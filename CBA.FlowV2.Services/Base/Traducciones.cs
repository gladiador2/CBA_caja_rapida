#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Base
{
    public class Traducciones
    {
        #region Atributos
        private static Dictionary<string, string> traducciones = null;
        private static decimal clienteActual;
        #endregion Atributos

        #region Propiedades flujos
        public static string Ordenes_de_Servicio { get { return ObtenerTraduccion("Órdenes de Servicio"); } }
        public static string Anticipo_Proveedores { get { return ObtenerTraduccion("Anticipo Proveedores"); } }
        public static string Presupuestos { get { return ObtenerTraduccion("Presupuestos"); } }
        public static string Tramites { get { return ObtenerTraduccion("Trámites"); } }
        public static string Descuento_Documentos { get { return ObtenerTraduccion("Descuento de Documentos"); } }
        #endregion Propiedades flujos

        #region Palabras o nombres particulares
        public static string Caso { get { return ObtenerTraduccion("Caso"); } }
        public static string Casos { get { return ObtenerTraduccion("Casos"); } }
        public static string la_persona { get { return ObtenerTraduccion("la persona"); } }
        public static string la_persona_relacionada { get { return ObtenerTraduccion("la persona relacionada"); } }
        public static string La_persona { get { return ObtenerTraduccion("La persona"); } }
        public static string la_sucursal { get { return ObtenerTraduccion("la sucursal"); } }
        public static string Funcionario { get { return ObtenerTraduccion("Funcionario"); } }
        public static string Funcionarios { get { return ObtenerTraduccion("Funcionarios"); } }
        public static string el_funcionario { get { return ObtenerTraduccion("el funcionario"); } }
        public static string El_funcionario { get { return ObtenerTraduccion("El funcionario"); } }
        public static string Vendedor { get { return ObtenerTraduccion("Vendedor"); } }
        public static string Persona { get { return ObtenerTraduccion("Persona"); } }
        public static string PersonaRelacionada { get { return ObtenerTraduccion("Persona Relacionada"); } }
        public static string Personas { get { return ObtenerTraduccion("Personas"); } }
        public static string Sucursal { get { return ObtenerTraduccion("Sucursal"); } }
        public static string Talonario { get { return ObtenerTraduccion("Talonario"); } }
        public static string Bonificacion { get { return ObtenerTraduccion("Bonificacion"); } }
        public static string Bonificaciones { get { return ObtenerTraduccion("Bonificaciones"); } }
        public static string la_Bonificacion { get { return ObtenerTraduccion("la Bonificacion"); } }
        public static string TipoTramite { get { return ObtenerTraduccion("Tipo de Orden"); } }
        public static string Representantes { get { return ObtenerTraduccion("Representantes"); } }
        public static string Saldo { get { return ObtenerTraduccion("Saldo"); } }
        public static string Descripcion { get { return ObtenerTraduccion("Descripcion"); } }
        public static string CtaCte { get { return ObtenerTraduccion("CtaCte"); } }
        public static string Orden_de_Servicio { get { return ObtenerTraduccion("Orden de Servicio"); } }
        public static string Anticipo_Proveedor { get { return ObtenerTraduccion("Anticipo Proveedor"); } }
        public static string Presupuesto { get { return ObtenerTraduccion("Presupuesto"); } }
        public static string Tramite { get { return ObtenerTraduccion("Trámite"); } }
        public static string TramiteActividadFinalizado { get { return ObtenerTraduccion("TramiteActividadFinalizado"); } }
        public static string NroComprobante { get { return ObtenerTraduccion("Nro. Comprobante"); } }
        public static string CreditosNroComprobante { get { return ObtenerTraduccion("Creditos Nro. Comprobante"); } }
        public static string NroDocExterno { get { return ObtenerTraduccion("Nro. Doc. Externo"); } }
        public static string NroSolicitud { get { return ObtenerTraduccion("Nro. Solicitud"); } }
        public static string CreditosNroSolicitud { get { return ObtenerTraduccion("Creditos Nro. Solicitud"); } }
        public static string FechaRecepcion { get { return ObtenerTraduccion("Recepción"); } }
        #endregion Palabras o nombres particulares

        #region mensajes cortos
        public static string Debe_seleccionar_la_persona { get { return ObtenerTraduccion("Debe seleccionar la persona"); } }
        public static string La_persona_esta_bloqueada { get { return ObtenerTraduccion("La persona está bloqueada"); } }
        public static string La_persona_esta_en_informconf { get { return ObtenerTraduccion("La persona está en informconf"); } }
        public static string La_persona_esta_en_judicial { get { return La_persona_esta_en_judicial_Resolucion(null); } }
        public static string La_persona_esta_en_judicial_Resolucion(PersonasService persona) 
        {
            string traduccion = ObtenerTraduccion("La persona está en judicial");

            if (persona != null)
            {
                switch (VariablesSistemaEntidadService.GetValorInt(Definiciones.VariablesDeSistema.Cliente))
                {
                    case Definiciones.Clientes.Electroban:
                        if (persona.TipoCliente.Observacion.Length > 0)
                            traduccion = persona.TipoCliente.Observacion;
                        break;
                }
            }
            return traduccion;
        }
        public static string La_persona_esta_inactiva { get { return ObtenerTraduccion("La persona está inactiva"); } }
        public static string El_funcionario_esta_inactivo { get { return ObtenerTraduccion("El funcioanrio está inactiva"); } }
        public static string Debe_seleccionar_el_tipo_de_tramite { get { return ObtenerTraduccion("Debe seleccionar el tipo de trámite"); } }
        #endregion mensajes cortos

        #region otros
        public static string Link_al_CBAFlow { get { return ObtenerTraduccion("Link al CBAFlow"); } }
        public static string VBP { get { return ObtenerTraduccion("VBP"); } }
        public static string VBP_Referencia { get { return ObtenerTraduccion("VBP = Visto Bueno de Persona"); } }
        public static string OrdenServicioTitulo { get { return ObtenerTraduccion("OrdenServicioTitulo"); } }
        public static string OrdenServicioDescripcion { get { return ObtenerTraduccion("OrdenServicioDescripcion"); } }
        public static string OrdenServicioDetallesHoras { get { return ObtenerTraduccion("Horas"); } }
        public static string OrdenServicioDetallesPrecio { get { return ObtenerTraduccion("Precio"); } }
        public static string PresupuestoFechaValidez { get { return ObtenerTraduccion("Validez"); } }
        public static string PresupuestoObjeto { get { return ObtenerTraduccion("Objeto"); } }
        public static string PresupuestoGaranteUno { get { return ObtenerTraduccion("Garante Uno"); } }
        public static string PresupuestoGaranteDos { get { return ObtenerTraduccion("Garante Dos"); } }
        public static string PresupuestoConcepto { get { return ObtenerTraduccion("Concepto"); } }
        public static string IngresoStockTextoPredefinido { get { return ObtenerTraduccion("IngresoStockTextoPredefinido"); } }
        #endregion otros

        #region AgregarTraduccion
        /// <summary>
        /// Agrega una traduccion al diccionario.
        /// Si la lista de clientes es vacia la traduccion se aplica a todos.
        /// Si ya existia entrada en el diccionario se sobreescribe.
        /// </summary>
        /// <param name="palabra">La palabra que se desea traducir.</param>
        /// <param name="traduccion">La traduccion.</param>
        /// <param name="clientes">Los clientes a los cuales se aplica la traduccion.</param>
        private static void AgregarTraduccion(string palabra, string traduccion, params decimal[] clientes)
        {
            if (clientes.Count() == 0)
            {
                traducciones[palabra] = traduccion;
                return;
            }
            foreach (decimal cliente in clientes)
            {
                if (cliente == clienteActual)
                {
                    traducciones[palabra] = traduccion;
                    return;
                }
            }
        }
        #endregion AgregarTraduccion

        #region CrearDiccionario
        private static void CrearDiccionario()
        {
            traducciones = new Dictionary<string, string>();
            clienteActual = (int)VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.Cliente);

            #region Valores por defecto
            #region Propiedades flujos
            AgregarTraduccion("Orden de Servicio", "Orden de Servicio");
            AgregarTraduccion("Anticipo Proveedor", "Anticipo Proveedor");
            AgregarTraduccion("Presupuestos", "Presupuestos");
            AgregarTraduccion("Trámites", "Trámites");
            AgregarTraduccion("Descuento de Documentos", "Descuento de Documentos");
            #endregion Propiedades flujos

            #region palabras o nombres particulares
            AgregarTraduccion("Caso", "Caso");
            AgregarTraduccion("Casos", "Casos");
            AgregarTraduccion("la persona", "la persona");
            AgregarTraduccion("La persona", "La persona");
            AgregarTraduccion("la sucursal", "la sucursal");
            AgregarTraduccion("Funcionario", "Funcionario");
            AgregarTraduccion("Funcionarios", "Funcionarios");
            AgregarTraduccion("El funcionario", "El funcionario");
            AgregarTraduccion("el funcionario", "el funcionario");
            AgregarTraduccion("Vendedor", "Vendedor");
            AgregarTraduccion("Persona", "Persona");
            AgregarTraduccion("Personas", "Personas");
            AgregarTraduccion("Recepción", "Recepción");

            AgregarTraduccion("Sucursal", "Sucursal");
            AgregarTraduccion("Talonario", "Talonario");
            AgregarTraduccion("Bonificacion", "Bonificación");
            AgregarTraduccion("Bonificaciones", "Bonificaciones");
            AgregarTraduccion("la Bonificacion", "la Bonificación");
            AgregarTraduccion("Representantes", "Representantes");
            AgregarTraduccion("Saldo", "Saldo");
            AgregarTraduccion("Descripcion", "Descripción");
            AgregarTraduccion("CtaCte", "CtaCte");
            AgregarTraduccion("Nro. Comprobante", "Nro. Comprobante");
            AgregarTraduccion("Creditos Nro. Comprobante", Traducciones.NroComprobante);
            AgregarTraduccion("Nro. Doc. Externo", "Nro. Doc. Externo");
            AgregarTraduccion("Nro. Solicitud", "Nro. Solicitud");
            AgregarTraduccion("Creditos Nro. Solicitud", Traducciones.NroSolicitud);
            AgregarTraduccion("TramiteActividadFinalizado", "Finalizado");
            AgregarTraduccion("TramiteTitulo", "Título");
            AgregarTraduccion("TramiteDescripcion", "Descripción");
            AgregarTraduccion("IngresoStockTextoPredefinido", "Concepto");
            #endregion palabras o nombres particulares

            #region mensajes cortos
            AgregarTraduccion("Debe seleccionar la persona", "Debe seleccionar la persona");
            AgregarTraduccion("La persona está bloqueada", "La persona está bloqueada");
            AgregarTraduccion("La persona está en informconf", "La persona está en informconf");
            AgregarTraduccion("La persona está en judicial", "La persona está en judicial");
            AgregarTraduccion("La persona está inactiva", "La persona está inactiva");
            AgregarTraduccion("El funcionario está inactivo", "El funcionario está inactivo");
            #endregion mensajes cortos

            #region otros
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py");
            AgregarTraduccion("VBP", "VBP");//visto bueno de persona
            AgregarTraduccion("VBP = Visto Bueno de Persona", "VBP = Visto Bueno de Persona");//referencia
            #endregion otros
            #endregion Valores por defecto

            #region Valores especificos por clientes

            #region Propiedades flujos
            AgregarTraduccion("Órdenes de Servicio", "Actividades", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Orden de Servicio", "Pedido de Materiales y/o Servicios", Definiciones.Clientes.TyC);
            AgregarTraduccion("Anticipo Proveedor", "Solicitud de Pago", Definiciones.Clientes.TyC);
            AgregarTraduccion("Presupuestos", "Solicitudes de Servicio", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Trámites", "Órdenes de Trabajo", Definiciones.Clientes.ServiciosJuridicos,
                                                                Definiciones.Clientes.Autotec);
            AgregarTraduccion("Descuento de Documentos", "Negociación", Definiciones.Clientes.CGL);
            #endregion Propiedades flujos

            #region palabras o nombres particulares
            AgregarTraduccion("Caso", "Documento", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Casos", "Documentos", Definiciones.Clientes.ServiciosJuridicos);

            AgregarTraduccion("la persona", "el cliente", Definiciones.Clientes.CGL,
                                                          Definiciones.Clientes.ACredito);
            AgregarTraduccion("La persona", "El cliente", Definiciones.Clientes.CGL,
                                                          Definiciones.Clientes.ACredito);

            AgregarTraduccion("Persona", "Cliente", Definiciones.Clientes.CGL,
                                                    Definiciones.Clientes.ACredito,
                                                    Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Personas", "Clientes", Definiciones.Clientes.CGL,
                                                    Definiciones.Clientes.ACredito,
                                                    Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Recepción", "Periodo", Definiciones.Clientes.Documenta);

            AgregarTraduccion("Funcionario", "Responsable", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Funcionarios", "Responsables", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("El funcionario", "El responsable", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("el funcionario", "el responsable", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Vendedor", "Responsable", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Bonificacion", "Beneficio", Definiciones.Clientes.CGL,
                                                    Definiciones.Clientes.ACredito);
            AgregarTraduccion("Bonificaciones", "Beneficios", Definiciones.Clientes.CGL,
                                                    Definiciones.Clientes.ACredito);
            AgregarTraduccion("la Bonificacion", "el Beneficio", Definiciones.Clientes.CGL,
                                                    Definiciones.Clientes.ACredito);
            AgregarTraduccion("Tipo de Tramite", "Tipo de Tramite", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Representantes", "Contactos", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Saldo", "Monto de Cuota", Definiciones.Clientes.ACredito);
            AgregarTraduccion("Descripcion", "Concepto", Definiciones.Clientes.ACredito);
            AgregarTraduccion("CtaCte", "Deuda", Definiciones.Clientes.CGL);
            AgregarTraduccion("Orden de Servicio", "Actividad", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Presupuesto", "Solicitud de Servicio", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Trámite", "OT", Definiciones.Clientes.ServiciosJuridicos,
                                               Definiciones.Clientes.Autotec);
            AgregarTraduccion(TramiteActividadFinalizado, "Resuelto", Definiciones.Clientes.TyC);
            AgregarTraduccion("Concepto", "Fuero", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Garante Uno", "Seguro", Definiciones.Clientes.Autotec);
            AgregarTraduccion("Garante Dos", "Operario", Definiciones.Clientes.Autotec);
            AgregarTraduccion("Validez", "Tentativa", Definiciones.Clientes.Autotec);
            AgregarTraduccion("Objeto", "Título", Definiciones.Clientes.Autotec);
            AgregarTraduccion("Creditos Nro. Comprobante", "Nro. OC", Definiciones.Clientes.Apro);
            AgregarTraduccion("Nro. Doc. Externo", "Nro. OC", Definiciones.Clientes.Electroban,
                                                              Definiciones.Clientes.Telexpar);
            AgregarTraduccion("Nro. Doc. Externo", "Nro Siniestro", Definiciones.Clientes.Autotec);
            AgregarTraduccion("Nro. Solicitud", "Nro. OC", Definiciones.Clientes.Electroban);
            AgregarTraduccion("Creditos Nro. Solicitud", "Nro. Walton", Definiciones.Clientes.Apro);
            #endregion palabras o nombres particulares

            #region mensajes cortos
            AgregarTraduccion("La persona está bloqueada", "El cliente está bloqueado",
                                Definiciones.Clientes.CGL,
                                Definiciones.Clientes.ACredito);

            AgregarTraduccion("La persona está en judicial", "Vendido a Nexo SAECA, contactar al 619 3000",
                                Definiciones.Clientes.Electroban);

            AgregarTraduccion("La persona está inactiva", "El cliente está inactivo",
                                Definiciones.Clientes.CGL,
                                Definiciones.Clientes.ACredito);
            AgregarTraduccion("Debe seleccionar la persona", "Debe seleccionar el cliente",
                                Definiciones.Clientes.CGL,
                                Definiciones.Clientes.ACredito);
            AgregarTraduccion("Debe seleccionar el tipo de tramite", "Debe seleccionar el tipo de tramite",
                                Definiciones.Clientes.ServiciosJuridicos,
                                Definiciones.Clientes.Autotec);
            #endregion mensajes cortos

            #region otros
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py/CBAFlow", Definiciones.Clientes.CBA);
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py/CBAFlow_cgl", Definiciones.Clientes.CGL);
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py/inmobiliaria", Definiciones.Clientes.Inmobiliaria);
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py/acredito", Definiciones.Clientes.ACredito);
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py/sj", Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py/minipymes", Definiciones.Clientes.Minipymes);
            AgregarTraduccion("Link al CBAFlow", "http://flow.cba.com.py/se", Definiciones.Clientes.ElectrobanSolucionEfectiva);
            AgregarTraduccion("VBP", "VBC", Definiciones.Clientes.CGL,
                                            Definiciones.Clientes.ACredito,
                                            Definiciones.Clientes.ServiciosJuridicos);
            AgregarTraduccion("VBP = Visto Bueno de Persona", "VBC = Visto Bueno de Cliente", Definiciones.Clientes.CGL,
                                                                                              Definiciones.Clientes.ACredito,
                                                                                              Definiciones.Clientes.ServiciosJuridicos);//referencia
            AgregarTraduccion("Horas", "Cantidad", Definiciones.Clientes.TyC);
            AgregarTraduccion("Precio", "Presupuestado", Definiciones.Clientes.TyC);
            AgregarTraduccion(OrdenServicioTitulo, "Contacto", Definiciones.Clientes.ParaguayMovil);
            AgregarTraduccion(OrdenServicioDescripcion, "Teléfono", Definiciones.Clientes.ParaguayMovil);
            AgregarTraduccion(IngresoStockTextoPredefinido, "Procedencia", Definiciones.Clientes.TyC);
            #endregion otros

            #endregion Valores especificos por clientes

        }
        #endregion CrearDiccionario

        #region ObtenerTraduccion
        private static string ObtenerTraduccion(string palabra)
        {
            if (traducciones == null) CrearDiccionario();

            if (traducciones.Keys.Contains(palabra))
                return traducciones[palabra];
            else
                return palabra;
        }
        #endregion ObtenerTraduccion
    }
}