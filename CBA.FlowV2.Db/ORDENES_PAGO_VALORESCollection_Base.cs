// <fileinfo name="ORDENES_PAGO_VALORESCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_VALORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_PAGO_VALORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_VALORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string CG_CTACTE_BANCARIA_IDColumnName = "CG_CTACTE_BANCARIA_ID";
		public const string CG_AUTONUMERACION_IDColumnName = "CG_AUTONUMERACION_ID";
		public const string CG_USAR_AUTONUMColumnName = "CG_USAR_AUTONUM";
		public const string CG_NUMERO_CHEQUEColumnName = "CG_NUMERO_CHEQUE";
		public const string CG_NOMBRE_EMISORColumnName = "CG_NOMBRE_EMISOR";
		public const string CG_NOMBRE_BENEFICIARIOColumnName = "CG_NOMBRE_BENEFICIARIO";
		public const string CG_FECHA_EMISIONColumnName = "CG_FECHA_EMISION";
		public const string CG_FECHA_VENCIMIENTOColumnName = "CG_FECHA_VENCIMIENTO";
		public const string CG_CTACTE_CHEQUE_GIRADO_IDColumnName = "CG_CTACTE_CHEQUE_GIRADO_ID";
		public const string CR_CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CR_CTACTE_CHEQUE_RECIBIDO_ID";
		public const string TC_CTACTE_TARJETA_CREDITO_IDColumnName = "TC_CTACTE_TARJETA_CREDITO_ID";
		public const string TC_CUPONColumnName = "TC_CUPON";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TRANSFERENCIA_BANCARIA_IDColumnName = "TRANSFERENCIA_BANCARIA_ID";
		public const string ANTICIPO_PROVEEDOR_IDColumnName = "ANTICIPO_PROVEEDOR_ID";
		public const string NOTA_CREDITO_PROVEEDOR_IDColumnName = "NOTA_CREDITO_PROVEEDOR_ID";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string RETENCION_EMITIDA_IDColumnName = "RETENCION_EMITIDA_ID";
		public const string RETENCION_AUX_CASOSColumnName = "RETENCION_AUX_CASOS";
		public const string RETENCION_AUX_MONTOSColumnName = "RETENCION_AUX_MONTOS";
		public const string AJUSTE_BANCARIO_IDColumnName = "AJUSTE_BANCARIO_ID";
		public const string CG_ES_DIFERIDOColumnName = "CG_ES_DIFERIDO";
		public const string RETENCION_TIPO_IDColumnName = "RETENCION_TIPO_ID";
		public const string RETENCION_FECHAColumnName = "RETENCION_FECHA";
		public const string COTIZACION_MONEDA_DESTINOColumnName = "COTIZACION_MONEDA_DESTINO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string DEBITO_AUTOM_CTACTE_BANC_IDColumnName = "DEBITO_AUTOM_CTACTE_BANC_ID";
		public const string CG_NUMERO_CTA_BENEFICIARIOColumnName = "CG_NUMERO_CTA_BENEFICIARIO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_VALORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_PAGO_VALORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_PAGO_VALORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_PAGO_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_PAGO_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_PAGO_VALORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGO_VALORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_PAGO_VALORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_PAGO_VALORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_PAGO_VALORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ORDENES_PAGO_VALORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGO_VALORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ORDENES_PAGO_VALORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ORDENES_PAGO_VALORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id)
		{
			return GetByAJUSTE_BANCARIO_ID(ajuste_bancario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			return MapRecords(CreateGetByAJUSTE_BANCARIO_IDCommand(ajuste_bancario_id, ajuste_bancario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAJUSTE_BANCARIO_IDAsDataTable(decimal ajuste_bancario_id)
		{
			return GetByAJUSTE_BANCARIO_IDAsDataTable(ajuste_bancario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAJUSTE_BANCARIO_IDAsDataTable(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAJUSTE_BANCARIO_IDCommand(ajuste_bancario_id, ajuste_bancario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAJUSTE_BANCARIO_IDCommand(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			string whereSql = "";
			if(ajuste_bancario_idNull)
				whereSql += "AJUSTE_BANCARIO_ID IS NULL";
			else
				whereSql += "AJUSTE_BANCARIO_ID=" + _db.CreateSqlParameterName("AJUSTE_BANCARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ajuste_bancario_idNull)
				AddParameter(cmd, "AJUSTE_BANCARIO_ID", ajuste_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByANTICIPO_PROVEEDOR_ID(decimal anticipo_proveedor_id)
		{
			return GetByANTICIPO_PROVEEDOR_ID(anticipo_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="anticipo_proveedor_idNull">true if the method ignores the anticipo_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByANTICIPO_PROVEEDOR_ID(decimal anticipo_proveedor_id, bool anticipo_proveedor_idNull)
		{
			return MapRecords(CreateGetByANTICIPO_PROVEEDOR_IDCommand(anticipo_proveedor_id, anticipo_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByANTICIPO_PROVEEDOR_IDAsDataTable(decimal anticipo_proveedor_id)
		{
			return GetByANTICIPO_PROVEEDOR_IDAsDataTable(anticipo_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="anticipo_proveedor_idNull">true if the method ignores the anticipo_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByANTICIPO_PROVEEDOR_IDAsDataTable(decimal anticipo_proveedor_id, bool anticipo_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByANTICIPO_PROVEEDOR_IDCommand(anticipo_proveedor_id, anticipo_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="anticipo_proveedor_idNull">true if the method ignores the anticipo_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByANTICIPO_PROVEEDOR_IDCommand(decimal anticipo_proveedor_id, bool anticipo_proveedor_idNull)
		{
			string whereSql = "";
			if(anticipo_proveedor_idNull)
				whereSql += "ANTICIPO_PROVEEDOR_ID IS NULL";
			else
				whereSql += "ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!anticipo_proveedor_idNull)
				AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", anticipo_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByCG_CTACTE_CHEQUE_GIRADO_ID(decimal cg_ctacte_cheque_girado_id)
		{
			return GetByCG_CTACTE_CHEQUE_GIRADO_ID(cg_ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <param name="cg_ctacte_cheque_girado_idNull">true if the method ignores the cg_ctacte_cheque_girado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByCG_CTACTE_CHEQUE_GIRADO_ID(decimal cg_ctacte_cheque_girado_id, bool cg_ctacte_cheque_girado_idNull)
		{
			return MapRecords(CreateGetByCG_CTACTE_CHEQUE_GIRADO_IDCommand(cg_ctacte_cheque_girado_id, cg_ctacte_cheque_girado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_CTACTE_CHEQUE_GIRADO_IDAsDataTable(decimal cg_ctacte_cheque_girado_id)
		{
			return GetByCG_CTACTE_CHEQUE_GIRADO_IDAsDataTable(cg_ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id)
		{
			return GetByCG_AUTONUMERACION_ID(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <param name="cg_autonumeracion_idNull">true if the method ignores the cg_autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id, bool cg_autonumeracion_idNull)
		{
			return MapRecords(CreateGetByCG_AUTONUMERACION_IDCommand(cg_autonumeracion_id, cg_autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_AUTONUMERACION_IDAsDataTable(decimal cg_autonumeracion_id)
		{
			return GetByCG_AUTONUMERACION_IDAsDataTable(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByCG_CTACTE_BANCARIA_ID(decimal cg_ctacte_bancaria_id)
		{
			return GetByCG_CTACTE_BANCARIA_ID(cg_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <param name="cg_ctacte_bancaria_idNull">true if the method ignores the cg_ctacte_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByCG_CTACTE_BANCARIA_ID(decimal cg_ctacte_bancaria_id, bool cg_ctacte_bancaria_idNull)
		{
			return MapRecords(CreateGetByCG_CTACTE_BANCARIA_IDCommand(cg_ctacte_bancaria_id, cg_ctacte_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCG_CTACTE_BANCARIA_IDAsDataTable(decimal cg_ctacte_bancaria_id)
		{
			return GetByCG_CTACTE_BANCARIA_IDAsDataTable(cg_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByCR_CTACTE_CHEQUE_RECIBIDO_ID(decimal cr_ctacte_cheque_recibido_id)
		{
			return GetByCR_CTACTE_CHEQUE_RECIBIDO_ID(cr_ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="cr_ctacte_cheque_recibido_idNull">true if the method ignores the cr_ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByCR_CTACTE_CHEQUE_RECIBIDO_ID(decimal cr_ctacte_cheque_recibido_id, bool cr_ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCR_CTACTE_CHEQUE_RECIBIDO_IDCommand(cr_ctacte_cheque_recibido_id, cr_ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCR_CTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal cr_ctacte_cheque_recibido_id)
		{
			return GetByCR_CTACTE_CHEQUE_RECIBIDO_IDAsDataTable(cr_ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="cr_ctacte_cheque_recibido_idNull">true if the method ignores the cr_ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCR_CTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal cr_ctacte_cheque_recibido_id, bool cr_ctacte_cheque_recibido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCR_CTACTE_CHEQUE_RECIBIDO_IDCommand(cr_ctacte_cheque_recibido_id, cr_ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="cr_ctacte_cheque_recibido_idNull">true if the method ignores the cr_ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCR_CTACTE_CHEQUE_RECIBIDO_IDCommand(decimal cr_ctacte_cheque_recibido_id, bool cr_ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(cr_ctacte_cheque_recibido_idNull)
				whereSql += "CR_CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CR_CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CR_CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cr_ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CR_CTACTE_CHEQUE_RECIBIDO_ID", cr_ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByDEBITO_AUTOM_CTACTE_BANC_ID(decimal debito_autom_ctacte_banc_id)
		{
			return GetByDEBITO_AUTOM_CTACTE_BANC_ID(debito_autom_ctacte_banc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <param name="debito_autom_ctacte_banc_idNull">true if the method ignores the debito_autom_ctacte_banc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByDEBITO_AUTOM_CTACTE_BANC_ID(decimal debito_autom_ctacte_banc_id, bool debito_autom_ctacte_banc_idNull)
		{
			return MapRecords(CreateGetByDEBITO_AUTOM_CTACTE_BANC_IDCommand(debito_autom_ctacte_banc_id, debito_autom_ctacte_banc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEBITO_AUTOM_CTACTE_BANC_IDAsDataTable(decimal debito_autom_ctacte_banc_id)
		{
			return GetByDEBITO_AUTOM_CTACTE_BANC_IDAsDataTable(debito_autom_ctacte_banc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <param name="debito_autom_ctacte_banc_idNull">true if the method ignores the debito_autom_ctacte_banc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEBITO_AUTOM_CTACTE_BANC_IDAsDataTable(decimal debito_autom_ctacte_banc_id, bool debito_autom_ctacte_banc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEBITO_AUTOM_CTACTE_BANC_IDCommand(debito_autom_ctacte_banc_id, debito_autom_ctacte_banc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <param name="debito_autom_ctacte_banc_idNull">true if the method ignores the debito_autom_ctacte_banc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEBITO_AUTOM_CTACTE_BANC_IDCommand(decimal debito_autom_ctacte_banc_id, bool debito_autom_ctacte_banc_idNull)
		{
			string whereSql = "";
			if(debito_autom_ctacte_banc_idNull)
				whereSql += "DEBITO_AUTOM_CTACTE_BANC_ID IS NULL";
			else
				whereSql += "DEBITO_AUTOM_CTACTE_BANC_ID=" + _db.CreateSqlParameterName("DEBITO_AUTOM_CTACTE_BANC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!debito_autom_ctacte_banc_idNull)
				AddParameter(cmd, "DEBITO_AUTOM_CTACTE_BANC_ID", debito_autom_ctacte_banc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_MON</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByNOTA_CREDITO_PROVEEDOR_ID(decimal nota_credito_proveedor_id)
		{
			return GetByNOTA_CREDITO_PROVEEDOR_ID(nota_credito_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="nota_credito_proveedor_idNull">true if the method ignores the nota_credito_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByNOTA_CREDITO_PROVEEDOR_ID(decimal nota_credito_proveedor_id, bool nota_credito_proveedor_idNull)
		{
			return MapRecords(CreateGetByNOTA_CREDITO_PROVEEDOR_IDCommand(nota_credito_proveedor_id, nota_credito_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNOTA_CREDITO_PROVEEDOR_IDAsDataTable(decimal nota_credito_proveedor_id)
		{
			return GetByNOTA_CREDITO_PROVEEDOR_IDAsDataTable(nota_credito_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="nota_credito_proveedor_idNull">true if the method ignores the nota_credito_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNOTA_CREDITO_PROVEEDOR_IDAsDataTable(decimal nota_credito_proveedor_id, bool nota_credito_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNOTA_CREDITO_PROVEEDOR_IDCommand(nota_credito_proveedor_id, nota_credito_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="nota_credito_proveedor_idNull">true if the method ignores the nota_credito_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNOTA_CREDITO_PROVEEDOR_IDCommand(decimal nota_credito_proveedor_id, bool nota_credito_proveedor_idNull)
		{
			string whereSql = "";
			if(nota_credito_proveedor_idNull)
				whereSql += "NOTA_CREDITO_PROVEEDOR_ID IS NULL";
			else
				whereSql += "NOTA_CREDITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nota_credito_proveedor_idNull)
				AddParameter(cmd, "NOTA_CREDITO_PROVEEDOR_ID", nota_credito_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return MapRecords(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_IDCommand(decimal orden_pago_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByRETENCION_EMITIDA_ID(decimal retencion_emitida_id)
		{
			return GetByRETENCION_EMITIDA_ID(retencion_emitida_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <param name="retencion_emitida_idNull">true if the method ignores the retencion_emitida_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByRETENCION_EMITIDA_ID(decimal retencion_emitida_id, bool retencion_emitida_idNull)
		{
			return MapRecords(CreateGetByRETENCION_EMITIDA_IDCommand(retencion_emitida_id, retencion_emitida_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_EMITIDA_IDAsDataTable(decimal retencion_emitida_id)
		{
			return GetByRETENCION_EMITIDA_IDAsDataTable(retencion_emitida_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByRETENCION_TIPO_ID(decimal retencion_tipo_id)
		{
			return GetByRETENCION_TIPO_ID(retencion_tipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <param name="retencion_tipo_idNull">true if the method ignores the retencion_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByRETENCION_TIPO_ID(decimal retencion_tipo_id, bool retencion_tipo_idNull)
		{
			return MapRecords(CreateGetByRETENCION_TIPO_IDCommand(retencion_tipo_id, retencion_tipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_TIPO_IDAsDataTable(decimal retencion_tipo_id)
		{
			return GetByRETENCION_TIPO_IDAsDataTable(retencion_tipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
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
		/// return records by the <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
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
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByTC_CTACTE_TARJETA_CREDITO_ID(decimal tc_ctacte_tarjeta_credito_id)
		{
			return GetByTC_CTACTE_TARJETA_CREDITO_ID(tc_ctacte_tarjeta_credito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <param name="tc_ctacte_tarjeta_credito_idNull">true if the method ignores the tc_ctacte_tarjeta_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByTC_CTACTE_TARJETA_CREDITO_ID(decimal tc_ctacte_tarjeta_credito_id, bool tc_ctacte_tarjeta_credito_idNull)
		{
			return MapRecords(CreateGetByTC_CTACTE_TARJETA_CREDITO_IDCommand(tc_ctacte_tarjeta_credito_id, tc_ctacte_tarjeta_credito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTC_CTACTE_TARJETA_CREDITO_IDAsDataTable(decimal tc_ctacte_tarjeta_credito_id)
		{
			return GetByTC_CTACTE_TARJETA_CREDITO_IDAsDataTable(tc_ctacte_tarjeta_credito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <param name="tc_ctacte_tarjeta_credito_idNull">true if the method ignores the tc_ctacte_tarjeta_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTC_CTACTE_TARJETA_CREDITO_IDAsDataTable(decimal tc_ctacte_tarjeta_credito_id, bool tc_ctacte_tarjeta_credito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTC_CTACTE_TARJETA_CREDITO_IDCommand(tc_ctacte_tarjeta_credito_id, tc_ctacte_tarjeta_credito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <param name="tc_ctacte_tarjeta_credito_idNull">true if the method ignores the tc_ctacte_tarjeta_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTC_CTACTE_TARJETA_CREDITO_IDCommand(decimal tc_ctacte_tarjeta_credito_id, bool tc_ctacte_tarjeta_credito_idNull)
		{
			string whereSql = "";
			if(tc_ctacte_tarjeta_credito_idNull)
				whereSql += "TC_CTACTE_TARJETA_CREDITO_ID IS NULL";
			else
				whereSql += "TC_CTACTE_TARJETA_CREDITO_ID=" + _db.CreateSqlParameterName("TC_CTACTE_TARJETA_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tc_ctacte_tarjeta_credito_idNull)
				AddParameter(cmd, "TC_CTACTE_TARJETA_CREDITO_ID", tc_ctacte_tarjeta_credito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public ORDENES_PAGO_VALORESRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			string whereSql = "";
			if(transferencia_bancaria_idNull)
				whereSql += "TRANSFERENCIA_BANCARIA_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_bancaria_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID", transferencia_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_VALORESRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_V_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		public virtual ORDENES_PAGO_VALORESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_V_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_V_VALOR</c> foreign key.
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
		/// Adds a new record into the <c>ORDENES_PAGO_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGO_VALORESRow"/> object to be inserted.</param>
		public virtual void Insert(ORDENES_PAGO_VALORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ORDENES_PAGO_VALORES (" +
				"ID, " +
				"ORDEN_PAGO_ID, " +
				"CTACTE_VALOR_ID, " +
				"MONTO_ORIGEN, " +
				"CG_CTACTE_BANCARIA_ID, " +
				"CG_AUTONUMERACION_ID, " +
				"CG_USAR_AUTONUM, " +
				"CG_NUMERO_CHEQUE, " +
				"CG_NOMBRE_EMISOR, " +
				"CG_NOMBRE_BENEFICIARIO, " +
				"CG_FECHA_EMISION, " +
				"CG_FECHA_VENCIMIENTO, " +
				"CG_CTACTE_CHEQUE_GIRADO_ID, " +
				"CR_CTACTE_CHEQUE_RECIBIDO_ID, " +
				"TC_CTACTE_TARJETA_CREDITO_ID, " +
				"TC_CUPON, " +
				"OBSERVACION, " +
				"TRANSFERENCIA_BANCARIA_ID, " +
				"ANTICIPO_PROVEEDOR_ID, " +
				"NOTA_CREDITO_PROVEEDOR_ID, " +
				"MONEDA_ORIGEN_ID, " +
				"COTIZACION_MONEDA_ORIGEN, " +
				"MONTO_DESTINO, " +
				"RETENCION_EMITIDA_ID, " +
				"RETENCION_AUX_CASOS, " +
				"RETENCION_AUX_MONTOS, " +
				"AJUSTE_BANCARIO_ID, " +
				"CG_ES_DIFERIDO, " +
				"RETENCION_TIPO_ID, " +
				"RETENCION_FECHA, " +
				"COTIZACION_MONEDA_DESTINO, " +
				"NRO_COMPROBANTE, " +
				"DEBITO_AUTOM_CTACTE_BANC_ID, " +
				"CG_NUMERO_CTA_BENEFICIARIO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CG_CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("CG_AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("CG_USAR_AUTONUM") + ", " +
				_db.CreateSqlParameterName("CG_NUMERO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("CG_NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("CG_NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("CG_FECHA_EMISION") + ", " +
				_db.CreateSqlParameterName("CG_FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CG_CTACTE_CHEQUE_GIRADO_ID") + ", " +
				_db.CreateSqlParameterName("CR_CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("TC_CTACTE_TARJETA_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("TC_CUPON") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("NOTA_CREDITO_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				_db.CreateSqlParameterName("RETENCION_EMITIDA_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_AUX_CASOS") + ", " +
				_db.CreateSqlParameterName("RETENCION_AUX_MONTOS") + ", " +
				_db.CreateSqlParameterName("AJUSTE_BANCARIO_ID") + ", " +
				_db.CreateSqlParameterName("CG_ES_DIFERIDO") + ", " +
				_db.CreateSqlParameterName("RETENCION_TIPO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_FECHA") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_DESTINO") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("DEBITO_AUTOM_CTACTE_BANC_ID") + ", " +
				_db.CreateSqlParameterName("CG_NUMERO_CTA_BENEFICIARIO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ORDEN_PAGO_ID", value.ORDEN_PAGO_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
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
			AddParameter(cmd, "CR_CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CR_CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "TC_CTACTE_TARJETA_CREDITO_ID",
				value.IsTC_CTACTE_TARJETA_CREDITO_IDNull ? DBNull.Value : (object)value.TC_CTACTE_TARJETA_CREDITO_ID);
			AddParameter(cmd, "TC_CUPON", value.TC_CUPON);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID",
				value.IsANTICIPO_PROVEEDOR_IDNull ? DBNull.Value : (object)value.ANTICIPO_PROVEEDOR_ID);
			AddParameter(cmd, "NOTA_CREDITO_PROVEEDOR_ID",
				value.IsNOTA_CREDITO_PROVEEDOR_IDNull ? DBNull.Value : (object)value.NOTA_CREDITO_PROVEEDOR_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "RETENCION_EMITIDA_ID",
				value.IsRETENCION_EMITIDA_IDNull ? DBNull.Value : (object)value.RETENCION_EMITIDA_ID);
			AddParameter(cmd, "RETENCION_AUX_CASOS", value.RETENCION_AUX_CASOS);
			AddParameter(cmd, "RETENCION_AUX_MONTOS", value.RETENCION_AUX_MONTOS);
			AddParameter(cmd, "AJUSTE_BANCARIO_ID",
				value.IsAJUSTE_BANCARIO_IDNull ? DBNull.Value : (object)value.AJUSTE_BANCARIO_ID);
			AddParameter(cmd, "CG_ES_DIFERIDO", value.CG_ES_DIFERIDO);
			AddParameter(cmd, "RETENCION_TIPO_ID",
				value.IsRETENCION_TIPO_IDNull ? DBNull.Value : (object)value.RETENCION_TIPO_ID);
			AddParameter(cmd, "RETENCION_FECHA",
				value.IsRETENCION_FECHANull ? DBNull.Value : (object)value.RETENCION_FECHA);
			AddParameter(cmd, "COTIZACION_MONEDA_DESTINO", value.COTIZACION_MONEDA_DESTINO);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "DEBITO_AUTOM_CTACTE_BANC_ID",
				value.IsDEBITO_AUTOM_CTACTE_BANC_IDNull ? DBNull.Value : (object)value.DEBITO_AUTOM_CTACTE_BANC_ID);
			AddParameter(cmd, "CG_NUMERO_CTA_BENEFICIARIO", value.CG_NUMERO_CTA_BENEFICIARIO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ORDENES_PAGO_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGO_VALORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ORDENES_PAGO_VALORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.ORDENES_PAGO_VALORES SET " +
				"ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"MONTO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				"CG_CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CG_CTACTE_BANCARIA_ID") + ", " +
				"CG_AUTONUMERACION_ID=" + _db.CreateSqlParameterName("CG_AUTONUMERACION_ID") + ", " +
				"CG_USAR_AUTONUM=" + _db.CreateSqlParameterName("CG_USAR_AUTONUM") + ", " +
				"CG_NUMERO_CHEQUE=" + _db.CreateSqlParameterName("CG_NUMERO_CHEQUE") + ", " +
				"CG_NOMBRE_EMISOR=" + _db.CreateSqlParameterName("CG_NOMBRE_EMISOR") + ", " +
				"CG_NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("CG_NOMBRE_BENEFICIARIO") + ", " +
				"CG_FECHA_EMISION=" + _db.CreateSqlParameterName("CG_FECHA_EMISION") + ", " +
				"CG_FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("CG_FECHA_VENCIMIENTO") + ", " +
				"CG_CTACTE_CHEQUE_GIRADO_ID=" + _db.CreateSqlParameterName("CG_CTACTE_CHEQUE_GIRADO_ID") + ", " +
				"CR_CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CR_CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"TC_CTACTE_TARJETA_CREDITO_ID=" + _db.CreateSqlParameterName("TC_CTACTE_TARJETA_CREDITO_ID") + ", " +
				"TC_CUPON=" + _db.CreateSqlParameterName("TC_CUPON") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				"ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID") + ", " +
				"NOTA_CREDITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_PROVEEDOR_ID") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"COTIZACION_MONEDA_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				"MONTO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				"RETENCION_EMITIDA_ID=" + _db.CreateSqlParameterName("RETENCION_EMITIDA_ID") + ", " +
				"RETENCION_AUX_CASOS=" + _db.CreateSqlParameterName("RETENCION_AUX_CASOS") + ", " +
				"RETENCION_AUX_MONTOS=" + _db.CreateSqlParameterName("RETENCION_AUX_MONTOS") + ", " +
				"AJUSTE_BANCARIO_ID=" + _db.CreateSqlParameterName("AJUSTE_BANCARIO_ID") + ", " +
				"CG_ES_DIFERIDO=" + _db.CreateSqlParameterName("CG_ES_DIFERIDO") + ", " +
				"RETENCION_TIPO_ID=" + _db.CreateSqlParameterName("RETENCION_TIPO_ID") + ", " +
				"RETENCION_FECHA=" + _db.CreateSqlParameterName("RETENCION_FECHA") + ", " +
				"COTIZACION_MONEDA_DESTINO=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_DESTINO") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"DEBITO_AUTOM_CTACTE_BANC_ID=" + _db.CreateSqlParameterName("DEBITO_AUTOM_CTACTE_BANC_ID") + ", " +
				"CG_NUMERO_CTA_BENEFICIARIO=" + _db.CreateSqlParameterName("CG_NUMERO_CTA_BENEFICIARIO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ORDEN_PAGO_ID", value.ORDEN_PAGO_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONTO_ORIGEN", value.MONTO_ORIGEN);
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
			AddParameter(cmd, "CR_CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCR_CTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CR_CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "TC_CTACTE_TARJETA_CREDITO_ID",
				value.IsTC_CTACTE_TARJETA_CREDITO_IDNull ? DBNull.Value : (object)value.TC_CTACTE_TARJETA_CREDITO_ID);
			AddParameter(cmd, "TC_CUPON", value.TC_CUPON);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID",
				value.IsANTICIPO_PROVEEDOR_IDNull ? DBNull.Value : (object)value.ANTICIPO_PROVEEDOR_ID);
			AddParameter(cmd, "NOTA_CREDITO_PROVEEDOR_ID",
				value.IsNOTA_CREDITO_PROVEEDOR_IDNull ? DBNull.Value : (object)value.NOTA_CREDITO_PROVEEDOR_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID", value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN", value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO", value.MONTO_DESTINO);
			AddParameter(cmd, "RETENCION_EMITIDA_ID",
				value.IsRETENCION_EMITIDA_IDNull ? DBNull.Value : (object)value.RETENCION_EMITIDA_ID);
			AddParameter(cmd, "RETENCION_AUX_CASOS", value.RETENCION_AUX_CASOS);
			AddParameter(cmd, "RETENCION_AUX_MONTOS", value.RETENCION_AUX_MONTOS);
			AddParameter(cmd, "AJUSTE_BANCARIO_ID",
				value.IsAJUSTE_BANCARIO_IDNull ? DBNull.Value : (object)value.AJUSTE_BANCARIO_ID);
			AddParameter(cmd, "CG_ES_DIFERIDO", value.CG_ES_DIFERIDO);
			AddParameter(cmd, "RETENCION_TIPO_ID",
				value.IsRETENCION_TIPO_IDNull ? DBNull.Value : (object)value.RETENCION_TIPO_ID);
			AddParameter(cmd, "RETENCION_FECHA",
				value.IsRETENCION_FECHANull ? DBNull.Value : (object)value.RETENCION_FECHA);
			AddParameter(cmd, "COTIZACION_MONEDA_DESTINO", value.COTIZACION_MONEDA_DESTINO);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "DEBITO_AUTOM_CTACTE_BANC_ID",
				value.IsDEBITO_AUTOM_CTACTE_BANC_IDNull ? DBNull.Value : (object)value.DEBITO_AUTOM_CTACTE_BANC_ID);
			AddParameter(cmd, "CG_NUMERO_CTA_BENEFICIARIO", value.CG_NUMERO_CTA_BENEFICIARIO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ORDENES_PAGO_VALORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ORDENES_PAGO_VALORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ORDENES_PAGO_VALORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGO_VALORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ORDENES_PAGO_VALORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ORDENES_PAGO_VALORES</c> table using
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
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id)
		{
			return DeleteByAJUSTE_BANCARIO_ID(ajuste_bancario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAJUSTE_BANCARIO_ID(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			return CreateDeleteByAJUSTE_BANCARIO_IDCommand(ajuste_bancario_id, ajuste_bancario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_AJUSTE_BANC</c> foreign key.
		/// </summary>
		/// <param name="ajuste_bancario_id">The <c>AJUSTE_BANCARIO_ID</c> column value.</param>
		/// <param name="ajuste_bancario_idNull">true if the method ignores the ajuste_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAJUSTE_BANCARIO_IDCommand(decimal ajuste_bancario_id, bool ajuste_bancario_idNull)
		{
			string whereSql = "";
			if(ajuste_bancario_idNull)
				whereSql += "AJUSTE_BANCARIO_ID IS NULL";
			else
				whereSql += "AJUSTE_BANCARIO_ID=" + _db.CreateSqlParameterName("AJUSTE_BANCARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ajuste_bancario_idNull)
				AddParameter(cmd, "AJUSTE_BANCARIO_ID", ajuste_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_PROVEEDOR_ID(decimal anticipo_proveedor_id)
		{
			return DeleteByANTICIPO_PROVEEDOR_ID(anticipo_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="anticipo_proveedor_idNull">true if the method ignores the anticipo_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_PROVEEDOR_ID(decimal anticipo_proveedor_id, bool anticipo_proveedor_idNull)
		{
			return CreateDeleteByANTICIPO_PROVEEDOR_IDCommand(anticipo_proveedor_id, anticipo_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_ANTICIP_PROV</c> foreign key.
		/// </summary>
		/// <param name="anticipo_proveedor_id">The <c>ANTICIPO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="anticipo_proveedor_idNull">true if the method ignores the anticipo_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByANTICIPO_PROVEEDOR_IDCommand(decimal anticipo_proveedor_id, bool anticipo_proveedor_idNull)
		{
			string whereSql = "";
			if(anticipo_proveedor_idNull)
				whereSql += "ANTICIPO_PROVEEDOR_ID IS NULL";
			else
				whereSql += "ANTICIPO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("ANTICIPO_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!anticipo_proveedor_idNull)
				AddParameter(cmd, "ANTICIPO_PROVEEDOR_ID", anticipo_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_cheque_girado_id">The <c>CG_CTACTE_CHEQUE_GIRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CTACTE_CHEQUE_GIRADO_ID(decimal cg_ctacte_cheque_girado_id)
		{
			return DeleteByCG_CTACTE_CHEQUE_GIRADO_ID(cg_ctacte_cheque_girado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_PAGO_V_CG</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="cg_autonumeracion_id">The <c>CG_AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_AUTONUMERACION_ID(decimal cg_autonumeracion_id)
		{
			return DeleteByCG_AUTONUMERACION_ID(cg_autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_PAGO_V_CG_AUTONUM</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
		/// </summary>
		/// <param name="cg_ctacte_bancaria_id">The <c>CG_CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCG_CTACTE_BANCARIA_ID(decimal cg_ctacte_bancaria_id)
		{
			return DeleteByCG_CTACTE_BANCARIA_ID(cg_ctacte_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_PAGO_V_CG_BCARIA</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCR_CTACTE_CHEQUE_RECIBIDO_ID(decimal cr_ctacte_cheque_recibido_id)
		{
			return DeleteByCR_CTACTE_CHEQUE_RECIBIDO_ID(cr_ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="cr_ctacte_cheque_recibido_idNull">true if the method ignores the cr_ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCR_CTACTE_CHEQUE_RECIBIDO_ID(decimal cr_ctacte_cheque_recibido_id, bool cr_ctacte_cheque_recibido_idNull)
		{
			return CreateDeleteByCR_CTACTE_CHEQUE_RECIBIDO_IDCommand(cr_ctacte_cheque_recibido_id, cr_ctacte_cheque_recibido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_CR</c> foreign key.
		/// </summary>
		/// <param name="cr_ctacte_cheque_recibido_id">The <c>CR_CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="cr_ctacte_cheque_recibido_idNull">true if the method ignores the cr_ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCR_CTACTE_CHEQUE_RECIBIDO_IDCommand(decimal cr_ctacte_cheque_recibido_id, bool cr_ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(cr_ctacte_cheque_recibido_idNull)
				whereSql += "CR_CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CR_CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CR_CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cr_ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CR_CTACTE_CHEQUE_RECIBIDO_ID", cr_ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEBITO_AUTOM_CTACTE_BANC_ID(decimal debito_autom_ctacte_banc_id)
		{
			return DeleteByDEBITO_AUTOM_CTACTE_BANC_ID(debito_autom_ctacte_banc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <param name="debito_autom_ctacte_banc_idNull">true if the method ignores the debito_autom_ctacte_banc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEBITO_AUTOM_CTACTE_BANC_ID(decimal debito_autom_ctacte_banc_id, bool debito_autom_ctacte_banc_idNull)
		{
			return CreateDeleteByDEBITO_AUTOM_CTACTE_BANC_IDCommand(debito_autom_ctacte_banc_id, debito_autom_ctacte_banc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_DEB_AUTO_CTA</c> foreign key.
		/// </summary>
		/// <param name="debito_autom_ctacte_banc_id">The <c>DEBITO_AUTOM_CTACTE_BANC_ID</c> column value.</param>
		/// <param name="debito_autom_ctacte_banc_idNull">true if the method ignores the debito_autom_ctacte_banc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEBITO_AUTOM_CTACTE_BANC_IDCommand(decimal debito_autom_ctacte_banc_id, bool debito_autom_ctacte_banc_idNull)
		{
			string whereSql = "";
			if(debito_autom_ctacte_banc_idNull)
				whereSql += "DEBITO_AUTOM_CTACTE_BANC_ID IS NULL";
			else
				whereSql += "DEBITO_AUTOM_CTACTE_BANC_ID=" + _db.CreateSqlParameterName("DEBITO_AUTOM_CTACTE_BANC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!debito_autom_ctacte_banc_idNull)
				AddParameter(cmd, "DEBITO_AUTOM_CTACTE_BANC_ID", debito_autom_ctacte_banc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_MON</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_CREDITO_PROVEEDOR_ID(decimal nota_credito_proveedor_id)
		{
			return DeleteByNOTA_CREDITO_PROVEEDOR_ID(nota_credito_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="nota_credito_proveedor_idNull">true if the method ignores the nota_credito_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_CREDITO_PROVEEDOR_ID(decimal nota_credito_proveedor_id, bool nota_credito_proveedor_idNull)
		{
			return CreateDeleteByNOTA_CREDITO_PROVEEDOR_IDCommand(nota_credito_proveedor_id, nota_credito_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_NC_PROV</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_proveedor_id">The <c>NOTA_CREDITO_PROVEEDOR_ID</c> column value.</param>
		/// <param name="nota_credito_proveedor_idNull">true if the method ignores the nota_credito_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNOTA_CREDITO_PROVEEDOR_IDCommand(decimal nota_credito_proveedor_id, bool nota_credito_proveedor_idNull)
		{
			string whereSql = "";
			if(nota_credito_proveedor_idNull)
				whereSql += "NOTA_CREDITO_PROVEEDOR_ID IS NULL";
			else
				whereSql += "NOTA_CREDITO_PROVEEDOR_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nota_credito_proveedor_idNull)
				AddParameter(cmd, "NOTA_CREDITO_PROVEEDOR_ID", nota_credito_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return CreateDeleteByORDEN_PAGO_IDCommand(orden_pago_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_IDCommand(decimal orden_pago_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
		/// </summary>
		/// <param name="retencion_emitida_id">The <c>RETENCION_EMITIDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_EMITIDA_ID(decimal retencion_emitida_id)
		{
			return DeleteByRETENCION_EMITIDA_ID(retencion_emitida_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_PAGO_V_RET_ID</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_TIPO_ID(decimal retencion_tipo_id)
		{
			return DeleteByRETENCION_TIPO_ID(retencion_tipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
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
		/// delete records using the <c>FK_ORDENES_PAGO_V_RET_TIPO</c> foreign key.
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
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTC_CTACTE_TARJETA_CREDITO_ID(decimal tc_ctacte_tarjeta_credito_id)
		{
			return DeleteByTC_CTACTE_TARJETA_CREDITO_ID(tc_ctacte_tarjeta_credito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <param name="tc_ctacte_tarjeta_credito_idNull">true if the method ignores the tc_ctacte_tarjeta_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTC_CTACTE_TARJETA_CREDITO_ID(decimal tc_ctacte_tarjeta_credito_id, bool tc_ctacte_tarjeta_credito_idNull)
		{
			return CreateDeleteByTC_CTACTE_TARJETA_CREDITO_IDCommand(tc_ctacte_tarjeta_credito_id, tc_ctacte_tarjeta_credito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_TC</c> foreign key.
		/// </summary>
		/// <param name="tc_ctacte_tarjeta_credito_id">The <c>TC_CTACTE_TARJETA_CREDITO_ID</c> column value.</param>
		/// <param name="tc_ctacte_tarjeta_credito_idNull">true if the method ignores the tc_ctacte_tarjeta_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTC_CTACTE_TARJETA_CREDITO_IDCommand(decimal tc_ctacte_tarjeta_credito_id, bool tc_ctacte_tarjeta_credito_idNull)
		{
			string whereSql = "";
			if(tc_ctacte_tarjeta_credito_idNull)
				whereSql += "TC_CTACTE_TARJETA_CREDITO_ID IS NULL";
			else
				whereSql += "TC_CTACTE_TARJETA_CREDITO_ID=" + _db.CreateSqlParameterName("TC_CTACTE_TARJETA_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tc_ctacte_tarjeta_credito_idNull)
				AddParameter(cmd, "TC_CTACTE_TARJETA_CREDITO_ID", tc_ctacte_tarjeta_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return DeleteByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_TRANSF_BANC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_BANCARIA_IDCommand(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			string whereSql = "";
			if(transferencia_bancaria_idNull)
				whereSql += "TRANSFERENCIA_BANCARIA_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_bancaria_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID", transferencia_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_VALORES</c> table using the 
		/// <c>FK_ORDENES_PAGO_V_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_V_VALOR</c> foreign key.
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
		/// Deletes <c>ORDENES_PAGO_VALORES</c> records that match the specified criteria.
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
		/// to delete <c>ORDENES_PAGO_VALORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ORDENES_PAGO_VALORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ORDENES_PAGO_VALORES</c> table.
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		protected ORDENES_PAGO_VALORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		protected ORDENES_PAGO_VALORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_VALORESRow"/> objects.</returns>
		protected virtual ORDENES_PAGO_VALORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int cg_ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CG_CTACTE_BANCARIA_ID");
			int cg_autonumeracion_idColumnIndex = reader.GetOrdinal("CG_AUTONUMERACION_ID");
			int cg_usar_autonumColumnIndex = reader.GetOrdinal("CG_USAR_AUTONUM");
			int cg_numero_chequeColumnIndex = reader.GetOrdinal("CG_NUMERO_CHEQUE");
			int cg_nombre_emisorColumnIndex = reader.GetOrdinal("CG_NOMBRE_EMISOR");
			int cg_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CG_NOMBRE_BENEFICIARIO");
			int cg_fecha_emisionColumnIndex = reader.GetOrdinal("CG_FECHA_EMISION");
			int cg_fecha_vencimientoColumnIndex = reader.GetOrdinal("CG_FECHA_VENCIMIENTO");
			int cg_ctacte_cheque_girado_idColumnIndex = reader.GetOrdinal("CG_CTACTE_CHEQUE_GIRADO_ID");
			int cr_ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CR_CTACTE_CHEQUE_RECIBIDO_ID");
			int tc_ctacte_tarjeta_credito_idColumnIndex = reader.GetOrdinal("TC_CTACTE_TARJETA_CREDITO_ID");
			int tc_cuponColumnIndex = reader.GetOrdinal("TC_CUPON");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int transferencia_bancaria_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BANCARIA_ID");
			int anticipo_proveedor_idColumnIndex = reader.GetOrdinal("ANTICIPO_PROVEEDOR_ID");
			int nota_credito_proveedor_idColumnIndex = reader.GetOrdinal("NOTA_CREDITO_PROVEEDOR_ID");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int retencion_emitida_idColumnIndex = reader.GetOrdinal("RETENCION_EMITIDA_ID");
			int retencion_aux_casosColumnIndex = reader.GetOrdinal("RETENCION_AUX_CASOS");
			int retencion_aux_montosColumnIndex = reader.GetOrdinal("RETENCION_AUX_MONTOS");
			int ajuste_bancario_idColumnIndex = reader.GetOrdinal("AJUSTE_BANCARIO_ID");
			int cg_es_diferidoColumnIndex = reader.GetOrdinal("CG_ES_DIFERIDO");
			int retencion_tipo_idColumnIndex = reader.GetOrdinal("RETENCION_TIPO_ID");
			int retencion_fechaColumnIndex = reader.GetOrdinal("RETENCION_FECHA");
			int cotizacion_moneda_destinoColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_DESTINO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int debito_autom_ctacte_banc_idColumnIndex = reader.GetOrdinal("DEBITO_AUTOM_CTACTE_BANC_ID");
			int cg_numero_cta_beneficiarioColumnIndex = reader.GetOrdinal("CG_NUMERO_CTA_BENEFICIARIO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_PAGO_VALORESRow record = new ORDENES_PAGO_VALORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cg_ctacte_bancaria_idColumnIndex))
						record.CG_CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_autonumeracion_idColumnIndex))
						record.CG_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cg_autonumeracion_idColumnIndex)), 9);
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
					if(!reader.IsDBNull(cr_ctacte_cheque_recibido_idColumnIndex))
						record.CR_CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cr_ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(tc_ctacte_tarjeta_credito_idColumnIndex))
						record.TC_CTACTE_TARJETA_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tc_ctacte_tarjeta_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(tc_cuponColumnIndex))
						record.TC_CUPON = Convert.ToString(reader.GetValue(tc_cuponColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(transferencia_bancaria_idColumnIndex))
						record.TRANSFERENCIA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_proveedor_idColumnIndex))
						record.ANTICIPO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(nota_credito_proveedor_idColumnIndex))
						record.NOTA_CREDITO_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_proveedor_idColumnIndex)), 9);
					record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_emitida_idColumnIndex))
						record.RETENCION_EMITIDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_emitida_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_aux_casosColumnIndex))
						record.RETENCION_AUX_CASOS = Convert.ToString(reader.GetValue(retencion_aux_casosColumnIndex));
					if(!reader.IsDBNull(retencion_aux_montosColumnIndex))
						record.RETENCION_AUX_MONTOS = Convert.ToString(reader.GetValue(retencion_aux_montosColumnIndex));
					if(!reader.IsDBNull(ajuste_bancario_idColumnIndex))
						record.AJUSTE_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ajuste_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_es_diferidoColumnIndex))
						record.CG_ES_DIFERIDO = Convert.ToString(reader.GetValue(cg_es_diferidoColumnIndex));
					if(!reader.IsDBNull(retencion_tipo_idColumnIndex))
						record.RETENCION_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_fechaColumnIndex))
						record.RETENCION_FECHA = Convert.ToDateTime(reader.GetValue(retencion_fechaColumnIndex));
					record.COTIZACION_MONEDA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(debito_autom_ctacte_banc_idColumnIndex))
						record.DEBITO_AUTOM_CTACTE_BANC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(debito_autom_ctacte_banc_idColumnIndex)), 9);
					if(!reader.IsDBNull(cg_numero_cta_beneficiarioColumnIndex))
						record.CG_NUMERO_CTA_BENEFICIARIO = Convert.ToString(reader.GetValue(cg_numero_cta_beneficiarioColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_PAGO_VALORESRow[])(recordList.ToArray(typeof(ORDENES_PAGO_VALORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_PAGO_VALORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_PAGO_VALORESRow"/> object.</returns>
		protected virtual ORDENES_PAGO_VALORESRow MapRow(DataRow row)
		{
			ORDENES_PAGO_VALORESRow mappedObject = new ORDENES_PAGO_VALORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
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
			// Column "CR_CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CR_CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CR_CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "TC_CTACTE_TARJETA_CREDITO_ID"
			dataColumn = dataTable.Columns["TC_CTACTE_TARJETA_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TC_CTACTE_TARJETA_CREDITO_ID = (decimal)row[dataColumn];
			// Column "TC_CUPON"
			dataColumn = dataTable.Columns["TC_CUPON"];
			if(!row.IsNull(dataColumn))
				mappedObject.TC_CUPON = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TRANSFERENCIA_BANCARIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "NOTA_CREDITO_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["NOTA_CREDITO_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
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
			// Column "AJUSTE_BANCARIO_ID"
			dataColumn = dataTable.Columns["AJUSTE_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AJUSTE_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "CG_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CG_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_ES_DIFERIDO = (string)row[dataColumn];
			// Column "RETENCION_TIPO_ID"
			dataColumn = dataTable.Columns["RETENCION_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_TIPO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_FECHA"
			dataColumn = dataTable.Columns["RETENCION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_FECHA = (System.DateTime)row[dataColumn];
			// Column "COTIZACION_MONEDA_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_DESTINO = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "DEBITO_AUTOM_CTACTE_BANC_ID"
			dataColumn = dataTable.Columns["DEBITO_AUTOM_CTACTE_BANC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO_AUTOM_CTACTE_BANC_ID = (decimal)row[dataColumn];
			// Column "CG_NUMERO_CTA_BENEFICIARIO"
			dataColumn = dataTable.Columns["CG_NUMERO_CTA_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CG_NUMERO_CTA_BENEFICIARIO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_PAGO_VALORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_PAGO_VALORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CG_CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_USAR_AUTONUM", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CG_NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CG_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CG_FECHA_EMISION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CG_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CG_CTACTE_CHEQUE_GIRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CR_CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TC_CTACTE_TARJETA_CREDITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TC_CUPON", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANTICIPO_PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RETENCION_EMITIDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_AUX_CASOS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("RETENCION_AUX_MONTOS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("AJUSTE_BANCARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("RETENCION_TIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DEBITO_AUTOM_CTACTE_BANC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CG_NUMERO_CTA_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
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

				case "CR_CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TC_CTACTE_TARJETA_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TC_CUPON":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSFERENCIA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_CREDITO_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
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

				case "AJUSTE_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RETENCION_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "COTIZACION_MONEDA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEBITO_AUTOM_CTACTE_BANC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CG_NUMERO_CTA_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_PAGO_VALORESCollection_Base class
}  // End of namespace
