using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class TiposClienteRecalendarizacionService
    {
        #region GetTiposClientesRecalendarizacionDataTable
        /// <summary>
        /// Retorna un datatable con la informacion de los tipos de cuenta bancaria
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static  DataTable  GetTiposClientesRecalendarizacionDataTable(decimal tipo_cliente)
        {
            using (SessionService sesion = new SessionService())
            {


                return GetTiposClientesRecalendarizacionDataTable(tipo_cliente, sesion);
            }
        }
        public static  DataTable  GetTiposClientesRecalendarizacionDataTable(decimal tipo_cliente, SessionService sesion)
        {
           


                return sesion.Db.TIPO_CLIENTE_RECALENDARIZACIONCollection.GetByTIPO_CLIENTE_IDAsDataTable(tipo_cliente);

        }

        public static DataTable GetTiposClientesRecalendarizacionDataTable(string where)
        {
            using (SessionService sesion = new SessionService())
            {


                return GetTiposClientesRecalendarizacionDataTable(where, sesion);
            }
        }
        public static DataTable GetTiposClientesRecalendarizacionDataTable(string where, SessionService sesion)
        {



            return sesion.Db.TIPO_CLIENTE_RECALENDARIZACIONCollection.GetAsDataTable(where, TiposClienteRecalendarizacionService.Id_NombreCol);

        }
        #endregion GetTiposClientesRecalendarizacionDataTable
        #region Guardar
        public static void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                Borrar(id, sesion);
            }
        }
        public static void Borrar(decimal id, SessionService sesion)
        {
            try
                {

                    TIPO_CLIENTE_RECALENDARIZACIONRow recalendarizacion = new TIPO_CLIENTE_RECALENDARIZACIONRow();
                    String valorAnterior = string.Empty;
                    string where = string.Empty;
                   
                    recalendarizacion = sesion.Db.TIPO_CLIENTE_RECALENDARIZACIONCollection.GetByPrimaryKey(id);
                    valorAnterior = recalendarizacion.ToString();
                    sesion.Db.BeginTransaction();
                    sesion.db.TIPO_CLIENTE_RECALENDARIZACIONCollection.Delete(recalendarizacion);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, recalendarizacion.ID, valorAnterior, recalendarizacion.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
        }
        #endregion

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
            TIPO_CLIENTE_RECALENDARIZACIONRow recalendarizacion = new TIPO_CLIENTE_RECALENDARIZACIONRow();
            String valorAnterior = string.Empty;
            string where = string.Empty;
           
                if (!campos.Contains(TiposClienteRecalendarizacionService.TipoClienteId_NombreCol))
                    throw new Exception("Debe indicar el Tipo cliente");
                if (!campos.Contains(TiposClienteRecalendarizacionService.DiasMinimo_NombreCol))
                    throw new Exception("Debe el mínimo de días");
                if (!campos.Contains(TiposClienteRecalendarizacionService.DiasMaximo_NombreCol))
                    throw new Exception("Debe el máximo de días");
                if (!campos.Contains(TiposClienteRecalendarizacionService.DiasDefecto_NombreCol))
                    throw new Exception("Debe indicar el valor por defecto");

             TIPO_CLIENTE_RECALENDARIZACIONRow[] rows   = sesion.db.TIPO_CLIENTE_RECALENDARIZACIONCollection.GetByTIPO_CLIENTE_ID(decimal.Parse(campos[TiposClienteRecalendarizacionService.TipoClienteId_NombreCol].ToString()));

            if (insertarNuevo)
            {
                recalendarizacion.ID = sesion.Db.GetSiguienteSecuencia("TP_CLIE_RECALENDARIZACION_SQC");
                valorAnterior = Definiciones.Log.RegistroNuevo;
                if (rows.Length > 0)
                {
                    throw new Exception("Ya existen parámetros para este tipo de clientes");
                }
            }
            else
            {
                if (rows.Length > 0)
                {
                    throw new Exception("Ya existen parámetros para este tipo de clientes");
                }

                if (!campos.Contains(TiposClienteRecalendarizacionService.Id_NombreCol))
                    throw new Exception("Falta el Id");


                recalendarizacion = sesion.Db.TIPO_CLIENTE_RECALENDARIZACIONCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                valorAnterior = recalendarizacion.ToString();
            }
            if (campos.Contains(TiposClienteRecalendarizacionService.TipoClienteId_NombreCol))
                recalendarizacion.TIPO_CLIENTE_ID = decimal.Parse(campos[TiposClienteRecalendarizacionService.TipoClienteId_NombreCol].ToString());

            if (campos.Contains(TiposClienteRecalendarizacionService.DiasMinimo_NombreCol))
                recalendarizacion.DIAS_MINIMOS = decimal.Parse(campos[TiposClienteRecalendarizacionService.DiasMinimo_NombreCol].ToString());

            if (campos.Contains(TiposClienteRecalendarizacionService.DiasMaximo_NombreCol))
                recalendarizacion.DIAS_MAXIMOS = decimal.Parse(campos[TiposClienteRecalendarizacionService.DiasMaximo_NombreCol].ToString());

            if (campos.Contains(TiposClienteRecalendarizacionService.DiasDefecto_NombreCol))
                recalendarizacion.DIAS_DEFECTO = decimal.Parse(campos[TiposClienteRecalendarizacionService.DiasDefecto_NombreCol].ToString());

            
            if (insertarNuevo)
                sesion.db.TIPO_CLIENTE_RECALENDARIZACIONCollection.Insert(recalendarizacion);
            else
                sesion.db.TIPO_CLIENTE_RECALENDARIZACIONCollection.Update(recalendarizacion);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, recalendarizacion.ID, valorAnterior, recalendarizacion.ToString(), sesion);
        }
       
        #endregion Guardar

        #region Constructor
        public TiposClienteRecalendarizacionService()
        { 
        
        }

        #endregion Constructor

        #region Accessors

        #region Tabla

        public static string Nombre_Tabla
        {
            get { return "TIPO_CLIENTE_RECALENDARIZACION"; }
        }
        //id
        public static string Id_NombreCol
        {
            get { return TIPO_CLIENTE_RECALENDARIZACIONCollection.IDColumnName; }
        }
        //descripcion
        public static string TipoClienteId_NombreCol
        {
            get { return TIPO_CLIENTE_RECALENDARIZACIONCollection.TIPO_CLIENTE_IDColumnName; }
        }
        public static string DiasMinimo_NombreCol
        {
            get { return TIPO_CLIENTE_RECALENDARIZACIONCollection.DIAS_MINIMOSColumnName; }
        }

        public static string DiasMaximo_NombreCol
        {
            get { return TIPO_CLIENTE_RECALENDARIZACIONCollection.DIAS_MAXIMOSColumnName; }
        }

        public static string DiasDefecto_NombreCol
        {
            get { return TIPO_CLIENTE_RECALENDARIZACIONCollection.DIAS_DEFECTOColumnName; }
        }


        #endregion Tabla

        #region Vista
        //no existe vista en esta tabla
        #endregion Vista

        #endregion Accessors
    }
}
