// <fileinfo name="STOCK_TRANSFERENCIA_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSFERENCIA_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_TRANSFERENCIA_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSFERENCIA_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TRANSFERENCIA_STOCK_IDColumnName = "TRANSFERENCIA_STOCK_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string UNIDAD_MEDIDA_DESTINO_IDColumnName = "UNIDAD_MEDIDA_DESTINO_ID";
		public const string CANTIDAD_DEST_UNITARIAColumnName = "CANTIDAD_DEST_UNITARIA";
		public const string CANTIDAD_DEST_EMBALADAColumnName = "CANTIDAD_DEST_EMBALADA";
		public const string CANTIDAD_DEST_CAJAColumnName = "CANTIDAD_DEST_CAJA";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_COSTOColumnName = "MONTO_COSTO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CANTIDAD_UNITARIA_DEST_TOTALColumnName = "CANTIDAD_UNITARIA_DEST_TOTAL";
		public const string UNIDAD_MEDIDA_ORIGEN_IDColumnName = "UNIDAD_MEDIDA_ORIGEN_ID";
		public const string CANTIDAD_ORIG_UNITARIAColumnName = "CANTIDAD_ORIG_UNITARIA";
		public const string CANTIDAD_ORIG_EMBALADAColumnName = "CANTIDAD_ORIG_EMBALADA";
		public const string CANTIDAD_ORIG_CAJAColumnName = "CANTIDAD_ORIG_CAJA";
		public const string CANTIDAD_UNITARIA_ORIG_TOTALColumnName = "CANTIDAD_UNITARIA_ORIG_TOTAL";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string COSTOS_IDColumnName = "COSTOS_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSFERENCIA_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_TRANSFERENCIA_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_TRANSFERENCIA_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_TRANSFERENCIA_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_TRANSFERENCIA_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			STOCK_TRANSFERENCIA_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_DETALLERow[] GetByCOSTOS_ID(decimal costos_id)
		{
			return GetByCOSTOS_ID(costos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetByCOSTOS_ID(decimal costos_id, bool costos_idNull)
		{
			return MapRecords(CreateGetByCOSTOS_IDCommand(costos_id, costos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOSTOS_IDAsDataTable(decimal costos_id)
		{
			return GetByCOSTOS_IDAsDataTable(costos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTOS_IDAsDataTable(decimal costos_id, bool costos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOSTOS_IDCommand(costos_id, costos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTOS_IDCommand(decimal costos_id, bool costos_idNull)
		{
			string whereSql = "";
			if(costos_idNull)
				whereSql += "COSTOS_ID IS NULL";
			else
				whereSql += "COSTOS_ID=" + _db.CreateSqlParameterName("COSTOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!costos_idNull)
				AddParameter(cmd, "COSTOS_ID", costos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
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
		/// return records by the <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_DETALLERow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
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
		/// return records by the <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_DETALLERow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_DETALLERow[] GetByTRANSFERENCIA_STOCK_ID(decimal transferencia_stock_id)
		{
			return GetByTRANSFERENCIA_STOCK_ID(transferencia_stock_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <param name="transferencia_stock_idNull">true if the method ignores the transferencia_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetByTRANSFERENCIA_STOCK_ID(decimal transferencia_stock_id, bool transferencia_stock_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_STOCK_IDCommand(transferencia_stock_id, transferencia_stock_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_STOCK_IDAsDataTable(decimal transferencia_stock_id)
		{
			return GetByTRANSFERENCIA_STOCK_IDAsDataTable(transferencia_stock_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <param name="transferencia_stock_idNull">true if the method ignores the transferencia_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_STOCK_IDAsDataTable(decimal transferencia_stock_id, bool transferencia_stock_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_STOCK_IDCommand(transferencia_stock_id, transferencia_stock_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <param name="transferencia_stock_idNull">true if the method ignores the transferencia_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_STOCK_IDCommand(decimal transferencia_stock_id, bool transferencia_stock_idNull)
		{
			string whereSql = "";
			if(transferencia_stock_idNull)
				whereSql += "TRANSFERENCIA_STOCK_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_STOCK_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_STOCK_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_stock_idNull)
				AddParameter(cmd, "TRANSFERENCIA_STOCK_ID", transferencia_stock_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetByUNIDAD_MEDIDA_DESTINO_ID(string unidad_medida_destino_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_DESTINO_IDAsDataTable(string unidad_medida_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(string unidad_medida_destino_id)
		{
			string whereSql = "";
			if(null == unidad_medida_destino_id)
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_medida_destino_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", unidad_medida_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_TRANSF_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_DETALLERow[] GetByUNIDAD_MEDIDA_ORIGEN_ID(string unidad_medida_origen_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_TRANSF_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_ORIGEN_IDAsDataTable(string unidad_medida_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_TRANSF_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(string unidad_medida_origen_id)
		{
			string whereSql = "";
			if(null == unidad_medida_origen_id)
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_medida_origen_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", unidad_medida_origen_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(STOCK_TRANSFERENCIA_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.STOCK_TRANSFERENCIA_DETALLE (" +
				"ID, " +
				"TRANSFERENCIA_STOCK_ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"UNIDAD_MEDIDA_DESTINO_ID, " +
				"CANTIDAD_DEST_UNITARIA, " +
				"CANTIDAD_DEST_EMBALADA, " +
				"CANTIDAD_DEST_CAJA, " +
				"COSTO_MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_COSTO, " +
				"OBSERVACION, " +
				"CANTIDAD_UNITARIA_DEST_TOTAL, " +
				"UNIDAD_MEDIDA_ORIGEN_ID, " +
				"CANTIDAD_ORIG_UNITARIA, " +
				"CANTIDAD_ORIG_EMBALADA, " +
				"CANTIDAD_ORIG_CAJA, " +
				"CANTIDAD_UNITARIA_ORIG_TOTAL, " +
				"FACTOR_CONVERSION, " +
				"COSTOS_ID, " +
				"PROVEEDOR_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_STOCK_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEST_UNITARIA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEST_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEST_CAJA") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_COSTO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_DEST_TOTAL") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIG_UNITARIA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIG_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIG_CAJA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_ORIG_TOTAL") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				_db.CreateSqlParameterName("COSTOS_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TRANSFERENCIA_STOCK_ID",
				value.IsTRANSFERENCIA_STOCK_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_STOCK_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", value.UNIDAD_MEDIDA_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_DEST_UNITARIA",
				value.IsCANTIDAD_DEST_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_DEST_UNITARIA);
			AddParameter(cmd, "CANTIDAD_DEST_EMBALADA",
				value.IsCANTIDAD_DEST_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_DEST_EMBALADA);
			AddParameter(cmd, "CANTIDAD_DEST_CAJA",
				value.IsCANTIDAD_DEST_CAJANull ? DBNull.Value : (object)value.CANTIDAD_DEST_CAJA);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_COSTO",
				value.IsMONTO_COSTONull ? DBNull.Value : (object)value.MONTO_COSTO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CANTIDAD_UNITARIA_DEST_TOTAL",
				value.IsCANTIDAD_UNITARIA_DEST_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_DEST_TOTAL);
			AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", value.UNIDAD_MEDIDA_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_ORIG_UNITARIA",
				value.IsCANTIDAD_ORIG_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_UNITARIA);
			AddParameter(cmd, "CANTIDAD_ORIG_EMBALADA",
				value.IsCANTIDAD_ORIG_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_EMBALADA);
			AddParameter(cmd, "CANTIDAD_ORIG_CAJA",
				value.IsCANTIDAD_ORIG_CAJANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_ORIG_TOTAL",
				value.IsCANTIDAD_UNITARIA_ORIG_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_ORIG_TOTAL);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTOS_ID",
				value.IsCOSTOS_IDNull ? DBNull.Value : (object)value.COSTOS_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(STOCK_TRANSFERENCIA_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.STOCK_TRANSFERENCIA_DETALLE SET " +
				"TRANSFERENCIA_STOCK_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_STOCK_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"UNIDAD_MEDIDA_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID") + ", " +
				"CANTIDAD_DEST_UNITARIA=" + _db.CreateSqlParameterName("CANTIDAD_DEST_UNITARIA") + ", " +
				"CANTIDAD_DEST_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_DEST_EMBALADA") + ", " +
				"CANTIDAD_DEST_CAJA=" + _db.CreateSqlParameterName("CANTIDAD_DEST_CAJA") + ", " +
				"COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_COSTO=" + _db.CreateSqlParameterName("MONTO_COSTO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CANTIDAD_UNITARIA_DEST_TOTAL=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_DEST_TOTAL") + ", " +
				"UNIDAD_MEDIDA_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID") + ", " +
				"CANTIDAD_ORIG_UNITARIA=" + _db.CreateSqlParameterName("CANTIDAD_ORIG_UNITARIA") + ", " +
				"CANTIDAD_ORIG_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_ORIG_EMBALADA") + ", " +
				"CANTIDAD_ORIG_CAJA=" + _db.CreateSqlParameterName("CANTIDAD_ORIG_CAJA") + ", " +
				"CANTIDAD_UNITARIA_ORIG_TOTAL=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_ORIG_TOTAL") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				"COSTOS_ID=" + _db.CreateSqlParameterName("COSTOS_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TRANSFERENCIA_STOCK_ID",
				value.IsTRANSFERENCIA_STOCK_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_STOCK_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", value.UNIDAD_MEDIDA_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_DEST_UNITARIA",
				value.IsCANTIDAD_DEST_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_DEST_UNITARIA);
			AddParameter(cmd, "CANTIDAD_DEST_EMBALADA",
				value.IsCANTIDAD_DEST_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_DEST_EMBALADA);
			AddParameter(cmd, "CANTIDAD_DEST_CAJA",
				value.IsCANTIDAD_DEST_CAJANull ? DBNull.Value : (object)value.CANTIDAD_DEST_CAJA);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_COSTO",
				value.IsMONTO_COSTONull ? DBNull.Value : (object)value.MONTO_COSTO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CANTIDAD_UNITARIA_DEST_TOTAL",
				value.IsCANTIDAD_UNITARIA_DEST_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_DEST_TOTAL);
			AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", value.UNIDAD_MEDIDA_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_ORIG_UNITARIA",
				value.IsCANTIDAD_ORIG_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_UNITARIA);
			AddParameter(cmd, "CANTIDAD_ORIG_EMBALADA",
				value.IsCANTIDAD_ORIG_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_EMBALADA);
			AddParameter(cmd, "CANTIDAD_ORIG_CAJA",
				value.IsCANTIDAD_ORIG_CAJANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_ORIG_TOTAL",
				value.IsCANTIDAD_UNITARIA_ORIG_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_ORIG_TOTAL);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTOS_ID",
				value.IsCOSTOS_IDNull ? DBNull.Value : (object)value.COSTOS_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>STOCK_TRANSFERENCIA_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>STOCK_TRANSFERENCIA_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(STOCK_TRANSFERENCIA_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTOS_ID(decimal costos_id)
		{
			return DeleteByCOSTOS_ID(costos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTOS_ID(decimal costos_id, bool costos_idNull)
		{
			return CreateDeleteByCOSTOS_IDCommand(costos_id, costos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANF_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTOS_IDCommand(decimal costos_id, bool costos_idNull)
		{
			string whereSql = "";
			if(costos_idNull)
				whereSql += "COSTOS_ID IS NULL";
			else
				whereSql += "COSTOS_ID=" + _db.CreateSqlParameterName("COSTOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!costos_idNull)
				AddParameter(cmd, "COSTOS_ID", costos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_TRANSF_DET_ARTICULO</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_TRANSF_DET_LOTE</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_STOCK_ID(decimal transferencia_stock_id)
		{
			return DeleteByTRANSFERENCIA_STOCK_ID(transferencia_stock_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <param name="transferencia_stock_idNull">true if the method ignores the transferencia_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_STOCK_ID(decimal transferencia_stock_id, bool transferencia_stock_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_STOCK_IDCommand(transferencia_stock_id, transferencia_stock_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_stock_id">The <c>TRANSFERENCIA_STOCK_ID</c> column value.</param>
		/// <param name="transferencia_stock_idNull">true if the method ignores the transferencia_stock_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_STOCK_IDCommand(decimal transferencia_stock_id, bool transferencia_stock_idNull)
		{
			string whereSql = "";
			if(transferencia_stock_idNull)
				whereSql += "TRANSFERENCIA_STOCK_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_STOCK_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_STOCK_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_stock_idNull)
				AddParameter(cmd, "TRANSFERENCIA_STOCK_ID", transferencia_stock_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_DESTINO_ID(string unidad_medida_destino_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_DESTINO_IDCommand(string unidad_medida_destino_id)
		{
			string whereSql = "";
			if(null == unidad_medida_destino_id)
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_medida_destino_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", unidad_medida_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table using the 
		/// <c>FK_STOCK_TRANSF_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_ORIGEN_ID(string unidad_medida_origen_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_TRANSF_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_ORIGEN_IDCommand(string unidad_medida_origen_id)
		{
			string whereSql = "";
			if(null == unidad_medida_origen_id)
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_medida_origen_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", unidad_medida_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>STOCK_TRANSFERENCIA_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>STOCK_TRANSFERENCIA_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.STOCK_TRANSFERENCIA_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		protected STOCK_TRANSFERENCIA_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		protected STOCK_TRANSFERENCIA_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> objects.</returns>
		protected virtual STOCK_TRANSFERENCIA_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int transferencia_stock_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_STOCK_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int unidad_medida_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_DESTINO_ID");
			int cantidad_dest_unitariaColumnIndex = reader.GetOrdinal("CANTIDAD_DEST_UNITARIA");
			int cantidad_dest_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_DEST_EMBALADA");
			int cantidad_dest_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_DEST_CAJA");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_costoColumnIndex = reader.GetOrdinal("MONTO_COSTO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cantidad_unitaria_dest_totalColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_DEST_TOTAL");
			int unidad_medida_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ORIGEN_ID");
			int cantidad_orig_unitariaColumnIndex = reader.GetOrdinal("CANTIDAD_ORIG_UNITARIA");
			int cantidad_orig_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_ORIG_EMBALADA");
			int cantidad_orig_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_ORIG_CAJA");
			int cantidad_unitaria_orig_totalColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_ORIG_TOTAL");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int costos_idColumnIndex = reader.GetOrdinal("COSTOS_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_TRANSFERENCIA_DETALLERow record = new STOCK_TRANSFERENCIA_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_stock_idColumnIndex))
						record.TRANSFERENCIA_STOCK_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_stock_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_destino_idColumnIndex))
						record.UNIDAD_MEDIDA_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_medida_destino_idColumnIndex));
					if(!reader.IsDBNull(cantidad_dest_unitariaColumnIndex))
						record.CANTIDAD_DEST_UNITARIA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dest_unitariaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_dest_embaladaColumnIndex))
						record.CANTIDAD_DEST_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dest_embaladaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_dest_cajaColumnIndex))
						record.CANTIDAD_DEST_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dest_cajaColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_idColumnIndex))
						record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_monedaColumnIndex))
						record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_costoColumnIndex))
						record.MONTO_COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_costoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(cantidad_unitaria_dest_totalColumnIndex))
						record.CANTIDAD_UNITARIA_DEST_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_dest_totalColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_origen_idColumnIndex))
						record.UNIDAD_MEDIDA_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_medida_origen_idColumnIndex));
					if(!reader.IsDBNull(cantidad_orig_unitariaColumnIndex))
						record.CANTIDAD_ORIG_UNITARIA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_orig_unitariaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_orig_embaladaColumnIndex))
						record.CANTIDAD_ORIG_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_orig_embaladaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_orig_cajaColumnIndex))
						record.CANTIDAD_ORIG_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_orig_cajaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_orig_totalColumnIndex))
						record.CANTIDAD_UNITARIA_ORIG_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_orig_totalColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(costos_idColumnIndex))
						record.COSTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costos_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_TRANSFERENCIA_DETALLERow[])(recordList.ToArray(typeof(STOCK_TRANSFERENCIA_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_TRANSFERENCIA_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_TRANSFERENCIA_DETALLERow"/> object.</returns>
		protected virtual STOCK_TRANSFERENCIA_DETALLERow MapRow(DataRow row)
		{
			STOCK_TRANSFERENCIA_DETALLERow mappedObject = new STOCK_TRANSFERENCIA_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_STOCK_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_STOCK_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_STOCK_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_DESTINO_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_DESTINO_ID = (string)row[dataColumn];
			// Column "CANTIDAD_DEST_UNITARIA"
			dataColumn = dataTable.Columns["CANTIDAD_DEST_UNITARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEST_UNITARIA = (decimal)row[dataColumn];
			// Column "CANTIDAD_DEST_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_DEST_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEST_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_DEST_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_DEST_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEST_CAJA = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO_COSTO"
			dataColumn = dataTable.Columns["MONTO_COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COSTO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_DEST_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_DEST_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_DEST_TOTAL = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ORIGEN_ID = (string)row[dataColumn];
			// Column "CANTIDAD_ORIG_UNITARIA"
			dataColumn = dataTable.Columns["CANTIDAD_ORIG_UNITARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIG_UNITARIA = (decimal)row[dataColumn];
			// Column "CANTIDAD_ORIG_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_ORIG_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIG_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_ORIG_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_ORIG_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIG_CAJA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_ORIG_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_ORIG_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_ORIG_TOTAL = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "COSTOS_ID"
			dataColumn = dataTable.Columns["COSTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTOS_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_TRANSFERENCIA_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_TRANSFERENCIA_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_STOCK_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEST_UNITARIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEST_EMBALADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEST_CAJA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_COSTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_DEST_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIG_UNITARIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIG_EMBALADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIG_CAJA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_ORIG_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
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

				case "TRANSFERENCIA_STOCK_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_DEST_UNITARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DEST_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DEST_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_UNITARIA_DEST_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_ORIG_UNITARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ORIG_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ORIG_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_ORIG_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_TRANSFERENCIA_DETALLECollection_Base class
}  // End of namespace
