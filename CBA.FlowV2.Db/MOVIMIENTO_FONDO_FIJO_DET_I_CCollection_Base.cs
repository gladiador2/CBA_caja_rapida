// <fileinfo name="MOVIMIENTO_FONDO_FIJO_DET_I_CCollection_Base.cs">
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
	/// The base class for <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MOVIMIENTO_FONDO_FIJO_DET_I_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string MOVIMIENTO_FONDO_FIJO_IDColumnName = "MOVIMIENTO_FONDO_FIJO_ID";
		public const string TIPO_TEXTO_PREDEFINIDO_IDColumnName = "TIPO_TEXTO_PREDEFINIDO_ID";
		public const string TIPO_TEXTO_PREDEFINIDOColumnName = "TIPO_TEXTO_PREDEFINIDO";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TEXTO_PREDEFINIDOColumnName = "TEXTO_PREDEFINIDO";
		public const string COMENTARIOColumnName = "COMENTARIO";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string SIMBOLO_ORIGENColumnName = "SIMBOLO_ORIGEN";
		public const string MONEDA_ORIGENColumnName = "MONEDA_ORIGEN";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string SIMBOLO_DESTINOColumnName = "SIMBOLO_DESTINO";
		public const string MONEDA_DESTINOColumnName = "MONEDA_DESTINO";
		public const string COTIZACION_ORIGENColumnName = "COTIZACION_ORIGEN";
		public const string COTIZACION_DESTINOColumnName = "COTIZACION_DESTINO";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string MONTO_INGRESO_ORIGENColumnName = "MONTO_INGRESO_ORIGEN";
		public const string MONTO_INGRESO_DESTINOColumnName = "MONTO_INGRESO_DESTINO";
		public const string MONTO_EGRESO_ORIGENColumnName = "MONTO_EGRESO_ORIGEN";
		public const string MONTO_EGRESO_DESTINOColumnName = "MONTO_EGRESO_DESTINO";
		public const string SUCURSAL_MOVIMIENTO_IDColumnName = "SUCURSAL_MOVIMIENTO_ID";
		public const string SUCURSAL_MOVIMIENTO_NOMBREColumnName = "SUCURSAL_MOVIMIENTO_NOMBRE";
		public const string SUCURSAL_MOVIMIENTO_ABREColumnName = "SUCURSAL_MOVIMIENTO_ABRE";
		public const string MONTO_TOTAL_ORIGENColumnName = "MONTO_TOTAL_ORIGEN";
		public const string MONTO_TOTAL_DESTINOColumnName = "MONTO_TOTAL_DESTINO";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_NOMBREColumnName = "FUNCIONARIO_NOMBRE";
		public const string FUNCIONARIO_CODIGOColumnName = "FUNCIONARIO_CODIGO";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PROVEEDOR_NOMBREColumnName = "PROVEEDOR_NOMBRE";
		public const string PROVEEDOR_CODIGOColumnName = "PROVEEDOR_CODIGO";
		public const string ESTADOColumnName = "ESTADO";
		public const string GENERAR_ADELANTO_FUNCColumnName = "GENERAR_ADELANTO_FUNC";
		public const string GENERAR_ANTICIPO_PROVEEDORColumnName = "GENERAR_ANTICIPO_PROVEEDOR";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public MOVIMIENTO_FONDO_FIJO_DET_I_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>MOVIMIENTO_FONDO_FIJO_DET_I_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DET_I_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MOVIMIENTO_FONDO_FIJO_DET_I_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MOVIMIENTO_FONDO_FIJO_DET_I_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MOVIMIENTO_FONDO_FIJO_DET_I_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MOVIMIENTO_FONDO_FIJO_DET_I_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects.</returns>
		public MOVIMIENTO_FONDO_FIJO_DET_I_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects that 
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects.</returns>
		public virtual MOVIMIENTO_FONDO_FIJO_DET_I_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.MOVIMIENTO_FONDO_FIJO_DET_I_C";
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects.</returns>
		protected MOVIMIENTO_FONDO_FIJO_DET_I_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects.</returns>
		protected MOVIMIENTO_FONDO_FIJO_DET_I_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> objects.</returns>
		protected virtual MOVIMIENTO_FONDO_FIJO_DET_I_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int movimiento_fondo_fijo_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_FONDO_FIJO_ID");
			int tipo_texto_predefinido_idColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEFINIDO_ID");
			int tipo_texto_predefinidoColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEFINIDO");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int texto_predefinidoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO");
			int comentarioColumnIndex = reader.GetOrdinal("COMENTARIO");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int simbolo_origenColumnIndex = reader.GetOrdinal("SIMBOLO_ORIGEN");
			int moneda_origenColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int simbolo_destinoColumnIndex = reader.GetOrdinal("SIMBOLO_DESTINO");
			int moneda_destinoColumnIndex = reader.GetOrdinal("MONEDA_DESTINO");
			int cotizacion_origenColumnIndex = reader.GetOrdinal("COTIZACION_ORIGEN");
			int cotizacion_destinoColumnIndex = reader.GetOrdinal("COTIZACION_DESTINO");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int monto_ingreso_origenColumnIndex = reader.GetOrdinal("MONTO_INGRESO_ORIGEN");
			int monto_ingreso_destinoColumnIndex = reader.GetOrdinal("MONTO_INGRESO_DESTINO");
			int monto_egreso_origenColumnIndex = reader.GetOrdinal("MONTO_EGRESO_ORIGEN");
			int monto_egreso_destinoColumnIndex = reader.GetOrdinal("MONTO_EGRESO_DESTINO");
			int sucursal_movimiento_idColumnIndex = reader.GetOrdinal("SUCURSAL_MOVIMIENTO_ID");
			int sucursal_movimiento_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_MOVIMIENTO_NOMBRE");
			int sucursal_movimiento_abreColumnIndex = reader.GetOrdinal("SUCURSAL_MOVIMIENTO_ABRE");
			int monto_total_origenColumnIndex = reader.GetOrdinal("MONTO_TOTAL_ORIGEN");
			int monto_total_destinoColumnIndex = reader.GetOrdinal("MONTO_TOTAL_DESTINO");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE");
			int funcionario_codigoColumnIndex = reader.GetOrdinal("FUNCIONARIO_CODIGO");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int proveedor_nombreColumnIndex = reader.GetOrdinal("PROVEEDOR_NOMBRE");
			int proveedor_codigoColumnIndex = reader.GetOrdinal("PROVEEDOR_CODIGO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int generar_adelanto_funcColumnIndex = reader.GetOrdinal("GENERAR_ADELANTO_FUNC");
			int generar_anticipo_proveedorColumnIndex = reader.GetOrdinal("GENERAR_ANTICIPO_PROVEEDOR");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					MOVIMIENTO_FONDO_FIJO_DET_I_CRow record = new MOVIMIENTO_FONDO_FIJO_DET_I_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.MOVIMIENTO_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_fondo_fijo_idColumnIndex)), 9);
					record.TIPO_TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_texto_predefinido_idColumnIndex)), 9);
					record.TIPO_TEXTO_PREDEFINIDO = Convert.ToString(reader.GetValue(tipo_texto_predefinidoColumnIndex));
					record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					record.TEXTO_PREDEFINIDO = Convert.ToString(reader.GetValue(texto_predefinidoColumnIndex));
					if(!reader.IsDBNull(comentarioColumnIndex))
						record.COMENTARIO = Convert.ToString(reader.GetValue(comentarioColumnIndex));
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.SIMBOLO_ORIGEN = Convert.ToString(reader.GetValue(simbolo_origenColumnIndex));
					record.MONEDA_ORIGEN = Convert.ToString(reader.GetValue(moneda_origenColumnIndex));
					record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					record.SIMBOLO_DESTINO = Convert.ToString(reader.GetValue(simbolo_destinoColumnIndex));
					record.MONEDA_DESTINO = Convert.ToString(reader.GetValue(moneda_destinoColumnIndex));
					record.COTIZACION_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_origenColumnIndex)), 9);
					record.COTIZACION_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_destinoColumnIndex)), 9);
					record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					record.MONTO_INGRESO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_ingreso_origenColumnIndex)), 9);
					record.MONTO_INGRESO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_ingreso_destinoColumnIndex)), 9);
					record.MONTO_EGRESO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_egreso_origenColumnIndex)), 9);
					record.MONTO_EGRESO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_egreso_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_movimiento_idColumnIndex))
						record.SUCURSAL_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_movimiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_movimiento_nombreColumnIndex))
						record.SUCURSAL_MOVIMIENTO_NOMBRE = Convert.ToString(reader.GetValue(sucursal_movimiento_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_movimiento_abreColumnIndex))
						record.SUCURSAL_MOVIMIENTO_ABRE = Convert.ToString(reader.GetValue(sucursal_movimiento_abreColumnIndex));
					if(!reader.IsDBNull(monto_total_origenColumnIndex))
						record.MONTO_TOTAL_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_origenColumnIndex)), 9);
					if(!reader.IsDBNull(monto_total_destinoColumnIndex))
						record.MONTO_TOTAL_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_nombreColumnIndex))
						record.FUNCIONARIO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_codigoColumnIndex))
						record.FUNCIONARIO_CODIGO = Convert.ToString(reader.GetValue(funcionario_codigoColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_nombreColumnIndex))
						record.PROVEEDOR_NOMBRE = Convert.ToString(reader.GetValue(proveedor_nombreColumnIndex));
					if(!reader.IsDBNull(proveedor_codigoColumnIndex))
						record.PROVEEDOR_CODIGO = Convert.ToString(reader.GetValue(proveedor_codigoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.GENERAR_ADELANTO_FUNC = Convert.ToString(reader.GetValue(generar_adelanto_funcColumnIndex));
					record.GENERAR_ANTICIPO_PROVEEDOR = Convert.ToString(reader.GetValue(generar_anticipo_proveedorColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MOVIMIENTO_FONDO_FIJO_DET_I_CRow[])(recordList.ToArray(typeof(MOVIMIENTO_FONDO_FIJO_DET_I_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MOVIMIENTO_FONDO_FIJO_DET_I_CRow"/> object.</returns>
		protected virtual MOVIMIENTO_FONDO_FIJO_DET_I_CRow MapRow(DataRow row)
		{
			MOVIMIENTO_FONDO_FIJO_DET_I_CRow mappedObject = new MOVIMIENTO_FONDO_FIJO_DET_I_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEFINIDO"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEFINIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEFINIDO = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO = (string)row[dataColumn];
			// Column "COMENTARIO"
			dataColumn = dataTable.Columns["COMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMENTARIO = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SIMBOLO_ORIGEN"
			dataColumn = dataTable.Columns["SIMBOLO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.SIMBOLO_ORIGEN = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN = (string)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "SIMBOLO_DESTINO"
			dataColumn = dataTable.Columns["SIMBOLO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SIMBOLO_DESTINO = (string)row[dataColumn];
			// Column "MONEDA_DESTINO"
			dataColumn = dataTable.Columns["MONEDA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO = (string)row[dataColumn];
			// Column "COTIZACION_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_ORIGEN = (decimal)row[dataColumn];
			// Column "COTIZACION_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "MONTO_INGRESO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_INGRESO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INGRESO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_INGRESO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_INGRESO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INGRESO_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_EGRESO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_EGRESO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EGRESO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_EGRESO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_EGRESO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EGRESO_DESTINO = (decimal)row[dataColumn];
			// Column "SUCURSAL_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_MOVIMIENTO_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_MOVIMIENTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_MOVIMIENTO_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_MOVIMIENTO_ABRE"
			dataColumn = dataTable.Columns["SUCURSAL_MOVIMIENTO_ABRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_MOVIMIENTO_ABRE = (string)row[dataColumn];
			// Column "MONTO_TOTAL_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_TOTAL_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL_DESTINO"
			dataColumn = dataTable.Columns["MONTO_TOTAL_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_DESTINO = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_CODIGO"
			dataColumn = dataTable.Columns["FUNCIONARIO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CODIGO = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_NOMBRE"
			dataColumn = dataTable.Columns["PROVEEDOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_NOMBRE = (string)row[dataColumn];
			// Column "PROVEEDOR_CODIGO"
			dataColumn = dataTable.Columns["PROVEEDOR_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_CODIGO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "GENERAR_ADELANTO_FUNC"
			dataColumn = dataTable.Columns["GENERAR_ADELANTO_FUNC"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_ADELANTO_FUNC = (string)row[dataColumn];
			// Column "GENERAR_ANTICIPO_PROVEEDOR"
			dataColumn = dataTable.Columns["GENERAR_ANTICIPO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_ANTICIPO_PROVEEDOR = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>MOVIMIENTO_FONDO_FIJO_DET_I_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MOVIMIENTO_FONDO_FIJO_DET_I_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEFINIDO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMENTARIO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SIMBOLO_ORIGEN", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SIMBOLO_DESTINO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_INGRESO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_INGRESO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_EGRESO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_EGRESO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_MOVIMIENTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_MOVIMIENTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_MOVIMIENTO_ABRE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERAR_ADELANTO_FUNC", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERAR_ANTICIPO_PROVEEDOR", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "MOVIMIENTO_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_TEXTO_PREDEFINIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SIMBOLO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SIMBOLO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INGRESO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INGRESO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_EGRESO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_EGRESO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_MOVIMIENTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_MOVIMIENTO_ABRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_TOTAL_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GENERAR_ADELANTO_FUNC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GENERAR_ANTICIPO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of MOVIMIENTO_FONDO_FIJO_DET_I_CCollection_Base class
}  // End of namespace
