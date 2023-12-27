// <fileinfo name="CTACTE_BANCOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_BANCOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_BANCOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_BANCOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string REPORTE_PLANILLA_CHEQUES_IDColumnName = "REPORTE_PLANILLA_CHEQUES_ID";
		public const string RAZON_SOCIALColumnName = "RAZON_SOCIAL";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string CODIGOColumnName = "CODIGO";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string DIRECCIONColumnName = "DIRECCION";
		public const string TELEFONO1ColumnName = "TELEFONO1";
		public const string TELEFONO2ColumnName = "TELEFONO2";
		public const string TELEFONO3ColumnName = "TELEFONO3";
		public const string EMAIL1ColumnName = "EMAIL1";
		public const string EMAIL2ColumnName = "EMAIL2";
		public const string AGENTE_CUENTA_NOMBREColumnName = "AGENTE_CUENTA_NOMBRE";
		public const string AGENTE_CUENTA_TELEFONO1ColumnName = "AGENTE_CUENTA_TELEFONO1";
		public const string AGENTE_CUENTA_TELEFONO2ColumnName = "AGENTE_CUENTA_TELEFONO2";
		public const string AGENTE_CUENTA_TELEFONO3ColumnName = "AGENTE_CUENTA_TELEFONO3";
		public const string ESTADOColumnName = "ESTADO";
		public const string ES_NACIONALColumnName = "ES_NACIONAL";
		public const string ES_EXTRANJEROColumnName = "ES_EXTRANJERO";
		public const string REPORTE_TXT_MODELO_IDColumnName = "REPORTE_TXT_MODELO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_BANCOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_BANCOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_BANCOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public virtual CTACTE_BANCOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_BANCOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_BANCOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_BANCOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_BANCOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_BANCOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_BANCOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public CTACTE_BANCOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public virtual CTACTE_BANCOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_BANCOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_BANCOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_BANCOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_BANCOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_BANCOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects 
		/// by the <c>FK_CTACTE_BANCOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public virtual CTACTE_BANCOSRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects 
		/// by the <c>FK_CTACTE_BANCOS_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public virtual CTACTE_BANCOSRow[] GetByPAIS_ID(decimal pais_id)
		{
			return MapRecords(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCOS_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_IDAsDataTable(decimal pais_id)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCOS_PAIS</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects 
		/// by the <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public CTACTE_BANCOSRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects 
		/// by the <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public virtual CTACTE_BANCOSRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects 
		/// by the <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public CTACTE_BANCOSRow[] GetByREPORTE_PLANILLA_CHEQUES_ID(decimal reporte_planilla_cheques_id)
		{
			return GetByREPORTE_PLANILLA_CHEQUES_ID(reporte_planilla_cheques_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_BANCOSRow"/> objects 
		/// by the <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <param name="reporte_planilla_cheques_idNull">true if the method ignores the reporte_planilla_cheques_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		public virtual CTACTE_BANCOSRow[] GetByREPORTE_PLANILLA_CHEQUES_ID(decimal reporte_planilla_cheques_id, bool reporte_planilla_cheques_idNull)
		{
			return MapRecords(CreateGetByREPORTE_PLANILLA_CHEQUES_IDCommand(reporte_planilla_cheques_id, reporte_planilla_cheques_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREPORTE_PLANILLA_CHEQUES_IDAsDataTable(decimal reporte_planilla_cheques_id)
		{
			return GetByREPORTE_PLANILLA_CHEQUES_IDAsDataTable(reporte_planilla_cheques_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <param name="reporte_planilla_cheques_idNull">true if the method ignores the reporte_planilla_cheques_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREPORTE_PLANILLA_CHEQUES_IDAsDataTable(decimal reporte_planilla_cheques_id, bool reporte_planilla_cheques_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREPORTE_PLANILLA_CHEQUES_IDCommand(reporte_planilla_cheques_id, reporte_planilla_cheques_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <param name="reporte_planilla_cheques_idNull">true if the method ignores the reporte_planilla_cheques_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREPORTE_PLANILLA_CHEQUES_IDCommand(decimal reporte_planilla_cheques_id, bool reporte_planilla_cheques_idNull)
		{
			string whereSql = "";
			if(reporte_planilla_cheques_idNull)
				whereSql += "REPORTE_PLANILLA_CHEQUES_ID IS NULL";
			else
				whereSql += "REPORTE_PLANILLA_CHEQUES_ID=" + _db.CreateSqlParameterName("REPORTE_PLANILLA_CHEQUES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!reporte_planilla_cheques_idNull)
				AddParameter(cmd, "REPORTE_PLANILLA_CHEQUES_ID", reporte_planilla_cheques_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_BANCOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_BANCOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_BANCOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_BANCOS (" +
				"ID, " +
				"ENTIDAD_ID, " +
				"PROVEEDOR_ID, " +
				"REPORTE_PLANILLA_CHEQUES_ID, " +
				"RAZON_SOCIAL, " +
				"ABREVIATURA, " +
				"CODIGO, " +
				"PAIS_ID, " +
				"DIRECCION, " +
				"TELEFONO1, " +
				"TELEFONO2, " +
				"TELEFONO3, " +
				"EMAIL1, " +
				"EMAIL2, " +
				"AGENTE_CUENTA_NOMBRE, " +
				"AGENTE_CUENTA_TELEFONO1, " +
				"AGENTE_CUENTA_TELEFONO2, " +
				"AGENTE_CUENTA_TELEFONO3, " +
				"ESTADO, " +
				"ES_NACIONAL, " +
				"ES_EXTRANJERO, " +
				"REPORTE_TXT_MODELO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("REPORTE_PLANILLA_CHEQUES_ID") + ", " +
				_db.CreateSqlParameterName("RAZON_SOCIAL") + ", " +
				_db.CreateSqlParameterName("ABREVIATURA") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("PAIS_ID") + ", " +
				_db.CreateSqlParameterName("DIRECCION") + ", " +
				_db.CreateSqlParameterName("TELEFONO1") + ", " +
				_db.CreateSqlParameterName("TELEFONO2") + ", " +
				_db.CreateSqlParameterName("TELEFONO3") + ", " +
				_db.CreateSqlParameterName("EMAIL1") + ", " +
				_db.CreateSqlParameterName("EMAIL2") + ", " +
				_db.CreateSqlParameterName("AGENTE_CUENTA_NOMBRE") + ", " +
				_db.CreateSqlParameterName("AGENTE_CUENTA_TELEFONO1") + ", " +
				_db.CreateSqlParameterName("AGENTE_CUENTA_TELEFONO2") + ", " +
				_db.CreateSqlParameterName("AGENTE_CUENTA_TELEFONO3") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("ES_NACIONAL") + ", " +
				_db.CreateSqlParameterName("ES_EXTRANJERO") + ", " +
				_db.CreateSqlParameterName("REPORTE_TXT_MODELO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "REPORTE_PLANILLA_CHEQUES_ID",
				value.IsREPORTE_PLANILLA_CHEQUES_IDNull ? DBNull.Value : (object)value.REPORTE_PLANILLA_CHEQUES_ID);
			AddParameter(cmd, "RAZON_SOCIAL", value.RAZON_SOCIAL);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "DIRECCION", value.DIRECCION);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "AGENTE_CUENTA_NOMBRE", value.AGENTE_CUENTA_NOMBRE);
			AddParameter(cmd, "AGENTE_CUENTA_TELEFONO1", value.AGENTE_CUENTA_TELEFONO1);
			AddParameter(cmd, "AGENTE_CUENTA_TELEFONO2", value.AGENTE_CUENTA_TELEFONO2);
			AddParameter(cmd, "AGENTE_CUENTA_TELEFONO3", value.AGENTE_CUENTA_TELEFONO3);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ES_NACIONAL", value.ES_NACIONAL);
			AddParameter(cmd, "ES_EXTRANJERO", value.ES_EXTRANJERO);
			AddParameter(cmd, "REPORTE_TXT_MODELO_ID",
				value.IsREPORTE_TXT_MODELO_IDNull ? DBNull.Value : (object)value.REPORTE_TXT_MODELO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_BANCOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_BANCOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_BANCOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_BANCOS SET " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"REPORTE_PLANILLA_CHEQUES_ID=" + _db.CreateSqlParameterName("REPORTE_PLANILLA_CHEQUES_ID") + ", " +
				"RAZON_SOCIAL=" + _db.CreateSqlParameterName("RAZON_SOCIAL") + ", " +
				"ABREVIATURA=" + _db.CreateSqlParameterName("ABREVIATURA") + ", " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID") + ", " +
				"DIRECCION=" + _db.CreateSqlParameterName("DIRECCION") + ", " +
				"TELEFONO1=" + _db.CreateSqlParameterName("TELEFONO1") + ", " +
				"TELEFONO2=" + _db.CreateSqlParameterName("TELEFONO2") + ", " +
				"TELEFONO3=" + _db.CreateSqlParameterName("TELEFONO3") + ", " +
				"EMAIL1=" + _db.CreateSqlParameterName("EMAIL1") + ", " +
				"EMAIL2=" + _db.CreateSqlParameterName("EMAIL2") + ", " +
				"AGENTE_CUENTA_NOMBRE=" + _db.CreateSqlParameterName("AGENTE_CUENTA_NOMBRE") + ", " +
				"AGENTE_CUENTA_TELEFONO1=" + _db.CreateSqlParameterName("AGENTE_CUENTA_TELEFONO1") + ", " +
				"AGENTE_CUENTA_TELEFONO2=" + _db.CreateSqlParameterName("AGENTE_CUENTA_TELEFONO2") + ", " +
				"AGENTE_CUENTA_TELEFONO3=" + _db.CreateSqlParameterName("AGENTE_CUENTA_TELEFONO3") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"ES_NACIONAL=" + _db.CreateSqlParameterName("ES_NACIONAL") + ", " +
				"ES_EXTRANJERO=" + _db.CreateSqlParameterName("ES_EXTRANJERO") + ", " +
				"REPORTE_TXT_MODELO_ID=" + _db.CreateSqlParameterName("REPORTE_TXT_MODELO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "REPORTE_PLANILLA_CHEQUES_ID",
				value.IsREPORTE_PLANILLA_CHEQUES_IDNull ? DBNull.Value : (object)value.REPORTE_PLANILLA_CHEQUES_ID);
			AddParameter(cmd, "RAZON_SOCIAL", value.RAZON_SOCIAL);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "DIRECCION", value.DIRECCION);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "AGENTE_CUENTA_NOMBRE", value.AGENTE_CUENTA_NOMBRE);
			AddParameter(cmd, "AGENTE_CUENTA_TELEFONO1", value.AGENTE_CUENTA_TELEFONO1);
			AddParameter(cmd, "AGENTE_CUENTA_TELEFONO2", value.AGENTE_CUENTA_TELEFONO2);
			AddParameter(cmd, "AGENTE_CUENTA_TELEFONO3", value.AGENTE_CUENTA_TELEFONO3);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ES_NACIONAL", value.ES_NACIONAL);
			AddParameter(cmd, "ES_EXTRANJERO", value.ES_EXTRANJERO);
			AddParameter(cmd, "REPORTE_TXT_MODELO_ID",
				value.IsREPORTE_TXT_MODELO_IDNull ? DBNull.Value : (object)value.REPORTE_TXT_MODELO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_BANCOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_BANCOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_BANCOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_BANCOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_BANCOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_BANCOS</c> table using
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
		/// Deletes records from the <c>CTACTE_BANCOS</c> table using the 
		/// <c>FK_CTACTE_BANCOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCOS</c> table using the 
		/// <c>FK_CTACTE_BANCOS_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id)
		{
			return CreateDeleteByPAIS_IDCommand(pais_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCOS_PAIS</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_BANCOS</c> table using the 
		/// <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCOS</c> table using the 
		/// <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCOS_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCOS</c> table using the 
		/// <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREPORTE_PLANILLA_CHEQUES_ID(decimal reporte_planilla_cheques_id)
		{
			return DeleteByREPORTE_PLANILLA_CHEQUES_ID(reporte_planilla_cheques_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_BANCOS</c> table using the 
		/// <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <param name="reporte_planilla_cheques_idNull">true if the method ignores the reporte_planilla_cheques_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREPORTE_PLANILLA_CHEQUES_ID(decimal reporte_planilla_cheques_id, bool reporte_planilla_cheques_idNull)
		{
			return CreateDeleteByREPORTE_PLANILLA_CHEQUES_IDCommand(reporte_planilla_cheques_id, reporte_planilla_cheques_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_BANCOS_REP_PLANILLA</c> foreign key.
		/// </summary>
		/// <param name="reporte_planilla_cheques_id">The <c>REPORTE_PLANILLA_CHEQUES_ID</c> column value.</param>
		/// <param name="reporte_planilla_cheques_idNull">true if the method ignores the reporte_planilla_cheques_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREPORTE_PLANILLA_CHEQUES_IDCommand(decimal reporte_planilla_cheques_id, bool reporte_planilla_cheques_idNull)
		{
			string whereSql = "";
			if(reporte_planilla_cheques_idNull)
				whereSql += "REPORTE_PLANILLA_CHEQUES_ID IS NULL";
			else
				whereSql += "REPORTE_PLANILLA_CHEQUES_ID=" + _db.CreateSqlParameterName("REPORTE_PLANILLA_CHEQUES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!reporte_planilla_cheques_idNull)
				AddParameter(cmd, "REPORTE_PLANILLA_CHEQUES_ID", reporte_planilla_cheques_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_BANCOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_BANCOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_BANCOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_BANCOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		protected CTACTE_BANCOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		protected CTACTE_BANCOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_BANCOSRow"/> objects.</returns>
		protected virtual CTACTE_BANCOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int reporte_planilla_cheques_idColumnIndex = reader.GetOrdinal("REPORTE_PLANILLA_CHEQUES_ID");
			int razon_socialColumnIndex = reader.GetOrdinal("RAZON_SOCIAL");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int direccionColumnIndex = reader.GetOrdinal("DIRECCION");
			int telefono1ColumnIndex = reader.GetOrdinal("TELEFONO1");
			int telefono2ColumnIndex = reader.GetOrdinal("TELEFONO2");
			int telefono3ColumnIndex = reader.GetOrdinal("TELEFONO3");
			int email1ColumnIndex = reader.GetOrdinal("EMAIL1");
			int email2ColumnIndex = reader.GetOrdinal("EMAIL2");
			int agente_cuenta_nombreColumnIndex = reader.GetOrdinal("AGENTE_CUENTA_NOMBRE");
			int agente_cuenta_telefono1ColumnIndex = reader.GetOrdinal("AGENTE_CUENTA_TELEFONO1");
			int agente_cuenta_telefono2ColumnIndex = reader.GetOrdinal("AGENTE_CUENTA_TELEFONO2");
			int agente_cuenta_telefono3ColumnIndex = reader.GetOrdinal("AGENTE_CUENTA_TELEFONO3");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int es_nacionalColumnIndex = reader.GetOrdinal("ES_NACIONAL");
			int es_extranjeroColumnIndex = reader.GetOrdinal("ES_EXTRANJERO");
			int reporte_txt_modelo_idColumnIndex = reader.GetOrdinal("REPORTE_TXT_MODELO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_BANCOSRow record = new CTACTE_BANCOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(reporte_planilla_cheques_idColumnIndex))
						record.REPORTE_PLANILLA_CHEQUES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reporte_planilla_cheques_idColumnIndex)), 9);
					record.RAZON_SOCIAL = Convert.ToString(reader.GetValue(razon_socialColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(direccionColumnIndex))
						record.DIRECCION = Convert.ToString(reader.GetValue(direccionColumnIndex));
					if(!reader.IsDBNull(telefono1ColumnIndex))
						record.TELEFONO1 = Convert.ToString(reader.GetValue(telefono1ColumnIndex));
					if(!reader.IsDBNull(telefono2ColumnIndex))
						record.TELEFONO2 = Convert.ToString(reader.GetValue(telefono2ColumnIndex));
					if(!reader.IsDBNull(telefono3ColumnIndex))
						record.TELEFONO3 = Convert.ToString(reader.GetValue(telefono3ColumnIndex));
					if(!reader.IsDBNull(email1ColumnIndex))
						record.EMAIL1 = Convert.ToString(reader.GetValue(email1ColumnIndex));
					if(!reader.IsDBNull(email2ColumnIndex))
						record.EMAIL2 = Convert.ToString(reader.GetValue(email2ColumnIndex));
					if(!reader.IsDBNull(agente_cuenta_nombreColumnIndex))
						record.AGENTE_CUENTA_NOMBRE = Convert.ToString(reader.GetValue(agente_cuenta_nombreColumnIndex));
					if(!reader.IsDBNull(agente_cuenta_telefono1ColumnIndex))
						record.AGENTE_CUENTA_TELEFONO1 = Convert.ToString(reader.GetValue(agente_cuenta_telefono1ColumnIndex));
					if(!reader.IsDBNull(agente_cuenta_telefono2ColumnIndex))
						record.AGENTE_CUENTA_TELEFONO2 = Convert.ToString(reader.GetValue(agente_cuenta_telefono2ColumnIndex));
					if(!reader.IsDBNull(agente_cuenta_telefono3ColumnIndex))
						record.AGENTE_CUENTA_TELEFONO3 = Convert.ToString(reader.GetValue(agente_cuenta_telefono3ColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.ES_NACIONAL = Convert.ToString(reader.GetValue(es_nacionalColumnIndex));
					record.ES_EXTRANJERO = Convert.ToString(reader.GetValue(es_extranjeroColumnIndex));
					if(!reader.IsDBNull(reporte_txt_modelo_idColumnIndex))
						record.REPORTE_TXT_MODELO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reporte_txt_modelo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_BANCOSRow[])(recordList.ToArray(typeof(CTACTE_BANCOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_BANCOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_BANCOSRow"/> object.</returns>
		protected virtual CTACTE_BANCOSRow MapRow(DataRow row)
		{
			CTACTE_BANCOSRow mappedObject = new CTACTE_BANCOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "REPORTE_PLANILLA_CHEQUES_ID"
			dataColumn = dataTable.Columns["REPORTE_PLANILLA_CHEQUES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REPORTE_PLANILLA_CHEQUES_ID = (decimal)row[dataColumn];
			// Column "RAZON_SOCIAL"
			dataColumn = dataTable.Columns["RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_SOCIAL = (string)row[dataColumn];
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "DIRECCION"
			dataColumn = dataTable.Columns["DIRECCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION = (string)row[dataColumn];
			// Column "TELEFONO1"
			dataColumn = dataTable.Columns["TELEFONO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO1 = (string)row[dataColumn];
			// Column "TELEFONO2"
			dataColumn = dataTable.Columns["TELEFONO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO2 = (string)row[dataColumn];
			// Column "TELEFONO3"
			dataColumn = dataTable.Columns["TELEFONO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO3 = (string)row[dataColumn];
			// Column "EMAIL1"
			dataColumn = dataTable.Columns["EMAIL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL1 = (string)row[dataColumn];
			// Column "EMAIL2"
			dataColumn = dataTable.Columns["EMAIL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL2 = (string)row[dataColumn];
			// Column "AGENTE_CUENTA_NOMBRE"
			dataColumn = dataTable.Columns["AGENTE_CUENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENTE_CUENTA_NOMBRE = (string)row[dataColumn];
			// Column "AGENTE_CUENTA_TELEFONO1"
			dataColumn = dataTable.Columns["AGENTE_CUENTA_TELEFONO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENTE_CUENTA_TELEFONO1 = (string)row[dataColumn];
			// Column "AGENTE_CUENTA_TELEFONO2"
			dataColumn = dataTable.Columns["AGENTE_CUENTA_TELEFONO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENTE_CUENTA_TELEFONO2 = (string)row[dataColumn];
			// Column "AGENTE_CUENTA_TELEFONO3"
			dataColumn = dataTable.Columns["AGENTE_CUENTA_TELEFONO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENTE_CUENTA_TELEFONO3 = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "ES_NACIONAL"
			dataColumn = dataTable.Columns["ES_NACIONAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_NACIONAL = (string)row[dataColumn];
			// Column "ES_EXTRANJERO"
			dataColumn = dataTable.Columns["ES_EXTRANJERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_EXTRANJERO = (string)row[dataColumn];
			// Column "REPORTE_TXT_MODELO_ID"
			dataColumn = dataTable.Columns["REPORTE_TXT_MODELO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REPORTE_TXT_MODELO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_BANCOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_BANCOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("REPORTE_PLANILLA_CHEQUES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIRECCION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("TELEFONO1", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO2", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO3", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("EMAIL1", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AGENTE_CUENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("AGENTE_CUENTA_TELEFONO1", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("AGENTE_CUENTA_TELEFONO2", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("AGENTE_CUENTA_TELEFONO3", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_NACIONAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_EXTRANJERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REPORTE_TXT_MODELO_ID", typeof(decimal));
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REPORTE_PLANILLA_CHEQUES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIRECCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENTE_CUENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENTE_CUENTA_TELEFONO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENTE_CUENTA_TELEFONO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENTE_CUENTA_TELEFONO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_NACIONAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_EXTRANJERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "REPORTE_TXT_MODELO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_BANCOSCollection_Base class
}  // End of namespace
