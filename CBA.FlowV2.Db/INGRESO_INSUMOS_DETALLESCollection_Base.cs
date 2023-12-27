// <fileinfo name="INGRESO_INSUMOS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="INGRESO_INSUMOS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INGRESO_INSUMOS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INGRESO_INSUMOS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string CANTIDAD_BLColumnName = "CANTIDAD_BL";
		public const string CANTIDAD_DRAFTColumnName = "CANTIDAD_DRAFT";
		public const string CANTIDAD_BASCULAColumnName = "CANTIDAD_BASCULA";
		public const string CANTIDAD_REMISIONColumnName = "CANTIDAD_REMISION";
		public const string BOX_IDColumnName = "BOX_ID";
		public const string MERMAColumnName = "MERMA";
		public const string UNIDAD_IDColumnName = "UNIDAD_ID";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string NRO_TICKET_BASCULAColumnName = "NRO_TICKET_BASCULA";
		public const string INGRESO_IDColumnName = "INGRESO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string USAR_CANTIDAD_BLColumnName = "USAR_CANTIDAD_BL";
		public const string USAR_CANTIDAD_DRAFTColumnName = "USAR_CANTIDAD_DRAFT";
		public const string USAR_CANTIDAD_BASCULAColumnName = "USAR_CANTIDAD_BASCULA";
		public const string USAR_CANTIDAD_REMISIONColumnName = "USAR_CANTIDAD_REMISION";
		public const string PRESENTACION_IDColumnName = "PRESENTACION_ID";
		public const string CANTIDAD_PRESENTACIONColumnName = "CANTIDAD_PRESENTACION";
		public const string CANTIDAD_DE_PRESENTACIONColumnName = "CANTIDAD_DE_PRESENTACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INGRESO_INSUMOS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INGRESO_INSUMOS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INGRESO_INSUMOS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INGRESO_INSUMOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INGRESO_INSUMOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INGRESO_INSUMOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INGRESO_INSUMOS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INGRESO_INSUMOS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public INGRESO_INSUMOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INGRESO_INSUMOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="INGRESO_INSUMOS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="INGRESO_INSUMOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			INGRESO_INSUMOS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public INGRESO_INSUMOS_DETALLESRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
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
		/// return records by the <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_INGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_id">The <c>INGRESO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetByINGRESO_ID(decimal ingreso_id)
		{
			return MapRecords(CreateGetByINGRESO_IDCommand(ingreso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_INGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_id">The <c>INGRESO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINGRESO_IDAsDataTable(decimal ingreso_id)
		{
			return MapRecordsToDataTable(CreateGetByINGRESO_IDCommand(ingreso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INGRE_INSUM_DET_INGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_id">The <c>INGRESO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINGRESO_IDCommand(decimal ingreso_id)
		{
			string whereSql = "";
			whereSql += "INGRESO_ID=" + _db.CreateSqlParameterName("INGRESO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "INGRESO_ID", ingreso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public INGRESO_INSUMOS_DETALLESRow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
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
		/// return records by the <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
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
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public INGRESO_INSUMOS_DETALLESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public INGRESO_INSUMOS_DETALLESRow[] GetByPRESENTACION_ID(decimal presentacion_id)
		{
			return GetByPRESENTACION_ID(presentacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetByPRESENTACION_ID(decimal presentacion_id, bool presentacion_idNull)
		{
			return MapRecords(CreateGetByPRESENTACION_IDCommand(presentacion_id, presentacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPRESENTACION_IDAsDataTable(decimal presentacion_id)
		{
			return GetByPRESENTACION_IDAsDataTable(presentacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPRESENTACION_IDAsDataTable(decimal presentacion_id, bool presentacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPRESENTACION_IDCommand(presentacion_id, presentacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPRESENTACION_IDCommand(decimal presentacion_id, bool presentacion_idNull)
		{
			string whereSql = "";
			if(presentacion_idNull)
				whereSql += "PRESENTACION_ID IS NULL";
			else
				whereSql += "PRESENTACION_ID=" + _db.CreateSqlParameterName("PRESENTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!presentacion_idNull)
				AddParameter(cmd, "PRESENTACION_ID", presentacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects 
		/// by the <c>FK_INGRE_INSUM_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		public virtual INGRESO_INSUMOS_DETALLESRow[] GetByUNIDAD_ID(string unidad_id)
		{
			return MapRecords(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INGRE_INSUM_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_IDAsDataTable(string unidad_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INGRE_INSUM_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_IDCommand(string unidad_id)
		{
			string whereSql = "";
			if(null == unidad_id)
				whereSql += "UNIDAD_ID IS NULL";
			else
				whereSql += "UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_id)
				AddParameter(cmd, "UNIDAD_ID", unidad_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>INGRESO_INSUMOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_INSUMOS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(INGRESO_INSUMOS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.INGRESO_INSUMOS_DETALLES (" +
				"ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"CANTIDAD_BL, " +
				"CANTIDAD_DRAFT, " +
				"CANTIDAD_BASCULA, " +
				"CANTIDAD_REMISION, " +
				"BOX_ID, " +
				"MERMA, " +
				"UNIDAD_ID, " +
				"CHAPA_CARRETA, " +
				"CHAPA_CAMION, " +
				"CHOFER_DOCUMENTO, " +
				"CHOFER_NOMBRE, " +
				"NRO_TICKET_BASCULA, " +
				"INGRESO_ID, " +
				"PERSONA_ID, " +
				"USAR_CANTIDAD_BL, " +
				"USAR_CANTIDAD_DRAFT, " +
				"USAR_CANTIDAD_BASCULA, " +
				"USAR_CANTIDAD_REMISION, " +
				"PRESENTACION_ID, " +
				"CANTIDAD_PRESENTACION, " +
				"CANTIDAD_DE_PRESENTACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_BL") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DRAFT") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_BASCULA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_REMISION") + ", " +
				_db.CreateSqlParameterName("BOX_ID") + ", " +
				_db.CreateSqlParameterName("MERMA") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				_db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				_db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				_db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("NRO_TICKET_BASCULA") + ", " +
				_db.CreateSqlParameterName("INGRESO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("USAR_CANTIDAD_BL") + ", " +
				_db.CreateSqlParameterName("USAR_CANTIDAD_DRAFT") + ", " +
				_db.CreateSqlParameterName("USAR_CANTIDAD_BASCULA") + ", " +
				_db.CreateSqlParameterName("USAR_CANTIDAD_REMISION") + ", " +
				_db.CreateSqlParameterName("PRESENTACION_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_PRESENTACION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DE_PRESENTACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_BL",
				value.IsCANTIDAD_BLNull ? DBNull.Value : (object)value.CANTIDAD_BL);
			AddParameter(cmd, "CANTIDAD_DRAFT",
				value.IsCANTIDAD_DRAFTNull ? DBNull.Value : (object)value.CANTIDAD_DRAFT);
			AddParameter(cmd, "CANTIDAD_BASCULA",
				value.IsCANTIDAD_BASCULANull ? DBNull.Value : (object)value.CANTIDAD_BASCULA);
			AddParameter(cmd, "CANTIDAD_REMISION",
				value.IsCANTIDAD_REMISIONNull ? DBNull.Value : (object)value.CANTIDAD_REMISION);
			AddParameter(cmd, "BOX_ID",
				value.IsBOX_IDNull ? DBNull.Value : (object)value.BOX_ID);
			AddParameter(cmd, "MERMA",
				value.IsMERMANull ? DBNull.Value : (object)value.MERMA);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "NRO_TICKET_BASCULA", value.NRO_TICKET_BASCULA);
			AddParameter(cmd, "INGRESO_ID", value.INGRESO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "USAR_CANTIDAD_BL", value.USAR_CANTIDAD_BL);
			AddParameter(cmd, "USAR_CANTIDAD_DRAFT", value.USAR_CANTIDAD_DRAFT);
			AddParameter(cmd, "USAR_CANTIDAD_BASCULA", value.USAR_CANTIDAD_BASCULA);
			AddParameter(cmd, "USAR_CANTIDAD_REMISION", value.USAR_CANTIDAD_REMISION);
			AddParameter(cmd, "PRESENTACION_ID",
				value.IsPRESENTACION_IDNull ? DBNull.Value : (object)value.PRESENTACION_ID);
			AddParameter(cmd, "CANTIDAD_PRESENTACION",
				value.IsCANTIDAD_PRESENTACIONNull ? DBNull.Value : (object)value.CANTIDAD_PRESENTACION);
			AddParameter(cmd, "CANTIDAD_DE_PRESENTACION",
				value.IsCANTIDAD_DE_PRESENTACIONNull ? DBNull.Value : (object)value.CANTIDAD_DE_PRESENTACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>INGRESO_INSUMOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_INSUMOS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(INGRESO_INSUMOS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.INGRESO_INSUMOS_DETALLES SET " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"CANTIDAD_BL=" + _db.CreateSqlParameterName("CANTIDAD_BL") + ", " +
				"CANTIDAD_DRAFT=" + _db.CreateSqlParameterName("CANTIDAD_DRAFT") + ", " +
				"CANTIDAD_BASCULA=" + _db.CreateSqlParameterName("CANTIDAD_BASCULA") + ", " +
				"CANTIDAD_REMISION=" + _db.CreateSqlParameterName("CANTIDAD_REMISION") + ", " +
				"BOX_ID=" + _db.CreateSqlParameterName("BOX_ID") + ", " +
				"MERMA=" + _db.CreateSqlParameterName("MERMA") + ", " +
				"UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				"CHAPA_CARRETA=" + _db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				"CHAPA_CAMION=" + _db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				"CHOFER_DOCUMENTO=" + _db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"NRO_TICKET_BASCULA=" + _db.CreateSqlParameterName("NRO_TICKET_BASCULA") + ", " +
				"INGRESO_ID=" + _db.CreateSqlParameterName("INGRESO_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"USAR_CANTIDAD_BL=" + _db.CreateSqlParameterName("USAR_CANTIDAD_BL") + ", " +
				"USAR_CANTIDAD_DRAFT=" + _db.CreateSqlParameterName("USAR_CANTIDAD_DRAFT") + ", " +
				"USAR_CANTIDAD_BASCULA=" + _db.CreateSqlParameterName("USAR_CANTIDAD_BASCULA") + ", " +
				"USAR_CANTIDAD_REMISION=" + _db.CreateSqlParameterName("USAR_CANTIDAD_REMISION") + ", " +
				"PRESENTACION_ID=" + _db.CreateSqlParameterName("PRESENTACION_ID") + ", " +
				"CANTIDAD_PRESENTACION=" + _db.CreateSqlParameterName("CANTIDAD_PRESENTACION") + ", " +
				"CANTIDAD_DE_PRESENTACION=" + _db.CreateSqlParameterName("CANTIDAD_DE_PRESENTACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_BL",
				value.IsCANTIDAD_BLNull ? DBNull.Value : (object)value.CANTIDAD_BL);
			AddParameter(cmd, "CANTIDAD_DRAFT",
				value.IsCANTIDAD_DRAFTNull ? DBNull.Value : (object)value.CANTIDAD_DRAFT);
			AddParameter(cmd, "CANTIDAD_BASCULA",
				value.IsCANTIDAD_BASCULANull ? DBNull.Value : (object)value.CANTIDAD_BASCULA);
			AddParameter(cmd, "CANTIDAD_REMISION",
				value.IsCANTIDAD_REMISIONNull ? DBNull.Value : (object)value.CANTIDAD_REMISION);
			AddParameter(cmd, "BOX_ID",
				value.IsBOX_IDNull ? DBNull.Value : (object)value.BOX_ID);
			AddParameter(cmd, "MERMA",
				value.IsMERMANull ? DBNull.Value : (object)value.MERMA);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "NRO_TICKET_BASCULA", value.NRO_TICKET_BASCULA);
			AddParameter(cmd, "INGRESO_ID", value.INGRESO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "USAR_CANTIDAD_BL", value.USAR_CANTIDAD_BL);
			AddParameter(cmd, "USAR_CANTIDAD_DRAFT", value.USAR_CANTIDAD_DRAFT);
			AddParameter(cmd, "USAR_CANTIDAD_BASCULA", value.USAR_CANTIDAD_BASCULA);
			AddParameter(cmd, "USAR_CANTIDAD_REMISION", value.USAR_CANTIDAD_REMISION);
			AddParameter(cmd, "PRESENTACION_ID",
				value.IsPRESENTACION_IDNull ? DBNull.Value : (object)value.PRESENTACION_ID);
			AddParameter(cmd, "CANTIDAD_PRESENTACION",
				value.IsCANTIDAD_PRESENTACIONNull ? DBNull.Value : (object)value.CANTIDAD_PRESENTACION);
			AddParameter(cmd, "CANTIDAD_DE_PRESENTACION",
				value.IsCANTIDAD_DE_PRESENTACIONNull ? DBNull.Value : (object)value.CANTIDAD_DE_PRESENTACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>INGRESO_INSUMOS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>INGRESO_INSUMOS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>INGRESO_INSUMOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INGRESO_INSUMOS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(INGRESO_INSUMOS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>INGRESO_INSUMOS_DETALLES</c> table using
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
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
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
		/// delete records using the <c>FK_INGRE_INSUM_DET_ARTICULO_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_INGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_id">The <c>INGRESO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINGRESO_ID(decimal ingreso_id)
		{
			return CreateDeleteByINGRESO_IDCommand(ingreso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INGRE_INSUM_DET_INGRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ingreso_id">The <c>INGRESO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINGRESO_IDCommand(decimal ingreso_id)
		{
			string whereSql = "";
			whereSql += "INGRESO_ID=" + _db.CreateSqlParameterName("INGRESO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "INGRESO_ID", ingreso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
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
		/// delete records using the <c>FK_INGRE_INSUM_DET_LOTE_ID</c> foreign key.
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
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INGRE_INSUM_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRESENTACION_ID(decimal presentacion_id)
		{
			return DeleteByPRESENTACION_ID(presentacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRESENTACION_ID(decimal presentacion_id, bool presentacion_idNull)
		{
			return CreateDeleteByPRESENTACION_IDCommand(presentacion_id, presentacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INGRE_INSUM_DET_PRESEN</c> foreign key.
		/// </summary>
		/// <param name="presentacion_id">The <c>PRESENTACION_ID</c> column value.</param>
		/// <param name="presentacion_idNull">true if the method ignores the presentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPRESENTACION_IDCommand(decimal presentacion_id, bool presentacion_idNull)
		{
			string whereSql = "";
			if(presentacion_idNull)
				whereSql += "PRESENTACION_ID IS NULL";
			else
				whereSql += "PRESENTACION_ID=" + _db.CreateSqlParameterName("PRESENTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!presentacion_idNull)
				AddParameter(cmd, "PRESENTACION_ID", presentacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INGRESO_INSUMOS_DETALLES</c> table using the 
		/// <c>FK_INGRE_INSUM_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ID(string unidad_id)
		{
			return CreateDeleteByUNIDAD_IDCommand(unidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INGRE_INSUM_DET_UNIDAD_ID</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_IDCommand(string unidad_id)
		{
			string whereSql = "";
			if(null == unidad_id)
				whereSql += "UNIDAD_ID IS NULL";
			else
				whereSql += "UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_id)
				AddParameter(cmd, "UNIDAD_ID", unidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>INGRESO_INSUMOS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>INGRESO_INSUMOS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.INGRESO_INSUMOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>INGRESO_INSUMOS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		protected INGRESO_INSUMOS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		protected INGRESO_INSUMOS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INGRESO_INSUMOS_DETALLESRow"/> objects.</returns>
		protected virtual INGRESO_INSUMOS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int cantidad_blColumnIndex = reader.GetOrdinal("CANTIDAD_BL");
			int cantidad_draftColumnIndex = reader.GetOrdinal("CANTIDAD_DRAFT");
			int cantidad_basculaColumnIndex = reader.GetOrdinal("CANTIDAD_BASCULA");
			int cantidad_remisionColumnIndex = reader.GetOrdinal("CANTIDAD_REMISION");
			int box_idColumnIndex = reader.GetOrdinal("BOX_ID");
			int mermaColumnIndex = reader.GetOrdinal("MERMA");
			int unidad_idColumnIndex = reader.GetOrdinal("UNIDAD_ID");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int nro_ticket_basculaColumnIndex = reader.GetOrdinal("NRO_TICKET_BASCULA");
			int ingreso_idColumnIndex = reader.GetOrdinal("INGRESO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int usar_cantidad_blColumnIndex = reader.GetOrdinal("USAR_CANTIDAD_BL");
			int usar_cantidad_draftColumnIndex = reader.GetOrdinal("USAR_CANTIDAD_DRAFT");
			int usar_cantidad_basculaColumnIndex = reader.GetOrdinal("USAR_CANTIDAD_BASCULA");
			int usar_cantidad_remisionColumnIndex = reader.GetOrdinal("USAR_CANTIDAD_REMISION");
			int presentacion_idColumnIndex = reader.GetOrdinal("PRESENTACION_ID");
			int cantidad_presentacionColumnIndex = reader.GetOrdinal("CANTIDAD_PRESENTACION");
			int cantidad_de_presentacionColumnIndex = reader.GetOrdinal("CANTIDAD_DE_PRESENTACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INGRESO_INSUMOS_DETALLESRow record = new INGRESO_INSUMOS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_blColumnIndex))
						record.CANTIDAD_BL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_blColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_draftColumnIndex))
						record.CANTIDAD_DRAFT = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_draftColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_basculaColumnIndex))
						record.CANTIDAD_BASCULA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_basculaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_remisionColumnIndex))
						record.CANTIDAD_REMISION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_remisionColumnIndex)), 9);
					if(!reader.IsDBNull(box_idColumnIndex))
						record.BOX_ID = Math.Round(Convert.ToDecimal(reader.GetValue(box_idColumnIndex)), 9);
					if(!reader.IsDBNull(mermaColumnIndex))
						record.MERMA = Math.Round(Convert.ToDecimal(reader.GetValue(mermaColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_idColumnIndex))
						record.UNIDAD_ID = Convert.ToString(reader.GetValue(unidad_idColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(nro_ticket_basculaColumnIndex))
						record.NRO_TICKET_BASCULA = Convert.ToString(reader.GetValue(nro_ticket_basculaColumnIndex));
					record.INGRESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ingreso_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(usar_cantidad_blColumnIndex))
						record.USAR_CANTIDAD_BL = Convert.ToString(reader.GetValue(usar_cantidad_blColumnIndex));
					if(!reader.IsDBNull(usar_cantidad_draftColumnIndex))
						record.USAR_CANTIDAD_DRAFT = Convert.ToString(reader.GetValue(usar_cantidad_draftColumnIndex));
					if(!reader.IsDBNull(usar_cantidad_basculaColumnIndex))
						record.USAR_CANTIDAD_BASCULA = Convert.ToString(reader.GetValue(usar_cantidad_basculaColumnIndex));
					if(!reader.IsDBNull(usar_cantidad_remisionColumnIndex))
						record.USAR_CANTIDAD_REMISION = Convert.ToString(reader.GetValue(usar_cantidad_remisionColumnIndex));
					if(!reader.IsDBNull(presentacion_idColumnIndex))
						record.PRESENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(presentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_presentacionColumnIndex))
						record.CANTIDAD_PRESENTACION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_presentacionColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_de_presentacionColumnIndex))
						record.CANTIDAD_DE_PRESENTACION = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_de_presentacionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INGRESO_INSUMOS_DETALLESRow[])(recordList.ToArray(typeof(INGRESO_INSUMOS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INGRESO_INSUMOS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INGRESO_INSUMOS_DETALLESRow"/> object.</returns>
		protected virtual INGRESO_INSUMOS_DETALLESRow MapRow(DataRow row)
		{
			INGRESO_INSUMOS_DETALLESRow mappedObject = new INGRESO_INSUMOS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_BL"
			dataColumn = dataTable.Columns["CANTIDAD_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_BL = (decimal)row[dataColumn];
			// Column "CANTIDAD_DRAFT"
			dataColumn = dataTable.Columns["CANTIDAD_DRAFT"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DRAFT = (decimal)row[dataColumn];
			// Column "CANTIDAD_BASCULA"
			dataColumn = dataTable.Columns["CANTIDAD_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_BASCULA = (decimal)row[dataColumn];
			// Column "CANTIDAD_REMISION"
			dataColumn = dataTable.Columns["CANTIDAD_REMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_REMISION = (decimal)row[dataColumn];
			// Column "BOX_ID"
			dataColumn = dataTable.Columns["BOX_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOX_ID = (decimal)row[dataColumn];
			// Column "MERMA"
			dataColumn = dataTable.Columns["MERMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERMA = (decimal)row[dataColumn];
			// Column "UNIDAD_ID"
			dataColumn = dataTable.Columns["UNIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "NRO_TICKET_BASCULA"
			dataColumn = dataTable.Columns["NRO_TICKET_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TICKET_BASCULA = (string)row[dataColumn];
			// Column "INGRESO_ID"
			dataColumn = dataTable.Columns["INGRESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "USAR_CANTIDAD_BL"
			dataColumn = dataTable.Columns["USAR_CANTIDAD_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_CANTIDAD_BL = (string)row[dataColumn];
			// Column "USAR_CANTIDAD_DRAFT"
			dataColumn = dataTable.Columns["USAR_CANTIDAD_DRAFT"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_CANTIDAD_DRAFT = (string)row[dataColumn];
			// Column "USAR_CANTIDAD_BASCULA"
			dataColumn = dataTable.Columns["USAR_CANTIDAD_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_CANTIDAD_BASCULA = (string)row[dataColumn];
			// Column "USAR_CANTIDAD_REMISION"
			dataColumn = dataTable.Columns["USAR_CANTIDAD_REMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_CANTIDAD_REMISION = (string)row[dataColumn];
			// Column "PRESENTACION_ID"
			dataColumn = dataTable.Columns["PRESENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESENTACION_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_PRESENTACION"
			dataColumn = dataTable.Columns["CANTIDAD_PRESENTACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_PRESENTACION = (decimal)row[dataColumn];
			// Column "CANTIDAD_DE_PRESENTACION"
			dataColumn = dataTable.Columns["CANTIDAD_DE_PRESENTACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DE_PRESENTACION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INGRESO_INSUMOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INGRESO_INSUMOS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_BL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DRAFT", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_BASCULA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_REMISION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BOX_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MERMA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NRO_TICKET_BASCULA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("INGRESO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USAR_CANTIDAD_BL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("USAR_CANTIDAD_DRAFT", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("USAR_CANTIDAD_BASCULA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("USAR_CANTIDAD_REMISION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PRESENTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_PRESENTACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DE_PRESENTACION", typeof(decimal));
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

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DRAFT":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_REMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BOX_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MERMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_TICKET_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USAR_CANTIDAD_BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USAR_CANTIDAD_DRAFT":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USAR_CANTIDAD_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USAR_CANTIDAD_REMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRESENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_PRESENTACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DE_PRESENTACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INGRESO_INSUMOS_DETALLESCollection_Base class
}  // End of namespace
