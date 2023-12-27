// <fileinfo name="CTB_ASIENTOS_AUTO_DET_INFO_COMCollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTO_DET_INFO_COMCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_ASIENTO_AUTOMATICO_IDColumnName = "CTB_ASIENTO_AUTOMATICO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string ORDENColumnName = "ORDEN";
		public const string COLUMNA_PRIORITARIAColumnName = "COLUMNA_PRIORITARIA";
		public const string COLUMNA_PRIORITARIA2ColumnName = "COLUMNA_PRIORITARIA2";
		public const string CENTRO_COSTO_PRIORIDADColumnName = "CENTRO_COSTO_PRIORIDAD";
		public const string CENTRO_COSTO_PRIORIDAD2ColumnName = "CENTRO_COSTO_PRIORIDAD2";
		public const string CENTRO_COSTO_PRIORIDAD3ColumnName = "CENTRO_COSTO_PRIORIDAD3";
		public const string RESUMIR_DETALLESColumnName = "RESUMIR_DETALLES";
		public const string CANTIDAD_CUENTAS_RELACIONADASColumnName = "CANTIDAD_CUENTAS_RELACIONADAS";
		public const string REVISION_POSTERIORColumnName = "REVISION_POSTERIOR";
		public const string TRANSICION_IDColumnName = "TRANSICION_ID";
		public const string USAR_FECHA_TRANSICIONColumnName = "USAR_FECHA_TRANSICION";
		public const string COPIAR_OBS_CABECERA_ASIENTOColumnName = "COPIAR_OBS_CABECERA_ASIENTO";
		public const string ESTRUCTURA_OBSERVACIONColumnName = "ESTRUCTURA_OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_AUTO_DET_INFO_COMCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_AUTO_DET_INFO_COM</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_DET_INFO_COMRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_AUTO_DET_INFO_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_AUTO_DET_INFO_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_AUTO_DET_INFO_COMRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_AUTO_DET_INFO_COMRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_DET_INFO_COMRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_DET_INFO_COMRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_AUTO_DET_INFO_COM";
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_DET_INFO_COMRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_DET_INFO_COMRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_AUTO_DET_INFO_COMRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_asiento_automatico_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_AUTOMATICO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int columna_prioritariaColumnIndex = reader.GetOrdinal("COLUMNA_PRIORITARIA");
			int columna_prioritaria2ColumnIndex = reader.GetOrdinal("COLUMNA_PRIORITARIA2");
			int centro_costo_prioridadColumnIndex = reader.GetOrdinal("CENTRO_COSTO_PRIORIDAD");
			int centro_costo_prioridad2ColumnIndex = reader.GetOrdinal("CENTRO_COSTO_PRIORIDAD2");
			int centro_costo_prioridad3ColumnIndex = reader.GetOrdinal("CENTRO_COSTO_PRIORIDAD3");
			int resumir_detallesColumnIndex = reader.GetOrdinal("RESUMIR_DETALLES");
			int cantidad_cuentas_relacionadasColumnIndex = reader.GetOrdinal("CANTIDAD_CUENTAS_RELACIONADAS");
			int revision_posteriorColumnIndex = reader.GetOrdinal("REVISION_POSTERIOR");
			int transicion_idColumnIndex = reader.GetOrdinal("TRANSICION_ID");
			int usar_fecha_transicionColumnIndex = reader.GetOrdinal("USAR_FECHA_TRANSICION");
			int copiar_obs_cabecera_asientoColumnIndex = reader.GetOrdinal("COPIAR_OBS_CABECERA_ASIENTO");
			int estructura_observacionColumnIndex = reader.GetOrdinal("ESTRUCTURA_OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_AUTO_DET_INFO_COMRow record = new CTB_ASIENTOS_AUTO_DET_INFO_COMRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_ASIENTO_AUTOMATICO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_automatico_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(columna_prioritariaColumnIndex))
						record.COLUMNA_PRIORITARIA = Math.Round(Convert.ToDecimal(reader.GetValue(columna_prioritariaColumnIndex)), 9);
					if(!reader.IsDBNull(columna_prioritaria2ColumnIndex))
						record.COLUMNA_PRIORITARIA2 = Math.Round(Convert.ToDecimal(reader.GetValue(columna_prioritaria2ColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_prioridadColumnIndex))
						record.CENTRO_COSTO_PRIORIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_prioridadColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_prioridad2ColumnIndex))
						record.CENTRO_COSTO_PRIORIDAD2 = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_prioridad2ColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_prioridad3ColumnIndex))
						record.CENTRO_COSTO_PRIORIDAD3 = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_prioridad3ColumnIndex)), 9);
					record.RESUMIR_DETALLES = Convert.ToString(reader.GetValue(resumir_detallesColumnIndex));
					if(!reader.IsDBNull(cantidad_cuentas_relacionadasColumnIndex))
						record.CANTIDAD_CUENTAS_RELACIONADAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cuentas_relacionadasColumnIndex)), 9);
					record.REVISION_POSTERIOR = Convert.ToString(reader.GetValue(revision_posteriorColumnIndex));
					if(!reader.IsDBNull(transicion_idColumnIndex))
						record.TRANSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_idColumnIndex)), 9);
					record.USAR_FECHA_TRANSICION = Convert.ToString(reader.GetValue(usar_fecha_transicionColumnIndex));
					record.COPIAR_OBS_CABECERA_ASIENTO = Convert.ToString(reader.GetValue(copiar_obs_cabecera_asientoColumnIndex));
					record.ESTRUCTURA_OBSERVACION = Convert.ToString(reader.GetValue(estructura_observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_AUTO_DET_INFO_COMRow[])(recordList.ToArray(typeof(CTB_ASIENTOS_AUTO_DET_INFO_COMRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_AUTO_DET_INFO_COMRow"/> object.</returns>
		protected virtual CTB_ASIENTOS_AUTO_DET_INFO_COMRow MapRow(DataRow row)
		{
			CTB_ASIENTOS_AUTO_DET_INFO_COMRow mappedObject = new CTB_ASIENTOS_AUTO_DET_INFO_COMRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_ASIENTO_AUTOMATICO_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_AUTOMATICO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_AUTOMATICO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "COLUMNA_PRIORITARIA"
			dataColumn = dataTable.Columns["COLUMNA_PRIORITARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLUMNA_PRIORITARIA = (decimal)row[dataColumn];
			// Column "COLUMNA_PRIORITARIA2"
			dataColumn = dataTable.Columns["COLUMNA_PRIORITARIA2"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLUMNA_PRIORITARIA2 = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_PRIORIDAD"
			dataColumn = dataTable.Columns["CENTRO_COSTO_PRIORIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_PRIORIDAD = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_PRIORIDAD2"
			dataColumn = dataTable.Columns["CENTRO_COSTO_PRIORIDAD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_PRIORIDAD2 = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_PRIORIDAD3"
			dataColumn = dataTable.Columns["CENTRO_COSTO_PRIORIDAD3"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_PRIORIDAD3 = (decimal)row[dataColumn];
			// Column "RESUMIR_DETALLES"
			dataColumn = dataTable.Columns["RESUMIR_DETALLES"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESUMIR_DETALLES = (string)row[dataColumn];
			// Column "CANTIDAD_CUENTAS_RELACIONADAS"
			dataColumn = dataTable.Columns["CANTIDAD_CUENTAS_RELACIONADAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CUENTAS_RELACIONADAS = (decimal)row[dataColumn];
			// Column "REVISION_POSTERIOR"
			dataColumn = dataTable.Columns["REVISION_POSTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.REVISION_POSTERIOR = (string)row[dataColumn];
			// Column "TRANSICION_ID"
			dataColumn = dataTable.Columns["TRANSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_ID = (decimal)row[dataColumn];
			// Column "USAR_FECHA_TRANSICION"
			dataColumn = dataTable.Columns["USAR_FECHA_TRANSICION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_FECHA_TRANSICION = (string)row[dataColumn];
			// Column "COPIAR_OBS_CABECERA_ASIENTO"
			dataColumn = dataTable.Columns["COPIAR_OBS_CABECERA_ASIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COPIAR_OBS_CABECERA_ASIENTO = (string)row[dataColumn];
			// Column "ESTRUCTURA_OBSERVACION"
			dataColumn = dataTable.Columns["ESTRUCTURA_OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTRUCTURA_OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_AUTO_DET_INFO_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_AUTO_DET_INFO_COM";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_AUTOMATICO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COLUMNA_PRIORITARIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COLUMNA_PRIORITARIA2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_PRIORIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_PRIORIDAD2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_PRIORIDAD3", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESUMIR_DETALLES", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CUENTAS_RELACIONADAS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REVISION_POSTERIOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSICION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USAR_FECHA_TRANSICION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COPIAR_OBS_CABECERA_ASIENTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTRUCTURA_OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
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

				case "CTB_ASIENTO_AUTOMATICO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COLUMNA_PRIORITARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COLUMNA_PRIORITARIA2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_PRIORIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_PRIORIDAD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_PRIORIDAD3":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESUMIR_DETALLES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CANTIDAD_CUENTAS_RELACIONADAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REVISION_POSTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TRANSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USAR_FECHA_TRANSICION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "COPIAR_OBS_CABECERA_ASIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTRUCTURA_OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_AUTO_DET_INFO_COMCollection_Base class
}  // End of namespace
