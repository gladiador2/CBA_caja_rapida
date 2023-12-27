// <fileinfo name="DETALLES_PERSONALIZADOS_HISTCollection_Base.cs">
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
	/// The base class for <see cref="DETALLES_PERSONALIZADOS_HISTCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DETALLES_PERSONALIZADOS_HISTCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DETALLES_PERSONALIZADOS_HISTCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_DETALLE_PERSONALIZADO_IDColumnName = "TIPO_DETALLE_PERSONALIZADO_ID";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_COPIADO_IDColumnName = "USUARIO_COPIADO_ID";
		public const string FECHA_COPIADOColumnName = "FECHA_COPIADO";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string COLUMNAColumnName = "COLUMNA";
		public const string REGISTRO_IDColumnName = "REGISTRO_ID";
		public const string CASO_IDColumnName = "CASO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOS_HISTCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DETALLES_PERSONALIZADOS_HISTCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HISTRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DETALLES_PERSONALIZADOS_HISTRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DETALLES_PERSONALIZADOS_HISTRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		public DETALLES_PERSONALIZADOS_HISTRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects that 
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HISTRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DETALLES_PERSONALIZADOS_HIST";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DETALLES_PERSONALIZADOS_HISTRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DETALLES_PERSONALIZADOS_HISTRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_HIST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HISTRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_HIST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_HIST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_HIST_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HISTRow[] GetByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id)
		{
			return MapRecords(CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_HIST_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_DETALLE_PERSONALIZADO_IDAsDataTable(decimal tipo_detalle_personalizado_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_HIST_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(decimal tipo_detalle_personalizado_id)
		{
			string whereSql = "";
			whereSql += "TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", tipo_detalle_personalizado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_HIST_USR_CO</c> foreign key.
		/// </summary>
		/// <param name="usuario_copiado_id">The <c>USUARIO_COPIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HISTRow[] GetByUSUARIO_COPIADO_ID(decimal usuario_copiado_id)
		{
			return MapRecords(CreateGetByUSUARIO_COPIADO_IDCommand(usuario_copiado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_HIST_USR_CO</c> foreign key.
		/// </summary>
		/// <param name="usuario_copiado_id">The <c>USUARIO_COPIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_COPIADO_IDAsDataTable(decimal usuario_copiado_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_COPIADO_IDCommand(usuario_copiado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_HIST_USR_CO</c> foreign key.
		/// </summary>
		/// <param name="usuario_copiado_id">The <c>USUARIO_COPIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_COPIADO_IDCommand(decimal usuario_copiado_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_COPIADO_ID=" + _db.CreateSqlParameterName("USUARIO_COPIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_COPIADO_ID", usuario_copiado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_HIST_USR_CR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HISTRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_HIST_USR_CR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_HIST_USR_CR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> object to be inserted.</param>
		public virtual void Insert(DETALLES_PERSONALIZADOS_HISTRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DETALLES_PERSONALIZADOS_HIST (" +
				"ID, " +
				"TIPO_DETALLE_PERSONALIZADO_ID, " +
				"USUARIO_CREACION_ID, " +
				"FECHA_CREACION, " +
				"USUARIO_COPIADO_ID, " +
				"FECHA_COPIADO, " +
				"TABLA_ID, " +
				"COLUMNA, " +
				"REGISTRO_ID, " +
				"CASO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_COPIADO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_COPIADO") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("COLUMNA") + ", " +
				_db.CreateSqlParameterName("REGISTRO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", value.TIPO_DETALLE_PERSONALIZADO_ID);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_COPIADO_ID", value.USUARIO_COPIADO_ID);
			AddParameter(cmd, "FECHA_COPIADO", value.FECHA_COPIADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "COLUMNA", value.COLUMNA);
			AddParameter(cmd, "REGISTRO_ID", value.REGISTRO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOS_HISTRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DETALLES_PERSONALIZADOS_HISTRow value)
		{
			
			string sqlStr = "UPDATE TRC.DETALLES_PERSONALIZADOS_HIST SET " +
				"TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_COPIADO_ID=" + _db.CreateSqlParameterName("USUARIO_COPIADO_ID") + ", " +
				"FECHA_COPIADO=" + _db.CreateSqlParameterName("FECHA_COPIADO") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"COLUMNA=" + _db.CreateSqlParameterName("COLUMNA") + ", " +
				"REGISTRO_ID=" + _db.CreateSqlParameterName("REGISTRO_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", value.TIPO_DETALLE_PERSONALIZADO_ID);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_COPIADO_ID", value.USUARIO_COPIADO_ID);
			AddParameter(cmd, "FECHA_COPIADO", value.FECHA_COPIADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "COLUMNA", value.COLUMNA);
			AddParameter(cmd, "REGISTRO_ID", value.REGISTRO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DETALLES_PERSONALIZADOS_HIST</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DETALLES_PERSONALIZADOS_HIST</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DETALLES_PERSONALIZADOS_HISTRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DETALLES_PERSONALIZADOS_HIST</c> table using
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
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table using the 
		/// <c>FK_DETALLES_PERS_HIST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_HIST_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table using the 
		/// <c>FK_DETALLES_PERS_HIST_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id)
		{
			return CreateDeleteByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_HIST_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_DETALLE_PERSONALIZADO_IDCommand(decimal tipo_detalle_personalizado_id)
		{
			string whereSql = "";
			whereSql += "TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", tipo_detalle_personalizado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table using the 
		/// <c>FK_DETALLES_PERS_HIST_USR_CO</c> foreign key.
		/// </summary>
		/// <param name="usuario_copiado_id">The <c>USUARIO_COPIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_COPIADO_ID(decimal usuario_copiado_id)
		{
			return CreateDeleteByUSUARIO_COPIADO_IDCommand(usuario_copiado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_HIST_USR_CO</c> foreign key.
		/// </summary>
		/// <param name="usuario_copiado_id">The <c>USUARIO_COPIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_COPIADO_IDCommand(decimal usuario_copiado_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_COPIADO_ID=" + _db.CreateSqlParameterName("USUARIO_COPIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_COPIADO_ID", usuario_copiado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table using the 
		/// <c>FK_DETALLES_PERS_HIST_USR_CR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_HIST_USR_CR</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DETALLES_PERSONALIZADOS_HIST</c> records that match the specified criteria.
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
		/// to delete <c>DETALLES_PERSONALIZADOS_HIST</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DETALLES_PERSONALIZADOS_HIST";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		protected DETALLES_PERSONALIZADOS_HISTRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		protected DETALLES_PERSONALIZADOS_HISTRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> objects.</returns>
		protected virtual DETALLES_PERSONALIZADOS_HISTRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_detalle_personalizado_idColumnIndex = reader.GetOrdinal("TIPO_DETALLE_PERSONALIZADO_ID");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_copiado_idColumnIndex = reader.GetOrdinal("USUARIO_COPIADO_ID");
			int fecha_copiadoColumnIndex = reader.GetOrdinal("FECHA_COPIADO");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int columnaColumnIndex = reader.GetOrdinal("COLUMNA");
			int registro_idColumnIndex = reader.GetOrdinal("REGISTRO_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DETALLES_PERSONALIZADOS_HISTRow record = new DETALLES_PERSONALIZADOS_HISTRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_DETALLE_PERSONALIZADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_detalle_personalizado_idColumnIndex)), 9);
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_COPIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_copiado_idColumnIndex)), 9);
					record.FECHA_COPIADO = Convert.ToDateTime(reader.GetValue(fecha_copiadoColumnIndex));
					record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					record.COLUMNA = Convert.ToString(reader.GetValue(columnaColumnIndex));
					record.REGISTRO_ID = Convert.ToString(reader.GetValue(registro_idColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DETALLES_PERSONALIZADOS_HISTRow[])(recordList.ToArray(typeof(DETALLES_PERSONALIZADOS_HISTRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DETALLES_PERSONALIZADOS_HISTRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> object.</returns>
		protected virtual DETALLES_PERSONALIZADOS_HISTRow MapRow(DataRow row)
		{
			DETALLES_PERSONALIZADOS_HISTRow mappedObject = new DETALLES_PERSONALIZADOS_HISTRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_DETALLE_PERSONALIZADO_ID"
			dataColumn = dataTable.Columns["TIPO_DETALLE_PERSONALIZADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DETALLE_PERSONALIZADO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_COPIADO_ID"
			dataColumn = dataTable.Columns["USUARIO_COPIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_COPIADO_ID = (decimal)row[dataColumn];
			// Column "FECHA_COPIADO"
			dataColumn = dataTable.Columns["FECHA_COPIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COPIADO = (System.DateTime)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "COLUMNA"
			dataColumn = dataTable.Columns["COLUMNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLUMNA = (string)row[dataColumn];
			// Column "REGISTRO_ID"
			dataColumn = dataTable.Columns["REGISTRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO_ID = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DETALLES_PERSONALIZADOS_HIST";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_DETALLE_PERSONALIZADO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_COPIADO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_COPIADO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COLUMNA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGISTRO_ID", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
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

				case "TIPO_DETALLE_PERSONALIZADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_COPIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_COPIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COLUMNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGISTRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DETALLES_PERSONALIZADOS_HISTCollection_Base class
}  // End of namespace
