// <fileinfo name="STOCK_AJUSTE_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="STOCK_AJUSTE_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_AJUSTE_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_AJUSTE_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string STOCK_AJUSTE_IDColumnName = "STOCK_AJUSTE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string UNIDAD_MEDIDA_DESTINO_IDColumnName = "UNIDAD_MEDIDA_DESTINO_ID";
		public const string CANTIDAD_DESTINOColumnName = "CANTIDAD_DESTINO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string UNIDAD_MEDIDA_ORIGEN_IDColumnName = "UNIDAD_MEDIDA_ORIGEN_ID";
		public const string CANTIDAD_ORIGENColumnName = "CANTIDAD_ORIGEN";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string COSTO_TOTALColumnName = "COSTO_TOTAL";
		public const string COSTO_UNITARIOColumnName = "COSTO_UNITARIO";
		public const string AJUSTADOColumnName = "AJUSTADO";
		public const string INVENTARIO_CANT_SISTEMAColumnName = "INVENTARIO_CANT_SISTEMA";
		public const string INVENTARIO_CANT_ENCONTRADAColumnName = "INVENTARIO_CANT_ENCONTRADA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_AJUSTE_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_AJUSTE_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_AJUSTE_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_AJUSTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_AJUSTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_AJUSTE_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_AJUSTE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_AJUSTE_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_AJUSTE_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public STOCK_AJUSTE_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_AJUSTE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="STOCK_AJUSTE_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="STOCK_AJUSTE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual STOCK_AJUSTE_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			STOCK_AJUSTE_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public STOCK_AJUSTE_DETALLERow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DET_UNID_DES</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetByUNIDAD_MEDIDA_DESTINO_ID(string unidad_medida_destino_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DET_UNID_DES</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_DESTINO_IDAsDataTable(string unidad_medida_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_AJUSTE_DET_UNID_DES</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DET_UNID_ORI</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetByUNIDAD_MEDIDA_ORIGEN_ID(string unidad_medida_origen_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DET_UNID_ORI</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_ORIGEN_IDAsDataTable(string unidad_medida_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_AJUSTE_DET_UNID_ORI</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public STOCK_AJUSTE_DETALLERow[] GetBySTOCK_AJUSTE_ID(decimal stock_ajuste_id)
		{
			return GetBySTOCK_AJUSTE_ID(stock_ajuste_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <param name="stock_ajuste_idNull">true if the method ignores the stock_ajuste_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetBySTOCK_AJUSTE_ID(decimal stock_ajuste_id, bool stock_ajuste_idNull)
		{
			return MapRecords(CreateGetBySTOCK_AJUSTE_IDCommand(stock_ajuste_id, stock_ajuste_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySTOCK_AJUSTE_IDAsDataTable(decimal stock_ajuste_id)
		{
			return GetBySTOCK_AJUSTE_IDAsDataTable(stock_ajuste_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <param name="stock_ajuste_idNull">true if the method ignores the stock_ajuste_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySTOCK_AJUSTE_IDAsDataTable(decimal stock_ajuste_id, bool stock_ajuste_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySTOCK_AJUSTE_IDCommand(stock_ajuste_id, stock_ajuste_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <param name="stock_ajuste_idNull">true if the method ignores the stock_ajuste_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySTOCK_AJUSTE_IDCommand(decimal stock_ajuste_id, bool stock_ajuste_idNull)
		{
			string whereSql = "";
			if(stock_ajuste_idNull)
				whereSql += "STOCK_AJUSTE_ID IS NULL";
			else
				whereSql += "STOCK_AJUSTE_ID=" + _db.CreateSqlParameterName("STOCK_AJUSTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!stock_ajuste_idNull)
				AddParameter(cmd, "STOCK_AJUSTE_ID", stock_ajuste_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public STOCK_AJUSTE_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
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
		/// return records by the <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public STOCK_AJUSTE_DETALLERow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		public virtual STOCK_AJUSTE_DETALLERow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
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
		/// return records by the <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
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
		/// Adds a new record into the <c>STOCK_AJUSTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_AJUSTE_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(STOCK_AJUSTE_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.STOCK_AJUSTE_DETALLE (" +
				"ID, " +
				"STOCK_AJUSTE_ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"UNIDAD_MEDIDA_DESTINO_ID, " +
				"CANTIDAD_DESTINO, " +
				"OBSERVACION, " +
				"UNIDAD_MEDIDA_ORIGEN_ID, " +
				"CANTIDAD_ORIGEN, " +
				"FACTOR_CONVERSION, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"COSTO_TOTAL, " +
				"COSTO_UNITARIO, " +
				"AJUSTADO, " +
				"INVENTARIO_CANT_SISTEMA, " +
				"INVENTARIO_CANT_ENCONTRADA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("STOCK_AJUSTE_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DESTINO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("COSTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("COSTO_UNITARIO") + ", " +
				_db.CreateSqlParameterName("AJUSTADO") + ", " +
				_db.CreateSqlParameterName("INVENTARIO_CANT_SISTEMA") + ", " +
				_db.CreateSqlParameterName("INVENTARIO_CANT_ENCONTRADA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "STOCK_AJUSTE_ID",
				value.IsSTOCK_AJUSTE_IDNull ? DBNull.Value : (object)value.STOCK_AJUSTE_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", value.UNIDAD_MEDIDA_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_DESTINO",
				value.IsCANTIDAD_DESTINONull ? DBNull.Value : (object)value.CANTIDAD_DESTINO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", value.UNIDAD_MEDIDA_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_ORIGEN",
				value.IsCANTIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_ORIGEN);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "COSTO_TOTAL",
				value.IsCOSTO_TOTALNull ? DBNull.Value : (object)value.COSTO_TOTAL);
			AddParameter(cmd, "COSTO_UNITARIO",
				value.IsCOSTO_UNITARIONull ? DBNull.Value : (object)value.COSTO_UNITARIO);
			AddParameter(cmd, "AJUSTADO", value.AJUSTADO);
			AddParameter(cmd, "INVENTARIO_CANT_SISTEMA",
				value.IsINVENTARIO_CANT_SISTEMANull ? DBNull.Value : (object)value.INVENTARIO_CANT_SISTEMA);
			AddParameter(cmd, "INVENTARIO_CANT_ENCONTRADA",
				value.IsINVENTARIO_CANT_ENCONTRADANull ? DBNull.Value : (object)value.INVENTARIO_CANT_ENCONTRADA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>STOCK_AJUSTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_AJUSTE_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(STOCK_AJUSTE_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.STOCK_AJUSTE_DETALLE SET " +
				"STOCK_AJUSTE_ID=" + _db.CreateSqlParameterName("STOCK_AJUSTE_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"UNIDAD_MEDIDA_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID") + ", " +
				"CANTIDAD_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_DESTINO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"UNIDAD_MEDIDA_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID") + ", " +
				"CANTIDAD_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_ORIGEN") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"COSTO_TOTAL=" + _db.CreateSqlParameterName("COSTO_TOTAL") + ", " +
				"COSTO_UNITARIO=" + _db.CreateSqlParameterName("COSTO_UNITARIO") + ", " +
				"AJUSTADO=" + _db.CreateSqlParameterName("AJUSTADO") + ", " +
				"INVENTARIO_CANT_SISTEMA=" + _db.CreateSqlParameterName("INVENTARIO_CANT_SISTEMA") + ", " +
				"INVENTARIO_CANT_ENCONTRADA=" + _db.CreateSqlParameterName("INVENTARIO_CANT_ENCONTRADA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "STOCK_AJUSTE_ID",
				value.IsSTOCK_AJUSTE_IDNull ? DBNull.Value : (object)value.STOCK_AJUSTE_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", value.UNIDAD_MEDIDA_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_DESTINO",
				value.IsCANTIDAD_DESTINONull ? DBNull.Value : (object)value.CANTIDAD_DESTINO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", value.UNIDAD_MEDIDA_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_ORIGEN",
				value.IsCANTIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_ORIGEN);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "COSTO_TOTAL",
				value.IsCOSTO_TOTALNull ? DBNull.Value : (object)value.COSTO_TOTAL);
			AddParameter(cmd, "COSTO_UNITARIO",
				value.IsCOSTO_UNITARIONull ? DBNull.Value : (object)value.COSTO_UNITARIO);
			AddParameter(cmd, "AJUSTADO", value.AJUSTADO);
			AddParameter(cmd, "INVENTARIO_CANT_SISTEMA",
				value.IsINVENTARIO_CANT_SISTEMANull ? DBNull.Value : (object)value.INVENTARIO_CANT_SISTEMA);
			AddParameter(cmd, "INVENTARIO_CANT_ENCONTRADA",
				value.IsINVENTARIO_CANT_ENCONTRADANull ? DBNull.Value : (object)value.INVENTARIO_CANT_ENCONTRADA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>STOCK_AJUSTE_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>STOCK_AJUSTE_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>STOCK_AJUSTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_AJUSTE_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(STOCK_AJUSTE_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>STOCK_AJUSTE_DETALLE</c> table using
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
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id, moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_AJUSTE_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DET_UNID_DES</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_DESTINO_ID(string unidad_medida_destino_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_AJUSTE_DET_UNID_DES</c> foreign key.
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
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DET_UNID_ORI</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_ORIGEN_ID(string unidad_medida_origen_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_AJUSTE_DET_UNID_ORI</c> foreign key.
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
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySTOCK_AJUSTE_ID(decimal stock_ajuste_id)
		{
			return DeleteBySTOCK_AJUSTE_ID(stock_ajuste_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <param name="stock_ajuste_idNull">true if the method ignores the stock_ajuste_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySTOCK_AJUSTE_ID(decimal stock_ajuste_id, bool stock_ajuste_idNull)
		{
			return CreateDeleteBySTOCK_AJUSTE_IDCommand(stock_ajuste_id, stock_ajuste_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_AJUSTE_DETALLE_AJUST</c> foreign key.
		/// </summary>
		/// <param name="stock_ajuste_id">The <c>STOCK_AJUSTE_ID</c> column value.</param>
		/// <param name="stock_ajuste_idNull">true if the method ignores the stock_ajuste_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySTOCK_AJUSTE_IDCommand(decimal stock_ajuste_id, bool stock_ajuste_idNull)
		{
			string whereSql = "";
			if(stock_ajuste_idNull)
				whereSql += "STOCK_AJUSTE_ID IS NULL";
			else
				whereSql += "STOCK_AJUSTE_ID=" + _db.CreateSqlParameterName("STOCK_AJUSTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!stock_ajuste_idNull)
				AddParameter(cmd, "STOCK_AJUSTE_ID", stock_ajuste_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_AJUSTE_DETALLE_ARTIC</c> foreign key.
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
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_AJUSTE_DETALLE</c> table using the 
		/// <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
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
		/// delete records using the <c>FK_STOCK_AJUSTE_DETALLE_LOTE</c> foreign key.
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
		/// Deletes <c>STOCK_AJUSTE_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>STOCK_AJUSTE_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.STOCK_AJUSTE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>STOCK_AJUSTE_DETALLE</c> table.
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
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		protected STOCK_AJUSTE_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		protected STOCK_AJUSTE_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_AJUSTE_DETALLERow"/> objects.</returns>
		protected virtual STOCK_AJUSTE_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int stock_ajuste_idColumnIndex = reader.GetOrdinal("STOCK_AJUSTE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int unidad_medida_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_DESTINO_ID");
			int cantidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_DESTINO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int unidad_medida_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ORIGEN_ID");
			int cantidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_ORIGEN");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int costo_totalColumnIndex = reader.GetOrdinal("COSTO_TOTAL");
			int costo_unitarioColumnIndex = reader.GetOrdinal("COSTO_UNITARIO");
			int ajustadoColumnIndex = reader.GetOrdinal("AJUSTADO");
			int inventario_cant_sistemaColumnIndex = reader.GetOrdinal("INVENTARIO_CANT_SISTEMA");
			int inventario_cant_encontradaColumnIndex = reader.GetOrdinal("INVENTARIO_CANT_ENCONTRADA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_AJUSTE_DETALLERow record = new STOCK_AJUSTE_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(stock_ajuste_idColumnIndex))
						record.STOCK_AJUSTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(stock_ajuste_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_destino_idColumnIndex))
						record.UNIDAD_MEDIDA_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_medida_destino_idColumnIndex));
					if(!reader.IsDBNull(cantidad_destinoColumnIndex))
						record.CANTIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(unidad_medida_origen_idColumnIndex))
						record.UNIDAD_MEDIDA_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_medida_origen_idColumnIndex));
					if(!reader.IsDBNull(cantidad_origenColumnIndex))
						record.CANTIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_origenColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_totalColumnIndex))
						record.COSTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_totalColumnIndex)), 9);
					if(!reader.IsDBNull(costo_unitarioColumnIndex))
						record.COSTO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(ajustadoColumnIndex))
						record.AJUSTADO = Convert.ToString(reader.GetValue(ajustadoColumnIndex));
					if(!reader.IsDBNull(inventario_cant_sistemaColumnIndex))
						record.INVENTARIO_CANT_SISTEMA = Math.Round(Convert.ToDecimal(reader.GetValue(inventario_cant_sistemaColumnIndex)), 9);
					if(!reader.IsDBNull(inventario_cant_encontradaColumnIndex))
						record.INVENTARIO_CANT_ENCONTRADA = Math.Round(Convert.ToDecimal(reader.GetValue(inventario_cant_encontradaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_AJUSTE_DETALLERow[])(recordList.ToArray(typeof(STOCK_AJUSTE_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_AJUSTE_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_AJUSTE_DETALLERow"/> object.</returns>
		protected virtual STOCK_AJUSTE_DETALLERow MapRow(DataRow row)
		{
			STOCK_AJUSTE_DETALLERow mappedObject = new STOCK_AJUSTE_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "STOCK_AJUSTE_ID"
			dataColumn = dataTable.Columns["STOCK_AJUSTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.STOCK_AJUSTE_ID = (decimal)row[dataColumn];
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
			// Column "CANTIDAD_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DESTINO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ORIGEN_ID = (string)row[dataColumn];
			// Column "CANTIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO_TOTAL"
			dataColumn = dataTable.Columns["COSTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TOTAL = (decimal)row[dataColumn];
			// Column "COSTO_UNITARIO"
			dataColumn = dataTable.Columns["COSTO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_UNITARIO = (decimal)row[dataColumn];
			// Column "AJUSTADO"
			dataColumn = dataTable.Columns["AJUSTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTADO = (string)row[dataColumn];
			// Column "INVENTARIO_CANT_SISTEMA"
			dataColumn = dataTable.Columns["INVENTARIO_CANT_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVENTARIO_CANT_SISTEMA = (decimal)row[dataColumn];
			// Column "INVENTARIO_CANT_ENCONTRADA"
			dataColumn = dataTable.Columns["INVENTARIO_CANT_ENCONTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVENTARIO_CANT_ENCONTRADA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_AJUSTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_AJUSTE_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("STOCK_AJUSTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DESTINO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_UNITARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AJUSTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("INVENTARIO_CANT_SISTEMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INVENTARIO_CANT_ENCONTRADA", typeof(decimal));
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

				case "STOCK_AJUSTE_ID":
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

				case "CANTIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				case "UNIDAD_MEDIDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INVENTARIO_CANT_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INVENTARIO_CANT_ENCONTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_AJUSTE_DETALLECollection_Base class
}  // End of namespace
