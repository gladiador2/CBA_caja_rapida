#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
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
    public class TransaccionesCierresService : ClaseCBA<TransaccionesCierresService>
    {
        #region Propiedades
        protected TRANSACCIONES_CIERRESRow row;
        protected TRANSACCIONES_CIERRESRow rowSinModificar;
        public class Modelo : TRANSACCIONES_CIERRESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public DateTime? MayorFechaTransaccion { get { if (row.IsMAYOR_FECHA_TRANSACCIONNull) return null; else return row.MAYOR_FECHA_TRANSACCION; } set { if (value.HasValue) row.MAYOR_FECHA_TRANSACCION = value.Value; else row.IsMAYOR_FECHA_TRANSACCIONNull = true; } }
        public DateTime? MenorFechaTransaccion { get { if (row.IsMENOR_FECHA_TRANSACCIONNull) return null; else return row.MENOR_FECHA_TRANSACCION; } set { if (value.HasValue) row.MENOR_FECHA_TRANSACCION = value.Value; else row.IsMENOR_FECHA_TRANSACCIONNull = true; } }
        #endregion Propiedades

        #region Propiedades extendidas
        private decimal? _comisionRecaudador;
        public decimal ComisionRecaudador
        {
            get
            {
                if (!_comisionRecaudador.HasValue)
                    throw new Exception("Error: antes de utilizar la propiedad debe invocarse a InicializarPropiedadesExtendidas()");
                
                return this._comisionRecaudador.Value;
            }
        }

        private decimal? _comisionProcesador;
        public decimal ComisionProcesador
        {
            get
            {
                if (!_comisionProcesador.HasValue)
                    throw new Exception("Error: antes de utilizar la propiedad debe invocarse a InicializarPropiedadesExtendidas()");
                
                return this._comisionProcesador.Value;
            }
        }

        private decimal? _comisionClearing;
        public decimal ComisionClearing
        {
            get
            {
                if (!_comisionClearing.HasValue)
                    throw new Exception("Error: antes de utilizar la propiedad debe invocarse a InicializarPropiedadesExtendidas()");
                
                return this._comisionClearing.Value;
            }
        }

        private decimal? _comisionRed;
        public decimal ComisionRed
        {
            get
            {
                if (!_comisionRed.HasValue)
                    throw new Exception("Error: antes de utilizar la propiedad debe invocarse a InicializarPropiedadesExtendidas()");
                
                return this._comisionRed.Value;
            }
        }

        private decimal? _comisionOtro;
        public decimal ComisionOtro
        {
            get
            {
                if (!_comisionOtro.HasValue)
                    throw new Exception("Error: antes de utilizar la propiedad debe invocarse a InicializarPropiedadesExtendidas()");
                
                return this._comisionOtro.Value;
            }
        }
        public void InicializarPropiedadesExtendidas(decimal moneda_id)
        {
            if (!this.ExisteEnDB)
                throw new Exception("La transacción no está guardada.");

            TransaccionesService[] ts = this.GetFiltrado<TransaccionesService>(new Filtro[] 
                {
                    new Filtro { Columna = TransaccionesService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = this.Id.Value },
                    new Filtro { Columna = TransaccionesService.Modelo.MONEDA_IDColumnName, Valor = moneda_id },
                }
            );

            this._comisionRecaudador = 0;
            this._comisionProcesador = 0;
            this._comisionClearing = 0;
            this._comisionRed = 0;
            this._comisionOtro = 0;
            for (int i = 0; i < ts.Length; i++)
            {
                this._comisionRecaudador += ts[i].ComisionRecaudador;
                this._comisionProcesador += ts[i].ComisionProcesador;
                this._comisionClearing += ts[i].ComisionClearing;
                this._comisionRed += ts[i].ComisionRed;
                this._comisionOtro += ts[i].ComisionOtro;
            }
        }
        #endregion Propiedades extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TRANSACCIONES_CIERRESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TRANSACCIONES_CIERRESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TRANSACCIONES_CIERRESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TransaccionesCierresService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TransaccionesCierresService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TransaccionesCierresService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TransaccionesCierresService(TRANSACCIONES_CIERRESRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            try
            {
                this.Validar();

                if (!this.ExisteEnDB)
                {
                    this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                    sesion.db.TRANSACCIONES_CIERRESCollection.Insert(this.row);

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
                }
                else
                {
                    sesion.db.TRANSACCIONES_CIERRESCollection.Update(this.row);
                    LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
                }

                this.rowSinModificar = this.row.Clonar();
                return this.Id.Value;
            }
            catch
            {
                throw;
            }
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.Nombre.Length <= 0)
                excepciones.Agregar("Debe indicar un nombre", null);

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._comisionClearing = null;
            this._comisionOtro = null;
            this._comisionProcesador = null;
            this._comisionRecaudador = null;
            this._comisionRed = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Crear
        public static TransaccionesCierresService Crear(string nombre, TransaccionesService[] transacciones)
        {
            using (SessionService sesion = new SessionService())
            {
                TransaccionesCierresService tc = null;

                try
                {
                    sesion.BeginTransaction();

                    tc = new TransaccionesCierresService();
                    tc.IniciarUsingSesion(sesion);
                    tc.Estado = Definiciones.Estado.Activo;
                    tc.Nombre = nombre;
                    tc.MenorFechaTransaccion = DateTime.MaxValue;
                    tc.MayorFechaTransaccion = DateTime.MinValue;
                    tc.Guardar();

                    for (int i = 0; i < transacciones.Length; i++)
                    {
                        if (transacciones[i].TransaccionCierreId.HasValue)
                            throw new Exception("La transacción " + transacciones[i].NroTransaccion + " ya pertenece a un cierre.");
                        transacciones[i].TransaccionCierreId = tc.Id;

                        if (transacciones[i].FechaTransaccion.HasValue)
                        {
                            if (tc.MenorFechaTransaccion.Value > transacciones[i].FechaTransaccion.Value)
                                tc.MenorFechaTransaccion = transacciones[i].FechaTransaccion;

                            if (tc.MayorFechaTransaccion.Value < transacciones[i].FechaTransaccion.Value)
                                tc.MayorFechaTransaccion = transacciones[i].FechaTransaccion;
                        }

                        transacciones[i].Guardar();
                    }

                    if (tc.MenorFechaTransaccion == DateTime.MaxValue)
                    {
                        tc.MenorFechaTransaccion = null;
                        tc.MayorFechaTransaccion = null;
                    }

                    tc.Guardar();

                    tc.FinalizarUsingSesion();
                    sesion.CommitTransaction();
                    return tc;
                }
                catch
                {
                    tc.FinalizarUsingSesion();
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Crear

        #region Borrar
        public void Borrar()
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    this.IniciarUsingSesion(sesion);

                    TransaccionesService[] t = this.GetFiltrado<TransaccionesService>(new Filtro { Columna = TransaccionesService.Modelo.TRANSACCION_CIERRE_IDColumnName, Valor = this.Id.Value });
                    for (int i = 0; i < t.Length; i++)
                    {
                        t[i].TransaccionCierreId = null;
                        t[i].Guardar();
                    }

                    this.Estado = Definiciones.Estado.Inactivo;
                    this.Guardar();

                    this.FinalizarUsingSesion();
                    sesion.CommitTransaction();
                }
                catch
                {
                    this.FinalizarUsingSesion();
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Borrar

        #region Buscar
        protected override TransaccionesCierresService[] Buscar(Filtro[] filtros)
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
                        case Modelo.IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.NOMBREColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.MAYOR_FECHA_TRANSACCIONColumnName:
                        case Modelo.MENOR_FECHA_TRANSACCIONColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            TRANSACCIONES_CIERRESRow[] rows = sesion.db.TRANSACCIONES_CIERRESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TransaccionesCierresService[] uid = new TransaccionesCierresService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                uid[i] = new TransaccionesCierresService(rows[i]);
            return uid;
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
        public static string Nombre_Tabla= "TRANSACCIONES_CIERRES";
        public static string Nombre_Secuencia = "TRANSACCIONES_CIERRES_SQC";
        #endregion Accessors
    }
}
