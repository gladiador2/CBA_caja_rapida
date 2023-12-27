using System;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Giros
{
    public class CuentaCorrientePlanesDesembolsoService
    {
        #region EstaActivo
        public static bool EstaActivo(decimal red_id)
        {
            using (SessionService sesion = new SessionService())
            {
                CTACTE_PLANES_DESEMBOLSORow condicion = sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.GetRow(Id_NombreCol + " = " + red_id);
                return condicion.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

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
                sesion.Db.BeginTransaction();

                CTACTE_PLANES_DESEMBOLSORow row = new CTACTE_PLANES_DESEMBOLSORow();
                String valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_PLANES_DESEMBOLSO_SQC");

                    if (campos.Contains(CtacteProcesadoraId_NombreCol)) 
                    {
                        row.CTACTE_PROCESADORA_ID = decimal.Parse(campos[CtacteProcesadoraId_NombreCol].ToString());
                    }

                    if (campos.Contains(CtaCteRedPagoId_NombreCol))
                    {
                        row.CTACTE_PROCESADORA_ID = decimal.Parse(campos[CtaCteRedPagoId_NombreCol].ToString());
                    }

                }
                else
                {
                    row = sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                row.NOMBRE = campos[Nombre_NombreCol].ToString();
                row.ESTADO = campos[Estado_NombreCol].ToString();
                row.CONDICION_DESEMBOLSO_ID = decimal.Parse(campos[CondicionDesembolsoId_NombreCol].ToString());
                row.DESEMBOLSO_AUTOMATICO = campos[DesembolsoAutomatico_NombreCol].ToString();
                row.POLITICA_PRIMER_DESEMBOLSO = decimal.Parse(campos[PoliticaPrimerDesembolso_NombreCol].ToString());
                row.USAR_VALIDEZ =  campos[UsarValidez_NombreCol].ToString();  
                
                if (campos.Contains(DiasDesdeInicioMes_NombreCol))
                {
                    row.DIAS_DESDE_INICIO_MES = decimal.Parse(campos[DiasDesdeInicioMes_NombreCol].ToString());
                }
                if (campos.Contains(ValidezDesde_NombreCol))
                {
                    row.VALIDEZ_DESDE = DateTime.Parse(campos[ValidezDesde_NombreCol].ToString());
                }
                if (campos.Contains(ValidezHasta_NombreCol))
                {
                    row.VALIDEZ_HASTA = DateTime.Parse(campos[ValidezHasta_NombreCol].ToString());
                }

                if (insertarNuevo) sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.Insert(row);
                else sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                sesion.Db.CommitTransaction();
            }
            catch (Exception exp)
            {
                sesion.Db.RollbackTransaction();
                throw exp;
            }
        }


          public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    CTACTE_PLANES_DESEMBOLSORow row = new CTACTE_PLANES_DESEMBOLSORow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("CTACTE_PLANES_DESEMBOLSO_SQC");
                    }
                    else
                    {
                        row = sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                        valorAnterior = row.ToString();
                    }

                    if (campos.Contains(CtacteProcesadoraId_NombreCol))
                    {
                        row.CTACTE_PROCESADORA_ID = decimal.Parse(campos[CtacteProcesadoraId_NombreCol].ToString());
                        row.IsCTACTE_RED_PAGO_IDNull = true;
                    }

                    if (campos.Contains(CtaCteRedPagoId_NombreCol))
                    {
                        row.CTACTE_RED_PAGO_ID = decimal.Parse(campos[CtaCteRedPagoId_NombreCol].ToString());
                        row.IsCTACTE_PROCESADORA_IDNull = true;
                    }

                    row.NOMBRE = campos[Nombre_NombreCol].ToString();
                    row.ESTADO = campos[Estado_NombreCol].ToString();
                    row.CONDICION_DESEMBOLSO_ID = decimal.Parse(campos[CondicionDesembolsoId_NombreCol].ToString());
                    row.DESEMBOLSO_AUTOMATICO = campos[DesembolsoAutomatico_NombreCol].ToString();
                    row.POLITICA_PRIMER_DESEMBOLSO = decimal.Parse(campos[PoliticaPrimerDesembolso_NombreCol].ToString());
                    row.USAR_VALIDEZ = campos[UsarValidez_NombreCol].ToString();

                    if (campos.Contains(DiasDesdeInicioMes_NombreCol))
                    {
                        row.DIAS_DESDE_INICIO_MES = decimal.Parse(campos[DiasDesdeInicioMes_NombreCol].ToString());
                    }
                    if (campos.Contains(ValidezDesde_NombreCol))
                    {
                        row.VALIDEZ_DESDE = DateTime.Parse(campos[ValidezDesde_NombreCol].ToString());
                    }
                    if (campos.Contains(ValidezHasta_NombreCol))
                    {
                        row.VALIDEZ_HASTA = DateTime.Parse(campos[ValidezHasta_NombreCol].ToString());
                    }

                    if (insertarNuevo) sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.Insert(row);
                    else sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.Update(row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

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
      public static void Borrar(decimal detalleId)
      {
          using (SessionService sesion = new SessionService())
          {
              try
              {
                  sesion.Db.BeginTransaction();
                  
                  CTACTE_PLANES_DESEMBOLSORow row = sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.GetByPrimaryKey(detalleId);
                  BorrarEscala(row.ID, sesion);
                  sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.Delete(row);
                  LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.IdNull, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                  
                  sesion.Db.CommitTransaction();
              }
              catch (OracleException exp)
              {
                  sesion.Db.RollbackTransaction();
                  switch (exp.Number)
                  {
                      case Definiciones.OracleNumeroExcepcion.INTEGRITY_CONSTRAINT:
                          throw new System.ArgumentException("La acción no se puede completar. Existen registros relacionados.");
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

      private static void BorrarEscala(decimal id_plan, SessionService sesion)
      {
          DataTable dt = CuentaCorrientePlanesDesembolsoEscalasService.GetPlanesDesemEscalaByIdPlan(id_plan);

          foreach (DataRow row in dt.Rows) 
          {
              CuentaCorrientePlanesDesembolsoEscalasService.Borrar((decimal)row[CuentaCorrientePlanesDesembolsoEscalasService.Id_NombreCol], sesion);
          }
      }
      #endregion Borrar

        #region GetPlanesDesembolsoDataTable
        /// <summary>
        /// Gets the activos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <param name="soloActivos">if set to <c>true</c> [solo activos].</param>
        /// <returns></returns>
        public static DataTable GetPlanesDesembolsoDataTable(string orden, bool soloActivos)
        {
            string where = string.Empty;
            if (soloActivos) where = Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
            return GetPlanesDesembolsoDataTable(where, orden);
        }

        public static DataTable GetPlanesDesembolsoDataTable(string where, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.GetAsDataTable(where, orden);
            }
        }
        public static DataTable GetAllPlanesDesembolsoDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PLANES_DESEMBOLSOCollection.GetAllAsDataTable();
            }
        }
        public static DataTable GetAllPlanesDesembolsoDataTableInfComp()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.CTACTE_PLANES_DESEMB_INFO_COMPCollection.GetAllAsDataTable();
            }
        }
        #endregion GetPlanesDesembolsoDataTable

        #region Accessors

        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "CTACTE_PLANES_DESEMBOLSO"; }
        }
        public static string Id_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.IDColumnName; }
        }
        public static string CondicionDesembolsoId_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.CONDICION_DESEMBOLSO_IDColumnName; }
        }
        public static string CtacteProcesadoraId_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.CTACTE_PROCESADORA_IDColumnName; }
        }
        public static string CtaCteRedPagoId_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.CTACTE_RED_PAGO_IDColumnName; }
        }
        public static string DesembolsoAutomatico_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.DESEMBOLSO_AUTOMATICOColumnName; }
        }
        public static string DiasDesdeInicioMes_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.DIAS_DESDE_INICIO_MESColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.ESTADOColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.NOMBREColumnName; }
        }
        public static string PoliticaPrimerDesembolso_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.POLITICA_PRIMER_DESEMBOLSOColumnName; }
        }
        public static string UsarValidez_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.USAR_VALIDEZColumnName; }
        }
        public static string ValidezDesde_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.VALIDEZ_DESDEColumnName; }
        }
        public static string ValidezHasta_NombreCol
        {
            get { return CTACTE_PLANES_DESEMBOLSOCollection.VALIDEZ_HASTAColumnName; }
        }
        #endregion Tabla

        #region Vista
        public static string VistaCondicionDesembolsoDesc_NombreCol
        {
            get { return CTACTE_PLANES_DESEMB_INFO_COMPCollection.COND_DESEMBOLSO_DESCRIPCIONColumnName; }
        }
        public static string VistaProcesadoraTarjetaNombre_NombreCol
        {
            get { return CTACTE_PLANES_DESEMB_INFO_COMPCollection.PROC_TARJETA_NOMBREColumnName; }
        }
        public static string VistaRedPagoNombre_NombreCol
        {
            get { return CTACTE_PLANES_DESEMB_INFO_COMPCollection.RED_PAGO_NOMBREColumnName; }
        }
        #endregion Vista

        #endregion Accessors
    }
}
