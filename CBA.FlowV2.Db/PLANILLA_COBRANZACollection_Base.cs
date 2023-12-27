// <fileinfo name="PLANILLA_COBRANZACollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_COBRANZACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_COBRANZACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_COBRANZACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FUNCIONARIO_CAJERO_IDColumnName = "FUNCIONARIO_CAJERO_ID";
		public const string GENERAR_PAGOColumnName = "GENERAR_PAGO";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string FC_AUTONUMERACION_IDColumnName = "FC_AUTONUMERACION_ID";
		public const string INCLUIR_MORAColumnName = "INCLUIR_MORA";
		public const string MONTO_COMISIONColumnName = "MONTO_COMISION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBRANZACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_COBRANZACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_COBRANZA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_COBRANZA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_COBRANZA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_COBRANZARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_COBRANZARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_COBRANZARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_COBRANZARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public PLANILLA_COBRANZARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_COBRANZA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANILLA_COBRANZARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANILLA_COBRANZARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANILLA_COBRANZARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANILLA_COBRANZARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public PLANILLA_COBRANZARow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public PLANILLA_COBRANZARow[] GetByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id)
		{
			return GetByFC_AUTONUMERACION_ID(fc_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByFC_AUTONUMERACION_IDCommand(fc_autonumeracion_id, fc_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFC_AUTONUMERACION_IDAsDataTable(decimal fc_autonumeracion_id)
		{
			return GetByFC_AUTONUMERACION_IDAsDataTable(fc_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFC_AUTONUMERACION_IDAsDataTable(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFC_AUTONUMERACION_IDCommand(fc_autonumeracion_id, fc_autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFC_AUTONUMERACION_IDCommand(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			string whereSql = "";
			if(fc_autonumeracion_idNull)
				whereSql += "FC_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "FC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("FC_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!fc_autonumeracion_idNull)
				AddParameter(cmd, "FC_AUTONUMERACION_ID", fc_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public PLANILLA_COBRANZARow[] GetByFUNCIONARIO_CAJERO_ID(decimal funcionario_cajero_id)
		{
			return GetByFUNCIONARIO_CAJERO_ID(funcionario_cajero_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <param name="funcionario_cajero_idNull">true if the method ignores the funcionario_cajero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByFUNCIONARIO_CAJERO_ID(decimal funcionario_cajero_id, bool funcionario_cajero_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_CAJERO_IDCommand(funcionario_cajero_id, funcionario_cajero_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_CAJERO_IDAsDataTable(decimal funcionario_cajero_id)
		{
			return GetByFUNCIONARIO_CAJERO_IDAsDataTable(funcionario_cajero_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <param name="funcionario_cajero_idNull">true if the method ignores the funcionario_cajero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_CAJERO_IDAsDataTable(decimal funcionario_cajero_id, bool funcionario_cajero_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_CAJERO_IDCommand(funcionario_cajero_id, funcionario_cajero_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <param name="funcionario_cajero_idNull">true if the method ignores the funcionario_cajero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_CAJERO_IDCommand(decimal funcionario_cajero_id, bool funcionario_cajero_idNull)
		{
			string whereSql = "";
			if(funcionario_cajero_idNull)
				whereSql += "FUNCIONARIO_CAJERO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CAJERO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CAJERO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_cajero_idNull)
				AddParameter(cmd, "FUNCIONARIO_CAJERO_ID", funcionario_cajero_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBR_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public PLANILLA_COBRANZARow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBRANZA_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBRANZA_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBRANZA_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBRANZA_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBRANZA_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBRANZA_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBRANZA_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBRANZA_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBRANZA_FUNC_ID</c> foreign key.
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
		/// Gets an array of <see cref="PLANILLA_COBRANZARow"/> objects 
		/// by the <c>FK_PLANILLA_COBRANZA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		public virtual PLANILLA_COBRANZARow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANILLA_COBRANZA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANILLA_COBRANZA_SUC_ID</c> foreign key.
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
		/// Adds a new record into the <c>PLANILLA_COBRANZA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_COBRANZARow"/> object to be inserted.</param>
		public virtual void Insert(PLANILLA_COBRANZARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANILLA_COBRANZA (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"FUNCIONARIO_ID, " +
				"FECHA_INICIO, " +
				"FECHA_FIN, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FUNCIONARIO_CAJERO_ID, " +
				"GENERAR_PAGO, " +
				"PERSONA_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"FC_AUTONUMERACION_ID, " +
				"INCLUIR_MORA, " +
				"MONTO_COMISION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_CAJERO_ID") + ", " +
				_db.CreateSqlParameterName("GENERAR_PAGO") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FC_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("INCLUIR_MORA") + ", " +
				_db.CreateSqlParameterName("MONTO_COMISION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN", value.FECHA_FIN);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FUNCIONARIO_CAJERO_ID",
				value.IsFUNCIONARIO_CAJERO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CAJERO_ID);
			AddParameter(cmd, "GENERAR_PAGO", value.GENERAR_PAGO);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "FC_AUTONUMERACION_ID",
				value.IsFC_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.FC_AUTONUMERACION_ID);
			AddParameter(cmd, "INCLUIR_MORA", value.INCLUIR_MORA);
			AddParameter(cmd, "MONTO_COMISION", value.MONTO_COMISION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANILLA_COBRANZA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_COBRANZARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANILLA_COBRANZARow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANILLA_COBRANZA SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FUNCIONARIO_CAJERO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CAJERO_ID") + ", " +
				"GENERAR_PAGO=" + _db.CreateSqlParameterName("GENERAR_PAGO") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"FC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("FC_AUTONUMERACION_ID") + ", " +
				"INCLUIR_MORA=" + _db.CreateSqlParameterName("INCLUIR_MORA") + ", " +
				"MONTO_COMISION=" + _db.CreateSqlParameterName("MONTO_COMISION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN", value.FECHA_FIN);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FUNCIONARIO_CAJERO_ID",
				value.IsFUNCIONARIO_CAJERO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_CAJERO_ID);
			AddParameter(cmd, "GENERAR_PAGO", value.GENERAR_PAGO);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "FC_AUTONUMERACION_ID",
				value.IsFC_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.FC_AUTONUMERACION_ID);
			AddParameter(cmd, "INCLUIR_MORA", value.INCLUIR_MORA);
			AddParameter(cmd, "MONTO_COMISION", value.MONTO_COMISION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANILLA_COBRANZA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANILLA_COBRANZA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANILLA_COBRANZA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANILLA_COBRANZARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANILLA_COBRANZARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANILLA_COBRANZA</c> table using
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
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBR_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id)
		{
			return DeleteByFC_AUTONUMERACION_ID(fc_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFC_AUTONUMERACION_ID(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			return CreateDeleteByFC_AUTONUMERACION_IDCommand(fc_autonumeracion_id, fc_autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBR_FC_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="fc_autonumeracion_id">The <c>FC_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="fc_autonumeracion_idNull">true if the method ignores the fc_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFC_AUTONUMERACION_IDCommand(decimal fc_autonumeracion_id, bool fc_autonumeracion_idNull)
		{
			string whereSql = "";
			if(fc_autonumeracion_idNull)
				whereSql += "FC_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "FC_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("FC_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!fc_autonumeracion_idNull)
				AddParameter(cmd, "FC_AUTONUMERACION_ID", fc_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CAJERO_ID(decimal funcionario_cajero_id)
		{
			return DeleteByFUNCIONARIO_CAJERO_ID(funcionario_cajero_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <param name="funcionario_cajero_idNull">true if the method ignores the funcionario_cajero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_CAJERO_ID(decimal funcionario_cajero_id, bool funcionario_cajero_idNull)
		{
			return CreateDeleteByFUNCIONARIO_CAJERO_IDCommand(funcionario_cajero_id, funcionario_cajero_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBR_FUNC_CAJ_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_cajero_id">The <c>FUNCIONARIO_CAJERO_ID</c> column value.</param>
		/// <param name="funcionario_cajero_idNull">true if the method ignores the funcionario_cajero_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_CAJERO_IDCommand(decimal funcionario_cajero_id, bool funcionario_cajero_idNull)
		{
			string whereSql = "";
			if(funcionario_cajero_idNull)
				whereSql += "FUNCIONARIO_CAJERO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_CAJERO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_CAJERO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_cajero_idNull)
				AddParameter(cmd, "FUNCIONARIO_CAJERO_ID", funcionario_cajero_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBR_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBR_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBRANZA_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBRANZA_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBRANZA_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBRANZA_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBRANZA_FUNC_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBRANZA_FUNC_ID</c> foreign key.
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
		/// Deletes records from the <c>PLANILLA_COBRANZA</c> table using the 
		/// <c>FK_PLANILLA_COBRANZA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANILLA_COBRANZA_SUC_ID</c> foreign key.
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
		/// Deletes <c>PLANILLA_COBRANZA</c> records that match the specified criteria.
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
		/// to delete <c>PLANILLA_COBRANZA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANILLA_COBRANZA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANILLA_COBRANZA</c> table.
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		protected PLANILLA_COBRANZARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		protected PLANILLA_COBRANZARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_COBRANZARow"/> objects.</returns>
		protected virtual PLANILLA_COBRANZARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int funcionario_cajero_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_CAJERO_ID");
			int generar_pagoColumnIndex = reader.GetOrdinal("GENERAR_PAGO");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int fc_autonumeracion_idColumnIndex = reader.GetOrdinal("FC_AUTONUMERACION_ID");
			int incluir_moraColumnIndex = reader.GetOrdinal("INCLUIR_MORA");
			int monto_comisionColumnIndex = reader.GetOrdinal("MONTO_COMISION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_COBRANZARow record = new PLANILLA_COBRANZARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(funcionario_cajero_idColumnIndex))
						record.FUNCIONARIO_CAJERO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cajero_idColumnIndex)), 9);
					if(!reader.IsDBNull(generar_pagoColumnIndex))
						record.GENERAR_PAGO = Convert.ToString(reader.GetValue(generar_pagoColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_autonumeracion_idColumnIndex))
						record.FC_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(incluir_moraColumnIndex))
						record.INCLUIR_MORA = Convert.ToString(reader.GetValue(incluir_moraColumnIndex));
					record.MONTO_COMISION = Math.Round(Convert.ToDecimal(reader.GetValue(monto_comisionColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_COBRANZARow[])(recordList.ToArray(typeof(PLANILLA_COBRANZARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_COBRANZARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_COBRANZARow"/> object.</returns>
		protected virtual PLANILLA_COBRANZARow MapRow(DataRow row)
		{
			PLANILLA_COBRANZARow mappedObject = new PLANILLA_COBRANZARow();
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
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FUNCIONARIO_CAJERO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_CAJERO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CAJERO_ID = (decimal)row[dataColumn];
			// Column "GENERAR_PAGO"
			dataColumn = dataTable.Columns["GENERAR_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_PAGO = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FC_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["FC_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "INCLUIR_MORA"
			dataColumn = dataTable.Columns["INCLUIR_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUIR_MORA = (string)row[dataColumn];
			// Column "MONTO_COMISION"
			dataColumn = dataTable.Columns["MONTO_COMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COMISION = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_COBRANZA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_COBRANZA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CAJERO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GENERAR_PAGO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INCLUIR_MORA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("MONTO_COMISION", typeof(decimal));
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_CAJERO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GENERAR_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INCLUIR_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_COMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_COBRANZACollection_Base class
}  // End of namespace
