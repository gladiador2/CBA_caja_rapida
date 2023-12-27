using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.General
{
    public class TiposDocumentosIdentidadService
    {
        #region EstaActivo
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="tipo_documento_id">The tipo_documento_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(String tipo_documento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_DOCUMENTO_IDENTIDADRow tipo = sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.GetRow(Nombre_NombreCol+" = upper('" + tipo_documento_id + "')");
                return tipo.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        public static string GetNombre(string descripcion)
        {
            using (SessionService sesion = new SessionService())
            {
                TIPOS_DOCUMENTO_IDENTIDADRow tipo = sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.GetRow(Descripcion_NombreCol + " = UPPER('" + descripcion+ "')");
                return tipo.NOMBRE;
            }
        }
        #region GetTiposDataTable
        public DataTable GetTiposDataTable() 
        {
            return GetTiposDataTable(string.Empty, string.Empty);
        }

        [Obsolete("usar metodos estaticos")]
        public DataTable GetTiposDataTable(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                //Si orden esta vacio, se ordena por "nombre"
                string orderBy = orden.Length > 0 ? orden : "upper("+TiposDocumentosIdentidadService.Nombre_NombreCol+")";

                DataTable table = sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.GetAsDataTable(clausula, orderBy);
                return table;
            }
        }
        public static DataTable GetTiposDataTable2(string clausula, string orden)
        {
            using (SessionService sesion = new SessionService()) {
                //Si orden esta vacio, se ordena por "nombre"
                string orderBy = orden.Length > 0 ? orden : "upper(" + TiposDocumentosIdentidadService.Nombre_NombreCol + ")";

                DataTable table = sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.GetAsDataTable(clausula, orderBy);
                return table;
            }
        }

        #endregion GetTiposDataTable

        #region GetTiposActivos
        public DataTable GetTiposActivos()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.GetAsDataTable(Nombre_NombreCol+ "='"+ Estado_NombreCol +"'", "upper(" + Nombre_NombreCol + ")");
                return table;
            }
        }
        #endregion GetTiposActivos

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    TIPOS_DOCUMENTO_IDENTIDADRow row = new TIPOS_DOCUMENTO_IDENTIDADRow();
                    String valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        valorAnterior = Definiciones.Log.RegistroNuevo;

                        //El nombre es el ID principal, por lo que no puede
                        //modificarse si el registro ya estaba creado
                        row.NOMBRE = (string)campos[Nombre_NombreCol];
                    }
                    else
                    {
                        row = sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.GetRow(Nombre_NombreCol+" = '" + (string)campos[Nombre_NombreCol] + "'");
                        valorAnterior = row.ToString();
                    }

                    row.DESCRIPCION = (string)campos[Descripcion_NombreCol];
                    row.ESTADO = (string)campos[Estado_NombreCol];

                    if (insertarNuevo) sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.Insert(row);
                    else sesion.Db.TIPOS_DOCUMENTO_IDENTIDADCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, Definiciones.Error.Valor.EnteroPositivo, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();
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

        #region GetDigitoVerificadorRUC
        /// <summary>
        /// Gets the digito verificador RUC.
        /// </summary>
        /// <param name="numero_documento">The numero_documento.</param>
        /// <returns></returns>
        public static int GetDigitoVerificadorRUC(string numero_documento)
        {
            return GetDigitoVerificadorRUC(numero_documento, 11);
        }

        /// <summary>
        /// Gets the digito verificador RUC.
        /// </summary>
        /// <param name="numero_documento">The numero_documento.</param>
        /// <param name="base_max">The base_max.</param>
        /// <returns></returns>
        public static int GetDigitoVerificadorRUC(string numero_documento, int base_max)
        {
            int v_total, v_resto, k, v_numero_aux, v_digit;
            char[] v_numero = numero_documento.ToCharArray();
            char[] v_numero_al_char;
            string v_numero_al = "";

            for (int i = 0; i < numero_documento.Length; i++)
            {
                char c = v_numero[i];
                if (Char.IsDigit(c))
                {
                    v_numero_al += c;
                }
                else
                {
                    v_numero_al += (int)c;
                }
            }

            k = 2;
            v_total = 0;

            v_numero_al_char = v_numero_al.ToCharArray();
            for (int i = v_numero_al.Length - 1; i >= 0; i--)
            {
                k = k > base_max ? 2 : k;
                v_numero_aux = v_numero_al_char[i] - 48;
                v_total += v_numero_aux * k++;
            }

            v_resto = v_total % 11;
            v_digit = v_resto > 1 ? 11 - v_resto : 0;

            return v_digit;
        }
        #endregion GetDigitoVerificadorRUC

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "TIPOS_DOCUMENTO_IDENTIDAD"; }
        }
        public static string Descripcion_NombreCol
        {
            get { return TIPOS_DOCUMENTO_IDENTIDADCollection.DESCRIPCIONColumnName; }
        }

        public static string Estado_NombreCol
        {
            get { return TIPOS_DOCUMENTO_IDENTIDADCollection.ESTADOColumnName; }
        }

        public static string Nombre_NombreCol
        {
            get { return TIPOS_DOCUMENTO_IDENTIDADCollection.NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
