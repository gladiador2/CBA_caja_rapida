// <fileinfo name="MARCACIONES_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="MARCACIONES_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="MARCACIONES_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MARCACIONES_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string RELOJ_MARCACION_IDColumnName = "RELOJ_MARCACION_ID";
		public const string RELOJ_FUNCIONARIO_IDColumnName = "RELOJ_FUNCIONARIO_ID";
		public const string FECHA_MARCACIONColumnName = "FECHA_MARCACION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string CALIFICACIONColumnName = "CALIFICACION";
		public const string ES_COPIADOColumnName = "ES_COPIADO";
		public const string JUSTIFICADOColumnName = "JUSTIFICADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TIPO_MOVIMIENTOColumnName = "TIPO_MOVIMIENTO";
		public const string FECHA_COPIADOColumnName = "FECHA_COPIADO";
		public const string DESCONTARColumnName = "DESCONTAR";
		public const string DESCONTADOColumnName = "DESCONTADO";
		public const string NOMBRE_COMPLETOColumnName = "NOMBRE_COMPLETO";
		public const string CODIGOColumnName = "CODIGO";
		public const string TURNO_ENTRADA_ANTESColumnName = "TURNO_ENTRADA_ANTES";
		public const string TURNO_ENTRADAColumnName = "TURNO_ENTRADA";
		public const string TURNO_ENTRADA_DESPUESColumnName = "TURNO_ENTRADA_DESPUES";
		public const string TURNO_SALIDA_ANTESColumnName = "TURNO_SALIDA_ANTES";
		public const string TURNO_SALIDAColumnName = "TURNO_SALIDA";
		public const string TURNO_SALIDA_DESPUESColumnName = "TURNO_SALIDA_DESPUES";
		public const string TURNO_IDColumnName = "TURNO_ID";
		public const string DESCUENTO_LLEGADA_TARDIA_IDColumnName = "DESCUENTO_LLEGADA_TARDIA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="MARCACIONES_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public MARCACIONES_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>MARCACIONES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects.</returns>
		public virtual MARCACIONES_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>MARCACIONES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>MARCACIONES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="MARCACIONES_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="MARCACIONES_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public MARCACIONES_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			MARCACIONES_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects.</returns>
		public MARCACIONES_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects.</returns>
		public virtual MARCACIONES_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.MARCACIONES_INFO_COMPL";
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
		/// <returns>An array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects.</returns>
		protected MARCACIONES_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects.</returns>
		protected MARCACIONES_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="MARCACIONES_INFO_COMPLRow"/> objects.</returns>
		protected virtual MARCACIONES_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int reloj_marcacion_idColumnIndex = reader.GetOrdinal("RELOJ_MARCACION_ID");
			int reloj_funcionario_idColumnIndex = reader.GetOrdinal("RELOJ_FUNCIONARIO_ID");
			int fecha_marcacionColumnIndex = reader.GetOrdinal("FECHA_MARCACION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int calificacionColumnIndex = reader.GetOrdinal("CALIFICACION");
			int es_copiadoColumnIndex = reader.GetOrdinal("ES_COPIADO");
			int justificadoColumnIndex = reader.GetOrdinal("JUSTIFICADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int tipo_movimientoColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO");
			int fecha_copiadoColumnIndex = reader.GetOrdinal("FECHA_COPIADO");
			int descontarColumnIndex = reader.GetOrdinal("DESCONTAR");
			int descontadoColumnIndex = reader.GetOrdinal("DESCONTADO");
			int nombre_completoColumnIndex = reader.GetOrdinal("NOMBRE_COMPLETO");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int turno_entrada_antesColumnIndex = reader.GetOrdinal("TURNO_ENTRADA_ANTES");
			int turno_entradaColumnIndex = reader.GetOrdinal("TURNO_ENTRADA");
			int turno_entrada_despuesColumnIndex = reader.GetOrdinal("TURNO_ENTRADA_DESPUES");
			int turno_salida_antesColumnIndex = reader.GetOrdinal("TURNO_SALIDA_ANTES");
			int turno_salidaColumnIndex = reader.GetOrdinal("TURNO_SALIDA");
			int turno_salida_despuesColumnIndex = reader.GetOrdinal("TURNO_SALIDA_DESPUES");
			int turno_idColumnIndex = reader.GetOrdinal("TURNO_ID");
			int descuento_llegada_tardia_idColumnIndex = reader.GetOrdinal("DESCUENTO_LLEGADA_TARDIA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					MARCACIONES_INFO_COMPLRow record = new MARCACIONES_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(reloj_marcacion_idColumnIndex))
						record.RELOJ_MARCACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reloj_marcacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(reloj_funcionario_idColumnIndex))
						record.RELOJ_FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(reloj_funcionario_idColumnIndex)), 9);
					record.FECHA_MARCACION = Convert.ToDateTime(reader.GetValue(fecha_marcacionColumnIndex));
					if(!reader.IsDBNull(funcionario_idColumnIndex))
						record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(calificacionColumnIndex))
						record.CALIFICACION = Math.Round(Convert.ToDecimal(reader.GetValue(calificacionColumnIndex)), 9);
					if(!reader.IsDBNull(es_copiadoColumnIndex))
						record.ES_COPIADO = Convert.ToString(reader.GetValue(es_copiadoColumnIndex));
					if(!reader.IsDBNull(justificadoColumnIndex))
						record.JUSTIFICADO = Convert.ToString(reader.GetValue(justificadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(tipo_movimientoColumnIndex))
						record.TIPO_MOVIMIENTO = Convert.ToString(reader.GetValue(tipo_movimientoColumnIndex));
					if(!reader.IsDBNull(fecha_copiadoColumnIndex))
						record.FECHA_COPIADO = Convert.ToDateTime(reader.GetValue(fecha_copiadoColumnIndex));
					if(!reader.IsDBNull(descontarColumnIndex))
						record.DESCONTAR = Convert.ToString(reader.GetValue(descontarColumnIndex));
					if(!reader.IsDBNull(descontadoColumnIndex))
						record.DESCONTADO = Convert.ToString(reader.GetValue(descontadoColumnIndex));
					if(!reader.IsDBNull(nombre_completoColumnIndex))
						record.NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(nombre_completoColumnIndex));
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(turno_entrada_antesColumnIndex))
						record.TURNO_ENTRADA_ANTES = Convert.ToDateTime(reader.GetValue(turno_entrada_antesColumnIndex));
					if(!reader.IsDBNull(turno_entradaColumnIndex))
						record.TURNO_ENTRADA = Convert.ToDateTime(reader.GetValue(turno_entradaColumnIndex));
					if(!reader.IsDBNull(turno_entrada_despuesColumnIndex))
						record.TURNO_ENTRADA_DESPUES = Convert.ToDateTime(reader.GetValue(turno_entrada_despuesColumnIndex));
					if(!reader.IsDBNull(turno_salida_antesColumnIndex))
						record.TURNO_SALIDA_ANTES = Convert.ToDateTime(reader.GetValue(turno_salida_antesColumnIndex));
					if(!reader.IsDBNull(turno_salidaColumnIndex))
						record.TURNO_SALIDA = Convert.ToDateTime(reader.GetValue(turno_salidaColumnIndex));
					if(!reader.IsDBNull(turno_salida_despuesColumnIndex))
						record.TURNO_SALIDA_DESPUES = Convert.ToDateTime(reader.GetValue(turno_salida_despuesColumnIndex));
					if(!reader.IsDBNull(turno_idColumnIndex))
						record.TURNO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(turno_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuento_llegada_tardia_idColumnIndex))
						record.DESCUENTO_LLEGADA_TARDIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_llegada_tardia_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (MARCACIONES_INFO_COMPLRow[])(recordList.ToArray(typeof(MARCACIONES_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="MARCACIONES_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="MARCACIONES_INFO_COMPLRow"/> object.</returns>
		protected virtual MARCACIONES_INFO_COMPLRow MapRow(DataRow row)
		{
			MARCACIONES_INFO_COMPLRow mappedObject = new MARCACIONES_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "RELOJ_MARCACION_ID"
			dataColumn = dataTable.Columns["RELOJ_MARCACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RELOJ_MARCACION_ID = (decimal)row[dataColumn];
			// Column "RELOJ_FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["RELOJ_FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RELOJ_FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA_MARCACION"
			dataColumn = dataTable.Columns["FECHA_MARCACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MARCACION = (System.DateTime)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "CALIFICACION"
			dataColumn = dataTable.Columns["CALIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALIFICACION = (decimal)row[dataColumn];
			// Column "ES_COPIADO"
			dataColumn = dataTable.Columns["ES_COPIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COPIADO = (string)row[dataColumn];
			// Column "JUSTIFICADO"
			dataColumn = dataTable.Columns["JUSTIFICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.JUSTIFICADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TIPO_MOVIMIENTO"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO = (string)row[dataColumn];
			// Column "FECHA_COPIADO"
			dataColumn = dataTable.Columns["FECHA_COPIADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COPIADO = (System.DateTime)row[dataColumn];
			// Column "DESCONTAR"
			dataColumn = dataTable.Columns["DESCONTAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONTAR = (string)row[dataColumn];
			// Column "DESCONTADO"
			dataColumn = dataTable.Columns["DESCONTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONTADO = (string)row[dataColumn];
			// Column "NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "TURNO_ENTRADA_ANTES"
			dataColumn = dataTable.Columns["TURNO_ENTRADA_ANTES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ENTRADA_ANTES = (System.DateTime)row[dataColumn];
			// Column "TURNO_ENTRADA"
			dataColumn = dataTable.Columns["TURNO_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ENTRADA = (System.DateTime)row[dataColumn];
			// Column "TURNO_ENTRADA_DESPUES"
			dataColumn = dataTable.Columns["TURNO_ENTRADA_DESPUES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ENTRADA_DESPUES = (System.DateTime)row[dataColumn];
			// Column "TURNO_SALIDA_ANTES"
			dataColumn = dataTable.Columns["TURNO_SALIDA_ANTES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_SALIDA_ANTES = (System.DateTime)row[dataColumn];
			// Column "TURNO_SALIDA"
			dataColumn = dataTable.Columns["TURNO_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_SALIDA = (System.DateTime)row[dataColumn];
			// Column "TURNO_SALIDA_DESPUES"
			dataColumn = dataTable.Columns["TURNO_SALIDA_DESPUES"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_SALIDA_DESPUES = (System.DateTime)row[dataColumn];
			// Column "TURNO_ID"
			dataColumn = dataTable.Columns["TURNO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TURNO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTO_LLEGADA_TARDIA_ID"
			dataColumn = dataTable.Columns["DESCUENTO_LLEGADA_TARDIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_LLEGADA_TARDIA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>MARCACIONES_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "MARCACIONES_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RELOJ_MARCACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RELOJ_FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MARCACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALIFICACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_COPIADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("JUSTIFICADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_COPIADO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCONTAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCONTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_ENTRADA_ANTES", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_ENTRADA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_ENTRADA_DESPUES", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_SALIDA_ANTES", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_SALIDA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_SALIDA_DESPUES", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TURNO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTO_LLEGADA_TARDIA_ID", typeof(decimal));
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

				case "RELOJ_MARCACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RELOJ_FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_MARCACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_COPIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "JUSTIFICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.String, value);
					break;

				case "TIPO_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_COPIADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESCONTAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCONTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TURNO_ENTRADA_ANTES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_ENTRADA_DESPUES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_SALIDA_ANTES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_SALIDA_DESPUES":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TURNO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_LLEGADA_TARDIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of MARCACIONES_INFO_COMPLCollection_Base class
}  // End of namespace
