// <fileinfo name="CTACTE_PLANES_DESEMB_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PLANES_DESEMB_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PLANES_DESEMB_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PLANES_DESEMB_INFO_COMPCollection_Base
	{
		// Constants
		public const string PROC_TARJETA_NOMBREColumnName = "PROC_TARJETA_NOMBRE";
		public const string COND_DESEMBOLSO_DESCRIPCIONColumnName = "COND_DESEMBOLSO_DESCRIPCION";
		public const string COND_DESEMBOLSO_NOMBREColumnName = "COND_DESEMBOLSO_NOMBRE";
		public const string RED_PAGO_NOMBREColumnName = "RED_PAGO_NOMBRE";
		public const string NOMBREColumnName = "NOMBRE";
		public const string IDColumnName = "ID";
		public const string CTACTE_PROCESADORA_IDColumnName = "CTACTE_PROCESADORA_ID";
		public const string CTACTE_RED_PAGO_IDColumnName = "CTACTE_RED_PAGO_ID";
		public const string USAR_VALIDEZColumnName = "USAR_VALIDEZ";
		public const string VALIDEZ_DESDEColumnName = "VALIDEZ_DESDE";
		public const string VALIDEZ_HASTAColumnName = "VALIDEZ_HASTA";
		public const string CONDICION_DESEMBOLSO_IDColumnName = "CONDICION_DESEMBOLSO_ID";
		public const string POLITICA_PRIMER_DESEMBOLSOColumnName = "POLITICA_PRIMER_DESEMBOLSO";
		public const string DIAS_DESDE_INICIO_MESColumnName = "DIAS_DESDE_INICIO_MES";
		public const string DESEMBOLSO_AUTOMATICOColumnName = "DESEMBOLSO_AUTOMATICO";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PLANES_DESEMB_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PLANES_DESEMB_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PLANES_DESEMB_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_PLANES_DESEMB_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PLANES_DESEMB_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PLANES_DESEMB_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PLANES_DESEMB_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PLANES_DESEMB_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects.</returns>
		public CTACTE_PLANES_DESEMB_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects.</returns>
		public virtual CTACTE_PLANES_DESEMB_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PLANES_DESEMB_INFO_COMP";
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_PLANES_DESEMB_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects.</returns>
		protected CTACTE_PLANES_DESEMB_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> objects.</returns>
		protected virtual CTACTE_PLANES_DESEMB_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int proc_tarjeta_nombreColumnIndex = reader.GetOrdinal("PROC_TARJETA_NOMBRE");
			int cond_desembolso_descripcionColumnIndex = reader.GetOrdinal("COND_DESEMBOLSO_DESCRIPCION");
			int cond_desembolso_nombreColumnIndex = reader.GetOrdinal("COND_DESEMBOLSO_NOMBRE");
			int red_pago_nombreColumnIndex = reader.GetOrdinal("RED_PAGO_NOMBRE");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_procesadora_idColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA_ID");
			int ctacte_red_pago_idColumnIndex = reader.GetOrdinal("CTACTE_RED_PAGO_ID");
			int usar_validezColumnIndex = reader.GetOrdinal("USAR_VALIDEZ");
			int validez_desdeColumnIndex = reader.GetOrdinal("VALIDEZ_DESDE");
			int validez_hastaColumnIndex = reader.GetOrdinal("VALIDEZ_HASTA");
			int condicion_desembolso_idColumnIndex = reader.GetOrdinal("CONDICION_DESEMBOLSO_ID");
			int politica_primer_desembolsoColumnIndex = reader.GetOrdinal("POLITICA_PRIMER_DESEMBOLSO");
			int dias_desde_inicio_mesColumnIndex = reader.GetOrdinal("DIAS_DESDE_INICIO_MES");
			int desembolso_automaticoColumnIndex = reader.GetOrdinal("DESEMBOLSO_AUTOMATICO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PLANES_DESEMB_INFO_COMPRow record = new CTACTE_PLANES_DESEMB_INFO_COMPRow();
					recordList.Add(record);

					if(!reader.IsDBNull(proc_tarjeta_nombreColumnIndex))
						record.PROC_TARJETA_NOMBRE = Convert.ToString(reader.GetValue(proc_tarjeta_nombreColumnIndex));
					if(!reader.IsDBNull(cond_desembolso_descripcionColumnIndex))
						record.COND_DESEMBOLSO_DESCRIPCION = Convert.ToString(reader.GetValue(cond_desembolso_descripcionColumnIndex));
					if(!reader.IsDBNull(cond_desembolso_nombreColumnIndex))
						record.COND_DESEMBOLSO_NOMBRE = Convert.ToString(reader.GetValue(cond_desembolso_nombreColumnIndex));
					if(!reader.IsDBNull(red_pago_nombreColumnIndex))
						record.RED_PAGO_NOMBRE = Convert.ToString(reader.GetValue(red_pago_nombreColumnIndex));
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadora_idColumnIndex))
						record.CTACTE_PROCESADORA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadora_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_red_pago_idColumnIndex))
						record.CTACTE_RED_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_red_pago_idColumnIndex)), 9);
					record.USAR_VALIDEZ = Convert.ToString(reader.GetValue(usar_validezColumnIndex));
					if(!reader.IsDBNull(validez_desdeColumnIndex))
						record.VALIDEZ_DESDE = Convert.ToDateTime(reader.GetValue(validez_desdeColumnIndex));
					if(!reader.IsDBNull(validez_hastaColumnIndex))
						record.VALIDEZ_HASTA = Convert.ToDateTime(reader.GetValue(validez_hastaColumnIndex));
					record.CONDICION_DESEMBOLSO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_desembolso_idColumnIndex)), 9);
					record.POLITICA_PRIMER_DESEMBOLSO = Math.Round(Convert.ToDecimal(reader.GetValue(politica_primer_desembolsoColumnIndex)), 9);
					record.DIAS_DESDE_INICIO_MES = Math.Round(Convert.ToDecimal(reader.GetValue(dias_desde_inicio_mesColumnIndex)), 9);
					if(!reader.IsDBNull(desembolso_automaticoColumnIndex))
						record.DESEMBOLSO_AUTOMATICO = Convert.ToString(reader.GetValue(desembolso_automaticoColumnIndex));
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PLANES_DESEMB_INFO_COMPRow[])(recordList.ToArray(typeof(CTACTE_PLANES_DESEMB_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> object.</returns>
		protected virtual CTACTE_PLANES_DESEMB_INFO_COMPRow MapRow(DataRow row)
		{
			CTACTE_PLANES_DESEMB_INFO_COMPRow mappedObject = new CTACTE_PLANES_DESEMB_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "PROC_TARJETA_NOMBRE"
			dataColumn = dataTable.Columns["PROC_TARJETA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROC_TARJETA_NOMBRE = (string)row[dataColumn];
			// Column "COND_DESEMBOLSO_DESCRIPCION"
			dataColumn = dataTable.Columns["COND_DESEMBOLSO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COND_DESEMBOLSO_DESCRIPCION = (string)row[dataColumn];
			// Column "COND_DESEMBOLSO_NOMBRE"
			dataColumn = dataTable.Columns["COND_DESEMBOLSO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COND_DESEMBOLSO_NOMBRE = (string)row[dataColumn];
			// Column "RED_PAGO_NOMBRE"
			dataColumn = dataTable.Columns["RED_PAGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RED_PAGO_NOMBRE = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA_ID"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_RED_PAGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RED_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RED_PAGO_ID = (decimal)row[dataColumn];
			// Column "USAR_VALIDEZ"
			dataColumn = dataTable.Columns["USAR_VALIDEZ"];
			if(!row.IsNull(dataColumn))
				mappedObject.USAR_VALIDEZ = (string)row[dataColumn];
			// Column "VALIDEZ_DESDE"
			dataColumn = dataTable.Columns["VALIDEZ_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALIDEZ_DESDE = (System.DateTime)row[dataColumn];
			// Column "VALIDEZ_HASTA"
			dataColumn = dataTable.Columns["VALIDEZ_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALIDEZ_HASTA = (System.DateTime)row[dataColumn];
			// Column "CONDICION_DESEMBOLSO_ID"
			dataColumn = dataTable.Columns["CONDICION_DESEMBOLSO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_DESEMBOLSO_ID = (decimal)row[dataColumn];
			// Column "POLITICA_PRIMER_DESEMBOLSO"
			dataColumn = dataTable.Columns["POLITICA_PRIMER_DESEMBOLSO"];
			if(!row.IsNull(dataColumn))
				mappedObject.POLITICA_PRIMER_DESEMBOLSO = (decimal)row[dataColumn];
			// Column "DIAS_DESDE_INICIO_MES"
			dataColumn = dataTable.Columns["DIAS_DESDE_INICIO_MES"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_DESDE_INICIO_MES = (decimal)row[dataColumn];
			// Column "DESEMBOLSO_AUTOMATICO"
			dataColumn = dataTable.Columns["DESEMBOLSO_AUTOMATICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESEMBOLSO_AUTOMATICO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PLANES_DESEMB_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PLANES_DESEMB_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("PROC_TARJETA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COND_DESEMBOLSO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COND_DESEMBOLSO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RED_PAGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_RED_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USAR_VALIDEZ", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALIDEZ_DESDE", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALIDEZ_HASTA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_DESEMBOLSO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("POLITICA_PRIMER_DESEMBOLSO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIAS_DESDE_INICIO_MES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESEMBOLSO_AUTOMATICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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
				case "PROC_TARJETA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COND_DESEMBOLSO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COND_DESEMBOLSO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RED_PAGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROCESADORA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RED_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USAR_VALIDEZ":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "VALIDEZ_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VALIDEZ_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONDICION_DESEMBOLSO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "POLITICA_PRIMER_DESEMBOLSO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIAS_DESDE_INICIO_MES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESEMBOLSO_AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PLANES_DESEMB_INFO_COMPCollection_Base class
}  // End of namespace
