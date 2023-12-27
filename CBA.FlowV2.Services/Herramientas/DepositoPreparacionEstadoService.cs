using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CBA.FlowV2.Db;
using CBA.FlowV2.Services.Sesion;
using CBA.FlowV2.Services.Base;
using System.Data;

namespace CBA.FlowV2.Services.Herramientas
{
    public class DepositoPreparacionEstadoService
    {
        #region Obtener siguiente secuencia
        /// <summary>
        /// Obteners the siguiente secuencia.
        /// </summary>
        /// <param name="sesion">The sesion.</param>
        /// <returns></returns>
        public decimal ObtenerSiguienteSecuencia(SessionService sesion)
        {
            DataTable seq = new DataTable();
            seq = sesion.Db.EjecutarQuery("select deposito_preparacion_estad_sqc.nextval from dual");
            return seq.Rows[0].Field<Decimal>(0);
        }
        #endregion obtener siguiente secuencia

        #region GetDepositoPreparacionEstadoDataTable
        public DataTable GetDepositoPreparacionEstadoDataTable(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = sesion.Db.DEPOSITO_PREPARACION_ESTADOCollection.GetAsDataTable(clausulas, string.Empty);
                return dt;
            }
        }
        #endregion GetDepositoPreparacionEstadoDataTable

