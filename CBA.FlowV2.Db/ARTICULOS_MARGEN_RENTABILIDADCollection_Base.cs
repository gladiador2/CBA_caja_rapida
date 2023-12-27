// <fileinfo name="ARTICULOS_MARGEN_RENTABILIDADCollection_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_MARGEN_RENTABILIDADCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ARTICULOS_MARGEN_RENTABILIDADCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_MARGEN_RENTABILIDADCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULOS_IDColumnName = "ARTICULOS_ID";
		public const string LISTA_PRECIOS_IDColumnName = "LISTA_PRECIOS_ID";
		public const string SUCURSALES_IDColumnName = "SUCURSALES_ID";
		public const string PORCENTAJEColumnName = "PORCENTAJE";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_MARGEN_RENTABILIDADCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ARTICULOS_MARGEN_RENTABILIDADCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		public virtual ARTICULOS_MARGEN_RENTABILIDADRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ARTICULOS_MARGEN_RENTABILIDADRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ARTICULOS_MARGEN_RENTABILIDADRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		public ARTICULOS_MARGEN_RENTABILIDADRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects that 
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
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		public virtual ARTICULOS_MARGEN_RENTABILIDADRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ARTICULOS_MARGEN_RENTABILIDAD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ARTICULOS_MARGEN_RENTABILIDADRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ARTICULOS_MARGEN_RENTABILIDADRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects 
		/// by the <c>ARTICULOS_MARGEN_ARTICULOS_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_id">The <c>ARTICULOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		public virtual ARTICULOS_MARGEN_RENTABILIDADRow[] GetByARTICULOS_ID(decimal articulos_id)
		{
			return MapRecords(CreateGetByARTICULOS_IDCommand(articulos_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>ARTICULOS_MARGEN_ARTICULOS_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_id">The <c>ARTICULOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULOS_IDAsDataTable(decimal articulos_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULOS_IDCommand(articulos_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>ARTICULOS_MARGEN_ARTICULOS_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_id">The <c>ARTICULOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULOS_IDCommand(decimal articulos_id)
		{
			string whereSql = "";
			whereSql += "ARTICULOS_ID=" + _db.CreateSqlParameterName("ARTICULOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULOS_ID", articulos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects 
		/// by the <c>ARTICULOS_MARGEN_LIST_PREC_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		public virtual ARTICULOS_MARGEN_RENTABILIDADRow[] GetByLISTA_PRECIOS_ID(decimal lista_precios_id)
		{
			return MapRecords(CreateGetByLISTA_PRECIOS_IDCommand(lista_precios_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>ARTICULOS_MARGEN_LIST_PREC_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIOS_IDAsDataTable(decimal lista_precios_id)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIOS_IDCommand(lista_precios_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>ARTICULOS_MARGEN_LIST_PREC_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIOS_IDCommand(decimal lista_precios_id)
		{
			string whereSql = "";
			whereSql += "LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LISTA_PRECIOS_ID", lista_precios_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects 
		/// by the <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		public ARTICULOS_MARGEN_RENTABILIDADRow[] GetBySUCURSALES_ID(decimal sucursales_id)
		{
			return GetBySUCURSALES_ID(sucursales_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects 
		/// by the <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <param name="sucursales_idNull">true if the method ignores the sucursales_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		public virtual ARTICULOS_MARGEN_RENTABILIDADRow[] GetBySUCURSALES_ID(decimal sucursales_id, bool sucursales_idNull)
		{
			return MapRecords(CreateGetBySUCURSALES_IDCommand(sucursales_id, sucursales_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSALES_IDAsDataTable(decimal sucursales_id)
		{
			return GetBySUCURSALES_IDAsDataTable(sucursales_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <param name="sucursales_idNull">true if the method ignores the sucursales_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSALES_IDAsDataTable(decimal sucursales_id, bool sucursales_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSALES_IDCommand(sucursales_id, sucursales_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <param name="sucursales_idNull">true if the method ignores the sucursales_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSALES_IDCommand(decimal sucursales_id, bool sucursales_idNull)
		{
			string whereSql = "";
			if(sucursales_idNull)
				whereSql += "SUCURSALES_ID IS NULL";
			else
				whereSql += "SUCURSALES_ID=" + _db.CreateSqlParameterName("SUCURSALES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursales_idNull)
				AddParameter(cmd, "SUCURSALES_ID", sucursales_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> object to be inserted.</param>
		public virtual void Insert(ARTICULOS_MARGEN_RENTABILIDADRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ARTICULOS_MARGEN_RENTABILIDAD (" +
				"ID, " +
				"ARTICULOS_ID, " +
				"LISTA_PRECIOS_ID, " +
				"SUCURSALES_ID, " +
				"PORCENTAJE, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"FECHA_CREACION, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULOS_ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIOS_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSALES_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULOS_ID", value.ARTICULOS_ID);
			AddParameter(cmd, "LISTA_PRECIOS_ID", value.LISTA_PRECIOS_ID);
			AddParameter(cmd, "SUCURSALES_ID",
				value.IsSUCURSALES_IDNull ? DBNull.Value : (object)value.SUCURSALES_ID);
			AddParameter(cmd, "PORCENTAJE", value.PORCENTAJE);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "FECHA_CREACION",
				value.IsFECHA_CREACIONNull ? DBNull.Value : (object)value.FECHA_CREACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ARTICULOS_MARGEN_RENTABILIDADRow value)
		{
			
			string sqlStr = "UPDATE TRC.ARTICULOS_MARGEN_RENTABILIDAD SET " +
				"ARTICULOS_ID=" + _db.CreateSqlParameterName("ARTICULOS_ID") + ", " +
				"LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID") + ", " +
				"SUCURSALES_ID=" + _db.CreateSqlParameterName("SUCURSALES_ID") + ", " +
				"PORCENTAJE=" + _db.CreateSqlParameterName("PORCENTAJE") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULOS_ID", value.ARTICULOS_ID);
			AddParameter(cmd, "LISTA_PRECIOS_ID", value.LISTA_PRECIOS_ID);
			AddParameter(cmd, "SUCURSALES_ID",
				value.IsSUCURSALES_IDNull ? DBNull.Value : (object)value.SUCURSALES_ID);
			AddParameter(cmd, "PORCENTAJE", value.PORCENTAJE);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "FECHA_CREACION",
				value.IsFECHA_CREACIONNull ? DBNull.Value : (object)value.FECHA_CREACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ARTICULOS_MARGEN_RENTABILIDADRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table using
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
		/// Deletes records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table using the 
		/// <c>ARTICULOS_MARGEN_ARTICULOS_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_id">The <c>ARTICULOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULOS_ID(decimal articulos_id)
		{
			return CreateDeleteByARTICULOS_IDCommand(articulos_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>ARTICULOS_MARGEN_ARTICULOS_ID</c> foreign key.
		/// </summary>
		/// <param name="articulos_id">The <c>ARTICULOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULOS_IDCommand(decimal articulos_id)
		{
			string whereSql = "";
			whereSql += "ARTICULOS_ID=" + _db.CreateSqlParameterName("ARTICULOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULOS_ID", articulos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table using the 
		/// <c>ARTICULOS_MARGEN_LIST_PREC_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIOS_ID(decimal lista_precios_id)
		{
			return CreateDeleteByLISTA_PRECIOS_IDCommand(lista_precios_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>ARTICULOS_MARGEN_LIST_PREC_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIOS_IDCommand(decimal lista_precios_id)
		{
			string whereSql = "";
			whereSql += "LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LISTA_PRECIOS_ID", lista_precios_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table using the 
		/// <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSALES_ID(decimal sucursales_id)
		{
			return DeleteBySUCURSALES_ID(sucursales_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table using the 
		/// <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <param name="sucursales_idNull">true if the method ignores the sucursales_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSALES_ID(decimal sucursales_id, bool sucursales_idNull)
		{
			return CreateDeleteBySUCURSALES_IDCommand(sucursales_id, sucursales_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>ARTICULOS_MARGEN_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursales_id">The <c>SUCURSALES_ID</c> column value.</param>
		/// <param name="sucursales_idNull">true if the method ignores the sucursales_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSALES_IDCommand(decimal sucursales_id, bool sucursales_idNull)
		{
			string whereSql = "";
			if(sucursales_idNull)
				whereSql += "SUCURSALES_ID IS NULL";
			else
				whereSql += "SUCURSALES_ID=" + _db.CreateSqlParameterName("SUCURSALES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursales_idNull)
				AddParameter(cmd, "SUCURSALES_ID", sucursales_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ARTICULOS_MARGEN_RENTABILIDAD</c> records that match the specified criteria.
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
		/// to delete <c>ARTICULOS_MARGEN_RENTABILIDAD</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ARTICULOS_MARGEN_RENTABILIDAD";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
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
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		protected ARTICULOS_MARGEN_RENTABILIDADRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		protected ARTICULOS_MARGEN_RENTABILIDADRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> objects.</returns>
		protected virtual ARTICULOS_MARGEN_RENTABILIDADRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulos_idColumnIndex = reader.GetOrdinal("ARTICULOS_ID");
			int lista_precios_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_ID");
			int sucursales_idColumnIndex = reader.GetOrdinal("SUCURSALES_ID");
			int porcentajeColumnIndex = reader.GetOrdinal("PORCENTAJE");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ARTICULOS_MARGEN_RENTABILIDADRow record = new ARTICULOS_MARGEN_RENTABILIDADRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulos_idColumnIndex)), 9);
					record.LISTA_PRECIOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursales_idColumnIndex))
						record.SUCURSALES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursales_idColumnIndex)), 9);
					record.PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(fecha_creacionColumnIndex))
						record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ARTICULOS_MARGEN_RENTABILIDADRow[])(recordList.ToArray(typeof(ARTICULOS_MARGEN_RENTABILIDADRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ARTICULOS_MARGEN_RENTABILIDADRow"/> object.</returns>
		protected virtual ARTICULOS_MARGEN_RENTABILIDADRow MapRow(DataRow row)
		{
			ARTICULOS_MARGEN_RENTABILIDADRow mappedObject = new ARTICULOS_MARGEN_RENTABILIDADRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULOS_ID"
			dataColumn = dataTable.Columns["ARTICULOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULOS_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_ID = (decimal)row[dataColumn];
			// Column "SUCURSALES_ID"
			dataColumn = dataTable.Columns["SUCURSALES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSALES_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE"
			dataColumn = dataTable.Columns["PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ARTICULOS_MARGEN_RENTABILIDAD</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ARTICULOS_MARGEN_RENTABILIDAD";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSALES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "ARTICULOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSALES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ARTICULOS_MARGEN_RENTABILIDADCollection_Base class
}  // End of namespace
