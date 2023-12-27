// <fileinfo name="CTB_EJERCICIOSCollection_Base.cs">
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
	/// The base class for <see cref="CTB_EJERCICIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_EJERCICIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_EJERCICIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_PLAN_CUENTA_IDColumnName = "CTB_PLAN_CUENTA_ID";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ESTADOColumnName = "ESTADO";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_INACTIVACION_IDColumnName = "USUARIO_INACTIVACION_ID";
		public const string FECHA_INACTIVACIONColumnName = "FECHA_INACTIVACION";
		public const string CTB_EJERCICIO_ANTERIORColumnName = "CTB_EJERCICIO_ANTERIOR";
		public const string SALDO_INICIAL_GENERADOColumnName = "SALDO_INICIAL_GENERADO";
		public const string SE_ABRIOColumnName = "SE_ABRIO";
		public const string SE_CERROColumnName = "SE_CERRO";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_EJERCICIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_EJERCICIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_EJERCICIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_EJERCICIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_EJERCICIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_EJERCICIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_EJERCICIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_EJERCICIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_EJERCICIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public CTB_EJERCICIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_EJERCICIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_EJERCICIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_EJERCICIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_EJERCICIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_EJERCICIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public CTB_EJERCICIOSRow[] GetByCTB_EJERCICIO_ANTERIOR(decimal ctb_ejercicio_anterior)
		{
			return GetByCTB_EJERCICIO_ANTERIOR(ctb_ejercicio_anterior, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <param name="ctb_ejercicio_anteriorNull">true if the method ignores the ctb_ejercicio_anterior
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetByCTB_EJERCICIO_ANTERIOR(decimal ctb_ejercicio_anterior, bool ctb_ejercicio_anteriorNull)
		{
			return MapRecords(CreateGetByCTB_EJERCICIO_ANTERIORCommand(ctb_ejercicio_anterior, ctb_ejercicio_anteriorNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_EJERCICIO_ANTERIORAsDataTable(decimal ctb_ejercicio_anterior)
		{
			return GetByCTB_EJERCICIO_ANTERIORAsDataTable(ctb_ejercicio_anterior, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <param name="ctb_ejercicio_anteriorNull">true if the method ignores the ctb_ejercicio_anterior
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_EJERCICIO_ANTERIORAsDataTable(decimal ctb_ejercicio_anterior, bool ctb_ejercicio_anteriorNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_EJERCICIO_ANTERIORCommand(ctb_ejercicio_anterior, ctb_ejercicio_anteriorNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <param name="ctb_ejercicio_anteriorNull">true if the method ignores the ctb_ejercicio_anterior
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_EJERCICIO_ANTERIORCommand(decimal ctb_ejercicio_anterior, bool ctb_ejercicio_anteriorNull)
		{
			string whereSql = "";
			if(ctb_ejercicio_anteriorNull)
				whereSql += "CTB_EJERCICIO_ANTERIOR IS NULL";
			else
				whereSql += "CTB_EJERCICIO_ANTERIOR=" + _db.CreateSqlParameterName("CTB_EJERCICIO_ANTERIOR");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_ejercicio_anteriorNull)
				AddParameter(cmd, "CTB_EJERCICIO_ANTERIOR", ctb_ejercicio_anterior);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_PAIS_ID</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetByPAIS_ID(decimal pais_id)
		{
			return MapRecords(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_PAIS_ID</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_IDAsDataTable(decimal pais_id)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_EJERCICIOS_PAIS_ID</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_PLAN_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetByCTB_PLAN_CUENTA_ID(decimal ctb_plan_cuenta_id)
		{
			return MapRecords(CreateGetByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_PLAN_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_PLAN_CUENTA_IDAsDataTable(decimal ctb_plan_cuenta_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_EJERCICIOS_PLAN_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_PLAN_CUENTA_IDCommand(decimal ctb_plan_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", ctb_plan_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public CTB_EJERCICIOSRow[] GetByREGION_ID(decimal region_id)
		{
			return GetByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetByREGION_ID(decimal region_id, bool region_idNull)
		{
			return MapRecords(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREGION_IDAsDataTable(decimal region_id)
		{
			return GetByREGION_IDAsDataTable(region_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREGION_IDAsDataTable(decimal region_id, bool region_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public CTB_EJERCICIOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
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
		/// return records by the <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
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
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_EJERCICIOS_USR_CREACION</c> foreign key.
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
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public CTB_EJERCICIOSRow[] GetByUSUARIO_INACTIVACION_ID(decimal usuario_inactivacion_id)
		{
			return GetByUSUARIO_INACTIVACION_ID(usuario_inactivacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_EJERCICIOSRow"/> objects 
		/// by the <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <param name="usuario_inactivacion_idNull">true if the method ignores the usuario_inactivacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		public virtual CTB_EJERCICIOSRow[] GetByUSUARIO_INACTIVACION_ID(decimal usuario_inactivacion_id, bool usuario_inactivacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_INACTIVACION_IDCommand(usuario_inactivacion_id, usuario_inactivacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_INACTIVACION_IDAsDataTable(decimal usuario_inactivacion_id)
		{
			return GetByUSUARIO_INACTIVACION_IDAsDataTable(usuario_inactivacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <param name="usuario_inactivacion_idNull">true if the method ignores the usuario_inactivacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_INACTIVACION_IDAsDataTable(decimal usuario_inactivacion_id, bool usuario_inactivacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_INACTIVACION_IDCommand(usuario_inactivacion_id, usuario_inactivacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <param name="usuario_inactivacion_idNull">true if the method ignores the usuario_inactivacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_INACTIVACION_IDCommand(decimal usuario_inactivacion_id, bool usuario_inactivacion_idNull)
		{
			string whereSql = "";
			if(usuario_inactivacion_idNull)
				whereSql += "USUARIO_INACTIVACION_ID IS NULL";
			else
				whereSql += "USUARIO_INACTIVACION_ID=" + _db.CreateSqlParameterName("USUARIO_INACTIVACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_inactivacion_idNull)
				AddParameter(cmd, "USUARIO_INACTIVACION_ID", usuario_inactivacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_EJERCICIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_EJERCICIOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_EJERCICIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_EJERCICIOS (" +
				"ID, " +
				"CTB_PLAN_CUENTA_ID, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"NOMBRE, " +
				"ESTADO, " +
				"USUARIO_CREACION_ID, " +
				"FECHA_CREACION, " +
				"USUARIO_INACTIVACION_ID, " +
				"FECHA_INACTIVACION, " +
				"CTB_EJERCICIO_ANTERIOR, " +
				"SALDO_INICIAL_GENERADO, " +
				"SE_ABRIO, " +
				"SE_CERRO, " +
				"PAIS_ID, " +
				"REGION_ID, " +
				"SUCURSAL_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_INACTIVACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INACTIVACION") + ", " +
				_db.CreateSqlParameterName("CTB_EJERCICIO_ANTERIOR") + ", " +
				_db.CreateSqlParameterName("SALDO_INICIAL_GENERADO") + ", " +
				_db.CreateSqlParameterName("SE_ABRIO") + ", " +
				_db.CreateSqlParameterName("SE_CERRO") + ", " +
				_db.CreateSqlParameterName("PAIS_ID") + ", " +
				_db.CreateSqlParameterName("REGION_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", value.CTB_PLAN_CUENTA_ID);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN", value.FECHA_FIN);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_INACTIVACION_ID",
				value.IsUSUARIO_INACTIVACION_IDNull ? DBNull.Value : (object)value.USUARIO_INACTIVACION_ID);
			AddParameter(cmd, "FECHA_INACTIVACION",
				value.IsFECHA_INACTIVACIONNull ? DBNull.Value : (object)value.FECHA_INACTIVACION);
			AddParameter(cmd, "CTB_EJERCICIO_ANTERIOR",
				value.IsCTB_EJERCICIO_ANTERIORNull ? DBNull.Value : (object)value.CTB_EJERCICIO_ANTERIOR);
			AddParameter(cmd, "SALDO_INICIAL_GENERADO", value.SALDO_INICIAL_GENERADO);
			AddParameter(cmd, "SE_ABRIO", value.SE_ABRIO);
			AddParameter(cmd, "SE_CERRO", value.SE_CERRO);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_EJERCICIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_EJERCICIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_EJERCICIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_EJERCICIOS SET " +
				"CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_INACTIVACION_ID=" + _db.CreateSqlParameterName("USUARIO_INACTIVACION_ID") + ", " +
				"FECHA_INACTIVACION=" + _db.CreateSqlParameterName("FECHA_INACTIVACION") + ", " +
				"CTB_EJERCICIO_ANTERIOR=" + _db.CreateSqlParameterName("CTB_EJERCICIO_ANTERIOR") + ", " +
				"SALDO_INICIAL_GENERADO=" + _db.CreateSqlParameterName("SALDO_INICIAL_GENERADO") + ", " +
				"SE_ABRIO=" + _db.CreateSqlParameterName("SE_ABRIO") + ", " +
				"SE_CERRO=" + _db.CreateSqlParameterName("SE_CERRO") + ", " +
				"PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID") + ", " +
				"REGION_ID=" + _db.CreateSqlParameterName("REGION_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", value.CTB_PLAN_CUENTA_ID);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN", value.FECHA_FIN);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_INACTIVACION_ID",
				value.IsUSUARIO_INACTIVACION_IDNull ? DBNull.Value : (object)value.USUARIO_INACTIVACION_ID);
			AddParameter(cmd, "FECHA_INACTIVACION",
				value.IsFECHA_INACTIVACIONNull ? DBNull.Value : (object)value.FECHA_INACTIVACION);
			AddParameter(cmd, "CTB_EJERCICIO_ANTERIOR",
				value.IsCTB_EJERCICIO_ANTERIORNull ? DBNull.Value : (object)value.CTB_EJERCICIO_ANTERIOR);
			AddParameter(cmd, "SALDO_INICIAL_GENERADO", value.SALDO_INICIAL_GENERADO);
			AddParameter(cmd, "SE_ABRIO", value.SE_ABRIO);
			AddParameter(cmd, "SE_CERRO", value.SE_CERRO);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_EJERCICIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_EJERCICIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_EJERCICIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_EJERCICIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_EJERCICIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_EJERCICIOS</c> table using
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
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_EJERCICIO_ANTERIOR(decimal ctb_ejercicio_anterior)
		{
			return DeleteByCTB_EJERCICIO_ANTERIOR(ctb_ejercicio_anterior, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <param name="ctb_ejercicio_anteriorNull">true if the method ignores the ctb_ejercicio_anterior
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_EJERCICIO_ANTERIOR(decimal ctb_ejercicio_anterior, bool ctb_ejercicio_anteriorNull)
		{
			return CreateDeleteByCTB_EJERCICIO_ANTERIORCommand(ctb_ejercicio_anterior, ctb_ejercicio_anteriorNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_EJERCICIOS_EJER_ANT</c> foreign key.
		/// </summary>
		/// <param name="ctb_ejercicio_anterior">The <c>CTB_EJERCICIO_ANTERIOR</c> column value.</param>
		/// <param name="ctb_ejercicio_anteriorNull">true if the method ignores the ctb_ejercicio_anterior
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_EJERCICIO_ANTERIORCommand(decimal ctb_ejercicio_anterior, bool ctb_ejercicio_anteriorNull)
		{
			string whereSql = "";
			if(ctb_ejercicio_anteriorNull)
				whereSql += "CTB_EJERCICIO_ANTERIOR IS NULL";
			else
				whereSql += "CTB_EJERCICIO_ANTERIOR=" + _db.CreateSqlParameterName("CTB_EJERCICIO_ANTERIOR");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_ejercicio_anteriorNull)
				AddParameter(cmd, "CTB_EJERCICIO_ANTERIOR", ctb_ejercicio_anterior);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_PAIS_ID</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id)
		{
			return CreateDeleteByPAIS_IDCommand(pais_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_EJERCICIOS_PAIS_ID</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_PLAN_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_PLAN_CUENTA_ID(decimal ctb_plan_cuenta_id)
		{
			return CreateDeleteByCTB_PLAN_CUENTA_IDCommand(ctb_plan_cuenta_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_EJERCICIOS_PLAN_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_plan_cuenta_id">The <c>CTB_PLAN_CUENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_PLAN_CUENTA_IDCommand(decimal ctb_plan_cuenta_id)
		{
			string whereSql = "";
			whereSql += "CTB_PLAN_CUENTA_ID=" + _db.CreateSqlParameterName("CTB_PLAN_CUENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_PLAN_CUENTA_ID", ctb_plan_cuenta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id)
		{
			return DeleteByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id, bool region_idNull)
		{
			return CreateDeleteByREGION_IDCommand(region_id, region_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_EJERCICIOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
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
		/// delete records using the <c>FK_CTB_EJERCICIOS_SUCURSAL</c> foreign key.
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
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_EJERCICIOS_USR_CREACION</c> foreign key.
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
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_INACTIVACION_ID(decimal usuario_inactivacion_id)
		{
			return DeleteByUSUARIO_INACTIVACION_ID(usuario_inactivacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_EJERCICIOS</c> table using the 
		/// <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <param name="usuario_inactivacion_idNull">true if the method ignores the usuario_inactivacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_INACTIVACION_ID(decimal usuario_inactivacion_id, bool usuario_inactivacion_idNull)
		{
			return CreateDeleteByUSUARIO_INACTIVACION_IDCommand(usuario_inactivacion_id, usuario_inactivacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_EJERCICIOS_USR_INACTIV</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <param name="usuario_inactivacion_idNull">true if the method ignores the usuario_inactivacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_INACTIVACION_IDCommand(decimal usuario_inactivacion_id, bool usuario_inactivacion_idNull)
		{
			string whereSql = "";
			if(usuario_inactivacion_idNull)
				whereSql += "USUARIO_INACTIVACION_ID IS NULL";
			else
				whereSql += "USUARIO_INACTIVACION_ID=" + _db.CreateSqlParameterName("USUARIO_INACTIVACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_inactivacion_idNull)
				AddParameter(cmd, "USUARIO_INACTIVACION_ID", usuario_inactivacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_EJERCICIOS</c> records that match the specified criteria.
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
		/// to delete <c>CTB_EJERCICIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_EJERCICIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_EJERCICIOS</c> table.
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
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		protected CTB_EJERCICIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		protected CTB_EJERCICIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_EJERCICIOSRow"/> objects.</returns>
		protected virtual CTB_EJERCICIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_plan_cuenta_idColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_ID");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_inactivacion_idColumnIndex = reader.GetOrdinal("USUARIO_INACTIVACION_ID");
			int fecha_inactivacionColumnIndex = reader.GetOrdinal("FECHA_INACTIVACION");
			int ctb_ejercicio_anteriorColumnIndex = reader.GetOrdinal("CTB_EJERCICIO_ANTERIOR");
			int saldo_inicial_generadoColumnIndex = reader.GetOrdinal("SALDO_INICIAL_GENERADO");
			int se_abrioColumnIndex = reader.GetOrdinal("SE_ABRIO");
			int se_cerroColumnIndex = reader.GetOrdinal("SE_CERRO");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_EJERCICIOSRow record = new CTB_EJERCICIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_plan_cuenta_idColumnIndex)), 9);
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(usuario_inactivacion_idColumnIndex))
						record.USUARIO_INACTIVACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_inactivacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_inactivacionColumnIndex))
						record.FECHA_INACTIVACION = Convert.ToDateTime(reader.GetValue(fecha_inactivacionColumnIndex));
					if(!reader.IsDBNull(ctb_ejercicio_anteriorColumnIndex))
						record.CTB_EJERCICIO_ANTERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_ejercicio_anteriorColumnIndex)), 9);
					record.SALDO_INICIAL_GENERADO = Convert.ToString(reader.GetValue(saldo_inicial_generadoColumnIndex));
					record.SE_ABRIO = Convert.ToString(reader.GetValue(se_abrioColumnIndex));
					record.SE_CERRO = Convert.ToString(reader.GetValue(se_cerroColumnIndex));
					record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_EJERCICIOSRow[])(recordList.ToArray(typeof(CTB_EJERCICIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_EJERCICIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_EJERCICIOSRow"/> object.</returns>
		protected virtual CTB_EJERCICIOSRow MapRow(DataRow row)
		{
			CTB_EJERCICIOSRow mappedObject = new CTB_EJERCICIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_ID = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_INACTIVACION_ID"
			dataColumn = dataTable.Columns["USUARIO_INACTIVACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_INACTIVACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_INACTIVACION"
			dataColumn = dataTable.Columns["FECHA_INACTIVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INACTIVACION = (System.DateTime)row[dataColumn];
			// Column "CTB_EJERCICIO_ANTERIOR"
			dataColumn = dataTable.Columns["CTB_EJERCICIO_ANTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_EJERCICIO_ANTERIOR = (decimal)row[dataColumn];
			// Column "SALDO_INICIAL_GENERADO"
			dataColumn = dataTable.Columns["SALDO_INICIAL_GENERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_INICIAL_GENERADO = (string)row[dataColumn];
			// Column "SE_ABRIO"
			dataColumn = dataTable.Columns["SE_ABRIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SE_ABRIO = (string)row[dataColumn];
			// Column "SE_CERRO"
			dataColumn = dataTable.Columns["SE_CERRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SE_CERRO = (string)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_EJERCICIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_EJERCICIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_INACTIVACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INACTIVACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CTB_EJERCICIO_ANTERIOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SALDO_INICIAL_GENERADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SE_ABRIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SE_CERRO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
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

				case "CTB_PLAN_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_INACTIVACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INACTIVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTB_EJERCICIO_ANTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_INICIAL_GENERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SE_ABRIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SE_CERRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_EJERCICIOSCollection_Base class
}  // End of namespace
