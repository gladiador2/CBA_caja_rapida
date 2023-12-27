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
using CBA.FlowV2.Services.Common;


namespace CBA.FlowV2.Services.Comercial
{
    public class ObjetivosVendedorExplotacionService
    {
        #region GetObjetivosVendedorExplotacionDataTable
        public DataTable GetObjetivosVendedorExplotacionDataTable(string clausulas, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.OBJETIVO_VENDEDOR_EXPLOTACIONCollection.GetAsDataTable(clausulas,orderBy);
            }
        }
        #endregion GetObjetivosVendedorExplotacionDataTable

        #region GetPorMeses
        public static decimal[][] GetPorMeses(string clausulas, int anho_desde, int anho_hasta)
        {
            using (SessionService sesion = new SessionService())
            {
                string sql = "select to_char(" + Fecha_NombreCol + ", 'mm') mes, to_char(" + Fecha_NombreCol + ", 'yyyy') anho, round(sum(" + MontoVendido_NombreCol + "), " + CantidadDecimales_NombreCol + ") monto" +
                             "  from " + Nombre_Vista +
                             " where trunc(" + Fecha_NombreCol + ") between to_date('01/01/" + anho_desde.ToString("0000") + "', 'dd/mm/yyyy') and to_date('31/12/" + anho_hasta.ToString("0000") + "', 'dd/mm/yyyy')";
                if (clausulas.Length > 0)
                    sql += " and (" + clausulas + ")";
                sql += " group by to_char(" + Fecha_NombreCol + ", 'mm'), to_char(" + Fecha_NombreCol + ", 'yyyy'), " + CantidadDecimales_NombreCol;
                
                var dt = sesion.Db.EjecutarQuery(sql);
                var resultado = new decimal[12][];

                for (int i = 0; i < 12; i++)
                {
                    resultado[i] = new decimal[anho_hasta - anho_desde + 1];
                    for (int j = 0; j < anho_hasta - anho_desde + 1; j++)
                    {
                        var objeto = dt.Compute("sum(monto)", "anho = '" + (anho_desde + j).ToString("0000") + "' and mes = '" + (i + 1).ToString("00") + "'");
                        if (Interprete.EsNullODBNull(objeto))
                            resultado[i][j] = 0;
                        else
                            resultado[i][j] = (decimal)objeto;
                    }
                }

                return resultado;
            }
        }
        #endregion GetPorMeses

