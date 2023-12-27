// <fileinfo name="CONTENEDORESCollection_Base.cs">
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
	/// The base class for <see cref="CONTENEDORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTENEDORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NUMEROColumnName = "NUMERO";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string AGENCIA_IDColumnName = "AGENCIA_ID";
		public const string TIPO_IDColumnName = "TIPO_ID";
		public const string TARAColumnName = "TARA";
		public const string CAPACIDADColumnName = "CAPACIDAD";
		public const string PESO_MAXIMOColumnName = "PESO_MAXIMO";
		public const string ESTADOColumnName = "ESTADO";
		public const string EN_PREDIOColumnName = "EN_PREDIO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string CLASEColumnName = "CLASE";
		public const string BLOQUEADOColumnName = "BLOQUEADO";
		public const string HABILITADO_HASTAColumnName = "HABILITADO_HASTA";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTENEDORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTENEDORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public virtual CONTENEDORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTENEDORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTENEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTENEDORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTENEDORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public CONTENEDORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects that 
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
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public virtual CONTENEDORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTENEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONTENEDORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONTENEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONTENEDORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONTENEDORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public virtual CONTENEDORESRow[] GetByAGENCIA_ID(decimal agencia_id)
		{
			return MapRecords(CreateGetByAGENCIA_IDCommand(agencia_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAGENCIA_IDAsDataTable(decimal agencia_id)
		{
			return MapRecordsToDataTable(CreateGetByAGENCIA_IDCommand(agencia_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTENEDORES_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAGENCIA_IDCommand(decimal agencia_id)
		{
			string whereSql = "";
			whereSql += "AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AGENCIA_ID", agencia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public virtual CONTENEDORESRow[] GetByLINEA_ID(decimal linea_id)
		{
			return MapRecords(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLINEA_IDAsDataTable(decimal linea_id)
		{
			return MapRecordsToDataTable(CreateGetByLINEA_IDCommand(linea_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTENEDORES_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLINEA_IDCommand(decimal linea_id)
		{
			string whereSql = "";
			whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public CONTENEDORESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <param name="puerto_devolucion_idNull">true if the method ignores the puerto_devolucion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public virtual CONTENEDORESRow[] GetByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id, bool puerto_devolucion_idNull)
		{
			return MapRecords(CreateGetByPUERTO_DEVOLUCION_IDCommand(puerto_devolucion_id, puerto_devolucion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPUERTO_DEVOLUCION_IDAsDataTable(decimal puerto_devolucion_id)
		{
			return GetByPUERTO_DEVOLUCION_IDAsDataTable(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
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
		/// return records by the <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
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
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_TIPOS_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public virtual CONTENEDORESRow[] GetByTIPO_ID(decimal tipo_id)
		{
			return MapRecords(CreateGetByTIPO_IDCommand(tipo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_TIPOS_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_IDAsDataTable(decimal tipo_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_IDCommand(tipo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTENEDORES_TIPOS_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_IDCommand(decimal tipo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ID=" + _db.CreateSqlParameterName("TIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_ID", tipo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		public virtual CONTENEDORESRow[] GetByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREADOR_IDAsDataTable(decimal usuario_creador_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREADOR_IDCommand(usuario_creador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTENEDORES_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORESRow"/> object to be inserted.</param>
		public virtual void Insert(CONTENEDORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONTENEDORES (" +
				"ID, " +
				"NUMERO, " +
				"LINEA_ID, " +
				"AGENCIA_ID, " +
				"TIPO_ID, " +
				"TARA, " +
				"CAPACIDAD, " +
				"PESO_MAXIMO, " +
				"ESTADO, " +
				"EN_PREDIO, " +
				"FECHA_CREACION, " +
				"USUARIO_CREADOR_ID, " +
				"CLASE, " +
				"BLOQUEADO, " +
				"HABILITADO_HASTA, " +
				"PUERTO_DEVOLUCION_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NUMERO") + ", " +
				_db.CreateSqlParameterName("LINEA_ID") + ", " +
				_db.CreateSqlParameterName("AGENCIA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_ID") + ", " +
				_db.CreateSqlParameterName("TARA") + ", " +
				_db.CreateSqlParameterName("CAPACIDAD") + ", " +
				_db.CreateSqlParameterName("PESO_MAXIMO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("EN_PREDIO") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				_db.CreateSqlParameterName("CLASE") + ", " +
				_db.CreateSqlParameterName("BLOQUEADO") + ", " +
				_db.CreateSqlParameterName("HABILITADO_HASTA") + ", " +
				_db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "AGENCIA_ID", value.AGENCIA_ID);
			AddParameter(cmd, "TIPO_ID", value.TIPO_ID);
			AddParameter(cmd, "TARA", value.TARA);
			AddParameter(cmd, "CAPACIDAD", value.CAPACIDAD);
			AddParameter(cmd, "PESO_MAXIMO", value.PESO_MAXIMO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "EN_PREDIO", value.EN_PREDIO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREADOR_ID", value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "CLASE", value.CLASE);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			AddParameter(cmd, "HABILITADO_HASTA",
				value.IsHABILITADO_HASTANull ? DBNull.Value : (object)value.HABILITADO_HASTA);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONTENEDORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONTENEDORES SET " +
				"NUMERO=" + _db.CreateSqlParameterName("NUMERO") + ", " +
				"LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID") + ", " +
				"AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID") + ", " +
				"TIPO_ID=" + _db.CreateSqlParameterName("TIPO_ID") + ", " +
				"TARA=" + _db.CreateSqlParameterName("TARA") + ", " +
				"CAPACIDAD=" + _db.CreateSqlParameterName("CAPACIDAD") + ", " +
				"PESO_MAXIMO=" + _db.CreateSqlParameterName("PESO_MAXIMO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"EN_PREDIO=" + _db.CreateSqlParameterName("EN_PREDIO") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID") + ", " +
				"CLASE=" + _db.CreateSqlParameterName("CLASE") + ", " +
				"BLOQUEADO=" + _db.CreateSqlParameterName("BLOQUEADO") + ", " +
				"HABILITADO_HASTA=" + _db.CreateSqlParameterName("HABILITADO_HASTA") + ", " +
				"PUERTO_DEVOLUCION_ID=" + _db.CreateSqlParameterName("PUERTO_DEVOLUCION_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "LINEA_ID", value.LINEA_ID);
			AddParameter(cmd, "AGENCIA_ID", value.AGENCIA_ID);
			AddParameter(cmd, "TIPO_ID", value.TIPO_ID);
			AddParameter(cmd, "TARA", value.TARA);
			AddParameter(cmd, "CAPACIDAD", value.CAPACIDAD);
			AddParameter(cmd, "PESO_MAXIMO", value.PESO_MAXIMO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "EN_PREDIO", value.EN_PREDIO);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREADOR_ID", value.USUARIO_CREADOR_ID);
			AddParameter(cmd, "CLASE", value.CLASE);
			AddParameter(cmd, "BLOQUEADO", value.BLOQUEADO);
			AddParameter(cmd, "HABILITADO_HASTA",
				value.IsHABILITADO_HASTANull ? DBNull.Value : (object)value.HABILITADO_HASTA);
			AddParameter(cmd, "PUERTO_DEVOLUCION_ID",
				value.IsPUERTO_DEVOLUCION_IDNull ? DBNull.Value : (object)value.PUERTO_DEVOLUCION_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONTENEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONTENEDORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONTENEDORES</c> table using
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
		/// Deletes records from the <c>CONTENEDORES</c> table using the 
		/// <c>FK_CONTENEDORES_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAGENCIA_ID(decimal agencia_id)
		{
			return CreateDeleteByAGENCIA_IDCommand(agencia_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTENEDORES_AGENCIA_ID</c> foreign key.
		/// </summary>
		/// <param name="agencia_id">The <c>AGENCIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAGENCIA_IDCommand(decimal agencia_id)
		{
			string whereSql = "";
			whereSql += "AGENCIA_ID=" + _db.CreateSqlParameterName("AGENCIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AGENCIA_ID", agencia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES</c> table using the 
		/// <c>FK_CONTENEDORES_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id)
		{
			return CreateDeleteByLINEA_IDCommand(linea_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTENEDORES_LINEA_ID</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLINEA_IDCommand(decimal linea_id)
		{
			string whereSql = "";
			whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES</c> table using the 
		/// <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
		/// </summary>
		/// <param name="puerto_devolucion_id">The <c>PUERTO_DEVOLUCION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPUERTO_DEVOLUCION_ID(decimal puerto_devolucion_id)
		{
			return DeleteByPUERTO_DEVOLUCION_ID(puerto_devolucion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES</c> table using the 
		/// <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
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
		/// delete records using the <c>FK_CONTENEDORES_PUERTO_ID</c> foreign key.
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
		/// Deletes records from the <c>CONTENEDORES</c> table using the 
		/// <c>FK_CONTENEDORES_TIPOS_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_ID(decimal tipo_id)
		{
			return CreateDeleteByTIPO_IDCommand(tipo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTENEDORES_TIPOS_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_id">The <c>TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_IDCommand(decimal tipo_id)
		{
			string whereSql = "";
			whereSql += "TIPO_ID=" + _db.CreateSqlParameterName("TIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_ID", tipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES</c> table using the 
		/// <c>FK_CONTENEDORES_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREADOR_ID(decimal usuario_creador_id)
		{
			return CreateDeleteByUSUARIO_CREADOR_IDCommand(usuario_creador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTENEDORES_USU_CREADOR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creador_id">The <c>USUARIO_CREADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREADOR_IDCommand(decimal usuario_creador_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREADOR_ID=" + _db.CreateSqlParameterName("USUARIO_CREADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREADOR_ID", usuario_creador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CONTENEDORES</c> records that match the specified criteria.
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
		/// to delete <c>CONTENEDORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONTENEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONTENEDORES</c> table.
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
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		protected CONTENEDORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		protected CONTENEDORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTENEDORESRow"/> objects.</returns>
		protected virtual CONTENEDORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int agencia_idColumnIndex = reader.GetOrdinal("AGENCIA_ID");
			int tipo_idColumnIndex = reader.GetOrdinal("TIPO_ID");
			int taraColumnIndex = reader.GetOrdinal("TARA");
			int capacidadColumnIndex = reader.GetOrdinal("CAPACIDAD");
			int peso_maximoColumnIndex = reader.GetOrdinal("PESO_MAXIMO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int en_predioColumnIndex = reader.GetOrdinal("EN_PREDIO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int claseColumnIndex = reader.GetOrdinal("CLASE");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");
			int habilitado_hastaColumnIndex = reader.GetOrdinal("HABILITADO_HASTA");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTENEDORESRow record = new CONTENEDORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NUMERO = Convert.ToString(reader.GetValue(numeroColumnIndex));
					record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					record.AGENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(agencia_idColumnIndex)), 9);
					record.TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_idColumnIndex)), 9);
					record.TARA = Math.Round(Convert.ToDecimal(reader.GetValue(taraColumnIndex)), 9);
					record.CAPACIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(capacidadColumnIndex)), 9);
					record.PESO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_maximoColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.EN_PREDIO = Convert.ToString(reader.GetValue(en_predioColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					record.CLASE = Convert.ToString(reader.GetValue(claseColumnIndex));
					if(!reader.IsDBNull(bloqueadoColumnIndex))
						record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));
					if(!reader.IsDBNull(habilitado_hastaColumnIndex))
						record.HABILITADO_HASTA = Convert.ToDateTime(reader.GetValue(habilitado_hastaColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTENEDORESRow[])(recordList.ToArray(typeof(CONTENEDORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTENEDORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTENEDORESRow"/> object.</returns>
		protected virtual CONTENEDORESRow MapRow(DataRow row)
		{
			CONTENEDORESRow mappedObject = new CONTENEDORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (string)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "AGENCIA_ID"
			dataColumn = dataTable.Columns["AGENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_ID = (decimal)row[dataColumn];
			// Column "TIPO_ID"
			dataColumn = dataTable.Columns["TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ID = (decimal)row[dataColumn];
			// Column "TARA"
			dataColumn = dataTable.Columns["TARA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA = (decimal)row[dataColumn];
			// Column "CAPACIDAD"
			dataColumn = dataTable.Columns["CAPACIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPACIDAD = (decimal)row[dataColumn];
			// Column "PESO_MAXIMO"
			dataColumn = dataTable.Columns["PESO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MAXIMO = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "EN_PREDIO"
			dataColumn = dataTable.Columns["EN_PREDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_PREDIO = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "CLASE"
			dataColumn = dataTable.Columns["CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLASE = (string)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			// Column "HABILITADO_HASTA"
			dataColumn = dataTable.Columns["HABILITADO_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.HABILITADO_HASTA = (System.DateTime)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTENEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTENEDORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AGENCIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TARA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPACIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PESO_MAXIMO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EN_PREDIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CLASE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn = dataTable.Columns.Add("HABILITADO_HASTA", typeof(System.DateTime));
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

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AGENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPACIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EN_PREDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "HABILITADO_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTENEDORESCollection_Base class
}  // End of namespace
