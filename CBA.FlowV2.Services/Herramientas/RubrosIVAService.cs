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
    public class RubrosIVAService
    {
        #region Getters
        public static DataTable GetRubrosIVADataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.RUBROS_IVACollection.GetAsDataTable(clausula, orden);
            }
        }

        public static DataTable GetRubrosIVAInfoCompleta(string clausula, string orden, bool soloActivos)
        {
            if (clausula.Equals(string.Empty))
                clausula = "1=1";

            using (SessionService sesion = new SessionService())
            {
                string query = string.Empty;
                query += "select ri.*, \n " +
                         " ri." + Modelo.CODIGO_RUBROColumnName + " || ' - ' || ri." + Modelo.DESCRIPCION_RUBROColumnName + " rubro_iva, \n" +
                         " s." + SucursalesService.Nombre_NombreCol + " sucursal_nombre, \n " +
                         " u." + UsuariosService.Usuario_NombreCol + " \n " +
                         " from " + Nombre_Tabla + " ri, \n" +
                         SucursalesService.Nombre_Tabla + " s, \n" +
                         UsuariosService.Nombre_Tabla + " u \n" +
                         " where ri." + Modelo.SUCURSAL_IDColumnName + " = s." + SucursalesService.Id_NombreCol + " \n" +
                         " and ri." + Modelo.USUARIO_IDColumnName + " = u." + UsuariosService.Id_NombreCol + " \n" +                         
                         " and " + clausula;
                if (soloActivos)
                    query += " and ri." + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' \n";
                if (!orden.Equals(string.Empty))
                    query +=  " order by" + orden;

                return sesion.db.EjecutarQuery(query);
            }
        }

        public static DataTable GetRubrosIVABusqueda(string clausula, string orden, bool soloActivos)
        {
            clausula = " (upper(ri." + Modelo.CODIGO_RUBROColumnName + ") like '%" + clausula.ToUpper() + "%' or " +
                       " upper(ri." + Modelo.DESCRIPCION_RUBROColumnName + ") like '%" + clausula.ToUpper() + "%') ";                       
            return GetRubrosIVAInfoCompleta(clausula, orden, soloActivos);            
        }
        #endregion Getters

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    RUBROS_IVARow rubrosIVA = new RUBROS_IVARow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        rubrosIVA.ID = sesion.Db.GetSiguienteSecuencia("rubros_iva_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        rubrosIVA = sesion.Db.RUBROS_IVACollection.GetRow(Modelo.IDColumnName + " = " + decimal.Parse(campos[Modelo.IDColumnName].ToString()));
                        valorAnterior = rubrosIVA.ToString();
                    }

                    rubrosIVA.SUCURSAL_ID = decimal.Parse(campos[Modelo.SUCURSAL_IDColumnName].ToString());
                    rubrosIVA.CODIGO_RUBRO = campos[Modelo.CODIGO_RUBROColumnName].ToString();
                    rubrosIVA.DESCRIPCION_RUBRO = campos[Modelo.DESCRIPCION_RUBROColumnName].ToString();
                    rubrosIVA.PRIORIDAD = decimal.Parse(campos[Modelo.PRIORIDADColumnName].ToString());
                    rubrosIVA.ESTADO = campos[Modelo.ESTADOColumnName].ToString();
                    rubrosIVA.FECHA_CREACION = DateTime.Now;
                    rubrosIVA.USUARIO_ID = sesion.Usuario_Id;

                    if (insertarNuevo) sesion.Db.RUBROS_IVACollection.Insert(rubrosIVA);
                    else sesion.Db.RUBROS_IVACollection.Update(rubrosIVA);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, rubrosIVA.ID, valorAnterior, rubrosIVA.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accesors
        public const string Nombre_Tabla = "RUBROS_IVA";
        public class Modelo : RUBROS_IVACollection_Base { public Modelo() : base(null) { } }
        #endregion Accesors
    }
}
