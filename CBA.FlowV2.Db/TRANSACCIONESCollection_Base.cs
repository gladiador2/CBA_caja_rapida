// <fileinfo name="TRANSACCIONESCollection_Base.cs">
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
	/// The base class for <see cref="TRANSACCIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSACCIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSACCIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ID_EXTERNOColumnName = "ID_EXTERNO";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string CTACTE_RED_PAGO_IDColumnName = "CTACTE_RED_PAGO_ID";
		public const string NRO_TRANSACCIONColumnName = "NRO_TRANSACCION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FECHA_TRANSACCIONColumnName = "FECHA_TRANSACCION";
		public const string FECHA_ACREDITACIONColumnName = "FECHA_ACREDITACION";
		public const string FECHA_ANULACIONColumnName = "FECHA_ANULACION";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_PERSONA_IDColumnName = "CTACTE_PERSONA_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string MONTO_CAPITALColumnName = "MONTO_CAPITAL";
		public const string MONTO_INTERESESColumnName = "MONTO_INTERESES";
		public const string MONTO_GASTO_ADMINISTRATIVOColumnName = "MONTO_GASTO_ADMINISTRATIVO";
		public const string COMISION_TOTALColumnName = "COMISION_TOTAL";
		public const string COMISION_RECAUDADORColumnName = "COMISION_RECAUDADOR";
		public const string COMISION_PROCESADORColumnName = "COMISION_PROCESADOR";
		public const string COMISION_CLEARINGColumnName = "COMISION_CLEARING";
		public const string COMISION_OTROColumnName = "COMISION_OTRO";
		public const string PROCESADOColumnName = "PROCESADO";
		public const string ANULADOColumnName = "ANULADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string JSONColumnName = "JSON";
		public const string TRANSACCION_CIERRE_IDColumnName = "TRANSACCION_CIERRE_ID";
		public const string COMISION_REDColumnName = "COMISION_RED";
		public const string FECHA_CORTEColumnName = "FECHA_CORTE";
		public const string CTACTE_BANCO_CLEARING_IDColumnName = "CTACTE_BANCO_CLEARING_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSACCIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSACCIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSACCIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSACCIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSACCIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSACCIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSACCIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSACCIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSACCIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSACCIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRANSACCIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRANSACCIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRANSACCIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TRANSACCIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetByCTACTE_BANCO_CLEARING_ID(decimal ctacte_banco_clearing_id)
		{
			return GetByCTACTE_BANCO_CLEARING_ID(ctacte_banco_clearing_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <param name="ctacte_banco_clearing_idNull">true if the method ignores the ctacte_banco_clearing_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByCTACTE_BANCO_CLEARING_ID(decimal ctacte_banco_clearing_id, bool ctacte_banco_clearing_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANCO_CLEARING_IDCommand(ctacte_banco_clearing_id, ctacte_banco_clearing_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANCO_CLEARING_IDAsDataTable(decimal ctacte_banco_clearing_id)
		{
			return GetByCTACTE_BANCO_CLEARING_IDAsDataTable(ctacte_banco_clearing_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <param name="ctacte_banco_clearing_idNull">true if the method ignores the ctacte_banco_clearing_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCO_CLEARING_IDAsDataTable(decimal ctacte_banco_clearing_id, bool ctacte_banco_clearing_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCO_CLEARING_IDCommand(ctacte_banco_clearing_id, ctacte_banco_clearing_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <param name="ctacte_banco_clearing_idNull">true if the method ignores the ctacte_banco_clearing_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCO_CLEARING_IDCommand(decimal ctacte_banco_clearing_id, bool ctacte_banco_clearing_idNull)
		{
			string whereSql = "";
			if(ctacte_banco_clearing_idNull)
				whereSql += "CTACTE_BANCO_CLEARING_ID IS NULL";
			else
				whereSql += "CTACTE_BANCO_CLEARING_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_CLEARING_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_banco_clearing_idNull)
				AddParameter(cmd, "CTACTE_BANCO_CLEARING_ID", ctacte_banco_clearing_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_IDAsDataTable(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSACCIONES_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
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
		/// return records by the <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
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
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RED_PAGO_IDAsDataTable(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_IDAsDataTable(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RED_PAGO_IDAsDataTable(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RED_PAGO_IDCommand(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			string whereSql = "";
			if(ctacte_red_pago_idNull)
				whereSql += "CTACTE_RED_PAGO_ID IS NULL";
			else
				whereSql += "CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_red_pago_idNull)
				AddParameter(cmd, "CTACTE_RED_PAGO_ID", ctacte_red_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
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
		/// return records by the <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
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
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetByTRANSACCION_CIERRE_ID(decimal transaccion_cierre_id)
		{
			return GetByTRANSACCION_CIERRE_ID(transaccion_cierre_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <param name="transaccion_cierre_idNull">true if the method ignores the transaccion_cierre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByTRANSACCION_CIERRE_ID(decimal transaccion_cierre_id, bool transaccion_cierre_idNull)
		{
			return MapRecords(CreateGetByTRANSACCION_CIERRE_IDCommand(transaccion_cierre_id, transaccion_cierre_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSACCION_CIERRE_IDAsDataTable(decimal transaccion_cierre_id)
		{
			return GetByTRANSACCION_CIERRE_IDAsDataTable(transaccion_cierre_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <param name="transaccion_cierre_idNull">true if the method ignores the transaccion_cierre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSACCION_CIERRE_IDAsDataTable(decimal transaccion_cierre_id, bool transaccion_cierre_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSACCION_CIERRE_IDCommand(transaccion_cierre_id, transaccion_cierre_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <param name="transaccion_cierre_idNull">true if the method ignores the transaccion_cierre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSACCION_CIERRE_IDCommand(decimal transaccion_cierre_id, bool transaccion_cierre_idNull)
		{
			string whereSql = "";
			if(transaccion_cierre_idNull)
				whereSql += "TRANSACCION_CIERRE_ID IS NULL";
			else
				whereSql += "TRANSACCION_CIERRE_ID=" + _db.CreateSqlParameterName("TRANSACCION_CIERRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transaccion_cierre_idNull)
				AddParameter(cmd, "TRANSACCION_CIERRE_ID", transaccion_cierre_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSACCIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public TRANSACCIONESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSACCIONESRow"/> objects 
		/// by the <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		public virtual TRANSACCIONESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_IDAsDataTable(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			string whereSql = "";
			if(ctacte_valor_idNull)
				whereSql += "CTACTE_VALOR_ID IS NULL";
			else
				whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_valor_idNull)
				AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TRANSACCIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSACCIONESRow"/> object to be inserted.</param>
		public virtual void Insert(TRANSACCIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRANSACCIONES (" +
				"ID, " +
				"ID_EXTERNO, " +
				"SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"PROVEEDOR_ID, " +
				"CTACTE_RED_PAGO_ID, " +
				"NRO_TRANSACCION, " +
				"NRO_COMPROBANTE, " +
				"FECHA_CREACION, " +
				"USUARIO_ID, " +
				"FECHA_TRANSACCION, " +
				"FECHA_ACREDITACION, " +
				"FECHA_ANULACION, " +
				"CTACTE_VALOR_ID, " +
				"CTACTE_PERSONA_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"MONTO_TOTAL, " +
				"MONTO_CAPITAL, " +
				"MONTO_INTERESES, " +
				"MONTO_GASTO_ADMINISTRATIVO, " +
				"COMISION_TOTAL, " +
				"COMISION_RECAUDADOR, " +
				"COMISION_PROCESADOR, " +
				"COMISION_CLEARING, " +
				"COMISION_OTRO, " +
				"PROCESADO, " +
				"ANULADO, " +
				"ESTADO, " +
				"JSON, " +
				"TRANSACCION_CIERRE_ID, " +
				"COMISION_RED, " +
				"FECHA_CORTE, " +
				"CTACTE_BANCO_CLEARING_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ID_EXTERNO") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("NRO_TRANSACCION") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_TRANSACCION") + ", " +
				_db.CreateSqlParameterName("FECHA_ACREDITACION") + ", " +
				_db.CreateSqlParameterName("FECHA_ANULACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERESES") + ", " +
				_db.CreateSqlParameterName("MONTO_GASTO_ADMINISTRATIVO") + ", " +
				_db.CreateSqlParameterName("COMISION_TOTAL") + ", " +
				_db.CreateSqlParameterName("COMISION_RECAUDADOR") + ", " +
				_db.CreateSqlParameterName("COMISION_PROCESADOR") + ", " +
				_db.CreateSqlParameterName("COMISION_CLEARING") + ", " +
				_db.CreateSqlParameterName("COMISION_OTRO") + ", " +
				_db.CreateSqlParameterName("PROCESADO") + ", " +
				_db.CreateSqlParameterName("ANULADO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("JSON") + ", " +
				_db.CreateSqlParameterName("TRANSACCION_CIERRE_ID") + ", " +
				_db.CreateSqlParameterName("COMISION_RED") + ", " +
				_db.CreateSqlParameterName("FECHA_CORTE") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCO_CLEARING_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ID_EXTERNO", value.ID_EXTERNO);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "NRO_TRANSACCION", value.NRO_TRANSACCION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA_TRANSACCION",
				value.IsFECHA_TRANSACCIONNull ? DBNull.Value : (object)value.FECHA_TRANSACCION);
			AddParameter(cmd, "FECHA_ACREDITACION",
				value.IsFECHA_ACREDITACIONNull ? DBNull.Value : (object)value.FECHA_ACREDITACION);
			AddParameter(cmd, "FECHA_ANULACION",
				value.IsFECHA_ANULACIONNull ? DBNull.Value : (object)value.FECHA_ANULACION);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "MONTO_TOTAL",
				value.IsMONTO_TOTALNull ? DBNull.Value : (object)value.MONTO_TOTAL);
			AddParameter(cmd, "MONTO_CAPITAL",
				value.IsMONTO_CAPITALNull ? DBNull.Value : (object)value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERESES",
				value.IsMONTO_INTERESESNull ? DBNull.Value : (object)value.MONTO_INTERESES);
			AddParameter(cmd, "MONTO_GASTO_ADMINISTRATIVO",
				value.IsMONTO_GASTO_ADMINISTRATIVONull ? DBNull.Value : (object)value.MONTO_GASTO_ADMINISTRATIVO);
			AddParameter(cmd, "COMISION_TOTAL",
				value.IsCOMISION_TOTALNull ? DBNull.Value : (object)value.COMISION_TOTAL);
			AddParameter(cmd, "COMISION_RECAUDADOR",
				value.IsCOMISION_RECAUDADORNull ? DBNull.Value : (object)value.COMISION_RECAUDADOR);
			AddParameter(cmd, "COMISION_PROCESADOR",
				value.IsCOMISION_PROCESADORNull ? DBNull.Value : (object)value.COMISION_PROCESADOR);
			AddParameter(cmd, "COMISION_CLEARING",
				value.IsCOMISION_CLEARINGNull ? DBNull.Value : (object)value.COMISION_CLEARING);
			AddParameter(cmd, "COMISION_OTRO",
				value.IsCOMISION_OTRONull ? DBNull.Value : (object)value.COMISION_OTRO);
			AddParameter(cmd, "PROCESADO", value.PROCESADO);
			AddParameter(cmd, "ANULADO", value.ANULADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "JSON", value.JSON);
			AddParameter(cmd, "TRANSACCION_CIERRE_ID",
				value.IsTRANSACCION_CIERRE_IDNull ? DBNull.Value : (object)value.TRANSACCION_CIERRE_ID);
			AddParameter(cmd, "COMISION_RED",
				value.IsCOMISION_REDNull ? DBNull.Value : (object)value.COMISION_RED);
			AddParameter(cmd, "FECHA_CORTE",
				value.IsFECHA_CORTENull ? DBNull.Value : (object)value.FECHA_CORTE);
			AddParameter(cmd, "CTACTE_BANCO_CLEARING_ID",
				value.IsCTACTE_BANCO_CLEARING_IDNull ? DBNull.Value : (object)value.CTACTE_BANCO_CLEARING_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRANSACCIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSACCIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRANSACCIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRANSACCIONES SET " +
				"ID_EXTERNO=" + _db.CreateSqlParameterName("ID_EXTERNO") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				"NRO_TRANSACCION=" + _db.CreateSqlParameterName("NRO_TRANSACCION") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"FECHA_TRANSACCION=" + _db.CreateSqlParameterName("FECHA_TRANSACCION") + ", " +
				"FECHA_ACREDITACION=" + _db.CreateSqlParameterName("FECHA_ACREDITACION") + ", " +
				"FECHA_ANULACION=" + _db.CreateSqlParameterName("FECHA_ANULACION") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"MONTO_CAPITAL=" + _db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				"MONTO_INTERESES=" + _db.CreateSqlParameterName("MONTO_INTERESES") + ", " +
				"MONTO_GASTO_ADMINISTRATIVO=" + _db.CreateSqlParameterName("MONTO_GASTO_ADMINISTRATIVO") + ", " +
				"COMISION_TOTAL=" + _db.CreateSqlParameterName("COMISION_TOTAL") + ", " +
				"COMISION_RECAUDADOR=" + _db.CreateSqlParameterName("COMISION_RECAUDADOR") + ", " +
				"COMISION_PROCESADOR=" + _db.CreateSqlParameterName("COMISION_PROCESADOR") + ", " +
				"COMISION_CLEARING=" + _db.CreateSqlParameterName("COMISION_CLEARING") + ", " +
				"COMISION_OTRO=" + _db.CreateSqlParameterName("COMISION_OTRO") + ", " +
				"PROCESADO=" + _db.CreateSqlParameterName("PROCESADO") + ", " +
				"ANULADO=" + _db.CreateSqlParameterName("ANULADO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"JSON=" + _db.CreateSqlParameterName("JSON") + ", " +
				"TRANSACCION_CIERRE_ID=" + _db.CreateSqlParameterName("TRANSACCION_CIERRE_ID") + ", " +
				"COMISION_RED=" + _db.CreateSqlParameterName("COMISION_RED") + ", " +
				"FECHA_CORTE=" + _db.CreateSqlParameterName("FECHA_CORTE") + ", " +
				"CTACTE_BANCO_CLEARING_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_CLEARING_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID_EXTERNO", value.ID_EXTERNO);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "NRO_TRANSACCION", value.NRO_TRANSACCION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "FECHA_TRANSACCION",
				value.IsFECHA_TRANSACCIONNull ? DBNull.Value : (object)value.FECHA_TRANSACCION);
			AddParameter(cmd, "FECHA_ACREDITACION",
				value.IsFECHA_ACREDITACIONNull ? DBNull.Value : (object)value.FECHA_ACREDITACION);
			AddParameter(cmd, "FECHA_ANULACION",
				value.IsFECHA_ANULACIONNull ? DBNull.Value : (object)value.FECHA_ANULACION);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION",
				value.IsCOTIZACIONNull ? DBNull.Value : (object)value.COTIZACION);
			AddParameter(cmd, "MONTO_TOTAL",
				value.IsMONTO_TOTALNull ? DBNull.Value : (object)value.MONTO_TOTAL);
			AddParameter(cmd, "MONTO_CAPITAL",
				value.IsMONTO_CAPITALNull ? DBNull.Value : (object)value.MONTO_CAPITAL);
			AddParameter(cmd, "MONTO_INTERESES",
				value.IsMONTO_INTERESESNull ? DBNull.Value : (object)value.MONTO_INTERESES);
			AddParameter(cmd, "MONTO_GASTO_ADMINISTRATIVO",
				value.IsMONTO_GASTO_ADMINISTRATIVONull ? DBNull.Value : (object)value.MONTO_GASTO_ADMINISTRATIVO);
			AddParameter(cmd, "COMISION_TOTAL",
				value.IsCOMISION_TOTALNull ? DBNull.Value : (object)value.COMISION_TOTAL);
			AddParameter(cmd, "COMISION_RECAUDADOR",
				value.IsCOMISION_RECAUDADORNull ? DBNull.Value : (object)value.COMISION_RECAUDADOR);
			AddParameter(cmd, "COMISION_PROCESADOR",
				value.IsCOMISION_PROCESADORNull ? DBNull.Value : (object)value.COMISION_PROCESADOR);
			AddParameter(cmd, "COMISION_CLEARING",
				value.IsCOMISION_CLEARINGNull ? DBNull.Value : (object)value.COMISION_CLEARING);
			AddParameter(cmd, "COMISION_OTRO",
				value.IsCOMISION_OTRONull ? DBNull.Value : (object)value.COMISION_OTRO);
			AddParameter(cmd, "PROCESADO", value.PROCESADO);
			AddParameter(cmd, "ANULADO", value.ANULADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "JSON", value.JSON);
			AddParameter(cmd, "TRANSACCION_CIERRE_ID",
				value.IsTRANSACCION_CIERRE_IDNull ? DBNull.Value : (object)value.TRANSACCION_CIERRE_ID);
			AddParameter(cmd, "COMISION_RED",
				value.IsCOMISION_REDNull ? DBNull.Value : (object)value.COMISION_RED);
			AddParameter(cmd, "FECHA_CORTE",
				value.IsFECHA_CORTENull ? DBNull.Value : (object)value.FECHA_CORTE);
			AddParameter(cmd, "CTACTE_BANCO_CLEARING_ID",
				value.IsCTACTE_BANCO_CLEARING_IDNull ? DBNull.Value : (object)value.CTACTE_BANCO_CLEARING_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRANSACCIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRANSACCIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TRANSACCIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSACCIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRANSACCIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRANSACCIONES</c> table using
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
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_CLEARING_ID(decimal ctacte_banco_clearing_id)
		{
			return DeleteByCTACTE_BANCO_CLEARING_ID(ctacte_banco_clearing_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <param name="ctacte_banco_clearing_idNull">true if the method ignores the ctacte_banco_clearing_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_CLEARING_ID(decimal ctacte_banco_clearing_id, bool ctacte_banco_clearing_idNull)
		{
			return CreateDeleteByCTACTE_BANCO_CLEARING_IDCommand(ctacte_banco_clearing_id, ctacte_banco_clearing_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSACCIONES_BANCO_CLEAR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_clearing_id">The <c>CTACTE_BANCO_CLEARING_ID</c> column value.</param>
		/// <param name="ctacte_banco_clearing_idNull">true if the method ignores the ctacte_banco_clearing_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCO_CLEARING_IDCommand(decimal ctacte_banco_clearing_id, bool ctacte_banco_clearing_idNull)
		{
			string whereSql = "";
			if(ctacte_banco_clearing_idNull)
				whereSql += "CTACTE_BANCO_CLEARING_ID IS NULL";
			else
				whereSql += "CTACTE_BANCO_CLEARING_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_CLEARING_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_banco_clearing_idNull)
				AddParameter(cmd, "CTACTE_BANCO_CLEARING_ID", ctacte_banco_clearing_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return DeleteByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return CreateDeleteByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSACCIONES_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSACCIONES_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_TRANSACCIONES_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
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
		/// delete records using the <c>FK_TRANSACCIONES_PROVEEDOR</c> foreign key.
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
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return DeleteByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return CreateDeleteByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSACCIONES_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RED_PAGO_IDCommand(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			string whereSql = "";
			if(ctacte_red_pago_idNull)
				whereSql += "CTACTE_RED_PAGO_ID IS NULL";
			else
				whereSql += "CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_red_pago_idNull)
				AddParameter(cmd, "CTACTE_RED_PAGO_ID", ctacte_red_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
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
		/// delete records using the <c>FK_TRANSACCIONES_SUCURSAL</c> foreign key.
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
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSACCION_CIERRE_ID(decimal transaccion_cierre_id)
		{
			return DeleteByTRANSACCION_CIERRE_ID(transaccion_cierre_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <param name="transaccion_cierre_idNull">true if the method ignores the transaccion_cierre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSACCION_CIERRE_ID(decimal transaccion_cierre_id, bool transaccion_cierre_idNull)
		{
			return CreateDeleteByTRANSACCION_CIERRE_IDCommand(transaccion_cierre_id, transaccion_cierre_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSACCIONES_TRANS_CIERRE</c> foreign key.
		/// </summary>
		/// <param name="transaccion_cierre_id">The <c>TRANSACCION_CIERRE_ID</c> column value.</param>
		/// <param name="transaccion_cierre_idNull">true if the method ignores the transaccion_cierre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSACCION_CIERRE_IDCommand(decimal transaccion_cierre_id, bool transaccion_cierre_idNull)
		{
			string whereSql = "";
			if(transaccion_cierre_idNull)
				whereSql += "TRANSACCION_CIERRE_ID IS NULL";
			else
				whereSql += "TRANSACCION_CIERRE_ID=" + _db.CreateSqlParameterName("TRANSACCION_CIERRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transaccion_cierre_idNull)
				AddParameter(cmd, "TRANSACCION_CIERRE_ID", transaccion_cierre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSACCIONES_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return DeleteByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSACCIONES</c> table using the 
		/// <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANSACCIONES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			string whereSql = "";
			if(ctacte_valor_idNull)
				whereSql += "CTACTE_VALOR_ID IS NULL";
			else
				whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_valor_idNull)
				AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TRANSACCIONES</c> records that match the specified criteria.
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
		/// to delete <c>TRANSACCIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRANSACCIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRANSACCIONES</c> table.
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
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		protected TRANSACCIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		protected TRANSACCIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSACCIONESRow"/> objects.</returns>
		protected virtual TRANSACCIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int id_externoColumnIndex = reader.GetOrdinal("ID_EXTERNO");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int ctacte_red_pago_idColumnIndex = reader.GetOrdinal("CTACTE_RED_PAGO_ID");
			int nro_transaccionColumnIndex = reader.GetOrdinal("NRO_TRANSACCION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int fecha_transaccionColumnIndex = reader.GetOrdinal("FECHA_TRANSACCION");
			int fecha_acreditacionColumnIndex = reader.GetOrdinal("FECHA_ACREDITACION");
			int fecha_anulacionColumnIndex = reader.GetOrdinal("FECHA_ANULACION");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int monto_capitalColumnIndex = reader.GetOrdinal("MONTO_CAPITAL");
			int monto_interesesColumnIndex = reader.GetOrdinal("MONTO_INTERESES");
			int monto_gasto_administrativoColumnIndex = reader.GetOrdinal("MONTO_GASTO_ADMINISTRATIVO");
			int comision_totalColumnIndex = reader.GetOrdinal("COMISION_TOTAL");
			int comision_recaudadorColumnIndex = reader.GetOrdinal("COMISION_RECAUDADOR");
			int comision_procesadorColumnIndex = reader.GetOrdinal("COMISION_PROCESADOR");
			int comision_clearingColumnIndex = reader.GetOrdinal("COMISION_CLEARING");
			int comision_otroColumnIndex = reader.GetOrdinal("COMISION_OTRO");
			int procesadoColumnIndex = reader.GetOrdinal("PROCESADO");
			int anuladoColumnIndex = reader.GetOrdinal("ANULADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int jsonColumnIndex = reader.GetOrdinal("JSON");
			int transaccion_cierre_idColumnIndex = reader.GetOrdinal("TRANSACCION_CIERRE_ID");
			int comision_redColumnIndex = reader.GetOrdinal("COMISION_RED");
			int fecha_corteColumnIndex = reader.GetOrdinal("FECHA_CORTE");
			int ctacte_banco_clearing_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_CLEARING_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSACCIONESRow record = new TRANSACCIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ID_EXTERNO = Math.Round(Convert.ToDecimal(reader.GetValue(id_externoColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_red_pago_idColumnIndex))
						record.CTACTE_RED_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_red_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_transaccionColumnIndex))
						record.NRO_TRANSACCION = Convert.ToString(reader.GetValue(nro_transaccionColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_transaccionColumnIndex))
						record.FECHA_TRANSACCION = Convert.ToDateTime(reader.GetValue(fecha_transaccionColumnIndex));
					if(!reader.IsDBNull(fecha_acreditacionColumnIndex))
						record.FECHA_ACREDITACION = Convert.ToDateTime(reader.GetValue(fecha_acreditacionColumnIndex));
					if(!reader.IsDBNull(fecha_anulacionColumnIndex))
						record.FECHA_ANULACION = Convert.ToDateTime(reader.GetValue(fecha_anulacionColumnIndex));
					if(!reader.IsDBNull(ctacte_valor_idColumnIndex))
						record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_persona_idColumnIndex))
						record.CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacionColumnIndex))
						record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(monto_totalColumnIndex))
						record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					if(!reader.IsDBNull(monto_capitalColumnIndex))
						record.MONTO_CAPITAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capitalColumnIndex)), 9);
					if(!reader.IsDBNull(monto_interesesColumnIndex))
						record.MONTO_INTERESES = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interesesColumnIndex)), 9);
					if(!reader.IsDBNull(monto_gasto_administrativoColumnIndex))
						record.MONTO_GASTO_ADMINISTRATIVO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_gasto_administrativoColumnIndex)), 9);
					if(!reader.IsDBNull(comision_totalColumnIndex))
						record.COMISION_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(comision_totalColumnIndex)), 9);
					if(!reader.IsDBNull(comision_recaudadorColumnIndex))
						record.COMISION_RECAUDADOR = Math.Round(Convert.ToDecimal(reader.GetValue(comision_recaudadorColumnIndex)), 9);
					if(!reader.IsDBNull(comision_procesadorColumnIndex))
						record.COMISION_PROCESADOR = Math.Round(Convert.ToDecimal(reader.GetValue(comision_procesadorColumnIndex)), 9);
					if(!reader.IsDBNull(comision_clearingColumnIndex))
						record.COMISION_CLEARING = Math.Round(Convert.ToDecimal(reader.GetValue(comision_clearingColumnIndex)), 9);
					if(!reader.IsDBNull(comision_otroColumnIndex))
						record.COMISION_OTRO = Math.Round(Convert.ToDecimal(reader.GetValue(comision_otroColumnIndex)), 9);
					record.PROCESADO = Convert.ToString(reader.GetValue(procesadoColumnIndex));
					record.ANULADO = Convert.ToString(reader.GetValue(anuladoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(jsonColumnIndex))
						record.JSON = Convert.ToString(reader.GetValue(jsonColumnIndex));
					if(!reader.IsDBNull(transaccion_cierre_idColumnIndex))
						record.TRANSACCION_CIERRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transaccion_cierre_idColumnIndex)), 9);
					if(!reader.IsDBNull(comision_redColumnIndex))
						record.COMISION_RED = Math.Round(Convert.ToDecimal(reader.GetValue(comision_redColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_corteColumnIndex))
						record.FECHA_CORTE = Convert.ToDateTime(reader.GetValue(fecha_corteColumnIndex));
					if(!reader.IsDBNull(ctacte_banco_clearing_idColumnIndex))
						record.CTACTE_BANCO_CLEARING_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_clearing_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSACCIONESRow[])(recordList.ToArray(typeof(TRANSACCIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSACCIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSACCIONESRow"/> object.</returns>
		protected virtual TRANSACCIONESRow MapRow(DataRow row)
		{
			TRANSACCIONESRow mappedObject = new TRANSACCIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ID_EXTERNO"
			dataColumn = dataTable.Columns["ID_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID_EXTERNO = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RED_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RED_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RED_PAGO_ID = (decimal)row[dataColumn];
			// Column "NRO_TRANSACCION"
			dataColumn = dataTable.Columns["NRO_TRANSACCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TRANSACCION = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA_TRANSACCION"
			dataColumn = dataTable.Columns["FECHA_TRANSACCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_TRANSACCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_ACREDITACION"
			dataColumn = dataTable.Columns["FECHA_ACREDITACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ACREDITACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_ANULACION"
			dataColumn = dataTable.Columns["FECHA_ANULACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ANULACION = (System.DateTime)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "MONTO_CAPITAL"
			dataColumn = dataTable.Columns["MONTO_CAPITAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL = (decimal)row[dataColumn];
			// Column "MONTO_INTERESES"
			dataColumn = dataTable.Columns["MONTO_INTERESES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERESES = (decimal)row[dataColumn];
			// Column "MONTO_GASTO_ADMINISTRATIVO"
			dataColumn = dataTable.Columns["MONTO_GASTO_ADMINISTRATIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_GASTO_ADMINISTRATIVO = (decimal)row[dataColumn];
			// Column "COMISION_TOTAL"
			dataColumn = dataTable.Columns["COMISION_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_TOTAL = (decimal)row[dataColumn];
			// Column "COMISION_RECAUDADOR"
			dataColumn = dataTable.Columns["COMISION_RECAUDADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_RECAUDADOR = (decimal)row[dataColumn];
			// Column "COMISION_PROCESADOR"
			dataColumn = dataTable.Columns["COMISION_PROCESADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_PROCESADOR = (decimal)row[dataColumn];
			// Column "COMISION_CLEARING"
			dataColumn = dataTable.Columns["COMISION_CLEARING"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_CLEARING = (decimal)row[dataColumn];
			// Column "COMISION_OTRO"
			dataColumn = dataTable.Columns["COMISION_OTRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_OTRO = (decimal)row[dataColumn];
			// Column "PROCESADO"
			dataColumn = dataTable.Columns["PROCESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADO = (string)row[dataColumn];
			// Column "ANULADO"
			dataColumn = dataTable.Columns["ANULADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANULADO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "JSON"
			dataColumn = dataTable.Columns["JSON"];
			if(!row.IsNull(dataColumn))
				mappedObject.JSON = (string)row[dataColumn];
			// Column "TRANSACCION_CIERRE_ID"
			dataColumn = dataTable.Columns["TRANSACCION_CIERRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSACCION_CIERRE_ID = (decimal)row[dataColumn];
			// Column "COMISION_RED"
			dataColumn = dataTable.Columns["COMISION_RED"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_RED = (decimal)row[dataColumn];
			// Column "FECHA_CORTE"
			dataColumn = dataTable.Columns["FECHA_CORTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CORTE = (System.DateTime)row[dataColumn];
			// Column "CTACTE_BANCO_CLEARING_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_CLEARING_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_CLEARING_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSACCIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSACCIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ID_EXTERNO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RED_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_TRANSACCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_TRANSACCION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ACREDITACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ANULACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_INTERESES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_GASTO_ADMINISTRATIVO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_RECAUDADOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_PROCESADOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_CLEARING", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_OTRO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROCESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ANULADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("JSON", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn = dataTable.Columns.Add("TRANSACCION_CIERRE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_RED", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_CORTE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_CLEARING_ID", typeof(decimal));
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

				case "ID_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RED_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_TRANSACCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_TRANSACCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ACREDITACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ANULACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CAPITAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INTERESES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_GASTO_ADMINISTRATIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_RECAUDADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_PROCESADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_CLEARING":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_OTRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROCESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ANULADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "JSON":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSACCION_CIERRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_RED":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CORTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_BANCO_CLEARING_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSACCIONESCollection_Base class
}  // End of namespace
