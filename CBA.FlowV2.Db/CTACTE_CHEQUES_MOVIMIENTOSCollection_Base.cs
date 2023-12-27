// <fileinfo name="CTACTE_CHEQUES_MOVIMIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_MOVIMIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CHEQUES_MOVIMIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_MOVIMIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string FECHA_MOVIMIENTOColumnName = "FECHA_MOVIMIENTO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string ESTADO_ORIGINAL_IDColumnName = "ESTADO_ORIGINAL_ID";
		public const string ESTADO_DESTINO_IDColumnName = "ESTADO_DESTINO_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CTACTE_CHEQUE_GIRADO_IDColumnName = "CTACTE_CHEQUE_GIRADO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_MOVIMIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CHEQUES_MOVIMIENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CHEQUES_MOVIMIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CHEQUES_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CHEQUES_MOVIMIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByCTACTE_CHEQUE_GIRADO_ID(decimal ctacte_cheque_girado_id)
		{
			return GetByCTACTE_CHEQUE_GIRADO_ID(ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_girado_idNull">true if the method ignores the ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByCTACTE_CHEQUE_GIRADO_ID(decimal ctacte_cheque_girado_id, bool ctacte_cheque_girado_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_GIRADO_IDCommand(ctacte_cheque_girado_id, ctacte_cheque_girado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_GIRADO_IDAsDataTable(decimal ctacte_cheque_girado_id)
		{
			return GetByCTACTE_CHEQUE_GIRADO_IDAsDataTable(ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByESTADO_DESTINO_ID(decimal estado_destino_id)
		{
			return GetByESTADO_DESTINO_ID(estado_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <param name="estado_destino_idNull">true if the method ignores the estado_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByESTADO_DESTINO_ID(decimal estado_destino_id, bool estado_destino_idNull)
		{
			return MapRecords(CreateGetByESTADO_DESTINO_IDCommand(estado_destino_id, estado_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByESTADO_DESTINO_IDAsDataTable(decimal estado_destino_id)
		{
			return GetByESTADO_DESTINO_IDAsDataTable(estado_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <param name="estado_destino_idNull">true if the method ignores the estado_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_DESTINO_IDAsDataTable(decimal estado_destino_id, bool estado_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_DESTINO_IDCommand(estado_destino_id, estado_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <param name="estado_destino_idNull">true if the method ignores the estado_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_DESTINO_IDCommand(decimal estado_destino_id, bool estado_destino_idNull)
		{
			string whereSql = "";
			if(estado_destino_idNull)
				whereSql += "ESTADO_DESTINO_ID IS NULL";
			else
				whereSql += "ESTADO_DESTINO_ID=" + _db.CreateSqlParameterName("ESTADO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!estado_destino_idNull)
				AddParameter(cmd, "ESTADO_DESTINO_ID", estado_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByESTADO_ORIGINAL_ID(decimal estado_original_id)
		{
			return GetByESTADO_ORIGINAL_ID(estado_original_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <param name="estado_original_idNull">true if the method ignores the estado_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByESTADO_ORIGINAL_ID(decimal estado_original_id, bool estado_original_idNull)
		{
			return MapRecords(CreateGetByESTADO_ORIGINAL_IDCommand(estado_original_id, estado_original_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByESTADO_ORIGINAL_IDAsDataTable(decimal estado_original_id)
		{
			return GetByESTADO_ORIGINAL_IDAsDataTable(estado_original_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <param name="estado_original_idNull">true if the method ignores the estado_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_ORIGINAL_IDAsDataTable(decimal estado_original_id, bool estado_original_idNull)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_ORIGINAL_IDCommand(estado_original_id, estado_original_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <param name="estado_original_idNull">true if the method ignores the estado_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_ORIGINAL_IDCommand(decimal estado_original_id, bool estado_original_idNull)
		{
			string whereSql = "";
			if(estado_original_idNull)
				whereSql += "ESTADO_ORIGINAL_ID IS NULL";
			else
				whereSql += "ESTADO_ORIGINAL_ID=" + _db.CreateSqlParameterName("ESTADO_ORIGINAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!estado_original_idNull)
				AddParameter(cmd, "ESTADO_ORIGINAL_ID", estado_original_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CHEQUES_MOVIMIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CHEQUES_MOVIMIENTOS (" +
				"ID, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"FECHA_MOVIMIENTO, " +
				"CASO_ID, " +
				"ESTADO_ORIGINAL_ID, " +
				"ESTADO_DESTINO_ID, " +
				"USUARIO_ID, " +
				"OBSERVACION, " +
				"CTACTE_CHEQUE_GIRADO_ID, " +
				"TEXTO_PREDEFINIDO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_ORIGINAL_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_GIRADO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "FECHA_MOVIMIENTO",
				value.IsFECHA_MOVIMIENTONull ? DBNull.Value : (object)value.FECHA_MOVIMIENTO);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "ESTADO_ORIGINAL_ID",
				value.IsESTADO_ORIGINAL_IDNull ? DBNull.Value : (object)value.ESTADO_ORIGINAL_ID);
			AddParameter(cmd, "ESTADO_DESTINO_ID",
				value.IsESTADO_DESTINO_IDNull ? DBNull.Value : (object)value.ESTADO_DESTINO_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_CHEQUE_GIRADO_ID",
				value.IsCTACTE_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CHEQUES_MOVIMIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CHEQUES_MOVIMIENTOS SET " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"FECHA_MOVIMIENTO=" + _db.CreateSqlParameterName("FECHA_MOVIMIENTO") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"ESTADO_ORIGINAL_ID=" + _db.CreateSqlParameterName("ESTADO_ORIGINAL_ID") + ", " +
				"ESTADO_DESTINO_ID=" + _db.CreateSqlParameterName("ESTADO_DESTINO_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_GIRADO_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "FECHA_MOVIMIENTO",
				value.IsFECHA_MOVIMIENTONull ? DBNull.Value : (object)value.FECHA_MOVIMIENTO);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "ESTADO_ORIGINAL_ID",
				value.IsESTADO_ORIGINAL_IDNull ? DBNull.Value : (object)value.ESTADO_ORIGINAL_ID);
			AddParameter(cmd, "ESTADO_DESTINO_ID",
				value.IsESTADO_DESTINO_IDNull ? DBNull.Value : (object)value.ESTADO_DESTINO_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_CHEQUE_GIRADO_ID",
				value.IsCTACTE_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CHEQUES_MOVIMIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using
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
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHEQUES_MOV_CASO</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_girado_id">The <c>CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_GIRADO_ID(decimal ctacte_cheque_girado_id)
		{
			return DeleteByCTACTE_CHEQUE_GIRADO_ID(ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHEQUES_MOV_CHQ_GI</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CHEQUES_MOV_CHQ_RE</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DESTINO_ID(decimal estado_destino_id)
		{
			return DeleteByESTADO_DESTINO_ID(estado_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <param name="estado_destino_idNull">true if the method ignores the estado_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DESTINO_ID(decimal estado_destino_id, bool estado_destino_idNull)
		{
			return CreateDeleteByESTADO_DESTINO_IDCommand(estado_destino_id, estado_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_MOV_EST_D</c> foreign key.
		/// </summary>
		/// <param name="estado_destino_id">The <c>ESTADO_DESTINO_ID</c> column value.</param>
		/// <param name="estado_destino_idNull">true if the method ignores the estado_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_DESTINO_IDCommand(decimal estado_destino_id, bool estado_destino_idNull)
		{
			string whereSql = "";
			if(estado_destino_idNull)
				whereSql += "ESTADO_DESTINO_ID IS NULL";
			else
				whereSql += "ESTADO_DESTINO_ID=" + _db.CreateSqlParameterName("ESTADO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!estado_destino_idNull)
				AddParameter(cmd, "ESTADO_DESTINO_ID", estado_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_ORIGINAL_ID(decimal estado_original_id)
		{
			return DeleteByESTADO_ORIGINAL_ID(estado_original_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <param name="estado_original_idNull">true if the method ignores the estado_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_ORIGINAL_ID(decimal estado_original_id, bool estado_original_idNull)
		{
			return CreateDeleteByESTADO_ORIGINAL_IDCommand(estado_original_id, estado_original_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_MOV_EST_O</c> foreign key.
		/// </summary>
		/// <param name="estado_original_id">The <c>ESTADO_ORIGINAL_ID</c> column value.</param>
		/// <param name="estado_original_idNull">true if the method ignores the estado_original_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_ORIGINAL_IDCommand(decimal estado_original_id, bool estado_original_idNull)
		{
			string whereSql = "";
			if(estado_original_idNull)
				whereSql += "ESTADO_ORIGINAL_ID IS NULL";
			else
				whereSql += "ESTADO_ORIGINAL_ID=" + _db.CreateSqlParameterName("ESTADO_ORIGINAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!estado_original_idNull)
				AddParameter(cmd, "ESTADO_ORIGINAL_ID", estado_original_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_MOV_TXT</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table using the 
		/// <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id, usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CHEQUES_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_CHEQUES_MOVIMIENTOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CHEQUES_MOVIMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CHEQUES_MOVIMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_MOVIMIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		protected CTACTE_CHEQUES_MOVIMIENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> objects.</returns>
		protected virtual CTACTE_CHEQUES_MOVIMIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int fecha_movimientoColumnIndex = reader.GetOrdinal("FECHA_MOVIMIENTO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int estado_original_idColumnIndex = reader.GetOrdinal("ESTADO_ORIGINAL_ID");
			int estado_destino_idColumnIndex = reader.GetOrdinal("ESTADO_DESTINO_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int ctacte_cheque_girado_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_GIRADO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CHEQUES_MOVIMIENTOSRow record = new CTACTE_CHEQUES_MOVIMIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_movimientoColumnIndex))
						record.FECHA_MOVIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_movimientoColumnIndex));
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_original_idColumnIndex))
						record.ESTADO_ORIGINAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_original_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_destino_idColumnIndex))
						record.ESTADO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_girado_idColumnIndex))
						record.CTACTE_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CHEQUES_MOVIMIENTOSRow[])(recordList.ToArray(typeof(CTACTE_CHEQUES_MOVIMIENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CHEQUES_MOVIMIENTOSRow"/> object.</returns>
		protected virtual CTACTE_CHEQUES_MOVIMIENTOSRow MapRow(DataRow row)
		{
			CTACTE_CHEQUES_MOVIMIENTOSRow mappedObject = new CTACTE_CHEQUES_MOVIMIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "FECHA_MOVIMIENTO"
			dataColumn = dataTable.Columns["FECHA_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MOVIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_ORIGINAL_ID"
			dataColumn = dataTable.Columns["ESTADO_ORIGINAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ORIGINAL_ID = (decimal)row[dataColumn];
			// Column "ESTADO_DESTINO_ID"
			dataColumn = dataTable.Columns["ESTADO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CHEQUES_MOVIMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CHEQUES_MOVIMIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_MOVIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO_ORIGINAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
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

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_ORIGINAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CHEQUES_MOVIMIENTOSCollection_Base class
}  // End of namespace
