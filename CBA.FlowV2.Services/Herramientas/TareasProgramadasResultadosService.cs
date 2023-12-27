#region Using
using System;
using System.Collections.Generic;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Common;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using System.Data;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class TareasProgramadasResultadosService : ClaseCBA<TareasProgramadasResultadosService>
    {
        #region Propiedades
        protected TAREAS_PROGRAMADAS_RESULTADOSRow row;
        protected TAREAS_PROGRAMADAS_RESULTADOSRow rowSinModificar;
        public class Modelo : TAREAS_PROGRAMADAS_RESULTADOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Exito { get { return row.EXITO; } set { row.EXITO = value; } }
        public DateTime Fecha { get { return row.FECHA; } set { row.FECHA = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Mensaje { get { return row.MENSAJE; } set { row.MENSAJE = value; } }
        public decimal TareaProgramadaId { get { return row.TAREA_PROGRAMADA_ID; } set { row.TAREA_PROGRAMADA_ID = value;} }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.TAREAS_PROGRAMADAS_RESULTADOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new TAREAS_PROGRAMADAS_RESULTADOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(TAREAS_PROGRAMADAS_RESULTADOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public TareasProgramadasResultadosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public TareasProgramadasResultadosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public TareasProgramadasResultadosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private TareasProgramadasResultadosService(TAREAS_PROGRAMADAS_RESULTADOSRow row)
        {
            Inicializar(row);
        }
        #endregion Constructores

        #region GetPorTareaProgramada
        public static TareasProgramadasResultadosService[] GetPorTareaProgramada(decimal tarea_programada_id)
        { 
            using(SessionService sesion = new SessionService())
            {
                TAREAS_PROGRAMADAS_RESULTADOSRow[] rows = sesion.db.TAREAS_PROGRAMADAS_RESULTADOSCollection.GetAsArray(TareasProgramadasResultadosService.TareaProgramadaId_NombreCol + " = " + tarea_programada_id, TareasProgramadasResultadosService.Id_NombreCol);
                TareasProgramadasResultadosService[] tpr = new TareasProgramadasResultadosService[rows.Length];

                for (int i = 0; i < rows.Length; i++)
                    tpr[i] = new TareasProgramadasResultadosService(rows[i]);

                return tpr;
            }
        }
        #endregion GetPorTareaProgramada

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

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            this.Validar();

            if (!this.ExisteEnDB)
            {
                this.Id = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                sesion.db.TAREAS_PROGRAMADAS_RESULTADOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.TAREAS_PROGRAMADAS_RESULTADOSCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();
            return this.Id.Value;
        }
        #endregion Guardar

        #region Buscar
        protected override TareasProgramadasResultadosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.IDColumnName:
                        case Modelo.TAREA_PROGRAMADA_IDColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.EXITOColumnName:
                        case Modelo.MENSAJEColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.FECHAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            TAREAS_PROGRAMADAS_RESULTADOSRow[] rows = sesion.db.TAREAS_PROGRAMADAS_RESULTADOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            TareasProgramadasResultadosService[] tpr = new TareasProgramadasResultadosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                tpr[i] = new TareasProgramadasResultadosService(rows[i]);
            return tpr;
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
            get { return "TAREAS_PROGRAMADAS_RESULTADOS"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "tareas_programadas_result_sqc"; }
        }
        public static string Exito_NombreCol
        {
            get { return TAREAS_PROGRAMADAS_RESULTADOSCollection.EXITOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return TAREAS_PROGRAMADAS_RESULTADOSCollection.FECHAColumnName; }
        }
        public static string Id_NombreCol
        {
            get { return TAREAS_PROGRAMADAS_RESULTADOSCollection.IDColumnName; }
        }
        public static string Mensaje_NombreCol
        {
            get { return TAREAS_PROGRAMADAS_RESULTADOSCollection.MENSAJEColumnName; }
        }
        public static string TareaProgramadaId_NombreCol
        {
            get { return TAREAS_PROGRAMADAS_RESULTADOSCollection.TAREA_PROGRAMADA_IDColumnName; }
        }
        #endregion Accessors
    }
}
