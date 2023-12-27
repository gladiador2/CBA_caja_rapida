using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.Data;

namespace CBA.FlowV2.Services.Herramientas
{
    public class VendedorClienteFamiliaService
    {

        #region GetVendedorClienteFamilia
        public static DataTable GetVendedorClienteFamiliaInfoCompleta(decimal PersonaId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = VendedorClienteFamiliaService.PersonaId_NombreCol + "=" + PersonaId;
                return sesion.Db.VENDEDOR_CLIENTE_FAM_INFO_COMPCollection.GetAsDataTable(clausula, string.Empty);
            }
        }

        public static DataTable GetVendedorClienteFamiliaInfoCompleta()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.VENDEDOR_CLIENTE_FAM_INFO_COMPCollection.GetAsDataTable(string.Empty, string.Empty);
            }
        }
        #endregion GetVendedorClienteFamilia

        #region GetVendedor
        public decimal GetVendedor(decimal PersonaId, decimal FamiliaId)
        {
            using (SessionService sesion = new SessionService())
            {
                string clausula = VendedorClienteFamiliaService.PersonaId_NombreCol + "=" + PersonaId + " and " +
                    VendedorClienteFamiliaService.ArticuloFamiliaId_NombreCol + "=" + FamiliaId;
                DataTable table = sesion.Db.VENDEDOR_CLIENTE_FAMILIACollection.GetAsDataTable(clausula, string.Empty);
                if (table.Rows.Count == 0)
                {
                    return Definiciones.Error.Valor.EnteroPositivo;
                }
                else
                {
                    DataRow row = table.Rows[0];
                    return decimal.Parse(row[VendedorClienteFamiliaService.FuncionarioId_NombreCol].ToString());
                }
            }
        }
        #endregion GetVendedor

        #region Constructor
        public VendedorClienteFamiliaService()
        {

        }
        #endregion Constructor

        #region Guardar
        /// <summary>
        /// Guardars the specified persona_id.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <param name="familia_id">The familia_id.</param>
        public void Guardar(decimal persona_id, decimal funcionario_id, decimal familia_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    string clausula = VendedorClienteFamiliaService.PersonaId_NombreCol + "=" + persona_id + " and " +
                    VendedorClienteFamiliaService.ArticuloFamiliaId_NombreCol + "=" + familia_id;
                    DataTable dt = sesion.Db.VENDEDOR_CLIENTE_FAMILIACollection.GetAsDataTable(clausula, string.Empty);
                    if (dt.Rows.Count > 0)
                        throw new Exception("Ya existe un vendedor asignado a la familia para el cliente.");

                    if (!FuncionariosService.EstaActivo(funcionario_id))
                        throw new Exception("El funcionarino no está activo.");

                    if (!FuncionariosService.EsVendedor(funcionario_id))
                        throw new Exception("El funcionarino no es vendedor.");

                    VENDEDOR_CLIENTE_FAMILIARow row = new VENDEDOR_CLIENTE_FAMILIARow();
                    row.ARTICULO_FAMILIA_ID = familia_id;
                    row.FUNCIONARIO_ID = funcionario_id;
                    row.PERSONA_ID = persona_id;
                    sesion.Db.VENDEDOR_CLIENTE_FAMILIACollection.Insert(row);
                    sesion.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Borrar
        public void Borrar(decimal PersonaId, decimal FuncionarioId, decimal FamiliaId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    VENDEDOR_CLIENTE_FAMILIARow row = sesion.Db.VENDEDOR_CLIENTE_FAMILIACollection.GetByPrimaryKey(FuncionarioId,PersonaId,FamiliaId);

                    sesion.Db.VENDEDOR_CLIENTE_FAMILIACollection.Delete(row);

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "VENDEDOR_CLIENTE_FAMILIA"; }
        }
        public static string ArticuloFamiliaId_NombreCol
        {
            get { return VENDEDOR_CLIENTE_FAMILIACollection.ARTICULO_FAMILIA_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return VENDEDOR_CLIENTE_FAMILIACollection.FUNCIONARIO_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return VENDEDOR_CLIENTE_FAMILIACollection.PERSONA_IDColumnName; }
        }
        public static string VistaArticuloFamiliaNombre_NombreCol
        {
            get { return VENDEDOR_CLIENTE_FAM_INFO_COMPCollection.ARTICULO_FAMILIA_NOMBREColumnName; }
        }
        public static string VistaClienteNombreCompleto_NombreCol
        {
            get { return VENDEDOR_CLIENTE_FAM_INFO_COMPCollection.CLIENTE_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaVendedorNombreCompleto_NombreCol
        {
            get { return VENDEDOR_CLIENTE_FAM_INFO_COMPCollection.VENDEDOR_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaVendedorCodigo_NombreCol
        {
            get { return VENDEDOR_CLIENTE_FAM_INFO_COMPCollection.VENDEDOR_CODIGOColumnName; }
        }
        #endregion Accessors
    }
}
