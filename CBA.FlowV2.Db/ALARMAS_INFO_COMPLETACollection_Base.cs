// <fileinfo name="ALARMAS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="ALARMAS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ALARMAS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ALARMAS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string TIPO_ALARMA_IDColumnName = "TIPO_ALARMA_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string USUARIOColumnName = "USUARIO";
		public const string USUARIO_NOMBREColumnName = "USUARIO_NOMBRE";
		public const string USUARIO_APELLIDOColumnName = "USUARIO_APELLIDO";
		public const string ROL_IDColumnName = "ROL_ID";
		public const string ROL_DESCRIPCIONColumnName = "ROL_DESCRIPCION";
		public const string FLUJO_IDColumnName = "FLUJO_ID";
		public const string FLUJO_DESCRIPCIONColumnName = "FLUJO_DESCRIPCION";
		public const string FLUJO_ESTADO_IDColumnName = "FLUJO_ESTADO_ID";
		public const string LOG_CAMPO_IDColumnName = "LOG_CAMPO_ID";
		public const string LOG_CAMPO_TABLA_IDColumnName = "LOG_CAMPO_TABLA_ID";
		public const string LOG_CAMPO_CAMPO_IDColumnName = "LOG_CAMPO_CAMPO_ID";
		public const string TIPO_DATOColumnName = "TIPO_DATO";
		public const string VALOR_INFERIORColumnName = "VALOR_INFERIOR";
		public const string VALOR_SUPERIORColumnName = "VALOR_SUPERIOR";
		public const string TIPO_RANGOColumnName = "TIPO_RANGO";
		public const string MAILColumnName = "MAIL";
		public const string ESTADOColumnName = "ESTADO";
		public const string EXISTENCIA_MAYOR_CEROColumnName = "EXISTENCIA_MAYOR_CERO";
		public const string TIPO_ENVIO_PARA_USUARIOColumnName = "TIPO_ENVIO_PARA_USUARIO";
		public const string RESUMIDOColumnName = "RESUMIDO";
		public const string SQLColumnName = "SQL";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ALARMAS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ALARMAS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ALARMAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual ALARMAS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ALARMAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ALARMAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ALARMAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ALARMAS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ALARMAS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ALARMAS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects.</returns>
		public ALARMAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual ALARMAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ALARMAS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects.</returns>
		protected ALARMAS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects.</returns>
		protected ALARMAS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ALARMAS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual ALARMAS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int tipo_alarma_idColumnIndex = reader.GetOrdinal("TIPO_ALARMA_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int usuarioColumnIndex = reader.GetOrdinal("USUARIO");
			int usuario_nombreColumnIndex = reader.GetOrdinal("USUARIO_NOMBRE");
			int usuario_apellidoColumnIndex = reader.GetOrdinal("USUARIO_APELLIDO");
			int rol_idColumnIndex = reader.GetOrdinal("ROL_ID");
			int rol_descripcionColumnIndex = reader.GetOrdinal("ROL_DESCRIPCION");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");
			int flujo_descripcionColumnIndex = reader.GetOrdinal("FLUJO_DESCRIPCION");
			int flujo_estado_idColumnIndex = reader.GetOrdinal("FLUJO_ESTADO_ID");
			int log_campo_idColumnIndex = reader.GetOrdinal("LOG_CAMPO_ID");
			int log_campo_tabla_idColumnIndex = reader.GetOrdinal("LOG_CAMPO_TABLA_ID");
			int log_campo_campo_idColumnIndex = reader.GetOrdinal("LOG_CAMPO_CAMPO_ID");
			int tipo_datoColumnIndex = reader.GetOrdinal("TIPO_DATO");
			int valor_inferiorColumnIndex = reader.GetOrdinal("VALOR_INFERIOR");
			int valor_superiorColumnIndex = reader.GetOrdinal("VALOR_SUPERIOR");
			int tipo_rangoColumnIndex = reader.GetOrdinal("TIPO_RANGO");
			int mailColumnIndex = reader.GetOrdinal("MAIL");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int existencia_mayor_ceroColumnIndex = reader.GetOrdinal("EXISTENCIA_MAYOR_CERO");
			int tipo_envio_para_usuarioColumnIndex = reader.GetOrdinal("TIPO_ENVIO_PARA_USUARIO");
			int resumidoColumnIndex = reader.GetOrdinal("RESUMIDO");
			int sqlColumnIndex = reader.GetOrdinal("SQL");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ALARMAS_INFO_COMPLETARow record = new ALARMAS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.TIPO_ALARMA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_alarma_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuarioColumnIndex))
						record.USUARIO = Convert.ToString(reader.GetValue(usuarioColumnIndex));
					if(!reader.IsDBNull(usuario_nombreColumnIndex))
						record.USUARIO_NOMBRE = Convert.ToString(reader.GetValue(usuario_nombreColumnIndex));
					if(!reader.IsDBNull(usuario_apellidoColumnIndex))
						record.USUARIO_APELLIDO = Convert.ToString(reader.GetValue(usuario_apellidoColumnIndex));
					if(!reader.IsDBNull(rol_idColumnIndex))
						record.ROL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rol_idColumnIndex)), 9);
					if(!reader.IsDBNull(rol_descripcionColumnIndex))
						record.ROL_DESCRIPCION = Convert.ToString(reader.GetValue(rol_descripcionColumnIndex));
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_descripcionColumnIndex))
						record.FLUJO_DESCRIPCION = Convert.ToString(reader.GetValue(flujo_descripcionColumnIndex));
					if(!reader.IsDBNull(flujo_estado_idColumnIndex))
						record.FLUJO_ESTADO_ID = Convert.ToString(reader.GetValue(flujo_estado_idColumnIndex));
					if(!reader.IsDBNull(log_campo_idColumnIndex))
						record.LOG_CAMPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(log_campo_idColumnIndex)), 9);
					if(!reader.IsDBNull(log_campo_tabla_idColumnIndex))
						record.LOG_CAMPO_TABLA_ID = Convert.ToString(reader.GetValue(log_campo_tabla_idColumnIndex));
					if(!reader.IsDBNull(log_campo_campo_idColumnIndex))
						record.LOG_CAMPO_CAMPO_ID = Convert.ToString(reader.GetValue(log_campo_campo_idColumnIndex));
					if(!reader.IsDBNull(tipo_datoColumnIndex))
						record.TIPO_DATO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_datoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_inferiorColumnIndex))
						record.VALOR_INFERIOR = Convert.ToString(reader.GetValue(valor_inferiorColumnIndex));
					if(!reader.IsDBNull(valor_superiorColumnIndex))
						record.VALOR_SUPERIOR = Convert.ToString(reader.GetValue(valor_superiorColumnIndex));
					if(!reader.IsDBNull(tipo_rangoColumnIndex))
						record.TIPO_RANGO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_rangoColumnIndex)), 9);
					if(!reader.IsDBNull(mailColumnIndex))
						record.MAIL = Convert.ToString(reader.GetValue(mailColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.EXISTENCIA_MAYOR_CERO = Convert.ToString(reader.GetValue(existencia_mayor_ceroColumnIndex));
					if(!reader.IsDBNull(tipo_envio_para_usuarioColumnIndex))
						record.TIPO_ENVIO_PARA_USUARIO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_envio_para_usuarioColumnIndex)), 9);
					record.RESUMIDO = Convert.ToString(reader.GetValue(resumidoColumnIndex));
					if(!reader.IsDBNull(sqlColumnIndex))
						record.SQL = Convert.ToString(reader.GetValue(sqlColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ALARMAS_INFO_COMPLETARow[])(recordList.ToArray(typeof(ALARMAS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ALARMAS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ALARMAS_INFO_COMPLETARow"/> object.</returns>
		protected virtual ALARMAS_INFO_COMPLETARow MapRow(DataRow row)
		{
			ALARMAS_INFO_COMPLETARow mappedObject = new ALARMAS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "TIPO_ALARMA_ID"
			dataColumn = dataTable.Columns["TIPO_ALARMA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ALARMA_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "USUARIO"
			dataColumn = dataTable.Columns["USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO = (string)row[dataColumn];
			// Column "USUARIO_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_NOMBRE = (string)row[dataColumn];
			// Column "USUARIO_APELLIDO"
			dataColumn = dataTable.Columns["USUARIO_APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APELLIDO = (string)row[dataColumn];
			// Column "ROL_ID"
			dataColumn = dataTable.Columns["ROL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_ID = (decimal)row[dataColumn];
			// Column "ROL_DESCRIPCION"
			dataColumn = dataTable.Columns["ROL_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_DESCRIPCION = (string)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			// Column "FLUJO_DESCRIPCION"
			dataColumn = dataTable.Columns["FLUJO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_DESCRIPCION = (string)row[dataColumn];
			// Column "FLUJO_ESTADO_ID"
			dataColumn = dataTable.Columns["FLUJO_ESTADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ESTADO_ID = (string)row[dataColumn];
			// Column "LOG_CAMPO_ID"
			dataColumn = dataTable.Columns["LOG_CAMPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOG_CAMPO_ID = (decimal)row[dataColumn];
			// Column "LOG_CAMPO_TABLA_ID"
			dataColumn = dataTable.Columns["LOG_CAMPO_TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOG_CAMPO_TABLA_ID = (string)row[dataColumn];
			// Column "LOG_CAMPO_CAMPO_ID"
			dataColumn = dataTable.Columns["LOG_CAMPO_CAMPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOG_CAMPO_CAMPO_ID = (string)row[dataColumn];
			// Column "TIPO_DATO"
			dataColumn = dataTable.Columns["TIPO_DATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DATO = (decimal)row[dataColumn];
			// Column "VALOR_INFERIOR"
			dataColumn = dataTable.Columns["VALOR_INFERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_INFERIOR = (string)row[dataColumn];
			// Column "VALOR_SUPERIOR"
			dataColumn = dataTable.Columns["VALOR_SUPERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_SUPERIOR = (string)row[dataColumn];
			// Column "TIPO_RANGO"
			dataColumn = dataTable.Columns["TIPO_RANGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_RANGO = (decimal)row[dataColumn];
			// Column "MAIL"
			dataColumn = dataTable.Columns["MAIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAIL = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "EXISTENCIA_MAYOR_CERO"
			dataColumn = dataTable.Columns["EXISTENCIA_MAYOR_CERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EXISTENCIA_MAYOR_CERO = (string)row[dataColumn];
			// Column "TIPO_ENVIO_PARA_USUARIO"
			dataColumn = dataTable.Columns["TIPO_ENVIO_PARA_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_ENVIO_PARA_USUARIO = (decimal)row[dataColumn];
			// Column "RESUMIDO"
			dataColumn = dataTable.Columns["RESUMIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RESUMIDO = (string)row[dataColumn];
			// Column "SQL"
			dataColumn = dataTable.Columns["SQL"];
			if(!row.IsNull(dataColumn))
				mappedObject.SQL = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ALARMAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ALARMAS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_ALARMA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_APELLIDO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ROL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ROL_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FLUJO_ESTADO_ID", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOG_CAMPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOG_CAMPO_TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOG_CAMPO_CAMPO_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DATO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_INFERIOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_SUPERIOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_RANGO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MAIL", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EXISTENCIA_MAYOR_CERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_ENVIO_PARA_USUARIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RESUMIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SQL", typeof(string));
			dataColumn.MaxLength = 2500;
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_ALARMA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ROL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FLUJO_ESTADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOG_CAMPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOG_CAMPO_TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOG_CAMPO_CAMPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_DATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_INFERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VALOR_SUPERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_RANGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MAIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EXISTENCIA_MAYOR_CERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_ENVIO_PARA_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RESUMIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SQL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ALARMAS_INFO_COMPLETACollection_Base class
}  // End of namespace
