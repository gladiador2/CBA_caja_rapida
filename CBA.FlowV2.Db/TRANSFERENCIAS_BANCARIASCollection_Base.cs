// <fileinfo name="TRANSFERENCIAS_BANCARIASCollection_Base.cs">
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
	/// The base class for <see cref="TRANSFERENCIAS_BANCARIASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRANSFERENCIAS_BANCARIASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSFERENCIAS_BANCARIASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string CUENTA_ORIGEN_ADMINISTRADAColumnName = "CUENTA_ORIGEN_ADMINISTRADA";
		public const string CUENTA_DESTINO_ADMINISTRADAColumnName = "CUENTA_DESTINO_ADMINISTRADA";
		public const string CUENTA_ORIGEN_TERCEROSColumnName = "CUENTA_ORIGEN_TERCEROS";
		public const string CUENTA_DESTINO_TERCEROSColumnName = "CUENTA_DESTINO_TERCEROS";
		public const string CTACTE_BANC_TERCEROS_ORIGEN_IDColumnName = "CTACTE_BANC_TERCEROS_ORIGEN_ID";
		public const string CTACTE_BANC_TERCEROS_DEST_IDColumnName = "CTACTE_BANC_TERCEROS_DEST_ID";
		public const string SUCURSAL_ORIGEN_IDColumnName = "SUCURSAL_ORIGEN_ID";
		public const string CTACTE_BANCO_ORIGEN_IDColumnName = "CTACTE_BANCO_ORIGEN_ID";
		public const string CTACTE_BANCARIA_ORIGEN_IDColumnName = "CTACTE_BANCARIA_ORIGEN_ID";
		public const string NUMERO_CUENTA_ORIGENColumnName = "NUMERO_CUENTA_ORIGEN";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string COSTO_TRANSFERENCIAColumnName = "COSTO_TRANSFERENCIA";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string CTACTE_BANCO_DESTINO_IDColumnName = "CTACTE_BANCO_DESTINO_ID";
		public const string CTACTE_BANCARIA_DESTINO_IDColumnName = "CTACTE_BANCARIA_DESTINO_ID";
		public const string NUMERO_CUENTA_DESTINOColumnName = "NUMERO_CUENTA_DESTINO";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string COTIZACION_MONEDA_DESTINOColumnName = "COTIZACION_MONEDA_DESTINO";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string NUMERO_TRANSACCIONColumnName = "NUMERO_TRANSACCION";
		public const string NRO_SOLICITUDColumnName = "NRO_SOLICITUD";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string CG_AUTONUMERACION_IDColumnName = "CG_AUTONUMERACION_ID";
		public const string CG_NUMERO_CHEQUEColumnName = "CG_NUMERO_CHEQUE";
		public const string CG_FECHA_EMISIONColumnName = "CG_FECHA_EMISION";
		public const string CG_FECHA_VENCIMIENTOColumnName = "CG_FECHA_VENCIMIENTO";
		public const string CG_NOMBRE_EMISORColumnName = "CG_NOMBRE_EMISOR";
		public const string CG_NOMBRE_BENEFICIARIOColumnName = "CG_NOMBRE_BENEFICIARIO";
		public const string CG_USAR_CHEQUERAColumnName = "CG_USAR_CHEQUERA";
		public const string CG_CHEQUE_GIRADO_IDColumnName = "CG_CHEQUE_GIRADO_ID";
		public const string CG_ES_DIFERIDOColumnName = "CG_ES_DIFERIDO";
		public const string ES_COTIZACION_DIRECTAColumnName = "ES_COTIZACION_DIRECTA";
		public const string MONEDA_COT_DIRECTA_IDColumnName = "MONEDA_COT_DIRECTA_ID";
		public const string CREAR_ANTICIPO_PERSONAColumnName = "CREAR_ANTICIPO_PERSONA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSFERENCIAS_BANCARIASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRANSFERENCIAS_BANCARIASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRANSFERENCIAS_BANCARIAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRANSFERENCIAS_BANCARIAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRANSFERENCIAS_BANCARIAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRANSFERENCIAS_BANCARIASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRANSFERENCIAS_BANCARIASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRANSFERENCIAS_BANCARIASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects that 
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRANSFERENCIAS_BANCARIAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRANSFERENCIAS_BANCARIASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRANSFERENCIAS_BANCARIASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TRANSFERENCIAS_BANCARIASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetByCG_CHEQUE_GIRADO_ID(decimal cg_cheque_girado_id)
		{
			return GetByCG_CHEQUE_GIRADO_ID(cg_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_cheque_girado_idNull">true if the method ignores the cg_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCG_CHEQUE_GIRADO_ID(decimal cg_cheque_girado_id, bool cg_cheque_girado_idNull)
		{
			return MapRecords(CreateGetByCG_CHEQUE_GIRADO_IDCommand(cg_cheque_girado_id, cg_cheque_girado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_CHEQUE_GIRADO_IDAsDataTable(decimal cg_cheque_girado_id)
		{
			return GetByCG_CHEQUE_GIRADO_IDAsDataTable(cg_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_cheque_girado_idNull">true if the method ignores the cg_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCG_CHEQUE_GIRADO_IDAsDataTable(decimal cg_cheque_girado_id, bool cg_cheque_girado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCG_CHEQUE_GIRADO_IDCommand(cg_cheque_girado_id, cg_cheque_girado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_cheque_girado_idNull">true if the method ignores the cg_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCG_CHEQUE_GIRADO_IDCommand(decimal cg_cheque_girado_id, bool cg_cheque_girado_idNull)
		{
			string whereSql = "";
			if(cg_cheque_girado_idNull)
				whereSql += "CG_CHEQUE_GIRADO_ID IS NULL";
			else
				whereSql += "CG_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CG_CHEQUE_GIRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cg_cheque_girado_idNull)
				AddParameter(cmd, "CG_CHEQUE_GIRADO_ID", cg_cheque_girado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id)
		{
			return GetByCG_AUTONUMERACION_ID(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="cg_autonumeracion_idNull">true if the method ignores the cg_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id, bool cg_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByCG_AUTONUMERACION_IDCommand(cg_autonumeracion_id, cg_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_AUTONUMERACION_IDAsDataTable(decimal cg_autonumeracion_id)
		{
			return GetByCG_AUTONUMERACION_IDAsDataTable(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
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
		/// return records by the <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
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
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANC_TERCEROS_DEST_ID(decimal ctacte_banc_terceros_dest_id)
		{
			return GetByCTACTE_BANC_TERCEROS_DEST_ID(ctacte_banc_terceros_dest_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_dest_idNull">true if the method ignores the ctacte_banc_terceros_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANC_TERCEROS_DEST_ID(decimal ctacte_banc_terceros_dest_id, bool ctacte_banc_terceros_dest_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANC_TERCEROS_DEST_IDCommand(ctacte_banc_terceros_dest_id, ctacte_banc_terceros_dest_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANC_TERCEROS_DEST_IDAsDataTable(decimal ctacte_banc_terceros_dest_id)
		{
			return GetByCTACTE_BANC_TERCEROS_DEST_IDAsDataTable(ctacte_banc_terceros_dest_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_dest_idNull">true if the method ignores the ctacte_banc_terceros_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANC_TERCEROS_DEST_IDAsDataTable(decimal ctacte_banc_terceros_dest_id, bool ctacte_banc_terceros_dest_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANC_TERCEROS_DEST_IDCommand(ctacte_banc_terceros_dest_id, ctacte_banc_terceros_dest_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_dest_idNull">true if the method ignores the ctacte_banc_terceros_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANC_TERCEROS_DEST_IDCommand(decimal ctacte_banc_terceros_dest_id, bool ctacte_banc_terceros_dest_idNull)
		{
			string whereSql = "";
			if(ctacte_banc_terceros_dest_idNull)
				whereSql += "CTACTE_BANC_TERCEROS_DEST_ID IS NULL";
			else
				whereSql += "CTACTE_BANC_TERCEROS_DEST_ID=" + _db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_DEST_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_banc_terceros_dest_idNull)
				AddParameter(cmd, "CTACTE_BANC_TERCEROS_DEST_ID", ctacte_banc_terceros_dest_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANC_TERCEROS_ORIGEN_ID(decimal ctacte_banc_terceros_origen_id)
		{
			return GetByCTACTE_BANC_TERCEROS_ORIGEN_ID(ctacte_banc_terceros_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_origen_idNull">true if the method ignores the ctacte_banc_terceros_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANC_TERCEROS_ORIGEN_ID(decimal ctacte_banc_terceros_origen_id, bool ctacte_banc_terceros_origen_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANC_TERCEROS_ORIGEN_IDCommand(ctacte_banc_terceros_origen_id, ctacte_banc_terceros_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANC_TERCEROS_ORIGEN_IDAsDataTable(decimal ctacte_banc_terceros_origen_id)
		{
			return GetByCTACTE_BANC_TERCEROS_ORIGEN_IDAsDataTable(ctacte_banc_terceros_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_origen_idNull">true if the method ignores the ctacte_banc_terceros_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANC_TERCEROS_ORIGEN_IDAsDataTable(decimal ctacte_banc_terceros_origen_id, bool ctacte_banc_terceros_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANC_TERCEROS_ORIGEN_IDCommand(ctacte_banc_terceros_origen_id, ctacte_banc_terceros_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_origen_idNull">true if the method ignores the ctacte_banc_terceros_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANC_TERCEROS_ORIGEN_IDCommand(decimal ctacte_banc_terceros_origen_id, bool ctacte_banc_terceros_origen_idNull)
		{
			string whereSql = "";
			if(ctacte_banc_terceros_origen_idNull)
				whereSql += "CTACTE_BANC_TERCEROS_ORIGEN_ID IS NULL";
			else
				whereSql += "CTACTE_BANC_TERCEROS_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_banc_terceros_origen_idNull)
				AddParameter(cmd, "CTACTE_BANC_TERCEROS_ORIGEN_ID", ctacte_banc_terceros_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CTA_BANCARIA_CAS</c> foreign key.
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
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANCARIA_DESTINO_ID(decimal ctacte_bancaria_destino_id)
		{
			return GetByCTACTE_BANCARIA_DESTINO_ID(ctacte_bancaria_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_destino_idNull">true if the method ignores the ctacte_bancaria_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANCARIA_DESTINO_ID(decimal ctacte_bancaria_destino_id, bool ctacte_bancaria_destino_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_DESTINO_IDCommand(ctacte_bancaria_destino_id, ctacte_bancaria_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANCARIA_DESTINO_IDAsDataTable(decimal ctacte_bancaria_destino_id)
		{
			return GetByCTACTE_BANCARIA_DESTINO_IDAsDataTable(ctacte_bancaria_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_destino_idNull">true if the method ignores the ctacte_bancaria_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_DESTINO_IDAsDataTable(decimal ctacte_bancaria_destino_id, bool ctacte_bancaria_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_DESTINO_IDCommand(ctacte_bancaria_destino_id, ctacte_bancaria_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_destino_idNull">true if the method ignores the ctacte_bancaria_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_DESTINO_IDCommand(decimal ctacte_bancaria_destino_id, bool ctacte_bancaria_destino_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_destino_idNull)
				whereSql += "CTACTE_BANCARIA_DESTINO_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_bancaria_destino_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_DESTINO_ID", ctacte_bancaria_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANCARIA_ORIGEN_ID(decimal ctacte_bancaria_origen_id)
		{
			return GetByCTACTE_BANCARIA_ORIGEN_ID(ctacte_bancaria_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_origen_idNull">true if the method ignores the ctacte_bancaria_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANCARIA_ORIGEN_ID(decimal ctacte_bancaria_origen_id, bool ctacte_bancaria_origen_idNull)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_ORIGEN_IDCommand(ctacte_bancaria_origen_id, ctacte_bancaria_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_BANCARIA_ORIGEN_IDAsDataTable(decimal ctacte_bancaria_origen_id)
		{
			return GetByCTACTE_BANCARIA_ORIGEN_IDAsDataTable(ctacte_bancaria_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_origen_idNull">true if the method ignores the ctacte_bancaria_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_ORIGEN_IDAsDataTable(decimal ctacte_bancaria_origen_id, bool ctacte_bancaria_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_ORIGEN_IDCommand(ctacte_bancaria_origen_id, ctacte_bancaria_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_origen_idNull">true if the method ignores the ctacte_bancaria_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_ORIGEN_IDCommand(decimal ctacte_bancaria_origen_id, bool ctacte_bancaria_origen_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_origen_idNull)
				whereSql += "CTACTE_BANCARIA_ORIGEN_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_bancaria_origen_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_ORIGEN_ID", ctacte_bancaria_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANCO_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_destino_id">The <c>CTACTE_BANCO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANCO_DESTINO_ID(decimal ctacte_banco_destino_id)
		{
			return MapRecords(CreateGetByCTACTE_BANCO_DESTINO_IDCommand(ctacte_banco_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANCO_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_destino_id">The <c>CTACTE_BANCO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCO_DESTINO_IDAsDataTable(decimal ctacte_banco_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCO_DESTINO_IDCommand(ctacte_banco_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CTA_BANCO_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_destino_id">The <c>CTACTE_BANCO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCO_DESTINO_IDCommand(decimal ctacte_banco_destino_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCO_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_BANCO_DESTINO_ID", ctacte_banco_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_CTA_BANCO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_origen_id">The <c>CTACTE_BANCO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByCTACTE_BANCO_ORIGEN_ID(decimal ctacte_banco_origen_id)
		{
			return MapRecords(CreateGetByCTACTE_BANCO_ORIGEN_IDCommand(ctacte_banco_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_CTA_BANCO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_origen_id">The <c>CTACTE_BANCO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCO_ORIGEN_IDAsDataTable(decimal ctacte_banco_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCO_ORIGEN_IDCommand(ctacte_banco_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_CTA_BANCO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_origen_id">The <c>CTACTE_BANCO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCO_ORIGEN_IDCommand(decimal ctacte_banco_origen_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCO_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_BANCO_ORIGEN_ID", ctacte_banco_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_MONEDA_DES</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByMONEDA_DESTINO_ID(decimal moneda_destino_id)
		{
			return MapRecords(CreateGetByMONEDA_DESTINO_IDCommand(moneda_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_MONEDA_DES</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_DESTINO_IDAsDataTable(decimal moneda_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_DESTINO_IDCommand(moneda_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_MONEDA_DES</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_DESTINO_IDCommand(decimal moneda_destino_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_DESTINO_ID", moneda_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_MONEDA_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_MONEDA_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_MONEDA_OR</c> foreign key.
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
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_IDAsDataTable(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			string whereSql = "";
			if(sucursal_destino_idNull)
				whereSql += "SUCURSAL_DESTINO_ID IS NULL";
			else
				whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_destino_idNull)
				AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return GetBySUCURSAL_ORIGEN_ID(sucursal_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <param name="sucursal_origen_idNull">true if the method ignores the sucursal_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id, bool sucursal_origen_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id, sucursal_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_ORIGEN_IDAsDataTable(decimal sucursal_origen_id)
		{
			return GetBySUCURSAL_ORIGEN_IDAsDataTable(sucursal_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <param name="sucursal_origen_idNull">true if the method ignores the sucursal_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_ORIGEN_IDAsDataTable(decimal sucursal_origen_id, bool sucursal_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id, sucursal_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <param name="sucursal_origen_idNull">true if the method ignores the sucursal_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_ORIGEN_IDCommand(decimal sucursal_origen_id, bool sucursal_origen_idNull)
		{
			string whereSql = "";
			if(sucursal_origen_idNull)
				whereSql += "SUCURSAL_ORIGEN_ID IS NULL";
			else
				whereSql += "SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_origen_idNull)
				AddParameter(cmd, "SUCURSAL_ORIGEN_ID", sucursal_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public TRANSFERENCIAS_BANCARIASRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects 
		/// by the <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		public virtual TRANSFERENCIAS_BANCARIASRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
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
		/// return records by the <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
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
		/// Adds a new record into the <c>TRANSFERENCIAS_BANCARIAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSFERENCIAS_BANCARIASRow"/> object to be inserted.</param>
		public virtual void Insert(TRANSFERENCIAS_BANCARIASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRANSFERENCIAS_BANCARIAS (" +
				"ID, " +
				"CASO_ID, " +
				"FECHA, " +
				"CUENTA_ORIGEN_ADMINISTRADA, " +
				"CUENTA_DESTINO_ADMINISTRADA, " +
				"CUENTA_ORIGEN_TERCEROS, " +
				"CUENTA_DESTINO_TERCEROS, " +
				"CTACTE_BANC_TERCEROS_ORIGEN_ID, " +
				"CTACTE_BANC_TERCEROS_DEST_ID, " +
				"SUCURSAL_ORIGEN_ID, " +
				"CTACTE_BANCO_ORIGEN_ID, " +
				"CTACTE_BANCARIA_ORIGEN_ID, " +
				"NUMERO_CUENTA_ORIGEN, " +
				"MONEDA_ORIGEN_ID, " +
				"COTIZACION_MONEDA_ORIGEN, " +
				"MONTO_ORIGEN, " +
				"COSTO_TRANSFERENCIA, " +
				"SUCURSAL_DESTINO_ID, " +
				"CTACTE_BANCO_DESTINO_ID, " +
				"CTACTE_BANCARIA_DESTINO_ID, " +
				"NUMERO_CUENTA_DESTINO, " +
				"MONEDA_DESTINO_ID, " +
				"COTIZACION_MONEDA_DESTINO, " +
				"MONTO_DESTINO, " +
				"NUMERO_TRANSACCION, " +
				"NRO_SOLICITUD, " +
				"OBSERVACION, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"CG_AUTONUMERACION_ID, " +
				"CG_NUMERO_CHEQUE, " +
				"CG_FECHA_EMISION, " +
				"CG_FECHA_VENCIMIENTO, " +
				"CG_NOMBRE_EMISOR, " +
				"CG_NOMBRE_BENEFICIARIO, " +
				"CG_USAR_CHEQUERA, " +
				"CG_CHEQUE_GIRADO_ID, " +
				"CG_ES_DIFERIDO, " +
				"ES_COTIZACION_DIRECTA, " +
				"MONEDA_COT_DIRECTA_ID, " +
				"CREAR_ANTICIPO_PERSONA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CUENTA_ORIGEN_ADMINISTRADA") + ", " +
				_db.CreateSqlParameterName("CUENTA_DESTINO_ADMINISTRADA") + ", " +
				_db.CreateSqlParameterName("CUENTA_ORIGEN_TERCEROS") + ", " +
				_db.CreateSqlParameterName("CUENTA_DESTINO_TERCEROS") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_DEST_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_CUENTA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("COSTO_TRANSFERENCIA") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_CUENTA_DESTINO") + ", " +
				_db.CreateSqlParameterName("MONEDA_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_DESTINO") + ", " +
				_db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				_db.CreateSqlParameterName("NUMERO_TRANSACCION") + ", " +
				_db.CreateSqlParameterName("NRO_SOLICITUD") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("CG_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("CG_NUMERO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("CG_FECHA_EMISION") + ", " +
				_db.CreateSqlParameterName("CG_FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CG_NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("CG_NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("CG_USAR_CHEQUERA") + ", " +
				_db.CreateSqlParameterName("CG_CHEQUE_GIRADO_ID") + ", " +
				_db.CreateSqlParameterName("CG_ES_DIFERIDO") + ", " +
				_db.CreateSqlParameterName("ES_COTIZACION_DIRECTA") + ", " +
				_db.CreateSqlParameterName("MONEDA_COT_DIRECTA_ID") + ", " +
				_db.CreateSqlParameterName("CREAR_ANTICIPO_PERSONA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CUENTA_ORIGEN_ADMINISTRADA", value.CUENTA_ORIGEN_ADMINISTRADA);
			AddParameter(cmd, "CUENTA_DESTINO_ADMINISTRADA", value.CUENTA_DESTINO_ADMINISTRADA);
			AddParameter(cmd, "CUENTA_ORIGEN_TERCEROS", value.CUENTA_ORIGEN_TERCEROS);
			AddParameter(cmd, "CUENTA_DESTINO_TERCEROS", value.CUENTA_DESTINO_TERCEROS);
			AddParameter(cmd, "CTACTE_BANC_TERCEROS_ORIGEN_ID",
				value.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull ? DBNull.Value : (object)value.CTACTE_BANC_TERCEROS_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_BANC_TERCEROS_DEST_ID",
				value.IsCTACTE_BANC_TERCEROS_DEST_IDNull ? DBNull.Value : (object)value.CTACTE_BANC_TERCEROS_DEST_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID",
				value.IsSUCURSAL_ORIGEN_IDNull ? DBNull.Value : (object)value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_BANCO_ORIGEN_ID", value.CTACTE_BANCO_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_ORIGEN_ID",
				value.IsCTACTE_BANCARIA_ORIGEN_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_ORIGEN_ID);
			AddParameter(cmd, "NUMERO_CUENTA_ORIGEN", value.NUMERO_CUENTA_ORIGEN);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "COSTO_TRANSFERENCIA", value.COSTO_TRANSFERENCIA);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "CTACTE_BANCO_DESTINO_ID", value.CTACTE_BANCO_DESTINO_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_DESTINO_ID",
				value.IsCTACTE_BANCARIA_DESTINO_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_DESTINO_ID);
			AddParameter(cmd, "NUMERO_CUENTA_DESTINO", value.NUMERO_CUENTA_DESTINO);
			AddParameter(cmd, "MONEDA_DESTINO_ID", value.MONEDA_DESTINO_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_DESTINO", value.COTIZACION_MONEDA_DESTINO);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "NUMERO_TRANSACCION", value.NUMERO_TRANSACCION);
			AddParameter(cmd, "NRO_SOLICITUD", value.NRO_SOLICITUD);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CG_AUTONUMERACION_ID",
				value.IsCG_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.CG_AUTONUMERACION_ID);
			AddParameter(cmd, "CG_NUMERO_CHEQUE", value.CG_NUMERO_CHEQUE);
			AddParameter(cmd, "CG_FECHA_EMISION",
				value.IsCG_FECHA_EMISIONNull ? DBNull.Value : (object)value.CG_FECHA_EMISION);
			AddParameter(cmd, "CG_FECHA_VENCIMIENTO",
				value.IsCG_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CG_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CG_NOMBRE_EMISOR", value.CG_NOMBRE_EMISOR);
			AddParameter(cmd, "CG_NOMBRE_BENEFICIARIO", value.CG_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CG_USAR_CHEQUERA", value.CG_USAR_CHEQUERA);
			AddParameter(cmd, "CG_CHEQUE_GIRADO_ID",
				value.IsCG_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CG_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "CG_ES_DIFERIDO", value.CG_ES_DIFERIDO);
			AddParameter(cmd, "ES_COTIZACION_DIRECTA", value.ES_COTIZACION_DIRECTA);
			AddParameter(cmd, "MONEDA_COT_DIRECTA_ID",
				value.IsMONEDA_COT_DIRECTA_IDNull ? DBNull.Value : (object)value.MONEDA_COT_DIRECTA_ID);
			AddParameter(cmd, "CREAR_ANTICIPO_PERSONA", value.CREAR_ANTICIPO_PERSONA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRANSFERENCIAS_BANCARIAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSFERENCIAS_BANCARIASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRANSFERENCIAS_BANCARIASRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRANSFERENCIAS_BANCARIAS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CUENTA_ORIGEN_ADMINISTRADA=" + _db.CreateSqlParameterName("CUENTA_ORIGEN_ADMINISTRADA") + ", " +
				"CUENTA_DESTINO_ADMINISTRADA=" + _db.CreateSqlParameterName("CUENTA_DESTINO_ADMINISTRADA") + ", " +
				"CUENTA_ORIGEN_TERCEROS=" + _db.CreateSqlParameterName("CUENTA_ORIGEN_TERCEROS") + ", " +
				"CUENTA_DESTINO_TERCEROS=" + _db.CreateSqlParameterName("CUENTA_DESTINO_TERCEROS") + ", " +
				"CTACTE_BANC_TERCEROS_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_ORIGEN_ID") + ", " +
				"CTACTE_BANC_TERCEROS_DEST_ID=" + _db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_DEST_ID") + ", " +
				"SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID") + ", " +
				"CTACTE_BANCO_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ORIGEN_ID") + ", " +
				"CTACTE_BANCARIA_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ORIGEN_ID") + ", " +
				"NUMERO_CUENTA_ORIGEN=" + _db.CreateSqlParameterName("NUMERO_CUENTA_ORIGEN") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"COTIZACION_MONEDA_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				"MONTO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				"COSTO_TRANSFERENCIA=" + _db.CreateSqlParameterName("COSTO_TRANSFERENCIA") + ", " +
				"SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				"CTACTE_BANCO_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_DESTINO_ID") + ", " +
				"CTACTE_BANCARIA_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_DESTINO_ID") + ", " +
				"NUMERO_CUENTA_DESTINO=" + _db.CreateSqlParameterName("NUMERO_CUENTA_DESTINO") + ", " +
				"MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID") + ", " +
				"COTIZACION_MONEDA_DESTINO=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_DESTINO") + ", " +
				"MONTO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				"NUMERO_TRANSACCION=" + _db.CreateSqlParameterName("NUMERO_TRANSACCION") + ", " +
				"NRO_SOLICITUD=" + _db.CreateSqlParameterName("NRO_SOLICITUD") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"CG_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("CG_AUTONUMERACION_ID") + ", " +
				"CG_NUMERO_CHEQUE=" + _db.CreateSqlParameterName("CG_NUMERO_CHEQUE") + ", " +
				"CG_FECHA_EMISION=" + _db.CreateSqlParameterName("CG_FECHA_EMISION") + ", " +
				"CG_FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("CG_FECHA_VENCIMIENTO") + ", " +
				"CG_NOMBRE_EMISOR=" + _db.CreateSqlParameterName("CG_NOMBRE_EMISOR") + ", " +
				"CG_NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("CG_NOMBRE_BENEFICIARIO") + ", " +
				"CG_USAR_CHEQUERA=" + _db.CreateSqlParameterName("CG_USAR_CHEQUERA") + ", " +
				"CG_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CG_CHEQUE_GIRADO_ID") + ", " +
				"CG_ES_DIFERIDO=" + _db.CreateSqlParameterName("CG_ES_DIFERIDO") + ", " +
				"ES_COTIZACION_DIRECTA=" + _db.CreateSqlParameterName("ES_COTIZACION_DIRECTA") + ", " +
				"MONEDA_COT_DIRECTA_ID=" + _db.CreateSqlParameterName("MONEDA_COT_DIRECTA_ID") + ", " +
				"CREAR_ANTICIPO_PERSONA=" + _db.CreateSqlParameterName("CREAR_ANTICIPO_PERSONA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CUENTA_ORIGEN_ADMINISTRADA", value.CUENTA_ORIGEN_ADMINISTRADA);
			AddParameter(cmd, "CUENTA_DESTINO_ADMINISTRADA", value.CUENTA_DESTINO_ADMINISTRADA);
			AddParameter(cmd, "CUENTA_ORIGEN_TERCEROS", value.CUENTA_ORIGEN_TERCEROS);
			AddParameter(cmd, "CUENTA_DESTINO_TERCEROS", value.CUENTA_DESTINO_TERCEROS);
			AddParameter(cmd, "CTACTE_BANC_TERCEROS_ORIGEN_ID",
				value.IsCTACTE_BANC_TERCEROS_ORIGEN_IDNull ? DBNull.Value : (object)value.CTACTE_BANC_TERCEROS_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_BANC_TERCEROS_DEST_ID",
				value.IsCTACTE_BANC_TERCEROS_DEST_IDNull ? DBNull.Value : (object)value.CTACTE_BANC_TERCEROS_DEST_ID);
			AddParameter(cmd, "SUCURSAL_ORIGEN_ID",
				value.IsSUCURSAL_ORIGEN_IDNull ? DBNull.Value : (object)value.SUCURSAL_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_BANCO_ORIGEN_ID", value.CTACTE_BANCO_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_ORIGEN_ID",
				value.IsCTACTE_BANCARIA_ORIGEN_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_ORIGEN_ID);
			AddParameter(cmd, "NUMERO_CUENTA_ORIGEN", value.NUMERO_CUENTA_ORIGEN);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
			AddParameter(cmd, "COSTO_TRANSFERENCIA", value.COSTO_TRANSFERENCIA);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "CTACTE_BANCO_DESTINO_ID", value.CTACTE_BANCO_DESTINO_ID);
			AddParameter(cmd, "CTACTE_BANCARIA_DESTINO_ID",
				value.IsCTACTE_BANCARIA_DESTINO_IDNull ? DBNull.Value : (object)value.CTACTE_BANCARIA_DESTINO_ID);
			AddParameter(cmd, "NUMERO_CUENTA_DESTINO", value.NUMERO_CUENTA_DESTINO);
			AddParameter(cmd, "MONEDA_DESTINO_ID", value.MONEDA_DESTINO_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_DESTINO", value.COTIZACION_MONEDA_DESTINO);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "NUMERO_TRANSACCION", value.NUMERO_TRANSACCION);
			AddParameter(cmd, "NRO_SOLICITUD", value.NRO_SOLICITUD);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CG_AUTONUMERACION_ID",
				value.IsCG_AUTONUMERACION_IDNull ? DBNull.Value : (object)value.CG_AUTONUMERACION_ID);
			AddParameter(cmd, "CG_NUMERO_CHEQUE", value.CG_NUMERO_CHEQUE);
			AddParameter(cmd, "CG_FECHA_EMISION",
				value.IsCG_FECHA_EMISIONNull ? DBNull.Value : (object)value.CG_FECHA_EMISION);
			AddParameter(cmd, "CG_FECHA_VENCIMIENTO",
				value.IsCG_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CG_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CG_NOMBRE_EMISOR", value.CG_NOMBRE_EMISOR);
			AddParameter(cmd, "CG_NOMBRE_BENEFICIARIO", value.CG_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CG_USAR_CHEQUERA", value.CG_USAR_CHEQUERA);
			AddParameter(cmd, "CG_CHEQUE_GIRADO_ID",
				value.IsCG_CHEQUE_GIRADO_IDNull ? DBNull.Value : (object)value.CG_CHEQUE_GIRADO_ID);
			AddParameter(cmd, "CG_ES_DIFERIDO", value.CG_ES_DIFERIDO);
			AddParameter(cmd, "ES_COTIZACION_DIRECTA", value.ES_COTIZACION_DIRECTA);
			AddParameter(cmd, "MONEDA_COT_DIRECTA_ID",
				value.IsMONEDA_COT_DIRECTA_IDNull ? DBNull.Value : (object)value.MONEDA_COT_DIRECTA_ID);
			AddParameter(cmd, "CREAR_ANTICIPO_PERSONA", value.CREAR_ANTICIPO_PERSONA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRANSFERENCIAS_BANCARIAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRANSFERENCIAS_BANCARIAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TRANSFERENCIAS_BANCARIAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRANSFERENCIAS_BANCARIASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRANSFERENCIAS_BANCARIASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRANSFERENCIAS_BANCARIAS</c> table using
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
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CHEQUE_GIRADO_ID(decimal cg_cheque_girado_id)
		{
			return DeleteByCG_CHEQUE_GIRADO_ID(cg_cheque_girado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_cheque_girado_idNull">true if the method ignores the cg_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CHEQUE_GIRADO_ID(decimal cg_cheque_girado_id, bool cg_cheque_girado_idNull)
		{
			return CreateDeleteByCG_CHEQUE_GIRADO_IDCommand(cg_cheque_girado_id, cg_cheque_girado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CHEQUE_GIRADO_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_cheque_girado_id">The <c>CG_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_cheque_girado_idNull">true if the method ignores the cg_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCG_CHEQUE_GIRADO_IDCommand(decimal cg_cheque_girado_id, bool cg_cheque_girado_idNull)
		{
			string whereSql = "";
			if(cg_cheque_girado_idNull)
				whereSql += "CG_CHEQUE_GIRADO_ID IS NULL";
			else
				whereSql += "CG_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CG_CHEQUE_GIRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cg_cheque_girado_idNull)
				AddParameter(cmd, "CG_CHEQUE_GIRADO_ID", cg_cheque_girado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id)
		{
			return DeleteByCG_AUTONUMERACION_ID(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
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
		/// delete records using the <c>FK_TRANS_BANC_CHEQUERA_ID</c> foreign key.
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
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANC_TERCEROS_DEST_ID(decimal ctacte_banc_terceros_dest_id)
		{
			return DeleteByCTACTE_BANC_TERCEROS_DEST_ID(ctacte_banc_terceros_dest_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_dest_idNull">true if the method ignores the ctacte_banc_terceros_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANC_TERCEROS_DEST_ID(decimal ctacte_banc_terceros_dest_id, bool ctacte_banc_terceros_dest_idNull)
		{
			return CreateDeleteByCTACTE_BANC_TERCEROS_DEST_IDCommand(ctacte_banc_terceros_dest_id, ctacte_banc_terceros_dest_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CTA_BANC_TER_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_dest_id">The <c>CTACTE_BANC_TERCEROS_DEST_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_dest_idNull">true if the method ignores the ctacte_banc_terceros_dest_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANC_TERCEROS_DEST_IDCommand(decimal ctacte_banc_terceros_dest_id, bool ctacte_banc_terceros_dest_idNull)
		{
			string whereSql = "";
			if(ctacte_banc_terceros_dest_idNull)
				whereSql += "CTACTE_BANC_TERCEROS_DEST_ID IS NULL";
			else
				whereSql += "CTACTE_BANC_TERCEROS_DEST_ID=" + _db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_DEST_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_banc_terceros_dest_idNull)
				AddParameter(cmd, "CTACTE_BANC_TERCEROS_DEST_ID", ctacte_banc_terceros_dest_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANC_TERCEROS_ORIGEN_ID(decimal ctacte_banc_terceros_origen_id)
		{
			return DeleteByCTACTE_BANC_TERCEROS_ORIGEN_ID(ctacte_banc_terceros_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_origen_idNull">true if the method ignores the ctacte_banc_terceros_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANC_TERCEROS_ORIGEN_ID(decimal ctacte_banc_terceros_origen_id, bool ctacte_banc_terceros_origen_idNull)
		{
			return CreateDeleteByCTACTE_BANC_TERCEROS_ORIGEN_IDCommand(ctacte_banc_terceros_origen_id, ctacte_banc_terceros_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CTA_BANC_TER_ORG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banc_terceros_origen_id">The <c>CTACTE_BANC_TERCEROS_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_banc_terceros_origen_idNull">true if the method ignores the ctacte_banc_terceros_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANC_TERCEROS_ORIGEN_IDCommand(decimal ctacte_banc_terceros_origen_id, bool ctacte_banc_terceros_origen_idNull)
		{
			string whereSql = "";
			if(ctacte_banc_terceros_origen_idNull)
				whereSql += "CTACTE_BANC_TERCEROS_ORIGEN_ID IS NULL";
			else
				whereSql += "CTACTE_BANC_TERCEROS_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANC_TERCEROS_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_banc_terceros_origen_idNull)
				AddParameter(cmd, "CTACTE_BANC_TERCEROS_ORIGEN_ID", ctacte_banc_terceros_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANCARIA_CAS</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CTA_BANCARIA_CAS</c> foreign key.
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
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_DESTINO_ID(decimal ctacte_bancaria_destino_id)
		{
			return DeleteByCTACTE_BANCARIA_DESTINO_ID(ctacte_bancaria_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_destino_idNull">true if the method ignores the ctacte_bancaria_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_DESTINO_ID(decimal ctacte_bancaria_destino_id, bool ctacte_bancaria_destino_idNull)
		{
			return CreateDeleteByCTACTE_BANCARIA_DESTINO_IDCommand(ctacte_bancaria_destino_id, ctacte_bancaria_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CTA_BANCARIA_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_destino_id">The <c>CTACTE_BANCARIA_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_destino_idNull">true if the method ignores the ctacte_bancaria_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_DESTINO_IDCommand(decimal ctacte_bancaria_destino_id, bool ctacte_bancaria_destino_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_destino_idNull)
				whereSql += "CTACTE_BANCARIA_DESTINO_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_bancaria_destino_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_DESTINO_ID", ctacte_bancaria_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ORIGEN_ID(decimal ctacte_bancaria_origen_id)
		{
			return DeleteByCTACTE_BANCARIA_ORIGEN_ID(ctacte_bancaria_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_origen_idNull">true if the method ignores the ctacte_bancaria_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ORIGEN_ID(decimal ctacte_bancaria_origen_id, bool ctacte_bancaria_origen_idNull)
		{
			return CreateDeleteByCTACTE_BANCARIA_ORIGEN_IDCommand(ctacte_bancaria_origen_id, ctacte_bancaria_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CTA_BANCARIA_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_origen_id">The <c>CTACTE_BANCARIA_ORIGEN_ID</c> column value.</param>
		/// <param name="ctacte_bancaria_origen_idNull">true if the method ignores the ctacte_bancaria_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_ORIGEN_IDCommand(decimal ctacte_bancaria_origen_id, bool ctacte_bancaria_origen_idNull)
		{
			string whereSql = "";
			if(ctacte_bancaria_origen_idNull)
				whereSql += "CTACTE_BANCARIA_ORIGEN_ID IS NULL";
			else
				whereSql += "CTACTE_BANCARIA_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_bancaria_origen_idNull)
				AddParameter(cmd, "CTACTE_BANCARIA_ORIGEN_ID", ctacte_bancaria_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANCO_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_destino_id">The <c>CTACTE_BANCO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_DESTINO_ID(decimal ctacte_banco_destino_id)
		{
			return CreateDeleteByCTACTE_BANCO_DESTINO_IDCommand(ctacte_banco_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CTA_BANCO_DES</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_destino_id">The <c>CTACTE_BANCO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCO_DESTINO_IDCommand(decimal ctacte_banco_destino_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCO_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_BANCO_DESTINO_ID", ctacte_banco_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_CTA_BANCO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_origen_id">The <c>CTACTE_BANCO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCO_ORIGEN_ID(decimal ctacte_banco_origen_id)
		{
			return CreateDeleteByCTACTE_BANCO_ORIGEN_IDCommand(ctacte_banco_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_CTA_BANCO_OR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_banco_origen_id">The <c>CTACTE_BANCO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCO_ORIGEN_IDCommand(decimal ctacte_banco_origen_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCO_ORIGEN_ID=" + _db.CreateSqlParameterName("CTACTE_BANCO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_BANCO_ORIGEN_ID", ctacte_banco_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_MONEDA_DES</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_DESTINO_ID(decimal moneda_destino_id)
		{
			return CreateDeleteByMONEDA_DESTINO_IDCommand(moneda_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_MONEDA_DES</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_DESTINO_IDCommand(decimal moneda_destino_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_DESTINO_ID", moneda_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_MONEDA_OR</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_MONEDA_OR</c> foreign key.
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
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return DeleteBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return CreateDeleteBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_SUC_DESTINO</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			string whereSql = "";
			if(sucursal_destino_idNull)
				whereSql += "SUCURSAL_DESTINO_ID IS NULL";
			else
				whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_destino_idNull)
				AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id)
		{
			return DeleteBySUCURSAL_ORIGEN_ID(sucursal_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <param name="sucursal_origen_idNull">true if the method ignores the sucursal_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ORIGEN_ID(decimal sucursal_origen_id, bool sucursal_origen_idNull)
		{
			return CreateDeleteBySUCURSAL_ORIGEN_IDCommand(sucursal_origen_id, sucursal_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRANS_BANC_SUC_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="sucursal_origen_id">The <c>SUCURSAL_ORIGEN_ID</c> column value.</param>
		/// <param name="sucursal_origen_idNull">true if the method ignores the sucursal_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_ORIGEN_IDCommand(decimal sucursal_origen_id, bool sucursal_origen_idNull)
		{
			string whereSql = "";
			if(sucursal_origen_idNull)
				whereSql += "SUCURSAL_ORIGEN_ID IS NULL";
			else
				whereSql += "SUCURSAL_ORIGEN_ID=" + _db.CreateSqlParameterName("SUCURSAL_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_origen_idNull)
				AddParameter(cmd, "SUCURSAL_ORIGEN_ID", sucursal_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRANSFERENCIAS_BANCARIAS</c> table using the 
		/// <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
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
		/// delete records using the <c>FK_TRANS_BANC_TEXTO_PRED</c> foreign key.
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
		/// Deletes <c>TRANSFERENCIAS_BANCARIAS</c> records that match the specified criteria.
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
		/// to delete <c>TRANSFERENCIAS_BANCARIAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRANSFERENCIAS_BANCARIAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRANSFERENCIAS_BANCARIAS</c> table.
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		protected TRANSFERENCIAS_BANCARIASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		protected TRANSFERENCIAS_BANCARIASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRANSFERENCIAS_BANCARIASRow"/> objects.</returns>
		protected virtual TRANSFERENCIAS_BANCARIASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int cuenta_origen_administradaColumnIndex = reader.GetOrdinal("CUENTA_ORIGEN_ADMINISTRADA");
			int cuenta_destino_administradaColumnIndex = reader.GetOrdinal("CUENTA_DESTINO_ADMINISTRADA");
			int cuenta_origen_tercerosColumnIndex = reader.GetOrdinal("CUENTA_ORIGEN_TERCEROS");
			int cuenta_destino_tercerosColumnIndex = reader.GetOrdinal("CUENTA_DESTINO_TERCEROS");
			int ctacte_banc_terceros_origen_idColumnIndex = reader.GetOrdinal("CTACTE_BANC_TERCEROS_ORIGEN_ID");
			int ctacte_banc_terceros_dest_idColumnIndex = reader.GetOrdinal("CTACTE_BANC_TERCEROS_DEST_ID");
			int sucursal_origen_idColumnIndex = reader.GetOrdinal("SUCURSAL_ORIGEN_ID");
			int ctacte_banco_origen_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ORIGEN_ID");
			int ctacte_bancaria_origen_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ORIGEN_ID");
			int numero_cuenta_origenColumnIndex = reader.GetOrdinal("NUMERO_CUENTA_ORIGEN");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int costo_transferenciaColumnIndex = reader.GetOrdinal("COSTO_TRANSFERENCIA");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int ctacte_banco_destino_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_DESTINO_ID");
			int ctacte_bancaria_destino_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_DESTINO_ID");
			int numero_cuenta_destinoColumnIndex = reader.GetOrdinal("NUMERO_CUENTA_DESTINO");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int cotizacion_moneda_destinoColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_DESTINO");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int numero_transaccionColumnIndex = reader.GetOrdinal("NUMERO_TRANSACCION");
			int nro_solicitudColumnIndex = reader.GetOrdinal("NRO_SOLICITUD");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int cg_autonumeracion_idColumnIndex = reader.GetOrdinal("CG_AUTONUMERACION_ID");
			int cg_numero_chequeColumnIndex = reader.GetOrdinal("CG_NUMERO_CHEQUE");
			int cg_fecha_emisionColumnIndex = reader.GetOrdinal("CG_FECHA_EMISION");
			int cg_fecha_vencimientoColumnIndex = reader.GetOrdinal("CG_FECHA_VENCIMIENTO");
			int cg_nombre_emisorColumnIndex = reader.GetOrdinal("CG_NOMBRE_EMISOR");
			int cg_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CG_NOMBRE_BENEFICIARIO");
			int cg_usar_chequeraColumnIndex = reader.GetOrdinal("CG_USAR_CHEQUERA");
			int cg_cheque_girado_idColumnIndex = reader.GetOrdinal("CG_CHEQUE_GIRADO_ID");
			int cg_es_diferidoColumnIndex = reader.GetOrdinal("CG_ES_DIFERIDO");
			int es_cotizacion_directaColumnIndex = reader.GetOrdinal("ES_COTIZACION_DIRECTA");
			int moneda_cot_directa_idColumnIndex = reader.GetOrdinal("MONEDA_COT_DIRECTA_ID");
			int crear_anticipo_personaColumnIndex = reader.GetOrdinal("CREAR_ANTICIPO_PERSONA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRANSFERENCIAS_BANCARIASRow record = new TRANSFERENCIAS_BANCARIASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.CUENTA_ORIGEN_ADMINISTRADA = Convert.ToString(reader.GetValue(cuenta_origen_administradaColumnIndex));
					record.CUENTA_DESTINO_ADMINISTRADA = Convert.ToString(reader.GetValue(cuenta_destino_administradaColumnIndex));
					record.CUENTA_ORIGEN_TERCEROS = Convert.ToString(reader.GetValue(cuenta_origen_tercerosColumnIndex));
					record.CUENTA_DESTINO_TERCEROS = Convert.ToString(reader.GetValue(cuenta_destino_tercerosColumnIndex));
					if(!reader.IsDBNull(ctacte_banc_terceros_origen_idColumnIndex))
						record.CTACTE_BANC_TERCEROS_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banc_terceros_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_banc_terceros_dest_idColumnIndex))
						record.CTACTE_BANC_TERCEROS_DEST_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banc_terceros_dest_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_origen_idColumnIndex))
						record.SUCURSAL_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_origen_idColumnIndex)), 9);
					record.CTACTE_BANCO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_bancaria_origen_idColumnIndex))
						record.CTACTE_BANCARIA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_origen_idColumnIndex)), 9);
					record.NUMERO_CUENTA_ORIGEN = Convert.ToString(reader.GetValue(numero_cuenta_origenColumnIndex));
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					record.COSTO_TRANSFERENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(costo_transferenciaColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_idColumnIndex))
						record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					record.CTACTE_BANCO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_bancaria_destino_idColumnIndex))
						record.CTACTE_BANCARIA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_destino_idColumnIndex)), 9);
					record.NUMERO_CUENTA_DESTINO = Convert.ToString(reader.GetValue(numero_cuenta_destinoColumnIndex));
					record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					record.COTIZACION_MONEDA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_destinoColumnIndex)), 9);
					record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(numero_transaccionColumnIndex))
						record.NUMERO_TRANSACCION = Convert.ToString(reader.GetValue(numero_transaccionColumnIndex));
					if(!reader.IsDBNull(nro_solicitudColumnIndex))
						record.NRO_SOLICITUD = Convert.ToString(reader.GetValue(nro_solicitudColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_autonumeracion_idColumnIndex))
						record.CG_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_numero_chequeColumnIndex))
						record.CG_NUMERO_CHEQUE = Convert.ToString(reader.GetValue(cg_numero_chequeColumnIndex));
					if(!reader.IsDBNull(cg_fecha_emisionColumnIndex))
						record.CG_FECHA_EMISION = Convert.ToDateTime(reader.GetValue(cg_fecha_emisionColumnIndex));
					if(!reader.IsDBNull(cg_fecha_vencimientoColumnIndex))
						record.CG_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(cg_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(cg_nombre_emisorColumnIndex))
						record.CG_NOMBRE_EMISOR = Convert.ToString(reader.GetValue(cg_nombre_emisorColumnIndex));
					if(!reader.IsDBNull(cg_nombre_beneficiarioColumnIndex))
						record.CG_NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(cg_nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cg_usar_chequeraColumnIndex))
						record.CG_USAR_CHEQUERA = Convert.ToString(reader.GetValue(cg_usar_chequeraColumnIndex));
					if(!reader.IsDBNull(cg_cheque_girado_idColumnIndex))
						record.CG_CHEQUE_GIRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_cheque_girado_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_es_diferidoColumnIndex))
						record.CG_ES_DIFERIDO = Convert.ToString(reader.GetValue(cg_es_diferidoColumnIndex));
					record.ES_COTIZACION_DIRECTA = Convert.ToString(reader.GetValue(es_cotizacion_directaColumnIndex));
					if(!reader.IsDBNull(moneda_cot_directa_idColumnIndex))
						record.MONEDA_COT_DIRECTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cot_directa_idColumnIndex)), 9);
					record.CREAR_ANTICIPO_PERSONA = Convert.ToString(reader.GetValue(crear_anticipo_personaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRANSFERENCIAS_BANCARIASRow[])(recordList.ToArray(typeof(TRANSFERENCIAS_BANCARIASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRANSFERENCIAS_BANCARIASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRANSFERENCIAS_BANCARIASRow"/> object.</returns>
		protected virtual TRANSFERENCIAS_BANCARIASRow MapRow(DataRow row)
		{
			TRANSFERENCIAS_BANCARIASRow mappedObject = new TRANSFERENCIAS_BANCARIASRow();
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
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CUENTA_ORIGEN_ADMINISTRADA"
			dataColumn = dataTable.Columns["CUENTA_ORIGEN_ADMINISTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_ORIGEN_ADMINISTRADA = (string)row[dataColumn];
			// Column "CUENTA_DESTINO_ADMINISTRADA"
			dataColumn = dataTable.Columns["CUENTA_DESTINO_ADMINISTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_DESTINO_ADMINISTRADA = (string)row[dataColumn];
			// Column "CUENTA_ORIGEN_TERCEROS"
			dataColumn = dataTable.Columns["CUENTA_ORIGEN_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_ORIGEN_TERCEROS = (string)row[dataColumn];
			// Column "CUENTA_DESTINO_TERCEROS"
			dataColumn = dataTable.Columns["CUENTA_DESTINO_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_DESTINO_TERCEROS = (string)row[dataColumn];
			// Column "CTACTE_BANC_TERCEROS_ORIGEN_ID"
			dataColumn = dataTable.Columns["CTACTE_BANC_TERCEROS_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANC_TERCEROS_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANC_TERCEROS_DEST_ID"
			dataColumn = dataTable.Columns["CTACTE_BANC_TERCEROS_DEST_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANC_TERCEROS_DEST_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ORIGEN_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ORIGEN_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CUENTA_ORIGEN"
			dataColumn = dataTable.Columns["NUMERO_CUENTA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA_ORIGEN = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "COSTO_TRANSFERENCIA"
			dataColumn = dataTable.Columns["COSTO_TRANSFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_TRANSFERENCIA = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_DESTINO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_DESTINO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CUENTA_DESTINO"
			dataColumn = dataTable.Columns["NUMERO_CUENTA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA_DESTINO = (string)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "NUMERO_TRANSACCION"
			dataColumn = dataTable.Columns["NUMERO_TRANSACCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_TRANSACCION = (string)row[dataColumn];
			// Column "NRO_SOLICITUD"
			dataColumn = dataTable.Columns["NRO_SOLICITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_SOLICITUD = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "CG_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["CG_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "CG_NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["CG_NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "CG_FECHA_EMISION"
			dataColumn = dataTable.Columns["CG_FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "CG_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CG_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CG_NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["CG_NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "CG_NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["CG_NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CG_USAR_CHEQUERA"
			dataColumn = dataTable.Columns["CG_USAR_CHEQUERA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_USAR_CHEQUERA = (string)row[dataColumn];
			// Column "CG_CHEQUE_GIRADO_ID"
			dataColumn = dataTable.Columns["CG_CHEQUE_GIRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_CHEQUE_GIRADO_ID = (decimal)row[dataColumn];
			// Column "CG_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CG_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_ES_DIFERIDO = (string)row[dataColumn];
			// Column "ES_COTIZACION_DIRECTA"
			dataColumn = dataTable.Columns["ES_COTIZACION_DIRECTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COTIZACION_DIRECTA = (string)row[dataColumn];
			// Column "MONEDA_COT_DIRECTA_ID"
			dataColumn = dataTable.Columns["MONEDA_COT_DIRECTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COT_DIRECTA_ID = (decimal)row[dataColumn];
			// Column "CREAR_ANTICIPO_PERSONA"
			dataColumn = dataTable.Columns["CREAR_ANTICIPO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREAR_ANTICIPO_PERSONA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRANSFERENCIAS_BANCARIAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRANSFERENCIAS_BANCARIAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUENTA_ORIGEN_ADMINISTRADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUENTA_DESTINO_ADMINISTRADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUENTA_ORIGEN_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUENTA_DESTINO_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANC_TERCEROS_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_BANC_TERCEROS_DEST_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA_ORIGEN", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_TRANSFERENCIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA_DESTINO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_TRANSACCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("NRO_SOLICITUD", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CG_FECHA_EMISION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CG_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CG_USAR_CHEQUERA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CG_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ES_COTIZACION_DIRECTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_COT_DIRECTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CREAR_ANTICIPO_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CUENTA_ORIGEN_ADMINISTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CUENTA_DESTINO_ADMINISTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CUENTA_ORIGEN_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CUENTA_DESTINO_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_BANC_TERCEROS_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANC_TERCEROS_DEST_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUENTA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_TRANSFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUENTA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_TRANSACCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_SOLICITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CG_NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CG_USAR_CHEQUERA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CG_CHEQUE_GIRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COTIZACION_DIRECTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONEDA_COT_DIRECTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREAR_ANTICIPO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRANSFERENCIAS_BANCARIASCollection_Base class
}  // End of namespace
