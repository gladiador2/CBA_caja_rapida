using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;
using CBA.FlowV2.Services.Tesoreria;

namespace CBA.FlowV2.Services.Casos
{
    public class CasosJudicializadosService
    {
        #region GetCasosJudicializadosDataTable
        public DataTable GetCasosJudicializadosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CASOS_JUDICIALIZADOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCasosJudicializadosDataTable

        #region GetCasosJudicializadosInfoCompleta
        public DataTable GetCasosJudicializadosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CASOS_JUDICIALIZADOS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCasosJudicializadosInfoCompleta

        #region Agregar
        public bool Agregar(decimal casoId, decimal motivoId, string observacion)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CasoId_NombreCol + " = " + casoId +
                    " and " + FechaSalida_NombreCol + " is null";
                DataTable dt = GetCasosJudicializadosDataTable(clausulas, string.Empty);
                if (dt.Rows.Count > 0) return false;

                try
                {
                    sesion.Db.BeginTransaction();

                    CASOS_JUDICIALIZADOSRow row = new CASOS_JUDICIALIZADOSRow();
                    String valorAnterior = string.Empty;
                    row.ID = sesion.Db.GetSiguienteSecuencia("casos_judicializados_sqc");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.CASO_ID = casoId;
                    row.FECHA_ENTRADA = DateTime.Now;
                    row.OBSERVACION_ENTRADA = observacion;
                    row.MOTIVO_ENTRADA_ID = motivoId;
                    row.USUARIO_ENTRADA_ID = sesion.Usuario_Id;

                    sesion.Db.CASOS_JUDICIALIZADOSCollection.Insert(row);

                    CuentaCorrientePersonasService ctactePersona = new CuentaCorrientePersonasService();

                    ctactePersona.ModificarJudicial(sesion, row.CASO_ID, true);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
            return true;
        }
        #endregion Agregar

        #region Quitar
        public void Quitar(decimal id, decimal motivoId, string observacion)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CASOS_JUDICIALIZADOSRow row = new CASOS_JUDICIALIZADOSRow();
                    String valorAnterior = string.Empty;
                    row = sesion.Db.CASOS_JUDICIALIZADOSCollection.GetByPrimaryKey(id);
                    valorAnterior = row.ToString();
                    row.ID = id;
                    row.FECHA_SALIDA = DateTime.Now;
                    row.OBSERVACION_SALIDA = observacion;
                    row.MOTIVO_SALIDA_ID = motivoId;
                    row.USUARIO_SALIDA_ID = sesion.Usuario_Id;
                    sesion.Db.CASOS_JUDICIALIZADOSCollection.Update(row);

                    CuentaCorrientePersonasService ctactePersona = new CuentaCorrientePersonasService();

                    ctactePersona.ModificarJudicial(sesion, row.CASO_ID, false);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Quitar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CASOS_JUDICIALIZADOS"; }
        }
        public static string CasoId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.CASO_IDColumnName; }
        }
        public static string FechaEntrada_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.FECHA_ENTRADAColumnName; }
        }
        public static string FechaSalida_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.FECHA_SALIDAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.IDColumnName; }
        }
        public static string ObservacionEntrada_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.OBSERVACION_ENTRADAColumnName; }
        }
        public static string ObservacionSalida_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.OBSERVACION_SALIDAColumnName; }
        }
        public static string MotivoEntradaId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.MOTIVO_ENTRADA_IDColumnName; }
        }
        public static string MotivoSalidaId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.MOTIVO_SALIDA_IDColumnName; }
        }
        public static string UsuarioEntradaId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.USUARIO_ENTRADA_IDColumnName; }
        }
        public static string UsuarioSalidaId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOSCollection.USUARIO_SALIDA_IDColumnName; }
        }

        public static string VistaMotivoEntrada_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.MOTIVO_ENTRADAColumnName; }
        }
        public static string VistaMotivoSalida_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.MOTIVO_SALIDAColumnName; }
        }
        public static string VistaEstadoId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.ESTADO_IDColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.FLUJO_IDColumnName; }
        }
        public static string VistaNroComprobante_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.PERSONA_IDColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaProveedorId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.PROVEEDOR_IDColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CASOS_JUDICIALIZADOS_INFO_COMPCollection.SUCURSAL_NOMBREColumnName; }
        }
        #endregion Accessors

    }
}
