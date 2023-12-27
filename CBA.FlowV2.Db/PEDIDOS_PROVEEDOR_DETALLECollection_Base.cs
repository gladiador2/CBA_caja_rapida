// <fileinfo name="PEDIDOS_PROVEEDOR_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_PROVEEDOR_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PEDIDOS_PROVEEDOR_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_PROVEEDOR_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PEDIDOS_PROVEEDOR_IDColumnName = "PEDIDOS_PROVEEDOR_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string UNIDAD_IDColumnName = "UNIDAD_ID";
		public const string CANTIDAD_EMBALADAColumnName = "CANTIDAD_EMBALADA";
		public const string CANTIDAD_UNIDADColumnName = "CANTIDAD_UNIDAD";
		public const string CANTIDAD_POR_CAJAColumnName = "CANTIDAD_POR_CAJA";
		public const string CANTIDAD_UNITARIA_TOTALColumnName = "CANTIDAD_UNITARIA_TOTAL";
		public const string PRECIO_BRUTOColumnName = "PRECIO_BRUTO";
		public const string PRECIO_CON_DTOColumnName = "PRECIO_CON_DTO";
		public const string PORCENTAJE_DTOColumnName = "PORCENTAJE_DTO";
		public const string IMPUESTO_PORCENTAJEColumnName = "IMPUESTO_PORCENTAJE";
		public const string TOTAL_MONTO_BRUTOColumnName = "TOTAL_MONTO_BRUTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_MONTO_IMPUESTO_DTOColumnName = "TOTAL_MONTO_IMPUESTO_DTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string LOTE_IDColumnName = "LOTE_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_PROVEEDOR_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PEDIDOS_PROVEEDOR_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PEDIDOS_PROVEEDOR_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PEDIDOS_PROVEEDOR_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public PEDIDOS_PROVEEDOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PEDIDOS_PROVEEDOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PEDIDOS_PROVEEDOR_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PEDIDOS_PROVEEDOR_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public PEDIDOS_PROVEEDOR_DETALLERow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_DETALLERow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
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
		/// return records by the <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
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
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_PROV_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_PROV_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_PROV_DET_ARTICULO</c> foreign key.
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
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_PROV_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_proveedor_id">The <c>PEDIDOS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_DETALLERow[] GetByPEDIDOS_PROVEEDOR_ID(decimal pedidos_proveedor_id)
		{
			return MapRecords(CreateGetByPEDIDOS_PROVEEDOR_IDCommand(pedidos_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_PROV_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_proveedor_id">The <c>PEDIDOS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPEDIDOS_PROVEEDOR_IDAsDataTable(decimal pedidos_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByPEDIDOS_PROVEEDOR_IDCommand(pedidos_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_PROV_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_proveedor_id">The <c>PEDIDOS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPEDIDOS_PROVEEDOR_IDCommand(decimal pedidos_proveedor_id)
		{
			string whereSql = "";
			whereSql += "PEDIDOS_PROVEEDOR_ID=" + _db.CreateSqlParameterName("PEDIDOS_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PEDIDOS_PROVEEDOR_ID", pedidos_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_PROV_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDOR_DETALLERow[] GetByUNIDAD_ID(string unidad_id)
		{
			return MapRecords(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_PROV_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_IDAsDataTable(string unidad_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_PROV_UNIDAD</c> foreign key.
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
		/// Adds a new record into the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(PEDIDOS_PROVEEDOR_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PEDIDOS_PROVEEDOR_DETALLE (" +
				"ID, " +
				"PEDIDOS_PROVEEDOR_ID, " +
				"ARTICULO_ID, " +
				"UNIDAD_ID, " +
				"CANTIDAD_EMBALADA, " +
				"CANTIDAD_UNIDAD, " +
				"CANTIDAD_POR_CAJA, " +
				"CANTIDAD_UNITARIA_TOTAL, " +
				"PRECIO_BRUTO, " +
				"PRECIO_CON_DTO, " +
				"PORCENTAJE_DTO, " +
				"IMPUESTO_PORCENTAJE, " +
				"TOTAL_MONTO_BRUTO, " +
				"TOTAL_MONTO_DTO, " +
				"TOTAL_MONTO_IMPUESTO_DTO, " +
				"TOTAL_NETO, " +
				"LOTE_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PEDIDOS_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL") + ", " +
				_db.CreateSqlParameterName("PRECIO_BRUTO") + ", " +
				_db.CreateSqlParameterName("PRECIO_CON_DTO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DTO") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_BRUTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_DTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_IMPUESTO_DTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_NETO") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PEDIDOS_PROVEEDOR_ID", value.PEDIDOS_PROVEEDOR_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_UNIDAD", value.CANTIDAD_UNIDAD);
			AddParameter(cmd, "CANTIDAD_POR_CAJA", value.CANTIDAD_POR_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL", value.CANTIDAD_UNITARIA_TOTAL);
			AddParameter(cmd, "PRECIO_BRUTO", value.PRECIO_BRUTO);
			AddParameter(cmd, "PRECIO_CON_DTO", value.PRECIO_CON_DTO);
			AddParameter(cmd, "PORCENTAJE_DTO", value.PORCENTAJE_DTO);
			AddParameter(cmd, "IMPUESTO_PORCENTAJE",
				value.IsIMPUESTO_PORCENTAJENull ? DBNull.Value : (object)value.IMPUESTO_PORCENTAJE);
			AddParameter(cmd, "TOTAL_MONTO_BRUTO", value.TOTAL_MONTO_BRUTO);
			AddParameter(cmd, "TOTAL_MONTO_DTO", value.TOTAL_MONTO_DTO);
			AddParameter(cmd, "TOTAL_MONTO_IMPUESTO_DTO", value.TOTAL_MONTO_IMPUESTO_DTO);
			AddParameter(cmd, "TOTAL_NETO", value.TOTAL_NETO);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PEDIDOS_PROVEEDOR_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.PEDIDOS_PROVEEDOR_DETALLE SET " +
				"PEDIDOS_PROVEEDOR_ID=" + _db.CreateSqlParameterName("PEDIDOS_PROVEEDOR_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				"CANTIDAD_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				"CANTIDAD_UNIDAD=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD") + ", " +
				"CANTIDAD_POR_CAJA=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA") + ", " +
				"CANTIDAD_UNITARIA_TOTAL=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL") + ", " +
				"PRECIO_BRUTO=" + _db.CreateSqlParameterName("PRECIO_BRUTO") + ", " +
				"PRECIO_CON_DTO=" + _db.CreateSqlParameterName("PRECIO_CON_DTO") + ", " +
				"PORCENTAJE_DTO=" + _db.CreateSqlParameterName("PORCENTAJE_DTO") + ", " +
				"IMPUESTO_PORCENTAJE=" + _db.CreateSqlParameterName("IMPUESTO_PORCENTAJE") + ", " +
				"TOTAL_MONTO_BRUTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_BRUTO") + ", " +
				"TOTAL_MONTO_DTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_DTO") + ", " +
				"TOTAL_MONTO_IMPUESTO_DTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_IMPUESTO_DTO") + ", " +
				"TOTAL_NETO=" + _db.CreateSqlParameterName("TOTAL_NETO") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PEDIDOS_PROVEEDOR_ID", value.PEDIDOS_PROVEEDOR_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_UNIDAD", value.CANTIDAD_UNIDAD);
			AddParameter(cmd, "CANTIDAD_POR_CAJA", value.CANTIDAD_POR_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL", value.CANTIDAD_UNITARIA_TOTAL);
			AddParameter(cmd, "PRECIO_BRUTO", value.PRECIO_BRUTO);
			AddParameter(cmd, "PRECIO_CON_DTO", value.PRECIO_CON_DTO);
			AddParameter(cmd, "PORCENTAJE_DTO", value.PORCENTAJE_DTO);
			AddParameter(cmd, "IMPUESTO_PORCENTAJE",
				value.IsIMPUESTO_PORCENTAJENull ? DBNull.Value : (object)value.IMPUESTO_PORCENTAJE);
			AddParameter(cmd, "TOTAL_MONTO_BRUTO", value.TOTAL_MONTO_BRUTO);
			AddParameter(cmd, "TOTAL_MONTO_DTO", value.TOTAL_MONTO_DTO);
			AddParameter(cmd, "TOTAL_MONTO_IMPUESTO_DTO", value.TOTAL_MONTO_IMPUESTO_DTO);
			AddParameter(cmd, "TOTAL_NETO", value.TOTAL_NETO);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PEDIDOS_PROVEEDOR_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table using
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
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
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
		/// delete records using the <c>FK_PEDIDIO_PROV_LOTE</c> foreign key.
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
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_PROV_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_PROV_DET_ARTICULO</c> foreign key.
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
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_PROV_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_proveedor_id">The <c>PEDIDOS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPEDIDOS_PROVEEDOR_ID(decimal pedidos_proveedor_id)
		{
			return CreateDeleteByPEDIDOS_PROVEEDOR_IDCommand(pedidos_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_PROV_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_proveedor_id">The <c>PEDIDOS_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPEDIDOS_PROVEEDOR_IDCommand(decimal pedidos_proveedor_id)
		{
			string whereSql = "";
			whereSql += "PEDIDOS_PROVEEDOR_ID=" + _db.CreateSqlParameterName("PEDIDOS_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PEDIDOS_PROVEEDOR_ID", pedidos_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_PROV_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ID(string unidad_id)
		{
			return CreateDeleteByUNIDAD_IDCommand(unidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_PROV_UNIDAD</c> foreign key.
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
		/// Deletes <c>PEDIDOS_PROVEEDOR_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>PEDIDOS_PROVEEDOR_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PEDIDOS_PROVEEDOR_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected PEDIDOS_PROVEEDOR_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected PEDIDOS_PROVEEDOR_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> objects.</returns>
		protected virtual PEDIDOS_PROVEEDOR_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pedidos_proveedor_idColumnIndex = reader.GetOrdinal("PEDIDOS_PROVEEDOR_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int unidad_idColumnIndex = reader.GetOrdinal("UNIDAD_ID");
			int cantidad_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA");
			int cantidad_unidadColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD");
			int cantidad_por_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA");
			int cantidad_unitaria_totalColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL");
			int precio_brutoColumnIndex = reader.GetOrdinal("PRECIO_BRUTO");
			int precio_con_dtoColumnIndex = reader.GetOrdinal("PRECIO_CON_DTO");
			int porcentaje_dtoColumnIndex = reader.GetOrdinal("PORCENTAJE_DTO");
			int impuesto_porcentajeColumnIndex = reader.GetOrdinal("IMPUESTO_PORCENTAJE");
			int total_monto_brutoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_monto_impuesto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO_DTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PEDIDOS_PROVEEDOR_DETALLERow record = new PEDIDOS_PROVEEDOR_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PEDIDOS_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pedidos_proveedor_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.UNIDAD_ID = Convert.ToString(reader.GetValue(unidad_idColumnIndex));
					record.CANTIDAD_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embaladaColumnIndex)), 9);
					record.CANTIDAD_UNIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidadColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_cajaColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_totalColumnIndex)), 9);
					record.PRECIO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_brutoColumnIndex)), 9);
					record.PRECIO_CON_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_con_dtoColumnIndex)), 9);
					record.PORCENTAJE_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_dtoColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_porcentajeColumnIndex))
						record.IMPUESTO_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_porcentajeColumnIndex)), 9);
					record.TOTAL_MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_brutoColumnIndex)), 9);
					record.TOTAL_MONTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_dtoColumnIndex)), 9);
					record.TOTAL_MONTO_IMPUESTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuesto_dtoColumnIndex)), 9);
					record.TOTAL_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_netoColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PEDIDOS_PROVEEDOR_DETALLERow[])(recordList.ToArray(typeof(PEDIDOS_PROVEEDOR_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PEDIDOS_PROVEEDOR_DETALLERow"/> object.</returns>
		protected virtual PEDIDOS_PROVEEDOR_DETALLERow MapRow(DataRow row)
		{
			PEDIDOS_PROVEEDOR_DETALLERow mappedObject = new PEDIDOS_PROVEEDOR_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PEDIDOS_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PEDIDOS_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PEDIDOS_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_ID"
			dataColumn = dataTable.Columns["UNIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID = (string)row[dataColumn];
			// Column "CANTIDAD_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL = (decimal)row[dataColumn];
			// Column "PRECIO_BRUTO"
			dataColumn = dataTable.Columns["PRECIO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_BRUTO = (decimal)row[dataColumn];
			// Column "PRECIO_CON_DTO"
			dataColumn = dataTable.Columns["PRECIO_CON_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_CON_DTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DTO"
			dataColumn = dataTable.Columns["PORCENTAJE_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DTO = (decimal)row[dataColumn];
			// Column "IMPUESTO_PORCENTAJE"
			dataColumn = dataTable.Columns["IMPUESTO_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_PORCENTAJE = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_DTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_DTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_IMPUESTO_DTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_IMPUESTO_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_IMPUESTO_DTO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO"
			dataColumn = dataTable.Columns["TOTAL_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PEDIDOS_PROVEEDOR_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PEDIDOS_PROVEEDOR_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PEDIDOS_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRECIO_BRUTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRECIO_CON_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPUESTO_PORCENTAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
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

				case "PEDIDOS_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_CON_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_IMPUESTO_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PEDIDOS_PROVEEDOR_DETALLECollection_Base class
}  // End of namespace
