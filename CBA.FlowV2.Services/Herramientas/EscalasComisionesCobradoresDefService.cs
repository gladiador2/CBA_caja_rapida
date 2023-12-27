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
    public class EscalasComisionesCobradoresDefaultService
    {
        #region GetEscalasComisionesCobradoresDefDataTable
        /// <summary>
        /// Gets the escalas comisiones cobradores data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetEscalasComisionesCobradoresDefDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.ESCALAS_COMISIONES_COBRA_DEFCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetEscalasComisionesCobradoresDefDataTable

        #region TieneRegistros
        public static bool TieneRegistros(decimal anho)
        {
            string clausulas = EscalasComisionesCobradoresDefaultService.Anho_NombreCol + " = " + anho;
            DataTable dt = GetEscalasComisionesCobradoresDefDataTable(clausulas, string.Empty);
            return dt.Rows.Count > 0;
        }
        #endregion TieneRegistros

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

                    ESCALAS_COMISIONES_COBRA_DEFRow row;
                    string valorAnterior;

                    if (campos.Contains(EscalasComisionesCobradoresDefaultService.Id_NombreCol))
                    {
                        row = sesion.Db.ESCALAS_COMISIONES_COBRA_DEFCollection.GetByPrimaryKey((decimal)campos[EscalasComisionesCobradoresDefaultService.Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }
                    else
                    {
                        row = new ESCALAS_COMISIONES_COBRA_DEFRow();
                        row.ID = sesion.Db.GetSiguienteSecuencia("escalas_comision_cobra_def_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }

                    row.ANHO = (decimal)campos[EscalasComisionesCobradoresDefaultService.Anho_NombreCol];
                    row.PORCENTAJE_COMISION = (decimal)campos[EscalasComisionesCobradoresDefaultService.PorcentajeComision_NombreCol];
                    row.PORCENTAJE_HASTA = (decimal)campos[EscalasComisionesCobradoresDefaultService.PorcentajeHasta_NombreCol];

                    if (campos.Contains(EscalasComisionesCobradoresDefaultService.Id_NombreCol))
                        sesion.Db.ESCALAS_COMISIONES_COBRA_DEFCollection.Update(row);
                    else
                        sesion.Db.ESCALAS_COMISIONES_COBRA_DEFCollection.Insert(row);
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
                    ESCALAS_COMISIONES_COBRA_DEFRow row = sesion.Db.ESCALAS_COMISIONES_COBRA_DEFCollection.GetByPrimaryKey(id);

                    sesion.Db.ESCALAS_COMISIONES_COBRA_DEFCollection.Delete(row);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ESCALAS_COMISIONES_COBRA_DEF"; }
        }
        public static string Anho_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRA_DEFCollection.ANHOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRA_DEFCollection.IDColumnName; }
        }
        public static string PorcentajeComision_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRA_DEFCollection.PORCENTAJE_COMISIONColumnName; }
        }
        public static string PorcentajeHasta_NombreCol
        {
            get { return ESCALAS_COMISIONES_COBRA_DEFCollection.PORCENTAJE_HASTAColumnName; }
        }
        #endregion Accessors
    }
}
