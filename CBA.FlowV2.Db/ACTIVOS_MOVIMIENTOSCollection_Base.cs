// <fileinfo name="ACTIVOS_MOVIMIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="ACTIVOS_MOVIMIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ACTIVOS_MOVIMIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ACTIVOS_MOVIMIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string FECHA_MOVIMIENTOColumnName = "FECHA_MOVIMIENTO";
		public const string USUARIO_MOVIMIENTO_IDColumnName = "USUARIO_MOVIMIENTO_ID";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ACTIVOS_MOVIMIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ACTIVOS_MOVIMIENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ACTIVOS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual ACTIVOS_MOVIMIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ACTIVOS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ACTIVOS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ACTIVOS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ACTIVOS_MOVIMIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ACTIVOS_MOVIMIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		public ACTIVOS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual ACTIVOS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ACTIVOS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ACTIVOS_MOVIMIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ACTIVOS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ACTIVOS_MOVIMIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ACTIVOS_MOVIMIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_MOV_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual ACTIVOS_MOVIMIENTOSRow[] GetByACTIVO_ID(decimal activo_id)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_MOV_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_IDCommand(activo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_MOV_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_IDCommand(decimal activo_id)
		{
			string whereSql = "";
			whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_MOV_SUC_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual ACTIVOS_MOVIMIENTOSRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return MapRecords(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_MOV_SUC_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_MOV_SUC_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_MOV_SUC_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual ACTIVOS_MOVIMIENTOSRow[] GetBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return MapRecords(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_MOV_SUC_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_ORIGEN_IDAsDataTable(decimal sucursal_origen_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_MOV_SUC_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_ORIGEN_IDCommand(decimal sucursal_origen_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", sucursal_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_ACTIVOS_MOV_USU_MOV_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_movimiento_id">The <c>USUARIO_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual ACTIVOS_MOVIMIENTOSRow[] GetByUSUARIO_MOVIMIENTO_ID(decimal usuario_movimiento_id)
		{
			return MapRecords(CreateGetByUSUARIO_MOVIMIENTO_IDCommand(usuario_movimiento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ACTIVOS_MOV_USU_MOV_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_movimiento_id">The <c>USUARIO_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_MOVIMIENTO_IDAsDataTable(decimal usuario_movimiento_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_MOVIMIENTO_IDCommand(usuario_movimiento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ACTIVOS_MOV_USU_MOV_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_movimiento_id">The <c>USUARIO_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_MOVIMIENTO_IDCommand(decimal usuario_movimiento_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("USUARIO_MOVIMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_MOVIMIENTO_ID", usuario_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ACTIVOS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ACTIVOS_MOVIMIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(ACTIVOS_MOVIMIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ACTIVOS_MOVIMIENTOS (" +
				"ID, " +
				"ACTIVO_ID, " +
				"SUCURSAL_ORIGEN_ID, " +
				"SUCURSAL_DESTINO_ID, " +
				"FECHA_MOVIMIENTO, " +
				"USUARIO_MOVIMIENTO_ID, " +
				"OBSERVACIONES, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("USUARIO_MOVIMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ACTIVO_ID", value.ACTIVO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "FECHA_MOVIMIENTO", value.FECHA_MOVIMIENTO);
			AddParameter(cmd, "USUARIO_MOVIMIENTO_ID", value.USUARIO_MOVIMIENTO_ID);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ACTIVOS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ACTIVOS_MOVIMIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ACTIVOS_MOVIMIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ACTIVOS_MOVIMIENTOS SET " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				"SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				"FECHA_MOVIMIENTO=" + _db.CreateSqlParameterName("FECHA_MOVIMIENTO") + ", " +
				"USUARIO_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("USUARIO_MOVIMIENTO_ID") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ACTIVO_ID", value.ACTIVO_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "FECHA_MOVIMIENTO", value.FECHA_MOVIMIENTO);
			AddParameter(cmd, "USUARIO_MOVIMIENTO_ID", value.USUARIO_MOVIMIENTO_ID);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ACTIVOS_MOVIMIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ACTIVOS_MOVIMIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ACTIVOS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ACTIVOS_MOVIMIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ACTIVOS_MOVIMIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ACTIVOS_MOVIMIENTOS</c> table using
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
		/// Deletes records from the <c>ACTIVOS_MOVIMIENTOS</c> table using the 
		/// <c>FK_ACTIVOS_MOV_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return CreateDeleteByACTIVO_IDCommand(activo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_MOV_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_IDCommand(decimal activo_id)
		{
			string whereSql = "";
			whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS_MOVIMIENTOS</c> table using the 
		/// <c>FK_ACTIVOS_MOV_SUC_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return CreateDeleteBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_MOV_SUC_DEST_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS_MOVIMIENTOS</c> table using the 
		/// <c>FK_ACTIVOS_MOV_SUC_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return CreateDeleteBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_MOV_SUC_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_ORIGEN_IDCommand(decimal sucursal_origen_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID", sucursal_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ACTIVOS_MOVIMIENTOS</c> table using the 
		/// <c>FK_ACTIVOS_MOV_USU_MOV_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_movimiento_id">The <c>USUARIO_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MOVIMIENTO_ID(decimal usuario_movimiento_id)
		{
			return CreateDeleteByUSUARIO_MOVIMIENTO_IDCommand(usuario_movimiento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ACTIVOS_MOV_USU_MOV_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_movimiento_id">The <c>USUARIO_MOVIMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_MOVIMIENTO_IDCommand(decimal usuario_movimiento_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_MOVIMIENTO_ID=" + _db.CreateSqlParameterName("USUARIO_MOVIMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_MOVIMIENTO_ID", usuario_movimiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ACTIVOS_MOVIMIENTOS</c> records that match the specified criteria.
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
		/// to delete <c>ACTIVOS_MOVIMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ACTIVOS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ACTIVOS_MOVIMIENTOS</c> table.
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
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		protected ACTIVOS_MOVIMIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		protected ACTIVOS_MOVIMIENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ACTIVOS_MOVIMIENTOSRow"/> objects.</returns>
		protected virtual ACTIVOS_MOVIMIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int fecha_movimientoColumnIndex = reader.GetOrdinal("FECHA_MOVIMIENTO");
			int usuario_movimiento_idColumnIndex = reader.GetOrdinal("USUARIO_MOVIMIENTO_ID");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ACTIVOS_MOVIMIENTOSRow record = new ACTIVOS_MOVIMIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					record.FECHA_MOVIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_movimientoColumnIndex));
					record.USUARIO_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_movimiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ACTIVOS_MOVIMIENTOSRow[])(recordList.ToArray(typeof(ACTIVOS_MOVIMIENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ACTIVOS_MOVIMIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ACTIVOS_MOVIMIENTOSRow"/> object.</returns>
		protected virtual ACTIVOS_MOVIMIENTOSRow MapRow(DataRow row)
		{
			ACTIVOS_MOVIMIENTOSRow mappedObject = new ACTIVOS_MOVIMIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "FECHA_MOVIMIENTO"
			dataColumn = dataTable.Columns["FECHA_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MOVIMIENTO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["USUARIO_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ACTIVOS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ACTIVOS_MOVIMIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_MOVIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_MOVIMIENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
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
				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ACTIVOS_MOVIMIENTOSCollection_Base class
}  // End of namespace
