using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using System.Data;
using System.Collections;

namespace CBA.FlowV2.Services.Stock
{
    public class StockUbicacionService : ClaseCBA<StockUbicacionService>
    {
        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "STOCK_UBICACION"; }
        }
        public static string Nombre_Vista
        {
            get { return "STOCK_UBICACION_INFO_COMPLETA"; }
        }
        public static string Nombre_Secuencia
        {
            get { return "STOCK_UBICACION_SQC"; }
        }

        public static string Pasillo_NombreCol
        {
            get { return STOCK_UBICACIONCollection.PASILLOColumnName; }
        }

        public static string Estante_NombreCol
        {
            get { return STOCK_UBICACIONCollection.ESTANTEColumnName; }
        }

        public static string Nivel_NombreCol
        {
            get { return STOCK_UBICACIONCollection.NIVELColumnName; }
        }

        public static string Columna_NombreCol
        {
            get { return STOCK_UBICACIONCollection.COLUMNAColumnName; }
        }

        public static string StockArtiDeposito_NombreCol
        {
            get { return STOCK_UBICACIONCollection.STOCK_SUC_DEP_ART_IDColumnName; }
        }

        public static string Cantidad_NombreCol
        {
            get { return STOCK_UBICACIONCollection.CANTIDADColumnName; }
        }
        #endregion Accesors

        #region Guardar
        public static bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            try
            {
                using (SessionService sesion = new SessionService())
                {
                    STOCK_UBICACIONRow row = new STOCK_UBICACIONRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        row.ID = sesion.Db.GetSiguienteSecuencia("stock_ubicacion_sqc");

                        row.STOCK_SUC_DEP_ART_ID = decimal.Parse(campos[StockUbicacionService.StockArtiDeposito_NombreCol].ToString());
                        row.PASILLO = campos[StockUbicacionService.Pasillo_NombreCol].ToString();
                        row.ESTANTE = campos[StockUbicacionService.Estante_NombreCol].ToString();
                        row.NIVEL = campos[StockUbicacionService.Nivel_NombreCol].ToString();
                        row.COLUMNA = campos[StockUbicacionService.Columna_NombreCol].ToString();
                        row.CANTIDAD = decimal.Parse(campos[StockUbicacionService.Cantidad_NombreCol].ToString());

                        if (insertarNuevo)
                            sesion.Db.STOCK_UBICACIONCollection.Insert(row);
                        else
                            sesion.Db.STOCK_UBICACIONCollection.Update(row);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Guardar



        #region CODIGO ORIENTACION A OBJETOS

        #region Propiedades
        public class Modelo : STOCK_UBICACIONCollection_Base { public Modelo() : base(null) { } }
        public class VistaModelo : STOCK_UBICACION_INFO_COMPLETARow_Base { }
        protected STOCK_UBICACIONRow row;
        protected STOCK_UBICACIONRow rowSinModificar;

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }
        public CBA.FlowV2.Services.Base.Excepciones excepciones { get; private set; }

        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? StockSucDepArtId { get { if (row.STOCK_SUC_DEP_ART_ID <= 0) return null; else return row.STOCK_SUC_DEP_ART_ID; }  set { if (value.HasValue) row.STOCK_SUC_DEP_ART_ID = value.Value; else row.STOCK_SUC_DEP_ART_ID = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo; } }
        public string Pasillo { get { return row.PASILLO; } set { row.PASILLO = value; } }
        public string Estante { get { return row.ESTANTE; } set { row.ESTANTE = value; } }
        public string Nivel { get { return row.NIVEL; } set { row.NIVEL = value; } }
        public string Columna { get { return row.COLUMNA; } set { row.COLUMNA = value; } }
        public decimal? Cantidad { get { if (row.CANTIDAD <= 0) return null; else return row.CANTIDAD; }  set { if (value.HasValue) row.CANTIDAD = value.Value; else row.CANTIDAD = CBA.FlowV2.Services.Base.Definiciones.Error.Valor.EnteroPositivo; } }
        
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.STOCK_UBICACIONCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new STOCK_UBICACIONRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
            
        }

        public StockUbicacionService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public StockUbicacionService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public StockUbicacionService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                Inicializar(id, sesion);
            }
        }
        #endregion Constructores

        #region Guardar
        protected override decimal GuardarPrivado(SessionService sesion)
        {
            try
            {
                this.ValidarPrivado(sesion);
                if (this.excepciones.ExistenErrores)
                    return Definiciones.Error.Valor.EnteroPositivo;

                if (!this.ExisteEnDB)
                {
                    this.row.ID = sesion.db.GetSiguienteSecuencia(Nombre_Secuencia);
                    sesion.db.STOCK_UBICACIONCollection.Insert(this.row);
                    LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, null, sesion);
                }
                else
                {
                    sesion.db.STOCK_UBICACIONCollection.Update(this.row);
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
            CBA.FlowV2.Services.Base.Excepciones excepciones = new CBA.FlowV2.Services.Base.Excepciones();
            if (excepciones.ExistenErrores)
                throw new Exception(excepciones.ToString());
        }
        #endregion Validar

        protected override StockUbicacionService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    switch (f.Columna)
                    {
                        case Modelo.IDColumnName:
                        default: throw new Exception(this.GetType().ToString() + ".Buscar. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }

            orden.Add(Modelo.IDColumnName);
            STOCK_UBICACIONRow[] rows = sesion.db.STOCK_UBICACIONCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            StockUbicacionService[] n = new StockUbicacionService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                n[i] = new StockUbicacionService(rows[i].ID);

            return n;
        }

        #region ResetearPropiedadesExtendidas
        public override void ResetearPropiedadesExtendidas()
        {
        }
        #endregion ResetearPropiedadesExtendidas

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

        #endregion CODIGO ORIENTACION A OBJETOS

    }
}
