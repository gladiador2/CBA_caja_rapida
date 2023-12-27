// <fileinfo name="CTACTE_TARJETA_CREDI_INF_COMPCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_TARJETA_CREDI_INF_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_TARJETA_CREDI_INF_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_TARJETA_CREDI_INF_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_PROCESADORAColumnName = "CTACTE_PROCESADORA";
		public const string CTACTE_TARJETA_CRED_EMIS_IDColumnName = "CTACTE_TARJETA_CRED_EMIS_ID";
		public const string CTACTE_BANCO_EMISORA_IDColumnName = "CTACTE_BANCO_EMISORA_ID";
		public const string EMISORAColumnName = "EMISORA";
		public const string NUMEROColumnName = "NUMERO";
		public const string TITULARColumnName = "TITULAR";
		public const string LIMITE_CREDITOColumnName = "LIMITE_CREDITO";
		public const string BLOQUEADOColumnName = "BLOQUEADO";
		public const string MOTIVO_ULTIMO_BLOQUEOColumnName = "MOTIVO_ULTIMO_BLOQUEO";
		public const string USUARIO_ULTIMO_BLOQUEO_IDColumnName = "USUARIO_ULTIMO_BLOQUEO_ID";
		public const string FECHA_ULTIMO_BLOQUEOColumnName = "FECHA_ULTIMO_BLOQUEO";
		public const string USUARIO_ULTIMO_DESBLOQUEO_IDColumnName = "USUARIO_ULTIMO_DESBLOQUEO_ID";
		public const string FECHA_ULTIMO_DESBLOQUEOColumnName = "FECHA_ULTIMO_DESBLOQUEO";
		public const string USUARIO_CREACIONColumnName = "USUARIO_CREACION";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string NOMBRE_TARJETAColumnName = "NOMBRE_TARJETA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_TARJETA_CREDI_INF_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_TARJETA_CREDI_INF_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_TARJETA_CREDI_INF_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects.</returns>
		public virtual CTACTE_TARJETA_CREDI_INF_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_TARJETA_CREDI_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_TARJETA_CREDI_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_TARJETA_CREDI_INF_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_TARJETA_CREDI_INF_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects.</returns>
		public CTACTE_TARJETA_CREDI_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects.</returns>
		public virtual CTACTE_TARJETA_CREDI_INF_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_TARJETA_CREDI_INF_COMP";
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects.</returns>
		protected CTACTE_TARJETA_CREDI_INF_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects.</returns>
		protected CTACTE_TARJETA_CREDI_INF_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> objects.</returns>
		protected virtual CTACTE_TARJETA_CREDI_INF_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_procesadoraColumnIndex = reader.GetOrdinal("CTACTE_PROCESADORA");
			int ctacte_tarjeta_cred_emis_idColumnIndex = reader.GetOrdinal("CTACTE_TARJETA_CRED_EMIS_ID");
			int ctacte_banco_emisora_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_EMISORA_ID");
			int emisoraColumnIndex = reader.GetOrdinal("EMISORA");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int titularColumnIndex = reader.GetOrdinal("TITULAR");
			int limite_creditoColumnIndex = reader.GetOrdinal("LIMITE_CREDITO");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");
			int motivo_ultimo_bloqueoColumnIndex = reader.GetOrdinal("MOTIVO_ULTIMO_BLOQUEO");
			int usuario_ultimo_bloqueo_idColumnIndex = reader.GetOrdinal("USUARIO_ULTIMO_BLOQUEO_ID");
			int fecha_ultimo_bloqueoColumnIndex = reader.GetOrdinal("FECHA_ULTIMO_BLOQUEO");
			int usuario_ultimo_desbloqueo_idColumnIndex = reader.GetOrdinal("USUARIO_ULTIMO_DESBLOQUEO_ID");
			int fecha_ultimo_desbloqueoColumnIndex = reader.GetOrdinal("FECHA_ULTIMO_DESBLOQUEO");
			int usuario_creacionColumnIndex = reader.GetOrdinal("USUARIO_CREACION");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int nombre_tarjetaColumnIndex = reader.GetOrdinal("NOMBRE_TARJETA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_TARJETA_CREDI_INF_COMPRow record = new CTACTE_TARJETA_CREDI_INF_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_procesadoraColumnIndex))
						record.CTACTE_PROCESADORA = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_procesadoraColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_tarjeta_cred_emis_idColumnIndex))
						record.CTACTE_TARJETA_CRED_EMIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_tarjeta_cred_emis_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_banco_emisora_idColumnIndex))
						record.CTACTE_BANCO_EMISORA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_emisora_idColumnIndex)), 9);
					if(!reader.IsDBNull(emisoraColumnIndex))
						record.EMISORA = Convert.ToString(reader.GetValue(emisoraColumnIndex));
					record.NUMERO = Convert.ToString(reader.GetValue(numeroColumnIndex));
					record.TITULAR = Convert.ToString(reader.GetValue(titularColumnIndex));
					record.LIMITE_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(limite_creditoColumnIndex)), 9);
					record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));
					if(!reader.IsDBNull(motivo_ultimo_bloqueoColumnIndex))
						record.MOTIVO_ULTIMO_BLOQUEO = Convert.ToString(reader.GetValue(motivo_ultimo_bloqueoColumnIndex));
					if(!reader.IsDBNull(usuario_ultimo_bloqueo_idColumnIndex))
						record.USUARIO_ULTIMO_BLOQUEO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_ultimo_bloqueo_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultimo_bloqueoColumnIndex))
						record.FECHA_ULTIMO_BLOQUEO = Convert.ToDateTime(reader.GetValue(fecha_ultimo_bloqueoColumnIndex));
					if(!reader.IsDBNull(usuario_ultimo_desbloqueo_idColumnIndex))
						record.USUARIO_ULTIMO_DESBLOQUEO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_ultimo_desbloqueo_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultimo_desbloqueoColumnIndex))
						record.FECHA_ULTIMO_DESBLOQUEO = Convert.ToDateTime(reader.GetValue(fecha_ultimo_desbloqueoColumnIndex));
					record.USUARIO_CREACION = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacionColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(nombre_tarjetaColumnIndex))
						record.NOMBRE_TARJETA = Convert.ToString(reader.GetValue(nombre_tarjetaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_TARJETA_CREDI_INF_COMPRow[])(recordList.ToArray(typeof(CTACTE_TARJETA_CREDI_INF_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_TARJETA_CREDI_INF_COMPRow"/> object.</returns>
		protected virtual CTACTE_TARJETA_CREDI_INF_COMPRow MapRow(DataRow row)
		{
			CTACTE_TARJETA_CREDI_INF_COMPRow mappedObject = new CTACTE_TARJETA_CREDI_INF_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROCESADORA"
			dataColumn = dataTable.Columns["CTACTE_PROCESADORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROCESADORA = (decimal)row[dataColumn];
			// Column "CTACTE_TARJETA_CRED_EMIS_ID"
			dataColumn = dataTable.Columns["CTACTE_TARJETA_CRED_EMIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_TARJETA_CRED_EMIS_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_EMISORA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_EMISORA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_EMISORA_ID = (decimal)row[dataColumn];
			// Column "EMISORA"
			dataColumn = dataTable.Columns["EMISORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMISORA = (string)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (string)row[dataColumn];
			// Column "TITULAR"
			dataColumn = dataTable.Columns["TITULAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULAR = (string)row[dataColumn];
			// Column "LIMITE_CREDITO"
			dataColumn = dataTable.Columns["LIMITE_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_CREDITO = (decimal)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			// Column "MOTIVO_ULTIMO_BLOQUEO"
			dataColumn = dataTable.Columns["MOTIVO_ULTIMO_BLOQUEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_ULTIMO_BLOQUEO = (string)row[dataColumn];
			// Column "USUARIO_ULTIMO_BLOQUEO_ID"
			dataColumn = dataTable.Columns["USUARIO_ULTIMO_BLOQUEO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ULTIMO_BLOQUEO_ID = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMO_BLOQUEO"
			dataColumn = dataTable.Columns["FECHA_ULTIMO_BLOQUEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMO_BLOQUEO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ULTIMO_DESBLOQUEO_ID"
			dataColumn = dataTable.Columns["USUARIO_ULTIMO_DESBLOQUEO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ULTIMO_DESBLOQUEO_ID = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMO_DESBLOQUEO"
			dataColumn = dataTable.Columns["FECHA_ULTIMO_DESBLOQUEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMO_DESBLOQUEO = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREACION"
			dataColumn = dataTable.Columns["USUARIO_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "NOMBRE_TARJETA"
			dataColumn = dataTable.Columns["NOMBRE_TARJETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_TARJETA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_TARJETA_CREDI_INF_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_TARJETA_CREDI_INF_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_PROCESADORA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_TARJETA_CRED_EMIS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_EMISORA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMISORA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TITULAR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LIMITE_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOTIVO_ULTIMO_BLOQUEO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ULTIMO_BLOQUEO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMO_BLOQUEO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ULTIMO_DESBLOQUEO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMO_DESBLOQUEO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_TARJETA", typeof(string));
			dataColumn.MaxLength = 41;
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

				case "CTACTE_PROCESADORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_TARJETA_CRED_EMIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_EMISORA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EMISORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TITULAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIMITE_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MOTIVO_ULTIMO_BLOQUEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ULTIMO_BLOQUEO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMO_BLOQUEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ULTIMO_DESBLOQUEO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMO_DESBLOQUEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE_TARJETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_TARJETA_CREDI_INF_COMPCollection_Base class
}  // End of namespace
