// <fileinfo name="EGRESOS_VARIOS_CAJA_DETCollection_Base.cs">
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
	/// The base class for <see cref="EGRESOS_VARIOS_CAJA_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EGRESOS_VARIOS_CAJA_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESOS_VARIOS_CAJA_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string CTACTE_PROVEEDOR_IDColumnName = "CTACTE_PROVEEDOR_ID";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_COMPRA_ORIGENColumnName = "COTIZACION_COMPRA_ORIGEN";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string CTACTE_PERSONA_IDColumnName = "CTACTE_PERSONA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESOS_VARIOS_CAJA_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EGRESOS_VARIOS_CAJA_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EGRESOS_VARIOS_CAJA_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EGRESOS_VARIOS_CAJA_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EGRESOS_VARIOS_CAJA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EGRESOS_VARIOS_CAJA_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_DETRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_IDAsDataTable(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_DETRow[] GetByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id)
		{
			return GetByCTACTE_PROVEEDOR_ID(ctacte_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id, ctacte_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROVEEDOR_IDAsDataTable(decimal ctacte_proveedor_id)
		{
			return GetByCTACTE_PROVEEDOR_IDAsDataTable(ctacte_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROVEEDOR_IDAsDataTable(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id, ctacte_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROVEEDOR_IDCommand(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			string whereSql = "";
			if(ctacte_proveedor_idNull)
				whereSql += "CTACTE_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_proveedor_idNull)
				AddParameter(cmd, "CTACTE_PROVEEDOR_ID", ctacte_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_EGR</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return MapRecords(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_EGR</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_DET_EGR</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id)
		{
			string whereSql = "";
			whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_DETRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
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
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
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
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_DETRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_DETRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
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
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
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
		/// Adds a new record into the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> object to be inserted.</param>
		public virtual void Insert(EGRESOS_VARIOS_CAJA_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EGRESOS_VARIOS_CAJA_DET (" +
				"ID, " +
				"EGRESO_VARIO_CAJA_ID, " +
				"CTACTE_PROVEEDOR_ID, " +
				"MONEDA_ORIGEN_ID, " +
				"COTIZACION_COMPRA_ORIGEN, " +
				"MONTO_ORIGEN, " +
				"MONTO_DESTINO, " +
				"OBSERVACION, " +
				"PROVEEDOR_ID, " +
				"PERSONA_ID, " +
				"CTACTE_PERSONA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_COMPRA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID",
				value.IsCTACTE_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CTACTE_PROVEEDOR_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_COMPRA_ORIGEN", value.COTIZACION_COMPRA_ORIGEN);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJA_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EGRESOS_VARIOS_CAJA_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.EGRESOS_VARIOS_CAJA_DET SET " +
				"EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				"CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"COTIZACION_COMPRA_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_COMPRA_ORIGEN") + ", " +
				"MONTO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				"MONTO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID",
				value.IsCTACTE_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CTACTE_PROVEEDOR_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_COMPRA_ORIGEN", value.COTIZACION_COMPRA_ORIGEN);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EGRESOS_VARIOS_CAJA_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EGRESOS_VARIOS_CAJA_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EGRESOS_VARIOS_CAJA_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return DeleteByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return CreateDeleteByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJA_DET_PER_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id)
		{
			return DeleteByCTACTE_PROVEEDOR_ID(ctacte_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			return CreateDeleteByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id, ctacte_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_DET_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROVEEDOR_IDCommand(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			string whereSql = "";
			if(ctacte_proveedor_idNull)
				whereSql += "CTACTE_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_proveedor_idNull)
				AddParameter(cmd, "CTACTE_PROVEEDOR_ID", ctacte_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_EGR</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_DET_EGR</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id)
		{
			string whereSql = "";
			whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
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
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_DET_PER</c> foreign key.
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
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
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_DET_PRO</c> foreign key.
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
		/// Deletes <c>EGRESOS_VARIOS_CAJA_DET</c> records that match the specified criteria.
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
		/// to delete <c>EGRESOS_VARIOS_CAJA_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EGRESOS_VARIOS_CAJA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		protected EGRESOS_VARIOS_CAJA_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		protected EGRESOS_VARIOS_CAJA_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> objects.</returns>
		protected virtual EGRESOS_VARIOS_CAJA_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int ctacte_proveedor_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_ID");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_compra_origenColumnIndex = reader.GetOrdinal("COTIZACION_COMPRA_ORIGEN");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int ctacte_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EGRESOS_VARIOS_CAJA_DETRow record = new EGRESOS_VARIOS_CAJA_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_proveedor_idColumnIndex))
						record.CTACTE_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.COTIZACION_COMPRA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_compra_origenColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_persona_idColumnIndex))
						record.CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EGRESOS_VARIOS_CAJA_DETRow[])(recordList.ToArray(typeof(EGRESOS_VARIOS_CAJA_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EGRESOS_VARIOS_CAJA_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EGRESOS_VARIOS_CAJA_DETRow"/> object.</returns>
		protected virtual EGRESOS_VARIOS_CAJA_DETRow MapRow(DataRow row)
		{
			EGRESOS_VARIOS_CAJA_DETRow mappedObject = new EGRESOS_VARIOS_CAJA_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_COMPRA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_COMPRA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_COMPRA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EGRESOS_VARIOS_CAJA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EGRESOS_VARIOS_CAJA_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_COMPRA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ID", typeof(decimal));
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

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_COMPRA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EGRESOS_VARIOS_CAJA_DETCollection_Base class
}  // End of namespace
