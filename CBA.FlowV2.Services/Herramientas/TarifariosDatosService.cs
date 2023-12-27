#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class TarifariosDatosService
    {
        #region GetDataTable
        public static DataTable GetTarifariosDatosDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarifariosDatosDataTable(where, orden, sesion);
            }
        }

        public static DataTable GetTarifariosDatosDataTable(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TARIFARIOS_DATOSCollection.GetAsDataTable(where, orden);
        }

        public static DataTable GetTarifariosDatosInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarifariosDatosInfoCompleta(where, orden, sesion);
            }
        }

        public static DataTable GetTarifariosDatosInfoCompleta(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TARIFARIOS_DATOS_INF_COMPCollection.GetAsDataTable(where, orden);
        }
        #endregion GetDataTable

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    decimal tarifarioDatoId = Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();

                    return tarifarioDatoId;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                TARIFARIOS_DATOSRow row = new TARIFARIOS_DATOSRow();
                TARIFARIOS_DATOSRow oldRow = new TARIFARIOS_DATOSRow();
                String valorAnterior = string.Empty;

                if (!campos.Contains(TarifariosDatosService.PersonaId_NombreCol))
                    throw new Exception("Debe indicar la Persona.");
                if (!campos.Contains(TarifariosDatosService.FilaEspecial_NombreCol))
                    throw new Exception("Debe Indicar el tipo de Registro.");

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("tarifarios_datos_sqc");
                }
                else
                {
                    oldRow = sesion.Db.TARIFARIOS_DATOSCollection.GetByPrimaryKey(decimal.Parse(campos[TarifariosDatosService.Id_NombreCol].ToString()));
                    valorAnterior = oldRow.ToString();

                    // Se crea y asocia el nuevo registro al original para el historico
                    row.ID = sesion.Db.GetSiguienteSecuencia("tarifarios_datos_sqc");
                    row.ESTADO = oldRow.ESTADO;
                    row.FECHA_MODIFICACION = oldRow.FECHA_MODIFICACION;
                    row.FILA_ESPECIAL = oldRow.FILA_ESPECIAL;
                    row.TARIFARIO_ID = oldRow.TARIFARIO_ID;
                    row.USUARIO_MODIFICACION_ID = oldRow.USUARIO_MODIFICACION_ID;
                    row.VALOR = oldRow.VALOR;

                    if (!oldRow.IsDATO_RELACIONADO_IDNull)
                        row.DATO_RELACIONADO_ID = oldRow.DATO_RELACIONADO_ID;

                    if (oldRow.IsDATO_RELACIONADO_IDNull)
                        row.DATO_RELACIONADO_ID = oldRow.ID;
                    else
                        row.DATO_RELACIONADO_ID = oldRow.DATO_RELACIONADO_ID;
                }

                if (RolesService.Tiene("TARIFARIOS PUEDE EDITAR DATOS DE OTROS FUNCIONARIOS"))
                {
                    if (!campos.Contains(TarifariosDatosService.FuncionarioId_NombreCol))
                        throw new Exception("Debe indicar el funcionario.");
                    
                    row.FUNCIONARIO_ID = decimal.Parse(campos[TarifariosDatosService.FuncionarioId_NombreCol].ToString());
                }
                else
                {
                    row.FUNCIONARIO_ID = sesion.Usuario_Funcionario_id;
                }

                row.PERSONA_ID = decimal.Parse(campos[TarifariosDatosService.PersonaId_NombreCol].ToString());
                row.TARIFARIO_ID = (decimal)campos[TarifariosDatosService.TarifarioId_NombreCol];
                row.USUARIO_MODIFICACION_ID = sesion.Usuario_Id;
                row.ESTADO = Definiciones.Estado.Activo;
                row.FECHA_MODIFICACION = DateTime.Now;
                row.FILA_ESPECIAL = campos[TarifariosDatosService.FilaEspecial_NombreCol].ToString();
                row.TIPO_VALOR = (string)campos[TarifariosDatosService.TipoValor_NombreCol];

                string where = TarifariosDatosService.TarifarioId_NombreCol + "=" + row.TARIFARIO_ID;
                where += " and " + TarifariosDatosService.PersonaId_NombreCol + "=" + row.PERSONA_ID;
                where += " and " + TarifariosDatosService.Estado_NombreCol + "='" + Definiciones.Estado.Activo + "'";
                
                if (!insertarNuevo)
                    where += " and " + TarifariosDatosService.Id_NombreCol + "<>" + oldRow.ID;

                DataTable dt = TarifariosDatosService.GetTarifariosDatosInfoCompleta(where, string.Empty);
                if (dt.Rows.Count > 0)
                    throw new Exception("El Cliente " + dt.Rows[0][TarifariosDatosService.VistaPersonaNombre_NombreCol] + " ya tiene asignado datos en este tarifario");

                if (campos.Contains(TarifariosDatosService.Valor_NombreCol))
                    row.VALOR = ((campos[TarifariosDatosService.Valor_NombreCol].ToString()));

                sesion.Db.TARIFARIOS_DATOSCollection.Insert(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                // Se borra el registro anterior
                if (!insertarNuevo)
                    TarifariosDatosService.Borrar(oldRow.ID, sesion);

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal tarifario_dato_id, SessionService sesion)
        {
            try
            {
                TARIFARIOS_DATOSRow row = sesion.Db.TARIFARIOS_DATOSCollection.GetByPrimaryKey(tarifario_dato_id);
                String valorAnterior = row.ToString();

                row.ESTADO = Definiciones.Estado.Inactivo;
                row.FECHA_MODIFICACION = DateTime.Now;
                row.USUARIO_MODIFICACION_ID = sesion.Usuario_Id;

                sesion.Db.TARIFARIOS_DATOSCollection.Update(row);
                LogCambiosService.LogDeRegistro(TarifariosDatosService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }

        public static void Borrar(decimal tarifario_dato_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    Borrar(tarifario_dato_id, sesion);
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TARIFARIOS_DATOS"; }
        }
        public static string DatoRelacionadoId_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.DATO_RELACIONADO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.ESTADOColumnName; }
        }
        public static string FechaModificacion_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.FECHA_MODIFICACIONColumnName; }
        }
        public static string FilaEspecial_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.FILA_ESPECIALColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.IDColumnName; }
        }
        public static string TarifarioId_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.TARIFARIO_IDColumnName; }
        }
        public static string UsuarioModificacionId_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.USUARIO_MODIFICACION_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.PERSONA_IDColumnName; }
        }
        public static string Valor_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.VALORColumnName; }
        }
        public static string TipoValor_NombreCol
        {
            get { return TARIFARIOS_DATOSCollection.TIPO_VALORColumnName; }
        }
        public static string VistaTarifariosNombre_NombreCol
        {
            get { return TARIFARIOS_DATOS_INF_COMPCollection.TARIFARIOS_NOMBREColumnName; }
        }
        public static string VistaUsuarioModificacionNombre_NombreCol
        {
            get { return TARIFARIOS_DATOS_INF_COMPCollection.USUARIO_MODIFICACION_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return TARIFARIOS_DATOS_INF_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return TARIFARIOS_DATOS_INF_COMPCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return TARIFARIOS_DATOS_INF_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return TARIFARIOS_DATOS_INF_COMPCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        #endregion Accessors
    }
}

