// <fileinfo name="ORDENES_SERVICIO_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIO_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_SERVICIO_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIO_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ORDEN_SERVICIO_IDColumnName = "ORDEN_SERVICIO_ID";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string CANTIDAD_HORASColumnName = "CANTIDAD_HORAS";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string COSTO_UNITARIOColumnName = "COSTO_UNITARIO";
		public const string PRECIOColumnName = "PRECIO";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string UNIDAD_IDColumnName = "UNIDAD_ID";
		public const string PORCENTAJE_DESCUENTOColumnName = "PORCENTAJE_DESCUENTO";
		public const string COSTO_TOTALColumnName = "COSTO_TOTAL";
		public const string COSTO_UNITARIO_DESCONTADOColumnName = "COSTO_UNITARIO_DESCONTADO";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string TOTAL_IMPUESTO_MONTOColumnName = "TOTAL_IMPUESTO_MONTO";
		public const string ESTADO_IDColumnName = "ESTADO_ID";
		public const string CANTIDAD_HORAS_SERVColumnName = "CANTIDAD_HORAS_SERV";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIO_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_SERVICIO_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_SERVICIO_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_SERVICIO_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_SERVICIO_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_SERVICIO_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_SERVICIO_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_SERVICIO_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public ORDENES_SERVICIO_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_SERVICIO_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ORDENES_SERVICIO_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ORDENES_SERVICIO_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ORDENES_SERVICIO_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public ORDENES_SERVICIO_DETALLESRow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
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
		/// return records by the <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public ORDENES_SERVICIO_DETALLESRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
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
		/// return records by the <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public ORDENES_SERVICIO_DETALLESRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
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
		/// return records by the <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByESTADO_ID(string estado_id)
		{
			return MapRecords(CreateGetByESTADO_IDCommand(estado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_IDAsDataTable(string estado_id)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_IDCommand(estado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDEN_SERV_DET_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_IDCommand(string estado_id)
		{
			string whereSql = "";
			if(null == estado_id)
				whereSql += "ESTADO_ID IS NULL";
			else
				whereSql += "ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != estado_id)
				AddParameter(cmd, "ESTADO_ID", estado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public ORDENES_SERVICIO_DETALLESRow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return GetByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <param name="impuesto_idNull">true if the method ignores the impuesto_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByIMPUESTO_ID(decimal impuesto_id, bool impuesto_idNull)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id, impuesto_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return GetByIMPUESTO_IDAsDataTable(impuesto_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
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
		/// return records by the <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDEN_SERV_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_ORDEN_SERV</c> foreign key.
		/// </summary>
		/// <param name="orden_servicio_id">The <c>ORDEN_SERVICIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByORDEN_SERVICIO_ID(decimal orden_servicio_id)
		{
			return MapRecords(CreateGetByORDEN_SERVICIO_IDCommand(orden_servicio_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_ORDEN_SERV</c> foreign key.
		/// </summary>
		/// <param name="orden_servicio_id">The <c>ORDEN_SERVICIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_SERVICIO_IDAsDataTable(decimal orden_servicio_id)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_SERVICIO_IDCommand(orden_servicio_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDEN_SERV_DET_ORDEN_SERV</c> foreign key.
		/// </summary>
		/// <param name="orden_servicio_id">The <c>ORDEN_SERVICIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_SERVICIO_IDCommand(decimal orden_servicio_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_SERVICIO_ID=" + _db.CreateSqlParameterName("ORDEN_SERVICIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ORDEN_SERVICIO_ID", orden_servicio_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects 
		/// by the <c>FK_ORDEN_SERV_DET_UNID_MED</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_DETALLESRow[] GetByUNIDAD_ID(string unidad_id)
		{
			return MapRecords(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDEN_SERV_DET_UNID_MED</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_IDAsDataTable(string unidad_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_IDCommand(unidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDEN_SERV_DET_UNID_MED</c> foreign key.
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
		/// Adds a new record into the <c>ORDENES_SERVICIO_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_SERVICIO_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(ORDENES_SERVICIO_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ORDENES_SERVICIO_DETALLES (" +
				"ID, " +
				"ORDEN_SERVICIO_ID, " +
				"DESCRIPCION, " +
				"CANTIDAD_HORAS, " +
				"CASO_ASOCIADO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"COSTO_UNITARIO, " +
				"PRECIO, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"ACTIVO_ID, " +
				"ARTICULO_ID, " +
				"UNIDAD_ID, " +
				"PORCENTAJE_DESCUENTO, " +
				"COSTO_TOTAL, " +
				"COSTO_UNITARIO_DESCONTADO, " +
				"IMPUESTO_ID, " +
				"TOTAL_IMPUESTO_MONTO, " +
				"ESTADO_ID, " +
				"CANTIDAD_HORAS_SERV" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_SERVICIO_ID") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_HORAS") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("COSTO_UNITARIO") + ", " +
				_db.CreateSqlParameterName("PRECIO") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("COSTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("COSTO_UNITARIO_DESCONTADO") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("TOTAL_IMPUESTO_MONTO") + ", " +
				_db.CreateSqlParameterName("ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_HORAS_SERV") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ORDEN_SERVICIO_ID", value.ORDEN_SERVICIO_ID);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "CANTIDAD_HORAS", value.CANTIDAD_HORAS);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "COSTO_UNITARIO",
				value.IsCOSTO_UNITARIONull ? DBNull.Value : (object)value.COSTO_UNITARIO);
			AddParameter(cmd, "PRECIO",
				value.IsPRECIONull ? DBNull.Value : (object)value.PRECIO);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "PORCENTAJE_DESCUENTO",
				value.IsPORCENTAJE_DESCUENTONull ? DBNull.Value : (object)value.PORCENTAJE_DESCUENTO);
			AddParameter(cmd, "COSTO_TOTAL",
				value.IsCOSTO_TOTALNull ? DBNull.Value : (object)value.COSTO_TOTAL);
			AddParameter(cmd, "COSTO_UNITARIO_DESCONTADO",
				value.IsCOSTO_UNITARIO_DESCONTADONull ? DBNull.Value : (object)value.COSTO_UNITARIO_DESCONTADO);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "TOTAL_IMPUESTO_MONTO",
				value.IsTOTAL_IMPUESTO_MONTONull ? DBNull.Value : (object)value.TOTAL_IMPUESTO_MONTO);
			AddParameter(cmd, "ESTADO_ID", value.ESTADO_ID);
			AddParameter(cmd, "CANTIDAD_HORAS_SERV",
				value.IsCANTIDAD_HORAS_SERVNull ? DBNull.Value : (object)value.CANTIDAD_HORAS_SERV);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ORDENES_SERVICIO_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_SERVICIO_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ORDENES_SERVICIO_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.ORDENES_SERVICIO_DETALLES SET " +
				"ORDEN_SERVICIO_ID=" + _db.CreateSqlParameterName("ORDEN_SERVICIO_ID") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"CANTIDAD_HORAS=" + _db.CreateSqlParameterName("CANTIDAD_HORAS") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"COSTO_UNITARIO=" + _db.CreateSqlParameterName("COSTO_UNITARIO") + ", " +
				"PRECIO=" + _db.CreateSqlParameterName("PRECIO") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"UNIDAD_ID=" + _db.CreateSqlParameterName("UNIDAD_ID") + ", " +
				"PORCENTAJE_DESCUENTO=" + _db.CreateSqlParameterName("PORCENTAJE_DESCUENTO") + ", " +
				"COSTO_TOTAL=" + _db.CreateSqlParameterName("COSTO_TOTAL") + ", " +
				"COSTO_UNITARIO_DESCONTADO=" + _db.CreateSqlParameterName("COSTO_UNITARIO_DESCONTADO") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"TOTAL_IMPUESTO_MONTO=" + _db.CreateSqlParameterName("TOTAL_IMPUESTO_MONTO") + ", " +
				"ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID") + ", " +
				"CANTIDAD_HORAS_SERV=" + _db.CreateSqlParameterName("CANTIDAD_HORAS_SERV") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ORDEN_SERVICIO_ID", value.ORDEN_SERVICIO_ID);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "CANTIDAD_HORAS", value.CANTIDAD_HORAS);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "COSTO_UNITARIO",
				value.IsCOSTO_UNITARIONull ? DBNull.Value : (object)value.COSTO_UNITARIO);
			AddParameter(cmd, "PRECIO",
				value.IsPRECIONull ? DBNull.Value : (object)value.PRECIO);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "UNIDAD_ID", value.UNIDAD_ID);
			AddParameter(cmd, "PORCENTAJE_DESCUENTO",
				value.IsPORCENTAJE_DESCUENTONull ? DBNull.Value : (object)value.PORCENTAJE_DESCUENTO);
			AddParameter(cmd, "COSTO_TOTAL",
				value.IsCOSTO_TOTALNull ? DBNull.Value : (object)value.COSTO_TOTAL);
			AddParameter(cmd, "COSTO_UNITARIO_DESCONTADO",
				value.IsCOSTO_UNITARIO_DESCONTADONull ? DBNull.Value : (object)value.COSTO_UNITARIO_DESCONTADO);
			AddParameter(cmd, "IMPUESTO_ID",
				value.IsIMPUESTO_IDNull ? DBNull.Value : (object)value.IMPUESTO_ID);
			AddParameter(cmd, "TOTAL_IMPUESTO_MONTO",
				value.IsTOTAL_IMPUESTO_MONTONull ? DBNull.Value : (object)value.TOTAL_IMPUESTO_MONTO);
			AddParameter(cmd, "ESTADO_ID", value.ESTADO_ID);
			AddParameter(cmd, "CANTIDAD_HORAS_SERV",
				value.IsCANTIDAD_HORAS_SERVNull ? DBNull.Value : (object)value.CANTIDAD_HORAS_SERV);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ORDENES_SERVICIO_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ORDENES_SERVICIO_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ORDENES_SERVICIO_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_SERVICIO_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ORDENES_SERVICIO_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ORDENES_SERVICIO_DETALLES</c> table using
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
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
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
		/// delete records using the <c>FK_ORDEN_SERV_DET_ACTIVO</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
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
		/// delete records using the <c>FK_ORDEN_SERV_DET_ART_ID</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
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
		/// delete records using the <c>FK_ORDEN_SERV_DET_CASO_ASOC</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_ID(string estado_id)
		{
			return CreateDeleteByESTADO_IDCommand(estado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDEN_SERV_DET_ESTADO_ID</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_IDCommand(string estado_id)
		{
			string whereSql = "";
			if(null == estado_id)
				whereSql += "ESTADO_ID IS NULL";
			else
				whereSql += "ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != estado_id)
				AddParameter(cmd, "ESTADO_ID", estado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return DeleteByIMPUESTO_ID(impuesto_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
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
		/// delete records using the <c>FK_ORDEN_SERV_DET_IMPUESTO</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDEN_SERV_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_ORDEN_SERV</c> foreign key.
		/// </summary>
		/// <param name="orden_servicio_id">The <c>ORDEN_SERVICIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_SERVICIO_ID(decimal orden_servicio_id)
		{
			return CreateDeleteByORDEN_SERVICIO_IDCommand(orden_servicio_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDEN_SERV_DET_ORDEN_SERV</c> foreign key.
		/// </summary>
		/// <param name="orden_servicio_id">The <c>ORDEN_SERVICIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_SERVICIO_IDCommand(decimal orden_servicio_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_SERVICIO_ID=" + _db.CreateSqlParameterName("ORDEN_SERVICIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ORDEN_SERVICIO_ID", orden_servicio_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_SERVICIO_DETALLES</c> table using the 
		/// <c>FK_ORDEN_SERV_DET_UNID_MED</c> foreign key.
		/// </summary>
		/// <param name="unidad_id">The <c>UNIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ID(string unidad_id)
		{
			return CreateDeleteByUNIDAD_IDCommand(unidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDEN_SERV_DET_UNID_MED</c> foreign key.
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
		/// Deletes <c>ORDENES_SERVICIO_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>ORDENES_SERVICIO_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ORDENES_SERVICIO_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ORDENES_SERVICIO_DETALLES</c> table.
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		protected ORDENES_SERVICIO_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		protected ORDENES_SERVICIO_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_DETALLESRow"/> objects.</returns>
		protected virtual ORDENES_SERVICIO_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int orden_servicio_idColumnIndex = reader.GetOrdinal("ORDEN_SERVICIO_ID");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int cantidad_horasColumnIndex = reader.GetOrdinal("CANTIDAD_HORAS");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int costo_unitarioColumnIndex = reader.GetOrdinal("COSTO_UNITARIO");
			int precioColumnIndex = reader.GetOrdinal("PRECIO");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int unidad_idColumnIndex = reader.GetOrdinal("UNIDAD_ID");
			int porcentaje_descuentoColumnIndex = reader.GetOrdinal("PORCENTAJE_DESCUENTO");
			int costo_totalColumnIndex = reader.GetOrdinal("COSTO_TOTAL");
			int costo_unitario_descontadoColumnIndex = reader.GetOrdinal("COSTO_UNITARIO_DESCONTADO");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int total_impuesto_montoColumnIndex = reader.GetOrdinal("TOTAL_IMPUESTO_MONTO");
			int estado_idColumnIndex = reader.GetOrdinal("ESTADO_ID");
			int cantidad_horas_servColumnIndex = reader.GetOrdinal("CANTIDAD_HORAS_SERV");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_SERVICIO_DETALLESRow record = new ORDENES_SERVICIO_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ORDEN_SERVICIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_servicio_idColumnIndex)), 9);
					record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.CANTIDAD_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_horasColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_unitarioColumnIndex))
						record.COSTO_UNITARIO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_unitarioColumnIndex)), 9);
					if(!reader.IsDBNull(precioColumnIndex))
						record.PRECIO = Math.Round(Convert.ToDecimal(reader.GetValue(precioColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_idColumnIndex))
						record.UNIDAD_ID = Convert.ToString(reader.GetValue(unidad_idColumnIndex));
					if(!reader.IsDBNull(porcentaje_descuentoColumnIndex))
						record.PORCENTAJE_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_totalColumnIndex))
						record.COSTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(costo_totalColumnIndex)), 9);
					if(!reader.IsDBNull(costo_unitario_descontadoColumnIndex))
						record.COSTO_UNITARIO_DESCONTADO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_unitario_descontadoColumnIndex)), 9);
					if(!reader.IsDBNull(impuesto_idColumnIndex))
						record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(total_impuesto_montoColumnIndex))
						record.TOTAL_IMPUESTO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_impuesto_montoColumnIndex)), 9);
					if(!reader.IsDBNull(estado_idColumnIndex))
						record.ESTADO_ID = Convert.ToString(reader.GetValue(estado_idColumnIndex));
					if(!reader.IsDBNull(cantidad_horas_servColumnIndex))
						record.CANTIDAD_HORAS_SERV = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_horas_servColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_SERVICIO_DETALLESRow[])(recordList.ToArray(typeof(ORDENES_SERVICIO_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_SERVICIO_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_SERVICIO_DETALLESRow"/> object.</returns>
		protected virtual ORDENES_SERVICIO_DETALLESRow MapRow(DataRow row)
		{
			ORDENES_SERVICIO_DETALLESRow mappedObject = new ORDENES_SERVICIO_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ORDEN_SERVICIO_ID"
			dataColumn = dataTable.Columns["ORDEN_SERVICIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_SERVICIO_ID = (decimal)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "CANTIDAD_HORAS"
			dataColumn = dataTable.Columns["CANTIDAD_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_HORAS = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO_UNITARIO"
			dataColumn = dataTable.Columns["COSTO_UNITARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_UNITARIO = (decimal)row[dataColumn];
			// Column "PRECIO"
			dataColumn = dataTable.Columns["PRECIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_ID"
			dataColumn = dataTable.Columns["UNIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ID = (string)row[dataColumn];
			// Column "PORCENTAJE_DESCUENTO"
			dataColumn = dataTable.Columns["PORCENTAJE_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESCUENTO = (decimal)row[dataColumn];
			// Column "COSTO_TOTAL"
			dataColumn = dataTable.Columns["COSTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TOTAL = (decimal)row[dataColumn];
			// Column "COSTO_UNITARIO_DESCONTADO"
			dataColumn = dataTable.Columns["COSTO_UNITARIO_DESCONTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_UNITARIO_DESCONTADO = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "TOTAL_IMPUESTO_MONTO"
			dataColumn = dataTable.Columns["TOTAL_IMPUESTO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPUESTO_MONTO = (decimal)row[dataColumn];
			// Column "ESTADO_ID"
			dataColumn = dataTable.Columns["ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ID = (string)row[dataColumn];
			// Column "CANTIDAD_HORAS_SERV"
			dataColumn = dataTable.Columns["CANTIDAD_HORAS_SERV"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_HORAS_SERV = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_SERVICIO_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_SERVICIO_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN_SERVICIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_HORAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_UNITARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESCUENTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_UNITARIO_DESCONTADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_IMPUESTO_MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("CANTIDAD_HORAS_SERV", typeof(decimal));
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

				case "ORDEN_SERVICIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_UNITARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PORCENTAJE_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_UNITARIO_DESCONTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPUESTO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_HORAS_SERV":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_SERVICIO_DETALLESCollection_Base class
}  // End of namespace
