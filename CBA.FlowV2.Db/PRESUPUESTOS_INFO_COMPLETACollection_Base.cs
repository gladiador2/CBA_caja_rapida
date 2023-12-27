// <fileinfo name="PRESUPUESTOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="PRESUPUESTOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRESUPUESTOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRESUPUESTOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string CASO_FECHA_CREACIONColumnName = "CASO_FECHA_CREACION";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_PAIS_IDColumnName = "SUCURSAL_PAIS_ID";
		public const string SUCURSAL_PAIS_NOMBREColumnName = "SUCURSAL_PAIS_NOMBRE";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_ENTREGAColumnName = "FECHA_ENTREGA";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string FECHA_VALIDEZColumnName = "FECHA_VALIDEZ";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string PERSONA_GARANTE_1_IDColumnName = "PERSONA_GARANTE_1_ID";
		public const string PERSONA_GARANTE_2_IDColumnName = "PERSONA_GARANTE_2_ID";
		public const string PERSONA_GARANTE_3_IDColumnName = "PERSONA_GARANTE_3_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FUNCIONARIO_NOMBRE_COMPLETOColumnName = "FUNCIONARIO_NOMBRE_COMPLETO";
		public const string OBJETOColumnName = "OBJETO";
		public const string CASO_ORIGEN_IDColumnName = "CASO_ORIGEN_ID";
		public const string TEXTO_PREDEFINIDO_TIPO_IDColumnName = "TEXTO_PREDEFINIDO_TIPO_ID";
		public const string TEXTO_PREDEF_ID_TIPOColumnName = "TEXTO_PREDEF_ID_TIPO";
		public const string TEXTO_PREDEF_TIPO_NOMBREColumnName = "TEXTO_PREDEF_TIPO_NOMBRE";
		public const string TEXTO_PREDEF_TIPO_TEXTOColumnName = "TEXTO_PREDEF_TIPO_TEXTO";
		public const string TEXTO_PREDEFINIDO_FUERO_IDColumnName = "TEXTO_PREDEFINIDO_FUERO_ID";
		public const string TEXTO_PREDEF_ID_FUEROColumnName = "TEXTO_PREDEF_ID_FUERO";
		public const string TEXTO_PREDEF_FUERO_NOMBREColumnName = "TEXTO_PREDEF_FUERO_NOMBRE";
		public const string TEXTO_PREDEF_FUERO_TEXTOColumnName = "TEXTO_PREDEF_FUERO_TEXTO";
		public const string TOTAL_MONTO_BRUTOColumnName = "TOTAL_MONTO_BRUTO";
		public const string TOTAL_MONTO_DESCUENTOColumnName = "TOTAL_MONTO_DESCUENTO";
		public const string TOTAL_MONTO_NETOColumnName = "TOTAL_MONTO_NETO";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TRAMITES_TIPOS_IDColumnName = "TRAMITES_TIPOS_ID";
		public const string TRAMITES_TIPOS_NOMBREColumnName = "TRAMITES_TIPOS_NOMBRE";
		public const string TIPO_UNIFICADO_IDColumnName = "TIPO_UNIFICADO_ID";
		public const string TIPO_UNIFICADOColumnName = "TIPO_UNIFICADO";
		public const string VEHICULO_IDColumnName = "VEHICULO_ID";
		public const string VEHICULO_NOMBREColumnName = "VEHICULO_NOMBRE";
		public const string CHASIS_NROColumnName = "CHASIS_NRO";
		public const string NRO_COMPROBANTE_EXTERNOColumnName = "NRO_COMPROBANTE_EXTERNO";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ARTICULO_MONTOColumnName = "ARTICULO_MONTO";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRESUPUESTOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRESUPUESTOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRESUPUESTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual PRESUPUESTOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRESUPUESTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRESUPUESTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRESUPUESTOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRESUPUESTOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects.</returns>
		public PRESUPUESTOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual PRESUPUESTOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRESUPUESTOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects.</returns>
		protected PRESUPUESTOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects.</returns>
		protected PRESUPUESTOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual PRESUPUESTOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estado_idColumnIndex = reader.GetOrdinal("CASO_ESTADO_ID");
			int caso_fecha_creacionColumnIndex = reader.GetOrdinal("CASO_FECHA_CREACION");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_pais_idColumnIndex = reader.GetOrdinal("SUCURSAL_PAIS_ID");
			int sucursal_pais_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_PAIS_NOMBRE");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_entregaColumnIndex = reader.GetOrdinal("FECHA_ENTREGA");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int fecha_validezColumnIndex = reader.GetOrdinal("FECHA_VALIDEZ");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int persona_garante_1_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_1_ID");
			int persona_garante_2_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_2_ID");
			int persona_garante_3_idColumnIndex = reader.GetOrdinal("PERSONA_GARANTE_3_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int funcionario_nombre_completoColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE_COMPLETO");
			int objetoColumnIndex = reader.GetOrdinal("OBJETO");
			int caso_origen_idColumnIndex = reader.GetOrdinal("CASO_ORIGEN_ID");
			int texto_predefinido_tipo_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_TIPO_ID");
			int texto_predef_id_tipoColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_ID_TIPO");
			int texto_predef_tipo_nombreColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_TIPO_NOMBRE");
			int texto_predef_tipo_textoColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_TIPO_TEXTO");
			int texto_predefinido_fuero_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_FUERO_ID");
			int texto_predef_id_fueroColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_ID_FUERO");
			int texto_predef_fuero_nombreColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_FUERO_NOMBRE");
			int texto_predef_fuero_textoColumnIndex = reader.GetOrdinal("TEXTO_PREDEF_FUERO_TEXTO");
			int total_monto_brutoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO");
			int total_monto_descuentoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DESCUENTO");
			int total_monto_netoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_NETO");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int tramites_tipos_idColumnIndex = reader.GetOrdinal("TRAMITES_TIPOS_ID");
			int tramites_tipos_nombreColumnIndex = reader.GetOrdinal("TRAMITES_TIPOS_NOMBRE");
			int tipo_unificado_idColumnIndex = reader.GetOrdinal("TIPO_UNIFICADO_ID");
			int tipo_unificadoColumnIndex = reader.GetOrdinal("TIPO_UNIFICADO");
			int vehiculo_idColumnIndex = reader.GetOrdinal("VEHICULO_ID");
			int vehiculo_nombreColumnIndex = reader.GetOrdinal("VEHICULO_NOMBRE");
			int chasis_nroColumnIndex = reader.GetOrdinal("CHASIS_NRO");
			int nro_comprobante_externoColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE_EXTERNO");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int articulo_montoColumnIndex = reader.GetOrdinal("ARTICULO_MONTO");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRESUPUESTOS_INFO_COMPLETARow record = new PRESUPUESTOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.CASO_FECHA_CREACION = Convert.ToDateTime(reader.GetValue(caso_fecha_creacionColumnIndex));
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.SUCURSAL_PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_pais_idColumnIndex)), 9);
					record.SUCURSAL_PAIS_NOMBRE = Convert.ToString(reader.GetValue(sucursal_pais_nombreColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(fecha_entregaColumnIndex))
						record.FECHA_ENTREGA = Convert.ToDateTime(reader.GetValue(fecha_entregaColumnIndex));
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					record.FECHA_VALIDEZ = Convert.ToDateTime(reader.GetValue(fecha_validezColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					if(!reader.IsDBNull(persona_garante_1_idColumnIndex))
						record.PERSONA_GARANTE_1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_1_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_2_idColumnIndex))
						record.PERSONA_GARANTE_2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_2_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_garante_3_idColumnIndex))
						record.PERSONA_GARANTE_3_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_garante_3_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_nombre_completoColumnIndex))
						record.FUNCIONARIO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(funcionario_nombre_completoColumnIndex));
					if(!reader.IsDBNull(objetoColumnIndex))
						record.OBJETO = Convert.ToString(reader.GetValue(objetoColumnIndex));
					if(!reader.IsDBNull(caso_origen_idColumnIndex))
						record.CASO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_tipo_idColumnIndex))
						record.TEXTO_PREDEFINIDO_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predef_id_tipoColumnIndex))
						record.TEXTO_PREDEF_ID_TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predef_id_tipoColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predef_tipo_nombreColumnIndex))
						record.TEXTO_PREDEF_TIPO_NOMBRE = Convert.ToString(reader.GetValue(texto_predef_tipo_nombreColumnIndex));
					if(!reader.IsDBNull(texto_predef_tipo_textoColumnIndex))
						record.TEXTO_PREDEF_TIPO_TEXTO = Convert.ToString(reader.GetValue(texto_predef_tipo_textoColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_fuero_idColumnIndex))
						record.TEXTO_PREDEFINIDO_FUERO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_fuero_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predef_id_fueroColumnIndex))
						record.TEXTO_PREDEF_ID_FUERO = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predef_id_fueroColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predef_fuero_nombreColumnIndex))
						record.TEXTO_PREDEF_FUERO_NOMBRE = Convert.ToString(reader.GetValue(texto_predef_fuero_nombreColumnIndex));
					if(!reader.IsDBNull(texto_predef_fuero_textoColumnIndex))
						record.TEXTO_PREDEF_FUERO_TEXTO = Convert.ToString(reader.GetValue(texto_predef_fuero_textoColumnIndex));
					if(!reader.IsDBNull(total_monto_brutoColumnIndex))
						record.TOTAL_MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_descuentoColumnIndex))
						record.TOTAL_MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_descuentoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_netoColumnIndex))
						record.TOTAL_MONTO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_netoColumnIndex)), 9);
					if(!reader.IsDBNull(total_monto_impuestoColumnIndex))
						record.TOTAL_MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(tramites_tipos_idColumnIndex))
						record.TRAMITES_TIPOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramites_tipos_idColumnIndex)), 9);
					if(!reader.IsDBNull(tramites_tipos_nombreColumnIndex))
						record.TRAMITES_TIPOS_NOMBRE = Convert.ToString(reader.GetValue(tramites_tipos_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_unificado_idColumnIndex))
						record.TIPO_UNIFICADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_unificado_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_unificadoColumnIndex))
						record.TIPO_UNIFICADO = Convert.ToString(reader.GetValue(tipo_unificadoColumnIndex));
					if(!reader.IsDBNull(vehiculo_idColumnIndex))
						record.VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(vehiculo_nombreColumnIndex))
						record.VEHICULO_NOMBRE = Convert.ToString(reader.GetValue(vehiculo_nombreColumnIndex));
					if(!reader.IsDBNull(chasis_nroColumnIndex))
						record.CHASIS_NRO = Convert.ToString(reader.GetValue(chasis_nroColumnIndex));
					if(!reader.IsDBNull(nro_comprobante_externoColumnIndex))
						record.NRO_COMPROBANTE_EXTERNO = Convert.ToString(reader.GetValue(nro_comprobante_externoColumnIndex));
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_montoColumnIndex))
						record.ARTICULO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRESUPUESTOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(PRESUPUESTOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRESUPUESTOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRESUPUESTOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual PRESUPUESTOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			PRESUPUESTOS_INFO_COMPLETARow mappedObject = new PRESUPUESTOS_INFO_COMPLETARow();
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
			// Column "CASO_FECHA_CREACION"
			dataColumn = dataTable.Columns["CASO_FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_PAIS_ID"
			dataColumn = dataTable.Columns["SUCURSAL_PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_PAIS_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_PAIS_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_PAIS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_PAIS_NOMBRE = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_ENTREGA"
			dataColumn = dataTable.Columns["FECHA_ENTREGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTREGA = (System.DateTime)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VALIDEZ"
			dataColumn = dataTable.Columns["FECHA_VALIDEZ"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VALIDEZ = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
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
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
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
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "OBJETO"
			dataColumn = dataTable.Columns["OBJETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBJETO = (string)row[dataColumn];
			// Column "CASO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CASO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_TIPO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_TIPO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEF_ID_TIPO"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_ID_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_ID_TIPO = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEF_TIPO_NOMBRE"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_TIPO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_TIPO_NOMBRE = (string)row[dataColumn];
			// Column "TEXTO_PREDEF_TIPO_TEXTO"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_TIPO_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_TIPO_TEXTO = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_FUERO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_FUERO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_FUERO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEF_ID_FUERO"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_ID_FUERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_ID_FUERO = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEF_FUERO_NOMBRE"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_FUERO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_FUERO_NOMBRE = (string)row[dataColumn];
			// Column "TEXTO_PREDEF_FUERO_TEXTO"
			dataColumn = dataTable.Columns["TEXTO_PREDEF_FUERO_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEF_FUERO_TEXTO = (string)row[dataColumn];
			// Column "TOTAL_MONTO_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_DESCUENTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_DESCUENTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_NETO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_NETO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "TRAMITES_TIPOS_ID"
			dataColumn = dataTable.Columns["TRAMITES_TIPOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITES_TIPOS_ID = (decimal)row[dataColumn];
			// Column "TRAMITES_TIPOS_NOMBRE"
			dataColumn = dataTable.Columns["TRAMITES_TIPOS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITES_TIPOS_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_UNIFICADO_ID"
			dataColumn = dataTable.Columns["TIPO_UNIFICADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_UNIFICADO_ID = (decimal)row[dataColumn];
			// Column "TIPO_UNIFICADO"
			dataColumn = dataTable.Columns["TIPO_UNIFICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_UNIFICADO = (string)row[dataColumn];
			// Column "VEHICULO_ID"
			dataColumn = dataTable.Columns["VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_ID = (decimal)row[dataColumn];
			// Column "VEHICULO_NOMBRE"
			dataColumn = dataTable.Columns["VEHICULO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VEHICULO_NOMBRE = (string)row[dataColumn];
			// Column "CHASIS_NRO"
			dataColumn = dataTable.Columns["CHASIS_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHASIS_NRO = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE_EXTERNO"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE_EXTERNO = (string)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_MONTO"
			dataColumn = dataTable.Columns["ARTICULO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_MONTO = (decimal)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRESUPUESTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRESUPUESTOS_INFO_COMPLETA";
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
			dataColumn = dataTable.Columns.Add("CASO_FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_PAIS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ENTREGA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VALIDEZ", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
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
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_GARANTE_3_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBJETO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_TIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_ID_TIPO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_TIPO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_TIPO_TEXTO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_FUERO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_ID_FUERO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_FUERO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEF_FUERO_TEXTO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DESCUENTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITES_TIPOS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRAMITES_TIPOS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_UNIFICADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_UNIFICADO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VEHICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VEHICULO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHASIS_NRO", typeof(string));
			dataColumn.MaxLength = 17;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE_EXTERNO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_MONTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 951;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
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

				case "CASO_FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_PAIS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ENTREGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VALIDEZ":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
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

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBJETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEF_ID_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEF_TIPO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEF_TIPO_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_FUERO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEF_ID_FUERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEF_FUERO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEF_FUERO_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITES_TIPOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRAMITES_TIPOS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_UNIFICADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_UNIFICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VEHICULO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHASIS_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRESUPUESTOS_INFO_COMPLETACollection_Base class
}  // End of namespace
