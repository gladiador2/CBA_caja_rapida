using System;
using System.Data;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Base;
using CBA.FlowV2.Services.Facturacion;

namespace CBA.FlowV2.Services.Herramientas
{
    public class FCProveedorPagosTercPersonasService
    {

        #region GetFCProveedorPagosTercPersonas
        public static DataTable GetFCProveedorPagosTercPersonas(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                return GetFCProveedorPagosTercPersonas(clausulas, orden, sesion);
            }
        }

        public static DataTable GetFCProveedorPagosTercPersonas(string clausulas, string orden, SessionService sesion)
        {
            return sesion.Db.FC_PROV_PAGO_TERC_PERSONASCollection.GetAsDataTable(clausulas, orden);
        }
        #endregion GetFCProveedorPagosTercPersonas

        #region GetFCProveedorPagosTercPersInfoCom
        public static DataTable GetFCProveedorPagosTercPersInfoCom(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable table = sesion.Db.FC_PROV_PAGO_TERC_PERS_INFO_CCollection.GetAsDataTable(clausulas, orden);
                return table;
            }
        }
        #endregion GetFCProveedorPagosTercPersInfoCom
       
        #region Borrar
        public static void Borrar(decimal detalleId)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    FC_PROV_PAGO_TERC_PERSONASRow row = sesion.Db.FC_PROV_PAGO_TERC_PERSONASCollection.GetByPrimaryKey(detalleId);

                    DataTable dtFacturaProveedor = FacturasProveedorService.GetFacturaProveedorInfoCompleta(FacturasProveedorService.Id_NombreCol + " = " + row.FC_PROVEEDOR_ID, string.Empty, sesion);
                    var casoEstadoId = (string)dtFacturaProveedor.Rows[0][FacturasProveedorService.VistaCasoEstadoId_NombreCol];
                    if (casoEstadoId == Definiciones.EstadosFlujos.Aprobado || casoEstadoId == Definiciones.EstadosFlujos.Cerrado || casoEstadoId == Definiciones.EstadosFlujos.Anulado)
                        throw new Exception("El caso no está en un estado modificable.");

                    sesion.Db.FC_PROV_PAGO_TERC_PERSONASCollection.Delete(row);
                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Borrar

        #region Guardar
        public static void Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();

                    DataTable dtFacturaProveedor = FacturasProveedorService.GetFacturaProveedorInfoCompleta(FacturasProveedorService.Id_NombreCol + " = " + campos[FCProveedorId_NombreCol], string.Empty, sesion);
                    var casoEstadoId = (string)dtFacturaProveedor.Rows[0][FacturasProveedorService.VistaCasoEstadoId_NombreCol];
                    if (casoEstadoId == Definiciones.EstadosFlujos.Aprobado || casoEstadoId == Definiciones.EstadosFlujos.Cerrado || casoEstadoId == Definiciones.EstadosFlujos.Anulado)
                        throw new Exception("El caso no está en un estado modificable.");

                    FC_PROV_PAGO_TERC_PERSONASRow fcProvPagoTerPers = new FC_PROV_PAGO_TERC_PERSONASRow();
                    string valorAnterior = string.Empty;

                    if (insertarNuevo)
                    {
                        CondicionesPagoService condiciones = new CondicionesPagoService();
                        decimal cantidadPagos = CondicionesPagoService.GetCantidadPagos((decimal)campos[CondicionPago_NombreCol],sesion);
                        String tipoCalculo = condiciones.GetTipoCalculo((decimal)campos[CondicionPago_NombreCol],sesion);
                        DataTable plazos = condiciones.GetPlazosVencimientos((decimal)campos[CondicionPago_NombreCol], sesion);
                        DateTime fechaBase = (DateTime)campos[FacturasProveedorService.FechaFactura_NombreCol];
                        DateTime vencimiento;

                        for (int i = 0; i < plazos.Rows.Count; i++)
                        {
                            fcProvPagoTerPers.ID = sesion.Db.GetSiguienteSecuencia("FC_PROV_PAGO_TERC_PERSONAS_SQC");
                            valorAnterior = Definiciones.Log.RegistroNuevo;

                            fcProvPagoTerPers.FC_PROVEEDOR_ID = (decimal)campos[FCProveedorId_NombreCol];
                            fcProvPagoTerPers.PERSONA_ID = (decimal)campos[PersonaId_NombreCol];
                            fcProvPagoTerPers.PORC_ASIGNADO = (decimal)campos[PorcentajeAsignado_NombreCol];
                            fcProvPagoTerPers.PORC_ASIGNADO_CUOTA = 100 / cantidadPagos;
                            fcProvPagoTerPers.PORC_COMISION = (decimal)campos[PorcentajeComision_NombreCol];
                            fcProvPagoTerPers.CONDICION_PAGO_ID = (decimal)campos[CondicionPago_NombreCol]; 
                            fcProvPagoTerPers.TOTAL_CUOTAS = cantidadPagos;
                            fcProvPagoTerPers.NRO_CUOTA = i + 1;

                            if (tipoCalculo.Equals(Definiciones.CondicionPagoTipoCalculo.Dias))
                                vencimiento = fechaBase.AddDays(double.Parse(plazos.Rows[i][CondicionesPagoService.Pagos_NombreCol].ToString()));
                            else vencimiento = fechaBase.AddMonths(int.Parse(plazos.Rows[i][CondicionesPagoService.Pagos_NombreCol].ToString()));

                            fcProvPagoTerPers.FECHA_VENCIMIENTO = vencimiento;

                            sesion.Db.FC_PROV_PAGO_TERC_PERSONASCollection.Insert(fcProvPagoTerPers);
                        }
                    }
                    else
                    {
                        fcProvPagoTerPers = sesion.Db.FC_PROV_PAGO_TERC_PERSONASCollection.GetRow(Id_NombreCol + "= " + (decimal)campos[Id_NombreCol]);
                        valorAnterior = fcProvPagoTerPers.ToString();

                        fcProvPagoTerPers.FECHA_VENCIMIENTO = (DateTime)campos[FechaVencimiento_NombreCol];
                        fcProvPagoTerPers.PORC_ASIGNADO_CUOTA = (decimal)campos[PorcentajeAsignadoCuota_NombreCol];

                        sesion.Db.FC_PROV_PAGO_TERC_PERSONASCollection.Update(fcProvPagoTerPers);
                    }   

                    LogCambiosService.LogDeRegistro(Nombre_Tabla, fcProvPagoTerPers.ID, valorAnterior, fcProvPagoTerPers.ToString(), sesion);

                    sesion.Db.CommitTransaction();
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }
        #endregion Guardar

        #region PorcentajeTotalValido
        public static bool PorcentajeTotalValido(decimal fc_proveedor_id, SessionService sesion) 
        {
            string clausulas = FCProveedorId_NombreCol + " = " + fc_proveedor_id;
            DataTable dt  = sesion.Db.FC_PROV_PAGO_TERC_PERSONASCollection.GetAsDataTable(clausulas, PersonaId_NombreCol);

            decimal personaActual = Definiciones.Error.Valor.EnteroPositivo;
            decimal total = 0;

            foreach (DataRow dr in dt.Rows) 
            { 
                if (personaActual != decimal.Parse(dr[PersonaId_NombreCol].ToString()))
                {
                    total += decimal.Parse(dr[PorcentajeAsignado_NombreCol].ToString());
                    personaActual = decimal.Parse(dr[PersonaId_NombreCol].ToString());
                }
            }

            return (total <= 100);
        }
       #endregion PorcentajeTotalValido

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "FC_PROV_PAGO_TERC_PERSONAS"; }
        }
        public static string Id_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.IDColumnName; }
        }
        public static string FCProveedorId_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.FC_PROVEEDOR_IDColumnName; }
        }
        public static string FechaVencimiento_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string NroCuota_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.NRO_CUOTAColumnName; }
        }
        public static string PersonaId_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.PERSONA_IDColumnName; }
        }
        public static string PorcentajeAsignado_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.PORC_ASIGNADOColumnName; }
        }
        public static string PorcentajeAsignadoCuota_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.PORC_ASIGNADO_CUOTAColumnName; }
        }
        public static string PorcentajeComision_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.PORC_COMISIONColumnName; }
        }
        public static string TotalCuotas_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.TOTAL_CUOTASColumnName; }
        }
        public static string VistaActivo_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.ACTIVO_CODIGOColumnName; }
        }
        public static string CondicionPago_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERSONASCollection.CONDICION_PAGO_IDColumnName; }
        }
        public static string VistaNombreCompleto_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.NOMBRE_COMPLETOColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.CASO_IDColumnName; }
        }
        public static string VistaCondicionPago_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.CONDICION_PAGO_IDColumnName; }
        }
        public static string VistaFCProveedorId_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.FC_PROVEEDOR_IDColumnName; }
        }
        public static string VistaPorcentajeAsignado_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.PORC_ASIGNADOColumnName; }
        }
        public static string VistaPorcentajeComision_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.PORC_COMISIONColumnName; }
        }
        public static string VistaId_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.IDColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.PERSONA_IDColumnName; }
        }
        public static string VistaTotalCuotas_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.TOTAL_CUOTASColumnName; }
        }
        public static string VistaFechaVencimiento_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.FECHA_VENCIMIENTOColumnName; }
        }
        public static string VistaNroCuota_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.NRO_CUOTAColumnName; }
        }
        public static string VistaPorcentajeAsignadoCuota_NombreCol
        {
            get { return FC_PROV_PAGO_TERC_PERS_INFO_CCollection.PORC_ASIGNADO_CUOTAColumnName; }
        }
        #endregion Accessors
    }
}
