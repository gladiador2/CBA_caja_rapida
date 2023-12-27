using System.Data;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using System;
using System.Web;

namespace CBA.FlowV2.Services.Casos
{
    public class EstadosSegunDestinoService
    {
        #region GetUltimoDestino
        /// <summary>
        /// Funcion recursiva que recorre las aceleraciones posibles a partir de una transicion.
        /// </summary>
        /// <param name="flujo_id">The flujo_id.</param>
        /// <param name="estado_actual_id">The estado_actual_id.</param>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>Ultimo estado despues de aplicar las reglas de aceleracion automatica de estados</returns>
        static string GetUltimoEstadoDestinoId(decimal flujo_id, string estado_actual_id, string estado_destino, decimal caso_id, SessionService sesion)
        {
            DataTable estadosDestinoSinAceleracion = GetPosiblesEstadosDestino(flujo_id, estado_actual_id, caso_id, sesion);
            foreach (DataRow dr in estadosDestinoSinAceleracion.Rows) 
            {
                string estadoDestinoAceleradoId = TransicionesAceleradorService.GetEstadoDestinoDeSiguienteTransicion(flujo_id, estado_actual_id, dr[TraeEstadosDestinoSegunPermisos.Id_NombreCol].ToString(), sesion);
                //se toma en cuenta solo una aceleracion
                if (!estadoDestinoAceleradoId.Equals(string.Empty)) {
                    return GetUltimoEstadoDestinoId(flujo_id, estado_destino, estadoDestinoAceleradoId, caso_id, sesion);
                }
            }
            //si no existieron aceleraciones, esta es la ultima aceleracion
            return EstadosFlujosService.GetEstadoAlias(estado_destino);
        }
        #endregion GetUltimoDestino

        #region GetPosiblesEstadosDestino
        public static DataTable GetPosiblesEstadosDestino(decimal flujo_id, string estado_actual_id, decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = null;
                try
                {
                    sesion.BeginTransaction();
                    dt = GetPosiblesEstadosDestino(flujo_id, estado_actual_id, caso_id, sesion);
                    sesion.CommitTransaction();
                }
                catch 
                {
                    sesion.RollbackTransaction();
                    throw;
                }
                return dt;
            }
        }

       
        #endregion GetPosiblesEstadosDestino

        #region GetPosiblesEstadosDestino
        public static DataTable GetPosiblesEstadosDestino(decimal flujo_id, string estado_actual_id, decimal caso_id, SessionService sesion)
        {
            try
            {
                
                DataTable dtNew = new DataTable();

               
                    // SQL para la consulta
                    string sql = "" +
                            " select distinct " +
                            "        e." + TraeEstadosDestinoSegunPermisos.Id_NombreCol + ", " +
                            "        e." + TraeEstadosDestinoSegunPermisos.Alias_NombreCol + ", " +
                            "        e." + TraeEstadosDestinoSegunPermisos.ColorHexadecimal_NombreCol + ", " +
                            "        t." + TraeEstadosDestinoSegunPermisos.SQL_NombreCol + ", " +
                            "        t.orden " +
                            "   from transiciones t, estados e, roles r, usuarios_roles ur " +
                            "  where t.estado_destino_id = e.id " +
                            "    and t.rol_id = r.id " +
                            "    and ur.rol_id = r.id " +
                            "    and t.estado = 'A' " +
                            "    and t.flujo_id = " + flujo_id +
                            "    and t.estado_origen_id = '" + estado_actual_id + "' " +
                            "    and ur.usuario_id = " + sesion.Usuario.ID +
                            " order by t.orden ";

                    DataTable dt = sesion.db.EjecutarQuery(sql);

                    // Agregamos una columna "resultado" donde obtiene el valor "OK" o "NO"
                    dt.Columns.Add("resultado", typeof(string));

                    foreach (DataRow dr in dt.Rows)
                    {
                        //Se reemplazan los parametros
                        string sqlIndividual = dr["sql"].ToString();
                        sqlIndividual = sqlIndividual.Replace("??caso_id??", caso_id.ToString());
                        sqlIndividual = sqlIndividual.Replace("??usuario_id??", HttpContext.Current.Session["usuarioID"].ToString());

                        if (sqlIndividual.Trim().Length > 0)
                        {

                            DataTable dtIndividual = sesion.db.EjecutarQuery(sqlIndividual);

                            dr["resultado"] = dtIndividual.Rows[0]["resultado"].ToString();
                            
                        }
                        else
                        {
                            dr["resultado"] = "OK";
                        }
                    }

                    dtNew = dt.Clone();

                    // se recorre para cargar solamente los que tiene OK en resultado
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["resultado"].ToString() == "OK")
                        {
                            dtNew.ImportRow(dr);
                        }
                    }
                    
                
                if (dtNew.Rows.Count > 0)
                {
                    string blancoHex = "FFFFFF";
                    dtNew.Rows.Add(estado_actual_id, estado_actual_id, blancoHex, "SQL", DBNull.Value, "OK");
                }
                return dtNew;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion GetPosiblesEstadosDestino

        public class TraeEstadosDestinoSegunPermisos 
        {


            #region Accessors
            public static string Id_NombreCol
            {
                get { return "ID"; }
            }
            public static string Alias_NombreCol
            {
                get { return "ALIAS"; }
            }
            public static string ColorHexadecimal_NombreCol
            {
                get { return "COLOR_HEXADECIMAL"; }
            }
            public static string SQL_NombreCol
            {
                get { return "SQL"; }
            }
            #endregion Accessors
        }
    }
}
