using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Collections;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EscalasComisionesCobradoresService
    {
        #region GetEscalasComisionesCobradoresDataTable
        /// <summary>
        /// Gets the escalas comisiones cobradores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEscalasComisionesCobradoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ESCALAS_COMISIONES_COBRADORESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetEscalasComisionesCobradoresDataTable

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ESCALAS_COMISIONES_COBRADORES"; }
        }
        public static string Anho_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRADORESCollection.ANHOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRADORESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRADORESCollection.IDColumnName; }
        }
        public static string PorcentajeComision_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRADORESCollection.PORCENTAJE_COMISIONColumnName; }
        }
        public static string PorcentajeHasta_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRADORESCollection.PORCENTAJE_HASTAColumnName; }
        }
        #endregion Accessors

        #region Guardar

        /// <summary>
        /// Guardars the specified campos_detalle.
        /// </summary>
        /// <param name="campos_detalle">The campos_detalle.</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    ESCALAS_COMISIONES_COBRADORESRow row;
                    string valorAnterior;

                    if (campos.Contains(EscalasComisionesCobradoresService.Id_NombreCol))
                    {
                        row = sesion.Db.ESCALAS_COMISIONES_COBRADORESCollection.GetByPrimaryKey((decimal)campos[EscalasComisionesCobradoresService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new ESCALAS_COMISIONES_COBRADORESRow();
                        row.ID = sesion.Db.GetSiguienteSecuencia("escalas_comisiones_cobra_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }

                    row.ANHO = (decimal)campos[EscalasComisionesCobradoresService.Anho_NombreCol];
                    row.FUNCIONARIO_ID = (decimal)campos[EscalasComisionesCobradoresService.FuncionarioId_NombreCol];
                    row.PORCENTAJE_COMISION = (decimal)campos[EscalasComisionesCobradoresService.PorcentajeComision_NombreCol];
                    row.PORCENTAJE_HASTA = (decimal)campos[EscalasComisionesCobradoresService.PorcentajeHasta_NombreCol];

                    if (campos.Contains(EscalasComisionesCobradoresService.Id_NombreCol))
                        sesion.Db.ESCALAS_COMISIONES_COBRADORESCollection.Update(row);
                    else
                        sesion.Db.ESCALAS_COMISIONES_COBRADORESCollection.Insert(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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

        #region Borrar
        /// <summary>
        /// Borrars the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public static void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    ESCALAS_COMISIONES_COBRADORESRow row = sesion.Db.ESCALAS_COMISIONES_COBRADORESCollection.GetByPrimaryKey(id);

                    sesion.Db.ESCALAS_COMISIONES_COBRADORESCollection.Delete(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

    }
}
