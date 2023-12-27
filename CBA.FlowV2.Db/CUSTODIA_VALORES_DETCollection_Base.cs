// <fileinfo name="CUSTODIA_VALORES_DETCollection_Base.cs">
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
	/// The base class for <see cref="CUSTODIA_VALORES_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CUSTODIA_VALORES_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CUSTODIA_VALORES_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CUSTODIA_VALOR_IDColumnName = "CUSTODIA_VALOR_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string COSTOColumnName = "COSTO";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string CTACTE_PAGARE_DET_IDColumnName = "CTACTE_PAGARE_DET_ID";
		public const string VALOR_RETIRADOColumnName = "VALOR_RETIRADO";
		public const string FECHA_RETIROColumnName = "FECHA_RETIRO";
		public const string USUARIO_RETIRO_IDColumnName = "USUARIO_RETIRO_ID";
		public const string OBSERVACION_INICIALColumnName = "OBSERVACION_INICIAL";
		public const string OBSERVACION_RETIROColumnName = "OBSERVACION_RETIRO";
		public const string DEPOSITO_AUTOMATICOColumnName = "DEPOSITO_AUTOMATICO";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CUSTODIA_VALORES_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CUSTODIA_VALORES_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CUSTODIA_VALORES_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CUSTODIA_VALORES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CUSTODIA_VALORES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CUSTODIA_VALORES_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CUSTODIA_VALORES_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CUSTODIA_VALORES_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CUSTODIA_VALORES_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public CUSTODIA_VALORES_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CUSTODIA_VALORES_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CUSTODIA_VALORES_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CUSTODIA_VALORES_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CUSTODIA_VALORES_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CUSTODIA_VALORES_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public CUSTODIA_VALORES_DETRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
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
		/// return records by the <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
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
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_CUSTOD</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_id">The <c>CUSTODIA_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetByCUSTODIA_VALOR_ID(decimal custodia_valor_id)
		{
			return MapRecords(CreateGetByCUSTODIA_VALOR_IDCommand(custodia_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_CUSTOD</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_id">The <c>CUSTODIA_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCUSTODIA_VALOR_IDAsDataTable(decimal custodia_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCUSTODIA_VALOR_IDCommand(custodia_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CUSTODIA_VALORES_DET_CUSTOD</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_id">The <c>CUSTODIA_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCUSTODIA_VALOR_IDCommand(decimal custodia_valor_id)
		{
			string whereSql = "";
			whereSql += "CUSTODIA_VALOR_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CUSTODIA_VALOR_ID", custodia_valor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CUSTODIA_VALORES_DET_MON</c> foreign key.
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
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public CUSTODIA_VALORES_DETRow[] GetByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id)
		{
			return GetByCTACTE_PAGARE_DET_ID(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGARE_DET_IDAsDataTable(decimal ctacte_pagare_det_id)
		{
			return GetByCTACTE_PAGARE_DET_IDAsDataTable(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGARE_DET_IDAsDataTable(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGARE_DET_IDCommand(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_det_idNull)
				whereSql += "CTACTE_PAGARE_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pagare_det_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DET_ID", ctacte_pagare_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public CUSTODIA_VALORES_DETRow[] GetByUSUARIO_RETIRO_ID(decimal usuario_retiro_id)
		{
			return GetByUSUARIO_RETIRO_ID(usuario_retiro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <param name="usuario_retiro_idNull">true if the method ignores the usuario_retiro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetByUSUARIO_RETIRO_ID(decimal usuario_retiro_id, bool usuario_retiro_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_RETIRO_IDCommand(usuario_retiro_id, usuario_retiro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_RETIRO_IDAsDataTable(decimal usuario_retiro_id)
		{
			return GetByUSUARIO_RETIRO_IDAsDataTable(usuario_retiro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <param name="usuario_retiro_idNull">true if the method ignores the usuario_retiro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_RETIRO_IDAsDataTable(decimal usuario_retiro_id, bool usuario_retiro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_RETIRO_IDCommand(usuario_retiro_id, usuario_retiro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <param name="usuario_retiro_idNull">true if the method ignores the usuario_retiro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_RETIRO_IDCommand(decimal usuario_retiro_id, bool usuario_retiro_idNull)
		{
			string whereSql = "";
			if(usuario_retiro_idNull)
				whereSql += "USUARIO_RETIRO_ID IS NULL";
			else
				whereSql += "USUARIO_RETIRO_ID=" + _db.CreateSqlParameterName("USUARIO_RETIRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_retiro_idNull)
				AddParameter(cmd, "USUARIO_RETIRO_ID", usuario_retiro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CUSTODIA_VALORES_DETRow"/> objects 
		/// by the <c>FK_CUSTODIA_VALORES_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		public virtual CUSTODIA_VALORES_DETRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CUSTODIA_VALORES_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CUSTODIA_VALORES_DET_VALOR</c> foreign key.
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
		/// Adds a new record into the <c>CUSTODIA_VALORES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CUSTODIA_VALORES_DETRow"/> object to be inserted.</param>
		public virtual void Insert(CUSTODIA_VALORES_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CUSTODIA_VALORES_DET (" +
				"ID, " +
				"CUSTODIA_VALOR_ID, " +
				"CTACTE_VALOR_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO, " +
				"COSTO, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"CTACTE_PAGARE_DET_ID, " +
				"VALOR_RETIRADO, " +
				"FECHA_RETIRO, " +
				"USUARIO_RETIRO_ID, " +
				"OBSERVACION_INICIAL, " +
				"OBSERVACION_RETIRO, " +
				"DEPOSITO_AUTOMATICO, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CUSTODIA_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("COSTO") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID") + ", " +
				_db.CreateSqlParameterName("VALOR_RETIRADO") + ", " +
				_db.CreateSqlParameterName("FECHA_RETIRO") + ", " +
				_db.CreateSqlParameterName("USUARIO_RETIRO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_INICIAL") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_RETIRO") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_AUTOMATICO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CUSTODIA_VALOR_ID", value.CUSTODIA_VALOR_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "COSTO",
				value.IsCOSTONull ? DBNull.Value : (object)value.COSTO);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DET_ID",
				value.IsCTACTE_PAGARE_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DET_ID);
			AddParameter(cmd, "VALOR_RETIRADO", value.VALOR_RETIRADO);
			AddParameter(cmd, "FECHA_RETIRO",
				value.IsFECHA_RETIRONull ? DBNull.Value : (object)value.FECHA_RETIRO);
			AddParameter(cmd, "USUARIO_RETIRO_ID",
				value.IsUSUARIO_RETIRO_IDNull ? DBNull.Value : (object)value.USUARIO_RETIRO_ID);
			AddParameter(cmd, "OBSERVACION_INICIAL", value.OBSERVACION_INICIAL);
			AddParameter(cmd, "OBSERVACION_RETIRO", value.OBSERVACION_RETIRO);
			AddParameter(cmd, "DEPOSITO_AUTOMATICO", value.DEPOSITO_AUTOMATICO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CUSTODIA_VALORES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CUSTODIA_VALORES_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CUSTODIA_VALORES_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.CUSTODIA_VALORES_DET SET " +
				"CUSTODIA_VALOR_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"COSTO=" + _db.CreateSqlParameterName("COSTO") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID") + ", " +
				"VALOR_RETIRADO=" + _db.CreateSqlParameterName("VALOR_RETIRADO") + ", " +
				"FECHA_RETIRO=" + _db.CreateSqlParameterName("FECHA_RETIRO") + ", " +
				"USUARIO_RETIRO_ID=" + _db.CreateSqlParameterName("USUARIO_RETIRO_ID") + ", " +
				"OBSERVACION_INICIAL=" + _db.CreateSqlParameterName("OBSERVACION_INICIAL") + ", " +
				"OBSERVACION_RETIRO=" + _db.CreateSqlParameterName("OBSERVACION_RETIRO") + ", " +
				"DEPOSITO_AUTOMATICO=" + _db.CreateSqlParameterName("DEPOSITO_AUTOMATICO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CUSTODIA_VALOR_ID", value.CUSTODIA_VALOR_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "COSTO",
				value.IsCOSTONull ? DBNull.Value : (object)value.COSTO);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DET_ID",
				value.IsCTACTE_PAGARE_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DET_ID);
			AddParameter(cmd, "VALOR_RETIRADO", value.VALOR_RETIRADO);
			AddParameter(cmd, "FECHA_RETIRO",
				value.IsFECHA_RETIRONull ? DBNull.Value : (object)value.FECHA_RETIRO);
			AddParameter(cmd, "USUARIO_RETIRO_ID",
				value.IsUSUARIO_RETIRO_IDNull ? DBNull.Value : (object)value.USUARIO_RETIRO_ID);
			AddParameter(cmd, "OBSERVACION_INICIAL", value.OBSERVACION_INICIAL);
			AddParameter(cmd, "OBSERVACION_RETIRO", value.OBSERVACION_RETIRO);
			AddParameter(cmd, "DEPOSITO_AUTOMATICO", value.DEPOSITO_AUTOMATICO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CUSTODIA_VALORES_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CUSTODIA_VALORES_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CUSTODIA_VALORES_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CUSTODIA_VALORES_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CUSTODIA_VALORES_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CUSTODIA_VALORES_DET</c> table using
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
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
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
		/// delete records using the <c>FK_CUSTODIA_VALORES_DET_CHEQ</c> foreign key.
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
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_CUSTOD</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_id">The <c>CUSTODIA_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALOR_ID(decimal custodia_valor_id)
		{
			return CreateDeleteByCUSTODIA_VALOR_IDCommand(custodia_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CUSTODIA_VALORES_DET_CUSTOD</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_id">The <c>CUSTODIA_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCUSTODIA_VALOR_IDCommand(decimal custodia_valor_id)
		{
			string whereSql = "";
			whereSql += "CUSTODIA_VALOR_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CUSTODIA_VALOR_ID", custodia_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CUSTODIA_VALORES_DET_MON</c> foreign key.
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
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id)
		{
			return DeleteByCTACTE_PAGARE_DET_ID(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return CreateDeleteByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CUSTODIA_VALORES_DET_PAGAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGARE_DET_IDCommand(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_det_idNull)
				whereSql += "CTACTE_PAGARE_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pagare_det_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DET_ID", ctacte_pagare_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_RETIRO_ID(decimal usuario_retiro_id)
		{
			return DeleteByUSUARIO_RETIRO_ID(usuario_retiro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <param name="usuario_retiro_idNull">true if the method ignores the usuario_retiro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_RETIRO_ID(decimal usuario_retiro_id, bool usuario_retiro_idNull)
		{
			return CreateDeleteByUSUARIO_RETIRO_IDCommand(usuario_retiro_id, usuario_retiro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CUSTODIA_VALORES_DET_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_retiro_id">The <c>USUARIO_RETIRO_ID</c> column value.</param>
		/// <param name="usuario_retiro_idNull">true if the method ignores the usuario_retiro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_RETIRO_IDCommand(decimal usuario_retiro_id, bool usuario_retiro_idNull)
		{
			string whereSql = "";
			if(usuario_retiro_idNull)
				whereSql += "USUARIO_RETIRO_ID IS NULL";
			else
				whereSql += "USUARIO_RETIRO_ID=" + _db.CreateSqlParameterName("USUARIO_RETIRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_retiro_idNull)
				AddParameter(cmd, "USUARIO_RETIRO_ID", usuario_retiro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CUSTODIA_VALORES_DET</c> table using the 
		/// <c>FK_CUSTODIA_VALORES_DET_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CUSTODIA_VALORES_DET_VALOR</c> foreign key.
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
		/// Deletes <c>CUSTODIA_VALORES_DET</c> records that match the specified criteria.
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
		/// to delete <c>CUSTODIA_VALORES_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CUSTODIA_VALORES_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CUSTODIA_VALORES_DET</c> table.
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
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		protected CUSTODIA_VALORES_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		protected CUSTODIA_VALORES_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CUSTODIA_VALORES_DETRow"/> objects.</returns>
		protected virtual CUSTODIA_VALORES_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int custodia_valor_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALOR_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int ctacte_pagare_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_DET_ID");
			int valor_retiradoColumnIndex = reader.GetOrdinal("VALOR_RETIRADO");
			int fecha_retiroColumnIndex = reader.GetOrdinal("FECHA_RETIRO");
			int usuario_retiro_idColumnIndex = reader.GetOrdinal("USUARIO_RETIRO_ID");
			int observacion_inicialColumnIndex = reader.GetOrdinal("OBSERVACION_INICIAL");
			int observacion_retiroColumnIndex = reader.GetOrdinal("OBSERVACION_RETIRO");
			int deposito_automaticoColumnIndex = reader.GetOrdinal("DEPOSITO_AUTOMATICO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CUSTODIA_VALORES_DETRow record = new CUSTODIA_VALORES_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CUSTODIA_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valor_idColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(costoColumnIndex))
						record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pagare_det_idColumnIndex))
						record.CTACTE_PAGARE_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_det_idColumnIndex)), 9);
					record.VALOR_RETIRADO = Convert.ToString(reader.GetValue(valor_retiradoColumnIndex));
					if(!reader.IsDBNull(fecha_retiroColumnIndex))
						record.FECHA_RETIRO = Convert.ToDateTime(reader.GetValue(fecha_retiroColumnIndex));
					if(!reader.IsDBNull(usuario_retiro_idColumnIndex))
						record.USUARIO_RETIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_retiro_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_inicialColumnIndex))
						record.OBSERVACION_INICIAL = Convert.ToString(reader.GetValue(observacion_inicialColumnIndex));
					if(!reader.IsDBNull(observacion_retiroColumnIndex))
						record.OBSERVACION_RETIRO = Convert.ToString(reader.GetValue(observacion_retiroColumnIndex));
					record.DEPOSITO_AUTOMATICO = Convert.ToString(reader.GetValue(deposito_automaticoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CUSTODIA_VALORES_DETRow[])(recordList.ToArray(typeof(CUSTODIA_VALORES_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CUSTODIA_VALORES_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CUSTODIA_VALORES_DETRow"/> object.</returns>
		protected virtual CUSTODIA_VALORES_DETRow MapRow(DataRow row)
		{
			CUSTODIA_VALORES_DETRow mappedObject = new CUSTODIA_VALORES_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALOR_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALOR_ID = (decimal)row[dataColumn];
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
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGARE_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_DET_ID = (decimal)row[dataColumn];
			// Column "VALOR_RETIRADO"
			dataColumn = dataTable.Columns["VALOR_RETIRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_RETIRADO = (string)row[dataColumn];
			// Column "FECHA_RETIRO"
			dataColumn = dataTable.Columns["FECHA_RETIRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RETIRO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_RETIRO_ID"
			dataColumn = dataTable.Columns["USUARIO_RETIRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_RETIRO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION_INICIAL"
			dataColumn = dataTable.Columns["OBSERVACION_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_INICIAL = (string)row[dataColumn];
			// Column "OBSERVACION_RETIRO"
			dataColumn = dataTable.Columns["OBSERVACION_RETIRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_RETIRO = (string)row[dataColumn];
			// Column "DEPOSITO_AUTOMATICO"
			dataColumn = dataTable.Columns["DEPOSITO_AUTOMATICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_AUTOMATICO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CUSTODIA_VALORES_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CUSTODIA_VALORES_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_RETIRADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_RETIRO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_RETIRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION_INICIAL", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("OBSERVACION_RETIRO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("DEPOSITO_AUTOMATICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "CUSTODIA_VALOR_ID":
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

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGARE_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_RETIRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_RETIRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_RETIRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION_RETIRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CUSTODIA_VALORES_DETCollection_Base class
}  // End of namespace
