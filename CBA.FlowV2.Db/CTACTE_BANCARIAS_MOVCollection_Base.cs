// <fileinfo name="CTACTE_BANCARIAS_MOVCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCARIAS_MOVCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_BANCARIAS_MOVCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCARIAS_MOVCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string INGRESOColumnName = "INGRESO";
		public const string EGRESOColumnName = "EGRESO";
		public const string SALDOColumnName = "SALDO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string DEPOSITO_BANCARIO_IDColumnName = "DEPOSITO_BANCARIO_ID";
		public const string TRANSFERENCIA_BANCARIA_IDColumnName = "TRANSFERENCIA_BANCARIA_ID";
		public const string AJUSTE_BANCARIO_IDColumnName = "AJUSTE_BANCARIO_ID";
		public const string DESCUENTO_DOCUMENTO_IDColumnName = "DESCUENTO_DOCUMENTO_ID";
		public const string CUSTODIA_VALORES_IDColumnName = "CUSTODIA_VALORES_ID";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string MOVIMIENTO_VARIO_TESORERIA_IDColumnName = "MOVIMIENTO_VARIO_TESORERIA_ID";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string CONCILIADOColumnName = "CONCILIADO";
		public const string CONCILIADO_USUARIO_IDColumnName = "CONCILIADO_USUARIO_ID";
		public const string CONCILIADO_FECHAColumnName = "CONCILIADO_FECHA";
		public const string DESCONCILIADO_USUARIO_IDColumnName = "DESCONCILIADO_USUARIO_ID";
		public const string DESCONCILIADO_FECHAColumnName = "DESCONCILIADO_FECHA";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CTACTE_CHEQUE_GIRADO_IDColumnName = "CTACTE_CHEQUE_GIRADO_ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCARIAS_MOVCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_BANCARIAS_MOVCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_BANCARIAS_MOV</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_BANCARIAS_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_BANCARIAS_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_BANCARIAS_MOVRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_BANCARIAS_MOVRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_BANCARIAS_MOVRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_BANCARIAS_MOVRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_BANCARIAS_MOV";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_BANCARIAS_MOVRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_BANCARIAS_MOVRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_BANCARIAS_MOVRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByCTACTE_CHEQUE_GIRADO_ID(decimal ctacte_cheque_girado_id)
		{
			return GetByCTACTE_CHEQUE_GIRADO_ID(ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_girado_idNull">true if the method ignores the ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByCTACTE_CHEQUE_GIRADO_ID(decimal ctacte_cheque_girado_id, bool ctacte_cheque_girado_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_GIRADO_IDCommand(ctacte_cheque_girado_id, ctacte_cheque_girado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_GIRADO_IDAsDataTable(decimal ctacte_cheque_girado_id)
		{
			return GetByCTACTE_CHEQUE_GIRADO_IDAsDataTable(ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_girado_idNull">true if the method ignores the ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CHEQUE_GIRADO_IDAsDataTable(decimal ctacte_cheque_girado_id, bool ctacte_cheque_girado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CHEQUE_GIRADO_IDCommand(ctacte_cheque_girado_id, ctacte_cheque_girado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_girado_idNull">true if the method ignores the ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CHEQUE_GIRADO_IDCommand(decimal ctacte_cheque_girado_id, bool ctacte_cheque_girado_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_girado_idNull)
				whereSql += "CTACTE_CHEQUE_GIRADO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_GIRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_cheque_girado_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_GIRADO_ID", ctacte_cheque_girado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByDESCONCILIADO_USUARIO_ID(decimal desconciliado_usuario_id)
		{
			return GetByDESCONCILIADO_USUARIO_ID(desconciliado_usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="desconciliado_usuario_idNull">true if the method ignores the desconciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByDESCONCILIADO_USUARIO_ID(decimal desconciliado_usuario_id, bool desconciliado_usuario_idNull)
		{
			return MapRecords(CreateGetByDESCONCILIADO_USUARIO_IDCommand(desconciliado_usuario_id, desconciliado_usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCONCILIADO_USUARIO_IDAsDataTable(decimal desconciliado_usuario_id)
		{
			return GetByDESCONCILIADO_USUARIO_IDAsDataTable(desconciliado_usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="desconciliado_usuario_idNull">true if the method ignores the desconciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCONCILIADO_USUARIO_IDAsDataTable(decimal desconciliado_usuario_id, bool desconciliado_usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCONCILIADO_USUARIO_IDCommand(desconciliado_usuario_id, desconciliado_usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="desconciliado_usuario_idNull">true if the method ignores the desconciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCONCILIADO_USUARIO_IDCommand(decimal desconciliado_usuario_id, bool desconciliado_usuario_idNull)
		{
			string whereSql = "";
			if(desconciliado_usuario_idNull)
				whereSql += "DESCONCILIADO_USUARIO_ID IS NULL";
			else
				whereSql += "DESCONCILIADO_USUARIO_ID=" + _db.CreateSqlParameterName("DESCONCILIADO_USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!desconciliado_usuario_idNull)
				AddParameter(cmd, "DESCONCILIADO_USUARIO_ID", desconciliado_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id)
		{
			return GetByAJUSTE_BANCARIO_ID(ajuste_bancario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			return MapRecords(CreateGetByAJUSTE_BANCARIO_IDCommand(ajuste_bancario_id, ajuste_bancario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAJUSTE_BANCARIO_IDAsDataTable(decimal ajuste_bancario_id)
		{
			return GetByAJUSTE_BANCARIO_IDAsDataTable(ajuste_bancario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAJUSTE_BANCARIO_IDAsDataTable(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAJUSTE_BANCARIO_IDCommand(ajuste_bancario_id, ajuste_bancario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAJUSTE_BANCARIO_IDCommand(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			string whereSql = "";
			if(ajuste_bancario_idNull)
				whereSql += "AJUSTE_BANCARIO_ID IS NULL";
			else
				whereSql += "AJUSTE_BANCARIO_ID=" + _db.CreateSqlParameterName("AJUSTE_BANCARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ajuste_bancario_idNull)
				AddParameter(cmd, "AJUSTE_BANCARIO_ID", ajuste_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_IDAsDataTable(decimal ctacte_bancaria_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByCONCILIADO_USUARIO_ID(decimal conciliado_usuario_id)
		{
			return GetByCONCILIADO_USUARIO_ID(conciliado_usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="conciliado_usuario_idNull">true if the method ignores the conciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByCONCILIADO_USUARIO_ID(decimal conciliado_usuario_id, bool conciliado_usuario_idNull)
		{
			return MapRecords(CreateGetByCONCILIADO_USUARIO_IDCommand(conciliado_usuario_id, conciliado_usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONCILIADO_USUARIO_IDAsDataTable(decimal conciliado_usuario_id)
		{
			return GetByCONCILIADO_USUARIO_IDAsDataTable(conciliado_usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="conciliado_usuario_idNull">true if the method ignores the conciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONCILIADO_USUARIO_IDAsDataTable(decimal conciliado_usuario_id, bool conciliado_usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONCILIADO_USUARIO_IDCommand(conciliado_usuario_id, conciliado_usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="conciliado_usuario_idNull">true if the method ignores the conciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONCILIADO_USUARIO_IDCommand(decimal conciliado_usuario_id, bool conciliado_usuario_idNull)
		{
			string whereSql = "";
			if(conciliado_usuario_idNull)
				whereSql += "CONCILIADO_USUARIO_ID IS NULL";
			else
				whereSql += "CONCILIADO_USUARIO_ID=" + _db.CreateSqlParameterName("CONCILIADO_USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!conciliado_usuario_idNull)
				AddParameter(cmd, "CONCILIADO_USUARIO_ID", conciliado_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByCUSTODIA_VALORES_ID(decimal custodia_valores_id)
		{
			return GetByCUSTODIA_VALORES_ID(custodia_valores_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByCUSTODIA_VALORES_ID(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			return MapRecords(CreateGetByCUSTODIA_VALORES_IDCommand(custodia_valores_id, custodia_valores_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCUSTODIA_VALORES_IDAsDataTable(decimal custodia_valores_id)
		{
			return GetByCUSTODIA_VALORES_IDAsDataTable(custodia_valores_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCUSTODIA_VALORES_IDAsDataTable(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCUSTODIA_VALORES_IDCommand(custodia_valores_id, custodia_valores_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCUSTODIA_VALORES_IDCommand(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			string whereSql = "";
			if(custodia_valores_idNull)
				whereSql += "CUSTODIA_VALORES_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALORES_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALORES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!custodia_valores_idNull)
				AddParameter(cmd, "CUSTODIA_VALORES_ID", custodia_valores_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_BANCARIO_IDAsDataTable(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_IDAsDataTable(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_BANCARIO_IDAsDataTable(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_BANCARIO_IDCommand(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_idNull)
				whereSql += "DEPOSITO_BANCARIO_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_bancario_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_ID", deposito_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByDESCUENTO_DOCUMENTO_ID(decimal descuento_documento_id)
		{
			return GetByDESCUENTO_DOCUMENTO_ID(descuento_documento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <param name="descuento_documento_idNull">true if the method ignores the descuento_documento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByDESCUENTO_DOCUMENTO_ID(decimal descuento_documento_id, bool descuento_documento_idNull)
		{
			return MapRecords(CreateGetByDESCUENTO_DOCUMENTO_IDCommand(descuento_documento_id, descuento_documento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCUENTO_DOCUMENTO_IDAsDataTable(decimal descuento_documento_id)
		{
			return GetByDESCUENTO_DOCUMENTO_IDAsDataTable(descuento_documento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <param name="descuento_documento_idNull">true if the method ignores the descuento_documento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_DOCUMENTO_IDAsDataTable(decimal descuento_documento_id, bool descuento_documento_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_DOCUMENTO_IDCommand(descuento_documento_id, descuento_documento_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <param name="descuento_documento_idNull">true if the method ignores the descuento_documento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_DOCUMENTO_IDCommand(decimal descuento_documento_id, bool descuento_documento_idNull)
		{
			string whereSql = "";
			if(descuento_documento_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!descuento_documento_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_ID", descuento_documento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecords(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_IDAsDataTable(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id)
		{
			return GetByMOVIMIENTO_VARIO_TESORERIA_ID(movimiento_vario_tesoreria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			return MapRecords(CreateGetByMOVIMIENTO_VARIO_TESORERIA_IDCommand(movimiento_vario_tesoreria_id, movimiento_vario_tesoreria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOVIMIENTO_VARIO_TESORERIA_IDAsDataTable(decimal movimiento_vario_tesoreria_id)
		{
			return GetByMOVIMIENTO_VARIO_TESORERIA_IDAsDataTable(movimiento_vario_tesoreria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOVIMIENTO_VARIO_TESORERIA_IDAsDataTable(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMOVIMIENTO_VARIO_TESORERIA_IDCommand(movimiento_vario_tesoreria_id, movimiento_vario_tesoreria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOVIMIENTO_VARIO_TESORERIA_IDCommand(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			string whereSql = "";
			if(movimiento_vario_tesoreria_idNull)
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!movimiento_vario_tesoreria_idNull)
				AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID", movimiento_vario_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecords(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_IDAsDataTable(orden_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public CTACTE_BANCARIAS_MOVRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			string whereSql = "";
			if(transferencia_bancaria_idNull)
				whereSql += "TRANSFERENCIA_BANCARIA_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_bancaria_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID", transferencia_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		public virtual CTACTE_BANCARIAS_MOVRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCARIAS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCARIAS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_BANCARIAS_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_BANCARIAS_MOVRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_BANCARIAS_MOVRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_BANCARIAS_MOV (" +
				"ID, " +
				"CTACTE_BANCARIA_ID, " +
				"FECHA, " +
				"USUARIO_ID, " +
				"INGRESO, " +
				"EGRESO, " +
				"SALDO, " +
				"COTIZACION_MONEDA, " +
				"ORDEN_PAGO_ID, " +
				"DEPOSITO_BANCARIO_ID, " +
				"TRANSFERENCIA_BANCARIA_ID, " +
				"AJUSTE_BANCARIO_ID, " +
				"DESCUENTO_DOCUMENTO_ID, " +
				"CUSTODIA_VALORES_ID, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"OBSERVACION, " +
				"MOVIMIENTO_VARIO_TESORERIA_ID, " +
				"FECHA_INSERCION, " +
				"EGRESO_VARIO_CAJA_ID, " +
				"CONCILIADO, " +
				"CONCILIADO_USUARIO_ID, " +
				"CONCILIADO_FECHA, " +
				"DESCONCILIADO_USUARIO_ID, " +
				"DESCONCILIADO_FECHA, " +
				"CASO_ID, " +
				"CTACTE_CHEQUE_GIRADO_ID, " +
				"CTACTE_CHEQUE_RECIBIDO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("INGRESO") + ", " +
				_db.CreateSqlParameterName("EGRESO") + ", " +
				_db.CreateSqlParameterName("SALDO") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("AJUSTE_BANCARIO_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_ID") + ", " +
				_db.CreateSqlParameterName("CUSTODIA_VALORES_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				_db.CreateSqlParameterName("CONCILIADO") + ", " +
				_db.CreateSqlParameterName("CONCILIADO_USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("CONCILIADO_FECHA") + ", " +
				_db.CreateSqlParameterName("DESCONCILIADO_USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("DESCONCILIADO_FECHA") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_GIRADO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "INGRESO",
				value.IsINGRESONull ? DBNull.Value : (object)value.INGRESO);
			AddParameter(cmd, "EGRESO",
				value.IsEGRESONull ? DBNull.Value : (object)value.EGRESO);
			AddParameter(cmd, "SALDO",
				value.IsSALDONull ? DBNull.Value : (object)value.SALDO);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "AJUSTE_BANCARIO_ID",
				value.IsAJUSTE_BANCARIO_IDNull ? DBNull.Value : (object)value.AJUSTE_BANCARIO_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_ID",
				value.IsDESCUENTO_DOCUMENTO_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_ID);
			AddParameter(cmd, "CUSTODIA_VALORES_ID",
				value.IsCUSTODIA_VALORES_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALORES_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID",
				value.IsMOVIMIENTO_VARIO_TESORERIA_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_VARIO_TESORERIA_ID);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CONCILIADO", value.CONCILIADO);
			AddParameter(cmd, "CONCILIADO_USUARIO_ID",
				value.IsCONCILIADO_USUARIO_IDNull ? DBNull.Value : (object)value.CONCILIADO_USUARIO_ID);
			AddParameter(cmd, "CONCILIADO_FECHA",
				value.IsCONCILIADO_FECHANull ? DBNull.Value : (object)value.CONCILIADO_FECHA);
			AddParameter(cmd, "DESCONCILIADO_USUARIO_ID",
				value.IsDESCONCILIADO_USUARIO_IDNull ? DBNull.Value : (object)value.DESCONCILIADO_USUARIO_ID);
			AddParameter(cmd, "DESCONCILIADO_FECHA",
				value.IsDESCONCILIADO_FECHANull ? DBNull.Value : (object)value.DESCONCILIADO_FECHA);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_GIRADO_ID",
				value.IsCTACTE_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_BANCARIAS_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_BANCARIAS_MOVRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_BANCARIAS_MOVRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_BANCARIAS_MOV SET " +
				"CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"INGRESO=" + _db.CreateSqlParameterName("INGRESO") + ", " +
				"EGRESO=" + _db.CreateSqlParameterName("EGRESO") + ", " +
				"SALDO=" + _db.CreateSqlParameterName("SALDO") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				"DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				"TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				"AJUSTE_BANCARIO_ID=" + _db.CreateSqlParameterName("AJUSTE_BANCARIO_ID") + ", " +
				"DESCUENTO_DOCUMENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_ID") + ", " +
				"CUSTODIA_VALORES_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALORES_ID") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"MOVIMIENTO_VARIO_TESORERIA_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID") + ", " +
				"FECHA_INSERCION=" + _db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				"EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				"CONCILIADO=" + _db.CreateSqlParameterName("CONCILIADO") + ", " +
				"CONCILIADO_USUARIO_ID=" + _db.CreateSqlParameterName("CONCILIADO_USUARIO_ID") + ", " +
				"CONCILIADO_FECHA=" + _db.CreateSqlParameterName("CONCILIADO_FECHA") + ", " +
				"DESCONCILIADO_USUARIO_ID=" + _db.CreateSqlParameterName("DESCONCILIADO_USUARIO_ID") + ", " +
				"DESCONCILIADO_FECHA=" + _db.CreateSqlParameterName("DESCONCILIADO_FECHA") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_GIRADO_ID") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "INGRESO",
				value.IsINGRESONull ? DBNull.Value : (object)value.INGRESO);
			AddParameter(cmd, "EGRESO",
				value.IsEGRESONull ? DBNull.Value : (object)value.EGRESO);
			AddParameter(cmd, "SALDO",
				value.IsSALDONull ? DBNull.Value : (object)value.SALDO);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "AJUSTE_BANCARIO_ID",
				value.IsAJUSTE_BANCARIO_IDNull ? DBNull.Value : (object)value.AJUSTE_BANCARIO_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_ID",
				value.IsDESCUENTO_DOCUMENTO_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_ID);
			AddParameter(cmd, "CUSTODIA_VALORES_ID",
				value.IsCUSTODIA_VALORES_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALORES_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID",
				value.IsMOVIMIENTO_VARIO_TESORERIA_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_VARIO_TESORERIA_ID);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CONCILIADO", value.CONCILIADO);
			AddParameter(cmd, "CONCILIADO_USUARIO_ID",
				value.IsCONCILIADO_USUARIO_IDNull ? DBNull.Value : (object)value.CONCILIADO_USUARIO_ID);
			AddParameter(cmd, "CONCILIADO_FECHA",
				value.IsCONCILIADO_FECHANull ? DBNull.Value : (object)value.CONCILIADO_FECHA);
			AddParameter(cmd, "DESCONCILIADO_USUARIO_ID",
				value.IsDESCONCILIADO_USUARIO_IDNull ? DBNull.Value : (object)value.DESCONCILIADO_USUARIO_ID);
			AddParameter(cmd, "DESCONCILIADO_FECHA",
				value.IsDESCONCILIADO_FECHANull ? DBNull.Value : (object)value.DESCONCILIADO_FECHA);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_GIRADO_ID",
				value.IsCTACTE_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_BANCARIAS_MOV</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_BANCARIAS_MOV</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_BANCARIAS_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_BANCARIAS_MOVRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_BANCARIAS_MOVRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_BANCARIAS_MOV</c> table using
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
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_BANC_MOV_CASO</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_GIRADO_ID(decimal ctacte_cheque_girado_id)
		{
			return DeleteByCTACTE_CHEQUE_GIRADO_ID(ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_girado_idNull">true if the method ignores the ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_GIRADO_ID(decimal ctacte_cheque_girado_id, bool ctacte_cheque_girado_idNull)
		{
			return CreateDeleteByCTACTE_CHEQUE_GIRADO_IDCommand(ctacte_cheque_girado_id, ctacte_cheque_girado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANC_MOV_CHE_G_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_girado_idNull">true if the method ignores the ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CHEQUE_GIRADO_IDCommand(decimal ctacte_cheque_girado_id, bool ctacte_cheque_girado_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_girado_idNull)
				whereSql += "CTACTE_CHEQUE_GIRADO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_GIRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_cheque_girado_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_GIRADO_ID", ctacte_cheque_girado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_BANC_MOV_CHE_R_ID</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCONCILIADO_USUARIO_ID(decimal desconciliado_usuario_id)
		{
			return DeleteByDESCONCILIADO_USUARIO_ID(desconciliado_usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="desconciliado_usuario_idNull">true if the method ignores the desconciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCONCILIADO_USUARIO_ID(decimal desconciliado_usuario_id, bool desconciliado_usuario_idNull)
		{
			return CreateDeleteByDESCONCILIADO_USUARIO_IDCommand(desconciliado_usuario_id, desconciliado_usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANC_MOV_DESCONCI</c> foreign key.
		/// </summary>
		/// <param name="desconciliado_usuario_id">The <c>DESCONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="desconciliado_usuario_idNull">true if the method ignores the desconciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCONCILIADO_USUARIO_IDCommand(decimal desconciliado_usuario_id, bool desconciliado_usuario_idNull)
		{
			string whereSql = "";
			if(desconciliado_usuario_idNull)
				whereSql += "DESCONCILIADO_USUARIO_ID IS NULL";
			else
				whereSql += "DESCONCILIADO_USUARIO_ID=" + _db.CreateSqlParameterName("DESCONCILIADO_USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!desconciliado_usuario_idNull)
				AddParameter(cmd, "DESCONCILIADO_USUARIO_ID", desconciliado_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id)
		{
			return DeleteByAJUSTE_BANCARIO_ID(ajuste_bancario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			return CreateDeleteByAJUSTE_BANCARIO_IDCommand(ajuste_bancario_id, ajuste_bancario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_AJUS</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAJUSTE_BANCARIO_IDCommand(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			string whereSql = "";
			if(ajuste_bancario_idNull)
				whereSql += "AJUSTE_BANCARIO_ID IS NULL";
			else
				whereSql += "AJUSTE_BANCARIO_ID=" + _db.CreateSqlParameterName("AJUSTE_BANCARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ajuste_bancario_idNull)
				AddParameter(cmd, "AJUSTE_BANCARIO_ID", ajuste_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return CreateDeleteByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_BANC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONCILIADO_USUARIO_ID(decimal conciliado_usuario_id)
		{
			return DeleteByCONCILIADO_USUARIO_ID(conciliado_usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="conciliado_usuario_idNull">true if the method ignores the conciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONCILIADO_USUARIO_ID(decimal conciliado_usuario_id, bool conciliado_usuario_idNull)
		{
			return CreateDeleteByCONCILIADO_USUARIO_IDCommand(conciliado_usuario_id, conciliado_usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_CONCI</c> foreign key.
		/// </summary>
		/// <param name="conciliado_usuario_id">The <c>CONCILIADO_USUARIO_ID</c> column value.</param>
		/// <param name="conciliado_usuario_idNull">true if the method ignores the conciliado_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONCILIADO_USUARIO_IDCommand(decimal conciliado_usuario_id, bool conciliado_usuario_idNull)
		{
			string whereSql = "";
			if(conciliado_usuario_idNull)
				whereSql += "CONCILIADO_USUARIO_ID IS NULL";
			else
				whereSql += "CONCILIADO_USUARIO_ID=" + _db.CreateSqlParameterName("CONCILIADO_USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!conciliado_usuario_idNull)
				AddParameter(cmd, "CONCILIADO_USUARIO_ID", conciliado_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALORES_ID(decimal custodia_valores_id)
		{
			return DeleteByCUSTODIA_VALORES_ID(custodia_valores_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALORES_ID(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			return CreateDeleteByCUSTODIA_VALORES_IDCommand(custodia_valores_id, custodia_valores_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_CU_VAL</c> foreign key.
		/// </summary>
		/// <param name="custodia_valores_id">The <c>CUSTODIA_VALORES_ID</c> column value.</param>
		/// <param name="custodia_valores_idNull">true if the method ignores the custodia_valores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCUSTODIA_VALORES_IDCommand(decimal custodia_valores_id, bool custodia_valores_idNull)
		{
			string whereSql = "";
			if(custodia_valores_idNull)
				whereSql += "CUSTODIA_VALORES_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALORES_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALORES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!custodia_valores_idNull)
				AddParameter(cmd, "CUSTODIA_VALORES_ID", custodia_valores_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return DeleteByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return CreateDeleteByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_BANCARIO_IDCommand(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_idNull)
				whereSql += "DEPOSITO_BANCARIO_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_bancario_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_ID", deposito_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_ID(decimal descuento_documento_id)
		{
			return DeleteByDESCUENTO_DOCUMENTO_ID(descuento_documento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <param name="descuento_documento_idNull">true if the method ignores the descuento_documento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_ID(decimal descuento_documento_id, bool descuento_documento_idNull)
		{
			return CreateDeleteByDESCUENTO_DOCUMENTO_IDCommand(descuento_documento_id, descuento_documento_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_DESC</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_id">The <c>DESCUENTO_DOCUMENTO_ID</c> column value.</param>
		/// <param name="descuento_documento_idNull">true if the method ignores the descuento_documento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_DOCUMENTO_IDCommand(decimal descuento_documento_id, bool descuento_documento_idNull)
		{
			string whereSql = "";
			if(descuento_documento_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!descuento_documento_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_ID", descuento_documento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return DeleteByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_EVC</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id)
		{
			return DeleteByMOVIMIENTO_VARIO_TESORERIA_ID(movimiento_vario_tesoreria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			return CreateDeleteByMOVIMIENTO_VARIO_TESORERIA_IDCommand(movimiento_vario_tesoreria_id, movimiento_vario_tesoreria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_MVT_ID</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOVIMIENTO_VARIO_TESORERIA_IDCommand(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			string whereSql = "";
			if(movimiento_vario_tesoreria_idNull)
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!movimiento_vario_tesoreria_idNull)
				AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID", movimiento_vario_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return DeleteByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return CreateDeleteByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_PC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return DeleteByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_BANCARIA_IDCommand(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			string whereSql = "";
			if(transferencia_bancaria_idNull)
				whereSql += "TRANSFERENCIA_BANCARIA_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_bancaria_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID", transferencia_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCARIAS_MOV</c> table using the 
		/// <c>FK_CTACTE_BANCARIAS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCARIAS_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_BANCARIAS_MOV</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_BANCARIAS_MOV</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_BANCARIAS_MOV";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_BANCARIAS_MOV</c> table.
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		protected CTACTE_BANCARIAS_MOVRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		protected CTACTE_BANCARIAS_MOVRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_BANCARIAS_MOVRow"/> objects.</returns>
		protected virtual CTACTE_BANCARIAS_MOVRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int ingresoColumnIndex = reader.GetOrdinal("INGRESO");
			int egresoColumnIndex = reader.GetOrdinal("EGRESO");
			int saldoColumnIndex = reader.GetOrdinal("SALDO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int deposito_bancario_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_ID");
			int transferencia_bancaria_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BANCARIA_ID");
			int ajuste_bancario_idColumnIndex = reader.GetOrdinal("AJUSTE_BANCARIO_ID");
			int descuento_documento_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_ID");
			int custodia_valores_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALORES_ID");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int movimiento_vario_tesoreria_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_VARIO_TESORERIA_ID");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int conciliadoColumnIndex = reader.GetOrdinal("CONCILIADO");
			int conciliado_usuario_idColumnIndex = reader.GetOrdinal("CONCILIADO_USUARIO_ID");
			int conciliado_fechaColumnIndex = reader.GetOrdinal("CONCILIADO_FECHA");
			int desconciliado_usuario_idColumnIndex = reader.GetOrdinal("DESCONCILIADO_USUARIO_ID");
			int desconciliado_fechaColumnIndex = reader.GetOrdinal("DESCONCILIADO_FECHA");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int ctacte_cheque_girado_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_GIRADO_ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_BANCARIAS_MOVRow record = new CTACTE_BANCARIAS_MOVRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingresoColumnIndex))
						record.INGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(ingresoColumnIndex)), 9);
					if(!reader.IsDBNull(egresoColumnIndex))
						record.EGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(egresoColumnIndex)), 9);
					if(!reader.IsDBNull(saldoColumnIndex))
						record.SALDO = Math.Round(Convert.ToDecimal(reader.GetValue(saldoColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_idColumnIndex))
						record.DEPOSITO_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_bancaria_idColumnIndex))
						record.TRANSFERENCIA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ajuste_bancario_idColumnIndex))
						record.AJUSTE_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valores_idColumnIndex))
						record.CUSTODIA_VALORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valores_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(movimiento_vario_tesoreria_idColumnIndex))
						record.MOVIMIENTO_VARIO_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_vario_tesoreria_idColumnIndex)), 9);
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					if(!reader.IsDBNull(egreso_vario_caja_idColumnIndex))
						record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					record.CONCILIADO = Convert.ToString(reader.GetValue(conciliadoColumnIndex));
					if(!reader.IsDBNull(conciliado_usuario_idColumnIndex))
						record.CONCILIADO_USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conciliado_usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(conciliado_fechaColumnIndex))
						record.CONCILIADO_FECHA = Convert.ToDateTime(reader.GetValue(conciliado_fechaColumnIndex));
					if(!reader.IsDBNull(desconciliado_usuario_idColumnIndex))
						record.DESCONCILIADO_USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desconciliado_usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(desconciliado_fechaColumnIndex))
						record.DESCONCILIADO_FECHA = Convert.ToDateTime(reader.GetValue(desconciliado_fechaColumnIndex));
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_girado_idColumnIndex))
						record.CTACTE_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_BANCARIAS_MOVRow[])(recordList.ToArray(typeof(CTACTE_BANCARIAS_MOVRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_BANCARIAS_MOVRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_BANCARIAS_MOVRow"/> object.</returns>
		protected virtual CTACTE_BANCARIAS_MOVRow MapRow(DataRow row)
		{
			CTACTE_BANCARIAS_MOVRow mappedObject = new CTACTE_BANCARIAS_MOVRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "INGRESO"
			dataColumn = dataTable.Columns["INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO = (decimal)row[dataColumn];
			// Column "EGRESO"
			dataColumn = dataTable.Columns["EGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO = (decimal)row[dataColumn];
			// Column "SALDO"
			dataColumn = dataTable.Columns["SALDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_BANCARIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "AJUSTE_BANCARIO_ID"
			dataColumn = dataTable.Columns["AJUSTE_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALORES_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALORES_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "MOVIMIENTO_VARIO_TESORERIA_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_VARIO_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_VARIO_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "CONCILIADO"
			dataColumn = dataTable.Columns["CONCILIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCILIADO = (string)row[dataColumn];
			// Column "CONCILIADO_USUARIO_ID"
			dataColumn = dataTable.Columns["CONCILIADO_USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCILIADO_USUARIO_ID = (decimal)row[dataColumn];
			// Column "CONCILIADO_FECHA"
			dataColumn = dataTable.Columns["CONCILIADO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCILIADO_FECHA = (System.DateTime)row[dataColumn];
			// Column "DESCONCILIADO_USUARIO_ID"
			dataColumn = dataTable.Columns["DESCONCILIADO_USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONCILIADO_USUARIO_ID = (decimal)row[dataColumn];
			// Column "DESCONCILIADO_FECHA"
			dataColumn = dataTable.Columns["DESCONCILIADO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONCILIADO_FECHA = (System.DateTime)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_BANCARIAS_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_BANCARIAS_MOV";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SALDO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AJUSTE_BANCARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALORES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_VARIO_TESORERIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONCILIADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONCILIADO_USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONCILIADO_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("DESCONCILIADO_USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCONCILIADO_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
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

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AJUSTE_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MOVIMIENTO_VARIO_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONCILIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONCILIADO_USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONCILIADO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESCONCILIADO_USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCONCILIADO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_BANCARIAS_MOVCollection_Base class
}  // End of namespace
