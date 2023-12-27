// <fileinfo name="CTB_ASIENTOS_AUTOM_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTOM_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string ENTIDAD_NOMBREColumnName = "ENTIDAD_NOMBRE";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string PAIS_NOMBREColumnName = "PAIS_NOMBRE";
		public const string TRANSICION_IDColumnName = "TRANSICION_ID";
		public const string TRANSICION_DESCRIPCIONColumnName = "TRANSICION_DESCRIPCION";
		public const string TRANSICION_FLUJO_IDColumnName = "TRANSICION_FLUJO_ID";
		public const string TRANSICION_FLUJO_DESCRIPCIONColumnName = "TRANSICION_FLUJO_DESCRIPCION";
		public const string ESTADOColumnName = "ESTADO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string REVISION_POSTERIORColumnName = "REVISION_POSTERIOR";
		public const string COPIAR_OBSERVACION_CASOColumnName = "COPIAR_OBSERVACION_CASO";
		public const string MOSTRAR_OBS_DET_REPORTEColumnName = "MOSTRAR_OBS_DET_REPORTE";
		public const string USAR_FECHA_TRANSICIONColumnName = "USAR_FECHA_TRANSICION";
		public const string ESTRUCTURA_OBSERVACIONColumnName = "ESTRUCTURA_OBSERVACION";
		public const string UNIFICAR_DETALLES_MISMA_CUENTAColumnName = "UNIFICAR_DETALLES_MISMA_CUENTA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_AUTOM_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_AUTOM_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTOM_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_AUTOM_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_AUTOM_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_AUTOM_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_AUTOM_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTOM_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTOM_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_AUTOM_INFO_COMPL";
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTOM_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTOM_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_AUTOM_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int entidad_nombreColumnIndex = reader.GetOrdinal("ENTIDAD_NOMBRE");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int pais_nombreColumnIndex = reader.GetOrdinal("PAIS_NOMBRE");
			int transicion_idColumnIndex = reader.GetOrdinal("TRANSICION_ID");
			int transicion_descripcionColumnIndex = reader.GetOrdinal("TRANSICION_DESCRIPCION");
			int transicion_flujo_idColumnIndex = reader.GetOrdinal("TRANSICION_FLUJO_ID");
			int transicion_flujo_descripcionColumnIndex = reader.GetOrdinal("TRANSICION_FLUJO_DESCRIPCION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int revision_posteriorColumnIndex = reader.GetOrdinal("REVISION_POSTERIOR");
			int copiar_observacion_casoColumnIndex = reader.GetOrdinal("COPIAR_OBSERVACION_CASO");
			int mostrar_obs_det_reporteColumnIndex = reader.GetOrdinal("MOSTRAR_OBS_DET_REPORTE");
			int usar_fecha_transicionColumnIndex = reader.GetOrdinal("USAR_FECHA_TRANSICION");
			int estructura_observacionColumnIndex = reader.GetOrdinal("ESTRUCTURA_OBSERVACION");
			int unificar_detalles_misma_cuentaColumnIndex = reader.GetOrdinal("UNIFICAR_DETALLES_MISMA_CUENTA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_AUTOM_INFO_COMPLRow record = new CTB_ASIENTOS_AUTOM_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(entidad_nombreColumnIndex));
					record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					record.PAIS_NOMBRE = Convert.ToString(reader.GetValue(pais_nombreColumnIndex));
					if(!reader.IsDBNull(transicion_idColumnIndex))
						record.TRANSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_idColumnIndex)), 9);
					if(!reader.IsDBNull(transicion_descripcionColumnIndex))
						record.TRANSICION_DESCRIPCION = Convert.ToString(reader.GetValue(transicion_descripcionColumnIndex));
					if(!reader.IsDBNull(transicion_flujo_idColumnIndex))
						record.TRANSICION_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(transicion_flujo_descripcionColumnIndex))
						record.TRANSICION_FLUJO_DESCRIPCION = Convert.ToString(reader.GetValue(transicion_flujo_descripcionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.REVISION_POSTERIOR = Convert.ToString(reader.GetValue(revision_posteriorColumnIndex));
					record.COPIAR_OBSERVACION_CASO = Convert.ToString(reader.GetValue(copiar_observacion_casoColumnIndex));
					record.MOSTRAR_OBS_DET_REPORTE = Convert.ToString(reader.GetValue(mostrar_obs_det_reporteColumnIndex));
					record.USAR_FECHA_TRANSICION = Convert.ToString(reader.GetValue(usar_fecha_transicionColumnIndex));
					record.ESTRUCTURA_OBSERVACION = Convert.ToString(reader.GetValue(estructura_observacionColumnIndex));
					record.UNIFICAR_DETALLES_MISMA_CUENTA = Convert.ToString(reader.GetValue(unificar_detalles_misma_cuentaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_AUTOM_INFO_COMPLRow[])(recordList.ToArray(typeof(CTB_ASIENTOS_AUTOM_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_AUTOM_INFO_COMPLRow"/> object.</returns>
		protected virtual CTB_ASIENTOS_AUTOM_INFO_COMPLRow MapRow(DataRow row)
		{
			CTB_ASIENTOS_AUTOM_INFO_COMPLRow mappedObject = new CTB_ASIENTOS_AUTOM_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "PAIS_NOMBRE"
			dataColumn = dataTable.Columns["PAIS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_NOMBRE = (string)row[dataColumn];
			// Column "TRANSICION_ID"
			dataColumn = dataTable.Columns["TRANSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_ID = (decimal)row[dataColumn];
			// Column "TRANSICION_DESCRIPCION"
			dataColumn = dataTable.Columns["TRANSICION_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_DESCRIPCION = (string)row[dataColumn];
			// Column "TRANSICION_FLUJO_ID"
			dataColumn = dataTable.Columns["TRANSICION_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_FLUJO_ID = (decimal)row[dataColumn];
			// Column "TRANSICION_FLUJO_DESCRIPCION"
			dataColumn = dataTable.Columns["TRANSICION_FLUJO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_FLUJO_DESCRIPCION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "REVISION_POSTERIOR"
			dataColumn = dataTable.Columns["REVISION_POSTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.REVISION_POSTERIOR = (string)row[dataColumn];
			// Column "COPIAR_OBSERVACION_CASO"
			dataColumn = dataTable.Columns["COPIAR_OBSERVACION_CASO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COPIAR_OBSERVACION_CASO = (string)row[dataColumn];
			// Column "MOSTRAR_OBS_DET_REPORTE"
			dataColumn = dataTable.Columns["MOSTRAR_OBS_DET_REPORTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOSTRAR_OBS_DET_REPORTE = (string)row[dataColumn];
			// Column "USAR_FECHA_TRANSICION"
			dataColumn = dataTable.Columns["USAR_FECHA_TRANSICION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_FECHA_TRANSICION = (string)row[dataColumn];
			// Column "ESTRUCTURA_OBSERVACION"
			dataColumn = dataTable.Columns["ESTRUCTURA_OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTRUCTURA_OBSERVACION = (string)row[dataColumn];
			// Column "UNIFICAR_DETALLES_MISMA_CUENTA"
			dataColumn = dataTable.Columns["UNIFICAR_DETALLES_MISMA_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIFICAR_DETALLES_MISMA_CUENTA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_AUTOM_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_AUTOM_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSICION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSICION_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 33;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSICION_FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSICION_FLUJO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REVISION_POSTERIOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COPIAR_OBSERVACION_CASO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOSTRAR_OBS_DET_REPORTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USAR_FECHA_TRANSICION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTRUCTURA_OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UNIFICAR_DETALLES_MISMA_CUENTA", typeof(string));
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSICION_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSICION_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSICION_FLUJO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REVISION_POSTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "COPIAR_OBSERVACION_CASO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MOSTRAR_OBS_DET_REPORTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USAR_FECHA_TRANSICION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTRUCTURA_OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIFICAR_DETALLES_MISMA_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_AUTOM_INFO_COMPLCollection_Base class
}  // End of namespace
