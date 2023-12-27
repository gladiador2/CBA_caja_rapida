// <fileinfo name="COMENTARIOS_TRANSICIONESCollection_Base.cs">
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
	/// The base class for <see cref="COMENTARIOS_TRANSICIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="COMENTARIOS_TRANSICIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COMENTARIOS_TRANSICIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string COMENTARIOColumnName = "COMENTARIO";
		public const string OPERACION_IDColumnName = "OPERACION_ID";
		public const string ORDENColumnName = "ORDEN";
		public const string TIPOColumnName = "TIPO";
		public const string COMENTARIO_TEXTO_IDColumnName = "COMENTARIO_TEXTO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="COMENTARIOS_TRANSICIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public COMENTARIOS_TRANSICIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>COMENTARIOS_TRANSICIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public virtual COMENTARIOS_TRANSICIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>COMENTARIOS_TRANSICIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>COMENTARIOS_TRANSICIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="COMENTARIOS_TRANSICIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="COMENTARIOS_TRANSICIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public COMENTARIOS_TRANSICIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			COMENTARIOS_TRANSICIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public COMENTARIOS_TRANSICIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public virtual COMENTARIOS_TRANSICIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.COMENTARIOS_TRANSICIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="COMENTARIOS_TRANSICIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="COMENTARIOS_TRANSICIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual COMENTARIOS_TRANSICIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			COMENTARIOS_TRANSICIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects 
		/// by the <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public COMENTARIOS_TRANSICIONESRow[] GetByCOMENTARIO_TEXTO_ID(decimal comentario_texto_id)
		{
			return GetByCOMENTARIO_TEXTO_ID(comentario_texto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects 
		/// by the <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <param name="comentario_texto_idNull">true if the method ignores the comentario_texto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public virtual COMENTARIOS_TRANSICIONESRow[] GetByCOMENTARIO_TEXTO_ID(decimal comentario_texto_id, bool comentario_texto_idNull)
		{
			return MapRecords(CreateGetByCOMENTARIO_TEXTO_IDCommand(comentario_texto_id, comentario_texto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOMENTARIO_TEXTO_IDAsDataTable(decimal comentario_texto_id)
		{
			return GetByCOMENTARIO_TEXTO_IDAsDataTable(comentario_texto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <param name="comentario_texto_idNull">true if the method ignores the comentario_texto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOMENTARIO_TEXTO_IDAsDataTable(decimal comentario_texto_id, bool comentario_texto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOMENTARIO_TEXTO_IDCommand(comentario_texto_id, comentario_texto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <param name="comentario_texto_idNull">true if the method ignores the comentario_texto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOMENTARIO_TEXTO_IDCommand(decimal comentario_texto_id, bool comentario_texto_idNull)
		{
			string whereSql = "";
			if(comentario_texto_idNull)
				whereSql += "COMENTARIO_TEXTO_ID IS NULL";
			else
				whereSql += "COMENTARIO_TEXTO_ID=" + _db.CreateSqlParameterName("COMENTARIO_TEXTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!comentario_texto_idNull)
				AddParameter(cmd, "COMENTARIO_TEXTO_ID", comentario_texto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects 
		/// by the <c>FK_COMENTARIOS_TRANS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public virtual COMENTARIOS_TRANSICIONESRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_TRANS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COMENTARIOS_TRANS_CASO</c> foreign key.
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
		/// Gets an array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects 
		/// by the <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public COMENTARIOS_TRANSICIONESRow[] GetByOPERACION_ID(decimal operacion_id)
		{
			return GetByOPERACION_ID(operacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects 
		/// by the <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <param name="operacion_idNull">true if the method ignores the operacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		public virtual COMENTARIOS_TRANSICIONESRow[] GetByOPERACION_ID(decimal operacion_id, bool operacion_idNull)
		{
			return MapRecords(CreateGetByOPERACION_IDCommand(operacion_id, operacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByOPERACION_IDAsDataTable(decimal operacion_id)
		{
			return GetByOPERACION_IDAsDataTable(operacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <param name="operacion_idNull">true if the method ignores the operacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByOPERACION_IDAsDataTable(decimal operacion_id, bool operacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByOPERACION_IDCommand(operacion_id, operacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <param name="operacion_idNull">true if the method ignores the operacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByOPERACION_IDCommand(decimal operacion_id, bool operacion_idNull)
		{
			string whereSql = "";
			if(operacion_idNull)
				whereSql += "OPERACION_ID IS NULL";
			else
				whereSql += "OPERACION_ID=" + _db.CreateSqlParameterName("OPERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!operacion_idNull)
				AddParameter(cmd, "OPERACION_ID", operacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>COMENTARIOS_TRANSICIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COMENTARIOS_TRANSICIONESRow"/> object to be inserted.</param>
		public virtual void Insert(COMENTARIOS_TRANSICIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.COMENTARIOS_TRANSICIONES (" +
				"ID, " +
				"CASO_ID, " +
				"FECHA, " +
				"COMENTARIO, " +
				"OPERACION_ID, " +
				"ORDEN, " +
				"TIPO, " +
				"COMENTARIO_TEXTO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("COMENTARIO") + ", " +
				_db.CreateSqlParameterName("OPERACION_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("TIPO") + ", " +
				_db.CreateSqlParameterName("COMENTARIO_TEXTO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			AddParameter(cmd, "OPERACION_ID",
				value.IsOPERACION_IDNull ? DBNull.Value : (object)value.OPERACION_ID);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "COMENTARIO_TEXTO_ID",
				value.IsCOMENTARIO_TEXTO_IDNull ? DBNull.Value : (object)value.COMENTARIO_TEXTO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>COMENTARIOS_TRANSICIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COMENTARIOS_TRANSICIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(COMENTARIOS_TRANSICIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.COMENTARIOS_TRANSICIONES SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"COMENTARIO=" + _db.CreateSqlParameterName("COMENTARIO") + ", " +
				"OPERACION_ID=" + _db.CreateSqlParameterName("OPERACION_ID") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"TIPO=" + _db.CreateSqlParameterName("TIPO") + ", " +
				"COMENTARIO_TEXTO_ID=" + _db.CreateSqlParameterName("COMENTARIO_TEXTO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "COMENTARIO", value.COMENTARIO);
			AddParameter(cmd, "OPERACION_ID",
				value.IsOPERACION_IDNull ? DBNull.Value : (object)value.OPERACION_ID);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "COMENTARIO_TEXTO_ID",
				value.IsCOMENTARIO_TEXTO_IDNull ? DBNull.Value : (object)value.COMENTARIO_TEXTO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>COMENTARIOS_TRANSICIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>COMENTARIOS_TRANSICIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>COMENTARIOS_TRANSICIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="COMENTARIOS_TRANSICIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(COMENTARIOS_TRANSICIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>COMENTARIOS_TRANSICIONES</c> table using
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
		/// Deletes records from the <c>COMENTARIOS_TRANSICIONES</c> table using the 
		/// <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOMENTARIO_TEXTO_ID(decimal comentario_texto_id)
		{
			return DeleteByCOMENTARIO_TEXTO_ID(comentario_texto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>COMENTARIOS_TRANSICIONES</c> table using the 
		/// <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <param name="comentario_texto_idNull">true if the method ignores the comentario_texto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOMENTARIO_TEXTO_ID(decimal comentario_texto_id, bool comentario_texto_idNull)
		{
			return CreateDeleteByCOMENTARIO_TEXTO_IDCommand(comentario_texto_id, comentario_texto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COMENTARIOS_TEXTO_ID</c> foreign key.
		/// </summary>
		/// <param name="comentario_texto_id">The <c>COMENTARIO_TEXTO_ID</c> column value.</param>
		/// <param name="comentario_texto_idNull">true if the method ignores the comentario_texto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOMENTARIO_TEXTO_IDCommand(decimal comentario_texto_id, bool comentario_texto_idNull)
		{
			string whereSql = "";
			if(comentario_texto_idNull)
				whereSql += "COMENTARIO_TEXTO_ID IS NULL";
			else
				whereSql += "COMENTARIO_TEXTO_ID=" + _db.CreateSqlParameterName("COMENTARIO_TEXTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!comentario_texto_idNull)
				AddParameter(cmd, "COMENTARIO_TEXTO_ID", comentario_texto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>COMENTARIOS_TRANSICIONES</c> table using the 
		/// <c>FK_COMENTARIOS_TRANS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COMENTARIOS_TRANS_CASO</c> foreign key.
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
		/// Deletes records from the <c>COMENTARIOS_TRANSICIONES</c> table using the 
		/// <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOPERACION_ID(decimal operacion_id)
		{
			return DeleteByOPERACION_ID(operacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>COMENTARIOS_TRANSICIONES</c> table using the 
		/// <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <param name="operacion_idNull">true if the method ignores the operacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOPERACION_ID(decimal operacion_id, bool operacion_idNull)
		{
			return CreateDeleteByOPERACION_IDCommand(operacion_id, operacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_COMENTARIOS_TRANS_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion_id">The <c>OPERACION_ID</c> column value.</param>
		/// <param name="operacion_idNull">true if the method ignores the operacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByOPERACION_IDCommand(decimal operacion_id, bool operacion_idNull)
		{
			string whereSql = "";
			if(operacion_idNull)
				whereSql += "OPERACION_ID IS NULL";
			else
				whereSql += "OPERACION_ID=" + _db.CreateSqlParameterName("OPERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!operacion_idNull)
				AddParameter(cmd, "OPERACION_ID", operacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>COMENTARIOS_TRANSICIONES</c> records that match the specified criteria.
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
		/// to delete <c>COMENTARIOS_TRANSICIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.COMENTARIOS_TRANSICIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>COMENTARIOS_TRANSICIONES</c> table.
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
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		protected COMENTARIOS_TRANSICIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		protected COMENTARIOS_TRANSICIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="COMENTARIOS_TRANSICIONESRow"/> objects.</returns>
		protected virtual COMENTARIOS_TRANSICIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int comentarioColumnIndex = reader.GetOrdinal("COMENTARIO");
			int operacion_idColumnIndex = reader.GetOrdinal("OPERACION_ID");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int comentario_texto_idColumnIndex = reader.GetOrdinal("COMENTARIO_TEXTO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					COMENTARIOS_TRANSICIONESRow record = new COMENTARIOS_TRANSICIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(comentarioColumnIndex))
						record.COMENTARIO = Convert.ToString(reader.GetValue(comentarioColumnIndex));
					if(!reader.IsDBNull(operacion_idColumnIndex))
						record.OPERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(operacion_idColumnIndex)), 9);
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Convert.ToString(reader.GetValue(tipoColumnIndex));
					if(!reader.IsDBNull(comentario_texto_idColumnIndex))
						record.COMENTARIO_TEXTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(comentario_texto_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (COMENTARIOS_TRANSICIONESRow[])(recordList.ToArray(typeof(COMENTARIOS_TRANSICIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="COMENTARIOS_TRANSICIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="COMENTARIOS_TRANSICIONESRow"/> object.</returns>
		protected virtual COMENTARIOS_TRANSICIONESRow MapRow(DataRow row)
		{
			COMENTARIOS_TRANSICIONESRow mappedObject = new COMENTARIOS_TRANSICIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "COMENTARIO"
			dataColumn = dataTable.Columns["COMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMENTARIO = (string)row[dataColumn];
			// Column "OPERACION_ID"
			dataColumn = dataTable.Columns["OPERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERACION_ID = (decimal)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (string)row[dataColumn];
			// Column "COMENTARIO_TEXTO_ID"
			dataColumn = dataTable.Columns["COMENTARIO_TEXTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMENTARIO_TEXTO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>COMENTARIOS_TRANSICIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "COMENTARIOS_TRANSICIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("COMENTARIO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("OPERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("COMENTARIO_TEXTO_ID", typeof(decimal));
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "COMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OPERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COMENTARIO_TEXTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of COMENTARIOS_TRANSICIONESCollection_Base class
}  // End of namespace
