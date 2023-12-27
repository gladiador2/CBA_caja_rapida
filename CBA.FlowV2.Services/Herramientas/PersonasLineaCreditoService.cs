using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PersonasLineaCreditoService
    {
        #region GetPersonasLineaCreditoDataTable
        public DataTable GetPersonasLineaCreditoDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                table = sesion.Db.PERSONAS_LINEA_CREDITOCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetPersonasLineaCreditoDataTable

        #region GetPersonasLineaCredito
        public DataRow GetPersonasLineaCredito(decimal personaId)
        { 
            using (SessionService sesion = new SessionService())
            {
                return GetPersonasLineaCredito(personaId, sesion);
            }
        }

        public static DataTable GetPersonasLineaCreditoDataTable(decimal personaId)
        {
            using (SessionService sesion = new SessionService()) {
                return GetPersonasLineaCreditoDataTable(personaId, sesion);
            }
        }


        public DataRow GetPersonasLineaCredito(decimal personaId, SessionService sesion)
        {
            DataTable table;
            string clausulas= PersonaId_NombreCol + " = " + personaId.ToString() +
                " and (" + Aprobado_NombreCol + " = '" + Definiciones.SiNo.Si +"' " +
                " or " + Aprobado_NombreCol + " is null)";
            table = sesion.Db.PERSONAS_LINEA_CREDITOCollection.GetAsDataTable(clausulas, FechaAsignacion_NombreCol + " desc");
            return table.Rows[0];
        }

        public static DataTable GetPersonasLineaCreditoDataTable(decimal personaId, SessionService sesion)
        {
            DataTable table;
            string clausulas = PersonaId_NombreCol + " = " + personaId.ToString() +
                " and (" + Aprobado_NombreCol + " = '" + Definiciones.SiNo.Si + "' " +
                " or " + Aprobado_NombreCol + " is null)";
            table = sesion.Db.PERSONAS_LINEA_CREDITOCollection.GetAsDataTable(clausulas, FechaAsignacion_NombreCol + " desc");
            return table;
        }
        #endregion GetPersonasLineaCredito

        #region PersonaTieneLineaCredito
        public bool PersonaTieneLineaCredito(decimal personaId)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string clausulas = PersonaId_NombreCol + " = " + personaId.ToString() +
                    " and (" + Aprobado_NombreCol + " = '" + Definiciones.SiNo.Si + "' " +
                    " or " + Aprobado_NombreCol + " is null)";
                table = sesion.Db.PERSONAS_LINEA_CREDITOCollection.GetAsDataTable(clausulas, FechaAsignacion_NombreCol + " desc");
                return table.Rows.Count > 0;
            }
        }
        #endregion PersonaTieneLineaCredito

        #region GetMonedaLineaCredito
        /// <summary>
        /// Gets the moneda linea credito.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <returns></returns>
        public decimal GetMonedaLineaCredito(decimal persona_id)
        {
            DataTable dt = this.GetPersonasLineaCreditoDataTable(PersonasLineaCreditoService.PersonaId_NombreCol + " = " + persona_id, PersonasLineaCreditoService.Id_NombreCol + " desc");

            if (dt.Rows.Count > 0)
                return (decimal)dt.Rows[0][PersonasLineaCreditoService.MonedaId_NombreCol];
            else 
                return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion GetMonedaLineaCredito

        #region GetPedidosPendientes
        public static DataTable GetPedidosPendientes(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPedidosPendientes(clausula, sesion);
            }
        }

        public static DataTable GetPedidosPendientes(string clausula, SessionService sesion)
        {
            DataTable table;
            table = sesion.Db.LINEA_CREDITO_PEDIDO_PENDIENTECollection.GetAsDataTable(clausula, string.Empty);
            return table;
        }
        #endregion GetPedidosPendientes

        #region GetFacturasPendientes
        public static DataTable GetFacturasPendientes(string clausula)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFacturasPendientes(clausula, sesion);
            }
        }

        public static DataTable GetFacturasPendientes(string clausula, SessionService sesion)
        {
            DataTable table;
            table = sesion.Db.LINEA_CREDITO_FACTURA_PENDCollection.GetAsDataTable(clausula, string.Empty);
            return table;
        }
        #endregion GetFacturasPendientes

        #region Guardar
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    decimal id = Guardar(sesion, campos, insertarNuevo);

                    sesion.Db.CommitTransaction();

                    return id;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public decimal Guardar(SessionService sesion, System.Collections.Hashtable campos, bool insertarNuevo)
        {
            PERSONAS_LINEA_CREDITORow row = new PERSONAS_LINEA_CREDITORow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("personas_linea_credito_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.FECHA_ASIGNACION = DateTime.Now;
                row.MONTO_LINEA_CREDITO = decimal.Parse(campos[MontoLineaCredito_NombreCol].ToString());
                row.MONEDA_ID = decimal.Parse(campos[MonedaId_NombreCol].ToString());

                row.COTIZACION = decimal.Parse(campos[Cotizacion_NombreCol].ToString());
                if (row.COTIZACION == Definiciones.Error.Valor.EnteroPositivo)
                    throw new Exception("Debe actualizar la cotización de la moneda.");

                row.PERSONA_ID = decimal.Parse(campos[PersonaId_NombreCol].ToString());
                row.USUARIO_ASIGNACION = sesion.Usuario_Id;
            }
            else
            {
                row = sesion.Db.PERSONAS_LINEA_CREDITOCollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                valorAnterior = row.ToString();
            }

            if (campos.Contains(Utilizado_NombreCol))
            {
                row.UTILIZADO = (string)campos[Utilizado_NombreCol];
            }
            if (campos.Contains(Temporal_NombreCol))
            {
                row.TEMPORAL = (string)campos[Temporal_NombreCol];
            }
            if (row.TEMPORAL == Definiciones.SiNo.No)
            {
                row.USUARIO_APROBACION = sesion.Usuario_Id;
                row.APROBADO = (string)campos[Aprobado_NombreCol];
            }
            else
            {
                if (insertarNuevo)
                {
                    //se verifica que no se creen 2 temporales seguidos y que el monto no supere lo permitido
                    if (PersonaTieneLineaCredito(row.PERSONA_ID))
                    {
                        DataRow rowViejo = GetPersonasLineaCredito(row.PERSONA_ID);
                        if (rowViejo[Temporal_NombreCol].ToString() == Definiciones.SiNo.Si)
                        {
                            throw new Exception("No se pueden crear 2 lineas de credito temporales de seguido");
                        }

                        decimal aumento = VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.AumentoLineaCredito);
                        decimal montoViejo = (decimal)rowViejo[MontoLineaCredito_NombreCol];
                        decimal montoMax = montoViejo + (montoViejo * aumento) / 100;
                        if (row.MONTO_LINEA_CREDITO > montoMax)
                        {
                            throw new Exception("No se puede asignar una linea de credito temporal mayor a " + montoMax.ToString());
                        }
                    }
                    else
                    {
                        throw new Exception("No se puede crear una linea de credito temporal porque la persona no cuenta con una linea de credito");
                    }
                }
            }

            if (insertarNuevo) sesion.Db.PERSONAS_LINEA_CREDITOCollection.Insert(row);
            else sesion.Db.PERSONAS_LINEA_CREDITOCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            return row.ID;
        }
        #endregion PersonaTieneLineaCredito

        #region Borrar
        public void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    PERSONAS_LINEA_CREDITORow row = sesion.Db.PERSONAS_LINEA_CREDITOCollection.GetRow(Id_NombreCol + " = " + id);
                    if (row.TEMPORAL == Definiciones.SiNo.Si)
                    {
                        throw new Exception("No se pueden borrar lineas de credito temporales");
                    }
                    sesion.Db.PERSONAS_LINEA_CREDITOCollection.Delete(row);
                    sesion.CommitTransaction();
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
            get { return "PERSONAS_LINEA_CREDITO"; }
        }
        public static string Id_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.IDColumnName; }
        }
        public static string Aprobado_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.APROBADOColumnName; }
        }
        public static string FechaAsignacion_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.FECHA_ASIGNACIONColumnName; }
        }
        public static string MontoLineaCredito_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.MONTO_LINEA_CREDITOColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.MONEDA_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.COTIZACIONColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.PERSONA_IDColumnName; }
        }
        public static string Temporal_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.TEMPORALColumnName; }
        }
        public static string UsuarioAprobacion_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.USUARIO_APROBACIONColumnName; }
        }
        public static string UsuarioAsignacion_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.USUARIO_ASIGNACIONColumnName; }
        }
        public static string Utilizado_NombreCol
        {
            get { return PERSONAS_LINEA_CREDITOCollection.UTILIZADOColumnName; }
        }
        public static string VistaPedidosPendientes_NombreCol
        {
            get { return LINEA_CREDITO_PEDIDO_PENDIENTECollection.PENDIENTEColumnName; }
        }
        public static string VistaPedidosPersonaId_NombreCol
        {
            get { return LINEA_CREDITO_PEDIDO_PENDIENTECollection.PERSONA_IDColumnName; }
        }
        public static string VistaPedidosMonedaId_NombreCol
        {
            get { return LINEA_CREDITO_PEDIDO_PENDIENTECollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string VistaFacturasPendientes_NombreCol
        {
            get { return LINEA_CREDITO_FACTURA_PENDCollection.PENDIENTEColumnName; }
        }
        public static string VistaFacturasPersonaId_NombreCol
        {
            get { return LINEA_CREDITO_FACTURA_PENDCollection.PERSONA_IDColumnName; }
        }
        public static string VistaFacturasPersonaGarante1Id_NombreCol
        {
            get { return LINEA_CREDITO_FACTURA_PENDCollection.PERSONA_GARANTE_1_IDColumnName; }
        }
        public static string VistaFacturasPersonaGarante2Id_NombreCol
        {
            get { return LINEA_CREDITO_FACTURA_PENDCollection.PERSONA_GARANTE_2_IDColumnName; }
        }
        public static string VistaFacturasPersonaGarante3Id_NombreCol
        {
            get { return LINEA_CREDITO_FACTURA_PENDCollection.PERSONA_GARANTE_3_IDColumnName; }
        }
        public static string VistaFacturasMonedaId_NombreCol
        {
            get { return LINEA_CREDITO_FACTURA_PENDCollection.MONEDA_DESTINO_IDColumnName; }
        }
        public static string VistaFacturasCotizacion_NombreCol
        {
            get { return LINEA_CREDITO_FACTURA_PENDCollection.COTIZACION_DESTINOColumnName; }
        }
        public static string VistaPedidoCotizacion_NombreCol
        {
            get { return LINEA_CREDITO_PEDIDO_PENDIENTECollection.COTIZACION_DESTINOColumnName; }
        }
        #endregion Accessors
    }
}
