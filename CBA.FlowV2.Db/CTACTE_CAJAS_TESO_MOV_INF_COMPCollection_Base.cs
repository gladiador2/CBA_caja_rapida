// <fileinfo name="CTACTE_CAJAS_TESO_MOV_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJAS_TESO_MOV_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string CTACTE_CAJA_TESORERIA_NOMBREColumnName = "CTACTE_CAJA_TESORERIA_NOMBRE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
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
		public const string CTACTE_CHEQUE_RECIBIDO_BANCOColumnName = "CTACTE_CHEQUE_RECIBIDO_BANCO";
		public const string CTACTE_CHEQUE_RECIBIDO_NUMEROColumnName = "CTACTE_CHEQUE_RECIBIDO_NUMERO";
		public const string CTACTE_CHEQUE_RECIBIDO_EMISORColumnName = "CTACTE_CHEQUE_RECIBIDO_EMISOR";
		public const string CTACTE_CHEQUE_RECIBIDO_VENCColumnName = "CTACTE_CHEQUE_RECIBIDO_VENC";
		public const string CTACTE_CHQ_RECIBIDO_ESTADO_IDColumnName = "CTACTE_CHQ_RECIBIDO_ESTADO_ID";
		public const string CTACTE_CHEQUE_RECIBIDO_ACTIVOColumnName = "CTACTE_CHEQUE_RECIBIDO_ACTIVO";
		public const string CTACTE_CHEQUE_RECIBIDO_ESTADOColumnName = "CTACTE_CHEQUE_RECIBIDO_ESTADO";
		public const string CTACTE_CHEQUE_RECIBIDO_TERCColumnName = "CTACTE_CHEQUE_RECIBIDO_TERC";
		public const string CTACTE_PROCESADORA_TARJETA_IDColumnName = "CTACTE_PROCESADORA_TARJETA_ID";
		public const string DEPOSITO_BANCARIO_DET_IDColumnName = "DEPOSITO_BANCARIO_DET_ID";
		public const string ORDEN_PAGO_VALOR_IDColumnName = "ORDEN_PAGO_VALOR_ID";
		public const string CAMBIO_DIVISA_DET_IDColumnName = "CAMBIO_DIVISA_DET_ID";
		public const string MOVIMIENTO_VARIO_DET_IDColumnName = "MOVIMIENTO_VARIO_DET_ID";
		public const string TRANSFERENCIA_DET_IDColumnName = "TRANSFERENCIA_DET_ID";
		public const string TRANSFERENCIA_CAJA_SUC_DET_IDColumnName = "TRANSFERENCIA_CAJA_SUC_DET_ID";
		public const string CUSTODIA_VALOR_DET_IDColumnName = "CUSTODIA_VALOR_DET_ID";
		public const string CUSTODIA_VALOR_DET_ENTRADA_IDColumnName = "CUSTODIA_VALOR_DET_ENTRADA_ID";
		public const string DESCUENTO_DOCUMENTO_DET_IDColumnName = "DESCUENTO_DOCUMENTO_DET_ID";
		public const string DESCUENTO_DOCUMENTO_PAGO_IDColumnName = "DESCUENTO_DOCUMENTO_PAGO_ID";
		public const string DESCUENTO_DOCUMENTO_CLI_DET_IDColumnName = "DESCUENTO_DOCUMENTO_CLI_DET_ID";
		public const string CANJE_VALOR_DET_IDColumnName = "CANJE_VALOR_DET_ID";
		public const string CANJE_VALOR_VAL_IDColumnName = "CANJE_VALOR_VAL_ID";
		public const string DESEMBOLSO_GIRO_IDColumnName = "DESEMBOLSO_GIRO_ID";
		public const string CTACTE_CHQ_RECIBIDO_PERSONA_IDColumnName = "CTACTE_CHQ_RECIBIDO_PERSONA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CAJAS_TESO_MOV_INF_COMPCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this view belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>CTACTE_CAJAS_TESO_MOV_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESO_MOV_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CAJAS_TESO_MOV_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CAJAS_TESO_MOV_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CAJAS_TESO_MOV_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CAJAS_TESO_MOV_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects.</returns>
		public CTACTE_CAJAS_TESO_MOV_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects.</returns>
		public virtual CTACTE_CAJAS_TESO_MOV_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CAJAS_TESO_MOV_INF_COMP";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects.</returns>
		protected CTACTE_CAJAS_TESO_MOV_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects.</returns>
		protected CTACTE_CAJAS_TESO_MOV_INF_COMPRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> objects.</returns>
		protected virtual CTACTE_CAJAS_TESO_MOV_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int ctacte_caja_tesoreria_nombreColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_NOMBRE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
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
			int ctacte_cheque_recibido_bancoColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_BANCO");
			int ctacte_cheque_recibido_numeroColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_NUMERO");
			int ctacte_cheque_recibido_emisorColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_EMISOR");
			int ctacte_cheque_recibido_vencColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_VENC");
			int ctacte_chq_recibido_estado_idColumnIndex = reader.GetOrdinal("CTACTE_CHQ_RECIBIDO_ESTADO_ID");
			int ctacte_cheque_recibido_activoColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ACTIVO");
			int ctacte_cheque_recibido_estadoColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ESTADO");
			int ctacte_cheque_recibido_tercColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_TERC");
			int ctacte_procesadora_tarjeta_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_TARJETA_ID");
			int deposito_bancario_det_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_DET_ID");
			int orden_pago_valor_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_VALOR_ID");
			int cambio_divisa_det_idColumnIndex = reader.GetOrdinal("CAMBIO_DIVISA_DET_ID");
			int movimiento_vario_det_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_VARIO_DET_ID");
			int transferencia_det_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_DET_ID");
			int transferencia_caja_suc_det_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_CAJA_SUC_DET_ID");
			int custodia_valor_det_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALOR_DET_ID");
			int custodia_valor_det_entrada_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALOR_DET_ENTRADA_ID");
			int descuento_documento_det_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_DET_ID");
			int descuento_documento_pago_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_PAGO_ID");
			int descuento_documento_cli_det_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTO_CLI_DET_ID");
			int canje_valor_det_idColumnIndex = reader.GetOrdinal("CANJE_VALOR_DET_ID");
			int canje_valor_val_idColumnIndex = reader.GetOrdinal("CANJE_VALOR_VAL_ID");
			int desembolso_giro_idColumnIndex = reader.GetOrdinal("DESEMBOLSO_GIRO_ID");
			int ctacte_chq_recibido_persona_idColumnIndex = reader.GetOrdinal("CTACTE_CHQ_RECIBIDO_PERSONA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CAJAS_TESO_MOV_INF_COMPRow record = new CTACTE_CAJAS_TESO_MOV_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_tesoreria_nombreColumnIndex))
						record.CTACTE_CAJA_TESORERIA_NOMBRE = Convert.ToString(reader.GetValue(ctacte_caja_tesoreria_nombreColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
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
					if(!reader.IsDBNull(ctacte_cheque_recibido_bancoColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_BANCO = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_bancoColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_numeroColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_NUMERO = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_numeroColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_emisorColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_EMISOR = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_emisorColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_vencColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_VENC = Convert.ToDateTime(reader.GetValue(ctacte_cheque_recibido_vencColumnIndex));
					if(!reader.IsDBNull(ctacte_chq_recibido_estado_idColumnIndex))
						record.CTACTE_CHQ_RECIBIDO_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_chq_recibido_estado_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_activoColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ACTIVO = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_activoColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_estadoColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ESTADO = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_estadoColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_tercColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_TERC = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_tercColumnIndex));
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
					if(!reader.IsDBNull(transferencia_caja_suc_det_idColumnIndex))
						record.TRANSFERENCIA_CAJA_SUC_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_caja_suc_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valor_det_idColumnIndex))
						record.CUSTODIA_VALOR_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valor_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valor_det_entrada_idColumnIndex))
						record.CUSTODIA_VALOR_DET_ENTRADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valor_det_entrada_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_det_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_pago_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documento_cli_det_idColumnIndex))
						record.DESCUENTO_DOCUMENTO_CLI_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documento_cli_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(canje_valor_det_idColumnIndex))
						record.CANJE_VALOR_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canje_valor_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(canje_valor_val_idColumnIndex))
						record.CANJE_VALOR_VAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canje_valor_val_idColumnIndex)), 9);
					if(!reader.IsDBNull(desembolso_giro_idColumnIndex))
						record.DESEMBOLSO_GIRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(desembolso_giro_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_chq_recibido_persona_idColumnIndex))
						record.CTACTE_CHQ_RECIBIDO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_chq_recibido_persona_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CAJAS_TESO_MOV_INF_COMPRow[])(recordList.ToArray(typeof(CTACTE_CAJAS_TESO_MOV_INF_COMPRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the view.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CAJAS_TESO_MOV_INF_COMPRow"/> object.</returns>
		protected virtual CTACTE_CAJAS_TESO_MOV_INF_COMPRow MapRow(DataRow row)
		{
			CTACTE_CAJAS_TESO_MOV_INF_COMPRow mappedObject = new CTACTE_CAJAS_TESO_MOV_INF_COMPRow();
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
			// Column "CTACTE_CAJA_TESORERIA_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
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
			// Column "CTACTE_CHEQUE_RECIBIDO_BANCO"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_BANCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_BANCO = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_NUMERO"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_NUMERO = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_EMISOR"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_EMISOR = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_VENC"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_VENC"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_VENC = (System.DateTime)row[dataColumn];
			// Column "CTACTE_CHQ_RECIBIDO_ESTADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHQ_RECIBIDO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHQ_RECIBIDO_ESTADO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ACTIVO"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ACTIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ACTIVO = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ESTADO"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ESTADO = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_TERC"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_TERC"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_TERC = (string)row[dataColumn];
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
			// Column "TRANSFERENCIA_CAJA_SUC_DET_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_CAJA_SUC_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_CAJA_SUC_DET_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALOR_DET_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALOR_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALOR_DET_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALOR_DET_ENTRADA_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALOR_DET_ENTRADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALOR_DET_ENTRADA_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_DET_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_DET_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_PAGO_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_PAGO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTO_CLI_DET_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTO_CLI_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTO_CLI_DET_ID = (decimal)row[dataColumn];
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
			// Column "CTACTE_CHQ_RECIBIDO_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_CHQ_RECIBIDO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHQ_RECIBIDO_PERSONA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CAJAS_TESO_MOV_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CAJAS_TESO_MOV_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_OPERACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_OPERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_EGRESO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_BANCO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_VENC", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHQ_RECIBIDO_ESTADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ACTIVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ESTADO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_TERC", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_TARJETA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_VALOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAMBIO_DIVISA_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_VARIO_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_CAJA_SUC_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALOR_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALOR_DET_ENTRADA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTO_CLI_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANJE_VALOR_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANJE_VALOR_VAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_GIRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHQ_RECIBIDO_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
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

				case "CTACTE_CAJA_TESORERIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "CTACTE_CHEQUE_RECIBIDO_BANCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_VENC":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_CHQ_RECIBIDO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ACTIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_TERC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
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

				case "TRANSFERENCIA_CAJA_SUC_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALOR_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALOR_DET_ENTRADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTO_CLI_DET_ID":
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

				case "CTACTE_CHQ_RECIBIDO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CAJAS_TESO_MOV_INF_COMPCollection_Base class
}  // End of namespace
