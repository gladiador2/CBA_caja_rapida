// <fileinfo name="STOCK_SUC_DEPO_ART_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_SUC_DEPO_ART_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_SUC_DEPO_ART_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_SUC_DEPO_ART_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITO_NOMBREColumnName = "DEPOSITO_NOMBRE";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_NOMBREColumnName = "ARTICULO_NOMBRE";
		public const string ARTICULO_LOTE_IDColumnName = "ARTICULO_LOTE_ID";
		public const string LOTE_NOMBREColumnName = "LOTE_NOMBRE";
		public const string UNIDAD_MEDIDA_IDColumnName = "UNIDAD_MEDIDA_ID";
		public const string UNIDAD_MEDIDAColumnName = "UNIDAD_MEDIDA";
		public const string EXISTENCIA_INICIALColumnName = "EXISTENCIA_INICIAL";
		public const string COMPRAColumnName = "COMPRA";
		public const string AJUSTE_POSITIVOColumnName = "AJUSTE_POSITIVO";
		public const string TRANSFERENCIA_ENTRADAColumnName = "TRANSFERENCIA_ENTRADA";
		public const string NOTA_CREDITO_CLIENTEColumnName = "NOTA_CREDITO_CLIENTE";
		public const string NOTA_DEBITO_PROVEEDORColumnName = "NOTA_DEBITO_PROVEEDOR";
		public const string TRANSITOColumnName = "TRANSITO";
		public const string INDUSTRIALIZACIONColumnName = "INDUSTRIALIZACION";
		public const string PUNTO_MINIMOColumnName = "PUNTO_MINIMO";
		public const string COMBOS_ELIMINADOSColumnName = "COMBOS_ELIMINADOS";
		public const string EXISTENCIAColumnName = "EXISTENCIA";
		public const string VENTAColumnName = "VENTA";
		public const string TRANSFERENCIA_SALIDAColumnName = "TRANSFERENCIA_SALIDA";
		public const string AJUSTE_NEGATIVOColumnName = "AJUSTE_NEGATIVO";
		public const string NOTA_DEBITO_CLIENTEColumnName = "NOTA_DEBITO_CLIENTE";
		public const string NOTA_CREDITO_PROVEEDORColumnName = "NOTA_CREDITO_PROVEEDOR";
		public const string USO_DE_INSUMOColumnName = "USO_DE_INSUMO";
		public const string COMBOS_CREADOSColumnName = "COMBOS_CREADOS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_SUC_DEPO_ART_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_SUC_DEPO_ART_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_SUC_DEPO_ART_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects.</returns>
		public virtual STOCK_SUC_DEPO_ART_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_SUC_DEPO_ART_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_SUC_DEPO_ART_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_SUC_DEPO_ART_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_SUC_DEPO_ART_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects.</returns>
		public STOCK_SUC_DEPO_ART_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects.</returns>
		public virtual STOCK_SUC_DEPO_ART_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_SUC_DEPO_ART_INF_COMP";
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
		/// <returns>An array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects.</returns>
		protected STOCK_SUC_DEPO_ART_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects.</returns>
		protected STOCK_SUC_DEPO_ART_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> objects.</returns>
		protected virtual STOCK_SUC_DEPO_ART_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int deposito_nombreColumnIndex = reader.GetOrdinal("DEPOSITO_NOMBRE");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_nombreColumnIndex = reader.GetOrdinal("ARTICULO_NOMBRE");
			int articulo_lote_idColumnIndex = reader.GetOrdinal("ARTICULO_LOTE_ID");
			int lote_nombreColumnIndex = reader.GetOrdinal("LOTE_NOMBRE");
			int unidad_medida_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ID");
			int unidad_medidaColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA");
			int existencia_inicialColumnIndex = reader.GetOrdinal("EXISTENCIA_INICIAL");
			int compraColumnIndex = reader.GetOrdinal("COMPRA");
			int ajuste_positivoColumnIndex = reader.GetOrdinal("AJUSTE_POSITIVO");
			int transferencia_entradaColumnIndex = reader.GetOrdinal("TRANSFERENCIA_ENTRADA");
			int nota_credito_clienteColumnIndex = reader.GetOrdinal("NOTA_CREDITO_CLIENTE");
			int nota_debito_proveedorColumnIndex = reader.GetOrdinal("NOTA_DEBITO_PROVEEDOR");
			int transitoColumnIndex = reader.GetOrdinal("TRANSITO");
			int industrializacionColumnIndex = reader.GetOrdinal("INDUSTRIALIZACION");
			int punto_minimoColumnIndex = reader.GetOrdinal("PUNTO_MINIMO");
			int combos_eliminadosColumnIndex = reader.GetOrdinal("COMBOS_ELIMINADOS");
			int existenciaColumnIndex = reader.GetOrdinal("EXISTENCIA");
			int ventaColumnIndex = reader.GetOrdinal("VENTA");
			int transferencia_salidaColumnIndex = reader.GetOrdinal("TRANSFERENCIA_SALIDA");
			int ajuste_negativoColumnIndex = reader.GetOrdinal("AJUSTE_NEGATIVO");
			int nota_debito_clienteColumnIndex = reader.GetOrdinal("NOTA_DEBITO_CLIENTE");
			int nota_credito_proveedorColumnIndex = reader.GetOrdinal("NOTA_CREDITO_PROVEEDOR");
			int uso_de_insumoColumnIndex = reader.GetOrdinal("USO_DE_INSUMO");
			int combos_creadosColumnIndex = reader.GetOrdinal("COMBOS_CREADOS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_SUC_DEPO_ART_INF_COMPRow record = new STOCK_SUC_DEPO_ART_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.DEPOSITO_NOMBRE = Convert.ToString(reader.GetValue(deposito_nombreColumnIndex));
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_nombreColumnIndex))
						record.ARTICULO_NOMBRE = Convert.ToString(reader.GetValue(articulo_nombreColumnIndex));
					if(!reader.IsDBNull(articulo_lote_idColumnIndex))
						record.ARTICULO_LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_nombreColumnIndex))
						record.LOTE_NOMBRE = Convert.ToString(reader.GetValue(lote_nombreColumnIndex));
					record.UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(unidad_medida_idColumnIndex));
					if(!reader.IsDBNull(unidad_medidaColumnIndex))
						record.UNIDAD_MEDIDA = Convert.ToString(reader.GetValue(unidad_medidaColumnIndex));
					record.EXISTENCIA_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(existencia_inicialColumnIndex)), 9);
					record.COMPRA = Math.Round(Convert.ToDecimal(reader.GetValue(compraColumnIndex)), 9);
					record.AJUSTE_POSITIVO = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_positivoColumnIndex)), 9);
					record.TRANSFERENCIA_ENTRADA = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_entradaColumnIndex)), 9);
					record.NOTA_CREDITO_CLIENTE = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_clienteColumnIndex)), 9);
					record.NOTA_DEBITO_PROVEEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(nota_debito_proveedorColumnIndex)), 9);
					record.TRANSITO = Math.Round(Convert.ToDecimal(reader.GetValue(transitoColumnIndex)), 9);
					if(!reader.IsDBNull(industrializacionColumnIndex))
						record.INDUSTRIALIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(industrializacionColumnIndex)), 9);
					if(!reader.IsDBNull(punto_minimoColumnIndex))
						record.PUNTO_MINIMO = Math.Round(Convert.ToDecimal(reader.GetValue(punto_minimoColumnIndex)), 9);
					record.COMBOS_ELIMINADOS = Math.Round(Convert.ToDecimal(reader.GetValue(combos_eliminadosColumnIndex)), 9);
					record.EXISTENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(existenciaColumnIndex)), 9);
					record.VENTA = Math.Round(Convert.ToDecimal(reader.GetValue(ventaColumnIndex)), 9);
					record.TRANSFERENCIA_SALIDA = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_salidaColumnIndex)), 9);
					record.AJUSTE_NEGATIVO = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_negativoColumnIndex)), 9);
					record.NOTA_DEBITO_CLIENTE = Math.Round(Convert.ToDecimal(reader.GetValue(nota_debito_clienteColumnIndex)), 9);
					record.NOTA_CREDITO_PROVEEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_proveedorColumnIndex)), 9);
					record.USO_DE_INSUMO = Math.Round(Convert.ToDecimal(reader.GetValue(uso_de_insumoColumnIndex)), 9);
					record.COMBOS_CREADOS = Math.Round(Convert.ToDecimal(reader.GetValue(combos_creadosColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_SUC_DEPO_ART_INF_COMPRow[])(recordList.ToArray(typeof(STOCK_SUC_DEPO_ART_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_SUC_DEPO_ART_INF_COMPRow"/> object.</returns>
		protected virtual STOCK_SUC_DEPO_ART_INF_COMPRow MapRow(DataRow row)
		{
			STOCK_SUC_DEPO_ART_INF_COMPRow mappedObject = new STOCK_SUC_DEPO_ART_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_NOMBRE"
			dataColumn = dataTable.Columns["DEPOSITO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_NOMBRE"
			dataColumn = dataTable.Columns["ARTICULO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_NOMBRE = (string)row[dataColumn];
			// Column "ARTICULO_LOTE_ID"
			dataColumn = dataTable.Columns["ARTICULO_LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE_NOMBRE"
			dataColumn = dataTable.Columns["LOTE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_NOMBRE = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA = (string)row[dataColumn];
			// Column "EXISTENCIA_INICIAL"
			dataColumn = dataTable.Columns["EXISTENCIA_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA_INICIAL = (decimal)row[dataColumn];
			// Column "COMPRA"
			dataColumn = dataTable.Columns["COMPRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMPRA = (decimal)row[dataColumn];
			// Column "AJUSTE_POSITIVO"
			dataColumn = dataTable.Columns["AJUSTE_POSITIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_POSITIVO = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_ENTRADA"
			dataColumn = dataTable.Columns["TRANSFERENCIA_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_ENTRADA = (decimal)row[dataColumn];
			// Column "NOTA_CREDITO_CLIENTE"
			dataColumn = dataTable.Columns["NOTA_CREDITO_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_CLIENTE = (decimal)row[dataColumn];
			// Column "NOTA_DEBITO_PROVEEDOR"
			dataColumn = dataTable.Columns["NOTA_DEBITO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_DEBITO_PROVEEDOR = (decimal)row[dataColumn];
			// Column "TRANSITO"
			dataColumn = dataTable.Columns["TRANSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSITO = (decimal)row[dataColumn];
			// Column "INDUSTRIALIZACION"
			dataColumn = dataTable.Columns["INDUSTRIALIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.INDUSTRIALIZACION = (decimal)row[dataColumn];
			// Column "PUNTO_MINIMO"
			dataColumn = dataTable.Columns["PUNTO_MINIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUNTO_MINIMO = (decimal)row[dataColumn];
			// Column "COMBOS_ELIMINADOS"
			dataColumn = dataTable.Columns["COMBOS_ELIMINADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMBOS_ELIMINADOS = (decimal)row[dataColumn];
			// Column "EXISTENCIA"
			dataColumn = dataTable.Columns["EXISTENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA = (decimal)row[dataColumn];
			// Column "VENTA"
			dataColumn = dataTable.Columns["VENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENTA = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_SALIDA"
			dataColumn = dataTable.Columns["TRANSFERENCIA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_SALIDA = (decimal)row[dataColumn];
			// Column "AJUSTE_NEGATIVO"
			dataColumn = dataTable.Columns["AJUSTE_NEGATIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_NEGATIVO = (decimal)row[dataColumn];
			// Column "NOTA_DEBITO_CLIENTE"
			dataColumn = dataTable.Columns["NOTA_DEBITO_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_DEBITO_CLIENTE = (decimal)row[dataColumn];
			// Column "NOTA_CREDITO_PROVEEDOR"
			dataColumn = dataTable.Columns["NOTA_CREDITO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_PROVEEDOR = (decimal)row[dataColumn];
			// Column "USO_DE_INSUMO"
			dataColumn = dataTable.Columns["USO_DE_INSUMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_DE_INSUMO = (decimal)row[dataColumn];
			// Column "COMBOS_CREADOS"
			dataColumn = dataTable.Columns["COMBOS_CREADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMBOS_CREADOS = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_SUC_DEPO_ART_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_SUC_DEPO_ART_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXISTENCIA_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMPRA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_POSITIVO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_ENTRADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_CLIENTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_DEBITO_PROVEEDOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INDUSTRIALIZACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUNTO_MINIMO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMBOS_ELIMINADOS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXISTENCIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_SALIDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AJUSTE_NEGATIVO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_DEBITO_CLIENTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_PROVEEDOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USO_DE_INSUMO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMBOS_CREADOS", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EXISTENCIA_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMPRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_POSITIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_CREDITO_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_DEBITO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INDUSTRIALIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUNTO_MINIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMBOS_ELIMINADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EXISTENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_NEGATIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_DEBITO_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_CREDITO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_DE_INSUMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMBOS_CREADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_SUC_DEPO_ART_INF_COMPCollection_Base class
}  // End of namespace
