// <fileinfo name="ALARMASCollection_Base.cs">
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
	/// The base class for <see cref="ALARMASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ALARMASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ALARMASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string TIPO_ALARMA_IDColumnName = "TIPO_ALARMA_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string ROL_IDColumnName = "ROL_ID";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string LOG_CAMPO_IDColumnName = "LOG_CAMPO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string FLUJO_ESTADO_IDColumnName = "FLUJO_ESTADO_ID";
		public const string TIPO_DATOColumnName = "TIPO_DATO";
		public const string VALOR_INFERIORColumnName = "VALOR_INFERIOR";
		public const string VALOR_SUPERIORColumnName = "VALOR_SUPERIOR";
		public const string TIPO_RANGOColumnName = "TIPO_RANGO";
		public const string MAILColumnName = "MAIL";
		public const string EXISTENCIA_MAYOR_CEROColumnName = "EXISTENCIA_MAYOR_CERO";
		public const string TIPO_ENVIO_PARA_USUARIOColumnName = "TIPO_ENVIO_PARA_USUARIO";
		public const string RESUMIDOColumnName = "RESUMIDO";
		public const string SQLColumnName = "SQL";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ALARMASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ALARMASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ALARMAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ALARMAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ALARMAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ALARMASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ALARMASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ALARMASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ALARMASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public ALARMASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects that 
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
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ALARMAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ALARMASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ALARMASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ALARMASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ALARMASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public ALARMASRow[] GetByLOG_CAMPO_ID(decimal log_campo_id)
		{
			return GetByLOG_CAMPO_ID(log_campo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetByLOG_CAMPO_ID(decimal log_campo_id, bool log_campo_idNull)
		{
			return MapRecords(CreateGetByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOG_CAMPO_IDAsDataTable(decimal log_campo_id)
		{
			return GetByLOG_CAMPO_IDAsDataTable(log_campo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOG_CAMPO_IDAsDataTable(decimal log_campo_id, bool log_campo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOG_CAMPO_IDCommand(decimal log_campo_id, bool log_campo_idNull)
		{
			string whereSql = "";
			if(log_campo_idNull)
				whereSql += "LOG_CAMPO_ID IS NULL";
			else
				whereSql += "LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!log_campo_idNull)
				AddParameter(cmd, "LOG_CAMPO_ID", log_campo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ALARMAS_ENTIDAD</c> foreign key.
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
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="flujo_estado_id">The <c>FLUJO_ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetByFLUJO_ESTADO_ID(string flujo_estado_id)
		{
			return MapRecords(CreateGetByFLUJO_ESTADO_IDCommand(flujo_estado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="flujo_estado_id">The <c>FLUJO_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_ESTADO_IDAsDataTable(string flujo_estado_id)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_ESTADO_IDCommand(flujo_estado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ALARMAS_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="flujo_estado_id">The <c>FLUJO_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_ESTADO_IDCommand(string flujo_estado_id)
		{
			string whereSql = "";
			if(null == flujo_estado_id)
				whereSql += "FLUJO_ESTADO_ID IS NULL";
			else
				whereSql += "FLUJO_ESTADO_ID=" + _db.CreateSqlParameterName("FLUJO_ESTADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != flujo_estado_id)
				AddParameter(cmd, "FLUJO_ESTADO_ID", flujo_estado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public ALARMASRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return GetByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return GetByFLUJO_IDAsDataTable(flujo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public ALARMASRow[] GetByROL_ID(decimal rol_id)
		{
			return GetByROL_ID(rol_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetByROL_ID(decimal rol_id, bool rol_idNull)
		{
			return MapRecords(CreateGetByROL_IDCommand(rol_id, rol_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_IDAsDataTable(decimal rol_id)
		{
			return GetByROL_IDAsDataTable(rol_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_IDAsDataTable(decimal rol_id, bool rol_idNull)
		{
			return MapRecordsToDataTable(CreateGetByROL_IDCommand(rol_id, rol_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_IDCommand(decimal rol_id, bool rol_idNull)
		{
			string whereSql = "";
			if(rol_idNull)
				whereSql += "ROL_ID IS NULL";
			else
				whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_idNull)
				AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public ALARMASRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMASRow"/> objects 
		/// by the <c>FK_ALARMAS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		public virtual ALARMASRow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ALARMAS_USR</c> foreign key.
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
		/// return records by the <c>FK_ALARMAS_USR</c> foreign key.
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
		/// Adds a new record into the <c>ALARMAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ALARMASRow"/> object to be inserted.</param>
		public virtual void Insert(ALARMASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ALARMAS (" +
				"ID, " +
				"ENTIDAD_ID, " +
				"TIPO_ALARMA_ID, " +
				"NOMBRE, " +
				"DESCRIPCION, " +
				"USUARIO_ID, " +
				"ROL_ID, " +
				"FLUJO_ID, " +
				"LOG_CAMPO_ID, " +
				"ESTADO, " +
				"FLUJO_ESTADO_ID, " +
				"TIPO_DATO, " +
				"VALOR_INFERIOR, " +
				"VALOR_SUPERIOR, " +
				"TIPO_RANGO, " +
				"MAIL, " +
				"EXISTENCIA_MAYOR_CERO, " +
				"TIPO_ENVIO_PARA_USUARIO, " +
				"RESUMIDO, " +
				"SQL" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_ALARMA_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("ROL_ID") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ", " +
				_db.CreateSqlParameterName("LOG_CAMPO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("FLUJO_ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_DATO") + ", " +
				_db.CreateSqlParameterName("VALOR_INFERIOR") + ", " +
				_db.CreateSqlParameterName("VALOR_SUPERIOR") + ", " +
				_db.CreateSqlParameterName("TIPO_RANGO") + ", " +
				_db.CreateSqlParameterName("MAIL") + ", " +
				_db.CreateSqlParameterName("EXISTENCIA_MAYOR_CERO") + ", " +
				_db.CreateSqlParameterName("TIPO_ENVIO_PARA_USUARIO") + ", " +
				_db.CreateSqlParameterName("RESUMIDO") + ", " +
				_db.CreateSqlParameterName("SQL") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "TIPO_ALARMA_ID", value.TIPO_ALARMA_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "ROL_ID",
				value.IsROL_IDNull ? DBNull.Value : (object)value.ROL_ID);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			AddParameter(cmd, "LOG_CAMPO_ID",
				value.IsLOG_CAMPO_IDNull ? DBNull.Value : (object)value.LOG_CAMPO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FLUJO_ESTADO_ID", value.FLUJO_ESTADO_ID);
			AddParameter(cmd, "TIPO_DATO",
				value.IsTIPO_DATONull ? DBNull.Value : (object)value.TIPO_DATO);
			AddParameter(cmd, "VALOR_INFERIOR", value.VALOR_INFERIOR);
			AddParameter(cmd, "VALOR_SUPERIOR", value.VALOR_SUPERIOR);
			AddParameter(cmd, "TIPO_RANGO",
				value.IsTIPO_RANGONull ? DBNull.Value : (object)value.TIPO_RANGO);
			AddParameter(cmd, "MAIL", value.MAIL);
			AddParameter(cmd, "EXISTENCIA_MAYOR_CERO", value.EXISTENCIA_MAYOR_CERO);
			AddParameter(cmd, "TIPO_ENVIO_PARA_USUARIO",
				value.IsTIPO_ENVIO_PARA_USUARIONull ? DBNull.Value : (object)value.TIPO_ENVIO_PARA_USUARIO);
			AddParameter(cmd, "RESUMIDO", value.RESUMIDO);
			AddParameter(cmd, "SQL", value.SQL);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ALARMAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ALARMASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ALARMASRow value)
		{
			
			string sqlStr = "UPDATE TRC.ALARMAS SET " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"TIPO_ALARMA_ID=" + _db.CreateSqlParameterName("TIPO_ALARMA_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"ROL_ID=" + _db.CreateSqlParameterName("ROL_ID") + ", " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") + ", " +
				"LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"FLUJO_ESTADO_ID=" + _db.CreateSqlParameterName("FLUJO_ESTADO_ID") + ", " +
				"TIPO_DATO=" + _db.CreateSqlParameterName("TIPO_DATO") + ", " +
				"VALOR_INFERIOR=" + _db.CreateSqlParameterName("VALOR_INFERIOR") + ", " +
				"VALOR_SUPERIOR=" + _db.CreateSqlParameterName("VALOR_SUPERIOR") + ", " +
				"TIPO_RANGO=" + _db.CreateSqlParameterName("TIPO_RANGO") + ", " +
				"MAIL=" + _db.CreateSqlParameterName("MAIL") + ", " +
				"EXISTENCIA_MAYOR_CERO=" + _db.CreateSqlParameterName("EXISTENCIA_MAYOR_CERO") + ", " +
				"TIPO_ENVIO_PARA_USUARIO=" + _db.CreateSqlParameterName("TIPO_ENVIO_PARA_USUARIO") + ", " +
				"RESUMIDO=" + _db.CreateSqlParameterName("RESUMIDO") + ", " +
				"SQL=" + _db.CreateSqlParameterName("SQL") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "TIPO_ALARMA_ID", value.TIPO_ALARMA_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "ROL_ID",
				value.IsROL_IDNull ? DBNull.Value : (object)value.ROL_ID);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			AddParameter(cmd, "LOG_CAMPO_ID",
				value.IsLOG_CAMPO_IDNull ? DBNull.Value : (object)value.LOG_CAMPO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FLUJO_ESTADO_ID", value.FLUJO_ESTADO_ID);
			AddParameter(cmd, "TIPO_DATO",
				value.IsTIPO_DATONull ? DBNull.Value : (object)value.TIPO_DATO);
			AddParameter(cmd, "VALOR_INFERIOR", value.VALOR_INFERIOR);
			AddParameter(cmd, "VALOR_SUPERIOR", value.VALOR_SUPERIOR);
			AddParameter(cmd, "TIPO_RANGO",
				value.IsTIPO_RANGONull ? DBNull.Value : (object)value.TIPO_RANGO);
			AddParameter(cmd, "MAIL", value.MAIL);
			AddParameter(cmd, "EXISTENCIA_MAYOR_CERO", value.EXISTENCIA_MAYOR_CERO);
			AddParameter(cmd, "TIPO_ENVIO_PARA_USUARIO",
				value.IsTIPO_ENVIO_PARA_USUARIONull ? DBNull.Value : (object)value.TIPO_ENVIO_PARA_USUARIO);
			AddParameter(cmd, "RESUMIDO", value.RESUMIDO);
			AddParameter(cmd, "SQL", value.SQL);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ALARMAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ALARMAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ALARMAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ALARMASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ALARMASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ALARMAS</c> table using
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
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOG_CAMPO_ID(decimal log_campo_id)
		{
			return DeleteByLOG_CAMPO_ID(log_campo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOG_CAMPO_ID(decimal log_campo_id, bool log_campo_idNull)
		{
			return CreateDeleteByLOG_CAMPO_IDCommand(log_campo_id, log_campo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ALARMAS_CAMPO</c> foreign key.
		/// </summary>
		/// <param name="log_campo_id">The <c>LOG_CAMPO_ID</c> column value.</param>
		/// <param name="log_campo_idNull">true if the method ignores the log_campo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOG_CAMPO_IDCommand(decimal log_campo_id, bool log_campo_idNull)
		{
			string whereSql = "";
			if(log_campo_idNull)
				whereSql += "LOG_CAMPO_ID IS NULL";
			else
				whereSql += "LOG_CAMPO_ID=" + _db.CreateSqlParameterName("LOG_CAMPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!log_campo_idNull)
				AddParameter(cmd, "LOG_CAMPO_ID", log_campo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ALARMAS_ENTIDAD</c> foreign key.
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
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="flujo_estado_id">The <c>FLUJO_ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ESTADO_ID(string flujo_estado_id)
		{
			return CreateDeleteByFLUJO_ESTADO_IDCommand(flujo_estado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ALARMAS_ESTADO</c> foreign key.
		/// </summary>
		/// <param name="flujo_estado_id">The <c>FLUJO_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_ESTADO_IDCommand(string flujo_estado_id)
		{
			string whereSql = "";
			if(null == flujo_estado_id)
				whereSql += "FLUJO_ESTADO_ID IS NULL";
			else
				whereSql += "FLUJO_ESTADO_ID=" + _db.CreateSqlParameterName("FLUJO_ESTADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != flujo_estado_id)
				AddParameter(cmd, "FLUJO_ESTADO_ID", flujo_estado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return DeleteByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id, flujo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ALARMAS_FLUJO</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id)
		{
			return DeleteByROL_ID(rol_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_ID(decimal rol_id, bool rol_idNull)
		{
			return CreateDeleteByROL_IDCommand(rol_id, rol_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ALARMAS_ROL</c> foreign key.
		/// </summary>
		/// <param name="rol_id">The <c>ROL_ID</c> column value.</param>
		/// <param name="rol_idNull">true if the method ignores the rol_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_IDCommand(decimal rol_id, bool rol_idNull)
		{
			string whereSql = "";
			if(rol_idNull)
				whereSql += "ROL_ID IS NULL";
			else
				whereSql += "ROL_ID=" + _db.CreateSqlParameterName("ROL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_idNull)
				AddParameter(cmd, "ROL_ID", rol_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ALARMAS</c> table using the 
		/// <c>FK_ALARMAS_USR</c> foreign key.
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
		/// delete records using the <c>FK_ALARMAS_USR</c> foreign key.
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
		/// Deletes <c>ALARMAS</c> records that match the specified criteria.
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
		/// to delete <c>ALARMAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ALARMAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ALARMAS</c> table.
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
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		protected ALARMASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		protected ALARMASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ALARMASRow"/> objects.</returns>
		protected virtual ALARMASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int tipo_alarma_idColumnIndex = reader.GetOrdinal("TIPO_ALARMA_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int rol_idColumnIndex = reader.GetOrdinal("ROL_ID");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int log_campo_idColumnIndex = reader.GetOrdinal("LOG_CAMPO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int flujo_estado_idColumnIndex = reader.GetOrdinal("FLUJO_ESTADO_ID");
			int tipo_datoColumnIndex = reader.GetOrdinal("TIPO_DATO");
			int valor_inferiorColumnIndex = reader.GetOrdinal("VALOR_INFERIOR");
			int valor_superiorColumnIndex = reader.GetOrdinal("VALOR_SUPERIOR");
			int tipo_rangoColumnIndex = reader.GetOrdinal("TIPO_RANGO");
			int mailColumnIndex = reader.GetOrdinal("MAIL");
			int existencia_mayor_ceroColumnIndex = reader.GetOrdinal("EXISTENCIA_MAYOR_CERO");
			int tipo_envio_para_usuarioColumnIndex = reader.GetOrdinal("TIPO_ENVIO_PARA_USUARIO");
			int resumidoColumnIndex = reader.GetOrdinal("RESUMIDO");
			int sqlColumnIndex = reader.GetOrdinal("SQL");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ALARMASRow record = new ALARMASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.TIPO_ALARMA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_alarma_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(rol_idColumnIndex))
						record.ROL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rol_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(log_campo_idColumnIndex))
						record.LOG_CAMPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(log_campo_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(flujo_estado_idColumnIndex))
						record.FLUJO_ESTADO_ID = Convert.ToString(reader.GetValue(flujo_estado_idColumnIndex));
					if(!reader.IsDBNull(tipo_datoColumnIndex))
						record.TIPO_DATO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_datoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_inferiorColumnIndex))
						record.VALOR_INFERIOR = Convert.ToString(reader.GetValue(valor_inferiorColumnIndex));
					if(!reader.IsDBNull(valor_superiorColumnIndex))
						record.VALOR_SUPERIOR = Convert.ToString(reader.GetValue(valor_superiorColumnIndex));
					if(!reader.IsDBNull(tipo_rangoColumnIndex))
						record.TIPO_RANGO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_rangoColumnIndex)), 9);
					if(!reader.IsDBNull(mailColumnIndex))
						record.MAIL = Convert.ToString(reader.GetValue(mailColumnIndex));
					record.EXISTENCIA_MAYOR_CERO = Convert.ToString(reader.GetValue(existencia_mayor_ceroColumnIndex));
					if(!reader.IsDBNull(tipo_envio_para_usuarioColumnIndex))
						record.TIPO_ENVIO_PARA_USUARIO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_envio_para_usuarioColumnIndex)), 9);
					record.RESUMIDO = Convert.ToString(reader.GetValue(resumidoColumnIndex));
					if(!reader.IsDBNull(sqlColumnIndex))
						record.SQL = Convert.ToString(reader.GetValue(sqlColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ALARMASRow[])(recordList.ToArray(typeof(ALARMASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ALARMASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ALARMASRow"/> object.</returns>
		protected virtual ALARMASRow MapRow(DataRow row)
		{
			ALARMASRow mappedObject = new ALARMASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "TIPO_ALARMA_ID"
			dataColumn = dataTable.Columns["TIPO_ALARMA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ALARMA_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "ROL_ID"
			dataColumn = dataTable.Columns["ROL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_ID = (decimal)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "LOG_CAMPO_ID"
			dataColumn = dataTable.Columns["LOG_CAMPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOG_CAMPO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "FLUJO_ESTADO_ID"
			dataColumn = dataTable.Columns["FLUJO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ESTADO_ID = (string)row[dataColumn];
			// Column "TIPO_DATO"
			dataColumn = dataTable.Columns["TIPO_DATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DATO = (decimal)row[dataColumn];
			// Column "VALOR_INFERIOR"
			dataColumn = dataTable.Columns["VALOR_INFERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_INFERIOR = (string)row[dataColumn];
			// Column "VALOR_SUPERIOR"
			dataColumn = dataTable.Columns["VALOR_SUPERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_SUPERIOR = (string)row[dataColumn];
			// Column "TIPO_RANGO"
			dataColumn = dataTable.Columns["TIPO_RANGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_RANGO = (decimal)row[dataColumn];
			// Column "MAIL"
			dataColumn = dataTable.Columns["MAIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAIL = (string)row[dataColumn];
			// Column "EXISTENCIA_MAYOR_CERO"
			dataColumn = dataTable.Columns["EXISTENCIA_MAYOR_CERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA_MAYOR_CERO = (string)row[dataColumn];
			// Column "TIPO_ENVIO_PARA_USUARIO"
			dataColumn = dataTable.Columns["TIPO_ENVIO_PARA_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ENVIO_PARA_USUARIO = (decimal)row[dataColumn];
			// Column "RESUMIDO"
			dataColumn = dataTable.Columns["RESUMIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESUMIDO = (string)row[dataColumn];
			// Column "SQL"
			dataColumn = dataTable.Columns["SQL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SQL = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ALARMAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ALARMAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_ALARMA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ROL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOG_CAMPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FLUJO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TIPO_DATO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_INFERIOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("VALOR_SUPERIOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TIPO_RANGO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MAIL", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("EXISTENCIA_MAYOR_CERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_ENVIO_PARA_USUARIO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RESUMIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SQL", typeof(string));
			dataColumn.MaxLength = 2500;
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ALARMA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOG_CAMPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FLUJO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_DATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_INFERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VALOR_SUPERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_RANGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MAIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EXISTENCIA_MAYOR_CERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_ENVIO_PARA_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESUMIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SQL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ALARMASCollection_Base class
}  // End of namespace
