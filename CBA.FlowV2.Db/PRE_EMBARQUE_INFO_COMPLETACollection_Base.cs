// <fileinfo name="PRE_EMBARQUE_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="PRE_EMBARQUE_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRE_EMBARQUE_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRE_EMBARQUE_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NRO_REGISTRO_SALIDAColumnName = "NRO_REGISTRO_SALIDA";
		public const string BUQUE_IDColumnName = "BUQUE_ID";
		public const string BUQUE_DESCRIPCIONColumnName = "BUQUE_DESCRIPCION";
		public const string BUQUE_EMPRESAColumnName = "BUQUE_EMPRESA";
		public const string NRO_VIAJEColumnName = "NRO_VIAJE";
		public const string FECHAColumnName = "FECHA";
		public const string NRO_VIAJE_CMAColumnName = "NRO_VIAJE_CMA";
		public const string NRO_CARPETAColumnName = "NRO_CARPETA";
		public const string FECHA_POSIBLE_CARGAColumnName = "FECHA_POSIBLE_CARGA";
		public const string ESTADOColumnName = "ESTADO";
		public const string PUERTO_IDColumnName = "PUERTO_ID";
		public const string PUERTO_NOMBREColumnName = "PUERTO_NOMBRE";
		public const string ARMADOR_IDColumnName = "ARMADOR_ID";
		public const string ARMADOR_NOMBREColumnName = "ARMADOR_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRE_EMBARQUE_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRE_EMBARQUE_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRE_EMBARQUE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects.</returns>
		public virtual PRE_EMBARQUE_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRE_EMBARQUE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRE_EMBARQUE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRE_EMBARQUE_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRE_EMBARQUE_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects.</returns>
		public PRE_EMBARQUE_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects.</returns>
		public virtual PRE_EMBARQUE_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRE_EMBARQUE_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects.</returns>
		protected PRE_EMBARQUE_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects.</returns>
		protected PRE_EMBARQUE_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> objects.</returns>
		protected virtual PRE_EMBARQUE_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nro_registro_salidaColumnIndex = reader.GetOrdinal("NRO_REGISTRO_SALIDA");
			int buque_idColumnIndex = reader.GetOrdinal("BUQUE_ID");
			int buque_descripcionColumnIndex = reader.GetOrdinal("BUQUE_DESCRIPCION");
			int buque_empresaColumnIndex = reader.GetOrdinal("BUQUE_EMPRESA");
			int nro_viajeColumnIndex = reader.GetOrdinal("NRO_VIAJE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int nro_viaje_cmaColumnIndex = reader.GetOrdinal("NRO_VIAJE_CMA");
			int nro_carpetaColumnIndex = reader.GetOrdinal("NRO_CARPETA");
			int fecha_posible_cargaColumnIndex = reader.GetOrdinal("FECHA_POSIBLE_CARGA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int puerto_idColumnIndex = reader.GetOrdinal("PUERTO_ID");
			int puerto_nombreColumnIndex = reader.GetOrdinal("PUERTO_NOMBRE");
			int armador_idColumnIndex = reader.GetOrdinal("ARMADOR_ID");
			int armador_nombreColumnIndex = reader.GetOrdinal("ARMADOR_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRE_EMBARQUE_INFO_COMPLETARow record = new PRE_EMBARQUE_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_registro_salidaColumnIndex))
						record.NRO_REGISTRO_SALIDA = Convert.ToString(reader.GetValue(nro_registro_salidaColumnIndex));
					if(!reader.IsDBNull(buque_idColumnIndex))
						record.BUQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(buque_idColumnIndex)), 9);
					if(!reader.IsDBNull(buque_descripcionColumnIndex))
						record.BUQUE_DESCRIPCION = Convert.ToString(reader.GetValue(buque_descripcionColumnIndex));
					if(!reader.IsDBNull(buque_empresaColumnIndex))
						record.BUQUE_EMPRESA = Convert.ToString(reader.GetValue(buque_empresaColumnIndex));
					if(!reader.IsDBNull(nro_viajeColumnIndex))
						record.NRO_VIAJE = Convert.ToString(reader.GetValue(nro_viajeColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(nro_viaje_cmaColumnIndex))
						record.NRO_VIAJE_CMA = Convert.ToString(reader.GetValue(nro_viaje_cmaColumnIndex));
					if(!reader.IsDBNull(nro_carpetaColumnIndex))
						record.NRO_CARPETA = Convert.ToString(reader.GetValue(nro_carpetaColumnIndex));
					if(!reader.IsDBNull(fecha_posible_cargaColumnIndex))
						record.FECHA_POSIBLE_CARGA = Convert.ToDateTime(reader.GetValue(fecha_posible_cargaColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(puerto_idColumnIndex))
						record.PUERTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_nombreColumnIndex))
						record.PUERTO_NOMBRE = Convert.ToString(reader.GetValue(puerto_nombreColumnIndex));
					if(!reader.IsDBNull(armador_idColumnIndex))
						record.ARMADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(armador_idColumnIndex)), 9);
					if(!reader.IsDBNull(armador_nombreColumnIndex))
						record.ARMADOR_NOMBRE = Convert.ToString(reader.GetValue(armador_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRE_EMBARQUE_INFO_COMPLETARow[])(recordList.ToArray(typeof(PRE_EMBARQUE_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRE_EMBARQUE_INFO_COMPLETARow"/> object.</returns>
		protected virtual PRE_EMBARQUE_INFO_COMPLETARow MapRow(DataRow row)
		{
			PRE_EMBARQUE_INFO_COMPLETARow mappedObject = new PRE_EMBARQUE_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NRO_REGISTRO_SALIDA"
			dataColumn = dataTable.Columns["NRO_REGISTRO_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_REGISTRO_SALIDA = (string)row[dataColumn];
			// Column "BUQUE_ID"
			dataColumn = dataTable.Columns["BUQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE_ID = (decimal)row[dataColumn];
			// Column "BUQUE_DESCRIPCION"
			dataColumn = dataTable.Columns["BUQUE_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE_DESCRIPCION = (string)row[dataColumn];
			// Column "BUQUE_EMPRESA"
			dataColumn = dataTable.Columns["BUQUE_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE_EMPRESA = (string)row[dataColumn];
			// Column "NRO_VIAJE"
			dataColumn = dataTable.Columns["NRO_VIAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_VIAJE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "NRO_VIAJE_CMA"
			dataColumn = dataTable.Columns["NRO_VIAJE_CMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_VIAJE_CMA = (string)row[dataColumn];
			// Column "NRO_CARPETA"
			dataColumn = dataTable.Columns["NRO_CARPETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CARPETA = (string)row[dataColumn];
			// Column "FECHA_POSIBLE_CARGA"
			dataColumn = dataTable.Columns["FECHA_POSIBLE_CARGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSIBLE_CARGA = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PUERTO_ID"
			dataColumn = dataTable.Columns["PUERTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ID = (decimal)row[dataColumn];
			// Column "PUERTO_NOMBRE"
			dataColumn = dataTable.Columns["PUERTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_NOMBRE = (string)row[dataColumn];
			// Column "ARMADOR_ID"
			dataColumn = dataTable.Columns["ARMADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARMADOR_ID = (decimal)row[dataColumn];
			// Column "ARMADOR_NOMBRE"
			dataColumn = dataTable.Columns["ARMADOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARMADOR_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRE_EMBARQUE_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRE_EMBARQUE_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_REGISTRO_SALIDA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BUQUE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BUQUE_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BUQUE_EMPRESA", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_VIAJE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_VIAJE_CMA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_CARPETA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_POSIBLE_CARGA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARMADOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARMADOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "NRO_REGISTRO_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BUQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BUQUE_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BUQUE_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_VIAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_VIAJE_CMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_CARPETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_POSIBLE_CARGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PUERTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARMADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARMADOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRE_EMBARQUE_INFO_COMPLETACollection_Base class
}  // End of namespace
