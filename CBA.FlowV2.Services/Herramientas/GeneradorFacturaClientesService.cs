#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Collections;
using CBA.FlowV2.Services.Facturacion;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class GeneradorFacturaClientesService
    {
        #region GetGeneradorFacturasDataTable
        public static DataTable GetGeneradorFacturasDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasDataTable(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

        }

        public static DataTable GetGeneradorFacturasDataTable(string where, string orderBy, SessionService sesion)
        {

            return sesion.db.GENERADOR_FC_CLIENTECollection.GetAsDataTable(where, orderBy);
        }
        #endregion GetGeneradorFacturasDataTable

        #region GetGeneradorFacturasInfoCompleta
        public static DataTable GetGeneradorFacturasDataTableInfoCompleta(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasDataTableInfoCompleta(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        public static DataTable GetGeneradorFacturasDataTableInfoCompleta(string where, string orderBy, SessionService sesion)
        {
            return sesion.db.GENER_FC_CLIENTE_INFO_COMPLETACollection.GetAsDataTable(where, orderBy);
        }
        #endregion GetGeneradorFacturasInfoCompleta

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor= Guardar(campos, insertarNuevo,sesion);
                    sesion.CommitTransaction();
                    return valor;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        public static decimal Modificar(System.Collections.Hashtable campos,decimal[]IdClientesModificarFecha,decimal[]IdClientesModificarCondicion,decimal[]IdClientesModificarVendedor)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Guardar(campos, false, sesion);

                    Hashtable detalles = new Hashtable();
                    for (int i = 0; i < IdClientesModificarFecha.Length; i++)
                    {
                        if (IdClientesModificarFecha[i] != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            detalles = null;
                            detalles = new Hashtable();
                            detalles.Add(GeneradorFacturaClientesPersonasService.Fecha_NombreCol, campos[GeneradorFacturaClientesService.Fecha_NombreCol].ToString());
                            detalles.Add(GeneradorFacturaClientesPersonasService.Id_NombreCol, IdClientesModificarFecha[i]);
                            GeneradorFacturaClientesPersonasService.Modificar(detalles, sesion);
                        }
                    }
                    for (int i = 0; i < IdClientesModificarCondicion.Length; i++)
                    {
                        if (IdClientesModificarCondicion[i] != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            detalles = null;
                            detalles = new Hashtable();
                            detalles.Add(GeneradorFacturaClientesPersonasService.CondicionId_NombreCol, campos[GeneradorFacturaClientesService.CondicionId_NombreCol].ToString());
                            detalles.Add(GeneradorFacturaClientesPersonasService.Id_NombreCol, IdClientesModificarCondicion[i]);
                            GeneradorFacturaClientesPersonasService.Modificar(detalles, sesion);
                        }
                    }
                    for (int i = 0; i < IdClientesModificarVendedor.Length; i++)
                    {
                        if (IdClientesModificarVendedor[i] != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            detalles = null;
                            detalles = new Hashtable();
                            detalles.Add(GeneradorFacturaClientesPersonasService.FuncionarioVendedorId_NombreCol, campos[GeneradorFacturaClientesService.FuncionarioVendedorId_NombreCol].ToString());
                            detalles.Add(GeneradorFacturaClientesPersonasService.Id_NombreCol, IdClientesModificarVendedor[i]);
                            GeneradorFacturaClientesPersonasService.Modificar(detalles, sesion);
                        }
                    } 
                    sesion.CommitTransaction();
                    return valor;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo,SessionService sesion)
        {
            try
            {
                GENERADOR_FC_CLIENTERow generador = new GENERADOR_FC_CLIENTERow();
                bool vCampoVendedorObligatorio = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.FacturaClienteVendedorObligatorio).Equals(Definiciones.SiNo.Si);
                String valorAnterior = "";
                decimal dAux;
                if (!campos.Contains(GeneradorFacturaClientesService.Nombre_NombreCol))
                    throw new Exception("Debe indicar el nombre.");
                if (!campos.Contains(GeneradorFacturaClientesService.MonedaId_NombreCol))
                    throw new Exception("Debe indicar la moneda.");
                if (!campos.Contains(GeneradorFacturaClientesService.SucursalId_NombreCol))
                    throw new Exception("Debe indicar la sucursal.");
                if (!campos.Contains(GeneradorFacturaClientesService.DepositoId_NombreCol))
                    throw new Exception("Debe indicar la depósito.");
                if (!campos.Contains(GeneradorFacturaClientesService.AutonumeracionId_NombreCol))
                    throw new Exception("Debe indicar el talonario.");
                if (vCampoVendedorObligatorio && !campos.Contains(GeneradorFacturaClientesService.FuncionarioVendedorId_NombreCol))
                    throw new Exception("Debe indicar el vendedor.");
                if (!campos.Contains(GeneradorFacturaClientesService.CondicionId_NombreCol))
                    throw new Exception("Debe indicar la condición de venta.");

                if (VariablesSistemaEntidadService.GetValorDecimal(Definiciones.VariablesDeSistema.EstrategiaPrecio).Equals(Definiciones.EstrategiaPrecio.FlujoModificacionListaPrecios))
                {
                    if (!campos.Contains(GeneradorFacturaClientesService.ListaPrecioId_NombreCol))
                        throw new Exception("Debe indicar la lista de precios.");
                }

                if (insertarNuevo)
                {
                    generador.ID = sesion.Db.GetSiguienteSecuencia("GENERADOR_FC_CLIENTE_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    if (!campos.Contains(GeneradorFacturaClientesService.Id_NombreCol))
                        throw new Exception("Error de implementación: se debe incluir el ID.");
                    dAux=decimal.Parse(campos[GeneradorFacturaClientesService.Id_NombreCol].ToString());
                    generador = sesion.Db.GENERADOR_FC_CLIENTECollection.GetByPrimaryKey(dAux);
                    valorAnterior = generador.ToString();
                }

                if (campos.Contains(GeneradorFacturaClientesService.Nombre_NombreCol))
                    generador.NOMBRE = campos[GeneradorFacturaClientesService.Nombre_NombreCol].ToString();
                if (campos.Contains(GeneradorFacturaClientesService.MonedaId_NombreCol))
                    generador.MONEDA_ID = decimal.Parse(campos[GeneradorFacturaClientesService.MonedaId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesService.SucursalId_NombreCol))
                    generador.SUCURSAL_ID = decimal.Parse(campos[GeneradorFacturaClientesService.SucursalId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesService.DepositoId_NombreCol))
                    generador.DEPOSITO_ID = decimal.Parse(campos[GeneradorFacturaClientesService.DepositoId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesService.AutonumeracionId_NombreCol))
                    generador.AUTONUMERACION_ID =decimal.Parse(campos[GeneradorFacturaClientesService.AutonumeracionId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesService.FuncionarioVendedorId_NombreCol))
                    generador.FUNCIONARIO_VENDEDOR_ID = decimal.Parse(campos[GeneradorFacturaClientesService.FuncionarioVendedorId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesService.Fecha_NombreCol))
                    generador.FECHA = DateTime.Parse(campos[GeneradorFacturaClientesService.Fecha_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesService.ListaPrecioId_NombreCol))
                    generador.LISTA_PRECIO_ID = decimal.Parse(campos[GeneradorFacturaClientesService.ListaPrecioId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesService.CondicionId_NombreCol))
                    generador.CONDICION_PAGO_ID = decimal.Parse(campos[GeneradorFacturaClientesService.CondicionId_NombreCol].ToString());

                if (insertarNuevo)
                    sesion.db.GENERADOR_FC_CLIENTECollection.Insert(generador);
                else
                    sesion.db.GENERADOR_FC_CLIENTECollection.Update(generador);

                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesService.Nombre_Tabla, generador.ID, valorAnterior, generador.ToString(), sesion);
                return generador.ID;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }
        #endregion Guardar

        #region Accesors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "GENERADOR_FC_CLIENTE"; }
        }
        public static string Id_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.IDColumnName; }
        }
        public static string AutonumeracionId_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.AUTONUMERACION_IDColumnName; }
        }
        public static string DepositoId_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.DEPOSITO_IDColumnName; }
        }
        public static string FuncionarioVendedorId_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.FUNCIONARIO_VENDEDOR_IDColumnName; }
        }
        public static string ListaPrecioId_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.LISTA_PRECIO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.MONEDA_IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.NOMBREColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.SUCURSAL_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.FECHAColumnName; }
        }
        public static string CondicionId_NombreCol
        {
            get { return GENERADOR_FC_CLIENTECollection.CONDICION_PAGO_IDColumnName; }
        }
        #endregion Tabla
        #region Vista
        public static string Vista_Tabla
        {
            get { return "GENER_FC_CLIENTE_INFO_COMPLETA"; }
        }
        public static string VistaAutonumeracionActual_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.AUTONUMERACION_ACTUALColumnName; }
        }
        public static string VistaAutonumeracionCodigo_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.AUTONUMERACION_CODIGOColumnName; }
        }
        public static string VistaAutonumeracionLimite_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.AUTONUMERACION_LIMITEColumnName; }
        }
        public static string VistaAutonumeracionPrefijo_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.AUTONUMERACION_PREFIJOColumnName; }
        }
        public static string VistaAutonumeracionTimbrado_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.AUTONUMERACION_TIMBRADOColumnName; }
        }
        public static string VistaDepositoAbreviatura_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.DEPOSITO_ABREVIATURAColumnName; }
        }
        public static string VistaDepositoNombre_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.DEPOSITO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaListaPrecioAbreviatura_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.LISTA_PRECIO_ABREVIATURAColumnName; }
        }
        public static string VistaListaPrecioNombre_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.LISTA_PRECIO_NOMBREColumnName; }
        }
        public static string VistaMonedaCadenaDecimales_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.MONEDA_CADENA_DECIMALESColumnName; }
        }
        public static string VistaMonedaCantidadDecimales_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.MONEDA_CANTIDAD_DECIMALESColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.MONEDA_NOMBREColumnName; }
        }
        public static string VistaMonedaSimbolo_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.MONEDA_SIMBOLOColumnName; }
        }
        public static string VistaSucursalAbreviatura_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.SUCURSAL_ABREVIATURAColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaCondicionNombre_NombreCol
        {
            get { return GENER_FC_CLIENTE_INFO_COMPLETACollection.CONDICION_NOMBREColumnName; }
        }
        #endregion Vista
        #endregion Accesors
    }
}
