// <fileinfo name="TRAN_CTACTE_PERS_DET_INF_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAN_CTACTE_PERS_DET_INF_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TRANSF_CTACTE_PERSONA_IDColumnName = "TRANSF_CTACTE_PERSONA_ID";
		public const string CTACTE_PERSONA_ORIG_IDColumnName = "CTACTE_PERSONA_ORIG_ID";
		public const string MONTO_CREDITO_ORIGENColumnName = "MONTO_CREDITO_ORIGEN";
		public const string MONTO_DEBITO_ORIGENColumnName = "MONTO_DEBITO_ORIGEN";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_ORIGEN_NOMBREColumnName = "MONEDA_ORIGEN_NOMBRE";
		public const string MONEDA_ORIGEN_SIMBOLOColumnName = "MONEDA_ORIGEN_SIMBOLO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CTACTE_PERSONA_DEST_IDColumnName = "CTACTE_PERSONA_DEST_ID";
		public const string MONTO_CREDITO_DESTINOColumnName = "MONTO_CREDITO_DESTINO";
		public const string MONTO_DEBITO_DESTINOColumnName = "MONTO_DEBITO_DESTINO";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string MONEDA_DESTINO_NOMBREColumnName = "MONEDA_DESTINO_NOMBRE";
		public const string MOENDA_DESTINO_SIMBOLOColumnName = "MOENDA_DESTINO_SIMBOLO";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string OBSERVACION_CUENTA_ORIGENColumnName = "OBSERVACION_CUENTA_ORIGEN";
		public const string VENCIMIENTO_CUENTA_ORIGENColumnName = "VENCIMIENTO_CUENTA_ORIGEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRAN_CTACTE_PERS_DET_INF_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRAN_CTACTE_PERS_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects.</returns>
		public virtual TRAN_CTACTE_PERS_DET_INF_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRAN_CTACTE_PERS_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRAN_CTACTE_PERS_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRAN_CTACTE_PERS_DET_INF_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRAN_CTACTE_PERS_DET_INF_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects.</returns>
		public TRAN_CTACTE_PERS_DET_INF_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects.</returns>
		public virtual TRAN_CTACTE_PERS_DET_INF_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRAN_CTACTE_PERS_DET_INF_COMPL";
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
		/// <returns>An array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects.</returns>
		protected TRAN_CTACTE_PERS_DET_INF_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects.</returns>
		protected TRAN_CTACTE_PERS_DET_INF_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> objects.</returns>
		protected virtual TRAN_CTACTE_PERS_DET_INF_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int transf_ctacte_persona_idColumnIndex = reader.GetOrdinal("TRANSF_CTACTE_PERSONA_ID");
			int ctacte_persona_orig_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ORIG_ID");
			int monto_credito_origenColumnIndex = reader.GetOrdinal("MONTO_CREDITO_ORIGEN");
			int monto_debito_origenColumnIndex = reader.GetOrdinal("MONTO_DEBITO_ORIGEN");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_origen_nombreColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_NOMBRE");
			int moneda_origen_simboloColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_SIMBOLO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int ctacte_persona_dest_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_DEST_ID");
			int monto_credito_destinoColumnIndex = reader.GetOrdinal("MONTO_CREDITO_DESTINO");
			int monto_debito_destinoColumnIndex = reader.GetOrdinal("MONTO_DEBITO_DESTINO");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int moneda_destino_nombreColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_NOMBRE");
			int moenda_destino_simboloColumnIndex = reader.GetOrdinal("MOENDA_DESTINO_SIMBOLO");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int observacion_cuenta_origenColumnIndex = reader.GetOrdinal("OBSERVACION_CUENTA_ORIGEN");
			int vencimiento_cuenta_origenColumnIndex = reader.GetOrdinal("VENCIMIENTO_CUENTA_ORIGEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRAN_CTACTE_PERS_DET_INF_COMPLRow record = new TRAN_CTACTE_PERS_DET_INF_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TRANSF_CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transf_ctacte_persona_idColumnIndex)), 9);
					record.CTACTE_PERSONA_ORIG_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_orig_idColumnIndex)), 9);
					record.MONTO_CREDITO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_credito_origenColumnIndex)), 9);
					record.MONTO_DEBITO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_debito_origenColumnIndex)), 9);
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(moneda_origen_nombreColumnIndex));
					record.MONEDA_ORIGEN_SIMBOLO = Convert.ToString(reader.GetValue(moneda_origen_simboloColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(ctacte_persona_dest_idColumnIndex))
						record.CTACTE_PERSONA_DEST_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_dest_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_credito_destinoColumnIndex))
						record.MONTO_CREDITO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_credito_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_debito_destinoColumnIndex))
						record.MONTO_DEBITO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_debito_destinoColumnIndex)), 9);
					record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					record.MONEDA_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(moneda_destino_nombreColumnIndex));
					record.MOENDA_DESTINO_SIMBOLO = Convert.ToString(reader.GetValue(moenda_destino_simboloColumnIndex));
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_cuenta_origenColumnIndex))
						record.OBSERVACION_CUENTA_ORIGEN = Convert.ToString(reader.GetValue(observacion_cuenta_origenColumnIndex));
					if(!reader.IsDBNull(vencimiento_cuenta_origenColumnIndex))
						record.VENCIMIENTO_CUENTA_ORIGEN = Convert.ToDateTime(reader.GetValue(vencimiento_cuenta_origenColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRAN_CTACTE_PERS_DET_INF_COMPLRow[])(recordList.ToArray(typeof(TRAN_CTACTE_PERS_DET_INF_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRAN_CTACTE_PERS_DET_INF_COMPLRow"/> object.</returns>
		protected virtual TRAN_CTACTE_PERS_DET_INF_COMPLRow MapRow(DataRow row)
		{
			TRAN_CTACTE_PERS_DET_INF_COMPLRow mappedObject = new TRAN_CTACTE_PERS_DET_INF_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TRANSF_CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSF_CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSF_CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ORIG_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ORIG_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ORIG_ID = (decimal)row[dataColumn];
			// Column "MONTO_CREDITO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_CREDITO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CREDITO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DEBITO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_DEBITO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DEBITO_ORIGEN = (decimal)row[dataColumn];
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
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CTACTE_PERSONA_DEST_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_DEST_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_DEST_ID = (decimal)row[dataColumn];
			// Column "MONTO_CREDITO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_CREDITO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CREDITO_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_DEBITO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DEBITO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DEBITO_DESTINO = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "MOENDA_DESTINO_SIMBOLO"
			dataColumn = dataTable.Columns["MOENDA_DESTINO_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOENDA_DESTINO_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION_CUENTA_ORIGEN"
			dataColumn = dataTable.Columns["OBSERVACION_CUENTA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_CUENTA_ORIGEN = (string)row[dataColumn];
			// Column "VENCIMIENTO_CUENTA_ORIGEN"
			dataColumn = dataTable.Columns["VENCIMIENTO_CUENTA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENCIMIENTO_CUENTA_ORIGEN = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRAN_CTACTE_PERS_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRAN_CTACTE_PERS_DET_INF_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSF_CTACTE_PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ORIG_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_CREDITO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DEBITO_ORIGEN", typeof(decimal));
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
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_DEST_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_CREDITO_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_DEBITO_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOENDA_DESTINO_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION_CUENTA_ORIGEN", typeof(string));
			dataColumn.MaxLength = 155;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENCIMIENTO_CUENTA_ORIGEN", typeof(System.DateTime));
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

				case "TRANSF_CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_ORIG_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CREDITO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DEBITO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PERSONA_DEST_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CREDITO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DEBITO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MOENDA_DESTINO_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_CUENTA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENCIMIENTO_CUENTA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRAN_CTACTE_PERS_DET_INF_COMPLCollection_Base class
}  // End of namespace
