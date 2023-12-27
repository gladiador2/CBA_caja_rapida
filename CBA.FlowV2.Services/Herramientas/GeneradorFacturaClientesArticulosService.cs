#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class GeneradorFacturaClientesArticulosService
    {
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
        public static decimal Agregar(System.Collections.Hashtable campos,decimal[] idClientesASelecionados)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Guardar(campos, true, sesion);
                    System.Collections.Hashtable detalles = new System.Collections.Hashtable();
                    
                    for (int i = 0; i < idClientesASelecionados.Length;i++ )
                    {
                        if (idClientesASelecionados[i] != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            detalles = null;
                            detalles = new System.Collections.Hashtable();
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol, 1);
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol, campos[GeneradorFacturaClientesArticulosService.Precio_NombreCol].ToString());
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol, campos[GeneradorFacturaClientesArticulosService.Observacion_NombreCol].ToString());
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol, valor);
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol, idClientesASelecionados[i]);
                            GeneradorFacturaClientesArticulosPersonasService.Guardar(detalles, true, sesion);
                        }

                    }
                     //
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
        public static decimal Modificar(System.Collections.Hashtable campos, decimal[] idDetallesClientesModificarPrecio, decimal[] idDetallesClientesModificarObs)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Guardar(campos, false, sesion);
                    //Modificar los valores de los cliente modificados
                    System.Collections.Hashtable detalles;
                    for (int i = 0; i < idDetallesClientesModificarObs.Length; i++)
                    {
                        if (idDetallesClientesModificarObs[i] != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            detalles = null;
                            detalles = new System.Collections.Hashtable();
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol, idDetallesClientesModificarObs[i]);
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol, campos[GeneradorFacturaClientesArticulosService.Id_NombreCol]);
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol, campos[GeneradorFacturaClientesArticulosService.Observacion_NombreCol].ToString());
                            GeneradorFacturaClientesArticulosPersonasService.Modificar(detalles, sesion);
                        }
                    }
                    for (int i = 0; i < idDetallesClientesModificarPrecio.Length; i++)
                    {
                        if (idDetallesClientesModificarPrecio[i] != Definiciones.Error.Valor.EnteroPositivo)
                        {
                            detalles = null;
                            detalles = new System.Collections.Hashtable();
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol, idDetallesClientesModificarPrecio[i]);
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol, campos[GeneradorFacturaClientesArticulosService.Id_NombreCol]);
                            detalles.Add(GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol, decimal.Parse(campos[GeneradorFacturaClientesArticulosService.Precio_NombreCol].ToString()));
                            GeneradorFacturaClientesArticulosPersonasService.Modificar(detalles, sesion);
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


                GEN_FC_CLIENTES_ARTICULOSRow generadorArticulos = new GEN_FC_CLIENTES_ARTICULOSRow();
                String valorAnterior = "";
                decimal dAux;
                
                
                if (!campos.Contains(GeneradorFacturaClientesArticulosService.Precio_NombreCol))
                    throw new Exception("Debe Indicar el precio");
           
                if (insertarNuevo)
                {
                    if (!campos.Contains(GeneradorFacturaClientesArticulosService.ArticuloId_NombreCol))
                        throw new Exception("Debe Indicar el Artículo");
                    if (!campos.Contains(GeneradorFacturaClientesArticulosService.GeneracionId_NombreCol))
                        throw new Exception("Debe Indicar la Generación Asociada");

                    generadorArticulos.ID = sesion.Db.GetSiguienteSecuencia("GEN_FC_CLIENTES_ARTICULOS_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    if (!campos.Contains(GeneradorFacturaClientesArticulosService.Id_NombreCol))
                        throw new Exception("Debe Incuir el Id");
                    dAux = decimal.Parse(campos[GeneradorFacturaClientesArticulosService.Id_NombreCol].ToString());
                    generadorArticulos = sesion.Db.GEN_FC_CLIENTES_ARTICULOSCollection.GetByPrimaryKey(dAux);
                    valorAnterior = generadorArticulos.ToString();
                }
                if (campos.Contains(GeneradorFacturaClientesArticulosService.ArticuloId_NombreCol))
                    generadorArticulos.ARTICULO_ID =decimal.Parse(campos[GeneradorFacturaClientesArticulosService.ArticuloId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesArticulosService.GeneracionId_NombreCol))
                    generadorArticulos.GENERACION_FC_CLIENTE_ID = decimal.Parse(campos[GeneradorFacturaClientesArticulosService.GeneracionId_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesArticulosService.Precio_NombreCol))
                    generadorArticulos.PRECIO = decimal.Parse(campos[GeneradorFacturaClientesArticulosService.Precio_NombreCol].ToString());
                
                if (campos.Contains(GeneradorFacturaClientesArticulosService.Observacion_NombreCol))
                    generadorArticulos.OBSERVACION = campos[GeneradorFacturaClientesArticulosService.Observacion_NombreCol].ToString();
                else
                    generadorArticulos.OBSERVACION = string.Empty;

                if (campos.Contains(GeneradorFacturaClientesArticulosService.ImpuestoId_NombreCol))
                    generadorArticulos.IMPUESTO_ID = (decimal)campos[GeneradorFacturaClientesArticulosService.ImpuestoId_NombreCol];
                if (campos.Contains(GeneradorFacturaClientesArticulosService.PorcentajeDto_NombreCol))
                    generadorArticulos.PORCENTAJE_DTO = (decimal)campos[GeneradorFacturaClientesArticulosService.PorcentajeDto_NombreCol];

                if (insertarNuevo)
                    sesion.db.GEN_FC_CLIENTES_ARTICULOSCollection.Insert(generadorArticulos);
                else
                    sesion.db.GEN_FC_CLIENTES_ARTICULOSCollection.Update(generadorArticulos);

                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesArticulosService.Nombre_Tabla, generadorArticulos.ID, valorAnterior, generadorArticulos.ToString(), sesion);
                return generadorArticulos.ID;
            }
            catch (Exception exp)
            {
               
                throw (exp);
            }
        }

        public static decimal Borrar(decimal generacion_articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Borrar(generacion_articulo_id, sesion);
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
        public static decimal  Borrar(decimal generacion_articulo_id, SessionService sesion)
        {
            try
            {


                GEN_FC_CLIENTES_ARTICULOSRow generadorArticulos = new GEN_FC_CLIENTES_ARTICULOSRow();
                String valorAnterior = generadorArticulos.ToString();
                
                    
                    generadorArticulos = sesion.Db.GEN_FC_CLIENTES_ARTICULOSCollection.GetByPrimaryKey(generacion_articulo_id);
                    valorAnterior = generadorArticulos.ToString();
                    //se borran los detalles
                    GeneradorFacturaClientesArticulosPersonasService.BorrarPorGeneradorArticuloId(generadorArticulos.ID);
                    
                    sesion.db.GEN_FC_CLIENTES_ARTICULOSCollection.Delete(generadorArticulos);

                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesArticulosService.Nombre_Tabla, generadorArticulos.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                return generadorArticulos.ID;
            }
            catch (Exception exp)
            {

                throw (exp);
            }
        }
        #endregion Guardar

        #region Get

        public static DataTable GetGeneradorFacturasArticulosDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasArticulosDataTable(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
 
        }

        public static DataTable GetGeneradorFacturasArticulosDataTable(string where, string orderBy,SessionService sesion)
        {

            return sesion.db.GEN_FC_CLIENTES_ARTICULOSCollection.GetAsDataTable(where, orderBy);
        }

        public static DataTable GetGeneradorFacturasArticulosDataTableInfoCompleta(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasArticulosDataTableInfoCompleta(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

        }

        public static DataTable GetGeneradorFacturasArticulosDataTableInfoCompleta(string where, string orderBy, SessionService sesion)
        {

            return sesion.db.GEN_FC_CLIE_ART_INFO_COMPLCollection.GetAsDataTable(where, orderBy);
        }
        #endregion Get

        #region Accesors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "GEN_FC_CLIENTES_ARTICULOS"; }
        }
        public static string Id_NombreCol
        {
            get { return GEN_FC_CLIENTES_ARTICULOSCollection.IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return GEN_FC_CLIENTES_ARTICULOSCollection.ARTICULO_IDColumnName; }
        }
        public static string GeneracionId_NombreCol
        {
            get { return GEN_FC_CLIENTES_ARTICULOSCollection.GENERACION_FC_CLIENTE_IDColumnName; }
        }
        public static string Precio_NombreCol
        {
            get { return GEN_FC_CLIENTES_ARTICULOSCollection.PRECIOColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return GEN_FC_CLIENTES_ARTICULOSCollection.OBSERVACIONColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return GEN_FC_CLIENTES_ARTICULOSCollection.IMPUESTO_IDColumnName; }
        }
        public static string PorcentajeDto_NombreCol
        {
            get { return GEN_FC_CLIENTES_ARTICULOSCollection.PORCENTAJE_DTOColumnName; }
        }
        #endregion Tabla
        #region Vista
        public static string Vista_Tabla
        {
            get { return "GEN_FC_CLIE_ART_INFO_COMPL"; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return GEN_FC_CLIE_ART_INFO_COMPLCollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return GEN_FC_CLIE_ART_INFO_COMPLCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return GEN_FC_CLIE_ART_INFO_COMPLCollection.IMPUESTO_NOMBREColumnName; }
        }
        #endregion Vista
        #endregion Accesors
    }
}
