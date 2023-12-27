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
using CBA.FlowV2.Services.DetallesPersonalizados;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class TarifariosColumnasService   
    {
        #region GetDataTable
        public static DataTable GetTarifariosColumnasDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarifariosColumnasDataTable(where, orden, sesion);
            }
        }

        public static DataTable GetTarifariosColumnasDataTable(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TARIFARIOS_COLUMNASCollection.GetAsDataTable(where, orden);
        }

        public static DataTable GetTarifariosColumnasInfoCompleta(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarifariosColumnasInfoCompleta(where, orden, sesion);
            }
        }

        public static DataTable GetTarifariosColumnasInfoCompleta(string where, string orden, SessionService sesion)
        {
            return sesion.Db.TARIFARIOS_COLUMNAS_INF_COMPCollection.GetAsDataTable(where, orden);
        }
        #endregion GetDataTable

        #region GetColumnaNombre
        public static string GetColumnaNombre(decimal tarifario_columna_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetColumnaNombre(tarifario_columna_id, sesion);
            }
        }

        public static string GetColumnaNombre(decimal tarifario_columna_id, SessionService sesion)
        {
            TARIFARIOS_COLUMNASRow row = sesion.db.TARIFARIOS_COLUMNASCollection.GetByPrimaryKey(tarifario_columna_id);
           
                return row.NOMBRE;
        }
        #endregion GetColumnaNombre

        #region GetColumnaNombre
        public static Hashtable ObtenerParametrosDeDatos(decimal tarifario_columna_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return ObtenerParametrosDeDatos(tarifario_columna_id, sesion);
            }
        }

        public static Hashtable ObtenerParametrosDeDatos(decimal tarifario_columna_id, SessionService sesion)
        {
            TARIFARIOS_COLUMNASRow row = sesion.db.TARIFARIOS_COLUMNASCollection.GetByPrimaryKey(tarifario_columna_id);
            Hashtable tabla = new Hashtable();
            if (!row.IsMINIMONull)
                tabla.Add(TarifariosColumnasService.Minimo_NombreCol, row.MINIMO);
            if (!row.IsMAXIMONull)
                tabla.Add(TarifariosColumnasService.Maximo_NombreCol, row.MAXIMO);
            if (!row.IsVALOR_POR_DEFECTONull)
                tabla.Add(TarifariosColumnasService.ValorPorDefecto_NombreCol, row.VALOR_POR_DEFECTO);

            return tabla;
        }
        #endregion GetColumnaNombre

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService()) 
            {
                try {
                    sesion.Db.BeginTransaction();
                    decimal tarifarioColumnaId = Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();

                    return tarifarioColumnaId;
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
                TARIFARIOS_COLUMNASRow row = new TARIFARIOS_COLUMNASRow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("tarifarios_columnas_sqc");
                }
                else
                {
                    row = sesion.Db.TARIFARIOS_COLUMNASCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }
                
                row.TARIFARIO_ID = (decimal)campos[TarifariosColumnasService.TarifarioId_NombreCol];
                row.NOMBRE = campos[TarifariosColumnasService.Nombre_NombreCol].ToString();
                row.TIPO_DATO_ID = decimal.Parse(campos[TarifariosColumnasService.TipoDatoId_NombreCol].ToString());

                #region Maximos Minimos y Valores por defecto
                if (decimal.ToInt32(row.TIPO_DATO_ID).Equals(TiposDetallesPersonalizadosService.TipoDato.NumeroMonto) || decimal.ToInt32(row.TIPO_DATO_ID).Equals(TiposDetallesPersonalizadosService.TipoDato.NumeroCantidad)
                    || decimal.ToInt32(row.TIPO_DATO_ID).Equals(TiposDetallesPersonalizadosService.TipoDato.NumeroPorcentaje))
                {
                    if (campos.Contains(TarifariosColumnasService.Minimo_NombreCol))
                    {
                        row.MINIMO = decimal.Parse(campos[TarifariosColumnasService.Minimo_NombreCol].ToString());
                    }
                    else {
                        row.IsMINIMONull = true;
                    }
                    if (campos.Contains(TarifariosColumnasService.Maximo_NombreCol))
                    {
                        row.MAXIMO = decimal.Parse(campos[TarifariosColumnasService.Maximo_NombreCol].ToString());
                    }
                    else {
                        row.IsMAXIMONull = true;
                    }
                    if (campos.Contains(TarifariosColumnasService.ValorPorDefecto_NombreCol))
                    {
                        row.VALOR_POR_DEFECTO = decimal.Parse(campos[TarifariosColumnasService.ValorPorDefecto_NombreCol].ToString());
                    }
                    else
                    {
                        row.IsVALOR_POR_DEFECTONull = true;
                    }
                    
                }
                else {
                    row.IsMAXIMONull = true;
                    row.IsMINIMONull = true;
                    row.IsVALOR_POR_DEFECTONull = true;
                    if (decimal.ToInt32(row.TIPO_DATO_ID).Equals(TiposDetallesPersonalizadosService.TipoDato.MonedaMonto))
                    {
                        if (campos.Contains(TarifariosColumnasService.ValorPorDefecto_NombreCol))
                        {
                            row.VALOR_POR_DEFECTO = decimal.Parse(campos[TarifariosColumnasService.ValorPorDefecto_NombreCol].ToString());
                        }
                        
                    }
                    
                }
                if (!row.IsMINIMONull && !row.IsMAXIMONull)
                {
                    if (row.MINIMO > row.MAXIMO)
                        throw new Exception("El valor por maximo no puede ser menor al valor minimo");
                }
                if (!row.IsMINIMONull && !row.IsVALOR_POR_DEFECTONull)
                {
                    if (row.MINIMO > row.VALOR_POR_DEFECTO)
                        throw new Exception("El valor por defecto no puede ser menor al valor minimo");
                }
                if (!row.IsMAXIMONull && !row.IsVALOR_POR_DEFECTONull)
                {
                    if (row.MAXIMO < row.VALOR_POR_DEFECTO)
                        throw new Exception("El valor por defecto no puede ser mayor al valor maximo");
                }
                #endregion Maximos Minimos y Valores por defecto

                if (campos.Contains(TarifariosColumnasService.IncluirSiempre_NombreCol))
                    row.INCLUIR_SIEMPRE = campos[TarifariosColumnasService.IncluirSiempre_NombreCol].ToString();
                else
                    row.INCLUIR_SIEMPRE = Definiciones.SiNo.No;

                if (campos.Contains(TarifariosColumnasService.TomarDatoIngresado_NombreCol))
                    row.TOMAR_DATO_INGRESADO = campos[TarifariosColumnasService.TomarDatoIngresado_NombreCol].ToString();
                else
                    row.TOMAR_DATO_INGRESADO = Definiciones.SiNo.No;
                
                #region Periodos
                if (campos.Contains(TarifariosColumnasService.PrimerPeriodo_NombreCol))
                {
                    row.PRIMER_PERIODO = decimal.Parse(campos[TarifariosColumnasService.PrimerPeriodo_NombreCol].ToString());

                    if (campos.Contains(TarifariosColumnasService.PeriodosPosteriores_NombreCol))
                        row.PERIODOS_POSTERIORES = decimal.Parse(campos[TarifariosColumnasService.PeriodosPosteriores_NombreCol].ToString());
                    else
                        throw new Exception("Falta Asignar los periodos posteriores");

                    if (campos.Contains(TarifariosColumnasService.ProrrateoPeriodos_NombreCol))
                        row.PRORRATEO_PERIODOS = decimal.Parse(campos[TarifariosColumnasService.ProrrateoPeriodos_NombreCol].ToString());
                    else
                        throw new Exception("Falta Asignar el dato para el calculo del Prorrateo.");
 
                    
                }
                else {
                    row.IsPRIMER_PERIODONull = true;
                    row.IsPERIODOS_POSTERIORESNull = true;
                    row.IsPRORRATEO_PERIODOSNull = true;
                }
                #endregion Periodos

                row.ESTADO = Definiciones.Estado.Activo;
                row.USUARIO_MODIFICACION_ID = sesion.Usuario_Id;
                row.FECHA_MODIFICACION = DateTime.Now;
                row.OBLIGATORIO = campos[TarifariosColumnasService.Obligatorio_NombreCol].ToString();
                row.ORDEN = (decimal)campos[TarifariosColumnasService.Orden_NombreCol];
                if (campos.Contains(TarifariosColumnasService.ArticuloRelacionadoId_NombreCol))
                    row.ARTICULO_RELACIONADO_ID = (decimal)campos[TarifariosColumnasService.ArticuloRelacionadoId_NombreCol];
                else
                    row.IsARTICULO_RELACIONADO_IDNull = true;
                if (campos.Contains(TarifariosColumnasService.TarifarioGrupoId_NombreCol))
                    row.TARIFARIOS_GRUPO_ID = (decimal)campos[TarifariosColumnasService.TarifarioGrupoId_NombreCol];
                else
                    row.IsTARIFARIOS_GRUPO_IDNull = true;

                if (insertarNuevo) sesion.Db.TARIFARIOS_COLUMNASCollection.Insert(row);
                else sesion.Db.TARIFARIOS_COLUMNASCollection.Update(row);
                
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                if (insertarNuevo)
                {
                    if (decimal.ToInt32(row.TIPO_DATO_ID).Equals(TiposDetallesPersonalizadosService.TipoDato.NumeroMonto))
                    {
                        TARIFARIOS_COLUMNASRow rowAux = new TARIFARIOS_COLUMNASRow();
                        rowAux = row;
                        rowAux.NOMBRE = row.NOMBRE + TarifariosColumnasService.MonedaMontoId_Nombrecol;
                        rowAux.ID = sesion.Db.GetSiguienteSecuencia("tarifarios_columnas_sqc");
                        rowAux.TIPO_DATO_ID = TiposDetallesPersonalizadosService.TipoDato.MonedaMonto;
                        sesion.Db.TARIFARIOS_COLUMNASCollection.Insert(rowAux);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, rowAux.ID, valorAnterior, rowAux.ToString(), sesion);
                    }
                }

                return row.ID;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal tarifario_columna_id, SessionService sesion)
        {
            try
            {
                TARIFARIOS_COLUMNASRow row = sesion.Db.TARIFARIOS_COLUMNASCollection.GetByPrimaryKey(tarifario_columna_id);
                String valorAnterior = row.ToString();

                row.ESTADO = Definiciones.Estado.Inactivo;
                row.FECHA_MODIFICACION = DateTime.Now;
                row.USUARIO_MODIFICACION_ID = sesion.Usuario_Id;

                sesion.Db.TARIFARIOS_COLUMNASCollection.Update(row);
                LogCambiosService.LogDeRegistro(TarifariosColumnasService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

               
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }

        public static void Borrar(decimal tarifario_columna_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Borrar(tarifario_columna_id, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar


        #region BorrarGrupos
        public static void BorrarGrupos(decimal tarifario_grupo_id, SessionService sesion)
        {
            try
            {
                
                String valorAnterior = string.Empty;

                TARIFARIOS_COLUMNASRow[] columnas = sesion.db.TARIFARIOS_COLUMNASCollection.GetByTARIFARIOS_GRUPO_ID(tarifario_grupo_id);
                for (int i = 0; i < columnas.Length; i++)
                {
                    valorAnterior = columnas[i].ToString();
                    columnas[i].IsTARIFARIOS_GRUPO_IDNull = true;
                    sesion.db.TARIFARIOS_COLUMNASCollection.Update(columnas[i]);
                    LogCambiosService.LogDeRegistro(TarifariosColumnasService.Nombre_NombreCol, columnas[i].ID, valorAnterior, columnas[i].ToString(), sesion);
                }

                
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }

        public static void BorrarGrupos(decimal tarifario_grupo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                BorrarGrupos(tarifario_grupo_id, sesion);

            }
        }
        #endregion BorrarGrupos

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "TARIFARIOS_COLUMNAS"; }
        }
        public static string Id_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.IDColumnName; }
        }
        public static string TarifarioId_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.TARIFARIO_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.NOMBREColumnName; }
        }
        public static string TipoDatoId_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.TIPO_DATO_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.ESTADOColumnName; }
        }
        public static string UsuarioModificacionId_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.USUARIO_MODIFICACION_IDColumnName; }
        }
        public static string FechaDeModificacion_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.FECHA_MODIFICACIONColumnName; }
        }
        public static string Obligatorio_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.OBLIGATORIOColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.ORDENColumnName; }
        }
        public static string ArticuloRelacionadoId_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.ARTICULO_RELACIONADO_IDColumnName; }
        }
        public static string TarifarioGrupoId_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.TARIFARIOS_GRUPO_IDColumnName; }
        }
        public static string Minimo_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.MINIMOColumnName; }
        }
        public static string Maximo_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.MAXIMOColumnName; }
        }
        public static string ValorPorDefecto_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.VALOR_POR_DEFECTOColumnName; }
        }
        public static string IncluirSiempre_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.INCLUIR_SIEMPREColumnName; }
        }
        public static string TomarDatoIngresado_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.TOMAR_DATO_INGRESADOColumnName; }
        }
        public static string PrimerPeriodo_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.PRIMER_PERIODOColumnName; }
        }
        public static string PeriodosPosteriores_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.PERIODOS_POSTERIORESColumnName; }
        }
        public static string ProrrateoPeriodos_NombreCol
        {
            get { return TARIFARIOS_COLUMNASCollection.PRORRATEO_PERIODOSColumnName; }
        }
        #endregion Tabla
        #region Vista
        public static string Nombre_Vista
        {
            get { return "tarifarios_columnas_inf_comp"; }
        }
        public static string MonedaMontoId_Nombrecol
        {
            get { return "_moneda_id"; }
        }
        public static string VistaTarifarioNombre_NombreCol
        {
            get { return TARIFARIOS_COLUMNAS_INF_COMPCollection.TARIFARIO_NOMBREColumnName; }
        }
        public static string VistaUsuarioModificacionNombre_NombreCol
        {
            get { return TARIFARIOS_COLUMNAS_INF_COMPCollection.USUARIO_MODIFICACION_NOMBREColumnName; }
        }
        public static string VistaArticuloRelacionadoCodigoNombreCol
        {
            get { return TARIFARIOS_COLUMNAS_INF_COMPCollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloRelacionadoDescripcionNombreCol
        {
            get { return TARIFARIOS_COLUMNAS_INF_COMPCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaTarifarioGrupoNombre_NombreCol
        {
            get { return TARIFARIOS_COLUMNAS_INF_COMPCollection.TARIFARIO_GRUPO_NOMBREColumnName; }
        }
        public static string VistaTarifarioGrupoOperacion_NombreCol
        {
            get { return TARIFARIOS_COLUMNAS_INF_COMPCollection.TARIFARIO_GRUPO_OPERACIONColumnName; }
        }
        #endregion Vista
        #endregion Accessors

        #region Clase Escala
        public class EscalaCBA
        {
            public int tipo_escala { get; set; }
            public List<EscalaDetalleCBA> datos = new List<EscalaDetalleCBA>();


            public EscalaCBA()
            {
                tipo_escala =TiposDetallesPersonalizadosService.TipoDato.EscalaMontoPorcentaje ;
                datos = new List<EscalaDetalleCBA>();
            }
            
            public EscalaCBA Deserializar(string valor)
            {
                return JsonUtil.Deserializar<EscalaCBA>(valor);
            }
            public string Serializar(EscalaCBA escala)
            {
                return JsonUtil.Serializar(escala);
            }
            public string toString()
            {
                #region Datos de las monedas
                DataTable dtMonedas = MonedasService.GetMonedasActivas2();
                Dictionary<decimal, string> monedasSimbolos = new Dictionary<decimal, string>();
                Dictionary<decimal, string> monedasFormateo = new Dictionary<decimal, string>();

                for (int i = 0; i < dtMonedas.Columns.Count; i++)
                {
                    monedasSimbolos.Add(decimal.Parse(dtMonedas.Rows[i][MonedasService.Modelo.IDColumnName].ToString()), dtMonedas.Rows[i][MonedasService.Modelo.SIMBOLOColumnName].ToString());
                    monedasFormateo.Add(decimal.Parse(dtMonedas.Rows[i][MonedasService.Modelo.IDColumnName].ToString()), dtMonedas.Rows[i][MonedasService.Modelo.CADENA_DECIMALESColumnName].ToString());
                }
                #endregion Datos de las monedas

                #region Titulo
                string cadena = string.Empty;
                switch (this.tipo_escala)
                {
                    
                    case TiposDetallesPersonalizadosService.TipoDato.EscalaCantidadMonto:
                        cadena += "Montos según rango de Cantidades";
                        break;
                    case TiposDetallesPersonalizadosService.TipoDato.EscalaCantidadPorcentaje:
                        cadena += " Porcentajes según rango de Cantidades";
                        break;
                    case TiposDetallesPersonalizadosService.TipoDato.EscalaMontoMonto:
                        cadena += "Montos según rango de Montos";
                        break;
                    case TiposDetallesPersonalizadosService.TipoDato.EscalaMontoPorcentaje:
                        cadena += "Porcentajes según rango de Montos";
                        break;

                    default: 
                        break;
                }
                #endregion Titulo
                cadena += " \n ";

                string formatoRango = string.Empty;
                string formatoDato = "###,###,##0.##";
                string simboloRango = string.Empty;
                 string simboloDato = string.Empty;

                foreach (EscalaDetalleCBA detalle in this.datos)
                {
                    #region Formateo de Datos
                    string formato = string.Empty;
                    string simbolo = string.Empty;

                    #region Formateo de los valores de los rangos
                    if (!detalle.moneda_rango_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        
                        if (monedasFormateo.TryGetValue(detalle.moneda_rango_id, out formato))
                           formatoRango = formato;
                        else
                            formatoRango = "###,###,##0";
                        if (monedasSimbolos.TryGetValue(detalle.moneda_rango_id, out simbolo))
                            simboloRango =simbolo;

                    }
                    #endregion Formateo de los valores de los rangos

                    #region Formateo de los valores de los datos
                    if (!detalle.moneda_dato_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        
                        if (monedasFormateo.TryGetValue(detalle.moneda_dato_id, out formato))
                           formatoDato = formato;
                        else
                            formatoDato = "###,###,##0.##";
                        if (monedasSimbolos.TryGetValue(detalle.moneda_dato_id, out simbolo))
                            simboloDato =simbolo;
                        else
                            simboloDato= "%";

                    }
                    #endregion Formateo de los valores de los datos
                    #endregion Formateo de Datos

                    //se concatenan los datos
                    cadena += "De: " + detalle.desde.ToString(formatoRango) + " a: " + detalle.hasta.ToString(formatoRango) + " " + simboloRango + " = " + detalle.dato.ToString(formatoDato) + " " + simboloDato;
                    cadena += " \n ";
                    
                }
                return cadena;
            }

            public EscalaResultadoCBA ObtenerResultado(decimal dato, decimal moneda_id, decimal cotizacion)
            {
                EscalaResultadoCBA resultado = new EscalaResultadoCBA();
                foreach (EscalaDetalleCBA detalles in this.datos)
                {
                    #region Seleccion del Rango
                    if (!moneda_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    {
                        if (detalles.moneda_rango_id.Equals(moneda_id))
                        {
                            if (detalles.desde <= dato && dato <= detalles.hasta)
                            {
                                resultado.valor = detalles.dato;
                                resultado.moneda_valor_id = detalles.moneda_dato_id;
                            }
                        }
                    }
                    else {
                        if (detalles.desde <= dato && dato <= detalles.hasta)
                        {
                            resultado.valor = detalles.dato;
                            resultado.moneda_valor_id = detalles.moneda_dato_id;
                        }
                    }
                    #endregion Seleccion del Rango
                    
                }
                return resultado;
            }
        }

        public class EscalaDetalleCBA
        {
            public decimal desde { get; set; }
            public decimal hasta { get; set; }
            public decimal moneda_rango_id { get; set; }
            public decimal dato { get; set; }
            public decimal moneda_dato_id { get; set; }


            public EscalaDetalleCBA()
            {
                desde = 0;
                hasta = 0;
                moneda_rango_id = Definiciones.Error.Valor.EnteroPositivo;
                dato = 0;
                moneda_rango_id = Definiciones.Error.Valor.EnteroPositivo;

            }
            public EscalaDetalleCBA Deserializar(string valor)
            {
                return JsonUtil.Deserializar<EscalaDetalleCBA>(valor);
            }
            public string Serializar(EscalaDetalleCBA escala)
            {
                return JsonUtil.Serializar(escala);
            }
            
        }
        public class EscalaResultadoCBA
        {
            public decimal valor;
            public decimal moneda_valor_id;

            public EscalaResultadoCBA()
            {
                valor = 0;
                moneda_valor_id = Definiciones.Error.Valor.EnteroPositivo;
            }
            public EscalaResultadoCBA Deserializar(string valor)
            {
                return JsonUtil.Deserializar<EscalaResultadoCBA>(valor);
            }
            public string Serializar(EscalaResultadoCBA resultado)
            {
                return JsonUtil.Serializar(resultado);
            }
        }
        #endregion Clase Escala
    }

    
}

