// <fileinfo name="CAMPOS_CONF_USUARIOS_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMPOS_CONF_USUARIOS_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CAMPO_CONF_ITEM_IDColumnName = "CAMPO_CONF_ITEM_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string VALORColumnName = "VALOR";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string GRUPO_ASIGNADO_IDColumnName = "GRUPO_ASIGNADO_ID";
		public const string CAMPO_GRUPO_ASIGNADO_IDColumnName = "CAMPO_GRUPO_ASIGNADO_ID";
		public const string TIPO_DATO_IDColumnName = "TIPO_DATO_ID";
		public const string GRUPO_NOMBREColumnName = "GRUPO_NOMBRE";
		public const string CAMPO_FLUJO_IDColumnName = "CAMPO_FLUJO_ID";
		public const string FLUJO_NOMBREColumnName = "FLUJO_NOMBRE";
		public const string CAMPO_TABLA_IDColumnName = "CAMPO_TABLA_ID";
		public const string TABLA_NOMBREColumnName = "TABLA_NOMBRE";
		public const string CAMPO_NOMBREColumnName = "CAMPO_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CAMPOS_CONF_USUARIOS_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CAMPOS_CONF_USUARIOS_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects.</returns>
		public virtual CAMPOS_CONF_USUARIOS_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CAMPOS_CONF_USUARIOS_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CAMPOS_CONF_USUARIOS_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CAMPOS_CONF_USUARIOS_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CAMPOS_CONF_USUARIOS_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects.</returns>
		public CAMPOS_CONF_USUARIOS_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects.</returns>
		public virtual CAMPOS_CONF_USUARIOS_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CAMPOS_CONF_USUARIOS_INFO_COMP";
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
		/// <returns>An array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects.</returns>
		protected CAMPOS_CONF_USUARIOS_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects.</returns>
		protected CAMPOS_CONF_USUARIOS_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> objects.</returns>
		protected virtual CAMPOS_CONF_USUARIOS_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int campo_conf_item_idColumnIndex = reader.GetOrdinal("CAMPO_CONF_ITEM_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int valorColumnIndex = reader.GetOrdinal("VALOR");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int grupo_asignado_idColumnIndex = reader.GetOrdinal("GRUPO_ASIGNADO_ID");
			int campo_grupo_asignado_idColumnIndex = reader.GetOrdinal("CAMPO_GRUPO_ASIGNADO_ID");
			int tipo_dato_idColumnIndex = reader.GetOrdinal("TIPO_DATO_ID");
			int grupo_nombreColumnIndex = reader.GetOrdinal("GRUPO_NOMBRE");
			int campo_flujo_idColumnIndex = reader.GetOrdinal("CAMPO_FLUJO_ID");
			int flujo_nombreColumnIndex = reader.GetOrdinal("FLUJO_NOMBRE");
			int campo_tabla_idColumnIndex = reader.GetOrdinal("CAMPO_TABLA_ID");
			int tabla_nombreColumnIndex = reader.GetOrdinal("TABLA_NOMBRE");
			int campo_nombreColumnIndex = reader.GetOrdinal("CAMPO_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CAMPOS_CONF_USUARIOS_INFO_COMPRow record = new CAMPOS_CONF_USUARIOS_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(campo_conf_item_idColumnIndex))
						record.CAMPO_CONF_ITEM_ID = Math.Round(Convert.ToDecimal(reader.GetValue(campo_conf_item_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(valorColumnIndex))
						record.VALOR = Convert.ToString(reader.GetValue(valorColumnIndex));
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_asignado_idColumnIndex))
						record.GRUPO_ASIGNADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_asignado_idColumnIndex)), 9);
					if(!reader.IsDBNull(campo_grupo_asignado_idColumnIndex))
						record.CAMPO_GRUPO_ASIGNADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(campo_grupo_asignado_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_dato_idColumnIndex))
						record.TIPO_DATO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_dato_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_nombreColumnIndex))
						record.GRUPO_NOMBRE = Convert.ToString(reader.GetValue(grupo_nombreColumnIndex));
					if(!reader.IsDBNull(campo_flujo_idColumnIndex))
						record.CAMPO_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(campo_flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_nombreColumnIndex))
						record.FLUJO_NOMBRE = Convert.ToString(reader.GetValue(flujo_nombreColumnIndex));
					if(!reader.IsDBNull(campo_tabla_idColumnIndex))
						record.CAMPO_TABLA_ID = Convert.ToString(reader.GetValue(campo_tabla_idColumnIndex));
					if(!reader.IsDBNull(tabla_nombreColumnIndex))
						record.TABLA_NOMBRE = Convert.ToString(reader.GetValue(tabla_nombreColumnIndex));
					if(!reader.IsDBNull(campo_nombreColumnIndex))
						record.CAMPO_NOMBRE = Convert.ToString(reader.GetValue(campo_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CAMPOS_CONF_USUARIOS_INFO_COMPRow[])(recordList.ToArray(typeof(CAMPOS_CONF_USUARIOS_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CAMPOS_CONF_USUARIOS_INFO_COMPRow"/> object.</returns>
		protected virtual CAMPOS_CONF_USUARIOS_INFO_COMPRow MapRow(DataRow row)
		{
			CAMPOS_CONF_USUARIOS_INFO_COMPRow mappedObject = new CAMPOS_CONF_USUARIOS_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CAMPO_CONF_ITEM_ID"
			dataColumn = dataTable.Columns["CAMPO_CONF_ITEM_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAMPO_CONF_ITEM_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "VALOR"
			dataColumn = dataTable.Columns["VALOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR = (string)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "GRUPO_ASIGNADO_ID"
			dataColumn = dataTable.Columns["GRUPO_ASIGNADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ASIGNADO_ID = (decimal)row[dataColumn];
			// Column "CAMPO_GRUPO_ASIGNADO_ID"
			dataColumn = dataTable.Columns["CAMPO_GRUPO_ASIGNADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAMPO_GRUPO_ASIGNADO_ID = (decimal)row[dataColumn];
			// Column "TIPO_DATO_ID"
			dataColumn = dataTable.Columns["TIPO_DATO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DATO_ID = (decimal)row[dataColumn];
			// Column "GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "CAMPO_FLUJO_ID"
			dataColumn = dataTable.Columns["CAMPO_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAMPO_FLUJO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_NOMBRE"
			dataColumn = dataTable.Columns["FLUJO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_NOMBRE = (string)row[dataColumn];
			// Column "CAMPO_TABLA_ID"
			dataColumn = dataTable.Columns["CAMPO_TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAMPO_TABLA_ID = (string)row[dataColumn];
			// Column "TABLA_NOMBRE"
			dataColumn = dataTable.Columns["TABLA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_NOMBRE = (string)row[dataColumn];
			// Column "CAMPO_NOMBRE"
			dataColumn = dataTable.Columns["CAMPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAMPO_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CAMPOS_CONF_USUARIOS_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CAMPOS_CONF_USUARIOS_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAMPO_CONF_ITEM_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ASIGNADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAMPO_GRUPO_ASIGNADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DATO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAMPO_FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAMPO_TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TABLA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAMPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 400;
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

				case "CAMPO_CONF_ITEM_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ASIGNADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAMPO_GRUPO_ASIGNADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_DATO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				case "CAMPO_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAMPO_TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TABLA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAMPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CAMPOS_CONF_USUARIOS_INFO_COMPCollection_Base class
}  // End of namespace
