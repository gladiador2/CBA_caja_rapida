using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;

using CBA.FlowV2.Db.Usuarios;
using CBA.FlowV2.Services.Herramientas;
using System.Collections;

namespace CBA.FlowV2.Services.Herramientas
{
    public static class UsuarioDepositoService
    {
        #region GetUsuarioDepositoDataTable

        public static DataTable GetUsuarioDepositoDataTable(string where, string orden, bool esAscendente, SessionService sesion)
        {
            string ascendente = " ASC ";
            if (esAscendente)
                ascendente = " DESC ";
            DataTable table = sesion.Db.USUARIOS_DEPOSITOSCollection.GetAsDataTable(where, orden + ascendente);
            return table;
        }

        public static DataTable GetUsuarioDepositoDataTable(string where, string orden, bool esAscendente)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsuarioDepositoDataTable(where, orden, esAscendente, sesion);
            }
        }

        public static DataTable GetUsuarioDepositoInfoCompletaDataTable(string where, string orden, bool esAscendente, SessionService sesion)
        {
            string ascendente = " ASC ";
            if (esAscendente)
                ascendente = " DESC ";
            DataTable table = sesion.Db.USUARIO_DEPOSITO_INFO_COMPLETACollection.GetAsDataTable(where, orden + ascendente);
            return table;
        }

        public static DataTable GetUsuarioDepositoInfoCompletaDataTable(string where, string orden, bool esAscendente)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsuarioDepositoInfoCompletaDataTable(where, orden, esAscendente, sesion);
            }
        }

        public static DataTable GetUsuarioDepositoPorUsuarioDataTable(decimal usuario_id, SessionService sesion)
        {
            DataTable table = sesion.Db.USUARIO_DEPOSITO_INFO_COMPLETACollection.GetAsDataTable(UsuarioDepositoService.UsuarioId_NombreCol + " = " + usuario_id, UsuarioDepositoService.DepositoId_NombreCol);
            return table;
        }

        public static DataTable GetUsuarioDepositoPorUsuarioDataTable(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsuarioDepositoPorUsuarioDataTable(usuario_id, sesion);
            }
        }

        public static DataTable GetUsuarioDepositoPorDepositoDataTable(decimal deposito_id, SessionService sesion)
        {

            DataTable table = sesion.Db.USUARIOS_DEPOSITOSCollection.GetByDEPOSITO_IDAsDataTable(deposito_id);
            return table;
        }

        public static DataTable GetUsuarioDepositoPorDepositoDataTable(decimal deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetUsuarioDepositoPorDepositoDataTable(deposito_id, sesion);
            }
        }

        #endregion GetUsuarioDepositoDataTable

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="sesion">The sesion.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos, SessionService sesion, bool insertarNuevo)
        {
            USUARIOS_DEPOSITOSRow row = new USUARIOS_DEPOSITOSRow();
            string valorAnterior = string.Empty;

            #region Validaciones
            if (!campos.Contains(UsuarioDepositoService.DepositoId_NombreCol))
                throw new Exception("Debe indicar el Deposito");
            if (!campos.Contains(UsuarioDepositoService.UsuarioId_NombreCol))
                throw new Exception("Debe indicar el Usuario");
            #endregion Validaciones

            if (insertarNuevo)
                valorAnterior = Definiciones.Log.RegistroNuevo;
            else
            {
                if (!campos.Contains(UsuarioDepositoService.Id_NombreCol))
                    throw new Exception("Debe Indicar el Id");
                row = sesion.db.USUARIOS_DEPOSITOSCollection.GetByPrimaryKey(decimal.Parse(campos[UsuarioDepositoService.Id_NombreCol].ToString()));
                valorAnterior = row.ToString();
            }

            row.DEPOSITO_ID = decimal.Parse(campos[UsuarioDepositoService.DepositoId_NombreCol].ToString());
            row.USUARIO_ID = decimal.Parse(campos[UsuarioDepositoService.UsuarioId_NombreCol].ToString());

            if (insertarNuevo)
            {
                row.ID = sesion.Db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.USUARIOS_DEPOSITOSCollection.Insert(row);
            }
            else
                sesion.db.USUARIOS_DEPOSITOSCollection.Update(row);

            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }

        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public static decimal Guardar(Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.db.BeginTransaction();
                    decimal usuarioDepositoId = Guardar(campos, sesion, insertarNuevo);
                    sesion.db.CommitTransaction();
                    return usuarioDepositoId;
                }
                catch (Exception exp)
                {
                    sesion.db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region Accesors

        public const string Nombre_Tabla = "USUARIOS_DEPOSITOS";

        public static string Nombre_Vista
        {
            get { return "usuario_deposito_info_completa"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "usuarios_depositos_SQC"; }
        }
        public static readonly string Id_NombreCol = USUARIOS_DEPOSITOSCollection.IDColumnName;
        public static readonly string DepositoId_NombreCol = USUARIOS_DEPOSITOSCollection.DEPOSITO_IDColumnName;
        public static readonly string UsuarioId_NombreCol = USUARIOS_DEPOSITOSCollection.USUARIO_IDColumnName;
        public static readonly string VistaSucursalID_NombreCol = USUARIO_DEPOSITO_INFO_COMPLETACollection.SUCURSAL_IDColumnName;
        public static readonly string VistaSucursal_NombreCol = USUARIO_DEPOSITO_INFO_COMPLETACollection.SUCURSAL_NOMBREColumnName;
        public static readonly string VistaDeposito_NombreCol = USUARIO_DEPOSITO_INFO_COMPLETACollection.DEPOSITO_NOMBREColumnName;
        public static readonly string VistaDepositoID_NombreCol = USUARIO_DEPOSITO_INFO_COMPLETACollection.DEPOSITO_IDColumnName;
        #endregion Accesors

        #region Borrar

        public static void Borrar(decimal usuario_deposito_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    USUARIOS_DEPOSITOSRow row = new USUARIOS_DEPOSITOSRow();
                    row = sesion.Db.USUARIOS_DEPOSITOSCollection.GetByPrimaryKey(usuario_deposito_id);
                    string valorAnterior = row.ToString();
                    string valorNuevo = Definiciones.Log.RegistroBorrado;

                    sesion.Db.USUARIOS_DEPOSITOSCollection.DeleteByPrimaryKey(usuario_deposito_id);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, valorNuevo, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception e)
                {
                    sesion.Db.RollbackTransaction();
                    throw e;
                }
            }
        }

        public static void BorrarSegunSucursal(decimal usuario_id, decimal sucursal_id)
        {
            DataTable usuariosDepositos = GetUsuarioDepositoInfoCompletaDataTable(UsuarioDepositoService.VistaSucursalID_NombreCol + " = " + sucursal_id + " and " + UsuarioDepositoService.UsuarioId_NombreCol + " = " + usuario_id, UsuarioDepositoService.Id_NombreCol, false);

            foreach (DataRow row in usuariosDepositos.Rows)
            {
                Borrar((decimal)row[UsuarioDepositoService.Id_NombreCol]);
            }
        }
        #endregion Borrar

    }
}
