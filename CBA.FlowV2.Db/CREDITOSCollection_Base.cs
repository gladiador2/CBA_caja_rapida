// <fileinfo name="CREDITOSCollection_Base.cs">
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
	/// The base class for <see cref="CREDITOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CREDITOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CREDITOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_GARANTE1_IDColumnName = "PERSONA_GARANTE1_ID";
		public const string PERSONA_GARANTE2_IDColumnName = "PERSONA_GARANTE2_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_SOLICITUDColumnName = "FECHA_SOLICITUD";
		public const string FECHA_RETIROColumnName = "FECHA_RETIRO";
		public const string SEPARACION_BIENESColumnName = "SEPARACION_BIENES";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string TOTAL_INGRESOSColumnName = "TOTAL_INGRESOS";
		public const string TOTAL_EGRESOSColumnName = "TOTAL_EGRESOS";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CANTIDAD_CUOTASColumnName = "CANTIDAD_CUOTAS";
		public const string PORCENTAJE_INTERESColumnName = "PORCENTAJE_INTERES";
		public const string PORCENTAJE_DIARIO_MORAColumnName = "PORCENTAJE_DIARIO_MORA";
		public const string PORCENTAJE_GASTO_ADMINISTColumnName = "PORCENTAJE_GASTO_ADMINIST";
		public const string MONTO_CAPITAL_APROBADOColumnName = "MONTO_CAPITAL_APROBADO";
		public const string MONTO_INTERESColumnName = "MONTO_INTERES";
		public const string MONTO_GASTO_ADMINISTRATIVOColumnName = "MONTO_GASTO_ADMINISTRATIVO";
		public const string MONTO_CAPITAL_SOLICITADOColumnName = "MONTO_CAPITAL_SOLICITADO";
		public const string MONTO_TOTALColumnName = "MONTO_TOTAL";
		public const string TIPO_CREDITO_IDColumnName = "TIPO_CREDITO_ID";
		public const string FACTURA_CLIENTE_IDColumnName = "FACTURA_CLIENTE_ID";
		public const string FACTURA_CLIENTE_AUTON_IDColumnName = "FACTURA_CLIENTE_AUTON_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string NUMERO_SOLICITUDColumnName = "NUMERO_SOLICITUD";
		public const string ORDENES_PAGO_IDColumnName = "ORDENES_PAGO_ID";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string ENTREGA_INICIALColumnName = "ENTREGA_INICIAL";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string CON_RECURSOColumnName = "CON_RECURSO";
		public const string DESEMBOLSAR_PARA_CLIENTEColumnName = "DESEMBOLSAR_PARA_CLIENTE";
		public const string INTERES_INCLUYE_IMPUESTOColumnName = "INTERES_INCLUYE_IMPUESTO";
		public const string TIPO_FRECUENCIAColumnName = "TIPO_FRECUENCIA";
		public const string FRECUENCIAColumnName = "FRECUENCIA";
		public const string ANHO_COMERCIALColumnName = "ANHO_COMERCIAL";
		public const string FACTURAR_CONCEPTOS_EN_PAGOSColumnName = "FACTURAR_CONCEPTOS_EN_PAGOS";
		public const string AUMENTAR_CAPITAL_POR_DESCUENTColumnName = "AUMENTAR_CAPITAL_POR_DESCUENT";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string DIAS_GRACIAColumnName = "DIAS_GRACIA";
		public const string PORCENTAJE_SEGUROColumnName = "PORCENTAJE_SEGURO";
		public const string PORCENTAJE_CORRETAJEColumnName = "PORCENTAJE_CORRETAJE";
		public const string PORCENTAJE_COMISION_ADMINColumnName = "PORCENTAJE_COMISION_ADMIN";
		public const string PORCENTAJE_BONIFICACIONColumnName = "PORCENTAJE_BONIFICACION";
		public const string MONTO_SEGUROColumnName = "MONTO_SEGURO";
		public const string MONTO_CORRETAJEColumnName = "MONTO_CORRETAJE";
		public const string MONTO_COMISION_ADMINColumnName = "MONTO_COMISION_ADMIN";
		public const string MONTO_BONIFICACIONColumnName = "MONTO_BONIFICACION";
		public const string DESCUENTO_CANCELACION_ANTICIPColumnName = "DESCUENTO_CANCELACION_ANTICIP";
		public const string ESTADOColumnName = "ESTADO";
		public const string FECHA_PRIMER_VENCIMIENTOColumnName = "FECHA_PRIMER_VENCIMIENTO";
		public const string MONTO_REDONDEOColumnName = "MONTO_REDONDEO";
		public const string TIPO_INTERES_ANUALColumnName = "TIPO_INTERES_ANUAL";
		public const string CONCEPTO_INCLUYE_IMPUESTOColumnName = "CONCEPTO_INCLUYE_IMPUESTO";
		public const string MONTO_CAPITAL_ORDEN_COMPRAColumnName = "MONTO_CAPITAL_ORDEN_COMPRA";
		public const string FACTURAR_BONIFICACION_EN_PAGOSColumnName = "FACTURAR_BONIFICACION_EN_PAGOS";
		public const string BONIFICACION_INCLUYE_IMPUESTOColumnName = "BONIFICACION_INCLUYE_IMPUESTO";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string APROBACION_1ColumnName = "APROBACION_1";
		public const string APROBACION_1_USUARIO_IDColumnName = "APROBACION_1_USUARIO_ID";
		public const string APROBACION_1_FECHAColumnName = "APROBACION_1_FECHA";
		public const string APROBACION_2ColumnName = "APROBACION_2";
		public const string APROBACION_2_USUARIO_IDColumnName = "APROBACION_2_USUARIO_ID";
		public const string APROBACION_2_FECHAColumnName = "APROBACION_2_FECHA";
		public const string APROBACION_3ColumnName = "APROBACION_3";
		public const string APROBACION_3_USUARIO_IDColumnName = "APROBACION_3_USUARIO_ID";
		public const string APROBACION_3_FECHAColumnName = "APROBACION_3_FECHA";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string FACTURAR_INTERESESColumnName = "FACTURAR_INTERESES";
		public const string PORCENTAJE_OTROSColumnName = "PORCENTAJE_OTROS";
		public const string MONTO_OTROSColumnName = "MONTO_OTROS";
		public const string INTERES_COMPUESTOColumnName = "INTERES_COMPUESTO";
		public const string AFECTA_LINEA_CREDITOColumnName = "AFECTA_LINEA_CREDITO";
		public const string FACTURAR_CAPITALColumnName = "FACTURAR_CAPITAL";
		public const string MONTO_DIARIO_MORAColumnName = "MONTO_DIARIO_MORA";
		public const string FECHA_CANCELACION_ANTICIPADAColumnName = "FECHA_CANCELACION_ANTICIPADA";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string DESCUENTO_CANC_ANT_APLICADOColumnName = "DESCUENTO_CANC_ANT_APLICADO";
		public const string DESCUENTO_CANC_ANT_CANT_NO_VENColumnName = "DESCUENTO_CANC_ANT_CANT_NO_VEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CREDITOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CREDITOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CREDITOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CREDITOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CREDITOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CREDITOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CREDITOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CREDITOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CREDITOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CREDITOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CREDITOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CREDITOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CREDITOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CREDITOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_IDAsDataTable(decimal activo_id, bool activo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByAPROBACION_1_USUARIO_ID(decimal aprobacion_1_usuario_id)
		{
			return GetByAPROBACION_1_USUARIO_ID(aprobacion_1_usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_1_usuario_idNull">true if the method ignores the aprobacion_1_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByAPROBACION_1_USUARIO_ID(decimal aprobacion_1_usuario_id, bool aprobacion_1_usuario_idNull)
		{
			return MapRecords(CreateGetByAPROBACION_1_USUARIO_IDCommand(aprobacion_1_usuario_id, aprobacion_1_usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPROBACION_1_USUARIO_IDAsDataTable(decimal aprobacion_1_usuario_id)
		{
			return GetByAPROBACION_1_USUARIO_IDAsDataTable(aprobacion_1_usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_1_usuario_idNull">true if the method ignores the aprobacion_1_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPROBACION_1_USUARIO_IDAsDataTable(decimal aprobacion_1_usuario_id, bool aprobacion_1_usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPROBACION_1_USUARIO_IDCommand(aprobacion_1_usuario_id, aprobacion_1_usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_1_usuario_idNull">true if the method ignores the aprobacion_1_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPROBACION_1_USUARIO_IDCommand(decimal aprobacion_1_usuario_id, bool aprobacion_1_usuario_idNull)
		{
			string whereSql = "";
			if(aprobacion_1_usuario_idNull)
				whereSql += "APROBACION_1_USUARIO_ID IS NULL";
			else
				whereSql += "APROBACION_1_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_1_USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aprobacion_1_usuario_idNull)
				AddParameter(cmd, "APROBACION_1_USUARIO_ID", aprobacion_1_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByAPROBACION_2_USUARIO_ID(decimal aprobacion_2_usuario_id)
		{
			return GetByAPROBACION_2_USUARIO_ID(aprobacion_2_usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_2_usuario_idNull">true if the method ignores the aprobacion_2_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByAPROBACION_2_USUARIO_ID(decimal aprobacion_2_usuario_id, bool aprobacion_2_usuario_idNull)
		{
			return MapRecords(CreateGetByAPROBACION_2_USUARIO_IDCommand(aprobacion_2_usuario_id, aprobacion_2_usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPROBACION_2_USUARIO_IDAsDataTable(decimal aprobacion_2_usuario_id)
		{
			return GetByAPROBACION_2_USUARIO_IDAsDataTable(aprobacion_2_usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_2_usuario_idNull">true if the method ignores the aprobacion_2_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPROBACION_2_USUARIO_IDAsDataTable(decimal aprobacion_2_usuario_id, bool aprobacion_2_usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPROBACION_2_USUARIO_IDCommand(aprobacion_2_usuario_id, aprobacion_2_usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_2_usuario_idNull">true if the method ignores the aprobacion_2_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPROBACION_2_USUARIO_IDCommand(decimal aprobacion_2_usuario_id, bool aprobacion_2_usuario_idNull)
		{
			string whereSql = "";
			if(aprobacion_2_usuario_idNull)
				whereSql += "APROBACION_2_USUARIO_ID IS NULL";
			else
				whereSql += "APROBACION_2_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_2_USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aprobacion_2_usuario_idNull)
				AddParameter(cmd, "APROBACION_2_USUARIO_ID", aprobacion_2_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByAPROBACION_3_USUARIO_ID(decimal aprobacion_3_usuario_id)
		{
			return GetByAPROBACION_3_USUARIO_ID(aprobacion_3_usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_3_usuario_idNull">true if the method ignores the aprobacion_3_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByAPROBACION_3_USUARIO_ID(decimal aprobacion_3_usuario_id, bool aprobacion_3_usuario_idNull)
		{
			return MapRecords(CreateGetByAPROBACION_3_USUARIO_IDCommand(aprobacion_3_usuario_id, aprobacion_3_usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPROBACION_3_USUARIO_IDAsDataTable(decimal aprobacion_3_usuario_id)
		{
			return GetByAPROBACION_3_USUARIO_IDAsDataTable(aprobacion_3_usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_3_usuario_idNull">true if the method ignores the aprobacion_3_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPROBACION_3_USUARIO_IDAsDataTable(decimal aprobacion_3_usuario_id, bool aprobacion_3_usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPROBACION_3_USUARIO_IDCommand(aprobacion_3_usuario_id, aprobacion_3_usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_3_usuario_idNull">true if the method ignores the aprobacion_3_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPROBACION_3_USUARIO_IDCommand(decimal aprobacion_3_usuario_id, bool aprobacion_3_usuario_idNull)
		{
			string whereSql = "";
			if(aprobacion_3_usuario_idNull)
				whereSql += "APROBACION_3_USUARIO_ID IS NULL";
			else
				whereSql += "APROBACION_3_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_3_USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aprobacion_3_usuario_idNull)
				AddParameter(cmd, "APROBACION_3_USUARIO_ID", aprobacion_3_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <param name="canal_venta_idNull">true if the method ignores the canal_venta_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByCANAL_VENTA_ID(decimal canal_venta_id, bool canal_venta_idNull)
		{
			return MapRecords(CreateGetByCANAL_VENTA_IDCommand(canal_venta_id, canal_venta_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCANAL_VENTA_IDAsDataTable(decimal canal_venta_id)
		{
			return GetByCANAL_VENTA_IDAsDataTable(canal_venta_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
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
		/// return records by the <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
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
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
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
		/// return records by the <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
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
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_tesoreria_idNull)
				whereSql += "CTACTE_CAJA_TESORERIA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_tesoreria_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_IDAsDataTable(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecords(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_IDAsDataTable(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByFACTURA_CLIENTE_ID(decimal factura_cliente_id)
		{
			return GetByFACTURA_CLIENTE_ID(factura_cliente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <param name="factura_cliente_idNull">true if the method ignores the factura_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByFACTURA_CLIENTE_ID(decimal factura_cliente_id, bool factura_cliente_idNull)
		{
			return MapRecords(CreateGetByFACTURA_CLIENTE_IDCommand(factura_cliente_id, factura_cliente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFACTURA_CLIENTE_IDAsDataTable(decimal factura_cliente_id)
		{
			return GetByFACTURA_CLIENTE_IDAsDataTable(factura_cliente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <param name="factura_cliente_idNull">true if the method ignores the factura_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFACTURA_CLIENTE_IDAsDataTable(decimal factura_cliente_id, bool factura_cliente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFACTURA_CLIENTE_IDCommand(factura_cliente_id, factura_cliente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <param name="factura_cliente_idNull">true if the method ignores the factura_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFACTURA_CLIENTE_IDCommand(decimal factura_cliente_id, bool factura_cliente_idNull)
		{
			string whereSql = "";
			if(factura_cliente_idNull)
				whereSql += "FACTURA_CLIENTE_ID IS NULL";
			else
				whereSql += "FACTURA_CLIENTE_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!factura_cliente_idNull)
				AddParameter(cmd, "FACTURA_CLIENTE_ID", factura_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByFACTURA_CLIENTE_AUTON_ID(decimal factura_cliente_auton_id)
		{
			return GetByFACTURA_CLIENTE_AUTON_ID(factura_cliente_auton_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <param name="factura_cliente_auton_idNull">true if the method ignores the factura_cliente_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByFACTURA_CLIENTE_AUTON_ID(decimal factura_cliente_auton_id, bool factura_cliente_auton_idNull)
		{
			return MapRecords(CreateGetByFACTURA_CLIENTE_AUTON_IDCommand(factura_cliente_auton_id, factura_cliente_auton_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFACTURA_CLIENTE_AUTON_IDAsDataTable(decimal factura_cliente_auton_id)
		{
			return GetByFACTURA_CLIENTE_AUTON_IDAsDataTable(factura_cliente_auton_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <param name="factura_cliente_auton_idNull">true if the method ignores the factura_cliente_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFACTURA_CLIENTE_AUTON_IDAsDataTable(decimal factura_cliente_auton_id, bool factura_cliente_auton_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFACTURA_CLIENTE_AUTON_IDCommand(factura_cliente_auton_id, factura_cliente_auton_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <param name="factura_cliente_auton_idNull">true if the method ignores the factura_cliente_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFACTURA_CLIENTE_AUTON_IDCommand(decimal factura_cliente_auton_id, bool factura_cliente_auton_idNull)
		{
			string whereSql = "";
			if(factura_cliente_auton_idNull)
				whereSql += "FACTURA_CLIENTE_AUTON_ID IS NULL";
			else
				whereSql += "FACTURA_CLIENTE_AUTON_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_AUTON_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!factura_cliente_auton_idNull)
				AddParameter(cmd, "FACTURA_CLIENTE_AUTON_ID", factura_cliente_auton_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_MONEDA_ID</c> foreign key.
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
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByORDENES_PAGO_ID(decimal ordenes_pago_id)
		{
			return GetByORDENES_PAGO_ID(ordenes_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <param name="ordenes_pago_idNull">true if the method ignores the ordenes_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByORDENES_PAGO_ID(decimal ordenes_pago_id, bool ordenes_pago_idNull)
		{
			return MapRecords(CreateGetByORDENES_PAGO_IDCommand(ordenes_pago_id, ordenes_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDENES_PAGO_IDAsDataTable(decimal ordenes_pago_id)
		{
			return GetByORDENES_PAGO_IDAsDataTable(ordenes_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <param name="ordenes_pago_idNull">true if the method ignores the ordenes_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDENES_PAGO_IDAsDataTable(decimal ordenes_pago_id, bool ordenes_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDENES_PAGO_IDCommand(ordenes_pago_id, ordenes_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <param name="ordenes_pago_idNull">true if the method ignores the ordenes_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDENES_PAGO_IDCommand(decimal ordenes_pago_id, bool ordenes_pago_idNull)
		{
			string whereSql = "";
			if(ordenes_pago_idNull)
				whereSql += "ORDENES_PAGO_ID IS NULL";
			else
				whereSql += "ORDENES_PAGO_ID=" + _db.CreateSqlParameterName("ORDENES_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ordenes_pago_idNull)
				AddParameter(cmd, "ORDENES_PAGO_ID", ordenes_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByPERSONA_GARANTE1_ID(decimal persona_garante1_id)
		{
			return GetByPERSONA_GARANTE1_ID(persona_garante1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <param name="persona_garante1_idNull">true if the method ignores the persona_garante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByPERSONA_GARANTE1_ID(decimal persona_garante1_id, bool persona_garante1_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE1_IDCommand(persona_garante1_id, persona_garante1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE1_IDAsDataTable(decimal persona_garante1_id)
		{
			return GetByPERSONA_GARANTE1_IDAsDataTable(persona_garante1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <param name="persona_garante1_idNull">true if the method ignores the persona_garante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE1_IDAsDataTable(decimal persona_garante1_id, bool persona_garante1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE1_IDCommand(persona_garante1_id, persona_garante1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <param name="persona_garante1_idNull">true if the method ignores the persona_garante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE1_IDCommand(decimal persona_garante1_id, bool persona_garante1_idNull)
		{
			string whereSql = "";
			if(persona_garante1_idNull)
				whereSql += "PERSONA_GARANTE1_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante1_idNull)
				AddParameter(cmd, "PERSONA_GARANTE1_ID", persona_garante1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public CREDITOSRow[] GetByPERSONA_GARANTE2_ID(decimal persona_garante2_id)
		{
			return GetByPERSONA_GARANTE2_ID(persona_garante2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <param name="persona_garante2_idNull">true if the method ignores the persona_garante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByPERSONA_GARANTE2_ID(decimal persona_garante2_id, bool persona_garante2_idNull)
		{
			return MapRecords(CreateGetByPERSONA_GARANTE2_IDCommand(persona_garante2_id, persona_garante2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_GARANTE2_IDAsDataTable(decimal persona_garante2_id)
		{
			return GetByPERSONA_GARANTE2_IDAsDataTable(persona_garante2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <param name="persona_garante2_idNull">true if the method ignores the persona_garante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_GARANTE2_IDAsDataTable(decimal persona_garante2_id, bool persona_garante2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_GARANTE2_IDCommand(persona_garante2_id, persona_garante2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <param name="persona_garante2_idNull">true if the method ignores the persona_garante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_GARANTE2_IDCommand(decimal persona_garante2_id, bool persona_garante2_idNull)
		{
			string whereSql = "";
			if(persona_garante2_idNull)
				whereSql += "PERSONA_GARANTE2_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_garante2_idNull)
				AddParameter(cmd, "PERSONA_GARANTE2_ID", persona_garante2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CREDITOSRow"/> objects 
		/// by the <c>FK_CREDITOS_TIPO_CREDITO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		public virtual CREDITOSRow[] GetByTIPO_CREDITO_ID(decimal tipo_credito_id)
		{
			return MapRecords(CreateGetByTIPO_CREDITO_IDCommand(tipo_credito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CREDITOS_TIPO_CREDITO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CREDITO_IDAsDataTable(decimal tipo_credito_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CREDITO_IDCommand(tipo_credito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CREDITOS_TIPO_CREDITO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CREDITO_IDCommand(decimal tipo_credito_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_CREDITO_ID", tipo_credito_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CREDITOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOSRow"/> object to be inserted.</param>
		public virtual void Insert(CREDITOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CREDITOS (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"PERSONA_GARANTE1_ID, " +
				"PERSONA_GARANTE2_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"FECHA_SOLICITUD, " +
				"FECHA_RETIRO, " +
				"SEPARACION_BIENES, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"TOTAL_INGRESOS, " +
				"TOTAL_EGRESOS, " +
				"OBSERVACION, " +
				"CANTIDAD_CUOTAS, " +
				"PORCENTAJE_INTERES, " +
				"PORCENTAJE_DIARIO_MORA, " +
				"PORCENTAJE_GASTO_ADMINIST, " +
				"MONTO_CAPITAL_APROBADO, " +
				"MONTO_INTERES, " +
				"MONTO_GASTO_ADMINISTRATIVO, " +
				"MONTO_CAPITAL_SOLICITADO, " +
				"MONTO_TOTAL, " +
				"TIPO_CREDITO_ID, " +
				"FACTURA_CLIENTE_ID, " +
				"FACTURA_CLIENTE_AUTON_ID, " +
				"FUNCIONARIO_ID, " +
				"NUMERO_SOLICITUD, " +
				"ORDENES_PAGO_ID, " +
				"CTACTE_CAJA_TESORERIA_ID, " +
				"ENTREGA_INICIAL, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"CASO_ASOCIADO_ID, " +
				"CON_RECURSO, " +
				"DESEMBOLSAR_PARA_CLIENTE, " +
				"INTERES_INCLUYE_IMPUESTO, " +
				"TIPO_FRECUENCIA, " +
				"FRECUENCIA, " +
				"ANHO_COMERCIAL, " +
				"FACTURAR_CONCEPTOS_EN_PAGOS, " +
				"AUMENTAR_CAPITAL_POR_DESCUENT, " +
				"ARTICULO_ID, " +
				"DIAS_GRACIA, " +
				"PORCENTAJE_SEGURO, " +
				"PORCENTAJE_CORRETAJE, " +
				"PORCENTAJE_COMISION_ADMIN, " +
				"PORCENTAJE_BONIFICACION, " +
				"MONTO_SEGURO, " +
				"MONTO_CORRETAJE, " +
				"MONTO_COMISION_ADMIN, " +
				"MONTO_BONIFICACION, " +
				"DESCUENTO_CANCELACION_ANTICIP, " +
				"ESTADO, " +
				"FECHA_PRIMER_VENCIMIENTO, " +
				"MONTO_REDONDEO, " +
				"TIPO_INTERES_ANUAL, " +
				"CONCEPTO_INCLUYE_IMPUESTO, " +
				"MONTO_CAPITAL_ORDEN_COMPRA, " +
				"FACTURAR_BONIFICACION_EN_PAGOS, " +
				"BONIFICACION_INCLUYE_IMPUESTO, " +
				"CTACTE_FONDO_FIJO_ID, " +
				"EGRESO_VARIO_CAJA_ID, " +
				"APROBACION_1, " +
				"APROBACION_1_USUARIO_ID, " +
				"APROBACION_1_FECHA, " +
				"APROBACION_2, " +
				"APROBACION_2_USUARIO_ID, " +
				"APROBACION_2_FECHA, " +
				"APROBACION_3, " +
				"APROBACION_3_USUARIO_ID, " +
				"APROBACION_3_FECHA, " +
				"CANAL_VENTA_ID, " +
				"FACTURAR_INTERESES, " +
				"PORCENTAJE_OTROS, " +
				"MONTO_OTROS, " +
				"INTERES_COMPUESTO, " +
				"AFECTA_LINEA_CREDITO, " +
				"FACTURAR_CAPITAL, " +
				"MONTO_DIARIO_MORA, " +
				"FECHA_CANCELACION_ANTICIPADA, " +
				"ACTIVO_ID, " +
				"DESCUENTO_CANC_ANT_APLICADO, " +
				"DESCUENTO_CANC_ANT_CANT_NO_VEN" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE1_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_GARANTE2_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA_SOLICITUD") + ", " +
				_db.CreateSqlParameterName("FECHA_RETIRO") + ", " +
				_db.CreateSqlParameterName("SEPARACION_BIENES") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("TOTAL_INGRESOS") + ", " +
				_db.CreateSqlParameterName("TOTAL_EGRESOS") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_INTERES") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DIARIO_MORA") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_GASTO_ADMINIST") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL_APROBADO") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				_db.CreateSqlParameterName("MONTO_GASTO_ADMINISTRATIVO") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL_SOLICITADO") + ", " +
				_db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				_db.CreateSqlParameterName("TIPO_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("FACTURA_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("FACTURA_CLIENTE_AUTON_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_SOLICITUD") + ", " +
				_db.CreateSqlParameterName("ORDENES_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("ENTREGA_INICIAL") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("CON_RECURSO") + ", " +
				_db.CreateSqlParameterName("DESEMBOLSAR_PARA_CLIENTE") + ", " +
				_db.CreateSqlParameterName("INTERES_INCLUYE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("TIPO_FRECUENCIA") + ", " +
				_db.CreateSqlParameterName("FRECUENCIA") + ", " +
				_db.CreateSqlParameterName("ANHO_COMERCIAL") + ", " +
				_db.CreateSqlParameterName("FACTURAR_CONCEPTOS_EN_PAGOS") + ", " +
				_db.CreateSqlParameterName("AUMENTAR_CAPITAL_POR_DESCUENT") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("DIAS_GRACIA") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_SEGURO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_CORRETAJE") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_COMISION_ADMIN") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_BONIFICACION") + ", " +
				_db.CreateSqlParameterName("MONTO_SEGURO") + ", " +
				_db.CreateSqlParameterName("MONTO_CORRETAJE") + ", " +
				_db.CreateSqlParameterName("MONTO_COMISION_ADMIN") + ", " +
				_db.CreateSqlParameterName("MONTO_BONIFICACION") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_CANCELACION_ANTICIP") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("FECHA_PRIMER_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("MONTO_REDONDEO") + ", " +
				_db.CreateSqlParameterName("TIPO_INTERES_ANUAL") + ", " +
				_db.CreateSqlParameterName("CONCEPTO_INCLUYE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL_ORDEN_COMPRA") + ", " +
				_db.CreateSqlParameterName("FACTURAR_BONIFICACION_EN_PAGOS") + ", " +
				_db.CreateSqlParameterName("BONIFICACION_INCLUYE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				_db.CreateSqlParameterName("APROBACION_1") + ", " +
				_db.CreateSqlParameterName("APROBACION_1_USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("APROBACION_1_FECHA") + ", " +
				_db.CreateSqlParameterName("APROBACION_2") + ", " +
				_db.CreateSqlParameterName("APROBACION_2_USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("APROBACION_2_FECHA") + ", " +
				_db.CreateSqlParameterName("APROBACION_3") + ", " +
				_db.CreateSqlParameterName("APROBACION_3_USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("APROBACION_3_FECHA") + ", " +
				_db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				_db.CreateSqlParameterName("FACTURAR_INTERESES") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_OTROS") + ", " +
				_db.CreateSqlParameterName("MONTO_OTROS") + ", " +
				_db.CreateSqlParameterName("INTERES_COMPUESTO") + ", " +
				_db.CreateSqlParameterName("AFECTA_LINEA_CREDITO") + ", " +
				_db.CreateSqlParameterName("FACTURAR_CAPITAL") + ", " +
				_db.CreateSqlParameterName("MONTO_DIARIO_MORA") + ", " +
				_db.CreateSqlParameterName("FECHA_CANCELACION_ANTICIPADA") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_CANC_ANT_APLICADO") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_CANC_ANT_CANT_NO_VEN") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "PERSONA_GARANTE1_ID",
				value.IsPERSONA_GARANTE1_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE1_ID);
			AddParameter(cmd, "PERSONA_GARANTE2_ID",
				value.IsPERSONA_GARANTE2_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE2_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_SOLICITUD", value.FECHA_SOLICITUD);
			AddParameter(cmd, "FECHA_RETIRO",
				value.IsFECHA_RETIRONull ? DBNull.Value : (object)value.FECHA_RETIRO);
			AddParameter(cmd, "SEPARACION_BIENES", value.SEPARACION_BIENES);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "TOTAL_INGRESOS",
				value.IsTOTAL_INGRESOSNull ? DBNull.Value : (object)value.TOTAL_INGRESOS);
			AddParameter(cmd, "TOTAL_EGRESOS",
				value.IsTOTAL_EGRESOSNull ? DBNull.Value : (object)value.TOTAL_EGRESOS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "PORCENTAJE_INTERES",
				value.IsPORCENTAJE_INTERESNull ? DBNull.Value : (object)value.PORCENTAJE_INTERES);
			AddParameter(cmd, "PORCENTAJE_DIARIO_MORA",
				value.IsPORCENTAJE_DIARIO_MORANull ? DBNull.Value : (object)value.PORCENTAJE_DIARIO_MORA);
			AddParameter(cmd, "PORCENTAJE_GASTO_ADMINIST",
				value.IsPORCENTAJE_GASTO_ADMINISTNull ? DBNull.Value : (object)value.PORCENTAJE_GASTO_ADMINIST);
			AddParameter(cmd, "MONTO_CAPITAL_APROBADO", value.MONTO_CAPITAL_APROBADO);
			AddParameter(cmd, "MONTO_INTERES",
				value.IsMONTO_INTERESNull ? DBNull.Value : (object)value.MONTO_INTERES);
			AddParameter(cmd, "MONTO_GASTO_ADMINISTRATIVO",
				value.IsMONTO_GASTO_ADMINISTRATIVONull ? DBNull.Value : (object)value.MONTO_GASTO_ADMINISTRATIVO);
			AddParameter(cmd, "MONTO_CAPITAL_SOLICITADO", value.MONTO_CAPITAL_SOLICITADO);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "TIPO_CREDITO_ID", value.TIPO_CREDITO_ID);
			AddParameter(cmd, "FACTURA_CLIENTE_ID",
				value.IsFACTURA_CLIENTE_IDNull ? DBNull.Value : (object)value.FACTURA_CLIENTE_ID);
			AddParameter(cmd, "FACTURA_CLIENTE_AUTON_ID",
				value.IsFACTURA_CLIENTE_AUTON_IDNull ? DBNull.Value : (object)value.FACTURA_CLIENTE_AUTON_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "NUMERO_SOLICITUD", value.NUMERO_SOLICITUD);
			AddParameter(cmd, "ORDENES_PAGO_ID",
				value.IsORDENES_PAGO_IDNull ? DBNull.Value : (object)value.ORDENES_PAGO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "ENTREGA_INICIAL", value.ENTREGA_INICIAL);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "CON_RECURSO", value.CON_RECURSO);
			AddParameter(cmd, "DESEMBOLSAR_PARA_CLIENTE", value.DESEMBOLSAR_PARA_CLIENTE);
			AddParameter(cmd, "INTERES_INCLUYE_IMPUESTO", value.INTERES_INCLUYE_IMPUESTO);
			AddParameter(cmd, "TIPO_FRECUENCIA", value.TIPO_FRECUENCIA);
			AddParameter(cmd, "FRECUENCIA", value.FRECUENCIA);
			AddParameter(cmd, "ANHO_COMERCIAL", value.ANHO_COMERCIAL);
			AddParameter(cmd, "FACTURAR_CONCEPTOS_EN_PAGOS", value.FACTURAR_CONCEPTOS_EN_PAGOS);
			AddParameter(cmd, "AUMENTAR_CAPITAL_POR_DESCUENT", value.AUMENTAR_CAPITAL_POR_DESCUENT);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "DIAS_GRACIA", value.DIAS_GRACIA);
			AddParameter(cmd, "PORCENTAJE_SEGURO",
				value.IsPORCENTAJE_SEGURONull ? DBNull.Value : (object)value.PORCENTAJE_SEGURO);
			AddParameter(cmd, "PORCENTAJE_CORRETAJE",
				value.IsPORCENTAJE_CORRETAJENull ? DBNull.Value : (object)value.PORCENTAJE_CORRETAJE);
			AddParameter(cmd, "PORCENTAJE_COMISION_ADMIN",
				value.IsPORCENTAJE_COMISION_ADMINNull ? DBNull.Value : (object)value.PORCENTAJE_COMISION_ADMIN);
			AddParameter(cmd, "PORCENTAJE_BONIFICACION",
				value.IsPORCENTAJE_BONIFICACIONNull ? DBNull.Value : (object)value.PORCENTAJE_BONIFICACION);
			AddParameter(cmd, "MONTO_SEGURO",
				value.IsMONTO_SEGURONull ? DBNull.Value : (object)value.MONTO_SEGURO);
			AddParameter(cmd, "MONTO_CORRETAJE",
				value.IsMONTO_CORRETAJENull ? DBNull.Value : (object)value.MONTO_CORRETAJE);
			AddParameter(cmd, "MONTO_COMISION_ADMIN",
				value.IsMONTO_COMISION_ADMINNull ? DBNull.Value : (object)value.MONTO_COMISION_ADMIN);
			AddParameter(cmd, "MONTO_BONIFICACION",
				value.IsMONTO_BONIFICACIONNull ? DBNull.Value : (object)value.MONTO_BONIFICACION);
			AddParameter(cmd, "DESCUENTO_CANCELACION_ANTICIP", value.DESCUENTO_CANCELACION_ANTICIP);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FECHA_PRIMER_VENCIMIENTO", value.FECHA_PRIMER_VENCIMIENTO);
			AddParameter(cmd, "MONTO_REDONDEO", value.MONTO_REDONDEO);
			AddParameter(cmd, "TIPO_INTERES_ANUAL", value.TIPO_INTERES_ANUAL);
			AddParameter(cmd, "CONCEPTO_INCLUYE_IMPUESTO", value.CONCEPTO_INCLUYE_IMPUESTO);
			AddParameter(cmd, "MONTO_CAPITAL_ORDEN_COMPRA", value.MONTO_CAPITAL_ORDEN_COMPRA);
			AddParameter(cmd, "FACTURAR_BONIFICACION_EN_PAGOS", value.FACTURAR_BONIFICACION_EN_PAGOS);
			AddParameter(cmd, "BONIFICACION_INCLUYE_IMPUESTO", value.BONIFICACION_INCLUYE_IMPUESTO);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "APROBACION_1", value.APROBACION_1);
			AddParameter(cmd, "APROBACION_1_USUARIO_ID",
				value.IsAPROBACION_1_USUARIO_IDNull ? DBNull.Value : (object)value.APROBACION_1_USUARIO_ID);
			AddParameter(cmd, "APROBACION_1_FECHA",
				value.IsAPROBACION_1_FECHANull ? DBNull.Value : (object)value.APROBACION_1_FECHA);
			AddParameter(cmd, "APROBACION_2", value.APROBACION_2);
			AddParameter(cmd, "APROBACION_2_USUARIO_ID",
				value.IsAPROBACION_2_USUARIO_IDNull ? DBNull.Value : (object)value.APROBACION_2_USUARIO_ID);
			AddParameter(cmd, "APROBACION_2_FECHA",
				value.IsAPROBACION_2_FECHANull ? DBNull.Value : (object)value.APROBACION_2_FECHA);
			AddParameter(cmd, "APROBACION_3", value.APROBACION_3);
			AddParameter(cmd, "APROBACION_3_USUARIO_ID",
				value.IsAPROBACION_3_USUARIO_IDNull ? DBNull.Value : (object)value.APROBACION_3_USUARIO_ID);
			AddParameter(cmd, "APROBACION_3_FECHA",
				value.IsAPROBACION_3_FECHANull ? DBNull.Value : (object)value.APROBACION_3_FECHA);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "FACTURAR_INTERESES", value.FACTURAR_INTERESES);
			AddParameter(cmd, "PORCENTAJE_OTROS",
				value.IsPORCENTAJE_OTROSNull ? DBNull.Value : (object)value.PORCENTAJE_OTROS);
			AddParameter(cmd, "MONTO_OTROS",
				value.IsMONTO_OTROSNull ? DBNull.Value : (object)value.MONTO_OTROS);
			AddParameter(cmd, "INTERES_COMPUESTO", value.INTERES_COMPUESTO);
			AddParameter(cmd, "AFECTA_LINEA_CREDITO", value.AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "FACTURAR_CAPITAL", value.FACTURAR_CAPITAL);
			AddParameter(cmd, "MONTO_DIARIO_MORA",
				value.IsMONTO_DIARIO_MORANull ? DBNull.Value : (object)value.MONTO_DIARIO_MORA);
			AddParameter(cmd, "FECHA_CANCELACION_ANTICIPADA",
				value.IsFECHA_CANCELACION_ANTICIPADANull ? DBNull.Value : (object)value.FECHA_CANCELACION_ANTICIPADA);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "DESCUENTO_CANC_ANT_APLICADO", value.DESCUENTO_CANC_ANT_APLICADO);
			AddParameter(cmd, "DESCUENTO_CANC_ANT_CANT_NO_VEN", value.DESCUENTO_CANC_ANT_CANT_NO_VEN);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CREDITOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CREDITOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CREDITOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"PERSONA_GARANTE1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE1_ID") + ", " +
				"PERSONA_GARANTE2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE2_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA_SOLICITUD=" + _db.CreateSqlParameterName("FECHA_SOLICITUD") + ", " +
				"FECHA_RETIRO=" + _db.CreateSqlParameterName("FECHA_RETIRO") + ", " +
				"SEPARACION_BIENES=" + _db.CreateSqlParameterName("SEPARACION_BIENES") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"TOTAL_INGRESOS=" + _db.CreateSqlParameterName("TOTAL_INGRESOS") + ", " +
				"TOTAL_EGRESOS=" + _db.CreateSqlParameterName("TOTAL_EGRESOS") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CANTIDAD_CUOTAS=" + _db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				"PORCENTAJE_INTERES=" + _db.CreateSqlParameterName("PORCENTAJE_INTERES") + ", " +
				"PORCENTAJE_DIARIO_MORA=" + _db.CreateSqlParameterName("PORCENTAJE_DIARIO_MORA") + ", " +
				"PORCENTAJE_GASTO_ADMINIST=" + _db.CreateSqlParameterName("PORCENTAJE_GASTO_ADMINIST") + ", " +
				"MONTO_CAPITAL_APROBADO=" + _db.CreateSqlParameterName("MONTO_CAPITAL_APROBADO") + ", " +
				"MONTO_INTERES=" + _db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				"MONTO_GASTO_ADMINISTRATIVO=" + _db.CreateSqlParameterName("MONTO_GASTO_ADMINISTRATIVO") + ", " +
				"MONTO_CAPITAL_SOLICITADO=" + _db.CreateSqlParameterName("MONTO_CAPITAL_SOLICITADO") + ", " +
				"MONTO_TOTAL=" + _db.CreateSqlParameterName("MONTO_TOTAL") + ", " +
				"TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID") + ", " +
				"FACTURA_CLIENTE_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_ID") + ", " +
				"FACTURA_CLIENTE_AUTON_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_AUTON_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"NUMERO_SOLICITUD=" + _db.CreateSqlParameterName("NUMERO_SOLICITUD") + ", " +
				"ORDENES_PAGO_ID=" + _db.CreateSqlParameterName("ORDENES_PAGO_ID") + ", " +
				"CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				"ENTREGA_INICIAL=" + _db.CreateSqlParameterName("ENTREGA_INICIAL") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"CON_RECURSO=" + _db.CreateSqlParameterName("CON_RECURSO") + ", " +
				"DESEMBOLSAR_PARA_CLIENTE=" + _db.CreateSqlParameterName("DESEMBOLSAR_PARA_CLIENTE") + ", " +
				"INTERES_INCLUYE_IMPUESTO=" + _db.CreateSqlParameterName("INTERES_INCLUYE_IMPUESTO") + ", " +
				"TIPO_FRECUENCIA=" + _db.CreateSqlParameterName("TIPO_FRECUENCIA") + ", " +
				"FRECUENCIA=" + _db.CreateSqlParameterName("FRECUENCIA") + ", " +
				"ANHO_COMERCIAL=" + _db.CreateSqlParameterName("ANHO_COMERCIAL") + ", " +
				"FACTURAR_CONCEPTOS_EN_PAGOS=" + _db.CreateSqlParameterName("FACTURAR_CONCEPTOS_EN_PAGOS") + ", " +
				"AUMENTAR_CAPITAL_POR_DESCUENT=" + _db.CreateSqlParameterName("AUMENTAR_CAPITAL_POR_DESCUENT") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"DIAS_GRACIA=" + _db.CreateSqlParameterName("DIAS_GRACIA") + ", " +
				"PORCENTAJE_SEGURO=" + _db.CreateSqlParameterName("PORCENTAJE_SEGURO") + ", " +
				"PORCENTAJE_CORRETAJE=" + _db.CreateSqlParameterName("PORCENTAJE_CORRETAJE") + ", " +
				"PORCENTAJE_COMISION_ADMIN=" + _db.CreateSqlParameterName("PORCENTAJE_COMISION_ADMIN") + ", " +
				"PORCENTAJE_BONIFICACION=" + _db.CreateSqlParameterName("PORCENTAJE_BONIFICACION") + ", " +
				"MONTO_SEGURO=" + _db.CreateSqlParameterName("MONTO_SEGURO") + ", " +
				"MONTO_CORRETAJE=" + _db.CreateSqlParameterName("MONTO_CORRETAJE") + ", " +
				"MONTO_COMISION_ADMIN=" + _db.CreateSqlParameterName("MONTO_COMISION_ADMIN") + ", " +
				"MONTO_BONIFICACION=" + _db.CreateSqlParameterName("MONTO_BONIFICACION") + ", " +
				"DESCUENTO_CANCELACION_ANTICIP=" + _db.CreateSqlParameterName("DESCUENTO_CANCELACION_ANTICIP") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"FECHA_PRIMER_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_PRIMER_VENCIMIENTO") + ", " +
				"MONTO_REDONDEO=" + _db.CreateSqlParameterName("MONTO_REDONDEO") + ", " +
				"TIPO_INTERES_ANUAL=" + _db.CreateSqlParameterName("TIPO_INTERES_ANUAL") + ", " +
				"CONCEPTO_INCLUYE_IMPUESTO=" + _db.CreateSqlParameterName("CONCEPTO_INCLUYE_IMPUESTO") + ", " +
				"MONTO_CAPITAL_ORDEN_COMPRA=" + _db.CreateSqlParameterName("MONTO_CAPITAL_ORDEN_COMPRA") + ", " +
				"FACTURAR_BONIFICACION_EN_PAGOS=" + _db.CreateSqlParameterName("FACTURAR_BONIFICACION_EN_PAGOS") + ", " +
				"BONIFICACION_INCLUYE_IMPUESTO=" + _db.CreateSqlParameterName("BONIFICACION_INCLUYE_IMPUESTO") + ", " +
				"CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				"EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				"APROBACION_1=" + _db.CreateSqlParameterName("APROBACION_1") + ", " +
				"APROBACION_1_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_1_USUARIO_ID") + ", " +
				"APROBACION_1_FECHA=" + _db.CreateSqlParameterName("APROBACION_1_FECHA") + ", " +
				"APROBACION_2=" + _db.CreateSqlParameterName("APROBACION_2") + ", " +
				"APROBACION_2_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_2_USUARIO_ID") + ", " +
				"APROBACION_2_FECHA=" + _db.CreateSqlParameterName("APROBACION_2_FECHA") + ", " +
				"APROBACION_3=" + _db.CreateSqlParameterName("APROBACION_3") + ", " +
				"APROBACION_3_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_3_USUARIO_ID") + ", " +
				"APROBACION_3_FECHA=" + _db.CreateSqlParameterName("APROBACION_3_FECHA") + ", " +
				"CANAL_VENTA_ID=" + _db.CreateSqlParameterName("CANAL_VENTA_ID") + ", " +
				"FACTURAR_INTERESES=" + _db.CreateSqlParameterName("FACTURAR_INTERESES") + ", " +
				"PORCENTAJE_OTROS=" + _db.CreateSqlParameterName("PORCENTAJE_OTROS") + ", " +
				"MONTO_OTROS=" + _db.CreateSqlParameterName("MONTO_OTROS") + ", " +
				"INTERES_COMPUESTO=" + _db.CreateSqlParameterName("INTERES_COMPUESTO") + ", " +
				"AFECTA_LINEA_CREDITO=" + _db.CreateSqlParameterName("AFECTA_LINEA_CREDITO") + ", " +
				"FACTURAR_CAPITAL=" + _db.CreateSqlParameterName("FACTURAR_CAPITAL") + ", " +
				"MONTO_DIARIO_MORA=" + _db.CreateSqlParameterName("MONTO_DIARIO_MORA") + ", " +
				"FECHA_CANCELACION_ANTICIPADA=" + _db.CreateSqlParameterName("FECHA_CANCELACION_ANTICIPADA") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"DESCUENTO_CANC_ANT_APLICADO=" + _db.CreateSqlParameterName("DESCUENTO_CANC_ANT_APLICADO") + ", " +
				"DESCUENTO_CANC_ANT_CANT_NO_VEN=" + _db.CreateSqlParameterName("DESCUENTO_CANC_ANT_CANT_NO_VEN") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "PERSONA_GARANTE1_ID",
				value.IsPERSONA_GARANTE1_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE1_ID);
			AddParameter(cmd, "PERSONA_GARANTE2_ID",
				value.IsPERSONA_GARANTE2_IDNull ? DBNull.Value : (object)value.PERSONA_GARANTE2_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_SOLICITUD", value.FECHA_SOLICITUD);
			AddParameter(cmd, "FECHA_RETIRO",
				value.IsFECHA_RETIRONull ? DBNull.Value : (object)value.FECHA_RETIRO);
			AddParameter(cmd, "SEPARACION_BIENES", value.SEPARACION_BIENES);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "TOTAL_INGRESOS",
				value.IsTOTAL_INGRESOSNull ? DBNull.Value : (object)value.TOTAL_INGRESOS);
			AddParameter(cmd, "TOTAL_EGRESOS",
				value.IsTOTAL_EGRESOSNull ? DBNull.Value : (object)value.TOTAL_EGRESOS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "PORCENTAJE_INTERES",
				value.IsPORCENTAJE_INTERESNull ? DBNull.Value : (object)value.PORCENTAJE_INTERES);
			AddParameter(cmd, "PORCENTAJE_DIARIO_MORA",
				value.IsPORCENTAJE_DIARIO_MORANull ? DBNull.Value : (object)value.PORCENTAJE_DIARIO_MORA);
			AddParameter(cmd, "PORCENTAJE_GASTO_ADMINIST",
				value.IsPORCENTAJE_GASTO_ADMINISTNull ? DBNull.Value : (object)value.PORCENTAJE_GASTO_ADMINIST);
			AddParameter(cmd, "MONTO_CAPITAL_APROBADO", value.MONTO_CAPITAL_APROBADO);
			AddParameter(cmd, "MONTO_INTERES",
				value.IsMONTO_INTERESNull ? DBNull.Value : (object)value.MONTO_INTERES);
			AddParameter(cmd, "MONTO_GASTO_ADMINISTRATIVO",
				value.IsMONTO_GASTO_ADMINISTRATIVONull ? DBNull.Value : (object)value.MONTO_GASTO_ADMINISTRATIVO);
			AddParameter(cmd, "MONTO_CAPITAL_SOLICITADO", value.MONTO_CAPITAL_SOLICITADO);
			AddParameter(cmd, "MONTO_TOTAL", value.MONTO_TOTAL);
			AddParameter(cmd, "TIPO_CREDITO_ID", value.TIPO_CREDITO_ID);
			AddParameter(cmd, "FACTURA_CLIENTE_ID",
				value.IsFACTURA_CLIENTE_IDNull ? DBNull.Value : (object)value.FACTURA_CLIENTE_ID);
			AddParameter(cmd, "FACTURA_CLIENTE_AUTON_ID",
				value.IsFACTURA_CLIENTE_AUTON_IDNull ? DBNull.Value : (object)value.FACTURA_CLIENTE_AUTON_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "NUMERO_SOLICITUD", value.NUMERO_SOLICITUD);
			AddParameter(cmd, "ORDENES_PAGO_ID",
				value.IsORDENES_PAGO_IDNull ? DBNull.Value : (object)value.ORDENES_PAGO_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "ENTREGA_INICIAL", value.ENTREGA_INICIAL);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "CON_RECURSO", value.CON_RECURSO);
			AddParameter(cmd, "DESEMBOLSAR_PARA_CLIENTE", value.DESEMBOLSAR_PARA_CLIENTE);
			AddParameter(cmd, "INTERES_INCLUYE_IMPUESTO", value.INTERES_INCLUYE_IMPUESTO);
			AddParameter(cmd, "TIPO_FRECUENCIA", value.TIPO_FRECUENCIA);
			AddParameter(cmd, "FRECUENCIA", value.FRECUENCIA);
			AddParameter(cmd, "ANHO_COMERCIAL", value.ANHO_COMERCIAL);
			AddParameter(cmd, "FACTURAR_CONCEPTOS_EN_PAGOS", value.FACTURAR_CONCEPTOS_EN_PAGOS);
			AddParameter(cmd, "AUMENTAR_CAPITAL_POR_DESCUENT", value.AUMENTAR_CAPITAL_POR_DESCUENT);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "DIAS_GRACIA", value.DIAS_GRACIA);
			AddParameter(cmd, "PORCENTAJE_SEGURO",
				value.IsPORCENTAJE_SEGURONull ? DBNull.Value : (object)value.PORCENTAJE_SEGURO);
			AddParameter(cmd, "PORCENTAJE_CORRETAJE",
				value.IsPORCENTAJE_CORRETAJENull ? DBNull.Value : (object)value.PORCENTAJE_CORRETAJE);
			AddParameter(cmd, "PORCENTAJE_COMISION_ADMIN",
				value.IsPORCENTAJE_COMISION_ADMINNull ? DBNull.Value : (object)value.PORCENTAJE_COMISION_ADMIN);
			AddParameter(cmd, "PORCENTAJE_BONIFICACION",
				value.IsPORCENTAJE_BONIFICACIONNull ? DBNull.Value : (object)value.PORCENTAJE_BONIFICACION);
			AddParameter(cmd, "MONTO_SEGURO",
				value.IsMONTO_SEGURONull ? DBNull.Value : (object)value.MONTO_SEGURO);
			AddParameter(cmd, "MONTO_CORRETAJE",
				value.IsMONTO_CORRETAJENull ? DBNull.Value : (object)value.MONTO_CORRETAJE);
			AddParameter(cmd, "MONTO_COMISION_ADMIN",
				value.IsMONTO_COMISION_ADMINNull ? DBNull.Value : (object)value.MONTO_COMISION_ADMIN);
			AddParameter(cmd, "MONTO_BONIFICACION",
				value.IsMONTO_BONIFICACIONNull ? DBNull.Value : (object)value.MONTO_BONIFICACION);
			AddParameter(cmd, "DESCUENTO_CANCELACION_ANTICIP", value.DESCUENTO_CANCELACION_ANTICIP);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FECHA_PRIMER_VENCIMIENTO", value.FECHA_PRIMER_VENCIMIENTO);
			AddParameter(cmd, "MONTO_REDONDEO", value.MONTO_REDONDEO);
			AddParameter(cmd, "TIPO_INTERES_ANUAL", value.TIPO_INTERES_ANUAL);
			AddParameter(cmd, "CONCEPTO_INCLUYE_IMPUESTO", value.CONCEPTO_INCLUYE_IMPUESTO);
			AddParameter(cmd, "MONTO_CAPITAL_ORDEN_COMPRA", value.MONTO_CAPITAL_ORDEN_COMPRA);
			AddParameter(cmd, "FACTURAR_BONIFICACION_EN_PAGOS", value.FACTURAR_BONIFICACION_EN_PAGOS);
			AddParameter(cmd, "BONIFICACION_INCLUYE_IMPUESTO", value.BONIFICACION_INCLUYE_IMPUESTO);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "APROBACION_1", value.APROBACION_1);
			AddParameter(cmd, "APROBACION_1_USUARIO_ID",
				value.IsAPROBACION_1_USUARIO_IDNull ? DBNull.Value : (object)value.APROBACION_1_USUARIO_ID);
			AddParameter(cmd, "APROBACION_1_FECHA",
				value.IsAPROBACION_1_FECHANull ? DBNull.Value : (object)value.APROBACION_1_FECHA);
			AddParameter(cmd, "APROBACION_2", value.APROBACION_2);
			AddParameter(cmd, "APROBACION_2_USUARIO_ID",
				value.IsAPROBACION_2_USUARIO_IDNull ? DBNull.Value : (object)value.APROBACION_2_USUARIO_ID);
			AddParameter(cmd, "APROBACION_2_FECHA",
				value.IsAPROBACION_2_FECHANull ? DBNull.Value : (object)value.APROBACION_2_FECHA);
			AddParameter(cmd, "APROBACION_3", value.APROBACION_3);
			AddParameter(cmd, "APROBACION_3_USUARIO_ID",
				value.IsAPROBACION_3_USUARIO_IDNull ? DBNull.Value : (object)value.APROBACION_3_USUARIO_ID);
			AddParameter(cmd, "APROBACION_3_FECHA",
				value.IsAPROBACION_3_FECHANull ? DBNull.Value : (object)value.APROBACION_3_FECHA);
			AddParameter(cmd, "CANAL_VENTA_ID",
				value.IsCANAL_VENTA_IDNull ? DBNull.Value : (object)value.CANAL_VENTA_ID);
			AddParameter(cmd, "FACTURAR_INTERESES", value.FACTURAR_INTERESES);
			AddParameter(cmd, "PORCENTAJE_OTROS",
				value.IsPORCENTAJE_OTROSNull ? DBNull.Value : (object)value.PORCENTAJE_OTROS);
			AddParameter(cmd, "MONTO_OTROS",
				value.IsMONTO_OTROSNull ? DBNull.Value : (object)value.MONTO_OTROS);
			AddParameter(cmd, "INTERES_COMPUESTO", value.INTERES_COMPUESTO);
			AddParameter(cmd, "AFECTA_LINEA_CREDITO", value.AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "FACTURAR_CAPITAL", value.FACTURAR_CAPITAL);
			AddParameter(cmd, "MONTO_DIARIO_MORA",
				value.IsMONTO_DIARIO_MORANull ? DBNull.Value : (object)value.MONTO_DIARIO_MORA);
			AddParameter(cmd, "FECHA_CANCELACION_ANTICIPADA",
				value.IsFECHA_CANCELACION_ANTICIPADANull ? DBNull.Value : (object)value.FECHA_CANCELACION_ANTICIPADA);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "DESCUENTO_CANC_ANT_APLICADO", value.DESCUENTO_CANC_ANT_APLICADO);
			AddParameter(cmd, "DESCUENTO_CANC_ANT_CANT_NO_VEN", value.DESCUENTO_CANC_ANT_CANT_NO_VEN);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CREDITOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CREDITOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CREDITOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CREDITOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CREDITOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CREDITOS</c> table using
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
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return CreateDeleteByACTIVO_IDCommand(activo_id, activo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPROBACION_1_USUARIO_ID(decimal aprobacion_1_usuario_id)
		{
			return DeleteByAPROBACION_1_USUARIO_ID(aprobacion_1_usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_1_usuario_idNull">true if the method ignores the aprobacion_1_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPROBACION_1_USUARIO_ID(decimal aprobacion_1_usuario_id, bool aprobacion_1_usuario_idNull)
		{
			return CreateDeleteByAPROBACION_1_USUARIO_IDCommand(aprobacion_1_usuario_id, aprobacion_1_usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_AP1_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_1_usuario_id">The <c>APROBACION_1_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_1_usuario_idNull">true if the method ignores the aprobacion_1_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPROBACION_1_USUARIO_IDCommand(decimal aprobacion_1_usuario_id, bool aprobacion_1_usuario_idNull)
		{
			string whereSql = "";
			if(aprobacion_1_usuario_idNull)
				whereSql += "APROBACION_1_USUARIO_ID IS NULL";
			else
				whereSql += "APROBACION_1_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_1_USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aprobacion_1_usuario_idNull)
				AddParameter(cmd, "APROBACION_1_USUARIO_ID", aprobacion_1_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPROBACION_2_USUARIO_ID(decimal aprobacion_2_usuario_id)
		{
			return DeleteByAPROBACION_2_USUARIO_ID(aprobacion_2_usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_2_usuario_idNull">true if the method ignores the aprobacion_2_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPROBACION_2_USUARIO_ID(decimal aprobacion_2_usuario_id, bool aprobacion_2_usuario_idNull)
		{
			return CreateDeleteByAPROBACION_2_USUARIO_IDCommand(aprobacion_2_usuario_id, aprobacion_2_usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_AP2_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_2_usuario_id">The <c>APROBACION_2_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_2_usuario_idNull">true if the method ignores the aprobacion_2_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPROBACION_2_USUARIO_IDCommand(decimal aprobacion_2_usuario_id, bool aprobacion_2_usuario_idNull)
		{
			string whereSql = "";
			if(aprobacion_2_usuario_idNull)
				whereSql += "APROBACION_2_USUARIO_ID IS NULL";
			else
				whereSql += "APROBACION_2_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_2_USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aprobacion_2_usuario_idNull)
				AddParameter(cmd, "APROBACION_2_USUARIO_ID", aprobacion_2_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPROBACION_3_USUARIO_ID(decimal aprobacion_3_usuario_id)
		{
			return DeleteByAPROBACION_3_USUARIO_ID(aprobacion_3_usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_3_usuario_idNull">true if the method ignores the aprobacion_3_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPROBACION_3_USUARIO_ID(decimal aprobacion_3_usuario_id, bool aprobacion_3_usuario_idNull)
		{
			return CreateDeleteByAPROBACION_3_USUARIO_IDCommand(aprobacion_3_usuario_id, aprobacion_3_usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_AP3_USUARIO</c> foreign key.
		/// </summary>
		/// <param name="aprobacion_3_usuario_id">The <c>APROBACION_3_USUARIO_ID</c> column value.</param>
		/// <param name="aprobacion_3_usuario_idNull">true if the method ignores the aprobacion_3_usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPROBACION_3_USUARIO_IDCommand(decimal aprobacion_3_usuario_id, bool aprobacion_3_usuario_idNull)
		{
			string whereSql = "";
			if(aprobacion_3_usuario_idNull)
				whereSql += "APROBACION_3_USUARIO_ID IS NULL";
			else
				whereSql += "APROBACION_3_USUARIO_ID=" + _db.CreateSqlParameterName("APROBACION_3_USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aprobacion_3_usuario_idNull)
				AddParameter(cmd, "APROBACION_3_USUARIO_ID", aprobacion_3_usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_AUTONUMERACION_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
		/// </summary>
		/// <param name="canal_venta_id">The <c>CANAL_VENTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCANAL_VENTA_ID(decimal canal_venta_id)
		{
			return DeleteByCANAL_VENTA_ID(canal_venta_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
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
		/// delete records using the <c>FK_CREDITOS_CANAL_VENTA</c> foreign key.
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
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_CASO_ASOCIADO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
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
		/// delete records using the <c>FK_CREDITOS_CTACTE_CAJA_SUC_ID</c> foreign key.
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
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return DeleteByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_CTACTE_CAJA_TES_ID</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_tesoreria_idNull)
				whereSql += "CTACTE_CAJA_TESORERIA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_tesoreria_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return DeleteByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_CTACTE_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return DeleteByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_EGRESO_VARIO_CAJA</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_CLIENTE_ID(decimal factura_cliente_id)
		{
			return DeleteByFACTURA_CLIENTE_ID(factura_cliente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <param name="factura_cliente_idNull">true if the method ignores the factura_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_CLIENTE_ID(decimal factura_cliente_id, bool factura_cliente_idNull)
		{
			return CreateDeleteByFACTURA_CLIENTE_IDCommand(factura_cliente_id, factura_cliente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_FC_CLIENTE</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_id">The <c>FACTURA_CLIENTE_ID</c> column value.</param>
		/// <param name="factura_cliente_idNull">true if the method ignores the factura_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFACTURA_CLIENTE_IDCommand(decimal factura_cliente_id, bool factura_cliente_idNull)
		{
			string whereSql = "";
			if(factura_cliente_idNull)
				whereSql += "FACTURA_CLIENTE_ID IS NULL";
			else
				whereSql += "FACTURA_CLIENTE_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!factura_cliente_idNull)
				AddParameter(cmd, "FACTURA_CLIENTE_ID", factura_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_CLIENTE_AUTON_ID(decimal factura_cliente_auton_id)
		{
			return DeleteByFACTURA_CLIENTE_AUTON_ID(factura_cliente_auton_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <param name="factura_cliente_auton_idNull">true if the method ignores the factura_cliente_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURA_CLIENTE_AUTON_ID(decimal factura_cliente_auton_id, bool factura_cliente_auton_idNull)
		{
			return CreateDeleteByFACTURA_CLIENTE_AUTON_IDCommand(factura_cliente_auton_id, factura_cliente_auton_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_FC_CLIENTE_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="factura_cliente_auton_id">The <c>FACTURA_CLIENTE_AUTON_ID</c> column value.</param>
		/// <param name="factura_cliente_auton_idNull">true if the method ignores the factura_cliente_auton_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFACTURA_CLIENTE_AUTON_IDCommand(decimal factura_cliente_auton_id, bool factura_cliente_auton_idNull)
		{
			string whereSql = "";
			if(factura_cliente_auton_idNull)
				whereSql += "FACTURA_CLIENTE_AUTON_ID IS NULL";
			else
				whereSql += "FACTURA_CLIENTE_AUTON_ID=" + _db.CreateSqlParameterName("FACTURA_CLIENTE_AUTON_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!factura_cliente_auton_idNull)
				AddParameter(cmd, "FACTURA_CLIENTE_AUTON_ID", factura_cliente_auton_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_FUNCIONARIO_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_MONEDA_ID</c> foreign key.
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
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDENES_PAGO_ID(decimal ordenes_pago_id)
		{
			return DeleteByORDENES_PAGO_ID(ordenes_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <param name="ordenes_pago_idNull">true if the method ignores the ordenes_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDENES_PAGO_ID(decimal ordenes_pago_id, bool ordenes_pago_idNull)
		{
			return CreateDeleteByORDENES_PAGO_IDCommand(ordenes_pago_id, ordenes_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_ORDENES_PAGO_ID</c> foreign key.
		/// </summary>
		/// <param name="ordenes_pago_id">The <c>ORDENES_PAGO_ID</c> column value.</param>
		/// <param name="ordenes_pago_idNull">true if the method ignores the ordenes_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDENES_PAGO_IDCommand(decimal ordenes_pago_id, bool ordenes_pago_idNull)
		{
			string whereSql = "";
			if(ordenes_pago_idNull)
				whereSql += "ORDENES_PAGO_ID IS NULL";
			else
				whereSql += "ORDENES_PAGO_ID=" + _db.CreateSqlParameterName("ORDENES_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ordenes_pago_idNull)
				AddParameter(cmd, "ORDENES_PAGO_ID", ordenes_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE1_ID(decimal persona_garante1_id)
		{
			return DeleteByPERSONA_GARANTE1_ID(persona_garante1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <param name="persona_garante1_idNull">true if the method ignores the persona_garante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE1_ID(decimal persona_garante1_id, bool persona_garante1_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE1_IDCommand(persona_garante1_id, persona_garante1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PERSONA_GAR1_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante1_id">The <c>PERSONA_GARANTE1_ID</c> column value.</param>
		/// <param name="persona_garante1_idNull">true if the method ignores the persona_garante1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE1_IDCommand(decimal persona_garante1_id, bool persona_garante1_idNull)
		{
			string whereSql = "";
			if(persona_garante1_idNull)
				whereSql += "PERSONA_GARANTE1_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE1_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante1_idNull)
				AddParameter(cmd, "PERSONA_GARANTE1_ID", persona_garante1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE2_ID(decimal persona_garante2_id)
		{
			return DeleteByPERSONA_GARANTE2_ID(persona_garante2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <param name="persona_garante2_idNull">true if the method ignores the persona_garante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_GARANTE2_ID(decimal persona_garante2_id, bool persona_garante2_idNull)
		{
			return CreateDeleteByPERSONA_GARANTE2_IDCommand(persona_garante2_id, persona_garante2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PERSONA_GAR2_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_garante2_id">The <c>PERSONA_GARANTE2_ID</c> column value.</param>
		/// <param name="persona_garante2_idNull">true if the method ignores the persona_garante2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_GARANTE2_IDCommand(decimal persona_garante2_id, bool persona_garante2_idNull)
		{
			string whereSql = "";
			if(persona_garante2_idNull)
				whereSql += "PERSONA_GARANTE2_ID IS NULL";
			else
				whereSql += "PERSONA_GARANTE2_ID=" + _db.CreateSqlParameterName("PERSONA_GARANTE2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_garante2_idNull)
				AddParameter(cmd, "PERSONA_GARANTE2_ID", persona_garante2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_SUCURSAL_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CREDITOS</c> table using the 
		/// <c>FK_CREDITOS_TIPO_CREDITO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CREDITO_ID(decimal tipo_credito_id)
		{
			return CreateDeleteByTIPO_CREDITO_IDCommand(tipo_credito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CREDITOS_TIPO_CREDITO_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_credito_id">The <c>TIPO_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CREDITO_IDCommand(decimal tipo_credito_id)
		{
			string whereSql = "";
			whereSql += "TIPO_CREDITO_ID=" + _db.CreateSqlParameterName("TIPO_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_CREDITO_ID", tipo_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CREDITOS</c> records that match the specified criteria.
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
		/// to delete <c>CREDITOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CREDITOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CREDITOS</c> table.
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
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		protected CREDITOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		protected CREDITOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CREDITOSRow"/> objects.</returns>
		protected virtual CREDITOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_garante1_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE1_ID");
			int persona_garante2_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE2_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_solicitudColumnIndex = reader.GetOrdinal("FECHA_SOLICITUD");
			int fecha_retiroColumnIndex = reader.GetOrdinal("FECHA_RETIRO");
			int separacion_bienesColumnIndex = reader.GetOrdinal("SEPARACION_BIENES");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int total_ingresosColumnIndex = reader.GetOrdinal("TOTAL_INGRESOS");
			int total_egresosColumnIndex = reader.GetOrdinal("TOTAL_EGRESOS");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cantidad_cuotasColumnIndex = reader.GetOrdinal("CANTIDAD_CUOTAS");
			int porcentaje_interesColumnIndex = reader.GetOrdinal("PORCENTAJE_INTERES");
			int porcentaje_diario_moraColumnIndex = reader.GetOrdinal("PORCENTAJE_DIARIO_MORA");
			int porcentaje_gasto_administColumnIndex = reader.GetOrdinal("PORCENTAJE_GASTO_ADMINIST");
			int monto_capital_aprobadoColumnIndex = reader.GetOrdinal("MONTO_CAPITAL_APROBADO");
			int monto_interesColumnIndex = reader.GetOrdinal("MONTO_INTERES");
			int monto_gasto_administrativoColumnIndex = reader.GetOrdinal("MONTO_GASTO_ADMINISTRATIVO");
			int monto_capital_solicitadoColumnIndex = reader.GetOrdinal("MONTO_CAPITAL_SOLICITADO");
			int monto_totalColumnIndex = reader.GetOrdinal("MONTO_TOTAL");
			int tipo_credito_idColumnIndex = reader.GetOrdinal("TIPO_CREDITO_ID");
			int factura_cliente_idColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_ID");
			int factura_cliente_auton_idColumnIndex = reader.GetOrdinal("FACTURA_CLIENTE_AUTON_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int numero_solicitudColumnIndex = reader.GetOrdinal("NUMERO_SOLICITUD");
			int ordenes_pago_idColumnIndex = reader.GetOrdinal("ORDENES_PAGO_ID");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int entrega_inicialColumnIndex = reader.GetOrdinal("ENTREGA_INICIAL");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int con_recursoColumnIndex = reader.GetOrdinal("CON_RECURSO");
			int desembolsar_para_clienteColumnIndex = reader.GetOrdinal("DESEMBOLSAR_PARA_CLIENTE");
			int interes_incluye_impuestoColumnIndex = reader.GetOrdinal("INTERES_INCLUYE_IMPUESTO");
			int tipo_frecuenciaColumnIndex = reader.GetOrdinal("TIPO_FRECUENCIA");
			int frecuenciaColumnIndex = reader.GetOrdinal("FRECUENCIA");
			int anho_comercialColumnIndex = reader.GetOrdinal("ANHO_COMERCIAL");
			int facturar_conceptos_en_pagosColumnIndex = reader.GetOrdinal("FACTURAR_CONCEPTOS_EN_PAGOS");
			int aumentar_capital_por_descuentColumnIndex = reader.GetOrdinal("AUMENTAR_CAPITAL_POR_DESCUENT");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int dias_graciaColumnIndex = reader.GetOrdinal("DIAS_GRACIA");
			int porcentaje_seguroColumnIndex = reader.GetOrdinal("PORCENTAJE_SEGURO");
			int porcentaje_corretajeColumnIndex = reader.GetOrdinal("PORCENTAJE_CORRETAJE");
			int porcentaje_comision_adminColumnIndex = reader.GetOrdinal("PORCENTAJE_COMISION_ADMIN");
			int porcentaje_bonificacionColumnIndex = reader.GetOrdinal("PORCENTAJE_BONIFICACION");
			int monto_seguroColumnIndex = reader.GetOrdinal("MONTO_SEGURO");
			int monto_corretajeColumnIndex = reader.GetOrdinal("MONTO_CORRETAJE");
			int monto_comision_adminColumnIndex = reader.GetOrdinal("MONTO_COMISION_ADMIN");
			int monto_bonificacionColumnIndex = reader.GetOrdinal("MONTO_BONIFICACION");
			int descuento_cancelacion_anticipColumnIndex = reader.GetOrdinal("DESCUENTO_CANCELACION_ANTICIP");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int fecha_primer_vencimientoColumnIndex = reader.GetOrdinal("FECHA_PRIMER_VENCIMIENTO");
			int monto_redondeoColumnIndex = reader.GetOrdinal("MONTO_REDONDEO");
			int tipo_interes_anualColumnIndex = reader.GetOrdinal("TIPO_INTERES_ANUAL");
			int concepto_incluye_impuestoColumnIndex = reader.GetOrdinal("CONCEPTO_INCLUYE_IMPUESTO");
			int monto_capital_orden_compraColumnIndex = reader.GetOrdinal("MONTO_CAPITAL_ORDEN_COMPRA");
			int facturar_bonificacion_en_pagosColumnIndex = reader.GetOrdinal("FACTURAR_BONIFICACION_EN_PAGOS");
			int bonificacion_incluye_impuestoColumnIndex = reader.GetOrdinal("BONIFICACION_INCLUYE_IMPUESTO");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int aprobacion_1ColumnIndex = reader.GetOrdinal("APROBACION_1");
			int aprobacion_1_usuario_idColumnIndex = reader.GetOrdinal("APROBACION_1_USUARIO_ID");
			int aprobacion_1_fechaColumnIndex = reader.GetOrdinal("APROBACION_1_FECHA");
			int aprobacion_2ColumnIndex = reader.GetOrdinal("APROBACION_2");
			int aprobacion_2_usuario_idColumnIndex = reader.GetOrdinal("APROBACION_2_USUARIO_ID");
			int aprobacion_2_fechaColumnIndex = reader.GetOrdinal("APROBACION_2_FECHA");
			int aprobacion_3ColumnIndex = reader.GetOrdinal("APROBACION_3");
			int aprobacion_3_usuario_idColumnIndex = reader.GetOrdinal("APROBACION_3_USUARIO_ID");
			int aprobacion_3_fechaColumnIndex = reader.GetOrdinal("APROBACION_3_FECHA");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int facturar_interesesColumnIndex = reader.GetOrdinal("FACTURAR_INTERESES");
			int porcentaje_otrosColumnIndex = reader.GetOrdinal("PORCENTAJE_OTROS");
			int monto_otrosColumnIndex = reader.GetOrdinal("MONTO_OTROS");
			int interes_compuestoColumnIndex = reader.GetOrdinal("INTERES_COMPUESTO");
			int afecta_linea_creditoColumnIndex = reader.GetOrdinal("AFECTA_LINEA_CREDITO");
			int facturar_capitalColumnIndex = reader.GetOrdinal("FACTURAR_CAPITAL");
			int monto_diario_moraColumnIndex = reader.GetOrdinal("MONTO_DIARIO_MORA");
			int fecha_cancelacion_anticipadaColumnIndex = reader.GetOrdinal("FECHA_CANCELACION_ANTICIPADA");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int descuento_canc_ant_aplicadoColumnIndex = reader.GetOrdinal("DESCUENTO_CANC_ANT_APLICADO");
			int descuento_canc_ant_cant_no_venColumnIndex = reader.GetOrdinal("DESCUENTO_CANC_ANT_CANT_NO_VEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CREDITOSRow record = new CREDITOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante1_idColumnIndex))
						record.PERSONA_GARANTE1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante1_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante2_idColumnIndex))
						record.PERSONA_GARANTE2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante2_idColumnIndex)), 9);
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.FECHA_SOLICITUD = Convert.ToDateTime(reader.GetValue(fecha_solicitudColumnIndex));
					if(!reader.IsDBNull(fecha_retiroColumnIndex))
						record.FECHA_RETIRO = Convert.ToDateTime(reader.GetValue(fecha_retiroColumnIndex));
					record.SEPARACION_BIENES = Convert.ToString(reader.GetValue(separacion_bienesColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(total_ingresosColumnIndex))
						record.TOTAL_INGRESOS = Math.Round(Convert.ToDecimal(reader.GetValue(total_ingresosColumnIndex)), 9);
					if(!reader.IsDBNull(total_egresosColumnIndex))
						record.TOTAL_EGRESOS = Math.Round(Convert.ToDecimal(reader.GetValue(total_egresosColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.CANTIDAD_CUOTAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cuotasColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_interesColumnIndex))
						record.PORCENTAJE_INTERES = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_interesColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_diario_moraColumnIndex))
						record.PORCENTAJE_DIARIO_MORA = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_diario_moraColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_gasto_administColumnIndex))
						record.PORCENTAJE_GASTO_ADMINIST = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_gasto_administColumnIndex)), 9);
					record.MONTO_CAPITAL_APROBADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capital_aprobadoColumnIndex)), 9);
					if(!reader.IsDBNull(monto_interesColumnIndex))
						record.MONTO_INTERES = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interesColumnIndex)), 9);
					if(!reader.IsDBNull(monto_gasto_administrativoColumnIndex))
						record.MONTO_GASTO_ADMINISTRATIVO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_gasto_administrativoColumnIndex)), 9);
					record.MONTO_CAPITAL_SOLICITADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capital_solicitadoColumnIndex)), 9);
					record.MONTO_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_totalColumnIndex)), 9);
					record.TIPO_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(factura_cliente_idColumnIndex))
						record.FACTURA_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(factura_cliente_auton_idColumnIndex))
						record.FACTURA_CLIENTE_AUTON_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_cliente_auton_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_solicitudColumnIndex))
						record.NUMERO_SOLICITUD = Convert.ToString(reader.GetValue(numero_solicitudColumnIndex));
					if(!reader.IsDBNull(ordenes_pago_idColumnIndex))
						record.ORDENES_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ordenes_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_tesoreria_idColumnIndex))
						record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					record.ENTREGA_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(entrega_inicialColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					record.CON_RECURSO = Convert.ToString(reader.GetValue(con_recursoColumnIndex));
					record.DESEMBOLSAR_PARA_CLIENTE = Convert.ToString(reader.GetValue(desembolsar_para_clienteColumnIndex));
					record.INTERES_INCLUYE_IMPUESTO = Convert.ToString(reader.GetValue(interes_incluye_impuestoColumnIndex));
					record.TIPO_FRECUENCIA = Convert.ToString(reader.GetValue(tipo_frecuenciaColumnIndex));
					record.FRECUENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(frecuenciaColumnIndex)), 9);
					record.ANHO_COMERCIAL = Convert.ToString(reader.GetValue(anho_comercialColumnIndex));
					record.FACTURAR_CONCEPTOS_EN_PAGOS = Convert.ToString(reader.GetValue(facturar_conceptos_en_pagosColumnIndex));
					record.AUMENTAR_CAPITAL_POR_DESCUENT = Convert.ToString(reader.GetValue(aumentar_capital_por_descuentColumnIndex));
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.DIAS_GRACIA = Math.Round(Convert.ToDecimal(reader.GetValue(dias_graciaColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_seguroColumnIndex))
						record.PORCENTAJE_SEGURO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_seguroColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_corretajeColumnIndex))
						record.PORCENTAJE_CORRETAJE = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_corretajeColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_comision_adminColumnIndex))
						record.PORCENTAJE_COMISION_ADMIN = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_comision_adminColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_bonificacionColumnIndex))
						record.PORCENTAJE_BONIFICACION = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_bonificacionColumnIndex)), 9);
					if(!reader.IsDBNull(monto_seguroColumnIndex))
						record.MONTO_SEGURO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_seguroColumnIndex)), 9);
					if(!reader.IsDBNull(monto_corretajeColumnIndex))
						record.MONTO_CORRETAJE = Math.Round(Convert.ToDecimal(reader.GetValue(monto_corretajeColumnIndex)), 9);
					if(!reader.IsDBNull(monto_comision_adminColumnIndex))
						record.MONTO_COMISION_ADMIN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_comision_adminColumnIndex)), 9);
					if(!reader.IsDBNull(monto_bonificacionColumnIndex))
						record.MONTO_BONIFICACION = Math.Round(Convert.ToDecimal(reader.GetValue(monto_bonificacionColumnIndex)), 9);
					record.DESCUENTO_CANCELACION_ANTICIP = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_cancelacion_anticipColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.FECHA_PRIMER_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_primer_vencimientoColumnIndex));
					record.MONTO_REDONDEO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_redondeoColumnIndex)), 9);
					record.TIPO_INTERES_ANUAL = Convert.ToString(reader.GetValue(tipo_interes_anualColumnIndex));
					record.CONCEPTO_INCLUYE_IMPUESTO = Convert.ToString(reader.GetValue(concepto_incluye_impuestoColumnIndex));
					record.MONTO_CAPITAL_ORDEN_COMPRA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capital_orden_compraColumnIndex)), 9);
					if(!reader.IsDBNull(facturar_bonificacion_en_pagosColumnIndex))
						record.FACTURAR_BONIFICACION_EN_PAGOS = Convert.ToString(reader.GetValue(facturar_bonificacion_en_pagosColumnIndex));
					record.BONIFICACION_INCLUYE_IMPUESTO = Convert.ToString(reader.GetValue(bonificacion_incluye_impuestoColumnIndex));
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_idColumnIndex))
						record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					record.APROBACION_1 = Convert.ToString(reader.GetValue(aprobacion_1ColumnIndex));
					if(!reader.IsDBNull(aprobacion_1_usuario_idColumnIndex))
						record.APROBACION_1_USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aprobacion_1_usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(aprobacion_1_fechaColumnIndex))
						record.APROBACION_1_FECHA = Convert.ToDateTime(reader.GetValue(aprobacion_1_fechaColumnIndex));
					record.APROBACION_2 = Convert.ToString(reader.GetValue(aprobacion_2ColumnIndex));
					if(!reader.IsDBNull(aprobacion_2_usuario_idColumnIndex))
						record.APROBACION_2_USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aprobacion_2_usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(aprobacion_2_fechaColumnIndex))
						record.APROBACION_2_FECHA = Convert.ToDateTime(reader.GetValue(aprobacion_2_fechaColumnIndex));
					record.APROBACION_3 = Convert.ToString(reader.GetValue(aprobacion_3ColumnIndex));
					if(!reader.IsDBNull(aprobacion_3_usuario_idColumnIndex))
						record.APROBACION_3_USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aprobacion_3_usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(aprobacion_3_fechaColumnIndex))
						record.APROBACION_3_FECHA = Convert.ToDateTime(reader.GetValue(aprobacion_3_fechaColumnIndex));
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					record.FACTURAR_INTERESES = Math.Round(Convert.ToDecimal(reader.GetValue(facturar_interesesColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_otrosColumnIndex))
						record.PORCENTAJE_OTROS = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_otrosColumnIndex)), 9);
					if(!reader.IsDBNull(monto_otrosColumnIndex))
						record.MONTO_OTROS = Math.Round(Convert.ToDecimal(reader.GetValue(monto_otrosColumnIndex)), 9);
					record.INTERES_COMPUESTO = Convert.ToString(reader.GetValue(interes_compuestoColumnIndex));
					record.AFECTA_LINEA_CREDITO = Convert.ToString(reader.GetValue(afecta_linea_creditoColumnIndex));
					record.FACTURAR_CAPITAL = Math.Round(Convert.ToDecimal(reader.GetValue(facturar_capitalColumnIndex)), 9);
					if(!reader.IsDBNull(monto_diario_moraColumnIndex))
						record.MONTO_DIARIO_MORA = Math.Round(Convert.ToDecimal(reader.GetValue(monto_diario_moraColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_cancelacion_anticipadaColumnIndex))
						record.FECHA_CANCELACION_ANTICIPADA = Convert.ToDateTime(reader.GetValue(fecha_cancelacion_anticipadaColumnIndex));
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.DESCUENTO_CANC_ANT_APLICADO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_canc_ant_aplicadoColumnIndex)), 9);
					record.DESCUENTO_CANC_ANT_CANT_NO_VEN = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_canc_ant_cant_no_venColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CREDITOSRow[])(recordList.ToArray(typeof(CREDITOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CREDITOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CREDITOSRow"/> object.</returns>
		protected virtual CREDITOSRow MapRow(DataRow row)
		{
			CREDITOSRow mappedObject = new CREDITOSRow();
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
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE1_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE1_ID = (decimal)row[dataColumn];
			// Column "PERSONA_GARANTE2_ID"
			dataColumn = dataTable.Columns["PERSONA_GARANTE2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_GARANTE2_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_SOLICITUD"
			dataColumn = dataTable.Columns["FECHA_SOLICITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SOLICITUD = (System.DateTime)row[dataColumn];
			// Column "FECHA_RETIRO"
			dataColumn = dataTable.Columns["FECHA_RETIRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RETIRO = (System.DateTime)row[dataColumn];
			// Column "SEPARACION_BIENES"
			dataColumn = dataTable.Columns["SEPARACION_BIENES"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEPARACION_BIENES = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "TOTAL_INGRESOS"
			dataColumn = dataTable.Columns["TOTAL_INGRESOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_INGRESOS = (decimal)row[dataColumn];
			// Column "TOTAL_EGRESOS"
			dataColumn = dataTable.Columns["TOTAL_EGRESOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_EGRESOS = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CANTIDAD_CUOTAS"
			dataColumn = dataTable.Columns["CANTIDAD_CUOTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CUOTAS = (decimal)row[dataColumn];
			// Column "PORCENTAJE_INTERES"
			dataColumn = dataTable.Columns["PORCENTAJE_INTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_INTERES = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DIARIO_MORA"
			dataColumn = dataTable.Columns["PORCENTAJE_DIARIO_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DIARIO_MORA = (decimal)row[dataColumn];
			// Column "PORCENTAJE_GASTO_ADMINIST"
			dataColumn = dataTable.Columns["PORCENTAJE_GASTO_ADMINIST"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_GASTO_ADMINIST = (decimal)row[dataColumn];
			// Column "MONTO_CAPITAL_APROBADO"
			dataColumn = dataTable.Columns["MONTO_CAPITAL_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL_APROBADO = (decimal)row[dataColumn];
			// Column "MONTO_INTERES"
			dataColumn = dataTable.Columns["MONTO_INTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERES = (decimal)row[dataColumn];
			// Column "MONTO_GASTO_ADMINISTRATIVO"
			dataColumn = dataTable.Columns["MONTO_GASTO_ADMINISTRATIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_GASTO_ADMINISTRATIVO = (decimal)row[dataColumn];
			// Column "MONTO_CAPITAL_SOLICITADO"
			dataColumn = dataTable.Columns["MONTO_CAPITAL_SOLICITADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL_SOLICITADO = (decimal)row[dataColumn];
			// Column "MONTO_TOTAL"
			dataColumn = dataTable.Columns["MONTO_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_TOTAL = (decimal)row[dataColumn];
			// Column "TIPO_CREDITO_ID"
			dataColumn = dataTable.Columns["TIPO_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CREDITO_ID = (decimal)row[dataColumn];
			// Column "FACTURA_CLIENTE_ID"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "FACTURA_CLIENTE_AUTON_ID"
			dataColumn = dataTable.Columns["FACTURA_CLIENTE_AUTON_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CLIENTE_AUTON_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "NUMERO_SOLICITUD"
			dataColumn = dataTable.Columns["NUMERO_SOLICITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_SOLICITUD = (string)row[dataColumn];
			// Column "ORDENES_PAGO_ID"
			dataColumn = dataTable.Columns["ORDENES_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDENES_PAGO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "ENTREGA_INICIAL"
			dataColumn = dataTable.Columns["ENTREGA_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTREGA_INICIAL = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "CON_RECURSO"
			dataColumn = dataTable.Columns["CON_RECURSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CON_RECURSO = (string)row[dataColumn];
			// Column "DESEMBOLSAR_PARA_CLIENTE"
			dataColumn = dataTable.Columns["DESEMBOLSAR_PARA_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSAR_PARA_CLIENTE = (string)row[dataColumn];
			// Column "INTERES_INCLUYE_IMPUESTO"
			dataColumn = dataTable.Columns["INTERES_INCLUYE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_INCLUYE_IMPUESTO = (string)row[dataColumn];
			// Column "TIPO_FRECUENCIA"
			dataColumn = dataTable.Columns["TIPO_FRECUENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FRECUENCIA = (string)row[dataColumn];
			// Column "FRECUENCIA"
			dataColumn = dataTable.Columns["FRECUENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FRECUENCIA = (decimal)row[dataColumn];
			// Column "ANHO_COMERCIAL"
			dataColumn = dataTable.Columns["ANHO_COMERCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANHO_COMERCIAL = (string)row[dataColumn];
			// Column "FACTURAR_CONCEPTOS_EN_PAGOS"
			dataColumn = dataTable.Columns["FACTURAR_CONCEPTOS_EN_PAGOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_CONCEPTOS_EN_PAGOS = (string)row[dataColumn];
			// Column "AUMENTAR_CAPITAL_POR_DESCUENT"
			dataColumn = dataTable.Columns["AUMENTAR_CAPITAL_POR_DESCUENT"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUMENTAR_CAPITAL_POR_DESCUENT = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "DIAS_GRACIA"
			dataColumn = dataTable.Columns["DIAS_GRACIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_GRACIA = (decimal)row[dataColumn];
			// Column "PORCENTAJE_SEGURO"
			dataColumn = dataTable.Columns["PORCENTAJE_SEGURO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_SEGURO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_CORRETAJE"
			dataColumn = dataTable.Columns["PORCENTAJE_CORRETAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_CORRETAJE = (decimal)row[dataColumn];
			// Column "PORCENTAJE_COMISION_ADMIN"
			dataColumn = dataTable.Columns["PORCENTAJE_COMISION_ADMIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_COMISION_ADMIN = (decimal)row[dataColumn];
			// Column "PORCENTAJE_BONIFICACION"
			dataColumn = dataTable.Columns["PORCENTAJE_BONIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_BONIFICACION = (decimal)row[dataColumn];
			// Column "MONTO_SEGURO"
			dataColumn = dataTable.Columns["MONTO_SEGURO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_SEGURO = (decimal)row[dataColumn];
			// Column "MONTO_CORRETAJE"
			dataColumn = dataTable.Columns["MONTO_CORRETAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CORRETAJE = (decimal)row[dataColumn];
			// Column "MONTO_COMISION_ADMIN"
			dataColumn = dataTable.Columns["MONTO_COMISION_ADMIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COMISION_ADMIN = (decimal)row[dataColumn];
			// Column "MONTO_BONIFICACION"
			dataColumn = dataTable.Columns["MONTO_BONIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BONIFICACION = (decimal)row[dataColumn];
			// Column "DESCUENTO_CANCELACION_ANTICIP"
			dataColumn = dataTable.Columns["DESCUENTO_CANCELACION_ANTICIP"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_CANCELACION_ANTICIP = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "FECHA_PRIMER_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_PRIMER_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_PRIMER_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "MONTO_REDONDEO"
			dataColumn = dataTable.Columns["MONTO_REDONDEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_REDONDEO = (decimal)row[dataColumn];
			// Column "TIPO_INTERES_ANUAL"
			dataColumn = dataTable.Columns["TIPO_INTERES_ANUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_INTERES_ANUAL = (string)row[dataColumn];
			// Column "CONCEPTO_INCLUYE_IMPUESTO"
			dataColumn = dataTable.Columns["CONCEPTO_INCLUYE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCEPTO_INCLUYE_IMPUESTO = (string)row[dataColumn];
			// Column "MONTO_CAPITAL_ORDEN_COMPRA"
			dataColumn = dataTable.Columns["MONTO_CAPITAL_ORDEN_COMPRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL_ORDEN_COMPRA = (decimal)row[dataColumn];
			// Column "FACTURAR_BONIFICACION_EN_PAGOS"
			dataColumn = dataTable.Columns["FACTURAR_BONIFICACION_EN_PAGOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_BONIFICACION_EN_PAGOS = (string)row[dataColumn];
			// Column "BONIFICACION_INCLUYE_IMPUESTO"
			dataColumn = dataTable.Columns["BONIFICACION_INCLUYE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BONIFICACION_INCLUYE_IMPUESTO = (string)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "APROBACION_1"
			dataColumn = dataTable.Columns["APROBACION_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_1 = (string)row[dataColumn];
			// Column "APROBACION_1_USUARIO_ID"
			dataColumn = dataTable.Columns["APROBACION_1_USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_1_USUARIO_ID = (decimal)row[dataColumn];
			// Column "APROBACION_1_FECHA"
			dataColumn = dataTable.Columns["APROBACION_1_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_1_FECHA = (System.DateTime)row[dataColumn];
			// Column "APROBACION_2"
			dataColumn = dataTable.Columns["APROBACION_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_2 = (string)row[dataColumn];
			// Column "APROBACION_2_USUARIO_ID"
			dataColumn = dataTable.Columns["APROBACION_2_USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_2_USUARIO_ID = (decimal)row[dataColumn];
			// Column "APROBACION_2_FECHA"
			dataColumn = dataTable.Columns["APROBACION_2_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_2_FECHA = (System.DateTime)row[dataColumn];
			// Column "APROBACION_3"
			dataColumn = dataTable.Columns["APROBACION_3"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_3 = (string)row[dataColumn];
			// Column "APROBACION_3_USUARIO_ID"
			dataColumn = dataTable.Columns["APROBACION_3_USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_3_USUARIO_ID = (decimal)row[dataColumn];
			// Column "APROBACION_3_FECHA"
			dataColumn = dataTable.Columns["APROBACION_3_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBACION_3_FECHA = (System.DateTime)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "FACTURAR_INTERESES"
			dataColumn = dataTable.Columns["FACTURAR_INTERESES"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_INTERESES = (decimal)row[dataColumn];
			// Column "PORCENTAJE_OTROS"
			dataColumn = dataTable.Columns["PORCENTAJE_OTROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_OTROS = (decimal)row[dataColumn];
			// Column "MONTO_OTROS"
			dataColumn = dataTable.Columns["MONTO_OTROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_OTROS = (decimal)row[dataColumn];
			// Column "INTERES_COMPUESTO"
			dataColumn = dataTable.Columns["INTERES_COMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERES_COMPUESTO = (string)row[dataColumn];
			// Column "AFECTA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["AFECTA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_LINEA_CREDITO = (string)row[dataColumn];
			// Column "FACTURAR_CAPITAL"
			dataColumn = dataTable.Columns["FACTURAR_CAPITAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAR_CAPITAL = (decimal)row[dataColumn];
			// Column "MONTO_DIARIO_MORA"
			dataColumn = dataTable.Columns["MONTO_DIARIO_MORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DIARIO_MORA = (decimal)row[dataColumn];
			// Column "FECHA_CANCELACION_ANTICIPADA"
			dataColumn = dataTable.Columns["FECHA_CANCELACION_ANTICIPADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CANCELACION_ANTICIPADA = (System.DateTime)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_CANC_ANT_APLICADO"
			dataColumn = dataTable.Columns["DESCUENTO_CANC_ANT_APLICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_CANC_ANT_APLICADO = (decimal)row[dataColumn];
			// Column "DESCUENTO_CANC_ANT_CANT_NO_VEN"
			dataColumn = dataTable.Columns["DESCUENTO_CANC_ANT_CANT_NO_VEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_CANC_ANT_CANT_NO_VEN = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CREDITOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CREDITOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA_SOLICITUD", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_RETIRO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("SEPARACION_BIENES", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_INGRESOS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_EGRESOS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CUOTAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_INTERES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DIARIO_MORA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_GASTO_ADMINIST", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL_APROBADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INTERES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_GASTO_ADMINISTRATIVO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL_SOLICITADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTURA_CLIENTE_AUTON_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_SOLICITUD", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ORDENES_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ENTREGA_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CON_RECURSO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESEMBOLSAR_PARA_CLIENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERES_INCLUYE_IMPUESTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_FRECUENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FRECUENCIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ANHO_COMERCIAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_CONCEPTOS_EN_PAGOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUMENTAR_CAPITAL_POR_DESCUENT", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DIAS_GRACIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_SEGURO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_CORRETAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_COMISION_ADMIN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PORCENTAJE_BONIFICACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_SEGURO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_CORRETAJE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_COMISION_ADMIN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_BONIFICACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_CANCELACION_ANTICIP", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_PRIMER_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_REDONDEO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_INTERES_ANUAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONCEPTO_INCLUYE_IMPUESTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL_ORDEN_COMPRA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_BONIFICACION_EN_PAGOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("BONIFICACION_INCLUYE_IMPUESTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APROBACION_1", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APROBACION_1_USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APROBACION_1_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("APROBACION_2", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APROBACION_2_USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APROBACION_2_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("APROBACION_3", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APROBACION_3_USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APROBACION_3_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTURAR_INTERESES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_OTROS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_OTROS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INTERES_COMPUESTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_LINEA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAR_CAPITAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DIARIO_MORA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_CANCELACION_ANTICIPADA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCUENTO_CANC_ANT_APLICADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCUENTO_CANC_ANT_CANT_NO_VEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_GARANTE2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_SOLICITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_RETIRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SEPARACION_BIENES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_INGRESOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_EGRESOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CUOTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_INTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DIARIO_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_GASTO_ADMINIST":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CAPITAL_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_INTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_GASTO_ADMINISTRATIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CAPITAL_SOLICITADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_CLIENTE_AUTON_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_SOLICITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDENES_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTREGA_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CON_RECURSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESEMBOLSAR_PARA_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INTERES_INCLUYE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_FRECUENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FRECUENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANHO_COMERCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURAR_CONCEPTOS_EN_PAGOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AUMENTAR_CAPITAL_POR_DESCUENT":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIAS_GRACIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_SEGURO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_CORRETAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_COMISION_ADMIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_BONIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_SEGURO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CORRETAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COMISION_ADMIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_BONIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_CANCELACION_ANTICIP":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_PRIMER_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONTO_REDONDEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_INTERES_ANUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONCEPTO_INCLUYE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_CAPITAL_ORDEN_COMPRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURAR_BONIFICACION_EN_PAGOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BONIFICACION_INCLUYE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APROBACION_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "APROBACION_1_USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APROBACION_1_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "APROBACION_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "APROBACION_2_USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APROBACION_2_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "APROBACION_3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "APROBACION_3_USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APROBACION_3_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURAR_INTERESES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_OTROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_OTROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INTERES_COMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURAR_CAPITAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DIARIO_MORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CANCELACION_ANTICIPADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_CANC_ANT_APLICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_CANC_ANT_CANT_NO_VEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CREDITOSCollection_Base class
}  // End of namespace
