using System;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using System.Collections;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Db;
using System.Text;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EstadosFlujosService
    {
        #region GetEstadoAlias
        public static string GetEstadoAlias(string estado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ESTADOSRow estado = sesion.Db.ESTADOSCollection.GetByPrimaryKey(estado_id);
                return estado.ALIAS;
            }
        }
        #endregion GetEstadoAlias

        #region GetEstadosAsDataTable
        [Obsolete("utilizar metodos estaticos")]
        /// <summary>
        /// Gets the estados as data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetEstadosAsDataTable()
        {
            return this.GetEstadosAsDataTable("", EstadosFlujosService.Alias_NombreCol);
        }

        /// <summary>
        /// Gets the estados as data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEstadosAsDataTableStatic()
        {
            return GetEstadosAsDataTableStatic("", EstadosFlujosService.Alias_NombreCol);
        }

        [Obsolete("utilizar metodos estaticos")]
        /// <summary>
        /// Gets the estados as data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetEstadosAsDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ESTADOSCollection.GetAsDataTable(clausulas, orden);
            }
        }

        /// <summary>
        /// Gets the estados as data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEstadosAsDataTableStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ESTADOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        public static DataTable GetEstadosPorFlujo(decimal flujo_id)
        {
            string subs1 = string.Format("select distinct t.estado_origen_id {1} from transiciones t where t.flujo_id = {0}", flujo_id, Id_NombreCol);
            string subs2 = string.Format("select distinct t.estado_destino_id {1} from transiciones t where t.flujo_id = {0}", flujo_id, Id_NombreCol);
            string union = string.Format("({0}) union ({1})", subs1, subs2);
            string where = string.Format("{0} in ({1})", Id_NombreCol, union);

            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ESTADOSCollection.GetAsDataTable(where,Id_NombreCol);
            }
        }
        
        #endregion GetEstadosAsDataTable

        #region GetEstadosPorFlujoAsDataTable
        [Obsolete("utilizar metodos estaticos")]
        /// <summary>
        /// Gets the estados por flujo as data table.
        /// </summary>
        /// <param name="flujoId">The flujo id.</param>
        /// <returns></returns>
        public DataTable GetEstadosPorFlujoAsDataTable(decimal flujoId)
        {
            return this.GetEstadosPorFlujoAsDataTable(flujoId, false);
        }

        /// <summary>
        /// Gets the estados por flujo as data table.
        /// </summary>
        /// <param name="flujoId">The flujo id.</param>
        /// <returns></returns>
        public static DataTable GetEstadosPorFlujoAsDataTableStatic(decimal flujoId)
        {
            return GetEstadosPorFlujoAsDataTableStatic(flujoId, false);
        }



        [Obsolete("utilizar metodos estaticos")]
        /// <summary>
        /// Gets the estados por flujo as data table.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="incluirCampoTodos">if set to <c>true</c> [incluir campo todos].</param>
        /// <returns></returns>
        public DataTable GetEstadosPorFlujoAsDataTable(decimal flujo_id, bool incluirCampoTodos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table; //datatable que se retornara con el resultado
                Hashtable estados = new Hashtable(); //lista de id de los estados seleccionados
                DataTable transiciones;

                //Se obtienen los estados
                table = this.GetEstadosAsDataTable();

                //Se obtienen las transiciones relevantes
                transiciones = (new TransicionesService()).GetTransicionesDataTable(flujo_id);

                //Se cargan los estados participantes de las transiciones
                for (int i = transiciones.Rows.Count - 1; i >= 0; i--)
                {
                    //Si el estado todavia no esta en el hashtable, se agrega
                    if (!estados.Contains(transiciones.Rows[i][TransicionesService.EstadoOrigenId_NombreCol]))
                        estados.Add(transiciones.Rows[i][TransicionesService.EstadoOrigenId_NombreCol], "");
                    if (!estados.Contains(transiciones.Rows[i][TransicionesService.EstadoDestinoId_NombreCol]))
                        estados.Add(transiciones.Rows[i][TransicionesService.EstadoDestinoId_NombreCol], "");
                }

                //Se quita del DataTable de estados aquellos no participantes de las transiciones
                for (int i = table.Rows.Count - 1; i >= 0; i--)
                {
                    if (!estados.Contains(table.Rows[i]["id"]))
                        table.Rows[i].Delete();
                } 
                
                if (incluirCampoTodos)
                {
                    DataRow row = table.NewRow();
                    row[EstadosFlujosService.Id_NombreCol] = Definiciones.IdNull.ToString();
                    row[EstadosFlujosService.Alias_NombreCol] = "Todos";
                    row[EstadosFlujosService.Descripcion_NombreCol] = "Todos los roles";
                    table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }

        /// <summary>
        /// Gets the estados por flujo as data table.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="incluirCampoTodos">if set to <c>true</c> [incluir campo todos].</param>
        /// <returns></returns>
        public static DataTable GetEstadosPorFlujoAsDataTableStatic(decimal flujo_id, bool incluirCampoTodos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table; //datatable que se retornara con el resultado
                Hashtable estados = new Hashtable(); //lista de id de los estados seleccionados
                DataTable transiciones;

                //Se obtienen los estados
                table = GetEstadosAsDataTableStatic();

                //Se obtienen las transiciones relevantes
                transiciones = (new TransicionesService()).GetTransicionesDataTable(flujo_id);

                //Se cargan los estados participantes de las transiciones
                for (int i = transiciones.Rows.Count - 1; i >= 0; i--)
                {
                    //Si el estado todavia no esta en el hashtable, se agrega
                    if (!estados.Contains(transiciones.Rows[i][TransicionesService.EstadoOrigenId_NombreCol]))
                        estados.Add(transiciones.Rows[i][TransicionesService.EstadoOrigenId_NombreCol], "");
                    if (!estados.Contains(transiciones.Rows[i][TransicionesService.EstadoDestinoId_NombreCol]))
                        estados.Add(transiciones.Rows[i][TransicionesService.EstadoDestinoId_NombreCol], "");
                }

                //Se quita del DataTable de estados aquellos no participantes de las transiciones
                for (int i = table.Rows.Count - 1; i >= 0; i--)
                {
                    if (!estados.Contains(table.Rows[i]["id"]))
                        table.Rows[i].Delete();
                }

                if (incluirCampoTodos)
                {
                    DataRow row = table.NewRow();
                    row[EstadosFlujosService.Id_NombreCol] = Definiciones.IdNull.ToString();
                    row[EstadosFlujosService.Alias_NombreCol] = "Todos";
                    row[EstadosFlujosService.Descripcion_NombreCol] = "Todos los roles";
                    table.Rows.InsertAt(row, 0);
                }

                return table;
            }
        }

        #endregion GetEstadosPorFlujoAsDataTable

        #region Accessors
        public static string Alias_NombreCol
        {
            get { return ESTADOSCollection.ALIASColumnName; }
        }
        public static string ColorHexadecimal_NombreCol
        {
            get { return ESTADOSCollection.COLOR_HEXADECIMALColumnName; }
        }
        public static string Descripcion_NombreCol
        {
            get { return ESTADOSCollection.DESCRIPCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ESTADOSCollection.IDColumnName; }
        }
        #endregion Accessors
    }
}
