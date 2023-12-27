using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PagoContratistasServices
    {
        #region Get Datatable                
        
        public static DataTable GetPagoContratistasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetPagoContratistasDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetPagoContratistasDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.PAGO_CONTRATISTASCollection.GetAsDataTable(clausulas, orden);
        }

        #endregion Get Datatable

        #region GetMonedaId
        public static decimal GetMonedaId(decimal pago_contratistas_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.db.PAGO_CONTRATISTASCollection.GetByPrimaryKey(pago_contratistas_id).MONEDA_ID;
            }
        }
        #endregion  GetMonedaId

        #region Guardar

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    Guardar(campos, insertarNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            PAGO_CONTRATISTASRow pagoContratistas = new PAGO_CONTRATISTASRow();
            String valorAnterior = string.Empty;
            string where = string.Empty;
            DataTable dtExiste = new DataTable();
            if (insertarNuevo)
            {
                if (!campos.Contains(PagoContratistasServices.ProveedorId_NombreCol))
                    throw new Exception("Debe indicar el Proveedor");

                if (!campos.Contains(PagoContratistasServices.SucursalId_NombreCol))
                    throw new Exception("Debe indicar la Sucursal");

                if (!campos.Contains(PagoContratistasServices.MonedaId_NombreCol))
                    throw new Exception("Debe indicar la Moneda");

                where = PagoContratistasServices.ProveedorId_NombreCol + " = " + campos[ProveedorId_NombreCol].ToString();

                dtExiste = GetPagoContratistasDataTable(where, string.Empty);
                if (dtExiste.Rows.Count > 0)
                    throw new Exception("Proveedor ya seleccionado.");
            
                pagoContratistas.ID = sesion.Db.GetSiguienteSecuencia("pago_contratistas_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                if (!campos.Contains(Id_NombreCol))
                    throw new Exception("Falta el Id");

                where = PagoContratistasServices.Id_NombreCol + " <> " + campos[Id_NombreCol].ToString() +
                        " and " + PagoContratistasServices.ProveedorId_NombreCol + " = " + campos[ProveedorId_NombreCol].ToString();
                
                dtExiste = GetPagoContratistasDataTable(where, string.Empty);
                if (dtExiste.Rows.Count > 0)
                    throw new Exception("Proveedor ya seleccionado.");

                pagoContratistas = sesion.Db.PAGO_CONTRATISTASCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                valorAnterior = pagoContratistas.ToString();
            }
            if (campos.Contains(PagoContratistasServices.ProveedorId_NombreCol))
                pagoContratistas.PROVEEDOR_ID = decimal.Parse(campos[PagoContratistasServices.ProveedorId_NombreCol].ToString());
           
            if (campos.Contains(PagoContratistasServices.MontoTotal_NombreCol))
                pagoContratistas.MONTO_TOTAL = decimal.Parse(campos[PagoContratistasServices.MontoTotal_NombreCol].ToString());
            
            if (campos.Contains(PagoContratistasServices.SaldoMontoAdelanto_NombreCol))
                pagoContratistas.SALDO_MONTO_ADELANTO_INICIAL = decimal.Parse(campos[PagoContratistasServices.SaldoMontoAdelanto_NombreCol].ToString());
            
            if (campos.Contains(PagoContratistasServices.SaldoMontoFijo_NombreCol))
                pagoContratistas.SALDO_ADELANTOS = decimal.Parse(campos[PagoContratistasServices.SaldoAdelantos_NombreCol].ToString());
            
            if (campos.Contains(PagoContratistasServices.SaldoAdelantos_NombreCol))
                pagoContratistas.SALDO_MONTO_FIJO = decimal.Parse(campos[PagoContratistasServices.SaldoMontoFijo_NombreCol].ToString());
            
            if (campos.Contains(PagoContratistasServices.SaldoFacturas_NombreCol))
                pagoContratistas.SALDO_FACTURAS = decimal.Parse(campos[PagoContratistasServices.SaldoFacturas_NombreCol].ToString());

            if (campos.Contains(PagoContratistasServices.SaldoFondoReparo_NombreCol))
                pagoContratistas.SALDO_FONDO_REPARO = decimal.Parse(campos[PagoContratistasServices.SaldoFondoReparo_NombreCol].ToString());

            if (campos.Contains(PagoContratistasServices.SucursalId_NombreCol))
                pagoContratistas.SUCURSAL_ID = decimal.Parse(campos[PagoContratistasServices.SucursalId_NombreCol].ToString());

            if (campos.Contains(PagoContratistasServices.MonedaId_NombreCol))
                pagoContratistas.MONEDA_ID = decimal.Parse(campos[PagoContratistasServices.MonedaId_NombreCol].ToString());

            if (campos.Contains(PagoContratistasServices.ImpuestoId_NombreCol))
                pagoContratistas.IMPUESTO_ID = decimal.Parse(campos[PagoContratistasServices.ImpuestoId_NombreCol].ToString());
            else
                pagoContratistas.IMPUESTO_ID = 1;

            if (campos.Contains(PagoContratistasServices.CtacteFondoFijoId_NombreCol))
                pagoContratistas.CTACTE_FONDO_FIJO_ID= decimal.Parse(campos[PagoContratistasServices.CtacteFondoFijoId_NombreCol].ToString());

            if (insertarNuevo)
                sesion.db.PAGO_CONTRATISTASCollection.Insert(pagoContratistas);
            else
                sesion.db.PAGO_CONTRATISTASCollection.Update(pagoContratistas);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, pagoContratistas.ID, valorAnterior, pagoContratistas.ToString(), sesion);
        }
       
        #endregion Guardar

        #region Accessors
        
        public static string Nombre_Tabla
        {
            get { return "PAGO_CONTRATISTAS"; }
        }
        public static string CtacteFondoFijoId_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.CTACTE_FONDO_FIJO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.IMPUESTO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.MONEDA_IDColumnName; }
        }
        public static string MontoTotal_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.MONTO_TOTALColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.PROVEEDOR_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.SUCURSAL_IDColumnName; }
        }
        public static string SaldoMontoFijo_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.SALDO_MONTO_FIJOColumnName; }
        }
        public static string SaldoMontoAdelanto_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.SALDO_MONTO_ADELANTO_INICIALColumnName; }
        }
        public static string SaldoFondoReparo_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.SALDO_FONDO_REPAROColumnName; }
        }
        public static string SaldoFacturas_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.SALDO_FACTURASColumnName; }
        }
        public static string SaldoAdelantos_NombreCol
        {
            get { return PAGO_CONTRATISTASCollection.SALDO_ADELANTOSColumnName; }
        }

        #endregion Accessors
    }
}
