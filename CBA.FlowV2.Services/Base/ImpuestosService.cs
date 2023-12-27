#region Using
using System.Data;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using System;
using System.Collections.Generic;
using System.Text;
using CBA.FlowV2.Services.Herramientas;
#endregion Using

namespace CBA.FlowV2.Services.Base
{
    public class ImpuestosService : ClaseCBA<ImpuestosService>
    {
        #region GetImpuestosDataTable
        /// <summary>
        /// Gets the impuestos data table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetImpuestosDataTable()
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.IMPUESTOSCollection.GetAsDataTable(ImpuestosService.Estado_NombreCol + " = '" + Definiciones.Estado.Activo + "'", ImpuestosService.Nombre_NombreCol);
            }
        }

        /// <summary>
        /// Gets the impuestos data table.
        /// </summary>
        /// <param name="clausulas">The clausulas.</param>
        /// <param name="orden">The orden.</param>
        /// <returns></returns>
        public static DataTable GetImpuestosDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.IMPUESTOSCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetImpuestosDataTable

        #region GetNombrePorId
        public static string GetNombrePorId(decimal impuesto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetNombrePorId(impuesto_id, sesion);
            }
        }

        public static string GetNombrePorId(decimal impuesto_id, SessionService sesion)
        {
            return sesion.Db.IMPUESTOSCollection.GetByPrimaryKey(impuesto_id).NOMBRE;
        }
        #endregion GetPorcentajePorId

        #region GetPorcentajePorId
        /// <summary>
        /// Gets the porcentaje por id.
        /// </summary>
        /// <param name="impuesto_id">The impuesto_id.</param>
        /// <returns></returns>
        public static decimal GetPorcentajePorId(decimal impuesto_id)
        {
            using (SessionService sesion = new SessionService())
            {
                IMPUESTOSRow row = sesion.Db.IMPUESTOSCollection.GetByPrimaryKey(impuesto_id);
                decimal porcentaje = ImpuestosCompuestosService.GetPorcentajeTotal(impuesto_id);

                //Si el impuesto es compuesto retorna un porcentaje distinto a -1
                //Si no es compuesto se utiliza el porcentaje de la tabla impuestos
                if (porcentaje == Definiciones.Error.Valor.EnteroPositivo)
                    porcentaje = row.PORCENTAJE;

                return porcentaje;
            }
        }
        public static decimal GetPorcentajePorId(decimal impuesto_id,SessionService sesion)
        {
            
                IMPUESTOSRow row = sesion.Db.IMPUESTOSCollection.GetByPrimaryKey(impuesto_id);
                decimal porcentaje = ImpuestosCompuestosService.GetPorcentajeTotal(impuesto_id);

                //Si el impuesto es compuesto retorna un porcentaje distinto a -1
                //Si no es compuesto se utiliza el porcentaje de la tabla impuestos
                if (porcentaje == Definiciones.Error.Valor.EnteroPositivo)
                    porcentaje = row.PORCENTAJE;

                return porcentaje;
            
        }
        #endregion GetPorcentajePorId

        #region GetImpuestoId
        /// <summary>
        /// Gets the impuesto id por porcentaje.
        /// </summary>
        /// <param name="porcentaje">The porcentaje.</param>
        /// <returns></returns>
        public static decimal GetImpuestoIdPorPorcentaje(decimal porcentaje) 
        {
            decimal impuesto = Definiciones.Error.Valor.EnteroPositivo;

            if (porcentaje == 0)
                impuesto =  Definiciones.Impuestos.Exenta;
            if (porcentaje == 5)
                impuesto = Definiciones.Impuestos.IVA_5;
            if (porcentaje == 10)
                impuesto = Definiciones.Impuestos.IVA_10;

            return impuesto;
        }
        #endregion GetImpuestoId

        #region GetMontoImpuestoDesdeBruto
        /// <summary>
        /// Gets the monto impuesto desde bruto.
        /// </summary>
        /// <param name="impuesto_id">The impuesto_id.</param>
        /// <param name="monto_bruto">The monto_bruto.</param>
        /// <returns></returns>
        public static decimal GetMontoImpuestoDesdeBruto(decimal impuesto_id, decimal monto_bruto)
        {
            return monto_bruto / ((100 / ImpuestosService.GetPorcentajePorId(impuesto_id)) + 1);
        }
        #endregion GetMontoImpuestoDesdeBruto

        #region GetMontoImpuestoDesdeNeto
        /// <summary>
        /// Gets the monto impuesto desde neto.
        /// </summary>
        /// <param name="impuesto_id">The impuesto_id.</param>
        /// <param name="monto_neto">The monto_neto.</param>
        /// <returns></returns>
        public static decimal GetMontoImpuestoDesdeNeto(decimal impuesto_id, decimal monto_neto)
        {
            return monto_neto * ImpuestosService.GetPorcentajePorId(impuesto_id) / 100;
        }
        #endregion GetMontoImpuestoDesdeNeto

        #region EsImpuestoInmobiliario
        public static bool EsImpuestoInmobiliario(decimal impuesto_padre_id)
        {
            using (SessionService sesion = new SessionService())
            {
                IMPUESTOSRow[] rows = sesion.db.IMPUESTOSCollection.GetAsArray(ImpuestosService.Id_NombreCol + " = " + impuesto_padre_id, string.Empty);

                return rows[0].TIPO_IMPUESTO_ID == Definiciones.TipoImpuesto.Inmuebles;
            }
        }
        #endregion EsInteresCompuesto

        #region Accesors
        public static string Nombre_Tabla
        {
            get { return "IMPUESTOS"; }
        }

        public static string Descripcion_NombreCol
        {
            get { return IMPUESTOSCollection.DESCRIPCIONColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return IMPUESTOSCollection.ESTADOColumnName; }
        }

        public static string Id_NombreCol
        {
            get { return IMPUESTOSCollection.IDColumnName; }
        }

        public static string TipoImpuestoId_NombreCol
        {
            get { return IMPUESTOSCollection.TIPO_IMPUESTO_IDColumnName; }
        }

        public static string Nombre_NombreCol
        {
            get { return IMPUESTOSCollection.NOMBREColumnName; }
        }

        public static string Orden_NombreCol
        {
            get { return IMPUESTOSCollection.ORDENColumnName; }
        }

        public static string PaisId_NombreCol
        {
            get { return IMPUESTOSCollection.PAIS_IDColumnName; }
        }

        public static string Porcentaje_NombreCol
        {
            get { return IMPUESTOSCollection.PORCENTAJEColumnName; }
        }

        public static string VistaPaisNombre_NombreCol
        {
            get { return IMPUESTOS_INFO_COMPLETACollection.PAIS_NOMBREColumnName; }
        }
        
        #endregion Accesors

        #region CODIGO NUEVO orientacion a objetos
        #region interfaz IEntidadMigrable
        public string GetOrCreateUUID(SessionService sesion)
        {
            return EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value, sesion);
        }

        public static ImpuestosService GetPorUUID(string uuid, SessionService sesion)
        {
            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return new ImpuestosService(e.RegistroId, sesion);
        }

        public static decimal? GetIdPorUUID(string uuid, SessionService sesion)
        {
            if (uuid.Length <= 0)
                return null;

            var e = EntidadesUUID.Instancia.GetPrimero<EntidadesUUID>(new ClaseCBABase.Filtro[] 
            {
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.TABLA_IDColumnName, Valor = Nombre_Tabla },
                new ClaseCBABase.Filtro() { Columna = EntidadesUUID.Modelo.UUIDColumnName, Valor = uuid },
            });

            if (e == null)
                return null;
            else
                return e.RegistroId;
        }
        #endregion interfaz IEntidadMigrable
        
        #region Propiedades
        protected IMPUESTOSRow row;
        protected IMPUESTOSRow rowSinModificar;
        public class Modelo : IMPUESTOSCollection_Base { public Modelo() : base(null) { } }

        public bool ExisteEnDB { get { return this.Id.HasValue; } }
        public bool AlmacenarLocalmente { get; set; }
        public bool FueModificado { get { return this.row.FueModificado(this.rowSinModificar); } }

        public string Descripcion { get { return row.DESCRIPCION; } set { row.DESCRIPCION = value; } }
        public string Estado { get { return row.ESTADO; } set { row.ESTADO = value; } }
        public decimal? Id { get { if (row.ID <= 0) return null; else return row.ID; } private set { if (value.HasValue) row.ID = value.Value; else row.ID = Definiciones.Error.Valor.EnteroPositivo; } }
        public string Nombre { get { return row.NOMBRE; } set { row.NOMBRE = value; } }
        public decimal? Orden { get { if (row.IsORDENNull) return null; else return row.ORDEN; } set { if (value.HasValue) row.ORDEN = value.Value; else row.IsORDENNull = true; } }
        public decimal PaisId { get { return row.PAIS_ID; } set { row.PAIS_ID = value; } }
        public decimal Porcentaje { get { return row.PORCENTAJE; } set { row.PORCENTAJE = value; } }
        #endregion Propiedades

        #region Constructores
        private void Inicializar(decimal id, SessionService sesion)
        {
            this.row = null;
            if (id != Definiciones.Error.Valor.EnteroPositivo)
            {
                this.row = sesion.db.IMPUESTOSCollection.GetByPrimaryKey(id);
            }
            else
            {
                this.row = new IMPUESTOSRow();
                this.Id = Definiciones.Error.Valor.EnteroPositivo;
            }

            this.rowSinModificar = this.row.Clonar();
        }
        private void Inicializar(IMPUESTOSRow row)
        {
            this.row = row;
            this.rowSinModificar = this.row.Clonar();
        }

        public ImpuestosService(decimal id, SessionService sesion) { Inicializar(id, sesion); }
        public ImpuestosService() : this(Definiciones.Error.Valor.EnteroPositivo) { }
        public ImpuestosService(decimal id) 
        {
            using (SessionService sesion = new SessionService())
            {
                this.IniciarUsingSesion(sesion);
                Inicializar(id, sesion);
                this.FinalizarUsingSesion();
            }
        }
        public ImpuestosService(EdiCBA.Impuesto edi, bool almacenar_localmente, SessionService sesion)
        {
            Inicializar(Definiciones.Error.Valor.EnteroPositivo, sesion); 
            this.AlmacenarLocalmente = almacenar_localmente;

            this.Id = ImpuestosService.GetIdPorUUID(edi.uuid, sesion);
            if (this.ExisteEnDB)
                Inicializar(this.Id.Value, sesion); 

            this.Descripcion = edi.descripcion;
            this.Nombre = edi.nombre;
            this.Porcentaje = edi.porcentaje;
        }

        private ImpuestosService(IMPUESTOSRow row)
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
                this.row.ID = sesion.db.GetSiguienteSecuencia("no existe secuencia");
                sesion.db.IMPUESTOSCollection.Insert(this.row);
                LogCambiosService.LogDeRegistroJSON(Nombre_Tabla, this.row.ID, this.row, null, sesion);
            }
            else
            {
                sesion.db.IMPUESTOSCollection.Update(this.row);
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
            //La modificación de impuestos por el momento se realiza desde la db
            excepciones.Agregar("No tiene permisos para guardar.", null);
            
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
        protected override ImpuestosService[] Buscar(Filtro[] filtros)
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
                        case Modelo.ORDENColumnName:
                        case Modelo.PAIS_IDColumnName:
                        case Modelo.PORCENTAJEColumnName:
                            if (f.Exacto)
                                sb.Append(f.Columna + " = " + f.Valor);
                            else
                                sb.Append(f.Columna + " in (" + string.Join(",", Array.ConvertAll((decimal[])f.Valor, i => i.ToString())) + ")");
                            break;
                        case Modelo.DESCRIPCIONColumnName:
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

            orden.Add(Modelo.ORDENColumnName);
            IMPUESTOSRow[] rows = sesion.db.IMPUESTOSCollection.GetAsArray(sb.ToString(), string.Join(",", orden.ToArray()));
            ImpuestosService[] imp = new ImpuestosService[rows.Length];
            for (int i = 0; i < rows.Length; i++)
                imp[i] = new ImpuestosService(rows[i]);

            return imp;
        }
        #endregion Buscar

        #region ToEDI
        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(SessionService sesion)
        {
            return this.ToEDI(0, sesion);
        }

        public override CBA.FlowV2.Services.Base.EdiCBA.Estructura ToEDI(int profundidad_resolucion, SessionService sesion)
        {
            int nueva_profundidad = EdiCBA.ProfundidadResolucion.DisminuirNivel(profundidad_resolucion);

            var e = new EdiCBA.Impuesto()
            {
                descripcion = this.Descripcion,
                nombre = this.Nombre,
                porcentaje = this.Porcentaje
            };

            if (this.ExisteEnDB)
            {
                e.id = this.Id.Value;
                e.uuid = EntidadesUUID.GetOrCreate(Nombre_Tabla, string.Empty, this.Id.Value);
            }
            return e;
        }
        #endregion ToEDI

        #endregion CODIGO NUEVO orientacion a objetos
    }
}
