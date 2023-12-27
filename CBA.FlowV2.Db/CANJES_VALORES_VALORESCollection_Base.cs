// <fileinfo name="CANJES_VALORES_VALORESCollection_Base.cs">
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
	/// The base class for <see cref="CANJES_VALORES_VALORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CANJES_VALORES_VALORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CANJES_VALORES_VALORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CANJE_VALOR_IDColumnName = "CANJE_VALOR_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string NUMERO_CUENTAColumnName = "NUMERO_CUENTA";
		public const string NUMERO_CHEQUEColumnName = "NUMERO_CHEQUE";
		public const string NOMBRE_EMISORColumnName = "NOMBRE_EMISOR";
		public const string NUMERO_DOCUMENTO_EMISORColumnName = "NUMERO_DOCUMENTO_EMISOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_POSDATADOColumnName = "FECHA_POSDATADO";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CHEQUE_DE_TERCEROSColumnName = "CHEQUE_DE_TERCEROS";
		public const string ES_DIFERIDOColumnName = "ES_DIFERIDO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CANJES_VALORES_VALORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CANJES_VALORES_VALORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CANJES_VALORES_VALORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public virtual CANJES_VALORES_VALORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CANJES_VALORES_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CANJES_VALORES_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CANJES_VALORES_VALORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CANJES_VALORES_VALORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CANJES_VALORES_VALORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CANJES_VALORES_VALORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public CANJES_VALORES_VALORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects that 
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
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public virtual CANJES_VALORES_VALORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CANJES_VALORES_VALORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CANJES_VALORES_VALORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CANJES_VALORES_VALORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CANJES_VALORES_VALORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CANJES_VALORES_VALORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects 
		/// by the <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public CANJES_VALORES_VALORESRow[] GetByCTACTE_BANCO_ID(decimal ctacte_banco_id)
		{
			return GetByCTACTE_BANCO_ID(ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects 
		/// by the <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="ctacte_banco_idNull">true if the method ignores the ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public virtual CANJES_VALORES_VALORESRow[] GetByCTACTE_BANCO_ID(decimal ctacte_banco_id, bool ctacte_banco_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANCO_IDCommand(ctacte_banco_id, ctacte_banco_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANCO_IDAsDataTable(decimal ctacte_banco_id)
		{
			return GetByCTACTE_BANCO_IDAsDataTable(ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="ctacte_banco_idNull">true if the method ignores the ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCO_IDAsDataTable(decimal ctacte_banco_id, bool ctacte_banco_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCO_IDCommand(ctacte_banco_id, ctacte_banco_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="ctacte_banco_idNull">true if the method ignores the ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCO_IDCommand(decimal ctacte_banco_id, bool ctacte_banco_idNull)
		{
			string whereSql = "";
			if(ctacte_banco_idNull)
				whereSql += "CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_banco_idNull)
				AddParameter(cmd, "CTACTE_BANCO_ID", ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects 
		/// by the <c>FK_CANJES_VALORES_VAL_CANJE</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_id">The <c>CANJE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public virtual CANJES_VALORES_VALORESRow[] GetByCANJE_VALOR_ID(decimal canje_valor_id)
		{
			return MapRecords(CreateGetByCANJE_VALOR_IDCommand(canje_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CANJES_VALORES_VAL_CANJE</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_id">The <c>CANJE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCANJE_VALOR_IDAsDataTable(decimal canje_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCANJE_VALOR_IDCommand(canje_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CANJES_VALORES_VAL_CANJE</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_id">The <c>CANJE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCANJE_VALOR_IDCommand(decimal canje_valor_id)
		{
			string whereSql = "";
			whereSql += "CANJE_VALOR_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CANJE_VALOR_ID", canje_valor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects 
		/// by the <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public CANJES_VALORES_VALORESRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects 
		/// by the <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public virtual CANJES_VALORES_VALORESRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
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
		/// return records by the <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
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
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects 
		/// by the <c>FK_CANJES_VALORES_VAL_CTA_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public virtual CANJES_VALORES_VALORESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CANJES_VALORES_VAL_CTA_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CANJES_VALORES_VAL_CTA_VAL</c> foreign key.
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
		/// Gets an array of <see cref="CANJES_VALORES_VALORESRow"/> objects 
		/// by the <c>FK_CANJES_VALORES_VAL_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		public virtual CANJES_VALORES_VALORESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CANJES_VALORES_VAL_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CANJES_VALORES_VAL_MONEDA</c> foreign key.
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
		/// Adds a new record into the <c>CANJES_VALORES_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CANJES_VALORES_VALORESRow"/> object to be inserted.</param>
		public virtual void Insert(CANJES_VALORES_VALORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CANJES_VALORES_VALORES (" +
				"ID, " +
				"CANJE_VALOR_ID, " +
				"CTACTE_VALOR_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO, " +
				"CTACTE_BANCO_ID, " +
				"NUMERO_CUENTA, " +
				"NUMERO_CHEQUE, " +
				"NOMBRE_EMISOR, " +
				"NUMERO_DOCUMENTO_EMISOR, " +
				"NOMBRE_BENEFICIARIO, " +
				"FECHA_CREACION, " +
				"FECHA_POSDATADO, " +
				"FECHA_VENCIMIENTO, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"OBSERVACION, " +
				"CHEQUE_DE_TERCEROS, " +
				"ES_DIFERIDO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CANJE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCO_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_CUENTA") + ", " +
				_db.CreateSqlParameterName("NUMERO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("NUMERO_DOCUMENTO_EMISOR") + ", " +
				_db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("FECHA_POSDATADO") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				_db.CreateSqlParameterName("ES_DIFERIDO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CANJE_VALOR_ID", value.CANJE_VALOR_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "CTACTE_BANCO_ID",
				value.IsCTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CTACTE_BANCO_ID);
			AddParameter(cmd, "NUMERO_CUENTA", value.NUMERO_CUENTA);
			AddParameter(cmd, "NUMERO_CHEQUE", value.NUMERO_CHEQUE);
			AddParameter(cmd, "NOMBRE_EMISOR", value.NOMBRE_EMISOR);
			AddParameter(cmd, "NUMERO_DOCUMENTO_EMISOR", value.NUMERO_DOCUMENTO_EMISOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_CREACION",
				value.IsFECHA_CREACIONNull ? DBNull.Value : (object)value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_POSDATADO",
				value.IsFECHA_POSDATADONull ? DBNull.Value : (object)value.FECHA_POSDATADO);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "ES_DIFERIDO", value.ES_DIFERIDO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CANJES_VALORES_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CANJES_VALORES_VALORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CANJES_VALORES_VALORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CANJES_VALORES_VALORES SET " +
				"CANJE_VALOR_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ID") + ", " +
				"NUMERO_CUENTA=" + _db.CreateSqlParameterName("NUMERO_CUENTA") + ", " +
				"NUMERO_CHEQUE=" + _db.CreateSqlParameterName("NUMERO_CHEQUE") + ", " +
				"NOMBRE_EMISOR=" + _db.CreateSqlParameterName("NOMBRE_EMISOR") + ", " +
				"NUMERO_DOCUMENTO_EMISOR=" + _db.CreateSqlParameterName("NUMERO_DOCUMENTO_EMISOR") + ", " +
				"NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"FECHA_POSDATADO=" + _db.CreateSqlParameterName("FECHA_POSDATADO") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CHEQUE_DE_TERCEROS=" + _db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				"ES_DIFERIDO=" + _db.CreateSqlParameterName("ES_DIFERIDO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CANJE_VALOR_ID", value.CANJE_VALOR_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "CTACTE_BANCO_ID",
				value.IsCTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CTACTE_BANCO_ID);
			AddParameter(cmd, "NUMERO_CUENTA", value.NUMERO_CUENTA);
			AddParameter(cmd, "NUMERO_CHEQUE", value.NUMERO_CHEQUE);
			AddParameter(cmd, "NOMBRE_EMISOR", value.NOMBRE_EMISOR);
			AddParameter(cmd, "NUMERO_DOCUMENTO_EMISOR", value.NUMERO_DOCUMENTO_EMISOR);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_CREACION",
				value.IsFECHA_CREACIONNull ? DBNull.Value : (object)value.FECHA_CREACION);
			AddParameter(cmd, "FECHA_POSDATADO",
				value.IsFECHA_POSDATADONull ? DBNull.Value : (object)value.FECHA_POSDATADO);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "ES_DIFERIDO", value.ES_DIFERIDO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CANJES_VALORES_VALORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CANJES_VALORES_VALORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CANJES_VALORES_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CANJES_VALORES_VALORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CANJES_VALORES_VALORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CANJES_VALORES_VALORES</c> table using
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
		/// Deletes records from the <c>CANJES_VALORES_VALORES</c> table using the 
		/// <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_ID(decimal ctacte_banco_id)
		{
			return DeleteByCTACTE_BANCO_ID(ctacte_banco_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CANJES_VALORES_VALORES</c> table using the 
		/// <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="ctacte_banco_idNull">true if the method ignores the ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_ID(decimal ctacte_banco_id, bool ctacte_banco_idNull)
		{
			return CreateDeleteByCTACTE_BANCO_IDCommand(ctacte_banco_id, ctacte_banco_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CANJES_VALORES_VAL_BANCO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_id">The <c>CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="ctacte_banco_idNull">true if the method ignores the ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCO_IDCommand(decimal ctacte_banco_id, bool ctacte_banco_idNull)
		{
			string whereSql = "";
			if(ctacte_banco_idNull)
				whereSql += "CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_banco_idNull)
				AddParameter(cmd, "CTACTE_BANCO_ID", ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CANJES_VALORES_VALORES</c> table using the 
		/// <c>FK_CANJES_VALORES_VAL_CANJE</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_id">The <c>CANJE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANJE_VALOR_ID(decimal canje_valor_id)
		{
			return CreateDeleteByCANJE_VALOR_IDCommand(canje_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CANJES_VALORES_VAL_CANJE</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_id">The <c>CANJE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCANJE_VALOR_IDCommand(decimal canje_valor_id)
		{
			string whereSql = "";
			whereSql += "CANJE_VALOR_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CANJE_VALOR_ID", canje_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CANJES_VALORES_VALORES</c> table using the 
		/// <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CANJES_VALORES_VALORES</c> table using the 
		/// <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
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
		/// delete records using the <c>FK_CANJES_VALORES_VAL_CHQ_REC</c> foreign key.
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
		/// Deletes records from the <c>CANJES_VALORES_VALORES</c> table using the 
		/// <c>FK_CANJES_VALORES_VAL_CTA_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CANJES_VALORES_VAL_CTA_VAL</c> foreign key.
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
		/// Deletes records from the <c>CANJES_VALORES_VALORES</c> table using the 
		/// <c>FK_CANJES_VALORES_VAL_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CANJES_VALORES_VAL_MONEDA</c> foreign key.
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
		/// Deletes <c>CANJES_VALORES_VALORES</c> records that match the specified criteria.
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
		/// to delete <c>CANJES_VALORES_VALORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CANJES_VALORES_VALORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CANJES_VALORES_VALORES</c> table.
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
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		protected CANJES_VALORES_VALORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		protected CANJES_VALORES_VALORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CANJES_VALORES_VALORESRow"/> objects.</returns>
		protected virtual CANJES_VALORES_VALORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int canje_valor_idColumnIndex = reader.GetOrdinal("CANJE_VALOR_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int numero_cuentaColumnIndex = reader.GetOrdinal("NUMERO_CUENTA");
			int numero_chequeColumnIndex = reader.GetOrdinal("NUMERO_CHEQUE");
			int nombre_emisorColumnIndex = reader.GetOrdinal("NOMBRE_EMISOR");
			int numero_documento_emisorColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO_EMISOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_posdatadoColumnIndex = reader.GetOrdinal("FECHA_POSDATADO");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cheque_de_tercerosColumnIndex = reader.GetOrdinal("CHEQUE_DE_TERCEROS");
			int es_diferidoColumnIndex = reader.GetOrdinal("ES_DIFERIDO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CANJES_VALORES_VALORESRow record = new CANJES_VALORES_VALORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CANJE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canje_valor_idColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_banco_idColumnIndex))
						record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_cuentaColumnIndex))
						record.NUMERO_CUENTA = Convert.ToString(reader.GetValue(numero_cuentaColumnIndex));
					if(!reader.IsDBNull(numero_chequeColumnIndex))
						record.NUMERO_CHEQUE = Convert.ToString(reader.GetValue(numero_chequeColumnIndex));
					if(!reader.IsDBNull(nombre_emisorColumnIndex))
						record.NOMBRE_EMISOR = Convert.ToString(reader.GetValue(nombre_emisorColumnIndex));
					if(!reader.IsDBNull(numero_documento_emisorColumnIndex))
						record.NUMERO_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(numero_documento_emisorColumnIndex));
					if(!reader.IsDBNull(nombre_beneficiarioColumnIndex))
						record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(fecha_creacionColumnIndex))
						record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(fecha_posdatadoColumnIndex))
						record.FECHA_POSDATADO = Convert.ToDateTime(reader.GetValue(fecha_posdatadoColumnIndex));
					if(!reader.IsDBNull(fecha_vencimientoColumnIndex))
						record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(cheque_de_tercerosColumnIndex))
						record.CHEQUE_DE_TERCEROS = Convert.ToString(reader.GetValue(cheque_de_tercerosColumnIndex));
					if(!reader.IsDBNull(es_diferidoColumnIndex))
						record.ES_DIFERIDO = Convert.ToString(reader.GetValue(es_diferidoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CANJES_VALORES_VALORESRow[])(recordList.ToArray(typeof(CANJES_VALORES_VALORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CANJES_VALORES_VALORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CANJES_VALORES_VALORESRow"/> object.</returns>
		protected virtual CANJES_VALORES_VALORESRow MapRow(DataRow row)
		{
			CANJES_VALORES_VALORESRow mappedObject = new CANJES_VALORES_VALORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CANJE_VALOR_ID"
			dataColumn = dataTable.Columns["CANJE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANJE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CUENTA"
			dataColumn = dataTable.Columns["NUMERO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA = (string)row[dataColumn];
			// Column "NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "NUMERO_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["NUMERO_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_POSDATADO"
			dataColumn = dataTable.Columns["FECHA_POSDATADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSDATADO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CHEQUE_DE_TERCEROS"
			dataColumn = dataTable.Columns["CHEQUE_DE_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DE_TERCEROS = (string)row[dataColumn];
			// Column "ES_DIFERIDO"
			dataColumn = dataTable.Columns["ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_DIFERIDO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CANJES_VALORES_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CANJES_VALORES_VALORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANJE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_POSDATADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("CHEQUE_DE_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ES_DIFERIDO", typeof(string));
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

				case "CANJE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_POSDATADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DE_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CANJES_VALORES_VALORESCollection_Base class
}  // End of namespace
