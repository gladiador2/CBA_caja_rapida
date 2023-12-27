#region Using
using System;
using System.Collections.Generic;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.TextosPredefinidos;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Contabilidad
{
    public class PresupuestosDetallesService : ClaseCBA<PresupuestosDetallesService>
    {
        #region Propiedades
        protected CTB_PRESUPUESTOS_DETRow row;
        protected CTB_PRESUPUESTOS_DETRow rowSinModificar;
        public class Modelo : CTB_PRESUPUESTOS_DETCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal CtbCuentaId { get { return row.CTB_CUENTA_ID; } set { row.CTB_CUENTA_ID = value; } }
        public decimal CtbPresupuestoId { get { return row.CTB_PRESUPUESTO_ID; } set { row.CTB_PRESUPUESTO_ID = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal MesDesde { get { return row.MES_DESDE; } set { row.MES_DESDE = value; } }
        public decimal MesHasta { get { return row.MES_HASTA; } set { row.MES_HASTA = value; } }
        public decimal Monto { get { return row.MONTO; } set { row.MONTO = value; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CTB_PRESUPUESTOS_DETCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CTB_PRESUPUESTOS_DETRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CTB_PRESUPUESTOS_DETRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public PresupuestosDetallesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public PresupuestosDetallesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public PresupuestosDetallesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private PresupuestosDetallesService(CTB_PRESUPUESTOS_DETRow row)
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
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                this.Estado = Definiciones.Estado.Activo;
                sesion.db.CTB_PRESUPUESTOS_DETCollection.Insert(this.row);

                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.Id.Value, null, this.row, sesion);
            }
            else
            {
                sesion.db.CTB_PRESUPUESTOS_DETCollection.Update(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.Id.Value, this.rowSinModificar, this.row, sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

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
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.Nombre.Length <= 0)
                excepciones.Agregar("El nombre debe estar definido", null);

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
        protected override PresupuestosDetallesService[] Buscar(Filtro[] filtros)
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
                        case Modelo.CTB_CUENTA_IDColumnName:
                        case Modelo.CTB_PRESUPUESTO_IDColumnName:
                        case Modelo.IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.MES_DESDEColumnName:
                        case Modelo.MES_HASTAColumnName:
                        case Modelo.MONTOColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        case Modelo.ESTADOColumnName:
                        case Modelo.NOMBREColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            CTB_PRESUPUESTOS_DETRow[] rows = sesion.db.CTB_PRESUPUESTOS_DETCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            PresupuestosDetallesService[] pd = new PresupuestosDetallesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                pd[i] = new PresupuestosDetallesService(rows[i]);
            return pd;
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
        public static string Nombre_Tabla
        {
            get { return "CTB_PRESUPUESTOS_DET"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "CTB_PRESUPUESTOS_DET_SQC"; }
        }
        #endregion Accessors
    }
}
