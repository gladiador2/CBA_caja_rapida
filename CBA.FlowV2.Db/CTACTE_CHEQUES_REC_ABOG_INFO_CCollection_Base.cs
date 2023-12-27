// <fileinfo name="CTACTE_CHEQUES_REC_ABOG_INFO_CCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_CHEQUES_REC_ABOG_INFO_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTACTE_CHEQUE_RECIBIDO_IDColumnName = "CTACTE_CHEQUE_RECIBIDO_ID";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string CTACTE_BANCO_NOMBREColumnName = "CTACTE_BANCO_NOMBRE";
		public const string NUMERO_CUENTAColumnName = "NUMERO_CUENTA";
		public const string NUMERO_CHEQUEColumnName = "NUMERO_CHEQUE";
		public const string NOMBRE_EMISORColumnName = "NOMBRE_EMISOR";
		public const string NOMBRE_BENEFICIARIOColumnName = "NOMBRE_BENEFICIARIO";
		public const string NUMERO_DOCUMENTO_EMISORColumnName = "NUMERO_DOCUMENTO_EMISOR";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string FECHA_POSDATADOColumnName = "FECHA_POSDATADO";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_COBROColumnName = "FECHA_COBRO";
		public const string FECHA_RECHAZOColumnName = "FECHA_RECHAZO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDAS_NOMBREColumnName = "MONEDAS_NOMBRE";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTOColumnName = "MONTO";
		public const string MOTIVO_RECHAZOColumnName = "MOTIVO_RECHAZO";
		public const string CHEQUE_ESTADO_IDColumnName = "CHEQUE_ESTADO_ID";
		public const string ESTADO_CHEQUE_NOMBREColumnName = "ESTADO_CHEQUE_NOMBRE";
		public const string CHEQUE_DE_TERCEROSColumnName = "CHEQUE_DE_TERCEROS";
		public const string ABOGADO_IDColumnName = "ABOGADO_ID";
		public const string ABOGADO_NOMBRE_COMPLETOColumnName = "ABOGADO_NOMBRE_COMPLETO";
		public const string ABOGADO_NOMBRE_ESTUDIOColumnName = "ABOGADO_NOMBRE_ESTUDIO";
		public const string FECHA_ASIGNACIONColumnName = "FECHA_ASIGNACION";
		public const string FECHA_DESASIGNACIONColumnName = "FECHA_DESASIGNACION";
		public const string OBSERVACION_ASIGNACIONColumnName = "OBSERVACION_ASIGNACION";
		public const string OBSERVACION_DESASIGNACIONColumnName = "OBSERVACION_DESASIGNACION";
		public const string USUARIO_ASIGNACION_IDColumnName = "USUARIO_ASIGNACION_ID";
		public const string USUARIO_ASIGNACION_FECHAColumnName = "USUARIO_ASIGNACION_FECHA";
		public const string USUARIO_DESASIGNACION_IDColumnName = "USUARIO_DESASIGNACION_ID";
		public const string USUARIO_DESASIGNACION_FECHAColumnName = "USUARIO_DESASIGNACION_FECHA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_CHEQUES_REC_ABOG_INFO_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_CHEQUES_REC_ABOG_INFO_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOG_INFO_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_CHEQUES_REC_ABOG_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_CHEQUES_REC_ABOG_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_CHEQUES_REC_ABOG_INFO_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_CHEQUES_REC_ABOG_INFO_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects.</returns>
		public CTACTE_CHEQUES_REC_ABOG_INFO_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects.</returns>
		public virtual CTACTE_CHEQUES_REC_ABOG_INFO_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_CHEQUES_REC_ABOG_INFO_C";
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects.</returns>
		protected CTACTE_CHEQUES_REC_ABOG_INFO_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects.</returns>
		protected CTACTE_CHEQUES_REC_ABOG_INFO_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> objects.</returns>
		protected virtual CTACTE_CHEQUES_REC_ABOG_INFO_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctacte_cheque_recibido_idColumnIndex = reader.GetOrdinal("CTACTE_CHEQUE_RECIBIDO_ID");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int ctacte_banco_nombreColumnIndex = reader.GetOrdinal("CTACTE_BANCO_NOMBRE");
			int numero_cuentaColumnIndex = reader.GetOrdinal("NUMERO_CUENTA");
			int numero_chequeColumnIndex = reader.GetOrdinal("NUMERO_CHEQUE");
			int nombre_emisorColumnIndex = reader.GetOrdinal("NOMBRE_EMISOR");
			int nombre_beneficiarioColumnIndex = reader.GetOrdinal("NOMBRE_BENEFICIARIO");
			int numero_documento_emisorColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO_EMISOR");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int fecha_posdatadoColumnIndex = reader.GetOrdinal("FECHA_POSDATADO");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_cobroColumnIndex = reader.GetOrdinal("FECHA_COBRO");
			int fecha_rechazoColumnIndex = reader.GetOrdinal("FECHA_RECHAZO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int monedas_nombreColumnIndex = reader.GetOrdinal("MONEDAS_NOMBRE");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int motivo_rechazoColumnIndex = reader.GetOrdinal("MOTIVO_RECHAZO");
			int cheque_estado_idColumnIndex = reader.GetOrdinal("CHEQUE_ESTADO_ID");
			int estado_cheque_nombreColumnIndex = reader.GetOrdinal("ESTADO_CHEQUE_NOMBRE");
			int cheque_de_tercerosColumnIndex = reader.GetOrdinal("CHEQUE_DE_TERCEROS");
			int abogado_idColumnIndex = reader.GetOrdinal("ABOGADO_ID");
			int abogado_nombre_completoColumnIndex = reader.GetOrdinal("ABOGADO_NOMBRE_COMPLETO");
			int abogado_nombre_estudioColumnIndex = reader.GetOrdinal("ABOGADO_NOMBRE_ESTUDIO");
			int fecha_asignacionColumnIndex = reader.GetOrdinal("FECHA_ASIGNACION");
			int fecha_desasignacionColumnIndex = reader.GetOrdinal("FECHA_DESASIGNACION");
			int observacion_asignacionColumnIndex = reader.GetOrdinal("OBSERVACION_ASIGNACION");
			int observacion_desasignacionColumnIndex = reader.GetOrdinal("OBSERVACION_DESASIGNACION");
			int usuario_asignacion_idColumnIndex = reader.GetOrdinal("USUARIO_ASIGNACION_ID");
			int usuario_asignacion_fechaColumnIndex = reader.GetOrdinal("USUARIO_ASIGNACION_FECHA");
			int usuario_desasignacion_idColumnIndex = reader.GetOrdinal("USUARIO_DESASIGNACION_ID");
			int usuario_desasignacion_fechaColumnIndex = reader.GetOrdinal("USUARIO_DESASIGNACION_FECHA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_CHEQUES_REC_ABOG_INFO_CRow record = new CTACTE_CHEQUES_REC_ABOG_INFO_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTACTE_CHEQUE_RECIBIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_cheque_recibido_idColumnIndex)), 9);
					record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					record.CTACTE_BANCO_NOMBRE = Convert.ToString(reader.GetValue(ctacte_banco_nombreColumnIndex));
					if(!reader.IsDBNull(numero_cuentaColumnIndex))
						record.NUMERO_CUENTA = Convert.ToString(reader.GetValue(numero_cuentaColumnIndex));
					record.NUMERO_CHEQUE = Convert.ToString(reader.GetValue(numero_chequeColumnIndex));
					if(!reader.IsDBNull(nombre_emisorColumnIndex))
						record.NOMBRE_EMISOR = Convert.ToString(reader.GetValue(nombre_emisorColumnIndex));
					if(!reader.IsDBNull(nombre_beneficiarioColumnIndex))
						record.NOMBRE_BENEFICIARIO = Convert.ToString(reader.GetValue(nombre_beneficiarioColumnIndex));
					if(!reader.IsDBNull(numero_documento_emisorColumnIndex))
						record.NUMERO_DOCUMENTO_EMISOR = Convert.ToString(reader.GetValue(numero_documento_emisorColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.FECHA_POSDATADO = Convert.ToDateTime(reader.GetValue(fecha_posdatadoColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_cobroColumnIndex))
						record.FECHA_COBRO = Convert.ToDateTime(reader.GetValue(fecha_cobroColumnIndex));
					if(!reader.IsDBNull(fecha_rechazoColumnIndex))
						record.FECHA_RECHAZO = Convert.ToDateTime(reader.GetValue(fecha_rechazoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDAS_NOMBRE = Convert.ToString(reader.GetValue(monedas_nombreColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					if(!reader.IsDBNull(motivo_rechazoColumnIndex))
						record.MOTIVO_RECHAZO = Convert.ToString(reader.GetValue(motivo_rechazoColumnIndex));
					if(!reader.IsDBNull(cheque_estado_idColumnIndex))
						record.CHEQUE_ESTADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cheque_estado_idColumnIndex)), 9);
					record.ESTADO_CHEQUE_NOMBRE = Convert.ToString(reader.GetValue(estado_cheque_nombreColumnIndex));
					if(!reader.IsDBNull(cheque_de_tercerosColumnIndex))
						record.CHEQUE_DE_TERCEROS = Convert.ToString(reader.GetValue(cheque_de_tercerosColumnIndex));
					record.ABOGADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(abogado_idColumnIndex)), 9);
					if(!reader.IsDBNull(abogado_nombre_completoColumnIndex))
						record.ABOGADO_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(abogado_nombre_completoColumnIndex));
					record.ABOGADO_NOMBRE_ESTUDIO = Convert.ToString(reader.GetValue(abogado_nombre_estudioColumnIndex));
					record.FECHA_ASIGNACION = Convert.ToDateTime(reader.GetValue(fecha_asignacionColumnIndex));
					if(!reader.IsDBNull(fecha_desasignacionColumnIndex))
						record.FECHA_DESASIGNACION = Convert.ToDateTime(reader.GetValue(fecha_desasignacionColumnIndex));
					if(!reader.IsDBNull(observacion_asignacionColumnIndex))
						record.OBSERVACION_ASIGNACION = Convert.ToString(reader.GetValue(observacion_asignacionColumnIndex));
					if(!reader.IsDBNull(observacion_desasignacionColumnIndex))
						record.OBSERVACION_DESASIGNACION = Convert.ToString(reader.GetValue(observacion_desasignacionColumnIndex));
					record.USUARIO_ASIGNACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_asignacion_idColumnIndex)), 9);
					record.USUARIO_ASIGNACION_FECHA = Convert.ToDateTime(reader.GetValue(usuario_asignacion_fechaColumnIndex));
					if(!reader.IsDBNull(usuario_desasignacion_idColumnIndex))
						record.USUARIO_DESASIGNACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_desasignacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_desasignacion_fechaColumnIndex))
						record.USUARIO_DESASIGNACION_FECHA = Convert.ToDateTime(reader.GetValue(usuario_desasignacion_fechaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_CHEQUES_REC_ABOG_INFO_CRow[])(recordList.ToArray(typeof(CTACTE_CHEQUES_REC_ABOG_INFO_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_CHEQUES_REC_ABOG_INFO_CRow"/> object.</returns>
		protected virtual CTACTE_CHEQUES_REC_ABOG_INFO_CRow MapRow(DataRow row)
		{
			CTACTE_CHEQUES_REC_ABOG_INFO_CRow mappedObject = new CTACTE_CHEQUES_REC_ABOG_INFO_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTACTE_CHEQUE_RECIBIDO_ID"
			dataColumn = dataTable.Columns["CTACTE_CHEQUE_RECIBIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CHEQUE_RECIBIDO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_BANCO_NOMBRE"
			dataColumn = dataTable.Columns["CTACTE_BANCO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_NOMBRE = (string)row[dataColumn];
			// Column "NUMERO_CUENTA"
			dataColumn = dataTable.Columns["NUMERO_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUENTA = (string)row[dataColumn];
			// Column "NUMERO_CHEQUE"
			dataColumn = dataTable.Columns["NUMERO_CHEQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CHEQUE = (string)row[dataColumn];
			// Column "NOMBRE_EMISOR"
			dataColumn = dataTable.Columns["NOMBRE_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_EMISOR = (string)row[dataColumn];
			// Column "NOMBRE_BENEFICIARIO"
			dataColumn = dataTable.Columns["NOMBRE_BENEFICIARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_BENEFICIARIO = (string)row[dataColumn];
			// Column "NUMERO_DOCUMENTO_EMISOR"
			dataColumn = dataTable.Columns["NUMERO_DOCUMENTO_EMISOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_DOCUMENTO_EMISOR = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_POSDATADO"
			dataColumn = dataTable.Columns["FECHA_POSDATADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_POSDATADO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_COBRO"
			dataColumn = dataTable.Columns["FECHA_COBRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_COBRO = (System.DateTime)row[dataColumn];
			// Column "FECHA_RECHAZO"
			dataColumn = dataTable.Columns["FECHA_RECHAZO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_RECHAZO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDAS_NOMBRE"
			dataColumn = dataTable.Columns["MONEDAS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDAS_NOMBRE = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "MOTIVO_RECHAZO"
			dataColumn = dataTable.Columns["MOTIVO_RECHAZO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_RECHAZO = (string)row[dataColumn];
			// Column "CHEQUE_ESTADO_ID"
			dataColumn = dataTable.Columns["CHEQUE_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_ESTADO_ID = (decimal)row[dataColumn];
			// Column "ESTADO_CHEQUE_NOMBRE"
			dataColumn = dataTable.Columns["ESTADO_CHEQUE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CHEQUE_NOMBRE = (string)row[dataColumn];
			// Column "CHEQUE_DE_TERCEROS"
			dataColumn = dataTable.Columns["CHEQUE_DE_TERCEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHEQUE_DE_TERCEROS = (string)row[dataColumn];
			// Column "ABOGADO_ID"
			dataColumn = dataTable.Columns["ABOGADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABOGADO_ID = (decimal)row[dataColumn];
			// Column "ABOGADO_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["ABOGADO_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABOGADO_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "ABOGADO_NOMBRE_ESTUDIO"
			dataColumn = dataTable.Columns["ABOGADO_NOMBRE_ESTUDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABOGADO_NOMBRE_ESTUDIO = (string)row[dataColumn];
			// Column "FECHA_ASIGNACION"
			dataColumn = dataTable.Columns["FECHA_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ASIGNACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_DESASIGNACION"
			dataColumn = dataTable.Columns["FECHA_DESASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESASIGNACION = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION_ASIGNACION"
			dataColumn = dataTable.Columns["OBSERVACION_ASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_ASIGNACION = (string)row[dataColumn];
			// Column "OBSERVACION_DESASIGNACION"
			dataColumn = dataTable.Columns["OBSERVACION_DESASIGNACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_DESASIGNACION = (string)row[dataColumn];
			// Column "USUARIO_ASIGNACION_ID"
			dataColumn = dataTable.Columns["USUARIO_ASIGNACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ASIGNACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ASIGNACION_FECHA"
			dataColumn = dataTable.Columns["USUARIO_ASIGNACION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ASIGNACION_FECHA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_DESASIGNACION_ID"
			dataColumn = dataTable.Columns["USUARIO_DESASIGNACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_DESASIGNACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_DESASIGNACION_FECHA"
			dataColumn = dataTable.Columns["USUARIO_DESASIGNACION_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_DESASIGNACION_FECHA = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_CHEQUES_REC_ABOG_INFO_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_CHEQUES_REC_ABOG_INFO_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_CHEQUE_RECIBIDO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CUENTA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_CHEQUE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_EMISOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_BENEFICIARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO_EMISOR", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_POSDATADO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_COBRO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_RECHAZO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDAS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOTIVO_RECHAZO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_ESTADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_CHEQUE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHEQUE_DE_TERCEROS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ABOGADO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ABOGADO_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ABOGADO_NOMBRE_ESTUDIO", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ASIGNACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_DESASIGNACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION_ASIGNACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION_DESASIGNACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ASIGNACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ASIGNACION_FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_DESASIGNACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_DESASIGNACION_FECHA", typeof(System.DateTime));
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

				case "CTACTE_CHEQUE_RECIBIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CHEQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_BENEFICIARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_DOCUMENTO_EMISOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_POSDATADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_COBRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_RECHAZO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDAS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOTIVO_RECHAZO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_CHEQUE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHEQUE_DE_TERCEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ABOGADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ABOGADO_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABOGADO_NOMBRE_ESTUDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DESASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION_ASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION_DESASIGNACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ASIGNACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ASIGNACION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_DESASIGNACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_DESASIGNACION_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_CHEQUES_REC_ABOG_INFO_CCollection_Base class
}  // End of namespace
