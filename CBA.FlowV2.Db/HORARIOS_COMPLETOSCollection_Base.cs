// <fileinfo name="HORARIOS_COMPLETOSCollection_Base.cs">
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
	/// The base class for <see cref="HORARIOS_COMPLETOSCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="HORARIOS_COMPLETOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOS_COMPLETOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PARA_FECHAColumnName = "PARA_FECHA";
		public const string FECHAColumnName = "FECHA";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string NOMBRE_COMPLETOColumnName = "NOMBRE_COMPLETO";
		public const string MARCACIONES_IDColumnName = "MARCACIONES_ID";
		public const string HORA_INICIOColumnName = "HORA_INICIO";
		public const string HORA_FINColumnName = "HORA_FIN";
		public const string MINUTOS_ANTES_ENTRADAColumnName = "MINUTOS_ANTES_ENTRADA";
		public const string MINUTOS_ANTES_SALIDAColumnName = "MINUTOS_ANTES_SALIDA";
		public const string MINUTOS_DESPUES_ENTRADAColumnName = "MINUTOS_DESPUES_ENTRADA";
		public const string MINUTOS_DESPUES_SALIDAColumnName = "MINUTOS_DESPUES_SALIDA";
		public const string DIA_IDColumnName = "DIA_ID";
		public const string TURNO_IDColumnName = "TURNO_ID";
		public const string NIVEL_ASIGNACIONColumnName = "NIVEL_ASIGNACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_COMPLETOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public HORARIOS_COMPLETOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>HORARIOS_COMPLETOS</c> view.
		/// </summary>
		/// <returns>An array of <see cref="HORARIOS_COMPLETOSRow"/> objects.</returns>
		public virtual HORARIOS_COMPLETOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>HORARIOS_COMPLETOS</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>HORARIOS_COMPLETOS</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="HORARIOS_COMPLETOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="HORARIOS_COMPLETOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public HORARIOS_COMPLETOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			HORARIOS_COMPLETOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_COMPLETOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="HORARIOS_COMPLETOSRow"/> objects.</returns>
		public HORARIOS_COMPLETOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_COMPLETOSRow"/> objects that 
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
		/// <returns>An array of <see cref="HORARIOS_COMPLETOSRow"/> objects.</returns>
		public virtual HORARIOS_COMPLETOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.HORARIOS_COMPLETOS";
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
		/// <returns>An array of <see cref="HORARIOS_COMPLETOSRow"/> objects.</returns>
		protected HORARIOS_COMPLETOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="HORARIOS_COMPLETOSRow"/> objects.</returns>
		protected HORARIOS_COMPLETOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="HORARIOS_COMPLETOSRow"/> objects.</returns>
		protected virtual HORARIOS_COMPLETOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int para_fechaColumnIndex = reader.GetOrdinal("PARA_FECHA");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int nombre_completoColumnIndex = reader.GetOrdinal("NOMBRE_COMPLETO");
			int marcaciones_idColumnIndex = reader.GetOrdinal("MARCACIONES_ID");
			int hora_inicioColumnIndex = reader.GetOrdinal("HORA_INICIO");
			int hora_finColumnIndex = reader.GetOrdinal("HORA_FIN");
			int minutos_antes_entradaColumnIndex = reader.GetOrdinal("MINUTOS_ANTES_ENTRADA");
			int minutos_antes_salidaColumnIndex = reader.GetOrdinal("MINUTOS_ANTES_SALIDA");
			int minutos_despues_entradaColumnIndex = reader.GetOrdinal("MINUTOS_DESPUES_ENTRADA");
			int minutos_despues_salidaColumnIndex = reader.GetOrdinal("MINUTOS_DESPUES_SALIDA");
			int dia_idColumnIndex = reader.GetOrdinal("DIA_ID");
			int turno_idColumnIndex = reader.GetOrdinal("TURNO_ID");
			int nivel_asignacionColumnIndex = reader.GetOrdinal("NIVEL_ASIGNACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					HORARIOS_COMPLETOSRow record = new HORARIOS_COMPLETOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(para_fechaColumnIndex))
						record.PARA_FECHA = Convert.ToString(reader.GetValue(para_fechaColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_completoColumnIndex))
						record.NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(nombre_completoColumnIndex));
					if(!reader.IsDBNull(marcaciones_idColumnIndex))
						record.MARCACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(marcaciones_idColumnIndex)), 9);
					record.HORA_INICIO = Convert.ToDateTime(reader.GetValue(hora_inicioColumnIndex));
					record.HORA_FIN = Convert.ToDateTime(reader.GetValue(hora_finColumnIndex));
					if(!reader.IsDBNull(minutos_antes_entradaColumnIndex))
						record.MINUTOS_ANTES_ENTRADA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_antes_entradaColumnIndex)), 9);
					if(!reader.IsDBNull(minutos_antes_salidaColumnIndex))
						record.MINUTOS_ANTES_SALIDA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_antes_salidaColumnIndex)), 9);
					if(!reader.IsDBNull(minutos_despues_entradaColumnIndex))
						record.MINUTOS_DESPUES_ENTRADA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_despues_entradaColumnIndex)), 9);
					if(!reader.IsDBNull(minutos_despues_salidaColumnIndex))
						record.MINUTOS_DESPUES_SALIDA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_despues_salidaColumnIndex)), 9);
					if(!reader.IsDBNull(dia_idColumnIndex))
						record.DIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(dia_idColumnIndex)), 9);
					record.TURNO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(turno_idColumnIndex)), 9);
					if(!reader.IsDBNull(nivel_asignacionColumnIndex))
						record.NIVEL_ASIGNACION = Math.Round(Convert.ToDecimal(reader.GetValue(nivel_asignacionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (HORARIOS_COMPLETOSRow[])(recordList.ToArray(typeof(HORARIOS_COMPLETOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="HORARIOS_COMPLETOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="HORARIOS_COMPLETOSRow"/> object.</returns>
		protected virtual HORARIOS_COMPLETOSRow MapRow(DataRow row)
		{
			HORARIOS_COMPLETOSRow mappedObject = new HORARIOS_COMPLETOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PARA_FECHA"
			dataColumn = dataTable.Columns["PARA_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARA_FECHA = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "MARCACIONES_ID"
			dataColumn = dataTable.Columns["MARCACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCACIONES_ID = (decimal)row[dataColumn];
			// Column "HORA_INICIO"
			dataColumn = dataTable.Columns["HORA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_INICIO = (System.DateTime)row[dataColumn];
			// Column "HORA_FIN"
			dataColumn = dataTable.Columns["HORA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_FIN = (System.DateTime)row[dataColumn];
			// Column "MINUTOS_ANTES_ENTRADA"
			dataColumn = dataTable.Columns["MINUTOS_ANTES_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_ANTES_ENTRADA = (decimal)row[dataColumn];
			// Column "MINUTOS_ANTES_SALIDA"
			dataColumn = dataTable.Columns["MINUTOS_ANTES_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_ANTES_SALIDA = (decimal)row[dataColumn];
			// Column "MINUTOS_DESPUES_ENTRADA"
			dataColumn = dataTable.Columns["MINUTOS_DESPUES_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_DESPUES_ENTRADA = (decimal)row[dataColumn];
			// Column "MINUTOS_DESPUES_SALIDA"
			dataColumn = dataTable.Columns["MINUTOS_DESPUES_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_DESPUES_SALIDA = (decimal)row[dataColumn];
			// Column "DIA_ID"
			dataColumn = dataTable.Columns["DIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIA_ID = (decimal)row[dataColumn];
			// Column "TURNO_ID"
			dataColumn = dataTable.Columns["TURNO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ID = (decimal)row[dataColumn];
			// Column "NIVEL_ASIGNACION"
			dataColumn = dataTable.Columns["NIVEL_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL_ASIGNACION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>HORARIOS_COMPLETOS</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "HORARIOS_COMPLETOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PARA_FECHA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARCACIONES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HORA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HORA_FIN", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MINUTOS_ANTES_ENTRADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MINUTOS_ANTES_SALIDA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MINUTOS_DESPUES_ENTRADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MINUTOS_DESPUES_SALIDA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NIVEL_ASIGNACION", typeof(decimal));
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

				case "PARA_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MARCACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HORA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "HORA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MINUTOS_ANTES_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MINUTOS_ANTES_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MINUTOS_DESPUES_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MINUTOS_DESPUES_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TURNO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NIVEL_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of HORARIOS_COMPLETOSCollection_Base class
}  // End of namespace
