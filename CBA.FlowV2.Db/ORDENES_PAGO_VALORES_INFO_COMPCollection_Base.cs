// <fileinfo name="ORDENES_PAGO_VALORES_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_VALORES_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_PAGO_VALORES_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_VALORES_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string ORDEN_PAGO_CASO_IDColumnName = "ORDEN_PAGO_CASO_ID";
		public const string ORDEN_PAGO_CASO_ESTADO_IDColumnName = "ORDEN_PAGO_CASO_ESTADO_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_VALOR_NOMBREColumnName = "CTACTE_VALOR_NOMBRE";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_ORIGEN_NOMBREColumnName = "MONEDA_ORIGEN_NOMBRE";
		public const string MONEDA_ORIGEN_SIMBOLOColumnName = "MONEDA_ORIGEN_SIMBOLO";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string COTIZACION_MONEDA_DESTINOColumnName = "COTIZACION_MONEDA_DESTINO";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string CG_CTACTE_BANCARIA_IDColumnName = "CG_CTACTE_BANCARIA_ID";
		public const string CG_CTACTE_BANCO_IDColumnName = "CG_CTACTE_BANCO_ID";
		public const string CG_CTACTE_BANCO_NOMBREColumnName = "CG_CTACTE_BANCO_NOMBRE";
		public const string CG_CTACTE_BANCO_ABREVIATURAColumnName = "CG_CTACTE_BANCO_ABREVIATURA";
		public const string CG_CTACTE_BANCARIA_NUMEROColumnName = "CG_CTACTE_BANCARIA_NUMERO";
		public const string CG_AUTONUMERACION_IDColumnName = "CG_AUTONUMERACION_ID";
		public const string CG_USAR_AUTONUMColumnName = "CG_USAR_AUTONUM";
		public const string CG_NUMERO_CHEQUEColumnName = "CG_NUMERO_CHEQUE";
		public const string CG_NOMBRE_EMISORColumnName = "CG_NOMBRE_EMISOR";
		public const string CG_NOMBRE_BENEFICIARIOColumnName = "CG_NOMBRE_BENEFICIARIO";
		public const string CG_NUMERO_CTA_BENEFICIARIOColumnName = "CG_NUMERO_CTA_BENEFICIARIO";
		public const string CG_ES_DIFERIDOColumnName = "CG_ES_DIFERIDO";
		public const string CG_FECHA_EMISIONColumnName = "CG_FECHA_EMISION";
		public const string CG_FECHA_VENCIMIENTOColumnName = "CG_FECHA_VENCIMIENTO";
		public const string CG_CTACTE_CHEQUE_GIRADO_IDColumnName = "CG_CTACTE_CHEQUE_GIRADO_ID";
		public const string CR_CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CR_CTACTE_CHEQUE_RECIBIDO_ID";
		public const string TC_CTACTE_TARJETA_CREDITO_IDColumnName = "TC_CTACTE_TARJETA_CREDITO_ID";
		public const string TC_CUPONColumnName = "TC_CUPON";
		public const string RETENCION_EMITIDA_IDColumnName = "RETENCION_EMITIDA_ID";
		public const string RETENCION_AUX_CASOSColumnName = "RETENCION_AUX_CASOS";
		public const string RETENCION_AUX_MONTOSColumnName = "RETENCION_AUX_MONTOS";
		public const string RETENCION_TIPO_IDColumnName = "RETENCION_TIPO_ID";
		public const string RETENCION_FECHAColumnName = "RETENCION_FECHA";
		public const string RETENCION_TIPO_NOMBREColumnName = "RETENCION_TIPO_NOMBRE";
		public const string RETENCION_EMITIDA_ESTADOColumnName = "RETENCION_EMITIDA_ESTADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TRANSFERENCIA_BANCARIA_IDColumnName = "TRANSFERENCIA_BANCARIA_ID";
		public const string ANTICIPO_PROVEEDOR_IDColumnName = "ANTICIPO_PROVEEDOR_ID";
		public const string NOTA_CREDITO_PROVEEDOR_IDColumnName = "NOTA_CREDITO_PROVEEDOR_ID";
		public const string AJUSTE_BANCARIO_IDColumnName = "AJUSTE_BANCARIO_ID";
		public const string AJUSTE_BANCARIO_CASO_IDColumnName = "AJUSTE_BANCARIO_CASO_ID";
		public const string AJUSTE_BANC_CTA_BANCARIA_IDColumnName = "AJUSTE_BANC_CTA_BANCARIA_ID";
		public const string AJUSTE_BANC_CUENTA_NROColumnName = "AJUSTE_BANC_CUENTA_NRO";
		public const string AJUSTE_BANC_BANCO_IDColumnName = "AJUSTE_BANC_BANCO_ID";
		public const string AJUSTE_BANC_BANCO_NOMBREColumnName = "AJUSTE_BANC_BANCO_NOMBRE";
		public const string DEBITO_AUTOM_CTACTE_BANC_IDColumnName = "DEBITO_AUTOM_CTACTE_BANC_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string CASO_RELACIONADO_IDColumnName = "CASO_RELACIONADO_ID";
		public const string RESUMENColumnName = "RESUMEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_VALORES_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_PAGO_VALORES_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_PAGO_VALORES_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORES_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_PAGO_VALORES_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_PAGO_VALORES_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_PAGO_VALORES_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_PAGO_VALORES_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects.</returns>
		public ORDENES_PAGO_VALORES_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORES_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_PAGO_VALORES_INFO_COMP";
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects.</returns>
		protected ORDENES_PAGO_VALORES_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects.</returns>
		protected ORDENES_PAGO_VALORES_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> objects.</returns>
		protected virtual ORDENES_PAGO_VALORES_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int orden_pago_caso_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_CASO_ID");
			int orden_pago_caso_estado_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_CASO_ESTADO_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_valor_nombreColumnIndex = reader.GetOrdinal("CTACTE_VALOR_NOMBRE");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_origen_nombreColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_NOMBRE");
			int moneda_origen_simboloColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_SIMBOLO");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int cotizacion_moneda_destinoColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_DESTINO");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int cg_ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CG_CTACTE_BANCARIA_ID");
			int cg_ctacte_banco_idColumnIndex = reader.GetOrdinal("CG_CTACTE_BANCO_ID");
			int cg_ctacte_banco_nombreColumnIndex = reader.GetOrdinal("CG_CTACTE_BANCO_NOMBRE");
			int cg_ctacte_banco_abreviaturaColumnIndex = reader.GetOrdinal("CG_CTACTE_BANCO_ABREVIATURA");
			int cg_ctacte_bancaria_numeroColumnIndex = reader.GetOrdinal("CG_CTACTE_BANCARIA_NUMERO");
			int cg_autonumeracion_idColumnIndex = reader.GetOrdinal("CG_AUTONUMERACION_ID");
			int cg_usar_autonumColumnIndex = reader.GetOrdinal("CG_USAR_AUTONUM");
			int cg_numero_chequeColumnIndex = reader.GetOrdinal("CG_NUMERO_CHEQUE");
			int cg_nombre_emisorColumnIndex = reader.GetOrdinal("CG_NOMBRE_EMISOR");
			int cg_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CG_NOMBRE_BENEFICIARIO");
			int cg_numero_cta_beneficiarioColumnIndex = reader.GetOrdinal("CG_NUMERO_CTA_BENEFICIARIO");
			int cg_es_diferidoColumnIndex = reader.GetOrdinal("CG_ES_DIFERIDO");
			int cg_fecha_emisionColumnIndex = reader.GetOrdinal("CG_FECHA_EMISION");
			int cg_fecha_vencimientoColumnIndex = reader.GetOrdinal("CG_FECHA_VENCIMIENTO");
			int cg_ctacte_cheque_girado_idColumnIndex = reader.GetOrdinal("CG_CTACTE_CHEQUE_GIRADO_ID");
			int cr_ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CR_CTACTE_CHEQUE_RECIBIDO_ID");
			int tc_ctacte_tarjeta_credito_idColumnIndex = reader.GetOrdinal("TC_CTACTE_TARJETA_CREDITO_ID");
			int tc_cuponColumnIndex = reader.GetOrdinal("TC_CUPON");
			int retencion_emitida_idColumnIndex = reader.GetOrdinal("RETENCION_EMITIDA_ID");
			int retencion_aux_casosColumnIndex = reader.GetOrdinal("RETENCION_AUX_CASOS");
			int retencion_aux_montosColumnIndex = reader.GetOrdinal("RETENCION_AUX_MONTOS");
			int retencion_tipo_idColumnIndex = reader.GetOrdinal("RETENCION_TIPO_ID");
			int retencion_fechaColumnIndex = reader.GetOrdinal("RETENCION_FECHA");
			int retencion_tipo_nombreColumnIndex = reader.GetOrdinal("RETENCION_TIPO_NOMBRE");
			int retencion_emitida_estadoColumnIndex = reader.GetOrdinal("RETENCION_EMITIDA_ESTADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int transferencia_bancaria_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BANCARIA_ID");
			int anticipo_proveedor_idColumnIndex = reader.GetOrdinal("ANTICIPO_PROVEEDOR_ID");
			int nota_credito_proveedor_idColumnIndex = reader.GetOrdinal("NOTA_CREDITO_PROVEEDOR_ID");
			int ajuste_bancario_idColumnIndex = reader.GetOrdinal("AJUSTE_BANCARIO_ID");
			int ajuste_bancario_caso_idColumnIndex = reader.GetOrdinal("AJUSTE_BANCARIO_CASO_ID");
			int ajuste_banc_cta_bancaria_idColumnIndex = reader.GetOrdinal("AJUSTE_BANC_CTA_BANCARIA_ID");
			int ajuste_banc_cuenta_nroColumnIndex = reader.GetOrdinal("AJUSTE_BANC_CUENTA_NRO");
			int ajuste_banc_banco_idColumnIndex = reader.GetOrdinal("AJUSTE_BANC_BANCO_ID");
			int ajuste_banc_banco_nombreColumnIndex = reader.GetOrdinal("AJUSTE_BANC_BANCO_NOMBRE");
			int debito_autom_ctacte_banc_idColumnIndex = reader.GetOrdinal("DEBITO_AUTOM_CTACTE_BANC_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int caso_relacionado_idColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_ID");
			int resumenColumnIndex = reader.GetOrdinal("RESUMEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_PAGO_VALORES_INFO_COMPRow record = new ORDENES_PAGO_VALORES_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					record.ORDEN_PAGO_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_caso_idColumnIndex)), 9);
					record.ORDEN_PAGO_CASO_ESTADO_ID = Convert.ToString(reader.GetValue(orden_pago_caso_estado_idColumnIndex));
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.CTACTE_VALOR_NOMBRE = Convert.ToString(reader.GetValue(ctacte_valor_nombreColumnIndex));
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(moneda_origen_nombreColumnIndex));
					record.MONEDA_ORIGEN_SIMBOLO = Convert.ToString(reader.GetValue(moneda_origen_simboloColumnIndex));
					record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					record.COTIZACION_MONEDA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_destinoColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(cg_ctacte_bancaria_idColumnIndex))
						record.CG_CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_ctacte_banco_idColumnIndex))
						record.CG_CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_ctacte_banco_nombreColumnIndex))
						record.CG_CTACTE_BANCO_NOMBRE = Convert.ToString(reader.GetValue(cg_ctacte_banco_nombreColumnIndex));
					if(!reader.IsDBNull(cg_ctacte_banco_abreviaturaColumnIndex))
						record.CG_CTACTE_BANCO_ABREVIATURA = Convert.ToString(reader.GetValue(cg_ctacte_banco_abreviaturaColumnIndex));
					if(!reader.IsDBNull(cg_ctacte_bancaria_numeroColumnIndex))
						record.CG_CTACTE_BANCARIA_NUMERO = Convert.ToString(reader.GetValue(cg_ctacte_bancaria_numeroColumnIndex));
					if(!reader.IsDBNull(cg_autonumeracion_idColumnIndex))
						record.CG_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_autonumeracion_idColumnIndex)), 9);
					record.CG_USAR_AUTONUM = Convert.ToString(reader.GetValue(cg_usar_autonumColumnIndex));
					if(!reader.IsDBNull(cg_numero_chequeColumnIndex))
						record.CG_NUMERO_CHEQUE = Convert.ToString(reader.GetValue(cg_numero_chequeColumnIndex));
					if(!reader.IsDBNull(cg_nombre_emisorColumnIndex))
						record.CG_NOMBRE_EMISOR = Convert.ToString(reader.GetValue(cg_nombre_emisorColumnIndex));
					if(!reader.IsDBNull(cg_nombre_beneficiarioColumnIndex))
						record.CG_NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(cg_nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cg_numero_cta_beneficiarioColumnIndex))
						record.CG_NUMERO_CTA_BENEFICIARIO = Convert.ToString(reader.GetValue(cg_numero_cta_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cg_es_diferidoColumnIndex))
						record.CG_ES_DIFERIDO = Convert.ToString(reader.GetValue(cg_es_diferidoColumnIndex));
					if(!reader.IsDBNull(cg_fecha_emisionColumnIndex))
						record.CG_FECHA_EMISION = Convert.ToDateTime(reader.GetValue(cg_fecha_emisionColumnIndex));
					if(!reader.IsDBNull(cg_fecha_vencimientoColumnIndex))
						record.CG_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(cg_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(cg_ctacte_cheque_girado_idColumnIndex))
						record.CG_CTACTE_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_ctacte_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(cr_ctacte_cheque_recibido_idColumnIndex))
						record.CR_CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cr_ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(tc_ctacte_tarjeta_credito_idColumnIndex))
						record.TC_CTACTE_TARJETA_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tc_ctacte_tarjeta_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(tc_cuponColumnIndex))
						record.TC_CUPON = Convert.ToString(reader.GetValue(tc_cuponColumnIndex));
					if(!reader.IsDBNull(retencion_emitida_idColumnIndex))
						record.RETENCION_EMITIDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_emitida_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_aux_casosColumnIndex))
						record.RETENCION_AUX_CASOS = Convert.ToString(reader.GetValue(retencion_aux_casosColumnIndex));
					if(!reader.IsDBNull(retencion_aux_montosColumnIndex))
						record.RETENCION_AUX_MONTOS = Convert.ToString(reader.GetValue(retencion_aux_montosColumnIndex));
					if(!reader.IsDBNull(retencion_tipo_idColumnIndex))
						record.RETENCION_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_fechaColumnIndex))
						record.RETENCION_FECHA = Convert.ToDateTime(reader.GetValue(retencion_fechaColumnIndex));
					if(!reader.IsDBNull(retencion_tipo_nombreColumnIndex))
						record.RETENCION_TIPO_NOMBRE = Convert.ToString(reader.GetValue(retencion_tipo_nombreColumnIndex));
					if(!reader.IsDBNull(retencion_emitida_estadoColumnIndex))
						record.RETENCION_EMITIDA_ESTADO = Convert.ToString(reader.GetValue(retencion_emitida_estadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(transferencia_bancaria_idColumnIndex))
						record.TRANSFERENCIA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_proveedor_idColumnIndex))
						record.ANTICIPO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(nota_credito_proveedor_idColumnIndex))
						record.NOTA_CREDITO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_bancario_idColumnIndex))
						record.AJUSTE_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_bancario_caso_idColumnIndex))
						record.AJUSTE_BANCARIO_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_bancario_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_banc_cta_bancaria_idColumnIndex))
						record.AJUSTE_BANC_CTA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_banc_cta_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_banc_cuenta_nroColumnIndex))
						record.AJUSTE_BANC_CUENTA_NRO = Convert.ToString(reader.GetValue(ajuste_banc_cuenta_nroColumnIndex));
					if(!reader.IsDBNull(ajuste_banc_banco_idColumnIndex))
						record.AJUSTE_BANC_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_banc_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_banc_banco_nombreColumnIndex))
						record.AJUSTE_BANC_BANCO_NOMBRE = Convert.ToString(reader.GetValue(ajuste_banc_banco_nombreColumnIndex));
					if(!reader.IsDBNull(debito_autom_ctacte_banc_idColumnIndex))
						record.DEBITO_AUTOM_CTACTE_BANC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(debito_autom_ctacte_banc_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(caso_relacionado_idColumnIndex))
						record.CASO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(resumenColumnIndex))
						record.RESUMEN = Convert.ToString(reader.GetValue(resumenColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_PAGO_VALORES_INFO_COMPRow[])(recordList.ToArray(typeof(ORDENES_PAGO_VALORES_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_PAGO_VALORES_INFO_COMPRow"/> object.</returns>
		protected virtual ORDENES_PAGO_VALORES_INFO_COMPRow MapRow(DataRow row)
		{
			ORDENES_PAGO_VALORES_INFO_COMPRow mappedObject = new ORDENES_PAGO_VALORES_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_CASO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_CASO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_VALOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "CG_CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CG_CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "CG_CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CG_CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CG_CTACTE_BANCO_NOMBRE"
			dataColumn = dataTable.Columns["CG_CTACTE_BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_BANCO_NOMBRE = (string)row[dataColumn];
			// Column "CG_CTACTE_BANCO_ABREVIATURA"
			dataColumn = dataTable.Columns["CG_CTACTE_BANCO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_BANCO_ABREVIATURA = (string)row[dataColumn];
			// Column "CG_CTACTE_BANCARIA_NUMERO"
			dataColumn = dataTable.Columns["CG_CTACTE_BANCARIA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_BANCARIA_NUMERO = (string)row[dataColumn];
			// Column "CG_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["CG_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "CG_USAR_AUTONUM"
			dataColumn = dataTable.Columns["CG_USAR_AUTONUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_USAR_AUTONUM = (string)row[dataColumn];
			// Column "CG_NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["CG_NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "CG_NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["CG_NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "CG_NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["CG_NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CG_NUMERO_CTA_BENEFICIARIO"
			dataColumn = dataTable.Columns["CG_NUMERO_CTA_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NUMERO_CTA_BENEFICIARIO = (string)row[dataColumn];
			// Column "CG_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CG_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_ES_DIFERIDO = (string)row[dataColumn];
			// Column "CG_FECHA_EMISION"
			dataColumn = dataTable.Columns["CG_FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "CG_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CG_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CG_CTACTE_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CG_CTACTE_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "CR_CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CR_CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CR_CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "TC_CTACTE_TARJETA_CREDITO_ID"
			dataColumn = dataTable.Columns["TC_CTACTE_TARJETA_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TC_CTACTE_TARJETA_CREDITO_ID = (decimal)row[dataColumn];
			// Column "TC_CUPON"
			dataColumn = dataTable.Columns["TC_CUPON"];
			if(!row.IsNull(dataColumn))
				mappedObject.TC_CUPON = (string)row[dataColumn];
			// Column "RETENCION_EMITIDA_ID"
			dataColumn = dataTable.Columns["RETENCION_EMITIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_EMITIDA_ID = (decimal)row[dataColumn];
			// Column "RETENCION_AUX_CASOS"
			dataColumn = dataTable.Columns["RETENCION_AUX_CASOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_AUX_CASOS = (string)row[dataColumn];
			// Column "RETENCION_AUX_MONTOS"
			dataColumn = dataTable.Columns["RETENCION_AUX_MONTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_AUX_MONTOS = (string)row[dataColumn];
			// Column "RETENCION_TIPO_ID"
			dataColumn = dataTable.Columns["RETENCION_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_TIPO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_FECHA"
			dataColumn = dataTable.Columns["RETENCION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_FECHA = (System.DateTime)row[dataColumn];
			// Column "RETENCION_TIPO_NOMBRE"
			dataColumn = dataTable.Columns["RETENCION_TIPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_TIPO_NOMBRE = (string)row[dataColumn];
			// Column "RETENCION_EMITIDA_ESTADO"
			dataColumn = dataTable.Columns["RETENCION_EMITIDA_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_EMITIDA_ESTADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TRANSFERENCIA_BANCARIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "NOTA_CREDITO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["NOTA_CREDITO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "AJUSTE_BANCARIO_ID"
			dataColumn = dataTable.Columns["AJUSTE_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "AJUSTE_BANCARIO_CASO_ID"
			dataColumn = dataTable.Columns["AJUSTE_BANCARIO_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANCARIO_CASO_ID = (decimal)row[dataColumn];
			// Column "AJUSTE_BANC_CTA_BANCARIA_ID"
			dataColumn = dataTable.Columns["AJUSTE_BANC_CTA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANC_CTA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "AJUSTE_BANC_CUENTA_NRO"
			dataColumn = dataTable.Columns["AJUSTE_BANC_CUENTA_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANC_CUENTA_NRO = (string)row[dataColumn];
			// Column "AJUSTE_BANC_BANCO_ID"
			dataColumn = dataTable.Columns["AJUSTE_BANC_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANC_BANCO_ID = (decimal)row[dataColumn];
			// Column "AJUSTE_BANC_BANCO_NOMBRE"
			dataColumn = dataTable.Columns["AJUSTE_BANC_BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANC_BANCO_NOMBRE = (string)row[dataColumn];
			// Column "DEBITO_AUTOM_CTACTE_BANC_ID"
			dataColumn = dataTable.Columns["DEBITO_AUTOM_CTACTE_BANC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO_AUTOM_CTACTE_BANC_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CASO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "RESUMEN"
			dataColumn = dataTable.Columns["RESUMEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESUMEN = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_PAGO_VALORES_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_PAGO_VALORES_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_BANCO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_BANCARIA_NUMERO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_USAR_AUTONUM", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_NUMERO_CTA_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CR_CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TC_CTACTE_TARJETA_CREDITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TC_CUPON", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_EMITIDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_AUX_CASOS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_AUX_MONTOS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_TIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_TIPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 45;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETENCION_EMITIDA_ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANTICIPO_PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANCARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANCARIO_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANC_CTA_BANCARIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANC_CUENTA_NRO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANC_BANCO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANC_BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEBITO_AUTOM_CTACTE_BANC_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESUMEN", typeof(string));
			dataColumn.MaxLength = 409;
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

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_CTACTE_BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_CTACTE_BANCO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_CTACTE_BANCARIA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_USAR_AUTONUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CG_NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_NUMERO_CTA_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CG_FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_CTACTE_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CR_CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TC_CTACTE_TARJETA_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TC_CUPON":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_EMITIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_AUX_CASOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_AUX_MONTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "RETENCION_TIPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_EMITIDA_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSFERENCIA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_CREDITO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_BANCARIO_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_BANC_CTA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_BANC_CUENTA_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AJUSTE_BANC_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_BANC_BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEBITO_AUTOM_CTACTE_BANC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESUMEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_PAGO_VALORES_INFO_COMPCollection_Base class
}  // End of namespace
