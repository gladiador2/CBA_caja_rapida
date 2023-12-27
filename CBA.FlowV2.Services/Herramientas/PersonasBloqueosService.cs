using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.TextosPredefinidos;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasBloqueosService
    {
        #region GetPersonasBloqueosDataTable
        public DataTable GetPersonasBloqueosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_BLOQUEOSCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasBloqueosDataTable

        #region GetPersonasBloqueosInfoCompleta
        public DataTable GetPersonasBloqueosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_BLOQUEOS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasBloqueosInfoCompleta

        #region GetRegistroBloqueo
        public DataRow GetRegistroBloqueo(decimal personaId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = PersonaId_NombreCol + " = " + personaId.ToString();
                DataTable tabla = sesion.Db.PERSONAS_BLOQUEOSCollection.GetAsDataTable(clausulas, FechaBloqueo_NombreCol + " desc");
                return tabla.Rows[0];
            }
        }
        #endregion GetRegistroBloqueo

        #region PersonaBloqueada
        public bool PersonaBloqueada(decimal personaId)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string clausulas = PersonaId_NombreCol + " = " + personaId.ToString();
                table = sesion.Db.PERSONAS_BLOQUEOSCollection.GetAsDataTable(clausulas, FechaBloqueo_NombreCol + " desc");
                if (table.Rows.Count > 0 && (string)table.Rows[0][Desbloqueado_NombreCol]==Definiciones.SiNo.No)
                    return true;
                else
                    return false;
            }
        }
        #endregion PersonaBloqueada

        #region BloquearPersona
        public void BloquearPersona(decimal personaId, string motivo)
        {
            BloquearPersona(personaId, GetTextoMotivoId(motivo));
        }
        public void BloquearPersona(decimal personaId, decimal textoMotivoId)
        {
            if (textoMotivoId == Definiciones.Error.Valor.EnteroPositivo)
            {
                throw new Exception("No se encuentra en motivo entre los textos predefinidos");
            }
            if (PersonaBloqueada(personaId))
            {
                throw new Exception("La persona ya se encuentra bloqueada");
            }

            using (SessionService sesion = new SessionService())
            {
                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                campos.Add(FechaBloqueo_NombreCol, DateTime.Now);
                campos.Add(PersonaId_NombreCol, personaId);
                campos.Add(UsuarioBloqueoId_NombreCol, sesion.Usuario_Id);
                campos.Add(TextoMotivoId_NombreCol, textoMotivoId);
                campos.Add(Desbloqueado_NombreCol, Definiciones.SiNo.No);
                Guardar(campos, true);
            }
        }
        #endregion BloquearPersona

        #region DesbloquearPersona
        public void DesbloquearPersona(int usuario, decimal personaId)
        {
            if (!PersonaBloqueada(personaId))
            {
                throw new Exception("La persona no se encuentra bloqueada");
            }

            using (SessionService sesion = new SessionService())
            {
                string clausulas = PersonaId_NombreCol + " = " + personaId.ToString();
                DataTable tabla = sesion.Db.PERSONAS_BLOQUEOSCollection.GetAsDataTable(clausulas, FechaBloqueo_NombreCol + " desc");
                decimal id = (decimal)tabla.Rows[0][Id_NombreCol];

                sesion.BeginTransaction();
                PERSONAS_BLOQUEOSRow row = sesion.Db.PERSONAS_BLOQUEOSCollection.GetByPrimaryKey(id);
                if (usuario == 1)
                {
                    row.USUARIO_DESBLOQUEO1_ID = sesion.Usuario_Id;
                    row.FECHA_DESBLOQUEO1 = DateTime.Now;
                }
                if (usuario == 2)
                {
                    row.USUARIO_DESBLOQUEO2_ID = sesion.Usuario_Id;
                    row.FECHA_DESBLOQUEO2 = DateTime.Now;
                }
                if (usuario == 3)
                {
                    row.USUARIO_DESBLOQUEO3_ID = sesion.Usuario_Id;
                    row.FECHA_DESBLOQUEO3 = DateTime.Now;
                }
                
                PersonasService personas = new PersonasService();
                DataTable persona = personas.GetPersona(personaId);
                decimal nivelCreditoId = (decimal)persona.Rows[0][PersonasService.NivelCreditoId_NombreCol];

                PersonasNivelesCreditoService nivelesCredito = new PersonasNivelesCreditoService();
                DataRow nivelCredito = nivelesCredito.GetPersonasNivelesCredito(nivelCreditoId);

                if ((nivelCredito[PersonasNivelesCreditoService.RolDesbloqueo1_NombreCol].Equals(DBNull.Value) || !row.IsUSUARIO_DESBLOQUEO1_IDNull)
                    && (nivelCredito[PersonasNivelesCreditoService.RolDesbloqueo2_NombreCol].Equals(DBNull.Value) || !row.IsUSUARIO_DESBLOQUEO2_IDNull)
                    && (nivelCredito[PersonasNivelesCreditoService.RolDesbloqueo3_NombreCol].Equals(DBNull.Value) || !row.IsUSUARIO_DESBLOQUEO3_IDNull))
                {
                    row.DESBLOQUEADO = Definiciones.SiNo.Si;
                }
                sesion.Db.PERSONAS_BLOQUEOSCollection.Update(row);
                sesion.CommitTransaction();
            }
        }
        #endregion DesbloquearPersona

        #region GetTextoMotivoId
        private decimal GetTextoMotivoId(string motivo)
        {
            string clausulas = TextosPredefinidosService.TipoTextoPredefinidoId_NombreCol + " = " + Definiciones.TipoTextoPredefinido.MotivosBloqueoPersonas.ToString() +
                " and " + TextosPredefinidosService.Texto_NombreCol + " = '" + motivo +"'" +
                " and " + TextosPredefinidosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            DataTable tabla = TextosPredefinidosService.GetDataTable(clausulas, string.Empty);
            if (tabla.Rows.Count > 0)
                return (decimal)tabla.Rows[0][TextosPredefinidosService.Id_NombreCol];
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetTextoMotivoId

        #region Guardar
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PERSONAS_BLOQUEOSRow row = new PERSONAS_BLOQUEOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("personas_bloqueos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.PERSONAS_BLOQUEOSCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (campos.Contains(FechaBloqueo_NombreCol))
                        row.FECHA_BLOQUEO = (DateTime)campos[FechaBloqueo_NombreCol];
                    if (campos.Contains(PersonaId_NombreCol))
                        row.PERSONA_ID = decimal.Parse(campos[PersonaId_NombreCol].ToString());
                    if (campos.Contains(UsuarioBloqueoId_NombreCol))
                        row.USUARIO_BLOQUEO_ID = decimal.Parse(campos[UsuarioBloqueoId_NombreCol].ToString());
                    if (campos.Contains(TextoMotivoId_NombreCol))
                        row.TEXTO_MOTIVO_ID = decimal.Parse(campos[TextoMotivoId_NombreCol].ToString());
                    if (campos.Contains(Desbloqueado_NombreCol))
                        row.DESBLOQUEADO = campos[Desbloqueado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.PERSONAS_BLOQUEOSCollection.Insert(row);
                    else sesion.Db.PERSONAS_BLOQUEOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "PERSONAS_BLOQUEOS"; }
        }
        public static string Id_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.IDColumnName; }
        }
        public static string FechaBloqueo_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.FECHA_BLOQUEOColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.PERSONA_IDColumnName; }
        }
        public static string TextoMotivoId_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.TEXTO_MOTIVO_IDColumnName; }
        }
        public static string UsuarioBloqueoId_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.USUARIO_BLOQUEO_IDColumnName; }
        }
        public static string UsuarioDesbloqueo1Id_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.USUARIO_DESBLOQUEO1_IDColumnName; }
        }
        public static string FechaDesbloqueo1_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.FECHA_DESBLOQUEO1ColumnName; }
        }
        public static string UsuarioDesbloqueo2Id_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.USUARIO_DESBLOQUEO2_IDColumnName; }
        }
        public static string FechaDesbloqueo2_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.FECHA_DESBLOQUEO2ColumnName; }
        }
        public static string UsuarioDesbloqueo3Id_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.USUARIO_DESBLOQUEO3_IDColumnName; }
        }
        public static string FechaDesbloqueo3_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.FECHA_DESBLOQUEO3ColumnName; }
        }
        public static string Desbloqueado_NombreCol
        {
            get { return PERSONAS_BLOQUEOSCollection.DESBLOQUEADOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return PERSONAS_BLOQUEOS_INFO_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaTextoMotivo_NombreCol
        {
            get { return PERSONAS_BLOQUEOS_INFO_COMPCollection.TEXTO_MOTIVOColumnName; }
        }
        public static string VistaUsuarioBloqueoNombre_NombreCol
        {
            get { return PERSONAS_BLOQUEOS_INFO_COMPCollection.USUARIO_BLOQUEO_NOMBREColumnName; }
        }
        #endregion Metodos estaticos
    }
}
