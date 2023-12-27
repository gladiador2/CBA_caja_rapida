// <fileinfo name="CAMIONES_CONF_TARA_ACTIVOCollection_Base.cs">
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
	/// The base class for <see cref="CAMIONES_CONF_TARA_ACTIVOCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CAMIONES_CONF_TARA_ACTIVOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMIONES_CONF_TARA_ACTIVOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_HORAColumnName = "FECHA_HORA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string USUARIOColumnName = "USUARIO";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";
		public const string TARAColumnName = "TARA";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string TRANSPORTADORA_PERSONA_IDColumnName = "TRANSPORTADORA_PERSONA_ID";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string CONSIGNATARIO_PERSONA_IDColumnName = "CONSIGNATARIO_PERSONA_ID";
		public const string CONSIGNATARIO_NOMBREColumnName = "CONSIGNATARIO_NOMBRE";
		public const string TIPO_VEHICULO_IDColumnName = "TIPO_VEHICULO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMIONES_CONF_TARA_ACTIVOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CAMIONES_CONF_TARA_ACTIVOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CAMIONES_CONF_TARA_ACTIVO</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects.</returns>
		public virtual CAMIONES_CONF_TARA_ACTIVORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CAMIONES_CONF_TARA_ACTIVO</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CAMIONES_CONF_TARA_ACTIVO</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CAMIONES_CONF_TARA_ACTIVORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CAMIONES_CONF_TARA_ACTIVORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects.</returns>
		public CAMIONES_CONF_TARA_ACTIVORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects that 
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
		/// <returns>An array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects.</returns>
		public virtual CAMIONES_CONF_TARA_ACTIVORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CAMIONES_CONF_TARA_ACTIVO";
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
		/// <returns>An array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects.</returns>
		protected CAMIONES_CONF_TARA_ACTIVORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects.</returns>
		protected CAMIONES_CONF_TARA_ACTIVORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> objects.</returns>
		protected virtual CAMIONES_CONF_TARA_ACTIVORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_horaColumnIndex = reader.GetOrdinal("FECHA_HORA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int usuarioColumnIndex = reader.GetOrdinal("USUARIO");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");
			int taraColumnIndex = reader.GetOrdinal("TARA");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int transportadora_persona_idColumnIndex = reader.GetOrdinal("TRANSPORTADORA_PERSONA_ID");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int consignatario_persona_idColumnIndex = reader.GetOrdinal("CONSIGNATARIO_PERSONA_ID");
			int consignatario_nombreColumnIndex = reader.GetOrdinal("CONSIGNATARIO_NOMBRE");
			int tipo_vehiculo_idColumnIndex = reader.GetOrdinal("TIPO_VEHICULO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CAMIONES_CONF_TARA_ACTIVORow record = new CAMIONES_CONF_TARA_ACTIVORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_horaColumnIndex))
						record.FECHA_HORA = Convert.ToDateTime(reader.GetValue(fecha_horaColumnIndex));
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.USUARIO = Convert.ToString(reader.GetValue(usuarioColumnIndex));
					if(!reader.IsDBNull(usuario_nombreColumnIndex))
						record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));
					if(!reader.IsDBNull(taraColumnIndex))
						record.TARA = Math.Round(Convert.ToDecimal(reader.GetValue(taraColumnIndex)), 9);
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(transportadora_persona_idColumnIndex))
						record.TRANSPORTADORA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transportadora_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(consignatario_persona_idColumnIndex))
						record.CONSIGNATARIO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(consignatario_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_nombreColumnIndex))
						record.CONSIGNATARIO_NOMBRE = Convert.ToString(reader.GetValue(consignatario_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_vehiculo_idColumnIndex))
						record.TIPO_VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_vehiculo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CAMIONES_CONF_TARA_ACTIVORow[])(recordList.ToArray(typeof(CAMIONES_CONF_TARA_ACTIVORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CAMIONES_CONF_TARA_ACTIVORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CAMIONES_CONF_TARA_ACTIVORow"/> object.</returns>
		protected virtual CAMIONES_CONF_TARA_ACTIVORow MapRow(DataRow row)
		{
			CAMIONES_CONF_TARA_ACTIVORow mappedObject = new CAMIONES_CONF_TARA_ACTIVORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_HORA"
			dataColumn = dataTable.Columns["FECHA_HORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HORA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "USUARIO"
			dataColumn = dataTable.Columns["USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO = (string)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "TARA"
			dataColumn = dataTable.Columns["TARA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA = (decimal)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "TRANSPORTADORA_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSPORTADORA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "CONSIGNATARIO_PERSONA_ID"
			dataColumn = dataTable.Columns["CONSIGNATARIO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_NOMBRE"
			dataColumn = dataTable.Columns["CONSIGNATARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_VEHICULO_ID"
			dataColumn = dataTable.Columns["TIPO_VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_VEHICULO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CAMIONES_CONF_TARA_ACTIVO</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CAMIONES_CONF_TARA_ACTIVO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_HORA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_VEHICULO_ID", typeof(decimal));
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

				case "FECHA_HORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSIGNATARIO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CAMIONES_CONF_TARA_ACTIVOCollection_Base class
}  // End of namespace
