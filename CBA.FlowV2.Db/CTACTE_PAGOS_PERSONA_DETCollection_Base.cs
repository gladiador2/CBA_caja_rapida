// <fileinfo name="CTACTE_PAGOS_PERSONA_DETCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PERSONA_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PAGOS_PERSONA_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PERSONA_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_PAGO_PERSONA_IDColumnName = "CTACTE_PAGO_PERSONA_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string TARJETA_NROColumnName = "TARJETA_NRO";
		public const string TARJETA_VENCIMIENTOColumnName = "TARJETA_VENCIMIENTO";
		public const string TARJETA_TITULARColumnName = "TARJETA_TITULAR";
		public const string DEPOSITO_CTACTE_BANCARIAS_IDColumnName = "DEPOSITO_CTACTE_BANCARIAS_ID";
		public const string DEPOSITO_NRO_BOLETAColumnName = "DEPOSITO_NRO_BOLETA";
		public const string DEPOSITO_FECHAColumnName = "DEPOSITO_FECHA";
		public const string CHEQUE_CTACTE_BANCO_IDColumnName = "CHEQUE_CTACTE_BANCO_ID";
		public const string CHEQUE_FECHA_POSDATADOColumnName = "CHEQUE_FECHA_POSDATADO";
		public const string CHEQUE_FECHA_VENCIMIENTOColumnName = "CHEQUE_FECHA_VENCIMIENTO";
		public const string CHEQUE_NOMBRE_EMISORColumnName = "CHEQUE_NOMBRE_EMISOR";
		public const string CHEQUE_NOMBRE_BENEFICIARIOColumnName = "CHEQUE_NOMBRE_BENEFICIARIO";
		public const string CHEQUE_NRO_CUENTAColumnName = "CHEQUE_NRO_CUENTA";
		public const string CHEQUE_NRO_CHEQUEColumnName = "CHEQUE_NRO_CHEQUE";
		public const string CHEQUE_DE_TERCEROSColumnName = "CHEQUE_DE_TERCEROS";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string CTACTE_PROCESADORA_TARJETA_IDColumnName = "CTACTE_PROCESADORA_TARJETA_ID";
		public const string ANTICIPO_IDColumnName = "ANTICIPO_ID";
		public const string TRANSFERENCIA_BANCARIA_IDColumnName = "TRANSFERENCIA_BANCARIA_ID";
		public const string DEPOSITO_BANCARIO_IDColumnName = "DEPOSITO_BANCARIO_ID";
		public const string NOTA_CREDITO_IDColumnName = "NOTA_CREDITO_ID";
		public const string RETENCION_NRO_COMPROBANTEColumnName = "RETENCION_NRO_COMPROBANTE";
		public const string RETENCION_OBSERVACIONColumnName = "RETENCION_OBSERVACION";
		public const string RETENCION_CASO_IDColumnName = "RETENCION_CASO_ID";
		public const string RETENCION_FECHAColumnName = "RETENCION_FECHA";
		public const string RETENCION_IDColumnName = "RETENCION_ID";
		public const string RETENCION_DETALLE_IDColumnName = "RETENCION_DETALLE_ID";
		public const string CHEQUE_DOCUMENTO_EMISORColumnName = "CHEQUE_DOCUMENTO_EMISOR";
		public const string TRANSFERENCIA_CTACTE_PERS_IDColumnName = "TRANSFERENCIA_CTACTE_PERS_ID";
		public const string CTACTE_RED_PAGO_IDColumnName = "CTACTE_RED_PAGO_ID";
		public const string CTACTE_PLAN_DESEMBOLSO_IDColumnName = "CTACTE_PLAN_DESEMBOLSO_ID";
		public const string GIRO_COMPROBANTEColumnName = "GIRO_COMPROBANTE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string CTACTE_GIRO_IDColumnName = "CTACTE_GIRO_ID";
		public const string RETENCION_TIMBRADOColumnName = "RETENCION_TIMBRADO";
		public const string CHEQUE_ES_DIFERIDOColumnName = "CHEQUE_ES_DIFERIDO";
		public const string ESTADOColumnName = "ESTADO";
		public const string RETENCION_TIPO_IDColumnName = "RETENCION_TIPO_ID";
		public const string RETENCION_PORCENTAJEColumnName = "RETENCION_PORCENTAJE";
		public const string POS_IDColumnName = "POS_ID";
		public const string MONTO_NETOColumnName = "MONTO_NETO";
		public const string FECHA_ACREDITACIONColumnName = "FECHA_ACREDITACION";
		public const string TRANSFERENCIA_CAJA_SUCURSAL_IDColumnName = "TRANSFERENCIA_CAJA_SUCURSAL_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PERSONA_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PAGOS_PERSONA_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PAGOS_PERSONA_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PAGOS_PERSONA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PAGOS_PERSONA_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByANTICIPO_ID(decimal anticipo_id)
		{
			return GetByANTICIPO_ID(anticipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <param name="anticipo_idNull">true if the method ignores the anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByANTICIPO_ID(decimal anticipo_id, bool anticipo_idNull)
		{
			return MapRecords(CreateGetByANTICIPO_IDCommand(anticipo_id, anticipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByANTICIPO_IDAsDataTable(decimal anticipo_id)
		{
			return GetByANTICIPO_IDAsDataTable(anticipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <param name="anticipo_idNull">true if the method ignores the anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByANTICIPO_IDAsDataTable(decimal anticipo_id, bool anticipo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByANTICIPO_IDCommand(anticipo_id, anticipo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <param name="anticipo_idNull">true if the method ignores the anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByANTICIPO_IDCommand(decimal anticipo_id, bool anticipo_idNull)
		{
			string whereSql = "";
			if(anticipo_idNull)
				whereSql += "ANTICIPO_ID IS NULL";
			else
				whereSql += "ANTICIPO_ID=" + _db.CreateSqlParameterName("ANTICIPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!anticipo_idNull)
				AddParameter(cmd, "ANTICIPO_ID", anticipo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id)
		{
			return GetByCHEQUE_CTACTE_BANCO_ID(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return MapRecords(CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(decimal cheque_ctacte_banco_id)
		{
			return GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCHEQUE_CTACTE_BANCO_IDAsDataTable(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCHEQUE_CTACTE_BANCO_IDCommand(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			string whereSql = "";
			if(cheque_ctacte_banco_idNull)
				whereSql += "CHEQUE_CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cheque_ctacte_banco_idNull)
				AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID", cheque_ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByDEPOSITO_CTACTE_BANCARIAS_ID(decimal deposito_ctacte_bancarias_id)
		{
			return GetByDEPOSITO_CTACTE_BANCARIAS_ID(deposito_ctacte_bancarias_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <param name="deposito_ctacte_bancarias_idNull">true if the method ignores the deposito_ctacte_bancarias_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByDEPOSITO_CTACTE_BANCARIAS_ID(decimal deposito_ctacte_bancarias_id, bool deposito_ctacte_bancarias_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_CTACTE_BANCARIAS_IDCommand(deposito_ctacte_bancarias_id, deposito_ctacte_bancarias_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_CTACTE_BANCARIAS_IDAsDataTable(decimal deposito_ctacte_bancarias_id)
		{
			return GetByDEPOSITO_CTACTE_BANCARIAS_IDAsDataTable(deposito_ctacte_bancarias_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <param name="deposito_ctacte_bancarias_idNull">true if the method ignores the deposito_ctacte_bancarias_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_CTACTE_BANCARIAS_IDAsDataTable(decimal deposito_ctacte_bancarias_id, bool deposito_ctacte_bancarias_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_CTACTE_BANCARIAS_IDCommand(deposito_ctacte_bancarias_id, deposito_ctacte_bancarias_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <param name="deposito_ctacte_bancarias_idNull">true if the method ignores the deposito_ctacte_bancarias_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_CTACTE_BANCARIAS_IDCommand(decimal deposito_ctacte_bancarias_id, bool deposito_ctacte_bancarias_idNull)
		{
			string whereSql = "";
			if(deposito_ctacte_bancarias_idNull)
				whereSql += "DEPOSITO_CTACTE_BANCARIAS_ID IS NULL";
			else
				whereSql += "DEPOSITO_CTACTE_BANCARIAS_ID=" + _db.CreateSqlParameterName("DEPOSITO_CTACTE_BANCARIAS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_ctacte_bancarias_idNull)
				AddParameter(cmd, "DEPOSITO_CTACTE_BANCARIAS_ID", deposito_ctacte_bancarias_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <param name="ctacte_cheque_recibido_idNull">true if the method ignores the ctacte_cheque_recibido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id, bool ctacte_cheque_recibido_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CHEQUE_RECIBIDO_IDCommand(ctacte_cheque_recibido_id, ctacte_cheque_recibido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(decimal ctacte_cheque_recibido_id)
		{
			return GetByCTACTE_CHEQUE_RECIBIDO_IDAsDataTable(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_BANCARIO_IDAsDataTable(decimal deposito_bancario_id)
		{
			return GetByDEPOSITO_BANCARIO_IDAsDataTable(deposito_bancario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_BANCARIO_IDAsDataTable(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_BANCARIO_IDCommand(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_idNull)
				whereSql += "DEPOSITO_BANCARIO_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_bancario_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_ID", deposito_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_MON</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByNOTA_CREDITO_ID(decimal nota_credito_id)
		{
			return GetByNOTA_CREDITO_ID(nota_credito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByNOTA_CREDITO_ID(decimal nota_credito_id, bool nota_credito_idNull)
		{
			return MapRecords(CreateGetByNOTA_CREDITO_IDCommand(nota_credito_id, nota_credito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNOTA_CREDITO_IDAsDataTable(decimal nota_credito_id)
		{
			return GetByNOTA_CREDITO_IDAsDataTable(nota_credito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNOTA_CREDITO_IDAsDataTable(decimal nota_credito_id, bool nota_credito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNOTA_CREDITO_IDCommand(nota_credito_id, nota_credito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNOTA_CREDITO_IDCommand(decimal nota_credito_id, bool nota_credito_idNull)
		{
			string whereSql = "";
			if(nota_credito_idNull)
				whereSql += "NOTA_CREDITO_ID IS NULL";
			else
				whereSql += "NOTA_CREDITO_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nota_credito_idNull)
				AddParameter(cmd, "NOTA_CREDITO_ID", nota_credito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_PAGO_PERSONA_ID(decimal ctacte_pago_persona_id)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_IDCommand(ctacte_pago_persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_IDAsDataTable(decimal ctacte_pago_persona_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_IDCommand(ctacte_pago_persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_IDCommand(decimal ctacte_pago_persona_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PAGO_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID", ctacte_pago_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByRETENCION_DETALLE_ID(decimal retencion_detalle_id)
		{
			return GetByRETENCION_DETALLE_ID(retencion_detalle_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <param name="retencion_detalle_idNull">true if the method ignores the retencion_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByRETENCION_DETALLE_ID(decimal retencion_detalle_id, bool retencion_detalle_idNull)
		{
			return MapRecords(CreateGetByRETENCION_DETALLE_IDCommand(retencion_detalle_id, retencion_detalle_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_DETALLE_IDAsDataTable(decimal retencion_detalle_id)
		{
			return GetByRETENCION_DETALLE_IDAsDataTable(retencion_detalle_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <param name="retencion_detalle_idNull">true if the method ignores the retencion_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRETENCION_DETALLE_IDAsDataTable(decimal retencion_detalle_id, bool retencion_detalle_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRETENCION_DETALLE_IDCommand(retencion_detalle_id, retencion_detalle_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <param name="retencion_detalle_idNull">true if the method ignores the retencion_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRETENCION_DETALLE_IDCommand(decimal retencion_detalle_id, bool retencion_detalle_idNull)
		{
			string whereSql = "";
			if(retencion_detalle_idNull)
				whereSql += "RETENCION_DETALLE_ID IS NULL";
			else
				whereSql += "RETENCION_DETALLE_ID=" + _db.CreateSqlParameterName("RETENCION_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!retencion_detalle_idNull)
				AddParameter(cmd, "RETENCION_DETALLE_ID", retencion_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByRETENCION_TIPO_ID(decimal retencion_tipo_id)
		{
			return GetByRETENCION_TIPO_ID(retencion_tipo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <param name="retencion_tipo_idNull">true if the method ignores the retencion_tipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByRETENCION_TIPO_ID(decimal retencion_tipo_id, bool retencion_tipo_idNull)
		{
			return MapRecords(CreateGetByRETENCION_TIPO_IDCommand(retencion_tipo_id, retencion_tipo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRETENCION_TIPO_IDAsDataTable(decimal retencion_tipo_id)
		{
			return GetByRETENCION_TIPO_IDAsDataTable(retencion_tipo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <param name="ctacte_procesadora_tarjeta_idNull">true if the method ignores the ctacte_procesadora_tarjeta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id, bool ctacte_procesadora_tarjeta_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROCESADORA_TARJETA_IDCommand(ctacte_procesadora_tarjeta_id, ctacte_procesadora_tarjeta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(decimal ctacte_procesadora_tarjeta_id)
		{
			return GetByCTACTE_PROCESADORA_TARJETA_IDAsDataTable(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByTRANSFERENCIA_CTACTE_PERS_ID(decimal transferencia_ctacte_pers_id)
		{
			return GetByTRANSFERENCIA_CTACTE_PERS_ID(transferencia_ctacte_pers_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <param name="transferencia_ctacte_pers_idNull">true if the method ignores the transferencia_ctacte_pers_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByTRANSFERENCIA_CTACTE_PERS_ID(decimal transferencia_ctacte_pers_id, bool transferencia_ctacte_pers_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_CTACTE_PERS_IDCommand(transferencia_ctacte_pers_id, transferencia_ctacte_pers_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_CTACTE_PERS_IDAsDataTable(decimal transferencia_ctacte_pers_id)
		{
			return GetByTRANSFERENCIA_CTACTE_PERS_IDAsDataTable(transferencia_ctacte_pers_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <param name="transferencia_ctacte_pers_idNull">true if the method ignores the transferencia_ctacte_pers_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_CTACTE_PERS_IDAsDataTable(decimal transferencia_ctacte_pers_id, bool transferencia_ctacte_pers_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_CTACTE_PERS_IDCommand(transferencia_ctacte_pers_id, transferencia_ctacte_pers_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <param name="transferencia_ctacte_pers_idNull">true if the method ignores the transferencia_ctacte_pers_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_CTACTE_PERS_IDCommand(decimal transferencia_ctacte_pers_id, bool transferencia_ctacte_pers_idNull)
		{
			string whereSql = "";
			if(transferencia_ctacte_pers_idNull)
				whereSql += "TRANSFERENCIA_CTACTE_PERS_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CTACTE_PERS_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CTACTE_PERS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_ctacte_pers_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CTACTE_PERS_ID", transferencia_ctacte_pers_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <param name="transferencia_bancaria_idNull">true if the method ignores the transferencia_bancaria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id, bool transferencia_bancaria_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_BANCARIA_IDCommand(transferencia_bancaria_id, transferencia_bancaria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(decimal transferencia_bancaria_id)
		{
			return GetByTRANSFERENCIA_BANCARIA_IDAsDataTable(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByTRANSFERENCIA_CAJA_SUCURSAL_ID(decimal transferencia_caja_sucursal_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUCURSAL_ID(transferencia_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="transferencia_caja_sucursal_idNull">true if the method ignores the transferencia_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByTRANSFERENCIA_CAJA_SUCURSAL_ID(decimal transferencia_caja_sucursal_id, bool transferencia_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_CAJA_SUCURSAL_IDCommand(transferencia_caja_sucursal_id, transferencia_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_CAJA_SUCURSAL_IDAsDataTable(decimal transferencia_caja_sucursal_id)
		{
			return GetByTRANSFERENCIA_CAJA_SUCURSAL_IDAsDataTable(transferencia_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="transferencia_caja_sucursal_idNull">true if the method ignores the transferencia_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_CAJA_SUCURSAL_IDAsDataTable(decimal transferencia_caja_sucursal_id, bool transferencia_caja_sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_CAJA_SUCURSAL_IDCommand(transferencia_caja_sucursal_id, transferencia_caja_sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="transferencia_caja_sucursal_idNull">true if the method ignores the transferencia_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_CAJA_SUCURSAL_IDCommand(decimal transferencia_caja_sucursal_id, bool transferencia_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(transferencia_caja_sucursal_idNull)
				whereSql += "TRANSFERENCIA_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_caja_sucursal_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CAJA_SUCURSAL_ID", transferencia_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_DET_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_DET_VAL</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_GIRO_ID(decimal ctacte_giro_id)
		{
			return GetByCTACTE_GIRO_ID(ctacte_giro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_GIRO_ID(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			return MapRecords(CreateGetByCTACTE_GIRO_IDCommand(ctacte_giro_id, ctacte_giro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_GIRO_IDAsDataTable(decimal ctacte_giro_id)
		{
			return GetByCTACTE_GIRO_IDAsDataTable(ctacte_giro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_GIRO_IDAsDataTable(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_GIRO_IDCommand(ctacte_giro_id, ctacte_giro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_GIRO_IDCommand(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			string whereSql = "";
			if(ctacte_giro_idNull)
				whereSql += "CTACTE_GIRO_ID IS NULL";
			else
				whereSql += "CTACTE_GIRO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_giro_idNull)
				AddParameter(cmd, "CTACTE_GIRO_ID", ctacte_giro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_PLAN_DESEMBOLSO_ID(decimal ctacte_plan_desembolso_id)
		{
			return GetByCTACTE_PLAN_DESEMBOLSO_ID(ctacte_plan_desembolso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="ctacte_plan_desembolso_idNull">true if the method ignores the ctacte_plan_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_PLAN_DESEMBOLSO_ID(decimal ctacte_plan_desembolso_id, bool ctacte_plan_desembolso_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PLAN_DESEMBOLSO_IDCommand(ctacte_plan_desembolso_id, ctacte_plan_desembolso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PLAN_DESEMBOLSO_IDAsDataTable(decimal ctacte_plan_desembolso_id)
		{
			return GetByCTACTE_PLAN_DESEMBOLSO_IDAsDataTable(ctacte_plan_desembolso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="ctacte_plan_desembolso_idNull">true if the method ignores the ctacte_plan_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PLAN_DESEMBOLSO_IDAsDataTable(decimal ctacte_plan_desembolso_id, bool ctacte_plan_desembolso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PLAN_DESEMBOLSO_IDCommand(ctacte_plan_desembolso_id, ctacte_plan_desembolso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="ctacte_plan_desembolso_idNull">true if the method ignores the ctacte_plan_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PLAN_DESEMBOLSO_IDCommand(decimal ctacte_plan_desembolso_id, bool ctacte_plan_desembolso_idNull)
		{
			string whereSql = "";
			if(ctacte_plan_desembolso_idNull)
				whereSql += "CTACTE_PLAN_DESEMBOLSO_ID IS NULL";
			else
				whereSql += "CTACTE_PLAN_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CTACTE_PLAN_DESEMBOLSO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_plan_desembolso_idNull)
				AddParameter(cmd, "CTACTE_PLAN_DESEMBOLSO_ID", ctacte_plan_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByPOS_ID(decimal pos_id)
		{
			return GetByPOS_ID(pos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <param name="pos_idNull">true if the method ignores the pos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByPOS_ID(decimal pos_id, bool pos_idNull)
		{
			return MapRecords(CreateGetByPOS_IDCommand(pos_id, pos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPOS_IDAsDataTable(decimal pos_id)
		{
			return GetByPOS_IDAsDataTable(pos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <param name="pos_idNull">true if the method ignores the pos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPOS_IDAsDataTable(decimal pos_id, bool pos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPOS_IDCommand(pos_id, pos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <param name="pos_idNull">true if the method ignores the pos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPOS_IDCommand(decimal pos_id, bool pos_idNull)
		{
			string whereSql = "";
			if(pos_idNull)
				whereSql += "POS_ID IS NULL";
			else
				whereSql += "POS_ID=" + _db.CreateSqlParameterName("POS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pos_idNull)
				AddParameter(cmd, "POS_ID", pos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects 
		/// by the <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <param name="ctacte_red_pago_idNull">true if the method ignores the ctacte_red_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_DETRow[] GetByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id, bool ctacte_red_pago_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RED_PAGO_IDCommand(ctacte_red_pago_id, ctacte_red_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RED_PAGO_IDAsDataTable(decimal ctacte_red_pago_id)
		{
			return GetByCTACTE_RED_PAGO_IDAsDataTable(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PAGOS_PERSONA_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PAGOS_PERSONA_DET (" +
				"ID, " +
				"CTACTE_PAGO_PERSONA_ID, " +
				"CTACTE_VALOR_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO, " +
				"TARJETA_NRO, " +
				"TARJETA_VENCIMIENTO, " +
				"TARJETA_TITULAR, " +
				"DEPOSITO_CTACTE_BANCARIAS_ID, " +
				"DEPOSITO_NRO_BOLETA, " +
				"DEPOSITO_FECHA, " +
				"CHEQUE_CTACTE_BANCO_ID, " +
				"CHEQUE_FECHA_POSDATADO, " +
				"CHEQUE_FECHA_VENCIMIENTO, " +
				"CHEQUE_NOMBRE_EMISOR, " +
				"CHEQUE_NOMBRE_BENEFICIARIO, " +
				"CHEQUE_NRO_CUENTA, " +
				"CHEQUE_NRO_CHEQUE, " +
				"CHEQUE_DE_TERCEROS, " +
				"CTACTE_CHEQUE_RECIBIDO_ID, " +
				"CTACTE_PROCESADORA_TARJETA_ID, " +
				"ANTICIPO_ID, " +
				"TRANSFERENCIA_BANCARIA_ID, " +
				"DEPOSITO_BANCARIO_ID, " +
				"NOTA_CREDITO_ID, " +
				"RETENCION_NRO_COMPROBANTE, " +
				"RETENCION_OBSERVACION, " +
				"RETENCION_CASO_ID, " +
				"RETENCION_FECHA, " +
				"RETENCION_ID, " +
				"RETENCION_DETALLE_ID, " +
				"CHEQUE_DOCUMENTO_EMISOR, " +
				"TRANSFERENCIA_CTACTE_PERS_ID, " +
				"CTACTE_RED_PAGO_ID, " +
				"CTACTE_PLAN_DESEMBOLSO_ID, " +
				"GIRO_COMPROBANTE, " +
				"OBSERVACIONES, " +
				"CTACTE_GIRO_ID, " +
				"RETENCION_TIMBRADO, " +
				"CHEQUE_ES_DIFERIDO, " +
				"ESTADO, " +
				"RETENCION_TIPO_ID, " +
				"RETENCION_PORCENTAJE, " +
				"POS_ID, " +
				"MONTO_NETO, " +
				"FECHA_ACREDITACION, " +
				"TRANSFERENCIA_CAJA_SUCURSAL_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("TARJETA_NRO") + ", " +
				_db.CreateSqlParameterName("TARJETA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("TARJETA_TITULAR") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_CTACTE_BANCARIAS_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_NRO_BOLETA") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_FECHA") + ", " +
				_db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID") + ", " +
				_db.CreateSqlParameterName("CHEQUE_FECHA_POSDATADO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NOMBRE_EMISOR") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NOMBRE_BENEFICIARIO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NRO_CUENTA") + ", " +
				_db.CreateSqlParameterName("CHEQUE_NRO_CHEQUE") + ", " +
				_db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				_db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") + ", " +
				_db.CreateSqlParameterName("ANTICIPO_ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				_db.CreateSqlParameterName("NOTA_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("RETENCION_OBSERVACION") + ", " +
				_db.CreateSqlParameterName("RETENCION_CASO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_FECHA") + ", " +
				_db.CreateSqlParameterName("RETENCION_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("CHEQUE_DOCUMENTO_EMISOR") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_CTACTE_PERS_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PLAN_DESEMBOLSO_ID") + ", " +
				_db.CreateSqlParameterName("GIRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("CTACTE_GIRO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_TIMBRADO") + ", " +
				_db.CreateSqlParameterName("CHEQUE_ES_DIFERIDO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("RETENCION_TIPO_ID") + ", " +
				_db.CreateSqlParameterName("RETENCION_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("POS_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_NETO") + ", " +
				_db.CreateSqlParameterName("FECHA_ACREDITACION") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUCURSAL_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID", value.CTACTE_PAGO_PERSONA_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "TARJETA_NRO", value.TARJETA_NRO);
			AddParameter(cmd, "TARJETA_VENCIMIENTO",
				value.IsTARJETA_VENCIMIENTONull ? DBNull.Value : (object)value.TARJETA_VENCIMIENTO);
			AddParameter(cmd, "TARJETA_TITULAR", value.TARJETA_TITULAR);
			AddParameter(cmd, "DEPOSITO_CTACTE_BANCARIAS_ID",
				value.IsDEPOSITO_CTACTE_BANCARIAS_IDNull ? DBNull.Value : (object)value.DEPOSITO_CTACTE_BANCARIAS_ID);
			AddParameter(cmd, "DEPOSITO_NRO_BOLETA", value.DEPOSITO_NRO_BOLETA);
			AddParameter(cmd, "DEPOSITO_FECHA",
				value.IsDEPOSITO_FECHANull ? DBNull.Value : (object)value.DEPOSITO_FECHA);
			AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID",
				value.IsCHEQUE_CTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CHEQUE_CTACTE_BANCO_ID);
			AddParameter(cmd, "CHEQUE_FECHA_POSDATADO",
				value.IsCHEQUE_FECHA_POSDATADONull ? DBNull.Value : (object)value.CHEQUE_FECHA_POSDATADO);
			AddParameter(cmd, "CHEQUE_FECHA_VENCIMIENTO",
				value.IsCHEQUE_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CHEQUE_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CHEQUE_NOMBRE_EMISOR", value.CHEQUE_NOMBRE_EMISOR);
			AddParameter(cmd, "CHEQUE_NOMBRE_BENEFICIARIO", value.CHEQUE_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CHEQUE_NRO_CUENTA", value.CHEQUE_NRO_CUENTA);
			AddParameter(cmd, "CHEQUE_NRO_CHEQUE", value.CHEQUE_NRO_CHEQUE);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			AddParameter(cmd, "ANTICIPO_ID",
				value.IsANTICIPO_IDNull ? DBNull.Value : (object)value.ANTICIPO_ID);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "NOTA_CREDITO_ID",
				value.IsNOTA_CREDITO_IDNull ? DBNull.Value : (object)value.NOTA_CREDITO_ID);
			AddParameter(cmd, "RETENCION_NRO_COMPROBANTE", value.RETENCION_NRO_COMPROBANTE);
			AddParameter(cmd, "RETENCION_OBSERVACION", value.RETENCION_OBSERVACION);
			AddParameter(cmd, "RETENCION_CASO_ID",
				value.IsRETENCION_CASO_IDNull ? DBNull.Value : (object)value.RETENCION_CASO_ID);
			AddParameter(cmd, "RETENCION_FECHA",
				value.IsRETENCION_FECHANull ? DBNull.Value : (object)value.RETENCION_FECHA);
			AddParameter(cmd, "RETENCION_ID",
				value.IsRETENCION_IDNull ? DBNull.Value : (object)value.RETENCION_ID);
			AddParameter(cmd, "RETENCION_DETALLE_ID",
				value.IsRETENCION_DETALLE_IDNull ? DBNull.Value : (object)value.RETENCION_DETALLE_ID);
			AddParameter(cmd, "CHEQUE_DOCUMENTO_EMISOR", value.CHEQUE_DOCUMENTO_EMISOR);
			AddParameter(cmd, "TRANSFERENCIA_CTACTE_PERS_ID",
				value.IsTRANSFERENCIA_CTACTE_PERS_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CTACTE_PERS_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "CTACTE_PLAN_DESEMBOLSO_ID",
				value.IsCTACTE_PLAN_DESEMBOLSO_IDNull ? DBNull.Value : (object)value.CTACTE_PLAN_DESEMBOLSO_ID);
			AddParameter(cmd, "GIRO_COMPROBANTE", value.GIRO_COMPROBANTE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CTACTE_GIRO_ID",
				value.IsCTACTE_GIRO_IDNull ? DBNull.Value : (object)value.CTACTE_GIRO_ID);
			AddParameter(cmd, "RETENCION_TIMBRADO", value.RETENCION_TIMBRADO);
			AddParameter(cmd, "CHEQUE_ES_DIFERIDO", value.CHEQUE_ES_DIFERIDO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RETENCION_TIPO_ID",
				value.IsRETENCION_TIPO_IDNull ? DBNull.Value : (object)value.RETENCION_TIPO_ID);
			AddParameter(cmd, "RETENCION_PORCENTAJE",
				value.IsRETENCION_PORCENTAJENull ? DBNull.Value : (object)value.RETENCION_PORCENTAJE);
			AddParameter(cmd, "POS_ID",
				value.IsPOS_IDNull ? DBNull.Value : (object)value.POS_ID);
			AddParameter(cmd, "MONTO_NETO",
				value.IsMONTO_NETONull ? DBNull.Value : (object)value.MONTO_NETO);
			AddParameter(cmd, "FECHA_ACREDITACION",
				value.IsFECHA_ACREDITACIONNull ? DBNull.Value : (object)value.FECHA_ACREDITACION);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUCURSAL_ID",
				value.IsTRANSFERENCIA_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUCURSAL_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PERSONA_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PAGOS_PERSONA_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PAGOS_PERSONA_DET SET " +
				"CTACTE_PAGO_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"TARJETA_NRO=" + _db.CreateSqlParameterName("TARJETA_NRO") + ", " +
				"TARJETA_VENCIMIENTO=" + _db.CreateSqlParameterName("TARJETA_VENCIMIENTO") + ", " +
				"TARJETA_TITULAR=" + _db.CreateSqlParameterName("TARJETA_TITULAR") + ", " +
				"DEPOSITO_CTACTE_BANCARIAS_ID=" + _db.CreateSqlParameterName("DEPOSITO_CTACTE_BANCARIAS_ID") + ", " +
				"DEPOSITO_NRO_BOLETA=" + _db.CreateSqlParameterName("DEPOSITO_NRO_BOLETA") + ", " +
				"DEPOSITO_FECHA=" + _db.CreateSqlParameterName("DEPOSITO_FECHA") + ", " +
				"CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID") + ", " +
				"CHEQUE_FECHA_POSDATADO=" + _db.CreateSqlParameterName("CHEQUE_FECHA_POSDATADO") + ", " +
				"CHEQUE_FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("CHEQUE_FECHA_VENCIMIENTO") + ", " +
				"CHEQUE_NOMBRE_EMISOR=" + _db.CreateSqlParameterName("CHEQUE_NOMBRE_EMISOR") + ", " +
				"CHEQUE_NOMBRE_BENEFICIARIO=" + _db.CreateSqlParameterName("CHEQUE_NOMBRE_BENEFICIARIO") + ", " +
				"CHEQUE_NRO_CUENTA=" + _db.CreateSqlParameterName("CHEQUE_NRO_CUENTA") + ", " +
				"CHEQUE_NRO_CHEQUE=" + _db.CreateSqlParameterName("CHEQUE_NRO_CHEQUE") + ", " +
				"CHEQUE_DE_TERCEROS=" + _db.CreateSqlParameterName("CHEQUE_DE_TERCEROS") + ", " +
				"CTACTE_CHEQUE_RECIBIDO_ID=" + _db.CreateSqlParameterName("CTACTE_CHEQUE_RECIBIDO_ID") + ", " +
				"CTACTE_PROCESADORA_TARJETA_ID=" + _db.CreateSqlParameterName("CTACTE_PROCESADORA_TARJETA_ID") + ", " +
				"ANTICIPO_ID=" + _db.CreateSqlParameterName("ANTICIPO_ID") + ", " +
				"TRANSFERENCIA_BANCARIA_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BANCARIA_ID") + ", " +
				"DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID") + ", " +
				"NOTA_CREDITO_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_ID") + ", " +
				"RETENCION_NRO_COMPROBANTE=" + _db.CreateSqlParameterName("RETENCION_NRO_COMPROBANTE") + ", " +
				"RETENCION_OBSERVACION=" + _db.CreateSqlParameterName("RETENCION_OBSERVACION") + ", " +
				"RETENCION_CASO_ID=" + _db.CreateSqlParameterName("RETENCION_CASO_ID") + ", " +
				"RETENCION_FECHA=" + _db.CreateSqlParameterName("RETENCION_FECHA") + ", " +
				"RETENCION_ID=" + _db.CreateSqlParameterName("RETENCION_ID") + ", " +
				"RETENCION_DETALLE_ID=" + _db.CreateSqlParameterName("RETENCION_DETALLE_ID") + ", " +
				"CHEQUE_DOCUMENTO_EMISOR=" + _db.CreateSqlParameterName("CHEQUE_DOCUMENTO_EMISOR") + ", " +
				"TRANSFERENCIA_CTACTE_PERS_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CTACTE_PERS_ID") + ", " +
				"CTACTE_RED_PAGO_ID=" + _db.CreateSqlParameterName("CTACTE_RED_PAGO_ID") + ", " +
				"CTACTE_PLAN_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CTACTE_PLAN_DESEMBOLSO_ID") + ", " +
				"GIRO_COMPROBANTE=" + _db.CreateSqlParameterName("GIRO_COMPROBANTE") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"CTACTE_GIRO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_ID") + ", " +
				"RETENCION_TIMBRADO=" + _db.CreateSqlParameterName("RETENCION_TIMBRADO") + ", " +
				"CHEQUE_ES_DIFERIDO=" + _db.CreateSqlParameterName("CHEQUE_ES_DIFERIDO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"RETENCION_TIPO_ID=" + _db.CreateSqlParameterName("RETENCION_TIPO_ID") + ", " +
				"RETENCION_PORCENTAJE=" + _db.CreateSqlParameterName("RETENCION_PORCENTAJE") + ", " +
				"POS_ID=" + _db.CreateSqlParameterName("POS_ID") + ", " +
				"MONTO_NETO=" + _db.CreateSqlParameterName("MONTO_NETO") + ", " +
				"FECHA_ACREDITACION=" + _db.CreateSqlParameterName("FECHA_ACREDITACION") + ", " +
				"TRANSFERENCIA_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUCURSAL_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID", value.CTACTE_PAGO_PERSONA_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID", value.CTACTE_VALOR_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO",
				value.IsMONTONull ? DBNull.Value : (object)value.MONTO);
			AddParameter(cmd, "TARJETA_NRO", value.TARJETA_NRO);
			AddParameter(cmd, "TARJETA_VENCIMIENTO",
				value.IsTARJETA_VENCIMIENTONull ? DBNull.Value : (object)value.TARJETA_VENCIMIENTO);
			AddParameter(cmd, "TARJETA_TITULAR", value.TARJETA_TITULAR);
			AddParameter(cmd, "DEPOSITO_CTACTE_BANCARIAS_ID",
				value.IsDEPOSITO_CTACTE_BANCARIAS_IDNull ? DBNull.Value : (object)value.DEPOSITO_CTACTE_BANCARIAS_ID);
			AddParameter(cmd, "DEPOSITO_NRO_BOLETA", value.DEPOSITO_NRO_BOLETA);
			AddParameter(cmd, "DEPOSITO_FECHA",
				value.IsDEPOSITO_FECHANull ? DBNull.Value : (object)value.DEPOSITO_FECHA);
			AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID",
				value.IsCHEQUE_CTACTE_BANCO_IDNull ? DBNull.Value : (object)value.CHEQUE_CTACTE_BANCO_ID);
			AddParameter(cmd, "CHEQUE_FECHA_POSDATADO",
				value.IsCHEQUE_FECHA_POSDATADONull ? DBNull.Value : (object)value.CHEQUE_FECHA_POSDATADO);
			AddParameter(cmd, "CHEQUE_FECHA_VENCIMIENTO",
				value.IsCHEQUE_FECHA_VENCIMIENTONull ? DBNull.Value : (object)value.CHEQUE_FECHA_VENCIMIENTO);
			AddParameter(cmd, "CHEQUE_NOMBRE_EMISOR", value.CHEQUE_NOMBRE_EMISOR);
			AddParameter(cmd, "CHEQUE_NOMBRE_BENEFICIARIO", value.CHEQUE_NOMBRE_BENEFICIARIO);
			AddParameter(cmd, "CHEQUE_NRO_CUENTA", value.CHEQUE_NRO_CUENTA);
			AddParameter(cmd, "CHEQUE_NRO_CHEQUE", value.CHEQUE_NRO_CHEQUE);
			AddParameter(cmd, "CHEQUE_DE_TERCEROS", value.CHEQUE_DE_TERCEROS);
			AddParameter(cmd, "CTACTE_CHEQUE_RECIBIDO_ID",
				value.IsCTACTE_CHEQUE_RECIBIDO_IDNull ? DBNull.Value : (object)value.CTACTE_CHEQUE_RECIBIDO_ID);
			AddParameter(cmd, "CTACTE_PROCESADORA_TARJETA_ID",
				value.IsCTACTE_PROCESADORA_TARJETA_IDNull ? DBNull.Value : (object)value.CTACTE_PROCESADORA_TARJETA_ID);
			AddParameter(cmd, "ANTICIPO_ID",
				value.IsANTICIPO_IDNull ? DBNull.Value : (object)value.ANTICIPO_ID);
			AddParameter(cmd, "TRANSFERENCIA_BANCARIA_ID",
				value.IsTRANSFERENCIA_BANCARIA_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BANCARIA_ID);
			AddParameter(cmd, "DEPOSITO_BANCARIO_ID",
				value.IsDEPOSITO_BANCARIO_IDNull ? DBNull.Value : (object)value.DEPOSITO_BANCARIO_ID);
			AddParameter(cmd, "NOTA_CREDITO_ID",
				value.IsNOTA_CREDITO_IDNull ? DBNull.Value : (object)value.NOTA_CREDITO_ID);
			AddParameter(cmd, "RETENCION_NRO_COMPROBANTE", value.RETENCION_NRO_COMPROBANTE);
			AddParameter(cmd, "RETENCION_OBSERVACION", value.RETENCION_OBSERVACION);
			AddParameter(cmd, "RETENCION_CASO_ID",
				value.IsRETENCION_CASO_IDNull ? DBNull.Value : (object)value.RETENCION_CASO_ID);
			AddParameter(cmd, "RETENCION_FECHA",
				value.IsRETENCION_FECHANull ? DBNull.Value : (object)value.RETENCION_FECHA);
			AddParameter(cmd, "RETENCION_ID",
				value.IsRETENCION_IDNull ? DBNull.Value : (object)value.RETENCION_ID);
			AddParameter(cmd, "RETENCION_DETALLE_ID",
				value.IsRETENCION_DETALLE_IDNull ? DBNull.Value : (object)value.RETENCION_DETALLE_ID);
			AddParameter(cmd, "CHEQUE_DOCUMENTO_EMISOR", value.CHEQUE_DOCUMENTO_EMISOR);
			AddParameter(cmd, "TRANSFERENCIA_CTACTE_PERS_ID",
				value.IsTRANSFERENCIA_CTACTE_PERS_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CTACTE_PERS_ID);
			AddParameter(cmd, "CTACTE_RED_PAGO_ID",
				value.IsCTACTE_RED_PAGO_IDNull ? DBNull.Value : (object)value.CTACTE_RED_PAGO_ID);
			AddParameter(cmd, "CTACTE_PLAN_DESEMBOLSO_ID",
				value.IsCTACTE_PLAN_DESEMBOLSO_IDNull ? DBNull.Value : (object)value.CTACTE_PLAN_DESEMBOLSO_ID);
			AddParameter(cmd, "GIRO_COMPROBANTE", value.GIRO_COMPROBANTE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CTACTE_GIRO_ID",
				value.IsCTACTE_GIRO_IDNull ? DBNull.Value : (object)value.CTACTE_GIRO_ID);
			AddParameter(cmd, "RETENCION_TIMBRADO", value.RETENCION_TIMBRADO);
			AddParameter(cmd, "CHEQUE_ES_DIFERIDO", value.CHEQUE_ES_DIFERIDO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "RETENCION_TIPO_ID",
				value.IsRETENCION_TIPO_IDNull ? DBNull.Value : (object)value.RETENCION_TIPO_ID);
			AddParameter(cmd, "RETENCION_PORCENTAJE",
				value.IsRETENCION_PORCENTAJENull ? DBNull.Value : (object)value.RETENCION_PORCENTAJE);
			AddParameter(cmd, "POS_ID",
				value.IsPOS_IDNull ? DBNull.Value : (object)value.POS_ID);
			AddParameter(cmd, "MONTO_NETO",
				value.IsMONTO_NETONull ? DBNull.Value : (object)value.MONTO_NETO);
			AddParameter(cmd, "FECHA_ACREDITACION",
				value.IsFECHA_ACREDITACIONNull ? DBNull.Value : (object)value.FECHA_ACREDITACION);
			AddParameter(cmd, "TRANSFERENCIA_CAJA_SUCURSAL_ID",
				value.IsTRANSFERENCIA_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGOS_PERSONA_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PAGOS_PERSONA_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PAGOS_PERSONA_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_ID(decimal anticipo_id)
		{
			return DeleteByANTICIPO_ID(anticipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <param name="anticipo_idNull">true if the method ignores the anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByANTICIPO_ID(decimal anticipo_id, bool anticipo_idNull)
		{
			return CreateDeleteByANTICIPO_IDCommand(anticipo_id, anticipo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_ANT</c> foreign key.
		/// </summary>
		/// <param name="anticipo_id">The <c>ANTICIPO_ID</c> column value.</param>
		/// <param name="anticipo_idNull">true if the method ignores the anticipo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByANTICIPO_IDCommand(decimal anticipo_id, bool anticipo_idNull)
		{
			string whereSql = "";
			if(anticipo_idNull)
				whereSql += "ANTICIPO_ID IS NULL";
			else
				whereSql += "ANTICIPO_ID=" + _db.CreateSqlParameterName("ANTICIPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!anticipo_idNull)
				AddParameter(cmd, "ANTICIPO_ID", anticipo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id)
		{
			return DeleteByCHEQUE_CTACTE_BANCO_ID(cheque_ctacte_banco_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCHEQUE_CTACTE_BANCO_ID(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			return CreateDeleteByCHEQUE_CTACTE_BANCO_IDCommand(cheque_ctacte_banco_id, cheque_ctacte_banco_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_BAN</c> foreign key.
		/// </summary>
		/// <param name="cheque_ctacte_banco_id">The <c>CHEQUE_CTACTE_BANCO_ID</c> column value.</param>
		/// <param name="cheque_ctacte_banco_idNull">true if the method ignores the cheque_ctacte_banco_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCHEQUE_CTACTE_BANCO_IDCommand(decimal cheque_ctacte_banco_id, bool cheque_ctacte_banco_idNull)
		{
			string whereSql = "";
			if(cheque_ctacte_banco_idNull)
				whereSql += "CHEQUE_CTACTE_BANCO_ID IS NULL";
			else
				whereSql += "CHEQUE_CTACTE_BANCO_ID=" + _db.CreateSqlParameterName("CHEQUE_CTACTE_BANCO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cheque_ctacte_banco_idNull)
				AddParameter(cmd, "CHEQUE_CTACTE_BANCO_ID", cheque_ctacte_banco_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_CTACTE_BANCARIAS_ID(decimal deposito_ctacte_bancarias_id)
		{
			return DeleteByDEPOSITO_CTACTE_BANCARIAS_ID(deposito_ctacte_bancarias_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <param name="deposito_ctacte_bancarias_idNull">true if the method ignores the deposito_ctacte_bancarias_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_CTACTE_BANCARIAS_ID(decimal deposito_ctacte_bancarias_id, bool deposito_ctacte_bancarias_idNull)
		{
			return CreateDeleteByDEPOSITO_CTACTE_BANCARIAS_IDCommand(deposito_ctacte_bancarias_id, deposito_ctacte_bancarias_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_BANC</c> foreign key.
		/// </summary>
		/// <param name="deposito_ctacte_bancarias_id">The <c>DEPOSITO_CTACTE_BANCARIAS_ID</c> column value.</param>
		/// <param name="deposito_ctacte_bancarias_idNull">true if the method ignores the deposito_ctacte_bancarias_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_CTACTE_BANCARIAS_IDCommand(decimal deposito_ctacte_bancarias_id, bool deposito_ctacte_bancarias_idNull)
		{
			string whereSql = "";
			if(deposito_ctacte_bancarias_idNull)
				whereSql += "DEPOSITO_CTACTE_BANCARIAS_ID IS NULL";
			else
				whereSql += "DEPOSITO_CTACTE_BANCARIAS_ID=" + _db.CreateSqlParameterName("DEPOSITO_CTACTE_BANCARIAS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_ctacte_bancarias_idNull)
				AddParameter(cmd, "DEPOSITO_CTACTE_BANCARIAS_ID", deposito_ctacte_bancarias_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_cheque_recibido_id">The <c>CTACTE_CHEQUE_RECIBIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CHEQUE_RECIBIDO_ID(decimal ctacte_cheque_recibido_id)
		{
			return DeleteByCTACTE_CHEQUE_RECIBIDO_ID(ctacte_cheque_recibido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_CHEQ</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id)
		{
			return DeleteByDEPOSITO_BANCARIO_ID(deposito_bancario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_BANCARIO_ID(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			return CreateDeleteByDEPOSITO_BANCARIO_IDCommand(deposito_bancario_id, deposito_bancario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_bancario_id">The <c>DEPOSITO_BANCARIO_ID</c> column value.</param>
		/// <param name="deposito_bancario_idNull">true if the method ignores the deposito_bancario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_BANCARIO_IDCommand(decimal deposito_bancario_id, bool deposito_bancario_idNull)
		{
			string whereSql = "";
			if(deposito_bancario_idNull)
				whereSql += "DEPOSITO_BANCARIO_ID IS NULL";
			else
				whereSql += "DEPOSITO_BANCARIO_ID=" + _db.CreateSqlParameterName("DEPOSITO_BANCARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_bancario_idNull)
				AddParameter(cmd, "DEPOSITO_BANCARIO_ID", deposito_bancario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_MON</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_CREDITO_ID(decimal nota_credito_id)
		{
			return DeleteByNOTA_CREDITO_ID(nota_credito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_CREDITO_ID(decimal nota_credito_id, bool nota_credito_idNull)
		{
			return CreateDeleteByNOTA_CREDITO_IDCommand(nota_credito_id, nota_credito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_NOTA</c> foreign key.
		/// </summary>
		/// <param name="nota_credito_id">The <c>NOTA_CREDITO_ID</c> column value.</param>
		/// <param name="nota_credito_idNull">true if the method ignores the nota_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNOTA_CREDITO_IDCommand(decimal nota_credito_id, bool nota_credito_idNull)
		{
			string whereSql = "";
			if(nota_credito_idNull)
				whereSql += "NOTA_CREDITO_ID IS NULL";
			else
				whereSql += "NOTA_CREDITO_ID=" + _db.CreateSqlParameterName("NOTA_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nota_credito_idNull)
				AddParameter(cmd, "NOTA_CREDITO_ID", nota_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_ID(decimal ctacte_pago_persona_id)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_IDCommand(ctacte_pago_persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_PAG</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_id">The <c>CTACTE_PAGO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_IDCommand(decimal ctacte_pago_persona_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_PAGO_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_ID", ctacte_pago_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_DETALLE_ID(decimal retencion_detalle_id)
		{
			return DeleteByRETENCION_DETALLE_ID(retencion_detalle_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <param name="retencion_detalle_idNull">true if the method ignores the retencion_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_DETALLE_ID(decimal retencion_detalle_id, bool retencion_detalle_idNull)
		{
			return CreateDeleteByRETENCION_DETALLE_IDCommand(retencion_detalle_id, retencion_detalle_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_RED</c> foreign key.
		/// </summary>
		/// <param name="retencion_detalle_id">The <c>RETENCION_DETALLE_ID</c> column value.</param>
		/// <param name="retencion_detalle_idNull">true if the method ignores the retencion_detalle_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRETENCION_DETALLE_IDCommand(decimal retencion_detalle_id, bool retencion_detalle_idNull)
		{
			string whereSql = "";
			if(retencion_detalle_idNull)
				whereSql += "RETENCION_DETALLE_ID IS NULL";
			else
				whereSql += "RETENCION_DETALLE_ID=" + _db.CreateSqlParameterName("RETENCION_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!retencion_detalle_idNull)
				AddParameter(cmd, "RETENCION_DETALLE_ID", retencion_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
		/// </summary>
		/// <param name="retencion_tipo_id">The <c>RETENCION_TIPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRETENCION_TIPO_ID(decimal retencion_tipo_id)
		{
			return DeleteByRETENCION_TIPO_ID(retencion_tipo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_T_RET</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
		/// </summary>
		/// <param name="ctacte_procesadora_tarjeta_id">The <c>CTACTE_PROCESADORA_TARJETA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROCESADORA_TARJETA_ID(decimal ctacte_procesadora_tarjeta_id)
		{
			return DeleteByCTACTE_PROCESADORA_TARJETA_ID(ctacte_procesadora_tarjeta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_TARJ</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CTACTE_PERS_ID(decimal transferencia_ctacte_pers_id)
		{
			return DeleteByTRANSFERENCIA_CTACTE_PERS_ID(transferencia_ctacte_pers_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <param name="transferencia_ctacte_pers_idNull">true if the method ignores the transferencia_ctacte_pers_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CTACTE_PERS_ID(decimal transferencia_ctacte_pers_id, bool transferencia_ctacte_pers_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_CTACTE_PERS_IDCommand(transferencia_ctacte_pers_id, transferencia_ctacte_pers_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_TR_CT</c> foreign key.
		/// </summary>
		/// <param name="transferencia_ctacte_pers_id">The <c>TRANSFERENCIA_CTACTE_PERS_ID</c> column value.</param>
		/// <param name="transferencia_ctacte_pers_idNull">true if the method ignores the transferencia_ctacte_pers_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_CTACTE_PERS_IDCommand(decimal transferencia_ctacte_pers_id, bool transferencia_ctacte_pers_idNull)
		{
			string whereSql = "";
			if(transferencia_ctacte_pers_idNull)
				whereSql += "TRANSFERENCIA_CTACTE_PERS_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CTACTE_PERS_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CTACTE_PERS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_ctacte_pers_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CTACTE_PERS_ID", transferencia_ctacte_pers_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
		/// </summary>
		/// <param name="transferencia_bancaria_id">The <c>TRANSFERENCIA_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BANCARIA_ID(decimal transferencia_bancaria_id)
		{
			return DeleteByTRANSFERENCIA_BANCARIA_ID(transferencia_bancaria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_TRAN</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CAJA_SUCURSAL_ID(decimal transferencia_caja_sucursal_id)
		{
			return DeleteByTRANSFERENCIA_CAJA_SUCURSAL_ID(transferencia_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="transferencia_caja_sucursal_idNull">true if the method ignores the transferencia_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_CAJA_SUCURSAL_ID(decimal transferencia_caja_sucursal_id, bool transferencia_caja_sucursal_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_CAJA_SUCURSAL_IDCommand(transferencia_caja_sucursal_id, transferencia_caja_sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_TRANFCAJASUC</c> foreign key.
		/// </summary>
		/// <param name="transferencia_caja_sucursal_id">The <c>TRANSFERENCIA_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="transferencia_caja_sucursal_idNull">true if the method ignores the transferencia_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_CAJA_SUCURSAL_IDCommand(decimal transferencia_caja_sucursal_id, bool transferencia_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(transferencia_caja_sucursal_idNull)
				whereSql += "TRANSFERENCIA_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_caja_sucursal_idNull)
				AddParameter(cmd, "TRANSFERENCIA_CAJA_SUCURSAL_ID", transferencia_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_DET_VAL</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_DET_VAL</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_GIRO_ID(decimal ctacte_giro_id)
		{
			return DeleteByCTACTE_GIRO_ID(ctacte_giro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_GIRO_ID(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			return CreateDeleteByCTACTE_GIRO_IDCommand(ctacte_giro_id, ctacte_giro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_GIROS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_giro_id">The <c>CTACTE_GIRO_ID</c> column value.</param>
		/// <param name="ctacte_giro_idNull">true if the method ignores the ctacte_giro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_GIRO_IDCommand(decimal ctacte_giro_id, bool ctacte_giro_idNull)
		{
			string whereSql = "";
			if(ctacte_giro_idNull)
				whereSql += "CTACTE_GIRO_ID IS NULL";
			else
				whereSql += "CTACTE_GIRO_ID=" + _db.CreateSqlParameterName("CTACTE_GIRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_giro_idNull)
				AddParameter(cmd, "CTACTE_GIRO_ID", ctacte_giro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PLAN_DESEMBOLSO_ID(decimal ctacte_plan_desembolso_id)
		{
			return DeleteByCTACTE_PLAN_DESEMBOLSO_ID(ctacte_plan_desembolso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="ctacte_plan_desembolso_idNull">true if the method ignores the ctacte_plan_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PLAN_DESEMBOLSO_ID(decimal ctacte_plan_desembolso_id, bool ctacte_plan_desembolso_idNull)
		{
			return CreateDeleteByCTACTE_PLAN_DESEMBOLSO_IDCommand(ctacte_plan_desembolso_id, ctacte_plan_desembolso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_PLAN_DESE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_plan_desembolso_id">The <c>CTACTE_PLAN_DESEMBOLSO_ID</c> column value.</param>
		/// <param name="ctacte_plan_desembolso_idNull">true if the method ignores the ctacte_plan_desembolso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PLAN_DESEMBOLSO_IDCommand(decimal ctacte_plan_desembolso_id, bool ctacte_plan_desembolso_idNull)
		{
			string whereSql = "";
			if(ctacte_plan_desembolso_idNull)
				whereSql += "CTACTE_PLAN_DESEMBOLSO_ID IS NULL";
			else
				whereSql += "CTACTE_PLAN_DESEMBOLSO_ID=" + _db.CreateSqlParameterName("CTACTE_PLAN_DESEMBOLSO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_plan_desembolso_idNull)
				AddParameter(cmd, "CTACTE_PLAN_DESEMBOLSO_ID", ctacte_plan_desembolso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPOS_ID(decimal pos_id)
		{
			return DeleteByPOS_ID(pos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <param name="pos_idNull">true if the method ignores the pos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPOS_ID(decimal pos_id, bool pos_idNull)
		{
			return CreateDeleteByPOS_IDCommand(pos_id, pos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_POS_ID</c> foreign key.
		/// </summary>
		/// <param name="pos_id">The <c>POS_ID</c> column value.</param>
		/// <param name="pos_idNull">true if the method ignores the pos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPOS_IDCommand(decimal pos_id, bool pos_idNull)
		{
			string whereSql = "";
			if(pos_idNull)
				whereSql += "POS_ID IS NULL";
			else
				whereSql += "POS_ID=" + _db.CreateSqlParameterName("POS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pos_idNull)
				AddParameter(cmd, "POS_ID", pos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_red_pago_id">The <c>CTACTE_RED_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RED_PAGO_ID(decimal ctacte_red_pago_id)
		{
			return DeleteByCTACTE_RED_PAGO_ID(ctacte_red_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table using the 
		/// <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PAGOS_PERS_RED_PAGO</c> foreign key.
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
		/// Deletes <c>CTACTE_PAGOS_PERSONA_DET</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PAGOS_PERSONA_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PAGOS_PERSONA_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		protected CTACTE_PAGOS_PERSONA_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		protected CTACTE_PAGOS_PERSONA_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> objects.</returns>
		protected virtual CTACTE_PAGOS_PERSONA_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_pago_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int tarjeta_nroColumnIndex = reader.GetOrdinal("TARJETA_NRO");
			int tarjeta_vencimientoColumnIndex = reader.GetOrdinal("TARJETA_VENCIMIENTO");
			int tarjeta_titularColumnIndex = reader.GetOrdinal("TARJETA_TITULAR");
			int deposito_ctacte_bancarias_idColumnIndex = reader.GetOrdinal("DEPOSITO_CTACTE_BANCARIAS_ID");
			int deposito_nro_boletaColumnIndex = reader.GetOrdinal("DEPOSITO_NRO_BOLETA");
			int deposito_fechaColumnIndex = reader.GetOrdinal("DEPOSITO_FECHA");
			int cheque_ctacte_banco_idColumnIndex = reader.GetOrdinal("CHEQUE_CTACTE_BANCO_ID");
			int cheque_fecha_posdatadoColumnIndex = reader.GetOrdinal("CHEQUE_FECHA_POSDATADO");
			int cheque_fecha_vencimientoColumnIndex = reader.GetOrdinal("CHEQUE_FECHA_VENCIMIENTO");
			int cheque_nombre_emisorColumnIndex = reader.GetOrdinal("CHEQUE_NOMBRE_EMISOR");
			int cheque_nombre_beneficiarioColumnIndex = reader.GetOrdinal("CHEQUE_NOMBRE_BENEFICIARIO");
			int cheque_nro_cuentaColumnIndex = reader.GetOrdinal("CHEQUE_NRO_CUENTA");
			int cheque_nro_chequeColumnIndex = reader.GetOrdinal("CHEQUE_NRO_CHEQUE");
			int cheque_de_tercerosColumnIndex = reader.GetOrdinal("CHEQUE_DE_TERCEROS");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int ctacte_procesadora_tarjeta_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_TARJETA_ID");
			int anticipo_idColumnIndex = reader.GetOrdinal("ANTICIPO_ID");
			int transferencia_bancaria_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BANCARIA_ID");
			int deposito_bancario_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_ID");
			int nota_credito_idColumnIndex = reader.GetOrdinal("NOTA_CREDITO_ID");
			int retencion_nro_comprobanteColumnIndex = reader.GetOrdinal("RETENCION_NRO_COMPROBANTE");
			int retencion_observacionColumnIndex = reader.GetOrdinal("RETENCION_OBSERVACION");
			int retencion_caso_idColumnIndex = reader.GetOrdinal("RETENCION_CASO_ID");
			int retencion_fechaColumnIndex = reader.GetOrdinal("RETENCION_FECHA");
			int retencion_idColumnIndex = reader.GetOrdinal("RETENCION_ID");
			int retencion_detalle_idColumnIndex = reader.GetOrdinal("RETENCION_DETALLE_ID");
			int cheque_documento_emisorColumnIndex = reader.GetOrdinal("CHEQUE_DOCUMENTO_EMISOR");
			int transferencia_ctacte_pers_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_CTACTE_PERS_ID");
			int ctacte_red_pago_idColumnIndex = reader.GetOrdinal("CTACTE_RED_PAGO_ID");
			int ctacte_plan_desembolso_idColumnIndex = reader.GetOrdinal("CTACTE_PLAN_DESEMBOLSO_ID");
			int giro_comprobanteColumnIndex = reader.GetOrdinal("GIRO_COMPROBANTE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int ctacte_giro_idColumnIndex = reader.GetOrdinal("CTACTE_GIRO_ID");
			int retencion_timbradoColumnIndex = reader.GetOrdinal("RETENCION_TIMBRADO");
			int cheque_es_diferidoColumnIndex = reader.GetOrdinal("CHEQUE_ES_DIFERIDO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int retencion_tipo_idColumnIndex = reader.GetOrdinal("RETENCION_TIPO_ID");
			int retencion_porcentajeColumnIndex = reader.GetOrdinal("RETENCION_PORCENTAJE");
			int pos_idColumnIndex = reader.GetOrdinal("POS_ID");
			int monto_netoColumnIndex = reader.GetOrdinal("MONTO_NETO");
			int fecha_acreditacionColumnIndex = reader.GetOrdinal("FECHA_ACREDITACION");
			int transferencia_caja_sucursal_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_CAJA_SUCURSAL_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PAGOS_PERSONA_DETRow record = new CTACTE_PAGOS_PERSONA_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_PAGO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_idColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(montoColumnIndex))
						record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(tarjeta_nroColumnIndex))
						record.TARJETA_NRO = Convert.ToString(reader.GetValue(tarjeta_nroColumnIndex));
					if(!reader.IsDBNull(tarjeta_vencimientoColumnIndex))
						record.TARJETA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(tarjeta_vencimientoColumnIndex));
					if(!reader.IsDBNull(tarjeta_titularColumnIndex))
						record.TARJETA_TITULAR = Convert.ToString(reader.GetValue(tarjeta_titularColumnIndex));
					if(!reader.IsDBNull(deposito_ctacte_bancarias_idColumnIndex))
						record.DEPOSITO_CTACTE_BANCARIAS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_ctacte_bancarias_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_nro_boletaColumnIndex))
						record.DEPOSITO_NRO_BOLETA = Convert.ToString(reader.GetValue(deposito_nro_boletaColumnIndex));
					if(!reader.IsDBNull(deposito_fechaColumnIndex))
						record.DEPOSITO_FECHA = Convert.ToDateTime(reader.GetValue(deposito_fechaColumnIndex));
					if(!reader.IsDBNull(cheque_ctacte_banco_idColumnIndex))
						record.CHEQUE_CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_ctacte_banco_idColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_fecha_posdatadoColumnIndex))
						record.CHEQUE_FECHA_POSDATADO = Convert.ToDateTime(reader.GetValue(cheque_fecha_posdatadoColumnIndex));
					if(!reader.IsDBNull(cheque_fecha_vencimientoColumnIndex))
						record.CHEQUE_FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(cheque_fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(cheque_nombre_emisorColumnIndex))
						record.CHEQUE_NOMBRE_EMISOR = Convert.ToString(reader.GetValue(cheque_nombre_emisorColumnIndex));
					if(!reader.IsDBNull(cheque_nombre_beneficiarioColumnIndex))
						record.CHEQUE_NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(cheque_nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(cheque_nro_cuentaColumnIndex))
						record.CHEQUE_NRO_CUENTA = Convert.ToString(reader.GetValue(cheque_nro_cuentaColumnIndex));
					if(!reader.IsDBNull(cheque_nro_chequeColumnIndex))
						record.CHEQUE_NRO_CHEQUE = Convert.ToString(reader.GetValue(cheque_nro_chequeColumnIndex));
					if(!reader.IsDBNull(cheque_de_tercerosColumnIndex))
						record.CHEQUE_DE_TERCEROS = Convert.ToString(reader.GetValue(cheque_de_tercerosColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadora_tarjeta_idColumnIndex))
						record.CTACTE_PROCESADORA_TARJETA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_tarjeta_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_idColumnIndex))
						record.ANTICIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_bancaria_idColumnIndex))
						record.TRANSFERENCIA_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_idColumnIndex))
						record.DEPOSITO_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(nota_credito_idColumnIndex))
						record.NOTA_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_nro_comprobanteColumnIndex))
						record.RETENCION_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(retencion_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(retencion_observacionColumnIndex))
						record.RETENCION_OBSERVACION = Convert.ToString(reader.GetValue(retencion_observacionColumnIndex));
					if(!reader.IsDBNull(retencion_caso_idColumnIndex))
						record.RETENCION_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_fechaColumnIndex))
						record.RETENCION_FECHA = Convert.ToDateTime(reader.GetValue(retencion_fechaColumnIndex));
					if(!reader.IsDBNull(retencion_idColumnIndex))
						record.RETENCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_detalle_idColumnIndex))
						record.RETENCION_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(cheque_documento_emisorColumnIndex))
						record.CHEQUE_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(cheque_documento_emisorColumnIndex));
					if(!reader.IsDBNull(transferencia_ctacte_pers_idColumnIndex))
						record.TRANSFERENCIA_CTACTE_PERS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_ctacte_pers_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_red_pago_idColumnIndex))
						record.CTACTE_RED_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_red_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_plan_desembolso_idColumnIndex))
						record.CTACTE_PLAN_DESEMBOLSO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_plan_desembolso_idColumnIndex)), 9);
					if(!reader.IsDBNull(giro_comprobanteColumnIndex))
						record.GIRO_COMPROBANTE = Convert.ToString(reader.GetValue(giro_comprobanteColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(ctacte_giro_idColumnIndex))
						record.CTACTE_GIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_giro_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_timbradoColumnIndex))
						record.RETENCION_TIMBRADO = Convert.ToString(reader.GetValue(retencion_timbradoColumnIndex));
					if(!reader.IsDBNull(cheque_es_diferidoColumnIndex))
						record.CHEQUE_ES_DIFERIDO = Convert.ToString(reader.GetValue(cheque_es_diferidoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(retencion_tipo_idColumnIndex))
						record.RETENCION_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(retencion_porcentajeColumnIndex))
						record.RETENCION_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(retencion_porcentajeColumnIndex)), 9);
					if(!reader.IsDBNull(pos_idColumnIndex))
						record.POS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pos_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_netoColumnIndex))
						record.MONTO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_netoColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_acreditacionColumnIndex))
						record.FECHA_ACREDITACION = Convert.ToDateTime(reader.GetValue(fecha_acreditacionColumnIndex));
					if(!reader.IsDBNull(transferencia_caja_sucursal_idColumnIndex))
						record.TRANSFERENCIA_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_caja_sucursal_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PAGOS_PERSONA_DETRow[])(recordList.ToArray(typeof(CTACTE_PAGOS_PERSONA_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PAGOS_PERSONA_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PAGOS_PERSONA_DETRow"/> object.</returns>
		protected virtual CTACTE_PAGOS_PERSONA_DETRow MapRow(DataRow row)
		{
			CTACTE_PAGOS_PERSONA_DETRow mappedObject = new CTACTE_PAGOS_PERSONA_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "TARJETA_NRO"
			dataColumn = dataTable.Columns["TARJETA_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARJETA_NRO = (string)row[dataColumn];
			// Column "TARJETA_VENCIMIENTO"
			dataColumn = dataTable.Columns["TARJETA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARJETA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "TARJETA_TITULAR"
			dataColumn = dataTable.Columns["TARJETA_TITULAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARJETA_TITULAR = (string)row[dataColumn];
			// Column "DEPOSITO_CTACTE_BANCARIAS_ID"
			dataColumn = dataTable.Columns["DEPOSITO_CTACTE_BANCARIAS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_CTACTE_BANCARIAS_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_NRO_BOLETA"
			dataColumn = dataTable.Columns["DEPOSITO_NRO_BOLETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_NRO_BOLETA = (string)row[dataColumn];
			// Column "DEPOSITO_FECHA"
			dataColumn = dataTable.Columns["DEPOSITO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_FECHA = (System.DateTime)row[dataColumn];
			// Column "CHEQUE_CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CHEQUE_CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CHEQUE_FECHA_POSDATADO"
			dataColumn = dataTable.Columns["CHEQUE_FECHA_POSDATADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_FECHA_POSDATADO = (System.DateTime)row[dataColumn];
			// Column "CHEQUE_FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["CHEQUE_FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CHEQUE_NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["CHEQUE_NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "CHEQUE_NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["CHEQUE_NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "CHEQUE_NRO_CUENTA"
			dataColumn = dataTable.Columns["CHEQUE_NRO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NRO_CUENTA = (string)row[dataColumn];
			// Column "CHEQUE_NRO_CHEQUE"
			dataColumn = dataTable.Columns["CHEQUE_NRO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_NRO_CHEQUE = (string)row[dataColumn];
			// Column "CHEQUE_DE_TERCEROS"
			dataColumn = dataTable.Columns["CHEQUE_DE_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DE_TERCEROS = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA_TARJETA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_TARJETA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_TARJETA_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_ID"
			dataColumn = dataTable.Columns["ANTICIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_BANCARIA_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "NOTA_CREDITO_ID"
			dataColumn = dataTable.Columns["NOTA_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_CREDITO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["RETENCION_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "RETENCION_OBSERVACION"
			dataColumn = dataTable.Columns["RETENCION_OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_OBSERVACION = (string)row[dataColumn];
			// Column "RETENCION_CASO_ID"
			dataColumn = dataTable.Columns["RETENCION_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_CASO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_FECHA"
			dataColumn = dataTable.Columns["RETENCION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_FECHA = (System.DateTime)row[dataColumn];
			// Column "RETENCION_ID"
			dataColumn = dataTable.Columns["RETENCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_ID = (decimal)row[dataColumn];
			// Column "RETENCION_DETALLE_ID"
			dataColumn = dataTable.Columns["RETENCION_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_DETALLE_ID = (decimal)row[dataColumn];
			// Column "CHEQUE_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["CHEQUE_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "TRANSFERENCIA_CTACTE_PERS_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_CTACTE_PERS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_CTACTE_PERS_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RED_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RED_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RED_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PLAN_DESEMBOLSO_ID"
			dataColumn = dataTable.Columns["CTACTE_PLAN_DESEMBOLSO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PLAN_DESEMBOLSO_ID = (decimal)row[dataColumn];
			// Column "GIRO_COMPROBANTE"
			dataColumn = dataTable.Columns["GIRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.GIRO_COMPROBANTE = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "CTACTE_GIRO_ID"
			dataColumn = dataTable.Columns["CTACTE_GIRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_GIRO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_TIMBRADO"
			dataColumn = dataTable.Columns["RETENCION_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_TIMBRADO = (string)row[dataColumn];
			// Column "CHEQUE_ES_DIFERIDO"
			dataColumn = dataTable.Columns["CHEQUE_ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ES_DIFERIDO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "RETENCION_TIPO_ID"
			dataColumn = dataTable.Columns["RETENCION_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_TIPO_ID = (decimal)row[dataColumn];
			// Column "RETENCION_PORCENTAJE"
			dataColumn = dataTable.Columns["RETENCION_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION_PORCENTAJE = (decimal)row[dataColumn];
			// Column "POS_ID"
			dataColumn = dataTable.Columns["POS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.POS_ID = (decimal)row[dataColumn];
			// Column "MONTO_NETO"
			dataColumn = dataTable.Columns["MONTO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_NETO = (decimal)row[dataColumn];
			// Column "FECHA_ACREDITACION"
			dataColumn = dataTable.Columns["FECHA_ACREDITACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ACREDITACION = (System.DateTime)row[dataColumn];
			// Column "TRANSFERENCIA_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PAGOS_PERSONA_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PAGOS_PERSONA_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARJETA_NRO", typeof(string));
			dataColumn.MaxLength = 19;
			dataColumn = dataTable.Columns.Add("TARJETA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TARJETA_TITULAR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DEPOSITO_CTACTE_BANCARIAS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_NRO_BOLETA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("DEPOSITO_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CHEQUE_CTACTE_BANCO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHEQUE_FECHA_POSDATADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CHEQUE_FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CHEQUE_NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_NRO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("CHEQUE_NRO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CHEQUE_DE_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_TARJETA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANTICIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BANCARIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOTA_CREDITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("RETENCION_OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("RETENCION_CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("RETENCION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_DETALLE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHEQUE_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_CTACTE_PERS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_RED_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PLAN_DESEMBOLSO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GIRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CTACTE_GIRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CHEQUE_ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RETENCION_TIPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RETENCION_PORCENTAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("POS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ACREDITACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_CAJA_SUCURSAL_ID", typeof(decimal));
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

				case "CTACTE_PAGO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARJETA_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARJETA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TARJETA_TITULAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_CTACTE_BANCARIAS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_NRO_BOLETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPOSITO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHEQUE_CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_FECHA_POSDATADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHEQUE_FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHEQUE_NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NRO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_NRO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DE_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROCESADORA_TARJETA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSFERENCIA_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RETENCION_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "RETENCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHEQUE_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSFERENCIA_CTACTE_PERS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RED_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PLAN_DESEMBOLSO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GIRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_GIRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RETENCION_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "POS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ACREDITACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TRANSFERENCIA_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PAGOS_PERSONA_DETCollection_Base class
}  // End of namespace
