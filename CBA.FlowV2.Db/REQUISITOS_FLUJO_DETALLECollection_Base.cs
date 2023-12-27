// <fileinfo name="REQUISITOS_FLUJO_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="REQUISITOS_FLUJO_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REQUISITOS_FLUJO_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REQUISITOS_FLUJO_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string REQUISITO_FLUJO_IDColumnName = "REQUISITO_FLUJO_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string USUARIO_CARGA_IDColumnName = "USUARIO_CARGA_ID";
		public const string FECHA_CARGAColumnName = "FECHA_CARGA";
		public const string ESTADOColumnName = "ESTADO";
		public const string FECHA_BORRADOColumnName = "FECHA_BORRADO";
		public const string USUARIO_BORRADO_IDColumnName = "USUARIO_BORRADO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REQUISITOS_FLUJO_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REQUISITOS_FLUJO_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REQUISITOS_FLUJO_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public virtual REQUISITOS_FLUJO_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REQUISITOS_FLUJO_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REQUISITOS_FLUJO_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REQUISITOS_FLUJO_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REQUISITOS_FLUJO_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REQUISITOS_FLUJO_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public REQUISITOS_FLUJO_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public virtual REQUISITOS_FLUJO_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REQUISITOS_FLUJO_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REQUISITOS_FLUJO_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REQUISITOS_FLUJO_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REQUISITOS_FLUJO_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REQUISITOS_FLUJO_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public virtual REQUISITOS_FLUJO_DETALLERow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_DET_CASO</c> foreign key.
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
		/// Gets an array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_REQ</c> foreign key.
		/// </summary>
		/// <param name="requisito_flujo_id">The <c>REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public virtual REQUISITOS_FLUJO_DETALLERow[] GetByREQUISITO_FLUJO_ID(decimal requisito_flujo_id)
		{
			return MapRecords(CreateGetByREQUISITO_FLUJO_IDCommand(requisito_flujo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_REQ</c> foreign key.
		/// </summary>
		/// <param name="requisito_flujo_id">The <c>REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREQUISITO_FLUJO_IDAsDataTable(decimal requisito_flujo_id)
		{
			return MapRecordsToDataTable(CreateGetByREQUISITO_FLUJO_IDCommand(requisito_flujo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_DET_REQ</c> foreign key.
		/// </summary>
		/// <param name="requisito_flujo_id">The <c>REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREQUISITO_FLUJO_IDCommand(decimal requisito_flujo_id)
		{
			string whereSql = "";
			whereSql += "REQUISITO_FLUJO_ID=" + _db.CreateSqlParameterName("REQUISITO_FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "REQUISITO_FLUJO_ID", requisito_flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public REQUISITOS_FLUJO_DETALLERow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public virtual REQUISITOS_FLUJO_DETALLERow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_IDAsDataTable(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_U_CAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		public virtual REQUISITOS_FLUJO_DETALLERow[] GetByUSUARIO_CARGA_ID(decimal usuario_carga_id)
		{
			return MapRecords(CreateGetByUSUARIO_CARGA_IDCommand(usuario_carga_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_DET_U_CAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CARGA_IDAsDataTable(decimal usuario_carga_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CARGA_IDCommand(usuario_carga_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_DET_U_CAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CARGA_IDCommand(decimal usuario_carga_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CARGA_ID=" + _db.CreateSqlParameterName("USUARIO_CARGA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CARGA_ID", usuario_carga_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>REQUISITOS_FLUJO_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REQUISITOS_FLUJO_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(REQUISITOS_FLUJO_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REQUISITOS_FLUJO_DETALLE (" +
				"ID, " +
				"REQUISITO_FLUJO_ID, " +
				"CASO_ID, " +
				"USUARIO_CARGA_ID, " +
				"FECHA_CARGA, " +
				"ESTADO, " +
				"FECHA_BORRADO, " +
				"USUARIO_BORRADO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("REQUISITO_FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CARGA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CARGA") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "REQUISITO_FLUJO_ID", value.REQUISITO_FLUJO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "USUARIO_CARGA_ID", value.USUARIO_CARGA_ID);
			AddParameter(cmd, "FECHA_CARGA", value.FECHA_CARGA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REQUISITOS_FLUJO_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REQUISITOS_FLUJO_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REQUISITOS_FLUJO_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.REQUISITOS_FLUJO_DETALLE SET " +
				"REQUISITO_FLUJO_ID=" + _db.CreateSqlParameterName("REQUISITO_FLUJO_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"USUARIO_CARGA_ID=" + _db.CreateSqlParameterName("USUARIO_CARGA_ID") + ", " +
				"FECHA_CARGA=" + _db.CreateSqlParameterName("FECHA_CARGA") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"FECHA_BORRADO=" + _db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				"USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "REQUISITO_FLUJO_ID", value.REQUISITO_FLUJO_ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "USUARIO_CARGA_ID", value.USUARIO_CARGA_ID);
			AddParameter(cmd, "FECHA_CARGA", value.FECHA_CARGA);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REQUISITOS_FLUJO_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REQUISITOS_FLUJO_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REQUISITOS_FLUJO_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REQUISITOS_FLUJO_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REQUISITOS_FLUJO_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REQUISITOS_FLUJO_DETALLE</c> table using
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
		/// Deletes records from the <c>REQUISITOS_FLUJO_DETALLE</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_DET_CASO</c> foreign key.
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
		/// Deletes records from the <c>REQUISITOS_FLUJO_DETALLE</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_DET_REQ</c> foreign key.
		/// </summary>
		/// <param name="requisito_flujo_id">The <c>REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREQUISITO_FLUJO_ID(decimal requisito_flujo_id)
		{
			return CreateDeleteByREQUISITO_FLUJO_IDCommand(requisito_flujo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_DET_REQ</c> foreign key.
		/// </summary>
		/// <param name="requisito_flujo_id">The <c>REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREQUISITO_FLUJO_IDCommand(decimal requisito_flujo_id)
		{
			string whereSql = "";
			whereSql += "REQUISITO_FLUJO_ID=" + _db.CreateSqlParameterName("REQUISITO_FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "REQUISITO_FLUJO_ID", requisito_flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO_DETALLE</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return DeleteByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO_DETALLE</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return CreateDeleteByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_DET_U_BOR</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO_DETALLE</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_DET_U_CAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CARGA_ID(decimal usuario_carga_id)
		{
			return CreateDeleteByUSUARIO_CARGA_IDCommand(usuario_carga_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_DET_U_CAR</c> foreign key.
		/// </summary>
		/// <param name="usuario_carga_id">The <c>USUARIO_CARGA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CARGA_IDCommand(decimal usuario_carga_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CARGA_ID=" + _db.CreateSqlParameterName("USUARIO_CARGA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CARGA_ID", usuario_carga_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>REQUISITOS_FLUJO_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>REQUISITOS_FLUJO_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REQUISITOS_FLUJO_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REQUISITOS_FLUJO_DETALLE</c> table.
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		protected REQUISITOS_FLUJO_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		protected REQUISITOS_FLUJO_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJO_DETALLERow"/> objects.</returns>
		protected virtual REQUISITOS_FLUJO_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int requisito_flujo_idColumnIndex = reader.GetOrdinal("REQUISITO_FLUJO_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int usuario_carga_idColumnIndex = reader.GetOrdinal("USUARIO_CARGA_ID");
			int fecha_cargaColumnIndex = reader.GetOrdinal("FECHA_CARGA");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int fecha_borradoColumnIndex = reader.GetOrdinal("FECHA_BORRADO");
			int usuario_borrado_idColumnIndex = reader.GetOrdinal("USUARIO_BORRADO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REQUISITOS_FLUJO_DETALLERow record = new REQUISITOS_FLUJO_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.REQUISITO_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(requisito_flujo_idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.USUARIO_CARGA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_carga_idColumnIndex)), 9);
					record.FECHA_CARGA = Convert.ToDateTime(reader.GetValue(fecha_cargaColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(fecha_borradoColumnIndex))
						record.FECHA_BORRADO = Convert.ToDateTime(reader.GetValue(fecha_borradoColumnIndex));
					if(!reader.IsDBNull(usuario_borrado_idColumnIndex))
						record.USUARIO_BORRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_borrado_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REQUISITOS_FLUJO_DETALLERow[])(recordList.ToArray(typeof(REQUISITOS_FLUJO_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REQUISITOS_FLUJO_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REQUISITOS_FLUJO_DETALLERow"/> object.</returns>
		protected virtual REQUISITOS_FLUJO_DETALLERow MapRow(DataRow row)
		{
			REQUISITOS_FLUJO_DETALLERow mappedObject = new REQUISITOS_FLUJO_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "REQUISITO_FLUJO_ID"
			dataColumn = dataTable.Columns["REQUISITO_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REQUISITO_FLUJO_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CARGA_ID"
			dataColumn = dataTable.Columns["USUARIO_CARGA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CARGA_ID = (decimal)row[dataColumn];
			// Column "FECHA_CARGA"
			dataColumn = dataTable.Columns["FECHA_CARGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CARGA = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "FECHA_BORRADO"
			dataColumn = dataTable.Columns["FECHA_BORRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_BORRADO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_BORRADO_ID"
			dataColumn = dataTable.Columns["USUARIO_BORRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_BORRADO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REQUISITOS_FLUJO_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REQUISITOS_FLUJO_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REQUISITO_FLUJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CARGA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CARGA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_BORRADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_BORRADO_ID", typeof(decimal));
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

				case "REQUISITO_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CARGA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CARGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_BORRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_BORRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REQUISITOS_FLUJO_DETALLECollection_Base class
}  // End of namespace
