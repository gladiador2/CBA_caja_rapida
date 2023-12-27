// <fileinfo name="ORDENES_SERV_CAS_ASOC_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERV_CAS_ASOC_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ORDEN_SERVICIO_IDColumnName = "ORDEN_SERVICIO_ID";
		public const string ORDEN_SERVICIO_TITULOColumnName = "ORDEN_SERVICIO_TITULO";
		public const string ORDEN_SERVICIO_TIPOColumnName = "ORDEN_SERVICIO_TIPO";
		public const string ORDEN_SERVICIO_CASOColumnName = "ORDEN_SERVICIO_CASO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FLUJO_ASOCIADO_IDColumnName = "FLUJO_ASOCIADO_ID";
		public const string FLUJO_ASOCIADO_DESCColumnName = "FLUJO_ASOCIADO_DESC";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CONSIDERAR_COMO_PAGOColumnName = "CONSIDERAR_COMO_PAGO";
		public const string FECHA_AGREGADOColumnName = "FECHA_AGREGADO";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string EDITABLEColumnName = "EDITABLE";
		public const string CASO_ASOCIADO_ESTADO_IDColumnName = "CASO_ASOCIADO_ESTADO_ID";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_SERV_CAS_ASOC_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_SERV_CAS_ASOC_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects.</returns>
		public virtual ORDENES_SERV_CAS_ASOC_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_SERV_CAS_ASOC_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_SERV_CAS_ASOC_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_SERV_CAS_ASOC_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_SERV_CAS_ASOC_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects.</returns>
		public ORDENES_SERV_CAS_ASOC_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects.</returns>
		public virtual ORDENES_SERV_CAS_ASOC_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_SERV_CAS_ASOC_INF_COMP";
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
		/// <returns>An array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects.</returns>
		protected ORDENES_SERV_CAS_ASOC_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects.</returns>
		protected ORDENES_SERV_CAS_ASOC_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> objects.</returns>
		protected virtual ORDENES_SERV_CAS_ASOC_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int orden_servicio_idColumnIndex = reader.GetOrdinal("ORDEN_SERVICIO_ID");
			int orden_servicio_tituloColumnIndex = reader.GetOrdinal("ORDEN_SERVICIO_TITULO");
			int orden_servicio_tipoColumnIndex = reader.GetOrdinal("ORDEN_SERVICIO_TIPO");
			int orden_servicio_casoColumnIndex = reader.GetOrdinal("ORDEN_SERVICIO_CASO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int flujo_asociado_idColumnIndex = reader.GetOrdinal("FLUJO_ASOCIADO_ID");
			int flujo_asociado_descColumnIndex = reader.GetOrdinal("FLUJO_ASOCIADO_DESC");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int considerar_como_pagoColumnIndex = reader.GetOrdinal("CONSIDERAR_COMO_PAGO");
			int fecha_agregadoColumnIndex = reader.GetOrdinal("FECHA_AGREGADO");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int editableColumnIndex = reader.GetOrdinal("EDITABLE");
			int caso_asociado_estado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ESTADO_ID");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_SERV_CAS_ASOC_INF_COMPRow record = new ORDENES_SERV_CAS_ASOC_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ORDEN_SERVICIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_servicio_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_servicio_tituloColumnIndex))
						record.ORDEN_SERVICIO_TITULO = Convert.ToString(reader.GetValue(orden_servicio_tituloColumnIndex));
					record.ORDEN_SERVICIO_TIPO = Convert.ToString(reader.GetValue(orden_servicio_tipoColumnIndex));
					record.ORDEN_SERVICIO_CASO = Math.Round(Convert.ToDecimal(reader.GetValue(orden_servicio_casoColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.FLUJO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_asociado_descColumnIndex))
						record.FLUJO_ASOCIADO_DESC = Convert.ToString(reader.GetValue(flujo_asociado_descColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(considerar_como_pagoColumnIndex))
						record.CONSIDERAR_COMO_PAGO = Convert.ToString(reader.GetValue(considerar_como_pagoColumnIndex));
					record.FECHA_AGREGADO = Convert.ToDateTime(reader.GetValue(fecha_agregadoColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.EDITABLE = Convert.ToString(reader.GetValue(editableColumnIndex));
					record.CASO_ASOCIADO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_asociado_estado_idColumnIndex));
					if(!reader.IsDBNull(usuario_nombreColumnIndex))
						record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_SERV_CAS_ASOC_INF_COMPRow[])(recordList.ToArray(typeof(ORDENES_SERV_CAS_ASOC_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_SERV_CAS_ASOC_INF_COMPRow"/> object.</returns>
		protected virtual ORDENES_SERV_CAS_ASOC_INF_COMPRow MapRow(DataRow row)
		{
			ORDENES_SERV_CAS_ASOC_INF_COMPRow mappedObject = new ORDENES_SERV_CAS_ASOC_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ORDEN_SERVICIO_ID"
			dataColumn = dataTable.Columns["ORDEN_SERVICIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_SERVICIO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_SERVICIO_TITULO"
			dataColumn = dataTable.Columns["ORDEN_SERVICIO_TITULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_SERVICIO_TITULO = (string)row[dataColumn];
			// Column "ORDEN_SERVICIO_TIPO"
			dataColumn = dataTable.Columns["ORDEN_SERVICIO_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_SERVICIO_TIPO = (string)row[dataColumn];
			// Column "ORDEN_SERVICIO_CASO"
			dataColumn = dataTable.Columns["ORDEN_SERVICIO_CASO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_SERVICIO_CASO = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["FLUJO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ASOCIADO_DESC"
			dataColumn = dataTable.Columns["FLUJO_ASOCIADO_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ASOCIADO_DESC = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CONSIDERAR_COMO_PAGO"
			dataColumn = dataTable.Columns["CONSIDERAR_COMO_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIDERAR_COMO_PAGO = (string)row[dataColumn];
			// Column "FECHA_AGREGADO"
			dataColumn = dataTable.Columns["FECHA_AGREGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_AGREGADO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "EDITABLE"
			dataColumn = dataTable.Columns["EDITABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDITABLE = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ESTADO_ID = (string)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_SERV_CAS_ASOC_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_SERV_CAS_ASOC_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_SERVICIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_SERVICIO_TITULO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_SERVICIO_TIPO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_SERVICIO_CASO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ASOCIADO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ASOCIADO_DESC", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIDERAR_COMO_PAGO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_AGREGADO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EDITABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
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

				case "ORDEN_SERVICIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_SERVICIO_TITULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN_SERVICIO_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN_SERVICIO_CASO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ASOCIADO_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSIDERAR_COMO_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_AGREGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EDITABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ASOCIADO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_SERV_CAS_ASOC_INF_COMPCollection_Base class
}  // End of namespace
