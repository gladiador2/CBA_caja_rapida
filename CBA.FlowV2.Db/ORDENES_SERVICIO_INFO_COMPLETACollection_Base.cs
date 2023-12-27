// <fileinfo name="ORDENES_SERVICIO_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_SERVICIO_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_SERVICIO_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_SERVICIO_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADO_IDColumnName = "CASO_ESTADO_ID";
		public const string CASO_FECHA_CREACIONColumnName = "CASO_FECHA_CREACION";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string TIPO_TEXTO_PREDEFINIDO_NOMBREColumnName = "TIPO_TEXTO_PREDEFINIDO_NOMBRE";
		public const string TEXTO_PREDEFINIDOColumnName = "TEXTO_PREDEFINIDO";
		public const string TITULOColumnName = "TITULO";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string HORA_INICIOColumnName = "HORA_INICIO";
		public const string HORA_FINColumnName = "HORA_FIN";
		public const string FECHA_FINColumnName = "FECHA_FIN";
		public const string CASO_ORIGINARIO_IDColumnName = "CASO_ORIGINARIO_ID";
		public const string CASO_ORIGINARIO_FLUJO_IDColumnName = "CASO_ORIGINARIO_FLUJO_ID";
		public const string CASO_ORIGINARIO_FLUJO_DESCColumnName = "CASO_ORIGINARIO_FLUJO_DESC";
		public const string DEBE_FACTURARColumnName = "DEBE_FACTURAR";
		public const string VISTO_BUENO_FUNCIONARIOColumnName = "VISTO_BUENO_FUNCIONARIO";
		public const string VISTO_BUENO_PERSONAColumnName = "VISTO_BUENO_PERSONA";
		public const string VISTO_BUENO_GERENCIAColumnName = "VISTO_BUENO_GERENCIA";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string AUTONUMERACION_TIMBRADOColumnName = "AUTONUMERACION_TIMBRADO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string TIENE_CASO_CONSIDERADO_PAGOColumnName = "TIENE_CASO_CONSIDERADO_PAGO";
		public const string ES_PARA_CLIENTEColumnName = "ES_PARA_CLIENTE";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string PROVEEDOR_RAZON_SOCIALColumnName = "PROVEEDOR_RAZON_SOCIAL";
		public const string TOTAL_CANTIDAD_HORASColumnName = "TOTAL_CANTIDAD_HORAS";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string CENTRO_COSTOS_NOMBREColumnName = "CENTRO_COSTOS_NOMBRE";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string CONDICION_PAGO_NOMBREColumnName = "CONDICION_PAGO_NOMBRE";
		public const string ANTICIPO_REQUERIDOColumnName = "ANTICIPO_REQUERIDO";
		public const string ANTICIPO_GENERARColumnName = "ANTICIPO_GENERAR";
		public const string ANTICIPO_MONTOColumnName = "ANTICIPO_MONTO";
		public const string APLICAR_RETENCIONColumnName = "APLICAR_RETENCION";
		public const string FACTURA_DETALLADAColumnName = "FACTURA_DETALLADA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_SERVICIO_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_SERVICIO_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_SERVICIO_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_SERVICIO_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_SERVICIO_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_SERVICIO_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_SERVICIO_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects.</returns>
		public ORDENES_SERVICIO_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects.</returns>
		public virtual ORDENES_SERVICIO_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_SERVICIO_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects.</returns>
		protected ORDENES_SERVICIO_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects.</returns>
		protected ORDENES_SERVICIO_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> objects.</returns>
		protected virtual ORDENES_SERVICIO_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
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
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int tipo_texto_predefinido_nombreColumnIndex = reader.GetOrdinal("TIPO_TEXTO_PREDEFINIDO_NOMBRE");
			int texto_predefinidoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO");
			int tituloColumnIndex = reader.GetOrdinal("TITULO");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int hora_inicioColumnIndex = reader.GetOrdinal("HORA_INICIO");
			int hora_finColumnIndex = reader.GetOrdinal("HORA_FIN");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");
			int caso_originario_idColumnIndex = reader.GetOrdinal("CASO_ORIGINARIO_ID");
			int caso_originario_flujo_idColumnIndex = reader.GetOrdinal("CASO_ORIGINARIO_FLUJO_ID");
			int caso_originario_flujo_descColumnIndex = reader.GetOrdinal("CASO_ORIGINARIO_FLUJO_DESC");
			int debe_facturarColumnIndex = reader.GetOrdinal("DEBE_FACTURAR");
			int visto_bueno_funcionarioColumnIndex = reader.GetOrdinal("VISTO_BUENO_FUNCIONARIO");
			int visto_bueno_personaColumnIndex = reader.GetOrdinal("VISTO_BUENO_PERSONA");
			int visto_bueno_gerenciaColumnIndex = reader.GetOrdinal("VISTO_BUENO_GERENCIA");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int autonumeracion_timbradoColumnIndex = reader.GetOrdinal("AUTONUMERACION_TIMBRADO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int tiene_caso_considerado_pagoColumnIndex = reader.GetOrdinal("TIENE_CASO_CONSIDERADO_PAGO");
			int es_para_clienteColumnIndex = reader.GetOrdinal("ES_PARA_CLIENTE");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int proveedor_razon_socialColumnIndex = reader.GetOrdinal("PROVEEDOR_RAZON_SOCIAL");
			int total_cantidad_horasColumnIndex = reader.GetOrdinal("TOTAL_CANTIDAD_HORAS");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int centro_costos_nombreColumnIndex = reader.GetOrdinal("CENTRO_COSTOS_NOMBRE");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int condicion_pago_nombreColumnIndex = reader.GetOrdinal("CONDICION_PAGO_NOMBRE");
			int anticipo_requeridoColumnIndex = reader.GetOrdinal("ANTICIPO_REQUERIDO");
			int anticipo_generarColumnIndex = reader.GetOrdinal("ANTICIPO_GENERAR");
			int anticipo_montoColumnIndex = reader.GetOrdinal("ANTICIPO_MONTO");
			int aplicar_retencionColumnIndex = reader.GetOrdinal("APLICAR_RETENCION");
			int factura_detalladaColumnIndex = reader.GetOrdinal("FACTURA_DETALLADA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_SERVICIO_INFO_COMPLETARow record = new ORDENES_SERVICIO_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO_ID = Convert.ToString(reader.GetValue(caso_estado_idColumnIndex));
					record.CASO_FECHA_CREACION = Convert.ToDateTime(reader.GetValue(caso_fecha_creacionColumnIndex));
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					record.TIPO_TEXTO_PREDEFINIDO_NOMBRE = Convert.ToString(reader.GetValue(tipo_texto_predefinido_nombreColumnIndex));
					record.TEXTO_PREDEFINIDO = Convert.ToString(reader.GetValue(texto_predefinidoColumnIndex));
					if(!reader.IsDBNull(tituloColumnIndex))
						record.TITULO = Convert.ToString(reader.GetValue(tituloColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(hora_inicioColumnIndex))
						record.HORA_INICIO = Convert.ToString(reader.GetValue(hora_inicioColumnIndex));
					if(!reader.IsDBNull(hora_finColumnIndex))
						record.HORA_FIN = Convert.ToString(reader.GetValue(hora_finColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));
					if(!reader.IsDBNull(caso_originario_idColumnIndex))
						record.CASO_ORIGINARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_originario_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_originario_flujo_idColumnIndex))
						record.CASO_ORIGINARIO_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_originario_flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_originario_flujo_descColumnIndex))
						record.CASO_ORIGINARIO_FLUJO_DESC = Convert.ToString(reader.GetValue(caso_originario_flujo_descColumnIndex));
					record.DEBE_FACTURAR = Convert.ToString(reader.GetValue(debe_facturarColumnIndex));
					record.VISTO_BUENO_FUNCIONARIO = Convert.ToString(reader.GetValue(visto_bueno_funcionarioColumnIndex));
					record.VISTO_BUENO_PERSONA = Convert.ToString(reader.GetValue(visto_bueno_personaColumnIndex));
					record.VISTO_BUENO_GERENCIA = Convert.ToString(reader.GetValue(visto_bueno_gerenciaColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_timbradoColumnIndex))
						record.AUTONUMERACION_TIMBRADO = Convert.ToString(reader.GetValue(autonumeracion_timbradoColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(tiene_caso_considerado_pagoColumnIndex))
						record.TIENE_CASO_CONSIDERADO_PAGO = Convert.ToString(reader.GetValue(tiene_caso_considerado_pagoColumnIndex));
					record.ES_PARA_CLIENTE = Convert.ToString(reader.GetValue(es_para_clienteColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_razon_socialColumnIndex))
						record.PROVEEDOR_RAZON_SOCIAL = Convert.ToString(reader.GetValue(proveedor_razon_socialColumnIndex));
					if(!reader.IsDBNull(total_cantidad_horasColumnIndex))
						record.TOTAL_CANTIDAD_HORAS = Math.Round(Convert.ToDecimal(reader.GetValue(total_cantidad_horasColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costos_nombreColumnIndex))
						record.CENTRO_COSTOS_NOMBRE = Convert.ToString(reader.GetValue(centro_costos_nombreColumnIndex));
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_pago_nombreColumnIndex))
						record.CONDICION_PAGO_NOMBRE = Convert.ToString(reader.GetValue(condicion_pago_nombreColumnIndex));
					if(!reader.IsDBNull(anticipo_requeridoColumnIndex))
						record.ANTICIPO_REQUERIDO = Convert.ToString(reader.GetValue(anticipo_requeridoColumnIndex));
					if(!reader.IsDBNull(anticipo_generarColumnIndex))
						record.ANTICIPO_GENERAR = Convert.ToString(reader.GetValue(anticipo_generarColumnIndex));
					if(!reader.IsDBNull(anticipo_montoColumnIndex))
						record.ANTICIPO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(anticipo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(aplicar_retencionColumnIndex))
						record.APLICAR_RETENCION = Convert.ToString(reader.GetValue(aplicar_retencionColumnIndex));
					if(!reader.IsDBNull(factura_detalladaColumnIndex))
						record.FACTURA_DETALLADA = Convert.ToString(reader.GetValue(factura_detalladaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_SERVICIO_INFO_COMPLETARow[])(recordList.ToArray(typeof(ORDENES_SERVICIO_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_SERVICIO_INFO_COMPLETARow"/> object.</returns>
		protected virtual ORDENES_SERVICIO_INFO_COMPLETARow MapRow(DataRow row)
		{
			ORDENES_SERVICIO_INFO_COMPLETARow mappedObject = new ORDENES_SERVICIO_INFO_COMPLETARow();
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
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "TIPO_TEXTO_PREDEFINIDO_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_TEXTO_PREDEFINIDO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_TEXTO_PREDEFINIDO_NOMBRE = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO = (string)row[dataColumn];
			// Column "TITULO"
			dataColumn = dataTable.Columns["TITULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULO = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "HORA_INICIO"
			dataColumn = dataTable.Columns["HORA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_INICIO = (string)row[dataColumn];
			// Column "HORA_FIN"
			dataColumn = dataTable.Columns["HORA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_FIN = (string)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			// Column "CASO_ORIGINARIO_ID"
			dataColumn = dataTable.Columns["CASO_ORIGINARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGINARIO_ID = (decimal)row[dataColumn];
			// Column "CASO_ORIGINARIO_FLUJO_ID"
			dataColumn = dataTable.Columns["CASO_ORIGINARIO_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGINARIO_FLUJO_ID = (decimal)row[dataColumn];
			// Column "CASO_ORIGINARIO_FLUJO_DESC"
			dataColumn = dataTable.Columns["CASO_ORIGINARIO_FLUJO_DESC"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGINARIO_FLUJO_DESC = (string)row[dataColumn];
			// Column "DEBE_FACTURAR"
			dataColumn = dataTable.Columns["DEBE_FACTURAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBE_FACTURAR = (string)row[dataColumn];
			// Column "VISTO_BUENO_FUNCIONARIO"
			dataColumn = dataTable.Columns["VISTO_BUENO_FUNCIONARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VISTO_BUENO_FUNCIONARIO = (string)row[dataColumn];
			// Column "VISTO_BUENO_PERSONA"
			dataColumn = dataTable.Columns["VISTO_BUENO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VISTO_BUENO_PERSONA = (string)row[dataColumn];
			// Column "VISTO_BUENO_GERENCIA"
			dataColumn = dataTable.Columns["VISTO_BUENO_GERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VISTO_BUENO_GERENCIA = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_TIMBRADO"
			dataColumn = dataTable.Columns["AUTONUMERACION_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_TIMBRADO = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "TIENE_CASO_CONSIDERADO_PAGO"
			dataColumn = dataTable.Columns["TIENE_CASO_CONSIDERADO_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIENE_CASO_CONSIDERADO_PAGO = (string)row[dataColumn];
			// Column "ES_PARA_CLIENTE"
			dataColumn = dataTable.Columns["ES_PARA_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_PARA_CLIENTE = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_RAZON_SOCIAL"
			dataColumn = dataTable.Columns["PROVEEDOR_RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_RAZON_SOCIAL = (string)row[dataColumn];
			// Column "TOTAL_CANTIDAD_HORAS"
			dataColumn = dataTable.Columns["TOTAL_CANTIDAD_HORAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CANTIDAD_HORAS = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "CENTRO_COSTOS_NOMBRE"
			dataColumn = dataTable.Columns["CENTRO_COSTOS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTOS_NOMBRE = (string)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO_NOMBRE"
			dataColumn = dataTable.Columns["CONDICION_PAGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_NOMBRE = (string)row[dataColumn];
			// Column "ANTICIPO_REQUERIDO"
			dataColumn = dataTable.Columns["ANTICIPO_REQUERIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_REQUERIDO = (string)row[dataColumn];
			// Column "ANTICIPO_GENERAR"
			dataColumn = dataTable.Columns["ANTICIPO_GENERAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_GENERAR = (string)row[dataColumn];
			// Column "ANTICIPO_MONTO"
			dataColumn = dataTable.Columns["ANTICIPO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANTICIPO_MONTO = (decimal)row[dataColumn];
			// Column "APLICAR_RETENCION"
			dataColumn = dataTable.Columns["APLICAR_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICAR_RETENCION = (string)row[dataColumn];
			// Column "FACTURA_DETALLADA"
			dataColumn = dataTable.Columns["FACTURA_DETALLADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_DETALLADA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_SERVICIO_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_SERVICIO_INFO_COMPLETA";
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
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_TEXTO_PREDEFINIDO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TITULO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HORA_INICIO", typeof(string));
			dataColumn.MaxLength = 8;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HORA_FIN", typeof(string));
			dataColumn.MaxLength = 8;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ORIGINARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ORIGINARIO_FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ORIGINARIO_FLUJO_DESC", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEBE_FACTURAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VISTO_BUENO_FUNCIONARIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VISTO_BUENO_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VISTO_BUENO_GERENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIENE_CASO_CONSIDERADO_PAGO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_PARA_CLIENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CANTIDAD_HORAS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTOS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 131;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANTICIPO_REQUERIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANTICIPO_GENERAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANTICIPO_MONTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APLICAR_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_DETALLADA", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_TEXTO_PREDEFINIDO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TITULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "HORA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "HORA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_ORIGINARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ORIGINARIO_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ORIGINARIO_FLUJO_DESC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEBE_FACTURAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VISTO_BUENO_FUNCIONARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VISTO_BUENO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VISTO_BUENO_GERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIENE_CASO_CONSIDERADO_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_PARA_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_CANTIDAD_HORAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTOS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ANTICIPO_REQUERIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ANTICIPO_GENERAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ANTICIPO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICAR_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FACTURA_DETALLADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_SERVICIO_INFO_COMPLETACollection_Base class
}  // End of namespace
