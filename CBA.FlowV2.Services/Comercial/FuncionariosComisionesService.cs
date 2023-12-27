using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Herramientas;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Data;
using CBA.FlowV2.Services.RecursosHumanos;
using CBA.FlowV2.Services.Tesoreria;

namespace CBA.FlowV2.Services.Comercial
{
    public class FuncionariosComisionesService
    {
        #region GetFuncionarioComisionDataTable
        public DataTable GetFuncionarioComisionDataTable(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFuncionarioComisionDataTable(clausulas, orden, sesion);
            }
        }
        public DataTable GetFuncionarioComisionDataTable(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FUNCIONARIOS_COMISIONESCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetFuncionarioComisionDataTable

        #region GetFuncionarioComisionInfoCompleta
        public DataTable GetFuncionarioComisionInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return sesion.Db.FUNCIONARIOS_COMISIONES_INFO_CCollection.GetAsDataTable(clausulas, orden);
            }
        }
        #endregion GetFuncionarioComisionInfoCompleta

        #region GenerarBonificacion
        public void GenerarBonificacion(SessionService sesion, decimal funcionario_id, DateTime desde, DateTime hasta, decimal moneda_id, decimal cotizacion)
        {
            #region Generar Comision Cobrador
            string clausulas = FuncionariosMontosCobradosService.FuncionarioId_NombreCol + " = " + funcionario_id +
                " and " + FuncionariosMontosCobradosService.FuncionarioComisionId_NombreCol + " is null " +
                " and " + FuncionariosMontosCobradosService.Fecha_NombreCol + " >= to_date('" + desde.ToShortDateString() + "','dd/mm/yyyy')" +
                " and " + FuncionariosMontosCobradosService.Fecha_NombreCol + " <= to_date('" + hasta.ToShortDateString() + "','dd/mm/yyyy')";
            DataTable dtMontosCobrados = FuncionariosMontosCobradosService.GetFuncionariosMontosCobradosDataTable(clausulas, string.Empty);
            decimal totalMontoCobradoDolares = 0;
            foreach(DataRow row in dtMontosCobrados.Rows)
            {
                decimal montoCobrado = (decimal)row[FuncionariosMontosCobradosService.Monto_NombreCol];
                decimal cotizacionCobrado = (decimal)row[FuncionariosMontosCobradosService.Cotizacion_NombreCol];
                totalMontoCobradoDolares += montoCobrado / cotizacionCobrado;
            }

            decimal comisionCobradorDolares = ObjetivosCobradoresService.ObtenerComisionDolares(funcionario_id, DateTime.Now.Year, totalMontoCobradoDolares, Definiciones.Monedas.Dolares);
            if (comisionCobradorDolares > 0)
            {
                FuncionariosComisionesService funcionarioComisiones = new FuncionariosComisionesService();
                System.Collections.Hashtable campos = new System.Collections.Hashtable();
                //campos.Add(FuncionariosComisionesService.CasoId_NombreCol, casoId);
                campos.Add(FuncionariosComisionesService.Cobrado_NombreCol, Definiciones.SiNo.No);
                campos.Add(FuncionariosComisionesService.Cotizacion_NombreCol, cotizacion);
                campos.Add(FuncionariosComisionesService.Fecha_NombreCol, DateTime.Now);
                campos.Add(FuncionariosComisionesService.FuncionarioId_NombreCol, funcionario_id);
                campos.Add(FuncionariosComisionesService.MonedaId_NombreCol, moneda_id);
                campos.Add(FuncionariosComisionesService.Monto_NombreCol, comisionCobradorDolares * cotizacion);
                campos.Add(FuncionariosComisionesService.TipoComision_NombreCol, Definiciones.TiposComision.ComisionPorCobro);
                campos.Add(FuncionariosComisionesService.TipoFuncionario_NombreCol, Definiciones.TipoFuncionarioComision.Cobrador);
                decimal idFuncionarioComision = funcionarioComisiones.Guardar(campos, true, sesion);
                
                foreach (DataRow row in dtMontosCobrados.Rows)
                    FuncionariosMontosCobradosService.AgregarFuncionarioComision((decimal)row[FuncionariosMontosCobradosService.Id_NombreCol], idFuncionarioComision, sesion);
            }
            #endregion Generar Comision Cobrador

            clausulas = FuncionariosComisionesService.FuncionarioId_NombreCol + " = " + funcionario_id.ToString() +
                 " and " + FuncionariosComisionesService.Fecha_NombreCol + " >= to_date('" + desde.ToShortDateString() + "','dd/mm/yyyy')" +
                 " and " + FuncionariosComisionesService.Fecha_NombreCol + " <= to_date('" + hasta.ToShortDateString() + "','dd/mm/yyyy')" +
                 " and " + FuncionariosComisionesService.Monto_NombreCol + " > 0";
            DataTable dt = GetFuncionarioComisionDataTable(clausulas, string.Empty, sesion);
            decimal totalComisionVendedor = 0;
            decimal totalComisionPromotor = 0;
            decimal totalComisionCobrador = 0;
            
            System.Collections.Hashtable totalComisionPromotorDolares = new System.Collections.Hashtable();

            foreach (DataRow row in dt.Rows)
            {
                if (row[FuncionariosComisionesService.FuncionarioBonificacionId_NombreCol] == DBNull.Value)
                {
                    decimal cotizacionComision = (decimal)row[FuncionariosComisionesService.Cotizacion_NombreCol];
                    decimal montoComision = (decimal)row[FuncionariosComisionesService.Monto_NombreCol];
                    
                    switch ((string)row[FuncionariosComisionesService.TipoFuncionario_NombreCol])
                    {
                        case Definiciones.TipoFuncionarioComision.Promotor:
                            decimal montoComisionDolares = montoComision / cotizacionComision;
                            decimal personaId = (decimal)row[FuncionariosComisionesService.PersonaId_NombreCol];
                            if (!totalComisionPromotorDolares.Contains(personaId)) totalComisionPromotorDolares.Add(personaId, (decimal)0);
                            totalComisionPromotorDolares[personaId] = (decimal)totalComisionPromotorDolares[personaId] + montoComisionDolares;
                            break;
                        case Definiciones.TipoFuncionarioComision.Vendedor:
                            totalComisionVendedor += (cotizacion * montoComision) / cotizacionComision;
                            break;
                        case Definiciones.TipoFuncionarioComision.Cobrador:
                            totalComisionCobrador += (cotizacion * montoComision) / cotizacionComision;
                            break;
                    }
                }
            }

            foreach(decimal personaId in totalComisionPromotorDolares.Keys)
            {
                clausulas = ObjetivosPromotorasService.Anho_NombreCol + " = " + DateTime.Now.Year +
                    " and " + ObjetivosPromotorasService.PersonaId_NombreCol + " = " + personaId +
                    " and " + ObjetivosPromotorasService.FuncionarioId_NombreCol + " = " + funcionario_id;
                DataTable dtObjetivosPromotoras = ObjetivosPromotorasService.GetObjetivosPromotorasDataTable(clausulas, string.Empty);

                decimal montoTopeDolares = (decimal)dtObjetivosPromotoras.Rows[0][ObjetivosPromotorasService.MontoTope_NombreCol] / CotizacionesService.GetCotizacionMonedaVenta((decimal)dtObjetivosPromotoras.Rows[0][ObjetivosPromotorasService.MonedaId_NombreCol]);

                if ((decimal)totalComisionPromotorDolares[personaId] > montoTopeDolares)
                    totalComisionPromotor += montoTopeDolares * cotizacion;
                else
                    totalComisionPromotor += (decimal)totalComisionPromotorDolares[personaId] * cotizacion;
            }

            decimal totalComision = totalComisionPromotor + totalComisionVendedor + totalComisionCobrador;
            if (totalComision > 0)
            {
                FuncionariosBonificacionesService funcionarioBonificacion = new FuncionariosBonificacionesService();
                System.Collections.Hashtable campos = new System.Collections.Hashtable();

                campos.Add(FuncionariosBonificacionesService.FuncionarioId_NombreCol, funcionario_id);
                campos.Add(FuncionariosBonificacionesService.MonedaId_NombreCol, moneda_id);
                campos.Add(FuncionariosBonificacionesService.UtilizarPorcentaje_NombreCol, Definiciones.SiNo.No);
                campos.Add(FuncionariosBonificacionesService.Monto_NombreCol, totalComision);
                campos.Add(FuncionariosBonificacionesService.Estado_NombreCol, Definiciones.Estado.Activo);
                campos.Add(FuncionariosBonificacionesService.BonificacionId_NombreCol, Definiciones.TipoBonificacion.Comision);
                campos.Add(FuncionariosBonificacionesService.Observacion_NombreCol, string.Empty);

                //Guardar los datos
                decimal funcionarioBonificacionId = funcionarioBonificacion.Guardar(campos, true, sesion);

                foreach (DataRow row in dt.Rows)
                {
                    decimal funcionarioComisionId = (decimal)row[FuncionariosComisionesService.Id_NombreCol];
                    FUNCIONARIOS_COMISIONESRow funcionarioComisionRow = sesion.Db.FUNCIONARIOS_COMISIONESCollection.GetByPrimaryKey(funcionarioComisionId);
                    funcionarioComisionRow.FUNCIONARIO_BONIFICACION_ID = funcionarioBonificacionId;
                    sesion.Db.FUNCIONARIOS_COMISIONESCollection.Update(funcionarioComisionRow);
                }
            }
        }
        #endregion GenerarBonificacion

        #region GenerarDescuento
        public void GenerarDescuento(SessionService sesion, decimal funcionario_id, DateTime desde, DateTime hasta, decimal moneda_id, decimal cotizacion)
        {
            string clausulas = FuncionariosComisionesService.FuncionarioId_NombreCol + " = " + funcionario_id.ToString() +
                 " and " + FuncionariosComisionesService.Fecha_NombreCol + " >= to_date('" + desde.ToShortDateString() + "','dd/mm/yyyy')" +
                 " and " + FuncionariosComisionesService.Fecha_NombreCol + " <= to_date('" + hasta.ToShortDateString() + "','dd/mm/yyyy')" +
                 " and " + FuncionariosComisionesService.Monto_NombreCol + " < 0";
            DataTable dt = GetFuncionarioComisionDataTable(clausulas, string.Empty);
            decimal totalComision = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row[FuncionariosComisionesService.FuncionarioDescuentoId_NombreCol] == DBNull.Value)
                {
                    decimal cotizacionComision = (decimal)row[FuncionariosComisionesService.Cotizacion_NombreCol];
                    decimal montoComision = (decimal)row[FuncionariosComisionesService.Monto_NombreCol];
                    totalComision += (cotizacion * montoComision * (-1)) / cotizacionComision;
                }
            }
            if (totalComision > 0)
            {
                FuncionariosDescuentosService funcionarioDescuentos = new FuncionariosDescuentosService();
                System.Collections.Hashtable campos = new System.Collections.Hashtable();

                campos.Add(FuncionariosDescuentosService.FuncionarioId_NombreCol, funcionario_id);
                campos.Add(FuncionariosDescuentosService.MonedaId_NombreCol, moneda_id);
                campos.Add(FuncionariosDescuentosService.UtilizarPorcentaje_NombreCol, Definiciones.SiNo.No);
                campos.Add(FuncionariosDescuentosService.Monto_NombreCol, totalComision);
                campos.Add(FuncionariosDescuentosService.Estado_NombreCol, Definiciones.Estado.Activo);
                campos.Add(FuncionariosDescuentosService.DescuentoId_NombreCol, Definiciones.TipoDescuento.Comision);
                campos.Add(FuncionariosDescuentosService.Observacion_NombreCol, string.Empty);

                //Guardar los datos
                decimal funcionarioDescuentoId = funcionarioDescuentos.Guardar(campos, true, sesion);

                foreach (DataRow row in dt.Rows)
                {
                    decimal funcionarioComisionId = (decimal)row[FuncionariosComisionesService.Id_NombreCol];
                    FUNCIONARIOS_COMISIONESRow funcionarioComisionRow = sesion.Db.FUNCIONARIOS_COMISIONESCollection.GetByPrimaryKey(funcionarioComisionId);
                    funcionarioComisionRow.FUNCIONARIO_DESCUENTO_ID = funcionarioDescuentoId;
                    sesion.Db.FUNCIONARIOS_COMISIONESCollection.Update(funcionarioComisionRow);
                }
            }
        }
        #endregion GenerarDescuento

        #region Guardar
        /// <summary>
        /// Guardars the specified campos.
        /// </summary>
        /// <param name="campos">The campos.</param>
        /// <param name="insertarNuevo">if set to <c>true</c> [insertar nuevo].</param>
        /// <returns></returns>
        public decimal Guardar(System.Collections.Hashtable campos, bool insertarNuevo, SessionService sesion)
        {
            FUNCIONARIOS_COMISIONESRow row = new FUNCIONARIOS_COMISIONESRow();
            string valorAnterior = "";

            if (insertarNuevo)
            {
                valorAnterior = Definiciones.Log.RegistroNuevo;
                row.ID = sesion.Db.GetSiguienteSecuencia("funcionarios_comisiones_sqc");
            }
            else
            {
                row = sesion.Db.FUNCIONARIOS_COMISIONESCollection.GetByPrimaryKey((decimal)campos[FuncionariosComisionesService.Id_NombreCol]);
                valorAnterior = row.ToString();
            }

            if (campos.Contains(CasoId_NombreCol))
                row.CASO_ID = (decimal)campos[CasoId_NombreCol];
            else
                row.IsCASO_IDNull = true;

            row.COBRADO = (string)campos[Cobrado_NombreCol];
            row.COTIZACION = (decimal)campos[Cotizacion_NombreCol];
            row.FECHA = (DateTime)campos[Fecha_NombreCol];
            row.FUNCIONARIO_ID = (decimal)campos[FuncionarioId_NombreCol];
            row.MONEDA_ID = (decimal)campos[MonedaId_NombreCol];
            row.MONTO = (decimal)campos[Monto_NombreCol];
            row.TIPO_COMISION = (string)campos[TipoComision_NombreCol];

            if (campos.Contains(FuncionariosComisionesService.CtactePagoPersonaDocId_NombreCol))
                row.CTACTE_PAGO_PERSONA_DOC_ID = (decimal)campos[FuncionariosComisionesService.CtactePagoPersonaDocId_NombreCol];
            else
                row.IsCTACTE_PAGO_PERSONA_DOC_IDNull = true;

            if (campos.Contains(FuncionarioBonificacionId_NombreCol))
                row.FUNCIONARIO_BONIFICACION_ID = (decimal)campos[FuncionarioBonificacionId_NombreCol];
            else
                row.IsFUNCIONARIO_BONIFICACION_IDNull = true;

            if (campos.Contains(FuncionarioDescuentoId_NombreCol))
                row.FUNCIONARIO_DESCUENTO_ID = (decimal)campos[FuncionarioDescuentoId_NombreCol];
            else
                row.IsFUNCIONARIO_DESCUENTO_IDNull = true;

            if (campos.Contains(Anho_NombreCol))
                row.ANHO = (decimal)campos[Anho_NombreCol];
            else
                row.IsANHONull = true;

            if (campos.Contains(TemporadaId_NombreCol))
                row.TEMPORADA_ID = (decimal)campos[TemporadaId_NombreCol];
            else
                row.IsTEMPORADA_IDNull = true;

            if (campos.Contains(PersonaId_NombreCol))
                row.PERSONA_ID = (decimal)campos[PersonaId_NombreCol];
            else
                row.IsPERSONA_IDNull = true;

            row.TIPO_FUNCIONARIO = (string)campos[TipoFuncionario_NombreCol];

            if (insertarNuevo) sesion.Db.FUNCIONARIOS_COMISIONESCollection.Insert(row);
            else sesion.Db.FUNCIONARIOS_COMISIONESCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }
        #endregion Guardar

        #region Cambiar Monto o Funcionario
        public decimal ModificarMontoFuncionario(SessionService sesion,decimal idFuncionarioRegistro, decimal idFuncionario, decimal monto )
        {
            FUNCIONARIOS_COMISIONESRow row = new FUNCIONARIOS_COMISIONESRow();
            string valorAnterior = "";

            row = sesion.Db.FUNCIONARIOS_COMISIONESCollection.GetByPrimaryKey(idFuncionarioRegistro);
            valorAnterior = row.ToString();

            if(!idFuncionario.Equals(Definiciones.Error.Valor.EnteroPositivo))
                row.FUNCIONARIO_ID = idFuncionario;

            if(!monto.Equals(Definiciones.Error.Valor.EnteroPositivo))
              row.MONTO = monto;
                       
            sesion.Db.FUNCIONARIOS_COMISIONESCollection.Update(row);
            LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);

            return row.ID;
        }

        #endregion Cambiar Monto o Funcionario
        
        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FUNCIONARIOS_COMISIONES"; }
        }
        public static string Id_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.IDColumnName; }
        }
        public static string CasoId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.CASO_IDColumnName; }
        }
        public static string Cobrado_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.COBRADOColumnName; }
        }
        public static string Cotizacion_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.COTIZACIONColumnName; }
        }
        public static string CtactePagoPersonaDocId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.CTACTE_PAGO_PERSONA_DOC_IDColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.FECHAColumnName; }
        }
        public static string FuncionarioBonificacionId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.FUNCIONARIO_BONIFICACION_IDColumnName; }
        }
        public static string FuncionarioDescuentoId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.FUNCIONARIO_DESCUENTO_IDColumnName; }
        }
        public static string FuncionarioId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.FUNCIONARIO_IDColumnName; }
        }
        public static string MonedaId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.MONEDA_IDColumnName; }
        }
        public static string Monto_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.MONTOColumnName; }
        }
        public static string TipoComision_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.TIPO_COMISIONColumnName; }
        }
        public static string Anho_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.ANHOColumnName; }
        }
        public static string TemporadaId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.TEMPORADA_IDColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.PERSONA_IDColumnName; }
        }
        public static string TipoFuncionario_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONESCollection.TIPO_FUNCIONARIOColumnName; }
        }

        public static string VistaFuncionarioNombre_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONES_INFO_CCollection.FUNCIONARIO_NOMBREColumnName; }
        }
        public static string VistaFuncionarioCodigo_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONES_INFO_CCollection.FUNCIONARIO_CODIGOColumnName; }
        }
        public static string VistaEsVendedor_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONES_INFO_CCollection.ES_VENDEDORColumnName; }
        }
        public static string VistaEsPromotor_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONES_INFO_CCollection.ES_PROMOTORColumnName; }
        }
        public static string VistaEsCobrador_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONES_INFO_CCollection.ES_COBRADORColumnName; }
        }
        public static string VistaMonedaNombre_NombreCol
        {
            get { return FUNCIONARIOS_COMISIONES_INFO_CCollection.MONEDA_NOMBREColumnName; }
        }
        #endregion Accessors

    }
}
