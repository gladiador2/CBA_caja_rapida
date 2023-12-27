using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class EscalasPremiosService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="escala_premio_id">The escala_premio_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal escala_premio_id)
        {
            using (SessionService sesion = new SessionService())
            {
                ESCALAS_PREMIOSRow row = sesion.Db.ESCALAS_PREMIOSCollection.GetByPrimaryKey(escala_premio_id);
                return row.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetEscalasPremiosDataTable
        /// <summary>
        /// Gets the escalas premios data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetEscalasPremiosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EscalasPremiosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.ESCALAS_PREMIOSCollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetEscalasPremiosDataTable

        #region GetEscalasPremiosInfoCompleta
        /// <summary>
        /// Gets the escalas premios info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public DataTable GetEscalasPremiosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                string where = EscalasPremiosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID;
                if (clausulas.Length > 0) where += " and " + clausulas;

                return sesion.Db.ESCALAS_PREMIOS_INFO_COMPLETACollection.GetAsDataTable(where, orden);
            }
        }
        #endregion GetEscalasPremiosInfoCompleta

        #region GetPorcentajePremioVenta
        public decimal GetPorcentajePremioVenta(decimal porcentaje)
        {
            string clausulas = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'" +
                " and " + TipoEscalaPremioId_NombreCol + " = " + Definiciones.TiposEscalaPremios.Venta;
            DataTable dt = GetEscalasPremiosDataTable(clausulas, PorcentajeLimiteSuperior_NombreCol);

            foreach (DataRow row in dt.Rows)
            {
                if (porcentaje < (decimal)row[PorcentajeLimiteSuperior_NombreCol])
                {
                    return (decimal)row[PorcentajePremio_NombreCol];
                }
            }

            if (dt.Rows.Count == 0) 
                return 0;
            else
                return (decimal)dt.Rows[dt.Rows.Count-1][PorcentajePremio_NombreCol];
        }
        #endregion GetPorcentajePremioVenta

        #region Guardar
        public void Guardar(decimal tipo_escala_premio_id, decimal[] porcentaje_limite, decimal[] porcentaje_premio)
        { 
            decimal limite_anterior;
            System.Collections.Hashtable campos;

            #region Controles de valores en el rango
            //Se verifica que la escala este compuesta por al menos un valor
            if (porcentaje_limite.Length <= 0) throw new Exception("La escala debe contener al menos un nivel.");

            //Se verifica que todos los array tengan la misma longitud
            if(porcentaje_limite.Length != porcentaje_premio.Length)
                throw new Exception("Debe indicarse la misma cantidad de porcentajes de premios que niveles.");

            //Se comprueba que la escala termine en 100
            if (porcentaje_limite[porcentaje_limite.Length - 1] != 100) throw new Exception("El último nivel debe ser 100.");

            //Se comprueba que los porcentajes se encuentren entre 0 y 100
            //Se comprueba que la escala sea monotamente creciente
            limite_anterior = Definiciones.Error.Valor.EnteroPositivo;
            for (int i = 0; i < porcentaje_limite.Length; i++)
            {
                if (porcentaje_limite[i] < 0 || porcentaje_limite[i] > 100 || porcentaje_premio[i] < 0 || porcentaje_premio[i] > 100)
                    throw new Exception("Al menos uno de los porcentajes no se encuentra entre 0 y 100.");

                if (porcentaje_limite[i] <= limite_anterior) throw new Exception("Los límites de la escala deben ser ser creciente sin repetir valores.");

                limite_anterior = porcentaje_limite[i];
            }
            #endregion Controles de valores en el rango

            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    this.Borrar(tipo_escala_premio_id, sesion);

                    for (int i = 0; i < porcentaje_limite.Length; i++)
                    {
                        campos = new System.Collections.Hashtable();

                        campos.Add(EscalasPremiosService.TipoEscalaPremioId_NombreCol, tipo_escala_premio_id);
                        campos.Add(EscalasPremiosService.PorcentajeLimiteSuperior_NombreCol, porcentaje_limite[i]);
                        campos.Add(EscalasPremiosService.PorcentajePremio_NombreCol, porcentaje_premio[i]);

                        this.Guardar(campos, sesion);
                    }

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        private void Guardar(System.Collections.Hashtable campos, SessionService sesion)
        {
            ESCALAS_PREMIOSRow row = new ESCALAS_PREMIOSRow();
            string valorAnterior = string.Empty;
            
            row.ID = sesion.Db.GetSiguienteSecuencia("escalas_premios_sqc");
            row.ENTIDAD_ID = sesion.Entidad.ID;
            valorAnterior = Definiciones.Log.RegistroNuevo;
       
            row.ESTADO = Definiciones.Estado.Activo;
            row.PORCENTAJE_LIMITE_SUPERIOR = (decimal)campos[EscalasPremiosService.PorcentajeLimiteSuperior_NombreCol];
            row.PORCENTAJE_PREMIO = (decimal)campos[EscalasPremiosService.PorcentajePremio_NombreCol];
            row.TIPO_ESCALA_PREMIO_ID = (decimal)campos[EscalasPremiosService.TipoEscalaPremioId_NombreCol];

            sesion.Db.ESCALAS_PREMIOSCollection.Insert(row);
            LogCambiosService.LogDeRegistro(EscalasPremiosService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
        }
        #endregion Guardar

        #region Borrar
        /// <summary>
        /// Borrars the specified tipo_escala_premio_id.
        /// </summary>
        /// <param name="tipo_escala_premio_id">The tipo_escala_premio_id.</param>
        public void Borrar(decimal tipo_escala_premio_id)
        { 
            using (SessionService sesion = new SessionService())
            {
                this.Borrar(tipo_escala_premio_id, sesion);
            }
        }

        /// <summary>
        /// Borrars the specified tipo_escala_premio_id.
        /// </summary>
        /// <param name="tipo_escala_premio_id">The tipo_escala_premio_id.</param>
        /// <param name="sesion">The sesion.</param>
        private void Borrar(decimal tipo_escala_premio_id, SessionService sesion)
        {
            string clausulas = EscalasPremiosService.TipoEscalaPremioId_NombreCol + " = " + tipo_escala_premio_id + " and " +
                               EscalasPremiosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";
            ESCALAS_PREMIOSRow[] rows = sesion.Db.ESCALAS_PREMIOSCollection.GetAsArray(clausulas, string.Empty);
            string valorAnterior = string.Empty;

            for (int i = 0; i < rows.Length; i++)
            {
                valorAnterior = rows[i].ToString();
                rows[i].ESTADO = Definiciones.Estado.Inactivo;
                sesion.Db.ESCALAS_PREMIOSCollection.Update(rows[i]);
                LogCambiosService.LogDeRegistro(EscalasPremiosService.Nombre_Tabla, rows[i].ID, valorAnterior, rows[i].ToString(), sesion);
            }
        }
        #endregion Borrar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ESCALAS_PREMIOS"; }
        }
        public static string EntidadId_NombreCol
        {
            get { return ESCALAS_PREMIOSCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ESCALAS_PREMIOSCollection.ESTADOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return ESCALAS_PREMIOSCollection.IDColumnName; }
        }
        public static string PorcentajeLimiteSuperior_NombreCol
        {
            get { return ESCALAS_PREMIOSCollection.PORCENTAJE_LIMITE_SUPERIORColumnName; }
        }
        public static string PorcentajePremio_NombreCol
        {
            get { return ESCALAS_PREMIOSCollection.PORCENTAJE_PREMIOColumnName; }
        }
        public static string TipoEscalaPremioId_NombreCol
        {
            get { return ESCALAS_PREMIOSCollection.TIPO_ESCALA_PREMIO_IDColumnName; }
        }
        public static string VistaTipoEscalaPremioNombre_NombreCol
        {
            get { return ESCALAS_PREMIOS_INFO_COMPLETACollection.TIPO_ESCALA_PREMIO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
