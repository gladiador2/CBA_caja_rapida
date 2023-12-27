// <fileinfo name="PRE_EMBARQUE_DETALLE_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRE_EMBARQUE_DETALLE_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PRE_EMBARQUE_IDColumnName = "PRE_EMBARQUE_ID";
		public const string NUMEROColumnName = "NUMERO";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSON_NOMBREColumnName = "PERSON_NOMBRE";
		public const string PERSONA_NUMERO_DOCUMENTOColumnName = "PERSONA_NUMERO_DOCUMENTO";
		public const string DESPACHO_NUMEROColumnName = "DESPACHO_NUMERO";
		public const string DESPACHO_FECHAColumnName = "DESPACHO_FECHA";
		public const string FACTURA_PAGADOColumnName = "FACTURA_PAGADO";
		public const string FACTURA_NUMEROColumnName = "FACTURA_NUMERO";
		public const string BLColumnName = "BL";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRE_EMBARQUE_DETALLE_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRE_EMBARQUE_DETALLE_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_DETALLE_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRE_EMBARQUE_DETALLE_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRE_EMBARQUE_DETALLE_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRE_EMBARQUE_DETALLE_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRE_EMBARQUE_DETALLE_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects.</returns>
		public PRE_EMBARQUE_DETALLE_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects.</returns>
		public virtual PRE_EMBARQUE_DETALLE_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRE_EMBARQUE_DETALLE_INFO_COMP";
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects.</returns>
		protected PRE_EMBARQUE_DETALLE_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects.</returns>
		protected PRE_EMBARQUE_DETALLE_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> objects.</returns>
		protected virtual PRE_EMBARQUE_DETALLE_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pre_embarque_idColumnIndex = reader.GetOrdinal("PRE_EMBARQUE_ID");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int person_nombreColumnIndex = reader.GetOrdinal("PERSON_NOMBRE");
			int persona_numero_documentoColumnIndex = reader.GetOrdinal("PERSONA_NUMERO_DOCUMENTO");
			int despacho_numeroColumnIndex = reader.GetOrdinal("DESPACHO_NUMERO");
			int despacho_fechaColumnIndex = reader.GetOrdinal("DESPACHO_FECHA");
			int factura_pagadoColumnIndex = reader.GetOrdinal("FACTURA_PAGADO");
			int factura_numeroColumnIndex = reader.GetOrdinal("FACTURA_NUMERO");
			int blColumnIndex = reader.GetOrdinal("BL");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRE_EMBARQUE_DETALLE_INFO_COMPRow record = new PRE_EMBARQUE_DETALLE_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PRE_EMBARQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pre_embarque_idColumnIndex)), 9);
					if(!reader.IsDBNull(numeroColumnIndex))
						record.NUMERO = Convert.ToString(reader.GetValue(numeroColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(person_nombreColumnIndex))
						record.PERSON_NOMBRE = Convert.ToString(reader.GetValue(person_nombreColumnIndex));
					if(!reader.IsDBNull(persona_numero_documentoColumnIndex))
						record.PERSONA_NUMERO_DOCUMENTO = Convert.ToString(reader.GetValue(persona_numero_documentoColumnIndex));
					if(!reader.IsDBNull(despacho_numeroColumnIndex))
						record.DESPACHO_NUMERO = Convert.ToString(reader.GetValue(despacho_numeroColumnIndex));
					if(!reader.IsDBNull(despacho_fechaColumnIndex))
						record.DESPACHO_FECHA = Convert.ToDateTime(reader.GetValue(despacho_fechaColumnIndex));
					if(!reader.IsDBNull(factura_pagadoColumnIndex))
						record.FACTURA_PAGADO = Convert.ToString(reader.GetValue(factura_pagadoColumnIndex));
					if(!reader.IsDBNull(factura_numeroColumnIndex))
						record.FACTURA_NUMERO = Convert.ToString(reader.GetValue(factura_numeroColumnIndex));
					if(!reader.IsDBNull(blColumnIndex))
						record.BL = Convert.ToString(reader.GetValue(blColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRE_EMBARQUE_DETALLE_INFO_COMPRow[])(recordList.ToArray(typeof(PRE_EMBARQUE_DETALLE_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRE_EMBARQUE_DETALLE_INFO_COMPRow"/> object.</returns>
		protected virtual PRE_EMBARQUE_DETALLE_INFO_COMPRow MapRow(DataRow row)
		{
			PRE_EMBARQUE_DETALLE_INFO_COMPRow mappedObject = new PRE_EMBARQUE_DETALLE_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PRE_EMBARQUE_ID"
			dataColumn = dataTable.Columns["PRE_EMBARQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRE_EMBARQUE_ID = (decimal)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSON_NOMBRE"
			dataColumn = dataTable.Columns["PERSON_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSON_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_NUMERO_DOCUMENTO"
			dataColumn = dataTable.Columns["PERSONA_NUMERO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NUMERO_DOCUMENTO = (string)row[dataColumn];
			// Column "DESPACHO_NUMERO"
			dataColumn = dataTable.Columns["DESPACHO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO_NUMERO = (string)row[dataColumn];
			// Column "DESPACHO_FECHA"
			dataColumn = dataTable.Columns["DESPACHO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO_FECHA = (System.DateTime)row[dataColumn];
			// Column "FACTURA_PAGADO"
			dataColumn = dataTable.Columns["FACTURA_PAGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_PAGADO = (string)row[dataColumn];
			// Column "FACTURA_NUMERO"
			dataColumn = dataTable.Columns["FACTURA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_NUMERO = (string)row[dataColumn];
			// Column "BL"
			dataColumn = dataTable.Columns["BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.BL = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRE_EMBARQUE_DETALLE_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRE_EMBARQUE_DETALLE_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRE_EMBARQUE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSON_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NUMERO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHO_NUMERO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHO_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_PAGADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_NUMERO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 200;
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

				case "PRE_EMBARQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSON_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NUMERO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_PAGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRE_EMBARQUE_DETALLE_INFO_COMPCollection_Base class
}  // End of namespace
