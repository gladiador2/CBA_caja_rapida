// <fileinfo name="CTACTE_PERSONAS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PERSONAS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PERSONAS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PERSONAS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_REGION_IDColumnName = "SUCURSAL_REGION_ID";
		public const string SUCURSAL_REGION_NOMBREColumnName = "SUCURSAL_REGION_NOMBRE";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string PERSONA_COBRADOR_HABITUALColumnName = "PERSONA_COBRADOR_HABITUAL";
		public const string PERSONA_TELEFONO1ColumnName = "PERSONA_TELEFONO1";
		public const string PERSONA_TELEFONO2ColumnName = "PERSONA_TELEFONO2";
		public const string PERSONA_TELEFONO3ColumnName = "PERSONA_TELEFONO3";
		public const string PERSONA_TELEFONO4ColumnName = "PERSONA_TELEFONO4";
		public const string PERSONA_EMAIL1ColumnName = "PERSONA_EMAIL1";
		public const string PERSONA_EMAIL2ColumnName = "PERSONA_EMAIL2";
		public const string PERSONA_EMAIL3ColumnName = "PERSONA_EMAIL3";
		public const string PERSONA_NUMERO_DOCUMENTOColumnName = "PERSONA_NUMERO_DOCUMENTO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string CASO_NRO_COMPROBANTEColumnName = "CASO_NRO_COMPROBANTE";
		public const string CASO_NRO_COMPROBANTE2ColumnName = "CASO_NRO_COMPROBANTE2";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string FLUJO_NOMBREColumnName = "FLUJO_NOMBRE";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_POSTERGACIONColumnName = "FECHA_POSTERGACION";
		public const string FECHA_VENCIMIENTO_TEXTOColumnName = "FECHA_VENCIMIENTO_TEXTO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CANTIDAD_DECIMALESColumnName = "MONEDA_CANTIDAD_DECIMALES";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_CONCEPTO_IDColumnName = "CTACTE_CONCEPTO_ID";
		public const string CTACTE_CONCEPTO_DESCRIPCIONColumnName = "CTACTE_CONCEPTO_DESCRIPCION";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_VALOR_NOMBREColumnName = "CTACTE_VALOR_NOMBRE";
		public const string CTACTE_PAGARE_DOC_IDColumnName = "CTACTE_PAGARE_DOC_ID";
		public const string CTACTE_PAGARE_DET_IDColumnName = "CTACTE_PAGARE_DET_ID";
		public const string CALENDARIO_PAGOS_FC_CLI_IDColumnName = "CALENDARIO_PAGOS_FC_CLI_ID";
		public const string CALENDARIO_PAGOS_CR_CLI_IDColumnName = "CALENDARIO_PAGOS_CR_CLI_ID";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string CREDITOColumnName = "CREDITO";
		public const string DEBITOColumnName = "DEBITO";
		public const string SALDO_DEBITOColumnName = "SALDO_DEBITO";
		public const string MONTO_EN_PROCESOColumnName = "MONTO_EN_PROCESO";
		public const string CONCEPTOColumnName = "CONCEPTO";
		public const string CTACTE_PERSONA_RELACIONADA_IDColumnName = "CTACTE_PERSONA_RELACIONADA_ID";
		public const string CTACTE_PAGO_PERSONA_DET_IDColumnName = "CTACTE_PAGO_PERSONA_DET_ID";
		public const string CTACTE_PAGO_PERSONA_DOC_IDColumnName = "CTACTE_PAGO_PERSONA_DOC_ID";
		public const string CTACTE_PAGO_PERSONA_REC_IDColumnName = "CTACTE_PAGO_PERSONA_REC_ID";
		public const string APLICACION_DOCUMENTOS_IDColumnName = "APLICACION_DOCUMENTOS_ID";
		public const string APLICACION_DOCUMENTOS_VAL_IDColumnName = "APLICACION_DOCUMENTOS_VAL_ID";
		public const string APLICACION_DOCUMENTOS_REC_IDColumnName = "APLICACION_DOCUMENTOS_REC_ID";
		public const string CTACTE_DOCUMENTO_VENC_IDColumnName = "CTACTE_DOCUMENTO_VENC_ID";
		public const string JUDICIALColumnName = "JUDICIAL";
		public const string BLOQUEADOColumnName = "BLOQUEADO";
		public const string CUOTA_NUMEROColumnName = "CUOTA_NUMERO";
		public const string CUOTA_TOTALColumnName = "CUOTA_TOTAL";
		public const string CUOTAColumnName = "CUOTA";
		public const string FECHA_ULTIMO_PAGOColumnName = "FECHA_ULTIMO_PAGO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string FACTURA_CLIENTE_TIPOColumnName = "FACTURA_CLIENTE_TIPO";
		public const string FACTURA_CLIENTE_FECHA_EMISIONColumnName = "FACTURA_CLIENTE_FECHA_EMISION";
		public const string FACTURA_CLIENTE_VENDEDOR_NOMBRColumnName = "FACTURA_CLIENTE_VENDEDOR_NOMBR";
		public const string FACTURA_CLIENTE_VENDEDOR_CODColumnName = "FACTURA_CLIENTE_VENDEDOR_COD";
		public const string FACTURA_CLIENTE_VENDEDOR_IDColumnName = "FACTURA_CLIENTE_VENDEDOR_ID";
		public const string JUEGO_PAGARES_APROBADOColumnName = "JUEGO_PAGARES_APROBADO";
		public const string CTACTE_PAGARE_IDColumnName = "CTACTE_PAGARE_ID";
		public const string RETENCION_APLICADAColumnName = "RETENCION_APLICADA";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PERSONAS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PERSONAS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_PERSONAS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PERSONAS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PERSONAS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		public CTACTE_PERSONAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_PERSONAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PERSONAS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_PERSONAS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_PERSONAS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTACTE_PERSONAS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_region_idColumnIndex = reader.GetOrdinal("SUCURSAL_REGION_ID");
			int sucursal_region_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_REGION_NOMBRE");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int persona_cobrador_habitualColumnIndex = reader.GetOrdinal("PERSONA_COBRADOR_HABITUAL");
			int persona_telefono1ColumnIndex = reader.GetOrdinal("PERSONA_TELEFONO1");
			int persona_telefono2ColumnIndex = reader.GetOrdinal("PERSONA_TELEFONO2");
			int persona_telefono3ColumnIndex = reader.GetOrdinal("PERSONA_TELEFONO3");
			int persona_telefono4ColumnIndex = reader.GetOrdinal("PERSONA_TELEFONO4");
			int persona_email1ColumnIndex = reader.GetOrdinal("PERSONA_EMAIL1");
			int persona_email2ColumnIndex = reader.GetOrdinal("PERSONA_EMAIL2");
			int persona_email3ColumnIndex = reader.GetOrdinal("PERSONA_EMAIL3");
			int persona_numero_documentoColumnIndex = reader.GetOrdinal("PERSONA_NUMERO_DOCUMENTO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int caso_nro_comprobanteColumnIndex = reader.GetOrdinal("CASO_NRO_COMPROBANTE");
			int caso_nro_comprobante2ColumnIndex = reader.GetOrdinal("CASO_NRO_COMPROBANTE2");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int flujo_nombreColumnIndex = reader.GetOrdinal("FLUJO_NOMBRE");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_postergacionColumnIndex = reader.GetOrdinal("FECHA_POSTERGACION");
			int fecha_vencimiento_textoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_TEXTO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cantidad_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDAD_DECIMALES");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_concepto_idColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_ID");
			int ctacte_concepto_descripcionColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_DESCRIPCION");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_valor_nombreColumnIndex = reader.GetOrdinal("CTACTE_VALOR_NOMBRE");
			int ctacte_pagare_doc_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_DOC_ID");
			int ctacte_pagare_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_DET_ID");
			int calendario_pagos_fc_cli_idColumnIndex = reader.GetOrdinal("CALENDARIO_PAGOS_FC_CLI_ID");
			int calendario_pagos_cr_cli_idColumnIndex = reader.GetOrdinal("CALENDARIO_PAGOS_CR_CLI_ID");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int creditoColumnIndex = reader.GetOrdinal("CREDITO");
			int debitoColumnIndex = reader.GetOrdinal("DEBITO");
			int saldo_debitoColumnIndex = reader.GetOrdinal("SALDO_DEBITO");
			int monto_en_procesoColumnIndex = reader.GetOrdinal("MONTO_EN_PROCESO");
			int conceptoColumnIndex = reader.GetOrdinal("CONCEPTO");
			int ctacte_persona_relacionada_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_RELACIONADA_ID");
			int ctacte_pago_persona_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DET_ID");
			int ctacte_pago_persona_doc_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DOC_ID");
			int ctacte_pago_persona_rec_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_REC_ID");
			int aplicacion_documentos_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTOS_ID");
			int aplicacion_documentos_val_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTOS_VAL_ID");
			int aplicacion_documentos_rec_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTOS_REC_ID");
			int ctacte_documento_venc_idColumnIndex = reader.GetOrdinal("CTACTE_DOCUMENTO_VENC_ID");
			int judicialColumnIndex = reader.GetOrdinal("JUDICIAL");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");
			int cuota_numeroColumnIndex = reader.GetOrdinal("CUOTA_NUMERO");
			int cuota_totalColumnIndex = reader.GetOrdinal("CUOTA_TOTAL");
			int cuotaColumnIndex = reader.GetOrdinal("CUOTA");
			int fecha_ultimo_pagoColumnIndex = reader.GetOrdinal("FECHA_ULTIMO_PAGO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int factura_cliente_tipoColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_TIPO");
			int factura_cliente_fecha_emisionColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_FECHA_EMISION");
			int factura_cliente_vendedor_nombrColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_VENDEDOR_NOMBR");
			int factura_cliente_vendedor_codColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_VENDEDOR_COD");
			int factura_cliente_vendedor_idColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_VENDEDOR_ID");
			int juego_pagares_aprobadoColumnIndex = reader.GetOrdinal("JUEGO_PAGARES_APROBADO");
			int ctacte_pagare_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_ID");
			int retencion_aplicadaColumnIndex = reader.GetOrdinal("RETENCION_APLICADA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PERSONAS_INFO_COMPLETARow record = new CTACTE_PERSONAS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_region_idColumnIndex))
						record.SUCURSAL_REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_region_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_region_nombreColumnIndex))
						record.SUCURSAL_REGION_NOMBRE = Convert.ToString(reader.GetValue(sucursal_region_nombreColumnIndex));
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					if(!reader.IsDBNull(persona_cobrador_habitualColumnIndex))
						record.PERSONA_COBRADOR_HABITUAL = Math.Round(Convert.ToDecimal(reader.GetValue(persona_cobrador_habitualColumnIndex)), 9);
					if(!reader.IsDBNull(persona_telefono1ColumnIndex))
						record.PERSONA_TELEFONO1 = Convert.ToString(reader.GetValue(persona_telefono1ColumnIndex));
					if(!reader.IsDBNull(persona_telefono2ColumnIndex))
						record.PERSONA_TELEFONO2 = Convert.ToString(reader.GetValue(persona_telefono2ColumnIndex));
					if(!reader.IsDBNull(persona_telefono3ColumnIndex))
						record.PERSONA_TELEFONO3 = Convert.ToString(reader.GetValue(persona_telefono3ColumnIndex));
					if(!reader.IsDBNull(persona_telefono4ColumnIndex))
						record.PERSONA_TELEFONO4 = Convert.ToString(reader.GetValue(persona_telefono4ColumnIndex));
					if(!reader.IsDBNull(persona_email1ColumnIndex))
						record.PERSONA_EMAIL1 = Convert.ToString(reader.GetValue(persona_email1ColumnIndex));
					if(!reader.IsDBNull(persona_email2ColumnIndex))
						record.PERSONA_EMAIL2 = Convert.ToString(reader.GetValue(persona_email2ColumnIndex));
					if(!reader.IsDBNull(persona_email3ColumnIndex))
						record.PERSONA_EMAIL3 = Convert.ToString(reader.GetValue(persona_email3ColumnIndex));
					if(!reader.IsDBNull(persona_numero_documentoColumnIndex))
						record.PERSONA_NUMERO_DOCUMENTO = Convert.ToString(reader.GetValue(persona_numero_documentoColumnIndex));
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_estado_idColumnIndex))
						record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					if(!reader.IsDBNull(caso_nro_comprobanteColumnIndex))
						record.CASO_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(caso_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(caso_nro_comprobante2ColumnIndex))
						record.CASO_NRO_COMPROBANTE2 = Convert.ToString(reader.GetValue(caso_nro_comprobante2ColumnIndex));
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_nombreColumnIndex))
						record.FLUJO_NOMBRE = Convert.ToString(reader.GetValue(flujo_nombreColumnIndex));
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					if(!reader.IsDBNull(fecha_vencimientoColumnIndex))
						record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_postergacionColumnIndex))
						record.FECHA_POSTERGACION = Convert.ToDateTime(reader.GetValue(fecha_postergacionColumnIndex));
					if(!reader.IsDBNull(fecha_vencimiento_textoColumnIndex))
						record.FECHA_VENCIMIENTO_TEXTO = Convert.ToString(reader.GetValue(fecha_vencimiento_textoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.MONEDA_CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidad_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_CONCEPTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_concepto_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_concepto_descripcionColumnIndex))
						record.CTACTE_CONCEPTO_DESCRIPCION = Convert.ToString(reader.GetValue(ctacte_concepto_descripcionColumnIndex));
					if(!reader.IsDBNull(ctacte_valor_idColumnIndex))
						record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_valor_nombreColumnIndex))
						record.CTACTE_VALOR_NOMBRE = Convert.ToString(reader.GetValue(ctacte_valor_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_pagare_doc_idColumnIndex))
						record.CTACTE_PAGARE_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_doc_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pagare_det_idColumnIndex))
						record.CTACTE_PAGARE_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(calendario_pagos_fc_cli_idColumnIndex))
						record.CALENDARIO_PAGOS_FC_CLI_ID = Math.Round(Convert.ToDecimal(reader.GetValue(calendario_pagos_fc_cli_idColumnIndex)), 9);
					if(!reader.IsDBNull(calendario_pagos_cr_cli_idColumnIndex))
						record.CALENDARIO_PAGOS_CR_CLI_ID = Math.Round(Convert.ToDecimal(reader.GetValue(calendario_pagos_cr_cli_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					record.CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(creditoColumnIndex)), 9);
					record.DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(debitoColumnIndex)), 9);
					if(!reader.IsDBNull(saldo_debitoColumnIndex))
						record.SALDO_DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_debitoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_en_procesoColumnIndex))
						record.MONTO_EN_PROCESO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_en_procesoColumnIndex)), 9);
					if(!reader.IsDBNull(conceptoColumnIndex))
						record.CONCEPTO = Convert.ToString(reader.GetValue(conceptoColumnIndex));
					if(!reader.IsDBNull(ctacte_persona_relacionada_idColumnIndex))
						record.CTACTE_PERSONA_RELACIONADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_relacionada_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_det_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_doc_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_doc_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_rec_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_REC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_rec_idColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_documentos_idColumnIndex))
						record.APLICACION_DOCUMENTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documentos_idColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_documentos_val_idColumnIndex))
						record.APLICACION_DOCUMENTOS_VAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documentos_val_idColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_documentos_rec_idColumnIndex))
						record.APLICACION_DOCUMENTOS_REC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documentos_rec_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_documento_venc_idColumnIndex))
						record.CTACTE_DOCUMENTO_VENC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_documento_venc_idColumnIndex)), 9);
					record.JUDICIAL = Convert.ToString(reader.GetValue(judicialColumnIndex));
					record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));
					if(!reader.IsDBNull(cuota_numeroColumnIndex))
						record.CUOTA_NUMERO = Math.Round(Convert.ToDecimal(reader.GetValue(cuota_numeroColumnIndex)), 9);
					if(!reader.IsDBNull(cuota_totalColumnIndex))
						record.CUOTA_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cuota_totalColumnIndex)), 9);
					if(!reader.IsDBNull(cuotaColumnIndex))
						record.CUOTA = Convert.ToString(reader.GetValue(cuotaColumnIndex));
					if(!reader.IsDBNull(fecha_ultimo_pagoColumnIndex))
						record.FECHA_ULTIMO_PAGO = Convert.ToDateTime(reader.GetValue(fecha_ultimo_pagoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(factura_cliente_tipoColumnIndex))
						record.FACTURA_CLIENTE_TIPO = Convert.ToString(reader.GetValue(factura_cliente_tipoColumnIndex));
					if(!reader.IsDBNull(factura_cliente_fecha_emisionColumnIndex))
						record.FACTURA_CLIENTE_FECHA_EMISION = Convert.ToDateTime(reader.GetValue(factura_cliente_fecha_emisionColumnIndex));
					if(!reader.IsDBNull(factura_cliente_vendedor_nombrColumnIndex))
						record.FACTURA_CLIENTE_VENDEDOR_NOMBR = Convert.ToString(reader.GetValue(factura_cliente_vendedor_nombrColumnIndex));
					if(!reader.IsDBNull(factura_cliente_vendedor_codColumnIndex))
						record.FACTURA_CLIENTE_VENDEDOR_COD = Convert.ToString(reader.GetValue(factura_cliente_vendedor_codColumnIndex));
					if(!reader.IsDBNull(factura_cliente_vendedor_idColumnIndex))
						record.FACTURA_CLIENTE_VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_cliente_vendedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(juego_pagares_aprobadoColumnIndex))
						record.JUEGO_PAGARES_APROBADO = Convert.ToString(reader.GetValue(juego_pagares_aprobadoColumnIndex));
					if(!reader.IsDBNull(ctacte_pagare_idColumnIndex))
						record.CTACTE_PAGARE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_aplicadaColumnIndex))
						record.RETENCION_APLICADA = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_aplicadaColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PERSONAS_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTACTE_PERSONAS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PERSONAS_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTACTE_PERSONAS_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTACTE_PERSONAS_INFO_COMPLETARow mappedObject = new CTACTE_PERSONAS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_REGION_ID"
			dataColumn = dataTable.Columns["SUCURSAL_REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_REGION_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_REGION_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_REGION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_REGION_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "PERSONA_COBRADOR_HABITUAL"
			dataColumn = dataTable.Columns["PERSONA_COBRADOR_HABITUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_COBRADOR_HABITUAL = (decimal)row[dataColumn];
			// Column "PERSONA_TELEFONO1"
			dataColumn = dataTable.Columns["PERSONA_TELEFONO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_TELEFONO1 = (string)row[dataColumn];
			// Column "PERSONA_TELEFONO2"
			dataColumn = dataTable.Columns["PERSONA_TELEFONO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_TELEFONO2 = (string)row[dataColumn];
			// Column "PERSONA_TELEFONO3"
			dataColumn = dataTable.Columns["PERSONA_TELEFONO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_TELEFONO3 = (string)row[dataColumn];
			// Column "PERSONA_TELEFONO4"
			dataColumn = dataTable.Columns["PERSONA_TELEFONO4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_TELEFONO4 = (string)row[dataColumn];
			// Column "PERSONA_EMAIL1"
			dataColumn = dataTable.Columns["PERSONA_EMAIL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_EMAIL1 = (string)row[dataColumn];
			// Column "PERSONA_EMAIL2"
			dataColumn = dataTable.Columns["PERSONA_EMAIL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_EMAIL2 = (string)row[dataColumn];
			// Column "PERSONA_EMAIL3"
			dataColumn = dataTable.Columns["PERSONA_EMAIL3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_EMAIL3 = (string)row[dataColumn];
			// Column "PERSONA_NUMERO_DOCUMENTO"
			dataColumn = dataTable.Columns["PERSONA_NUMERO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NUMERO_DOCUMENTO = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "CASO_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["CASO_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CASO_NRO_COMPROBANTE2"
			dataColumn = dataTable.Columns["CASO_NRO_COMPROBANTE2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_NRO_COMPROBANTE2 = (string)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_NOMBRE"
			dataColumn = dataTable.Columns["FLUJO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_POSTERGACION"
			dataColumn = dataTable.Columns["FECHA_POSTERGACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSTERGACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_TEXTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_TEXTO = (string)row[dataColumn];
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
			// Column "MONEDA_CANTIDAD_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDAD_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDAD_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
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
			// Column "CTACTE_PAGARE_DOC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_DOC_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGARE_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_DET_ID = (decimal)row[dataColumn];
			// Column "CALENDARIO_PAGOS_FC_CLI_ID"
			dataColumn = dataTable.Columns["CALENDARIO_PAGOS_FC_CLI_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALENDARIO_PAGOS_FC_CLI_ID = (decimal)row[dataColumn];
			// Column "CALENDARIO_PAGOS_CR_CLI_ID"
			dataColumn = dataTable.Columns["CALENDARIO_PAGOS_CR_CLI_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALENDARIO_PAGOS_CR_CLI_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "CREDITO"
			dataColumn = dataTable.Columns["CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO = (decimal)row[dataColumn];
			// Column "DEBITO"
			dataColumn = dataTable.Columns["DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO = (decimal)row[dataColumn];
			// Column "SALDO_DEBITO"
			dataColumn = dataTable.Columns["SALDO_DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_DEBITO = (decimal)row[dataColumn];
			// Column "MONTO_EN_PROCESO"
			dataColumn = dataTable.Columns["MONTO_EN_PROCESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EN_PROCESO = (decimal)row[dataColumn];
			// Column "CONCEPTO"
			dataColumn = dataTable.Columns["CONCEPTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCEPTO = (string)row[dataColumn];
			// Column "CTACTE_PERSONA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_RELACIONADA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DET_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DOC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DOC_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_REC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_REC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_REC_ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTOS_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTOS_ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTOS_VAL_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTOS_VAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTOS_VAL_ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTOS_REC_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTOS_REC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTOS_REC_ID = (decimal)row[dataColumn];
			// Column "CTACTE_DOCUMENTO_VENC_ID"
			dataColumn = dataTable.Columns["CTACTE_DOCUMENTO_VENC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_DOCUMENTO_VENC_ID = (decimal)row[dataColumn];
			// Column "JUDICIAL"
			dataColumn = dataTable.Columns["JUDICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.JUDICIAL = (string)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			// Column "CUOTA_NUMERO"
			dataColumn = dataTable.Columns["CUOTA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA_NUMERO = (decimal)row[dataColumn];
			// Column "CUOTA_TOTAL"
			dataColumn = dataTable.Columns["CUOTA_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA_TOTAL = (decimal)row[dataColumn];
			// Column "CUOTA"
			dataColumn = dataTable.Columns["CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA = (string)row[dataColumn];
			// Column "FECHA_ULTIMO_PAGO"
			dataColumn = dataTable.Columns["FECHA_ULTIMO_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMO_PAGO = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "FACTURA_CLIENTE_TIPO"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_TIPO = (string)row[dataColumn];
			// Column "FACTURA_CLIENTE_FECHA_EMISION"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "FACTURA_CLIENTE_VENDEDOR_NOMBR"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_VENDEDOR_NOMBR"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_VENDEDOR_NOMBR = (string)row[dataColumn];
			// Column "FACTURA_CLIENTE_VENDEDOR_COD"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_VENDEDOR_COD"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_VENDEDOR_COD = (string)row[dataColumn];
			// Column "FACTURA_CLIENTE_VENDEDOR_ID"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "JUEGO_PAGARES_APROBADO"
			dataColumn = dataTable.Columns["JUEGO_PAGARES_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.JUEGO_PAGARES_APROBADO = (string)row[dataColumn];
			// Column "CTACTE_PAGARE_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_ID = (decimal)row[dataColumn];
			// Column "RETENCION_APLICADA"
			dataColumn = dataTable.Columns["RETENCION_APLICADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_APLICADA = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PERSONAS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_REGION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_REGION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_COBRADOR_HABITUAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_TELEFONO1", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_TELEFONO2", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_TELEFONO3", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_TELEFONO4", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_EMAIL1", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_EMAIL2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_EMAIL3", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NUMERO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_NRO_COMPROBANTE2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_POSTERGACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_TEXTO", typeof(string));
			dataColumn.MaxLength = 10;
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
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDAD_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
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
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_DOC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALENDARIO_PAGOS_FC_CLI_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALENDARIO_PAGOS_CR_CLI_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEBITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALDO_DEBITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_EN_PROCESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONCEPTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_RELACIONADA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DOC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_REC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTOS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTOS_VAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTOS_REC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_DOCUMENTO_VENC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("JUDICIAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUOTA_NUMERO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUOTA_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUOTA", typeof(string));
			dataColumn.MaxLength = 87;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMO_PAGO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 155;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_TIPO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_VENDEDOR_NOMBR", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_VENDEDOR_COD", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_VENDEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("JUEGO_PAGARES_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_APLICADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_REGION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_COBRADOR_HABITUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_TELEFONO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_TELEFONO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_TELEFONO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_TELEFONO4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_EMAIL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_EMAIL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_EMAIL3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NUMERO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_NRO_COMPROBANTE2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_POSTERGACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "MONEDA_CANTIDAD_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "CTACTE_PAGARE_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGARE_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALENDARIO_PAGOS_FC_CLI_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALENDARIO_PAGOS_CR_CLI_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_EN_PROCESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONCEPTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PERSONA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_REC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCUMENTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCUMENTOS_VAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCUMENTOS_REC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_DOCUMENTO_VENC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "JUDICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CUOTA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUOTA_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ULTIMO_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_CLIENTE_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_CLIENTE_FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_CLIENTE_VENDEDOR_NOMBR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_CLIENTE_VENDEDOR_COD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_CLIENTE_VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "JUEGO_PAGARES_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_PAGARE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_APLICADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PERSONAS_INFO_COMPLETACollection_Base class
}  // End of namespace
