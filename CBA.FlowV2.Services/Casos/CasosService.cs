#region Using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Contabilidad;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Common;
#endregion Using

namespace CBA.FlowV2.Services.Casos
{
    public class CasosService
    {
        #region GetEstadoCaso
        /// <summary>
        /// Gets the estado caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static string GetEstadoCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetEstadoCaso(caso_id, sesion);
            }
        }

        public static string GetEstadoCaso(decimal caso_id, SessionService sesion)
        {
            return sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id).ESTADO_ID;
        }

        #endregion getEstadoCaso

        #region ExisteCaso
        public static bool ExisteCaso(decimal caso_id, SessionService sesion)
        {
            CASOSRow caso = sesion.db.CASOSCollection.GetByPrimaryKey(caso_id);
            if (caso == null)
                return false;
            if (caso.ESTADO.Equals(Definiciones.Estado.Inactivo))
                return false;

            return true;
        }

        public static bool ExisteCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return ExisteCaso(caso_id, sesion);
            }
        }
        #endregion ExisteCaso

        #region GetSucursal
        /// <summary>
        /// Gets the sucursal.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal GetSucursal(decimal caso_id, SessionService sesion)
        {
            return sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id).SUCURSAL_ID;
        }
        #endregion GetSucursal

        #region GetCasoPorId
        public static CASOSRow GetCasoPorId(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CASOSRow caso = sesion.db.CASOSCollection.GetByPrimaryKey(caso_id);
                return caso;
            }
        }

        public static CASOSRow GetCasoPorId(decimal caso_id, SessionService sesion)
        {
            CASOSRow caso = sesion.db.CASOSCollection.GetByPrimaryKey(caso_id);
            return caso;
        }
        #endregion GetCasoPorId

        #region ActualizarSucursal
        public static void ActualizarSucursal(decimal caso_id, decimal sucursal_id, SessionService sesion)
        {
            try
            {
                CASOSRow casoViejo = GetCasoPorId(caso_id, sesion);
                CASOSRow casoNuevo = GetCasoPorId(caso_id, sesion);
                casoNuevo.SUCURSAL_ID = sucursal_id;
                casoNuevo.ULTIMA_MODIFICACION = DateTime.Now;
                sesion.db.CASOSCollection.Update(casoNuevo);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, casoNuevo.ID, casoViejo.ToString(), casoNuevo.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ActualizarSucursal

        #region ActualizarEstado
        public static void ActualizarEstado(decimal caso_id, string estado_actual, string estado_anterior, SessionService sesion)
        {
            try
            {
                CASOSRow row = GetCasoPorId(caso_id);
                string valorAnterior = row.ToString();
                row.ESTADO_ID = estado_actual;
                row.ESTADO_ANTERIOR_ID = estado_anterior;
                sesion.db.CASOSCollection.Update(row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion ActualizarEstado

        #region Actualizar
        public static bool Actualizar(CASOSRow fila_nueva, SessionService sesion)
        {
            bool res = false;
            CASOSRow filaVieja = sesion.db.CASOSCollection.GetByPrimaryKey(fila_nueva.ID);
            res = sesion.db.CASOSCollection.Update(fila_nueva);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, fila_nueva.ID, filaVieja.ToString(), fila_nueva.ToString(), sesion);
            return res;
        }
        #endregion Actualizar

        #region GetCasoDataTable
        /// <summary>
        /// Gets the caso data table.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public DataTable GetCasoDataTable(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CasosService.Id_NombreCol + " = " + caso_id + " and " +
                                   CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                return sesion.Db.CASOSCollection.GetAsDataTable(clausulas, string.Empty);
            }
        }
        #endregion GetCasoDataTable

        #region GetFlujo
        public static decimal GetFlujo(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFlujo(caso_id, sesion);
            }
        }

        /// <summary>
        /// Gets the flujo.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static decimal GetFlujo(decimal caso_id, SessionService sesion)
        {
            CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
            return caso == null ? Definiciones.Error.Valor.EnteroPositivo : caso.FLUJO_ID;
        }
        #endregion GetFlujo

        #region GetEstado
        public static bool EstaActivo(decimal caso_id, SessionService sesion)
        {
            CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
            return caso.ESTADO == Definiciones.Estado.Activo;
        }

        public static bool EstaActivo(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return EstaActivo(caso_id, sesion);
            }
        }
        #endregion GetEstado

        #region Obtener flujo y estado de un caso
        public static void GetFlujoYEstado(decimal caso_id, ref string flujo_id, ref string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                GetFlujoYEstado(caso_id, ref flujo_id, ref estado_id, sesion);
            }
        }

        /// <summary>
        /// Gets the flujo Y estado.
        /// </summary>
        /// <param name="caso_id">El numero de caso.</param>
        /// <param name="flujo_id">Una referencia a la variable donde se almacenara el flujo_id.</param>
        /// <param name="estado_id">}Una referencia a la variable donde se almacenara el estado_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void GetFlujoYEstado(decimal caso_id, ref string flujo_id, ref string estado_id, SessionService sesion)
        {
            CASOSRow caso = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
            flujo_id = caso.FLUJO_ID.ToString();
            estado_id = caso.ESTADO_ID;
        }
        #endregion Obtener flujo y estado de un caso

        #region GetListaDeCasos
        /// <summary>
        /// Obtener una lista separada por comas de id de casos que coinciden con el flujo y estado dados.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static string GetListaDeCasos(decimal flujo_id, string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string resultado;
                string where = CasosService.FlujoId_NombreCol + " = " + flujo_id + " and " +
                               CasosService.EstadoId_NombreCol + " = '" + estado_id + "' and " +
                               CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                DataTable casos = sesion.Db.CASOSCollection.GetAsDataTable(where, string.Empty);

                decimal[] lista = new decimal[casos.Rows.Count];
                for (int i = 0; i < casos.Rows.Count; i++)
                {
                    lista[i] = (decimal)casos.Rows[i][CasosService.Id_NombreCol];
                }

                //Convertir el array de int a una cadena separada por comas
                resultado = String.Join(",", Array.ConvertAll<decimal, string>(lista, delegate(decimal i) { return i.ToString(); }));

                return resultado;
            }
        }
        /// <summary>
        /// Obtener un array de decimales con id de casos que coinciden con el flujo y estado dados.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="estado_id">The estado_id.</param>
        /// <returns></returns>
        public static decimal[] GetListaDeCasosArray(decimal flujo_id, string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = CasosService.FlujoId_NombreCol + " = " + flujo_id + " and " +
                               CasosService.EstadoId_NombreCol + " = '" + estado_id + "' and " +
                               CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
                DataTable casos = sesion.Db.CASOSCollection.GetAsDataTable(where, string.Empty);

                decimal[] lista = new decimal[casos.Rows.Count];
                for (int i = 0; i < casos.Rows.Count; i++)
                {
                    lista[i] = (decimal)casos.Rows[i][CasosService.Id_NombreCol];
                }
                return lista;
            }
        }
        #endregion GetListaDeCasos

        #region GetCasosInfoCompleta
        public DataTable GetCasosInfoCompleta(string clausulas, SessionService sesion)
        {
            return GetCasosInfoCompleta(clausulas, string.Empty, sesion);
        }

        public static DataTable GetCasoInfoCompletaDataTable(decimal casoId, SessionService sesion)
        {
            return GetCasosInfoCompleta(CasosService.Id_NombreCol + " = " + casoId, string.Empty, sesion);
        }

        public static DataTable GetCasosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCasosInfoCompleta(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCasosInfoCompleta(string clausulas, string orden, SessionService sesion)
        {
            string where = CasosService.VistaEntidadId_NombreCol + " = " + sesion.EntidadActual_Id + " and " +
                           CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            if (clausulas.Length > 0)
                where += " and " + clausulas;

            return sesion.Db.CASOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
        }
        #endregion GetCasosInfoCompleta

        #region GetCasosDataTable
        public static DataTable GetCasosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCasosDataTable(clausulas, orden, sesion);
            }
        }
        public static DataTable GetCasosDataTable(string clausulas, string orden, SessionService sesion)
        {
            string where = CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            if (clausulas.Length > 0)
                where += " and " + clausulas;

            return sesion.db.CASOSCollection.GetAsDataTable(where, orden);
        }
        #endregion GetCasosDataTable

        #region GetCasosInfoCompletaFiltrandoPermisos
        public DataTable GetCasosInfoCompletaFiltrandoPermisos(string clausulas, string orden)
        {
            return CasosService.GetCasosInfoCompletaFiltrandoPermisos2(clausulas, orden);
        }

        public static DataTable GetCasosInfoCompletaFiltrandoPermisos2(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string sql, sqlTiposPorFlujo;
                string sqlTipoFCProveedores;

                #region tipos por flujo segun permisos
                sqlTipoFCProveedores = " ( pvf." + PermisosVisualizacionFlujosService.FlujoId_NombreCol + " = " + Definiciones.FlujosIDs.FACTURACION_PROVEEDOR + " and (" +
                                            "(" + (RolesService.Tiene("tipo factura proveedor compra articulos ver") ? "1=1" : "1=0") + " and pvf." + PermisosVisualizacionFlujosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.CompraArticulos + " and " + CasosService.Nombre_Vista + "." + CasosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.CompraArticulos + " ) or " +
                                            "(" + (RolesService.Tiene("tipo factura proveedor gastos ver") ? "1=1" : "1=0") + " and pvf." + PermisosVisualizacionFlujosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.Gastos + " and " + CasosService.Nombre_Vista + "." + CasosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.Gastos + " ) or " +
                                            "(" + (RolesService.Tiene("TIPO FACTURA PROVEEDOR PAGO A TERCEROS VER") ? "1=1" : "1=0") + " and pvf." + PermisosVisualizacionFlujosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.PagoTerceros + " and " + CasosService.Nombre_Vista + "." + CasosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.PagoTerceros + " ) or " +
                                            "(" + (RolesService.Tiene("TIPO FACTURA PROVEEDOR GASTOS DE DESPACHO VER") ? "1=1" : "1=0") + " and pvf." + PermisosVisualizacionFlujosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.GastosDeDespacho + " and " + CasosService.Nombre_Vista + "." + CasosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.GastosDeDespacho + " ) or " +
                                            "(" + (RolesService.Tiene("TIPO FACTURA PROVEEDOR AUTOFACTURA VER") ? "1=1" : "1=0") + " and pvf." + PermisosVisualizacionFlujosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.Autofactura + " and " + CasosService.Nombre_Vista + "." + CasosService.TipoEspecifico_NombreCol + " = " + Definiciones.TipoFacturaProveedor.Autofactura + " ) " +
                                        " )) ";

                sqlTiposPorFlujo = " ( pvf." + PermisosVisualizacionFlujosService.TipoEspecifico_NombreCol + " is null or " +
                                        sqlTipoFCProveedores +
                                    " ) ";


                #endregion tipos por flujo segun permisos

                sql = " exists " +
                    "       (select pvf.id " +
                    "          from permisos_visualizacion_flujos pvf, usuarios_roles ur, usuarios_sucursales us " +
                    "         where ur.usuario_id = " + sesion.Usuario_Id + " " +
                    "           and us.usuario_id = " + sesion.Usuario_Id + " " +
                    "           and (" + CasosService.Nombre_Vista + "." + CasosService.SucursalId_NombreCol + " = " + " us." + UsuariosSucursalesService.SucursalId_NombreCol + " or " +
                    "                exists (" +
                    "                        select r.id from " + RolesService.Nombre_Tabla + " r, " + UsuariosRolesService.Nombre_Tabla + " ur2 " +
                    "                         where r." + RolesService.Descripcion_NombreCol + " = 'USUARIO PUEDE VER CASOS TODAS SUCURSALES' " +
                    "                           and ur2." + UsuariosRolesService.RolId_NombreCol + " = r." + RolesService.Id_NombreCol + " and ur2." + UsuariosRolesService.UsuarioId_NombreCol + " = " + sesion.Usuario.ID + ")" +
                    "                )" +
                    "           and pvf.flujo_id = " + CasosService.Nombre_Vista + ".flujo_id " +
                    "           and (pvf.estado_id = " + CasosService.Nombre_Vista + ".estado_id or pvf.estado_id is null) " +
                    "           and pvf.rol_id = ur.rol_id " +
                    "           and " + sqlTiposPorFlujo + ") " +
                    " and " + CasosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (!sesion.permisoPuedeVerCasosAjenos)
                    sql += " and " + CasosService.UsuarioCreacionId_NombreCol + " = " + sesion.Usuario_Id;

                if (clausulas.Length > 0) sql += " and " + clausulas;

                return GetCasosInfoCompleta(sql, orden, sesion);
            }
        }
        #endregion GetCasosInfoCompletaFiltrandoPermisos

        #region ActualizarCampos
        /// <summary>
        /// Actualizars the campos.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        public static void ActualizarCampos(decimal caso_id, Hashtable campos, SessionService sesion)
        {
            try
            {
                CASOSRow row = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                row.ULTIMO_USUARIO_ID = sesion.Usuario_Id;
                row.ULTIMA_MODIFICACION = DateTime.Now;

                if (campos.Contains(CasosService.FechaFormulario_NombreCol))
                {
                    row.FECHA_FORMULARIO = (DateTime)campos[CasosService.FechaFormulario_NombreCol];
                    
                    var sm = StockMovimientoService.Instancia;
                    sm.IniciarUsingSesion(sesion);
                    foreach (var movimiento in sm.GetFiltrado<StockMovimientoService>(new ClaseCBABase.Filtro(){ Columna = StockMovimientoService.Modelo.CASO_IDColumnName, Valor = row.ID }))
                    {
                        movimiento.IniciarUsingSesion(sesion);
                        movimiento.FechaFormulario = row.FECHA_FORMULARIO;
                        movimiento.Guardar();
                        movimiento.FinalizarUsingSesion();
                    }
                    sm.FinalizarUsingSesion();
                }
                else
                {
                    row.IsFECHA_FORMULARIONull = true;
                }

                if (campos.Contains(CasosService.SucursalId_NombreCol))
                    row.SUCURSAL_ID = decimal.Parse(campos[CasosService.SucursalId_NombreCol].ToString());

                if (campos.Contains(CasosService.FuncionarioId_NombreCol))
                    row.FUNCIONARIO_ID = (decimal)campos[CasosService.FuncionarioId_NombreCol];
                else
                    row.IsFUNCIONARIO_IDNull = true;

                if (campos.Contains(CasosService.NroComprobante_NombreCol))
                    row.NRO_COMPROBANTE = (string)campos[CasosService.NroComprobante_NombreCol];
                else
                    row.NRO_COMPROBANTE = string.Empty;

                if (campos.Contains(CasosService.NroComprobante2_NombreCol))
                    row.NRO_COMPROBANTE_2 = (string)campos[CasosService.NroComprobante2_NombreCol];
                else
                    row.NRO_COMPROBANTE_2 = string.Empty;

                if (campos.Contains(CasosService.PersonaId_NombreCol))
                {
                    UsuariosService usuario = new UsuariosService();
                    if (usuario.GetPersonaId(sesion.Usuario_Id) == (decimal)campos[CasosService.PersonaId_NombreCol] && usuario.GetPersonaId(sesion.Usuario_Id) != Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("El usuario no puede crear un caso de sí mismo.");
                    
                    row.PERSONA_ID = (decimal)campos[CasosService.PersonaId_NombreCol];
                }
                else
                    row.IsPERSONA_IDNull = true;

                if (campos.Contains(CasosService.ProveedorId_NombreCol))
                {
                    UsuariosService usuario = new UsuariosService();
                    if (usuario.GetPersonaId(sesion.Usuario_Id) == ProveedoresService.GetPersonaIdPorProveedorId((decimal)campos[CasosService.ProveedorId_NombreCol]) && usuario.GetPersonaId(sesion.Usuario_Id) != Definiciones.Error.Valor.EnteroPositivo)
                        throw new Exception("El usuario no puede crear un caso de sí mismo.");

                    row.PROVEEDOR_ID = (decimal)campos[CasosService.ProveedorId_NombreCol];
                }
                else
                    row.IsPROVEEDOR_IDNull = true;

                if (campos.Contains(CasosService.TipoEspecifico_NombreCol))
                    row.TIPO_ESPECIFICO = (decimal)campos[CasosService.TipoEspecifico_NombreCol];
                else
                    row.IsTIPO_ESPECIFICONull = true;

                sesion.Db.CASOSCollection.Update(row);
            }
            catch (Exception exp)
            {
            }
        }
        #endregion ActualizarCampos

        #region Eliminar
        /// <summary>
        /// Eliminars the specified caso_id.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void Eliminar(decimal caso_id, SessionService sesion)
        {
            CASOSRow row = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
            string valorAnterior = row.ToString();

            row.ESTADO = Definiciones.Estado.Inactivo;
            sesion.db.CASOSCollection.Update(row);

            // Verificar asientos aprobados
            DataTable dtAsientosAprobados = AsientosService.GetAsientosDataTable(AsientosService.CasoRelacionadoId_NombreCol + " = " + caso_id + " AND " + AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' AND " + AsientosService.Aprobado_NombreCol + " = '" + Definiciones.SiNo.Si + "' ", string.Empty);

            if (dtAsientosAprobados.Rows.Count > 0)
            {
                List<string> asientos = new List<string>();
                foreach (DataRow dr in dtAsientosAprobados.Rows)
                    asientos.Add(dr[AsientosService.Numero_NombreCol].ToString());

                throw new Exception("No es posible eliminar. Los siguientes asientos contables ya se encuentran aprobados: " + string.Join(", ", asientos.ToArray()) + ".");
            }
            else
            {
                // Eliminar asientos si existen
                DataTable dtAsientos = AsientosService.GetAsientosDataTable(AsientosService.CasoRelacionadoId_NombreCol + " = " + caso_id + " AND " + AsientosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ", string.Empty);

                foreach (DataRow dr in dtAsientos.Rows)
                    AsientosService.Borrar((decimal)dr[AsientosService.Id_NombreCol], sesion);
            }

            LogCambiosService.LogDeRegistro(CasosService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Eliminar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "CASOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "CASOS_INFO_COMPLETA"; }
        }
        public static string Estado_NombreCol
        {
            get { return CASOSCollection.ESTADOColumnName; }
        }
        public static string EstadoId_NombreCol
        {
            get { return CASOSCollection.ESTADO_IDColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CASOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaFormatoNumero_NombreCol
        {
            get { return CASOSCollection.FECHA_FORMATO_NUMEROColumnName; }
        }
        public static string FechaFormFormatoNumero_NombreCol
        {
            get { return CASOSCollection.FECHA_FORM_FORMATO_NUMEROColumnName; }
        }
        public static string FechaFormulario_NombreCol
        {
            get { return CASOSCollection.FECHA_FORMULARIOColumnName; }
        }
        public static string FlujoId_NombreCol
        {
            get { return CASOSCollection.FLUJO_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return CASOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CASOSCollection.IDColumnName; }
        }
        public static string NroComprobante_NombreCol
        {
            get { return CASOSCollection.NRO_COMPROBANTEColumnName; }
        }
        public static string NroComprobante2_NombreCol
        {
            get { return CASOSCollection.NRO_COMPROBANTE_2ColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CASOSCollection.PERSONA_IDColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CASOSCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return CASOSCollection.SUCURSAL_IDColumnName; }
        }
        public static string TipoEspecifico_NombreCol
        {
            get { return CASOSCollection.TIPO_ESPECIFICOColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return CASOSCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return CASOSCollection.USUARIO_IDColumnName; }
        }
        public static string VistaFlujoAgrupamientoId_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.FLUJO_AGRUPAMIENTO_IDColumnName; }
        }
        public static string VistaFlujoDescripcion_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.FLUJO_DESCRIPCIONColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaEntidadId_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.ENTIDAD_IDColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaUltimoUsuarioNombreCompleto_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.ULTIMO_USUARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaUsuarioCreacionNombreComp_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.USUARIO_CREACION_NOMBRE_COMPColumnName; }
        }
        public static string VistaUsuarioNombreCompleto_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.USUARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.PERSONA_NOMBREColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaTipoClienteId_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.PERSONA_TIPO_CLIENTE_IDColumnName; }
        }
        public static string VistaProveedorRazonSocial_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.PROVEEDOR_RAZON_SOCIALColumnName; }
        }
        public static string VistaProveedorCodigo_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.PROVEEDOR_CODIGOColumnName; }
        }
        public static string VistaFlujoDescripcionImp_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.FLUJO_DESCRIPCION_IMPColumnName; }
        }
        public static string VistaSucursalRegionId_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.SUCURSAL_REGION_IDColumnName; }
        }
        public static string VistaSucursalRegionNombre_NombreCol
        {
            get { return CASOS_INFO_COMPLETACollection.SUCURSAL_REGION_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static CasosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new CasosService(e.RegistroId, sesion);
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
        protected CASOSRow row;
        protected CASOSRow rowSinModificar;
        public class Modelo : CASOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string EstadoAnterior { get { return ClaseCBABase.GetStringHelper(row.ESTADO_ANTERIOR_ID); } set { row.ESTADO_ANTERIOR_ID = value; } }
        public string EstadoId { get { return ClaseCBABase.GetStringHelper(row.ESTADO_ID); } set { row.ESTADO_ID = value; } }
        public DateTime FechaCreacion { get { return row.FECHA_CREACION; } set { row.FECHA_CREACION = value; } }
        public decimal? FechaFormFormatoNumero { get { if (row.IsFECHA_FORM_FORMATO_NUMERONull) return null; else return row.FECHA_FORM_FORMATO_NUMERO; } set { if (value.HasValue) row.FECHA_FORM_FORMATO_NUMERO = value.Value; else row.IsFECHA_FORM_FORMATO_NUMERONull= true; } }
        public decimal FechaFormatoNumero { get { return row.FECHA_FORMATO_NUMERO; } set { row.FECHA_FORMATO_NUMERO = value; } }
        public DateTime? FechaFormulario { get { if (row.IsFECHA_FORMULARIONull) return null; else return row.FECHA_FORMULARIO; } set { if (value.HasValue) row.FECHA_FORMULARIO = value.Value; else row.IsFECHA_FORMULARIONull = true; } }
        public decimal FlujoId { get { return row.FLUJO_ID; } set { if (this.FlujoId != value) this._flujo = null; row.FLUJO_ID = value; } }
        public decimal? FuncionarioId { get { if (row.IsFUNCIONARIO_IDNull) return null; else return row.FUNCIONARIO_ID; } set { if (value.HasValue) { if (this.FuncionarioId != value) this._funcionario = null; row.FUNCIONARIO_ID = value.Value; } else { row.IsFUNCIONARIO_IDNull = true; } } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string NroComprobante { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE); } set { row.NRO_COMPROBANTE = value; } }
        public string NroComprobante2 { get { return ClaseCBABase.GetStringHelper(row.NRO_COMPROBANTE_2); } set { row.NRO_COMPROBANTE_2 = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; else return row.PERSONA_ID; } set { if (value.HasValue) { if (this.PersonaId != value) this._persona = null; row.PERSONA_ID = value.Value; } else { row.IsPERSONA_IDNull = true; } } }
        public decimal? ProveedorId { get { if (row.IsPROVEEDOR_IDNull) return null; else return row.PROVEEDOR_ID; } set { if (value.HasValue) { if (this.ProveedorId != value) this._proveedor = null; row.PROVEEDOR_ID = value.Value; } else { row.IsPROVEEDOR_IDNull = true; } } }
        public decimal SucursalId { get { return row.SUCURSAL_ID; } set { if (this.SucursalId != value) this._sucursal = null; row.SUCURSAL_ID = value; } }
        public decimal? TipoEspecifico { get { if (row.IsTIPO_ESPECIFICONull) return null; else return row.TIPO_ESPECIFICO; } set { if (value.HasValue) row.TIPO_ESPECIFICO = value.Value; else row.IsTIPO_ESPECIFICONull = true; } }
        public DateTime? UltimaActualizacion { get { if (row.IsULTIMA_MODIFICACIONNull) return null; else return row.ULTIMA_MODIFICACION; } set { if (value.HasValue) row.ULTIMA_MODIFICACION = value.Value; else row.IsULTIMA_MODIFICACIONNull = true; } }
        public decimal? UltimoUsuarioId { get { if (row.IsULTIMO_USUARIO_IDNull) return null; else return row.ULTIMO_USUARIO_ID; } set { if (value.HasValue) row.ULTIMO_USUARIO_ID = value.Value; else row.IsULTIMO_USUARIO_IDNull = true; } }
        public decimal? UsuarioCreacionId { get { if (row.IsUSUARIO_CREACION_IDNull) return null; else return row.USUARIO_CREACION_ID; } set { if (value.HasValue) row.USUARIO_CREACION_ID = value.Value; else row.IsUSUARIO_CREACION_IDNull = true; } }
        public decimal? UsuarioId { get { if (row.IsUSUARIO_IDNull) return null; else return row.USUARIO_ID; } set { if (value.HasValue) { if (this.UsuarioId != value) this._usuario = null; row.USUARIO_ID = value.Value; } else { row.IsUSUARIO_IDNull = true; } } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private FlujosService _flujo;
        public FlujosService Flujo
        {
            get
            {
                if (this._flujo == null)
                    this._flujo = new FlujosService(this.FlujoId);
                return this._flujo;
            }
        }
        
        private FuncionariosService _funcionario;
        public FuncionariosService Funcionario
        {
            get
            {
                if (this._funcionario == null)
                    this._funcionario = new FuncionariosService(this.FuncionarioId.Value);
                return this._funcionario;
            }
        }

        private PersonasService _persona;
        public PersonasService Persona
        {
            get
            {
                if (this._persona == null)
                    this._persona = new PersonasService(this.PersonaId.Value);
                return this._persona;
            }
        }

        private ProveedoresService _proveedor;
        public ProveedoresService Proveedor
        {
            get
            {
                if (this._proveedor == null)
                    this._proveedor = new ProveedoresService(this.ProveedorId.Value);
                return this._proveedor;
            }
        }

        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                    this._sucursal = new SucursalesService(this.SucursalId);
                return this._sucursal;
            }
        }
        
        private UsuariosService _usuario;
        public UsuariosService Usuario
        {
            get
            {
                if (this._usuario == null)
                    this._usuario = new UsuariosService(this.UsuarioId.Value);
                return this._usuario;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CASOSCollection.GetByPrimaryKey(id);
                if (row.ESTADO == Definiciones.Estado.Inactivo)
                    throw new Exception("El caso " + id + " fue borrado.");
            }
            else
            {
                this.row = new CASOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public CasosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CasosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CasosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public CasosService(EdiCBA.Caso edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = CasosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            this.Estado = Definiciones.Estado.Activo;
            this.EstadoId = edi.estado_id;

            #region funcionario
            if (!string.IsNullOrEmpty(edi.funcionario_uuid))
                this._funcionario = FuncionariosService.GetPorUUID(edi.funcionario_uuid, sesion);
            if (this._funcionario == null && edi.funcionario != null)
                this._funcionario = new FuncionariosService(edi.funcionario, almacenar_localmente, sesion);
            if (this._funcionario != null)
            {
                if (!this.Funcionario.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.Funcionario.Id.HasValue)
                    this.FuncionarioId = this.Funcionario.Id.Value;
            }
            #endregion funcionario

            this.NroComprobante = edi.nro_comprobante;

            #region persona
            if (!string.IsNullOrEmpty(edi.persona_uuid))
                this._persona = PersonasService.GetPorUUID(edi.persona_uuid, sesion);
            if (this._persona == null && edi.persona != null)
                this._persona = new PersonasService(edi.persona, almacenar_localmente, sesion);
            if (this._persona != null)
            {
                if (!this.Persona.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.Persona.Id.HasValue)
                    this.PersonaId = this.Persona.Id.Value;
            }
            #endregion persona

            #region proveedor
            if (!string.IsNullOrEmpty(edi.proveedor_uuid))
                this._proveedor = ProveedoresService.GetPorUUID(edi.proveedor_uuid, sesion);
            if (this._proveedor == null && edi.proveedor != null)
                this._proveedor = new ProveedoresService(edi.proveedor, almacenar_localmente, sesion);
            if (this._proveedor != null)
            {
                if (!this.Proveedor.ExisteEnDB && almacenar_localmente)
                {
                    //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                    throw new NotImplementedException("Debe guardarse localmente la entidad.");
                }
                if (this.Proveedor.Id.HasValue)
                    this.ProveedorId = this.Proveedor.Id.Value;
            }
            #endregion proveedor

            #region sucursal
            if (!string.IsNullOrEmpty(edi.sucursal_uuid))
                this._sucursal = SucursalesService.GetPorUUID(edi.sucursal_uuid, sesion);
            if (this._sucursal == null && edi.sucursal != null)
                this._sucursal = new SucursalesService(edi.sucursal, almacenar_localmente, sesion);
            if (this._sucursal == null)
                throw new Exception("No se encontró el UUID " + edi.sucursal_uuid + " ni se definieron los datos del objeto.");

            if (!this.Sucursal.ExisteEnDB && almacenar_localmente)
            {
                //Cuando la clase referenciada sea orientada a objetos, llamar a Guardar()
                throw new NotImplementedException("Debe guardarse localmente la entidad.");
            }
            if (this.Sucursal.Id.HasValue)
                this.SucursalId = this.Sucursal.Id.Value;
            #endregion sucursal
        }
        #endregion Constructores

        #region Guardar
        public decimal Guardar(SessionService sesion)
        {
            try
            {
                this.Validar(sesion);
                if (this.excepciones.ExistenErrores)
                    return Definiciones.Error.Valor.EnteroPositivo;

                sesion.db.CASOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);

                this.rowSinModificar = this.row.Clonar();
                return this.Id.Value;
            }
            catch
            {
                throw;
            }
        }
        #endregion Guardar

        #region Validar
        public bool Validar(SessionService sesion)
        {
            
            return !this.excepciones.ExistenErrores;
        }
        #endregion Validar

        #region ToEDI
        public CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI()
        {
            var e = new EdiCBA.Caso()
            {
                caso_id = this.Id.Value,
                estado_id = this.EstadoId,
                funcionario_id = this.FuncionarioId,
                nro_comprobante = this.NroComprobante,
                persona_id = this.PersonaId,
                proveedor_id = this.ProveedorId,
                sucursal_id = this.SucursalId,
            };

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }

            return e;
        }
        #endregion ToEDI
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
