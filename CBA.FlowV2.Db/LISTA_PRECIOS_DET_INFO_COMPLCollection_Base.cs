// <fileinfo name="LISTA_PRECIOS_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="LISTA_PRECIOS_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="LISTA_PRECIOS_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LISTA_PRECIOS_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";
		public const string LISTA_PRECIOS_NOMBREColumnName = "LISTA_PRECIOS_NOMBRE";
		public const string LISTA_PRECIOS_ABREVIATURAColumnName = "LISTA_PRECIOS_ABREVIATURA";
		public const string LISTA_PRECIOS_MONEDA_IDColumnName = "LISTA_PRECIOS_MONEDA_ID";
		public const string LISTA_PRECIOS_MONEDA_NOMBREColumnName = "LISTA_PRECIOS_MONEDA_NOMBRE";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string DESCUENTO_MAXIMOColumnName = "DESCUENTO_MAXIMO";
		public const string PRECIOColumnName = "PRECIO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_NOMBREColumnName = "ARTICULO_NOMBRE";
		public const string CANTIDAD_RESTANTEColumnName = "CANTIDAD_RESTANTE";
		public const string FAMILIA_DESCRIPCIONColumnName = "FAMILIA_DESCRIPCION";
		public const string GRUPO_DESCRIPCIONColumnName = "GRUPO_DESCRIPCION";
		public const string SUBGRUPO_DESCRIPCIONColumnName = "SUBGRUPO_DESCRIPCION";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string CODIGO_EMPRESAColumnName = "CODIGO_EMPRESA";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="LISTA_PRECIOS_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public LISTA_PRECIOS_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>LISTA_PRECIOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>LISTA_PRECIOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>LISTA_PRECIOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public LISTA_PRECIOS_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			LISTA_PRECIOS_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects.</returns>
		public LISTA_PRECIOS_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.LISTA_PRECIOS_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects.</returns>
		protected LISTA_PRECIOS_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects.</returns>
		protected LISTA_PRECIOS_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual LISTA_PRECIOS_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");
			int lista_precios_nombreColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_NOMBRE");
			int lista_precios_abreviaturaColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_ABREVIATURA");
			int lista_precios_moneda_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_MONEDA_ID");
			int lista_precios_moneda_nombreColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_MONEDA_NOMBRE");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int descuento_maximoColumnIndex = reader.GetOrdinal("DESCUENTO_MAXIMO");
			int precioColumnIndex = reader.GetOrdinal("PRECIO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_NOMBRE");
			int cantidad_restanteColumnIndex = reader.GetOrdinal("CANTIDAD_RESTANTE");
			int familia_descripcionColumnIndex = reader.GetOrdinal("FAMILIA_DESCRIPCION");
			int grupo_descripcionColumnIndex = reader.GetOrdinal("GRUPO_DESCRIPCION");
			int subgrupo_descripcionColumnIndex = reader.GetOrdinal("SUBGRUPO_DESCRIPCION");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int codigo_empresaColumnIndex = reader.GetOrdinal("CODIGO_EMPRESA");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					LISTA_PRECIOS_DET_INFO_COMPLRow record = new LISTA_PRECIOS_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);
					record.LISTA_PRECIOS_NOMBRE = Convert.ToString(reader.GetValue(lista_precios_nombreColumnIndex));
					record.LISTA_PRECIOS_ABREVIATURA = Convert.ToString(reader.GetValue(lista_precios_abreviaturaColumnIndex));
					record.LISTA_PRECIOS_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_moneda_idColumnIndex)), 9);
					record.LISTA_PRECIOS_MONEDA_NOMBRE = Convert.ToString(reader.GetValue(lista_precios_moneda_nombreColumnIndex));
					if(!reader.IsDBNull(cantidad_minimaColumnIndex))
						record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_maximoColumnIndex))
						record.DESCUENTO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_maximoColumnIndex)), 9);
					if(!reader.IsDBNull(precioColumnIndex))
						record.PRECIO = Math.Round(Convert.ToDecimal(reader.GetValue(precioColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_nombreColumnIndex))
						record.ARTICULO_NOMBRE = Convert.ToString(reader.GetValue(articulo_nombreColumnIndex));
					if(!reader.IsDBNull(cantidad_restanteColumnIndex))
						record.CANTIDAD_RESTANTE = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_restanteColumnIndex)), 9);
					if(!reader.IsDBNull(familia_descripcionColumnIndex))
						record.FAMILIA_DESCRIPCION = Convert.ToString(reader.GetValue(familia_descripcionColumnIndex));
					if(!reader.IsDBNull(grupo_descripcionColumnIndex))
						record.GRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(grupo_descripcionColumnIndex));
					if(!reader.IsDBNull(subgrupo_descripcionColumnIndex))
						record.SUBGRUPO_DESCRIPCION = Convert.ToString(reader.GetValue(subgrupo_descripcionColumnIndex));
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_empresaColumnIndex))
						record.CODIGO_EMPRESA = Convert.ToString(reader.GetValue(codigo_empresaColumnIndex));
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LISTA_PRECIOS_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(LISTA_PRECIOS_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="LISTA_PRECIOS_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual LISTA_PRECIOS_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			LISTA_PRECIOS_DET_INFO_COMPLRow mappedObject = new LISTA_PRECIOS_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_NOMBRE"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_NOMBRE = (string)row[dataColumn];
			// Column "LISTA_PRECIOS_ABREVIATURA"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_ABREVIATURA = (string)row[dataColumn];
			// Column "LISTA_PRECIOS_MONEDA_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_MONEDA_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "DESCUENTO_MAXIMO"
			dataColumn = dataTable.Columns["DESCUENTO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_MAXIMO = (decimal)row[dataColumn];
			// Column "PRECIO"
			dataColumn = dataTable.Columns["PRECIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_NOMBRE = (string)row[dataColumn];
			// Column "CANTIDAD_RESTANTE"
			dataColumn = dataTable.Columns["CANTIDAD_RESTANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_RESTANTE = (decimal)row[dataColumn];
			// Column "FAMILIA_DESCRIPCION"
			dataColumn = dataTable.Columns["FAMILIA_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_DESCRIPCION = (string)row[dataColumn];
			// Column "GRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["GRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "SUBGRUPO_DESCRIPCION"
			dataColumn = dataTable.Columns["SUBGRUPO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_DESCRIPCION = (string)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "CODIGO_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EMPRESA = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>LISTA_PRECIOS_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "LISTA_PRECIOS_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAXIMO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_RESTANTE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIOS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LISTA_PRECIOS_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LISTA_PRECIOS_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIOS_MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_RESTANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FAMILIA_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUBGRUPO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
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
	} // End of LISTA_PRECIOS_DET_INFO_COMPLCollection_Base class
}  // End of namespace
