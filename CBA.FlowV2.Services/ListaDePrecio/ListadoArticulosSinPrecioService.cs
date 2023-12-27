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
using CBA.FlowV2.Services.Articulos;

namespace CBA.FlowV2.Services.ListaDePrecio
{
    public class ListadoArticulosSinPrecioService
    {
        #region GetListadoArticulosSinPrecioInfoCompleta
        /// <summary>
        /// Gets the lista artículos sin precio data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetListadoArticulosSinPrecioInfoCompl(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.EstrategiaPrecio))
                {
                    case Definiciones.EstrategiaPrecio.FlujoModificacionListaPrecios:
                        return sesion.Db.LISTADO_ARTICULOS_SIN_PRECIOCollection.GetAsDataTable(clausulas, orden);
                    case Definiciones.EstrategiaPrecio.ModuloPrecios:
                        string sql =
                            " select aif." + ArticulosService.Id_NombreCol + ", " +
                            "        aif." + ArticulosService.EntidadId_NombreCol + ", " +
                            "        aif." + ArticulosService.CodigoEmpresa_NombreCol + ", " +
                            "        aif." + ArticulosService.FamiliaId_NombreCol + ", " +
                            "        aif." + ArticulosService.VistaFamiliaDescripcion_NombreCol + ", " +
                            "        aif." + ArticulosService.GrupoId_NombreCol + ", " +
                            "        aif." + ArticulosService.VistaGrupoDescripcion_NombreCol + ", " +
                            "        aif." + ArticulosService.SubgrupoId_NombreCol + ", " +
                            "        aif." + ArticulosService.VistaSubgrupoDescripcion_NombreCol + ", " +
                            "        nvl(aif." + ArticulosService.DescripcionImpresion_NombreCol + ", aif." + ArticulosService.DescripcionInterna_NombreCol + ") " + ArticulosService.VistaDescripcionAUtilizar_NombreCol + ", " +
                            "        'Sin Precio' " + ListadoArticulosSinPrecioService.VistaProblema_NombreCol +
                            "   from " + ArticulosService.Nombre_Vista + " aif " +
                            "  where aif." + ArticulosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                        if (clausulas.Length > 0)
                            sql += " and (" + clausulas + ")";
                        sql +=
                            "    and not exists(" +
                            "                   select p." + PreciosService.Id_NombreCol +
                            "                    from " + PreciosService.ArticulosPreciosHistoricos_Nombre_Tabla + " p" +
                            "                   where aif." + ArticulosService.Id_NombreCol + " = p." + PreciosService.ArticuloId_NombreCol +
                            "                   )" +
                            " order by aif." + ArticulosService.CodigoEmpresa_NombreCol;
                        return sesion.db.EjecutarQuery(sql);
                    case Definiciones.EstrategiaPrecio.WebService:
                        throw new Exception("La estrategia de precios WebService no puede mostrar los artículos sin precio.");
                    default:
                        throw new Exception("ListadoArticulosSinPrecioService.GetListadoArticulosSinPrecioInfoCompl(): Estrategia de precios no implementada.");
                }
            }
        }
        #endregion GetListadoArticulosSinPrecioInfoCompleta

        #region Accessors
        #region Vista
        public static string VistaCodigoEmpresa_NombreCol
        { get { return LISTADO_ARTICULOS_SIN_PRECIOCollection.CODIGO_EMPRESAColumnName; } }

        public static string VistaFamiliaDescripcion_NombreCol
        { get { return LISTADO_ARTICULOS_SIN_PRECIOCollection.FAMILIA_DESCRIPCIONColumnName; } }

        public static string VistaGrupoDescripcion_NombreCol
        { get { return LISTADO_ARTICULOS_SIN_PRECIOCollection.GRUPO_DESCRIPCIONColumnName; } }

        public static string VistaSubgrupoDescripcion_NombreCol
        { get { return LISTADO_ARTICULOS_SIN_PRECIOCollection.SUBGRUPO_DESCRIPCIONColumnName; } }

        public static string VistaDescripcionAUtilizar_NombreCol
        { get { return LISTADO_ARTICULOS_SIN_PRECIOCollection.DESCRIPCION_A_UTILIZARColumnName; } }

        public static string VistaProblema_NombreCol
        { get { return LISTADO_ARTICULOS_SIN_PRECIOCollection.PROBLEMAColumnName; } }
        #endregion Vista
        #endregion Accessors
    }
        
}

