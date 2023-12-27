// <fileinfo name="MARCACIONESCollection_Base.cs">
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
	/// The base class for <see cref="MARCACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MARCACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MARCACIONESCollection_Base
	{
		// Constants
		public const string RELOJ_MARCACION_IDColumnName = "RELOJ_MARCACION_ID";
		public const string RELOJ_FUNCIONARIO_IDColumnName = "RELOJ_FUNCIONARIO_ID";
		public const string FECHA_MARCACIONColumnName = "FECHA_MARCACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string CALIFICACIONColumnName = "CALIFICACION";
		public const string ES_COPIADOColumnName = "ES_COPIADO";
		public const string JUSTIFICADOColumnName = "JUSTIFICADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TIPO_MOVIMIENTOColumnName = "TIPO_MOVIMIENTO";
		public const string FECHA_COPIADOColumnName = "FECHA_COPIADO";
		public const string DESCONTARColumnName = "DESCONTAR";
		public const string DESCONTADOColumnName = "DESCONTADO";
		public const string IDColumnName = "ID";
		public const string TURNO_ENTRADA_ANTESColumnName = "TURNO_ENTRADA_ANTES";
		public const string TURNO_ENTRADAColumnName = "TURNO_ENTRADA";
		public const string TURNO_ENTRADA_DESPUESColumnName = "TURNO_ENTRADA_DESPUES";
		public const string TURNO_SALIDA_ANTESColumnName = "TURNO_SALIDA_ANTES";
		public const string TURNO_SALIDAColumnName = "TURNO_SALIDA";
		public const string TURNO_SALIDA_DESPUESColumnName = "TURNO_SALIDA_DESPUES";
		public const string TURNO_IDColumnName = "TURNO_ID";
		public const string DESCUENTO_LLEGADA_TARDIA_IDColumnName = "DESCUENTO_LLEGADA_TARDIA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MARCACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public MARCACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>MARCACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public virtual MARCACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MARCACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MARCACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MARCACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MARCACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MARCACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MARCACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public MARCACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public virtual MARCACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.MARCACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="MARCACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="MARCACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual MARCACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			MARCACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects 
		/// by the <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public MARCACIONESRow[] GetByDESCUENTO_LLEGADA_TARDIA_ID(decimal descuento_llegada_tardia_id)
		{
			return GetByDESCUENTO_LLEGADA_TARDIA_ID(descuento_llegada_tardia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects 
		/// by the <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <param name="descuento_llegada_tardia_idNull">true if the method ignores the descuento_llegada_tardia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public virtual MARCACIONESRow[] GetByDESCUENTO_LLEGADA_TARDIA_ID(decimal descuento_llegada_tardia_id, bool descuento_llegada_tardia_idNull)
		{
			return MapRecords(CreateGetByDESCUENTO_LLEGADA_TARDIA_IDCommand(descuento_llegada_tardia_id, descuento_llegada_tardia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCUENTO_LLEGADA_TARDIA_IDAsDataTable(decimal descuento_llegada_tardia_id)
		{
			return GetByDESCUENTO_LLEGADA_TARDIA_IDAsDataTable(descuento_llegada_tardia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <param name="descuento_llegada_tardia_idNull">true if the method ignores the descuento_llegada_tardia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_LLEGADA_TARDIA_IDAsDataTable(decimal descuento_llegada_tardia_id, bool descuento_llegada_tardia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_LLEGADA_TARDIA_IDCommand(descuento_llegada_tardia_id, descuento_llegada_tardia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <param name="descuento_llegada_tardia_idNull">true if the method ignores the descuento_llegada_tardia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_LLEGADA_TARDIA_IDCommand(decimal descuento_llegada_tardia_id, bool descuento_llegada_tardia_idNull)
		{
			string whereSql = "";
			if(descuento_llegada_tardia_idNull)
				whereSql += "DESCUENTO_LLEGADA_TARDIA_ID IS NULL";
			else
				whereSql += "DESCUENTO_LLEGADA_TARDIA_ID=" + _db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!descuento_llegada_tardia_idNull)
				AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID", descuento_llegada_tardia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects 
		/// by the <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public MARCACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects 
		/// by the <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public virtual MARCACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return GetByFUNCIONARIO_IDAsDataTable(funcionario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id, bool funcionario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects 
		/// by the <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public MARCACIONESRow[] GetByTURNO_ID(decimal turno_id)
		{
			return GetByTURNO_ID(turno_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONESRow"/> objects 
		/// by the <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <param name="turno_idNull">true if the method ignores the turno_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		public virtual MARCACIONESRow[] GetByTURNO_ID(decimal turno_id, bool turno_idNull)
		{
			return MapRecords(CreateGetByTURNO_IDCommand(turno_id, turno_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTURNO_IDAsDataTable(decimal turno_id)
		{
			return GetByTURNO_IDAsDataTable(turno_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <param name="turno_idNull">true if the method ignores the turno_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTURNO_IDAsDataTable(decimal turno_id, bool turno_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTURNO_IDCommand(turno_id, turno_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <param name="turno_idNull">true if the method ignores the turno_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTURNO_IDCommand(decimal turno_id, bool turno_idNull)
		{
			string whereSql = "";
			if(turno_idNull)
				whereSql += "TURNO_ID IS NULL";
			else
				whereSql += "TURNO_ID=" + _db.CreateSqlParameterName("TURNO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!turno_idNull)
				AddParameter(cmd, "TURNO_ID", turno_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>MARCACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MARCACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(MARCACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.MARCACIONES (" +
				"RELOJ_MARCACION_ID, " +
				"RELOJ_FUNCIONARIO_ID, " +
				"FECHA_MARCACION, " +
				"FUNCIONARIO_ID, " +
				"CALIFICACION, " +
				"ES_COPIADO, " +
				"JUSTIFICADO, " +
				"OBSERVACION, " +
				"TIPO_MOVIMIENTO, " +
				"FECHA_COPIADO, " +
				"DESCONTAR, " +
				"DESCONTADO, " +
				"ID, " +
				"TURNO_ENTRADA_ANTES, " +
				"TURNO_ENTRADA, " +
				"TURNO_ENTRADA_DESPUES, " +
				"TURNO_SALIDA_ANTES, " +
				"TURNO_SALIDA, " +
				"TURNO_SALIDA_DESPUES, " +
				"TURNO_ID, " +
				"DESCUENTO_LLEGADA_TARDIA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("RELOJ_MARCACION_ID") + ", " +
				_db.CreateSqlParameterName("RELOJ_FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_MARCACION") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("CALIFICACION") + ", " +
				_db.CreateSqlParameterName("ES_COPIADO") + ", " +
				_db.CreateSqlParameterName("JUSTIFICADO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TIPO_MOVIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_COPIADO") + ", " +
				_db.CreateSqlParameterName("DESCONTAR") + ", " +
				_db.CreateSqlParameterName("DESCONTADO") + ", " +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TURNO_ENTRADA_ANTES") + ", " +
				_db.CreateSqlParameterName("TURNO_ENTRADA") + ", " +
				_db.CreateSqlParameterName("TURNO_ENTRADA_DESPUES") + ", " +
				_db.CreateSqlParameterName("TURNO_SALIDA_ANTES") + ", " +
				_db.CreateSqlParameterName("TURNO_SALIDA") + ", " +
				_db.CreateSqlParameterName("TURNO_SALIDA_DESPUES") + ", " +
				_db.CreateSqlParameterName("TURNO_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "RELOJ_MARCACION_ID",
				value.IsRELOJ_MARCACION_IDNull ? DBNull.Value : (object)value.RELOJ_MARCACION_ID);
			AddParameter(cmd, "RELOJ_FUNCIONARIO_ID",
				value.IsRELOJ_FUNCIONARIO_IDNull ? DBNull.Value : (object)value.RELOJ_FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA_MARCACION", value.FECHA_MARCACION);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "CALIFICACION",
				value.IsCALIFICACIONNull ? DBNull.Value : (object)value.CALIFICACION);
			AddParameter(cmd, "ES_COPIADO", value.ES_COPIADO);
			AddParameter(cmd, "JUSTIFICADO", value.JUSTIFICADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TIPO_MOVIMIENTO", value.TIPO_MOVIMIENTO);
			AddParameter(cmd, "FECHA_COPIADO",
				value.IsFECHA_COPIADONull ? DBNull.Value : (object)value.FECHA_COPIADO);
			AddParameter(cmd, "DESCONTAR", value.DESCONTAR);
			AddParameter(cmd, "DESCONTADO", value.DESCONTADO);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TURNO_ENTRADA_ANTES",
				value.IsTURNO_ENTRADA_ANTESNull ? DBNull.Value : (object)value.TURNO_ENTRADA_ANTES);
			AddParameter(cmd, "TURNO_ENTRADA",
				value.IsTURNO_ENTRADANull ? DBNull.Value : (object)value.TURNO_ENTRADA);
			AddParameter(cmd, "TURNO_ENTRADA_DESPUES",
				value.IsTURNO_ENTRADA_DESPUESNull ? DBNull.Value : (object)value.TURNO_ENTRADA_DESPUES);
			AddParameter(cmd, "TURNO_SALIDA_ANTES",
				value.IsTURNO_SALIDA_ANTESNull ? DBNull.Value : (object)value.TURNO_SALIDA_ANTES);
			AddParameter(cmd, "TURNO_SALIDA",
				value.IsTURNO_SALIDANull ? DBNull.Value : (object)value.TURNO_SALIDA);
			AddParameter(cmd, "TURNO_SALIDA_DESPUES",
				value.IsTURNO_SALIDA_DESPUESNull ? DBNull.Value : (object)value.TURNO_SALIDA_DESPUES);
			AddParameter(cmd, "TURNO_ID",
				value.IsTURNO_IDNull ? DBNull.Value : (object)value.TURNO_ID);
			AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID",
				value.IsDESCUENTO_LLEGADA_TARDIA_IDNull ? DBNull.Value : (object)value.DESCUENTO_LLEGADA_TARDIA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>MARCACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MARCACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(MARCACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.MARCACIONES SET " +
				"RELOJ_MARCACION_ID=" + _db.CreateSqlParameterName("RELOJ_MARCACION_ID") + ", " +
				"RELOJ_FUNCIONARIO_ID=" + _db.CreateSqlParameterName("RELOJ_FUNCIONARIO_ID") + ", " +
				"FECHA_MARCACION=" + _db.CreateSqlParameterName("FECHA_MARCACION") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"CALIFICACION=" + _db.CreateSqlParameterName("CALIFICACION") + ", " +
				"ES_COPIADO=" + _db.CreateSqlParameterName("ES_COPIADO") + ", " +
				"JUSTIFICADO=" + _db.CreateSqlParameterName("JUSTIFICADO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TIPO_MOVIMIENTO=" + _db.CreateSqlParameterName("TIPO_MOVIMIENTO") + ", " +
				"FECHA_COPIADO=" + _db.CreateSqlParameterName("FECHA_COPIADO") + ", " +
				"DESCONTAR=" + _db.CreateSqlParameterName("DESCONTAR") + ", " +
				"DESCONTADO=" + _db.CreateSqlParameterName("DESCONTADO") + ", " +
				"TURNO_ENTRADA_ANTES=" + _db.CreateSqlParameterName("TURNO_ENTRADA_ANTES") + ", " +
				"TURNO_ENTRADA=" + _db.CreateSqlParameterName("TURNO_ENTRADA") + ", " +
				"TURNO_ENTRADA_DESPUES=" + _db.CreateSqlParameterName("TURNO_ENTRADA_DESPUES") + ", " +
				"TURNO_SALIDA_ANTES=" + _db.CreateSqlParameterName("TURNO_SALIDA_ANTES") + ", " +
				"TURNO_SALIDA=" + _db.CreateSqlParameterName("TURNO_SALIDA") + ", " +
				"TURNO_SALIDA_DESPUES=" + _db.CreateSqlParameterName("TURNO_SALIDA_DESPUES") + ", " +
				"TURNO_ID=" + _db.CreateSqlParameterName("TURNO_ID") + ", " +
				"DESCUENTO_LLEGADA_TARDIA_ID=" + _db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "RELOJ_MARCACION_ID",
				value.IsRELOJ_MARCACION_IDNull ? DBNull.Value : (object)value.RELOJ_MARCACION_ID);
			AddParameter(cmd, "RELOJ_FUNCIONARIO_ID",
				value.IsRELOJ_FUNCIONARIO_IDNull ? DBNull.Value : (object)value.RELOJ_FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA_MARCACION", value.FECHA_MARCACION);
			AddParameter(cmd, "FUNCIONARIO_ID",
				value.IsFUNCIONARIO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_ID);
			AddParameter(cmd, "CALIFICACION",
				value.IsCALIFICACIONNull ? DBNull.Value : (object)value.CALIFICACION);
			AddParameter(cmd, "ES_COPIADO", value.ES_COPIADO);
			AddParameter(cmd, "JUSTIFICADO", value.JUSTIFICADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TIPO_MOVIMIENTO", value.TIPO_MOVIMIENTO);
			AddParameter(cmd, "FECHA_COPIADO",
				value.IsFECHA_COPIADONull ? DBNull.Value : (object)value.FECHA_COPIADO);
			AddParameter(cmd, "DESCONTAR", value.DESCONTAR);
			AddParameter(cmd, "DESCONTADO", value.DESCONTADO);
			AddParameter(cmd, "TURNO_ENTRADA_ANTES",
				value.IsTURNO_ENTRADA_ANTESNull ? DBNull.Value : (object)value.TURNO_ENTRADA_ANTES);
			AddParameter(cmd, "TURNO_ENTRADA",
				value.IsTURNO_ENTRADANull ? DBNull.Value : (object)value.TURNO_ENTRADA);
			AddParameter(cmd, "TURNO_ENTRADA_DESPUES",
				value.IsTURNO_ENTRADA_DESPUESNull ? DBNull.Value : (object)value.TURNO_ENTRADA_DESPUES);
			AddParameter(cmd, "TURNO_SALIDA_ANTES",
				value.IsTURNO_SALIDA_ANTESNull ? DBNull.Value : (object)value.TURNO_SALIDA_ANTES);
			AddParameter(cmd, "TURNO_SALIDA",
				value.IsTURNO_SALIDANull ? DBNull.Value : (object)value.TURNO_SALIDA);
			AddParameter(cmd, "TURNO_SALIDA_DESPUES",
				value.IsTURNO_SALIDA_DESPUESNull ? DBNull.Value : (object)value.TURNO_SALIDA_DESPUES);
			AddParameter(cmd, "TURNO_ID",
				value.IsTURNO_IDNull ? DBNull.Value : (object)value.TURNO_ID);
			AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID",
				value.IsDESCUENTO_LLEGADA_TARDIA_IDNull ? DBNull.Value : (object)value.DESCUENTO_LLEGADA_TARDIA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>MARCACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>MARCACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>MARCACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="MARCACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(MARCACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>MARCACIONES</c> table using
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
		/// Deletes records from the <c>MARCACIONES</c> table using the 
		/// <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_LLEGADA_TARDIA_ID(decimal descuento_llegada_tardia_id)
		{
			return DeleteByDESCUENTO_LLEGADA_TARDIA_ID(descuento_llegada_tardia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MARCACIONES</c> table using the 
		/// <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <param name="descuento_llegada_tardia_idNull">true if the method ignores the descuento_llegada_tardia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_LLEGADA_TARDIA_ID(decimal descuento_llegada_tardia_id, bool descuento_llegada_tardia_idNull)
		{
			return CreateDeleteByDESCUENTO_LLEGADA_TARDIA_IDCommand(descuento_llegada_tardia_id, descuento_llegada_tardia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTO_LLEG_TAR_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_llegada_tardia_id">The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</param>
		/// <param name="descuento_llegada_tardia_idNull">true if the method ignores the descuento_llegada_tardia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_LLEGADA_TARDIA_IDCommand(decimal descuento_llegada_tardia_id, bool descuento_llegada_tardia_idNull)
		{
			string whereSql = "";
			if(descuento_llegada_tardia_idNull)
				whereSql += "DESCUENTO_LLEGADA_TARDIA_ID IS NULL";
			else
				whereSql += "DESCUENTO_LLEGADA_TARDIA_ID=" + _db.CreateSqlParameterName("DESCUENTO_LLEGADA_TARDIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!descuento_llegada_tardia_idNull)
				AddParameter(cmd, "DESCUENTO_LLEGADA_TARDIA_ID", descuento_llegada_tardia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MARCACIONES</c> table using the 
		/// <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return DeleteByFUNCIONARIO_ID(funcionario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MARCACIONES</c> table using the 
		/// <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id, bool funcionario_idNull)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id, funcionario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <param name="funcionario_idNull">true if the method ignores the funcionario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id, bool funcionario_idNull)
		{
			string whereSql = "";
			if(funcionario_idNull)
				whereSql += "FUNCIONARIO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_idNull)
				AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>MARCACIONES</c> table using the 
		/// <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTURNO_ID(decimal turno_id)
		{
			return DeleteByTURNO_ID(turno_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>MARCACIONES</c> table using the 
		/// <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <param name="turno_idNull">true if the method ignores the turno_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTURNO_ID(decimal turno_id, bool turno_idNull)
		{
			return CreateDeleteByTURNO_IDCommand(turno_id, turno_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TURNO_ID</c> foreign key.
		/// </summary>
		/// <param name="turno_id">The <c>TURNO_ID</c> column value.</param>
		/// <param name="turno_idNull">true if the method ignores the turno_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTURNO_IDCommand(decimal turno_id, bool turno_idNull)
		{
			string whereSql = "";
			if(turno_idNull)
				whereSql += "TURNO_ID IS NULL";
			else
				whereSql += "TURNO_ID=" + _db.CreateSqlParameterName("TURNO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!turno_idNull)
				AddParameter(cmd, "TURNO_ID", turno_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>MARCACIONES</c> records that match the specified criteria.
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
		/// to delete <c>MARCACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.MARCACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>MARCACIONES</c> table.
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
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		protected MARCACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		protected MARCACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MARCACIONESRow"/> objects.</returns>
		protected virtual MARCACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int reloj_marcacion_idColumnIndex = reader.GetOrdinal("RELOJ_MARCACION_ID");
			int reloj_funcionario_idColumnIndex = reader.GetOrdinal("RELOJ_FUNCIONARIO_ID");
			int fecha_marcacionColumnIndex = reader.GetOrdinal("FECHA_MARCACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int calificacionColumnIndex = reader.GetOrdinal("CALIFICACION");
			int es_copiadoColumnIndex = reader.GetOrdinal("ES_COPIADO");
			int justificadoColumnIndex = reader.GetOrdinal("JUSTIFICADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int tipo_movimientoColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO");
			int fecha_copiadoColumnIndex = reader.GetOrdinal("FECHA_COPIADO");
			int descontarColumnIndex = reader.GetOrdinal("DESCONTAR");
			int descontadoColumnIndex = reader.GetOrdinal("DESCONTADO");
			int idColumnIndex = reader.GetOrdinal("ID");
			int turno_entrada_antesColumnIndex = reader.GetOrdinal("TURNO_ENTRADA_ANTES");
			int turno_entradaColumnIndex = reader.GetOrdinal("TURNO_ENTRADA");
			int turno_entrada_despuesColumnIndex = reader.GetOrdinal("TURNO_ENTRADA_DESPUES");
			int turno_salida_antesColumnIndex = reader.GetOrdinal("TURNO_SALIDA_ANTES");
			int turno_salidaColumnIndex = reader.GetOrdinal("TURNO_SALIDA");
			int turno_salida_despuesColumnIndex = reader.GetOrdinal("TURNO_SALIDA_DESPUES");
			int turno_idColumnIndex = reader.GetOrdinal("TURNO_ID");
			int descuento_llegada_tardia_idColumnIndex = reader.GetOrdinal("DESCUENTO_LLEGADA_TARDIA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					MARCACIONESRow record = new MARCACIONESRow();
					recordList.Add(record);

					if(!reader.IsDBNull(reloj_marcacion_idColumnIndex))
						record.RELOJ_MARCACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reloj_marcacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(reloj_funcionario_idColumnIndex))
						record.RELOJ_FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reloj_funcionario_idColumnIndex)), 9);
					record.FECHA_MARCACION = Convert.ToDateTime(reader.GetValue(fecha_marcacionColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(calificacionColumnIndex))
						record.CALIFICACION = Math.Round(Convert.ToDecimal(reader.GetValue(calificacionColumnIndex)), 9);
					if(!reader.IsDBNull(es_copiadoColumnIndex))
						record.ES_COPIADO = Convert.ToString(reader.GetValue(es_copiadoColumnIndex));
					if(!reader.IsDBNull(justificadoColumnIndex))
						record.JUSTIFICADO = Convert.ToString(reader.GetValue(justificadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(tipo_movimientoColumnIndex))
						record.TIPO_MOVIMIENTO = Convert.ToString(reader.GetValue(tipo_movimientoColumnIndex));
					if(!reader.IsDBNull(fecha_copiadoColumnIndex))
						record.FECHA_COPIADO = Convert.ToDateTime(reader.GetValue(fecha_copiadoColumnIndex));
					if(!reader.IsDBNull(descontarColumnIndex))
						record.DESCONTAR = Convert.ToString(reader.GetValue(descontarColumnIndex));
					if(!reader.IsDBNull(descontadoColumnIndex))
						record.DESCONTADO = Convert.ToString(reader.GetValue(descontadoColumnIndex));
					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(turno_entrada_antesColumnIndex))
						record.TURNO_ENTRADA_ANTES = Convert.ToDateTime(reader.GetValue(turno_entrada_antesColumnIndex));
					if(!reader.IsDBNull(turno_entradaColumnIndex))
						record.TURNO_ENTRADA = Convert.ToDateTime(reader.GetValue(turno_entradaColumnIndex));
					if(!reader.IsDBNull(turno_entrada_despuesColumnIndex))
						record.TURNO_ENTRADA_DESPUES = Convert.ToDateTime(reader.GetValue(turno_entrada_despuesColumnIndex));
					if(!reader.IsDBNull(turno_salida_antesColumnIndex))
						record.TURNO_SALIDA_ANTES = Convert.ToDateTime(reader.GetValue(turno_salida_antesColumnIndex));
					if(!reader.IsDBNull(turno_salidaColumnIndex))
						record.TURNO_SALIDA = Convert.ToDateTime(reader.GetValue(turno_salidaColumnIndex));
					if(!reader.IsDBNull(turno_salida_despuesColumnIndex))
						record.TURNO_SALIDA_DESPUES = Convert.ToDateTime(reader.GetValue(turno_salida_despuesColumnIndex));
					if(!reader.IsDBNull(turno_idColumnIndex))
						record.TURNO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(turno_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_llegada_tardia_idColumnIndex))
						record.DESCUENTO_LLEGADA_TARDIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_llegada_tardia_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MARCACIONESRow[])(recordList.ToArray(typeof(MARCACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MARCACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MARCACIONESRow"/> object.</returns>
		protected virtual MARCACIONESRow MapRow(DataRow row)
		{
			MARCACIONESRow mappedObject = new MARCACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "RELOJ_MARCACION_ID"
			dataColumn = dataTable.Columns["RELOJ_MARCACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RELOJ_MARCACION_ID = (decimal)row[dataColumn];
			// Column "RELOJ_FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["RELOJ_FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RELOJ_FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA_MARCACION"
			dataColumn = dataTable.Columns["FECHA_MARCACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MARCACION = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "CALIFICACION"
			dataColumn = dataTable.Columns["CALIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALIFICACION = (decimal)row[dataColumn];
			// Column "ES_COPIADO"
			dataColumn = dataTable.Columns["ES_COPIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COPIADO = (string)row[dataColumn];
			// Column "JUSTIFICADO"
			dataColumn = dataTable.Columns["JUSTIFICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.JUSTIFICADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TIPO_MOVIMIENTO"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO = (string)row[dataColumn];
			// Column "FECHA_COPIADO"
			dataColumn = dataTable.Columns["FECHA_COPIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COPIADO = (System.DateTime)row[dataColumn];
			// Column "DESCONTAR"
			dataColumn = dataTable.Columns["DESCONTAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONTAR = (string)row[dataColumn];
			// Column "DESCONTADO"
			dataColumn = dataTable.Columns["DESCONTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONTADO = (string)row[dataColumn];
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TURNO_ENTRADA_ANTES"
			dataColumn = dataTable.Columns["TURNO_ENTRADA_ANTES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ENTRADA_ANTES = (System.DateTime)row[dataColumn];
			// Column "TURNO_ENTRADA"
			dataColumn = dataTable.Columns["TURNO_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ENTRADA = (System.DateTime)row[dataColumn];
			// Column "TURNO_ENTRADA_DESPUES"
			dataColumn = dataTable.Columns["TURNO_ENTRADA_DESPUES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ENTRADA_DESPUES = (System.DateTime)row[dataColumn];
			// Column "TURNO_SALIDA_ANTES"
			dataColumn = dataTable.Columns["TURNO_SALIDA_ANTES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_SALIDA_ANTES = (System.DateTime)row[dataColumn];
			// Column "TURNO_SALIDA"
			dataColumn = dataTable.Columns["TURNO_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_SALIDA = (System.DateTime)row[dataColumn];
			// Column "TURNO_SALIDA_DESPUES"
			dataColumn = dataTable.Columns["TURNO_SALIDA_DESPUES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_SALIDA_DESPUES = (System.DateTime)row[dataColumn];
			// Column "TURNO_ID"
			dataColumn = dataTable.Columns["TURNO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_LLEGADA_TARDIA_ID"
			dataColumn = dataTable.Columns["DESCUENTO_LLEGADA_TARDIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_LLEGADA_TARDIA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>MARCACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MARCACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("RELOJ_MARCACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RELOJ_FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_MARCACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALIFICACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_COPIADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("JUSTIFICADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("FECHA_COPIADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("DESCONTAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DESCONTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TURNO_ENTRADA_ANTES", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TURNO_ENTRADA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TURNO_ENTRADA_DESPUES", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TURNO_SALIDA_ANTES", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TURNO_SALIDA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TURNO_SALIDA_DESPUES", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TURNO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_LLEGADA_TARDIA_ID", typeof(decimal));
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
				case "RELOJ_MARCACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RELOJ_FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_MARCACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_COPIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "JUSTIFICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				case "TIPO_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_COPIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESCONTAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCONTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TURNO_ENTRADA_ANTES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_ENTRADA_DESPUES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_SALIDA_ANTES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_SALIDA_DESPUES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_LLEGADA_TARDIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of MARCACIONESCollection_Base class
}  // End of namespace
