// <fileinfo name="CTACTE_CAJAS_TESORERIA_MOVCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJAS_TESORERIA_MOVCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CAJAS_TESORERIA_MOVCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJAS_TESORERIA_MOVCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string FECHA_OPERACIONColumnName = "FECHA_OPERACION";
		public const string USUARIO_OPERACION_IDColumnName = "USUARIO_OPERACION_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string INGRESOColumnName = "INGRESO";
		public const string EGRESOColumnName = "EGRESO";
		public const string FECHA_INGRESOColumnName = "FECHA_INGRESO";
		public const string FECHA_EGRESOColumnName = "FECHA_EGRESO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string CTACTE_PROCESADORA_TARJETA_IDColumnName = "CTACTE_PROCESADORA_TARJETA_ID";
		public const string DEPOSITO_BANCARIO_DET_IDColumnName = "DEPOSITO_BANCARIO_DET_ID";
		public const string ORDEN_PAGO_VALOR_IDColumnName = "ORDEN_PAGO_VALOR_ID";
		public const string CAMBIO_DIVISA_DET_IDColumnName = "CAMBIO_DIVISA_DET_ID";
		public const string MOVIMIENTO_VARIO_DET_IDColumnName = "MOVIMIENTO_VARIO_DET_ID";
		public const string TRANSFERENCIA_DET_IDColumnName = "TRANSFERENCIA_DET_ID";
		public const string CUSTODIA_VALOR_DET_IDColumnName = "CUSTODIA_VALOR_DET_ID";
		public const string DESCUENTO_DOCUMENTO_PAGO_IDColumnName = "DESCUENTO_DOCUMENTO_PAGO_ID";
		public const string DESCUENTO_DOCUMENTO_DET_IDColumnName = "DESCUENTO_DOCUMENTO_DET_ID";
		public const string CANJE_VALOR_DET_IDColumnName = "CANJE_VALOR_DET_ID";
		public const string CANJE_VALOR_VAL_IDColumnName = "CANJE_VALOR_VAL_ID";
		public const string DESEMBOLSO_GIRO_IDColumnName = "DESEMBOLSO_GIRO_ID";
		public const string CUSTODIA_VALOR_DET_ENTRADA_IDColumnName = "CUSTODIA_VALOR_DET_ENTRADA_ID";
		public const string DESCUENTO_DOCUMENTO_CLI_DET_IDColumnName = "DESCUENTO_DOCUMENTO_CLI_DET_ID";
		public const string TRANSFERENCIA_CAJA_SUC_DET_IDColumnName = "TRANSFERENCIA_CAJA_SUC_DET_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJAS_TESORERIA_MOVCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CAJAS_TESORERIA_MOVCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CAJAS_TESORERIA_MOVRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CAJAS_TESORERIA_MOV";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_CAJAS_TESORERIA_MOVRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESCUENTO_DOCUMENTO_CLI_DET_ID(decimal descuento_documento_cli_det_id)
		{
			return GetByDESCUENTO_DOCUMENTO_CLI_DET_ID(descuento_documento_cli_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_cli_det_idNull">true if the method ignores the descuento_documento_cli_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESCUENTO_DOCUMENTO_CLI_DET_ID(decimal descuento_documento_cli_det_id, bool descuento_documento_cli_det_idNull)
		{
			return MapRecords(CreateGetByDESCUENTO_DOCUMENTO_CLI_DET_IDCommand(descuento_documento_cli_det_id, descuento_documento_cli_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCUENTO_DOCUMENTO_CLI_DET_IDAsDataTable(decimal descuento_documento_cli_det_id)
		{
			return GetByDESCUENTO_DOCUMENTO_CLI_DET_IDAsDataTable(descuento_documento_cli_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_cli_det_idNull">true if the method ignores the descuento_documento_cli_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_DOCUMENTO_CLI_DET_IDAsDataTable(decimal descuento_documento_cli_det_id, bool descuento_documento_cli_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_DOCUMENTO_CLI_DET_IDCommand(descuento_documento_cli_det_id, descuento_documento_cli_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_cli_det_idNull">true if the method ignores the descuento_documento_cli_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_DOCUMENTO_CLI_DET_IDCommand(decimal descuento_documento_cli_det_id, bool descuento_documento_cli_det_idNull)
		{
			string whereSql = "";
			if(descuento_documento_cli_det_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_CLI_DET_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_CLI_DET_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_CLI_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!descuento_documento_cli_det_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_CLI_DET_ID", descuento_documento_cli_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByTRANSFERENCIA_CAJA_SUC_DET_ID(decimal transferencia_caja_suc_det_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUC_DET_ID(transferencia_caja_suc_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_det_idNull">true if the method ignores the transferencia_caja_suc_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByTRANSFERENCIA_CAJA_SUC_DET_ID(decimal transferencia_caja_suc_det_id, bool transferencia_caja_suc_det_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_CAJA_SUC_DET_IDCommand(transferencia_caja_suc_det_id, transferencia_caja_suc_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_CAJA_SUC_DET_IDAsDataTable(decimal transferencia_caja_suc_det_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUC_DET_IDAsDataTable(transferencia_caja_suc_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_det_idNull">true if the method ignores the transferencia_caja_suc_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_CAJA_SUC_DET_IDAsDataTable(decimal transferencia_caja_suc_det_id, bool transferencia_caja_suc_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_CAJA_SUC_DET_IDCommand(transferencia_caja_suc_det_id, transferencia_caja_suc_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_det_idNull">true if the method ignores the transferencia_caja_suc_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_CAJA_SUC_DET_IDCommand(decimal transferencia_caja_suc_det_id, bool transferencia_caja_suc_det_idNull)
		{
			string whereSql = "";
			if(transferencia_caja_suc_det_idNull)
				whereSql += "TRANSFERENCIA_CAJA_SUC_DET_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CAJA_SUC_DET_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_caja_suc_det_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_DET_ID", transferencia_caja_suc_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESEMBOLSO_GIRO_ID(decimal desembolso_giro_id)
		{
			return GetByDESEMBOLSO_GIRO_ID(desembolso_giro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <param name="desembolso_giro_idNull">true if the method ignores the desembolso_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESEMBOLSO_GIRO_ID(decimal desembolso_giro_id, bool desembolso_giro_idNull)
		{
			return MapRecords(CreateGetByDESEMBOLSO_GIRO_IDCommand(desembolso_giro_id, desembolso_giro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESEMBOLSO_GIRO_IDAsDataTable(decimal desembolso_giro_id)
		{
			return GetByDESEMBOLSO_GIRO_IDAsDataTable(desembolso_giro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <param name="desembolso_giro_idNull">true if the method ignores the desembolso_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESEMBOLSO_GIRO_IDAsDataTable(decimal desembolso_giro_id, bool desembolso_giro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESEMBOLSO_GIRO_IDCommand(desembolso_giro_id, desembolso_giro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <param name="desembolso_giro_idNull">true if the method ignores the desembolso_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESEMBOLSO_GIRO_IDCommand(decimal desembolso_giro_id, bool desembolso_giro_idNull)
		{
			string whereSql = "";
			if(desembolso_giro_idNull)
				whereSql += "DESEMBOLSO_GIRO_ID IS NULL";
			else
				whereSql += "DESEMBOLSO_GIRO_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!desembolso_giro_idNull)
				AddParameter(cmd, "DESEMBOLSO_GIRO_ID", desembolso_giro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCANJE_VALOR_DET_ID(decimal canje_valor_det_id)
		{
			return GetByCANJE_VALOR_DET_ID(canje_valor_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <param name="canje_valor_det_idNull">true if the method ignores the canje_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCANJE_VALOR_DET_ID(decimal canje_valor_det_id, bool canje_valor_det_idNull)
		{
			return MapRecords(CreateGetByCANJE_VALOR_DET_IDCommand(canje_valor_det_id, canje_valor_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANJE_VALOR_DET_IDAsDataTable(decimal canje_valor_det_id)
		{
			return GetByCANJE_VALOR_DET_IDAsDataTable(canje_valor_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <param name="canje_valor_det_idNull">true if the method ignores the canje_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCANJE_VALOR_DET_IDAsDataTable(decimal canje_valor_det_id, bool canje_valor_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCANJE_VALOR_DET_IDCommand(canje_valor_det_id, canje_valor_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <param name="canje_valor_det_idNull">true if the method ignores the canje_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCANJE_VALOR_DET_IDCommand(decimal canje_valor_det_id, bool canje_valor_det_idNull)
		{
			string whereSql = "";
			if(canje_valor_det_idNull)
				whereSql += "CANJE_VALOR_DET_ID IS NULL";
			else
				whereSql += "CANJE_VALOR_DET_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!canje_valor_det_idNull)
				AddParameter(cmd, "CANJE_VALOR_DET_ID", canje_valor_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCANJE_VALOR_VAL_ID(decimal canje_valor_val_id)
		{
			return GetByCANJE_VALOR_VAL_ID(canje_valor_val_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <param name="canje_valor_val_idNull">true if the method ignores the canje_valor_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCANJE_VALOR_VAL_ID(decimal canje_valor_val_id, bool canje_valor_val_idNull)
		{
			return MapRecords(CreateGetByCANJE_VALOR_VAL_IDCommand(canje_valor_val_id, canje_valor_val_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANJE_VALOR_VAL_IDAsDataTable(decimal canje_valor_val_id)
		{
			return GetByCANJE_VALOR_VAL_IDAsDataTable(canje_valor_val_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <param name="canje_valor_val_idNull">true if the method ignores the canje_valor_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCANJE_VALOR_VAL_IDAsDataTable(decimal canje_valor_val_id, bool canje_valor_val_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCANJE_VALOR_VAL_IDCommand(canje_valor_val_id, canje_valor_val_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <param name="canje_valor_val_idNull">true if the method ignores the canje_valor_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCANJE_VALOR_VAL_IDCommand(decimal canje_valor_val_id, bool canje_valor_val_idNull)
		{
			string whereSql = "";
			if(canje_valor_val_idNull)
				whereSql += "CANJE_VALOR_VAL_ID IS NULL";
			else
				whereSql += "CANJE_VALOR_VAL_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_VAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!canje_valor_val_idNull)
				AddParameter(cmd, "CANJE_VALOR_VAL_ID", canje_valor_val_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCAMBIO_DIVISA_DET_ID(decimal cambio_divisa_det_id)
		{
			return GetByCAMBIO_DIVISA_DET_ID(cambio_divisa_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <param name="cambio_divisa_det_idNull">true if the method ignores the cambio_divisa_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCAMBIO_DIVISA_DET_ID(decimal cambio_divisa_det_id, bool cambio_divisa_det_idNull)
		{
			return MapRecords(CreateGetByCAMBIO_DIVISA_DET_IDCommand(cambio_divisa_det_id, cambio_divisa_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCAMBIO_DIVISA_DET_IDAsDataTable(decimal cambio_divisa_det_id)
		{
			return GetByCAMBIO_DIVISA_DET_IDAsDataTable(cambio_divisa_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <param name="cambio_divisa_det_idNull">true if the method ignores the cambio_divisa_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCAMBIO_DIVISA_DET_IDAsDataTable(decimal cambio_divisa_det_id, bool cambio_divisa_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCAMBIO_DIVISA_DET_IDCommand(cambio_divisa_det_id, cambio_divisa_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <param name="cambio_divisa_det_idNull">true if the method ignores the cambio_divisa_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCAMBIO_DIVISA_DET_IDCommand(decimal cambio_divisa_det_id, bool cambio_divisa_det_idNull)
		{
			string whereSql = "";
			if(cambio_divisa_det_idNull)
				whereSql += "CAMBIO_DIVISA_DET_ID IS NULL";
			else
				whereSql += "CAMBIO_DIVISA_DET_ID=" + _db.CreateSqlParameterName("CAMBIO_DIVISA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cambio_divisa_det_idNull)
				AddParameter(cmd, "CAMBIO_DIVISA_DET_ID", cambio_divisa_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_recibido_idNull)
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCUSTODIA_VALOR_DET_ID(decimal custodia_valor_det_id)
		{
			return GetByCUSTODIA_VALOR_DET_ID(custodia_valor_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <param name="custodia_valor_det_idNull">true if the method ignores the custodia_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCUSTODIA_VALOR_DET_ID(decimal custodia_valor_det_id, bool custodia_valor_det_idNull)
		{
			return MapRecords(CreateGetByCUSTODIA_VALOR_DET_IDCommand(custodia_valor_det_id, custodia_valor_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCUSTODIA_VALOR_DET_IDAsDataTable(decimal custodia_valor_det_id)
		{
			return GetByCUSTODIA_VALOR_DET_IDAsDataTable(custodia_valor_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <param name="custodia_valor_det_idNull">true if the method ignores the custodia_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCUSTODIA_VALOR_DET_IDAsDataTable(decimal custodia_valor_det_id, bool custodia_valor_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCUSTODIA_VALOR_DET_IDCommand(custodia_valor_det_id, custodia_valor_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <param name="custodia_valor_det_idNull">true if the method ignores the custodia_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCUSTODIA_VALOR_DET_IDCommand(decimal custodia_valor_det_id, bool custodia_valor_det_idNull)
		{
			string whereSql = "";
			if(custodia_valor_det_idNull)
				whereSql += "CUSTODIA_VALOR_DET_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALOR_DET_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!custodia_valor_det_idNull)
				AddParameter(cmd, "CUSTODIA_VALOR_DET_ID", custodia_valor_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCUSTODIA_VALOR_DET_ENTRADA_ID(decimal custodia_valor_det_entrada_id)
		{
			return GetByCUSTODIA_VALOR_DET_ENTRADA_ID(custodia_valor_det_entrada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <param name="custodia_valor_det_entrada_idNull">true if the method ignores the custodia_valor_det_entrada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCUSTODIA_VALOR_DET_ENTRADA_ID(decimal custodia_valor_det_entrada_id, bool custodia_valor_det_entrada_idNull)
		{
			return MapRecords(CreateGetByCUSTODIA_VALOR_DET_ENTRADA_IDCommand(custodia_valor_det_entrada_id, custodia_valor_det_entrada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCUSTODIA_VALOR_DET_ENTRADA_IDAsDataTable(decimal custodia_valor_det_entrada_id)
		{
			return GetByCUSTODIA_VALOR_DET_ENTRADA_IDAsDataTable(custodia_valor_det_entrada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <param name="custodia_valor_det_entrada_idNull">true if the method ignores the custodia_valor_det_entrada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCUSTODIA_VALOR_DET_ENTRADA_IDAsDataTable(decimal custodia_valor_det_entrada_id, bool custodia_valor_det_entrada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCUSTODIA_VALOR_DET_ENTRADA_IDCommand(custodia_valor_det_entrada_id, custodia_valor_det_entrada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <param name="custodia_valor_det_entrada_idNull">true if the method ignores the custodia_valor_det_entrada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCUSTODIA_VALOR_DET_ENTRADA_IDCommand(decimal custodia_valor_det_entrada_id, bool custodia_valor_det_entrada_idNull)
		{
			string whereSql = "";
			if(custodia_valor_det_entrada_idNull)
				whereSql += "CUSTODIA_VALOR_DET_ENTRADA_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALOR_DET_ENTRADA_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ENTRADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!custodia_valor_det_entrada_idNull)
				AddParameter(cmd, "CUSTODIA_VALOR_DET_ENTRADA_ID", custodia_valor_det_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id)
		{
			return GetByDEPOSITO_BANCARIO_DET_ID(deposito_bancario_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_BANCARIO_DET_IDCommand(deposito_bancario_det_id, deposito_bancario_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_BANCARIO_DET_IDAsDataTable(decimal deposito_bancario_det_id)
		{
			return GetByDEPOSITO_BANCARIO_DET_IDAsDataTable(deposito_bancario_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_BANCARIO_DET_IDAsDataTable(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_BANCARIO_DET_IDCommand(deposito_bancario_det_id, deposito_bancario_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_BANCARIO_DET_IDCommand(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_det_idNull)
				whereSql += "DEPOSITO_BANCARIO_DET_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_DET_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_bancario_det_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID", deposito_bancario_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESCUENTO_DOCUMENTO_DET_ID(decimal descuento_documento_det_id)
		{
			return GetByDESCUENTO_DOCUMENTO_DET_ID(descuento_documento_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_det_idNull">true if the method ignores the descuento_documento_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESCUENTO_DOCUMENTO_DET_ID(decimal descuento_documento_det_id, bool descuento_documento_det_idNull)
		{
			return MapRecords(CreateGetByDESCUENTO_DOCUMENTO_DET_IDCommand(descuento_documento_det_id, descuento_documento_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCUENTO_DOCUMENTO_DET_IDAsDataTable(decimal descuento_documento_det_id)
		{
			return GetByDESCUENTO_DOCUMENTO_DET_IDAsDataTable(descuento_documento_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_det_idNull">true if the method ignores the descuento_documento_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_DOCUMENTO_DET_IDAsDataTable(decimal descuento_documento_det_id, bool descuento_documento_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_DOCUMENTO_DET_IDCommand(descuento_documento_det_id, descuento_documento_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_det_idNull">true if the method ignores the descuento_documento_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_DOCUMENTO_DET_IDCommand(decimal descuento_documento_det_id, bool descuento_documento_det_idNull)
		{
			string whereSql = "";
			if(descuento_documento_det_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_DET_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_DET_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!descuento_documento_det_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_DET_ID", descuento_documento_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESCUENTO_DOCUMENTO_PAGO_ID(decimal descuento_documento_pago_id)
		{
			return GetByDESCUENTO_DOCUMENTO_PAGO_ID(descuento_documento_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <param name="descuento_documento_pago_idNull">true if the method ignores the descuento_documento_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByDESCUENTO_DOCUMENTO_PAGO_ID(decimal descuento_documento_pago_id, bool descuento_documento_pago_idNull)
		{
			return MapRecords(CreateGetByDESCUENTO_DOCUMENTO_PAGO_IDCommand(descuento_documento_pago_id, descuento_documento_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESCUENTO_DOCUMENTO_PAGO_IDAsDataTable(decimal descuento_documento_pago_id)
		{
			return GetByDESCUENTO_DOCUMENTO_PAGO_IDAsDataTable(descuento_documento_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <param name="descuento_documento_pago_idNull">true if the method ignores the descuento_documento_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESCUENTO_DOCUMENTO_PAGO_IDAsDataTable(decimal descuento_documento_pago_id, bool descuento_documento_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESCUENTO_DOCUMENTO_PAGO_IDCommand(descuento_documento_pago_id, descuento_documento_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <param name="descuento_documento_pago_idNull">true if the method ignores the descuento_documento_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESCUENTO_DOCUMENTO_PAGO_IDCommand(decimal descuento_documento_pago_id, bool descuento_documento_pago_idNull)
		{
			string whereSql = "";
			if(descuento_documento_pago_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_PAGO_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_PAGO_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!descuento_documento_pago_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_PAGO_ID", descuento_documento_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_MON</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByMOVIMIENTO_VARIO_DET_ID(decimal movimiento_vario_det_id)
		{
			return GetByMOVIMIENTO_VARIO_DET_ID(movimiento_vario_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <param name="movimiento_vario_det_idNull">true if the method ignores the movimiento_vario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByMOVIMIENTO_VARIO_DET_ID(decimal movimiento_vario_det_id, bool movimiento_vario_det_idNull)
		{
			return MapRecords(CreateGetByMOVIMIENTO_VARIO_DET_IDCommand(movimiento_vario_det_id, movimiento_vario_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOVIMIENTO_VARIO_DET_IDAsDataTable(decimal movimiento_vario_det_id)
		{
			return GetByMOVIMIENTO_VARIO_DET_IDAsDataTable(movimiento_vario_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <param name="movimiento_vario_det_idNull">true if the method ignores the movimiento_vario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOVIMIENTO_VARIO_DET_IDAsDataTable(decimal movimiento_vario_det_id, bool movimiento_vario_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMOVIMIENTO_VARIO_DET_IDCommand(movimiento_vario_det_id, movimiento_vario_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <param name="movimiento_vario_det_idNull">true if the method ignores the movimiento_vario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOVIMIENTO_VARIO_DET_IDCommand(decimal movimiento_vario_det_id, bool movimiento_vario_det_idNull)
		{
			string whereSql = "";
			if(movimiento_vario_det_idNull)
				whereSql += "MOVIMIENTO_VARIO_DET_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_VARIO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!movimiento_vario_det_idNull)
				AddParameter(cmd, "MOVIMIENTO_VARIO_DET_ID", movimiento_vario_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id)
		{
			return GetByORDEN_PAGO_VALOR_ID(orden_pago_valor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			return MapRecords(CreateGetByORDEN_PAGO_VALOR_IDCommand(orden_pago_valor_id, orden_pago_valor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDEN_PAGO_VALOR_IDAsDataTable(decimal orden_pago_valor_id)
		{
			return GetByORDEN_PAGO_VALOR_IDAsDataTable(orden_pago_valor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_VALOR_IDAsDataTable(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_VALOR_IDCommand(orden_pago_valor_id, orden_pago_valor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_VALOR_IDCommand(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			string whereSql = "";
			if(orden_pago_valor_idNull)
				whereSql += "ORDEN_PAGO_VALOR_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_VALOR_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!orden_pago_valor_idNull)
				AddParameter(cmd, "ORDEN_PAGO_VALOR_ID", orden_pago_valor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_tarjeta_idNull)
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_procesadora_tarjeta_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID", ctacte_procesadora_tarjeta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public CTACTE_CAJAS_TESORERIA_MOVRow[] GetByTRANSFERENCIA_DET_ID(decimal transferencia_det_id)
		{
			return GetByTRANSFERENCIA_DET_ID(transferencia_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <param name="transferencia_det_idNull">true if the method ignores the transferencia_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByTRANSFERENCIA_DET_ID(decimal transferencia_det_id, bool transferencia_det_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_DET_IDCommand(transferencia_det_id, transferencia_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_DET_IDAsDataTable(decimal transferencia_det_id)
		{
			return GetByTRANSFERENCIA_DET_IDAsDataTable(transferencia_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <param name="transferencia_det_idNull">true if the method ignores the transferencia_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_DET_IDAsDataTable(decimal transferencia_det_id, bool transferencia_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_DET_IDCommand(transferencia_det_id, transferencia_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <param name="transferencia_det_idNull">true if the method ignores the transferencia_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_DET_IDCommand(decimal transferencia_det_id, bool transferencia_det_idNull)
		{
			string whereSql = "";
			if(transferencia_det_idNull)
				whereSql += "TRANSFERENCIA_DET_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_DET_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_det_idNull)
				AddParameter(cmd, "TRANSFERENCIA_DET_ID", transferencia_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByUSUARIO_OPERACION_ID(decimal usuario_operacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_OPERACION_IDCommand(usuario_operacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_OPERACION_IDAsDataTable(decimal usuario_operacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_OPERACION_IDCommand(usuario_operacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_OPERACION_IDCommand(decimal usuario_operacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_OPERACION_ID=" + _db.CreateSqlParameterName("USUARIO_OPERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_OPERACION_ID", usuario_operacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESORERIA_MOVRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_CAJAS_TESO_MOV_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_CAJAS_TESO_MOV_VAL</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_CAJAS_TESORERIA_MOVRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_CAJAS_TESORERIA_MOV (" +
				"ID, " +
				"CTACTE_CAJA_TESORERIA_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"FECHA_OPERACION, " +
				"USUARIO_OPERACION_ID, " +
				"CTACTE_VALOR_ID, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"INGRESO, " +
				"EGRESO, " +
				"FECHA_INGRESO, " +
				"FECHA_EGRESO, " +
				"OBSERVACION, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"CTACTE_PROCESADORA_TARJETA_ID, " +
				"DEPOSITO_BANCARIO_DET_ID, " +
				"ORDEN_PAGO_VALOR_ID, " +
				"CAMBIO_DIVISA_DET_ID, " +
				"MOVIMIENTO_VARIO_DET_ID, " +
				"TRANSFERENCIA_DET_ID, " +
				"CUSTODIA_VALOR_DET_ID, " +
				"DESCUENTO_DOCUMENTO_PAGO_ID, " +
				"DESCUENTO_DOCUMENTO_DET_ID, " +
				"CANJE_VALOR_DET_ID, " +
				"CANJE_VALOR_VAL_ID, " +
				"DESEMBOLSO_GIRO_ID, " +
				"CUSTODIA_VALOR_DET_ENTRADA_ID, " +
				"DESCUENTO_DOCUMENTO_CLI_DET_ID, " +
				"TRANSFERENCIA_CAJA_SUC_DET_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("FECHA_OPERACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_OPERACION_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("INGRESO") + ", " +
				_db.CreateSqlParameterName("EGRESO") + ", " +
				_db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				_db.CreateSqlParameterName("FECHA_EGRESO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("CAMBIO_DIVISA_DET_ID") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_VARIO_DET_ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_DET_ID") + ", " +
				_db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_DET_ID") + ", " +
				_db.CreateSqlParameterName("CANJE_VALOR_DET_ID") + ", " +
				_db.CreateSqlParameterName("CANJE_VALOR_VAL_ID") + ", " +
				_db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID") + ", " +
				_db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ENTRADA_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_CLI_DET_ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_DET_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "FECHA_OPERACION", value.FECHA_OPERACION);
			AddParameter(cmd, "USUARIO_OPERACION_ID", value.USUARIO_OPERACION_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "INGRESO",
				value.IsINGRESONull ? DBNull.Value : (object)value.INGRESO);
			AddParameter(cmd, "EGRESO",
				value.IsEGRESONull ? DBNull.Value : (object)value.EGRESO);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "FECHA_EGRESO",
				value.IsFECHA_EGRESONull ? DBNull.Value : (object)value.FECHA_EGRESO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID",
				value.IsDEPOSITO_BANCARIO_DET_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_DET_ID);
			AddParameter(cmd, "ORDEN_PAGO_VALOR_ID",
				value.IsORDEN_PAGO_VALOR_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_VALOR_ID);
			AddParameter(cmd, "CAMBIO_DIVISA_DET_ID",
				value.IsCAMBIO_DIVISA_DET_IDNull ? DBNull.Value : (object)value.CAMBIO_DIVISA_DET_ID);
			AddParameter(cmd, "MOVIMIENTO_VARIO_DET_ID",
				value.IsMOVIMIENTO_VARIO_DET_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_VARIO_DET_ID);
			AddParameter(cmd, "TRANSFERENCIA_DET_ID",
				value.IsTRANSFERENCIA_DET_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_DET_ID);
			AddParameter(cmd, "CUSTODIA_VALOR_DET_ID",
				value.IsCUSTODIA_VALOR_DET_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALOR_DET_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_PAGO_ID",
				value.IsDESCUENTO_DOCUMENTO_PAGO_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_PAGO_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_DET_ID",
				value.IsDESCUENTO_DOCUMENTO_DET_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_DET_ID);
			AddParameter(cmd, "CANJE_VALOR_DET_ID",
				value.IsCANJE_VALOR_DET_IDNull ? DBNull.Value : (object)value.CANJE_VALOR_DET_ID);
			AddParameter(cmd, "CANJE_VALOR_VAL_ID",
				value.IsCANJE_VALOR_VAL_IDNull ? DBNull.Value : (object)value.CANJE_VALOR_VAL_ID);
			AddParameter(cmd, "DESEMBOLSO_GIRO_ID",
				value.IsDESEMBOLSO_GIRO_IDNull ? DBNull.Value : (object)value.DESEMBOLSO_GIRO_ID);
			AddParameter(cmd, "CUSTODIA_VALOR_DET_ENTRADA_ID",
				value.IsCUSTODIA_VALOR_DET_ENTRADA_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALOR_DET_ENTRADA_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_CLI_DET_ID",
				value.IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_CLI_DET_ID);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_DET_ID",
				value.IsTRANSFERENCIA_CAJA_SUC_DET_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUC_DET_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_CAJAS_TESORERIA_MOVRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_CAJAS_TESORERIA_MOV SET " +
				"CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"FECHA_OPERACION=" + _db.CreateSqlParameterName("FECHA_OPERACION") + ", " +
				"USUARIO_OPERACION_ID=" + _db.CreateSqlParameterName("USUARIO_OPERACION_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"INGRESO=" + _db.CreateSqlParameterName("INGRESO") + ", " +
				"EGRESO=" + _db.CreateSqlParameterName("EGRESO") + ", " +
				"FECHA_INGRESO=" + _db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				"FECHA_EGRESO=" + _db.CreateSqlParameterName("FECHA_EGRESO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") + ", " +
				"DEPOSITO_BANCARIO_DET_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID") + ", " +
				"ORDEN_PAGO_VALOR_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID") + ", " +
				"CAMBIO_DIVISA_DET_ID=" + _db.CreateSqlParameterName("CAMBIO_DIVISA_DET_ID") + ", " +
				"MOVIMIENTO_VARIO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_DET_ID") + ", " +
				"TRANSFERENCIA_DET_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_DET_ID") + ", " +
				"CUSTODIA_VALOR_DET_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ID") + ", " +
				"DESCUENTO_DOCUMENTO_PAGO_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_PAGO_ID") + ", " +
				"DESCUENTO_DOCUMENTO_DET_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_DET_ID") + ", " +
				"CANJE_VALOR_DET_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_DET_ID") + ", " +
				"CANJE_VALOR_VAL_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_VAL_ID") + ", " +
				"DESEMBOLSO_GIRO_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID") + ", " +
				"CUSTODIA_VALOR_DET_ENTRADA_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ENTRADA_ID") + ", " +
				"DESCUENTO_DOCUMENTO_CLI_DET_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_CLI_DET_ID") + ", " +
				"TRANSFERENCIA_CAJA_SUC_DET_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_DET_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "FECHA_OPERACION", value.FECHA_OPERACION);
			AddParameter(cmd, "USUARIO_OPERACION_ID", value.USUARIO_OPERACION_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "INGRESO",
				value.IsINGRESONull ? DBNull.Value : (object)value.INGRESO);
			AddParameter(cmd, "EGRESO",
				value.IsEGRESONull ? DBNull.Value : (object)value.EGRESO);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "FECHA_EGRESO",
				value.IsFECHA_EGRESONull ? DBNull.Value : (object)value.FECHA_EGRESO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID",
				value.IsDEPOSITO_BANCARIO_DET_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_DET_ID);
			AddParameter(cmd, "ORDEN_PAGO_VALOR_ID",
				value.IsORDEN_PAGO_VALOR_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_VALOR_ID);
			AddParameter(cmd, "CAMBIO_DIVISA_DET_ID",
				value.IsCAMBIO_DIVISA_DET_IDNull ? DBNull.Value : (object)value.CAMBIO_DIVISA_DET_ID);
			AddParameter(cmd, "MOVIMIENTO_VARIO_DET_ID",
				value.IsMOVIMIENTO_VARIO_DET_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_VARIO_DET_ID);
			AddParameter(cmd, "TRANSFERENCIA_DET_ID",
				value.IsTRANSFERENCIA_DET_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_DET_ID);
			AddParameter(cmd, "CUSTODIA_VALOR_DET_ID",
				value.IsCUSTODIA_VALOR_DET_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALOR_DET_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_PAGO_ID",
				value.IsDESCUENTO_DOCUMENTO_PAGO_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_PAGO_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_DET_ID",
				value.IsDESCUENTO_DOCUMENTO_DET_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_DET_ID);
			AddParameter(cmd, "CANJE_VALOR_DET_ID",
				value.IsCANJE_VALOR_DET_IDNull ? DBNull.Value : (object)value.CANJE_VALOR_DET_ID);
			AddParameter(cmd, "CANJE_VALOR_VAL_ID",
				value.IsCANJE_VALOR_VAL_IDNull ? DBNull.Value : (object)value.CANJE_VALOR_VAL_ID);
			AddParameter(cmd, "DESEMBOLSO_GIRO_ID",
				value.IsDESEMBOLSO_GIRO_IDNull ? DBNull.Value : (object)value.DESEMBOLSO_GIRO_ID);
			AddParameter(cmd, "CUSTODIA_VALOR_DET_ENTRADA_ID",
				value.IsCUSTODIA_VALOR_DET_ENTRADA_IDNull ? DBNull.Value : (object)value.CUSTODIA_VALOR_DET_ENTRADA_ID);
			AddParameter(cmd, "DESCUENTO_DOCUMENTO_CLI_DET_ID",
				value.IsDESCUENTO_DOCUMENTO_CLI_DET_IDNull ? DBNull.Value : (object)value.DESCUENTO_DOCUMENTO_CLI_DET_ID);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_DET_ID",
				value.IsTRANSFERENCIA_CAJA_SUC_DET_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUC_DET_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_CAJAS_TESORERIA_MOVRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using
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
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_CLI_DET_ID(decimal descuento_documento_cli_det_id)
		{
			return DeleteByDESCUENTO_DOCUMENTO_CLI_DET_ID(descuento_documento_cli_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_cli_det_idNull">true if the method ignores the descuento_documento_cli_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_CLI_DET_ID(decimal descuento_documento_cli_det_id, bool descuento_documento_cli_det_idNull)
		{
			return CreateDeleteByDESCUENTO_DOCUMENTO_CLI_DET_IDCommand(descuento_documento_cli_det_id, descuento_documento_cli_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACT_CAJ_TES_MOV_DES_CLI_D</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_cli_det_id">The <c>DESCUENTO_DOCUMENTO_CLI_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_cli_det_idNull">true if the method ignores the descuento_documento_cli_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_DOCUMENTO_CLI_DET_IDCommand(decimal descuento_documento_cli_det_id, bool descuento_documento_cli_det_idNull)
		{
			string whereSql = "";
			if(descuento_documento_cli_det_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_CLI_DET_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_CLI_DET_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_CLI_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!descuento_documento_cli_det_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_CLI_DET_ID", descuento_documento_cli_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CAJA_SUC_DET_ID(decimal transferencia_caja_suc_det_id)
		{
			return DeleteByTRANSFERENCIA_CAJA_SUC_DET_ID(transferencia_caja_suc_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_det_idNull">true if the method ignores the transferencia_caja_suc_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CAJA_SUC_DET_ID(decimal transferencia_caja_suc_det_id, bool transferencia_caja_suc_det_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_CAJA_SUC_DET_IDCommand(transferencia_caja_suc_det_id, transferencia_caja_suc_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJ_TESO_MOV_TCS_DET</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_suc_det_id">The <c>TRANSFERENCIA_CAJA_SUC_DET_ID</c> column value.</param>
		/// <param name="transferencia_caja_suc_det_idNull">true if the method ignores the transferencia_caja_suc_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_CAJA_SUC_DET_IDCommand(decimal transferencia_caja_suc_det_id, bool transferencia_caja_suc_det_idNull)
		{
			string whereSql = "";
			if(transferencia_caja_suc_det_idNull)
				whereSql += "TRANSFERENCIA_CAJA_SUC_DET_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CAJA_SUC_DET_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUC_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_caja_suc_det_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CAJA_SUC_DET_ID", transferencia_caja_suc_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESEMBOLSO_GIRO_ID(decimal desembolso_giro_id)
		{
			return DeleteByDESEMBOLSO_GIRO_ID(desembolso_giro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <param name="desembolso_giro_idNull">true if the method ignores the desembolso_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESEMBOLSO_GIRO_ID(decimal desembolso_giro_id, bool desembolso_giro_idNull)
		{
			return CreateDeleteByDESEMBOLSO_GIRO_IDCommand(desembolso_giro_id, desembolso_giro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_DESEM_GIRO</c> foreign key.
		/// </summary>
		/// <param name="desembolso_giro_id">The <c>DESEMBOLSO_GIRO_ID</c> column value.</param>
		/// <param name="desembolso_giro_idNull">true if the method ignores the desembolso_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESEMBOLSO_GIRO_IDCommand(decimal desembolso_giro_id, bool desembolso_giro_idNull)
		{
			string whereSql = "";
			if(desembolso_giro_idNull)
				whereSql += "DESEMBOLSO_GIRO_ID IS NULL";
			else
				whereSql += "DESEMBOLSO_GIRO_ID=" + _db.CreateSqlParameterName("DESEMBOLSO_GIRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!desembolso_giro_idNull)
				AddParameter(cmd, "DESEMBOLSO_GIRO_ID", desembolso_giro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJ</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CAJA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANJE_VALOR_DET_ID(decimal canje_valor_det_id)
		{
			return DeleteByCANJE_VALOR_DET_ID(canje_valor_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <param name="canje_valor_det_idNull">true if the method ignores the canje_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANJE_VALOR_DET_ID(decimal canje_valor_det_id, bool canje_valor_det_idNull)
		{
			return CreateDeleteByCANJE_VALOR_DET_IDCommand(canje_valor_det_id, canje_valor_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_D</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_det_id">The <c>CANJE_VALOR_DET_ID</c> column value.</param>
		/// <param name="canje_valor_det_idNull">true if the method ignores the canje_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCANJE_VALOR_DET_IDCommand(decimal canje_valor_det_id, bool canje_valor_det_idNull)
		{
			string whereSql = "";
			if(canje_valor_det_idNull)
				whereSql += "CANJE_VALOR_DET_ID IS NULL";
			else
				whereSql += "CANJE_VALOR_DET_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!canje_valor_det_idNull)
				AddParameter(cmd, "CANJE_VALOR_DET_ID", canje_valor_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANJE_VALOR_VAL_ID(decimal canje_valor_val_id)
		{
			return DeleteByCANJE_VALOR_VAL_ID(canje_valor_val_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <param name="canje_valor_val_idNull">true if the method ignores the canje_valor_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANJE_VALOR_VAL_ID(decimal canje_valor_val_id, bool canje_valor_val_idNull)
		{
			return CreateDeleteByCANJE_VALOR_VAL_IDCommand(canje_valor_val_id, canje_valor_val_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CAN_V</c> foreign key.
		/// </summary>
		/// <param name="canje_valor_val_id">The <c>CANJE_VALOR_VAL_ID</c> column value.</param>
		/// <param name="canje_valor_val_idNull">true if the method ignores the canje_valor_val_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCANJE_VALOR_VAL_IDCommand(decimal canje_valor_val_id, bool canje_valor_val_idNull)
		{
			string whereSql = "";
			if(canje_valor_val_idNull)
				whereSql += "CANJE_VALOR_VAL_ID IS NULL";
			else
				whereSql += "CANJE_VALOR_VAL_ID=" + _db.CreateSqlParameterName("CANJE_VALOR_VAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!canje_valor_val_idNull)
				AddParameter(cmd, "CANJE_VALOR_VAL_ID", canje_valor_val_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAMBIO_DIVISA_DET_ID(decimal cambio_divisa_det_id)
		{
			return DeleteByCAMBIO_DIVISA_DET_ID(cambio_divisa_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <param name="cambio_divisa_det_idNull">true if the method ignores the cambio_divisa_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCAMBIO_DIVISA_DET_ID(decimal cambio_divisa_det_id, bool cambio_divisa_det_idNull)
		{
			return CreateDeleteByCAMBIO_DIVISA_DET_IDCommand(cambio_divisa_det_id, cambio_divisa_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CD</c> foreign key.
		/// </summary>
		/// <param name="cambio_divisa_det_id">The <c>CAMBIO_DIVISA_DET_ID</c> column value.</param>
		/// <param name="cambio_divisa_det_idNull">true if the method ignores the cambio_divisa_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCAMBIO_DIVISA_DET_IDCommand(decimal cambio_divisa_det_id, bool cambio_divisa_det_idNull)
		{
			string whereSql = "";
			if(cambio_divisa_det_idNull)
				whereSql += "CAMBIO_DIVISA_DET_ID IS NULL";
			else
				whereSql += "CAMBIO_DIVISA_DET_ID=" + _db.CreateSqlParameterName("CAMBIO_DIVISA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cambio_divisa_det_idNull)
				AddParameter(cmd, "CAMBIO_DIVISA_DET_ID", cambio_divisa_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CHQ_R</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CHEQUE_RECIBIDO_IDCommand(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			string whereSql = "";
			if(ctacte_cheque_recibido_idNull)
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID IS NULL";
			else
				whereSql += "CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_cheque_recibido_idNull)
				AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID", ctacte_cheque_recibido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALOR_DET_ID(decimal custodia_valor_det_id)
		{
			return DeleteByCUSTODIA_VALOR_DET_ID(custodia_valor_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <param name="custodia_valor_det_idNull">true if the method ignores the custodia_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALOR_DET_ID(decimal custodia_valor_det_id, bool custodia_valor_det_idNull)
		{
			return CreateDeleteByCUSTODIA_VALOR_DET_IDCommand(custodia_valor_det_id, custodia_valor_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_id">The <c>CUSTODIA_VALOR_DET_ID</c> column value.</param>
		/// <param name="custodia_valor_det_idNull">true if the method ignores the custodia_valor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCUSTODIA_VALOR_DET_IDCommand(decimal custodia_valor_det_id, bool custodia_valor_det_idNull)
		{
			string whereSql = "";
			if(custodia_valor_det_idNull)
				whereSql += "CUSTODIA_VALOR_DET_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALOR_DET_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!custodia_valor_det_idNull)
				AddParameter(cmd, "CUSTODIA_VALOR_DET_ID", custodia_valor_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALOR_DET_ENTRADA_ID(decimal custodia_valor_det_entrada_id)
		{
			return DeleteByCUSTODIA_VALOR_DET_ENTRADA_ID(custodia_valor_det_entrada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <param name="custodia_valor_det_entrada_idNull">true if the method ignores the custodia_valor_det_entrada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCUSTODIA_VALOR_DET_ENTRADA_ID(decimal custodia_valor_det_entrada_id, bool custodia_valor_det_entrada_idNull)
		{
			return CreateDeleteByCUSTODIA_VALOR_DET_ENTRADA_IDCommand(custodia_valor_det_entrada_id, custodia_valor_det_entrada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_CUS_E</c> foreign key.
		/// </summary>
		/// <param name="custodia_valor_det_entrada_id">The <c>CUSTODIA_VALOR_DET_ENTRADA_ID</c> column value.</param>
		/// <param name="custodia_valor_det_entrada_idNull">true if the method ignores the custodia_valor_det_entrada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCUSTODIA_VALOR_DET_ENTRADA_IDCommand(decimal custodia_valor_det_entrada_id, bool custodia_valor_det_entrada_idNull)
		{
			string whereSql = "";
			if(custodia_valor_det_entrada_idNull)
				whereSql += "CUSTODIA_VALOR_DET_ENTRADA_ID IS NULL";
			else
				whereSql += "CUSTODIA_VALOR_DET_ENTRADA_ID=" + _db.CreateSqlParameterName("CUSTODIA_VALOR_DET_ENTRADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!custodia_valor_det_entrada_idNull)
				AddParameter(cmd, "CUSTODIA_VALOR_DET_ENTRADA_ID", custodia_valor_det_entrada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id)
		{
			return DeleteByDEPOSITO_BANCARIO_DET_ID(deposito_bancario_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_DET_ID(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			return CreateDeleteByDEPOSITO_BANCARIO_DET_IDCommand(deposito_bancario_det_id, deposito_bancario_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_det_id">The <c>DEPOSITO_BANCARIO_DET_ID</c> column value.</param>
		/// <param name="deposito_bancario_det_idNull">true if the method ignores the deposito_bancario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_BANCARIO_DET_IDCommand(decimal deposito_bancario_det_id, bool deposito_bancario_det_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_det_idNull)
				whereSql += "DEPOSITO_BANCARIO_DET_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_DET_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_bancario_det_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_DET_ID", deposito_bancario_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_DET_ID(decimal descuento_documento_det_id)
		{
			return DeleteByDESCUENTO_DOCUMENTO_DET_ID(descuento_documento_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_det_idNull">true if the method ignores the descuento_documento_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_DET_ID(decimal descuento_documento_det_id, bool descuento_documento_det_idNull)
		{
			return CreateDeleteByDESCUENTO_DOCUMENTO_DET_IDCommand(descuento_documento_det_id, descuento_documento_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_DESE</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_det_id">The <c>DESCUENTO_DOCUMENTO_DET_ID</c> column value.</param>
		/// <param name="descuento_documento_det_idNull">true if the method ignores the descuento_documento_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_DOCUMENTO_DET_IDCommand(decimal descuento_documento_det_id, bool descuento_documento_det_idNull)
		{
			string whereSql = "";
			if(descuento_documento_det_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_DET_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_DET_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!descuento_documento_det_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_DET_ID", descuento_documento_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_PAGO_ID(decimal descuento_documento_pago_id)
		{
			return DeleteByDESCUENTO_DOCUMENTO_PAGO_ID(descuento_documento_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <param name="descuento_documento_pago_idNull">true if the method ignores the descuento_documento_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESCUENTO_DOCUMENTO_PAGO_ID(decimal descuento_documento_pago_id, bool descuento_documento_pago_idNull)
		{
			return CreateDeleteByDESCUENTO_DOCUMENTO_PAGO_IDCommand(descuento_documento_pago_id, descuento_documento_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_DESI</c> foreign key.
		/// </summary>
		/// <param name="descuento_documento_pago_id">The <c>DESCUENTO_DOCUMENTO_PAGO_ID</c> column value.</param>
		/// <param name="descuento_documento_pago_idNull">true if the method ignores the descuento_documento_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESCUENTO_DOCUMENTO_PAGO_IDCommand(decimal descuento_documento_pago_id, bool descuento_documento_pago_idNull)
		{
			string whereSql = "";
			if(descuento_documento_pago_idNull)
				whereSql += "DESCUENTO_DOCUMENTO_PAGO_ID IS NULL";
			else
				whereSql += "DESCUENTO_DOCUMENTO_PAGO_ID=" + _db.CreateSqlParameterName("DESCUENTO_DOCUMENTO_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!descuento_documento_pago_idNull)
				AddParameter(cmd, "DESCUENTO_DOCUMENTO_PAGO_ID", descuento_documento_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_MON</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_VARIO_DET_ID(decimal movimiento_vario_det_id)
		{
			return DeleteByMOVIMIENTO_VARIO_DET_ID(movimiento_vario_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <param name="movimiento_vario_det_idNull">true if the method ignores the movimiento_vario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_VARIO_DET_ID(decimal movimiento_vario_det_id, bool movimiento_vario_det_idNull)
		{
			return CreateDeleteByMOVIMIENTO_VARIO_DET_IDCommand(movimiento_vario_det_id, movimiento_vario_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_MV</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_det_id">The <c>MOVIMIENTO_VARIO_DET_ID</c> column value.</param>
		/// <param name="movimiento_vario_det_idNull">true if the method ignores the movimiento_vario_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOVIMIENTO_VARIO_DET_IDCommand(decimal movimiento_vario_det_id, bool movimiento_vario_det_idNull)
		{
			string whereSql = "";
			if(movimiento_vario_det_idNull)
				whereSql += "MOVIMIENTO_VARIO_DET_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_VARIO_DET_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!movimiento_vario_det_idNull)
				AddParameter(cmd, "MOVIMIENTO_VARIO_DET_ID", movimiento_vario_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id)
		{
			return DeleteByORDEN_PAGO_VALOR_ID(orden_pago_valor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			return CreateDeleteByORDEN_PAGO_VALOR_IDCommand(orden_pago_valor_id, orden_pago_valor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_VALOR_IDCommand(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			string whereSql = "";
			if(orden_pago_valor_idNull)
				whereSql += "ORDEN_PAGO_VALOR_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_VALOR_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!orden_pago_valor_idNull)
				AddParameter(cmd, "ORDEN_PAGO_VALOR_ID", orden_pago_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return DeleteByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return CreateDeleteByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROCESADORA_TARJETA_IDCommand(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			string whereSql = "";
			if(ctacte_procesadora_tarjeta_idNull)
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID IS NULL";
			else
				whereSql += "CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_procesadora_tarjeta_idNull)
				AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID", ctacte_procesadora_tarjeta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_DET_ID(decimal transferencia_det_id)
		{
			return DeleteByTRANSFERENCIA_DET_ID(transferencia_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <param name="transferencia_det_idNull">true if the method ignores the transferencia_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_DET_ID(decimal transferencia_det_id, bool transferencia_det_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_DET_IDCommand(transferencia_det_id, transferencia_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_TD</c> foreign key.
		/// </summary>
		/// <param name="transferencia_det_id">The <c>TRANSFERENCIA_DET_ID</c> column value.</param>
		/// <param name="transferencia_det_idNull">true if the method ignores the transferencia_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_DET_IDCommand(decimal transferencia_det_id, bool transferencia_det_idNull)
		{
			string whereSql = "";
			if(transferencia_det_idNull)
				whereSql += "TRANSFERENCIA_DET_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_DET_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_det_idNull)
				AddParameter(cmd, "TRANSFERENCIA_DET_ID", transferencia_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_OPERACION_ID(decimal usuario_operacion_id)
		{
			return CreateDeleteByUSUARIO_OPERACION_IDCommand(usuario_operacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_USR</c> foreign key.
		/// </summary>
		/// <param name="usuario_operacion_id">The <c>USUARIO_OPERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_OPERACION_IDCommand(decimal usuario_operacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_OPERACION_ID=" + _db.CreateSqlParameterName("USUARIO_OPERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_OPERACION_ID", usuario_operacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table using the 
		/// <c>FK_CTACTE_CAJAS_TESO_MOV_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_CAJAS_TESO_MOV_VAL</c> foreign key.
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
		/// Deletes <c>CTACTE_CAJAS_TESORERIA_MOV</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_CAJAS_TESORERIA_MOV</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_CAJAS_TESORERIA_MOV";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		protected CTACTE_CAJAS_TESORERIA_MOVRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		protected CTACTE_CAJAS_TESORERIA_MOVRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> objects.</returns>
		protected virtual CTACTE_CAJAS_TESORERIA_MOVRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int fecha_operacionColumnIndex = reader.GetOrdinal("FECHA_OPERACION");
			int usuario_operacion_idColumnIndex = reader.GetOrdinal("USUARIO_OPERACION_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int ingresoColumnIndex = reader.GetOrdinal("INGRESO");
			int egresoColumnIndex = reader.GetOrdinal("EGRESO");
			int fecha_ingresoColumnIndex = reader.GetOrdinal("FECHA_INGRESO");
			int fecha_egresoColumnIndex = reader.GetOrdinal("FECHA_EGRESO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int ctacte_procesadora_tarjeta_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_TARJETA_ID");
			int deposito_bancario_det_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_DET_ID");
			int orden_pago_valor_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_VALOR_ID");
			int cambio_divisa_det_idColumnIndex = reader.GetOrdinal("CAMBIO_DIVISA_DET_ID");
			int movimiento_vario_det_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_VARIO_DET_ID");
			int transferencia_det_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_DET_ID");
			int custodia_valor_det_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALOR_DET_ID");
			int descuento_documento_pago_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_PAGO_ID");
			int descuento_documento_det_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_DET_ID");
			int canje_valor_det_idColumnIndex = reader.GetOrdinal("CANJE_VALOR_DET_ID");
			int canje_valor_val_idColumnIndex = reader.GetOrdinal("CANJE_VALOR_VAL_ID");
			int desembolso_giro_idColumnIndex = reader.GetOrdinal("DESEMBOLSO_GIRO_ID");
			int custodia_valor_det_entrada_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALOR_DET_ENTRADA_ID");
			int descuento_documento_cli_det_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_CLI_DET_ID");
			int transferencia_caja_suc_det_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_CAJA_SUC_DET_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CAJAS_TESORERIA_MOVRow record = new CTACTE_CAJAS_TESORERIA_MOVRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.FECHA_OPERACION = Convert.ToDateTime(reader.GetValue(fecha_operacionColumnIndex));
					record.USUARIO_OPERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_operacion_idColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(ingresoColumnIndex))
						record.INGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(ingresoColumnIndex)), 9);
					if(!reader.IsDBNull(egresoColumnIndex))
						record.EGRESO = Math.Round(Convert.ToDecimal(reader.GetValue(egresoColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ingresoColumnIndex))
						record.FECHA_INGRESO = Convert.ToDateTime(reader.GetValue(fecha_ingresoColumnIndex));
					if(!reader.IsDBNull(fecha_egresoColumnIndex))
						record.FECHA_EGRESO = Convert.ToDateTime(reader.GetValue(fecha_egresoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadora_tarjeta_idColumnIndex))
						record.CTACTE_PROCESADORA_TARJETA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_tarjeta_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_det_idColumnIndex))
						record.DEPOSITO_BANCARIO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_valor_idColumnIndex))
						record.ORDEN_PAGO_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(cambio_divisa_det_idColumnIndex))
						record.CAMBIO_DIVISA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cambio_divisa_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_vario_det_idColumnIndex))
						record.MOVIMIENTO_VARIO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_vario_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_det_idColumnIndex))
						record.TRANSFERENCIA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valor_det_idColumnIndex))
						record.CUSTODIA_VALOR_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valor_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_pago_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_det_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(canje_valor_det_idColumnIndex))
						record.CANJE_VALOR_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canje_valor_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(canje_valor_val_idColumnIndex))
						record.CANJE_VALOR_VAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canje_valor_val_idColumnIndex)), 9);
					if(!reader.IsDBNull(desembolso_giro_idColumnIndex))
						record.DESEMBOLSO_GIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desembolso_giro_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valor_det_entrada_idColumnIndex))
						record.CUSTODIA_VALOR_DET_ENTRADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valor_det_entrada_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_cli_det_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_CLI_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_cli_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_caja_suc_det_idColumnIndex))
						record.TRANSFERENCIA_CAJA_SUC_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_caja_suc_det_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CAJAS_TESORERIA_MOVRow[])(recordList.ToArray(typeof(CTACTE_CAJAS_TESORERIA_MOVRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CAJAS_TESORERIA_MOVRow"/> object.</returns>
		protected virtual CTACTE_CAJAS_TESORERIA_MOVRow MapRow(DataRow row)
		{
			CTACTE_CAJAS_TESORERIA_MOVRow mappedObject = new CTACTE_CAJAS_TESORERIA_MOVRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "FECHA_OPERACION"
			dataColumn = dataTable.Columns["FECHA_OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_OPERACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_OPERACION_ID"
			dataColumn = dataTable.Columns["USUARIO_OPERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_OPERACION_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "INGRESO"
			dataColumn = dataTable.Columns["INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO = (decimal)row[dataColumn];
			// Column "EGRESO"
			dataColumn = dataTable.Columns["EGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO = (decimal)row[dataColumn];
			// Column "FECHA_INGRESO"
			dataColumn = dataTable.Columns["FECHA_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO = (System.DateTime)row[dataColumn];
			// Column "FECHA_EGRESO"
			dataColumn = dataTable.Columns["FECHA_EGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EGRESO = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA_TARJETA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_TARJETA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_TARJETA_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_DET_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_DET_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_VALOR_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_VALOR_ID = (decimal)row[dataColumn];
			// Column "CAMBIO_DIVISA_DET_ID"
			dataColumn = dataTable.Columns["CAMBIO_DIVISA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAMBIO_DIVISA_DET_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_VARIO_DET_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_VARIO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_VARIO_DET_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_DET_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_DET_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALOR_DET_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALOR_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALOR_DET_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_PAGO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_PAGO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_DET_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_DET_ID = (decimal)row[dataColumn];
			// Column "CANJE_VALOR_DET_ID"
			dataColumn = dataTable.Columns["CANJE_VALOR_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANJE_VALOR_DET_ID = (decimal)row[dataColumn];
			// Column "CANJE_VALOR_VAL_ID"
			dataColumn = dataTable.Columns["CANJE_VALOR_VAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANJE_VALOR_VAL_ID = (decimal)row[dataColumn];
			// Column "DESEMBOLSO_GIRO_ID"
			dataColumn = dataTable.Columns["DESEMBOLSO_GIRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_GIRO_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALOR_DET_ENTRADA_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALOR_DET_ENTRADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALOR_DET_ENTRADA_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_CLI_DET_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_CLI_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_CLI_DET_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_CAJA_SUC_DET_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_CAJA_SUC_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_CAJA_SUC_DET_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CAJAS_TESORERIA_MOV</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CAJAS_TESORERIA_MOV";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_OPERACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_OPERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INGRESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_EGRESO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_TARJETA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_VALOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CAMBIO_DIVISA_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_VARIO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALOR_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANJE_VALOR_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANJE_VALOR_VAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_GIRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALOR_DET_ENTRADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_CLI_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_CAJA_SUC_DET_ID", typeof(decimal));
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

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_OPERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_EGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROCESADORA_TARJETA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAMBIO_DIVISA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_VARIO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALOR_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANJE_VALOR_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANJE_VALOR_VAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESEMBOLSO_GIRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALOR_DET_ENTRADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_CLI_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_CAJA_SUC_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CAJAS_TESORERIA_MOVCollection_Base class
}  // End of namespace
