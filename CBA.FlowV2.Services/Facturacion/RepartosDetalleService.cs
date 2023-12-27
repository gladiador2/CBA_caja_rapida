using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Stock;

namespace CBA.FlowV2.Services.Facturacion
{
    public class RepartosDetalleService
    {

        #region ObtenerSiguienteSecuencia
        /// <summary>
        /// Obteners the siguiente secuencia.
        /// </summary>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static decimal ObtenerSiguienteSecuencia(SessionService sesion) {
            DataTable seq = new DataTable();
            seq = sesion.Db.EjecutarQuery("select repartos_detalle_sqc.nextval from dual");
            return seq.Rows[0].Field<Decimal>(0);
        }
        #endregion ObtenerSiguienteSecuencia

        #region CasoEstaEnRepartoEnProceso
        public static bool CasoEstaEnRepartoEnProceso(decimal casoId) {
            string clausula = RepartosDetalleService.CasoId_NombreCol + " = " + casoId.ToString();
            DataTable existencia = GetRepartosDetallesInfoCompleta(clausula);
            if (existencia.Rows.Count > 0)
                //si existe, se debe verificar que el estado del caso de reparto esta en estado viajando
                if (CasosService.GetEstadoCaso((decimal)RepartosService.GetReparto((decimal)existencia.Rows[0][RepartosDetalleService.RepartoId_NombreCol]).CASO_ID).Equals(Definiciones.EstadosFlujos.Viajando))
                    return true;
            return false;
        }
        #endregion CasoEstaEnRepartoEnProceso

        #region CasoEstaEnReparto
        public static bool CasoEstaEnReparto(decimal casoId)
        {
            // Si un caso (FC o Nota de crédito) ha sido incluido en un caso de reparto y ha tenido entrega exitosa no debe volver a incluirse en nuevos casos de reparto.
            // Comente la sig linea y agregue otra sin la verificacion de 'EntregaExitosa' ya que, aun cuando la Nota de Credito se encuentre pendiente de rendicion la misma
            // ya esta anclada a su caso de reparto correspondiente y no debe estar disponible para otros repartos.
            //string clausula = RepartosDetalleService.CasoId_NombreCol + " = " + casoId.ToString() + " and " + RepartosDetalleService.EntregaExitosa_NombreCol + " like " + "'S'";
            string clausula = RepartosDetalleService.CasoId_NombreCol + " = " + casoId.ToString()+" and " + RepartosDetalleService.EntregaExitosa_NombreCol + " = " + "'S'";

            DataTable existencia = GetRepartosDetallesInfoCompleta(clausula);

            if (existencia.Rows.Count > 0)
                return true;
            return false;
        }
        #endregion CasoEstaEnRepartoEnProceso

