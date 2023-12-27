// <fileinfo name="TRANSFERENCIAS_BANCARIAS_INF_CCollection_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIAS_BANCARIAS_INF_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSFERENCIAS_BANCARIAS_INF_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIAS_BANCARIAS_INF_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string NRO_SOLICITUDColumnName = "NRO_SOLICITUD";
		public const string CUENTA_ORIGEN_ADMINISTRADAColumnName = "CUENTA_ORIGEN_ADMINISTRADA";
		public const string CUENTA_DESTINO_ADMINISTRADAColumnName = "CUENTA_DESTINO_ADMINISTRADA";
		public const string CUENTA_ORIGEN_TERCEROSColumnName = "CUENTA_ORIGEN_TERCEROS";
		public const string CUENTA_DESTINO_TERCEROSColumnName = "CUENTA_DESTINO_TERCEROS";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string CTACTE_BANC_TERCEROS_ORIGEN_IDColumnName = "CTACTE_BANC_TERCEROS_ORIGEN_ID";
		public const string CTACTE_BANC_TERCEROS_DEST_IDColumnName = "CTACTE_BANC_TERCEROS_DEST_ID";
		public const string SUCURSAL_ORIGEN_NOMBREColumnName = "SUCURSAL_ORIGEN_NOMBRE";
		public const string CTACTE_BANCO_ORIGEN_IDColumnName = "CTACTE_BANCO_ORIGEN_ID";
		public const string CTACTE_BANCO_ORIGEN_NOMBREColumnName = "CTACTE_BANCO_ORIGEN_NOMBRE";
		public const string CTACTE_BANCO_ORIGEN_ABREVColumnName = "CTACTE_BANCO_ORIGEN_ABREV";
		public const string CTACTE_BANCARIA_ORIGEN_IDColumnName = "CTACTE_BANCARIA_ORIGEN_ID";
		public const string NUMERO_CUENTA_ORIGENColumnName = "NUMERO_CUENTA_ORIGEN";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_ORIGEN_NOMBREColumnName = "MONEDA_ORIGEN_NOMBRE";
		public const string MONEDA_ORIGEN_SIMBOLOColumnName = "MONEDA_ORIGEN_SIMBOLO";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string COSTO_TRANSFERENCIAColumnName = "COSTO_TRANSFERENCIA";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string SUCURSAL_DESTINO_NOMBREColumnName = "SUCURSAL_DESTINO_NOMBRE";
		public const string CTACTE_BANCO_DESTINO_IDColumnName = "CTACTE_BANCO_DESTINO_ID";
		public const string CTACTE_BANCARIA_DESTINO_IDColumnName = "CTACTE_BANCARIA_DESTINO_ID";
		public const string CTACTE_BANCO_DESTINO_NOMBREColumnName = "CTACTE_BANCO_DESTINO_NOMBRE";
		public const string CTACTE_BANCO_DESTINO_ABREVColumnName = "CTACTE_BANCO_DESTINO_ABREV";
		public const string NUMERO_CUENTA_DESTINOColumnName = "NUMERO_CUENTA_DESTINO";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string MONEDA_DESTINO_NOMBREColumnName = "MONEDA_DESTINO_NOMBRE";
		public const string MONEDA_DESTINO_SIMBOLOColumnName = "MONEDA_DESTINO_SIMBOLO";
		public const string COTIZACION_MONEDA_DESTINOColumnName = "COTIZACION_MONEDA_DESTINO";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string NUMERO_TRANSACCIONColumnName = "NUMERO_TRANSACCION";
		public const string PERSONA_ORIGEN_IDColumnName = "PERSONA_ORIGEN_ID";
		public const string PROVEEDOR_ORIGEN_IDColumnName = "PROVEEDOR_ORIGEN_ID";
		public const string FUNCIONARIO_ORIGEN_IDColumnName = "FUNCIONARIO_ORIGEN_ID";
		public const string PERSONA_DESTINO_IDColumnName = "PERSONA_DESTINO_ID";
		public const string PROVEEDOR_DESTINO_IDColumnName = "PROVEEDOR_DESTINO_ID";
		public const string FUNCIONARIO_DESTINO_IDColumnName = "FUNCIONARIO_DESTINO_ID";
		public const string ORDEN_PAGO_RESPALDA_CASO_IDColumnName = "ORDEN_PAGO_RESPALDA_CASO_ID";
		public const string ORDEN_PAGO_UTILIZA_CASO_IDColumnName = "ORDEN_PAGO_UTILIZA_CASO_ID";
		public const string ANTICIPO_PROV_UTILIZA_CASO_IDColumnName = "ANTICIPO_PROV_UTILIZA_CASO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string CG_AUTONUMERACION_IDColumnName = "CG_AUTONUMERACION_ID";
		public const string CG_NUMERO_CHEQUEColumnName = "CG_NUMERO_CHEQUE";
		public const string CG_FECHA_EMISIONColumnName = "CG_FECHA_EMISION";
		public const string CG_FECHA_VENCIMIENTOColumnName = "CG_FECHA_VENCIMIENTO";
		public const string CG_NOMBRE_EMISORColumnName = "CG_NOMBRE_EMISOR";
		public const string CG_NOMBRE_BENEFICIARIOColumnName = "CG_NOMBRE_BENEFICIARIO";
		public const string CG_USAR_CHEQUERAColumnName = "CG_USAR_CHEQUERA";
		public const string CG_CHEQUE_GIRADO_IDColumnName = "CG_CHEQUE_GIRADO_ID";
		public const string CG_ES_DIFERIDOColumnName = "CG_ES_DIFERIDO";
		public const string PERSONA_ORIGEN_NOMBREColumnName = "PERSONA_ORIGEN_NOMBRE";
		public const string PROVEEDOR_ORIGEN_NOMBREColumnName = "PROVEEDOR_ORIGEN_NOMBRE";
		public const string FUNCIONARIO_ORIGEN_NOMBREColumnName = "FUNCIONARIO_ORIGEN_NOMBRE";
		public const string PERSONA_DESTINO_NOMBREColumnName = "PERSONA_DESTINO_NOMBRE";
		public const string PROVEEDOR_DESTINO_NOMBREColumnName = "PROVEEDOR_DESTINO_NOMBRE";
		public const string FUNCIONARIO_DESTINO_NOMBREColumnName = "FUNCIONARIO_DESTINO_NOMBRE";
		public const string ES_COTIZACION_DIRECTAColumnName = "ES_COTIZACION_DIRECTA";
		public const string MONEDA_COT_DIRECTA_IDColumnName = "MONEDA_COT_DIRECTA_ID";
		public const string MONEDA_DIRECTA_NOMBREColumnName = "MONEDA_DIRECTA_NOMBRE";
		public const string MONEDA_DIRECTA_SIMBOLOColumnName = "MONEDA_DIRECTA_SIMBOLO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_BANCARIAS_INF_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSFERENCIAS_BANCARIAS_INF_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSFERENCIAS_BANCARIAS_INF_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIAS_INF_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSFERENCIAS_BANCARIAS_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSFERENCIAS_BANCARIAS_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSFERENCIAS_BANCARIAS_INF_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSFERENCIAS_BANCARIAS_INF_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIAS_INF_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIAS_INF_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSFERENCIAS_BANCARIAS_INF_C";
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects.</returns>
		protected TRANSFERENCIAS_BANCARIAS_INF_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects.</returns>
		protected TRANSFERENCIAS_BANCARIAS_INF_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> objects.</returns>
		protected virtual TRANSFERENCIAS_BANCARIAS_INF_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int nro_solicitudColumnIndex = reader.GetOrdinal("NRO_SOLICITUD");
			int cuenta_origen_administradaColumnIndex = reader.GetOrdinal("CUENTA_ORIGEN_ADMINISTRADA");
			int cuenta_destino_administradaColumnIndex = reader.GetOrdinal("CUENTA_DESTINO_ADMINISTRADA");
			int cuenta_origen_tercerosColumnIndex = reader.GetOrdinal("CUENTA_ORIGEN_TERCEROS");
			int cuenta_destino_tercerosColumnIndex = reader.GetOrdinal("CUENTA_DESTINO_TERCEROS");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int ctacte_banc_terceros_origen_idColumnIndex = reader.GetOrdinal("CTACTE_BANC_TERCEROS_ORIGEN_ID");
			int ctacte_banc_terceros_dest_idColumnIndex = reader.GetOrdinal("CTACTE_BANC_TERCEROS_DEST_ID");
			int sucursal_origen_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_NOMBRE");
			int ctacte_banco_origen_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ORIGEN_ID");
			int ctacte_banco_origen_nombreColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ORIGEN_NOMBRE");
			int ctacte_banco_origen_abrevColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ORIGEN_ABREV");
			int ctacte_bancaria_origen_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ORIGEN_ID");
			int numero_cuenta_origenColumnIndex = reader.GetOrdinal("NUMERO_CUENTA_ORIGEN");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_origen_nombreColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_NOMBRE");
			int moneda_origen_simboloColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_SIMBOLO");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int costo_transferenciaColumnIndex = reader.GetOrdinal("COSTO_TRANSFERENCIA");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int sucursal_destino_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_NOMBRE");
			int ctacte_banco_destino_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_DESTINO_ID");
			int ctacte_bancaria_destino_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_DESTINO_ID");
			int ctacte_banco_destino_nombreColumnIndex = reader.GetOrdinal("CTACTE_BANCO_DESTINO_NOMBRE");
			int ctacte_banco_destino_abrevColumnIndex = reader.GetOrdinal("CTACTE_BANCO_DESTINO_ABREV");
			int numero_cuenta_destinoColumnIndex = reader.GetOrdinal("NUMERO_CUENTA_DESTINO");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int moneda_destino_nombreColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_NOMBRE");
			int moneda_destino_simboloColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_SIMBOLO");
			int cotizacion_moneda_destinoColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_DESTINO");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int numero_transaccionColumnIndex = reader.GetOrdinal("NUMERO_TRANSACCION");
			int persona_origen_idColumnIndex = reader.GetOrdinal("PERSONA_ORIGEN_ID");
			int proveedor_origen_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ORIGEN_ID");
			int funcionario_origen_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ORIGEN_ID");
			int persona_destino_idColumnIndex = reader.GetOrdinal("PERSONA_DESTINO_ID");
			int proveedor_destino_idColumnIndex = reader.GetOrdinal("PROVEEDOR_DESTINO_ID");
			int funcionario_destino_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_DESTINO_ID");
			int orden_pago_respalda_caso_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_RESPALDA_CASO_ID");
			int orden_pago_utiliza_caso_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_UTILIZA_CASO_ID");
			int anticipo_prov_utiliza_caso_idColumnIndex = reader.GetOrdinal("ANTICIPO_PROV_UTILIZA_CASO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int cg_autonumeracion_idColumnIndex = reader.GetOrdinal("CG_AUTONUMERACION_ID");
			int cg_numero_chequeColumnIndex = reader.GetOrdinal("CG_NUMERO_CHEQUE");
			int cg_fecha_emisionColumnIndex = reader.GetOrdinal("CG_FECHA_EMISION");
			int cg_fecha_vencimientoColumnIndex = reader.GetOrdinal("CG_FECHA_VENCIMIENTO");
			int cg_nombre_emisorColumnIndex = reader.GetOrdinal("CG_NOMBRE_EMISOR");
			int cg_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CG_NOMBRE_BENEFICIARIO");
			int cg_usar_chequeraColumnIndex = reader.GetOrdinal("CG_USAR_CHEQUERA");
			int cg_cheque_girado_idColumnIndex = reader.GetOrdinal("CG_CHEQUE_GIRADO_ID");
			int cg_es_diferidoColumnIndex = reader.GetOrdinal("CG_ES_DIFERIDO");
			int persona_origen_nombreColumnIndex = reader.GetOrdinal("PERSONA_ORIGEN_NOMBRE");
			int proveedor_origen_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_ORIGEN_NOMBRE");
			int funcionario_origen_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_ORIGEN_NOMBRE");
			int persona_destino_nombreColumnIndex = reader.GetOrdinal("PERSONA_DESTINO_NOMBRE");
			int proveedor_destino_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_DESTINO_NOMBRE");
			int funcionario_destino_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_DESTINO_NOMBRE");
			int es_cotizacion_directaColumnIndex = reader.GetOrdinal("ES_COTIZACION_DIRECTA");
			int moneda_cot_directa_idColumnIndex = reader.GetOrdinal("MONEDA_COT_DIRECTA_ID");
			int moneda_directa_nombreColumnIndex = reader.GetOrdinal("MONEDA_DIRECTA_NOMBRE");
			int moneda_directa_simboloColumnIndex = reader.GetOrdinal("MONEDA_DIRECTA_SIMBOLO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSFERENCIAS_BANCARIAS_INF_CRow record = new TRANSFERENCIAS_BANCARIAS_INF_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(nro_solicitudColumnIndex))
						record.NRO_SOLICITUD = Convert.ToString(reader.GetValue(nro_solicitudColumnIndex));
					record.CUENTA_ORIGEN_ADMINISTRADA = Convert.ToString(reader.GetValue(cuenta_origen_administradaColumnIndex));
					record.CUENTA_DESTINO_ADMINISTRADA = Convert.ToString(reader.GetValue(cuenta_destino_administradaColumnIndex));
					record.CUENTA_ORIGEN_TERCEROS = Convert.ToString(reader.GetValue(cuenta_origen_tercerosColumnIndex));
					record.CUENTA_DESTINO_TERCEROS = Convert.ToString(reader.GetValue(cuenta_destino_tercerosColumnIndex));
					if(!reader.IsDBNull(sucursal_origen_idColumnIndex))
						record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_banc_terceros_origen_idColumnIndex))
						record.CTACTE_BANC_TERCEROS_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banc_terceros_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_banc_terceros_dest_idColumnIndex))
						record.CTACTE_BANC_TERCEROS_DEST_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banc_terceros_dest_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_origen_nombreColumnIndex))
						record.SUCURSAL_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(sucursal_origen_nombreColumnIndex));
					record.CTACTE_BANCO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_origen_idColumnIndex)), 9);
					record.CTACTE_BANCO_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(ctacte_banco_origen_nombreColumnIndex));
					record.CTACTE_BANCO_ORIGEN_ABREV = Convert.ToString(reader.GetValue(ctacte_banco_origen_abrevColumnIndex));
					if(!reader.IsDBNull(ctacte_bancaria_origen_idColumnIndex))
						record.CTACTE_BANCARIA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_origen_idColumnIndex)), 9);
					record.NUMERO_CUENTA_ORIGEN = Convert.ToString(reader.GetValue(numero_cuenta_origenColumnIndex));
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(moneda_origen_nombreColumnIndex));
					record.MONEDA_ORIGEN_SIMBOLO = Convert.ToString(reader.GetValue(moneda_origen_simboloColumnIndex));
					record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					record.COSTO_TRANSFERENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(costo_transferenciaColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_idColumnIndex))
						record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_nombreColumnIndex))
						record.SUCURSAL_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(sucursal_destino_nombreColumnIndex));
					record.CTACTE_BANCO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_bancaria_destino_idColumnIndex))
						record.CTACTE_BANCARIA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_destino_idColumnIndex)), 9);
					record.CTACTE_BANCO_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_banco_destino_nombreColumnIndex));
					record.CTACTE_BANCO_DESTINO_ABREV = Convert.ToString(reader.GetValue(ctacte_banco_destino_abrevColumnIndex));
					record.NUMERO_CUENTA_DESTINO = Convert.ToString(reader.GetValue(numero_cuenta_destinoColumnIndex));
					record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					record.MONEDA_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(moneda_destino_nombreColumnIndex));
					record.MONEDA_DESTINO_SIMBOLO = Convert.ToString(reader.GetValue(moneda_destino_simboloColumnIndex));
					record.COTIZACION_MONEDA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_destinoColumnIndex)), 9);
					record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(numero_transaccionColumnIndex))
						record.NUMERO_TRANSACCION = Convert.ToString(reader.GetValue(numero_transaccionColumnIndex));
					if(!reader.IsDBNull(persona_origen_idColumnIndex))
						record.PERSONA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_origen_idColumnIndex))
						record.PROVEEDOR_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_origen_idColumnIndex))
						record.FUNCIONARIO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_destino_idColumnIndex))
						record.PERSONA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_destino_idColumnIndex))
						record.PROVEEDOR_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_destino_idColumnIndex))
						record.FUNCIONARIO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_respalda_caso_idColumnIndex))
						record.ORDEN_PAGO_RESPALDA_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_respalda_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_utiliza_caso_idColumnIndex))
						record.ORDEN_PAGO_UTILIZA_CASO_ID = Convert.ToString(reader.GetValue(orden_pago_utiliza_caso_idColumnIndex));
					if(!reader.IsDBNull(anticipo_prov_utiliza_caso_idColumnIndex))
						record.ANTICIPO_PROV_UTILIZA_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_prov_utiliza_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_autonumeracion_idColumnIndex))
						record.CG_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_numero_chequeColumnIndex))
						record.CG_NUMERO_CHEQUE = Convert.ToString(reader.GetValue(cg_numero_chequeColumnIndex));
					if(!reader.IsDBNull(cg_fecha_emisionColumnIndex))
						record.CG_FECHA_EMISION = Convert.ToDateTime(reader.GetValue(cg_fecha_emisionColumnIndex));
					if(!reader.IsDBNull(cg_fecha_vencimientoColumnIndex))
						record.CG_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(cg_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(cg_nombre_emisorColumnIndex))
						record.CG_NOMBRE_EMISOR = Convert.ToString(reader.GetValue(cg_nombre_emisorColumnIndex));
					if(!reader.IsDBNull(cg_nombre_beneficiarioColumnIndex))
						record.CG_NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(cg_nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cg_usar_chequeraColumnIndex))
						record.CG_USAR_CHEQUERA = Convert.ToString(reader.GetValue(cg_usar_chequeraColumnIndex));
					if(!reader.IsDBNull(cg_cheque_girado_idColumnIndex))
						record.CG_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_es_diferidoColumnIndex))
						record.CG_ES_DIFERIDO = Convert.ToString(reader.GetValue(cg_es_diferidoColumnIndex));
					if(!reader.IsDBNull(persona_origen_nombreColumnIndex))
						record.PERSONA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(persona_origen_nombreColumnIndex));
					if(!reader.IsDBNull(proveedor_origen_nombreColumnIndex))
						record.PROVEEDOR_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(proveedor_origen_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_origen_nombreColumnIndex))
						record.FUNCIONARIO_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(funcionario_origen_nombreColumnIndex));
					if(!reader.IsDBNull(persona_destino_nombreColumnIndex))
						record.PERSONA_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(persona_destino_nombreColumnIndex));
					if(!reader.IsDBNull(proveedor_destino_nombreColumnIndex))
						record.PROVEEDOR_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(proveedor_destino_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_destino_nombreColumnIndex))
						record.FUNCIONARIO_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_destino_nombreColumnIndex));
					record.ES_COTIZACION_DIRECTA = Convert.ToString(reader.GetValue(es_cotizacion_directaColumnIndex));
					if(!reader.IsDBNull(moneda_cot_directa_idColumnIndex))
						record.MONEDA_COT_DIRECTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cot_directa_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_directa_nombreColumnIndex))
						record.MONEDA_DIRECTA_NOMBRE = Convert.ToString(reader.GetValue(moneda_directa_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_directa_simboloColumnIndex))
						record.MONEDA_DIRECTA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_directa_simboloColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSFERENCIAS_BANCARIAS_INF_CRow[])(recordList.ToArray(typeof(TRANSFERENCIAS_BANCARIAS_INF_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSFERENCIAS_BANCARIAS_INF_CRow"/> object.</returns>
		protected virtual TRANSFERENCIAS_BANCARIAS_INF_CRow MapRow(DataRow row)
		{
			TRANSFERENCIAS_BANCARIAS_INF_CRow mappedObject = new TRANSFERENCIAS_BANCARIAS_INF_CRow();
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
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "NRO_SOLICITUD"
			dataColumn = dataTable.Columns["NRO_SOLICITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_SOLICITUD = (string)row[dataColumn];
			// Column "CUENTA_ORIGEN_ADMINISTRADA"
			dataColumn = dataTable.Columns["CUENTA_ORIGEN_ADMINISTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_ORIGEN_ADMINISTRADA = (string)row[dataColumn];
			// Column "CUENTA_DESTINO_ADMINISTRADA"
			dataColumn = dataTable.Columns["CUENTA_DESTINO_ADMINISTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_DESTINO_ADMINISTRADA = (string)row[dataColumn];
			// Column "CUENTA_ORIGEN_TERCEROS"
			dataColumn = dataTable.Columns["CUENTA_ORIGEN_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_ORIGEN_TERCEROS = (string)row[dataColumn];
			// Column "CUENTA_DESTINO_TERCEROS"
			dataColumn = dataTable.Columns["CUENTA_DESTINO_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_DESTINO_TERCEROS = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANC_TERCEROS_ORIGEN_ID"
			dataColumn = dataTable.Columns["CTACTE_BANC_TERCEROS_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANC_TERCEROS_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANC_TERCEROS_DEST_ID"
			dataColumn = dataTable.Columns["CTACTE_BANC_TERCEROS_DEST_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANC_TERCEROS_DEST_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCO_ORIGEN_ABREV"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ORIGEN_ABREV"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ORIGEN_ABREV = (string)row[dataColumn];
			// Column "CTACTE_BANCARIA_ORIGEN_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CUENTA_ORIGEN"
			dataColumn = dataTable.Columns["NUMERO_CUENTA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA_ORIGEN = (string)row[dataColumn];
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
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "COSTO_TRANSFERENCIA"
			dataColumn = dataTable.Columns["COSTO_TRANSFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TRANSFERENCIA = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCO_DESTINO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_DESTINO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_BANCO_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCO_DESTINO_ABREV"
			dataColumn = dataTable.Columns["CTACTE_BANCO_DESTINO_ABREV"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_DESTINO_ABREV = (string)row[dataColumn];
			// Column "NUMERO_CUENTA_DESTINO"
			dataColumn = dataTable.Columns["NUMERO_CUENTA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA_DESTINO = (string)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_DESTINO_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "NUMERO_TRANSACCION"
			dataColumn = dataTable.Columns["NUMERO_TRANSACCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_TRANSACCION = (string)row[dataColumn];
			// Column "PERSONA_ORIGEN_ID"
			dataColumn = dataTable.Columns["PERSONA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ORIGEN_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ORIGEN_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "PERSONA_DESTINO_ID"
			dataColumn = dataTable.Columns["PERSONA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_DESTINO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_DESTINO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_DESTINO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_RESPALDA_CASO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_RESPALDA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_RESPALDA_CASO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_UTILIZA_CASO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_UTILIZA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_UTILIZA_CASO_ID = (string)row[dataColumn];
			// Column "ANTICIPO_PROV_UTILIZA_CASO_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PROV_UTILIZA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PROV_UTILIZA_CASO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "CG_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["CG_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "CG_NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["CG_NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "CG_FECHA_EMISION"
			dataColumn = dataTable.Columns["CG_FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "CG_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CG_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CG_NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["CG_NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "CG_NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["CG_NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CG_USAR_CHEQUERA"
			dataColumn = dataTable.Columns["CG_USAR_CHEQUERA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_USAR_CHEQUERA = (string)row[dataColumn];
			// Column "CG_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CG_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "CG_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CG_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_ES_DIFERIDO = (string)row[dataColumn];
			// Column "PERSONA_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "PROVEEDOR_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "PROVEEDOR_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "ES_COTIZACION_DIRECTA"
			dataColumn = dataTable.Columns["ES_COTIZACION_DIRECTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COTIZACION_DIRECTA = (string)row[dataColumn];
			// Column "MONEDA_COT_DIRECTA_ID"
			dataColumn = dataTable.Columns["MONEDA_COT_DIRECTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COT_DIRECTA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_DIRECTA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_DIRECTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DIRECTA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_DIRECTA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_DIRECTA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DIRECTA_SIMBOLO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSFERENCIAS_BANCARIAS_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSFERENCIAS_BANCARIAS_INF_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_SOLICITUD", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_ORIGEN_ADMINISTRADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_DESTINO_ADMINISTRADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_ORIGEN_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_DESTINO_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANC_TERCEROS_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANC_TERCEROS_DEST_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ORIGEN_ABREV", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA_ORIGEN", typeof(string));
			dataColumn.MaxLength = 100;
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
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_TRANSFERENCIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_DESTINO_ABREV", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA_DESTINO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_TRANSACCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_RESPALDA_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_UTILIZA_CASO_ID", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANTICIPO_PROV_UTILIZA_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_USAR_CHEQUERA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CG_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_COTIZACION_DIRECTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COT_DIRECTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DIRECTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DIRECTA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_SOLICITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CUENTA_ORIGEN_ADMINISTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CUENTA_DESTINO_ADMINISTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CUENTA_ORIGEN_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CUENTA_DESTINO_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANC_TERCEROS_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANC_TERCEROS_DEST_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_ORIGEN_ABREV":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCARIA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUENTA_ORIGEN":
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

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TRANSFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_DESTINO_ABREV":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CUENTA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_DESTINO_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_TRANSACCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_RESPALDA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_UTILIZA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ANTICIPO_PROV_UTILIZA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_USAR_CHEQUERA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CG_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONA_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_COTIZACION_DIRECTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONEDA_COT_DIRECTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DIRECTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_DIRECTA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSFERENCIAS_BANCARIAS_INF_CCollection_Base class
}  // End of namespace
