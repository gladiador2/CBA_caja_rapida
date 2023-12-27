// <fileinfo name="PLANES_FACTURACION_ETAPAS_DETCollection_Base.cs">
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
	/// The base class for <see cref="PLANES_FACTURACION_ETAPAS_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANES_FACTURACION_ETAPAS_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANES_FACTURACION_ETAPAS_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLAN_FACTURACION_ETAPA_IDColumnName = "PLAN_FACTURACION_ETAPA_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string CANTIDAD_EMBALADAColumnName = "CANTIDAD_EMBALADA";
		public const string CANTIDAD_UNITARIAColumnName = "CANTIDAD_UNITARIA";
		public const string MONTO_BRUTOColumnName = "MONTO_BRUTO";
		public const string CALCULAR_MONTOColumnName = "CALCULAR_MONTO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string UNIDAD_MEDIDA_IDColumnName = "UNIDAD_MEDIDA_ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANES_FACTURACION_ETAPAS_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANES_FACTURACION_ETAPAS_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPAS_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANES_FACTURACION_ETAPAS_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANES_FACTURACION_ETAPAS_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public PLANES_FACTURACION_ETAPAS_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPAS_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANES_FACTURACION_ETAPAS_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANES_FACTURACION_ETAPAS_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANES_FACTURACION_ETAPAS_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects 
		/// by the <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public PLANES_FACTURACION_ETAPAS_DETRow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects 
		/// by the <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPAS_DETRow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
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
		/// return records by the <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
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
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects 
		/// by the <c>FK_PLANES_FACT_ETAPAS_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPAS_DETRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACT_ETAPAS_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANES_FACT_ETAPAS_DET_ART</c> foreign key.
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
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects 
		/// by the <c>FK_PLANES_FACT_ETAPAS_DET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_etapa_id">The <c>PLAN_FACTURACION_ETAPA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPAS_DETRow[] GetByPLAN_FACTURACION_ETAPA_ID(decimal plan_facturacion_etapa_id)
		{
			return MapRecords(CreateGetByPLAN_FACTURACION_ETAPA_IDCommand(plan_facturacion_etapa_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACT_ETAPAS_DET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_etapa_id">The <c>PLAN_FACTURACION_ETAPA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLAN_FACTURACION_ETAPA_IDAsDataTable(decimal plan_facturacion_etapa_id)
		{
			return MapRecordsToDataTable(CreateGetByPLAN_FACTURACION_ETAPA_IDCommand(plan_facturacion_etapa_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANES_FACT_ETAPAS_DET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_etapa_id">The <c>PLAN_FACTURACION_ETAPA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLAN_FACTURACION_ETAPA_IDCommand(decimal plan_facturacion_etapa_id)
		{
			string whereSql = "";
			whereSql += "PLAN_FACTURACION_ETAPA_ID=" + _db.CreateSqlParameterName("PLAN_FACTURACION_ETAPA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PLAN_FACTURACION_ETAPA_ID", plan_facturacion_etapa_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects 
		/// by the <c>FK_PLANES_FACT_ETAPAS_DET_UNI</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPAS_DETRow[] GetByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACT_ETAPAS_DET_UNI</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_IDAsDataTable(string unidad_medida_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_IDCommand(unidad_medida_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANES_FACT_ETAPAS_DET_UNI</c> foreign key.
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
		/// Adds a new record into the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> object to be inserted.</param>
		public virtual void Insert(PLANES_FACTURACION_ETAPAS_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANES_FACTURACION_ETAPAS_DET (" +
				"ID, " +
				"PLAN_FACTURACION_ETAPA_ID, " +
				"ARTICULO_ID, " +
				"CANTIDAD_EMBALADA, " +
				"CANTIDAD_UNITARIA, " +
				"MONTO_BRUTO, " +
				"CALCULAR_MONTO, " +
				"OBSERVACION, " +
				"UNIDAD_MEDIDA_ID, " +
				"ACTIVO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PLAN_FACTURACION_ETAPA_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA") + ", " +
				_db.CreateSqlParameterName("MONTO_BRUTO") + ", " +
				_db.CreateSqlParameterName("CALCULAR_MONTO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PLAN_FACTURACION_ETAPA_ID", value.PLAN_FACTURACION_ETAPA_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_UNITARIA", value.CANTIDAD_UNITARIA);
			AddParameter(cmd, "MONTO_BRUTO",
				value.IsMONTO_BRUTONull ? DBNull.Value : (object)value.MONTO_BRUTO);
			AddParameter(cmd, "CALCULAR_MONTO", value.CALCULAR_MONTO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANES_FACTURACION_ETAPAS_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANES_FACTURACION_ETAPAS_DET SET " +
				"PLAN_FACTURACION_ETAPA_ID=" + _db.CreateSqlParameterName("PLAN_FACTURACION_ETAPA_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"CANTIDAD_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				"CANTIDAD_UNITARIA=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA") + ", " +
				"MONTO_BRUTO=" + _db.CreateSqlParameterName("MONTO_BRUTO") + ", " +
				"CALCULAR_MONTO=" + _db.CreateSqlParameterName("CALCULAR_MONTO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"UNIDAD_MEDIDA_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ID") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PLAN_FACTURACION_ETAPA_ID", value.PLAN_FACTURACION_ETAPA_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_UNITARIA", value.CANTIDAD_UNITARIA);
			AddParameter(cmd, "MONTO_BRUTO",
				value.IsMONTO_BRUTONull ? DBNull.Value : (object)value.MONTO_BRUTO);
			AddParameter(cmd, "CALCULAR_MONTO", value.CALCULAR_MONTO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "UNIDAD_MEDIDA_ID", value.UNIDAD_MEDIDA_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANES_FACTURACION_ETAPAS_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANES_FACTURACION_ETAPAS_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANES_FACTURACION_ETAPAS_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table using
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
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table using the 
		/// <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table using the 
		/// <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
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
		/// delete records using the <c>FK_PLANES_FACT_ET_DET_ACT_ID</c> foreign key.
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
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table using the 
		/// <c>FK_PLANES_FACT_ETAPAS_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANES_FACT_ETAPAS_DET_ART</c> foreign key.
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
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table using the 
		/// <c>FK_PLANES_FACT_ETAPAS_DET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_etapa_id">The <c>PLAN_FACTURACION_ETAPA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLAN_FACTURACION_ETAPA_ID(decimal plan_facturacion_etapa_id)
		{
			return CreateDeleteByPLAN_FACTURACION_ETAPA_IDCommand(plan_facturacion_etapa_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANES_FACT_ETAPAS_DET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_etapa_id">The <c>PLAN_FACTURACION_ETAPA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLAN_FACTURACION_ETAPA_IDCommand(decimal plan_facturacion_etapa_id)
		{
			string whereSql = "";
			whereSql += "PLAN_FACTURACION_ETAPA_ID=" + _db.CreateSqlParameterName("PLAN_FACTURACION_ETAPA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PLAN_FACTURACION_ETAPA_ID", plan_facturacion_etapa_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table using the 
		/// <c>FK_PLANES_FACT_ETAPAS_DET_UNI</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_id">The <c>UNIDAD_MEDIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_ID(string unidad_medida_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_IDCommand(unidad_medida_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANES_FACT_ETAPAS_DET_UNI</c> foreign key.
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
		/// Deletes <c>PLANES_FACTURACION_ETAPAS_DET</c> records that match the specified criteria.
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
		/// to delete <c>PLANES_FACTURACION_ETAPAS_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANES_FACTURACION_ETAPAS_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		protected PLANES_FACTURACION_ETAPAS_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		protected PLANES_FACTURACION_ETAPAS_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> objects.</returns>
		protected virtual PLANES_FACTURACION_ETAPAS_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int plan_facturacion_etapa_idColumnIndex = reader.GetOrdinal("PLAN_FACTURACION_ETAPA_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int cantidad_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA");
			int cantidad_unitariaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA");
			int monto_brutoColumnIndex = reader.GetOrdinal("MONTO_BRUTO");
			int calcular_montoColumnIndex = reader.GetOrdinal("CALCULAR_MONTO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int unidad_medida_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANES_FACTURACION_ETAPAS_DETRow record = new PLANES_FACTURACION_ETAPAS_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLAN_FACTURACION_ETAPA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(plan_facturacion_etapa_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.CANTIDAD_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embaladaColumnIndex)), 9);
					record.CANTIDAD_UNITARIA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitariaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_brutoColumnIndex))
						record.MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_brutoColumnIndex)), 9);
					record.CALCULAR_MONTO = Convert.ToString(reader.GetValue(calcular_montoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.UNIDAD_MEDIDA_ID = Convert.ToString(reader.GetValue(unidad_medida_idColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANES_FACTURACION_ETAPAS_DETRow[])(recordList.ToArray(typeof(PLANES_FACTURACION_ETAPAS_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANES_FACTURACION_ETAPAS_DETRow"/> object.</returns>
		protected virtual PLANES_FACTURACION_ETAPAS_DETRow MapRow(DataRow row)
		{
			PLANES_FACTURACION_ETAPAS_DETRow mappedObject = new PLANES_FACTURACION_ETAPAS_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLAN_FACTURACION_ETAPA_ID"
			dataColumn = dataTable.Columns["PLAN_FACTURACION_ETAPA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLAN_FACTURACION_ETAPA_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA = (decimal)row[dataColumn];
			// Column "MONTO_BRUTO"
			dataColumn = dataTable.Columns["MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BRUTO = (decimal)row[dataColumn];
			// Column "CALCULAR_MONTO"
			dataColumn = dataTable.Columns["CALCULAR_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALCULAR_MONTO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ID = (string)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANES_FACTURACION_ETAPAS_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANES_FACTURACION_ETAPAS_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLAN_FACTURACION_ETAPA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALCULAR_MONTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
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

				case "PLAN_FACTURACION_ETAPA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALCULAR_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "UNIDAD_MEDIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANES_FACTURACION_ETAPAS_DETCollection_Base class
}  // End of namespace
