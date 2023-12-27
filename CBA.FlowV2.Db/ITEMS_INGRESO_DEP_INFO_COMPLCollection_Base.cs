// <fileinfo name="ITEMS_INGRESO_DEP_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESO_DEP_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_INGRESO_DEP_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESO_DEP_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEMS_INGRESO_IDColumnName = "ITEMS_INGRESO_ID";
		public const string FECHA_INGRESOColumnName = "FECHA_INGRESO";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string GENERACION_CONFIRMADAColumnName = "GENERACION_CONFIRMADA";
		public const string INGRESO_CONFIRMADOColumnName = "INGRESO_CONFIRMADO";
		public const string NUMERO_COMPROBANTEColumnName = "NUMERO_COMPROBANTE";
		public const string PRECINTOSColumnName = "PRECINTOS";
		public const string INICIOColumnName = "INICIO";
		public const string FINColumnName = "FIN";
		public const string DESPACHOColumnName = "DESPACHO";
		public const string IDA3ColumnName = "IDA3";
		public const string ICColumnName = "IC";
		public const string OTROSColumnName = "OTROS";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string MIC_DTAColumnName = "MIC_DTA";
		public const string PESO_MANIFESTADOColumnName = "PESO_MANIFESTADO";
		public const string FCL_LCLColumnName = "FCL_LCL";
		public const string FECHA_INGRESO_PUERTOColumnName = "FECHA_INGRESO_PUERTO";
		public const string CHAPAColumnName = "CHAPA";
		public const string TIPO_CAMION_NOMBREColumnName = "TIPO_CAMION_NOMBRE";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string SEMANAColumnName = "SEMANA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESO_DEP_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_INGRESO_DEP_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_INGRESO_DEP_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEP_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_INGRESO_DEP_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_INGRESO_DEP_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_INGRESO_DEP_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_INGRESO_DEP_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects.</returns>
		public ITEMS_INGRESO_DEP_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEP_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_INGRESO_DEP_INFO_COMPL";
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects.</returns>
		protected ITEMS_INGRESO_DEP_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects.</returns>
		protected ITEMS_INGRESO_DEP_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> objects.</returns>
		protected virtual ITEMS_INGRESO_DEP_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int items_ingreso_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_ID");
			int fecha_ingresoColumnIndex = reader.GetOrdinal("FECHA_INGRESO");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int generacion_confirmadaColumnIndex = reader.GetOrdinal("GENERACION_CONFIRMADA");
			int ingreso_confirmadoColumnIndex = reader.GetOrdinal("INGRESO_CONFIRMADO");
			int numero_comprobanteColumnIndex = reader.GetOrdinal("NUMERO_COMPROBANTE");
			int precintosColumnIndex = reader.GetOrdinal("PRECINTOS");
			int inicioColumnIndex = reader.GetOrdinal("INICIO");
			int finColumnIndex = reader.GetOrdinal("FIN");
			int despachoColumnIndex = reader.GetOrdinal("DESPACHO");
			int ida3ColumnIndex = reader.GetOrdinal("IDA3");
			int icColumnIndex = reader.GetOrdinal("IC");
			int otrosColumnIndex = reader.GetOrdinal("OTROS");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int mic_dtaColumnIndex = reader.GetOrdinal("MIC_DTA");
			int peso_manifestadoColumnIndex = reader.GetOrdinal("PESO_MANIFESTADO");
			int fcl_lclColumnIndex = reader.GetOrdinal("FCL_LCL");
			int fecha_ingreso_puertoColumnIndex = reader.GetOrdinal("FECHA_INGRESO_PUERTO");
			int chapaColumnIndex = reader.GetOrdinal("CHAPA");
			int tipo_camion_nombreColumnIndex = reader.GetOrdinal("TIPO_CAMION_NOMBRE");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_INGRESO_DEP_INFO_COMPLRow record = new ITEMS_INGRESO_DEP_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingreso_idColumnIndex))
						record.ITEMS_INGRESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ingresoColumnIndex))
						record.FECHA_INGRESO = Convert.ToDateTime(reader.GetValue(fecha_ingresoColumnIndex));
					if(!reader.IsDBNull(fecha_emisionColumnIndex))
						record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(generacion_confirmadaColumnIndex))
						record.GENERACION_CONFIRMADA = Convert.ToString(reader.GetValue(generacion_confirmadaColumnIndex));
					if(!reader.IsDBNull(ingreso_confirmadoColumnIndex))
						record.INGRESO_CONFIRMADO = Convert.ToString(reader.GetValue(ingreso_confirmadoColumnIndex));
					if(!reader.IsDBNull(numero_comprobanteColumnIndex))
						record.NUMERO_COMPROBANTE = Convert.ToString(reader.GetValue(numero_comprobanteColumnIndex));
					if(!reader.IsDBNull(precintosColumnIndex))
						record.PRECINTOS = Convert.ToString(reader.GetValue(precintosColumnIndex));
					if(!reader.IsDBNull(inicioColumnIndex))
						record.INICIO = Convert.ToDateTime(reader.GetValue(inicioColumnIndex));
					if(!reader.IsDBNull(finColumnIndex))
						record.FIN = Convert.ToDateTime(reader.GetValue(finColumnIndex));
					if(!reader.IsDBNull(despachoColumnIndex))
						record.DESPACHO = Convert.ToString(reader.GetValue(despachoColumnIndex));
					if(!reader.IsDBNull(ida3ColumnIndex))
						record.IDA3 = Convert.ToString(reader.GetValue(ida3ColumnIndex));
					if(!reader.IsDBNull(icColumnIndex))
						record.IC = Convert.ToString(reader.GetValue(icColumnIndex));
					if(!reader.IsDBNull(otrosColumnIndex))
						record.OTROS = Convert.ToString(reader.GetValue(otrosColumnIndex));
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(mic_dtaColumnIndex))
						record.MIC_DTA = Convert.ToString(reader.GetValue(mic_dtaColumnIndex));
					if(!reader.IsDBNull(peso_manifestadoColumnIndex))
						record.PESO_MANIFESTADO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_manifestadoColumnIndex)), 9);
					if(!reader.IsDBNull(fcl_lclColumnIndex))
						record.FCL_LCL = Convert.ToString(reader.GetValue(fcl_lclColumnIndex));
					if(!reader.IsDBNull(fecha_ingreso_puertoColumnIndex))
						record.FECHA_INGRESO_PUERTO = Convert.ToDateTime(reader.GetValue(fecha_ingreso_puertoColumnIndex));
					if(!reader.IsDBNull(chapaColumnIndex))
						record.CHAPA = Convert.ToString(reader.GetValue(chapaColumnIndex));
					if(!reader.IsDBNull(tipo_camion_nombreColumnIndex))
						record.TIPO_CAMION_NOMBRE = Convert.ToString(reader.GetValue(tipo_camion_nombreColumnIndex));
					if(!reader.IsDBNull(contenedor_numeroColumnIndex))
						record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_INGRESO_DEP_INFO_COMPLRow[])(recordList.ToArray(typeof(ITEMS_INGRESO_DEP_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> object.</returns>
		protected virtual ITEMS_INGRESO_DEP_INFO_COMPLRow MapRow(DataRow row)
		{
			ITEMS_INGRESO_DEP_INFO_COMPLRow mappedObject = new ITEMS_INGRESO_DEP_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESO_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_ID = (decimal)row[dataColumn];
			// Column "FECHA_INGRESO"
			dataColumn = dataTable.Columns["FECHA_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO = (System.DateTime)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "GENERACION_CONFIRMADA"
			dataColumn = dataTable.Columns["GENERACION_CONFIRMADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERACION_CONFIRMADA = (string)row[dataColumn];
			// Column "INGRESO_CONFIRMADO"
			dataColumn = dataTable.Columns["INGRESO_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_CONFIRMADO = (string)row[dataColumn];
			// Column "NUMERO_COMPROBANTE"
			dataColumn = dataTable.Columns["NUMERO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_COMPROBANTE = (string)row[dataColumn];
			// Column "PRECINTOS"
			dataColumn = dataTable.Columns["PRECINTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTOS = (string)row[dataColumn];
			// Column "INICIO"
			dataColumn = dataTable.Columns["INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INICIO = (System.DateTime)row[dataColumn];
			// Column "FIN"
			dataColumn = dataTable.Columns["FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FIN = (System.DateTime)row[dataColumn];
			// Column "DESPACHO"
			dataColumn = dataTable.Columns["DESPACHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO = (string)row[dataColumn];
			// Column "IDA3"
			dataColumn = dataTable.Columns["IDA3"];
			if(!row.IsNull(dataColumn))
				mappedObject.IDA3 = (string)row[dataColumn];
			// Column "IC"
			dataColumn = dataTable.Columns["IC"];
			if(!row.IsNull(dataColumn))
				mappedObject.IC = (string)row[dataColumn];
			// Column "OTROS"
			dataColumn = dataTable.Columns["OTROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.OTROS = (string)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "MIC_DTA"
			dataColumn = dataTable.Columns["MIC_DTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MIC_DTA = (string)row[dataColumn];
			// Column "PESO_MANIFESTADO"
			dataColumn = dataTable.Columns["PESO_MANIFESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MANIFESTADO = (decimal)row[dataColumn];
			// Column "FCL_LCL"
			dataColumn = dataTable.Columns["FCL_LCL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FCL_LCL = (string)row[dataColumn];
			// Column "FECHA_INGRESO_PUERTO"
			dataColumn = dataTable.Columns["FECHA_INGRESO_PUERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO_PUERTO = (System.DateTime)row[dataColumn];
			// Column "CHAPA"
			dataColumn = dataTable.Columns["CHAPA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA = (string)row[dataColumn];
			// Column "TIPO_CAMION_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_CAMION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CAMION_NOMBRE = (string)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_INGRESO_DEP_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_INGRESO_DEP_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERACION_CONFIRMADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTOS", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INICIO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FIN", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IDA3", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IC", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OTROS", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MIC_DTA", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_MANIFESTADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FCL_LCL", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO_PUERTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA", typeof(string));
			dataColumn.MaxLength = 21;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CAMION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
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

				case "ITEMS_INGRESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "GENERACION_CONFIRMADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INGRESO_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NUMERO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESPACHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IDA3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OTROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MIC_DTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO_MANIFESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FCL_LCL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INGRESO_PUERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHAPA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CAMION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_INGRESO_DEP_INFO_COMPLCollection_Base class
}  // End of namespace
