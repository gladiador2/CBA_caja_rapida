// <fileinfo name="FUNCIONARIOS_BONIFICACIONESCollection_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_BONIFICACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FUNCIONARIOS_BONIFICACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_BONIFICACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string BONIFICACION_IDColumnName = "BONIFICACION_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string EMPRESA_SECCION_IDColumnName = "EMPRESA_SECCION_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string UTILIZAR_PORCENTAJEColumnName = "UTILIZAR_PORCENTAJE";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string LIQUIDACION_ASOCIADA_IDColumnName = "LIQUIDACION_ASOCIADA_ID";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_BONIFICACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FUNCIONARIOS_BONIFICACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FUNCIONARIOS_BONIFICACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FUNCIONARIOS_BONIFICACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public FUNCIONARIOS_BONIFICACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FUNCIONARIOS_BONIFICACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FUNCIONARIOS_BONIFICACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_BONIF_FUNCIONARIO_ID</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public FUNCIONARIOS_BONIFICACIONESRow[] GetByLIQUIDACION_ASOCIADA_ID(decimal liquidacion_asociada_id)
		{
			return GetByLIQUIDACION_ASOCIADA_ID(liquidacion_asociada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <param name="liquidacion_asociada_idNull">true if the method ignores the liquidacion_asociada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetByLIQUIDACION_ASOCIADA_ID(decimal liquidacion_asociada_id, bool liquidacion_asociada_idNull)
		{
			return MapRecords(CreateGetByLIQUIDACION_ASOCIADA_IDCommand(liquidacion_asociada_id, liquidacion_asociada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLIQUIDACION_ASOCIADA_IDAsDataTable(decimal liquidacion_asociada_id)
		{
			return GetByLIQUIDACION_ASOCIADA_IDAsDataTable(liquidacion_asociada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <param name="liquidacion_asociada_idNull">true if the method ignores the liquidacion_asociada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLIQUIDACION_ASOCIADA_IDAsDataTable(decimal liquidacion_asociada_id, bool liquidacion_asociada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLIQUIDACION_ASOCIADA_IDCommand(liquidacion_asociada_id, liquidacion_asociada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <param name="liquidacion_asociada_idNull">true if the method ignores the liquidacion_asociada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLIQUIDACION_ASOCIADA_IDCommand(decimal liquidacion_asociada_id, bool liquidacion_asociada_idNull)
		{
			string whereSql = "";
			if(liquidacion_asociada_idNull)
				whereSql += "LIQUIDACION_ASOCIADA_ID IS NULL";
			else
				whereSql += "LIQUIDACION_ASOCIADA_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ASOCIADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!liquidacion_asociada_idNull)
				AddParameter(cmd, "LIQUIDACION_ASOCIADA_ID", liquidacion_asociada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_BONIF_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public FUNCIONARIOS_BONIFICACIONESRow[] GetByEMPRESA_SECCION_ID(decimal empresa_seccion_id)
		{
			return GetByEMPRESA_SECCION_ID(empresa_seccion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetByEMPRESA_SECCION_ID(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			return MapRecords(CreateGetByEMPRESA_SECCION_IDCommand(empresa_seccion_id, empresa_seccion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEMPRESA_SECCION_IDAsDataTable(decimal empresa_seccion_id)
		{
			return GetByEMPRESA_SECCION_IDAsDataTable(empresa_seccion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEMPRESA_SECCION_IDAsDataTable(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEMPRESA_SECCION_IDCommand(empresa_seccion_id, empresa_seccion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEMPRESA_SECCION_IDCommand(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			string whereSql = "";
			if(empresa_seccion_idNull)
				whereSql += "EMPRESA_SECCION_ID IS NULL";
			else
				whereSql += "EMPRESA_SECCION_ID=" + _db.CreateSqlParameterName("EMPRESA_SECCION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!empresa_seccion_idNull)
				AddParameter(cmd, "EMPRESA_SECCION_ID", empresa_seccion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_TIPO_BONIF_ID</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetByBONIFICACION_ID(decimal bonificacion_id)
		{
			return MapRecords(CreateGetByBONIFICACION_IDCommand(bonificacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_TIPO_BONIF_ID</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBONIFICACION_IDAsDataTable(decimal bonificacion_id)
		{
			return MapRecordsToDataTable(CreateGetByBONIFICACION_IDCommand(bonificacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_BONIF_TIPO_BONIF_ID</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBONIFICACION_IDCommand(decimal bonificacion_id)
		{
			string whereSql = "";
			whereSql += "BONIFICACION_ID=" + _db.CreateSqlParameterName("BONIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "BONIFICACION_ID", bonificacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects 
		/// by the <c>FK_FUNC_BONIF_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_BONIFICACIONESRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_BONIF_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_BONIF_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(FUNCIONARIOS_BONIFICACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FUNCIONARIOS_BONIFICACIONES (" +
				"ID, " +
				"BONIFICACION_ID, " +
				"FUNCIONARIO_ID, " +
				"EMPRESA_SECCION_ID, " +
				"OBSERVACION, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO, " +
				"UTILIZAR_PORCENTAJE, " +
				"FECHA_CREACION, " +
				"USUARIO_CREACION_ID, " +
				"LIQUIDACION_ASOCIADA_ID, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("BONIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("EMPRESA_SECCION_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("UTILIZAR_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("LIQUIDACION_ASOCIADA_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "BONIFICACION_ID", value.BONIFICACION_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "EMPRESA_SECCION_ID",
				value.IsEMPRESA_SECCION_IDNull ? DBNull.Value : (object)value.EMPRESA_SECCION_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "UTILIZAR_PORCENTAJE", value.UTILIZAR_PORCENTAJE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "LIQUIDACION_ASOCIADA_ID",
				value.IsLIQUIDACION_ASOCIADA_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ASOCIADA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_BONIFICACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FUNCIONARIOS_BONIFICACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.FUNCIONARIOS_BONIFICACIONES SET " +
				"BONIFICACION_ID=" + _db.CreateSqlParameterName("BONIFICACION_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"EMPRESA_SECCION_ID=" + _db.CreateSqlParameterName("EMPRESA_SECCION_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"UTILIZAR_PORCENTAJE=" + _db.CreateSqlParameterName("UTILIZAR_PORCENTAJE") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"LIQUIDACION_ASOCIADA_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ASOCIADA_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "BONIFICACION_ID", value.BONIFICACION_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "EMPRESA_SECCION_ID",
				value.IsEMPRESA_SECCION_IDNull ? DBNull.Value : (object)value.EMPRESA_SECCION_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "UTILIZAR_PORCENTAJE", value.UTILIZAR_PORCENTAJE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "LIQUIDACION_ASOCIADA_ID",
				value.IsLIQUIDACION_ASOCIADA_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ASOCIADA_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_BONIFICACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_BONIFICACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FUNCIONARIOS_BONIFICACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using
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
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_BONIF_FUNCIONARIO_ID</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLIQUIDACION_ASOCIADA_ID(decimal liquidacion_asociada_id)
		{
			return DeleteByLIQUIDACION_ASOCIADA_ID(liquidacion_asociada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <param name="liquidacion_asociada_idNull">true if the method ignores the liquidacion_asociada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLIQUIDACION_ASOCIADA_ID(decimal liquidacion_asociada_id, bool liquidacion_asociada_idNull)
		{
			return CreateDeleteByLIQUIDACION_ASOCIADA_IDCommand(liquidacion_asociada_id, liquidacion_asociada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_BONIF_LIQ_ASOC_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_asociada_id">The <c>LIQUIDACION_ASOCIADA_ID</c> column value.</param>
		/// <param name="liquidacion_asociada_idNull">true if the method ignores the liquidacion_asociada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLIQUIDACION_ASOCIADA_IDCommand(decimal liquidacion_asociada_id, bool liquidacion_asociada_idNull)
		{
			string whereSql = "";
			if(liquidacion_asociada_idNull)
				whereSql += "LIQUIDACION_ASOCIADA_ID IS NULL";
			else
				whereSql += "LIQUIDACION_ASOCIADA_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ASOCIADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!liquidacion_asociada_idNull)
				AddParameter(cmd, "LIQUIDACION_ASOCIADA_ID", liquidacion_asociada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_BONIF_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEMPRESA_SECCION_ID(decimal empresa_seccion_id)
		{
			return DeleteByEMPRESA_SECCION_ID(empresa_seccion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEMPRESA_SECCION_ID(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			return CreateDeleteByEMPRESA_SECCION_IDCommand(empresa_seccion_id, empresa_seccion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_BONIF_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEMPRESA_SECCION_IDCommand(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			string whereSql = "";
			if(empresa_seccion_idNull)
				whereSql += "EMPRESA_SECCION_ID IS NULL";
			else
				whereSql += "EMPRESA_SECCION_ID=" + _db.CreateSqlParameterName("EMPRESA_SECCION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!empresa_seccion_idNull)
				AddParameter(cmd, "EMPRESA_SECCION_ID", empresa_seccion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_TIPO_BONIF_ID</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBONIFICACION_ID(decimal bonificacion_id)
		{
			return CreateDeleteByBONIFICACION_IDCommand(bonificacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_BONIF_TIPO_BONIF_ID</c> foreign key.
		/// </summary>
		/// <param name="bonificacion_id">The <c>BONIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBONIFICACION_IDCommand(decimal bonificacion_id)
		{
			string whereSql = "";
			whereSql += "BONIFICACION_ID=" + _db.CreateSqlParameterName("BONIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "BONIFICACION_ID", bonificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table using the 
		/// <c>FK_FUNC_BONIF_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_BONIF_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FUNCIONARIOS_BONIFICACIONES</c> records that match the specified criteria.
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
		/// to delete <c>FUNCIONARIOS_BONIFICACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FUNCIONARIOS_BONIFICACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
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
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		protected FUNCIONARIOS_BONIFICACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		protected FUNCIONARIOS_BONIFICACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> objects.</returns>
		protected virtual FUNCIONARIOS_BONIFICACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int bonificacion_idColumnIndex = reader.GetOrdinal("BONIFICACION_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int empresa_seccion_idColumnIndex = reader.GetOrdinal("EMPRESA_SECCION_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int utilizar_porcentajeColumnIndex = reader.GetOrdinal("UTILIZAR_PORCENTAJE");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int liquidacion_asociada_idColumnIndex = reader.GetOrdinal("LIQUIDACION_ASOCIADA_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FUNCIONARIOS_BONIFICACIONESRow record = new FUNCIONARIOS_BONIFICACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.BONIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(bonificacion_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(empresa_seccion_idColumnIndex))
						record.EMPRESA_SECCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(empresa_seccion_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.UTILIZAR_PORCENTAJE = Convert.ToString(reader.GetValue(utilizar_porcentajeColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(liquidacion_asociada_idColumnIndex))
						record.LIQUIDACION_ASOCIADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(liquidacion_asociada_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FUNCIONARIOS_BONIFICACIONESRow[])(recordList.ToArray(typeof(FUNCIONARIOS_BONIFICACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FUNCIONARIOS_BONIFICACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FUNCIONARIOS_BONIFICACIONESRow"/> object.</returns>
		protected virtual FUNCIONARIOS_BONIFICACIONESRow MapRow(DataRow row)
		{
			FUNCIONARIOS_BONIFICACIONESRow mappedObject = new FUNCIONARIOS_BONIFICACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "BONIFICACION_ID"
			dataColumn = dataTable.Columns["BONIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BONIFICACION_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "EMPRESA_SECCION_ID"
			dataColumn = dataTable.Columns["EMPRESA_SECCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_SECCION_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "UTILIZAR_PORCENTAJE"
			dataColumn = dataTable.Columns["UTILIZAR_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.UTILIZAR_PORCENTAJE = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "LIQUIDACION_ASOCIADA_ID"
			dataColumn = dataTable.Columns["LIQUIDACION_ASOCIADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIQUIDACION_ASOCIADA_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FUNCIONARIOS_BONIFICACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FUNCIONARIOS_BONIFICACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BONIFICACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EMPRESA_SECCION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UTILIZAR_PORCENTAJE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIQUIDACION_ASOCIADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "BONIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_SECCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UTILIZAR_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIQUIDACION_ASOCIADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FUNCIONARIOS_BONIFICACIONESCollection_Base class
}  // End of namespace
