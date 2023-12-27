// <fileinfo name="NOTA_DEBITO_PROVEEDOR_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="NOTA_DEBITO_PROVEEDOR_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="NOTA_DEBITO_PROVEEDOR_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTA_DEBITO_PROVEEDOR_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOTA_DEBITO_PROVEEDOR_IDColumnName = "NOTA_DEBITO_PROVEEDOR_ID";
		public const string FACTURA_RELACIONADA_IDColumnName = "FACTURA_RELACIONADA_ID";
		public const string MONTOColumnName = "MONTO";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string MONTO_IMPUESTOColumnName = "MONTO_IMPUESTO";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTA_DEBITO_PROVEEDOR_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public NOTA_DEBITO_PROVEEDOR_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public NOTA_DEBITO_PROVEEDOR_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			NOTA_DEBITO_PROVEEDOR_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.NOTA_DEBITO_PROVEEDOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual NOTA_DEBITO_PROVEEDOR_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			NOTA_DEBITO_PROVEEDOR_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_IDAsDataTable(decimal activo_id, bool activo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetByFACTURA_RELACIONADA_ID(decimal factura_relacionada_id)
		{
			return GetByFACTURA_RELACIONADA_ID(factura_relacionada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <param name="factura_relacionada_idNull">true if the method ignores the factura_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetByFACTURA_RELACIONADA_ID(decimal factura_relacionada_id, bool factura_relacionada_idNull)
		{
			return MapRecords(CreateGetByFACTURA_RELACIONADA_IDCommand(factura_relacionada_id, factura_relacionada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFACTURA_RELACIONADA_IDAsDataTable(decimal factura_relacionada_id)
		{
			return GetByFACTURA_RELACIONADA_IDAsDataTable(factura_relacionada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <param name="factura_relacionada_idNull">true if the method ignores the factura_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFACTURA_RELACIONADA_IDAsDataTable(decimal factura_relacionada_id, bool factura_relacionada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFACTURA_RELACIONADA_IDCommand(factura_relacionada_id, factura_relacionada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <param name="factura_relacionada_idNull">true if the method ignores the factura_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFACTURA_RELACIONADA_IDCommand(decimal factura_relacionada_id, bool factura_relacionada_idNull)
		{
			string whereSql = "";
			if(factura_relacionada_idNull)
				whereSql += "FACTURA_RELACIONADA_ID IS NULL";
			else
				whereSql += "FACTURA_RELACIONADA_ID=" + _db.CreateSqlParameterName("FACTURA_RELACIONADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!factura_relacionada_idNull)
				AddParameter(cmd, "FACTURA_RELACIONADA_ID", factura_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_NDP_DETALE_NDP_ID</c> foreign key.
		/// </summary>
		/// <param name="nota_debito_proveedor_id">The <c>NOTA_DEBITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual NOTA_DEBITO_PROVEEDOR_DETALLERow[] GetByNOTA_DEBITO_PROVEEDOR_ID(decimal nota_debito_proveedor_id)
		{
			return MapRecords(CreateGetByNOTA_DEBITO_PROVEEDOR_IDCommand(nota_debito_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NDP_DETALE_NDP_ID</c> foreign key.
		/// </summary>
		/// <param name="nota_debito_proveedor_id">The <c>NOTA_DEBITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNOTA_DEBITO_PROVEEDOR_IDAsDataTable(decimal nota_debito_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByNOTA_DEBITO_PROVEEDOR_IDCommand(nota_debito_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NDP_DETALE_NDP_ID</c> foreign key.
		/// </summary>
		/// <param name="nota_debito_proveedor_id">The <c>NOTA_DEBITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNOTA_DEBITO_PROVEEDOR_IDCommand(decimal nota_debito_proveedor_id)
		{
			string whereSql = "";
			whereSql += "NOTA_DEBITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("NOTA_DEBITO_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "NOTA_DEBITO_PROVEEDOR_ID", nota_debito_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(NOTA_DEBITO_PROVEEDOR_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.NOTA_DEBITO_PROVEEDOR_DETALLE (" +
				"ID, " +
				"NOTA_DEBITO_PROVEEDOR_ID, " +
				"FACTURA_RELACIONADA_ID, " +
				"MONTO, " +
				"PORCENTAJE_IMPUESTO, " +
				"MONTO_IMPUESTO, " +
				"DESCRIPCION, " +
				"ACTIVO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOTA_DEBITO_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("FACTURA_RELACIONADA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOTA_DEBITO_PROVEEDOR_ID", value.NOTA_DEBITO_PROVEEDOR_ID);
			AddParameter(cmd, "FACTURA_RELACIONADA_ID",
				value.IsFACTURA_RELACIONADA_IDNull ? DBNull.Value : (object)value.FACTURA_RELACIONADA_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO", value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "MONTO_IMPUESTO", value.MONTO_IMPUESTO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(NOTA_DEBITO_PROVEEDOR_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.NOTA_DEBITO_PROVEEDOR_DETALLE SET " +
				"NOTA_DEBITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("NOTA_DEBITO_PROVEEDOR_ID") + ", " +
				"FACTURA_RELACIONADA_ID=" + _db.CreateSqlParameterName("FACTURA_RELACIONADA_ID") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"PORCENTAJE_IMPUESTO=" + _db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				"MONTO_IMPUESTO=" + _db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOTA_DEBITO_PROVEEDOR_ID", value.NOTA_DEBITO_PROVEEDOR_ID);
			AddParameter(cmd, "FACTURA_RELACIONADA_ID",
				value.IsFACTURA_RELACIONADA_IDNull ? DBNull.Value : (object)value.FACTURA_RELACIONADA_ID);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO", value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "MONTO_IMPUESTO", value.MONTO_IMPUESTO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(NOTA_DEBITO_PROVEEDOR_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table using
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
		/// Deletes records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return CreateDeleteByACTIVO_IDCommand(activo_id, activo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NDP_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_RELACIONADA_ID(decimal factura_relacionada_id)
		{
			return DeleteByFACTURA_RELACIONADA_ID(factura_relacionada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <param name="factura_relacionada_idNull">true if the method ignores the factura_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_RELACIONADA_ID(decimal factura_relacionada_id, bool factura_relacionada_idNull)
		{
			return CreateDeleteByFACTURA_RELACIONADA_IDCommand(factura_relacionada_id, factura_relacionada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NDP_DETALE_FACTURA_ID</c> foreign key.
		/// </summary>
		/// <param name="factura_relacionada_id">The <c>FACTURA_RELACIONADA_ID</c> column value.</param>
		/// <param name="factura_relacionada_idNull">true if the method ignores the factura_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFACTURA_RELACIONADA_IDCommand(decimal factura_relacionada_id, bool factura_relacionada_idNull)
		{
			string whereSql = "";
			if(factura_relacionada_idNull)
				whereSql += "FACTURA_RELACIONADA_ID IS NULL";
			else
				whereSql += "FACTURA_RELACIONADA_ID=" + _db.CreateSqlParameterName("FACTURA_RELACIONADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!factura_relacionada_idNull)
				AddParameter(cmd, "FACTURA_RELACIONADA_ID", factura_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_NDP_DETALE_NDP_ID</c> foreign key.
		/// </summary>
		/// <param name="nota_debito_proveedor_id">The <c>NOTA_DEBITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_DEBITO_PROVEEDOR_ID(decimal nota_debito_proveedor_id)
		{
			return CreateDeleteByNOTA_DEBITO_PROVEEDOR_IDCommand(nota_debito_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NDP_DETALE_NDP_ID</c> foreign key.
		/// </summary>
		/// <param name="nota_debito_proveedor_id">The <c>NOTA_DEBITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNOTA_DEBITO_PROVEEDOR_IDCommand(decimal nota_debito_proveedor_id)
		{
			string whereSql = "";
			whereSql += "NOTA_DEBITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("NOTA_DEBITO_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "NOTA_DEBITO_PROVEEDOR_ID", nota_debito_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.NOTA_DEBITO_PROVEEDOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
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
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected NOTA_DEBITO_PROVEEDOR_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected NOTA_DEBITO_PROVEEDOR_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected virtual NOTA_DEBITO_PROVEEDOR_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nota_debito_proveedor_idColumnIndex = reader.GetOrdinal("NOTA_DEBITO_PROVEEDOR_ID");
			int factura_relacionada_idColumnIndex = reader.GetOrdinal("FACTURA_RELACIONADA_ID");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int monto_impuestoColumnIndex = reader.GetOrdinal("MONTO_IMPUESTO");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					NOTA_DEBITO_PROVEEDOR_DETALLERow record = new NOTA_DEBITO_PROVEEDOR_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOTA_DEBITO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_debito_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(factura_relacionada_idColumnIndex))
						record.FACTURA_RELACIONADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_relacionada_idColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					record.MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_impuestoColumnIndex)), 9);
					record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NOTA_DEBITO_PROVEEDOR_DETALLERow[])(recordList.ToArray(typeof(NOTA_DEBITO_PROVEEDOR_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="NOTA_DEBITO_PROVEEDOR_DETALLERow"/> object.</returns>
		protected virtual NOTA_DEBITO_PROVEEDOR_DETALLERow MapRow(DataRow row)
		{
			NOTA_DEBITO_PROVEEDOR_DETALLERow mappedObject = new NOTA_DEBITO_PROVEEDOR_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOTA_DEBITO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["NOTA_DEBITO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_DEBITO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "FACTURA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["FACTURA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_RELACIONADA_ID = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>NOTA_DEBITO_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "NOTA_DEBITO_PROVEEDOR_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOTA_DEBITO_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURA_RELACIONADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
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

				case "NOTA_DEBITO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of NOTA_DEBITO_PROVEEDOR_DETALLECollection_Base class
}  // End of namespace
