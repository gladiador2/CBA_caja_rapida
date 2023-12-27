// <fileinfo name="FUNCIONARIOS_DESCUENTOSCollection_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_DESCUENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FUNCIONARIOS_DESCUENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_DESCUENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string DESCUENTO_IDColumnName = "DESCUENTO_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string EMPRESA_SECCION_IDColumnName = "EMPRESA_SECCION_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string UTILIZAR_PORCENTAJEColumnName = "UTILIZAR_PORCENTAJE";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string LIQUIDACION_ASOCIADA_IDColumnName = "LIQUIDACION_ASOCIADA_ID";
		public const string CONSUMO_VISITASColumnName = "CONSUMO_VISITAS";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string CASO_ORIGEN_IDColumnName = "CASO_ORIGEN_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_DESCUENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FUNCIONARIOS_DESCUENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FUNCIONARIOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FUNCIONARIOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FUNCIONARIOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FUNCIONARIOS_DESCUENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FUNCIONARIOS_DESCUENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public FUNCIONARIOS_DESCUENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FUNCIONARIOS_DESCUENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FUNCIONARIOS_DESCUENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FUNCIONARIOS_DESCUENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public FUNCIONARIOS_DESCUENTOSRow[] GetByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return GetByCASO_ORIGEN_ID(caso_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetByCASO_ORIGEN_ID(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return MapRecords(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ORIGEN_IDAsDataTable(decimal caso_origen_id)
		{
			return GetByCASO_ORIGEN_IDAsDataTable(caso_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ORIGEN_IDAsDataTable(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ORIGEN_IDCommand(decimal caso_origen_id, bool caso_origen_idNull)
		{
			string whereSql = "";
			if(caso_origen_idNull)
				whereSql += "CASO_ORIGEN_ID IS NULL";
			else
				whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_origen_idNull)
				AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_DESCUENTO_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetByDESCUENTO_ID(decimal descuento_id)
		{
			return MapRecords(CreateGetByDESCUENTO_IDCommand(descuento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_DESCUENTO_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_IDAsDataTable(decimal descuento_id)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_IDCommand(descuento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_DESC_DESCUENTO_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_IDCommand(decimal descuento_id)
		{
			string whereSql = "";
			whereSql += "DESCUENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DESCUENTO_ID", descuento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_DESC_FUNCIONARIO_ID</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_DESC_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public FUNCIONARIOS_DESCUENTOSRow[] GetByEMPRESA_SECCION_ID(decimal empresa_seccion_id)
		{
			return GetByEMPRESA_SECCION_ID(empresa_seccion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <param name="empresa_seccion_idNull">true if the method ignores the empresa_seccion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetByEMPRESA_SECCION_ID(decimal empresa_seccion_id, bool empresa_seccion_idNull)
		{
			return MapRecords(CreateGetByEMPRESA_SECCION_IDCommand(empresa_seccion_id, empresa_seccion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEMPRESA_SECCION_IDAsDataTable(decimal empresa_seccion_id)
		{
			return GetByEMPRESA_SECCION_IDAsDataTable(empresa_seccion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
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
		/// return records by the <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects 
		/// by the <c>FK_FUNC_DESC_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		public virtual FUNCIONARIOS_DESCUENTOSRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_DESC_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_DESC_USUARIO_CREAC_ID</c> foreign key.
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
		/// Adds a new record into the <c>FUNCIONARIOS_DESCUENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_DESCUENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(FUNCIONARIOS_DESCUENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FUNCIONARIOS_DESCUENTOS (" +
				"ID, " +
				"DESCUENTO_ID, " +
				"FUNCIONARIO_ID, " +
				"EMPRESA_SECCION_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO, " +
				"UTILIZAR_PORCENTAJE, " +
				"FECHA_CREACION, " +
				"USUARIO_CREACION_ID, " +
				"LIQUIDACION_ASOCIADA_ID, " +
				"CONSUMO_VISITAS, " +
				"OBSERVACION, " +
				"ESTADO, " +
				"CASO_ORIGEN_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("EMPRESA_SECCION_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("UTILIZAR_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("LIQUIDACION_ASOCIADA_ID") + ", " +
				_db.CreateSqlParameterName("CONSUMO_VISITAS") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CASO_ORIGEN_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "DESCUENTO_ID", value.DESCUENTO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "EMPRESA_SECCION_ID",
				value.IsEMPRESA_SECCION_IDNull ? DBNull.Value : (object)value.EMPRESA_SECCION_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "UTILIZAR_PORCENTAJE", value.UTILIZAR_PORCENTAJE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "LIQUIDACION_ASOCIADA_ID",
				value.IsLIQUIDACION_ASOCIADA_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ASOCIADA_ID);
			AddParameter(cmd, "CONSUMO_VISITAS", value.CONSUMO_VISITAS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CASO_ORIGEN_ID",
				value.IsCASO_ORIGEN_IDNull ? DBNull.Value : (object)value.CASO_ORIGEN_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FUNCIONARIOS_DESCUENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_DESCUENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FUNCIONARIOS_DESCUENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.FUNCIONARIOS_DESCUENTOS SET " +
				"DESCUENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"EMPRESA_SECCION_ID=" + _db.CreateSqlParameterName("EMPRESA_SECCION_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"UTILIZAR_PORCENTAJE=" + _db.CreateSqlParameterName("UTILIZAR_PORCENTAJE") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"LIQUIDACION_ASOCIADA_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ASOCIADA_ID") + ", " +
				"CONSUMO_VISITAS=" + _db.CreateSqlParameterName("CONSUMO_VISITAS") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "DESCUENTO_ID", value.DESCUENTO_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "EMPRESA_SECCION_ID",
				value.IsEMPRESA_SECCION_IDNull ? DBNull.Value : (object)value.EMPRESA_SECCION_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "UTILIZAR_PORCENTAJE", value.UTILIZAR_PORCENTAJE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "LIQUIDACION_ASOCIADA_ID",
				value.IsLIQUIDACION_ASOCIADA_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ASOCIADA_ID);
			AddParameter(cmd, "CONSUMO_VISITAS", value.CONSUMO_VISITAS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CASO_ORIGEN_ID",
				value.IsCASO_ORIGEN_IDNull ? DBNull.Value : (object)value.CASO_ORIGEN_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_DESCUENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_DESCUENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FUNCIONARIOS_DESCUENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_DESCUENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FUNCIONARIOS_DESCUENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FUNCIONARIOS_DESCUENTOS</c> table using
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
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return DeleteByCASO_ORIGEN_ID(caso_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGEN_ID(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return CreateDeleteByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_DESC_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ORIGEN_IDCommand(decimal caso_origen_id, bool caso_origen_idNull)
		{
			string whereSql = "";
			if(caso_origen_idNull)
				whereSql += "CASO_ORIGEN_ID IS NULL";
			else
				whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_origen_idNull)
				AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_DESCUENTO_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_ID(decimal descuento_id)
		{
			return CreateDeleteByDESCUENTO_IDCommand(descuento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_DESC_DESCUENTO_ID</c> foreign key.
		/// </summary>
		/// <param name="descuento_id">The <c>DESCUENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_IDCommand(decimal descuento_id)
		{
			string whereSql = "";
			whereSql += "DESCUENTO_ID=" + _db.CreateSqlParameterName("DESCUENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DESCUENTO_ID", descuento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_DESC_FUNCIONARIO_ID</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_DESC_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
		/// </summary>
		/// <param name="empresa_seccion_id">The <c>EMPRESA_SECCION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEMPRESA_SECCION_ID(decimal empresa_seccion_id)
		{
			return DeleteByEMPRESA_SECCION_ID(empresa_seccion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
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
		/// delete records using the <c>FK_FUNC_DESC_SECCION_ID</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_DESCUENTOS</c> table using the 
		/// <c>FK_FUNC_DESC_USUARIO_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_DESC_USUARIO_CREAC_ID</c> foreign key.
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
		/// Deletes <c>FUNCIONARIOS_DESCUENTOS</c> records that match the specified criteria.
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
		/// to delete <c>FUNCIONARIOS_DESCUENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FUNCIONARIOS_DESCUENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FUNCIONARIOS_DESCUENTOS</c> table.
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
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		protected FUNCIONARIOS_DESCUENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		protected FUNCIONARIOS_DESCUENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_DESCUENTOSRow"/> objects.</returns>
		protected virtual FUNCIONARIOS_DESCUENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int descuento_idColumnIndex = reader.GetOrdinal("DESCUENTO_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int empresa_seccion_idColumnIndex = reader.GetOrdinal("EMPRESA_SECCION_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int utilizar_porcentajeColumnIndex = reader.GetOrdinal("UTILIZAR_PORCENTAJE");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int liquidacion_asociada_idColumnIndex = reader.GetOrdinal("LIQUIDACION_ASOCIADA_ID");
			int consumo_visitasColumnIndex = reader.GetOrdinal("CONSUMO_VISITAS");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int caso_origen_idColumnIndex = reader.GetOrdinal("CASO_ORIGEN_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FUNCIONARIOS_DESCUENTOSRow record = new FUNCIONARIOS_DESCUENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.DESCUENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(empresa_seccion_idColumnIndex))
						record.EMPRESA_SECCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(empresa_seccion_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.UTILIZAR_PORCENTAJE = Convert.ToString(reader.GetValue(utilizar_porcentajeColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(liquidacion_asociada_idColumnIndex))
						record.LIQUIDACION_ASOCIADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(liquidacion_asociada_idColumnIndex)), 9);
					record.CONSUMO_VISITAS = Convert.ToString(reader.GetValue(consumo_visitasColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(caso_origen_idColumnIndex))
						record.CASO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_origen_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FUNCIONARIOS_DESCUENTOSRow[])(recordList.ToArray(typeof(FUNCIONARIOS_DESCUENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FUNCIONARIOS_DESCUENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FUNCIONARIOS_DESCUENTOSRow"/> object.</returns>
		protected virtual FUNCIONARIOS_DESCUENTOSRow MapRow(DataRow row)
		{
			FUNCIONARIOS_DESCUENTOSRow mappedObject = new FUNCIONARIOS_DESCUENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "EMPRESA_SECCION_ID"
			dataColumn = dataTable.Columns["EMPRESA_SECCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_SECCION_ID = (decimal)row[dataColumn];
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
			// Column "CONSUMO_VISITAS"
			dataColumn = dataTable.Columns["CONSUMO_VISITAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSUMO_VISITAS = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CASO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CASO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGEN_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FUNCIONARIOS_DESCUENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FUNCIONARIOS_DESCUENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCUENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EMPRESA_SECCION_ID", typeof(decimal));
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
			dataColumn = dataTable.Columns.Add("CONSUMO_VISITAS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ORIGEN_ID", typeof(decimal));
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

				case "DESCUENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMPRESA_SECCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "CONSUMO_VISITAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FUNCIONARIOS_DESCUENTOSCollection_Base class
}  // End of namespace
