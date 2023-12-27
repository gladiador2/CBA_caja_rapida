// <fileinfo name="CATALOGOS_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="CATALOGOS_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CATALOGOS_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CATALOGOS_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CATALOGO_IDColumnName = "CATALOGO_ID";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CATALOGOS_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CATALOGOS_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CATALOGOS_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public virtual CATALOGOS_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CATALOGOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CATALOGOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CATALOGOS_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CATALOGOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CATALOGOS_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CATALOGOS_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public CATALOGOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public virtual CATALOGOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CATALOGOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CATALOGOS_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CATALOGOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CATALOGOS_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CATALOGOS_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects 
		/// by the <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public CATALOGOS_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects 
		/// by the <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public virtual CATALOGOS_DETALLERow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
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
		/// return records by the <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
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
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects 
		/// by the <c>FK_CATALOGOS_DETALLE_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public virtual CATALOGOS_DETALLERow[] GetByFAMILIA_ID(decimal familia_id)
		{
			return MapRecords(CreateGetByFAMILIA_IDCommand(familia_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CATALOGOS_DETALLE_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFAMILIA_IDAsDataTable(decimal familia_id)
		{
			return MapRecordsToDataTable(CreateGetByFAMILIA_IDCommand(familia_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CATALOGOS_DETALLE_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFAMILIA_IDCommand(decimal familia_id)
		{
			string whereSql = "";
			whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects 
		/// by the <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public CATALOGOS_DETALLERow[] GetByGRUPO_ID(decimal grupo_id)
		{
			return GetByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects 
		/// by the <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public virtual CATALOGOS_DETALLERow[] GetByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecords(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id)
		{
			return GetByGRUPO_IDAsDataTable(grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects 
		/// by the <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public CATALOGOS_DETALLERow[] GetBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CATALOGOS_DETALLERow"/> objects 
		/// by the <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		public virtual CATALOGOS_DETALLERow[] GetBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecords(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_IDAsDataTable(subgrupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CATALOGOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CATALOGOS_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(CATALOGOS_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CATALOGOS_DETALLE (" +
				"ID, " +
				"CATALOGO_ID, " +
				"FAMILIA_ID, " +
				"GRUPO_ID, " +
				"SUBGRUPO_ID, " +
				"ARTICULO_ID, " +
				"OBSERVACION, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CATALOGO_ID") + ", " +
				_db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				_db.CreateSqlParameterName("GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CATALOGO_ID", value.CATALOGO_ID);
			AddParameter(cmd, "FAMILIA_ID", value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CATALOGOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CATALOGOS_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CATALOGOS_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.CATALOGOS_DETALLE SET " +
				"CATALOGO_ID=" + _db.CreateSqlParameterName("CATALOGO_ID") + ", " +
				"FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				"GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID") + ", " +
				"SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CATALOGO_ID", value.CATALOGO_ID);
			AddParameter(cmd, "FAMILIA_ID", value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CATALOGOS_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CATALOGOS_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CATALOGOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CATALOGOS_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CATALOGOS_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CATALOGOS_DETALLE</c> table using
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
		/// Deletes records from the <c>CATALOGOS_DETALLE</c> table using the 
		/// <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CATALOGOS_DETALLE</c> table using the 
		/// <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
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
		/// delete records using the <c>FK_CATALOGOS_DETALLE_ARTICULO</c> foreign key.
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
		/// Deletes records from the <c>CATALOGOS_DETALLE</c> table using the 
		/// <c>FK_CATALOGOS_DETALLE_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFAMILIA_ID(decimal familia_id)
		{
			return CreateDeleteByFAMILIA_IDCommand(familia_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CATALOGOS_DETALLE_FAMILIA</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFAMILIA_IDCommand(decimal familia_id)
		{
			string whereSql = "";
			whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CATALOGOS_DETALLE</c> table using the 
		/// <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id)
		{
			return DeleteByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CATALOGOS_DETALLE</c> table using the 
		/// <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return CreateDeleteByGRUPO_IDCommand(grupo_id, grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CATALOGOS_DETALLE_GRUPO</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CATALOGOS_DETALLE</c> table using the 
		/// <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return DeleteBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CATALOGOS_DETALLE</c> table using the 
		/// <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return CreateDeleteBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CATALOGOS_DETALLE_SUBGRUPO</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CATALOGOS_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>CATALOGOS_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CATALOGOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CATALOGOS_DETALLE</c> table.
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
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		protected CATALOGOS_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		protected CATALOGOS_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CATALOGOS_DETALLERow"/> objects.</returns>
		protected virtual CATALOGOS_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int catalogo_idColumnIndex = reader.GetOrdinal("CATALOGO_ID");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CATALOGOS_DETALLERow record = new CATALOGOS_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CATALOGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(catalogo_idColumnIndex)), 9);
					record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CATALOGOS_DETALLERow[])(recordList.ToArray(typeof(CATALOGOS_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CATALOGOS_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CATALOGOS_DETALLERow"/> object.</returns>
		protected virtual CATALOGOS_DETALLERow MapRow(DataRow row)
		{
			CATALOGOS_DETALLERow mappedObject = new CATALOGOS_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CATALOGO_ID"
			dataColumn = dataTable.Columns["CATALOGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CATALOGO_ID = (decimal)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CATALOGOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CATALOGOS_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CATALOGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "CATALOGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CATALOGOS_DETALLECollection_Base class
}  // End of namespace
