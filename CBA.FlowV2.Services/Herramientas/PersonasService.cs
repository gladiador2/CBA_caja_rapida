#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;

using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Tesoreria;
using System.Collections;
using System.Globalization;
using CBA.FlowV2.Services.Facturacion;
using System.Text.RegularExpressions;
using CBA.FlowV2.Services.Casos;
using System.Collections.Generic;
using System.Net;

using CBA.FlowV2.Services.Anticipo;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasService 
    {
        #region Persona - Clase utilizada principalmente por WebServices
        /// <summary>
        /// Clase utilizada principalmente por WebServices
        /// </summary>
        public class Persona
        {
            #region propiedades
            public decimal Id;
            public string Nombre;
            public string Apellido;
            public decimal PaisId;
            public decimal DepartamentoId;
            public decimal CiudadId;
            public decimal BarrioId;
            public decimal ZonaCobranzaId;
            public string Calle;
            public string Telefono1;
            public string Telefono2;
            public string Telefono3;
            public string Telefono4;
            public string TelefonoCobranza1;
            public string TelefonoCobranza2;
            public string Email1;

            private string _NroDocumento;
            public string NroDocumento
            {
                get { return this._NroDocumento; }
                set
                {
                    //Solo se permiten caracteres alfanumericos
                    string pattern = @"^[a-zA-Z0-9]*$";
                    if (!Regex.IsMatch(value, pattern))
                        throw new Exception("El número de documento no debe contener separadores.");

                    this._NroDocumento = value;
                }
            }
            #endregion propiedades

            #region Constructores
            public Persona()
            {
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
                this.Nombre = string.Empty;
                this.Apellido = string.Empty;
                this.NroDocumento = string.Empty;
                this.PaisId = Definiciones.Error.Valor.EnteroPositivo;
                this.DepartamentoId = Definiciones.Error.Valor.EnteroPositivo;
                this.CiudadId = Definiciones.Error.Valor.EnteroPositivo;
                this.BarrioId = Definiciones.Error.Valor.EnteroPositivo;
                this.Calle = string.Empty;
            }
            #endregion Constructores

            #region Buscar
            public bool Buscar()
            {
                string clausulas = PersonasService.TipoDocumentoIdentidadId_NombreCol + " = '" + Definiciones.TiposDocumentoIdentidad.CI + "' and " + PersonasService.NumeroDocumento_NombreCol + " = '" + this.NroDocumento + "'";
                DataTable dt = PersonasService.GetPersonasDataTable2(clausulas, string.Empty, false);

                if (dt.Rows.Count > 0)
                {
                    this.Id = (decimal)dt.Rows[0][PersonasService.Id_NombreCol];
                    return true;
                }
                else
                {
                    this.Id = Definiciones.Error.Valor.EnteroPositivo;
                    return false;
                }
            }
            #endregion Buscar
        }
        #endregion Persona - Clase utilizada principalmente por WebServices

        #region Getters

        #region GetPersonasInfoCompleta
        /// <summary>
        /// Gets the personas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        [Obsolete("Utilizar los metodos estaticos.")]
        public DataTable GetPersonasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {

                return sesion.Db.PERSONAS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetPersonasInfoCompleta2(string clausulas, string orden)
        {
            return GetPersonasInfoCompleta2(clausulas, orden, false);
        }

        public static DataTable GetPersonasInfoCompleta2(string clausulas, string orden, bool busqueda_flexible, SessionService sesion)
        {
            if (busqueda_flexible)
                sesion.db.IniciarBusquedaFlexible();

            string where = PersonasService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
            if (clausulas.Length > 0) where += " and " + clausulas;

            DataTable dt = sesion.Db.PERSONAS_INFO_COMPLETACollection.GetAsDataTable(where, orden);

            if (busqueda_flexible)
                sesion.db.FinalizarBusquedaFlexible();

            return dt;
        }

        public static DataTable GetPersonasInfoCompleta2(string clausulas, string orden, bool busqueda_flexible)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPersonasInfoCompleta2(clausulas, orden, busqueda_flexible, sesion);
            }
        }
        public static DataTable GetPersonasInfoCompletaPorID(string persona_id)
        {
            string clausulas = PersonasService.Id_NombreCol + " = " + persona_id;
            return PersonasService.GetPersonasInfoCompleta2(clausulas, string.Empty);
        }

        public static DataTable GetPersonasInfoCompletaFiltrado(string pTexto)
        {
            return GetPersonasInfoCompletaFiltrado(pTexto, false);
        }

        public static DataTable GetPersonasInfoCompletaFiltrado(string pTexto, bool busqueda_flexible)
        {
            return GetPersonasInfoCompletaFiltrado(pTexto, string.Empty, busqueda_flexible);
        }

        public static DataTable GetPersonasInfoCompletaFiltrado(string pTexto, string restricciones, bool busqueda_flexible)
        {
            string filtro = string.Empty;
            string txt = pTexto.Replace(' ', '%').ToUpper();

            decimal cantidadMinimaCaracteres = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.BusquedaCantidadMinimaCaracteres);
            //Verificamos si se ingreso una cadena válida.
            if (pTexto.Trim().Length >= cantidadMinimaCaracteres)
            {
                filtro += " upper(" + PersonasService.NombreCompleto_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.Ruc_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.Codigo_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.CodigoExterno_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.NumeroDocumento_NombreCol + ") like '%" + txt + "%' ";

                if (restricciones.Length > 0)
                    filtro = "(" + filtro + ") and " + restricciones;

                return PersonasService.GetPersonasInfoCompleta2(filtro, PersonasService.NombreCompleto_NombreCol, busqueda_flexible);
            }
            else
            {
                throw new Exception("La cantidad mínima de carácteres de filtrado es " + cantidadMinimaCaracteres + ".");
            }
        }

        public static DataTable GetClientesInfoCompletaFiltrado(string pTexto)
        {
            string filtro = string.Empty;
            string txt = pTexto.Replace(' ', '%').ToUpper();

            decimal cantidadMinimaCaracteres = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.BusquedaCantidadMinimaCaracteres);
            //Verificamos si se ingreso una cadena válida.
            if (pTexto.Trim().Length >= cantidadMinimaCaracteres)
            {
                filtro = PersonasService.EsCliente_NombreCol + " = '" + Definiciones.SiNo.Si + "'";

                filtro += " and upper(" + PersonasService.NombreCompleto_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.Ruc_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.Codigo_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.CodigoExterno_NombreCol + ") like '%" + txt + "%' " +
                           " or upper(" + PersonasService.NumeroDocumento_NombreCol + ") like '%" + txt + "%' ";

                return PersonasService.GetPersonasInfoCompleta2(filtro, PersonasService.NombreCompleto_NombreCol);
            }
            else
            {
                throw new Exception("La cantidad mínima de carácteres de filtrado es " + cantidadMinimaCaracteres + ".");
            }
        }

        public static DataTable GetClientesInfoCompletaFiltradoId(string pTexto)
        {
            string filtro = string.Empty;
            string txt = pTexto.Replace(' ', '%').ToUpper();

            //Verificamos si se ingreso una cadena válida.
            filtro = PersonasService.Id_NombreCol + " = " + pTexto;

            return PersonasService.GetPersonasInfoCompleta2(filtro, PersonasService.NombreCompleto_NombreCol);
        }
        #endregion GetPersonasInfoCompleta

        #region GetPersonasDataTable
        /// <summary>
        /// Gets the personas data table ordered by lastname and name.
        /// </summary>
        /// <param name="soloActivos">Si es true se obtienen solo los personas activos.</param>
        /// <returns></returns>
        public DataTable GetPersonasDataTable(bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                String estado = "";
                if (soloActivos) estado = " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                DataTable table = sesion.Db.PERSONASCollection.GetAsDataTable(EntidadId_NombreCol + " = " + sesion.Entidad.ID + estado, "upper(" + Apellido_NombreCol + " ||' '|| " + Apellido_NombreCol + ")");
                return table;
            }
        }

        /// <summary>
        /// Gets the personas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public DataTable GetPersonasDataTable(string clausulas, string orden, bool soloActivos)
        {
            return PersonasService.GetPersonasDataTable2(clausulas, orden, soloActivos);
        }

        public static DataTable GetPersonasDataTable2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPersonasDataTable2(clausulas, orden, soloActivos, sesion);
            }
        }

        /// <summary>
        /// Gets the personas data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los personas activos.</param>
        /// <returns></returns>
        public static DataTable GetPersonasDataTable2(string clausulas, string orden, bool soloActivos, SessionService sesion)
        {
            DataTable table;
            string estado = string.Empty;
            if (soloActivos) estado = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            else estado = "1=1";
            //Realizar la busqueda sin importar tildes ni mayusculas
            sesion.Db.IniciarBusquedaFlexible();

            if (clausulas.Length > 0)
            {
                table = sesion.Db.PERSONASCollection.GetAsDataTable(clausulas + " and " + clausulas, orden);
            }
            else
            {
                table = sesion.Db.PERSONASCollection.GetAsDataTable(estado, orden);
            }

            //Finalizar el uso de busqueda sin importar tildes ni mayusculas
            sesion.Db.FinalizarBusquedaFlexible();

            return table;
        }

        /// <summary>
        /// Gets the personas data table with an user-specific order clause.
        /// </summary>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los personas activos.</param>
        /// <returns></returns>
        public static DataTable GetPersonasDataTable(string clausulas, string orden)
        {
            return new PersonasService().GetPersonasDataTable(clausulas, orden, false);
        }

        /// <summary>
        /// Gets the personas data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetPersonasDataTable()
        {
            return this.GetPersonasDataTable(string.Empty, "upper(" + Apellido_NombreCol + " ||' '|| " + Apellido_NombreCol + ")", false);
        }



        #endregion GetPersonasDataTable

        #region GetPersonasPorRuc
        /// <summary>
        /// Gets the personas por ruc data table.
        /// </summary>
        /// <param name="ruc">The ruc.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPersonasPorRuc(string ruc)
        {
            string clausulas = PersonasService.Ruc_NombreCol + " = '" + ruc + "'";
            return PersonasService.GetPersonasDataTable(clausulas, string.Empty);
        }
        #endregion

        #region GetPersonasPorDocumento
        /// <summary>
        /// Gets the personas por ruc data table.
        /// </summary>
        /// <param name="ruc">The ruc.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetPersonasPorDocumento(string documento)
        {
            string clausulas = PersonasService.NumeroDocumento_NombreCol + " = '" + documento + "'";
            return PersonasService.GetPersonasDataTable(clausulas, string.Empty);
        }
        #endregion

        #region GetPersonasPorCodigo
        public static DataTable GetPersonasPorCodigo(string codigo)
        {
            return GetPersonasPorCodigo(codigo, string.Empty);
        }

        /// <summary>
        /// Gets the personas por codigo.
        /// </summary>
        /// <param name="codigo">The codigo.</param>
        /// <returns></returns>
        public static DataTable GetPersonasPorCodigo(string codigo, string restricciones)
        {
            string clausulas = PersonasService.Codigo_NombreCol + " = '" + codigo + "'";

            if (restricciones.Length > 0)
                clausulas += " and (" + restricciones + ")";

            return new PersonasService().GetPersonasInfoCompleta(clausulas, string.Empty);
        }
        #endregion

        #region GetPersonaId
        public static decimal GetPersonaIdPorCodigo(string codigo)
        {
            DataTable dtPersonas = GetPersonasPorCodigo(codigo);
            decimal personaId = Definiciones.Error.Valor.EnteroPositivo;
            if (dtPersonas.Rows.Count > 0)
                personaId = (decimal)(dtPersonas).Rows[0][Id_NombreCol];
            return personaId;
        }
        public static decimal GetPersonaIdPorNroDocumento(string nro_documento)
        {
            DataTable dtPersonas = GetPersonasPorDocumento(nro_documento);
            decimal personaId = Definiciones.Error.Valor.EnteroPositivo;
            if (dtPersonas.Rows.Count > 0)
                personaId = (decimal)(dtPersonas).Rows[0][Id_NombreCol];
            return personaId;
        }
        public static decimal GetPersonaIdPorRuc(string ruc)
        {
            DataTable dtPersonas = GetPersonasPorRuc(ruc);
            decimal personaId = Definiciones.Error.Valor.EnteroPositivo;
            if (dtPersonas.Rows.Count > 0)
                personaId = (decimal)(dtPersonas).Rows[0][Id_NombreCol];
            return personaId;
        }
        #endregion GetPersonaId

        #region GetLineaCreditoDisponible
        public static decimal GetLineaCreditoDisponibleEnDolares(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetLineaCreditoDisponibleEnDolares(persona_id, sesion);
            }
        }

        public static decimal GetLineaCreditoDisponibleEnDolares(decimal persona_id, SessionService sesion)
        {
            PersonasLineaCreditoService personasLineaCredito = new PersonasLineaCreditoService();

            if (!personasLineaCredito.PersonaTieneLineaCredito(persona_id))
                throw new Exception("La persona no tiene asignada una línea de crédito");

            DataRow lineaCredito = personasLineaCredito.GetPersonasLineaCredito(persona_id);
            decimal lineaCreditoMonto = (decimal)lineaCredito[PersonasLineaCreditoService.MontoLineaCredito_NombreCol];

            return lineaCreditoMonto - CuentaCorrientePersonasService.GetSaldoPersonaEnDolares(persona_id, sesion);
        }

        public static decimal GetLineaCreditoDisponible(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetLineaCreditoDisponible(persona_id, sesion);
            }
        }

        public static decimal GetLineaCreditoDisponible(decimal persona_id, SessionService sesion)
        {
            PersonasLineaCreditoService personasLineaCredito = new PersonasLineaCreditoService();

            if (!personasLineaCredito.PersonaTieneLineaCredito(persona_id))
                // throw new Exception("La persona no tiene asignada una línea de crédito");
                return Definiciones.ValorCero.CeroDecimal;

            DataRow lineaCredito = personasLineaCredito.GetPersonasLineaCredito(persona_id);
            decimal lineaCreditoMonto = (decimal)lineaCredito[PersonasLineaCreditoService.MontoLineaCredito_NombreCol];

            decimal adelanto = AnticiposPersonaService.GetAnticipoPersonaTotalPorPersonaId(persona_id);
            decimal chequesAdelantados = CuentaCorrienteChequesRecibidosService.GetChequesAdelantadosMontoTotalPorPersonaId(persona_id);

            return lineaCreditoMonto + adelanto - chequesAdelantados - CuentaCorrientePersonasService.GetSaldoPersona(persona_id, sesion);
        }
        #endregion GetLineaCreditoDisponible

        #region GetPersonasNombreConcatenadoDataTable
        /// <summary>
        /// Gets the personas con nombre concatenado data table.
        /// </summary>
        /// <param name="soloActivos">si es <c>true</c> devuelve solo los activos, si no todos.</param>
        /// <returns></returns>
        public DataTable GetPersonasNombreConcatenadoDataTable(bool soloActivos)
        {
            string clausulas = string.Empty;
            if (soloActivos) clausulas = PersonasService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

            return this.GetPersonasInfoCompleta(clausulas, PersonasService.NombreCompleto_NombreCol);
        }
        #endregion GetPersonasNombreConcatenadoDataTable

        #region GetNombreCompleto
        /// <summary>
        /// Gets the nombre completo.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public string GetNombreCompleto(decimal persona_id)
        {
            DataTable dt = this.GetPersonasInfoCompleta(PersonasService.Id_NombreCol + " = " + persona_id, string.Empty);

            if (dt.Rows.Count > 0)
                return (string)dt.Rows[0][PersonasService.NombreCompleto_NombreCol];
            else
                return string.Empty;
        }
        #endregion GetNombreCompleto

        #region GetVendedorHabitual
        /// <summary>
        /// Gets the vendedor habitual.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public static decimal GetVendedorHabitual(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow row = sesion.Db.PERSONASCollection.GetByPrimaryKey(persona_id);

                return row.IsVENDEDOR_HABITUAL_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.VENDEDOR_HABITUAL_ID;
            }
        }
        #endregion GetVendedorHabitual

        #region GetCondicionHabitualPago
        public static decimal GetCondicionHabitualPago(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow row = sesion.Db.PERSONASCollection.GetByPrimaryKey(persona_id);

                return row.CONDICION_HABITUAL_PAGO_ID;
            }
        }
        #endregion GetCondicionHabitualPago


        #region GetEsMayorista
        public static bool GetEsMayorista(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow row = sesion.Db.PERSONASCollection.GetByPrimaryKey(persona_id);

                return row.MAYORISTA == Definiciones.SiNo.Si;
            }
        }
        #endregion GetEsMayorista

        #region GetCobradorHabitual
        /// <summary>
        /// Gets the cobrador habitual.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public decimal GetCobradorHabitual(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow row = sesion.Db.PERSONASCollection.GetByPrimaryKey(persona_id);

                return row.IsCOBRADOR_HABITUAL_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.COBRADOR_HABITUAL_ID;
            }
        }
        #endregion GetCobradorHabitual

        #region GetPersona
        /// <summary>
        /// Gets an specific persona.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public DataTable GetPersona(Decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.PERSONASCollection.GetAsDataTable(Id_NombreCol + " = " + persona_id, "");
                return tabla;
            }
        }

        /// <summary>
        /// Gets an specific persona.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public static PERSONAS_INFO_COMPLETARow GetPersonaInfoCompletaRow(Decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PERSONAS_INFO_COMPLETACollection.GetRow(PersonasService.Id_NombreCol + " = " + persona_id.ToString());
            }
        }

        #endregion GetPersona

        #region GetPersonaIncobrableId
        public static decimal GetPersonaIncobrableId()
        {
            return VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PersonaParaIncobrables);
        }
        #endregion GetPersonaIncobrableId

        #region GetDeudasPersonas
        /// <summary>
        /// getDeudasPersonas (Obtiene todas las facturas que estan en el estado Caja y los casos de créditos que estan en proceso)
        /// </summary>
        /// <param name="where">Criterios de busqueda del cliente</param>
        /// <returns></returns>
        public static DataTable GetDeudasPersonas(string filtrosFecha, string personaId)
        {
            using (SessionService sesion = new SessionService())
            {
                String query = "";
                query = query + "SELECT" + "\n";
                query = query + "p.CASO_ID," + "\n";
                query = query + "p.SUCURSAL_NOMBRE," + "\n";
                query = query + "p.FECHA, " + "\n";
                query = query + "p.tipo, " + "\n";
                query = query + "p.CondicionPago," + "\n";
                query = query + "p.Total, " + "\n";
                query = query + "p.MONEDA_SIMBOLO," + "\n";
                query = query + "p.MonedaId, " + "\n";
                query = query + "p.Flujo, " + "\n";
                query = query + "nvl(sum(ccp.credito - ccp.debito),0) PENDIENTE" + "\n";
                query = query + "FROM   (SELECT fcic." + FacturasClienteService.CasoId_NombreCol + ", " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaSucursalNombre_NombreCol + ", " + "\n";
                query = query + "               fcic." + FacturasClienteService.Fecha_NombreCol + " fecha, " + "\n";
                query = query + "               'TITULAR'         tipo, " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaCondicionPagoNombre_NombreCol + " CondicionPago, " + "\n";
                query = query + "               fcic." + FacturasClienteService.TotalNeto_NombreCol + " Total, " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaMonedaSimbolo_NombreCol + ", " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaMonedaId_NombreCol + " MonedaId, " + "\n";
                query = query + "               'FACTURA CLIENTE' Flujo " + "\n";
                query = query + "        FROM   " + FacturasClienteService.Nombre_Vista + " fcic " + "\n";
                query = query + "        WHERE  fcic." + FacturasClienteService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Caja + "' " + "\n";
                query = query + "               AND fcic." + FacturasClienteService.PersonaId_NombreCol + " = " + personaId + " " + "\n";
                query = query + "        UNION " + "\n";
                query = query + "        SELECT fcic." + FacturasClienteService.CasoId_NombreCol + ", " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaSucursalNombre_NombreCol + ", " + "\n";
                query = query + "               fcic." + FacturasClienteService.Fecha_NombreCol + " fecha, " + "\n";
                query = query + "               'GARANTE'         tipo, " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaCondicionPagoNombre_NombreCol + " CondicionPago, " + "\n";
                query = query + "               fcic." + FacturasClienteService.TotalNeto_NombreCol + " Total, " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaMonedaSimbolo_NombreCol + ", " + "\n";
                query = query + "               fcic." + FacturasClienteService.VistaMonedaId_NombreCol + " MonedaId, " + "\n";
                query = query + "               'FACTURA CLIENTE' Flujo " + "\n";
                query = query + "        FROM   " + FacturasClienteService.Nombre_Vista + " fcic " + "\n";
                query = query + "        WHERE  fcic." + FacturasClienteService.VistaCasoEstadoId_NombreCol + " = '" + Definiciones.EstadosFlujos.Caja + "' " + "\n";
                query = query + "               AND ( fcic." + FacturasClienteService.PersonaGarante1Id_NombreCol + "= " + personaId + " " + "\n";
                query = query + "                      OR fcic." + FacturasClienteService.PersonaGarante2Id_NombreCol + " =" + personaId + " " + "\n";
                query = query + "                      OR fcic." + FacturasClienteService.PersonaGarante3Id_NombreCol + " = " + personaId + " ) " + "\n";
                query = query + "        UNION " + "\n";
                query = query + "        SELECT cr." + CreditosService.Modelo.CASO_IDColumnName + ", " + "\n";
                query = query + "               s." + SucursalesService.Modelo.NOMBREColumnName + ", " + "\n";
                query = query + "               cr." + CreditosService.Modelo.FECHA_RETIROColumnName + " fecha, " + "\n";
                query = query + "               'TITULAR'         tipo, " + "\n";
                query = query + "               'CREDITO' CondicionPago, " + "\n";
                query = query + "               cr." + CreditosService.Modelo.MONTO_TOTALColumnName + " Total, " + "\n";
                query = query + "               m." + MonedasService.Modelo.SIMBOLOColumnName + ", " + "\n";
                query = query + "               cr." + CreditosService.Modelo.MONEDA_IDColumnName + " MonedaId, " + "\n";
                query = query + "               'CRÉDITO CLIENTE' Flujo " + "\n";
                query = query + "        FROM   " + CreditosService.Nombre_Tabla + " cr, " + CasosService.Nombre_Tabla + " c, " + SucursalesService.Nombre_Tabla + " s, " + MonedasService.Nombre_Tabla + " m \n";
                query = query + "        WHERE      c." + CasosService.Modelo.IDColumnName + " = cr." + CreditosService.Modelo.CASO_IDColumnName + " " + "\n";
                query = query + "               AND cr." + CreditosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " + "\n";
                query = query + "               AND c." + CasosService.Modelo.ESTADO_IDColumnName + " = '" + Definiciones.EstadosFlujos.Vigente + "' " + "\n";
                query = query + "               AND cr." + CreditosService.Modelo.PERSONA_IDColumnName + " = " + personaId + " " + "\n";
                query = query + "        UNION " + "\n";
                query = query + "        SELECT cr." + CreditosService.Modelo.CASO_IDColumnName + ", " + "\n";
                query = query + "               s." + SucursalesService.Modelo.NOMBREColumnName + ", " + "\n";
                query = query + "               cr." + CreditosService.Modelo.FECHA_RETIROColumnName + " fecha, " + "\n";
                query = query + "               'GARANTE'         tipo, " + "\n";
                query = query + "               'CREDITO' CondicionPago, " + "\n";
                query = query + "               cr." + CreditosService.Modelo.MONTO_TOTALColumnName + " Total, " + "\n";
                query = query + "               m." + MonedasService.Modelo.SIMBOLOColumnName + ", " + "\n";
                query = query + "               cr." + CreditosService.Modelo.MONEDA_IDColumnName + " MonedaId, " + "\n";
                query = query + "               'CRÉDITO CLIENTE' Flujo " + "\n";
                query = query + "        FROM   " + CreditosService.Nombre_Tabla + " cr, " + CasosService.Nombre_Tabla + " c, " + SucursalesService.Nombre_Tabla + " s, " + MonedasService.Nombre_Tabla + " m \n";
                query = query + "        WHERE      c." + CasosService.Modelo.IDColumnName + " = cr." + CreditosService.Modelo.CASO_IDColumnName + " " + "\n";
                query = query + "               AND cr." + CreditosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' " + "\n";
                query = query + "               AND c." + CasosService.Modelo.ESTADO_IDColumnName + " = '" + Definiciones.EstadosFlujos.Vigente + "' " + "\n";
                query = query + "               AND (cr." + CreditosService.Modelo.PERSONA_GARANTE1_IDColumnName + " = " + personaId + ") or cr." + CreditosService.Modelo.PERSONA_GARANTE2_IDColumnName + " = " + personaId + ") p \n";
                query = query + "left join " + CuentaCorrientePersonasService.Nombre_Tabla + " ccp on ccp." + CuentaCorrientePersonasService.CasoId_NombreCol + " = p." + CuentaCorrientePersonasService.CasoId_NombreCol + "\n";

                query = query + "group by ";
                query = query + "p.CASO_ID," + "\n";
                query = query + "p.SUCURSAL_NOMBRE," + "\n";
                query = query + "p.FECHA, " + "\n";
                query = query + "p.tipo, " + "\n";
                query = query + "p.CondicionPago," + "\n";
                query = query + "p.Total, " + "\n";
                query = query + "p.MONEDA_SIMBOLO," + "\n";
                query = query + "p.MonedaId, " + "\n";
                query = query + "p.Flujo " + "\n";
                query = query + "order by p.caso_id ";

                if (filtrosFecha.Length > 0)
                    query = query + "WHERE 0=0 " + filtrosFecha;
                else if (personaId.Length == 0)
                    return new DataTable();

                return sesion.db.EjecutarQuery(query);
            }
        }
        #endregion GetDeudasPersonas

        #region GetCentroCosto
        public static decimal GetCentroCosto(decimal persona_id, SessionService sesion)
        {
            PERSONASRow row = sesion.Db.PERSONASCollection.GetByPrimaryKey(persona_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        #endregion GetCentroCosto

        #region GetDatosEstanActualizados
        public static bool GetDatosEstanActualizados(decimal persona_id, SessionService sesion)
        {
            var row = sesion.db.PERSONASCollection.GetByPrimaryKey(persona_id);
            var diasVigencia = VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.PersonasDiasActualizacionDatosVigencia);
            return row.FECHA_ULTIMA_ACTUALIZAC_DATOS.AddDays(diasVigencia).Date > DateTime.Now.Date;
        }
        #endregion GetDatosEstanActualizados
        #endregion Getters

        #region Booleans

        #region ExisteRUC
        /// <summary>
        /// Existes the RUC.
        /// </summary>
        /// <param name="ruc">The ruc.</param>
        /// <returns></returns>
        public static bool ExisteRUC(string ruc, decimal persona_id)
        {
            string clausulas = PersonasService.Ruc_NombreCol + " = '" + ruc + "' and " + PersonasService.Id_NombreCol + " <> " + persona_id;
            return PersonasService.GetPersonasDataTable(clausulas, string.Empty).Rows.Count > 0;
        }
        #endregion

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + " = " + persona_id);
                return persona.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region EsCliente
        /// <summary>
        /// Eses the cliente.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public static bool EsCliente(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + " = " + persona_id);
                return persona.ES_CLIENTE == Definiciones.SiNo.Si;
            }
        }
        #endregion EsCliente

        #region EsAgenteRetentor
        public static bool EsAgenteRetentor(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + " = " + persona_id);
                return persona.AGENTE_RETENCION == Definiciones.SiNo.Si;
            }
        }
        #endregion EsAgenteRetentor

        #region TieneInforconf
        /// <summary>
        /// Tienes the inforconf.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public static bool TieneInforconf(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow persona = sesion.Db.PERSONASCollection.GetByPrimaryKey(persona_id);
                return persona.EN_INFORMCONF == Definiciones.SiNo.Si;
            }
        }
        #endregion TieneInforconf

        #region EnJudicial
        public static bool EnJudicialStatic(decimal persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                PERSONASRow persona = sesion.Db.PERSONASCollection.GetByPrimaryKey(persona_id);
                return persona.EN_JUDICIAL == Definiciones.SiNo.Si;
            }
        }
        #endregion EnJudicial

        #region EstaBloqueado
        /// <summary>
        /// Estas the bloqueado.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public static bool EstaBloqueado(decimal persona_id)
        {
            PersonasBloqueosService personasBloqueos = new PersonasBloqueosService();
            return personasBloqueos.PersonaBloqueada(persona_id);
        }
        #endregion EstaBloqueado

        #endregion Booleans

        

        #region Guardar

        /// <summary>
        /// Actualiza los datos del cliente (telefono1 y email1)
        /// se utiliza en facturaCliente, en el evento cboPersonas_SelectedValueChanged del comboBoxCBA del campo Persona
        /// </summary>
        /// <param name="campos">debe indicarse el id del registro</param>
        public static decimal ActualizaPersona(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PERSONASRow persona;
                    PERSONASRow personaOriginal;
                    string valorAnterior = "";

                    persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + "=" + campos[Id_NombreCol]);
                    valorAnterior = persona.ToString();

                    personaOriginal = persona.Clonar();

                    persona.TELEFONO1 = Interprete.EsNullODBNull(campos[Telefono1_NombreCol]) ? string.Empty : (string)campos[Telefono1_NombreCol];
                    persona.EMAIL1 = Interprete.EsNullODBNull(campos[Email1_NombreCol]) ? string.Empty : (string)campos[Email1_NombreCol];

                    sesion.Db.PERSONASCollection.Update(persona);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, persona.ID, valorAnterior, persona.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                    return persona.ID;
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe otra persona con el mismo tipo y número de documento.", exp);
                        default:
                            throw;
                    }
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }

        /// <summary>
        /// Hace un update  del registro del cliente en caja rapida.
        /// </summary>
        /// <param name="campos">Campos del registro. debe indicarse el id del registro</param>
        public static decimal EditClienteRapido(System.Collections.Hashtable campo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PERSONASRow persona;

                    string valorAnterior = string.Empty;
                    persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + "=" + campo[Id_NombreCol]);

                    //verificar que el registro sea modificable
                    if (persona.MODIFICABLE.Equals(Definiciones.SiNo.No))
                        throw new System.ArgumentException("No puede modificar los datos del cliente.");

                    valorAnterior = persona.ToString();
                    persona.ID = decimal.Parse(campo[Id_NombreCol].ToString());
                    persona.FISICO = campo[Fisico_NombreCol].ToString();
                    persona.CODIGO = campo[Codigo_NombreCol].ToString();
                    persona.TIPO_DOCUMENTO_IDENTIDAD_ID = campo[TipoDocumentoIdentidadId_NombreCol].ToString();
                    persona.NUMERO_DOCUMENTO = campo[NumeroDocumento_NombreCol].ToString();
                    if (campo.Contains(Ruc_NombreCol))
                        persona.RUC = campo[Ruc_NombreCol].ToString();

                    persona.NOMBRE = campo[Nombre_NombreCol].ToString();
                    persona.APELLIDO = campo[Fisico_NombreCol].ToString().Equals(Definiciones.SiNo.Si) ? campo[Apellido_NombreCol].ToString() : String.Empty;
                    persona.EMAIL1 = campo[Email1_NombreCol].ToString();
                    persona.TELEFONO1 = campo[Telefono1_NombreCol].ToString();
                    persona.PAIS_RESIDENCIA_ID = decimal.Parse(campo[PaisResidenciaId_NombreCol].ToString());
                    persona.PAIS_NACIONALIDAD_ID = decimal.Parse(campo[PaisNacionalidadId_NombreCol].ToString());
                    persona.CALLE_COBRANZA = campo[CalleCobranza_NombreCol].ToString();

                    sesion.Db.PERSONASCollection.Update(persona);
                    sesion.Db.CommitTransaction();

                    return persona.ID;
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe otra persona con el mismo tipo y número de documento.", exp);
                        default:
                            throw;
                    }
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PERSONASRow persona;
                    PERSONASRow personaOriginal;
                    string valorAnterior = "";
                    decimal dAux;
                    string sAux = string.Empty;

                    //persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + "=" + campos[Id_NombreCol]);
                    //valorAnterior = persona.ToString();

                    if (insertarNuevo)
                    {
                        persona = new PERSONASRow();
                        persona.ID = sesion.Db.GetSiguienteSecuencia("personas_sqc");
                        persona.ENTIDAD_ID = sesion.Entidad.ID;
                        persona.BANDERA_RETENCION = Definiciones.SiNo.No;
                        persona.INGRESO_APROBADO = Definiciones.SiNo.No;
                        persona.MAYORISTA = Definiciones.SiNo.No;
                        persona.AGENTE_RETENCION = Definiciones.SiNo.No;
                        persona.MONEDA_ID = Definiciones.Monedas.Guaranies;
                        persona.MONEDA_LIMITE_CREDITO_ID = Definiciones.Monedas.Guaranies;
                        persona.OPERA_CREDITO = Definiciones.SiNo.Si;
                        persona.MODIFICABLE = Definiciones.SiNo.Si;
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        #region Control de Codigo
                        if (campos.Contains(Codigo_NombreCol))
                        {
                            persona.CODIGO = (string)campos[Codigo_NombreCol];
                        }
                        else
                        {
                            DataTable dtAutonumeracion = AutonumeracionesService.GetAutonumeracionesPorTabla2(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, string.Empty, AutonumeracionesService.Id_NombreCol);
                            if (dtAutonumeracion.Rows.Count > 0)
                                persona.CODIGO = AutonumeracionesService.GetSiguienteNumero2((decimal)dtAutonumeracion.Rows[0][AutonumeracionesService.Id_NombreCol]);
                            else
                                throw new Exception("No existe una autonumeración para los códigos de " + Traducciones.Persona + ".");
                        }

                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PersonasControlarUnicidadCodigo) == Definiciones.SiNo.Si)
                        {
                            DataTable dtCodigo = PersonasService.GetPersonasPorCodigo(persona.CODIGO);
                            if (dtCodigo.Rows.Count > 0)
                                throw new Exception("Ya existe el Código");
                        }
                        #endregion Control de Codigo
                    }
                    else
                    {
                        persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + "=" + campos[Id_NombreCol]);
                        valorAnterior = persona.ToString();

                        //verificar que el registro sea modificable
                        if (persona.MODIFICABLE.Equals(Definiciones.SiNo.No))
                            throw new System.ArgumentException("No puede modificar a la persona.");
                    }

                    personaOriginal = persona.Clonar();

                    // Campos obligatorios
                    persona.NOMBRE = (string)campos[Nombre_NombreCol];
                    persona.APELLIDO = (string)campos[Apellido_NombreCol];
                    persona.NOMBRE_COMPLETO = (string)campos[Nombre_NombreCol] + " " + (string)campos[Apellido_NombreCol];

                    persona.CODIGO_EXTERNO = (string)campos[CodigoExterno_NombreCol];
                    persona.CALLE2 = Interprete.EsNullODBNull(campos[Calle2_NombreCol]) ? string.Empty : (string)campos[Calle2_NombreCol];
                    persona.CODIGO_POSTAL2 = Interprete.EsNullODBNull(campos[CodigoPostal2_NombreCol]) ? string.Empty : (string)campos[CodigoPostal2_NombreCol];

                    persona.TELEFONO1 = Interprete.EsNullODBNull(campos[Telefono1_NombreCol]) ? string.Empty : (string)campos[Telefono1_NombreCol];
                    persona.TELEFONO2 = Interprete.EsNullODBNull(campos[Telefono2_NombreCol]) ? string.Empty : (string)campos[Telefono2_NombreCol];
                    persona.TELEFONO3 = Interprete.EsNullODBNull(campos[Telefono3_NombreCol]) ? string.Empty : (string)campos[Telefono3_NombreCol];
                    persona.TELEFONO4 = Interprete.EsNullODBNull(campos[Telefono4_NombreCol]) ? string.Empty : (string)campos[Telefono4_NombreCol];
                    persona.TELEFONO_COBRANZA1 = Interprete.EsNullODBNull(campos[TelefonoCobranza1_NombreCol]) ? string.Empty : (string)campos[TelefonoCobranza1_NombreCol];
                    persona.TELEFONO_COBRANZA2 = Interprete.EsNullODBNull(campos[TelefonoCobranza2_NombreCol]) ? string.Empty : (string)campos[TelefonoCobranza2_NombreCol];
                    persona.EMAIL1 = Interprete.EsNullODBNull(campos[Email1_NombreCol]) ? string.Empty : (string)campos[Email1_NombreCol];
                    persona.EMAIL2 = Interprete.EsNullODBNull(campos[Email2_NombreCol]) ? string.Empty : (string)campos[Email2_NombreCol];
                    persona.EMAIL3 = Interprete.EsNullODBNull(campos[Email3_NombreCol]) ? string.Empty : (string)campos[Email3_NombreCol];

                    persona.SEPARACION_BIENES = (string)campos[SeparacionBienes_NombreCol];
                    persona.FISICO = (string)campos[Fisico_NombreCol];
                    persona.GENERO = (string)campos[Genero_NombreCol];
                    persona.GRUPO_SANGUINEO = (string)campos[GrupoSanguineo_NombreCol];
                    persona.CALLE1 = Interprete.EsNullODBNull(campos[Calle1_NombreCol]) ? string.Empty : (string)campos[Calle1_NombreCol];
                    persona.CODIGO_POSTAL1 = Interprete.EsNullODBNull(campos[CodigoPostal1_NombreCol]) ? string.Empty : (string)campos[CodigoPostal1_NombreCol];

                    persona.POSEE_UNIPERSONAL = (string)campos[PersonasService.PoseeUnipersonal_NombreCol];
                    persona.EMPRESA_NOMBRE_FANTASIA = Interprete.EsNullODBNull(campos[EmpresaNombreFantasia_NombreCol]) ? string.Empty : (string)campos[EmpresaNombreFantasia_NombreCol];
                    persona.EMPRESA_PERSONA_CONTACTO = Interprete.EsNullODBNull(campos[EmpresaPersonaContacto_NombreCol]) ? string.Empty : (string)campos[EmpresaPersonaContacto_NombreCol];
                    persona.EMPRESA_TELEFONO_CONTACTO = Interprete.EsNullODBNull(campos[EmpresaTelefonoContacto_NombreCol]) ? string.Empty : (string)campos[EmpresaTelefonoContacto_NombreCol];
                    persona.MAYORISTA = (string)campos[Mayorista_NombreCol] == null ? Definiciones.SiNo.No : (string)campos[Mayorista_NombreCol];

                    persona.CALLE_COBRANZA = Interprete.EsNullODBNull(campos[CalleCobranza_NombreCol]) ? string.Empty : (string)campos[CalleCobranza_NombreCol];
                    persona.CODIGO_POSTAL_COBRANZA = Interprete.EsNullODBNull(campos[CodigoPostalCobranzaId_NombreCol]) ? string.Empty : (string)campos[CodigoPostalCobranzaId_NombreCol];
                    persona.EN_INFORMCONF = (string)campos[EnInformconf_NombreCol];
                    persona.EN_JUDICIAL = (string)campos[EnJudicial_NombreCol];

                    persona.NUMERO_DOCUMENTO = ((string)campos[NumeroDocumento_NombreCol]).Trim();
                    if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.VerificarUnicidadRUC).Equals(Definiciones.SiNo.Si) && decimal.Parse(campos[TipoClienteId_NombreCol].ToString()) != 2) //tipo cliente 2 es diplomatico
                    {
                        DataTable dt = PersonasService.GetPersonasDataTable2(PersonasService.NumeroDocumento_NombreCol + " = '" + persona.NUMERO_DOCUMENTO + "' and " + PersonasService.Id_NombreCol + " <> " + persona.ID, string.Empty, false, sesion);
                        if (dt.Rows.Count > 0)
                            throw new Exception("Ya existe una persona con el mismo número de documento.");
                    }

                    persona.OPERA_CREDITO = (string)campos[OperaCredito_NombreCol];

                    persona.AGENTE_RETENCION = (string)campos[AgenteRetencion_NombreCol];
                    persona.ES_CLIENTE = (string)campos[PersonasService.EsCliente_NombreCol];
                    persona.ES_CONTRIBUYENTE = (string)campos[PersonasService.EsContribuyente_NombreCol];

                    if (campos.Contains(PersonasService.CentroCostoId_NombreCol))
                        persona.CENTRO_COSTO_ID = (decimal)campos[PersonasService.CentroCostoId_NombreCol];
                    else
                        persona.IsCENTRO_COSTO_IDNull = true;

                    if (campos.Contains(PersonasService.NroTarjetaRedPago_NombreCol))
                        persona.NRO_TARJETA_RED_PAGO = (decimal)campos[PersonasService.NroTarjetaRedPago_NombreCol];
                    else
                        persona.IsNRO_TARJETA_RED_PAGONull = true;

                    if (campos[TratamientoId_NombreCol] != null)
                        sAux = (string)campos[TratamientoId_NombreCol];
                    else
                        sAux = string.Empty;
                    if (persona.TRATAMIENTO_ID != sAux && sAux != string.Empty)
                    {
                        if (TratamientosService.EstaActivo(sAux))
                            persona.TRATAMIENTO_ID = sAux;
                        else
                            throw new System.ArgumentException("El tratamiento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }

                    sAux = (string)campos[TipoDocumentoIdentidadId_NombreCol];
                    if (persona.TIPO_DOCUMENTO_IDENTIDAD_ID != sAux)
                    {
                        persona.TIPO_DOCUMENTO_IDENTIDAD_ID = sAux;
                        if (!persona.TIPO_DOCUMENTO_IDENTIDAD_ID.Equals(string.Empty))
                        {
                            if (!TiposDocumentosIdentidadService.EstaActivo(sAux))
                                throw new System.ArgumentException("El tipo de documento seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    if (campos.Contains(ProfesionId_NombreCol))
                    {
                        sAux = (string)campos[ProfesionId_NombreCol];
                        if (persona.PROFESION_ID != sAux)
                        {
                            if (ProfesionesService.EstaActivo(sAux))
                                persona.PROFESION_ID = sAux;
                            else
                                throw new System.ArgumentException("La profesión seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }

                    if (campos.Contains(CondicionHabitualPagoId_NombreCol))
                    {
                        dAux = Interprete.ObtenerDecimal(campos[CondicionHabitualPagoId_NombreCol]);
                        if (persona.CONDICION_HABITUAL_PAGO_ID != dAux)
                        {
                            if (CondicionesPagoService.EstaActivo(dAux))
                                persona.CONDICION_HABITUAL_PAGO_ID = dAux;
                            else
                                throw new System.ArgumentException("La condición de pago seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }


                    if (campos.Contains(PersonaIdConyuge_NombreCol))
                    {
                        persona.PERSONA_ID_CONYUGE = decimal.Parse(campos[PersonaIdConyuge_NombreCol].ToString());
                        persona.CONYUGE_NOMBRE = string.Empty;
                        persona.CONYUGE_APELLIDO = string.Empty;
                    }
                    else
                    {
                        persona.IsPERSONA_ID_CONYUGENull = true;
                        persona.CONYUGE_NOMBRE = (string)campos[ConyugeNombre_NombreCol];
                        persona.CONYUGE_APELLIDO = (string)campos[ConyugeApellido_NombreCol];
                    }
                    if (campos.Contains(IngresoAprobado_NombreCol))
                    {
                        if (persona.INGRESO_APROBADO != (string)campos[IngresoAprobado_NombreCol])
                        {
                            if ((string)campos[IngresoAprobado_NombreCol] == Definiciones.SiNo.Si)
                            {//Se aprobo el ingreso del persona
                                persona.FECHA_APROBACION = DateTime.Now;
                                persona.USUARIO_APROBACION_ID = sesion.Usuario.ID;
                                persona.INGRESO_APROBADO = (string)campos[IngresoAprobado_NombreCol];
                            }
                            else
                                throw new ArgumentException("No puede desaprobarse el ingreso de un persona aprobado previamente.");
                        }
                    }
                    if (campos.Contains(MonedaLimiteCreditoId_NombreCol))
                    {
                        dAux = Interprete.ObtenerDecimal(campos[MonedaLimiteCreditoId_NombreCol]);
                        if (persona.MONEDA_LIMITE_CREDITO_ID != dAux)
                            if (MonedasService.EstaActivo(dAux))
                                persona.MONEDA_LIMITE_CREDITO_ID = dAux;
                            else
                                throw new System.ArgumentException("La moneda del límite de crédito seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                    else
                    {
                        if (insertarNuevo)//cqmbiar luego
                        {
                            throw new ArgumentException("Debe indicar la moneda en que se expresa el límite crédito");
                        }

                    }

                    #region Campos Opcionales

                    // Campos opcionales
                    #region Campos con valores por defecto
                    if (campos.Contains(Estado_NombreCol))
                    {
                        if (campos[Estado_NombreCol].ToString().Length > 0)
                            persona.ESTADO = (string)campos[Estado_NombreCol];
                        else
                            persona.ESTADO = Definiciones.SiNo.Si;
                    }
                    else
                        persona.ESTADO = Definiciones.SiNo.Si;

                    #endregion Campos con valores por defecto

                    #region campos con valores nulos
                    if (campos.Contains(Nacimiento_NombreCol))
                        persona.NACIMIENTO = DateTime.Parse(campos[Nacimiento_NombreCol].ToString());
                    else
                        persona.IsNACIMIENTONull = true;

                    if (campos.Contains(PaisNacionalidadId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[PaisNacionalidadId_NombreCol].ToString());
                        if (persona.IsPAIS_NACIONALIDAD_IDNull || persona.PAIS_NACIONALIDAD_ID != dAux)
                            if (PaisesService.EstaActivo(dAux))
                                persona.PAIS_NACIONALIDAD_ID = dAux;
                            else
                                throw new System.ArgumentException("La nacionalidad seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                    else
                        persona.IsPAIS_NACIONALIDAD_IDNull = true;

                    if (campos.Contains(EstadoDocumentacionId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[EstadoDocumentacionId_NombreCol].ToString());
                        if (persona.IsESTADO_DOCUMENTACION_IDNull || persona.ESTADO_DOCUMENTACION_ID != dAux)
                            if (EstadosDocumentacionService.EstaActivo(dAux))
                                persona.ESTADO_DOCUMENTACION_ID = dAux;
                            else
                                throw new System.ArgumentException("El estado de la documentación seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                    else
                        persona.IsESTADO_DOCUMENTACION_IDNull = true;

                    if (campos.Contains(PaisResidenciaId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[PaisResidenciaId_NombreCol].ToString());
                        if (persona.IsPAIS_RESIDENCIA_IDNull || persona.PAIS_RESIDENCIA_ID != dAux)
                        {
                            if (PaisesService.EstaActivo(dAux)) persona.PAIS_RESIDENCIA_ID = dAux;
                            else throw new System.ArgumentException("El país de residencia seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsPAIS_RESIDENCIA_IDNull = true;

                    if (campos.Contains(Departamento1Id_NombreCol))
                    {
                        dAux = decimal.Parse(campos[Departamento1Id_NombreCol].ToString());
                        if (persona.IsDEPARTAMENTO1_IDNull || persona.DEPARTAMENTO1_ID != dAux)
                            if (DepartamentosService.EstaActivo(dAux))
                                persona.DEPARTAMENTO1_ID = dAux;
                            else
                                throw
                                    new System.ArgumentException("El departamento principal seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                    else
                        persona.IsDEPARTAMENTO1_IDNull = true;

                    if (campos.Contains(Ciudad1Id_NombreCol))
                    {
                        dAux = decimal.Parse(campos[Ciudad1Id_NombreCol].ToString());
                        if (persona.IsCIUDAD1_IDNull || persona.CIUDAD1_ID != dAux)
                            if (CiudadesService.EstaActivo(dAux))
                                persona.CIUDAD1_ID = dAux;
                            else
                                throw new
                                    System.ArgumentException("La ciudad principal seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                    else
                        persona.IsCIUDAD1_IDNull = true;

                    if (campos.Contains(Barrio1Id_NombreCol))
                    {
                        dAux = decimal.Parse(campos[Barrio1Id_NombreCol].ToString());
                        if (persona.IsBARRIO1_IDNull || persona.BARRIO1_ID != dAux)
                            if (BarriosService.EstaActivo(dAux))
                                persona.BARRIO1_ID = dAux;
                            else
                                throw new System.ArgumentException("El barrio principal seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                    else
                        persona.IsBARRIO1_IDNull = true;

                    #endregion campos con valores nulos

                    #region campos ignorados
                    if (campos.Contains(NombreFantasia_NombreCol))
                        persona.NOMBRE_FANTASIA = (string)campos[NombreFantasia_NombreCol];

                    if (campos.Contains(Ruc_NombreCol))
                    {
                        persona.RUC = ((string)campos[Ruc_NombreCol]).Trim();
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.VerificarUnicidadRUC).Equals(Definiciones.SiNo.Si) && decimal.Parse(campos[TipoClienteId_NombreCol].ToString()) != 2) //tipo cliente 2 es diplomatico
                        {
                            if (ExisteRUC(persona.RUC, persona.ID))
                                throw new System.ArgumentException("El RUC ya existe, Favor verificar.");
                        }
                    }
                    #endregion campos ignorados

                    if (campos.Contains(PersonasService.ListaPreciosId_NombreCol))
                        persona.LISTA_PRECIOS_ID = (decimal)campos[PersonasService.ListaPreciosId_NombreCol];
                    else// si no recibe lista de precio, se le asigna lista por default
                        persona.LISTA_PRECIOS_ID = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.ListaDePrecioPorDefectoID);

                    if (campos.Contains(PersonasService.PersonaCalificacionId_NombreCol))
                        persona.PERSONA_CALIFICACION_ID = (decimal)campos[PersonasService.PersonaCalificacionId_NombreCol];
                    else
                        persona.IsPERSONA_CALIFICACION_IDNull = true;

                    if (campos.Contains(EmpresaFundacion_NombreCol))
                        persona.EMPRESA_FUNDACION = DateTime.Parse(campos[EmpresaFundacion_NombreCol].ToString());
                    else
                        persona.IsEMPRESA_FUNDACIONNull = true;

                    if (campos.Contains(TextoPredefinidoId_NombreCol))
                        persona.TEXTO_PREDEFINIDO_ID = (decimal)campos[TextoPredefinidoId_NombreCol];
                    else
                        persona.IsTEXTO_PREDEFINIDO_IDNull = true;

                    if (campos.Contains(Departamento2Id_NombreCol))
                    {
                        dAux = decimal.Parse(campos[Departamento2Id_NombreCol].ToString());
                        if (persona.IsDEPARTAMENTO2_IDNull || persona.DEPARTAMENTO2_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux))
                                persona.DEPARTAMENTO2_ID = dAux;
                            else
                                throw new System.ArgumentException("El departamento secundario seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsDEPARTAMENTO2_IDNull = true;

                    if (campos.Contains(Ciudad2Id_NombreCol))
                    {
                        dAux = decimal.Parse(campos[Ciudad2Id_NombreCol].ToString());
                        if (persona.IsCIUDAD2_IDNull || persona.CIUDAD2_ID != dAux)
                            if (CiudadesService.EstaActivo(dAux))
                                persona.CIUDAD2_ID = dAux;
                            else
                                throw new System.ArgumentException("La ciudad secundaria seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                    }
                    else
                        persona.IsCIUDAD2_IDNull = true;

                    if (campos.Contains(Barrio2Id_NombreCol))
                    {
                        dAux = decimal.Parse(campos[Barrio2Id_NombreCol].ToString());
                        if (persona.IsBARRIO2_IDNull || persona.BARRIO2_ID != dAux)
                            if (BarriosService.EstaActivo(dAux))
                                persona.BARRIO2_ID = dAux;
                            else
                                throw new System.ArgumentException("El barrio secundario seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                    }
                    else
                        persona.IsBARRIO2_IDNull = true;


                    if (campos.Contains(PersonasService.Latitud1_NombreCol)
                        || campos.Contains(PersonasService.Longitud1_NombreCol))
                    {
                        if (!(campos.Contains(PersonasService.Latitud1_NombreCol)
                              && campos.Contains(PersonasService.Longitud1_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        persona.LATITUD1 = decimal.Parse(campos[PersonasService.Latitud1_NombreCol].ToString());
                        persona.LONGITUD1 = decimal.Parse(campos[PersonasService.Longitud1_NombreCol].ToString());
                    }
                    else
                    {
                        persona.IsLATITUD1Null = true;
                        persona.IsLONGITUD1Null = true;
                    }

                    if (campos.Contains(PersonasService.Latitud2_NombreCol) || campos.Contains(PersonasService.Longitud2_NombreCol))
                    {
                        if (!(campos.Contains(PersonasService.Latitud2_NombreCol) && campos.Contains(PersonasService.Longitud2_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        persona.LATITUD2 = decimal.Parse(campos[PersonasService.Latitud2_NombreCol].ToString());
                        persona.LONGITUD2 = decimal.Parse(campos[PersonasService.Longitud2_NombreCol].ToString());
                    }
                    else
                    {
                        persona.IsLATITUD2Null = true;
                        persona.IsLONGITUD2Null = true;
                    }

                    if (campos.Contains(PersonasService.LatitudCobranza_NombreCol) || campos.Contains(PersonasService.LongitudCobranza_NombreCol))
                    {
                        if (!(campos.Contains(PersonasService.LatitudCobranza_NombreCol) && campos.Contains(PersonasService.LongitudCobranza_NombreCol)))
                            throw new Exception("Debe establecer tanto la latitud como la longitud.");

                        persona.LATITUD_COBRANZA = decimal.Parse(campos[PersonasService.LatitudCobranza_NombreCol].ToString());
                        persona.LONGITUD_COBRANZA = decimal.Parse(campos[PersonasService.LongitudCobranza_NombreCol].ToString());
                    }
                    else
                    {
                        persona.IsLATITUD_COBRANZANull = true;
                        persona.IsLONGITUD_COBRANZANull = true;
                    }

                    if (campos.Contains(RubroId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[RubroId_NombreCol].ToString());
                        if (persona.IsRUBRO_IDNull || persona.RUBRO_ID != dAux)
                        {
                            if (RubrosService.EstaActivo(dAux))
                                persona.RUBRO_ID = dAux;
                            else
                                throw new System.ArgumentException("El rubro seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsRUBRO_IDNull = true;


                    if (campos.Contains(MonedaId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[MonedaId_NombreCol].ToString());
                        if (persona.IsMONEDA_IDNull || persona.MONEDA_ID != dAux)
                        {
                            if (MonedasService.EstaActivo(dAux)) persona.MONEDA_ID = dAux;
                            else throw new System.ArgumentException("La moneda seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsMONEDA_IDNull = true;

                    if (campos.Contains(VendedorHabitualId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[VendedorHabitualId_NombreCol].ToString());
                        if (persona.IsVENDEDOR_HABITUAL_IDNull || persona.VENDEDOR_HABITUAL_ID != dAux)
                        {
                            if (FuncionariosService.EstaActivo(dAux))
                                persona.VENDEDOR_HABITUAL_ID = dAux;
                            else
                                throw new System.ArgumentException("El vendedor seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        if (VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.PersonasVendedorObligatorio) == Definiciones.SiNo.Si)
                            throw new Exception("La persona debe tener un vendedor asignado.");
                        persona.IsVENDEDOR_HABITUAL_IDNull = true;
                    }


                    if (campos.Contains(CobradorHabitualId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[CobradorHabitualId_NombreCol].ToString());
                        if (persona.IsCOBRADOR_HABITUAL_IDNull || persona.COBRADOR_HABITUAL_ID != dAux)
                        {
                            if (FuncionariosService.EstaActivo(dAux))
                                persona.COBRADOR_HABITUAL_ID = dAux;
                            else
                                throw new System.ArgumentException("El cobrador seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsCOBRADOR_HABITUAL_IDNull = true;

                    if (campos.Contains(DepartamentoCobranzaId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[DepartamentoCobranzaId_NombreCol].ToString());
                        if (persona.IsDEPARTAMENTO_COBRANZA_IDNull || persona.DEPARTAMENTO_COBRANZA_ID != dAux)
                        {
                            if (DepartamentosService.EstaActivo(dAux))
                                persona.DEPARTAMENTO_COBRANZA_ID = dAux;
                            else
                                throw new System.ArgumentException("El departamento de cobranza seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsDEPARTAMENTO_COBRANZA_IDNull = true;

                    if (campos.Contains(CiudadCobranzaId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[CiudadCobranzaId_NombreCol].ToString());
                        if (persona.IsCIUDAD_COBRANZA_IDNull || persona.CIUDAD_COBRANZA_ID != dAux)
                        {
                            if (CiudadesService.EstaActivo(dAux))
                                persona.CIUDAD_COBRANZA_ID = dAux;
                            else
                                throw new System.ArgumentException("La ciudad de cobranza seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsCIUDAD_COBRANZA_IDNull = true;

                    if (campos.Contains(BarrioCobranzaId_NombreCol))
                    {
                        dAux = decimal.Parse(campos[BarrioCobranzaId_NombreCol].ToString());
                        if (persona.IsBARRIO_COBRANZA_IDNull || persona.BARRIO_COBRANZA_ID != dAux)
                        {
                            if (BarriosService.EstaActivo(dAux))
                                persona.BARRIO_COBRANZA_ID = dAux;
                            else
                                throw new System.ArgumentException("El barrio de cobranza seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                        persona.IsBARRIO_COBRANZA_IDNull = true;

                    if (campos.Contains(FechaModificacionInforcomf_NombreCol))
                        persona.FECHA_MODIFICACION_INFORMCONF = (DateTime)campos[FechaModificacionInforcomf_NombreCol];
                    else
                        persona.IsFECHA_MODIFICACION_INFORMCONFNull = true;

                    if (campos.Contains(FechaModificacionJudicial_NombreCol))
                        persona.FECHA_MODIFICACION_JUDICIAL = (DateTime)campos[FechaModificacionJudicial_NombreCol];
                    else
                        persona.IsFECHA_MODIFICACION_JUDICIALNull = true;

                    if (persona.EN_JUDICIAL == Definiciones.SiNo.Si)
                    {//Si el persona esta en judicial debe tener un abogado asignado
                        if (!campos.Contains(AbogadoId_NombreCol))
                            throw new ArgumentException("Debe indicar el estudio jurídico al que fue asigando el persona");
                        else
                        {
                            dAux = decimal.Parse(campos[AbogadoId_NombreCol].ToString());
                            if (persona.IsABOGADO_IDNull || persona.ABOGADO_ID != dAux)
                            {
                                if (EstudiosJuridicosService.EstaActivo(dAux)) persona.ABOGADO_ID = dAux;
                                else throw new System.ArgumentException("El estudio jurídico seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                            }
                        }
                    }
                    else
                    {//Si no, no debe estar asignado a ningun estudio juridico
                        persona.IsABOGADO_IDNull = true;
                    }
                    if (campos.Contains(EsCliente_NombreCol))
                    {
                        //Si es Cliente se le debe asignar un tipo y un estado de morosidad
                        if (persona.ES_CLIENTE.Equals(Definiciones.SiNo.Si))
                        {
                            persona.TIPO_CLIENTE_ID = (decimal)campos[PersonasService.TipoClienteId_NombreCol];
                            persona.ESTADO_MOROSIDAD_ID = (decimal)campos[PersonasService.EstadoMorosidadId_NombreCol];
                        }
                    }


                    if (campos.Contains(PersonasService.EstadoCivilId_NombreCol))
                        persona.ESTADO_CIVIL_ID = (string)campos[PersonasService.EstadoCivilId_NombreCol];
                    else
                        persona.ESTADO_CIVIL_ID = string.Empty;

                    if (campos.Contains(PersonasService.NumeroHijos_NombreCol))
                        persona.NUMERO_HIJOS = (decimal)campos[PersonasService.NumeroHijos_NombreCol];

                    if (campos.Contains(PersonasService.TipoEmpleo_NombreCol))
                        persona.TIPO_EMPLEO = campos[TipoEmpleo_NombreCol].ToString();
                    else
                        persona.TIPO_EMPLEO = string.Empty;

                    if (campos.Contains(PorcDescuento_NombreCol))
                        persona.PORC_DESCUENTO_AUTOMATICO = decimal.Parse(campos[PorcDescuento_NombreCol].ToString());

                    if (campos.Contains(FechaUltimaVisita_NombreCol))
                        persona.FECHA_ULTIMA_VISITA = (DateTime)campos[FechaUltimaVisita_NombreCol];
                    else
                        persona.IsFECHA_ULTIMA_VISITANull = true;

                    if (campos.Contains(ZonaId_NombreCol))
                    {
                        persona.ZONA_COBRANZA_ID = (decimal)campos[ZonaId_NombreCol];
                        persona.COBRADOR_HABITUAL_ID = ZonasFuncionariosService.GetFuncionarioTipado(persona.ZONA_COBRANZA_ID, Definiciones.TipoFuncionarioComision.Cobrador);

                        if (persona.COBRADOR_HABITUAL_ID.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            persona.COBRADOR_HABITUAL_ID = ZonasFuncionariosService.GetFuncionarioTipado(persona.ZONA_COBRANZA_ID, Definiciones.TipoFuncionarioComision.CobradorExterno);

                        if (persona.COBRADOR_HABITUAL_ID.Equals(Definiciones.Error.Valor.EnteroPositivo))
                            persona.IsCOBRADOR_HABITUAL_IDNull = true;
                    }
                    else
                    {
                        if (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.TipoDeAsociacionCobranza) == Definiciones.TipoDeAsociacionCobranza.IndirectaPorZonaDeCobranza)
                            throw new Exception("Debe indicarse una zona de cobranza.");
                    }

                    //Si no se incluye el campo, actualizar a "ahora"
                    if (campos.Contains(FechaUltimaActualizacDatos_NombreCol))
                        persona.FECHA_ULTIMA_ACTUALIZAC_DATOS = (DateTime)campos[FechaUltimaActualizacDatos_NombreCol];
                    else
                        persona.FECHA_ULTIMA_ACTUALIZAC_DATOS = DateTime.Now;

                    if (insertarNuevo)
                        sesion.Db.PERSONASCollection.Insert(persona);
                    else
                        sesion.Db.PERSONASCollection.Update(persona);

                    #region Migracion
                    if (insertarNuevo)
                    {
                        var p = new PersonasService(persona.ID, sesion);
                        p.CrearEntidad(sesion);
                    }
                    else
                    {
                        var p = new PersonasService(persona.ID, sesion);
                        var modificar = new Dictionary<string, object>();
                        var borrar = new List<string>();

                        if (p.Nombre != personaOriginal.NOMBRE)
                        {
                            if (p.Nombre.Length > 0)
                                modificar[Modelo.NOMBREColumnName] = p.Nombre;
                            else
                                borrar.Add(Modelo.NOMBREColumnName);
                        }
                        if (p.Apellido != personaOriginal.APELLIDO)
                        {
                            if (p.Apellido.Length > 0)
                                modificar[Modelo.APELLIDOColumnName] = p.Apellido;
                            else
                                borrar.Add(Modelo.APELLIDOColumnName);
                        }
                        if (p.Codigo != personaOriginal.CODIGO)
                        {
                            if (p.Codigo.Length > 0)
                                modificar[Modelo.CODIGOColumnName] = p.Codigo;
                            else
                                borrar.Add(Modelo.CODIGOColumnName);
                        }
                        if (p.Telefono1 != personaOriginal.TELEFONO1)
                        {
                            if (p.Telefono1.Length > 0)
                                modificar[Modelo.TELEFONO1ColumnName] = p.Telefono1;
                            else
                                borrar.Add(Modelo.TELEFONO1ColumnName);
                        }
                        if (p.Telefono2 != personaOriginal.TELEFONO2)
                        {
                            if (p.Telefono2.Length > 0)
                                modificar[Modelo.TELEFONO2ColumnName] = p.Telefono2;
                            else
                                borrar.Add(Modelo.TELEFONO2ColumnName);
                        }
                        if (p.Telefono3 != personaOriginal.TELEFONO3)
                        {
                            if (p.Telefono3.Length > 0)
                                modificar[Modelo.TELEFONO3ColumnName] = p.Telefono3;
                            else
                                borrar.Add(Modelo.TELEFONO3ColumnName);
                        }
                        if (p.Telefono4 != personaOriginal.TELEFONO4)
                        {
                            if (p.Telefono4.Length > 0)
                                modificar[Modelo.TELEFONO4ColumnName] = p.Telefono4;
                            else
                                borrar.Add(Modelo.TELEFONO4ColumnName);
                        }
                        if (p.TelefonoCobranza1 != personaOriginal.TELEFONO_COBRANZA1)
                        {
                            if (p.TelefonoCobranza1.Length > 0)
                                modificar[Modelo.TELEFONO_COBRANZA1ColumnName] = p.TelefonoCobranza1;
                            else
                                borrar.Add(Modelo.TELEFONO_COBRANZA1ColumnName);
                        }
                        if (p.TelefonoCobranza2 != personaOriginal.TELEFONO_COBRANZA2)
                        {
                            if (p.TelefonoCobranza2.Length > 0)
                                modificar[Modelo.TELEFONO_COBRANZA2ColumnName] = p.TelefonoCobranza2;
                            else
                                borrar.Add(Modelo.TELEFONO_COBRANZA2ColumnName);
                        }

                        if (p.Calle1 != personaOriginal.CALLE1)
                        {
                            if (p.Calle1.Length > 0)
                                modificar[Modelo.CALLE1ColumnName] = p.Calle1;
                            else
                                borrar.Add(Modelo.CALLE1ColumnName);
                        }
                        if (p.Calle2 != personaOriginal.CALLE2)
                        {
                            if (p.Calle2.Length > 0)
                                modificar[Modelo.CALLE2ColumnName] = p.Calle2;
                            else
                                borrar.Add(Modelo.CALLE2ColumnName);
                        }
                        if (p.CalleCobranza != personaOriginal.CALLE_COBRANZA)
                        {
                            if (p.CalleCobranza.Length > 0)
                                modificar[Modelo.CALLE_COBRANZAColumnName] = p.CalleCobranza;
                            else
                                borrar.Add(Modelo.CALLE_COBRANZAColumnName);
                        }

                        if (modificar.Count > 0)
                            p.ModificarValores(modificar, sesion);
                        if (borrar.Count > 0)
                            p.BorrarValores(borrar, sesion);
                    }
                    #endregion Migracion

                    // En caso de que se eligio el conyuge a traves de otra persona. Se actualiza
                    // el id de conyuge en la otra persona
                    if (campos.Contains(PersonasService.PersonaIdConyuge_NombreCol))
                    {
                        PERSONASRow personaConyuge = new PERSONASRow();
                        String valorAnteriorConyuge = "";

                        personaConyuge = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + "=" + decimal.Parse(campos[PersonasService.PersonaIdConyuge_NombreCol].ToString()));
                        valorAnteriorConyuge = personaConyuge.ToString();
                        personaConyuge.PERSONA_ID_CONYUGE = persona.ID;
                        personaConyuge.CONYUGE_APELLIDO = string.Empty;
                        personaConyuge.CONYUGE_NOMBRE = string.Empty;

                        sesion.Db.PERSONASCollection.Update(personaConyuge);
                    }

                    if (campos.Contains("CreditosRequisitos"))
                    {
                        string[] requisitos = (string[])campos["CreditosRequisitos"];
                        PersonasCreditosRequisitosService personaCreditosRequisitos = new PersonasCreditosRequisitosService();
                        personaCreditosRequisitos.Guardar(sesion, persona.ID, requisitos);
                    }
                    #endregion Campos Opcionales
                    sesion.Db.PERSONASCollection.Update(persona);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, persona.ID, valorAnterior, persona.ToString(), sesion);
                    // Lo que va aqui debe ir luego al trigger after update

                    //Actualizamos los datos del Funcionario
                    if (!insertarNuevo) ActualizarFuncionario(persona, sesion);

                    #region Actualiza Linea de Credito

                    if (campos.Contains(NivelCreditoId_NombreCol))
                    {
                        decimal nivelCreditoId = Interprete.ObtenerDecimal(campos[NivelCreditoId_NombreCol]);
                        if (persona.IsNIVEL_CREDITO_IDNull || persona.NIVEL_CREDITO_ID != nivelCreditoId)
                        {
                            persona.NIVEL_CREDITO_ID = nivelCreditoId;

                            #region modificar linea de credito
                            PersonasNivelesCreditoService personaNivelCredito = new PersonasNivelesCreditoService();
                            DataRow nivelCredito = personaNivelCredito.GetPersonasNivelesCredito(nivelCreditoId);
                            decimal limiteInferiorCredito = (decimal)nivelCredito[PersonasNivelesCreditoService.LimiteInferiorCredito_NombreCol];

                            System.Collections.Hashtable camposLineaCredito = new System.Collections.Hashtable();

                            camposLineaCredito.Add(PersonasLineaCreditoService.PersonaId_NombreCol, persona.ID);
                            camposLineaCredito.Add(PersonasLineaCreditoService.MontoLineaCredito_NombreCol, limiteInferiorCredito);
                            camposLineaCredito.Add(PersonasLineaCreditoService.MonedaId_NombreCol, sesion.SucursalActiva.MONEDA_ID);
                            camposLineaCredito.Add(PersonasLineaCreditoService.Cotizacion_NombreCol, CotizacionesService.GetCotizacionMonedaCompra(sesion.SucursalActiva_pais_id, sesion.SucursalActiva.MONEDA_ID, DateTime.Now, sesion));
                            camposLineaCredito.Add(PersonasLineaCreditoService.Temporal_NombreCol, Definiciones.SiNo.No);
                            camposLineaCredito.Add(PersonasLineaCreditoService.Aprobado_NombreCol, Definiciones.SiNo.Si);

                            PersonasLineaCreditoService PersonaLineaCredito = new PersonasLineaCreditoService();
                            PersonaLineaCredito.Guardar(sesion, camposLineaCredito, true);
                            #endregion modificar linea de credito

                            persona.INGRESO_APROBADO = Definiciones.SiNo.No;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Debe indicar el nivel de crédito");
                    }
                    #endregion Actualiza Linea de Credito

                    sesion.Db.CommitTransaction();

                    #region controlar si tiene todos los requisitos
                    sesion.Db.BeginTransaction();
                    PersonasNivelesCreditoDetallesService NivelesCreditoDetalle = new PersonasNivelesCreditoDetallesService();
                    PersonasCreditosRequisitosService CreditosRequisitos = new PersonasCreditosRequisitosService();
                    string clausulas = PersonasNivelesCreditoDetallesService.PersonaNivelCreditoId_NombreCol + " = " + persona.NIVEL_CREDITO_ID;
                    DataTable table = NivelesCreditoDetalle.GetPersonasNivelesCreditoDetallesDataTable(clausulas, string.Empty);
                    bool tieneTodos = true;
                    foreach (DataRow row in table.Rows)
                        tieneTodos &= CreditosRequisitos.PersonaTieneRequisito(persona.ID, (decimal)row[PersonasNivelesCreditoDetallesService.Id_NombreCol]);

                    if (tieneTodos && (persona.ESTADO_DOCUMENTACION_ID == Definiciones.EstadosDocumentacion.FaltanDocumentos))
                    {
                        persona.ESTADO_DOCUMENTACION_ID = Definiciones.EstadosDocumentacion.EnOrden;
                    }
                    else
                    {
                        persona.ESTADO_DOCUMENTACION_ID = Definiciones.EstadosDocumentacion.FaltanDocumentos;
                    }
                    sesion.Db.PERSONASCollection.Update(persona);
                    sesion.Db.CommitTransaction();
                    #endregion controlar si tiene todos los requisitos

                    return persona.ID;
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe otra persona con el mismo tipo y número de documento.", exp);
                        default:
                            throw;
                    }
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Guardar

        #region ActualizarDatosJudiciales
        public static void ActualizarDatosJudiciales(decimal persona_id, decimal abogado_id, bool en_judicial, SessionService sesion)
        {
            var row = sesion.db.PERSONASCollection.GetByPrimaryKey(persona_id);
            string valorAnterior = row.ToString();

            row.FECHA_MODIFICACION_JUDICIAL = DateTime.Now;
            row.EN_JUDICIAL = en_judicial ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
            if (en_judicial)
                row.ABOGADO_ID = abogado_id;
            else
                row.IsABOGADO_IDNull = true;
            sesion.db.PERSONASCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion ActualizarDatosJudiciales

        #region Actualizar Funcionario
        /// <summary>
        /// Actualizars the funcionario.
        /// </summary>
        /// <param name="persona">The persona.</param>
        /// <param name="sesion">The sesion.</param>
        private static void ActualizarFuncionario(PERSONASRow persona, SessionService sesion)
        {
            try
            {
                String valorAnterior = "";
                FUNCIONARIOSRow funcionario = new FUNCIONARIOSRow();
                string clausula = FuncionariosService.Persona_IdNombreCol + " = " + persona.ID;
                funcionario = sesion.Db.FUNCIONARIOSCollection.GetRow(clausula);
                //Se comprueba la existencia del funcionario
                if (funcionario != null)
                {
                    valorAnterior = funcionario.ToString();
                    funcionario.ENTIDAD_ID = persona.ENTIDAD_ID;
                    funcionario.RUC = persona.RUC;
                    funcionario.TIPO_DOCUMENTO_IDENTIDAD_ID = persona.TIPO_DOCUMENTO_IDENTIDAD_ID;
                    funcionario.NUMERO_DOCUMENTO = persona.NUMERO_DOCUMENTO;
                    funcionario.TRATAMIENTO_ID = persona.TRATAMIENTO_ID;
                    funcionario.NOMBRE = persona.NOMBRE;
                    funcionario.APELLIDO = persona.APELLIDO;
                    funcionario.GENERO = persona.GENERO;
                    funcionario.GRUPO_SANGUINEO = persona.GRUPO_SANGUINEO;
                    if (!persona.IsNACIMIENTONull)
                        funcionario.NACIMIENTO = persona.NACIMIENTO;

                    if (!persona.IsPAIS_NACIONALIDAD_IDNull)
                        funcionario.PAIS_NACIONALIDAD_ID = persona.PAIS_NACIONALIDAD_ID;

                    if (!persona.IsPAIS_RESIDENCIA_IDNull)
                        funcionario.PAIS_RESIDENCIA_ID = persona.PAIS_RESIDENCIA_ID;

                    funcionario.PROFESION_ID = persona.PROFESION_ID;

                    if (!persona.IsDEPARTAMENTO1_IDNull)
                        funcionario.DEPARTAMENTO1_ID = persona.DEPARTAMENTO1_ID;

                    if (!persona.IsDEPARTAMENTO2_IDNull)
                        funcionario.DEPARTAMENTO2_ID = persona.DEPARTAMENTO2_ID;

                    if (!persona.IsCIUDAD1_IDNull)
                        funcionario.CIUDAD1_ID = persona.CIUDAD1_ID;

                    if (!persona.IsCIUDAD2_IDNull)
                        funcionario.CIUDAD2_ID = persona.CIUDAD2_ID;

                    if (!persona.IsBARRIO1_IDNull)
                        funcionario.BARRIO1_ID = persona.BARRIO1_ID;

                    if (!persona.IsBARRIO2_IDNull)
                        funcionario.BARRIO2_ID = persona.BARRIO2_ID;
                    funcionario.CALLE1 = persona.CALLE1;
                    funcionario.CALLE2 = persona.CALLE2;
                    funcionario.CODIGO_POSTAL1 = persona.CODIGO_POSTAL1;
                    funcionario.CODIGO_POSTAL2 = persona.CODIGO_POSTAL2;
                    funcionario.TELEFONO1 = persona.TELEFONO1;
                    funcionario.TELEFONO2 = persona.TELEFONO2;
                    funcionario.TELEFONO3 = persona.TELEFONO3;
                    funcionario.TELEFONO4 = persona.TELEFONO4;
                    funcionario.EMAIL1 = persona.EMAIL1;
                    funcionario.EMAIL2 = persona.EMAIL2;
                    funcionario.EMAIL3 = persona.EMAIL3;
                    funcionario.ESTADO = persona.ESTADO;

                    if (!persona.IsLATITUD1Null)
                    {
                        funcionario.LATITUD1 = persona.LATITUD1;
                        funcionario.IsLATITUD1Null = true;
                    }

                    if (!persona.IsLONGITUD1Null)
                    {
                        funcionario.LONGITUD1 = persona.LONGITUD1;
                        funcionario.IsLONGITUD1Null = true;
                    }

                    if (!persona.IsLATITUD2Null)
                    {
                        funcionario.LATITUD2 = persona.LATITUD2;
                        funcionario.IsLATITUD2Null = true;
                    }

                    if (!persona.IsLONGITUD2Null)
                    {
                        funcionario.LONGITUD2 = persona.LONGITUD2;
                        funcionario.IsLONGITUD2Null = true;
                    }


                    sesion.Db.FUNCIONARIOSCollection.Update(funcionario);
                    LogCambiosService.LogDeRegistro(FuncionariosService.Nombre_Tabla, funcionario.ID, valorAnterior, funcionario.ToString(), sesion);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }
        #endregion Actualizar Funcionario

        #region CrearPersona
        public static decimal CrearPersona(string nombre, string apellido, string documento_identidad, string codigo, bool persona_fisica)
        {
            return CrearPersona(nombre, apellido, documento_identidad, codigo, persona_fisica,
                                true, DateTime.Now, Definiciones.Paises.Paraguay, Definiciones.Paises.Paraguay,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, string.Empty, Definiciones.Error.Valor.EnteroPositivo, false);
        }
        public static decimal CrearPersona(string nombre, string apellido, string documento_identidad, string codigo, bool persona_fisica,
            decimal pais_nacionalidad_id, decimal pais_residencia_id, string email_1, string telefono)
        {
            return CrearPersona(nombre, apellido, documento_identidad, codigo, persona_fisica,
                                true, DateTime.Now, pais_nacionalidad_id, pais_residencia_id,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty, telefono, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, email_1, Definiciones.Error.Valor.EnteroPositivo, false);
        }
        public static decimal CrearPersona(string nombre, string apellido, string documento_identidad, string codigo, bool persona_fisica,
            decimal pais_nacionalidad_id, decimal pais_residencia_id, string email_1, string telefono, decimal tipoCliente, string tipo_documento,
            string ruc_dig_verificador)
        {
            return CrearPersona(nombre, apellido, documento_identidad, codigo, persona_fisica,
                                true, DateTime.Now, pais_nacionalidad_id, pais_residencia_id,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty, telefono, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, email_1, Definiciones.Error.Valor.EnteroPositivo, false, tipoCliente, tipo_documento, ruc_dig_verificador);
        }
        //este
        public static decimal CrearPersona(string nombre, string apellido, string documento_identidad, string codigo, bool persona_fisica,
            decimal pais_nacionalidad_id, decimal pais_residencia_id, string email_1, string telefono, decimal tipoCliente, string calleCobranza, string tipo_documento, string ruc_dig_verificador)
        {
            return CrearPersona(nombre, apellido, documento_identidad, codigo, persona_fisica,
                                true, DateTime.Now, pais_nacionalidad_id, pais_residencia_id,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, string.Empty,
                                Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo,
                                Definiciones.Error.Valor.EnteroPositivo, calleCobranza, telefono, string.Empty, string.Empty, string.Empty,
                                string.Empty, string.Empty, email_1, Definiciones.Error.Valor.EnteroPositivo, false, tipoCliente, tipo_documento, ruc_dig_verificador);
        }

        public static decimal CrearPersona(string nombre, string apellido, string documento_identidad, string codigo,
            bool persona_fisica, bool genero_masculino, DateTime nacimiento,
            decimal pais_nacionalidad_id, decimal pais_residencia_id, decimal direccion1_departamento, decimal direccion1_ciudad, decimal direccion1_barrio, string direccion1_calle, decimal direccion2_departamento, decimal direccion2_ciudad, decimal direccion2_barrio, string direccion2_calle, decimal direccion3_departamento, decimal direccion3_ciudad, decimal direccion3_barrio, string direccion3_calle,
            string telefono_1, string telefono_2, string telefono_3, string telefono_4, string telefono_cobranza_1, string telefono_cobranza_2, string email_1, decimal zona_cobranza_id, bool ingreso_aprobado)
        {
            try
            {
                decimal idCreado = Definiciones.Error.Valor.EnteroPositivo;
                Hashtable campos = new Hashtable();

                campos.Add(PersonasService.TratamientoId_NombreCol, genero_masculino ? Definiciones.Tratamientos.Senhor : Definiciones.Tratamientos.Senhora);
                campos.Add(PersonasService.Nombre_NombreCol, nombre);
                campos.Add(PersonasService.Apellido_NombreCol, apellido);
                campos.Add(PersonasService.EsCliente_NombreCol, Definiciones.SiNo.Si);
                campos.Add(PersonasService.EsContribuyente_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.TipoDocumentoIdentidadId_NombreCol, Definiciones.TiposDocumentoIdentidad.CI);
                campos.Add(PersonasService.NumeroDocumento_NombreCol, documento_identidad);
                campos.Add(PersonasService.Ruc_NombreCol, documento_identidad);
                campos.Add(PersonasService.ProfesionId_NombreCol, Definiciones.Profesiones.NoAplica);
                campos.Add(PersonasService.GrupoSanguineo_NombreCol, Definiciones.GrupoSanguineo.NoAplica);
                campos.Add(PersonasService.AgenteRetencion_NombreCol, Definiciones.SiNo.No);
                if (codigo.Length > 0) campos.Add(PersonasService.Codigo_NombreCol, codigo);
                campos.Add(PersonasService.CodigoExterno_NombreCol, string.Empty);
                campos.Add(PersonasService.Fisico_NombreCol, persona_fisica ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(PersonasService.Genero_NombreCol, genero_masculino ? Definiciones.Genero.Masculino : Definiciones.Genero.Femenino);
                campos.Add(PersonasService.Nacimiento_NombreCol, nacimiento.ToShortDateString());
                campos.Add(PersonasService.ConyugeNombre_NombreCol, string.Empty);
                campos.Add(PersonasService.ConyugeApellido_NombreCol, string.Empty);
                campos.Add(PersonasService.SeparacionBienes_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.EstadoDocumentacionId_NombreCol, Definiciones.EstadosDocumentacion.EnOrden);
                campos.Add(PersonasService.Estado_NombreCol, Definiciones.Estado.Activo);
                campos.Add(PersonasService.IngresoAprobado_NombreCol, ingreso_aprobado ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                if (ingreso_aprobado) campos.Add(PersonasService.FechaAprobacion_NombreCol, DateTime.Now.ToString());
                campos.Add(PersonasService.NumeroHijos_NombreCol, (decimal)0);

                campos.Add(PersonasService.PaisNacionalidadId_NombreCol, pais_nacionalidad_id);
                if (pais_nacionalidad_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos[PersonasService.PaisNacionalidadId_NombreCol] = Definiciones.Paises.Paraguay;

                campos.Add(PersonasService.PaisResidenciaId_NombreCol, pais_residencia_id);
                if (pais_residencia_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos[PersonasService.PaisResidenciaId_NombreCol] = Definiciones.Paises.Paraguay;

                if (!direccion1_departamento.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Departamento1Id_NombreCol, direccion1_departamento);

                if (!direccion1_ciudad.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Ciudad1Id_NombreCol, direccion1_ciudad);

                if (!direccion1_barrio.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Barrio1Id_NombreCol, direccion1_barrio);

                campos.Add(PersonasService.Calle1_NombreCol, direccion1_calle);
                campos.Add(PersonasService.CodigoPostal1_NombreCol, string.Empty);

                if (!direccion2_departamento.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Departamento2Id_NombreCol, direccion2_departamento);

                if (!direccion2_ciudad.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Ciudad2Id_NombreCol, direccion2_ciudad);

                if (!direccion2_barrio.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Barrio2Id_NombreCol, direccion2_barrio);

                campos.Add(PersonasService.Calle2_NombreCol, direccion2_calle);
                campos.Add(PersonasService.CodigoPostal2_NombreCol, string.Empty);

                if (!direccion3_departamento.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.DepartamentoCobranzaId_NombreCol, direccion3_departamento);

                if (!direccion3_ciudad.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.CiudadCobranzaId_NombreCol, direccion3_ciudad);

                if (!direccion3_barrio.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.BarrioCobranzaId_NombreCol, direccion3_barrio);

                campos.Add(PersonasService.CalleCobranza_NombreCol, direccion3_calle);
                campos.Add(PersonasService.CodigoPostalCobranzaId_NombreCol, string.Empty);

                campos.Add(PersonasService.Telefono1_NombreCol, telefono_1);
                campos.Add(PersonasService.Telefono2_NombreCol, telefono_2);
                campos.Add(PersonasService.Telefono3_NombreCol, telefono_3);
                campos.Add(PersonasService.Telefono4_NombreCol, telefono_4);
                campos.Add(PersonasService.TelefonoCobranza1_NombreCol, telefono_cobranza_1);
                campos.Add(PersonasService.TelefonoCobranza2_NombreCol, telefono_cobranza_2);
                campos.Add(PersonasService.Email1_NombreCol, email_1);
                campos.Add(PersonasService.Email2_NombreCol, string.Empty);
                campos.Add(PersonasService.Email3_NombreCol, string.Empty);
                campos.Add(PersonasService.PoseeUnipersonal_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.EmpresaNombreFantasia_NombreCol, string.Empty);
                campos.Add(PersonasService.EmpresaPersonaContacto_NombreCol, string.Empty);
                campos.Add(PersonasService.EmpresaTelefonoContacto_NombreCol, string.Empty);
                campos.Add(PersonasService.MonedaId_NombreCol, Definiciones.Monedas.Guaranies);
                campos.Add(PersonasService.MonedaLimiteCreditoId_NombreCol, Definiciones.Monedas.Guaranies);
                campos.Add(PersonasService.CondicionHabitualPagoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionDePagoPorDefecto));

                if (!zona_cobranza_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.ZonaId_NombreCol, zona_cobranza_id);

                campos.Add(PersonasService.EnInformconf_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.EnJudicial_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.NivelCreditoId_NombreCol, Definiciones.PersonasNivelesCredito.A);
                campos.Add(PersonasService.OperaCredito_NombreCol, Definiciones.SiNo.Si);
                campos.Add(PersonasService.Mayorista_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.PorcDescuento_NombreCol, (decimal)0);
                campos.Add(PersonasService.TipoClienteId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.PersonasTipoClienteIdPorDefecto));
                campos.Add(PersonasService.ListaPreciosId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.ListaDePrecioPorDefectoID));

                campos.Add(PersonasService.EstadoMorosidadId_NombreCol, Definiciones.EstadosMorosidad.NoAplica);

                idCreado = PersonasService.Guardar(campos, true);

                return idCreado;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static decimal CrearPersona(string nombre, string apellido, string documento_identidad, string codigo,
            bool persona_fisica, bool genero_masculino, DateTime nacimiento,
            decimal pais_nacionalidad_id, decimal pais_residencia_id, decimal direccion1_departamento, decimal direccion1_ciudad, decimal direccion1_barrio, string direccion1_calle, decimal direccion2_departamento, decimal direccion2_ciudad, decimal direccion2_barrio, string direccion2_calle, decimal direccion3_departamento, decimal direccion3_ciudad, decimal direccion3_barrio, string direccion3_calle,
            string telefono_1, string telefono_2, string telefono_3, string telefono_4, string telefono_cobranza_1,
            string telefono_cobranza_2, string email_1, decimal zona_cobranza_id, bool ingreso_aprobado, decimal tipo_cliente, string tipo_documento, string ruc_dig_verificador)
        {
            try
            {
                decimal idCreado = Definiciones.Error.Valor.EnteroPositivo;
                Hashtable campos = new Hashtable();

                campos.Add(PersonasService.TratamientoId_NombreCol, genero_masculino ? Definiciones.Tratamientos.Senhor : Definiciones.Tratamientos.Senhora);
                campos.Add(PersonasService.Nombre_NombreCol, nombre);
                campos.Add(PersonasService.Apellido_NombreCol, apellido);
                campos.Add(PersonasService.EsCliente_NombreCol, Definiciones.SiNo.Si);
                campos.Add(PersonasService.EsContribuyente_NombreCol, Definiciones.SiNo.No);
                //campos.Add(PersonasService.TipoDocumentoIdentidadId_NombreCol, Definiciones.TiposDocumentoIdentidad.CI);
                campos.Add(PersonasService.TipoDocumentoIdentidadId_NombreCol, tipo_documento);
                campos.Add(PersonasService.NumeroDocumento_NombreCol, documento_identidad);
                if (tipo_documento == Definiciones.TiposDocumentoIdentidad.RUC)
                    campos.Add(PersonasService.Ruc_NombreCol, documento_identidad + "-" + ruc_dig_verificador);
                else
                    campos.Add(PersonasService.Ruc_NombreCol, documento_identidad);
                campos.Add(PersonasService.ProfesionId_NombreCol, Definiciones.Profesiones.NoAplica);
                campos.Add(PersonasService.GrupoSanguineo_NombreCol, Definiciones.GrupoSanguineo.NoAplica);
                campos.Add(PersonasService.AgenteRetencion_NombreCol, Definiciones.SiNo.No);
                if (codigo.Length > 0) campos.Add(PersonasService.Codigo_NombreCol, codigo);
                campos.Add(PersonasService.CodigoExterno_NombreCol, string.Empty);
                campos.Add(PersonasService.Fisico_NombreCol, persona_fisica ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                campos.Add(PersonasService.Genero_NombreCol, genero_masculino ? Definiciones.Genero.Masculino : Definiciones.Genero.Femenino);
                campos.Add(PersonasService.Nacimiento_NombreCol, nacimiento.ToShortDateString());
                campos.Add(PersonasService.ConyugeNombre_NombreCol, string.Empty);
                campos.Add(PersonasService.ConyugeApellido_NombreCol, string.Empty);
                campos.Add(PersonasService.SeparacionBienes_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.EstadoDocumentacionId_NombreCol, Definiciones.EstadosDocumentacion.EnOrden);
                campos.Add(PersonasService.Estado_NombreCol, Definiciones.Estado.Activo);
                campos.Add(PersonasService.IngresoAprobado_NombreCol, ingreso_aprobado ? Definiciones.SiNo.Si : Definiciones.SiNo.No);
                if (ingreso_aprobado) campos.Add(PersonasService.FechaAprobacion_NombreCol, DateTime.Now.ToString());
                campos.Add(PersonasService.NumeroHijos_NombreCol, (decimal)0);

                campos.Add(PersonasService.PaisNacionalidadId_NombreCol, pais_nacionalidad_id);
                if (pais_nacionalidad_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos[PersonasService.PaisNacionalidadId_NombreCol] = Definiciones.Paises.Paraguay;

                campos.Add(PersonasService.PaisResidenciaId_NombreCol, pais_residencia_id);
                if (pais_residencia_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos[PersonasService.PaisResidenciaId_NombreCol] = Definiciones.Paises.Paraguay;

                if (!direccion1_departamento.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Departamento1Id_NombreCol, direccion1_departamento);

                if (!direccion1_ciudad.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Ciudad1Id_NombreCol, direccion1_ciudad);

                if (!direccion1_barrio.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Barrio1Id_NombreCol, direccion1_barrio);

                campos.Add(PersonasService.Calle1_NombreCol, direccion1_calle);
                campos.Add(PersonasService.CodigoPostal1_NombreCol, string.Empty);

                if (!direccion2_departamento.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Departamento2Id_NombreCol, direccion2_departamento);

                if (!direccion2_ciudad.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Ciudad2Id_NombreCol, direccion2_ciudad);

                if (!direccion2_barrio.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.Barrio2Id_NombreCol, direccion2_barrio);

                campos.Add(PersonasService.Calle2_NombreCol, direccion2_calle);
                campos.Add(PersonasService.CodigoPostal2_NombreCol, string.Empty);

                if (!direccion3_departamento.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.DepartamentoCobranzaId_NombreCol, direccion3_departamento);

                if (!direccion3_ciudad.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.CiudadCobranzaId_NombreCol, direccion3_ciudad);

                if (!direccion3_barrio.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.BarrioCobranzaId_NombreCol, direccion3_barrio);

                campos.Add(PersonasService.CalleCobranza_NombreCol, direccion3_calle);
                campos.Add(PersonasService.CodigoPostalCobranzaId_NombreCol, string.Empty);

                campos.Add(PersonasService.Telefono1_NombreCol, telefono_1);
                campos.Add(PersonasService.Telefono2_NombreCol, telefono_2);
                campos.Add(PersonasService.Telefono3_NombreCol, telefono_3);
                campos.Add(PersonasService.Telefono4_NombreCol, telefono_4);
                campos.Add(PersonasService.TelefonoCobranza1_NombreCol, telefono_cobranza_1);
                campos.Add(PersonasService.TelefonoCobranza2_NombreCol, telefono_cobranza_2);
                campos.Add(PersonasService.Email1_NombreCol, email_1);
                campos.Add(PersonasService.Email2_NombreCol, string.Empty);
                campos.Add(PersonasService.Email3_NombreCol, string.Empty);
                campos.Add(PersonasService.PoseeUnipersonal_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.EmpresaNombreFantasia_NombreCol, string.Empty);
                campos.Add(PersonasService.EmpresaPersonaContacto_NombreCol, string.Empty);
                campos.Add(PersonasService.EmpresaTelefonoContacto_NombreCol, string.Empty);
                campos.Add(PersonasService.MonedaId_NombreCol, Definiciones.Monedas.Guaranies);
                campos.Add(PersonasService.MonedaLimiteCreditoId_NombreCol, Definiciones.Monedas.Guaranies);
                campos.Add(PersonasService.CondicionHabitualPagoId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.CondicionDePagoPorDefecto));

                if (!zona_cobranza_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    campos.Add(PersonasService.ZonaId_NombreCol, zona_cobranza_id);

                campos.Add(PersonasService.EnInformconf_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.EnJudicial_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.NivelCreditoId_NombreCol, Definiciones.PersonasNivelesCredito.A);
                campos.Add(PersonasService.OperaCredito_NombreCol, Definiciones.SiNo.Si);
                campos.Add(PersonasService.Mayorista_NombreCol, Definiciones.SiNo.No);
                campos.Add(PersonasService.PorcDescuento_NombreCol, (decimal)0);
                campos.Add(PersonasService.TipoClienteId_NombreCol, tipo_cliente);
                campos.Add(PersonasService.ListaPreciosId_NombreCol, VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.ListaDePrecioPorDefectoID));

                campos.Add(PersonasService.EstadoMorosidadId_NombreCol, Definiciones.EstadosMorosidad.NoAplica);

                idCreado = PersonasService.Guardar(campos, true);

                return idCreado;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion CrearPersona

        #region ModificarDatosPersona (webservice)
        /// <summary>
        /// La idea es que ese método sea mutable en el sentido que SIEMPRE tiene que validar el dato antes de modificar la persona
        /// a diferencia de guardar que tiene datos que asume que van a venir en el hashtable
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="datosAModificar">The datos a modificar.</param>
        /// <returns></returns>
        public static bool ModificarDatosPersona(decimal persona_id, Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    bool exito = true;

                    PERSONASRow persona = new PERSONASRow();
                    String valorAnterior = "";
                    persona = sesion.Db.PERSONASCollection.GetRow(Id_NombreCol + "=" + persona_id);
                    valorAnterior = persona.ToString();

                    //////////////////////////
                    //si se agregan campos, agregar ordenados ALFABETICAMENTE
                    //////////////////////////
                    if (campos.Contains(PersonasService.Barrio1Id_NombreCol))
                        persona.BARRIO1_ID = (decimal)campos[PersonasService.Barrio1Id_NombreCol];

                    if (campos.Contains(PersonasService.Barrio2Id_NombreCol))
                        persona.BARRIO2_ID = (decimal)campos[PersonasService.Barrio2Id_NombreCol];

                    if (campos.Contains(PersonasService.BarrioCobranzaId_NombreCol))
                        persona.BARRIO_COBRANZA_ID = (decimal)campos[PersonasService.BarrioCobranzaId_NombreCol];

                    if (campos.Contains(PersonasService.Calle1_NombreCol))
                        persona.CALLE1 = (string)campos[PersonasService.Calle1_NombreCol];

                    if (campos.Contains(PersonasService.Calle2_NombreCol))
                        persona.CALLE2 = (string)campos[PersonasService.Calle2_NombreCol];

                    if (campos.Contains(PersonasService.CalleCobranza_NombreCol))
                        persona.CALLE_COBRANZA = (string)campos[PersonasService.CalleCobranza_NombreCol];

                    if (campos.Contains(PersonasService.Ciudad1Id_NombreCol))
                        persona.CIUDAD1_ID = (decimal)campos[PersonasService.Ciudad1Id_NombreCol];

                    if (campos.Contains(PersonasService.Ciudad2Id_NombreCol))
                        persona.CIUDAD2_ID = (decimal)campos[PersonasService.Ciudad2Id_NombreCol];

                    if (campos.Contains(PersonasService.CiudadCobranzaId_NombreCol))
                        persona.CIUDAD_COBRANZA_ID = (decimal)campos[PersonasService.CiudadCobranzaId_NombreCol];

                    if (campos.Contains(PersonasService.Departamento1Id_NombreCol))
                        persona.DEPARTAMENTO1_ID = (decimal)campos[PersonasService.Departamento1Id_NombreCol];

                    if (campos.Contains(PersonasService.Departamento2Id_NombreCol))
                        persona.DEPARTAMENTO2_ID = (decimal)campos[PersonasService.Departamento2Id_NombreCol];

                    if (campos.Contains(PersonasService.DepartamentoCobranzaId_NombreCol))
                        persona.DEPARTAMENTO_COBRANZA_ID = (decimal)campos[PersonasService.DepartamentoCobranzaId_NombreCol];

                    if (campos.Contains(PersonasService.EstadoMorosidadId_NombreCol))
                        persona.ESTADO_MOROSIDAD_ID = (decimal)campos[PersonasService.EstadoMorosidadId_NombreCol];

                    if (campos.Contains(PersonasService.Telefono1_NombreCol))
                        persona.TELEFONO1 = (string)campos[PersonasService.Telefono1_NombreCol];

                    if (campos.Contains(PersonasService.Telefono2_NombreCol))
                        persona.TELEFONO2 = (string)campos[PersonasService.Telefono2_NombreCol];

                    if (campos.Contains(PersonasService.Telefono3_NombreCol))
                        persona.TELEFONO3 = (string)campos[PersonasService.Telefono3_NombreCol];

                    if (campos.Contains(PersonasService.TelefonoCobranza1_NombreCol))
                        persona.TELEFONO_COBRANZA1 = (string)campos[PersonasService.TelefonoCobranza1_NombreCol];

                    if (campos.Contains(PersonasService.TelefonoCobranza2_NombreCol))
                        persona.TELEFONO_COBRANZA2 = (string)campos[PersonasService.TelefonoCobranza2_NombreCol];

                    if (campos.Contains(PersonasService.TipoClienteId_NombreCol))
                    {
                        if (exito && (exito = TipoClientesService.EstaActivo((decimal)campos[PersonasService.TipoClienteId_NombreCol])))
                            persona.TIPO_CLIENTE_ID = (decimal)campos[PersonasService.TipoClienteId_NombreCol];
                    }

                    if (campos.Contains(PersonasService.ZonaId_NombreCol))
                    {
                        if (exito && (exito = ZonasService.EstaActivo((decimal)campos[PersonasService.ZonaId_NombreCol])))
                            persona.ZONA_COBRANZA_ID = (decimal)campos[PersonasService.ZonaId_NombreCol];
                    }

                    if (exito)
                    {
                        sesion.Db.PERSONASCollection.Update(persona);
                        LogCambiosService.LogDeRegistro(Nombre_Tabla, persona.ID, valorAnterior, persona.ToString(), sesion);
                    }

                    return exito;
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion ModificarDatosPersona (webservice)

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "PERSONAS"; }
        }
        public static string Nombre_Vista
        {
            get { return "PERSONAS_INFO_COMPLETA"; }
        }
        public static string Id_NombreCol
        {
            get { return PERSONASCollection.IDColumnName; }
        }
        public static string AbogadoId_NombreCol
        {
            get { return PERSONASCollection.ABOGADO_IDColumnName; }
        }
        public static string AgenteRetencion_NombreCol
        {
            get { return PERSONASCollection.AGENTE_RETENCIONColumnName; }
        }
        public static string Apellido_NombreCol
        {
            get { return PERSONASCollection.APELLIDOColumnName; }
        }
        public static string BanderaRetencion_NombreCol
        {
            get { return PERSONASCollection.BANDERA_RETENCIONColumnName; }
        }
        public static string BarrioCobranzaId_NombreCol
        {
            get { return PERSONASCollection.BARRIO_COBRANZA_IDColumnName; }
        }
        public static string Barrio1Id_NombreCol
        {
            get { return PERSONASCollection.BARRIO1_IDColumnName; }
        }
        public static string Barrio2Id_NombreCol
        {
            get { return PERSONASCollection.BARRIO2_IDColumnName; }
        }
        public static string CalleCobranza_NombreCol
        {
            get { return PERSONASCollection.CALLE_COBRANZAColumnName; }
        }
        public static string Calle1_NombreCol
        {
            get { return PERSONASCollection.CALLE1ColumnName; }
        }
        public static string Calle2_NombreCol
        {
            get { return PERSONASCollection.CALLE2ColumnName; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return PERSONASCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string CiudadCobranzaId_NombreCol
        {
            get { return PERSONASCollection.CIUDAD_COBRANZA_IDColumnName; }
        }
        public static string Ciudad1Id_NombreCol
        {
            get { return PERSONASCollection.CIUDAD1_IDColumnName; }
        }
        public static string Ciudad2Id_NombreCol
        {
            get { return PERSONASCollection.CIUDAD2_IDColumnName; }
        }
        public static string CobradorHabitualId_NombreCol
        {
            get { return PERSONASCollection.COBRADOR_HABITUAL_IDColumnName; }
        }
        public static string CodigoPostalCobranzaId_NombreCol
        {
            get { return PERSONASCollection.CODIGO_POSTAL_COBRANZAColumnName; }
        }
        public static string CodigoPostal1_NombreCol
        {
            get { return PERSONASCollection.CODIGO_POSTAL1ColumnName; }
        }
        public static string CodigoPostal2_NombreCol
        {
            get { return PERSONASCollection.CODIGO_POSTAL2ColumnName; }
        }
        public static string Codigo_NombreCol
        {
            get { return PERSONASCollection.CODIGOColumnName; }
        }
        public static string CodigoExterno_NombreCol
        {
            get { return PERSONASCollection.CODIGO_EXTERNOColumnName; }
        }
        public static string CondicionHabitualPagoId_NombreCol
        {
            get { return PERSONASCollection.CONDICION_HABITUAL_PAGO_IDColumnName; }
        }
        public static string ContadorCreditoActual_NombreCol
        {
            get { return PERSONASCollection.CONTADOR_CREDITO_ACTUALColumnName; }
        }
        public static string ConyugeApellido_NombreCol
        {
            get { return PERSONASCollection.CONYUGE_APELLIDOColumnName; }
        }
        public static string ConyugeNombre_NombreCol
        {
            get { return PERSONASCollection.CONYUGE_NOMBREColumnName; }
        }
        public static string DepartamentoCobranzaId_NombreCol
        {
            get { return PERSONASCollection.DEPARTAMENTO_COBRANZA_IDColumnName; }
        }
        public static string Departamento1Id_NombreCol
        {
            get { return PERSONASCollection.DEPARTAMENTO1_IDColumnName; }
        }
        public static string Departamento2Id_NombreCol
        {
            get { return PERSONASCollection.DEPARTAMENTO2_IDColumnName; }
        }
        public static string Email1_NombreCol
        {
            get { return PERSONASCollection.EMAIL1ColumnName; }
        }
        public static string Email2_NombreCol
        {
            get { return PERSONASCollection.EMAIL2ColumnName; }
        }
        public static string Email3_NombreCol
        {
            get { return PERSONASCollection.EMAIL3ColumnName; }
        }
        public static string EmpresaFundacion_NombreCol
        {
            get { return PERSONASCollection.EMPRESA_FUNDACIONColumnName; }
        }
        public static string EmpresaNombreFantasia_NombreCol
        {
            get { return PERSONASCollection.EMPRESA_NOMBRE_FANTASIAColumnName; }
        }
        public static string EmpresaPersonaContacto_NombreCol
        {
            get { return PERSONASCollection.EMPRESA_PERSONA_CONTACTOColumnName; }
        }
        public static string EmpresaTelefonoContacto_NombreCol
        {
            get { return PERSONASCollection.EMPRESA_TELEFONO_CONTACTOColumnName; }
        }
        public static string EnInformconf_NombreCol
        {
            get { return PERSONASCollection.EN_INFORMCONFColumnName; }
        }
        public static string EnJudicial_NombreCol
        {
            get { return PERSONASCollection.EN_JUDICIALColumnName; }
        }
        public static string EntidadId_NombreCol
        {
            get { return PERSONASCollection.ENTIDAD_IDColumnName; }
        }
        public static string EsCliente_NombreCol
        {
            get { return PERSONASCollection.ES_CLIENTEColumnName; }
        }
        public static string EsContribuyente_NombreCol
        {
            get { return PERSONASCollection.ES_CONTRIBUYENTEColumnName; }
        }

        public static string NroTarjetaRedPago_NombreCol
        {
            get { return PERSONASCollection.NRO_TARJETA_RED_PAGOColumnName; }
        }

        public static string EstadoDocumentacionId_NombreCol
        {
            get { return PERSONASCollection.ESTADO_DOCUMENTACION_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return PERSONASCollection.ESTADOColumnName; }
        }
        public static string FechaAprobacion_NombreCol
        {
            get { return PERSONASCollection.FECHA_APROBACIONColumnName; }
        }
        public static string FechaModificacionJudicial_NombreCol
        {
            get { return PERSONASCollection.FECHA_MODIFICACION_JUDICIALColumnName; }
        }
        public static string FechaUltimaActualizacDatos_NombreCol
        {
            get { return PERSONASCollection.FECHA_ULTIMA_ACTUALIZAC_DATOSColumnName; }
        }
        public static string FechaUltimaVisita_NombreCol
        {
            get { return PERSONASCollection.FECHA_ULTIMA_VISITAColumnName; }
        }
        public static string Fisico_NombreCol
        {
            get { return PERSONASCollection.FISICOColumnName; }
        }
        public static string Genero_NombreCol
        {
            get { return PERSONASCollection.GENEROColumnName; }
        }
        public static string GrupoSanguineo_NombreCol
        {
            get { return PERSONASCollection.GRUPO_SANGUINEOColumnName; }
        }
        public static string IngresoAprobado_NombreCol
        {
            get { return PERSONASCollection.INGRESO_APROBADOColumnName; }
        }
        public static string Latitud1_NombreCol
        {
            get { return PERSONASCollection.LATITUD1ColumnName; }
        }
        public static string Latitud2_NombreCol
        {
            get { return PERSONASCollection.LATITUD2ColumnName; }
        }
        public static string LatitudCobranza_NombreCol
        {
            get { return PERSONASCollection.LATITUD_COBRANZAColumnName; }
        }
        public static string Longitud1_NombreCol
        {
            get { return PERSONASCollection.LONGITUD1ColumnName; }
        }
        public static string Longitud2_NombreCol
        {
            get { return PERSONASCollection.LONGITUD2ColumnName; }
        }
        public static string LongitudCobranza_NombreCol
        {
            get { return PERSONASCollection.LONGITUD_COBRANZAColumnName; }
        }
        public static string Mayorista_NombreCol
        {
            get { return PERSONASCollection.MAYORISTAColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PERSONASCollection.MONEDA_IDColumnName; }
        }
        public static string MonedaLimiteCreditoId_NombreCol
        {
            get { return PERSONASCollection.MONEDA_LIMITE_CREDITO_IDColumnName; }
        }
        public static string Nacimiento_NombreCol
        {
            get { return PERSONASCollection.NACIMIENTOColumnName; }
        }
        public static string NombreFantasia_NombreCol
        {
            get { return PERSONASCollection.NOMBRE_FANTASIAColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return PERSONASCollection.NOMBREColumnName; }
        }
        public static string NumeroDocumento_NombreCol
        {
            get { return PERSONASCollection.NUMERO_DOCUMENTOColumnName; }
        }
        public static string OperaCredito_NombreCol
        {
            get { return PERSONASCollection.OPERA_CREDITOColumnName; }
        }
        public static string PaisNacionalidadId_NombreCol
        {
            get { return PERSONASCollection.PAIS_NACIONALIDAD_IDColumnName; }
        }
        public static string PaisResidenciaId_NombreCol
        {
            get { return PERSONASCollection.PAIS_RESIDENCIA_IDColumnName; }
        }
        public static string PoseeUnipersonal_NombreCol
        {
            get { return PERSONASCollection.POSEE_UNIPERSONALColumnName; }
        }
        public static string ProfesionId_NombreCol
        {
            get { return PERSONASCollection.PROFESION_IDColumnName; }
        }
        public static string PorcDescuento_NombreCol
        {
            get { return PERSONASCollection.PORC_DESCUENTO_AUTOMATICOColumnName; }
        }
        public static string RubroId_NombreCol
        {
            get { return PERSONASCollection.RUBRO_IDColumnName; }
        }
        public static string Ruc_NombreCol
        {
            get { return PERSONASCollection.RUCColumnName; }
        }
        public static string TelefonoCobranza1_NombreCol
        {
            get { return PERSONASCollection.TELEFONO_COBRANZA1ColumnName; }
        }
        public static string TelefonoCobranza2_NombreCol
        {
            get { return PERSONASCollection.TELEFONO_COBRANZA2ColumnName; }
        }
        public static string Telefono1_NombreCol
        {
            get { return PERSONASCollection.TELEFONO1ColumnName; }
        }
        public static string Telefono2_NombreCol
        {
            get { return PERSONASCollection.TELEFONO2ColumnName; }
        }
        public static string Telefono3_NombreCol
        {
            get { return PERSONASCollection.TELEFONO3ColumnName; }
        }
        public static string Telefono4_NombreCol
        {
            get { return PERSONASCollection.TELEFONO4ColumnName; }
        }
        public static string TipoDocumentoIdentidadId_NombreCol
        {
            get { return PERSONASCollection.TIPO_DOCUMENTO_IDENTIDAD_IDColumnName; }
        }
        public static string TratamientoId_NombreCol
        {
            get { return PERSONASCollection.TRATAMIENTO_IDColumnName; }
        }
        public static string UsuarioAprobacionId_NombreCol
        {
            get { return PERSONASCollection.USUARIO_APROBACION_IDColumnName; }
        }
        public static string VendedorHabitualId_NombreCol
        {
            get { return PERSONASCollection.VENDEDOR_HABITUAL_IDColumnName; }
        }
        public static string NivelCreditoId_NombreCol
        {
            get { return PERSONASCollection.NIVEL_CREDITO_IDColumnName; }
        }
        public static string EstadoCivilId_NombreCol
        {
            get { return PERSONASCollection.ESTADO_CIVIL_IDColumnName; }
        }
        public static string PersonaIdConyuge_NombreCol
        {
            get { return PERSONASCollection.PERSONA_ID_CONYUGEColumnName; }
        }
        public static string Modificable_NombreCol
        {
            get { return PERSONASCollection.MODIFICABLEColumnName; }
        }
        public static string NumeroHijos_NombreCol
        {
            get { return PERSONASCollection.NUMERO_HIJOSColumnName; }
        }
        public static string TipoEmpleo_NombreCol
        {
            get { return PERSONASCollection.TIPO_EMPLEOColumnName; }
        }
        public static string FechaModificacionInforcomf_NombreCol
        {
            get { return PERSONASCollection.FECHA_MODIFICACION_INFORMCONFColumnName; }
        }
        public static string SeparacionBienes_NombreCol
        {
            get { return PERSONASCollection.SEPARACION_BIENESColumnName; }
        }
        public static string NombreCompleto_NombreCol
        {
            get { return PERSONASCollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string TextoPredefinidoId_NombreCol
        {
            get { return PERSONASCollection.TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string ZonaId_NombreCol
        {
            get { return PERSONASCollection.ZONA_COBRANZA_IDColumnName; }
        }
        public static string TipoClienteId_NombreCol
        {
            get { return PERSONASCollection.TIPO_CLIENTE_IDColumnName; }
        }
        public static string EstadoMorosidadId_NombreCol
        {
            get { return PERSONASCollection.ESTADO_MOROSIDAD_IDColumnName; }
        }
        public static string ListaPreciosId_NombreCol
        {
            get { return PERSONASCollection.LISTA_PRECIOS_IDColumnName; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaTratamiento_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.TRATAMIENTOColumnName; }
        }
        public static string VistaPaisNacionalidad_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.PAIS_NACIONALIDADColumnName; }
        }
        public static string VistaPaisResidencia_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.PAIS_RESIDENCIAColumnName; }
        }
        public static string VistaAbogadoNombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.ABOGADO_NOMBREColumnName; }
        }
        public static string VistaProfesionNombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.PROFESION_NOMBREColumnName; }
        }
        public static string VistaDepartamento1Nombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.DEPARTAMENT01_NOMBREColumnName; }
        }
        public static string VistaDepartamentoCobranza_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.DEPARTAMENTO_COBRANZAColumnName; }
        }
        public static string VistaDepartamento2Nombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.DEPARTAMENTO2_NOMBREColumnName; }
        }
        public static string VistaCiudadCobranza_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.CIUDAD_COBRANZAColumnName; }
        }
        public static string VistaCiudad1Nombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.CIUDAD1_NOMBREColumnName; }
        }
        public static string VistaCiudad2Nombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.CIUDAD2_NOMBREColumnName; }
        }
        public static string VistaBarrioCobranza_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.BARRIO_COBRANZAColumnName; }
        }
        public static string VistaBarrio1Nombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.BARRIO1_NOMBREColumnName; }
        }
        public static string VistaBarrio2Nombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.BARRIO2_NOMBREColumnName; }
        }
        public static string VistaRubroNombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.RUBRO_NOMBREColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaLimiteCredito_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.MONEDA_LIMITE_CREDITOColumnName; }
        }
        public static string VistaDocumentacionEstado_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.DOCUMENTACION_ESTADOColumnName; }
        }
        public static string VistaNivelCredito_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.NIVEL_CREDITOColumnName; }
        }
        public static string VistaEstadoCivilDescripcion_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.ESTADO_CIVIL_DESCRIPCIONColumnName; }
        }
        public static string VistaDescripcionPersonaCalificaion_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.DESCRIPCION_CALIFICACIONColumnName; }
        }
        public static string VistaZonaNombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.ZONA_NOMBREColumnName; }
        }
        public static string VistaZonaAbreviatura_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.ZONA_ABREVIATURAColumnName; }
        }
        public static string PersonaCalificacionId_NombreCol
        {
            get { return PERSONASCollection.PERSONA_CALIFICACION_IDColumnName; }
        }
        public static string VistaTipoClientes_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.TIPO_CLIENTES_NOMBREColumnName; }
        }
        public static string VistaEstadoMorosidad_Nombrecol
        {
            get { return PERSONAS_INFO_COMPLETACollection.ESTADO_MOROSIDAD_NOMBREColumnName; }
        }
        public static string VistaVendedorFuncionarioHabitualNombre_Nombrecol
        {
            get { return PERSONAS_INFO_COMPLETACollection.VENDEDOR_HABITUAL_NOMBREColumnName; }
        }
        public static string VistaVendedorFuncionarioHabitualCodigo_Nombrecol
        {
            get { return PERSONAS_INFO_COMPLETACollection.VENDEDOR_HABITUAL_CODIGOColumnName; }
        }

        #endregion Accessors

        #region Por borrar
        public static string VistaNombre_NombreCol
        {
            get { return PERSONAS_INFO_COMPLETACollection.NOMBRE_COMPLETOColumnName; }
        }
        #endregion Por borrar

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static PersonasService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new PersonasService(e.RegistroId, sesion);
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

        /// <summary>
        /// Crears the entidad.
        /// </summary>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public EdiCBA.Estructura CrearEntidad(SessionService sesion)
        {
            EdiCBA.Persona p = new EdiCBA.Persona
            {
                objeto_nombre = PersonasService.Nombre_Tabla,
                uuid = this.GetOrCreateUUID(sesion),
                nombre = this.Nombre,
                apellido = this.Apellido,
                codigo = this.Codigo,
            };

            #region telefonos
            List<EdiCBA.Telefono> lTelefonos = new List<EdiCBA.Telefono>();
            var dTelefonos = new Dictionary<string, string>
            {
                { PersonasService.Telefono1_NombreCol, this.Telefono1 },
                { PersonasService.Telefono2_NombreCol, this.Telefono2 },
                { PersonasService.Telefono3_NombreCol, this.Telefono3 },
                { PersonasService.Telefono4_NombreCol, this.Telefono4 },
                { PersonasService.TelefonoCobranza1_NombreCol, this.TelefonoCobranza1 },
                { PersonasService.TelefonoCobranza2_NombreCol, this.TelefonoCobranza2 },
            };

            foreach (KeyValuePair<string, string> item in dTelefonos)
            {
                if (item.Value.Length > 0)
                {
                    lTelefonos.Add(new EdiCBA.Telefono
                    {
                        objeto_nombre = item.Key,
                        uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, item.Key, this.Id.Value, sesion),
                        numero = item.Value
                    });
                }
            }
            if (lTelefonos.Count > 0)
                p.telefonos = lTelefonos;
            #endregion telefonos

            #region documentos
            List<EdiCBA.Documento> lDocumentos = new List<EdiCBA.Documento>();
            DataTable dtPersona = PersonasService.GetPersonasInfoCompleta2(PersonasService.Id_NombreCol + " = " + this.Id.ToString(), string.Empty, false, sesion);
            lDocumentos.Add(new EdiCBA.Documento()
            {
                tipo = EdiCBA.TipoDocumento.RUC,
                numero = this.RUC,
                emision = DateTime.Now,
                vencimiento = DateTime.Now
            });
            lDocumentos.Add(new EdiCBA.Documento()
            {
                tipo = EdiCBA.TipoDocumento.CedulaIdentidad, //COMO SE EXTRAE EL VALOR QUE ESTA EN EL TEXTBOX???
                numero = this.NumeroDocumento,
                emision = DateTime.Now,
                vencimiento = DateTime.Now
            });

            if (lDocumentos.Count > 0)
                p.documentos = lDocumentos;
            #endregion documentos

            #region direcciones
            List<EdiCBA.Direccion> lDirecciones = new List<EdiCBA.Direccion>();
            var dDirecciones = new Dictionary<string, string[]>
            {
                { PersonasService.Calle1_NombreCol, new string[] { this.Calle1 } },
                { PersonasService.Calle2_NombreCol, new string[] { this.Calle2 } },
                { PersonasService.CalleCobranza_NombreCol, new string[] { this.CalleCobranza } },
            };

            foreach (KeyValuePair<string, string[]> item in dDirecciones)
            {
                if (item.Value[0].Length > 0)
                {
                    lDirecciones.Add(new EdiCBA.Direccion
                    {
                        objeto_nombre = item.Key,
                        uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, item.Key, this.Id.Value, sesion),
                        calle = item.Value[0]
                    });
                }
            }
            if (lDirecciones.Count > 0)
                p.direcciones = lDirecciones;
            #endregion direcciones

            var resultado = MigracionUtil.CrearMK2("Cliente", p);
            var pResultado = JsonUtil.Deserializar<EdiCBA.Persona>(resultado);

            return pResultado;
        }

        public EdiCBA.Estructura BorrarEntidad(SessionService sesion)
        {
            EdiCBA.Persona p = new EdiCBA.Persona
            {
                uuid = this.GetOrCreateUUID(sesion),
            };

            var resultado = MigracionUtil.BorrarMK2("Cliente", p);
            var pResultado = JsonUtil.Deserializar<EdiCBA.Persona>(resultado);

            return pResultado;
        }

        public EdiCBA.Estructura ModificarValores(Dictionary<string, object> valores, SessionService sesion)
        {
            List<EdiCBA.Telefono> lTelefonos = new List<EdiCBA.Telefono>();
            List<EdiCBA.Direccion> lDirecciones = new List<EdiCBA.Direccion>();

            EdiCBA.Persona p = new EdiCBA.Persona
            {
                uuid = this.GetOrCreateUUID(sesion),
            };

            foreach (KeyValuePair<string, object> item in valores)
            {
                switch (item.Key)
                {
                    case Modelo.NOMBRE_COMPLETOColumnName:
                        p.nombre = (string)item.Value;
                        break;
                    case Modelo.APELLIDOColumnName:
                        p.nombre = (string)item.Value;
                        break;
                    case Modelo.CODIGOColumnName:
                        p.codigo = (string)item.Value;
                        break;
                    case Modelo.TELEFONO1ColumnName:
                    case Modelo.TELEFONO2ColumnName:
                    case Modelo.TELEFONO3ColumnName:
                    case Modelo.TELEFONO4ColumnName:
                    case Modelo.TELEFONO_COBRANZA1ColumnName:
                    case Modelo.TELEFONO_COBRANZA2ColumnName:
                        lTelefonos.Add(new EdiCBA.Telefono
                        {
                            objeto_nombre = item.Key,
                            uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, item.Key, this.Id.Value, sesion),
                            numero = (string)item.Value
                        });
                        break;
                    case Modelo.CALLE1ColumnName:
                    case Modelo.CALLE2ColumnName:
                    case Modelo.CALLE_COBRANZAColumnName:
                        lDirecciones.Add(new EdiCBA.Direccion
                        {
                            objeto_nombre = item.Key,
                            uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, item.Key, this.Id.Value, sesion),
                            calle = (string)item.Value
                        });
                        break;
                }
            }

            if (lTelefonos.Count > 0)
                p.telefonos = lTelefonos;
            if (lDirecciones.Count > 0)
                p.direcciones = lDirecciones;

            var resultado = MigracionUtil.ModificarMK2("Cliente", p);
            var pResultado = JsonUtil.Deserializar<EdiCBA.Persona>(resultado);

            return pResultado;
        }

        public EdiCBA.Estructura BorrarValores(List<string> campos, SessionService sesion)
        {
            //Todavia no implementado
            return new EdiCBA.Estructura();
        }
        #endregion interfaz IEntidadMigrable

        #region Propiedades
        protected PERSONASRow row;
        protected PERSONASRow rowSinModificar;
        public class Modelo : PERSONASCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? AbogadoId { get { if (row.IsABOGADO_IDNull) return null; else return row.ABOGADO_ID; } set { if (value.HasValue) row.ABOGADO_ID = value.Value; else row.IsABOGADO_IDNull = true; } }
        public string Apellido { get { return row.APELLIDO; } set { row.APELLIDO = value; } }
        public string Calle1 { get { return ClaseCBABase.GetStringHelper(row.CALLE1); } set { row.CALLE1 = value; } }
        public string Calle2 { get { return ClaseCBABase.GetStringHelper(row.CALLE2); } set { row.CALLE2 = value; } }
        public string CalleCobranza { get { return ClaseCBABase.GetStringHelper(row.CALLE_COBRANZA); } set { row.CALLE_COBRANZA = value; } }
        public decimal? CiudadCobranzaId { get { if (row.IsCIUDAD_COBRANZA_IDNull) return null; else return row.CIUDAD_COBRANZA_ID; } set { if (value.HasValue) { this._ciudad_cobranza = null; row.CIUDAD_COBRANZA_ID = value.Value; } else { row.IsCIUDAD_COBRANZA_IDNull = true; } } }
        public string Codigo { get { return ClaseCBABase.GetStringHelper(row.CODIGO); } set { row.CODIGO = value; } }
        public string CodigoExterno { get { return ClaseCBABase.GetStringHelper(row.CODIGO_EXTERNO); } set { row.CODIGO_EXTERNO = value; } }
        public decimal CondicionHabitualPagoId { get { return row.CONDICION_HABITUAL_PAGO_ID; } set { row.CONDICION_HABITUAL_PAGO_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Email1 { get { return ClaseCBABase.GetStringHelper(row.EMAIL1); } set { row.EMAIL1 = value; } }
        public string Email2 { get { return ClaseCBABase.GetStringHelper(row.EMAIL2); } set { row.EMAIL2 = value; } }
        public string Email3 { get { return ClaseCBABase.GetStringHelper(row.EMAIL3); } set { row.EMAIL3 = value; } }
        public string EnInformconf { get { return ClaseCBABase.GetStringHelper(row.EN_INFORMCONF); } set { row.EN_INFORMCONF = value; } }
        public string EnJudicial { get { return ClaseCBABase.GetStringHelper(row.EN_JUDICIAL); } set { row.EN_JUDICIAL = value; } }
        public string EstadoCivilId { get { return ClaseCBABase.GetStringHelper(row.ESTADO_CIVIL_ID); } set { row.ESTADO_CIVIL_ID = value; } }
        public DateTime? FechaModificacionJudicial { get { if (row.IsFECHA_MODIFICACION_JUDICIALNull) return null; else return row.FECHA_MODIFICACION_JUDICIAL; } set { if (value.HasValue) row.FECHA_MODIFICACION_JUDICIAL = value.Value; else row.IsFECHA_MODIFICACION_JUDICIALNull = true; } }
        public DateTime FechaUltimaActualizacDatos { get { return row.FECHA_ULTIMA_ACTUALIZAC_DATOS; } set { row.FECHA_ULTIMA_ACTUALIZAC_DATOS = value; } }
        public string Fisico { get { return ClaseCBABase.GetStringHelper(row.FISICO); } set { row.FISICO = value; } }
        public decimal MonedaLimiteCreditoId { get { return row.MONEDA_LIMITE_CREDITO_ID; } set { row.MONEDA_LIMITE_CREDITO_ID = value; } }
        public DateTime? Nacimiento { get { if (row.IsNACIMIENTONull) return null; else return row.NACIMIENTO; } set { if (value.HasValue) row.NACIMIENTO = value.Value; else row.IsNACIMIENTONull = true; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string NombreCompleto { get { return row.NOMBRE_COMPLETO; } }
        public string NumeroDocumento { get { return ClaseCBABase.GetStringHelper(row.NUMERO_DOCUMENTO); } set { row.NUMERO_DOCUMENTO = value; } }
        public decimal? PaisResidenciaId { get { if (row.IsPAIS_RESIDENCIA_IDNull) return null; else return row.PAIS_RESIDENCIA_ID; } set { if (value.HasValue) { this._pais_residencia = null; row.PAIS_RESIDENCIA_ID = value.Value; } else { row.IsPAIS_RESIDENCIA_IDNull = true; } } }
        public decimal? PersonaIdConyuge { get { if (row.IsPERSONA_ID_CONYUGENull) return null; else return row.PERSONA_ID_CONYUGE; } set { if (value.HasValue) row.PERSONA_ID_CONYUGE = value.Value; else row.IsPERSONA_ID_CONYUGENull = true; } }
        public string RUC { get { return ClaseCBABase.GetStringHelper(row.RUC); } set { row.RUC = value; } }
        public string SeparacionBienes { get { return ClaseCBABase.GetStringHelper(row.SEPARACION_BIENES); } set { row.SEPARACION_BIENES = value; } }
        public string Telefono1 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO1); } set { row.TELEFONO1 = value; } }
        public string Telefono2 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO2); } set { row.TELEFONO2 = value; } }
        public string Telefono3 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO3); } set { row.TELEFONO3 = value; } }
        public string Telefono4 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO4); } set { row.TELEFONO4 = value; } }
        public string TelefonoCobranza1 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO_COBRANZA1); } set { row.TELEFONO_COBRANZA1 = value; } }
        public string TelefonoCobranza2 { get { return ClaseCBABase.GetStringHelper(row.TELEFONO_COBRANZA2); } set { row.TELEFONO_COBRANZA2 = value; } }
        public decimal? TipoClienteId { get { if (row.IsTIPO_CLIENTE_IDNull) return null; else return row.TIPO_CLIENTE_ID; } set { if (value.HasValue) row.TIPO_CLIENTE_ID = value.Value; else row.IsTIPO_CLIENTE_IDNull = true; } }
        public string TipoDocumentoIdentidadId { get { return ClaseCBABase.GetStringHelper(row.TIPO_DOCUMENTO_IDENTIDAD_ID); } set { row.TIPO_DOCUMENTO_IDENTIDAD_ID = value; } }
        public string EsContribuyente { get { return ClaseCBABase.GetStringHelper(row.ES_CONTRIBUYENTE); } set { row.ES_CONTRIBUYENTE = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private AbogadosService _abogado;
        public AbogadosService Abogado
        {
            get
            {
                if (this._abogado == null)
                    this._abogado = new AbogadosService(this.AbogadoId.Value);
                return this._abogado;
            }
        }

        private PersonasService _persona_conyuge;
        public PersonasService PersonaConyuge
        {
            get
            {
                if (this._persona_conyuge == null)
                    this._persona_conyuge = new PersonasService(this.PersonaIdConyuge.Value);
                return this._persona_conyuge;
            }
        }

        private TipoClientesService _tipoCliente;
        public TipoClientesService TipoCliente
        {
            get
            {
                if (this._tipoCliente == null)
                    this._tipoCliente = new TipoClientesService(this.TipoClienteId.Value);
                return this._tipoCliente;
            }
        }

        private PaisesService _pais_residencia;
        public PaisesService PaisResidencia
        {
            get
            {
                if (this._pais_residencia == null)
                    this._pais_residencia = new PaisesService(this.PaisResidenciaId.Value);
                return this._pais_residencia;
            }
        }

        private CiudadesService _ciudad_cobranza;
        public CiudadesService Ciudad
        {
            get
            {
                if (this._ciudad_cobranza == null)
                    this._ciudad_cobranza = new CiudadesService(this.CiudadCobranzaId.Value);
                return this._ciudad_cobranza;
            }
        }
        #endregion Propiedades Extendidas

        #region Propiedades OneToMany
        private PersonasRelacionesService[] _personas_dependientes;
        public PersonasRelacionesService[] PersonasDependientes
        {
            get
            {
                if (this._personas_dependientes == null)
                {
                    this._personas_dependientes = PersonasRelacionesService.Instancia.GetFiltrado<PersonasRelacionesService>(new ClaseCBABase.Filtro[]
                    {
                        new ClaseCBABase.Filtro { Columna = PersonasRelacionesService.Modelo.PERSONA_IDColumnName, Valor = this.Id.Value },
                        new ClaseCBABase.Filtro { Columna = PersonasRelacionesService.Modelo.TIPO_RELACION_PERSONA_IDColumnName, Valor = Definiciones.TiposRelacionesPersonas.Dependiente },
                    });
                }

                return this._personas_dependientes;
            }
        }
        #endregion Propiedades OneToMany

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.PERSONASCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new PERSONASRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.AlmacenarLocalmente = true;
            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(PERSONASRow row)
        {
            this.AlmacenarLocalmente = true;
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public PersonasService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PersonasService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PersonasService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        public PersonasService(EdiCBA.Persona edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion);
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = PersonasService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion);

            this.Apellido = edi.apellido;
            this.Codigo = edi.codigo;
            this.Nombre = edi.nombre;

            if (edi.documentos != null && edi.documentos.Count > 0)
            {
                this.NumeroDocumento = edi.documentos[0].numero;
                this.TipoDocumentoIdentidadId = edi.documentos[0].tipo == EdiCBA.TipoDocumento.CedulaIdentidad ? Definiciones.TiposDocumentoIdentidad.CI : Definiciones.TiposDocumentoIdentidad.RUC;
                this.RUC = this.NumeroDocumento;
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
            if (edi.telefonos != null && edi.telefonos.Count > contTelefonos)
                this.TelefonoCobranza1 = edi.telefonos[++contTelefonos].codigo_pais + edi.telefonos[contTelefonos].codigo_operadora + edi.telefonos[++contTelefonos].numero;
            if (edi.telefonos != null && edi.telefonos.Count > contTelefonos)
                this.TelefonoCobranza2 = edi.telefonos[++contTelefonos].codigo_pais + edi.telefonos[contTelefonos].codigo_operadora + edi.telefonos[++contTelefonos].numero;
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
                tipo = this.EsContribuyente == Definiciones.SiNo.Si ? EdiCBA.TipoDocumento.RUC : EdiCBA.TipoDocumento.CedulaIdentidad,
                numero = this.NumeroDocumento,
                orden = 0
            };

            //Se limpian los . en el numero del documento
            if (doc.numero.Contains("."))
                doc.numero = doc.numero.Replace(".", string.Empty);

            if (this.ExisteEnDB)
            {
                doc.id = this.Id.Value;
                doc.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, NumeroDocumento_NombreCol, this.Id.Value, sesion);
            }

            lDocumentos.Add(doc);
            #endregion Documento

            var e = new CBA.FlowV2.Services.Base.EdiCBA.Persona()
            {
                codigo = this.Codigo,
                nombre = this.Nombre,
                apellido = this.Apellido,
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

        #region ResetearPropiedadesExtendidas
        public void ResetearPropiedadesExtendidas()
        {
            this._abogado = null;
            this._pais_residencia = null;
            this._persona_conyuge = null;
            this._personas_dependientes = null;
            this._tipoCliente = null;
            this._ciudad_cobranza = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region ControlLineaCredito
        public bool ControlLineaCredito(decimal caso_id, decimal moneda_id, decimal monto, decimal cotizacion, decimal sucursal_id, DateTime fecha, SessionService sesion)
        {
            //obtener la linea de credito
            PersonasLineaCreditoService personasLineaCredito = new PersonasLineaCreditoService();
            DataRow lineaCredito = personasLineaCredito.GetPersonasLineaCredito(this.Id.Value);
            decimal lineaCreditoMonto = (decimal)lineaCredito[PersonasLineaCreditoService.MontoLineaCredito_NombreCol];
            var cotizacionLineaCredito = CotizacionesService.GetCotizacionMonedaCompra(new SucursalesService(sucursal_id, sesion).PaisId, this.MonedaLimiteCreditoId, fecha, sesion);

            DataTable dtFacturasPendientes = PersonasLineaCreditoService.GetFacturasPendientes(PersonasLineaCreditoService.VistaPedidosPersonaId_NombreCol + " = " + this.Id.Value, sesion);
            decimal facturasEnDolares = 0;
            if (dtFacturasPendientes.Rows.Count > 0)
            {
                foreach (DataRow rows in dtFacturasPendientes.Rows)
                    facturasEnDolares += ((decimal)rows[PersonasLineaCreditoService.VistaFacturasPendientes_NombreCol] / (decimal)rows[PersonasLineaCreditoService.VistaFacturasCotizacion_NombreCol]);
            }

            DataTable dtPedidosPendientes = PersonasLineaCreditoService.GetPedidosPendientes(PersonasLineaCreditoService.VistaPedidosPersonaId_NombreCol + " = " + this.Id.Value, sesion);
            decimal pedidosEnDolares = 0;
            if (dtPedidosPendientes.Rows.Count > 0)
            {
                foreach (DataRow rows in dtPedidosPendientes.Rows)
                    pedidosEnDolares += ((decimal)rows[PersonasLineaCreditoService.VistaPedidosPendientes_NombreCol] / (decimal)rows[PersonasLineaCreditoService.VistaPedidoCotizacion_NombreCol]);
            }

            var creditosPendientes = CreditosService.Instancia.GetFiltrado<CreditosService>(new ClaseCBABase.Filtro[]
            {
                new ClaseCBABase.Filtro { Columna = CreditosService.FiltroExtension.PersonaDeudoraOGaranteId, Valor = this.Id.Value },
                new ClaseCBABase.Filtro { Columna = CreditosService.FiltroExtension.CasoEstadoId, Valor = new string[] { Definiciones.EstadosFlujos.Borrador, Definiciones.EstadosFlujos.Pendiente, Definiciones.EstadosFlujos.PreAprobado, Definiciones.EstadosFlujos.Aprobado }, Exacto = false },
                new ClaseCBABase.Filtro { Columna = CreditosService.Modelo.AFECTA_LINEA_CREDITOColumnName, Valor = Definiciones.SiNo.Si },
                new ClaseCBABase.Filtro { Columna = CreditosService.Modelo.CASO_IDColumnName, Valor = caso_id, Comparacion = "<>" }
            });
            decimal creditosEnDolares = 0;
            foreach (var c in creditosPendientes)
                creditosEnDolares += c.MontoTotal / c.Cotizacion;

            decimal factor = 1;
            if (this.MonedaLimiteCreditoId != moneda_id)
                factor = cotizacionLineaCredito / cotizacion;
            decimal movimientoActual = monto * factor;

            //calculo del saldo comprometido, conversiones a la moneda de la linea de credito
            decimal saldoPersonaEnDolares = CuentaCorrientePersonasService.GetSaldoPersonaEnDolares(this.Id.Value, sesion);
            decimal saldoConMovimientoActual = (saldoPersonaEnDolares + facturasEnDolares + pedidosEnDolares + creditosEnDolares - monto / cotizacion) * cotizacionLineaCredito;

            return lineaCreditoMonto >= saldoConMovimientoActual;
        }
        #endregion ControlLineaCredito
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
