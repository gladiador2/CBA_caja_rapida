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
    public class CuentaCorrienteTarjetasConfiguracionService
    {


        #region GetTarjetasConfiguracionDataTable
        public static DataTable GetTarjetasConfiguracionDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                dt = sesion.Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetAsDataTable(clausulas, string.Empty);

                return dt;
            }
        }


        #endregion GetTarjetasConfiguracionDataTable

        #region GetTarjetasConfiguracionInfoCompleta
        public static DataTable GetTarjetasConfiguracionInfoCompleta(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                dt = sesion.Db.CTACTE_TARJETA_CONF_PROC_INF_COMPCollection.GetAsDataTable(clausulas, string.Empty);

                return dt;
            }
        }


        #endregion GetTarjetasConfiguracionInfoCompleta

        #region Guardar
        public static decimal Guardar(Hashtable campos, SessionService sesion, bool insertarNuevo)
        {
            CTACTE_TARJETAS_CONFIG_PROCESOSRow row = new CTACTE_TARJETAS_CONFIG_PROCESOSRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_tarjet_config_proc_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetByPrimaryKey(decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.IDColumnName].ToString()));
                valorAnterior = row.ToString();
            }

            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.POS_IDColumnName))
                row.POS_ID = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.POS_IDColumnName].ToString());
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_IDColumnName))
                row.PROCESADORA_ID = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_IDColumnName].ToString());
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.COMISION_PORCColumnName))
                row.COMISION_PORC = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.COMISION_PORCColumnName].ToString());
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.IVA_SOBRE_COMISION_PORCColumnName))
                row.IVA_SOBRE_COMISION_PORC = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.IVA_SOBRE_COMISION_PORCColumnName].ToString());
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.RENTA_SOBRE_IVA_PORCColumnName))
                row.RENTA_SOBRE_IVA_PORC = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.RENTA_SOBRE_IVA_PORCColumnName].ToString());
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.CTACTE_BANCARIA_ID_DESTColumnName))
                row.CTACTE_BANCARIA_ID_DEST = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.CTACTE_BANCARIA_ID_DESTColumnName].ToString());
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.ES_TARJETA_CREDITOColumnName))
                row.ES_TARJETA_CREDITO = campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.ES_TARJETA_CREDITOColumnName].ToString();
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.CTACTE_CAJA_IDColumnName))
                row.CTACTE_CAJA_ID = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.CTACTE_CAJA_IDColumnName].ToString());

            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_ID_RED_DINELCOColumnName))
            {
                if (campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_ID_RED_DINELCOColumnName].ToString().Equals(string.Empty))
                    row.IsPROCESADORA_ID_RED_DINELCONull = true;

                row.PROCESADORA_ID_RED_DINELCO = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_ID_RED_DINELCOColumnName].ToString());
            }
            else
                row.IsPROCESADORA_ID_RED_DINELCONull = true;
            if (campos.Contains(CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_ID_RED_INFONETColumnName))
            {
                if (campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_ID_RED_INFONETColumnName].ToString().Equals(string.Empty))
                    row.IsPROCESADORA_ID_RED_INFONETNull = true;

                row.PROCESADORA_ID_RED_INFONET = decimal.Parse(campos[CuentaCorrienteTarjetasConfiguracionService.Modelo.PROCESADORA_ID_RED_INFONETColumnName].ToString());
            }
            else
                row.IsPROCESADORA_ID_RED_INFONETNull = true;

            if (existeConfiguracion(row.ID, row.POS_ID, row.PROCESADORA_ID, row.ES_TARJETA_CREDITO, insertarNuevo))
            {
                string pos = CuentaCorrientePosService.getPOSNombrePorId(row.POS_ID);
                string procesadora = CuentaCorrienteProcesadorasTarjetaEntidadService.getProcesadoraNombrePorId(row.PROCESADORA_ID);
                string tipotarjeta = row.ES_TARJETA_CREDITO.Equals(Definiciones.SiNo.Si) ? "Crédito" : "Débito";
                string mensaje = "Ya existe una configuración para:\n " +
                                    "\t - POS: " + pos  +"\n " +
                                    "\t - Procesadora: " + procesadora + "\n " +
                                    "\t - Tarjeta: " + tipotarjeta;

                throw new Exception(mensaje);
            }
            if (insertarNuevo)
            {
                sesion.db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.Insert(row);
            }
            else
                sesion.db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.Update(row);

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
                    decimal id = Guardar(campos, sesion, insertarNuevo);
                    sesion.db.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region GetProcesadoraId
        public static decimal GetProcesadoraId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_TARJETAS_CONFIG_PROCESOSRow row = sesion.Db.CTACTE_TARJETAS_CONFIG_PROCESOSCollection.GetByPrimaryKey(id);
                return row.PROCESADORA_ID;
            }
        }
        #endregion GetProcesadoraId

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "ctacte_tarjetas_config_procesos"; }
        }
        
        public class Modelo : CTACTE_TARJETAS_CONFIG_PROCESOSCollection_Base { public Modelo() : base(null) { } }
        public class ModeloVista : CTACTE_TARJETA_CONF_PROC_INF_COMPCollection_Base { public ModeloVista() : base(null) { } }       
       
        #endregion Accesors

        #region existeConfiguracion
        public static bool existeConfiguracion(decimal id,decimal pos_id, decimal procesadora_id, string es_tarjeta_credito, bool nuevo)
        {
            string clausulas = Modelo.POS_IDColumnName + " = " + pos_id ;
             clausulas += " and " + Modelo.PROCESADORA_IDColumnName + " = " + procesadora_id;
             clausulas += " and " + Modelo.ES_TARJETA_CREDITOColumnName + " = '" + es_tarjeta_credito + "'";

            if (!nuevo)
                clausulas += " and " + Modelo.IDColumnName + " != " + id;
            DataTable dt = GetTarjetasConfiguracionDataTable(clausulas);

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        #endregion existeConfiguracion
    }
}
