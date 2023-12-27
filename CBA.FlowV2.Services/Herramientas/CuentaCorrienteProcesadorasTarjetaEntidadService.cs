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
    public class CuentaCorrienteProcesadorasTarjetaEntidadService
    {
        #region GetProcesadorasEntidad
        public static DataTable GetProcesadorasEntidad(string clausulas, string order, bool soloActivo)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;
                if (soloActivo)
                {
                    clausulas += clausulas.Equals(string.Empty) ? string.Empty : " and ";
                    clausulas += CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
                }
                dt = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetAsDataTable(clausulas, order);
                return dt;
            }
        }
        #endregion GetProcesadorasEntidad

        #region getProcesadoraNombre
        public static string getProcesadoraNombrePorId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PROCESADORAS_TARJETA_ENTIDADRow row = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetByPrimaryKey(id);
                return row.NOMBRE;
            }
        }
        #endregion getProcesadoraNombre

        #region EsProcesoPosDia
        public static bool EsProcesoPosDia(decimal vIdProcesadora, bool esCredito)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = sesion.Db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetAsDataTable(Modelo.IDColumnName + " = " + vIdProcesadora, string.Empty);

                if (esCredito)
                    return dt.Rows[0][Modelo.CRED_COMISION_POS_DIAColumnName].ToString().Equals(Definiciones.SiNo.Si);
                else
                    return dt.Rows[0][Modelo.DEB_COMISION_POS_DIAColumnName].ToString().Equals(Definiciones.SiNo.Si);
            }
        }
        #endregion EsProcesoPosDia

        #region Guardar
        public static decimal Guardar(Hashtable campos, SessionService sesion, bool insertarNuevo)
        {
            CTACTE_PROCESADORAS_TARJETA_ENTIDADRow row = new CTACTE_PROCESADORAS_TARJETA_ENTIDADRow();
            string valorAnterior = string.Empty;
            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("ctacte_procesadora_tarj_entidad_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.GetByPrimaryKey(decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.IDColumnName].ToString()));
                valorAnterior = row.ToString();
            }
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.ABREVIATURAColumnName))
                row.ABREVIATURA = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.ABREVIATURAColumnName].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.NOMBREColumnName))
                row.NOMBRE = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.NOMBREColumnName].ToString();            
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_COMISION_POS_DIAColumnName))
                row.CRED_COMISION_POS_DIA = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_COMISION_POS_DIAColumnName].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_COMISION_SOB_IMP_BRUTOColumnName))
                row.CRED_COMISION_SOB_IMP_BRUTO = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_COMISION_SOB_IMP_BRUTOColumnName].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_COMISION_POS_DIAColumnName))
                row.DEB_COMISION_POS_DIA = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_COMISION_POS_DIAColumnName].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_COMISION_SOB_IMP_BRUTOColumnName))
                row.DEB_COMISION_SOB_IMP_BRUTO = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_COMISION_SOB_IMP_BRUTOColumnName].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.ESTADOColumnName))
                row.ESTADO = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.ESTADOColumnName].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_LUNES_HORASColumnName))
                row.DEB_LUNES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_LUNES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_MARTES_HORASColumnName))
                row.DEB_MARTES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_MARTES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_MIERCOLES_HORASColumnName))
                row.DEB_MIERCOLES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_MIERCOLES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_JUEVES_HORASColumnName))
                row.DEB_JUEVES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_JUEVES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_VIERNES_HORASColumnName))
                row.DEB_VIERNES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_VIERNES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_SABADO_HORASColumnName))
                row.DEB_SABADO_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_SABADO_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_DOMINGO_HORASColumnName))
                row.DEB_DOMINGO_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.DEB_DOMINGO_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_LUNES_HORASColumnName))
                row.CRED_LUNES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_LUNES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_MARTES_HORASColumnName))
                row.CRED_MARTES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_MARTES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_MIERCOLES_HORASColumnName))
                row.CRED_MIERCOLES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_MIERCOLES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_JUEVES_HORASColumnName))
                row.CRED_JUEVES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_JUEVES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_VIERNES_HORASColumnName))
                row.CRED_VIERNES_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_VIERNES_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_SABADO_HORASColumnName))
                row.CRED_SABADO_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_SABADO_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_DOMINGO_HORASColumnName))
                row.CRED_DOMINGO_HORAS = decimal.Parse(campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CRED_DOMINGO_HORASColumnName].ToString());
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CONTROLA_DIA_HABILColumnName))
                row.CONTROLA_DIA_HABIL = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CONTROLA_DIA_HABILColumnName].ToString();
            if (campos.Contains(CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CONTROLA_FERIADO_BANCARIOColumnName))
                row.CONTROLA_FERIADO_BANCARIO = campos[CuentaCorrienteProcesadorasTarjetaEntidadService.Modelo.CONTROLA_FERIADO_BANCARIOColumnName].ToString();

            if (insertarNuevo)            
                sesion.db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.Insert(row);            
            else
                sesion.db.CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection.Update(row);

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

        #region Accesors
        public const string Nombre_Tabla = "CTACTE_PROCESADORAS_TARJETA_ENTIDAD";
        public class Modelo : CTACTE_PROCESADORAS_TARJETA_ENTIDADCollection_Base { public Modelo() : base(null) { } }       
        #endregion Accesors
    }
}
