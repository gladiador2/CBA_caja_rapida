using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Collections;

namespace CBA.FlowV2.Services.Herramientas
{
    public class MensajesDeSistemaService
    {
        #region Sub clase TiposMensajesSistema
        public class TiposMensajesSistema
        {
            #region GetTiposMensajesDataTable
            /// <summary>
            /// Gets the tipos mensajes data table.
            /// </summary>
            /// <returns></returns>
            public static DataTable GetTiposMensajesDataTable()
            {
                DataTable dt = new DataTable();

                dt.Columns.Add(TiposMensajesSistema.Id_NombreCol, typeof(decimal));
                dt.Columns.Add(TiposMensajesSistema.Nombre_NombreCol, typeof(string));

                dt.Rows.Add(Definiciones.TiposMensajesSistema.AvisoCliente, "Aviso Empresa");
                dt.Rows.Add(Definiciones.TiposMensajesSistema.AvisoIT, "Aviso Técnico");
                dt.Rows.Add(Definiciones.TiposMensajesSistema.AdvertenciaPersona, "Advertencia " + Traducciones.Persona);
                dt.Rows.Add(Definiciones.TiposMensajesSistema.AdvertenciaProveedor, "Advertencia Proveedor");
                dt.Rows.Add(Definiciones.TiposMensajesSistema.AdvertenciaFuncionario, "Advertencia " + Traducciones.Funcionario);
                dt.Rows.Add(Definiciones.TiposMensajesSistema.AdvertenciaArticulo, "Advertencia Artículo");
                dt.Rows.Add(Definiciones.TiposMensajesSistema.PromocionArticulo, "Promoción Artículo");

                return dt;
            }
            #endregion GetTiposMensajesDataTable

            #region Accessors
            public static string Id_NombreCol
            {
                get { return "ID"; }
            }
            public static string Nombre_NombreCol
            {
                get { return "NOMBRE"; }
            }
            #endregion Accessors
        }
        #endregion Sub clase TiposMensajesSistema

        #region EstaActivo
        public static bool EstaActivo(decimal departamento_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DEPARTAMENTOSRow departamento = sesion.Db.DEPARTAMENTOSCollection.GetRow(" id = " + departamento_id);
                return departamento.ESTADO == Definiciones.Estado.Activo;
            }
        }
        #endregion EstaActivo

