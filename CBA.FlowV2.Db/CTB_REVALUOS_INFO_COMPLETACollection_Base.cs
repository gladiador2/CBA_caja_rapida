// <fileinfo name="CTB_REVALUOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTB_REVALUOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_REVALUOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_REVALUOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string ACTIVO_RUBRO_IDColumnName = "ACTIVO_RUBRO_ID";
		public const string ACTIVO_RUBRO_NOMBREColumnName = "ACTIVO_RUBRO_NOMBRE";
		public const string CASO_RELACIONADO_IDColumnName = "CASO_RELACIONADO_ID";
		public const string ACTIVO_CODIGOColumnName = "ACTIVO_CODIGO";
		public const string ACTIVO_NOMBREColumnName = "ACTIVO_NOMBRE";
		public const string FECHA_COMPRAColumnName = "FECHA_COMPRA";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string FECHA_REVALUOColumnName = "FECHA_REVALUO";
		public const string COEFICIENTEColumnName = "COEFICIENTE";
		public const string CTB_REVALUO_ANTERIOR_IDColumnName = "CTB_REVALUO_ANTERIOR_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string VIDA_UTILColumnName = "VIDA_UTIL";
		public const string VALOR_FISCAL_REVColumnName = "VALOR_FISCAL_REV";
		public const string VALOR_FISCAL_NET_CIERREColumnName = "VALOR_FISCAL_NET_CIERRE";
		public const string CUOTA_FISCAL_DEPR_ANUALColumnName = "CUOTA_FISCAL_DEPR_ANUAL";
		public const string DEPREC_FISCAL_ACUMColumnName = "DEPREC_FISCAL_ACUM";
		public const string VIDA_UTIL_RESTANTEColumnName = "VIDA_UTIL_RESTANTE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONTOColumnName = "MONTO";
		public const string REVALUOColumnName = "REVALUO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_REVALUOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_REVALUOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_REVALUOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_REVALUOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_REVALUOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_REVALUOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_REVALUOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_REVALUOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects.</returns>
		public CTB_REVALUOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_REVALUOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_REVALUOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_REVALUOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_REVALUOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTB_REVALUOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int activo_rubro_idColumnIndex = reader.GetOrdinal("ACTIVO_RUBRO_ID");
			int activo_rubro_nombreColumnIndex = reader.GetOrdinal("ACTIVO_RUBRO_NOMBRE");
			int caso_relacionado_idColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_ID");
			int activo_codigoColumnIndex = reader.GetOrdinal("ACTIVO_CODIGO");
			int activo_nombreColumnIndex = reader.GetOrdinal("ACTIVO_NOMBRE");
			int fecha_compraColumnIndex = reader.GetOrdinal("FECHA_COMPRA");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int fecha_revaluoColumnIndex = reader.GetOrdinal("FECHA_REVALUO");
			int coeficienteColumnIndex = reader.GetOrdinal("COEFICIENTE");
			int ctb_revaluo_anterior_idColumnIndex = reader.GetOrdinal("CTB_REVALUO_ANTERIOR_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int vida_utilColumnIndex = reader.GetOrdinal("VIDA_UTIL");
			int valor_fiscal_revColumnIndex = reader.GetOrdinal("VALOR_FISCAL_REV");
			int valor_fiscal_net_cierreColumnIndex = reader.GetOrdinal("VALOR_FISCAL_NET_CIERRE");
			int cuota_fiscal_depr_anualColumnIndex = reader.GetOrdinal("CUOTA_FISCAL_DEPR_ANUAL");
			int deprec_fiscal_acumColumnIndex = reader.GetOrdinal("DEPREC_FISCAL_ACUM");
			int vida_util_restanteColumnIndex = reader.GetOrdinal("VIDA_UTIL_RESTANTE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int revaluoColumnIndex = reader.GetOrdinal("REVALUO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_REVALUOS_INFO_COMPLETARow record = new CTB_REVALUOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_rubro_idColumnIndex))
						record.ACTIVO_RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_rubro_nombreColumnIndex))
						record.ACTIVO_RUBRO_NOMBRE = Convert.ToString(reader.GetValue(activo_rubro_nombreColumnIndex));
					if(!reader.IsDBNull(caso_relacionado_idColumnIndex))
						record.CASO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_codigoColumnIndex))
						record.ACTIVO_CODIGO = Convert.ToString(reader.GetValue(activo_codigoColumnIndex));
					if(!reader.IsDBNull(activo_nombreColumnIndex))
						record.ACTIVO_NOMBRE = Convert.ToString(reader.GetValue(activo_nombreColumnIndex));
					if(!reader.IsDBNull(fecha_compraColumnIndex))
						record.FECHA_COMPRA = Convert.ToDateTime(reader.GetValue(fecha_compraColumnIndex));
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.FECHA_REVALUO = Convert.ToDateTime(reader.GetValue(fecha_revaluoColumnIndex));
					record.COEFICIENTE = Math.Round(Convert.ToDecimal(reader.GetValue(coeficienteColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_revaluo_anterior_idColumnIndex))
						record.CTB_REVALUO_ANTERIOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_revaluo_anterior_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.VIDA_UTIL = Math.Round(Convert.ToDecimal(reader.GetValue(vida_utilColumnIndex)), 9);
					record.VALOR_FISCAL_REV = Math.Round(Convert.ToDecimal(reader.GetValue(valor_fiscal_revColumnIndex)), 9);
					record.VALOR_FISCAL_NET_CIERRE = Math.Round(Convert.ToDecimal(reader.GetValue(valor_fiscal_net_cierreColumnIndex)), 9);
					record.CUOTA_FISCAL_DEPR_ANUAL = Math.Round(Convert.ToDecimal(reader.GetValue(cuota_fiscal_depr_anualColumnIndex)), 9);
					record.DEPREC_FISCAL_ACUM = Math.Round(Convert.ToDecimal(reader.GetValue(deprec_fiscal_acumColumnIndex)), 9);
					record.VIDA_UTIL_RESTANTE = Math.Round(Convert.ToDecimal(reader.GetValue(vida_util_restanteColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(revaluoColumnIndex))
						record.REVALUO = Math.Round(Convert.ToDecimal(reader.GetValue(revaluoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_REVALUOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTB_REVALUOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_REVALUOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_REVALUOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTB_REVALUOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTB_REVALUOS_INFO_COMPLETARow mappedObject = new CTB_REVALUOS_INFO_COMPLETARow();
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
			// Column "ACTIVO_RUBRO_ID"
			dataColumn = dataTable.Columns["ACTIVO_RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_RUBRO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_RUBRO_NOMBRE"
			dataColumn = dataTable.Columns["ACTIVO_RUBRO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_RUBRO_NOMBRE = (string)row[dataColumn];
			// Column "CASO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_CODIGO"
			dataColumn = dataTable.Columns["ACTIVO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_CODIGO = (string)row[dataColumn];
			// Column "ACTIVO_NOMBRE"
			dataColumn = dataTable.Columns["ACTIVO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_COMPRA"
			dataColumn = dataTable.Columns["FECHA_COMPRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COMPRA = (System.DateTime)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_REVALUO"
			dataColumn = dataTable.Columns["FECHA_REVALUO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_REVALUO = (System.DateTime)row[dataColumn];
			// Column "COEFICIENTE"
			dataColumn = dataTable.Columns["COEFICIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COEFICIENTE = (decimal)row[dataColumn];
			// Column "CTB_REVALUO_ANTERIOR_ID"
			dataColumn = dataTable.Columns["CTB_REVALUO_ANTERIOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_REVALUO_ANTERIOR_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "VIDA_UTIL"
			dataColumn = dataTable.Columns["VIDA_UTIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIDA_UTIL = (decimal)row[dataColumn];
			// Column "VALOR_FISCAL_REV"
			dataColumn = dataTable.Columns["VALOR_FISCAL_REV"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_FISCAL_REV = (decimal)row[dataColumn];
			// Column "VALOR_FISCAL_NET_CIERRE"
			dataColumn = dataTable.Columns["VALOR_FISCAL_NET_CIERRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_FISCAL_NET_CIERRE = (decimal)row[dataColumn];
			// Column "CUOTA_FISCAL_DEPR_ANUAL"
			dataColumn = dataTable.Columns["CUOTA_FISCAL_DEPR_ANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA_FISCAL_DEPR_ANUAL = (decimal)row[dataColumn];
			// Column "DEPREC_FISCAL_ACUM"
			dataColumn = dataTable.Columns["DEPREC_FISCAL_ACUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPREC_FISCAL_ACUM = (decimal)row[dataColumn];
			// Column "VIDA_UTIL_RESTANTE"
			dataColumn = dataTable.Columns["VIDA_UTIL_RESTANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VIDA_UTIL_RESTANTE = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "REVALUO"
			dataColumn = dataTable.Columns["REVALUO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REVALUO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_REVALUOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_REVALUOS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_RUBRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_RUBRO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_CODIGO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ACTIVO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_COMPRA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_REVALUO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COEFICIENTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_REVALUO_ANTERIOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VIDA_UTIL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_FISCAL_REV", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_FISCAL_NET_CIERRE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUOTA_FISCAL_DEPR_ANUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPREC_FISCAL_ACUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VIDA_UTIL_RESTANTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REVALUO", typeof(decimal));
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

				case "ACTIVO_RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_RUBRO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_COMPRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_REVALUO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "COEFICIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_REVALUO_ANTERIOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VIDA_UTIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_FISCAL_REV":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_FISCAL_NET_CIERRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUOTA_FISCAL_DEPR_ANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPREC_FISCAL_ACUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VIDA_UTIL_RESTANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REVALUO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_REVALUOS_INFO_COMPLETACollection_Base class
}  // End of namespace
