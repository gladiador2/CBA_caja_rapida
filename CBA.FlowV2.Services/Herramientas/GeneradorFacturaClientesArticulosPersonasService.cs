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
    public class GeneradorFacturaClientesArticulosPersonasService
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
        
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo,SessionService sesion)
        {
            try
            {
                GEN_FC_CLIE_PER_ARTRow generadorArticulosPersonas = new GEN_FC_CLIE_PER_ARTRow();
                String valorAnterior = "";
                decimal dAux;           
                                
                if (!campos.Contains(GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol))
                    throw new Exception("Debe Indicar la Cantidad");
                if (!campos.Contains(GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol))
                    throw new Exception("Debe Indicar el Precio Unitario");
                           
                if (insertarNuevo)
                {
                    if (!campos.Contains(GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol))
                        throw new Exception("Debe Indicar Articulo a Incluir");
                    if (!campos.Contains(GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol))
                        throw new Exception("Debe Indicar El Cliente Incluido");

                    generadorArticulosPersonas.ID = sesion.Db.GetSiguienteSecuencia("GEN_FC_CLIE_PER_ART_SQC");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    generadorArticulosPersonas.GEN_FC_CLIE_ART_ID = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol].ToString());
                    generadorArticulosPersonas.GEN_FC_CLIE_PER_ID = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol].ToString());
                    generadorArticulosPersonas.INCLUIR = Definiciones.SiNo.Si;
                    generadorArticulosPersonas.IMPUESTO_ID = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol].ToString());
                }
                else
                {
                    if (!campos.Contains(GeneradorFacturaClientesArticulosPersonasService.Id_NombreCol))
                        throw new Exception("Debe Incuir el Id");

                    dAux = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.Id_NombreCol].ToString());
                    generadorArticulosPersonas = sesion.Db.GEN_FC_CLIE_PER_ARTCollection.GetByPrimaryKey(dAux);
                    valorAnterior = generadorArticulosPersonas.ToString();
                }
                if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol))
                    generadorArticulosPersonas.CANTIDAD = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol))
                    generadorArticulosPersonas.PRECIO_UNITARIO = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol].ToString());
                if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol))
                    generadorArticulosPersonas.OBSERVACION = campos[GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol].ToString();

                generadorArticulosPersonas.TOTAL = generadorArticulosPersonas.PRECIO_UNITARIO * generadorArticulosPersonas.CANTIDAD;

                if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.Incluir_NombreCol))
                    generadorArticulosPersonas.INCLUIR = campos[GeneradorFacturaClientesArticulosPersonasService.Incluir_NombreCol].ToString();

                if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol))
                    generadorArticulosPersonas.IMPUESTO_ID = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol].ToString());

                if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.PorcentajeDto_NombreCol))
                    generadorArticulosPersonas.PORCENTAJE_DTO = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.PorcentajeDto_NombreCol].ToString());
                
                if (insertarNuevo)
                    sesion.db.GEN_FC_CLIE_PER_ARTCollection.Insert(generadorArticulosPersonas);
                else
                    sesion.db.GEN_FC_CLIE_PER_ARTCollection.Update(generadorArticulosPersonas);

                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesPersonasService.Nombre_Tabla, generadorArticulosPersonas.ID, valorAnterior, generadorArticulosPersonas.ToString(), sesion);
                return generadorArticulosPersonas.ID;
            }
            catch (Exception exp)
            {               
                throw (exp);
            }
        }

        public static decimal Borrar(decimal generacion_cliente_articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal valor = Borrar(generacion_cliente_articulo_id, sesion);
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
        public static void BorrarPorGeneradorArticuloId(decimal generacion_articulo_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    BorrarPorGeneradorArticuloId(generacion_articulo_id, sesion);
                    sesion.CommitTransaction();                   
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }
        public static void BorrarPorGeneradorArticuloId(decimal generacion_articulo_id, SessionService sesion)
        {            
                try
                {                    
                    GEN_FC_CLIE_PER_ARTRow[] generadorArticulosPersonas = sesion.db.GEN_FC_CLIE_PER_ARTCollection.GetByGEN_FC_CLIE_ART_ID(generacion_articulo_id);
                    
                    for (int i = 0; i < generadorArticulosPersonas.Length; i++)                    
                        Borrar(generadorArticulosPersonas[i].ID);                   
                }
                catch (Exception exp)
                {                    
                    throw (exp);
                }            
        }

        public static void BorrarPorGeneradorPersonaID(decimal generacion_persona_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    BorrarPorGeneradorPersonaID(generacion_persona_id, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        public static void BorrarPorGeneradorPersonaID(decimal generacion_persona_id, SessionService sesion)
        {
            try
            {                
                GEN_FC_CLIE_PER_ARTRow[] generadorArticulosPersonas = sesion.db.GEN_FC_CLIE_PER_ARTCollection.GetByGEN_FC_CLIE_PER_ID(generacion_persona_id);

                for (int i = 0; i < generadorArticulosPersonas.Length; i++)                
                    Borrar(generadorArticulosPersonas[i].ID);                        
            }
            catch (Exception exp)
            {                
                throw (exp);
            }
        }

        public static decimal Borrar(decimal generacion_cliente_articulo_id, SessionService sesion)
        {
            try
            {
                GEN_FC_CLIE_PER_ARTRow generadorArticulosPersonas = new GEN_FC_CLIE_PER_ARTRow();
             
                generadorArticulosPersonas = sesion.Db.GEN_FC_CLIE_PER_ARTCollection.GetByPrimaryKey(generacion_cliente_articulo_id);
                string valorAnterior = generadorArticulosPersonas.ToString();

                sesion.db.GEN_FC_CLIE_PER_ARTCollection.Delete(generadorArticulosPersonas);

                LogCambiosService.LogDeRegistro(GeneradorFacturaClientesArticulosService.Nombre_Tabla, generadorArticulosPersonas.ID, valorAnterior, Definiciones.Log.RegistroBorrado, sesion);
                return generadorArticulosPersonas.ID;
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public static void Modificar(System.Collections.Hashtable campos,  SessionService sesion)
        {
            try
            {
                GEN_FC_CLIE_PER_ARTRow[] generadorArticulosPersonas;
                String valorAnterior = "";
                
                if (!campos.Contains(GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol))
                    throw new Exception("Debe Incuir el Id del artículo");
                if (!campos.Contains(GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol))
                    throw new Exception("Debe Incuir el Id del cliente");
                string where = GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol + "=" + campos[GeneradorFacturaClientesArticulosPersonasService.GeneradorArticuloId_NombreCol];
                where += " and " + GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol + "=" + campos[GeneradorFacturaClientesArticulosPersonasService.GeneradorPersonaId_NombreCol];
                
                generadorArticulosPersonas = sesion.Db.GEN_FC_CLIE_PER_ARTCollection.GetAsArray(where, string.Empty);
                
                for (int i = 0; i < generadorArticulosPersonas.Length; i++)
                {
                    valorAnterior = generadorArticulosPersonas.ToString();
                    
                    if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol))
                        generadorArticulosPersonas[i].CANTIDAD = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.Cantidad_NombreCol].ToString());
                    if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol))
                        generadorArticulosPersonas[i].PRECIO_UNITARIO= decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.PrecioUnitario_NombreCol].ToString());
                    if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol))
                        generadorArticulosPersonas[i].OBSERVACION = campos[GeneradorFacturaClientesArticulosPersonasService.Observacion_NombreCol].ToString();
                    
                    generadorArticulosPersonas[i].TOTAL = generadorArticulosPersonas[i].PRECIO_UNITARIO * generadorArticulosPersonas[i].CANTIDAD;

                    if (campos.Contains(GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol))
                        generadorArticulosPersonas[i].IMPUESTO_ID = decimal.Parse(campos[GeneradorFacturaClientesArticulosPersonasService.ImpuestoId_NombreCol].ToString());
                    
                    sesion.db.GEN_FC_CLIE_PER_ARTCollection.Update(generadorArticulosPersonas[i]);
                    
                    LogCambiosService.LogDeRegistro(GeneradorFacturaClientesPersonasService.Nombre_Tabla, generadorArticulosPersonas[i].ID, valorAnterior, generadorArticulosPersonas.ToString(), sesion);
                }                
            }
            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public static void Modificar(System.Collections.Hashtable campos )
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    Modificar(campos, sesion);
                    sesion.CommitTransaction();                    
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw (exp);
                }
            }
        }

        #endregion Guardar

        #region Get

        public static DataTable GetGeneradorFacturasClientesArticulosDataTable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasClientesArticulosDataTable(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
 
        }

        public static DataTable GetGeneradorFacturasClientesArticulosDataTable(string where, string orderBy, SessionService sesion)
        {

            return sesion.db.GEN_FC_CLIE_PER_ARTCollection.GetAsDataTable(where, orderBy);
        }

        public static DataTable GetGeneradorFacturasClientesArticulosDataTableInfoCompleta(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    return GetGeneradorFacturasClientesArticulosDataTableInfoCompleta(where, orderBy, sesion);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

        }

        public static DataTable GetGeneradorFacturasClientesArticulosDataTableInfoCompleta(string where, string orderBy, SessionService sesion)
        {

            return sesion.db.GEN_FC_CLIE_PER_ART_INFO_COMPCollection.GetAsDataTable(where, orderBy);
        }
        #endregion Get

        #region Accesors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "GEN_FC_CLIE_PER_ART"; }
        }
        public static string Id_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.IDColumnName; }
        }
        public static string GeneradorArticuloId_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.GEN_FC_CLIE_ART_IDColumnName; }
        }

        public static string GeneradorPersonaId_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.GEN_FC_CLIE_PER_IDColumnName; }
        }
        public static string ImpuestoId_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.IMPUESTO_IDColumnName; }
        }
        public static string Incluir_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.INCLUIRColumnName; }
        }
        public static string PrecioUnitario_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.PRECIO_UNITARIOColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.CANTIDADColumnName; }
        }
        public static string Total_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.TOTALColumnName; }
        }
        public static string Observacion_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.OBSERVACIONColumnName; }
        }
        public static string PorcentajeDto_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ARTCollection.PORCENTAJE_DTOColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string Vista_Tabla
        {
            get { return "GEN_FC_CLIE_PER_ART_INFO_COMP"; }
        }
        public static string VistaArticuloId_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ART_INFO_COMPCollection.ARTICULO_IDColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ART_INFO_COMPCollection.ARTICULO_CODIGOColumnName; }
        }
        public static string VistaArticuloDescripcion_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ART_INFO_COMPCollection.ARTICULO_DESCRIPCIONColumnName; }
        }
        public static string VistaImpuestoNombre_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ART_INFO_COMPCollection.IMPUESTO_NOMBREColumnName; }
        }       
        public static string VistaPersonaId_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ART_INFO_COMPCollection.PERSONA_IDColumnName; }
        }
        public static string VistaPersonaCodigo_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ART_INFO_COMPCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return GEN_FC_CLIE_PER_ART_INFO_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        #endregion Vista
        #endregion Accesors
    }
}
