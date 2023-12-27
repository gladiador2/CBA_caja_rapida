// <fileinfo name="CTACTE_TARJETAS_CREDITOCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_TARJETAS_CREDITOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_TARJETAS_CREDITOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_TARJETAS_CREDITOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_PROCESADORAColumnName = "CTACTE_PROCESADORA";
		public const string NUMEROColumnName = "NUMERO";
		public const string TITULARColumnName = "TITULAR";
		public const string LIMITE_CREDITOColumnName = "LIMITE_CREDITO";
		public const string BLOQUEADOColumnName = "BLOQUEADO";
		public const string MOTIVO_ULTIMO_BLOQUEOColumnName = "MOTIVO_ULTIMO_BLOQUEO";
		public const string USUARIO_ULTIMO_BLOQUEO_IDColumnName = "USUARIO_ULTIMO_BLOQUEO_ID";
		public const string FECHA_ULTIMO_BLOQUEOColumnName = "FECHA_ULTIMO_BLOQUEO";
		public const string USUARIO_ULTIMO_DESBLOQUEO_IDColumnName = "USUARIO_ULTIMO_DESBLOQUEO_ID";
		public const string FECHA_ULTIMO_DESBLOQUEOColumnName = "FECHA_ULTIMO_DESBLOQUEO";
		public const string USUARIO_CREACIONColumnName = "USUARIO_CREACION";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string CTACTE_TARJETA_CRED_EMIS_IDColumnName = "CTACTE_TARJETA_CRED_EMIS_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_TARJETAS_CREDITOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_TARJETAS_CREDITOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_TARJETAS_CREDITO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_TARJETAS_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_TARJETAS_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_TARJETAS_CREDITORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_TARJETAS_CREDITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_TARJETAS_CREDITORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_TARJETAS_CREDITORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public CTACTE_TARJETAS_CREDITORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_TARJETAS_CREDITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_TARJETAS_CREDITORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_TARJETAS_CREDITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_TARJETAS_CREDITORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public CTACTE_TARJETAS_CREDITORow[] GetByCTACTE_TARJETA_CRED_EMIS_ID(decimal ctacte_tarjeta_cred_emis_id)
		{
			return GetByCTACTE_TARJETA_CRED_EMIS_ID(ctacte_tarjeta_cred_emis_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <param name="ctacte_tarjeta_cred_emis_idNull">true if the method ignores the ctacte_tarjeta_cred_emis_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow[] GetByCTACTE_TARJETA_CRED_EMIS_ID(decimal ctacte_tarjeta_cred_emis_id, bool ctacte_tarjeta_cred_emis_idNull)
		{
			return MapRecords(CreateGetByCTACTE_TARJETA_CRED_EMIS_IDCommand(ctacte_tarjeta_cred_emis_id, ctacte_tarjeta_cred_emis_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_TARJETA_CRED_EMIS_IDAsDataTable(decimal ctacte_tarjeta_cred_emis_id)
		{
			return GetByCTACTE_TARJETA_CRED_EMIS_IDAsDataTable(ctacte_tarjeta_cred_emis_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <param name="ctacte_tarjeta_cred_emis_idNull">true if the method ignores the ctacte_tarjeta_cred_emis_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_TARJETA_CRED_EMIS_IDAsDataTable(decimal ctacte_tarjeta_cred_emis_id, bool ctacte_tarjeta_cred_emis_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_TARJETA_CRED_EMIS_IDCommand(ctacte_tarjeta_cred_emis_id, ctacte_tarjeta_cred_emis_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <param name="ctacte_tarjeta_cred_emis_idNull">true if the method ignores the ctacte_tarjeta_cred_emis_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_TARJETA_CRED_EMIS_IDCommand(decimal ctacte_tarjeta_cred_emis_id, bool ctacte_tarjeta_cred_emis_idNull)
		{
			string whereSql = "";
			if(ctacte_tarjeta_cred_emis_idNull)
				whereSql += "CTACTE_TARJETA_CRED_EMIS_ID IS NULL";
			else
				whereSql += "CTACTE_TARJETA_CRED_EMIS_ID=" + _db.CreateSqlParameterName("CTACTE_TARJETA_CRED_EMIS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_tarjeta_cred_emis_idNull)
				AddParameter(cmd, "CTACTE_TARJETA_CRED_EMIS_ID", ctacte_tarjeta_cred_emis_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public CTACTE_TARJETAS_CREDITORow[] GetByUSUARIO_ULTIMO_BLOQUEO_ID(decimal usuario_ultimo_bloqueo_id)
		{
			return GetByUSUARIO_ULTIMO_BLOQUEO_ID(usuario_ultimo_bloqueo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_bloqueo_idNull">true if the method ignores the usuario_ultimo_bloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow[] GetByUSUARIO_ULTIMO_BLOQUEO_ID(decimal usuario_ultimo_bloqueo_id, bool usuario_ultimo_bloqueo_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_ULTIMO_BLOQUEO_IDCommand(usuario_ultimo_bloqueo_id, usuario_ultimo_bloqueo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_ULTIMO_BLOQUEO_IDAsDataTable(decimal usuario_ultimo_bloqueo_id)
		{
			return GetByUSUARIO_ULTIMO_BLOQUEO_IDAsDataTable(usuario_ultimo_bloqueo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_bloqueo_idNull">true if the method ignores the usuario_ultimo_bloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ULTIMO_BLOQUEO_IDAsDataTable(decimal usuario_ultimo_bloqueo_id, bool usuario_ultimo_bloqueo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ULTIMO_BLOQUEO_IDCommand(usuario_ultimo_bloqueo_id, usuario_ultimo_bloqueo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_bloqueo_idNull">true if the method ignores the usuario_ultimo_bloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ULTIMO_BLOQUEO_IDCommand(decimal usuario_ultimo_bloqueo_id, bool usuario_ultimo_bloqueo_idNull)
		{
			string whereSql = "";
			if(usuario_ultimo_bloqueo_idNull)
				whereSql += "USUARIO_ULTIMO_BLOQUEO_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMO_BLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMO_BLOQUEO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_ultimo_bloqueo_idNull)
				AddParameter(cmd, "USUARIO_ULTIMO_BLOQUEO_ID", usuario_ultimo_bloqueo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion">The <c>USUARIO_CREACION</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow[] GetByUSUARIO_CREACION(decimal usuario_creacion)
		{
			return MapRecords(CreateGetByUSUARIO_CREACIONCommand(usuario_creacion));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion">The <c>USUARIO_CREACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACIONAsDataTable(decimal usuario_creacion)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACIONCommand(usuario_creacion));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_TARJETAS_C_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion">The <c>USUARIO_CREACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACIONCommand(decimal usuario_creacion)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION=" + _db.CreateSqlParameterName("USUARIO_CREACION");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREACION", usuario_creacion);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public CTACTE_TARJETAS_CREDITORow[] GetByUSUARIO_ULTIMO_DESBLOQUEO_ID(decimal usuario_ultimo_desbloqueo_id)
		{
			return GetByUSUARIO_ULTIMO_DESBLOQUEO_ID(usuario_ultimo_desbloqueo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_desbloqueo_idNull">true if the method ignores the usuario_ultimo_desbloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow[] GetByUSUARIO_ULTIMO_DESBLOQUEO_ID(decimal usuario_ultimo_desbloqueo_id, bool usuario_ultimo_desbloqueo_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_ULTIMO_DESBLOQUEO_IDCommand(usuario_ultimo_desbloqueo_id, usuario_ultimo_desbloqueo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_ULTIMO_DESBLOQUEO_IDAsDataTable(decimal usuario_ultimo_desbloqueo_id)
		{
			return GetByUSUARIO_ULTIMO_DESBLOQUEO_IDAsDataTable(usuario_ultimo_desbloqueo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_desbloqueo_idNull">true if the method ignores the usuario_ultimo_desbloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ULTIMO_DESBLOQUEO_IDAsDataTable(decimal usuario_ultimo_desbloqueo_id, bool usuario_ultimo_desbloqueo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ULTIMO_DESBLOQUEO_IDCommand(usuario_ultimo_desbloqueo_id, usuario_ultimo_desbloqueo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_desbloqueo_idNull">true if the method ignores the usuario_ultimo_desbloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ULTIMO_DESBLOQUEO_IDCommand(decimal usuario_ultimo_desbloqueo_id, bool usuario_ultimo_desbloqueo_idNull)
		{
			string whereSql = "";
			if(usuario_ultimo_desbloqueo_idNull)
				whereSql += "USUARIO_ULTIMO_DESBLOQUEO_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMO_DESBLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMO_DESBLOQUEO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_ultimo_desbloqueo_idNull)
				AddParameter(cmd, "USUARIO_ULTIMO_DESBLOQUEO_ID", usuario_ultimo_desbloqueo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public CTACTE_TARJETAS_CREDITORow[] GetByCTACTE_PROCESADORA(decimal ctacte_procesadora)
		{
			return GetByCTACTE_PROCESADORA(ctacte_procesadora, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects 
		/// by the <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <param name="ctacte_procesadoraNull">true if the method ignores the ctacte_procesadora
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		public virtual CTACTE_TARJETAS_CREDITORow[] GetByCTACTE_PROCESADORA(decimal ctacte_procesadora, bool ctacte_procesadoraNull)
		{
			return MapRecords(CreateGetByCTACTE_PROCESADORACommand(ctacte_procesadora, ctacte_procesadoraNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROCESADORAAsDataTable(decimal ctacte_procesadora)
		{
			return GetByCTACTE_PROCESADORAAsDataTable(ctacte_procesadora, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <param name="ctacte_procesadoraNull">true if the method ignores the ctacte_procesadora
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROCESADORAAsDataTable(decimal ctacte_procesadora, bool ctacte_procesadoraNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROCESADORACommand(ctacte_procesadora, ctacte_procesadoraNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <param name="ctacte_procesadoraNull">true if the method ignores the ctacte_procesadora
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROCESADORACommand(decimal ctacte_procesadora, bool ctacte_procesadoraNull)
		{
			string whereSql = "";
			if(ctacte_procesadoraNull)
				whereSql += "CTACTE_PROCESADORA IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_procesadoraNull)
				AddParameter(cmd, "CTACTE_PROCESADORA", ctacte_procesadora);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_TARJETAS_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_TARJETAS_CREDITORow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_TARJETAS_CREDITORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_TARJETAS_CREDITO (" +
				"ID, " +
				"CTACTE_PROCESADORA, " +
				"NUMERO, " +
				"TITULAR, " +
				"LIMITE_CREDITO, " +
				"BLOQUEADO, " +
				"MOTIVO_ULTIMO_BLOQUEO, " +
				"USUARIO_ULTIMO_BLOQUEO_ID, " +
				"FECHA_ULTIMO_BLOQUEO, " +
				"USUARIO_ULTIMO_DESBLOQUEO_ID, " +
				"FECHA_ULTIMO_DESBLOQUEO, " +
				"USUARIO_CREACION, " +
				"FECHA_CREACION, " +
				"ESTADO, " +
				"CTACTE_TARJETA_CRED_EMIS_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROCESADORA") + ", " +
				_db.CreateSqlParameterName("NUMERO") + ", " +
				_db.CreateSqlParameterName("TITULAR") + ", " +
				_db.CreateSqlParameterName("LIMITE_CREDITO") + ", " +
				_db.CreateSqlParameterName("BLOQUEADO") + ", " +
				_db.CreateSqlParameterName("MOTIVO_ULTIMO_BLOQUEO") + ", " +
				_db.CreateSqlParameterName("USUARIO_ULTIMO_BLOQUEO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMO_BLOQUEO") + ", " +
				_db.CreateSqlParameterName("USUARIO_ULTIMO_DESBLOQUEO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMO_DESBLOQUEO") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CTACTE_TARJETA_CRED_EMIS_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_PROCESADORA",
				value.IsCTACTE_PROCESADORANull ? DBNull.Value : (object)value.CTACTE_PROCESADORA);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "TITULAR", value.TITULAR);
			AddParameter(cmd, "LIMITE_CREDITO", value.LIMITE_CREDITO);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			AddParameter(cmd, "MOTIVO_ULTIMO_BLOQUEO", value.MOTIVO_ULTIMO_BLOQUEO);
			AddParameter(cmd, "USUARIO_ULTIMO_BLOQUEO_ID",
				value.IsUSUARIO_ULTIMO_BLOQUEO_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMO_BLOQUEO_ID);
			AddParameter(cmd, "FECHA_ULTIMO_BLOQUEO",
				value.IsFECHA_ULTIMO_BLOQUEONull ? DBNull.Value : (object)value.FECHA_ULTIMO_BLOQUEO);
			AddParameter(cmd, "USUARIO_ULTIMO_DESBLOQUEO_ID",
				value.IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMO_DESBLOQUEO_ID);
			AddParameter(cmd, "FECHA_ULTIMO_DESBLOQUEO",
				value.IsFECHA_ULTIMO_DESBLOQUEONull ? DBNull.Value : (object)value.FECHA_ULTIMO_DESBLOQUEO);
			AddParameter(cmd, "USUARIO_CREACION", value.USUARIO_CREACION);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CTACTE_TARJETA_CRED_EMIS_ID",
				value.IsCTACTE_TARJETA_CRED_EMIS_IDNull ? DBNull.Value : (object)value.CTACTE_TARJETA_CRED_EMIS_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_TARJETAS_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_TARJETAS_CREDITORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_TARJETAS_CREDITORow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_TARJETAS_CREDITO SET " +
				"CTACTE_PROCESADORA=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA") + ", " +
				"NUMERO=" + _db.CreateSqlParameterName("NUMERO") + ", " +
				"TITULAR=" + _db.CreateSqlParameterName("TITULAR") + ", " +
				"LIMITE_CREDITO=" + _db.CreateSqlParameterName("LIMITE_CREDITO") + ", " +
				"BLOQUEADO=" + _db.CreateSqlParameterName("BLOQUEADO") + ", " +
				"MOTIVO_ULTIMO_BLOQUEO=" + _db.CreateSqlParameterName("MOTIVO_ULTIMO_BLOQUEO") + ", " +
				"USUARIO_ULTIMO_BLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMO_BLOQUEO_ID") + ", " +
				"FECHA_ULTIMO_BLOQUEO=" + _db.CreateSqlParameterName("FECHA_ULTIMO_BLOQUEO") + ", " +
				"USUARIO_ULTIMO_DESBLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMO_DESBLOQUEO_ID") + ", " +
				"FECHA_ULTIMO_DESBLOQUEO=" + _db.CreateSqlParameterName("FECHA_ULTIMO_DESBLOQUEO") + ", " +
				"USUARIO_CREACION=" + _db.CreateSqlParameterName("USUARIO_CREACION") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CTACTE_TARJETA_CRED_EMIS_ID=" + _db.CreateSqlParameterName("CTACTE_TARJETA_CRED_EMIS_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_PROCESADORA",
				value.IsCTACTE_PROCESADORANull ? DBNull.Value : (object)value.CTACTE_PROCESADORA);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "TITULAR", value.TITULAR);
			AddParameter(cmd, "LIMITE_CREDITO", value.LIMITE_CREDITO);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			AddParameter(cmd, "MOTIVO_ULTIMO_BLOQUEO", value.MOTIVO_ULTIMO_BLOQUEO);
			AddParameter(cmd, "USUARIO_ULTIMO_BLOQUEO_ID",
				value.IsUSUARIO_ULTIMO_BLOQUEO_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMO_BLOQUEO_ID);
			AddParameter(cmd, "FECHA_ULTIMO_BLOQUEO",
				value.IsFECHA_ULTIMO_BLOQUEONull ? DBNull.Value : (object)value.FECHA_ULTIMO_BLOQUEO);
			AddParameter(cmd, "USUARIO_ULTIMO_DESBLOQUEO_ID",
				value.IsUSUARIO_ULTIMO_DESBLOQUEO_IDNull ? DBNull.Value : (object)value.USUARIO_ULTIMO_DESBLOQUEO_ID);
			AddParameter(cmd, "FECHA_ULTIMO_DESBLOQUEO",
				value.IsFECHA_ULTIMO_DESBLOQUEONull ? DBNull.Value : (object)value.FECHA_ULTIMO_DESBLOQUEO);
			AddParameter(cmd, "USUARIO_CREACION", value.USUARIO_CREACION);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CTACTE_TARJETA_CRED_EMIS_ID",
				value.IsCTACTE_TARJETA_CRED_EMIS_IDNull ? DBNull.Value : (object)value.CTACTE_TARJETA_CRED_EMIS_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_TARJETAS_CREDITO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_TARJETAS_CREDITO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_TARJETAS_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_TARJETAS_CREDITORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_TARJETAS_CREDITORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_TARJETAS_CREDITO</c> table using
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
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_TARJETA_CRED_EMIS_ID(decimal ctacte_tarjeta_cred_emis_id)
		{
			return DeleteByCTACTE_TARJETA_CRED_EMIS_ID(ctacte_tarjeta_cred_emis_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <param name="ctacte_tarjeta_cred_emis_idNull">true if the method ignores the ctacte_tarjeta_cred_emis_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_TARJETA_CRED_EMIS_ID(decimal ctacte_tarjeta_cred_emis_id, bool ctacte_tarjeta_cred_emis_idNull)
		{
			return CreateDeleteByCTACTE_TARJETA_CRED_EMIS_IDCommand(ctacte_tarjeta_cred_emis_id, ctacte_tarjeta_cred_emis_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_TARJETAS_C_EMIS_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_tarjeta_cred_emis_id">The <c>CTACTE_TARJETA_CRED_EMIS_ID</c> column value.</param>
		/// <param name="ctacte_tarjeta_cred_emis_idNull">true if the method ignores the ctacte_tarjeta_cred_emis_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_TARJETA_CRED_EMIS_IDCommand(decimal ctacte_tarjeta_cred_emis_id, bool ctacte_tarjeta_cred_emis_idNull)
		{
			string whereSql = "";
			if(ctacte_tarjeta_cred_emis_idNull)
				whereSql += "CTACTE_TARJETA_CRED_EMIS_ID IS NULL";
			else
				whereSql += "CTACTE_TARJETA_CRED_EMIS_ID=" + _db.CreateSqlParameterName("CTACTE_TARJETA_CRED_EMIS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_tarjeta_cred_emis_idNull)
				AddParameter(cmd, "CTACTE_TARJETA_CRED_EMIS_ID", ctacte_tarjeta_cred_emis_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMO_BLOQUEO_ID(decimal usuario_ultimo_bloqueo_id)
		{
			return DeleteByUSUARIO_ULTIMO_BLOQUEO_ID(usuario_ultimo_bloqueo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_bloqueo_idNull">true if the method ignores the usuario_ultimo_bloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMO_BLOQUEO_ID(decimal usuario_ultimo_bloqueo_id, bool usuario_ultimo_bloqueo_idNull)
		{
			return CreateDeleteByUSUARIO_ULTIMO_BLOQUEO_IDCommand(usuario_ultimo_bloqueo_id, usuario_ultimo_bloqueo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_TARJETAS_C_USR_B</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_bloqueo_id">The <c>USUARIO_ULTIMO_BLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_bloqueo_idNull">true if the method ignores the usuario_ultimo_bloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ULTIMO_BLOQUEO_IDCommand(decimal usuario_ultimo_bloqueo_id, bool usuario_ultimo_bloqueo_idNull)
		{
			string whereSql = "";
			if(usuario_ultimo_bloqueo_idNull)
				whereSql += "USUARIO_ULTIMO_BLOQUEO_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMO_BLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMO_BLOQUEO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_ultimo_bloqueo_idNull)
				AddParameter(cmd, "USUARIO_ULTIMO_BLOQUEO_ID", usuario_ultimo_bloqueo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_C_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion">The <c>USUARIO_CREACION</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION(decimal usuario_creacion)
		{
			return CreateDeleteByUSUARIO_CREACIONCommand(usuario_creacion).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_TARJETAS_C_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion">The <c>USUARIO_CREACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACIONCommand(decimal usuario_creacion)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION=" + _db.CreateSqlParameterName("USUARIO_CREACION");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREACION", usuario_creacion);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMO_DESBLOQUEO_ID(decimal usuario_ultimo_desbloqueo_id)
		{
			return DeleteByUSUARIO_ULTIMO_DESBLOQUEO_ID(usuario_ultimo_desbloqueo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_desbloqueo_idNull">true if the method ignores the usuario_ultimo_desbloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ULTIMO_DESBLOQUEO_ID(decimal usuario_ultimo_desbloqueo_id, bool usuario_ultimo_desbloqueo_idNull)
		{
			return CreateDeleteByUSUARIO_ULTIMO_DESBLOQUEO_IDCommand(usuario_ultimo_desbloqueo_id, usuario_ultimo_desbloqueo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_TARJETAS_C_USR_D</c> foreign key.
		/// </summary>
		/// <param name="usuario_ultimo_desbloqueo_id">The <c>USUARIO_ULTIMO_DESBLOQUEO_ID</c> column value.</param>
		/// <param name="usuario_ultimo_desbloqueo_idNull">true if the method ignores the usuario_ultimo_desbloqueo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ULTIMO_DESBLOQUEO_IDCommand(decimal usuario_ultimo_desbloqueo_id, bool usuario_ultimo_desbloqueo_idNull)
		{
			string whereSql = "";
			if(usuario_ultimo_desbloqueo_idNull)
				whereSql += "USUARIO_ULTIMO_DESBLOQUEO_ID IS NULL";
			else
				whereSql += "USUARIO_ULTIMO_DESBLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_ULTIMO_DESBLOQUEO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_ultimo_desbloqueo_idNull)
				AddParameter(cmd, "USUARIO_ULTIMO_DESBLOQUEO_ID", usuario_ultimo_desbloqueo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA(decimal ctacte_procesadora)
		{
			return DeleteByCTACTE_PROCESADORA(ctacte_procesadora, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_TARJETAS_CREDITO</c> table using the 
		/// <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <param name="ctacte_procesadoraNull">true if the method ignores the ctacte_procesadora
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA(decimal ctacte_procesadora, bool ctacte_procesadoraNull)
		{
			return CreateDeleteByCTACTE_PROCESADORACommand(ctacte_procesadora, ctacte_procesadoraNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_TARJETAS_CRED_PROC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora">The <c>CTACTE_PROCESADORA</c> column value.</param>
		/// <param name="ctacte_procesadoraNull">true if the method ignores the ctacte_procesadora
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROCESADORACommand(decimal ctacte_procesadora, bool ctacte_procesadoraNull)
		{
			string whereSql = "";
			if(ctacte_procesadoraNull)
				whereSql += "CTACTE_PROCESADORA IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_procesadoraNull)
				AddParameter(cmd, "CTACTE_PROCESADORA", ctacte_procesadora);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_TARJETAS_CREDITO</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_TARJETAS_CREDITO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_TARJETAS_CREDITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_TARJETAS_CREDITO</c> table.
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		protected CTACTE_TARJETAS_CREDITORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		protected CTACTE_TARJETAS_CREDITORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_TARJETAS_CREDITORow"/> objects.</returns>
		protected virtual CTACTE_TARJETAS_CREDITORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_procesadoraColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int titularColumnIndex = reader.GetOrdinal("TITULAR");
			int limite_creditoColumnIndex = reader.GetOrdinal("LIMITE_CREDITO");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");
			int motivo_ultimo_bloqueoColumnIndex = reader.GetOrdinal("MOTIVO_ULTIMO_BLOQUEO");
			int usuario_ultimo_bloqueo_idColumnIndex = reader.GetOrdinal("USUARIO_ULTIMO_BLOQUEO_ID");
			int fecha_ultimo_bloqueoColumnIndex = reader.GetOrdinal("FECHA_ULTIMO_BLOQUEO");
			int usuario_ultimo_desbloqueo_idColumnIndex = reader.GetOrdinal("USUARIO_ULTIMO_DESBLOQUEO_ID");
			int fecha_ultimo_desbloqueoColumnIndex = reader.GetOrdinal("FECHA_ULTIMO_DESBLOQUEO");
			int usuario_creacionColumnIndex = reader.GetOrdinal("USUARIO_CREACION");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ctacte_tarjeta_cred_emis_idColumnIndex = reader.GetOrdinal("CTACTE_TARJETA_CRED_EMIS_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_TARJETAS_CREDITORow record = new CTACTE_TARJETAS_CREDITORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadoraColumnIndex))
						record.CTACTE_PROCESADORA = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadoraColumnIndex)), 9);
					record.NUMERO = Convert.ToString(reader.GetValue(numeroColumnIndex));
					record.TITULAR = Convert.ToString(reader.GetValue(titularColumnIndex));
					record.LIMITE_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(limite_creditoColumnIndex)), 9);
					record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));
					if(!reader.IsDBNull(motivo_ultimo_bloqueoColumnIndex))
						record.MOTIVO_ULTIMO_BLOQUEO = Convert.ToString(reader.GetValue(motivo_ultimo_bloqueoColumnIndex));
					if(!reader.IsDBNull(usuario_ultimo_bloqueo_idColumnIndex))
						record.USUARIO_ULTIMO_BLOQUEO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_ultimo_bloqueo_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultimo_bloqueoColumnIndex))
						record.FECHA_ULTIMO_BLOQUEO = Convert.ToDateTime(reader.GetValue(fecha_ultimo_bloqueoColumnIndex));
					if(!reader.IsDBNull(usuario_ultimo_desbloqueo_idColumnIndex))
						record.USUARIO_ULTIMO_DESBLOQUEO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_ultimo_desbloqueo_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultimo_desbloqueoColumnIndex))
						record.FECHA_ULTIMO_DESBLOQUEO = Convert.ToDateTime(reader.GetValue(fecha_ultimo_desbloqueoColumnIndex));
					record.USUARIO_CREACION = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacionColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(ctacte_tarjeta_cred_emis_idColumnIndex))
						record.CTACTE_TARJETA_CRED_EMIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_tarjeta_cred_emis_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_TARJETAS_CREDITORow[])(recordList.ToArray(typeof(CTACTE_TARJETAS_CREDITORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_TARJETAS_CREDITORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_TARJETAS_CREDITORow"/> object.</returns>
		protected virtual CTACTE_TARJETAS_CREDITORow MapRow(DataRow row)
		{
			CTACTE_TARJETAS_CREDITORow mappedObject = new CTACTE_TARJETAS_CREDITORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA = (decimal)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (string)row[dataColumn];
			// Column "TITULAR"
			dataColumn = dataTable.Columns["TITULAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULAR = (string)row[dataColumn];
			// Column "LIMITE_CREDITO"
			dataColumn = dataTable.Columns["LIMITE_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_CREDITO = (decimal)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			// Column "MOTIVO_ULTIMO_BLOQUEO"
			dataColumn = dataTable.Columns["MOTIVO_ULTIMO_BLOQUEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_ULTIMO_BLOQUEO = (string)row[dataColumn];
			// Column "USUARIO_ULTIMO_BLOQUEO_ID"
			dataColumn = dataTable.Columns["USUARIO_ULTIMO_BLOQUEO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ULTIMO_BLOQUEO_ID = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMO_BLOQUEO"
			dataColumn = dataTable.Columns["FECHA_ULTIMO_BLOQUEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMO_BLOQUEO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ULTIMO_DESBLOQUEO_ID"
			dataColumn = dataTable.Columns["USUARIO_ULTIMO_DESBLOQUEO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ULTIMO_DESBLOQUEO_ID = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMO_DESBLOQUEO"
			dataColumn = dataTable.Columns["FECHA_ULTIMO_DESBLOQUEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMO_DESBLOQUEO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREACION"
			dataColumn = dataTable.Columns["USUARIO_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CTACTE_TARJETA_CRED_EMIS_ID"
			dataColumn = dataTable.Columns["CTACTE_TARJETA_CRED_EMIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_TARJETA_CRED_EMIS_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_TARJETAS_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_TARJETAS_CREDITO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TITULAR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIMITE_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOTIVO_ULTIMO_BLOQUEO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("USUARIO_ULTIMO_BLOQUEO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMO_BLOQUEO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_ULTIMO_DESBLOQUEO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMO_DESBLOQUEO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_TARJETA_CRED_EMIS_ID", typeof(decimal));
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

				case "CTACTE_PROCESADORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TITULAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIMITE_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MOTIVO_ULTIMO_BLOQUEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ULTIMO_BLOQUEO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMO_BLOQUEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ULTIMO_DESBLOQUEO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMO_DESBLOQUEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_TARJETA_CRED_EMIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_TARJETAS_CREDITOCollection_Base class
}  // End of namespace
