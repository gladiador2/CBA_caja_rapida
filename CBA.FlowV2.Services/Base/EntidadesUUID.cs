#region Using
using System;
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Casos;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Tesoreria;
using CBA.FlowV2.Services.Common;
using System.Collections;
using System.Collections.Generic;
using CBA.FlowV2.Services.Articulos;
using System.Collections.Specialized;
using System.Text;
using CBA.FlowV2.Services.ToolbarFlujo;
using CBA.FlowV2.Services.General;
using CBA.FlowV2.Services.EgresosVariosCaja;
using CBA.FlowV2.Services.Anticipo;
using CBA.FlowV2.Services.NotasCreditoPersona;
#endregion Using

namespace CBA.FlowV2.Services.Base
{
    public partial class EntidadesUUID : ClaseCBA<EntidadesUUID>
    {
        #region GenerarUUID
        public static string GenerarUUID()
        {
            return System.Guid.NewGuid().ToString("").ToUpper();
        }
        #endregion GenerarUUID

        #region Propiedades
        protected ENTIDADES_UUIDRow row;
        protected ENTIDADES_UUIDRow rowSinModificar;
        public class Modelo : ENTIDADES_UUIDCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.UUID.Length > 0; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string UUID { get { return ClaseCBABase.GetStringHelper(row.UUID); } set { row.UUID = value; } }
        public string TablaId { get { return ClaseCBABase.GetStringHelper(row.TABLA_ID); } set { row.TABLA_ID = value; } }
        public string CampoId { get { return ClaseCBABase.GetStringHelper(row.CAMPO_ID); } set { row.CAMPO_ID = value; } }
        public decimal RegistroId { get { return row.REGISTRO_ID; } set { row.REGISTRO_ID = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(string uuid, SessionService sesion)
        {
            this.row = null;
            if (!string.IsNullOrEmpty(uuid))
            {
                this.row = sesion.db.ENTIDADES_UUIDCollection.GetByPrimaryKey(this.UUID);
            }
            else
            {
                this.row = new ENTIDADES_UUIDRow();
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(ENTIDADES_UUIDRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public EntidadesUUID(string uuid, SessionService sesion) { Inicializar(uuid, sesion); }
        public EntidadesUUID() : this(string.Empty) { }
        public EntidadesUUID(string uuid)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(uuid, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private EntidadesUUID(ENTIDADES_UUIDRow row)
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
                this.UUID = EntidadesUUID.GenerarUUID();
                sesion.db.ENTIDADES_UUIDCollection.Insert(this.row);
            }
            else
            {
                sesion.db.ENTIDADES_UUIDCollection.Update(this.row);
            }

            this.rowSinModificar = this.row.Clonar();
            return Definiciones.Error.Valor.EnteroPositivo;
        }
        #endregion Guardar

        #region Validar
        protected override void ValidarPrivado(SessionService sesion)
        {
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();

            if (this.TablaId.Length <= 0)
                excepciones.Agregar("Debe indicar la tabla.");

            if (this.RegistroId <= 0)
                excepciones.Agregar("Debe indicar el registro.");

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
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Borrar(sesion);
                this.FinalizarUsingSesion();
            }
        }

        public void Borrar(SessionService sesion)
        {
            if (this.ExisteEnDB)
                sesion.db.ENTIDADES_UUIDCollection.DeleteByPrimaryKey(this.UUID);
        }
        #endregion Borrar

        #region Buscar
        protected override EntidadesUUID[] Buscar(Filtro[] filtros)
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
                        case Modelo.UUIDColumnName:
                        case Modelo.TABLA_IDColumnName:
                            sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            break;
                        case Modelo.CAMPO_IDColumnName:
                            if (f.Valor.ToString() == string.Empty)
                                sb.Append("upper(" + f.Columna + ") is null");
                            else
                                sb.Append("upper(" + f.Columna + ") " + f.Comparacion + " '" + f.Valor.ToString().ToUpper() + "'");
                            break;
                        case Modelo.REGISTRO_IDColumnName:
                            sb.Append(f.Columna + " " + f.Comparacion + " " + f.Valor);
                            break;
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            ENTIDADES_UUIDRow[] rows = sesion.db.ENTIDADES_UUIDCollection.GetAsArray(sb.ToString(), string.Empty);
            EntidadesUUID[] eu = new EntidadesUUID[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                eu[i] = new EntidadesUUID(rows[i]);

            return eu;
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

        #region GetOrCreate
        public static string GetOrCreate(string tabla_id, string campo_id, decimal registro_id)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.BeginTransaction();
                    string resultado = GetOrCreate(tabla_id, campo_id, registro_id, sesion);
                    sesion.CommitTransaction();
                    return resultado;
                }
                catch (Exception)
                {
                    sesion.RollbackTransaction();
                    throw;
                }
            }
        }

        public static string GetOrCreate(string tabla_id, string campo_id, decimal registro_id, SessionService sesion)
        {
            var uuid = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] {
                new ClaseCBABase.Filtro { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = tabla_id },
                new ClaseCBABase.Filtro { Columna = EntidadesUUID.Modelo.CAMPO_IDColumnName, Valor = campo_id },
                new ClaseCBABase.Filtro { Columna = EntidadesUUID.Modelo.REGISTRO_IDColumnName, Valor = registro_id },
            });

            if (uuid == null)
            {
                uuid = new EntidadesUUID()
                {
                    TablaId = tabla_id,
                    RegistroId = registro_id,
                    CampoId = campo_id
                };
                uuid.IniciarUsingSesion(sesion);
                uuid.Guardar();
                uuid.FinalizarUsingSesion();
            }

            return uuid.UUID;
        }
        #endregion GetOrCreate

        #region Accessors
        public static string Nombre_Tabla = "ENTIDADES_UUID";
        #endregion Accessors
    }
}
