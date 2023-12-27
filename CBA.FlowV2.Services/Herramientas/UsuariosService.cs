using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Db.Usuarios;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Sesion;
using Oracle.ManagedDataAccess.Client;

namespace CBA.FlowV2.Services.Herramientas
{
    public class UsuariosService : FlujosServiceBaseWorkaround
    {
        #region Implementacion de metodos abstract
         public override int GetFlujoId()
         {
             return Definiciones.FlujosIDs.USUARIOS;
         }

         public override Dictionary<decimal, decimal> SeleccionarCentrosCosto(decimal prioridad, CasosService caso, object caso_cabecera, object caso_detalle, SessionService sesion)
         {
             Dictionary<decimal, object> campos = new Dictionary<decimal, object>();
             campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Sucursal, caso.SucursalId);
             campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Region, caso.Sucursal.RegionId);
             campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Persona, caso.PersonaId);
             campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Funcionario, caso.FuncionarioId);
             campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Proveedor, caso.ProveedorId);

             //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Deposito, );
             //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Articulo, );
             //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.TextoPredefinido, );
             //campos.Add(Definiciones.Contabilidad.TiposAsientosAutomaticosRelacionesCentroCostoPrioridad.Activo, );
             return Contabilidad.CentrosCostoService.SeleccionarCentrosCosto(prioridad, campos, sesion);
         }

         /// <summary>
         /// Funcion que debe ser implementada por cada service que hereda esta clase.
         /// Realiza las acciones necesarias al cambiar de estado un caso.
         /// </summary>
         /// <param name="caso_id">The caso_id.</param>
         /// <param name="estado_destino">The estado_destino.</param>
         /// <param name="cambio_pedido_por_usuario">El cambio fue pedido por el usuario o por el sistema</param>
         /// <param name="mensaje">The mensaje de salida.</param>
         /// <returns>
         /// True si no los controles se ejecutaron exitosamente, si no false.
         /// </returns>
         public override bool ProcesarCambioEstado(decimal caso_id, string estado_destino, bool cambio_pedido_por_usuario, out string mensaje, SessionService sesion)
        {
                bool exito = false;
                bool revisarRequisitos = false;
                mensaje = string.Empty;
                try
                {
                    CASOSRow casoRow = sesion.Db.CASOSCollection.GetByPrimaryKey(caso_id);
                    USUARIOSRow cabeceraRow = sesion.Db.USUARIOSCollection.GetByCASO_ID(caso_id)[0];

                    //Borrador a Anulado
                    if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                       estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    //Borrador a Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Borrador) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }

                    //Pendiente a Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }

                    //Pendiente a Borrador
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Borrador))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                    }

                    //Pendiente a En proceso
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.Pendiente) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.EnProceso))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }

                    //En proceso Pendiente
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Pendiente))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }

                      //En proceso Aprobado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Aprobado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }
                    // En proceso Anulado
                    else if (casoRow.ESTADO_ID.Equals(Definiciones.EstadosFlujos.EnProceso) &&
                            estado_destino.Equals(Definiciones.EstadosFlujos.Anulado))
                    {
                        //Acciones
                        //ninguna.
                        exito = true;
                        revisarRequisitos = true;
                    }

                    //Verificar si se cumplen los requisitos
                    if (exito && revisarRequisitos)
                    {
                        exito = base.VerificarRequisitosDelFlujo(caso_id, out mensaje, sesion);
                    }

                    if (exito)
                    {
                        sesion.Db.CASOSCollection.Update(casoRow);
                        sesion.Db.USUARIOSCollection.Update(cabeceraRow);
                    }
                }
                catch
                {
                    exito = false;
                    throw;
                }
                return exito;
        }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Realiza acciones necesarias una vez que se efectuo el cambio de estado
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
         public override void EjecutarAccionesLuegoDeCambioEstado(decimal caso_id, string estado_destino_id, SessionService sesion) { }

        /// <summary>
        /// Funcion que debe ser implementada por cada service que hereda esta clase.
        /// Obtener el numero de comprobante
        /// </summary>
        /// <param name="caso_id">The caso_id.</param>
        /// <returns>String con el numero de comprobante</returns>
        public override string GetNumeroComprobante(decimal caso_id, SessionService sesion)
        {
            return string.Empty;
        }
         #endregion Implementacion de metodos abstract

        #region SetUsuarioPorPersona()

        /// <summary>
        /// Sets the usuarios por persona.
        /// </summary>
        /// <param name="persona_id">The persona_id.</param>
        /// <param name="funcionario_id">The funcionario_id.</param>
        /// <param name="sesion">The sesion.</param>
        public void SetUsuariosPorPersona(FUNCIONARIOSRow funcionario, SessionService sesion)
        {
            string valorAnterior = string.Empty;
            USUARIOSRow usuario = new USUARIOSRow();
            DataTable tabla = sesion.Db.USUARIOSCollection.GetAsDataTable(" " + UsuariosService.PersonaId_NombreCol + " = " + funcionario.PERSONA_ID, string.Empty);
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    valorAnterior = usuario.ToString();
                    usuario = sesion.Db.USUARIOSCollection.GetRow(" " + UsuariosService.Id_NombreCol + " = " + tabla.Rows[i][UsuariosService.Id_NombreCol]);
                    usuario.FUNCIONARIO_ID = funcionario.ID;
                    usuario.NOMBRE = funcionario.NOMBRE;
                    usuario.APELLIDO = funcionario.APELLIDO;
                    sesion.Db.USUARIOSCollection.Update(usuario);
                    LogCambiosService.LogDeRegistro("USUARIOS", usuario.ID, valorAnterior, usuario.ToString(), sesion);
                }
            }
        }

        #endregion SetUsuarioPorpersona

        #region Metodos Estaticos
        /// <summary>
        /// Estas the activo.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        public static bool EstaActivo(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow usuario = sesion.Db.USUARIOSCollection.GetRow(UsuariosService.Id_NombreCol + " = " + usuario_id);
                return usuario.ESTADO == Definiciones.Estado.Activo;
            }
        }

        #region EsSessionActual
        /// <summary>
        /// Eses the session actual.
        /// </summary>
        /// <returns></returns>
        public static bool EsSessionActual()
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow usuario = sesion.Db.USUARIOSCollection.GetRow( UsuariosService.Id_NombreCol + " = " + sesion.Usuario_Id);
                return usuario.SESION == sesion.Usuario.SESION;
            }
        }
        #endregion EsSessionActual

        #region EsSessionMobileActual
        public static bool EsSessionMobileActual(decimal dispositivo_id, string token)
        {
            using (SessionService sesion = new SessionService())
            {
                bool exito = false;
                string tokenEnDb = DispositivosService.GetToken(dispositivo_id, sesion);
                
                exito = tokenEnDb == token;

                if (exito)
                    exito = ReglasLoginService.Validar(sesion.Usuario.ID, sesion.Usuario.USUARIO, SessionService.GetClienteIP(), ReglasLoginService.Origen.mobile);

                return exito;
            }
        }
        #endregion EsSessionMobileActual

        #region CambiarSucursalActiva
        /// <summary>
        /// Cambiars the sucursal activa.
        /// </summary>
        /// <param name="sucursal_activa">The sucursal_activa.</param>
        public void CambiarSucursalActiva(decimal sucursal_activa)
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow row;
                if (!SucursalesService.EstaActivo(sucursal_activa))
                    throw new Exception("La suscursal no está activa.");

                row = sesion.Db.USUARIOSCollection.GetByPrimaryKey(sesion.Usuario_Id);
                row.SUCURSAL_ACTIVA_ID = sucursal_activa;
                sesion.BeginTransaction();
                sesion.Db.USUARIOSCollection.Update(row);
                sesion.CommitTransaction();
            }
        }
        #endregion CambiarSucursalActiva

        #region Columnas
        public static string Nombre_Tabla
        {
            get { return "USUARIOS"; }
        }
        public static string sucursal_nombre
        {
            get { return "sucursal_nombre"; } 
        }
        public const string Region_Nombre = "region_nombre";
        public static string RegionId_NombreCol
        {
            get { return USUARIOS_SUCURSALESCollection.REGION_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return USUARIOSCollection.IDColumnName; }
        }
        public static string Nombre_NombreCol
        {
            get{return USUARIOSCollection.NOMBREColumnName;}
        }
        public static string Apellido_NombreCol
        {
            get { return USUARIOSCollection.APELLIDOColumnName; }
        }
        public static string Usuario_NombreCol
        {
            get { return USUARIOSCollection.USUARIOColumnName; }
        }
        public static string Externo_NombreCol
        {
            get{return USUARIOSCollection.EXTERNOColumnName;}
        }
        public static string Sesion_NombreCol
        {
            get{return USUARIOSCollection.SESIONColumnName;}
        }
        public static string FechaCambioPass_NombreCol
        {
            get{return USUARIOSCollection.FECHA_CAMBIO_PASSColumnName;}
        }
        public static string VidaPass_NombreCol
        {
            get{return USUARIOSCollection.VIDA_PASSColumnName;}
        }
        public static string FechaCaduPass_NombreCol
        {
            get{return USUARIOSCollection.FECHA_CADU_PASSColumnName;}
        }
        public static string UltimoLogin_NombreCol
        {
            get{return USUARIOSCollection.ULTIMO_LOGINColumnName;}
        }
        public static string EntidadId_NombreCol
        {
            get { return USUARIOSCollection.ENTIDAD_IDColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return USUARIOSCollection.ESTADOColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return USUARIOSCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return USUARIOSCollection.PERSONA_IDColumnName; }
        }
        public static string RequerirCambioContrasenha_NombreCol
        {
            get { return USUARIOSCollection.REQUERIR_CAMBIO_CONTRASENHAColumnName; }
        }
        public static string SucursalActivaId_NombreCol
        {
            get { return USUARIOSCollection.SUCURSAL_ACTIVA_IDColumnName; }
        }
        public static string Supervisor_NombreCol
        {
            get{return USUARIOSCollection.SUPERVISORColumnName;}
        }
        public static string Email_NombreCol
        {
            get{return USUARIOSCollection.EMAILColumnName;}
        }
        public static string CasoID_NombreCol
        {
            get{return USUARIOSCollection.CASO_IDColumnName;}
        }
        #endregion Columnas

        /// <summary>
        /// Gets the usuarios.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetUsuarios(string where,string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.USUARIOSCollection.GetAsDataTable(where, orden);
                return tabla;
            }
        }
        #endregion Metodos Estaticos

        #region Metodos Publicos
        #region GetUsuarios
        /// <summary>
        /// Gets the usuarios.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Utilizas métodos estáticos")]
        public DataTable GetUsuarios()
        {
            return this.GetUsuarios(true);
        }

        /// <summary>
        /// Gets the usuarios incluyendo un registro inicial "Todos".
        /// </summary>
        /// <param name="incluirRegistroTodos">if set to <c>true</c> [incluir registro todos].</param>
        /// <returns></returns>
        [Obsolete("Utilizas métodos estáticos")]
        public DataTable GetUsuarios(bool incluirRegistroTodos)
        {
            return UsuariosService.GetUsuarios("", "upper("+UsuariosService.Nombre_NombreCol+"||' '||"+UsuariosService.Apellido_NombreCol+"||' '||"+UsuariosService.Usuario_NombreCol+")", false, incluirRegistroTodos);
        }

        public static DataTable GetUsuarios2(bool incluirRegistroTodos)
        {
            return UsuariosService.GetUsuarios("", "upper(" + UsuariosService.Nombre_NombreCol + "||' '||" + UsuariosService.Apellido_NombreCol + "||' '||" + UsuariosService.Usuario_NombreCol + ")", false, incluirRegistroTodos);
        }

        /// <summary>
        /// Gets the usuarios data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <returns></returns>
        public DataTable GetUsuarios(string clausulas, string orden, bool soloActivos)
        {
            return GetUsuarios(clausulas, orden, soloActivos, false);
        }

        #region GetUsuarioPorCaso
        public DataTable GetUsuarioPorCaso(decimal caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.USUARIOSCollection.GetAsDataTable(UsuariosService.CasoID_NombreCol+ " = " + caso_id, string.Empty);
            }
        }
        public DataTable GetUsuarioPorCaso(string caso_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.USUARIOSCollection.GetAsDataTable(UsuariosService.CasoID_NombreCol + " = " + caso_id, string.Empty);
            }
        }
        #endregion GetUsuarioPorCaso

        /// <summary>
        /// Gets the usuarios data table with an user-specific where and order clauses.
        /// </summary>
        /// <param name="clausulas">The where string.</param>
        /// <param name="orden">The ordering string.</param>
        /// <param name="soloActivos">Si es true se obtienen solo los activos.</param>
        /// <param name="incluirRegistroTodos">if set to <c>true</c> [incluir registro todos].</param>
        /// <returns></returns>
        public DataTable GetUsuariosNinguno(string clausulas, string orden, bool soloActivos, bool incluirRegistroTodos)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    DataTable table;
                    string estado = " 1=1 ";
                    if (soloActivos)
                        estado = UsuariosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    if (clausulas.Length > 0)
                        clausulas += " and ";
                    clausulas += UsuariosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " ";

                    table = sesion.Db.USUARIOSCollection.GetAsDataTable(estado + " and " + clausulas, orden);

                    //Se agrega una columna concatenando nombre y apellido
                    table.Columns.Add("nombre_concatenado", typeof(String));
                    foreach (DataRow dr in table.Rows)
                    {
                        dr["nombre_concatenado"] = dr["nombre"] + " " + dr["apellido"];
                    }

                    if (incluirRegistroTodos)
                      {
                          DataRow row = table.NewRow();
                          row[UsuariosService.Id_NombreCol] = Definiciones.IdNull;
                          row[UsuariosService.Nombre_NombreCol] = "Ninguno";
                          row[UsuariosService.Apellido_NombreCol] = string.Empty;
                          row["nombre_concatenado"] = "Ninguno";
                          row[UsuariosService.Usuario_NombreCol] = string.Empty;
                          row[UsuariosService.EntidadId_NombreCol] = sesion.Entidad.ID;
                          row[UsuariosService.VidaPass_NombreCol] = 0;
                          row[UsuariosService.FechaCaduPass_NombreCol] = DateTime.Today;
                          row[UsuariosService.Estado_NombreCol] = Definiciones.Estado.Activo;
                          row[UsuariosService.RequerirCambioContrasenha_NombreCol] = Definiciones.SiNo.No;
                          row[UsuariosService.SucursalActivaId_NombreCol] = sesion.Usuario.SUCURSAL_ACTIVA_ID;
                          row[UsuariosService.Email_NombreCol] = string.Empty;
                          row[UsuariosService.CasoID_NombreCol] = Definiciones.Error.Valor.EnteroPositivo;
                         
                        table.Rows.InsertAt(row, 0);
                      }
                    return table;
                }
            }
            catch 
            {
                throw;
            }
        }
        public static DataTable GetUsuarios(string clausulas, string orden, bool soloActivos, bool incluirRegistroTodos)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    DataTable table;
                    string estado = " 1=1 ";
                    if (soloActivos)
                        estado = UsuariosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "' ";

                    if (clausulas.Length > 0)
                        clausulas += " and ";
                    if (sesion.Entidad == null)
                        clausulas += UsuariosService.EntidadId_NombreCol + " = " + sesion.EntidadActual_Id + " ";
                    else
                        clausulas += UsuariosService.EntidadId_NombreCol + " = " + sesion.Entidad.ID + " ";

                    table = sesion.Db.USUARIOSCollection.GetAsDataTable(estado + " and " + clausulas, orden);

                    //Se agrega una columna concatenando nombre y apellido
                    table.Columns.Add("nombre_concatenado", typeof(String));
                    foreach (DataRow dr in table.Rows)
                    {
                        dr["nombre_concatenado"] = dr["nombre"] + " " + dr["apellido"];
                    }

                    if (incluirRegistroTodos)
                    {
                        DataRow row = table.NewRow();
                        row[UsuariosService.Id_NombreCol] = Definiciones.IdNull;
                        row[UsuariosService.Nombre_NombreCol] = "Todos";
                        row[UsuariosService.Apellido_NombreCol] = string.Empty;
                        row["nombre_concatenado"] = "Todos";
                        row[UsuariosService.Usuario_NombreCol] = string.Empty;
                        row[UsuariosService.EntidadId_NombreCol] = sesion.Entidad.ID;
                        row[UsuariosService.VidaPass_NombreCol] = 0;
                        row[UsuariosService.FechaCaduPass_NombreCol] = DateTime.Today;
                        row[UsuariosService.Estado_NombreCol] = Definiciones.Estado.Activo;
                        row[UsuariosService.RequerirCambioContrasenha_NombreCol] = Definiciones.SiNo.No;
                        row[UsuariosService.SucursalActivaId_NombreCol] = sesion.Usuario.SUCURSAL_ACTIVA_ID;
                        row[UsuariosService.Email_NombreCol] = string.Empty;
                        row[UsuariosService.CasoID_NombreCol] = Definiciones.Error.Valor.EnteroPositivo;
                        
                        table.Rows.InsertAt(row, 0);
                    }
                    return table;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion GetUsuarios

        #region GetUsuario
        /// <summary>
        /// Gets the usuario.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        public DataTable GetUsuario(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.USUARIOSCollection.GetAsDataTable(" " + UsuariosService.Id_NombreCol + " = " + usuario_id, "");
                return tabla;
            }
        }

        /// <summary>
        /// Devuelve el usuario en funcion al nombre de usuario. Se pasa
        /// la entidad_id porque este par siempre es unico.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        public DataTable GetUsuario(string nombre_usuario, string entidad_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.USUARIOSCollection.GetAsDataTable(" " + UsuariosService.Nombre_NombreCol + " ='" + nombre_usuario + "' and " 
                                                                                    + UsuariosService.EntidadId_NombreCol + " = " + entidad_id, "");
                return tabla;
            }
        }

        
        #endregion GetUsuario

        #region GetUsuarioDataRow
        /// <summary>
        /// Gets the usuario.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        public DataRow GetUsuarioDataRow(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable tabla = sesion.Db.USUARIOSCollection.GetAsDataTable(" " + UsuariosService.Id_NombreCol + " = " + usuario_id, "");
                return tabla.Rows[0];
            }
        }
        #endregion GetUsuarioDataRow

        #region GetValidarCorrespondeEmail
        public bool GetValidarCorrespondeEmail(string usuarioProveido, string emailProveido)
        {
            using (SessionService sesion = new SessionService())
            {
                string query = " upper("+UsuariosService.Usuario_NombreCol+") ='" + usuarioProveido.ToUpper() + "' and upper("+ UsuariosService.Email_NombreCol + ")= '" + emailProveido.ToUpper() +"'";
                DataTable tabla = sesion.Db.USUARIOSCollection.GetAsDataTable(query, string.Empty);
                if (1 == tabla.Rows.Count)
                    return true;
            }
            return false;
        }

        #endregion

        #region GetNombreCompleto
        /// <summary>
        /// Get cadena concatenada: 'nombre apellido (codigo)'
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        [Obsolete("Utilizas métodos estáticos")]
        public string GetNombreCompleto(decimal usuario_id)
        {
            return UsuariosService.GetNombreCompleto2(usuario_id);
        }

        public static string GetNombreCompleto2(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNombreCompleto2(usuario_id, sesion);
            }
        }

        public static string GetNombreCompleto2(decimal usuario_id, SessionService sesion)
        {
            USUARIOSRow usuario = sesion.Db.USUARIOSCollection.GetRow(UsuariosService.Id_NombreCol + " = " + usuario_id);
            return usuario.NOMBRE + " " + usuario.APELLIDO + " (" + usuario.USUARIO + ")";
        }
        #endregion GetNombreCompleto

        #region GetUserName
        public string GetNombreUsuario(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow usuario = sesion.Db.USUARIOSCollection.GetRow(UsuariosService.Id_NombreCol + " = " + usuario_id);
                return usuario.USUARIO;
            }
        }
        #endregion GetUserName

        #region GetUserName
        public static decimal GetId(string nombre_usuario)
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow[] rows = sesion.Db.USUARIOSCollection.GetAsArray("upper(" + UsuariosService.Usuario_NombreCol + ") = '" + nombre_usuario.ToUpper() + "'", string.Empty);
                if (rows.Length > 0)
                    return rows[0].ID;
                else
                    return Definiciones.Error.Valor.EnteroPositivo;
            }
        }

        #endregion GetUserName

        #region GetPersonaId
        /// <summary>
        /// Gets the persona id.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        public decimal GetPersonaId(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow usuario = sesion.Db.USUARIOSCollection.GetByPrimaryKey(usuario_id);

                if (usuario.IsPERSONA_IDNull) 
                    return Definiciones.Error.Valor.EnteroPositivo;
                else
                    return usuario.PERSONA_ID;
            }
        }
        #endregion GetPersonaId

        #region GetFuncionarioId
        /// <summary>
        /// Gets the funcionario id.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <returns></returns>
        public static decimal GetFuncionarioId(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow usuario = sesion.Db.USUARIOSCollection.GetByPrimaryKey(usuario_id);

                if (usuario.IsFUNCIONARIO_IDNull)
                    return Definiciones.Error.Valor.EnteroPositivo;
                else
                    return usuario.FUNCIONARIO_ID;
            }
        }
        #endregion GetFuncionarioId

        #region GetSucursalesPerteneceUsuario
        public static DataTable GetSucursalesPerteneceUsuario(decimal usuario_id)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable sucursales;
                DataTable usuarios_sucursales;
                DataSet ds = new DataSet();
                DataRelation relSucursal;
                decimal usuarioId = usuario_id.Equals(Definiciones.Error.Valor.EnteroPositivo) ? sesion.Usuario.ID : usuario_id;

                sucursales = SucursalesService.GetSucursalesDataTable();
                usuarios_sucursales = sesion.Db.USUARIOS_SUCURSALESCollection.GetAsDataTable(" usuario_id = " + usuarioId, " sucursal_id ");

                ds.Tables.Add(sucursales);
                ds.Tables.Add(usuarios_sucursales);

                relSucursal = new DataRelation("relSucursal", sucursales.Columns["ID"], usuarios_sucursales.Columns["SUCURSAL_ID"]);
                ds.Relations.Add(relSucursal);
                usuarios_sucursales.Columns.Add(UsuariosService.sucursal_nombre, typeof(String));
                foreach (DataRow dr in usuarios_sucursales.Rows)
                {
                    dr[UsuariosService.sucursal_nombre] = dr.GetParentRow("relSucursal")["nombre"];
                }

                return usuarios_sucursales;
            }
        }
        #endregion GetSucursalesPerteneceUsuario

        #region ObtenerSiguienteSecuencia
        public decimal ObtenerSiguienteSecuencia()
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable seq = new DataTable();
                return sesion.Db.GetSiguienteSecuencia("usuarios_sqc");
            }
        }
        #endregion ObtenerSiguienteSecuencia

        #region Encriptar
        /// <summary>
        /// Encriptars the specified cadena.
        /// </summary>
        /// <param name="cadena">The cadena.</param>
        /// <returns></returns>
        public String Encriptar(String cadena)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable seq = new DataTable();
                seq = sesion.Db.EjecutarQuery("select encriptar('"+cadena+"') seq from dual");
                return seq.Rows[0].Field<String>(0);
            }
        }
        #endregion Encriptar

        #region GetUsuarioActual
        public decimal GetUsuarioActual()
        {
            using(SessionService sesion = new SessionService())
            {
                return sesion.Usuario_Id;
            }
        }
        #endregion GetUsuarioActual

        #region AddPerteneceRegion
        public static void AddPerteneceRegion(Decimal usuario_id, Decimal region_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    USUARIOS_SUCURSALESRow row = new USUARIOS_SUCURSALESRow();
                    row.USUARIO_ID = usuario_id;
                    row.REGION_ID = region_id;
                    sesion.Db.BeginTransaction();
                    foreach (SUCURSALESRow sucursal in SucursalesService.GetSucursalesPorRegion(region_id))
                    {
                        row.SUCURSAL_ID = sucursal.ID;
                        row.ID = sesion.Db.GetSiguienteSecuencia("usuarios_sucursales_sqc");
                        if (sesion.Db.USUARIOS_SUCURSALESCollection.GetRow("USUARIO_ID = " + usuario_id + " AND SUCURSAL_ID = " + sucursal.ID + "AND  REGION_ID = " + region_id) != null) continue;
                        sesion.Db.USUARIOS_SUCURSALESCollection.Insert(row);
                        LogCambiosService.LogDeRegistro("usuarios_sucursales", Definiciones.IdNull, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
                    }
                    sesion.Db.CommitTransaction();
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion AddPerteneceRegion

        #region RemovePerteneceRegion
        public static void RemovePerteneceRegion(decimal usuario_id, decimal region_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DataTable dt = sesion.Db.USUARIOS_SUCURSALESCollection.GetAsDataTable(" usuario_id = " + usuario_id + " and region_id = " + region_id, string.Empty);

                    foreach (DataRow row in dt.Rows)
                    {
                        USUARIOS_SUCURSALESRow aux = sesion.Db.USUARIOS_SUCURSALESCollection.GetByPrimaryKey((decimal)row[Id_NombreCol]);
                        LogCambiosService.LogDeRegistro("usuarios_sucursales", Definiciones.IdNull, aux.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    }
                    sesion.Db.USUARIOS_SUCURSALESCollection.Delete(" usuario_id = " + usuario_id + " and region_id = " + region_id);
                   
                    sesion.Db.CommitTransaction();
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion RemovePerteneceRegion

        #region AddPerteneceSucursal
        /// <summary>
        /// Indicar una sucursal a la que el usuario pertenece.
        /// </summary>
        /// <param name="usuario_id">The usuario_id.</param>
        /// <param name="sucursal_id">The sucursal_id.</param>
        public static decimal AddPerteneceSucursal(Decimal usuario_id, Decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    USUARIOS_SUCURSALESRow row = new USUARIOS_SUCURSALESRow();
                    row.ID = sesion.Db.GetSiguienteSecuencia(UsuariosSucursalesService.Secuencia);
                    row.SUCURSAL_ID = sucursal_id;
                    row.USUARIO_ID = usuario_id;
                    row.IsREGION_IDNull = true;
                    sesion.Db.USUARIOS_SUCURSALESCollection.Insert(row);

                    LogCambiosService.LogDeRegistro("usuarios_sucursales", Definiciones.IdNull, Definiciones.Log.RegistroNuevo, row.ToString(), sesion);
                    sesion.Db.CommitTransaction();
                    return row.ID;
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        public static decimal AddPerteneceSucursal(Hashtable campos )
        {
            Func<object, decimal> ObtenerDecimal = (valor) => valor is decimal ? (decimal)valor : decimal.Parse((string)valor);
            return AddPerteneceSucursal(
                    ObtenerDecimal(campos[UsuariosSucursalesService.UsuarioId_NombreCol]),
                    ObtenerDecimal(campos[UsuariosSucursalesService.SucursalId_NombreCol])
                );
        }
        [Obsolete("Utilizar métodos estáticos")]
        public void AddPerteneceSucursal2(Decimal usuario_id, Decimal sucursal_id)
        {
            UsuariosService.AddPerteneceSucursal(usuario_id, sucursal_id);
        }
        #endregion AddPerteneceSucursal2

        #region RemovePerteneceSucursal
        public void RemovePerteneceSucursal(decimal usuario_id, decimal sucursal_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    USUARIOS_SUCURSALESRow row = new USUARIOS_SUCURSALESRow();
                    row.SUCURSAL_ID = sucursal_id;
                    row.USUARIO_ID = usuario_id;

                    sesion.Db.USUARIOS_SUCURSALESCollection.Delete(" usuario_id = " + usuario_id + " and sucursal_id = " + sucursal_id + " and region_id is null");

                    LogCambiosService.LogDeRegistro("usuarios_sucursales", Definiciones.IdNull, row.ToString(), Definiciones.Log.RegistroBorrado, sesion);
                    sesion.Db.CommitTransaction();
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion RemovePerteneceSucursal

        #region SetRequerirCambioContrasenha
        public static void SetRequerirCambioContrasenha(decimal usuario_id, string requerir, SessionService sesion)
        {
            var row = sesion.db.USUARIOSCollection.GetByPrimaryKey(usuario_id);
            row.REQUERIR_CAMBIO_CONTRASENHA = requerir;
            sesion.db.USUARIOSCollection.Update(row);
        }
        #endregion SetRequerirCambioContrasenha

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo, ref decimal caso_id, ref string estado_id)
        {
            bool exito = false;
            
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    USUARIOSRow row = new USUARIOSRow();
                    string valorAnterior = string.Empty;
                    decimal dAux;

                    if (insertarNuevo)
                    {
                        row.ID = ObtenerSiguienteSecuencia();
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                      
                        CrearCasos CrearCaso = new CrearCasos(
                                                                 (int)sesion.SucursalActiva.ID, //la sucursal id
                                                                 int.Parse(Definiciones.FlujosIDs.USUARIOS.ToString()), //el nombre del flujo
                                                                 (int)sesion.Usuario_Id, //el id del usuario
                                                                 SessionService.GetClienteIP() //el ip del cliente
                                                             );

                        row.CASO_ID = int.Parse(CrearCaso.Ejecutar(sesion.Db.GetSesionAcutalDelUsuario(sesion.Usuario.USUARIO))); //el caso nuevo.
                        caso_id = row.CASO_ID; //Se copia al parametro pasado por referencia
                        estado_id = Definiciones.EstadosFlujos.Borrador; //se inicia en estado borrador.
                        row.ENTIDAD_ID = decimal.Parse(sesion.EntidadActual_Id);
                        row.SUCURSAL_ACTIVA_ID = sesion.SucursalActiva_Id;
                    }
                    else
                    {
                        row = sesion.Db.USUARIOSCollection.GetRow(UsuariosService.Id_NombreCol+ " = " + campos[UsuariosService.Id_NombreCol].ToString());
                        valorAnterior = row.ToString();
                        row.ENTIDAD_ID = decimal.Parse(campos[UsuariosService.EntidadId_NombreCol].ToString());
                        row.SUCURSAL_ACTIVA_ID = decimal.Parse(campos[UsuariosService.SucursalActivaId_NombreCol].ToString());

                    }

                    row.USUARIO = (string)campos[UsuariosService.Usuario_NombreCol];
                    row.ESTADO = (string)campos[UsuariosService.Estado_NombreCol];
                    row.REQUERIR_CAMBIO_CONTRASENHA = (string)campos[UsuariosService.RequerirCambioContrasenha_NombreCol];
                    row.APELLIDO = (string)campos[UsuariosService.Apellido_NombreCol];
                    row.NOMBRE = (string)campos[UsuariosService.Nombre_NombreCol];
                    row.EMAIL = (string)campos[UsuariosService.Email_NombreCol];
                    row.EXTERNO = (string)campos[UsuariosService.Externo_NombreCol];

                    row.FECHA_CADU_PASS = DateTime.Parse((string)campos[UsuariosService.FechaCaduPass_NombreCol]);
                    row.VIDA_PASS = decimal.Parse((string)campos[UsuariosService.VidaPass_NombreCol]);

                    if (campos.Contains(UsuariosService.PersonaId_NombreCol))
                    {
                        dAux = decimal.Parse((string)campos[UsuariosService.PersonaId_NombreCol]);
                        if (row.IsPERSONA_IDNull || row.PERSONA_ID != dAux)
                        {
                            if (PersonasService.EstaActivo(dAux))
                                row.PERSONA_ID = dAux;
                            else
                                throw new System.ArgumentException("La persona seleccionada se encuentra inactiva. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        row.IsPERSONA_IDNull = true;
                    }
                    
                    if (campos.Contains(UsuariosService.FuncionarioId_NombreCol))
                    {
                        dAux = decimal.Parse((string)campos[UsuariosService.FuncionarioId_NombreCol]);
                        if (row.IsFUNCIONARIO_IDNull || row.FUNCIONARIO_ID != dAux)
                        {
                            if (FuncionariosService.EstaActivo(dAux)) 
                                row.FUNCIONARIO_ID = dAux;
                            else 
                                throw new System.ArgumentException("El funcionario seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        row.IsFUNCIONARIO_IDNull = true;
                    }


                    if (campos.Contains(UsuariosService.Supervisor_NombreCol))
                    {
                        dAux = decimal.Parse((string)campos[UsuariosService.Supervisor_NombreCol]);
                        if (row.IsSUPERVISORNull || row.SUPERVISOR != dAux)
                        {
                            if (UsuariosService.EstaActivo(dAux)) 
                                row.SUPERVISOR = dAux;
                            else 
                                throw new System.ArgumentException("El supervisor seleccionado se encuentra inactivo. Los cambios no fueron guardados.");
                        }
                    }
                    else
                    {
                        row.IsSUPERVISORNull = true;
                    }

                    if (insertarNuevo)
                    {
                        sesion.Db.USUARIOSCollection.Insert(row);
                        sesion.Db.CommitTransaction();
                        AddPerteneceSucursal2(row.ID, row.SUCURSAL_ACTIVA_ID);
                        sesion.Db.BeginTransaction();
                        
                        EstablecerContrasena.Establecer(row.ID, (string)campos[UsuariosPasswordService.Passwd_NombreCol]);
                    }
                    else
                    {
                        sesion.Db.USUARIOSCollection.Update(row);
                        if (campos.Contains(UsuariosPasswordService.Passwd_NombreCol))
                        {
                            Cambiar_Contrasena(row.ID, (string)campos[UsuariosPasswordService.Passwd_NombreCol], sesion);
                        }

                    }

                    LogCambiosService.LogDeRegistro(UsuariosService.Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    #region Actualizar datos en tabla casos
                    Hashtable camposCaso = new Hashtable();
					camposCaso.Add(CasosService.NroComprobante_NombreCol, row.USUARIO);
                    if(!row.IsPERSONA_IDNull)
                        camposCaso.Add(CasosService.PersonaId_NombreCol, row.PERSONA_ID);
                    if(!row.IsFUNCIONARIO_IDNull)
                        camposCaso.Add(CasosService.FuncionarioId_NombreCol, row.FUNCIONARIO_ID);
                    CasosService.ActualizarCampos(row.CASO_ID, camposCaso, sesion);
                    #endregion Actualizar datos en tabla casos

                    sesion.Db.CommitTransaction();
                    sesion.Db.BeginTransaction();
                    sesion.Db.CommitTransaction();
                    
                    exito = true;
                }
                catch (OracleException exp)
                {
                    sesion.Db.RollbackTransaction();
                    switch (exp.Number)
                    {
                        case Definiciones.OracleNumeroExcepcion.UNIQUE_KEY:
                            throw new System.ArgumentException("El usuario ya existe. Elija otro nombre de usuario.");
                        default:
                            throw;
                    }
                }
                catch
                {
                    sesion.Db.RollbackTransaction();
                    throw;
                }
                return exito;
            }

        }
        #endregion guardar

        #region Cambiar_Contrasena
        private void Cambiar_Contrasena(decimal usuario_id, string passw, SessionService sesion)
        {
            string procedimientoAlamacenado = "TRC.LOGUEO.CAMBIAR_PASSWORD";

            OracleCommand cmd = new OracleCommand(procedimientoAlamacenado, sesion.Db.Connection as OracleConnection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            #region Parametros ENTRANTES
            
            cmd.Parameters.Add(new OracleParameter("p_usuario_id", OracleDbType.Int32));
            cmd.Parameters["p_usuario_id"].Direction = ParameterDirection.Input;

            cmd.Parameters.Add(new OracleParameter("nuevo_passw", OracleDbType.Varchar2, 50));
            cmd.Parameters["nuevo_passw"].Direction = ParameterDirection.Input;

            #endregion Parametros ENTRANTES

            cmd.Parameters["p_usuario_id"].Value = usuario_id;
            cmd.Parameters["nuevo_passw"].Value = passw;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        #endregion Cambiar_Contrasena

        #region GetIdSucursal por nombre de usuario
        /// <summary>
        /// Devuelve el id de la sucursal para un usuario particular. Se busca 
        /// solo por el usuario en mayusculas, no es importnate si es en minusculas o mayusculas.
        /// </summary>
        /// <param name="nombre_usuario">The nombre_usuario.</param>
        /// <returns></returns>
        public decimal GetIDSucursal(string nombre_usuario)
        {
            using (SessionService sesion = new SessionService())
            {
                USUARIOSRow usuario = sesion.Db.USUARIOSCollection.GetRow(" usuario = '" + nombre_usuario.ToUpper() + "'");
                if (usuario == null)
                    return Definiciones.Error.Valor.EnteroPositivo;
                return usuario.SUCURSAL_ACTIVA_ID;
            }
        }
        #endregion
        #endregion Metodos Publicos

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region Propiedades
        protected USUARIOSRow row;
        protected USUARIOSRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public string Apellido { get { return row.APELLIDO; } set { row.APELLIDO = value; } }
        public Decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public string Email { get { return GetStringHelper(row.EMAIL); } set { row.EMAIL = value; } }
        public decimal EntidadId { get { return row.ENTIDAD_ID; } set { row.ENTIDAD_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string Externo { get { return row.EXTERNO; } set { row.EXTERNO = value; } }
        public DateTime FechaCaduPass { get { return row.FECHA_CADU_PASS; } set { row.FECHA_CADU_PASS = value; } }
        public DateTime? FechaCambioPass { get { if (row.IsFECHA_CAMBIO_PASSNull) return null; return row.FECHA_CAMBIO_PASS; } set { if (value.HasValue) row.FECHA_CAMBIO_PASS = value.Value; else row.IsFECHA_CAMBIO_PASSNull = true; } }
        public decimal? FuncionarioId { get { if (row.IsFUNCIONARIO_IDNull) return null; return row.FUNCIONARIO_ID; } set { if (value.HasValue) row.FUNCIONARIO_ID = value.Value; else row.IsFUNCIONARIO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public decimal? PersonaId { get { if (row.IsPERSONA_IDNull) return null; return row.PERSONA_ID; } set { if (value.HasValue) row.PERSONA_ID = value.Value; else row.IsPERSONA_IDNull = true; } }
        public string RequerirCambioContrasenha { get { return row.REQUERIR_CAMBIO_CONTRASENHA; } set { row.REQUERIR_CAMBIO_CONTRASENHA = value; } }
        public decimal? Sesion { get { if (row.IsSESIONNull) return null; return row.SESION; } private set { row.SESION = value.Value; } }
        public decimal SucursalActivaId { get { return row.SUCURSAL_ACTIVA_ID; } private set { row.SUCURSAL_ACTIVA_ID = value; } }
        public decimal? Supervisor { get { if (row.IsSUPERVISORNull) return null; return row.SUPERVISOR; } set { if (value.HasValue) row.SUPERVISOR = value.Value; else row.IsSUPERVISORNull = true; } }
        public DateTime? UltimoLogin { get { if (row.IsULTIMO_LOGINNull) return null; return row.ULTIMO_LOGIN; } set { if (value.HasValue) row.ULTIMO_LOGIN = value.Value; else row.IsULTIMO_LOGINNull = true; } }
        public string Usuario { get { return row.USUARIO; } set { row.USUARIO = value; } }
        public decimal VidaPass { get { return row.VIDA_PASS; } set { row.VIDA_PASS = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private SucursalesService _sucursal;
        public SucursalesService Sucursal
        {
            get
            {
                if (this._sucursal == null)
                {
                    if (this.sesion != null)
                        this._sucursal = new SucursalesService(this.SucursalActivaId, this.sesion);
                    else
                        this._sucursal = new SucursalesService(this.SucursalActivaId);
                }
                return this._sucursal;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.USUARIOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new USUARIOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public UsuariosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public UsuariosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public UsuariosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        //#region Guardar
        //public override decimal Guardar(SessionService sesion)
        //{
        //    try
        //    {
        //        this.Validar();
        //        if (this.excepciones.ExistenErrores)
        //            return Definiciones.Error.Valor.EnteroPositivo;

        //        if (!this.ExisteEnDB)
        //        {
        //            this.row.ID = sesion.db.GetSiguienteSecuencia("usuarios_sqc");
        //            sesion.db.USUARIOSCollection.Insert(this.row);
        //            LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, null, sesion);
        //        }
        //        else
        //        {
        //            sesion.db.USUARIOSCollection.Update(this.row);
        //            LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, this.rowSinModificar, sesion);
        //        }

        //        this.rowSinModificar = this.row.Clonar();

        //        return this.row.ID;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
        //#endregion Guardar

        //#region Validar
        //public override bool Validar()
        //{
        //    

        //    return !this.excepciones.ExistenErrores;
        //}
        //#endregion Validar
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}
