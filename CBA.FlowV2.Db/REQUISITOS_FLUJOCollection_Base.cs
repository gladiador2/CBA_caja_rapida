// <fileinfo name="REQUISITOS_FLUJOCollection_Base.cs">
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
	/// The base class for <see cref="REQUISITOS_FLUJOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REQUISITOS_FLUJOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REQUISITOS_FLUJOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_REQUISITO_FLUJO_IDColumnName = "TIPO_REQUISITO_FLUJO_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string ESTADO_IDColumnName = "ESTADO_ID";
		public const string TITULOColumnName = "TITULO";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string OBLIGATORIOColumnName = "OBLIGATORIO";
		public const string ROL_VERColumnName = "ROL_VER";
		public const string ROL_EDITARColumnName = "ROL_EDITAR";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REQUISITOS_FLUJOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REQUISITOS_FLUJOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REQUISITOS_FLUJO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REQUISITOS_FLUJO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REQUISITOS_FLUJO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REQUISITOS_FLUJORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REQUISITOS_FLUJORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REQUISITOS_FLUJORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REQUISITOS_FLUJORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public REQUISITOS_FLUJORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects that 
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REQUISITOS_FLUJO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REQUISITOS_FLUJORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REQUISITOS_FLUJORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REQUISITOS_FLUJORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REQUISITOS_FLUJORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetByESTADO_ID(string estado_id)
		{
			return MapRecords(CreateGetByESTADO_IDCommand(estado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_IDAsDataTable(string estado_id)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_IDCommand(estado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_IDCommand(string estado_id)
		{
			string whereSql = "";
			whereSql += "ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ESTADO_ID", estado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public REQUISITOS_FLUJORow[] GetByROL_EDITAR(decimal rol_editar)
		{
			return GetByROL_EDITAR(rol_editar, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <param name="rol_editarNull">true if the method ignores the rol_editar
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetByROL_EDITAR(decimal rol_editar, bool rol_editarNull)
		{
			return MapRecords(CreateGetByROL_EDITARCommand(rol_editar, rol_editarNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_EDITARAsDataTable(decimal rol_editar)
		{
			return GetByROL_EDITARAsDataTable(rol_editar, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <param name="rol_editarNull">true if the method ignores the rol_editar
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_EDITARAsDataTable(decimal rol_editar, bool rol_editarNull)
		{
			return MapRecordsToDataTable(CreateGetByROL_EDITARCommand(rol_editar, rol_editarNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <param name="rol_editarNull">true if the method ignores the rol_editar
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_EDITARCommand(decimal rol_editar, bool rol_editarNull)
		{
			string whereSql = "";
			if(rol_editarNull)
				whereSql += "ROL_EDITAR IS NULL";
			else
				whereSql += "ROL_EDITAR=" + _db.CreateSqlParameterName("ROL_EDITAR");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_editarNull)
				AddParameter(cmd, "ROL_EDITAR", rol_editar);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public REQUISITOS_FLUJORow[] GetByROL_VER(decimal rol_ver)
		{
			return GetByROL_VER(rol_ver, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <param name="rol_verNull">true if the method ignores the rol_ver
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetByROL_VER(decimal rol_ver, bool rol_verNull)
		{
			return MapRecords(CreateGetByROL_VERCommand(rol_ver, rol_verNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_VERAsDataTable(decimal rol_ver)
		{
			return GetByROL_VERAsDataTable(rol_ver, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <param name="rol_verNull">true if the method ignores the rol_ver
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_VERAsDataTable(decimal rol_ver, bool rol_verNull)
		{
			return MapRecordsToDataTable(CreateGetByROL_VERCommand(rol_ver, rol_verNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <param name="rol_verNull">true if the method ignores the rol_ver
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_VERCommand(decimal rol_ver, bool rol_verNull)
		{
			string whereSql = "";
			if(rol_verNull)
				whereSql += "ROL_VER IS NULL";
			else
				whereSql += "ROL_VER=" + _db.CreateSqlParameterName("ROL_VER");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_verNull)
				AddParameter(cmd, "ROL_VER", rol_ver);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REQUISITOS_FLUJORow"/> objects 
		/// by the <c>FK_REQUISITOS_FLUJO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_requisito_flujo_id">The <c>TIPO_REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		public virtual REQUISITOS_FLUJORow[] GetByTIPO_REQUISITO_FLUJO_ID(string tipo_requisito_flujo_id)
		{
			return MapRecords(CreateGetByTIPO_REQUISITO_FLUJO_IDCommand(tipo_requisito_flujo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REQUISITOS_FLUJO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_requisito_flujo_id">The <c>TIPO_REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_REQUISITO_FLUJO_IDAsDataTable(string tipo_requisito_flujo_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_REQUISITO_FLUJO_IDCommand(tipo_requisito_flujo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REQUISITOS_FLUJO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_requisito_flujo_id">The <c>TIPO_REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_REQUISITO_FLUJO_IDCommand(string tipo_requisito_flujo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_REQUISITO_FLUJO_ID=" + _db.CreateSqlParameterName("TIPO_REQUISITO_FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_REQUISITO_FLUJO_ID", tipo_requisito_flujo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>REQUISITOS_FLUJO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REQUISITOS_FLUJORow"/> object to be inserted.</param>
		public virtual void Insert(REQUISITOS_FLUJORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REQUISITOS_FLUJO (" +
				"ID, " +
				"TIPO_REQUISITO_FLUJO_ID, " +
				"FLUJO_ID, " +
				"ESTADO_ID, " +
				"TITULO, " +
				"DESCRIPCION, " +
				"ENTIDAD_ID, " +
				"ESTADO, " +
				"OBLIGATORIO, " +
				"ROL_VER, " +
				"ROL_EDITAR" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_REQUISITO_FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("TITULO") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("OBLIGATORIO") + ", " +
				_db.CreateSqlParameterName("ROL_VER") + ", " +
				_db.CreateSqlParameterName("ROL_EDITAR") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_REQUISITO_FLUJO_ID", value.TIPO_REQUISITO_FLUJO_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "ESTADO_ID", value.ESTADO_ID);
			AddParameter(cmd, "TITULO", value.TITULO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "OBLIGATORIO", value.OBLIGATORIO);
			AddParameter(cmd, "ROL_VER",
				value.IsROL_VERNull ? DBNull.Value : (object)value.ROL_VER);
			AddParameter(cmd, "ROL_EDITAR",
				value.IsROL_EDITARNull ? DBNull.Value : (object)value.ROL_EDITAR);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REQUISITOS_FLUJO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REQUISITOS_FLUJORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REQUISITOS_FLUJORow value)
		{
			
			string sqlStr = "UPDATE TRC.REQUISITOS_FLUJO SET " +
				"TIPO_REQUISITO_FLUJO_ID=" + _db.CreateSqlParameterName("TIPO_REQUISITO_FLUJO_ID") + ", " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + ", " +
				"ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID") + ", " +
				"TITULO=" + _db.CreateSqlParameterName("TITULO") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"OBLIGATORIO=" + _db.CreateSqlParameterName("OBLIGATORIO") + ", " +
				"ROL_VER=" + _db.CreateSqlParameterName("ROL_VER") + ", " +
				"ROL_EDITAR=" + _db.CreateSqlParameterName("ROL_EDITAR") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_REQUISITO_FLUJO_ID", value.TIPO_REQUISITO_FLUJO_ID);
			AddParameter(cmd, "FLUJO_ID", value.FLUJO_ID);
			AddParameter(cmd, "ESTADO_ID", value.ESTADO_ID);
			AddParameter(cmd, "TITULO", value.TITULO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "OBLIGATORIO", value.OBLIGATORIO);
			AddParameter(cmd, "ROL_VER",
				value.IsROL_VERNull ? DBNull.Value : (object)value.ROL_VER);
			AddParameter(cmd, "ROL_EDITAR",
				value.IsROL_EDITARNull ? DBNull.Value : (object)value.ROL_EDITAR);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REQUISITOS_FLUJO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REQUISITOS_FLUJO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REQUISITOS_FLUJO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REQUISITOS_FLUJORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REQUISITOS_FLUJORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REQUISITOS_FLUJO</c> table using
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
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_ID(string estado_id)
		{
			return CreateDeleteByESTADO_IDCommand(estado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="estado_id">The <c>ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_IDCommand(string estado_id)
		{
			string whereSql = "";
			whereSql += "ESTADO_ID=" + _db.CreateSqlParameterName("ESTADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ESTADO_ID", estado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id)
		{
			string whereSql = "";
			whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_EDITAR(decimal rol_editar)
		{
			return DeleteByROL_EDITAR(rol_editar, false);
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <param name="rol_editarNull">true if the method ignores the rol_editar
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_EDITAR(decimal rol_editar, bool rol_editarNull)
		{
			return CreateDeleteByROL_EDITARCommand(rol_editar, rol_editarNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_ROL_EDITAR</c> foreign key.
		/// </summary>
		/// <param name="rol_editar">The <c>ROL_EDITAR</c> column value.</param>
		/// <param name="rol_editarNull">true if the method ignores the rol_editar
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_EDITARCommand(decimal rol_editar, bool rol_editarNull)
		{
			string whereSql = "";
			if(rol_editarNull)
				whereSql += "ROL_EDITAR IS NULL";
			else
				whereSql += "ROL_EDITAR=" + _db.CreateSqlParameterName("ROL_EDITAR");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_editarNull)
				AddParameter(cmd, "ROL_EDITAR", rol_editar);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_VER(decimal rol_ver)
		{
			return DeleteByROL_VER(rol_ver, false);
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <param name="rol_verNull">true if the method ignores the rol_ver
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_VER(decimal rol_ver, bool rol_verNull)
		{
			return CreateDeleteByROL_VERCommand(rol_ver, rol_verNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_ROL_VER</c> foreign key.
		/// </summary>
		/// <param name="rol_ver">The <c>ROL_VER</c> column value.</param>
		/// <param name="rol_verNull">true if the method ignores the rol_ver
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_VERCommand(decimal rol_ver, bool rol_verNull)
		{
			string whereSql = "";
			if(rol_verNull)
				whereSql += "ROL_VER IS NULL";
			else
				whereSql += "ROL_VER=" + _db.CreateSqlParameterName("ROL_VER");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_verNull)
				AddParameter(cmd, "ROL_VER", rol_ver);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REQUISITOS_FLUJO</c> table using the 
		/// <c>FK_REQUISITOS_FLUJO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_requisito_flujo_id">The <c>TIPO_REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_REQUISITO_FLUJO_ID(string tipo_requisito_flujo_id)
		{
			return CreateDeleteByTIPO_REQUISITO_FLUJO_IDCommand(tipo_requisito_flujo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REQUISITOS_FLUJO_TIPO</c> foreign key.
		/// </summary>
		/// <param name="tipo_requisito_flujo_id">The <c>TIPO_REQUISITO_FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_REQUISITO_FLUJO_IDCommand(string tipo_requisito_flujo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_REQUISITO_FLUJO_ID=" + _db.CreateSqlParameterName("TIPO_REQUISITO_FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_REQUISITO_FLUJO_ID", tipo_requisito_flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>REQUISITOS_FLUJO</c> records that match the specified criteria.
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
		/// to delete <c>REQUISITOS_FLUJO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REQUISITOS_FLUJO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REQUISITOS_FLUJO</c> table.
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		protected REQUISITOS_FLUJORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		protected REQUISITOS_FLUJORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REQUISITOS_FLUJORow"/> objects.</returns>
		protected virtual REQUISITOS_FLUJORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_requisito_flujo_idColumnIndex = reader.GetOrdinal("TIPO_REQUISITO_FLUJO_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int estado_idColumnIndex = reader.GetOrdinal("ESTADO_ID");
			int tituloColumnIndex = reader.GetOrdinal("TITULO");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int obligatorioColumnIndex = reader.GetOrdinal("OBLIGATORIO");
			int rol_verColumnIndex = reader.GetOrdinal("ROL_VER");
			int rol_editarColumnIndex = reader.GetOrdinal("ROL_EDITAR");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REQUISITOS_FLUJORow record = new REQUISITOS_FLUJORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_REQUISITO_FLUJO_ID = Convert.ToString(reader.GetValue(tipo_requisito_flujo_idColumnIndex));
					record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					record.ESTADO_ID = Convert.ToString(reader.GetValue(estado_idColumnIndex));
					record.TITULO = Convert.ToString(reader.GetValue(tituloColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(obligatorioColumnIndex))
						record.OBLIGATORIO = Convert.ToString(reader.GetValue(obligatorioColumnIndex));
					if(!reader.IsDBNull(rol_verColumnIndex))
						record.ROL_VER = Math.Round(Convert.ToDecimal(reader.GetValue(rol_verColumnIndex)), 9);
					if(!reader.IsDBNull(rol_editarColumnIndex))
						record.ROL_EDITAR = Math.Round(Convert.ToDecimal(reader.GetValue(rol_editarColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REQUISITOS_FLUJORow[])(recordList.ToArray(typeof(REQUISITOS_FLUJORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REQUISITOS_FLUJORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REQUISITOS_FLUJORow"/> object.</returns>
		protected virtual REQUISITOS_FLUJORow MapRow(DataRow row)
		{
			REQUISITOS_FLUJORow mappedObject = new REQUISITOS_FLUJORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_REQUISITO_FLUJO_ID"
			dataColumn = dataTable.Columns["TIPO_REQUISITO_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_REQUISITO_FLUJO_ID = (string)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_ID"
			dataColumn = dataTable.Columns["ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ID = (string)row[dataColumn];
			// Column "TITULO"
			dataColumn = dataTable.Columns["TITULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULO = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "OBLIGATORIO"
			dataColumn = dataTable.Columns["OBLIGATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBLIGATORIO = (string)row[dataColumn];
			// Column "ROL_VER"
			dataColumn = dataTable.Columns["ROL_VER"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_VER = (decimal)row[dataColumn];
			// Column "ROL_EDITAR"
			dataColumn = dataTable.Columns["ROL_EDITAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_EDITAR = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REQUISITOS_FLUJO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REQUISITOS_FLUJO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_REQUISITO_FLUJO_ID", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TITULO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBLIGATORIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ROL_VER", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ROL_EDITAR", typeof(decimal));
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

				case "TIPO_REQUISITO_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TITULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBLIGATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ROL_VER":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_EDITAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REQUISITOS_FLUJOCollection_Base class
}  // End of namespace