        #region GetPorClientesFechas
        public static DataTable GetPorClientesFechas(string clausulas, int anho_desde, int anho_hasta, int mes_desde, int mes_hasta)
        {
            using (SessionService sesion = new SessionService())
            {
                var dResultado = new Dictionary<decimal, object[]>();
                var sqlPartes = new List<string>();

                for (int i = 0; i < anho_hasta - anho_desde + 1; i++)
                {
                    DateTime fechaDesde = new DateTime(anho_desde + i, mes_desde, 1);
                    DateTime fechaHasta = new DateTime(anho_desde + i, mes_hasta, 1).AddMonths(1).AddDays(-1); //Ultimo día del mes

                    string sqlParte = "select " + PersonaId_NombreCol + ", " +
                                 "       to_char(" + Fecha_NombreCol + ", 'mm') mes, " +
                                 "       to_char(" + Fecha_NombreCol + ", 'yyyy') anho, "+
                                 "       round(sum(" + MontoVendido_NombreCol + "), " + CantidadDecimales_NombreCol + ") monto " +
                                 "  from " + Nombre_Vista +
                                 " where trunc(" + Fecha_NombreCol + ") between to_date('" + fechaDesde.ToShortDateString() + "', 'dd/mm/yyyy') and to_date('" + fechaHasta.ToShortDateString() + "', 'dd/mm/yyyy')";
                    if (clausulas.Length > 0)
                        sqlParte += " and (" + clausulas + ")";
                    sqlParte += " group by " + PersonaId_NombreCol + ", to_char(" + Fecha_NombreCol + ", 'mm'), to_char(" + Fecha_NombreCol + ", 'yyyy'), " + CantidadDecimales_NombreCol;
                    sqlPartes.Add(sqlParte);
                }

                string sql = string.Join(" union ", sqlPartes.ToArray());
                var dt = sesion.Db.EjecutarQuery(sql);
                var dtDistintos = sesion.db.ObtenerDistintos(new string[] { PersonaId_NombreCol }, dt);

                #region crear columnas en datatable
                //Codigo, nombre, saldo linea, N columnas para mes-año, total
                var dtResultado = new DataTable();
                dtResultado.Columns.Add("Código", typeof(string));
                dtResultado.Columns.Add("Nombre", typeof(string));
                dtResultado.Columns.Add("Saldo Línea Crédito", typeof(decimal));

                for (int anho = 0; anho < anho_hasta - anho_desde + 1; anho++)
                {
                    for (int mes = 0; mes < mes_hasta - mes_desde + 1; mes++)
                        dtResultado.Columns.Add((mes_desde + mes).ToString("00") + "-" + (anho_desde + anho).ToString("0000"), typeof(decimal));
                }
                dtResultado.Columns.Add("Total", typeof(decimal));
                dtResultado.Columns.Add("%", typeof(decimal));
                #endregion crear columnas en datatable

                decimal total = 0;
                for (int i = 0; i < dtDistintos.Rows.Count; i++)
			    {
                    var dr = dtResultado.NewRow();
                    int cont = 0;

                    PersonasService p = new PersonasService((decimal)dtDistintos.Rows[i][0], sesion);
                    dr[cont++] = p.Codigo;
                    dr[cont++] = p.NombreCompleto;
                    dr[cont++] = PersonasService.GetLineaCreditoDisponible(p.Id.Value, sesion);

                    decimal totalPersona = 0;
                    for (int anho = 0; anho < anho_hasta - anho_desde + 1; anho++)
                    {
                        for (int mes = 0; mes < mes_hasta - mes_desde + 1; mes++)
                        {
                            var objeto = dt.Compute("sum(monto)", "anho = '" + (anho_desde + anho).ToString("0000") + "' and mes = '" + (mes_desde + mes).ToString("00") + "' and " + PersonaId_NombreCol + " = " + p.Id.Value);
                            if (Interprete.EsNullODBNull(objeto))
                                dr[cont++] = 0;
                            else
                                dr[cont++] = objeto;

                            totalPersona += (decimal)dr[cont - 1];
                        }
                    }

                    dr[cont++] = totalPersona;
                    total += totalPersona;
                    dtResultado.Rows.Add(dr);
			    }

                for (int i = 0; i < dtDistintos.Rows.Count; i++)
                    dtResultado.Rows[i][dtResultado.Columns.Count - 1] = (decimal)dtResultado.Rows[i][dtResultado.Columns.Count - 2] / total * 100;

                return dtResultado;
            }
        }

        public static DataTable GetPorClientesFechas(string clausulas, IEnumerable<DateTime> fechas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = sesion.Db.OBJETIVO_VENDEDOR_EXPLOTACIONCollection.GetAsDataTable(clausulas, ObjetivosVendedorExplotacionService.PersonaId_NombreCol + ", " + ObjetivosVendedorExplotacionService.Fecha_NombreCol);
                
                #region prepararDtResultado
                DataTable resultado = new DataTable();
                decimal totalGeneral = 0;

                #region crear columnas en datatable
                resultado.Columns.Add("Cod. Cliente", typeof(string));
                resultado.Columns.Add("Cliente", typeof(string));
                resultado.Columns.Add("Saldo Línea de Credito", typeof(decimal));

                foreach (string nombre in fechas.Select(f => f.ToString("MMM yyyy")))
                    resultado.Columns.Add(nombre, typeof(decimal));
                resultado.Columns.Add("Totales", typeof(decimal));
                resultado.Columns.Add("%", typeof(decimal));
                #endregion crear columnas en datatable

                #region Preparar Filas Calculos
                DataRow rowSumatoria = resultado.NewRow();
                DataRow rowEnPorcentaje = resultado.NewRow();
                DataRow rowNroCltes = resultado.NewRow();
                DataRow rowExpCartera = resultado.NewRow();
                DataRow rowPromeClteGS = resultado.NewRow();
                DataRow rowAprovCartera = resultado.NewRow();

                rowSumatoria["Cliente"] = "Totales";
                rowEnPorcentaje["Cliente"] = "En %";
                rowNroCltes["Cliente"] = "Nro. Cltes.";
                rowExpCartera["Cliente"] = "Exp. Cartera %";
                rowPromeClteGS["Cliente"] = "Prom. Clte. ";
                rowAprovCartera["Cliente"] = "Aprov. Cartera";
                decimal sum_A = 0;
                decimal sum_C = 0;
                #endregion Preparar Filas Calculos

                PersonasService persona = new PersonasService((decimal)dt.Rows[0][PersonaId_NombreCol], sesion);
                Hashtable datos_sumados = new Hashtable();

                #region Filas Datos
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        foreach (string nombre in fechas.Select(f => f.ToString("MMM yyyy")))
                        {
                            rowSumatoria[nombre] = 0;
                            rowNroCltes[nombre] = 0;
                        }
                    }
                    
