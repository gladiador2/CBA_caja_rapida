#region Using
using System;
using System.Data;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Collections.Generic;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class CondicionesPagoDetService : ClaseCBA<CondicionesPagoDetService>
    {
        #region Propiedades
        protected CTACTE_CONDICIONES_PAGO_DETRow row;
        protected CTACTE_CONDICIONES_PAGO_DETRow rowSinModificar;
        public class Modelo : CTACTE_CONDICIONES_PAGO_DETCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CtacteCondicionPagoId { get { return row.CTACTE_CONDICION_PAGO_ID; } set { row.CTACTE_CONDICION_PAGO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal NumeroCuota { get { return row.NUMERO_CUOTA; } set { row.NUMERO_CUOTA = value; } }
        public decimal VencimientoPago { get { return row.VENCIMIENTO_PAGO; } set { row.VENCIMIENTO_PAGO = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTACTE_CONDICIONES_PAGO_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTACTE_CONDICIONES_PAGO_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTACTE_CONDICIONES_PAGO_DETRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CondicionesPagoDetService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CondicionesPagoDetService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CondicionesPagoDetService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        
        private CondicionesPagoDetService(CTACTE_CONDICIONES_PAGO_DETRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.CTACTE_CONDICIONES_PAGO_DETCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, null, sesion);
            }
            else
            {
                sesion.db.CTACTE_CONDICIONES_PAGO_DETCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, this.rowSinModificar, sesion);
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

        #region Buscar
        protected override CondicionesPagoDetService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CTACTE_CONDICION_PAGO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.NUMERO_CUOTAColumnName:
                        case Modelo.VENCIMIENTO_PAGOColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.NUMERO_CUOTAColumnName);
            CTACTE_CONDICIONES_PAGO_DETRow[] rows = sesion.db.CTACTE_CONDICIONES_PAGO_DETCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CondicionesPagoDetService[] m = new CondicionesPagoDetService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                m[i] = new CondicionesPagoDetService(rows[i]);

            return m;
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
        public static string Nombre_Tabla = "CTACTE_CONDICIONES_PAGO_DET";
        public static string Nombre_Secuencia = "CTACTE_CONDIC_PAGO_DET_SQC";
        #endregion Accessors
    }
}
