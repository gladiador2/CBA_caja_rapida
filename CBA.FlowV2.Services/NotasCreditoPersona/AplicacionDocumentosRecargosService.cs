#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Facturacion;
using CBA.FlowV2.Services.NotasDebitoPersona;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Tesoreria;
using System.Collections;
#endregion Using

namespace CBA.FlowV2.Services.NotasCreditoPersona
{
    public class AplicacionDocumentosRecargosService : ClaseCBA<AplicacionDocumentosRecargosService>
    {
        #region Propiedades
        protected APLICACION_DOCUMEN_DOC_RECARGORow row;
        protected APLICACION_DOCUMEN_DOC_RECARGORow rowSinModificar;
        public class Modelo : APLICACION_DOCUMEN_DOC_RECARGOCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? AplicacionDcoumentoDocId { get { if (row.IsAPLICACION_DOCUMENTO_DOC_IDNull) return null; else return row.APLICACION_DOCUMENTO_DOC_ID; } set { if (value.HasValue) row.APLICACION_DOCUMENTO_DOC_ID = value.Value; else row.IsAPLICACION_DOCUMENTO_DOC_IDNull = true; } }
        public decimal Cotizacion { get { return row.COTIZACION; } set { row.COTIZACION = value; } }
        public decimal CtacteConceptoId { get { return row.CTACTE_CONCEPTO_ID; } set { row.CTACTE_CONCEPTO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal ImpuestoId { get { return row.IMPUESTO_ID; } set { row.IMPUESTO_ID = value; } }
        public decimal MonedaId { get { return row.MONEDA_ID; } set { row.MONEDA_ID = value; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string Observacion { get { return ClaseCBABase.GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        public decimal TipoRecargo { get { return row.TIPO_RECARGO; } set { row.TIPO_RECARGO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.APLICACION_DOCUMEN_DOC_RECARGOCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new APLICACION_DOCUMEN_DOC_RECARGORow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(APLICACION_DOCUMEN_DOC_RECARGORow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public AplicacionDocumentosRecargosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public AplicacionDocumentosRecargosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public AplicacionDocumentosRecargosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private AplicacionDocumentosRecargosService(APLICACION_DOCUMEN_DOC_RECARGORow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetRecargosSobreDocumento
        public static AplicacionDocumentosRecargosService[] GetRecargosSobreDocumento(decimal aplicacion_documento_doc_id, SessionService sesion)
        {
            string clausulas = NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocuDocReferidId_NombreCol + " = " + aplicacion_documento_doc_id;
            DataTable dt = NotasCreditoPersonaAplicacionDocumentosService.GetNotaCreditoAplicacionDocumentosDataTable(clausulas, NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol, sesion);

            var instancia = AplicacionDocumentosRecargosService.Instancia;
            instancia.IniciarUsingSesion(sesion);
            var adr = new AplicacionDocumentosRecargosService[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                adr[i] = instancia.GetPrimero<AplicacionDocumentosRecargosService>(new Filtro() { Columna = AplicacionDocumentosRecargosService.Modelo.APLICACION_DOCUMENTO_DOC_IDColumnName, Valor = dt.Rows[i][NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol] });

            instancia.FinalizarUsingSesion();

            return adr;
        }
        #endregion GetRecargosSobreDocumento

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                #region Crear el documento en la aplicacion
                DataTable dtAplicacionDocumento = NotasCreditoPersonaAplicacionDocumentosService.GetNotaCreditoAplicacionDocumentosDataTable(NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol + " = " + this.AplicacionDcoumentoDocId.Value, string.Empty, this.sesion);
                var campos = new Hashtable();
                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocuDocReferidId_NombreCol, this.AplicacionDcoumentoDocId);
                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MonedaId_NombreCol, this.MonedaId);
                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.Cotizacion_NombreCol, this.Cotizacion);
                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoDestino_NombreCol, this.Monto);
                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.MontoOrigen_NombreCol, this.Monto);
                campos.Add(NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol, dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol]);
                this.AplicacionDcoumentoDocId = NotasCreditoPersonaAplicacionDocumentosService.Guardar(campos, sesion);
                #endregion Crear el documento en la aplicacion

                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.APLICACION_DOCUMEN_DOC_RECARGOCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroNuevo, this.row.ToString(), sesion);
            }
            else
            {
                sesion.db.APLICACION_DOCUMEN_DOC_RECARGOCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.rowSinModificar.ToString(), this.row.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

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
        }
        #endregion ResetearPropiedadesExtendidas

        #region Borrar
        public void Borrar()
        {
            if (this.sesion == null)
            {
                using (SessionService sesion = new SessionService())
                {
                    sesion.db.APLICACION_DOCUMEN_DOC_RECARGOCollection.Delete(this.row);
                    this.Id = Definiciones.Error.Valor.EnteroPositivo;
                    ResetearPropiedadesExtendidas();
                }
            }
        }
        #endregion Borrar

        #region Buscar
        protected override AplicacionDocumentosRecargosService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" 1=1 ");

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
                        case Modelo.APLICACION_DOCUMENTO_DOC_IDColumnName:
                        case Modelo.CTACTE_CONCEPTO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.IMPUESTO_IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.MONTOColumnName:
                        case Modelo.TIPO_RECARGOColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.OBSERVACIONColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            APLICACION_DOCUMEN_DOC_RECARGORow[] rows = sesion.db.APLICACION_DOCUMEN_DOC_RECARGOCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            AplicacionDocumentosRecargosService[] adr = new AplicacionDocumentosRecargosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                adr[i] = new AplicacionDocumentosRecargosService(rows[i]);

            return adr;
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
    
        #region CrearCredito
        /// <summary>
        /// Crears the credito.
        /// </summary>
        /// <param name="ctacte_pago_persona_recargo_id">The ctacte_pago_persona_recargo_id.</param>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public decimal CrearCredito()
        {
            decimal ctacte_persona_id;
            DataTable dtAplicacionDocumento = NotasCreditoPersonaAplicacionDocumentosService.GetNotaCreditoAplicacionDocumentosDataTable(NotasCreditoPersonaAplicacionDocumentosService.Id_NombreCol + " = " + this.AplicacionDcoumentoDocId.Value, string.Empty, this.sesion);
            DataTable dtAplicacion = NotasCreditoPersonaAplicacionesService.GetNotaCreditoAplicacionDataTable((decimal)dtAplicacionDocumento.Rows[0][NotasCreditoPersonaAplicacionDocumentosService.AplicacionDocumentoId_NombreCol], this.sesion);
            
            ctacte_persona_id = CuentaCorrientePersonasService.AgregarCredito(
                    (decimal)dtAplicacion.Rows[0][NotasCreditoPersonaAplicacionesService.PersonaDocumentoId_NombreCol],
                    Definiciones.Error.Valor.EnteroPositivo,
                    this.CtacteConceptoId,
                    (decimal)dtAplicacion.Rows[0][NotasCreditoPersonaAplicacionesService.CasoId_NombreCol],
                    row.MONEDA_ID,
                    row.COTIZACION,
                    new decimal[] { row.IMPUESTO_ID },
                    new decimal[] { row.MONTO },
                    row.OBSERVACION,
                    DateTime.Now,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    Definiciones.Error.Valor.EnteroPositivo,
                    row.ID,
                    1,
                    1,
                    sesion);

            return ctacte_persona_id;
        }
        #endregion CrearCredito

        #region BorrarCredito
        public void BorrarCredito()
        {
            CuentaCorrientePersonasService.DeshacerAgregarCredito(Definiciones.Error.Valor.EnteroPositivo, Definiciones.Error.Valor.EnteroPositivo, this.Id.Value, false, this.sesion);
        }
        #endregion BorrarCredito

        #region Accessors
        public static string Nombre_Tabla = "CTACTE_PAGOS_PERSONA_RECARGO";
        public static string Nombre_Secuencia = "aplicacion_documen_doc_rec_sqc";
        #endregion Accessors
    }
}
