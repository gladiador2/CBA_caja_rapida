// <fileinfo name="ANTICIPOS_PERSONACollection_Base.cs">
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
	/// The base class for <see cref="ANTICIPOS_PERSONACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ANTICIPOS_PERSONACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ANTICIPOS_PERSONACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FECHAColumnName = "FECHA";
		public const string FUNCIONARIO_COBRADOR_IDColumnName = "FUNCIONARIO_COBRADOR_ID";
		public const string AUTONUMERACION_RECIBO_IDColumnName = "AUTONUMERACION_RECIBO_ID";
		public const string CTACTE_RECIBO_IDColumnName = "CTACTE_RECIBO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string SALDO_POR_APLICARColumnName = "SALDO_POR_APLICAR";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ANTICIPOS_PERSONACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ANTICIPOS_PERSONACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ANTICIPOS_PERSONA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ANTICIPOS_PERSONA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ANTICIPOS_PERSONA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ANTICIPOS_PERSONARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ANTICIPOS_PERSONARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ANTICIPOS_PERSONARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ANTICIPOS_PERSONARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public ANTICIPOS_PERSONARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects that 
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
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ANTICIPOS_PERSONA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ANTICIPOS_PERSONARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ANTICIPOS_PERSONARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ANTICIPOS_PERSONARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ANTICIPOS_PERSONARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public ANTICIPOS_PERSONARow[] GetByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id)
		{
			return GetByAUTONUMERACION_RECIBO_ID(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_RECIBO_IDAsDataTable(decimal autonumeracion_recibo_id)
		{
			return GetByAUTONUMERACION_RECIBO_IDAsDataTable(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_RECIBO_IDAsDataTable(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_RECIBO_IDCommand(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_recibo_idNull)
				whereSql += "AUTONUMERACION_RECIBO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_recibo_idNull)
				AddParameter(cmd, "AUTONUMERACION_RECIBO_ID", autonumeracion_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetByFUNCIONARIO_COBRADOR_ID(decimal funcionario_cobrador_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_COBRADOR_IDAsDataTable(decimal funcionario_cobrador_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_COBRADOR_IDCommand(decimal funcionario_cobrador_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", funcionario_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_MON</c> foreign key.
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
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_PERS</c> foreign key.
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
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public ANTICIPOS_PERSONARow[] GetByCTACTE_RECIBO_ID(decimal ctacte_recibo_id)
		{
			return GetByCTACTE_RECIBO_ID(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetByCTACTE_RECIBO_ID(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RECIBO_IDAsDataTable(decimal ctacte_recibo_id)
		{
			return GetByCTACTE_RECIBO_IDAsDataTable(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RECIBO_IDAsDataTable(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RECIBO_IDCommand(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_idNull)
				whereSql += "CTACTE_RECIBO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_recibo_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ID", ctacte_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_SUC</c> foreign key.
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
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public ANTICIPOS_PERSONARow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ANTICIPOS_PERSONARow"/> objects 
		/// by the <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		public virtual ANTICIPOS_PERSONARow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ANTICIPOS_PERSONA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ANTICIPOS_PERSONARow"/> object to be inserted.</param>
		public virtual void Insert(ANTICIPOS_PERSONARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ANTICIPOS_PERSONA (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"FECHA, " +
				"FUNCIONARIO_COBRADOR_ID, " +
				"AUTONUMERACION_RECIBO_ID, " +
				"CTACTE_RECIBO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_TOTAL, " +
				"SALDO_POR_APLICAR, " +
				"OBSERVACION, " +
				"TEXTO_PREDEFINIDO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RECIBO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("SALDO_POR_APLICAR") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", value.FUNCIONARIO_COBRADOR_ID);
			AddParameter(cmd, "AUTONUMERACION_RECIBO_ID",
				value.IsAUTONUMERACION_RECIBO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_RECIBO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ID",
				value.IsCTACTE_RECIBO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "SALDO_POR_APLICAR", value.SALDO_POR_APLICAR);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ANTICIPOS_PERSONA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ANTICIPOS_PERSONARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ANTICIPOS_PERSONARow value)
		{
			
			string sqlStr = "UPDATE TRC.ANTICIPOS_PERSONA SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID") + ", " +
				"AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID") + ", " +
				"CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"SALDO_POR_APLICAR=" + _db.CreateSqlParameterName("SALDO_POR_APLICAR") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", value.FUNCIONARIO_COBRADOR_ID);
			AddParameter(cmd, "AUTONUMERACION_RECIBO_ID",
				value.IsAUTONUMERACION_RECIBO_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_RECIBO_ID);
			AddParameter(cmd, "CTACTE_RECIBO_ID",
				value.IsCTACTE_RECIBO_IDNull ? DBNull.Value : (object)value.CTACTE_RECIBO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "SALDO_POR_APLICAR", value.SALDO_POR_APLICAR);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ANTICIPOS_PERSONA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ANTICIPOS_PERSONA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ANTICIPOS_PERSONA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ANTICIPOS_PERSONARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ANTICIPOS_PERSONARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ANTICIPOS_PERSONA</c> table using
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
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id)
		{
			return DeleteByAUTONUMERACION_RECIBO_ID(autonumeracion_recibo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_RECIBO_ID(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			return CreateDeleteByAUTONUMERACION_RECIBO_IDCommand(autonumeracion_recibo_id, autonumeracion_recibo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_recibo_id">The <c>AUTONUMERACION_RECIBO_ID</c> column value.</param>
		/// <param name="autonumeracion_recibo_idNull">true if the method ignores the autonumeracion_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_RECIBO_IDCommand(decimal autonumeracion_recibo_id, bool autonumeracion_recibo_idNull)
		{
			string whereSql = "";
			if(autonumeracion_recibo_idNull)
				whereSql += "AUTONUMERACION_RECIBO_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_RECIBO_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_RECIBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_recibo_idNull)
				AddParameter(cmd, "AUTONUMERACION_RECIBO_ID", autonumeracion_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_COBRADOR_ID(decimal funcionario_cobrador_id)
		{
			return CreateDeleteByFUNCIONARIO_COBRADOR_IDCommand(funcionario_cobrador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_FUNCOB</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cobrador_id">The <c>FUNCIONARIO_COBRADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_COBRADOR_IDCommand(decimal funcionario_cobrador_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_COBRADOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_COBRADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_COBRADOR_ID", funcionario_cobrador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_MON</c> foreign key.
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
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_PERS</c> foreign key.
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
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ID(decimal ctacte_recibo_id)
		{
			return DeleteByCTACTE_RECIBO_ID(ctacte_recibo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECIBO_ID(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			return CreateDeleteByCTACTE_RECIBO_IDCommand(ctacte_recibo_id, ctacte_recibo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_RECIBO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recibo_id">The <c>CTACTE_RECIBO_ID</c> column value.</param>
		/// <param name="ctacte_recibo_idNull">true if the method ignores the ctacte_recibo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RECIBO_IDCommand(decimal ctacte_recibo_id, bool ctacte_recibo_idNull)
		{
			string whereSql = "";
			if(ctacte_recibo_idNull)
				whereSql += "CTACTE_RECIBO_ID IS NULL";
			else
				whereSql += "CTACTE_RECIBO_ID=" + _db.CreateSqlParameterName("CTACTE_RECIBO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_recibo_idNull)
				AddParameter(cmd, "CTACTE_RECIBO_ID", ctacte_recibo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_SUC</c> foreign key.
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
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ANTICIPOS_PERSONA</c> table using the 
		/// <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ANTICIPOS_PERSONA_TEXT_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ANTICIPOS_PERSONA</c> records that match the specified criteria.
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
		/// to delete <c>ANTICIPOS_PERSONA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ANTICIPOS_PERSONA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ANTICIPOS_PERSONA</c> table.
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
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		protected ANTICIPOS_PERSONARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		protected ANTICIPOS_PERSONARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ANTICIPOS_PERSONARow"/> objects.</returns>
		protected virtual ANTICIPOS_PERSONARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int funcionario_cobrador_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_ID");
			int autonumeracion_recibo_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_RECIBO_ID");
			int ctacte_recibo_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int saldo_por_aplicarColumnIndex = reader.GetOrdinal("SALDO_POR_APLICAR");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ANTICIPOS_PERSONARow record = new ANTICIPOS_PERSONARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.FUNCIONARIO_COBRADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cobrador_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_recibo_idColumnIndex))
						record.AUTONUMERACION_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_idColumnIndex))
						record.CTACTE_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					record.SALDO_POR_APLICAR = Math.Round(Convert.ToDecimal(reader.GetValue(saldo_por_aplicarColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ANTICIPOS_PERSONARow[])(recordList.ToArray(typeof(ANTICIPOS_PERSONARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ANTICIPOS_PERSONARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ANTICIPOS_PERSONARow"/> object.</returns>
		protected virtual ANTICIPOS_PERSONARow MapRow(DataRow row)
		{
			ANTICIPOS_PERSONARow mappedObject = new ANTICIPOS_PERSONARow();
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
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_RECIBO_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_RECIBO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "SALDO_POR_APLICAR"
			dataColumn = dataTable.Columns["SALDO_POR_APLICAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALDO_POR_APLICAR = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ANTICIPOS_PERSONA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ANTICIPOS_PERSONA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_RECIBO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SALDO_POR_APLICAR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_COBRADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALDO_POR_APLICAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ANTICIPOS_PERSONACollection_Base class
}  // End of namespace
