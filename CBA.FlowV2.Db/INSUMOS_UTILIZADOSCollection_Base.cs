// <fileinfo name="INSUMOS_UTILIZADOSCollection_Base.cs">
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
	/// The base class for <see cref="INSUMOS_UTILIZADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INSUMOS_UTILIZADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INSUMOS_UTILIZADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PROD_BALAN_IDColumnName = "PROD_BALAN_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string UNIDAD_MEDIDA_IDColumnName = "UNIDAD_MEDIDA_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string CANTIDAD_NOMINALColumnName = "CANTIDAD_NOMINAL";
		public const string EGRESO_PRODUCTO_IDColumnName = "EGRESO_PRODUCTO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INSUMOS_UTILIZADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INSUMOS_UTILIZADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INSUMOS_UTILIZADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public virtual INSUMOS_UTILIZADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INSUMOS_UTILIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INSUMOS_UTILIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INSUMOS_UTILIZADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INSUMOS_UTILIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INSUMOS_UTILIZADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INSUMOS_UTILIZADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public INSUMOS_UTILIZADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public virtual INSUMOS_UTILIZADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INSUMOS_UTILIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="INSUMOS_UTILIZADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="INSUMOS_UTILIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual INSUMOS_UTILIZADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			INSUMOS_UTILIZADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public INSUMOS_UTILIZADOSRow[] GetByPROD_BALAN_ID(decimal prod_balan_id)
		{
			return GetByPROD_BALAN_ID(prod_balan_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <param name="prod_balan_idNull">true if the method ignores the prod_balan_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public virtual INSUMOS_UTILIZADOSRow[] GetByPROD_BALAN_ID(decimal prod_balan_id, bool prod_balan_idNull)
		{
			return MapRecords(CreateGetByPROD_BALAN_IDCommand(prod_balan_id, prod_balan_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROD_BALAN_IDAsDataTable(decimal prod_balan_id)
		{
			return GetByPROD_BALAN_IDAsDataTable(prod_balan_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <param name="prod_balan_idNull">true if the method ignores the prod_balan_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROD_BALAN_IDAsDataTable(decimal prod_balan_id, bool prod_balan_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROD_BALAN_IDCommand(prod_balan_id, prod_balan_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <param name="prod_balan_idNull">true if the method ignores the prod_balan_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROD_BALAN_IDCommand(decimal prod_balan_id, bool prod_balan_idNull)
		{
			string whereSql = "";
			if(prod_balan_idNull)
				whereSql += "PROD_BALAN_ID IS NULL";
			else
				whereSql += "PROD_BALAN_ID=" + _db.CreateSqlParameterName("PROD_BALAN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!prod_balan_idNull)
				AddParameter(cmd, "PROD_BALAN_ID", prod_balan_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTILIZADO_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public virtual INSUMOS_UTILIZADOSRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTILIZADO_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INSUMOS_UTILIZADO_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public INSUMOS_UTILIZADOSRow[] GetByEGRESO_PRODUCTO_ID(decimal egreso_producto_id)
		{
			return GetByEGRESO_PRODUCTO_ID(egreso_producto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <param name="egreso_producto_idNull">true if the method ignores the egreso_producto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public virtual INSUMOS_UTILIZADOSRow[] GetByEGRESO_PRODUCTO_ID(decimal egreso_producto_id, bool egreso_producto_idNull)
		{
			return MapRecords(CreateGetByEGRESO_PRODUCTO_IDCommand(egreso_producto_id, egreso_producto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEGRESO_PRODUCTO_IDAsDataTable(decimal egreso_producto_id)
		{
			return GetByEGRESO_PRODUCTO_IDAsDataTable(egreso_producto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <param name="egreso_producto_idNull">true if the method ignores the egreso_producto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_PRODUCTO_IDAsDataTable(decimal egreso_producto_id, bool egreso_producto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_PRODUCTO_IDCommand(egreso_producto_id, egreso_producto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <param name="egreso_producto_idNull">true if the method ignores the egreso_producto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_PRODUCTO_IDCommand(decimal egreso_producto_id, bool egreso_producto_idNull)
		{
			string whereSql = "";
			if(egreso_producto_idNull)
				whereSql += "EGRESO_PRODUCTO_ID IS NULL";
			else
				whereSql += "EGRESO_PRODUCTO_ID=" + _db.CreateSqlParameterName("EGRESO_PRODUCTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!egreso_producto_idNull)
				AddParameter(cmd, "EGRESO_PRODUCTO_ID", egreso_producto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTILIZADO_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public virtual INSUMOS_UTILIZADOSRow[] GetByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTILIZADO_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_IDAsDataTable(string unidad_medida_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INSUMOS_UTILIZADO_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_IDCommand(string unidad_medida_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", unidad_medida_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public INSUMOS_UTILIZADOSRow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INSUMOS_UTILIZADOSRow"/> objects 
		/// by the <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		public virtual INSUMOS_UTILIZADOSRow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOTE_IDAsDataTable(decimal lote_id, bool lote_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>INSUMOS_UTILIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INSUMOS_UTILIZADOSRow"/> object to be inserted.</param>
		public virtual void Insert(INSUMOS_UTILIZADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.INSUMOS_UTILIZADOS (" +
				"ID, " +
				"PROD_BALAN_ID, " +
				"ARTICULO_ID, " +
				"UNIDAD_MEDIDA_ID, " +
				"CANTIDAD, " +
				"LOTE_ID, " +
				"CANTIDAD_NOMINAL, " +
				"EGRESO_PRODUCTO_ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PROD_BALAN_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_NOMINAL") + ", " +
				_db.CreateSqlParameterName("EGRESO_PRODUCTO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PROD_BALAN_ID",
				value.IsPROD_BALAN_IDNull ? DBNull.Value : (object)value.PROD_BALAN_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_NOMINAL",
				value.IsCANTIDAD_NOMINALNull ? DBNull.Value : (object)value.CANTIDAD_NOMINAL);
			AddParameter(cmd, "EGRESO_PRODUCTO_ID",
				value.IsEGRESO_PRODUCTO_IDNull ? DBNull.Value : (object)value.EGRESO_PRODUCTO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>INSUMOS_UTILIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INSUMOS_UTILIZADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(INSUMOS_UTILIZADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.INSUMOS_UTILIZADOS SET " +
				"PROD_BALAN_ID=" + _db.CreateSqlParameterName("PROD_BALAN_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"CANTIDAD_NOMINAL=" + _db.CreateSqlParameterName("CANTIDAD_NOMINAL") + ", " +
				"EGRESO_PRODUCTO_ID=" + _db.CreateSqlParameterName("EGRESO_PRODUCTO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PROD_BALAN_ID",
				value.IsPROD_BALAN_IDNull ? DBNull.Value : (object)value.PROD_BALAN_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_NOMINAL",
				value.IsCANTIDAD_NOMINALNull ? DBNull.Value : (object)value.CANTIDAD_NOMINAL);
			AddParameter(cmd, "EGRESO_PRODUCTO_ID",
				value.IsEGRESO_PRODUCTO_IDNull ? DBNull.Value : (object)value.EGRESO_PRODUCTO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>INSUMOS_UTILIZADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>INSUMOS_UTILIZADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>INSUMOS_UTILIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INSUMOS_UTILIZADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(INSUMOS_UTILIZADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>INSUMOS_UTILIZADOS</c> table using
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
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROD_BALAN_ID(decimal prod_balan_id)
		{
			return DeleteByPROD_BALAN_ID(prod_balan_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <param name="prod_balan_idNull">true if the method ignores the prod_balan_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROD_BALAN_ID(decimal prod_balan_id, bool prod_balan_idNull)
		{
			return CreateDeleteByPROD_BALAN_IDCommand(prod_balan_id, prod_balan_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INSUMOS_UTIL_PROD_BAL_ID</c> foreign key.
		/// </summary>
		/// <param name="prod_balan_id">The <c>PROD_BALAN_ID</c> column value.</param>
		/// <param name="prod_balan_idNull">true if the method ignores the prod_balan_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROD_BALAN_IDCommand(decimal prod_balan_id, bool prod_balan_idNull)
		{
			string whereSql = "";
			if(prod_balan_idNull)
				whereSql += "PROD_BALAN_ID IS NULL";
			else
				whereSql += "PROD_BALAN_ID=" + _db.CreateSqlParameterName("PROD_BALAN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!prod_balan_idNull)
				AddParameter(cmd, "PROD_BALAN_ID", prod_balan_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTILIZADO_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INSUMOS_UTILIZADO_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_PRODUCTO_ID(decimal egreso_producto_id)
		{
			return DeleteByEGRESO_PRODUCTO_ID(egreso_producto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <param name="egreso_producto_idNull">true if the method ignores the egreso_producto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_PRODUCTO_ID(decimal egreso_producto_id, bool egreso_producto_idNull)
		{
			return CreateDeleteByEGRESO_PRODUCTO_IDCommand(egreso_producto_id, egreso_producto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INSUMOS_UTILIZADO_EGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_producto_id">The <c>EGRESO_PRODUCTO_ID</c> column value.</param>
		/// <param name="egreso_producto_idNull">true if the method ignores the egreso_producto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_PRODUCTO_IDCommand(decimal egreso_producto_id, bool egreso_producto_idNull)
		{
			string whereSql = "";
			if(egreso_producto_idNull)
				whereSql += "EGRESO_PRODUCTO_ID IS NULL";
			else
				whereSql += "EGRESO_PRODUCTO_ID=" + _db.CreateSqlParameterName("EGRESO_PRODUCTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!egreso_producto_idNull)
				AddParameter(cmd, "EGRESO_PRODUCTO_ID", egreso_producto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTILIZADO_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_IDCommand(unidad_medida_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INSUMOS_UTILIZADO_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_IDCommand(string unidad_medida_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", unidad_medida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INSUMOS_UTILIZADOS</c> table using the 
		/// <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return CreateDeleteByLOTE_IDCommand(lote_id, lote_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INSUMOS_UTILIZADOS_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>INSUMOS_UTILIZADOS</c> records that match the specified criteria.
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
		/// to delete <c>INSUMOS_UTILIZADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.INSUMOS_UTILIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>INSUMOS_UTILIZADOS</c> table.
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
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		protected INSUMOS_UTILIZADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		protected INSUMOS_UTILIZADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INSUMOS_UTILIZADOSRow"/> objects.</returns>
		protected virtual INSUMOS_UTILIZADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int prod_balan_idColumnIndex = reader.GetOrdinal("PROD_BALAN_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int unidad_medida_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int cantidad_nominalColumnIndex = reader.GetOrdinal("CANTIDAD_NOMINAL");
			int egreso_producto_idColumnIndex = reader.GetOrdinal("EGRESO_PRODUCTO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INSUMOS_UTILIZADOSRow record = new INSUMOS_UTILIZADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(prod_balan_idColumnIndex))
						record.PROD_BALAN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(prod_balan_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(unidad_medida_idColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_nominalColumnIndex))
						record.CANTIDAD_NOMINAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_nominalColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_producto_idColumnIndex))
						record.EGRESO_PRODUCTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_producto_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INSUMOS_UTILIZADOSRow[])(recordList.ToArray(typeof(INSUMOS_UTILIZADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INSUMOS_UTILIZADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INSUMOS_UTILIZADOSRow"/> object.</returns>
		protected virtual INSUMOS_UTILIZADOSRow MapRow(DataRow row)
		{
			INSUMOS_UTILIZADOSRow mappedObject = new INSUMOS_UTILIZADOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PROD_BALAN_ID"
			dataColumn = dataTable.Columns["PROD_BALAN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROD_BALAN_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_NOMINAL"
			dataColumn = dataTable.Columns["CANTIDAD_NOMINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_NOMINAL = (decimal)row[dataColumn];
			// Column "EGRESO_PRODUCTO_ID"
			dataColumn = dataTable.Columns["EGRESO_PRODUCTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_PRODUCTO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INSUMOS_UTILIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INSUMOS_UTILIZADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROD_BALAN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_NOMINAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_PRODUCTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
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

				case "PROD_BALAN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_NOMINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_PRODUCTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INSUMOS_UTILIZADOSCollection_Base class
}  // End of namespace
