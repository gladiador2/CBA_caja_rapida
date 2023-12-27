// <fileinfo name="ACTIVOS_MOV_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="ACTIVOS_MOV_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ACTIVOS_MOV_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ACTIVOS_MOV_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string SUCURSAL_ORIGEN_NOMBREColumnName = "SUCURSAL_ORIGEN_NOMBRE";
		public const string SUCURSAL_ORIGEN_ABREVIATURAColumnName = "SUCURSAL_ORIGEN_ABREVIATURA";
		public const string SUCURSAL_ORIGEN_REGION_IDColumnName = "SUCURSAL_ORIGEN_REGION_ID";
		public const string SUCURSAL_ORIGEN_REGION_NOMBREColumnName = "SUCURSAL_ORIGEN_REGION_NOMBRE";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string SUCURSAL_DESTINO_NOMBREColumnName = "SUCURSAL_DESTINO_NOMBRE";
		public const string SUCURSAL_DESTINO_ABREVIATURAColumnName = "SUCURSAL_DESTINO_ABREVIATURA";
		public const string SUCURSAL_DESTINO_REGION_IDColumnName = "SUCURSAL_DESTINO_REGION_ID";
		public const string SUCURSAL_DESTINO_REGION_NOMBREColumnName = "SUCURSAL_DESTINO_REGION_NOMBRE";
		public const string FECHA_MOVIMIENTOColumnName = "FECHA_MOVIMIENTO";
		public const string USUARIO_MOVIMIENTO_IDColumnName = "USUARIO_MOVIMIENTO_ID";
		public const string USUARIOColumnName = "USUARIO";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ACTIVOS_MOV_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ACTIVOS_MOV_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ACTIVOS_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects.</returns>
		public virtual ACTIVOS_MOV_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ACTIVOS_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ACTIVOS_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ACTIVOS_MOV_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ACTIVOS_MOV_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects.</returns>
		public ACTIVOS_MOV_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects.</returns>
		public virtual ACTIVOS_MOV_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ACTIVOS_MOV_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects.</returns>
		protected ACTIVOS_MOV_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects.</returns>
		protected ACTIVOS_MOV_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> objects.</returns>
		protected virtual ACTIVOS_MOV_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int sucursal_origen_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_NOMBRE");
			int sucursal_origen_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ABREVIATURA");
			int sucursal_origen_region_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_REGION_ID");
			int sucursal_origen_region_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_REGION_NOMBRE");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int sucursal_destino_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_NOMBRE");
			int sucursal_destino_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ABREVIATURA");
			int sucursal_destino_region_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_REGION_ID");
			int sucursal_destino_region_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_REGION_NOMBRE");
			int fecha_movimientoColumnIndex = reader.GetOrdinal("FECHA_MOVIMIENTO");
			int usuario_movimiento_idColumnIndex = reader.GetOrdinal("USUARIO_MOVIMIENTO_ID");
			int usuarioColumnIndex = reader.GetOrdinal("USUARIO");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ACTIVOS_MOV_INFO_COMPLETARow record = new ACTIVOS_MOV_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(sucursal_origen_nombreColumnIndex));
					record.SUCURSAL_ORIGEN_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_origen_abreviaturaColumnIndex));
					if(!reader.IsDBNull(sucursal_origen_region_idColumnIndex))
						record.SUCURSAL_ORIGEN_REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_region_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_origen_region_nombreColumnIndex))
						record.SUCURSAL_ORIGEN_REGION_NOMBRE = Convert.ToString(reader.GetValue(sucursal_origen_region_nombreColumnIndex));
					record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					record.SUCURSAL_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(sucursal_destino_nombreColumnIndex));
					record.SUCURSAL_DESTINO_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_destino_abreviaturaColumnIndex));
					if(!reader.IsDBNull(sucursal_destino_region_idColumnIndex))
						record.SUCURSAL_DESTINO_REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_region_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_region_nombreColumnIndex))
						record.SUCURSAL_DESTINO_REGION_NOMBRE = Convert.ToString(reader.GetValue(sucursal_destino_region_nombreColumnIndex));
					record.FECHA_MOVIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_movimientoColumnIndex));
					record.USUARIO_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_movimiento_idColumnIndex)), 9);
					record.USUARIO = Convert.ToString(reader.GetValue(usuarioColumnIndex));
					if(!reader.IsDBNull(usuario_nombreColumnIndex))
						record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ACTIVOS_MOV_INFO_COMPLETARow[])(recordList.ToArray(typeof(ACTIVOS_MOV_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ACTIVOS_MOV_INFO_COMPLETARow"/> object.</returns>
		protected virtual ACTIVOS_MOV_INFO_COMPLETARow MapRow(DataRow row)
		{
			ACTIVOS_MOV_INFO_COMPLETARow mappedObject = new ACTIVOS_MOV_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ABREVIATURA = (string)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_REGION_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_REGION_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_REGION_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_REGION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_REGION_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ABREVIATURA = (string)row[dataColumn];
			// Column "SUCURSAL_DESTINO_REGION_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_REGION_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_REGION_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_REGION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_REGION_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_MOVIMIENTO"
			dataColumn = dataTable.Columns["FECHA_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MOVIMIENTO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["USUARIO_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "USUARIO"
			dataColumn = dataTable.Columns["USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO = (string)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ACTIVOS_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ACTIVOS_MOV_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_REGION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_REGION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_REGION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_REGION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MOVIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_MOVIMIENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
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

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ORIGEN_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ORIGEN_REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_REGION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_DESTINO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_DESTINO_REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_REGION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ACTIVOS_MOV_INFO_COMPLETACollection_Base class
}  // End of namespace
