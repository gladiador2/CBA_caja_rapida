// <fileinfo name="OBJETIVO_VENDEDOR_EXPLOTACIONCollection_Base.cs">
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
	/// The base class for <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJETIVO_VENDEDOR_EXPLOTACIONCollection_Base
	{
		// Constants
		public const string FACTURA_CLIENTE_DETALLE_IDColumnName = "FACTURA_CLIENTE_DETALLE_ID";
		public const string FECHAColumnName = "FECHA";
		public const string VENDEDOR_COMISIONISTA_IDColumnName = "VENDEDOR_COMISIONISTA_ID";
		public const string VENDEDOR_NOMBREColumnName = "VENDEDOR_NOMBRE";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string FAMILIA_NOMBREColumnName = "FAMILIA_NOMBRE";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string GRUPO_NOMBREColumnName = "GRUPO_NOMBRE";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string SUBGRUPO_NOMBREColumnName = "SUBGRUPO_NOMBRE";
		public const string ARTICULO_MARCA_IDColumnName = "ARTICULO_MARCA_ID";
		public const string CANTIDAD_VENDIDAColumnName = "CANTIDAD_VENDIDA";
		public const string MONTO_VENDIDO_USDColumnName = "MONTO_VENDIDO_USD";
		public const string MONTO_VENDIDOColumnName = "MONTO_VENDIDO";
		public const string MONTO_LINEA_CREDITOColumnName = "MONTO_LINEA_CREDITO";
		public const string MONEDA_LINEA_CREDITOColumnName = "MONEDA_LINEA_CREDITO";
		public const string MONEDA_LC_COTIZACIONColumnName = "MONEDA_LC_COTIZACION";
		public const string CREDITO_MENOS_DEBITOColumnName = "CREDITO_MENOS_DEBITO";
		public const string TOT_CHEQ_NO_DEPOSIT_NI_EFECTIVColumnName = "TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string CANTIDAD_DECIMALESColumnName = "CANTIDAD_DECIMALES";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public OBJETIVO_VENDEDOR_EXPLOTACIONCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>OBJETIVO_VENDEDOR_EXPLOTACION</c> view.
		/// </summary>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_EXPLOTACIONRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>OBJETIVO_VENDEDOR_EXPLOTACION</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>OBJETIVO_VENDEDOR_EXPLOTACION</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public OBJETIVO_VENDEDOR_EXPLOTACIONRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			OBJETIVO_VENDEDOR_EXPLOTACIONRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects.</returns>
		public OBJETIVO_VENDEDOR_EXPLOTACIONRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects that 
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects.</returns>
		public virtual OBJETIVO_VENDEDOR_EXPLOTACIONRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.OBJETIVO_VENDEDOR_EXPLOTACION";
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects.</returns>
		protected OBJETIVO_VENDEDOR_EXPLOTACIONRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects.</returns>
		protected OBJETIVO_VENDEDOR_EXPLOTACIONRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> objects.</returns>
		protected virtual OBJETIVO_VENDEDOR_EXPLOTACIONRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int factura_cliente_detalle_idColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_DETALLE_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int vendedor_comisionista_idColumnIndex = reader.GetOrdinal("VENDEDOR_COMISIONISTA_ID");
			int vendedor_nombreColumnIndex = reader.GetOrdinal("VENDEDOR_NOMBRE");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int familia_nombreColumnIndex = reader.GetOrdinal("FAMILIA_NOMBRE");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int grupo_nombreColumnIndex = reader.GetOrdinal("GRUPO_NOMBRE");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int subgrupo_nombreColumnIndex = reader.GetOrdinal("SUBGRUPO_NOMBRE");
			int articulo_marca_idColumnIndex = reader.GetOrdinal("ARTICULO_MARCA_ID");
			int cantidad_vendidaColumnIndex = reader.GetOrdinal("CANTIDAD_VENDIDA");
			int monto_vendido_usdColumnIndex = reader.GetOrdinal("MONTO_VENDIDO_USD");
			int monto_vendidoColumnIndex = reader.GetOrdinal("MONTO_VENDIDO");
			int monto_linea_creditoColumnIndex = reader.GetOrdinal("MONTO_LINEA_CREDITO");
			int moneda_linea_creditoColumnIndex = reader.GetOrdinal("MONEDA_LINEA_CREDITO");
			int moneda_lc_cotizacionColumnIndex = reader.GetOrdinal("MONEDA_LC_COTIZACION");
			int credito_menos_debitoColumnIndex = reader.GetOrdinal("CREDITO_MENOS_DEBITO");
			int tot_cheq_no_deposit_ni_efectivColumnIndex = reader.GetOrdinal("TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cantidad_decimalesColumnIndex = reader.GetOrdinal("CANTIDAD_DECIMALES");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					OBJETIVO_VENDEDOR_EXPLOTACIONRow record = new OBJETIVO_VENDEDOR_EXPLOTACIONRow();
					recordList.Add(record);

					record.FACTURA_CLIENTE_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_cliente_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(vendedor_comisionista_idColumnIndex))
						record.VENDEDOR_COMISIONISTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_comisionista_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_nombreColumnIndex))
						record.VENDEDOR_NOMBRE = Convert.ToString(reader.GetValue(vendedor_nombreColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					record.FAMILIA_NOMBRE = Convert.ToString(reader.GetValue(familia_nombreColumnIndex));
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					record.GRUPO_NOMBRE = Convert.ToString(reader.GetValue(grupo_nombreColumnIndex));
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					record.SUBGRUPO_NOMBRE = Convert.ToString(reader.GetValue(subgrupo_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_marca_idColumnIndex))
						record.ARTICULO_MARCA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_marca_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_vendidaColumnIndex))
						record.CANTIDAD_VENDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_vendidaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_vendido_usdColumnIndex))
						record.MONTO_VENDIDO_USD = Math.Round(Convert.ToDecimal(reader.GetValue(monto_vendido_usdColumnIndex)), 9);
					if(!reader.IsDBNull(monto_vendidoColumnIndex))
						record.MONTO_VENDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_vendidoColumnIndex)), 9);
					record.MONTO_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_linea_creditoColumnIndex)), 9);
					record.MONEDA_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_linea_creditoColumnIndex)), 9);
					record.MONEDA_LC_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_lc_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(credito_menos_debitoColumnIndex))
						record.CREDITO_MENOS_DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(credito_menos_debitoColumnIndex)), 9);
					if(!reader.IsDBNull(tot_cheq_no_deposit_ni_efectivColumnIndex))
						record.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV = Math.Round(Convert.ToDecimal(reader.GetValue(tot_cheq_no_deposit_ni_efectivColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_decimalesColumnIndex))
						record.CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_decimalesColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OBJETIVO_VENDEDOR_EXPLOTACIONRow[])(recordList.ToArray(typeof(OBJETIVO_VENDEDOR_EXPLOTACIONRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="OBJETIVO_VENDEDOR_EXPLOTACIONRow"/> object.</returns>
		protected virtual OBJETIVO_VENDEDOR_EXPLOTACIONRow MapRow(DataRow row)
		{
			OBJETIVO_VENDEDOR_EXPLOTACIONRow mappedObject = new OBJETIVO_VENDEDOR_EXPLOTACIONRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "FACTURA_CLIENTE_DETALLE_ID"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_DETALLE_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "VENDEDOR_COMISIONISTA_ID"
			dataColumn = dataTable.Columns["VENDEDOR_COMISIONISTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_COMISIONISTA_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR_NOMBRE"
			dataColumn = dataTable.Columns["VENDEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "FAMILIA_NOMBRE"
			dataColumn = dataTable.Columns["FAMILIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_NOMBRE = (string)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "GRUPO_NOMBRE"
			dataColumn = dataTable.Columns["GRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_NOMBRE = (string)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "SUBGRUPO_NOMBRE"
			dataColumn = dataTable.Columns["SUBGRUPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_MARCA_ID"
			dataColumn = dataTable.Columns["ARTICULO_MARCA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MARCA_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_VENDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_VENDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_VENDIDA = (decimal)row[dataColumn];
			// Column "MONTO_VENDIDO_USD"
			dataColumn = dataTable.Columns["MONTO_VENDIDO_USD"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_VENDIDO_USD = (decimal)row[dataColumn];
			// Column "MONTO_VENDIDO"
			dataColumn = dataTable.Columns["MONTO_VENDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_VENDIDO = (decimal)row[dataColumn];
			// Column "MONTO_LINEA_CREDITO"
			dataColumn = dataTable.Columns["MONTO_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_LINEA_CREDITO = (decimal)row[dataColumn];
			// Column "MONEDA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["MONEDA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_LINEA_CREDITO = (decimal)row[dataColumn];
			// Column "MONEDA_LC_COTIZACION"
			dataColumn = dataTable.Columns["MONEDA_LC_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_LC_COTIZACION = (decimal)row[dataColumn];
			// Column "CREDITO_MENOS_DEBITO"
			dataColumn = dataTable.Columns["CREDITO_MENOS_DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO_MENOS_DEBITO = (decimal)row[dataColumn];
			// Column "TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV"
			dataColumn = dataTable.Columns["TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_DECIMALES"
			dataColumn = dataTable.Columns["CANTIDAD_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DECIMALES = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>OBJETIVO_VENDEDOR_EXPLOTACION</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "OBJETIVO_VENDEDOR_EXPLOTACION";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_DETALLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_COMISIONISTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 951;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FAMILIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUBGRUPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_MARCA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_VENDIDA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_VENDIDO_USD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_VENDIDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_LINEA_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_LINEA_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_LC_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CREDITO_MENOS_DEBITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DECIMALES", typeof(decimal));
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
				case "FACTURA_CLIENTE_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VENDEDOR_COMISIONISTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FAMILIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_MARCA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_VENDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_VENDIDO_USD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_VENDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_LC_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO_MENOS_DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOT_CHEQ_NO_DEPOSIT_NI_EFECTIV":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of OBJETIVO_VENDEDOR_EXPLOTACIONCollection_Base class
}  // End of namespace
