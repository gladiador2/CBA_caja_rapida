// <fileinfo name="REPARTO_DETALLES_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="REPARTO_DETALLES_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REPARTO_DETALLES_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REPARTO_DETALLES_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string REPARTO_IDColumnName = "REPARTO_ID";
		public const string CASO_NRO_COMPROBANTEColumnName = "CASO_NRO_COMPROBANTE";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string CASO_ESTADOColumnName = "CASO_ESTADO";
		public const string CASO_FLUJO_IDColumnName = "CASO_FLUJO_ID";
		public const string CASO_FLUJO_DESC_IMPRColumnName = "CASO_FLUJO_DESC_IMPR";
		public const string CASO_FLUJO_DESCRIPColumnName = "CASO_FLUJO_DESCRIP";
		public const string CASO_SUCURSAL_IDColumnName = "CASO_SUCURSAL_ID";
		public const string CASO_SUCURSAL_NOMBREColumnName = "CASO_SUCURSAL_NOMBRE";
		public const string CASO_SUCURSAL_ABREVIATURAColumnName = "CASO_SUCURSAL_ABREVIATURA";
		public const string FECHA_CASOColumnName = "FECHA_CASO";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string PERSONA_DEPARTAMENTO1_NOMBREColumnName = "PERSONA_DEPARTAMENTO1_NOMBRE";
		public const string PERSONA_CIUDAD1_NOMBREColumnName = "PERSONA_CIUDAD1_NOMBRE";
		public const string PERSONA_BARRIO1_NOMBREColumnName = "PERSONA_BARRIO1_NOMBRE";
		public const string PERSONA_CALLE1ColumnName = "PERSONA_CALLE1";
		public const string ORDENColumnName = "ORDEN";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ENTREGA_EXITOSAColumnName = "ENTREGA_EXITOSA";
		public const string BULTOSColumnName = "BULTOS";
		public const string TRANSF_SUCURSAL_DESTINO_IDColumnName = "TRANSF_SUCURSAL_DESTINO_ID";
		public const string TRANSF_SUCURSAL_DESTINO_NOMBREColumnName = "TRANSF_SUCURSAL_DESTINO_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REPARTO_DETALLES_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REPARTO_DETALLES_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REPARTO_DETALLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects.</returns>
		public virtual REPARTO_DETALLES_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REPARTO_DETALLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REPARTO_DETALLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REPARTO_DETALLES_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REPARTO_DETALLES_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects.</returns>
		public REPARTO_DETALLES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects.</returns>
		public virtual REPARTO_DETALLES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REPARTO_DETALLES_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects.</returns>
		protected REPARTO_DETALLES_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects.</returns>
		protected REPARTO_DETALLES_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> objects.</returns>
		protected virtual REPARTO_DETALLES_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int reparto_idColumnIndex = reader.GetOrdinal("REPARTO_ID");
			int caso_nro_comprobanteColumnIndex = reader.GetOrdinal("CASO_NRO_COMPROBANTE");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int caso_estadoColumnIndex = reader.GetOrdinal("CASO_ESTADO");
			int caso_flujo_idColumnIndex = reader.GetOrdinal("CASO_FLUJO_ID");
			int caso_flujo_desc_imprColumnIndex = reader.GetOrdinal("CASO_FLUJO_DESC_IMPR");
			int caso_flujo_descripColumnIndex = reader.GetOrdinal("CASO_FLUJO_DESCRIP");
			int caso_sucursal_idColumnIndex = reader.GetOrdinal("CASO_SUCURSAL_ID");
			int caso_sucursal_nombreColumnIndex = reader.GetOrdinal("CASO_SUCURSAL_NOMBRE");
			int caso_sucursal_abreviaturaColumnIndex = reader.GetOrdinal("CASO_SUCURSAL_ABREVIATURA");
			int fecha_casoColumnIndex = reader.GetOrdinal("FECHA_CASO");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int persona_departamento1_nombreColumnIndex = reader.GetOrdinal("PERSONA_DEPARTAMENTO1_NOMBRE");
			int persona_ciudad1_nombreColumnIndex = reader.GetOrdinal("PERSONA_CIUDAD1_NOMBRE");
			int persona_barrio1_nombreColumnIndex = reader.GetOrdinal("PERSONA_BARRIO1_NOMBRE");
			int persona_calle1ColumnIndex = reader.GetOrdinal("PERSONA_CALLE1");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int entrega_exitosaColumnIndex = reader.GetOrdinal("ENTREGA_EXITOSA");
			int bultosColumnIndex = reader.GetOrdinal("BULTOS");
			int transf_sucursal_destino_idColumnIndex = reader.GetOrdinal("TRANSF_SUCURSAL_DESTINO_ID");
			int transf_sucursal_destino_nombreColumnIndex = reader.GetOrdinal("TRANSF_SUCURSAL_DESTINO_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REPARTO_DETALLES_INFO_COMPLETARow record = new REPARTO_DETALLES_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.REPARTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reparto_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_nro_comprobanteColumnIndex))
						record.CASO_NRO_COMPROBANTE = Convert.ToString(reader.GetValue(caso_nro_comprobanteColumnIndex));
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.CASO_ESTADO = Convert.ToString(reader.GetValue(caso_estadoColumnIndex));
					record.CASO_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_flujo_desc_imprColumnIndex))
						record.CASO_FLUJO_DESC_IMPR = Convert.ToString(reader.GetValue(caso_flujo_desc_imprColumnIndex));
					if(!reader.IsDBNull(caso_flujo_descripColumnIndex))
						record.CASO_FLUJO_DESCRIP = Convert.ToString(reader.GetValue(caso_flujo_descripColumnIndex));
					record.CASO_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_sucursal_idColumnIndex)), 9);
					record.CASO_SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(caso_sucursal_nombreColumnIndex));
					record.CASO_SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(caso_sucursal_abreviaturaColumnIndex));
					record.FECHA_CASO = Convert.ToDateTime(reader.GetValue(fecha_casoColumnIndex));
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					if(!reader.IsDBNull(persona_departamento1_nombreColumnIndex))
						record.PERSONA_DEPARTAMENTO1_NOMBRE = Convert.ToString(reader.GetValue(persona_departamento1_nombreColumnIndex));
					if(!reader.IsDBNull(persona_ciudad1_nombreColumnIndex))
						record.PERSONA_CIUDAD1_NOMBRE = Convert.ToString(reader.GetValue(persona_ciudad1_nombreColumnIndex));
					if(!reader.IsDBNull(persona_barrio1_nombreColumnIndex))
						record.PERSONA_BARRIO1_NOMBRE = Convert.ToString(reader.GetValue(persona_barrio1_nombreColumnIndex));
					if(!reader.IsDBNull(persona_calle1ColumnIndex))
						record.PERSONA_CALLE1 = Convert.ToString(reader.GetValue(persona_calle1ColumnIndex));
					if(!reader.IsDBNull(ordenColumnIndex))
						record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(entrega_exitosaColumnIndex))
						record.ENTREGA_EXITOSA = Convert.ToString(reader.GetValue(entrega_exitosaColumnIndex));
					if(!reader.IsDBNull(bultosColumnIndex))
						record.BULTOS = Math.Round(Convert.ToDecimal(reader.GetValue(bultosColumnIndex)), 9);
					if(!reader.IsDBNull(transf_sucursal_destino_idColumnIndex))
						record.TRANSF_SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transf_sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(transf_sucursal_destino_nombreColumnIndex))
						record.TRANSF_SUCURSAL_DESTINO_NOMBRE = Convert.ToString(reader.GetValue(transf_sucursal_destino_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REPARTO_DETALLES_INFO_COMPLETARow[])(recordList.ToArray(typeof(REPARTO_DETALLES_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REPARTO_DETALLES_INFO_COMPLETARow"/> object.</returns>
		protected virtual REPARTO_DETALLES_INFO_COMPLETARow MapRow(DataRow row)
		{
			REPARTO_DETALLES_INFO_COMPLETARow mappedObject = new REPARTO_DETALLES_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "REPARTO_ID"
			dataColumn = dataTable.Columns["REPARTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REPARTO_ID = (decimal)row[dataColumn];
			// Column "CASO_NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["CASO_NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "CASO_ESTADO"
			dataColumn = dataTable.Columns["CASO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ESTADO = (string)row[dataColumn];
			// Column "CASO_FLUJO_ID"
			dataColumn = dataTable.Columns["CASO_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FLUJO_ID = (decimal)row[dataColumn];
			// Column "CASO_FLUJO_DESC_IMPR"
			dataColumn = dataTable.Columns["CASO_FLUJO_DESC_IMPR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FLUJO_DESC_IMPR = (string)row[dataColumn];
			// Column "CASO_FLUJO_DESCRIP"
			dataColumn = dataTable.Columns["CASO_FLUJO_DESCRIP"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FLUJO_DESCRIP = (string)row[dataColumn];
			// Column "CASO_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CASO_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "CASO_SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["CASO_SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "CASO_SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["CASO_SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "FECHA_CASO"
			dataColumn = dataTable.Columns["FECHA_CASO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CASO = (System.DateTime)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "PERSONA_DEPARTAMENTO1_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_DEPARTAMENTO1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DEPARTAMENTO1_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CIUDAD1_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_CIUDAD1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CIUDAD1_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_BARRIO1_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_BARRIO1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_BARRIO1_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_CALLE1"
			dataColumn = dataTable.Columns["PERSONA_CALLE1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CALLE1 = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ENTREGA_EXITOSA"
			dataColumn = dataTable.Columns["ENTREGA_EXITOSA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTREGA_EXITOSA = (string)row[dataColumn];
			// Column "BULTOS"
			dataColumn = dataTable.Columns["BULTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.BULTOS = (decimal)row[dataColumn];
			// Column "TRANSF_SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["TRANSF_SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSF_SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "TRANSF_SUCURSAL_DESTINO_NOMBRE"
			dataColumn = dataTable.Columns["TRANSF_SUCURSAL_DESTINO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSF_SUCURSAL_DESTINO_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REPARTO_DETALLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REPARTO_DETALLES_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REPARTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_ESTADO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_FLUJO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_FLUJO_DESC_IMPR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_FLUJO_DESCRIP", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CASO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DEPARTAMENTO1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CIUDAD1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_BARRIO1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CALLE1", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTREGA_EXITOSA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BULTOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSF_SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSF_SUCURSAL_DESTINO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "REPARTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_FLUJO_DESC_IMPR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_FLUJO_DESCRIP":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CASO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_DEPARTAMENTO1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CIUDAD1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_BARRIO1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CALLE1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTREGA_EXITOSA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BULTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSF_SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSF_SUCURSAL_DESTINO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REPARTO_DETALLES_INFO_COMPLETACollection_Base class
}  // End of namespace
