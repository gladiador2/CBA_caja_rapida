// <fileinfo name="EMPRESA_CARGOS_FUNC_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EMPRESA_CARGOS_FUNC_INFO_COMPCollection_Base
	{
		// Constants
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_NOMBREColumnName = "FUNCIONARIO_NOMBRE";
		public const string FUNCIONARIO_NOMBRE_COMPLETOColumnName = "FUNCIONARIO_NOMBRE_COMPLETO";
		public const string FUNCIONARIO_APELLIDOColumnName = "FUNCIONARIO_APELLIDO";
		public const string MARCACIONES_IDColumnName = "MARCACIONES_ID";
		public const string EMPRESA_CARGO_IDColumnName = "EMPRESA_CARGO_ID";
		public const string PORCENTAJE_CARGOColumnName = "PORCENTAJE_CARGO";
		public const string EMPRESA_CARGO_NOMBREColumnName = "EMPRESA_CARGO_NOMBRE";
		public const string EMPRESA_SECCION_IDColumnName = "EMPRESA_SECCION_ID";
		public const string EMPRESA_SECCIONES_NOMBREColumnName = "EMPRESA_SECCIONES_NOMBRE";
		public const string EMPRESA_DEPARTAMENTO_IDColumnName = "EMPRESA_DEPARTAMENTO_ID";
		public const string EMPRESA_FAJA_IDColumnName = "EMPRESA_FAJA_ID";
		public const string EMPRESA_FAJAS_NOMBREColumnName = "EMPRESA_FAJAS_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EMPRESA_CARGOS_FUNC_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EMPRESA_CARGOS_FUNC_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects.</returns>
		public virtual EMPRESA_CARGOS_FUNC_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EMPRESA_CARGOS_FUNC_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EMPRESA_CARGOS_FUNC_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EMPRESA_CARGOS_FUNC_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EMPRESA_CARGOS_FUNC_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects.</returns>
		public EMPRESA_CARGOS_FUNC_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects.</returns>
		public virtual EMPRESA_CARGOS_FUNC_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EMPRESA_CARGOS_FUNC_INFO_COMP";
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
		/// <returns>An array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects.</returns>
		protected EMPRESA_CARGOS_FUNC_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects.</returns>
		protected EMPRESA_CARGOS_FUNC_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> objects.</returns>
		protected virtual EMPRESA_CARGOS_FUNC_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE");
			int funcionario_nombre_completoColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE_COMPLETO");
			int funcionario_apellidoColumnIndex = reader.GetOrdinal("FUNCIONARIO_APELLIDO");
			int marcaciones_idColumnIndex = reader.GetOrdinal("MARCACIONES_ID");
			int empresa_cargo_idColumnIndex = reader.GetOrdinal("EMPRESA_CARGO_ID");
			int porcentaje_cargoColumnIndex = reader.GetOrdinal("PORCENTAJE_CARGO");
			int empresa_cargo_nombreColumnIndex = reader.GetOrdinal("EMPRESA_CARGO_NOMBRE");
			int empresa_seccion_idColumnIndex = reader.GetOrdinal("EMPRESA_SECCION_ID");
			int empresa_secciones_nombreColumnIndex = reader.GetOrdinal("EMPRESA_SECCIONES_NOMBRE");
			int empresa_departamento_idColumnIndex = reader.GetOrdinal("EMPRESA_DEPARTAMENTO_ID");
			int empresa_faja_idColumnIndex = reader.GetOrdinal("EMPRESA_FAJA_ID");
			int empresa_fajas_nombreColumnIndex = reader.GetOrdinal("EMPRESA_FAJAS_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EMPRESA_CARGOS_FUNC_INFO_COMPRow record = new EMPRESA_CARGOS_FUNC_INFO_COMPRow();
					recordList.Add(record);

					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.FUNCIONARIO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_nombre_completoColumnIndex))
						record.FUNCIONARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(funcionario_nombre_completoColumnIndex));
					if(!reader.IsDBNull(funcionario_apellidoColumnIndex))
						record.FUNCIONARIO_APELLIDO = Convert.ToString(reader.GetValue(funcionario_apellidoColumnIndex));
					if(!reader.IsDBNull(marcaciones_idColumnIndex))
						record.MARCACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(marcaciones_idColumnIndex)), 9);
					record.EMPRESA_CARGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(empresa_cargo_idColumnIndex)), 9);
					record.PORCENTAJE_CARGO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_cargoColumnIndex)), 9);
					record.EMPRESA_CARGO_NOMBRE = Convert.ToString(reader.GetValue(empresa_cargo_nombreColumnIndex));
					record.EMPRESA_SECCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(empresa_seccion_idColumnIndex)), 9);
					record.EMPRESA_SECCIONES_NOMBRE = Convert.ToString(reader.GetValue(empresa_secciones_nombreColumnIndex));
					record.EMPRESA_DEPARTAMENTO_ID = Convert.ToString(reader.GetValue(empresa_departamento_idColumnIndex));
					if(!reader.IsDBNull(empresa_faja_idColumnIndex))
						record.EMPRESA_FAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(empresa_faja_idColumnIndex)), 9);
					if(!reader.IsDBNull(empresa_fajas_nombreColumnIndex))
						record.EMPRESA_FAJAS_NOMBRE = Convert.ToString(reader.GetValue(empresa_fajas_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EMPRESA_CARGOS_FUNC_INFO_COMPRow[])(recordList.ToArray(typeof(EMPRESA_CARGOS_FUNC_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EMPRESA_CARGOS_FUNC_INFO_COMPRow"/> object.</returns>
		protected virtual EMPRESA_CARGOS_FUNC_INFO_COMPRow MapRow(DataRow row)
		{
			EMPRESA_CARGOS_FUNC_INFO_COMPRow mappedObject = new EMPRESA_CARGOS_FUNC_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "FUNCIONARIO_APELLIDO"
			dataColumn = dataTable.Columns["FUNCIONARIO_APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_APELLIDO = (string)row[dataColumn];
			// Column "MARCACIONES_ID"
			dataColumn = dataTable.Columns["MARCACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCACIONES_ID = (decimal)row[dataColumn];
			// Column "EMPRESA_CARGO_ID"
			dataColumn = dataTable.Columns["EMPRESA_CARGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_CARGO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_CARGO"
			dataColumn = dataTable.Columns["PORCENTAJE_CARGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_CARGO = (decimal)row[dataColumn];
			// Column "EMPRESA_CARGO_NOMBRE"
			dataColumn = dataTable.Columns["EMPRESA_CARGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_CARGO_NOMBRE = (string)row[dataColumn];
			// Column "EMPRESA_SECCION_ID"
			dataColumn = dataTable.Columns["EMPRESA_SECCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_SECCION_ID = (decimal)row[dataColumn];
			// Column "EMPRESA_SECCIONES_NOMBRE"
			dataColumn = dataTable.Columns["EMPRESA_SECCIONES_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_SECCIONES_NOMBRE = (string)row[dataColumn];
			// Column "EMPRESA_DEPARTAMENTO_ID"
			dataColumn = dataTable.Columns["EMPRESA_DEPARTAMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_DEPARTAMENTO_ID = (string)row[dataColumn];
			// Column "EMPRESA_FAJA_ID"
			dataColumn = dataTable.Columns["EMPRESA_FAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_FAJA_ID = (decimal)row[dataColumn];
			// Column "EMPRESA_FAJAS_NOMBRE"
			dataColumn = dataTable.Columns["EMPRESA_FAJAS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_FAJAS_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EMPRESA_CARGOS_FUNC_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EMPRESA_CARGOS_FUNC_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARCACIONES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_CARGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_CARGO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_CARGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_SECCION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_SECCIONES_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_DEPARTAMENTO_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_FAJA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_FAJAS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
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
				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MARCACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_CARGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_CARGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_CARGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMPRESA_SECCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_SECCIONES_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMPRESA_DEPARTAMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMPRESA_FAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_FAJAS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EMPRESA_CARGOS_FUNC_INFO_COMPCollection_Base class
}  // End of namespace
