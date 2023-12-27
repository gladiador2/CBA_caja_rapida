using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Tesoreria
{
    public class CuentaCorrienteCuentasBancariasTercerosService
    {
        #region GetCuentaCorrienteBancariasTercerosDataTable
        public static DataTable GetCuentaCorrienteBancariasTercerosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetCuentaCorrienteBancariasTercerosDataTable(clausulas, orden, sesion);
            }
        }

        public static DataTable GetCuentaCorrienteBancariasTercerosDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetCuentaCorrienteBancariasTercerosDataTable

        #region GetCuentaCorrienteBancariasTercerosInfoCompleta
        public DataTable GetCuentaCorrienteBancariasTercerosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_BANCARIAS_TERC_INFO_COMCollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetStaticCuentaCorrienteBancariasTercerosInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_BANCARIAS_TERC_INFO_COMCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetCuentaCorrienteBancariasTercerosInfoCompleta

        #region ObtenerMonedaId
        public static decimal ObtenerMonedaId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_BANCARIAS_TERCEROSRow row = sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.GetByPrimaryKey(id);
                return row.MONEDA_ID;
            }
        }
        #endregion ObtenerMonedaId

        #region ObtenerPaisId
        public static decimal ObtenerPaisId(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_BANCARIAS_TERCEROSRow row = sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.GetByPrimaryKey(id);
                return row.PAIS_ID;
            }
        }
        #endregion ObtenerPaisId

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTACTE_BANCARIAS_TERCEROSRow ctacteBancaria = new CTACTE_BANCARIAS_TERCEROSRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        ctacteBancaria.ID = sesion.Db.GetSiguienteSecuencia("ctacte_bancarias_terceros_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        ctacteBancaria = sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.GetRow(Id_NombreCol + "= " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = ctacteBancaria.ToString();
                    }

                    ctacteBancaria.CIUDAD = campos[Ciudad_NombreCol].ToString();
                    ctacteBancaria.CTACTE_BANCO_ID = (decimal)campos[CtacteBancoId_NombreCol];
                    ctacteBancaria.DIRECCION = campos[Direccion_NombreCol].ToString();
                    ctacteBancaria.NUMERO_CUENTA = campos[NumeroCuenta_NombreCol].ToString();
                    if (campos.Contains(PaisId_NombreCol))
                        ctacteBancaria.PAIS_ID = (decimal)campos[PaisId_NombreCol];
                    else
                        ctacteBancaria.IsPAIS_IDNull = true;
                    ctacteBancaria.SWIFT = campos[Swift_NombreCol].ToString();

                    if (campos.Contains(PersonaId_NombreCol))
                        ctacteBancaria.PERSONA_ID = (decimal)campos[PersonaId_NombreCol];
                    else
                        ctacteBancaria.IsPERSONA_IDNull = true;

                    if (campos.Contains(FuncionarioId_NombreCol))
                        ctacteBancaria.FUNCIONARIO_ID = (decimal)campos[FuncionarioId_NombreCol];
                    else
                        ctacteBancaria.IsFUNCIONARIO_IDNull = true;

                    if (campos.Contains(ProveedorId_NombreCol))
                        ctacteBancaria.PROVEEDOR_ID = (decimal)campos[ProveedorId_NombreCol];
                    else
                        ctacteBancaria.IsPROVEEDOR_IDNull = true;

                    ctacteBancaria.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];

                    if (insertarNuevo) sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.Insert(ctacteBancaria);
                    else sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.Update(ctacteBancaria);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, ctacteBancaria.ID, valorAnterior, ctacteBancaria.ToString(), sesion);

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
        public void Borrar(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    CTACTE_BANCARIAS_TERCEROSRow row = sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.GetByPrimaryKey(id);

                    sesion.Db.CTACTE_BANCARIAS_TERCEROSCollection.Delete(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
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
            get { return "CTACTE_BANCARIAS_TERCEROS"; }
        }
        public static string Ciudad_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.CIUDADColumnName; }
        }
        public static string CtacteBancoId_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.CTACTE_BANCO_IDColumnName; }
        }
        public static string Direccion_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.DIRECCIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.IDColumnName; }
        }
        public static string NumeroCuenta_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.NUMERO_CUENTAColumnName; }
        }
        public static string PaisId_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.PAIS_IDColumnName; }
        }
        public static string Swift_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.SWIFTColumnName; }
        }
        public static string ProveedorId_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.PROVEEDOR_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.PERSONA_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERCEROSCollection.MONEDA_IDColumnName; }
        }

        public static string VistaBanco_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERC_INFO_COMCollection.BANCOColumnName; }
        }
        public static string VistaPais_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERC_INFO_COMCollection.PAISColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERC_INFO_COMCollection.MONEDA_NOMBREColumnName; }
        }
        //3542
        public static string VistaBancoCuenta_NombreCol
        {
            get { return CTACTE_BANCARIAS_TERC_INFO_COMCollection.BANCO_CUENTAColumnName; }
        }
        #endregion Accessors
    }
}
