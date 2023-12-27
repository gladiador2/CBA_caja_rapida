#region Using
using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using System.IO;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.DetallesPersonalizados
{
    public class DetallesPersonalizadosService
    {
        #region GetDetallesPersonalizdos
        /// <summary>
        /// Gets the detalles personalizados.
        /// </summary>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="orden_descendente">if set to <c>true</c> [orden_descendente].</param>
        /// <returns></returns>
        public static decimal[] GetDetallesPersonalizados(decimal[] tipo_detalle_personalizado_id, string tabla_id, string columna, string registro_id, bool orden_descendente)
        {
            using (SessionService sesion = new SessionService())
            {
                string[] strId = Array.ConvertAll(tipo_detalle_personalizado_id, x => x.ToString());
                string clausulas = DetallesPersonalizadosService.TipoDetallePersonalizadoId_NombreCol + " in (" + string.Join(",", strId) + ") and " +
                                   DetallesPersonalizadosService.TablaId_NombreCol + " = '" + tabla_id + "' and " +
                                   DetallesPersonalizadosService.Columna_NombreCol + " = '" + columna + "' and " +
                                   DetallesPersonalizadosService.RegistroId_NombreCol + " = '" + registro_id + "' and " +
                                   DetallesPersonalizadosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                string orden = DetallesPersonalizadosService.FechaCreacion_NombreCol;
                if (orden_descendente) orden += " desc";
                
                DETALLES_PERSONALIZADOSRow[] rows = sesion.Db.DETALLES_PERSONALIZADOSCollection.GetAsArray(clausulas, orden);

                decimal[] registros = new decimal[rows.Length];

                for (int i = 0; i < registros.Length; i++)
                    registros[i] = rows[i].ID;

                return registros;
            }
        }
        #endregion GetDetallesPersonalizdos

        #region GetDetallesPersonalizadosDataTable
        /// <summary>
        /// Gets the detalles personalizados data table.
        /// </summary>
        /// <param name="tipo_detalle_personalizado_id">The tipo_detalle_personalizado_id.</param>
        /// <param name="tabla_id">The tabla_id.</param>
        /// <param name="columna">The columna.</param>
        /// <param name="registro_id">The registro_id.</param>
        /// <param name="orden_descendente">if set to <c>true</c> [orden_descendente].</param>
        /// <returns></returns>
        public static DataTable GetDetallesPersonalizadosDataTable(decimal[] tipo_detalle_personalizado_id, string tabla_id, string columna, string registro_id, bool orden_descendente)
        {
            using (SessionService sesion = new SessionService())
            {
                string[] strId = Array.ConvertAll(tipo_detalle_personalizado_id, x => x.ToString());
                string clausulas = DetallesPersonalizadosService.TipoDetallePersonalizadoId_NombreCol + " in (" + string.Join(",", strId) + ") and " +
                                   DetallesPersonalizadosService.TablaId_NombreCol + " = '" + tabla_id + "' and " +
                                   DetallesPersonalizadosService.Columna_NombreCol + " = '" + columna + "' and " +
                                   DetallesPersonalizadosService.RegistroId_NombreCol + " = '" + registro_id + "' and " +
                                   DetallesPersonalizadosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                string orden = DetallesPersonalizadosService.FechaCreacion_NombreCol;
                if (orden_descendente) orden += " desc";

                return sesion.Db.DETALLES_PERSONALIZADOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetDetallesPersonalizadosDataTable

        #region Borrar
        /// <summary>
        /// Borrars the specified detalle_personalizado_id.
        /// </summary>
        /// <param name="detalle_personalizado_id">The detalle_personalizado_id.</param>
        public static void Borrar(decimal detalle_personalizado_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DETALLES_PERSONALIZADOSRow row = sesion.Db.DETALLES_PERSONALIZADOSCollection.GetByPrimaryKey(detalle_personalizado_id);
                row.ESTADO = Definiciones.Estado.Inactivo;
                row.USUARIO_BORRADO_ID = sesion.Usuario.ID;
                row.FECHA_BORRADO = DateTime.Now;
                sesion.Db.DETALLES_PERSONALIZADOSCollection.Update(row);
            }
        }

        #endregion Borrar

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="valores">The valores.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        public static void Guardar(System.Collections.Hashtable campos, object[] valores)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DETALLES_PERSONALIZADOSRow row = new DETALLES_PERSONALIZADOSRow();
                    string valorAnterior = string.Empty;
                    string[] titulos;
                    int[] tiposDatos;
                    decimal[] orden;
                    bool[] obligatorios, disparanAlarma;
                    System.Collections.Hashtable camposDetalle;

                    if (campos.Contains(DetallesPersonalizadosService.Id_NombreCol))
                    {
                        row = sesion.Db.DETALLES_PERSONALIZADOSCollection.GetByPrimaryKey((decimal)campos[DetallesPersonalizadosService.Id_NombreCol]);
                        valorAnterior = row.ToString(); 
                    }
                    else
                    {
                        row = new DETALLES_PERSONALIZADOSRow();
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.ID = sesion.Db.GetSiguienteSecuencia("detalles_personalizados_sqc");
                        row.ESTADO = Definiciones.Estado.Activo;
                        row.FECHA_CREACION = DateTime.Now;
                        row.USUARIO_CREACION_ID = sesion.Usuario_Id;
                        row.TIPO_DETALLE_PERSONALIZADO_ID = decimal.Parse(campos[DetallesPersonalizadosService.TipoDetallePersonalizadoId_NombreCol].ToString());
                        row.TABLA_ID = (string)campos[DetallesPersonalizadosService.TablaId_NombreCol];
                        row.COLUMNA = (string)campos[DetallesPersonalizadosService.Columna_NombreCol];
                        row.REGISTRO_ID = campos[DetallesPersonalizadosService.RegistroId_NombreCol].ToString();

                        //Crear el nuevo registro
                        sesion.Db.DETALLES_PERSONALIZADOSCollection.Insert(row);
                    }

                    TiposDetallesPersonalizadosService.GetEstructura(row.TIPO_DETALLE_PERSONALIZADO_ID, out titulos, out tiposDatos, out orden, out obligatorios, out disparanAlarma);

                    if (valores.Length != orden.Length)
                        throw new Exception("DetallesPersonalizadosService.Guardar(). Existen " + valores.Length + " valores y " + orden.Length + " campos que conforman el detalle.");

                    #region Guardar los detalles segun el tipo
                    for (int i = 0; i < orden.Length; i++)
                    {
                        camposDetalle = new System.Collections.Hashtable();
                        camposDetalle.Add(DetallesPersonalizadosDetallesService.DetallePersonalizadoId_NombreCol, row.ID);
                        camposDetalle.Add(DetallesPersonalizadosDetallesService.Orden_NombreCol, decimal.Parse(i.ToString()));

                        #region Agregar campo del valor segun tipo
                        //Si el valor es null entonces al guaradar se ceran los campos
                        if (valores[i] != null)
                        {
                            switch (tiposDatos[i])
                            {
                                case TiposDetallesPersonalizadosService.TipoDato.Fecha:
                                    camposDetalle.Add(DetallesPersonalizadosDetallesService.ValorFecha_NombreCol, valores[i]);
                                    break;
                                case TiposDetallesPersonalizadosService.TipoDato.TextoCorto:
                                    camposDetalle.Add(DetallesPersonalizadosDetallesService.ValorTexto_NombreCol, valores[i]);
                                    break;
                                case TiposDetallesPersonalizadosService.TipoDato.NumeroAnho:
                                case TiposDetallesPersonalizadosService.TipoDato.NumeroCantidad:
                                case TiposDetallesPersonalizadosService.TipoDato.NumeroDia:
                                case TiposDetallesPersonalizadosService.TipoDato.NumeroLatitudLongitud:
                                case TiposDetallesPersonalizadosService.TipoDato.NumeroMes:
                                case TiposDetallesPersonalizadosService.TipoDato.NumeroMonto:
                                case TiposDetallesPersonalizadosService.TipoDato.CasoId:
                                    camposDetalle.Add(DetallesPersonalizadosDetallesService.ValorNumero_NombreCol, valores[i]);
                                    break;

                                #region Case de dominios personalizados
                                case TiposDetallesPersonalizadosService.TipoDato.SiNo:
                                case TiposDetallesPersonalizadosService.TipoDato.Estado:
                                    camposDetalle.Add(DetallesPersonalizadosDetallesService.ValorTexto_NombreCol, valores[i]);
                                    break;
                                #endregion Case de dominios personalizados

                                #region Case de campos tabla
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Proveedores_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Personas_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Abogados_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_AbogadosDet_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Sucursales_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Funcionarios_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Paises_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Departamentos_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Ciudades_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Barrios_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Moneda_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_PersonaCalificacion_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Rubro_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Activos_Id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Articulos_Familias_id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Articulos_Grupos_id:
                                case TiposDetallesPersonalizadosService.TipoDato.Campo_Articulos_Id:
                                //case TiposDetallesPersonalizadosService.TipoDato.TextoPredefinido_TipoDeInmueble:
                                    camposDetalle.Add(DetallesPersonalizadosDetallesService.ValorNumero_NombreCol, valores[i]);
                                    break;
                                #endregion Case de campos tabla

                                #region Case de detalles personalizados
                                case TiposDetallesPersonalizadosService.TipoDato.DetallePersonalizado_ProveedorPersonaAutorizada:
                                    camposDetalle.Add(DetallesPersonalizadosDetallesService.ValorNumero_NombreCol, valores[i]);
                                    break;
                                #endregion Case de detalles personalizados
                                default: throw new Exception("DetallesPersonalizadosService.Guardar(). Tipo de dato no implementado.");
                            }
                        }
                        #endregion Agregar campo del valor segun tipo

                        DetallesPersonalizadosDetallesService.Guardar(camposDetalle, !campos.Contains(DetallesPersonalizadosService.Id_NombreCol), sesion);
                    }
                    #endregion Guardar los detalles segun el tipo

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

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DETALLES_PERSONALIZADOS"; }
        }
        public static string Columna_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.COLUMNAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.ESTADOColumnName; }
        }
        public static string FechaBorrado_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.FECHA_BORRADOColumnName; }
        }
        public static string FechaCreacion_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.FECHA_CREACIONColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.IDColumnName; }
        }
        public static string TablaId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.TABLA_IDColumnName; }
        }
        public static string TipoDetallePersonalizadoId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.TIPO_DETALLE_PERSONALIZADO_IDColumnName; }
        }
        public static string RegistroId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.REGISTRO_IDColumnName; }
        }
        public static string UsuarioBorradoId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.USUARIO_BORRADO_IDColumnName; }
        }
        public static string UsuarioCreacionId_NombreCol
        {
            get { return DETALLES_PERSONALIZADOSCollection.USUARIO_CREACION_IDColumnName; }
        }
        public static string VistaTipoDetallePersNombre_NombreCol
        {
            get { return DETALLES_PERSONALIZ_INF_COMPLCollection.TIPO_DETALLE_PERS_NOMBREColumnName; }
        }
        public static string VistaUsuarioBorradoNombre_NombreCol
        {
            get { return DETALLES_PERSONALIZ_INF_COMPLCollection.USUARIO_BORRADO_NOMBREColumnName; }
        }
        public static string VistaUsuarioCreacionNombre_NombreCol
        {
            get { return DETALLES_PERSONALIZ_INF_COMPLCollection.USUARIO_CREACION_NOMBREColumnName; }
        }

        #endregion Accessors
    }
}
