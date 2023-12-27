// <fileinfo name="NOMINA_CONTENEDORES_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="NOMINA_CONTENEDORES_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="NOMINA_CONTENEDORES_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOMINA_CONTENEDORES_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string BOOKINGColumnName = "BOOKING";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string USUARIO_CREADORColumnName = "USUARIO_CREADOR";
		public const string USUARIO_MODIFICACION_IDColumnName = "USUARIO_MODIFICACION_ID";
		public const string USUARIO_MODIFICACIONColumnName = "USUARIO_MODIFICACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TOTAL_CONTENEDORESColumnName = "TOTAL_CONTENEDORES";
		public const string TOTAL_CONTENEDORES_ENTREGADOSColumnName = "TOTAL_CONTENEDORES_ENTREGADOS";
		public const string TOTAL_CONTENEDORES_DEVUELTOSColumnName = "TOTAL_CONTENEDORES_DEVUELTOS";
		public const string TOTAL_CONTENEDORES_PENDIENTESColumnName = "TOTAL_CONTENEDORES_PENDIENTES";
		public const string TIPO_NOMINAColumnName = "TIPO_NOMINA";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";
		public const string PUERTO_DEVOLUCION_NOMBREColumnName = "PUERTO_DEVOLUCION_NOMBRE";
		public const string PUERTO_DEVOLUCION_ABREVIATURAColumnName = "PUERTO_DEVOLUCION_ABREVIATURA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOMINA_CONTENEDORES_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public NOMINA_CONTENEDORES_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>NOMINA_CONTENEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>NOMINA_CONTENEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>NOMINA_CONTENEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public NOMINA_CONTENEDORES_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			NOMINA_CONTENEDORES_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects.</returns>
		public NOMINA_CONTENEDORES_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects.</returns>
		public virtual NOMINA_CONTENEDORES_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.NOMINA_CONTENEDORES_INFO_COMPL";
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects.</returns>
		protected NOMINA_CONTENEDORES_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects.</returns>
		protected NOMINA_CONTENEDORES_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> objects.</returns>
		protected virtual NOMINA_CONTENEDORES_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int usuario_creadorColumnIndex = reader.GetOrdinal("USUARIO_CREADOR");
			int usuario_modificacion_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_ID");
			int usuario_modificacionColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int total_contenedoresColumnIndex = reader.GetOrdinal("TOTAL_CONTENEDORES");
			int total_contenedores_entregadosColumnIndex = reader.GetOrdinal("TOTAL_CONTENEDORES_ENTREGADOS");
			int total_contenedores_devueltosColumnIndex = reader.GetOrdinal("TOTAL_CONTENEDORES_DEVUELTOS");
			int total_contenedores_pendientesColumnIndex = reader.GetOrdinal("TOTAL_CONTENEDORES_PENDIENTES");
			int tipo_nominaColumnIndex = reader.GetOrdinal("TIPO_NOMINA");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");
			int puerto_devolucion_nombreColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_NOMBRE");
			int puerto_devolucion_abreviaturaColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ABREVIATURA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					NOMINA_CONTENEDORES_INFO_COMPLRow record = new NOMINA_CONTENEDORES_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(usuario_creador_idColumnIndex))
						record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creadorColumnIndex))
						record.USUARIO_CREADOR = Convert.ToString(reader.GetValue(usuario_creadorColumnIndex));
					if(!reader.IsDBNull(usuario_modificacion_idColumnIndex))
						record.USUARIO_MODIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_modificacionColumnIndex))
						record.USUARIO_MODIFICACION = Convert.ToString(reader.GetValue(usuario_modificacionColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(total_contenedoresColumnIndex))
						record.TOTAL_CONTENEDORES = Math.Round(Convert.ToDecimal(reader.GetValue(total_contenedoresColumnIndex)), 9);
					if(!reader.IsDBNull(total_contenedores_entregadosColumnIndex))
						record.TOTAL_CONTENEDORES_ENTREGADOS = Math.Round(Convert.ToDecimal(reader.GetValue(total_contenedores_entregadosColumnIndex)), 9);
					if(!reader.IsDBNull(total_contenedores_devueltosColumnIndex))
						record.TOTAL_CONTENEDORES_DEVUELTOS = Math.Round(Convert.ToDecimal(reader.GetValue(total_contenedores_devueltosColumnIndex)), 9);
					if(!reader.IsDBNull(total_contenedores_pendientesColumnIndex))
						record.TOTAL_CONTENEDORES_PENDIENTES = Math.Round(Convert.ToDecimal(reader.GetValue(total_contenedores_pendientesColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_nominaColumnIndex))
						record.TIPO_NOMINA = Convert.ToString(reader.GetValue(tipo_nominaColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_devolucion_nombreColumnIndex))
						record.PUERTO_DEVOLUCION_NOMBRE = Convert.ToString(reader.GetValue(puerto_devolucion_nombreColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_abreviaturaColumnIndex))
						record.PUERTO_DEVOLUCION_ABREVIATURA = Convert.ToString(reader.GetValue(puerto_devolucion_abreviaturaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (NOMINA_CONTENEDORES_INFO_COMPLRow[])(recordList.ToArray(typeof(NOMINA_CONTENEDORES_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="NOMINA_CONTENEDORES_INFO_COMPLRow"/> object.</returns>
		protected virtual NOMINA_CONTENEDORES_INFO_COMPLRow MapRow(DataRow row)
		{
			NOMINA_CONTENEDORES_INFO_COMPLRow mappedObject = new NOMINA_CONTENEDORES_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
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
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR"
			dataColumn = dataTable.Columns["USUARIO_CREADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR = (string)row[dataColumn];
			// Column "USUARIO_MODIFICACION_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_MODIFICACION"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TOTAL_CONTENEDORES"
			dataColumn = dataTable.Columns["TOTAL_CONTENEDORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CONTENEDORES = (decimal)row[dataColumn];
			// Column "TOTAL_CONTENEDORES_ENTREGADOS"
			dataColumn = dataTable.Columns["TOTAL_CONTENEDORES_ENTREGADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CONTENEDORES_ENTREGADOS = (decimal)row[dataColumn];
			// Column "TOTAL_CONTENEDORES_DEVUELTOS"
			dataColumn = dataTable.Columns["TOTAL_CONTENEDORES_DEVUELTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CONTENEDORES_DEVUELTOS = (decimal)row[dataColumn];
			// Column "TOTAL_CONTENEDORES_PENDIENTES"
			dataColumn = dataTable.Columns["TOTAL_CONTENEDORES_PENDIENTES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CONTENEDORES_PENDIENTES = (decimal)row[dataColumn];
			// Column "TIPO_NOMINA"
			dataColumn = dataTable.Columns["TIPO_NOMINA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_NOMINA = (string)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_NOMBRE"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_NOMBRE = (string)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ABREVIATURA"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ABREVIATURA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>NOMINA_CONTENEDORES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "NOMINA_CONTENEDORES_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CONTENEDORES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CONTENEDORES_ENTREGADOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CONTENEDORES_DEVUELTOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_CONTENEDORES_PENDIENTES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_NOMINA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_MODIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_MODIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_CONTENEDORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CONTENEDORES_ENTREGADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CONTENEDORES_DEVUELTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CONTENEDORES_PENDIENTES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_NOMINA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_DEVOLUCION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_DEVOLUCION_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of NOMINA_CONTENEDORES_INFO_COMPLCollection_Base class
}  // End of namespace
