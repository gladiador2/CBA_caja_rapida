// <fileinfo name="IMPORTACION_ARTICULOS_PEDIDOSCollection_Base.cs">
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
	/// The base class for <see cref="IMPORTACION_ARTICULOS_PEDIDOSCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="IMPORTACION_ARTICULOS_PEDIDOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACION_ARTICULOS_PEDIDOSCollection_Base
	{
		// Constants
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string CANTIDAD_IMPORTACIONColumnName = "CANTIDAD_IMPORTACION";
		public const string CANTIDAD_PEDIDOSColumnName = "CANTIDAD_PEDIDOS";
		public const string DESCRIPCION_INTERNAColumnName = "DESCRIPCION_INTERNA";
		public const string EXISTENCIAColumnName = "EXISTENCIA";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string FAMILIA_DESCRIPCIONColumnName = "FAMILIA_DESCRIPCION";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string GRUPO_DESCRIPCIONColumnName = "GRUPO_DESCRIPCION";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string SUBGRUPO_DESCRIPCIONColumnName = "SUBGRUPO_DESCRIPCION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACION_ARTICULOS_PEDIDOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public IMPORTACION_ARTICULOS_PEDIDOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>IMPORTACION_ARTICULOS_PEDIDOS</c> view.
		/// </summary>
		/// <returns>An array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects.</returns>
		public virtual IMPORTACION_ARTICULOS_PEDIDOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>IMPORTACION_ARTICULOS_PEDIDOS</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>IMPORTACION_ARTICULOS_PEDIDOS</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public IMPORTACION_ARTICULOS_PEDIDOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			IMPORTACION_ARTICULOS_PEDIDOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects.</returns>
		public IMPORTACION_ARTICULOS_PEDIDOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects that 
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
		/// <returns>An array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects.</returns>
		public virtual IMPORTACION_ARTICULOS_PEDIDOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.IMPORTACION_ARTICULOS_PEDIDOS";
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
		/// <returns>An array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects.</returns>
		protected IMPORTACION_ARTICULOS_PEDIDOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects.</returns>
		protected IMPORTACION_ARTICULOS_PEDIDOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> objects.</returns>
		protected virtual IMPORTACION_ARTICULOS_PEDIDOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int cantidad_importacionColumnIndex = reader.GetOrdinal("CANTIDAD_IMPORTACION");
			int cantidad_pedidosColumnIndex = reader.GetOrdinal("CANTIDAD_PEDIDOS");
			int descripcion_internaColumnIndex = reader.GetOrdinal("DESCRIPCION_INTERNA");
			int existenciaColumnIndex = reader.GetOrdinal("EXISTENCIA");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int familia_descripcionColumnIndex = reader.GetOrdinal("FAMILIA_DESCRIPCION");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int grupo_descripcionColumnIndex = reader.GetOrdinal("GRUPO_DESCRIPCION");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int subgrupo_descripcionColumnIndex = reader.GetOrdinal("SUBGRUPO_DESCRIPCION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					IMPORTACION_ARTICULOS_PEDIDOSRow record = new IMPORTACION_ARTICULOS_PEDIDOSRow();
					recordList.Add(record);

					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_importacionColumnIndex))
						record.CANTIDAD_IMPORTACION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_importacionColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_pedidosColumnIndex))
						record.CANTIDAD_PEDIDOS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_pedidosColumnIndex)), 9);
					if(!reader.IsDBNull(descripcion_internaColumnIndex))
						record.DESCRIPCION_INTERNA = Convert.ToString(reader.GetValue(descripcion_internaColumnIndex));
					if(!reader.IsDBNull(existenciaColumnIndex))
						record.EXISTENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(existenciaColumnIndex)), 9);
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(familia_descripcionColumnIndex))
						record.FAMILIA_DESCRIPCION = Convert.ToString(reader.GetValue(familia_descripcionColumnIndex));
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_descripcionColumnIndex))
						record.GRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(grupo_descripcionColumnIndex));
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(subgrupo_descripcionColumnIndex))
						record.SUBGRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(subgrupo_descripcionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (IMPORTACION_ARTICULOS_PEDIDOSRow[])(recordList.ToArray(typeof(IMPORTACION_ARTICULOS_PEDIDOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> object.</returns>
		protected virtual IMPORTACION_ARTICULOS_PEDIDOSRow MapRow(DataRow row)
		{
			IMPORTACION_ARTICULOS_PEDIDOSRow mappedObject = new IMPORTACION_ARTICULOS_PEDIDOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_IMPORTACION"
			dataColumn = dataTable.Columns["CANTIDAD_IMPORTACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_IMPORTACION = (decimal)row[dataColumn];
			// Column "CANTIDAD_PEDIDOS"
			dataColumn = dataTable.Columns["CANTIDAD_PEDIDOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_PEDIDOS = (decimal)row[dataColumn];
			// Column "DESCRIPCION_INTERNA"
			dataColumn = dataTable.Columns["DESCRIPCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_INTERNA = (string)row[dataColumn];
			// Column "EXISTENCIA"
			dataColumn = dataTable.Columns["EXISTENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA = (decimal)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "FAMILIA_DESCRIPCION"
			dataColumn = dataTable.Columns["FAMILIA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_DESCRIPCION = (string)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "GRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["GRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "SUBGRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["SUBGRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_DESCRIPCION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>IMPORTACION_ARTICULOS_PEDIDOS</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "IMPORTACION_ARTICULOS_PEDIDOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_IMPORTACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_PEDIDOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXISTENCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
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
				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_IMPORTACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_PEDIDOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCRIPCION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EXISTENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FAMILIA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of IMPORTACION_ARTICULOS_PEDIDOSCollection_Base class
}  // End of namespace
