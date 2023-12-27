// <fileinfo name="CTACTE_CHQ_MOV_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHQ_MOV_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CHQ_MOV_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHQ_MOV_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string CTACTE_CHEQUE_GIRADO_IDColumnName = "CTACTE_CHEQUE_GIRADO_ID";
		public const string ESTADO_ORIGINAL_IDColumnName = "ESTADO_ORIGINAL_ID";
		public const string ESTADO_ORIGEN_NOMBREColumnName = "ESTADO_ORIGEN_NOMBRE";
		public const string ESTADO_ORIGEN_ALIASColumnName = "ESTADO_ORIGEN_ALIAS";
		public const string ESTADO_DESTINO_IDColumnName = "ESTADO_DESTINO_ID";
		public const string ESTADO_DESTINO_NOMBREColumnName = "ESTADO_DESTINO_NOMBRE";
		public const string ESTADO_DESTINO_ALIASColumnName = "ESTADO_DESTINO_ALIAS";
		public const string FECHA_MOVIMIENTOColumnName = "FECHA_MOVIMIENTO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";
		public const string CHEQUE_RECIBIDO_PERSONAColumnName = "CHEQUE_RECIBIDO_PERSONA";
		public const string CHEQUE_RECIBIDO_PROVEEDORColumnName = "CHEQUE_RECIBIDO_PROVEEDOR";
		public const string CHEQUE_GIRADO_PERSONAColumnName = "CHEQUE_GIRADO_PERSONA";
		public const string CHEQUE_GIRADO_PROVEEDORColumnName = "CHEQUE_GIRADO_PROVEEDOR";
		public const string CHEQUE_RECIBIDO_ENTIDADColumnName = "CHEQUE_RECIBIDO_ENTIDAD";
		public const string CHEQUE_GIRADO_ENTIDADColumnName = "CHEQUE_GIRADO_ENTIDAD";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHQ_MOV_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CHQ_MOV_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CHQ_MOV_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects.</returns>
		public virtual CTACTE_CHQ_MOV_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CHQ_MOV_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CHQ_MOV_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CHQ_MOV_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CHQ_MOV_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects.</returns>
		public CTACTE_CHQ_MOV_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects.</returns>
		public virtual CTACTE_CHQ_MOV_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CHQ_MOV_INFO_COMPL";
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
		/// <returns>An array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects.</returns>
		protected CTACTE_CHQ_MOV_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects.</returns>
		protected CTACTE_CHQ_MOV_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> objects.</returns>
		protected virtual CTACTE_CHQ_MOV_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int ctacte_cheque_girado_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_GIRADO_ID");
			int estado_original_idColumnIndex = reader.GetOrdinal("ESTADO_ORIGINAL_ID");
			int estado_origen_nombreColumnIndex = reader.GetOrdinal("ESTADO_ORIGEN_NOMBRE");
			int estado_origen_aliasColumnIndex = reader.GetOrdinal("ESTADO_ORIGEN_ALIAS");
			int estado_destino_idColumnIndex = reader.GetOrdinal("ESTADO_DESTINO_ID");
			int estado_destino_nombreColumnIndex = reader.GetOrdinal("ESTADO_DESTINO_NOMBRE");
			int estado_destino_aliasColumnIndex = reader.GetOrdinal("ESTADO_DESTINO_ALIAS");
			int fecha_movimientoColumnIndex = reader.GetOrdinal("FECHA_MOVIMIENTO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");
			int cheque_recibido_personaColumnIndex = reader.GetOrdinal("CHEQUE_RECIBIDO_PERSONA");
			int cheque_recibido_proveedorColumnIndex = reader.GetOrdinal("CHEQUE_RECIBIDO_PROVEEDOR");
			int cheque_girado_personaColumnIndex = reader.GetOrdinal("CHEQUE_GIRADO_PERSONA");
			int cheque_girado_proveedorColumnIndex = reader.GetOrdinal("CHEQUE_GIRADO_PROVEEDOR");
			int cheque_recibido_entidadColumnIndex = reader.GetOrdinal("CHEQUE_RECIBIDO_ENTIDAD");
			int cheque_girado_entidadColumnIndex = reader.GetOrdinal("CHEQUE_GIRADO_ENTIDAD");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CHQ_MOV_INFO_COMPLRow record = new CTACTE_CHQ_MOV_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_girado_idColumnIndex))
						record.CTACTE_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_original_idColumnIndex))
						record.ESTADO_ORIGINAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_original_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_origen_nombreColumnIndex))
						record.ESTADO_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(estado_origen_nombreColumnIndex));
					if(!reader.IsDBNull(estado_origen_aliasColumnIndex))
						record.ESTADO_ORIGEN_ALIAS = Convert.ToString(reader.GetValue(estado_origen_aliasColumnIndex));
					if(!reader.IsDBNull(estado_destino_idColumnIndex))
						record.ESTADO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_destino_nombreColumnIndex))
						record.ESTADO_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(estado_destino_nombreColumnIndex));
					if(!reader.IsDBNull(estado_destino_aliasColumnIndex))
						record.ESTADO_DESTINO_ALIAS = Convert.ToString(reader.GetValue(estado_destino_aliasColumnIndex));
					if(!reader.IsDBNull(fecha_movimientoColumnIndex))
						record.FECHA_MOVIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_movimientoColumnIndex));
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));
					if(!reader.IsDBNull(cheque_recibido_personaColumnIndex))
						record.CHEQUE_RECIBIDO_PERSONA = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_recibido_personaColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_recibido_proveedorColumnIndex))
						record.CHEQUE_RECIBIDO_PROVEEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_recibido_proveedorColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_girado_personaColumnIndex))
						record.CHEQUE_GIRADO_PERSONA = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_girado_personaColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_girado_proveedorColumnIndex))
						record.CHEQUE_GIRADO_PROVEEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_girado_proveedorColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_recibido_entidadColumnIndex))
						record.CHEQUE_RECIBIDO_ENTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_recibido_entidadColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_girado_entidadColumnIndex))
						record.CHEQUE_GIRADO_ENTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_girado_entidadColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CHQ_MOV_INFO_COMPLRow[])(recordList.ToArray(typeof(CTACTE_CHQ_MOV_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CHQ_MOV_INFO_COMPLRow"/> object.</returns>
		protected virtual CTACTE_CHQ_MOV_INFO_COMPLRow MapRow(DataRow row)
		{
			CTACTE_CHQ_MOV_INFO_COMPLRow mappedObject = new CTACTE_CHQ_MOV_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_ORIGINAL_ID"
			dataColumn = dataTable.Columns["ESTADO_ORIGINAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ORIGINAL_ID = (decimal)row[dataColumn];
			// Column "ESTADO_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["ESTADO_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "ESTADO_ORIGEN_ALIAS"
			dataColumn = dataTable.Columns["ESTADO_ORIGEN_ALIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ORIGEN_ALIAS = (string)row[dataColumn];
			// Column "ESTADO_DESTINO_ID"
			dataColumn = dataTable.Columns["ESTADO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["ESTADO_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DESTINO_NOMBRE = (string)row[dataColumn];
			// Column "ESTADO_DESTINO_ALIAS"
			dataColumn = dataTable.Columns["ESTADO_DESTINO_ALIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DESTINO_ALIAS = (string)row[dataColumn];
			// Column "FECHA_MOVIMIENTO"
			dataColumn = dataTable.Columns["FECHA_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MOVIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "CHEQUE_RECIBIDO_PERSONA"
			dataColumn = dataTable.Columns["CHEQUE_RECIBIDO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_RECIBIDO_PERSONA = (decimal)row[dataColumn];
			// Column "CHEQUE_RECIBIDO_PROVEEDOR"
			dataColumn = dataTable.Columns["CHEQUE_RECIBIDO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_RECIBIDO_PROVEEDOR = (decimal)row[dataColumn];
			// Column "CHEQUE_GIRADO_PERSONA"
			dataColumn = dataTable.Columns["CHEQUE_GIRADO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_GIRADO_PERSONA = (decimal)row[dataColumn];
			// Column "CHEQUE_GIRADO_PROVEEDOR"
			dataColumn = dataTable.Columns["CHEQUE_GIRADO_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_GIRADO_PROVEEDOR = (decimal)row[dataColumn];
			// Column "CHEQUE_RECIBIDO_ENTIDAD"
			dataColumn = dataTable.Columns["CHEQUE_RECIBIDO_ENTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_RECIBIDO_ENTIDAD = (decimal)row[dataColumn];
			// Column "CHEQUE_GIRADO_ENTIDAD"
			dataColumn = dataTable.Columns["CHEQUE_GIRADO_ENTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_GIRADO_ENTIDAD = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CHQ_MOV_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CHQ_MOV_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_ORIGINAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_ORIGEN_ALIAS", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DESTINO_ALIAS", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MOVIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_RECIBIDO_PERSONA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_RECIBIDO_PROVEEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_GIRADO_PERSONA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_GIRADO_PROVEEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_RECIBIDO_ENTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_GIRADO_ENTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
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

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_ORIGINAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_ORIGEN_ALIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_DESTINO_ALIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_RECIBIDO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_RECIBIDO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_GIRADO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_GIRADO_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_RECIBIDO_ENTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_GIRADO_ENTIDAD":
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
	} // End of CTACTE_CHQ_MOV_INFO_COMPLCollection_Base class
}  // End of namespace
