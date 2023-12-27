// <fileinfo name="CASOS_JUDICIALIZADOSCollection_Base.cs">
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
	/// The base class for <see cref="CASOS_JUDICIALIZADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CASOS_JUDICIALIZADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CASOS_JUDICIALIZADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string USUARIO_ENTRADA_IDColumnName = "USUARIO_ENTRADA_ID";
		public const string FECHA_ENTRADAColumnName = "FECHA_ENTRADA";
		public const string MOTIVO_ENTRADA_IDColumnName = "MOTIVO_ENTRADA_ID";
		public const string OBSERVACION_ENTRADAColumnName = "OBSERVACION_ENTRADA";
		public const string USUARIO_SALIDA_IDColumnName = "USUARIO_SALIDA_ID";
		public const string FECHA_SALIDAColumnName = "FECHA_SALIDA";
		public const string MOTIVO_SALIDA_IDColumnName = "MOTIVO_SALIDA_ID";
		public const string OBSERVACION_SALIDAColumnName = "OBSERVACION_SALIDA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CASOS_JUDICIALIZADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CASOS_JUDICIALIZADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CASOS_JUDICIALIZADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public virtual CASOS_JUDICIALIZADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CASOS_JUDICIALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CASOS_JUDICIALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CASOS_JUDICIALIZADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CASOS_JUDICIALIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CASOS_JUDICIALIZADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CASOS_JUDICIALIZADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public CASOS_JUDICIALIZADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public virtual CASOS_JUDICIALIZADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CASOS_JUDICIALIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CASOS_JUDICIALIZADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CASOS_JUDICIALIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CASOS_JUDICIALIZADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CASOS_JUDICIALIZADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects 
		/// by the <c>FK_CASOS_JUDIC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public virtual CASOS_JUDICIALIZADOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS_JUDIC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CASOS_JUDIC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects 
		/// by the <c>FK_CASOS_JUDIC_MOTIVO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="motivo_entrada_id">The <c>MOTIVO_ENTRADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public virtual CASOS_JUDICIALIZADOSRow[] GetByMOTIVO_ENTRADA_ID(decimal motivo_entrada_id)
		{
			return MapRecords(CreateGetByMOTIVO_ENTRADA_IDCommand(motivo_entrada_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS_JUDIC_MOTIVO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="motivo_entrada_id">The <c>MOTIVO_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOTIVO_ENTRADA_IDAsDataTable(decimal motivo_entrada_id)
		{
			return MapRecordsToDataTable(CreateGetByMOTIVO_ENTRADA_IDCommand(motivo_entrada_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CASOS_JUDIC_MOTIVO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="motivo_entrada_id">The <c>MOTIVO_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOTIVO_ENTRADA_IDCommand(decimal motivo_entrada_id)
		{
			string whereSql = "";
			whereSql += "MOTIVO_ENTRADA_ID=" + _db.CreateSqlParameterName("MOTIVO_ENTRADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MOTIVO_ENTRADA_ID", motivo_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects 
		/// by the <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public CASOS_JUDICIALIZADOSRow[] GetByMOTIVO_SALIDA_ID(decimal motivo_salida_id)
		{
			return GetByMOTIVO_SALIDA_ID(motivo_salida_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects 
		/// by the <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <param name="motivo_salida_idNull">true if the method ignores the motivo_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public virtual CASOS_JUDICIALIZADOSRow[] GetByMOTIVO_SALIDA_ID(decimal motivo_salida_id, bool motivo_salida_idNull)
		{
			return MapRecords(CreateGetByMOTIVO_SALIDA_IDCommand(motivo_salida_id, motivo_salida_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOTIVO_SALIDA_IDAsDataTable(decimal motivo_salida_id)
		{
			return GetByMOTIVO_SALIDA_IDAsDataTable(motivo_salida_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <param name="motivo_salida_idNull">true if the method ignores the motivo_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOTIVO_SALIDA_IDAsDataTable(decimal motivo_salida_id, bool motivo_salida_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMOTIVO_SALIDA_IDCommand(motivo_salida_id, motivo_salida_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <param name="motivo_salida_idNull">true if the method ignores the motivo_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOTIVO_SALIDA_IDCommand(decimal motivo_salida_id, bool motivo_salida_idNull)
		{
			string whereSql = "";
			if(motivo_salida_idNull)
				whereSql += "MOTIVO_SALIDA_ID IS NULL";
			else
				whereSql += "MOTIVO_SALIDA_ID=" + _db.CreateSqlParameterName("MOTIVO_SALIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!motivo_salida_idNull)
				AddParameter(cmd, "MOTIVO_SALIDA_ID", motivo_salida_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects 
		/// by the <c>FK_CASOS_JUDIC_USUARIO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="usuario_entrada_id">The <c>USUARIO_ENTRADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public virtual CASOS_JUDICIALIZADOSRow[] GetByUSUARIO_ENTRADA_ID(decimal usuario_entrada_id)
		{
			return MapRecords(CreateGetByUSUARIO_ENTRADA_IDCommand(usuario_entrada_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS_JUDIC_USUARIO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="usuario_entrada_id">The <c>USUARIO_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ENTRADA_IDAsDataTable(decimal usuario_entrada_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ENTRADA_IDCommand(usuario_entrada_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CASOS_JUDIC_USUARIO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="usuario_entrada_id">The <c>USUARIO_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ENTRADA_IDCommand(decimal usuario_entrada_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ENTRADA_ID=" + _db.CreateSqlParameterName("USUARIO_ENTRADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ENTRADA_ID", usuario_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects 
		/// by the <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public CASOS_JUDICIALIZADOSRow[] GetByUSUARIO_SALIDA_ID(decimal usuario_salida_id)
		{
			return GetByUSUARIO_SALIDA_ID(usuario_salida_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects 
		/// by the <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <param name="usuario_salida_idNull">true if the method ignores the usuario_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		public virtual CASOS_JUDICIALIZADOSRow[] GetByUSUARIO_SALIDA_ID(decimal usuario_salida_id, bool usuario_salida_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_SALIDA_IDCommand(usuario_salida_id, usuario_salida_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_SALIDA_IDAsDataTable(decimal usuario_salida_id)
		{
			return GetByUSUARIO_SALIDA_IDAsDataTable(usuario_salida_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <param name="usuario_salida_idNull">true if the method ignores the usuario_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_SALIDA_IDAsDataTable(decimal usuario_salida_id, bool usuario_salida_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_SALIDA_IDCommand(usuario_salida_id, usuario_salida_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <param name="usuario_salida_idNull">true if the method ignores the usuario_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_SALIDA_IDCommand(decimal usuario_salida_id, bool usuario_salida_idNull)
		{
			string whereSql = "";
			if(usuario_salida_idNull)
				whereSql += "USUARIO_SALIDA_ID IS NULL";
			else
				whereSql += "USUARIO_SALIDA_ID=" + _db.CreateSqlParameterName("USUARIO_SALIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_salida_idNull)
				AddParameter(cmd, "USUARIO_SALIDA_ID", usuario_salida_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CASOS_JUDICIALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CASOS_JUDICIALIZADOSRow"/> object to be inserted.</param>
		public virtual void Insert(CASOS_JUDICIALIZADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CASOS_JUDICIALIZADOS (" +
				"ID, " +
				"CASO_ID, " +
				"USUARIO_ENTRADA_ID, " +
				"FECHA_ENTRADA, " +
				"MOTIVO_ENTRADA_ID, " +
				"OBSERVACION_ENTRADA, " +
				"USUARIO_SALIDA_ID, " +
				"FECHA_SALIDA, " +
				"MOTIVO_SALIDA_ID, " +
				"OBSERVACION_SALIDA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ENTRADA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ENTRADA") + ", " +
				_db.CreateSqlParameterName("MOTIVO_ENTRADA_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_ENTRADA") + ", " +
				_db.CreateSqlParameterName("USUARIO_SALIDA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				_db.CreateSqlParameterName("MOTIVO_SALIDA_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_SALIDA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "USUARIO_ENTRADA_ID", value.USUARIO_ENTRADA_ID);
			AddParameter(cmd, "FECHA_ENTRADA", value.FECHA_ENTRADA);
			AddParameter(cmd, "MOTIVO_ENTRADA_ID", value.MOTIVO_ENTRADA_ID);
			AddParameter(cmd, "OBSERVACION_ENTRADA", value.OBSERVACION_ENTRADA);
			AddParameter(cmd, "USUARIO_SALIDA_ID",
				value.IsUSUARIO_SALIDA_IDNull ? DBNull.Value : (object)value.USUARIO_SALIDA_ID);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "MOTIVO_SALIDA_ID",
				value.IsMOTIVO_SALIDA_IDNull ? DBNull.Value : (object)value.MOTIVO_SALIDA_ID);
			AddParameter(cmd, "OBSERVACION_SALIDA", value.OBSERVACION_SALIDA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CASOS_JUDICIALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CASOS_JUDICIALIZADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CASOS_JUDICIALIZADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CASOS_JUDICIALIZADOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"USUARIO_ENTRADA_ID=" + _db.CreateSqlParameterName("USUARIO_ENTRADA_ID") + ", " +
				"FECHA_ENTRADA=" + _db.CreateSqlParameterName("FECHA_ENTRADA") + ", " +
				"MOTIVO_ENTRADA_ID=" + _db.CreateSqlParameterName("MOTIVO_ENTRADA_ID") + ", " +
				"OBSERVACION_ENTRADA=" + _db.CreateSqlParameterName("OBSERVACION_ENTRADA") + ", " +
				"USUARIO_SALIDA_ID=" + _db.CreateSqlParameterName("USUARIO_SALIDA_ID") + ", " +
				"FECHA_SALIDA=" + _db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				"MOTIVO_SALIDA_ID=" + _db.CreateSqlParameterName("MOTIVO_SALIDA_ID") + ", " +
				"OBSERVACION_SALIDA=" + _db.CreateSqlParameterName("OBSERVACION_SALIDA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "USUARIO_ENTRADA_ID", value.USUARIO_ENTRADA_ID);
			AddParameter(cmd, "FECHA_ENTRADA", value.FECHA_ENTRADA);
			AddParameter(cmd, "MOTIVO_ENTRADA_ID", value.MOTIVO_ENTRADA_ID);
			AddParameter(cmd, "OBSERVACION_ENTRADA", value.OBSERVACION_ENTRADA);
			AddParameter(cmd, "USUARIO_SALIDA_ID",
				value.IsUSUARIO_SALIDA_IDNull ? DBNull.Value : (object)value.USUARIO_SALIDA_ID);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "MOTIVO_SALIDA_ID",
				value.IsMOTIVO_SALIDA_IDNull ? DBNull.Value : (object)value.MOTIVO_SALIDA_ID);
			AddParameter(cmd, "OBSERVACION_SALIDA", value.OBSERVACION_SALIDA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CASOS_JUDICIALIZADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CASOS_JUDICIALIZADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CASOS_JUDICIALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CASOS_JUDICIALIZADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CASOS_JUDICIALIZADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CASOS_JUDICIALIZADOS</c> table using
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
		/// Deletes records from the <c>CASOS_JUDICIALIZADOS</c> table using the 
		/// <c>FK_CASOS_JUDIC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CASOS_JUDIC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CASOS_JUDICIALIZADOS</c> table using the 
		/// <c>FK_CASOS_JUDIC_MOTIVO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="motivo_entrada_id">The <c>MOTIVO_ENTRADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOTIVO_ENTRADA_ID(decimal motivo_entrada_id)
		{
			return CreateDeleteByMOTIVO_ENTRADA_IDCommand(motivo_entrada_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CASOS_JUDIC_MOTIVO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="motivo_entrada_id">The <c>MOTIVO_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOTIVO_ENTRADA_IDCommand(decimal motivo_entrada_id)
		{
			string whereSql = "";
			whereSql += "MOTIVO_ENTRADA_ID=" + _db.CreateSqlParameterName("MOTIVO_ENTRADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MOTIVO_ENTRADA_ID", motivo_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CASOS_JUDICIALIZADOS</c> table using the 
		/// <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOTIVO_SALIDA_ID(decimal motivo_salida_id)
		{
			return DeleteByMOTIVO_SALIDA_ID(motivo_salida_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CASOS_JUDICIALIZADOS</c> table using the 
		/// <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <param name="motivo_salida_idNull">true if the method ignores the motivo_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOTIVO_SALIDA_ID(decimal motivo_salida_id, bool motivo_salida_idNull)
		{
			return CreateDeleteByMOTIVO_SALIDA_IDCommand(motivo_salida_id, motivo_salida_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CASOS_JUDIC_MOTIVO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="motivo_salida_id">The <c>MOTIVO_SALIDA_ID</c> column value.</param>
		/// <param name="motivo_salida_idNull">true if the method ignores the motivo_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOTIVO_SALIDA_IDCommand(decimal motivo_salida_id, bool motivo_salida_idNull)
		{
			string whereSql = "";
			if(motivo_salida_idNull)
				whereSql += "MOTIVO_SALIDA_ID IS NULL";
			else
				whereSql += "MOTIVO_SALIDA_ID=" + _db.CreateSqlParameterName("MOTIVO_SALIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!motivo_salida_idNull)
				AddParameter(cmd, "MOTIVO_SALIDA_ID", motivo_salida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CASOS_JUDICIALIZADOS</c> table using the 
		/// <c>FK_CASOS_JUDIC_USUARIO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="usuario_entrada_id">The <c>USUARIO_ENTRADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ENTRADA_ID(decimal usuario_entrada_id)
		{
			return CreateDeleteByUSUARIO_ENTRADA_IDCommand(usuario_entrada_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CASOS_JUDIC_USUARIO_ENTRADA</c> foreign key.
		/// </summary>
		/// <param name="usuario_entrada_id">The <c>USUARIO_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ENTRADA_IDCommand(decimal usuario_entrada_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ENTRADA_ID=" + _db.CreateSqlParameterName("USUARIO_ENTRADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ENTRADA_ID", usuario_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CASOS_JUDICIALIZADOS</c> table using the 
		/// <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_SALIDA_ID(decimal usuario_salida_id)
		{
			return DeleteByUSUARIO_SALIDA_ID(usuario_salida_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CASOS_JUDICIALIZADOS</c> table using the 
		/// <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <param name="usuario_salida_idNull">true if the method ignores the usuario_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_SALIDA_ID(decimal usuario_salida_id, bool usuario_salida_idNull)
		{
			return CreateDeleteByUSUARIO_SALIDA_IDCommand(usuario_salida_id, usuario_salida_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CASOS_JUDIC_USUARIO_SALIDA</c> foreign key.
		/// </summary>
		/// <param name="usuario_salida_id">The <c>USUARIO_SALIDA_ID</c> column value.</param>
		/// <param name="usuario_salida_idNull">true if the method ignores the usuario_salida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_SALIDA_IDCommand(decimal usuario_salida_id, bool usuario_salida_idNull)
		{
			string whereSql = "";
			if(usuario_salida_idNull)
				whereSql += "USUARIO_SALIDA_ID IS NULL";
			else
				whereSql += "USUARIO_SALIDA_ID=" + _db.CreateSqlParameterName("USUARIO_SALIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_salida_idNull)
				AddParameter(cmd, "USUARIO_SALIDA_ID", usuario_salida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CASOS_JUDICIALIZADOS</c> records that match the specified criteria.
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
		/// to delete <c>CASOS_JUDICIALIZADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CASOS_JUDICIALIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CASOS_JUDICIALIZADOS</c> table.
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
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		protected CASOS_JUDICIALIZADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		protected CASOS_JUDICIALIZADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CASOS_JUDICIALIZADOSRow"/> objects.</returns>
		protected virtual CASOS_JUDICIALIZADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int usuario_entrada_idColumnIndex = reader.GetOrdinal("USUARIO_ENTRADA_ID");
			int fecha_entradaColumnIndex = reader.GetOrdinal("FECHA_ENTRADA");
			int motivo_entrada_idColumnIndex = reader.GetOrdinal("MOTIVO_ENTRADA_ID");
			int observacion_entradaColumnIndex = reader.GetOrdinal("OBSERVACION_ENTRADA");
			int usuario_salida_idColumnIndex = reader.GetOrdinal("USUARIO_SALIDA_ID");
			int fecha_salidaColumnIndex = reader.GetOrdinal("FECHA_SALIDA");
			int motivo_salida_idColumnIndex = reader.GetOrdinal("MOTIVO_SALIDA_ID");
			int observacion_salidaColumnIndex = reader.GetOrdinal("OBSERVACION_SALIDA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CASOS_JUDICIALIZADOSRow record = new CASOS_JUDICIALIZADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.USUARIO_ENTRADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_entrada_idColumnIndex)), 9);
					record.FECHA_ENTRADA = Convert.ToDateTime(reader.GetValue(fecha_entradaColumnIndex));
					record.MOTIVO_ENTRADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(motivo_entrada_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_entradaColumnIndex))
						record.OBSERVACION_ENTRADA = Convert.ToString(reader.GetValue(observacion_entradaColumnIndex));
					if(!reader.IsDBNull(usuario_salida_idColumnIndex))
						record.USUARIO_SALIDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_salida_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_salidaColumnIndex))
						record.FECHA_SALIDA = Convert.ToDateTime(reader.GetValue(fecha_salidaColumnIndex));
					if(!reader.IsDBNull(motivo_salida_idColumnIndex))
						record.MOTIVO_SALIDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(motivo_salida_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_salidaColumnIndex))
						record.OBSERVACION_SALIDA = Convert.ToString(reader.GetValue(observacion_salidaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CASOS_JUDICIALIZADOSRow[])(recordList.ToArray(typeof(CASOS_JUDICIALIZADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CASOS_JUDICIALIZADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CASOS_JUDICIALIZADOSRow"/> object.</returns>
		protected virtual CASOS_JUDICIALIZADOSRow MapRow(DataRow row)
		{
			CASOS_JUDICIALIZADOSRow mappedObject = new CASOS_JUDICIALIZADOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ENTRADA_ID"
			dataColumn = dataTable.Columns["USUARIO_ENTRADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ENTRADA_ID = (decimal)row[dataColumn];
			// Column "FECHA_ENTRADA"
			dataColumn = dataTable.Columns["FECHA_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTRADA = (System.DateTime)row[dataColumn];
			// Column "MOTIVO_ENTRADA_ID"
			dataColumn = dataTable.Columns["MOTIVO_ENTRADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_ENTRADA_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION_ENTRADA"
			dataColumn = dataTable.Columns["OBSERVACION_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_ENTRADA = (string)row[dataColumn];
			// Column "USUARIO_SALIDA_ID"
			dataColumn = dataTable.Columns["USUARIO_SALIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_SALIDA_ID = (decimal)row[dataColumn];
			// Column "FECHA_SALIDA"
			dataColumn = dataTable.Columns["FECHA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA = (System.DateTime)row[dataColumn];
			// Column "MOTIVO_SALIDA_ID"
			dataColumn = dataTable.Columns["MOTIVO_SALIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_SALIDA_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION_SALIDA"
			dataColumn = dataTable.Columns["OBSERVACION_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_SALIDA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CASOS_JUDICIALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CASOS_JUDICIALIZADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ENTRADA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ENTRADA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MOTIVO_ENTRADA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION_ENTRADA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("USUARIO_SALIDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("MOTIVO_SALIDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION_SALIDA", typeof(string));
			dataColumn.MaxLength = 300;
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ENTRADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MOTIVO_ENTRADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_SALIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MOTIVO_SALIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CASOS_JUDICIALIZADOSCollection_Base class
}  // End of namespace
