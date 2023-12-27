// <fileinfo name="STOCK_INVENT_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_INVENT_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_INVENT_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_INVENT_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string STOCK_INVENTANRIO_IDColumnName = "STOCK_INVENTANRIO_ID";
		public const string STOCK_INVENT_CASO_IDColumnName = "STOCK_INVENT_CASO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string ARTICULO_FAMILIAColumnName = "ARTICULO_FAMILIA";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string ARTICULO_GRUPOColumnName = "ARTICULO_GRUPO";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string ARTICULO_SUBGRUPOColumnName = "ARTICULO_SUBGRUPO";
		public const string ARTICULO_CODIGO_CATALOGOColumnName = "ARTICULO_CODIGO_CATALOGO";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string LOTEColumnName = "LOTE";
		public const string CANTIDAD_SISTEMAColumnName = "CANTIDAD_SISTEMA";
		public const string CANTIDAD_MANUALColumnName = "CANTIDAD_MANUAL";
		public const string UNIDAD_IDColumnName = "UNIDAD_ID";
		public const string UNIDAD_MEDIDAColumnName = "UNIDAD_MEDIDA";
		public const string AJUSTE_STOCK_CASO_IDColumnName = "AJUSTE_STOCK_CASO_ID";
		public const string COSTO_MONEDAColumnName = "COSTO_MONEDA";
		public const string COSTO_COTIZACIONColumnName = "COSTO_COTIZACION";
		public const string COSTOColumnName = "COSTO";
		public const string PASILLOColumnName = "PASILLO";
		public const string ESTANTEColumnName = "ESTANTE";
		public const string NIVELColumnName = "NIVEL";
		public const string COLUMNAColumnName = "COLUMNA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_INVENT_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_INVENT_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_INVENT_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual STOCK_INVENT_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_INVENT_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_INVENT_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_INVENT_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_INVENT_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects.</returns>
		public STOCK_INVENT_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual STOCK_INVENT_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_INVENT_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects.</returns>
		protected STOCK_INVENT_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects.</returns>
		protected STOCK_INVENT_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual STOCK_INVENT_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int stock_inventanrio_idColumnIndex = reader.GetOrdinal("STOCK_INVENTANRIO_ID");
			int stock_invent_caso_idColumnIndex = reader.GetOrdinal("STOCK_INVENT_CASO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int articulo_familiaColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int articulo_grupoColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int articulo_subgrupoColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO");
			int articulo_codigo_catalogoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO_CATALOGO");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int loteColumnIndex = reader.GetOrdinal("LOTE");
			int cantidad_sistemaColumnIndex = reader.GetOrdinal("CANTIDAD_SISTEMA");
			int cantidad_manualColumnIndex = reader.GetOrdinal("CANTIDAD_MANUAL");
			int unidad_idColumnIndex = reader.GetOrdinal("UNIDAD_ID");
			int unidad_medidaColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA");
			int ajuste_stock_caso_idColumnIndex = reader.GetOrdinal("AJUSTE_STOCK_CASO_ID");
			int costo_monedaColumnIndex = reader.GetOrdinal("COSTO_MONEDA");
			int costo_cotizacionColumnIndex = reader.GetOrdinal("COSTO_COTIZACION");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int pasilloColumnIndex = reader.GetOrdinal("PASILLO");
			int estanteColumnIndex = reader.GetOrdinal("ESTANTE");
			int nivelColumnIndex = reader.GetOrdinal("NIVEL");
			int columnaColumnIndex = reader.GetOrdinal("COLUMNA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_INVENT_DET_INFO_COMPLRow record = new STOCK_INVENT_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.STOCK_INVENTANRIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_inventanrio_idColumnIndex)), 9);
					record.STOCK_INVENT_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_invent_caso_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_familiaColumnIndex))
						record.ARTICULO_FAMILIA = Convert.ToString(reader.GetValue(articulo_familiaColumnIndex));
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_grupoColumnIndex))
						record.ARTICULO_GRUPO = Convert.ToString(reader.GetValue(articulo_grupoColumnIndex));
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_subgrupoColumnIndex))
						record.ARTICULO_SUBGRUPO = Convert.ToString(reader.GetValue(articulo_subgrupoColumnIndex));
					if(!reader.IsDBNull(articulo_codigo_catalogoColumnIndex))
						record.ARTICULO_CODIGO_CATALOGO = Convert.ToString(reader.GetValue(articulo_codigo_catalogoColumnIndex));
					record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(loteColumnIndex))
						record.LOTE = Convert.ToString(reader.GetValue(loteColumnIndex));
					if(!reader.IsDBNull(cantidad_sistemaColumnIndex))
						record.CANTIDAD_SISTEMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_sistemaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_manualColumnIndex))
						record.CANTIDAD_MANUAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_manualColumnIndex)), 9);
					record.UNIDAD_ID = Convert.ToString(reader.GetValue(unidad_idColumnIndex));
					if(!reader.IsDBNull(unidad_medidaColumnIndex))
						record.UNIDAD_MEDIDA = Convert.ToString(reader.GetValue(unidad_medidaColumnIndex));
					if(!reader.IsDBNull(ajuste_stock_caso_idColumnIndex))
						record.AJUSTE_STOCK_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_stock_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_monedaColumnIndex))
						record.COSTO_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(costo_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(costo_cotizacionColumnIndex))
						record.COSTO_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(costoColumnIndex))
						record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					if(!reader.IsDBNull(pasilloColumnIndex))
						record.PASILLO = Convert.ToString(reader.GetValue(pasilloColumnIndex));
					if(!reader.IsDBNull(estanteColumnIndex))
						record.ESTANTE = Convert.ToString(reader.GetValue(estanteColumnIndex));
					if(!reader.IsDBNull(nivelColumnIndex))
						record.NIVEL = Convert.ToString(reader.GetValue(nivelColumnIndex));
					if(!reader.IsDBNull(columnaColumnIndex))
						record.COLUMNA = Convert.ToString(reader.GetValue(columnaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_INVENT_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(STOCK_INVENT_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_INVENT_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual STOCK_INVENT_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			STOCK_INVENT_DET_INFO_COMPLRow mappedObject = new STOCK_INVENT_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "STOCK_INVENTANRIO_ID"
			dataColumn = dataTable.Columns["STOCK_INVENTANRIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_INVENTANRIO_ID = (decimal)row[dataColumn];
			// Column "STOCK_INVENT_CASO_ID"
			dataColumn = dataTable.Columns["STOCK_INVENT_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_INVENT_CASO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FAMILIA"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA = (string)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_GRUPO"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO = (string)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO = (string)row[dataColumn];
			// Column "ARTICULO_CODIGO_CATALOGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO_CATALOGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO_CATALOGO = (string)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE"
			dataColumn = dataTable.Columns["LOTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE = (string)row[dataColumn];
			// Column "CANTIDAD_SISTEMA"
			dataColumn = dataTable.Columns["CANTIDAD_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_SISTEMA = (decimal)row[dataColumn];
			// Column "CANTIDAD_MANUAL"
			dataColumn = dataTable.Columns["CANTIDAD_MANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MANUAL = (decimal)row[dataColumn];
			// Column "UNIDAD_ID"
			dataColumn = dataTable.Columns["UNIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA = (string)row[dataColumn];
			// Column "AJUSTE_STOCK_CASO_ID"
			dataColumn = dataTable.Columns["AJUSTE_STOCK_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_STOCK_CASO_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA"
			dataColumn = dataTable.Columns["COSTO_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA = (decimal)row[dataColumn];
			// Column "COSTO_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "PASILLO"
			dataColumn = dataTable.Columns["PASILLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASILLO = (string)row[dataColumn];
			// Column "ESTANTE"
			dataColumn = dataTable.Columns["ESTANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTANTE = (string)row[dataColumn];
			// Column "NIVEL"
			dataColumn = dataTable.Columns["NIVEL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL = (string)row[dataColumn];
			// Column "COLUMNA"
			dataColumn = dataTable.Columns["COLUMNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLUMNA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_INVENT_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_INVENT_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_INVENTANRIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STOCK_INVENT_CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 953;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO_CATALOGO", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_SISTEMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MANUAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_STOCK_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PASILLO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTANTE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NIVEL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COLUMNA", typeof(string));
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

				case "STOCK_INVENTANRIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "STOCK_INVENT_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_FAMILIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_GRUPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_SUBGRUPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_CODIGO_CATALOGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AJUSTE_STOCK_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PASILLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NIVEL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COLUMNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_INVENT_DET_INFO_COMPLCollection_Base class
}  // End of namespace
