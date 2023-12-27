// <fileinfo name="FACTURAS_CLIENTECollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_CLIENTECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ORIGEN_IDColumnName = "CASO_ORIGEN_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string VENDEDOR_IDColumnName = "VENDEDOR_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string TIPO_FACTURA_IDColumnName = "TIPO_FACTURA_ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string PORCENTAJE_DESC_SOBRE_TOTALColumnName = "PORCENTAJE_DESC_SOBRE_TOTAL";
		public const string MONEDA_DESTINO_IDColumnName = "MONEDA_DESTINO_ID";
		public const string COTIZACION_DESTINOColumnName = "COTIZACION_DESTINO";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_MONTO_BRUTOColumnName = "TOTAL_MONTO_BRUTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string TOTAL_COSTO_BRUTOColumnName = "TOTAL_COSTO_BRUTO";
		public const string TOTAL_COSTO_NETOColumnName = "TOTAL_COSTO_NETO";
		public const string TOTAL_COMISION_VENDEDORColumnName = "TOTAL_COMISION_VENDEDOR";
		public const string USUARIO_ID_AUTORIZA_DESCUENTOColumnName = "USUARIO_ID_AUTORIZA_DESCUENTO";
		public const string FECHA_AUTORIZACION_DESCUENTOColumnName = "FECHA_AUTORIZACION_DESCUENTO";
		public const string DESCUENTO_MAX_AUTORIZADOColumnName = "DESCUENTO_MAX_AUTORIZADO";
		public const string AFECTA_LINEA_CREDITOColumnName = "AFECTA_LINEA_CREDITO";
		public const string AFECTA_CTACTEColumnName = "AFECTA_CTACTE";
		public const string MONTO_AFECTA_LINEA_CREDITOColumnName = "MONTO_AFECTA_LINEA_CREDITO";
		public const string COMISION_POR_VENTAColumnName = "COMISION_POR_VENTA";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string A_CONSIGNACIONColumnName = "A_CONSIGNACION";
		public const string DIRECCIONColumnName = "DIRECCION";
		public const string LATITUDColumnName = "LATITUD";
		public const string LONGITUDColumnName = "LONGITUD";
		public const string OBSERVACION_ENTREGAColumnName = "OBSERVACION_ENTREGA";
		public const string CONDICION_DESCRIPCIONColumnName = "CONDICION_DESCRIPCION";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string MORA_PORCENTAJEColumnName = "MORA_PORCENTAJE";
		public const string MORA_DIAS_GRACIAColumnName = "MORA_DIAS_GRACIA";
		public const string AFECTA_STOCKColumnName = "AFECTA_STOCK";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string TOTAL_ENTREGA_INICIALColumnName = "TOTAL_ENTREGA_INICIAL";
		public const string NRO_COMPROBANTE_SECUENCIAColumnName = "NRO_COMPROBANTE_SECUENCIA";
		public const string PERSONA_GARANTE_1_IDColumnName = "PERSONA_GARANTE_1_ID";
		public const string PERSONA_GARANTE_2_IDColumnName = "PERSONA_GARANTE_2_ID";
		public const string PERSONA_GARANTE_3_IDColumnName = "PERSONA_GARANTE_3_ID";
		public const string NRO_DOCUMENTO_EXTERNOColumnName = "NRO_DOCUMENTO_EXTERNO";
		public const string SUCURSAL_VENTA_IDColumnName = "SUCURSAL_VENTA_ID";
		public const string CONTROLAR_CANT_MIN_DESC_MAXColumnName = "CONTROLAR_CANT_MIN_DESC_MAX";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string GENERAR_TRANSFERENCIAColumnName = "GENERAR_TRANSFERENCIA";
		public const string DEPOSITO_DESTINO_IDColumnName = "DEPOSITO_DESTINO_ID";
		public const string AUTONUMERACION_TRANSF_IDColumnName = "AUTONUMERACION_TRANSF_ID";
		public const string NRO_TIMBRADO_FACT_PROColumnName = "NRO_TIMBRADO_FACT_PRO";
		public const string FECHA_VENC_TIMBRADO_FACT_PROColumnName = "FECHA_VENC_TIMBRADO_FACT_PRO";
		public const string NRO_COMPROBANTE_FACT_PROColumnName = "NRO_COMPROBANTE_FACT_PRO";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string ES_RAPIDAColumnName = "ES_RAPIDA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_CLIENTECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURAS_CLIENTE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_CLIENTERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_CLIENTERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_CLIENTERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FACTURAS_CLIENTERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FACTURAS_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FACTURAS_CLIENTERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FACTURAS_CLIENTERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByMONEDA_DESTINO_ID(decimal moneda_destino_id)
		{
			return GetByMONEDA_DESTINO_ID(moneda_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <param name="moneda_destino_idNull">true if the method ignores the moneda_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByMONEDA_DESTINO_ID(decimal moneda_destino_id, bool moneda_destino_idNull)
		{
			return MapRecords(CreateGetByMONEDA_DESTINO_IDCommand(moneda_destino_id, moneda_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_DESTINO_IDAsDataTable(decimal moneda_destino_id)
		{
			return GetByMONEDA_DESTINO_IDAsDataTable(moneda_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <param name="moneda_destino_idNull">true if the method ignores the moneda_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_DESTINO_IDAsDataTable(decimal moneda_destino_id, bool moneda_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_DESTINO_IDCommand(moneda_destino_id, moneda_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <param name="moneda_destino_idNull">true if the method ignores the moneda_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_DESTINO_IDCommand(decimal moneda_destino_id, bool moneda_destino_idNull)
		{
			string whereSql = "";
			if(moneda_destino_idNull)
				whereSql += "MONEDA_DESTINO_ID IS NULL";
			else
				whereSql += "MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_destino_idNull)
				AddParameter(cmd, "MONEDA_DESTINO_ID", moneda_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
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
		/// return records by the <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecords(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_IDAsDataTable(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByAUTONUMERACION_TRANSF_ID(decimal autonumeracion_transf_id)
		{
			return GetByAUTONUMERACION_TRANSF_ID(autonumeracion_transf_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <param name="autonumeracion_transf_idNull">true if the method ignores the autonumeracion_transf_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByAUTONUMERACION_TRANSF_ID(decimal autonumeracion_transf_id, bool autonumeracion_transf_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_TRANSF_IDCommand(autonumeracion_transf_id, autonumeracion_transf_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_TRANSF_IDAsDataTable(decimal autonumeracion_transf_id)
		{
			return GetByAUTONUMERACION_TRANSF_IDAsDataTable(autonumeracion_transf_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <param name="autonumeracion_transf_idNull">true if the method ignores the autonumeracion_transf_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_TRANSF_IDAsDataTable(decimal autonumeracion_transf_id, bool autonumeracion_transf_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_TRANSF_IDCommand(autonumeracion_transf_id, autonumeracion_transf_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <param name="autonumeracion_transf_idNull">true if the method ignores the autonumeracion_transf_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_TRANSF_IDCommand(decimal autonumeracion_transf_id, bool autonumeracion_transf_idNull)
		{
			string whereSql = "";
			if(autonumeracion_transf_idNull)
				whereSql += "AUTONUMERACION_TRANSF_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_TRANSF_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_TRANSF_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_transf_idNull)
				AddParameter(cmd, "AUTONUMERACION_TRANSF_ID", autonumeracion_transf_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecords(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_IDAsDataTable(canal_venta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return GetByCASO_ORIGEN_ID(caso_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByCASO_ORIGEN_ID(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return MapRecords(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ORIGEN_IDAsDataTable(decimal caso_origen_id)
		{
			return GetByCASO_ORIGEN_IDAsDataTable(caso_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ORIGEN_IDAsDataTable(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ORIGEN_IDCommand(decimal caso_origen_id, bool caso_origen_idNull)
		{
			string whereSql = "";
			if(caso_origen_idNull)
				whereSql += "CASO_ORIGEN_ID IS NULL";
			else
				whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_origen_idNull)
				AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByDEPOSITO_DESTINO_ID(decimal deposito_destino_id)
		{
			return GetByDEPOSITO_DESTINO_ID(deposito_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByDEPOSITO_DESTINO_ID(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_DESTINO_IDCommand(deposito_destino_id, deposito_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_DESTINO_IDAsDataTable(decimal deposito_destino_id)
		{
			return GetByDEPOSITO_DESTINO_IDAsDataTable(deposito_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_DESTINO_IDAsDataTable(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_DESTINO_IDCommand(deposito_destino_id, deposito_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_DESTINO_IDCommand(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			string whereSql = "";
			if(deposito_destino_idNull)
				whereSql += "DEPOSITO_DESTINO_ID IS NULL";
			else
				whereSql += "DEPOSITO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPOSITO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_destino_idNull)
				AddParameter(cmd, "DEPOSITO_DESTINO_ID", deposito_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return GetByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return GetByDEPOSITO_IDAsDataTable(deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_IDAsDataTable(lista_precio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id)
		{
			return GetByPERSONA_GARANTE_1_ID(persona_garante_1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE_1_IDCommand(persona_garante_1_id, persona_garante_1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE_1_IDAsDataTable(decimal persona_garante_1_id)
		{
			return GetByPERSONA_GARANTE_1_IDAsDataTable(persona_garante_1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE_1_IDAsDataTable(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE_1_IDCommand(persona_garante_1_id, persona_garante_1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE_1_IDCommand(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			string whereSql = "";
			if(persona_garante_1_idNull)
				whereSql += "PERSONA_GARANTE_1_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante_1_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_1_ID", persona_garante_1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id)
		{
			return GetByPERSONA_GARANTE_2_ID(persona_garante_2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE_2_IDCommand(persona_garante_2_id, persona_garante_2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE_2_IDAsDataTable(decimal persona_garante_2_id)
		{
			return GetByPERSONA_GARANTE_2_IDAsDataTable(persona_garante_2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE_2_IDAsDataTable(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE_2_IDCommand(persona_garante_2_id, persona_garante_2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE_2_IDCommand(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			string whereSql = "";
			if(persona_garante_2_idNull)
				whereSql += "PERSONA_GARANTE_2_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante_2_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_2_ID", persona_garante_2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id)
		{
			return GetByPERSONA_GARANTE_3_ID(persona_garante_3_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE_3_IDCommand(persona_garante_3_id, persona_garante_3_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE_3_IDAsDataTable(decimal persona_garante_3_id)
		{
			return GetByPERSONA_GARANTE_3_IDAsDataTable(persona_garante_3_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE_3_IDAsDataTable(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE_3_IDCommand(persona_garante_3_id, persona_garante_3_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE_3_IDCommand(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			string whereSql = "";
			if(persona_garante_3_idNull)
				whereSql += "PERSONA_GARANTE_3_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_3_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_3_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante_3_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_3_ID", persona_garante_3_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetBySUCURSAL_VENTA_ID(decimal sucursal_venta_id)
		{
			return GetBySUCURSAL_VENTA_ID(sucursal_venta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <param name="sucursal_venta_idNull">true if the method ignores the sucursal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetBySUCURSAL_VENTA_ID(decimal sucursal_venta_id, bool sucursal_venta_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_VENTA_IDCommand(sucursal_venta_id, sucursal_venta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_VENTA_IDAsDataTable(decimal sucursal_venta_id)
		{
			return GetBySUCURSAL_VENTA_IDAsDataTable(sucursal_venta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <param name="sucursal_venta_idNull">true if the method ignores the sucursal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_VENTA_IDAsDataTable(decimal sucursal_venta_id, bool sucursal_venta_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_VENTA_IDCommand(sucursal_venta_id, sucursal_venta_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <param name="sucursal_venta_idNull">true if the method ignores the sucursal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_VENTA_IDCommand(decimal sucursal_venta_id, bool sucursal_venta_idNull)
		{
			string whereSql = "";
			if(sucursal_venta_idNull)
				whereSql += "SUCURSAL_VENTA_ID IS NULL";
			else
				whereSql += "SUCURSAL_VENTA_ID=" + _db.CreateSqlParameterName("SUCURSAL_VENTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_venta_idNull)
				AddParameter(cmd, "SUCURSAL_VENTA_ID", sucursal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByUSUARIO_ID_AUTORIZA_DESCUENTO(decimal usuario_id_autoriza_descuento)
		{
			return GetByUSUARIO_ID_AUTORIZA_DESCUENTO(usuario_id_autoriza_descuento, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <param name="usuario_id_autoriza_descuentoNull">true if the method ignores the usuario_id_autoriza_descuento
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByUSUARIO_ID_AUTORIZA_DESCUENTO(decimal usuario_id_autoriza_descuento, bool usuario_id_autoriza_descuentoNull)
		{
			return MapRecords(CreateGetByUSUARIO_ID_AUTORIZA_DESCUENTOCommand(usuario_id_autoriza_descuento, usuario_id_autoriza_descuentoNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_ID_AUTORIZA_DESCUENTOAsDataTable(decimal usuario_id_autoriza_descuento)
		{
			return GetByUSUARIO_ID_AUTORIZA_DESCUENTOAsDataTable(usuario_id_autoriza_descuento, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <param name="usuario_id_autoriza_descuentoNull">true if the method ignores the usuario_id_autoriza_descuento
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_ID_AUTORIZA_DESCUENTOAsDataTable(decimal usuario_id_autoriza_descuento, bool usuario_id_autoriza_descuentoNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_ID_AUTORIZA_DESCUENTOCommand(usuario_id_autoriza_descuento, usuario_id_autoriza_descuentoNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <param name="usuario_id_autoriza_descuentoNull">true if the method ignores the usuario_id_autoriza_descuento
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_ID_AUTORIZA_DESCUENTOCommand(decimal usuario_id_autoriza_descuento, bool usuario_id_autoriza_descuentoNull)
		{
			string whereSql = "";
			if(usuario_id_autoriza_descuentoNull)
				whereSql += "USUARIO_ID_AUTORIZA_DESCUENTO IS NULL";
			else
				whereSql += "USUARIO_ID_AUTORIZA_DESCUENTO=" + _db.CreateSqlParameterName("USUARIO_ID_AUTORIZA_DESCUENTO");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_id_autoriza_descuentoNull)
				AddParameter(cmd, "USUARIO_ID_AUTORIZA_DESCUENTO", usuario_id_autoriza_descuento);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public FACTURAS_CLIENTERow[] GetByVENDEDOR_ID(decimal vendedor_id)
		{
			return GetByVENDEDOR_ID(vendedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTERow[] GetByVENDEDOR_ID(decimal vendedor_id, bool vendedor_idNull)
		{
			return MapRecords(CreateGetByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVENDEDOR_IDAsDataTable(decimal vendedor_id)
		{
			return GetByVENDEDOR_IDAsDataTable(vendedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVENDEDOR_IDAsDataTable(decimal vendedor_id, bool vendedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVENDEDOR_IDCommand(decimal vendedor_id, bool vendedor_idNull)
		{
			string whereSql = "";
			if(vendedor_idNull)
				whereSql += "VENDEDOR_ID IS NULL";
			else
				whereSql += "VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vendedor_idNull)
				AddParameter(cmd, "VENDEDOR_ID", vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FACTURAS_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_CLIENTERow"/> object to be inserted.</param>
		public virtual void Insert(FACTURAS_CLIENTERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FACTURAS_CLIENTE (" +
				"ID, " +
				"CASO_ID, " +
				"CASO_ORIGEN_ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"FECHA, " +
				"VENDEDOR_ID, " +
				"PERSONA_ID, " +
				"TIPO_FACTURA_ID, " +
				"LISTA_PRECIO_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA_VENCIMIENTO, " +
				"CONDICION_PAGO_ID, " +
				"PORCENTAJE_DESC_SOBRE_TOTAL, " +
				"MONEDA_DESTINO_ID, " +
				"COTIZACION_DESTINO, " +
				"TOTAL_MONTO_IMPUESTO, " +
				"TOTAL_MONTO_DTO, " +
				"TOTAL_MONTO_BRUTO, " +
				"TOTAL_NETO, " +
				"TOTAL_COSTO_BRUTO, " +
				"TOTAL_COSTO_NETO, " +
				"TOTAL_COMISION_VENDEDOR, " +
				"USUARIO_ID_AUTORIZA_DESCUENTO, " +
				"FECHA_AUTORIZACION_DESCUENTO, " +
				"DESCUENTO_MAX_AUTORIZADO, " +
				"AFECTA_LINEA_CREDITO, " +
				"AFECTA_CTACTE, " +
				"MONTO_AFECTA_LINEA_CREDITO, " +
				"COMISION_POR_VENTA, " +
				"OBSERVACION, " +
				"A_CONSIGNACION, " +
				"DIRECCION, " +
				"LATITUD, " +
				"LONGITUD, " +
				"OBSERVACION_ENTREGA, " +
				"CONDICION_DESCRIPCION, " +
				"IMPRESO, " +
				"MORA_PORCENTAJE, " +
				"MORA_DIAS_GRACIA, " +
				"AFECTA_STOCK, " +
				"TOTAL_RECARGO_FINANCIERO, " +
				"TOTAL_ENTREGA_INICIAL, " +
				"NRO_COMPROBANTE_SECUENCIA, " +
				"PERSONA_GARANTE_1_ID, " +
				"PERSONA_GARANTE_2_ID, " +
				"PERSONA_GARANTE_3_ID, " +
				"NRO_DOCUMENTO_EXTERNO, " +
				"SUCURSAL_VENTA_ID, " +
				"CONTROLAR_CANT_MIN_DESC_MAX, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"ESTADO, " +
				"GENERAR_TRANSFERENCIA, " +
				"DEPOSITO_DESTINO_ID, " +
				"AUTONUMERACION_TRANSF_ID, " +
				"NRO_TIMBRADO_FACT_PRO, " +
				"FECHA_VENC_TIMBRADO_FACT_PRO, " +
				"NRO_COMPROBANTE_FACT_PRO, " +
				"CANAL_VENTA_ID, " +
				"ES_RAPIDA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("VENDEDOR_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_FACTURA_ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DESC_SOBRE_TOTAL") + ", " +
				_db.CreateSqlParameterName("MONEDA_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_DESTINO") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_DTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_BRUTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_NETO") + ", " +
				_db.CreateSqlParameterName("TOTAL_COSTO_BRUTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_COSTO_NETO") + ", " +
				_db.CreateSqlParameterName("TOTAL_COMISION_VENDEDOR") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID_AUTORIZA_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_AUTORIZACION_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_MAX_AUTORIZADO") + ", " +
				_db.CreateSqlParameterName("AFECTA_LINEA_CREDITO") + ", " +
				_db.CreateSqlParameterName("AFECTA_CTACTE") + ", " +
				_db.CreateSqlParameterName("MONTO_AFECTA_LINEA_CREDITO") + ", " +
				_db.CreateSqlParameterName("COMISION_POR_VENTA") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("A_CONSIGNACION") + ", " +
				_db.CreateSqlParameterName("DIRECCION") + ", " +
				_db.CreateSqlParameterName("LATITUD") + ", " +
				_db.CreateSqlParameterName("LONGITUD") + ", " +
				_db.CreateSqlParameterName("OBSERVACION_ENTREGA") + ", " +
				_db.CreateSqlParameterName("CONDICION_DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("IMPRESO") + ", " +
				_db.CreateSqlParameterName("MORA_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("MORA_DIAS_GRACIA") + ", " +
				_db.CreateSqlParameterName("AFECTA_STOCK") + ", " +
				_db.CreateSqlParameterName("TOTAL_RECARGO_FINANCIERO") + ", " +
				_db.CreateSqlParameterName("TOTAL_ENTREGA_INICIAL") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE_SECUENCIA") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE_1_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE_2_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE_3_ID") + ", " +
				_db.CreateSqlParameterName("NRO_DOCUMENTO_EXTERNO") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_VENTA_ID") + ", " +
				_db.CreateSqlParameterName("CONTROLAR_CANT_MIN_DESC_MAX") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("GENERAR_TRANSFERENCIA") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_TRANSF_ID") + ", " +
				_db.CreateSqlParameterName("NRO_TIMBRADO_FACT_PRO") + ", " +
				_db.CreateSqlParameterName("FECHA_VENC_TIMBRADO_FACT_PRO") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE_FACT_PRO") + ", " +
				_db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				_db.CreateSqlParameterName("ES_RAPIDA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CASO_ORIGEN_ID",
				value.IsCASO_ORIGEN_IDNull ? DBNull.Value : (object)value.CASO_ORIGEN_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "VENDEDOR_ID",
				value.IsVENDEDOR_IDNull ? DBNull.Value : (object)value.VENDEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "TIPO_FACTURA_ID", value.TIPO_FACTURA_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "PORCENTAJE_DESC_SOBRE_TOTAL",
				value.IsPORCENTAJE_DESC_SOBRE_TOTALNull ? DBNull.Value : (object)value.PORCENTAJE_DESC_SOBRE_TOTAL);
			AddParameter(cmd, "MONEDA_DESTINO_ID",
				value.IsMONEDA_DESTINO_IDNull ? DBNull.Value : (object)value.MONEDA_DESTINO_ID);
			AddParameter(cmd, "COTIZACION_DESTINO",
				value.IsCOTIZACION_DESTINONull ? DBNull.Value : (object)value.COTIZACION_DESTINO);
			AddParameter(cmd, "TOTAL_MONTO_IMPUESTO",
				value.IsTOTAL_MONTO_IMPUESTONull ? DBNull.Value : (object)value.TOTAL_MONTO_IMPUESTO);
			AddParameter(cmd, "TOTAL_MONTO_DTO",
				value.IsTOTAL_MONTO_DTONull ? DBNull.Value : (object)value.TOTAL_MONTO_DTO);
			AddParameter(cmd, "TOTAL_MONTO_BRUTO",
				value.IsTOTAL_MONTO_BRUTONull ? DBNull.Value : (object)value.TOTAL_MONTO_BRUTO);
			AddParameter(cmd, "TOTAL_NETO",
				value.IsTOTAL_NETONull ? DBNull.Value : (object)value.TOTAL_NETO);
			AddParameter(cmd, "TOTAL_COSTO_BRUTO",
				value.IsTOTAL_COSTO_BRUTONull ? DBNull.Value : (object)value.TOTAL_COSTO_BRUTO);
			AddParameter(cmd, "TOTAL_COSTO_NETO",
				value.IsTOTAL_COSTO_NETONull ? DBNull.Value : (object)value.TOTAL_COSTO_NETO);
			AddParameter(cmd, "TOTAL_COMISION_VENDEDOR",
				value.IsTOTAL_COMISION_VENDEDORNull ? DBNull.Value : (object)value.TOTAL_COMISION_VENDEDOR);
			AddParameter(cmd, "USUARIO_ID_AUTORIZA_DESCUENTO",
				value.IsUSUARIO_ID_AUTORIZA_DESCUENTONull ? DBNull.Value : (object)value.USUARIO_ID_AUTORIZA_DESCUENTO);
			AddParameter(cmd, "FECHA_AUTORIZACION_DESCUENTO",
				value.IsFECHA_AUTORIZACION_DESCUENTONull ? DBNull.Value : (object)value.FECHA_AUTORIZACION_DESCUENTO);
			AddParameter(cmd, "DESCUENTO_MAX_AUTORIZADO",
				value.IsDESCUENTO_MAX_AUTORIZADONull ? DBNull.Value : (object)value.DESCUENTO_MAX_AUTORIZADO);
			AddParameter(cmd, "AFECTA_LINEA_CREDITO", value.AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "AFECTA_CTACTE", value.AFECTA_CTACTE);
			AddParameter(cmd, "MONTO_AFECTA_LINEA_CREDITO",
				value.IsMONTO_AFECTA_LINEA_CREDITONull ? DBNull.Value : (object)value.MONTO_AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "COMISION_POR_VENTA", value.COMISION_POR_VENTA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "A_CONSIGNACION", value.A_CONSIGNACION);
			AddParameter(cmd, "DIRECCION", value.DIRECCION);
			AddParameter(cmd, "LATITUD",
				value.IsLATITUDNull ? DBNull.Value : (object)value.LATITUD);
			AddParameter(cmd, "LONGITUD",
				value.IsLONGITUDNull ? DBNull.Value : (object)value.LONGITUD);
			AddParameter(cmd, "OBSERVACION_ENTREGA", value.OBSERVACION_ENTREGA);
			AddParameter(cmd, "CONDICION_DESCRIPCION", value.CONDICION_DESCRIPCION);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "MORA_PORCENTAJE", value.MORA_PORCENTAJE);
			AddParameter(cmd, "MORA_DIAS_GRACIA", value.MORA_DIAS_GRACIA);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			AddParameter(cmd, "TOTAL_RECARGO_FINANCIERO", value.TOTAL_RECARGO_FINANCIERO);
			AddParameter(cmd, "TOTAL_ENTREGA_INICIAL", value.TOTAL_ENTREGA_INICIAL);
			AddParameter(cmd, "NRO_COMPROBANTE_SECUENCIA",
				value.IsNRO_COMPROBANTE_SECUENCIANull ? DBNull.Value : (object)value.NRO_COMPROBANTE_SECUENCIA);
			AddParameter(cmd, "PERSONA_GARANTE_1_ID",
				value.IsPERSONA_GARANTE_1_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_1_ID);
			AddParameter(cmd, "PERSONA_GARANTE_2_ID",
				value.IsPERSONA_GARANTE_2_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_2_ID);
			AddParameter(cmd, "PERSONA_GARANTE_3_ID",
				value.IsPERSONA_GARANTE_3_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_3_ID);
			AddParameter(cmd, "NRO_DOCUMENTO_EXTERNO", value.NRO_DOCUMENTO_EXTERNO);
			AddParameter(cmd, "SUCURSAL_VENTA_ID",
				value.IsSUCURSAL_VENTA_IDNull ? DBNull.Value : (object)value.SUCURSAL_VENTA_ID);
			AddParameter(cmd, "CONTROLAR_CANT_MIN_DESC_MAX", value.CONTROLAR_CANT_MIN_DESC_MAX);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "GENERAR_TRANSFERENCIA", value.GENERAR_TRANSFERENCIA);
			AddParameter(cmd, "DEPOSITO_DESTINO_ID",
				value.IsDEPOSITO_DESTINO_IDNull ? DBNull.Value : (object)value.DEPOSITO_DESTINO_ID);
			AddParameter(cmd, "AUTONUMERACION_TRANSF_ID",
				value.IsAUTONUMERACION_TRANSF_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_TRANSF_ID);
			AddParameter(cmd, "NRO_TIMBRADO_FACT_PRO", value.NRO_TIMBRADO_FACT_PRO);
			AddParameter(cmd, "FECHA_VENC_TIMBRADO_FACT_PRO",
				value.IsFECHA_VENC_TIMBRADO_FACT_PRONull ? DBNull.Value : (object)value.FECHA_VENC_TIMBRADO_FACT_PRO);
			AddParameter(cmd, "NRO_COMPROBANTE_FACT_PRO", value.NRO_COMPROBANTE_FACT_PRO);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "ES_RAPIDA", value.ES_RAPIDA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FACTURAS_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_CLIENTERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FACTURAS_CLIENTERow value)
		{
			
			string sqlStr = "UPDATE TRC.FACTURAS_CLIENTE SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"TIPO_FACTURA_ID=" + _db.CreateSqlParameterName("TIPO_FACTURA_ID") + ", " +
				"LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				"PORCENTAJE_DESC_SOBRE_TOTAL=" + _db.CreateSqlParameterName("PORCENTAJE_DESC_SOBRE_TOTAL") + ", " +
				"MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID") + ", " +
				"COTIZACION_DESTINO=" + _db.CreateSqlParameterName("COTIZACION_DESTINO") + ", " +
				"TOTAL_MONTO_IMPUESTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_IMPUESTO") + ", " +
				"TOTAL_MONTO_DTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_DTO") + ", " +
				"TOTAL_MONTO_BRUTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_BRUTO") + ", " +
				"TOTAL_NETO=" + _db.CreateSqlParameterName("TOTAL_NETO") + ", " +
				"TOTAL_COSTO_BRUTO=" + _db.CreateSqlParameterName("TOTAL_COSTO_BRUTO") + ", " +
				"TOTAL_COSTO_NETO=" + _db.CreateSqlParameterName("TOTAL_COSTO_NETO") + ", " +
				"TOTAL_COMISION_VENDEDOR=" + _db.CreateSqlParameterName("TOTAL_COMISION_VENDEDOR") + ", " +
				"USUARIO_ID_AUTORIZA_DESCUENTO=" + _db.CreateSqlParameterName("USUARIO_ID_AUTORIZA_DESCUENTO") + ", " +
				"FECHA_AUTORIZACION_DESCUENTO=" + _db.CreateSqlParameterName("FECHA_AUTORIZACION_DESCUENTO") + ", " +
				"DESCUENTO_MAX_AUTORIZADO=" + _db.CreateSqlParameterName("DESCUENTO_MAX_AUTORIZADO") + ", " +
				"AFECTA_LINEA_CREDITO=" + _db.CreateSqlParameterName("AFECTA_LINEA_CREDITO") + ", " +
				"AFECTA_CTACTE=" + _db.CreateSqlParameterName("AFECTA_CTACTE") + ", " +
				"MONTO_AFECTA_LINEA_CREDITO=" + _db.CreateSqlParameterName("MONTO_AFECTA_LINEA_CREDITO") + ", " +
				"COMISION_POR_VENTA=" + _db.CreateSqlParameterName("COMISION_POR_VENTA") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"A_CONSIGNACION=" + _db.CreateSqlParameterName("A_CONSIGNACION") + ", " +
				"DIRECCION=" + _db.CreateSqlParameterName("DIRECCION") + ", " +
				"LATITUD=" + _db.CreateSqlParameterName("LATITUD") + ", " +
				"LONGITUD=" + _db.CreateSqlParameterName("LONGITUD") + ", " +
				"OBSERVACION_ENTREGA=" + _db.CreateSqlParameterName("OBSERVACION_ENTREGA") + ", " +
				"CONDICION_DESCRIPCION=" + _db.CreateSqlParameterName("CONDICION_DESCRIPCION") + ", " +
				"IMPRESO=" + _db.CreateSqlParameterName("IMPRESO") + ", " +
				"MORA_PORCENTAJE=" + _db.CreateSqlParameterName("MORA_PORCENTAJE") + ", " +
				"MORA_DIAS_GRACIA=" + _db.CreateSqlParameterName("MORA_DIAS_GRACIA") + ", " +
				"AFECTA_STOCK=" + _db.CreateSqlParameterName("AFECTA_STOCK") + ", " +
				"TOTAL_RECARGO_FINANCIERO=" + _db.CreateSqlParameterName("TOTAL_RECARGO_FINANCIERO") + ", " +
				"TOTAL_ENTREGA_INICIAL=" + _db.CreateSqlParameterName("TOTAL_ENTREGA_INICIAL") + ", " +
				"NRO_COMPROBANTE_SECUENCIA=" + _db.CreateSqlParameterName("NRO_COMPROBANTE_SECUENCIA") + ", " +
				"PERSONA_GARANTE_1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_1_ID") + ", " +
				"PERSONA_GARANTE_2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_2_ID") + ", " +
				"PERSONA_GARANTE_3_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_3_ID") + ", " +
				"NRO_DOCUMENTO_EXTERNO=" + _db.CreateSqlParameterName("NRO_DOCUMENTO_EXTERNO") + ", " +
				"SUCURSAL_VENTA_ID=" + _db.CreateSqlParameterName("SUCURSAL_VENTA_ID") + ", " +
				"CONTROLAR_CANT_MIN_DESC_MAX=" + _db.CreateSqlParameterName("CONTROLAR_CANT_MIN_DESC_MAX") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"GENERAR_TRANSFERENCIA=" + _db.CreateSqlParameterName("GENERAR_TRANSFERENCIA") + ", " +
				"DEPOSITO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPOSITO_DESTINO_ID") + ", " +
				"AUTONUMERACION_TRANSF_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_TRANSF_ID") + ", " +
				"NRO_TIMBRADO_FACT_PRO=" + _db.CreateSqlParameterName("NRO_TIMBRADO_FACT_PRO") + ", " +
				"FECHA_VENC_TIMBRADO_FACT_PRO=" + _db.CreateSqlParameterName("FECHA_VENC_TIMBRADO_FACT_PRO") + ", " +
				"NRO_COMPROBANTE_FACT_PRO=" + _db.CreateSqlParameterName("NRO_COMPROBANTE_FACT_PRO") + ", " +
				"CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				"ES_RAPIDA=" + _db.CreateSqlParameterName("ES_RAPIDA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "CASO_ORIGEN_ID",
				value.IsCASO_ORIGEN_IDNull ? DBNull.Value : (object)value.CASO_ORIGEN_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "VENDEDOR_ID",
				value.IsVENDEDOR_IDNull ? DBNull.Value : (object)value.VENDEDOR_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "TIPO_FACTURA_ID", value.TIPO_FACTURA_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "PORCENTAJE_DESC_SOBRE_TOTAL",
				value.IsPORCENTAJE_DESC_SOBRE_TOTALNull ? DBNull.Value : (object)value.PORCENTAJE_DESC_SOBRE_TOTAL);
			AddParameter(cmd, "MONEDA_DESTINO_ID",
				value.IsMONEDA_DESTINO_IDNull ? DBNull.Value : (object)value.MONEDA_DESTINO_ID);
			AddParameter(cmd, "COTIZACION_DESTINO",
				value.IsCOTIZACION_DESTINONull ? DBNull.Value : (object)value.COTIZACION_DESTINO);
			AddParameter(cmd, "TOTAL_MONTO_IMPUESTO",
				value.IsTOTAL_MONTO_IMPUESTONull ? DBNull.Value : (object)value.TOTAL_MONTO_IMPUESTO);
			AddParameter(cmd, "TOTAL_MONTO_DTO",
				value.IsTOTAL_MONTO_DTONull ? DBNull.Value : (object)value.TOTAL_MONTO_DTO);
			AddParameter(cmd, "TOTAL_MONTO_BRUTO",
				value.IsTOTAL_MONTO_BRUTONull ? DBNull.Value : (object)value.TOTAL_MONTO_BRUTO);
			AddParameter(cmd, "TOTAL_NETO",
				value.IsTOTAL_NETONull ? DBNull.Value : (object)value.TOTAL_NETO);
			AddParameter(cmd, "TOTAL_COSTO_BRUTO",
				value.IsTOTAL_COSTO_BRUTONull ? DBNull.Value : (object)value.TOTAL_COSTO_BRUTO);
			AddParameter(cmd, "TOTAL_COSTO_NETO",
				value.IsTOTAL_COSTO_NETONull ? DBNull.Value : (object)value.TOTAL_COSTO_NETO);
			AddParameter(cmd, "TOTAL_COMISION_VENDEDOR",
				value.IsTOTAL_COMISION_VENDEDORNull ? DBNull.Value : (object)value.TOTAL_COMISION_VENDEDOR);
			AddParameter(cmd, "USUARIO_ID_AUTORIZA_DESCUENTO",
				value.IsUSUARIO_ID_AUTORIZA_DESCUENTONull ? DBNull.Value : (object)value.USUARIO_ID_AUTORIZA_DESCUENTO);
			AddParameter(cmd, "FECHA_AUTORIZACION_DESCUENTO",
				value.IsFECHA_AUTORIZACION_DESCUENTONull ? DBNull.Value : (object)value.FECHA_AUTORIZACION_DESCUENTO);
			AddParameter(cmd, "DESCUENTO_MAX_AUTORIZADO",
				value.IsDESCUENTO_MAX_AUTORIZADONull ? DBNull.Value : (object)value.DESCUENTO_MAX_AUTORIZADO);
			AddParameter(cmd, "AFECTA_LINEA_CREDITO", value.AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "AFECTA_CTACTE", value.AFECTA_CTACTE);
			AddParameter(cmd, "MONTO_AFECTA_LINEA_CREDITO",
				value.IsMONTO_AFECTA_LINEA_CREDITONull ? DBNull.Value : (object)value.MONTO_AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "COMISION_POR_VENTA", value.COMISION_POR_VENTA);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "A_CONSIGNACION", value.A_CONSIGNACION);
			AddParameter(cmd, "DIRECCION", value.DIRECCION);
			AddParameter(cmd, "LATITUD",
				value.IsLATITUDNull ? DBNull.Value : (object)value.LATITUD);
			AddParameter(cmd, "LONGITUD",
				value.IsLONGITUDNull ? DBNull.Value : (object)value.LONGITUD);
			AddParameter(cmd, "OBSERVACION_ENTREGA", value.OBSERVACION_ENTREGA);
			AddParameter(cmd, "CONDICION_DESCRIPCION", value.CONDICION_DESCRIPCION);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "MORA_PORCENTAJE", value.MORA_PORCENTAJE);
			AddParameter(cmd, "MORA_DIAS_GRACIA", value.MORA_DIAS_GRACIA);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			AddParameter(cmd, "TOTAL_RECARGO_FINANCIERO", value.TOTAL_RECARGO_FINANCIERO);
			AddParameter(cmd, "TOTAL_ENTREGA_INICIAL", value.TOTAL_ENTREGA_INICIAL);
			AddParameter(cmd, "NRO_COMPROBANTE_SECUENCIA",
				value.IsNRO_COMPROBANTE_SECUENCIANull ? DBNull.Value : (object)value.NRO_COMPROBANTE_SECUENCIA);
			AddParameter(cmd, "PERSONA_GARANTE_1_ID",
				value.IsPERSONA_GARANTE_1_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_1_ID);
			AddParameter(cmd, "PERSONA_GARANTE_2_ID",
				value.IsPERSONA_GARANTE_2_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_2_ID);
			AddParameter(cmd, "PERSONA_GARANTE_3_ID",
				value.IsPERSONA_GARANTE_3_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE_3_ID);
			AddParameter(cmd, "NRO_DOCUMENTO_EXTERNO", value.NRO_DOCUMENTO_EXTERNO);
			AddParameter(cmd, "SUCURSAL_VENTA_ID",
				value.IsSUCURSAL_VENTA_IDNull ? DBNull.Value : (object)value.SUCURSAL_VENTA_ID);
			AddParameter(cmd, "CONTROLAR_CANT_MIN_DESC_MAX", value.CONTROLAR_CANT_MIN_DESC_MAX);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "GENERAR_TRANSFERENCIA", value.GENERAR_TRANSFERENCIA);
			AddParameter(cmd, "DEPOSITO_DESTINO_ID",
				value.IsDEPOSITO_DESTINO_IDNull ? DBNull.Value : (object)value.DEPOSITO_DESTINO_ID);
			AddParameter(cmd, "AUTONUMERACION_TRANSF_ID",
				value.IsAUTONUMERACION_TRANSF_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_TRANSF_ID);
			AddParameter(cmd, "NRO_TIMBRADO_FACT_PRO", value.NRO_TIMBRADO_FACT_PRO);
			AddParameter(cmd, "FECHA_VENC_TIMBRADO_FACT_PRO",
				value.IsFECHA_VENC_TIMBRADO_FACT_PRONull ? DBNull.Value : (object)value.FECHA_VENC_TIMBRADO_FACT_PRO);
			AddParameter(cmd, "NRO_COMPROBANTE_FACT_PRO", value.NRO_COMPROBANTE_FACT_PRO);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "ES_RAPIDA", value.ES_RAPIDA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FACTURAS_CLIENTE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FACTURAS_CLIENTE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FACTURAS_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_CLIENTERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FACTURAS_CLIENTERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FACTURAS_CLIENTE</c> table using
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
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_DESTINO_ID(decimal moneda_destino_id)
		{
			return DeleteByMONEDA_DESTINO_ID(moneda_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <param name="moneda_destino_idNull">true if the method ignores the moneda_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_DESTINO_ID(decimal moneda_destino_id, bool moneda_destino_idNull)
		{
			return CreateDeleteByMONEDA_DESTINO_IDCommand(moneda_destino_id, moneda_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTRAS_CLI_MONEDA_ID_ORI</c> foreign key.
		/// </summary>
		/// <param name="moneda_destino_id">The <c>MONEDA_DESTINO_ID</c> column value.</param>
		/// <param name="moneda_destino_idNull">true if the method ignores the moneda_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_DESTINO_IDCommand(decimal moneda_destino_id, bool moneda_destino_idNull)
		{
			string whereSql = "";
			if(moneda_destino_idNull)
				whereSql += "MONEDA_DESTINO_ID IS NULL";
			else
				whereSql += "MONEDA_DESTINO_ID=" + _db.CreateSqlParameterName("MONEDA_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_destino_idNull)
				AddParameter(cmd, "MONEDA_DESTINO_ID", moneda_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
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
		/// delete records using the <c>FK_FACTURA_CLI_CAJA_SUC</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return DeleteByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return CreateDeleteByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURA_CLI_COND_PAG_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_TRANSF_ID(decimal autonumeracion_transf_id)
		{
			return DeleteByAUTONUMERACION_TRANSF_ID(autonumeracion_transf_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <param name="autonumeracion_transf_idNull">true if the method ignores the autonumeracion_transf_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_TRANSF_ID(decimal autonumeracion_transf_id, bool autonumeracion_transf_idNull)
		{
			return CreateDeleteByAUTONUMERACION_TRANSF_IDCommand(autonumeracion_transf_id, autonumeracion_transf_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_AUTO_TRANS_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_transf_id">The <c>AUTONUMERACION_TRANSF_ID</c> column value.</param>
		/// <param name="autonumeracion_transf_idNull">true if the method ignores the autonumeracion_transf_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_TRANSF_IDCommand(decimal autonumeracion_transf_id, bool autonumeracion_transf_idNull)
		{
			string whereSql = "";
			if(autonumeracion_transf_idNull)
				whereSql += "AUTONUMERACION_TRANSF_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_TRANSF_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_TRANSF_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_transf_idNull)
				AddParameter(cmd, "AUTONUMERACION_TRANSF_ID", autonumeracion_transf_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return DeleteByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return CreateDeleteByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCANAL_VENTA_IDCommand(decimal canal_venta_id, bool canal_venta_idNull)
		{
			string whereSql = "";
			if(canal_venta_idNull)
				whereSql += "CANAL_VENTA_ID IS NULL";
			else
				whereSql += "CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!canal_venta_idNull)
				AddParameter(cmd, "CANAL_VENTA_ID", canal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return DeleteByCASO_ORIGEN_ID(caso_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGEN_ID(decimal caso_origen_id, bool caso_origen_idNull)
		{
			return CreateDeleteByCASO_ORIGEN_IDCommand(caso_origen_id, caso_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_CASO_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <param name="caso_origen_idNull">true if the method ignores the caso_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ORIGEN_IDCommand(decimal caso_origen_id, bool caso_origen_idNull)
		{
			string whereSql = "";
			if(caso_origen_idNull)
				whereSql += "CASO_ORIGEN_ID IS NULL";
			else
				whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_origen_idNull)
				AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_DESTINO_ID(decimal deposito_destino_id)
		{
			return DeleteByDEPOSITO_DESTINO_ID(deposito_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_DESTINO_ID(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			return CreateDeleteByDEPOSITO_DESTINO_IDCommand(deposito_destino_id, deposito_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DEP_DES_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_DESTINO_IDCommand(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			string whereSql = "";
			if(deposito_destino_idNull)
				whereSql += "DEPOSITO_DESTINO_ID IS NULL";
			else
				whereSql += "DEPOSITO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPOSITO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_destino_idNull)
				AddParameter(cmd, "DEPOSITO_DESTINO_ID", deposito_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return DeleteByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id, deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DEPOSITO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return DeleteByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return CreateDeleteByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_LISTA_PRECI_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id)
		{
			return DeleteByPERSONA_GARANTE_1_ID(persona_garante_1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_1_ID(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE_1_IDCommand(persona_garante_1_id, persona_garante_1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_PERSON_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_1_id">The <c>PERSONA_GARANTE_1_ID</c> column value.</param>
		/// <param name="persona_garante_1_idNull">true if the method ignores the persona_garante_1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE_1_IDCommand(decimal persona_garante_1_id, bool persona_garante_1_idNull)
		{
			string whereSql = "";
			if(persona_garante_1_idNull)
				whereSql += "PERSONA_GARANTE_1_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante_1_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_1_ID", persona_garante_1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id)
		{
			return DeleteByPERSONA_GARANTE_2_ID(persona_garante_2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_2_ID(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE_2_IDCommand(persona_garante_2_id, persona_garante_2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_PERSON_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_2_id">The <c>PERSONA_GARANTE_2_ID</c> column value.</param>
		/// <param name="persona_garante_2_idNull">true if the method ignores the persona_garante_2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE_2_IDCommand(decimal persona_garante_2_id, bool persona_garante_2_idNull)
		{
			string whereSql = "";
			if(persona_garante_2_idNull)
				whereSql += "PERSONA_GARANTE_2_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante_2_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_2_ID", persona_garante_2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id)
		{
			return DeleteByPERSONA_GARANTE_3_ID(persona_garante_3_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE_3_ID(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE_3_IDCommand(persona_garante_3_id, persona_garante_3_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_PERSON_GAR3_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante_3_id">The <c>PERSONA_GARANTE_3_ID</c> column value.</param>
		/// <param name="persona_garante_3_idNull">true if the method ignores the persona_garante_3_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE_3_IDCommand(decimal persona_garante_3_id, bool persona_garante_3_idNull)
		{
			string whereSql = "";
			if(persona_garante_3_idNull)
				whereSql += "PERSONA_GARANTE_3_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE_3_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE_3_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante_3_idNull)
				AddParameter(cmd, "PERSONA_GARANTE_3_ID", persona_garante_3_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_VENTA_ID(decimal sucursal_venta_id)
		{
			return DeleteBySUCURSAL_VENTA_ID(sucursal_venta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <param name="sucursal_venta_idNull">true if the method ignores the sucursal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_VENTA_ID(decimal sucursal_venta_id, bool sucursal_venta_idNull)
		{
			return CreateDeleteBySUCURSAL_VENTA_IDCommand(sucursal_venta_id, sucursal_venta_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_SUCURSAL_VE_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_venta_id">The <c>SUCURSAL_VENTA_ID</c> column value.</param>
		/// <param name="sucursal_venta_idNull">true if the method ignores the sucursal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_VENTA_IDCommand(decimal sucursal_venta_id, bool sucursal_venta_idNull)
		{
			string whereSql = "";
			if(sucursal_venta_idNull)
				whereSql += "SUCURSAL_VENTA_ID IS NULL";
			else
				whereSql += "SUCURSAL_VENTA_ID=" + _db.CreateSqlParameterName("SUCURSAL_VENTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_venta_idNull)
				AddParameter(cmd, "SUCURSAL_VENTA_ID", sucursal_venta_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID_AUTORIZA_DESCUENTO(decimal usuario_id_autoriza_descuento)
		{
			return DeleteByUSUARIO_ID_AUTORIZA_DESCUENTO(usuario_id_autoriza_descuento, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <param name="usuario_id_autoriza_descuentoNull">true if the method ignores the usuario_id_autoriza_descuento
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID_AUTORIZA_DESCUENTO(decimal usuario_id_autoriza_descuento, bool usuario_id_autoriza_descuentoNull)
		{
			return CreateDeleteByUSUARIO_ID_AUTORIZA_DESCUENTOCommand(usuario_id_autoriza_descuento, usuario_id_autoriza_descuentoNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_USUARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id_autoriza_descuento">The <c>USUARIO_ID_AUTORIZA_DESCUENTO</c> column value.</param>
		/// <param name="usuario_id_autoriza_descuentoNull">true if the method ignores the usuario_id_autoriza_descuento
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_ID_AUTORIZA_DESCUENTOCommand(decimal usuario_id_autoriza_descuento, bool usuario_id_autoriza_descuentoNull)
		{
			string whereSql = "";
			if(usuario_id_autoriza_descuentoNull)
				whereSql += "USUARIO_ID_AUTORIZA_DESCUENTO IS NULL";
			else
				whereSql += "USUARIO_ID_AUTORIZA_DESCUENTO=" + _db.CreateSqlParameterName("USUARIO_ID_AUTORIZA_DESCUENTO");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_id_autoriza_descuentoNull)
				AddParameter(cmd, "USUARIO_ID_AUTORIZA_DESCUENTO", usuario_id_autoriza_descuento);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_ID(decimal vendedor_id)
		{
			return DeleteByVENDEDOR_ID(vendedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE</c> table using the 
		/// <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_ID(decimal vendedor_id, bool vendedor_idNull)
		{
			return CreateDeleteByVENDEDOR_IDCommand(vendedor_id, vendedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_VENDEDOR</c> foreign key.
		/// </summary>
		/// <param name="vendedor_id">The <c>VENDEDOR_ID</c> column value.</param>
		/// <param name="vendedor_idNull">true if the method ignores the vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVENDEDOR_IDCommand(decimal vendedor_id, bool vendedor_idNull)
		{
			string whereSql = "";
			if(vendedor_idNull)
				whereSql += "VENDEDOR_ID IS NULL";
			else
				whereSql += "VENDEDOR_ID=" + _db.CreateSqlParameterName("VENDEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vendedor_idNull)
				AddParameter(cmd, "VENDEDOR_ID", vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FACTURAS_CLIENTE</c> records that match the specified criteria.
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
		/// to delete <c>FACTURAS_CLIENTE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FACTURAS_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FACTURAS_CLIENTE</c> table.
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		protected FACTURAS_CLIENTERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		protected FACTURAS_CLIENTERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTERow"/> objects.</returns>
		protected virtual FACTURAS_CLIENTERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_origen_idColumnIndex = reader.GetOrdinal("CASO_ORIGEN_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int vendedor_idColumnIndex = reader.GetOrdinal("VENDEDOR_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int tipo_factura_idColumnIndex = reader.GetOrdinal("TIPO_FACTURA_ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int porcentaje_desc_sobre_totalColumnIndex = reader.GetOrdinal("PORCENTAJE_DESC_SOBRE_TOTAL");
			int moneda_destino_idColumnIndex = reader.GetOrdinal("MONEDA_DESTINO_ID");
			int cotizacion_destinoColumnIndex = reader.GetOrdinal("COTIZACION_DESTINO");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_monto_brutoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int total_costo_brutoColumnIndex = reader.GetOrdinal("TOTAL_COSTO_BRUTO");
			int total_costo_netoColumnIndex = reader.GetOrdinal("TOTAL_COSTO_NETO");
			int total_comision_vendedorColumnIndex = reader.GetOrdinal("TOTAL_COMISION_VENDEDOR");
			int usuario_id_autoriza_descuentoColumnIndex = reader.GetOrdinal("USUARIO_ID_AUTORIZA_DESCUENTO");
			int fecha_autorizacion_descuentoColumnIndex = reader.GetOrdinal("FECHA_AUTORIZACION_DESCUENTO");
			int descuento_max_autorizadoColumnIndex = reader.GetOrdinal("DESCUENTO_MAX_AUTORIZADO");
			int afecta_linea_creditoColumnIndex = reader.GetOrdinal("AFECTA_LINEA_CREDITO");
			int afecta_ctacteColumnIndex = reader.GetOrdinal("AFECTA_CTACTE");
			int monto_afecta_linea_creditoColumnIndex = reader.GetOrdinal("MONTO_AFECTA_LINEA_CREDITO");
			int comision_por_ventaColumnIndex = reader.GetOrdinal("COMISION_POR_VENTA");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int a_consignacionColumnIndex = reader.GetOrdinal("A_CONSIGNACION");
			int direccionColumnIndex = reader.GetOrdinal("DIRECCION");
			int latitudColumnIndex = reader.GetOrdinal("LATITUD");
			int longitudColumnIndex = reader.GetOrdinal("LONGITUD");
			int observacion_entregaColumnIndex = reader.GetOrdinal("OBSERVACION_ENTREGA");
			int condicion_descripcionColumnIndex = reader.GetOrdinal("CONDICION_DESCRIPCION");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int mora_porcentajeColumnIndex = reader.GetOrdinal("MORA_PORCENTAJE");
			int mora_dias_graciaColumnIndex = reader.GetOrdinal("MORA_DIAS_GRACIA");
			int afecta_stockColumnIndex = reader.GetOrdinal("AFECTA_STOCK");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int total_entrega_inicialColumnIndex = reader.GetOrdinal("TOTAL_ENTREGA_INICIAL");
			int nro_comprobante_secuenciaColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_SECUENCIA");
			int persona_garante_1_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_1_ID");
			int persona_garante_2_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_2_ID");
			int persona_garante_3_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_3_ID");
			int nro_documento_externoColumnIndex = reader.GetOrdinal("NRO_DOCUMENTO_EXTERNO");
			int sucursal_venta_idColumnIndex = reader.GetOrdinal("SUCURSAL_VENTA_ID");
			int controlar_cant_min_desc_maxColumnIndex = reader.GetOrdinal("CONTROLAR_CANT_MIN_DESC_MAX");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int generar_transferenciaColumnIndex = reader.GetOrdinal("GENERAR_TRANSFERENCIA");
			int deposito_destino_idColumnIndex = reader.GetOrdinal("DEPOSITO_DESTINO_ID");
			int autonumeracion_transf_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_TRANSF_ID");
			int nro_timbrado_fact_proColumnIndex = reader.GetOrdinal("NRO_TIMBRADO_FACT_PRO");
			int fecha_venc_timbrado_fact_proColumnIndex = reader.GetOrdinal("FECHA_VENC_TIMBRADO_FACT_PRO");
			int nro_comprobante_fact_proColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_FACT_PRO");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int es_rapidaColumnIndex = reader.GetOrdinal("ES_RAPIDA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_CLIENTERow record = new FACTURAS_CLIENTERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_origen_idColumnIndex))
						record.CASO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(vendedor_idColumnIndex))
						record.VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_factura_idColumnIndex))
						record.TIPO_FACTURA_ID = Convert.ToString(reader.GetValue(tipo_factura_idColumnIndex));
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_desc_sobre_totalColumnIndex))
						record.PORCENTAJE_DESC_SOBRE_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_desc_sobre_totalColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_destino_idColumnIndex))
						record.MONEDA_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_destinoColumnIndex))
						record.COTIZACION_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_impuestoColumnIndex))
						record.TOTAL_MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_dtoColumnIndex))
						record.TOTAL_MONTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_dtoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_brutoColumnIndex))
						record.TOTAL_MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_netoColumnIndex))
						record.TOTAL_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costo_brutoColumnIndex))
						record.TOTAL_COSTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costo_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_costo_netoColumnIndex))
						record.TOTAL_COSTO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_costo_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_comision_vendedorColumnIndex))
						record.TOTAL_COMISION_VENDEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(total_comision_vendedorColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_id_autoriza_descuentoColumnIndex))
						record.USUARIO_ID_AUTORIZA_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_id_autoriza_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_autorizacion_descuentoColumnIndex))
						record.FECHA_AUTORIZACION_DESCUENTO = Convert.ToDateTime(reader.GetValue(fecha_autorizacion_descuentoColumnIndex));
					if(!reader.IsDBNull(descuento_max_autorizadoColumnIndex))
						record.DESCUENTO_MAX_AUTORIZADO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_max_autorizadoColumnIndex)), 9);
					if(!reader.IsDBNull(afecta_linea_creditoColumnIndex))
						record.AFECTA_LINEA_CREDITO = Convert.ToString(reader.GetValue(afecta_linea_creditoColumnIndex));
					record.AFECTA_CTACTE = Convert.ToString(reader.GetValue(afecta_ctacteColumnIndex));
					if(!reader.IsDBNull(monto_afecta_linea_creditoColumnIndex))
						record.MONTO_AFECTA_LINEA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_afecta_linea_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(comision_por_ventaColumnIndex))
						record.COMISION_POR_VENTA = Convert.ToString(reader.GetValue(comision_por_ventaColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.A_CONSIGNACION = Convert.ToString(reader.GetValue(a_consignacionColumnIndex));
					if(!reader.IsDBNull(direccionColumnIndex))
						record.DIRECCION = Convert.ToString(reader.GetValue(direccionColumnIndex));
					if(!reader.IsDBNull(latitudColumnIndex))
						record.LATITUD = Math.Round(Convert.ToDecimal(reader.GetValue(latitudColumnIndex)), 9);
					if(!reader.IsDBNull(longitudColumnIndex))
						record.LONGITUD = Math.Round(Convert.ToDecimal(reader.GetValue(longitudColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_entregaColumnIndex))
						record.OBSERVACION_ENTREGA = Convert.ToString(reader.GetValue(observacion_entregaColumnIndex));
					if(!reader.IsDBNull(condicion_descripcionColumnIndex))
						record.CONDICION_DESCRIPCION = Convert.ToString(reader.GetValue(condicion_descripcionColumnIndex));
					record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					record.MORA_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(mora_porcentajeColumnIndex)), 9);
					record.MORA_DIAS_GRACIA = Math.Round(Convert.ToDecimal(reader.GetValue(mora_dias_graciaColumnIndex)), 9);
					record.AFECTA_STOCK = Convert.ToString(reader.GetValue(afecta_stockColumnIndex));
					record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					record.TOTAL_ENTREGA_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(total_entrega_inicialColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobante_secuenciaColumnIndex))
						record.NRO_COMPROBANTE_SECUENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(nro_comprobante_secuenciaColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_1_idColumnIndex))
						record.PERSONA_GARANTE_1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_1_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_2_idColumnIndex))
						record.PERSONA_GARANTE_2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_2_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_3_idColumnIndex))
						record.PERSONA_GARANTE_3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_3_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_documento_externoColumnIndex))
						record.NRO_DOCUMENTO_EXTERNO = Convert.ToString(reader.GetValue(nro_documento_externoColumnIndex));
					if(!reader.IsDBNull(sucursal_venta_idColumnIndex))
						record.SUCURSAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_venta_idColumnIndex)), 9);
					record.CONTROLAR_CANT_MIN_DESC_MAX = Convert.ToString(reader.GetValue(controlar_cant_min_desc_maxColumnIndex));
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.GENERAR_TRANSFERENCIA = Convert.ToString(reader.GetValue(generar_transferenciaColumnIndex));
					if(!reader.IsDBNull(deposito_destino_idColumnIndex))
						record.DEPOSITO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_transf_idColumnIndex))
						record.AUTONUMERACION_TRANSF_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_transf_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_timbrado_fact_proColumnIndex))
						record.NRO_TIMBRADO_FACT_PRO = Convert.ToString(reader.GetValue(nro_timbrado_fact_proColumnIndex));
					if(!reader.IsDBNull(fecha_venc_timbrado_fact_proColumnIndex))
						record.FECHA_VENC_TIMBRADO_FACT_PRO = Convert.ToDateTime(reader.GetValue(fecha_venc_timbrado_fact_proColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_fact_proColumnIndex))
						record.NRO_COMPROBANTE_FACT_PRO = Convert.ToString(reader.GetValue(nro_comprobante_fact_proColumnIndex));
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					if(!reader.IsDBNull(es_rapidaColumnIndex))
						record.ES_RAPIDA = Convert.ToString(reader.GetValue(es_rapidaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_CLIENTERow[])(recordList.ToArray(typeof(FACTURAS_CLIENTERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_CLIENTERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_CLIENTERow"/> object.</returns>
		protected virtual FACTURAS_CLIENTERow MapRow(DataRow row)
		{
			FACTURAS_CLIENTERow mappedObject = new FACTURAS_CLIENTERow();
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
			// Column "CASO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CASO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "VENDEDOR_ID"
			dataColumn = dataTable.Columns["VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "TIPO_FACTURA_ID"
			dataColumn = dataTable.Columns["TIPO_FACTURA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FACTURA_ID = (string)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DESC_SOBRE_TOTAL"
			dataColumn = dataTable.Columns["PORCENTAJE_DESC_SOBRE_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DESC_SOBRE_TOTAL = (decimal)row[dataColumn];
			// Column "MONEDA_DESTINO_ID"
			dataColumn = dataTable.Columns["MONEDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_DESTINO_ID = (decimal)row[dataColumn];
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
			// Column "TOTAL_MONTO_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_BRUTO = (decimal)row[dataColumn];
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
			// Column "AFECTA_CTACTE"
			dataColumn = dataTable.Columns["AFECTA_CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE = (string)row[dataColumn];
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
			// Column "A_CONSIGNACION"
			dataColumn = dataTable.Columns["A_CONSIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.A_CONSIGNACION = (string)row[dataColumn];
			// Column "DIRECCION"
			dataColumn = dataTable.Columns["DIRECCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION = (string)row[dataColumn];
			// Column "LATITUD"
			dataColumn = dataTable.Columns["LATITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD = (decimal)row[dataColumn];
			// Column "LONGITUD"
			dataColumn = dataTable.Columns["LONGITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD = (decimal)row[dataColumn];
			// Column "OBSERVACION_ENTREGA"
			dataColumn = dataTable.Columns["OBSERVACION_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_ENTREGA = (string)row[dataColumn];
			// Column "CONDICION_DESCRIPCION"
			dataColumn = dataTable.Columns["CONDICION_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_DESCRIPCION = (string)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "MORA_PORCENTAJE"
			dataColumn = dataTable.Columns["MORA_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_PORCENTAJE = (decimal)row[dataColumn];
			// Column "MORA_DIAS_GRACIA"
			dataColumn = dataTable.Columns["MORA_DIAS_GRACIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_DIAS_GRACIA = (decimal)row[dataColumn];
			// Column "AFECTA_STOCK"
			dataColumn = dataTable.Columns["AFECTA_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_STOCK = (string)row[dataColumn];
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "TOTAL_ENTREGA_INICIAL"
			dataColumn = dataTable.Columns["TOTAL_ENTREGA_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_ENTREGA_INICIAL = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE_SECUENCIA"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_SECUENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_SECUENCIA = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_1_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_1_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_2_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_2_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE_3_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE_3_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE_3_ID = (decimal)row[dataColumn];
			// Column "NRO_DOCUMENTO_EXTERNO"
			dataColumn = dataTable.Columns["NRO_DOCUMENTO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_DOCUMENTO_EXTERNO = (string)row[dataColumn];
			// Column "SUCURSAL_VENTA_ID"
			dataColumn = dataTable.Columns["SUCURSAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "CONTROLAR_CANT_MIN_DESC_MAX"
			dataColumn = dataTable.Columns["CONTROLAR_CANT_MIN_DESC_MAX"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTROLAR_CANT_MIN_DESC_MAX = (string)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "GENERAR_TRANSFERENCIA"
			dataColumn = dataTable.Columns["GENERAR_TRANSFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_TRANSFERENCIA = (string)row[dataColumn];
			// Column "DEPOSITO_DESTINO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_TRANSF_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_TRANSF_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_TRANSF_ID = (decimal)row[dataColumn];
			// Column "NRO_TIMBRADO_FACT_PRO"
			dataColumn = dataTable.Columns["NRO_TIMBRADO_FACT_PRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TIMBRADO_FACT_PRO = (string)row[dataColumn];
			// Column "FECHA_VENC_TIMBRADO_FACT_PRO"
			dataColumn = dataTable.Columns["FECHA_VENC_TIMBRADO_FACT_PRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENC_TIMBRADO_FACT_PRO = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE_FACT_PRO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_FACT_PRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_FACT_PRO = (string)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "ES_RAPIDA"
			dataColumn = dataTable.Columns["ES_RAPIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_RAPIDA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_CLIENTE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("VENDEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_FACTURA_ID", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DESC_SOBRE_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_DESTINO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_COSTO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_COMISION_VENDEDOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USUARIO_ID_AUTORIZA_DESCUENTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_AUTORIZACION_DESCUENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAX_AUTORIZADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AFECTA_LINEA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_AFECTA_LINEA_CREDITO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COMISION_POR_VENTA", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("A_CONSIGNACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIRECCION", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("LATITUD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION_ENTREGA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("CONDICION_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MORA_PORCENTAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MORA_DIAS_GRACIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_ENTREGA_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_SECUENCIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_3_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_DOCUMENTO_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SUCURSAL_VENTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONTROLAR_CANT_MIN_DESC_MAX", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GENERAR_TRANSFERENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITO_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_TRANSF_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_TIMBRADO_FACT_PRO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_VENC_TIMBRADO_FACT_PRO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_FACT_PRO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_RAPIDA", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "CASO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_FACTURA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DESC_SOBRE_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "TOTAL_MONTO_BRUTO":
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

				case "AFECTA_CTACTE":
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

				case "A_CONSIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DIRECCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONDICION_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MORA_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MORA_DIAS_GRACIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AFECTA_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_ENTREGA_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE_SECUENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE_3_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_DOCUMENTO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTROLAR_CANT_MIN_DESC_MAX":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "GENERAR_TRANSFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DEPOSITO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_TRANSF_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_TIMBRADO_FACT_PRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VENC_TIMBRADO_FACT_PRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE_FACT_PRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_RAPIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_CLIENTECollection_Base class
}  // End of namespace
