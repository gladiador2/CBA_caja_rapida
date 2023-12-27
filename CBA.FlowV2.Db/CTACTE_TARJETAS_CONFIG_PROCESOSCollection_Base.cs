// <fileinfo name="CTACTE_TARJETAS_CONFIG_PROCESOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_TARJETAS_CONFIG_PROCESOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string POS_IDColumnName = "POS_ID";
		public const string PROCESADORA_IDColumnName = "PROCESADORA_ID";
		public const string COMISION_PORCColumnName = "COMISION_PORC";
		public const string IVA_SOBRE_COMISION_PORCColumnName = "IVA_SOBRE_COMISION_PORC";
		public const string RENTA_SOBRE_IVA_PORCColumnName = "RENTA_SOBRE_IVA_PORC";
		public const string CTACTE_BANCARIA_ID_DESTColumnName = "CTACTE_BANCARIA_ID_DEST";
		public const string ES_TARJETA_CREDITOColumnName = "ES_TARJETA_CREDITO";
		public const string CTACTE_CAJA_IDColumnName = "CTACTE_CAJA_ID";
		public const string PROCESADORA_ID_RED_DINELCOColumnName = "PROCESADORA_ID_RED_DINELCO";
		public const string PROCESADORA_ID_RED_INFONETColumnName = "PROCESADORA_ID_RED_INFONET";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_TARJETAS_CONFIG_PROCESOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_TARJETAS_CONFIG_PROCESOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_TARJETAS_CONFIG_PROCESOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_TARJETAS_CONFIG_PROCESOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_TARJETAS_CONFIG_PROCESOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByCTACTE_CAJA_ID(decimal ctacte_caja_id)
		{
			return GetByCTACTE_CAJA_ID(ctacte_caja_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <param name="ctacte_caja_idNull">true if the method ignores the ctacte_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByCTACTE_CAJA_ID(decimal ctacte_caja_id, bool ctacte_caja_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_IDCommand(ctacte_caja_id, ctacte_caja_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_IDAsDataTable(decimal ctacte_caja_id)
		{
			return GetByCTACTE_CAJA_IDAsDataTable(ctacte_caja_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <param name="ctacte_caja_idNull">true if the method ignores the ctacte_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_IDAsDataTable(decimal ctacte_caja_id, bool ctacte_caja_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_IDCommand(ctacte_caja_id, ctacte_caja_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <param name="ctacte_caja_idNull">true if the method ignores the ctacte_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_IDCommand(decimal ctacte_caja_id, bool ctacte_caja_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_idNull)
				whereSql += "CTACTE_CAJA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_idNull)
				AddParameter(cmd, "CTACTE_CAJA_ID", ctacte_caja_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_CTABANC_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id_dest">The <c>CTACTE_BANCARIA_ID_DEST</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByCTACTE_BANCARIA_ID_DEST(decimal ctacte_bancaria_id_dest)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_ID_DESTCommand(ctacte_bancaria_id_dest));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_CTABANC_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id_dest">The <c>CTACTE_BANCARIA_ID_DEST</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_ID_DESTAsDataTable(decimal ctacte_bancaria_id_dest)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_ID_DESTCommand(ctacte_bancaria_id_dest));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CCTE_TARJ_CONF_CTABANC_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id_dest">The <c>CTACTE_BANCARIA_ID_DEST</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_ID_DESTCommand(decimal ctacte_bancaria_id_dest)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID_DEST=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID_DEST");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_BANCARIA_ID_DEST", ctacte_bancaria_id_dest);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_POS</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByPOS_ID(decimal pos_id)
		{
			return MapRecords(CreateGetByPOS_IDCommand(pos_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_POS</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPOS_IDAsDataTable(decimal pos_id)
		{
			return MapRecordsToDataTable(CreateGetByPOS_IDCommand(pos_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CCTE_TARJ_CONF_POS</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPOS_IDCommand(decimal pos_id)
		{
			string whereSql = "";
			whereSql += "POS_ID=" + _db.CreateSqlParameterName("POS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "POS_ID", pos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByPROCESADORA_ID_RED_DINELCO(decimal procesadora_id_red_dinelco)
		{
			return GetByPROCESADORA_ID_RED_DINELCO(procesadora_id_red_dinelco, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <param name="procesadora_id_red_dinelcoNull">true if the method ignores the procesadora_id_red_dinelco
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByPROCESADORA_ID_RED_DINELCO(decimal procesadora_id_red_dinelco, bool procesadora_id_red_dinelcoNull)
		{
			return MapRecords(CreateGetByPROCESADORA_ID_RED_DINELCOCommand(procesadora_id_red_dinelco, procesadora_id_red_dinelcoNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROCESADORA_ID_RED_DINELCOAsDataTable(decimal procesadora_id_red_dinelco)
		{
			return GetByPROCESADORA_ID_RED_DINELCOAsDataTable(procesadora_id_red_dinelco, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <param name="procesadora_id_red_dinelcoNull">true if the method ignores the procesadora_id_red_dinelco
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROCESADORA_ID_RED_DINELCOAsDataTable(decimal procesadora_id_red_dinelco, bool procesadora_id_red_dinelcoNull)
		{
			return MapRecordsToDataTable(CreateGetByPROCESADORA_ID_RED_DINELCOCommand(procesadora_id_red_dinelco, procesadora_id_red_dinelcoNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <param name="procesadora_id_red_dinelcoNull">true if the method ignores the procesadora_id_red_dinelco
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROCESADORA_ID_RED_DINELCOCommand(decimal procesadora_id_red_dinelco, bool procesadora_id_red_dinelcoNull)
		{
			string whereSql = "";
			if(procesadora_id_red_dinelcoNull)
				whereSql += "PROCESADORA_ID_RED_DINELCO IS NULL";
			else
				whereSql += "PROCESADORA_ID_RED_DINELCO=" + _db.CreateSqlParameterName("PROCESADORA_ID_RED_DINELCO");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!procesadora_id_red_dinelcoNull)
				AddParameter(cmd, "PROCESADORA_ID_RED_DINELCO", procesadora_id_red_dinelco);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByPROCESADORA_ID_RED_INFONET(decimal procesadora_id_red_infonet)
		{
			return GetByPROCESADORA_ID_RED_INFONET(procesadora_id_red_infonet, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <param name="procesadora_id_red_infonetNull">true if the method ignores the procesadora_id_red_infonet
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByPROCESADORA_ID_RED_INFONET(decimal procesadora_id_red_infonet, bool procesadora_id_red_infonetNull)
		{
			return MapRecords(CreateGetByPROCESADORA_ID_RED_INFONETCommand(procesadora_id_red_infonet, procesadora_id_red_infonetNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROCESADORA_ID_RED_INFONETAsDataTable(decimal procesadora_id_red_infonet)
		{
			return GetByPROCESADORA_ID_RED_INFONETAsDataTable(procesadora_id_red_infonet, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <param name="procesadora_id_red_infonetNull">true if the method ignores the procesadora_id_red_infonet
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROCESADORA_ID_RED_INFONETAsDataTable(decimal procesadora_id_red_infonet, bool procesadora_id_red_infonetNull)
		{
			return MapRecordsToDataTable(CreateGetByPROCESADORA_ID_RED_INFONETCommand(procesadora_id_red_infonet, procesadora_id_red_infonetNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <param name="procesadora_id_red_infonetNull">true if the method ignores the procesadora_id_red_infonet
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROCESADORA_ID_RED_INFONETCommand(decimal procesadora_id_red_infonet, bool procesadora_id_red_infonetNull)
		{
			string whereSql = "";
			if(procesadora_id_red_infonetNull)
				whereSql += "PROCESADORA_ID_RED_INFONET IS NULL";
			else
				whereSql += "PROCESADORA_ID_RED_INFONET=" + _db.CreateSqlParameterName("PROCESADORA_ID_RED_INFONET");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!procesadora_id_red_infonetNull)
				AddParameter(cmd, "PROCESADORA_ID_RED_INFONET", procesadora_id_red_infonet);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCESADORA</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] GetByPROCESADORA_ID(decimal procesadora_id)
		{
			return MapRecords(CreateGetByPROCESADORA_IDCommand(procesadora_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CCTE_TARJ_CONF_PROCESADORA</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROCESADORA_IDAsDataTable(decimal procesadora_id)
		{
			return MapRecordsToDataTable(CreateGetByPROCESADORA_IDCommand(procesadora_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CCTE_TARJ_CONF_PROCESADORA</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROCESADORA_IDCommand(decimal procesadora_id)
		{
			string whereSql = "";
			whereSql += "PROCESADORA_ID=" + _db.CreateSqlParameterName("PROCESADORA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PROCESADORA_ID", procesadora_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_TARJETAS_CONFIG_PROCESOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_TARJETAS_CONFIG_PROCESOS (" +
				"ID, " +
				"POS_ID, " +
				"PROCESADORA_ID, " +
				"COMISION_PORC, " +
				"IVA_SOBRE_COMISION_PORC, " +
				"RENTA_SOBRE_IVA_PORC, " +
				"CTACTE_BANCARIA_ID_DEST, " +
				"ES_TARJETA_CREDITO, " +
				"CTACTE_CAJA_ID, " +
				"PROCESADORA_ID_RED_DINELCO, " +
				"PROCESADORA_ID_RED_INFONET" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("POS_ID") + ", " +
				_db.CreateSqlParameterName("PROCESADORA_ID") + ", " +
				_db.CreateSqlParameterName("COMISION_PORC") + ", " +
				_db.CreateSqlParameterName("IVA_SOBRE_COMISION_PORC") + ", " +
				_db.CreateSqlParameterName("RENTA_SOBRE_IVA_PORC") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_ID_DEST") + ", " +
				_db.CreateSqlParameterName("ES_TARJETA_CREDITO") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_ID") + ", " +
				_db.CreateSqlParameterName("PROCESADORA_ID_RED_DINELCO") + ", " +
				_db.CreateSqlParameterName("PROCESADORA_ID_RED_INFONET") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "POS_ID", value.POS_ID);
			AddParameter(cmd, "PROCESADORA_ID", value.PROCESADORA_ID);
			AddParameter(cmd, "COMISION_PORC", value.COMISION_PORC);
			AddParameter(cmd, "IVA_SOBRE_COMISION_PORC", value.IVA_SOBRE_COMISION_PORC);
			AddParameter(cmd, "RENTA_SOBRE_IVA_PORC", value.RENTA_SOBRE_IVA_PORC);
			AddParameter(cmd, "CTACTE_BANCARIA_ID_DEST", value.CTACTE_BANCARIA_ID_DEST);
			AddParameter(cmd, "ES_TARJETA_CREDITO", value.ES_TARJETA_CREDITO);
			AddParameter(cmd, "CTACTE_CAJA_ID",
				value.IsCTACTE_CAJA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_ID);
			AddParameter(cmd, "PROCESADORA_ID_RED_DINELCO",
				value.IsPROCESADORA_ID_RED_DINELCONull ? DBNull.Value : (object)value.PROCESADORA_ID_RED_DINELCO);
			AddParameter(cmd, "PROCESADORA_ID_RED_INFONET",
				value.IsPROCESADORA_ID_RED_INFONETNull ? DBNull.Value : (object)value.PROCESADORA_ID_RED_INFONET);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_TARJETAS_CONFIG_PROCESOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_TARJETAS_CONFIG_PROCESOS SET " +
				"POS_ID=" + _db.CreateSqlParameterName("POS_ID") + ", " +
				"PROCESADORA_ID=" + _db.CreateSqlParameterName("PROCESADORA_ID") + ", " +
				"COMISION_PORC=" + _db.CreateSqlParameterName("COMISION_PORC") + ", " +
				"IVA_SOBRE_COMISION_PORC=" + _db.CreateSqlParameterName("IVA_SOBRE_COMISION_PORC") + ", " +
				"RENTA_SOBRE_IVA_PORC=" + _db.CreateSqlParameterName("RENTA_SOBRE_IVA_PORC") + ", " +
				"CTACTE_BANCARIA_ID_DEST=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID_DEST") + ", " +
				"ES_TARJETA_CREDITO=" + _db.CreateSqlParameterName("ES_TARJETA_CREDITO") + ", " +
				"CTACTE_CAJA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_ID") + ", " +
				"PROCESADORA_ID_RED_DINELCO=" + _db.CreateSqlParameterName("PROCESADORA_ID_RED_DINELCO") + ", " +
				"PROCESADORA_ID_RED_INFONET=" + _db.CreateSqlParameterName("PROCESADORA_ID_RED_INFONET") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "POS_ID", value.POS_ID);
			AddParameter(cmd, "PROCESADORA_ID", value.PROCESADORA_ID);
			AddParameter(cmd, "COMISION_PORC", value.COMISION_PORC);
			AddParameter(cmd, "IVA_SOBRE_COMISION_PORC", value.IVA_SOBRE_COMISION_PORC);
			AddParameter(cmd, "RENTA_SOBRE_IVA_PORC", value.RENTA_SOBRE_IVA_PORC);
			AddParameter(cmd, "CTACTE_BANCARIA_ID_DEST", value.CTACTE_BANCARIA_ID_DEST);
			AddParameter(cmd, "ES_TARJETA_CREDITO", value.ES_TARJETA_CREDITO);
			AddParameter(cmd, "CTACTE_CAJA_ID",
				value.IsCTACTE_CAJA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_ID);
			AddParameter(cmd, "PROCESADORA_ID_RED_DINELCO",
				value.IsPROCESADORA_ID_RED_DINELCONull ? DBNull.Value : (object)value.PROCESADORA_ID_RED_DINELCO);
			AddParameter(cmd, "PROCESADORA_ID_RED_INFONET",
				value.IsPROCESADORA_ID_RED_INFONETNull ? DBNull.Value : (object)value.PROCESADORA_ID_RED_INFONET);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_TARJETAS_CONFIG_PROCESOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using
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
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_ID(decimal ctacte_caja_id)
		{
			return DeleteByCTACTE_CAJA_ID(ctacte_caja_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <param name="ctacte_caja_idNull">true if the method ignores the ctacte_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_ID(decimal ctacte_caja_id, bool ctacte_caja_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_IDCommand(ctacte_caja_id, ctacte_caja_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CCTE_TARJ_CONF_CAJA_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_id">The <c>CTACTE_CAJA_ID</c> column value.</param>
		/// <param name="ctacte_caja_idNull">true if the method ignores the ctacte_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_IDCommand(decimal ctacte_caja_id, bool ctacte_caja_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_idNull)
				whereSql += "CTACTE_CAJA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_idNull)
				AddParameter(cmd, "CTACTE_CAJA_ID", ctacte_caja_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_CTABANC_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id_dest">The <c>CTACTE_BANCARIA_ID_DEST</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID_DEST(decimal ctacte_bancaria_id_dest)
		{
			return CreateDeleteByCTACTE_BANCARIA_ID_DESTCommand(ctacte_bancaria_id_dest).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CCTE_TARJ_CONF_CTABANC_DEST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id_dest">The <c>CTACTE_BANCARIA_ID_DEST</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_ID_DESTCommand(decimal ctacte_bancaria_id_dest)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID_DEST=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID_DEST");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_BANCARIA_ID_DEST", ctacte_bancaria_id_dest);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_POS</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPOS_ID(decimal pos_id)
		{
			return CreateDeleteByPOS_IDCommand(pos_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CCTE_TARJ_CONF_POS</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPOS_IDCommand(decimal pos_id)
		{
			string whereSql = "";
			whereSql += "POS_ID=" + _db.CreateSqlParameterName("POS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "POS_ID", pos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCESADORA_ID_RED_DINELCO(decimal procesadora_id_red_dinelco)
		{
			return DeleteByPROCESADORA_ID_RED_DINELCO(procesadora_id_red_dinelco, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <param name="procesadora_id_red_dinelcoNull">true if the method ignores the procesadora_id_red_dinelco
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCESADORA_ID_RED_DINELCO(decimal procesadora_id_red_dinelco, bool procesadora_id_red_dinelcoNull)
		{
			return CreateDeleteByPROCESADORA_ID_RED_DINELCOCommand(procesadora_id_red_dinelco, procesadora_id_red_dinelcoNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CCTE_TARJ_CONF_PROCES_ID_DINELCO</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_dinelco">The <c>PROCESADORA_ID_RED_DINELCO</c> column value.</param>
		/// <param name="procesadora_id_red_dinelcoNull">true if the method ignores the procesadora_id_red_dinelco
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROCESADORA_ID_RED_DINELCOCommand(decimal procesadora_id_red_dinelco, bool procesadora_id_red_dinelcoNull)
		{
			string whereSql = "";
			if(procesadora_id_red_dinelcoNull)
				whereSql += "PROCESADORA_ID_RED_DINELCO IS NULL";
			else
				whereSql += "PROCESADORA_ID_RED_DINELCO=" + _db.CreateSqlParameterName("PROCESADORA_ID_RED_DINELCO");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!procesadora_id_red_dinelcoNull)
				AddParameter(cmd, "PROCESADORA_ID_RED_DINELCO", procesadora_id_red_dinelco);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCESADORA_ID_RED_INFONET(decimal procesadora_id_red_infonet)
		{
			return DeleteByPROCESADORA_ID_RED_INFONET(procesadora_id_red_infonet, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <param name="procesadora_id_red_infonetNull">true if the method ignores the procesadora_id_red_infonet
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCESADORA_ID_RED_INFONET(decimal procesadora_id_red_infonet, bool procesadora_id_red_infonetNull)
		{
			return CreateDeleteByPROCESADORA_ID_RED_INFONETCommand(procesadora_id_red_infonet, procesadora_id_red_infonetNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CCTE_TARJ_CONF_PROCES_ID_INFONET</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id_red_infonet">The <c>PROCESADORA_ID_RED_INFONET</c> column value.</param>
		/// <param name="procesadora_id_red_infonetNull">true if the method ignores the procesadora_id_red_infonet
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROCESADORA_ID_RED_INFONETCommand(decimal procesadora_id_red_infonet, bool procesadora_id_red_infonetNull)
		{
			string whereSql = "";
			if(procesadora_id_red_infonetNull)
				whereSql += "PROCESADORA_ID_RED_INFONET IS NULL";
			else
				whereSql += "PROCESADORA_ID_RED_INFONET=" + _db.CreateSqlParameterName("PROCESADORA_ID_RED_INFONET");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!procesadora_id_red_infonetNull)
				AddParameter(cmd, "PROCESADORA_ID_RED_INFONET", procesadora_id_red_infonet);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table using the 
		/// <c>FK_CCTE_TARJ_CONF_PROCESADORA</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROCESADORA_ID(decimal procesadora_id)
		{
			return CreateDeleteByPROCESADORA_IDCommand(procesadora_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CCTE_TARJ_CONF_PROCESADORA</c> foreign key.
		/// </summary>
		/// <param name="procesadora_id">The <c>PROCESADORA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROCESADORA_IDCommand(decimal procesadora_id)
		{
			string whereSql = "";
			whereSql += "PROCESADORA_ID=" + _db.CreateSqlParameterName("PROCESADORA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PROCESADORA_ID", procesadora_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_TARJETAS_CONFIG_PROCESOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		protected CTACTE_TARJETAS_CONFIG_PROCESOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		protected CTACTE_TARJETAS_CONFIG_PROCESOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> objects.</returns>
		protected virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pos_idColumnIndex = reader.GetOrdinal("POS_ID");
			int procesadora_idColumnIndex = reader.GetOrdinal("PROCESADORA_ID");
			int comision_porcColumnIndex = reader.GetOrdinal("COMISION_PORC");
			int iva_sobre_comision_porcColumnIndex = reader.GetOrdinal("IVA_SOBRE_COMISION_PORC");
			int renta_sobre_iva_porcColumnIndex = reader.GetOrdinal("RENTA_SOBRE_IVA_PORC");
			int ctacte_bancaria_id_destColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID_DEST");
			int es_tarjeta_creditoColumnIndex = reader.GetOrdinal("ES_TARJETA_CREDITO");
			int ctacte_caja_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_ID");
			int procesadora_id_red_dinelcoColumnIndex = reader.GetOrdinal("PROCESADORA_ID_RED_DINELCO");
			int procesadora_id_red_infonetColumnIndex = reader.GetOrdinal("PROCESADORA_ID_RED_INFONET");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_TARJETAS_CONFIG_PROCESOSRow record = new CTACTE_TARJETAS_CONFIG_PROCESOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.POS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pos_idColumnIndex)), 9);
					record.PROCESADORA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(procesadora_idColumnIndex)), 9);
					record.COMISION_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(comision_porcColumnIndex)), 9);
					record.IVA_SOBRE_COMISION_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(iva_sobre_comision_porcColumnIndex)), 9);
					record.RENTA_SOBRE_IVA_PORC = Math.Round(Convert.ToDecimal(reader.GetValue(renta_sobre_iva_porcColumnIndex)), 9);
					record.CTACTE_BANCARIA_ID_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_id_destColumnIndex)), 9);
					record.ES_TARJETA_CREDITO = Convert.ToString(reader.GetValue(es_tarjeta_creditoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_idColumnIndex))
						record.CTACTE_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_idColumnIndex)), 9);
					if(!reader.IsDBNull(procesadora_id_red_dinelcoColumnIndex))
						record.PROCESADORA_ID_RED_DINELCO = Math.Round(Convert.ToDecimal(reader.GetValue(procesadora_id_red_dinelcoColumnIndex)), 9);
					if(!reader.IsDBNull(procesadora_id_red_infonetColumnIndex))
						record.PROCESADORA_ID_RED_INFONET = Math.Round(Convert.ToDecimal(reader.GetValue(procesadora_id_red_infonetColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_TARJETAS_CONFIG_PROCESOSRow[])(recordList.ToArray(typeof(CTACTE_TARJETAS_CONFIG_PROCESOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_TARJETAS_CONFIG_PROCESOSRow"/> object.</returns>
		protected virtual CTACTE_TARJETAS_CONFIG_PROCESOSRow MapRow(DataRow row)
		{
			CTACTE_TARJETAS_CONFIG_PROCESOSRow mappedObject = new CTACTE_TARJETAS_CONFIG_PROCESOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "POS_ID"
			dataColumn = dataTable.Columns["POS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.POS_ID = (decimal)row[dataColumn];
			// Column "PROCESADORA_ID"
			dataColumn = dataTable.Columns["PROCESADORA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_ID = (decimal)row[dataColumn];
			// Column "COMISION_PORC"
			dataColumn = dataTable.Columns["COMISION_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_PORC = (decimal)row[dataColumn];
			// Column "IVA_SOBRE_COMISION_PORC"
			dataColumn = dataTable.Columns["IVA_SOBRE_COMISION_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.IVA_SOBRE_COMISION_PORC = (decimal)row[dataColumn];
			// Column "RENTA_SOBRE_IVA_PORC"
			dataColumn = dataTable.Columns["RENTA_SOBRE_IVA_PORC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RENTA_SOBRE_IVA_PORC = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID_DEST"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID_DEST = (decimal)row[dataColumn];
			// Column "ES_TARJETA_CREDITO"
			dataColumn = dataTable.Columns["ES_TARJETA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_TARJETA_CREDITO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_ID = (decimal)row[dataColumn];
			// Column "PROCESADORA_ID_RED_DINELCO"
			dataColumn = dataTable.Columns["PROCESADORA_ID_RED_DINELCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_ID_RED_DINELCO = (decimal)row[dataColumn];
			// Column "PROCESADORA_ID_RED_INFONET"
			dataColumn = dataTable.Columns["PROCESADORA_ID_RED_INFONET"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADORA_ID_RED_INFONET = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_TARJETAS_CONFIG_PROCESOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_TARJETAS_CONFIG_PROCESOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("POS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROCESADORA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COMISION_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IVA_SOBRE_COMISION_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RENTA_SOBRE_IVA_PORC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_TARJETA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROCESADORA_ID_RED_DINELCO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROCESADORA_ID_RED_INFONET", typeof(decimal));
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

				case "POS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCESADORA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IVA_SOBRE_COMISION_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RENTA_SOBRE_IVA_PORC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_ID_DEST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_TARJETA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCESADORA_ID_RED_DINELCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCESADORA_ID_RED_INFONET":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_TARJETAS_CONFIG_PROCESOSCollection_Base class
}  // End of namespace
