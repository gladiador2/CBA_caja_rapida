// <fileinfo name="CTB_ASIENTOS_AUTO_REL_INFO_CCollection_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;
using System.Data;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTO_REL_INFO_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_ASIENTO_AUTO_DET_IDColumnName = "CTB_ASIENTO_AUTO_DET_ID";
		public const string CTB_ASIENTO_AUTO_DET_NOMBREColumnName = "CTB_ASIENTO_AUTO_DET_NOMBRE";
		public const string CTB_ASIENTO_AUTO_DET_DESCColumnName = "CTB_ASIENTO_AUTO_DET_DESC";
		public const string CTB_ASIENTO_AUTOMATICO_IDColumnName = "CTB_ASIENTO_AUTOMATICO_ID";
		public const string CTB_PLAN_CUENTA_IDColumnName = "CTB_PLAN_CUENTA_ID";
		public const string CTB_PLAN_CUENTA_NOMBREColumnName = "CTB_PLAN_CUENTA_NOMBRE";
		public const string CTB_PLAN_CUENTA_ESTADOColumnName = "CTB_PLAN_CUENTA_ESTADO";
		public const string INVERTIR_DEBE_Y_HABERColumnName = "INVERTIR_DEBE_Y_HABER";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string REGION_NOMBREColumnName = "REGION_NOMBRE";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string CTB_CUENTA_IDColumnName = "CTB_CUENTA_ID";
		public const string CTB_CUENTA_CODIGOColumnName = "CTB_CUENTA_CODIGO";
		public const string CTB_CUENTA_NOMBREColumnName = "CTB_CUENTA_NOMBRE";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string CTACTE_BANCARIA_NUMEROColumnName = "CTACTE_BANCARIA_NUMERO";
		public const string CTACTE_BANCARIA_BANCO_IDColumnName = "CTACTE_BANCARIA_BANCO_ID";
		public const string CTACTE_BANCARIA_BANCO_NOMBREColumnName = "CTACTE_BANCARIA_BANCO_NOMBRE";
		public const string STOCK_DEPOSITO_IDColumnName = "STOCK_DEPOSITO_ID";
		public const string STOCK_DEPOSITO_NOMBREColumnName = "STOCK_DEPOSITO_NOMBRE";
		public const string STOCK_DEPOSITO_SUCURSAL_IDColumnName = "STOCK_DEPOSITO_SUCURSAL_ID";
		public const string STOCK_DEPOSITO_SUCURSAL_NOMBREColumnName = "STOCK_DEPOSITO_SUCURSAL_NOMBRE";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_VALOR_NOMBREColumnName = "CTACTE_VALOR_NOMBRE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PROVEEDOR_NOMBREColumnName = "PROVEEDOR_NOMBRE";
		public const string PROVEEDOR_RELACIONADO_IDColumnName = "PROVEEDOR_RELACIONADO_ID";
		public const string PROVEEDOR_REL_RAZON_SOCIALColumnName = "PROVEEDOR_REL_RAZON_SOCIAL";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string TIPO_CLIENTE_IDColumnName = "TIPO_CLIENTE_ID";
		public const string TIPO_CLIENTE_NOMBREColumnName = "TIPO_CLIENTE_NOMBRE";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string PERSONA_RELACIONADA_NOMBREColumnName = "PERSONA_RELACIONADA_NOMBRE";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_NOMBREColumnName = "FUNCIONARIO_NOMBRE";
		public const string ARTICULO_FAMILIA_IDColumnName = "ARTICULO_FAMILIA_ID";
		public const string ARTICULO_FAMILIA_NOMBREColumnName = "ARTICULO_FAMILIA_NOMBRE";
		public const string ARTICULO_GRUPO_IDColumnName = "ARTICULO_GRUPO_ID";
		public const string ARTICULO_GRUPO_NOMBREColumnName = "ARTICULO_GRUPO_NOMBRE";
		public const string ARTICULO_SUBGRUPO_IDColumnName = "ARTICULO_SUBGRUPO_ID";
		public const string ARTICULO_SUBGRUPO_NOMBREColumnName = "ARTICULO_SUBGRUPO_NOMBRE";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_NOMBREColumnName = "ARTICULO_NOMBRE";
		public const string ARTICULO_USADOColumnName = "ARTICULO_USADO";
		public const string ARTICULO_DANHADOColumnName = "ARTICULO_DANHADO";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string RUBRO_NOMBREColumnName = "RUBRO_NOMBRE";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TEXTO_PREDEFINIDO_TEXTOColumnName = "TEXTO_PREDEFINIDO_TEXTO";
		public const string CTACTE_CAJA_TESO_IDColumnName = "CTACTE_CAJA_TESO_ID";
		public const string CTACTE_CAJA_TESO_NOMBREColumnName = "CTACTE_CAJA_TESO_NOMBRE";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string CTACTE_FONDO_FIJO_NOMBREColumnName = "CTACTE_FONDO_FIJO_NOMBRE";
		public const string CTACTE_CHEQUE_ESTADO_IDColumnName = "CTACTE_CHEQUE_ESTADO_ID";
		public const string CTACTE_CHEQUE_ESTADO_NOMBREColumnName = "CTACTE_CHEQUE_ESTADO_NOMBRE";
		public const string TIPO_NOTAS_CREDITO_IDColumnName = "TIPO_NOTAS_CREDITO_ID";
		public const string TIPO_ORDEN_PAGO_IDColumnName = "TIPO_ORDEN_PAGO_ID";
		public const string TIPO_ORDEN_PAGO_DESCRIPCIONColumnName = "TIPO_ORDEN_PAGO_DESCRIPCION";
		public const string TIPO_NOTAS_CREDITO_DESCRIPCIONColumnName = "TIPO_NOTAS_CREDITO_DESCRIPCION";
		public const string INVERTIR_SI_ES_NEGATIVOColumnName = "INVERTIR_SI_ES_NEGATIVO";
		public const string DESCUENTO_IDColumnName = "DESCUENTO_ID";
		public const string DESCUENTO_NOMBREColumnName = "DESCUENTO_NOMBRE";
		public const string BONIFICACION_IDColumnName = "BONIFICACION_ID";
		public const string BONIFICACION_NOMBREColumnName = "BONIFICACION_NOMBRE";
		public const string EXCLUSIONESColumnName = "EXCLUSIONES";
		public const string INCLUSIONESColumnName = "INCLUSIONES";
		public const string CREAR_ASIENTOColumnName = "CREAR_ASIENTO";
		public const string PERSONA_RELACIONADA_IDColumnName = "PERSONA_RELACIONADA_ID";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string CANAL_VENTA_NOMBREColumnName = "CANAL_VENTA_NOMBRE";
		public const string ACTIVO_RUBRO_IDColumnName = "ACTIVO_RUBRO_ID";
		public const string ACTIVO_RUBRO_NOMBREColumnName = "ACTIVO_RUBRO_NOMBRE";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string IMPUESTO_NOMBREColumnName = "IMPUESTO_NOMBRE";
		public const string CTACTE_PROCESADORA_TARJETA_IDColumnName = "CTACTE_PROCESADORA_TARJETA_ID";
		public const string CTACTE_PROC_TARJETA_NOMBREColumnName = "CTACTE_PROC_TARJETA_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_AUTO_REL_INFO_CCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this view belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>CTB_ASIENTOS_AUTO_REL_INFO_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_REL_INFO_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_AUTO_REL_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_AUTO_REL_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_AUTO_REL_INFO_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_AUTO_REL_INFO_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_REL_INFO_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example:
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <param name="startIndex">The index of the first record to return.</param>
		/// <param name="length">The number of records to return.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_REL_INFO_CRow[] GetAsArray(string whereSql, string orderBySql,
							int startIndex, int length, ref int totalRecordCount)
		{
			using(IDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
			{
				return MapRecords(reader, startIndex, length, ref totalRecordCount);
			}
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object filled with data that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetAsDataTable(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsDataTable(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object filled with data that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <param name="startIndex">The index of the first record to return.</param>
		/// <param name="length">The number of records to return.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAsDataTable(string whereSql, string orderBySql,
							int startIndex, int length, ref int totalRecordCount)
		{
			using(IDataReader reader = _db.ExecuteReader(CreateGetCommand(whereSql, orderBySql)))
			{
				return MapRecordsToDataTable(reader, startIndex, length, ref totalRecordCount);
			}
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object for the specified search criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: "FirstName='Smith' AND Zip=75038".</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: "LastName ASC, FirstName ASC".</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetCommand(string whereSql, string orderBySql)
		{
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_AUTO_REL_INFO_C";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_REL_INFO_CRow[] MapRecords(IDbCommand command)
		{
			using(IDataReader reader = _db.ExecuteReader(command))
			{
				return MapRecords(reader);
			}
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_REL_INFO_CRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_AUTO_REL_INFO_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_asiento_auto_det_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_AUTO_DET_ID");
			int ctb_asiento_auto_det_nombreColumnIndex = reader.GetOrdinal("CTB_ASIENTO_AUTO_DET_NOMBRE");
			int ctb_asiento_auto_det_descColumnIndex = reader.GetOrdinal("CTB_ASIENTO_AUTO_DET_DESC");
			int ctb_asiento_automatico_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_AUTOMATICO_ID");
			int ctb_plan_cuenta_idColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_ID");
			int ctb_plan_cuenta_nombreColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_NOMBRE");
			int ctb_plan_cuenta_estadoColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_ESTADO");
			int invertir_debe_y_haberColumnIndex = reader.GetOrdinal("INVERTIR_DEBE_Y_HABER");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int region_nombreColumnIndex = reader.GetOrdinal("REGION_NOMBRE");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int ctb_cuenta_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_ID");
			int ctb_cuenta_codigoColumnIndex = reader.GetOrdinal("CTB_CUENTA_CODIGO");
			int ctb_cuenta_nombreColumnIndex = reader.GetOrdinal("CTB_CUENTA_NOMBRE");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int ctacte_bancaria_numeroColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_NUMERO");
			int ctacte_bancaria_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_BANCO_ID");
			int ctacte_bancaria_banco_nombreColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_BANCO_NOMBRE");
			int stock_deposito_idColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_ID");
			int stock_deposito_nombreColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_NOMBRE");
			int stock_deposito_sucursal_idColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_SUCURSAL_ID");
			int stock_deposito_sucursal_nombreColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_SUCURSAL_NOMBRE");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_valor_nombreColumnIndex = reader.GetOrdinal("CTACTE_VALOR_NOMBRE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int proveedor_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_NOMBRE");
			int proveedor_relacionado_idColumnIndex = reader.GetOrdinal("PROVEEDOR_RELACIONADO_ID");
			int proveedor_rel_razon_socialColumnIndex = reader.GetOrdinal("PROVEEDOR_REL_RAZON_SOCIAL");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int tipo_cliente_idColumnIndex = reader.GetOrdinal("TIPO_CLIENTE_ID");
			int tipo_cliente_nombreColumnIndex = reader.GetOrdinal("TIPO_CLIENTE_NOMBRE");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int persona_relacionada_nombreColumnIndex = reader.GetOrdinal("PERSONA_RELACIONADA_NOMBRE");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE");
			int articulo_familia_idColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_ID");
			int articulo_familia_nombreColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_NOMBRE");
			int articulo_grupo_idColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_ID");
			int articulo_grupo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_NOMBRE");
			int articulo_subgrupo_idColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_ID");
			int articulo_subgrupo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_NOMBRE");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_NOMBRE");
			int articulo_usadoColumnIndex = reader.GetOrdinal("ARTICULO_USADO");
			int articulo_danhadoColumnIndex = reader.GetOrdinal("ARTICULO_DANHADO");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int rubro_nombreColumnIndex = reader.GetOrdinal("RUBRO_NOMBRE");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int texto_predefinido_textoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_TEXTO");
			int ctacte_caja_teso_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_ID");
			int ctacte_caja_teso_nombreColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_NOMBRE");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int ctacte_fondo_fijo_nombreColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_NOMBRE");
			int ctacte_cheque_estado_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_ESTADO_ID");
			int ctacte_cheque_estado_nombreColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_ESTADO_NOMBRE");
			int tipo_notas_credito_idColumnIndex = reader.GetOrdinal("TIPO_NOTAS_CREDITO_ID");
			int tipo_orden_pago_idColumnIndex = reader.GetOrdinal("TIPO_ORDEN_PAGO_ID");
			int tipo_orden_pago_descripcionColumnIndex = reader.GetOrdinal("TIPO_ORDEN_PAGO_DESCRIPCION");
			int tipo_notas_credito_descripcionColumnIndex = reader.GetOrdinal("TIPO_NOTAS_CREDITO_DESCRIPCION");
			int invertir_si_es_negativoColumnIndex = reader.GetOrdinal("INVERTIR_SI_ES_NEGATIVO");
			int descuento_idColumnIndex = reader.GetOrdinal("DESCUENTO_ID");
			int descuento_nombreColumnIndex = reader.GetOrdinal("DESCUENTO_NOMBRE");
			int bonificacion_idColumnIndex = reader.GetOrdinal("BONIFICACION_ID");
			int bonificacion_nombreColumnIndex = reader.GetOrdinal("BONIFICACION_NOMBRE");
			int exclusionesColumnIndex = reader.GetOrdinal("EXCLUSIONES");
			int inclusionesColumnIndex = reader.GetOrdinal("INCLUSIONES");
			int crear_asientoColumnIndex = reader.GetOrdinal("CREAR_ASIENTO");
			int persona_relacionada_idColumnIndex = reader.GetOrdinal("PERSONA_RELACIONADA_ID");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int canal_venta_nombreColumnIndex = reader.GetOrdinal("CANAL_VENTA_NOMBRE");
			int activo_rubro_idColumnIndex = reader.GetOrdinal("ACTIVO_RUBRO_ID");
			int activo_rubro_nombreColumnIndex = reader.GetOrdinal("ACTIVO_RUBRO_NOMBRE");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int impuesto_nombreColumnIndex = reader.GetOrdinal("IMPUESTO_NOMBRE");
			int ctacte_procesadora_tarjeta_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_TARJETA_ID");
			int ctacte_proc_tarjeta_nombreColumnIndex = reader.GetOrdinal("CTACTE_PROC_TARJETA_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_AUTO_REL_INFO_CRow record = new CTB_ASIENTOS_AUTO_REL_INFO_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_ASIENTO_AUTO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_auto_det_idColumnIndex)), 9);
					record.CTB_ASIENTO_AUTO_DET_NOMBRE = Convert.ToString(reader.GetValue(ctb_asiento_auto_det_nombreColumnIndex));
					record.CTB_ASIENTO_AUTO_DET_DESC = Convert.ToString(reader.GetValue(ctb_asiento_auto_det_descColumnIndex));
					record.CTB_ASIENTO_AUTOMATICO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_automatico_idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_plan_cuenta_idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_NOMBRE = Convert.ToString(reader.GetValue(ctb_plan_cuenta_nombreColumnIndex));
					record.CTB_PLAN_CUENTA_ESTADO = Convert.ToString(reader.GetValue(ctb_plan_cuenta_estadoColumnIndex));
					record.INVERTIR_DEBE_Y_HABER = Convert.ToString(reader.GetValue(invertir_debe_y_haberColumnIndex));
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					if(!reader.IsDBNull(region_nombreColumnIndex))
						record.REGION_NOMBRE = Convert.ToString(reader.GetValue(region_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(ctb_cuenta_idColumnIndex))
						record.CTB_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_cuenta_codigoColumnIndex))
						record.CTB_CUENTA_CODIGO = Convert.ToString(reader.GetValue(ctb_cuenta_codigoColumnIndex));
					if(!reader.IsDBNull(ctb_cuenta_nombreColumnIndex))
						record.CTB_CUENTA_NOMBRE = Convert.ToString(reader.GetValue(ctb_cuenta_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_bancaria_idColumnIndex))
						record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_bancaria_numeroColumnIndex))
						record.CTACTE_BANCARIA_NUMERO = Convert.ToString(reader.GetValue(ctacte_bancaria_numeroColumnIndex));
					if(!reader.IsDBNull(ctacte_bancaria_banco_idColumnIndex))
						record.CTACTE_BANCARIA_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_bancaria_banco_nombreColumnIndex))
						record.CTACTE_BANCARIA_BANCO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_bancaria_banco_nombreColumnIndex));
					if(!reader.IsDBNull(stock_deposito_idColumnIndex))
						record.STOCK_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(stock_deposito_nombreColumnIndex))
						record.STOCK_DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(stock_deposito_nombreColumnIndex));
					if(!reader.IsDBNull(stock_deposito_sucursal_idColumnIndex))
						record.STOCK_DEPOSITO_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_deposito_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(stock_deposito_sucursal_nombreColumnIndex))
						record.STOCK_DEPOSITO_SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(stock_deposito_sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_valor_idColumnIndex))
						record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_valor_nombreColumnIndex))
						record.CTACTE_VALOR_NOMBRE = Convert.ToString(reader.GetValue(ctacte_valor_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_nombreColumnIndex))
						record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_nombreColumnIndex))
						record.PROVEEDOR_NOMBRE = Convert.ToString(reader.GetValue(proveedor_nombreColumnIndex));
					if(!reader.IsDBNull(proveedor_relacionado_idColumnIndex))
						record.PROVEEDOR_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_rel_razon_socialColumnIndex))
						record.PROVEEDOR_REL_RAZON_SOCIAL = Convert.ToString(reader.GetValue(proveedor_rel_razon_socialColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_cliente_idColumnIndex))
						record.TIPO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_cliente_nombreColumnIndex))
						record.TIPO_CLIENTE_NOMBRE = Convert.ToString(reader.GetValue(tipo_cliente_nombreColumnIndex));
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(persona_relacionada_nombreColumnIndex))
						record.PERSONA_RELACIONADA_NOMBRE = Convert.ToString(reader.GetValue(persona_relacionada_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_nombreColumnIndex))
						record.FUNCIONARIO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_familia_idColumnIndex))
						record.ARTICULO_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_familia_nombreColumnIndex))
						record.ARTICULO_FAMILIA_NOMBRE = Convert.ToString(reader.GetValue(articulo_familia_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_grupo_idColumnIndex))
						record.ARTICULO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupo_nombreColumnIndex))
						record.ARTICULO_GRUPO_NOMBRE = Convert.ToString(reader.GetValue(articulo_grupo_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_subgrupo_idColumnIndex))
						record.ARTICULO_SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupo_nombreColumnIndex))
						record.ARTICULO_SUBGRUPO_NOMBRE = Convert.ToString(reader.GetValue(articulo_subgrupo_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_nombreColumnIndex))
						record.ARTICULO_NOMBRE = Convert.ToString(reader.GetValue(articulo_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_usadoColumnIndex))
						record.ARTICULO_USADO = Convert.ToString(reader.GetValue(articulo_usadoColumnIndex));
					if(!reader.IsDBNull(articulo_danhadoColumnIndex))
						record.ARTICULO_DANHADO = Convert.ToString(reader.GetValue(articulo_danhadoColumnIndex));
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_nombreColumnIndex))
						record.RUBRO_NOMBRE = Convert.ToString(reader.GetValue(rubro_nombreColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_textoColumnIndex))
						record.TEXTO_PREDEFINIDO_TEXTO = Convert.ToString(reader.GetValue(texto_predefinido_textoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_teso_idColumnIndex))
						record.CTACTE_CAJA_TESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_teso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_teso_nombreColumnIndex))
						record.CTACTE_CAJA_TESO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_caja_teso_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fondo_fijo_nombreColumnIndex))
						record.CTACTE_FONDO_FIJO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_fondo_fijo_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_estado_idColumnIndex))
						record.CTACTE_CHEQUE_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_estado_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_estado_nombreColumnIndex))
						record.CTACTE_CHEQUE_ESTADO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_cheque_estado_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_notas_credito_idColumnIndex))
						record.TIPO_NOTAS_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_notas_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_orden_pago_idColumnIndex))
						record.TIPO_ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_orden_pago_descripcionColumnIndex))
						record.TIPO_ORDEN_PAGO_DESCRIPCION = Convert.ToString(reader.GetValue(tipo_orden_pago_descripcionColumnIndex));
					if(!reader.IsDBNull(tipo_notas_credito_descripcionColumnIndex))
						record.TIPO_NOTAS_CREDITO_DESCRIPCION = Convert.ToString(reader.GetValue(tipo_notas_credito_descripcionColumnIndex));
					record.INVERTIR_SI_ES_NEGATIVO = Convert.ToString(reader.GetValue(invertir_si_es_negativoColumnIndex));
					if(!reader.IsDBNull(descuento_idColumnIndex))
						record.DESCUENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_nombreColumnIndex))
						record.DESCUENTO_NOMBRE = Convert.ToString(reader.GetValue(descuento_nombreColumnIndex));
					if(!reader.IsDBNull(bonificacion_idColumnIndex))
						record.BONIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(bonificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(bonificacion_nombreColumnIndex))
						record.BONIFICACION_NOMBRE = Convert.ToString(reader.GetValue(bonificacion_nombreColumnIndex));
					if(!reader.IsDBNull(exclusionesColumnIndex))
						record.EXCLUSIONES = Convert.ToString(reader.GetValue(exclusionesColumnIndex));
					if(!reader.IsDBNull(inclusionesColumnIndex))
						record.INCLUSIONES = Convert.ToString(reader.GetValue(inclusionesColumnIndex));
					record.CREAR_ASIENTO = Convert.ToString(reader.GetValue(crear_asientoColumnIndex));
					if(!reader.IsDBNull(persona_relacionada_idColumnIndex))
						record.PERSONA_RELACIONADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_relacionada_idColumnIndex)), 9);
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					if(!reader.IsDBNull(canal_venta_nombreColumnIndex))
						record.CANAL_VENTA_NOMBRE = Convert.ToString(reader.GetValue(canal_venta_nombreColumnIndex));
					if(!reader.IsDBNull(activo_rubro_idColumnIndex))
						record.ACTIVO_RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_rubro_nombreColumnIndex))
						record.ACTIVO_RUBRO_NOMBRE = Convert.ToString(reader.GetValue(activo_rubro_nombreColumnIndex));
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_nombreColumnIndex))
						record.IMPUESTO_NOMBRE = Convert.ToString(reader.GetValue(impuesto_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_procesadora_tarjeta_idColumnIndex))
						record.CTACTE_PROCESADORA_TARJETA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_tarjeta_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_proc_tarjeta_nombreColumnIndex))
						record.CTACTE_PROC_TARJETA_NOMBRE = Convert.ToString(reader.GetValue(ctacte_proc_tarjeta_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_AUTO_REL_INFO_CRow[])(recordList.ToArray(typeof(CTB_ASIENTOS_AUTO_REL_INFO_CRow)));
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected DataTable MapRecordsToDataTable(IDbCommand command)
		{
			using(IDataReader reader = _db.ExecuteReader(command))
			{
				return MapRecordsToDataTable(reader);
			}
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected DataTable MapRecordsToDataTable(IDataReader reader)
		{
			int totalRecordCount = 0;
			return MapRecordsToDataTable(reader, 0, int.MaxValue, ref totalRecordCount);
		}
		
		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// a filled <see cref="System.Data.DataTable"/> object.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <param name="startIndex">The index of the first record to read.</param>
		/// <param name="length">The number of records to read.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable MapRecordsToDataTable(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int columnCount = reader.FieldCount;
			int ri = -startIndex;
			
			DataTable dataTable = CreateDataTable();
			dataTable.BeginLoadData();
			object[] values = new object[columnCount];

			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					reader.GetValues(values);
					dataTable.LoadDataRow(values, true);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}
			dataTable.EndLoadData();

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return dataTable;
		}

		/// <summary>
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_AUTO_REL_INFO_CRow"/> object.</returns>
		protected virtual CTB_ASIENTOS_AUTO_REL_INFO_CRow MapRow(DataRow row)
		{
			CTB_ASIENTOS_AUTO_REL_INFO_CRow mappedObject = new CTB_ASIENTOS_AUTO_REL_INFO_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_ASIENTO_AUTO_DET_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_AUTO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_AUTO_DET_ID = (decimal)row[dataColumn];
			// Column "CTB_ASIENTO_AUTO_DET_NOMBRE"
			dataColumn = dataTable.Columns["CTB_ASIENTO_AUTO_DET_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_AUTO_DET_NOMBRE = (string)row[dataColumn];
			// Column "CTB_ASIENTO_AUTO_DET_DESC"
			dataColumn = dataTable.Columns["CTB_ASIENTO_AUTO_DET_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_AUTO_DET_DESC = (string)row[dataColumn];
			// Column "CTB_ASIENTO_AUTOMATICO_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_AUTOMATICO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_AUTOMATICO_ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_NOMBRE"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_NOMBRE = (string)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_ESTADO"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_ESTADO = (string)row[dataColumn];
			// Column "INVERTIR_DEBE_Y_HABER"
			dataColumn = dataTable.Columns["INVERTIR_DEBE_Y_HABER"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVERTIR_DEBE_Y_HABER = (string)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "REGION_NOMBRE"
			dataColumn = dataTable.Columns["REGION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "CTB_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_CODIGO"
			dataColumn = dataTable.Columns["CTB_CUENTA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_CODIGO = (string)row[dataColumn];
			// Column "CTB_CUENTA_NOMBRE"
			dataColumn = dataTable.Columns["CTB_CUENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_NUMERO"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_NUMERO = (string)row[dataColumn];
			// Column "CTACTE_BANCARIA_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_BANCO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_BANCO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_BANCO_NOMBRE = (string)row[dataColumn];
			// Column "STOCK_DEPOSITO_ID"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "STOCK_DEPOSITO_NOMBRE"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_NOMBRE = (string)row[dataColumn];
			// Column "STOCK_DEPOSITO_SUCURSAL_ID"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "STOCK_DEPOSITO_SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_VALOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_NOMBRE = (string)row[dataColumn];
			// Column "PROVEEDOR_RELACIONADO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_REL_RAZON_SOCIAL"
			dataColumn = dataTable.Columns["PROVEEDOR_REL_RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_REL_RAZON_SOCIAL = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "TIPO_CLIENTE_ID"
			dataColumn = dataTable.Columns["TIPO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "TIPO_CLIENTE_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_CLIENTE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTE_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_RELACIONADA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_RELACIONADA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_RELACIONADA_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FAMILIA_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_USADO"
			dataColumn = dataTable.Columns["ARTICULO_USADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_USADO = (string)row[dataColumn];
			// Column "ARTICULO_DANHADO"
			dataColumn = dataTable.Columns["ARTICULO_DANHADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DANHADO = (string)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_NOMBRE"
			dataColumn = dataTable.Columns["RUBRO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_NOMBRE = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_TEXTO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_TEXTO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_ESTADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_ESTADO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_ESTADO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_ESTADO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_ESTADO_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_NOTAS_CREDITO_ID"
			dataColumn = dataTable.Columns["TIPO_NOTAS_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_NOTAS_CREDITO_ID = (decimal)row[dataColumn];
			// Column "TIPO_ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["TIPO_ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "TIPO_ORDEN_PAGO_DESCRIPCION"
			dataColumn = dataTable.Columns["TIPO_ORDEN_PAGO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ORDEN_PAGO_DESCRIPCION = (string)row[dataColumn];
			// Column "TIPO_NOTAS_CREDITO_DESCRIPCION"
			dataColumn = dataTable.Columns["TIPO_NOTAS_CREDITO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_NOTAS_CREDITO_DESCRIPCION = (string)row[dataColumn];
			// Column "INVERTIR_SI_ES_NEGATIVO"
			dataColumn = dataTable.Columns["INVERTIR_SI_ES_NEGATIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVERTIR_SI_ES_NEGATIVO = (string)row[dataColumn];
			// Column "DESCUENTO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_NOMBRE"
			dataColumn = dataTable.Columns["DESCUENTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_NOMBRE = (string)row[dataColumn];
			// Column "BONIFICACION_ID"
			dataColumn = dataTable.Columns["BONIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BONIFICACION_ID = (decimal)row[dataColumn];
			// Column "BONIFICACION_NOMBRE"
			dataColumn = dataTable.Columns["BONIFICACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BONIFICACION_NOMBRE = (string)row[dataColumn];
			// Column "EXCLUSIONES"
			dataColumn = dataTable.Columns["EXCLUSIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXCLUSIONES = (string)row[dataColumn];
			// Column "INCLUSIONES"
			dataColumn = dataTable.Columns["INCLUSIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUSIONES = (string)row[dataColumn];
			// Column "CREAR_ASIENTO"
			dataColumn = dataTable.Columns["CREAR_ASIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREAR_ASIENTO = (string)row[dataColumn];
			// Column "PERSONA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["PERSONA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_RELACIONADA_ID = (decimal)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "CANAL_VENTA_NOMBRE"
			dataColumn = dataTable.Columns["CANAL_VENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_NOMBRE = (string)row[dataColumn];
			// Column "ACTIVO_RUBRO_ID"
			dataColumn = dataTable.Columns["ACTIVO_RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_RUBRO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_RUBRO_NOMBRE"
			dataColumn = dataTable.Columns["ACTIVO_RUBRO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_RUBRO_NOMBRE = (string)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTO_NOMBRE"
			dataColumn = dataTable.Columns["IMPUESTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_PROCESADORA_TARJETA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_TARJETA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_TARJETA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROC_TARJETA_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_PROC_TARJETA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROC_TARJETA_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_AUTO_REL_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_AUTO_REL_INFO_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_AUTO_DET_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_AUTO_DET_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_AUTO_DET_DESC", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_AUTOMATICO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INVERTIR_DEBE_Y_HABER", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REGION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_CODIGO", typeof(string));
			dataColumn.MaxLength = 113;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_NUMERO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_BANCO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 253;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_REL_RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 174;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_RELACIONADA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 174;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 174;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 953;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_USADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DANHADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_TEXTO", typeof(string));
			dataColumn.MaxLength = 253;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 68;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 103;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_ESTADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_ESTADO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_NOTAS_CREDITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_ORDEN_PAGO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_NOTAS_CREDITO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INVERTIR_SI_ES_NEGATIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BONIFICACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BONIFICACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXCLUSIONES", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INCLUSIONES", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREAR_ASIENTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_RELACIONADA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_RUBRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_RUBRO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_TARJETA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROC_TARJETA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			return dataTable;
		}
		
		/// <summary>
		/// Adds a new parameter to the specified command.
		/// </summary>
		/// <param name="cmd">The <see cref="System.Data.IDbCommand"/> object to add the parameter to.</param>
		/// <param name="paramName">The name of the parameter.</param>
		/// <param name="value">The value of the parameter.</param>
		/// <returns>A reference to the added parameter.</returns>
		protected virtual IDbDataParameter AddParameter(IDbCommand cmd, string paramName, object value)
		{
			IDbDataParameter parameter;
			switch(paramName)
			{
				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_ASIENTO_AUTO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_ASIENTO_AUTO_DET_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_ASIENTO_AUTO_DET_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_ASIENTO_AUTOMATICO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_PLAN_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_PLAN_CUENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_PLAN_CUENTA_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INVERTIR_DEBE_Y_HABER":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CUENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCARIA_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "STOCK_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "STOCK_DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "STOCK_DEPOSITO_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "STOCK_DEPOSITO_SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_REL_RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CLIENTE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_RELACIONADA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_FAMILIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_SUBGRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_USADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_DANHADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FONDO_FIJO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_ESTADO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_NOTAS_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ORDEN_PAGO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_NOTAS_CREDITO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INVERTIR_SI_ES_NEGATIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCUENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BONIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BONIFICACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EXCLUSIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INCLUSIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CREAR_ASIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANAL_VENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_RUBRO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PROCESADORA_TARJETA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROC_TARJETA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_AUTO_REL_INFO_CCollection_Base class
}  // End of namespace
