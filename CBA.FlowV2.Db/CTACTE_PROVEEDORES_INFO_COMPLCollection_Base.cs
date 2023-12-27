// <fileinfo name="CTACTE_PROVEEDORES_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PROVEEDORES_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PROVEEDORES_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PROVEEDORES_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PROVEEDOR_PERSONA_CODIGOColumnName = "PROVEEDOR_PERSONA_CODIGO";
		public const string PROVEEDOR_PERSONA_NOMBREColumnName = "PROVEEDOR_PERSONA_NOMBRE";
		public const string PROVEEDOR_NOMBREColumnName = "PROVEEDOR_NOMBRE";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ENTIDAD_IDColumnName = "CASO_ENTIDAD_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string CASO_NRO_COMPROBANTEColumnName = "CASO_NRO_COMPROBANTE";
		public const string FLUJO_DESCRIPCIONColumnName = "FLUJO_DESCRIPCION";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_VENCIMIENTO_TEXTOColumnName = "FECHA_VENCIMIENTO_TEXTO";
		public const string CASO_FECHA_FORMULARIOColumnName = "CASO_FECHA_FORMULARIO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string MONEDA_CANTIDAD_DECIMALESColumnName = "MONEDA_CANTIDAD_DECIMALES";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_CONCEPTO_IDColumnName = "CTACTE_CONCEPTO_ID";
		public const string CTACTE_CONCEPTO_DESCRIPCIONColumnName = "CTACTE_CONCEPTO_DESCRIPCION";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_VALOR_NOMBREColumnName = "CTACTE_VALOR_NOMBRE";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string MOVIMIENTO_VARIO_TESORERIA_IDColumnName = "MOVIMIENTO_VARIO_TESORERIA_ID";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string CTACTE_PAGARE_DET_IDColumnName = "CTACTE_PAGARE_DET_ID";
		public const string NC_APLICACION_IDColumnName = "NC_APLICACION_ID";
		public const string NC_APLICACION_DET_IDColumnName = "NC_APLICACION_DET_ID";
		public const string ORDEN_PAGO_VALOR_IDColumnName = "ORDEN_PAGO_VALOR_ID";
		public const string CALENDARIO_PAGOS_FC_PROV_IDColumnName = "CALENDARIO_PAGOS_FC_PROV_ID";
		public const string CREDITO_PROVEEDOR_DET_IDColumnName = "CREDITO_PROVEEDOR_DET_ID";
		public const string CREDITOColumnName = "CREDITO";
		public const string DEBITOColumnName = "DEBITO";
		public const string SALDO_CREDITOColumnName = "SALDO_CREDITO";
		public const string CONCEPTOColumnName = "CONCEPTO";
		public const string CTACTE_PROVEEDOR_RELAC_IDColumnName = "CTACTE_PROVEEDOR_RELAC_ID";
		public const string RETENCION_APLICADAColumnName = "RETENCION_APLICADA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string FC_PROV_PAGAR_POR_FONDO_FIJOColumnName = "FC_PROV_PAGAR_POR_FONDO_FIJO";
		public const string FC_PROV_CTACTE_FONDO_FIJO_IDColumnName = "FC_PROV_CTACTE_FONDO_FIJO_ID";
		public const string FC_PROV_FECHA_EMISIONColumnName = "FC_PROV_FECHA_EMISION";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PROVEEDORES_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PROVEEDORES_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PROVEEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORES_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PROVEEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PROVEEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PROVEEDORES_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PROVEEDORES_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects.</returns>
		public CTACTE_PROVEEDORES_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORES_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PROVEEDORES_INFO_COMPL";
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects.</returns>
		protected CTACTE_PROVEEDORES_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects.</returns>
		protected CTACTE_PROVEEDORES_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> objects.</returns>
		protected virtual CTACTE_PROVEEDORES_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int proveedor_persona_codigoColumnIndex = reader.GetOrdinal("PROVEEDOR_PERSONA_CODIGO");
			int proveedor_persona_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_PERSONA_NOMBRE");
			int proveedor_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_NOMBRE");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_entidad_idColumnIndex = reader.GetOrdinal("CASO_ENTIDAD_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int caso_nro_comprobanteColumnIndex = reader.GetOrdinal("CASO_NRO_COMPROBANTE");
			int flujo_descripcionColumnIndex = reader.GetOrdinal("FLUJO_DESCRIPCION");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_vencimiento_textoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_TEXTO");
			int caso_fecha_formularioColumnIndex = reader.GetOrdinal("CASO_FECHA_FORMULARIO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int moneda_cantidad_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDAD_DECIMALES");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_concepto_idColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_ID");
			int ctacte_concepto_descripcionColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_DESCRIPCION");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_valor_nombreColumnIndex = reader.GetOrdinal("CTACTE_VALOR_NOMBRE");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int movimiento_vario_tesoreria_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_VARIO_TESORERIA_ID");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int ctacte_pagare_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_DET_ID");
			int nc_aplicacion_idColumnIndex = reader.GetOrdinal("NC_APLICACION_ID");
			int nc_aplicacion_det_idColumnIndex = reader.GetOrdinal("NC_APLICACION_DET_ID");
			int orden_pago_valor_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_VALOR_ID");
			int calendario_pagos_fc_prov_idColumnIndex = reader.GetOrdinal("CALENDARIO_PAGOS_FC_PROV_ID");
			int credito_proveedor_det_idColumnIndex = reader.GetOrdinal("CREDITO_PROVEEDOR_DET_ID");
			int creditoColumnIndex = reader.GetOrdinal("CREDITO");
			int debitoColumnIndex = reader.GetOrdinal("DEBITO");
			int saldo_creditoColumnIndex = reader.GetOrdinal("SALDO_CREDITO");
			int conceptoColumnIndex = reader.GetOrdinal("CONCEPTO");
			int ctacte_proveedor_relac_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_RELAC_ID");
			int retencion_aplicadaColumnIndex = reader.GetOrdinal("RETENCION_APLICADA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int fc_prov_pagar_por_fondo_fijoColumnIndex = reader.GetOrdinal("FC_PROV_PAGAR_POR_FONDO_FIJO");
			int fc_prov_ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("FC_PROV_CTACTE_FONDO_FIJO_ID");
			int fc_prov_fecha_emisionColumnIndex = reader.GetOrdinal("FC_PROV_FECHA_EMISION");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PROVEEDORES_INFO_COMPLRow record = new CTACTE_PROVEEDORES_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_persona_codigoColumnIndex))
						record.PROVEEDOR_PERSONA_CODIGO = Convert.ToString(reader.GetValue(proveedor_persona_codigoColumnIndex));
					if(!reader.IsDBNull(proveedor_persona_nombreColumnIndex))
						record.PROVEEDOR_PERSONA_NOMBRE = Convert.ToString(reader.GetValue(proveedor_persona_nombreColumnIndex));
					if(!reader.IsDBNull(proveedor_nombreColumnIndex))
						record.PROVEEDOR_NOMBRE = Convert.ToString(reader.GetValue(proveedor_nombreColumnIndex));
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_entidad_idColumnIndex))
						record.CASO_ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_nro_comprobanteColumnIndex))
						record.CASO_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(caso_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(flujo_descripcionColumnIndex))
						record.FLUJO_DESCRIPCION = Convert.ToString(reader.GetValue(flujo_descripcionColumnIndex));
					if(!reader.IsDBNull(caso_estado_idColumnIndex))
						record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_vencimiento_textoColumnIndex))
						record.FECHA_VENCIMIENTO_TEXTO = Convert.ToString(reader.GetValue(fecha_vencimiento_textoColumnIndex));
					if(!reader.IsDBNull(caso_fecha_formularioColumnIndex))
						record.CASO_FECHA_FORMULARIO = Convert.ToDateTime(reader.GetValue(caso_fecha_formularioColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					record.MONEDA_CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidad_decimalesColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_CONCEPTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_concepto_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_concepto_descripcionColumnIndex))
						record.CTACTE_CONCEPTO_DESCRIPCION = Convert.ToString(reader.GetValue(ctacte_concepto_descripcionColumnIndex));
					if(!reader.IsDBNull(ctacte_valor_idColumnIndex))
						record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_valor_nombreColumnIndex))
						record.CTACTE_VALOR_NOMBRE = Convert.ToString(reader.GetValue(ctacte_valor_nombreColumnIndex));
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_vario_tesoreria_idColumnIndex))
						record.MOVIMIENTO_VARIO_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_vario_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_idColumnIndex))
						record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pagare_det_idColumnIndex))
						record.CTACTE_PAGARE_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_aplicacion_idColumnIndex))
						record.NC_APLICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_aplicacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_aplicacion_det_idColumnIndex))
						record.NC_APLICACION_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_aplicacion_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_valor_idColumnIndex))
						record.ORDEN_PAGO_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(calendario_pagos_fc_prov_idColumnIndex))
						record.CALENDARIO_PAGOS_FC_PROV_ID = Math.Round(Convert.ToDecimal(reader.GetValue(calendario_pagos_fc_prov_idColumnIndex)), 9);
					if(!reader.IsDBNull(credito_proveedor_det_idColumnIndex))
						record.CREDITO_PROVEEDOR_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(credito_proveedor_det_idColumnIndex)), 9);
					record.CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(creditoColumnIndex)), 9);
					record.DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(debitoColumnIndex)), 9);
					if(!reader.IsDBNull(saldo_creditoColumnIndex))
						record.SALDO_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(conceptoColumnIndex))
						record.CONCEPTO = Convert.ToString(reader.GetValue(conceptoColumnIndex));
					if(!reader.IsDBNull(ctacte_proveedor_relac_idColumnIndex))
						record.CTACTE_PROVEEDOR_RELAC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_relac_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_aplicadaColumnIndex))
						record.RETENCION_APLICADA = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_aplicadaColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(fc_prov_pagar_por_fondo_fijoColumnIndex))
						record.FC_PROV_PAGAR_POR_FONDO_FIJO = Convert.ToString(reader.GetValue(fc_prov_pagar_por_fondo_fijoColumnIndex));
					if(!reader.IsDBNull(fc_prov_ctacte_fondo_fijo_idColumnIndex))
						record.FC_PROV_CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_prov_ctacte_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_prov_fecha_emisionColumnIndex))
						record.FC_PROV_FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fc_prov_fecha_emisionColumnIndex));
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PROVEEDORES_INFO_COMPLRow[])(recordList.ToArray(typeof(CTACTE_PROVEEDORES_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PROVEEDORES_INFO_COMPLRow"/> object.</returns>
		protected virtual CTACTE_PROVEEDORES_INFO_COMPLRow MapRow(DataRow row)
		{
			CTACTE_PROVEEDORES_INFO_COMPLRow mappedObject = new CTACTE_PROVEEDORES_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PROVEEDOR_PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PROVEEDOR_PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PROVEEDOR_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_NOMBRE = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_ENTIDAD_ID"
			dataColumn = dataTable.Columns["CASO_ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "CASO_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["CASO_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FLUJO_DESCRIPCION"
			dataColumn = dataTable.Columns["FLUJO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_DESCRIPCION = (string)row[dataColumn];
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_TEXTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_TEXTO = (string)row[dataColumn];
			// Column "CASO_FECHA_FORMULARIO"
			dataColumn = dataTable.Columns["CASO_FECHA_FORMULARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FECHA_FORMULARIO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "MONEDA_CANTIDAD_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDAD_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDAD_DECIMALES = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "CTACTE_CONCEPTO_ID"
			dataColumn = dataTable.Columns["CTACTE_CONCEPTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONCEPTO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CONCEPTO_DESCRIPCION"
			dataColumn = dataTable.Columns["CTACTE_CONCEPTO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONCEPTO_DESCRIPCION = (string)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_VALOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_NOMBRE = (string)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_VARIO_TESORERIA_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_VARIO_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_VARIO_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGARE_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_DET_ID = (decimal)row[dataColumn];
			// Column "NC_APLICACION_ID"
			dataColumn = dataTable.Columns["NC_APLICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_APLICACION_ID = (decimal)row[dataColumn];
			// Column "NC_APLICACION_DET_ID"
			dataColumn = dataTable.Columns["NC_APLICACION_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_APLICACION_DET_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_VALOR_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_VALOR_ID = (decimal)row[dataColumn];
			// Column "CALENDARIO_PAGOS_FC_PROV_ID"
			dataColumn = dataTable.Columns["CALENDARIO_PAGOS_FC_PROV_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALENDARIO_PAGOS_FC_PROV_ID = (decimal)row[dataColumn];
			// Column "CREDITO_PROVEEDOR_DET_ID"
			dataColumn = dataTable.Columns["CREDITO_PROVEEDOR_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO_PROVEEDOR_DET_ID = (decimal)row[dataColumn];
			// Column "CREDITO"
			dataColumn = dataTable.Columns["CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO = (decimal)row[dataColumn];
			// Column "DEBITO"
			dataColumn = dataTable.Columns["DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO = (decimal)row[dataColumn];
			// Column "SALDO_CREDITO"
			dataColumn = dataTable.Columns["SALDO_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_CREDITO = (decimal)row[dataColumn];
			// Column "CONCEPTO"
			dataColumn = dataTable.Columns["CONCEPTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCEPTO = (string)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_RELAC_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_RELAC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_RELAC_ID = (decimal)row[dataColumn];
			// Column "RETENCION_APLICADA"
			dataColumn = dataTable.Columns["RETENCION_APLICADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_APLICADA = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "FC_PROV_PAGAR_POR_FONDO_FIJO"
			dataColumn = dataTable.Columns["FC_PROV_PAGAR_POR_FONDO_FIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_PROV_PAGAR_POR_FONDO_FIJO = (string)row[dataColumn];
			// Column "FC_PROV_CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["FC_PROV_CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_PROV_CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "FC_PROV_FECHA_EMISION"
			dataColumn = dataTable.Columns["FC_PROV_FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_PROV_FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PROVEEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PROVEEDORES_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ENTIDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_TEXTO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_FECHA_FORMULARIO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDAD_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CONCEPTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CONCEPTO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_VARIO_TESORERIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NC_APLICACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NC_APLICACION_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_VALOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALENDARIO_PAGOS_FC_PROV_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREDITO_PROVEEDOR_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEBITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO_CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONCEPTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_RELAC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_APLICADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 256;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_PROV_PAGAR_POR_FONDO_FIJO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_PROV_CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_PROV_FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
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

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FLUJO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_FECHA_FORMULARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CANTIDAD_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONCEPTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONCEPTO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_VARIO_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGARE_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_APLICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_APLICACION_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALENDARIO_PAGOS_FC_PROV_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO_PROVEEDOR_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONCEPTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PROVEEDOR_RELAC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_APLICADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FC_PROV_PAGAR_POR_FONDO_FIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FC_PROV_CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_PROV_FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PROVEEDORES_INFO_COMPLCollection_Base class
}  // End of namespace
