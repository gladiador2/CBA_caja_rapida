// <fileinfo name="FUNCIONARIOS_LIQUIDACIONESCollection_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_LIQUIDACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FUNCIONARIOS_LIQUIDACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_LIQUIDACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string TIPOColumnName = "TIPO";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string TOTAL_SALARIOColumnName = "TOTAL_SALARIO";
		public const string TOTAL_DESCUENTOColumnName = "TOTAL_DESCUENTO";
		public const string TOTAL_BONIFICACIONESColumnName = "TOTAL_BONIFICACIONES";
		public const string TOTAL_COBRARColumnName = "TOTAL_COBRAR";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string PLANILLA_SALARIO_IDColumnName = "PLANILLA_SALARIO_ID";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string DIAS_TRABAJADOSColumnName = "DIAS_TRABAJADOS";
		public const string TOTAL_APORTES_EMPRESAColumnName = "TOTAL_APORTES_EMPRESA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_LIQUIDACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FUNCIONARIOS_LIQUIDACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FUNCIONARIOS_LIQUIDACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FUNCIONARIOS_LIQUIDACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public FUNCIONARIOS_LIQUIDACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FUNCIONARIOS_LIQUIDACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FUNCIONARIOS_LIQUIDACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects 
		/// by the <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public FUNCIONARIOS_LIQUIDACIONESRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects 
		/// by the <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects 
		/// by the <c>FK_FUNC_LIQ_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_LIQ_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_LIQ_FUNCIONARIO</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects 
		/// by the <c>FK_FUNC_LIQ_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_LIQ_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_LIQ_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects 
		/// by the <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public FUNCIONARIOS_LIQUIDACIONESRow[] GetByPLANILLA_SALARIO_ID(decimal planilla_salario_id)
		{
			return GetByPLANILLA_SALARIO_ID(planilla_salario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects 
		/// by the <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <param name="planilla_salario_idNull">true if the method ignores the planilla_salario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow[] GetByPLANILLA_SALARIO_ID(decimal planilla_salario_id, bool planilla_salario_idNull)
		{
			return MapRecords(CreateGetByPLANILLA_SALARIO_IDCommand(planilla_salario_id, planilla_salario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPLANILLA_SALARIO_IDAsDataTable(decimal planilla_salario_id)
		{
			return GetByPLANILLA_SALARIO_IDAsDataTable(planilla_salario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <param name="planilla_salario_idNull">true if the method ignores the planilla_salario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLANILLA_SALARIO_IDAsDataTable(decimal planilla_salario_id, bool planilla_salario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPLANILLA_SALARIO_IDCommand(planilla_salario_id, planilla_salario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <param name="planilla_salario_idNull">true if the method ignores the planilla_salario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLANILLA_SALARIO_IDCommand(decimal planilla_salario_id, bool planilla_salario_idNull)
		{
			string whereSql = "";
			if(planilla_salario_idNull)
				whereSql += "PLANILLA_SALARIO_ID IS NULL";
			else
				whereSql += "PLANILLA_SALARIO_ID=" + _db.CreateSqlParameterName("PLANILLA_SALARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!planilla_salario_idNull)
				AddParameter(cmd, "PLANILLA_SALARIO_ID", planilla_salario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects 
		/// by the <c>FK_FUNC_LIQ_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_LIQUIDACIONESRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_LIQ_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_LIQ_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(FUNCIONARIOS_LIQUIDACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FUNCIONARIOS_LIQUIDACIONES (" +
				"ID, " +
				"FECHA_CREACION, " +
				"FUNCIONARIO_ID, " +
				"TIPO, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"USUARIO_ID, " +
				"TOTAL_SALARIO, " +
				"TOTAL_DESCUENTO, " +
				"TOTAL_BONIFICACIONES, " +
				"TOTAL_COBRAR, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"OBSERVACION, " +
				"PLANILLA_SALARIO_ID, " +
				"CASO_ASOCIADO_ID, " +
				"DIAS_TRABAJADOS, " +
				"TOTAL_APORTES_EMPRESA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("TIPO") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("TOTAL_SALARIO") + ", " +
				_db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_BONIFICACIONES") + ", " +
				_db.CreateSqlParameterName("TOTAL_COBRAR") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("PLANILLA_SALARIO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("DIAS_TRABAJADOS") + ", " +
				_db.CreateSqlParameterName("TOTAL_APORTES_EMPRESA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN", value.FECHA_FIN);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "TOTAL_SALARIO", value.TOTAL_SALARIO);
			AddParameter(cmd, "TOTAL_DESCUENTO", value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_BONIFICACIONES", value.TOTAL_BONIFICACIONES);
			AddParameter(cmd, "TOTAL_COBRAR", value.TOTAL_COBRAR);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "PLANILLA_SALARIO_ID",
				value.IsPLANILLA_SALARIO_IDNull ? DBNull.Value : (object)value.PLANILLA_SALARIO_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "DIAS_TRABAJADOS",
				value.IsDIAS_TRABAJADOSNull ? DBNull.Value : (object)value.DIAS_TRABAJADOS);
			AddParameter(cmd, "TOTAL_APORTES_EMPRESA", value.TOTAL_APORTES_EMPRESA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FUNCIONARIOS_LIQUIDACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.FUNCIONARIOS_LIQUIDACIONES SET " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"TIPO=" + _db.CreateSqlParameterName("TIPO") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"TOTAL_SALARIO=" + _db.CreateSqlParameterName("TOTAL_SALARIO") + ", " +
				"TOTAL_DESCUENTO=" + _db.CreateSqlParameterName("TOTAL_DESCUENTO") + ", " +
				"TOTAL_BONIFICACIONES=" + _db.CreateSqlParameterName("TOTAL_BONIFICACIONES") + ", " +
				"TOTAL_COBRAR=" + _db.CreateSqlParameterName("TOTAL_COBRAR") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"PLANILLA_SALARIO_ID=" + _db.CreateSqlParameterName("PLANILLA_SALARIO_ID") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"DIAS_TRABAJADOS=" + _db.CreateSqlParameterName("DIAS_TRABAJADOS") + ", " +
				"TOTAL_APORTES_EMPRESA=" + _db.CreateSqlParameterName("TOTAL_APORTES_EMPRESA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN", value.FECHA_FIN);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "TOTAL_SALARIO", value.TOTAL_SALARIO);
			AddParameter(cmd, "TOTAL_DESCUENTO", value.TOTAL_DESCUENTO);
			AddParameter(cmd, "TOTAL_BONIFICACIONES", value.TOTAL_BONIFICACIONES);
			AddParameter(cmd, "TOTAL_COBRAR", value.TOTAL_COBRAR);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "PLANILLA_SALARIO_ID",
				value.IsPLANILLA_SALARIO_IDNull ? DBNull.Value : (object)value.PLANILLA_SALARIO_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "DIAS_TRABAJADOS",
				value.IsDIAS_TRABAJADOSNull ? DBNull.Value : (object)value.DIAS_TRABAJADOS);
			AddParameter(cmd, "TOTAL_APORTES_EMPRESA", value.TOTAL_APORTES_EMPRESA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_LIQUIDACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_LIQUIDACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FUNCIONARIOS_LIQUIDACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using
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
		/// Deletes records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using the 
		/// <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using the 
		/// <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_LIQ_CASO_ASO</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using the 
		/// <c>FK_FUNC_LIQ_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_LIQ_FUNCIONARIO</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using the 
		/// <c>FK_FUNC_LIQ_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_LIQ_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using the 
		/// <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_SALARIO_ID(decimal planilla_salario_id)
		{
			return DeleteByPLANILLA_SALARIO_ID(planilla_salario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using the 
		/// <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <param name="planilla_salario_idNull">true if the method ignores the planilla_salario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLANILLA_SALARIO_ID(decimal planilla_salario_id, bool planilla_salario_idNull)
		{
			return CreateDeleteByPLANILLA_SALARIO_IDCommand(planilla_salario_id, planilla_salario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_LIQ_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="planilla_salario_id">The <c>PLANILLA_SALARIO_ID</c> column value.</param>
		/// <param name="planilla_salario_idNull">true if the method ignores the planilla_salario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLANILLA_SALARIO_IDCommand(decimal planilla_salario_id, bool planilla_salario_idNull)
		{
			string whereSql = "";
			if(planilla_salario_idNull)
				whereSql += "PLANILLA_SALARIO_ID IS NULL";
			else
				whereSql += "PLANILLA_SALARIO_ID=" + _db.CreateSqlParameterName("PLANILLA_SALARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!planilla_salario_idNull)
				AddParameter(cmd, "PLANILLA_SALARIO_ID", planilla_salario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table using the 
		/// <c>FK_FUNC_LIQ_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_LIQ_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FUNCIONARIOS_LIQUIDACIONES</c> records that match the specified criteria.
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
		/// to delete <c>FUNCIONARIOS_LIQUIDACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FUNCIONARIOS_LIQUIDACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		protected FUNCIONARIOS_LIQUIDACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		protected FUNCIONARIOS_LIQUIDACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> objects.</returns>
		protected virtual FUNCIONARIOS_LIQUIDACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int total_salarioColumnIndex = reader.GetOrdinal("TOTAL_SALARIO");
			int total_descuentoColumnIndex = reader.GetOrdinal("TOTAL_DESCUENTO");
			int total_bonificacionesColumnIndex = reader.GetOrdinal("TOTAL_BONIFICACIONES");
			int total_cobrarColumnIndex = reader.GetOrdinal("TOTAL_COBRAR");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int planilla_salario_idColumnIndex = reader.GetOrdinal("PLANILLA_SALARIO_ID");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int dias_trabajadosColumnIndex = reader.GetOrdinal("DIAS_TRABAJADOS");
			int total_aportes_empresaColumnIndex = reader.GetOrdinal("TOTAL_APORTES_EMPRESA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FUNCIONARIOS_LIQUIDACIONESRow record = new FUNCIONARIOS_LIQUIDACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(tipoColumnIndex)), 9);
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.TOTAL_SALARIO = Math.Round(Convert.ToDecimal(reader.GetValue(total_salarioColumnIndex)), 9);
					record.TOTAL_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_descuentoColumnIndex)), 9);
					record.TOTAL_BONIFICACIONES = Math.Round(Convert.ToDecimal(reader.GetValue(total_bonificacionesColumnIndex)), 9);
					record.TOTAL_COBRAR = Math.Round(Convert.ToDecimal(reader.GetValue(total_cobrarColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(planilla_salario_idColumnIndex))
						record.PLANILLA_SALARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_salario_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(dias_trabajadosColumnIndex))
						record.DIAS_TRABAJADOS = Math.Round(Convert.ToDecimal(reader.GetValue(dias_trabajadosColumnIndex)), 9);
					record.TOTAL_APORTES_EMPRESA = Math.Round(Convert.ToDecimal(reader.GetValue(total_aportes_empresaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FUNCIONARIOS_LIQUIDACIONESRow[])(recordList.ToArray(typeof(FUNCIONARIOS_LIQUIDACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FUNCIONARIOS_LIQUIDACIONESRow"/> object.</returns>
		protected virtual FUNCIONARIOS_LIQUIDACIONESRow MapRow(DataRow row)
		{
			FUNCIONARIOS_LIQUIDACIONESRow mappedObject = new FUNCIONARIOS_LIQUIDACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "TOTAL_SALARIO"
			dataColumn = dataTable.Columns["TOTAL_SALARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_SALARIO = (decimal)row[dataColumn];
			// Column "TOTAL_DESCUENTO"
			dataColumn = dataTable.Columns["TOTAL_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DESCUENTO = (decimal)row[dataColumn];
			// Column "TOTAL_BONIFICACIONES"
			dataColumn = dataTable.Columns["TOTAL_BONIFICACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BONIFICACIONES = (decimal)row[dataColumn];
			// Column "TOTAL_COBRAR"
			dataColumn = dataTable.Columns["TOTAL_COBRAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COBRAR = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "PLANILLA_SALARIO_ID"
			dataColumn = dataTable.Columns["PLANILLA_SALARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_SALARIO_ID = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "DIAS_TRABAJADOS"
			dataColumn = dataTable.Columns["DIAS_TRABAJADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_TRABAJADOS = (decimal)row[dataColumn];
			// Column "TOTAL_APORTES_EMPRESA"
			dataColumn = dataTable.Columns["TOTAL_APORTES_EMPRESA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_APORTES_EMPRESA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FUNCIONARIOS_LIQUIDACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FUNCIONARIOS_LIQUIDACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_SALARIO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_BONIFICACIONES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_COBRAR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("PLANILLA_SALARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DIAS_TRABAJADOS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_APORTES_EMPRESA", typeof(decimal));
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

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_SALARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BONIFICACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COBRAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PLANILLA_SALARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIAS_TRABAJADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_APORTES_EMPRESA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FUNCIONARIOS_LIQUIDACIONESCollection_Base class
}  // End of namespace
