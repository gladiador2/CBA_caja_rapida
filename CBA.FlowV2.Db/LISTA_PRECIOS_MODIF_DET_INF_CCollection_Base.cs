// <fileinfo name="LISTA_PRECIOS_MODIF_DET_INF_CCollection_Base.cs">
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
	/// The base class for <see cref="LISTA_PRECIOS_MODIF_DET_INF_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="LISTA_PRECIOS_MODIF_DET_INF_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LISTA_PRECIOS_MODIF_DET_INF_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LISTA_PRECIOS_MODIFICAR_IDColumnName = "LISTA_PRECIOS_MODIFICAR_ID";
		public const string LISTA_PRECIOS_IDColumnName = "LISTA_PRECIOS_ID";
		public const string LISTA_PRECIOS_NOMBREColumnName = "LISTA_PRECIOS_NOMBRE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string ARTICULO_FAMILIA_DESCRIPCIONColumnName = "ARTICULO_FAMILIA_DESCRIPCION";
		public const string ARTICULO_GRUPO_DESCRIPCIONColumnName = "ARTICULO_GRUPO_DESCRIPCION";
		public const string ARTICULO_SUBGRUPO_DESCRIPCIONColumnName = "ARTICULO_SUBGRUPO_DESCRIPCION";
		public const string PRECIO_NUEVOColumnName = "PRECIO_NUEVO";
		public const string COSTOColumnName = "COSTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_SIMBOLOColumnName = "COSTO_MONEDA_SIMBOLO";
		public const string COSTO_COTIZACIONColumnName = "COSTO_COTIZACION";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MARGEN_RENTABILIDADColumnName = "MARGEN_RENTABILIDAD";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string DESCUENTO_MAXIMOColumnName = "DESCUENTO_MAXIMO";
		public const string QUITAR_ARTICULO_DE_LISTAColumnName = "QUITAR_ARTICULO_DE_LISTA";
		public const string SUCURSALES_IDColumnName = "SUCURSALES_ID";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="LISTA_PRECIOS_MODIF_DET_INF_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public LISTA_PRECIOS_MODIF_DET_INF_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>LISTA_PRECIOS_MODIF_DET_INF_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_MODIF_DET_INF_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>LISTA_PRECIOS_MODIF_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>LISTA_PRECIOS_MODIF_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public LISTA_PRECIOS_MODIF_DET_INF_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			LISTA_PRECIOS_MODIF_DET_INF_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects.</returns>
		public LISTA_PRECIOS_MODIF_DET_INF_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects that 
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_MODIF_DET_INF_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.LISTA_PRECIOS_MODIF_DET_INF_C";
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects.</returns>
		protected LISTA_PRECIOS_MODIF_DET_INF_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects.</returns>
		protected LISTA_PRECIOS_MODIF_DET_INF_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> objects.</returns>
		protected virtual LISTA_PRECIOS_MODIF_DET_INF_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int lista_precios_modificar_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_MODIFICAR_ID");
			int lista_precios_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_ID");
			int lista_precios_nombreColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_NOMBRE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int articulo_familia_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_FAMILIA_DESCRIPCION");
			int articulo_grupo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_GRUPO_DESCRIPCION");
			int articulo_subgrupo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_SUBGRUPO_DESCRIPCION");
			int precio_nuevoColumnIndex = reader.GetOrdinal("PRECIO_NUEVO");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_simboloColumnIndex = reader.GetOrdinal("COSTO_MONEDA_SIMBOLO");
			int costo_cotizacionColumnIndex = reader.GetOrdinal("COSTO_COTIZACION");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int margen_rentabilidadColumnIndex = reader.GetOrdinal("MARGEN_RENTABILIDAD");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int descuento_maximoColumnIndex = reader.GetOrdinal("DESCUENTO_MAXIMO");
			int quitar_articulo_de_listaColumnIndex = reader.GetOrdinal("QUITAR_ARTICULO_DE_LISTA");
			int sucursales_idColumnIndex = reader.GetOrdinal("SUCURSALES_ID");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					LISTA_PRECIOS_MODIF_DET_INF_CRow record = new LISTA_PRECIOS_MODIF_DET_INF_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.LISTA_PRECIOS_MODIFICAR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_modificar_idColumnIndex)), 9);
					record.LISTA_PRECIOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_idColumnIndex)), 9);
					record.LISTA_PRECIOS_NOMBRE = Convert.ToString(reader.GetValue(lista_precios_nombreColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_familia_descripcionColumnIndex))
						record.ARTICULO_FAMILIA_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_familia_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_grupo_descripcionColumnIndex))
						record.ARTICULO_GRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_grupo_descripcionColumnIndex));
					if(!reader.IsDBNull(articulo_subgrupo_descripcionColumnIndex))
						record.ARTICULO_SUBGRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_subgrupo_descripcionColumnIndex));
					record.PRECIO_NUEVO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_nuevoColumnIndex)), 9);
					record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					record.COSTO_MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(costo_moneda_simboloColumnIndex));
					record.COSTO_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_cotizacionColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.MARGEN_RENTABILIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(margen_rentabilidadColumnIndex)), 9);
					record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					record.DESCUENTO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_maximoColumnIndex)), 9);
					record.QUITAR_ARTICULO_DE_LISTA = Convert.ToString(reader.GetValue(quitar_articulo_de_listaColumnIndex));
					if(!reader.IsDBNull(sucursales_idColumnIndex))
						record.SUCURSALES_ID = Convert.ToString(reader.GetValue(sucursales_idColumnIndex));
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LISTA_PRECIOS_MODIF_DET_INF_CRow[])(recordList.ToArray(typeof(LISTA_PRECIOS_MODIF_DET_INF_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="LISTA_PRECIOS_MODIF_DET_INF_CRow"/> object.</returns>
		protected virtual LISTA_PRECIOS_MODIF_DET_INF_CRow MapRow(DataRow row)
		{
			LISTA_PRECIOS_MODIF_DET_INF_CRow mappedObject = new LISTA_PRECIOS_MODIF_DET_INF_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_MODIFICAR_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_MODIFICAR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_MODIFICAR_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_NOMBRE"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_FAMILIA_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_FAMILIA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FAMILIA_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_GRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_GRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_GRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "ARTICULO_SUBGRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_SUBGRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_SUBGRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "PRECIO_NUEVO"
			dataColumn = dataTable.Columns["PRECIO_NUEVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_NUEVO = (decimal)row[dataColumn];
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["COSTO_MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "COSTO_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_COTIZACION = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "MARGEN_RENTABILIDAD"
			dataColumn = dataTable.Columns["MARGEN_RENTABILIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARGEN_RENTABILIDAD = (decimal)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "DESCUENTO_MAXIMO"
			dataColumn = dataTable.Columns["DESCUENTO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_MAXIMO = (decimal)row[dataColumn];
			// Column "QUITAR_ARTICULO_DE_LISTA"
			dataColumn = dataTable.Columns["QUITAR_ARTICULO_DE_LISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.QUITAR_ARTICULO_DE_LISTA = (string)row[dataColumn];
			// Column "SUCURSALES_ID"
			dataColumn = dataTable.Columns["SUCURSALES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ID = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>LISTA_PRECIOS_MODIF_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "LISTA_PRECIOS_MODIF_DET_INF_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_MODIFICAR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 953;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_FAMILIA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_GRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_SUBGRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO_NUEVO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARGEN_RENTABILIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAXIMO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("QUITAR_ARTICULO_DE_LISTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSALES_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
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

				case "LISTA_PRECIOS_MODIFICAR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIOS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_FAMILIA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_GRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_SUBGRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECIO_NUEVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MARGEN_RENTABILIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "QUITAR_ARTICULO_DE_LISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SUCURSALES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of LISTA_PRECIOS_MODIF_DET_INF_CCollection_Base class
}  // End of namespace
