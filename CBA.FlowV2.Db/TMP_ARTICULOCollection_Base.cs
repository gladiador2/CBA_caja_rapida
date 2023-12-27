// <fileinfo name="TMP_ARTICULOCollection_Base.cs">
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
	/// The base class for <see cref="TMP_ARTICULOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TMP_ARTICULOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TMP_ARTICULOCollection_Base
	{
		// Constants
		public const string CLAVEColumnName = "CLAVE";
		public const string IDColumnName = "ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string SUB_GRUPO_IDColumnName = "SUB_GRUPO_ID";
		public const string DESCRIPCION_INTERNAColumnName = "DESCRIPCION_INTERNA";
		public const string DESCRIPCION_IMPRESIONColumnName = "DESCRIPCION_IMPRESION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TMP_ARTICULOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TMP_ARTICULOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TMP_ARTICULO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TMP_ARTICULORow"/> objects.</returns>
		public virtual TMP_ARTICULORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TMP_ARTICULO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TMP_ARTICULO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TMP_ARTICULORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TMP_ARTICULORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TMP_ARTICULORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TMP_ARTICULORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TMP_ARTICULORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TMP_ARTICULORow"/> objects.</returns>
		public TMP_ARTICULORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TMP_ARTICULORow"/> objects that 
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
		/// <returns>An array of <see cref="TMP_ARTICULORow"/> objects.</returns>
		public virtual TMP_ARTICULORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TMP_ARTICULO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Adds a new record into the <c>TMP_ARTICULO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TMP_ARTICULORow"/> object to be inserted.</param>
		public virtual void Insert(TMP_ARTICULORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TMP_ARTICULO (" +
				"CLAVE, " +
				"ID, " +
				"CODIGO, " +
				"FAMILIA_ID, " +
				"GRUPO_ID, " +
				"SUB_GRUPO_ID, " +
				"DESCRIPCION_INTERNA, " +
				"DESCRIPCION_IMPRESION" +
				") VALUES (" +
				_db.CreateSqlParameterName("CLAVE") + ", " +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				_db.CreateSqlParameterName("GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("SUB_GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION_INTERNA") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION_IMPRESION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CLAVE",
				value.IsCLAVENull ? DBNull.Value : (object)value.CLAVE);
			AddParameter(cmd, "ID",
				value.IsIDNull ? DBNull.Value : (object)value.ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "FAMILIA_ID",
				value.IsFAMILIA_IDNull ? DBNull.Value : (object)value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUB_GRUPO_ID",
				value.IsSUB_GRUPO_IDNull ? DBNull.Value : (object)value.SUB_GRUPO_ID);
			AddParameter(cmd, "DESCRIPCION_INTERNA", value.DESCRIPCION_INTERNA);
			AddParameter(cmd, "DESCRIPCION_IMPRESION", value.DESCRIPCION_IMPRESION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes <c>TMP_ARTICULO</c> records that match the specified criteria.
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
		/// to delete <c>TMP_ARTICULO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TMP_ARTICULO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TMP_ARTICULO</c> table.
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
		/// <returns>An array of <see cref="TMP_ARTICULORow"/> objects.</returns>
		protected TMP_ARTICULORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TMP_ARTICULORow"/> objects.</returns>
		protected TMP_ARTICULORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TMP_ARTICULORow"/> objects.</returns>
		protected virtual TMP_ARTICULORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int claveColumnIndex = reader.GetOrdinal("CLAVE");
			int idColumnIndex = reader.GetOrdinal("ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int sub_grupo_idColumnIndex = reader.GetOrdinal("SUB_GRUPO_ID");
			int descripcion_internaColumnIndex = reader.GetOrdinal("DESCRIPCION_INTERNA");
			int descripcion_impresionColumnIndex = reader.GetOrdinal("DESCRIPCION_IMPRESION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TMP_ARTICULORow record = new TMP_ARTICULORow();
					recordList.Add(record);

					if(!reader.IsDBNull(claveColumnIndex))
						record.CLAVE = Math.Round(Convert.ToDecimal(reader.GetValue(claveColumnIndex)), 9);
					if(!reader.IsDBNull(idColumnIndex))
						record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(sub_grupo_idColumnIndex))
						record.SUB_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sub_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(descripcion_internaColumnIndex))
						record.DESCRIPCION_INTERNA = Convert.ToString(reader.GetValue(descripcion_internaColumnIndex));
					if(!reader.IsDBNull(descripcion_impresionColumnIndex))
						record.DESCRIPCION_IMPRESION = Convert.ToString(reader.GetValue(descripcion_impresionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TMP_ARTICULORow[])(recordList.ToArray(typeof(TMP_ARTICULORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TMP_ARTICULORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TMP_ARTICULORow"/> object.</returns>
		protected virtual TMP_ARTICULORow MapRow(DataRow row)
		{
			TMP_ARTICULORow mappedObject = new TMP_ARTICULORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "CLAVE"
			dataColumn = dataTable.Columns["CLAVE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLAVE = (decimal)row[dataColumn];
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "SUB_GRUPO_ID"
			dataColumn = dataTable.Columns["SUB_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUB_GRUPO_ID = (decimal)row[dataColumn];
			// Column "DESCRIPCION_INTERNA"
			dataColumn = dataTable.Columns["DESCRIPCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_INTERNA = (string)row[dataColumn];
			// Column "DESCRIPCION_IMPRESION"
			dataColumn = dataTable.Columns["DESCRIPCION_IMPRESION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_IMPRESION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TMP_ARTICULO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TMP_ARTICULO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("CLAVE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUB_GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCRIPCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_IMPRESION", typeof(string));
			dataColumn.MaxLength = 900;
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
				case "CLAVE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUB_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCRIPCION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_IMPRESION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TMP_ARTICULOCollection_Base class
}  // End of namespace
