
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using System.Collections;
using CBA.FlowV2.Services.Herramientas;


namespace CBA.FlowV2.Services.Base
{
    public class OperacionesService
    {
        #region GetOperacionesDataTable
        public static DataTable GetOperacionesDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.db.OPERACIONESCollection.GetAsDataTable(clausulas, orden);
        }

        public static DataTable GetOperacionesDataTable(decimal caso_id, string orden, SessionService sesion)
        {
            return sesion.db.OPERACIONESCollection.GetAsDataTable(OperacionesService.CasoId_NombreCol + " = " + caso_id, orden);
        }
        #endregion GetOperacionesDataTable

        #region GetOperacionesInfoCompleta
        public static DataTable GetOperacionesInfoCompletaStatic(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetOperacionesInfoCompletaStatic(clausulas, orden, sesion);
            }
        }

        public static DataTable GetOperacionesInfoCompletaStatic(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.OPERACIONES_INFO_COMPLETACollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetOperacionesInfoCompleta

        #region Insertar Operación
        /// <summary>
        /// Insertar Un registro en la tabla operaciones, ojo se debe 
        /// realizar el commit transaction desde el bloque que invoca a este metodo ya que aquí no se hace para no cerrar la transacción
        /// </summary>
        /// <param name="pCasoId">The p caso identifier.</param>
        /// <param name="pTransacion">The p transacion.</param>
        /// <param name="pEstado">The p estado.</param>
        /// <param name="pEstadoAnterior">The p estado anterior.</param>
        /// <param name="pOperacion">The p operacion.</param>
        /// <param name="pUsuarioId">The p usuario identifier.</param>
        /// <param name="pDireccionIp">The p direccion ip.</param>
        /// <param name="pFecha">The p fecha.</param>
        /// <param name="pComentario">The p comentario.</param>
        /// <param name="sesion">The sesion.</param>
        /// <exception cref="System.Exception">Error al insertar datos en la tabla Operaciones</exception>
        public static decimal InsertarOperacion(decimal pCasoId, decimal pTransacion, string pEstado, string pEstadoAnterior, decimal pOperacion,
                                      decimal pUsuarioId, string pDireccionIp, string pFecha, string pComentario,decimal comentario_texto_id, SessionService sesion)
        {

            try
            {

                OPERACIONESRow nuevaOperacion = new OPERACIONESRow();
                DateTime fecha = new DateTime();
                decimal idOperacion = sesion.db.GetSiguienteSecuencia("operaciones_SQC");


                if (pFecha.Equals(string.Empty))
                {
                    fecha = DateTime.Now;
                }
                else
                {
                    fecha = DateTime.Parse(pFecha);
                }


                nuevaOperacion.ID = idOperacion;
                nuevaOperacion.CASO_ID = pCasoId;
                nuevaOperacion.USUARIO_ID = pUsuarioId;
                nuevaOperacion.TIPO_OPERACION_ID = pOperacion;
                nuevaOperacion.FECHA = fecha;
                nuevaOperacion.ESTADO_ORIGINAL_ID = pEstadoAnterior;
                nuevaOperacion.ESTADO_RESULTANTE_ID = pEstado;
                nuevaOperacion.COMENTARIO = pComentario;
                nuevaOperacion.IP = pDireccionIp;
                nuevaOperacion.FECHA_FORMATO_NUMERO = decimal.Parse(fecha.ToString("yyyyMMdd"));

                if (pTransacion.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    nuevaOperacion.IsTRANSICION_IDNull = true;
                }
                else
                {
                    nuevaOperacion.TRANSICION_ID = pTransacion;
                }

                sesion.db.OPERACIONESCollection.Insert(nuevaOperacion);


                if (!pComentario.Equals(string.Empty) || !comentario_texto_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                {
                    COMENTARIOS_TRANSICIONESRow comentarioRow = new COMENTARIOS_TRANSICIONESRow();
                    comentarioRow.ID = sesion.db.GetSiguienteSecuencia("comentarios_transiciones_sqc");
                    comentarioRow.COMENTARIO = pComentario;
                    if (comentario_texto_id.Equals(Definiciones.Error.Valor.EnteroPositivo))
                        comentarioRow.IsCOMENTARIO_TEXTO_IDNull = true;
                    else
                        comentarioRow.COMENTARIO_TEXTO_ID = comentario_texto_id;

                    comentarioRow.FECHA = DateTime.Now;
                    comentarioRow.OPERACION_ID = nuevaOperacion.ID; ;
                    comentarioRow.ORDEN = 1;
                    comentarioRow.CASO_ID = pCasoId;
                    sesion.db.COMENTARIOS_TRANSICIONESCollection.Insert(comentarioRow);

                }


                return nuevaOperacion.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar datos en la tabla Operaciones");
            }
        }
        #endregion Insertar Operación

        #region Borrar
        /// <summary>
        /// Borrars the specified operacion_id.
        /// </summary>
        /// <param name="operacion_id">The operacion_id.</param>
        /// <param name="sesion">The sesion.</param>
        public static void Borrar(decimal operacion_id, SessionService sesion)
        {
            sesion.db.COMENTARIOS_TRANSICIONESCollection.DeleteByOPERACION_ID(operacion_id);
            sesion.db.OPERACIONESCollection.DeleteByPrimaryKey(operacion_id);
        }
        #endregion Borrar

        #region Mostrar Usuario Según Cambio De Estado

        public static string ObtenerNombreUsuario(decimal caso_id,string estado_original, string estado_resultante, SessionService sesion)
        {
            string nombreUsuario = string.Empty;

            nombreUsuario += "select oic." + OperacionesService.VistaUsuarioNombreCompleto_NombreCol + " from " + OperacionesService.Nombre_Tabla + " oic " + "\n" +
                                "where id = (select max(id) " + "\n" +
                                "              from " + OperacionesService.Nombre_Tabla + "\n" +
                                "             where " + OperacionesService.CasoId_NombreCol + "= " + caso_id +
                                "             and   " + OperacionesService.EstadoOriginalId_NombreCol + " = '" + estado_original + "' " + "\n" +
                                "             and   " + OperacionesService.EstadoResultanteId_NombreCol + " = '" + estado_resultante + "' )";
            DataTable dtNombre = sesion.db.EjecutarQuery(nombreUsuario);
            if (dtNombre.Rows.Count > 0)
                return dtNombre.Rows[0][OperacionesService.VistaUsuarioNombreCompleto_NombreCol].ToString();
            else
                return string.Empty;
        }

        #endregion Mostrar Usuario Según Cambio De Estado

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "OPERACIONES_INFO_COMPLETA"; }
        }
        public static string CasoId_NombreCol
        {
            get { return OPERACIONESCollection.CASO_IDColumnName; }
        }
        public static string Comentario_NombreCol
        {
            get { return OPERACIONESCollection.COMENTARIOColumnName; }
        }
        public static string EstadoOriginalId_NombreCol
        {
            get { return OPERACIONESCollection.ESTADO_ORIGINAL_IDColumnName; }
        }
        public static string EstadoResultanteId_NombreCol
        {
            get { return OPERACIONESCollection.ESTADO_RESULTANTE_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return OPERACIONESCollection.FECHAColumnName; }
        }
        public static string FechaFormatoNumero_NombreCol
        {
            get { return OPERACIONESCollection.FECHA_FORMATO_NUMEROColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return OPERACIONESCollection.IDColumnName; }
        }
        public static string Ip_NombreCol
        {
            get { return OPERACIONESCollection.IPColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return OPERACIONESCollection.USUARIO_IDColumnName; }
        }
        public static string TipoOperacionId_NombreCol
        {
            get { return OPERACIONESCollection.TIPO_OPERACION_IDColumnName; }
        }
        public static string TransicionId_NombreCol
        {
            get { return OPERACIONESCollection.TRANSICION_IDColumnName; }
        }
        public static string VistaCasoEstado_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.CASO_ESTADOColumnName; }
        }
        public static string VistaComentarioTipo_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.COMENTARIO_TIPOColumnName; }
        }
        public static string VistaFechaFormulario_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.FECHA_FORMULARIOColumnName; }
        }
        public static string VistaFlujoId_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.FLUJO_IDColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.PERSONA_IDColumnName; }
        }
        public static string VistaProveedorId_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.PROVEEDOR_IDColumnName; }
        }
        public static string VistaSucursalId_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaTipoOperacionNombre_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.TIPO_OPERACION_NOMBREColumnName; }
        }
        public static string VistaUsuarioNombreCompleto_NombreCol
        {
            get { return OPERACIONES_INFO_COMPLETACollection.USUARIO_NOMBRE_COMPLETOColumnName; }
        }
        #endregion Accessors
    }
}
