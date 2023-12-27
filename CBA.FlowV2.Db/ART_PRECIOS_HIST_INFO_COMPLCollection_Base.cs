// <fileinfo name="ART_PRECIOS_HIST_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="ART_PRECIOS_HIST_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ART_PRECIOS_HIST_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ART_PRECIOS_HIST_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string CODIGO_EMPRESAColumnName = "CODIGO_EMPRESA";
		public const string ARTICULO_DESCRIPCION_INTERNAColumnName = "ARTICULO_DESCRIPCION_INTERNA";
		public const string ARTICULOS_FAMILIA_IDColumnName = "ARTICULOS_FAMILIA_ID";
		public const string ARTICULOS_FAMILIA_NOMBREColumnName = "ARTICULOS_FAMILIA_NOMBRE";
		public const string ARTICULOS_GRUPO_IDColumnName = "ARTICULOS_GRUPO_ID";
		public const string ARTICULOS_GRUPO_NOMBREColumnName = "ARTICULOS_GRUPO_NOMBRE";
		public const string ARTICULOS_SUB_GRUPO_IDColumnName = "ARTICULOS_SUB_GRUPO_ID";
		public const string ARTICULOS_SUBGRUPOS_NOMBREColumnName = "ARTICULOS_SUBGRUPOS_NOMBRE";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSALES_NOMBREColumnName = "SUCURSALES_NOMBRE";
		public const string SUCURSALES_ABREVIATURAColumnName = "SUCURSALES_ABREVIATURA";
		public const string SUCURSALES_ENTIDAD_IDColumnName = "SUCURSALES_ENTIDAD_ID";
		public const string SUCURSALES_ENTIDAD_NOMBREColumnName = "SUCURSALES_ENTIDAD_NOMBRE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDAS_NOMBREColumnName = "MONEDAS_NOMBRE";
		public const string MONEDAS_SIMBOLOColumnName = "MONEDAS_SIMBOLO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string PRECIOColumnName = "PRECIO";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string IMPUESTOS_NOMBREColumnName = "IMPUESTOS_NOMBRE";
		public const string COSTOColumnName = "COSTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string COSTO_MONEDA_SIMBOLOColumnName = "COSTO_MONEDA_SIMBOLO";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string USUARIOS_USUARIOColumnName = "USUARIOS_USUARIO";
		public const string FECHAColumnName = "FECHA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string DESCUENTO_MAXIMOColumnName = "DESCUENTO_MAXIMO";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string MARCA_IDColumnName = "MARCA_ID";
		public const string NOMBRE_MARCAColumnName = "NOMBRE_MARCA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ART_PRECIOS_HIST_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ART_PRECIOS_HIST_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ART_PRECIOS_HIST_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects.</returns>
		public virtual ART_PRECIOS_HIST_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ART_PRECIOS_HIST_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ART_PRECIOS_HIST_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ART_PRECIOS_HIST_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ART_PRECIOS_HIST_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects.</returns>
		public ART_PRECIOS_HIST_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects.</returns>
		public virtual ART_PRECIOS_HIST_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ART_PRECIOS_HIST_INFO_COMPL";
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
		/// <returns>An array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects.</returns>
		protected ART_PRECIOS_HIST_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects.</returns>
		protected ART_PRECIOS_HIST_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> objects.</returns>
		protected virtual ART_PRECIOS_HIST_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int codigo_empresaColumnIndex = reader.GetOrdinal("CODIGO_EMPRESA");
			int articulo_descripcion_internaColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION_INTERNA");
			int articulos_familia_idColumnIndex = reader.GetOrdinal("ARTICULOS_FAMILIA_ID");
			int articulos_familia_nombreColumnIndex = reader.GetOrdinal("ARTICULOS_FAMILIA_NOMBRE");
			int articulos_grupo_idColumnIndex = reader.GetOrdinal("ARTICULOS_GRUPO_ID");
			int articulos_grupo_nombreColumnIndex = reader.GetOrdinal("ARTICULOS_GRUPO_NOMBRE");
			int articulos_sub_grupo_idColumnIndex = reader.GetOrdinal("ARTICULOS_SUB_GRUPO_ID");
			int articulos_subgrupos_nombreColumnIndex = reader.GetOrdinal("ARTICULOS_SUBGRUPOS_NOMBRE");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursales_nombreColumnIndex = reader.GetOrdinal("SUCURSALES_NOMBRE");
			int sucursales_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSALES_ABREVIATURA");
			int sucursales_entidad_idColumnIndex = reader.GetOrdinal("SUCURSALES_ENTIDAD_ID");
			int sucursales_entidad_nombreColumnIndex = reader.GetOrdinal("SUCURSALES_ENTIDAD_NOMBRE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monedas_nombreColumnIndex = reader.GetOrdinal("MONEDAS_NOMBRE");
			int monedas_simboloColumnIndex = reader.GetOrdinal("MONEDAS_SIMBOLO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int precioColumnIndex = reader.GetOrdinal("PRECIO");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int impuestos_nombreColumnIndex = reader.GetOrdinal("IMPUESTOS_NOMBRE");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int costo_moneda_simboloColumnIndex = reader.GetOrdinal("COSTO_MONEDA_SIMBOLO");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int usuarios_usuarioColumnIndex = reader.GetOrdinal("USUARIOS_USUARIO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int descuento_maximoColumnIndex = reader.GetOrdinal("DESCUENTO_MAXIMO");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int marca_idColumnIndex = reader.GetOrdinal("MARCA_ID");
			int nombre_marcaColumnIndex = reader.GetOrdinal("NOMBRE_MARCA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ART_PRECIOS_HIST_INFO_COMPLRow record = new ART_PRECIOS_HIST_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_empresaColumnIndex))
						record.CODIGO_EMPRESA = Convert.ToString(reader.GetValue(codigo_empresaColumnIndex));
					if(!reader.IsDBNull(articulo_descripcion_internaColumnIndex))
						record.ARTICULO_DESCRIPCION_INTERNA = Convert.ToString(reader.GetValue(articulo_descripcion_internaColumnIndex));
					if(!reader.IsDBNull(articulos_familia_idColumnIndex))
						record.ARTICULOS_FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_familia_idColumnIndex)), 9);
					record.ARTICULOS_FAMILIA_NOMBRE = Convert.ToString(reader.GetValue(articulos_familia_nombreColumnIndex));
					if(!reader.IsDBNull(articulos_grupo_idColumnIndex))
						record.ARTICULOS_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_grupo_idColumnIndex)), 9);
					record.ARTICULOS_GRUPO_NOMBRE = Convert.ToString(reader.GetValue(articulos_grupo_nombreColumnIndex));
					if(!reader.IsDBNull(articulos_sub_grupo_idColumnIndex))
						record.ARTICULOS_SUB_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_sub_grupo_idColumnIndex)), 9);
					record.ARTICULOS_SUBGRUPOS_NOMBRE = Convert.ToString(reader.GetValue(articulos_subgrupos_nombreColumnIndex));
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSALES_NOMBRE = Convert.ToString(reader.GetValue(sucursales_nombreColumnIndex));
					record.SUCURSALES_ABREVIATURA = Convert.ToString(reader.GetValue(sucursales_abreviaturaColumnIndex));
					record.SUCURSALES_ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursales_entidad_idColumnIndex)), 9);
					record.SUCURSALES_ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(sucursales_entidad_nombreColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDAS_NOMBRE = Convert.ToString(reader.GetValue(monedas_nombreColumnIndex));
					record.MONEDAS_SIMBOLO = Convert.ToString(reader.GetValue(monedas_simboloColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.PRECIO = Math.Round(Convert.ToDecimal(reader.GetValue(precioColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					record.IMPUESTOS_NOMBRE = Convert.ToString(reader.GetValue(impuestos_nombreColumnIndex));
					if(!reader.IsDBNull(costoColumnIndex))
						record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_idColumnIndex))
						record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_cotizacionColumnIndex))
						record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_simboloColumnIndex))
						record.COSTO_MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(costo_moneda_simboloColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.USUARIOS_USUARIO = Convert.ToString(reader.GetValue(usuarios_usuarioColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(descuento_maximoColumnIndex))
						record.DESCUENTO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_maximoColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_minimaColumnIndex))
						record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					if(!reader.IsDBNull(marca_idColumnIndex))
						record.MARCA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(marca_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_marcaColumnIndex))
						record.NOMBRE_MARCA = Convert.ToString(reader.GetValue(nombre_marcaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ART_PRECIOS_HIST_INFO_COMPLRow[])(recordList.ToArray(typeof(ART_PRECIOS_HIST_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ART_PRECIOS_HIST_INFO_COMPLRow"/> object.</returns>
		protected virtual ART_PRECIOS_HIST_INFO_COMPLRow MapRow(DataRow row)
		{
			ART_PRECIOS_HIST_INFO_COMPLRow mappedObject = new ART_PRECIOS_HIST_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "CODIGO_EMPRESA"
			dataColumn = dataTable.Columns["CODIGO_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EMPRESA = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION_INTERNA"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION_INTERNA = (string)row[dataColumn];
			// Column "ARTICULOS_FAMILIA_ID"
			dataColumn = dataTable.Columns["ARTICULOS_FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_FAMILIA_ID = (decimal)row[dataColumn];
			// Column "ARTICULOS_FAMILIA_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULOS_FAMILIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_FAMILIA_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULOS_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULOS_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULOS_GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULOS_GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULOS_SUB_GRUPO_ID"
			dataColumn = dataTable.Columns["ARTICULOS_SUB_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_SUB_GRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULOS_SUBGRUPOS_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULOS_SUBGRUPOS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_SUBGRUPOS_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSALES_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSALES_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSALES_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSALES_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ABREVIATURA = (string)row[dataColumn];
			// Column "SUCURSALES_ENTIDAD_ID"
			dataColumn = dataTable.Columns["SUCURSALES_ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "SUCURSALES_ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSALES_ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDAS_NOMBRE"
			dataColumn = dataTable.Columns["MONEDAS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_NOMBRE = (string)row[dataColumn];
			// Column "MONEDAS_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDAS_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "PRECIO"
			dataColumn = dataTable.Columns["PRECIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "IMPUESTOS_NOMBRE"
			dataColumn = dataTable.Columns["IMPUESTOS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTOS_NOMBRE = (string)row[dataColumn];
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["COSTO_MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "USUARIOS_USUARIO"
			dataColumn = dataTable.Columns["USUARIOS_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIOS_USUARIO = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "DESCUENTO_MAXIMO"
			dataColumn = dataTable.Columns["DESCUENTO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_MAXIMO = (decimal)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "MARCA_ID"
			dataColumn = dataTable.Columns["MARCA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_MARCA"
			dataColumn = dataTable.Columns["NOMBRE_MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_MARCA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ART_PRECIOS_HIST_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ART_PRECIOS_HIST_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_EMPRESA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION_INTERNA", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULOS_FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULOS_FAMILIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULOS_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULOS_GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULOS_SUB_GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULOS_SUBGRUPOS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSALES_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSALES_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSALES_ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSALES_ENTIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECIO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPUESTOS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_COTIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIOS_USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAXIMO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARCA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_MARCA", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULOS_FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULOS_FAMILIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULOS_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULOS_GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULOS_SUB_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULOS_SUBGRUPOS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSALES_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSALES_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSALES_ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSALES_ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDAS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDAS_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTOS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIOS_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCUENTO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MARCA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ART_PRECIOS_HIST_INFO_COMPLCollection_Base class
}  // End of namespace
