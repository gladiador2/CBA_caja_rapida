using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System;
using CBA.FlowV2.Services.Herramientas;

namespace CBA.FlowV2.Services.Reportes
{
    public class ReportesContadoresService
    {
        #region Guardar
        public void Guardar(decimal reporte_id, string exito, CBAV2 db,string ip,decimal usuario_id) 
        {
            try
            {
                db.BeginTransaction();
                
                REPORTES_CONTADORESRow contador = new REPORTES_CONTADORESRow();
                string valorAnterior = string.Empty;
                
                contador.ID = db.GetSiguienteSecuencia("reportes_contadores_sqc");
                valorAnterior = Definiciones.Log.RegistroNuevo;
                contador.CLIENTE_IP = ip;
                contador.REPORTE_ID = reporte_id;
                contador.EXITO = exito;
                contador.FECHA = DateTime.Now;
               
                if (usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                    contador.IsUSUARIO_IDNull = true;
                else 
                    contador.USUARIO_ID = usuario_id;
                
                db.REPORTES_CONTADORESCollection.Insert(contador);
                db.CommitTransaction();
            }
            catch (Exception exp)
            {
                db.RollbackTransaction();
                throw exp;
            }
        }
        #endregion Guardar

        #region Metodos estaticos
        public static string Nombre_Tabla
        {
            get { return "REPORTE_CONTADORES"; }
        }
        public static string ReportesContadores_Id_NombreColumna
        {
            get { return REPORTES_CONTADORESCollection.IDColumnName; }
        }
        public static string ReportesContadores_Cliente_IP_NombreColumna
        {
            get { return REPORTES_CONTADORESCollection.CLIENTE_IPColumnName; }
        }
        public static string ReportesContadores_Exito_NombreColumna
        {
            get { return REPORTES_CONTADORESCollection.EXITOColumnName; }
        }
        public static string ReportesContadores_Fecha_NombreColumna
        {
            get { return REPORTES_CONTADORESCollection.FECHAColumnName; }
        }
        public static string ReportesContadores_Reporte_Id_NombreColumna
        {
            get { return REPORTES_CONTADORESCollection.REPORTE_IDColumnName; }
        }
        public static string ReportesContadores_Usuario_Id_NombreColumna
        {
            get { return REPORTES_CONTADORESCollection.USUARIO_IDColumnName; }
        }
       
        #endregion Metodos estaticos
    }
}