        #region GetMensajeActivo
        /// <summary>
        /// Gets the mensaje activo.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="tipo_mensaje_id">The tipo_mensaje_id.</param>
        /// <returns></returns>
        public static string GetMensajeActivo(Hashtable campos, decimal tipo_mensaje_id)
        {
            DataTable dt;
            string mensaje;
            string clausulas = MensajesDeSistemaService.TipoMensaje_NombreCol + " = " + tipo_mensaje_id + " and " +
                               " trunc(" + MensajesDeSistemaService.FechaInicio_NombreCol + ") <= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy') and " +
                               " trunc(" + MensajesDeSistemaService.FechaFin_NombreCol + ") >= to_date('" + DateTime.Now.ToShortDateString() + "','dd/mm/yyyy') and " +
                               "( " + MensajesDeSistemaService.UsuarioId_NombreCol + " = " + (new SessionService().Usuario.ID) + " or " + MensajesDeSistemaService.UsuarioId_NombreCol + " is null) ";

            foreach (DictionaryEntry pair in campos)
            {
                switch ((string)pair.Key)
                {
                    case MENSAJES_SISTEMACollection.SUCURSAL_IDColumnName:
                        clausulas += " and (" + MensajesDeSistemaService.SucursalId_NombreCol + " = " + pair.Value + " or " + MensajesDeSistemaService.SucursalId_NombreCol + " is null) ";
                        break;
                    case MENSAJES_SISTEMACollection.SOBRE_ARTICULO_IDColumnName:
                        clausulas += " and " + MensajesDeSistemaService.SobreArticuloId_NombreCol + " = " + pair.Value;
                        break;
                    case MENSAJES_SISTEMACollection.SOBRE_FUNCIONARIO_IDColumnName:
                        clausulas += " and " + MensajesDeSistemaService.SobreFuncionarioId_NombreCol + " = " + pair.Value;
                        break;
                    case MENSAJES_SISTEMACollection.SOBRE_PERSONA_IDColumnName:
                        clausulas += " and " + MensajesDeSistemaService.SobrePersonaId_NombreCol + " = " + pair.Value;
                        break;
                    case MENSAJES_SISTEMACollection.SOBRE_PROVEEDOR_IDColumnName:
                        clausulas += " and " + MensajesDeSistemaService.SobreProveedorId_NombreCol + " = " + pair.Value;
                        break;
                    default:
                        throw new NotImplementedException("Error en MensajesDeSistemaService.GetMensajeActivo(). Columna no implementada.");
                }
            }

            dt = MensajesDeSistemaService.GetMensajesDeSistemaDataTable(clausulas, MensajesDeSistemaService.FechaInicio_NombreCol, true);

            mensaje = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0) mensaje += "\n\n";
                mensaje += dt.Rows[i][MensajesDeSistemaService.Texto_NombreCol];
            }

            return mensaje;
        }
        #endregion GetMensajeActivo

        #region GetMensajesDeSistemaDataTable
        /// <summary>
        /// Devuelve los mensajes del sistema para las clausulas dadas
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        public static DataTable GetMensajesDeSistemaDataTable(string clausulas, string orden, bool soloActivos)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table;
                String estado = " 1=1 ";
                if (soloActivos) estado = " " + MensajesDeSistemaService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                if (clausulas.Length > 0)
                {
                    table = sesion.Db.MENSAJES_SISTEMACollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                else
                {
                    table = sesion.Db.MENSAJES_SISTEMACollection.GetAsDataTable(clausulas + " and " + estado, orden);
                }
                return table;
            }
        }
        #endregion GetMensajesDeSistemaDataTable

        #region Get Mensajes afectados
        public string GetMensajesAfectados(decimal entidad_id)
        {
            string mensajes = string.Empty;
            string clausulas = string.Empty;

            //cargar las clausulas que correspondan a la entidad, no esten vencidads y no esten
            //dise;adas para una sucursal o usuario particular.
            clausulas += MensajesDeSistemaService.EntidadId_NombreCol + " = " + entidad_id.ToString() + " and " +
                         MensajesDeSistemaService.Estado_NombreCol + " = 'A' and " +
                         MensajesDeSistemaService.TipoMensaje_NombreCol + " in (" + Definiciones.TiposMensajesSistema.AvisoCliente + ", " + Definiciones.TiposMensajesSistema.AvisoIT + ") and " +
                         MensajesDeSistemaService.SucursalId_NombreCol + " is null " + " and " +
                         MensajesDeSistemaService.UsuarioId_NombreCol + " is null " + " and " +
                         MensajesDeSistemaService.RolId_NombreCol + " is null " + " and " +
                         " sysdate > " + MensajesDeSistemaService.FechaInicio_NombreCol + " and " +
                         "( sysdate < " + MensajesDeSistemaService.FechaFin_NombreCol + " or " + MensajesDeSistemaService.FechaFin_NombreCol + " is null ) ";


            DataTable datos = this.GetMensajesInfoCompleta(clausulas, MensajesDeSistemaService.FechaInicio_NombreCol + " desc" + "," + MensajesDeSistemaService.Texto_NombreCol);
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                mensajes += "<br>";
                mensajes += "<h4>Fecha:" + datos.Rows[i][MensajesDeSistemaService.FechaInicio_NombreCol].ToString() + "</h4><br>";
                mensajes += datos.Rows[i][MensajesDeSistemaService.Texto_NombreCol].ToString();
                mensajes += "<hr>";
            }
            return mensajes;
        }

        #endregion Get Mensajes afectados

        #region Get mensajes usuarios
        public DataTable GetMensajesUsuarioInfoCompleta()
        {
            string mensajes = string.Empty;
            string clausulas = string.Empty;

            
            //cargar las clausulas que correspondan a la entidad, no esten vencidads y no esten
            //dise;adas para una sucursal o usuario particular.
            //ademas darme los que no tiene due;o particuar.
            using (SessionService sesion = new SessionService())
            {
                clausulas += " (" + MensajesDeSistemaService.EntidadId_NombreCol + " = " + sesion.EntidadActual_Id + " or " + MensajesDeSistemaService.EntidadId_NombreCol + " is null ) and ";
                clausulas += " (" + MensajesDeSistemaService.SucursalId_NombreCol + " = " + sesion.SucursalActiva_Id + " or " + MensajesDeSistemaService.SucursalId_NombreCol + " is null ) and ";
                clausulas += " (" + MensajesDeSistemaService.UsuarioId_NombreCol + " = " + sesion.Usuario_Id + " or " + MensajesDeSistemaService.UsuarioId_NombreCol + " is null ) and ";
            }
            clausulas += " trunc(" + MensajesDeSistemaService.FechaInicio_NombreCol + ") <= to_date('" + DateTime.Today.ToShortDateString() + "','dd/mm/yyyy') ";
            clausulas += " and ( ";
            clausulas += " trunc(" + MensajesDeSistemaService.FechaFin_NombreCol + ") >= to_date('" + DateTime.Today.ToShortDateString() + "','dd/mm/yyyy') ";
            clausulas += " or ";
            clausulas += MensajesDeSistemaService.FechaFin_NombreCol + " is null )" + " and ";
            clausulas += MensajesDeSistemaService.Estado_NombreCol + " = 'A'";

            return this.GetMensajesInfoCompleta(clausulas, MensajesDeSistemaService.FechaInicio_NombreCol + " desc" + "," + MensajesDeSistemaService.Texto_NombreCol);
        }
               
        #endregion

        #region SetMarcarComoLeido
        public void SetMarcarComoLeido(bool leido, decimal id_mensaje)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    MENSAJES_SISTEMARow mensaje = new MENSAJES_SISTEMARow();

                    string valorAnterior = string.Empty;

                    mensaje = sesion.Db.MENSAJES_SISTEMACollection.GetRow(" " + MensajesDeSistemaService.Id_NombreCol + " = " + (decimal)id_mensaje);
                    valorAnterior = mensaje.ToString();

                    /*aca se verifica si el usuario puede realmente cambiar de leido a no leido.
                     * las condiciones son simples. Si el mensajes es privado para el puede.
                     * Se prevee que el campo LEIDO pueda tener tres valores. 'S', 'N', 'B'.
                     * El valor 'S' para marcar como leido
                     * El valor 'N'  para marcar como no leido
                     * El valor 'B' para marcar como bloqueado y que siempre este como no leido y no pueda cambiar*/

                    if (mensaje.USUARIO_ID == sesion.Usuario_Id)
                    {
                        /*if(mensaje.LEIDO != "B")
                        {
                            leido ? mensaje.LEIDO = 'S' : mensaje.LEIDO = 'N';  
                        }
                         else
                        {
                            throw new Exception("El mensaje ha sido marcado como bloqueado. No puede cambiar si estado.");
                        }
                         
                         */
                    }
                    sesion.Db.MENSAJES_SISTEMACollection.Update(mensaje);
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion SetMarcarComoLeido

        #region GetMensajesInfoCompleta
        public DataTable GetMensajesInfoCompleta(string clausulas, string orden)
        {
             try
            {
                using (SessionService sesion = new SessionService())
                {
                    DataTable dtDatos;

                     /*hay que verifiar los permisos que pueda tener la persona. Si tiene
                     * los permisos suficientes puede listar los elementos creados por otros usuarios, sino, 
                     * solo los propios. En cualquiera de los casos, la posibilidad de edicion de los
                     * mensajes esta dada por los roles de edicion y creacion.*/
                    if (sesion.Usuario != null) //se verifica que no sea null el usuario
                    {
                        if (RolesService.Tiene("mensajes sistema ver todos usuarios") == false)
                        {
                            clausulas += " and " + MensajesDeSistemaService.UsuarioCreadorID_NombreCol + " = " + sesion.Usuario_Id + " ";
                        }
                        /*else  se traen los datos para todos los usuarios.
                        { 
                        }*/
                        clausulas += " and " + MensajesDeSistemaService.EntidadId_NombreCol + " = " + sesion.EntidadActual_Id + " ";

                    }

                    dtDatos = sesion.Db.MENSAJES_SISTEMA_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);

                    return dtDatos;
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        #endregion GetMensajesInfoCompleta
       
        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    MENSAJES_SISTEMARow mensaje = new MENSAJES_SISTEMARow();
                    
                    string valorAnterior = string.Empty;
   
                    if (insertarNuevo)
                    {
                        mensaje.ID = sesion.Db.GetSiguienteSecuencia(MensajesDeSistemaService.Nombre_Secuencia);
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        mensaje.USUARIO_CREADOR_ID = sesion.Usuario_Id;
                        mensaje.ENTIDAD_ID = sesion.Entidad.ID;
                    }
                    else
                    {
                        mensaje = sesion.Db.MENSAJES_SISTEMACollection.GetByPrimaryKey((decimal)campos[MensajesDeSistemaService.Id_NombreCol]);
                        valorAnterior = mensaje.ToString();
                    }

                    mensaje.ESTADO = (string)campos[MensajesDeSistemaService.Estado_NombreCol];
                    mensaje.TEXTO = (string)campos[MensajesDeSistemaService.Texto_NombreCol];

                    mensaje.TIPO_MENSAJE = (decimal)campos[MensajesDeSistemaService.TipoMensaje_NombreCol];

                    if (campos.Contains(MensajesDeSistemaService.SobreArticuloId_NombreCol))
                        mensaje.SOBRE_ARTICULO_ID = (decimal)campos[MensajesDeSistemaService.SobreArticuloId_NombreCol];
                    else
                        mensaje.IsSOBRE_ARTICULO_IDNull = true;

                    if (campos.Contains(MensajesDeSistemaService.SobreFuncionarioId_NombreCol))
                        mensaje.SOBRE_FUNCIONARIO_ID = (decimal)campos[MensajesDeSistemaService.SobreFuncionarioId_NombreCol];
                    else
                        mensaje.IsSOBRE_FUNCIONARIO_IDNull = true;

                    if (campos.Contains(MensajesDeSistemaService.SobrePersonaId_NombreCol))
                        mensaje.SOBRE_PERSONA_ID = (decimal)campos[MensajesDeSistemaService.SobrePersonaId_NombreCol];
                    else
                        mensaje.IsSOBRE_PERSONA_IDNull = true;

                    if (campos.Contains(MensajesDeSistemaService.SobreProveedorId_NombreCol))
                        mensaje.SOBRE_PROVEEDOR_ID = (decimal)campos[MensajesDeSistemaService.SobreProveedorId_NombreCol];
                    else
                        mensaje.IsSOBRE_PROVEEDOR_IDNull = true;

                    mensaje.FECHA_INICIO = (DateTime)campos[MensajesDeSistemaService.FechaInicio_NombreCol];

                    if (campos.Contains(MensajesDeSistemaService.FechaFin_NombreCol))
                    {
                        mensaje.FECHA_FIN = (DateTime)campos[MensajesDeSistemaService.FechaFin_NombreCol];
                    }
                    else
                    {
                        mensaje.IsFECHA_FINNull = true;
                    }       

                    if(campos.Contains(MensajesDeSistemaService.RolId_NombreCol))
                        mensaje.ROL_ID = (decimal)campos[MensajesDeSistemaService.RolId_NombreCol];
                    if(campos.Contains(MensajesDeSistemaService.UsuarioId_NombreCol))
                        mensaje.USUARIO_ID = (decimal)campos[MensajesDeSistemaService.UsuarioId_NombreCol];
                    if(campos.Contains(MensajesDeSistemaService.SucursalId_NombreCol))
                        mensaje.SUCURSAL_ID = (decimal)campos[MensajesDeSistemaService.SucursalId_NombreCol];

                    if (insertarNuevo) 
                        sesion.Db.MENSAJES_SISTEMACollection.Insert(mensaje);
                    else 
                        sesion.Db.MENSAJES_SISTEMACollection.Update(mensaje);

                    LogCambiosService.LogDeRegistro(MensajesDeSistemaService.Nombre_Tabla, mensaje.ID, valorAnterior, mensaje.ToString(), sesion);

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
        public static string Nombre_Secuencia
        {
            get { return "mensajes_sistema_sqc"; }
        }

        public static string Nombre_Tabla
        {
            get { return "MENSAJES_SISTEMA"; }
        }

        public static string EntidadId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.ESTADOColumnName; }
        }
        public static string FechaFin_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.FECHA_FINColumnName; }
        }
        public static string FechaInicio_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.FECHA_INICIOColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.IDColumnName; }
        }
        public static string RolId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.ROL_IDColumnName; }
        }
        public static string SobreArticuloId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.SOBRE_ARTICULO_IDColumnName; }
        }
        public static string SobreFuncionarioId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.SOBRE_FUNCIONARIO_IDColumnName; }
        }
        public static string SobrePersonaId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.SOBRE_PERSONA_IDColumnName; }
        }
        public static string SobreProveedorId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.SOBRE_PROVEEDOR_IDColumnName; }
        }
        public static string SucursalId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.SUCURSAL_IDColumnName; }
        }
        public static string Texto_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.TEXTOColumnName; }
        }
        public static string TipoMensaje_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.TIPO_MENSAJEColumnName; }
        }
        public static string UsuarioCreadorID_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.USUARIO_CREADOR_IDColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return MENSAJES_SISTEMACollection.USUARIO_IDColumnName; }
        }
        public static string VistaEntidadNombre_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.ENTIDAD_NOMBREColumnName; }
        }
        public static string VistaSobreArticuloCodigo_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.SOBRE_ARTICULO_CODIGOColumnName; }
        }
        public static string VistaSobreFuncionarioNombre_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.SOBRE_FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaSobrePersonaNombre_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.SOBRE_PERSONA_NOMBREColumnName; }
        }
        public static string VistaSobreProveedorNombre_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.SOBRE_PROVEEDOR_NOMBREColumnName; }
        }
        public static string VistaRolDescripcion_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.ROL_DESCIPCIONColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaUsuarioNombre_NombreCol
        {
            get { return MENSAJES_SISTEMA_INFO_COMPLCollection.USUARIO_NOMBREColumnName; }
        }
        #endregion Accessors
    }
}
