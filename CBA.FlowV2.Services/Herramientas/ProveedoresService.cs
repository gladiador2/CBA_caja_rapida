using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Common;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Herramientas
{
    public class ProveedoresService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PROVEEDORESRow row = sesion.Db.PROVEEDORESCollection.GetRow(ProveedoresService.Id_NombreCol + " = " + proveedor_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EsNacional
        /// <summary>
        /// Eses the nacional.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public static bool EsNacional(decimal proveedor_id, SessionService sesion)
        {
            PROVEEDORESRow row = sesion.Db.PROVEEDORESCollection.GetRow(ProveedoresService.Id_NombreCol + " = " + proveedor_id);
            return row.ES_NACIONAL == Definiciones.SiNo.Si;
        }
        #endregion EsNacional

        #region EsPasibleRetencion
        /// <summary>
        /// Eses the pasible retencion.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public static bool EsPasibleRetencion(decimal proveedor_id, DateTime fecha_factura)
        {
            using (SessionService sesion = new SessionService())
            {
                PROVEEDORESRow row = sesion.Db.PROVEEDORESCollection.GetRow(ProveedoresService.Id_NombreCol + " = " + proveedor_id);

                if (row.PASIBLE_RETENCION == Definiciones.SiNo.No)
                {
                    if (row.FECHA_DESDE_NO_RETENER <= fecha_factura && row.FECHA_HASTA_NO_RETENER >= fecha_factura)
                        return false;
                    else
                        return true;
                }
                else
                    return true;

                //return row.PASIBLE_RETENCION == Definiciones.SiNo.Si;
            }
        }
        #endregion EsPasibleRetencion

        #region GetPersonaIdPorProveedorId
        public static decimal GetPersonaIdPorProveedorId(decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPersonaIdPorProveedorId(proveedor_id, sesion);
            }
        }
        public static decimal GetPersonaIdPorProveedorId(decimal proveedor_id, SessionService sesion)
        {
            if (sesion.Db.PROVEEDORESCollection.GetByPrimaryKey(proveedor_id).IsPERSONA_IDNull)
                return Definiciones.Error.Valor.EnteroPositivo;
            else
                return sesion.Db.PROVEEDORESCollection.GetByPrimaryKey(proveedor_id).PERSONA_ID;

        }
        #endregion GetPersonaIdPorProveedorId
        
        #region GetRazonSocial
        public static string GetRazonSocial(decimal proveedor_id, SessionService sesion) {
            return sesion.Db.PROVEEDORESCollection.GetByPrimaryKey(proveedor_id).RAZON_SOCIAL;
        }

        public static string GetRazonSocial(decimal proveedor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetRazonSocial(proveedor_id, sesion);
            }
        }

        #endregion GetRazonSocial

        #region GetCentroCosto
        public static decimal GetCentroCosto(decimal proveedor_id, SessionService sesion)
        {
            PROVEEDORESRow row = sesion.Db.PROVEEDORESCollection.GetByPrimaryKey(proveedor_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        #endregion GetCentroCosto

        #region GetProveedoresDataTable
        /// <summary>
        /// Gets the proveedores data table ordenado por razon social y nombre fantasia
        /// </summary>
        /// <param name="soloActivos">Si es true se obtienen solo los proveedores activos.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetProveedoresDataTable(bool soloActivos)
        {
            return GetProveedoresDataTable(string.Empty, string.Empty, true);
        }

        /// <summary>
        /// Gets the proveedores data table.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetProveedoresDataTable()
        {
            return GetProveedoresDataTable(false);
        }

        /// <summary>
        /// Gets the proveedores data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los proveedores activos.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetProveedoresDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ProveedoresService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;
                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                return sesion.Db.PROVEEDORESCollection.GetAsDataTable(where, orden);
            }
        }

        public static DataTable GetProveedoresDataTable2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetProveedoresDataTable2(clausulas, orden, soloActivos, sesion);
            }
        }

        public static DataTable GetProveedoresDataTable2(string clausulas, string orden, bool soloActivos, SessionService sesion)
        {
            string where = ProveedoresService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;
            if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            return sesion.Db.PROVEEDORESCollection.GetAsDataTable(where, orden);
        }
        #endregion GetProveedoresDataTable

        #region GetProveedoresInfoCompleta
        /// <summary>
        /// Gets the proveedores info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetProveedoresInfoCompleta(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = ProveedoresService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if(clausulas.Length > 0) where += " and " + clausulas;
                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                return sesion.Db.PROVEEDORES_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }

        public static DataTable GetProveedoresInfoCompleta2(string clausulas, string orden, bool soloActivos)
        {
            return GetProveedoresInfoCompleta2(clausulas, orden, soloActivos, false);
        }

        public static DataTable GetProveedoresInfoCompleta2(string clausulas, string orden, bool soloActivos, bool busqueda_flexible)
        {
            using (SessionService sesion = new SessionService())
            {
                if (busqueda_flexible)
                    sesion.db.IniciarBusquedaFlexible();

                string where = ProveedoresService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;
                if (soloActivos) where += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                DataTable dt = sesion.Db.PROVEEDORES_INFO_COMPLETACollection.GetAsDataTable(where, orden);

                if (busqueda_flexible)
                    sesion.db.FinalizarBusquedaFlexible();

                return dt;
            }
        }
        #endregion GetProveedoresInfoCompleta

        #region GetProveedor
        /// <summary>
        /// Gets an specific proveedor.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizar metodos estaticos")]
        public DataTable GetProveedor(decimal proveedor_id)
        {
            return GetProveedoresDataTable(ProveedoresService.Id_NombreCol + " = " + proveedor_id, string.Empty, false);
        }
        public static DataTable GetProveedor2(decimal proveedor_id)
        {
            return GetProveedoresDataTable2(ProveedoresService.Id_NombreCol + " = " + proveedor_id, string.Empty, false);
        }
        #endregion GetProveedor

        #region GetProveedorId
        public static decimal GetProveedorIdPorNroDocumento(string ruc)
        {
            DataTable dtProveedores = ProveedoresService.GetProveedoresDataTable2(ProveedoresService.Ruc_NombreCol + " = " + ruc, string.Empty, false);
            decimal proveedorId = Definiciones.Error.Valor.EnteroPositivo;
            if (dtProveedores.Rows.Count > 0)
                proveedorId = (decimal)(dtProveedores).Rows[0][Id_NombreCol];
            return proveedorId;
        }
        public static decimal GetProveedorIdPorCodigo(string codigo)
        {
            DataTable dtProveedores = ProveedoresService.GetProveedoresDataTable2(ProveedoresService.Codigo_NombreCol + " = " + codigo, string.Empty, false);
            decimal proveedorId = Definiciones.Error.Valor.EnteroPositivo;
            if (dtProveedores.Rows.Count > 0)
                proveedorId = (decimal)(dtProveedores).Rows[0][Id_NombreCol];
            return proveedorId;
        }
        #endregion GetProveedorId

        #region GetProveedoresInfoCompletaFiltrado
        public static DataTable GetProveedoresInfoCompletaFiltrado(string texto)
        {
            return GetProveedoresInfoCompletaFiltrado(texto, false, false);
        }

        public static DataTable GetProveedoresInfoCompletaFiltrado(string texto, bool solo_activos)
        { 
            return GetProveedoresInfoCompletaFiltrado(texto, solo_activos, false);
        }

        /// <summary>
        /// Gets the proveedores info completa filtrado.
        /// </summary>
        /// <param name="texto">The texto.</param>
        /// <returns></returns>
        public static DataTable GetProveedoresInfoCompletaFiltrado(string texto, bool solo_activos, bool busqueda_flexible)
        {
            string filtro = string.Empty;
            string txt = texto.Replace(' ', '%').ToUpper();

            decimal cantidadMinimaCaracteres = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.BusquedaCantidadMinimaCaracteres);
            //Verificamos si se ingreso una cadena válida.
            if (texto.Trim().Length >= cantidadMinimaCaracteres)
            {
                filtro = "     upper(" + ProveedoresService.NombreFantasia_NombreCol + ") like '%" + txt + "%' " +
                          " or upper(" + ProveedoresService.RazonSocial_NombreCol + ") like '%" + txt + "%' " +
                          " or upper(" + ProveedoresService.Ruc_NombreCol + ") like '%" + txt + "%' " +
                          " or upper(" + ProveedoresService.Codigo_NombreCol + ") like '%" + txt + "%' ";

                if (solo_activos)
                    filtro += " and " + ProveedoresService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                return ProveedoresService.GetProveedoresInfoCompleta2(filtro, ProveedoresService.RazonSocial_NombreCol, true, busqueda_flexible);
            }
            else
            {
                throw new Exception("La cantidad mínima de carácteres de filtrado es " + cantidadMinimaCaracteres + ".");
            }
        }
        #endregion GetProveedoresInfoCompletaFiltrado

        #region GetProveedoresInfoCompletaFiltradoPorId
        /// <summary>
        /// Gets the proveedores info completa filtrado por id.
        /// </summary>
        /// <param name="proveedor_id">The proveedor_id.</param>
        /// <returns></returns>
        public static DataTable GetProveedoresInfoCompletaFiltradoPorId(decimal proveedor_id)
        {
            return ProveedoresService.GetProveedoresInfoCompleta2(ProveedoresService.Id_NombreCol + " = " + proveedor_id, string.Empty, false);
        }
        #endregion GetProveedoresInfoCompletaFiltradoPorId
        
        #region Crear
        public static decimal Crear(string razon_social, string ruc, string codigo)
        {
            try
            {
                System.Collections.Hashtable campos = new System.Collections.Hashtable();

                campos.Add(ProveedoresService.Codigo_NombreCol, codigo);
                campos.Add(ProveedoresService.RazonSocial_NombreCol, razon_social);
                campos.Add(ProveedoresService.NombreFantasia_NombreCol, razon_social);
                campos.Add(ProveedoresService.Ruc_NombreCol, ruc);
                campos.Add(ProveedoresService.ContactoPersona_NombreCol, string.Empty);
                campos.Add(ProveedoresService.ContactoTelefono_NombreCol, string.Empty);
                campos.Add(ProveedoresService.ContactoEmail_NombreCol, string.Empty);
                campos.Add(ProveedoresService.PasibleRetencion_NombreCol, Definiciones.SiNo.Si);
                campos.Add(ProveedoresService.Estado_NombreCol, Definiciones.Estado.Activo);
                campos.Add(ProveedoresService.IngresoAprobado_NombreCol, Definiciones.SiNo.No);
                campos.Add(ProveedoresService.SolicitaReferencia_NombreCol, Definiciones.SiNo.Si);
                campos.Add(ProveedoresService.PaisId_NombreCol, Definiciones.Paises.Paraguay);
                campos.Add(ProveedoresService.Calle1_NombreCol, string.Empty);
                campos.Add(ProveedoresService.CodigoPostal1_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Calle2_NombreCol, string.Empty);
                campos.Add(ProveedoresService.CodigoPostal2_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Telefono1_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Telefono2_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Telefono3_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Telefono4_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Email1_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Email2_NombreCol, string.Empty);
                campos.Add(ProveedoresService.Email3_NombreCol, string.Empty);
                campos.Add(ProveedoresService.EsNacional_NombreCol, Definiciones.SiNo.Si);
                campos.Add(ProveedoresService.OperaCredito_NombreCol, Definiciones.SiNo.Si);
                
                return new ProveedoresService().Guardar(campos, true);
            }
            catch
            {
                throw;
            }
        }
        #endregion Crear

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo) {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PROVEEDORESRow proveedor = new PROVEEDORESRow();
                    string valorAnterior = string.Empty;
                    Decimal dAux;

                    if (insertarNuevo){
                        proveedor.ID = sesion.Db.GetSiguienteSecuencia("proveedores_sqc");
                        proveedor.ENTIDAD_ID = sesion.Entidad.ID;
                        proveedor.INGRESO_APROBADO = Definiciones.SiNo.No;
                        proveedor.BANDERA_RETENCION = Definiciones.SiNo.No;
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        #region Control de Codigo
                        if (campos.Contains(Codigo_NombreCol) && (string)campos[Codigo_NombreCol] != string.Empty)
                        {
                            proveedor.CODIGO = (string)campos[Codigo_NombreCol];
                        }
                        else
                        {
                            DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorTabla2(Nombre_Tabla);
                            if (dtAutonumeracion.Rows.Count >= 1)
                                proveedor.CODIGO = AutonumeracionesService.GetSiguienteNumero2((decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                            else
                                throw new Exception("No existe una autonumeración para los códigos de proveedor.");
                        }

                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ProveedoresControlarUnicidadCodigo) == Definiciones.SiNo.Si)
                        {
                            DataTable dtCodigo = ProveedoresService.GetProveedoresDataTable2(ProveedoresService.Codigo_NombreCol + " = '" + proveedor.CODIGO + "'", string.Empty, false);
                            if (dtCodigo.Rows.Count > 0)
                                throw new Exception("Ya existe el Código");
                        }
                        #endregion Control de Codigo
                    }
                    else
                    {
                        proveedor = sesion.Db.PROVEEDORESCollection.GetRow(Id_NombreCol+" = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = proveedor.ToString();
                    }

                    #region Control de Codigo

                    if (campos.Contains(Codigo_NombreCol) && (string)campos[Codigo_NombreCol] != string.Empty)
                    {
                        proveedor.CODIGO = (string)campos[Codigo_NombreCol];
                    }
                    else
                    {
                        if (proveedor.CODIGO == null)
                            proveedor.CODIGO = string.Empty;
                        
                        if (proveedor.CODIGO == string.Empty)
                        {
                            DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorTabla2(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, sesion);
                            if (dtAutonumeracion.Rows.Count >= 1)
                                proveedor.CODIGO = AutonumeracionesService.GetSiguienteNumero2((decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                            else
                                throw new Exception("No existe una autonumeración para los códigos de proveedor.");
                        }
                    }

                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ProveedoresControlarUnicidadCodigo) == Definiciones.SiNo.Si)
                    {
                        string where = ProveedoresService.Codigo_NombreCol + " = '" + proveedor.CODIGO + "' and " + ProveedoresService.Id_NombreCol + " <> " + proveedor.ID;
                        DataTable dtCodigo2 = ProveedoresService.GetProveedoresDataTable2(where, string.Empty, false);
                        if (dtCodigo2.Rows.Count > 0)
                            throw new Exception("Ya existe el Código");
                    }
                    #endregion Control de Codigo

                    proveedor.RAZON_SOCIAL = (string)campos[RazonSocial_NombreCol];
                    proveedor.NOMBRE_FANTASIA = (string)campos[NombreFantasia_NombreCol];
                    proveedor.ES_CONTRIBUYENTE = (string)campos[EsContribuyente_NombreCol];
                    if (campos.Contains(RubroId_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[RubroId_NombreCol]);
                        if (proveedor.IsRUBRO_IDNull || proveedor.RUBRO_ID != dAux)
                        {
                            if (RubrosService.EstaActivo(dAux)) proveedor.RUBRO_ID = dAux;
                            else throw new System.ArgumentException("El rubro seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsRUBRO_IDNull = true;
                    }

                    proveedor.RUC = ((string)campos[Ruc_NombreCol]).Trim();
                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.VerificarUnicidadRUC).Equals(Definiciones.SiNo.Si))
                    {
                        DataTable dt = ProveedoresService.GetProveedoresDataTable2(ProveedoresService.Ruc_NombreCol + " = '" + proveedor.RUC + "' and " + ProveedoresService.Id_NombreCol + " <> " + proveedor.ID, string.Empty, false, sesion);
                        if (dt.Rows.Count > 0)
                            throw new Exception("Ya existe un proveedor con el mismo número RUC.");
                    }
                    
                    if (campos.Contains(Codigo_NombreCol))
                    {
                        proveedor.CODIGO = ((string)campos[Codigo_NombreCol]).Trim();
                        string clausula = ProveedoresService.Codigo_NombreCol + " = '" + proveedor.CODIGO + "' ";
                        if (!insertarNuevo)
                            clausula += " and " + ProveedoresService.Id_NombreCol + " <> " + proveedor.ID + " ";
                        DataTable dt = ProveedoresService.GetProveedoresDataTable2(clausula, string.Empty, false, sesion);
                        if (dt.Rows.Count > 0)
                            throw new Exception("Ya existe un proveedor con el mismo CODIGO.");
                    }
                    if (campos.Contains(FechaFundacion_NombreCol)) proveedor.FECHA_FUNDACION = DateTime.Parse((string)campos[FechaFundacion_NombreCol]);
                    else proveedor.IsFECHA_FUNDACIONNull = true;
                    
                    if (campos.Contains(CentroCostoId_NombreCol)) proveedor.CENTRO_COSTO_ID = (decimal)campos[CentroCostoId_NombreCol];
                    else proveedor.IsCENTRO_COSTO_IDNull = true;
                    
                    proveedor.CONTACTO_PERSONA = (string)campos[ContactoPersona_NombreCol];
                    proveedor.CONTACTO_TELEFONO = (string)campos[ContactoTelefono_NombreCol];
                    proveedor.CONTACTO_EMAIL = (string)campos[ContactoEmail_NombreCol];
                    proveedor.PASIBLE_RETENCION = (string)campos[PasibleRetencion_NombreCol];
                    proveedor.ESTADO = (string)campos[Estado_NombreCol];
                    proveedor.SOLICITA_REFERENCIA = (string)campos[SolicitaReferencia_NombreCol];

                    if (campos[FechaDesdeNoRetencion_NombreCol] != string.Empty)
                        proveedor.FECHA_DESDE_NO_RETENER = DateTime.Parse(campos[FechaDesdeNoRetencion_NombreCol].ToString());
                    else
                        proveedor.IsFECHA_DESDE_NO_RETENERNull = true;

                    if (campos[FechaHastaNoRetencion_NombreCol] != string.Empty)
                        proveedor.FECHA_HASTA_NO_RETENER = DateTime.Parse(campos[FechaHastaNoRetencion_NombreCol].ToString());
                    else
                        proveedor.IsFECHA_HASTA_NO_RETENERNull = true;

                    if (campos.Contains(PersonaId_NombreCol))
                        proveedor.PERSONA_ID = (decimal)campos[PersonaId_NombreCol];

                    if (campos.Contains(FcObservacionDetalle_NombreCol))
                        proveedor.FC_OBSERVACION_DETALLE = (string)campos[FcObservacionDetalle_NombreCol];

                    if (proveedor.INGRESO_APROBADO != (string)campos[IngresoAprobado_NombreCol])
                    {
                        if ((string)campos[IngresoAprobado_NombreCol] == Definiciones.SiNo.Si)
                        {//Se aprobo el ingreso del proveedor
                            proveedor.FECHA_APROBACION = DateTime.Now;
                            proveedor.USUARIO_APROBACION_ID = sesion.Usuario.ID;
                            proveedor.INGRESO_APROBADO = (string)campos[IngresoAprobado_NombreCol];
                        }
                        else
                        {
                            throw new ArgumentException("No puede desaprobarse el ingreso de un cliente aprobado previamente.");
                        }
                    }

                    dAux = Decimal.Parse(campos[PaisId_NombreCol].ToString());
                    if (proveedor.PAIS_ID != dAux)
                    {
                        if (PaisesService.EstaActivo(dAux)) proveedor.PAIS_ID = dAux;
                        else throw new System.ArgumentException("El país seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    if (campos.Contains(Departamento1Id_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[Departamento1Id_NombreCol]);
                        if (proveedor.IsDEPARTAMENTO1_IDNull || proveedor.DEPARTAMENTO1_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux)) proveedor.DEPARTAMENTO1_ID = dAux;
                            else throw new System.ArgumentException("El departamento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsDEPARTAMENTO1_IDNull = true;
                    }

                    if (campos.Contains(Ciudad1Id_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[Ciudad1Id_NombreCol]);
                        if (proveedor.IsCIUDAD1_IDNull || proveedor.CIUDAD1_ID != dAux)
                        {
                            if (CiudadesService.EstaActivo(dAux)) proveedor.CIUDAD1_ID = dAux;
                            else throw new System.ArgumentException("La ciudad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsCIUDAD1_IDNull = true;
                    }

                    if (campos.Contains(Barrio1Id_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[Barrio1Id_NombreCol]);
                        if (proveedor.IsBARRIO1_IDNull || proveedor.BARRIO1_ID != dAux)
                        {
                            if (BarriosService.EstaActivo(dAux)) proveedor.BARRIO1_ID = dAux;
                            else throw new System.ArgumentException("El barrio seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsBARRIO1_IDNull = true;
                    }

                    proveedor.CALLE1 = (string)campos[Calle1_NombreCol];
                    proveedor.CODIGO_POSTAL1 = (string)campos[CodigoPostal1_NombreCol];
                    if (campos.Contains(EsNacional_NombreCol)) proveedor.ES_NACIONAL = campos[EsNacional_NombreCol].ToString();

                    if (campos.Contains(Departamento2Id_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[Departamento2Id_NombreCol]);
                        if (proveedor.IsDEPARTAMENTO2_IDNull || proveedor.DEPARTAMENTO2_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux)) proveedor.DEPARTAMENTO2_ID = dAux;
                            else throw new System.ArgumentException("El departamento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsDEPARTAMENTO2_IDNull = true;
                    }

                    if (campos.Contains(Ciudad2Id_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[Ciudad2Id_NombreCol]);
                        if (proveedor.IsCIUDAD2_IDNull || proveedor.CIUDAD2_ID != dAux)
                        {
                            if (CiudadesService.EstaActivo(dAux)) proveedor.CIUDAD2_ID = dAux;
                            else throw new System.ArgumentException("La ciudad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsCIUDAD2_IDNull = true;
                    }

                    if (campos.Contains(Barrio2Id_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[Barrio2Id_NombreCol]);
                        if (proveedor.IsBARRIO2_IDNull || proveedor.BARRIO2_ID != dAux)
                        {
                            if (BarriosService.EstaActivo(dAux)) proveedor.BARRIO2_ID = dAux;
                            else throw new System.ArgumentException("El barrio seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsBARRIO2_IDNull = true;
                    }
                    proveedor.CALLE2 = (string)campos[Calle2_NombreCol];
                    proveedor.CODIGO_POSTAL2 = (string)campos[CodigoPostal2_NombreCol];

                    proveedor.TELEFONO1 = (string)campos[Telefono1_NombreCol];
                    proveedor.TELEFONO2 = (string)campos[Telefono2_NombreCol];
                    proveedor.TELEFONO3 = (string)campos[Telefono3_NombreCol];
                    proveedor.TELEFONO4 = (string)campos[Telefono4_NombreCol];
                    proveedor.EMAIL1 = (string)campos[Email1_NombreCol];
                    proveedor.EMAIL2 = (string)campos[Email2_NombreCol];
                    proveedor.EMAIL3 = (string)campos[Email3_NombreCol];

                    if (campos.Contains(ProveedoresService.Latitud1_NombreCol) || campos.Contains(ProveedoresService.Longitud1_NombreCol))
                    {
                        if (!(campos.Contains(ProveedoresService.Latitud1_NombreCol) && campos.Contains(ProveedoresService.Longitud1_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        proveedor.LATITUD1 = (decimal)campos[ProveedoresService.Latitud1_NombreCol];
                        proveedor.LONGITUD1 = (decimal)campos[ProveedoresService.Longitud1_NombreCol];
                    }
                    else
                    {
                        proveedor.IsLATITUD1Null = true;
                        proveedor.IsLONGITUD1Null = true;
                    }

                    if (campos.Contains(ProveedoresService.Latitud2_NombreCol) || campos.Contains(ProveedoresService.Longitud2_NombreCol))
                    {
                        if (!(campos.Contains(ProveedoresService.Latitud2_NombreCol) && campos.Contains(ProveedoresService.Longitud2_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        proveedor.LATITUD2 = (decimal)campos[ProveedoresService.Latitud2_NombreCol];
                        proveedor.LONGITUD2 = (decimal)campos[ProveedoresService.Longitud2_NombreCol];
                    }
                    else
                    {
                        proveedor.IsLATITUD2Null = true;
                        proveedor.IsLONGITUD2Null = true;
                    }

                    if (campos.Contains(MonedaId_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[MonedaId_NombreCol]);
                        if (proveedor.IsMONEDA_IDNull || proveedor.MONEDA_ID != dAux)
                        {
                            if (MonedasService.EstaActivo(dAux)) proveedor.MONEDA_ID = dAux;
                            else throw new System.ArgumentException("La moneda seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsMONEDA_IDNull = true;
                    }

                    proveedor.OPERA_CREDITO = (string)campos[OperaCredito_NombreCol];

                    if (campos.Contains(CondicionHabitualPagoId_NombreCol))
                    {
                        dAux = Decimal.Parse((string)campos[CondicionHabitualPagoId_NombreCol]);
                        if (proveedor.IsCONDICION_HABITUAL_PAGO_IDNull || proveedor.CONDICION_HABITUAL_PAGO_ID != dAux)
                        {
                            if (CondicionesPagoService.EstaActivo(dAux)) proveedor.CONDICION_HABITUAL_PAGO_ID = dAux;
                            else throw new System.ArgumentException("La condición de pago seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        proveedor.IsCONDICION_HABITUAL_PAGO_IDNull = true;
                    }

                    if (insertarNuevo) sesion.Db.PROVEEDORESCollection.Insert(proveedor);
                    else sesion.Db.PROVEEDORESCollection.Update(proveedor);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, proveedor.ID, valorAnterior, proveedor.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return proveedor.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        { get { return "PROVEEDORES"; } }

        public static string Nombre_Vista
        {
            get { return "PROVEEDORES_INFO_COMPLETA"; }
        }

        public static string Id_NombreCol
        { get { return PROVEEDORESCollection.IDColumnName;} }

        public static string NombreFantasia_NombreCol
        { get { return PROVEEDORESCollection.NOMBRE_FANTASIAColumnName; } }

        public static string BanderaRetencion_NombreCol
        { get { return PROVEEDORESCollection.BANDERA_RETENCIONColumnName; } }

        public static string Barrio1Id_NombreCol
        { get { return PROVEEDORESCollection.BARRIO1_IDColumnName; } }

        public static string Barrio2Id_NombreCol
        { get { return PROVEEDORESCollection.BARRIO2_IDColumnName; } }

        public static string Calle1_NombreCol
        { get { return PROVEEDORESCollection.CALLE1ColumnName; } }

        public static string Calle2_NombreCol
        { get { return PROVEEDORESCollection.CALLE2ColumnName; } }

        public static string CentroCostoId_NombreCol
        { get { return PROVEEDORESCollection.CENTRO_COSTO_IDColumnName; } }

        public static string Ciudad1Id_NombreCol
        { get { return PROVEEDORESCollection.CIUDAD1_IDColumnName; } }

        public static string Ciudad2Id_NombreCol
        { get { return PROVEEDORESCollection.CIUDAD2_IDColumnName; } }

        public static string CodigoPostal1_NombreCol
        { get { return PROVEEDORESCollection.CODIGO_POSTAL1ColumnName; } }

        public static string CodigoPostal2_NombreCol
        { get { return PROVEEDORESCollection.CODIGO_POSTAL2ColumnName; } }

        public static string Codigo_NombreCol
        { get { return PROVEEDORESCollection.CODIGOColumnName; } }

        public static string CondicionHabitualPagoId_NombreCol
        { get { return PROVEEDORESCollection.CONDICION_HABITUAL_PAGO_IDColumnName; } }

        public static string ContactoPersona_NombreCol
        { get { return PROVEEDORESCollection.CONTACTO_PERSONAColumnName; } }

        public static string ContactoEmail_NombreCol
        { get { return PROVEEDORESCollection.CONTACTO_EMAILColumnName; } }

        public static string ContactoTelefono_NombreCol
        { get { return PROVEEDORESCollection.CONTACTO_TELEFONOColumnName; } }

        public static string Departamento1Id_NombreCol
        { get { return PROVEEDORESCollection.DEPARTAMENTO1_IDColumnName; } }

        public static string Departamento2Id_NombreCol
        { get { return PROVEEDORESCollection.DEPARTAMENTO2_IDColumnName; } }

        public static string Email1_NombreCol
        { get { return PROVEEDORESCollection.EMAIL1ColumnName; } }

        public static string Email2_NombreCol
        { get { return PROVEEDORESCollection.EMAIL2ColumnName; } }

        public static string Email3_NombreCol
        { get { return PROVEEDORESCollection.EMAIL3ColumnName; } }

        public static string EntidadId_NombreCol
        { get { return PROVEEDORESCollection.ENTIDAD_IDColumnName; } }

        public static string EsNacional_NombreCol
        { get { return PROVEEDORESCollection.ES_NACIONALColumnName; } }

        public static string Estado_NombreCol
        { get { return PROVEEDORESCollection.ESTADOColumnName; } }

        public static string EsContribuyente_NombreCol
        { get { return PROVEEDORESCollection.ES_CONTRIBUYENTEColumnName; } }

        public static string FechaAprobacion_NombreCol
        { get { return PROVEEDORESCollection.FECHA_APROBACIONColumnName; } }

        public static string FechaFundacion_NombreCol
        { get { return PROVEEDORESCollection.FECHA_FUNDACIONColumnName; } }

        public static string FcObservacionDetalle_NombreCol
        { get { return PROVEEDORESCollection.FC_OBSERVACION_DETALLEColumnName; } }

        public static string IngresoAprobado_NombreCol
        { get { return PROVEEDORESCollection.INGRESO_APROBADOColumnName; } }

        public static string Latitud1_NombreCol
        { get { return PROVEEDORESCollection.LATITUD1ColumnName; } }

        public static string Latitud2_NombreCol
        { get { return PROVEEDORESCollection.LATITUD2ColumnName; } }

        public static string Longitud1_NombreCol
        { get { return PROVEEDORESCollection.LONGITUD1ColumnName; } }

        public static string Longitud2_NombreCol
        { get { return PROVEEDORESCollection.LONGITUD2ColumnName; } }
        
        public static string MonedaId_NombreCol
        { get { return PROVEEDORESCollection.MONEDA_IDColumnName; } }

        public static string OperaCredito_NombreCol
        { get { return PROVEEDORESCollection.OPERA_CREDITOColumnName; } }

        public static string PaisId_NombreCol
        { get { return PROVEEDORESCollection.PAIS_IDColumnName; } }

        public static string PasibleRetencion_NombreCol
        { get { return PROVEEDORESCollection.PASIBLE_RETENCIONColumnName; } }

        public static string RazonSocial_NombreCol
        { get { return PROVEEDORESCollection.RAZON_SOCIALColumnName; } }

        public static string RubroId_NombreCol
        { get { return PROVEEDORESCollection.RUBRO_IDColumnName; } }

        public static string Ruc_NombreCol
        { get { return PROVEEDORESCollection.RUCColumnName; } }

        public static string Telefono1_NombreCol
        { get { return PROVEEDORESCollection.TELEFONO1ColumnName; } }

        public static string Telefono2_NombreCol
        { get { return PROVEEDORESCollection.TELEFONO2ColumnName; } }

        public static string Telefono3_NombreCol
        { get { return PROVEEDORESCollection.TELEFONO3ColumnName; } }

        public static string Telefono4_NombreCol
        { get { return PROVEEDORESCollection.TELEFONO4ColumnName; } }

        public static string UsuarioAprobacionId_NombreCol
        { get { return PROVEEDORESCollection.USUARIO_APROBACION_IDColumnName; } }

        public static string SolicitaReferencia_NombreCol
        { get { return PROVEEDORESCollection.SOLICITA_REFERENCIAColumnName; } }

        public static string PersonaId_NombreCol
        { get { return PROVEEDORESCollection.PERSONA_IDColumnName; } }

        public static string FechaDesdeNoRetencion_NombreCol
        { get { return PROVEEDORESCollection.FECHA_DESDE_NO_RETENERColumnName; } }

        public static string FechaHastaNoRetencion_NombreCol
        { get { return PROVEEDORESCollection.FECHA_HASTA_NO_RETENERColumnName; } }

        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaRubroNombre_NombreCol
        { 
            get { return PROVEEDORES_INFO_COMPLETACollection.RUBRO_NOMBREColumnName; } 
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaCondicionHabitualPagoNombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.CONDICION_HABITUAL_PAGO_NOMBREColumnName; }
        }
        public static string VistaCtacteBancoId_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string VistaPaisAbreviatura_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.PAIS_ABREVIATURAColumnName; }
        }
        public static string VistaPaisNombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.PAIS_NOMBREColumnName; }
        }
        public static string VistaDepartamento1Abreviatura_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.DEPARTAMENTO1_ABREVIATURAColumnName; }
        }
        public static string VistaDepartamento1Nombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.DEPARTAMENTO1_NOMBREColumnName; }
        }
        public static string VistaDepartamento2Abreviatura_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.DEPARTAMENTO2_ABREVIATURAColumnName; }
        }
        public static string VistaDepartamento2Nombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.DEPARTAMENTO2_NOMBREColumnName; }
        }
        public static string VistaCiudad1Abreviatura_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.CIUDAD1_ABREVIATURAColumnName; }
        }
        public static string VistaCiudad1Nombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.CIUDAD1_NOMBREColumnName; }
        }
        public static string VistaCiudad2Abreviatura_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.CIUDAD2_ABREVIATURAColumnName; }
        }
        public static string VistaCiudad2Nombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.CIUDAD2_NOMBREColumnName; }
        }
        public static string VistaBarrio1Abreviatura_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.BARRIO1_ABREVIATURAColumnName; }
        }
        public static string VistaBarrio1Nombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.BARRIO1_NOMBREColumnName; }
        }
        public static string VistaBarrio2Abreviatura_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.BARRIO2_ABREVIATURAColumnName; }
        }
        public static string VistaBarrio2Nombre_NombreCol
        {
            get { return PROVEEDORES_INFO_COMPLETACollection.BARRIO2_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static ProveedoresService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new ProveedoresService(e.RegistroId, sesion);
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
        protected PROVEEDORESRow row;
        protected PROVEEDORESRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Codigo { get { return ClaseCBABase.GetStringHelper(row.CODIGO); } set { row.CODIGO = value; } }
        public decimal? CondicionHabitualPago { get { if (row.IsCONDICION_HABITUAL_PAGO_IDNull) return null; else return row.CONDICION_HABITUAL_PAGO_ID; } set { if (value.HasValue) row.CONDICION_HABITUAL_PAGO_ID = value.Value; else row.IsCONDICION_HABITUAL_PAGO_IDNull = true; } }
        public string ContactoEmail { get { return ClaseCBABase.GetStringHelper(row.CONTACTO_EMAIL); } set { row.CONTACTO_EMAIL = value; } }
        public string esNacional { get { return row.ES_NACIONAL; } set { row.ES_NACIONAL = value; } }//El accessor está con minúsculas porque existe un método que coincide en nombre
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Email1 { get { return ClaseCBABase.GetStringHelper(row.EMAIL1); } set { row.EMAIL1 = value; } }
        public string Email2 { get { return ClaseCBABase.GetStringHelper(row.EMAIL2); } set { row.EMAIL2 = value; } }
        public string Email3 { get { return ClaseCBABase.GetStringHelper(row.EMAIL3); } set { row.EMAIL3 = value; } }
        public string NombreFantasia { get { return ClaseCBABase.GetStringHelper(row.NOMBRE_FANTASIA); } set { row.NOMBRE_FANTASIA = value; } }
        public string PasibleRetencion { get { return ClaseCBABase.GetStringHelper(row.PASIBLE_RETENCION); } set { row.PASIBLE_RETENCION = value; } }
        public string RazonSocial { get { return row.RAZON_SOCIAL; } set { row.RAZON_SOCIAL = value; } }
        public string RUC { get { return row.RUC; } set { row.RUC = value; } }
        public decimal? RubroId { get { if (row.IsRUBRO_IDNull) return null; else return row.RUBRO_ID; } set { if (value.HasValue) row.RUBRO_ID = value.Value; else row.IsRUBRO_IDNull = true; } }
        public string Telefono1 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO1); } set { row.TELEFONO1 = value; } }
        public string Telefono2 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO2); } set { row.TELEFONO2 = value; } }
        public string Telefono3 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO3); } set { row.TELEFONO3 = value; } }
        public string Telefono4 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO4); } set { row.TELEFONO4 = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private RubrosService _rubros;
        public RubrosService Rubros
        {
            get
            {
                if (this._rubros == null)
                    this._rubros = new RubrosService(RubroId.Value);
                return this._rubros;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.PROVEEDORESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new PROVEEDORESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(PROVEEDORESRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public ProveedoresService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ProveedoresService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ProveedoresService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public ProveedoresService(EdiCBA.Proveedor edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = ProveedoresService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.RazonSocial = edi.razon_social;
            this.Codigo = edi.codigo;
 
            if(edi.documentos!= null && edi.documentos.Count > 0)
            {
                this.RUC = edi.documentos[0].numero;
            }

            int contTelefonos = 0;
            if (edi.telefonos != null && edi.telefonos.Count > contTelefonos)
                this.Telefono1 = edi.telefonos[++contTelefonos].codigo_pais + edi.telefonos[contTelefonos].codigo_operadora + edi.telefonos[++contTelefonos].numero;
            if (edi.telefonos != null && edi.telefonos.Count > contTelefonos)
                this.Telefono2 = edi.telefonos[++contTelefonos].codigo_pais + edi.telefonos[contTelefonos].codigo_operadora + edi.telefonos[++contTelefonos].numero;
            if (edi.telefonos != null && edi.telefonos.Count > contTelefonos)
                this.Telefono3 = edi.telefonos[++contTelefonos].codigo_pais + edi.telefonos[contTelefonos].codigo_operadora + edi.telefonos[++contTelefonos].numero;
            if (edi.telefonos != null && edi.telefonos.Count > contTelefonos)
                this.Telefono4 = edi.telefonos[++contTelefonos].codigo_pais + edi.telefonos[contTelefonos].codigo_operadora + edi.telefonos[++contTelefonos].numero;
        }
        #endregion Constructores

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI()
        {
            using (SessionService sesion = new SessionService())
            {
                return ToEDI(sesion);
            }
        }
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return ToEDI(0, sesion);
        }

        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            var lDocumentos = new List<EdiCBA.Documento>();
            var lDirecciones = new List<EdiCBA.Direccion>();
            var lTelefonos = new List<EdiCBA.Telefono>();
            var lImagenes = new List<EdiCBA.Imagen>();

            #region Documento
            var doc = new EdiCBA.Documento()
            {
                tipo = EdiCBA.TipoDocumento.RUC,
                numero = this.RUC,
                orden = 0
            };

            //Se limpian los . en el numero del documento
            if (doc.numero.Contains("."))
                doc.numero = doc.numero.Replace(".", string.Empty);

            if (this.ExisteEnDB)
            {
                doc.id = this.Id.Value;
                doc.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, Ruc_NombreCol, this.Id.Value, sesion);
            }

            lDocumentos.Add(doc);
            #endregion Documento

            var e = new CBA.FlowV2.Services.Base.EdiCBA.Proveedor()
            {
                codigo = this.Codigo,
                razon_social = this.RazonSocial,
                documentos = lDocumentos,
                direcciones = lDirecciones,
                telefonos = lTelefonos,
                imagenes = lImagenes,
            };

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = this.GetOrCreateUUID(sesion);
            }
            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
