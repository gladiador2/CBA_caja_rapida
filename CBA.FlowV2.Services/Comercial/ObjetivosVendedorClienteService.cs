using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Collections;
using CBA.FlowV2.Services.Herramientas;


namespace CBA.FlowV2.Services.Comercial
{
    public class ObjetivosVendedorClienteService
    {
        #region GetObjetivoClientePorVendedorTableInfoCompleta

        public DataTable GetObjetivoClientePorVendedorTableInfoCompleta()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJ_VEND_CLI_INFO_COMPLETACollection.GetAsDataTable(ObjetivosVendedorClienteService.VistaEntidadId_NombreCol + "=" + sesion.Entidad.ID, "upper(" + ObjetivosVendedorClienteService.TemporadaId_NombreCol + ")");
                return table;
            }
        }

        public DataTable GetObjetivoClientePorVendedorTableInfoCompleta(decimal temporada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJ_VEND_CLI_INFO_COMPLETACollection.GetAsDataTable(ObjetivosVendedorClienteService.TemporadaId_NombreCol + "=" + temporada_id, "upper(" + ObjetivosVendedorClienteService.TemporadaId_NombreCol + ")");
                return table;
            }
        }

        public DataTable GetObjetivoClientePorVendedorTableInfoCompleta(decimal temporada_id, decimal anho)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJ_VEND_CLI_INFO_COMPLETACollection.GetAsDataTable(ObjetivosVendedorClienteService.TemporadaId_NombreCol + "=" + temporada_id + " and " + ObjetivosVendedorClienteService.Anho_NombreCol + "=" +  anho, "upper(" + ObjetivosVendedorClienteService.TemporadaId_NombreCol + ")");
                return table;
            }
        }

        #endregion GetObjetivoClientePorVendedorTableInfoCompleta

        #region GetObjetivoVendedorClienteDataTable
        public DataTable GetObjetivoVendedorClienteDataTable(decimal objetivo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJETIVO_VENDEDOR_CLIENTECollection.GetAsDataTable(ObjetivosVendedorClienteService.Id_NombreCol + " = " + objetivo_id, "upper(" + ObjetivosVendedorClienteService.TemporadaId_NombreCol + ")");
                return table;
            }
        }

        public static DataTable GetObjetivoVendedorClienteDataTable2(decimal objetivo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJETIVO_VENDEDOR_CLIENTECollection.GetAsDataTable(ObjetivosVendedorClienteService.Id_NombreCol + " = " + objetivo_id, "upper(" + ObjetivosVendedorClienteService.TemporadaId_NombreCol + ")");
                return table;
            }
        }
        #endregion GetObjetivoVendedorClienteDataTable

        #region Guardar
        public decimal Guardar(bool esNuevo, Hashtable campos)
        {
            try
            {
                
                using (SessionService sesion = new SessionService())
                {
                    sesion.Db.BeginTransaction();  
                    string valorAnterior = string.Empty;
                    OBJETIVO_VENDEDOR_CLIENTERow row = new OBJETIVO_VENDEDOR_CLIENTERow();
                    
                    if (esNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("objetivo_vendedor_cliente_sqc");
                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREADOR_ID = sesion.Usuario.ID;
                        row.TEMPORADA_ID = (decimal)campos[ ObjetivosVendedorClienteService.TemporadaId_NombreCol ];
                        row.PORCENTAJE = (decimal)campos[ ObjetivosVendedorClienteService.Porcentaje_NombreCol ];
                    }
                    else 
                    {
                        decimal id = decimal.Parse(campos[ObjetivosVendedorClienteService.Id_NombreCol].ToString());
                        row = sesion.Db.OBJETIVO_VENDEDOR_CLIENTECollection.GetByPrimaryKey(id);
                        valorAnterior = row.ToString();
                    }
                    //campos obligatorios venidos desde el CRUD
                    //se usan las condicionales para evitar errores en el momento de ejecucion 
                    //cuando se actualiza desde la tabla detalles
                    if(campos.Contains(ObjetivosVendedorClienteService.Anho_NombreCol))
                        row.ANHO = (decimal)campos[ObjetivosVendedorClienteService.Anho_NombreCol];
                    if (campos.Contains(ObjetivosVendedorClienteService.MonedaId_NombreCol))
                        row.MONEDA_ID = (decimal)campos[ObjetivosVendedorClienteService.MonedaId_NombreCol];

                    //campos obligatorios desde el service
                    row.FECHA_MODIFICACION = DateTime.Now;
                    row.USUARIO_MODIFICADOR_ID = sesion.Usuario.ID;

                    //se guardan los rows
                    if (esNuevo) sesion.Db.OBJETIVO_VENDEDOR_CLIENTECollection.Insert(row);
                    else sesion.Db.OBJETIVO_VENDEDOR_CLIENTECollection.Update(row);

                    //se guardan los cambios de log
                    LogCambiosService.LogDeRegistro(ObjetivosVendedorClienteService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                
            }
            catch (Exception e)
            {
                return Definiciones.Error.Valor.EnteroPositivo;
            }


        }
        #endregion Guardar

        #region Constructor
        public ObjetivosVendedorClienteService()
        {

        }
        #endregion Constructor

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "OBJETIVO_VENDEDOR_CLIENTE"; }
        }
        //id 
        public static string Id_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.IDColumnName; }
        }
        //articulo_temporada_id 
        public static string TemporadaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.TEMPORADA_IDColumnName; }
        }
        //usuario_creador_id
        public static string UsuarioCreadorId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.USUARIO_CREADOR_IDColumnName; }
        }
        //fecha_creacion
        public static string FechaCreacion_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.FECHA_CREACIONColumnName; }
        }
        //usuario_modificador_id 
        public static string UsuarioModificadorId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.USUARIO_MODIFICADOR_IDColumnName; }
        }
        //fecha_modificacion 
        public static string FechaModificacion_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.FECHA_MODIFICACIONColumnName; }
        }
        //moneda_id
        public static string MonedaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.MONEDA_IDColumnName; }
        }
        //anho_id
        public static string Anho_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.ANHOColumnName; }
        }
        //porcentaje
        public static string Porcentaje_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_CLIENTECollection.PORCENTAJEColumnName; }
        }
        #endregion Tabla

        #region Vista

        //id
        public static string VistaId_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.IDColumnName; }
        }
        //articulo_temporada_id 
        public static string VistaArticuloTemporadaId_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.TEMPORADA_IDColumnName; }
        }
        //temporada_nombre 
        public static string VistaTemporadaNombre_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.TEMPORADA_NOMBREColumnName; }
        }
        //entidad_id 
        public static string VistaEntidadId_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        //temporada_inicio 
        public static string VistaTemporadaInicio_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.TEMPORADA_INICIOColumnName; }
        }
        //temporada_fin
        public static string VistaTemporadaFin_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.TEMPORADA_FINColumnName; }
        }
        //usuario_creador_id 
        public static string VistaUsuarioCreadorId_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.USUARIO_CREADOR_IDColumnName; }
        }
        //moneda_id
        public static string VistaMonedaId_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.MONEDA_IDColumnName; }
        }
        //moneda_nombre 
        public static string VistaMonedaNombre_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        //moneda_simbolo
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        //usuario_creacion 
        public static string VistaUsuarioCreacion_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.USUARIO_CREACIONColumnName; }
        }
        //fecha_creacion
        public static string VistaFechaCreacion_NombreCol
        {
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.FECHA_CREACIONColumnName; }
        }
        //usuario_modificador_id 
        public static string VistaUsuarioModificadorId_NombreCol
        { 
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.USUARIO_MODIFICADOR_IDColumnName; }
        }
        //usuario_modificacion
        public static string VistaUsuarioModificacion_NombreCol
        {
            get {return OBJ_VEND_CLI_INFO_COMPLETACollection.USUARIO_MODIFICACIONColumnName; }
        }
        //fecha_modificacion
        public static string VistaFechaModificacion_NombreCol{
            get { return OBJ_VEND_CLI_INFO_COMPLETACollection.FECHA_MODIFICACIONColumnName; }
        }
        #endregion Vista

        #endregion Accessors

    }
}
