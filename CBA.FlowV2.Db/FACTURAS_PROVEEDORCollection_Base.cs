// <fileinfo name="FACTURAS_PROVEEDORCollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_PROVEEDORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_PROVEEDORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_PROVEEDORCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string STOCK_DEPOSITO_IDColumnName = "STOCK_DEPOSITO_ID";
		public const string TIPO_FACTURA_PROVEEDOR_IDColumnName = "TIPO_FACTURA_PROVEEDOR_ID";
		public const string FECHAColumnName = "FECHA";
		public const string FECHA_FACTURAColumnName = "FECHA_FACTURA";
		public const string FECHA_RECEPCIONColumnName = "FECHA_RECEPCION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string NUMERO_CONTRATOColumnName = "NUMERO_CONTRATO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_COTIZACIONColumnName = "MONEDA_COTIZACION";
		public const string CTACTE_CONDICION_PAGO_IDColumnName = "CTACTE_CONDICION_PAGO_ID";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string TIPO_CONTENEDOR_IDColumnName = "TIPO_CONTENEDOR_ID";
		public const string CANTIDAD_CONTENEDORESColumnName = "CANTIDAD_CONTENEDORES";
		public const string TIPO_EMBARQUE_IDColumnName = "TIPO_EMBARQUE_ID";
		public const string TOTAL_BRUTOColumnName = "TOTAL_BRUTO";
		public const string TOTAL_DESCUENTOColumnName = "TOTAL_DESCUENTO";
		public const string TOTAL_IMPUESTOColumnName = "TOTAL_IMPUESTO";
		public const string TOTAL_PAGOColumnName = "TOTAL_PAGO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string IMPORTACION_IDColumnName = "IMPORTACION_ID";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string NRO_TIMBRADOColumnName = "NRO_TIMBRADO";
		public const string PAGAR_POR_FONDO_FIJOColumnName = "PAGAR_POR_FONDO_FIJO";
		public const string AFECTA_CTACTE_PROVEEDORColumnName = "AFECTA_CTACTE_PROVEEDOR";
		public const string AFECTA_CTACTE_PERSONAColumnName = "AFECTA_CTACTE_PERSONA";
		public const string AFECTA_CRED_FISCAL_EMPRESAColumnName = "AFECTA_CRED_FISCAL_EMPRESA";
		public const string AFECTA_CRED_FISCAL_PERSONAColumnName = "AFECTA_CRED_FISCAL_PERSONA";
		public const string PASIBLE_RETENCIONColumnName = "PASIBLE_RETENCION";
		public const string NRO_DOCUMENTO_EXTERNOColumnName = "NRO_DOCUMENTO_EXTERNO";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string PORCENTAJE_DESC_SOBRE_TOTALColumnName = "PORCENTAJE_DESC_SOBRE_TOTAL";
		public const string ES_TICKETColumnName = "ES_TICKET";
		public const string PROVEEDOR_GASTO_IDColumnName = "PROVEEDOR_GASTO_ID";
		public const string DIRECCION_LUGAR_TRANSACCIONColumnName = "DIRECCION_LUGAR_TRANSACCION";
		public const string FECHA_VENCIMIENTO_TIMBRADOColumnName = "FECHA_VENCIMIENTO_TIMBRADO";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string EGRESO_VARIO_CAJA_AUTONUM_IDColumnName = "EGRESO_VARIO_CAJA_AUTONUM_ID";
		public const string EGRESO_VARIO_CAJA_NRO_COMPRColumnName = "EGRESO_VARIO_CAJA_NRO_COMPR";
		public const string CENTRO_COSTO_OBLIGATORIOColumnName = "CENTRO_COSTO_OBLIGATORIO";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string EGRESO_VARIO_CAJA_FECHAColumnName = "EGRESO_VARIO_CAJA_FECHA";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string ORDEN_PAGO_CTACTE_BANCARIA_IDColumnName = "ORDEN_PAGO_CTACTE_BANCARIA_ID";
		public const string APLICAR_PRORRATEO_SERVICIOSColumnName = "APLICAR_PRORRATEO_SERVICIOS";
		public const string PAGO_CONTRATISTA_DETALLE_IDColumnName = "PAGO_CONTRATISTA_DETALLE_ID";
		public const string MONEDA_PAIS_COTIZACIONColumnName = "MONEDA_PAIS_COTIZACION";
		public const string ES_FACT_ELECTRONICAColumnName = "ES_FACT_ELECTRONICA";
		public const string TIPO_MOVIMIENTO_SETColumnName = "TIPO_MOVIMIENTO_SET";
		public const string CTB_TIPO_COMPROBANTE_SET_IDColumnName = "CTB_TIPO_COMPROBANTE_SET_ID";
		public const string IMPUTA_IVAColumnName = "IMPUTA_IVA";
		public const string IMPUTA_IREColumnName = "IMPUTA_IRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_PROVEEDORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_PROVEEDORCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this table belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_PROVEEDORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_PROVEEDORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_PROVEEDORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FACTURAS_PROVEEDORRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FACTURAS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FACTURAS_PROVEEDORRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FACTURAS_PROVEEDORRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByORDEN_PAGO_CTACTE_BANCARIA_ID(decimal orden_pago_ctacte_bancaria_id)
		{
			return GetByORDEN_PAGO_CTACTE_BANCARIA_ID(orden_pago_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="orden_pago_ctacte_bancaria_idNull">true if the method ignores the orden_pago_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByORDEN_PAGO_CTACTE_BANCARIA_ID(decimal orden_pago_ctacte_bancaria_id, bool orden_pago_ctacte_bancaria_idNull)
		{
			return MapRecords(CreateGetByORDEN_PAGO_CTACTE_BANCARIA_IDCommand(orden_pago_ctacte_bancaria_id, orden_pago_ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDEN_PAGO_CTACTE_BANCARIA_IDAsDataTable(decimal orden_pago_ctacte_bancaria_id)
		{
			return GetByORDEN_PAGO_CTACTE_BANCARIA_IDAsDataTable(orden_pago_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="orden_pago_ctacte_bancaria_idNull">true if the method ignores the orden_pago_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_CTACTE_BANCARIA_IDAsDataTable(decimal orden_pago_ctacte_bancaria_id, bool orden_pago_ctacte_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_CTACTE_BANCARIA_IDCommand(orden_pago_ctacte_bancaria_id, orden_pago_ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="orden_pago_ctacte_bancaria_idNull">true if the method ignores the orden_pago_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_CTACTE_BANCARIA_IDCommand(decimal orden_pago_ctacte_bancaria_id, bool orden_pago_ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(orden_pago_ctacte_bancaria_idNull)
				whereSql += "ORDEN_PAGO_CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!orden_pago_ctacte_bancaria_idNull)
				AddParameter(cmd, "ORDEN_PAGO_CTACTE_BANCARIA_ID", orden_pago_ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByEGRESO_VARIO_CAJA_AUTONUM_ID(decimal egreso_vario_caja_autonum_id)
		{
			return GetByEGRESO_VARIO_CAJA_AUTONUM_ID(egreso_vario_caja_autonum_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_autonum_idNull">true if the method ignores the egreso_vario_caja_autonum_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByEGRESO_VARIO_CAJA_AUTONUM_ID(decimal egreso_vario_caja_autonum_id, bool egreso_vario_caja_autonum_idNull)
		{
			return MapRecords(CreateGetByEGRESO_VARIO_CAJA_AUTONUM_IDCommand(egreso_vario_caja_autonum_id, egreso_vario_caja_autonum_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEGRESO_VARIO_CAJA_AUTONUM_IDAsDataTable(decimal egreso_vario_caja_autonum_id)
		{
			return GetByEGRESO_VARIO_CAJA_AUTONUM_IDAsDataTable(egreso_vario_caja_autonum_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_autonum_idNull">true if the method ignores the egreso_vario_caja_autonum_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_VARIO_CAJA_AUTONUM_IDAsDataTable(decimal egreso_vario_caja_autonum_id, bool egreso_vario_caja_autonum_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_VARIO_CAJA_AUTONUM_IDCommand(egreso_vario_caja_autonum_id, egreso_vario_caja_autonum_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_autonum_idNull">true if the method ignores the egreso_vario_caja_autonum_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_VARIO_CAJA_AUTONUM_IDCommand(decimal egreso_vario_caja_autonum_id, bool egreso_vario_caja_autonum_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_autonum_idNull)
				whereSql += "EGRESO_VARIO_CAJA_AUTONUM_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_AUTONUM_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_AUTONUM_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!egreso_vario_caja_autonum_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_AUTONUM_ID", egreso_vario_caja_autonum_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByPAGO_CONTRATISTA_DETALLE_ID(decimal pago_contratista_detalle_id)
		{
			return GetByPAGO_CONTRATISTA_DETALLE_ID(pago_contratista_detalle_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <param name="pago_contratista_detalle_idNull">true if the method ignores the pago_contratista_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByPAGO_CONTRATISTA_DETALLE_ID(decimal pago_contratista_detalle_id, bool pago_contratista_detalle_idNull)
		{
			return MapRecords(CreateGetByPAGO_CONTRATISTA_DETALLE_IDCommand(pago_contratista_detalle_id, pago_contratista_detalle_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPAGO_CONTRATISTA_DETALLE_IDAsDataTable(decimal pago_contratista_detalle_id)
		{
			return GetByPAGO_CONTRATISTA_DETALLE_IDAsDataTable(pago_contratista_detalle_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <param name="pago_contratista_detalle_idNull">true if the method ignores the pago_contratista_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAGO_CONTRATISTA_DETALLE_IDAsDataTable(decimal pago_contratista_detalle_id, bool pago_contratista_detalle_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPAGO_CONTRATISTA_DETALLE_IDCommand(pago_contratista_detalle_id, pago_contratista_detalle_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <param name="pago_contratista_detalle_idNull">true if the method ignores the pago_contratista_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAGO_CONTRATISTA_DETALLE_IDCommand(decimal pago_contratista_detalle_id, bool pago_contratista_detalle_idNull)
		{
			string whereSql = "";
			if(pago_contratista_detalle_idNull)
				whereSql += "PAGO_CONTRATISTA_DETALLE_ID IS NULL";
			else
				whereSql += "PAGO_CONTRATISTA_DETALLE_ID=" + _db.CreateSqlParameterName("PAGO_CONTRATISTA_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pago_contratista_detalle_idNull)
				AddParameter(cmd, "PAGO_CONTRATISTA_DETALLE_ID", pago_contratista_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_COND_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_condicion_pago_id">The <c>CTACTE_CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByCTACTE_CONDICION_PAGO_ID(decimal ctacte_condicion_pago_id)
		{
			return MapRecords(CreateGetByCTACTE_CONDICION_PAGO_IDCommand(ctacte_condicion_pago_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_COND_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_condicion_pago_id">The <c>CTACTE_CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CONDICION_PAGO_IDAsDataTable(decimal ctacte_condicion_pago_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CONDICION_PAGO_IDCommand(ctacte_condicion_pago_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_COND_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_condicion_pago_id">The <c>CTACTE_CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CONDICION_PAGO_IDCommand(decimal ctacte_condicion_pago_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_CONDICION_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CONDICION_PAGO_ID", ctacte_condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return GetByTIPO_CONTENEDOR_ID(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return MapRecords(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id)
		{
			return GetByTIPO_CONTENEDOR_IDAsDataTable(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			string whereSql = "";
			if(tipo_contenedor_idNull)
				whereSql += "TIPO_CONTENEDOR_ID IS NULL";
			else
				whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_contenedor_idNull)
				AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_DEP</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetBySTOCK_DEPOSITO_ID(decimal stock_deposito_id)
		{
			return MapRecords(CreateGetBySTOCK_DEPOSITO_IDCommand(stock_deposito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_DEP</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySTOCK_DEPOSITO_IDAsDataTable(decimal stock_deposito_id)
		{
			return MapRecordsToDataTable(CreateGetBySTOCK_DEPOSITO_IDCommand(stock_deposito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_DEP</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySTOCK_DEPOSITO_IDCommand(decimal stock_deposito_id)
		{
			string whereSql = "";
			whereSql += "STOCK_DEPOSITO_ID=" + _db.CreateSqlParameterName("STOCK_DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "STOCK_DEPOSITO_ID", stock_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByTIPO_EMBARQUE_ID(decimal tipo_embarque_id)
		{
			return GetByTIPO_EMBARQUE_ID(tipo_embarque_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByTIPO_EMBARQUE_ID(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			return MapRecords(CreateGetByTIPO_EMBARQUE_IDCommand(tipo_embarque_id, tipo_embarque_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_EMBARQUE_IDAsDataTable(decimal tipo_embarque_id)
		{
			return GetByTIPO_EMBARQUE_IDAsDataTable(tipo_embarque_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_EMBARQUE_IDAsDataTable(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_EMBARQUE_IDCommand(tipo_embarque_id, tipo_embarque_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_EMBARQUE_IDCommand(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			string whereSql = "";
			if(tipo_embarque_idNull)
				whereSql += "TIPO_EMBARQUE_ID IS NULL";
			else
				whereSql += "TIPO_EMBARQUE_ID=" + _db.CreateSqlParameterName("TIPO_EMBARQUE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_embarque_idNull)
				AddParameter(cmd, "TIPO_EMBARQUE_ID", tipo_embarque_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecords(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_IDAsDataTable(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_IDAsDataTable(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByPROVEEDOR_GASTO_ID(decimal proveedor_gasto_id)
		{
			return GetByPROVEEDOR_GASTO_ID(proveedor_gasto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <param name="proveedor_gasto_idNull">true if the method ignores the proveedor_gasto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByPROVEEDOR_GASTO_ID(decimal proveedor_gasto_id, bool proveedor_gasto_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_GASTO_IDCommand(proveedor_gasto_id, proveedor_gasto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_GASTO_IDAsDataTable(decimal proveedor_gasto_id)
		{
			return GetByPROVEEDOR_GASTO_IDAsDataTable(proveedor_gasto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <param name="proveedor_gasto_idNull">true if the method ignores the proveedor_gasto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_GASTO_IDAsDataTable(decimal proveedor_gasto_id, bool proveedor_gasto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_GASTO_IDCommand(proveedor_gasto_id, proveedor_gasto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <param name="proveedor_gasto_idNull">true if the method ignores the proveedor_gasto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_GASTO_IDCommand(decimal proveedor_gasto_id, bool proveedor_gasto_idNull)
		{
			string whereSql = "";
			if(proveedor_gasto_idNull)
				whereSql += "PROVEEDOR_GASTO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_GASTO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_GASTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_gasto_idNull)
				AddParameter(cmd, "PROVEEDOR_GASTO_ID", proveedor_gasto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByIMPORTACION_ID(decimal importacion_id)
		{
			return GetByIMPORTACION_ID(importacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByIMPORTACION_ID(decimal importacion_id, bool importacion_idNull)
		{
			return MapRecords(CreateGetByIMPORTACION_IDCommand(importacion_id, importacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPORTACION_IDAsDataTable(decimal importacion_id)
		{
			return GetByIMPORTACION_IDAsDataTable(importacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPORTACION_IDAsDataTable(decimal importacion_id, bool importacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByIMPORTACION_IDCommand(importacion_id, importacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPORTACION_IDCommand(decimal importacion_id, bool importacion_idNull)
		{
			string whereSql = "";
			if(importacion_idNull)
				whereSql += "IMPORTACION_ID IS NULL";
			else
				whereSql += "IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!importacion_idNull)
				AddParameter(cmd, "IMPORTACION_ID", importacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id)
		{
			string whereSql = "";
			whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public FACTURAS_PROVEEDORRow[] GetByRUBRO_ID(decimal rubro_id)
		{
			return GetByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecords(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id)
		{
			return GetByRUBRO_IDAsDataTable(rubro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRUBRO_IDCommand(decimal rubro_id, bool rubro_idNull)
		{
			string whereSql = "";
			if(rubro_idNull)
				whereSql += "RUBRO_ID IS NULL";
			else
				whereSql += "RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rubro_idNull)
				AddParameter(cmd, "RUBRO_ID", rubro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_PROVEEDORRow"/> objects 
		/// by the <c>FK_FACTURAS_PROVEEDOR_TIPO_FP</c> foreign key.
		/// </summary>
		/// <param name="tipo_factura_proveedor_id">The <c>TIPO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		public virtual FACTURAS_PROVEEDORRow[] GetByTIPO_FACTURA_PROVEEDOR_ID(decimal tipo_factura_proveedor_id)
		{
			return MapRecords(CreateGetByTIPO_FACTURA_PROVEEDOR_IDCommand(tipo_factura_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_PROVEEDOR_TIPO_FP</c> foreign key.
		/// </summary>
		/// <param name="tipo_factura_proveedor_id">The <c>TIPO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_FACTURA_PROVEEDOR_IDAsDataTable(decimal tipo_factura_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_FACTURA_PROVEEDOR_IDCommand(tipo_factura_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_PROVEEDOR_TIPO_FP</c> foreign key.
		/// </summary>
		/// <param name="tipo_factura_proveedor_id">The <c>TIPO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_FACTURA_PROVEEDOR_IDCommand(decimal tipo_factura_proveedor_id)
		{
			string whereSql = "";
			whereSql += "TIPO_FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("TIPO_FACTURA_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_FACTURA_PROVEEDOR_ID", tipo_factura_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_PROVEEDORRow"/> object to be inserted.</param>
		public virtual void Insert(FACTURAS_PROVEEDORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FACTURAS_PROVEEDOR (" +
				"ID, " +
				"CASO_ID, " +
				"PROVEEDOR_ID, " +
				"SUCURSAL_ID, " +
				"STOCK_DEPOSITO_ID, " +
				"TIPO_FACTURA_PROVEEDOR_ID, " +
				"FECHA, " +
				"FECHA_FACTURA, " +
				"FECHA_RECEPCION, " +
				"NRO_COMPROBANTE, " +
				"NUMERO_CONTRATO, " +
				"MONEDA_ID, " +
				"MONEDA_COTIZACION, " +
				"CTACTE_CONDICION_PAGO_ID, " +
				"ESTADO_DOCUMENTACION_ID, " +
				"TIPO_CONTENEDOR_ID, " +
				"CANTIDAD_CONTENEDORES, " +
				"TIPO_EMBARQUE_ID, " +
				"TOTAL_BRUTO, " +
				"TOTAL_DESCUENTO, " +
				"TOTAL_IMPUESTO, " +
				"TOTAL_PAGO, " +
				"OBSERVACION, " +
				"IMPORTACION_ID, " +
				"CENTRO_COSTO_ID, " +
				"RUBRO_ID, " +
				"NRO_TIMBRADO, " +
				"PAGAR_POR_FONDO_FIJO, " +
				"AFECTA_CTACTE_PROVEEDOR, " +
				"AFECTA_CTACTE_PERSONA, " +
				"AFECTA_CRED_FISCAL_EMPRESA, " +
				"AFECTA_CRED_FISCAL_PERSONA, " +
				"PASIBLE_RETENCION, " +
				"NRO_DOCUMENTO_EXTERNO, " +
				"CASO_ASOCIADO_ID, " +
				"PORCENTAJE_DESC_SOBRE_TOTAL, " +
				"ES_TICKET, " +
				"PROVEEDOR_GASTO_ID, " +
				"DIRECCION_LUGAR_TRANSACCION, " +
				"FECHA_VENCIMIENTO_TIMBRADO, " +
				"CTACTE_FONDO_FIJO_ID, " +
				"EGRESO_VARIO_CAJA_AUTONUM_ID, " +
				"EGRESO_VARIO_CAJA_NRO_COMPR, " +
				"CENTRO_COSTO_OBLIGATORIO, " +
				"FUNCIONARIO_ID, " +
				"EGRESO_VARIO_CAJA_FECHA, " +
				"AUTONUMERACION_ID, " +
				"ORDEN_PAGO_CTACTE_BANCARIA_ID, " +
				"APLICAR_PRORRATEO_SERVICIOS, " +
				"PAGO_CONTRATISTA_DETALLE_ID, " +
				"MONEDA_PAIS_COTIZACION, " +
				"ES_FACT_ELECTRONICA, " +
				"TIPO_MOVIMIENTO_SET, " +
				"CTB_TIPO_COMPROBANTE_SET_ID, " +
				"IMPUTA_IVA, " +
				"IMPUTA_IRE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("STOCK_DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_FACTURA_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("FECHA_FACTURA") + ", " +
				_db.CreateSqlParameterName("FECHA_RECEPCION") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("NUMERO_CONTRATO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_COTIZACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_CONDICION_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CONTENEDORES") + ", " +
				_db.CreateSqlParameterName("TIPO_EMBARQUE_ID") + ", " +
				_db.CreateSqlParameterName("TOTAL_BRUTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_PAGO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("IMPORTACION_ID") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("NRO_TIMBRADO") + ", " +
				_db.CreateSqlParameterName("PAGAR_POR_FONDO_FIJO") + ", " +
				_db.CreateSqlParameterName("AFECTA_CTACTE_PROVEEDOR") + ", " +
				_db.CreateSqlParameterName("AFECTA_CTACTE_PERSONA") + ", " +
				_db.CreateSqlParameterName("AFECTA_CRED_FISCAL_EMPRESA") + ", " +
				_db.CreateSqlParameterName("AFECTA_CRED_FISCAL_PERSONA") + ", " +
				_db.CreateSqlParameterName("PASIBLE_RETENCION") + ", " +
				_db.CreateSqlParameterName("NRO_DOCUMENTO_EXTERNO") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DESC_SOBRE_TOTAL") + ", " +
				_db.CreateSqlParameterName("ES_TICKET") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_GASTO_ID") + ", " +
				_db.CreateSqlParameterName("DIRECCION_LUGAR_TRANSACCION") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO_TIMBRADO") + ", " +
				_db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_AUTONUM_ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_NRO_COMPR") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_OBLIGATORIO") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_FECHA") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("APLICAR_PRORRATEO_SERVICIOS") + ", " +
				_db.CreateSqlParameterName("PAGO_CONTRATISTA_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_PAIS_COTIZACION") + ", " +
				_db.CreateSqlParameterName("ES_FACT_ELECTRONICA") + ", " +
				_db.CreateSqlParameterName("TIPO_MOVIMIENTO_SET") + ", " +
				_db.CreateSqlParameterName("CTB_TIPO_COMPROBANTE_SET_ID") + ", " +
				_db.CreateSqlParameterName("IMPUTA_IVA") + ", " +
				_db.CreateSqlParameterName("IMPUTA_IRE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "PROVEEDOR_ID", value.PROVEEDOR_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "STOCK_DEPOSITO_ID", value.STOCK_DEPOSITO_ID);
			AddParameter(cmd, "TIPO_FACTURA_PROVEEDOR_ID", value.TIPO_FACTURA_PROVEEDOR_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FECHA_FACTURA",
				value.IsFECHA_FACTURANull ? DBNull.Value : (object)value.FECHA_FACTURA);
			AddParameter(cmd, "FECHA_RECEPCION",
				value.IsFECHA_RECEPCIONNull ? DBNull.Value : (object)value.FECHA_RECEPCION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "NUMERO_CONTRATO", value.NUMERO_CONTRATO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "MONEDA_COTIZACION", value.MONEDA_COTIZACION);
			AddParameter(cmd, "CTACTE_CONDICION_PAGO_ID", value.CTACTE_CONDICION_PAGO_ID);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID",
				value.IsTIPO_CONTENEDOR_IDNull ? DBNull.Value : (object)value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "CANTIDAD_CONTENEDORES",
				value.IsCANTIDAD_CONTENEDORESNull ? DBNull.Value : (object)value.CANTIDAD_CONTENEDORES);
			AddParameter(cmd, "TIPO_EMBARQUE_ID",
				value.IsTIPO_EMBARQUE_IDNull ? DBNull.Value : (object)value.TIPO_EMBARQUE_ID);
			AddParameter(cmd, "TOTAL_BRUTO",
				value.IsTOTAL_BRUTONull ? DBNull.Value : (object)value.TOTAL_BRUTO);
			AddParameter(cmd, "TOTAL_DESCUENTO",
				value.IsTOTAL_DESCUENTONull ? DBNull.Value : (object)value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_IMPUESTO",
				value.IsTOTAL_IMPUESTONull ? DBNull.Value : (object)value.TOTAL_IMPUESTO);
			AddParameter(cmd, "TOTAL_PAGO",
				value.IsTOTAL_PAGONull ? DBNull.Value : (object)value.TOTAL_PAGO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "IMPORTACION_ID",
				value.IsIMPORTACION_IDNull ? DBNull.Value : (object)value.IMPORTACION_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "NRO_TIMBRADO", value.NRO_TIMBRADO);
			AddParameter(cmd, "PAGAR_POR_FONDO_FIJO", value.PAGAR_POR_FONDO_FIJO);
			AddParameter(cmd, "AFECTA_CTACTE_PROVEEDOR", value.AFECTA_CTACTE_PROVEEDOR);
			AddParameter(cmd, "AFECTA_CTACTE_PERSONA", value.AFECTA_CTACTE_PERSONA);
			AddParameter(cmd, "AFECTA_CRED_FISCAL_EMPRESA", value.AFECTA_CRED_FISCAL_EMPRESA);
			AddParameter(cmd, "AFECTA_CRED_FISCAL_PERSONA", value.AFECTA_CRED_FISCAL_PERSONA);
			AddParameter(cmd, "PASIBLE_RETENCION", value.PASIBLE_RETENCION);
			AddParameter(cmd, "NRO_DOCUMENTO_EXTERNO", value.NRO_DOCUMENTO_EXTERNO);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "PORCENTAJE_DESC_SOBRE_TOTAL", value.PORCENTAJE_DESC_SOBRE_TOTAL);
			AddParameter(cmd, "ES_TICKET", value.ES_TICKET);
			AddParameter(cmd, "PROVEEDOR_GASTO_ID",
				value.IsPROVEEDOR_GASTO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_GASTO_ID);
			AddParameter(cmd, "DIRECCION_LUGAR_TRANSACCION", value.DIRECCION_LUGAR_TRANSACCION);
			AddParameter(cmd, "FECHA_VENCIMIENTO_TIMBRADO", value.FECHA_VENCIMIENTO_TIMBRADO);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_AUTONUM_ID",
				value.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_AUTONUM_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_NRO_COMPR", value.EGRESO_VARIO_CAJA_NRO_COMPR);
			AddParameter(cmd, "CENTRO_COSTO_OBLIGATORIO", value.CENTRO_COSTO_OBLIGATORIO);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_FECHA",
				value.IsEGRESO_VARIO_CAJA_FECHANull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_FECHA);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "ORDEN_PAGO_CTACTE_BANCARIA_ID",
				value.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_CTACTE_BANCARIA_ID);
			AddParameter(cmd, "APLICAR_PRORRATEO_SERVICIOS", value.APLICAR_PRORRATEO_SERVICIOS);
			AddParameter(cmd, "PAGO_CONTRATISTA_DETALLE_ID",
				value.IsPAGO_CONTRATISTA_DETALLE_IDNull ? DBNull.Value : (object)value.PAGO_CONTRATISTA_DETALLE_ID);
			AddParameter(cmd, "MONEDA_PAIS_COTIZACION", value.MONEDA_PAIS_COTIZACION);
			AddParameter(cmd, "ES_FACT_ELECTRONICA", value.ES_FACT_ELECTRONICA);
			AddParameter(cmd, "TIPO_MOVIMIENTO_SET", value.TIPO_MOVIMIENTO_SET);
			AddParameter(cmd, "CTB_TIPO_COMPROBANTE_SET_ID",
				value.IsCTB_TIPO_COMPROBANTE_SET_IDNull ? DBNull.Value : (object)value.CTB_TIPO_COMPROBANTE_SET_ID);
			AddParameter(cmd, "IMPUTA_IVA", value.IMPUTA_IVA);
			AddParameter(cmd, "IMPUTA_IRE", value.IMPUTA_IRE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_PROVEEDORRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FACTURAS_PROVEEDORRow value)
		{
			
			string sqlStr = "UPDATE TRC.FACTURAS_PROVEEDOR SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"STOCK_DEPOSITO_ID=" + _db.CreateSqlParameterName("STOCK_DEPOSITO_ID") + ", " +
				"TIPO_FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("TIPO_FACTURA_PROVEEDOR_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"FECHA_FACTURA=" + _db.CreateSqlParameterName("FECHA_FACTURA") + ", " +
				"FECHA_RECEPCION=" + _db.CreateSqlParameterName("FECHA_RECEPCION") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"NUMERO_CONTRATO=" + _db.CreateSqlParameterName("NUMERO_CONTRATO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"MONEDA_COTIZACION=" + _db.CreateSqlParameterName("MONEDA_COTIZACION") + ", " +
				"CTACTE_CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_CONDICION_PAGO_ID") + ", " +
				"ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				"TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				"CANTIDAD_CONTENEDORES=" + _db.CreateSqlParameterName("CANTIDAD_CONTENEDORES") + ", " +
				"TIPO_EMBARQUE_ID=" + _db.CreateSqlParameterName("TIPO_EMBARQUE_ID") + ", " +
				"TOTAL_BRUTO=" + _db.CreateSqlParameterName("TOTAL_BRUTO") + ", " +
				"TOTAL_DESCUENTO=" + _db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				"TOTAL_IMPUESTO=" + _db.CreateSqlParameterName("TOTAL_IMPUESTO") + ", " +
				"TOTAL_PAGO=" + _db.CreateSqlParameterName("TOTAL_PAGO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID") + ", " +
				"NRO_TIMBRADO=" + _db.CreateSqlParameterName("NRO_TIMBRADO") + ", " +
				"PAGAR_POR_FONDO_FIJO=" + _db.CreateSqlParameterName("PAGAR_POR_FONDO_FIJO") + ", " +
				"AFECTA_CTACTE_PROVEEDOR=" + _db.CreateSqlParameterName("AFECTA_CTACTE_PROVEEDOR") + ", " +
				"AFECTA_CTACTE_PERSONA=" + _db.CreateSqlParameterName("AFECTA_CTACTE_PERSONA") + ", " +
				"AFECTA_CRED_FISCAL_EMPRESA=" + _db.CreateSqlParameterName("AFECTA_CRED_FISCAL_EMPRESA") + ", " +
				"AFECTA_CRED_FISCAL_PERSONA=" + _db.CreateSqlParameterName("AFECTA_CRED_FISCAL_PERSONA") + ", " +
				"PASIBLE_RETENCION=" + _db.CreateSqlParameterName("PASIBLE_RETENCION") + ", " +
				"NRO_DOCUMENTO_EXTERNO=" + _db.CreateSqlParameterName("NRO_DOCUMENTO_EXTERNO") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"PORCENTAJE_DESC_SOBRE_TOTAL=" + _db.CreateSqlParameterName("PORCENTAJE_DESC_SOBRE_TOTAL") + ", " +
				"ES_TICKET=" + _db.CreateSqlParameterName("ES_TICKET") + ", " +
				"PROVEEDOR_GASTO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_GASTO_ID") + ", " +
				"DIRECCION_LUGAR_TRANSACCION=" + _db.CreateSqlParameterName("DIRECCION_LUGAR_TRANSACCION") + ", " +
				"FECHA_VENCIMIENTO_TIMBRADO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO_TIMBRADO") + ", " +
				"CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				"EGRESO_VARIO_CAJA_AUTONUM_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_AUTONUM_ID") + ", " +
				"EGRESO_VARIO_CAJA_NRO_COMPR=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_NRO_COMPR") + ", " +
				"CENTRO_COSTO_OBLIGATORIO=" + _db.CreateSqlParameterName("CENTRO_COSTO_OBLIGATORIO") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"EGRESO_VARIO_CAJA_FECHA=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_FECHA") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"ORDEN_PAGO_CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_CTACTE_BANCARIA_ID") + ", " +
				"APLICAR_PRORRATEO_SERVICIOS=" + _db.CreateSqlParameterName("APLICAR_PRORRATEO_SERVICIOS") + ", " +
				"PAGO_CONTRATISTA_DETALLE_ID=" + _db.CreateSqlParameterName("PAGO_CONTRATISTA_DETALLE_ID") + ", " +
				"MONEDA_PAIS_COTIZACION=" + _db.CreateSqlParameterName("MONEDA_PAIS_COTIZACION") + ", " +
				"ES_FACT_ELECTRONICA=" + _db.CreateSqlParameterName("ES_FACT_ELECTRONICA") + ", " +
				"TIPO_MOVIMIENTO_SET=" + _db.CreateSqlParameterName("TIPO_MOVIMIENTO_SET") + ", " +
				"CTB_TIPO_COMPROBANTE_SET_ID=" + _db.CreateSqlParameterName("CTB_TIPO_COMPROBANTE_SET_ID") + ", " +
				"IMPUTA_IVA=" + _db.CreateSqlParameterName("IMPUTA_IVA") + ", " +
				"IMPUTA_IRE=" + _db.CreateSqlParameterName("IMPUTA_IRE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "PROVEEDOR_ID", value.PROVEEDOR_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "STOCK_DEPOSITO_ID", value.STOCK_DEPOSITO_ID);
			AddParameter(cmd, "TIPO_FACTURA_PROVEEDOR_ID", value.TIPO_FACTURA_PROVEEDOR_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FECHA_FACTURA",
				value.IsFECHA_FACTURANull ? DBNull.Value : (object)value.FECHA_FACTURA);
			AddParameter(cmd, "FECHA_RECEPCION",
				value.IsFECHA_RECEPCIONNull ? DBNull.Value : (object)value.FECHA_RECEPCION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "NUMERO_CONTRATO", value.NUMERO_CONTRATO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "MONEDA_COTIZACION", value.MONEDA_COTIZACION);
			AddParameter(cmd, "CTACTE_CONDICION_PAGO_ID", value.CTACTE_CONDICION_PAGO_ID);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID",
				value.IsTIPO_CONTENEDOR_IDNull ? DBNull.Value : (object)value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "CANTIDAD_CONTENEDORES",
				value.IsCANTIDAD_CONTENEDORESNull ? DBNull.Value : (object)value.CANTIDAD_CONTENEDORES);
			AddParameter(cmd, "TIPO_EMBARQUE_ID",
				value.IsTIPO_EMBARQUE_IDNull ? DBNull.Value : (object)value.TIPO_EMBARQUE_ID);
			AddParameter(cmd, "TOTAL_BRUTO",
				value.IsTOTAL_BRUTONull ? DBNull.Value : (object)value.TOTAL_BRUTO);
			AddParameter(cmd, "TOTAL_DESCUENTO",
				value.IsTOTAL_DESCUENTONull ? DBNull.Value : (object)value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_IMPUESTO",
				value.IsTOTAL_IMPUESTONull ? DBNull.Value : (object)value.TOTAL_IMPUESTO);
			AddParameter(cmd, "TOTAL_PAGO",
				value.IsTOTAL_PAGONull ? DBNull.Value : (object)value.TOTAL_PAGO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "IMPORTACION_ID",
				value.IsIMPORTACION_IDNull ? DBNull.Value : (object)value.IMPORTACION_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "NRO_TIMBRADO", value.NRO_TIMBRADO);
			AddParameter(cmd, "PAGAR_POR_FONDO_FIJO", value.PAGAR_POR_FONDO_FIJO);
			AddParameter(cmd, "AFECTA_CTACTE_PROVEEDOR", value.AFECTA_CTACTE_PROVEEDOR);
			AddParameter(cmd, "AFECTA_CTACTE_PERSONA", value.AFECTA_CTACTE_PERSONA);
			AddParameter(cmd, "AFECTA_CRED_FISCAL_EMPRESA", value.AFECTA_CRED_FISCAL_EMPRESA);
			AddParameter(cmd, "AFECTA_CRED_FISCAL_PERSONA", value.AFECTA_CRED_FISCAL_PERSONA);
			AddParameter(cmd, "PASIBLE_RETENCION", value.PASIBLE_RETENCION);
			AddParameter(cmd, "NRO_DOCUMENTO_EXTERNO", value.NRO_DOCUMENTO_EXTERNO);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "PORCENTAJE_DESC_SOBRE_TOTAL", value.PORCENTAJE_DESC_SOBRE_TOTAL);
			AddParameter(cmd, "ES_TICKET", value.ES_TICKET);
			AddParameter(cmd, "PROVEEDOR_GASTO_ID",
				value.IsPROVEEDOR_GASTO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_GASTO_ID);
			AddParameter(cmd, "DIRECCION_LUGAR_TRANSACCION", value.DIRECCION_LUGAR_TRANSACCION);
			AddParameter(cmd, "FECHA_VENCIMIENTO_TIMBRADO", value.FECHA_VENCIMIENTO_TIMBRADO);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_AUTONUM_ID",
				value.IsEGRESO_VARIO_CAJA_AUTONUM_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_AUTONUM_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_NRO_COMPR", value.EGRESO_VARIO_CAJA_NRO_COMPR);
			AddParameter(cmd, "CENTRO_COSTO_OBLIGATORIO", value.CENTRO_COSTO_OBLIGATORIO);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_FECHA",
				value.IsEGRESO_VARIO_CAJA_FECHANull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_FECHA);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "ORDEN_PAGO_CTACTE_BANCARIA_ID",
				value.IsORDEN_PAGO_CTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_CTACTE_BANCARIA_ID);
			AddParameter(cmd, "APLICAR_PRORRATEO_SERVICIOS", value.APLICAR_PRORRATEO_SERVICIOS);
			AddParameter(cmd, "PAGO_CONTRATISTA_DETALLE_ID",
				value.IsPAGO_CONTRATISTA_DETALLE_IDNull ? DBNull.Value : (object)value.PAGO_CONTRATISTA_DETALLE_ID);
			AddParameter(cmd, "MONEDA_PAIS_COTIZACION", value.MONEDA_PAIS_COTIZACION);
			AddParameter(cmd, "ES_FACT_ELECTRONICA", value.ES_FACT_ELECTRONICA);
			AddParameter(cmd, "TIPO_MOVIMIENTO_SET", value.TIPO_MOVIMIENTO_SET);
			AddParameter(cmd, "CTB_TIPO_COMPROBANTE_SET_ID",
				value.IsCTB_TIPO_COMPROBANTE_SET_IDNull ? DBNull.Value : (object)value.CTB_TIPO_COMPROBANTE_SET_ID);
			AddParameter(cmd, "IMPUTA_IVA", value.IMPUTA_IVA);
			AddParameter(cmd, "IMPUTA_IRE", value.IMPUTA_IRE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FACTURAS_PROVEEDOR</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FACTURAS_PROVEEDOR</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
		/// argument when your code calls this method in an ADO.NET transaction context. Note that in 
		/// this case, after you call the Update method you need call either <c>AcceptChanges</c> 
		/// or <c>RejectChanges</c> method on the DataTable object.
		/// <code>
		/// MyDb db = new MyDb();
		/// try
		/// {
		///		db.BeginTransaction();
		///		db.MyCollection.Update(myDataTable, false);
		///		db.CommitTransaction();
		///		myDataTable.AcceptChanges();
		/// }
		/// catch(Exception)
		/// {
		///		db.RollbackTransaction();
		///		myDataTable.RejectChanges();
		/// }
		/// </code>
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		/// <param name="acceptChanges">Specifies whether this method calls the <c>AcceptChanges</c>
		/// method on the changed DataRow objects.</param>
		public virtual void Update(DataTable table, bool acceptChanges)
		{
			DataRowCollection rows = table.Rows;
			for(int i = rows.Count - 1; i >= 0; i--)
			{
				DataRow row = rows[i];
				switch(row.RowState)
				{
					case DataRowState.Added:
						Insert(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;

					case DataRowState.Deleted:
						// Temporary reject changes to be able to access to the PK column(s)
						row.RejectChanges();
						try
						{
							DeleteByPrimaryKey((decimal)row["ID"]);
						}
						finally
						{
							row.Delete();
						}
						if(acceptChanges)
							row.AcceptChanges();
						break;
						
					case DataRowState.Modified:
						Update(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;
				}
			}
		}

		/// <summary>
		/// Deletes the specified object from the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_PROVEEDORRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FACTURAS_PROVEEDORRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FACTURAS_PROVEEDOR</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ID", id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_AUTONUMERAC</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_CTACTE_BANCARIA_ID(decimal orden_pago_ctacte_bancaria_id)
		{
			return DeleteByORDEN_PAGO_CTACTE_BANCARIA_ID(orden_pago_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="orden_pago_ctacte_bancaria_idNull">true if the method ignores the orden_pago_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_CTACTE_BANCARIA_ID(decimal orden_pago_ctacte_bancaria_id, bool orden_pago_ctacte_bancaria_idNull)
		{
			return CreateDeleteByORDEN_PAGO_CTACTE_BANCARIA_IDCommand(orden_pago_ctacte_bancaria_id, orden_pago_ctacte_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_CTA_BANCARIA</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_ctacte_bancaria_id">The <c>ORDEN_PAGO_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="orden_pago_ctacte_bancaria_idNull">true if the method ignores the orden_pago_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_CTACTE_BANCARIA_IDCommand(decimal orden_pago_ctacte_bancaria_id, bool orden_pago_ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(orden_pago_ctacte_bancaria_idNull)
				whereSql += "ORDEN_PAGO_CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!orden_pago_ctacte_bancaria_idNull)
				AddParameter(cmd, "ORDEN_PAGO_CTACTE_BANCARIA_ID", orden_pago_ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_AUTONUM_ID(decimal egreso_vario_caja_autonum_id)
		{
			return DeleteByEGRESO_VARIO_CAJA_AUTONUM_ID(egreso_vario_caja_autonum_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_autonum_idNull">true if the method ignores the egreso_vario_caja_autonum_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_AUTONUM_ID(decimal egreso_vario_caja_autonum_id, bool egreso_vario_caja_autonum_idNull)
		{
			return CreateDeleteByEGRESO_VARIO_CAJA_AUTONUM_IDCommand(egreso_vario_caja_autonum_id, egreso_vario_caja_autonum_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_EVC_NRO_COMP</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_autonum_id">The <c>EGRESO_VARIO_CAJA_AUTONUM_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_autonum_idNull">true if the method ignores the egreso_vario_caja_autonum_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_VARIO_CAJA_AUTONUM_IDCommand(decimal egreso_vario_caja_autonum_id, bool egreso_vario_caja_autonum_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_autonum_idNull)
				whereSql += "EGRESO_VARIO_CAJA_AUTONUM_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_AUTONUM_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_AUTONUM_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!egreso_vario_caja_autonum_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_AUTONUM_ID", egreso_vario_caja_autonum_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAGO_CONTRATISTA_DETALLE_ID(decimal pago_contratista_detalle_id)
		{
			return DeleteByPAGO_CONTRATISTA_DETALLE_ID(pago_contratista_detalle_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <param name="pago_contratista_detalle_idNull">true if the method ignores the pago_contratista_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAGO_CONTRATISTA_DETALLE_ID(decimal pago_contratista_detalle_id, bool pago_contratista_detalle_idNull)
		{
			return CreateDeleteByPAGO_CONTRATISTA_DETALLE_IDCommand(pago_contratista_detalle_id, pago_contratista_detalle_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROV_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_detalle_id">The <c>PAGO_CONTRATISTA_DETALLE_ID</c> column value.</param>
		/// <param name="pago_contratista_detalle_idNull">true if the method ignores the pago_contratista_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAGO_CONTRATISTA_DETALLE_IDCommand(decimal pago_contratista_detalle_id, bool pago_contratista_detalle_idNull)
		{
			string whereSql = "";
			if(pago_contratista_detalle_idNull)
				whereSql += "PAGO_CONTRATISTA_DETALLE_ID IS NULL";
			else
				whereSql += "PAGO_CONTRATISTA_DETALLE_ID=" + _db.CreateSqlParameterName("PAGO_CONTRATISTA_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pago_contratista_detalle_idNull)
				AddParameter(cmd, "PAGO_CONTRATISTA_DETALLE_ID", pago_contratista_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_COND_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_condicion_pago_id">The <c>CTACTE_CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CONDICION_PAGO_ID(decimal ctacte_condicion_pago_id)
		{
			return CreateDeleteByCTACTE_CONDICION_PAGO_IDCommand(ctacte_condicion_pago_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_COND_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_condicion_pago_id">The <c>CTACTE_CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CONDICION_PAGO_IDCommand(decimal ctacte_condicion_pago_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_CONDICION_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CONDICION_PAGO_ID", ctacte_condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return DeleteByTIPO_CONTENEDOR_ID(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return CreateDeleteByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			string whereSql = "";
			if(tipo_contenedor_idNull)
				whereSql += "TIPO_CONTENEDOR_ID IS NULL";
			else
				whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_contenedor_idNull)
				AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_DEP</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySTOCK_DEPOSITO_ID(decimal stock_deposito_id)
		{
			return CreateDeleteBySTOCK_DEPOSITO_IDCommand(stock_deposito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_DEP</c> foreign key.
		/// </summary>
		/// <param name="stock_deposito_id">The <c>STOCK_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySTOCK_DEPOSITO_IDCommand(decimal stock_deposito_id)
		{
			string whereSql = "";
			whereSql += "STOCK_DEPOSITO_ID=" + _db.CreateSqlParameterName("STOCK_DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "STOCK_DEPOSITO_ID", stock_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_EMBARQUE_ID(decimal tipo_embarque_id)
		{
			return DeleteByTIPO_EMBARQUE_ID(tipo_embarque_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_EMBARQUE_ID(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			return CreateDeleteByTIPO_EMBARQUE_IDCommand(tipo_embarque_id, tipo_embarque_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_EMBARQ</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_EMBARQUE_IDCommand(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			string whereSql = "";
			if(tipo_embarque_idNull)
				whereSql += "TIPO_EMBARQUE_ID IS NULL";
			else
				whereSql += "TIPO_EMBARQUE_ID=" + _db.CreateSqlParameterName("TIPO_EMBARQUE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_embarque_idNull)
				AddParameter(cmd, "TIPO_EMBARQUE_ID", tipo_embarque_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return DeleteByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return CreateDeleteByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_EST_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return DeleteByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_FOND_FIJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_GASTO_ID(decimal proveedor_gasto_id)
		{
			return DeleteByPROVEEDOR_GASTO_ID(proveedor_gasto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <param name="proveedor_gasto_idNull">true if the method ignores the proveedor_gasto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_GASTO_ID(decimal proveedor_gasto_id, bool proveedor_gasto_idNull)
		{
			return CreateDeleteByPROVEEDOR_GASTO_IDCommand(proveedor_gasto_id, proveedor_gasto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_GASTO_ID</c> foreign key.
		/// </summary>
		/// <param name="proveedor_gasto_id">The <c>PROVEEDOR_GASTO_ID</c> column value.</param>
		/// <param name="proveedor_gasto_idNull">true if the method ignores the proveedor_gasto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_GASTO_IDCommand(decimal proveedor_gasto_id, bool proveedor_gasto_idNull)
		{
			string whereSql = "";
			if(proveedor_gasto_idNull)
				whereSql += "PROVEEDOR_GASTO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_GASTO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_GASTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_gasto_idNull)
				AddParameter(cmd, "PROVEEDOR_GASTO_ID", proveedor_gasto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPORTACION_ID(decimal importacion_id)
		{
			return DeleteByIMPORTACION_ID(importacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPORTACION_ID(decimal importacion_id, bool importacion_idNull)
		{
			return CreateDeleteByIMPORTACION_IDCommand(importacion_id, importacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_IMPORTAC</c> foreign key.
		/// </summary>
		/// <param name="importacion_id">The <c>IMPORTACION_ID</c> column value.</param>
		/// <param name="importacion_idNull">true if the method ignores the importacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPORTACION_IDCommand(decimal importacion_id, bool importacion_idNull)
		{
			string whereSql = "";
			if(importacion_idNull)
				whereSql += "IMPORTACION_ID IS NULL";
			else
				whereSql += "IMPORTACION_ID=" + _db.CreateSqlParameterName("IMPORTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!importacion_idNull)
				AddParameter(cmd, "IMPORTACION_ID", importacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id)
		{
			string whereSql = "";
			whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id)
		{
			return DeleteByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return CreateDeleteByRUBRO_IDCommand(rubro_id, rubro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRUBRO_IDCommand(decimal rubro_id, bool rubro_idNull)
		{
			string whereSql = "";
			if(rubro_idNull)
				whereSql += "RUBRO_ID IS NULL";
			else
				whereSql += "RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rubro_idNull)
				AddParameter(cmd, "RUBRO_ID", rubro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_PROVEEDOR</c> table using the 
		/// <c>FK_FACTURAS_PROVEEDOR_TIPO_FP</c> foreign key.
		/// </summary>
		/// <param name="tipo_factura_proveedor_id">The <c>TIPO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_FACTURA_PROVEEDOR_ID(decimal tipo_factura_proveedor_id)
		{
			return CreateDeleteByTIPO_FACTURA_PROVEEDOR_IDCommand(tipo_factura_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_PROVEEDOR_TIPO_FP</c> foreign key.
		/// </summary>
		/// <param name="tipo_factura_proveedor_id">The <c>TIPO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_FACTURA_PROVEEDOR_IDCommand(decimal tipo_factura_proveedor_id)
		{
			string whereSql = "";
			whereSql += "TIPO_FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("TIPO_FACTURA_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_FACTURA_PROVEEDOR_ID", tipo_factura_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FACTURAS_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>The number of deleted records.</returns>
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used 
		/// to delete <c>FACTURAS_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FACTURAS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>The number of deleted records.</returns>
		public int DeleteAll()
		{
			return Delete("");
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		protected FACTURAS_PROVEEDORRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		protected FACTURAS_PROVEEDORRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="FACTURAS_PROVEEDORRow"/> objects.</returns>
		protected virtual FACTURAS_PROVEEDORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int stock_deposito_idColumnIndex = reader.GetOrdinal("STOCK_DEPOSITO_ID");
			int tipo_factura_proveedor_idColumnIndex = reader.GetOrdinal("TIPO_FACTURA_PROVEEDOR_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int fecha_facturaColumnIndex = reader.GetOrdinal("FECHA_FACTURA");
			int fecha_recepcionColumnIndex = reader.GetOrdinal("FECHA_RECEPCION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int numero_contratoColumnIndex = reader.GetOrdinal("NUMERO_CONTRATO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_COTIZACION");
			int ctacte_condicion_pago_idColumnIndex = reader.GetOrdinal("CTACTE_CONDICION_PAGO_ID");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int tipo_contenedor_idColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_ID");
			int cantidad_contenedoresColumnIndex = reader.GetOrdinal("CANTIDAD_CONTENEDORES");
			int tipo_embarque_idColumnIndex = reader.GetOrdinal("TIPO_EMBARQUE_ID");
			int total_brutoColumnIndex = reader.GetOrdinal("TOTAL_BRUTO");
			int total_descuentoColumnIndex = reader.GetOrdinal("TOTAL_DESCUENTO");
			int total_impuestoColumnIndex = reader.GetOrdinal("TOTAL_IMPUESTO");
			int total_pagoColumnIndex = reader.GetOrdinal("TOTAL_PAGO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int importacion_idColumnIndex = reader.GetOrdinal("IMPORTACION_ID");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int nro_timbradoColumnIndex = reader.GetOrdinal("NRO_TIMBRADO");
			int pagar_por_fondo_fijoColumnIndex = reader.GetOrdinal("PAGAR_POR_FONDO_FIJO");
			int afecta_ctacte_proveedorColumnIndex = reader.GetOrdinal("AFECTA_CTACTE_PROVEEDOR");
			int afecta_ctacte_personaColumnIndex = reader.GetOrdinal("AFECTA_CTACTE_PERSONA");
			int afecta_cred_fiscal_empresaColumnIndex = reader.GetOrdinal("AFECTA_CRED_FISCAL_EMPRESA");
			int afecta_cred_fiscal_personaColumnIndex = reader.GetOrdinal("AFECTA_CRED_FISCAL_PERSONA");
			int pasible_retencionColumnIndex = reader.GetOrdinal("PASIBLE_RETENCION");
			int nro_documento_externoColumnIndex = reader.GetOrdinal("NRO_DOCUMENTO_EXTERNO");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int porcentaje_desc_sobre_totalColumnIndex = reader.GetOrdinal("PORCENTAJE_DESC_SOBRE_TOTAL");
			int es_ticketColumnIndex = reader.GetOrdinal("ES_TICKET");
			int proveedor_gasto_idColumnIndex = reader.GetOrdinal("PROVEEDOR_GASTO_ID");
			int direccion_lugar_transaccionColumnIndex = reader.GetOrdinal("DIRECCION_LUGAR_TRANSACCION");
			int fecha_vencimiento_timbradoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_TIMBRADO");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int egreso_vario_caja_autonum_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_AUTONUM_ID");
			int egreso_vario_caja_nro_comprColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_NRO_COMPR");
			int centro_costo_obligatorioColumnIndex = reader.GetOrdinal("CENTRO_COSTO_OBLIGATORIO");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int egreso_vario_caja_fechaColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_FECHA");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int orden_pago_ctacte_bancaria_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_CTACTE_BANCARIA_ID");
			int aplicar_prorrateo_serviciosColumnIndex = reader.GetOrdinal("APLICAR_PRORRATEO_SERVICIOS");
			int pago_contratista_detalle_idColumnIndex = reader.GetOrdinal("PAGO_CONTRATISTA_DETALLE_ID");
			int moneda_pais_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_PAIS_COTIZACION");
			int es_fact_electronicaColumnIndex = reader.GetOrdinal("ES_FACT_ELECTRONICA");
			int tipo_movimiento_setColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO_SET");
			int ctb_tipo_comprobante_set_idColumnIndex = reader.GetOrdinal("CTB_TIPO_COMPROBANTE_SET_ID");
			int imputa_ivaColumnIndex = reader.GetOrdinal("IMPUTA_IVA");
			int imputa_ireColumnIndex = reader.GetOrdinal("IMPUTA_IRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_PROVEEDORRow record = new FACTURAS_PROVEEDORRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.STOCK_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_deposito_idColumnIndex)), 9);
					record.TIPO_FACTURA_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_factura_proveedor_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(fecha_facturaColumnIndex))
						record.FECHA_FACTURA = Convert.ToDateTime(reader.GetValue(fecha_facturaColumnIndex));
					if(!reader.IsDBNull(fecha_recepcionColumnIndex))
						record.FECHA_RECEPCION = Convert.ToDateTime(reader.GetValue(fecha_recepcionColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(numero_contratoColumnIndex))
						record.NUMERO_CONTRATO = Convert.ToString(reader.GetValue(numero_contratoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cotizacionColumnIndex)), 9);
					record.CTACTE_CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_documentacion_idColumnIndex))
						record.ESTADO_DOCUMENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_documentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_contenedor_idColumnIndex))
						record.TIPO_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_contenedoresColumnIndex))
						record.CANTIDAD_CONTENEDORES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_contenedoresColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_embarque_idColumnIndex))
						record.TIPO_EMBARQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_embarque_idColumnIndex)), 9);
					if(!reader.IsDBNull(total_brutoColumnIndex))
						record.TOTAL_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_descuentoColumnIndex))
						record.TOTAL_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(total_impuestoColumnIndex))
						record.TOTAL_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(total_pagoColumnIndex))
						record.TOTAL_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(total_pagoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(importacion_idColumnIndex))
						record.IMPORTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(importacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_timbradoColumnIndex))
						record.NRO_TIMBRADO = Convert.ToString(reader.GetValue(nro_timbradoColumnIndex));
					record.PAGAR_POR_FONDO_FIJO = Convert.ToString(reader.GetValue(pagar_por_fondo_fijoColumnIndex));
					record.AFECTA_CTACTE_PROVEEDOR = Convert.ToString(reader.GetValue(afecta_ctacte_proveedorColumnIndex));
					record.AFECTA_CTACTE_PERSONA = Convert.ToString(reader.GetValue(afecta_ctacte_personaColumnIndex));
					record.AFECTA_CRED_FISCAL_EMPRESA = Convert.ToString(reader.GetValue(afecta_cred_fiscal_empresaColumnIndex));
					record.AFECTA_CRED_FISCAL_PERSONA = Convert.ToString(reader.GetValue(afecta_cred_fiscal_personaColumnIndex));
					record.PASIBLE_RETENCION = Convert.ToString(reader.GetValue(pasible_retencionColumnIndex));
					if(!reader.IsDBNull(nro_documento_externoColumnIndex))
						record.NRO_DOCUMENTO_EXTERNO = Convert.ToString(reader.GetValue(nro_documento_externoColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					record.PORCENTAJE_DESC_SOBRE_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_desc_sobre_totalColumnIndex)), 9);
					record.ES_TICKET = Convert.ToString(reader.GetValue(es_ticketColumnIndex));
					if(!reader.IsDBNull(proveedor_gasto_idColumnIndex))
						record.PROVEEDOR_GASTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_gasto_idColumnIndex)), 9);
					if(!reader.IsDBNull(direccion_lugar_transaccionColumnIndex))
						record.DIRECCION_LUGAR_TRANSACCION = Convert.ToString(reader.GetValue(direccion_lugar_transaccionColumnIndex));
					record.FECHA_VENCIMIENTO_TIMBRADO = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_timbradoColumnIndex));
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_autonum_idColumnIndex))
						record.EGRESO_VARIO_CAJA_AUTONUM_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_autonum_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_nro_comprColumnIndex))
						record.EGRESO_VARIO_CAJA_NRO_COMPR = Convert.ToString(reader.GetValue(egreso_vario_caja_nro_comprColumnIndex));
					record.CENTRO_COSTO_OBLIGATORIO = Convert.ToString(reader.GetValue(centro_costo_obligatorioColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_fechaColumnIndex))
						record.EGRESO_VARIO_CAJA_FECHA = Convert.ToDateTime(reader.GetValue(egreso_vario_caja_fechaColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_ctacte_bancaria_idColumnIndex))
						record.ORDEN_PAGO_CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_ctacte_bancaria_idColumnIndex)), 9);
					record.APLICAR_PRORRATEO_SERVICIOS = Convert.ToString(reader.GetValue(aplicar_prorrateo_serviciosColumnIndex));
					if(!reader.IsDBNull(pago_contratista_detalle_idColumnIndex))
						record.PAGO_CONTRATISTA_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pago_contratista_detalle_idColumnIndex)), 9);
					record.MONEDA_PAIS_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_pais_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(es_fact_electronicaColumnIndex))
						record.ES_FACT_ELECTRONICA = Convert.ToString(reader.GetValue(es_fact_electronicaColumnIndex));
					if(!reader.IsDBNull(tipo_movimiento_setColumnIndex))
						record.TIPO_MOVIMIENTO_SET = Convert.ToString(reader.GetValue(tipo_movimiento_setColumnIndex));
					if(!reader.IsDBNull(ctb_tipo_comprobante_set_idColumnIndex))
						record.CTB_TIPO_COMPROBANTE_SET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_tipo_comprobante_set_idColumnIndex)), 9);
					if(!reader.IsDBNull(imputa_ivaColumnIndex))
						record.IMPUTA_IVA = Convert.ToString(reader.GetValue(imputa_ivaColumnIndex));
					if(!reader.IsDBNull(imputa_ireColumnIndex))
						record.IMPUTA_IRE = Convert.ToString(reader.GetValue(imputa_ireColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_PROVEEDORRow[])(recordList.ToArray(typeof(FACTURAS_PROVEEDORRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_PROVEEDORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_PROVEEDORRow"/> object.</returns>
		protected virtual FACTURAS_PROVEEDORRow MapRow(DataRow row)
		{
			FACTURAS_PROVEEDORRow mappedObject = new FACTURAS_PROVEEDORRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "STOCK_DEPOSITO_ID"
			dataColumn = dataTable.Columns["STOCK_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "TIPO_FACTURA_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_FACTURA_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FACTURA_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FECHA_FACTURA"
			dataColumn = dataTable.Columns["FECHA_FACTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FACTURA = (System.DateTime)row[dataColumn];
			// Column "FECHA_RECEPCION"
			dataColumn = dataTable.Columns["FECHA_RECEPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECEPCION = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NUMERO_CONTRATO"
			dataColumn = dataTable.Columns["NUMERO_CONTRATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CONTRATO = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "CTACTE_CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_ID"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_ID = (decimal)row[dataColumn];
			// Column "TIPO_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_CONTENEDORES"
			dataColumn = dataTable.Columns["CANTIDAD_CONTENEDORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CONTENEDORES = (decimal)row[dataColumn];
			// Column "TIPO_EMBARQUE_ID"
			dataColumn = dataTable.Columns["TIPO_EMBARQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMBARQUE_ID = (decimal)row[dataColumn];
			// Column "TOTAL_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_DESCUENTO"
			dataColumn = dataTable.Columns["TOTAL_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DESCUENTO = (decimal)row[dataColumn];
			// Column "TOTAL_IMPUESTO"
			dataColumn = dataTable.Columns["TOTAL_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPUESTO = (decimal)row[dataColumn];
			// Column "TOTAL_PAGO"
			dataColumn = dataTable.Columns["TOTAL_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_PAGO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "IMPORTACION_ID"
			dataColumn = dataTable.Columns["IMPORTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_ID = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "NRO_TIMBRADO"
			dataColumn = dataTable.Columns["NRO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TIMBRADO = (string)row[dataColumn];
			// Column "PAGAR_POR_FONDO_FIJO"
			dataColumn = dataTable.Columns["PAGAR_POR_FONDO_FIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGAR_POR_FONDO_FIJO = (string)row[dataColumn];
			// Column "AFECTA_CTACTE_PROVEEDOR"
			dataColumn = dataTable.Columns["AFECTA_CTACTE_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE_PROVEEDOR = (string)row[dataColumn];
			// Column "AFECTA_CTACTE_PERSONA"
			dataColumn = dataTable.Columns["AFECTA_CTACTE_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE_PERSONA = (string)row[dataColumn];
			// Column "AFECTA_CRED_FISCAL_EMPRESA"
			dataColumn = dataTable.Columns["AFECTA_CRED_FISCAL_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CRED_FISCAL_EMPRESA = (string)row[dataColumn];
			// Column "AFECTA_CRED_FISCAL_PERSONA"
			dataColumn = dataTable.Columns["AFECTA_CRED_FISCAL_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CRED_FISCAL_PERSONA = (string)row[dataColumn];
			// Column "PASIBLE_RETENCION"
			dataColumn = dataTable.Columns["PASIBLE_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASIBLE_RETENCION = (string)row[dataColumn];
			// Column "NRO_DOCUMENTO_EXTERNO"
			dataColumn = dataTable.Columns["NRO_DOCUMENTO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_DOCUMENTO_EXTERNO = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DESC_SOBRE_TOTAL"
			dataColumn = dataTable.Columns["PORCENTAJE_DESC_SOBRE_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESC_SOBRE_TOTAL = (decimal)row[dataColumn];
			// Column "ES_TICKET"
			dataColumn = dataTable.Columns["ES_TICKET"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TICKET = (string)row[dataColumn];
			// Column "PROVEEDOR_GASTO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_GASTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_GASTO_ID = (decimal)row[dataColumn];
			// Column "DIRECCION_LUGAR_TRANSACCION"
			dataColumn = dataTable.Columns["DIRECCION_LUGAR_TRANSACCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_LUGAR_TRANSACCION = (string)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_TIMBRADO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_TIMBRADO = (System.DateTime)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_AUTONUM_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_AUTONUM_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_AUTONUM_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_NRO_COMPR"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_NRO_COMPR"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_NRO_COMPR = (string)row[dataColumn];
			// Column "CENTRO_COSTO_OBLIGATORIO"
			dataColumn = dataTable.Columns["CENTRO_COSTO_OBLIGATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_OBLIGATORIO = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_FECHA"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_FECHA = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "APLICAR_PRORRATEO_SERVICIOS"
			dataColumn = dataTable.Columns["APLICAR_PRORRATEO_SERVICIOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICAR_PRORRATEO_SERVICIOS = (string)row[dataColumn];
			// Column "PAGO_CONTRATISTA_DETALLE_ID"
			dataColumn = dataTable.Columns["PAGO_CONTRATISTA_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGO_CONTRATISTA_DETALLE_ID = (decimal)row[dataColumn];
			// Column "MONEDA_PAIS_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_PAIS_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_PAIS_COTIZACION = (decimal)row[dataColumn];
			// Column "ES_FACT_ELECTRONICA"
			dataColumn = dataTable.Columns["ES_FACT_ELECTRONICA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_FACT_ELECTRONICA = (string)row[dataColumn];
			// Column "TIPO_MOVIMIENTO_SET"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO_SET"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO_SET = (string)row[dataColumn];
			// Column "CTB_TIPO_COMPROBANTE_SET_ID"
			dataColumn = dataTable.Columns["CTB_TIPO_COMPROBANTE_SET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_TIPO_COMPROBANTE_SET_ID = (decimal)row[dataColumn];
			// Column "IMPUTA_IVA"
			dataColumn = dataTable.Columns["IMPUTA_IVA"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUTA_IVA = (string)row[dataColumn];
			// Column "IMPUTA_IRE"
			dataColumn = dataTable.Columns["IMPUTA_IRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUTA_IRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_PROVEEDOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("STOCK_DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_FACTURA_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FACTURA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_RECEPCION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NUMERO_CONTRATO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CONDICION_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_CONTENEDORES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_EMBARQUE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_DESCUENTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_PAGO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("IMPORTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PAGAR_POR_FONDO_FIJO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_CRED_FISCAL_EMPRESA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_CRED_FISCAL_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PASIBLE_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_DOCUMENTO_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESC_SOBRE_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_TICKET", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_GASTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DIRECCION_LUGAR_TRANSACCION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_TIMBRADO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_AUTONUM_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_NRO_COMPR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_OBLIGATORIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APLICAR_PRORRATEO_SERVICIOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PAGO_CONTRATISTA_DETALLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_PAIS_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_FACT_ELECTRONICA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO_SET", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CTB_TIPO_COMPROBANTE_SET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPUTA_IVA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("IMPUTA_IRE", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "STOCK_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_FACTURA_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FACTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_RECEPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CONTRATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_DOCUMENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_CONTENEDORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_EMBARQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPORTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAGAR_POR_FONDO_FIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CTACTE_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CTACTE_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CRED_FISCAL_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CRED_FISCAL_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PASIBLE_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_DOCUMENTO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DESC_SOBRE_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_TICKET":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROVEEDOR_GASTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIRECCION_LUGAR_TRANSACCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VENCIMIENTO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_AUTONUM_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_NRO_COMPR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CENTRO_COSTO_OBLIGATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICAR_PRORRATEO_SERVICIOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PAGO_CONTRATISTA_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_PAIS_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_FACT_ELECTRONICA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_MOVIMIENTO_SET":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_TIPO_COMPROBANTE_SET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUTA_IVA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPUTA_IRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_PROVEEDORCollection_Base class
}  // End of namespace
