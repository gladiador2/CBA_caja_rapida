#region Using
using System;
using System.Linq;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using Oracle.ManagedDataAccess.Client;
using System.Collections;

#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class CuentasService
    {
        #region GetCuentasDataTable

        /// <summary>
        /// Gets the cuentas data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCuentasDataTable()
        {
            return GetCuentasDataTable(string.Empty, string.Empty);
        }

        /// <summary>
        /// Gets the cuentas data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentasDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = "1=1";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.CTB_CUENTASCollection.GetAsDataTable(clausulas, orden);
                }
                else
                {
                    table = sesion.Db.CTB_CUENTASCollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetCuentasDataTable

        #region GetCuentasInfoCompleta

        /// <summary>
        /// Gets the cuentas info completa.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCuentasInfoCompleta()
        {
            return GetCuentasInfoCompleta(string.Empty, string.Empty);
        }

        /// <summary>
        /// Gets the cuentas info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetCuentasInfoCompleta(String clausulas, String orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                string estado = "1=1";

                if (!clausulas.Equals(string.Empty))
                {
                    table = sesion.Db.CTB_CUENTAS_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
                }
                else
                {
                    table = sesion.Db.CTB_CUENTAS_INFO_COMPLETACollection.GetAsDataTable(estado, orden);
                }
                return table;
            }
        }
        #endregion GetCuentasInfoCompleta

        #region GetNivel

        /// <summary>
        /// Gets the nivel.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static decimal GetNivel(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
                return row.NIVEL;
            }
        }

        #endregion GetNivel

        #region GetNombre

        /// <summary>
        /// Gets the nivel.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public string GetNombre(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
                return row.NOMBRE;
            }
        }

        #endregion GetNombre

        #region ObtenerRama

        /// <summary>
        /// Gets the cuenta madre.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static decimal[] ObtenerRama(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);

                decimal[] rama = new decimal[(int)row.NIVEL];
                rama[(int)row.NIVEL - 1] = row.ID;
                if (CuentasService.TieneCuentaMadre(cuenta_id))
                    IterarCuentasMadre(row.CTB_CUENTA_MADRE_ID, ref rama);

                return rama;
            }
        }

        public static void IterarCuentasMadre(decimal cuenta_id, ref decimal[] rama)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);

                rama[(int)row.NIVEL - 1] = row.ID;

                if (CuentasService.TieneCuentaMadre(cuenta_id))
                {
                    IterarCuentasMadre(row.CTB_CUENTA_MADRE_ID, ref rama);
                }
            }
        }

        #endregion ObtenerRama

        #region GetCuentaMadre

        /// <summary>
        /// Gets the cuenta madre.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static decimal GetCuentaMadre(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
                return row.CTB_CUENTA_MADRE_ID;
            }
        }

        public static decimal GetCuentaMadreRaiz(decimal cuenta_id, SessionService sesion)
        {
            
            
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);

                if (row.IsCTB_CUENTA_MADRE_IDNull)
                    return decimal.Parse(row.CODIGO);                
                else
                    return GetCuentaMadreRaiz(row.CTB_CUENTA_MADRE_ID, sesion);
            
        }

        #endregion GetCuentaMadre

        #region EsAsentable
        /// <summary>
        /// Eses the asentable.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static bool EsAsentable(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
                return row.ASENTABLE.EndsWith(Definiciones.SiNo.Si) ? true : false;
            }
        }
        #endregion EsAsentable

        #region EsEditable

        /// <summary>
        /// Eses the editable.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public static bool EsEditable(decimal cuenta_id, SessionService sesion)
        {
            CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
            if (row.EDITABLE.Equals(Definiciones.SiNo.Si))
                return true;
            else
                return false;
        }
        #endregion EsEditable

        #region SetAsentable

        /// <summary>
        /// Sets the asentable.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <param name="valor">The valor.</param>
        /// <param name="sesion">The sesion.</param>
        public static void SetAsentable(decimal cuenta_id, string valor, SessionService sesion)
        {
            CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
            string valorAnterior = row.ToString();

            row.ASENTABLE = valor;

            sesion.Db.CTB_CUENTASCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion SetAsentable

        #region GetNumeroDeHijos

        /// <summary>
        /// Gets the numero de hijos.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static decimal GetNumeroDeHijos(decimal cuenta_id)
        {
            decimal hijos = 0;
            DataTable dt;
            string clausulas;

            clausulas = CuentasService.CtbCuentaMadreId_NombreCol + " = " + cuenta_id;
            dt = CuentasService.GetCuentasDataTable(clausulas, string.Empty);

            hijos = dt.Rows.Count;

            return hijos;
        }
        #endregion GetNumeroDeHijos

        #region GetHijos
        /* Obtiene todos los hijos de la cuenta pasada como parámetro.
         */
        public static DataTable GetHijos(string cuenta_id)
        {
            DataTable dt;
            string clausulas;

            clausulas = CuentasService.CtbCuentaMadreId_NombreCol + " = " + cuenta_id;
            dt = CuentasService.GetCuentasDataTable(clausulas, string.Empty);

            return dt;
        }
        #endregion GetHijos

        #region GetCuentasInferiores
        /* Obtiene todos los hijos de la cuenta pasada como parámetro.
         */
        public static DataTable GetCuentasInferiores(decimal cuenta_id, decimal plan_cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausulas = CuentasService.CtbPlanCuentaId_NombreCol + " = " + plan_cuenta_id;

                if (cuenta_id != Definiciones.Error.Valor.EnteroPositivo)
                {
                    CTB_CUENTAS_INFO_COMPLETARow row = sesion.Db.CTB_CUENTAS_INFO_COMPLETACollection.GetRow(CuentasService.Id_NombreCol + " = " + cuenta_id);
                    clausulas += " and " + CuentasService.VistaCodigoCompletoSinCeros_NombreCol + " like '" + row.CODIGO_COMPLETO_SIN_CEROS + ".%'";
                }

                return CuentasService.GetCuentasInfoCompleta(clausulas, string.Empty);
            }
        }
        #endregion GetCuentasInferiores

        #region TieneCuentaMadre

        /// <summary>
        /// Tienes the cuenta madre.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static bool TieneCuentaMadre(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
                return !row.IsCTB_CUENTA_MADRE_IDNull;
            }
        }

        #endregion TieneCuentaMadre

        #region GetCodigo

        /// <summary>
        /// Gets the codigo.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static string GetCodigo(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
                return row.CODIGO;
            }
        }

        #endregion GetCodigo

        #region GetCodigoBase

        /// <summary>
        /// Gets the codigo base.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        /// <returns></returns>
        public static string GetCodigoBase(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);
                return row.CODIGO_BASE;
            }
        }

        #endregion GetCodigoBase

        #region Verificar Codigo
        //Funcion que verifica si el codigo que se desea dar a la cuenta esta disponible
        /// <summary>
        /// Verificars the codigo.
        /// </summary>
        /// <param name="cuentaMadre_id">The cuenta madre_id.</param>
        /// <param name="cuentaHija_id">The cuenta hija_id.</param>
        /// <param name="codigo">The codigo.</param>
        /// <returns></returns>
        public static bool VerificarCodigo(decimal cuentaMadre_id, decimal cuentaHija_id, string codigo)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow[] cuentas = sesion.Db.CTB_CUENTASCollection.GetByCTB_CUENTA_MADRE_ID(cuentaMadre_id);
                for (int i = 0; i < cuentas.Length; i++)
                {
                    //Si la cuenta consultada es la evaluada, debe continuarse
                    if (cuentaHija_id.Equals(cuentas[i].ID) && !cuentaHija_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        continue;

                    if (cuentas[i].CODIGO == codigo)
                        return false;
                }
                return true;
            }
        }

        #endregion Verificar Codigo

        #region Ajustar Codigos

        /// <summary>
        /// Ajustars the codigos.
        /// </summary>
        /// <param name="cuentaMadre_id">The cuenta madre_id.</param>
        /// <param name="codigoNuevo">The codigo nuevo.</param>
        /// <param name="codigoViejo">The codigo viejo.</param>
        public static void AjustarCodigos(decimal cuentaMadre_id, string codigoNuevo, string codigoViejo)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow[] cuentas = sesion.Db.CTB_CUENTASCollection.GetByCTB_CUENTA_MADRE_ID(cuentaMadre_id);
                CTB_CUENTASRow cuenta;
                sesion.Db.BeginTransaction();
                for (int i = 0; i < cuentas.Length; i++)
                {
                    cuenta = cuentas[i];
                    if (codigoViejo.Equals(string.Empty))
                    {
                        if (decimal.Parse(cuenta.CODIGO) >= decimal.Parse(codigoNuevo))
                            cuenta.CODIGO = (decimal.Parse(cuentas[i].CODIGO) + 1).ToString();
                    }
                    else
                    {

                        //Si el cambio deseado es de un elemento mas bajo a uno mas alto
                        if (decimal.Parse(codigoViejo) < decimal.Parse(codigoNuevo))
                        {
                            if (decimal.Parse(cuenta.CODIGO) > decimal.Parse(codigoViejo) && decimal.Parse(cuenta.CODIGO) <= decimal.Parse(codigoNuevo))
                                cuenta.CODIGO = (decimal.Parse(cuentas[i].CODIGO) - 1).ToString();
                        }
                        //Si no, el cambio es de un elemento mas alto a uno mas bajo
                        else
                        {
                            if (decimal.Parse(cuenta.CODIGO) < decimal.Parse(codigoViejo) && decimal.Parse(cuenta.CODIGO) >= decimal.Parse(codigoNuevo))
                                cuenta.CODIGO = (decimal.Parse(cuentas[i].CODIGO) + 1).ToString();
                        }
                    }
                    sesion.Db.CTB_CUENTASCollection.Update(cuenta);
                }
                sesion.Db.CommitTransaction();

                //CalcularCodigosBase(cuentaMadre_id);
            }
        }

        #endregion Ajustar Codigos

        #region Calcular Codigos Base
        //Funcion recursiva que recalcula los codigos base de todos los hijos de una cuenta madre dada
        /// <summary>
        /// Calculars the codigos base.
        /// </summary>
        /// <param name="ctb_cuenta_madre_id">The ctb_cuenta_madre_id.</param>
        public static void CalcularCodigosBase(decimal ctb_cuenta_madre_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow[] cuentasHijos = sesion.Db.CTB_CUENTASCollection.GetByCTB_CUENTA_MADRE_ID(ctb_cuenta_madre_id);
                CTB_CUENTASRow cuenta;
                for (int i = 0; i < cuentasHijos.Length; i++)
                {
                    sesion.Db.BeginTransaction();
                    cuenta = cuentasHijos[i];
                    if (TieneCuentaMadre(ctb_cuenta_madre_id))
                        cuenta.CODIGO_BASE = GetCodigoBase(ctb_cuenta_madre_id) + "." + GetCodigo(ctb_cuenta_madre_id);
                    else
                        cuenta.CODIGO_BASE = GetCodigo(ctb_cuenta_madre_id);
                    sesion.Db.CTB_CUENTASCollection.Update(cuenta);
                    sesion.Db.CommitTransaction();

                    //Si tiene hijos, se calcula los codigos base de cada uno de los hijos
                    if (GetNumeroDeHijos(cuenta.ID) > 0)
                        CalcularCodigosBase(cuenta.ID);
                }
            }
        }

        #endregion Calcular Codigos Base

        #region ImportarCuentas
        //Funcion que borra las cuentas viejas del plan destino y le carga las cuentas del plan origen
        /// <summary>
        /// Importars the cuentas.
        /// </summary>
        /// <param name="planOrigen">The plan origen.</param>
        /// <param name="planDestino">The plan destino.</param>
        public static void ImportarCuentas(decimal planOrigen, decimal planDestino)
        {
            using (SessionService sesion = new SessionService())
            {
                //Borrar cuentas viejas
                CTB_CUENTASRow[] cuentasViejas = sesion.Db.CTB_CUENTASCollection.GetByCTB_PLAN_CUENTA_ID(planDestino);
                for (int i = 0; i < cuentasViejas.Length; i++)
                {
                    //Si no tiene cuenta madre, es raiz y se aplica el borrado recursivo.
                    if (cuentasViejas[i].IsCTB_CUENTA_MADRE_IDNull)
                        CuentasService.BorrarCuentas(cuentasViejas[i].ID);
                }

                //Crear cuentas nuevas
                sesion.Db.BeginTransaction();
                CrearCuentas(planDestino, 0, null, null, true, planOrigen);
                sesion.Db.CommitTransaction();
            }
        }

        #endregion ImportarCuentas

        #region Crear Cuentas
        //Funcion que carga las cuentas plantillas en un plan nuevo, o que importa las cuentas de otro plan existente
        /// <summary>
        /// Crears the cuentas.
        /// </summary>
        /// <param name="ctb_plan_cuenta_id">The ctb_plan_cuenta_id.</param>
        /// <param name="ctb_cuenta_madre_id">The ctb_cuenta_madre_id.</param>
        /// <param name="dr_ctb_cuenta_plantilla_row">The dr_ctb_cuenta_plantilla_row.</param>
        /// <param name="sesion">The sesion.</param>
        /// <param name="importar">if set to <c>true</c> [importar].</param>
        /// <param name="ctb_plan_cuenta_origen">The ctb_plan_cuenta_origen.</param>
        public static void CrearCuentas(decimal ctb_plan_cuenta_id, decimal ctb_cuenta_madre_id, DataRow dr_ctb_cuenta_plantilla_row, SessionService sesion, bool importar, decimal ctb_plan_cuenta_origen)
        {
            //En la primera llamada al metodo sesion es null
            if (sesion == null) sesion = new SessionService();

            //En la primera llamada al metodo la cuenta plantilla es null
            //y se copian las cuentas del primer nivel (que no tienen cuenta madre)
            if (dr_ctb_cuenta_plantilla_row == null)
            {
                DataTable dtPlantilla;
                if (importar && ctb_plan_cuenta_origen != 0)
                {
                    dtPlantilla = CuentasService.GetCuentasDataTable(CuentasService.CtbCuentaMadreId_NombreCol + " is null and " + CuentasService.CtbPlanCuentaId_NombreCol + " = " + ctb_plan_cuenta_origen, string.Empty);
                    for (int i = 0; i < dtPlantilla.Rows.Count; i++)
                    {
                        CrearCuentas(ctb_plan_cuenta_id, Definiciones.Error.Valor.EnteroPositivo, dtPlantilla.Rows[i], sesion, true, 0);
                    }
                }
                else
                {
                    dtPlantilla = (new CuentasPlantillasService()).GetCuentasPlantillasDataTable(CuentasPlantillasService.CtbCuentaMadreId_NombreCol + " is null", string.Empty);
                    for (int i = 0; i < dtPlantilla.Rows.Count; i++)
                    {
                        CrearCuentas(ctb_plan_cuenta_id, Definiciones.Error.Valor.EnteroPositivo, dtPlantilla.Rows[i], sesion, false, 0);
                    }
                }
            }
            else
            {
                #region Crear la cuenta
                CTB_CUENTASRow cuentaNueva = new CTB_CUENTASRow();

                cuentaNueva.ID = sesion.Db.GetSiguienteSecuencia("ctb_cuentas_sqc");
                cuentaNueva.CTB_PLAN_CUENTA_ID = ctb_plan_cuenta_id;

                if (ctb_cuenta_madre_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    cuentaNueva.IsCTB_CUENTA_MADRE_IDNull = true;
                else
                    cuentaNueva.CTB_CUENTA_MADRE_ID = ctb_cuenta_madre_id;

                if (importar)
                {
                    if (!dr_ctb_cuenta_plantilla_row[CuentasService.CodigoBase_NombreCol].Equals(DBNull.Value))
                        cuentaNueva.CODIGO_BASE = (string)dr_ctb_cuenta_plantilla_row[CuentasService.CodigoBase_NombreCol];
                    cuentaNueva.CODIGO = (string)dr_ctb_cuenta_plantilla_row[CuentasService.Codigo_NombreCol];
                    cuentaNueva.NIVEL = (decimal)dr_ctb_cuenta_plantilla_row[CuentasService.Nivel_NombreCol];
                    cuentaNueva.NOMBRE = (string)dr_ctb_cuenta_plantilla_row[CuentasService.Nombre_NombreCol];
                    cuentaNueva.ASENTABLE = (string)dr_ctb_cuenta_plantilla_row[CuentasService.Asentable_NombreCol];
                    cuentaNueva.EDITABLE = (string)dr_ctb_cuenta_plantilla_row[CuentasService.Editable_NombreCol];
                    cuentaNueva.UTILIZAR = Definiciones.SiNo.Si;
                    cuentaNueva.DESGLOSAR = Definiciones.SiNo.No;
                }
                else
                {
                    if (!dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.CodigoBase_NombreCol].Equals(DBNull.Value))
                        cuentaNueva.CODIGO_BASE = (string)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.CodigoBase_NombreCol];
                    cuentaNueva.CODIGO = (string)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Codigo_NombreCol];
                    cuentaNueva.NIVEL = (decimal)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Nivel_NombreCol];
                    cuentaNueva.NOMBRE = (string)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Nombre_NombreCol];
                    cuentaNueva.ASENTABLE = (string)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Asentable_NombreCol];
                    cuentaNueva.EDITABLE = (string)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Editable_NombreCol];
                    cuentaNueva.UTILIZAR = Definiciones.SiNo.Si;
                    cuentaNueva.DESGLOSAR = Definiciones.SiNo.No;
                }
                sesion.Db.CTB_CUENTASCollection.Insert(cuentaNueva);
                #endregion Crear la cuenta

                #region Crear subcuentas si existen
                if (importar)
                {
                    if (CuentasService.GetNumeroDeHijos((decimal)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Id_NombreCol]) > 0)
                    {
                        DataTable dtPlantillaHijos = CuentasService.GetCuentasDataTable(CuentasService.CtbCuentaMadreId_NombreCol + " = " + dr_ctb_cuenta_plantilla_row[CuentasService.Id_NombreCol], string.Empty);
                        for (int i = 0; i < dtPlantillaHijos.Rows.Count; i++)
                        {
                            CrearCuentas(ctb_plan_cuenta_id, cuentaNueva.ID, dtPlantillaHijos.Rows[i], sesion, true, 0);
                        }
                    }
                }
                else
                {
                    if (CuentasPlantillasService.TieneHijos((decimal)dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Id_NombreCol]))
                    {
                        DataTable dtPlantillaHijos = (new CuentasPlantillasService()).GetCuentasPlantillasDataTable(CuentasPlantillasService.CtbCuentaMadreId_NombreCol + " = " + dr_ctb_cuenta_plantilla_row[CuentasPlantillasService.Id_NombreCol], string.Empty);
                        for (int i = 0; i < dtPlantillaHijos.Rows.Count; i++)
                        {
                            CrearCuentas(ctb_plan_cuenta_id, cuentaNueva.ID, dtPlantillaHijos.Rows[i], sesion, false, 0);
                        }
                    }
                }
                #endregion Crear subcuentas si existen
            }
        }


        //indica si la numeracion1 es anterior a la numeracion2, false en caso contrario
        private static bool numeracionEsPosterior(int[] numeracion1, int[] numeracion2)
        {
            if (numeracion1.Length == numeracion2.Length)
            {//son numeraciones del mismo nivel 
                //el prefijo debe ser igual
                for (int i = 0; i < numeracion1.Length - 1; i++)
                    if (numeracion1[i] != numeracion2[i])
                        return false;
                //el ultimo numero del segundo codigo debe ser mayor
                if (numeracion1[numeracion1.Length - 1] >= numeracion2[numeracion2.Length - 1])
                    return false;
            }
            else if (numeracion1.Length > numeracion2.Length)
            {//la segunda numeracion es de un nivel menor
                //el prefijo comun del segundo codigo debe ser igual
                for (int i = 0; i < numeracion2.Length - 1; i++)
                    if (numeracion1[i] != numeracion2[i])
                        return false;
                //el ultimo numero del segundo codigo tiene que se mayor al numero de ese nivel del primer codigo
                if (numeracion1[numeracion2.Length - 1] >= numeracion2[numeracion2.Length - 1])
                    return false;
            }
            else if (numeracion1.Length < numeracion2.Length)
            {//la segunda numeracion es de un nivel mayor
                //el segundo codigo puede ser como maximo un nivel mas
                if (numeracion2.Length - numeracion1.Length > 1)
                    return false;
                //el prefijo del segundo numero debe ser igual al codigo entero del anterior
                for (int i = 0; i < numeracion1.Length - 1; i++)
                    if (numeracion1[i] != numeracion2[i])
                        return false;
                //el numero sin prefijo del segundo codigo debe ser un entero positivo
                if (numeracion2[numeracion2.Length - 1] <= 0)
                    return false;
            }
            return true;
        }

        private static void AgregarSeparadorACodigos(DataTable dt)
        {
            if (dt.Rows.Count <= 1)
                return;

            //Se busca el separador en la 2da cuenta y si lo tiene no hace falta modificar los codigos
            if (dt.Rows[1][CuentasService.Codigo_NombreCol].ToString().Contains("."))
                return;

            string codigoAux;
            string[] codigoCuentaMadre = new string[20]; //La dimension es la cantidad de niveles soportada
            string[] codigoCuentaMadreFormateado = new string[20];
            int nivelAnterior = Definiciones.Error.Valor.IntPositivo;
            bool bandera = false;

            codigoCuentaMadre[0] = string.Empty;
            codigoCuentaMadreFormateado[0] = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
            { 
                int nivelActual = int.Parse(dt.Rows[i][CuentasService.Nivel_NombreCol].ToString());

                if (nivelActual > nivelAnterior + 1)
                {
                    //Se inicia el recorrido de los hijos
                    nivelAnterior += 1;
                    codigoCuentaMadre[nivelActual] = dt.Rows[i][CuentasService.Codigo_NombreCol].ToString();
                    bandera = true;
                }
                else if (nivelActual <= nivelAnterior)
                { 
                    //Se terminaron los hijos anidados del hermano anterior
                    nivelAnterior = nivelActual - 1;
                    codigoCuentaMadre[nivelActual] = dt.Rows[i][CuentasService.Codigo_NombreCol].ToString();
                    bandera = true;
                }

                //Obtener la ultima seccion del codigo
                codigoAux = dt.Rows[i][CuentasService.Codigo_NombreCol].ToString();
                codigoAux = codigoAux.Substring(codigoAux.IndexOf(codigoCuentaMadre[nivelAnterior]) + codigoCuentaMadre[nivelAnterior].Length);

                //Concatenar el codigo bien formateado de la cuenta madre con la ultima parte del codigo de la cuenta
                if(codigoCuentaMadreFormateado[nivelAnterior].Length > 0)
                    dt.Rows[i][CuentasService.Codigo_NombreCol] = codigoCuentaMadreFormateado[nivelAnterior] + "." + int.Parse(codigoAux);
                else
                    dt.Rows[i][CuentasService.Codigo_NombreCol] = codigoAux;

                if (bandera)
                {
                    bandera = false;
                    codigoCuentaMadreFormateado[nivelActual] = dt.Rows[i][CuentasService.Codigo_NombreCol].ToString();
                }
            }
        }

        private static bool ValidarDataTable(DataTable dataTableCuentas)
        {
            DataRow cuentaAnterior = null;
            foreach (DataRow cuenta in dataTableCuentas.Rows)
            {
                string numeracion = cuenta[CuentasService.Codigo_NombreCol].ToString();
                int[] numeracionSegments = numeracion.Split('.').Select(n => Convert.ToInt32(n)).ToArray();
                string nombre = cuenta[CuentasService.Nombre_NombreCol].ToString();
                bool asentable = cuenta[CuentasService.Asentable_NombreCol].ToString() == "S";
                bool utilizar = cuenta[CuentasService.Utilizar_NombreCol].ToString() == "S";
                int nivel = int.Parse(cuenta[CuentasService.Nivel_NombreCol].ToString());

                //el nivel debe ser consistente con la cantidad de segmentos de la numeracion
                if (numeracionSegments.Length > nivel)
                    throw new Exception("Inconsistencia entre código y nivel en la cuenta " + numeracion + " " + nombre + ", nivel " + nivel + ".");

                //controles con la cuenta anterior
                if (cuentaAnterior != null)
                {
                    string numeracionAnterior = cuentaAnterior[CuentasService.Codigo_NombreCol].ToString();
                    int[] numeracionSegmentsAnterior = numeracionAnterior.Split('.').Select(n => Convert.ToInt32(n)).ToArray();
                    
                    if (!numeracionEsPosterior(numeracionSegmentsAnterior, numeracionSegments))
                        throw new Exception("Error de numeración en la cuenta " + numeracion + " " + nombre + ".");
                }
                else
                {
                    //en caso de que sea la primera cuenta de todas, deben cumplirse lo siguiente 
                    if (nivel != 1 || numeracion != "1")
                        throw new Exception("Error de nivel o código en la cuenta " + numeracion + " " + nombre + ".");
                }

                cuentaAnterior = cuenta;
            }

            return true;
        }

        private static string obtenerCodigoBase(int[] segmentos)
        {
            string codigoBase = string.Empty;
            for (int i = 0; i < segmentos.Length - 1; i++)
            {
                if (i > 0)
                    codigoBase += ".";
                codigoBase += segmentos[i].ToString();
            }
            return codigoBase;
        }

        public static string CrearCuentas(decimal ctb_plan_cuenta_id, DataTable dataTableCuentas)
        {
            using (SessionService sesion = new SessionService())
            {
                return CrearCuentas(ctb_plan_cuenta_id, dataTableCuentas, sesion);
            }
        }

        public static string CrearCuentas(decimal ctb_plan_cuenta_id, DataTable dataTableCuentas, SessionService sesion)
        {
            try
            {
                AgregarSeparadorACodigos(dataTableCuentas);
                ValidarDataTable(dataTableCuentas);

                DataRow cuentaAnterior = null;
                Stack ramaActual = new Stack();
                foreach (DataRow cuenta in dataTableCuentas.Rows)
                {
                    string numeracion = cuenta[CuentasService.Codigo_NombreCol].ToString();
                    int[] numeracionSegments = numeracion.Split('.').Select(n => Convert.ToInt32(n)).ToArray();
                    string nombre = cuenta[CuentasService.Nombre_NombreCol].ToString();
                    bool asentable = true;
                    bool utilizar = true;
                    int nivel = int.Parse(cuenta[CuentasService.Nivel_NombreCol].ToString());

                    CTB_CUENTASRow cuentaNueva = new CTB_CUENTASRow();
                    cuentaNueva.CTB_PLAN_CUENTA_ID = ctb_plan_cuenta_id;
                    cuentaNueva.EDITABLE = Definiciones.SiNo.Si;
                    cuentaNueva.NIVEL = nivel;
                    cuentaNueva.NOMBRE = nombre;
                    cuentaNueva.UTILIZAR = utilizar ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
                    cuentaNueva.ASENTABLE = asentable ? Definiciones.SiNo.Si : Definiciones.SiNo.No;
                    cuentaNueva.CODIGO_BASE = obtenerCodigoBase(numeracionSegments);
                    cuentaNueva.CODIGO = numeracionSegments[numeracionSegments.Length - 1].ToString();
                    cuentaNueva.DESGLOSAR = Definiciones.SiNo.No;

                    if (cuentaAnterior != null)
                    {
                        string numeracionAnterior = cuentaAnterior[CuentasService.Codigo_NombreCol].ToString();
                        int[] numeracionSegmentsAnterior = numeracionAnterior.Split('.').Select(n => Convert.ToInt32(n)).ToArray();
                        int nivelAnterior = int.Parse(cuentaAnterior[CuentasService.Nivel_NombreCol].ToString());

                        if (nivelAnterior == nivel)
                        {
                            ramaActual.Pop();//la cuenta anterior era una cuenta del mismo nivel, por lo tanto se comparte el ancestro como padre
                            if (ramaActual.Count > 0)
                                cuentaNueva.CTB_CUENTA_MADRE_ID = ((CTB_CUENTASRow)ramaActual.Peek()).ID;
                            else
                                cuentaNueva.IsCTB_CUENTA_MADRE_IDNull = true;

                            //en este caso , si la diferencia entre los codigos es mayor a 1, se crean las cuentas intermedias
                            if (numeracionSegments[numeracionSegments.Length - 1] - numeracionSegmentsAnterior[numeracionSegmentsAnterior.Length - 1] > 1)
                                for (int i = numeracionSegmentsAnterior[numeracionSegmentsAnterior.Length - 1] + 1; i < numeracionSegments[numeracionSegments.Length - 1]; i++)
                                {
                                    CTB_CUENTASRow cuentaIntermedia = new CTB_CUENTASRow();
                                    cuentaIntermedia.CTB_PLAN_CUENTA_ID = ctb_plan_cuenta_id;
                                    cuentaIntermedia.ID = sesion.Db.GetSiguienteSecuencia("ctb_cuentas_sqc");
                                    cuentaIntermedia.EDITABLE = Definiciones.SiNo.Si;
                                    cuentaIntermedia.NIVEL = nivel;
                                    cuentaIntermedia.NOMBRE = "NO UTILIZAR";
                                    cuentaIntermedia.UTILIZAR = Definiciones.SiNo.No;
                                    cuentaIntermedia.ASENTABLE = Definiciones.SiNo.No;
                                    cuentaIntermedia.CODIGO_BASE = obtenerCodigoBase(numeracionSegments);
                                    cuentaIntermedia.CODIGO = i.ToString();
                                    cuentaIntermedia.DESGLOSAR = Definiciones.SiNo.No;
                                    if (nivel != 1)
                                        cuentaIntermedia.CTB_CUENTA_MADRE_ID = cuentaNueva.CTB_CUENTA_MADRE_ID;
                                    else
                                        cuentaIntermedia.IsCTB_CUENTA_MADRE_IDNull = true;
                                    sesion.db.CTB_CUENTASCollection.Insert(cuentaIntermedia);
                                }


                        }
                        else if (nivelAnterior < nivel)
                        {//la cuenta anterior es la cuenta padre de la cuenta actual
                            cuentaNueva.CTB_CUENTA_MADRE_ID = ((CTB_CUENTASRow)ramaActual.Peek()).ID;
                        }
                        else if (nivelAnterior > nivel)
                        {//la cuenta anterior era la ultima cuenta de su rama, se debe hacer pop de los padres hasta llegar al ancestro comun
                            if (nivel > 1)
                                while (((CTB_CUENTASRow)ramaActual.Peek()).NIVEL >= nivel)//retrocedemos el stack hasta encontrar al padre de la cuenta actual
                                    ramaActual.Pop();
                            else
                                ramaActual.Clear();

                            if (ramaActual.Count > 0)
                                cuentaNueva.CTB_CUENTA_MADRE_ID = ((CTB_CUENTASRow)ramaActual.Peek()).ID;
                            else
                                cuentaNueva.IsCTB_CUENTA_MADRE_IDNull = true;
                        }
                    }
                    else
                    {
                        //es definitivamente la primera cuenta del datatable
                        cuentaNueva.IsCTB_CUENTA_MADRE_IDNull = true;
                    }

                    cuentaNueva.ID = sesion.Db.GetSiguienteSecuencia("ctb_cuentas_sqc");

                    //si es una cuenta hija, la cuenta madre se pone como no asentable
                    if (!cuentaNueva.IsCTB_CUENTA_MADRE_IDNull)
                        SetAsentable(cuentaNueva.CTB_CUENTA_MADRE_ID, Definiciones.SiNo.No, sesion);

                    sesion.db.CTB_CUENTASCollection.Insert(cuentaNueva);
                    ramaActual.Push(cuentaNueva);//se asume que la cuenta recien insertada tiene descendencia

                    cuentaAnterior = cuenta;
                }
                return "Las cuentas fueron creadas exitosamente";
            }
            catch
            {
                throw;
            }
        }

        #endregion Crear Cuentas

        #region Guardar

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTB_CUENTASRow row = new CTB_CUENTASRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("ctb_cuentas_sqc");
                        row.ASENTABLE = Definiciones.SiNo.No;

                        //Se marca a la cta madre como no asentable
                        CuentasService.SetAsentable((decimal)campos[CtbCuentaMadreId_NombreCol], Definiciones.SiNo.No, sesion);
                    }
                    else
                    {
                        row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                    }

                    if (row.CTB_PLAN_CUENTA_ID.Equals(DBNull.Value) || row.CTB_PLAN_CUENTA_ID != (decimal)campos[CtbPlanCuentaId_NombreCol])
                    {
                        if (!PlanesDeCuentaService.EstaActivo((decimal)campos[CtbPlanCuentaId_NombreCol]))
                            throw new System.Exception("El plan de cuentas no está activo.");
                        else
                            row.CTB_PLAN_CUENTA_ID = (decimal)campos[CtbPlanCuentaId_NombreCol];
                    }

                    row.NOMBRE = (string)campos[Nombre_NombreCol];
                    row.CODIGO = (string)campos[Codigo_NombreCol];
                    row.CODIGO_BASE = (string)campos[CodigoBase_NombreCol];

                    if (row.ASENTABLE.Equals(Definiciones.SiNo.No) && (string)campos[Asentable_NombreCol] == Definiciones.SiNo.Si)
                    {
                        if (CuentasService.GetNumeroDeHijos(row.ID) > 0)
                            throw new Exception("La cuenta tiene hijos por lo que no puede ser asentable");
                    }

                    row.ASENTABLE = (string)campos[Asentable_NombreCol];
                    row.UTILIZAR = campos[Utilizar_NombreCol].ToString();
                    row.DESGLOSAR = campos[Desglosar_NombreCol].ToString();

                    if (campos.Contains(CtbCuentaMadreId_NombreCol))
                    {
                        row.CTB_CUENTA_MADRE_ID = (decimal)campos[CtbCuentaMadreId_NombreCol];
                        CuentasService.SetAsentable(row.CTB_CUENTA_MADRE_ID, Definiciones.SiNo.No, sesion);
                        row.EDITABLE = Definiciones.SiNo.Si;
                        row.NIVEL = CuentasService.GetNivel((decimal)campos[CtbCuentaMadreId_NombreCol]) + 1;
                    }
                    else
                    {
                        row.EDITABLE = Definiciones.SiNo.No;
                        row.NIVEL = 1;
                    }

                    if (insertarNuevo)
                    {
                        if(!row.IsCTB_CUENTA_MADRE_IDNull)
                            row.CTB_CLASIFICACION_CUENTAS_ID = GetCuentaMadreRaiz(row.CTB_CUENTA_MADRE_ID, sesion);

                        sesion.Db.CTB_CUENTASCollection.Insert(row);
                    }
                    else sesion.Db.CTB_CUENTASCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("Ya existe un registro con ese nombre.");
                        default: throw exp;
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
        /// Borrars the specified cuenta_id.
        /// </summary>
        /// <param name="cuenta_id">The cuenta_id.</param>
        public static void Borrar(decimal cuenta_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTB_CUENTASRow row;

                //Se verifica que no hayan asientos registrados en la cuenta
                DataTable dtAsientos = AsientosDetalleService.GetAsientosDetalleDataTable(AsientosDetalleService.CtbCuentaId_NombreCol + " = " + cuenta_id, string.Empty);
                if (dtAsientos.Rows.Count > 0)
                    throw new Exception("La cuenta no puede ser borrada porque contiene asientos registrados.");

                if (!CuentasService.EsEditable(cuenta_id, sesion))
                    throw new Exception("La cuenta no puede ser borrada porque no es editable.");

                DataTable dtCuentasHijas = CuentasService.GetCuentasDataTable(CuentasService.CtbCuentaMadreId_NombreCol + " = " + cuenta_id, string.Empty);
                if (dtCuentasHijas.Rows.Count > 0)
                    throw new Exception("La cuenta no puede ser borrada porque es madre de otras cuentas.");

                row = sesion.Db.CTB_CUENTASCollection.GetByPrimaryKey(cuenta_id);

                sesion.Db.CTB_CUENTASCollection.DeleteByPrimaryKey(cuenta_id);
                //Si la cuenta madre se ha convertido en una hoja y es editable, la misma debe ser asentable
                if (!row.IsCTB_CUENTA_MADRE_IDNull && CuentasService.GetNumeroDeHijos(row.CTB_CUENTA_MADRE_ID) == 0 && EsEditable(row.CTB_CUENTA_MADRE_ID, sesion))
                    SetAsentable(row.CTB_CUENTA_MADRE_ID, Definiciones.SiNo.Si, sesion);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
            }
        }
        #endregion borrar

        #region Borrar Cuentas

        /// <summary>
        /// Borrars the cuentas.
        /// </summary>
        /// <param name="ctb_cuenta_madre_id">The ctb_cuenta_madre_id.</param>
        private static void BorrarCuentas(decimal ctb_cuenta_madre_id)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                if (GetNumeroDeHijos(ctb_cuenta_madre_id) > 0)
                {
                    CTB_CUENTASRow[] cuentasHijas = sesion.Db.CTB_CUENTASCollection.GetByCTB_CUENTA_MADRE_ID(ctb_cuenta_madre_id);
                    for (int j = 0; j < cuentasHijas.Length; j++)
                        CuentasService.BorrarCuentas(cuentasHijas[j].ID);
                }

                CuentasService.Borrar(ctb_cuenta_madre_id);
                sesion.Db.CommitTransaction();
            }
        }

        #endregion Borrar Cuentas

        #region Accessors

        public static string Nombre_Tabla
        { get { return "CTB_CUENTAS"; } }
        public static string Nombre_Vista
        { get { return "CTB_CUENTAS_INFO_COMPLETA"; } }

        public static string Asentable_NombreCol
        { get { return CTB_CUENTASCollection.ASENTABLEColumnName; } }

        public static string CodigoBase_NombreCol
        { get { return CTB_CUENTASCollection.CODIGO_BASEColumnName; } }

        public static string Codigo_NombreCol
        { get { return CTB_CUENTASCollection.CODIGOColumnName; } }

        public static string CtbClasificacionCuentasId_NombreCol
        { get { return CTB_CUENTASCollection.CTB_CLASIFICACION_CUENTAS_IDColumnName; } }

        public static string CtbCuentaMadreId_NombreCol
        { get { return CTB_CUENTASCollection.CTB_CUENTA_MADRE_IDColumnName; } }

        public static string CtbPlanCuentaId_NombreCol
        { get { return CTB_CUENTASCollection.CTB_PLAN_CUENTA_IDColumnName; } }

        public static string Editable_NombreCol
        { get { return CTB_CUENTASCollection.EDITABLEColumnName; } }

        public static string Id_NombreCol
        { get { return CTB_CUENTASCollection.IDColumnName; } }

        public static string Nivel_NombreCol
        { get { return CTB_CUENTASCollection.NIVELColumnName; } }

        public static string Nombre_NombreCol
        { get { return CTB_CUENTASCollection.NOMBREColumnName; } }

        public static string Utilizar_NombreCol
        { get { return CTB_CUENTASCollection.UTILIZARColumnName; } }

        public static string Desglosar_NombreCol
        { get { return CTB_CUENTASCollection.DESGLOSARColumnName; } }

        public static string VistaCodigoCompleto_NombreCol
        { get { return CTB_CUENTAS_INFO_COMPLETACollection.CODIGO_COMPLETOColumnName; } }

        public static string VistaCuentaMadreNombre_NombreCol
        { get { return CTB_CUENTAS_INFO_COMPLETACollection.CTB_CUENTA_MADRE_NOMBREColumnName; } }

        public static string VistaEsCuentaDeResultados_NombreCol
        { get { return CTB_CUENTAS_INFO_COMPLETACollection.ES_CUENTA_DE_RESULTADOSColumnName; } }

        public static string VistaPlanCuentaNombre_NombreCol
        { get { return CTB_CUENTAS_INFO_COMPLETACollection.CTB_PLAN_CUENTA_NOMBREColumnName; } }

        public static string VistaCodigoCompletoSinCeros_NombreCol
        { get { return CTB_CUENTAS_INFO_COMPLETACollection.CODIGO_COMPLETO_SIN_CEROSColumnName; } }

        #endregion Accessors
    }
}
