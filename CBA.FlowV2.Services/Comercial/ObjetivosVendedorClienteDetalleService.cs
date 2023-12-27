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
using System.Collections;
using CBA.FlowV2.Services.Articulos;
#endregion Using

namespace CBA.FlowV2.Services.Comercial
{
    public class ObjetivosVendedorClienteDetalleService
    {
        #region GetObjetivosVendedorClienteDetalleDataTable
        public static DataTable GetObjetivosVendedorClienteDetalleDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.OBJ_VEND_CLI_DET_INFO_COMPLETACollection.GetAsDataTable(where, string.Empty);
            }
        }
        #endregion GetObjetivosVendedorClienteDetalleDataTable

        #region Guardar
        public bool Guardar(bool esNuevo, Hashtable campos)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    sesion.Db.BeginTransaction();
                    string valorAnterior = string.Empty;
                    OBJ_VEND_CLIE_DETALLERow row = new OBJ_VEND_CLIE_DETALLERow();

                    if (esNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("obj_vend_clie_detalle_sqc");
                        row.CLIENTE_ID = (decimal)campos[ObjetivosVendedorClienteDetalleService.ClienteId_NombreCol];
                        row.VENDEDOR_ID = (decimal)campos[ObjetivosVendedorClienteDetalleService.VendedorId_NombreCol];
                        row.OBJETIVO_VENDEDOR_CLIENTE_ID = (decimal)campos[ObjetivosVendedorClienteDetalleService.ObjetivoVendedorClienteId_NombreCol];
                    }
                    else
                    {
                        decimal id = decimal.Parse(campos[ObjetivosVendedorClienteDetalleService.Id_NombreCol].ToString());
                        row = sesion.Db.OBJ_VEND_CLIE_DETALLECollection.GetByPrimaryKey(id);
                        valorAnterior = row.ToString();
                    }
                    //campos obligatorios venidos desde el CRUD
                    row.MONTO = (decimal)campos[ObjetivosVendedorClienteDetalleService.Monto_NombreCol];
                    
                    //se guardan los rows
                    if (esNuevo)
                    {
                        sesion.Db.OBJ_VEND_CLIE_DETALLECollection.Insert(row);
                    }
                    else
                    {
                        sesion.Db.OBJ_VEND_CLIE_DETALLECollection.Update(row);
                        Hashtable campos2 = new Hashtable();
                        campos2.Add(ObjetivosVendedorClienteService.Id_NombreCol, row.OBJETIVO_VENDEDOR_CLIENTE_ID);
                        (new ObjetivosVendedorClienteService()).Guardar(false, campos2);
                    }
                    //se guardan los cambios de log
                    LogCambiosService.LogDeRegistro(ObjetivosVendedorArticuloService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Guardar

        #region GetDetallesPorObjetivoId
        public DataTable GetDetallesPorObjetivoId(decimal objetivo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ObjetivosVendedorClienteDetalleService.ObjetivoVendedorClienteId_NombreCol + " = " + objetivo_id;
                return sesion.Db.OBJ_VEND_CLI_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        public DataTable GetDetallesPorVendedor(decimal vendedor_id)
        { 
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ObjetivosVendedorClienteDetalleService.VendedorId_NombreCol + "=" + vendedor_id;
                return sesion.Db.OBJ_VEND_CLI_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        public DataTable GetDetallesPorVendedorWhere(decimal vendedor_id, string where)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ObjetivosVendedorClienteDetalleService.VendedorId_NombreCol + "=" + vendedor_id;
                clausulas += " and " + where;
                return sesion.Db.OBJ_VEND_CLI_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        #endregion GetDetallesPorObjetivoId

        #region Constructor
        public ObjetivosVendedorClienteDetalleService()
        {

        }
        #endregion Constructor

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "OBJ_VEND_CLIE_DETALLE"; }
        }


        //id
        public static string Id_NombreCol
        {
            get { return OBJ_VEND_CLIE_DETALLECollection.IDColumnName; }
        }
        //objetivo_vendedor_cliente_id
        public static string ObjetivoVendedorClienteId_NombreCol
        {
            get { return OBJ_VEND_CLIE_DETALLECollection.OBJETIVO_VENDEDOR_CLIENTE_IDColumnName; }
        }
        //cliente_id
        public static string ClienteId_NombreCol
        {
            get { return OBJ_VEND_CLIE_DETALLECollection.CLIENTE_IDColumnName; }
        }
        //vendedor_id
        public static string VendedorId_NombreCol
        {
            get { return OBJ_VEND_CLIE_DETALLECollection.VENDEDOR_IDColumnName; }
        }
        //monto
        public static string Monto_NombreCol
        {
            get { return OBJ_VEND_CLIE_DETALLECollection.MONTOColumnName; }
        }

        #endregion Tabla

        #region Vista


        //persona_nombre
        public static string VistaPersonaNombre_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        //persona_codigo
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.PERSONA_CODIGOColumnName; }
        }
        //funcionario_codigo
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.FUNCIONARIO_CODIGOColumnName; }
        }
        //funcionario_nombre
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.FUNCIONARIO_NOMBREColumnName; }
        }
        //moneda_id
        public static string VistaMonedaId_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.MONEDA_IDColumnName; }
        }
        //moneda_nombre
        public static string VistaMonedaNombreId_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        //temporada_id
        public static string VistaTemporadaId_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.TEMPORADA_IDColumnName; }
        }
        //temporada_nombre
        public static string VistaTemporadaNombre_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.TEMPORADA_NOMBREColumnName; }
        }
        //anho
        public static string VistaAnho_NombreCol
        {
            get { return OBJ_VEND_CLI_DET_INFO_COMPLETACollection.ANHOColumnName; }
        }

        #endregion Vista

        #endregion Accessors

    }
}
