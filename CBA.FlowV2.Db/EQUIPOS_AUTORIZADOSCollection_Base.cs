// <fileinfo name="EQUIPOS_AUTORIZADOSCollection_Base.cs">
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
	/// The base class for <see cref="EQUIPOS_AUTORIZADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EQUIPOS_AUTORIZADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EQUIPOS_AUTORIZADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NUMERO_FACTURAColumnName = "NUMERO_FACTURA";
		public const string ASAMARColumnName = "ASAMAR";
		public const string DESPACHOColumnName = "DESPACHO";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string CONFIRMADOColumnName = "CONFIRMADO";
		public const string PERSONA_IDColumnName = "PERSONA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EQUIPOS_AUTORIZADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EQUIPOS_AUTORIZADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EQUIPOS_AUTORIZADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EQUIPOS_AUTORIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EQUIPOS_AUTORIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EQUIPOS_AUTORIZADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EQUIPOS_AUTORIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EQUIPOS_AUTORIZADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EQUIPOS_AUTORIZADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EQUIPOS_AUTORIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EQUIPOS_AUTORIZADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EQUIPOS_AUTORIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EQUIPOS_AUTORIZADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EQUIPOS_AUTORIZADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOSRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects 
		/// by the <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOSRow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>EQUIPOS_AUTORIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOSRow"/> object to be inserted.</param>
		public virtual void Insert(EQUIPOS_AUTORIZADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EQUIPOS_AUTORIZADOS (" +
				"ID, " +
				"NUMERO_FACTURA, " +
				"ASAMAR, " +
				"DESPACHO, " +
				"USUARIO_ID, " +
				"FECHA, " +
				"CONFIRMADO, " +
				"PERSONA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_FACTURA") + ", " +
				_db.CreateSqlParameterName("ASAMAR") + ", " +
				_db.CreateSqlParameterName("DESPACHO") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CONFIRMADO") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NUMERO_FACTURA", value.NUMERO_FACTURA);
			AddParameter(cmd, "ASAMAR", value.ASAMAR);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EQUIPOS_AUTORIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EQUIPOS_AUTORIZADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.EQUIPOS_AUTORIZADOS SET " +
				"NUMERO_FACTURA=" + _db.CreateSqlParameterName("NUMERO_FACTURA") + ", " +
				"ASAMAR=" + _db.CreateSqlParameterName("ASAMAR") + ", " +
				"DESPACHO=" + _db.CreateSqlParameterName("DESPACHO") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CONFIRMADO=" + _db.CreateSqlParameterName("CONFIRMADO") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NUMERO_FACTURA", value.NUMERO_FACTURA);
			AddParameter(cmd, "ASAMAR", value.ASAMAR);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EQUIPOS_AUTORIZADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EQUIPOS_AUTORIZADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EQUIPOS_AUTORIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EQUIPOS_AUTORIZADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EQUIPOS_AUTORIZADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EQUIPOS_AUTORIZADOS</c> table using
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
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EQUIPOS_AUTORIZADOS</c> table using the 
		/// <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id, usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EQUIPOS_AUTOR_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>EQUIPOS_AUTORIZADOS</c> records that match the specified criteria.
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
		/// to delete <c>EQUIPOS_AUTORIZADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EQUIPOS_AUTORIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EQUIPOS_AUTORIZADOS</c> table.
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOSRow"/> objects.</returns>
		protected virtual EQUIPOS_AUTORIZADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int numero_facturaColumnIndex = reader.GetOrdinal("NUMERO_FACTURA");
			int asamarColumnIndex = reader.GetOrdinal("ASAMAR");
			int despachoColumnIndex = reader.GetOrdinal("DESPACHO");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int confirmadoColumnIndex = reader.GetOrdinal("CONFIRMADO");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EQUIPOS_AUTORIZADOSRow record = new EQUIPOS_AUTORIZADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_facturaColumnIndex))
						record.NUMERO_FACTURA = Convert.ToString(reader.GetValue(numero_facturaColumnIndex));
					if(!reader.IsDBNull(asamarColumnIndex))
						record.ASAMAR = Convert.ToString(reader.GetValue(asamarColumnIndex));
					if(!reader.IsDBNull(despachoColumnIndex))
						record.DESPACHO = Convert.ToString(reader.GetValue(despachoColumnIndex));
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(confirmadoColumnIndex))
						record.CONFIRMADO = Convert.ToString(reader.GetValue(confirmadoColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EQUIPOS_AUTORIZADOSRow[])(recordList.ToArray(typeof(EQUIPOS_AUTORIZADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EQUIPOS_AUTORIZADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EQUIPOS_AUTORIZADOSRow"/> object.</returns>
		protected virtual EQUIPOS_AUTORIZADOSRow MapRow(DataRow row)
		{
			EQUIPOS_AUTORIZADOSRow mappedObject = new EQUIPOS_AUTORIZADOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NUMERO_FACTURA"
			dataColumn = dataTable.Columns["NUMERO_FACTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_FACTURA = (string)row[dataColumn];
			// Column "ASAMAR"
			dataColumn = dataTable.Columns["ASAMAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ASAMAR = (string)row[dataColumn];
			// Column "DESPACHO"
			dataColumn = dataTable.Columns["DESPACHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CONFIRMADO"
			dataColumn = dataTable.Columns["CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONFIRMADO = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EQUIPOS_AUTORIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EQUIPOS_AUTORIZADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_FACTURA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("ASAMAR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("DESPACHO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
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

				case "NUMERO_FACTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ASAMAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EQUIPOS_AUTORIZADOSCollection_Base class
}  // End of namespace
