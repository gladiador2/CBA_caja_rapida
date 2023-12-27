// <fileinfo name="CTACTE_CAJAS_SUCURSALCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJAS_SUCURSALCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CAJAS_SUCURSALCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJAS_SUCURSALCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string USUARIO_ABRE_IDColumnName = "USUARIO_ABRE_ID";
		public const string USUARIO_CIERRA_IDColumnName = "USUARIO_CIERRA_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string CTACTE_CAJA_SUCURSAL_ESTADO_IDColumnName = "CTACTE_CAJA_SUCURSAL_ESTADO_ID";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string CTACTE_CAJA_SUC_ANTERIOR_IDColumnName = "CTACTE_CAJA_SUC_ANTERIOR_ID";
		public const string MONEDA_PRINCIPAL_IDColumnName = "MONEDA_PRINCIPAL_ID";
		public const string SALDO_CIERREColumnName = "SALDO_CIERRE";
		public const string EXISTE_CAJA_SIGUIENTEColumnName = "EXISTE_CAJA_SIGUIENTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJAS_SUCURSALCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CAJAS_SUCURSALCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJAS_SUCURSALRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CAJAS_SUCURSALRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CAJAS_SUCURSALRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public CTACTE_CAJAS_SUCURSALRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CAJAS_SUCURSAL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CAJAS_SUCURSALRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJAS_SUCURSALRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CAJAS_SUCURSALRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public CTACTE_CAJAS_SUCURSALRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public CTACTE_CAJAS_SUCURSALRow[] GetByCTACTE_CAJA_SUC_ANTERIOR_ID(decimal ctacte_caja_suc_anterior_id)
		{
			return GetByCTACTE_CAJA_SUC_ANTERIOR_ID(ctacte_caja_suc_anterior_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_anterior_idNull">true if the method ignores the ctacte_caja_suc_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByCTACTE_CAJA_SUC_ANTERIOR_ID(decimal ctacte_caja_suc_anterior_id, bool ctacte_caja_suc_anterior_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUC_ANTERIOR_IDCommand(ctacte_caja_suc_anterior_id, ctacte_caja_suc_anterior_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUC_ANTERIOR_IDAsDataTable(decimal ctacte_caja_suc_anterior_id)
		{
			return GetByCTACTE_CAJA_SUC_ANTERIOR_IDAsDataTable(ctacte_caja_suc_anterior_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_anterior_idNull">true if the method ignores the ctacte_caja_suc_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_SUC_ANTERIOR_IDAsDataTable(decimal ctacte_caja_suc_anterior_id, bool ctacte_caja_suc_anterior_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_SUC_ANTERIOR_IDCommand(ctacte_caja_suc_anterior_id, ctacte_caja_suc_anterior_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_anterior_idNull">true if the method ignores the ctacte_caja_suc_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_SUC_ANTERIOR_IDCommand(decimal ctacte_caja_suc_anterior_id, bool ctacte_caja_suc_anterior_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_suc_anterior_idNull)
				whereSql += "CTACTE_CAJA_SUC_ANTERIOR_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUC_ANTERIOR_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUC_ANTERIOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_suc_anterior_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUC_ANTERIOR_ID", ctacte_caja_suc_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_CTESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_CTESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_CTESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_estado_id">The <c>CTACTE_CAJA_SUCURSAL_ESTADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByCTACTE_CAJA_SUCURSAL_ESTADO_ID(string ctacte_caja_sucursal_estado_id)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_ESTADO_IDCommand(ctacte_caja_sucursal_estado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_estado_id">The <c>CTACTE_CAJA_SUCURSAL_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_SUCURSAL_ESTADO_IDAsDataTable(string ctacte_caja_sucursal_estado_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_SUCURSAL_ESTADO_IDCommand(ctacte_caja_sucursal_estado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_estado_id">The <c>CTACTE_CAJA_SUCURSAL_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_SUCURSAL_ESTADO_IDCommand(string ctacte_caja_sucursal_estado_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_SUCURSAL_ESTADO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ESTADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ESTADO_ID", ctacte_caja_sucursal_estado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_FUNC</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_principal_id">The <c>MONEDA_PRINCIPAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByMONEDA_PRINCIPAL_ID(decimal moneda_principal_id)
		{
			return MapRecords(CreateGetByMONEDA_PRINCIPAL_IDCommand(moneda_principal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_principal_id">The <c>MONEDA_PRINCIPAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_PRINCIPAL_IDAsDataTable(decimal moneda_principal_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_PRINCIPAL_IDCommand(moneda_principal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_principal_id">The <c>MONEDA_PRINCIPAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_PRINCIPAL_IDCommand(decimal moneda_principal_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_PRINCIPAL_ID=" + _db.CreateSqlParameterName("MONEDA_PRINCIPAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_PRINCIPAL_ID", moneda_principal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_abre_id">The <c>USUARIO_ABRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByUSUARIO_ABRE_ID(decimal usuario_abre_id)
		{
			return MapRecords(CreateGetByUSUARIO_ABRE_IDCommand(usuario_abre_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_abre_id">The <c>USUARIO_ABRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ABRE_IDAsDataTable(decimal usuario_abre_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ABRE_IDCommand(usuario_abre_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_abre_id">The <c>USUARIO_ABRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ABRE_IDCommand(decimal usuario_abre_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ABRE_ID=" + _db.CreateSqlParameterName("USUARIO_ABRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ABRE_ID", usuario_abre_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public CTACTE_CAJAS_SUCURSALRow[] GetByUSUARIO_CIERRA_ID(decimal usuario_cierra_id)
		{
			return GetByUSUARIO_CIERRA_ID(usuario_cierra_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <param name="usuario_cierra_idNull">true if the method ignores the usuario_cierra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_SUCURSALRow[] GetByUSUARIO_CIERRA_ID(decimal usuario_cierra_id, bool usuario_cierra_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_CIERRA_IDCommand(usuario_cierra_id, usuario_cierra_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_CIERRA_IDAsDataTable(decimal usuario_cierra_id)
		{
			return GetByUSUARIO_CIERRA_IDAsDataTable(usuario_cierra_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <param name="usuario_cierra_idNull">true if the method ignores the usuario_cierra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CIERRA_IDAsDataTable(decimal usuario_cierra_id, bool usuario_cierra_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CIERRA_IDCommand(usuario_cierra_id, usuario_cierra_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <param name="usuario_cierra_idNull">true if the method ignores the usuario_cierra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CIERRA_IDCommand(decimal usuario_cierra_id, bool usuario_cierra_idNull)
		{
			string whereSql = "";
			if(usuario_cierra_idNull)
				whereSql += "USUARIO_CIERRA_ID IS NULL";
			else
				whereSql += "USUARIO_CIERRA_ID=" + _db.CreateSqlParameterName("USUARIO_CIERRA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_cierra_idNull)
				AddParameter(cmd, "USUARIO_CIERRA_ID", usuario_cierra_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJAS_SUCURSALRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CAJAS_SUCURSALRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CAJAS_SUCURSAL (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"FUNCIONARIO_ID, " +
				"USUARIO_ABRE_ID, " +
				"USUARIO_CIERRA_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"CTACTE_CAJA_SUCURSAL_ESTADO_ID, " +
				"CTACTE_CAJA_TESORERIA_ID, " +
				"CTACTE_CAJA_SUC_ANTERIOR_ID, " +
				"MONEDA_PRINCIPAL_ID, " +
				"SALDO_CIERRE, " +
				"EXISTE_CAJA_SIGUIENTE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ABRE_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CIERRA_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ESTADO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUC_ANTERIOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_PRINCIPAL_ID") + ", " +
				_db.CreateSqlParameterName("SALDO_CIERRE") + ", " +
				_db.CreateSqlParameterName("EXISTE_CAJA_SIGUIENTE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "USUARIO_ABRE_ID", value.USUARIO_ABRE_ID);
			AddParameter(cmd, "USUARIO_CIERRA_ID",
				value.IsUSUARIO_CIERRA_IDNull ? DBNull.Value : (object)value.USUARIO_CIERRA_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ESTADO_ID", value.CTACTE_CAJA_SUCURSAL_ESTADO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUC_ANTERIOR_ID",
				value.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUC_ANTERIOR_ID);
			AddParameter(cmd, "MONEDA_PRINCIPAL_ID", value.MONEDA_PRINCIPAL_ID);
			AddParameter(cmd, "SALDO_CIERRE", value.SALDO_CIERRE);
			AddParameter(cmd, "EXISTE_CAJA_SIGUIENTE", value.EXISTE_CAJA_SIGUIENTE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJAS_SUCURSALRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CAJAS_SUCURSALRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CAJAS_SUCURSAL SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"USUARIO_ABRE_ID=" + _db.CreateSqlParameterName("USUARIO_ABRE_ID") + ", " +
				"USUARIO_CIERRA_ID=" + _db.CreateSqlParameterName("USUARIO_CIERRA_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"CTACTE_CAJA_SUCURSAL_ESTADO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ESTADO_ID") + ", " +
				"CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				"CTACTE_CAJA_SUC_ANTERIOR_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUC_ANTERIOR_ID") + ", " +
				"MONEDA_PRINCIPAL_ID=" + _db.CreateSqlParameterName("MONEDA_PRINCIPAL_ID") + ", " +
				"SALDO_CIERRE=" + _db.CreateSqlParameterName("SALDO_CIERRE") + ", " +
				"EXISTE_CAJA_SIGUIENTE=" + _db.CreateSqlParameterName("EXISTE_CAJA_SIGUIENTE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "USUARIO_ABRE_ID", value.USUARIO_ABRE_ID);
			AddParameter(cmd, "USUARIO_CIERRA_ID",
				value.IsUSUARIO_CIERRA_IDNull ? DBNull.Value : (object)value.USUARIO_CIERRA_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ESTADO_ID", value.CTACTE_CAJA_SUCURSAL_ESTADO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUC_ANTERIOR_ID",
				value.IsCTACTE_CAJA_SUC_ANTERIOR_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUC_ANTERIOR_ID);
			AddParameter(cmd, "MONEDA_PRINCIPAL_ID", value.MONEDA_PRINCIPAL_ID);
			AddParameter(cmd, "SALDO_CIERRE", value.SALDO_CIERRE);
			AddParameter(cmd, "EXISTE_CAJA_SIGUIENTE", value.EXISTE_CAJA_SIGUIENTE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJAS_SUCURSAL</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJAS_SUCURSAL</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJAS_SUCURSALRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CAJAS_SUCURSALRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CAJAS_SUCURSAL</c> table using
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
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUC_ANTERIOR_ID(decimal ctacte_caja_suc_anterior_id)
		{
			return DeleteByCTACTE_CAJA_SUC_ANTERIOR_ID(ctacte_caja_suc_anterior_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_anterior_idNull">true if the method ignores the ctacte_caja_suc_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUC_ANTERIOR_ID(decimal ctacte_caja_suc_anterior_id, bool ctacte_caja_suc_anterior_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_SUC_ANTERIOR_IDCommand(ctacte_caja_suc_anterior_id, ctacte_caja_suc_anterior_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_CAJ_A</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_anterior_id">The <c>CTACTE_CAJA_SUC_ANTERIOR_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_anterior_idNull">true if the method ignores the ctacte_caja_suc_anterior_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_SUC_ANTERIOR_IDCommand(decimal ctacte_caja_suc_anterior_id, bool ctacte_caja_suc_anterior_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_suc_anterior_idNull)
				whereSql += "CTACTE_CAJA_SUC_ANTERIOR_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUC_ANTERIOR_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUC_ANTERIOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_suc_anterior_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUC_ANTERIOR_ID", ctacte_caja_suc_anterior_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_CTESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_CTESO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_estado_id">The <c>CTACTE_CAJA_SUCURSAL_ESTADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ESTADO_ID(string ctacte_caja_sucursal_estado_id)
		{
			return CreateDeleteByCTACTE_CAJA_SUCURSAL_ESTADO_IDCommand(ctacte_caja_sucursal_estado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_EST</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_estado_id">The <c>CTACTE_CAJA_SUCURSAL_ESTADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_SUCURSAL_ESTADO_IDCommand(string ctacte_caja_sucursal_estado_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_SUCURSAL_ESTADO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ESTADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ESTADO_ID", ctacte_caja_sucursal_estado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_FUNC</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_principal_id">The <c>MONEDA_PRINCIPAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_PRINCIPAL_ID(decimal moneda_principal_id)
		{
			return CreateDeleteByMONEDA_PRINCIPAL_IDCommand(moneda_principal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_MONE</c> foreign key.
		/// </summary>
		/// <param name="moneda_principal_id">The <c>MONEDA_PRINCIPAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_PRINCIPAL_IDCommand(decimal moneda_principal_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_PRINCIPAL_ID=" + _db.CreateSqlParameterName("MONEDA_PRINCIPAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_PRINCIPAL_ID", moneda_principal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_USR_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_abre_id">The <c>USUARIO_ABRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ABRE_ID(decimal usuario_abre_id)
		{
			return CreateDeleteByUSUARIO_ABRE_IDCommand(usuario_abre_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_A</c> foreign key.
		/// </summary>
		/// <param name="usuario_abre_id">The <c>USUARIO_ABRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ABRE_IDCommand(decimal usuario_abre_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ABRE_ID=" + _db.CreateSqlParameterName("USUARIO_ABRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ABRE_ID", usuario_abre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CIERRA_ID(decimal usuario_cierra_id)
		{
			return DeleteByUSUARIO_CIERRA_ID(usuario_cierra_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_SUCURSAL</c> table using the 
		/// <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <param name="usuario_cierra_idNull">true if the method ignores the usuario_cierra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CIERRA_ID(decimal usuario_cierra_id, bool usuario_cierra_idNull)
		{
			return CreateDeleteByUSUARIO_CIERRA_IDCommand(usuario_cierra_id, usuario_cierra_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_SUCURSAL_USR_C</c> foreign key.
		/// </summary>
		/// <param name="usuario_cierra_id">The <c>USUARIO_CIERRA_ID</c> column value.</param>
		/// <param name="usuario_cierra_idNull">true if the method ignores the usuario_cierra_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CIERRA_IDCommand(decimal usuario_cierra_id, bool usuario_cierra_idNull)
		{
			string whereSql = "";
			if(usuario_cierra_idNull)
				whereSql += "USUARIO_CIERRA_ID IS NULL";
			else
				whereSql += "USUARIO_CIERRA_ID=" + _db.CreateSqlParameterName("USUARIO_CIERRA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_cierra_idNull)
				AddParameter(cmd, "USUARIO_CIERRA_ID", usuario_cierra_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_CAJAS_SUCURSAL</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CAJAS_SUCURSAL</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CAJAS_SUCURSAL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CAJAS_SUCURSAL</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		protected CTACTE_CAJAS_SUCURSALRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		protected CTACTE_CAJAS_SUCURSALRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_SUCURSALRow"/> objects.</returns>
		protected virtual CTACTE_CAJAS_SUCURSALRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int usuario_abre_idColumnIndex = reader.GetOrdinal("USUARIO_ABRE_ID");
			int usuario_cierra_idColumnIndex = reader.GetOrdinal("USUARIO_CIERRA_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int ctacte_caja_sucursal_estado_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ESTADO_ID");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int ctacte_caja_suc_anterior_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUC_ANTERIOR_ID");
			int moneda_principal_idColumnIndex = reader.GetOrdinal("MONEDA_PRINCIPAL_ID");
			int saldo_cierreColumnIndex = reader.GetOrdinal("SALDO_CIERRE");
			int existe_caja_siguienteColumnIndex = reader.GetOrdinal("EXISTE_CAJA_SIGUIENTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CAJAS_SUCURSALRow record = new CTACTE_CAJAS_SUCURSALRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.USUARIO_ABRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_abre_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_cierra_idColumnIndex))
						record.USUARIO_CIERRA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_cierra_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					record.CTACTE_CAJA_SUCURSAL_ESTADO_ID = Convert.ToString(reader.GetValue(ctacte_caja_sucursal_estado_idColumnIndex));
					record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_suc_anterior_idColumnIndex))
						record.CTACTE_CAJA_SUC_ANTERIOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_suc_anterior_idColumnIndex)), 9);
					record.MONEDA_PRINCIPAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_principal_idColumnIndex)), 9);
					record.SALDO_CIERRE = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_cierreColumnIndex)), 9);
					record.EXISTE_CAJA_SIGUIENTE = Convert.ToString(reader.GetValue(existe_caja_siguienteColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CAJAS_SUCURSALRow[])(recordList.ToArray(typeof(CTACTE_CAJAS_SUCURSALRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CAJAS_SUCURSALRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CAJAS_SUCURSALRow"/> object.</returns>
		protected virtual CTACTE_CAJAS_SUCURSALRow MapRow(DataRow row)
		{
			CTACTE_CAJAS_SUCURSALRow mappedObject = new CTACTE_CAJAS_SUCURSALRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ABRE_ID"
			dataColumn = dataTable.Columns["USUARIO_ABRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ABRE_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CIERRA_ID"
			dataColumn = dataTable.Columns["USUARIO_CIERRA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CIERRA_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ESTADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ESTADO_ID = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUC_ANTERIOR_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUC_ANTERIOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUC_ANTERIOR_ID = (decimal)row[dataColumn];
			// Column "MONEDA_PRINCIPAL_ID"
			dataColumn = dataTable.Columns["MONEDA_PRINCIPAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_PRINCIPAL_ID = (decimal)row[dataColumn];
			// Column "SALDO_CIERRE"
			dataColumn = dataTable.Columns["SALDO_CIERRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_CIERRE = (decimal)row[dataColumn];
			// Column "EXISTE_CAJA_SIGUIENTE"
			dataColumn = dataTable.Columns["EXISTE_CAJA_SIGUIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTE_CAJA_SIGUIENTE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CAJAS_SUCURSAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CAJAS_SUCURSAL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ABRE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CIERRA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUC_ANTERIOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_PRINCIPAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SALDO_CIERRE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EXISTE_CAJA_SIGUIENTE", typeof(string));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ABRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CIERRA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUC_ANTERIOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_PRINCIPAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_CIERRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EXISTE_CAJA_SIGUIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CAJAS_SUCURSALCollection_Base class
}  // End of namespace
