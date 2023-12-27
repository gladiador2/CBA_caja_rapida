#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.IO;
#endregion Using

namespace CBA.FlowV2.Services.DetallesPersonalizados
{
    public class TiposDetallesPersonalizadosService
    {
        #region Variables de clase
        private static string[] vSeparador = {"@!@"};
        #endregion Variables de clase

        #region Columnas y Posicion de Tipo
        #region ProveedorPersonaAutorizada
        public static class ProveedorPersonaAutorizada 
        {
            public const string DetallePersonalizadoId_NombreCol = "DETALLE_PERSONALIZADO_ID";
            public const string Nombre_NombreCol = "NOMBRE";
            public const int Nombre_PosicionValor = 0;
            public const string Codigo_NombreCol = "CODIGO";
            public const int Codigo_PosicionValor = 1;
            public const string Observacion_NombreCol = "OBSERVACION";
            public const int Observacion_PosicionValor = 2;
            public const string Estado_NombreCol = "ESTADO";
            public const int Estado_PosicionValor = 3;

            public const string Guardar = "CMD_GUARDAR";
            public const string Borrar = "CMD_BORRAR";
        }
        #endregion ProveedorPersonaAutorizada

        #region ReferenciasCreditoTerceros
        //Entidad@!@Monto@!@Plazo@!@Fecha Aprobación@!@Moneda@!@Monto Cuota@!@Número de Cuota@!@Promedio Atraso@!@Máximo Atraso@!@Cancelado
        public static class ReferenciasCreditoTerceros
        {
            public const string DetallePersonalizadoId_NombreCol = "DETALLE_PERSONALIZADO_ID";
            public const string Entidad_NombreCol = "ENTIDAD";
            public const int Entidad_PosicionValor = 0;
            public const string Monto_NombreCol = "MONTO";
            public const int Monto_PosicionValor = 1;
            public const string Plazo_NombreCol = "PLAZO";
            public const int Plazo_PosicionValor = 2;
            public const string FechaAprobacion_NombreCol = "FECHA_APROBACION";
            public const int FechaAprobacion_PosicionValor = 3;
            public const string Moneda_NombreCol = "MONEDA";
            public const int Moneda_PosicionValor = 4;
            public const string MontoCuota_NombreCol = "MONTO_CUOTA";
            public const int MontoCuota_PosicionValor = 5;
            public const string NumeroCuota_NombreCol = "NUMERO_CUOTA";
            public const int NumeroCuota_PosicionValor = 6;
            public const string PromedioAtraso_NombreCol = "PROMEDIO_ATRASO";
            public const int PromedioAtraso_PosicionValor = 7;
            public const string MaximoAtraso_NombreCol = "MAXIMO_ATRASO";
            public const int MaximoAtraso_PosicionValor = 8;
            public const string Cancelado_NombreCol = "CANCELADO";
            public const int Cancelado_PosicionValor = 9;
        }
        #endregion ReferenciasCreditoTerceros
        #endregion Columnas y Posicion de Tipo

        #region Definicion de TipoDato
        public abstract class TipoDato
        {
            public const int TextoCorto = 1;
            public const int Fecha = 2;
            public const int NumeroCantidad = 4;
            public const int NumeroMonto = 5;
            public const int NumeroAnho = 6;
            public const int NumeroMes = 7;
            public const int NumeroDia = 8;
            public const int NumeroLatitudLongitud = 9;
            public const int NumeroPorcentaje = 10;
            public const int TextoLargo = 11;
            public const int MonedaMonto = 12;
            public const int EscalaMontoPorcentaje  = 13;
            public const int CasoId = 14;
			public const int EscalaCantidadPorcentaje = 15;
            public const int EscalaMontoMonto = 16;
            public const int EscalaCantidadMonto = 17;
          

