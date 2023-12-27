// <fileinfo name="CTACTE_CAJA_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CAJA_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CAJA_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CAJA_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";
		public const string USUARIO_USUARIOColumnName = "USUARIO_USUARIO";
		public const string FUNCIONARIO_COBRADOR_IDColumnName = "FUNCIONARIO_COBRADOR_ID";
		public const string FUNCIONARIO_COBRADOR_NOMBREColumnName = "FUNCIONARIO_COBRADOR_NOMBRE";
		public const string CTACTE_CONCEPTO_IDColumnName = "CTACTE_CONCEPTO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string CTACTE_VALOR_NOMBREColumnName = "CTACTE_VALOR_NOMBRE";
		public const string MONTOColumnName = "MONTO";
		public const string FECHAColumnName = "FECHA";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string CTACTE_CHEQUE_REC_DATOS_RESUMColumnName = "CTACTE_CHEQUE_REC_DATOS_RESUM";
		public const string CTACTE_CHEQUE_RECIBIDO_NUMEROColumnName = "CTACTE_CHEQUE_RECIBIDO_NUMERO";
		public const string CTACTE_CHEQUE_RECIBIDO_VENCColumnName = "CTACTE_CHEQUE_RECIBIDO_VENC";
		public const string CTACTE_CHEQUE_RECIBIDO_EMISORColumnName = "CTACTE_CHEQUE_RECIBIDO_EMISOR";
		public const string CTACTE_CHQ_RECIBIDO_ESTADO_IDColumnName = "CTACTE_CHQ_RECIBIDO_ESTADO_ID";
		public const string CTACTE_CHEQUE_RECIBIDO_BANCOColumnName = "CTACTE_CHEQUE_RECIBIDO_BANCO";
		public const string CTACTE_CHEQ_RECIBIDO_N_CUENTAColumnName = "CTACTE_CHEQ_RECIBIDO_N_CUENTA";
		public const string CTACTE_CHQ_RECIBIDO_ESTADOColumnName = "CTACTE_CHQ_RECIBIDO_ESTADO";
		public const string CTACTE_PAGO_PERSONA_IDColumnName = "CTACTE_PAGO_PERSONA_ID";
		public const string CTACTE_PAGO_PERSONA_DET_IDColumnName = "CTACTE_PAGO_PERSONA_DET_ID";
		public const string CTACTE_RECIBO_IDColumnName = "CTACTE_RECIBO_ID";
		public const string CTACTE_RECIBO_NROColumnName = "CTACTE_RECIBO_NRO";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string CTACTE_CAJA_SUCURSAL_ESTADOColumnName = "CTACTE_CAJA_SUCURSAL_ESTADO";
		public const string EGRESO_VARIO_IDColumnName = "EGRESO_VARIO_ID";
		public const string CTACTE_FONDO_FIJO_MOV_IDColumnName = "CTACTE_FONDO_FIJO_MOV_ID";
		public const string ANTICIPO_PERSONA_IDColumnName = "ANTICIPO_PERSONA_ID";
		public const string ANTICIPO_PERSONA_DET_IDColumnName = "ANTICIPO_PERSONA_DET_ID";
		public const string DEPOSITO_BANCARIO_DET_IDColumnName = "DEPOSITO_BANCARIO_DET_ID";
		public const string CTACTE_CAJA_RESERVA_DET_IDColumnName = "CTACTE_CAJA_RESERVA_DET_ID";
		public const string MOVIMIENTO_FONDO_FIJO_IDColumnName = "MOVIMIENTO_FONDO_FIJO_ID";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CAJA_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CAJA_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CAJA_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_CAJA_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CAJA_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CAJA_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CAJA_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CAJA_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects.</returns>
		public CTACTE_CAJA_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTACTE_CAJA_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CAJA_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_CAJA_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects.</returns>
		protected CTACTE_CAJA_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTACTE_CAJA_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");
			int usuario_usuarioColumnIndex = reader.GetOrdinal("USUARIO_USUARIO");
			int funcionario_cobrador_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_ID");
			int funcionario_cobrador_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_NOMBRE");
			int ctacte_concepto_idColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int ctacte_valor_nombreColumnIndex = reader.GetOrdinal("CTACTE_VALOR_NOMBRE");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int ctacte_cheque_rec_datos_resumColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_REC_DATOS_RESUM");
			int ctacte_cheque_recibido_numeroColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_NUMERO");
			int ctacte_cheque_recibido_vencColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_VENC");
			int ctacte_cheque_recibido_emisorColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_EMISOR");
			int ctacte_chq_recibido_estado_idColumnIndex = reader.GetOrdinal("CTACTE_CHQ_RECIBIDO_ESTADO_ID");
			int ctacte_cheque_recibido_bancoColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_BANCO");
			int ctacte_cheq_recibido_n_cuentaColumnIndex = reader.GetOrdinal("CTACTE_CHEQ_RECIBIDO_N_CUENTA");
			int ctacte_chq_recibido_estadoColumnIndex = reader.GetOrdinal("CTACTE_CHQ_RECIBIDO_ESTADO");
			int ctacte_pago_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_ID");
			int ctacte_pago_persona_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DET_ID");
			int ctacte_recibo_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ID");
			int ctacte_recibo_nroColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_NRO");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int ctacte_caja_sucursal_estadoColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ESTADO");
			int egreso_vario_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_ID");
			int ctacte_fondo_fijo_mov_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_MOV_ID");
			int anticipo_persona_idColumnIndex = reader.GetOrdinal("ANTICIPO_PERSONA_ID");
			int anticipo_persona_det_idColumnIndex = reader.GetOrdinal("ANTICIPO_PERSONA_DET_ID");
			int deposito_bancario_det_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_DET_ID");
			int ctacte_caja_reserva_det_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_RESERVA_DET_ID");
			int movimiento_fondo_fijo_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_FONDO_FIJO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CAJA_INFO_COMPLETARow record = new CTACTE_CAJA_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_nombreColumnIndex))
						record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));
					record.USUARIO_USUARIO = Convert.ToString(reader.GetValue(usuario_usuarioColumnIndex));
					record.FUNCIONARIO_COBRADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cobrador_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_cobrador_nombreColumnIndex))
						record.FUNCIONARIO_COBRADOR_NOMBRE = Convert.ToString(reader.GetValue(funcionario_cobrador_nombreColumnIndex));
					record.CTACTE_CONCEPTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_concepto_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					record.CTACTE_VALOR_NOMBRE = Convert.ToString(reader.GetValue(ctacte_valor_nombreColumnIndex));
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_idColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_rec_datos_resumColumnIndex))
						record.CTACTE_CHEQUE_REC_DATOS_RESUM = Convert.ToString(reader.GetValue(ctacte_cheque_rec_datos_resumColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_numeroColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_NUMERO = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_numeroColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_vencColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_VENC = Convert.ToDateTime(reader.GetValue(ctacte_cheque_recibido_vencColumnIndex));
					if(!reader.IsDBNull(ctacte_cheque_recibido_emisorColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_EMISOR = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_emisorColumnIndex));
					if(!reader.IsDBNull(ctacte_chq_recibido_estado_idColumnIndex))
						record.CTACTE_CHQ_RECIBIDO_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_chq_recibido_estado_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_cheque_recibido_bancoColumnIndex))
						record.CTACTE_CHEQUE_RECIBIDO_BANCO = Convert.ToString(reader.GetValue(ctacte_cheque_recibido_bancoColumnIndex));
					if(!reader.IsDBNull(ctacte_cheq_recibido_n_cuentaColumnIndex))
						record.CTACTE_CHEQ_RECIBIDO_N_CUENTA = Convert.ToString(reader.GetValue(ctacte_cheq_recibido_n_cuentaColumnIndex));
					if(!reader.IsDBNull(ctacte_chq_recibido_estadoColumnIndex))
						record.CTACTE_CHQ_RECIBIDO_ESTADO = Convert.ToString(reader.GetValue(ctacte_chq_recibido_estadoColumnIndex));
					if(!reader.IsDBNull(ctacte_pago_persona_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_det_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_idColumnIndex))
						record.CTACTE_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_nroColumnIndex))
						record.CTACTE_RECIBO_NRO = Convert.ToString(reader.GetValue(ctacte_recibo_nroColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					record.CTACTE_CAJA_SUCURSAL_ESTADO = Convert.ToString(reader.GetValue(ctacte_caja_sucursal_estadoColumnIndex));
					if(!reader.IsDBNull(egreso_vario_idColumnIndex))
						record.EGRESO_VARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fondo_fijo_mov_idColumnIndex))
						record.CTACTE_FONDO_FIJO_MOV_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_mov_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_persona_idColumnIndex))
						record.ANTICIPO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(anticipo_persona_det_idColumnIndex))
						record.ANTICIPO_PERSONA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_persona_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_det_idColumnIndex))
						record.DEPOSITO_BANCARIO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_reserva_det_idColumnIndex))
						record.CTACTE_CAJA_RESERVA_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_reserva_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_fondo_fijo_idColumnIndex))
						record.MOVIMIENTO_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_fondo_fijo_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CAJA_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTACTE_CAJA_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CAJA_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CAJA_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTACTE_CAJA_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTACTE_CAJA_INFO_COMPLETARow mappedObject = new CTACTE_CAJA_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "USUARIO_USUARIO"
			dataColumn = dataTable.Columns["USUARIO_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_USUARIO = (string)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_CONCEPTO_ID"
			dataColumn = dataTable.Columns["CTACTE_CONCEPTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONCEPTO_ID = (decimal)row[dataColumn];
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
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_VALOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_NOMBRE = (string)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_REC_DATOS_RESUM"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_REC_DATOS_RESUM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_REC_DATOS_RESUM = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_NUMERO"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_NUMERO = (string)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_VENC"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_VENC"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_VENC = (System.DateTime)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_EMISOR"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_EMISOR = (string)row[dataColumn];
			// Column "CTACTE_CHQ_RECIBIDO_ESTADO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHQ_RECIBIDO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHQ_RECIBIDO_ESTADO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_BANCO"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_BANCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_BANCO = (string)row[dataColumn];
			// Column "CTACTE_CHEQ_RECIBIDO_N_CUENTA"
			dataColumn = dataTable.Columns["CTACTE_CHEQ_RECIBIDO_N_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQ_RECIBIDO_N_CUENTA = (string)row[dataColumn];
			// Column "CTACTE_CHQ_RECIBIDO_ESTADO"
			dataColumn = dataTable.Columns["CTACTE_CHQ_RECIBIDO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHQ_RECIBIDO_ESTADO = (string)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DET_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_NRO"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_NRO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ESTADO"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ESTADO = (string)row[dataColumn];
			// Column "EGRESO_VARIO_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_MOV_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_MOV_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_MOV_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_PERSONA_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "ANTICIPO_PERSONA_DET_ID"
			dataColumn = dataTable.Columns["ANTICIPO_PERSONA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_PERSONA_DET_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_DET_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_DET_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_RESERVA_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_RESERVA_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_RESERVA_DET_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CAJA_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CAJA_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CONCEPTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
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
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_REC_DATOS_RESUM", typeof(string));
			dataColumn.MaxLength = 434;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_VENC", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHQ_RECIBIDO_ESTADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_BANCO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQ_RECIBIDO_N_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHQ_RECIBIDO_ESTADO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_NRO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ESTADO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_MOV_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANTICIPO_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANTICIPO_PERSONA_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_RESERVA_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_FONDO_FIJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_COBRADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_COBRADOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CONCEPTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_REC_DATOS_RESUM":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_VENC":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHQ_RECIBIDO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CHEQUE_RECIBIDO_BANCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHEQ_RECIBIDO_N_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CHQ_RECIBIDO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PAGO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECIBO_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EGRESO_VARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FONDO_FIJO_MOV_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANTICIPO_PERSONA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_RESERVA_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CAJA_INFO_COMPLETACollection_Base class
}  // End of namespace
