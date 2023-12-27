#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Framework.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;

using System.Collections;
using System.Globalization;
using CBA.FlowV2.Services.Facturacion;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using CBA.FlowV2.Services.Giros;
using System.Net;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class TransaccionesCierresCasosService : ClaseCBA<TransaccionesCierresCasosService>
    {
        #region Propiedades
        protected TRANSACCIONES_CIERRES_CASOSRow row;
        protected TRANSACCIONES_CIERRES_CASOSRow rowSinModificar;
        public class Modelo : TRANSACCIONES_CIERRES_CASOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal CasoId { get { return row.CASO_ID; } set { row.CASO_ID = value; } }
        public decimal? ComisionClearing { get { if (row.IsCOMISION_CLEARINGNull) return null; else return row.COMISION_CLEARING; } set { if (value.HasValue) row.COMISION_CLEARING = value.Value; else row.IsCOMISION_CLEARINGNull = true; } }
        public decimal? ComisionOtro { get { if (row.IsCOMISION_OTRONull) return null; else return row.COMISION_OTRO; } set { if (value.HasValue) row.COMISION_OTRO = value.Value; else row.IsCOMISION_OTRONull = true; } }
        public decimal? ComisionProcesador { get { if (row.IsCOMISION_PROCESADORNull) return null; else return row.COMISION_PROCESADOR; } set { if (value.HasValue) row.COMISION_PROCESADOR = value.Value; else row.IsCOMISION_PROCESADORNull = true; } }
        public decimal? ComisionRecaudador { get { if (row.IsCOMISION_RECAUDADORNull) return null; else return row.COMISION_RECAUDADOR; } set { if (value.HasValue) row.COMISION_RECAUDADOR = value.Value; else row.IsCOMISION_RECAUDADORNull = true; } }
        public decimal? ComisionRed { get { if (row.IsCOMISION_REDNull) return null; else return row.COMISION_RED; } set { if (value.HasValue) row.COMISION_RED = value.Value; else row.IsCOMISION_REDNull = true; } }
        public decimal? ComisionTotal { get { if (row.IsCOMISION_TOTALNull) return null; else return row.COMISION_TOTAL; } set { if (value.HasValue) row.COMISION_TOTAL = value.Value; else row.IsCOMISION_TOTALNull = true; } }
        public decimal? Cotizacion { get { if (row.IsCOTIZACIONNull) return null; else return row.COTIZACION; } set { if (value.HasValue) row.COTIZACION = value.Value; else row.IsCOTIZACIONNull = true; } }
        public decimal FlujoId { get { return row.FLUJO_ID; } set { row.FLUJO_ID = value; } }
        public decimal? MonedaId { get { if (row.IsMONEDA_IDNull ) return null; else return row.MONEDA_ID; } set { if (value.HasValue) row.MONEDA_ID = value.Value; else row.IsMONEDA_IDNull = true; } }
        public decimal? MontoTotal { get { if (row.IsMONTO_TOTALNull ) return null; else return row.MONTO_TOTAL; } set { if (value.HasValue) row.MONTO_TOTAL = value.Value; else row.IsMONTO_TOTALNull = true; } }
        public decimal TransaccionCierreId { get { return row.TRANSACCION_CIERRE_ID; } set { row.TRANSACCION_CIERRE_ID = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private TransaccionesCierresService _transaccionCierre;
        public TransaccionesCierresService TransaccionCierre
        {
            get
            {
                if (this._transaccionCierre == null)
                    this._transaccionCierre = new TransaccionesCierresService(this.TransaccionCierreId);
                return this._transaccionCierre;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TRANSACCIONES_CIERRES_CASOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TRANSACCIONES_CIERRES_CASOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TRANSACCIONES_CIERRES_CASOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TransaccionesCierresCasosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TransaccionesCierresCasosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TransaccionesCierresCasosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TransaccionesCierresCasosService(TRANSACCIONES_CIERRES_CASOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Borrar
        public void Borrar()
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Borrar(sesion);
                this.FinalizarUsingSesion();
            }
        }

        public void Borrar(SessionService sesion)
        {
            if(this.Id.HasValue)
            {
                sesion.db.TRANSACCIONES_CIERRES_CASOSCollection.DeleteByPrimaryKey(this.Id.Value);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, Definiciones.Log.RegistroBorrado, this.row.ToString(), sesion);

                this.Id = null;
            }
        }
        #endregion Borrar

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.TRANSACCIONES_CIERRES_CASOSCollection.Insert(this.row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.TRANSACCIONES_CIERRES_CASOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
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
            this._transaccionCierre = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override TransaccionesCierresCasosService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");

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
                        case Modelo.FLUJO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.MONEDA_IDColumnName:
                        case Modelo.TRANSACCION_CIERRE_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.COMISION_CLEARINGColumnName:
                        case Modelo.COMISION_OTROColumnName:
                        case Modelo.COMISION_PROCESADORColumnName:
                        case Modelo.COMISION_RECAUDADORColumnName:
                        case Modelo.COMISION_REDColumnName:
                        case Modelo.COMISION_TOTALColumnName:
                        case Modelo.MONTO_TOTALColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            TRANSACCIONES_CIERRES_CASOSRow[] rows = sesion.db.TRANSACCIONES_CIERRES_CASOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TransaccionesCierresCasosService[] tcc = new TransaccionesCierresCasosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                tcc[i] = new TransaccionesCierresCasosService(rows[i]);
            return tcc;
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

        #region Accessors
        public static string Nombre_Tabla= "TRANSACCIONES_CIERRES_CASOS";
        public static string Nombre_Secuencia = "TRANSACCIONES_CIERR_CASOS_SQC";
        #endregion Accessors
    }
}
