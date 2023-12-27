// <fileinfo name="CTB_ASIENTOS_AUTO_DETCollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTO_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_AUTO_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTO_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_ASIENTO_AUTOMATICO_IDColumnName = "CTB_ASIENTO_AUTOMATICO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string ORDENColumnName = "ORDEN";
		public const string COLUMNA_PRIORITARIAColumnName = "COLUMNA_PRIORITARIA";
		public const string COLUMNA_PRIORITARIA2ColumnName = "COLUMNA_PRIORITARIA2";
		public const string RESUMIR_DETALLESColumnName = "RESUMIR_DETALLES";
		public const string CENTRO_COSTO_PRIORIDADColumnName = "CENTRO_COSTO_PRIORIDAD";
		public const string CENTRO_COSTO_PRIORIDAD2ColumnName = "CENTRO_COSTO_PRIORIDAD2";
		public const string COPIAR_OBS_CABECERA_ASIENTOColumnName = "COPIAR_OBS_CABECERA_ASIENTO";
		public const string CENTRO_COSTO_PRIORIDAD3ColumnName = "CENTRO_COSTO_PRIORIDAD3";
		public const string ESTRUCTURA_OBSERVACIONColumnName = "ESTRUCTURA_OBSERVACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTO_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_AUTO_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_AUTO_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_AUTO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_AUTO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_AUTO_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_AUTO_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTO_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_AUTO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_ASIENTOS_AUTO_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_ASIENTOS_AUTO_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_ASIENTOS_AUTO_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects 
		/// by the <c>FK_ASIENTOS_AUTO_DET_AS_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_automatico_id">The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTO_DETRow[] GetByCTB_ASIENTO_AUTOMATICO_ID(decimal ctb_asiento_automatico_id)
		{
			return MapRecords(CreateGetByCTB_ASIENTO_AUTOMATICO_IDCommand(ctb_asiento_automatico_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ASIENTOS_AUTO_DET_AS_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_automatico_id">The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_ASIENTO_AUTOMATICO_IDAsDataTable(decimal ctb_asiento_automatico_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_ASIENTO_AUTOMATICO_IDCommand(ctb_asiento_automatico_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ASIENTOS_AUTO_DET_AS_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_automatico_id">The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_ASIENTO_AUTOMATICO_IDCommand(decimal ctb_asiento_automatico_id)
		{
			string whereSql = "";
			whereSql += "CTB_ASIENTO_AUTOMATICO_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_AUTOMATICO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_ASIENTO_AUTOMATICO_ID", ctb_asiento_automatico_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_ASIENTOS_AUTO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTO_DETRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_ASIENTOS_AUTO_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_ASIENTOS_AUTO_DET (" +
				"ID, " +
				"CTB_ASIENTO_AUTOMATICO_ID, " +
				"NOMBRE, " +
				"DESCRIPCION, " +
				"ORDEN, " +
				"COLUMNA_PRIORITARIA, " +
				"COLUMNA_PRIORITARIA2, " +
				"RESUMIR_DETALLES, " +
				"CENTRO_COSTO_PRIORIDAD, " +
				"CENTRO_COSTO_PRIORIDAD2, " +
				"COPIAR_OBS_CABECERA_ASIENTO, " +
				"CENTRO_COSTO_PRIORIDAD3, " +
				"ESTRUCTURA_OBSERVACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_ASIENTO_AUTOMATICO_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("COLUMNA_PRIORITARIA") + ", " +
				_db.CreateSqlParameterName("COLUMNA_PRIORITARIA2") + ", " +
				_db.CreateSqlParameterName("RESUMIR_DETALLES") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_PRIORIDAD") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_PRIORIDAD2") + ", " +
				_db.CreateSqlParameterName("COPIAR_OBS_CABECERA_ASIENTO") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_PRIORIDAD3") + ", " +
				_db.CreateSqlParameterName("ESTRUCTURA_OBSERVACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_ASIENTO_AUTOMATICO_ID", value.CTB_ASIENTO_AUTOMATICO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "COLUMNA_PRIORITARIA",
				value.IsCOLUMNA_PRIORITARIANull ? DBNull.Value : (object)value.COLUMNA_PRIORITARIA);
			AddParameter(cmd, "COLUMNA_PRIORITARIA2",
				value.IsCOLUMNA_PRIORITARIA2Null ? DBNull.Value : (object)value.COLUMNA_PRIORITARIA2);
			AddParameter(cmd, "RESUMIR_DETALLES", value.RESUMIR_DETALLES);
			AddParameter(cmd, "CENTRO_COSTO_PRIORIDAD",
				value.IsCENTRO_COSTO_PRIORIDADNull ? DBNull.Value : (object)value.CENTRO_COSTO_PRIORIDAD);
			AddParameter(cmd, "CENTRO_COSTO_PRIORIDAD2",
				value.IsCENTRO_COSTO_PRIORIDAD2Null ? DBNull.Value : (object)value.CENTRO_COSTO_PRIORIDAD2);
			AddParameter(cmd, "COPIAR_OBS_CABECERA_ASIENTO", value.COPIAR_OBS_CABECERA_ASIENTO);
			AddParameter(cmd, "CENTRO_COSTO_PRIORIDAD3",
				value.IsCENTRO_COSTO_PRIORIDAD3Null ? DBNull.Value : (object)value.CENTRO_COSTO_PRIORIDAD3);
			AddParameter(cmd, "ESTRUCTURA_OBSERVACION", value.ESTRUCTURA_OBSERVACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_ASIENTOS_AUTO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTO_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_ASIENTOS_AUTO_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_ASIENTOS_AUTO_DET SET " +
				"CTB_ASIENTO_AUTOMATICO_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_AUTOMATICO_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"COLUMNA_PRIORITARIA=" + _db.CreateSqlParameterName("COLUMNA_PRIORITARIA") + ", " +
				"COLUMNA_PRIORITARIA2=" + _db.CreateSqlParameterName("COLUMNA_PRIORITARIA2") + ", " +
				"RESUMIR_DETALLES=" + _db.CreateSqlParameterName("RESUMIR_DETALLES") + ", " +
				"CENTRO_COSTO_PRIORIDAD=" + _db.CreateSqlParameterName("CENTRO_COSTO_PRIORIDAD") + ", " +
				"CENTRO_COSTO_PRIORIDAD2=" + _db.CreateSqlParameterName("CENTRO_COSTO_PRIORIDAD2") + ", " +
				"COPIAR_OBS_CABECERA_ASIENTO=" + _db.CreateSqlParameterName("COPIAR_OBS_CABECERA_ASIENTO") + ", " +
				"CENTRO_COSTO_PRIORIDAD3=" + _db.CreateSqlParameterName("CENTRO_COSTO_PRIORIDAD3") + ", " +
				"ESTRUCTURA_OBSERVACION=" + _db.CreateSqlParameterName("ESTRUCTURA_OBSERVACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_ASIENTO_AUTOMATICO_ID", value.CTB_ASIENTO_AUTOMATICO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "COLUMNA_PRIORITARIA",
				value.IsCOLUMNA_PRIORITARIANull ? DBNull.Value : (object)value.COLUMNA_PRIORITARIA);
			AddParameter(cmd, "COLUMNA_PRIORITARIA2",
				value.IsCOLUMNA_PRIORITARIA2Null ? DBNull.Value : (object)value.COLUMNA_PRIORITARIA2);
			AddParameter(cmd, "RESUMIR_DETALLES", value.RESUMIR_DETALLES);
			AddParameter(cmd, "CENTRO_COSTO_PRIORIDAD",
				value.IsCENTRO_COSTO_PRIORIDADNull ? DBNull.Value : (object)value.CENTRO_COSTO_PRIORIDAD);
			AddParameter(cmd, "CENTRO_COSTO_PRIORIDAD2",
				value.IsCENTRO_COSTO_PRIORIDAD2Null ? DBNull.Value : (object)value.CENTRO_COSTO_PRIORIDAD2);
			AddParameter(cmd, "COPIAR_OBS_CABECERA_ASIENTO", value.COPIAR_OBS_CABECERA_ASIENTO);
			AddParameter(cmd, "CENTRO_COSTO_PRIORIDAD3",
				value.IsCENTRO_COSTO_PRIORIDAD3Null ? DBNull.Value : (object)value.CENTRO_COSTO_PRIORIDAD3);
			AddParameter(cmd, "ESTRUCTURA_OBSERVACION", value.ESTRUCTURA_OBSERVACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_AUTO_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_AUTO_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_ASIENTOS_AUTO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTO_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_ASIENTOS_AUTO_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_ASIENTOS_AUTO_DET</c> table using
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTO_DET</c> table using the 
		/// <c>FK_ASIENTOS_AUTO_DET_AS_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_automatico_id">The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_ASIENTO_AUTOMATICO_ID(decimal ctb_asiento_automatico_id)
		{
			return CreateDeleteByCTB_ASIENTO_AUTOMATICO_IDCommand(ctb_asiento_automatico_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ASIENTOS_AUTO_DET_AS_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_automatico_id">The <c>CTB_ASIENTO_AUTOMATICO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_ASIENTO_AUTOMATICO_IDCommand(decimal ctb_asiento_automatico_id)
		{
			string whereSql = "";
			whereSql += "CTB_ASIENTO_AUTOMATICO_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_AUTOMATICO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_ASIENTO_AUTOMATICO_ID", ctb_asiento_automatico_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_ASIENTOS_AUTO_DET</c> records that match the specified criteria.
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
		/// to delete <c>CTB_ASIENTOS_AUTO_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_ASIENTOS_AUTO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_ASIENTOS_AUTO_DET</c> table.
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTO_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTO_DETRow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_AUTO_DETRow[] MapRecords(IDataReader reader, 
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
			int resumir_detallesColumnIndex = reader.GetOrdinal("RESUMIR_DETALLES");
			int centro_costo_prioridadColumnIndex = reader.GetOrdinal("CENTRO_COSTO_PRIORIDAD");
			int centro_costo_prioridad2ColumnIndex = reader.GetOrdinal("CENTRO_COSTO_PRIORIDAD2");
			int copiar_obs_cabecera_asientoColumnIndex = reader.GetOrdinal("COPIAR_OBS_CABECERA_ASIENTO");
			int centro_costo_prioridad3ColumnIndex = reader.GetOrdinal("CENTRO_COSTO_PRIORIDAD3");
			int estructura_observacionColumnIndex = reader.GetOrdinal("ESTRUCTURA_OBSERVACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_AUTO_DETRow record = new CTB_ASIENTOS_AUTO_DETRow();
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
					record.RESUMIR_DETALLES = Convert.ToString(reader.GetValue(resumir_detallesColumnIndex));
					if(!reader.IsDBNull(centro_costo_prioridadColumnIndex))
						record.CENTRO_COSTO_PRIORIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_prioridadColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_prioridad2ColumnIndex))
						record.CENTRO_COSTO_PRIORIDAD2 = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_prioridad2ColumnIndex)), 9);
					record.COPIAR_OBS_CABECERA_ASIENTO = Convert.ToString(reader.GetValue(copiar_obs_cabecera_asientoColumnIndex));
					if(!reader.IsDBNull(centro_costo_prioridad3ColumnIndex))
						record.CENTRO_COSTO_PRIORIDAD3 = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_prioridad3ColumnIndex)), 9);
					record.ESTRUCTURA_OBSERVACION = Convert.ToString(reader.GetValue(estructura_observacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_AUTO_DETRow[])(recordList.ToArray(typeof(CTB_ASIENTOS_AUTO_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_AUTO_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_AUTO_DETRow"/> object.</returns>
		protected virtual CTB_ASIENTOS_AUTO_DETRow MapRow(DataRow row)
		{
			CTB_ASIENTOS_AUTO_DETRow mappedObject = new CTB_ASIENTOS_AUTO_DETRow();
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
			// Column "RESUMIR_DETALLES"
			dataColumn = dataTable.Columns["RESUMIR_DETALLES"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESUMIR_DETALLES = (string)row[dataColumn];
			// Column "CENTRO_COSTO_PRIORIDAD"
			dataColumn = dataTable.Columns["CENTRO_COSTO_PRIORIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_PRIORIDAD = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_PRIORIDAD2"
			dataColumn = dataTable.Columns["CENTRO_COSTO_PRIORIDAD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_PRIORIDAD2 = (decimal)row[dataColumn];
			// Column "COPIAR_OBS_CABECERA_ASIENTO"
			dataColumn = dataTable.Columns["COPIAR_OBS_CABECERA_ASIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COPIAR_OBS_CABECERA_ASIENTO = (string)row[dataColumn];
			// Column "CENTRO_COSTO_PRIORIDAD3"
			dataColumn = dataTable.Columns["CENTRO_COSTO_PRIORIDAD3"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_PRIORIDAD3 = (decimal)row[dataColumn];
			// Column "ESTRUCTURA_OBSERVACION"
			dataColumn = dataTable.Columns["ESTRUCTURA_OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTRUCTURA_OBSERVACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_AUTO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_AUTO_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_AUTOMATICO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COLUMNA_PRIORITARIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COLUMNA_PRIORITARIA2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RESUMIR_DETALLES", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_PRIORIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_PRIORIDAD2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COPIAR_OBS_CABECERA_ASIENTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_PRIORIDAD3", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTRUCTURA_OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
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

				case "RESUMIR_DETALLES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CENTRO_COSTO_PRIORIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_PRIORIDAD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COPIAR_OBS_CABECERA_ASIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CENTRO_COSTO_PRIORIDAD3":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTRUCTURA_OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_AUTO_DETCollection_Base class
}  // End of namespace
