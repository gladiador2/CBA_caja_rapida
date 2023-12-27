// <fileinfo name="TARIFARIOS_DATOSCollection_Base.cs">
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
	/// The base class for <see cref="TARIFARIOS_DATOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TARIFARIOS_DATOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TARIFARIOS_DATOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TARIFARIO_IDColumnName = "TARIFARIO_ID";
		public const string VALORColumnName = "VALOR";
		public const string FECHA_MODIFICACIONColumnName = "FECHA_MODIFICACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string FILA_ESPECIALColumnName = "FILA_ESPECIAL";
		public const string DATO_RELACIONADO_IDColumnName = "DATO_RELACIONADO_ID";
		public const string USUARIO_MODIFICACION_IDColumnName = "USUARIO_MODIFICACION_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string TIPO_VALORColumnName = "TIPO_VALOR";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_DATOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TARIFARIOS_DATOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TARIFARIOS_DATOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public virtual TARIFARIOS_DATOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TARIFARIOS_DATOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TARIFARIOS_DATOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TARIFARIOS_DATOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TARIFARIOS_DATOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TARIFARIOS_DATOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TARIFARIOS_DATOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public TARIFARIOS_DATOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects that 
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
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public virtual TARIFARIOS_DATOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TARIFARIOS_DATOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TARIFARIOS_DATOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TARIFARIOS_DATOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TARIFARIOS_DATOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TARIFARIOS_DATOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects 
		/// by the <c>FK_TARIFARIOS_DATOS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public virtual TARIFARIOS_DATOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_DATOS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_DATOS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects 
		/// by the <c>FK_TARIFARIOS_DATOS_PERS_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public virtual TARIFARIOS_DATOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_DATOS_PERS_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_DATOS_PERS_ID</c> foreign key.
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
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects 
		/// by the <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public TARIFARIOS_DATOSRow[] GetByDATO_RELACIONADO_ID(decimal dato_relacionado_id)
		{
			return GetByDATO_RELACIONADO_ID(dato_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects 
		/// by the <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <param name="dato_relacionado_idNull">true if the method ignores the dato_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public virtual TARIFARIOS_DATOSRow[] GetByDATO_RELACIONADO_ID(decimal dato_relacionado_id, bool dato_relacionado_idNull)
		{
			return MapRecords(CreateGetByDATO_RELACIONADO_IDCommand(dato_relacionado_id, dato_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDATO_RELACIONADO_IDAsDataTable(decimal dato_relacionado_id)
		{
			return GetByDATO_RELACIONADO_IDAsDataTable(dato_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <param name="dato_relacionado_idNull">true if the method ignores the dato_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDATO_RELACIONADO_IDAsDataTable(decimal dato_relacionado_id, bool dato_relacionado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDATO_RELACIONADO_IDCommand(dato_relacionado_id, dato_relacionado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <param name="dato_relacionado_idNull">true if the method ignores the dato_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDATO_RELACIONADO_IDCommand(decimal dato_relacionado_id, bool dato_relacionado_idNull)
		{
			string whereSql = "";
			if(dato_relacionado_idNull)
				whereSql += "DATO_RELACIONADO_ID IS NULL";
			else
				whereSql += "DATO_RELACIONADO_ID=" + _db.CreateSqlParameterName("DATO_RELACIONADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!dato_relacionado_idNull)
				AddParameter(cmd, "DATO_RELACIONADO_ID", dato_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects 
		/// by the <c>FK_TARIFARIOS_DATOS_TARIF_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public virtual TARIFARIOS_DATOSRow[] GetByTARIFARIO_ID(decimal tarifario_id)
		{
			return MapRecords(CreateGetByTARIFARIO_IDCommand(tarifario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_DATOS_TARIF_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTARIFARIO_IDAsDataTable(decimal tarifario_id)
		{
			return MapRecordsToDataTable(CreateGetByTARIFARIO_IDCommand(tarifario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_DATOS_TARIF_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTARIFARIO_IDCommand(decimal tarifario_id)
		{
			string whereSql = "";
			whereSql += "TARIFARIO_ID=" + _db.CreateSqlParameterName("TARIFARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TARIFARIO_ID", tarifario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_DATOSRow"/> objects 
		/// by the <c>FK_TARIFARIOS_DATOS_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		public virtual TARIFARIOS_DATOSRow[] GetByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_DATOS_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_MODIFICACION_IDAsDataTable(decimal usuario_modificacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_DATOS_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TARIFARIOS_DATOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TARIFARIOS_DATOSRow"/> object to be inserted.</param>
		public virtual void Insert(TARIFARIOS_DATOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TARIFARIOS_DATOS (" +
				"ID, " +
				"TARIFARIO_ID, " +
				"VALOR, " +
				"FECHA_MODIFICACION, " +
				"ESTADO, " +
				"FILA_ESPECIAL, " +
				"DATO_RELACIONADO_ID, " +
				"USUARIO_MODIFICACION_ID, " +
				"FUNCIONARIO_ID, " +
				"PERSONA_ID, " +
				"TIPO_VALOR" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TARIFARIO_ID") + ", " +
				_db.CreateSqlParameterName("VALOR") + ", " +
				_db.CreateSqlParameterName("FECHA_MODIFICACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("FILA_ESPECIAL") + ", " +
				_db.CreateSqlParameterName("DATO_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_VALOR") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TARIFARIO_ID", value.TARIFARIO_ID);
			AddParameter(cmd, "VALOR", value.VALOR);
			AddParameter(cmd, "FECHA_MODIFICACION", value.FECHA_MODIFICACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FILA_ESPECIAL", value.FILA_ESPECIAL);
			AddParameter(cmd, "DATO_RELACIONADO_ID",
				value.IsDATO_RELACIONADO_IDNull ? DBNull.Value : (object)value.DATO_RELACIONADO_ID);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "TIPO_VALOR", value.TIPO_VALOR);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TARIFARIOS_DATOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TARIFARIOS_DATOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TARIFARIOS_DATOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.TARIFARIOS_DATOS SET " +
				"TARIFARIO_ID=" + _db.CreateSqlParameterName("TARIFARIO_ID") + ", " +
				"VALOR=" + _db.CreateSqlParameterName("VALOR") + ", " +
				"FECHA_MODIFICACION=" + _db.CreateSqlParameterName("FECHA_MODIFICACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"FILA_ESPECIAL=" + _db.CreateSqlParameterName("FILA_ESPECIAL") + ", " +
				"DATO_RELACIONADO_ID=" + _db.CreateSqlParameterName("DATO_RELACIONADO_ID") + ", " +
				"USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"TIPO_VALOR=" + _db.CreateSqlParameterName("TIPO_VALOR") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TARIFARIO_ID", value.TARIFARIO_ID);
			AddParameter(cmd, "VALOR", value.VALOR);
			AddParameter(cmd, "FECHA_MODIFICACION", value.FECHA_MODIFICACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FILA_ESPECIAL", value.FILA_ESPECIAL);
			AddParameter(cmd, "DATO_RELACIONADO_ID",
				value.IsDATO_RELACIONADO_IDNull ? DBNull.Value : (object)value.DATO_RELACIONADO_ID);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "TIPO_VALOR", value.TIPO_VALOR);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TARIFARIOS_DATOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TARIFARIOS_DATOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TARIFARIOS_DATOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TARIFARIOS_DATOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TARIFARIOS_DATOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TARIFARIOS_DATOS</c> table using
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
		/// Deletes records from the <c>TARIFARIOS_DATOS</c> table using the 
		/// <c>FK_TARIFARIOS_DATOS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_DATOS_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_DATOS</c> table using the 
		/// <c>FK_TARIFARIOS_DATOS_PERS_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_DATOS_PERS_ID</c> foreign key.
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
		/// Deletes records from the <c>TARIFARIOS_DATOS</c> table using the 
		/// <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDATO_RELACIONADO_ID(decimal dato_relacionado_id)
		{
			return DeleteByDATO_RELACIONADO_ID(dato_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_DATOS</c> table using the 
		/// <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <param name="dato_relacionado_idNull">true if the method ignores the dato_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDATO_RELACIONADO_ID(decimal dato_relacionado_id, bool dato_relacionado_idNull)
		{
			return CreateDeleteByDATO_RELACIONADO_IDCommand(dato_relacionado_id, dato_relacionado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_DATOS_RELAC_ID</c> foreign key.
		/// </summary>
		/// <param name="dato_relacionado_id">The <c>DATO_RELACIONADO_ID</c> column value.</param>
		/// <param name="dato_relacionado_idNull">true if the method ignores the dato_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDATO_RELACIONADO_IDCommand(decimal dato_relacionado_id, bool dato_relacionado_idNull)
		{
			string whereSql = "";
			if(dato_relacionado_idNull)
				whereSql += "DATO_RELACIONADO_ID IS NULL";
			else
				whereSql += "DATO_RELACIONADO_ID=" + _db.CreateSqlParameterName("DATO_RELACIONADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!dato_relacionado_idNull)
				AddParameter(cmd, "DATO_RELACIONADO_ID", dato_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_DATOS</c> table using the 
		/// <c>FK_TARIFARIOS_DATOS_TARIF_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTARIFARIO_ID(decimal tarifario_id)
		{
			return CreateDeleteByTARIFARIO_IDCommand(tarifario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_DATOS_TARIF_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTARIFARIO_IDCommand(decimal tarifario_id)
		{
			string whereSql = "";
			whereSql += "TARIFARIO_ID=" + _db.CreateSqlParameterName("TARIFARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TARIFARIO_ID", tarifario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_DATOS</c> table using the 
		/// <c>FK_TARIFARIOS_DATOS_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return CreateDeleteByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_DATOS_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TARIFARIOS_DATOS</c> records that match the specified criteria.
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
		/// to delete <c>TARIFARIOS_DATOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TARIFARIOS_DATOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TARIFARIOS_DATOS</c> table.
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
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		protected TARIFARIOS_DATOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		protected TARIFARIOS_DATOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TARIFARIOS_DATOSRow"/> objects.</returns>
		protected virtual TARIFARIOS_DATOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tarifario_idColumnIndex = reader.GetOrdinal("TARIFARIO_ID");
			int valorColumnIndex = reader.GetOrdinal("VALOR");
			int fecha_modificacionColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int fila_especialColumnIndex = reader.GetOrdinal("FILA_ESPECIAL");
			int dato_relacionado_idColumnIndex = reader.GetOrdinal("DATO_RELACIONADO_ID");
			int usuario_modificacion_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int tipo_valorColumnIndex = reader.GetOrdinal("TIPO_VALOR");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TARIFARIOS_DATOSRow record = new TARIFARIOS_DATOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TARIFARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tarifario_idColumnIndex)), 9);
					if(!reader.IsDBNull(valorColumnIndex))
						record.VALOR = Convert.ToString(reader.GetValue(valorColumnIndex));
					record.FECHA_MODIFICACION = Convert.ToDateTime(reader.GetValue(fecha_modificacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.FILA_ESPECIAL = Convert.ToString(reader.GetValue(fila_especialColumnIndex));
					if(!reader.IsDBNull(dato_relacionado_idColumnIndex))
						record.DATO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(dato_relacionado_idColumnIndex)), 9);
					record.USUARIO_MODIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificacion_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_valorColumnIndex))
						record.TIPO_VALOR = Convert.ToString(reader.GetValue(tipo_valorColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TARIFARIOS_DATOSRow[])(recordList.ToArray(typeof(TARIFARIOS_DATOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TARIFARIOS_DATOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TARIFARIOS_DATOSRow"/> object.</returns>
		protected virtual TARIFARIOS_DATOSRow MapRow(DataRow row)
		{
			TARIFARIOS_DATOSRow mappedObject = new TARIFARIOS_DATOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TARIFARIO_ID"
			dataColumn = dataTable.Columns["TARIFARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIO_ID = (decimal)row[dataColumn];
			// Column "VALOR"
			dataColumn = dataTable.Columns["VALOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR = (string)row[dataColumn];
			// Column "FECHA_MODIFICACION"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "FILA_ESPECIAL"
			dataColumn = dataTable.Columns["FILA_ESPECIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FILA_ESPECIAL = (string)row[dataColumn];
			// Column "DATO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["DATO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DATO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_MODIFICACION_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "TIPO_VALOR"
			dataColumn = dataTable.Columns["TIPO_VALOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_VALOR = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TARIFARIOS_DATOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TARIFARIOS_DATOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TARIFARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VALOR", typeof(string));
			dataColumn.MaxLength = 4000;
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FILA_ESPECIAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DATO_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_VALOR", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "TARIFARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_MODIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FILA_ESPECIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DATO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_MODIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_VALOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TARIFARIOS_DATOSCollection_Base class
}  // End of namespace
