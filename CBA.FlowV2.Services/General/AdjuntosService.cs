using System;
using System.IO;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;

using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;


namespace CBA.FlowV2.Services.General
{
    #region Extension
    public static class Extension
    {
        public static void CopyTo(this Stream origin, Stream destination)
        {
            int bufferSize = 81920;
            byte[] array = new byte[bufferSize];
            int count;
            while ((count = origin.Read(array, 0, array.Length)) != 0)
            {
                destination.Write(array, 0, count);
            }
        }
    }
    #endregion Extension

    public class AdjuntosService : ClaseCBA<AdjuntosService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string ComentarioCasoCasoId = "ComentarioCasoCasoId";
            public const string NombreODescripcion = "NombreODescripcion";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected ADJUNTOSRow row;
        protected ADJUNTOSRow rowSinModificar;
        public class Modelo : ADJUNTOSCollection_Base { public Modelo() : base(null) { } }
        private static string clioURL = VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ClioURL);

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? CasoId { get { if (row.IsCASO_IDNull) return null; else return row.CASO_ID; } set { if (value.HasValue) row.CASO_ID = value.Value; else row.IsCASO_IDNull = true; } }
        public string ClioUUID { get { return GetStringHelper(row.CLIO_UUID); } set { row.CLIO_UUID = value; } }
        public string Descripcion { get { return GetStringHelper(row.DESCRIPCION); } set { row.DESCRIPCION = value; } }
        public string Estado { get { return GetStringHelper(row.ESTADO); } set { row.ESTADO = value; } }
        public string Extension { get { return GetStringHelper(row.EXTENSION); } set { row.EXTENSION = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public DateTime? FechaBorrado { get { if (row.IsFECHA_BORRADONull) return null; else return row.FECHA_BORRADO; } set { if (value.HasValue) row.FECHA_BORRADO = value.Value; else row.IsFECHA_BORRADONull = true; } }
        public DateTime? FechaUltimaEdicion { get { if (row.IsFECHA_ULTIMA_EDICIONNull) return null; else return row.FECHA_ULTIMA_EDICION; } set { if (value.HasValue) row.FECHA_ULTIMA_EDICION = value.Value; else row.IsFECHA_ULTIMA_EDICIONNull = true; } }
        public string Grupo { get { return GetStringHelper(row.GRUPO); } set { row.GRUPO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string MotivoBorrado { get { return GetStringHelper(row.MOTIVO_BORRADO); } set { row.MOTIVO_BORRADO = value; } }
        public string NombreArchivo { get { return GetStringHelper(row.NOMBRE_ARCHIVO); } set { row.NOMBRE_ARCHIVO = value; } }
        public string Principal { get { return GetStringHelper(row.PRINCIPAL); } set { row.PRINCIPAL = value; } }
        public decimal? Registro { get { if (row.IsREGISTRONull) return null; else return row.REGISTRO; } set { if (value.HasValue) row.REGISTRO = value.Value; else row.IsREGISTRONull = true; } }
        public string TablaId { get { return GetStringHelper(row.TABLA_ID); } set { row.TABLA_ID = value; } }
        public decimal TipoAdjuntoId { get { return row.TIPO_ADJUNTO_ID; } set { row.TIPO_ADJUNTO_ID = value; } }
        public string TipoMime { get { return GetStringHelper(row.TIPO_MIME); } set { row.TIPO_MIME = value; } }
        public string TipoPrivacidad { get { return GetStringHelper(row.TIPO_PRIVACIDAD); } set { row.TIPO_PRIVACIDAD = value; } }
        public decimal? UsuarioBorradoId { get { if (row.IsUSUARIO_BORRADO_IDNull) return null; else return row.USUARIO_BORRADO_ID; } set { if (value.HasValue) row.USUARIO_BORRADO_ID = value.Value; else row.IsUSUARIO_BORRADO_IDNull = true; } }
        public decimal UsuarioId { get { return row.USUARIO_ID; } set { row.USUARIO_ID = value; } }
        public decimal? UsuarioUltimaEdicionId { get { if (row.IsUSUARIO_ULTIMA_EDICION_IDNull) return null; else return row.USUARIO_ULTIMA_EDICION_ID; } set { if (value.HasValue) row.USUARIO_ULTIMA_EDICION_ID = value.Value; else row.IsUSUARIO_ULTIMA_EDICION_IDNull = true; } }
        public string PathTemporal { get { return GetStringHelper(row.PATH_TEMPORAL); } set { row.PATH_TEMPORAL = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        public string Path { get { return clioURL + "/conseguir/" + this.ClioUUID; } }
        
        private CasosService _caso;
        public CasosService Caso
        {
            get
            {
                if (this._caso == null)
                    this._caso = new CasosService(this.CasoId.Value);
                return this._caso;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.ADJUNTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new ADJUNTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ADJUNTOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public AdjuntosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AdjuntosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AdjuntosService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private AdjuntosService(ADJUNTOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (this.TipoMime != GetStringHelper(this.rowSinModificar.TIPO_MIME))
                this.TipoMime = ObtenerTipoMIMESegunExtension(this.Extension);

            //Una entidad (caso o <tabla, registro> no puede tener más de un adjunto marcado como principal
            #region unicidad de principal
            AdjuntosService[] adjuntos = null;
            var lFiltrosPrincipal = new List<Filtro>();

            if (this.CasoId.HasValue)
            {
                lFiltrosPrincipal.Add(new Filtro { Columna = AdjuntosService.Modelo.CASO_IDColumnName, Valor = this.CasoId });
            }
            else
            {
                lFiltrosPrincipal.Add(new Filtro { Columna = AdjuntosService.Modelo.TABLA_IDColumnName, Valor = this.TablaId });
                lFiltrosPrincipal.Add(new Filtro { Columna = AdjuntosService.Modelo.REGISTROColumnName, Valor = this.Registro });
            }
            if(this.ExisteEnDB)
                lFiltrosPrincipal.Add(new Filtro { Columna = AdjuntosService.Modelo.IDColumnName, Comparacion = "<>", Valor = this.Id });
            adjuntos = this.GetFiltrado<AdjuntosService>(lFiltrosPrincipal);

            //Si no existía otro, marcarlo como principal
            //Si ya existían otros adjuntos y el que se guarda cambia de valor, asegurar unicidad
            if (adjuntos != null && adjuntos.Length <= 0)
            {
                this.Principal = Definiciones.SiNo.Si;
            }
            else if (this.Principal != GetStringHelper(this.rowSinModificar.PRINCIPAL))
            {
                if (this.Principal == Definiciones.SiNo.Si)
                {
                    for (int i = 0; i < adjuntos.Length; i++)
                    {
                        if (adjuntos[i].Principal == Definiciones.SiNo.Si)
                        {
                            adjuntos[i].Principal = Definiciones.SiNo.No;
                            adjuntos[i].IniciarUsingSesion(sesion);
                            adjuntos[i].Guardar();
                            adjuntos[i].FinalizarUsingSesion();
                        }
                    }
                }
            }
            #endregion unicidad de principal

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                this.Principal = Definiciones.SiNo.No;
                sesion.db.ADJUNTOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.ADJUNTOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        public static decimal GuardarPathTemporal(System.Collections.Hashtable campos)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    decimal id = GuardarPathTemporal(campos, sesion);
                    sesion.CommitTransaction();

                    return id;
                }
                catch
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static decimal GuardarPathTemporal(System.Collections.Hashtable campos, SessionService sesion)
        {
            try
            {
                ADJUNTOSRow row = new ADJUNTOSRow();
                row = sesion.Db.ADJUNTOSCollection.GetByPrimaryKey((decimal)campos[AdjuntosService.Modelo.IDColumnName]);
                row.PATH_TEMPORAL = campos[AdjuntosService.Modelo.PATH_TEMPORALColumnName].ToString();
                sesion.Db.ADJUNTOSCollection.Update(row);
                return row.ID;
            }
            catch
            {
                sesion.RollbackTransaction();
                throw;
            }
        }

        #region GuardarEnClio
        private void GuardarEnClio(Stream archivo)
        {
            var files = new[] 
            {
                new UploadFile
                {
                    Name = "file",
                    Filename = this.NombreArchivo,
                    ContentType = this.TipoMime,
                    Stream = archivo
                }
            };

            string bucket = "cbaflow-" + VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.Cliente);
            var values = new NameValueCollection
            {
                { "bucket", bucket},
                { "token", "alk41kALGOKzdks"},
            };

            byte[] result = UploadFiles(clioURL + "/subir/", files, values);
            string respuesta = Encoding.UTF8.GetString(result);
            Dictionary<string, object> resultado = JsonUtil.Deserializar<Dictionary<string, object>>(respuesta);

            if (resultado.ContainsKey("error"))
                throw new Exception(resultado["error"].ToString());
            
            this.ClioUUID = resultado["recurso"].ToString();
        }
        #endregion GuardarEnClio

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._caso = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override AdjuntosService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.CASO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.REGISTROColumnName:
                        case Modelo.TIPO_ADJUNTO_IDColumnName:
                        case Modelo.USUARIO_BORRADO_IDColumnName:
                        case Modelo.USUARIO_IDColumnName:
                        case Modelo.USUARIO_ULTIMA_EDICION_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.CLIO_UUIDColumnName:
                        case Modelo.DESCRIPCIONColumnName:
                        case Modelo.EXTENSIONColumnName:
                        case Modelo.GRUPOColumnName:
                        case Modelo.MOTIVO_BORRADOColumnName:
                        case Modelo.NOMBRE_ARCHIVOColumnName:
                        case Modelo.PRINCIPALColumnName:
                        case Modelo.TABLA_IDColumnName:
                        case Modelo.TIPO_MIMEColumnName:
                        case Modelo.TIPO_PRIVACIDADColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.FECHA_BORRADOColumnName:
                        case Modelo.FECHA_ULTIMA_EDICIONColumnName:
                        case Modelo.FECHAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        case FiltroExtension.NombreODescripcion:
                            if (f.Exacto)
                            {
                                sb.Append("(upper(nvl(" + Modelo.NOMBRE_ARCHIVOColumnName + ",'')) " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "' or ");
                                sb.Append(" upper(nvl(" + Modelo.DESCRIPCIONColumnName + ",'')) " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "')");
                            }
                            else
                            {
                                sb.Append("(upper(nvl(" + Modelo.NOMBRE_ARCHIVOColumnName + ",'')) like '%" + f.Valor.ToString().ToUpper() + "%' or ");
                                sb.Append(" upper(nvl(" + Modelo.DESCRIPCIONColumnName + ",'')) like '%" + f.Valor.ToString().ToUpper() + "%')");
                            }
                            break;
                        case FiltroExtension.ComentarioCasoCasoId:
                            sb.Append(Modelo.TABLA_IDColumnName + " = '" + ComentariosCasosService.Nombre_Tabla + "' and " +
                                      "exists(select c." + ComentariosCasosService.Id_NombreCol +
                                      "         from " + ComentariosCasosService.Nombre_Tabla + " c " +
                                      "        where c." + ComentariosCasosService.CasoId_NombreCol + " = " + f.Valor +
                                      "          and c." + ComentariosCasosService.Id_NombreCol + " = " + Nombre_Tabla + "." + Modelo.REGISTROColumnName +
                                       ")");
                            break;
                    }
                }
            }

            if (orden.Count <= 0)
                orden.Add(Modelo.IDColumnName + " desc");
            
            //Priero la princpal (S está después que N)
            orden.Insert(0, Modelo.PRINCIPALColumnName + " desc");
            
            ADJUNTOSRow[] rows = sesion.db.ADJUNTOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            AdjuntosService[] a = new AdjuntosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                a[i] = new AdjuntosService(rows[i]);

            return a;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            throw new NotImplementedException("Falta implementar.");
        }
        #endregion ToEDI

        #region Crear
        private void Crear(Stream archivo, string nombre, SessionService sesion)
        {
            //Obtener la extension del archivo, si la tiene
            int puntoSeparacion = nombre.LastIndexOf(".");
            if (puntoSeparacion > 0)
                this.Extension = nombre.Substring(puntoSeparacion + 1).ToLower();

            this.Fecha = DateTime.Now;
            this.NombreArchivo = nombre;
            this.TipoAdjuntoId = Definiciones.TiposAdjunto.Indefinido;
            this.TipoMime = ObtenerTipoMIMESegunExtension(this.Extension);
            this.UsuarioId = sesion.Usuario_Id;

            this.GuardarEnClio(archivo);
            this.Guardar();
        }


        public static AdjuntosService Crear(string tabla_id, decimal registro_id, Stream archivo, string nombre_archivo, SessionService sesion)
        {
            AdjuntosService a = new AdjuntosService();
            a.TablaId = tabla_id;
            a.Registro = registro_id;
            a.Principal = Definiciones.SiNo.Si;
            a.Crear(archivo, nombre_archivo, sesion);

            return a;
        }
        #endregion Crear

     

        #region GetGruposDistintos
        public static string[] GetGruposDistintos(string tabla_id, decimal registro_id)
        {
            using (SessionService sesion = new SessionService())
            { 
                string sql = "select distinct nvl(" + Modelo.GRUPOColumnName + ", '') " +
                             "  from " + Nombre_Tabla +
                             " where " + Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'";
                if (tabla_id == CasosService.Nombre_Tabla)
                    sql += " and " + Modelo.CASO_IDColumnName + " = " + registro_id;
                else
                    sql += " and " + Modelo.TABLA_IDColumnName + " = '" + tabla_id +  "' and " + Modelo.REGISTROColumnName + " = " + registro_id;
                sql += " order by 1";

                var dt = sesion.db.EjecutarQuery(sql);
                var grupos = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    grupos[i] = GetStringHelper(dt.Rows[i][0]);
                
                return grupos;
            }
        }
        #endregion GetGruposDistintos

        #region Accessors
        public static string Nombre_Tabla = "ADJUNTOS";
        public static string Nombre_Secuencia = "ADJUNTOS_SQC";
        #endregion Accessors

        #region ObtenerTipoMIMESegunExtension
        /// <summary>
        /// Obteners the tipo MIME segun extension.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns></returns>
        public string ObtenerTipoMIMESegunExtension(string extension)
        {
            //Si no esta definida la extension, se usa el MIME generico
            string resultado = "application/octet-stream";

            switch (extension.ToLower())
            {
                // HTML
                case "htm":
                case "html":
                case "htmls":
                    resultado = "text/html";
                    break;

                // DOCUMENTOS DE TEXTO PLANO
                case "list":
                case "log":
                case "txt":
                case "lst":
                    resultado = "text/plain";
                    break;
                case "rtf":
                    resultado = "text/richtext";
                    break;

                // DOCUMENTOS DE MS-OFFICE
                case "dot":
                case "doc":
                case "docx":
                    resultado = "application/msword";
                    break;
                case "xls":
                case "xlsx":
                    resultado = "application/excel";
                    break;
                case "ppt":
                case "pps":
                case "ppsx":
                    resultado = "application/excel";
                    break;

                // IMAGENES
                case "jpg":
                case "jpe":
                case "jpeg":
                    resultado = "image/jpeg";
                    break;
                case "tif":
                case "tiff":
                    resultado = "image/tiff";
                    break;
                case "gif":
                case "png":
                case "bmp":
                    resultado = "image/" + extension;
                    break;
                // OTROS
                case "pdf":
                    resultado = "application/pdf";
                    break;
            }

            return resultado;
        }
        #endregion ObtenerTipoMIMESegunExtension

        #region UploadFile
        private class UploadFile
        {
            public UploadFile()
            {
                ContentType = "application/octet-stream";
            }
            public string Name { get; set; }
            public string Filename { get; set; }
            public string ContentType { get; set; }
            public Stream Stream { get; set; }
        }

        private byte[] UploadFiles(string address, IEnumerable<UploadFile> files, NameValueCollection values)
        {
            var request = WebRequest.Create(address);
            request.Method = "POST";
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            boundary = "--" + boundary;

            using (var requestStream = request.GetRequestStream())
            {
                // Write the values
                foreach (string name in values.Keys)
                {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                // Write the files
                foreach (var file in files)
                {
                    var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                    requestStream.Write(buffer, 0, buffer.Length);
                    file.Stream.CopyTo(requestStream);
                    buffer = Encoding.ASCII.GetBytes(Environment.NewLine);
                    requestStream.Write(buffer, 0, buffer.Length);
                }

                var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
            }

            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var stream = new MemoryStream())
            {
                responseStream.CopyTo(stream);
                return stream.ToArray();
            }
        }
        #endregion UploadFile
    }
}
