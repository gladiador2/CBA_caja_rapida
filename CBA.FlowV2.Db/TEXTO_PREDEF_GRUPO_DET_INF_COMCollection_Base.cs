// <fileinfo name="TEXTO_PREDEF_GRUPO_DET_INF_COMCollection_Base.cs">
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
	/// The base class for <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TEXTO_PREDEF_GRUPO_DET_INF_COMCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TEXTO_PREDEFINIDOColumnName = "TEXTO_PREDEFINIDO";
		public const string TEXTO_PREDEFINIDO_GRUPO_IDColumnName = "TEXTO_PREDEFINIDO_GRUPO_ID";
		public const string TEXTO_PRED_GRUPO_NOMBREColumnName = "TEXTO_PRED_GRUPO_NOMBRE";
		public const string TEXTO_PRED_GRUPO_ESTADOColumnName = "TEXTO_PRED_GRUPO_ESTADO";
		public const string TEXTO_PREDEF_G_HIJO_IDColumnName = "TEXTO_PREDEF_G_HIJO_ID";
		public const string TEXTO_PREDEF_G_HIJO_NOMBREColumnName = "TEXTO_PREDEF_G_HIJO_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TEXTO_PREDEF_GRUPO_DET_INF_COMCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TEXTO_PREDEF_GRUPO_DET_INF_COM</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects.</returns>
		public virtual TEXTO_PREDEF_GRUPO_DET_INF_COMRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TEXTO_PREDEF_GRUPO_DET_INF_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TEXTO_PREDEF_GRUPO_DET_INF_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TEXTO_PREDEF_GRUPO_DET_INF_COMRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TEXTO_PREDEF_GRUPO_DET_INF_COMRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects.</returns>
		public TEXTO_PREDEF_GRUPO_DET_INF_COMRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects that 
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
		/// <returns>An array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects.</returns>
		public virtual TEXTO_PREDEF_GRUPO_DET_INF_COMRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TEXTO_PREDEF_GRUPO_DET_INF_COM";
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
		/// <returns>An array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects.</returns>
		protected TEXTO_PREDEF_GRUPO_DET_INF_COMRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects.</returns>
		protected TEXTO_PREDEF_GRUPO_DET_INF_COMRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> objects.</returns>
		protected virtual TEXTO_PREDEF_GRUPO_DET_INF_COMRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int texto_predefinidoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO");
			int texto_predefinido_grupo_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_GRUPO_ID");
			int texto_pred_grupo_nombreColumnIndex = reader.GetOrdinal("TEXTO_PRED_GRUPO_NOMBRE");
			int texto_pred_grupo_estadoColumnIndex = reader.GetOrdinal("TEXTO_PRED_GRUPO_ESTADO");
			int texto_predef_g_hijo_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_G_HIJO_ID");
			int texto_predef_g_hijo_nombreColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_G_HIJO_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TEXTO_PREDEF_GRUPO_DET_INF_COMRow record = new TEXTO_PREDEF_GRUPO_DET_INF_COMRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinidoColumnIndex))
						record.TEXTO_PREDEFINIDO = Convert.ToString(reader.GetValue(texto_predefinidoColumnIndex));
					record.TEXTO_PREDEFINIDO_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_pred_grupo_nombreColumnIndex))
						record.TEXTO_PRED_GRUPO_NOMBRE = Convert.ToString(reader.GetValue(texto_pred_grupo_nombreColumnIndex));
					if(!reader.IsDBNull(texto_pred_grupo_estadoColumnIndex))
						record.TEXTO_PRED_GRUPO_ESTADO = Convert.ToString(reader.GetValue(texto_pred_grupo_estadoColumnIndex));
					if(!reader.IsDBNull(texto_predef_g_hijo_idColumnIndex))
						record.TEXTO_PREDEF_G_HIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predef_g_hijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predef_g_hijo_nombreColumnIndex))
						record.TEXTO_PREDEF_G_HIJO_NOMBRE = Convert.ToString(reader.GetValue(texto_predef_g_hijo_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TEXTO_PREDEF_GRUPO_DET_INF_COMRow[])(recordList.ToArray(typeof(TEXTO_PREDEF_GRUPO_DET_INF_COMRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TEXTO_PREDEF_GRUPO_DET_INF_COMRow"/> object.</returns>
		protected virtual TEXTO_PREDEF_GRUPO_DET_INF_COMRow MapRow(DataRow row)
		{
			TEXTO_PREDEF_GRUPO_DET_INF_COMRow mappedObject = new TEXTO_PREDEF_GRUPO_DET_INF_COMRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_GRUPO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_GRUPO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PRED_GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["TEXTO_PRED_GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PRED_GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "TEXTO_PRED_GRUPO_ESTADO"
			dataColumn = dataTable.Columns["TEXTO_PRED_GRUPO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PRED_GRUPO_ESTADO = (string)row[dataColumn];
			// Column "TEXTO_PREDEF_G_HIJO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_G_HIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_G_HIJO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEF_G_HIJO_NOMBRE"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_G_HIJO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_G_HIJO_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TEXTO_PREDEF_GRUPO_DET_INF_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TEXTO_PREDEF_GRUPO_DET_INF_COM";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_GRUPO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PRED_GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PRED_GRUPO_ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_G_HIJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_G_HIJO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PRED_GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PRED_GRUPO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TEXTO_PREDEF_G_HIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEF_G_HIJO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TEXTO_PREDEF_GRUPO_DET_INF_COMCollection_Base class
}  // End of namespace
