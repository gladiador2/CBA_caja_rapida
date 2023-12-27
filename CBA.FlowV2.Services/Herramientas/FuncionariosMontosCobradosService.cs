using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Data;

namespace CBA.FlowV2.Services.Herramientas
{
    public class FuncionariosMontosCobradosService
    {
        #region GetFuncionariosMontosCobradosDataTable

        /// <summary>
        /// Gets the funcionarios montos cobrados data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetFuncionariosMontosCobradosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_MONTOS_COBRADOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFuncionariosMontosCobradosDataTable

        #region AgregarFuncionarioComision
        public static void AgregarFuncionarioComision(decimal id, decimal funcionarioComisionId, SessionService sesion)
        {
            FUNCIONARIOS_MONTOS_COBRADOSRow funcionarioMontoCobrado = sesion.Db.FUNCIONARIOS_MONTOS_COBRADOSCollection.GetByPrimaryKey(id);
            funcionarioMontoCobrado.FUNCIONARIO_COMISION_ID = funcionarioComisionId;
            sesion.Db.FUNCIONARIOS_MONTOS_COBRADOSCollection.Update(funcionarioMontoCobrado);
        }
        #endregion AgregarFuncionarioComision

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            try
            {
                FUNCIONARIOS_MONTOS_COBRADOSRow funcionarioMontoCobrado = new FUNCIONARIOS_MONTOS_COBRADOSRow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    funcionarioMontoCobrado.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_montos_cobra_sqc");
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                }
                else
                {
                    funcionarioMontoCobrado = sesion.Db.FUNCIONARIOS_MONTOS_COBRADOSCollection.GetByPrimaryKey((decimal)campos[Id_NombreCol]);
                    valorAnterior = funcionarioMontoCobrado.ToString();
                }

                funcionarioMontoCobrado.CASO_ID = (decimal)campos[CasoId_NombreCol];
                funcionarioMontoCobrado.COTIZACION = (decimal)campos[Cotizacion_NombreCol];
                funcionarioMontoCobrado.FECHA = (DateTime)campos[Fecha_NombreCol];
                funcionarioMontoCobrado.FUNCIONARIO_ID = (decimal)campos[FuncionarioId_NombreCol];

                if (campos.Contains(FuncionarioComisionId_NombreCol))
                {
                    funcionarioMontoCobrado.FUNCIONARIO_COMISION_ID = (decimal)campos[FuncionarioComisionId_NombreCol];
                }
                else
                {
                    funcionarioMontoCobrado.IsFUNCIONARIO_COMISION_IDNull = true;
                }

                funcionarioMontoCobrado.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
                funcionarioMontoCobrado.MONTO = (decimal)campos[Monto_NombreCol];

                if (insertarNuevo) sesion.Db.FUNCIONARIOS_MONTOS_COBRADOSCollection.Insert(funcionarioMontoCobrado);
                else sesion.Db.FUNCIONARIOS_MONTOS_COBRADOSCollection.Update(funcionarioMontoCobrado);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, funcionarioMontoCobrado.ID, valorAnterior, funcionarioMontoCobrado.ToString(), sesion);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_MONTOS_COBRADOS"; }
        }
        public static string CasoId_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.CASO_IDColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.COTIZACIONColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.FECHAColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string FuncionarioComisionId_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.FUNCIONARIO_COMISION_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return FUNCIONARIOS_MONTOS_COBRADOSCollection.MONTOColumnName; }
        }
        #endregion Accessors
    }
}
