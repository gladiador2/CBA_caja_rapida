// <fileinfo name="CONTENEDORES_MOV_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_MOV_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTENEDORES_MOV_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_MOV_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_MOVIMIENTOColumnName = "FECHA_MOVIMIENTO";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string TIPO_MOVIMIENTOColumnName = "TIPO_MOVIMIENTO";
		public const string MOVIMIENTO_IDColumnName = "MOVIMIENTO_ID";
		public const string COMPROBANTE_MOVIMIENTOColumnName = "COMPROBANTE_MOVIMIENTO";
		public const string ORDENACIONColumnName = "ORDENACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string EN_PREDIOColumnName = "EN_PREDIO";
		public const string ESTADO_FINALColumnName = "ESTADO_FINAL";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string MOVIMIENTO_USUARIOColumnName = "MOVIMIENTO_USUARIO";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string CONTENEDOR_LINEAColumnName = "CONTENEDOR_LINEA";
		public const string CONTENEDOR_AGENCIAColumnName = "CONTENEDOR_AGENCIA";
		public const string CONTENEDOR_TIPOColumnName = "CONTENEDOR_TIPO";
		public const string BLOQUEADOColumnName = "BLOQUEADO";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string BUQUEColumnName = "BUQUE";
		public const string BLColumnName = "BL";
		public const string BOOKINGColumnName = "BOOKING";
		public const string CLIENTEColumnName = "CLIENTE";
		public const string NRO_VIAJEColumnName = "NRO_VIAJE";
		public const string PUERTOColumnName = "PUERTO";
		public const string PESOColumnName = "PESO";
		public const string TARAColumnName = "TARA";
		public const string SETPOINTColumnName = "SETPOINT";
		public const string PAYLOADColumnName = "PAYLOAD";
		public const string EIR_PISOColumnName = "EIR_PISO";
		public const string EIR_FONDOColumnName = "EIR_FONDO";
		public const string EIR_TECHOColumnName = "EIR_TECHO";
		public const string EIR_PANEL_DERECHOColumnName = "EIR_PANEL_DERECHO";
		public const string EIR_PANEL_IZQUIERDOColumnName = "EIR_PANEL_IZQUIERDO";
		public const string EIR_PUERTAColumnName = "EIR_PUERTA";
		public const string EIR_REFRIGERADOColumnName = "EIR_REFRIGERADO";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string CLASEColumnName = "CLASE";
		public const string MERCADERIASColumnName = "MERCADERIAS";
		public const string DANADOColumnName = "DANADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_MOV_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTENEDORES_MOV_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTENEDORES_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects.</returns>
		public virtual CONTENEDORES_MOV_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTENEDORES_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTENEDORES_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTENEDORES_MOV_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTENEDORES_MOV_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects.</returns>
		public CONTENEDORES_MOV_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects.</returns>
		public virtual CONTENEDORES_MOV_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTENEDORES_MOV_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects.</returns>
		protected CONTENEDORES_MOV_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects.</returns>
		protected CONTENEDORES_MOV_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> objects.</returns>
		protected virtual CONTENEDORES_MOV_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_movimientoColumnIndex = reader.GetOrdinal("FECHA_MOVIMIENTO");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int tipo_movimientoColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO");
			int movimiento_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_ID");
			int comprobante_movimientoColumnIndex = reader.GetOrdinal("COMPROBANTE_MOVIMIENTO");
			int ordenacionColumnIndex = reader.GetOrdinal("ORDENACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int en_predioColumnIndex = reader.GetOrdinal("EN_PREDIO");
			int estado_finalColumnIndex = reader.GetOrdinal("ESTADO_FINAL");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int movimiento_usuarioColumnIndex = reader.GetOrdinal("MOVIMIENTO_USUARIO");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int contenedor_lineaColumnIndex = reader.GetOrdinal("CONTENEDOR_LINEA");
			int contenedor_agenciaColumnIndex = reader.GetOrdinal("CONTENEDOR_AGENCIA");
			int contenedor_tipoColumnIndex = reader.GetOrdinal("CONTENEDOR_TIPO");
			int bloqueadoColumnIndex = reader.GetOrdinal("BLOQUEADO");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int buqueColumnIndex = reader.GetOrdinal("BUQUE");
			int blColumnIndex = reader.GetOrdinal("BL");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int clienteColumnIndex = reader.GetOrdinal("CLIENTE");
			int nro_viajeColumnIndex = reader.GetOrdinal("NRO_VIAJE");
			int puertoColumnIndex = reader.GetOrdinal("PUERTO");
			int pesoColumnIndex = reader.GetOrdinal("PESO");
			int taraColumnIndex = reader.GetOrdinal("TARA");
			int setpointColumnIndex = reader.GetOrdinal("SETPOINT");
			int payloadColumnIndex = reader.GetOrdinal("PAYLOAD");
			int eir_pisoColumnIndex = reader.GetOrdinal("EIR_PISO");
			int eir_fondoColumnIndex = reader.GetOrdinal("EIR_FONDO");
			int eir_techoColumnIndex = reader.GetOrdinal("EIR_TECHO");
			int eir_panel_derechoColumnIndex = reader.GetOrdinal("EIR_PANEL_DERECHO");
			int eir_panel_izquierdoColumnIndex = reader.GetOrdinal("EIR_PANEL_IZQUIERDO");
			int eir_puertaColumnIndex = reader.GetOrdinal("EIR_PUERTA");
			int eir_refrigeradoColumnIndex = reader.GetOrdinal("EIR_REFRIGERADO");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int claseColumnIndex = reader.GetOrdinal("CLASE");
			int mercaderiasColumnIndex = reader.GetOrdinal("MERCADERIAS");
			int danadoColumnIndex = reader.GetOrdinal("DANADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTENEDORES_MOV_INFO_COMPLETARow record = new CONTENEDORES_MOV_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FECHA_MOVIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_movimientoColumnIndex));
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					record.TIPO_MOVIMIENTO = Convert.ToString(reader.GetValue(tipo_movimientoColumnIndex));
					if(!reader.IsDBNull(movimiento_idColumnIndex))
						record.MOVIMIENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_idColumnIndex)), 9);
					if(!reader.IsDBNull(comprobante_movimientoColumnIndex))
						record.COMPROBANTE_MOVIMIENTO = Convert.ToString(reader.GetValue(comprobante_movimientoColumnIndex));
					if(!reader.IsDBNull(ordenacionColumnIndex))
						record.ORDENACION = Math.Round(Convert.ToDecimal(reader.GetValue(ordenacionColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.EN_PREDIO = Convert.ToString(reader.GetValue(en_predioColumnIndex));
					record.ESTADO_FINAL = Convert.ToString(reader.GetValue(estado_finalColumnIndex));
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.MOVIMIENTO_USUARIO = Convert.ToString(reader.GetValue(movimiento_usuarioColumnIndex));
					record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(contenedor_lineaColumnIndex))
						record.CONTENEDOR_LINEA = Convert.ToString(reader.GetValue(contenedor_lineaColumnIndex));
					if(!reader.IsDBNull(contenedor_agenciaColumnIndex))
						record.CONTENEDOR_AGENCIA = Convert.ToString(reader.GetValue(contenedor_agenciaColumnIndex));
					record.CONTENEDOR_TIPO = Convert.ToString(reader.GetValue(contenedor_tipoColumnIndex));
					if(!reader.IsDBNull(bloqueadoColumnIndex))
						record.BLOQUEADO = Convert.ToString(reader.GetValue(bloqueadoColumnIndex));
					if(!reader.IsDBNull(precinto_1ColumnIndex))
						record.PRECINTO_1 = Convert.ToString(reader.GetValue(precinto_1ColumnIndex));
					if(!reader.IsDBNull(precinto_2ColumnIndex))
						record.PRECINTO_2 = Convert.ToString(reader.GetValue(precinto_2ColumnIndex));
					if(!reader.IsDBNull(precinto_3ColumnIndex))
						record.PRECINTO_3 = Convert.ToString(reader.GetValue(precinto_3ColumnIndex));
					if(!reader.IsDBNull(precinto_4ColumnIndex))
						record.PRECINTO_4 = Convert.ToString(reader.GetValue(precinto_4ColumnIndex));
					if(!reader.IsDBNull(precinto_5ColumnIndex))
						record.PRECINTO_5 = Convert.ToString(reader.GetValue(precinto_5ColumnIndex));
					if(!reader.IsDBNull(precinto_ventileteColumnIndex))
						record.PRECINTO_VENTILETE = Convert.ToString(reader.GetValue(precinto_ventileteColumnIndex));
					if(!reader.IsDBNull(buqueColumnIndex))
						record.BUQUE = Convert.ToString(reader.GetValue(buqueColumnIndex));
					if(!reader.IsDBNull(blColumnIndex))
						record.BL = Convert.ToString(reader.GetValue(blColumnIndex));
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(clienteColumnIndex))
						record.CLIENTE = Convert.ToString(reader.GetValue(clienteColumnIndex));
					if(!reader.IsDBNull(nro_viajeColumnIndex))
						record.NRO_VIAJE = Convert.ToString(reader.GetValue(nro_viajeColumnIndex));
					if(!reader.IsDBNull(puertoColumnIndex))
						record.PUERTO = Convert.ToString(reader.GetValue(puertoColumnIndex));
					if(!reader.IsDBNull(pesoColumnIndex))
						record.PESO = Math.Round(Convert.ToDecimal(reader.GetValue(pesoColumnIndex)), 9);
					if(!reader.IsDBNull(taraColumnIndex))
						record.TARA = Math.Round(Convert.ToDecimal(reader.GetValue(taraColumnIndex)), 9);
					if(!reader.IsDBNull(setpointColumnIndex))
						record.SETPOINT = Math.Round(Convert.ToDecimal(reader.GetValue(setpointColumnIndex)), 9);
					if(!reader.IsDBNull(payloadColumnIndex))
						record.PAYLOAD = Math.Round(Convert.ToDecimal(reader.GetValue(payloadColumnIndex)), 9);
					if(!reader.IsDBNull(eir_pisoColumnIndex))
						record.EIR_PISO = Convert.ToString(reader.GetValue(eir_pisoColumnIndex));
					if(!reader.IsDBNull(eir_fondoColumnIndex))
						record.EIR_FONDO = Convert.ToString(reader.GetValue(eir_fondoColumnIndex));
					if(!reader.IsDBNull(eir_techoColumnIndex))
						record.EIR_TECHO = Convert.ToString(reader.GetValue(eir_techoColumnIndex));
					if(!reader.IsDBNull(eir_panel_derechoColumnIndex))
						record.EIR_PANEL_DERECHO = Convert.ToString(reader.GetValue(eir_panel_derechoColumnIndex));
					if(!reader.IsDBNull(eir_panel_izquierdoColumnIndex))
						record.EIR_PANEL_IZQUIERDO = Convert.ToString(reader.GetValue(eir_panel_izquierdoColumnIndex));
					if(!reader.IsDBNull(eir_puertaColumnIndex))
						record.EIR_PUERTA = Convert.ToString(reader.GetValue(eir_puertaColumnIndex));
					if(!reader.IsDBNull(eir_refrigeradoColumnIndex))
						record.EIR_REFRIGERADO = Convert.ToString(reader.GetValue(eir_refrigeradoColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(claseColumnIndex))
						record.CLASE = Convert.ToString(reader.GetValue(claseColumnIndex));
					if(!reader.IsDBNull(mercaderiasColumnIndex))
						record.MERCADERIAS = Convert.ToString(reader.GetValue(mercaderiasColumnIndex));
					if(!reader.IsDBNull(danadoColumnIndex))
						record.DANADO = Convert.ToString(reader.GetValue(danadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTENEDORES_MOV_INFO_COMPLETARow[])(recordList.ToArray(typeof(CONTENEDORES_MOV_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTENEDORES_MOV_INFO_COMPLETARow"/> object.</returns>
		protected virtual CONTENEDORES_MOV_INFO_COMPLETARow MapRow(DataRow row)
		{
			CONTENEDORES_MOV_INFO_COMPLETARow mappedObject = new CONTENEDORES_MOV_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_MOVIMIENTO"
			dataColumn = dataTable.Columns["FECHA_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MOVIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "TIPO_MOVIMIENTO"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO = (string)row[dataColumn];
			// Column "MOVIMIENTO_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_ID = (decimal)row[dataColumn];
			// Column "COMPROBANTE_MOVIMIENTO"
			dataColumn = dataTable.Columns["COMPROBANTE_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMPROBANTE_MOVIMIENTO = (string)row[dataColumn];
			// Column "ORDENACION"
			dataColumn = dataTable.Columns["ORDENACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDENACION = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "EN_PREDIO"
			dataColumn = dataTable.Columns["EN_PREDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_PREDIO = (string)row[dataColumn];
			// Column "ESTADO_FINAL"
			dataColumn = dataTable.Columns["ESTADO_FINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_FINAL = (string)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_USUARIO"
			dataColumn = dataTable.Columns["MOVIMIENTO_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_USUARIO = (string)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "CONTENEDOR_LINEA"
			dataColumn = dataTable.Columns["CONTENEDOR_LINEA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_LINEA = (string)row[dataColumn];
			// Column "CONTENEDOR_AGENCIA"
			dataColumn = dataTable.Columns["CONTENEDOR_AGENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_AGENCIA = (string)row[dataColumn];
			// Column "CONTENEDOR_TIPO"
			dataColumn = dataTable.Columns["CONTENEDOR_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_TIPO = (string)row[dataColumn];
			// Column "BLOQUEADO"
			dataColumn = dataTable.Columns["BLOQUEADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BLOQUEADO = (string)row[dataColumn];
			// Column "PRECINTO_1"
			dataColumn = dataTable.Columns["PRECINTO_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_1 = (string)row[dataColumn];
			// Column "PRECINTO_2"
			dataColumn = dataTable.Columns["PRECINTO_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_2 = (string)row[dataColumn];
			// Column "PRECINTO_3"
			dataColumn = dataTable.Columns["PRECINTO_3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_3 = (string)row[dataColumn];
			// Column "PRECINTO_4"
			dataColumn = dataTable.Columns["PRECINTO_4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_4 = (string)row[dataColumn];
			// Column "PRECINTO_5"
			dataColumn = dataTable.Columns["PRECINTO_5"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_5 = (string)row[dataColumn];
			// Column "PRECINTO_VENTILETE"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE = (string)row[dataColumn];
			// Column "BUQUE"
			dataColumn = dataTable.Columns["BUQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BUQUE = (string)row[dataColumn];
			// Column "BL"
			dataColumn = dataTable.Columns["BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.BL = (string)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "CLIENTE"
			dataColumn = dataTable.Columns["CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLIENTE = (string)row[dataColumn];
			// Column "NRO_VIAJE"
			dataColumn = dataTable.Columns["NRO_VIAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_VIAJE = (string)row[dataColumn];
			// Column "PUERTO"
			dataColumn = dataTable.Columns["PUERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO = (string)row[dataColumn];
			// Column "PESO"
			dataColumn = dataTable.Columns["PESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO = (decimal)row[dataColumn];
			// Column "TARA"
			dataColumn = dataTable.Columns["TARA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA = (decimal)row[dataColumn];
			// Column "SETPOINT"
			dataColumn = dataTable.Columns["SETPOINT"];
			if(!row.IsNull(dataColumn))
				mappedObject.SETPOINT = (decimal)row[dataColumn];
			// Column "PAYLOAD"
			dataColumn = dataTable.Columns["PAYLOAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAYLOAD = (decimal)row[dataColumn];
			// Column "EIR_PISO"
			dataColumn = dataTable.Columns["EIR_PISO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PISO = (string)row[dataColumn];
			// Column "EIR_FONDO"
			dataColumn = dataTable.Columns["EIR_FONDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_FONDO = (string)row[dataColumn];
			// Column "EIR_TECHO"
			dataColumn = dataTable.Columns["EIR_TECHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_TECHO = (string)row[dataColumn];
			// Column "EIR_PANEL_DERECHO"
			dataColumn = dataTable.Columns["EIR_PANEL_DERECHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PANEL_DERECHO = (string)row[dataColumn];
			// Column "EIR_PANEL_IZQUIERDO"
			dataColumn = dataTable.Columns["EIR_PANEL_IZQUIERDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PANEL_IZQUIERDO = (string)row[dataColumn];
			// Column "EIR_PUERTA"
			dataColumn = dataTable.Columns["EIR_PUERTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_PUERTA = (string)row[dataColumn];
			// Column "EIR_REFRIGERADO"
			dataColumn = dataTable.Columns["EIR_REFRIGERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EIR_REFRIGERADO = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "CLASE"
			dataColumn = dataTable.Columns["CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLASE = (string)row[dataColumn];
			// Column "MERCADERIAS"
			dataColumn = dataTable.Columns["MERCADERIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIAS = (string)row[dataColumn];
			// Column "DANADO"
			dataColumn = dataTable.Columns["DANADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTENEDORES_MOV_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTENEDORES_MOV_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MOVIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMPROBANTE_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORDENACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EN_PREDIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_FINAL", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_USUARIO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_LINEA", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_AGENCIA", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_TIPO", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BLOQUEADO", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_2", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_3", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_4", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_5", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BUQUE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BL", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CLIENTE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_VIAJE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SETPOINT", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAYLOAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_PISO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_FONDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_TECHO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_PANEL_DERECHO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_PANEL_IZQUIERDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_PUERTA", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CLASE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIAS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DANADO", typeof(string));
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
				case "ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TIPO_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MOVIMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COMPROBANTE_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDENACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EN_PREDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO_FINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_LINEA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_AGENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BLOQUEADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BUQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_VIAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SETPOINT":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAYLOAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EIR_PISO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_FONDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_TECHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_PANEL_DERECHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_PANEL_IZQUIERDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_PUERTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EIR_REFRIGERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DANADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTENEDORES_MOV_INFO_COMPLETACollection_Base class
}  // End of namespace
