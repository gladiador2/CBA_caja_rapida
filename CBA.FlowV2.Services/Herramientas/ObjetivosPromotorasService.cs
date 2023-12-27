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
    public class ObjetivosPromotorasService
    {
        #region GetObjetivosPromotorasDataTable
        /// <summary>
        /// Gets the alarmas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetObjetivosPromotorasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.OBJETIVOS_PROMOTORASCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetObjetivosPromotorasDataTable

        #region GetObjetivosPromotorasInfoCompleta
        /// <summary>
        /// Gets the objetivos Promotoras info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetObjetivosPromotorasInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.OBJETIVOS_PROMOTORAS_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetObjetivosPromotorasInfoCompleta

        #region GenerarObjetivos
        public static void GenerarObjetivos(decimal anho, decimal monedaId)
        {
            string clausulas = FuncionariosService.EsPromotor_NombreCol + " = '" + Definiciones.SiNo.Si + "'";
            DataTable dtFuncionarios = FuncionariosService.GetFuncionariosDataTable2(clausulas, string.Empty, true);
            foreach(DataRow funcionarioRow in dtFuncionarios.Rows)
            {
                DataTable dtClientes = PromotoresService.GetClientesDePromotoresID((decimal)funcionarioRow[FuncionariosService.Id_NombreCol]);
                foreach (DataRow clienteRow in dtClientes.Rows)
                {
                    clausulas = ObjetivosPromotorasService.Anho_NombreCol + " = " + anho +
                        " and " + ObjetivosPromotorasService.FuncionarioId_NombreCol + " = " + clienteRow[PromotoresService.FuncionarioId_NombreCol].ToString() +
                        " and " + ObjetivosPromotorasService.PersonaId_NombreCol + " = " + clienteRow[PromotoresService.PersonaId_NombreCol].ToString();
                    DataTable dt = ObjetivosPromotorasService.GetObjetivosPromotorasDataTable(clausulas, string.Empty);

                    System.Collections.Hashtable campos = new System.Collections.Hashtable();
                    campos.Add(ObjetivosPromotorasService.Anho_NombreCol, anho);
                    campos.Add(ObjetivosPromotorasService.FuncionarioId_NombreCol, clienteRow[PromotoresService.FuncionarioId_NombreCol]);
                    campos.Add(ObjetivosPromotorasService.MonedaId_NombreCol, monedaId);
                    if (dt.Rows.Count == 0)
                    {
                        campos.Add(ObjetivosPromotorasService.MontoObjetivo_NombreCol, (decimal)0);
                        campos.Add(ObjetivosPromotorasService.MontoTope_NombreCol, (decimal)0);
                        campos.Add(ObjetivosPromotorasService.PorcentajeComision_NombreCol, (decimal)0);
                        campos.Add(ObjetivosPromotorasService.PorcentajeTope_NombreCol, (decimal)0);
                    }
                    else
                    {
                        campos.Add(ObjetivosPromotorasService.MontoObjetivo_NombreCol, (decimal)dt.Rows[0][ObjetivosPromotorasService.MontoObjetivo_NombreCol]);
                        campos.Add(ObjetivosPromotorasService.MontoTope_NombreCol, (decimal)dt.Rows[0][ObjetivosPromotorasService.MontoTope_NombreCol]);
                        campos.Add(ObjetivosPromotorasService.PorcentajeComision_NombreCol, (decimal)dt.Rows[0][ObjetivosPromotorasService.PorcentajeComision_NombreCol]);
                        campos.Add(ObjetivosPromotorasService.PorcentajeTope_NombreCol, (decimal)dt.Rows[0][ObjetivosPromotorasService.PorcentajeTope_NombreCol]);
                    }
                    campos.Add(ObjetivosPromotorasService.PersonaId_NombreCol, clienteRow[PromotoresService.PersonaId_NombreCol]);

                    Guardar(campos, dt.Rows.Count == 0);
                }

                clausulas = ObjetivosPromotorasService.Anho_NombreCol + " = " + anho +
                       " and " + ObjetivosPromotorasService.FuncionarioId_NombreCol + " = " + funcionarioRow[FuncionariosService.Id_NombreCol].ToString();
                DataTable dt2 = ObjetivosPromotorasService.GetObjetivosPromotorasDataTable(clausulas, string.Empty);
                foreach (DataRow ObjetivoPromotoraRow in dt2.Rows)
                {
                    bool encontrado = false;
                    foreach (DataRow clienteRow in dtClientes.Rows)
                    {
                        if ((decimal)clienteRow[PromotoresService.PersonaId_NombreCol] == (decimal)ObjetivoPromotoraRow[ObjetivosPromotorasService.PersonaId_NombreCol])
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Borrar((decimal)ObjetivoPromotoraRow[ObjetivosPromotorasService.FuncionarioId_NombreCol],
                            (decimal)ObjetivoPromotoraRow[ObjetivosPromotorasService.Anho_NombreCol],
                            (decimal)ObjetivoPromotoraRow[ObjetivosPromotorasService.PersonaId_NombreCol]);
                    }
                }

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
                OBJETIVOS_PROMOTORASRow row = new OBJETIVOS_PROMOTORASRow();
                try
                {
                    sesion.Db.BeginTransaction();

                    string valorAnterior = string.Empty;
                    if (insertarNuevo)
                    {
                        row.ANHO = (decimal)campos[ObjetivosPromotorasService.Anho_NombreCol];
                        row.FUNCIONARIO_ID = (decimal)campos[ObjetivosPromotorasService.FuncionarioId_NombreCol];
                        row.PERSONA_ID = (decimal)campos[ObjetivosPromotorasService.PersonaId_NombreCol];

                        row.MONEDA_ID = (decimal)campos[ObjetivosPromotorasService.MonedaId_NombreCol];
                        row.MONTO_OBJETIVO = (decimal)campos[ObjetivosPromotorasService.MontoObjetivo_NombreCol];
                        row.MONTO_TOPE = (decimal)campos[ObjetivosPromotorasService.MontoTope_NombreCol];
                        row.PORCENTAJE_COMISION = (decimal)campos[ObjetivosPromotorasService.PorcentajeComision_NombreCol];
                        row.PORCENTAJE_TOPE = (decimal)campos[ObjetivosPromotorasService.PorcentajeTope_NombreCol];
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        row = sesion.Db.OBJETIVOS_PROMOTORASCollection.GetByPrimaryKey((decimal)campos[ObjetivosPromotorasService.FuncionarioId_NombreCol], (decimal)campos[ObjetivosPromotorasService.Anho_NombreCol], (decimal)campos[ObjetivosPromotorasService.PersonaId_NombreCol]);
                        valorAnterior = row.ToString();

                        if (row.MONEDA_ID != (decimal)campos[ObjetivosPromotorasService.MonedaId_NombreCol])
                        {
                            decimal cotizacionVieja = CotizacionesService.GetCotizacionMonedaVenta(row.MONEDA_ID);
                            decimal cotizacionNueva = CotizacionesService.GetCotizacionMonedaVenta((decimal)campos[ObjetivosPromotorasService.MonedaId_NombreCol]);

                            row.MONTO_OBJETIVO = (row.MONTO_OBJETIVO / cotizacionVieja) * cotizacionNueva;
                            row.MONTO_TOPE = (row.MONTO_TOPE / cotizacionVieja) * cotizacionNueva;
                        }
                        else
                        {
                            row.PORCENTAJE_COMISION = (decimal)campos[ObjetivosPromotorasService.PorcentajeComision_NombreCol];
                            row.PORCENTAJE_TOPE = (decimal)campos[ObjetivosPromotorasService.PorcentajeTope_NombreCol];
                            row.MONTO_OBJETIVO = (decimal)campos[ObjetivosPromotorasService.MontoObjetivo_NombreCol];
                            row.MONTO_TOPE = (decimal)campos[ObjetivosPromotorasService.MontoTope_NombreCol];
                        }
                        row.MONEDA_ID = (decimal)campos[ObjetivosPromotorasService.MonedaId_NombreCol];

                    }

                    if (insertarNuevo) sesion.Db.OBJETIVOS_PROMOTORASCollection.Insert(row);
                    else sesion.Db.OBJETIVOS_PROMOTORASCollection.Update(row);
                    
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

        #region Borrar
        /// <summary>
        /// Borrars the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        public static void Borrar(decimal funcionarioId, decimal anho, decimal personaId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    OBJETIVOS_PROMOTORASRow row = sesion.Db.OBJETIVOS_PROMOTORASCollection.GetByPrimaryKey(funcionarioId,anho,personaId);

                    sesion.Db.OBJETIVOS_PROMOTORASCollection.Delete(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
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
            get { return "OBJETIVOS_Promotoras"; }
        }
        public static string Anho_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.ANHOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.MONEDA_IDColumnName; }
        }
        public static string MontoObjetivo_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.MONTO_OBJETIVOColumnName; }
        }
        public static string MontoTope_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.MONTO_TOPEColumnName; }
        }
        public static string PorcentajeComision_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.PORCENTAJE_COMISIONColumnName; }
        }
        public static string PorcentajeTope_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.PORCENTAJE_TOPEColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return OBJETIVOS_PROMOTORASCollection.PERSONA_IDColumnName; }
        }

        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return OBJETIVOS_PROMOTORAS_INFO_COMPCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaPersonaNombre_NombreCol
        {
            get { return OBJETIVOS_PROMOTORAS_INFO_COMPCollection.PERSONA_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
