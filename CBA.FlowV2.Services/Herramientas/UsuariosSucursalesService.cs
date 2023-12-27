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

namespace CBA.FlowV2.Services.Herramientas
{
    public static class UsuariosSucursalesService
    {
        public static bool TieneAcceso(decimal sucursal_id, decimal usuario_id, SessionService sesion)
        {
            var sucursal = new SucursalesService(sucursal_id, sesion);
            string clausulas = UsuarioId_NombreCol + " = " + usuario_id + " and (" + SucursalId_NombreCol + " = " + sucursal_id;
            if(sucursal.RegionId.HasValue)
                clausulas += " or " + "(" + SucursalId_NombreCol + " is null and " + RegionId_NombreCol + " = " + sucursal.RegionId.Value + ")";
            clausulas += ")";
            var rows = sesion.db.USUARIOS_SUCURSALESCollection.GetAsArray(clausulas, string.Empty);
            return rows.Length > 0;
        }

        public static DataTable GetSucursalesPorUsuario(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                decimal usuarioId = usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo) ? sesion.Usuario.ID : usuario_id;

                return sesion.Db.USUARIOS_SUCURSALES_INF_COMPCollection.GetAsDataTable(UsuariosSucursalesService.UsuarioId_NombreCol +" = "+ usuarioId, UsuariosSucursalesService.SucursalId_NombreCol);

            }

        }
        public static DataTable GetRegionesPorUsuario(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetRegionesPorUsuario(usuario_id, sesion);
            }
        }

        public static DataTable GetRegionesPorUsuario(decimal usuario_id, SessionService sesion)
        {
            DataTable regiones, regiones_usuarios;
            DataTable usuarios_sucursales;
            decimal usuarioId = usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo) ? sesion.Usuario.ID : usuario_id;

            regiones = RegionesService.GetRegionesEnDataTable();
            regiones_usuarios = regiones.Clone();
            usuarios_sucursales = sesion.Db.USUARIOS_SUCURSALESCollection.GetAsDataTable(" usuario_id = " + usuarioId + " and region_id is not null ", string.Empty);

            foreach (DataRow region in regiones.Rows)
            {
                DataRow[] temp = usuarios_sucursales.Select(UsuariosService.RegionId_NombreCol + " = " + (decimal)region[RegionesService.Id_NombreCol]);
                if (temp != null && temp.Length>0)
                    regiones_usuarios.Rows.Add(region.ItemArray);
            }
            return regiones_usuarios;
        }
        
        public static DataTable FiltrarUsuariosPorRegion(decimal region_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable usuarios_sucursales, usuarios_filtrado;
                DataRow [] agregar;
                usuarios_sucursales = sesion.Db.USUARIOS_SUCURSALESCollection.GetAsDataTable( UsuariosSucursalesService.RegionId_NombreCol+ " = " + region_id, UsuariosService.RegionId_NombreCol);
                usuarios_filtrado = usuarios_sucursales.Clone();
                foreach (DataRow us in usuarios_sucursales.Rows)
                {
                    agregar = usuarios_filtrado.Select(UsuarioId_NombreCol + " = " + (decimal)us[UsuarioId_NombreCol]);
                    if (agregar.Length == 0) usuarios_filtrado.Rows.Add(us.ItemArray);
                }
                return usuarios_filtrado;
            }
        }
        public static void DesasignarSucursalAUsuariosConRegion(decimal sucursal_id, decimal region_id, SessionService sesion)
        {
            USUARIOS_SUCURSALESRow relacion = new USUARIOS_SUCURSALESRow();
            DataTable usuariosSucursalesFiltrado = FiltrarUsuariosPorRegion(region_id);
            foreach (DataRow usuario in usuariosSucursalesFiltrado.Rows)
            {
                string where = UsuarioId_NombreCol + " = " + (decimal)usuario[UsuarioId_NombreCol] +
                    " and " + SucursalId_NombreCol + " = " + sucursal_id +
                    " and " + RegionId_NombreCol + " = " + region_id;
                if ((relacion = sesion.Db.USUARIOS_SUCURSALESCollection.GetRow(where))!=null)
                {
                    sesion.Db.USUARIOS_SUCURSALESCollection.Delete(where);
                    LogCambiosService.LogDeRegistro(UsuariosSucursalesService.Nombre_Tabla, relacion.ID, relacion.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                }
            }
        }
        public static void AsignarSucursalAUsuariosConRegion(decimal sucursal_id, decimal region_id, SessionService sesion)
        {
            USUARIOS_SUCURSALESRow relacion = new USUARIOS_SUCURSALESRow ();
            DataTable usuariosSucursalesFiltrado = FiltrarUsuariosPorRegion(region_id);
            foreach (DataRow usuario in usuariosSucursalesFiltrado.Rows)
            {
                string where = UsuarioId_NombreCol + " = " + (decimal)usuario[UsuarioId_NombreCol] + 
                    " and " + SucursalId_NombreCol + " = " + sucursal_id +
                    " and " + RegionId_NombreCol + " = " + region_id;
                if (sesion.Db.USUARIOS_SUCURSALESCollection.GetAsDataTable(where, SucursalId_NombreCol).Rows.Count > 0)
                {
                    continue;
                }
                relacion.ID = sesion.Db.GetSiguienteSecuencia("usuarios_sucursales_sqc");
                relacion.SUCURSAL_ID = sucursal_id;
                relacion.REGION_ID = region_id;
                relacion.USUARIO_ID = (decimal)usuario[UsuarioId_NombreCol];
                sesion.Db.USUARIOS_SUCURSALESCollection.Insert(relacion);
                LogCambiosService.LogDeRegistro("usuarios_sucursales", Definiciones.IdNull, Definiciones.Log.RegistroNuevo, relacion.ToString(), sesion);
            }
        }
        private static void CambioDeRegionEnSucursalEnCadena(decimal sucursal_id, decimal region_nueva_id, decimal region_vieja_id, SessionService sesion)
        {
            USUARIOS_SUCURSALESRow relacion = new USUARIOS_SUCURSALESRow();
            DataTable usuariosSucursalesFiltrado = FiltrarUsuariosPorRegion(region_vieja_id);
            foreach (DataRow usuario in usuariosSucursalesFiltrado.Rows)
            {
                string where = UsuarioId_NombreCol + " = " + (decimal)usuario[UsuarioId_NombreCol] +
                    " and " + SucursalId_NombreCol + " = " + sucursal_id +
                    " and " + RegionId_NombreCol + " = " + region_vieja_id;
                if ((relacion = sesion.Db.USUARIOS_SUCURSALESCollection.GetRow(where))!=null)
                {
                    relacion.REGION_ID = region_nueva_id;
                    sesion.Db.USUARIOS_SUCURSALESCollection.Update(relacion);
                    LogCambiosService.LogDeRegistro("usuarios_sucursales", Definiciones.IdNull, Definiciones.Log.RegistroNuevo, relacion.ToString(), sesion);
                }
            }
        }
        #region Accesors
        public static readonly string Nombre_Tabla = "USUARIOS_SUCURSALES";
        public static readonly string Nombre_Vista = "USUARIOS_SUCURSALES_INF_COMP";
        public static readonly string Secuencia = "USUARIOS_SUCURSALES_SQC";
        #region Tabla
        public static readonly string Id_NombreCol = USUARIOS_SUCURSALESCollection.IDColumnName;
        public static readonly string SucursalId_NombreCol = USUARIOS_SUCURSALESCollection.SUCURSAL_IDColumnName;
        public static readonly string RegionId_NombreCol = USUARIOS_SUCURSALESCollection.REGION_IDColumnName;
        public static readonly string UsuarioId_NombreCol = USUARIOS_SUCURSALESCollection.USUARIO_IDColumnName;
        #endregion Tabla
        #region Vista
        public static readonly string VistaUsuario_NombreCol = USUARIOS_SUCURSALES_INF_COMPCollection.USUARIOColumnName;
        public static readonly string VistaRegionNombre_NombreCol = USUARIOS_SUCURSALES_INF_COMPCollection.NOMBRE_REGIONColumnName;
        public static readonly string VistaRegionAbreviatura_NombreCol = USUARIOS_SUCURSALES_INF_COMPCollection.ABREVIATURA_REGIONColumnName;
        public static readonly string VistaSucursalNombre_NombreCol = USUARIOS_SUCURSALES_INF_COMPCollection.NOMBRE_SUCURSALColumnName;
        public static readonly string VistaSucursalAbreviatura_NombreCol = USUARIOS_SUCURSALES_INF_COMPCollection.ABREVIATURA_SUCURSALColumnName;
        #endregion Vista
        #endregion Accesors
    }
}
