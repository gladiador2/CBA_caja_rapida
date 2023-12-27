// <fileinfo name="PEDIDOS_CLIENTE_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_CLIENTE_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PEDIDOS_CLIENTE_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_CLIENTE_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";
		public const string LISTA_PRECIO_NOMBREColumnName = "LISTA_PRECIO_NOMBRE";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSALColumnName = "SUCURSAL";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string DEPOSITOColumnName = "DEPOSITO";
		public const string FECHAColumnName = "FECHA";
		public const string VENDEDOR_IDColumnName = "VENDEDOR_ID";
		public const string VENDEDORColumnName = "VENDEDOR";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONAColumnName = "PERSONA";
		public const string DIRECCIONColumnName = "DIRECCION";
		public const string RUCColumnName = "RUC";
		public const string TIPO_FACTURA_IDColumnName = "TIPO_FACTURA_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string AUTONUMERACION_TIMBRADOColumnName = "AUTONUMERACION_TIMBRADO";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string CONDICION_PAGO_NOMBREColumnName = "CONDICION_PAGO_NOMBRE";
		public const string PORCENTAJE_DESC_SOBRE_TOTALColumnName = "PORCENTAJE_DESC_SOBRE_TOTAL";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string MONEDA_DESTINOColumnName = "MONEDA_DESTINO";
		public const string MONEDA_CANTIDAD_DECIMALESColumnName = "MONEDA_CANTIDAD_DECIMALES";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACION_DESTINOColumnName = "COTIZACION_DESTINO";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string TOTAL_COSTO_BRUTOColumnName = "TOTAL_COSTO_BRUTO";
		public const string TOTAL_COSTO_NETOColumnName = "TOTAL_COSTO_NETO";
		public const string TOTAL_COMISION_VENDEDORColumnName = "TOTAL_COMISION_VENDEDOR";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string USUARIO_ID_AUTORIZA_DESCUENTOColumnName = "USUARIO_ID_AUTORIZA_DESCUENTO";
		public const string FECHA_AUTORIZACION_DESCUENTOColumnName = "FECHA_AUTORIZACION_DESCUENTO";
		public const string DESCUENTO_MAX_AUTORIZADOColumnName = "DESCUENTO_MAX_AUTORIZADO";
		public const string AFECTA_LINEA_CREDITOColumnName = "AFECTA_LINEA_CREDITO";
		public const string MONTO_AFECTA_LINEA_CREDITOColumnName = "MONTO_AFECTA_LINEA_CREDITO";
		public const string COMISION_POR_VENTAColumnName = "COMISION_POR_VENTA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string APROBACION_DPTO_CREDITOColumnName = "APROBACION_DPTO_CREDITO";
		public const string FECHA_APROB_DPTO_CREDITOColumnName = "FECHA_APROB_DPTO_CREDITO";
		public const string USUARIO_APROB_DPTO_CREDITOColumnName = "USUARIO_APROB_DPTO_CREDITO";
		public const string APROBACION_DPTO_PRECIOSColumnName = "APROBACION_DPTO_PRECIOS";
		public const string FECHA_APROB_DPTO_PRECIOSColumnName = "FECHA_APROB_DPTO_PRECIOS";
		public const string USUARIO_APROB_DPTO_PRECIOSColumnName = "USUARIO_APROB_DPTO_PRECIOS";
		public const string SUCURSAL_VENTA_IDColumnName = "SUCURSAL_VENTA_ID";
		public const string SUCURSAL_VENTAColumnName = "SUCURSAL_VENTA";
		public const string PREVENTAColumnName = "PREVENTA";
		public const string PREVENTA_ORDENColumnName = "PREVENTA_ORDEN";
		public const string PREVENTA_FECHA_ENTREGAColumnName = "PREVENTA_FECHA_ENTREGA";
		public const string TOTAL_MONTO_BRUTO_INICIALColumnName = "TOTAL_MONTO_BRUTO_INICIAL";
		public const string TOTAL_MONTO_BRUTO_FINALColumnName = "TOTAL_MONTO_BRUTO_FINAL";
		public const string TOTAL_ENTREGA_INICIALColumnName = "TOTAL_ENTREGA_INICIAL";
		public const string TOTAL_FINAL_SUBITEMSColumnName = "TOTAL_FINAL_SUBITEMS";
		public const string TEXTO_OBS_DPTO_CREDITO_IDColumnName = "TEXTO_OBS_DPTO_CREDITO_ID";
		public const string TEXTO_OBS_DPTO_PRECIOS_IDColumnName = "TEXTO_OBS_DPTO_PRECIOS_ID";
		public const string CONTROLAR_CANT_MIN_DESC_MAXColumnName = "CONTROLAR_CANT_MIN_DESC_MAX";
		public const string TEXTO_OBS_DPTO_CREDITOColumnName = "TEXTO_OBS_DPTO_CREDITO";
		public const string TEXTO_OBS_DPTO_PRECIOSColumnName = "TEXTO_OBS_DPTO_PRECIOS";
		public const string A_CONSIGNACIONColumnName = "A_CONSIGNACION";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string MONTO_CREDITO_APROBADOColumnName = "MONTO_CREDITO_APROBADO";
		public const string USAR_REMISIONESColumnName = "USAR_REMISIONES";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTE_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PEDIDOS_CLIENTE_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PEDIDOS_CLIENTE_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PEDIDOS_CLIENTE_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PEDIDOS_CLIENTE_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PEDIDOS_CLIENTE_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PEDIDOS_CLIENTE_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects.</returns>
		public PEDIDOS_CLIENTE_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PEDIDOS_CLIENTE_INFO_COMPL";
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects.</returns>
		protected PEDIDOS_CLIENTE_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects.</returns>
		protected PEDIDOS_CLIENTE_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> objects.</returns>
		protected virtual PEDIDOS_CLIENTE_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");
			int lista_precio_nombreColumnIndex = reader.GetOrdinal("LISTA_PRECIO_NOMBRE");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursalColumnIndex = reader.GetOrdinal("SUCURSAL");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int depositoColumnIndex = reader.GetOrdinal("DEPOSITO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int vendedor_idColumnIndex = reader.GetOrdinal("VENDEDOR_ID");
			int vendedorColumnIndex = reader.GetOrdinal("VENDEDOR");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int personaColumnIndex = reader.GetOrdinal("PERSONA");
			int direccionColumnIndex = reader.GetOrdinal("DIRECCION");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int tipo_factura_idColumnIndex = reader.GetOrdinal("TIPO_FACTURA_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int autonumeracion_timbradoColumnIndex = reader.GetOrdinal("AUTONUMERACION_TIMBRADO");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int condicion_pago_nombreColumnIndex = reader.GetOrdinal("CONDICION_PAGO_NOMBRE");
			int porcentaje_desc_sobre_totalColumnIndex = reader.GetOrdinal("PORCENTAJE_DESC_SOBRE_TOTAL");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int moneda_destinoColumnIndex = reader.GetOrdinal("MONEDA_DESTINO");
			int moneda_cantidad_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDAD_DECIMALES");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacion_destinoColumnIndex = reader.GetOrdinal("COTIZACION_DESTINO");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int total_costo_brutoColumnIndex = reader.GetOrdinal("TOTAL_COSTO_BRUTO");
			int total_costo_netoColumnIndex = reader.GetOrdinal("TOTAL_COSTO_NETO");
			int total_comision_vendedorColumnIndex = reader.GetOrdinal("TOTAL_COMISION_VENDEDOR");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int usuario_id_autoriza_descuentoColumnIndex = reader.GetOrdinal("USUARIO_ID_AUTORIZA_DESCUENTO");
			int fecha_autorizacion_descuentoColumnIndex = reader.GetOrdinal("FECHA_AUTORIZACION_DESCUENTO");
			int descuento_max_autorizadoColumnIndex = reader.GetOrdinal("DESCUENTO_MAX_AUTORIZADO");
			int afecta_linea_creditoColumnIndex = reader.GetOrdinal("AFECTA_LINEA_CREDITO");
			int monto_afecta_linea_creditoColumnIndex = reader.GetOrdinal("MONTO_AFECTA_LINEA_CREDITO");
			int comision_por_ventaColumnIndex = reader.GetOrdinal("COMISION_POR_VENTA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int aprobacion_dpto_creditoColumnIndex = reader.GetOrdinal("APROBACION_DPTO_CREDITO");
			int fecha_aprob_dpto_creditoColumnIndex = reader.GetOrdinal("FECHA_APROB_DPTO_CREDITO");
			int usuario_aprob_dpto_creditoColumnIndex = reader.GetOrdinal("USUARIO_APROB_DPTO_CREDITO");
			int aprobacion_dpto_preciosColumnIndex = reader.GetOrdinal("APROBACION_DPTO_PRECIOS");
			int fecha_aprob_dpto_preciosColumnIndex = reader.GetOrdinal("FECHA_APROB_DPTO_PRECIOS");
			int usuario_aprob_dpto_preciosColumnIndex = reader.GetOrdinal("USUARIO_APROB_DPTO_PRECIOS");
			int sucursal_venta_idColumnIndex = reader.GetOrdinal("SUCURSAL_VENTA_ID");
			int sucursal_ventaColumnIndex = reader.GetOrdinal("SUCURSAL_VENTA");
			int preventaColumnIndex = reader.GetOrdinal("PREVENTA");
			int preventa_ordenColumnIndex = reader.GetOrdinal("PREVENTA_ORDEN");
			int preventa_fecha_entregaColumnIndex = reader.GetOrdinal("PREVENTA_FECHA_ENTREGA");
			int total_monto_bruto_inicialColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO_INICIAL");
			int total_monto_bruto_finalColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO_FINAL");
			int total_entrega_inicialColumnIndex = reader.GetOrdinal("TOTAL_ENTREGA_INICIAL");
			int total_final_subitemsColumnIndex = reader.GetOrdinal("TOTAL_FINAL_SUBITEMS");
			int texto_obs_dpto_credito_idColumnIndex = reader.GetOrdinal("TEXTO_OBS_DPTO_CREDITO_ID");
			int texto_obs_dpto_precios_idColumnIndex = reader.GetOrdinal("TEXTO_OBS_DPTO_PRECIOS_ID");
			int controlar_cant_min_desc_maxColumnIndex = reader.GetOrdinal("CONTROLAR_CANT_MIN_DESC_MAX");
			int texto_obs_dpto_creditoColumnIndex = reader.GetOrdinal("TEXTO_OBS_DPTO_CREDITO");
			int texto_obs_dpto_preciosColumnIndex = reader.GetOrdinal("TEXTO_OBS_DPTO_PRECIOS");
			int a_consignacionColumnIndex = reader.GetOrdinal("A_CONSIGNACION");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int monto_credito_aprobadoColumnIndex = reader.GetOrdinal("MONTO_CREDITO_APROBADO");
			int usar_remisionesColumnIndex = reader.GetOrdinal("USAR_REMISIONES");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PEDIDOS_CLIENTE_INFO_COMPLRow record = new PEDIDOS_CLIENTE_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precio_nombreColumnIndex))
						record.LISTA_PRECIO_NOMBRE = Convert.ToString(reader.GetValue(lista_precio_nombreColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL = Convert.ToString(reader.GetValue(sucursalColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.DEPOSITO = Convert.ToString(reader.GetValue(depositoColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(vendedor_idColumnIndex))
						record.VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedorColumnIndex))
						record.VENDEDOR = Convert.ToString(reader.GetValue(vendedorColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(personaColumnIndex))
						record.PERSONA = Convert.ToString(reader.GetValue(personaColumnIndex));
					if(!reader.IsDBNull(direccionColumnIndex))
						record.DIRECCION = Convert.ToString(reader.GetValue(direccionColumnIndex));
					if(!reader.IsDBNull(rucColumnIndex))
						record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
					if(!reader.IsDBNull(tipo_factura_idColumnIndex))
						record.TIPO_FACTURA_ID = Convert.ToString(reader.GetValue(tipo_factura_idColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_timbradoColumnIndex))
						record.AUTONUMERACION_TIMBRADO = Convert.ToString(reader.GetValue(autonumeracion_timbradoColumnIndex));
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					record.CONDICION_PAGO_NOMBRE = Convert.ToString(reader.GetValue(condicion_pago_nombreColumnIndex));
					if(!reader.IsDBNull(porcentaje_desc_sobre_totalColumnIndex))
						record.PORCENTAJE_DESC_SOBRE_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_desc_sobre_totalColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_destino_idColumnIndex))
						record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					record.MONEDA_DESTINO = Convert.ToString(reader.GetValue(moneda_destinoColumnIndex));
					record.MONEDA_CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidad_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(cotizacion_destinoColumnIndex))
						record.COTIZACION_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_impuestoColumnIndex))
						record.TOTAL_MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_dtoColumnIndex))
						record.TOTAL_MONTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_dtoColumnIndex)), 9);
					if(!reader.IsDBNull(total_netoColumnIndex))
						record.TOTAL_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costo_brutoColumnIndex))
						record.TOTAL_COSTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costo_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costo_netoColumnIndex))
						record.TOTAL_COSTO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costo_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_comision_vendedorColumnIndex))
						record.TOTAL_COMISION_VENDEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(total_comision_vendedorColumnIndex)), 9);
					record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_id_autoriza_descuentoColumnIndex))
						record.USUARIO_ID_AUTORIZA_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_id_autoriza_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_autorizacion_descuentoColumnIndex))
						record.FECHA_AUTORIZACION_DESCUENTO = Convert.ToDateTime(reader.GetValue(fecha_autorizacion_descuentoColumnIndex));
					if(!reader.IsDBNull(descuento_max_autorizadoColumnIndex))
						record.DESCUENTO_MAX_AUTORIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_max_autorizadoColumnIndex)), 9);
					record.AFECTA_LINEA_CREDITO = Convert.ToString(reader.GetValue(afecta_linea_creditoColumnIndex));
					if(!reader.IsDBNull(monto_afecta_linea_creditoColumnIndex))
						record.MONTO_AFECTA_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_afecta_linea_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(comision_por_ventaColumnIndex))
						record.COMISION_POR_VENTA = Convert.ToString(reader.GetValue(comision_por_ventaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(aprobacion_dpto_creditoColumnIndex))
						record.APROBACION_DPTO_CREDITO = Convert.ToString(reader.GetValue(aprobacion_dpto_creditoColumnIndex));
					if(!reader.IsDBNull(fecha_aprob_dpto_creditoColumnIndex))
						record.FECHA_APROB_DPTO_CREDITO = Convert.ToDateTime(reader.GetValue(fecha_aprob_dpto_creditoColumnIndex));
					if(!reader.IsDBNull(usuario_aprob_dpto_creditoColumnIndex))
						record.USUARIO_APROB_DPTO_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprob_dpto_creditoColumnIndex)), 9);
					record.APROBACION_DPTO_PRECIOS = Convert.ToString(reader.GetValue(aprobacion_dpto_preciosColumnIndex));
					if(!reader.IsDBNull(fecha_aprob_dpto_preciosColumnIndex))
						record.FECHA_APROB_DPTO_PRECIOS = Convert.ToDateTime(reader.GetValue(fecha_aprob_dpto_preciosColumnIndex));
					if(!reader.IsDBNull(usuario_aprob_dpto_preciosColumnIndex))
						record.USUARIO_APROB_DPTO_PRECIOS = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprob_dpto_preciosColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_venta_idColumnIndex))
						record.SUCURSAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_venta_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_ventaColumnIndex))
						record.SUCURSAL_VENTA = Convert.ToString(reader.GetValue(sucursal_ventaColumnIndex));
					record.PREVENTA = Convert.ToString(reader.GetValue(preventaColumnIndex));
					if(!reader.IsDBNull(preventa_ordenColumnIndex))
						record.PREVENTA_ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(preventa_ordenColumnIndex)), 9);
					if(!reader.IsDBNull(preventa_fecha_entregaColumnIndex))
						record.PREVENTA_FECHA_ENTREGA = Convert.ToDateTime(reader.GetValue(preventa_fecha_entregaColumnIndex));
					if(!reader.IsDBNull(total_monto_bruto_inicialColumnIndex))
						record.TOTAL_MONTO_BRUTO_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_bruto_inicialColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_bruto_finalColumnIndex))
						record.TOTAL_MONTO_BRUTO_FINAL = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_bruto_finalColumnIndex)), 9);
					record.TOTAL_ENTREGA_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(total_entrega_inicialColumnIndex)), 9);
					if(!reader.IsDBNull(total_final_subitemsColumnIndex))
						record.TOTAL_FINAL_SUBITEMS = Math.Round(Convert.ToDecimal(reader.GetValue(total_final_subitemsColumnIndex)), 9);
					if(!reader.IsDBNull(texto_obs_dpto_credito_idColumnIndex))
						record.TEXTO_OBS_DPTO_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_obs_dpto_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_obs_dpto_precios_idColumnIndex))
						record.TEXTO_OBS_DPTO_PRECIOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_obs_dpto_precios_idColumnIndex)), 9);
					record.CONTROLAR_CANT_MIN_DESC_MAX = Convert.ToString(reader.GetValue(controlar_cant_min_desc_maxColumnIndex));
					if(!reader.IsDBNull(texto_obs_dpto_creditoColumnIndex))
						record.TEXTO_OBS_DPTO_CREDITO = Convert.ToString(reader.GetValue(texto_obs_dpto_creditoColumnIndex));
					if(!reader.IsDBNull(texto_obs_dpto_preciosColumnIndex))
						record.TEXTO_OBS_DPTO_PRECIOS = Convert.ToString(reader.GetValue(texto_obs_dpto_preciosColumnIndex));
					record.A_CONSIGNACION = Convert.ToString(reader.GetValue(a_consignacionColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					if(!reader.IsDBNull(monto_credito_aprobadoColumnIndex))
						record.MONTO_CREDITO_APROBADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_credito_aprobadoColumnIndex)), 9);
					record.USAR_REMISIONES = Convert.ToString(reader.GetValue(usar_remisionesColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PEDIDOS_CLIENTE_INFO_COMPLRow[])(recordList.ToArray(typeof(PEDIDOS_CLIENTE_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PEDIDOS_CLIENTE_INFO_COMPLRow"/> object.</returns>
		protected virtual PEDIDOS_CLIENTE_INFO_COMPLRow MapRow(DataRow row)
		{
			PEDIDOS_CLIENTE_INFO_COMPLRow mappedObject = new PEDIDOS_CLIENTE_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_NOMBRE"
			dataColumn = dataTable.Columns["LISTA_PRECIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_NOMBRE = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL"
			dataColumn = dataTable.Columns["SUCURSAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO"
			dataColumn = dataTable.Columns["DEPOSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "VENDEDOR_ID"
			dataColumn = dataTable.Columns["VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR"
			dataColumn = dataTable.Columns["VENDEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PERSONA"
			dataColumn = dataTable.Columns["PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA = (string)row[dataColumn];
			// Column "DIRECCION"
			dataColumn = dataTable.Columns["DIRECCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION = (string)row[dataColumn];
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
			// Column "TIPO_FACTURA_ID"
			dataColumn = dataTable.Columns["TIPO_FACTURA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FACTURA_ID = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_TIMBRADO"
			dataColumn = dataTable.Columns["AUTONUMERACION_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_TIMBRADO = (string)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO_NOMBRE"
			dataColumn = dataTable.Columns["CONDICION_PAGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_NOMBRE = (string)row[dataColumn];
			// Column "PORCENTAJE_DESC_SOBRE_TOTAL"
			dataColumn = dataTable.Columns["PORCENTAJE_DESC_SOBRE_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESC_SOBRE_TOTAL = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO"
			dataColumn = dataTable.Columns["MONEDA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO = (string)row[dataColumn];
			// Column "MONEDA_CANTIDAD_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDAD_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDAD_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_DESTINO"
			dataColumn = dataTable.Columns["COTIZACION_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_DESTINO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_DTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_DTO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO"
			dataColumn = dataTable.Columns["TOTAL_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO = (decimal)row[dataColumn];
			// Column "TOTAL_COSTO_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_COSTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COSTO_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_COSTO_NETO"
			dataColumn = dataTable.Columns["TOTAL_COSTO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COSTO_NETO = (decimal)row[dataColumn];
			// Column "TOTAL_COMISION_VENDEDOR"
			dataColumn = dataTable.Columns["TOTAL_COMISION_VENDEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_COMISION_VENDEDOR = (decimal)row[dataColumn];
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "USUARIO_ID_AUTORIZA_DESCUENTO"
			dataColumn = dataTable.Columns["USUARIO_ID_AUTORIZA_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID_AUTORIZA_DESCUENTO = (decimal)row[dataColumn];
			// Column "FECHA_AUTORIZACION_DESCUENTO"
			dataColumn = dataTable.Columns["FECHA_AUTORIZACION_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_AUTORIZACION_DESCUENTO = (System.DateTime)row[dataColumn];
			// Column "DESCUENTO_MAX_AUTORIZADO"
			dataColumn = dataTable.Columns["DESCUENTO_MAX_AUTORIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_MAX_AUTORIZADO = (decimal)row[dataColumn];
			// Column "AFECTA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["AFECTA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_LINEA_CREDITO = (string)row[dataColumn];
			// Column "MONTO_AFECTA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["MONTO_AFECTA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_AFECTA_LINEA_CREDITO = (decimal)row[dataColumn];
			// Column "COMISION_POR_VENTA"
			dataColumn = dataTable.Columns["COMISION_POR_VENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMISION_POR_VENTA = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "APROBACION_DPTO_CREDITO"
			dataColumn = dataTable.Columns["APROBACION_DPTO_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_DPTO_CREDITO = (string)row[dataColumn];
			// Column "FECHA_APROB_DPTO_CREDITO"
			dataColumn = dataTable.Columns["FECHA_APROB_DPTO_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROB_DPTO_CREDITO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_APROB_DPTO_CREDITO"
			dataColumn = dataTable.Columns["USUARIO_APROB_DPTO_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROB_DPTO_CREDITO = (decimal)row[dataColumn];
			// Column "APROBACION_DPTO_PRECIOS"
			dataColumn = dataTable.Columns["APROBACION_DPTO_PRECIOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_DPTO_PRECIOS = (string)row[dataColumn];
			// Column "FECHA_APROB_DPTO_PRECIOS"
			dataColumn = dataTable.Columns["FECHA_APROB_DPTO_PRECIOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROB_DPTO_PRECIOS = (System.DateTime)row[dataColumn];
			// Column "USUARIO_APROB_DPTO_PRECIOS"
			dataColumn = dataTable.Columns["USUARIO_APROB_DPTO_PRECIOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROB_DPTO_PRECIOS = (decimal)row[dataColumn];
			// Column "SUCURSAL_VENTA_ID"
			dataColumn = dataTable.Columns["SUCURSAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_VENTA"
			dataColumn = dataTable.Columns["SUCURSAL_VENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_VENTA = (string)row[dataColumn];
			// Column "PREVENTA"
			dataColumn = dataTable.Columns["PREVENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PREVENTA = (string)row[dataColumn];
			// Column "PREVENTA_ORDEN"
			dataColumn = dataTable.Columns["PREVENTA_ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PREVENTA_ORDEN = (decimal)row[dataColumn];
			// Column "PREVENTA_FECHA_ENTREGA"
			dataColumn = dataTable.Columns["PREVENTA_FECHA_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PREVENTA_FECHA_ENTREGA = (System.DateTime)row[dataColumn];
			// Column "TOTAL_MONTO_BRUTO_INICIAL"
			dataColumn = dataTable.Columns["TOTAL_MONTO_BRUTO_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_BRUTO_INICIAL = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_BRUTO_FINAL"
			dataColumn = dataTable.Columns["TOTAL_MONTO_BRUTO_FINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_BRUTO_FINAL = (decimal)row[dataColumn];
			// Column "TOTAL_ENTREGA_INICIAL"
			dataColumn = dataTable.Columns["TOTAL_ENTREGA_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_ENTREGA_INICIAL = (decimal)row[dataColumn];
			// Column "TOTAL_FINAL_SUBITEMS"
			dataColumn = dataTable.Columns["TOTAL_FINAL_SUBITEMS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_FINAL_SUBITEMS = (decimal)row[dataColumn];
			// Column "TEXTO_OBS_DPTO_CREDITO_ID"
			dataColumn = dataTable.Columns["TEXTO_OBS_DPTO_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_OBS_DPTO_CREDITO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_OBS_DPTO_PRECIOS_ID"
			dataColumn = dataTable.Columns["TEXTO_OBS_DPTO_PRECIOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_OBS_DPTO_PRECIOS_ID = (decimal)row[dataColumn];
			// Column "CONTROLAR_CANT_MIN_DESC_MAX"
			dataColumn = dataTable.Columns["CONTROLAR_CANT_MIN_DESC_MAX"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROLAR_CANT_MIN_DESC_MAX = (string)row[dataColumn];
			// Column "TEXTO_OBS_DPTO_CREDITO"
			dataColumn = dataTable.Columns["TEXTO_OBS_DPTO_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_OBS_DPTO_CREDITO = (string)row[dataColumn];
			// Column "TEXTO_OBS_DPTO_PRECIOS"
			dataColumn = dataTable.Columns["TEXTO_OBS_DPTO_PRECIOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_OBS_DPTO_PRECIOS = (string)row[dataColumn];
			// Column "A_CONSIGNACION"
			dataColumn = dataTable.Columns["A_CONSIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_CONSIGNACION = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "MONTO_CREDITO_APROBADO"
			dataColumn = dataTable.Columns["MONTO_CREDITO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CREDITO_APROBADO = (decimal)row[dataColumn];
			// Column "USAR_REMISIONES"
			dataColumn = dataTable.Columns["USAR_REMISIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_REMISIONES = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PEDIDOS_CLIENTE_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PEDIDOS_CLIENTE_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIRECCION", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_FACTURA_ID", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESC_SOBRE_TOTAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDAD_DECIMALES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_DESTINO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_COMISION_VENDEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID_AUTORIZA_DESCUENTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_AUTORIZACION_DESCUENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAX_AUTORIZADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_LINEA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_AFECTA_LINEA_CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMISION_POR_VENTA", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APROBACION_DPTO_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_APROB_DPTO_CREDITO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_APROB_DPTO_CREDITO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APROBACION_DPTO_PRECIOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_APROB_DPTO_PRECIOS", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_APROB_DPTO_PRECIOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_VENTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_VENTA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PREVENTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PREVENTA_ORDEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PREVENTA_FECHA_ENTREGA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO_INICIAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO_FINAL", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_ENTREGA_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_FINAL_SUBITEMS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_OBS_DPTO_CREDITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_OBS_DPTO_PRECIOS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTROLAR_CANT_MIN_DESC_MAX", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_OBS_DPTO_CREDITO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_OBS_DPTO_PRECIOS", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("A_CONSIGNACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_CREDITO_APROBADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USAR_REMISIONES", typeof(string));
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

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DIRECCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_FACTURA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PORCENTAJE_DESC_SOBRE_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CANTIDAD_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COSTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COSTO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_COMISION_VENDEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID_AUTORIZA_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_AUTORIZACION_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESCUENTO_MAX_AUTORIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AFECTA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_AFECTA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMISION_POR_VENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APROBACION_DPTO_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_APROB_DPTO_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_APROB_DPTO_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APROBACION_DPTO_PRECIOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_APROB_DPTO_PRECIOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_APROB_DPTO_PRECIOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_VENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PREVENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PREVENTA_ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PREVENTA_FECHA_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TOTAL_MONTO_BRUTO_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_BRUTO_FINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_ENTREGA_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_FINAL_SUBITEMS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_OBS_DPTO_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_OBS_DPTO_PRECIOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTROLAR_CANT_MIN_DESC_MAX":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TEXTO_OBS_DPTO_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_OBS_DPTO_PRECIOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "A_CONSIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_CREDITO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USAR_REMISIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PEDIDOS_CLIENTE_INFO_COMPLCollection_Base class
}  // End of namespace
