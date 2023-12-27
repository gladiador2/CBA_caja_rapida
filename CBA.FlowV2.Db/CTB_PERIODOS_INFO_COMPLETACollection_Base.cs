// <fileinfo name="CTB_PERIODOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTB_PERIODOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_PERIODOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_PERIODOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string EJERCICIO_PLAN_CUENTA_IDColumnName = "EJERCICIO_PLAN_CUENTA_ID";
		public const string CTB_EJERCICIO_IDColumnName = "CTB_EJERCICIO_ID";
		public const string EJERCICIO_NOMBREColumnName = "EJERCICIO_NOMBRE";
		public const string EJERCICIO_PAIS_IDColumnName = "EJERCICIO_PAIS_ID";
		public const string EJERCICIO_REGION_IDColumnName = "EJERCICIO_REGION_ID";
		public const string EJERCICIO_SUCURSAL_IDColumnName = "EJERCICIO_SUCURSAL_ID";
		public const string EJERCICIO_SE_ABRIOColumnName = "EJERCICIO_SE_ABRIO";
		public const string EJERCICIO_SE_CERROColumnName = "EJERCICIO_SE_CERRO";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string ESTADOColumnName = "ESTADO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string USUARIO_CREACION_NOMBREColumnName = "USUARIO_CREACION_NOMBRE";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_INACTIVACION_IDColumnName = "USUARIO_INACTIVACION_ID";
		public const string USUARIO_INACTIVACION_NOMBREColumnName = "USUARIO_INACTIVACION_NOMBRE";
		public const string FECHA_INACTIVACIONColumnName = "FECHA_INACTIVACION";
		public const string VIGENTEColumnName = "VIGENTE";
		public const string VIGENTE_POR_MARGENColumnName = "VIGENTE_POR_MARGEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_PERIODOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_PERIODOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_PERIODOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_PERIODOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_PERIODOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_PERIODOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_PERIODOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_PERIODOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects.</returns>
		public CTB_PERIODOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_PERIODOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_PERIODOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_PERIODOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_PERIODOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTB_PERIODOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int ejercicio_plan_cuenta_idColumnIndex = reader.GetOrdinal("EJERCICIO_PLAN_CUENTA_ID");
			int ctb_ejercicio_idColumnIndex = reader.GetOrdinal("CTB_EJERCICIO_ID");
			int ejercicio_nombreColumnIndex = reader.GetOrdinal("EJERCICIO_NOMBRE");
			int ejercicio_pais_idColumnIndex = reader.GetOrdinal("EJERCICIO_PAIS_ID");
			int ejercicio_region_idColumnIndex = reader.GetOrdinal("EJERCICIO_REGION_ID");
			int ejercicio_sucursal_idColumnIndex = reader.GetOrdinal("EJERCICIO_SUCURSAL_ID");
			int ejercicio_se_abrioColumnIndex = reader.GetOrdinal("EJERCICIO_SE_ABRIO");
			int ejercicio_se_cerroColumnIndex = reader.GetOrdinal("EJERCICIO_SE_CERRO");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int usuario_creacion_nombreColumnIndex = reader.GetOrdinal("USUARIO_CREACION_NOMBRE");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_inactivacion_idColumnIndex = reader.GetOrdinal("USUARIO_INACTIVACION_ID");
			int usuario_inactivacion_nombreColumnIndex = reader.GetOrdinal("USUARIO_INACTIVACION_NOMBRE");
			int fecha_inactivacionColumnIndex = reader.GetOrdinal("FECHA_INACTIVACION");
			int vigenteColumnIndex = reader.GetOrdinal("VIGENTE");
			int vigente_por_margenColumnIndex = reader.GetOrdinal("VIGENTE_POR_MARGEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_PERIODOS_INFO_COMPLETARow record = new CTB_PERIODOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.EJERCICIO_PLAN_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ejercicio_plan_cuenta_idColumnIndex)), 9);
					record.CTB_EJERCICIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_ejercicio_idColumnIndex)), 9);
					record.EJERCICIO_NOMBRE = Convert.ToString(reader.GetValue(ejercicio_nombreColumnIndex));
					record.EJERCICIO_PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ejercicio_pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(ejercicio_region_idColumnIndex))
						record.EJERCICIO_REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ejercicio_region_idColumnIndex)), 9);
					if(!reader.IsDBNull(ejercicio_sucursal_idColumnIndex))
						record.EJERCICIO_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ejercicio_sucursal_idColumnIndex)), 9);
					record.EJERCICIO_SE_ABRIO = Convert.ToString(reader.GetValue(ejercicio_se_abrioColumnIndex));
					record.EJERCICIO_SE_CERRO = Convert.ToString(reader.GetValue(ejercicio_se_cerroColumnIndex));
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creacion_nombreColumnIndex))
						record.USUARIO_CREACION_NOMBRE = Convert.ToString(reader.GetValue(usuario_creacion_nombreColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(usuario_inactivacion_idColumnIndex))
						record.USUARIO_INACTIVACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_inactivacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_inactivacion_nombreColumnIndex))
						record.USUARIO_INACTIVACION_NOMBRE = Convert.ToString(reader.GetValue(usuario_inactivacion_nombreColumnIndex));
					if(!reader.IsDBNull(fecha_inactivacionColumnIndex))
						record.FECHA_INACTIVACION = Convert.ToDateTime(reader.GetValue(fecha_inactivacionColumnIndex));
					if(!reader.IsDBNull(vigenteColumnIndex))
						record.VIGENTE = Convert.ToString(reader.GetValue(vigenteColumnIndex));
					if(!reader.IsDBNull(vigente_por_margenColumnIndex))
						record.VIGENTE_POR_MARGEN = Convert.ToString(reader.GetValue(vigente_por_margenColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_PERIODOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTB_PERIODOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_PERIODOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_PERIODOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTB_PERIODOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTB_PERIODOS_INFO_COMPLETARow mappedObject = new CTB_PERIODOS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "EJERCICIO_PLAN_CUENTA_ID"
			dataColumn = dataTable.Columns["EJERCICIO_PLAN_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EJERCICIO_PLAN_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CTB_EJERCICIO_ID"
			dataColumn = dataTable.Columns["CTB_EJERCICIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_EJERCICIO_ID = (decimal)row[dataColumn];
			// Column "EJERCICIO_NOMBRE"
			dataColumn = dataTable.Columns["EJERCICIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EJERCICIO_NOMBRE = (string)row[dataColumn];
			// Column "EJERCICIO_PAIS_ID"
			dataColumn = dataTable.Columns["EJERCICIO_PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EJERCICIO_PAIS_ID = (decimal)row[dataColumn];
			// Column "EJERCICIO_REGION_ID"
			dataColumn = dataTable.Columns["EJERCICIO_REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EJERCICIO_REGION_ID = (decimal)row[dataColumn];
			// Column "EJERCICIO_SUCURSAL_ID"
			dataColumn = dataTable.Columns["EJERCICIO_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EJERCICIO_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "EJERCICIO_SE_ABRIO"
			dataColumn = dataTable.Columns["EJERCICIO_SE_ABRIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EJERCICIO_SE_ABRIO = (string)row[dataColumn];
			// Column "EJERCICIO_SE_CERRO"
			dataColumn = dataTable.Columns["EJERCICIO_SE_CERRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EJERCICIO_SE_CERRO = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_CREACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_INACTIVACION_ID"
			dataColumn = dataTable.Columns["USUARIO_INACTIVACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_INACTIVACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_INACTIVACION_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_INACTIVACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_INACTIVACION_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_INACTIVACION"
			dataColumn = dataTable.Columns["FECHA_INACTIVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INACTIVACION = (System.DateTime)row[dataColumn];
			// Column "VIGENTE"
			dataColumn = dataTable.Columns["VIGENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIGENTE = (string)row[dataColumn];
			// Column "VIGENTE_POR_MARGEN"
			dataColumn = dataTable.Columns["VIGENTE_POR_MARGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIGENTE_POR_MARGEN = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_PERIODOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_PERIODOS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EJERCICIO_PLAN_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_EJERCICIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EJERCICIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EJERCICIO_PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EJERCICIO_REGION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EJERCICIO_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EJERCICIO_SE_ABRIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EJERCICIO_SE_CERRO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_INACTIVACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_INACTIVACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INACTIVACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VIGENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VIGENTE_POR_MARGEN", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EJERCICIO_PLAN_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_EJERCICIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EJERCICIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EJERCICIO_PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EJERCICIO_REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EJERCICIO_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EJERCICIO_SE_ABRIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EJERCICIO_SE_CERRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_INACTIVACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_INACTIVACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INACTIVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VIGENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VIGENTE_POR_MARGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_PERIODOS_INFO_COMPLETACollection_Base class
}  // End of namespace
