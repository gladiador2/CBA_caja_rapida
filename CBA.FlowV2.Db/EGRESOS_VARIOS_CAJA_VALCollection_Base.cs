// <fileinfo name="EGRESOS_VARIOS_CAJA_VALCollection_Base.cs">
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
	/// The base class for <see cref="EGRESOS_VARIOS_CAJA_VALCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EGRESOS_VARIOS_CAJA_VALCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EGRESOS_VARIOS_CAJA_VALCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string COTIZACION_MONEDA_DESTINOColumnName = "COTIZACION_MONEDA_DESTINO";
		public const string CG_CTACTE_BANCARIA_IDColumnName = "CG_CTACTE_BANCARIA_ID";
		public const string CG_AUTONUMERACION_IDColumnName = "CG_AUTONUMERACION_ID";
		public const string CG_USAR_AUTONUMColumnName = "CG_USAR_AUTONUM";
		public const string CG_NUMERO_CHEQUEColumnName = "CG_NUMERO_CHEQUE";
		public const string CG_NOMBRE_EMISORColumnName = "CG_NOMBRE_EMISOR";
		public const string CG_NOMBRE_BENEFICIARIOColumnName = "CG_NOMBRE_BENEFICIARIO";
		public const string CG_FECHA_EMISIONColumnName = "CG_FECHA_EMISION";
		public const string CG_FECHA_VENCIMIENTOColumnName = "CG_FECHA_VENCIMIENTO";
		public const string CG_CTACTE_CHEQUE_GIRADO_IDColumnName = "CG_CTACTE_CHEQUE_GIRADO_ID";
		public const string RETENCION_EMITIDA_IDColumnName = "RETENCION_EMITIDA_ID";
		public const string RETENCION_AUX_CASOSColumnName = "RETENCION_AUX_CASOS";
		public const string RETENCION_AUX_MONTOSColumnName = "RETENCION_AUX_MONTOS";
		public const string RETENCION_TIPO_IDColumnName = "RETENCION_TIPO_ID";
		public const string RETENCION_FECHAColumnName = "RETENCION_FECHA";
		public const string CG_ES_DIFERIDOColumnName = "CG_ES_DIFERIDO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string ESTADOColumnName = "ESTADO";
		public const string RETENCION_PROVEEDOR_IDColumnName = "RETENCION_PROVEEDOR_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EGRESOS_VARIOS_CAJA_VALCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EGRESOS_VARIOS_CAJA_VALCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
		/// </summary>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EGRESOS_VARIOS_CAJA_VALRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects that 
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EGRESOS_VARIOS_CAJA_VAL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			EGRESOS_VARIOS_CAJA_VALRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow[] GetByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id)
		{
			return GetByCG_AUTONUMERACION_ID(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="cg_autonumeracion_idNull">true if the method ignores the cg_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id, bool cg_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByCG_AUTONUMERACION_IDCommand(cg_autonumeracion_id, cg_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_AUTONUMERACION_IDAsDataTable(decimal cg_autonumeracion_id)
		{
			return GetByCG_AUTONUMERACION_IDAsDataTable(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="cg_autonumeracion_idNull">true if the method ignores the cg_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCG_AUTONUMERACION_IDAsDataTable(decimal cg_autonumeracion_id, bool cg_autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCG_AUTONUMERACION_IDCommand(cg_autonumeracion_id, cg_autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="cg_autonumeracion_idNull">true if the method ignores the cg_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCG_AUTONUMERACION_IDCommand(decimal cg_autonumeracion_id, bool cg_autonumeracion_idNull)
		{
			string whereSql = "";
			if(cg_autonumeracion_idNull)
				whereSql += "CG_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "CG_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("CG_AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cg_autonumeracion_idNull)
				AddParameter(cmd, "CG_AUTONUMERACION_ID", cg_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow[] GetByCG_CTACTE_CHEQUE_GIRADO_ID(decimal cg_ctacte_cheque_girado_id)
		{
			return GetByCG_CTACTE_CHEQUE_GIRADO_ID(cg_ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_ctacte_cheque_girado_idNull">true if the method ignores the cg_ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByCG_CTACTE_CHEQUE_GIRADO_ID(decimal cg_ctacte_cheque_girado_id, bool cg_ctacte_cheque_girado_idNull)
		{
			return MapRecords(CreateGetByCG_CTACTE_CHEQUE_GIRADO_IDCommand(cg_ctacte_cheque_girado_id, cg_ctacte_cheque_girado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_CTACTE_CHEQUE_GIRADO_IDAsDataTable(decimal cg_ctacte_cheque_girado_id)
		{
			return GetByCG_CTACTE_CHEQUE_GIRADO_IDAsDataTable(cg_ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_ctacte_cheque_girado_idNull">true if the method ignores the cg_ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCG_CTACTE_CHEQUE_GIRADO_IDAsDataTable(decimal cg_ctacte_cheque_girado_id, bool cg_ctacte_cheque_girado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCG_CTACTE_CHEQUE_GIRADO_IDCommand(cg_ctacte_cheque_girado_id, cg_ctacte_cheque_girado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_ctacte_cheque_girado_idNull">true if the method ignores the cg_ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCG_CTACTE_CHEQUE_GIRADO_IDCommand(decimal cg_ctacte_cheque_girado_id, bool cg_ctacte_cheque_girado_idNull)
		{
			string whereSql = "";
			if(cg_ctacte_cheque_girado_idNull)
				whereSql += "CG_CTACTE_CHEQUE_GIRADO_ID IS NULL";
			else
				whereSql += "CG_CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CG_CTACTE_CHEQUE_GIRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cg_ctacte_cheque_girado_idNull)
				AddParameter(cmd, "CG_CTACTE_CHEQUE_GIRADO_ID", cg_ctacte_cheque_girado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow[] GetByCG_CTACTE_BANCARIA_ID(decimal cg_ctacte_bancaria_id)
		{
			return GetByCG_CTACTE_BANCARIA_ID(cg_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cg_ctacte_bancaria_idNull">true if the method ignores the cg_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByCG_CTACTE_BANCARIA_ID(decimal cg_ctacte_bancaria_id, bool cg_ctacte_bancaria_idNull)
		{
			return MapRecords(CreateGetByCG_CTACTE_BANCARIA_IDCommand(cg_ctacte_bancaria_id, cg_ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_CTACTE_BANCARIA_IDAsDataTable(decimal cg_ctacte_bancaria_id)
		{
			return GetByCG_CTACTE_BANCARIA_IDAsDataTable(cg_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cg_ctacte_bancaria_idNull">true if the method ignores the cg_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCG_CTACTE_BANCARIA_IDAsDataTable(decimal cg_ctacte_bancaria_id, bool cg_ctacte_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCG_CTACTE_BANCARIA_IDCommand(cg_ctacte_bancaria_id, cg_ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cg_ctacte_bancaria_idNull">true if the method ignores the cg_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCG_CTACTE_BANCARIA_IDCommand(decimal cg_ctacte_bancaria_id, bool cg_ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(cg_ctacte_bancaria_idNull)
				whereSql += "CG_CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CG_CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CG_CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cg_ctacte_bancaria_idNull)
				AddParameter(cmd, "CG_CTACTE_BANCARIA_ID", cg_ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_EGR_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return MapRecords(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_EGR_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_EGR_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id)
		{
			string whereSql = "";
			whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_MON_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_MON_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_MON_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow[] GetByRETENCION_EMITIDA_ID(decimal retencion_emitida_id)
		{
			return GetByRETENCION_EMITIDA_ID(retencion_emitida_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <param name="retencion_emitida_idNull">true if the method ignores the retencion_emitida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByRETENCION_EMITIDA_ID(decimal retencion_emitida_id, bool retencion_emitida_idNull)
		{
			return MapRecords(CreateGetByRETENCION_EMITIDA_IDCommand(retencion_emitida_id, retencion_emitida_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_EMITIDA_IDAsDataTable(decimal retencion_emitida_id)
		{
			return GetByRETENCION_EMITIDA_IDAsDataTable(retencion_emitida_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <param name="retencion_emitida_idNull">true if the method ignores the retencion_emitida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRETENCION_EMITIDA_IDAsDataTable(decimal retencion_emitida_id, bool retencion_emitida_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRETENCION_EMITIDA_IDCommand(retencion_emitida_id, retencion_emitida_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <param name="retencion_emitida_idNull">true if the method ignores the retencion_emitida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRETENCION_EMITIDA_IDCommand(decimal retencion_emitida_id, bool retencion_emitida_idNull)
		{
			string whereSql = "";
			if(retencion_emitida_idNull)
				whereSql += "RETENCION_EMITIDA_ID IS NULL";
			else
				whereSql += "RETENCION_EMITIDA_ID=" + _db.CreateSqlParameterName("RETENCION_EMITIDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!retencion_emitida_idNull)
				AddParameter(cmd, "RETENCION_EMITIDA_ID", retencion_emitida_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow[] GetByRETENCION_PROVEEDOR_ID(decimal retencion_proveedor_id)
		{
			return GetByRETENCION_PROVEEDOR_ID(retencion_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <param name="retencion_proveedor_idNull">true if the method ignores the retencion_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByRETENCION_PROVEEDOR_ID(decimal retencion_proveedor_id, bool retencion_proveedor_idNull)
		{
			return MapRecords(CreateGetByRETENCION_PROVEEDOR_IDCommand(retencion_proveedor_id, retencion_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_PROVEEDOR_IDAsDataTable(decimal retencion_proveedor_id)
		{
			return GetByRETENCION_PROVEEDOR_IDAsDataTable(retencion_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <param name="retencion_proveedor_idNull">true if the method ignores the retencion_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRETENCION_PROVEEDOR_IDAsDataTable(decimal retencion_proveedor_id, bool retencion_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRETENCION_PROVEEDOR_IDCommand(retencion_proveedor_id, retencion_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <param name="retencion_proveedor_idNull">true if the method ignores the retencion_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRETENCION_PROVEEDOR_IDCommand(decimal retencion_proveedor_id, bool retencion_proveedor_idNull)
		{
			string whereSql = "";
			if(retencion_proveedor_idNull)
				whereSql += "RETENCION_PROVEEDOR_ID IS NULL";
			else
				whereSql += "RETENCION_PROVEEDOR_ID=" + _db.CreateSqlParameterName("RETENCION_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!retencion_proveedor_idNull)
				AddParameter(cmd, "RETENCION_PROVEEDOR_ID", retencion_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public EGRESOS_VARIOS_CAJA_VALRow[] GetByRETENCION_TIPO_ID(decimal retencion_tipo_id)
		{
			return GetByRETENCION_TIPO_ID(retencion_tipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <param name="retencion_tipo_idNull">true if the method ignores the retencion_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByRETENCION_TIPO_ID(decimal retencion_tipo_id, bool retencion_tipo_idNull)
		{
			return MapRecords(CreateGetByRETENCION_TIPO_IDCommand(retencion_tipo_id, retencion_tipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_TIPO_IDAsDataTable(decimal retencion_tipo_id)
		{
			return GetByRETENCION_TIPO_IDAsDataTable(retencion_tipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <param name="retencion_tipo_idNull">true if the method ignores the retencion_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRETENCION_TIPO_IDAsDataTable(decimal retencion_tipo_id, bool retencion_tipo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRETENCION_TIPO_IDCommand(retencion_tipo_id, retencion_tipo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <param name="retencion_tipo_idNull">true if the method ignores the retencion_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRETENCION_TIPO_IDCommand(decimal retencion_tipo_id, bool retencion_tipo_idNull)
		{
			string whereSql = "";
			if(retencion_tipo_idNull)
				whereSql += "RETENCION_TIPO_ID IS NULL";
			else
				whereSql += "RETENCION_TIPO_ID=" + _db.CreateSqlParameterName("RETENCION_TIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!retencion_tipo_idNull)
				AddParameter(cmd, "RETENCION_TIPO_ID", retencion_tipo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_VALOR_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		public virtual EGRESOS_VARIOS_CAJA_VALRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_EGR_VAR_CAJ_VAL_VALOR_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_EGR_VAR_CAJ_VAL_VALOR_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> object to be inserted.</param>
		public virtual void Insert(EGRESOS_VARIOS_CAJA_VALRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.EGRESOS_VARIOS_CAJA_VAL (" +
				"ID, " +
				"EGRESO_VARIO_CAJA_ID, " +
				"CTACTE_VALOR_ID, " +
				"MONEDA_ORIGEN_ID, " +
				"MONTO_ORIGEN, " +
				"OBSERVACION, " +
				"COTIZACION_MONEDA_ORIGEN, " +
				"MONTO_DESTINO, " +
				"COTIZACION_MONEDA_DESTINO, " +
				"CG_CTACTE_BANCARIA_ID, " +
				"CG_AUTONUMERACION_ID, " +
				"CG_USAR_AUTONUM, " +
				"CG_NUMERO_CHEQUE, " +
				"CG_NOMBRE_EMISOR, " +
				"CG_NOMBRE_BENEFICIARIO, " +
				"CG_FECHA_EMISION, " +
				"CG_FECHA_VENCIMIENTO, " +
				"CG_CTACTE_CHEQUE_GIRADO_ID, " +
				"RETENCION_EMITIDA_ID, " +
				"RETENCION_AUX_CASOS, " +
				"RETENCION_AUX_MONTOS, " +
				"RETENCION_TIPO_ID, " +
				"RETENCION_FECHA, " +
				"CG_ES_DIFERIDO, " +
				"NRO_COMPROBANTE, " +
				"ESTADO, " +
				"RETENCION_PROVEEDOR_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_DESTINO") + ", " +
				_db.CreateSqlParameterName("CG_CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("CG_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("CG_USAR_AUTONUM") + ", " +
				_db.CreateSqlParameterName("CG_NUMERO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("CG_NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("CG_NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("CG_FECHA_EMISION") + ", " +
				_db.CreateSqlParameterName("CG_FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CG_CTACTE_CHEQUE_GIRADO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_EMITIDA_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_AUX_CASOS") + ", " +
				_db.CreateSqlParameterName("RETENCION_AUX_MONTOS") + ", " +
				_db.CreateSqlParameterName("RETENCION_TIPO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_FECHA") + ", " +
				_db.CreateSqlParameterName("CG_ES_DIFERIDO") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("RETENCION_PROVEEDOR_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "COTIZACION_MONEDA_DESTINO", value.COTIZACION_MONEDA_DESTINO);
			AddParameter(cmd, "CG_CTACTE_BANCARIA_ID",
				value.IsCG_CTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CG_CTACTE_BANCARIA_ID);
			AddParameter(cmd, "CG_AUTONUMERACION_ID",
				value.IsCG_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.CG_AUTONUMERACION_ID);
			AddParameter(cmd, "CG_USAR_AUTONUM", value.CG_USAR_AUTONUM);
			AddParameter(cmd, "CG_NUMERO_CHEQUE", value.CG_NUMERO_CHEQUE);
			AddParameter(cmd, "CG_NOMBRE_EMISOR", value.CG_NOMBRE_EMISOR);
			AddParameter(cmd, "CG_NOMBRE_BENEFICIARIO", value.CG_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CG_FECHA_EMISION",
				value.IsCG_FECHA_EMISIONNull ? DBNull.Value : (object)value.CG_FECHA_EMISION);
			AddParameter(cmd, "CG_FECHA_VENCIMIENTO",
				value.IsCG_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CG_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CG_CTACTE_CHEQUE_GIRADO_ID",
				value.IsCG_CTACTE_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CG_CTACTE_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "RETENCION_EMITIDA_ID",
				value.IsRETENCION_EMITIDA_IDNull ? DBNull.Value : (object)value.RETENCION_EMITIDA_ID);
			AddParameter(cmd, "RETENCION_AUX_CASOS", value.RETENCION_AUX_CASOS);
			AddParameter(cmd, "RETENCION_AUX_MONTOS", value.RETENCION_AUX_MONTOS);
			AddParameter(cmd, "RETENCION_TIPO_ID",
				value.IsRETENCION_TIPO_IDNull ? DBNull.Value : (object)value.RETENCION_TIPO_ID);
			AddParameter(cmd, "RETENCION_FECHA",
				value.IsRETENCION_FECHANull ? DBNull.Value : (object)value.RETENCION_FECHA);
			AddParameter(cmd, "CG_ES_DIFERIDO", value.CG_ES_DIFERIDO);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RETENCION_PROVEEDOR_ID",
				value.IsRETENCION_PROVEEDOR_IDNull ? DBNull.Value : (object)value.RETENCION_PROVEEDOR_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJA_VALRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(EGRESOS_VARIOS_CAJA_VALRow value)
		{
			
			string sqlStr = "UPDATE TRC.EGRESOS_VARIOS_CAJA_VAL SET " +
				"EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"MONTO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"COTIZACION_MONEDA_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				"MONTO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				"COTIZACION_MONEDA_DESTINO=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_DESTINO") + ", " +
				"CG_CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CG_CTACTE_BANCARIA_ID") + ", " +
				"CG_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("CG_AUTONUMERACION_ID") + ", " +
				"CG_USAR_AUTONUM=" + _db.CreateSqlParameterName("CG_USAR_AUTONUM") + ", " +
				"CG_NUMERO_CHEQUE=" + _db.CreateSqlParameterName("CG_NUMERO_CHEQUE") + ", " +
				"CG_NOMBRE_EMISOR=" + _db.CreateSqlParameterName("CG_NOMBRE_EMISOR") + ", " +
				"CG_NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("CG_NOMBRE_BENEFICIARIO") + ", " +
				"CG_FECHA_EMISION=" + _db.CreateSqlParameterName("CG_FECHA_EMISION") + ", " +
				"CG_FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("CG_FECHA_VENCIMIENTO") + ", " +
				"CG_CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CG_CTACTE_CHEQUE_GIRADO_ID") + ", " +
				"RETENCION_EMITIDA_ID=" + _db.CreateSqlParameterName("RETENCION_EMITIDA_ID") + ", " +
				"RETENCION_AUX_CASOS=" + _db.CreateSqlParameterName("RETENCION_AUX_CASOS") + ", " +
				"RETENCION_AUX_MONTOS=" + _db.CreateSqlParameterName("RETENCION_AUX_MONTOS") + ", " +
				"RETENCION_TIPO_ID=" + _db.CreateSqlParameterName("RETENCION_TIPO_ID") + ", " +
				"RETENCION_FECHA=" + _db.CreateSqlParameterName("RETENCION_FECHA") + ", " +
				"CG_ES_DIFERIDO=" + _db.CreateSqlParameterName("CG_ES_DIFERIDO") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"RETENCION_PROVEEDOR_ID=" + _db.CreateSqlParameterName("RETENCION_PROVEEDOR_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "COTIZACION_MONEDA_DESTINO", value.COTIZACION_MONEDA_DESTINO);
			AddParameter(cmd, "CG_CTACTE_BANCARIA_ID",
				value.IsCG_CTACTE_BANCARIA_IDNull ? DBNull.Value : (object)value.CG_CTACTE_BANCARIA_ID);
			AddParameter(cmd, "CG_AUTONUMERACION_ID",
				value.IsCG_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.CG_AUTONUMERACION_ID);
			AddParameter(cmd, "CG_USAR_AUTONUM", value.CG_USAR_AUTONUM);
			AddParameter(cmd, "CG_NUMERO_CHEQUE", value.CG_NUMERO_CHEQUE);
			AddParameter(cmd, "CG_NOMBRE_EMISOR", value.CG_NOMBRE_EMISOR);
			AddParameter(cmd, "CG_NOMBRE_BENEFICIARIO", value.CG_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CG_FECHA_EMISION",
				value.IsCG_FECHA_EMISIONNull ? DBNull.Value : (object)value.CG_FECHA_EMISION);
			AddParameter(cmd, "CG_FECHA_VENCIMIENTO",
				value.IsCG_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CG_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CG_CTACTE_CHEQUE_GIRADO_ID",
				value.IsCG_CTACTE_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CG_CTACTE_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "RETENCION_EMITIDA_ID",
				value.IsRETENCION_EMITIDA_IDNull ? DBNull.Value : (object)value.RETENCION_EMITIDA_ID);
			AddParameter(cmd, "RETENCION_AUX_CASOS", value.RETENCION_AUX_CASOS);
			AddParameter(cmd, "RETENCION_AUX_MONTOS", value.RETENCION_AUX_MONTOS);
			AddParameter(cmd, "RETENCION_TIPO_ID",
				value.IsRETENCION_TIPO_IDNull ? DBNull.Value : (object)value.RETENCION_TIPO_ID);
			AddParameter(cmd, "RETENCION_FECHA",
				value.IsRETENCION_FECHANull ? DBNull.Value : (object)value.RETENCION_FECHA);
			AddParameter(cmd, "CG_ES_DIFERIDO", value.CG_ES_DIFERIDO);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RETENCION_PROVEEDOR_ID",
				value.IsRETENCION_PROVEEDOR_IDNull ? DBNull.Value : (object)value.RETENCION_PROVEEDOR_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>EGRESOS_VARIOS_CAJA_VAL</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>EGRESOS_VARIOS_CAJA_VAL</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
		/// </summary>
		/// <param name="value">The <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(EGRESOS_VARIOS_CAJA_VALRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using
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
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id)
		{
			return DeleteByCG_AUTONUMERACION_ID(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="cg_autonumeracion_idNull">true if the method ignores the cg_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id, bool cg_autonumeracion_idNull)
		{
			return CreateDeleteByCG_AUTONUMERACION_IDCommand(cg_autonumeracion_id, cg_autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="cg_autonumeracion_idNull">true if the method ignores the cg_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCG_AUTONUMERACION_IDCommand(decimal cg_autonumeracion_id, bool cg_autonumeracion_idNull)
		{
			string whereSql = "";
			if(cg_autonumeracion_idNull)
				whereSql += "CG_AUTONUMERACION_ID IS NULL";
			else
				whereSql += "CG_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("CG_AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cg_autonumeracion_idNull)
				AddParameter(cmd, "CG_AUTONUMERACION_ID", cg_autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CTACTE_CHEQUE_GIRADO_ID(decimal cg_ctacte_cheque_girado_id)
		{
			return DeleteByCG_CTACTE_CHEQUE_GIRADO_ID(cg_ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_ctacte_cheque_girado_idNull">true if the method ignores the cg_ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CTACTE_CHEQUE_GIRADO_ID(decimal cg_ctacte_cheque_girado_id, bool cg_ctacte_cheque_girado_idNull)
		{
			return CreateDeleteByCG_CTACTE_CHEQUE_GIRADO_IDCommand(cg_ctacte_cheque_girado_id, cg_ctacte_cheque_girado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_CG_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_ctacte_cheque_girado_idNull">true if the method ignores the cg_ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCG_CTACTE_CHEQUE_GIRADO_IDCommand(decimal cg_ctacte_cheque_girado_id, bool cg_ctacte_cheque_girado_idNull)
		{
			string whereSql = "";
			if(cg_ctacte_cheque_girado_idNull)
				whereSql += "CG_CTACTE_CHEQUE_GIRADO_ID IS NULL";
			else
				whereSql += "CG_CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CG_CTACTE_CHEQUE_GIRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cg_ctacte_cheque_girado_idNull)
				AddParameter(cmd, "CG_CTACTE_CHEQUE_GIRADO_ID", cg_ctacte_cheque_girado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CTACTE_BANCARIA_ID(decimal cg_ctacte_bancaria_id)
		{
			return DeleteByCG_CTACTE_BANCARIA_ID(cg_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cg_ctacte_bancaria_idNull">true if the method ignores the cg_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CTACTE_BANCARIA_ID(decimal cg_ctacte_bancaria_id, bool cg_ctacte_bancaria_idNull)
		{
			return CreateDeleteByCG_CTACTE_BANCARIA_IDCommand(cg_ctacte_bancaria_id, cg_ctacte_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_CTA_BANC_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cg_ctacte_bancaria_idNull">true if the method ignores the cg_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCG_CTACTE_BANCARIA_IDCommand(decimal cg_ctacte_bancaria_id, bool cg_ctacte_bancaria_idNull)
		{
			string whereSql = "";
			if(cg_ctacte_bancaria_idNull)
				whereSql += "CG_CTACTE_BANCARIA_ID IS NULL";
			else
				whereSql += "CG_CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CG_CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cg_ctacte_bancaria_idNull)
				AddParameter(cmd, "CG_CTACTE_BANCARIA_ID", cg_ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_EGR_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_EGR_ID</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id)
		{
			string whereSql = "";
			whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_MON_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_MON_ORIG_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_EMITIDA_ID(decimal retencion_emitida_id)
		{
			return DeleteByRETENCION_EMITIDA_ID(retencion_emitida_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <param name="retencion_emitida_idNull">true if the method ignores the retencion_emitida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_EMITIDA_ID(decimal retencion_emitida_id, bool retencion_emitida_idNull)
		{
			return CreateDeleteByRETENCION_EMITIDA_IDCommand(retencion_emitida_id, retencion_emitida_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_RET_EMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <param name="retencion_emitida_idNull">true if the method ignores the retencion_emitida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRETENCION_EMITIDA_IDCommand(decimal retencion_emitida_id, bool retencion_emitida_idNull)
		{
			string whereSql = "";
			if(retencion_emitida_idNull)
				whereSql += "RETENCION_EMITIDA_ID IS NULL";
			else
				whereSql += "RETENCION_EMITIDA_ID=" + _db.CreateSqlParameterName("RETENCION_EMITIDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!retencion_emitida_idNull)
				AddParameter(cmd, "RETENCION_EMITIDA_ID", retencion_emitida_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_PROVEEDOR_ID(decimal retencion_proveedor_id)
		{
			return DeleteByRETENCION_PROVEEDOR_ID(retencion_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <param name="retencion_proveedor_idNull">true if the method ignores the retencion_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_PROVEEDOR_ID(decimal retencion_proveedor_id, bool retencion_proveedor_idNull)
		{
			return CreateDeleteByRETENCION_PROVEEDOR_IDCommand(retencion_proveedor_id, retencion_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_RET_PROV</c> foreign key.
		/// </summary>
		/// <param name="retencion_proveedor_id">The <c>RETENCION_PROVEEDOR_ID</c> column value.</param>
		/// <param name="retencion_proveedor_idNull">true if the method ignores the retencion_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRETENCION_PROVEEDOR_IDCommand(decimal retencion_proveedor_id, bool retencion_proveedor_idNull)
		{
			string whereSql = "";
			if(retencion_proveedor_idNull)
				whereSql += "RETENCION_PROVEEDOR_ID IS NULL";
			else
				whereSql += "RETENCION_PROVEEDOR_ID=" + _db.CreateSqlParameterName("RETENCION_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!retencion_proveedor_idNull)
				AddParameter(cmd, "RETENCION_PROVEEDOR_ID", retencion_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_TIPO_ID(decimal retencion_tipo_id)
		{
			return DeleteByRETENCION_TIPO_ID(retencion_tipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <param name="retencion_tipo_idNull">true if the method ignores the retencion_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_TIPO_ID(decimal retencion_tipo_id, bool retencion_tipo_idNull)
		{
			return CreateDeleteByRETENCION_TIPO_IDCommand(retencion_tipo_id, retencion_tipo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_RET_TIP_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <param name="retencion_tipo_idNull">true if the method ignores the retencion_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRETENCION_TIPO_IDCommand(decimal retencion_tipo_id, bool retencion_tipo_idNull)
		{
			string whereSql = "";
			if(retencion_tipo_idNull)
				whereSql += "RETENCION_TIPO_ID IS NULL";
			else
				whereSql += "RETENCION_TIPO_ID=" + _db.CreateSqlParameterName("RETENCION_TIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!retencion_tipo_idNull)
				AddParameter(cmd, "RETENCION_TIPO_ID", retencion_tipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table using the 
		/// <c>FK_EGR_VAR_CAJ_VAL_VALOR_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_EGR_VAR_CAJ_VAL_VALOR_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>EGRESOS_VARIOS_CAJA_VAL</c> records that match the specified criteria.
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
		/// to delete <c>EGRESOS_VARIOS_CAJA_VAL</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.EGRESOS_VARIOS_CAJA_VAL";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		protected EGRESOS_VARIOS_CAJA_VALRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		protected EGRESOS_VARIOS_CAJA_VALRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> objects.</returns>
		protected virtual EGRESOS_VARIOS_CAJA_VALRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int cotizacion_moneda_destinoColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_DESTINO");
			int cg_ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CG_CTACTE_BANCARIA_ID");
			int cg_autonumeracion_idColumnIndex = reader.GetOrdinal("CG_AUTONUMERACION_ID");
			int cg_usar_autonumColumnIndex = reader.GetOrdinal("CG_USAR_AUTONUM");
			int cg_numero_chequeColumnIndex = reader.GetOrdinal("CG_NUMERO_CHEQUE");
			int cg_nombre_emisorColumnIndex = reader.GetOrdinal("CG_NOMBRE_EMISOR");
			int cg_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CG_NOMBRE_BENEFICIARIO");
			int cg_fecha_emisionColumnIndex = reader.GetOrdinal("CG_FECHA_EMISION");
			int cg_fecha_vencimientoColumnIndex = reader.GetOrdinal("CG_FECHA_VENCIMIENTO");
			int cg_ctacte_cheque_girado_idColumnIndex = reader.GetOrdinal("CG_CTACTE_CHEQUE_GIRADO_ID");
			int retencion_emitida_idColumnIndex = reader.GetOrdinal("RETENCION_EMITIDA_ID");
			int retencion_aux_casosColumnIndex = reader.GetOrdinal("RETENCION_AUX_CASOS");
			int retencion_aux_montosColumnIndex = reader.GetOrdinal("RETENCION_AUX_MONTOS");
			int retencion_tipo_idColumnIndex = reader.GetOrdinal("RETENCION_TIPO_ID");
			int retencion_fechaColumnIndex = reader.GetOrdinal("RETENCION_FECHA");
			int cg_es_diferidoColumnIndex = reader.GetOrdinal("CG_ES_DIFERIDO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int retencion_proveedor_idColumnIndex = reader.GetOrdinal("RETENCION_PROVEEDOR_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EGRESOS_VARIOS_CAJA_VALRow record = new EGRESOS_VARIOS_CAJA_VALRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					record.COTIZACION_MONEDA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(cg_ctacte_bancaria_idColumnIndex))
						record.CG_CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_autonumeracion_idColumnIndex))
						record.CG_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_usar_autonumColumnIndex))
						record.CG_USAR_AUTONUM = Convert.ToString(reader.GetValue(cg_usar_autonumColumnIndex));
					if(!reader.IsDBNull(cg_numero_chequeColumnIndex))
						record.CG_NUMERO_CHEQUE = Convert.ToString(reader.GetValue(cg_numero_chequeColumnIndex));
					if(!reader.IsDBNull(cg_nombre_emisorColumnIndex))
						record.CG_NOMBRE_EMISOR = Convert.ToString(reader.GetValue(cg_nombre_emisorColumnIndex));
					if(!reader.IsDBNull(cg_nombre_beneficiarioColumnIndex))
						record.CG_NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(cg_nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cg_fecha_emisionColumnIndex))
						record.CG_FECHA_EMISION = Convert.ToDateTime(reader.GetValue(cg_fecha_emisionColumnIndex));
					if(!reader.IsDBNull(cg_fecha_vencimientoColumnIndex))
						record.CG_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(cg_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(cg_ctacte_cheque_girado_idColumnIndex))
						record.CG_CTACTE_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_ctacte_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_emitida_idColumnIndex))
						record.RETENCION_EMITIDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_emitida_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_aux_casosColumnIndex))
						record.RETENCION_AUX_CASOS = Convert.ToString(reader.GetValue(retencion_aux_casosColumnIndex));
					if(!reader.IsDBNull(retencion_aux_montosColumnIndex))
						record.RETENCION_AUX_MONTOS = Convert.ToString(reader.GetValue(retencion_aux_montosColumnIndex));
					if(!reader.IsDBNull(retencion_tipo_idColumnIndex))
						record.RETENCION_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_fechaColumnIndex))
						record.RETENCION_FECHA = Convert.ToDateTime(reader.GetValue(retencion_fechaColumnIndex));
					if(!reader.IsDBNull(cg_es_diferidoColumnIndex))
						record.CG_ES_DIFERIDO = Convert.ToString(reader.GetValue(cg_es_diferidoColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(retencion_proveedor_idColumnIndex))
						record.RETENCION_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_proveedor_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EGRESOS_VARIOS_CAJA_VALRow[])(recordList.ToArray(typeof(EGRESOS_VARIOS_CAJA_VALRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EGRESOS_VARIOS_CAJA_VALRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EGRESOS_VARIOS_CAJA_VALRow"/> object.</returns>
		protected virtual EGRESOS_VARIOS_CAJA_VALRow MapRow(DataRow row)
		{
			EGRESOS_VARIOS_CAJA_VALRow mappedObject = new EGRESOS_VARIOS_CAJA_VALRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_DESTINO = (decimal)row[dataColumn];
			// Column "CG_CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CG_CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "CG_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["CG_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "CG_USAR_AUTONUM"
			dataColumn = dataTable.Columns["CG_USAR_AUTONUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_USAR_AUTONUM = (string)row[dataColumn];
			// Column "CG_NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["CG_NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "CG_NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["CG_NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "CG_NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["CG_NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CG_FECHA_EMISION"
			dataColumn = dataTable.Columns["CG_FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "CG_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CG_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CG_CTACTE_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CG_CTACTE_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CTACTE_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_EMITIDA_ID"
			dataColumn = dataTable.Columns["RETENCION_EMITIDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_EMITIDA_ID = (decimal)row[dataColumn];
			// Column "RETENCION_AUX_CASOS"
			dataColumn = dataTable.Columns["RETENCION_AUX_CASOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_AUX_CASOS = (string)row[dataColumn];
			// Column "RETENCION_AUX_MONTOS"
			dataColumn = dataTable.Columns["RETENCION_AUX_MONTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_AUX_MONTOS = (string)row[dataColumn];
			// Column "RETENCION_TIPO_ID"
			dataColumn = dataTable.Columns["RETENCION_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_TIPO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_FECHA"
			dataColumn = dataTable.Columns["RETENCION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_FECHA = (System.DateTime)row[dataColumn];
			// Column "CG_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CG_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_ES_DIFERIDO = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "RETENCION_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["RETENCION_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_PROVEEDOR_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EGRESOS_VARIOS_CAJA_VAL</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EGRESOS_VARIOS_CAJA_VAL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_USAR_AUTONUM", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CG_NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CG_FECHA_EMISION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CG_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CG_CTACTE_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_EMITIDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_AUX_CASOS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("RETENCION_AUX_MONTOS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("RETENCION_TIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CG_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RETENCION_PROVEEDOR_ID", typeof(decimal));
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

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_USAR_AUTONUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CG_NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_CTACTE_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_EMITIDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_AUX_CASOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_AUX_MONTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RETENCION_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EGRESOS_VARIOS_CAJA_VALCollection_Base class
}  // End of namespace
