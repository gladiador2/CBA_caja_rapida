#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
using System.Text;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosAutoRelacionesService
    {
        #region Clase Exclusion
        public class Exclusion
        {
            public List<int> Columnas { get; set; }

            public Exclusion()
            {
                this.Columnas = new List<int>();
            }

            public void Agregar(int columna)
            {
                if (!this.Columnas.Contains(columna))
                    this.Columnas.Add(columna);
            }
        }
        #endregion Clase Exclusion

        #region Clase Inclusion
        public class Inclusion
        {
            public List<int> Columnas { get; set; }

            public Inclusion()
            {
                this.Columnas = new List<int>();
            }

            public void Agregar(int columna)
            {
                if (!this.Columnas.Contains(columna))
                    this.Columnas.Add(columna);
            }
        }
        #endregion Clase Inclusion

        #region GetAsientosAutoRelacionesDataTable
        /// <summary>
        /// Gets the asientos auto relaciones data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosAutoRelacionesDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_ASIENTOS_AUTO_RELACIONESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetAsientosAutoRelacionesDataTable

        #region GetAsientosAutoRelacionesInfoCompleta

        /// <summary>
        /// Gets the asientos auto relaciones info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosAutoRelacionesInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_ASIENTOS_AUTO_REL_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetAsientosAutoRelacionesInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_ASIENTOS_AUTO_RELACIONESRow row;
                    string valorAnterior;

                    if (insertarNuevo)
                    {
                        row = new CTB_ASIENTOS_AUTO_RELACIONESRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_asientos_auto_rel_sqc");
                    }
                    else
                    {
                        row = sesion.Db.CTB_ASIENTOS_AUTO_RELACIONESCollection.GetByPrimaryKey((decimal)campos[AsientosAutoRelacionesService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    row.CTB_ASIENTO_AUTO_DET_ID = decimal.Parse(campos[AsientosAutoRelacionesService.CtbAsientoAutoDetId_NombreCol].ToString());

                    if (campos.Contains(AsientosAutoRelacionesService.CtbCuentaId_NombreCol))
                        row.CTB_CUENTA_ID = (decimal)campos[AsientosAutoRelacionesService.CtbCuentaId_NombreCol];
                    else
                        row.IsCTB_CUENTA_IDNull = true;

                    row.CTB_PLAN_CUENTA_ID = (decimal)campos[AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol];
                    row.INVERTIR_DEBE_Y_HABER = (string)campos[AsientosAutoRelacionesService.InvertirDebeYHaber_NombreCol];
                    row.INVERTIR_SI_ES_NEGATIVO = (string)campos[AsientosAutoRelacionesService.InvertirSiEsNegativo_NombreCol];

                    if (campos.Contains(AsientosAutoRelacionesService.SucursalId_NombreCol))
                        row.SUCURSAL_ID = (decimal)campos[AsientosAutoRelacionesService.SucursalId_NombreCol];
                    else
                        row.IsSUCURSAL_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.RegionId_NombreCol))
                        row.REGION_ID = (decimal)campos[AsientosAutoRelacionesService.RegionId_NombreCol];
                    else
                        row.IsREGION_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.CtacteValorId_NombreCol))
                        row.CTACTE_VALOR_ID = (decimal)campos[AsientosAutoRelacionesService.CtacteValorId_NombreCol];
                    else
                        row.IsCTACTE_VALOR_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = (decimal)campos[AsientosAutoRelacionesService.ProveedorId_NombreCol];
                    else
                        row.IsPROVEEDOR_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol))
                        row.PROVEEDOR_RELACIONADO_ID = (decimal)campos[AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol];
                    else
                        row.IsPROVEEDOR_RELACIONADO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.PersonaId_NombreCol))
                        row.PERSONA_ID = (decimal)campos[AsientosAutoRelacionesService.PersonaId_NombreCol];
                    else
                        row.IsPERSONA_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol))
                        row.PERSONA_RELACIONADA_ID = (decimal)campos[AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol];
                    else
                        row.IsPERSONA_RELACIONADA_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol))
                        row.PROVEEDOR_RELACIONADO_ID = (decimal)campos[AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol];
                    else
                        row.IsPROVEEDOR_RELACIONADO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.BonificacionId_NombreCol))
                        row.BONIFICACION_ID = (decimal)campos[AsientosAutoRelacionesService.BonificacionId_NombreCol];
                    else
                        row.IsBONIFICACION_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.DescuentoId_NombreCol))
                        row.DESCUENTO_ID = (decimal)campos[AsientosAutoRelacionesService.DescuentoId_NombreCol];
                    else
                        row.IsDESCUENTO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.FuncionarioId_NombreCol))
                        row.FUNCIONARIO_ID = (decimal)campos[AsientosAutoRelacionesService.FuncionarioId_NombreCol];
                    else
                        row.IsFUNCIONARIO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol))
                        row.CTACTE_BANCARIA_ID = (decimal)campos[AsientosAutoRelacionesService.CtacteBancariaId_NombreCol];
                    else
                        row.IsCTACTE_BANCARIA_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.StockDepositoId_NombreCol))
                        row.STOCK_DEPOSITO_ID = (decimal)campos[AsientosAutoRelacionesService.StockDepositoId_NombreCol];
                    else
                        row.IsSTOCK_DEPOSITO_IDNull = true;
                    
                    if (campos.Contains(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol))
                        row.ARTICULO_FAMILIA_ID = (decimal)campos[AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol];
                    else
                        row.IsARTICULO_FAMILIA_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol))
                        row.ARTICULO_GRUPO_ID = (decimal)campos[AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol];
                    else
                        row.IsARTICULO_GRUPO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol))
                        row.ARTICULO_SUBGRUPO_ID = (decimal)campos[AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol];
                    else
                        row.IsARTICULO_SUBGRUPO_IDNull= true;

                    if (campos.Contains(AsientosAutoRelacionesService.ArticuloId_NombreCol))
                        row.ARTICULO_ID = (decimal)campos[AsientosAutoRelacionesService.ArticuloId_NombreCol];
                    else
                        row.IsARTICULO_IDNull = true;

                    row.ARTICULO_DANHADO = (string)campos[AsientosAutoRelacionesService.ArticuloDanhado_NombreCol]; 
                    row.ARTICULO_USADO = (string)campos[AsientosAutoRelacionesService.ArticuloUsado_NombreCol];
                    
                    if (campos.Contains(AsientosAutoRelacionesService.MonedaId_NombreCol))
                        row.MONEDA_ID = (decimal)campos[AsientosAutoRelacionesService.MonedaId_NombreCol];
                    else
                        row.IsMONEDA_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.RubroId_NombreCol))
                        row.RUBRO_ID = (decimal)campos[AsientosAutoRelacionesService.RubroId_NombreCol];
                    else
                        row.IsRUBRO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol))
                        row.TEXTO_PREDEFINIDO_ID = (decimal)campos[AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol];
                    else
                        row.IsTEXTO_PREDEFINIDO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.TipoClienteId_NombreCol))
                        row.TIPO_CLIENTE_ID = (decimal)campos[AsientosAutoRelacionesService.TipoClienteId_NombreCol];
                    else
                        row.IsTIPO_CLIENTE_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol))
                        row.TIPO_NOTAS_CREDITO_ID = (decimal)campos[AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol];
                    else
                        row.IsTIPO_NOTAS_CREDITO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol))
                        row.CTACTE_CAJA_TESO_ID = (decimal)campos[AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol];
                    else
                        row.IsCTACTE_CAJA_TESO_IDNull = true;
                    
                    if (campos.Contains(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol))
                        row.CTACTE_FONDO_FIJO_ID = (decimal)campos[AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol];
                    else
                        row.IsCTACTE_FONDO_FIJO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol))
                        row.CTACTE_CHEQUE_ESTADO_ID = (decimal)campos[AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol];
                    else
                        row.IsCTACTE_CHEQUE_ESTADO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol))
                        row.TIPO_ORDEN_PAGO_ID = (decimal)campos[AsientosAutoRelacionesService.TipoOrdenPagoId_NombreCol];
                    else
                        row.IsTIPO_ORDEN_PAGO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol))
                        row.CANAL_VENTA_ID = (decimal)campos[AsientosAutoRelacionesService.CanalDeVentaId_NombreCol];
                    else
                        row.IsCANAL_VENTA_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.ActivoRubroId_NombreCol))
                        row.ACTIVO_RUBRO_ID = (decimal)campos[AsientosAutoRelacionesService.ActivoRubroId_NombreCol];
                    else
                        row.IsACTIVO_RUBRO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.ImpuestoId_NombreCol))
                        row.IMPUESTO_ID = (decimal)campos[AsientosAutoRelacionesService.ImpuestoId_NombreCol];
                    else
                        row.IsIMPUESTO_IDNull = true;

                    if (campos.Contains(AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol))
                        row.CTACTE_PROCESADORA_TARJETA_ID = (decimal)campos[AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol];
                    else
                        row.IsCTACTE_PROCESADORA_TARJETA_IDNull = true;

                    row.CREAR_ASIENTO = (string)campos[AsientosAutoRelacionesService.CrearAsiento_NombreCol];

                    if(campos.Contains(AsientosAutoRelacionesService.Exclusiones_NombreCol))
                        row.EXCLUSIONES = JsonUtil.Serializar(campos[AsientosAutoRelacionesService.Exclusiones_NombreCol]);

                    if (campos.Contains(AsientosAutoRelacionesService.Inclusiones_NombreCol))
                        row.INCLUSIONES = JsonUtil.Serializar(campos[AsientosAutoRelacionesService.Inclusiones_NombreCol]);

                    if (insertarNuevo) sesion.Db.CTB_ASIENTOS_AUTO_RELACIONESCollection.Insert(row);
                    else sesion.Db.CTB_ASIENTOS_AUTO_RELACIONESCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal relacion_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    CTB_ASIENTOS_AUTO_RELACIONESRow row;

                    row = sesion.Db.CTB_ASIENTOS_AUTO_RELACIONESCollection.GetByPrimaryKey(relacion_id);

                    sesion.Db.CTB_ASIENTOS_AUTO_RELACIONESCollection.DeleteByPrimaryKey(relacion_id);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion borrar

        #region Borrar Por Detalle
        public static void BorrarPorDetalle(decimal detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();

                    sesion.Db.CTB_ASIENTOS_AUTO_RELACIONESCollection.DeleteByCTB_ASIENTO_AUTO_DET_ID(detalle_id);

                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar por Detalle

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS_AUTO_RELACIONES"; }
        }
        public static string ActivoRubroId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.ACTIVO_RUBRO_IDColumnName; }
        }
        public static string ArticuloFamiliaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string ArticuloGrupoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.ARTICULO_GRUPO_IDColumnName; }
        }
        public static string ArticuloSubGrupoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.ARTICULO_SUBGRUPO_IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.ARTICULO_IDColumnName; }
        }
        public static string ArticuloDanhado_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.ARTICULO_DANHADOColumnName; }
        }
        public static string ArticuloUsado_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.ARTICULO_USADOColumnName; }
        }
        public static string BonificacionId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.BONIFICACION_IDColumnName; }
        }
        public static string CanalDeVentaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CANAL_VENTA_IDColumnName; }
        }
        public static string CtacteBancariaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTACTE_BANCARIA_IDColumnName; }
        }
        public static string CtacteCajaTesoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTACTE_CAJA_TESO_IDColumnName; }
        }
        public static string CtacteChequeEstadoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTACTE_CHEQUE_ESTADO_IDColumnName; }
        }
        public static string CtacteFondoFijoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string CtacteProcesadoraTarjetaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTACTE_PROCESADORA_TARJETA_IDColumnName; }
        }
        public static string CtacteValorId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTACTE_VALOR_IDColumnName; }
        }
        public static string CtbAsientoAutoDetId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTB_ASIENTO_AUTO_DET_IDColumnName; }
        }
        public static string CrearAsiento_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CREAR_ASIENTOColumnName; }
        }
        public static string CtbCuentaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTB_CUENTA_IDColumnName; }
        }
        public static string CtbPlanCuentaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.CTB_PLAN_CUENTA_IDColumnName; }
        }
        public static string DescuentoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.DESCUENTO_IDColumnName; }
        }
        public static string Exclusiones_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.EXCLUSIONESColumnName; }
        }
        public static string Inclusiones_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.INCLUSIONESColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.IMPUESTO_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.IDColumnName; }
        }
        public static string InvertirDebeYHaber_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.INVERTIR_DEBE_Y_HABERColumnName; }
        }
        public static string InvertirSiEsNegativo_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.INVERTIR_SI_ES_NEGATIVOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.MONEDA_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.PERSONA_IDColumnName; }
        }
        public static string PersonaRelacionadaId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.PERSONA_RELACIONADA_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.PROVEEDOR_IDColumnName; }
        }
        public static string ProveedorRelacionadoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.PROVEEDOR_RELACIONADO_IDColumnName; }
        }
        public static string RegionId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.REGION_IDColumnName; }
        }
        public static string RubroId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.RUBRO_IDColumnName; }
        }
        public static string StockDepositoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.STOCK_DEPOSITO_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.SUCURSAL_IDColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string TipoNotasCreditoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.TIPO_NOTAS_CREDITO_IDColumnName; }
        }
        public static string TipoOrdenPagoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.TIPO_ORDEN_PAGO_IDColumnName; }
        }
        public static string TipoClienteId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_RELACIONESCollection.TIPO_CLIENTE_IDColumnName; }
        }
        public static string VistaActivoRubroNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.ACTIVO_RUBRO_NOMBREColumnName; }
        }
        public static string VistaArticuloFamiliaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.ARTICULO_FAMILIA_NOMBREColumnName; }
        }
        public static string VistaArticuloGrupoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.ARTICULO_GRUPO_NOMBREColumnName; }
        }
        public static string VistaArticuloSubGrupoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.ARTICULO_SUBGRUPO_NOMBREColumnName; }
        }
        public static string VistaArticuloNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.ARTICULO_NOMBREColumnName; }
        }
        public static string VistaBonificacionNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.BONIFICACION_NOMBREColumnName; }
        }
        public static string VistaCanalVentaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CANAL_VENTA_NOMBREColumnName; }
        }
        public static string VistaCtacteBancariaBancoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_BANCARIA_BANCO_IDColumnName; }
        }
        public static string VistaCtacteBancariaBancoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_BANCARIA_BANCO_NOMBREColumnName; }
        }
        public static string VistaCtacteCajaTesoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_CAJA_TESO_NOMBREColumnName; }
        }
        public static string VistaCtacteChequeEstadoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_CHEQUE_ESTADO_NOMBREColumnName; }
        }
        public static string VistaCtacteFondoFijoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_FONDO_FIJO_NOMBREColumnName; }
        }
        public static string VistaCtacteProcTarjetaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_PROC_TARJETA_NOMBREColumnName; }
        }
        public static string VistaCtacteValorNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_VALOR_NOMBREColumnName; }
        }
        public static string VistaCtacteBancariaNumero_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTACTE_BANCARIA_NUMEROColumnName; }
        }
        public static string VistaCtbPlanCuentaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTB_PLAN_CUENTA_NOMBREColumnName; }
        }
        public static string VistaCtbAsientoAutoDetDesc_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTB_ASIENTO_AUTO_DET_DESCColumnName; }
        }
        public static string VistaCtbAsientoDetalleNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTB_ASIENTO_AUTO_DET_NOMBREColumnName; }
        }
        public static string VistaCtbAsientoAutomaticoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTB_ASIENTO_AUTOMATICO_IDColumnName; }
        }
        public static string VistaCtbCuentaCodigo_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTB_CUENTA_CODIGOColumnName; }
        }
        public static string VistaCtbCuentaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTB_CUENTA_NOMBREColumnName; }
        }
        public static string VistaDescuentoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.DESCUENTO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.IMPUESTO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaPersonaRelacionadaNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.PERSONA_RELACIONADA_NOMBREColumnName; }
        }
        public static string VistaProveedorNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.PROVEEDOR_NOMBREColumnName; }
        }
        public static string VistaProveedorRelNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.PROVEEDOR_REL_RAZON_SOCIALColumnName; }
        }
        public static string VistaRegionNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.REGION_NOMBREColumnName; }
        }
        public static string VistaStockDepositoNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.STOCK_DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaStockDepositoSucursalId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.STOCK_DEPOSITO_SUCURSAL_IDColumnName; }
        }
        public static string VistaStockDepositoSucursalNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.STOCK_DEPOSITO_SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaRubroNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.RUBRO_NOMBREColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTextoPredefinidoTexto_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.TEXTO_PREDEFINIDO_TEXTOColumnName; }
        }
        public static string VistaTipoClienteNombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.TIPO_CLIENTE_NOMBREColumnName; }
        }
        public static string VistaTipoNotasCreditoDescripcion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.TIPO_NOTAS_CREDITO_DESCRIPCIONColumnName; }
        }
        public static string VistaTipoOrdenPagoDescripcion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.TIPO_ORDEN_PAGO_DESCRIPCIONColumnName; }
        }
        public static string VistaCtbPlanCuentaEstado_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_REL_INFO_CCollection.CTB_PLAN_CUENTA_ESTADOColumnName; }
        }
        #endregion Accesors
    }
}
