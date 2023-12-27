// <fileinfo name="CTB_ASIENTOS_DET_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_DET_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_DET_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_DET_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_ASIENTO_IDColumnName = "CTB_ASIENTO_ID";
		public const string CTB_CUENTA_IDColumnName = "CTB_CUENTA_ID";
		public const string CTB_PLAN_CUENTA_IDColumnName = "CTB_PLAN_CUENTA_ID";
		public const string CTB_PLAN_CUENTA_NOMBREColumnName = "CTB_PLAN_CUENTA_NOMBRE";
		public const string CTB_CUENTA_CODIGO_COMPLETOColumnName = "CTB_CUENTA_CODIGO_COMPLETO";
		public const string CODIGO_COMPLETO_SIN_CEROSColumnName = "CODIGO_COMPLETO_SIN_CEROS";
		public const string CTB_CUENTA_NOMBREColumnName = "CTB_CUENTA_NOMBRE";
		public const string CTB_CUENTA_MADRE_IDColumnName = "CTB_CUENTA_MADRE_ID";
		public const string DEBEColumnName = "DEBE";
		public const string HABERColumnName = "HABER";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string ORDENColumnName = "ORDEN";
		public const string DEBE_ORIGENColumnName = "DEBE_ORIGEN";
		public const string HABER_ORIGENColumnName = "HABER_ORIGEN";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONEDA_ORIGEN_NOMBREColumnName = "MONEDA_ORIGEN_NOMBRE";
		public const string MONEDA_ORIGEN_SIMBOLOColumnName = "MONEDA_ORIGEN_SIMBOLO";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string OBSERVACION_SISTEMAColumnName = "OBSERVACION_SISTEMA";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string CTB_EJERCICIO_IDColumnName = "CTB_EJERCICIO_ID";
		public const string USUARIO_CREACION_NOMBREColumnName = "USUARIO_CREACION_NOMBRE";
		public const string ESTADOColumnName = "ESTADO";
		public const string CENTROS_COSTOSColumnName = "CENTROS_COSTOS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_DET_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_DET_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DET_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_DET_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_DET_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		public CTB_ASIENTOS_DET_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_ASIENTOS_DET_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_DET_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_ASIENTOS_DET_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_ASIENTOS_DET_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_DET_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_asiento_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_ID");
			int ctb_cuenta_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_ID");
			int ctb_plan_cuenta_idColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_ID");
			int ctb_plan_cuenta_nombreColumnIndex = reader.GetOrdinal("CTB_PLAN_CUENTA_NOMBRE");
			int ctb_cuenta_codigo_completoColumnIndex = reader.GetOrdinal("CTB_CUENTA_CODIGO_COMPLETO");
			int codigo_completo_sin_cerosColumnIndex = reader.GetOrdinal("CODIGO_COMPLETO_SIN_CEROS");
			int ctb_cuenta_nombreColumnIndex = reader.GetOrdinal("CTB_CUENTA_NOMBRE");
			int ctb_cuenta_madre_idColumnIndex = reader.GetOrdinal("CTB_CUENTA_MADRE_ID");
			int debeColumnIndex = reader.GetOrdinal("DEBE");
			int haberColumnIndex = reader.GetOrdinal("HABER");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int debe_origenColumnIndex = reader.GetOrdinal("DEBE_ORIGEN");
			int haber_origenColumnIndex = reader.GetOrdinal("HABER_ORIGEN");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int moneda_origen_nombreColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_NOMBRE");
			int moneda_origen_simboloColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_SIMBOLO");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int observacion_sistemaColumnIndex = reader.GetOrdinal("OBSERVACION_SISTEMA");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int ctb_ejercicio_idColumnIndex = reader.GetOrdinal("CTB_EJERCICIO_ID");
			int usuario_creacion_nombreColumnIndex = reader.GetOrdinal("USUARIO_CREACION_NOMBRE");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int centros_costosColumnIndex = reader.GetOrdinal("CENTROS_COSTOS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_DET_INFO_COMPLETARow record = new CTB_ASIENTOS_DET_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_ASIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_idColumnIndex)), 9);
					record.CTB_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_plan_cuenta_idColumnIndex)), 9);
					record.CTB_PLAN_CUENTA_NOMBRE = Convert.ToString(reader.GetValue(ctb_plan_cuenta_nombreColumnIndex));
					if(!reader.IsDBNull(ctb_cuenta_codigo_completoColumnIndex))
						record.CTB_CUENTA_CODIGO_COMPLETO = Convert.ToString(reader.GetValue(ctb_cuenta_codigo_completoColumnIndex));
					if(!reader.IsDBNull(codigo_completo_sin_cerosColumnIndex))
						record.CODIGO_COMPLETO_SIN_CEROS = Convert.ToString(reader.GetValue(codigo_completo_sin_cerosColumnIndex));
					record.CTB_CUENTA_NOMBRE = Convert.ToString(reader.GetValue(ctb_cuenta_nombreColumnIndex));
					if(!reader.IsDBNull(ctb_cuenta_madre_idColumnIndex))
						record.CTB_CUENTA_MADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuenta_madre_idColumnIndex)), 9);
					record.DEBE = Math.Round(Convert.ToDecimal(reader.GetValue(debeColumnIndex)), 9);
					record.HABER = Math.Round(Convert.ToDecimal(reader.GetValue(haberColumnIndex)), 9);
					record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(ordenColumnIndex))
						record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(debe_origenColumnIndex))
						record.DEBE_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(debe_origenColumnIndex)), 9);
					if(!reader.IsDBNull(haber_origenColumnIndex))
						record.HABER_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(haber_origenColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_origen_nombreColumnIndex))
						record.MONEDA_ORIGEN_NOMBRE = Convert.ToString(reader.GetValue(moneda_origen_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_origen_simboloColumnIndex))
						record.MONEDA_ORIGEN_SIMBOLO = Convert.ToString(reader.GetValue(moneda_origen_simboloColumnIndex));
					if(!reader.IsDBNull(cotizacion_moneda_origenColumnIndex))
						record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_sistemaColumnIndex))
						record.OBSERVACION_SISTEMA = Convert.ToString(reader.GetValue(observacion_sistemaColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.CTB_EJERCICIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_ejercicio_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creacion_nombreColumnIndex))
						record.USUARIO_CREACION_NOMBRE = Convert.ToString(reader.GetValue(usuario_creacion_nombreColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(centros_costosColumnIndex))
						record.CENTROS_COSTOS = Convert.ToString(reader.GetValue(centros_costosColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_DET_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTB_ASIENTOS_DET_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_DET_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTB_ASIENTOS_DET_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTB_ASIENTOS_DET_INFO_COMPLETARow mappedObject = new CTB_ASIENTOS_DET_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_ASIENTO_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_ID = (decimal)row[dataColumn];
			// Column "CTB_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_ID"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_ID = (decimal)row[dataColumn];
			// Column "CTB_PLAN_CUENTA_NOMBRE"
			dataColumn = dataTable.Columns["CTB_PLAN_CUENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PLAN_CUENTA_NOMBRE = (string)row[dataColumn];
			// Column "CTB_CUENTA_CODIGO_COMPLETO"
			dataColumn = dataTable.Columns["CTB_CUENTA_CODIGO_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_CODIGO_COMPLETO = (string)row[dataColumn];
			// Column "CODIGO_COMPLETO_SIN_CEROS"
			dataColumn = dataTable.Columns["CODIGO_COMPLETO_SIN_CEROS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_COMPLETO_SIN_CEROS = (string)row[dataColumn];
			// Column "CTB_CUENTA_NOMBRE"
			dataColumn = dataTable.Columns["CTB_CUENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_NOMBRE = (string)row[dataColumn];
			// Column "CTB_CUENTA_MADRE_ID"
			dataColumn = dataTable.Columns["CTB_CUENTA_MADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA_MADRE_ID = (decimal)row[dataColumn];
			// Column "DEBE"
			dataColumn = dataTable.Columns["DEBE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBE = (decimal)row[dataColumn];
			// Column "HABER"
			dataColumn = dataTable.Columns["HABER"];
			if(!row.IsNull(dataColumn))
				mappedObject.HABER = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
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
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "DEBE_ORIGEN"
			dataColumn = dataTable.Columns["DEBE_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBE_ORIGEN = (decimal)row[dataColumn];
			// Column "HABER_ORIGEN"
			dataColumn = dataTable.Columns["HABER_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.HABER_ORIGEN = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_ORIGEN_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_SIMBOLO = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "OBSERVACION_SISTEMA"
			dataColumn = dataTable.Columns["OBSERVACION_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_SISTEMA = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "CTB_EJERCICIO_ID"
			dataColumn = dataTable.Columns["CTB_EJERCICIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_EJERCICIO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_CREACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_NOMBRE = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CENTROS_COSTOS"
			dataColumn = dataTable.Columns["CENTROS_COSTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTROS_COSTOS = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_DET_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_DET_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PLAN_CUENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_CODIGO_COMPLETO", typeof(string));
			dataColumn.MaxLength = 113;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_COMPLETO_SIN_CEROS", typeof(string));
			dataColumn.MaxLength = 201;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_CUENTA_MADRE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEBE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HABER", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEBE_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HABER_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION_SISTEMA", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_EJERCICIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTROS_COSTOS", typeof(string));
			dataColumn.MaxLength = 4000;
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

				case "CTB_ASIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_PLAN_CUENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_PLAN_CUENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CUENTA_CODIGO_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_COMPLETO_SIN_CEROS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CUENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_CUENTA_MADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HABER":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
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

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBE_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HABER_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ORIGEN_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_EJERCICIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CENTROS_COSTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_DET_INFO_COMPLETACollection_Base class
}  // End of namespace