            //Se reservan los numeros entre 501 y 1000 para dominios personalizados
            public const int SiNo = 501;    // S = si, N = no
            public const int Estado = 502;  // A = activo, I = inactivo
            public const int Temas = 503;
            public const int Impresoras = 504; //Epson LX-300, etc.
            public const int ObjetivoBusqueda = 505; //Codigo, Texto, Flexible (utilizados por ejemplo en ComboboxCBA)
            public const int ImpresoraTipoYNombre = 506; //Serializacion de clase Definiciones.Impresora

            //Se reservan los numeros entre 1001 y 5000 para campos de tablas
            public const int Campo_Personas_Id = 1001;
            public const int Campo_Proveedores_Id = 1002;
            public const int Campo_Sucursales_Id = 1003;
            public const int Campo_Funcionarios_Id = 1004;
            public const int Campo_Paises_Id = 1005;
            public const int Campo_Departamentos_Id = 1006;
            public const int Campo_Ciudades_Id = 1007;
            public const int Campo_Barrios_Id = 1008;
            public const int Campo_Moneda_Id = 1009;
            public const int Campo_PersonaCalificacion_Id = 1010;
            public const int Campo_Rubro_Id = 1011;
            public const int Campo_Articulos_Familias_id = 1012;
            public const int Campo_Articulos_Grupos_id = 1013;
            public const int Campo_Articulos_Id = 1014;
            public const int Campo_CtaCte_Condiciones_Pago_id = 1015;
            public const int Campo_Tipos_Factura_Proveedor_Id = 1016;
            public const int Campo_Activos_Id = 1017;
            public const int Campo_Tipo_Cliente_Id = 1018;
            public const int Campo_Estado_Morosidad_Id = 1019;
            public const int Campo_Formatos_Reporte_Id = 1020;
            public const int Campo_Abogados_Id = 1021;
            public const int Campo_AbogadosDet_Id = 1022;

            //Se reservan los numeros entre 5001 y 10000 para referencias a campos de detalles personalizados 
            //Esto es, cuando el registro es parte de los valores de un detalle personalizado existente
            public const int DetallePersonalizado_ProveedorPersonaAutorizada = 5001;

            //Se reserva el numero 10001 para referencias a campos de textos predefinidos 
            //Esto es, cuando el registro es parte de los textos de un texto predefinido existente
            public const int TextoPredefinido = 10001;

            // Accesors para el nombre de las columnas que devuelve el metodo GetTiposDatos
            private const string _nombreDato = "NombreDato";
            private const string _valorDato = "ValorDato";

            public static string NombreDato
            {
                get { return _nombreDato; }
            } 
            public static string ValorDato
            {
                get { return _valorDato; }
            }
            public static DataTable GetTiposDatosParaTarifario()
            {
                DataTable tiposDatos = new DataTable();
                // Se agregan las columnas
                tiposDatos.Columns.Add(NombreDato, typeof(string));
                tiposDatos.Columns.Add(ValorDato, typeof(int));
                // Se agregan las filas
                tiposDatos.Rows.Add("Número Monto", NumeroMonto);
                tiposDatos.Rows.Add("Número Porcentaje", NumeroPorcentaje);
                tiposDatos.Rows.Add("Número Cantidad", NumeroCantidad);
                tiposDatos.Rows.Add("Texto", TextoCorto);
                tiposDatos.Rows.Add("Texto Largo", TextoLargo);
                tiposDatos.Rows.Add("Fecha", Fecha);
                tiposDatos.Rows.Add("Condiciones de Pago", Campo_CtaCte_Condiciones_Pago_id);
                tiposDatos.Rows.Add("Sí / No", SiNo);
                tiposDatos.Rows.Add("Moneda Monto", MonedaMonto);
                tiposDatos.Rows.Add("Escala Monto x Monto", EscalaMontoMonto);
                tiposDatos.Rows.Add("Escala Monto x %", EscalaMontoPorcentaje);
                tiposDatos.Rows.Add("Escala Cantidad x %", EscalaCantidadPorcentaje);
                tiposDatos.Rows.Add("Escala Cantidad x Monto", EscalaCantidadMonto);


                return tiposDatos;

            }

