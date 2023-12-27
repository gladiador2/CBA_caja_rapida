using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EmpresaFajasService
    {
        #region getters
        public static DataTable GetFajasDatable(string where, string orderBy)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.EMPRESA_FAJASCollection.GetAsDataTable(where, orderBy);
            }
        }
        #endregion getters

        #region Guardar
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    EMPRESA_FAJASRow row = new EMPRESA_FAJASRow();
                    String valorAnterior = "";

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("empresa_fajas_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.EMPRESA_FAJASCollection.GetRow(Id_NombreCol + " = " + decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();                    
                    row.ESTADO = campos[Estado_NombreCol].ToString();

                    if (insertarNuevo) sesion.Db.EMPRESA_FAJASCollection.Insert(row);
                    else sesion.Db.EMPRESA_FAJASCollection.Update(row);

                    LogCambiosService.LogDeRegistro("empresa_fajas", row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "EMPRESA_FAJAS"; }
        }
        public static string Id_NombreCol
        {
            get { return EMPRESA_FAJASCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return EMPRESA_FAJASCollection.NOMBREColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return EMPRESA_FAJASCollection.ESTADOColumnName; }
        }
        #endregion Accessors
    }
}
