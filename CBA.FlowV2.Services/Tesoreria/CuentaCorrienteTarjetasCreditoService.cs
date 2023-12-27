using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteTarjetasCreditoService
    {
        #region GetTarjetaCreditoDataTable
        public static DataTable GetTarjetaCreditoInfoCompleta(string clausulas, SessionService sesion)
        {
            string where = Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
            DataTable dt;          
           
            dt = sesion.Db.CTACTE_TARJETA_CREDI_INF_COMPCollection.GetAsDataTable(where, string.Empty);
          
            return dt;
        }

        public static DataTable GetTarjetaCreditoInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetTarjetaCreditoInfoCompleta(clausulas, sesion);
            }
        }
        #endregion GetTarjetaCreditoDataTable

        #region Guardar
        public static decimal Guardar(Hashtable campos, SessionService sesion, bool insertarNuevo)
        {
            CTACTE_TARJETAS_CREDITORow row = new CTACTE_TARJETAS_CREDITORow();           
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_TARJETAS_CREDITO_SQC");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.db.CTACTE_TARJETAS_CREDITOCollection.GetByPrimaryKey(decimal.Parse(campos[Modelo.IDColumnName].ToString()));
                valorAnterior = row.ToString();
            }

            if (campos.Contains(Modelo.CTACTE_PROCESADORAColumnName))
                row.CTACTE_PROCESADORA = decimal.Parse(campos[Modelo.CTACTE_PROCESADORAColumnName].ToString());
            if (campos.Contains(Modelo.NUMEROColumnName))
                row.NUMERO = campos[Modelo.NUMEROColumnName].ToString();
            if (campos.Contains(Modelo.TITULARColumnName))
                row.TITULAR = campos[Modelo.TITULARColumnName].ToString();
            if (campos.Contains(Modelo.LIMITE_CREDITOColumnName))
                row.LIMITE_CREDITO = decimal.Parse(campos[Modelo.LIMITE_CREDITOColumnName].ToString());
            if (campos.Contains(Modelo.BLOQUEADOColumnName))
                row.BLOQUEADO = campos[Modelo.BLOQUEADOColumnName].ToString();
            if (campos.Contains(Modelo.MOTIVO_ULTIMO_BLOQUEOColumnName))
                row.MOTIVO_ULTIMO_BLOQUEO = campos[Modelo.MOTIVO_ULTIMO_BLOQUEOColumnName].ToString();
            if (campos.Contains(Modelo.USUARIO_ULTIMO_BLOQUEO_IDColumnName))
                row.USUARIO_ULTIMO_BLOQUEO_ID = decimal.Parse(campos[Modelo.USUARIO_ULTIMO_BLOQUEO_IDColumnName].ToString());
            if (campos.Contains(Modelo.FECHA_ULTIMO_BLOQUEOColumnName))
                row.FECHA_ULTIMO_BLOQUEO = DateTime.Parse(campos[Modelo.FECHA_ULTIMO_BLOQUEOColumnName].ToString());
            if (campos.Contains(Modelo.USUARIO_ULTIMO_DESBLOQUEO_IDColumnName))
                row.USUARIO_ULTIMO_DESBLOQUEO_ID = decimal.Parse(campos[Modelo.USUARIO_ULTIMO_DESBLOQUEO_IDColumnName].ToString());
            if (campos.Contains(Modelo.FECHA_ULTIMO_DESBLOQUEOColumnName))
                row.FECHA_ULTIMO_DESBLOQUEO = DateTime.Parse(campos[Modelo.FECHA_ULTIMO_DESBLOQUEOColumnName].ToString());  
            if (campos.Contains(Modelo.ESTADOColumnName))
                row.ESTADO = campos[Modelo.ESTADOColumnName].ToString();
            
            if (insertarNuevo)
            {
                row.USUARIO_CREACION = sesion.Usuario.ID;
                row.FECHA_CREACION = DateTime.Now;
                sesion.db.CTACTE_TARJETAS_CREDITOCollection.Insert(row);
            }
            else
                sesion.db.CTACTE_TARJETAS_CREDITOCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
            return row.ID;
        }

        public static decimal Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    decimal ctacte_tarjetas_credito_id = Guardar(campos, sesion, insertarNuevo);
                    sesion.db.CommitTransaction();
                    return ctacte_tarjetas_credito_id;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region GetProcesadoraTarjeta
        public static decimal GetCtaCteProcesadora(decimal ctacte_tarjeta_credito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_TARJETAS_CREDITORow row = sesion.Db.CTACTE_TARJETAS_CREDITOCollection.GetByPrimaryKey(ctacte_tarjeta_credito_id);
                return row.CTACTE_PROCESADORA;
            }
        }
        #endregion GetProcesadoraTarjeta

        #region Accesors
        public class Modelo : CTACTE_TARJETAS_CREDITOCollection_Base { public Modelo() : base(null) { } }
        public class VistaModelo : CTACTE_TARJETA_CREDI_INF_COMPCollection_Base { public VistaModelo() : base(null) { } }      
        public static string Nombre_Tabla
        {
            get { return "CTACTE_TARJETAS_CREDITO"; }
        }
        public static string Nombre_Vista
        {
            get { return "ctacte_tarjeta_credi_inf_comp"; }
        }

        /*public static string Id_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.IDColumnName; }
        }
        public static string Bloqueado_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.BLOQUEADOColumnName; }
        }
        public static string CtaCteProcesadora_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.CTACTE_PROCESADORAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.ESTADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.FECHA_CREACIONColumnName; }
        }
        public static string FechaUltimoBloqueo_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.FECHA_ULTIMO_BLOQUEOColumnName; }
        }
        public static string FechaUltimoDesbloqueo_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.FECHA_ULTIMO_DESBLOQUEOColumnName; }
        }
        public static string LimiteCredito_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.LIMITE_CREDITOColumnName; }
        }
        public static string MotivoUltimoBloqueo_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.MOTIVO_ULTIMO_BLOQUEOColumnName; }
        }
        public static string Numero_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.NUMEROColumnName; }
        }
        public static string Titular_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.TITULARColumnName; }
        }
        public static string UsuarioCreacion_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.USUARIO_CREACIONColumnName; }
        }
        public static string UsuarioUltimoBloqueoId_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.USUARIO_ULTIMO_BLOQUEO_IDColumnName; }
        }
        public static string UsuarioUltimoDesbloqueoId_NombreCol
        {
            get { return CTACTE_TARJETAS_CREDITOCollection.USUARIO_ULTIMO_DESBLOQUEO_IDColumnName; }
        }
        public static string VistaNombreTarjeta_NombreCol
        {
            get { return CTACTE_TARJETA_CREDI_INF_COMPCollection.NOMBRE_TARJETAColumnName; }
        }    */

        #endregion Accesors
    }
}
