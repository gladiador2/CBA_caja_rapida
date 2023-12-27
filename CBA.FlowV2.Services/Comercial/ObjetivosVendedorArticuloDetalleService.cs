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


namespace CBA.FlowV2.Services.Comercial
{
    public class ObjetivosVendedorArticuloDetalleService
    {
        #region Guardar
        public bool Guardar(bool esNuevo, Hashtable campos)
        {


            try
            {

                using (SessionService sesion = new SessionService())
                {
                    sesion.Db.BeginTransaction();
                    string valorAnterior = string.Empty;
                    OBJ_VEND_ARTI_DETALLERow row = new OBJ_VEND_ARTI_DETALLERow();

                    if (esNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("obj_vend_arti_detalle_sqc");
                        row.ARTICULO_ID = (decimal)campos[ObjetivosVendedorArticuloDetalleService.ArticuloId_NombreCol];
                        row.VENDEDOR_ID = (decimal)campos[ObjetivosVendedorArticuloDetalleService.VendedorId_NombreCol];
                        row.OBJETIVO_VENDEDOR_ARTICULO_ID = (decimal)campos[ObjetivosVendedorArticuloDetalleService.ObjetivoId_NombreCol];

                    }
                    else
                    {
                        decimal id = decimal.Parse(campos[ObjetivosVendedorArticuloDetalleService.Id_NombreCol].ToString());
                        row = sesion.Db.OBJ_VEND_ARTI_DETALLECollection.GetByPrimaryKey(id);

                    }
                    //campos obligatorios venidos desde el CRUD

                    
                    row.CANTIDAD = (decimal)campos[ObjetivosVendedorArticuloDetalleService.Cantidad_NombreCol];
                    decimal total = 0;
                    if(!esNuevo)
                    {
                        OBJ_VEND_ARTI_DETALLERow[] detallesRow = sesion.Db.OBJ_VEND_ARTI_DETALLECollection.GetByOBJETIVO_VENDEDOR_ARTICULO_ID(row.OBJETIVO_VENDEDOR_ARTICULO_ID);
                        for (int i = 0; i < detallesRow.Length; i++)
                        {
                            if(detallesRow[i].ID!=row.ID && detallesRow[i].ARTICULO_ID==row.ARTICULO_ID)
                            {
                                total += detallesRow[i].CANTIDAD;
                            }
                        }
                        total += row.CANTIDAD;
                        OBJETIVO_VENDEDOR_ARTICULORow cabeceraRow = sesion.Db.OBJETIVO_VENDEDOR_ARTICULOCollection.GetByPrimaryKey( row.OBJETIVO_VENDEDOR_ARTICULO_ID);
                        decimal cantidadObjetivo = (new ArticulosPorTemporadaDetallesService()).GetTotalArticuloPorTemporada(cabeceraRow.ARTICULO_TEMPORADA_ID, row.ARTICULO_ID);
                    }

                     //se guardan los rows
                    if (esNuevo)
                    {
                        sesion.Db.OBJ_VEND_ARTI_DETALLECollection.Insert(row);
                    }
                    else
                    {
                        sesion.Db.OBJ_VEND_ARTI_DETALLECollection.Update(row);
                        Hashtable campos2 = new Hashtable();
                        campos2.Add(ObjetivosVendedorArticuloService.Id_NombreCol, row.OBJETIVO_VENDEDOR_ARTICULO_ID);
                        (new ObjetivosVendedorArticuloService()).Guardar(false, campos2);
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
                //return false;
            }


        }
        #endregion Guardar

        #region GetDetallesPorObjetivoId
        public DataTable GetDetallesPorObjetivoId(decimal objetivo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ObjetivosVendedorArticuloDetalleService.ObjetivoId_NombreCol + " = " + objetivo_id;
                return sesion.Db.OBJ_VEND_ART_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        public static DataTable GetDetallesPorObjetivoId(decimal objetivo_id, string where)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = ObjetivosVendedorArticuloDetalleService.ObjetivoId_NombreCol + " = " + objetivo_id;
                clausulas += " and " + where; 
                return sesion.Db.OBJ_VEND_ART_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        #endregion GetDetallesPorObjetivoId

        #region GetDetallesInfoCompleta
        public DataTable GetDetallesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.OBJ_VEND_ART_DET_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDetallesInfoCompleta


        #region GetDatosParaListados
        public static DataTable GetDatosParaListado(decimal objetivoVendedorArticulo)
        {
            using (SessionService sesion = new SessionService())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select distinct ovaic.id objetivo_vend_articulo_id, \n");
                query.Append("       ovaic.temporada_nombre, \n");
                query.Append("       ovaicdet.articulo_id, \n");
                query.Append("       ovaicdet.articulo_codigo, \n");
                query.Append("       ovaicdet.articulo_grupo, \n");
                query.Append("       ovaicdet.articulo_descripcion, \n");
                query.Append("       ovaicdet.articulo_descripcion, \n");
                query.Append("       (select herramientas.Obtener_Cantidad_Articulo(ovaicdet.articulo_id) from dual) STOCK_ACTUAL \n");
                query.Append("  from obj_vend_art_det_info_completa ovaicdet \n");
                query.Append("  join obj_vend_art_info_completa ovaic on ovaicdet.objetivo_vendedor_articulo_id = \n");
                query.Append("                                           ovaic.id");
                query.Append("  where ovaic.id = ").Append(objetivoVendedorArticulo.ToString());

                return sesion.db.EjecutarQuery(query.ToString());
            }
        }

        public static DataTable GetFuncionarioPorArticulosPorObjetivo(decimal objetivoVendedorArticuloId, decimal articulosId)
        {
            using (SessionService sesion = new SessionService())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select distinct obj.vendedor_id, obj.funcionario_nombre, nvl(obj.cantidad,0) cantidad \n");
                query.Append("  from obj_vend_art_det_info_completa obj \n");
                query.Append(" where obj.objetivo_vendedor_articulo_id = " + objetivoVendedorArticuloId.ToString()  + " \n");
                query.Append("   and obj.articulo_id = " + articulosId.ToString() + " and obj.cantidad > 0 order by obj.funcionario_nombre");

                return sesion.db.EjecutarQuery(query.ToString());
            }
        }

        public static decimal GetOjetivoVentasArticulosPorVendedor(decimal objetivoVendedorPorArticuloId,decimal articuloId,decimal funcionarioId, string fechaIncio, string fechaFin, bool filtrarPorTemporada)
        {

            using (SessionService sesion = new SessionService())
            {
                StringBuilder query = new StringBuilder();
                query.Append("SELECT articulo_id, \n");
                query.Append("               vendedor_id, \n");
                query.Append("               sum(cantidad_vt - cantidad_dv) total_venta \n");
                query.Append("        FROM   (SELECT 'FC'                                             tipo, \n");
                query.Append("                       a.id articulo_id, \n");
                query.Append("                       fd.cantidad_unitaria_total_dest                  cantidad_vt, \n");
                query.Append("                       0                                                cantidad_dv, \n");
                query.Append("                       trunc(fc.fecha)                                  fecha, \n");
                query.Append("                       fc.vendedor_id, \n");
                query.Append("                       c.flujo_id, \n");
                query.Append("                       c.estado_id \n");
                query.Append("                FROM   facturas_cliente_info_completa fc, \n");
                query.Append("                       facturas_cliente_det_inf_co fd, \n");
                query.Append("                       articulos_info_completa a, \n");
                query.Append("                       personas p, \n");
                query.Append("                       casos c, \n");
                query.Append("                       ctacte_condiciones_pago ccp \n");
                query.Append("                WHERE  fd.facturas_cliente_id = fc.id AND \n");
                query.Append("                       fc.estado = 'A' AND \n");
                query.Append("                       fd.articulo_id = a. id AND \n");
                query.Append("                       fc.condicion_pago_id = ccp. id AND \n");
                query.Append("                       fc.persona_id = p. id AND \n");
                query.Append("                       fc.caso_id = c. id and \n");

                if (!filtrarPorTemporada)
                    query.Append("                       fc.fecha BETWEEN to_date('" + fechaIncio + "','dd/mm/yyyy') AND  to_date('" + fechaFin + "','dd/mm/yyyy') AND \n");
                else
                {
                     query.Append("                       fc.fecha BETWEEN (SELECT to_date((to_char(fecha_inicio, 'dd/mm') \n");
                     query.Append("                                                         || temp.anho), 'dd/mm/yyyy') fecha_inicio \n");
                     query.Append("                                         FROM   (select apt.id, t.fecha_inicio, t.fecha_fin,apt.anho \n");
                     query.Append("                                                  from articulos_por_temporada apt \n");
                     query.Append("                                                   join temporadas t on apt.temporada_id = t.id) temp \n");
                     query.Append("                                         WHERE  temp.id = " + objetivoVendedorPorArticuloId.ToString() + ") AND (SELECT to_date((to_char(fecha_fin, 'dd/mm') \n");
                     query.Append("                                                                                  || temp.anho), 'dd/mm/yyyy') fecha_fin \n");
                     query.Append("                                                                  FROM   (select apt.id, t.fecha_inicio, t.fecha_fin,apt.anho \n");
                     query.Append("                                                                         from articulos_por_temporada apt \n");
                     query.Append("                                                                         join temporadas t on apt.temporada_id = t.id) temp \n");
                     query.Append("                                                                  WHERE  temp.id = " + objetivoVendedorPorArticuloId.ToString() + ") AND \n");

                }

                query.Append("                       fc.caso_estado_id IN ('CAJA', 'CERRADO') \n");
                query.Append("                UNION ALL \n");
                query.Append("                SELECT \n");
                query.Append("                       'NC'                                                  tipo, \n");
                query.Append("                       a.id articulo_id, \n");
                query.Append("                       0                                                     cantidad_vt, \n");
                query.Append("                       ncd.cantidad                                          cantidad_dv, \n");
                query.Append("                       trunc(nc.fecha)                                       fecha, \n");
                query.Append("                       fc.vendedor_id, \n");
                query.Append("                       c.flujo_id, \n");
                query.Append("                       c.estado_id \n");
                query.Append("                FROM   notas_credito_persona_inf_comp nc, \n");
                query.Append("                       notas_cred_per_det_inf_comp ncd, \n");
                query.Append("                       facturas_cliente_det_inf_co fcd, \n");
                query.Append("                       facturas_cliente_info_completa fc, \n");
                query.Append("                       personas p, \n");
                query.Append("                       casos c, \n");
                query.Append("                       articulos_info_completa a \n");
                query.Append("                WHERE  ncd.nota_credito_persona_id = nc.id AND \n");
                query.Append("                       nc.persona_id = p. id AND \n");
                query.Append("                       ncd.factura_cliente_detalle_id = fcd. id AND \n");
                query.Append("                       fcd.facturas_cliente_id = fc. id AND \n");
                query.Append("                       nc.caso_id = c. id AND \n");
                query.Append("                       c.estado = 'A' AND \n");
                query.Append("                       ncd.articulo_id = a. id AND \n");

                if (!filtrarPorTemporada)
                    query.Append("                       nc.fecha BETWEEN to_date('" + fechaIncio + "','dd/mm/yyyy') AND  to_date('" + fechaFin + "','dd/mm/yyyy') AND \n");
                else
                {
                    query.Append("                       nc.fecha BETWEEN (SELECT to_date((to_char(fecha_inicio, 'dd/mm') \n");
                    query.Append("                                                         || temp.anho), 'dd/mm/yyyy') fecha_inicio \n");
                    query.Append("                                         FROM   (select apt.id, t.fecha_inicio, t.fecha_fin,apt.anho  from articulos_por_temporada apt \n");
                    query.Append("                                                  join temporadas t on apt.temporada_id = t.id) temp \n");
                    query.Append("                                         WHERE  temp.id = " + objetivoVendedorPorArticuloId.ToString()  + ") AND (SELECT to_date((to_char(fecha_fin, 'dd/mm') \n");
                    query.Append("                                                                                  || temp.anho), 'dd/mm/yyyy') fecha_fin \n");
                    query.Append("                                                                  FROM   (select apt.id,apt.anho, t.fecha_inicio, t.fecha_fin  from articulos_por_temporada apt \n");
                    query.Append("                                                                    join temporadas t on apt.temporada_id = t.id) temp \n");
                    query.Append("                                                                  WHERE  temp.id = " + objetivoVendedorPorArticuloId.ToString() +  ") AND \n");
                }
                  
                query.Append("                       nc.caso_estado_id IN ('APROBADO', 'CERRADO')) ventas \n");
                query.Append("                       where ventas.articulo_id = " + articuloId.ToString()+ " and vendedor_id = " + funcionarioId + " \n");
                query.Append("        GROUP  BY articulo_id, vendedor_id");


                DataTable dt =  sesion.db.EjecutarQuery(query.ToString());

                if (dt.Rows.Count > 0)
                    return (decimal)dt.Rows[0]["total_venta"];
                else
                    return 0;
            }
            
        }

        #endregion GetDatosParaListados

        #region GetDetallesPorTemporada
        public DataTable GetDetallesPorTemporada(decimal TemporadaId, decimal vendedorId)
        {
            ArticulosPorTemporadaService articulosPorTemporada = new ArticulosPorTemporadaService();
            ObjetivosVendedorArticuloService objetivoArticulo = new ObjetivosVendedorArticuloService();

            DataTable dtArticulosPorTemp = articulosPorTemporada.GetArticulosPorTemporadaDataTable(ArticulosPorTemporadaService.TemporadaId_NombreCol + " = " + TemporadaId.ToString(),string.Empty,true);
            List<string> articulosPorTempIds = new List<string>();
            foreach (DataRow row in dtArticulosPorTemp.Rows)
            {
                articulosPorTempIds.Add(row[ArticulosPorTemporadaService.Id_NombreCol].ToString());
            }

            string articulosPorTemporadas = string.Join(",", articulosPorTempIds.ToArray());
            string clausulasObjetivoVendedorArticulo = ObjetivosVendedorArticuloService.ArticuloTemporadaId_NombreCol + " in (" + articulosPorTemporadas + ")";
            DataTable dtObjetivoVendedorArticulo = objetivoArticulo.GetObjetivoArticuloPorVendedorTableInfoCompleta(clausulasObjetivoVendedorArticulo);

            if (dtObjetivoVendedorArticulo.Rows.Count > 0)
            {
                List<decimal> objetivosVendedorArtIds = new List<decimal>();
                foreach (DataRow row in dtObjetivoVendedorArticulo.Rows)
                {
                    objetivosVendedorArtIds.Add((decimal)row[ArticulosPorTemporadaService.Id_NombreCol]);
                }

                return GetDetallesAcumulado(vendedorId, objetivosVendedorArtIds);
            }
            else
            {
                return null;
            }
        }
        #endregion GetDetallesPorTemporada

        #region GetDetallesAcumulado
        private DataTable GetDetallesAcumulado(decimal vendedorId, List<decimal> objetivosVendedorArtIds)
        {
            string Nombre_Vista = "OBJ_VEND_ART_DET_INFO_COMPLETA";

            using (SessionService sesion = new SessionService())
            {
                string objetivos = string.Join(",", objetivosVendedorArtIds.Select(x => x.ToString()).ToArray());
                string query = "select " + ArticuloId_NombreCol +
                    ", " + VendedorId_NombreCol +
                    ", " + VistaArticuloNombre_NombreCol +
                    ", sum(" + Cantidad_NombreCol + ") cantidad" + 
                    " from " + Nombre_Vista + 
                    " where " + 
                    ObjetivosVendedorArticuloDetalleService.VendedorId_NombreCol + " = " + vendedorId +
                    " and " + ObjetivosVendedorArticuloDetalleService.ObjetivoId_NombreCol + " in (" + objetivos + ")" +
                    " group by " + ArticuloId_NombreCol + 
                    ", " + VistaArticuloNombre_NombreCol +
                    ", " + VendedorId_NombreCol;
                return sesion.Db.EjecutarQuery(query);
            }
        }
        #endregion GetDetallesAcumulado

        #region Constructor
        public ObjetivosVendedorArticuloDetalleService()
        {

        }
        #endregion Constructor

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "OBJ_VEND_ARTI_DETALLE"; }
        }
        public static string Id_NombreCol
        {
            get { return OBJ_VEND_ARTI_DETALLECollection.IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return OBJ_VEND_ARTI_DETALLECollection.ARTICULO_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return OBJ_VEND_ARTI_DETALLECollection.CANTIDADColumnName; }
        }
        public static string ObjetivoId_NombreCol
        {
            get { return OBJ_VEND_ARTI_DETALLECollection.OBJETIVO_VENDEDOR_ARTICULO_IDColumnName; }
        }
        public static string VendedorId_NombreCol
        {
            get { return OBJ_VEND_ARTI_DETALLECollection.VENDEDOR_IDColumnName; }
        }
        
        
        #endregion Tabla

        #region Vista
        public static string VistaArticuloNombre_NombreCol
        {
            get { return OBJ_VEND_ART_DET_INFO_COMPLETACollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return OBJ_VEND_ART_DET_INFO_COMPLETACollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return OBJ_VEND_ART_DET_INFO_COMPLETACollection.FUNCIONARIO_NOMBREColumnName; }
        }
        
        
        #endregion Vista

        #endregion Accessors
    }
}