                    // si la persona es distinta a la que actualmente estamos procesando
                    if (persona.Id.Value != (decimal)dt.Rows[i][PersonaId_NombreCol])
                    {
                        persona = new PersonasService((decimal)dt.Rows[i][PersonaId_NombreCol], sesion);
                        
                        // agregar registro al datatable consolidado
                        DataRow row = resultado.NewRow();
                        decimal total = 0;
                        foreach (DateTime fecha in fechas)
                        {
                            if (datos_sumados.Contains(fecha))
                            {
                                decimal valor = (decimal)datos_sumados[fecha];
                                string columna = fecha.ToString("MMM yyyy");
                                row[columna] = valor;
                                rowSumatoria[columna] = (decimal)rowSumatoria[columna] + valor;
                                rowNroCltes[columna] = (decimal)rowNroCltes[columna] + 1;
                                sum_A += valor;
                                sum_C += 1;
                                total += valor;
                            }
                        }

                        row["Cod. Cliente"] = persona.Codigo;
                        row["Cliente"] = persona.NombreCompleto;
                        row["Saldo Línea de Credito"] = PersonasService.GetLineaCreditoDisponible(persona.Id.Value, sesion);
                        row["Totales"] = total;
                        resultado.Rows.Add(row);
                        
                        // reset de las variables auxiliares
                        datos_sumados.Clear();
                    }
                    else
                    {
                        // sumar valores para cada rango de fecha
                        foreach (DateTime fecha in fechas)
                        {
                            // si alguna de las fechas filtradas matchea con la fecha del registro, debemos sumar al registro de esta persona
                            if (fecha.Year == ((DateTime)dt.Rows[i][Fecha_NombreCol]).Year && fecha.Month == ((DateTime)dt.Rows[i][Fecha_NombreCol]).Month)
                            {
                                if (datos_sumados.Contains(fecha))
                                    datos_sumados[fecha] = (decimal)datos_sumados[fecha] + (decimal)dt.Rows[i][MontoVendido_NombreCol];
                                else
                                    datos_sumados[fecha] = (decimal)dt.Rows[i][MontoVendido_NombreCol];

                                // no es necesario iterar el resto de las fechas
                                break; 
                            }
                        }
                    }

