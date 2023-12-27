// <fileinfo name="STOCK_INVENTARIO_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="STOCK_INVENTARIO_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_INVENTARIO_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_INVENTARIO_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string STOCK_INVENTANRIO_IDColumnName = "STOCK_INVENTANRIO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string CANTIDAD_SISTEMAColumnName = "CANTIDAD_SISTEMA";
		public const string CANTIDAD_MANUALColumnName = "CANTIDAD_MANUAL";
		public const string AJUSTE_STOCK_CASO_IDColumnName = "AJUSTE_STOCK_CASO_ID";
		public const string UNIDAD_IDColumnName = "UNIDAD_ID";
		public const string PASILLOColumnName = "PASILLO";
		public const string ESTANTEColumnName = "ESTANTE";
		public const string NIVELColumnName = "NIVEL";
		public const string COLUMNAColumnName = "COLUMNA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_INVENTARIO_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_INVENTARIO_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_INVENTARIO_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_INVENTARIO_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_INVENTARIO_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_INVENTARIO_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_INVENTARIO_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_INVENTARIO_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_INVENTARIO_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public STOCK_INVENTARIO_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_INVENTARIO_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="STOCK_INVENTARIO_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="STOCK_INVENTARIO_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			STOCK_INVENTARIO_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public STOCK_INVENTARIO_DETALLERow[] GetByAJUSTE_STOCK_CASO_ID(decimal ajuste_stock_caso_id)
		{
			return GetByAJUSTE_STOCK_CASO_ID(ajuste_stock_caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <param name="ajuste_stock_caso_idNull">true if the method ignores the ajuste_stock_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow[] GetByAJUSTE_STOCK_CASO_ID(decimal ajuste_stock_caso_id, bool ajuste_stock_caso_idNull)
		{
			return MapRecords(CreateGetByAJUSTE_STOCK_CASO_IDCommand(ajuste_stock_caso_id, ajuste_stock_caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAJUSTE_STOCK_CASO_IDAsDataTable(decimal ajuste_stock_caso_id)
		{
			return GetByAJUSTE_STOCK_CASO_IDAsDataTable(ajuste_stock_caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <param name="ajuste_stock_caso_idNull">true if the method ignores the ajuste_stock_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAJUSTE_STOCK_CASO_IDAsDataTable(decimal ajuste_stock_caso_id, bool ajuste_stock_caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAJUSTE_STOCK_CASO_IDCommand(ajuste_stock_caso_id, ajuste_stock_caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <param name="ajuste_stock_caso_idNull">true if the method ignores the ajuste_stock_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAJUSTE_STOCK_CASO_IDCommand(decimal ajuste_stock_caso_id, bool ajuste_stock_caso_idNull)
		{
			string whereSql = "";
			if(ajuste_stock_caso_idNull)
				whereSql += "AJUSTE_STOCK_CASO_ID IS NULL";
			else
				whereSql += "AJUSTE_STOCK_CASO_ID=" + _db.CreateSqlParameterName("AJUSTE_STOCK_CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ajuste_stock_caso_idNull)
				AddParameter(cmd, "AJUSTE_STOCK_CASO_ID", ajuste_stock_caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_INVEN_DET_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_INVEN_DET_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_INVEN_DET_ART_ID</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_INVEN_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow[] GetByLOTE_ID(decimal lote_id)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_INVEN_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return MapRecordsToDataTable(CreateGetByLOTE_IDCommand(lote_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_INVEN_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOTE_IDCommand(decimal lote_id)
		{
			string whereSql = "";
			whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_INVEN_INVATARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_inventanrio_id">The <c>STOCK_INVENTANRIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow[] GetBySTOCK_INVENTANRIO_ID(decimal stock_inventanrio_id)
		{
			return MapRecords(CreateGetBySTOCK_INVENTANRIO_IDCommand(stock_inventanrio_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_INVEN_INVATARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_inventanrio_id">The <c>STOCK_INVENTANRIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySTOCK_INVENTANRIO_IDAsDataTable(decimal stock_inventanrio_id)
		{
			return MapRecordsToDataTable(CreateGetBySTOCK_INVENTANRIO_IDCommand(stock_inventanrio_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_INVEN_INVATARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_inventanrio_id">The <c>STOCK_INVENTANRIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySTOCK_INVENTANRIO_IDCommand(decimal stock_inventanrio_id)
		{
			string whereSql = "";
			whereSql += "STOCK_INVENTANRIO_ID=" + _db.CreateSqlParameterName("STOCK_INVENTANRIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "STOCK_INVENTANRIO_ID", stock_inventanrio_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_INVEN_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		public virtual STOCK_INVENTARIO_DETALLERow[] GetByUNIDAD_ID(string unidad_id)
		{
			return MapRecords(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_INVEN_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_IDAsDataTable(string unidad_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_INVEN_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_IDCommand(string unidad_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UNIDAD_ID", unidad_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>STOCK_INVENTARIO_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_INVENTARIO_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(STOCK_INVENTARIO_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.STOCK_INVENTARIO_DETALLE (" +
				"ID, " +
				"STOCK_INVENTANRIO_ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"CANTIDAD_SISTEMA, " +
				"CANTIDAD_MANUAL, " +
				"AJUSTE_STOCK_CASO_ID, " +
				"UNIDAD_ID, " +
				"PASILLO, " +
				"ESTANTE, " +
				"NIVEL, " +
				"COLUMNA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("STOCK_INVENTANRIO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_SISTEMA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MANUAL") + ", " +
				_db.CreateSqlParameterName("AJUSTE_STOCK_CASO_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				_db.CreateSqlParameterName("PASILLO") + ", " +
				_db.CreateSqlParameterName("ESTANTE") + ", " +
				_db.CreateSqlParameterName("NIVEL") + ", " +
				_db.CreateSqlParameterName("COLUMNA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "STOCK_INVENTANRIO_ID", value.STOCK_INVENTANRIO_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID", value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_SISTEMA",
				value.IsCANTIDAD_SISTEMANull ? DBNull.Value : (object)value.CANTIDAD_SISTEMA);
			AddParameter(cmd, "CANTIDAD_MANUAL",
				value.IsCANTIDAD_MANUALNull ? DBNull.Value : (object)value.CANTIDAD_MANUAL);
			AddParameter(cmd, "AJUSTE_STOCK_CASO_ID",
				value.IsAJUSTE_STOCK_CASO_IDNull ? DBNull.Value : (object)value.AJUSTE_STOCK_CASO_ID);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "PASILLO", value.PASILLO);
			AddParameter(cmd, "ESTANTE", value.ESTANTE);
			AddParameter(cmd, "NIVEL", value.NIVEL);
			AddParameter(cmd, "COLUMNA", value.COLUMNA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>STOCK_INVENTARIO_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_INVENTARIO_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(STOCK_INVENTARIO_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.STOCK_INVENTARIO_DETALLE SET " +
				"STOCK_INVENTANRIO_ID=" + _db.CreateSqlParameterName("STOCK_INVENTANRIO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"CANTIDAD_SISTEMA=" + _db.CreateSqlParameterName("CANTIDAD_SISTEMA") + ", " +
				"CANTIDAD_MANUAL=" + _db.CreateSqlParameterName("CANTIDAD_MANUAL") + ", " +
				"AJUSTE_STOCK_CASO_ID=" + _db.CreateSqlParameterName("AJUSTE_STOCK_CASO_ID") + ", " +
				"UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				"PASILLO=" + _db.CreateSqlParameterName("PASILLO") + ", " +
				"ESTANTE=" + _db.CreateSqlParameterName("ESTANTE") + ", " +
				"NIVEL=" + _db.CreateSqlParameterName("NIVEL") + ", " +
				"COLUMNA=" + _db.CreateSqlParameterName("COLUMNA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "STOCK_INVENTANRIO_ID", value.STOCK_INVENTANRIO_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID", value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_SISTEMA",
				value.IsCANTIDAD_SISTEMANull ? DBNull.Value : (object)value.CANTIDAD_SISTEMA);
			AddParameter(cmd, "CANTIDAD_MANUAL",
				value.IsCANTIDAD_MANUALNull ? DBNull.Value : (object)value.CANTIDAD_MANUAL);
			AddParameter(cmd, "AJUSTE_STOCK_CASO_ID",
				value.IsAJUSTE_STOCK_CASO_IDNull ? DBNull.Value : (object)value.AJUSTE_STOCK_CASO_ID);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "PASILLO", value.PASILLO);
			AddParameter(cmd, "ESTANTE", value.ESTANTE);
			AddParameter(cmd, "NIVEL", value.NIVEL);
			AddParameter(cmd, "COLUMNA", value.COLUMNA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>STOCK_INVENTARIO_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>STOCK_INVENTARIO_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>STOCK_INVENTARIO_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_INVENTARIO_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(STOCK_INVENTARIO_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>STOCK_INVENTARIO_DETALLE</c> table using
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
		/// Deletes records from the <c>STOCK_INVENTARIO_DETALLE</c> table using the 
		/// <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAJUSTE_STOCK_CASO_ID(decimal ajuste_stock_caso_id)
		{
			return DeleteByAJUSTE_STOCK_CASO_ID(ajuste_stock_caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_INVENTARIO_DETALLE</c> table using the 
		/// <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <param name="ajuste_stock_caso_idNull">true if the method ignores the ajuste_stock_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAJUSTE_STOCK_CASO_ID(decimal ajuste_stock_caso_id, bool ajuste_stock_caso_idNull)
		{
			return CreateDeleteByAJUSTE_STOCK_CASO_IDCommand(ajuste_stock_caso_id, ajuste_stock_caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_INVEN_DET_AJUSTE_ID</c> foreign key.
		/// </summary>
		/// <param name="ajuste_stock_caso_id">The <c>AJUSTE_STOCK_CASO_ID</c> column value.</param>
		/// <param name="ajuste_stock_caso_idNull">true if the method ignores the ajuste_stock_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAJUSTE_STOCK_CASO_IDCommand(decimal ajuste_stock_caso_id, bool ajuste_stock_caso_idNull)
		{
			string whereSql = "";
			if(ajuste_stock_caso_idNull)
				whereSql += "AJUSTE_STOCK_CASO_ID IS NULL";
			else
				whereSql += "AJUSTE_STOCK_CASO_ID=" + _db.CreateSqlParameterName("AJUSTE_STOCK_CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ajuste_stock_caso_idNull)
				AddParameter(cmd, "AJUSTE_STOCK_CASO_ID", ajuste_stock_caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_INVENTARIO_DETALLE</c> table using the 
		/// <c>FK_STOCK_INVEN_DET_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_INVEN_DET_ART_ID</c> foreign key.
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
		/// Deletes records from the <c>STOCK_INVENTARIO_DETALLE</c> table using the 
		/// <c>FK_STOCK_INVEN_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return CreateDeleteByLOTE_IDCommand(lote_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_INVEN_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOTE_IDCommand(decimal lote_id)
		{
			string whereSql = "";
			whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_INVENTARIO_DETALLE</c> table using the 
		/// <c>FK_STOCK_INVEN_INVATARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_inventanrio_id">The <c>STOCK_INVENTANRIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySTOCK_INVENTANRIO_ID(decimal stock_inventanrio_id)
		{
			return CreateDeleteBySTOCK_INVENTANRIO_IDCommand(stock_inventanrio_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_INVEN_INVATARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="stock_inventanrio_id">The <c>STOCK_INVENTANRIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySTOCK_INVENTANRIO_IDCommand(decimal stock_inventanrio_id)
		{
			string whereSql = "";
			whereSql += "STOCK_INVENTANRIO_ID=" + _db.CreateSqlParameterName("STOCK_INVENTANRIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "STOCK_INVENTANRIO_ID", stock_inventanrio_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_INVENTARIO_DETALLE</c> table using the 
		/// <c>FK_STOCK_INVEN_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ID(string unidad_id)
		{
			return CreateDeleteByUNIDAD_IDCommand(unidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_INVEN_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_IDCommand(string unidad_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UNIDAD_ID", unidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>STOCK_INVENTARIO_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>STOCK_INVENTARIO_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.STOCK_INVENTARIO_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>STOCK_INVENTARIO_DETALLE</c> table.
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
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		protected STOCK_INVENTARIO_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		protected STOCK_INVENTARIO_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_INVENTARIO_DETALLERow"/> objects.</returns>
		protected virtual STOCK_INVENTARIO_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int stock_inventanrio_idColumnIndex = reader.GetOrdinal("STOCK_INVENTANRIO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int cantidad_sistemaColumnIndex = reader.GetOrdinal("CANTIDAD_SISTEMA");
			int cantidad_manualColumnIndex = reader.GetOrdinal("CANTIDAD_MANUAL");
			int ajuste_stock_caso_idColumnIndex = reader.GetOrdinal("AJUSTE_STOCK_CASO_ID");
			int unidad_idColumnIndex = reader.GetOrdinal("UNIDAD_ID");
			int pasilloColumnIndex = reader.GetOrdinal("PASILLO");
			int estanteColumnIndex = reader.GetOrdinal("ESTANTE");
			int nivelColumnIndex = reader.GetOrdinal("NIVEL");
			int columnaColumnIndex = reader.GetOrdinal("COLUMNA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_INVENTARIO_DETALLERow record = new STOCK_INVENTARIO_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.STOCK_INVENTANRIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_inventanrio_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_sistemaColumnIndex))
						record.CANTIDAD_SISTEMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_sistemaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_manualColumnIndex))
						record.CANTIDAD_MANUAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_manualColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_stock_caso_idColumnIndex))
						record.AJUSTE_STOCK_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_stock_caso_idColumnIndex)), 9);
					record.UNIDAD_ID = Convert.ToString(reader.GetValue(unidad_idColumnIndex));
					if(!reader.IsDBNull(pasilloColumnIndex))
						record.PASILLO = Convert.ToString(reader.GetValue(pasilloColumnIndex));
					if(!reader.IsDBNull(estanteColumnIndex))
						record.ESTANTE = Convert.ToString(reader.GetValue(estanteColumnIndex));
					if(!reader.IsDBNull(nivelColumnIndex))
						record.NIVEL = Convert.ToString(reader.GetValue(nivelColumnIndex));
					if(!reader.IsDBNull(columnaColumnIndex))
						record.COLUMNA = Convert.ToString(reader.GetValue(columnaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_INVENTARIO_DETALLERow[])(recordList.ToArray(typeof(STOCK_INVENTARIO_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_INVENTARIO_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_INVENTARIO_DETALLERow"/> object.</returns>
		protected virtual STOCK_INVENTARIO_DETALLERow MapRow(DataRow row)
		{
			STOCK_INVENTARIO_DETALLERow mappedObject = new STOCK_INVENTARIO_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "STOCK_INVENTANRIO_ID"
			dataColumn = dataTable.Columns["STOCK_INVENTANRIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_INVENTANRIO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_SISTEMA"
			dataColumn = dataTable.Columns["CANTIDAD_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_SISTEMA = (decimal)row[dataColumn];
			// Column "CANTIDAD_MANUAL"
			dataColumn = dataTable.Columns["CANTIDAD_MANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MANUAL = (decimal)row[dataColumn];
			// Column "AJUSTE_STOCK_CASO_ID"
			dataColumn = dataTable.Columns["AJUSTE_STOCK_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_STOCK_CASO_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_ID"
			dataColumn = dataTable.Columns["UNIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID = (string)row[dataColumn];
			// Column "PASILLO"
			dataColumn = dataTable.Columns["PASILLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASILLO = (string)row[dataColumn];
			// Column "ESTANTE"
			dataColumn = dataTable.Columns["ESTANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTANTE = (string)row[dataColumn];
			// Column "NIVEL"
			dataColumn = dataTable.Columns["NIVEL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL = (string)row[dataColumn];
			// Column "COLUMNA"
			dataColumn = dataTable.Columns["COLUMNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLUMNA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_INVENTARIO_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_INVENTARIO_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("STOCK_INVENTANRIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_SISTEMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_MANUAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AJUSTE_STOCK_CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PASILLO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("ESTANTE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("NIVEL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("COLUMNA", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "STOCK_INVENTANRIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_STOCK_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PASILLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NIVEL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COLUMNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_INVENTARIO_DETALLECollection_Base class
}  // End of namespace
