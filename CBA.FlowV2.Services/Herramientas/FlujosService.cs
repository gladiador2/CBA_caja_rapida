using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Stock;
using CBA.FlowV2.Services.Tesoreria;
using System.Windows.Forms;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.ToolbarFlujo;
using CBA.FlowV2.Services.Common;

namespace CBA.FlowV2.Services.Herramientas
{
    interface IFlujo
    {
        int GetFlujoId();
        void ProcesarCambioEstado(string estado_destino_id, bool cambio_pedido_por_usuario, ToolbarFlujoService.ComentarioTransicion comentario, SessionService sesion);

        /// <summary>
        /// Retorna el conjunto de centros de costo a ser afectados (key: id del centro de costo, value: porcentaje) en los asientos automaticos
        /// </summary>
        /// <returns></returns>
        Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion);
    }

    public abstract class FlujosServiceBase<T> : ClaseCBA<T>, IFlujo where T : new()
    {
        //Cuando el guardado es una consecuencia del paso de estado de otro flujo,
        //debe poder indicarse que no se controlen los permisos de guardar
        protected bool controlarPermisosGuardado = true;

        public virtual int GetFlujoId()
        {
            throw new NotImplementedException("Debe ser implementado por las clases que derivan.");
        }

        public virtual Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
        {
            throw new NotImplementedException("Debe ser implementado por las clases que derivan.");
        }

        /// <summary>
        /// Metodo que debe ser implementada por cada service que hereda esta clase.
        /// Realiza las acciones necesarias al cambiar de estado un caso.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="estado_destino">The estado_destino.</param>
        /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
        /// <param name="mensaje">The mensaje de salida.</param>
        /// <returns>
        /// True si no los controles se ejecutaron exitosamente, si no false.
        /// </returns>
        protected abstract CasosService EjecutarAccionesCambioEstado(string estado_destino_id, bool cambio_pedido_por_usuario, SessionService sesion);

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        protected abstract void EjecutarAccionesLuegoDeCambioEstado(string estado_destino_id, SessionService sesion);

        public void ProcesarCambioEstado(string estado_destino_id, bool cambio_pedido_por_usuario, ToolbarFlujoService.ComentarioTransicion comentario, SessionService sesion)
        {
            CasosService caso = this.EjecutarAccionesCambioEstado(estado_destino_id, cambio_pedido_por_usuario, sesion);
            (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(caso.Id.Value, estado_destino_id, comentario, sesion);

            this.EjecutarAccionesLuegoDeCambioEstado(estado_destino_id, sesion);
        }

        #region VerificarRequisitosDelFlujo
        /// <summary>
        /// Verificar que el caso cumple con los requisitos establecidos para pasar el estado actual.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="mensaje">The mensaje.</param>
        /// <returns></returns>
        public void VerificarRequisitosDelFlujo(decimal caso_id, SessionService sesion)
        {
            RequisitosFlujoService RequisitosFlujo = new RequisitosFlujoService();
            RequisitosFlujoDetalleService RequisitosFlujoDetalle = new RequisitosFlujoDetalleService();
            DataTable dtRequisitos;
            DataTable dtRequisitosCumplidos;
            string flujo_id = "";
            string estado_id = "";
            bool ok;

            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            CasosService.GetFlujoYEstado(caso_id, ref flujo_id, ref estado_id, sesion);
            dtRequisitos = RequisitosFlujoService.GetRequisitosPorFlujoYEstado(decimal.Parse(flujo_id), estado_id, true, true, sesion);
            dtRequisitosCumplidos = RequisitosFlujoDetalle.GetRequisitosFlujoDetalleDataTable(caso_id, sesion);

            foreach (DataRow drRequisito in dtRequisitos.Rows)
            {
                ok = false;

                foreach (DataRow drReqCumplido in dtRequisitosCumplidos.Rows)
                {

                    //Se compara si el id del requisito cumplido es el mismo que el requisito necesario
                    if (drRequisito[RequisitosFlujoService.Id_NombreCol].Equals(drReqCumplido[RequisitosFlujoDetalleService.RequisitoFlujoId_NombreCol]))
                    {
                        ok = true;
                        break;
                    }
                }

                if (!ok)
                {
                    excepciones.Agregar("Existen requisitos que aun no fueron cumplidos por el caso en el estado " + estado_id + ".");
                    break;
                }
            }

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion VerificarRequisitosDelFlujo

        #region pasarela cambio estado campos
        public SolicitarCamposService.Campo[] pasarelaCambioEstadoCampos;
        public virtual SolicitarCamposService.Campo GetPasarelaCambioEstadoCampo(string campo_nombre_interno)
        {
            if (this.pasarelaCambioEstadoCampos == null)
                return null;
            for (int i = 0; i < this.pasarelaCambioEstadoCampos.Length; i++)
            {
                if (this.pasarelaCambioEstadoCampos[i].nombreInterno == campo_nombre_interno)
                    return this.pasarelaCambioEstadoCampos[i];
            }
            return null;
        }
        #endregion pasarela cambio estado campos
    }
    
    public class FlujosServiceBaseWorkaround : FlujosServiceBase<FlujosServiceBaseWorkaround>
    {
        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override FlujosServiceBaseWorkaround[] Buscar(Filtro[] filtros)
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }
        #endregion ToEDI

        #region VerificarRequisitosDelFlujo
        public void VerificarRequisitosDelFlujo(decimal caso_id) 
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }
        
        public bool VerificarRequisitosDelFlujo(decimal caso_id, out string mensaje, SessionService sesion)
        {
            base.VerificarRequisitosDelFlujo(caso_id, sesion);
            mensaje = string.Empty;
            return true;
        }
        #endregion VerificarRequisitosDelFlujo

        #region GetNumeroComprobante
        public virtual string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            CasosService caso = new CasosService(caso_id, sesion);
            return caso.NroComprobante;
        }
        #endregion GetNumeroComprobante

        protected override CasosService EjecutarAccionesCambioEstado(string estado_destino_id, bool cambio_pedido_por_usuario, SessionService sesion)
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }

        protected override void EjecutarAccionesLuegoDeCambioEstado(string estado_destino_id, SessionService sesion)
        {
            throw new NotImplementedException("Los flujos tienen que ir dejando el workaround implementando las clases ellos mismos.");
        }

        public virtual bool ProcesarCambioEstado(decimal caso_id, string estado_destino_id, bool cambio_pedido_por_usuario, out string mensaje, SessionService sesion) { mensaje = string.Empty; return true; }
        public virtual void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }
    }

    public class FlujosService
    {
        public static DataTable GetFlujosDataTable(bool incluirRegistroTodos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.FLUJOSCollection.GetAsDataTable(" entidad_id = " + sesion.Entidad.ID, FLUJOSCollection.DESCRIPCIONColumnName);

                if (incluirRegistroTodos)
                {
                    DataRow row = table.NewRow();
                    row[FLUJOSCollection.IDColumnName] = Definiciones.IdNull;
                    row[FLUJOSCollection.DESCRIPCIONColumnName] = "Todos";
                    row[FLUJOSCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID;
                    table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }

        public static DataTable GetFlujosDataTableStatic(bool incluirRegistroTodos, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.FLUJOSCollection.GetAsDataTable(" entidad_id = " + sesion.Entidad.ID, orden);

                if (incluirRegistroTodos)
                {
                    DataRow row = table.NewRow();
                    row[FLUJOSCollection.IDColumnName] = Definiciones.IdNull;
                    row[FLUJOSCollection.DESCRIPCIONColumnName] = "Todos";
                    row[FLUJOSCollection.ENTIDAD_IDColumnName] = sesion.Entidad.ID;
                    table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }

        public static DataTable GetFlujosDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = " entidad_id = " + sesion.Entidad.ID;
                if (!where.Equals(string.Empty))
                    clausula += " and " + where;
                return sesion.Db.FLUJOSCollection.GetAsDataTable(clausula, orderBy);
            }
        }

        public DataTable GetFlujosDataTable()
        {
            return GetFlujosDataTable(false);
        }

        #region GetDescripcionImpresion
        public static string GetDescripcionImpresion(decimal flujo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FLUJOSRow row = sesion.db.FLUJOSCollection.GetByPrimaryKey(flujo_id);
                return row.DESCRIPCION_IMPRESION;
            }
        }
        #endregion GetDescripcionImpresion

        public static string GetFlujoDescripcion(decimal flujo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                FLUJOSRow row = sesion.Db.FLUJOSCollection.GetByPrimaryKey(flujo_id);
                return row.DESCRIPCION;
            }
        }

        public static DataTable GetFlujosConPermisoCrear()
        {
            using (SessionService sesion = new SessionService())
            {
                //obtener el array de roles que tiene el usuario
                decimal[] roles = RolesService.TieneArray(Definiciones.Flujo.permisosFlujos(), sesion.Usuario_Id);
                string where = FlujosService.RolCreacionId_NombreCol + " in (";
                for (int i = 0; i < roles.Length; i++)
                {
                    if (i != 0)
                        where += ", ";
                    where += roles[i];
                }
                where += ") or " + FlujosService.RolCreacionId_NombreCol + " is null";
                return sesion.Db.FLUJOSCollection.GetAsDataTable(where, FlujosService.DescripcionImpresion_NombreCol);
            }
        }

        private static string vComboboxAccionId_NombreCol = "id";

        private static string vComboboxAccionNombre_NombreCol = "nombre";

        public static DataTable GetAccionesPorLote(int flujo_id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(vComboboxAccionId_NombreCol, typeof(int));
            dt.Columns.Add(vComboboxAccionNombre_NombreCol, typeof(string));

            if (!flujo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {//hay flujo seleccionado, entonces es homogeneo 
                switch (flujo_id)
                {
                    case Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO:
                        if (RolesService.Tiene("ADELANTO FUNCIONARIO IMPRIMIR RECIBO"))
                            dt.Rows.Add(Definiciones.AccionPorLote.Imprimir, "Imprimir Recibo");
                        break;
                    case Definiciones.FlujosIDs.CREDITOS:
                        if (RolesService.Tiene("CREDITOS CLIENTES ACCION CREAR FACTURA PROVEEDOR"))
                            dt.Rows.Add(Definiciones.AccionPorLote.GenerarFacturaProveedor, "Generar Factura Proveedor");
                        break;
                    case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                        dt.Rows.Add(Definiciones.AccionPorLote.AsignarCustodiaDocumentos, "Asignar Custodia a Funcionario");
                        if (RolesService.Tiene("REPORTES VER TESORERIA FACTURAS DE PERSONAS"))
                            dt.Rows.Add(Definiciones.AccionPorLote.Imprimir, "Imprimir Facturas");
                        break;
                    case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                        if (RolesService.Tiene("FC PROVEEDOR GENERAR OP"))
                            dt.Rows.Add(Definiciones.AccionPorLote.GenerarOP, "Generar OP");
                        break;
                    case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                        dt.Rows.Add(Definiciones.AccionPorLote.ImprimirCheque, "Imprimir Cheques");
                        dt.Rows.Add(Definiciones.AccionPorLote.Imprimir, "Imprimir Movimientos Varios");
                        break;
                    case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                        dt.Rows.Add(Definiciones.AccionPorLote.Imprimir, "Imprimir Notas de Crédito");
                        break;
                    case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                        dt.Rows.Add(Definiciones.AccionPorLote.CrearCasoDepositoBancario, "Crear Depósito Bancario");
                        dt.Rows.Add(Definiciones.AccionPorLote.ImprimirCheque, "Imprimir Cheques");
                        dt.Rows.Add(Definiciones.AccionPorLote.Imprimir, "Imprimir Órdenes de Pago");
                        break;
                    case Definiciones.FlujosIDs.PAGO_DE_PERSONAS:
                        if (RolesService.Tiene("pagos de persona accion crear deposito bancario"))
                            dt.Rows.Add(Definiciones.AccionPorLote.CrearCasoDepositoBancario, "Crear Depósito Bancario");
                        
                        dt.Rows.Add(Definiciones.AccionPorLote.ImprimirRecibo, "Imprimir Recibos");
                        break;
                    case Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA:
                        dt.Rows.Add(Definiciones.AccionPorLote.Imprimir, "Imprimir Transferencias");
                        dt.Rows.Add(Definiciones.AccionPorLote.ImprimirCheque, "Imprimir Cheques");
                        break;
                    case Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR:
                        if (RolesService.Tiene("ANTICIPOS PROVEEDOR CREAR"))
                            dt.Rows.Add(Definiciones.AccionPorLote.GenerarFacturaProveedor, "Crear Factura Proveedor");
                        break;
                } 
            }
            //acciones comunes a todos los flujos
            dt.Rows.Add(Definiciones.AccionPorLote.CambiarEstado, "Cambiar Estado");
            return dt;
        }

        public static bool VerificarPuedeAvanzarEstado(decimal caso_id, out string mensaje, string rol, decimal variable_sistema_id, SessionService sesion)
        {
            mensaje = "";
            DataTable dtCaso = CasosService.GetCasosDataTable(CasosService.Id_NombreCol + " = " + caso_id, string.Empty, sesion);

            //Validar la fecha de actualización de los datos de la persona
            if (!Interprete.EsNullODBNull(dtCaso.Rows[0][CasosService.PersonaId_NombreCol]))
            {
                if (!PersonasService.GetDatosEstanActualizados((decimal)dtCaso.Rows[0][CasosService.PersonaId_NombreCol], sesion))
                {
                    mensaje = "Deben actualizarse los datos de " + Traducciones.la_persona + ".";
                    return false;
                }
            }

            //Chequear que el usuario no tenga el rol para ignorar este chequeo
            if (RolesService.Tiene(rol))
                return true;

            //Hacer el cálculo para determinar si es que entra en el rango válido
            decimal margenDias = VariablesSistemaEntidadService.GetValorDecimal(variable_sistema_id);

            DateTime fechaFormulario = (DateTime)dtCaso.Rows[0][CasosService.FechaFormulario_NombreCol];
            DateTime fechaActual = DateTime.Today;

            if (fechaFormulario.Month != fechaActual.Month || fechaFormulario.Year != fechaActual.Year)
            {
                fechaFormulario = fechaFormulario.AddMonths(1);
                fechaFormulario = new DateTime(fechaFormulario.Year, fechaFormulario.Month, 1);
                fechaFormulario = fechaFormulario.AddDays((double)(margenDias - 1));

                if (fechaFormulario.Date < fechaActual.Date)
                {
                    mensaje = "El " + Traducciones.Caso + " se encuentra fuera del rango de fechas en el que se permite cambiar de estado.";
                    return false;
                }
            }

            if (!RolesService.Tiene("CASOS NO CONTROLAR FECHA A FUTURO"))
            {
                double margenDiasFuturo = (double)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CantidadDiasFechaAFuturo);

                fechaFormulario = (DateTime)dtCaso.Rows[0][CasosService.FechaFormulario_NombreCol];

                if (fechaFormulario.Date > fechaActual.Date && DateTime.Today.AddDays(margenDiasFuturo).Date <= fechaFormulario.Date)
                {
                    mensaje = "El " + Traducciones.Caso + " " + caso_id + " no puede aprobarse con una fecha superior a " + margenDiasFuturo + " días.";
                    return false;
                }
            }

            return true;
        }

        public static void EjecutarAccion(int accion, int flujo_id, Dictionary<int, int> casos, Hashtable datos, ref decimal valorAsociado, out Dictionary<decimal, string> advertencias)
        {
            bool accionComun = false;
            advertencias = new Dictionary<decimal, string>();

            if (!flujo_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
            {//hay flujo seleccionado, entonces es homogeneo 
                using (SessionService sesion = new SessionService())
                {
                    try
                    {
                        sesion.BeginTransaction();

                        if (accion == Definiciones.AccionPorLote.CambiarEstado)
                            accionComun = true;

                        if (!accionComun)
                        {
                            Dictionary<int, int> casosId = casos;
                            int casoId;
                            int cabeceraId;
                            int flujoId;

                            #region accion por flujo
                            switch (flujo_id)
                            {
                                case Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO:
                                    switch (accion)
                                    {
                                        case Definiciones.AccionPorLote.Imprimir:
                                            valorAsociado = Definiciones.Reportes.RRHH.ReciboAdelantoFuncionario;
                                            break;
                                    }
                                    break;
                                case Definiciones.FlujosIDs.AJUSTE_BANCARIO:
                                    break;
                                case Definiciones.FlujosIDs.AJUSTE_STOCK:
                                    break;
                                case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                    break;
                                case Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR:
                                    switch (accion)
                                    {
                                        #region Generar Facturas
                                        case Definiciones.AccionPorLote.GenerarFacturaProveedor:

                                            #region Propiedades
                                            Dictionary<int, int> ids = casos;
                                            ArrayList ArrayCasosAprobados = new ArrayList();//Array que lista los casos que cumplen los requerimientos
                                            ArrayList ArrayProveedores = new ArrayList();//Array de proveedores por si se generan facturas unificadas
                                            /*Se copia la lista de nro de comprobantes obtenidas del control*/
                                            ArrayList ArrayComprobantes = (ArrayList)datos[FacturasProveedorService.NroComprobante_NombreCol];
                                            ArrayList ArrayTimbrados = (ArrayList)datos[FacturasProveedorService.NroTimbrado_NombreCol];
                                            decimal casoFactura = decimal.Zero;
                                            decimal montoTotal = decimal.Zero;
                                            bool unificarFactura = bool.Parse(datos["UNIFICADO"].ToString());
                                            #endregion

                                            #region Validaciones
                                            /*Obs = Se validan los casos con estados correspondientes y que no se hayan generado una factura del anticipo o que esta
                                             este anulada*/
                                            foreach (KeyValuePair<int, int> id in ids)
                                            {
                                                cabeceraId = id.Key;
                                                flujoId = id.Value;
                                                string casoEstado = CasosService.GetEstadoCaso(cabeceraId, sesion);

                                                if (!(casoEstado.Equals(Definiciones.EstadosFlujos.Aplicacion)))
                                                    throw new Exception("Solo se puede generar la factura con casos en estado APLICACION");

                                                decimal idAnticipo = AnticiposProveedorService.GetAnticipoIdPorCaso(cabeceraId);
                                                if (idAnticipo != Definiciones.Error.Valor.EnteroPositivo)
                                                {
                                                    /*Obs= Si el anticipo ya tiene un factura asociada regresa con su id sino con -1*/
                                                    decimal idFacturaAsociada = AnticiposPorFacturasProveedorService.ContieneFacturaAsociada(idAnticipo);
                                                    if (idFacturaAsociada == Definiciones.Error.Valor.EnteroPositivo)
                                                        ArrayCasosAprobados.Add(cabeceraId);
                                                    else
                                                    {
                                                        bool bandAnticipoPorProveedor = true;
                                                        string clausula = AnticiposPorFacturasProveedorService.AnticipoProveedorId_NombreCol + "=" + idAnticipo;
                                                        DataTable dtFacturasAnticipos = AnticiposPorFacturasProveedorService.GetAnticiposPorFacturasProveedorDataTable(clausula, string.Empty);
                                                        if (dtFacturasAnticipos.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow row in dtFacturasAnticipos.Rows)
                                                            {
                                                                string where = FacturasProveedorService.Id_NombreCol + "=" + decimal.Parse(row[AnticiposPorFacturasProveedorService.FacturaProveedorId_NombreCol].ToString());
                                                                DataTable dtFactura = FacturasProveedorService.GetFacturaProveedorInfoCompleta(where, string.Empty);
                                                                if (dtFactura.Rows[0][FacturasProveedorService.VistaCasoEstadoId_NombreCol].ToString() != Definiciones.EstadosFlujos.Anulado)
                                                                {
                                                                    bandAnticipoPorProveedor = false;
                                                                    casoFactura = decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString());
                                                                    break; 
                                                                }
                                                            }
                                                        }

                                                        if (bandAnticipoPorProveedor)
                                                            ArrayCasosAprobados.Add(cabeceraId);
                                                        else
                                                            throw new Exception("El anticipo " + cabeceraId + " ya esta asociado a la factura " + casoFactura);
                                                    }
                                                }
                                                else
                                                    throw new Exception("Error al obtener datos del anticipo "+cabeceraId);
                                            }

                                            #endregion

                                            if (unificarFactura)
                                            {
                                                #region Obtener Lista de Proveedores
                                                /*OBS=Se genera la lista de proveedores de los casos aprobados*/
                                                for (int i = 0; i < ArrayCasosAprobados.Count; i++)
                                                {
                                                    string clausula = AnticiposProveedorService.CasoId_NombreCol + "=" + ArrayCasosAprobados[i].ToString();
                                                    DataTable dtAnticipos = AnticiposProveedorService.GetAnticipoProveedorDataTable(clausula, string.Empty);
                                                    if (dtAnticipos.Rows.Count > 0)
                                                    {
                                                        bool bandProveedorRegistrado = true;

                                                        if (ArrayProveedores.Count > 0)
                                                        {
                                                            for (int j = 0; j < ArrayProveedores.Count; j++)
                                                            {
                                                                if (ArrayProveedores[j].ToString() == dtAnticipos.Rows[0][AnticiposProveedorService.ProveedorId_NombreCol].ToString())
                                                                {
                                                                    bandProveedorRegistrado = false;
                                                                }
                                                            }
                                                            if (bandProveedorRegistrado)
                                                                ArrayProveedores.Add(dtAnticipos.Rows[0][AnticiposProveedorService.ProveedorId_NombreCol].ToString());
                                                        }
                                                        else
                                                        {
                                                            ArrayProveedores.Add(dtAnticipos.Rows[0][AnticiposProveedorService.ProveedorId_NombreCol].ToString());
                                                        }
                                                    }
                                                }
                                                #endregion

                                                #region Generar Facturas por Proveedores
                                                /*OBS= Se generan las facturas por proveedor*/
                                                for (int i = 0; i < ArrayProveedores.Count; i++)
                                                {
                                                    #region Obtener Montos y Observaciones
                                                    montoTotal = 0;
                                                    ArrayList ArrayCasosPorProveedor = new ArrayList();//Array que guarda las id de los casos por proveedor.
                                                    string casosaprobadosObservacion = string.Empty;//lista los casos referentes al proveedor para agregar al comentario si este esta vacio.

                                                    for (int j = 0; j < ArrayCasosAprobados.Count; j++)
                                                    {
                                                        string clausula = AnticiposProveedorService.CasoId_NombreCol + "=" + decimal.Parse(ArrayCasosAprobados[j].ToString());
                                                        DataTable dtAnticipos = AnticiposProveedorService.GetAnticipoProveedorDataTable(clausula, String.Empty);

                                                        if (dtAnticipos.Rows.Count > 0)
                                                        {
                                                            if (ArrayProveedores[i].ToString() == dtAnticipos.Rows[0][AnticiposProveedorService.ProveedorId_NombreCol].ToString())
                                                            {
                                                                if (casosaprobadosObservacion == string.Empty)
                                                                    casosaprobadosObservacion += ArrayCasosAprobados[j].ToString();
                                                                else
                                                                    casosaprobadosObservacion += " - " + ArrayCasosAprobados[j].ToString();

                                                                montoTotal += decimal.Parse(dtAnticipos.Rows[0][AnticiposProveedorService.MontoTotal_NombreCol].ToString());
                                                                ArrayCasosPorProveedor.Add(dtAnticipos.Rows[0][AnticiposProveedorService.Id_NombreCol].ToString());
                                                            }
                                                        }
                                                    }
                                                    #endregion

                                                    #region Generar Facturas

                                                    #region Formatear HashTable
                                                    /*OBS= Se generan las facturas por casos aprobados por lo tanto hay que formatear por cada caso, el comprabante y
                                                    timbrado siempre son formateados por ser obtenidos en array en el metodo de obtener los datos*/
                                                    if (datos.Contains(FacturasProveedorService.NroComprobante_NombreCol))
                                                        datos.Remove(FacturasProveedorService.NroComprobante_NombreCol);

                                                    if (datos.Contains(FacturasProveedorService.NroTimbrado_NombreCol))
                                                        datos.Remove(FacturasProveedorService.NroTimbrado_NombreCol);

                                                    if (ArrayProveedores.Count > 1)
                                                    {
                                                        if (datos.Contains(FacturasProveedorService.ProveedorId_NombreCol))
                                                            datos.Remove(FacturasProveedorService.ProveedorId_NombreCol);
                                                        if (datos.Contains(CasosService.Id_NombreCol))
                                                            datos.Remove(CasosService.Id_NombreCol);
                                                    }

                                                    datos.Add(FacturasProveedorService.NroComprobante_NombreCol, ArrayComprobantes[i].ToString());
                                                    datos.Add(FacturasProveedorService.NroTimbrado_NombreCol, ArrayTimbrados[i].ToString());
                                                    datos.Add(FacturasProveedorService.ProveedorId_NombreCol, decimal.Parse(ArrayProveedores[i].ToString()));
                                                    datos.Add(CasosService.Id_NombreCol, casosaprobadosObservacion);
                                                    #endregion

                                                    /*Generar Facturas por Proveedores*/
                                                    casoFactura = FacturasProveedorService.GenerarFacturaProveedor(datos, montoTotal);
                                                    if (casoFactura.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                    {
                                                        DataTable dtProveedor = ProveedoresService.GetProveedoresInfoCompletaFiltradoPorId(decimal.Parse(ArrayProveedores[i].ToString()));
                                                        if (dtProveedor.Rows.Count > 0)
                                                            throw new Exception("Error al generar la factura unificada al proveedor " + dtProveedor.Rows[0][ProveedoresService.RazonSocial_NombreCol].ToString());
                                                        else
                                                            throw new Exception("Error al generar la factura unificada al proveedor ");
                                                    }

                                                    #endregion

                                                    #region Relacionar Existencia entre Anticipo y Factura
                                                    for (int j = 0; j < ArrayCasosPorProveedor.Count; j++)
                                                    {
                                                        Hashtable camposAP = new Hashtable();
                                                        decimal IdFactura = FacturasProveedorService.GetFacturaIdPorCaso(casoFactura);

                                                        camposAP.Add(AnticiposPorFacturasProveedorService.AnticipoProveedorId_NombreCol, decimal.Parse(ArrayCasosPorProveedor[j].ToString()));
                                                        camposAP.Add(AnticiposPorFacturasProveedorService.FacturaProveedorId_NombreCol, IdFactura);
                                                        camposAP.Add(AnticiposPorFacturasProveedorService.Fecha_NombreCol, DateTime.Now);
                                                        AnticiposPorFacturasProveedorService.Guardar(camposAP);
                                                    }
                                                    #endregion
                                                }

                                                #region Generar Advertencias
                                                foreach (KeyValuePair<int, int> id in ids)
                                                {
                                                    cabeceraId = id.Key;

                                                    decimal idAnticipo = AnticiposProveedorService.GetAnticipoIdPorCaso(cabeceraId);
                                                    string clausula = AnticiposPorFacturasProveedorService.AnticipoProveedorId_NombreCol + "=" + idAnticipo;
                                                    DataTable dtFacturasAnticipos = AnticiposPorFacturasProveedorService.GetAnticiposPorFacturasProveedorDataTable(clausula, string.Empty);
                                                    if (dtFacturasAnticipos.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow row in dtFacturasAnticipos.Rows)
                                                        {
                                                            string where = FacturasProveedorService.Id_NombreCol + "=" + decimal.Parse(row[AnticiposPorFacturasProveedorService.FacturaProveedorId_NombreCol].ToString());
                                                            DataTable dtFactura = FacturasProveedorService.GetFacturaProveedorInfoCompleta(where, string.Empty);

                                                            if (dtFactura.Rows[0][FacturasProveedorService.VistaCasoEstadoId_NombreCol].ToString() != Definiciones.EstadosFlujos.Anulado)
                                                            {
                                                                if (!decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString()).Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                                {
                                                                    string values = string.Empty;
                                                                    foreach (KeyValuePair<decimal, string> adv in advertencias)
                                                                    {
                                                                        if (adv.Key.Equals(decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString())))
                                                                        {
                                                                             values = adv.Value;
                                                                             break;
                                                                        }
                                                                    }

                                                                    if (values != string.Empty)
                                                                    {
                                                                        advertencias.Remove(decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString()));
                                                                        advertencias.Add(decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString()), values + " , " + cabeceraId.ToString());
                                                                    }
                                                                    else
                                                                        advertencias.Add(decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString()), "Se creó la FP caso " + dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString() + " desde el anticipo " + cabeceraId.ToString());
                                                                }
                                                                else
                                                                {
                                                                    if (!advertencias.ContainsKey(Definiciones.Error.Valor.EnteroPositivo))
                                                                        advertencias.Add(decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString()), "Error en creación de FP para los siguientes anticipos: " + cabeceraId.ToString());
                                                                    else
                                                                        advertencias[decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString())] = advertencias[decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString())] + ", " + decimal.Parse(dtFactura.Rows[0][FacturasProveedorService.CasoId_NombreCol].ToString());
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion

                                                #endregion
                                            }
                                            else
                                            {
                                                #region Generar Facturas por Casos Aprobados
                                                for (int i = 0; i < ArrayCasosAprobados.Count; i++)
                                                {
                                                    #region Generar Factura
                                                    string clausula = AnticiposProveedorService.CasoId_NombreCol + "=" + decimal.Parse(ArrayCasosAprobados[i].ToString());
                                                    DataTable dtAnticipos = AnticiposProveedorService.GetAnticipoProveedorDataTable(clausula, String.Empty);

                                                    #region Configuracion HashTable
                                                    /*Es necasario formatear todos los registros ya que datos trae en si un array de nro comprobantes y timbrados*/
                                                    if (datos.Contains(FacturasProveedorService.NroComprobante_NombreCol))
                                                        datos.Remove(FacturasProveedorService.NroComprobante_NombreCol);

                                                    if (datos.Contains(FacturasProveedorService.NroTimbrado_NombreCol))
                                                        datos.Remove(FacturasProveedorService.NroTimbrado_NombreCol);

                                                    if (ArrayCasosAprobados.Count > 1)
                                                    {
                                                        /*Solo es necesario formater el hashtable si se genera por mas de un caso a la vez*/
                                                        if (datos.Contains(FacturasProveedorService.ProveedorId_NombreCol))
                                                            datos.Remove(FacturasProveedorService.ProveedorId_NombreCol);

                                                        if (datos.Contains(CasosService.Id_NombreCol))
                                                            datos.Remove(CasosService.Id_NombreCol);

                                                        if (datos.Contains(FacturasProveedorService.CasoAsociadoId_NombreCol))
                                                            datos.Remove(FacturasProveedorService.CasoAsociadoId_NombreCol);
                                                    }

                                                    datos.Add(FacturasProveedorService.NroComprobante_NombreCol, ArrayComprobantes[i].ToString());
                                                    datos.Add(FacturasProveedorService.NroTimbrado_NombreCol, ArrayTimbrados[i].ToString());
                                                    datos.Add(FacturasProveedorService.ProveedorId_NombreCol, decimal.Parse(dtAnticipos.Rows[0][FacturasProveedorService.ProveedorId_NombreCol].ToString()));
                                                    datos.Add(CasosService.Id_NombreCol, decimal.Parse(ArrayCasosAprobados[i].ToString()));
                                                    datos.Add(FacturasProveedorService.CasoAsociadoId_NombreCol, decimal.Parse(ArrayCasosAprobados[i].ToString()));
                                                    #endregion

                                                    /*Se genera la factura proveedor*/
                                                    montoTotal = decimal.Parse(dtAnticipos.Rows[0][AnticiposProveedorService.MontoTotal_NombreCol].ToString());
                                                    casoFactura = FacturasProveedorService.GenerarFacturaProveedor(datos, montoTotal);
                                                    if (casoFactura.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                        throw new Exception("Error al generar la factura desde el caso de anticipo " + ArrayCasosAprobados[i].ToString());
                                                    #endregion

                                                    #region Generar Advertencias
                                                    if (!casoFactura.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                    {
                                                        advertencias.Add(casoFactura, "Se creó la FP caso " + casoFactura.ToString() + " desde el anticipo " + ArrayCasosAprobados[i].ToString());
                                                    }
                                                    else
                                                    {
                                                        if (!advertencias.ContainsKey(Definiciones.Error.Valor.EnteroPositivo))
                                                            advertencias.Add(casoFactura, "Error en creación de FP para los siguientes anticipos: "+ArrayCasosAprobados[i].ToString());
                                                        else
                                                            advertencias[casoFactura] = advertencias[casoFactura] + ", " + casoFactura;
                                                    }
                                                    #endregion

                                                    #region Relacionar Existencia entre Anticipo y Factura
                                                    Hashtable camposAP = new Hashtable();
                                                    decimal idFactura = FacturasProveedorService.GetFacturaIdPorCaso(casoFactura);
                                                    decimal idAnticipo = AnticiposProveedorService.GetAnticipoIdPorCaso(decimal.Parse(ArrayCasosAprobados[i].ToString()));

                                                    camposAP.Add(AnticiposPorFacturasProveedorService.AnticipoProveedorId_NombreCol, idAnticipo);
                                                    camposAP.Add(AnticiposPorFacturasProveedorService.FacturaProveedorId_NombreCol, idFactura);
                                                    camposAP.Add(AnticiposPorFacturasProveedorService.Fecha_NombreCol, DateTime.Now);
                                                    AnticiposPorFacturasProveedorService.Guardar(camposAP);
                                                    #endregion
                                                }
                                                #endregion
                                            }

                                            break;
                                        #endregion

                                        #region Default
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                        #endregion
                                    }
                                    break;
                                case Definiciones.FlujosIDs.ASIGNACION_CARGOS:
                                    break;
                                case Definiciones.FlujosIDs.CAMBIO_DIVISA:
                                    break;
                                case Definiciones.FlujosIDs.CANJES_VALORES:
                                    break;
                                case Definiciones.FlujosIDs.CONTRATOS:
                                    break;
                                case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                    break;
                                case Definiciones.FlujosIDs.CUSTODIA_DE_VALORES:
                                    break;
                                case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:
                                    break;
                                case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS:
                                    break;
                                case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                                    break;
                                case Definiciones.FlujosIDs.ENCUESTAS:
                                    break;
                                case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                    switch (accion)
                                    {
                                        #region AsignarCustodiaFuncionario
                                        case Definiciones.AccionPorLote.AsignarCustodiaDocumentos:
                                            //La accion se realiza cuando se guarda en el formulario AsignacionDocumentos.AsignarForm
                                            break;
                                        #endregion AsignarCustodiaFuncionario

                                        #region ImprimirFacturas
                                        case Definiciones.AccionPorLote.Imprimir:
                                            valorAsociado = Definiciones.Reportes.Tesoreria.FacturasdePersonasImpresion;
                                            break;
                                        #endregion ImprimirFacturas
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                    switch (accion)
                                    {
                                        #region GenerarOP
                                        case Definiciones.AccionPorLote.GenerarOP:
                                            // Se obtiene datatable con casos seleccionados
                                            string casosFC = string.Empty;
                                            foreach (KeyValuePair<int, int> caso in casos)
                                                casosFC += caso.Key.ToString() + ", ";

                                            casosFC = casosFC.Remove(casosFC.Length - 2);
                                            DataTable dtFacturas = FacturasProveedorService.GetFacturaProveedorDataTable2(FacturasProveedorService.CasoId_NombreCol + " in (" + casosFC + ")", string.Empty, sesion);

                                            // Se obtienen los distintos proveedores del conjunto de casos recibido
                                            DataTable dtProveedores = dtFacturas.DefaultView.ToTable(true, FacturasProveedorService.ProveedorId_NombreCol);

                                            // Se crea una op por cada proveedor
                                            string mensaje = string.Empty;
                                            foreach (DataRow proveedor in dtProveedores.Rows)
                                            {
                                                DataRow[] dtCasos = dtFacturas.Select(FacturasProveedorService.ProveedorId_NombreCol + " = " + proveedor[FacturasProveedorService.ProveedorId_NombreCol].ToString());

                                                // Se crea la cabecera de la OP
                                                Hashtable cabecera = new Hashtable();
                                                cabecera.Add(OrdenesPagoService.OrdenPagoTipoId_NombreCol, Definiciones.TiposOrdenesPago.PagoAProveedor);
                                                cabecera.Add(OrdenesPagoService.SucursalOrigenId_NombreCol, datos[OrdenesPagoService.SucursalOrigenId_NombreCol]);
                                                cabecera.Add(OrdenesPagoService.MonedaId_NombreCol, datos[OrdenesPagoService.MonedaId_NombreCol]);
                                                cabecera.Add(OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol, datos[OrdenesPagoService.CtacteCajaTesoOrigenId_NombreCol]);
                                                cabecera.Add(OrdenesPagoService.ProveedorId_NombreCol, (decimal)proveedor[FacturasProveedorService.ProveedorId_NombreCol]);
                                                cabecera.Add(OrdenesPagoService.Fecha_NombreCol, DateTime.Now);
                                                cabecera.Add(OrdenesPagoService.Observacion_NombreCol, "Orden de Pago generada en acción por lote desde Buscador de Casos.");

                                                // Se crean los detalles de la OP
                                                Hashtable[] detalles = new Hashtable[dtCasos.Length];
                                                string comprobantes = string.Empty;
                                                decimal cantidadDecimales = MonedasService.CantidadDecimalesStatic((decimal)datos[OrdenesPagoService.MonedaId_NombreCol]);

                                                for (int i = 0; i < dtCasos.Length; i++)
                                                {
                                                    string clausulas = CuentaCorrienteProveedoresService.ProveedorId_NombreCol + " = " + proveedor[FacturasProveedorService.ProveedorId_NombreCol].ToString() + " and " +
                                                                       "round(" + CuentaCorrienteProveedoresService.Credito_NombreCol + " - " + CuentaCorrienteProveedoresService.Debito_NombreCol + ", " + cantidadDecimales + ") > 0 and " +
                                                                        CuentaCorrienteProveedoresService.CasoId_NombreCol + " = " + dtCasos[i][FacturasProveedorService.CasoId_NombreCol].ToString();
                                                    DataTable dtCtacteProveedor = CuentaCorrienteProveedoresService.GetCuentaCorrienteProveedoresInfoCompleta(clausulas, CuentaCorrienteProveedoresService.FechaVencimiento_NombreCol, sesion);

                                                    detalles[i] = new Hashtable();
                                                    detalles[i].Add(OrdenesPagoDetalleService.CtacteProveedorId_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Id_NombreCol]);
                                                    detalles[i].Add(OrdenesPagoDetalleService.MonedaOrigenId_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.MonedaId_NombreCol]);
                                                    detalles[i].Add(OrdenesPagoDetalleService.CasoReferidoId_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.CasoId_NombreCol]);
                                                    detalles[i].Add(OrdenesPagoDetalleService.MontoOrigen_NombreCol, (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Credito_NombreCol] - (decimal)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.Debito_NombreCol]);
                                                    detalles[i].Add(OrdenesPagoDetalleService.Observacion_NombreCol, (string)dtCtacteProveedor.Rows[0][CuentaCorrienteProveedoresService.VistaObservacion_NombreCol]);

                                                    comprobantes += dtCasos[i][FacturasProveedorService.NroComprobante_NombreCol].ToString() + ", ";
                                                }

                                                // Se crea la OP
                                                comprobantes = comprobantes.Remove(comprobantes.Length - 2);
                                                decimal casoOP = OrdenesPagoService.CrearOrdenPago(cabecera, detalles, Definiciones.Error.Valor.IntPositivo, null, true, false, sesion);
                                                string proveedorNombre = ProveedoresService.GetRazonSocial((decimal)proveedor[FacturasProveedorService.ProveedorId_NombreCol], sesion);
                                                if (!casoOP.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                {
                                                    advertencias.Add(casoOP, "Se creó la OP Caso " + casoOP.ToString() + " para las facturas " + comprobantes + " del proveedor " + proveedorNombre + ".");
                                                }
                                                else
                                                {
                                                    if (!advertencias.ContainsKey(Definiciones.Error.Valor.EnteroPositivo))
                                                        advertencias.Add(casoOP, "Error en creación de OP para los siguientes proveedores: " + proveedorNombre);
                                                    else
                                                        advertencias[casoOP] = advertencias[casoOP] + ", " + proveedorNombre;
                                                }
                                            }
                                            break;
                                        #endregion GenerarOP
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Acción no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.INGRESO_DE_STOCK:
                                    break;
                                case Definiciones.FlujosIDs.MODIFICAR_LISTA_PRECIOS:
                                    break;
                                case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                                    switch (accion)
                                    {
                                        case Definiciones.AccionPorLote.Imprimir:
                                            valorAsociado = Definiciones.Reportes.Tesoreria.MovimientoVarioTesoreriaCaso;
                                            throw new Exception("Acción no implementada");//Falta adaptar el reporte para imprimir multiples casos
                                            break;
                                        case Definiciones.AccionPorLote.ImprimirCheque:
                                            valorAsociado = (decimal)datos["reporte_id"];
                                            break;
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                    switch (accion)
                                    {
                                        #region ImprimirNotasDeCredito
                                        case Definiciones.AccionPorLote.Imprimir:
                                            valorAsociado = Definiciones.Reportes.Tesoreria.NotaCreditoPersonaCaso;
                                            break;
                                        #endregion ImprimirNotasDeCredito
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.NOTA_CREDITO_PROVEEDOR:
                                    break;
                                case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                                    break;
                                case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                    break;
                                case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                                    switch (accion)
                                    {
                                        case Definiciones.AccionPorLote.CrearCasoDescuentoDocumentos:
                                            break;
                                        case Definiciones.AccionPorLote.Imprimir:
                                            valorAsociado = Definiciones.Reportes.Tesoreria.OrdenDePagoImpresion;
                                            break;
                                        case Definiciones.AccionPorLote.ImprimirCheque:
                                            valorAsociado = (decimal)datos["reporte_id"];
                                            break;
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.PAGO_DE_PERSONAS:
                                    switch (accion)
                                    {
                                        #region CrearCasoDepositoBancario
                                        case Definiciones.AccionPorLote.CrearCasoDepositoBancario:
                                            decimal total = decimal.Zero;
                                            StringBuilder pagos = new StringBuilder();

                                            // cuando se usa el listview personalizado los casos no se discriminan por caso sino por id
                                            Dictionary<int, int> ids = casos;

                                            foreach (KeyValuePair<int, int> id in ids)
                                            {
                                                casoId = id.Key;
                                                flujoId = id.Value;
                                                total += CBA.FlowV2.Services.Tesoreria.PagosDePersonaService.GetMontoEfectivo(casoId);
                                                if (pagos.Length > 0) pagos.Append("\n");
                                                pagos.Append(CBA.FlowV2.Services.Tesoreria.PagosDePersonaService.GetInfoPago(casoId));
                                            }

                                            decimal casoDeposito = Definiciones.Error.Valor.EnteroPositivo;
                                            string casoEstado = string.Empty;

                                            
                                            datos.Add(DepositosBancariosService.Observacion_NombreCol, pagos.ToString());
                                            DepositosBancariosService.Guardar(datos, true, ref casoDeposito, ref casoEstado);
                                            var depositoId = DepositosBancariosService.GetDepositosBancariosDataTable(CBA.FlowV2.Services.Tesoreria.DepositosBancariosService.CasoId_NombreCol + " = " + casoDeposito, string.Empty).Rows[0][CBA.FlowV2.Services.Tesoreria.DepositosBancariosService.Id_NombreCol];

                                            //Agregar un detalle por la suma del efectivo
                                            Hashtable campos;

                                            if (total > 0)
                                            {
                                                campos = new Hashtable();
                                                campos.Add(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol, (decimal)depositoId);
                                                campos.Add(DepositosBancariosDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Efectivo);
                                                campos.Add(DepositosBancariosDetalleService.Importe_NombreCol, total);
                                                DepositosBancariosDetalleService.Guardar(campos, sesion);
                                            }

                                            //Agregar cada cheque
                                            foreach (KeyValuePair<int, int> id in ids)
                                            {
                                                var dtPago = PagosDePersonaService.GetPagosDePersonaDataTable(PagosDePersonaService.CasoId_NombreCol + " = " + id.Key, string.Empty, sesion);
                                                var dtPagoDet = CuentaCorrientePagosPersonaDetalleService.GetCuentaCorrientePagosPersonaDetalleDataTable(CuentaCorrientePagosPersonaDetalleService.CtactePagoPersonaId_NombreCol + " = " + dtPago.Rows[0][PagosDePersonaService.Id_NombreCol] + " and " + CuentaCorrientePagosPersonaDetalleService.CtacteValorId_NombreCol + " = " + Definiciones.CuentaCorrienteValores.Cheque, CuentaCorrientePagosPersonaDetalleService.Id_NombreCol, sesion);
                                                for (int i = 0; i < dtPagoDet.Rows.Count; i++)
                                                {
                                                    campos = new System.Collections.Hashtable();
                                                    campos.Add(DepositosBancariosDetalleService.DepositoBancarioId_NombreCol, (decimal)depositoId);
                                                    campos.Add(DepositosBancariosDetalleService.CtacteValorId_NombreCol, Definiciones.CuentaCorrienteValores.Cheque);
                                                    campos.Add(DepositosBancariosDetalleService.CtacteChequeRecibidoId_NombreCol, dtPagoDet.Rows[i][CuentaCorrientePagosPersonaDetalleService.CtacteChequeRecibidoId_NombreCol]); 
                                                    campos.Add(DepositosBancariosDetalleService.Importe_NombreCol, dtPagoDet.Rows[i][CuentaCorrientePagosPersonaDetalleService.Monto_NombreCol]);
                                                    DepositosBancariosDetalleService.Guardar(campos, sesion);
                                                }
                                            }

                                            foreach (KeyValuePair<int, int> id in ids)
                                            {
                                                cabeceraId = id.Key;
                                                flujoId = id.Value;
                                                CBA.FlowV2.Services.Tesoreria.PagosDePersonaService.SetCasoAsociado(decimal.Parse(cabeceraId.ToString()), casoDeposito, sesion);  
                                            }

                                            valorAsociado = casoDeposito;

                                            break;

                                        #endregion CrearCasoDepositoBancario
                                        case Definiciones.AccionPorLote.ImprimirRecibo:
                                            valorAsociado = Definiciones.Reportes.Tesoreria.Recibo;
                                            break;
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.PEDIDO_A_PROVEEDOR:
                                    break;
                                case Definiciones.FlujosIDs.PEDIDO_DE_CLIENTE:
                                    break;
                                case Definiciones.FlujosIDs.PLANILLA_DE_PAGOS:
                                    break;
                                case Definiciones.FlujosIDs.PLANILLA_LIQUIDACIONES:
                                    break;
                                case Definiciones.FlujosIDs.PRESUPUESTOS:
                                    break;
                                case Definiciones.FlujosIDs.REMISIONES:
                                    break;
                                case Definiciones.FlujosIDs.REPARTO:
                                    break;
                                case Definiciones.FlujosIDs.STOCK_INVENTARIO:
                                    break;
                                case Definiciones.FlujosIDs.SUGERENCIAS:
                                    break;
                                case Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA:
                                    switch (accion)
                                    {
                                        case Definiciones.AccionPorLote.Imprimir:
                                            valorAsociado = Definiciones.Reportes.Tesoreria.TransferenciasBancariasCaso;
                                            //throw new Exception("Acción no implementada");//Falta adaptar el reporte para imprimir multiples casos
                                            break;
                                        case Definiciones.AccionPorLote.ImprimirCheque:
                                            valorAsociado = (decimal)datos["reporte_id"];
                                            break;
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA:
                                    break;
                                case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:
                                    break;
                                case Definiciones.FlujosIDs.USO_DE_INSUMOS:
                                    break;
                                case Definiciones.FlujosIDs.USUARIOS:
                                    break;
                                case Definiciones.FlujosIDs.CREDITOS:
                                    switch (accion)
                                    {
                                        case Definiciones.AccionPorLote.GenerarFacturaProveedor:

                                            Dictionary<int, int> ids = casos;
                                            decimal montoTotal = decimal.Zero;
                                            decimal casoFactura;
                                            Dictionary<decimal, CreditosService> dCreditos = new Dictionary<decimal, CreditosService>();

                                            foreach (KeyValuePair<int, int> id in ids)
                                            {
                                                dCreditos[id.Key] = ClaseCBA<CreditosService>.Instancia.GetPrimero<CreditosService>(new ClaseCBABase.Filtro { Columna = CreditosService.Modelo.CASO_IDColumnName, Valor = id.Key });

                                                if (dCreditos[id.Key].Caso.EstadoId != Definiciones.EstadosFlujos.Aprobado && dCreditos[id.Key].Caso.EstadoId != Definiciones.EstadosFlujos.Vigente)
                                                    throw new Exception("Solo se puede generar la factura con casos en estado APROBADO o VIGENTE");

                                                if (dCreditos[id.Key].CasoAsociadoId.HasValue)
                                                    throw new Exception("Algunos créditos ya están asociadas a facturas");

                                                montoTotal += dCreditos[id.Key].MontoTotal;
                                            }

                                            casoFactura = FacturasProveedorService.GenerarFacturaProveedor(datos, montoTotal);

                                            if (casoFactura.Equals(Definiciones.Error.Valor.EnteroPositivo))
                                                throw new Exception("Error al generar la factura"); 

                                            foreach (KeyValuePair<int, int> id in ids)
                                            {
                                                try
                                                {
                                                    dCreditos[id.Key].CasoAsociadoId = casoFactura;
                                                    dCreditos[id.Key].IniciarUsingSesion(sesion);
                                                    dCreditos[id.Key].Guardar();
                                                    dCreditos[id.Key].FinalizarUsingSesion();
                                                }
                                                catch
                                                {
                                                    dCreditos[id.Key].FinalizarUsingSesion();
                                                    throw;
                                                }
                                            }

                                            break;
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Accion no implementada " + accion + ".");
                                    }
                                    break;
                                case Definiciones.FlujosIDs.ORDENES_SERVICIO:
                                    break;
                                case Definiciones.FlujosIDs.TRAMITES:
                                    break;
                                case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL:
                                    break;
                                default:
                                    throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Flujo no implementado " + flujo_id + ".");
                            }
                            #endregion accion por flujo
                        }
                        sesion.CommitTransaction();
                    }
                    catch
                    {
                        sesion.RollbackTransaction();
                        throw;
                    }
                }
            }
            if (accionComun)
            {
                switch (accion)
                {
                    #region Accion Cambiar Estado
                    case Definiciones.AccionPorLote.CambiarEstado:
                        using (SessionService sesion = new SessionService())
                        {
                            try
                            {
                                sesion.BeginTransaction();
                                string estadoDestino = (string)datos["estadoDestino"];

                                Exception excepcionesCapturadas = new System.ArgumentException(string.Empty);
                                DataTable datatableAdvertencias = new DataTable();

                                object flujoEspecifico;

                                int auxInt;
                                foreach (KeyValuePair<int, int> caso in casos)
                                {
                                    if (!int.TryParse(caso.Key.ToString(), out auxInt))
                                        continue;

                                    int casoId = caso.Key;
                                    int flujoId = caso.Value;

                                    #region Instanciar el service segun flujo y cambiar estado
                                    switch (flujoId)
                                    {
                                        case Definiciones.FlujosIDs.ADELANTO_FUNCIONARIO:
                                            flujoEspecifico = new CBA.FlowV2.Services.RecursosHumanos.FuncionarioAdelantoService();
                                            break;
                                        case Definiciones.FlujosIDs.AJUSTE_BANCARIO:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.AjustesBancariosService();
                                            break;
                                        case Definiciones.FlujosIDs.AJUSTE_STOCK:
                                            flujoEspecifico = new CBA.FlowV2.Services.Stock.StockAjusteService();
                                            break;
                                        case Definiciones.FlujosIDs.ANTICIPO_PERSONA:
                                            flujoEspecifico = new CBA.FlowV2.Services.Anticipo.AnticiposPersonaService();
                                            break;
                                        case Definiciones.FlujosIDs.ANTICIPO_PROVEEDOR:
                                            flujoEspecifico = new CBA.FlowV2.Services.Anticipo.AnticiposProveedorService();
                                            break;
                                        case Definiciones.FlujosIDs.ASIGNACION_CARGOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.RecursosHumanos.AsignacionCargosService();
                                            break;
                                        case Definiciones.FlujosIDs.CAMBIO_DIVISA:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.CambiosDivisaService();
                                            break;
                                        case Definiciones.FlujosIDs.CANJES_VALORES:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.CanjesValoresService();
                                            break;
                                        case Definiciones.FlujosIDs.CONTRATOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Contratos.ContratosService();
                                            break;
                                        case Definiciones.FlujosIDs.CREDITOS_PROVEEDOR:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.CreditosProveedorService();
                                            break;
                                        case Definiciones.FlujosIDs.CUSTODIA_DE_VALORES:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.CustodiaValoresService();
                                            break;
                                        case Definiciones.FlujosIDs.DEPOSITO_BANCARIO:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.DepositosBancariosService();
                                            break;
                                        case Definiciones.FlujosIDs.DESEMBOLSOS_GIROS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Giros.DesembolsosGirosService();
                                            break;
                                        case Definiciones.FlujosIDs.DESCUENTO_DE_DOCUMENTOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.DescuentoDocumentosService();
                                            break;
                                        case Definiciones.FlujosIDs.EGRESO_VARIO_CAJA:
                                            flujoEspecifico = new CBA.FlowV2.Services.EgresosVariosCaja.EgresosVariosCajaService();
                                            break;
                                        case Definiciones.FlujosIDs.ENCUESTAS:
                                            flujoEspecifico = new CBA.FlowV2.Services.RecursosHumanos.EncuestasService();
                                            break;
                                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                                            flujoEspecifico = new CBA.FlowV2.Services.Facturacion.FacturasClienteService();
                                            break;
                                        case Definiciones.FlujosIDs.FACTURACION_PROVEEDOR:
                                            flujoEspecifico = new CBA.FlowV2.Services.Facturacion.FacturasProveedorService();
                                            break;
                                        case Definiciones.FlujosIDs.INGRESO_DE_STOCK:
                                            flujoEspecifico = new CBA.FlowV2.Services.Stock.IngresoStockService();
                                            break;
                                        case Definiciones.FlujosIDs.MODIFICAR_LISTA_PRECIOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.ListaDePrecio.ListaDePreciosModificarService();
                                            break;
                                        case Definiciones.FlujosIDs.MOVIMIENTO_VARIO_TESORERIA:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.MovimientoVarioCajaTesoreriaService();
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:
                                            flujoEspecifico = new CBA.FlowV2.Services.NotasCreditoPersona.NotasCreditoPersonaService();
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_CREDITO_PROVEEDOR:
                                            flujoEspecifico = new CBA.FlowV2.Services.NotaCreditosProveedores.NotasCreditoProveedorService();
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_DEBITO_PERSONA:
                                            flujoEspecifico = new CBA.FlowV2.Services.NotasDebitoPersona.NotasDebitoPersonaService();
                                            break;
                                        case Definiciones.FlujosIDs.NOTA_DEBITO_PROVEEDOR:
                                            flujoEspecifico = new CBA.FlowV2.Services.NotasDebitoProveedor.NotasDebitoProveedorService();
                                            break;
                                        case Definiciones.FlujosIDs.ORDEN_DE_PAGO:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.OrdenesPagoService();
                                            break;
                                        case Definiciones.FlujosIDs.PAGO_DE_PERSONAS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.PagosDePersonaService();
                                            break;
                                        case Definiciones.FlujosIDs.PEDIDO_A_PROVEEDOR:
                                            throw new Exception("Flujo Pedido a Proveedor no implementado.");
                                        case Definiciones.FlujosIDs.PEDIDO_DE_CLIENTE:
                                            flujoEspecifico = new CBA.FlowV2.Services.Facturacion.NotasDePedidosService();
                                            break;
                                        case Definiciones.FlujosIDs.PLANILLA_DE_PAGOS:
                                            throw new Exception("Flujo Planilla de Pagos no implementado.");
                                        case Definiciones.FlujosIDs.PLANILLA_LIQUIDACIONES:
                                            flujoEspecifico = new CBA.FlowV2.Services.RecursosHumanos.PlanillaLiquidacionesService();
                                            break;
                                        case Definiciones.FlujosIDs.PRESUPUESTOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Presupuestos.PresupuestosService();
                                            break;
                                        case Definiciones.FlujosIDs.REMISIONES:
                                            flujoEspecifico = new CBA.FlowV2.Services.Facturacion.RemisionesService();
                                            break;
                                        case Definiciones.FlujosIDs.REPARTO:
                                            flujoEspecifico = new CBA.FlowV2.Services.Facturacion.RepartosService();
                                            break;
                                        case Definiciones.FlujosIDs.STOCK_INVENTARIO:
                                            flujoEspecifico = new CBA.FlowV2.Services.Stock.StockInventarioService();
                                            break;
                                        case Definiciones.FlujosIDs.SUGERENCIAS:
                                            flujoEspecifico = new CBA.FlowV2.Services.RecursosHumanos.SugerenciasService();
                                            break;
                                        case Definiciones.FlujosIDs.TRANSFERENCIA_BANCARIA:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.TransferenciasBancariasService();
                                            break;
                                        case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_TESORERIA:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.TransferenciasCajasTesoreriaService();
                                            break;
                                        case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Stock.StockTransferenciasService();
                                            break;
                                        case Definiciones.FlujosIDs.USO_DE_INSUMOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Stock.UsoDeInsumosService();
                                            break;
                                        case Definiciones.FlujosIDs.USUARIOS:
                                            flujoEspecifico = new CBA.FlowV2.Services.Herramientas.UsuariosService();
                                            break;
                                        case Definiciones.FlujosIDs.CREDITOS:
                                            flujoEspecifico = CreditosService.GetPorCaso(casoId, sesion);
                                            break;
                                        case Definiciones.FlujosIDs.ORDENES_SERVICIO:
                                            flujoEspecifico = new CBA.FlowV2.Services.Facturacion.OrdenesServicioService();
                                            break;
                                        case Definiciones.FlujosIDs.TRAMITES:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tramites.TramitesService();
                                            break;
                                        case Definiciones.FlujosIDs.TRANSFERENCIA_CAJAS_SUCURSAL:
                                            flujoEspecifico = new CBA.FlowV2.Services.Tesoreria.TransferenciaCajasSucursalService();
                                            break;
                                        default:
                                            throw new Exception("Error en GestionCasosPorLote.EjecutarAccion(). Flujo no implementado " + flujoId + ".");
                                    }
                                    string estado_anterior;
                                    string estado_siguiente = estadoDestino;

                                    while (estado_siguiente != string.Empty)
                                    {
                                        try
                                        {
                                            estado_anterior = CasosService.GetEstadoCaso(casoId, sesion);

                                            //Hasta que termine la conversion a OO debe diferenciarse segun tipo
                                            if (flujoEspecifico.GetType().IsSubclassOf(typeof(FlujosServiceBaseWorkaround)))
                                            {
                                                ((FlujosServiceBaseWorkaround)flujoEspecifico).IniciarUsingSesion(sesion);

                                                string msgAsociado = string.Empty;
                                                bool exito = ((FlujosServiceBaseWorkaround)flujoEspecifico).ProcesarCambioEstado(casoId, estado_siguiente, true, out msgAsociado, sesion);
                                                if (exito)
                                                    (new CBA.FlowV2.Services.ToolbarFlujo.ToolbarFlujoService()).ProcesarCambioEstado(casoId, estado_siguiente, "cambio de estado por lote desde buscador", sesion);
                                                if (exito)
                                                    ((FlujosServiceBaseWorkaround)flujoEspecifico).EjecutarAccionesLuegoDeCambioEstado(casoId, estado_siguiente, sesion);

                                                ((FlujosServiceBaseWorkaround)flujoEspecifico).FinalizarUsingSesion();
                                            }
                                            else
                                            {
                                                ((ClaseCBABase)flujoEspecifico).IniciarUsingSesion(sesion);
                                                ((IFlujo)flujoEspecifico).ProcesarCambioEstado(estado_siguiente, true, new ToolbarFlujoService.ComentarioTransicion { texto = "cambio de estado en lote desde buscador" }, sesion);
                                                ((ClaseCBABase)flujoEspecifico).FinalizarUsingSesion();
                                            }

                                            estado_siguiente = TransicionesAceleradorService.GetEstadoDestinoDeSiguienteTransicion(flujoId, estado_anterior, estado_siguiente, sesion);
                                        }
                                        catch (Exception exp)
                                        {
                                            advertencias.Add(casoId, exp.Message);
                                            estado_siguiente = string.Empty;
                                        }
                                    }
                                    #endregion Instanciar el service segun flujo y cambiar estado
                                }

                                sesion.CommitTransaction();
                            }
                            catch
                            {
                                sesion.RollbackTransaction();
                                throw;
                            }
                        }
                        break;
                    #endregion Accion Cambiar Estado
                }
            }
        }

        #region CargarDatatableResultado
        private static void CargarDatatableResultado(decimal caso, string mensaje, ref DataTable datatable)
        {
            DataColumn column;
            DataRow row;

            String Columna1 = "Caso";
            String Columna2 = "Mensaje";

            if (datatable.Columns.Count == 0)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Decimal");
                column.ColumnName = Columna1;
                datatable.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.String");
                column.ColumnName = Columna2;
                datatable.Columns.Add(column);
            }

            row = datatable.NewRow();
            row[Columna1] = caso;
            row[Columna2] = mensaje;
            datatable.Rows.Add(row);

        }
        #endregion CargarDatatableResultado

        #region Accessors

        public static string Nombre_tabla
        {
            get { return "FLUJOS"; }
        }
        public static string DescripcionImpresion_NombreCol
        {
            get { return FLUJOSCollection.DESCRIPCION_IMPRESIONColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return FLUJOSCollection.DESCRIPCIONColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return FLUJOSCollection.ENTIDAD_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FLUJOSCollection.IDColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return FLUJOSCollection.ORDENColumnName; }
        }
        public static string RolCreacionId_NombreCol
        {
            get { return FLUJOSCollection.ROL_CREACION_IDColumnName; }
        }

        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected FLUJOSRow row;
        protected FLUJOSRow rowSinModificar;
        public class Modelo : FLUJOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Descripcion { get { return row.DESCRIPCION; } set { row.DESCRIPCION = value; } }
        public string DescripcionImpresion { get { return row.DESCRIPCION_IMPRESION; } set { row.DESCRIPCION_IMPRESION = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? Orden { get { if (row.IsORDENNull) return null; else return row.ORDEN; } set { if (value.HasValue) row.ORDEN = value.Value; else row.IsORDENNull = true; } }
        public decimal? RolCreacionId { get { if (row.IsROL_CREACION_IDNull) return null; else return row.ROL_CREACION_ID; } set { if (value.HasValue) row.ROL_CREACION_ID = value.Value; else row.IsROL_CREACION_IDNull = true; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.FLUJOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new FLUJOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }
            
            this.rowSinModificar = this.row.Clonar();
        }

        public FlujosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public FlujosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public FlujosService(decimal id) 
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
