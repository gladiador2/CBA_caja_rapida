#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.CRM
{
    public class CrmHilosEntradasRelacionesService : ClaseCBA<CrmHilosEntradasRelacionesService>
    {
        #region Propiedades
        protected CRM_HILOS_ENTRADAS_RELACIONESRow row;
        protected CRM_HILOS_ENTRADAS_RELACIONESRow rowSinModificar;
        public class Modelo : CRM_HILOS_ENTRADAS_RELACIONESCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal CrmHiloEntradaId { get { return row.CRM_HILOS_ENTRADA_ID; } set { row.CRM_HILOS_ENTRADA_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal TipoDeDatoId { get { return row.TIPO_DE_DATO_ID; } set { row.TIPO_DE_DATO_ID = value; } }
        public DateTime? ValorFecha { get { if (row.IsVALOR_FECHANull) return null; else return row.VALOR_FECHA; } set { if (value.HasValue) row.VALOR_FECHA = value.Value; else row.IsVALOR_FECHANull = true; } }
        public decimal? ValorNumero { get { if (row.IsVALOR_NUMERONull) return null; else return row.VALOR_NUMERO; } set { if (value.HasValue) row.VALOR_NUMERO = value.Value; else row.IsVALOR_NUMERONull = true; } }
        public string ValorTexto { get { return ClaseCBABase.GetStringHelper(row.VALOR_TEXTO); } set { row.VALOR_TEXTO = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CrmHilosEntradasService _crm_hilo_entrada;
        public CrmHilosEntradasService CrmHiloEntrada
        {
            get
            {
                if (this._crm_hilo_entrada == null)
                {
                    if (this.sesion != null)
                        this._crm_hilo_entrada = new CrmHilosEntradasService(this.CrmHiloEntradaId, this.sesion);
                    else
                        this._crm_hilo_entrada = new CrmHilosEntradasService(this.CrmHiloEntradaId);
                }
                return this._crm_hilo_entrada;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CRM_HILOS_ENTRADAS_RELACIONESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CRM_HILOS_ENTRADAS_RELACIONESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CRM_HILOS_ENTRADAS_RELACIONESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CrmHilosEntradasRelacionesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CrmHilosEntradasRelacionesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CrmHilosEntradasRelacionesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        public CrmHilosEntradasRelacionesService(CRM_HILOS_ENTRADAS_RELACIONESRow row)
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
                this.row.ESTADO = Definiciones.Estado.Activo;
                sesion.db.CRM_HILOS_ENTRADAS_RELACIONESCollection.Insert(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CRM_HILOS_ENTRADAS_RELACIONESCollection.Update(this.row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), this.rowSinModificar.ToString(), sesion);
            }

            this.rowSinModificar = this.row.Clonar();

            return this.row.ID;
        }
        #endregion Guardar

        #region Borrar
        public void Borrar()
        {
            this.Estado = Definiciones.Estado.Inactivo;
            this.Guardar();
        }
        #endregion Borrar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            int valores = 0;

            if (this.ValorFecha.HasValue)
                valores++;
            if (this.ValorNumero.HasValue)
                valores++;
            if (this.ValorTexto.Length > 0)
                valores++;

            if (valores != 1)
                excepciones.Agregar("Debe estar definido solo un valor.");

            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
            this._crm_hilo_entrada = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CrmHilosEntradasRelacionesService[] Buscar(Filtro[] filtros)
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
                        case Modelo.VALOR_TEXTOColumnName:
                            if (f.Exacto)
                                sb.Append("upper(" + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(" + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        case Modelo.CRM_HILOS_ENTRADA_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.TIPO_DE_DATO_IDColumnName:
                        case Modelo.VALOR_NUMEROColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.VALOR_FECHAColumnName:
                            sb.Append("trunc(" + f.Columna + ") " + f.Comparacion + " to_date('" + ((DateTime)f.Valor).ToShortDateString() + "', 'dd/mm/yyyy')");
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            var rows = sesion.db.CRM_HILOS_ENTRADAS_RELACIONESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CrmHilosEntradasRelacionesService[] r = new CrmHilosEntradasRelacionesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                r[i] = new CrmHilosEntradasRelacionesService(rows[i]);

            return r;
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
        public static string Nombre_Tabla = "CRM_HILOS_ENTRADAS_RELACIONES";
        public static string Nombre_Secuencia = "CRM_HILOS_ENTRADAS_RELAC_SQC";
        #endregion Accessors
    }
}
