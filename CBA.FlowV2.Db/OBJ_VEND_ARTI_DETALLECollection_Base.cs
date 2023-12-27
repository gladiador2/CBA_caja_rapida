// <fileinfo name="OBJ_VEND_ARTI_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="OBJ_VEND_ARTI_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="OBJ_VEND_ARTI_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJ_VEND_ARTI_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string OBJETIVO_VENDEDOR_ARTICULO_IDColumnName = "OBJETIVO_VENDEDOR_ARTICULO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string VENDEDOR_IDColumnName = "VENDEDOR_ID";
		public const string CANTIDADColumnName = "CANTIDAD";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJ_VEND_ARTI_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public OBJ_VEND_ARTI_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>OBJ_VEND_ARTI_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_ARTI_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>OBJ_VEND_ARTI_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>OBJ_VEND_ARTI_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="OBJ_VEND_ARTI_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public OBJ_VEND_ARTI_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			OBJ_VEND_ARTI_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public OBJ_VEND_ARTI_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_ARTI_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.OBJ_VEND_ARTI_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="OBJ_VEND_ARTI_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="OBJ_VEND_ARTI_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual OBJ_VEND_ARTI_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			OBJ_VEND_ARTI_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public OBJ_VEND_ARTI_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_ARTI_DETALLERow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public OBJ_VEND_ARTI_DETALLERow[] GetByOBJETIVO_VENDEDOR_ARTICULO_ID(decimal objetivo_vendedor_articulo_id)
		{
			return GetByOBJETIVO_VENDEDOR_ARTICULO_ID(objetivo_vendedor_articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_articulo_idNull">true if the method ignores the objetivo_vendedor_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_ARTI_DETALLERow[] GetByOBJETIVO_VENDEDOR_ARTICULO_ID(decimal objetivo_vendedor_articulo_id, bool objetivo_vendedor_articulo_idNull)
		{
			return MapRecords(CreateGetByOBJETIVO_VENDEDOR_ARTICULO_IDCommand(objetivo_vendedor_articulo_id, objetivo_vendedor_articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByOBJETIVO_VENDEDOR_ARTICULO_IDAsDataTable(decimal objetivo_vendedor_articulo_id)
		{
			return GetByOBJETIVO_VENDEDOR_ARTICULO_IDAsDataTable(objetivo_vendedor_articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_articulo_idNull">true if the method ignores the objetivo_vendedor_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByOBJETIVO_VENDEDOR_ARTICULO_IDAsDataTable(decimal objetivo_vendedor_articulo_id, bool objetivo_vendedor_articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByOBJETIVO_VENDEDOR_ARTICULO_IDCommand(objetivo_vendedor_articulo_id, objetivo_vendedor_articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_articulo_idNull">true if the method ignores the objetivo_vendedor_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByOBJETIVO_VENDEDOR_ARTICULO_IDCommand(decimal objetivo_vendedor_articulo_id, bool objetivo_vendedor_articulo_idNull)
		{
			string whereSql = "";
			if(objetivo_vendedor_articulo_idNull)
				whereSql += "OBJETIVO_VENDEDOR_ARTICULO_ID IS NULL";
			else
				whereSql += "OBJETIVO_VENDEDOR_ARTICULO_ID=" + _db.CreateSqlParameterName("OBJETIVO_VENDEDOR_ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!objetivo_vendedor_articulo_idNull)
				AddParameter(cmd, "OBJETIVO_VENDEDOR_ARTICULO_ID", objetivo_vendedor_articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public OBJ_VEND_ARTI_DETALLERow[] GetByVENDEDOR_ID(decimal vendedor_id)
		{
			return GetByVENDEDOR_ID(vendedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects 
		/// by the <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		public virtual OBJ_VEND_ARTI_DETALLERow[] GetByVENDEDOR_ID(decimal vendedor_id, bool vendedor_idNull)
		{
			return MapRecords(CreateGetByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVENDEDOR_IDAsDataTable(decimal vendedor_id)
		{
			return GetByVENDEDOR_IDAsDataTable(vendedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVENDEDOR_IDAsDataTable(decimal vendedor_id, bool vendedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVENDEDOR_IDCommand(decimal vendedor_id, bool vendedor_idNull)
		{
			string whereSql = "";
			if(vendedor_idNull)
				whereSql += "VENDEDOR_ID IS NULL";
			else
				whereSql += "VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vendedor_idNull)
				AddParameter(cmd, "VENDEDOR_ID", vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>OBJ_VEND_ARTI_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJ_VEND_ARTI_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(OBJ_VEND_ARTI_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.OBJ_VEND_ARTI_DETALLE (" +
				"ID, " +
				"OBJETIVO_VENDEDOR_ARTICULO_ID, " +
				"ARTICULO_ID, " +
				"VENDEDOR_ID, " +
				"CANTIDAD" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("OBJETIVO_VENDEDOR_ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("VENDEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "OBJETIVO_VENDEDOR_ARTICULO_ID",
				value.IsOBJETIVO_VENDEDOR_ARTICULO_IDNull ? DBNull.Value : (object)value.OBJETIVO_VENDEDOR_ARTICULO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "VENDEDOR_ID",
				value.IsVENDEDOR_IDNull ? DBNull.Value : (object)value.VENDEDOR_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>OBJ_VEND_ARTI_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJ_VEND_ARTI_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(OBJ_VEND_ARTI_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.OBJ_VEND_ARTI_DETALLE SET " +
				"OBJETIVO_VENDEDOR_ARTICULO_ID=" + _db.CreateSqlParameterName("OBJETIVO_VENDEDOR_ARTICULO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "OBJETIVO_VENDEDOR_ARTICULO_ID",
				value.IsOBJETIVO_VENDEDOR_ARTICULO_IDNull ? DBNull.Value : (object)value.OBJETIVO_VENDEDOR_ARTICULO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "VENDEDOR_ID",
				value.IsVENDEDOR_IDNull ? DBNull.Value : (object)value.VENDEDOR_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>OBJ_VEND_ARTI_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>OBJ_VEND_ARTI_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>OBJ_VEND_ARTI_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="OBJ_VEND_ARTI_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(OBJ_VEND_ARTI_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>OBJ_VEND_ARTI_DETALLE</c> table using
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
		/// Deletes records from the <c>OBJ_VEND_ARTI_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_ARTI_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id, articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_ART_DET_ARTI_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_ARTI_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOBJETIVO_VENDEDOR_ARTICULO_ID(decimal objetivo_vendedor_articulo_id)
		{
			return DeleteByOBJETIVO_VENDEDOR_ARTICULO_ID(objetivo_vendedor_articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_ARTI_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_articulo_idNull">true if the method ignores the objetivo_vendedor_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOBJETIVO_VENDEDOR_ARTICULO_ID(decimal objetivo_vendedor_articulo_id, bool objetivo_vendedor_articulo_idNull)
		{
			return CreateDeleteByOBJETIVO_VENDEDOR_ARTICULO_IDCommand(objetivo_vendedor_articulo_id, objetivo_vendedor_articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_ART_DET_OBJ_AR</c> foreign key.
		/// </summary>
		/// <param name="objetivo_vendedor_articulo_id">The <c>OBJETIVO_VENDEDOR_ARTICULO_ID</c> column value.</param>
		/// <param name="objetivo_vendedor_articulo_idNull">true if the method ignores the objetivo_vendedor_articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByOBJETIVO_VENDEDOR_ARTICULO_IDCommand(decimal objetivo_vendedor_articulo_id, bool objetivo_vendedor_articulo_idNull)
		{
			string whereSql = "";
			if(objetivo_vendedor_articulo_idNull)
				whereSql += "OBJETIVO_VENDEDOR_ARTICULO_ID IS NULL";
			else
				whereSql += "OBJETIVO_VENDEDOR_ARTICULO_ID=" + _db.CreateSqlParameterName("OBJETIVO_VENDEDOR_ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!objetivo_vendedor_articulo_idNull)
				AddParameter(cmd, "OBJETIVO_VENDEDOR_ARTICULO_ID", objetivo_vendedor_articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_ARTI_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_ID(decimal vendedor_id)
		{
			return DeleteByVENDEDOR_ID(vendedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>OBJ_VEND_ARTI_DETALLE</c> table using the 
		/// <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_ID(decimal vendedor_id, bool vendedor_idNull)
		{
			return CreateDeleteByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_OBJ_VEND_ART_DET_VEND</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVENDEDOR_IDCommand(decimal vendedor_id, bool vendedor_idNull)
		{
			string whereSql = "";
			if(vendedor_idNull)
				whereSql += "VENDEDOR_ID IS NULL";
			else
				whereSql += "VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vendedor_idNull)
				AddParameter(cmd, "VENDEDOR_ID", vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>OBJ_VEND_ARTI_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>OBJ_VEND_ARTI_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.OBJ_VEND_ARTI_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>OBJ_VEND_ARTI_DETALLE</c> table.
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
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		protected OBJ_VEND_ARTI_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		protected OBJ_VEND_ARTI_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="OBJ_VEND_ARTI_DETALLERow"/> objects.</returns>
		protected virtual OBJ_VEND_ARTI_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int objetivo_vendedor_articulo_idColumnIndex = reader.GetOrdinal("OBJETIVO_VENDEDOR_ARTICULO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int vendedor_idColumnIndex = reader.GetOrdinal("VENDEDOR_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					OBJ_VEND_ARTI_DETALLERow record = new OBJ_VEND_ARTI_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(objetivo_vendedor_articulo_idColumnIndex))
						record.OBJETIVO_VENDEDOR_ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(objetivo_vendedor_articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_idColumnIndex))
						record.VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (OBJ_VEND_ARTI_DETALLERow[])(recordList.ToArray(typeof(OBJ_VEND_ARTI_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="OBJ_VEND_ARTI_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="OBJ_VEND_ARTI_DETALLERow"/> object.</returns>
		protected virtual OBJ_VEND_ARTI_DETALLERow MapRow(DataRow row)
		{
			OBJ_VEND_ARTI_DETALLERow mappedObject = new OBJ_VEND_ARTI_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "OBJETIVO_VENDEDOR_ARTICULO_ID"
			dataColumn = dataTable.Columns["OBJETIVO_VENDEDOR_ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBJETIVO_VENDEDOR_ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR_ID"
			dataColumn = dataTable.Columns["VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>OBJ_VEND_ARTI_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "OBJ_VEND_ARTI_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBJETIVO_VENDEDOR_ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VENDEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
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

				case "OBJETIVO_VENDEDOR_ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of OBJ_VEND_ARTI_DETALLECollection_Base class
}  // End of namespace
