// <fileinfo name="REPARTOSCollection_Base.cs">
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
	/// The base class for <see cref="REPARTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REPARTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPARTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string FUNCIONARIO_CHOFER_IDColumnName = "FUNCIONARIO_CHOFER_ID";
		public const string FUNCIONARIO_ACOMPANHANTE_1ColumnName = "FUNCIONARIO_ACOMPANHANTE_1";
		public const string FUNCIONARIO_ACOMPANHANTE_2ColumnName = "FUNCIONARIO_ACOMPANHANTE_2";
		public const string FECHA_SALIDAColumnName = "FECHA_SALIDA";
		public const string FECHA_REGRESOColumnName = "FECHA_REGRESO";
		public const string KILOMETRAJE_SALIDAColumnName = "KILOMETRAJE_SALIDA";
		public const string KILOMETRAJE_REGRESOColumnName = "KILOMETRAJE_REGRESO";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string CTACTE_CAJA_SUC_IDColumnName = "CTACTE_CAJA_SUC_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPARTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REPARTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REPARTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REPARTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REPARTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REPARTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REPARTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REPARTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REPARTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REPARTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REPARTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REPARTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REPARTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REPARTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id, bool caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetByCTACTE_CAJA_SUC_ID(decimal ctacte_caja_suc_id)
		{
			return GetByCTACTE_CAJA_SUC_ID(ctacte_caja_suc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_idNull">true if the method ignores the ctacte_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetByCTACTE_CAJA_SUC_ID(decimal ctacte_caja_suc_id, bool ctacte_caja_suc_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUC_IDCommand(ctacte_caja_suc_id, ctacte_caja_suc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUC_IDAsDataTable(decimal ctacte_caja_suc_id)
		{
			return GetByCTACTE_CAJA_SUC_IDAsDataTable(ctacte_caja_suc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_idNull">true if the method ignores the ctacte_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_SUC_IDAsDataTable(decimal ctacte_caja_suc_id, bool ctacte_caja_suc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_SUC_IDCommand(ctacte_caja_suc_id, ctacte_caja_suc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_idNull">true if the method ignores the ctacte_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_SUC_IDCommand(decimal ctacte_caja_suc_id, bool ctacte_caja_suc_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_suc_idNull)
				whereSql += "CTACTE_CAJA_SUC_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUC_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_suc_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUC_ID", ctacte_caja_suc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return GetByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return GetByDEPOSITO_IDAsDataTable(deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetByFUNCIONARIO_ACOMPANHANTE_1(decimal funcionario_acompanhante_1)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE_1(funcionario_acompanhante_1, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <param name="funcionario_acompanhante_1Null">true if the method ignores the funcionario_acompanhante_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetByFUNCIONARIO_ACOMPANHANTE_1(decimal funcionario_acompanhante_1, bool funcionario_acompanhante_1Null)
		{
			return MapRecords(CreateGetByFUNCIONARIO_ACOMPANHANTE_1Command(funcionario_acompanhante_1, funcionario_acompanhante_1Null));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_ACOMPANHANTE_1AsDataTable(decimal funcionario_acompanhante_1)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE_1AsDataTable(funcionario_acompanhante_1, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <param name="funcionario_acompanhante_1Null">true if the method ignores the funcionario_acompanhante_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_ACOMPANHANTE_1AsDataTable(decimal funcionario_acompanhante_1, bool funcionario_acompanhante_1Null)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_ACOMPANHANTE_1Command(funcionario_acompanhante_1, funcionario_acompanhante_1Null));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <param name="funcionario_acompanhante_1Null">true if the method ignores the funcionario_acompanhante_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_ACOMPANHANTE_1Command(decimal funcionario_acompanhante_1, bool funcionario_acompanhante_1Null)
		{
			string whereSql = "";
			if(funcionario_acompanhante_1Null)
				whereSql += "FUNCIONARIO_ACOMPANHANTE_1 IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE_1=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_1");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_acompanhante_1Null)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_1", funcionario_acompanhante_1);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetByFUNCIONARIO_ACOMPANHANTE_2(decimal funcionario_acompanhante_2)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE_2(funcionario_acompanhante_2, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <param name="funcionario_acompanhante_2Null">true if the method ignores the funcionario_acompanhante_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetByFUNCIONARIO_ACOMPANHANTE_2(decimal funcionario_acompanhante_2, bool funcionario_acompanhante_2Null)
		{
			return MapRecords(CreateGetByFUNCIONARIO_ACOMPANHANTE_2Command(funcionario_acompanhante_2, funcionario_acompanhante_2Null));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_ACOMPANHANTE_2AsDataTable(decimal funcionario_acompanhante_2)
		{
			return GetByFUNCIONARIO_ACOMPANHANTE_2AsDataTable(funcionario_acompanhante_2, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <param name="funcionario_acompanhante_2Null">true if the method ignores the funcionario_acompanhante_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_ACOMPANHANTE_2AsDataTable(decimal funcionario_acompanhante_2, bool funcionario_acompanhante_2Null)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_ACOMPANHANTE_2Command(funcionario_acompanhante_2, funcionario_acompanhante_2Null));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <param name="funcionario_acompanhante_2Null">true if the method ignores the funcionario_acompanhante_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_ACOMPANHANTE_2Command(decimal funcionario_acompanhante_2, bool funcionario_acompanhante_2Null)
		{
			string whereSql = "";
			if(funcionario_acompanhante_2Null)
				whereSql += "FUNCIONARIO_ACOMPANHANTE_2 IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE_2=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_2");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_acompanhante_2Null)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_2", funcionario_acompanhante_2);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id)
		{
			return GetByFUNCIONARIO_CHOFER_ID(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_CHOFER_IDAsDataTable(decimal funcionario_chofer_id)
		{
			return GetByFUNCIONARIO_CHOFER_IDAsDataTable(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_CHOFER_IDAsDataTable(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_CHOFER_IDCommand(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			string whereSql = "";
			if(funcionario_chofer_idNull)
				whereSql += "FUNCIONARIO_CHOFER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_chofer_idNull)
				AddParameter(cmd, "FUNCIONARIO_CHOFER_ID", funcionario_chofer_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public REPARTOSRow[] GetByVEHICULO_ID(decimal vehiculo_id)
		{
			return GetByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTOSRow"/> objects 
		/// by the <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		public virtual REPARTOSRow[] GetByVEHICULO_ID(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return MapRecords(CreateGetByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVEHICULO_IDAsDataTable(decimal vehiculo_id)
		{
			return GetByVEHICULO_IDAsDataTable(vehiculo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVEHICULO_IDAsDataTable(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVEHICULO_IDCommand(decimal vehiculo_id, bool vehiculo_idNull)
		{
			string whereSql = "";
			if(vehiculo_idNull)
				whereSql += "VEHICULO_ID IS NULL";
			else
				whereSql += "VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vehiculo_idNull)
				AddParameter(cmd, "VEHICULO_ID", vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>REPARTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REPARTOSRow"/> object to be inserted.</param>
		public virtual void Insert(REPARTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REPARTOS (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"FECHA, " +
				"VEHICULO_ID, " +
				"FUNCIONARIO_CHOFER_ID, " +
				"FUNCIONARIO_ACOMPANHANTE_1, " +
				"FUNCIONARIO_ACOMPANHANTE_2, " +
				"FECHA_SALIDA, " +
				"FECHA_REGRESO, " +
				"KILOMETRAJE_SALIDA, " +
				"KILOMETRAJE_REGRESO, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"OBSERVACION, " +
				"IMPRESO, " +
				"CTACTE_CAJA_SUC_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_1") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_2") + ", " +
				_db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				_db.CreateSqlParameterName("FECHA_REGRESO") + ", " +
				_db.CreateSqlParameterName("KILOMETRAJE_SALIDA") + ", " +
				_db.CreateSqlParameterName("KILOMETRAJE_REGRESO") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("IMPRESO") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUC_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "FUNCIONARIO_CHOFER_ID",
				value.IsFUNCIONARIO_CHOFER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CHOFER_ID);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_1",
				value.IsFUNCIONARIO_ACOMPANHANTE_1Null ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE_1);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_2",
				value.IsFUNCIONARIO_ACOMPANHANTE_2Null ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE_2);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "FECHA_REGRESO",
				value.IsFECHA_REGRESONull ? DBNull.Value : (object)value.FECHA_REGRESO);
			AddParameter(cmd, "KILOMETRAJE_SALIDA",
				value.IsKILOMETRAJE_SALIDANull ? DBNull.Value : (object)value.KILOMETRAJE_SALIDA);
			AddParameter(cmd, "KILOMETRAJE_REGRESO",
				value.IsKILOMETRAJE_REGRESONull ? DBNull.Value : (object)value.KILOMETRAJE_REGRESO);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "CTACTE_CAJA_SUC_ID",
				value.IsCTACTE_CAJA_SUC_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUC_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REPARTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REPARTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REPARTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.REPARTOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID") + ", " +
				"FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID") + ", " +
				"FUNCIONARIO_ACOMPANHANTE_1=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_1") + ", " +
				"FUNCIONARIO_ACOMPANHANTE_2=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_2") + ", " +
				"FECHA_SALIDA=" + _db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				"FECHA_REGRESO=" + _db.CreateSqlParameterName("FECHA_REGRESO") + ", " +
				"KILOMETRAJE_SALIDA=" + _db.CreateSqlParameterName("KILOMETRAJE_SALIDA") + ", " +
				"KILOMETRAJE_REGRESO=" + _db.CreateSqlParameterName("KILOMETRAJE_REGRESO") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"IMPRESO=" + _db.CreateSqlParameterName("IMPRESO") + ", " +
				"CTACTE_CAJA_SUC_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUC_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "VEHICULO_ID",
				value.IsVEHICULO_IDNull ? DBNull.Value : (object)value.VEHICULO_ID);
			AddParameter(cmd, "FUNCIONARIO_CHOFER_ID",
				value.IsFUNCIONARIO_CHOFER_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CHOFER_ID);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_1",
				value.IsFUNCIONARIO_ACOMPANHANTE_1Null ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE_1);
			AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_2",
				value.IsFUNCIONARIO_ACOMPANHANTE_2Null ? DBNull.Value : (object)value.FUNCIONARIO_ACOMPANHANTE_2);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "FECHA_REGRESO",
				value.IsFECHA_REGRESONull ? DBNull.Value : (object)value.FECHA_REGRESO);
			AddParameter(cmd, "KILOMETRAJE_SALIDA",
				value.IsKILOMETRAJE_SALIDANull ? DBNull.Value : (object)value.KILOMETRAJE_SALIDA);
			AddParameter(cmd, "KILOMETRAJE_REGRESO",
				value.IsKILOMETRAJE_REGRESONull ? DBNull.Value : (object)value.KILOMETRAJE_REGRESO);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "CTACTE_CAJA_SUC_ID",
				value.IsCTACTE_CAJA_SUC_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUC_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REPARTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REPARTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REPARTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REPARTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REPARTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REPARTOS</c> table using
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
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return CreateDeleteByCASO_IDCommand(caso_id, caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUC_ID(decimal ctacte_caja_suc_id)
		{
			return DeleteByCTACTE_CAJA_SUC_ID(ctacte_caja_suc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_idNull">true if the method ignores the ctacte_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUC_ID(decimal ctacte_caja_suc_id, bool ctacte_caja_suc_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_SUC_IDCommand(ctacte_caja_suc_id, ctacte_caja_suc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_suc_id">The <c>CTACTE_CAJA_SUC_ID</c> column value.</param>
		/// <param name="ctacte_caja_suc_idNull">true if the method ignores the ctacte_caja_suc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_SUC_IDCommand(decimal ctacte_caja_suc_id, bool ctacte_caja_suc_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_suc_idNull)
				whereSql += "CTACTE_CAJA_SUC_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUC_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_suc_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUC_ID", ctacte_caja_suc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return DeleteByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id, deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE_1(decimal funcionario_acompanhante_1)
		{
			return DeleteByFUNCIONARIO_ACOMPANHANTE_1(funcionario_acompanhante_1, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <param name="funcionario_acompanhante_1Null">true if the method ignores the funcionario_acompanhante_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE_1(decimal funcionario_acompanhante_1, bool funcionario_acompanhante_1Null)
		{
			return CreateDeleteByFUNCIONARIO_ACOMPANHANTE_1Command(funcionario_acompanhante_1, funcionario_acompanhante_1Null).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_FUN_ACOMP_1_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_1">The <c>FUNCIONARIO_ACOMPANHANTE_1</c> column value.</param>
		/// <param name="funcionario_acompanhante_1Null">true if the method ignores the funcionario_acompanhante_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_ACOMPANHANTE_1Command(decimal funcionario_acompanhante_1, bool funcionario_acompanhante_1Null)
		{
			string whereSql = "";
			if(funcionario_acompanhante_1Null)
				whereSql += "FUNCIONARIO_ACOMPANHANTE_1 IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE_1=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_1");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_acompanhante_1Null)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_1", funcionario_acompanhante_1);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE_2(decimal funcionario_acompanhante_2)
		{
			return DeleteByFUNCIONARIO_ACOMPANHANTE_2(funcionario_acompanhante_2, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <param name="funcionario_acompanhante_2Null">true if the method ignores the funcionario_acompanhante_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ACOMPANHANTE_2(decimal funcionario_acompanhante_2, bool funcionario_acompanhante_2Null)
		{
			return CreateDeleteByFUNCIONARIO_ACOMPANHANTE_2Command(funcionario_acompanhante_2, funcionario_acompanhante_2Null).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_FUN_ACOMP_2_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_acompanhante_2">The <c>FUNCIONARIO_ACOMPANHANTE_2</c> column value.</param>
		/// <param name="funcionario_acompanhante_2Null">true if the method ignores the funcionario_acompanhante_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_ACOMPANHANTE_2Command(decimal funcionario_acompanhante_2, bool funcionario_acompanhante_2Null)
		{
			string whereSql = "";
			if(funcionario_acompanhante_2Null)
				whereSql += "FUNCIONARIO_ACOMPANHANTE_2 IS NULL";
			else
				whereSql += "FUNCIONARIO_ACOMPANHANTE_2=" + _db.CreateSqlParameterName("FUNCIONARIO_ACOMPANHANTE_2");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_acompanhante_2Null)
				AddParameter(cmd, "FUNCIONARIO_ACOMPANHANTE_2", funcionario_acompanhante_2);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id)
		{
			return DeleteByFUNCIONARIO_CHOFER_ID(funcionario_chofer_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CHOFER_ID(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			return CreateDeleteByFUNCIONARIO_CHOFER_IDCommand(funcionario_chofer_id, funcionario_chofer_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_FUN_CHOFER_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_chofer_id">The <c>FUNCIONARIO_CHOFER_ID</c> column value.</param>
		/// <param name="funcionario_chofer_idNull">true if the method ignores the funcionario_chofer_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_CHOFER_IDCommand(decimal funcionario_chofer_id, bool funcionario_chofer_idNull)
		{
			string whereSql = "";
			if(funcionario_chofer_idNull)
				whereSql += "FUNCIONARIO_CHOFER_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CHOFER_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CHOFER_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_chofer_idNull)
				AddParameter(cmd, "FUNCIONARIO_CHOFER_ID", funcionario_chofer_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVEHICULO_ID(decimal vehiculo_id)
		{
			return DeleteByVEHICULO_ID(vehiculo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REPARTOS</c> table using the 
		/// <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVEHICULO_ID(decimal vehiculo_id, bool vehiculo_idNull)
		{
			return CreateDeleteByVEHICULO_IDCommand(vehiculo_id, vehiculo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REPARTO_VEHICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="vehiculo_id">The <c>VEHICULO_ID</c> column value.</param>
		/// <param name="vehiculo_idNull">true if the method ignores the vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVEHICULO_IDCommand(decimal vehiculo_id, bool vehiculo_idNull)
		{
			string whereSql = "";
			if(vehiculo_idNull)
				whereSql += "VEHICULO_ID IS NULL";
			else
				whereSql += "VEHICULO_ID=" + _db.CreateSqlParameterName("VEHICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vehiculo_idNull)
				AddParameter(cmd, "VEHICULO_ID", vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>REPARTOS</c> records that match the specified criteria.
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
		/// to delete <c>REPARTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REPARTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REPARTOS</c> table.
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
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		protected REPARTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		protected REPARTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REPARTOSRow"/> objects.</returns>
		protected virtual REPARTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int funcionario_chofer_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_CHOFER_ID");
			int funcionario_acompanhante_1ColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMPANHANTE_1");
			int funcionario_acompanhante_2ColumnIndex = reader.GetOrdinal("FUNCIONARIO_ACOMPANHANTE_2");
			int fecha_salidaColumnIndex = reader.GetOrdinal("FECHA_SALIDA");
			int fecha_regresoColumnIndex = reader.GetOrdinal("FECHA_REGRESO");
			int kilometraje_salidaColumnIndex = reader.GetOrdinal("KILOMETRAJE_SALIDA");
			int kilometraje_regresoColumnIndex = reader.GetOrdinal("KILOMETRAJE_REGRESO");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int ctacte_caja_suc_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUC_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REPARTOSRow record = new REPARTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_chofer_idColumnIndex))
						record.FUNCIONARIO_CHOFER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_chofer_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_acompanhante_1ColumnIndex))
						record.FUNCIONARIO_ACOMPANHANTE_1 = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_acompanhante_1ColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_acompanhante_2ColumnIndex))
						record.FUNCIONARIO_ACOMPANHANTE_2 = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_acompanhante_2ColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_salidaColumnIndex))
						record.FECHA_SALIDA = Convert.ToDateTime(reader.GetValue(fecha_salidaColumnIndex));
					if(!reader.IsDBNull(fecha_regresoColumnIndex))
						record.FECHA_REGRESO = Convert.ToDateTime(reader.GetValue(fecha_regresoColumnIndex));
					if(!reader.IsDBNull(kilometraje_salidaColumnIndex))
						record.KILOMETRAJE_SALIDA = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_salidaColumnIndex)), 9);
					if(!reader.IsDBNull(kilometraje_regresoColumnIndex))
						record.KILOMETRAJE_REGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_regresoColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_suc_idColumnIndex))
						record.CTACTE_CAJA_SUC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_suc_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REPARTOSRow[])(recordList.ToArray(typeof(REPARTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REPARTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REPARTOSRow"/> object.</returns>
		protected virtual REPARTOSRow MapRow(DataRow row)
		{
			REPARTOSRow mappedObject = new REPARTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_CHOFER_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_CHOFER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CHOFER_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ACOMPANHANTE_1"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMPANHANTE_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMPANHANTE_1 = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ACOMPANHANTE_2"
			dataColumn = dataTable.Columns["FUNCIONARIO_ACOMPANHANTE_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ACOMPANHANTE_2 = (decimal)row[dataColumn];
			// Column "FECHA_SALIDA"
			dataColumn = dataTable.Columns["FECHA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA = (System.DateTime)row[dataColumn];
			// Column "FECHA_REGRESO"
			dataColumn = dataTable.Columns["FECHA_REGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_REGRESO = (System.DateTime)row[dataColumn];
			// Column "KILOMETRAJE_SALIDA"
			dataColumn = dataTable.Columns["KILOMETRAJE_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_SALIDA = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_REGRESO"
			dataColumn = dataTable.Columns["KILOMETRAJE_REGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_REGRESO = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUC_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUC_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REPARTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REPARTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CHOFER_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMPANHANTE_1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ACOMPANHANTE_2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_REGRESO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_SALIDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_REGRESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUC_ID", typeof(decimal));
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_CHOFER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ACOMPANHANTE_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ACOMPANHANTE_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_REGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "KILOMETRAJE_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_REGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_SUC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REPARTOSCollection_Base class
}  // End of namespace
