using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.RecursosHumanos
{
    public class AsignacionCargosDetalleService
    {
        #region Getters
        /// <summary>
        /// Gets the asignacion cargos detalle row.
        /// </summary>
        /// <param name="asignacion_cargos_detalle_id">The asignacion_cargos_detalle_id.</param>
        /// <returns></returns>
        public DataRow GetAsignacionCargosDetalleRow(decimal asignacion_cargos_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table= new DataTable();
               
                return table.Rows[0];
            }
        }

        /// <summary>
        /// Gets the asignacion cargos detalle.
        /// </summary>
        /// <param name="asignacion_cargos_id">The asignacion_cargos_id.</param>
        /// <returns></returns>
        public DataTable GetAsignacionCargosDetalle(decimal asignacion_cargos_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = new DataTable();    
                return table;
            }
        }

        #endregion Getters

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="asignacion_cargos_id">The asignacion_cargos_id.</param>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(decimal asignacion_cargos_id, System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    ASIGNACIONES_CARGOS_DETALLERow row = new ASIGNACIONES_CARGOS_DETALLERow();
                    
                    ASIGNACIONES_CARGOSRow cabeceraRow;
                    CasosService caso = new CasosService();
                    CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();

                    decimal decimalAux;
                    String valorAnterior = "";

                    if (insertarNuevo)
                    {
                        sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("asignaciones_cargos_detal_sqc");
                        row.ASIGNACIONES_CARGOS_ID = decimal.Parse(campos["ASIGNACIONES_CARGOS_ID"].ToString());
                        row.ENTIDAD_ID = sesion.Usuario.ENTIDAD_ID;

                        
                        sesion.Db.CommitTransaction();
                    }
                    else
                    {
                        row = sesion.Db.ASIGNACIONES_CARGOS_DETALLECollection.GetRow(" id = " + decimal.Parse(campos["ID"].ToString()));
                        
                        valorAnterior = row.ToString();
                    }

                    cabeceraRow = sesion.Db.ASIGNACIONES_CARGOSCollection.GetByPrimaryKey(row.ASIGNACIONES_CARGOS_ID);

                    //Si cambia el cargo, se controla que el nuevo se encuentre activo
                    decimalAux = decimal.Parse(campos["EMPRESA_CARGO_ID"].ToString());
                    if (row.EMPRESA_CARGO_ID.Equals(decimalAux))
                    {
                        if (!EmpresaCargosService.EstaActivo(decimalAux))
                            throw new System.Exception("El cargo se encuentra inactivo.");
                    }
                    row.EMPRESA_CARGO_ID = decimalAux;

                    if (campos.Contains("SUCURSAL_ID"))
                    {
                        //Si cambia la sucursal, se controla que la nueva se encuentre activo
                        decimalAux = decimal.Parse(campos["SUCURSAL_ID"].ToString());
                        if (row.IsSUCURSAL_IDNull || row.SUCURSAL_ID.Equals(decimalAux))
                        {
                            if (!SucursalesService.EstaActivo(decimalAux))
                                throw new System.Exception("La sede se encuentra inactiva.");
                        }
                        row.SUCURSAL_ID = decimalAux;
                    }
                    else row.IsSUCURSAL_IDNull = true;

                   

                    //Si cambia el funcionario, se controla que el nuevo se encuentre activo
                    decimalAux = decimal.Parse(campos["FUNCIONARIO_ID"].ToString());
                    if (row.FUNCIONARIO_ID.Equals(decimalAux))
                    {
                        if (!FuncionariosService.EstaActivo(decimalAux))
                            throw new System.Exception("El funcionario se encuentra inactivo.");
                    }
                    row.FUNCIONARIO_ID = decimalAux;


                    sesion.Db.BeginTransaction(); //Si se iniciaba una sola vez, no actualizaba todos los registros

                    if (insertarNuevo)
                    {
                        sesion.Db.ASIGNACIONES_CARGOS_DETALLECollection.Insert(row);
                     
                    }
                    else
                    {
                        sesion.Db.ASIGNACIONES_CARGOS_DETALLECollection.Update(row);
                        
                    }
                    LogCambiosService.LogDeRegistro("asignaciones_cargos_detalle", row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("El caso ya contiene un detalle con el detalle indicado.");
                        default:
                            throw exp;
                    }
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified asignacion_cargos_detalle_id.
        /// </summary>
        /// <param name="asignacion_cargos_detalle_id">The asignacion_cargos_detalle_id.</param>
        public void Borrar(decimal asignacion_cargos_detalle_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    CasosService caso = new CasosService();
                    ASIGNACIONES_CARGOS_DETALLERow row = sesion.Db.ASIGNACIONES_CARGOS_DETALLECollection.GetByPrimaryKey(asignacion_cargos_detalle_id);
                    
                    ASIGNACIONES_CARGOSRow cabeceraRow = sesion.Db.ASIGNACIONES_CARGOSCollection.GetByPrimaryKey(row.ASIGNACIONES_CARGOS_ID);
                    CambioEstadoCasoService cambioEstado = new CambioEstadoCasoService();

                    sesion.Db.BeginTransaction();

                    sesion.Db.ASIGNACIONES_CARGOS_DETALLECollection.Delete(row);
                   
                    LogCambiosService.LogDeRegistro("asignaciones_cargos_detalle", row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar
    }
}
