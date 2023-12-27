// <fileinfo name="PLANILLA_COBRANZA_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_COBRANZA_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_COBRANZA_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_COBRANZA_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLANILLA_COBRANZA_IDColumnName = "PLANILLA_COBRANZA_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string DIRECCION_COBROColumnName = "DIRECCION_COBRO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONTO_CUOTAColumnName = "MONTO_CUOTA";
		public const string MONEDA_COBRADO_IDColumnName = "MONEDA_COBRADO_ID";
		public const string COTIZACION_COBRADAColumnName = "COTIZACION_COBRADA";
		public const string MONTO_COBRADOColumnName = "MONTO_COBRADO";
		public const string COBRADOColumnName = "COBRADO";
		public const string CASO_PAGO_IDColumnName = "CASO_PAGO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CTACTE_RECIBO_IMPRESO_IDColumnName = "CTACTE_RECIBO_IMPRESO_ID";
		public const string CTACTE_RECIBO_ENTREGADO_IDColumnName = "CTACTE_RECIBO_ENTREGADO_ID";
		public const string MONTO_MORAColumnName = "MONTO_MORA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBRANZA_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_COBRANZA_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_COBRANZA_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_COBRANZA_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_COBRANZA_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_COBRANZA_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_COBRANZA_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public PLANILLA_COBRANZA_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_COBRANZA_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANILLA_COBRANZA_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANILLA_COBRANZA_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public PLANILLA_COBRANZA_DETALLESRow[] GetByCASO_PAGO_ID(decimal caso_pago_id)
		{
			return GetByCASO_PAGO_ID(caso_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <param name="caso_pago_idNull">true if the method ignores the caso_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetByCASO_PAGO_ID(decimal caso_pago_id, bool caso_pago_idNull)
		{
			return MapRecords(CreateGetByCASO_PAGO_IDCommand(caso_pago_id, caso_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_PAGO_IDAsDataTable(decimal caso_pago_id)
		{
			return GetByCASO_PAGO_IDAsDataTable(caso_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <param name="caso_pago_idNull">true if the method ignores the caso_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_PAGO_IDAsDataTable(decimal caso_pago_id, bool caso_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_PAGO_IDCommand(caso_pago_id, caso_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <param name="caso_pago_idNull">true if the method ignores the caso_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_PAGO_IDCommand(decimal caso_pago_id, bool caso_pago_idNull)
		{
			string whereSql = "";
			if(caso_pago_idNull)
				whereSql += "CASO_PAGO_ID IS NULL";
			else
				whereSql += "CASO_PAGO_ID=" + _db.CreateSqlParameterName("CASO_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_pago_idNull)
				AddParameter(cmd, "CASO_PAGO_ID", caso_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public PLANILLA_COBRANZA_DETALLESRow[] GetByMONEDA_COBRADO_ID(decimal moneda_cobrado_id)
		{
			return GetByMONEDA_COBRADO_ID(moneda_cobrado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <param name="moneda_cobrado_idNull">true if the method ignores the moneda_cobrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetByMONEDA_COBRADO_ID(decimal moneda_cobrado_id, bool moneda_cobrado_idNull)
		{
			return MapRecords(CreateGetByMONEDA_COBRADO_IDCommand(moneda_cobrado_id, moneda_cobrado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_COBRADO_IDAsDataTable(decimal moneda_cobrado_id)
		{
			return GetByMONEDA_COBRADO_IDAsDataTable(moneda_cobrado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <param name="moneda_cobrado_idNull">true if the method ignores the moneda_cobrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_COBRADO_IDAsDataTable(decimal moneda_cobrado_id, bool moneda_cobrado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_COBRADO_IDCommand(moneda_cobrado_id, moneda_cobrado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <param name="moneda_cobrado_idNull">true if the method ignores the moneda_cobrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_COBRADO_IDCommand(decimal moneda_cobrado_id, bool moneda_cobrado_idNull)
		{
			string whereSql = "";
			if(moneda_cobrado_idNull)
				whereSql += "MONEDA_COBRADO_ID IS NULL";
			else
				whereSql += "MONEDA_COBRADO_ID=" + _db.CreateSqlParameterName("MONEDA_COBRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_cobrado_idNull)
				AddParameter(cmd, "MONEDA_COBRADO_ID", moneda_cobrado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLAN_COB_DET_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLAN_COB_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_PLAN_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_cobranza_id">The <c>PLANILLA_COBRANZA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetByPLANILLA_COBRANZA_ID(decimal planilla_cobranza_id)
		{
			return MapRecords(CreateGetByPLANILLA_COBRANZA_IDCommand(planilla_cobranza_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_PLAN_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_cobranza_id">The <c>PLANILLA_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLANILLA_COBRANZA_IDAsDataTable(decimal planilla_cobranza_id)
		{
			return MapRecordsToDataTable(CreateGetByPLANILLA_COBRANZA_IDCommand(planilla_cobranza_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLAN_COB_DET_PLAN_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_cobranza_id">The <c>PLANILLA_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLANILLA_COBRANZA_IDCommand(decimal planilla_cobranza_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_COBRANZA_ID=" + _db.CreateSqlParameterName("PLANILLA_COBRANZA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PLANILLA_COBRANZA_ID", planilla_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public PLANILLA_COBRANZA_DETALLESRow[] GetByCTACTE_RECIBO_ENTREGADO_ID(decimal ctacte_recibo_entregado_id)
		{
			return GetByCTACTE_RECIBO_ENTREGADO_ID(ctacte_recibo_entregado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_entregado_idNull">true if the method ignores the ctacte_recibo_entregado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetByCTACTE_RECIBO_ENTREGADO_ID(decimal ctacte_recibo_entregado_id, bool ctacte_recibo_entregado_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RECIBO_ENTREGADO_IDCommand(ctacte_recibo_entregado_id, ctacte_recibo_entregado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RECIBO_ENTREGADO_IDAsDataTable(decimal ctacte_recibo_entregado_id)
		{
			return GetByCTACTE_RECIBO_ENTREGADO_IDAsDataTable(ctacte_recibo_entregado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_entregado_idNull">true if the method ignores the ctacte_recibo_entregado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RECIBO_ENTREGADO_IDAsDataTable(decimal ctacte_recibo_entregado_id, bool ctacte_recibo_entregado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RECIBO_ENTREGADO_IDCommand(ctacte_recibo_entregado_id, ctacte_recibo_entregado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_entregado_idNull">true if the method ignores the ctacte_recibo_entregado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RECIBO_ENTREGADO_IDCommand(decimal ctacte_recibo_entregado_id, bool ctacte_recibo_entregado_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_entregado_idNull)
				whereSql += "CTACTE_RECIBO_ENTREGADO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ENTREGADO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ENTREGADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_recibo_entregado_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ENTREGADO_ID", ctacte_recibo_entregado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public PLANILLA_COBRANZA_DETALLESRow[] GetByCTACTE_RECIBO_IMPRESO_ID(decimal ctacte_recibo_impreso_id)
		{
			return GetByCTACTE_RECIBO_IMPRESO_ID(ctacte_recibo_impreso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects 
		/// by the <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_impreso_idNull">true if the method ignores the ctacte_recibo_impreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		public virtual PLANILLA_COBRANZA_DETALLESRow[] GetByCTACTE_RECIBO_IMPRESO_ID(decimal ctacte_recibo_impreso_id, bool ctacte_recibo_impreso_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RECIBO_IMPRESO_IDCommand(ctacte_recibo_impreso_id, ctacte_recibo_impreso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RECIBO_IMPRESO_IDAsDataTable(decimal ctacte_recibo_impreso_id)
		{
			return GetByCTACTE_RECIBO_IMPRESO_IDAsDataTable(ctacte_recibo_impreso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_impreso_idNull">true if the method ignores the ctacte_recibo_impreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RECIBO_IMPRESO_IDAsDataTable(decimal ctacte_recibo_impreso_id, bool ctacte_recibo_impreso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RECIBO_IMPRESO_IDCommand(ctacte_recibo_impreso_id, ctacte_recibo_impreso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_impreso_idNull">true if the method ignores the ctacte_recibo_impreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RECIBO_IMPRESO_IDCommand(decimal ctacte_recibo_impreso_id, bool ctacte_recibo_impreso_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_impreso_idNull)
				whereSql += "CTACTE_RECIBO_IMPRESO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_IMPRESO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_IMPRESO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_recibo_impreso_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_IMPRESO_ID", ctacte_recibo_impreso_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PLANILLA_COBRANZA_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_COBRANZA_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(PLANILLA_COBRANZA_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANILLA_COBRANZA_DETALLES (" +
				"ID, " +
				"PLANILLA_COBRANZA_ID, " +
				"PERSONA_ID, " +
				"DIRECCION_COBRO, " +
				"MONEDA_ID, " +
				"MONTO_CUOTA, " +
				"MONEDA_COBRADO_ID, " +
				"COTIZACION_COBRADA, " +
				"MONTO_COBRADO, " +
				"COBRADO, " +
				"CASO_PAGO_ID, " +
				"OBSERVACION, " +
				"CTACTE_RECIBO_IMPRESO_ID, " +
				"CTACTE_RECIBO_ENTREGADO_ID, " +
				"MONTO_MORA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PLANILLA_COBRANZA_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("DIRECCION_COBRO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_CUOTA") + ", " +
				_db.CreateSqlParameterName("MONEDA_COBRADO_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_COBRADA") + ", " +
				_db.CreateSqlParameterName("MONTO_COBRADO") + ", " +
				_db.CreateSqlParameterName("COBRADO") + ", " +
				_db.CreateSqlParameterName("CASO_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_RECIBO_IMPRESO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RECIBO_ENTREGADO_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_MORA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PLANILLA_COBRANZA_ID", value.PLANILLA_COBRANZA_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "DIRECCION_COBRO", value.DIRECCION_COBRO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "MONTO_CUOTA", value.MONTO_CUOTA);
			AddParameter(cmd, "MONEDA_COBRADO_ID",
				value.IsMONEDA_COBRADO_IDNull ? DBNull.Value : (object)value.MONEDA_COBRADO_ID);
			AddParameter(cmd, "COTIZACION_COBRADA",
				value.IsCOTIZACION_COBRADANull ? DBNull.Value : (object)value.COTIZACION_COBRADA);
			AddParameter(cmd, "MONTO_COBRADO",
				value.IsMONTO_COBRADONull ? DBNull.Value : (object)value.MONTO_COBRADO);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			AddParameter(cmd, "CASO_PAGO_ID",
				value.IsCASO_PAGO_IDNull ? DBNull.Value : (object)value.CASO_PAGO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_RECIBO_IMPRESO_ID",
				value.IsCTACTE_RECIBO_IMPRESO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_IMPRESO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ENTREGADO_ID",
				value.IsCTACTE_RECIBO_ENTREGADO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ENTREGADO_ID);
			AddParameter(cmd, "MONTO_MORA", value.MONTO_MORA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANILLA_COBRANZA_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_COBRANZA_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANILLA_COBRANZA_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANILLA_COBRANZA_DETALLES SET " +
				"PLANILLA_COBRANZA_ID=" + _db.CreateSqlParameterName("PLANILLA_COBRANZA_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"DIRECCION_COBRO=" + _db.CreateSqlParameterName("DIRECCION_COBRO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"MONTO_CUOTA=" + _db.CreateSqlParameterName("MONTO_CUOTA") + ", " +
				"MONEDA_COBRADO_ID=" + _db.CreateSqlParameterName("MONEDA_COBRADO_ID") + ", " +
				"COTIZACION_COBRADA=" + _db.CreateSqlParameterName("COTIZACION_COBRADA") + ", " +
				"MONTO_COBRADO=" + _db.CreateSqlParameterName("MONTO_COBRADO") + ", " +
				"COBRADO=" + _db.CreateSqlParameterName("COBRADO") + ", " +
				"CASO_PAGO_ID=" + _db.CreateSqlParameterName("CASO_PAGO_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CTACTE_RECIBO_IMPRESO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_IMPRESO_ID") + ", " +
				"CTACTE_RECIBO_ENTREGADO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ENTREGADO_ID") + ", " +
				"MONTO_MORA=" + _db.CreateSqlParameterName("MONTO_MORA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PLANILLA_COBRANZA_ID", value.PLANILLA_COBRANZA_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "DIRECCION_COBRO", value.DIRECCION_COBRO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "MONTO_CUOTA", value.MONTO_CUOTA);
			AddParameter(cmd, "MONEDA_COBRADO_ID",
				value.IsMONEDA_COBRADO_IDNull ? DBNull.Value : (object)value.MONEDA_COBRADO_ID);
			AddParameter(cmd, "COTIZACION_COBRADA",
				value.IsCOTIZACION_COBRADANull ? DBNull.Value : (object)value.COTIZACION_COBRADA);
			AddParameter(cmd, "MONTO_COBRADO",
				value.IsMONTO_COBRADONull ? DBNull.Value : (object)value.MONTO_COBRADO);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			AddParameter(cmd, "CASO_PAGO_ID",
				value.IsCASO_PAGO_IDNull ? DBNull.Value : (object)value.CASO_PAGO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_RECIBO_IMPRESO_ID",
				value.IsCTACTE_RECIBO_IMPRESO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_IMPRESO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ENTREGADO_ID",
				value.IsCTACTE_RECIBO_ENTREGADO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ENTREGADO_ID);
			AddParameter(cmd, "MONTO_MORA", value.MONTO_MORA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANILLA_COBRANZA_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANILLA_COBRANZA_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANILLA_COBRANZA_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_COBRANZA_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANILLA_COBRANZA_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANILLA_COBRANZA_DETALLES</c> table using
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
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_PAGO_ID(decimal caso_pago_id)
		{
			return DeleteByCASO_PAGO_ID(caso_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <param name="caso_pago_idNull">true if the method ignores the caso_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_PAGO_ID(decimal caso_pago_id, bool caso_pago_idNull)
		{
			return CreateDeleteByCASO_PAGO_IDCommand(caso_pago_id, caso_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLAN_COB_DET_CASO_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_pago_id">The <c>CASO_PAGO_ID</c> column value.</param>
		/// <param name="caso_pago_idNull">true if the method ignores the caso_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_PAGO_IDCommand(decimal caso_pago_id, bool caso_pago_idNull)
		{
			string whereSql = "";
			if(caso_pago_idNull)
				whereSql += "CASO_PAGO_ID IS NULL";
			else
				whereSql += "CASO_PAGO_ID=" + _db.CreateSqlParameterName("CASO_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_pago_idNull)
				AddParameter(cmd, "CASO_PAGO_ID", caso_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_COBRADO_ID(decimal moneda_cobrado_id)
		{
			return DeleteByMONEDA_COBRADO_ID(moneda_cobrado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <param name="moneda_cobrado_idNull">true if the method ignores the moneda_cobrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_COBRADO_ID(decimal moneda_cobrado_id, bool moneda_cobrado_idNull)
		{
			return CreateDeleteByMONEDA_COBRADO_IDCommand(moneda_cobrado_id, moneda_cobrado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLAN_COB_DET_MON_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_cobrado_id">The <c>MONEDA_COBRADO_ID</c> column value.</param>
		/// <param name="moneda_cobrado_idNull">true if the method ignores the moneda_cobrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_COBRADO_IDCommand(decimal moneda_cobrado_id, bool moneda_cobrado_idNull)
		{
			string whereSql = "";
			if(moneda_cobrado_idNull)
				whereSql += "MONEDA_COBRADO_ID IS NULL";
			else
				whereSql += "MONEDA_COBRADO_ID=" + _db.CreateSqlParameterName("MONEDA_COBRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_cobrado_idNull)
				AddParameter(cmd, "MONEDA_COBRADO_ID", moneda_cobrado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLAN_COB_DET_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLAN_COB_DET_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_PLAN_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_cobranza_id">The <c>PLANILLA_COBRANZA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_COBRANZA_ID(decimal planilla_cobranza_id)
		{
			return CreateDeleteByPLANILLA_COBRANZA_IDCommand(planilla_cobranza_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLAN_COB_DET_PLAN_COBR_ID</c> foreign key.
		/// </summary>
		/// <param name="planilla_cobranza_id">The <c>PLANILLA_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLANILLA_COBRANZA_IDCommand(decimal planilla_cobranza_id)
		{
			string whereSql = "";
			whereSql += "PLANILLA_COBRANZA_ID=" + _db.CreateSqlParameterName("PLANILLA_COBRANZA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PLANILLA_COBRANZA_ID", planilla_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ENTREGADO_ID(decimal ctacte_recibo_entregado_id)
		{
			return DeleteByCTACTE_RECIBO_ENTREGADO_ID(ctacte_recibo_entregado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_entregado_idNull">true if the method ignores the ctacte_recibo_entregado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ENTREGADO_ID(decimal ctacte_recibo_entregado_id, bool ctacte_recibo_entregado_idNull)
		{
			return CreateDeleteByCTACTE_RECIBO_ENTREGADO_IDCommand(ctacte_recibo_entregado_id, ctacte_recibo_entregado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLAN_COB_DET_REC_ENTREG_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_entregado_id">The <c>CTACTE_RECIBO_ENTREGADO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_entregado_idNull">true if the method ignores the ctacte_recibo_entregado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RECIBO_ENTREGADO_IDCommand(decimal ctacte_recibo_entregado_id, bool ctacte_recibo_entregado_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_entregado_idNull)
				whereSql += "CTACTE_RECIBO_ENTREGADO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ENTREGADO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ENTREGADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_recibo_entregado_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ENTREGADO_ID", ctacte_recibo_entregado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_IMPRESO_ID(decimal ctacte_recibo_impreso_id)
		{
			return DeleteByCTACTE_RECIBO_IMPRESO_ID(ctacte_recibo_impreso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA_DETALLES</c> table using the 
		/// <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_impreso_idNull">true if the method ignores the ctacte_recibo_impreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_IMPRESO_ID(decimal ctacte_recibo_impreso_id, bool ctacte_recibo_impreso_idNull)
		{
			return CreateDeleteByCTACTE_RECIBO_IMPRESO_IDCommand(ctacte_recibo_impreso_id, ctacte_recibo_impreso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLAN_COB_DET_REC_IMPRESO_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_impreso_id">The <c>CTACTE_RECIBO_IMPRESO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_impreso_idNull">true if the method ignores the ctacte_recibo_impreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RECIBO_IMPRESO_IDCommand(decimal ctacte_recibo_impreso_id, bool ctacte_recibo_impreso_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_impreso_idNull)
				whereSql += "CTACTE_RECIBO_IMPRESO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_IMPRESO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_IMPRESO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_recibo_impreso_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_IMPRESO_ID", ctacte_recibo_impreso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PLANILLA_COBRANZA_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>PLANILLA_COBRANZA_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANILLA_COBRANZA_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANILLA_COBRANZA_DETALLES</c> table.
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		protected PLANILLA_COBRANZA_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		protected PLANILLA_COBRANZA_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZA_DETALLESRow"/> objects.</returns>
		protected virtual PLANILLA_COBRANZA_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int planilla_cobranza_idColumnIndex = reader.GetOrdinal("PLANILLA_COBRANZA_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int direccion_cobroColumnIndex = reader.GetOrdinal("DIRECCION_COBRO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monto_cuotaColumnIndex = reader.GetOrdinal("MONTO_CUOTA");
			int moneda_cobrado_idColumnIndex = reader.GetOrdinal("MONEDA_COBRADO_ID");
			int cotizacion_cobradaColumnIndex = reader.GetOrdinal("COTIZACION_COBRADA");
			int monto_cobradoColumnIndex = reader.GetOrdinal("MONTO_COBRADO");
			int cobradoColumnIndex = reader.GetOrdinal("COBRADO");
			int caso_pago_idColumnIndex = reader.GetOrdinal("CASO_PAGO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int ctacte_recibo_impreso_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_IMPRESO_ID");
			int ctacte_recibo_entregado_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ENTREGADO_ID");
			int monto_moraColumnIndex = reader.GetOrdinal("MONTO_MORA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_COBRANZA_DETALLESRow record = new PLANILLA_COBRANZA_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLANILLA_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_cobranza_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(direccion_cobroColumnIndex))
						record.DIRECCION_COBRO = Convert.ToString(reader.GetValue(direccion_cobroColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONTO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_cuotaColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cobrado_idColumnIndex))
						record.MONEDA_COBRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cobrado_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_cobradaColumnIndex))
						record.COTIZACION_COBRADA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_cobradaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_cobradoColumnIndex))
						record.MONTO_COBRADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_cobradoColumnIndex)), 9);
					if(!reader.IsDBNull(cobradoColumnIndex))
						record.COBRADO = Convert.ToString(reader.GetValue(cobradoColumnIndex));
					if(!reader.IsDBNull(caso_pago_idColumnIndex))
						record.CASO_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(ctacte_recibo_impreso_idColumnIndex))
						record.CTACTE_RECIBO_IMPRESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_impreso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_entregado_idColumnIndex))
						record.CTACTE_RECIBO_ENTREGADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_entregado_idColumnIndex)), 9);
					record.MONTO_MORA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_moraColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_COBRANZA_DETALLESRow[])(recordList.ToArray(typeof(PLANILLA_COBRANZA_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_COBRANZA_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_COBRANZA_DETALLESRow"/> object.</returns>
		protected virtual PLANILLA_COBRANZA_DETALLESRow MapRow(DataRow row)
		{
			PLANILLA_COBRANZA_DETALLESRow mappedObject = new PLANILLA_COBRANZA_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLANILLA_COBRANZA_ID"
			dataColumn = dataTable.Columns["PLANILLA_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "DIRECCION_COBRO"
			dataColumn = dataTable.Columns["DIRECCION_COBRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_COBRO = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONTO_CUOTA"
			dataColumn = dataTable.Columns["MONTO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CUOTA = (decimal)row[dataColumn];
			// Column "MONEDA_COBRADO_ID"
			dataColumn = dataTable.Columns["MONEDA_COBRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COBRADO_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_COBRADA"
			dataColumn = dataTable.Columns["COTIZACION_COBRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_COBRADA = (decimal)row[dataColumn];
			// Column "MONTO_COBRADO"
			dataColumn = dataTable.Columns["MONTO_COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COBRADO = (decimal)row[dataColumn];
			// Column "COBRADO"
			dataColumn = dataTable.Columns["COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRADO = (string)row[dataColumn];
			// Column "CASO_PAGO_ID"
			dataColumn = dataTable.Columns["CASO_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_PAGO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CTACTE_RECIBO_IMPRESO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_IMPRESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_IMPRESO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_ENTREGADO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ENTREGADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ENTREGADO_ID = (decimal)row[dataColumn];
			// Column "MONTO_MORA"
			dataColumn = dataTable.Columns["MONTO_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_MORA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_COBRANZA_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_COBRANZA_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLANILLA_COBRANZA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIRECCION_COBRO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_COBRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_COBRADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_COBRADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COBRADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CASO_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_IMPRESO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ENTREGADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_MORA", typeof(decimal));
			dataColumn.AllowDBNull = false;
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

				case "PLANILLA_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIRECCION_COBRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COBRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_COBRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_RECIBO_IMPRESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECIBO_ENTREGADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_COBRANZA_DETALLESCollection_Base class
}  // End of namespace
