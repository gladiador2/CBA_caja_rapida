// <fileinfo name="VEHICULOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="VEHICULOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="VEHICULOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class VEHICULOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_VEHICULO_IDColumnName = "TIPO_VEHICULO_ID";
		public const string TIPO_VEHICULO_NOMBREColumnName = "TIPO_VEHICULO_NOMBRE";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string SUCURSAL_ABREVIATURAColumnName = "SUCURSAL_ABREVIATURA";
		public const string CHOFER_HABITUAL_IDColumnName = "CHOFER_HABITUAL_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string MATRICULAColumnName = "MATRICULA";
		public const string MARCAColumnName = "MARCA";
		public const string MODELOColumnName = "MODELO";
		public const string ANHOColumnName = "ANHO";
		public const string COLORColumnName = "COLOR";
		public const string CONSUMO_ESTIMADOColumnName = "CONSUMO_ESTIMADO";
		public const string KILOMETRAJE_INICIALColumnName = "KILOMETRAJE_INICIAL";
		public const string KILOMETRAJE_ACTUALColumnName = "KILOMETRAJE_ACTUAL";
		public const string TIPO_COMBUSTIBLEColumnName = "TIPO_COMBUSTIBLE";
		public const string CANTIDAD_KM_ENTRE_MANTENIMColumnName = "CANTIDAD_KM_ENTRE_MANTENIM";
		public const string CANTIDAD_DIAS_ENTRE_MANTENIMColumnName = "CANTIDAD_DIAS_ENTRE_MANTENIM";
		public const string KILOMETRAJE_ULTIMO_MANTENIMIENColumnName = "KILOMETRAJE_ULTIMO_MANTENIMIEN";
		public const string FECHA_ULTIMO_MANTENIMIENTOColumnName = "FECHA_ULTIMO_MANTENIMIENTO";
		public const string FECHA_VENCIMIENTO_POLIZAColumnName = "FECHA_VENCIMIENTO_POLIZA";
		public const string FECHA_VENCIMIENTO_PATENTEColumnName = "FECHA_VENCIMIENTO_PATENTE";
		public const string FECHA_INGRESOColumnName = "FECHA_INGRESO";
		public const string FECHA_INACTIVADOColumnName = "FECHA_INACTIVADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string CHASIS_NROColumnName = "CHASIS_NRO";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string RAZON_SOCIALColumnName = "RAZON_SOCIAL";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string NOMBRE_COMPLETOColumnName = "NOMBRE_COMPLETO";
		public const string NRO_CELDASColumnName = "NRO_CELDAS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="VEHICULOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public VEHICULOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>VEHICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual VEHICULOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>VEHICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>VEHICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="VEHICULOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="VEHICULOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public VEHICULOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			VEHICULOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects.</returns>
		public VEHICULOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual VEHICULOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.VEHICULOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects.</returns>
		protected VEHICULOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects.</returns>
		protected VEHICULOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="VEHICULOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual VEHICULOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_vehiculo_idColumnIndex = reader.GetOrdinal("TIPO_VEHICULO_ID");
			int tipo_vehiculo_nombreColumnIndex = reader.GetOrdinal("TIPO_VEHICULO_NOMBRE");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int sucursal_abreviaturaColumnIndex = reader.GetOrdinal("SUCURSAL_ABREVIATURA");
			int chofer_habitual_idColumnIndex = reader.GetOrdinal("CHOFER_HABITUAL_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int matriculaColumnIndex = reader.GetOrdinal("MATRICULA");
			int marcaColumnIndex = reader.GetOrdinal("MARCA");
			int modeloColumnIndex = reader.GetOrdinal("MODELO");
			int anhoColumnIndex = reader.GetOrdinal("ANHO");
			int colorColumnIndex = reader.GetOrdinal("COLOR");
			int consumo_estimadoColumnIndex = reader.GetOrdinal("CONSUMO_ESTIMADO");
			int kilometraje_inicialColumnIndex = reader.GetOrdinal("KILOMETRAJE_INICIAL");
			int kilometraje_actualColumnIndex = reader.GetOrdinal("KILOMETRAJE_ACTUAL");
			int tipo_combustibleColumnIndex = reader.GetOrdinal("TIPO_COMBUSTIBLE");
			int cantidad_km_entre_mantenimColumnIndex = reader.GetOrdinal("CANTIDAD_KM_ENTRE_MANTENIM");
			int cantidad_dias_entre_mantenimColumnIndex = reader.GetOrdinal("CANTIDAD_DIAS_ENTRE_MANTENIM");
			int kilometraje_ultimo_mantenimienColumnIndex = reader.GetOrdinal("KILOMETRAJE_ULTIMO_MANTENIMIEN");
			int fecha_ultimo_mantenimientoColumnIndex = reader.GetOrdinal("FECHA_ULTIMO_MANTENIMIENTO");
			int fecha_vencimiento_polizaColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_POLIZA");
			int fecha_vencimiento_patenteColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO_PATENTE");
			int fecha_ingresoColumnIndex = reader.GetOrdinal("FECHA_INGRESO");
			int fecha_inactivadoColumnIndex = reader.GetOrdinal("FECHA_INACTIVADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int chasis_nroColumnIndex = reader.GetOrdinal("CHASIS_NRO");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int razon_socialColumnIndex = reader.GetOrdinal("RAZON_SOCIAL");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int nombre_completoColumnIndex = reader.GetOrdinal("NOMBRE_COMPLETO");
			int nro_celdasColumnIndex = reader.GetOrdinal("NRO_CELDAS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					VEHICULOS_INFO_COMPLETARow record = new VEHICULOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_vehiculo_idColumnIndex)), 9);
					record.TIPO_VEHICULO_NOMBRE = Convert.ToString(reader.GetValue(tipo_vehiculo_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(sucursal_abreviaturaColumnIndex))
						record.SUCURSAL_ABREVIATURA = Convert.ToString(reader.GetValue(sucursal_abreviaturaColumnIndex));
					if(!reader.IsDBNull(chofer_habitual_idColumnIndex))
						record.CHOFER_HABITUAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(chofer_habitual_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					record.MATRICULA = Convert.ToString(reader.GetValue(matriculaColumnIndex));
					if(!reader.IsDBNull(marcaColumnIndex))
						record.MARCA = Convert.ToString(reader.GetValue(marcaColumnIndex));
					if(!reader.IsDBNull(modeloColumnIndex))
						record.MODELO = Convert.ToString(reader.GetValue(modeloColumnIndex));
					if(!reader.IsDBNull(anhoColumnIndex))
						record.ANHO = Math.Round(Convert.ToDecimal(reader.GetValue(anhoColumnIndex)), 9);
					if(!reader.IsDBNull(colorColumnIndex))
						record.COLOR = Convert.ToString(reader.GetValue(colorColumnIndex));
					if(!reader.IsDBNull(consumo_estimadoColumnIndex))
						record.CONSUMO_ESTIMADO = Math.Round(Convert.ToDecimal(reader.GetValue(consumo_estimadoColumnIndex)), 9);
					record.KILOMETRAJE_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_inicialColumnIndex)), 9);
					record.KILOMETRAJE_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_actualColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_combustibleColumnIndex))
						record.TIPO_COMBUSTIBLE = Convert.ToString(reader.GetValue(tipo_combustibleColumnIndex));
					if(!reader.IsDBNull(cantidad_km_entre_mantenimColumnIndex))
						record.CANTIDAD_KM_ENTRE_MANTENIM = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_km_entre_mantenimColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_dias_entre_mantenimColumnIndex))
						record.CANTIDAD_DIAS_ENTRE_MANTENIM = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dias_entre_mantenimColumnIndex)), 9);
					if(!reader.IsDBNull(kilometraje_ultimo_mantenimienColumnIndex))
						record.KILOMETRAJE_ULTIMO_MANTENIMIEN = Math.Round(Convert.ToDecimal(reader.GetValue(kilometraje_ultimo_mantenimienColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ultimo_mantenimientoColumnIndex))
						record.FECHA_ULTIMO_MANTENIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_ultimo_mantenimientoColumnIndex));
					if(!reader.IsDBNull(fecha_vencimiento_polizaColumnIndex))
						record.FECHA_VENCIMIENTO_POLIZA = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_polizaColumnIndex));
					if(!reader.IsDBNull(fecha_vencimiento_patenteColumnIndex))
						record.FECHA_VENCIMIENTO_PATENTE = Convert.ToDateTime(reader.GetValue(fecha_vencimiento_patenteColumnIndex));
					if(!reader.IsDBNull(fecha_ingresoColumnIndex))
						record.FECHA_INGRESO = Convert.ToDateTime(reader.GetValue(fecha_ingresoColumnIndex));
					if(!reader.IsDBNull(fecha_inactivadoColumnIndex))
						record.FECHA_INACTIVADO = Convert.ToDateTime(reader.GetValue(fecha_inactivadoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(chasis_nroColumnIndex))
						record.CHASIS_NRO = Convert.ToString(reader.GetValue(chasis_nroColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(razon_socialColumnIndex))
						record.RAZON_SOCIAL = Convert.ToString(reader.GetValue(razon_socialColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_completoColumnIndex))
						record.NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(nombre_completoColumnIndex));
					if(!reader.IsDBNull(nro_celdasColumnIndex))
						record.NRO_CELDAS = Math.Round(Convert.ToDecimal(reader.GetValue(nro_celdasColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (VEHICULOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(VEHICULOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="VEHICULOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="VEHICULOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual VEHICULOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			VEHICULOS_INFO_COMPLETARow mappedObject = new VEHICULOS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_VEHICULO_ID"
			dataColumn = dataTable.Columns["TIPO_VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_VEHICULO_ID = (decimal)row[dataColumn];
			// Column "TIPO_VEHICULO_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_VEHICULO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_VEHICULO_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "SUCURSAL_ABREVIATURA"
			dataColumn = dataTable.Columns["SUCURSAL_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ABREVIATURA = (string)row[dataColumn];
			// Column "CHOFER_HABITUAL_ID"
			dataColumn = dataTable.Columns["CHOFER_HABITUAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_HABITUAL_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "MATRICULA"
			dataColumn = dataTable.Columns["MATRICULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MATRICULA = (string)row[dataColumn];
			// Column "MARCA"
			dataColumn = dataTable.Columns["MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA = (string)row[dataColumn];
			// Column "MODELO"
			dataColumn = dataTable.Columns["MODELO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MODELO = (string)row[dataColumn];
			// Column "ANHO"
			dataColumn = dataTable.Columns["ANHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANHO = (decimal)row[dataColumn];
			// Column "COLOR"
			dataColumn = dataTable.Columns["COLOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLOR = (string)row[dataColumn];
			// Column "CONSUMO_ESTIMADO"
			dataColumn = dataTable.Columns["CONSUMO_ESTIMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSUMO_ESTIMADO = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_INICIAL"
			dataColumn = dataTable.Columns["KILOMETRAJE_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_INICIAL = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_ACTUAL"
			dataColumn = dataTable.Columns["KILOMETRAJE_ACTUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_ACTUAL = (decimal)row[dataColumn];
			// Column "TIPO_COMBUSTIBLE"
			dataColumn = dataTable.Columns["TIPO_COMBUSTIBLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_COMBUSTIBLE = (string)row[dataColumn];
			// Column "CANTIDAD_KM_ENTRE_MANTENIM"
			dataColumn = dataTable.Columns["CANTIDAD_KM_ENTRE_MANTENIM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_KM_ENTRE_MANTENIM = (decimal)row[dataColumn];
			// Column "CANTIDAD_DIAS_ENTRE_MANTENIM"
			dataColumn = dataTable.Columns["CANTIDAD_DIAS_ENTRE_MANTENIM"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DIAS_ENTRE_MANTENIM = (decimal)row[dataColumn];
			// Column "KILOMETRAJE_ULTIMO_MANTENIMIEN"
			dataColumn = dataTable.Columns["KILOMETRAJE_ULTIMO_MANTENIMIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.KILOMETRAJE_ULTIMO_MANTENIMIEN = (decimal)row[dataColumn];
			// Column "FECHA_ULTIMO_MANTENIMIENTO"
			dataColumn = dataTable.Columns["FECHA_ULTIMO_MANTENIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMO_MANTENIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_POLIZA"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_POLIZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_POLIZA = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO_PATENTE"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO_PATENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO_PATENTE = (System.DateTime)row[dataColumn];
			// Column "FECHA_INGRESO"
			dataColumn = dataTable.Columns["FECHA_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO = (System.DateTime)row[dataColumn];
			// Column "FECHA_INACTIVADO"
			dataColumn = dataTable.Columns["FECHA_INACTIVADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INACTIVADO = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "CHASIS_NRO"
			dataColumn = dataTable.Columns["CHASIS_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHASIS_NRO = (string)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "RAZON_SOCIAL"
			dataColumn = dataTable.Columns["RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_SOCIAL = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "NRO_CELDAS"
			dataColumn = dataTable.Columns["NRO_CELDAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CELDAS = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>VEHICULOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "VEHICULOS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_VEHICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_VEHICULO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_HABITUAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MATRICULA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARCA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MODELO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANHO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COLOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSUMO_ESTIMADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_ACTUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_COMBUSTIBLE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_KM_ENTRE_MANTENIM", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DIAS_ENTRE_MANTENIM", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("KILOMETRAJE_ULTIMO_MANTENIMIEN", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMO_MANTENIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_POLIZA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO_PATENTE", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INACTIVADO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHASIS_NRO", typeof(string));
			dataColumn.MaxLength = 17;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_CELDAS", typeof(decimal));
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

				case "TIPO_VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_VEHICULO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUCURSAL_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_HABITUAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MATRICULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MODELO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ANHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COLOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSUMO_ESTIMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_ACTUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_COMBUSTIBLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_KM_ENTRE_MANTENIM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DIAS_ENTRE_MANTENIM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "KILOMETRAJE_ULTIMO_MANTENIMIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ULTIMO_MANTENIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_POLIZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO_PATENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INACTIVADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CHASIS_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_CELDAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of VEHICULOS_INFO_COMPLETACollection_Base class
}  // End of namespace
