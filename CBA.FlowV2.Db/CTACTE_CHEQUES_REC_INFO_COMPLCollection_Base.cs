// <fileinfo name="CTACTE_CHEQUES_REC_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_REC_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CHEQUES_REC_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_REC_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string BANCO_NOMBREColumnName = "BANCO_NOMBRE";
		public const string BANCO_ABREVIATURAColumnName = "BANCO_ABREVIATURA";
		public const string BANCO_CODIGOColumnName = "BANCO_CODIGO";
		public const string BANCO_ENTIDADColumnName = "BANCO_ENTIDAD";
		public const string ENTIDAD_NOMBREColumnName = "ENTIDAD_NOMBRE";
		public const string NUMERO_CUENTAColumnName = "NUMERO_CUENTA";
		public const string NUMERO_CHEQUEColumnName = "NUMERO_CHEQUE";
		public const string NOMBRE_EMISORColumnName = "NOMBRE_EMISOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_POSDATADOColumnName = "FECHA_POSDATADO";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_COBROColumnName = "FECHA_COBRO";
		public const string FECHA_RECHAZOColumnName = "FECHA_RECHAZO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string NUMERO_DOCUMENTO_EMISORColumnName = "NUMERO_DOCUMENTO_EMISOR";
		public const string MONEDAS_NOMBREColumnName = "MONEDAS_NOMBRE";
		public const string MONEDAS_SIMBOLOColumnName = "MONEDAS_SIMBOLO";
		public const string CANTIDADES_DECIMALESColumnName = "CANTIDADES_DECIMALES";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string DEPOSITO_BANCARIO_IDColumnName = "DEPOSITO_BANCARIO_ID";
		public const string CUSTODIA_VALORES_IDColumnName = "CUSTODIA_VALORES_ID";
		public const string DESCUENTO_DOCUMENTOS_IDColumnName = "DESCUENTO_DOCUMENTOS_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string MOTIVO_RECHAZOColumnName = "MOTIVO_RECHAZO";
		public const string CHEQUE_ESTADO_IDColumnName = "CHEQUE_ESTADO_ID";
		public const string ESTADO_CHEQUEColumnName = "ESTADO_CHEQUE";
		public const string ESTADO_ABREVIADOColumnName = "ESTADO_ABREVIADO";
		public const string CHEQUE_DE_TERCEROSColumnName = "CHEQUE_DE_TERCEROS";
		public const string CASO_CREADOR_IDColumnName = "CASO_CREADOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PROVEEDOR_RAZON_SOCIALColumnName = "PROVEEDOR_RAZON_SOCIAL";
		public const string ES_DIFERIDOColumnName = "ES_DIFERIDO";
		public const string ESTADOColumnName = "ESTADO";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string CTACTE_CAJA_TESORERIA_NOMBREColumnName = "CTACTE_CAJA_TESORERIA_NOMBRE";
		public const string FUNCIONARIO_ASIGNADO_IDColumnName = "FUNCIONARIO_ASIGNADO_ID";
		public const string FUNCIONARIO_ASIGNADO_NOMBREColumnName = "FUNCIONARIO_ASIGNADO_NOMBRE";
		public const string DATOS_RESUMIDOS_SIN_MONTOColumnName = "DATOS_RESUMIDOS_SIN_MONTO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_REC_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CHEQUES_REC_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CHEQUES_REC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CHEQUES_REC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CHEQUES_REC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CHEQUES_REC_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CHEQUES_REC_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects.</returns>
		public CTACTE_CHEQUES_REC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CHEQUES_REC_INFO_COMPL";
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects.</returns>
		protected CTACTE_CHEQUES_REC_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects.</returns>
		protected CTACTE_CHEQUES_REC_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> objects.</returns>
		protected virtual CTACTE_CHEQUES_REC_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int banco_nombreColumnIndex = reader.GetOrdinal("BANCO_NOMBRE");
			int banco_abreviaturaColumnIndex = reader.GetOrdinal("BANCO_ABREVIATURA");
			int banco_codigoColumnIndex = reader.GetOrdinal("BANCO_CODIGO");
			int banco_entidadColumnIndex = reader.GetOrdinal("BANCO_ENTIDAD");
			int entidad_nombreColumnIndex = reader.GetOrdinal("ENTIDAD_NOMBRE");
			int numero_cuentaColumnIndex = reader.GetOrdinal("NUMERO_CUENTA");
			int numero_chequeColumnIndex = reader.GetOrdinal("NUMERO_CHEQUE");
			int nombre_emisorColumnIndex = reader.GetOrdinal("NOMBRE_EMISOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_posdatadoColumnIndex = reader.GetOrdinal("FECHA_POSDATADO");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_cobroColumnIndex = reader.GetOrdinal("FECHA_COBRO");
			int fecha_rechazoColumnIndex = reader.GetOrdinal("FECHA_RECHAZO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int numero_documento_emisorColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO_EMISOR");
			int monedas_nombreColumnIndex = reader.GetOrdinal("MONEDAS_NOMBRE");
			int monedas_simboloColumnIndex = reader.GetOrdinal("MONEDAS_SIMBOLO");
			int cantidades_decimalesColumnIndex = reader.GetOrdinal("CANTIDADES_DECIMALES");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int deposito_bancario_idColumnIndex = reader.GetOrdinal("DEPOSITO_BANCARIO_ID");
			int custodia_valores_idColumnIndex = reader.GetOrdinal("CUSTODIA_VALORES_ID");
			int descuento_documentos_idColumnIndex = reader.GetOrdinal("DESCUENTO_DOCUMENTOS_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int motivo_rechazoColumnIndex = reader.GetOrdinal("MOTIVO_RECHAZO");
			int cheque_estado_idColumnIndex = reader.GetOrdinal("CHEQUE_ESTADO_ID");
			int estado_chequeColumnIndex = reader.GetOrdinal("ESTADO_CHEQUE");
			int estado_abreviadoColumnIndex = reader.GetOrdinal("ESTADO_ABREVIADO");
			int cheque_de_tercerosColumnIndex = reader.GetOrdinal("CHEQUE_DE_TERCEROS");
			int caso_creador_idColumnIndex = reader.GetOrdinal("CASO_CREADOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int proveedor_razon_socialColumnIndex = reader.GetOrdinal("PROVEEDOR_RAZON_SOCIAL");
			int es_diferidoColumnIndex = reader.GetOrdinal("ES_DIFERIDO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int ctacte_caja_tesoreria_nombreColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_NOMBRE");
			int funcionario_asignado_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ASIGNADO_ID");
			int funcionario_asignado_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_ASIGNADO_NOMBRE");
			int datos_resumidos_sin_montoColumnIndex = reader.GetOrdinal("DATOS_RESUMIDOS_SIN_MONTO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CHEQUES_REC_INFO_COMPLRow record = new CTACTE_CHEQUES_REC_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					record.BANCO_NOMBRE = Convert.ToString(reader.GetValue(banco_nombreColumnIndex));
					record.BANCO_ABREVIATURA = Convert.ToString(reader.GetValue(banco_abreviaturaColumnIndex));
					if(!reader.IsDBNull(banco_codigoColumnIndex))
						record.BANCO_CODIGO = Convert.ToString(reader.GetValue(banco_codigoColumnIndex));
					record.BANCO_ENTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(banco_entidadColumnIndex)), 9);
					record.ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(entidad_nombreColumnIndex));
					if(!reader.IsDBNull(numero_cuentaColumnIndex))
						record.NUMERO_CUENTA = Convert.ToString(reader.GetValue(numero_cuentaColumnIndex));
					record.NUMERO_CHEQUE = Convert.ToString(reader.GetValue(numero_chequeColumnIndex));
					if(!reader.IsDBNull(nombre_emisorColumnIndex))
						record.NOMBRE_EMISOR = Convert.ToString(reader.GetValue(nombre_emisorColumnIndex));
					if(!reader.IsDBNull(nombre_beneficiarioColumnIndex))
						record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.FECHA_POSDATADO = Convert.ToDateTime(reader.GetValue(fecha_posdatadoColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_cobroColumnIndex))
						record.FECHA_COBRO = Convert.ToDateTime(reader.GetValue(fecha_cobroColumnIndex));
					if(!reader.IsDBNull(fecha_rechazoColumnIndex))
						record.FECHA_RECHAZO = Convert.ToDateTime(reader.GetValue(fecha_rechazoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_documento_emisorColumnIndex))
						record.NUMERO_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(numero_documento_emisorColumnIndex));
					record.MONEDAS_NOMBRE = Convert.ToString(reader.GetValue(monedas_nombreColumnIndex));
					record.MONEDAS_SIMBOLO = Convert.ToString(reader.GetValue(monedas_simboloColumnIndex));
					record.CANTIDADES_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidades_decimalesColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_bancario_idColumnIndex))
						record.DEPOSITO_BANCARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_bancario_idColumnIndex)), 9);
					if(!reader.IsDBNull(custodia_valores_idColumnIndex))
						record.CUSTODIA_VALORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(custodia_valores_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_documentos_idColumnIndex))
						record.DESCUENTO_DOCUMENTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_documentos_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(motivo_rechazoColumnIndex))
						record.MOTIVO_RECHAZO = Convert.ToString(reader.GetValue(motivo_rechazoColumnIndex));
					if(!reader.IsDBNull(cheque_estado_idColumnIndex))
						record.CHEQUE_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_estado_idColumnIndex)), 9);
					record.ESTADO_CHEQUE = Convert.ToString(reader.GetValue(estado_chequeColumnIndex));
					if(!reader.IsDBNull(estado_abreviadoColumnIndex))
						record.ESTADO_ABREVIADO = Convert.ToString(reader.GetValue(estado_abreviadoColumnIndex));
					if(!reader.IsDBNull(cheque_de_tercerosColumnIndex))
						record.CHEQUE_DE_TERCEROS = Convert.ToString(reader.GetValue(cheque_de_tercerosColumnIndex));
					if(!reader.IsDBNull(caso_creador_idColumnIndex))
						record.CASO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_abreviaturaColumnIndex))
						record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(proveedor_razon_socialColumnIndex))
						record.PROVEEDOR_RAZON_SOCIAL = Convert.ToString(reader.GetValue(proveedor_razon_socialColumnIndex));
					record.ES_DIFERIDO = Convert.ToString(reader.GetValue(es_diferidoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_tesoreria_idColumnIndex))
						record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_tesoreria_nombreColumnIndex))
						record.CTACTE_CAJA_TESORERIA_NOMBRE = Convert.ToString(reader.GetValue(ctacte_caja_tesoreria_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_asignado_idColumnIndex))
						record.FUNCIONARIO_ASIGNADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_asignado_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_asignado_nombreColumnIndex))
						record.FUNCIONARIO_ASIGNADO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_asignado_nombreColumnIndex));
					if(!reader.IsDBNull(datos_resumidos_sin_montoColumnIndex))
						record.DATOS_RESUMIDOS_SIN_MONTO = Convert.ToString(reader.GetValue(datos_resumidos_sin_montoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CHEQUES_REC_INFO_COMPLRow[])(recordList.ToArray(typeof(CTACTE_CHEQUES_REC_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CHEQUES_REC_INFO_COMPLRow"/> object.</returns>
		protected virtual CTACTE_CHEQUES_REC_INFO_COMPLRow MapRow(DataRow row)
		{
			CTACTE_CHEQUES_REC_INFO_COMPLRow mappedObject = new CTACTE_CHEQUES_REC_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "BANCO_NOMBRE"
			dataColumn = dataTable.Columns["BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANCO_NOMBRE = (string)row[dataColumn];
			// Column "BANCO_ABREVIATURA"
			dataColumn = dataTable.Columns["BANCO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANCO_ABREVIATURA = (string)row[dataColumn];
			// Column "BANCO_CODIGO"
			dataColumn = dataTable.Columns["BANCO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANCO_CODIGO = (string)row[dataColumn];
			// Column "BANCO_ENTIDAD"
			dataColumn = dataTable.Columns["BANCO_ENTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANCO_ENTIDAD = (decimal)row[dataColumn];
			// Column "ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "NUMERO_CUENTA"
			dataColumn = dataTable.Columns["NUMERO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA = (string)row[dataColumn];
			// Column "NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_POSDATADO"
			dataColumn = dataTable.Columns["FECHA_POSDATADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSDATADO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_COBRO"
			dataColumn = dataTable.Columns["FECHA_COBRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COBRO = (System.DateTime)row[dataColumn];
			// Column "FECHA_RECHAZO"
			dataColumn = dataTable.Columns["FECHA_RECHAZO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECHAZO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "NUMERO_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["NUMERO_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "MONEDAS_NOMBRE"
			dataColumn = dataTable.Columns["MONEDAS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_NOMBRE = (string)row[dataColumn];
			// Column "MONEDAS_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDAS_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_SIMBOLO = (string)row[dataColumn];
			// Column "CANTIDADES_DECIMALES"
			dataColumn = dataTable.Columns["CANTIDADES_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDADES_DECIMALES = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "DEPOSITO_BANCARIO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_BANCARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_BANCARIO_ID = (decimal)row[dataColumn];
			// Column "CUSTODIA_VALORES_ID"
			dataColumn = dataTable.Columns["CUSTODIA_VALORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUSTODIA_VALORES_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_DOCUMENTOS_ID"
			dataColumn = dataTable.Columns["DESCUENTO_DOCUMENTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_DOCUMENTOS_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "MOTIVO_RECHAZO"
			dataColumn = dataTable.Columns["MOTIVO_RECHAZO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_RECHAZO = (string)row[dataColumn];
			// Column "CHEQUE_ESTADO_ID"
			dataColumn = dataTable.Columns["CHEQUE_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ESTADO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_CHEQUE"
			dataColumn = dataTable.Columns["ESTADO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CHEQUE = (string)row[dataColumn];
			// Column "ESTADO_ABREVIADO"
			dataColumn = dataTable.Columns["ESTADO_ABREVIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ABREVIADO = (string)row[dataColumn];
			// Column "CHEQUE_DE_TERCEROS"
			dataColumn = dataTable.Columns["CHEQUE_DE_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DE_TERCEROS = (string)row[dataColumn];
			// Column "CASO_CREADOR_ID"
			dataColumn = dataTable.Columns["CASO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PROVEEDOR_RAZON_SOCIAL"
			dataColumn = dataTable.Columns["PROVEEDOR_RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_RAZON_SOCIAL = (string)row[dataColumn];
			// Column "ES_DIFERIDO"
			dataColumn = dataTable.Columns["ES_DIFERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_DIFERIDO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_ASIGNADO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ASIGNADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ASIGNADO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ASIGNADO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_ASIGNADO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ASIGNADO_NOMBRE = (string)row[dataColumn];
			// Column "DATOS_RESUMIDOS_SIN_MONTO"
			dataColumn = dataTable.Columns["DATOS_RESUMIDOS_SIN_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DATOS_RESUMIDOS_SIN_MONTO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CHEQUES_REC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CHEQUES_REC_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANCO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANCO_CODIGO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANCO_ENTIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_POSDATADO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_COBRO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_RECHAZO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDADES_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_BANCARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUSTODIA_VALORES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_DOCUMENTOS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOTIVO_RECHAZO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_ESTADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_ABREVIADO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_DE_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_CREADOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_DIFERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ASIGNADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ASIGNADO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DATOS_RESUMIDOS_SIN_MONTO", typeof(string));
			dataColumn.MaxLength = 434;
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

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BANCO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BANCO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BANCO_ENTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_POSDATADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_COBRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_RECHAZO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDAS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDAS_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDADES_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_BANCARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUSTODIA_VALORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_DOCUMENTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOTIVO_RECHAZO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_ABREVIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DE_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_DIFERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESORERIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ASIGNADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ASIGNADO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DATOS_RESUMIDOS_SIN_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CHEQUES_REC_INFO_COMPLCollection_Base class
}  // End of namespace
