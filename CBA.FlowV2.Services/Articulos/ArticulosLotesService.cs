using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.General;


namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosLotesService : ClaseCBA<ArticulosLotesService>
    {
        #region codigo viejo no orientado a objetos que debe borrarse al ir convirtiendo
        #region EsServicio
        /// <summary>
        /// Eses the servicio.
        /// </summary>
        /// <param name="lote_id">The lote_id.</param>
        /// <returns></returns>
        public static bool EsServicio(decimal lote_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_LOTESRow row = sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(lote_id);
                return ArticulosService.EsServicio(row.ARTICULO_ID);
            }
        }

        public static bool EsServicio(decimal lote_id, SessionService sesion)
        {

            ARTICULOS_LOTESRow row = sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(lote_id);
            return ArticulosService.EsServicio(row.ARTICULO_ID, sesion);

        }
        #endregion EsServicio

        #region Getters
        [Obsolete("Utilizar métodos estáticos")]
        public decimal GetArticuloId(decimal lote_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_LOTESRow row = sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(lote_id);
                return row.ARTICULO_ID;
            }
        }

        public static decimal GetArticuloId2(decimal lote_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ARTICULOS_LOTESRow row = sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(lote_id);
                return row.ARTICULO_ID;
            }
        }
        public static decimal GetArticuloId2(decimal lote_id,SessionService sesion )
        {
            
                ARTICULOS_LOTESRow row = sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(lote_id);
                return row.ARTICULO_ID;
            
        }

        #region GetArticulosLotes
        /// <summary>
        /// Gets the articulos lotes.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Utilizar metodos estaticos")]
        public DataTable GetArticulosLotes()
        {
            return GetArticulosLotes2();
        }

        public static DataTable GetArticulosLotes2()
        {
            return GetArticulosLotes(string.Empty, string.Empty);
        }

        public static DataTable GetArticulosLotes(string where)
        {
            return GetArticulosLotes(where, string.Empty);
        }

        public static DataTable GetArticulosLotesOrderById(string where)
        {
            return GetArticulosLotes(where, Id_NombreCol);
        }

        public static DataTable GetArticulosLotesOrderById(string where, SessionService sesion)
        {
            return GetArticulosLotes(where, Id_NombreCol, sesion);
        }

        public static DataTable GetArticulosLotes(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_LOTESCollection.GetAsDataTable(where, orderby);
            }
        }

        public static DataTable GetArticulosLotes(string where, string orderby, SessionService sesion)
        {
            return sesion.Db.ARTICULOS_LOTESCollection.GetAsDataTable(where, orderby);
        }

        public static string GetNombreLote(decimal lote_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(lote_id).LOTE;
            }
        }

        public static ARTICULOS_LOTESRow[] GetArticulosLotesArray(string where, string orderby)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_LOTESCollection.GetAsArray(where, orderby);
            }
        }

        #endregion GetArticulosLotes

        #region GetArticulosLotesCuenta
        /// <summary>
        /// Gets the articulos lotes cuenta.
        /// </summary>
        /// <param name="artiuclo_id">The artiuclo_id.</param>
        /// <returns></returns>
        public DataTable GetArticulosLotesCuenta(decimal articulo_id)
        {
            try
            {
                DataTable dt = new DataTable();      
                String query = "select al.id as " + ArticulosLotesService.Id_NombreCol + ", \n"
                + "  al.articulo_id as " + ArticulosLotesService.Articulo_ID_NombreCol + ", \n"
                + "  al.lote as " + ArticulosLotesService.LOTE_NombreCol + ", \n"
                + " al.fecha_fabricacion as " + ArticulosLotesService.FECHA_FABRICACION_NombreCol + ", \n"
                + "  al.fecha_vencimiento as " + ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol + ", \n"
                + "  nvl(sum(ssda.existencia),0) as " + ArticulosLotesService.Total_NombreCol + ", \n"
                + "  al.fecha as " + ArticulosLotesService.Fecha_NombreCol + ", \n"
                + "  b.id as " + ArticulosLotesService.Buque_Id_NombreCol + ", \n"
                + "  b.descripcion as " + ArticulosLotesService.VistaBuque_Descripcion_NombreCol + ", \n"
                + "  p.id  as " + ArticulosLotesService.VistaPersona_Id_NombreCol + ", \n"
                + "  p.nombre_completo as " + ArticulosLotesService.VistaPersona_Nombre_NombreCol + ", \n"
                + "  al.despacho as " + ArticulosLotesService.Despacho_NombreCol + " \n"
             + " from articulos_lotes al, stock_suc_deposito_articulo ssda, buques b, personas p\n"
            + " where al.id = ssda.articulo_lote_id(+)\n"
               + "   and al.buque_id = b.id(+)\n"
                + "  and al.persona_id = p.id(+)\n"
                 + " and al.articulo_id = '" + articulo_id + "'\n"
           + " group by al.id,\n"
              + "       al.articulo_id,\n"
              + "     al.lote,\n"
              + "     al.fecha_fabricacion,\n"
              + "      al.fecha_vencimiento,\n"
              + "     b.id,\n"
              + "     b.descripcion,\n"
              + "     al.fecha,\n"
              + "     p.id,\n"
              + "     al.despacho,\n"
              + "     p.nombre_completo\n";
                using (SessionService sesion = new SessionService())
                {
                   dt= sesion.db.EjecutarQuery(query);
                }
                return dt;
            }
            catch (Exception ex){ throw ex; }     
        }
        #endregion GetArticulosLotesCuenta

        #region GetArticulosLotes
        /// <summary>
        /// Gets the articulos lotes.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosLotes(decimal articulo_id, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                String clausula = string.Empty;
                if (articulo_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula = Articulo_ID_NombreCol + " = " + articulo_id;
                if (orden.Equals(string.Empty)) orden = ArticulosLotesService.Id_NombreCol;

                DataTable Lotes = sesion.Db.ARTICULOS_LOTESCollection.GetAsDataTable(clausula, orden);
                return Lotes;
            }
        }

        public static DataTable GetArticulosLotes(decimal articulo_id, decimal persona_id,string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                String clausula = string.Empty;
                if (articulo_id != Definiciones.Error.Valor.EnteroPositivo)
                    clausula = Articulo_ID_NombreCol + " = " + articulo_id;

                if (persona_id != Definiciones.Error.Valor.EnteroPositivo)
                {
                    if (clausula != string.Empty)
                        clausula += " and " + Persona_Id_NombreCol + " = " + persona_id;
                    else
                        clausula = Persona_Id_NombreCol + " = " + persona_id;
                }
                
                if (orden.Equals(string.Empty)) orden = ArticulosLotesService.Id_NombreCol;

                DataTable Lotes = sesion.Db.ARTICULOS_LOTESCollection.GetAsDataTable(clausula, orden);
                return Lotes;
            }
        }
        #endregion GetArticulosLotes

        #region GetArticulosLotesInfoCompleta
        /// <summary>
        /// Gets the articulos lotes info completa.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetArticulosLotesInfoCompleta(decimal articulo_id, string orden)
        {
            return ArticulosLotesService.GetArticulosLotesInfoCompleta2(articulo_id, orden);
        }

        public static DataTable GetArticulosLotesInfoCompleta2(decimal articulo_id, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosLotesInfoCompleta2(articulo_id, orden, sesion);
            }
        }

        public static DataTable GetArticulosLotesInfoCompleta2(decimal articulo_id, string orden, SessionService sesion)
        {
            string clausula = string.Empty;
            if (articulo_id != Definiciones.Error.Valor.EnteroPositivo)
                clausula = Articulo_ID_NombreCol + " = " + articulo_id;

            DataTable Lotes = sesion.Db.ARTICULOS_LOTES_INFO_COMPLETACollection.GetAsDataTable(clausula, orden);
            return Lotes;
        }
        #endregion GetArticulosLotesInfoCompleta

        #region GetArticulosLotesUnificandoDepositos
        /// <summary>
        /// Gets the articulos lotes unificando depositos.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetArticulosLotesUnificandoDepositos(decimal articulo_id, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = ArticulosLotesService.GetArticulosLotesInfoCompleta2(articulo_id, orden);
                dt = sesion.db.ObtenerDistintos(new string[] { ArticulosLotesService.Id_NombreCol, ArticulosLotesService.LOTE_NombreCol }, dt);

                return dt;
            }
        }
        #endregion GetArticulosLotesUnificandoDepositos

        #region GetArticulosLotesConStock
        public static DataTable GetArticulosLotesConStockConsiderandoReserva(decimal depostito_id, decimal articulo_id, bool solo_con_saldo)
        {
            using (SessionService sesion = new SessionService())
            {
                return StockArticulosReservaService.GetLotesConExistencia(depostito_id, articulo_id, solo_con_saldo, sesion);
            }
        }

        public DataTable GetArticulosLotesConStock(decimal sucursal_id, decimal depostito_id, decimal articulo_id, bool soloConSaldo, SessionService sesion)
        {
            string clausula = "(" + ArticulosLotesService.Sucursal_Id_NombreCol + " = " + sucursal_id + " or " + ArticulosLotesService.Sucursal_Id_NombreCol + " is null) and " +
                              "(" + ArticulosLotesService.Deposito_Id_NombreCol + " = " + depostito_id + " or " + ArticulosLotesService.Deposito_Id_NombreCol + " is null) and " +
                                    ArticulosLotesService.Articulo_ID_NombreCol + " = " + articulo_id;
            if (soloConSaldo)
                clausula += " and " + ArticulosLotesService.Total_NombreCol + " > 0 ";
            
            DataTable dtLotes = sesion.Db.ARTICULOS_LOTES_INFO_COMPLETACollection.GetAsDataTable(clausula, FECHA_VENCIMIENTO_NombreCol);
            dtLotes.Columns.Add(ArticulosLotesService.LoteYCantidad_NombreCol, typeof(string));
            DataTable dtLotes2 = dtLotes.Clone();

            foreach (DataRow dr in dtLotes.Rows)
            {
                decimal cantidad = ObtenerCantidadexistentePorLote((decimal)dr[ArticulosLotesService.Id_NombreCol], depostito_id);
                if (!soloConSaldo || cantidad > 0)
                {
                    dr[ArticulosLotesService.LoteYCantidad_NombreCol] = dr[ArticulosLotesService.LOTE_NombreCol].ToString() + " (" + cantidad + ")";
                    dtLotes2.ImportRow(dr);
                }
            }
            DataTable dtLotes3 = ArticulosLotesService.GetArticulosLotes(articulo_id, ArticulosLotesService.Id_NombreCol);

            if (dtLotes2.Rows.Count == 0 && !soloConSaldo)
            {
                decimal cantidad2 = 0;
                dtLotes3 = ArticulosLotesService.GetArticulosLotes(articulo_id, ArticulosLotesService.Id_NombreCol);
                // dtLotes2 = dtLotes.Clone();

                foreach (DataRow dr3 in dtLotes3.Rows)
                {
                    DataRow dr2 = dtLotes2.NewRow();
                    dr2[ArticulosLotesService.Id_NombreCol] = dr3[ArticulosLotesService.Id_NombreCol];
                    dr2[ArticulosLotesService.LoteYCantidad_NombreCol] = dr3[ArticulosLotesService.LOTE_NombreCol].ToString() + "(" + cantidad2 + ")";
                    dtLotes2.Rows.Add(dr2);
                }
            }

            return dtLotes2;
        }
        public DataTable GetArticulosLotesConStock(decimal sucursal_id, decimal depostito_id, decimal articulo_id, bool soloConSaldo)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetArticulosLotesConStock(sucursal_id, depostito_id, articulo_id, soloConSaldo,sesion);
            }
        }
        #endregion GetArticulosLotesConStock

        #region GetCantidadSucursalDepositoLote
        public decimal GetCantidadSucursalDepositoLote(decimal sucursal_id, decimal depostito_id, decimal lote_id, bool soloConSaldo)
        {
            string clausula = ArticulosLotesService.Sucursal_Id_NombreCol + " = " + sucursal_id + " and " +
                                              ArticulosLotesService.Deposito_Id_NombreCol + " = " + depostito_id + " and " +
                                              ArticulosLotesService.Id_NombreCol + " = " + lote_id;
            if (soloConSaldo)
            {
                clausula += " and " + ArticulosLotesService.Total_NombreCol + " > 0 ";
            }
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_LOTES_INFO_COMPLETACollection.GetAsArray(clausula, FECHA_VENCIMIENTO_NombreCol)[0].TOTAL;

            }
        }
        #endregion GetCantidadSucursalDepositoLote

        #region GetCantidadSucursalDepositoLote
        public static decimal GetCantidadSucursalDepositoLote(decimal sucursal_id, decimal depostito_id, decimal lote_id)
        {
            string clausula = ArticulosLotesService.Sucursal_Id_NombreCol + " = " + sucursal_id + " and " +
                                              ArticulosLotesService.Deposito_Id_NombreCol + " = " + depostito_id + " and " +
                                              ArticulosLotesService.Id_NombreCol + " = " + lote_id;
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ARTICULOS_LOTES_INFO_COMPLETACollection.GetAsArray(clausula, FECHA_VENCIMIENTO_NombreCol)[0].TOTAL;

            }
        }
        #endregion GetCantidadSucursalDepositoLote

        #region GetArticulosLotesConStock
        /// <summary>
        /// Gets the articulos lotes info completa.
        /// </summary>
        /// <param name="clausula">The clausula.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetArticulosLotesInfoCompleta(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable Lotes = sesion.Db.ARTICULOS_LOTES_INFO_COMPLETACollection.GetAsDataTable(clausula, "upper(" + orden + ")");
                return Lotes;
            }
        }
        #endregion GetArticulosLotesConStock

        #endregion Getters

        #region GetPrimerLoteId
        public static decimal GetPrimerLoteId(decimal articulo_id, decimal deposito_id, SessionService sesion)
        { 
            string clausulas = ArticulosLotesService.Articulo_ID_NombreCol + " = " + articulo_id + " and " + 
                               "(" + ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol + " is null or trunc(" + ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol + ") >= to_date(sysdate, 'dd/mm/yyyy')) and " +
                               " exists(select ssda." + StockService.Id_NombreCol + 
                               "          from " + StockService.Nombre_Tabla + " ssda " +
                               "         where " + StockService.ArticuloLoteId_NombreCol + " = " + ArticulosLotesService.Nombre_Tabla + "." + ArticulosLotesService.Id_NombreCol +
                               "           and " + StockService.DepositoId_NombreCol + " = " + deposito_id +
                               "           and " + StockService.Existencia_NombreCol + " > 0 " +
                               "       ) ";
            ARTICULOS_LOTESRow[] rows = sesion.db.ARTICULOS_LOTESCollection.GetAsArray(clausulas, ArticulosLotesService.Id_NombreCol);
            if (rows.Length > 0)
                return rows[0].ID;
            else
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        public static decimal GetPrimerLoteId(decimal articulo_id, decimal deposito_id)
        {
            
                using (SessionService sesion = new SessionService())
                {
                    return GetPrimerLoteId(articulo_id, deposito_id, sesion);
                }
        }
        public static decimal GetLoteIdCajaRapida(decimal articulo_id, decimal deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetLoteIdCajaRapida(articulo_id, deposito_id, sesion);
            }
        }
        public static decimal GetLoteIdCajaRapida(decimal articulo_id, decimal deposito_id, SessionService sesion)
        {
            //Buscar el lutimo lote con existencia en esa sucursal y en ese deposito
            //optener el lote mas antiguo
            string clausulas = ArticulosLotesService.Articulo_ID_NombreCol + " = " + articulo_id + " and " +
                               "(" + ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol + " is null or trunc(" + ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol + ") >= to_date(sysdate, 'dd/mm/yyyy')) and " +
                               " exists(select ssda." + StockService.Id_NombreCol +
                               "          from " + StockService.Nombre_Tabla + " ssda " +
                               "         where " + StockService.ArticuloLoteId_NombreCol + " = " + ArticulosLotesService.Nombre_Tabla + "." + ArticulosLotesService.Id_NombreCol +
                               "           and " + StockService.DepositoId_NombreCol + " = " + deposito_id +
                               "           and " + StockService.Existencia_NombreCol + " > 0 " +
                               "       ) ";
            ARTICULOS_LOTESRow[] rows = sesion.db.ARTICULOS_LOTESCollection.GetAsArray(clausulas, ArticulosLotesService.Id_NombreCol);
            if (rows.Length > 0)
                return rows[0].ID;
            else
            {
                //en caso de que no exista un lote con existencia 
                //agregar el lote mas nuevo sin existencia
                clausulas = ArticulosLotesService.Articulo_ID_NombreCol + " = " + articulo_id + " and " +
                               "(" + ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol + " is null or trunc(" + ArticulosLotesService.FECHA_VENCIMIENTO_NombreCol + ") >= to_date(sysdate, 'dd/mm/yyyy')) ";
                               
            ARTICULOS_LOTESRow[] rows2 = sesion.db.ARTICULOS_LOTESCollection.GetAsArray(clausulas, ArticulosLotesService.Id_NombreCol);
            if (rows2.Length > 0)
                return rows2[0].ID;
            else
                return Definiciones.Error.Valor.EnteroPositivo;
            }
                
        }

        #endregion GetPrimerLoteId

      

        #region ObtenerCantidadexistentePorLote
        public decimal ObtenerCantidadexistentePorLote(decimal lote_id, decimal deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return ObtenerCantidadexistentePorLote(lote_id, deposito_id, sesion);
            }
        }

        /// <summary>
        /// Obteners the cantidadexistente por lote.
        /// </summary>
        /// <param name="lote_id">The lote_id.</param>
        /// <returns></returns>
        public decimal ObtenerCantidadexistentePorLote(decimal lote_id, decimal deposito_id, SessionService sesion)
        {
            decimal politicaStock = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PoliticaMovimientoStock);
            decimal existenciaDisponible;

            switch ((int)politicaStock)
            {
                case (int)Definiciones.Stock.Politicas.Tardia:
                    existenciaDisponible = StockArticulosReservaService.GetCantidadDisponibleSegunLote(lote_id, deposito_id,sesion);
                    break;
                case (int)Definiciones.Stock.Politicas.Intermedio:
                case (int)Definiciones.Stock.Politicas.Temprano:
                    //HERRAMIENTAS.OBTENERCANTDIDAD PARECE ESTAR MAL
                    //No distingue entre depositos
                    DataTable seq = new DataTable();
                    seq = sesion.Db.EjecutarQuery("select herramientas.Obtener_Cantidad_Stock(" + lote_id + ") from dual");
                    decimal existenciaEnStock = seq.Rows[0].Field<object>(0) != null ? seq.Rows[0].Field<Decimal>(0) : 0;

                    existenciaDisponible = existenciaEnStock;
                    break;
                default:
                    throw new Exception("ArticulosLotesService.ObtenerCantidadexistentePorLote(). Política de Stock no implementasda.");
            }

            return existenciaDisponible;
        }
        #endregion ObtenerCantidadexistentePorArticulo

        #region ObtenerCantidadexistentePorArticulo

        /// <summary>
        /// Obteners the cantidadexistente por articulo.
        /// </summary>
        /// <param name="articulo_id">The articulo_id.</param>
        /// <returns></returns>
        public decimal ObtenerCantidadexistentePorArticulo(decimal articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable seq = new DataTable();
                seq = sesion.Db.EjecutarQuery("select herramientas.Obtener_Cantidad_Articulo(" + articulo_id + ") from dual");
                if (seq.Rows[0].Field<object>(0) != null) return seq.Rows[0].Field<Decimal>(0);
                else return 0;
            }
        }
        #endregion ObtenerCantidadexistentePorArticulo

        #region GetCantidadPorArticulos
        public DataTable GetCantidadPorArticulos(decimal articulo_id)
        {
            string clausula = ArticulosLotesService.VistaStockArticuloId_NombreCol + "=" + articulo_id;
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = sesion.Db.STOCK_SUC_DEP_ART_CANTIDADCollection.GetAsDataTable(clausula, "upper(" + ArticulosLotesService.VistaStockArticuloId_NombreCol + ")");
                return dt;
            }

        }
        #endregion GetCantidadPorArticulos

        #region Accessors
        #region Tablas
        public static string Id_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.IDColumnName; }
        }
        public static string Articulo_ID_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.ARTICULO_IDColumnName; }
        }
        public static string FECHA_FABRICACION_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.FECHA_FABRICACIONColumnName; }
        }
        public static string FECHA_VENCIMIENTO_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string LOTE_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.LOTEColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.TOTALColumnName; }
        }
        public static string ARTICULO_DESCRIPCION_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string Sucursal_Id_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.SUCURSAL_IDColumnName; }
        }
        public static string Deposito_Id_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.DEPOSITO_IDColumnName; }
        }
        public static string DESPLEGADO_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.DESPLEGADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.FECHAColumnName; }
        }
        public static string Despacho_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.DESPACHOColumnName; }
        }
        public static string Persona_Id_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.PERSONA_IDColumnName; }
        }
        public static string Buque_Id_NombreCol
        {
            get { return ARTICULOS_LOTESCollection.BUQUE_IDColumnName; }
        }
        public static string LoteYCantidad_NombreCol
        {
            get { return "CANT_DISPONIBLE"; }
        }

        #endregion Tablas
        #region Vistas
        public static string VistaStockId_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.IDColumnName; }
        }
        public static string VistaStockSucursalId_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaStockSucursalNombre_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaStockDepositoId_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.DEPOSITO_IDColumnName; }
        }
        public static string VistaStockDepositoNombre_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaStockLoteId_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.ARTICULO_LOTE_IDColumnName; }
        }
        public static string VistaStockLote_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.LOTEColumnName; }
        }
        public static string VistaStockArticuloId_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.ARTICULO_IDColumnName; }
        }
        public static string VistaStockArticuloDescripcion_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaStockExistencia_NombreCol
        {
            get { return STOCK_SUC_DEP_ART_CANTIDADCollection.EXISTENCIAColumnName; }
        }

        public static string VistaFecha_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.FECHAColumnName; }
        }
        public static string VistaDespacho_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.DESPACHOColumnName; }
        }
        public static string VistaPersona_Id_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.PERSONA_IDColumnName; }
        }
        public static string VistaPersona_Nombre_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaBuque_Id_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.BUQUE_IDColumnName; }
        }
        public static string VistaBuque_Descripcion_NombreCol
        {
            get { return ARTICULOS_LOTES_INFO_COMPLETACollection.BUQUE_DESCRIPCIONColumnName; }
        }

        #endregion Vistas
        #endregion Accessors
        #endregion codigo viejo no orientado a objetos que debe borrarse al ir convirtiendo

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static ArticulosLotesService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new ArticulosLotesService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable
        
        #region Propiedades
        protected ARTICULOS_LOTESRow row;
        protected ARTICULOS_LOTESRow rowSinModificar;
        public class Modelo : ARTICULOS_LOTESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal ArticuloId { get { return row.ARTICULO_ID; } set { row.ARTICULO_ID = value; } }
        public DateTime? FechaFabricacion { get { if (row.IsFECHA_FABRICACIONNull) return null; else return row.FECHA_FABRICACION; } set { if (value.HasValue) row.FECHA_FABRICACION = value.Value; else row.IsFECHA_FABRICACIONNull = true; } }
        public DateTime? FechaVencimiento { get { if (row.IsFECHA_VENCIMIENTONull) return null; else return row.FECHA_VENCIMIENTO; } set { if (value.HasValue) row.FECHA_VENCIMIENTO = value.Value; else row.IsFECHA_VENCIMIENTONull = true; } }
        public DateTime? Fecha{ get { if (row.IsFECHANull) return null; else return row.FECHA; } set { if (value.HasValue) row.FECHA = value.Value; else row.IsFECHANull = true; } }        
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal PersonaId { get { return row.PERSONA_ID; } set { row.PERSONA_ID = value; } }
        public decimal BuqueId { get { return row.BUQUE_ID; } set { row.BUQUE_ID = value; } }
        public string Lote { get { return ClaseCBABase.GetStringHelper(row.LOTE); } set { row.LOTE = value; } }
        public string Despacho { get { return ClaseCBABase.GetStringHelper(row.DESPACHO); } set { row.DESPACHO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private ArticulosService _articulo;
        public ArticulosService Articulo
        {
            get
            {
                if (this._articulo == null)
                {
                    if (this.sesion != null)
                        this._articulo = new ArticulosService(this.ArticuloId, this.sesion);
                    else
                        this._articulo = new ArticulosService(this.ArticuloId);
                }
                return this._articulo;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ARTICULOS_LOTESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ARTICULOS_LOTESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(ARTICULOS_LOTESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public ArticulosLotesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ArticulosLotesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ArticulosLotesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
       
        private ArticulosLotesService(ARTICULOS_LOTESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            if (!RolesService.Tiene("ARTICULOS LOTES EDITAR"))
                throw new Exception("No tiene permisos para guardar");

            this.Validar();

            if (!this.ExisteEnDB)
            {
                if (!RolesService.Tiene("ARTICULOS LOTES CREAR"))
                    throw new Exception("No tiene permisos para guardar");
                
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.ARTICULOS_LOTESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.ARTICULOS_LOTESCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }

        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                ARTICULOS_LOTESRow row = new ARTICULOS_LOTESRow();
                string valorAnterior = string.Empty;

                //verifica si es una nueva fila a insertar
                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = ObtenerSiguienteSecuencia();
                }
                else
                {
                    // si solo es para actualizar se obtiene la fila desde la base de datos
                    row = sesion.Db.ARTICULOS_LOTESCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
                //se verifica que exista el campo del id del articulo
                if (campos.Contains(Articulo_ID_NombreCol))
                    row.ARTICULO_ID = decimal.Parse(campos[Articulo_ID_NombreCol].ToString());
                else
                    throw new System.ArgumentException("El Id del articulo no puede ser nulo");

                //se verifica si existe un lote, sino se coloca a null
                if (campos.Contains(LOTE_NombreCol))
                    row.LOTE = campos[LOTE_NombreCol].ToString();
                else
                    row.LOTE = null;

                //se verifica si existe un fecha de fabricacion, sino se coloca a null
                if (campos.Contains(FECHA_FABRICACION_NombreCol))
                    row.FECHA_FABRICACION = DateTime.Parse(campos[FECHA_FABRICACION_NombreCol].ToString());
                else
                    row.IsFECHA_FABRICACIONNull = true;

                //se verifica si existe un fecha de vencimiento, sino se coloca a null
                if (campos.Contains(FECHA_VENCIMIENTO_NombreCol))
                    row.FECHA_VENCIMIENTO = DateTime.Parse(campos[FECHA_VENCIMIENTO_NombreCol].ToString());
                else
                    row.IsFECHA_VENCIMIENTONull = true;

                if (campos.Contains(Persona_Id_NombreCol))
                    row.PERSONA_ID = decimal.Parse(campos[Persona_Id_NombreCol].ToString());
                else
                    row.IsPERSONA_IDNull = true;

                if (insertarNuevo)
                    sesion.Db.ARTICULOS_LOTESCollection.Insert(row);
                else
                    sesion.Db.ARTICULOS_LOTESCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                return row.ID;
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException exp)
            {
                switch (exp.Number)
                {
                    case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                        throw new System.ArgumentException("Ya existe el lote " + campos[LOTE_NombreCol] + " para este articulo.", exp);
                    default:
                        throw;
                }
            }
            catch
            {
                throw;
            }

        }

        #endregion Guardar

        #region ObtenerSiguienteSecuencia
        public decimal ObtenerSiguienteSecuencia()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable seq = new DataTable();
                seq = sesion.Db.EjecutarQuery("select articulos_lotes_sqc.nextval seq from dual");
                return seq.Rows[0].Field<Decimal>(0);
            }
        }
        #endregion ObtenerSiguienteSecuencia


        #region ExisteLoteEnDetalleFP
        public static bool ExisteLoteEnDetalleFP(decimal lote_id)
        {
            bool rtn = false;
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = new DataTable();
                dt = sesion.Db.EjecutarQuery("select count(fp.lote_id) cantidad from facturas_proveedor_detalle fp where fp.lote_id = " + lote_id);
                if ((decimal)dt.Rows[0][0] > 0)
                    rtn = true;
            }
            return rtn;
        }
        #endregion ExisteLoteEnDetalleFP

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            string clausulas = Modelo.ARTICULO_IDColumnName + " = " + this.ArticuloId + " and " +
                               "upper(" + Modelo.LOTEColumnName + ") = '" + this.Lote.ToUpper() + "'";
            if (this.Id.HasValue)
                clausulas += " and " + Modelo.IDColumnName + " <> " + this.Id.Value;

            var rows = sesion.db.ARTICULOS_LOTESCollection.GetAsArray(clausulas, string.Empty);
            if (rows.Length > 0)
                excepciones.Agregar("El artículo ya tiene un lote con código " + this.Lote + ".", null);

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._articulo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override ArticulosLotesService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1 = 1");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.LOTEColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append(f.Columna + " in ('" + string.Join("','", Array.ConvertAll((string[])f.Valor, i => i.ToString())) + "')");
                            break;
                        case Modelo.FECHA_FABRICACIONColumnName:
                        case Modelo.FECHA_VENCIMIENTOColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            ARTICULOS_LOTESRow[] rows = sesion.db.ARTICULOS_LOTESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            ArticulosLotesService[] al = new ArticulosLotesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                al[i] = new ArticulosLotesService(rows[i]);
            return al;
        }

        public override EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            throw new NotImplementedException();
        }

        public override EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException();
        }
        #endregion Buscar



        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_LOTES"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "ARTICULOS_LOTES_SQC"; }
        }
        #endregion Accessors
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
