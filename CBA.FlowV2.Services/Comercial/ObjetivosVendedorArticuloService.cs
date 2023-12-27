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
    public class ObjetivosVendedorArticuloService
    {
        #region GetObjetivoArticuloPorVendedorTableInfoCompleta
        public DataTable GetObjetivoArticuloPorVendedorTableInfoCompleta()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJ_VEND_ART_INFO_COMPLETACollection.GetAsDataTable(ObjetivosVendedorArticuloService.VistaEntidadId_NombreCol + "=" + sesion.Entidad.ID, "upper(" + ObjetivosVendedorArticuloService.ArticuloTemporadaId_NombreCol + ")");
                return table;
            }
        }

        public DataTable GetObjetivoArticuloPorVendedorTableInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ObjetivosVendedorArticuloService.VistaEntidadId_NombreCol + "=" + sesion.Entidad.ID;
                where += " and " + clausulas; 
                DataTable table = sesion.Db.OBJ_VEND_ART_INFO_COMPLETACollection.GetAsDataTable(where, "upper(" + ObjetivosVendedorArticuloService.ArticuloTemporadaId_NombreCol + ")");
                return table;
            }
        }

        public DataTable GetObjetivoArticuloPorVendedorTableInfoCompleta(decimal temporada_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJ_VEND_ART_INFO_COMPLETACollection.GetAsDataTable(ObjetivosVendedorArticuloService.ArticuloTemporadaId_NombreCol + "=" + temporada_id, "upper(" + ObjetivosVendedorArticuloService.ArticuloTemporadaId_NombreCol + ")");
                return table;
            }
        }
        #endregion GetObjetivoArticuloPorVendedorTableInfoCompleta

        #region GetObjetivoVendedorArticuloDataTable
        public DataTable GetObjetivoVendedorArticuloDataTable(decimal objetivo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.OBJETIVO_VENDEDOR_ARTICULOCollection.GetAsDataTable(ObjetivosVendedorArticuloService.Id_NombreCol + " = " + objetivo_id, "upper(" + ObjetivosVendedorArticuloService.ArticuloTemporadaId_NombreCol + ")");
                return table;
            }
        }
        #endregion GetObjetivoVendedorArticuloDataTable
        
        #region Guardar
        public decimal Guardar(bool esNuevo, Hashtable campos)
        {
            
            
            try
            {
                
                using (SessionService sesion = new SessionService())
                {
                    sesion.Db.BeginTransaction();  
                    string valorAnterior = string.Empty;
                    OBJETIVO_VENDEDOR_ARTICULORow row = new OBJETIVO_VENDEDOR_ARTICULORow();

                    if (esNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("objetivo_vendedor_articulo_sqc");
                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREADOR_ID = sesion.Usuario.ID;
                        row.ARTICULO_TEMPORADA_ID = (decimal)campos[ObjetivosVendedorArticuloService.ArticuloTemporadaId_NombreCol];

                    }
                    else 
                    {
                        decimal id = decimal.Parse(campos[ObjetivosVendedorArticuloService.Id_NombreCol].ToString());
                        row = sesion.Db.OBJETIVO_VENDEDOR_ARTICULOCollection.GetByPrimaryKey(id);
                        valorAnterior = row.ToString();

                    }
                    //campos obligatorios venidos desde el CRUD
                    
                    

                    //campos obligatorios desde el service
                    row.FECHA_MODIFICACION = DateTime.Now;
                    row.USUARIO_MODIFICADOR_ID = sesion.Usuario.ID;

                    //se guardan los rows
                    if (esNuevo) sesion.Db.OBJETIVO_VENDEDOR_ARTICULOCollection.Insert(row);
                    else sesion.Db.OBJETIVO_VENDEDOR_ARTICULOCollection.Update(row);

                    //se guardan los cambios de log
                    LogCambiosService.LogDeRegistro(ObjetivosVendedorArticuloService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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
        public ObjetivosVendedorArticuloService()
        {

        }
        #endregion Constructor

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "OBJETIVO_VENDEDOR_ARTICULO"; }
        }
        public static string Id_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_ARTICULOCollection.IDColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_ARTICULOCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaModificacion_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_ARTICULOCollection.FECHA_MODIFICACIONColumnName; }
        }
        public static string ArticuloTemporadaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_ARTICULOCollection.ARTICULO_TEMPORADA_IDColumnName; }
        }
        
        public static string UsuarioCreadorId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_ARTICULOCollection.USUARIO_CREADOR_IDColumnName; }
        }
        public static string UsuarioModificadorId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_ARTICULOCollection.USUARIO_MODIFICADOR_IDColumnName; }
        }
        
        
        #endregion Tabla

        #region Vista
        public static string VistaEntidadId_NombreCol
        {
            get { return OBJ_VEND_ART_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaTemporadaFin_NombreCol
        {
            get { return OBJ_VEND_ART_INFO_COMPLETACollection.TEMPORADA_FINColumnName; }
        }
        public static string VistaTemporadaInicio_NombreCol
        {
            get { return OBJ_VEND_ART_INFO_COMPLETACollection.TEMPORADA_INICIOColumnName; }
        }
        public static string VistaTemporadaNombre_NombreCol
        {
            get { return OBJ_VEND_ART_INFO_COMPLETACollection.TEMPORADA_NOMBREColumnName; }
        }
        public static string VistaUsuarioCreacion_NombreCol
        {
            get { return OBJ_VEND_ART_INFO_COMPLETACollection.USUARIO_CREACIONColumnName; }
        }
        public static string VistaUsuarioModificacion_NombreCol
        {
            get { return OBJ_VEND_ART_INFO_COMPLETACollection.USUARIO_MODIFICACIONColumnName; }
        }
                                       
       
        #endregion Vista

        #endregion Accessors

    }
}