        #region GetDepositoPreparacionEstadoActual
        public DataTable GetDepositoPreparacionEstadoActual(string clausulas)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = sesion.Db.DEPOSITO_PREP_ESTADO_ACTUALCollection.GetAsDataTable(clausulas, string.Empty);
                return dt;
            }
        }
        #endregion GetDepositoPreparacionEstadoActual

        #region GetDepositoPreparacionEstadoInfoCompleta
        public DataTable GetDepositoPreparacionEstadoInfoCompleta(string clausulas, string orden)
        {
            using (SessionService sesion = new SessionService())
            {
                DataTable dt = sesion.Db.DEPOSITO_PREP_ESTADO_INFO_COMPCollection.GetAsDataTable(clausulas, orden);
                return dt;
            }
        }
        #endregion GetDepositoPreparacionEstadoInfoCompleta

        #region Guardar

        public bool Guardar(System.Collections.Hashtable campos, bool insertarNuevo)
        {
            bool exito = false;
            using (SessionService sesion = new SessionService())
            {
                try
                {
                    sesion.Db.BeginTransaction();
                    exito = Guardar(sesion, campos, insertarNuevo);
                    sesion.Db.CommitTransaction();
                    return exito;
                }
                catch (Exception exp)
                {
                    sesion.Db.RollbackTransaction();
                    throw exp;
                }
            }
        }

        public bool Guardar(SessionService sesion, System.Collections.Hashtable campos, bool insertarNuevo)
        {
            bool exito = false;
            DEPOSITO_PREPARACION_ESTADORow row = new DEPOSITO_PREPARACION_ESTADORow();

            try
            {
                string valorAnterior = string.Empty;

                if (insertarNuevo)
                {
                    valorAnterior = Definiciones.Log.RegistroNuevo;
                    row.ID = ObtenerSiguienteSecuencia(sesion);
                    row.ESTADO = Definiciones.Estado.Activo;
                }
                else
                {
                    row = sesion.Db.DEPOSITO_PREPARACION_ESTADOCollection.GetByPrimaryKey(decimal.Parse(campos[Id_NombreCol].ToString()));
                    valorAnterior = row.ToString();
                }

                if (campos.Contains(DepositoEstado_NombreCol))
                    row.DEPOSITO_ESTADO = (string)campos[DepositoEstado_NombreCol];
                if (campos.Contains(Fecha_NombreCol))
                    row.FECHA = (DateTime)campos[Fecha_NombreCol];
                if (campos.Contains(PedidoClienteId_NombreCol))
                    row.PEDIDO_CLIENTE_ID = (decimal)campos[PedidoClienteId_NombreCol];
                
                if (campos.Contains(FuncionarioPreparacionId_NombreCol))
                    row.FUNCIONARIO_PREPARACION_ID = (decimal)campos[FuncionarioPreparacionId_NombreCol];                

                if (campos.Contains(ArticuloId_NombreCol))                
                    row.ARTICULO_ID = (decimal)campos[ArticuloId_NombreCol];

                if (campos.Contains(PuedeProcesar_NombreCol))
                    row.PUEDE_PROCESAR = (string)campos[PuedeProcesar_NombreCol];
                else
                    row.PUEDE_PROCESAR = Definiciones.SiNo.No;

                if (campos.Contains(Cantidad_NombreCol))
                    row.CANTIDAD = (decimal)campos[Cantidad_NombreCol];
                else
                    row.CANTIDAD = 0;

                if (campos.Contains(Estado_NombreCol))
                    row.ESTADO = (string)campos[Estado_NombreCol];

                if (sesion.Usuario_Funcionario_id != Definiciones.Error.Valor.EnteroPositivo)
                    row.USUARIO_ID = sesion.Usuario_Id;
                else
                    row.IsUSUARIO_IDNull = true;             

                if (insertarNuevo) sesion.Db.DEPOSITO_PREPARACION_ESTADOCollection.Insert(row);
                else sesion.Db.DEPOSITO_PREPARACION_ESTADOCollection.Update(row);
                LogCambiosService.LogDeRegistro(Nombre_Tabla, row.ID, valorAnterior, row.ToString(), sesion);
                exito = true;
            }
            catch (Exception exp)
            {
                exito = false;
                throw exp;
            }
            return exito;
        }
        #endregion guardar

        #region Accessors
        public static string Nombre_Tabla
        {
            get { return "DEPOSITO_PREPARACION_ESTADO"; }
        }
        public static string Id_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.IDColumnName; }
        }
        public static string ArticuloId_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.ARTICULO_IDColumnName; }
        }
        public static string Cantidad_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.CANTIDADColumnName; }
        }
        public static string DepositoEstado_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.DEPOSITO_ESTADOColumnName; }
        }
        public static string Estado_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.ESTADOColumnName; }
        }
        public static string Fecha_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.FECHAColumnName; }
        }
        public static string UsuarioId_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.USUARIO_IDColumnName; }
        }
        public static string FuncionarioPreparacionId_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.FUNCIONARIO_PREPARACION_IDColumnName; }
        }
        public static string PedidoClienteId_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.PEDIDO_CLIENTE_IDColumnName; }
        }
        public static string PuedeProcesar_NombreCol
        {
            get { return DEPOSITO_PREPARACION_ESTADOCollection.PUEDE_PROCESARColumnName; }
        }
        public static string VistaCasoId_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.CASO_IDColumnName; }
        }
        public static string VistaCantidadTotalPedida_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.CANTIDAD_TOTAL_PEDIDAColumnName; }
        }
        public static string VistaPersonaId_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.PERSONA_IDColumnName; }
        }
        public static string VistaCliente_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.CLIENTEColumnName; }
        }
        public static string VistaClienteId_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.CLIENTE_IDColumnName; }
        }
        public static string VistaUsuario_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.USUARIO_IDColumnName; }
        }       
        public static string VistaFuncionarioPreparacion_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.FUNCIONARIO_PREPARACIONColumnName; }
        }       
        public static string VistaSucursalId_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.SUCURSAL_IDColumnName; }
        }
        public static string VistaSucursalNombre_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.SUCURSAL_NOMBREColumnName; }
        }
        public static string VistaNumeroPedido_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.NRO_COMPROBANTEColumnName; }
        }      
        public static string VistaArticuloNombre_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.ARTICULO_NOMBREColumnName; }
        }
        public static string VistaArticuloCodigo_NombreCol
        {
            get { return DEPOSITO_PREP_ESTADO_ACTUALCollection.ARTICULO_CODIGOColumnName; }
        }
        #endregion Accessors
    }
}
