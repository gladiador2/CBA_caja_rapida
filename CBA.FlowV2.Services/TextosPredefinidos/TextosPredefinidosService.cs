#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Articulos;
using CBA.FlowV2.Services.Herramientas;
using System.Drawing;
#endregion Using

namespace CBA.FlowV2.Services.TextosPredefinidos
{
    public class TextosPredefinidosService
    {
        #region GetCentroCosto
        public static decimal GetCentroCosto(decimal texto_predefinido_id, SessionService sesion)
        {
            TEXTOS_PREDEFINIDOSRow row = sesion.Db.TEXTOS_PREDEFINIDOSCollection.GetByPrimaryKey(texto_predefinido_id);
            return row.IsCENTRO_COSTO_IDNull ? Definiciones.Error.Valor.EnteroPositivo : row.CENTRO_COSTO_ID;
        }
        #endregion GetCentroCosto

        #region GetTextosPredefinidosDataTable
        public static DataTable GetDataTable(decimal tipo_id)
        {
            return GetDataTable(TipoTextoPredefinidoId_NombreCol + " = " + tipo_id + " and " + Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", Texto_NombreCol);
        }

        public static DataTable GetDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService()) {
                return sesion.Db.TEXTOS_PREDEFINIDOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetTextosPredefinidosDataTable

        #region GetTextosPredefinidosInfoCompleta
        /// <summary>
        /// Gets the Textos Predefinidos info completa.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt;

                //Realizar la busqueda sin importar tildes ni mayusculas
                sesion.Db.IniciarBusquedaFlexible();

                dt = sesion.Db.TEXTOS_PREDEFINIDOS_INFO_COMPLCollection.GetAsDataTable(clausulas, orden);

                //Finalizar el uso de busqueda sin importar tildes ni mayusculas
                sesion.Db.FinalizarBusquedaFlexible();

                return dt;
            }
        }
        #endregion GetTextosPredefinidosInfoCompleta

