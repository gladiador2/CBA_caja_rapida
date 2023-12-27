// <fileinfo name="APLICACION_DOCUMENTOS_INFO_COMCollection_Base.cs">
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
	/// The base class for <see cref="APLICACION_DOCUMENTOS_INFO_COMCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="APLICACION_DOCUMENTOS_INFO_COMCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class APLICACION_DOCUMENTOS_INFO_COMCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_CODIGOColumnName = "FUNCIONARIO_CODIGO";
		public const string FUNCIONARIO_NOMBRE_COMPLETOColumnName = "FUNCIONARIO_NOMBRE_COMPLETO";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string PERSONA_DOCUMENTOS_IDColumnName = "PERSONA_DOCUMENTOS_ID";
		public const string PERSONA_VALORES_IDColumnName = "PERSONA_VALORES_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string NRO_COMPROBANTE_EXTERNOColumnName = "NRO_COMPROBANTE_EXTERNO";
		public const string TOTAL_VALORESColumnName = "TOTAL_VALORES";
		public const string TOTAL_DOCUMENTOSColumnName = "TOTAL_DOCUMENTOS";
		public const string PERSONA_NOMBRE_DOCColumnName = "PERSONA_NOMBRE_DOC";
		public const string PERSONA_NOMBRE_VALColumnName = "PERSONA_NOMBRE_VAL";
		public const string PERSONA_CODIGO_DOCColumnName = "PERSONA_CODIGO_DOC";
		public const string PERSONA_CODIGO_VALColumnName = "PERSONA_CODIGO_VAL";
		public const string ESTADO_IDColumnName = "ESTADO_ID";
		public const string USUARIOColumnName = "USUARIO";
		public const string USUARIO_NOMBRE_COMPLETOColumnName = "USUARIO_NOMBRE_COMPLETO";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CANTIDAD_DECIMALESColumnName = "MONEDA_CANTIDAD_DECIMALES";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string AUTONUMERACION_RECIBO_IDColumnName = "AUTONUMERACION_RECIBO_ID";
		public const string AUTONUMERACION_RECIBO_CODIGOColumnName = "AUTONUMERACION_RECIBO_CODIGO";
		public const string CTACTE_RECIBO_IDColumnName = "CTACTE_RECIBO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string RECIBO_NUMEROColumnName = "RECIBO_NUMERO";
		public const string NRO_RECIBO_MANUALColumnName = "NRO_RECIBO_MANUAL";
		public const string CONSOLIDACION_DEUDAColumnName = "CONSOLIDACION_DEUDA";
		public const string NC_DEPOSITO_IDColumnName = "NC_DEPOSITO_ID";
		public const string NC_AUTONUMERACION_IDColumnName = "NC_AUTONUMERACION_ID";
		public const string NC_NRO_COMPROBANTEColumnName = "NC_NRO_COMPROBANTE";
		public const string NC_CTACTE_CAJA_SUCURSAL_IDColumnName = "NC_CTACTE_CAJA_SUCURSAL_ID";
		public const string FC_DEPOSITO_IDColumnName = "FC_DEPOSITO_ID";
		public const string FC_AUTONUMERACION_IDColumnName = "FC_AUTONUMERACION_ID";
		public const string FC_NRO_COMPROBANTEColumnName = "FC_NRO_COMPROBANTE";
		public const string FC_CTACTE_CAJA_SUCURSAL_IDColumnName = "FC_CTACTE_CAJA_SUCURSAL_ID";
		public const string FC_CASO_IDColumnName = "FC_CASO_ID";
		public const string MONTO_NUEVA_CUOTAColumnName = "MONTO_NUEVA_CUOTA";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="APLICACION_DOCUMENTOS_INFO_COMCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public APLICACION_DOCUMENTOS_INFO_COMCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>APLICACION_DOCUMENTOS_INFO_COM</c> view.
		/// </summary>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_INFO_COMRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>APLICACION_DOCUMENTOS_INFO_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>APLICACION_DOCUMENTOS_INFO_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public APLICACION_DOCUMENTOS_INFO_COMRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			APLICACION_DOCUMENTOS_INFO_COMRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects.</returns>
		public APLICACION_DOCUMENTOS_INFO_COMRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects that 
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects.</returns>
		public virtual APLICACION_DOCUMENTOS_INFO_COMRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.APLICACION_DOCUMENTOS_INFO_COM";
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects.</returns>
		protected APLICACION_DOCUMENTOS_INFO_COMRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects.</returns>
		protected APLICACION_DOCUMENTOS_INFO_COMRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> objects.</returns>
		protected virtual APLICACION_DOCUMENTOS_INFO_COMRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_codigoColumnIndex = reader.GetOrdinal("FUNCIONARIO_CODIGO");
			int funcionario_nombre_completoColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE_COMPLETO");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int persona_documentos_idColumnIndex = reader.GetOrdinal("PERSONA_DOCUMENTOS_ID");
			int persona_valores_idColumnIndex = reader.GetOrdinal("PERSONA_VALORES_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int nro_comprobante_externoColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_EXTERNO");
			int total_valoresColumnIndex = reader.GetOrdinal("TOTAL_VALORES");
			int total_documentosColumnIndex = reader.GetOrdinal("TOTAL_DOCUMENTOS");
			int persona_nombre_docColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_DOC");
			int persona_nombre_valColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_VAL");
			int persona_codigo_docColumnIndex = reader.GetOrdinal("PERSONA_CODIGO_DOC");
			int persona_codigo_valColumnIndex = reader.GetOrdinal("PERSONA_CODIGO_VAL");
			int estado_idColumnIndex = reader.GetOrdinal("ESTADO_ID");
			int usuarioColumnIndex = reader.GetOrdinal("USUARIO");
			int usuario_nombre_completoColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE_COMPLETO");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cantidad_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDAD_DECIMALES");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int autonumeracion_recibo_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_RECIBO_ID");
			int autonumeracion_recibo_codigoColumnIndex = reader.GetOrdinal("AUTONUMERACION_RECIBO_CODIGO");
			int ctacte_recibo_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int recibo_numeroColumnIndex = reader.GetOrdinal("RECIBO_NUMERO");
			int nro_recibo_manualColumnIndex = reader.GetOrdinal("NRO_RECIBO_MANUAL");
			int consolidacion_deudaColumnIndex = reader.GetOrdinal("CONSOLIDACION_DEUDA");
			int nc_deposito_idColumnIndex = reader.GetOrdinal("NC_DEPOSITO_ID");
			int nc_autonumeracion_idColumnIndex = reader.GetOrdinal("NC_AUTONUMERACION_ID");
			int nc_nro_comprobanteColumnIndex = reader.GetOrdinal("NC_NRO_COMPROBANTE");
			int nc_ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("NC_CTACTE_CAJA_SUCURSAL_ID");
			int fc_deposito_idColumnIndex = reader.GetOrdinal("FC_DEPOSITO_ID");
			int fc_autonumeracion_idColumnIndex = reader.GetOrdinal("FC_AUTONUMERACION_ID");
			int fc_nro_comprobanteColumnIndex = reader.GetOrdinal("FC_NRO_COMPROBANTE");
			int fc_ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("FC_CTACTE_CAJA_SUCURSAL_ID");
			int fc_caso_idColumnIndex = reader.GetOrdinal("FC_CASO_ID");
			int monto_nueva_cuotaColumnIndex = reader.GetOrdinal("MONTO_NUEVA_CUOTA");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					APLICACION_DOCUMENTOS_INFO_COMRow record = new APLICACION_DOCUMENTOS_INFO_COMRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_codigoColumnIndex))
						record.FUNCIONARIO_CODIGO = Convert.ToString(reader.GetValue(funcionario_codigoColumnIndex));
					if(!reader.IsDBNull(funcionario_nombre_completoColumnIndex))
						record.FUNCIONARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(funcionario_nombre_completoColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.PERSONA_DOCUMENTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_documentos_idColumnIndex)), 9);
					record.PERSONA_VALORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_valores_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_externoColumnIndex))
						record.NRO_COMPROBANTE_EXTERNO = Convert.ToString(reader.GetValue(nro_comprobante_externoColumnIndex));
					record.TOTAL_VALORES = Math.Round(Convert.ToDecimal(reader.GetValue(total_valoresColumnIndex)), 9);
					record.TOTAL_DOCUMENTOS = Math.Round(Convert.ToDecimal(reader.GetValue(total_documentosColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombre_docColumnIndex))
						record.PERSONA_NOMBRE_DOC = Convert.ToString(reader.GetValue(persona_nombre_docColumnIndex));
					if(!reader.IsDBNull(persona_nombre_valColumnIndex))
						record.PERSONA_NOMBRE_VAL = Convert.ToString(reader.GetValue(persona_nombre_valColumnIndex));
					if(!reader.IsDBNull(persona_codigo_docColumnIndex))
						record.PERSONA_CODIGO_DOC = Convert.ToString(reader.GetValue(persona_codigo_docColumnIndex));
					if(!reader.IsDBNull(persona_codigo_valColumnIndex))
						record.PERSONA_CODIGO_VAL = Convert.ToString(reader.GetValue(persona_codigo_valColumnIndex));
					record.ESTADO_ID = Convert.ToString(reader.GetValue(estado_idColumnIndex));
					record.USUARIO = Convert.ToString(reader.GetValue(usuarioColumnIndex));
					if(!reader.IsDBNull(usuario_nombre_completoColumnIndex))
						record.USUARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(usuario_nombre_completoColumnIndex));
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.MONEDA_CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidad_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(autonumeracion_recibo_idColumnIndex))
						record.AUTONUMERACION_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_recibo_codigoColumnIndex))
						record.AUTONUMERACION_RECIBO_CODIGO = Convert.ToString(reader.GetValue(autonumeracion_recibo_codigoColumnIndex));
					if(!reader.IsDBNull(ctacte_recibo_idColumnIndex))
						record.CTACTE_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(recibo_numeroColumnIndex))
						record.RECIBO_NUMERO = Convert.ToString(reader.GetValue(recibo_numeroColumnIndex));
					if(!reader.IsDBNull(nro_recibo_manualColumnIndex))
						record.NRO_RECIBO_MANUAL = Convert.ToString(reader.GetValue(nro_recibo_manualColumnIndex));
					if(!reader.IsDBNull(consolidacion_deudaColumnIndex))
						record.CONSOLIDACION_DEUDA = Convert.ToString(reader.GetValue(consolidacion_deudaColumnIndex));
					if(!reader.IsDBNull(nc_deposito_idColumnIndex))
						record.NC_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_autonumeracion_idColumnIndex))
						record.NC_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_nro_comprobanteColumnIndex))
						record.NC_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nc_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(nc_ctacte_caja_sucursal_idColumnIndex))
						record.NC_CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_deposito_idColumnIndex))
						record.FC_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_autonumeracion_idColumnIndex))
						record.FC_AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_nro_comprobanteColumnIndex))
						record.FC_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(fc_nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fc_ctacte_caja_sucursal_idColumnIndex))
						record.FC_CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_caso_idColumnIndex))
						record.FC_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_nueva_cuotaColumnIndex))
						record.MONTO_NUEVA_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_nueva_cuotaColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (APLICACION_DOCUMENTOS_INFO_COMRow[])(recordList.ToArray(typeof(APLICACION_DOCUMENTOS_INFO_COMRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="APLICACION_DOCUMENTOS_INFO_COMRow"/> object.</returns>
		protected virtual APLICACION_DOCUMENTOS_INFO_COMRow MapRow(DataRow row)
		{
			APLICACION_DOCUMENTOS_INFO_COMRow mappedObject = new APLICACION_DOCUMENTOS_INFO_COMRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
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
			// Column "FUNCIONARIO_CODIGO"
			dataColumn = dataTable.Columns["FUNCIONARIO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CODIGO = (string)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_DOCUMENTOS_ID"
			dataColumn = dataTable.Columns["PERSONA_DOCUMENTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DOCUMENTOS_ID = (decimal)row[dataColumn];
			// Column "PERSONA_VALORES_ID"
			dataColumn = dataTable.Columns["PERSONA_VALORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_VALORES_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE_EXTERNO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_EXTERNO = (string)row[dataColumn];
			// Column "TOTAL_VALORES"
			dataColumn = dataTable.Columns["TOTAL_VALORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_VALORES = (decimal)row[dataColumn];
			// Column "TOTAL_DOCUMENTOS"
			dataColumn = dataTable.Columns["TOTAL_DOCUMENTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DOCUMENTOS = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE_DOC"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_DOC"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_DOC = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE_VAL"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_VAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_VAL = (string)row[dataColumn];
			// Column "PERSONA_CODIGO_DOC"
			dataColumn = dataTable.Columns["PERSONA_CODIGO_DOC"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO_DOC = (string)row[dataColumn];
			// Column "PERSONA_CODIGO_VAL"
			dataColumn = dataTable.Columns["PERSONA_CODIGO_VAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO_VAL = (string)row[dataColumn];
			// Column "ESTADO_ID"
			dataColumn = dataTable.Columns["ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_ID = (string)row[dataColumn];
			// Column "USUARIO"
			dataColumn = dataTable.Columns["USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO = (string)row[dataColumn];
			// Column "USUARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "MONEDA_CANTIDAD_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDAD_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDAD_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "AUTONUMERACION_RECIBO_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_RECIBO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_RECIBO_CODIGO"
			dataColumn = dataTable.Columns["AUTONUMERACION_RECIBO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_RECIBO_CODIGO = (string)row[dataColumn];
			// Column "CTACTE_RECIBO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "RECIBO_NUMERO"
			dataColumn = dataTable.Columns["RECIBO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_NUMERO = (string)row[dataColumn];
			// Column "NRO_RECIBO_MANUAL"
			dataColumn = dataTable.Columns["NRO_RECIBO_MANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_RECIBO_MANUAL = (string)row[dataColumn];
			// Column "CONSOLIDACION_DEUDA"
			dataColumn = dataTable.Columns["CONSOLIDACION_DEUDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSOLIDACION_DEUDA = (string)row[dataColumn];
			// Column "NC_DEPOSITO_ID"
			dataColumn = dataTable.Columns["NC_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "NC_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["NC_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NC_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NC_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "NC_CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["NC_CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FC_DEPOSITO_ID"
			dataColumn = dataTable.Columns["FC_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FC_AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["FC_AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "FC_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["FC_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FC_CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["FC_CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FC_CASO_ID"
			dataColumn = dataTable.Columns["FC_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CASO_ID = (decimal)row[dataColumn];
			// Column "MONTO_NUEVA_CUOTA"
			dataColumn = dataTable.Columns["MONTO_NUEVA_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_NUEVA_CUOTA = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>APLICACION_DOCUMENTOS_INFO_COM</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "APLICACION_DOCUMENTOS_INFO_COM";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
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
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DOCUMENTOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_VALORES_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_VALORES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_DOCUMENTOS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_DOC", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_VAL", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO_DOC", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO_VAL", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDAD_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_RECIBO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_RECIBO_CODIGO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECIBO_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_RECIBO_MANUAL", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSOLIDACION_DEUDA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NC_DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NC_AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NC_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NC_CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_NUEVA_CUOTA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
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

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_DOCUMENTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_VALORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_VALORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DOCUMENTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE_DOC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE_VAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO_DOC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO_VAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CANTIDAD_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_RECIBO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RECIBO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_RECIBO_MANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSOLIDACION_DEUDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NC_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NC_CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FC_CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_NUEVA_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of APLICACION_DOCUMENTOS_INFO_COMCollection_Base class
}  // End of namespace
