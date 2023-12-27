using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Herramientas
{
    public class VehiculosService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="vehiculo_id">The vehiculo_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal vehiculo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                VEHICULOSRow row = sesion.Db.VEHICULOSCollection.GetByPrimaryKey(vehiculo_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetVehiculosDataTable
        /// <summary>
        /// Gets the vehiculos data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetVehiculosDataTable()
        {
            return GetVehiculosDataTable(string.Empty, VehiculosService.Nombre_NombreCol);
        }

        /// <summary>
        /// Gets the vehiculos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetVehiculosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.VEHICULOSCollection.GetAsDataTable(clausulas, orden);
            }
        }

        #endregion GetVehiculosDataTable

        #region GetVehiculosInfoCompleta
        [Obsolete("Utilizar métodos estáticos")]
        /// <summary>
        /// Gets the vehiculos info completa.
        /// </summary>
        /// <returns></returns>
        public DataTable GetVehiculosInfoCompleta()
        {
            return GetVehiculosInfoCompleta(string.Empty, VehiculosService.Nombre_NombreCol);
        }
        /// <summary>
        /// Gets the vehiculos info completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVehiculosInfoCompleta2()
        {
            return GetVehiculosInfoCompleta2(string.Empty, VehiculosService.Nombre_NombreCol);
        }

        [Obsolete("Utilizar métodos estáticos")]
        /// <summary>
        /// Gets the vehiculos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetVehiculosInfoCompleta(string clausulas, string orden)
        {
            return GetVehiculosInfoCompleta(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the vehiculos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetVehiculosInfoCompleta2(string clausulas, string orden)
        {
            return GetVehiculosInfoCompleta2(clausulas, orden, false);
        }


        [Obsolete("Utilizar métodos estáticos")]
        /// <summary>
        /// Gets the vehiculos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="busquedaFlexible">if set to <c>true</c> [busqueda flexible].</param>
        /// <returns></returns>
        public static DataTable GetVehiculosInfoCompleta(string clausulas, string orden, bool busquedaFlexible)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                //Desactivar. Distinguir o no mayusculas, minusculas y tildes.
                if (busquedaFlexible) sesion.Db.IniciarBusquedaFlexible();

                dt = sesion.Db.VEHICULOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);

                //Reactivar. Distinguir o no mayusculas, minusculas y tildes.
                if (busquedaFlexible) sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }

        /// <summary>
        /// Gets the vehiculos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="busquedaFlexible">if set to <c>true</c> [busqueda flexible].</param>
        /// <returns></returns>
        public static DataTable GetVehiculosInfoCompleta2(string clausulas, string orden, bool busquedaFlexible)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                //Desactivar. Distinguir o no mayusculas, minusculas y tildes.
                if (busquedaFlexible) sesion.Db.IniciarBusquedaFlexible();

                dt = sesion.Db.VEHICULOS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);

                //Reactivar. Distinguir o no mayusculas, minusculas y tildes.
                if (busquedaFlexible) sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }
        #endregion GetVehiculosInfoCompleta

        #region GetVehiculosInfoCompletaFiltrado
        public static DataTable GetVehiculosInfoCompletaFiltrado(string p_texto, string condicion_adicional)
        {
            return GetVehiculosInfoCompletaFiltrado(p_texto, condicion_adicional, false);
        }

        public static DataTable GetVehiculosInfoCompletaFiltrado(string p_texto, string condicion_adicional, bool busqueda_flexible)
        {
            return GetVehiculosInfoCompletaFiltrado(p_texto, condicion_adicional, busqueda_flexible, true);
        }

        public static DataTable GetVehiculosInfoCompletaFiltrado(string p_texto, string condicion_adicional, bool busqueda_flexible, bool solo_activos)
        {
            decimal cantidadMinimaCaracteres = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.BusquedaCantidadMinimaCaracteres);
            if (p_texto.Trim().Length < cantidadMinimaCaracteres)
                throw new Exception("La cantidad mínima de carácteres de filtrado es " + cantidadMinimaCaracteres + ".");

            string txt = p_texto.Replace(' ', '%').ToUpper();

            string clausulas = "(" +
                               "     upper(" + VehiculosService.Nombre_NombreCol + ") like '%" + txt + "%' or " +
                               "     upper(" + VehiculosService.Matricula_NombreCol + ") like '%" + txt + "%' or " +
                               "     upper(" + VehiculosService.Chasis_Nro_NombreCol + ") like '%" + txt + "%'" +
                               ")";

            return GetVehiculosInfoCompleta2(clausulas, VehiculosService.Nombre_NombreCol, busqueda_flexible);

        }
        #endregion GetVehiculosInfoCompletaFiltrado

        #region GetVehiculoInfoCompletaPorId
        public static DataTable GetVehiculoInfoCompletaPorId (string id)
        {
            string txt = id.Replace(' ', '%').ToUpper();

            string clausulas = "(" +
                               "     upper(" + VehiculosService.Id_NombreCol + ") = '" + txt + "'" +
                               ")";

            return GetVehiculosInfoCompleta2(clausulas, VehiculosService.Nombre_NombreCol, false);
        }
        #endregion GetVehiculoInfoCompletaPorId

        #region GetFuncionarioChoferId
        /// <summary>
        /// Gets the funcionario chofer identifier.
        /// </summary>
        /// <param name="vechiculo_id">The vechiculo_id.</param>
        /// <returns></returns>
        public static decimal GetFuncionarioChoferId(decimal vechiculo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                VEHICULOSRow row = sesion.Db.VEHICULOSCollection.GetByPrimaryKey(vechiculo_id);
                return row.IsCHOFER_HABITUAL_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CHOFER_HABITUAL_ID;
            }
        }
        #endregion GetFuncionarioChoferId

        #region GetKilometrajeActual
        /// <summary>
        /// Gets the kilometraje actual.
        /// </summary>
        /// <param name="vechiculo_id">The vechiculo_id.</param>
        /// <returns></returns>
        public static decimal GetKilometrajeActual(decimal vechiculo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                VEHICULOSRow row = sesion.Db.VEHICULOSCollection.GetByPrimaryKey(vechiculo_id);
                return row.KILOMETRAJE_ACTUAL;
            }
        }
        #endregion GetKilometrajeActual

        #region GetNroCeldas
        public static decimal GetNroCeldas(decimal vehiculoId)
        {
            using (SessionService sesion = new SessionService())
            {
                VEHICULOSRow row = sesion.Db.VEHICULOSCollection.GetByPrimaryKey(vehiculoId);
                return row.IsNRO_CELDASNull ? 0 : row.NRO_CELDAS;
            }
        }
        #endregion GetNroCeldas

        #region SetKilometrajeActual
        /// <summary>
        /// Sets the kilometraje actual.
        /// </summary>
        /// <param name="vechiculo_id">The vechiculo_id.</param>
        /// <param name="kilometraje_actual">The kilometraje_actual.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetKilometrajeActual(decimal vechiculo_id, decimal kilometraje_actual, SessionService sesion)
        {
            VEHICULOSRow row = sesion.Db.VEHICULOSCollection.GetByPrimaryKey(vechiculo_id);
            row.KILOMETRAJE_ACTUAL = kilometraje_actual;
            sesion.db.VEHICULOSCollection.Update(row);
        }
        #endregion SetKilometrajeActual

       

       

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    VEHICULOSRow row = new VEHICULOSRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("vehiculos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.FECHA_INGRESO = DateTime.Now;
                    }
                    else
                    {
                        row = sesion.Db.VEHICULOSCollection.GetRow(VehiculosService.Id_NombreCol + " = " + campos[VehiculosService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (campos.Contains(VehiculosService.Anho_NombreCol))
                        row.ANHO = (decimal)campos[VehiculosService.Anho_NombreCol];
                    else
                        row.IsANHONull = true;

                    row.CHASIS_NRO = (string)campos[VehiculosService.Chasis_Nro_NombreCol];

                    if (campos.Contains(VehiculosService.CantidadDiasEntreMantenim_NombreCol))
                        row.CANTIDAD_DIAS_ENTRE_MANTENIM = (decimal)campos[VehiculosService.CantidadDiasEntreMantenim_NombreCol];
                    else
                        row.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull = true;

                    if (campos.Contains(VehiculosService.CantidadKmEntreMantenim_NombreCol))
                        row.CANTIDAD_KM_ENTRE_MANTENIM = (decimal)campos[VehiculosService.CantidadKmEntreMantenim_NombreCol];
                    else
                        row.IsCANTIDAD_KM_ENTRE_MANTENIMNull = true;

                    row.COLOR = (string)campos[VehiculosService.Color_NombreCol];

                    if (campos.Contains(VehiculosService.ConsumoEstimado_NombreCol))
                        row.CONSUMO_ESTIMADO = (decimal)campos[VehiculosService.ConsumoEstimado_NombreCol];
                    else
                        row.IsCONSUMO_ESTIMADONull = true;

                    if (row.ESTADO == null || !row.ESTADO.Equals((string)campos[VehiculosService.Estado_NombreCol]))
                    {
                        row.ESTADO = (string)campos[VehiculosService.Estado_NombreCol];

                        if (row.ESTADO.Equals(Definiciones.Estado.Activo))
                            row.IsFECHA_INACTIVADONull = true;
                        else
                            row.FECHA_INACTIVADO = DateTime.Now;
                    }

                    if (campos.Contains(VehiculosService.FechaUltimoMantenimiento_NombreCol))
                        row.FECHA_ULTIMO_MANTENIMIENTO = (DateTime)campos[VehiculosService.FechaUltimoMantenimiento_NombreCol];
                    else
                        row.IsFECHA_ULTIMO_MANTENIMIENTONull = true;

                    if (campos.Contains(VehiculosService.FechaVencimientoPatente_NombreCol))
                        row.FECHA_VENCIMIENTO_PATENTE = (DateTime)campos[VehiculosService.FechaVencimientoPatente_NombreCol];
                    else
                        row.IsFECHA_VENCIMIENTO_PATENTENull = true;

                    if (campos.Contains(VehiculosService.FechaVencimientoPoliza_NombreCol))
                        row.FECHA_VENCIMIENTO_POLIZA = (DateTime)campos[VehiculosService.FechaVencimientoPoliza_NombreCol];
                    else
                        row.IsFECHA_VENCIMIENTO_POLIZANull = true;

                    if (campos.Contains(VehiculosService.Nro_Celdas_NombreCol))
                        row.NRO_CELDAS = (decimal)campos[VehiculosService.Nro_Celdas_NombreCol];

                    row.KILOMETRAJE_ACTUAL = (decimal)campos[VehiculosService.KilometrajeActual_NombreCol];

                    if (campos.Contains(VehiculosService.SucursalId_NombreCol))
                    {
                        if (row.IsSUCURSAL_IDNull || !row.SUCURSAL_ID.Equals((decimal)campos[VehiculosService.SucursalId_NombreCol]))
                        {
                            if (SucursalesService.EstaActivo((decimal)campos[VehiculosService.SucursalId_NombreCol]))
                                row.SUCURSAL_ID = (decimal)campos[VehiculosService.SucursalId_NombreCol];
                            else
                                throw new Exception("La sucursal no se encuentra activa.");
                        }
                    }
                    else
                    {
                        row.IsSUCURSAL_IDNull = true;
                    }

                    if (campos.Contains(VehiculosService.ChoferHabitualId_NombreCol))
                        row.CHOFER_HABITUAL_ID = (decimal)campos[VehiculosService.ChoferHabitualId_NombreCol];
                    else
                        row.IsCHOFER_HABITUAL_IDNull = true;

                    row.KILOMETRAJE_INICIAL = (decimal)campos[VehiculosService.KilometrajeInicial_NombreCol];

                    if (campos.Contains(VehiculosService.KilometrajeUltimoMantenimien_NombreCol))
                        row.KILOMETRAJE_ULTIMO_MANTENIMIEN = (decimal)campos[VehiculosService.KilometrajeUltimoMantenimien_NombreCol];
                    else
                        row.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull = true;

                    row.MARCA = (string)campos[VehiculosService.Marca_NombreCol];
                    row.MATRICULA = (string)campos[VehiculosService.Matricula_NombreCol];
                    row.MODELO = (string)campos[VehiculosService.Modelo_NombreCol];

                    if (!campos[VehiculosService.Abreviatura_NombreCol].Equals(string.Empty))
                        row.ABREVIATURA = (string)campos[VehiculosService.Abreviatura_NombreCol];
                    else
                        row.ABREVIATURA = (string)campos[VehiculosService.Matricula_NombreCol]; 

                    if (!campos[VehiculosService.Nombre_NombreCol].Equals(string.Empty))
                        row.NOMBRE = (string)campos[VehiculosService.Nombre_NombreCol];
                    else
                        row.NOMBRE = (string)campos[VehiculosService.Matricula_NombreCol]; 

                    row.TIPO_COMBUSTIBLE = (string)campos[VehiculosService.TipoCombustible_NombreCol];
                    row.TIPO_VEHICULO_ID = (decimal)campos[VehiculosService.TipoVehiculoId_NombreCol];

                    if (campos.Contains(VehiculosService.ProveedorId_NombreCol))
                        row.PROVEEDOR_ID = (decimal)campos[VehiculosService.ProveedorId_NombreCol];
                    else
                        row.IsPROVEEDOR_IDNull = true;

                    if (campos.Contains(VehiculosService.PersonaId_NombreCol))
                        row.PERSONA_ID = (decimal)campos[VehiculosService.PersonaId_NombreCol];
                    else
                        row.IsPERSONA_IDNull = true;

                    if (insertarNuevo) sesion.Db.VEHICULOSCollection.Insert(row);
                    else sesion.Db.VEHICULOSCollection.Update(row);

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

        #region GetVehiculoEdiPorId
        public static EdiCBA.Vehiculo GetVehiculoEdiPorId(decimal id)
        {
            var dtVehiculo = GetVehiculoInfoCompletaPorId(id.ToString());

            if (dtVehiculo.Rows.Count <= 0)
                    throw new Exception("No se encontraron resultados.");
 
            EdiCBA.Vehiculo vehiculo = new EdiCBA.Vehiculo();

            vehiculo.Id = (decimal)dtVehiculo.Rows[0][Id_NombreCol];
            vehiculo.Tipo_Vehiculo_Id = (decimal)dtVehiculo.Rows[0][TipoVehiculoId_NombreCol];
            
            if(!Interprete.EsNullODBNull(dtVehiculo.Rows[0][SucursalId_NombreCol]))
                vehiculo.Sucursal_Id = (decimal)dtVehiculo.Rows[0][SucursalId_NombreCol];
            
            vehiculo.Nombre = (string)dtVehiculo.Rows[0][Nombre_NombreCol];
            vehiculo.Abreviatura = (string)dtVehiculo.Rows[0][Abreviatura_NombreCol];
            vehiculo.Matricula = (string)dtVehiculo.Rows[0][Matricula_NombreCol];

            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][Marca_NombreCol]))
                vehiculo.Marca = (string)dtVehiculo.Rows[0][Marca_NombreCol];

            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][Modelo_NombreCol]))
                vehiculo.Modelo = (string)dtVehiculo.Rows[0][Modelo_NombreCol];

            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][Anho_NombreCol]))
                vehiculo.Anho = (decimal)dtVehiculo.Rows[0][Anho_NombreCol];
            
            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][Color_NombreCol]))
                vehiculo.Color = (string)dtVehiculo.Rows[0][Color_NombreCol];

            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][ConsumoEstimado_NombreCol]))
                vehiculo.Consumo_Estimado = (decimal)dtVehiculo.Rows[0][ConsumoEstimado_NombreCol];

            vehiculo.Kilometraje_Inicial = (decimal)dtVehiculo.Rows[0][KilometrajeInicial_NombreCol];
            vehiculo.Kilometraje_Actual = (decimal)dtVehiculo.Rows[0][KilometrajeActual_NombreCol];

            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][TipoCombustible_NombreCol]))
                vehiculo.Tipo_Combustible = dtVehiculo.Rows[0][TipoCombustible_NombreCol].ToString();

            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][CantidadKmEntreMantenim_NombreCol]))
                vehiculo.Cantidad_Km_Entre_Mantenim = (decimal)dtVehiculo.Rows[0][CantidadKmEntreMantenim_NombreCol];

            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][CantidadDiasEntreMantenim_NombreCol]))
                vehiculo.Cantidad_Dias_Entre_Mantenim = (decimal)dtVehiculo.Rows[0][CantidadDiasEntreMantenim_NombreCol];
            if (!Interprete.EsNullODBNull(dtVehiculo.Rows[0][KilometrajeUltimoMantenimien_NombreCol]))
                vehiculo.Kilometraje_Ultimo_Mantenimien = (decimal)dtVehiculo.Rows[0][KilometrajeUltimoMantenimien_NombreCol];

            return vehiculo;
        
        }

        #endregion

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "VEHICULOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "VEHICULOS_INFO_COMPLETA"; }
        }
        public static string Abreviatura_NombreCol
        {
            get { return VEHICULOSCollection.ABREVIATURAColumnName; }
        }
        public static string Anho_NombreCol
        {
            get { return VEHICULOSCollection.ANHOColumnName; }
        }
        public static string CantidadDiasEntreMantenim_NombreCol
        {
            get { return VEHICULOSCollection.CANTIDAD_DIAS_ENTRE_MANTENIMColumnName; }
        }
        public static string CantidadKmEntreMantenim_NombreCol
        {
            get { return VEHICULOSCollection.CANTIDAD_KM_ENTRE_MANTENIMColumnName; }
        }
        public static string Chasis_Nro_NombreCol
        {
            get { return VEHICULOSCollection.CHASIS_NROColumnName; }
        }
        public static string ChoferHabitualId_NombreCol
        {
            get { return VEHICULOSCollection.CHOFER_HABITUAL_IDColumnName; }
        }
        public static string Color_NombreCol
        {
            get { return VEHICULOSCollection.COLORColumnName; }
        }
        public static string ConsumoEstimado_NombreCol
        {
            get { return VEHICULOSCollection.CONSUMO_ESTIMADOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return VEHICULOSCollection.ESTADOColumnName; }
        }
        public static string FechaInactivado_NombreCol
        {
            get { return VEHICULOSCollection.FECHA_INACTIVADOColumnName; }
        }
        public static string FechaIngreso_NombreCol
        {
            get { return VEHICULOSCollection.FECHA_INGRESOColumnName; }
        }
        public static string FechaUltimoMantenimiento_NombreCol
        {
            get { return VEHICULOSCollection.FECHA_ULTIMO_MANTENIMIENTOColumnName; }
        }
        public static string FechaVencimientoPatente_NombreCol
        {
            get { return VEHICULOSCollection.FECHA_VENCIMIENTO_PATENTEColumnName; }
        }
        public static string FechaVencimientoPoliza_NombreCol
        {
            get { return VEHICULOSCollection.FECHA_VENCIMIENTO_POLIZAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return VEHICULOSCollection.IDColumnName; }
        }
        public static string KilometrajeActual_NombreCol
        {
            get { return VEHICULOSCollection.KILOMETRAJE_ACTUALColumnName; }
        }
        public static string KilometrajeInicial_NombreCol
        {
            get { return VEHICULOSCollection.KILOMETRAJE_INICIALColumnName; }
        }
        public static string KilometrajeUltimoMantenimien_NombreCol
        {
            get { return VEHICULOSCollection.KILOMETRAJE_ULTIMO_MANTENIMIENColumnName; }
        }
        public static string Marca_NombreCol
        {
            get { return VEHICULOSCollection.MARCAColumnName; }
        }
        public static string Matricula_NombreCol
        {
            get { return VEHICULOSCollection.MATRICULAColumnName; }
        }
        public static string Modelo_NombreCol
        {
            get { return VEHICULOSCollection.MODELOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return VEHICULOSCollection.NOMBREColumnName; }
        }
        public static string Nro_Celdas_NombreCol
        {
            get { return VEHICULOSCollection.NRO_CELDASColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return VEHICULOSCollection.PROVEEDOR_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return VEHICULOSCollection.PERSONA_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return VEHICULOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TipoCombustible_NombreCol
        {
            get { return VEHICULOSCollection.TIPO_COMBUSTIBLEColumnName; }
        }
        public static string TipoVehiculoId_NombreCol
        {
            get { return VEHICULOSCollection.TIPO_VEHICULO_IDColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return VEHICULOS_INFO_COMPLETACollection.RAZON_SOCIALColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return VEHICULOS_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return VEHICULOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaTipoVehiculoNombre_NombreCol
        {
            get { return VEHICULOS_INFO_COMPLETACollection.TIPO_VEHICULO_NOMBREColumnName; }
        }
        #endregion Metodos estaticos

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        
        #region Propiedades
        protected VEHICULOSRow row;
        protected VEHICULOSRow rowSinModificar;
        public class Modelo : VEHICULOSCollection_Base { public Modelo() : base(null) { } }

        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal Id { get { return row.ID; } set { row.ID = value; } }
        public decimal Tipo_Vehiculo_Id { get { return row.TIPO_VEHICULO_ID; } set { row.TIPO_VEHICULO_ID = value; } }
        public decimal? Sucursal_Id { get { if (row.IsSUCURSAL_IDNull) return null; else return row.SUCURSAL_ID; } set { if (value.HasValue) row.SUCURSAL_ID = value.Value; else row.IsSUCURSAL_IDNull = true; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string Abreviatura { get { return row.ABREVIATURA; } set { row.ABREVIATURA = value; } }
        public string Matricula { get { return row.MATRICULA; } set { row.MATRICULA = value; } }
        public string Marca { get { return ClaseCBABase.GetStringHelper(row.MARCA); } set { row.MARCA = value; } }
        public string modelo { get { return ClaseCBABase.GetStringHelper(row.MODELO); } set { row.MODELO = value; } }
        public decimal? Anho { get { if (row.IsANHONull) return null; else return row.ANHO; } set { if (value.HasValue) row.ANHO = value.Value; else row.IsANHONull = true; } }
        public string Color { get { return ClaseCBABase.GetStringHelper(row.COLOR); } set { row.COLOR = value; } }
        public decimal? Consumo_Estimado { get { if (row.IsCONSUMO_ESTIMADONull) return null; else return row.CONSUMO_ESTIMADO; } set { if (value.HasValue) row.CONSUMO_ESTIMADO = value.Value; else row.IsCONSUMO_ESTIMADONull = true; } }
        public decimal Kilometraje_Inicial { get { return row.KILOMETRAJE_INICIAL; } set { row.KILOMETRAJE_INICIAL = value; } }
        public decimal Kilometraje_Actual { get { return row.KILOMETRAJE_ACTUAL; } set { row.KILOMETRAJE_ACTUAL = value; } }
        public string Tipo_Combustible { get { return ClaseCBABase.GetStringHelper(row.TIPO_COMBUSTIBLE); } set { row.TIPO_COMBUSTIBLE = value; } }
        public decimal? Cantidad_Km_Entre_Mantenim { get { if (row.IsCANTIDAD_KM_ENTRE_MANTENIMNull) return null; else return row.CANTIDAD_KM_ENTRE_MANTENIM; } set { if (value.HasValue) row.CANTIDAD_KM_ENTRE_MANTENIM = value.Value; else row.IsCANTIDAD_KM_ENTRE_MANTENIMNull = true; } }
        public decimal? Cantidad_Dias_Entre_Mantenim { get { if (row.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull) return null; else return row.CANTIDAD_DIAS_ENTRE_MANTENIM; } set { if (value.HasValue) row.CANTIDAD_DIAS_ENTRE_MANTENIM = value.Value; else row.IsCANTIDAD_DIAS_ENTRE_MANTENIMNull = true; } }
        public decimal? Kilometraje_Ultimo_Mantenimien { get { if (row.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull) return null; else return row.KILOMETRAJE_ULTIMO_MANTENIMIEN; } set { if (value.HasValue) row.KILOMETRAJE_ULTIMO_MANTENIMIEN = value.Value; else row.IsKILOMETRAJE_ULTIMO_MANTENIMIENNull = true; } }
        public DateTime? Fecha_Ultimo_Mantenimiento { get { if (row.IsFECHA_ULTIMO_MANTENIMIENTONull) return null; else return row.FECHA_ULTIMO_MANTENIMIENTO; } set { if (value.HasValue) row.FECHA_ULTIMO_MANTENIMIENTO = value.Value; else row.IsFECHA_ULTIMO_MANTENIMIENTONull = true; } }
        public DateTime? Fecha_Vencimiento_Poliza { get { if (row.IsFECHA_VENCIMIENTO_POLIZANull) return null; else return row.FECHA_VENCIMIENTO_POLIZA; } set { if (value.HasValue) row.FECHA_VENCIMIENTO_POLIZA = value.Value; else row.IsFECHA_VENCIMIENTO_POLIZANull = true; } }
        public DateTime? Fecha_Vencimiento_Patente { get { if (row.IsFECHA_VENCIMIENTO_PATENTENull) return null; else return row.FECHA_VENCIMIENTO_PATENTE; } set { if (value.HasValue) row.FECHA_VENCIMIENTO_PATENTE = value.Value; else row.IsFECHA_VENCIMIENTO_PATENTENull = true; } }
        public DateTime? Fecha_Ingreso { get { if (row.IsFECHA_INGRESONull) return null; else return row.FECHA_INGRESO; } set { if (value.HasValue) row.FECHA_INGRESO = value.Value; else row.IsFECHA_INGRESONull = true; } }
        public DateTime? Fecha_Inactivado { get { if (row.IsFECHA_INACTIVADONull) return null; else return row.FECHA_INACTIVADO; } set { if (value.HasValue) row.FECHA_INACTIVADO = value.Value; else row.IsFECHA_INACTIVADONull = true; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Chofer_Habitual_Id { get { if (row.IsCHOFER_HABITUAL_IDNull) return null; else return row.CHOFER_HABITUAL_ID; } set { if (value.HasValue) row.CHOFER_HABITUAL_ID = value.Value; else row.IsCHOFER_HABITUAL_IDNull = true; } }
        public string Chasis_Nro { get { return ClaseCBABase.GetStringHelper(row.CHASIS_NRO); } set { row.CHASIS_NRO = value; } }
        public decimal? Proveedor_Id { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) row.PROVEEDOR_ID = value.Value; else row.IsPROVEEDOR_IDNull = true; } }
        public decimal? Persona_Id { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID;} set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true;}}
        #endregion Propiedades
 
        #region Propiedades Extendidas

        #region Sucursal
        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.Id);
                return this._sucursal;
            }
        }
        #endregion Sucursal

        #region Chofer
        private FuncionariosService _chofer;
        public FuncionariosService Chofer
        {
            get
            {
                if (this._chofer == null)
                    this._chofer = new FuncionariosService(this.Id);
                return this._chofer;
            }
        }
        #endregion Chofer

        #region Proveedor
        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                    this._proveedor = new ProveedoresService(this.Id);
                return this._proveedor;
            }
        }
        #endregion Proveedor

        #region Persona
        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                    this._persona = new PersonasService(this.Id);
                return this._persona;
            }
        }
        #endregion Persona

        #region Tipo Vehiculo
        /*
        private TiposVehiculoService _tipo_vehiculo;
        public TiposVehiculoService Tipo_Vehiculo
        {
            get
            {
                if (this._tipo_vehiculo == null)
                                           //No existe actualmente para TiposVehiculosService
                    this._tipo_vehiculo = new TiposVehiculoService(this.Id);
                return this._tipo_vehiculo;
            }
        }
        */
        #endregion Tipo Vehiculo

        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.VEHICULOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new VEHICULOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public VehiculosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public VehiculosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public VehiculosService(decimal id) 
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
