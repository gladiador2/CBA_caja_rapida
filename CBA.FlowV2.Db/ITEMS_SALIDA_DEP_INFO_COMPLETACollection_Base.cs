// <fileinfo name="ITEMS_SALIDA_DEP_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_SALIDA_DEP_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEMS_INGRESOS_DETALLES_IDColumnName = "ITEMS_INGRESOS_DETALLES_ID";
		public const string CONOCIMIENTOColumnName = "CONOCIMIENTO";
		public const string MIC_DTAColumnName = "MIC_DTA";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FACTURA_PERSONA_IDColumnName = "FACTURA_PERSONA_ID";
		public const string FACTURA_CASOColumnName = "FACTURA_CASO";
		public const string FACTURA_FECHAColumnName = "FACTURA_FECHA";
		public const string FACTURA_NUMEROColumnName = "FACTURA_NUMERO";
		public const string CONSIGNATARIO_PERSONA_IDColumnName = "CONSIGNATARIO_PERSONA_ID";
		public const string CONSIGNATARIO_CODIGOColumnName = "CONSIGNATARIO_CODIGO";
		public const string CONSIGANATARIO_NOMBREColumnName = "CONSIGANATARIO_NOMBRE";
		public const string CONSIGANATARIO_DOCUMENTOColumnName = "CONSIGANATARIO_DOCUMENTO";
		public const string DESPACHANTEColumnName = "DESPACHANTE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string VENCIMIENTOColumnName = "VENCIMIENTO";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string MERCADERIAColumnName = "MERCADERIA";
		public const string TIPO_BULTOColumnName = "TIPO_BULTO";
		public const string DESPACHOColumnName = "DESPACHO";
		public const string GENERACION_CONFIRMADAColumnName = "GENERACION_CONFIRMADA";
		public const string SALIDA_CONFIRMADAColumnName = "SALIDA_CONFIRMADA";
		public const string ES_EXTENSIONColumnName = "ES_EXTENSION";
		public const string ITEM_SALIDA_DEPOSITO_ORIGEN_IDColumnName = "ITEM_SALIDA_DEPOSITO_ORIGEN_ID";
		public const string BOLETA_SALIDA_ORIGENColumnName = "BOLETA_SALIDA_ORIGEN";
		public const string SEMANAColumnName = "SEMANA";
		public const string RAZON_TEXTOS_PREDEFINIDOS_IDColumnName = "RAZON_TEXTOS_PREDEFINIDOS_ID";
		public const string RAZON_TEXTO_PREDEFINIDO_NOMBREColumnName = "RAZON_TEXTO_PREDEFINIDO_NOMBRE";
		public const string DESPACHANTE_PERSONA_IDColumnName = "DESPACHANTE_PERSONA_ID";
		public const string IMPRESOColumnName = "IMPRESO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_SALIDA_DEP_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_SALIDA_DEP_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEP_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_SALIDA_DEP_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_SALIDA_DEP_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_SALIDA_DEP_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_SALIDA_DEP_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects.</returns>
		public ITEMS_SALIDA_DEP_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEP_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_SALIDA_DEP_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects.</returns>
		protected ITEMS_SALIDA_DEP_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects.</returns>
		protected ITEMS_SALIDA_DEP_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> objects.</returns>
		protected virtual ITEMS_SALIDA_DEP_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int items_ingresos_detalles_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESOS_DETALLES_ID");
			int conocimientoColumnIndex = reader.GetOrdinal("CONOCIMIENTO");
			int mic_dtaColumnIndex = reader.GetOrdinal("MIC_DTA");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int factura_persona_idColumnIndex = reader.GetOrdinal("FACTURA_PERSONA_ID");
			int factura_casoColumnIndex = reader.GetOrdinal("FACTURA_CASO");
			int factura_fechaColumnIndex = reader.GetOrdinal("FACTURA_FECHA");
			int factura_numeroColumnIndex = reader.GetOrdinal("FACTURA_NUMERO");
			int consignatario_persona_idColumnIndex = reader.GetOrdinal("CONSIGNATARIO_PERSONA_ID");
			int consignatario_codigoColumnIndex = reader.GetOrdinal("CONSIGNATARIO_CODIGO");
			int consiganatario_nombreColumnIndex = reader.GetOrdinal("CONSIGANATARIO_NOMBRE");
			int consiganatario_documentoColumnIndex = reader.GetOrdinal("CONSIGANATARIO_DOCUMENTO");
			int despachanteColumnIndex = reader.GetOrdinal("DESPACHANTE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int vencimientoColumnIndex = reader.GetOrdinal("VENCIMIENTO");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");
			int tipo_bultoColumnIndex = reader.GetOrdinal("TIPO_BULTO");
			int despachoColumnIndex = reader.GetOrdinal("DESPACHO");
			int generacion_confirmadaColumnIndex = reader.GetOrdinal("GENERACION_CONFIRMADA");
			int salida_confirmadaColumnIndex = reader.GetOrdinal("SALIDA_CONFIRMADA");
			int es_extensionColumnIndex = reader.GetOrdinal("ES_EXTENSION");
			int item_salida_deposito_origen_idColumnIndex = reader.GetOrdinal("ITEM_SALIDA_DEPOSITO_ORIGEN_ID");
			int boleta_salida_origenColumnIndex = reader.GetOrdinal("BOLETA_SALIDA_ORIGEN");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");
			int razon_textos_predefinidos_idColumnIndex = reader.GetOrdinal("RAZON_TEXTOS_PREDEFINIDOS_ID");
			int razon_texto_predefinido_nombreColumnIndex = reader.GetOrdinal("RAZON_TEXTO_PREDEFINIDO_NOMBRE");
			int despachante_persona_idColumnIndex = reader.GetOrdinal("DESPACHANTE_PERSONA_ID");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_SALIDA_DEP_INFO_COMPLETARow record = new ITEMS_SALIDA_DEP_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingresos_detalles_idColumnIndex))
						record.ITEMS_INGRESOS_DETALLES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingresos_detalles_idColumnIndex)), 9);
					if(!reader.IsDBNull(conocimientoColumnIndex))
						record.CONOCIMIENTO = Convert.ToString(reader.GetValue(conocimientoColumnIndex));
					if(!reader.IsDBNull(mic_dtaColumnIndex))
						record.MIC_DTA = Convert.ToString(reader.GetValue(mic_dtaColumnIndex));
					if(!reader.IsDBNull(fecha_emisionColumnIndex))
						record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(factura_persona_idColumnIndex))
						record.FACTURA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(factura_casoColumnIndex))
						record.FACTURA_CASO = Math.Round(Convert.ToDecimal(reader.GetValue(factura_casoColumnIndex)), 9);
					if(!reader.IsDBNull(factura_fechaColumnIndex))
						record.FACTURA_FECHA = Convert.ToDateTime(reader.GetValue(factura_fechaColumnIndex));
					if(!reader.IsDBNull(factura_numeroColumnIndex))
						record.FACTURA_NUMERO = Convert.ToString(reader.GetValue(factura_numeroColumnIndex));
					if(!reader.IsDBNull(consignatario_persona_idColumnIndex))
						record.CONSIGNATARIO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(consignatario_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_codigoColumnIndex))
						record.CONSIGNATARIO_CODIGO = Convert.ToString(reader.GetValue(consignatario_codigoColumnIndex));
					if(!reader.IsDBNull(consiganatario_nombreColumnIndex))
						record.CONSIGANATARIO_NOMBRE = Convert.ToString(reader.GetValue(consiganatario_nombreColumnIndex));
					if(!reader.IsDBNull(consiganatario_documentoColumnIndex))
						record.CONSIGANATARIO_DOCUMENTO = Convert.ToString(reader.GetValue(consiganatario_documentoColumnIndex));
					if(!reader.IsDBNull(despachanteColumnIndex))
						record.DESPACHANTE = Convert.ToString(reader.GetValue(despachanteColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(vencimientoColumnIndex))
						record.VENCIMIENTO = Convert.ToDateTime(reader.GetValue(vencimientoColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));
					if(!reader.IsDBNull(tipo_bultoColumnIndex))
						record.TIPO_BULTO = Convert.ToString(reader.GetValue(tipo_bultoColumnIndex));
					if(!reader.IsDBNull(despachoColumnIndex))
						record.DESPACHO = Convert.ToString(reader.GetValue(despachoColumnIndex));
					if(!reader.IsDBNull(generacion_confirmadaColumnIndex))
						record.GENERACION_CONFIRMADA = Convert.ToString(reader.GetValue(generacion_confirmadaColumnIndex));
					if(!reader.IsDBNull(salida_confirmadaColumnIndex))
						record.SALIDA_CONFIRMADA = Convert.ToString(reader.GetValue(salida_confirmadaColumnIndex));
					if(!reader.IsDBNull(es_extensionColumnIndex))
						record.ES_EXTENSION = Convert.ToString(reader.GetValue(es_extensionColumnIndex));
					if(!reader.IsDBNull(item_salida_deposito_origen_idColumnIndex))
						record.ITEM_SALIDA_DEPOSITO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(item_salida_deposito_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(boleta_salida_origenColumnIndex))
						record.BOLETA_SALIDA_ORIGEN = Convert.ToString(reader.GetValue(boleta_salida_origenColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);
					if(!reader.IsDBNull(razon_textos_predefinidos_idColumnIndex))
						record.RAZON_TEXTOS_PREDEFINIDOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(razon_textos_predefinidos_idColumnIndex)), 9);
					if(!reader.IsDBNull(razon_texto_predefinido_nombreColumnIndex))
						record.RAZON_TEXTO_PREDEFINIDO_NOMBRE = Convert.ToString(reader.GetValue(razon_texto_predefinido_nombreColumnIndex));
					if(!reader.IsDBNull(despachante_persona_idColumnIndex))
						record.DESPACHANTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(despachante_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(impresoColumnIndex))
						record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_SALIDA_DEP_INFO_COMPLETARow[])(recordList.ToArray(typeof(ITEMS_SALIDA_DEP_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_SALIDA_DEP_INFO_COMPLETARow"/> object.</returns>
		protected virtual ITEMS_SALIDA_DEP_INFO_COMPLETARow MapRow(DataRow row)
		{
			ITEMS_SALIDA_DEP_INFO_COMPLETARow mappedObject = new ITEMS_SALIDA_DEP_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESOS_DETALLES_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESOS_DETALLES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESOS_DETALLES_ID = (decimal)row[dataColumn];
			// Column "CONOCIMIENTO"
			dataColumn = dataTable.Columns["CONOCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO = (string)row[dataColumn];
			// Column "MIC_DTA"
			dataColumn = dataTable.Columns["MIC_DTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MIC_DTA = (string)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FACTURA_PERSONA_ID"
			dataColumn = dataTable.Columns["FACTURA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "FACTURA_CASO"
			dataColumn = dataTable.Columns["FACTURA_CASO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_CASO = (decimal)row[dataColumn];
			// Column "FACTURA_FECHA"
			dataColumn = dataTable.Columns["FACTURA_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_FECHA = (System.DateTime)row[dataColumn];
			// Column "FACTURA_NUMERO"
			dataColumn = dataTable.Columns["FACTURA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_NUMERO = (string)row[dataColumn];
			// Column "CONSIGNATARIO_PERSONA_ID"
			dataColumn = dataTable.Columns["CONSIGNATARIO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_CODIGO"
			dataColumn = dataTable.Columns["CONSIGNATARIO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_CODIGO = (string)row[dataColumn];
			// Column "CONSIGANATARIO_NOMBRE"
			dataColumn = dataTable.Columns["CONSIGANATARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGANATARIO_NOMBRE = (string)row[dataColumn];
			// Column "CONSIGANATARIO_DOCUMENTO"
			dataColumn = dataTable.Columns["CONSIGANATARIO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGANATARIO_DOCUMENTO = (string)row[dataColumn];
			// Column "DESPACHANTE"
			dataColumn = dataTable.Columns["DESPACHANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHANTE = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "VENCIMIENTO"
			dataColumn = dataTable.Columns["VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "MERCADERIA"
			dataColumn = dataTable.Columns["MERCADERIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA = (string)row[dataColumn];
			// Column "TIPO_BULTO"
			dataColumn = dataTable.Columns["TIPO_BULTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_BULTO = (string)row[dataColumn];
			// Column "DESPACHO"
			dataColumn = dataTable.Columns["DESPACHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO = (string)row[dataColumn];
			// Column "GENERACION_CONFIRMADA"
			dataColumn = dataTable.Columns["GENERACION_CONFIRMADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERACION_CONFIRMADA = (string)row[dataColumn];
			// Column "SALIDA_CONFIRMADA"
			dataColumn = dataTable.Columns["SALIDA_CONFIRMADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALIDA_CONFIRMADA = (string)row[dataColumn];
			// Column "ES_EXTENSION"
			dataColumn = dataTable.Columns["ES_EXTENSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_EXTENSION = (string)row[dataColumn];
			// Column "ITEM_SALIDA_DEPOSITO_ORIGEN_ID"
			dataColumn = dataTable.Columns["ITEM_SALIDA_DEPOSITO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEM_SALIDA_DEPOSITO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "BOLETA_SALIDA_ORIGEN"
			dataColumn = dataTable.Columns["BOLETA_SALIDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOLETA_SALIDA_ORIGEN = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			// Column "RAZON_TEXTOS_PREDEFINIDOS_ID"
			dataColumn = dataTable.Columns["RAZON_TEXTOS_PREDEFINIDOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_TEXTOS_PREDEFINIDOS_ID = (decimal)row[dataColumn];
			// Column "RAZON_TEXTO_PREDEFINIDO_NOMBRE"
			dataColumn = dataTable.Columns["RAZON_TEXTO_PREDEFINIDO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_TEXTO_PREDEFINIDO_NOMBRE = (string)row[dataColumn];
			// Column "DESPACHANTE_PERSONA_ID"
			dataColumn = dataTable.Columns["DESPACHANTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHANTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_SALIDA_DEP_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_SALIDA_DEP_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESOS_DETALLES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MIC_DTA", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_CASO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGANATARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGANATARIO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHANTE", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_BULTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERACION_CONFIRMADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALIDA_CONFIRMADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_EXTENSION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEM_SALIDA_DEPOSITO_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BOLETA_SALIDA_ORIGEN", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RAZON_TEXTOS_PREDEFINIDOS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RAZON_TEXTO_PREDEFINIDO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHANTE_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
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

				case "ITEMS_INGRESOS_DETALLES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONOCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MIC_DTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_CASO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURA_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSIGNATARIO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSIGANATARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSIGANATARIO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MERCADERIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_BULTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GENERACION_CONFIRMADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SALIDA_CONFIRMADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_EXTENSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ITEM_SALIDA_DEPOSITO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BOLETA_SALIDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RAZON_TEXTOS_PREDEFINIDOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RAZON_TEXTO_PREDEFINIDO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHANTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_SALIDA_DEP_INFO_COMPLETACollection_Base class
}  // End of namespace
