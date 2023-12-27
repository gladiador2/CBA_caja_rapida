// <fileinfo name="ARTICULOS_FINANCIEROS_RANGOSCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_FINANCIEROS_RANGOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_FINANCIEROS_RANGOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_FINANCIEROS_RANGOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULO_FINANCIERO_IDColumnName = "ARTICULO_FINANCIERO_ID";
		public const string TIPO_ARTICULO_FINANC_RANGO_IDColumnName = "TIPO_ARTICULO_FINANC_RANGO_ID";
		public const string DIAS_DESDEColumnName = "DIAS_DESDE";
		public const string MONTO_DESDEColumnName = "MONTO_DESDE";
		public const string PORCENTAJEColumnName = "PORCENTAJE";
		public const string MONTOColumnName = "MONTO";
		public const string ESTADOColumnName = "ESTADO";
		public const string CONSIDERAR_PLAZOColumnName = "CONSIDERAR_PLAZO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_FINANCIEROS_RANGOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_FINANCIEROS_RANGOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROS_RANGOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_FINANCIEROS_RANGOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_FINANCIEROS_RANGOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		public ARTICULOS_FINANCIEROS_RANGOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROS_RANGOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_FINANCIEROS_RANGOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_FINANCIEROS_RANGOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_FINANCIEROS_RANGOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects 
		/// by the <c>PK_ARTICULOS_FINAN_RANGOS_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_financiero_id">The <c>ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROS_RANGOSRow[] GetByARTICULO_FINANCIERO_ID(decimal articulo_financiero_id)
		{
			return MapRecords(CreateGetByARTICULO_FINANCIERO_IDCommand(articulo_financiero_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>PK_ARTICULOS_FINAN_RANGOS_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_financiero_id">The <c>ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_FINANCIERO_IDAsDataTable(decimal articulo_financiero_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_FINANCIERO_IDCommand(articulo_financiero_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>PK_ARTICULOS_FINAN_RANGOS_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_financiero_id">The <c>ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_FINANCIERO_IDCommand(decimal articulo_financiero_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_FINANCIERO_ID=" + _db.CreateSqlParameterName("ARTICULO_FINANCIERO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_FINANCIERO_ID", articulo_financiero_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects 
		/// by the <c>PK_ARTICULOS_FINAN_RANGOS_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financ_rango_id">The <c>TIPO_ARTICULO_FINANC_RANGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		public virtual ARTICULOS_FINANCIEROS_RANGOSRow[] GetByTIPO_ARTICULO_FINANC_RANGO_ID(decimal tipo_articulo_financ_rango_id)
		{
			return MapRecords(CreateGetByTIPO_ARTICULO_FINANC_RANGO_IDCommand(tipo_articulo_financ_rango_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>PK_ARTICULOS_FINAN_RANGOS_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financ_rango_id">The <c>TIPO_ARTICULO_FINANC_RANGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_ARTICULO_FINANC_RANGO_IDAsDataTable(decimal tipo_articulo_financ_rango_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_ARTICULO_FINANC_RANGO_IDCommand(tipo_articulo_financ_rango_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>PK_ARTICULOS_FINAN_RANGOS_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financ_rango_id">The <c>TIPO_ARTICULO_FINANC_RANGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_ARTICULO_FINANC_RANGO_IDCommand(decimal tipo_articulo_financ_rango_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ARTICULO_FINANC_RANGO_ID=" + _db.CreateSqlParameterName("TIPO_ARTICULO_FINANC_RANGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_ARTICULO_FINANC_RANGO_ID", tipo_articulo_financ_rango_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_FINANCIEROS_RANGOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_FINANCIEROS_RANGOS (" +
				"ID, " +
				"ARTICULO_FINANCIERO_ID, " +
				"TIPO_ARTICULO_FINANC_RANGO_ID, " +
				"DIAS_DESDE, " +
				"MONTO_DESDE, " +
				"PORCENTAJE, " +
				"MONTO, " +
				"ESTADO, " +
				"CONSIDERAR_PLAZO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_FINANCIERO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_ARTICULO_FINANC_RANGO_ID") + ", " +
				_db.CreateSqlParameterName("DIAS_DESDE") + ", " +
				_db.CreateSqlParameterName("MONTO_DESDE") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CONSIDERAR_PLAZO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULO_FINANCIERO_ID", value.ARTICULO_FINANCIERO_ID);
			AddParameter(cmd, "TIPO_ARTICULO_FINANC_RANGO_ID", value.TIPO_ARTICULO_FINANC_RANGO_ID);
			AddParameter(cmd, "DIAS_DESDE", value.DIAS_DESDE);
			AddParameter(cmd, "MONTO_DESDE", value.MONTO_DESDE);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CONSIDERAR_PLAZO", value.CONSIDERAR_PLAZO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_FINANCIEROS_RANGOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_FINANCIEROS_RANGOS SET " +
				"ARTICULO_FINANCIERO_ID=" + _db.CreateSqlParameterName("ARTICULO_FINANCIERO_ID") + ", " +
				"TIPO_ARTICULO_FINANC_RANGO_ID=" + _db.CreateSqlParameterName("TIPO_ARTICULO_FINANC_RANGO_ID") + ", " +
				"DIAS_DESDE=" + _db.CreateSqlParameterName("DIAS_DESDE") + ", " +
				"MONTO_DESDE=" + _db.CreateSqlParameterName("MONTO_DESDE") + ", " +
				"PORCENTAJE=" + _db.CreateSqlParameterName("PORCENTAJE") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CONSIDERAR_PLAZO=" + _db.CreateSqlParameterName("CONSIDERAR_PLAZO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULO_FINANCIERO_ID", value.ARTICULO_FINANCIERO_ID);
			AddParameter(cmd, "TIPO_ARTICULO_FINANC_RANGO_ID", value.TIPO_ARTICULO_FINANC_RANGO_ID);
			AddParameter(cmd, "DIAS_DESDE", value.DIAS_DESDE);
			AddParameter(cmd, "MONTO_DESDE", value.MONTO_DESDE);
			AddParameter(cmd, "PORCENTAJE",
				value.IsPORCENTAJENull ? DBNull.Value : (object)value.PORCENTAJE);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CONSIDERAR_PLAZO", value.CONSIDERAR_PLAZO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_FINANCIEROS_RANGOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table using
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
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table using the 
		/// <c>PK_ARTICULOS_FINAN_RANGOS_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_financiero_id">The <c>ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_FINANCIERO_ID(decimal articulo_financiero_id)
		{
			return CreateDeleteByARTICULO_FINANCIERO_IDCommand(articulo_financiero_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>PK_ARTICULOS_FINAN_RANGOS_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_financiero_id">The <c>ARTICULO_FINANCIERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_FINANCIERO_IDCommand(decimal articulo_financiero_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_FINANCIERO_ID=" + _db.CreateSqlParameterName("ARTICULO_FINANCIERO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_FINANCIERO_ID", articulo_financiero_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table using the 
		/// <c>PK_ARTICULOS_FINAN_RANGOS_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financ_rango_id">The <c>TIPO_ARTICULO_FINANC_RANGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ARTICULO_FINANC_RANGO_ID(decimal tipo_articulo_financ_rango_id)
		{
			return CreateDeleteByTIPO_ARTICULO_FINANC_RANGO_IDCommand(tipo_articulo_financ_rango_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>PK_ARTICULOS_FINAN_RANGOS_TIP</c> foreign key.
		/// </summary>
		/// <param name="tipo_articulo_financ_rango_id">The <c>TIPO_ARTICULO_FINANC_RANGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_ARTICULO_FINANC_RANGO_IDCommand(decimal tipo_articulo_financ_rango_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ARTICULO_FINANC_RANGO_ID=" + _db.CreateSqlParameterName("TIPO_ARTICULO_FINANC_RANGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_ARTICULO_FINANC_RANGO_ID", tipo_articulo_financ_rango_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_FINANCIEROS_RANGOS</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_FINANCIEROS_RANGOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_FINANCIEROS_RANGOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		protected ARTICULOS_FINANCIEROS_RANGOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		protected ARTICULOS_FINANCIEROS_RANGOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> objects.</returns>
		protected virtual ARTICULOS_FINANCIEROS_RANGOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulo_financiero_idColumnIndex = reader.GetOrdinal("ARTICULO_FINANCIERO_ID");
			int tipo_articulo_financ_rango_idColumnIndex = reader.GetOrdinal("TIPO_ARTICULO_FINANC_RANGO_ID");
			int dias_desdeColumnIndex = reader.GetOrdinal("DIAS_DESDE");
			int monto_desdeColumnIndex = reader.GetOrdinal("MONTO_DESDE");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int considerar_plazoColumnIndex = reader.GetOrdinal("CONSIDERAR_PLAZO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_FINANCIEROS_RANGOSRow record = new ARTICULOS_FINANCIEROS_RANGOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULO_FINANCIERO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_financiero_idColumnIndex)), 9);
					record.TIPO_ARTICULO_FINANC_RANGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_articulo_financ_rango_idColumnIndex)), 9);
					record.DIAS_DESDE = Math.Round(Convert.ToDecimal(reader.GetValue(dias_desdeColumnIndex)), 9);
					record.MONTO_DESDE = Math.Round(Convert.ToDecimal(reader.GetValue(monto_desdeColumnIndex)), 9);
					if(!reader.IsDBNull(porcentajeColumnIndex))
						record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.CONSIDERAR_PLAZO = Convert.ToString(reader.GetValue(considerar_plazoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_FINANCIEROS_RANGOSRow[])(recordList.ToArray(typeof(ARTICULOS_FINANCIEROS_RANGOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_FINANCIEROS_RANGOSRow"/> object.</returns>
		protected virtual ARTICULOS_FINANCIEROS_RANGOSRow MapRow(DataRow row)
		{
			ARTICULOS_FINANCIEROS_RANGOSRow mappedObject = new ARTICULOS_FINANCIEROS_RANGOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULO_FINANCIERO_ID"
			dataColumn = dataTable.Columns["ARTICULO_FINANCIERO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_FINANCIERO_ID = (decimal)row[dataColumn];
			// Column "TIPO_ARTICULO_FINANC_RANGO_ID"
			dataColumn = dataTable.Columns["TIPO_ARTICULO_FINANC_RANGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ARTICULO_FINANC_RANGO_ID = (decimal)row[dataColumn];
			// Column "DIAS_DESDE"
			dataColumn = dataTable.Columns["DIAS_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_DESDE = (decimal)row[dataColumn];
			// Column "MONTO_DESDE"
			dataColumn = dataTable.Columns["MONTO_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESDE = (decimal)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CONSIDERAR_PLAZO"
			dataColumn = dataTable.Columns["CONSIDERAR_PLAZO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIDERAR_PLAZO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_FINANCIEROS_RANGOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_FINANCIEROS_RANGOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_FINANCIERO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_ARTICULO_FINANC_RANGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIAS_DESDE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESDE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONSIDERAR_PLAZO", typeof(string));
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

				case "ARTICULO_FINANCIERO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ARTICULO_FINANC_RANGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIAS_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONSIDERAR_PLAZO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_FINANCIEROS_RANGOSCollection_Base class
}  // End of namespace
