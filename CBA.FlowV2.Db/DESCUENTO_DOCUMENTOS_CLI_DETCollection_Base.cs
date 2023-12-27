// <fileinfo name="DESCUENTO_DOCUMENTOS_CLI_DETCollection_Base.cs">
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
	/// The base class for <see cref="DESCUENTO_DOCUMENTOS_CLI_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESCUENTO_DOCUMENTOS_CLI_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTO_DOCUMENTOS_CLI_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string DESCUENTO_DOCUMENTOS_CLI_IDColumnName = "DESCUENTO_DOCUMENTOS_CLI_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string TOTAL_VALOR_NOMINALColumnName = "TOTAL_VALOR_NOMINAL";
		public const string TOTAL_VALOR_EFECTIVOColumnName = "TOTAL_VALOR_EFECTIVO";
		public const string TOTAL_RETENCIONColumnName = "TOTAL_RETENCION";
		public const string PORCENTAJE_INTERES_ANUALColumnName = "PORCENTAJE_INTERES_ANUAL";
		public const string PORCENTAJE_GASTO_ADMINColumnName = "PORCENTAJE_GASTO_ADMIN";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string NOMBRE_DEUDORColumnName = "NOMBRE_DEUDOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string CHEQUE_CTACTE_BANCO_IDColumnName = "CHEQUE_CTACTE_BANCO_ID";
		public const string CHEQUE_NRO_CUENTAColumnName = "CHEQUE_NRO_CUENTA";
		public const string CHEQUE_DE_TERCEROSColumnName = "CHEQUE_DE_TERCEROS";
		public const string CHEQUE_DOCUMENTO_EMISORColumnName = "CHEQUE_DOCUMENTO_EMISOR";
		public const string CTACTE_DOCUMENTO_RECIBIDO_IDColumnName = "CTACTE_DOCUMENTO_RECIBIDO_ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CHEQUE_ES_DIFERIDOColumnName = "CHEQUE_ES_DIFERIDO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTO_DOCUMENTOS_CLI_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESCUENTO_DOCUMENTOS_CLI_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESCUENTO_DOCUMENTOS_CLI_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESCUENTO_DOCUMENTOS_CLI_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESCUENTO_DOCUMENTOS_CLI_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DESCUENTO_DOCUMENTOS_CLI_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id)
		{
			return GetByCHEQUE_CTACTE_BANCO_ID(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return MapRecords(CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(decimal cheque_ctacte_banco_id)
		{
			return GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			string whereSql = "";
			if(cheque_ctacte_banco_idNull)
				whereSql += "CHEQUE_CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cheque_ctacte_banco_idNull)
				AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID", cheque_ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_recibido_idNull)
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_DESC_DOC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_cli_id">The <c>DESCUENTO_DOCUMENTOS_CLI_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByDESCUENTO_DOCUMENTOS_CLI_ID(decimal descuento_documentos_cli_id)
		{
			return MapRecords(CreateGetByDESCUENTO_DOCUMENTOS_CLI_IDCommand(descuento_documentos_cli_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_DESC_DOC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_cli_id">The <c>DESCUENTO_DOCUMENTOS_CLI_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_DOCUMENTOS_CLI_IDAsDataTable(decimal descuento_documentos_cli_id)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_DOCUMENTOS_CLI_IDCommand(descuento_documentos_cli_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESC_DOC_CLI_DET_DESC_DOC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_cli_id">The <c>DESCUENTO_DOCUMENTOS_CLI_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_DOCUMENTOS_CLI_IDCommand(decimal descuento_documentos_cli_id)
		{
			string whereSql = "";
			whereSql += "DESCUENTO_DOCUMENTOS_CLI_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_CLI_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DESCUENTO_DOCUMENTOS_CLI_ID", descuento_documentos_cli_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByCTACTE_DOCUMENTO_RECIBIDO_ID(decimal ctacte_documento_recibido_id)
		{
			return GetByCTACTE_DOCUMENTO_RECIBIDO_ID(ctacte_documento_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_documento_recibido_idNull">true if the method ignores the ctacte_documento_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByCTACTE_DOCUMENTO_RECIBIDO_ID(decimal ctacte_documento_recibido_id, bool ctacte_documento_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_DOCUMENTO_RECIBIDO_IDCommand(ctacte_documento_recibido_id, ctacte_documento_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_DOCUMENTO_RECIBIDO_IDAsDataTable(decimal ctacte_documento_recibido_id)
		{
			return GetByCTACTE_DOCUMENTO_RECIBIDO_IDAsDataTable(ctacte_documento_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_documento_recibido_idNull">true if the method ignores the ctacte_documento_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_DOCUMENTO_RECIBIDO_IDAsDataTable(decimal ctacte_documento_recibido_id, bool ctacte_documento_recibido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_DOCUMENTO_RECIBIDO_IDCommand(ctacte_documento_recibido_id, ctacte_documento_recibido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_documento_recibido_idNull">true if the method ignores the ctacte_documento_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_DOCUMENTO_RECIBIDO_IDCommand(decimal ctacte_documento_recibido_id, bool ctacte_documento_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_documento_recibido_idNull)
				whereSql += "CTACTE_DOCUMENTO_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_DOCUMENTO_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_DOCUMENTO_RECIBIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_documento_recibido_idNull)
				AddParameter(cmd, "CTACTE_DOCUMENTO_RECIBIDO_ID", ctacte_documento_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESC_DOC_CLI_DET_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
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
		/// return records by the <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
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
		/// Gets an array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects 
		/// by the <c>FK_DESC_DOC_CLI_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		public virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESC_DOC_CLI_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESC_DOC_CLI_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> object to be inserted.</param>
		public virtual void Insert(DESCUENTO_DOCUMENTOS_CLI_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DESCUENTO_DOCUMENTOS_CLI_DET (" +
				"ID, " +
				"DESCUENTO_DOCUMENTOS_CLI_ID, " +
				"PERSONA_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"TOTAL_VALOR_NOMINAL, " +
				"TOTAL_VALOR_EFECTIVO, " +
				"TOTAL_RETENCION, " +
				"PORCENTAJE_INTERES_ANUAL, " +
				"PORCENTAJE_GASTO_ADMIN, " +
				"CTACTE_VALOR_ID, " +
				"FECHA_CREACION, " +
				"NRO_COMPROBANTE, " +
				"NOMBRE_DEUDOR, " +
				"NOMBRE_BENEFICIARIO, " +
				"CHEQUE_CTACTE_BANCO_ID, " +
				"CHEQUE_NRO_CUENTA, " +
				"CHEQUE_DE_TERCEROS, " +
				"CHEQUE_DOCUMENTO_EMISOR, " +
				"CTACTE_DOCUMENTO_RECIBIDO_ID, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"OBSERVACION, " +
				"CHEQUE_ES_DIFERIDO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_CLI_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("TOTAL_VALOR_NOMINAL") + ", " +
				_db.CreateSqlParameterName("TOTAL_VALOR_EFECTIVO") + ", " +
				_db.CreateSqlParameterName("TOTAL_RETENCION") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_INTERES_ANUAL") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_GASTO_ADMIN") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("NOMBRE_DEUDOR") + ", " +
				_db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NRO_CUENTA") + ", " +
				_db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				_db.CreateSqlParameterName("CHEQUE_DOCUMENTO_EMISOR") + ", " +
				_db.CreateSqlParameterName("CTACTE_DOCUMENTO_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CHEQUE_ES_DIFERIDO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTOS_CLI_ID", value.DESCUENTO_DOCUMENTOS_CLI_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "TOTAL_VALOR_NOMINAL", value.TOTAL_VALOR_NOMINAL);
			AddParameter(cmd, "TOTAL_VALOR_EFECTIVO", value.TOTAL_VALOR_EFECTIVO);
			AddParameter(cmd, "TOTAL_RETENCION", value.TOTAL_RETENCION);
			AddParameter(cmd, "PORCENTAJE_INTERES_ANUAL", value.PORCENTAJE_INTERES_ANUAL);
			AddParameter(cmd, "PORCENTAJE_GASTO_ADMIN", value.PORCENTAJE_GASTO_ADMIN);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "NOMBRE_DEUDOR", value.NOMBRE_DEUDOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID",
				value.IsCHEQUE_CTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CHEQUE_CTACTE_BANCO_ID);
			AddParameter(cmd, "CHEQUE_NRO_CUENTA", value.CHEQUE_NRO_CUENTA);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "CHEQUE_DOCUMENTO_EMISOR", value.CHEQUE_DOCUMENTO_EMISOR);
			AddParameter(cmd, "CTACTE_DOCUMENTO_RECIBIDO_ID",
				value.IsCTACTE_DOCUMENTO_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_DOCUMENTO_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CHEQUE_ES_DIFERIDO", value.CHEQUE_ES_DIFERIDO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DESCUENTO_DOCUMENTOS_CLI_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.DESCUENTO_DOCUMENTOS_CLI_DET SET " +
				"DESCUENTO_DOCUMENTOS_CLI_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_CLI_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"TOTAL_VALOR_NOMINAL=" + _db.CreateSqlParameterName("TOTAL_VALOR_NOMINAL") + ", " +
				"TOTAL_VALOR_EFECTIVO=" + _db.CreateSqlParameterName("TOTAL_VALOR_EFECTIVO") + ", " +
				"TOTAL_RETENCION=" + _db.CreateSqlParameterName("TOTAL_RETENCION") + ", " +
				"PORCENTAJE_INTERES_ANUAL=" + _db.CreateSqlParameterName("PORCENTAJE_INTERES_ANUAL") + ", " +
				"PORCENTAJE_GASTO_ADMIN=" + _db.CreateSqlParameterName("PORCENTAJE_GASTO_ADMIN") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"NOMBRE_DEUDOR=" + _db.CreateSqlParameterName("NOMBRE_DEUDOR") + ", " +
				"NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				"CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID") + ", " +
				"CHEQUE_NRO_CUENTA=" + _db.CreateSqlParameterName("CHEQUE_NRO_CUENTA") + ", " +
				"CHEQUE_DE_TERCEROS=" + _db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				"CHEQUE_DOCUMENTO_EMISOR=" + _db.CreateSqlParameterName("CHEQUE_DOCUMENTO_EMISOR") + ", " +
				"CTACTE_DOCUMENTO_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_DOCUMENTO_RECIBIDO_ID") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CHEQUE_ES_DIFERIDO=" + _db.CreateSqlParameterName("CHEQUE_ES_DIFERIDO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "DESCUENTO_DOCUMENTOS_CLI_ID", value.DESCUENTO_DOCUMENTOS_CLI_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "TOTAL_VALOR_NOMINAL", value.TOTAL_VALOR_NOMINAL);
			AddParameter(cmd, "TOTAL_VALOR_EFECTIVO", value.TOTAL_VALOR_EFECTIVO);
			AddParameter(cmd, "TOTAL_RETENCION", value.TOTAL_RETENCION);
			AddParameter(cmd, "PORCENTAJE_INTERES_ANUAL", value.PORCENTAJE_INTERES_ANUAL);
			AddParameter(cmd, "PORCENTAJE_GASTO_ADMIN", value.PORCENTAJE_GASTO_ADMIN);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "NOMBRE_DEUDOR", value.NOMBRE_DEUDOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID",
				value.IsCHEQUE_CTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CHEQUE_CTACTE_BANCO_ID);
			AddParameter(cmd, "CHEQUE_NRO_CUENTA", value.CHEQUE_NRO_CUENTA);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "CHEQUE_DOCUMENTO_EMISOR", value.CHEQUE_DOCUMENTO_EMISOR);
			AddParameter(cmd, "CTACTE_DOCUMENTO_RECIBIDO_ID",
				value.IsCTACTE_DOCUMENTO_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_DOCUMENTO_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CHEQUE_ES_DIFERIDO", value.CHEQUE_ES_DIFERIDO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DESCUENTO_DOCUMENTOS_CLI_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using
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
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id)
		{
			return DeleteByCHEQUE_CTACTE_BANCO_ID(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return CreateDeleteByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESC_DOC_CLI_DET_BANCO</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCHEQUE_CTACTE_BANCO_IDCommand(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			string whereSql = "";
			if(cheque_ctacte_banco_idNull)
				whereSql += "CHEQUE_CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cheque_ctacte_banco_idNull)
				AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID", cheque_ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESC_DOC_CLI_DET_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_recibido_idNull)
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_DESC_DOC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_cli_id">The <c>DESCUENTO_DOCUMENTOS_CLI_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTOS_CLI_ID(decimal descuento_documentos_cli_id)
		{
			return CreateDeleteByDESCUENTO_DOCUMENTOS_CLI_IDCommand(descuento_documentos_cli_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESC_DOC_CLI_DET_DESC_DOC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documentos_cli_id">The <c>DESCUENTO_DOCUMENTOS_CLI_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_DOCUMENTOS_CLI_IDCommand(decimal descuento_documentos_cli_id)
		{
			string whereSql = "";
			whereSql += "DESCUENTO_DOCUMENTOS_CLI_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTOS_CLI_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DESCUENTO_DOCUMENTOS_CLI_ID", descuento_documentos_cli_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_DOCUMENTO_RECIBIDO_ID(decimal ctacte_documento_recibido_id)
		{
			return DeleteByCTACTE_DOCUMENTO_RECIBIDO_ID(ctacte_documento_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_documento_recibido_idNull">true if the method ignores the ctacte_documento_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_DOCUMENTO_RECIBIDO_ID(decimal ctacte_documento_recibido_id, bool ctacte_documento_recibido_idNull)
		{
			return CreateDeleteByCTACTE_DOCUMENTO_RECIBIDO_IDCommand(ctacte_documento_recibido_id, ctacte_documento_recibido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESC_DOC_CLI_DET_DOC_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_documento_recibido_id">The <c>CTACTE_DOCUMENTO_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_documento_recibido_idNull">true if the method ignores the ctacte_documento_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_DOCUMENTO_RECIBIDO_IDCommand(decimal ctacte_documento_recibido_id, bool ctacte_documento_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_documento_recibido_idNull)
				whereSql += "CTACTE_DOCUMENTO_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_DOCUMENTO_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_DOCUMENTO_RECIBIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_documento_recibido_idNull)
				AddParameter(cmd, "CTACTE_DOCUMENTO_RECIBIDO_ID", ctacte_documento_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESC_DOC_CLI_DET_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
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
		/// delete records using the <c>FK_DESC_DOC_CLI_DET_PERS</c> foreign key.
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
		/// Deletes records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table using the 
		/// <c>FK_DESC_DOC_CLI_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESC_DOC_CLI_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> records that match the specified criteria.
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
		/// to delete <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DESCUENTO_DOCUMENTOS_CLI_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		protected DESCUENTO_DOCUMENTOS_CLI_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		protected DESCUENTO_DOCUMENTOS_CLI_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> objects.</returns>
		protected virtual DESCUENTO_DOCUMENTOS_CLI_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int descuento_documentos_cli_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTOS_CLI_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int total_valor_nominalColumnIndex = reader.GetOrdinal("TOTAL_VALOR_NOMINAL");
			int total_valor_efectivoColumnIndex = reader.GetOrdinal("TOTAL_VALOR_EFECTIVO");
			int total_retencionColumnIndex = reader.GetOrdinal("TOTAL_RETENCION");
			int porcentaje_interes_anualColumnIndex = reader.GetOrdinal("PORCENTAJE_INTERES_ANUAL");
			int porcentaje_gasto_adminColumnIndex = reader.GetOrdinal("PORCENTAJE_GASTO_ADMIN");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int nombre_deudorColumnIndex = reader.GetOrdinal("NOMBRE_DEUDOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int cheque_ctacte_banco_idColumnIndex = reader.GetOrdinal("CHEQUE_CTACTE_BANCO_ID");
			int cheque_nro_cuentaColumnIndex = reader.GetOrdinal("CHEQUE_NRO_CUENTA");
			int cheque_de_tercerosColumnIndex = reader.GetOrdinal("CHEQUE_DE_TERCEROS");
			int cheque_documento_emisorColumnIndex = reader.GetOrdinal("CHEQUE_DOCUMENTO_EMISOR");
			int ctacte_documento_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_DOCUMENTO_RECIBIDO_ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cheque_es_diferidoColumnIndex = reader.GetOrdinal("CHEQUE_ES_DIFERIDO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESCUENTO_DOCUMENTOS_CLI_DETRow record = new DESCUENTO_DOCUMENTOS_CLI_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.DESCUENTO_DOCUMENTOS_CLI_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documentos_cli_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.TOTAL_VALOR_NOMINAL = Math.Round(Convert.ToDecimal(reader.GetValue(total_valor_nominalColumnIndex)), 9);
					record.TOTAL_VALOR_EFECTIVO = Math.Round(Convert.ToDecimal(reader.GetValue(total_valor_efectivoColumnIndex)), 9);
					record.TOTAL_RETENCION = Math.Round(Convert.ToDecimal(reader.GetValue(total_retencionColumnIndex)), 9);
					record.PORCENTAJE_INTERES_ANUAL = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_interes_anualColumnIndex)), 9);
					record.PORCENTAJE_GASTO_ADMIN = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_gasto_adminColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.NOMBRE_DEUDOR = Convert.ToString(reader.GetValue(nombre_deudorColumnIndex));
					record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cheque_ctacte_banco_idColumnIndex))
						record.CHEQUE_CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_nro_cuentaColumnIndex))
						record.CHEQUE_NRO_CUENTA = Convert.ToString(reader.GetValue(cheque_nro_cuentaColumnIndex));
					if(!reader.IsDBNull(cheque_de_tercerosColumnIndex))
						record.CHEQUE_DE_TERCEROS = Convert.ToString(reader.GetValue(cheque_de_tercerosColumnIndex));
					if(!reader.IsDBNull(cheque_documento_emisorColumnIndex))
						record.CHEQUE_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(cheque_documento_emisorColumnIndex));
					if(!reader.IsDBNull(ctacte_documento_recibido_idColumnIndex))
						record.CTACTE_DOCUMENTO_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_documento_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(cheque_es_diferidoColumnIndex))
						record.CHEQUE_ES_DIFERIDO = Convert.ToString(reader.GetValue(cheque_es_diferidoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESCUENTO_DOCUMENTOS_CLI_DETRow[])(recordList.ToArray(typeof(DESCUENTO_DOCUMENTOS_CLI_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESCUENTO_DOCUMENTOS_CLI_DETRow"/> object.</returns>
		protected virtual DESCUENTO_DOCUMENTOS_CLI_DETRow MapRow(DataRow row)
		{
			DESCUENTO_DOCUMENTOS_CLI_DETRow mappedObject = new DESCUENTO_DOCUMENTOS_CLI_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTOS_CLI_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTOS_CLI_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTOS_CLI_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "TOTAL_VALOR_NOMINAL"
			dataColumn = dataTable.Columns["TOTAL_VALOR_NOMINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_VALOR_NOMINAL = (decimal)row[dataColumn];
			// Column "TOTAL_VALOR_EFECTIVO"
			dataColumn = dataTable.Columns["TOTAL_VALOR_EFECTIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_VALOR_EFECTIVO = (decimal)row[dataColumn];
			// Column "TOTAL_RETENCION"
			dataColumn = dataTable.Columns["TOTAL_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RETENCION = (decimal)row[dataColumn];
			// Column "PORCENTAJE_INTERES_ANUAL"
			dataColumn = dataTable.Columns["PORCENTAJE_INTERES_ANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_INTERES_ANUAL = (decimal)row[dataColumn];
			// Column "PORCENTAJE_GASTO_ADMIN"
			dataColumn = dataTable.Columns["PORCENTAJE_GASTO_ADMIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_GASTO_ADMIN = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NOMBRE_DEUDOR"
			dataColumn = dataTable.Columns["NOMBRE_DEUDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_DEUDOR = (string)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CHEQUE_CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CHEQUE_CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CHEQUE_NRO_CUENTA"
			dataColumn = dataTable.Columns["CHEQUE_NRO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NRO_CUENTA = (string)row[dataColumn];
			// Column "CHEQUE_DE_TERCEROS"
			dataColumn = dataTable.Columns["CHEQUE_DE_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DE_TERCEROS = (string)row[dataColumn];
			// Column "CHEQUE_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["CHEQUE_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "CTACTE_DOCUMENTO_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_DOCUMENTO_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_DOCUMENTO_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CHEQUE_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CHEQUE_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ES_DIFERIDO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESCUENTO_DOCUMENTOS_CLI_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESCUENTO_DOCUMENTOS_CLI_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTOS_CLI_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_VALOR_NOMINAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_VALOR_EFECTIVO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_RETENCION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_INTERES_ANUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_GASTO_ADMIN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_DEUDOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CHEQUE_CTACTE_BANCO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHEQUE_NRO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("CHEQUE_DE_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CHEQUE_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CTACTE_DOCUMENTO_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("CHEQUE_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "DESCUENTO_DOCUMENTOS_CLI_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_VALOR_NOMINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_VALOR_EFECTIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_INTERES_ANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_GASTO_ADMIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_DEUDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_NRO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DE_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CHEQUE_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_DOCUMENTO_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESCUENTO_DOCUMENTOS_CLI_DETCollection_Base class
}  // End of namespace
