// <fileinfo name="DEPOSITOS_BANCARIOS_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DEPOSITOS_BANCARIOS_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_NOMBRE_COMPLETOColumnName = "FUNCIONARIO_NOMBRE_COMPLETO";
		public const string FECHAColumnName = "FECHA";
		public const string DEPOSITO_DESDE_SUCColumnName = "DEPOSITO_DESDE_SUC";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string MONEDA_CANTIDADES_DECIMALESColumnName = "MONEDA_CANTIDADES_DECIMALES";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string CTACTE_BANCO_NOMBREColumnName = "CTACTE_BANCO_NOMBRE";
		public const string CTACTE_BANCO_ABREVIATURAColumnName = "CTACTE_BANCO_ABREVIATURA";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string NUMERO_CUENTAColumnName = "NUMERO_CUENTA";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string CTACTE_CAJA_TESORERIA_NOMBREColumnName = "CTACTE_CAJA_TESORERIA_NOMBRE";
		public const string CTACTE_CAJA_TESO_ABREVIATURAColumnName = "CTACTE_CAJA_TESO_ABREVIATURA";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string CTACTE_CAJA_SUC_FUNC_NOMBREColumnName = "CTACTE_CAJA_SUC_FUNC_NOMBRE";
		public const string CTACTE_CAJA_SUC_NRO_COMPColumnName = "CTACTE_CAJA_SUC_NRO_COMP";
		public const string CTACTE_CAJA_SUC_FECHA_INIColumnName = "CTACTE_CAJA_SUC_FECHA_INI";
		public const string CTACTE_CAJA_SUC_FECHA_FINColumnName = "CTACTE_CAJA_SUC_FECHA_FIN";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string TOTAL_EFECTIVOColumnName = "TOTAL_EFECTIVO";
		public const string TOTAL_CHEQUE_MISMO_BANCOColumnName = "TOTAL_CHEQUE_MISMO_BANCO";
		public const string TOTAL_CHEQUE_OTRO_BANCOColumnName = "TOTAL_CHEQUE_OTRO_BANCO";
		public const string TOTAL_IMPORTEColumnName = "TOTAL_IMPORTE";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TEXTO_PREDEFINIDO_NOMBREColumnName = "TEXTO_PREDEFINIDO_NOMBRE";
		public const string INCLUYE_PERSONAColumnName = "INCLUYE_PERSONA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DEPOSITOS_BANCARIOS_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DEPOSITOS_BANCARIOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOS_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DEPOSITOS_BANCARIOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DEPOSITOS_BANCARIOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DEPOSITOS_BANCARIOS_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DEPOSITOS_BANCARIOS_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects.</returns>
		public DEPOSITOS_BANCARIOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DEPOSITOS_BANCARIOS_INFO_COMPL";
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects.</returns>
		protected DEPOSITOS_BANCARIOS_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects.</returns>
		protected DEPOSITOS_BANCARIOS_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> objects.</returns>
		protected virtual DEPOSITOS_BANCARIOS_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_nombre_completoColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE_COMPLETO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int deposito_desde_sucColumnIndex = reader.GetOrdinal("DEPOSITO_DESDE_SUC");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int moneda_cantidades_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDADES_DECIMALES");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int ctacte_banco_nombreColumnIndex = reader.GetOrdinal("CTACTE_BANCO_NOMBRE");
			int ctacte_banco_abreviaturaColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ABREVIATURA");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int numero_cuentaColumnIndex = reader.GetOrdinal("NUMERO_CUENTA");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int ctacte_caja_tesoreria_nombreColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_NOMBRE");
			int ctacte_caja_teso_abreviaturaColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_ABREVIATURA");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int ctacte_caja_suc_func_nombreColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUC_FUNC_NOMBRE");
			int ctacte_caja_suc_nro_compColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUC_NRO_COMP");
			int ctacte_caja_suc_fecha_iniColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUC_FECHA_INI");
			int ctacte_caja_suc_fecha_finColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUC_FECHA_FIN");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int total_efectivoColumnIndex = reader.GetOrdinal("TOTAL_EFECTIVO");
			int total_cheque_mismo_bancoColumnIndex = reader.GetOrdinal("TOTAL_CHEQUE_MISMO_BANCO");
			int total_cheque_otro_bancoColumnIndex = reader.GetOrdinal("TOTAL_CHEQUE_OTRO_BANCO");
			int total_importeColumnIndex = reader.GetOrdinal("TOTAL_IMPORTE");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int texto_predefinido_nombreColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_NOMBRE");
			int incluye_personaColumnIndex = reader.GetOrdinal("INCLUYE_PERSONA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DEPOSITOS_BANCARIOS_INFO_COMPLRow record = new DEPOSITOS_BANCARIOS_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_nombre_completoColumnIndex))
						record.FUNCIONARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(funcionario_nombre_completoColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.DEPOSITO_DESDE_SUC = Convert.ToString(reader.GetValue(deposito_desde_sucColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					record.MONEDA_CANTIDADES_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidades_decimalesColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					record.CTACTE_BANCO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_banco_nombreColumnIndex));
					record.CTACTE_BANCO_ABREVIATURA = Convert.ToString(reader.GetValue(ctacte_banco_abreviaturaColumnIndex));
					record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					record.NUMERO_CUENTA = Convert.ToString(reader.GetValue(numero_cuentaColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_tesoreria_idColumnIndex))
						record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_tesoreria_nombreColumnIndex))
						record.CTACTE_CAJA_TESORERIA_NOMBRE = Convert.ToString(reader.GetValue(ctacte_caja_tesoreria_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_teso_abreviaturaColumnIndex))
						record.CTACTE_CAJA_TESO_ABREVIATURA = Convert.ToString(reader.GetValue(ctacte_caja_teso_abreviaturaColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_suc_func_nombreColumnIndex))
						record.CTACTE_CAJA_SUC_FUNC_NOMBRE = Convert.ToString(reader.GetValue(ctacte_caja_suc_func_nombreColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_suc_nro_compColumnIndex))
						record.CTACTE_CAJA_SUC_NRO_COMP = Convert.ToString(reader.GetValue(ctacte_caja_suc_nro_compColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_suc_fecha_iniColumnIndex))
						record.CTACTE_CAJA_SUC_FECHA_INI = Convert.ToDateTime(reader.GetValue(ctacte_caja_suc_fecha_iniColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_suc_fecha_finColumnIndex))
						record.CTACTE_CAJA_SUC_FECHA_FIN = Convert.ToDateTime(reader.GetValue(ctacte_caja_suc_fecha_finColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.TOTAL_EFECTIVO = Math.Round(Convert.ToDecimal(reader.GetValue(total_efectivoColumnIndex)), 9);
					record.TOTAL_CHEQUE_MISMO_BANCO = Math.Round(Convert.ToDecimal(reader.GetValue(total_cheque_mismo_bancoColumnIndex)), 9);
					record.TOTAL_CHEQUE_OTRO_BANCO = Math.Round(Convert.ToDecimal(reader.GetValue(total_cheque_otro_bancoColumnIndex)), 9);
					record.TOTAL_IMPORTE = Math.Round(Convert.ToDecimal(reader.GetValue(total_importeColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_nombreColumnIndex))
						record.TEXTO_PREDEFINIDO_NOMBRE = Convert.ToString(reader.GetValue(texto_predefinido_nombreColumnIndex));
					record.INCLUYE_PERSONA = Convert.ToString(reader.GetValue(incluye_personaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DEPOSITOS_BANCARIOS_INFO_COMPLRow[])(recordList.ToArray(typeof(DEPOSITOS_BANCARIOS_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DEPOSITOS_BANCARIOS_INFO_COMPLRow"/> object.</returns>
		protected virtual DEPOSITOS_BANCARIOS_INFO_COMPLRow MapRow(DataRow row)
		{
			DEPOSITOS_BANCARIOS_INFO_COMPLRow mappedObject = new DEPOSITOS_BANCARIOS_INFO_COMPLRow();
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
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "DEPOSITO_DESDE_SUC"
			dataColumn = dataTable.Columns["DEPOSITO_DESDE_SUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_DESDE_SUC = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "MONEDA_CANTIDADES_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDADES_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDADES_DECIMALES = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_BANCO_ABREVIATURA"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ABREVIATURA = (string)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "NUMERO_CUENTA"
			dataColumn = dataTable.Columns["NUMERO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_ABREVIATURA"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_ABREVIATURA = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUC_FUNC_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUC_FUNC_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUC_FUNC_NOMBRE = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUC_NRO_COMP"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUC_NRO_COMP"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUC_NRO_COMP = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUC_FECHA_INI"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUC_FECHA_INI"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUC_FECHA_INI = (System.DateTime)row[dataColumn];
			// Column "CTACTE_CAJA_SUC_FECHA_FIN"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUC_FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUC_FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "TOTAL_EFECTIVO"
			dataColumn = dataTable.Columns["TOTAL_EFECTIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_EFECTIVO = (decimal)row[dataColumn];
			// Column "TOTAL_CHEQUE_MISMO_BANCO"
			dataColumn = dataTable.Columns["TOTAL_CHEQUE_MISMO_BANCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CHEQUE_MISMO_BANCO = (decimal)row[dataColumn];
			// Column "TOTAL_CHEQUE_OTRO_BANCO"
			dataColumn = dataTable.Columns["TOTAL_CHEQUE_OTRO_BANCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CHEQUE_OTRO_BANCO = (decimal)row[dataColumn];
			// Column "TOTAL_IMPORTE"
			dataColumn = dataTable.Columns["TOTAL_IMPORTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPORTE = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_NOMBRE"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_NOMBRE = (string)row[dataColumn];
			// Column "INCLUYE_PERSONA"
			dataColumn = dataTable.Columns["INCLUYE_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUYE_PERSONA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DEPOSITOS_BANCARIOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DEPOSITOS_BANCARIOS_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_DESDE_SUC", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDADES_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUC_FUNC_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUC_NRO_COMP", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUC_FECHA_INI", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUC_FECHA_FIN", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_EFECTIVO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CHEQUE_MISMO_BANCO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CHEQUE_OTRO_BANCO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_IMPORTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INCLUYE_PERSONA", typeof(string));
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DEPOSITO_DESDE_SUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CANTIDADES_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESORERIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_TESO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUC_FUNC_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_SUC_NRO_COMP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_CAJA_SUC_FECHA_INI":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CTACTE_CAJA_SUC_FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_EFECTIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CHEQUE_MISMO_BANCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CHEQUE_OTRO_BANCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPORTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INCLUYE_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DEPOSITOS_BANCARIOS_INFO_COMPLCollection_Base class
}  // End of namespace
