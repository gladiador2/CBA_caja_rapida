// <fileinfo name="PRESUPUESTOS_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRESUPUESTOS_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PRESUPUESTO_ETAPA_IDColumnName = "PRESUPUESTO_ETAPA_ID";
		public const string MONTO_BRUTO_UNITARIOColumnName = "MONTO_BRUTO_UNITARIO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string UNIDAD_MEDIDAColumnName = "UNIDAD_MEDIDA";
		public const string CANTIDAD_CAJASColumnName = "CANTIDAD_CAJAS";
		public const string CANTIDAD_UNIDADESColumnName = "CANTIDAD_UNIDADES";
		public const string CANTIDAD_POR_CAJAColumnName = "CANTIDAD_POR_CAJA";
		public const string CANTIDAD_UNITARIA_TOTALColumnName = "CANTIDAD_UNITARIA_TOTAL";
		public const string CANTIDAD_UNITARIA_FACTURADAColumnName = "CANTIDAD_UNITARIA_FACTURADA";
		public const string MONTO_DESCUENTOColumnName = "MONTO_DESCUENTO";
		public const string PORCENTAJE_DESCColumnName = "PORCENTAJE_DESC";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string MONTO_IMPUESTOColumnName = "MONTO_IMPUESTO";
		public const string MONTO_NETO_UNITARIOColumnName = "MONTO_NETO_UNITARIO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string COSTO_IDColumnName = "COSTO_ID";
		public const string COSTO_MONTOColumnName = "COSTO_MONTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRESUPUESTOS_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRESUPUESTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public virtual PRESUPUESTOS_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRESUPUESTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRESUPUESTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRESUPUESTOS_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRESUPUESTOS_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRESUPUESTOS_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public PRESUPUESTOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public virtual PRESUPUESTOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRESUPUESTOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PRESUPUESTOS_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PRESUPUESTOS_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PRESUPUESTOS_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public PRESUPUESTOS_DETALLERow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public virtual PRESUPUESTOS_DETALLERow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
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
		/// return records by the <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DET_PRESUP_ETAPA_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_etapa_id">The <c>PRESUPUESTO_ETAPA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public virtual PRESUPUESTOS_DETALLERow[] GetByPRESUPUESTO_ETAPA_ID(decimal presupuesto_etapa_id)
		{
			return MapRecords(CreateGetByPRESUPUESTO_ETAPA_IDCommand(presupuesto_etapa_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DET_PRESUP_ETAPA_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_etapa_id">The <c>PRESUPUESTO_ETAPA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPRESUPUESTO_ETAPA_IDAsDataTable(decimal presupuesto_etapa_id)
		{
			return MapRecordsToDataTable(CreateGetByPRESUPUESTO_ETAPA_IDCommand(presupuesto_etapa_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_DET_PRESUP_ETAPA_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_etapa_id">The <c>PRESUPUESTO_ETAPA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPRESUPUESTO_ETAPA_IDCommand(decimal presupuesto_etapa_id)
		{
			string whereSql = "";
			whereSql += "PRESUPUESTO_ETAPA_ID=" + _db.CreateSqlParameterName("PRESUPUESTO_ETAPA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PRESUPUESTO_ETAPA_ID", presupuesto_etapa_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public PRESUPUESTOS_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public virtual PRESUPUESTOS_DETALLERow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
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
		/// return records by the <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
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
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public PRESUPUESTOS_DETALLERow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return GetByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public virtual PRESUPUESTOS_DETALLERow[] GetByIMPUESTO_ID(decimal impuesto_id, bool impuesto_idNull)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return GetByIMPUESTO_IDAsDataTable(impuesto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id, bool impuesto_idNull)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPUESTO_IDCommand(decimal impuesto_id, bool impuesto_idNull)
		{
			string whereSql = "";
			if(impuesto_idNull)
				whereSql += "IMPUESTO_ID IS NULL";
			else
				whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!impuesto_idNull)
				AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_DETALLERow"/> objects 
		/// by the <c>FK_PRESUP_DETALLE_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida">The <c>UNIDAD_MEDIDA</c> column value.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		public virtual PRESUPUESTOS_DETALLERow[] GetByUNIDAD_MEDIDA(string unidad_medida)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDACommand(unidad_medida));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PRESUP_DETALLE_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida">The <c>UNIDAD_MEDIDA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDAAsDataTable(string unidad_medida)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDACommand(unidad_medida));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PRESUP_DETALLE_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida">The <c>UNIDAD_MEDIDA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDACommand(string unidad_medida)
		{
			string whereSql = "";
			if(null == unidad_medida)
				whereSql += "UNIDAD_MEDIDA IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_medida)
				AddParameter(cmd, "UNIDAD_MEDIDA", unidad_medida);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PRESUPUESTOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOS_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(PRESUPUESTOS_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PRESUPUESTOS_DETALLE (" +
				"ID, " +
				"PRESUPUESTO_ETAPA_ID, " +
				"MONTO_BRUTO_UNITARIO, " +
				"ARTICULO_ID, " +
				"UNIDAD_MEDIDA, " +
				"CANTIDAD_CAJAS, " +
				"CANTIDAD_UNIDADES, " +
				"CANTIDAD_POR_CAJA, " +
				"CANTIDAD_UNITARIA_TOTAL, " +
				"CANTIDAD_UNITARIA_FACTURADA, " +
				"MONTO_DESCUENTO, " +
				"PORCENTAJE_DESC, " +
				"IMPUESTO_ID, " +
				"PORCENTAJE_IMPUESTO, " +
				"MONTO_IMPUESTO, " +
				"MONTO_NETO_UNITARIO, " +
				"OBSERVACION, " +
				"COSTO_ID, " +
				"COSTO_MONTO, " +
				"COSTO_MONEDA_ID, " +
				"COSTO_MONEDA_COTIZACION, " +
				"ACTIVO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PRESUPUESTO_ETAPA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_BRUTO_UNITARIO") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CAJAS") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDADES") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_FACTURADA") + ", " +
				_db.CreateSqlParameterName("MONTO_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DESC") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("MONTO_NETO_UNITARIO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("COSTO_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_MONTO") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PRESUPUESTO_ETAPA_ID", value.PRESUPUESTO_ETAPA_ID);
			AddParameter(cmd, "MONTO_BRUTO_UNITARIO",
				value.IsMONTO_BRUTO_UNITARIONull ? DBNull.Value : (object)value.MONTO_BRUTO_UNITARIO);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA", value.UNIDAD_MEDIDA);
			AddParameter(cmd, "CANTIDAD_CAJAS",
				value.IsCANTIDAD_CAJASNull ? DBNull.Value : (object)value.CANTIDAD_CAJAS);
			AddParameter(cmd, "CANTIDAD_UNIDADES",
				value.IsCANTIDAD_UNIDADESNull ? DBNull.Value : (object)value.CANTIDAD_UNIDADES);
			AddParameter(cmd, "CANTIDAD_POR_CAJA",
				value.IsCANTIDAD_POR_CAJANull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL",
				value.IsCANTIDAD_UNITARIA_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL);
			AddParameter(cmd, "CANTIDAD_UNITARIA_FACTURADA",
				value.IsCANTIDAD_UNITARIA_FACTURADANull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_FACTURADA);
			AddParameter(cmd, "MONTO_DESCUENTO",
				value.IsMONTO_DESCUENTONull ? DBNull.Value : (object)value.MONTO_DESCUENTO);
			AddParameter(cmd, "PORCENTAJE_DESC",
				value.IsPORCENTAJE_DESCNull ? DBNull.Value : (object)value.PORCENTAJE_DESC);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO",
				value.IsPORCENTAJE_IMPUESTONull ? DBNull.Value : (object)value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "MONTO_IMPUESTO",
				value.IsMONTO_IMPUESTONull ? DBNull.Value : (object)value.MONTO_IMPUESTO);
			AddParameter(cmd, "MONTO_NETO_UNITARIO",
				value.IsMONTO_NETO_UNITARIONull ? DBNull.Value : (object)value.MONTO_NETO_UNITARIO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "COSTO_MONTO",
				value.IsCOSTO_MONTONull ? DBNull.Value : (object)value.COSTO_MONTO);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION",
				value.IsCOSTO_MONEDA_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PRESUPUESTOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOS_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PRESUPUESTOS_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.PRESUPUESTOS_DETALLE SET " +
				"PRESUPUESTO_ETAPA_ID=" + _db.CreateSqlParameterName("PRESUPUESTO_ETAPA_ID") + ", " +
				"MONTO_BRUTO_UNITARIO=" + _db.CreateSqlParameterName("MONTO_BRUTO_UNITARIO") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"UNIDAD_MEDIDA=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA") + ", " +
				"CANTIDAD_CAJAS=" + _db.CreateSqlParameterName("CANTIDAD_CAJAS") + ", " +
				"CANTIDAD_UNIDADES=" + _db.CreateSqlParameterName("CANTIDAD_UNIDADES") + ", " +
				"CANTIDAD_POR_CAJA=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA") + ", " +
				"CANTIDAD_UNITARIA_TOTAL=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL") + ", " +
				"CANTIDAD_UNITARIA_FACTURADA=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_FACTURADA") + ", " +
				"MONTO_DESCUENTO=" + _db.CreateSqlParameterName("MONTO_DESCUENTO") + ", " +
				"PORCENTAJE_DESC=" + _db.CreateSqlParameterName("PORCENTAJE_DESC") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"PORCENTAJE_IMPUESTO=" + _db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				"MONTO_IMPUESTO=" + _db.CreateSqlParameterName("MONTO_IMPUESTO") + ", " +
				"MONTO_NETO_UNITARIO=" + _db.CreateSqlParameterName("MONTO_NETO_UNITARIO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID") + ", " +
				"COSTO_MONTO=" + _db.CreateSqlParameterName("COSTO_MONTO") + ", " +
				"COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				"COSTO_MONEDA_COTIZACION=" + _db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PRESUPUESTO_ETAPA_ID", value.PRESUPUESTO_ETAPA_ID);
			AddParameter(cmd, "MONTO_BRUTO_UNITARIO",
				value.IsMONTO_BRUTO_UNITARIONull ? DBNull.Value : (object)value.MONTO_BRUTO_UNITARIO);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA", value.UNIDAD_MEDIDA);
			AddParameter(cmd, "CANTIDAD_CAJAS",
				value.IsCANTIDAD_CAJASNull ? DBNull.Value : (object)value.CANTIDAD_CAJAS);
			AddParameter(cmd, "CANTIDAD_UNIDADES",
				value.IsCANTIDAD_UNIDADESNull ? DBNull.Value : (object)value.CANTIDAD_UNIDADES);
			AddParameter(cmd, "CANTIDAD_POR_CAJA",
				value.IsCANTIDAD_POR_CAJANull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL",
				value.IsCANTIDAD_UNITARIA_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL);
			AddParameter(cmd, "CANTIDAD_UNITARIA_FACTURADA",
				value.IsCANTIDAD_UNITARIA_FACTURADANull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_FACTURADA);
			AddParameter(cmd, "MONTO_DESCUENTO",
				value.IsMONTO_DESCUENTONull ? DBNull.Value : (object)value.MONTO_DESCUENTO);
			AddParameter(cmd, "PORCENTAJE_DESC",
				value.IsPORCENTAJE_DESCNull ? DBNull.Value : (object)value.PORCENTAJE_DESC);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO",
				value.IsPORCENTAJE_IMPUESTONull ? DBNull.Value : (object)value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "MONTO_IMPUESTO",
				value.IsMONTO_IMPUESTONull ? DBNull.Value : (object)value.MONTO_IMPUESTO);
			AddParameter(cmd, "MONTO_NETO_UNITARIO",
				value.IsMONTO_NETO_UNITARIONull ? DBNull.Value : (object)value.MONTO_NETO_UNITARIO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "COSTO_MONTO",
				value.IsCOSTO_MONTONull ? DBNull.Value : (object)value.COSTO_MONTO);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION",
				value.IsCOSTO_MONEDA_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PRESUPUESTOS_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PRESUPUESTOS_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PRESUPUESTOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PRESUPUESTOS_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PRESUPUESTOS_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PRESUPUESTOS_DETALLE</c> table using
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
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
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
		/// delete records using the <c>FK_PRESUP_DET_ACTIVO_ID</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DET_PRESUP_ETAPA_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_etapa_id">The <c>PRESUPUESTO_ETAPA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPRESUPUESTO_ETAPA_ID(decimal presupuesto_etapa_id)
		{
			return CreateDeleteByPRESUPUESTO_ETAPA_IDCommand(presupuesto_etapa_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_DET_PRESUP_ETAPA_ID</c> foreign key.
		/// </summary>
		/// <param name="presupuesto_etapa_id">The <c>PRESUPUESTO_ETAPA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPRESUPUESTO_ETAPA_IDCommand(decimal presupuesto_etapa_id)
		{
			string whereSql = "";
			whereSql += "PRESUPUESTO_ETAPA_ID=" + _db.CreateSqlParameterName("PRESUPUESTO_ETAPA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PRESUPUESTO_ETAPA_ID", presupuesto_etapa_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
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
		/// delete records using the <c>FK_PRESUP_DETALLE_ARTICULO</c> foreign key.
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
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return DeleteByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id, bool impuesto_idNull)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_DETALLE_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPUESTO_IDCommand(decimal impuesto_id, bool impuesto_idNull)
		{
			string whereSql = "";
			if(impuesto_idNull)
				whereSql += "IMPUESTO_ID IS NULL";
			else
				whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!impuesto_idNull)
				AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PRESUPUESTOS_DETALLE</c> table using the 
		/// <c>FK_PRESUP_DETALLE_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida">The <c>UNIDAD_MEDIDA</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA(string unidad_medida)
		{
			return CreateDeleteByUNIDAD_MEDIDACommand(unidad_medida).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PRESUP_DETALLE_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida">The <c>UNIDAD_MEDIDA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDACommand(string unidad_medida)
		{
			string whereSql = "";
			if(null == unidad_medida)
				whereSql += "UNIDAD_MEDIDA IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_medida)
				AddParameter(cmd, "UNIDAD_MEDIDA", unidad_medida);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PRESUPUESTOS_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>PRESUPUESTOS_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PRESUPUESTOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PRESUPUESTOS_DETALLE</c> table.
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		protected PRESUPUESTOS_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		protected PRESUPUESTOS_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_DETALLERow"/> objects.</returns>
		protected virtual PRESUPUESTOS_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int presupuesto_etapa_idColumnIndex = reader.GetOrdinal("PRESUPUESTO_ETAPA_ID");
			int monto_bruto_unitarioColumnIndex = reader.GetOrdinal("MONTO_BRUTO_UNITARIO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int unidad_medidaColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA");
			int cantidad_cajasColumnIndex = reader.GetOrdinal("CANTIDAD_CAJAS");
			int cantidad_unidadesColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDADES");
			int cantidad_por_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA");
			int cantidad_unitaria_totalColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL");
			int cantidad_unitaria_facturadaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_FACTURADA");
			int monto_descuentoColumnIndex = reader.GetOrdinal("MONTO_DESCUENTO");
			int porcentaje_descColumnIndex = reader.GetOrdinal("PORCENTAJE_DESC");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int monto_impuestoColumnIndex = reader.GetOrdinal("MONTO_IMPUESTO");
			int monto_neto_unitarioColumnIndex = reader.GetOrdinal("MONTO_NETO_UNITARIO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int costo_idColumnIndex = reader.GetOrdinal("COSTO_ID");
			int costo_montoColumnIndex = reader.GetOrdinal("COSTO_MONTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRESUPUESTOS_DETALLERow record = new PRESUPUESTOS_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PRESUPUESTO_ETAPA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(presupuesto_etapa_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_bruto_unitarioColumnIndex))
						record.MONTO_BRUTO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_bruto_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medidaColumnIndex))
						record.UNIDAD_MEDIDA = Convert.ToString(reader.GetValue(unidad_medidaColumnIndex));
					if(!reader.IsDBNull(cantidad_cajasColumnIndex))
						record.CANTIDAD_CAJAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cajasColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unidadesColumnIndex))
						record.CANTIDAD_UNIDADES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidadesColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_por_cajaColumnIndex))
						record.CANTIDAD_POR_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_cajaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_totalColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_totalColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_facturadaColumnIndex))
						record.CANTIDAD_UNITARIA_FACTURADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_facturadaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_descuentoColumnIndex))
						record.MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_descColumnIndex))
						record.PORCENTAJE_DESC = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_descColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_impuestoColumnIndex))
						record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_impuestoColumnIndex))
						record.MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_neto_unitarioColumnIndex))
						record.MONTO_NETO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_neto_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(costo_idColumnIndex))
						record.COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_montoColumnIndex))
						record.COSTO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_idColumnIndex))
						record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_cotizacionColumnIndex))
						record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRESUPUESTOS_DETALLERow[])(recordList.ToArray(typeof(PRESUPUESTOS_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRESUPUESTOS_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRESUPUESTOS_DETALLERow"/> object.</returns>
		protected virtual PRESUPUESTOS_DETALLERow MapRow(DataRow row)
		{
			PRESUPUESTOS_DETALLERow mappedObject = new PRESUPUESTOS_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PRESUPUESTO_ETAPA_ID"
			dataColumn = dataTable.Columns["PRESUPUESTO_ETAPA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRESUPUESTO_ETAPA_ID = (decimal)row[dataColumn];
			// Column "MONTO_BRUTO_UNITARIO"
			dataColumn = dataTable.Columns["MONTO_BRUTO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO_UNITARIO = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA = (string)row[dataColumn];
			// Column "CANTIDAD_CAJAS"
			dataColumn = dataTable.Columns["CANTIDAD_CAJAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CAJAS = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDADES"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDADES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDADES = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_FACTURADA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_FACTURADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_FACTURADA = (decimal)row[dataColumn];
			// Column "MONTO_DESCUENTO"
			dataColumn = dataTable.Columns["MONTO_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESCUENTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DESC"
			dataColumn = dataTable.Columns["PORCENTAJE_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESC = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "MONTO_NETO_UNITARIO"
			dataColumn = dataTable.Columns["MONTO_NETO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_NETO_UNITARIO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "COSTO_ID"
			dataColumn = dataTable.Columns["COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONTO"
			dataColumn = dataTable.Columns["COSTO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONTO = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRESUPUESTOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRESUPUESTOS_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRESUPUESTO_ETAPA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO_UNITARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CAJAS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDADES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_FACTURADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_DESCUENTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESC", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_NETO_UNITARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_COTIZACION", typeof(decimal));
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

				case "PRESUPUESTO_ETAPA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BRUTO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CAJAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDADES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_FACTURADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_NETO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRESUPUESTOS_DETALLECollection_Base class
}  // End of namespace
