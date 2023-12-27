// <fileinfo name="TRANSFERENCIA_CAJAS_SUC_INF_CCollection_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIA_CAJAS_SUC_INF_CCollection_Base
	{
		// Constants
		public const string TRANSFERENCIA_IDColumnName = "TRANSFERENCIA_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string CAJA_SUC_ORIGEN_IDColumnName = "CAJA_SUC_ORIGEN_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CAJA_SUC_ORIGEN_NOMBREColumnName = "CAJA_SUC_ORIGEN_NOMBRE";
		public const string CAJA_SUC_DES_IDColumnName = "CAJA_SUC_DES_ID";
		public const string CAJA_SUC_DES_NOMBREColumnName = "CAJA_SUC_DES_NOMBRE";
		public const string FONDO_FIJO_ORIGEN_IDColumnName = "FONDO_FIJO_ORIGEN_ID";
		public const string FONDO_FIJO_ORIGEN_NOMBREColumnName = "FONDO_FIJO_ORIGEN_NOMBRE";
		public const string FONDO_FIJO_DES_IDColumnName = "FONDO_FIJO_DES_ID";
		public const string FONDO_FIJO_DESTINO_NOMBREColumnName = "FONDO_FIJO_DESTINO_NOMBRE";
		public const string CAJA_TESO_ORIGEN_IDColumnName = "CAJA_TESO_ORIGEN_ID";
		public const string CAJA_TESO_ORIGEN_NOMBREColumnName = "CAJA_TESO_ORIGEN_NOMBRE";
		public const string CAJA_TESO_DESTINO_IDColumnName = "CAJA_TESO_DESTINO_ID";
		public const string CAJA_TESO_DESTINO_NOMBREColumnName = "CAJA_TESO_DESTINO_NOMBRE";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSFERENCIA_CAJAS_SUC_INF_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSFERENCIA_CAJAS_SUC_INF_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUC_INF_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSFERENCIA_CAJAS_SUC_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSFERENCIA_CAJAS_SUC_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSFERENCIA_CAJAS_SUC_INF_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSFERENCIA_CAJAS_SUC_INF_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects.</returns>
		public TRANSFERENCIA_CAJAS_SUC_INF_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects.</returns>
		public virtual TRANSFERENCIA_CAJAS_SUC_INF_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSFERENCIA_CAJAS_SUC_INF_C";
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects.</returns>
		protected TRANSFERENCIA_CAJAS_SUC_INF_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects.</returns>
		protected TRANSFERENCIA_CAJAS_SUC_INF_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> objects.</returns>
		protected virtual TRANSFERENCIA_CAJAS_SUC_INF_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int transferencia_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int caja_suc_origen_idColumnIndex = reader.GetOrdinal("CAJA_SUC_ORIGEN_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int caja_suc_origen_nombreColumnIndex = reader.GetOrdinal("CAJA_SUC_ORIGEN_NOMBRE");
			int caja_suc_des_idColumnIndex = reader.GetOrdinal("CAJA_SUC_DES_ID");
			int caja_suc_des_nombreColumnIndex = reader.GetOrdinal("CAJA_SUC_DES_NOMBRE");
			int fondo_fijo_origen_idColumnIndex = reader.GetOrdinal("FONDO_FIJO_ORIGEN_ID");
			int fondo_fijo_origen_nombreColumnIndex = reader.GetOrdinal("FONDO_FIJO_ORIGEN_NOMBRE");
			int fondo_fijo_des_idColumnIndex = reader.GetOrdinal("FONDO_FIJO_DES_ID");
			int fondo_fijo_destino_nombreColumnIndex = reader.GetOrdinal("FONDO_FIJO_DESTINO_NOMBRE");
			int caja_teso_origen_idColumnIndex = reader.GetOrdinal("CAJA_TESO_ORIGEN_ID");
			int caja_teso_origen_nombreColumnIndex = reader.GetOrdinal("CAJA_TESO_ORIGEN_NOMBRE");
			int caja_teso_destino_idColumnIndex = reader.GetOrdinal("CAJA_TESO_DESTINO_ID");
			int caja_teso_destino_nombreColumnIndex = reader.GetOrdinal("CAJA_TESO_DESTINO_NOMBRE");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSFERENCIA_CAJAS_SUC_INF_CRow record = new TRANSFERENCIA_CAJAS_SUC_INF_CRow();
					recordList.Add(record);

					record.TRANSFERENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_estado_idColumnIndex))
						record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_suc_origen_idColumnIndex))
						record.CAJA_SUC_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_suc_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(caja_suc_origen_nombreColumnIndex))
						record.CAJA_SUC_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(caja_suc_origen_nombreColumnIndex));
					if(!reader.IsDBNull(caja_suc_des_idColumnIndex))
						record.CAJA_SUC_DES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_suc_des_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_suc_des_nombreColumnIndex))
						record.CAJA_SUC_DES_NOMBRE = Convert.ToString(reader.GetValue(caja_suc_des_nombreColumnIndex));
					if(!reader.IsDBNull(fondo_fijo_origen_idColumnIndex))
						record.FONDO_FIJO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fondo_fijo_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(fondo_fijo_origen_nombreColumnIndex))
						record.FONDO_FIJO_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(fondo_fijo_origen_nombreColumnIndex));
					if(!reader.IsDBNull(fondo_fijo_des_idColumnIndex))
						record.FONDO_FIJO_DES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fondo_fijo_des_idColumnIndex)), 9);
					if(!reader.IsDBNull(fondo_fijo_destino_nombreColumnIndex))
						record.FONDO_FIJO_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(fondo_fijo_destino_nombreColumnIndex));
					if(!reader.IsDBNull(caja_teso_origen_idColumnIndex))
						record.CAJA_TESO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_teso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_teso_origen_nombreColumnIndex))
						record.CAJA_TESO_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(caja_teso_origen_nombreColumnIndex));
					if(!reader.IsDBNull(caja_teso_destino_idColumnIndex))
						record.CAJA_TESO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caja_teso_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(caja_teso_destino_nombreColumnIndex))
						record.CAJA_TESO_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(caja_teso_destino_nombreColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSFERENCIA_CAJAS_SUC_INF_CRow[])(recordList.ToArray(typeof(TRANSFERENCIA_CAJAS_SUC_INF_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSFERENCIA_CAJAS_SUC_INF_CRow"/> object.</returns>
		protected virtual TRANSFERENCIA_CAJAS_SUC_INF_CRow MapRow(DataRow row)
		{
			TRANSFERENCIA_CAJAS_SUC_INF_CRow mappedObject = new TRANSFERENCIA_CAJAS_SUC_INF_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "TRANSFERENCIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "CAJA_SUC_ORIGEN_ID"
			dataColumn = dataTable.Columns["CAJA_SUC_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_SUC_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CAJA_SUC_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["CAJA_SUC_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_SUC_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "CAJA_SUC_DES_ID"
			dataColumn = dataTable.Columns["CAJA_SUC_DES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_SUC_DES_ID = (decimal)row[dataColumn];
			// Column "CAJA_SUC_DES_NOMBRE"
			dataColumn = dataTable.Columns["CAJA_SUC_DES_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_SUC_DES_NOMBRE = (string)row[dataColumn];
			// Column "FONDO_FIJO_ORIGEN_ID"
			dataColumn = dataTable.Columns["FONDO_FIJO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "FONDO_FIJO_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["FONDO_FIJO_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "FONDO_FIJO_DES_ID"
			dataColumn = dataTable.Columns["FONDO_FIJO_DES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO_DES_ID = (decimal)row[dataColumn];
			// Column "FONDO_FIJO_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["FONDO_FIJO_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "CAJA_TESO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CAJA_TESO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CAJA_TESO_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["CAJA_TESO_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESO_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "CAJA_TESO_DESTINO_ID"
			dataColumn = dataTable.Columns["CAJA_TESO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CAJA_TESO_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["CAJA_TESO_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAJA_TESO_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSFERENCIA_CAJAS_SUC_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSFERENCIA_CAJAS_SUC_INF_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_SUC_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_SUC_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_SUC_DES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_SUC_DES_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FONDO_FIJO_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FONDO_FIJO_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FONDO_FIJO_DES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FONDO_FIJO_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESO_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESO_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESO_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAJA_TESO_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
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
				case "TRANSFERENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_SUC_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAJA_SUC_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAJA_SUC_DES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_SUC_DES_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FONDO_FIJO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FONDO_FIJO_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FONDO_FIJO_DES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FONDO_FIJO_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAJA_TESO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_TESO_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CAJA_TESO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAJA_TESO_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSFERENCIA_CAJAS_SUC_INF_CCollection_Base class
}  // End of namespace
