// <fileinfo name="DESCUENTOS_LLEGADAS_TAR_DETCollection_Base.cs">
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
	/// The base class for <see cref="DESCUENTOS_LLEGADAS_TAR_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESCUENTOS_LLEGADAS_TAR_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTOS_LLEGADAS_TAR_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string DESCUENTO_LLEGADA_TARDIA_IDColumnName = "DESCUENTO_LLEGADA_TARDIA_ID";
		public const string MONTO_DESCUENTOColumnName = "MONTO_DESCUENTO";
		public const string HORAS_PENALIZADASColumnName = "HORAS_PENALIZADAS";
		public const string PUNTO_INICIOColumnName = "PUNTO_INICIO";
		public const string PUNTO_FINColumnName = "PUNTO_FIN";
		public const string TIEMPO_INICIOColumnName = "TIEMPO_INICIO";
		public const string TIEMPO_FINColumnName = "TIEMPO_FIN";
		public const string MENSAJEColumnName = "MENSAJE";
		public const string ESTADOColumnName = "ESTADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTOS_LLEGADAS_TAR_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESCUENTOS_LLEGADAS_TAR_DETCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this table belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects.</returns>
		public virtual DESCUENTOS_LLEGADAS_TAR_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESCUENTOS_LLEGADAS_TAR_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESCUENTOS_LLEGADAS_TAR_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects.</returns>
		public DESCUENTOS_LLEGADAS_TAR_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects.</returns>
		public virtual DESCUENTOS_LLEGADAS_TAR_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESCUENTOS_LLEGADAS_TAR_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DESCUENTOS_LLEGADAS_TAR_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DESCUENTOS_LLEGADAS_TAR_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects 
		/// by the <c>FK_DESCUENTO_LLEGADA_TARDIA</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects.</returns>
		public virtual DESCUENTOS_LLEGADAS_TAR_DETRow[] GetByDESCUENTO_LLEGADA_TARDIA_ID(decimal descuento_llegada_tardia_id)
		{
			return MapRecords(CreateGetByDESCUENTO_LLEGADA_TARDIA_IDCommand(descuento_llegada_tardia_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_LLEGADA_TARDIA</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_LLEGADA_TARDIA_IDAsDataTable(decimal descuento_llegada_tardia_id)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_LLEGADA_TARDIA_IDCommand(descuento_llegada_tardia_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_LLEGADA_TARDIA</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_LLEGADA_TARDIA_IDCommand(decimal descuento_llegada_tardia_id)
		{
			string whereSql = "";
			whereSql += "DESCUENTO_LLEGADA_TARDIA_ID=" + _db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID", descuento_llegada_tardia_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> object to be inserted.</param>
		public virtual void Insert(DESCUENTOS_LLEGADAS_TAR_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DESCUENTOS_LLEGADAS_TAR_DET (" +
				"ID, " +
				"DESCUENTO_LLEGADA_TARDIA_ID, " +
				"MONTO_DESCUENTO, " +
				"HORAS_PENALIZADAS, " +
				"PUNTO_INICIO, " +
				"PUNTO_FIN, " +
				"TIEMPO_INICIO, " +
				"TIEMPO_FIN, " +
				"MENSAJE, " +
				"ESTADO, " +
				"OBSERVACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("HORAS_PENALIZADAS") + ", " +
				_db.CreateSqlParameterName("PUNTO_INICIO") + ", " +
				_db.CreateSqlParameterName("PUNTO_FIN") + ", " +
				_db.CreateSqlParameterName("TIEMPO_INICIO") + ", " +
				_db.CreateSqlParameterName("TIEMPO_FIN") + ", " +
				_db.CreateSqlParameterName("MENSAJE") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID", value.DESCUENTO_LLEGADA_TARDIA_ID);
			AddParameter(cmd, "MONTO_DESCUENTO",
				value.IsMONTO_DESCUENTONull ? DBNull.Value : (object)value.MONTO_DESCUENTO);
			AddParameter(cmd, "HORAS_PENALIZADAS",
				value.IsHORAS_PENALIZADASNull ? DBNull.Value : (object)value.HORAS_PENALIZADAS);
			AddParameter(cmd, "PUNTO_INICIO",
				value.IsPUNTO_INICIONull ? DBNull.Value : (object)value.PUNTO_INICIO);
			AddParameter(cmd, "PUNTO_FIN",
				value.IsPUNTO_FINNull ? DBNull.Value : (object)value.PUNTO_FIN);
			AddParameter(cmd, "TIEMPO_INICIO",
				value.IsTIEMPO_INICIONull ? DBNull.Value : (object)value.TIEMPO_INICIO);
			AddParameter(cmd, "TIEMPO_FIN",
				value.IsTIEMPO_FINNull ? DBNull.Value : (object)value.TIEMPO_FIN);
			AddParameter(cmd, "MENSAJE", value.MENSAJE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DESCUENTOS_LLEGADAS_TAR_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.DESCUENTOS_LLEGADAS_TAR_DET SET " +
				"DESCUENTO_LLEGADA_TARDIA_ID=" + _db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID") + ", " +
				"MONTO_DESCUENTO=" + _db.CreateSqlParameterName("MONTO_DESCUENTO") + ", " +
				"HORAS_PENALIZADAS=" + _db.CreateSqlParameterName("HORAS_PENALIZADAS") + ", " +
				"PUNTO_INICIO=" + _db.CreateSqlParameterName("PUNTO_INICIO") + ", " +
				"PUNTO_FIN=" + _db.CreateSqlParameterName("PUNTO_FIN") + ", " +
				"TIEMPO_INICIO=" + _db.CreateSqlParameterName("TIEMPO_INICIO") + ", " +
				"TIEMPO_FIN=" + _db.CreateSqlParameterName("TIEMPO_FIN") + ", " +
				"MENSAJE=" + _db.CreateSqlParameterName("MENSAJE") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID", value.DESCUENTO_LLEGADA_TARDIA_ID);
			AddParameter(cmd, "MONTO_DESCUENTO",
				value.IsMONTO_DESCUENTONull ? DBNull.Value : (object)value.MONTO_DESCUENTO);
			AddParameter(cmd, "HORAS_PENALIZADAS",
				value.IsHORAS_PENALIZADASNull ? DBNull.Value : (object)value.HORAS_PENALIZADAS);
			AddParameter(cmd, "PUNTO_INICIO",
				value.IsPUNTO_INICIONull ? DBNull.Value : (object)value.PUNTO_INICIO);
			AddParameter(cmd, "PUNTO_FIN",
				value.IsPUNTO_FINNull ? DBNull.Value : (object)value.PUNTO_FIN);
			AddParameter(cmd, "TIEMPO_INICIO",
				value.IsTIEMPO_INICIONull ? DBNull.Value : (object)value.TIEMPO_INICIO);
			AddParameter(cmd, "TIEMPO_FIN",
				value.IsTIEMPO_FINNull ? DBNull.Value : (object)value.TIEMPO_FIN);
			AddParameter(cmd, "MENSAJE", value.MENSAJE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
		/// argument when your code calls this method in an ADO.NET transaction context. Note that in 
		/// this case, after you call the Update method you need call either <c>AcceptChanges</c> 
		/// or <c>RejectChanges</c> method on the DataTable object.
		/// <code>
		/// MyDb db = new MyDb();
		/// try
		/// {
		///		db.BeginTransaction();
		///		db.MyCollection.Update(myDataTable, false);
		///		db.CommitTransaction();
		///		myDataTable.AcceptChanges();
		/// }
		/// catch(Exception)
		/// {
		///		db.RollbackTransaction();
		///		myDataTable.RejectChanges();
		/// }
		/// </code>
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		/// <param name="acceptChanges">Specifies whether this method calls the <c>AcceptChanges</c>
		/// method on the changed DataRow objects.</param>
		public virtual void Update(DataTable table, bool acceptChanges)
		{
			DataRowCollection rows = table.Rows;
			for(int i = rows.Count - 1; i >= 0; i--)
			{
				DataRow row = rows[i];
				switch(row.RowState)
				{
					case DataRowState.Added:
						Insert(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;

					case DataRowState.Deleted:
						// Temporary reject changes to be able to access to the PK column(s)
						row.RejectChanges();
						try
						{
							DeleteByPrimaryKey((decimal)row["ID"]);
						}
						finally
						{
							row.Delete();
						}
						if(acceptChanges)
							row.AcceptChanges();
						break;
						
					case DataRowState.Modified:
						Update(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;
				}
			}
		}

		/// <summary>
		/// Deletes the specified object from the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DESCUENTOS_LLEGADAS_TAR_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ID", id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table using the 
		/// <c>FK_DESCUENTO_LLEGADA_TARDIA</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_LLEGADA_TARDIA_ID(decimal descuento_llegada_tardia_id)
		{
			return CreateDeleteByDESCUENTO_LLEGADA_TARDIA_IDCommand(descuento_llegada_tardia_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_LLEGADA_TARDIA</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_LLEGADA_TARDIA_IDCommand(decimal descuento_llegada_tardia_id)
		{
			string whereSql = "";
			whereSql += "DESCUENTO_LLEGADA_TARDIA_ID=" + _db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID", descuento_llegada_tardia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DESCUENTOS_LLEGADAS_TAR_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>The number of deleted records.</returns>
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used 
		/// to delete <c>DESCUENTOS_LLEGADAS_TAR_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DESCUENTOS_LLEGADAS_TAR_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <returns>The number of deleted records.</returns>
		public int DeleteAll()
		{
			return Delete("");
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects.</returns>
		protected DESCUENTOS_LLEGADAS_TAR_DETRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects.</returns>
		protected DESCUENTOS_LLEGADAS_TAR_DETRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> objects.</returns>
		protected virtual DESCUENTOS_LLEGADAS_TAR_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int descuento_llegada_tardia_idColumnIndex = reader.GetOrdinal("DESCUENTO_LLEGADA_TARDIA_ID");
			int monto_descuentoColumnIndex = reader.GetOrdinal("MONTO_DESCUENTO");
			int horas_penalizadasColumnIndex = reader.GetOrdinal("HORAS_PENALIZADAS");
			int punto_inicioColumnIndex = reader.GetOrdinal("PUNTO_INICIO");
			int punto_finColumnIndex = reader.GetOrdinal("PUNTO_FIN");
			int tiempo_inicioColumnIndex = reader.GetOrdinal("TIEMPO_INICIO");
			int tiempo_finColumnIndex = reader.GetOrdinal("TIEMPO_FIN");
			int mensajeColumnIndex = reader.GetOrdinal("MENSAJE");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESCUENTOS_LLEGADAS_TAR_DETRow record = new DESCUENTOS_LLEGADAS_TAR_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.DESCUENTO_LLEGADA_TARDIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_llegada_tardia_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_descuentoColumnIndex))
						record.MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(horas_penalizadasColumnIndex))
						record.HORAS_PENALIZADAS = Convert.ToDateTime(reader.GetValue(horas_penalizadasColumnIndex));
					if(!reader.IsDBNull(punto_inicioColumnIndex))
						record.PUNTO_INICIO = Math.Round(Convert.ToDecimal(reader.GetValue(punto_inicioColumnIndex)), 9);
					if(!reader.IsDBNull(punto_finColumnIndex))
						record.PUNTO_FIN = Math.Round(Convert.ToDecimal(reader.GetValue(punto_finColumnIndex)), 9);
					if(!reader.IsDBNull(tiempo_inicioColumnIndex))
						record.TIEMPO_INICIO = Convert.ToDateTime(reader.GetValue(tiempo_inicioColumnIndex));
					if(!reader.IsDBNull(tiempo_finColumnIndex))
						record.TIEMPO_FIN = Convert.ToDateTime(reader.GetValue(tiempo_finColumnIndex));
					if(!reader.IsDBNull(mensajeColumnIndex))
						record.MENSAJE = Convert.ToString(reader.GetValue(mensajeColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESCUENTOS_LLEGADAS_TAR_DETRow[])(recordList.ToArray(typeof(DESCUENTOS_LLEGADAS_TAR_DETRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESCUENTOS_LLEGADAS_TAR_DETRow"/> object.</returns>
		protected virtual DESCUENTOS_LLEGADAS_TAR_DETRow MapRow(DataRow row)
		{
			DESCUENTOS_LLEGADAS_TAR_DETRow mappedObject = new DESCUENTOS_LLEGADAS_TAR_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_LLEGADA_TARDIA_ID"
			dataColumn = dataTable.Columns["DESCUENTO_LLEGADA_TARDIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_LLEGADA_TARDIA_ID = (decimal)row[dataColumn];
			// Column "MONTO_DESCUENTO"
			dataColumn = dataTable.Columns["MONTO_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESCUENTO = (decimal)row[dataColumn];
			// Column "HORAS_PENALIZADAS"
			dataColumn = dataTable.Columns["HORAS_PENALIZADAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORAS_PENALIZADAS = (System.DateTime)row[dataColumn];
			// Column "PUNTO_INICIO"
			dataColumn = dataTable.Columns["PUNTO_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUNTO_INICIO = (decimal)row[dataColumn];
			// Column "PUNTO_FIN"
			dataColumn = dataTable.Columns["PUNTO_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUNTO_FIN = (decimal)row[dataColumn];
			// Column "TIEMPO_INICIO"
			dataColumn = dataTable.Columns["TIEMPO_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIEMPO_INICIO = (System.DateTime)row[dataColumn];
			// Column "TIEMPO_FIN"
			dataColumn = dataTable.Columns["TIEMPO_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIEMPO_FIN = (System.DateTime)row[dataColumn];
			// Column "MENSAJE"
			dataColumn = dataTable.Columns["MENSAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MENSAJE = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESCUENTOS_LLEGADAS_TAR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESCUENTOS_LLEGADAS_TAR_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCUENTO_LLEGADA_TARDIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESCUENTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("HORAS_PENALIZADAS", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PUNTO_INICIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PUNTO_FIN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIEMPO_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TIEMPO_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MENSAJE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 80;
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

				case "DESCUENTO_LLEGADA_TARDIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HORAS_PENALIZADAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PUNTO_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUNTO_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIEMPO_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TIEMPO_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MENSAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESCUENTOS_LLEGADAS_TAR_DETCollection_Base class
}  // End of namespace
