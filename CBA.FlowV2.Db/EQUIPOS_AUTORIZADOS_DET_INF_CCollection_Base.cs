// <fileinfo name="EQUIPOS_AUTORIZADOS_DET_INF_CCollection_Base.cs">
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
	/// The base class for <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EQUIPOS_AUTORIZADOS_DET_INF_CCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string EQUIPOS_AUTORIZADOS_IDColumnName = "EQUIPOS_AUTORIZADOS_ID";
		public const string PUERTAS_MOVIMIENTO_IDColumnName = "PUERTAS_MOVIMIENTO_ID";
		public const string TIPOColumnName = "TIPO";
		public const string CONOCIMIENTO_DETALLE_IDColumnName = "CONOCIMIENTO_DETALLE_ID";
		public const string CONOCIMIENTO_CONTENIDO_IDColumnName = "CONOCIMIENTO_CONTENIDO_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string BOOKING_BLColumnName = "BOOKING_BL";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_DEVOLUCIONColumnName = "FECHA_DEVOLUCION";
		public const string PUERTO_DEVOLUCION_IDColumnName = "PUERTO_DEVOLUCION_ID";
		public const string RETIRADOColumnName = "RETIRADO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string PUERTO_DEVOLUCION_NOMBREColumnName = "PUERTO_DEVOLUCION_NOMBRE";
		public const string CONTENEDOR_LINEAColumnName = "CONTENEDOR_LINEA";
		public const string CONTENEDOR_TIPOColumnName = "CONTENEDOR_TIPO";
		public const string CONTENEDOR_CLASEColumnName = "CONTENEDOR_CLASE";
		public const string CONTENEDOR_ESTADOColumnName = "CONTENEDOR_ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public EQUIPOS_AUTORIZADOS_DET_INF_CCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>EQUIPOS_AUTORIZADOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DET_INF_CRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>EQUIPOS_AUTORIZADOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>EQUIPOS_AUTORIZADOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public EQUIPOS_AUTORIZADOS_DET_INF_CRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			EQUIPOS_AUTORIZADOS_DET_INF_CRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects.</returns>
		public EQUIPOS_AUTORIZADOS_DET_INF_CRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects that 
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects.</returns>
		public virtual EQUIPOS_AUTORIZADOS_DET_INF_CRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.EQUIPOS_AUTORIZADOS_DET_INF_C";
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOS_DET_INF_CRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects.</returns>
		protected EQUIPOS_AUTORIZADOS_DET_INF_CRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> objects.</returns>
		protected virtual EQUIPOS_AUTORIZADOS_DET_INF_CRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int equipos_autorizados_idColumnIndex = reader.GetOrdinal("EQUIPOS_AUTORIZADOS_ID");
			int puertas_movimiento_idColumnIndex = reader.GetOrdinal("PUERTAS_MOVIMIENTO_ID");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int conocimiento_detalle_idColumnIndex = reader.GetOrdinal("CONOCIMIENTO_DETALLE_ID");
			int conocimiento_contenido_idColumnIndex = reader.GetOrdinal("CONOCIMIENTO_CONTENIDO_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int booking_blColumnIndex = reader.GetOrdinal("BOOKING_BL");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_devolucionColumnIndex = reader.GetOrdinal("FECHA_DEVOLUCION");
			int puerto_devolucion_idColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_ID");
			int retiradoColumnIndex = reader.GetOrdinal("RETIRADO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int puerto_devolucion_nombreColumnIndex = reader.GetOrdinal("PUERTO_DEVOLUCION_NOMBRE");
			int contenedor_lineaColumnIndex = reader.GetOrdinal("CONTENEDOR_LINEA");
			int contenedor_tipoColumnIndex = reader.GetOrdinal("CONTENEDOR_TIPO");
			int contenedor_claseColumnIndex = reader.GetOrdinal("CONTENEDOR_CLASE");
			int contenedor_estadoColumnIndex = reader.GetOrdinal("CONTENEDOR_ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					EQUIPOS_AUTORIZADOS_DET_INF_CRow record = new EQUIPOS_AUTORIZADOS_DET_INF_CRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.EQUIPOS_AUTORIZADOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(equipos_autorizados_idColumnIndex)), 9);
					if(!reader.IsDBNull(puertas_movimiento_idColumnIndex))
						record.PUERTAS_MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puertas_movimiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Convert.ToString(reader.GetValue(tipoColumnIndex));
					if(!reader.IsDBNull(conocimiento_detalle_idColumnIndex))
						record.CONOCIMIENTO_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimiento_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(conocimiento_contenido_idColumnIndex))
						record.CONOCIMIENTO_CONTENIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(conocimiento_contenido_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_numeroColumnIndex))
						record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(booking_blColumnIndex))
						record.BOOKING_BL = Convert.ToString(reader.GetValue(booking_blColumnIndex));
					if(!reader.IsDBNull(fecha_vencimientoColumnIndex))
						record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_devolucionColumnIndex))
						record.FECHA_DEVOLUCION = Convert.ToDateTime(reader.GetValue(fecha_devolucionColumnIndex));
					if(!reader.IsDBNull(puerto_devolucion_idColumnIndex))
						record.PUERTO_DEVOLUCION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_devolucion_idColumnIndex)), 9);
					record.RETIRADO = Convert.ToString(reader.GetValue(retiradoColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_devolucion_nombreColumnIndex))
						record.PUERTO_DEVOLUCION_NOMBRE = Convert.ToString(reader.GetValue(puerto_devolucion_nombreColumnIndex));
					if(!reader.IsDBNull(contenedor_lineaColumnIndex))
						record.CONTENEDOR_LINEA = Convert.ToString(reader.GetValue(contenedor_lineaColumnIndex));
					if(!reader.IsDBNull(contenedor_tipoColumnIndex))
						record.CONTENEDOR_TIPO = Convert.ToString(reader.GetValue(contenedor_tipoColumnIndex));
					if(!reader.IsDBNull(contenedor_claseColumnIndex))
						record.CONTENEDOR_CLASE = Convert.ToString(reader.GetValue(contenedor_claseColumnIndex));
					if(!reader.IsDBNull(contenedor_estadoColumnIndex))
						record.CONTENEDOR_ESTADO = Convert.ToString(reader.GetValue(contenedor_estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (EQUIPOS_AUTORIZADOS_DET_INF_CRow[])(recordList.ToArray(typeof(EQUIPOS_AUTORIZADOS_DET_INF_CRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="EQUIPOS_AUTORIZADOS_DET_INF_CRow"/> object.</returns>
		protected virtual EQUIPOS_AUTORIZADOS_DET_INF_CRow MapRow(DataRow row)
		{
			EQUIPOS_AUTORIZADOS_DET_INF_CRow mappedObject = new EQUIPOS_AUTORIZADOS_DET_INF_CRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "EQUIPOS_AUTORIZADOS_ID"
			dataColumn = dataTable.Columns["EQUIPOS_AUTORIZADOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EQUIPOS_AUTORIZADOS_ID = (decimal)row[dataColumn];
			// Column "PUERTAS_MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["PUERTAS_MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTAS_MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (string)row[dataColumn];
			// Column "CONOCIMIENTO_DETALLE_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTO_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO_DETALLE_ID = (decimal)row[dataColumn];
			// Column "CONOCIMIENTO_CONTENIDO_ID"
			dataColumn = dataTable.Columns["CONOCIMIENTO_CONTENIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO_CONTENIDO_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "BOOKING_BL"
			dataColumn = dataTable.Columns["BOOKING_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING_BL = (string)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_DEVOLUCION"
			dataColumn = dataTable.Columns["FECHA_DEVOLUCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DEVOLUCION = (System.DateTime)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_ID"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_ID = (decimal)row[dataColumn];
			// Column "RETIRADO"
			dataColumn = dataTable.Columns["RETIRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETIRADO = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "PUERTO_DEVOLUCION_NOMBRE"
			dataColumn = dataTable.Columns["PUERTO_DEVOLUCION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_DEVOLUCION_NOMBRE = (string)row[dataColumn];
			// Column "CONTENEDOR_LINEA"
			dataColumn = dataTable.Columns["CONTENEDOR_LINEA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_LINEA = (string)row[dataColumn];
			// Column "CONTENEDOR_TIPO"
			dataColumn = dataTable.Columns["CONTENEDOR_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_TIPO = (string)row[dataColumn];
			// Column "CONTENEDOR_CLASE"
			dataColumn = dataTable.Columns["CONTENEDOR_CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_CLASE = (string)row[dataColumn];
			// Column "CONTENEDOR_ESTADO"
			dataColumn = dataTable.Columns["CONTENEDOR_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>EQUIPOS_AUTORIZADOS_DET_INF_C</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "EQUIPOS_AUTORIZADOS_DET_INF_C";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EQUIPOS_AUTORIZADOS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTAS_MOVIMIENTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO_DETALLE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO_CONTENIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BOOKING_BL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_DEVOLUCION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RETIRADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_DEVOLUCION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_LINEA", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_TIPO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_CLASE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ESTADO", typeof(string));
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

				case "EQUIPOS_AUTORIZADOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTAS_MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONOCIMIENTO_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONOCIMIENTO_CONTENIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BOOKING_BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_DEVOLUCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PUERTO_DEVOLUCION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETIRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_DEVOLUCION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_LINEA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of EQUIPOS_AUTORIZADOS_DET_INF_CCollection_Base class
}  // End of namespace
