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

namespace CBA.FlowV2.Services.ListaDePrecio
{
    public class ListaDePrecioHistoricoService
    {
        #region GetListadoArticulosSinPrecioInfoCompleta
        /// <summary>
        /// Gets the lista artículos sin precio data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListadoListaHistoricoInfoCompl()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LISTA_PRECIOS_HISTORICOCollection.GetAllAsDataTable();
            }
        }
        #endregion GetListadoArticulosSinPrecioInfoCompleta

        #region GetListadoArticulosSinPrecioInfoCompleta
        /// <summary>
        /// Gets the lista artículos sin precio data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListadoListaHistoricoInfoCompl(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LISTA_PRECIOS_HISTORICOCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetListadoArticulosSinPrecioInfoCompleta

        public static DataTable GetListas(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.LISTA_PRECIOS_HISTORICOCollection.GetAsDataTable(clausulas, orden);
            }
        }

        #region Accessors
        #region Vista
        public static string VistaCodigoEmpresa_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.CODIGO_EMPRESAColumnName; } }

        public static string VistaFamiliaDescripcion_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.FAMILIA_DESCRIPCIONColumnName; } }

        public static string VistaGrupoDescripcion_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.GRUPO_DESCRIPCIONColumnName; } }

        public static string VistaSubgrupoDescripcion_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.SUBGRUPO_DESCRIPCIONColumnName; } }

        public static string VistaDescripcionAUtilizar_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.DESCRIPCION_A_UTILIZARColumnName; } }

        public static string VistaFechaAprobacion_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.FECHA_APROBACIONColumnName; } }

        public static string VistaUsuario_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.USUARIO_NOMBRE_COMPLETOColumnName; } }

        public static string VistaListaPrecioNombre_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.LISTA_PRECIOS_NOMBREColumnName; } }

        public static string VistaListaPrecioID_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.LISTA_PRECIOS_IDColumnName; } }

        public static string VistaMonedaSimbolo_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.MONEDA_SIMBOLOColumnName; } }

        public static string VistaPrecioNuevo_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.PRECIO_NUEVOColumnName; } }

        public static string VistaFamiliaId_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.FAMILIA_IDColumnName; } }

        public static string VistaGrupoId_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.GRUPO_IDColumnName; } }

        public static string VistaSubGrupoId_NombreCol
        { get { return LISTA_PRECIOS_HISTORICOCollection.SUBGRUPO_IDColumnName; } }

        #endregion Vista
        #endregion Accessors
    }
        
}

