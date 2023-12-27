// <fileinfo name="GEN_FC_CLIE_PERS_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="GEN_FC_CLIE_PERS_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="GEN_FC_CLIE_PERS_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GEN_FC_CLIE_PERS_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string PERSONA_DOCUMENTOColumnName = "PERSONA_DOCUMENTO";
		public const string GENERACION_FC_CLIENTE_IDColumnName = "GENERACION_FC_CLIENTE_ID";
		public const string CONDICION_IDColumnName = "CONDICION_ID";
		public const string CONDICION_NOMBREColumnName = "CONDICION_NOMBRE";
		public const string FUNCIONARIO_VENDEDOR_IDColumnName = "FUNCIONARIO_VENDEDOR_ID";
		public const string FECHAColumnName = "FECHA";
		public const string FACTURA_GENERADAColumnName = "FACTURA_GENERADA";
		public const string FUNCIONARIO_CODIGOColumnName = "FUNCIONARIO_CODIGO";
		public const string FUNCIONARIO_NOMBREColumnName = "FUNCIONARIO_NOMBRE";
		public const string CASO_FACTURA_GENERADA_IDColumnName = "CASO_FACTURA_GENERADA_ID";
		public const string CASO_ESTADOColumnName = "CASO_ESTADO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CANTIDADES_DECIMALESColumnName = "MONEDA_CANTIDADES_DECIMALES";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string AUTONUMERACION_CODIGOColumnName = "AUTONUMERACION_CODIGO";
		public const string AUTONUMERACION_TIMBRADOColumnName = "AUTONUMERACION_TIMBRADO";
		public const string ANULADAColumnName = "ANULADA";
		public const string PAGADAColumnName = "PAGADA";
		public const string AFECTA_STOCKColumnName = "AFECTA_STOCK";
		public const string AFECTA_CTACTEColumnName = "AFECTA_CTACTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="GEN_FC_CLIE_PERS_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public GEN_FC_CLIE_PERS_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>GEN_FC_CLIE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects.</returns>
		public virtual GEN_FC_CLIE_PERS_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>GEN_FC_CLIE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>GEN_FC_CLIE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public GEN_FC_CLIE_PERS_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			GEN_FC_CLIE_PERS_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects.</returns>
		public GEN_FC_CLIE_PERS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects.</returns>
		public virtual GEN_FC_CLIE_PERS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.GEN_FC_CLIE_PERS_INFO_COMPL";
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects.</returns>
		protected GEN_FC_CLIE_PERS_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects.</returns>
		protected GEN_FC_CLIE_PERS_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> objects.</returns>
		protected virtual GEN_FC_CLIE_PERS_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int persona_documentoColumnIndex = reader.GetOrdinal("PERSONA_DOCUMENTO");
			int generacion_fc_cliente_idColumnIndex = reader.GetOrdinal("GENERACION_FC_CLIENTE_ID");
			int condicion_idColumnIndex = reader.GetOrdinal("CONDICION_ID");
			int condicion_nombreColumnIndex = reader.GetOrdinal("CONDICION_NOMBRE");
			int funcionario_vendedor_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_VENDEDOR_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int factura_generadaColumnIndex = reader.GetOrdinal("FACTURA_GENERADA");
			int funcionario_codigoColumnIndex = reader.GetOrdinal("FUNCIONARIO_CODIGO");
			int funcionario_nombreColumnIndex = reader.GetOrdinal("FUNCIONARIO_NOMBRE");
			int caso_factura_generada_idColumnIndex = reader.GetOrdinal("CASO_FACTURA_GENERADA_ID");
			int caso_estadoColumnIndex = reader.GetOrdinal("CASO_ESTADO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cantidades_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDADES_DECIMALES");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int autonumeracion_codigoColumnIndex = reader.GetOrdinal("AUTONUMERACION_CODIGO");
			int autonumeracion_timbradoColumnIndex = reader.GetOrdinal("AUTONUMERACION_TIMBRADO");
			int anuladaColumnIndex = reader.GetOrdinal("ANULADA");
			int pagadaColumnIndex = reader.GetOrdinal("PAGADA");
			int afecta_stockColumnIndex = reader.GetOrdinal("AFECTA_STOCK");
			int afecta_ctacteColumnIndex = reader.GetOrdinal("AFECTA_CTACTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					GEN_FC_CLIE_PERS_INFO_COMPLRow record = new GEN_FC_CLIE_PERS_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(persona_documentoColumnIndex))
						record.PERSONA_DOCUMENTO = Convert.ToString(reader.GetValue(persona_documentoColumnIndex));
					record.GENERACION_FC_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(generacion_fc_cliente_idColumnIndex)), 9);
					record.CONDICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_idColumnIndex)), 9);
					record.CONDICION_NOMBRE = Convert.ToString(reader.GetValue(condicion_nombreColumnIndex));
					if(!reader.IsDBNull(funcionario_vendedor_idColumnIndex))
						record.FUNCIONARIO_VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_vendedor_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.FACTURA_GENERADA = Convert.ToString(reader.GetValue(factura_generadaColumnIndex));
					if(!reader.IsDBNull(funcionario_codigoColumnIndex))
						record.FUNCIONARIO_CODIGO = Convert.ToString(reader.GetValue(funcionario_codigoColumnIndex));
					if(!reader.IsDBNull(funcionario_nombreColumnIndex))
						record.FUNCIONARIO_NOMBRE = Convert.ToString(reader.GetValue(funcionario_nombreColumnIndex));
					if(!reader.IsDBNull(caso_factura_generada_idColumnIndex))
						record.CASO_FACTURA_GENERADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_factura_generada_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_estadoColumnIndex))
						record.CASO_ESTADO = Convert.ToString(reader.GetValue(caso_estadoColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_nombreColumnIndex))
						record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_simboloColumnIndex))
						record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(moneda_cantidades_decimalesColumnIndex))
						record.MONEDA_CANTIDADES_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidades_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_codigoColumnIndex))
						record.AUTONUMERACION_CODIGO = Convert.ToString(reader.GetValue(autonumeracion_codigoColumnIndex));
					if(!reader.IsDBNull(autonumeracion_timbradoColumnIndex))
						record.AUTONUMERACION_TIMBRADO = Convert.ToString(reader.GetValue(autonumeracion_timbradoColumnIndex));
					record.ANULADA = Convert.ToString(reader.GetValue(anuladaColumnIndex));
					record.PAGADA = Convert.ToString(reader.GetValue(pagadaColumnIndex));
					record.AFECTA_STOCK = Convert.ToString(reader.GetValue(afecta_stockColumnIndex));
					record.AFECTA_CTACTE = Convert.ToString(reader.GetValue(afecta_ctacteColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (GEN_FC_CLIE_PERS_INFO_COMPLRow[])(recordList.ToArray(typeof(GEN_FC_CLIE_PERS_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="GEN_FC_CLIE_PERS_INFO_COMPLRow"/> object.</returns>
		protected virtual GEN_FC_CLIE_PERS_INFO_COMPLRow MapRow(DataRow row)
		{
			GEN_FC_CLIE_PERS_INFO_COMPLRow mappedObject = new GEN_FC_CLIE_PERS_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_DOCUMENTO"
			dataColumn = dataTable.Columns["PERSONA_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DOCUMENTO = (string)row[dataColumn];
			// Column "GENERACION_FC_CLIENTE_ID"
			dataColumn = dataTable.Columns["GENERACION_FC_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERACION_FC_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "CONDICION_ID"
			dataColumn = dataTable.Columns["CONDICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_ID = (decimal)row[dataColumn];
			// Column "CONDICION_NOMBRE"
			dataColumn = dataTable.Columns["CONDICION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_NOMBRE = (string)row[dataColumn];
			// Column "FUNCIONARIO_VENDEDOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FACTURA_GENERADA"
			dataColumn = dataTable.Columns["FACTURA_GENERADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_GENERADA = (string)row[dataColumn];
			// Column "FUNCIONARIO_CODIGO"
			dataColumn = dataTable.Columns["FUNCIONARIO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_CODIGO = (string)row[dataColumn];
			// Column "FUNCIONARIO_NOMBRE"
			dataColumn = dataTable.Columns["FUNCIONARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_NOMBRE = (string)row[dataColumn];
			// Column "CASO_FACTURA_GENERADA_ID"
			dataColumn = dataTable.Columns["CASO_FACTURA_GENERADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FACTURA_GENERADA_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO"
			dataColumn = dataTable.Columns["CASO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO = (string)row[dataColumn];
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
			// Column "MONEDA_CANTIDADES_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDADES_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDADES_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_CODIGO"
			dataColumn = dataTable.Columns["AUTONUMERACION_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_CODIGO = (string)row[dataColumn];
			// Column "AUTONUMERACION_TIMBRADO"
			dataColumn = dataTable.Columns["AUTONUMERACION_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_TIMBRADO = (string)row[dataColumn];
			// Column "ANULADA"
			dataColumn = dataTable.Columns["ANULADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANULADA = (string)row[dataColumn];
			// Column "PAGADA"
			dataColumn = dataTable.Columns["PAGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGADA = (string)row[dataColumn];
			// Column "AFECTA_STOCK"
			dataColumn = dataTable.Columns["AFECTA_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_STOCK = (string)row[dataColumn];
			// Column "AFECTA_CTACTE"
			dataColumn = dataTable.Columns["AFECTA_CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>GEN_FC_CLIE_PERS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "GEN_FC_CLIE_PERS_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERACION_FC_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_VENDEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_GENERADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 140;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_FACTURA_GENERADA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDADES_DECIMALES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_CODIGO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANULADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAGADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE", typeof(string));
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GENERACION_FC_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_GENERADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FUNCIONARIO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_FACTURA_GENERADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO":
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

				case "MONEDA_CANTIDADES_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ANULADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PAGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CTACTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of GEN_FC_CLIE_PERS_INFO_COMPLCollection_Base class
}  // End of namespace
