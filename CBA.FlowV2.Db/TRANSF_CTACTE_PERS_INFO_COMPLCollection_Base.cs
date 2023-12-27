// <fileinfo name="TRANSF_CTACTE_PERS_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="TRANSF_CTACTE_PERS_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSF_CTACTE_PERS_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSF_CTACTE_PERS_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string PERSONA_ORIGEN_IDColumnName = "PERSONA_ORIGEN_ID";
		public const string PERSONA_ORIGEN_NOMBREColumnName = "PERSONA_ORIGEN_NOMBRE";
		public const string PERSONA_ORIGEN_CODIGOColumnName = "PERSONA_ORIGEN_CODIGO";
		public const string PERSONA_DESTINO_IDColumnName = "PERSONA_DESTINO_ID";
		public const string PERSONA_DESTINO_NOMBREColumnName = "PERSONA_DESTINO_NOMBRE";
		public const string PERSONA_DESTINO_CODIGOColumnName = "PERSONA_DESTINO_CODIGO";
		public const string FECHAColumnName = "FECHA";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FECHA_VENCIMIENTO_DESTINOColumnName = "FECHA_VENCIMIENTO_DESTINO";
		public const string CASO_USUARIO_CREACION_IDColumnName = "CASO_USUARIO_CREACION_ID";
		public const string CASO_USUARIO_CREADORColumnName = "CASO_USUARIO_CREADOR";
		public const string CASO_ESTADOColumnName = "CASO_ESTADO";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONTO_TOTAL_CREDITOColumnName = "MONTO_TOTAL_CREDITO";
		public const string MONTO_SALDO_CREDITOColumnName = "MONTO_SALDO_CREDITO";
		public const string MONTO_TOTAL_DEBITOColumnName = "MONTO_TOTAL_DEBITO";
		public const string MONTO_SALDO_DEBITOColumnName = "MONTO_SALDO_DEBITO";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSF_CTACTE_PERS_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSF_CTACTE_PERS_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSF_CTACTE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERS_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSF_CTACTE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSF_CTACTE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSF_CTACTE_PERS_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSF_CTACTE_PERS_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects.</returns>
		public TRANSF_CTACTE_PERS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects.</returns>
		public virtual TRANSF_CTACTE_PERS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSF_CTACTE_PERS_INFO_COMPL";
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects.</returns>
		protected TRANSF_CTACTE_PERS_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects.</returns>
		protected TRANSF_CTACTE_PERS_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> objects.</returns>
		protected virtual TRANSF_CTACTE_PERS_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int persona_origen_idColumnIndex = reader.GetOrdinal("PERSONA_ORIGEN_ID");
			int persona_origen_nombreColumnIndex = reader.GetOrdinal("PERSONA_ORIGEN_NOMBRE");
			int persona_origen_codigoColumnIndex = reader.GetOrdinal("PERSONA_ORIGEN_CODIGO");
			int persona_destino_idColumnIndex = reader.GetOrdinal("PERSONA_DESTINO_ID");
			int persona_destino_nombreColumnIndex = reader.GetOrdinal("PERSONA_DESTINO_NOMBRE");
			int persona_destino_codigoColumnIndex = reader.GetOrdinal("PERSONA_DESTINO_CODIGO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int fecha_vencimiento_destinoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_DESTINO");
			int caso_usuario_creacion_idColumnIndex = reader.GetOrdinal("CASO_USUARIO_CREACION_ID");
			int caso_usuario_creadorColumnIndex = reader.GetOrdinal("CASO_USUARIO_CREADOR");
			int caso_estadoColumnIndex = reader.GetOrdinal("CASO_ESTADO");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int monto_total_creditoColumnIndex = reader.GetOrdinal("MONTO_TOTAL_CREDITO");
			int monto_saldo_creditoColumnIndex = reader.GetOrdinal("MONTO_SALDO_CREDITO");
			int monto_total_debitoColumnIndex = reader.GetOrdinal("MONTO_TOTAL_DEBITO");
			int monto_saldo_debitoColumnIndex = reader.GetOrdinal("MONTO_SALDO_DEBITO");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSF_CTACTE_PERS_INFO_COMPLRow record = new TRANSF_CTACTE_PERS_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					record.PERSONA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_origen_nombreColumnIndex))
						record.PERSONA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(persona_origen_nombreColumnIndex));
					if(!reader.IsDBNull(persona_origen_codigoColumnIndex))
						record.PERSONA_ORIGEN_CODIGO = Convert.ToString(reader.GetValue(persona_origen_codigoColumnIndex));
					record.PERSONA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_destino_nombreColumnIndex))
						record.PERSONA_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(persona_destino_nombreColumnIndex));
					if(!reader.IsDBNull(persona_destino_codigoColumnIndex))
						record.PERSONA_DESTINO_CODIGO = Convert.ToString(reader.GetValue(persona_destino_codigoColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_vencimiento_destinoColumnIndex))
						record.FECHA_VENCIMIENTO_DESTINO = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_destinoColumnIndex));
					if(!reader.IsDBNull(caso_usuario_creacion_idColumnIndex))
						record.CASO_USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_usuario_creacion_idColumnIndex)), 9);
					record.CASO_USUARIO_CREADOR = Convert.ToString(reader.GetValue(caso_usuario_creadorColumnIndex));
					record.CASO_ESTADO = Convert.ToString(reader.GetValue(caso_estadoColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(monto_total_creditoColumnIndex))
						record.MONTO_TOTAL_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_saldo_creditoColumnIndex))
						record.MONTO_SALDO_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_saldo_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_total_debitoColumnIndex))
						record.MONTO_TOTAL_DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_debitoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_saldo_debitoColumnIndex))
						record.MONTO_SALDO_DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_saldo_debitoColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSF_CTACTE_PERS_INFO_COMPLRow[])(recordList.ToArray(typeof(TRANSF_CTACTE_PERS_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSF_CTACTE_PERS_INFO_COMPLRow"/> object.</returns>
		protected virtual TRANSF_CTACTE_PERS_INFO_COMPLRow MapRow(DataRow row)
		{
			TRANSF_CTACTE_PERS_INFO_COMPLRow mappedObject = new TRANSF_CTACTE_PERS_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "PERSONA_ORIGEN_ID"
			dataColumn = dataTable.Columns["PERSONA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_ORIGEN_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_ORIGEN_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ORIGEN_CODIGO = (string)row[dataColumn];
			// Column "PERSONA_DESTINO_ID"
			dataColumn = dataTable.Columns["PERSONA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_DESTINO_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_DESTINO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DESTINO_CODIGO = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_DESTINO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_DESTINO = (System.DateTime)row[dataColumn];
			// Column "CASO_USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["CASO_USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "CASO_USUARIO_CREADOR"
			dataColumn = dataTable.Columns["CASO_USUARIO_CREADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_USUARIO_CREADOR = (string)row[dataColumn];
			// Column "CASO_ESTADO"
			dataColumn = dataTable.Columns["CASO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
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
			// Column "MONTO_TOTAL_CREDITO"
			dataColumn = dataTable.Columns["MONTO_TOTAL_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_CREDITO = (decimal)row[dataColumn];
			// Column "MONTO_SALDO_CREDITO"
			dataColumn = dataTable.Columns["MONTO_SALDO_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_SALDO_CREDITO = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL_DEBITO"
			dataColumn = dataTable.Columns["MONTO_TOTAL_DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_DEBITO = (decimal)row[dataColumn];
			// Column "MONTO_SALDO_DEBITO"
			dataColumn = dataTable.Columns["MONTO_SALDO_DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_SALDO_DEBITO = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSF_CTACTE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSF_CTACTE_PERS_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ORIGEN_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DESTINO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_DESTINO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_USUARIO_CREADOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
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
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_SALDO_CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_DEBITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_SALDO_DEBITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ORIGEN_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DESTINO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_VENCIMIENTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_USUARIO_CREADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
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

				case "MONTO_TOTAL_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_SALDO_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL_DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_SALDO_DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSF_CTACTE_PERS_INFO_COMPLCollection_Base class
}  // End of namespace
