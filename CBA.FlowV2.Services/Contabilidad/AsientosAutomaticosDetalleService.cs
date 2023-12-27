#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using CBA.FlowV2.Services.Common;
using System.Collections.Generic;
using CBA.FlowV2.Services.Casos;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class AsientosAutomaticosDetalleService
    {
        #region GetAsientosAutomaticosDetalleDataTable

        /// <summary>
        /// Gets the asientos automaticos detalle data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosAutomaticosDetalleDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTB_ASIENTOS_AUTO_DETCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetAsientosAutomaticosDetalleDataTable

        #region GetAsientosAutomaticosDetalleInfoCompleta
        public static DataTable GetAsientosAutomaticosDetalleInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetAsientosAutomaticosDetalleInfoCompleta(clausulas, orden, sesion);
            }
        }

        /// <summary>
        /// Gets the asientos automaticos detalle info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetAsientosAutomaticosDetalleInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTB_ASIENTOS_AUTO_DET_INFO_COMCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetAsientosAutomaticosDetalleInfoCompleta

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_ASIENTOS_AUTO_DETRow row;
                    string valorAnterior;

                    row = sesion.Db.CTB_ASIENTOS_AUTO_DETCollection.GetByPrimaryKey((decimal)campos[AsientosAutomaticosDetalleService.Id_NombreCol]);
                    valorAnterior = row.ToString();

                    row.CTB_ASIENTO_AUTOMATICO_ID = (decimal)campos[AsientosAutomaticosDetalleService.AsientoAutomaticoId_NombreCol];
                    row.DESCRIPCION = (string)campos[AsientosAutomaticosDetalleService.Descripcion_NombreCol];
                    row.ESTRUCTURA_OBSERVACION = (string)campos[AsientosAutomaticosDetalleService.EstructuraObservacion_NombreCol];
                    row.NOMBRE = (string)campos[AsientosAutomaticosDetalleService.Nombre_NombreCol];
                    row.ORDEN = (decimal)campos[AsientosAutomaticosDetalleService.Orden_NombreCol];
                    row.RESUMIR_DETALLES = (string)campos[AsientosAutomaticosDetalleService.ResumirDetalles_NombreCol];
                    row.COPIAR_OBS_CABECERA_ASIENTO = (string)campos[AsientosAutomaticosDetalleService.CopiarObsCabeceraAsiento_NombreCol];

                    if (campos.Contains(AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol))
                        row.COLUMNA_PRIORITARIA = (decimal)campos[AsientosAutomaticosDetalleService.ColumnaPrioritaria_NombreCol];
                    else
                        row.IsCOLUMNA_PRIORITARIANull = true;

                    if (campos.Contains(AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol))
                        row.COLUMNA_PRIORITARIA2 = (decimal)campos[AsientosAutomaticosDetalleService.ColumnaPrioritaria2_NombreCol];
                    else
                        row.IsCOLUMNA_PRIORITARIA2Null = true;

                    if (campos.Contains(AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol))
                        row.CENTRO_COSTO_PRIORIDAD = (decimal)campos[AsientosAutomaticosDetalleService.CentroCostoPrioridad_NombreCol];
                    else
                        row.IsCENTRO_COSTO_PRIORIDADNull = true;

                    if (campos.Contains(AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol))
                        row.CENTRO_COSTO_PRIORIDAD2 = (decimal)campos[AsientosAutomaticosDetalleService.CentroCostoPrioridad2_NombreCol];
                    else
                        row.IsCENTRO_COSTO_PRIORIDAD2Null = true;

                    if (campos.Contains(AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol))
                        row.CENTRO_COSTO_PRIORIDAD3 = (decimal)campos[AsientosAutomaticosDetalleService.CentroCostoPrioridad3_NombreCol];
                    else
                        row.IsCENTRO_COSTO_PRIORIDAD3Null = true;

                    sesion.Db.CTB_ASIENTOS_AUTO_DETCollection.Update(row);

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

        #region GetCuentaAAsentar
        /// <summary>
        /// Gets the cuenta A asentar.
        /// </summary>
        /// <param name="asiento_automatico_detalle_id">The asiento_automatico_detalle_id.</param>
        /// <param name="columna_preferencia">The columna_preferencia.</param>
        /// <param name="parametros">The parametros.</param>
        /// <returns></returns>
        public static decimal GetCuentaAAsentar(decimal asiento_automatico_detalle_id, object columna_preferencia1, object columna_preferencia2, Hashtable parametros, out bool invertir_debe_haber, out bool invertir_si_es_negativo, ref bool crear_asiento, SessionService sesion)
        {
            decimal cuentaId = Definiciones.Error.Valor.EnteroPositivo;
            decimal preferencia1 = Definiciones.Error.Valor.EnteroPositivo;
            decimal preferencia2 = Definiciones.Error.Valor.EnteroPositivo;
            string clausulas, orden, orden1, orden2;
            List<int> camposPresentes = new List<int>();

            invertir_debe_haber = false;
            invertir_si_es_negativo = false;

            if (!columna_preferencia1.Equals(DBNull.Value))
                preferencia1 = (decimal)columna_preferencia1;

            if (!columna_preferencia2.Equals(DBNull.Value))
                preferencia2 = (decimal)columna_preferencia2;

            #region sql clausulas
            clausulas = AsientosAutoRelacionesService.CtbAsientoAutoDetId_NombreCol + " = " + asiento_automatico_detalle_id + " and " +
                        AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtbPlanCuentaId_NombreCol];

            if (parametros.Contains(AsientosAutoRelacionesService.ArticuloId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ArticuloId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ArticuloId_NombreCol] + " or " + AsientosAutoRelacionesService.ArticuloId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Articulo);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ArticuloId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol] + " or " + AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloFamilia);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol] + " or " + AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloGrupo);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol] + " or " + AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloSubGrupo);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ArticuloUsado_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloUsado_NombreCol]))
                clausulas += " and (" + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + " = '" + parametros[AsientosAutoRelacionesService.ArticuloUsado_NombreCol] + "' or " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + " is null)";
            else
                clausulas += " and " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + " is null";

            if (parametros.Contains(AsientosAutoRelacionesService.ArticuloDanhado_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloDanhado_NombreCol]))
                clausulas += " and (" + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol + " = '" + parametros[AsientosAutoRelacionesService.ArticuloDanhado_NombreCol] + "' or " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol + " is null)";
            else
                clausulas += " and " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol + " is null";

            if (parametros.Contains(AsientosAutoRelacionesService.CanalDeVentaId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CanalDeVentaId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.CanalDeVentaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CanalDeVentaId_NombreCol] + " or " + AsientosAutoRelacionesService.CanalDeVentaId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CanalDeVenta);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.CanalDeVentaId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.CtacteBancariaId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteBancariaId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.CtacteBancariaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtacteBancariaId_NombreCol] + " or " + AsientosAutoRelacionesService.CtacteBancariaId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtacteBancaria);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.CtacteBancariaId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol] + " or " + AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtaCteCajaTesoreria);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol]))
                clausulas += " and (" + AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol] + " or " + AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol + " is null)";
            else
                clausulas += " and " + AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol + " is null";

            if (parametros.Contains(AsientosAutoRelacionesService.FuncionarioId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.FuncionarioId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.FuncionarioId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.FuncionarioId_NombreCol] + " or " + AsientosAutoRelacionesService.FuncionarioId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Funcionario);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.FuncionarioId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.MonedaId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.MonedaId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.MonedaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.MonedaId_NombreCol] + " or " + AsientosAutoRelacionesService.MonedaId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Moneda);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.MonedaId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.PersonaId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.PersonaId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.PersonaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.PersonaId_NombreCol] + " or " + AsientosAutoRelacionesService.PersonaId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Persona);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.PersonaId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol] + " or " + AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.PersonaRelacionada);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol] + " or " + AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ProveedorRelacionado);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ProveedorId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ProveedorId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ProveedorId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ProveedorId_NombreCol] + " or " + AsientosAutoRelacionesService.ProveedorId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Proveedor);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ProveedorId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.RubroId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.RubroId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.RubroId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.RubroId_NombreCol] + " or " + AsientosAutoRelacionesService.RubroId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Rubro);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.RubroId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.RegionId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.RegionId_NombreCol]))
                clausulas += " and (" + AsientosAutoRelacionesService.RegionId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.RegionId_NombreCol] + " or " + AsientosAutoRelacionesService.RegionId_NombreCol + " is null)";
            else
                clausulas += " and " + AsientosAutoRelacionesService.RegionId_NombreCol + " is null";

            if (parametros.Contains(AsientosAutoRelacionesService.StockDepositoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.StockDepositoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.StockDepositoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.StockDepositoId_NombreCol] + " or " + AsientosAutoRelacionesService.StockDepositoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.StockDeposito);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.StockDepositoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.SucursalId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.SucursalId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.SucursalId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.SucursalId_NombreCol] + " or " + AsientosAutoRelacionesService.SucursalId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Sucursal);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.SucursalId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.CtacteValorId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteValorId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.CtacteValorId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtacteValorId_NombreCol] + " or " + AsientosAutoRelacionesService.CtacteValorId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtacteValor);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.CtacteValorId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol] + " or " + AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TextoPredefinido);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol]))
                clausulas += " and (" + AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol] + " or " + AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol + " is null)";
            else
                clausulas += " and " + AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol + " is null";

            if (parametros.Contains(AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol] + " or " + AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FondoFijo);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.TipoClienteId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TipoClienteId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.TipoClienteId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.TipoClienteId_NombreCol] + " or " + AsientosAutoRelacionesService.TipoClienteId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TipoCliente);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.TipoClienteId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol] + " or " + AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TipoNotaCredito);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.BonificacionId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.BonificacionId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.BonificacionId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.BonificacionId_NombreCol] + " or " + AsientosAutoRelacionesService.BonificacionId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FuncionarioBonificacion);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.BonificacionId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.DescuentoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.DescuentoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.DescuentoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.DescuentoId_NombreCol] + " or " + AsientosAutoRelacionesService.DescuentoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FuncionarioDescuento);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.DescuentoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ActivoRubroId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ActivoRubroId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ActivoRubroId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ActivoRubroId_NombreCol] + " or " + AsientosAutoRelacionesService.ActivoRubroId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ActivoRubro);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ActivoRubroId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.ImpuestoId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ImpuestoId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.ImpuestoId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.ImpuestoId_NombreCol] + " or " + AsientosAutoRelacionesService.ImpuestoId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Impuesto);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.ImpuestoId_NombreCol + " is null";
            }

            if (parametros.Contains(AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol]))
            {
                clausulas += " and (" + AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol + " = " + parametros[AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol] + " or " + AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol + " is null)";
                camposPresentes.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Impuesto);
            }
            else
            {
                clausulas += " and " + AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol + " is null";
            }
            #endregion sql clausulas

            #region sql orden1
            if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Articulo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloFamilia) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloGrupo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloSubGrupo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CanalDeVenta) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CanalDeVentaId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.CanalDeVentaId_NombreCol + ", " + AsientosAutoRelacionesService.CanalDeVentaId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtacteBancaria) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteBancariaId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.CtacteBancariaId_NombreCol + ", " + AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FondoFijo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtaCteCajaTesoreria) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtacteValor) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteValorId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.CtacteValorId_NombreCol + ", " + AsientosAutoRelacionesService.CtacteBancariaId_NombreCol + ", " + AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Funcionario) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.FuncionarioId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.FuncionarioId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Moneda) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.MonedaId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.MonedaId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Persona) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.PersonaId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.PersonaId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.PersonaRelacionada) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Proveedor) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ProveedorId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ProveedorId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ProveedorRelacionado) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.StockDeposito) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.StockDepositoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.StockDepositoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Sucursal) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.SucursalId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.SucursalId_NombreCol + ", " + AsientosAutoRelacionesService.StockDepositoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TextoPredefinido) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TipoNotaCredito) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TipoCliente) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TipoClienteId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.TipoClienteId_NombreCol + ", " + AsientosAutoRelacionesService.PersonaId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FuncionarioBonificacion) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.BonificacionId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.BonificacionId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FuncionarioDescuento) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.DescuentoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.DescuentoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Rubro) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.RubroId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.RubroId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ActivoRubro) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ActivoRubroId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ActivoRubroId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Impuesto) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ImpuestoId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.ImpuestoId_NombreCol;
            else if (preferencia1.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ProcesadoraTarjeta) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol]))
                orden1 = AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol;
            else
                orden1 = string.Empty;
            #endregion sql orden1

            #region sql orden2
            if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Articulo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloFamilia) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ArticuloFamiliaId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloGrupo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ArticuloGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ArticuloSubGrupo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ArticuloSubGrupoId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloId_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloUsado_NombreCol + ", " + AsientosAutoRelacionesService.ArticuloDanhado_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CanalDeVenta) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CanalDeVentaId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.CanalDeVentaId_NombreCol + ", " + AsientosAutoRelacionesService.CanalDeVentaId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtacteBancaria) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteBancariaId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.CtacteBancariaId_NombreCol + ", " + AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FondoFijo) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.CtacteFondoFijoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtaCteCajaTesoreria) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.CtacteCajaTesoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.CtacteValor) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteValorId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.CtacteValorId_NombreCol + ", " + AsientosAutoRelacionesService.CtacteBancariaId_NombreCol + ", " + AsientosAutoRelacionesService.CtacteChequeEstadoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Funcionario) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.FuncionarioId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.FuncionarioId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Moneda) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.MonedaId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.MonedaId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Persona) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.PersonaId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.PersonaId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.PersonaRelacionada) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.PersonaRelacionadaId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Proveedor) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ProveedorId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ProveedorId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ProveedorRelacionado) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ProveedorRelacionadoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.StockDeposito) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.StockDepositoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.StockDepositoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Sucursal) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.SucursalId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.SucursalId_NombreCol + ", " + AsientosAutoRelacionesService.StockDepositoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TextoPredefinido) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.TextoPredefinidoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TipoNotaCredito) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.TipoNotasCreditoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.TipoCliente) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.TipoClienteId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.TipoClienteId_NombreCol + ", " + AsientosAutoRelacionesService.PersonaId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FuncionarioBonificacion) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.BonificacionId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.BonificacionId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.FuncionarioDescuento) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.DescuentoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.DescuentoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Rubro) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.RubroId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.RubroId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ActivoRubro) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ActivoRubroId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ActivoRubroId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.Impuesto) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.ImpuestoId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.ImpuestoId_NombreCol;
            else if (preferencia2.Equals(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesColumnaPrioridad.ProcesadoraTarjeta) && !Interprete.EsNullODBNull(parametros[AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol]))
                orden2 = AsientosAutoRelacionesService.CtacteProcesadoraTarjetaId_NombreCol;
            else
                orden2 = string.Empty;
            #endregion sql orden2

            orden = string.Empty;
            if (orden1.Length > 0)
                orden = orden1;

            if (orden2.Length > 0)
            {
                if (orden1.Length > 0)
                    orden += ", ";

                orden += orden2;
            }

            DataTable dt = AsientosAutoRelacionesService.GetAsientosAutoRelacionesDataTable(clausulas, orden);
            DataTable dtResultado = dt.Clone();

            #region exclusiones e inclusiones
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool excluir = false;

                if (!excluir)
                {
                    AsientosAutoRelacionesService.Exclusion exclusiones = new AsientosAutoRelacionesService.Exclusion();
                    if (!Interprete.EsNullODBNull(dt.Rows[i][AsientosAutoRelacionesService.Exclusiones_NombreCol]))
                    {
                        AsientosAutoRelacionesService.Exclusion eTmp = JsonUtil.Deserializar<AsientosAutoRelacionesService.Exclusion>((string)dt.Rows[i][AsientosAutoRelacionesService.Exclusiones_NombreCol]);
                        exclusiones.Columnas.AddRange(eTmp.Columnas);
                    }

                    foreach (int columna in exclusiones.Columnas)
                    {
                        // Si se está recibiendo un campo x en [Hashtable parametros] que a su vez está especificado en la columna EXCLUSIONES, entonces ese row se ignora.
                        if (camposPresentes.Contains(columna))
                            excluir = true;

                        if (excluir)
                            break;
                    }
                }

                if (!excluir)
                {
                    AsientosAutoRelacionesService.Inclusion inclusiones = new AsientosAutoRelacionesService.Inclusion();

                    if (!Interprete.EsNullODBNull(dt.Rows[i][AsientosAutoRelacionesService.Inclusiones_NombreCol]))
                    {
                        AsientosAutoRelacionesService.Inclusion iTmp = JsonUtil.Deserializar<AsientosAutoRelacionesService.Inclusion>((string)dt.Rows[i][AsientosAutoRelacionesService.Inclusiones_NombreCol]);
                        inclusiones.Columnas.AddRange(iTmp.Columnas);
                    }

                    foreach (int columna in inclusiones.Columnas)
                    {
                        // Si no se está recibiendo un campo x en [Hashtable parametros] que a su vez está especificado en la columna INCLUSIONES, entonces ese row se ignora.
                        if (!camposPresentes.Contains(columna))
                            excluir = true;

                        if (excluir)
                            break;
                    }
                }

                if (!excluir)
                    dtResultado.Rows.Add(dt.Rows[i].ItemArray);
            }

            dt = dtResultado;
            #endregion exclusiones e inclusiones

            if (dt.Rows.Count > 0)
            {
                if (Interprete.EsNullODBNull(dt.Rows[0][AsientosAutoRelacionesService.CtbCuentaId_NombreCol]))
                    cuentaId = Definiciones.Error.Valor.EnteroPositivo;
                else
                    cuentaId = (decimal)dt.Rows[0][AsientosAutoRelacionesService.CtbCuentaId_NombreCol];
                invertir_debe_haber = (string)dt.Rows[0][AsientosAutoRelacionesService.InvertirDebeYHaber_NombreCol] == Definiciones.SiNo.Si;
                invertir_si_es_negativo = (string)dt.Rows[0][AsientosAutoRelacionesService.InvertirSiEsNegativo_NombreCol] == Definiciones.SiNo.Si;

                if (crear_asiento)
                    crear_asiento = (string)dt.Rows[0][AsientosAutoRelacionesService.CrearAsiento_NombreCol] == Definiciones.SiNo.Si;
            }

            return cuentaId;
        }

        #endregion GetCuentaAAsentar

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "CTB_ASIENTOS_AUTO_DET"; }
        }
        public static string CopiarObsCabeceraAsiento_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.COPIAR_OBS_CABECERA_ASIENTOColumnName; }
        }
        public static string ColumnaPrioritaria_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.COLUMNA_PRIORITARIAColumnName; }
        }
        public static string ColumnaPrioritaria2_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.COLUMNA_PRIORITARIA2ColumnName; }
        }
        public static string CentroCostoPrioridad_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.CENTRO_COSTO_PRIORIDADColumnName; }
        }
        public static string CentroCostoPrioridad2_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.CENTRO_COSTO_PRIORIDAD2ColumnName; }
        }
        public static string CentroCostoPrioridad3_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.CENTRO_COSTO_PRIORIDAD3ColumnName; }
        }
        public static string AsientoAutomaticoId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.CTB_ASIENTO_AUTOMATICO_IDColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.DESCRIPCIONColumnName; }
        }
        public static string EstructuraObservacion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.ESTRUCTURA_OBSERVACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.NOMBREColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.ORDENColumnName; }
        }
        public static string ResumirDetalles_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DETCollection.RESUMIR_DETALLESColumnName; }
        }
        public static string VistaCantidadCuentasRelacionadas_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DET_INFO_COMCollection.CANTIDAD_CUENTAS_RELACIONADASColumnName; }
        }
        public static string VistaRevisionPosterior_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DET_INFO_COMCollection.REVISION_POSTERIORColumnName; }
        }
        public static string VistaTransicionId_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DET_INFO_COMCollection.TRANSICION_IDColumnName; }
        }
        public static string VistaUsarFechaTransicion_NombreCol
        {
            get { return CTB_ASIENTOS_AUTO_DET_INFO_COMCollection.USAR_FECHA_TRANSICIONColumnName; }
        }
        #endregion Accesors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected CTB_ASIENTOS_AUTO_DETRow row;
        protected CTB_ASIENTOS_AUTO_DETRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal CTBAsientoAutomaticoId { get { return row.CTB_ASIENTO_AUTOMATICO_ID; } set { row.CTB_ASIENTO_AUTOMATICO_ID = value; } }
        public string Descripcion { get { return row.DESCRIPCION; } set { row.DESCRIPCION = value; } }
        public string EstructuraObservacion { get { return row.ESTRUCTURA_OBSERVACION; } set { row.ESTRUCTURA_OBSERVACION = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private AsientosAutomaticosService _CTBAsientoAutomatico;
        public AsientosAutomaticosService CTBAsientoAutomatico
        {
            get
            {
                if (this._CTBAsientoAutomatico == null)
                    this._CTBAsientoAutomatico = new AsientosAutomaticosService(this.CTBAsientoAutomaticoId);
                return this._CTBAsientoAutomatico;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_ASIENTOS_AUTO_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_ASIENTOS_AUTO_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public AsientosAutomaticosDetalleService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AsientosAutomaticosDetalleService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AsientosAutomaticosDetalleService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
