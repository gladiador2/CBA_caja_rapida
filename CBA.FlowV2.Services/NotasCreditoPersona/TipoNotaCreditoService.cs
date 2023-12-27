using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Collections.Generic;

namespace CBA.FlowV2.Services.Herramientas
{
    public class TipoNotaCreditoService
    {
        #region Propiedades privadas
        static List<int> tiposAfectanStockComplejo = new List<int>
        {
            Definiciones.TiposNotasCredito.CambioTitular,
            Definiciones.TiposNotasCredito.DesperfectoMercaderia,
            Definiciones.TiposNotasCredito.ReconocimientoGarantia,
            Definiciones.TiposNotasCredito.RecuperoMercaderia
        };

        static List<int> tiposAfectanStockSimple = new List<int>
        {
            Definiciones.TiposNotasCredito.CambioMercaderia,
            Definiciones.TiposNotasCredito.DevolucionMercaderia,
            Definiciones.TiposNotasCredito.ErrorChassis,
            Definiciones.TiposNotasCredito.ErrorFacturacion,
            Definiciones.TiposNotasCredito.EstandarCBA,
            Definiciones.TiposNotasCredito.ExtravioDocumento,
        };
        #endregion Propiedades privadas

        public static string GetPrefijo(decimal tipo_nc)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.TIPOS_NOTAS_CREDITOCollection.GetByPrimaryKey(tipo_nc).PREFIJO;
            }
        }

        #region GetTiposNotasCreditoDataTable
        /// <summary>
        /// Gets the tipoNotasCredito data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTiposNotasCreditoDataTable(bool soloActivos)
        {
            return GetTiposNotasCreditoDataTable(string.Empty, "upper(" + Descripcion_ColumnName + ")", soloActivos);
        }

        /// <summary>
        /// Gets the tipoNotasCredito data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetTiposNotasCreditoDataTable(string clausulas, string orden, bool estado) 
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                if (estado)
                {
                    if (clausulas.Length > 0)
                    {
                        clausulas += " and ";
                    }
                    clausulas += TipoNotaCreditoService.EstadoColumnName + "='" + Definiciones.Estado.Activo+"'";

                }



                table = sesion.Db.TIPOS_NOTAS_CREDITOCollection.GetAsDataTable(clausulas, orden);
              
                return table;
            }
        }

        #endregion GetTipoClientesDataTable

        #region AfectaStockComplejo
        public static bool AfectaStockComplejo(int tipo_nota_credito)
        {
            return tiposAfectanStockComplejo.Contains(tipo_nota_credito);
        }
        #endregion AfectaStockComplejo

        #region AfectaStockSimple
        public static bool AfectaStockSimple(int tipo_nota_credito)
        {
            return tiposAfectanStockSimple.Contains(tipo_nota_credito);
        }
        #endregion AfectaStockSimple

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_NOTAS_CREDITO"; }
        }
        public static string Id_ColumnName
        {
            get { return TIPOS_NOTAS_CREDITOCollection.IDColumnName; }
        }
        public static string Prefijo_ColumnName
        {
            get { return TIPOS_NOTAS_CREDITOCollection.PREFIJOColumnName; }
        }
        public static string Descripcion_ColumnName
        {
            get { return TIPOS_NOTAS_CREDITOCollection.DESCRIPCIONColumnName; }
        }
        public static string RolId_ColumnName
        {
            get { return TIPOS_NOTAS_CREDITOCollection.ROL_IDColumnName; }
        }
        public static string DiasDesdeFactura_ColumnName
        {
            get { return TIPOS_NOTAS_CREDITOCollection.DIAS_DESDE_FACTURAColumnName; }
        }
        public static string EstadoColumnName
        {
            get { return TIPOS_NOTAS_CREDITOCollection.ESTADOColumnName; }
        }
        #endregion Accessors
    }
}
