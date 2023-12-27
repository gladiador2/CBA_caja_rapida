// <fileinfo name="USO_DE_INSUMOS_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="USO_DE_INSUMOS_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="USO_DE_INSUMOS_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USO_DE_INSUMOS_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ARTICULO_LOTE_IDColumnName = "ARTICULO_LOTE_ID";
		public const string CANTIDAD_EMBALADAColumnName = "CANTIDAD_EMBALADA";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string CANTIDAD_UNIDAD_DESTINOColumnName = "CANTIDAD_UNIDAD_DESTINO";
		public const string CANTIDAD_UNITARIA_TOTAL_DESTColumnName = "CANTIDAD_UNITARIA_TOTAL_DEST";
		public const string COSTO_IDColumnName = "COSTO_ID";
		public const string COSTO_TOTALColumnName = "COSTO_TOTAL";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string UNIDAD_DESTINO_IDColumnName = "UNIDAD_DESTINO_ID";
		public const string FACTOR_DE_CONVERSIONColumnName = "FACTOR_DE_CONVERSION";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGENColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIGEN";
		public const string USO_DE_INSUMO_IDColumnName = "USO_DE_INSUMO_ID";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string UNIDAD_ORIGEN_IDColumnName = "UNIDAD_ORIGEN_ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string VALOR_MEDICIONColumnName = "VALOR_MEDICION";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string PROVEEDOR_ASIGNADO_IDColumnName = "PROVEEDOR_ASIGNADO_ID";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string ORDENES_SERVICIO_DETALLES_IDColumnName = "ORDENES_SERVICIO_DETALLES_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="USO_DE_INSUMOS_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public USO_DE_INSUMOS_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>USO_DE_INSUMOS_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>USO_DE_INSUMOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>USO_DE_INSUMOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="USO_DE_INSUMOS_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="USO_DE_INSUMOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public USO_DE_INSUMOS_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			USO_DE_INSUMOS_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public USO_DE_INSUMOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.USO_DE_INSUMOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="USO_DE_INSUMOS_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="USO_DE_INSUMOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			USO_DE_INSUMOS_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public USO_DE_INSUMOS_DETALLERow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
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
		/// return records by the <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
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
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_CABECERA</c> foreign key.
		/// </summary>
		/// <param name="uso_de_insumo_id">The <c>USO_DE_INSUMO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByUSO_DE_INSUMO_ID(decimal uso_de_insumo_id)
		{
			return MapRecords(CreateGetByUSO_DE_INSUMO_IDCommand(uso_de_insumo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_CABECERA</c> foreign key.
		/// </summary>
		/// <param name="uso_de_insumo_id">The <c>USO_DE_INSUMO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSO_DE_INSUMO_IDAsDataTable(decimal uso_de_insumo_id)
		{
			return MapRecordsToDataTable(CreateGetByUSO_DE_INSUMO_IDCommand(uso_de_insumo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_CABECERA</c> foreign key.
		/// </summary>
		/// <param name="uso_de_insumo_id">The <c>USO_DE_INSUMO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSO_DE_INSUMO_IDCommand(decimal uso_de_insumo_id)
		{
			string whereSql = "";
			whereSql += "USO_DE_INSUMO_ID=" + _db.CreateSqlParameterName("USO_DE_INSUMO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USO_DE_INSUMO_ID", uso_de_insumo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public USO_DE_INSUMOS_DETALLERow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_COST_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByCOSTO_MONEDA_ID(decimal costo_moneda_id)
		{
			return MapRecords(CreateGetByCOSTO_MONEDA_IDCommand(costo_moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_COST_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTO_MONEDA_IDAsDataTable(decimal costo_moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByCOSTO_MONEDA_IDCommand(costo_moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_COST_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTO_MONEDA_IDCommand(decimal costo_moneda_id)
		{
			string whereSql = "";
			whereSql += "COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "COSTO_MONEDA_ID", costo_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public USO_DE_INSUMOS_DETALLERow[] GetByCOSTO_ID(decimal costo_id)
		{
			return GetByCOSTO_ID(costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByCOSTO_ID(decimal costo_id, bool costo_idNull)
		{
			return MapRecords(CreateGetByCOSTO_IDCommand(costo_id, costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOSTO_IDAsDataTable(decimal costo_id)
		{
			return GetByCOSTO_IDAsDataTable(costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTO_IDAsDataTable(decimal costo_id, bool costo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOSTO_IDCommand(costo_id, costo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTO_IDCommand(decimal costo_id, bool costo_idNull)
		{
			string whereSql = "";
			if(costo_idNull)
				whereSql += "COSTO_ID IS NULL";
			else
				whereSql += "COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!costo_idNull)
				AddParameter(cmd, "COSTO_ID", costo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_lote_id">The <c>ARTICULO_LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByARTICULO_LOTE_ID(decimal articulo_lote_id)
		{
			return MapRecords(CreateGetByARTICULO_LOTE_IDCommand(articulo_lote_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_lote_id">The <c>ARTICULO_LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_LOTE_IDAsDataTable(decimal articulo_lote_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_LOTE_IDCommand(articulo_lote_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_lote_id">The <c>ARTICULO_LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_LOTE_IDCommand(decimal articulo_lote_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_LOTE_ID=" + _db.CreateSqlParameterName("ARTICULO_LOTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_LOTE_ID", articulo_lote_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public USO_DE_INSUMOS_DETALLERow[] GetByORDENES_SERVICIO_DETALLES_ID(decimal ordenes_servicio_detalles_id)
		{
			return GetByORDENES_SERVICIO_DETALLES_ID(ordenes_servicio_detalles_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <param name="ordenes_servicio_detalles_idNull">true if the method ignores the ordenes_servicio_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByORDENES_SERVICIO_DETALLES_ID(decimal ordenes_servicio_detalles_id, bool ordenes_servicio_detalles_idNull)
		{
			return MapRecords(CreateGetByORDENES_SERVICIO_DETALLES_IDCommand(ordenes_servicio_detalles_id, ordenes_servicio_detalles_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDENES_SERVICIO_DETALLES_IDAsDataTable(decimal ordenes_servicio_detalles_id)
		{
			return GetByORDENES_SERVICIO_DETALLES_IDAsDataTable(ordenes_servicio_detalles_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <param name="ordenes_servicio_detalles_idNull">true if the method ignores the ordenes_servicio_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDENES_SERVICIO_DETALLES_IDAsDataTable(decimal ordenes_servicio_detalles_id, bool ordenes_servicio_detalles_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDENES_SERVICIO_DETALLES_IDCommand(ordenes_servicio_detalles_id, ordenes_servicio_detalles_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <param name="ordenes_servicio_detalles_idNull">true if the method ignores the ordenes_servicio_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDENES_SERVICIO_DETALLES_IDCommand(decimal ordenes_servicio_detalles_id, bool ordenes_servicio_detalles_idNull)
		{
			string whereSql = "";
			if(ordenes_servicio_detalles_idNull)
				whereSql += "ORDENES_SERVICIO_DETALLES_ID IS NULL";
			else
				whereSql += "ORDENES_SERVICIO_DETALLES_ID=" + _db.CreateSqlParameterName("ORDENES_SERVICIO_DETALLES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ordenes_servicio_detalles_idNull)
				AddParameter(cmd, "ORDENES_SERVICIO_DETALLES_ID", ordenes_servicio_detalles_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public USO_DE_INSUMOS_DETALLERow[] GetByPROVEEDOR_ASIGNADO_ID(decimal proveedor_asignado_id)
		{
			return GetByPROVEEDOR_ASIGNADO_ID(proveedor_asignado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <param name="proveedor_asignado_idNull">true if the method ignores the proveedor_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByPROVEEDOR_ASIGNADO_ID(decimal proveedor_asignado_id, bool proveedor_asignado_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_ASIGNADO_IDCommand(proveedor_asignado_id, proveedor_asignado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_ASIGNADO_IDAsDataTable(decimal proveedor_asignado_id)
		{
			return GetByPROVEEDOR_ASIGNADO_IDAsDataTable(proveedor_asignado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <param name="proveedor_asignado_idNull">true if the method ignores the proveedor_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_ASIGNADO_IDAsDataTable(decimal proveedor_asignado_id, bool proveedor_asignado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_ASIGNADO_IDCommand(proveedor_asignado_id, proveedor_asignado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <param name="proveedor_asignado_idNull">true if the method ignores the proveedor_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_ASIGNADO_IDCommand(decimal proveedor_asignado_id, bool proveedor_asignado_idNull)
		{
			string whereSql = "";
			if(proveedor_asignado_idNull)
				whereSql += "PROVEEDOR_ASIGNADO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ASIGNADO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ASIGNADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_asignado_idNull)
				AddParameter(cmd, "PROVEEDOR_ASIGNADO_ID", proveedor_asignado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public USO_DE_INSUMOS_DETALLERow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_IDAsDataTable(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			string whereSql = "";
			if(sucursal_destino_idNull)
				whereSql += "SUCURSAL_DESTINO_ID IS NULL";
			else
				whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_destino_idNull)
				AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByUNIDAD_DESTINO_ID(string unidad_destino_id)
		{
			return MapRecords(CreateGetByUNIDAD_DESTINO_IDCommand(unidad_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_DESTINO_IDAsDataTable(string unidad_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_DESTINO_IDCommand(unidad_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_DESTINO_IDCommand(string unidad_destino_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", unidad_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects 
		/// by the <c>FK_USO_INSUMOS_DET_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		public virtual USO_DE_INSUMOS_DETALLERow[] GetByUNIDAD_ORIGEN_ID(string unidad_origen_id)
		{
			return MapRecords(CreateGetByUNIDAD_ORIGEN_IDCommand(unidad_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USO_INSUMOS_DET_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_ORIGEN_IDAsDataTable(string unidad_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_ORIGEN_IDCommand(unidad_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USO_INSUMOS_DET_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_ORIGEN_IDCommand(string unidad_origen_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", unidad_origen_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>USO_DE_INSUMOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USO_DE_INSUMOS_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(USO_DE_INSUMOS_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.USO_DE_INSUMOS_DETALLE (" +
				"ID, " +
				"ARTICULO_LOTE_ID, " +
				"CANTIDAD_EMBALADA, " +
				"CANTIDAD_POR_CAJA_DESTINO, " +
				"CANTIDAD_UNIDAD_DESTINO, " +
				"CANTIDAD_UNITARIA_TOTAL_DEST, " +
				"COSTO_ID, " +
				"COSTO_TOTAL, " +
				"COSTO_MONEDA_ID, " +
				"COSTO_MONEDA_COTIZACION, " +
				"OBSERVACION, " +
				"UNIDAD_DESTINO_ID, " +
				"FACTOR_DE_CONVERSION, " +
				"CANTIDAD_UNITARIA_TOTAL_ORIGEN, " +
				"USO_DE_INSUMO_ID, " +
				"CANTIDAD_POR_CAJA_ORIGEN, " +
				"CANTIDAD_UNIDAD_ORIGEN, " +
				"UNIDAD_ORIGEN_ID, " +
				"ACTIVO_ID, " +
				"VALOR_MEDICION, " +
				"SUCURSAL_DESTINO_ID, " +
				"PROVEEDOR_ASIGNADO_ID, " +
				"CASO_ASOCIADO_ID, " +
				"ORDENES_SERVICIO_DETALLES_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_LOTE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_DEST") + ", " +
				_db.CreateSqlParameterName("COSTO_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("FACTOR_DE_CONVERSION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIGEN") + ", " +
				_db.CreateSqlParameterName("USO_DE_INSUMO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("VALOR_MEDICION") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ASIGNADO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("ORDENES_SERVICIO_DETALLES_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ARTICULO_LOTE_ID", value.ARTICULO_LOTE_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNIDAD_DESTINO", value.CANTIDAD_UNIDAD_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_DEST", value.CANTIDAD_UNITARIA_TOTAL_DEST);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "COSTO_TOTAL", value.COSTO_TOTAL);
			AddParameter(cmd, "COSTO_MONEDA_ID", value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION", value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "FACTOR_DE_CONVERSION", value.FACTOR_DE_CONVERSION);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIGEN", value.CANTIDAD_UNITARIA_TOTAL_ORIGEN);
			AddParameter(cmd, "USO_DE_INSUMO_ID", value.USO_DE_INSUMO_ID);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN", value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN", value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "VALOR_MEDICION",
				value.IsVALOR_MEDICIONNull ? DBNull.Value : (object)value.VALOR_MEDICION);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "PROVEEDOR_ASIGNADO_ID",
				value.IsPROVEEDOR_ASIGNADO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ASIGNADO_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "ORDENES_SERVICIO_DETALLES_ID",
				value.IsORDENES_SERVICIO_DETALLES_IDNull ? DBNull.Value : (object)value.ORDENES_SERVICIO_DETALLES_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>USO_DE_INSUMOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USO_DE_INSUMOS_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(USO_DE_INSUMOS_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.USO_DE_INSUMOS_DETALLE SET " +
				"ARTICULO_LOTE_ID=" + _db.CreateSqlParameterName("ARTICULO_LOTE_ID") + ", " +
				"CANTIDAD_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				"CANTIDAD_POR_CAJA_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				"CANTIDAD_UNIDAD_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_DESTINO") + ", " +
				"CANTIDAD_UNITARIA_TOTAL_DEST=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_DEST") + ", " +
				"COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID") + ", " +
				"COSTO_TOTAL=" + _db.CreateSqlParameterName("COSTO_TOTAL") + ", " +
				"COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				"COSTO_MONEDA_COTIZACION=" + _db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				"FACTOR_DE_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_DE_CONVERSION") + ", " +
				"CANTIDAD_UNITARIA_TOTAL_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIGEN") + ", " +
				"USO_DE_INSUMO_ID=" + _db.CreateSqlParameterName("USO_DE_INSUMO_ID") + ", " +
				"CANTIDAD_POR_CAJA_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				"CANTIDAD_UNIDAD_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				"UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"VALOR_MEDICION=" + _db.CreateSqlParameterName("VALOR_MEDICION") + ", " +
				"SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				"PROVEEDOR_ASIGNADO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ASIGNADO_ID") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"ORDENES_SERVICIO_DETALLES_ID=" + _db.CreateSqlParameterName("ORDENES_SERVICIO_DETALLES_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ARTICULO_LOTE_ID", value.ARTICULO_LOTE_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNIDAD_DESTINO", value.CANTIDAD_UNIDAD_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_DEST", value.CANTIDAD_UNITARIA_TOTAL_DEST);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "COSTO_TOTAL", value.COSTO_TOTAL);
			AddParameter(cmd, "COSTO_MONEDA_ID", value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION", value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "FACTOR_DE_CONVERSION", value.FACTOR_DE_CONVERSION);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIGEN", value.CANTIDAD_UNITARIA_TOTAL_ORIGEN);
			AddParameter(cmd, "USO_DE_INSUMO_ID", value.USO_DE_INSUMO_ID);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN", value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN", value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "VALOR_MEDICION",
				value.IsVALOR_MEDICIONNull ? DBNull.Value : (object)value.VALOR_MEDICION);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "PROVEEDOR_ASIGNADO_ID",
				value.IsPROVEEDOR_ASIGNADO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ASIGNADO_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "ORDENES_SERVICIO_DETALLES_ID",
				value.IsORDENES_SERVICIO_DETALLES_IDNull ? DBNull.Value : (object)value.ORDENES_SERVICIO_DETALLES_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>USO_DE_INSUMOS_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>USO_DE_INSUMOS_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>USO_DE_INSUMOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USO_DE_INSUMOS_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(USO_DE_INSUMOS_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>USO_DE_INSUMOS_DETALLE</c> table using
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
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
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
		/// delete records using the <c>FK_USO_INSUMOS_DET_ACTIVO</c> foreign key.
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
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_CABECERA</c> foreign key.
		/// </summary>
		/// <param name="uso_de_insumo_id">The <c>USO_DE_INSUMO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSO_DE_INSUMO_ID(decimal uso_de_insumo_id)
		{
			return CreateDeleteByUSO_DE_INSUMO_IDCommand(uso_de_insumo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_CABECERA</c> foreign key.
		/// </summary>
		/// <param name="uso_de_insumo_id">The <c>USO_DE_INSUMO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSO_DE_INSUMO_IDCommand(decimal uso_de_insumo_id)
		{
			string whereSql = "";
			whereSql += "USO_DE_INSUMO_ID=" + _db.CreateSqlParameterName("USO_DE_INSUMO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USO_DE_INSUMO_ID", uso_de_insumo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_COST_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_MONEDA_ID(decimal costo_moneda_id)
		{
			return CreateDeleteByCOSTO_MONEDA_IDCommand(costo_moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_COST_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTO_MONEDA_IDCommand(decimal costo_moneda_id)
		{
			string whereSql = "";
			whereSql += "COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "COSTO_MONEDA_ID", costo_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_ID(decimal costo_id)
		{
			return DeleteByCOSTO_ID(costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_ID(decimal costo_id, bool costo_idNull)
		{
			return CreateDeleteByCOSTO_IDCommand(costo_id, costo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTO_IDCommand(decimal costo_id, bool costo_idNull)
		{
			string whereSql = "";
			if(costo_idNull)
				whereSql += "COSTO_ID IS NULL";
			else
				whereSql += "COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!costo_idNull)
				AddParameter(cmd, "COSTO_ID", costo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_lote_id">The <c>ARTICULO_LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_LOTE_ID(decimal articulo_lote_id)
		{
			return CreateDeleteByARTICULO_LOTE_IDCommand(articulo_lote_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="articulo_lote_id">The <c>ARTICULO_LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_LOTE_IDCommand(decimal articulo_lote_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_LOTE_ID=" + _db.CreateSqlParameterName("ARTICULO_LOTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_LOTE_ID", articulo_lote_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDENES_SERVICIO_DETALLES_ID(decimal ordenes_servicio_detalles_id)
		{
			return DeleteByORDENES_SERVICIO_DETALLES_ID(ordenes_servicio_detalles_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <param name="ordenes_servicio_detalles_idNull">true if the method ignores the ordenes_servicio_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDENES_SERVICIO_DETALLES_ID(decimal ordenes_servicio_detalles_id, bool ordenes_servicio_detalles_idNull)
		{
			return CreateDeleteByORDENES_SERVICIO_DETALLES_IDCommand(ordenes_servicio_detalles_id, ordenes_servicio_detalles_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_OT_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_servicio_detalles_id">The <c>ORDENES_SERVICIO_DETALLES_ID</c> column value.</param>
		/// <param name="ordenes_servicio_detalles_idNull">true if the method ignores the ordenes_servicio_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDENES_SERVICIO_DETALLES_IDCommand(decimal ordenes_servicio_detalles_id, bool ordenes_servicio_detalles_idNull)
		{
			string whereSql = "";
			if(ordenes_servicio_detalles_idNull)
				whereSql += "ORDENES_SERVICIO_DETALLES_ID IS NULL";
			else
				whereSql += "ORDENES_SERVICIO_DETALLES_ID=" + _db.CreateSqlParameterName("ORDENES_SERVICIO_DETALLES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ordenes_servicio_detalles_idNull)
				AddParameter(cmd, "ORDENES_SERVICIO_DETALLES_ID", ordenes_servicio_detalles_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ASIGNADO_ID(decimal proveedor_asignado_id)
		{
			return DeleteByPROVEEDOR_ASIGNADO_ID(proveedor_asignado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <param name="proveedor_asignado_idNull">true if the method ignores the proveedor_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ASIGNADO_ID(decimal proveedor_asignado_id, bool proveedor_asignado_idNull)
		{
			return CreateDeleteByPROVEEDOR_ASIGNADO_IDCommand(proveedor_asignado_id, proveedor_asignado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_PROV_ASIG</c> foreign key.
		/// </summary>
		/// <param name="proveedor_asignado_id">The <c>PROVEEDOR_ASIGNADO_ID</c> column value.</param>
		/// <param name="proveedor_asignado_idNull">true if the method ignores the proveedor_asignado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_ASIGNADO_IDCommand(decimal proveedor_asignado_id, bool proveedor_asignado_idNull)
		{
			string whereSql = "";
			if(proveedor_asignado_idNull)
				whereSql += "PROVEEDOR_ASIGNADO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ASIGNADO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ASIGNADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_asignado_idNull)
				AddParameter(cmd, "PROVEEDOR_ASIGNADO_ID", proveedor_asignado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return DeleteBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return CreateDeleteBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			string whereSql = "";
			if(sucursal_destino_idNull)
				whereSql += "SUCURSAL_DESTINO_ID IS NULL";
			else
				whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_destino_idNull)
				AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_DESTINO_ID(string unidad_destino_id)
		{
			return CreateDeleteByUNIDAD_DESTINO_IDCommand(unidad_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_DESTINO_IDCommand(string unidad_destino_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", unidad_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>USO_DE_INSUMOS_DETALLE</c> table using the 
		/// <c>FK_USO_INSUMOS_DET_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ORIGEN_ID(string unidad_origen_id)
		{
			return CreateDeleteByUNIDAD_ORIGEN_IDCommand(unidad_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USO_INSUMOS_DET_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_ORIGEN_IDCommand(string unidad_origen_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", unidad_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>USO_DE_INSUMOS_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>USO_DE_INSUMOS_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.USO_DE_INSUMOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>USO_DE_INSUMOS_DETALLE</c> table.
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		protected USO_DE_INSUMOS_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		protected USO_DE_INSUMOS_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="USO_DE_INSUMOS_DETALLERow"/> objects.</returns>
		protected virtual USO_DE_INSUMOS_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int articulo_lote_idColumnIndex = reader.GetOrdinal("ARTICULO_LOTE_ID");
			int cantidad_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int cantidad_unidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_DESTINO");
			int cantidad_unitaria_total_destColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_DEST");
			int costo_idColumnIndex = reader.GetOrdinal("COSTO_ID");
			int costo_totalColumnIndex = reader.GetOrdinal("COSTO_TOTAL");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int unidad_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_ID");
			int factor_de_conversionColumnIndex = reader.GetOrdinal("FACTOR_DE_CONVERSION");
			int cantidad_unitaria_total_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIGEN");
			int uso_de_insumo_idColumnIndex = reader.GetOrdinal("USO_DE_INSUMO_ID");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int unidad_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int valor_medicionColumnIndex = reader.GetOrdinal("VALOR_MEDICION");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int proveedor_asignado_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ASIGNADO_ID");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int ordenes_servicio_detalles_idColumnIndex = reader.GetOrdinal("ORDENES_SERVICIO_DETALLES_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					USO_DE_INSUMOS_DETALLERow record = new USO_DE_INSUMOS_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ARTICULO_LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_lote_idColumnIndex)), 9);
					record.CANTIDAD_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embaladaColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_destinoColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_destColumnIndex)), 9);
					if(!reader.IsDBNull(costo_idColumnIndex))
						record.COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_idColumnIndex)), 9);
					record.COSTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_totalColumnIndex)), 9);
					record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.UNIDAD_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_destino_idColumnIndex));
					record.FACTOR_DE_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_de_conversionColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_origenColumnIndex)), 9);
					record.USO_DE_INSUMO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(uso_de_insumo_idColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_origenColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_origenColumnIndex)), 9);
					record.UNIDAD_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_origen_idColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(valor_medicionColumnIndex))
						record.VALOR_MEDICION = Math.Round(Convert.ToDecimal(reader.GetValue(valor_medicionColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_idColumnIndex))
						record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_asignado_idColumnIndex))
						record.PROVEEDOR_ASIGNADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_asignado_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(ordenes_servicio_detalles_idColumnIndex))
						record.ORDENES_SERVICIO_DETALLES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ordenes_servicio_detalles_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (USO_DE_INSUMOS_DETALLERow[])(recordList.ToArray(typeof(USO_DE_INSUMOS_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="USO_DE_INSUMOS_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="USO_DE_INSUMOS_DETALLERow"/> object.</returns>
		protected virtual USO_DE_INSUMOS_DETALLERow MapRow(DataRow row)
		{
			USO_DE_INSUMOS_DETALLERow mappedObject = new USO_DE_INSUMOS_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ARTICULO_LOTE_ID"
			dataColumn = dataTable.Columns["ARTICULO_LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_LOTE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_DEST"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_DEST = (decimal)row[dataColumn];
			// Column "COSTO_ID"
			dataColumn = dataTable.Columns["COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ID = (decimal)row[dataColumn];
			// Column "COSTO_TOTAL"
			dataColumn = dataTable.Columns["COSTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TOTAL = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "UNIDAD_DESTINO_ID"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO_ID = (string)row[dataColumn];
			// Column "FACTOR_DE_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_DE_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_DE_CONVERSION = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_ORIGEN = (decimal)row[dataColumn];
			// Column "USO_DE_INSUMO_ID"
			dataColumn = dataTable.Columns["USO_DE_INSUMO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_DE_INSUMO_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "UNIDAD_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_ID = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "VALOR_MEDICION"
			dataColumn = dataTable.Columns["VALOR_MEDICION"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_MEDICION = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ASIGNADO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ASIGNADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ASIGNADO_ID = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "ORDENES_SERVICIO_DETALLES_ID"
			dataColumn = dataTable.Columns["ORDENES_SERVICIO_DETALLES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDENES_SERVICIO_DETALLES_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>USO_DE_INSUMOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "USO_DE_INSUMOS_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_LOTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTOR_DE_CONVERSION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USO_DE_INSUMO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_MEDICION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ASIGNADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDENES_SERVICIO_DETALLES_ID", typeof(decimal));
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

				case "ARTICULO_LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTOR_DE_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_DE_INSUMO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_MEDICION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ASIGNADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDENES_SERVICIO_DETALLES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of USO_DE_INSUMOS_DETALLECollection_Base class
}  // End of namespace