                    totalGeneral += (decimal)dt.Rows[i]["Totales"];
                }
                #endregion Filas Datos

                for (int i = 0; i < dt.Rows.Count; i++)
                    dt.Rows[i]["%"] = (decimal)dt.Rows[i]["Totales"] / totalGeneral * 100;

                #region Filas Formulas
                foreach (string columna in fechas.Select(f => f.ToString("MMM yyyy")))
                {
                    if (sum_A != 0)
                        rowEnPorcentaje[columna] = (decimal)rowSumatoria[columna] * 100 / sum_A;
                    if (sum_C != 0)
                    {
                        rowExpCartera[columna] = (decimal)rowNroCltes[columna] * 100 / sum_C;
                        rowAprovCartera[columna] = (decimal)rowSumatoria[columna] / sum_C;
                    }
                    if (decimal.Parse(rowNroCltes[columna].ToString()) != 0)
                        rowPromeClteGS[columna] = (decimal)rowSumatoria[columna] / (decimal)rowNroCltes[columna];
                }
                resultado.Rows.Add(rowSumatoria);
                resultado.Rows.Add(rowEnPorcentaje);
                resultado.Rows.Add(rowNroCltes);
                resultado.Rows.Add(rowExpCartera);
                resultado.Rows.Add(rowPromeClteGS);
                resultado.Rows.Add(rowAprovCartera);
                #endregion Filas Formulas

                #endregion prepararDtResultado

                return resultado;
            }
        }
        #endregion GetPorClientesFechas

        #region GetPorVendedoresFechas
        public static DataTable GetPorVendedoresFechas(string clausulas, int anho_desde, int anho_hasta, int mes_desde, int mes_hasta)
        {
            using (SessionService sesion = new SessionService())
            {
                var dResultado = new Dictionary<decimal, object[]>();
                var sqlPartes = new List<string>();

                for (int i = 0; i < anho_hasta - anho_desde + 1; i++)
                {
                    DateTime fechaDesde = new DateTime(anho_desde + i, mes_desde, 1);
                    DateTime fechaHasta = new DateTime(anho_desde + i, mes_hasta, 1).AddMonths(1).AddDays(-1); //Ultimo día del mes

                    string sqlParte = "select " + VendedorComisionistaId_NombreCol + ", " +
                                 "       to_char(" + Fecha_NombreCol + ", 'mm') mes, " +
                                 "       to_char(" + Fecha_NombreCol + ", 'yyyy') anho, " +
                                 "       round(sum(" + MontoVendido_NombreCol + "), " + CantidadDecimales_NombreCol + ") monto " +
                                 "  from " + Nombre_Vista +
                                 " where trunc(" + Fecha_NombreCol + ") between to_date('" + fechaDesde.ToShortDateString() + "', 'dd/mm/yyyy') and to_date('" + fechaHasta.ToShortDateString() + "', 'dd/mm/yyyy')";
                    if (clausulas.Length > 0)
                        sqlParte += " and (" + clausulas + ")";
                    sqlParte += " group by " + VendedorComisionistaId_NombreCol + ", to_char(" + Fecha_NombreCol + ", 'mm'), to_char(" + Fecha_NombreCol + ", 'yyyy'), " + CantidadDecimales_NombreCol; ;
                    sqlPartes.Add(sqlParte);
                }

                string sql = string.Join(" union ", sqlPartes.ToArray());
                var dt = sesion.Db.EjecutarQuery(sql);
                var dtDistintos = sesion.db.ObtenerDistintos(new string[] { VendedorComisionistaId_NombreCol }, dt);

                #region crear columnas en datatable
                //Codigo, nombre, saldo linea, N columnas para mes-año, total
                var dtResultado = new DataTable();
                dtResultado.Columns.Add("Código", typeof(string));
                dtResultado.Columns.Add("Nombre", typeof(string));

                for (int anho = 0; anho < anho_hasta - anho_desde + 1; anho++)
                {
                    for (int mes = 0; mes < mes_hasta - mes_desde + 1; mes++)
                        dtResultado.Columns.Add((mes_desde + mes).ToString("00") + "-" + (anho_desde + anho).ToString("0000"), typeof(decimal));
                }
                dtResultado.Columns.Add("Total", typeof(decimal));
                dtResultado.Columns.Add("%", typeof(decimal));
                #endregion crear columnas en datatable

                decimal total = 0;
                for (int i = 0; i < dtDistintos.Rows.Count; i++)
                {
                    var dr = dtResultado.NewRow();
                    int cont = 0;

                    FuncionariosService f = new FuncionariosService((decimal)dtDistintos.Rows[i][0], sesion);
                    dr[cont++] = f.Codigo;
                    dr[cont++] = f.Nombre + " " + f.Apellido;

                    decimal totalFuncionario = 0;
                    for (int anho = 0; anho < anho_hasta - anho_desde + 1; anho++)
                    {
                        for (int mes = 0; mes < mes_hasta - mes_desde + 1; mes++)
                        {
                            var objeto = dt.Compute("sum(monto)", "anho = '" + (anho_desde + anho).ToString("0000") + "' and mes = '" + (mes_desde + mes).ToString("00") + "' and " + VendedorComisionistaId_NombreCol + " = " + f.Id.Value);
                            if (Interprete.EsNullODBNull(objeto))
                                dr[cont++] = 0;
                            else
                                dr[cont++] = objeto;

                            totalFuncionario += (decimal)dr[cont - 1];
                        }
                    }

                    dr[cont++] = totalFuncionario;
                    total += totalFuncionario;
                    dtResultado.Rows.Add(dr);
                }

                for (int i = 0; i < dtDistintos.Rows.Count; i++)
                    dtResultado.Rows[i][dtResultado.Columns.Count - 1] = (decimal)dtResultado.Rows[i][dtResultado.Columns.Count - 2] / total * 100;

                return dtResultado;
            }

            List<DateTime> fechas = new List<DateTime>();
            for (int anho = (int)anho_desde; anho <= anho_hasta; anho++)
            {
                for (int mes = (int)mes_desde; mes <= mes_hasta; mes++)
                    fechas.Add(new DateTime(anho, mes, 1));
            }
        }
        #endregion GetPorVendedoresFechas

        #region Accessors
        public static string Nombre_Vista
        {
            get { return "OBJETIVO_VENDEDOR_EXPLOTACION"; }
        }

        #region Vista

        public static string FacturaClienteDetalleId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.FACTURA_CLIENTE_DETALLE_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.FECHAColumnName; }
        }
        public static string VendedorComisionistaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.VENDEDOR_COMISIONISTA_IDColumnName; }
        }
        public static string VendedorNombre_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.VENDEDOR_NOMBREColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.PERSONA_IDColumnName; }
        }
        public static string PersonaNombreCompleto_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string PersonaCodigo_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.PERSONA_CODIGOColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.ARTICULO_IDColumnName; }
        }
        public static string ArticuloDescripcion_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string ArticuloMarcaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.ARTICULO_MARCA_IDColumnName; }
        }
        public static string FamiliaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.FAMILIA_IDColumnName; }
        }
        public static string FamiliaNombre_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.FAMILIA_NOMBREColumnName; }
        }
        public static string GrupoId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.GRUPO_IDColumnName; }
        }
        public static string GrupoNombre_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.GRUPO_NOMBREColumnName; }
        }
        public static string SubgrupoId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.SUBGRUPO_IDColumnName; }
        }
        public static string SubgrupoNombre_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.SUBGRUPO_NOMBREColumnName; }
        }
        public static string CantidadVendida_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.CANTIDAD_VENDIDAColumnName; }
        }
        public static string MontoVendidoUSD_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.MONTO_VENDIDO_USDColumnName; }
        }
        public static string MontoVendido_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.MONTO_VENDIDOColumnName; }
        }
        public static string MontoLineaCredito_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.MONTO_LINEA_CREDITOColumnName; }
        }

        public static string MonedaLineaCredito_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.MONEDA_LINEA_CREDITOColumnName; }
        }

        public static string MonedaLineaCreditoCotizacion_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.MONEDA_LC_COTIZACIONColumnName; }
        }

        public static string CreditoMenosDebito_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.CREDITO_MENOS_DEBITOColumnName; }
        }

        public static string TotCheqNoDepositNiEfectiv_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIVColumnName; }
        }

        public static string SucursalId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.SUCURSAL_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.MONEDA_IDColumnName; }
        }
        public static string CantidadDecimales_NombreCol
        {
            get { return OBJETIVO_VENDEDOR_EXPLOTACIONCollection.CANTIDAD_DECIMALESColumnName; }
        }

        #endregion Vista
        #endregion Accessors
    }
}
