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

namespace CBA.FlowV2.Services.Articulos
{
    public class CatalogosDetallesService : ClaseCBA<CatalogosDetallesService>
    {
        #region FiltrosExtension
        public static class FiltroExtension
        {
            public const string ArticuloTexto = "ArticuloTexto";
            public const string TextoPredefinidoId = "TextoPredefinidoId";
        }
        #endregion FiltrosExtension

        #region Propiedades
        protected CATALOGOS_DETALLERow row;
        protected CATALOGOS_DETALLERow rowSinModificar;
        public class Modelo : CATALOGOS_DETALLECollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public decimal? ArticuloId { get { if (row.IsARTICULO_IDNull) return null; else return row.ARTICULO_ID; } set { if (value.HasValue) row.ARTICULO_ID = value.Value; else row.IsARTICULO_IDNull = true; } }
        public decimal CatalogoId { get { return row.CATALOGO_ID; } set { row.CATALOGO_ID = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal FamiliaId { get { return row.FAMILIA_ID; } set { row.FAMILIA_ID = value; } }
        public decimal? GrupoId { get { if (row.IsGRUPO_IDNull) return null; else return row.GRUPO_ID; } set { if (value.HasValue) row.GRUPO_ID = value.Value; else row.IsGRUPO_IDNull = true; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public decimal? SubGrupoId { get { if (row.IsSUBGRUPO_IDNull) return null; else return row.SUBGRUPO_ID; } set { if (value.HasValue) row.SUBGRUPO_ID = value.Value; else row.IsSUBGRUPO_IDNull = true; } }
        public string Observacion { get { return GetStringHelper(row.OBSERVACION); } set { row.OBSERVACION = value; } }
        #endregion Propiedades

        #region Propiedades Extendidas
        private CatalogosService _catalogo;
        public CatalogosService Catalogo
        {
            get
            {
                if (this._catalogo == null)
                    this._catalogo = new CatalogosService(this.CatalogoId);
                return this._catalogo;
            }
        }

        private ArticulosFamiliasService _familia;
        public ArticulosFamiliasService Familia
        {
            get
            {
                if (this._familia == null)
                    this._familia = new ArticulosFamiliasService(this.FamiliaId);
                return this._familia;
            }
        }

        private ArticulosGruposService _grupos;
        public ArticulosGruposService Grupos
        {
            get
            {
                if (this._grupos == null)
                    this._grupos = new ArticulosGruposService(this.GrupoId.Value);
                return this._grupos;
            }
        }

        private ArticulosService _articulos;
        public ArticulosService Articulos
        {
            get
            {
                if (this._articulos == null)
                    this._articulos = new ArticulosService(this.ArticuloId.Value);
                return this._articulos;
            }
        }

        private ArticulosSubgruposService _subgrupos;
        public ArticulosSubgruposService Subgrupos
        {
            get
            {
                if (this._subgrupos == null)
                    this._subgrupos = new ArticulosSubgruposService(this.SubGrupoId.Value);
                return this._subgrupos;
            }
        }
        #endregion Propiedades Extendidas

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.CATALOGOS_DETALLECollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new CATALOGOS_DETALLERow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(CATALOGOS_DETALLERow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public CatalogosDetallesService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public CatalogosDetallesService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public CatalogosDetallesService(decimal id)
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        private CatalogosDetallesService(CATALOGOS_DETALLERow row)
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
                sesion.db.CATALOGOS_DETALLECollection.Insert(this.row);

                LogCambiosService.LogDeRegistro(Nombre_Tabla, this.row.ID, this.row.ToString(), Definiciones.Log.RegistroNuevo, sesion);
            }
            else
            {
                sesion.db.CATALOGOS_DETALLECollection.Update(this.row);
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
            this._catalogo = null;
        }
        #endregion ResetearPropiedadesExtendidas

        #region Buscar
        protected override CatalogosDetallesService[] Buscar(Filtro[] filtros)
        {
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            
            sb.Append(Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo +"'");

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
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.CATALOGO_IDColumnName:
                        case Modelo.FAMILIA_IDColumnName:
                        case Modelo.GRUPO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.SUBGRUPO_IDColumnName:
                            if(f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.ESTADOColumnName:
                        case Modelo.OBSERVACIONColumnName:
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
            CATALOGOS_DETALLERow[] rows = sesion.db.CATALOGOS_DETALLECollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            CatalogosDetallesService[] cd = new CatalogosDetallesService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                cd[i] = new CatalogosDetallesService(rows[i]);
            return cd;
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

        #region BuscarArticulos
        public static ArticulosService[] BuscarArticulos(Filtro[] filtros, SessionService sesion)
        { 
            List<string> orden = new List<string>();
            StringBuilder sb = new StringBuilder();
            
            sb.Append(ArticulosService.Modelo.PARA_VENTAColumnName + " = '" + Definiciones.SiNo.Si + "' and " +
                      ArticulosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' and " +
                      ArticulosService.Modelo.CONTROLAR_PRECIOColumnName + " = '" + Definiciones.SiNo.Si + "' and " +
                      ArticulosService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "' ");

            Filtro fArticuloTexto = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == FiltroExtension.ArticuloTexto; });
            if (fArticuloTexto != null)
            {
                string articuloTexto = fArticuloTexto.Valor.ToString().ToUpper();

                if (fArticuloTexto.Exacto)
                    sb.Append(" and (upper(nvl(" + ArticulosService.Modelo.DESCRIPCION_IMPRESIONColumnName + ", " + ArticulosService.Modelo.DESCRIPCION_INTERNAColumnName + ")) = '" + articuloTexto + "' or " +
                              "      upper(" + ArticulosService.Modelo.CODIGO_EMPRESAColumnName + ") = '" + articuloTexto + "')");
                else
                    sb.Append(" and (upper(nvl(" + ArticulosService.Modelo.DESCRIPCION_IMPRESIONColumnName + ", " + ArticulosService.Modelo.DESCRIPCION_INTERNAColumnName + ")) like '%" + articuloTexto + "%' or " +
                              "      upper(" + ArticulosService.Modelo.CODIGO_EMPRESAColumnName + ") like '%" + articuloTexto + "%')");
            }

            Filtro fTextoPredefinido = Array.Find(filtros, delegate(Filtro filtro) { return filtro.Columna == FiltroExtension.TextoPredefinidoId; });
            if (fTextoPredefinido != null)
            {
                sb.Append(" and exists(select etp.id from " + EntidadesTextoPredefinidoService.Nombre_Tabla + " etp " +
                          "             where etp." + EntidadesTextoPredefinidoService.Modelo.ESTADOColumnName + " = '" + Definiciones.Estado.Activo + "'" +
                          "               and etp." + EntidadesTextoPredefinidoService.Modelo.TABLA_IDColumnName + " = '" + ArticulosService.Nombre_Tabla + "'" +
                          "               and etp." + EntidadesTextoPredefinidoService.Modelo.REGISTRO_IDColumnName + " = " + ArticulosService.Nombre_Tabla + "." + ArticulosService.Id_NombreCol);
                if (fTextoPredefinido.Exacto)
                    sb.Append(" and etp." + EntidadesTextoPredefinidoService.Modelo.TEXTO_PREDEFINIDO_IDColumnName + " = " + fTextoPredefinido.Valor);
                else
                    sb.Append(" and etp." + EntidadesTextoPredefinidoService.Modelo.TEXTO_PREDEFINIDO_IDColumnName + " in (" + string.Join(",", Array.ConvertAll((int[])fTextoPredefinido.Valor, i => i.ToString())) + ")");
                sb.Append(")");
            }

            sb.Append(" and exists(select cd.id from " + CatalogosDetallesService.Nombre_Tabla + " cd " +
                     "         where (cd." + Modelo.ARTICULO_IDColumnName + " = " + ArticulosService.Nombre_Tabla + "." + ArticulosService.Modelo.IDColumnName + " or " +
                     "                (cd." + Modelo.SUBGRUPO_IDColumnName + " = " + ArticulosService.Nombre_Tabla + "." + ArticulosService.Modelo.SUBGRUPO_IDColumnName + " and cd." + Modelo.ARTICULO_IDColumnName + " is null) or " +
                     "                (cd." + Modelo.GRUPO_IDColumnName + " = " + ArticulosService.Nombre_Tabla + "." + ArticulosService.Modelo.GRUPO_IDColumnName + " and cd." + Modelo.SUBGRUPO_IDColumnName + " is null) or " +
                     "                (cd." + Modelo.FAMILIA_IDColumnName + " = " + ArticulosService.Nombre_Tabla + "." + ArticulosService.Modelo.FAMILIA_IDColumnName + " and cd." + Modelo.GRUPO_IDColumnName + " is null)) ");

            foreach (Filtro f in filtros)
            {
                if (f.OrderBy)
                {
                    orden.Add(f.Columna + " " + f.Valor);
                }
                else
                {
                    if (f.Columna == FiltroExtension.ArticuloTexto || f.Columna == FiltroExtension.TextoPredefinidoId)
                        continue;

                    sb.Append(" and ");
                    switch (f.Columna)
                    {
                        case Modelo.ARTICULO_IDColumnName:
                        case Modelo.CATALOGO_IDColumnName:
                        case Modelo.IDColumnName:
                        case Modelo.FAMILIA_IDColumnName:
                        case Modelo.GRUPO_IDColumnName:
                        case Modelo.SUBGRUPO_IDColumnName:
                            sb.Append("cd." + f.Columna + " = " + f.Valor);
                            break;
                        case Modelo.OBSERVACIONColumnName:
                            if (f.Exacto)
                                sb.Append("upper(cd." + f.Columna + ") = '" + f.Valor.ToString().ToUpper() + "'");
                            else
                                sb.Append("upper(cd." + f.Columna + ") like '%" + f.Valor.ToString().ToUpper() + "%'");
                            break;
                        default: throw new Exception(typeof(CatalogosDetallesService).ToString() + ".BuscarArticulos. Campo " + f.Columna + " no implementado en la búsqueda.");
                    }
                }
            }
            sb.Append(")");

            return ArticulosService.Buscar(sb.ToString(), null, "nvl(" + ArticulosService.Modelo.DESCRIPCION_IMPRESIONColumnName + ", " + ArticulosService.Modelo.DESCRIPCION_INTERNAColumnName + ")", sesion);
        }
        #endregion BuscarArticulos

        #region Accessors
        public static string Nombre_Tabla = "CATALOGOS_DETALLE";
        public static string Nombre_Secuencia = "CATALOGOS_DETALLE_SQC";
        #endregion Accessors
    }
}
