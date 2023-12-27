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
    public class ObjetivosCobradoresService
    {
        #region GetObjetivosCobradoresDataTable
        /// <summary>
        /// Gets the alarmas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetObjetivosCobradoresDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.OBJETIVOS_COBRADORESCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetObjetivosCobradoresDataTable

        #region GetObjetivosCobradoresInfoCompleta
        /// <summary>
        /// Gets the objetivos cobradores info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetObjetivosCobradoresInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.OBJETIVOS_COBRADORES_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetObjetivosCobradoresInfoCompleta

        #region GenerarObjetivos
        public static void GenerarObjetivos(decimal anho, decimal monedaId)
        {
            string clausulas = FuncionariosService.EsCobrador_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
            DataTable dtFuncionarios = FuncionariosService.GetFuncionariosDataTable2(clausulas, string.Empty, true);
            foreach(DataRow row in dtFuncionarios.Rows)
            {
                clausulas = ObjetivosCobradoresService.Anho_NombreCol + " = " + anho +
                    " and " + ObjetivosCobradoresService.FuncionarioId_NombreCol + " = " + row[FuncionariosService.Id_NombreCol].ToString();
                DataTable dt = ObjetivosCobradoresService.GetObjetivosCobradoresDataTable(clausulas, string.Empty);

                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                campos.Add(ObjetivosCobradoresService.Anho_NombreCol, anho);
                campos.Add(ObjetivosCobradoresService.FuncionarioId_NombreCol, row[FuncionariosService.Id_NombreCol]);
                campos.Add(ObjetivosCobradoresService.MonedaId_NombreCol, monedaId);
                if (dt.Rows.Count == 0)
                {
                    campos.Add(ObjetivosCobradoresService.MontoObjetivo_NombreCol, (decimal)0);
                    campos.Add(ObjetivosCobradoresService.MontoTope_NombreCol, (decimal)0);
                }
                else
                {
                    campos.Add(ObjetivosCobradoresService.MontoObjetivo_NombreCol, (decimal)dt.Rows[0][ObjetivosCobradoresService.MontoObjetivo_NombreCol]);
                    campos.Add(ObjetivosCobradoresService.MontoTope_NombreCol, (decimal)dt.Rows[0][ObjetivosCobradoresService.MontoTope_NombreCol]);
                }
                Guardar(campos, dt.Rows.Count == 0);
            }
        }
        #endregion GenerarObjetivos

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                OBJETIVOS_COBRADORESRow row = new OBJETIVOS_COBRADORESRow();
                try
                {
                    sesion.Db.BeginTransaction();

                    string valorAnterior = string.Empty;
                    if (insertarNuevo)
                    {
                        row.ANHO = (decimal)campos[ObjetivosCobradoresService.Anho_NombreCol];
                        row.FUNCIONARIO_ID = (decimal)campos[ObjetivosCobradoresService.FuncionarioId_NombreCol];

                        row.MONEDA_ID = (decimal)campos[ObjetivosCobradoresService.MonedaId_NombreCol];
                        row.MONTO_OBJETIVO = (decimal)campos[ObjetivosCobradoresService.MontoObjetivo_NombreCol];
                        row.MONTO_TOPE = (decimal)campos[ObjetivosCobradoresService.MontoTope_NombreCol];

                        string clausulas = EscalasComisionesCobradoresDefaultService.Anho_NombreCol + " = " + row.ANHO;
                        DataTable dt = EscalasComisionesCobradoresDefaultService.GetEscalasComisionesCobradoresDefDataTable(clausulas, EscalasComisionesCobradoresDefaultService.PorcentajeHasta_NombreCol);

                        foreach (DataRow r in dt.Rows)
                        {
                            System.Collections.Hashtable campos2 = new System.Collections.Hashtable();
                            campos2.Add(EscalasComisionesCobradoresService.PorcentajeHasta_NombreCol, r[EscalasComisionesCobradoresDefaultService.PorcentajeHasta_NombreCol]);
                            campos2.Add(EscalasComisionesCobradoresService.PorcentajeComision_NombreCol, r[EscalasComisionesCobradoresDefaultService.PorcentajeComision_NombreCol]);
                            campos2.Add(EscalasComisionesCobradoresService.Anho_NombreCol, r[EscalasComisionesCobradoresDefaultService.Anho_NombreCol]);
                            campos2.Add(EscalasComisionesCobradoresService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);

                            EscalasComisionesCobradoresService.Guardar(campos2);
                        }

                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.OBJETIVOS_COBRADORESCollection.GetByPrimaryKey((decimal)campos[ObjetivosCobradoresService.FuncionarioId_NombreCol], (decimal)campos[ObjetivosCobradoresService.Anho_NombreCol]);
                        valorAnterior = row.ToString();

                        if (row.MONEDA_ID != (decimal)campos[ObjetivosCobradoresService.MonedaId_NombreCol])
                        {
                            decimal cotizacionVieja = CotizacionesService.GetCotizacionMonedaVenta(row.MONEDA_ID);
                            decimal cotizacionNueva = CotizacionesService.GetCotizacionMonedaVenta((decimal)campos[ObjetivosCobradoresService.MonedaId_NombreCol]);

                            row.MONTO_OBJETIVO = (row.MONTO_OBJETIVO / cotizacionVieja) * cotizacionNueva;
                            row.MONTO_TOPE = (row.MONTO_TOPE / cotizacionVieja) * cotizacionNueva;
                        }
                        else
                        {
                            row.MONTO_OBJETIVO = (decimal)campos[ObjetivosCobradoresService.MontoObjetivo_NombreCol];
                            row.MONTO_TOPE = (decimal)campos[ObjetivosCobradoresService.MontoTope_NombreCol];
                        }
                        row.MONEDA_ID = (decimal)campos[ObjetivosCobradoresService.MonedaId_NombreCol];
                    }

                    if (insertarNuevo) sesion.Db.OBJETIVOS_COBRADORESCollection.Insert(row);
                    else sesion.Db.OBJETIVOS_COBRADORESCollection.Update(row);
                    
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.FUNCIONARIO_ID, valorAnterior, row.ToString(), sesion);

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

        #region ConvertirADolares
        static decimal ConvertirADolares(decimal monto, decimal monedaId)
        {
            return monto / CotizacionesService.GetCotizacionMonedaVenta(monedaId);
        }
        #endregion ConvertirADolares

        #region ObtenerComisionDolares
        public static decimal ObtenerComisionDolares(decimal funcionario_id, decimal anho, decimal monto, decimal monedaId)
        {
            using (SessionService sesion = new SessionService())
            {
                OBJETIVOS_COBRADORESRow rowObjetivo = sesion.Db.OBJETIVOS_COBRADORESCollection.GetByPrimaryKey(funcionario_id, anho);
                string clausulas = EscalasComisionesCobradoresService.FuncionarioId_NombreCol + " = " + funcionario_id +
                    " and " + EscalasComisionesCobradoresService.Anho_NombreCol + " = " + anho;
                DataTable dtEscala = EscalasComisionesCobradoresService.GetEscalasComisionesCobradoresDataTable(clausulas, EscalasComisionesCobradoresService.PorcentajeHasta_NombreCol + " desc");

                if (rowObjetivo == null || rowObjetivo.MONTO_OBJETIVO == 0) return 0;

                decimal montoDolares = ConvertirADolares(monto, monedaId);
                decimal montoObjetivoDolares = ConvertirADolares(rowObjetivo.MONTO_OBJETIVO, rowObjetivo.MONEDA_ID);
                decimal montoTopeDolares = ConvertirADolares(rowObjetivo.MONTO_TOPE, rowObjetivo.MONEDA_ID);

                decimal porcentajeDeObjetivo = (montoDolares * 100) / montoObjetivoDolares;
                
                foreach (DataRow row in dtEscala.Rows)
                {
                    if (porcentajeDeObjetivo >= (decimal)row[EscalasComisionesCobradoresService.PorcentajeHasta_NombreCol])
                    {
                        decimal porcentaje = (decimal)row[EscalasComisionesCobradoresService.PorcentajeComision_NombreCol];
                        decimal comision = montoDolares * porcentaje / 100;
                        if (comision > montoTopeDolares)
                        {
                            return montoTopeDolares;
                        }
                        else
                        {
                            return comision;
                        }
                    }
                }

                if (dtEscala.Rows.Count > 0)
                {
                    decimal porcentaje = (decimal)dtEscala.Rows[dtEscala.Rows.Count-1][EscalasComisionesCobradoresService.PorcentajeComision_NombreCol];
                    decimal comision = montoDolares * porcentaje / 100;
                    if (comision > montoTopeDolares)
                    {
                        return montoTopeDolares;
                    }
                    else
                    {
                        return comision;
                    }
                }

                return 0;
            }
        }
        #endregion ObtenerComisionDolares

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "OBJETIVOS_COBRADORES"; }
        }
        public static string Anho_NombreCol
        {
            get { return OBJETIVOS_COBRADORESCollection.ANHOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return OBJETIVOS_COBRADORESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return OBJETIVOS_COBRADORESCollection.MONEDA_IDColumnName; }
        }
        public static string MontoObjetivo_NombreCol
        {
            get { return OBJETIVOS_COBRADORESCollection.MONTO_OBJETIVOColumnName; }
        }
        public static string MontoTope_NombreCol
        {
            get { return OBJETIVOS_COBRADORESCollection.MONTO_TOPEColumnName; }
        }

        public static string VistaNombreCompleto_NombreCol
        {
            get { return OBJETIVOS_COBRADORES_INFO_COMPCollection.NOMBRE_COMPLETOColumnName; }
        }
        #endregion Accessors
    }
}
