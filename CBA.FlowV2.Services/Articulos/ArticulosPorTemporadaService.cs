using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using CBA.FlowV2.Services.Base;

namespace CBA.FlowV2.Services.Articulos
{
    public class ArticulosPorTemporadaService
    {

        #region GetArticulosInfoCompleta
        public DataTable GetArticulosPorTemporadaInfoCompleta(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {

                if (clausulas.Length == 0) clausulas = "1=1";
                if (soloActivos) clausulas += " and " + ArticulosPorTemporadaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";
                
                return sesion.Db.ARTICULOS_POR_TEMP_INF_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosPorTemporadaInfoCompleta

        #region GetArticulosInfoCompleta
        public static DataTable GetArticulosPorTemporadaInfoCompleta2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {

                if (clausulas.Length == 0) clausulas = "1=1";
                if (soloActivos) clausulas += " and " + ArticulosPorTemporadaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                return sesion.Db.ARTICULOS_POR_TEMP_INF_COMPCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosPorTemporadaInfoCompleta

        #region GetArticulosPorTemporadaDataTable
        public DataTable GetArticulosPorTemporadaDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                if (clausulas.Length == 0) clausulas = "1=1";
                if (soloActivos) clausulas += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                return sesion.Db.ARTICULOS_POR_TEMPORADACollection.GetAsDataTable(clausulas, orden);
            }
        }

        public static DataTable GetArticulosPorTemporadaDataTable2(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService()) {
                if (clausulas.Length == 0) clausulas = "1=1";
                if (soloActivos) clausulas += " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'";

                return sesion.Db.ARTICULOS_POR_TEMPORADACollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetArticulosPorTemporadaDataTable

        #region Guardar

        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                sesion.Db.BeginTransaction();
                ARTICULOS_POR_TEMPORADARow row = new ARTICULOS_POR_TEMPORADARow();
                if (insertarNuevo)
                {
                    row.ID = sesion.Db.GetSiguienteSecuencia("ARTICULOS_POR_TEMPORADA_SQC");
                }
                else
                {
                    row = sesion.Db.ARTICULOS_POR_TEMPORADACollection.GetRow(Id_NombreCol + " = " + campos[Id_NombreCol]);
                }
                
                row.FECHA_CREACION = DateTime.Now;
                row.USUARIO_CREACION_ID = sesion.Usuario_Id;

                row.ANHO = decimal.Parse(campos[Anho_NombreCol].ToString());
                row.NOMBRE_LISTA = campos[NombreLista_NombreCol].ToString();
                row.TEMPORADA_ID = decimal.Parse(campos[TemporadaId_NombreCol].ToString());
                row.ESTADO = campos[Estado_NombreCol].ToString();

                if (insertarNuevo)
                    sesion.Db.ARTICULOS_POR_TEMPORADACollection.Insert(row);
                else
                    sesion.Db.ARTICULOS_POR_TEMPORADACollection.Update(row);

                sesion.Db.CommitTransaction();
                return row.ID;

            }
        }
        #endregion Guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "ARTICULOS_POR_TEMPORADA"; }
        }

        public static string Id_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADACollection.IDColumnName; }
        }
        public static string TemporadaId_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADACollection.TEMPORADA_IDColumnName; }
        }
        public static string Anho_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADACollection.ANHOColumnName; }
        }
        public static string NombreLista_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADACollection.NOMBRE_LISTAColumnName; }
        }
        public static string UsuarioCreacion_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADACollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADACollection.FECHA_CREACIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return ARTICULOS_POR_TEMPORADACollection.ESTADOColumnName; }
        }

        public static string VistaTemporada_NombreCol
        {
            get { return ARTICULOS_POR_TEMP_INF_COMPCollection.TEMPORADAColumnName; }
        }
        public static string VistaUsuario_NombreCol
        {
            get { return ARTICULOS_POR_TEMP_INF_COMPCollection.USUARIOColumnName; }
        }

        
        #endregion Accessors
    }
}
