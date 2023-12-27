// <fileinfo name="CONTENEDORES_OPERAC_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_OPERAC_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTENEDORES_OPERAC_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_OPERAC_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string OPERACIONColumnName = "OPERACION";
		public const string FECHAColumnName = "FECHA";
		public const string HORA_INICIOColumnName = "HORA_INICIO";
		public const string HORA_FINColumnName = "HORA_FIN";
		public const string NRO_FORMULARIOColumnName = "NRO_FORMULARIO";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string LINEA_NOMBREColumnName = "LINEA_NOMBRE";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string BL_NROColumnName = "BL_NRO";
		public const string BOOKINGColumnName = "BOOKING";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string CLASIFICACION_IDColumnName = "CLASIFICACION_ID";
		public const string CONTENEDOR_CLASEColumnName = "CONTENEDOR_CLASE";
		public const string ITEMColumnName = "ITEM";
		public const string MERCADERIA_INTERNAColumnName = "MERCADERIA_INTERNA";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string VENTILETEColumnName = "VENTILETE";
		public const string EDIColumnName = "EDI";
		public const string ESTADOColumnName = "ESTADO";
		public const string PROCESADOColumnName = "PROCESADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PISOColumnName = "PISO";
		public const string FONDOColumnName = "FONDO";
		public const string PANEL_DERECHOColumnName = "PANEL_DERECHO";
		public const string PANEL_IZQUIERDOColumnName = "PANEL_IZQUIERDO";
		public const string PUERTAColumnName = "PUERTA";
		public const string REFRIGERADOColumnName = "REFRIGERADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_OPERAC_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTENEDORES_OPERAC_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTENEDORES_OPERAC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects.</returns>
		public virtual CONTENEDORES_OPERAC_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTENEDORES_OPERAC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTENEDORES_OPERAC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTENEDORES_OPERAC_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTENEDORES_OPERAC_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects.</returns>
		public CONTENEDORES_OPERAC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects.</returns>
		public virtual CONTENEDORES_OPERAC_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTENEDORES_OPERAC_INFO_COMPL";
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects.</returns>
		protected CONTENEDORES_OPERAC_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects.</returns>
		protected CONTENEDORES_OPERAC_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> objects.</returns>
		protected virtual CONTENEDORES_OPERAC_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int operacionColumnIndex = reader.GetOrdinal("OPERACION");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int hora_inicioColumnIndex = reader.GetOrdinal("HORA_INICIO");
			int hora_finColumnIndex = reader.GetOrdinal("HORA_FIN");
			int nro_formularioColumnIndex = reader.GetOrdinal("NRO_FORMULARIO");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int linea_nombreColumnIndex = reader.GetOrdinal("LINEA_NOMBRE");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int bl_nroColumnIndex = reader.GetOrdinal("BL_NRO");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int clasificacion_idColumnIndex = reader.GetOrdinal("CLASIFICACION_ID");
			int contenedor_claseColumnIndex = reader.GetOrdinal("CONTENEDOR_CLASE");
			int itemColumnIndex = reader.GetOrdinal("ITEM");
			int mercaderia_internaColumnIndex = reader.GetOrdinal("MERCADERIA_INTERNA");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int ventileteColumnIndex = reader.GetOrdinal("VENTILETE");
			int ediColumnIndex = reader.GetOrdinal("EDI");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int procesadoColumnIndex = reader.GetOrdinal("PROCESADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int pisoColumnIndex = reader.GetOrdinal("PISO");
			int fondoColumnIndex = reader.GetOrdinal("FONDO");
			int panel_derechoColumnIndex = reader.GetOrdinal("PANEL_DERECHO");
			int panel_izquierdoColumnIndex = reader.GetOrdinal("PANEL_IZQUIERDO");
			int puertaColumnIndex = reader.GetOrdinal("PUERTA");
			int refrigeradoColumnIndex = reader.GetOrdinal("REFRIGERADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTENEDORES_OPERAC_INFO_COMPLRow record = new CONTENEDORES_OPERAC_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(operacionColumnIndex))
						record.OPERACION = Convert.ToString(reader.GetValue(operacionColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(hora_inicioColumnIndex))
						record.HORA_INICIO = Convert.ToDateTime(reader.GetValue(hora_inicioColumnIndex));
					if(!reader.IsDBNull(hora_finColumnIndex))
						record.HORA_FIN = Convert.ToDateTime(reader.GetValue(hora_finColumnIndex));
					if(!reader.IsDBNull(nro_formularioColumnIndex))
						record.NRO_FORMULARIO = Convert.ToString(reader.GetValue(nro_formularioColumnIndex));
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_numeroColumnIndex))
						record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(linea_idColumnIndex))
						record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(linea_nombreColumnIndex))
						record.LINEA_NOMBRE = Convert.ToString(reader.GetValue(linea_nombreColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(bl_nroColumnIndex))
						record.BL_NRO = Convert.ToString(reader.GetValue(bl_nroColumnIndex));
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(clasificacion_idColumnIndex))
						record.CLASIFICACION_ID = Convert.ToString(reader.GetValue(clasificacion_idColumnIndex));
					if(!reader.IsDBNull(contenedor_claseColumnIndex))
						record.CONTENEDOR_CLASE = Convert.ToString(reader.GetValue(contenedor_claseColumnIndex));
					if(!reader.IsDBNull(itemColumnIndex))
						record.ITEM = Math.Round(Convert.ToDecimal(reader.GetValue(itemColumnIndex)), 9);
					if(!reader.IsDBNull(mercaderia_internaColumnIndex))
						record.MERCADERIA_INTERNA = Convert.ToString(reader.GetValue(mercaderia_internaColumnIndex));
					if(!reader.IsDBNull(precinto_1ColumnIndex))
						record.PRECINTO_1 = Convert.ToString(reader.GetValue(precinto_1ColumnIndex));
					if(!reader.IsDBNull(precinto_2ColumnIndex))
						record.PRECINTO_2 = Convert.ToString(reader.GetValue(precinto_2ColumnIndex));
					if(!reader.IsDBNull(precinto_3ColumnIndex))
						record.PRECINTO_3 = Convert.ToString(reader.GetValue(precinto_3ColumnIndex));
					if(!reader.IsDBNull(precinto_4ColumnIndex))
						record.PRECINTO_4 = Convert.ToString(reader.GetValue(precinto_4ColumnIndex));
					if(!reader.IsDBNull(precinto_5ColumnIndex))
						record.PRECINTO_5 = Convert.ToString(reader.GetValue(precinto_5ColumnIndex));
					if(!reader.IsDBNull(ventileteColumnIndex))
						record.VENTILETE = Convert.ToString(reader.GetValue(ventileteColumnIndex));
					if(!reader.IsDBNull(ediColumnIndex))
						record.EDI = Convert.ToString(reader.GetValue(ediColumnIndex));
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(procesadoColumnIndex))
						record.PROCESADO = Convert.ToString(reader.GetValue(procesadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(pisoColumnIndex))
						record.PISO = Convert.ToString(reader.GetValue(pisoColumnIndex));
					if(!reader.IsDBNull(fondoColumnIndex))
						record.FONDO = Convert.ToString(reader.GetValue(fondoColumnIndex));
					if(!reader.IsDBNull(panel_derechoColumnIndex))
						record.PANEL_DERECHO = Convert.ToString(reader.GetValue(panel_derechoColumnIndex));
					if(!reader.IsDBNull(panel_izquierdoColumnIndex))
						record.PANEL_IZQUIERDO = Convert.ToString(reader.GetValue(panel_izquierdoColumnIndex));
					if(!reader.IsDBNull(puertaColumnIndex))
						record.PUERTA = Convert.ToString(reader.GetValue(puertaColumnIndex));
					if(!reader.IsDBNull(refrigeradoColumnIndex))
						record.REFRIGERADO = Convert.ToString(reader.GetValue(refrigeradoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTENEDORES_OPERAC_INFO_COMPLRow[])(recordList.ToArray(typeof(CONTENEDORES_OPERAC_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTENEDORES_OPERAC_INFO_COMPLRow"/> object.</returns>
		protected virtual CONTENEDORES_OPERAC_INFO_COMPLRow MapRow(DataRow row)
		{
			CONTENEDORES_OPERAC_INFO_COMPLRow mappedObject = new CONTENEDORES_OPERAC_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "OPERACION"
			dataColumn = dataTable.Columns["OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERACION = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "HORA_INICIO"
			dataColumn = dataTable.Columns["HORA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_INICIO = (System.DateTime)row[dataColumn];
			// Column "HORA_FIN"
			dataColumn = dataTable.Columns["HORA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_FIN = (System.DateTime)row[dataColumn];
			// Column "NRO_FORMULARIO"
			dataColumn = dataTable.Columns["NRO_FORMULARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_FORMULARIO = (string)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "LINEA_NOMBRE"
			dataColumn = dataTable.Columns["LINEA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_NOMBRE = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "BL_NRO"
			dataColumn = dataTable.Columns["BL_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BL_NRO = (string)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "CLASIFICACION_ID"
			dataColumn = dataTable.Columns["CLASIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLASIFICACION_ID = (string)row[dataColumn];
			// Column "CONTENEDOR_CLASE"
			dataColumn = dataTable.Columns["CONTENEDOR_CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_CLASE = (string)row[dataColumn];
			// Column "ITEM"
			dataColumn = dataTable.Columns["ITEM"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEM = (decimal)row[dataColumn];
			// Column "MERCADERIA_INTERNA"
			dataColumn = dataTable.Columns["MERCADERIA_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA_INTERNA = (string)row[dataColumn];
			// Column "PRECINTO_1"
			dataColumn = dataTable.Columns["PRECINTO_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_1 = (string)row[dataColumn];
			// Column "PRECINTO_2"
			dataColumn = dataTable.Columns["PRECINTO_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_2 = (string)row[dataColumn];
			// Column "PRECINTO_3"
			dataColumn = dataTable.Columns["PRECINTO_3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_3 = (string)row[dataColumn];
			// Column "PRECINTO_4"
			dataColumn = dataTable.Columns["PRECINTO_4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_4 = (string)row[dataColumn];
			// Column "PRECINTO_5"
			dataColumn = dataTable.Columns["PRECINTO_5"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_5 = (string)row[dataColumn];
			// Column "VENTILETE"
			dataColumn = dataTable.Columns["VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENTILETE = (string)row[dataColumn];
			// Column "EDI"
			dataColumn = dataTable.Columns["EDI"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PROCESADO"
			dataColumn = dataTable.Columns["PROCESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PISO"
			dataColumn = dataTable.Columns["PISO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PISO = (string)row[dataColumn];
			// Column "FONDO"
			dataColumn = dataTable.Columns["FONDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO = (string)row[dataColumn];
			// Column "PANEL_DERECHO"
			dataColumn = dataTable.Columns["PANEL_DERECHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PANEL_DERECHO = (string)row[dataColumn];
			// Column "PANEL_IZQUIERDO"
			dataColumn = dataTable.Columns["PANEL_IZQUIERDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PANEL_IZQUIERDO = (string)row[dataColumn];
			// Column "PUERTA"
			dataColumn = dataTable.Columns["PUERTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTA = (string)row[dataColumn];
			// Column "REFRIGERADO"
			dataColumn = dataTable.Columns["REFRIGERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REFRIGERADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTENEDORES_OPERAC_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTENEDORES_OPERAC_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OPERACION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HORA_INICIO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HORA_FIN", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_FORMULARIO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LINEA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BL_NRO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CLASIFICACION_ID", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_CLASE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEM", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIA_INTERNA", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_2", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_3", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_4", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_5", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENTILETE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EDI", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PISO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FONDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PANEL_DERECHO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PANEL_IZQUIERDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTA", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
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

				case "OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "HORA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "HORA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_FORMULARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LINEA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BL_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CLASIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONTENEDOR_CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ITEM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MERCADERIA_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EDI":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROCESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PISO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FONDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PANEL_DERECHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PANEL_IZQUIERDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REFRIGERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTENEDORES_OPERAC_INFO_COMPLCollection_Base class
}  // End of namespace