        #region Guardar
        /// <summary>
        /// Hace un update o insert del registro.
        /// </summary>
        /// <param name="campos">Campos del registro. Si es un update debe indicarse el id del registro</param>
        /// <param name="insertarNuevo">if set to <c>true</c> hace un insert, sino un update.</param>
        /// <returns></returns>
        public static decimal Guardar(System.Collections.Hashtable campos)
        {
            decimal id = Definiciones.Error.Valor.EnteroPositivo;
            TextosPredefinidosService textoPredefinido = new TextosPredefinidosService();
            
            #region Validaciones
            if (((string)campos[TextosPredefinidosService.Texto_NombreCol]).Length <= 0)
                throw new Exception("Debe indicar el texto");
            #endregion Validaciones

            if (!campos.Contains(TextosPredefinidosService.Id_NombreCol))
            {
                id = textoPredefinido.Guardar(campos, true);
            }
            else
            {
                id = textoPredefinido.Guardar(campos, false);
            }

            return id;
        }
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    TEXTOS_PREDEFINIDOSRow row = new TEXTOS_PREDEFINIDOSRow();
                    string valorAnterior = string.Empty;
                    
                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("textos_predefinidos_sqc");
                        valorAnterior = Definiciones.Log.RegistroNuevo;
                        row.SOLO_LECTURA = Definiciones.SiNo.No;
                    }
                    else
                    {
                        row = sesion.Db.TEXTOS_PREDEFINIDOSCollection.GetRow(TextosPredefinidosService.Id_NombreCol + " = " + campos[Id_NombreCol]);
                        valorAnterior = row.ToString();
                        if (row.SOLO_LECTURA == Definiciones.SiNo.Si)
                        {
                            throw new Exception("No se puede editar el texto predefinido por ser de solo lectura.");
                        }
                    }

                    row.TEXTO = (string)campos[TextosPredefinidosService.Texto_NombreCol];
                    row.ESTADO = (string)campos[TextosPredefinidosService.Estado_NombreCol];
                    row.SOLO_LECTURA = (string)campos[TextosPredefinidosService.SoloLectura_NombreCol];
                    row.TIPO_TEXTO_PREDEFINIDO_ID = (decimal)campos[TextosPredefinidosService.TipoTextoPredefinidoId_NombreCol];
                    
                    if (campos.Contains(TextosPredefinidosService.CentroCostoId_NombreCol))
                        row.CENTRO_COSTO_ID = (decimal)campos[TextosPredefinidosService.CentroCostoId_NombreCol];
                    else
                        row.IsCENTRO_COSTO_IDNull = true;

                    if (campos.Contains(TextosPredefinidosService.ColorHexadecimal_NombreCol))
                        row.COLOR_HEXADECIMAL = (string)campos[TextosPredefinidosService.ColorHexadecimal_NombreCol];
                    else
                        row.IsCENTRO_COSTO_IDNull = true;

                    if (insertarNuevo) sesion.Db.TEXTOS_PREDEFINIDOSCollection.Insert(row);
                    else sesion.Db.TEXTOS_PREDEFINIDOSCollection.Update(row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

                    sesion.Db.CommitTransaction();

                    return row.ID;
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
            get { return "TEXTOS_PREDEFINIDOS"; }
        }
        public static string Nombre_Vista
        {
            get { return "TEXTOS_PREDEFINIDOS_INFO_COMPL"; }
        }
        public static string CentroCostoId_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOSCollection.CENTRO_COSTO_IDColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOSCollection.IDColumnName; }
        }
        public static string Texto_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOSCollection.TEXTOColumnName; }
        }
        public static string TipoTextoPredefinidoId_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOSCollection.TIPO_TEXTO_PREDEFINIDO_IDColumnName; }
        }
        public static string SoloLectura_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOSCollection.SOLO_LECTURAColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOSCollection.ESTADOColumnName; }
        }
        public static string ColorHexadecimal_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOSCollection.COLOR_HEXADECIMALColumnName; }
        }
        public static string VistaTipoTextoPredefinidoNombre_NombreCol
        {
            get { return TEXTOS_PREDEFINIDOS_INFO_COMPLCollection.TIPO_TEXTO_PREDEFINIDO_NOMBREColumnName; }
        }
        #endregion Accessors

        #region CODIGO NUEVO ORIENTACION A OBJETOS
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static TextosPredefinidosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new TextosPredefinidosService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable
        
        #region Propiedades
        protected TEXTOS_PREDEFINIDOSRow row;
        protected TEXTOS_PREDEFINIDOSRow rowSinModificar;
        public class Modelo : TEXTOS_PREDEFINIDOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? CentroCostoId { get { if (row.IsCENTRO_COSTO_IDNull) return null; else return row.CENTRO_COSTO_ID; } set { if (value.HasValue) row.CENTRO_COSTO_ID = value.Value; else row.IsCENTRO_COSTO_IDNull = true; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string ColorHexadecimal { get { return ClaseCBABase.GetStringHelper(row.COLOR_HEXADECIMAL); } set { row.COLOR_HEXADECIMAL = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string SolorLectura { get { return row.SOLO_LECTURA; } set { row.SOLO_LECTURA = value; } }
        public string Texto { get { return row.TEXTO; } set { row.TEXTO = value; } }
        public decimal TipoTextoPredefinidoId { get { return row.TIPO_TEXTO_PREDEFINIDO_ID; } set { row.TIPO_TEXTO_PREDEFINIDO_ID = value; } }
        #endregion Propiedades

       

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TEXTOS_PREDEFINIDOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TEXTOS_PREDEFINIDOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(TEXTOS_PREDEFINIDOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
            
        }

        public TextosPredefinidosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TextosPredefinidosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TextosPredefinidosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        private TextosPredefinidosService(TEXTOS_PREDEFINIDOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores
        #endregion CODIGO NUEVO ORIENTACION A OBJETOS
    }
}




