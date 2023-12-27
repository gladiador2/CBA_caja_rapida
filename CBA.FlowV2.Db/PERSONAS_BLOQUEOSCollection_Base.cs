// <fileinfo name="PERSONAS_BLOQUEOSCollection_Base.cs">
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
	/// The base class for <see cref="PERSONAS_BLOQUEOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PERSONAS_BLOQUEOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_BLOQUEOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string USUARIO_BLOQUEO_IDColumnName = "USUARIO_BLOQUEO_ID";
		public const string FECHA_BLOQUEOColumnName = "FECHA_BLOQUEO";
		public const string TEXTO_MOTIVO_IDColumnName = "TEXTO_MOTIVO_ID";
		public const string USUARIO_DESBLOQUEO1_IDColumnName = "USUARIO_DESBLOQUEO1_ID";
		public const string USUARIO_DESBLOQUEO2_IDColumnName = "USUARIO_DESBLOQUEO2_ID";
		public const string USUARIO_DESBLOQUEO3_IDColumnName = "USUARIO_DESBLOQUEO3_ID";
		public const string FECHA_DESBLOQUEO1ColumnName = "FECHA_DESBLOQUEO1";
		public const string FECHA_DESBLOQUEO2ColumnName = "FECHA_DESBLOQUEO2";
		public const string FECHA_DESBLOQUEO3ColumnName = "FECHA_DESBLOQUEO3";
		public const string DESBLOQUEADOColumnName = "DESBLOQUEADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_BLOQUEOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PERSONAS_BLOQUEOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PERSONAS_BLOQUEOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PERSONAS_BLOQUEOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PERSONAS_BLOQUEOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PERSONAS_BLOQUEOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PERSONAS_BLOQUEOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PERSONAS_BLOQUEOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PERSONAS_BLOQUEOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public PERSONAS_BLOQUEOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects that 
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
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PERSONAS_BLOQUEOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PERSONAS_BLOQUEOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PERSONAS_BLOQUEOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PERSONAS_BLOQUEOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PERSONAS_BLOQUEOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_BLOQ_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_TEXTO_MOTIVO</c> foreign key.
		/// </summary>
		/// <param name="texto_motivo_id">The <c>TEXTO_MOTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetByTEXTO_MOTIVO_ID(decimal texto_motivo_id)
		{
			return MapRecords(CreateGetByTEXTO_MOTIVO_IDCommand(texto_motivo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_TEXTO_MOTIVO</c> foreign key.
		/// </summary>
		/// <param name="texto_motivo_id">The <c>TEXTO_MOTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_MOTIVO_IDAsDataTable(decimal texto_motivo_id)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_MOTIVO_IDCommand(texto_motivo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_BLOQ_TEXTO_MOTIVO</c> foreign key.
		/// </summary>
		/// <param name="texto_motivo_id">The <c>TEXTO_MOTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_MOTIVO_IDCommand(decimal texto_motivo_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_MOTIVO_ID=" + _db.CreateSqlParameterName("TEXTO_MOTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TEXTO_MOTIVO_ID", texto_motivo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_USUARIO_BLOQ</c> foreign key.
		/// </summary>
		/// <param name="usuario_bloqueo_id">The <c>USUARIO_BLOQUEO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetByUSUARIO_BLOQUEO_ID(decimal usuario_bloqueo_id)
		{
			return MapRecords(CreateGetByUSUARIO_BLOQUEO_IDCommand(usuario_bloqueo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_USUARIO_BLOQ</c> foreign key.
		/// </summary>
		/// <param name="usuario_bloqueo_id">The <c>USUARIO_BLOQUEO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_BLOQUEO_IDAsDataTable(decimal usuario_bloqueo_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_BLOQUEO_IDCommand(usuario_bloqueo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_BLOQ_USUARIO_BLOQ</c> foreign key.
		/// </summary>
		/// <param name="usuario_bloqueo_id">The <c>USUARIO_BLOQUEO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_BLOQUEO_IDCommand(decimal usuario_bloqueo_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_BLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_BLOQUEO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_BLOQUEO_ID", usuario_bloqueo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public PERSONAS_BLOQUEOSRow[] GetByUSUARIO_DESBLOQUEO1_ID(decimal usuario_desbloqueo1_id)
		{
			return GetByUSUARIO_DESBLOQUEO1_ID(usuario_desbloqueo1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo1_idNull">true if the method ignores the usuario_desbloqueo1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetByUSUARIO_DESBLOQUEO1_ID(decimal usuario_desbloqueo1_id, bool usuario_desbloqueo1_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_DESBLOQUEO1_IDCommand(usuario_desbloqueo1_id, usuario_desbloqueo1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_DESBLOQUEO1_IDAsDataTable(decimal usuario_desbloqueo1_id)
		{
			return GetByUSUARIO_DESBLOQUEO1_IDAsDataTable(usuario_desbloqueo1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo1_idNull">true if the method ignores the usuario_desbloqueo1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_DESBLOQUEO1_IDAsDataTable(decimal usuario_desbloqueo1_id, bool usuario_desbloqueo1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_DESBLOQUEO1_IDCommand(usuario_desbloqueo1_id, usuario_desbloqueo1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo1_idNull">true if the method ignores the usuario_desbloqueo1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_DESBLOQUEO1_IDCommand(decimal usuario_desbloqueo1_id, bool usuario_desbloqueo1_idNull)
		{
			string whereSql = "";
			if(usuario_desbloqueo1_idNull)
				whereSql += "USUARIO_DESBLOQUEO1_ID IS NULL";
			else
				whereSql += "USUARIO_DESBLOQUEO1_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_desbloqueo1_idNull)
				AddParameter(cmd, "USUARIO_DESBLOQUEO1_ID", usuario_desbloqueo1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public PERSONAS_BLOQUEOSRow[] GetByUSUARIO_DESBLOQUEO2_ID(decimal usuario_desbloqueo2_id)
		{
			return GetByUSUARIO_DESBLOQUEO2_ID(usuario_desbloqueo2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo2_idNull">true if the method ignores the usuario_desbloqueo2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetByUSUARIO_DESBLOQUEO2_ID(decimal usuario_desbloqueo2_id, bool usuario_desbloqueo2_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_DESBLOQUEO2_IDCommand(usuario_desbloqueo2_id, usuario_desbloqueo2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_DESBLOQUEO2_IDAsDataTable(decimal usuario_desbloqueo2_id)
		{
			return GetByUSUARIO_DESBLOQUEO2_IDAsDataTable(usuario_desbloqueo2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo2_idNull">true if the method ignores the usuario_desbloqueo2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_DESBLOQUEO2_IDAsDataTable(decimal usuario_desbloqueo2_id, bool usuario_desbloqueo2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_DESBLOQUEO2_IDCommand(usuario_desbloqueo2_id, usuario_desbloqueo2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo2_idNull">true if the method ignores the usuario_desbloqueo2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_DESBLOQUEO2_IDCommand(decimal usuario_desbloqueo2_id, bool usuario_desbloqueo2_idNull)
		{
			string whereSql = "";
			if(usuario_desbloqueo2_idNull)
				whereSql += "USUARIO_DESBLOQUEO2_ID IS NULL";
			else
				whereSql += "USUARIO_DESBLOQUEO2_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_desbloqueo2_idNull)
				AddParameter(cmd, "USUARIO_DESBLOQUEO2_ID", usuario_desbloqueo2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public PERSONAS_BLOQUEOSRow[] GetByUSUARIO_DESBLOQUEO3_ID(decimal usuario_desbloqueo3_id)
		{
			return GetByUSUARIO_DESBLOQUEO3_ID(usuario_desbloqueo3_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_BLOQUEOSRow"/> objects 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo3_idNull">true if the method ignores the usuario_desbloqueo3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		public virtual PERSONAS_BLOQUEOSRow[] GetByUSUARIO_DESBLOQUEO3_ID(decimal usuario_desbloqueo3_id, bool usuario_desbloqueo3_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_DESBLOQUEO3_IDCommand(usuario_desbloqueo3_id, usuario_desbloqueo3_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_DESBLOQUEO3_IDAsDataTable(decimal usuario_desbloqueo3_id)
		{
			return GetByUSUARIO_DESBLOQUEO3_IDAsDataTable(usuario_desbloqueo3_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo3_idNull">true if the method ignores the usuario_desbloqueo3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_DESBLOQUEO3_IDAsDataTable(decimal usuario_desbloqueo3_id, bool usuario_desbloqueo3_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_DESBLOQUEO3_IDCommand(usuario_desbloqueo3_id, usuario_desbloqueo3_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo3_idNull">true if the method ignores the usuario_desbloqueo3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_DESBLOQUEO3_IDCommand(decimal usuario_desbloqueo3_id, bool usuario_desbloqueo3_idNull)
		{
			string whereSql = "";
			if(usuario_desbloqueo3_idNull)
				whereSql += "USUARIO_DESBLOQUEO3_ID IS NULL";
			else
				whereSql += "USUARIO_DESBLOQUEO3_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO3_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_desbloqueo3_idNull)
				AddParameter(cmd, "USUARIO_DESBLOQUEO3_ID", usuario_desbloqueo3_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PERSONAS_BLOQUEOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_BLOQUEOSRow"/> object to be inserted.</param>
		public virtual void Insert(PERSONAS_BLOQUEOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PERSONAS_BLOQUEOS (" +
				"ID, " +
				"PERSONA_ID, " +
				"USUARIO_BLOQUEO_ID, " +
				"FECHA_BLOQUEO, " +
				"TEXTO_MOTIVO_ID, " +
				"USUARIO_DESBLOQUEO1_ID, " +
				"USUARIO_DESBLOQUEO2_ID, " +
				"USUARIO_DESBLOQUEO3_ID, " +
				"FECHA_DESBLOQUEO1, " +
				"FECHA_DESBLOQUEO2, " +
				"FECHA_DESBLOQUEO3, " +
				"DESBLOQUEADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_BLOQUEO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_BLOQUEO") + ", " +
				_db.CreateSqlParameterName("TEXTO_MOTIVO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_DESBLOQUEO1_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_DESBLOQUEO2_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_DESBLOQUEO3_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_DESBLOQUEO1") + ", " +
				_db.CreateSqlParameterName("FECHA_DESBLOQUEO2") + ", " +
				_db.CreateSqlParameterName("FECHA_DESBLOQUEO3") + ", " +
				_db.CreateSqlParameterName("DESBLOQUEADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "USUARIO_BLOQUEO_ID", value.USUARIO_BLOQUEO_ID);
			AddParameter(cmd, "FECHA_BLOQUEO", value.FECHA_BLOQUEO);
			AddParameter(cmd, "TEXTO_MOTIVO_ID", value.TEXTO_MOTIVO_ID);
			AddParameter(cmd, "USUARIO_DESBLOQUEO1_ID",
				value.IsUSUARIO_DESBLOQUEO1_IDNull ? DBNull.Value : (object)value.USUARIO_DESBLOQUEO1_ID);
			AddParameter(cmd, "USUARIO_DESBLOQUEO2_ID",
				value.IsUSUARIO_DESBLOQUEO2_IDNull ? DBNull.Value : (object)value.USUARIO_DESBLOQUEO2_ID);
			AddParameter(cmd, "USUARIO_DESBLOQUEO3_ID",
				value.IsUSUARIO_DESBLOQUEO3_IDNull ? DBNull.Value : (object)value.USUARIO_DESBLOQUEO3_ID);
			AddParameter(cmd, "FECHA_DESBLOQUEO1",
				value.IsFECHA_DESBLOQUEO1Null ? DBNull.Value : (object)value.FECHA_DESBLOQUEO1);
			AddParameter(cmd, "FECHA_DESBLOQUEO2",
				value.IsFECHA_DESBLOQUEO2Null ? DBNull.Value : (object)value.FECHA_DESBLOQUEO2);
			AddParameter(cmd, "FECHA_DESBLOQUEO3",
				value.IsFECHA_DESBLOQUEO3Null ? DBNull.Value : (object)value.FECHA_DESBLOQUEO3);
			AddParameter(cmd, "DESBLOQUEADO", value.DESBLOQUEADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PERSONAS_BLOQUEOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_BLOQUEOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PERSONAS_BLOQUEOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.PERSONAS_BLOQUEOS SET " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"USUARIO_BLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_BLOQUEO_ID") + ", " +
				"FECHA_BLOQUEO=" + _db.CreateSqlParameterName("FECHA_BLOQUEO") + ", " +
				"TEXTO_MOTIVO_ID=" + _db.CreateSqlParameterName("TEXTO_MOTIVO_ID") + ", " +
				"USUARIO_DESBLOQUEO1_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO1_ID") + ", " +
				"USUARIO_DESBLOQUEO2_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO2_ID") + ", " +
				"USUARIO_DESBLOQUEO3_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO3_ID") + ", " +
				"FECHA_DESBLOQUEO1=" + _db.CreateSqlParameterName("FECHA_DESBLOQUEO1") + ", " +
				"FECHA_DESBLOQUEO2=" + _db.CreateSqlParameterName("FECHA_DESBLOQUEO2") + ", " +
				"FECHA_DESBLOQUEO3=" + _db.CreateSqlParameterName("FECHA_DESBLOQUEO3") + ", " +
				"DESBLOQUEADO=" + _db.CreateSqlParameterName("DESBLOQUEADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "USUARIO_BLOQUEO_ID", value.USUARIO_BLOQUEO_ID);
			AddParameter(cmd, "FECHA_BLOQUEO", value.FECHA_BLOQUEO);
			AddParameter(cmd, "TEXTO_MOTIVO_ID", value.TEXTO_MOTIVO_ID);
			AddParameter(cmd, "USUARIO_DESBLOQUEO1_ID",
				value.IsUSUARIO_DESBLOQUEO1_IDNull ? DBNull.Value : (object)value.USUARIO_DESBLOQUEO1_ID);
			AddParameter(cmd, "USUARIO_DESBLOQUEO2_ID",
				value.IsUSUARIO_DESBLOQUEO2_IDNull ? DBNull.Value : (object)value.USUARIO_DESBLOQUEO2_ID);
			AddParameter(cmd, "USUARIO_DESBLOQUEO3_ID",
				value.IsUSUARIO_DESBLOQUEO3_IDNull ? DBNull.Value : (object)value.USUARIO_DESBLOQUEO3_ID);
			AddParameter(cmd, "FECHA_DESBLOQUEO1",
				value.IsFECHA_DESBLOQUEO1Null ? DBNull.Value : (object)value.FECHA_DESBLOQUEO1);
			AddParameter(cmd, "FECHA_DESBLOQUEO2",
				value.IsFECHA_DESBLOQUEO2Null ? DBNull.Value : (object)value.FECHA_DESBLOQUEO2);
			AddParameter(cmd, "FECHA_DESBLOQUEO3",
				value.IsFECHA_DESBLOQUEO3Null ? DBNull.Value : (object)value.FECHA_DESBLOQUEO3);
			AddParameter(cmd, "DESBLOQUEADO", value.DESBLOQUEADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PERSONAS_BLOQUEOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PERSONAS_BLOQUEOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PERSONAS_BLOQUEOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_BLOQUEOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PERSONAS_BLOQUEOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PERSONAS_BLOQUEOS</c> table using
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
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_BLOQ_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_TEXTO_MOTIVO</c> foreign key.
		/// </summary>
		/// <param name="texto_motivo_id">The <c>TEXTO_MOTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_MOTIVO_ID(decimal texto_motivo_id)
		{
			return CreateDeleteByTEXTO_MOTIVO_IDCommand(texto_motivo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_BLOQ_TEXTO_MOTIVO</c> foreign key.
		/// </summary>
		/// <param name="texto_motivo_id">The <c>TEXTO_MOTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_MOTIVO_IDCommand(decimal texto_motivo_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_MOTIVO_ID=" + _db.CreateSqlParameterName("TEXTO_MOTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TEXTO_MOTIVO_ID", texto_motivo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_USUARIO_BLOQ</c> foreign key.
		/// </summary>
		/// <param name="usuario_bloqueo_id">The <c>USUARIO_BLOQUEO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BLOQUEO_ID(decimal usuario_bloqueo_id)
		{
			return CreateDeleteByUSUARIO_BLOQUEO_IDCommand(usuario_bloqueo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_BLOQ_USUARIO_BLOQ</c> foreign key.
		/// </summary>
		/// <param name="usuario_bloqueo_id">The <c>USUARIO_BLOQUEO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_BLOQUEO_IDCommand(decimal usuario_bloqueo_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_BLOQUEO_ID=" + _db.CreateSqlParameterName("USUARIO_BLOQUEO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_BLOQUEO_ID", usuario_bloqueo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESBLOQUEO1_ID(decimal usuario_desbloqueo1_id)
		{
			return DeleteByUSUARIO_DESBLOQUEO1_ID(usuario_desbloqueo1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo1_idNull">true if the method ignores the usuario_desbloqueo1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESBLOQUEO1_ID(decimal usuario_desbloqueo1_id, bool usuario_desbloqueo1_idNull)
		{
			return CreateDeleteByUSUARIO_DESBLOQUEO1_IDCommand(usuario_desbloqueo1_id, usuario_desbloqueo1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ1</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo1_id">The <c>USUARIO_DESBLOQUEO1_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo1_idNull">true if the method ignores the usuario_desbloqueo1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_DESBLOQUEO1_IDCommand(decimal usuario_desbloqueo1_id, bool usuario_desbloqueo1_idNull)
		{
			string whereSql = "";
			if(usuario_desbloqueo1_idNull)
				whereSql += "USUARIO_DESBLOQUEO1_ID IS NULL";
			else
				whereSql += "USUARIO_DESBLOQUEO1_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_desbloqueo1_idNull)
				AddParameter(cmd, "USUARIO_DESBLOQUEO1_ID", usuario_desbloqueo1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESBLOQUEO2_ID(decimal usuario_desbloqueo2_id)
		{
			return DeleteByUSUARIO_DESBLOQUEO2_ID(usuario_desbloqueo2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo2_idNull">true if the method ignores the usuario_desbloqueo2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESBLOQUEO2_ID(decimal usuario_desbloqueo2_id, bool usuario_desbloqueo2_idNull)
		{
			return CreateDeleteByUSUARIO_DESBLOQUEO2_IDCommand(usuario_desbloqueo2_id, usuario_desbloqueo2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ2</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo2_id">The <c>USUARIO_DESBLOQUEO2_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo2_idNull">true if the method ignores the usuario_desbloqueo2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_DESBLOQUEO2_IDCommand(decimal usuario_desbloqueo2_id, bool usuario_desbloqueo2_idNull)
		{
			string whereSql = "";
			if(usuario_desbloqueo2_idNull)
				whereSql += "USUARIO_DESBLOQUEO2_ID IS NULL";
			else
				whereSql += "USUARIO_DESBLOQUEO2_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_desbloqueo2_idNull)
				AddParameter(cmd, "USUARIO_DESBLOQUEO2_ID", usuario_desbloqueo2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESBLOQUEO3_ID(decimal usuario_desbloqueo3_id)
		{
			return DeleteByUSUARIO_DESBLOQUEO3_ID(usuario_desbloqueo3_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_BLOQUEOS</c> table using the 
		/// <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo3_idNull">true if the method ignores the usuario_desbloqueo3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_DESBLOQUEO3_ID(decimal usuario_desbloqueo3_id, bool usuario_desbloqueo3_idNull)
		{
			return CreateDeleteByUSUARIO_DESBLOQUEO3_IDCommand(usuario_desbloqueo3_id, usuario_desbloqueo3_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERS_BLOQ_USUARIO_DESBLOQ3</c> foreign key.
		/// </summary>
		/// <param name="usuario_desbloqueo3_id">The <c>USUARIO_DESBLOQUEO3_ID</c> column value.</param>
		/// <param name="usuario_desbloqueo3_idNull">true if the method ignores the usuario_desbloqueo3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_DESBLOQUEO3_IDCommand(decimal usuario_desbloqueo3_id, bool usuario_desbloqueo3_idNull)
		{
			string whereSql = "";
			if(usuario_desbloqueo3_idNull)
				whereSql += "USUARIO_DESBLOQUEO3_ID IS NULL";
			else
				whereSql += "USUARIO_DESBLOQUEO3_ID=" + _db.CreateSqlParameterName("USUARIO_DESBLOQUEO3_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_desbloqueo3_idNull)
				AddParameter(cmd, "USUARIO_DESBLOQUEO3_ID", usuario_desbloqueo3_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PERSONAS_BLOQUEOS</c> records that match the specified criteria.
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
		/// to delete <c>PERSONAS_BLOQUEOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PERSONAS_BLOQUEOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PERSONAS_BLOQUEOS</c> table.
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
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		protected PERSONAS_BLOQUEOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		protected PERSONAS_BLOQUEOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PERSONAS_BLOQUEOSRow"/> objects.</returns>
		protected virtual PERSONAS_BLOQUEOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int usuario_bloqueo_idColumnIndex = reader.GetOrdinal("USUARIO_BLOQUEO_ID");
			int fecha_bloqueoColumnIndex = reader.GetOrdinal("FECHA_BLOQUEO");
			int texto_motivo_idColumnIndex = reader.GetOrdinal("TEXTO_MOTIVO_ID");
			int usuario_desbloqueo1_idColumnIndex = reader.GetOrdinal("USUARIO_DESBLOQUEO1_ID");
			int usuario_desbloqueo2_idColumnIndex = reader.GetOrdinal("USUARIO_DESBLOQUEO2_ID");
			int usuario_desbloqueo3_idColumnIndex = reader.GetOrdinal("USUARIO_DESBLOQUEO3_ID");
			int fecha_desbloqueo1ColumnIndex = reader.GetOrdinal("FECHA_DESBLOQUEO1");
			int fecha_desbloqueo2ColumnIndex = reader.GetOrdinal("FECHA_DESBLOQUEO2");
			int fecha_desbloqueo3ColumnIndex = reader.GetOrdinal("FECHA_DESBLOQUEO3");
			int desbloqueadoColumnIndex = reader.GetOrdinal("DESBLOQUEADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PERSONAS_BLOQUEOSRow record = new PERSONAS_BLOQUEOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.USUARIO_BLOQUEO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_bloqueo_idColumnIndex)), 9);
					record.FECHA_BLOQUEO = Convert.ToDateTime(reader.GetValue(fecha_bloqueoColumnIndex));
					record.TEXTO_MOTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_motivo_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_desbloqueo1_idColumnIndex))
						record.USUARIO_DESBLOQUEO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_desbloqueo1_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_desbloqueo2_idColumnIndex))
						record.USUARIO_DESBLOQUEO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_desbloqueo2_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_desbloqueo3_idColumnIndex))
						record.USUARIO_DESBLOQUEO3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_desbloqueo3_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desbloqueo1ColumnIndex))
						record.FECHA_DESBLOQUEO1 = Convert.ToDateTime(reader.GetValue(fecha_desbloqueo1ColumnIndex));
					if(!reader.IsDBNull(fecha_desbloqueo2ColumnIndex))
						record.FECHA_DESBLOQUEO2 = Convert.ToDateTime(reader.GetValue(fecha_desbloqueo2ColumnIndex));
					if(!reader.IsDBNull(fecha_desbloqueo3ColumnIndex))
						record.FECHA_DESBLOQUEO3 = Convert.ToDateTime(reader.GetValue(fecha_desbloqueo3ColumnIndex));
					record.DESBLOQUEADO = Convert.ToString(reader.GetValue(desbloqueadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PERSONAS_BLOQUEOSRow[])(recordList.ToArray(typeof(PERSONAS_BLOQUEOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PERSONAS_BLOQUEOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PERSONAS_BLOQUEOSRow"/> object.</returns>
		protected virtual PERSONAS_BLOQUEOSRow MapRow(DataRow row)
		{
			PERSONAS_BLOQUEOSRow mappedObject = new PERSONAS_BLOQUEOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "USUARIO_BLOQUEO_ID"
			dataColumn = dataTable.Columns["USUARIO_BLOQUEO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_BLOQUEO_ID = (decimal)row[dataColumn];
			// Column "FECHA_BLOQUEO"
			dataColumn = dataTable.Columns["FECHA_BLOQUEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_BLOQUEO = (System.DateTime)row[dataColumn];
			// Column "TEXTO_MOTIVO_ID"
			dataColumn = dataTable.Columns["TEXTO_MOTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_MOTIVO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_DESBLOQUEO1_ID"
			dataColumn = dataTable.Columns["USUARIO_DESBLOQUEO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_DESBLOQUEO1_ID = (decimal)row[dataColumn];
			// Column "USUARIO_DESBLOQUEO2_ID"
			dataColumn = dataTable.Columns["USUARIO_DESBLOQUEO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_DESBLOQUEO2_ID = (decimal)row[dataColumn];
			// Column "USUARIO_DESBLOQUEO3_ID"
			dataColumn = dataTable.Columns["USUARIO_DESBLOQUEO3_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_DESBLOQUEO3_ID = (decimal)row[dataColumn];
			// Column "FECHA_DESBLOQUEO1"
			dataColumn = dataTable.Columns["FECHA_DESBLOQUEO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESBLOQUEO1 = (System.DateTime)row[dataColumn];
			// Column "FECHA_DESBLOQUEO2"
			dataColumn = dataTable.Columns["FECHA_DESBLOQUEO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESBLOQUEO2 = (System.DateTime)row[dataColumn];
			// Column "FECHA_DESBLOQUEO3"
			dataColumn = dataTable.Columns["FECHA_DESBLOQUEO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESBLOQUEO3 = (System.DateTime)row[dataColumn];
			// Column "DESBLOQUEADO"
			dataColumn = dataTable.Columns["DESBLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESBLOQUEADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PERSONAS_BLOQUEOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PERSONAS_BLOQUEOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_BLOQUEO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_BLOQUEO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO_MOTIVO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_DESBLOQUEO1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_DESBLOQUEO2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_DESBLOQUEO3_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_DESBLOQUEO1", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_DESBLOQUEO2", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_DESBLOQUEO3", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("DESBLOQUEADO", typeof(string));
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_BLOQUEO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_BLOQUEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TEXTO_MOTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_DESBLOQUEO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_DESBLOQUEO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_DESBLOQUEO3_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESBLOQUEO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DESBLOQUEO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DESBLOQUEO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESBLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PERSONAS_BLOQUEOSCollection_Base class
}  // End of namespace