        #region Getters
        public static DataTable GetRepartosDetallesInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REPARTO_DETALLES_INFO_COMPLETACollection.GetAsDataTable(clausulas, string.Empty);
            }
        }

        /// <summary>
        /// Gets the reparto detalle row.
        /// </summary>
        /// <param name="reparto_detalle_id">The reparto_detalle_id.</param>
        /// <returns></returns>
        public DataRow GetRepartoDetalleRow(Decimal reparto_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.REPARTOS_DETALLECollection.GetAsDataTable(RepartosDetalleService.Id_NombreCol + " = " + reparto_detalle_id, string.Empty);
                return table.Rows[0];
            }
        }

        /// <summary>
        /// Gets the reparto detalle.
        /// </summary>
        /// <param name="reparto_id">The reparto_id.</param>
        /// <returns></returns>
        public DataTable GetRepartoDetalle(Decimal reparto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.REPARTOS_DETALLECollection.GetAsDataTable(RepartosDetalleService.RepartoId_NombreCol + " = " + reparto_id, string.Empty);
                return table;
            }
        }

        /// <summary>
        /// Obtener un array de los numero de casos de FC contenidos en el Reparto.
        /// </summary>
        /// <param name="reparto_id">The reparto_id.</param>
        /// <returns></returns>
        public static int[] GetRepartoDetalleCasos(Decimal reparto_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                REPARTOS_DETALLERow[] detalles;
                detalles = sesion.Db.REPARTOS_DETALLECollection.GetByREPARTO_ID(reparto_id);
                
                int[] resultado = new int[detalles.Length];
                for (int i = 0; i < detalles.Length; i++) 
                {
                    resultado[i] = (int)detalles[i].CASO_ID;
                }
                return resultado;
            }
        }

        public static DataTable GetRepartoDetalles(Decimal reparto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.REPARTO_DETALLES_INFO_COMPLETACollection.GetAsDataTable(RepartosDetalleService.RepartoId_NombreCol + " = " + reparto_id, RepartosDetalleService.Orden_NombreCol); ;
            }
        }

        /// <summary>
        /// Obtener un numero indicando si (-1) el detalle no existe o no esta definido, (0) entrega no exitosa, (1) entrega exitosa
        /// </summary>
        /// <param name="reparto_id">The reparto_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns></returns>
        public static int GetRepartoDetalleResultadoExitoso(decimal reparto_id, decimal caso_id) 
        {
            using (SessionService sesion = new SessionService())
            {
                string where = RepartosDetalleService.RepartoId_NombreCol + " = " + reparto_id + " and " + RepartosDetalleService.CasoId_NombreCol + " = " + caso_id;
                REPARTOS_DETALLERow[] detalle = sesion.Db.REPARTOS_DETALLECollection.GetAsArray(where,"");

                //Si no se existe el detalle
                if (!(detalle.Length > 0)) return Definiciones.Error.Valor.IntPositivo;
                //Si el campo contiene null o vacio
                else if (detalle[0].ENTREGA_EXITOSA == null || detalle[0].ENTREGA_EXITOSA.Equals(DBNull.Value)
                        || detalle[0].ENTREGA_EXITOSA.Length == 0)
                         return Definiciones.Error.Valor.IntPositivo;
                //Si el campo contiene Si
                else if (detalle[0].ENTREGA_EXITOSA.Equals(Definiciones.SiNo.Si)) return 1;
                //Si el campo contiene No
                else if (detalle[0].ENTREGA_EXITOSA.Equals(Definiciones.SiNo.No)) return 0;
                else return Definiciones.Error.Valor.IntPositivo;
            }
        }
        

        #endregion Getters

        #region ReordenarDetalles
        /// <summary>
        /// Reordenars the detalles.
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <param name="operacion">The operacion.</param>
        public static void ReordenarDetalles(decimal caso_id, decimal operacion)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    REPARTOS_DETALLERow[] rows = sesion.Db.REPARTOS_DETALLECollection.GetByCASO_ID(caso_id);
                    REPARTOS_DETALLERow row = rows[0];
                    REPARTOS_DETALLERow[] detalles = sesion.Db.REPARTOS_DETALLECollection.GetByREPARTO_ID(row.REPARTO_ID);
                    decimal aux = 0;
                    if (operacion == Definiciones.OrdenOperacion.Subir)
                    {
                       
                        foreach (REPARTOS_DETALLERow det in detalles)
                        {
                            if (row.ORDEN > 1)
                            {
                                if (row.ID != det.ID)
                                {
                                    if ((row.ORDEN - det.ORDEN) == 1)
                                    {
                                        aux = det.ORDEN;
                                        det.ORDEN = row.ORDEN;
                                        sesion.Db.REPARTOS_DETALLECollection.Update(det);

                                    }

                                }
                            }

                        }
                        
                    }
                    else 
                    {
                        foreach (REPARTOS_DETALLERow det in detalles)
                        {
                            if (!EsOrdenMayorPorReparto(row.REPARTO_ID, row.ORDEN))
                            {
                                if(row.ID != det.ID) 
                                {
                                    if ((det.ORDEN - row.ORDEN) == 1)
                                    {
                                        aux = det.ORDEN;
                                        det.ORDEN = row.ORDEN;
                                        sesion.Db.REPARTOS_DETALLECollection.Update(det);

                                    }

                                }
                            }

                        }
                    }
                    if (aux != 0)
                    {
                        row.ORDEN = aux;
                        sesion.Db.REPARTOS_DETALLECollection.Update(row);
                        sesion.Db.CommitTransaction();
                    }
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion ReordenarDetalles

        #region EsOrdenMayorPorReparto
        public static bool EsOrdenMayorPorReparto(decimal reparto_id, decimal orden)
        {
             using (SessionService sesion = new SessionService())
            {
                try
                {
                    REPARTOS_DETALLERow[] detalles = sesion.Db.REPARTOS_DETALLECollection.GetByREPARTO_ID(reparto_id);

                    decimal mayor = 0;
                    foreach (REPARTOS_DETALLERow det in detalles)
                    {
                        if (det.ORDEN > mayor)
                        {
                            mayor = det.ORDEN;
                        }
                    }
                    return mayor == orden;

                }
                catch (Exception exp)
                {
                    
                    throw exp;
                }
            }

        }

        #endregion EsOrdenMayorPorReparto

        #region MarcarDetalleResultadoEntrega
        /// <summary>
        /// Marcar el campo 'entrega exitosa' del detalle del Reparto.
        /// </summary>
        /// <param name="reparto_id">The reparto_id.</param>
        /// <param name="fc_caso_id">The fc_caso_id.</param>
        /// <param name="estado">El estado debe ser (-1) indefinido, (0) si no fue exitoso, (1) si fue exitoso.</param>
        public static void MarcarDetalleResultadoEntrega(decimal reparto_id, decimal caso_id, int estado) 
        { 
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    string clausulas = RepartosDetalleService.RepartoId_NombreCol + " = " + reparto_id + " and " +
                                       RepartosDetalleService.CasoId_NombreCol + " = " + caso_id;
                    REPARTOS_DETALLERow[] detalle = sesion.Db.REPARTOS_DETALLECollection.GetAsArray(clausulas, string.Empty);

                    if (detalle.Length != 1)
                    {
                        throw new System.ArgumentException("Error en MarcarDetalleResultadoEntrega(). Registro duplicado para reparto " + reparto_id + " y Caso " + caso_id + ".");
                    }

                    switch (estado)
                    {
                        case Definiciones.Error.Valor.IntPositivo: detalle[0].ENTREGA_EXITOSA = string.Empty; break;
                        case 0: detalle[0].ENTREGA_EXITOSA = Definiciones.SiNo.No; break;
                        case 1: detalle[0].ENTREGA_EXITOSA = Definiciones.SiNo.Si; break;
                        default: throw new System.ArgumentException("Error en MarcarDetalleResultadoEntrega(). El estado debe ser (-1) indefinido, (0) si no fue exitoso, (1) si fue exitoso.");
                    }

                    sesion.Db.REPARTOS_DETALLECollection.Update(detalle[0]);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion MarcarDetalleResultadoEntrega

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="reparto_id">The reparto_id.</param>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(decimal reparto_id, System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    REPARTOS_DETALLERow row = new REPARTOS_DETALLERow();
                    REPARTOSRow cabeceraRow;
                    CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();
                    FACTURAS_CLIENTERow cabeceraFC;
                    FACTURAS_CLIENTE_DETALLERow[] detallesFC;
                    ARTICULOSRow articuloRow;
                    ARTICULOS_DATOS_PERSONARow[] articuloDatosPersonaRows;
                    string casoFlujo = string.Empty;
                    string casoEstado = string.Empty;

                    string valorAnterior = "";
                    
                    if (insertarNuevo)
                    {
                        sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = ObtenerSiguienteSecuencia(sesion);
                        row.REPARTO_ID = decimal.Parse(campos[RepartosDetalleService.RepartoId_NombreCol].ToString());
                        sesion.Db.CommitTransaction();
                    }
                    else
                    {
                        row = sesion.Db.REPARTOS_DETALLECollection.GetByCASO_ID(decimal.Parse(campos[RepartosDetalleService.CasoId_NombreCol].ToString()))[0];
                        valorAnterior = row.ToString();
                    }

                    cabeceraRow = sesion.Db.REPARTOSCollection.GetByPrimaryKey(row.REPARTO_ID);

                    row.CASO_ID = decimal.Parse(campos[RepartosDetalleService.CasoId_NombreCol].ToString());
                    
                    CasosService.GetFlujoYEstado(row.CASO_ID, ref casoFlujo, ref casoEstado, sesion);
                   
                    row.OBSERVACION = campos[RepartosDetalleService.Observacion_NombreCol].ToString();

                    if (campos.Contains(Bultos_NombreCol))
                        row.BULTOS = (decimal)campos[Bultos_NombreCol];

                    REPARTOS_DETALLERow[] detalles = sesion.Db.REPARTOS_DETALLECollection.GetByREPARTO_ID(row.REPARTO_ID);

                    decimal mayor = 0; 
                    foreach (REPARTOS_DETALLERow det in detalles)
                    {
                        if (det.ORDEN > mayor)
                        {
                            mayor = det.ORDEN;
                        }
                    }

                    row.ORDEN = mayor+1;

                    sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros

                    if (insertarNuevo) sesion.Db.REPARTOS_DETALLECollection.Insert(row);
                    else sesion.Db.REPARTOS_DETALLECollection.Update(row);
                    LogCambiosService.LogDeRegistro(RepartosDetalleService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                    
                    int flujoId = int.Parse(casoFlujo);
                    switch (flujoId)
                    {
                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                            if (casoEstado.Equals(Definiciones.EstadosFlujos.ParaReparto))
                            {   //Se debe cambiar de estado el caso de FC a En Reparto
                                cambioEstado.CambiarEstado(row.CASO_ID,
                                                           Definiciones.EstadosFlujos.EnReparto,
                                                           sesion.Usuario.ID,
                                                           sesion.Usuario.SESION,
                                                           "Transición utilizada al agregarse la FC como detalle del caso de Reparto Nro. " + cabeceraRow.CASO_ID + ".",
                                                           SessionService.GetClienteIP(), sesion);

                                //Se actualiza el codigo de barras con que sale el articulo
                                //dando preferencia en el siguiente orden: cod. segun persona, segun Empresa, segun proveedor.
                                cabeceraFC = sesion.Db.FACTURAS_CLIENTECollection.GetByCASO_ID(row.CASO_ID)[0];
                                detallesFC = sesion.Db.FACTURAS_CLIENTE_DETALLECollection.GetByFACTURAS_CLIENTE_ID(cabeceraRow.ID);
                                foreach (FACTURAS_CLIENTE_DETALLERow d in detallesFC)
                                {
                                    String where = ArticulosDatosPersonaService.ArticuloId_NombreCol + " = " + d.ARTICULO_ID + " and " + ArticulosDatosPersonaService.PersonaId_NombreCol + " = " + cabeceraFC.PERSONA_ID;
                                    articuloDatosPersonaRows = sesion.Db.ARTICULOS_DATOS_PERSONACollection.GetAsArray(where, "");
                                    articuloRow = sesion.Db.ARTICULOSCollection.GetByPrimaryKey(d.ARTICULO_ID);

                                    #region Buscar codigo
                                    d.ARTICULO_CODIGO = "";
                                    if (articuloDatosPersonaRows.Length > 0 && articuloDatosPersonaRows[0].CODIGO.Length > 0)
                                        d.ARTICULO_CODIGO = articuloDatosPersonaRows[0].CODIGO;
                                    else if (articuloRow.CODIGO_EMPRESA.Length > 0)
                                        d.ARTICULO_CODIGO = articuloRow.CODIGO_EMPRESA;
                                    else if (articuloRow.CODIGO_PROVEEDOR.Length > 0)
                                        d.ARTICULO_CODIGO = articuloRow.CODIGO_PROVEEDOR;
                                    #endregion Buscar codigo

                                    #region Buscar codigo de barras
                                    d.ARTICULO_CODIGO_BARRAS = "";
                                    if (articuloDatosPersonaRows.Length > 0 && articuloDatosPersonaRows[0].CODIGO_BARRAS.Length > 0)
                                        d.ARTICULO_CODIGO_BARRAS = articuloDatosPersonaRows[0].CODIGO_BARRAS;
                                    else if (articuloRow.CODIGO_BARRAS_EMPRESA != null && articuloRow.CODIGO_BARRAS_EMPRESA.Length > 0)
                                        d.ARTICULO_CODIGO_BARRAS = articuloRow.CODIGO_BARRAS_EMPRESA;
                                    else if (articuloRow.CODIGO_BARRAS_PROVEEDOR != null && articuloRow.CODIGO_BARRAS_PROVEEDOR.Length > 0)
                                        d.ARTICULO_CODIGO_BARRAS = articuloRow.CODIGO_BARRAS_PROVEEDOR;
                                    #endregion Buscar codigo de barras

                                    #region Buscar descripcion
                                    d.ARTICULO_DESCRIPCION = "";
                                    if (articuloDatosPersonaRows.Length > 0 && articuloDatosPersonaRows[0].DESCRIPCION.Length > 0)
                                        d.ARTICULO_DESCRIPCION = articuloDatosPersonaRows[0].DESCRIPCION;
                                    else if (articuloRow.DESCRIPCION_IMPRESION != null && articuloRow.DESCRIPCION_IMPRESION.Length > 0)
                                        d.ARTICULO_DESCRIPCION = articuloRow.DESCRIPCION_IMPRESION;
                                    else if (articuloRow.DESCRIPCION_PROVEEDOR != null && articuloRow.DESCRIPCION_PROVEEDOR.Length > 0)
                                        d.ARTICULO_DESCRIPCION = articuloRow.DESCRIPCION_PROVEEDOR;
                                    #endregion Buscar descripcion

                                    sesion.Db.FACTURAS_CLIENTE_DETALLECollection.Update(d);
                                }

                            }

                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:
                           

                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:

                            break;
                        default: throw new System.ArgumentException("Error Repartos Service, situacion para flujo no implementado");
                    }
                    sesion.Db.CommitTransaction();
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
        /// <summary>
        /// Borrars the specified factura_cliente_caso_id.
        /// </summary>
        /// <param name="factura_cliente_caso_id">The factura_cliente_caso_id.</param>
        public static void Borrar(decimal factura_cliente_caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CasosService caso = new CasosService();
                    REPARTOS_DETALLERow row = sesion.Db.REPARTOS_DETALLECollection.GetByCASO_ID(factura_cliente_caso_id)[0];
                    REPARTOSRow cabeceraRow = sesion.Db.REPARTOSCollection.GetByPrimaryKey(row.REPARTO_ID);
                    CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();
                    
                    sesion.Db.BeginTransaction();

                    
                    sesion.Db.REPARTOS_DETALLECollection.Delete(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    //Se debe pasar de estado la FC de Cliente a Para Reparto

                    int flujoId = int.Parse(CasosService.GetFlujo(row.CASO_ID, sesion).ToString());
                    
                    switch (flujoId)
                    {
                        case Definiciones.FlujosIDs.FACTURACION_CLIENTE:
                            if (CasosService.GetEstadoCaso(row.CASO_ID, sesion).Equals(Definiciones.EstadosFlujos.EnReparto))
                            {   //Se debe cambiar de estado el caso de FC a En Reparto
                                cambioEstado.CambiarEstado(row.CASO_ID,
                                                           Definiciones.EstadosFlujos.ParaReparto,
                                                           sesion.Usuario.ID,
                                                           sesion.Usuario.SESION,
                                                           "Transición utilizada al agregarse la FC como detalle del caso de Reparto Nro. " + cabeceraRow.CASO_ID + ".",
                                                           SessionService.GetClienteIP(), sesion);

                               
                                

                            }

                            break;
                        case Definiciones.FlujosIDs.TRANSFERENCIA_DE_ARTICULOS:
                            
                            break;

                        case Definiciones.FlujosIDs.NOTA_CREDITO_PERSONA:

                            break;
                        default: throw new System.ArgumentException("Error Repartos Service, situacion para flujo no implementado");
                    }
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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "REPARTOS_DETALLE"; }
        }
        //id 
        public static string Id_NombreCol
        {
            get { return REPARTOS_DETALLECollection.IDColumnName; }
        }
        //reparto_id 
        public static string RepartoId_NombreCol
        {
            get { return REPARTOS_DETALLECollection.REPARTO_IDColumnName; }
        }
        //caso_id
        public static string CasoId_NombreCol
        {
            get { return REPARTOS_DETALLECollection.CASO_IDColumnName; }
        }
        //observacion 
        public static string Observacion_NombreCol
        {
            get { return REPARTOS_DETALLECollection.OBSERVACIONColumnName; }
        }
        //entrega_exitosa 
        public static string EntregaExitosa_NombreCol
        {
            get { return REPARTOS_DETALLECollection.ENTREGA_EXITOSAColumnName; }
        }
        //orden
        public static string Orden_NombreCol
        {
            get { return REPARTOS_DETALLECollection.ORDENColumnName; }
        }
        //bultos
        public static string Bultos_NombreCol
        {
            get { return REPARTOS_DETALLECollection.BULTOSColumnName; }
        }
        #region Vista
        
        //caso_nro_comprobante
        public static string VistaCasoNroComprobante_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_NRO_COMPROBANTEColumnName; }
        }
        //caso_estado 
        public static string VistaCasoEstado_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }
        //fecha_caso 
        public static string VistaFechaCaso_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.FECHA_CASOColumnName; }
        }
        //persona_nombre_completo 
        public static string VistaPersonaNombreCompleto_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        //persona_departamento1_nombre 
        public static string VistaPersonaDepartamento1Nombre_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.PERSONA_DEPARTAMENTO1_NOMBREColumnName; }
        }
        //persona_ciudad1_nombre 
        public static string VistaPersonaCiudad1Nombre_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.PERSONA_CIUDAD1_NOMBREColumnName; }
        }
        //persona_barrio1_nombre 
        public static string VistaPersonaBarrio1Nombre_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.PERSONA_BARRIO1_NOMBREColumnName; }
        }
        //persona_calle1 
        public static string VistaPersonaCalle1_NombreCol 
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.PERSONA_CALLE1ColumnName; }
        }
        public static string VistaCasoFlujoId_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_FLUJO_IDColumnName; }
        }
        public static string VistaCasoFlujoDescripcion_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_FLUJO_DESCRIPColumnName; }
        }
        public static string VistaCasoFlujoDescripcionImpresion_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_FLUJO_DESC_IMPRColumnName; }
        }
        public static string VistaCasoSucursalId_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_SUCURSAL_IDColumnName; }
        }
        public static string VistaCasoSucursalNombre_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaCasoSucursalAbeviatura_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaTransferenciaSucursalDestinoId_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.TRANSF_SUCURSAL_DESTINO_IDColumnName; }
        }
        public static string VistaTransferenciaSucursalDestinoNombre_NombreCol
        {
            get { return REPARTO_DETALLES_INFO_COMPLETACollection.TRANSF_SUCURSAL_DESTINO_NOMBREColumnName; }
        }
        #endregion Vista

        #endregion Accessors

        public static class DocumentosDisponibles
        {

            #region GetCasosIncluidos

            public static DataTable GetCasosIncluidos(decimal repartoId) {
                DataTable result = new DataTable();
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.CasoId_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.Fecha_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.SucursalOrigenNombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.FlujoDescripcion_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.SucursalDestinoNombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.NroComprobante_NombreCol);

                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaBarrio1Nombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaCalle1_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaCiudad1Nombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaNombre_NombreCol); ;
                using (SessionService sesion = new SessionService())
                {
                    string clausula = RepartosDetalleService.RepartoId_NombreCol + " = " + repartoId.ToString();
                    DataTable dtCasos = sesion.Db.REPARTO_DETALLES_INFO_COMPLETACollection.GetAsDataTable(clausula, string.Empty);
                    foreach (DataRow dr in dtCasos.Rows) {
                        DataRow insert = result.NewRow();
                        insert[RepartosDetalleService.DocumentosDisponibles.CasoId_NombreCol] = dr[RepartosDetalleService.CasoId_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.Fecha_NombreCol] = dr[RepartosDetalleService.VistaFechaCaso_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.SucursalOrigenNombre_NombreCol] = dr[RepartosDetalleService.VistaCasoSucursalNombre_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.FlujoDescripcion_NombreCol] = dr[RepartosDetalleService.VistaCasoFlujoDescripcionImpresion_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.NroComprobante_NombreCol] = dr[RepartosDetalleService.VistaCasoNroComprobante_NombreCol];
                        if ((decimal)dr[RepartosDetalleService.VistaCasoFlujoId_NombreCol] == 22)
                        {
                            insert[RepartosDetalleService.DocumentosDisponibles.SucursalDestinoNombre_NombreCol] = StockTransferenciasService.GetStockTransferenciaSucursalDestinoNombrePorCaso((decimal)dr[RepartosDetalleService.CasoId_NombreCol]);
                        }
                        else
                        {
                            insert[RepartosDetalleService.DocumentosDisponibles.SucursalDestinoNombre_NombreCol] = string.Empty;
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaBarrio1Nombre_NombreCol] = dr[RepartosDetalleService.VistaPersonaBarrio1Nombre_NombreCol];
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaCalle1_NombreCol] = dr[RepartosDetalleService.VistaPersonaCalle1_NombreCol];
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaCiudad1Nombre_NombreCol] = dr[RepartosDetalleService.VistaPersonaCiudad1Nombre_NombreCol];
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaNombre_NombreCol] = dr[RepartosDetalleService.VistaPersonaNombreCompleto_NombreCol];
                        }
                        result.Rows.Add(insert);
                    }
                    return result;
                }

            }

            #endregion GetCasosIncluidos


            #region GetCasosSegunFlujosEstados
            public static DataTable GetCasosSegunFlujosEstados(System.Collections.Hashtable configuracion, string filtroFecha)
            {
                return GetCasosSegunFlujosEstados(configuracion, 0, true, filtroFecha);
            }

            public static DataTable GetCasosSegunFlujosEstados(System.Collections.Hashtable configuracion, decimal sucursalId, bool usarSucursal, string filtroFecha)
            {
                DataTable result = new DataTable();
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.CasoId_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.Fecha_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.SucursalOrigenNombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.FlujoDescripcion_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.SucursalDestinoNombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.NroComprobante_NombreCol);

                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaBarrio1Nombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaCalle1_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaCiudad1Nombre_NombreCol);
                result.Columns.Add(RepartosDetalleService.DocumentosDisponibles.PersonaNombre_NombreCol);
                

                string clausula = string.Empty;
                

                clausula += filtroFecha;

                if (!clausula.Equals(string.Empty))
                        clausula += " and (";

                
                //if (usarSucursal) clausula = CasosService.SucursalId_NombreCol + " = " + sucursalId + " and ";

                bool primero = true;
                foreach (System.Collections.DictionaryEntry flujo in configuracion)
                {
                    string[] estados = (string[])flujo.Value;

                    if (!primero) clausula += " or ";

                    if (usarSucursal)
                    {
                        clausula += "(" + CasosService.SucursalId_NombreCol + " = " + sucursalId + " and " +
                            CasosService.FlujoId_NombreCol + " = " + flujo.Key.ToString() + " and " +
                            CasosService.EstadoId_NombreCol + CBAV2.CrearClausulaIn(estados, true) + ")";
                    }
                    else
                    {
                        clausula += "(" + CasosService.FlujoId_NombreCol + " = " + flujo.Key.ToString() + " and " +
                            CasosService.EstadoId_NombreCol + CBAV2.CrearClausulaIn(estados, true) + ")";
                    }

                    primero = false;
                }
                clausula += ")";
                using (SessionService sesion = new SessionService())
                {
                    DataTable dtCasos = sesion.Db.CASOS_INFO_COMPLETACollection.GetAsDataTable(clausula, string.Empty);
                    foreach (DataRow dr in dtCasos.Rows) {
                        DataRow insert = result.NewRow();

                        /* En el sig. 'if' solo para las Notas de Credito se verifica si ya esta incluido en un caso de reparto,
                         * ya que todas las FC traidas a <dtCasos> estan en PARA-REPARTO y no es necesario realizar dicha verificacion,
                         * pues si estuvieran en un caso de reparto su estado seria EN-REPARTO y serian traidos a 'dtCasos'.
                         * En el caso de las Transferencias de Stock las que esten en APROBADO Y no esten incluidas en otro reparto
                         */
                        if ((decimal)dr[CasosService.FlujoId_NombreCol] == 12 && RepartosDetalleService.CasoEstaEnReparto((decimal)dr[CasosService.Id_NombreCol]))
                            continue;
                        if ((decimal)dr[CasosService.FlujoId_NombreCol] == 22 && RepartosDetalleService.CasoEstaEnReparto((decimal)dr[CasosService.Id_NombreCol]))
                            continue;

                        //
                        insert[RepartosDetalleService.DocumentosDisponibles.CasoId_NombreCol] = dr[CasosService.Id_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.Fecha_NombreCol] = dr[CasosService.FechaCreacion_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.SucursalOrigenNombre_NombreCol] = dr[CasosService.VistaSucursalNombre_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.FlujoDescripcion_NombreCol] = dr[CasosService.VistaFlujoDescripcionImp_NombreCol];
                        insert[RepartosDetalleService.DocumentosDisponibles.NroComprobante_NombreCol] =  dr[CasosService.NroComprobante_NombreCol];
                        if ((decimal)dr[CasosService.FlujoId_NombreCol] == 22)
                        {
                            insert[RepartosDetalleService.DocumentosDisponibles.SucursalDestinoNombre_NombreCol] = StockTransferenciasService.GetStockTransferenciaSucursalDestinoNombrePorCaso((decimal)dr[CasosService.Id_NombreCol]);
                        }
                        else
                        {
                            insert[RepartosDetalleService.DocumentosDisponibles.SucursalDestinoNombre_NombreCol] = string.Empty;
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaBarrio1Nombre_NombreCol] = PersonasService.GetPersonaInfoCompletaRow((decimal)dr[CasosService.PersonaId_NombreCol]).BARRIO1_NOMBRE;
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaCalle1_NombreCol] = PersonasService.GetPersonaInfoCompletaRow((decimal)dr[CasosService.PersonaId_NombreCol]).CALLE1;
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaCiudad1Nombre_NombreCol] = PersonasService.GetPersonaInfoCompletaRow((decimal)dr[CasosService.PersonaId_NombreCol]).CIUDAD1_NOMBRE;
                            insert[RepartosDetalleService.DocumentosDisponibles.PersonaNombre_NombreCol] = dr[CasosService.VistaPersonaNombre_NombreCol];
                        }
                        result.Rows.Add(insert);
                    }
                    return result;
                }
            }

            public static DataTable GetCasosSegunFlujosEstadosYDeposito(System.Collections.Hashtable configuracion, decimal depositoId, string filtroFecha)
            {
                return GetCasosSegunFlujosEstados(configuracion, StockDepositosService.GetStockDeposito(depositoId).SUCURSAL_ID, true, filtroFecha);
            }
            #endregion GetCasosSegunFlujosEstados 

            #region Accessors

            public static string Fecha_NombreCol
            {
                get { return RepartosDetalleService.VistaFechaCaso_NombreCol; }
            }
            public static string NroComprobante_NombreCol
            {
                get { return RepartosDetalleService.VistaCasoNroComprobante_NombreCol; }
            }
            public static string CasoId_NombreCol
            {
                get { return RepartosDetalleService.CasoId_NombreCol; }
            }
            public static string PersonaNombre_NombreCol
            {
                get { return RepartosDetalleService.VistaPersonaNombreCompleto_NombreCol; }
            }
            public static string PersonaCiudad1Nombre_NombreCol
            {
                get { return RepartosDetalleService.VistaPersonaCiudad1Nombre_NombreCol; }
            }
            public static string PersonaBarrio1Nombre_NombreCol
            {
                get { return RepartosDetalleService.VistaPersonaBarrio1Nombre_NombreCol; }
            }
            public static string PersonaCalle1_NombreCol
            {
                get { return RepartosDetalleService.VistaPersonaCalle1_NombreCol; }
            }
            public static string FlujoDescripcion_NombreCol
            {
                get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_FLUJO_DESC_IMPRColumnName; }
            }
            public static string SucursalOrigenNombre_NombreCol
            {
                get { return REPARTO_DETALLES_INFO_COMPLETACollection.CASO_SUCURSAL_NOMBREColumnName; }
            }
            public static string SucursalDestinoNombre_NombreCol
            {
                get { return REPARTO_DETALLES_INFO_COMPLETACollection.TRANSF_SUCURSAL_DESTINO_NOMBREColumnName; }
            }
            #endregion Accessors

        }

    }
}
