// <fileinfo name="APLICACION_DOCUMENTOS_DOCCollection_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMENTOS_DOCCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="APLICACION_DOCUMENTOS_DOCCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMENTOS_DOCCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string APLICACION_DOCUMENTO_IDColumnName = "APLICACION_DOCUMENTO_ID";
		public const string CTACTE_PERSONA_IDColumnName = "CTACTE_PERSONA_ID";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string APLICACION_DOCU_DOC_REFERID_IDColumnName = "APLICACION_DOCU_DOC_REFERID_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMENTOS_DOCCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public APLICACION_DOCUMENTOS_DOCCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>APLICACION_DOCUMENTOS_DOC</c> table.
		/// </summary>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_DOCRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>APLICACION_DOCUMENTOS_DOC</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>APLICACION_DOCUMENTOS_DOC</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public APLICACION_DOCUMENTOS_DOCRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			APLICACION_DOCUMENTOS_DOCRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public APLICACION_DOCUMENTOS_DOCRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects that 
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_DOCRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.APLICACION_DOCUMENTOS_DOC";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="APLICACION_DOCUMENTOS_DOCRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual APLICACION_DOCUMENTOS_DOCRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			APLICACION_DOCUMENTOS_DOCRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects 
		/// by the <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public APLICACION_DOCUMENTOS_DOCRow[] GetByAPLICACION_DOCU_DOC_REFERID_ID(decimal aplicacion_docu_doc_referid_id)
		{
			return GetByAPLICACION_DOCU_DOC_REFERID_ID(aplicacion_docu_doc_referid_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects 
		/// by the <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <param name="aplicacion_docu_doc_referid_idNull">true if the method ignores the aplicacion_docu_doc_referid_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_DOCRow[] GetByAPLICACION_DOCU_DOC_REFERID_ID(decimal aplicacion_docu_doc_referid_id, bool aplicacion_docu_doc_referid_idNull)
		{
			return MapRecords(CreateGetByAPLICACION_DOCU_DOC_REFERID_IDCommand(aplicacion_docu_doc_referid_id, aplicacion_docu_doc_referid_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPLICACION_DOCU_DOC_REFERID_IDAsDataTable(decimal aplicacion_docu_doc_referid_id)
		{
			return GetByAPLICACION_DOCU_DOC_REFERID_IDAsDataTable(aplicacion_docu_doc_referid_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <param name="aplicacion_docu_doc_referid_idNull">true if the method ignores the aplicacion_docu_doc_referid_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPLICACION_DOCU_DOC_REFERID_IDAsDataTable(decimal aplicacion_docu_doc_referid_id, bool aplicacion_docu_doc_referid_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPLICACION_DOCU_DOC_REFERID_IDCommand(aplicacion_docu_doc_referid_id, aplicacion_docu_doc_referid_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <param name="aplicacion_docu_doc_referid_idNull">true if the method ignores the aplicacion_docu_doc_referid_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPLICACION_DOCU_DOC_REFERID_IDCommand(decimal aplicacion_docu_doc_referid_id, bool aplicacion_docu_doc_referid_idNull)
		{
			string whereSql = "";
			if(aplicacion_docu_doc_referid_idNull)
				whereSql += "APLICACION_DOCU_DOC_REFERID_ID IS NULL";
			else
				whereSql += "APLICACION_DOCU_DOC_REFERID_ID=" + _db.CreateSqlParameterName("APLICACION_DOCU_DOC_REFERID_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aplicacion_docu_doc_referid_idNull)
				AddParameter(cmd, "APLICACION_DOCU_DOC_REFERID_ID", aplicacion_docu_doc_referid_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_APLIC_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_id">The <c>APLICACION_DOCUMENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_DOCRow[] GetByAPLICACION_DOCUMENTO_ID(decimal aplicacion_documento_id)
		{
			return MapRecords(CreateGetByAPLICACION_DOCUMENTO_IDCommand(aplicacion_documento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_APLIC_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_id">The <c>APLICACION_DOCUMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPLICACION_DOCUMENTO_IDAsDataTable(decimal aplicacion_documento_id)
		{
			return MapRecordsToDataTable(CreateGetByAPLICACION_DOCUMENTO_IDCommand(aplicacion_documento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_DOC_APLIC_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_id">The <c>APLICACION_DOCUMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPLICACION_DOCUMENTO_IDCommand(decimal aplicacion_documento_id)
		{
			string whereSql = "";
			whereSql += "APLICACION_DOCUMENTO_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "APLICACION_DOCUMENTO_ID", aplicacion_documento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public APLICACION_DOCUMENTOS_DOCRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_DOCRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_IDAsDataTable(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
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
		/// return records by the <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
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
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_DOCRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_APLIC_DOCUMEN_DOC_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_APLIC_DOCUMEN_DOC_MONEDA</c> foreign key.
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
		/// Adds a new record into the <c>APLICACION_DOCUMENTOS_DOC</c> table.
		/// </summary>
		/// <param name="value">The <see cref="APLICACION_DOCUMENTOS_DOCRow"/> object to be inserted.</param>
		public virtual void Insert(APLICACION_DOCUMENTOS_DOCRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.APLICACION_DOCUMENTOS_DOC (" +
				"ID, " +
				"APLICACION_DOCUMENTO_ID, " +
				"CTACTE_PERSONA_ID, " +
				"MONTO_ORIGEN, " +
				"MONTO_DESTINO, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"APLICACION_DOCU_DOC_REFERID_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("APLICACION_DOCUMENTO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("APLICACION_DOCU_DOC_REFERID_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "APLICACION_DOCUMENTO_ID", value.APLICACION_DOCUMENTO_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "APLICACION_DOCU_DOC_REFERID_ID",
				value.IsAPLICACION_DOCU_DOC_REFERID_IDNull ? DBNull.Value : (object)value.APLICACION_DOCU_DOC_REFERID_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>APLICACION_DOCUMENTOS_DOC</c> table.
		/// </summary>
		/// <param name="value">The <see cref="APLICACION_DOCUMENTOS_DOCRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(APLICACION_DOCUMENTOS_DOCRow value)
		{
			
			string sqlStr = "UPDATE TRC.APLICACION_DOCUMENTOS_DOC SET " +
				"APLICACION_DOCUMENTO_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_ID") + ", " +
				"CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				"MONTO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				"MONTO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"APLICACION_DOCU_DOC_REFERID_ID=" + _db.CreateSqlParameterName("APLICACION_DOCU_DOC_REFERID_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "APLICACION_DOCUMENTO_ID", value.APLICACION_DOCUMENTO_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "APLICACION_DOCU_DOC_REFERID_ID",
				value.IsAPLICACION_DOCU_DOC_REFERID_IDNull ? DBNull.Value : (object)value.APLICACION_DOCU_DOC_REFERID_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>APLICACION_DOCUMENTOS_DOC</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>APLICACION_DOCUMENTOS_DOC</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>APLICACION_DOCUMENTOS_DOC</c> table.
		/// </summary>
		/// <param name="value">The <see cref="APLICACION_DOCUMENTOS_DOCRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(APLICACION_DOCUMENTOS_DOCRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>APLICACION_DOCUMENTOS_DOC</c> table using
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS_DOC</c> table using the 
		/// <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCU_DOC_REFERID_ID(decimal aplicacion_docu_doc_referid_id)
		{
			return DeleteByAPLICACION_DOCU_DOC_REFERID_ID(aplicacion_docu_doc_referid_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS_DOC</c> table using the 
		/// <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <param name="aplicacion_docu_doc_referid_idNull">true if the method ignores the aplicacion_docu_doc_referid_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCU_DOC_REFERID_ID(decimal aplicacion_docu_doc_referid_id, bool aplicacion_docu_doc_referid_idNull)
		{
			return CreateDeleteByAPLICACION_DOCU_DOC_REFERID_IDCommand(aplicacion_docu_doc_referid_id, aplicacion_docu_doc_referid_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCU_DOC_APL_DOC_REF</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_docu_doc_referid_id">The <c>APLICACION_DOCU_DOC_REFERID_ID</c> column value.</param>
		/// <param name="aplicacion_docu_doc_referid_idNull">true if the method ignores the aplicacion_docu_doc_referid_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPLICACION_DOCU_DOC_REFERID_IDCommand(decimal aplicacion_docu_doc_referid_id, bool aplicacion_docu_doc_referid_idNull)
		{
			string whereSql = "";
			if(aplicacion_docu_doc_referid_idNull)
				whereSql += "APLICACION_DOCU_DOC_REFERID_ID IS NULL";
			else
				whereSql += "APLICACION_DOCU_DOC_REFERID_ID=" + _db.CreateSqlParameterName("APLICACION_DOCU_DOC_REFERID_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aplicacion_docu_doc_referid_idNull)
				AddParameter(cmd, "APLICACION_DOCU_DOC_REFERID_ID", aplicacion_docu_doc_referid_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS_DOC</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_DOC_APLIC_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_id">The <c>APLICACION_DOCUMENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTO_ID(decimal aplicacion_documento_id)
		{
			return CreateDeleteByAPLICACION_DOCUMENTO_IDCommand(aplicacion_documento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_DOC_APLIC_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_id">The <c>APLICACION_DOCUMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPLICACION_DOCUMENTO_IDCommand(decimal aplicacion_documento_id)
		{
			string whereSql = "";
			whereSql += "APLICACION_DOCUMENTO_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "APLICACION_DOCUMENTO_ID", aplicacion_documento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS_DOC</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return DeleteByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>APLICACION_DOCUMENTOS_DOC</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
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
		/// delete records using the <c>FK_APLIC_DOCUMEN_DOC_CTACTE</c> foreign key.
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
		/// Deletes records from the <c>APLICACION_DOCUMENTOS_DOC</c> table using the 
		/// <c>FK_APLIC_DOCUMEN_DOC_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_APLIC_DOCUMEN_DOC_MONEDA</c> foreign key.
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
		/// Deletes <c>APLICACION_DOCUMENTOS_DOC</c> records that match the specified criteria.
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
		/// to delete <c>APLICACION_DOCUMENTOS_DOC</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.APLICACION_DOCUMENTOS_DOC";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>APLICACION_DOCUMENTOS_DOC</c> table.
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		protected APLICACION_DOCUMENTOS_DOCRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		protected APLICACION_DOCUMENTOS_DOCRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_DOCRow"/> objects.</returns>
		protected virtual APLICACION_DOCUMENTOS_DOCRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int aplicacion_documento_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTO_ID");
			int ctacte_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ID");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int aplicacion_docu_doc_referid_idColumnIndex = reader.GetOrdinal("APLICACION_DOCU_DOC_REFERID_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					APLICACION_DOCUMENTOS_DOCRow record = new APLICACION_DOCUMENTOS_DOCRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.APLICACION_DOCUMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documento_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_persona_idColumnIndex))
						record.CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_idColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_docu_doc_referid_idColumnIndex))
						record.APLICACION_DOCU_DOC_REFERID_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_docu_doc_referid_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (APLICACION_DOCUMENTOS_DOCRow[])(recordList.ToArray(typeof(APLICACION_DOCUMENTOS_DOCRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="APLICACION_DOCUMENTOS_DOCRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="APLICACION_DOCUMENTOS_DOCRow"/> object.</returns>
		protected virtual APLICACION_DOCUMENTOS_DOCRow MapRow(DataRow row)
		{
			APLICACION_DOCUMENTOS_DOCRow mappedObject = new APLICACION_DOCUMENTOS_DOCRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTO_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "APLICACION_DOCU_DOC_REFERID_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCU_DOC_REFERID_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCU_DOC_REFERID_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>APLICACION_DOCUMENTOS_DOC</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "APLICACION_DOCUMENTOS_DOC";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APLICACION_DOCU_DOC_REFERID_ID", typeof(decimal));
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

				case "APLICACION_DOCUMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCU_DOC_REFERID_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of APLICACION_DOCUMENTOS_DOCCollection_Base class
}  // End of namespace
