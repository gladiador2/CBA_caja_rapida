using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Herramientas
{
    public class PromotoresService
    {


        public static DataTable GetPromotoresDeClientesInfoCompleta(Decimal cliente_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PROMOTORES_CLIENTES_INFO_COMPLCollection.GetAsDataTable(PromotoresService.PersonaId_NombreCol + "=" + cliente_id, PromotoresService.Id_NombreCol);


            }
        }

        public static DataTable GetClientesDePromotoresInfoCompleta(Decimal promotor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PROMOTORES_CLIENTES_INFO_COMPLCollection.GetAsDataTable(PromotoresService.FuncionarioId_NombreCol + "=" + promotor_id,PromotoresService.Id_NombreCol);
                  
                
            }
        }

        public static DataTable GetClientesDePromotoresID(Decimal promotor_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.PROMOTORES_CLIENTESCollection.GetAsDataTable(PromotoresService.FuncionarioId_NombreCol + " = " + promotor_id, PromotoresService.Id_NombreCol);
            }
        }

        #region Borrar

        public static void Borrar(decimal fila_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    
                    PROMOTORES_CLIENTESRow row = sesion.Db.PROMOTORES_CLIENTESCollection.GetByPrimaryKey(fila_id);
                    
                    sesion.Db.BeginTransaction(); 
                    
                    sesion.Db.PROMOTORES_CLIENTESCollection.Delete(row);
                    LogCambiosService.LogDeRegistro(PromotoresService.Nombre_Tabla, row.ID, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);

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

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    PROMOTORES_CLIENTESRow promotor = new PROMOTORES_CLIENTESRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        promotor.ID = sesion.Db.GetSiguienteSecuencia("PROMOTORES_CLIENTES_SQC");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                    }
                    else
                    {
                        promotor = sesion.Db.PROMOTORES_CLIENTESCollection.GetRow(Id_NombreCol + " = " + decimal.Parse((string)campos[Id_NombreCol]));
                        valorAnterior = promotor.ToString();
                    }

                    promotor.PERSONA_ID = (decimal)campos[PersonaId_NombreCol];
                    promotor.FUNCIONARIO_ID = (decimal)campos[FuncionarioId_NombreCol];


                    if (insertarNuevo) sesion.Db.PROMOTORES_CLIENTESCollection.Insert(promotor);
                    else sesion.Db.PROMOTORES_CLIENTESCollection.Update(promotor);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, promotor.ID, valorAnterior, promotor.ToString(), sesion);

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

        #region Accessors
        #region Tabla
        public static string Nombre_Tabla
        {
            get { return "PROMOTORES_CLIENTES"; }
        }
        public static string Id_NombreCol
        {
            get { return PROMOTORES_CLIENTESCollection.IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return PROMOTORES_CLIENTESCollection.PERSONA_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return PROMOTORES_CLIENTESCollection.FUNCIONARIO_IDColumnName; }
        }
        #endregion Tabla
        
        #region Vista
        
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return PROMOTORES_CLIENTES_INFO_COMPLCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaFuncionarioNombreCompleto_NombreCol
        {
            get { return PROMOTORES_CLIENTES_INFO_COMPLCollection.FUNCIONARIO_NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaClienteCodigo_NombreCol
        {
            get { return PROMOTORES_CLIENTES_INFO_COMPLCollection.PERSONA_CODIGOColumnName; }
        }
        public static string VistaClienteNombreCompleto_NombreCol
        {
            get { return PROMOTORES_CLIENTES_INFO_COMPLCollection.PERSONA_NOMBRE_COMPLETOColumnName; }
        }
        
       
        #endregion Vista


        #endregion Accessors
    }
}
