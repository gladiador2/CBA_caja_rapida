// <fileinfo name="PLANILLA_LIQ_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_LIQ_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_LIQ_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_LIQ_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASOS_ESTADOColumnName = "CASOS_ESTADO";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSALES_NOMBREColumnName = "SUCURSALES_NOMBRE";
		public const string SUCURSALES_ABREVIATURASColumnName = "SUCURSALES_ABREVIATURAS";
		public const string SUCURSALES_ENTIDAD_IDColumnName = "SUCURSALES_ENTIDAD_ID";
		public const string SUCURSALES_ENTIDAD_NOMBREColumnName = "SUCURSALES_ENTIDAD_NOMBRE";
		public const string TIPOColumnName = "TIPO";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string USUARIOS_USUARIOColumnName = "USUARIOS_USUARIO";
		public const string FECHA_DESDEColumnName = "FECHA_DESDE";
		public const string FECHA_HASTAColumnName = "FECHA_HASTA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDAS_NOMBRESColumnName = "MONEDAS_NOMBRES";
		public const string MONEDAS_SIMBOLOSColumnName = "MONEDAS_SIMBOLOS";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string TOTALColumnName = "TOTAL";
		public const string CTACTECAJATESORERIA_IDColumnName = "CTACTECAJATESORERIA_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_LIQ_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_LIQ_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_LIQ_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects.</returns>
		public virtual PLANILLA_LIQ_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_LIQ_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_LIQ_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_LIQ_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_LIQ_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects.</returns>
		public PLANILLA_LIQ_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects.</returns>
		public virtual PLANILLA_LIQ_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_LIQ_INFO_COMPL";
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
		/// <returns>An array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects.</returns>
		protected PLANILLA_LIQ_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects.</returns>
		protected PLANILLA_LIQ_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> objects.</returns>
		protected virtual PLANILLA_LIQ_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int casos_estadoColumnIndex = reader.GetOrdinal("CASOS_ESTADO");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursales_nombreColumnIndex = reader.GetOrdinal("SUCURSALES_NOMBRE");
			int sucursales_abreviaturasColumnIndex = reader.GetOrdinal("SUCURSALES_ABREVIATURAS");
			int sucursales_entidad_idColumnIndex = reader.GetOrdinal("SUCURSALES_ENTIDAD_ID");
			int sucursales_entidad_nombreColumnIndex = reader.GetOrdinal("SUCURSALES_ENTIDAD_NOMBRE");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int usuarios_usuarioColumnIndex = reader.GetOrdinal("USUARIOS_USUARIO");
			int fecha_desdeColumnIndex = reader.GetOrdinal("FECHA_DESDE");
			int fecha_hastaColumnIndex = reader.GetOrdinal("FECHA_HASTA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monedas_nombresColumnIndex = reader.GetOrdinal("MONEDAS_NOMBRES");
			int monedas_simbolosColumnIndex = reader.GetOrdinal("MONEDAS_SIMBOLOS");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int totalColumnIndex = reader.GetOrdinal("TOTAL");
			int ctactecajatesoreria_idColumnIndex = reader.GetOrdinal("CTACTECAJATESORERIA_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_LIQ_INFO_COMPLRow record = new PLANILLA_LIQ_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASOS_ESTADO = Convert.ToString(reader.GetValue(casos_estadoColumnIndex));
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSALES_NOMBRE = Convert.ToString(reader.GetValue(sucursales_nombreColumnIndex));
					record.SUCURSALES_ABREVIATURAS = Convert.ToString(reader.GetValue(sucursales_abreviaturasColumnIndex));
					record.SUCURSALES_ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursales_entidad_idColumnIndex)), 9);
					record.SUCURSALES_ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(sucursales_entidad_nombreColumnIndex));
					record.TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(tipoColumnIndex)), 9);
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.USUARIOS_USUARIO = Convert.ToString(reader.GetValue(usuarios_usuarioColumnIndex));
					record.FECHA_DESDE = Convert.ToDateTime(reader.GetValue(fecha_desdeColumnIndex));
					record.FECHA_HASTA = Convert.ToDateTime(reader.GetValue(fecha_hastaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDAS_NOMBRES = Convert.ToString(reader.GetValue(monedas_nombresColumnIndex));
					record.MONEDAS_SIMBOLOS = Convert.ToString(reader.GetValue(monedas_simbolosColumnIndex));
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(totalColumnIndex)), 9);
					if(!reader.IsDBNull(ctactecajatesoreria_idColumnIndex))
						record.CTACTECAJATESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctactecajatesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_LIQ_INFO_COMPLRow[])(recordList.ToArray(typeof(PLANILLA_LIQ_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_LIQ_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_LIQ_INFO_COMPLRow"/> object.</returns>
		protected virtual PLANILLA_LIQ_INFO_COMPLRow MapRow(DataRow row)
		{
			PLANILLA_LIQ_INFO_COMPLRow mappedObject = new PLANILLA_LIQ_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASOS_ESTADO"
			dataColumn = dataTable.Columns["CASOS_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASOS_ESTADO = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSALES_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSALES_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSALES_ABREVIATURAS"
			dataColumn = dataTable.Columns["SUCURSALES_ABREVIATURAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ABREVIATURAS = (string)row[dataColumn];
			// Column "SUCURSALES_ENTIDAD_ID"
			dataColumn = dataTable.Columns["SUCURSALES_ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "SUCURSALES_ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSALES_ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "USUARIOS_USUARIO"
			dataColumn = dataTable.Columns["USUARIOS_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIOS_USUARIO = (string)row[dataColumn];
			// Column "FECHA_DESDE"
			dataColumn = dataTable.Columns["FECHA_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESDE = (System.DateTime)row[dataColumn];
			// Column "FECHA_HASTA"
			dataColumn = dataTable.Columns["FECHA_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HASTA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDAS_NOMBRES"
			dataColumn = dataTable.Columns["MONEDAS_NOMBRES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_NOMBRES = (string)row[dataColumn];
			// Column "MONEDAS_SIMBOLOS"
			dataColumn = dataTable.Columns["MONEDAS_SIMBOLOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_SIMBOLOS = (string)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "TOTAL"
			dataColumn = dataTable.Columns["TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL = (decimal)row[dataColumn];
			// Column "CTACTECAJATESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTECAJATESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTECAJATESORERIA_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_LIQ_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_LIQ_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASOS_ESTADO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSALES_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSALES_ABREVIATURAS", typeof(string));
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
			dataColumn = dataTable.Columns.Add("TIPO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIOS_USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_DESDE", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_HASTA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_NOMBRES", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_SIMBOLOS", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTECAJATESORERIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASOS_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSALES_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSALES_ABREVIATURAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSALES_ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSALES_ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIOS_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDAS_NOMBRES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDAS_SIMBOLOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTECAJATESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_LIQ_INFO_COMPLCollection_Base class
}  // End of namespace
