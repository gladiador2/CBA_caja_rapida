// <fileinfo name="CTACTE_GIROS_MOVIMIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_GIROS_MOVIMIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_GIROS_MOVIMIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_GIROS_MOVIMIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_GIRO_IDColumnName = "CTACTE_GIRO_ID";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string FECHA_DESEMBOLSOColumnName = "FECHA_DESEMBOLSO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string CREDITOColumnName = "CREDITO";
		public const string DEBITOColumnName = "DEBITO";
		public const string CTACTE_GIRO_RELACIONADO_IDColumnName = "CTACTE_GIRO_RELACIONADO_ID";
		public const string NRO_CUOTAColumnName = "NRO_CUOTA";
		public const string TOTAL_CUOTASColumnName = "TOTAL_CUOTAS";
		public const string DESEMBOLSO_GIRO_DET_IDColumnName = "DESEMBOLSO_GIRO_DET_ID";
		public const string CASO_IDColumnName = "CASO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_GIROS_MOVIMIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_GIROS_MOVIMIENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_GIROS_MOVIMIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_GIROS_MOVIMIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_GIROS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_GIROS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_GIROS_MOVIMIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_GIROS_MOVIMIENTOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id, bool caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_GIROS_MOVIMIENTOSRow[] GetByCTACTE_GIRO_RELACIONADO_ID(decimal ctacte_giro_relacionado_id)
		{
			return GetByCTACTE_GIRO_RELACIONADO_ID(ctacte_giro_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <param name="ctacte_giro_relacionado_idNull">true if the method ignores the ctacte_giro_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow[] GetByCTACTE_GIRO_RELACIONADO_ID(decimal ctacte_giro_relacionado_id, bool ctacte_giro_relacionado_idNull)
		{
			return MapRecords(CreateGetByCTACTE_GIRO_RELACIONADO_IDCommand(ctacte_giro_relacionado_id, ctacte_giro_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_GIRO_RELACIONADO_IDAsDataTable(decimal ctacte_giro_relacionado_id)
		{
			return GetByCTACTE_GIRO_RELACIONADO_IDAsDataTable(ctacte_giro_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <param name="ctacte_giro_relacionado_idNull">true if the method ignores the ctacte_giro_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_GIRO_RELACIONADO_IDAsDataTable(decimal ctacte_giro_relacionado_id, bool ctacte_giro_relacionado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_GIRO_RELACIONADO_IDCommand(ctacte_giro_relacionado_id, ctacte_giro_relacionado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <param name="ctacte_giro_relacionado_idNull">true if the method ignores the ctacte_giro_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_GIRO_RELACIONADO_IDCommand(decimal ctacte_giro_relacionado_id, bool ctacte_giro_relacionado_idNull)
		{
			string whereSql = "";
			if(ctacte_giro_relacionado_idNull)
				whereSql += "CTACTE_GIRO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CTACTE_GIRO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_RELACIONADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_giro_relacionado_idNull)
				AddParameter(cmd, "CTACTE_GIRO_RELACIONADO_ID", ctacte_giro_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_GIROS_MOVIMIENTOSRow[] GetByDESEMBOLSO_GIRO_DET_ID(decimal desembolso_giro_det_id)
		{
			return GetByDESEMBOLSO_GIRO_DET_ID(desembolso_giro_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <param name="desembolso_giro_det_idNull">true if the method ignores the desembolso_giro_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow[] GetByDESEMBOLSO_GIRO_DET_ID(decimal desembolso_giro_det_id, bool desembolso_giro_det_idNull)
		{
			return MapRecords(CreateGetByDESEMBOLSO_GIRO_DET_IDCommand(desembolso_giro_det_id, desembolso_giro_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESEMBOLSO_GIRO_DET_IDAsDataTable(decimal desembolso_giro_det_id)
		{
			return GetByDESEMBOLSO_GIRO_DET_IDAsDataTable(desembolso_giro_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <param name="desembolso_giro_det_idNull">true if the method ignores the desembolso_giro_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESEMBOLSO_GIRO_DET_IDAsDataTable(decimal desembolso_giro_det_id, bool desembolso_giro_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESEMBOLSO_GIRO_DET_IDCommand(desembolso_giro_det_id, desembolso_giro_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <param name="desembolso_giro_det_idNull">true if the method ignores the desembolso_giro_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESEMBOLSO_GIRO_DET_IDCommand(decimal desembolso_giro_det_id, bool desembolso_giro_det_idNull)
		{
			string whereSql = "";
			if(desembolso_giro_det_idNull)
				whereSql += "DESEMBOLSO_GIRO_DET_ID IS NULL";
			else
				whereSql += "DESEMBOLSO_GIRO_DET_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!desembolso_giro_det_idNull)
				AddParameter(cmd, "DESEMBOLSO_GIRO_DET_ID", desembolso_giro_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_GIROS_MOVIMIENTOSRow[] GetByCTACTE_GIRO_ID(decimal ctacte_giro_id)
		{
			return GetByCTACTE_GIRO_ID(ctacte_giro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow[] GetByCTACTE_GIRO_ID(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			return MapRecords(CreateGetByCTACTE_GIRO_IDCommand(ctacte_giro_id, ctacte_giro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_GIRO_IDAsDataTable(decimal ctacte_giro_id)
		{
			return GetByCTACTE_GIRO_IDAsDataTable(ctacte_giro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_GIRO_IDAsDataTable(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_GIRO_IDCommand(ctacte_giro_id, ctacte_giro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_GIRO_IDCommand(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			string whereSql = "";
			if(ctacte_giro_idNull)
				whereSql += "CTACTE_GIRO_ID IS NULL";
			else
				whereSql += "CTACTE_GIRO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_giro_idNull)
				AddParameter(cmd, "CTACTE_GIRO_ID", ctacte_giro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_GIROS_MOVIMIENTOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_GIROS_MOVIMIENTOSRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_GIROS_MOVIMIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_GIROS_MOVIMIENTOS (" +
				"ID, " +
				"CTACTE_GIRO_ID, " +
				"FECHA_INSERCION, " +
				"FECHA_DESEMBOLSO, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"CREDITO, " +
				"DEBITO, " +
				"CTACTE_GIRO_RELACIONADO_ID, " +
				"NRO_CUOTA, " +
				"TOTAL_CUOTAS, " +
				"DESEMBOLSO_GIRO_DET_ID, " +
				"CASO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_GIRO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				_db.CreateSqlParameterName("FECHA_DESEMBOLSO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("CREDITO") + ", " +
				_db.CreateSqlParameterName("DEBITO") + ", " +
				_db.CreateSqlParameterName("CTACTE_GIRO_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("NRO_CUOTA") + ", " +
				_db.CreateSqlParameterName("TOTAL_CUOTAS") + ", " +
				_db.CreateSqlParameterName("DESEMBOLSO_GIRO_DET_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_GIRO_ID",
				value.IsCTACTE_GIRO_IDNull ? DBNull.Value : (object)value.CTACTE_GIRO_ID);
			AddParameter(cmd, "FECHA_INSERCION",
				value.IsFECHA_INSERCIONNull ? DBNull.Value : (object)value.FECHA_INSERCION);
			AddParameter(cmd, "FECHA_DESEMBOLSO",
				value.IsFECHA_DESEMBOLSONull ? DBNull.Value : (object)value.FECHA_DESEMBOLSO);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "CREDITO",
				value.IsCREDITONull ? DBNull.Value : (object)value.CREDITO);
			AddParameter(cmd, "DEBITO",
				value.IsDEBITONull ? DBNull.Value : (object)value.DEBITO);
			AddParameter(cmd, "CTACTE_GIRO_RELACIONADO_ID",
				value.IsCTACTE_GIRO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CTACTE_GIRO_RELACIONADO_ID);
			AddParameter(cmd, "NRO_CUOTA",
				value.IsNRO_CUOTANull ? DBNull.Value : (object)value.NRO_CUOTA);
			AddParameter(cmd, "TOTAL_CUOTAS",
				value.IsTOTAL_CUOTASNull ? DBNull.Value : (object)value.TOTAL_CUOTAS);
			AddParameter(cmd, "DESEMBOLSO_GIRO_DET_ID",
				value.IsDESEMBOLSO_GIRO_DET_IDNull ? DBNull.Value : (object)value.DESEMBOLSO_GIRO_DET_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_GIROS_MOVIMIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_GIROS_MOVIMIENTOS SET " +
				"CTACTE_GIRO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_ID") + ", " +
				"FECHA_INSERCION=" + _db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				"FECHA_DESEMBOLSO=" + _db.CreateSqlParameterName("FECHA_DESEMBOLSO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"CREDITO=" + _db.CreateSqlParameterName("CREDITO") + ", " +
				"DEBITO=" + _db.CreateSqlParameterName("DEBITO") + ", " +
				"CTACTE_GIRO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_RELACIONADO_ID") + ", " +
				"NRO_CUOTA=" + _db.CreateSqlParameterName("NRO_CUOTA") + ", " +
				"TOTAL_CUOTAS=" + _db.CreateSqlParameterName("TOTAL_CUOTAS") + ", " +
				"DESEMBOLSO_GIRO_DET_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_DET_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_GIRO_ID",
				value.IsCTACTE_GIRO_IDNull ? DBNull.Value : (object)value.CTACTE_GIRO_ID);
			AddParameter(cmd, "FECHA_INSERCION",
				value.IsFECHA_INSERCIONNull ? DBNull.Value : (object)value.FECHA_INSERCION);
			AddParameter(cmd, "FECHA_DESEMBOLSO",
				value.IsFECHA_DESEMBOLSONull ? DBNull.Value : (object)value.FECHA_DESEMBOLSO);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "CREDITO",
				value.IsCREDITONull ? DBNull.Value : (object)value.CREDITO);
			AddParameter(cmd, "DEBITO",
				value.IsDEBITONull ? DBNull.Value : (object)value.DEBITO);
			AddParameter(cmd, "CTACTE_GIRO_RELACIONADO_ID",
				value.IsCTACTE_GIRO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CTACTE_GIRO_RELACIONADO_ID);
			AddParameter(cmd, "NRO_CUOTA",
				value.IsNRO_CUOTANull ? DBNull.Value : (object)value.NRO_CUOTA);
			AddParameter(cmd, "TOTAL_CUOTAS",
				value.IsTOTAL_CUOTASNull ? DBNull.Value : (object)value.TOTAL_CUOTAS);
			AddParameter(cmd, "DESEMBOLSO_GIRO_DET_ID",
				value.IsDESEMBOLSO_GIRO_DET_IDNull ? DBNull.Value : (object)value.DESEMBOLSO_GIRO_DET_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_GIROS_MOVIMIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_GIROS_MOVIMIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_GIROS_MOVIMIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using
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
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return CreateDeleteByCASO_IDCommand(caso_id, caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTA_GIR_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_GIRO_RELACIONADO_ID(decimal ctacte_giro_relacionado_id)
		{
			return DeleteByCTACTE_GIRO_RELACIONADO_ID(ctacte_giro_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <param name="ctacte_giro_relacionado_idNull">true if the method ignores the ctacte_giro_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_GIRO_RELACIONADO_ID(decimal ctacte_giro_relacionado_id, bool ctacte_giro_relacionado_idNull)
		{
			return CreateDeleteByCTACTE_GIRO_RELACIONADO_IDCommand(ctacte_giro_relacionado_id, ctacte_giro_relacionado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTA_GIR_MOV_CTA_GIR_MOV</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_relacionado_id">The <c>CTACTE_GIRO_RELACIONADO_ID</c> column value.</param>
		/// <param name="ctacte_giro_relacionado_idNull">true if the method ignores the ctacte_giro_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_GIRO_RELACIONADO_IDCommand(decimal ctacte_giro_relacionado_id, bool ctacte_giro_relacionado_idNull)
		{
			string whereSql = "";
			if(ctacte_giro_relacionado_idNull)
				whereSql += "CTACTE_GIRO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CTACTE_GIRO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_RELACIONADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_giro_relacionado_idNull)
				AddParameter(cmd, "CTACTE_GIRO_RELACIONADO_ID", ctacte_giro_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESEMBOLSO_GIRO_DET_ID(decimal desembolso_giro_det_id)
		{
			return DeleteByDESEMBOLSO_GIRO_DET_ID(desembolso_giro_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <param name="desembolso_giro_det_idNull">true if the method ignores the desembolso_giro_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESEMBOLSO_GIRO_DET_ID(decimal desembolso_giro_det_id, bool desembolso_giro_det_idNull)
		{
			return CreateDeleteByDESEMBOLSO_GIRO_DET_IDCommand(desembolso_giro_det_id, desembolso_giro_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTA_GIR_MOV_DESEM_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_det_id">The <c>DESEMBOLSO_GIRO_DET_ID</c> column value.</param>
		/// <param name="desembolso_giro_det_idNull">true if the method ignores the desembolso_giro_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESEMBOLSO_GIRO_DET_IDCommand(decimal desembolso_giro_det_id, bool desembolso_giro_det_idNull)
		{
			string whereSql = "";
			if(desembolso_giro_det_idNull)
				whereSql += "DESEMBOLSO_GIRO_DET_ID IS NULL";
			else
				whereSql += "DESEMBOLSO_GIRO_DET_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!desembolso_giro_det_idNull)
				AddParameter(cmd, "DESEMBOLSO_GIRO_DET_ID", desembolso_giro_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_GIRO_ID(decimal ctacte_giro_id)
		{
			return DeleteByCTACTE_GIRO_ID(ctacte_giro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_GIRO_ID(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			return CreateDeleteByCTACTE_GIRO_IDCommand(ctacte_giro_id, ctacte_giro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_GI_MOV_CTACTE_GIR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_GIRO_IDCommand(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			string whereSql = "";
			if(ctacte_giro_idNull)
				whereSql += "CTACTE_GIRO_ID IS NULL";
			else
				whereSql += "CTACTE_GIRO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_giro_idNull)
				AddParameter(cmd, "CTACTE_GIRO_ID", ctacte_giro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_MOV_MONEDAS</c> foreign key.
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
		/// Deletes <c>CTACTE_GIROS_MOVIMIENTOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_GIROS_MOVIMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_GIROS_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		protected CTACTE_GIROS_MOVIMIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		protected CTACTE_GIROS_MOVIMIENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> objects.</returns>
		protected virtual CTACTE_GIROS_MOVIMIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_giro_idColumnIndex = reader.GetOrdinal("CTACTE_GIRO_ID");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int fecha_desembolsoColumnIndex = reader.GetOrdinal("FECHA_DESEMBOLSO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int creditoColumnIndex = reader.GetOrdinal("CREDITO");
			int debitoColumnIndex = reader.GetOrdinal("DEBITO");
			int ctacte_giro_relacionado_idColumnIndex = reader.GetOrdinal("CTACTE_GIRO_RELACIONADO_ID");
			int nro_cuotaColumnIndex = reader.GetOrdinal("NRO_CUOTA");
			int total_cuotasColumnIndex = reader.GetOrdinal("TOTAL_CUOTAS");
			int desembolso_giro_det_idColumnIndex = reader.GetOrdinal("DESEMBOLSO_GIRO_DET_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_GIROS_MOVIMIENTOSRow record = new CTACTE_GIROS_MOVIMIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_giro_idColumnIndex))
						record.CTACTE_GIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_giro_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_insercionColumnIndex))
						record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					if(!reader.IsDBNull(fecha_desembolsoColumnIndex))
						record.FECHA_DESEMBOLSO = Convert.ToDateTime(reader.GetValue(fecha_desembolsoColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(creditoColumnIndex))
						record.CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(creditoColumnIndex)), 9);
					if(!reader.IsDBNull(debitoColumnIndex))
						record.DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(debitoColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_giro_relacionado_idColumnIndex))
						record.CTACTE_GIRO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_giro_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_cuotaColumnIndex))
						record.NRO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(nro_cuotaColumnIndex)), 9);
					if(!reader.IsDBNull(total_cuotasColumnIndex))
						record.TOTAL_CUOTAS = Math.Round(Convert.ToDecimal(reader.GetValue(total_cuotasColumnIndex)), 9);
					if(!reader.IsDBNull(desembolso_giro_det_idColumnIndex))
						record.DESEMBOLSO_GIRO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desembolso_giro_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_GIROS_MOVIMIENTOSRow[])(recordList.ToArray(typeof(CTACTE_GIROS_MOVIMIENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_GIROS_MOVIMIENTOSRow"/> object.</returns>
		protected virtual CTACTE_GIROS_MOVIMIENTOSRow MapRow(DataRow row)
		{
			CTACTE_GIROS_MOVIMIENTOSRow mappedObject = new CTACTE_GIROS_MOVIMIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_GIRO_ID"
			dataColumn = dataTable.Columns["CTACTE_GIRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIRO_ID = (decimal)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_DESEMBOLSO"
			dataColumn = dataTable.Columns["FECHA_DESEMBOLSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESEMBOLSO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "CREDITO"
			dataColumn = dataTable.Columns["CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO = (decimal)row[dataColumn];
			// Column "DEBITO"
			dataColumn = dataTable.Columns["DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO = (decimal)row[dataColumn];
			// Column "CTACTE_GIRO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CTACTE_GIRO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIRO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "NRO_CUOTA"
			dataColumn = dataTable.Columns["NRO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CUOTA = (decimal)row[dataColumn];
			// Column "TOTAL_CUOTAS"
			dataColumn = dataTable.Columns["TOTAL_CUOTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CUOTAS = (decimal)row[dataColumn];
			// Column "DESEMBOLSO_GIRO_DET_ID"
			dataColumn = dataTable.Columns["DESEMBOLSO_GIRO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_GIRO_DET_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_GIROS_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_GIROS_MOVIMIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_GIRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_DESEMBOLSO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CREDITO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEBITO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_GIRO_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_CUOTA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_CUOTAS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_GIRO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
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

				case "CTACTE_GIRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DESEMBOLSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_GIRO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CUOTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESEMBOLSO_GIRO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_GIROS_MOVIMIENTOSCollection_Base class
}  // End of namespace
