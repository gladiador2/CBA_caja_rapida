// <fileinfo name="CTB_CUENTAS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTB_CUENTAS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_CUENTAS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_CUENTAS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_PLAN_CUENTA_IDColumnName = "CTB_PLAN_CUENTA_ID";
		public const string CTB_PLAN_CUENTA_NOMBREColumnName = "CTB_PLAN_CUENTA_NOMBRE";
		public const string CTB_CUENTA_MADRE_IDColumnName = "CTB_CUENTA_MADRE_ID";
		public const string CTB_CUENTA_MADRE_NOMBREColumnName = "CTB_CUENTA_MADRE_NOMBRE";
		public const string CODIGOColumnName = "CODIGO";
		public const string NIVELColumnName = "NIVEL";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ASENTABLEColumnName = "ASENTABLE";
		public const string EDITABLEColumnName = "EDITABLE";
		public const string UTILIZARColumnName = "UTILIZAR";
		public const string DESGLOSARColumnName = "DESGLOSAR";
		public const string CODIGO_BASEColumnName = "CODIGO_BASE";
		public const string CODIGO_COMPLETOColumnName = "CODIGO_COMPLETO";
		public const string CODIGO_COMPLETO_SIN_CEROSColumnName = "CODIGO_COMPLETO_SIN_CEROS";
		public const string CTB_CLASIFICACION_CUENTAS_IDColumnName = "CTB_CLASIFICACION_CUENTAS_ID";
		public const string ES_CUENTA_DE_RESULTADOSColumnName = "ES_CUENTA_DE_RESULTADOS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_CUENTAS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_CUENTAS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_CUENTAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_CUENTAS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_CUENTAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_CUENTAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_CUENTAS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_CUENTAS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects.</returns>
		public CTB_CUENTAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_CUENTAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_CUENTAS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_CUENTAS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_CUENTAS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTB_CUENTAS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_plan_cuenta_idColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_ID");
			int ctb_plan_cuenta_nombreColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_NOMBRE");
			int ctb_cuenta_madre_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_MADRE_ID");
			int ctb_cuenta_madre_nombreColumnIndex = reader.GetOrdinal("CTB_CUENTA_MADRE_NOMBRE");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int nivelColumnIndex = reader.GetOrdinal("NIVEL");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int asentableColumnIndex = reader.GetOrdinal("ASENTABLE");
			int editableColumnIndex = reader.GetOrdinal("EDITABLE");
			int utilizarColumnIndex = reader.GetOrdinal("UTILIZAR");
			int desglosarColumnIndex = reader.GetOrdinal("DESGLOSAR");
			int codigo_baseColumnIndex = reader.GetOrdinal("CODIGO_BASE");
			int codigo_completoColumnIndex = reader.GetOrdinal("CODIGO_COMPLETO");
			int codigo_completo_sin_cerosColumnIndex = reader.GetOrdinal("CODIGO_COMPLETO_SIN_CEROS");
			int ctb_clasificacion_cuentas_idColumnIndex = reader.GetOrdinal("CTB_CLASIFICACION_CUENTAS_ID");
			int es_cuenta_de_resultadosColumnIndex = reader.GetOrdinal("ES_CUENTA_DE_RESULTADOS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_CUENTAS_INFO_COMPLETARow record = new CTB_CUENTAS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_plan_cuenta_idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_NOMBRE = Convert.ToString(reader.GetValue(ctb_plan_cuenta_nombreColumnIndex));
					if(!reader.IsDBNull(ctb_cuenta_madre_idColumnIndex))
						record.CTB_CUENTA_MADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_madre_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_cuenta_madre_nombreColumnIndex))
						record.CTB_CUENTA_MADRE_NOMBRE = Convert.ToString(reader.GetValue(ctb_cuenta_madre_nombreColumnIndex));
					record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.NIVEL = Math.Round(Convert.ToDecimal(reader.GetValue(nivelColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ASENTABLE = Convert.ToString(reader.GetValue(asentableColumnIndex));
					record.EDITABLE = Convert.ToString(reader.GetValue(editableColumnIndex));
					record.UTILIZAR = Convert.ToString(reader.GetValue(utilizarColumnIndex));
					record.DESGLOSAR = Convert.ToString(reader.GetValue(desglosarColumnIndex));
					if(!reader.IsDBNull(codigo_baseColumnIndex))
						record.CODIGO_BASE = Convert.ToString(reader.GetValue(codigo_baseColumnIndex));
					if(!reader.IsDBNull(codigo_completoColumnIndex))
						record.CODIGO_COMPLETO = Convert.ToString(reader.GetValue(codigo_completoColumnIndex));
					if(!reader.IsDBNull(codigo_completo_sin_cerosColumnIndex))
						record.CODIGO_COMPLETO_SIN_CEROS = Convert.ToString(reader.GetValue(codigo_completo_sin_cerosColumnIndex));
					if(!reader.IsDBNull(ctb_clasificacion_cuentas_idColumnIndex))
						record.CTB_CLASIFICACION_CUENTAS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_clasificacion_cuentas_idColumnIndex)), 9);
					if(!reader.IsDBNull(es_cuenta_de_resultadosColumnIndex))
						record.ES_CUENTA_DE_RESULTADOS = Convert.ToString(reader.GetValue(es_cuenta_de_resultadosColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_CUENTAS_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTB_CUENTAS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_CUENTAS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_CUENTAS_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTB_CUENTAS_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTB_CUENTAS_INFO_COMPLETARow mappedObject = new CTB_CUENTAS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_NOMBRE"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_NOMBRE = (string)row[dataColumn];
			// Column "CTB_CUENTA_MADRE_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_MADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_MADRE_ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_MADRE_NOMBRE"
			dataColumn = dataTable.Columns["CTB_CUENTA_MADRE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_MADRE_NOMBRE = (string)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "NIVEL"
			dataColumn = dataTable.Columns["NIVEL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ASENTABLE"
			dataColumn = dataTable.Columns["ASENTABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ASENTABLE = (string)row[dataColumn];
			// Column "EDITABLE"
			dataColumn = dataTable.Columns["EDITABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDITABLE = (string)row[dataColumn];
			// Column "UTILIZAR"
			dataColumn = dataTable.Columns["UTILIZAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.UTILIZAR = (string)row[dataColumn];
			// Column "DESGLOSAR"
			dataColumn = dataTable.Columns["DESGLOSAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESGLOSAR = (string)row[dataColumn];
			// Column "CODIGO_BASE"
			dataColumn = dataTable.Columns["CODIGO_BASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_BASE = (string)row[dataColumn];
			// Column "CODIGO_COMPLETO"
			dataColumn = dataTable.Columns["CODIGO_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_COMPLETO = (string)row[dataColumn];
			// Column "CODIGO_COMPLETO_SIN_CEROS"
			dataColumn = dataTable.Columns["CODIGO_COMPLETO_SIN_CEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_COMPLETO_SIN_CEROS = (string)row[dataColumn];
			// Column "CTB_CLASIFICACION_CUENTAS_ID"
			dataColumn = dataTable.Columns["CTB_CLASIFICACION_CUENTAS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CLASIFICACION_CUENTAS_ID = (decimal)row[dataColumn];
			// Column "ES_CUENTA_DE_RESULTADOS"
			dataColumn = dataTable.Columns["ES_CUENTA_DE_RESULTADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CUENTA_DE_RESULTADOS = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_CUENTAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_CUENTAS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_MADRE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_MADRE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NIVEL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ASENTABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EDITABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UTILIZAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESGLOSAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_BASE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_COMPLETO", typeof(string));
			dataColumn.MaxLength = 113;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_COMPLETO_SIN_CEROS", typeof(string));
			dataColumn.MaxLength = 201;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CLASIFICACION_CUENTAS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_CUENTA_DE_RESULTADOS", typeof(string));
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

				case "CTB_PLAN_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_PLAN_CUENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CUENTA_MADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA_MADRE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NIVEL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ASENTABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDITABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "UTILIZAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESGLOSAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CODIGO_BASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_COMPLETO_SIN_CEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CLASIFICACION_CUENTAS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_CUENTA_DE_RESULTADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_CUENTAS_INFO_COMPLETACollection_Base class
}  // End of namespace
