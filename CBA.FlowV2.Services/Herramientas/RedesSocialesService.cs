#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;

using System.Collections.Generic;
using System.Text;
#endregion Using

namespace CBA.FlowV2.Services.Herramientas
{
    public class RedesSocialesService : ClaseCBA<RedesSocialesService>
    {
        #region Propiedades
        protected REDES_SOCIALESRow row;
        protected REDES_SOCIALESRow rowSinModificar;
        public class Modelo : REDES_SOCIALESCollection_Base { public Modelo() : base(null) { } }
        
        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.REDES_SOCIALESCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new REDES_SOCIALESRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }
        private void Inicializar(REDES_SOCIALESRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public RedesSocialesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public RedesSocialesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public RedesSocialesService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private RedesSocialesService(REDES_SOCIALESRow row)
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
                if(this.excepciones.ExistenErrores)
                    return Definiciones.Error.Valor.EnteroPositivo;

                if (!this.ExisteEnDB)
                {
                    this.row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                    sesion.db.REDES_SOCIALESCollection.Insert(this.row);
                    LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, null, sesion);
                }
                else
                {
                    sesion.db.REDES_SOCIALESCollection.Update(this.row);
                    LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, this.rowSinModificar, sesion);
                }

                this.rowSinModificar = this.row.Clonar();

                return this.row.ID;
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
            

            if (!RolesService.Tiene("redes sociales editar"))
                this.excepciones.Agregar("No tiene permisos para guardar.", null);

            if (this.row.NOMBRE.Length <= 0)
                this.excepciones.Agregar("Debe indicar el nombre.", null);

            if (this.excepciones.ExistenErrores)
                throw new Exception(this.excepciones.ToString());
        }
        #endregion Validar

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override RedesSocialesService[] Buscar(Filtro[] filtros)
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
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            REDES_SOCIALESRow[] rows = sesion.db.REDES_SOCIALESCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            RedesSocialesService[] rs = new RedesSocialesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                rs[i] = new RedesSocialesService(rows[i]);
            return rs;
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
            get { return "REDES_SOCIALES"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "REDES_SOCIALES_SQC"; }
        }
        #endregion Accessors
    }
}
