// <fileinfo name="STOCK_ARTICULOS_RESERVACollection_Base.cs">
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
	/// The base class for <see cref="STOCK_ARTICULOS_RESERVACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_ARTICULOS_RESERVACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_ARTICULOS_RESERVACollection_Base
	{
		// Constants
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSALColumnName = "SUCURSAL";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITOColumnName = "DEPOSITO";
		public const string ARTICULO_LOTE_IDColumnName = "ARTICULO_LOTE_ID";
		public const string LOTEColumnName = "LOTE";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULOColumnName = "ARTICULO";
		public const string RESERVADO_FACTURADOColumnName = "RESERVADO_FACTURADO";
		public const string RESERVADO_PEDIDOColumnName = "RESERVADO_PEDIDO";
		public const string RESERVADO_TRANSFERENCIAColumnName = "RESERVADO_TRANSFERENCIA";
		public const string RESERVADO_PROD_BALANColumnName = "RESERVADO_PROD_BALAN";
		public const string RESERVADO_PROD_BALAN_MATERIALColumnName = "RESERVADO_PROD_BALAN_MATERIAL";
		public const string RESERVADO_EGRESO_PRODUCTOColumnName = "RESERVADO_EGRESO_PRODUCTO";
		public const string RESERVADO_EGRESO_PROD_MATERIALColumnName = "RESERVADO_EGRESO_PROD_MATERIAL";
		public const string CANT_RESERVADAColumnName = "CANT_RESERVADA";
		public const string DISPONIBLEColumnName = "DISPONIBLE";
		public const string EXISTENCIAColumnName = "EXISTENCIA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_ARTICULOS_RESERVACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_ARTICULOS_RESERVACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_ARTICULOS_RESERVA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects.</returns>
		public virtual STOCK_ARTICULOS_RESERVARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_ARTICULOS_RESERVA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_ARTICULOS_RESERVA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_ARTICULOS_RESERVARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_ARTICULOS_RESERVARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_ARTICULOS_RESERVARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_ARTICULOS_RESERVARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects.</returns>
		public STOCK_ARTICULOS_RESERVARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects.</returns>
		public virtual STOCK_ARTICULOS_RESERVARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_ARTICULOS_RESERVA";
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
		/// <returns>An array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects.</returns>
		protected STOCK_ARTICULOS_RESERVARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects.</returns>
		protected STOCK_ARTICULOS_RESERVARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_ARTICULOS_RESERVARow"/> objects.</returns>
		protected virtual STOCK_ARTICULOS_RESERVARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursalColumnIndex = reader.GetOrdinal("SUCURSAL");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int depositoColumnIndex = reader.GetOrdinal("DEPOSITO");
			int articulo_lote_idColumnIndex = reader.GetOrdinal("ARTICULO_LOTE_ID");
			int loteColumnIndex = reader.GetOrdinal("LOTE");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articuloColumnIndex = reader.GetOrdinal("ARTICULO");
			int reservado_facturadoColumnIndex = reader.GetOrdinal("RESERVADO_FACTURADO");
			int reservado_pedidoColumnIndex = reader.GetOrdinal("RESERVADO_PEDIDO");
			int reservado_transferenciaColumnIndex = reader.GetOrdinal("RESERVADO_TRANSFERENCIA");
			int reservado_prod_balanColumnIndex = reader.GetOrdinal("RESERVADO_PROD_BALAN");
			int reservado_prod_balan_materialColumnIndex = reader.GetOrdinal("RESERVADO_PROD_BALAN_MATERIAL");
			int reservado_egreso_productoColumnIndex = reader.GetOrdinal("RESERVADO_EGRESO_PRODUCTO");
			int reservado_egreso_prod_materialColumnIndex = reader.GetOrdinal("RESERVADO_EGRESO_PROD_MATERIAL");
			int cant_reservadaColumnIndex = reader.GetOrdinal("CANT_RESERVADA");
			int disponibleColumnIndex = reader.GetOrdinal("DISPONIBLE");
			int existenciaColumnIndex = reader.GetOrdinal("EXISTENCIA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_ARTICULOS_RESERVARow record = new STOCK_ARTICULOS_RESERVARow();
					recordList.Add(record);

					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL = Convert.ToString(reader.GetValue(sucursalColumnIndex));
					record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.DEPOSITO = Convert.ToString(reader.GetValue(depositoColumnIndex));
					if(!reader.IsDBNull(articulo_lote_idColumnIndex))
						record.ARTICULO_LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(loteColumnIndex))
						record.LOTE = Convert.ToString(reader.GetValue(loteColumnIndex));
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articuloColumnIndex))
						record.ARTICULO = Convert.ToString(reader.GetValue(articuloColumnIndex));
					if(!reader.IsDBNull(reservado_facturadoColumnIndex))
						record.RESERVADO_FACTURADO = Math.Round(Convert.ToDecimal(reader.GetValue(reservado_facturadoColumnIndex)), 9);
					if(!reader.IsDBNull(reservado_pedidoColumnIndex))
						record.RESERVADO_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(reservado_pedidoColumnIndex)), 9);
					if(!reader.IsDBNull(reservado_transferenciaColumnIndex))
						record.RESERVADO_TRANSFERENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(reservado_transferenciaColumnIndex)), 9);
					if(!reader.IsDBNull(reservado_prod_balanColumnIndex))
						record.RESERVADO_PROD_BALAN = Math.Round(Convert.ToDecimal(reader.GetValue(reservado_prod_balanColumnIndex)), 9);
					if(!reader.IsDBNull(reservado_prod_balan_materialColumnIndex))
						record.RESERVADO_PROD_BALAN_MATERIAL = Math.Round(Convert.ToDecimal(reader.GetValue(reservado_prod_balan_materialColumnIndex)), 9);
					if(!reader.IsDBNull(reservado_egreso_productoColumnIndex))
						record.RESERVADO_EGRESO_PRODUCTO = Math.Round(Convert.ToDecimal(reader.GetValue(reservado_egreso_productoColumnIndex)), 9);
					if(!reader.IsDBNull(reservado_egreso_prod_materialColumnIndex))
						record.RESERVADO_EGRESO_PROD_MATERIAL = Math.Round(Convert.ToDecimal(reader.GetValue(reservado_egreso_prod_materialColumnIndex)), 9);
					if(!reader.IsDBNull(cant_reservadaColumnIndex))
						record.CANT_RESERVADA = Math.Round(Convert.ToDecimal(reader.GetValue(cant_reservadaColumnIndex)), 9);
					if(!reader.IsDBNull(disponibleColumnIndex))
						record.DISPONIBLE = Math.Round(Convert.ToDecimal(reader.GetValue(disponibleColumnIndex)), 9);
					record.EXISTENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(existenciaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_ARTICULOS_RESERVARow[])(recordList.ToArray(typeof(STOCK_ARTICULOS_RESERVARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_ARTICULOS_RESERVARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_ARTICULOS_RESERVARow"/> object.</returns>
		protected virtual STOCK_ARTICULOS_RESERVARow MapRow(DataRow row)
		{
			STOCK_ARTICULOS_RESERVARow mappedObject = new STOCK_ARTICULOS_RESERVARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL"
			dataColumn = dataTable.Columns["SUCURSAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL = (string)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO"
			dataColumn = dataTable.Columns["DEPOSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO = (string)row[dataColumn];
			// Column "ARTICULO_LOTE_ID"
			dataColumn = dataTable.Columns["ARTICULO_LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LOTE_ID = (decimal)row[dataColumn];
			// Column "LOTE"
			dataColumn = dataTable.Columns["LOTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO"
			dataColumn = dataTable.Columns["ARTICULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO = (string)row[dataColumn];
			// Column "RESERVADO_FACTURADO"
			dataColumn = dataTable.Columns["RESERVADO_FACTURADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESERVADO_FACTURADO = (decimal)row[dataColumn];
			// Column "RESERVADO_PEDIDO"
			dataColumn = dataTable.Columns["RESERVADO_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESERVADO_PEDIDO = (decimal)row[dataColumn];
			// Column "RESERVADO_TRANSFERENCIA"
			dataColumn = dataTable.Columns["RESERVADO_TRANSFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESERVADO_TRANSFERENCIA = (decimal)row[dataColumn];
			// Column "RESERVADO_PROD_BALAN"
			dataColumn = dataTable.Columns["RESERVADO_PROD_BALAN"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESERVADO_PROD_BALAN = (decimal)row[dataColumn];
			// Column "RESERVADO_PROD_BALAN_MATERIAL"
			dataColumn = dataTable.Columns["RESERVADO_PROD_BALAN_MATERIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESERVADO_PROD_BALAN_MATERIAL = (decimal)row[dataColumn];
			// Column "RESERVADO_EGRESO_PRODUCTO"
			dataColumn = dataTable.Columns["RESERVADO_EGRESO_PRODUCTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESERVADO_EGRESO_PRODUCTO = (decimal)row[dataColumn];
			// Column "RESERVADO_EGRESO_PROD_MATERIAL"
			dataColumn = dataTable.Columns["RESERVADO_EGRESO_PROD_MATERIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESERVADO_EGRESO_PROD_MATERIAL = (decimal)row[dataColumn];
			// Column "CANT_RESERVADA"
			dataColumn = dataTable.Columns["CANT_RESERVADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANT_RESERVADA = (decimal)row[dataColumn];
			// Column "DISPONIBLE"
			dataColumn = dataTable.Columns["DISPONIBLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DISPONIBLE = (decimal)row[dataColumn];
			// Column "EXISTENCIA"
			dataColumn = dataTable.Columns["EXISTENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_ARTICULOS_RESERVA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_ARTICULOS_RESERVA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_LOTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO", typeof(string));
			dataColumn.MaxLength = 900;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESERVADO_FACTURADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESERVADO_PEDIDO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESERVADO_TRANSFERENCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESERVADO_PROD_BALAN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESERVADO_PROD_BALAN_MATERIAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESERVADO_EGRESO_PRODUCTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESERVADO_EGRESO_PROD_MATERIAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANT_RESERVADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DISPONIBLE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXISTENCIA", typeof(decimal));
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
				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RESERVADO_FACTURADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESERVADO_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESERVADO_TRANSFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESERVADO_PROD_BALAN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESERVADO_PROD_BALAN_MATERIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESERVADO_EGRESO_PRODUCTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESERVADO_EGRESO_PROD_MATERIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANT_RESERVADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DISPONIBLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EXISTENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_ARTICULOS_RESERVACollection_Base class
}  // End of namespace
