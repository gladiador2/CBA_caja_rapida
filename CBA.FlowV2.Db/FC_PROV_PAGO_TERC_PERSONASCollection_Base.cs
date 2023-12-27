// <fileinfo name="FC_PROV_PAGO_TERC_PERSONASCollection_Base.cs">
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
	/// The base class for <see cref="FC_PROV_PAGO_TERC_PERSONASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FC_PROV_PAGO_TERC_PERSONASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FC_PROV_PAGO_TERC_PERSONASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FC_PROVEEDOR_IDColumnName = "FC_PROVEEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PORC_COMISIONColumnName = "PORC_COMISION";
		public const string PORC_ASIGNADOColumnName = "PORC_ASIGNADO";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string PORC_ASIGNADO_CUOTAColumnName = "PORC_ASIGNADO_CUOTA";
		public const string TOTAL_CUOTASColumnName = "TOTAL_CUOTAS";
		public const string NRO_CUOTAColumnName = "NRO_CUOTA";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FC_PROV_PAGO_TERC_PERSONASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FC_PROV_PAGO_TERC_PERSONASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		public virtual FC_PROV_PAGO_TERC_PERSONASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FC_PROV_PAGO_TERC_PERSONASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FC_PROV_PAGO_TERC_PERSONASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		public FC_PROV_PAGO_TERC_PERSONASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects that 
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
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		public virtual FC_PROV_PAGO_TERC_PERSONASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FC_PROV_PAGO_TERC_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FC_PROV_PAGO_TERC_PERSONASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FC_PROV_PAGO_TERC_PERSONASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects 
		/// by the <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		public FC_PROV_PAGO_TERC_PERSONASRow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects 
		/// by the <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		public virtual FC_PROV_PAGO_TERC_PERSONASRow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecords(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_IDAsDataTable(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects 
		/// by the <c>FK_FC_PROV_PAG_TER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		public virtual FC_PROV_PAGO_TERC_PERSONASRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FC_PROV_PAG_TER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FC_PROV_PAG_TER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects 
		/// by the <c>FK_FC_PROV_PAG_TER_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="fc_proveedor_id">The <c>FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		public virtual FC_PROV_PAGO_TERC_PERSONASRow[] GetByFC_PROVEEDOR_ID(decimal fc_proveedor_id)
		{
			return MapRecords(CreateGetByFC_PROVEEDOR_IDCommand(fc_proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FC_PROV_PAG_TER_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="fc_proveedor_id">The <c>FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_PROVEEDOR_IDAsDataTable(decimal fc_proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByFC_PROVEEDOR_IDCommand(fc_proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FC_PROV_PAG_TER_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="fc_proveedor_id">The <c>FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_PROVEEDOR_IDCommand(decimal fc_proveedor_id)
		{
			string whereSql = "";
			whereSql += "FC_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FC_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FC_PROVEEDOR_ID", fc_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> object to be inserted.</param>
		public virtual void Insert(FC_PROV_PAGO_TERC_PERSONASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FC_PROV_PAGO_TERC_PERSONAS (" +
				"ID, " +
				"FC_PROVEEDOR_ID, " +
				"PERSONA_ID, " +
				"PORC_COMISION, " +
				"PORC_ASIGNADO, " +
				"CONDICION_PAGO_ID, " +
				"PORC_ASIGNADO_CUOTA, " +
				"TOTAL_CUOTAS, " +
				"NRO_CUOTA, " +
				"FECHA_VENCIMIENTO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FC_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PORC_COMISION") + ", " +
				_db.CreateSqlParameterName("PORC_ASIGNADO") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("PORC_ASIGNADO_CUOTA") + ", " +
				_db.CreateSqlParameterName("TOTAL_CUOTAS") + ", " +
				_db.CreateSqlParameterName("NRO_CUOTA") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FC_PROVEEDOR_ID", value.FC_PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "PORC_COMISION",
				value.IsPORC_COMISIONNull ? DBNull.Value : (object)value.PORC_COMISION);
			AddParameter(cmd, "PORC_ASIGNADO",
				value.IsPORC_ASIGNADONull ? DBNull.Value : (object)value.PORC_ASIGNADO);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "PORC_ASIGNADO_CUOTA",
				value.IsPORC_ASIGNADO_CUOTANull ? DBNull.Value : (object)value.PORC_ASIGNADO_CUOTA);
			AddParameter(cmd, "TOTAL_CUOTAS",
				value.IsTOTAL_CUOTASNull ? DBNull.Value : (object)value.TOTAL_CUOTAS);
			AddParameter(cmd, "NRO_CUOTA",
				value.IsNRO_CUOTANull ? DBNull.Value : (object)value.NRO_CUOTA);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FC_PROV_PAGO_TERC_PERSONASRow value)
		{
			
			string sqlStr = "UPDATE TRC.FC_PROV_PAGO_TERC_PERSONAS SET " +
				"FC_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FC_PROVEEDOR_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"PORC_COMISION=" + _db.CreateSqlParameterName("PORC_COMISION") + ", " +
				"PORC_ASIGNADO=" + _db.CreateSqlParameterName("PORC_ASIGNADO") + ", " +
				"CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				"PORC_ASIGNADO_CUOTA=" + _db.CreateSqlParameterName("PORC_ASIGNADO_CUOTA") + ", " +
				"TOTAL_CUOTAS=" + _db.CreateSqlParameterName("TOTAL_CUOTAS") + ", " +
				"NRO_CUOTA=" + _db.CreateSqlParameterName("NRO_CUOTA") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FC_PROVEEDOR_ID", value.FC_PROVEEDOR_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "PORC_COMISION",
				value.IsPORC_COMISIONNull ? DBNull.Value : (object)value.PORC_COMISION);
			AddParameter(cmd, "PORC_ASIGNADO",
				value.IsPORC_ASIGNADONull ? DBNull.Value : (object)value.PORC_ASIGNADO);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "PORC_ASIGNADO_CUOTA",
				value.IsPORC_ASIGNADO_CUOTANull ? DBNull.Value : (object)value.PORC_ASIGNADO_CUOTA);
			AddParameter(cmd, "TOTAL_CUOTAS",
				value.IsTOTAL_CUOTASNull ? DBNull.Value : (object)value.TOTAL_CUOTAS);
			AddParameter(cmd, "NRO_CUOTA",
				value.IsNRO_CUOTANull ? DBNull.Value : (object)value.NRO_CUOTA);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FC_PROV_PAGO_TERC_PERSONASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table using
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
		/// Deletes records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table using the 
		/// <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return DeleteByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table using the 
		/// <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return CreateDeleteByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FC_PROV_PAG_TER_CONDICION</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table using the 
		/// <c>FK_FC_PROV_PAG_TER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FC_PROV_PAG_TER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table using the 
		/// <c>FK_FC_PROV_PAG_TER_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="fc_proveedor_id">The <c>FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_PROVEEDOR_ID(decimal fc_proveedor_id)
		{
			return CreateDeleteByFC_PROVEEDOR_IDCommand(fc_proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FC_PROV_PAG_TER_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="fc_proveedor_id">The <c>FC_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_PROVEEDOR_IDCommand(decimal fc_proveedor_id)
		{
			string whereSql = "";
			whereSql += "FC_PROVEEDOR_ID=" + _db.CreateSqlParameterName("FC_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FC_PROVEEDOR_ID", fc_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FC_PROV_PAGO_TERC_PERSONAS</c> records that match the specified criteria.
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
		/// to delete <c>FC_PROV_PAGO_TERC_PERSONAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FC_PROV_PAGO_TERC_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
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
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		protected FC_PROV_PAGO_TERC_PERSONASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		protected FC_PROV_PAGO_TERC_PERSONASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> objects.</returns>
		protected virtual FC_PROV_PAGO_TERC_PERSONASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fc_proveedor_idColumnIndex = reader.GetOrdinal("FC_PROVEEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int porc_comisionColumnIndex = reader.GetOrdinal("PORC_COMISION");
			int porc_asignadoColumnIndex = reader.GetOrdinal("PORC_ASIGNADO");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int porc_asignado_cuotaColumnIndex = reader.GetOrdinal("PORC_ASIGNADO_CUOTA");
			int total_cuotasColumnIndex = reader.GetOrdinal("TOTAL_CUOTAS");
			int nro_cuotaColumnIndex = reader.GetOrdinal("NRO_CUOTA");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FC_PROV_PAGO_TERC_PERSONASRow record = new FC_PROV_PAGO_TERC_PERSONASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FC_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_proveedor_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(porc_comisionColumnIndex))
						record.PORC_COMISION = Math.Round(Convert.ToDecimal(reader.GetValue(porc_comisionColumnIndex)), 9);
					if(!reader.IsDBNull(porc_asignadoColumnIndex))
						record.PORC_ASIGNADO = Math.Round(Convert.ToDecimal(reader.GetValue(porc_asignadoColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(porc_asignado_cuotaColumnIndex))
						record.PORC_ASIGNADO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(porc_asignado_cuotaColumnIndex)), 9);
					if(!reader.IsDBNull(total_cuotasColumnIndex))
						record.TOTAL_CUOTAS = Math.Round(Convert.ToDecimal(reader.GetValue(total_cuotasColumnIndex)), 9);
					if(!reader.IsDBNull(nro_cuotaColumnIndex))
						record.NRO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(nro_cuotaColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_vencimientoColumnIndex))
						record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FC_PROV_PAGO_TERC_PERSONASRow[])(recordList.ToArray(typeof(FC_PROV_PAGO_TERC_PERSONASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FC_PROV_PAGO_TERC_PERSONASRow"/> object.</returns>
		protected virtual FC_PROV_PAGO_TERC_PERSONASRow MapRow(DataRow row)
		{
			FC_PROV_PAGO_TERC_PERSONASRow mappedObject = new FC_PROV_PAGO_TERC_PERSONASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FC_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["FC_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PORC_COMISION"
			dataColumn = dataTable.Columns["PORC_COMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORC_COMISION = (decimal)row[dataColumn];
			// Column "PORC_ASIGNADO"
			dataColumn = dataTable.Columns["PORC_ASIGNADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORC_ASIGNADO = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "PORC_ASIGNADO_CUOTA"
			dataColumn = dataTable.Columns["PORC_ASIGNADO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORC_ASIGNADO_CUOTA = (decimal)row[dataColumn];
			// Column "TOTAL_CUOTAS"
			dataColumn = dataTable.Columns["TOTAL_CUOTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CUOTAS = (decimal)row[dataColumn];
			// Column "NRO_CUOTA"
			dataColumn = dataTable.Columns["NRO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CUOTA = (decimal)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FC_PROV_PAGO_TERC_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FC_PROV_PAGO_TERC_PERSONAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FC_PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORC_COMISION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORC_ASIGNADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORC_ASIGNADO_CUOTA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_CUOTAS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_CUOTA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
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

				case "FC_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORC_COMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORC_ASIGNADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORC_ASIGNADO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CUOTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FC_PROV_PAGO_TERC_PERSONASCollection_Base class
}  // End of namespace
