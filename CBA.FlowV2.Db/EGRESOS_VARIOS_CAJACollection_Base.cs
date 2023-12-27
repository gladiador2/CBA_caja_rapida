// <fileinfo name="EGRESOS_VARIOS_CAJACollection_Base.cs">
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
	/// The base class for <see cref="EGRESOS_VARIOS_CAJACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EGRESOS_VARIOS_CAJACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESOS_VARIOS_CAJACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string FECHA_RECIBO_BENEFICIARIOColumnName = "FECHA_RECIBO_BENEFICIARIO";
		public const string NRO_RECIBO_BENEFICIARIOColumnName = "NRO_RECIBO_BENEFICIARIO";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string GASTO_DIRECTIVOColumnName = "GASTO_DIRECTIVO";
		public const string RETENCION_AUTONUMERACION_IDColumnName = "RETENCION_AUTONUMERACION_ID";
		public const string RETENCION_UNIFICADAColumnName = "RETENCION_UNIFICADA";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESOS_VARIOS_CAJACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EGRESOS_VARIOS_CAJACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EGRESOS_VARIOS_CAJA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EGRESOS_VARIOS_CAJA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EGRESOS_VARIOS_CAJA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EGRESOS_VARIOS_CAJARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EGRESOS_VARIOS_CAJARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EGRESOS_VARIOS_CAJARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EGRESOS_VARIOS_CAJARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects that 
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EGRESOS_VARIOS_CAJA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EGRESOS_VARIOS_CAJARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EGRESOS_VARIOS_CAJARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EGRESOS_VARIOS_CAJARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EGRESOS_VARIOS_CAJARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJARow[] GetByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id)
		{
			return GetByRETENCION_AUTONUMERACION_ID(retencion_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByRETENCION_AUTONUMERACION_IDCommand(retencion_autonumeracion_id, retencion_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_AUTONUMERACION_IDAsDataTable(decimal retencion_autonumeracion_id)
		{
			return GetByRETENCION_AUTONUMERACION_IDAsDataTable(retencion_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRETENCION_AUTONUMERACION_IDAsDataTable(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRETENCION_AUTONUMERACION_IDCommand(retencion_autonumeracion_id, retencion_autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRETENCION_AUTONUMERACION_IDCommand(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			string whereSql = "";
			if(retencion_autonumeracion_idNull)
				whereSql += "RETENCION_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "RETENCION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!retencion_autonumeracion_idNull)
				AddParameter(cmd, "RETENCION_AUTONUMERACION_ID", retencion_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_AUTO</c> foreign key.
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
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJARow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
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
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
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
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_CASO</c> foreign key.
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
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJARow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_IDAsDataTable(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_MON</c> foreign key.
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
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJARow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGRESOS_VARIOS_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGRESOS_VARIOS_CAJA_SUC</c> foreign key.
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
		/// Adds a new record into the <c>EGRESOS_VARIOS_CAJA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJARow"/> object to be inserted.</param>
		public virtual void Insert(EGRESOS_VARIOS_CAJARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EGRESOS_VARIOS_CAJA (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"CTACTE_FONDO_FIJO_ID, " +
				"FECHA, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"NOMBRE_BENEFICIARIO, " +
				"FECHA_RECIBO_BENEFICIARIO, " +
				"NRO_RECIBO_BENEFICIARIO, " +
				"MONTO_TOTAL, " +
				"OBSERVACION, " +
				"GASTO_DIRECTIVO, " +
				"RETENCION_AUTONUMERACION_ID, " +
				"RETENCION_UNIFICADA, " +
				"CTACTE_CAJA_SUCURSAL_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("FECHA_RECIBO_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("NRO_RECIBO_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("GASTO_DIRECTIVO") + ", " +
				_db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_UNIFICADA") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_RECIBO_BENEFICIARIO",
				value.IsFECHA_RECIBO_BENEFICIARIONull ? DBNull.Value : (object)value.FECHA_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "NRO_RECIBO_BENEFICIARIO", value.NRO_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "GASTO_DIRECTIVO", value.GASTO_DIRECTIVO);
			AddParameter(cmd, "RETENCION_AUTONUMERACION_ID",
				value.IsRETENCION_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.RETENCION_AUTONUMERACION_ID);
			AddParameter(cmd, "RETENCION_UNIFICADA", value.RETENCION_UNIFICADA);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EGRESOS_VARIOS_CAJA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EGRESOS_VARIOS_CAJARow value)
		{
			
			string sqlStr = "UPDATE TRC.EGRESOS_VARIOS_CAJA SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("NOMBRE_BENEFICIARIO") + ", " +
				"FECHA_RECIBO_BENEFICIARIO=" + _db.CreateSqlParameterName("FECHA_RECIBO_BENEFICIARIO") + ", " +
				"NRO_RECIBO_BENEFICIARIO=" + _db.CreateSqlParameterName("NRO_RECIBO_BENEFICIARIO") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"GASTO_DIRECTIVO=" + _db.CreateSqlParameterName("GASTO_DIRECTIVO") + ", " +
				"RETENCION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID") + ", " +
				"RETENCION_UNIFICADA=" + _db.CreateSqlParameterName("RETENCION_UNIFICADA") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "NOMBRE_BENEFICIARIO", value.NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "FECHA_RECIBO_BENEFICIARIO",
				value.IsFECHA_RECIBO_BENEFICIARIONull ? DBNull.Value : (object)value.FECHA_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "NRO_RECIBO_BENEFICIARIO", value.NRO_RECIBO_BENEFICIARIO);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "GASTO_DIRECTIVO", value.GASTO_DIRECTIVO);
			AddParameter(cmd, "RETENCION_AUTONUMERACION_ID",
				value.IsRETENCION_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.RETENCION_AUTONUMERACION_ID);
			AddParameter(cmd, "RETENCION_UNIFICADA", value.RETENCION_UNIFICADA);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EGRESOS_VARIOS_CAJA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EGRESOS_VARIOS_CAJA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EGRESOS_VARIOS_CAJA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EGRESOS_VARIOS_CAJARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EGRESOS_VARIOS_CAJA</c> table using
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id)
		{
			return DeleteByRETENCION_AUTONUMERACION_ID(retencion_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_AUTONUMERACION_ID(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			return CreateDeleteByRETENCION_AUTONUMERACION_IDCommand(retencion_autonumeracion_id, retencion_autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VAR_CAJA_AUTO_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_autonumeracion_id">The <c>RETENCION_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="retencion_autonumeracion_idNull">true if the method ignores the retencion_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRETENCION_AUTONUMERACION_IDCommand(decimal retencion_autonumeracion_id, bool retencion_autonumeracion_idNull)
		{
			string whereSql = "";
			if(retencion_autonumeracion_idNull)
				whereSql += "RETENCION_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "RETENCION_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("RETENCION_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!retencion_autonumeracion_idNull)
				AddParameter(cmd, "RETENCION_AUTONUMERACION_ID", retencion_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_AUTO</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_AUTO</c> foreign key.
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
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
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_CAJA_SU</c> foreign key.
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_CASO</c> foreign key.
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return DeleteByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_FONDO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_MON</c> foreign key.
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA</c> table using the 
		/// <c>FK_EGRESOS_VARIOS_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGRESOS_VARIOS_CAJA_SUC</c> foreign key.
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
		/// Deletes <c>EGRESOS_VARIOS_CAJA</c> records that match the specified criteria.
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
		/// to delete <c>EGRESOS_VARIOS_CAJA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EGRESOS_VARIOS_CAJA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EGRESOS_VARIOS_CAJA</c> table.
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		protected EGRESOS_VARIOS_CAJARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		protected EGRESOS_VARIOS_CAJARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJARow"/> objects.</returns>
		protected virtual EGRESOS_VARIOS_CAJARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int fecha_recibo_beneficiarioColumnIndex = reader.GetOrdinal("FECHA_RECIBO_BENEFICIARIO");
			int nro_recibo_beneficiarioColumnIndex = reader.GetOrdinal("NRO_RECIBO_BENEFICIARIO");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int gasto_directivoColumnIndex = reader.GetOrdinal("GASTO_DIRECTIVO");
			int retencion_autonumeracion_idColumnIndex = reader.GetOrdinal("RETENCION_AUTONUMERACION_ID");
			int retencion_unificadaColumnIndex = reader.GetOrdinal("RETENCION_UNIFICADA");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EGRESOS_VARIOS_CAJARow record = new EGRESOS_VARIOS_CAJARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_beneficiarioColumnIndex))
						record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(fecha_recibo_beneficiarioColumnIndex))
						record.FECHA_RECIBO_BENEFICIARIO = Convert.ToDateTime(reader.GetValue(fecha_recibo_beneficiarioColumnIndex));
					if(!reader.IsDBNull(nro_recibo_beneficiarioColumnIndex))
						record.NRO_RECIBO_BENEFICIARIO = Convert.ToString(reader.GetValue(nro_recibo_beneficiarioColumnIndex));
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.GASTO_DIRECTIVO = Convert.ToString(reader.GetValue(gasto_directivoColumnIndex));
					if(!reader.IsDBNull(retencion_autonumeracion_idColumnIndex))
						record.RETENCION_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_unificadaColumnIndex))
						record.RETENCION_UNIFICADA = Convert.ToString(reader.GetValue(retencion_unificadaColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EGRESOS_VARIOS_CAJARow[])(recordList.ToArray(typeof(EGRESOS_VARIOS_CAJARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EGRESOS_VARIOS_CAJARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EGRESOS_VARIOS_CAJARow"/> object.</returns>
		protected virtual EGRESOS_VARIOS_CAJARow MapRow(DataRow row)
		{
			EGRESOS_VARIOS_CAJARow mappedObject = new EGRESOS_VARIOS_CAJARow();
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
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "FECHA_RECIBO_BENEFICIARIO"
			dataColumn = dataTable.Columns["FECHA_RECIBO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECIBO_BENEFICIARIO = (System.DateTime)row[dataColumn];
			// Column "NRO_RECIBO_BENEFICIARIO"
			dataColumn = dataTable.Columns["NRO_RECIBO_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_RECIBO_BENEFICIARIO = (string)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "GASTO_DIRECTIVO"
			dataColumn = dataTable.Columns["GASTO_DIRECTIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GASTO_DIRECTIVO = (string)row[dataColumn];
			// Column "RETENCION_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["RETENCION_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "RETENCION_UNIFICADA"
			dataColumn = dataTable.Columns["RETENCION_UNIFICADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_UNIFICADA = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EGRESOS_VARIOS_CAJA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EGRESOS_VARIOS_CAJA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("FECHA_RECIBO_BENEFICIARIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_RECIBO_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("GASTO_DIRECTIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RETENCION_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_UNIFICADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
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

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_RECIBO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_RECIBO_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GASTO_DIRECTIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RETENCION_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_UNIFICADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EGRESOS_VARIOS_CAJACollection_Base class
}  // End of namespace