            public static DataTable GetTiposDatos()
            {
                DataTable tiposDatos = new DataTable();

                // Se agregan las columnas
                tiposDatos.Columns.Add(NombreDato, typeof(string));
                tiposDatos.Columns.Add(ValorDato, typeof(int));

                // Se agregan las filas
                tiposDatos.Rows.Add("Texto", TextoCorto);
                tiposDatos.Rows.Add("Fecha", Fecha);
                tiposDatos.Rows.Add("Número Cantidad", NumeroCantidad);
                tiposDatos.Rows.Add("Número Monto", NumeroMonto);
                tiposDatos.Rows.Add("Número Año", NumeroAnho);
                tiposDatos.Rows.Add("Número Mes", NumeroMes);
                tiposDatos.Rows.Add("Número Día", NumeroDia);
                tiposDatos.Rows.Add("Número Latitud Longitud", NumeroLatitudLongitud);
                tiposDatos.Rows.Add("Número Porcentaje", NumeroPorcentaje);
                tiposDatos.Rows.Add("Texto Largo", TextoLargo);
                tiposDatos.Rows.Add("Moneda Monto", MonedaMonto);
                
                tiposDatos.Rows.Add(Traducciones.Caso, CasoId);

                tiposDatos.Rows.Add("Sí / No", SiNo);
                tiposDatos.Rows.Add("Estado", Estado);
                tiposDatos.Rows.Add("Temas", Temas);
                tiposDatos.Rows.Add("Impresoras", Impresoras);
                tiposDatos.Rows.Add("Objetivo Búsqueda", ObjetivoBusqueda);

                tiposDatos.Rows.Add("Personas", Campo_Personas_Id);
                tiposDatos.Rows.Add("Abogados", Campo_Abogados_Id);
                tiposDatos.Rows.Add("Abogados Integrante", Campo_AbogadosDet_Id);
                tiposDatos.Rows.Add("Proveedores", Campo_Proveedores_Id);
                tiposDatos.Rows.Add("Sucursales", Campo_Sucursales_Id);
                tiposDatos.Rows.Add("Funcionarios", Campo_Funcionarios_Id);
                tiposDatos.Rows.Add("Paises", Campo_Paises_Id);
                tiposDatos.Rows.Add("Departamentos", Campo_Departamentos_Id);
                tiposDatos.Rows.Add("Ciudades", Campo_Ciudades_Id);
                tiposDatos.Rows.Add("Barrios", Campo_Barrios_Id);
                tiposDatos.Rows.Add("Moneda", Campo_Moneda_Id);
                tiposDatos.Rows.Add("Persona Calificación", Campo_PersonaCalificacion_Id);
                tiposDatos.Rows.Add("Rubro", Campo_Rubro_Id);
                tiposDatos.Rows.Add("Artículos Familias", Campo_Articulos_Familias_id);
                tiposDatos.Rows.Add("Artículos Grupos", Campo_Articulos_Grupos_id);
                tiposDatos.Rows.Add("Artículos", Campo_Articulos_Id);
                tiposDatos.Rows.Add("Condiciones de Pago", Campo_CtaCte_Condiciones_Pago_id);
                tiposDatos.Rows.Add("Tipos Factura Proveedor", Campo_Tipos_Factura_Proveedor_Id);
                tiposDatos.Rows.Add("Activos", Campo_Activos_Id);
                tiposDatos.Rows.Add("Tipo Cliente", Campo_Tipo_Cliente_Id);
                tiposDatos.Rows.Add("Estado Morosidad", Campo_Estado_Morosidad_Id);
                tiposDatos.Rows.Add("Reporte FCClienteImpresion Formato", Campo_Formatos_Reporte_Id);

                tiposDatos.Rows.Add("Detalle Personalizado - Proveedor Persona Autorizada", DetallePersonalizado_ProveedorPersonaAutorizada);

                tiposDatos.Rows.Add("Texto Predefinido", TextoPredefinido);

                return tiposDatos;
            }
        }
        #endregion Definicion de TipoDato

        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="tipo_detalle_personalizado_id">The tipo_detalle_personalizado_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal tipo_detalle_personalizado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_DETALLES_PERSONALIZADOSRow row = sesion.Db.TIPOS_DETALLES_PERSONALIZADOSCollection.GetByPrimaryKey(tipo_detalle_personalizado_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetTiposDetallesPersonalizadosDataTable
        /// <summary>
        /// Gets the tipos detalles personalizados data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTiposDetallesPersonalizadosDataTable()
        {
            using(SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_DETALLES_PERSONALIZADOSCollection.GetAsDataTable(string.Empty, TiposDetallesPersonalizadosService.Nombre_NombreCol);
            }
        }
        #endregion GetTiposDetallesPersonalizadosDataTable

        #region GetEstructura
        /// <summary>
        /// Gets the estructura.
        /// </summary>
        /// <param name="tipo_detalle_personalizado_id">The tipo_detalle_personalizado_id.</param>
        /// <param name="titulos">The titulos.</param>
        /// <param name="tipos_dato">The tipos_dato.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="obligatorios">The obligatorios.</param>
        /// <param name="disparan_alarma">The disparan_alarma.</param>
        public static void GetEstructura(decimal tipo_detalle_personalizado_id, out string[] titulos, out int[] tipos_dato, out decimal[] orden, out bool[] obligatorios, out bool[] disparan_alarma)
        {
            using (SessionService sesion = new SessionService())
            {
                string[] strTmp;
                TIPOS_DETALLES_PERSONALIZADOSRow row = sesion.Db.TIPOS_DETALLES_PERSONALIZADOSCollection.GetByPrimaryKey(tipo_detalle_personalizado_id);
                
                titulos = row.TITULOS.Split(TiposDetallesPersonalizadosService.vSeparador, StringSplitOptions.RemoveEmptyEntries);

                strTmp = row.TIPOS_DATO.Split(TiposDetallesPersonalizadosService.vSeparador, StringSplitOptions.RemoveEmptyEntries);
                tipos_dato = Array.ConvertAll<string, int>(strTmp, Convert.ToInt32);

                strTmp = row.ORDEN.Split(TiposDetallesPersonalizadosService.vSeparador, StringSplitOptions.RemoveEmptyEntries);
                orden = Array.ConvertAll<string, decimal>(strTmp, Convert.ToDecimal);

                strTmp = row.OBLIGATORIOS.Split(TiposDetallesPersonalizadosService.vSeparador, StringSplitOptions.RemoveEmptyEntries);
                obligatorios = new bool[strTmp.Length];
                for (int i = 0; i < strTmp.Length; i++)
                    obligatorios[i] = strTmp[i].Equals(Definiciones.SiNo.Si);

                strTmp = row.DISPARAN_ALARMA.Split(TiposDetallesPersonalizadosService.vSeparador, StringSplitOptions.RemoveEmptyEntries);
                disparan_alarma = new bool[strTmp.Length];
                for (int i = 0; i < strTmp.Length; i++)
                    disparan_alarma[i] = strTmp[i].Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion GetEstructura

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_DETALLES_PERSONALIZADOS"; }
        }
        public static string DisparanAlarma_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.DISPARAN_ALARMAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.NOMBREColumnName; }
        }
        public static string Obligatorio_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.OBLIGATORIOSColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.OBSERVACIONColumnName; }
        }
        public static string Orden_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.ORDENColumnName; }
        }
        public static string Privado_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.PRIVADOColumnName; }
        }
        public static string TiposDato_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.TIPOS_DATOColumnName; }
        }
        public static string Titulos_NombreCol
        {
            get { return TIPOS_DETALLES_PERSONALIZADOSCollection.TITULOSColumnName; }
        }
        #endregion Accessors
    }
}
