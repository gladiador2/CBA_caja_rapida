// <fileinfo name="CTB_ASIENTOS_AUTOMATICOSCollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_AUTOMATICOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_AUTOMATICOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_AUTOMATICOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string TRANSICION_IDColumnName = "TRANSICION_ID";
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
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_AUTOMATICOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_AUTOMATICOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTOMATICOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_AUTOMATICOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_AUTOMATICOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTOMATICOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTOMATICOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_AUTOMATICOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_ASIENTOS_AUTOMATICOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_ASIENTOS_AUTOMATICOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_ENT</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTOMATICOSRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_ENT</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUTO_ENT</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTOMATICOSRow[] GetByPAIS_ID(decimal pais_id)
		{
			return MapRecords(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_IDAsDataTable(decimal pais_id)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUTO_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		public CTB_ASIENTOS_AUTOMATICOSRow[] GetByTRANSICION_ID(decimal transicion_id)
		{
			return GetByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOS_AUTOMATICOSRow[] GetByTRANSICION_ID(decimal transicion_id, bool transicion_idNull)
		{
			return MapRecords(CreateGetByTRANSICION_IDCommand(transicion_id, transicion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSICION_IDAsDataTable(decimal transicion_id)
		{
			return GetByTRANSICION_IDAsDataTable(transicion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSICION_IDAsDataTable(decimal transicion_id, bool transicion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSICION_IDCommand(transicion_id, transicion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSICION_IDCommand(decimal transicion_id, bool transicion_idNull)
		{
			string whereSql = "";
			if(transicion_idNull)
				whereSql += "TRANSICION_ID IS NULL";
			else
				whereSql += "TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transicion_idNull)
				AddParameter(cmd, "TRANSICION_ID", transicion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_ASIENTOS_AUTOMATICOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_ASIENTOS_AUTOMATICOS (" +
				"ID, " +
				"ENTIDAD_ID, " +
				"PAIS_ID, " +
				"TRANSICION_ID, " +
				"ESTADO, " +
				"NOMBRE, " +
				"REVISION_POSTERIOR, " +
				"COPIAR_OBSERVACION_CASO, " +
				"MOSTRAR_OBS_DET_REPORTE, " +
				"USAR_FECHA_TRANSICION, " +
				"ESTRUCTURA_OBSERVACION, " +
				"UNIFICAR_DETALLES_MISMA_CUENTA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("PAIS_ID") + ", " +
				_db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("REVISION_POSTERIOR") + ", " +
				_db.CreateSqlParameterName("COPIAR_OBSERVACION_CASO") + ", " +
				_db.CreateSqlParameterName("MOSTRAR_OBS_DET_REPORTE") + ", " +
				_db.CreateSqlParameterName("USAR_FECHA_TRANSICION") + ", " +
				_db.CreateSqlParameterName("ESTRUCTURA_OBSERVACION") + ", " +
				_db.CreateSqlParameterName("UNIFICAR_DETALLES_MISMA_CUENTA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "REVISION_POSTERIOR", value.REVISION_POSTERIOR);
			AddParameter(cmd, "COPIAR_OBSERVACION_CASO", value.COPIAR_OBSERVACION_CASO);
			AddParameter(cmd, "MOSTRAR_OBS_DET_REPORTE", value.MOSTRAR_OBS_DET_REPORTE);
			AddParameter(cmd, "USAR_FECHA_TRANSICION", value.USAR_FECHA_TRANSICION);
			AddParameter(cmd, "ESTRUCTURA_OBSERVACION", value.ESTRUCTURA_OBSERVACION);
			AddParameter(cmd, "UNIFICAR_DETALLES_MISMA_CUENTA", value.UNIFICAR_DETALLES_MISMA_CUENTA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_ASIENTOS_AUTOMATICOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_ASIENTOS_AUTOMATICOS SET " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID") + ", " +
				"TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"REVISION_POSTERIOR=" + _db.CreateSqlParameterName("REVISION_POSTERIOR") + ", " +
				"COPIAR_OBSERVACION_CASO=" + _db.CreateSqlParameterName("COPIAR_OBSERVACION_CASO") + ", " +
				"MOSTRAR_OBS_DET_REPORTE=" + _db.CreateSqlParameterName("MOSTRAR_OBS_DET_REPORTE") + ", " +
				"USAR_FECHA_TRANSICION=" + _db.CreateSqlParameterName("USAR_FECHA_TRANSICION") + ", " +
				"ESTRUCTURA_OBSERVACION=" + _db.CreateSqlParameterName("ESTRUCTURA_OBSERVACION") + ", " +
				"UNIFICAR_DETALLES_MISMA_CUENTA=" + _db.CreateSqlParameterName("UNIFICAR_DETALLES_MISMA_CUENTA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "REVISION_POSTERIOR", value.REVISION_POSTERIOR);
			AddParameter(cmd, "COPIAR_OBSERVACION_CASO", value.COPIAR_OBSERVACION_CASO);
			AddParameter(cmd, "MOSTRAR_OBS_DET_REPORTE", value.MOSTRAR_OBS_DET_REPORTE);
			AddParameter(cmd, "USAR_FECHA_TRANSICION", value.USAR_FECHA_TRANSICION);
			AddParameter(cmd, "ESTRUCTURA_OBSERVACION", value.ESTRUCTURA_OBSERVACION);
			AddParameter(cmd, "UNIFICAR_DETALLES_MISMA_CUENTA", value.UNIFICAR_DETALLES_MISMA_CUENTA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_AUTOMATICOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS_AUTOMATICOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_ASIENTOS_AUTOMATICOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table using
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_ENT</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUTO_ENT</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id)
		{
			return CreateDeleteByPAIS_IDCommand(pais_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUTO_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_ID(decimal transicion_id)
		{
			return DeleteByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_ID(decimal transicion_id, bool transicion_idNull)
		{
			return CreateDeleteByTRANSICION_IDCommand(transicion_id, transicion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_AUTO_TRANS</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSICION_IDCommand(decimal transicion_id, bool transicion_idNull)
		{
			string whereSql = "";
			if(transicion_idNull)
				whereSql += "TRANSICION_ID IS NULL";
			else
				whereSql += "TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transicion_idNull)
				AddParameter(cmd, "TRANSICION_ID", transicion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_ASIENTOS_AUTOMATICOS</c> records that match the specified criteria.
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
		/// to delete <c>CTB_ASIENTOS_AUTOMATICOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_ASIENTOS_AUTOMATICOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTOMATICOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		protected CTB_ASIENTOS_AUTOMATICOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_AUTOMATICOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int transicion_idColumnIndex = reader.GetOrdinal("TRANSICION_ID");
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
					CTB_ASIENTOS_AUTOMATICOSRow record = new CTB_ASIENTOS_AUTOMATICOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(transicion_idColumnIndex))
						record.TRANSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_idColumnIndex)), 9);
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
			return (CTB_ASIENTOS_AUTOMATICOSRow[])(recordList.ToArray(typeof(CTB_ASIENTOS_AUTOMATICOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_AUTOMATICOSRow"/> object.</returns>
		protected virtual CTB_ASIENTOS_AUTOMATICOSRow MapRow(DataRow row)
		{
			CTB_ASIENTOS_AUTOMATICOSRow mappedObject = new CTB_ASIENTOS_AUTOMATICOSRow();
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
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "TRANSICION_ID"
			dataColumn = dataTable.Columns["TRANSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_ID = (decimal)row[dataColumn];
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
		/// the <c>CTB_ASIENTOS_AUTOMATICOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_AUTOMATICOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRANSICION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REVISION_POSTERIOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COPIAR_OBSERVACION_CASO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOSTRAR_OBS_DET_REPORTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USAR_FECHA_TRANSICION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTRUCTURA_OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIFICAR_DETALLES_MISMA_CUENTA", typeof(string));
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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
	} // End of CTB_ASIENTOS_AUTOMATICOSCollection_Base class
}  // End of namespace
