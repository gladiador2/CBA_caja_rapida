// <fileinfo name="TRANSICIONES_ACELERADORCollection_Base.cs">
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
	/// The base class for <see cref="TRANSICIONES_ACELERADORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSICIONES_ACELERADORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSICIONES_ACELERADORCollection_Base
	{
		// Constants
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string TRANSICION_OCURRIDA_IDColumnName = "TRANSICION_OCURRIDA_ID";
		public const string TRANSICION_SIGUIENTE_IDColumnName = "TRANSICION_SIGUIENTE_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string ROL_IDColumnName = "ROL_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSICIONES_ACELERADORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSICIONES_ACELERADORCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSICIONES_ACELERADOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public virtual TRANSICIONES_ACELERADORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSICIONES_ACELERADOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSICIONES_ACELERADOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSICIONES_ACELERADORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSICIONES_ACELERADORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSICIONES_ACELERADORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSICIONES_ACELERADORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSICIONES_ACELERADORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public TRANSICIONES_ACELERADORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSICIONES_ACELERADORRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public virtual TRANSICIONES_ACELERADORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSICIONES_ACELERADOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRANSICIONES_ACELERADORRow"/> by the primary key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="transicion_ocurrida_id">The <c>TRANSICION_OCURRIDA_ID</c> column value.</param>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRANSICIONES_ACELERADORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRANSICIONES_ACELERADORRow GetByPrimaryKey(decimal entidad_id, decimal flujo_id, decimal transicion_ocurrida_id, decimal rol_id)
		{
			string whereSql = "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + " AND " +
							  "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + " AND " +
							  "TRANSICION_OCURRIDA_ID=" + _db.CreateSqlParameterName("TRANSICION_OCURRIDA_ID") + " AND " +
							  "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			AddParameter(cmd, "TRANSICION_OCURRIDA_ID", transicion_ocurrida_id);
			AddParameter(cmd, "ROL_ID", rol_id);
			TRANSICIONES_ACELERADORRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSICIONES_ACELERADORRow"/> objects 
		/// by the <c>FK_TRANSICIONES_ACEL_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public virtual TRANSICIONES_ACELERADORRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSICIONES_ACEL_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSICIONES_ACEL_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSICIONES_ACELERADORRow"/> objects 
		/// by the <c>FK_TRANSICIONES_ACEL_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public virtual TRANSICIONES_ACELERADORRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSICIONES_ACEL_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSICIONES_ACEL_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSICIONES_ACELERADORRow"/> objects 
		/// by the <c>FK_TRANSICIONES_ACEL_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public virtual TRANSICIONES_ACELERADORRow[] GetByROL_ID(decimal rol_id)
		{
			return MapRecords(CreateGetByROL_IDCommand(rol_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSICIONES_ACEL_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_IDAsDataTable(decimal rol_id)
		{
			return MapRecordsToDataTable(CreateGetByROL_IDCommand(rol_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSICIONES_ACEL_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_IDCommand(decimal rol_id)
		{
			string whereSql = "";
			whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSICIONES_ACELERADORRow"/> objects 
		/// by the <c>FK_TRANSICIONES_ACEL_T_OCU</c> foreign key.
		/// </summary>
		/// <param name="transicion_ocurrida_id">The <c>TRANSICION_OCURRIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public virtual TRANSICIONES_ACELERADORRow[] GetByTRANSICION_OCURRIDA_ID(decimal transicion_ocurrida_id)
		{
			return MapRecords(CreateGetByTRANSICION_OCURRIDA_IDCommand(transicion_ocurrida_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSICIONES_ACEL_T_OCU</c> foreign key.
		/// </summary>
		/// <param name="transicion_ocurrida_id">The <c>TRANSICION_OCURRIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSICION_OCURRIDA_IDAsDataTable(decimal transicion_ocurrida_id)
		{
			return MapRecordsToDataTable(CreateGetByTRANSICION_OCURRIDA_IDCommand(transicion_ocurrida_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSICIONES_ACEL_T_OCU</c> foreign key.
		/// </summary>
		/// <param name="transicion_ocurrida_id">The <c>TRANSICION_OCURRIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSICION_OCURRIDA_IDCommand(decimal transicion_ocurrida_id)
		{
			string whereSql = "";
			whereSql += "TRANSICION_OCURRIDA_ID=" + _db.CreateSqlParameterName("TRANSICION_OCURRIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TRANSICION_OCURRIDA_ID", transicion_ocurrida_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSICIONES_ACELERADORRow"/> objects 
		/// by the <c>FK_TRANSICIONES_ACEL_T_SGT</c> foreign key.
		/// </summary>
		/// <param name="transicion_siguiente_id">The <c>TRANSICION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		public virtual TRANSICIONES_ACELERADORRow[] GetByTRANSICION_SIGUIENTE_ID(decimal transicion_siguiente_id)
		{
			return MapRecords(CreateGetByTRANSICION_SIGUIENTE_IDCommand(transicion_siguiente_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSICIONES_ACEL_T_SGT</c> foreign key.
		/// </summary>
		/// <param name="transicion_siguiente_id">The <c>TRANSICION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSICION_SIGUIENTE_IDAsDataTable(decimal transicion_siguiente_id)
		{
			return MapRecordsToDataTable(CreateGetByTRANSICION_SIGUIENTE_IDCommand(transicion_siguiente_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSICIONES_ACEL_T_SGT</c> foreign key.
		/// </summary>
		/// <param name="transicion_siguiente_id">The <c>TRANSICION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSICION_SIGUIENTE_IDCommand(decimal transicion_siguiente_id)
		{
			string whereSql = "";
			whereSql += "TRANSICION_SIGUIENTE_ID=" + _db.CreateSqlParameterName("TRANSICION_SIGUIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TRANSICION_SIGUIENTE_ID", transicion_siguiente_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TRANSICIONES_ACELERADOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSICIONES_ACELERADORRow"/> object to be inserted.</param>
		public virtual void Insert(TRANSICIONES_ACELERADORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRANSICIONES_ACELERADOR (" +
				"ENTIDAD_ID, " +
				"FLUJO_ID, " +
				"TRANSICION_OCURRIDA_ID, " +
				"TRANSICION_SIGUIENTE_ID, " +
				"ESTADO, " +
				"ROL_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("TRANSICION_OCURRIDA_ID") + ", " +
				_db.CreateSqlParameterName("TRANSICION_SIGUIENTE_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("ROL_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "TRANSICION_OCURRIDA_ID", value.TRANSICION_OCURRIDA_ID);
			AddParameter(cmd, "TRANSICION_SIGUIENTE_ID", value.TRANSICION_SIGUIENTE_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ROL_ID", value.ROL_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRANSICIONES_ACELERADOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSICIONES_ACELERADORRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRANSICIONES_ACELERADORRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRANSICIONES_ACELERADOR SET " +
				"TRANSICION_SIGUIENTE_ID=" + _db.CreateSqlParameterName("TRANSICION_SIGUIENTE_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + " AND " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + " AND " +
				"TRANSICION_OCURRIDA_ID=" + _db.CreateSqlParameterName("TRANSICION_OCURRIDA_ID") + " AND " +
				"ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TRANSICION_SIGUIENTE_ID", value.TRANSICION_SIGUIENTE_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "TRANSICION_OCURRIDA_ID", value.TRANSICION_OCURRIDA_ID);
			AddParameter(cmd, "ROL_ID", value.ROL_ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRANSICIONES_ACELERADOR</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRANSICIONES_ACELERADOR</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
							DeleteByPrimaryKey((decimal)row["ENTIDAD_ID"], (decimal)row["FLUJO_ID"], (decimal)row["TRANSICION_OCURRIDA_ID"], (decimal)row["ROL_ID"]);
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
		/// Deletes the specified object from the <c>TRANSICIONES_ACELERADOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSICIONES_ACELERADORRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRANSICIONES_ACELERADORRow value)
		{
			return DeleteByPrimaryKey(value.ENTIDAD_ID, value.FLUJO_ID, value.TRANSICION_OCURRIDA_ID, value.ROL_ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRANSICIONES_ACELERADOR</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="transicion_ocurrida_id">The <c>TRANSICION_OCURRIDA_ID</c> column value.</param>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal entidad_id, decimal flujo_id, decimal transicion_ocurrida_id, decimal rol_id)
		{
			string whereSql = "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + " AND " +
							  "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + " AND " +
							  "TRANSICION_OCURRIDA_ID=" + _db.CreateSqlParameterName("TRANSICION_OCURRIDA_ID") + " AND " +
							  "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			AddParameter(cmd, "TRANSICION_OCURRIDA_ID", transicion_ocurrida_id);
			AddParameter(cmd, "ROL_ID", rol_id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>TRANSICIONES_ACELERADOR</c> table using the 
		/// <c>FK_TRANSICIONES_ACEL_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSICIONES_ACEL_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSICIONES_ACELERADOR</c> table using the 
		/// <c>FK_TRANSICIONES_ACEL_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSICIONES_ACEL_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSICIONES_ACELERADOR</c> table using the 
		/// <c>FK_TRANSICIONES_ACEL_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id)
		{
			return CreateDeleteByROL_IDCommand(rol_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSICIONES_ACEL_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_IDCommand(decimal rol_id)
		{
			string whereSql = "";
			whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSICIONES_ACELERADOR</c> table using the 
		/// <c>FK_TRANSICIONES_ACEL_T_OCU</c> foreign key.
		/// </summary>
		/// <param name="transicion_ocurrida_id">The <c>TRANSICION_OCURRIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_OCURRIDA_ID(decimal transicion_ocurrida_id)
		{
			return CreateDeleteByTRANSICION_OCURRIDA_IDCommand(transicion_ocurrida_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSICIONES_ACEL_T_OCU</c> foreign key.
		/// </summary>
		/// <param name="transicion_ocurrida_id">The <c>TRANSICION_OCURRIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSICION_OCURRIDA_IDCommand(decimal transicion_ocurrida_id)
		{
			string whereSql = "";
			whereSql += "TRANSICION_OCURRIDA_ID=" + _db.CreateSqlParameterName("TRANSICION_OCURRIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TRANSICION_OCURRIDA_ID", transicion_ocurrida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSICIONES_ACELERADOR</c> table using the 
		/// <c>FK_TRANSICIONES_ACEL_T_SGT</c> foreign key.
		/// </summary>
		/// <param name="transicion_siguiente_id">The <c>TRANSICION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_SIGUIENTE_ID(decimal transicion_siguiente_id)
		{
			return CreateDeleteByTRANSICION_SIGUIENTE_IDCommand(transicion_siguiente_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSICIONES_ACEL_T_SGT</c> foreign key.
		/// </summary>
		/// <param name="transicion_siguiente_id">The <c>TRANSICION_SIGUIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSICION_SIGUIENTE_IDCommand(decimal transicion_siguiente_id)
		{
			string whereSql = "";
			whereSql += "TRANSICION_SIGUIENTE_ID=" + _db.CreateSqlParameterName("TRANSICION_SIGUIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TRANSICION_SIGUIENTE_ID", transicion_siguiente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TRANSICIONES_ACELERADOR</c> records that match the specified criteria.
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
		/// to delete <c>TRANSICIONES_ACELERADOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRANSICIONES_ACELERADOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRANSICIONES_ACELERADOR</c> table.
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
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		protected TRANSICIONES_ACELERADORRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		protected TRANSICIONES_ACELERADORRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSICIONES_ACELERADORRow"/> objects.</returns>
		protected virtual TRANSICIONES_ACELERADORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int transicion_ocurrida_idColumnIndex = reader.GetOrdinal("TRANSICION_OCURRIDA_ID");
			int transicion_siguiente_idColumnIndex = reader.GetOrdinal("TRANSICION_SIGUIENTE_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int rol_idColumnIndex = reader.GetOrdinal("ROL_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSICIONES_ACELERADORRow record = new TRANSICIONES_ACELERADORRow();
					recordList.Add(record);

					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					record.TRANSICION_OCURRIDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_ocurrida_idColumnIndex)), 9);
					record.TRANSICION_SIGUIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_siguiente_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.ROL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rol_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSICIONES_ACELERADORRow[])(recordList.ToArray(typeof(TRANSICIONES_ACELERADORRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSICIONES_ACELERADORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSICIONES_ACELERADORRow"/> object.</returns>
		protected virtual TRANSICIONES_ACELERADORRow MapRow(DataRow row)
		{
			TRANSICIONES_ACELERADORRow mappedObject = new TRANSICIONES_ACELERADORRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "TRANSICION_OCURRIDA_ID"
			dataColumn = dataTable.Columns["TRANSICION_OCURRIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_OCURRIDA_ID = (decimal)row[dataColumn];
			// Column "TRANSICION_SIGUIENTE_ID"
			dataColumn = dataTable.Columns["TRANSICION_SIGUIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_SIGUIENTE_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "ROL_ID"
			dataColumn = dataTable.Columns["ROL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSICIONES_ACELERADOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSICIONES_ACELERADOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRANSICION_OCURRIDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRANSICION_SIGUIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ROL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
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
				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSICION_OCURRIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSICION_SIGUIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ROL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSICIONES_ACELERADORCollection_Base class
}  // End of namespace
