// <fileinfo name="PLANILLA_COBR_DET_INF_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="PLANILLA_COBR_DET_INF_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANILLA_COBR_DET_INF_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_COBR_DET_INF_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLANILLA_COBRANZA_IDColumnName = "PLANILLA_COBRANZA_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string DIRECCION_COBROColumnName = "DIRECCION_COBRO";
		public const string MONTO_CUOTAColumnName = "MONTO_CUOTA";
		public const string MONTO_MORAColumnName = "MONTO_MORA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_MONTO_NOMBREColumnName = "MONEDA_MONTO_NOMBRE";
		public const string MONEDA_MONTO_SIMBOLOColumnName = "MONEDA_MONTO_SIMBOLO";
		public const string MONEDA_MONTO_DECIMALESColumnName = "MONEDA_MONTO_DECIMALES";
		public const string MONEDA_MONTO_CADENA_DECIMALESColumnName = "MONEDA_MONTO_CADENA_DECIMALES";
		public const string MONTO_COBRADOColumnName = "MONTO_COBRADO";
		public const string MONEDA_COBRADO_IDColumnName = "MONEDA_COBRADO_ID";
		public const string MONEDA_COBRADO_NOMBREColumnName = "MONEDA_COBRADO_NOMBRE";
		public const string MONEDA_COBRADO_SIMBOLOColumnName = "MONEDA_COBRADO_SIMBOLO";
		public const string MONEDA_COBRADO_DECIMALESColumnName = "MONEDA_COBRADO_DECIMALES";
		public const string MONEDA_COBRAD_CADENA_DECIMALESColumnName = "MONEDA_COBRAD_CADENA_DECIMALES";
		public const string CTACTE_RECIBO_IMPRESO_IDColumnName = "CTACTE_RECIBO_IMPRESO_ID";
		public const string RECIBO_IMPRESO_TALONARIO_IDColumnName = "RECIBO_IMPRESO_TALONARIO_ID";
		public const string REC_IMPRESO_TALONARIO_TIPOColumnName = "REC_IMPRESO_TALONARIO_TIPO";
		public const string NRO_RECIBO_IMPRESOColumnName = "NRO_RECIBO_IMPRESO";
		public const string RECIBO_IMPRESO_ESTADOColumnName = "RECIBO_IMPRESO_ESTADO";
		public const string CTACTE_RECIBO_ENTREGADO_IDColumnName = "CTACTE_RECIBO_ENTREGADO_ID";
		public const string RECIBO_ENTREGADO_TALONARIO_IDColumnName = "RECIBO_ENTREGADO_TALONARIO_ID";
		public const string REC_ENTREGADO_TALONARIO_TIPOColumnName = "REC_ENTREGADO_TALONARIO_TIPO";
		public const string NRO_RECIBO_ENTREGADOColumnName = "NRO_RECIBO_ENTREGADO";
		public const string RECIBO_ENTREGADO_ESTADOColumnName = "RECIBO_ENTREGADO_ESTADO";
		public const string CASO_PAGO_IDColumnName = "CASO_PAGO_ID";
		public const string CASO_PAGO_ESTADOColumnName = "CASO_PAGO_ESTADO";
		public const string CASO_PAGO_COMPROBANTEColumnName = "CASO_PAGO_COMPROBANTE";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string COTIZACION_COBRADAColumnName = "COTIZACION_COBRADA";
		public const string PAGO_CONFIRMADOColumnName = "PAGO_CONFIRMADO";
		public const string FUNCIONARIO_CAJERO_IDColumnName = "FUNCIONARIO_CAJERO_ID";
		public const string FUNCIONARIO_CAJERO_NOMBREColumnName = "FUNCIONARIO_CAJERO_NOMBRE";
		public const string FECHA_POSTERGACIONColumnName = "FECHA_POSTERGACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_COBR_DET_INF_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANILLA_COBR_DET_INF_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANILLA_COBR_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects.</returns>
		public virtual PLANILLA_COBR_DET_INF_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANILLA_COBR_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANILLA_COBR_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANILLA_COBR_DET_INF_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANILLA_COBR_DET_INF_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects.</returns>
		public PLANILLA_COBR_DET_INF_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects.</returns>
		public virtual PLANILLA_COBR_DET_INF_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANILLA_COBR_DET_INF_COMPL";
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
		/// <returns>An array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects.</returns>
		protected PLANILLA_COBR_DET_INF_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects.</returns>
		protected PLANILLA_COBR_DET_INF_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> objects.</returns>
		protected virtual PLANILLA_COBR_DET_INF_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int planilla_cobranza_idColumnIndex = reader.GetOrdinal("PLANILLA_COBRANZA_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int direccion_cobroColumnIndex = reader.GetOrdinal("DIRECCION_COBRO");
			int monto_cuotaColumnIndex = reader.GetOrdinal("MONTO_CUOTA");
			int monto_moraColumnIndex = reader.GetOrdinal("MONTO_MORA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_monto_nombreColumnIndex = reader.GetOrdinal("MONEDA_MONTO_NOMBRE");
			int moneda_monto_simboloColumnIndex = reader.GetOrdinal("MONEDA_MONTO_SIMBOLO");
			int moneda_monto_decimalesColumnIndex = reader.GetOrdinal("MONEDA_MONTO_DECIMALES");
			int moneda_monto_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_MONTO_CADENA_DECIMALES");
			int monto_cobradoColumnIndex = reader.GetOrdinal("MONTO_COBRADO");
			int moneda_cobrado_idColumnIndex = reader.GetOrdinal("MONEDA_COBRADO_ID");
			int moneda_cobrado_nombreColumnIndex = reader.GetOrdinal("MONEDA_COBRADO_NOMBRE");
			int moneda_cobrado_simboloColumnIndex = reader.GetOrdinal("MONEDA_COBRADO_SIMBOLO");
			int moneda_cobrado_decimalesColumnIndex = reader.GetOrdinal("MONEDA_COBRADO_DECIMALES");
			int moneda_cobrad_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_COBRAD_CADENA_DECIMALES");
			int ctacte_recibo_impreso_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_IMPRESO_ID");
			int recibo_impreso_talonario_idColumnIndex = reader.GetOrdinal("RECIBO_IMPRESO_TALONARIO_ID");
			int rec_impreso_talonario_tipoColumnIndex = reader.GetOrdinal("REC_IMPRESO_TALONARIO_TIPO");
			int nro_recibo_impresoColumnIndex = reader.GetOrdinal("NRO_RECIBO_IMPRESO");
			int recibo_impreso_estadoColumnIndex = reader.GetOrdinal("RECIBO_IMPRESO_ESTADO");
			int ctacte_recibo_entregado_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ENTREGADO_ID");
			int recibo_entregado_talonario_idColumnIndex = reader.GetOrdinal("RECIBO_ENTREGADO_TALONARIO_ID");
			int rec_entregado_talonario_tipoColumnIndex = reader.GetOrdinal("REC_ENTREGADO_TALONARIO_TIPO");
			int nro_recibo_entregadoColumnIndex = reader.GetOrdinal("NRO_RECIBO_ENTREGADO");
			int recibo_entregado_estadoColumnIndex = reader.GetOrdinal("RECIBO_ENTREGADO_ESTADO");
			int caso_pago_idColumnIndex = reader.GetOrdinal("CASO_PAGO_ID");
			int caso_pago_estadoColumnIndex = reader.GetOrdinal("CASO_PAGO_ESTADO");
			int caso_pago_comprobanteColumnIndex = reader.GetOrdinal("CASO_PAGO_COMPROBANTE");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cotizacion_cobradaColumnIndex = reader.GetOrdinal("COTIZACION_COBRADA");
			int pago_confirmadoColumnIndex = reader.GetOrdinal("PAGO_CONFIRMADO");
			int funcionario_cajero_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_CAJERO_ID");
			int funcionario_cajero_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_CAJERO_NOMBRE");
			int fecha_postergacionColumnIndex = reader.GetOrdinal("FECHA_POSTERGACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANILLA_COBR_DET_INF_COMPLRow record = new PLANILLA_COBR_DET_INF_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLANILLA_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(planilla_cobranza_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(direccion_cobroColumnIndex))
						record.DIRECCION_COBRO = Convert.ToString(reader.GetValue(direccion_cobroColumnIndex));
					record.MONTO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_cuotaColumnIndex)), 9);
					record.MONTO_MORA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_moraColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_monto_nombreColumnIndex))
						record.MONEDA_MONTO_NOMBRE = Convert.ToString(reader.GetValue(moneda_monto_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_monto_simboloColumnIndex))
						record.MONEDA_MONTO_SIMBOLO = Convert.ToString(reader.GetValue(moneda_monto_simboloColumnIndex));
					if(!reader.IsDBNull(moneda_monto_decimalesColumnIndex))
						record.MONEDA_MONTO_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_monto_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_monto_cadena_decimalesColumnIndex))
						record.MONEDA_MONTO_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_monto_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(monto_cobradoColumnIndex))
						record.MONTO_COBRADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_cobradoColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cobrado_idColumnIndex))
						record.MONEDA_COBRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cobrado_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cobrado_nombreColumnIndex))
						record.MONEDA_COBRADO_NOMBRE = Convert.ToString(reader.GetValue(moneda_cobrado_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_cobrado_simboloColumnIndex))
						record.MONEDA_COBRADO_SIMBOLO = Convert.ToString(reader.GetValue(moneda_cobrado_simboloColumnIndex));
					if(!reader.IsDBNull(moneda_cobrado_decimalesColumnIndex))
						record.MONEDA_COBRADO_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cobrado_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cobrad_cadena_decimalesColumnIndex))
						record.MONEDA_COBRAD_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cobrad_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(ctacte_recibo_impreso_idColumnIndex))
						record.CTACTE_RECIBO_IMPRESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_impreso_idColumnIndex)), 9);
					if(!reader.IsDBNull(recibo_impreso_talonario_idColumnIndex))
						record.RECIBO_IMPRESO_TALONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(recibo_impreso_talonario_idColumnIndex)), 9);
					if(!reader.IsDBNull(rec_impreso_talonario_tipoColumnIndex))
						record.REC_IMPRESO_TALONARIO_TIPO = Convert.ToString(reader.GetValue(rec_impreso_talonario_tipoColumnIndex));
					if(!reader.IsDBNull(nro_recibo_impresoColumnIndex))
						record.NRO_RECIBO_IMPRESO = Convert.ToString(reader.GetValue(nro_recibo_impresoColumnIndex));
					if(!reader.IsDBNull(recibo_impreso_estadoColumnIndex))
						record.RECIBO_IMPRESO_ESTADO = Convert.ToString(reader.GetValue(recibo_impreso_estadoColumnIndex));
					if(!reader.IsDBNull(ctacte_recibo_entregado_idColumnIndex))
						record.CTACTE_RECIBO_ENTREGADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_entregado_idColumnIndex)), 9);
					if(!reader.IsDBNull(recibo_entregado_talonario_idColumnIndex))
						record.RECIBO_ENTREGADO_TALONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(recibo_entregado_talonario_idColumnIndex)), 9);
					if(!reader.IsDBNull(rec_entregado_talonario_tipoColumnIndex))
						record.REC_ENTREGADO_TALONARIO_TIPO = Convert.ToString(reader.GetValue(rec_entregado_talonario_tipoColumnIndex));
					if(!reader.IsDBNull(nro_recibo_entregadoColumnIndex))
						record.NRO_RECIBO_ENTREGADO = Convert.ToString(reader.GetValue(nro_recibo_entregadoColumnIndex));
					if(!reader.IsDBNull(recibo_entregado_estadoColumnIndex))
						record.RECIBO_ENTREGADO_ESTADO = Convert.ToString(reader.GetValue(recibo_entregado_estadoColumnIndex));
					if(!reader.IsDBNull(caso_pago_idColumnIndex))
						record.CASO_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_pago_estadoColumnIndex))
						record.CASO_PAGO_ESTADO = Convert.ToString(reader.GetValue(caso_pago_estadoColumnIndex));
					if(!reader.IsDBNull(caso_pago_comprobanteColumnIndex))
						record.CASO_PAGO_COMPROBANTE = Convert.ToString(reader.GetValue(caso_pago_comprobanteColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(cotizacion_cobradaColumnIndex))
						record.COTIZACION_COBRADA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_cobradaColumnIndex)), 9);
					if(!reader.IsDBNull(pago_confirmadoColumnIndex))
						record.PAGO_CONFIRMADO = Convert.ToString(reader.GetValue(pago_confirmadoColumnIndex));
					if(!reader.IsDBNull(funcionario_cajero_idColumnIndex))
						record.FUNCIONARIO_CAJERO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cajero_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_cajero_nombreColumnIndex))
						record.FUNCIONARIO_CAJERO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_cajero_nombreColumnIndex));
					if(!reader.IsDBNull(fecha_postergacionColumnIndex))
						record.FECHA_POSTERGACION = Convert.ToDateTime(reader.GetValue(fecha_postergacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANILLA_COBR_DET_INF_COMPLRow[])(recordList.ToArray(typeof(PLANILLA_COBR_DET_INF_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANILLA_COBR_DET_INF_COMPLRow"/> object.</returns>
		protected virtual PLANILLA_COBR_DET_INF_COMPLRow MapRow(DataRow row)
		{
			PLANILLA_COBR_DET_INF_COMPLRow mappedObject = new PLANILLA_COBR_DET_INF_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLANILLA_COBRANZA_ID"
			dataColumn = dataTable.Columns["PLANILLA_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLANILLA_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "DIRECCION_COBRO"
			dataColumn = dataTable.Columns["DIRECCION_COBRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION_COBRO = (string)row[dataColumn];
			// Column "MONTO_CUOTA"
			dataColumn = dataTable.Columns["MONTO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CUOTA = (decimal)row[dataColumn];
			// Column "MONTO_MORA"
			dataColumn = dataTable.Columns["MONTO_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_MORA = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_MONTO_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_MONTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_MONTO_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_MONTO_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_MONTO_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_MONTO_SIMBOLO = (string)row[dataColumn];
			// Column "MONEDA_MONTO_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_MONTO_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_MONTO_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_MONTO_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_MONTO_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_MONTO_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "MONTO_COBRADO"
			dataColumn = dataTable.Columns["MONTO_COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COBRADO = (decimal)row[dataColumn];
			// Column "MONEDA_COBRADO_ID"
			dataColumn = dataTable.Columns["MONEDA_COBRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COBRADO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_COBRADO_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_COBRADO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COBRADO_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_COBRADO_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_COBRADO_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COBRADO_SIMBOLO = (string)row[dataColumn];
			// Column "MONEDA_COBRADO_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_COBRADO_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COBRADO_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_COBRAD_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_COBRAD_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_COBRAD_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "CTACTE_RECIBO_IMPRESO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_IMPRESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_IMPRESO_ID = (decimal)row[dataColumn];
			// Column "RECIBO_IMPRESO_TALONARIO_ID"
			dataColumn = dataTable.Columns["RECIBO_IMPRESO_TALONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_IMPRESO_TALONARIO_ID = (decimal)row[dataColumn];
			// Column "REC_IMPRESO_TALONARIO_TIPO"
			dataColumn = dataTable.Columns["REC_IMPRESO_TALONARIO_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REC_IMPRESO_TALONARIO_TIPO = (string)row[dataColumn];
			// Column "NRO_RECIBO_IMPRESO"
			dataColumn = dataTable.Columns["NRO_RECIBO_IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_RECIBO_IMPRESO = (string)row[dataColumn];
			// Column "RECIBO_IMPRESO_ESTADO"
			dataColumn = dataTable.Columns["RECIBO_IMPRESO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_IMPRESO_ESTADO = (string)row[dataColumn];
			// Column "CTACTE_RECIBO_ENTREGADO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ENTREGADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ENTREGADO_ID = (decimal)row[dataColumn];
			// Column "RECIBO_ENTREGADO_TALONARIO_ID"
			dataColumn = dataTable.Columns["RECIBO_ENTREGADO_TALONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_ENTREGADO_TALONARIO_ID = (decimal)row[dataColumn];
			// Column "REC_ENTREGADO_TALONARIO_TIPO"
			dataColumn = dataTable.Columns["REC_ENTREGADO_TALONARIO_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REC_ENTREGADO_TALONARIO_TIPO = (string)row[dataColumn];
			// Column "NRO_RECIBO_ENTREGADO"
			dataColumn = dataTable.Columns["NRO_RECIBO_ENTREGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_RECIBO_ENTREGADO = (string)row[dataColumn];
			// Column "RECIBO_ENTREGADO_ESTADO"
			dataColumn = dataTable.Columns["RECIBO_ENTREGADO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_ENTREGADO_ESTADO = (string)row[dataColumn];
			// Column "CASO_PAGO_ID"
			dataColumn = dataTable.Columns["CASO_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_PAGO_ID = (decimal)row[dataColumn];
			// Column "CASO_PAGO_ESTADO"
			dataColumn = dataTable.Columns["CASO_PAGO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_PAGO_ESTADO = (string)row[dataColumn];
			// Column "CASO_PAGO_COMPROBANTE"
			dataColumn = dataTable.Columns["CASO_PAGO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_PAGO_COMPROBANTE = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "COTIZACION_COBRADA"
			dataColumn = dataTable.Columns["COTIZACION_COBRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_COBRADA = (decimal)row[dataColumn];
			// Column "PAGO_CONFIRMADO"
			dataColumn = dataTable.Columns["PAGO_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGO_CONFIRMADO = (string)row[dataColumn];
			// Column "FUNCIONARIO_CAJERO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_CAJERO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CAJERO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_CAJERO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_CAJERO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CAJERO_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_POSTERGACION"
			dataColumn = dataTable.Columns["FECHA_POSTERGACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSTERGACION = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANILLA_COBR_DET_INF_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANILLA_COBR_DET_INF_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PLANILLA_COBRANZA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIRECCION_COBRO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_MORA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_MONTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_MONTO_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_MONTO_DECIMALES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_MONTO_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_COBRADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COBRADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COBRADO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COBRADO_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COBRADO_DECIMALES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_COBRAD_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_IMPRESO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECIBO_IMPRESO_TALONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REC_IMPRESO_TALONARIO_TIPO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_RECIBO_IMPRESO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECIBO_IMPRESO_ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ENTREGADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECIBO_ENTREGADO_TALONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REC_ENTREGADO_TALONARIO_TIPO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_RECIBO_ENTREGADO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECIBO_ENTREGADO_ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_PAGO_ESTADO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_PAGO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_COBRADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAGO_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CAJERO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CAJERO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_POSTERGACION", typeof(System.DateTime));
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

				case "PLANILLA_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION_COBRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_MONTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_MONTO_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_MONTO_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_MONTO_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONTO_COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COBRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COBRADO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_COBRADO_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_COBRADO_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_COBRAD_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_RECIBO_IMPRESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RECIBO_IMPRESO_TALONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REC_IMPRESO_TALONARIO_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_RECIBO_IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RECIBO_IMPRESO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_RECIBO_ENTREGADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RECIBO_ENTREGADO_TALONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REC_ENTREGADO_TALONARIO_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_RECIBO_ENTREGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RECIBO_ENTREGADO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_PAGO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_PAGO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_COBRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAGO_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FUNCIONARIO_CAJERO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_CAJERO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_POSTERGACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANILLA_COBR_DET_INF_COMPLCollection_Base class
}  // End of namespace
