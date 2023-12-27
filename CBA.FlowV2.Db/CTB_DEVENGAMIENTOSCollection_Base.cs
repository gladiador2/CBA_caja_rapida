// <fileinfo name="CTB_DEVENGAMIENTOSCollection_Base.cs">
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
	/// The base class for <see cref="CTB_DEVENGAMIENTOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_DEVENGAMIENTOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_DEVENGAMIENTOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string LIMITE_DIAS_EN_SUSPENSOColumnName = "LIMITE_DIAS_EN_SUSPENSO";
		public const string A_DEVENGAR_VIGENTEColumnName = "A_DEVENGAR_VIGENTE";
		public const string A_DEVENGAR_VIGENTE_AUMColumnName = "A_DEVENGAR_VIGENTE_AUM";
		public const string A_DEVENGAR_VIGENTE_DISColumnName = "A_DEVENGAR_VIGENTE_DIS";
		public const string A_DEVENGAR_VENCIDOColumnName = "A_DEVENGAR_VENCIDO";
		public const string A_DEVENGAR_VENCIDO_AUMColumnName = "A_DEVENGAR_VENCIDO_AUM";
		public const string A_DEVENGAR_VENCIDO_DISColumnName = "A_DEVENGAR_VENCIDO_DIS";
		public const string DEVENGADOColumnName = "DEVENGADO";
		public const string DEVENGADO_AUMColumnName = "DEVENGADO_AUM";
		public const string DEVENGADO_DISColumnName = "DEVENGADO_DIS";
		public const string EN_SUSPENSOColumnName = "EN_SUSPENSO";
		public const string EN_SUSPENSO_AUMColumnName = "EN_SUSPENSO_AUM";
		public const string EN_SUSPENSO_DISColumnName = "EN_SUSPENSO_DIS";
		public const string CAPITAL_A_COBRAR_VIGENTEColumnName = "CAPITAL_A_COBRAR_VIGENTE";
		public const string CAPITAL_A_COBRAR_VIGENTE_AUMColumnName = "CAPITAL_A_COBRAR_VIGENTE_AUM";
		public const string CAPITAL_A_COBRAR_VIGENTE_DISColumnName = "CAPITAL_A_COBRAR_VIGENTE_DIS";
		public const string CAPITAL_A_COBRAR_VENCIDOColumnName = "CAPITAL_A_COBRAR_VENCIDO";
		public const string CAPITAL_A_COBRAR_VENCIDO_AUMColumnName = "CAPITAL_A_COBRAR_VENCIDO_AUM";
		public const string CAPITAL_A_COBRAR_VENCIDO_DISColumnName = "CAPITAL_A_COBRAR_VENCIDO_DIS";
		public const string INTERES_A_COBRAR_VIGENTEColumnName = "INTERES_A_COBRAR_VIGENTE";
		public const string INTERES_A_COBRAR_VIGENTE_AUMColumnName = "INTERES_A_COBRAR_VIGENTE_AUM";
		public const string INTERES_A_COBRAR_VIGENTE_DISColumnName = "INTERES_A_COBRAR_VIGENTE_DIS";
		public const string INTERES_A_COBRAR_VENCIDOColumnName = "INTERES_A_COBRAR_VENCIDO";
		public const string INTERES_A_COBRAR_VENCIDO_AUMColumnName = "INTERES_A_COBRAR_VENCIDO_AUM";
		public const string INTERES_A_COBRAR_VENCIDO_DISColumnName = "INTERES_A_COBRAR_VENCIDO_DIS";
		public const string ESTADOColumnName = "ESTADO";
		public const string CAPITAL_VENCIDO_COBRADOColumnName = "CAPITAL_VENCIDO_COBRADO";
		public const string INTERES_VENCIDO_COBRADOColumnName = "INTERES_VENCIDO_COBRADO";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string PERSONA_RELACIONADA_IDColumnName = "PERSONA_RELACIONADA_ID";
		public const string EXISTE_PERSONA_RELACIONADAColumnName = "EXISTE_PERSONA_RELACIONADA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_DEVENGAMIENTOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_DEVENGAMIENTOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_DEVENGAMIENTOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public virtual CTB_DEVENGAMIENTOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_DEVENGAMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_DEVENGAMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_DEVENGAMIENTOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_DEVENGAMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_DEVENGAMIENTOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_DEVENGAMIENTOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public CTB_DEVENGAMIENTOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public virtual CTB_DEVENGAMIENTOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_DEVENGAMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_DEVENGAMIENTOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_DEVENGAMIENTOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_DEVENGAMIENTOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_DEVENGAMIENTOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public CTB_DEVENGAMIENTOSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public virtual CTB_DEVENGAMIENTOSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecords(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_IDAsDataTable(canal_venta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public virtual CTB_DEVENGAMIENTOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_DEVENGAMIENTOS_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public CTB_DEVENGAMIENTOSRow[] GetByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id)
		{
			return GetByPERSONA_RELACIONADA_ID(persona_relacionada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public virtual CTB_DEVENGAMIENTOSRow[] GetByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			return MapRecords(CreateGetByPERSONA_RELACIONADA_IDCommand(persona_relacionada_id, persona_relacionada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_RELACIONADA_IDAsDataTable(decimal persona_relacionada_id)
		{
			return GetByPERSONA_RELACIONADA_IDAsDataTable(persona_relacionada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_RELACIONADA_IDAsDataTable(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_RELACIONADA_IDCommand(persona_relacionada_id, persona_relacionada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_RELACIONADA_IDCommand(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			string whereSql = "";
			if(persona_relacionada_idNull)
				whereSql += "PERSONA_RELACIONADA_ID IS NULL";
			else
				whereSql += "PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("PERSONA_RELACIONADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_relacionada_idNull)
				AddParameter(cmd, "PERSONA_RELACIONADA_ID", persona_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public CTB_DEVENGAMIENTOSRow[] GetByREGION_ID(decimal region_id)
		{
			return GetByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		public virtual CTB_DEVENGAMIENTOSRow[] GetByREGION_ID(decimal region_id, bool region_idNull)
		{
			return MapRecords(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREGION_IDAsDataTable(decimal region_id)
		{
			return GetByREGION_IDAsDataTable(region_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
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
		/// return records by the <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
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
		/// Adds a new record into the <c>CTB_DEVENGAMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_DEVENGAMIENTOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTB_DEVENGAMIENTOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_DEVENGAMIENTOS (" +
				"ID, " +
				"REGION_ID, " +
				"FECHA, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"LIMITE_DIAS_EN_SUSPENSO, " +
				"A_DEVENGAR_VIGENTE, " +
				"A_DEVENGAR_VIGENTE_AUM, " +
				"A_DEVENGAR_VIGENTE_DIS, " +
				"A_DEVENGAR_VENCIDO, " +
				"A_DEVENGAR_VENCIDO_AUM, " +
				"A_DEVENGAR_VENCIDO_DIS, " +
				"DEVENGADO, " +
				"DEVENGADO_AUM, " +
				"DEVENGADO_DIS, " +
				"EN_SUSPENSO, " +
				"EN_SUSPENSO_AUM, " +
				"EN_SUSPENSO_DIS, " +
				"CAPITAL_A_COBRAR_VIGENTE, " +
				"CAPITAL_A_COBRAR_VIGENTE_AUM, " +
				"CAPITAL_A_COBRAR_VIGENTE_DIS, " +
				"CAPITAL_A_COBRAR_VENCIDO, " +
				"CAPITAL_A_COBRAR_VENCIDO_AUM, " +
				"CAPITAL_A_COBRAR_VENCIDO_DIS, " +
				"INTERES_A_COBRAR_VIGENTE, " +
				"INTERES_A_COBRAR_VIGENTE_AUM, " +
				"INTERES_A_COBRAR_VIGENTE_DIS, " +
				"INTERES_A_COBRAR_VENCIDO, " +
				"INTERES_A_COBRAR_VENCIDO_AUM, " +
				"INTERES_A_COBRAR_VENCIDO_DIS, " +
				"ESTADO, " +
				"CAPITAL_VENCIDO_COBRADO, " +
				"INTERES_VENCIDO_COBRADO, " +
				"CANAL_VENTA_ID, " +
				"PERSONA_RELACIONADA_ID, " +
				"EXISTE_PERSONA_RELACIONADA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("REGION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("LIMITE_DIAS_EN_SUSPENSO") + ", " +
				_db.CreateSqlParameterName("A_DEVENGAR_VIGENTE") + ", " +
				_db.CreateSqlParameterName("A_DEVENGAR_VIGENTE_AUM") + ", " +
				_db.CreateSqlParameterName("A_DEVENGAR_VIGENTE_DIS") + ", " +
				_db.CreateSqlParameterName("A_DEVENGAR_VENCIDO") + ", " +
				_db.CreateSqlParameterName("A_DEVENGAR_VENCIDO_AUM") + ", " +
				_db.CreateSqlParameterName("A_DEVENGAR_VENCIDO_DIS") + ", " +
				_db.CreateSqlParameterName("DEVENGADO") + ", " +
				_db.CreateSqlParameterName("DEVENGADO_AUM") + ", " +
				_db.CreateSqlParameterName("DEVENGADO_DIS") + ", " +
				_db.CreateSqlParameterName("EN_SUSPENSO") + ", " +
				_db.CreateSqlParameterName("EN_SUSPENSO_AUM") + ", " +
				_db.CreateSqlParameterName("EN_SUSPENSO_DIS") + ", " +
				_db.CreateSqlParameterName("CAPITAL_A_COBRAR_VIGENTE") + ", " +
				_db.CreateSqlParameterName("CAPITAL_A_COBRAR_VIGENTE_AUM") + ", " +
				_db.CreateSqlParameterName("CAPITAL_A_COBRAR_VIGENTE_DIS") + ", " +
				_db.CreateSqlParameterName("CAPITAL_A_COBRAR_VENCIDO") + ", " +
				_db.CreateSqlParameterName("CAPITAL_A_COBRAR_VENCIDO_AUM") + ", " +
				_db.CreateSqlParameterName("CAPITAL_A_COBRAR_VENCIDO_DIS") + ", " +
				_db.CreateSqlParameterName("INTERES_A_COBRAR_VIGENTE") + ", " +
				_db.CreateSqlParameterName("INTERES_A_COBRAR_VIGENTE_AUM") + ", " +
				_db.CreateSqlParameterName("INTERES_A_COBRAR_VIGENTE_DIS") + ", " +
				_db.CreateSqlParameterName("INTERES_A_COBRAR_VENCIDO") + ", " +
				_db.CreateSqlParameterName("INTERES_A_COBRAR_VENCIDO_AUM") + ", " +
				_db.CreateSqlParameterName("INTERES_A_COBRAR_VENCIDO_DIS") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("CAPITAL_VENCIDO_COBRADO") + ", " +
				_db.CreateSqlParameterName("INTERES_VENCIDO_COBRADO") + ", " +
				_db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_RELACIONADA_ID") + ", " +
				_db.CreateSqlParameterName("EXISTE_PERSONA_RELACIONADA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "LIMITE_DIAS_EN_SUSPENSO", value.LIMITE_DIAS_EN_SUSPENSO);
			AddParameter(cmd, "A_DEVENGAR_VIGENTE", value.A_DEVENGAR_VIGENTE);
			AddParameter(cmd, "A_DEVENGAR_VIGENTE_AUM", value.A_DEVENGAR_VIGENTE_AUM);
			AddParameter(cmd, "A_DEVENGAR_VIGENTE_DIS", value.A_DEVENGAR_VIGENTE_DIS);
			AddParameter(cmd, "A_DEVENGAR_VENCIDO", value.A_DEVENGAR_VENCIDO);
			AddParameter(cmd, "A_DEVENGAR_VENCIDO_AUM", value.A_DEVENGAR_VENCIDO_AUM);
			AddParameter(cmd, "A_DEVENGAR_VENCIDO_DIS", value.A_DEVENGAR_VENCIDO_DIS);
			AddParameter(cmd, "DEVENGADO", value.DEVENGADO);
			AddParameter(cmd, "DEVENGADO_AUM", value.DEVENGADO_AUM);
			AddParameter(cmd, "DEVENGADO_DIS", value.DEVENGADO_DIS);
			AddParameter(cmd, "EN_SUSPENSO", value.EN_SUSPENSO);
			AddParameter(cmd, "EN_SUSPENSO_AUM", value.EN_SUSPENSO_AUM);
			AddParameter(cmd, "EN_SUSPENSO_DIS", value.EN_SUSPENSO_DIS);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VIGENTE", value.CAPITAL_A_COBRAR_VIGENTE);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VIGENTE_AUM", value.CAPITAL_A_COBRAR_VIGENTE_AUM);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VIGENTE_DIS", value.CAPITAL_A_COBRAR_VIGENTE_DIS);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VENCIDO", value.CAPITAL_A_COBRAR_VENCIDO);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VENCIDO_AUM", value.CAPITAL_A_COBRAR_VENCIDO_AUM);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VENCIDO_DIS", value.CAPITAL_A_COBRAR_VENCIDO_DIS);
			AddParameter(cmd, "INTERES_A_COBRAR_VIGENTE", value.INTERES_A_COBRAR_VIGENTE);
			AddParameter(cmd, "INTERES_A_COBRAR_VIGENTE_AUM", value.INTERES_A_COBRAR_VIGENTE_AUM);
			AddParameter(cmd, "INTERES_A_COBRAR_VIGENTE_DIS", value.INTERES_A_COBRAR_VIGENTE_DIS);
			AddParameter(cmd, "INTERES_A_COBRAR_VENCIDO", value.INTERES_A_COBRAR_VENCIDO);
			AddParameter(cmd, "INTERES_A_COBRAR_VENCIDO_AUM", value.INTERES_A_COBRAR_VENCIDO_AUM);
			AddParameter(cmd, "INTERES_A_COBRAR_VENCIDO_DIS", value.INTERES_A_COBRAR_VENCIDO_DIS);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CAPITAL_VENCIDO_COBRADO", value.CAPITAL_VENCIDO_COBRADO);
			AddParameter(cmd, "INTERES_VENCIDO_COBRADO", value.INTERES_VENCIDO_COBRADO);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "PERSONA_RELACIONADA_ID",
				value.IsPERSONA_RELACIONADA_IDNull ? DBNull.Value : (object)value.PERSONA_RELACIONADA_ID);
			AddParameter(cmd, "EXISTE_PERSONA_RELACIONADA", value.EXISTE_PERSONA_RELACIONADA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_DEVENGAMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_DEVENGAMIENTOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_DEVENGAMIENTOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_DEVENGAMIENTOS SET " +
				"REGION_ID=" + _db.CreateSqlParameterName("REGION_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"LIMITE_DIAS_EN_SUSPENSO=" + _db.CreateSqlParameterName("LIMITE_DIAS_EN_SUSPENSO") + ", " +
				"A_DEVENGAR_VIGENTE=" + _db.CreateSqlParameterName("A_DEVENGAR_VIGENTE") + ", " +
				"A_DEVENGAR_VIGENTE_AUM=" + _db.CreateSqlParameterName("A_DEVENGAR_VIGENTE_AUM") + ", " +
				"A_DEVENGAR_VIGENTE_DIS=" + _db.CreateSqlParameterName("A_DEVENGAR_VIGENTE_DIS") + ", " +
				"A_DEVENGAR_VENCIDO=" + _db.CreateSqlParameterName("A_DEVENGAR_VENCIDO") + ", " +
				"A_DEVENGAR_VENCIDO_AUM=" + _db.CreateSqlParameterName("A_DEVENGAR_VENCIDO_AUM") + ", " +
				"A_DEVENGAR_VENCIDO_DIS=" + _db.CreateSqlParameterName("A_DEVENGAR_VENCIDO_DIS") + ", " +
				"DEVENGADO=" + _db.CreateSqlParameterName("DEVENGADO") + ", " +
				"DEVENGADO_AUM=" + _db.CreateSqlParameterName("DEVENGADO_AUM") + ", " +
				"DEVENGADO_DIS=" + _db.CreateSqlParameterName("DEVENGADO_DIS") + ", " +
				"EN_SUSPENSO=" + _db.CreateSqlParameterName("EN_SUSPENSO") + ", " +
				"EN_SUSPENSO_AUM=" + _db.CreateSqlParameterName("EN_SUSPENSO_AUM") + ", " +
				"EN_SUSPENSO_DIS=" + _db.CreateSqlParameterName("EN_SUSPENSO_DIS") + ", " +
				"CAPITAL_A_COBRAR_VIGENTE=" + _db.CreateSqlParameterName("CAPITAL_A_COBRAR_VIGENTE") + ", " +
				"CAPITAL_A_COBRAR_VIGENTE_AUM=" + _db.CreateSqlParameterName("CAPITAL_A_COBRAR_VIGENTE_AUM") + ", " +
				"CAPITAL_A_COBRAR_VIGENTE_DIS=" + _db.CreateSqlParameterName("CAPITAL_A_COBRAR_VIGENTE_DIS") + ", " +
				"CAPITAL_A_COBRAR_VENCIDO=" + _db.CreateSqlParameterName("CAPITAL_A_COBRAR_VENCIDO") + ", " +
				"CAPITAL_A_COBRAR_VENCIDO_AUM=" + _db.CreateSqlParameterName("CAPITAL_A_COBRAR_VENCIDO_AUM") + ", " +
				"CAPITAL_A_COBRAR_VENCIDO_DIS=" + _db.CreateSqlParameterName("CAPITAL_A_COBRAR_VENCIDO_DIS") + ", " +
				"INTERES_A_COBRAR_VIGENTE=" + _db.CreateSqlParameterName("INTERES_A_COBRAR_VIGENTE") + ", " +
				"INTERES_A_COBRAR_VIGENTE_AUM=" + _db.CreateSqlParameterName("INTERES_A_COBRAR_VIGENTE_AUM") + ", " +
				"INTERES_A_COBRAR_VIGENTE_DIS=" + _db.CreateSqlParameterName("INTERES_A_COBRAR_VIGENTE_DIS") + ", " +
				"INTERES_A_COBRAR_VENCIDO=" + _db.CreateSqlParameterName("INTERES_A_COBRAR_VENCIDO") + ", " +
				"INTERES_A_COBRAR_VENCIDO_AUM=" + _db.CreateSqlParameterName("INTERES_A_COBRAR_VENCIDO_AUM") + ", " +
				"INTERES_A_COBRAR_VENCIDO_DIS=" + _db.CreateSqlParameterName("INTERES_A_COBRAR_VENCIDO_DIS") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"CAPITAL_VENCIDO_COBRADO=" + _db.CreateSqlParameterName("CAPITAL_VENCIDO_COBRADO") + ", " +
				"INTERES_VENCIDO_COBRADO=" + _db.CreateSqlParameterName("INTERES_VENCIDO_COBRADO") + ", " +
				"CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				"PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("PERSONA_RELACIONADA_ID") + ", " +
				"EXISTE_PERSONA_RELACIONADA=" + _db.CreateSqlParameterName("EXISTE_PERSONA_RELACIONADA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "LIMITE_DIAS_EN_SUSPENSO", value.LIMITE_DIAS_EN_SUSPENSO);
			AddParameter(cmd, "A_DEVENGAR_VIGENTE", value.A_DEVENGAR_VIGENTE);
			AddParameter(cmd, "A_DEVENGAR_VIGENTE_AUM", value.A_DEVENGAR_VIGENTE_AUM);
			AddParameter(cmd, "A_DEVENGAR_VIGENTE_DIS", value.A_DEVENGAR_VIGENTE_DIS);
			AddParameter(cmd, "A_DEVENGAR_VENCIDO", value.A_DEVENGAR_VENCIDO);
			AddParameter(cmd, "A_DEVENGAR_VENCIDO_AUM", value.A_DEVENGAR_VENCIDO_AUM);
			AddParameter(cmd, "A_DEVENGAR_VENCIDO_DIS", value.A_DEVENGAR_VENCIDO_DIS);
			AddParameter(cmd, "DEVENGADO", value.DEVENGADO);
			AddParameter(cmd, "DEVENGADO_AUM", value.DEVENGADO_AUM);
			AddParameter(cmd, "DEVENGADO_DIS", value.DEVENGADO_DIS);
			AddParameter(cmd, "EN_SUSPENSO", value.EN_SUSPENSO);
			AddParameter(cmd, "EN_SUSPENSO_AUM", value.EN_SUSPENSO_AUM);
			AddParameter(cmd, "EN_SUSPENSO_DIS", value.EN_SUSPENSO_DIS);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VIGENTE", value.CAPITAL_A_COBRAR_VIGENTE);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VIGENTE_AUM", value.CAPITAL_A_COBRAR_VIGENTE_AUM);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VIGENTE_DIS", value.CAPITAL_A_COBRAR_VIGENTE_DIS);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VENCIDO", value.CAPITAL_A_COBRAR_VENCIDO);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VENCIDO_AUM", value.CAPITAL_A_COBRAR_VENCIDO_AUM);
			AddParameter(cmd, "CAPITAL_A_COBRAR_VENCIDO_DIS", value.CAPITAL_A_COBRAR_VENCIDO_DIS);
			AddParameter(cmd, "INTERES_A_COBRAR_VIGENTE", value.INTERES_A_COBRAR_VIGENTE);
			AddParameter(cmd, "INTERES_A_COBRAR_VIGENTE_AUM", value.INTERES_A_COBRAR_VIGENTE_AUM);
			AddParameter(cmd, "INTERES_A_COBRAR_VIGENTE_DIS", value.INTERES_A_COBRAR_VIGENTE_DIS);
			AddParameter(cmd, "INTERES_A_COBRAR_VENCIDO", value.INTERES_A_COBRAR_VENCIDO);
			AddParameter(cmd, "INTERES_A_COBRAR_VENCIDO_AUM", value.INTERES_A_COBRAR_VENCIDO_AUM);
			AddParameter(cmd, "INTERES_A_COBRAR_VENCIDO_DIS", value.INTERES_A_COBRAR_VENCIDO_DIS);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "CAPITAL_VENCIDO_COBRADO", value.CAPITAL_VENCIDO_COBRADO);
			AddParameter(cmd, "INTERES_VENCIDO_COBRADO", value.INTERES_VENCIDO_COBRADO);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "PERSONA_RELACIONADA_ID",
				value.IsPERSONA_RELACIONADA_IDNull ? DBNull.Value : (object)value.PERSONA_RELACIONADA_ID);
			AddParameter(cmd, "EXISTE_PERSONA_RELACIONADA", value.EXISTE_PERSONA_RELACIONADA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_DEVENGAMIENTOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_DEVENGAMIENTOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_DEVENGAMIENTOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_DEVENGAMIENTOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_DEVENGAMIENTOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_DEVENGAMIENTOS</c> table using
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
		/// Deletes records from the <c>CTB_DEVENGAMIENTOS</c> table using the 
		/// <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return DeleteByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_DEVENGAMIENTOS</c> table using the 
		/// <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return CreateDeleteByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_DEVENGAMIENTOS_CANAL_VE</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_DEVENGAMIENTOS</c> table using the 
		/// <c>FK_CTB_DEVENGAMIENTOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_DEVENGAMIENTOS_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTB_DEVENGAMIENTOS</c> table using the 
		/// <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id)
		{
			return DeleteByPERSONA_RELACIONADA_ID(persona_relacionada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_DEVENGAMIENTOS</c> table using the 
		/// <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_RELACIONADA_ID(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			return CreateDeleteByPERSONA_RELACIONADA_IDCommand(persona_relacionada_id, persona_relacionada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_DEVENGAMIENTOS_PERS_REL</c> foreign key.
		/// </summary>
		/// <param name="persona_relacionada_id">The <c>PERSONA_RELACIONADA_ID</c> column value.</param>
		/// <param name="persona_relacionada_idNull">true if the method ignores the persona_relacionada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_RELACIONADA_IDCommand(decimal persona_relacionada_id, bool persona_relacionada_idNull)
		{
			string whereSql = "";
			if(persona_relacionada_idNull)
				whereSql += "PERSONA_RELACIONADA_ID IS NULL";
			else
				whereSql += "PERSONA_RELACIONADA_ID=" + _db.CreateSqlParameterName("PERSONA_RELACIONADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_relacionada_idNull)
				AddParameter(cmd, "PERSONA_RELACIONADA_ID", persona_relacionada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_DEVENGAMIENTOS</c> table using the 
		/// <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id)
		{
			return DeleteByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_DEVENGAMIENTOS</c> table using the 
		/// <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
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
		/// delete records using the <c>FK_CTB_DEVENGAMIENTOS_REGION</c> foreign key.
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
		/// Deletes <c>CTB_DEVENGAMIENTOS</c> records that match the specified criteria.
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
		/// to delete <c>CTB_DEVENGAMIENTOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_DEVENGAMIENTOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_DEVENGAMIENTOS</c> table.
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
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		protected CTB_DEVENGAMIENTOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		protected CTB_DEVENGAMIENTOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_DEVENGAMIENTOSRow"/> objects.</returns>
		protected virtual CTB_DEVENGAMIENTOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int limite_dias_en_suspensoColumnIndex = reader.GetOrdinal("LIMITE_DIAS_EN_SUSPENSO");
			int a_devengar_vigenteColumnIndex = reader.GetOrdinal("A_DEVENGAR_VIGENTE");
			int a_devengar_vigente_aumColumnIndex = reader.GetOrdinal("A_DEVENGAR_VIGENTE_AUM");
			int a_devengar_vigente_disColumnIndex = reader.GetOrdinal("A_DEVENGAR_VIGENTE_DIS");
			int a_devengar_vencidoColumnIndex = reader.GetOrdinal("A_DEVENGAR_VENCIDO");
			int a_devengar_vencido_aumColumnIndex = reader.GetOrdinal("A_DEVENGAR_VENCIDO_AUM");
			int a_devengar_vencido_disColumnIndex = reader.GetOrdinal("A_DEVENGAR_VENCIDO_DIS");
			int devengadoColumnIndex = reader.GetOrdinal("DEVENGADO");
			int devengado_aumColumnIndex = reader.GetOrdinal("DEVENGADO_AUM");
			int devengado_disColumnIndex = reader.GetOrdinal("DEVENGADO_DIS");
			int en_suspensoColumnIndex = reader.GetOrdinal("EN_SUSPENSO");
			int en_suspenso_aumColumnIndex = reader.GetOrdinal("EN_SUSPENSO_AUM");
			int en_suspenso_disColumnIndex = reader.GetOrdinal("EN_SUSPENSO_DIS");
			int capital_a_cobrar_vigenteColumnIndex = reader.GetOrdinal("CAPITAL_A_COBRAR_VIGENTE");
			int capital_a_cobrar_vigente_aumColumnIndex = reader.GetOrdinal("CAPITAL_A_COBRAR_VIGENTE_AUM");
			int capital_a_cobrar_vigente_disColumnIndex = reader.GetOrdinal("CAPITAL_A_COBRAR_VIGENTE_DIS");
			int capital_a_cobrar_vencidoColumnIndex = reader.GetOrdinal("CAPITAL_A_COBRAR_VENCIDO");
			int capital_a_cobrar_vencido_aumColumnIndex = reader.GetOrdinal("CAPITAL_A_COBRAR_VENCIDO_AUM");
			int capital_a_cobrar_vencido_disColumnIndex = reader.GetOrdinal("CAPITAL_A_COBRAR_VENCIDO_DIS");
			int interes_a_cobrar_vigenteColumnIndex = reader.GetOrdinal("INTERES_A_COBRAR_VIGENTE");
			int interes_a_cobrar_vigente_aumColumnIndex = reader.GetOrdinal("INTERES_A_COBRAR_VIGENTE_AUM");
			int interes_a_cobrar_vigente_disColumnIndex = reader.GetOrdinal("INTERES_A_COBRAR_VIGENTE_DIS");
			int interes_a_cobrar_vencidoColumnIndex = reader.GetOrdinal("INTERES_A_COBRAR_VENCIDO");
			int interes_a_cobrar_vencido_aumColumnIndex = reader.GetOrdinal("INTERES_A_COBRAR_VENCIDO_AUM");
			int interes_a_cobrar_vencido_disColumnIndex = reader.GetOrdinal("INTERES_A_COBRAR_VENCIDO_DIS");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int capital_vencido_cobradoColumnIndex = reader.GetOrdinal("CAPITAL_VENCIDO_COBRADO");
			int interes_vencido_cobradoColumnIndex = reader.GetOrdinal("INTERES_VENCIDO_COBRADO");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int persona_relacionada_idColumnIndex = reader.GetOrdinal("PERSONA_RELACIONADA_ID");
			int existe_persona_relacionadaColumnIndex = reader.GetOrdinal("EXISTE_PERSONA_RELACIONADA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_DEVENGAMIENTOSRow record = new CTB_DEVENGAMIENTOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.LIMITE_DIAS_EN_SUSPENSO = Math.Round(Convert.ToDecimal(reader.GetValue(limite_dias_en_suspensoColumnIndex)), 9);
					record.A_DEVENGAR_VIGENTE = Math.Round(Convert.ToDecimal(reader.GetValue(a_devengar_vigenteColumnIndex)), 9);
					record.A_DEVENGAR_VIGENTE_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(a_devengar_vigente_aumColumnIndex)), 9);
					record.A_DEVENGAR_VIGENTE_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(a_devengar_vigente_disColumnIndex)), 9);
					record.A_DEVENGAR_VENCIDO = Math.Round(Convert.ToDecimal(reader.GetValue(a_devengar_vencidoColumnIndex)), 9);
					record.A_DEVENGAR_VENCIDO_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(a_devengar_vencido_aumColumnIndex)), 9);
					record.A_DEVENGAR_VENCIDO_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(a_devengar_vencido_disColumnIndex)), 9);
					record.DEVENGADO = Math.Round(Convert.ToDecimal(reader.GetValue(devengadoColumnIndex)), 9);
					record.DEVENGADO_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(devengado_aumColumnIndex)), 9);
					record.DEVENGADO_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(devengado_disColumnIndex)), 9);
					record.EN_SUSPENSO = Math.Round(Convert.ToDecimal(reader.GetValue(en_suspensoColumnIndex)), 9);
					record.EN_SUSPENSO_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(en_suspenso_aumColumnIndex)), 9);
					record.EN_SUSPENSO_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(en_suspenso_disColumnIndex)), 9);
					record.CAPITAL_A_COBRAR_VIGENTE = Math.Round(Convert.ToDecimal(reader.GetValue(capital_a_cobrar_vigenteColumnIndex)), 9);
					record.CAPITAL_A_COBRAR_VIGENTE_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(capital_a_cobrar_vigente_aumColumnIndex)), 9);
					record.CAPITAL_A_COBRAR_VIGENTE_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(capital_a_cobrar_vigente_disColumnIndex)), 9);
					record.CAPITAL_A_COBRAR_VENCIDO = Math.Round(Convert.ToDecimal(reader.GetValue(capital_a_cobrar_vencidoColumnIndex)), 9);
					record.CAPITAL_A_COBRAR_VENCIDO_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(capital_a_cobrar_vencido_aumColumnIndex)), 9);
					record.CAPITAL_A_COBRAR_VENCIDO_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(capital_a_cobrar_vencido_disColumnIndex)), 9);
					record.INTERES_A_COBRAR_VIGENTE = Math.Round(Convert.ToDecimal(reader.GetValue(interes_a_cobrar_vigenteColumnIndex)), 9);
					record.INTERES_A_COBRAR_VIGENTE_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(interes_a_cobrar_vigente_aumColumnIndex)), 9);
					record.INTERES_A_COBRAR_VIGENTE_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(interes_a_cobrar_vigente_disColumnIndex)), 9);
					record.INTERES_A_COBRAR_VENCIDO = Math.Round(Convert.ToDecimal(reader.GetValue(interes_a_cobrar_vencidoColumnIndex)), 9);
					record.INTERES_A_COBRAR_VENCIDO_AUM = Math.Round(Convert.ToDecimal(reader.GetValue(interes_a_cobrar_vencido_aumColumnIndex)), 9);
					record.INTERES_A_COBRAR_VENCIDO_DIS = Math.Round(Convert.ToDecimal(reader.GetValue(interes_a_cobrar_vencido_disColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.CAPITAL_VENCIDO_COBRADO = Math.Round(Convert.ToDecimal(reader.GetValue(capital_vencido_cobradoColumnIndex)), 9);
					record.INTERES_VENCIDO_COBRADO = Math.Round(Convert.ToDecimal(reader.GetValue(interes_vencido_cobradoColumnIndex)), 9);
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_relacionada_idColumnIndex))
						record.PERSONA_RELACIONADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_relacionada_idColumnIndex)), 9);
					if(!reader.IsDBNull(existe_persona_relacionadaColumnIndex))
						record.EXISTE_PERSONA_RELACIONADA = Convert.ToString(reader.GetValue(existe_persona_relacionadaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_DEVENGAMIENTOSRow[])(recordList.ToArray(typeof(CTB_DEVENGAMIENTOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_DEVENGAMIENTOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_DEVENGAMIENTOSRow"/> object.</returns>
		protected virtual CTB_DEVENGAMIENTOSRow MapRow(DataRow row)
		{
			CTB_DEVENGAMIENTOSRow mappedObject = new CTB_DEVENGAMIENTOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "LIMITE_DIAS_EN_SUSPENSO"
			dataColumn = dataTable.Columns["LIMITE_DIAS_EN_SUSPENSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_DIAS_EN_SUSPENSO = (decimal)row[dataColumn];
			// Column "A_DEVENGAR_VIGENTE"
			dataColumn = dataTable.Columns["A_DEVENGAR_VIGENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_DEVENGAR_VIGENTE = (decimal)row[dataColumn];
			// Column "A_DEVENGAR_VIGENTE_AUM"
			dataColumn = dataTable.Columns["A_DEVENGAR_VIGENTE_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_DEVENGAR_VIGENTE_AUM = (decimal)row[dataColumn];
			// Column "A_DEVENGAR_VIGENTE_DIS"
			dataColumn = dataTable.Columns["A_DEVENGAR_VIGENTE_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_DEVENGAR_VIGENTE_DIS = (decimal)row[dataColumn];
			// Column "A_DEVENGAR_VENCIDO"
			dataColumn = dataTable.Columns["A_DEVENGAR_VENCIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_DEVENGAR_VENCIDO = (decimal)row[dataColumn];
			// Column "A_DEVENGAR_VENCIDO_AUM"
			dataColumn = dataTable.Columns["A_DEVENGAR_VENCIDO_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_DEVENGAR_VENCIDO_AUM = (decimal)row[dataColumn];
			// Column "A_DEVENGAR_VENCIDO_DIS"
			dataColumn = dataTable.Columns["A_DEVENGAR_VENCIDO_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_DEVENGAR_VENCIDO_DIS = (decimal)row[dataColumn];
			// Column "DEVENGADO"
			dataColumn = dataTable.Columns["DEVENGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEVENGADO = (decimal)row[dataColumn];
			// Column "DEVENGADO_AUM"
			dataColumn = dataTable.Columns["DEVENGADO_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEVENGADO_AUM = (decimal)row[dataColumn];
			// Column "DEVENGADO_DIS"
			dataColumn = dataTable.Columns["DEVENGADO_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEVENGADO_DIS = (decimal)row[dataColumn];
			// Column "EN_SUSPENSO"
			dataColumn = dataTable.Columns["EN_SUSPENSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_SUSPENSO = (decimal)row[dataColumn];
			// Column "EN_SUSPENSO_AUM"
			dataColumn = dataTable.Columns["EN_SUSPENSO_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_SUSPENSO_AUM = (decimal)row[dataColumn];
			// Column "EN_SUSPENSO_DIS"
			dataColumn = dataTable.Columns["EN_SUSPENSO_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_SUSPENSO_DIS = (decimal)row[dataColumn];
			// Column "CAPITAL_A_COBRAR_VIGENTE"
			dataColumn = dataTable.Columns["CAPITAL_A_COBRAR_VIGENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPITAL_A_COBRAR_VIGENTE = (decimal)row[dataColumn];
			// Column "CAPITAL_A_COBRAR_VIGENTE_AUM"
			dataColumn = dataTable.Columns["CAPITAL_A_COBRAR_VIGENTE_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPITAL_A_COBRAR_VIGENTE_AUM = (decimal)row[dataColumn];
			// Column "CAPITAL_A_COBRAR_VIGENTE_DIS"
			dataColumn = dataTable.Columns["CAPITAL_A_COBRAR_VIGENTE_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPITAL_A_COBRAR_VIGENTE_DIS = (decimal)row[dataColumn];
			// Column "CAPITAL_A_COBRAR_VENCIDO"
			dataColumn = dataTable.Columns["CAPITAL_A_COBRAR_VENCIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPITAL_A_COBRAR_VENCIDO = (decimal)row[dataColumn];
			// Column "CAPITAL_A_COBRAR_VENCIDO_AUM"
			dataColumn = dataTable.Columns["CAPITAL_A_COBRAR_VENCIDO_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPITAL_A_COBRAR_VENCIDO_AUM = (decimal)row[dataColumn];
			// Column "CAPITAL_A_COBRAR_VENCIDO_DIS"
			dataColumn = dataTable.Columns["CAPITAL_A_COBRAR_VENCIDO_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPITAL_A_COBRAR_VENCIDO_DIS = (decimal)row[dataColumn];
			// Column "INTERES_A_COBRAR_VIGENTE"
			dataColumn = dataTable.Columns["INTERES_A_COBRAR_VIGENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_A_COBRAR_VIGENTE = (decimal)row[dataColumn];
			// Column "INTERES_A_COBRAR_VIGENTE_AUM"
			dataColumn = dataTable.Columns["INTERES_A_COBRAR_VIGENTE_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_A_COBRAR_VIGENTE_AUM = (decimal)row[dataColumn];
			// Column "INTERES_A_COBRAR_VIGENTE_DIS"
			dataColumn = dataTable.Columns["INTERES_A_COBRAR_VIGENTE_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_A_COBRAR_VIGENTE_DIS = (decimal)row[dataColumn];
			// Column "INTERES_A_COBRAR_VENCIDO"
			dataColumn = dataTable.Columns["INTERES_A_COBRAR_VENCIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_A_COBRAR_VENCIDO = (decimal)row[dataColumn];
			// Column "INTERES_A_COBRAR_VENCIDO_AUM"
			dataColumn = dataTable.Columns["INTERES_A_COBRAR_VENCIDO_AUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_A_COBRAR_VENCIDO_AUM = (decimal)row[dataColumn];
			// Column "INTERES_A_COBRAR_VENCIDO_DIS"
			dataColumn = dataTable.Columns["INTERES_A_COBRAR_VENCIDO_DIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_A_COBRAR_VENCIDO_DIS = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CAPITAL_VENCIDO_COBRADO"
			dataColumn = dataTable.Columns["CAPITAL_VENCIDO_COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPITAL_VENCIDO_COBRADO = (decimal)row[dataColumn];
			// Column "INTERES_VENCIDO_COBRADO"
			dataColumn = dataTable.Columns["INTERES_VENCIDO_COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_VENCIDO_COBRADO = (decimal)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["PERSONA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_RELACIONADA_ID = (decimal)row[dataColumn];
			// Column "EXISTE_PERSONA_RELACIONADA"
			dataColumn = dataTable.Columns["EXISTE_PERSONA_RELACIONADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTE_PERSONA_RELACIONADA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_DEVENGAMIENTOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_DEVENGAMIENTOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIMITE_DIAS_EN_SUSPENSO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("A_DEVENGAR_VIGENTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("A_DEVENGAR_VIGENTE_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("A_DEVENGAR_VIGENTE_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("A_DEVENGAR_VENCIDO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("A_DEVENGAR_VENCIDO_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("A_DEVENGAR_VENCIDO_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEVENGADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEVENGADO_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEVENGADO_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EN_SUSPENSO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EN_SUSPENSO_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EN_SUSPENSO_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPITAL_A_COBRAR_VIGENTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPITAL_A_COBRAR_VIGENTE_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPITAL_A_COBRAR_VIGENTE_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPITAL_A_COBRAR_VENCIDO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPITAL_A_COBRAR_VENCIDO_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPITAL_A_COBRAR_VENCIDO_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_A_COBRAR_VIGENTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_A_COBRAR_VIGENTE_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_A_COBRAR_VIGENTE_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_A_COBRAR_VENCIDO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_A_COBRAR_VENCIDO_AUM", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_A_COBRAR_VENCIDO_DIS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CAPITAL_VENCIDO_COBRADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_VENCIDO_COBRADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_RELACIONADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EXISTE_PERSONA_RELACIONADA", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_DIAS_EN_SUSPENSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "A_DEVENGAR_VIGENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "A_DEVENGAR_VIGENTE_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "A_DEVENGAR_VIGENTE_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "A_DEVENGAR_VENCIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "A_DEVENGAR_VENCIDO_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "A_DEVENGAR_VENCIDO_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEVENGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEVENGADO_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEVENGADO_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EN_SUSPENSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EN_SUSPENSO_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EN_SUSPENSO_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPITAL_A_COBRAR_VIGENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPITAL_A_COBRAR_VIGENTE_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPITAL_A_COBRAR_VIGENTE_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPITAL_A_COBRAR_VENCIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPITAL_A_COBRAR_VENCIDO_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPITAL_A_COBRAR_VENCIDO_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_A_COBRAR_VIGENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_A_COBRAR_VIGENTE_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_A_COBRAR_VIGENTE_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_A_COBRAR_VENCIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_A_COBRAR_VENCIDO_AUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_A_COBRAR_VENCIDO_DIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CAPITAL_VENCIDO_COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_VENCIDO_COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EXISTE_PERSONA_RELACIONADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_DEVENGAMIENTOSCollection_Base class
}  // End of namespace
