// <fileinfo name="CTACTE_PAGOS_PERSONA_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PAGOS_PERSONA_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_RECIBO_IDColumnName = "CTACTE_RECIBO_ID";
		public const string CTACTE_RECIBO_NUMEROColumnName = "CTACTE_RECIBO_NUMERO";
		public const string RECIBO_EMITIR_POR_DOCUMENTOSColumnName = "RECIBO_EMITIR_POR_DOCUMENTOS";
		public const string CTACTE_RECIBO_NRO_COMPROBANTEColumnName = "CTACTE_RECIBO_NRO_COMPROBANTE";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string PERSONA_RUCColumnName = "PERSONA_RUC";
		public const string FECHAColumnName = "FECHA";
		public const string USUARIO_CARGA_IDColumnName = "USUARIO_CARGA_ID";
		public const string USUARIO_NOMBRE_COMPLETOColumnName = "USUARIO_NOMBRE_COMPLETO";
		public const string FUNCIONARIO_COBRADOR_IDColumnName = "FUNCIONARIO_COBRADOR_ID";
		public const string FUNCIONARIO_NOMBRE_COMPLETOColumnName = "FUNCIONARIO_NOMBRE_COMPLETO";
		public const string FUNCIONARIO_COBRADOR_EXTER_IDColumnName = "FUNCIONARIO_COBRADOR_EXTER_ID";
		public const string FUNCIONARIO_COBR_EXT_NOMBREColumnName = "FUNCIONARIO_COBR_EXT_NOMBRE";
		public const string MONEDA_TOTAL_VUELTO_IDColumnName = "MONEDA_TOTAL_VUELTO_ID";
		public const string MONEDA_TOTAL_VUELTO_NOMBREColumnName = "MONEDA_TOTAL_VUELTO_NOMBRE";
		public const string MONEDA_TOTAL_VUELTO_SIMBOLOColumnName = "MONEDA_TOTAL_VUELTO_SIMBOLO";
		public const string COTIZACION_MONEDA_TOTAL_VUELTOColumnName = "COTIZACION_MONEDA_TOTAL_VUELTO";
		public const string MONTO_TOTAL_VUELTOColumnName = "MONTO_TOTAL_VUELTO";
		public const string VUELTO_CONVERTIDO_A_ANTICIPOColumnName = "VUELTO_CONVERTIDO_A_ANTICIPO";
		public const string CASO_ANTICIPO_IDColumnName = "CASO_ANTICIPO_ID";
		public const string CASO_ANTICIPO_ESTADO_IDColumnName = "CASO_ANTICIPO_ESTADO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string PAGO_CONFIRMADOColumnName = "PAGO_CONFIRMADO";
		public const string FC_CLIENTE1_COMPROBANTE_IDColumnName = "FC_CLIENTE1_COMPROBANTE_ID";
		public const string FACTURA_CLIENTE_COMP1_CASO_IDColumnName = "FACTURA_CLIENTE_COMP1_CASO_ID";
		public const string FC_CLIENTE1_COMP_AUTON_IDColumnName = "FC_CLIENTE1_COMP_AUTON_ID";
		public const string FC_CLIENTE2_COMPROBANTE_IDColumnName = "FC_CLIENTE2_COMPROBANTE_ID";
		public const string FACTURA_CLIENTE_COMP2_CASO_IDColumnName = "FACTURA_CLIENTE_COMP2_CASO_ID";
		public const string FC_CLIENTE2_COMP_AUTON_IDColumnName = "FC_CLIENTE2_COMP_AUTON_ID";
		public const string FECHA_CONFIRMACIONColumnName = "FECHA_CONFIRMACION";
		public const string AUTONUMERACION_RECIBO_IDColumnName = "AUTONUMERACION_RECIBO_ID";
		public const string AUTONUMERACION_ANTICIPO_IDColumnName = "AUTONUMERACION_ANTICIPO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string NOMBRE_TEXTO_PREDEFINIDOColumnName = "NOMBRE_TEXTO_PREDEFINIDO";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PAGOS_PERSONA_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PAGOS_PERSONA_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PAGOS_PERSONA_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PAGOS_PERSONA_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PAGOS_PERSONA_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PAGOS_PERSONA_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects.</returns>
		public CTACTE_PAGOS_PERSONA_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_PAGOS_PERSONA_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PAGOS_PERSONA_INFO_COMP";
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_PAGOS_PERSONA_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_PAGOS_PERSONA_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> objects.</returns>
		protected virtual CTACTE_PAGOS_PERSONA_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_recibo_idColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_ID");
			int ctacte_recibo_numeroColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_NUMERO");
			int recibo_emitir_por_documentosColumnIndex = reader.GetOrdinal("RECIBO_EMITIR_POR_DOCUMENTOS");
			int ctacte_recibo_nro_comprobanteColumnIndex = reader.GetOrdinal("CTACTE_RECIBO_NRO_COMPROBANTE");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int persona_rucColumnIndex = reader.GetOrdinal("PERSONA_RUC");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int usuario_carga_idColumnIndex = reader.GetOrdinal("USUARIO_CARGA_ID");
			int usuario_nombre_completoColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE_COMPLETO");
			int funcionario_cobrador_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_ID");
			int funcionario_nombre_completoColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE_COMPLETO");
			int funcionario_cobrador_exter_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBRADOR_EXTER_ID");
			int funcionario_cobr_ext_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_COBR_EXT_NOMBRE");
			int moneda_total_vuelto_idColumnIndex = reader.GetOrdinal("MONEDA_TOTAL_VUELTO_ID");
			int moneda_total_vuelto_nombreColumnIndex = reader.GetOrdinal("MONEDA_TOTAL_VUELTO_NOMBRE");
			int moneda_total_vuelto_simboloColumnIndex = reader.GetOrdinal("MONEDA_TOTAL_VUELTO_SIMBOLO");
			int cotizacion_moneda_total_vueltoColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_TOTAL_VUELTO");
			int monto_total_vueltoColumnIndex = reader.GetOrdinal("MONTO_TOTAL_VUELTO");
			int vuelto_convertido_a_anticipoColumnIndex = reader.GetOrdinal("VUELTO_CONVERTIDO_A_ANTICIPO");
			int caso_anticipo_idColumnIndex = reader.GetOrdinal("CASO_ANTICIPO_ID");
			int caso_anticipo_estado_idColumnIndex = reader.GetOrdinal("CASO_ANTICIPO_ESTADO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int pago_confirmadoColumnIndex = reader.GetOrdinal("PAGO_CONFIRMADO");
			int fc_cliente1_comprobante_idColumnIndex = reader.GetOrdinal("FC_CLIENTE1_COMPROBANTE_ID");
			int factura_cliente_comp1_caso_idColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_COMP1_CASO_ID");
			int fc_cliente1_comp_auton_idColumnIndex = reader.GetOrdinal("FC_CLIENTE1_COMP_AUTON_ID");
			int fc_cliente2_comprobante_idColumnIndex = reader.GetOrdinal("FC_CLIENTE2_COMPROBANTE_ID");
			int factura_cliente_comp2_caso_idColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_COMP2_CASO_ID");
			int fc_cliente2_comp_auton_idColumnIndex = reader.GetOrdinal("FC_CLIENTE2_COMP_AUTON_ID");
			int fecha_confirmacionColumnIndex = reader.GetOrdinal("FECHA_CONFIRMACION");
			int autonumeracion_recibo_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_RECIBO_ID");
			int autonumeracion_anticipo_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ANTICIPO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int nombre_texto_predefinidoColumnIndex = reader.GetOrdinal("NOMBRE_TEXTO_PREDEFINIDO");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PAGOS_PERSONA_INFO_COMPRow record = new CTACTE_PAGOS_PERSONA_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_idColumnIndex))
						record.CTACTE_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recibo_numeroColumnIndex))
						record.CTACTE_RECIBO_NUMERO = Convert.ToString(reader.GetValue(ctacte_recibo_numeroColumnIndex));
					record.RECIBO_EMITIR_POR_DOCUMENTOS = Convert.ToString(reader.GetValue(recibo_emitir_por_documentosColumnIndex));
					if(!reader.IsDBNull(ctacte_recibo_nro_comprobanteColumnIndex))
						record.CTACTE_RECIBO_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(ctacte_recibo_nro_comprobanteColumnIndex));
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					if(!reader.IsDBNull(persona_rucColumnIndex))
						record.PERSONA_RUC = Convert.ToString(reader.GetValue(persona_rucColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.USUARIO_CARGA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_carga_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_nombre_completoColumnIndex))
						record.USUARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(usuario_nombre_completoColumnIndex));
					record.FUNCIONARIO_COBRADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cobrador_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_nombre_completoColumnIndex))
						record.FUNCIONARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(funcionario_nombre_completoColumnIndex));
					if(!reader.IsDBNull(funcionario_cobrador_exter_idColumnIndex))
						record.FUNCIONARIO_COBRADOR_EXTER_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_cobrador_exter_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_cobr_ext_nombreColumnIndex))
						record.FUNCIONARIO_COBR_EXT_NOMBRE = Convert.ToString(reader.GetValue(funcionario_cobr_ext_nombreColumnIndex));
					record.MONEDA_TOTAL_VUELTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_total_vuelto_idColumnIndex)), 9);
					record.MONEDA_TOTAL_VUELTO_NOMBRE = Convert.ToString(reader.GetValue(moneda_total_vuelto_nombreColumnIndex));
					record.MONEDA_TOTAL_VUELTO_SIMBOLO = Convert.ToString(reader.GetValue(moneda_total_vuelto_simboloColumnIndex));
					record.COTIZACION_MONEDA_TOTAL_VUELTO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_total_vueltoColumnIndex)), 9);
					record.MONTO_TOTAL_VUELTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_total_vueltoColumnIndex)), 9);
					record.VUELTO_CONVERTIDO_A_ANTICIPO = Convert.ToString(reader.GetValue(vuelto_convertido_a_anticipoColumnIndex));
					if(!reader.IsDBNull(caso_anticipo_idColumnIndex))
						record.CASO_ANTICIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_anticipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_anticipo_estado_idColumnIndex))
						record.CASO_ANTICIPO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_anticipo_estado_idColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.PAGO_CONFIRMADO = Convert.ToString(reader.GetValue(pago_confirmadoColumnIndex));
					if(!reader.IsDBNull(fc_cliente1_comprobante_idColumnIndex))
						record.FC_CLIENTE1_COMPROBANTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente1_comprobante_idColumnIndex)), 9);
					if(!reader.IsDBNull(factura_cliente_comp1_caso_idColumnIndex))
						record.FACTURA_CLIENTE_COMP1_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_cliente_comp1_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_cliente1_comp_auton_idColumnIndex))
						record.FC_CLIENTE1_COMP_AUTON_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente1_comp_auton_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_cliente2_comprobante_idColumnIndex))
						record.FC_CLIENTE2_COMPROBANTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente2_comprobante_idColumnIndex)), 9);
					if(!reader.IsDBNull(factura_cliente_comp2_caso_idColumnIndex))
						record.FACTURA_CLIENTE_COMP2_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_cliente_comp2_caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(fc_cliente2_comp_auton_idColumnIndex))
						record.FC_CLIENTE2_COMP_AUTON_ID = Math.Round(Convert.ToDecimal(reader.GetValue(fc_cliente2_comp_auton_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_confirmacionColumnIndex))
						record.FECHA_CONFIRMACION = Convert.ToDateTime(reader.GetValue(fecha_confirmacionColumnIndex));
					if(!reader.IsDBNull(autonumeracion_recibo_idColumnIndex))
						record.AUTONUMERACION_RECIBO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_recibo_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_anticipo_idColumnIndex))
						record.AUTONUMERACION_ANTICIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_anticipo_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_texto_predefinidoColumnIndex))
						record.NOMBRE_TEXTO_PREDEFINIDO = Convert.ToString(reader.GetValue(nombre_texto_predefinidoColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PAGOS_PERSONA_INFO_COMPRow[])(recordList.ToArray(typeof(CTACTE_PAGOS_PERSONA_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PAGOS_PERSONA_INFO_COMPRow"/> object.</returns>
		protected virtual CTACTE_PAGOS_PERSONA_INFO_COMPRow MapRow(DataRow row)
		{
			CTACTE_PAGOS_PERSONA_INFO_COMPRow mappedObject = new CTACTE_PAGOS_PERSONA_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RECIBO_NUMERO"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_NUMERO = (string)row[dataColumn];
			// Column "RECIBO_EMITIR_POR_DOCUMENTOS"
			dataColumn = dataTable.Columns["RECIBO_EMITIR_POR_DOCUMENTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBO_EMITIR_POR_DOCUMENTOS = (string)row[dataColumn];
			// Column "CTACTE_RECIBO_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["CTACTE_RECIBO_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECIBO_NRO_COMPROBANTE = (string)row[dataColumn];
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
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "PERSONA_RUC"
			dataColumn = dataTable.Columns["PERSONA_RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_RUC = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CARGA_ID"
			dataColumn = dataTable.Columns["USUARIO_CARGA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CARGA_ID = (decimal)row[dataColumn];
			// Column "USUARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "FUNCIONARIO_COBRADOR_EXTER_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBRADOR_EXTER_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBRADOR_EXTER_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_COBR_EXT_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_COBR_EXT_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_COBR_EXT_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_TOTAL_VUELTO_ID"
			dataColumn = dataTable.Columns["MONEDA_TOTAL_VUELTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_TOTAL_VUELTO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_TOTAL_VUELTO_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_TOTAL_VUELTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_TOTAL_VUELTO_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_TOTAL_VUELTO_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_TOTAL_VUELTO_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_TOTAL_VUELTO_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA_TOTAL_VUELTO"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_TOTAL_VUELTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_TOTAL_VUELTO = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL_VUELTO"
			dataColumn = dataTable.Columns["MONTO_TOTAL_VUELTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL_VUELTO = (decimal)row[dataColumn];
			// Column "VUELTO_CONVERTIDO_A_ANTICIPO"
			dataColumn = dataTable.Columns["VUELTO_CONVERTIDO_A_ANTICIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VUELTO_CONVERTIDO_A_ANTICIPO = (string)row[dataColumn];
			// Column "CASO_ANTICIPO_ID"
			dataColumn = dataTable.Columns["CASO_ANTICIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ANTICIPO_ID = (decimal)row[dataColumn];
			// Column "CASO_ANTICIPO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ANTICIPO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ANTICIPO_ESTADO_ID = (string)row[dataColumn];
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
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO_ID"
			dataColumn = dataTable.Columns["CASO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO_ID = (string)row[dataColumn];
			// Column "PAGO_CONFIRMADO"
			dataColumn = dataTable.Columns["PAGO_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGO_CONFIRMADO = (string)row[dataColumn];
			// Column "FC_CLIENTE1_COMPROBANTE_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE1_COMPROBANTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE1_COMPROBANTE_ID = (decimal)row[dataColumn];
			// Column "FACTURA_CLIENTE_COMP1_CASO_ID"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_COMP1_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_COMP1_CASO_ID = (decimal)row[dataColumn];
			// Column "FC_CLIENTE1_COMP_AUTON_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE1_COMP_AUTON_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE1_COMP_AUTON_ID = (decimal)row[dataColumn];
			// Column "FC_CLIENTE2_COMPROBANTE_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE2_COMPROBANTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE2_COMPROBANTE_ID = (decimal)row[dataColumn];
			// Column "FACTURA_CLIENTE_COMP2_CASO_ID"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_COMP2_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_COMP2_CASO_ID = (decimal)row[dataColumn];
			// Column "FC_CLIENTE2_COMP_AUTON_ID"
			dataColumn = dataTable.Columns["FC_CLIENTE2_COMP_AUTON_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_CLIENTE2_COMP_AUTON_ID = (decimal)row[dataColumn];
			// Column "FECHA_CONFIRMACION"
			dataColumn = dataTable.Columns["FECHA_CONFIRMACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONFIRMACION = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_RECIBO_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_RECIBO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_RECIBO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ANTICIPO_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ANTICIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ANTICIPO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_TEXTO_PREDEFINIDO"
			dataColumn = dataTable.Columns["NOMBRE_TEXTO_PREDEFINIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_TEXTO_PREDEFINIDO = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PAGOS_PERSONA_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PAGOS_PERSONA_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECIBO_EMITIR_POR_DOCUMENTOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RECIBO_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 100;
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
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_RUC", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CARGA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 154;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBRADOR_EXTER_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_COBR_EXT_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_TOTAL_VUELTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_TOTAL_VUELTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_TOTAL_VUELTO_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_TOTAL_VUELTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL_VUELTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VUELTO_CONVERTIDO_A_ANTICIPO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ANTICIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ANTICIPO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
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
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAGO_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_CLIENTE1_COMPROBANTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_COMP1_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_CLIENTE1_COMP_AUTON_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_CLIENTE2_COMPROBANTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_COMP2_CASO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_CLIENTE2_COMP_AUTON_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CONFIRMACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_RECIBO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ANTICIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_TEXTO_PREDEFINIDO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
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

				case "CTACTE_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECIBO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RECIBO_EMITIR_POR_DOCUMENTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_RECIBO_NRO_COMPROBANTE":
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CARGA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_COBRADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_COBRADOR_EXTER_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_COBR_EXT_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_TOTAL_VUELTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_TOTAL_VUELTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_TOTAL_VUELTO_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA_TOTAL_VUELTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL_VUELTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VUELTO_CONVERTIDO_A_ANTICIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ANTICIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ANTICIPO_ESTADO_ID":
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAGO_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FC_CLIENTE1_COMPROBANTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_CLIENTE_COMP1_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CLIENTE1_COMP_AUTON_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CLIENTE2_COMPROBANTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_CLIENTE_COMP2_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_CLIENTE2_COMP_AUTON_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CONFIRMACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_RECIBO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ANTICIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_TEXTO_PREDEFINIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PAGOS_PERSONA_INFO_COMPCollection_Base class
}  // End of namespace
