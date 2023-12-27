// <fileinfo name="CTB_ASIENTOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CTB_ASIENTOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_ASIENTOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_ASIENTOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string CTB_PERIODO_IDColumnName = "CTB_PERIODO_ID";
		public const string CTB_PERIODO_NOMBREColumnName = "CTB_PERIODO_NOMBRE";
		public const string CTB_PERIODO_VIGENTEColumnName = "CTB_PERIODO_VIGENTE";
		public const string CTB_PERIODO_VIGENTE_POR_MARGENColumnName = "CTB_PERIODO_VIGENTE_POR_MARGEN";
		public const string CTB_EJERCICIO_IDColumnName = "CTB_EJERCICIO_ID";
		public const string CTB_EJERCICIO_NOMBREColumnName = "CTB_EJERCICIO_NOMBRE";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string USUARIO_CREACION_NOMBREColumnName = "USUARIO_CREACION_NOMBRE";
		public const string AUTOMATICOColumnName = "AUTOMATICO";
		public const string USUARIO_INACTIVACION_IDColumnName = "USUARIO_INACTIVACION_ID";
		public const string USUARIO_INACTIVACION_NOMBREColumnName = "USUARIO_INACTIVACION_NOMBRE";
		public const string FECHA_INACTIVACIONColumnName = "FECHA_INACTIVACION";
		public const string FECHA_ASIENTOColumnName = "FECHA_ASIENTO";
		public const string NUMEROColumnName = "NUMERO";
		public const string OBSERVACION_SISTEMAColumnName = "OBSERVACION_SISTEMA";
		public const string APROBADOColumnName = "APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string CASO_RELACIONADO_IDColumnName = "CASO_RELACIONADO_ID";
		public const string CASO_RELACIONADO_FLUJO_IDColumnName = "CASO_RELACIONADO_FLUJO_ID";
		public const string CASO_RELACIONADO_FLUJO_DESColumnName = "CASO_RELACIONADO_FLUJO_DES";
		public const string TRANSICION_IDColumnName = "TRANSICION_ID";
		public const string TABLA_RELACIONADA_IDColumnName = "TABLA_RELACIONADA_ID";
		public const string REGISTRO_RELACIONADO_IDColumnName = "REGISTRO_RELACIONADO_ID";
		public const string REVISION_POSTERIORColumnName = "REVISION_POSTERIOR";
		public const string ES_APERTURAColumnName = "ES_APERTURA";
		public const string ES_REGULARIZACIONColumnName = "ES_REGULARIZACION";
		public const string ES_CIERREColumnName = "ES_CIERRE";
		public const string ES_GLOBALColumnName = "ES_GLOBAL";
		public const string CTB_ASIENTO_GLOBAL_IDColumnName = "CTB_ASIENTO_GLOBAL_ID";
		public const string TOTAL_DEBEColumnName = "TOTAL_DEBE";
		public const string TOTAL_HABERColumnName = "TOTAL_HABER";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_ASIENTOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_ASIENTOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_ASIENTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_ASIENTOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_ASIENTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_ASIENTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_ASIENTOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_ASIENTOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects.</returns>
		public CTB_ASIENTOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual CTB_ASIENTOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_ASIENTOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_ASIENTOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects.</returns>
		protected CTB_ASIENTOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CTB_ASIENTOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int ctb_periodo_idColumnIndex = reader.GetOrdinal("CTB_PERIODO_ID");
			int ctb_periodo_nombreColumnIndex = reader.GetOrdinal("CTB_PERIODO_NOMBRE");
			int ctb_periodo_vigenteColumnIndex = reader.GetOrdinal("CTB_PERIODO_VIGENTE");
			int ctb_periodo_vigente_por_margenColumnIndex = reader.GetOrdinal("CTB_PERIODO_VIGENTE_POR_MARGEN");
			int ctb_ejercicio_idColumnIndex = reader.GetOrdinal("CTB_EJERCICIO_ID");
			int ctb_ejercicio_nombreColumnIndex = reader.GetOrdinal("CTB_EJERCICIO_NOMBRE");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int usuario_creacion_nombreColumnIndex = reader.GetOrdinal("USUARIO_CREACION_NOMBRE");
			int automaticoColumnIndex = reader.GetOrdinal("AUTOMATICO");
			int usuario_inactivacion_idColumnIndex = reader.GetOrdinal("USUARIO_INACTIVACION_ID");
			int usuario_inactivacion_nombreColumnIndex = reader.GetOrdinal("USUARIO_INACTIVACION_NOMBRE");
			int fecha_inactivacionColumnIndex = reader.GetOrdinal("FECHA_INACTIVACION");
			int fecha_asientoColumnIndex = reader.GetOrdinal("FECHA_ASIENTO");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int observacion_sistemaColumnIndex = reader.GetOrdinal("OBSERVACION_SISTEMA");
			int aprobadoColumnIndex = reader.GetOrdinal("APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int caso_relacionado_idColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_ID");
			int caso_relacionado_flujo_idColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_FLUJO_ID");
			int caso_relacionado_flujo_desColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_FLUJO_DES");
			int transicion_idColumnIndex = reader.GetOrdinal("TRANSICION_ID");
			int tabla_relacionada_idColumnIndex = reader.GetOrdinal("TABLA_RELACIONADA_ID");
			int registro_relacionado_idColumnIndex = reader.GetOrdinal("REGISTRO_RELACIONADO_ID");
			int revision_posteriorColumnIndex = reader.GetOrdinal("REVISION_POSTERIOR");
			int es_aperturaColumnIndex = reader.GetOrdinal("ES_APERTURA");
			int es_regularizacionColumnIndex = reader.GetOrdinal("ES_REGULARIZACION");
			int es_cierreColumnIndex = reader.GetOrdinal("ES_CIERRE");
			int es_globalColumnIndex = reader.GetOrdinal("ES_GLOBAL");
			int ctb_asiento_global_idColumnIndex = reader.GetOrdinal("CTB_ASIENTO_GLOBAL_ID");
			int total_debeColumnIndex = reader.GetOrdinal("TOTAL_DEBE");
			int total_haberColumnIndex = reader.GetOrdinal("TOTAL_HABER");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_ASIENTOS_INFO_COMPLETARow record = new CTB_ASIENTOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					record.CTB_PERIODO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_periodo_idColumnIndex)), 9);
					record.CTB_PERIODO_NOMBRE = Convert.ToString(reader.GetValue(ctb_periodo_nombreColumnIndex));
					if(!reader.IsDBNull(ctb_periodo_vigenteColumnIndex))
						record.CTB_PERIODO_VIGENTE = Convert.ToString(reader.GetValue(ctb_periodo_vigenteColumnIndex));
					if(!reader.IsDBNull(ctb_periodo_vigente_por_margenColumnIndex))
						record.CTB_PERIODO_VIGENTE_POR_MARGEN = Convert.ToString(reader.GetValue(ctb_periodo_vigente_por_margenColumnIndex));
					record.CTB_EJERCICIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_ejercicio_idColumnIndex)), 9);
					record.CTB_EJERCICIO_NOMBRE = Convert.ToString(reader.GetValue(ctb_ejercicio_nombreColumnIndex));
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(usuario_creacion_idColumnIndex))
						record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creacion_nombreColumnIndex))
						record.USUARIO_CREACION_NOMBRE = Convert.ToString(reader.GetValue(usuario_creacion_nombreColumnIndex));
					record.AUTOMATICO = Convert.ToString(reader.GetValue(automaticoColumnIndex));
					if(!reader.IsDBNull(usuario_inactivacion_idColumnIndex))
						record.USUARIO_INACTIVACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_inactivacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_inactivacion_nombreColumnIndex))
						record.USUARIO_INACTIVACION_NOMBRE = Convert.ToString(reader.GetValue(usuario_inactivacion_nombreColumnIndex));
					if(!reader.IsDBNull(fecha_inactivacionColumnIndex))
						record.FECHA_INACTIVACION = Convert.ToDateTime(reader.GetValue(fecha_inactivacionColumnIndex));
					record.FECHA_ASIENTO = Convert.ToDateTime(reader.GetValue(fecha_asientoColumnIndex));
					record.NUMERO = Math.Round(Convert.ToDecimal(reader.GetValue(numeroColumnIndex)), 9);
					if(!reader.IsDBNull(observacion_sistemaColumnIndex))
						record.OBSERVACION_SISTEMA = Convert.ToString(reader.GetValue(observacion_sistemaColumnIndex));
					record.APROBADO = Convert.ToString(reader.GetValue(aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(caso_relacionado_idColumnIndex))
						record.CASO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_relacionado_flujo_idColumnIndex))
						record.CASO_RELACIONADO_FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relacionado_flujo_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_relacionado_flujo_desColumnIndex))
						record.CASO_RELACIONADO_FLUJO_DES = Convert.ToString(reader.GetValue(caso_relacionado_flujo_desColumnIndex));
					if(!reader.IsDBNull(transicion_idColumnIndex))
						record.TRANSICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transicion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tabla_relacionada_idColumnIndex))
						record.TABLA_RELACIONADA_ID = Convert.ToString(reader.GetValue(tabla_relacionada_idColumnIndex));
					if(!reader.IsDBNull(registro_relacionado_idColumnIndex))
						record.REGISTRO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(registro_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(revision_posteriorColumnIndex))
						record.REVISION_POSTERIOR = Convert.ToString(reader.GetValue(revision_posteriorColumnIndex));
					record.ES_APERTURA = Convert.ToString(reader.GetValue(es_aperturaColumnIndex));
					record.ES_REGULARIZACION = Convert.ToString(reader.GetValue(es_regularizacionColumnIndex));
					record.ES_CIERRE = Convert.ToString(reader.GetValue(es_cierreColumnIndex));
					record.ES_GLOBAL = Convert.ToString(reader.GetValue(es_globalColumnIndex));
					if(!reader.IsDBNull(ctb_asiento_global_idColumnIndex))
						record.CTB_ASIENTO_GLOBAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_asiento_global_idColumnIndex)), 9);
					if(!reader.IsDBNull(total_debeColumnIndex))
						record.TOTAL_DEBE = Math.Round(Convert.ToDecimal(reader.GetValue(total_debeColumnIndex)), 9);
					if(!reader.IsDBNull(total_haberColumnIndex))
						record.TOTAL_HABER = Math.Round(Convert.ToDecimal(reader.GetValue(total_haberColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_ASIENTOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(CTB_ASIENTOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_ASIENTOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual CTB_ASIENTOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			CTB_ASIENTOS_INFO_COMPLETARow mappedObject = new CTB_ASIENTOS_INFO_COMPLETARow();
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
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "CTB_PERIODO_ID"
			dataColumn = dataTable.Columns["CTB_PERIODO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PERIODO_ID = (decimal)row[dataColumn];
			// Column "CTB_PERIODO_NOMBRE"
			dataColumn = dataTable.Columns["CTB_PERIODO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PERIODO_NOMBRE = (string)row[dataColumn];
			// Column "CTB_PERIODO_VIGENTE"
			dataColumn = dataTable.Columns["CTB_PERIODO_VIGENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PERIODO_VIGENTE = (string)row[dataColumn];
			// Column "CTB_PERIODO_VIGENTE_POR_MARGEN"
			dataColumn = dataTable.Columns["CTB_PERIODO_VIGENTE_POR_MARGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_PERIODO_VIGENTE_POR_MARGEN = (string)row[dataColumn];
			// Column "CTB_EJERCICIO_ID"
			dataColumn = dataTable.Columns["CTB_EJERCICIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_EJERCICIO_ID = (decimal)row[dataColumn];
			// Column "CTB_EJERCICIO_NOMBRE"
			dataColumn = dataTable.Columns["CTB_EJERCICIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_EJERCICIO_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_CREACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_NOMBRE = (string)row[dataColumn];
			// Column "AUTOMATICO"
			dataColumn = dataTable.Columns["AUTOMATICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTOMATICO = (string)row[dataColumn];
			// Column "USUARIO_INACTIVACION_ID"
			dataColumn = dataTable.Columns["USUARIO_INACTIVACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_INACTIVACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_INACTIVACION_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_INACTIVACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_INACTIVACION_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_INACTIVACION"
			dataColumn = dataTable.Columns["FECHA_INACTIVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INACTIVACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_ASIENTO"
			dataColumn = dataTable.Columns["FECHA_ASIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ASIENTO = (System.DateTime)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (decimal)row[dataColumn];
			// Column "OBSERVACION_SISTEMA"
			dataColumn = dataTable.Columns["OBSERVACION_SISTEMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_SISTEMA = (string)row[dataColumn];
			// Column "APROBADO"
			dataColumn = dataTable.Columns["APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APROBADO = (string)row[dataColumn];
			// Column "USUARIO_APROBACION_ID"
			dataColumn = dataTable.Columns["USUARIO_APROBACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "CASO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "CASO_RELACIONADO_FLUJO_ID"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_FLUJO_ID = (decimal)row[dataColumn];
			// Column "CASO_RELACIONADO_FLUJO_DES"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_FLUJO_DES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_FLUJO_DES = (string)row[dataColumn];
			// Column "TRANSICION_ID"
			dataColumn = dataTable.Columns["TRANSICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSICION_ID = (decimal)row[dataColumn];
			// Column "TABLA_RELACIONADA_ID"
			dataColumn = dataTable.Columns["TABLA_RELACIONADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_RELACIONADA_ID = (string)row[dataColumn];
			// Column "REGISTRO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["REGISTRO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "REVISION_POSTERIOR"
			dataColumn = dataTable.Columns["REVISION_POSTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.REVISION_POSTERIOR = (string)row[dataColumn];
			// Column "ES_APERTURA"
			dataColumn = dataTable.Columns["ES_APERTURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_APERTURA = (string)row[dataColumn];
			// Column "ES_REGULARIZACION"
			dataColumn = dataTable.Columns["ES_REGULARIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_REGULARIZACION = (string)row[dataColumn];
			// Column "ES_CIERRE"
			dataColumn = dataTable.Columns["ES_CIERRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CIERRE = (string)row[dataColumn];
			// Column "ES_GLOBAL"
			dataColumn = dataTable.Columns["ES_GLOBAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_GLOBAL = (string)row[dataColumn];
			// Column "CTB_ASIENTO_GLOBAL_ID"
			dataColumn = dataTable.Columns["CTB_ASIENTO_GLOBAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_ASIENTO_GLOBAL_ID = (decimal)row[dataColumn];
			// Column "TOTAL_DEBE"
			dataColumn = dataTable.Columns["TOTAL_DEBE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DEBE = (decimal)row[dataColumn];
			// Column "TOTAL_HABER"
			dataColumn = dataTable.Columns["TOTAL_HABER"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_HABER = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_ASIENTOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_ASIENTOS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PERIODO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PERIODO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PERIODO_VIGENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_PERIODO_VIGENTE_POR_MARGEN", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_EJERCICIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_EJERCICIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTOMATICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_INACTIVACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_INACTIVACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 101;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INACTIVACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ASIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION_SISTEMA", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_FLUJO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_FLUJO_DES", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSICION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TABLA_RELACIONADA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REGISTRO_RELACIONADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("REVISION_POSTERIOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_APERTURA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_REGULARIZACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_CIERRE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_GLOBAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTB_ASIENTO_GLOBAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_DEBE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_HABER", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_PERIODO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_PERIODO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTB_PERIODO_VIGENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTB_PERIODO_VIGENTE_POR_MARGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTB_EJERCICIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_EJERCICIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_INACTIVACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_INACTIVACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INACTIVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ASIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION_SISTEMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_APROBACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_RELACIONADO_FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_RELACIONADO_FLUJO_DES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TABLA_RELACIONADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGISTRO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "REVISION_POSTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_APERTURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_REGULARIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_CIERRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_GLOBAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CTB_ASIENTO_GLOBAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DEBE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_HABER":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_ASIENTOS_INFO_COMPLETACollection_Base class
}  // End of namespace
