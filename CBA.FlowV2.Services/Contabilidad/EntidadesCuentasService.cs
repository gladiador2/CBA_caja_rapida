using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;

namespace CBA.FlowV2.Services.Contabilidad
{
    public class EntidadesCuentasService
    {
        #region GetEntidadesCuentasDataTable
        public static DataTable GetEntidadesCuentasDataTable(String clausulas, String orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String entidad = Modelo.ENTIDAD_IDColumnName + " = " + sesion.Entidad.ID;           

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.CTB_ENTIDADES_CUENTASCollection.GetAsDataTable(clausulas + " and " + entidad, orden);
                }
                else
                {
                    table = sesion.Db.CTB_ENTIDADES_CUENTASCollection.GetAsDataTable(entidad, orden);
                }
                return table;
            }
        }
        #endregion GetEntidadesCuentasDataTable

        #region Guardar
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                return Guardar(campos, insertarNuevo, sesion);
            }
        }

        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            CTB_ENTIDADES_CUENTASRow row = new CTB_ENTIDADES_CUENTASRow();
            string valorAnterior = string.Empty;

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia("CTB_ENTIDADES_CUENTAS_SQC");
                row.REGISTRO_ID = (decimal)campos[EntidadesCuentasService.Modelo.REGISTRO_IDColumnName];
                row.LOG_CAMPOS_ID = decimal.Parse(campos[EntidadesCuentasService.Modelo.LOG_CAMPOS_IDColumnName].ToString());
                row.FECHA_INSERCION = DateTime.Now;
                row.USUARIO_ID_INSERCION = sesion.Usuario_Id;
                valorAnterior = Definiciones.Log.RegistroNuevo;
            }
            else
            {
                row = sesion.Db.CTB_ENTIDADES_CUENTASCollection.GetRow(EntidadesCuentasService.Modelo.IDColumnName + " = " + campos[EntidadesCuentasService.Modelo.IDColumnName]);
                valorAnterior = row.ToString();
            }

            row.CTB_CUENTA_ID = (decimal)campos[EntidadesCuentasService.Modelo.CTB_CUENTA_IDColumnName];
            row.ENTIDAD_ID = sesion.Entidad.ID;
            if (campos.Contains(EntidadesCuentasService.Modelo.TIPOColumnName))
                row.TIPO = campos[EntidadesCuentasService.Modelo.TIPOColumnName].ToString();            

            if (insertarNuevo)
                sesion.Db.CTB_ENTIDADES_CUENTASCollection.Insert(row);
            else
                sesion.Db.CTB_ENTIDADES_CUENTASCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Borrar
        public static void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    CTB_ENTIDADES_CUENTASRow row = new CTB_ENTIDADES_CUENTASRow();

                    row = sesion.Db.CTB_ENTIDADES_CUENTASCollection.GetByPrimaryKey(id);
                    string ctbAsientoAutoDetId = string.Empty;

                    if (row.TIPO == "COSTOS")
                        ctbAsientoAutoDetId = "807";
                    else 
                    if (row.TIPO == "VENTA")
                        ctbAsientoAutoDetId = "804";
                    else 
                    if (row.TIPO == "MERCADERIA")
                        ctbAsientoAutoDetId = "501, 502";                    

                    //Se borra las relaciones si existen
                    DataTable ctbAsientosAutoRelaciones = AsientosAutoRelacionesService.GetAsientosAutoRelacionesDataTable(
                        AsientosAutoRelacionesService.ArticuloId_NombreCol + " = " + row.REGISTRO_ID + " and " + 
                        AsientosAutoRelacionesService.CtbCuentaId_NombreCol + " = " + row.CTB_CUENTA_ID + " and " +
                        AsientosAutoRelacionesService.CtbAsientoAutoDetId_NombreCol + " in (" + ctbAsientoAutoDetId + ")", string.Empty);

                    foreach (DataRow ctbAsientosAutoRelacion in ctbAsientosAutoRelaciones.Rows)
                        AsientosAutoRelacionesService.Borrar((decimal)ctbAsientosAutoRelacion[AsientosAutoRelacionesService.Id_NombreCol]);

                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;
                    sesion.Db.CTB_ENTIDADES_CUENTASCollection.DeleteByPrimaryKey(id);
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
        public const string Nombre_Tabla = "CTB_ENTIDADES_CUENTAS";
        public class Modelo : CTB_ENTIDADES_CUENTASCollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
