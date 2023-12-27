// <fileinfo name="NOMINA_CONTENEDORESCollection_Base.cs">
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
	/// The base class for <see cref="NOMINA_CONTENEDORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="NOMINA_CONTENEDORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOMINA_CONTENEDORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string BOOKINGColumnName = "BOOKING";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string USUARIO_MODIFICACION_IDColumnName = "USUARIO_MODIFICACION_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TIPO_NOMINAColumnName = "TIPO_NOMINA";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENEDORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public NOMINA_CONTENEDORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>NOMINA_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>NOMINA_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>NOMINA_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="NOMINA_CONTENEDORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="NOMINA_CONTENEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public NOMINA_CONTENEDORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			NOMINA_CONTENEDORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public NOMINA_CONTENEDORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects that 
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.NOMINA_CONTENEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="NOMINA_CONTENEDORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="NOMINA_CONTENEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual NOMINA_CONTENEDORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			NOMINA_CONTENEDORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public NOMINA_CONTENEDORESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
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
		/// return records by the <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
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
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public NOMINA_CONTENEDORESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return MapRecords(CreateGetByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_DEVOLUCION_IDAsDataTable(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_IDAsDataTable(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPUERTO_DEVOLUCION_IDAsDataTable(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPUERTO_DEVOLUCION_IDCommand(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			string whereSql = "";
			if(puerto_devolucion_idNull)
				whereSql += "PUERTO_DEVOLUCION_ID IS NULL";
			else
				whereSql += "PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!puerto_devolucion_idNull)
				AddParameter(cmd, "PUERTO_DEVOLUCION_ID", puerto_devolucion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public NOMINA_CONTENEDORESRow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return GetByUSUARIO_CREADOR_ID(usuario_creador_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORESRow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id)
		{
			return GetByUSUARIO_CREADOR_IDAsDataTable(usuario_creador_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			string whereSql = "";
			if(usuario_creador_idNull)
				whereSql += "USUARIO_CREADOR_ID IS NULL";
			else
				whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_creador_idNull)
				AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public NOMINA_CONTENEDORESRow[] GetByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return GetByUSUARIO_MODIFICACION_ID(usuario_modificacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORESRow"/> objects 
		/// by the <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORESRow[] GetByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id, usuario_modificacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_MODIFICACION_IDAsDataTable(decimal usuario_modificacion_id)
		{
			return GetByUSUARIO_MODIFICACION_IDAsDataTable(usuario_modificacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_MODIFICACION_IDAsDataTable(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id, usuario_modificacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			string whereSql = "";
			if(usuario_modificacion_idNull)
				whereSql += "USUARIO_MODIFICACION_ID IS NULL";
			else
				whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_modificacion_idNull)
				AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>NOMINA_CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOMINA_CONTENEDORESRow"/> object to be inserted.</param>
		public virtual void Insert(NOMINA_CONTENEDORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.NOMINA_CONTENEDORES (" +
				"ID, " +
				"BOOKING, " +
				"PERSONA_ID, " +
				"USUARIO_CREADOR_ID, " +
				"USUARIO_MODIFICACION_ID, " +
				"OBSERVACION, " +
				"TIPO_NOMINA, " +
				"PUERTO_DEVOLUCION_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("BOOKING") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TIPO_NOMINA") + ", " +
				_db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID",
				value.IsUSUARIO_CREADOR_IDNull ? DBNull.Value : (object)value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID",
				value.IsUSUARIO_MODIFICACION_IDNull ? DBNull.Value : (object)value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TIPO_NOMINA", value.TIPO_NOMINA);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>NOMINA_CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOMINA_CONTENEDORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(NOMINA_CONTENEDORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.NOMINA_CONTENEDORES SET " +
				"BOOKING=" + _db.CreateSqlParameterName("BOOKING") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				"USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TIPO_NOMINA=" + _db.CreateSqlParameterName("TIPO_NOMINA") + ", " +
				"PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "USUARIO_CREADOR_ID",
				value.IsUSUARIO_CREADOR_IDNull ? DBNull.Value : (object)value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID",
				value.IsUSUARIO_MODIFICACION_IDNull ? DBNull.Value : (object)value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TIPO_NOMINA", value.TIPO_NOMINA);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>NOMINA_CONTENEDORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>NOMINA_CONTENEDORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>NOMINA_CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="NOMINA_CONTENEDORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(NOMINA_CONTENEDORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>NOMINA_CONTENEDORES</c> table using
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
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
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
		/// delete records using the <c>FK_NOMINA_CONT_PERSONA_ID</c> foreign key.
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
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return DeleteByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return CreateDeleteByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOMINA_CONT_PTO_DVO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPUERTO_DEVOLUCION_IDCommand(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			string whereSql = "";
			if(puerto_devolucion_idNull)
				whereSql += "PUERTO_DEVOLUCION_ID IS NULL";
			else
				whereSql += "PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!puerto_devolucion_idNull)
				AddParameter(cmd, "PUERTO_DEVOLUCION_ID", puerto_devolucion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return DeleteByUSUARIO_CREADOR_ID(usuario_creador_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			return CreateDeleteByUSUARIO_CREADOR_IDCommand(usuario_creador_id, usuario_creador_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOMINA_CONT_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <param name="usuario_creador_idNull">true if the method ignores the usuario_creador_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id, bool usuario_creador_idNull)
		{
			string whereSql = "";
			if(usuario_creador_idNull)
				whereSql += "USUARIO_CREADOR_ID IS NULL";
			else
				whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_creador_idNull)
				AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return DeleteByUSUARIO_MODIFICACION_ID(usuario_modificacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>NOMINA_CONTENEDORES</c> table using the 
		/// <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			return CreateDeleteByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id, usuario_modificacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_NOMINA_CONT_USU_MODIF_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <param name="usuario_modificacion_idNull">true if the method ignores the usuario_modificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id, bool usuario_modificacion_idNull)
		{
			string whereSql = "";
			if(usuario_modificacion_idNull)
				whereSql += "USUARIO_MODIFICACION_ID IS NULL";
			else
				whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_modificacion_idNull)
				AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>NOMINA_CONTENEDORES</c> records that match the specified criteria.
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
		/// to delete <c>NOMINA_CONTENEDORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.NOMINA_CONTENEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>NOMINA_CONTENEDORES</c> table.
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		protected NOMINA_CONTENEDORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		protected NOMINA_CONTENEDORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORESRow"/> objects.</returns>
		protected virtual NOMINA_CONTENEDORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int usuario_modificacion_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int tipo_nominaColumnIndex = reader.GetOrdinal("TIPO_NOMINA");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					NOMINA_CONTENEDORESRow record = new NOMINA_CONTENEDORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creador_idColumnIndex))
						record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_modificacion_idColumnIndex))
						record.USUARIO_MODIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(tipo_nominaColumnIndex))
						record.TIPO_NOMINA = Convert.ToString(reader.GetValue(tipo_nominaColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NOMINA_CONTENEDORESRow[])(recordList.ToArray(typeof(NOMINA_CONTENEDORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="NOMINA_CONTENEDORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="NOMINA_CONTENEDORESRow"/> object.</returns>
		protected virtual NOMINA_CONTENEDORESRow MapRow(DataRow row)
		{
			NOMINA_CONTENEDORESRow mappedObject = new NOMINA_CONTENEDORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "USUARIO_MODIFICACION_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TIPO_NOMINA"
			dataColumn = dataTable.Columns["TIPO_NOMINA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_NOMINA = (string)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>NOMINA_CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "NOMINA_CONTENEDORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("TIPO_NOMINA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ID", typeof(decimal));
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

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_MODIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_NOMINA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of NOMINA_CONTENEDORESCollection_Base class
}  // End of namespace
