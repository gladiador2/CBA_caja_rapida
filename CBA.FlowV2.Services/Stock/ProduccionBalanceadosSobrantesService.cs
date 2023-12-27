﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Stock
{
    public class ProduccionBalanceadosSobrantesService
    {
        #region GetProduccionBalanceadosSobrantesDataTable
        public static DataTable GetProduccionBalanceadosSobrantesDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PROD_BALAN_SOBRANTESCollection.GetAsDataTable(clausula, orden);
            }
        }
        #endregion GetProduccionBalanceadosSobrantesDataTable

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = Guardar(campos, insertarNuevo, sesion);
                    sesion.CommitTransaction();
                    return id;
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            if (!campos.Contains(ProduccionBalanceadosSobrantesService.Modelo.ARTICULO_IDColumnName))
                throw new Exception("Debe indicar el artículo.");
            if (!campos.Contains(ProduccionBalanceadosSobrantesService.Modelo.LOTE_IDColumnName))
                throw new Exception("Debe indicar el lote.");

            PROD_BALAN_SOBRANTESRow row = new PROD_BALAN_SOBRANTESRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("PROD_BALAN_SOBRANTES_SQC");
                row.PROD_BALAN_ID = (decimal)campos[ProduccionBalanceadosSobrantesService.Modelo.PROD_BALAN_IDColumnName];
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.PROD_BALAN_SOBRANTESCollection.GetRow(ProduccionBalanceadosSobrantesService.Modelo.IDColumnName + " = " + campos[ProduccionBalanceadosSobrantesService.Modelo.IDColumnName]);
                valorAnterior = row.ToString();
            }

            row.ARTICULO_ID = (decimal)campos[ProduccionBalanceadosSobrantesService.Modelo.ARTICULO_IDColumnName];
            row.LOTE_ID = (decimal)campos[ProduccionBalanceadosSobrantesService.Modelo.LOTE_IDColumnName];
            row.CANTIDAD = (decimal)campos[ProduccionBalanceadosSobrantesService.Modelo.CANTIDADColumnName];
            row.UNIDAD_MEDIDA_ID = campos[ProduccionBalanceadosSobrantesService.Modelo.UNIDAD_MEDIDA_IDColumnName].ToString();
            row.OBSERVACION = campos[ProduccionBalanceadosSobrantesService.Modelo.OBSERVACIONColumnName].ToString();
            
            if (insertarNuevo)
                sesion.Db.PROD_BALAN_SOBRANTESCollection.Insert(row);
            else
                sesion.Db.PROD_BALAN_SOBRANTESCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal sobrante_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    PROD_BALAN_SOBRANTESRow row = new PROD_BALAN_SOBRANTESRow();
                    row = sesion.Db.PROD_BALAN_SOBRANTESCollection.GetByPrimaryKey(sobrante_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;

                    sesion.Db.PROD_BALAN_SOBRANTESCollection.DeleteByPrimaryKey(sobrante_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }
        #endregion Borrar

        #region Accesors
        public const string Nombre_Tabla = "PROD_BALAN_SOBRANTES";
        public class Modelo : PROD_BALAN_SOBRANTESCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
