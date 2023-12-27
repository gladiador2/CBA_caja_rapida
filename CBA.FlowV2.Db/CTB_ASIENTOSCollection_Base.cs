// <fileinfo name="CTB_ASIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_PERIODO_IDColumnName = "CTB_PERIODO_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string AUTOMATICOColumnName = "AUTOMATICO";
		public const string USUARIO_INACTIVACION_IDColumnName = "USUARIO_INACTIVACION_ID";
		public const string FECHA_INACTIVACIONColumnName = "FECHA_INACTIVACION";
		public const string FECHA_ASIENTOColumnName = "FECHA_ASIENTO";
		public const string NUMEROColumnName = "NUMERO";
		public const string OBSERVACION_SISTEMAColumnName = "OBSERVACION_SISTEMA";
		public const string APROBADOColumnName = "APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string CASO_RELACIONADO_IDColumnName = "CASO_RELACIONADO_ID";
		public const string TABLA_RELACIONADA_IDColumnName = "TABLA_RELACIONADA_ID";
		public const string REGISTRO_RELACIONADO_IDColumnName = "REGISTRO_RELACIONADO_ID";
		public const string REVISION_POSTERIORColumnName = "REVISION_POSTERIOR";
		public const string TRANSICION_IDColumnName = "TRANSICION_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string ES_APERTURAColumnName = "ES_APERTURA";
		public const string ES_REGULARIZACIONColumnName = "ES_REGULARIZACION";
		public const string ES_CIERREColumnName = "ES_CIERRE";
		public const string ES_GLOBALColumnName = "ES_GLOBAL";
		public const string CTB_ASIENTO_GLOBAL_IDColumnName = "CTB_ASIENTO_GLOBAL_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public CTB_ASIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_ASIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_ASIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_ASIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public CTB_ASIENTOSRow[] GetByCASO_RELACIONADO_ID(decimal caso_relacionado_id)
		{
			return GetByCASO_RELACIONADO_ID(caso_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByCASO_RELACIONADO_ID(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return MapRecords(CreateGetByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_RELACIONADO_IDAsDataTable(decimal caso_relacionado_id)
		{
			return GetByCASO_RELACIONADO_IDAsDataTable(caso_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_RELACIONADO_IDAsDataTable(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_RELACIONADO_IDCommand(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			string whereSql = "";
			if(caso_relacionado_idNull)
				whereSql += "CASO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_relacionado_idNull)
				AddParameter(cmd, "CASO_RELACIONADO_ID", caso_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public CTB_ASIENTOSRow[] GetByCTB_ASIENTO_GLOBAL_ID(decimal ctb_asiento_global_id)
		{
			return GetByCTB_ASIENTO_GLOBAL_ID(ctb_asiento_global_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <param name="ctb_asiento_global_idNull">true if the method ignores the ctb_asiento_global_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByCTB_ASIENTO_GLOBAL_ID(decimal ctb_asiento_global_id, bool ctb_asiento_global_idNull)
		{
			return MapRecords(CreateGetByCTB_ASIENTO_GLOBAL_IDCommand(ctb_asiento_global_id, ctb_asiento_global_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_ASIENTO_GLOBAL_IDAsDataTable(decimal ctb_asiento_global_id)
		{
			return GetByCTB_ASIENTO_GLOBAL_IDAsDataTable(ctb_asiento_global_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <param name="ctb_asiento_global_idNull">true if the method ignores the ctb_asiento_global_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_ASIENTO_GLOBAL_IDAsDataTable(decimal ctb_asiento_global_id, bool ctb_asiento_global_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_ASIENTO_GLOBAL_IDCommand(ctb_asiento_global_id, ctb_asiento_global_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <param name="ctb_asiento_global_idNull">true if the method ignores the ctb_asiento_global_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_ASIENTO_GLOBAL_IDCommand(decimal ctb_asiento_global_id, bool ctb_asiento_global_idNull)
		{
			string whereSql = "";
			if(ctb_asiento_global_idNull)
				whereSql += "CTB_ASIENTO_GLOBAL_ID IS NULL";
			else
				whereSql += "CTB_ASIENTO_GLOBAL_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_GLOBAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_asiento_global_idNull)
				AddParameter(cmd, "CTB_ASIENTO_GLOBAL_ID", ctb_asiento_global_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_PERIODO</c> foreign key.
		/// </summary>
		/// <param name="ctb_periodo_id">The <c>CTB_PERIODO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByCTB_PERIODO_ID(decimal ctb_periodo_id)
		{
			return MapRecords(CreateGetByCTB_PERIODO_IDCommand(ctb_periodo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_PERIODO</c> foreign key.
		/// </summary>
		/// <param name="ctb_periodo_id">The <c>CTB_PERIODO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_PERIODO_IDAsDataTable(decimal ctb_periodo_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_PERIODO_IDCommand(ctb_periodo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_PERIODO</c> foreign key.
		/// </summary>
		/// <param name="ctb_periodo_id">The <c>CTB_PERIODO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_PERIODO_IDCommand(decimal ctb_periodo_id)
		{
			string whereSql = "";
			whereSql += "CTB_PERIODO_ID=" + _db.CreateSqlParameterName("CTB_PERIODO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_PERIODO_ID", ctb_periodo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_SUCURSAL</c> foreign key.
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
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByTABLA_RELACIONADA_ID(string tabla_relacionada_id)
		{
			return MapRecords(CreateGetByTABLA_RELACIONADA_IDCommand(tabla_relacionada_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTABLA_RELACIONADA_IDAsDataTable(string tabla_relacionada_id)
		{
			return MapRecordsToDataTable(CreateGetByTABLA_RELACIONADA_IDCommand(tabla_relacionada_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTABLA_RELACIONADA_IDCommand(string tabla_relacionada_id)
		{
			string whereSql = "";
			if(null == tabla_relacionada_id)
				whereSql += "TABLA_RELACIONADA_ID IS NULL";
			else
				whereSql += "TABLA_RELACIONADA_ID=" + _db.CreateSqlParameterName("TABLA_RELACIONADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tabla_relacionada_id)
				AddParameter(cmd, "TABLA_RELACIONADA_ID", tabla_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public CTB_ASIENTOSRow[] GetByTRANSICION_ID(decimal transicion_id)
		{
			return GetByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByTRANSICION_ID(decimal transicion_id, bool transicion_idNull)
		{
			return MapRecords(CreateGetByTRANSICION_IDCommand(transicion_id, transicion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSICION_IDAsDataTable(decimal transicion_id)
		{
			return GetByTRANSICION_IDAsDataTable(transicion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSICION_IDAsDataTable(decimal transicion_id, bool transicion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSICION_IDCommand(transicion_id, transicion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSICION_IDCommand(decimal transicion_id, bool transicion_idNull)
		{
			string whereSql = "";
			if(transicion_idNull)
				whereSql += "TRANSICION_ID IS NULL";
			else
				whereSql += "TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transicion_idNull)
				AddParameter(cmd, "TRANSICION_ID", transicion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public CTB_ASIENTOSRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_IDAsDataTable(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public CTB_ASIENTOSRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return GetByUSUARIO_CREACION_ID(usuario_creacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id, usuario_creacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return GetByUSUARIO_CREACION_IDAsDataTable(usuario_creacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id, usuario_creacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			string whereSql = "";
			if(usuario_creacion_idNull)
				whereSql += "USUARIO_CREACION_ID IS NULL";
			else
				whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_creacion_idNull)
				AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public CTB_ASIENTOSRow[] GetByUSUARIO_INACTIVACION_ID(decimal usuario_inactivacion_id)
		{
			return GetByUSUARIO_INACTIVACION_ID(usuario_inactivacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOSRow"/> objects 
		/// by the <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <param name="usuario_inactivacion_idNull">true if the method ignores the usuario_inactivacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		public virtual CTB_ASIENTOSRow[] GetByUSUARIO_INACTIVACION_ID(decimal usuario_inactivacion_id, bool usuario_inactivacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_INACTIVACION_IDCommand(usuario_inactivacion_id, usuario_inactivacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_INACTIVACION_IDAsDataTable(decimal usuario_inactivacion_id)
		{
			return GetByUSUARIO_INACTIVACION_IDAsDataTable(usuario_inactivacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
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
		/// return records by the <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
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
		/// Adds a new record into the <c>CTB_ASIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_ASIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_ASIENTOS (" +
				"ID, " +
				"CTB_PERIODO_ID, " +
				"FECHA_CREACION, " +
				"OBSERVACION, " +
				"ESTADO, " +
				"USUARIO_CREACION_ID, " +
				"AUTOMATICO, " +
				"USUARIO_INACTIVACION_ID, " +
				"FECHA_INACTIVACION, " +
				"FECHA_ASIENTO, " +
				"NUMERO, " +
				"OBSERVACION_SISTEMA, " +
				"APROBADO, " +
				"USUARIO_APROBACION_ID, " +
				"FECHA_APROBACION, " +
				"CASO_RELACIONADO_ID, " +
				"TABLA_RELACIONADA_ID, " +
				"REGISTRO_RELACIONADO_ID, " +
				"REVISION_POSTERIOR, " +
				"TRANSICION_ID, " +
				"SUCURSAL_ID, " +
				"ES_APERTURA, " +
				"ES_REGULARIZACION, " +
				"ES_CIERRE, " +
				"ES_GLOBAL, " +
				"CTB_ASIENTO_GLOBAL_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_PERIODO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("AUTOMATICO") + ", " +
				_db.CreateSqlParameterName("USUARIO_INACTIVACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INACTIVACION") + ", " +
				_db.CreateSqlParameterName("FECHA_ASIENTO") + ", " +
				_db.CreateSqlParameterName("NUMERO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_SISTEMA") + ", " +
				_db.CreateSqlParameterName("APROBADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("CASO_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("TABLA_RELACIONADA_ID") + ", " +
				_db.CreateSqlParameterName("REGISTRO_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("REVISION_POSTERIOR") + ", " +
				_db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("ES_APERTURA") + ", " +
				_db.CreateSqlParameterName("ES_REGULARIZACION") + ", " +
				_db.CreateSqlParameterName("ES_CIERRE") + ", " +
				_db.CreateSqlParameterName("ES_GLOBAL") + ", " +
				_db.CreateSqlParameterName("CTB_ASIENTO_GLOBAL_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_PERIODO_ID", value.CTB_PERIODO_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_CREACION_ID",
				value.IsUSUARIO_CREACION_IDNull ? DBNull.Value : (object)value.USUARIO_CREACION_ID);
			AddParameter(cmd, "AUTOMATICO", value.AUTOMATICO);
			AddParameter(cmd, "USUARIO_INACTIVACION_ID",
				value.IsUSUARIO_INACTIVACION_IDNull ? DBNull.Value : (object)value.USUARIO_INACTIVACION_ID);
			AddParameter(cmd, "FECHA_INACTIVACION",
				value.IsFECHA_INACTIVACIONNull ? DBNull.Value : (object)value.FECHA_INACTIVACION);
			AddParameter(cmd, "FECHA_ASIENTO", value.FECHA_ASIENTO);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "OBSERVACION_SISTEMA", value.OBSERVACION_SISTEMA);
			AddParameter(cmd, "APROBADO", value.APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "CASO_RELACIONADO_ID",
				value.IsCASO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CASO_RELACIONADO_ID);
			AddParameter(cmd, "TABLA_RELACIONADA_ID", value.TABLA_RELACIONADA_ID);
			AddParameter(cmd, "REGISTRO_RELACIONADO_ID",
				value.IsREGISTRO_RELACIONADO_IDNull ? DBNull.Value : (object)value.REGISTRO_RELACIONADO_ID);
			AddParameter(cmd, "REVISION_POSTERIOR", value.REVISION_POSTERIOR);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "ES_APERTURA", value.ES_APERTURA);
			AddParameter(cmd, "ES_REGULARIZACION", value.ES_REGULARIZACION);
			AddParameter(cmd, "ES_CIERRE", value.ES_CIERRE);
			AddParameter(cmd, "ES_GLOBAL", value.ES_GLOBAL);
			AddParameter(cmd, "CTB_ASIENTO_GLOBAL_ID",
				value.IsCTB_ASIENTO_GLOBAL_IDNull ? DBNull.Value : (object)value.CTB_ASIENTO_GLOBAL_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_ASIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_ASIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_ASIENTOS SET " +
				"CTB_PERIODO_ID=" + _db.CreateSqlParameterName("CTB_PERIODO_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"AUTOMATICO=" + _db.CreateSqlParameterName("AUTOMATICO") + ", " +
				"USUARIO_INACTIVACION_ID=" + _db.CreateSqlParameterName("USUARIO_INACTIVACION_ID") + ", " +
				"FECHA_INACTIVACION=" + _db.CreateSqlParameterName("FECHA_INACTIVACION") + ", " +
				"FECHA_ASIENTO=" + _db.CreateSqlParameterName("FECHA_ASIENTO") + ", " +
				"NUMERO=" + _db.CreateSqlParameterName("NUMERO") + ", " +
				"OBSERVACION_SISTEMA=" + _db.CreateSqlParameterName("OBSERVACION_SISTEMA") + ", " +
				"APROBADO=" + _db.CreateSqlParameterName("APROBADO") + ", " +
				"USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID") + ", " +
				"TABLA_RELACIONADA_ID=" + _db.CreateSqlParameterName("TABLA_RELACIONADA_ID") + ", " +
				"REGISTRO_RELACIONADO_ID=" + _db.CreateSqlParameterName("REGISTRO_RELACIONADO_ID") + ", " +
				"REVISION_POSTERIOR=" + _db.CreateSqlParameterName("REVISION_POSTERIOR") + ", " +
				"TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"ES_APERTURA=" + _db.CreateSqlParameterName("ES_APERTURA") + ", " +
				"ES_REGULARIZACION=" + _db.CreateSqlParameterName("ES_REGULARIZACION") + ", " +
				"ES_CIERRE=" + _db.CreateSqlParameterName("ES_CIERRE") + ", " +
				"ES_GLOBAL=" + _db.CreateSqlParameterName("ES_GLOBAL") + ", " +
				"CTB_ASIENTO_GLOBAL_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_GLOBAL_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_PERIODO_ID", value.CTB_PERIODO_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_CREACION_ID",
				value.IsUSUARIO_CREACION_IDNull ? DBNull.Value : (object)value.USUARIO_CREACION_ID);
			AddParameter(cmd, "AUTOMATICO", value.AUTOMATICO);
			AddParameter(cmd, "USUARIO_INACTIVACION_ID",
				value.IsUSUARIO_INACTIVACION_IDNull ? DBNull.Value : (object)value.USUARIO_INACTIVACION_ID);
			AddParameter(cmd, "FECHA_INACTIVACION",
				value.IsFECHA_INACTIVACIONNull ? DBNull.Value : (object)value.FECHA_INACTIVACION);
			AddParameter(cmd, "FECHA_ASIENTO", value.FECHA_ASIENTO);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "OBSERVACION_SISTEMA", value.OBSERVACION_SISTEMA);
			AddParameter(cmd, "APROBADO", value.APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "CASO_RELACIONADO_ID",
				value.IsCASO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CASO_RELACIONADO_ID);
			AddParameter(cmd, "TABLA_RELACIONADA_ID", value.TABLA_RELACIONADA_ID);
			AddParameter(cmd, "REGISTRO_RELACIONADO_ID",
				value.IsREGISTRO_RELACIONADO_IDNull ? DBNull.Value : (object)value.REGISTRO_RELACIONADO_ID);
			AddParameter(cmd, "REVISION_POSTERIOR", value.REVISION_POSTERIOR);
			AddParameter(cmd, "TRANSICION_ID",
				value.IsTRANSICION_IDNull ? DBNull.Value : (object)value.TRANSICION_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "ES_APERTURA", value.ES_APERTURA);
			AddParameter(cmd, "ES_REGULARIZACION", value.ES_REGULARIZACION);
			AddParameter(cmd, "ES_CIERRE", value.ES_CIERRE);
			AddParameter(cmd, "ES_GLOBAL", value.ES_GLOBAL);
			AddParameter(cmd, "CTB_ASIENTO_GLOBAL_ID",
				value.IsCTB_ASIENTO_GLOBAL_IDNull ? DBNull.Value : (object)value.CTB_ASIENTO_GLOBAL_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_ASIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_ASIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_ASIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_ASIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_ASIENTOS</c> table using
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
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELACIONADO_ID(decimal caso_relacionado_id)
		{
			return DeleteByCASO_RELACIONADO_ID(caso_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELACIONADO_ID(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return CreateDeleteByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_AIENTOS_CASO_REL</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_RELACIONADO_IDCommand(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			string whereSql = "";
			if(caso_relacionado_idNull)
				whereSql += "CASO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_relacionado_idNull)
				AddParameter(cmd, "CASO_RELACIONADO_ID", caso_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_ASIENTO_GLOBAL_ID(decimal ctb_asiento_global_id)
		{
			return DeleteByCTB_ASIENTO_GLOBAL_ID(ctb_asiento_global_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <param name="ctb_asiento_global_idNull">true if the method ignores the ctb_asiento_global_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_ASIENTO_GLOBAL_ID(decimal ctb_asiento_global_id, bool ctb_asiento_global_idNull)
		{
			return CreateDeleteByCTB_ASIENTO_GLOBAL_IDCommand(ctb_asiento_global_id, ctb_asiento_global_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_ASIENTO_GLOBAL</c> foreign key.
		/// </summary>
		/// <param name="ctb_asiento_global_id">The <c>CTB_ASIENTO_GLOBAL_ID</c> column value.</param>
		/// <param name="ctb_asiento_global_idNull">true if the method ignores the ctb_asiento_global_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_ASIENTO_GLOBAL_IDCommand(decimal ctb_asiento_global_id, bool ctb_asiento_global_idNull)
		{
			string whereSql = "";
			if(ctb_asiento_global_idNull)
				whereSql += "CTB_ASIENTO_GLOBAL_ID IS NULL";
			else
				whereSql += "CTB_ASIENTO_GLOBAL_ID=" + _db.CreateSqlParameterName("CTB_ASIENTO_GLOBAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_asiento_global_idNull)
				AddParameter(cmd, "CTB_ASIENTO_GLOBAL_ID", ctb_asiento_global_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_PERIODO</c> foreign key.
		/// </summary>
		/// <param name="ctb_periodo_id">The <c>CTB_PERIODO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_PERIODO_ID(decimal ctb_periodo_id)
		{
			return CreateDeleteByCTB_PERIODO_IDCommand(ctb_periodo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_PERIODO</c> foreign key.
		/// </summary>
		/// <param name="ctb_periodo_id">The <c>CTB_PERIODO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_PERIODO_IDCommand(decimal ctb_periodo_id)
		{
			string whereSql = "";
			whereSql += "CTB_PERIODO_ID=" + _db.CreateSqlParameterName("CTB_PERIODO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_PERIODO_ID", ctb_periodo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_SUCURSAL</c> foreign key.
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
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTABLA_RELACIONADA_ID(string tabla_relacionada_id)
		{
			return CreateDeleteByTABLA_RELACIONADA_IDCommand(tabla_relacionada_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_TABLA_REL</c> foreign key.
		/// </summary>
		/// <param name="tabla_relacionada_id">The <c>TABLA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTABLA_RELACIONADA_IDCommand(string tabla_relacionada_id)
		{
			string whereSql = "";
			if(null == tabla_relacionada_id)
				whereSql += "TABLA_RELACIONADA_ID IS NULL";
			else
				whereSql += "TABLA_RELACIONADA_ID=" + _db.CreateSqlParameterName("TABLA_RELACIONADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tabla_relacionada_id)
				AddParameter(cmd, "TABLA_RELACIONADA_ID", tabla_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_ID(decimal transicion_id)
		{
			return DeleteByTRANSICION_ID(transicion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSICION_ID(decimal transicion_id, bool transicion_idNull)
		{
			return CreateDeleteByTRANSICION_IDCommand(transicion_id, transicion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_TRANSICION</c> foreign key.
		/// </summary>
		/// <param name="transicion_id">The <c>TRANSICION_ID</c> column value.</param>
		/// <param name="transicion_idNull">true if the method ignores the transicion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSICION_IDCommand(decimal transicion_id, bool transicion_idNull)
		{
			string whereSql = "";
			if(transicion_idNull)
				whereSql += "TRANSICION_ID IS NULL";
			else
				whereSql += "TRANSICION_ID=" + _db.CreateSqlParameterName("TRANSICION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transicion_idNull)
				AddParameter(cmd, "TRANSICION_ID", transicion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return DeleteByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return CreateDeleteByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_USR_APRUEBA</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return DeleteByUSUARIO_CREACION_ID(usuario_creacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id, usuario_creacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_ASIENTOS_USR_CREACION</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			string whereSql = "";
			if(usuario_creacion_idNull)
				whereSql += "USUARIO_CREACION_ID IS NULL";
			else
				whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_creacion_idNull)
				AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
		/// </summary>
		/// <param name="usuario_inactivacion_id">The <c>USUARIO_INACTIVACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_INACTIVACION_ID(decimal usuario_inactivacion_id)
		{
			return DeleteByUSUARIO_INACTIVACION_ID(usuario_inactivacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_ASIENTOS</c> table using the 
		/// <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
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
		/// delete records using the <c>FK_CTB_ASIENTOS_USR_INACTIVA</c> foreign key.
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
		/// Deletes <c>CTB_ASIENTOS</c> records that match the specified criteria.
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
		/// to delete <c>CTB_ASIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_ASIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_ASIENTOS</c> table.
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
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		protected CTB_ASIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		protected CTB_ASIENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOSRow"/> objects.</returns>
		protected virtual CTB_ASIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_periodo_idColumnIndex = reader.GetOrdinal("CTB_PERIODO_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int automaticoColumnIndex = reader.GetOrdinal("AUTOMATICO");
			int usuario_inactivacion_idColumnIndex = reader.GetOrdinal("USUARIO_INACTIVACION_ID");
			int fecha_inactivacionColumnIndex = reader.GetOrdinal("FECHA_INACTIVACION");
			int fecha_asientoColumnIndex = reader.GetOrdinal("FECHA_ASIENTO");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int observacion_sistemaColumnIndex = reader.GetOrdinal("OBSERVACION_SISTEMA");
			int aprobadoColumnIndex = reader.GetOrdinal("APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int caso_relacionado_idColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_ID");
			int tabla_relacionada_idColumnIndex = reader.GetOrdinal("TABLA_RELACIONADA_ID");
			int registro_relacionado_idColumnIndex = reader.GetOrdinal("REGISTRO_RELACIONADO_ID");
			int revision_posteriorColumnIndex = reader.GetOrdinal("REVISION_POSTERIOR");
			int transicion_idColumnIndex = reader.GetOrdinal("TRANSICION_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int es_aperturaColumnIndex = reader.GetOrdinal("ES_APERTURA");
			int es_regularizacionColumnIndex = reader.GetOrdinal("ES_REGULARIZACION");
			int es_cierreColumnIndex = reader.GetOrdinal("ES_CIERRE");
			int es_globalColumnIndex = reader.GetOrdinal("ES_GLOBAL");
			int ctb_asiento_global_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_GLOBAL_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOSRow record = new CTB_ASIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_PERIODO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_periodo_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(usuario_creacion_idColumnIndex))
						record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.AUTOMATICO = Convert.ToString(reader.GetValue(automaticoColumnIndex));
					if(!reader.IsDBNull(usuario_inactivacion_idColumnIndex))
						record.USUARIO_INACTIVACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_inactivacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_inactivacionColumnIndex))
						record.FECHA_INACTIVACION = Convert.ToDateTime(reader.GetValue(fecha_inactivacionColumnIndex));
					record.FECHA_ASIENTO = Convert.ToDateTime(reader.GetValue(fecha_asientoColumnIndex));
					record.NUMERO = Math.Round(Convert.ToDecimal(reader.GetValue(numeroColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_sistemaColumnIndex))
						record.OBSERVACION_SISTEMA = Convert.ToString(reader.GetValue(observacion_sistemaColumnIndex));
					record.APROBADO = Convert.ToString(reader.GetValue(aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(caso_relacionado_idColumnIndex))
						record.CASO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(tabla_relacionada_idColumnIndex))
						record.TABLA_RELACIONADA_ID = Convert.ToString(reader.GetValue(tabla_relacionada_idColumnIndex));
					if(!reader.IsDBNull(registro_relacionado_idColumnIndex))
						record.REGISTRO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(registro_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(revision_posteriorColumnIndex))
						record.REVISION_POSTERIOR = Convert.ToString(reader.GetValue(revision_posteriorColumnIndex));
					if(!reader.IsDBNull(transicion_idColumnIndex))
						record.TRANSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.ES_APERTURA = Convert.ToString(reader.GetValue(es_aperturaColumnIndex));
					record.ES_REGULARIZACION = Convert.ToString(reader.GetValue(es_regularizacionColumnIndex));
					record.ES_CIERRE = Convert.ToString(reader.GetValue(es_cierreColumnIndex));
					record.ES_GLOBAL = Convert.ToString(reader.GetValue(es_globalColumnIndex));
					if(!reader.IsDBNull(ctb_asiento_global_idColumnIndex))
						record.CTB_ASIENTO_GLOBAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_global_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOSRow[])(recordList.ToArray(typeof(CTB_ASIENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOSRow"/> object.</returns>
		protected virtual CTB_ASIENTOSRow MapRow(DataRow row)
		{
			CTB_ASIENTOSRow mappedObject = new CTB_ASIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_PERIODO_ID"
			dataColumn = dataTable.Columns["CTB_PERIODO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PERIODO_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "AUTOMATICO"
			dataColumn = dataTable.Columns["AUTOMATICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTOMATICO = (string)row[dataColumn];
			// Column "USUARIO_INACTIVACION_ID"
			dataColumn = dataTable.Columns["USUARIO_INACTIVACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_INACTIVACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_INACTIVACION"
			dataColumn = dataTable.Columns["FECHA_INACTIVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INACTIVACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_ASIENTO"
			dataColumn = dataTable.Columns["FECHA_ASIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ASIENTO = (System.DateTime)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (decimal)row[dataColumn];
			// Column "OBSERVACION_SISTEMA"
			dataColumn = dataTable.Columns["OBSERVACION_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_SISTEMA = (string)row[dataColumn];
			// Column "APROBADO"
			dataColumn = dataTable.Columns["APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBADO = (string)row[dataColumn];
			// Column "USUARIO_APROBACION_ID"
			dataColumn = dataTable.Columns["USUARIO_APROBACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "CASO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "TABLA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["TABLA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_RELACIONADA_ID = (string)row[dataColumn];
			// Column "REGISTRO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["REGISTRO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "REVISION_POSTERIOR"
			dataColumn = dataTable.Columns["REVISION_POSTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.REVISION_POSTERIOR = (string)row[dataColumn];
			// Column "TRANSICION_ID"
			dataColumn = dataTable.Columns["TRANSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "ES_APERTURA"
			dataColumn = dataTable.Columns["ES_APERTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_APERTURA = (string)row[dataColumn];
			// Column "ES_REGULARIZACION"
			dataColumn = dataTable.Columns["ES_REGULARIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_REGULARIZACION = (string)row[dataColumn];
			// Column "ES_CIERRE"
			dataColumn = dataTable.Columns["ES_CIERRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CIERRE = (string)row[dataColumn];
			// Column "ES_GLOBAL"
			dataColumn = dataTable.Columns["ES_GLOBAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_GLOBAL = (string)row[dataColumn];
			// Column "CTB_ASIENTO_GLOBAL_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_GLOBAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_GLOBAL_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_PERIODO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTOMATICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_INACTIVACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INACTIVACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ASIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION_SISTEMA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TABLA_RELACIONADA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("REGISTRO_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REVISION_POSTERIOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TRANSICION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_APERTURA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_REGULARIZACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_CIERRE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_GLOBAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_GLOBAL_ID", typeof(decimal));
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

				case "CTB_PERIODO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_INACTIVACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INACTIVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ASIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_APROBACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TABLA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGISTRO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REVISION_POSTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TRANSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_APERTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_REGULARIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_CIERRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_GLOBAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTB_ASIENTO_GLOBAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOSCollection_Base class
}  // End of namespace
