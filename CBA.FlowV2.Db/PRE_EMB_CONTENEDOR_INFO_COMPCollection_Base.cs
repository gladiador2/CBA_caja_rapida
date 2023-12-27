// <fileinfo name="PRE_EMB_CONTENEDOR_INFO_COMPCollection_Base.cs">
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
	/// The base class for <see cref="PRE_EMB_CONTENEDOR_INFO_COMPCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PRE_EMB_CONTENEDOR_INFO_COMPCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PRE_EMB_CONTENEDOR_INFO_COMPCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PRE_EMBARQUE_DETALLE_IDColumnName = "PRE_EMBARQUE_DETALLE_ID";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string PUERTO_IDColumnName = "PUERTO_ID";
		public const string PUERTO_NOMBREColumnName = "PUERTO_NOMBRE";
		public const string INTERCAMBIO_EQUIPO_IDColumnName = "INTERCAMBIO_EQUIPO_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string CONTENEDOR_TIPO_IDColumnName = "CONTENEDOR_TIPO_ID";
		public const string CONTENEDOR_LINEA_IDColumnName = "CONTENEDOR_LINEA_ID";
		public const string TAMANOColumnName = "TAMANO";
		public const string CAPACIDADColumnName = "CAPACIDAD";
		public const string PESO_MAXIMOColumnName = "PESO_MAXIMO";
		public const string TIPOColumnName = "TIPO";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string LINEA_NOMBREColumnName = "LINEA_NOMBRE";
		public const string AGENCIA_IDColumnName = "AGENCIA_ID";
		public const string AGENCIA_NOMBREColumnName = "AGENCIA_NOMBRE";
		public const string MERCADERIAColumnName = "MERCADERIA";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string BOOKINGColumnName = "BOOKING";
		public const string CARTA_DE_FRIOColumnName = "CARTA_DE_FRIO";
		public const string SET_POINTColumnName = "SET_POINT";
		public const string IMO_IDColumnName = "IMO_ID";
		public const string PAYLOAD_EIRColumnName = "PAYLOAD_EIR";
		public const string TARA_EIRColumnName = "TARA_EIR";
		public const string TEMPERATURA_EIRColumnName = "TEMPERATURA_EIR";
		public const string HORA_EIRColumnName = "HORA_EIR";
		public const string PROCESADO_EIRColumnName = "PROCESADO_EIR";
		public const string SALIDOColumnName = "SALIDO";
		public const string EDIColumnName = "EDI";
		public const string EDI_ANULADOColumnName = "EDI_ANULADO";
		public const string EDI_ARMADORColumnName = "EDI_ARMADOR";
		public const string PRECINTO1ColumnName = "PRECINTO1";
		public const string PRECINTO2ColumnName = "PRECINTO2";
		public const string PRECINTO3ColumnName = "PRECINTO3";
		public const string PRECINTO4ColumnName = "PRECINTO4";
		public const string PRECINTO5ColumnName = "PRECINTO5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string PRECINTO_1_EIRColumnName = "PRECINTO_1_EIR";
		public const string PRECINTO_2_EIRColumnName = "PRECINTO_2_EIR";
		public const string PRECINTO_3_EIRColumnName = "PRECINTO_3_EIR";
		public const string PRECINTO_4_EIRColumnName = "PRECINTO_4_EIR";
		public const string PRECINTO_5_EIRColumnName = "PRECINTO_5_EIR";
		public const string PRECINTO_VENTILETE_EIRColumnName = "PRECINTO_VENTILETE_EIR";
		public const string EIR_PISOColumnName = "EIR_PISO";
		public const string EIR_FONDOColumnName = "EIR_FONDO";
		public const string EIR_TECHOColumnName = "EIR_TECHO";
		public const string EIR_PANEL_DERECHOColumnName = "EIR_PANEL_DERECHO";
		public const string EIR_PANEL_IZQUIERDOColumnName = "EIR_PANEL_IZQUIERDO";
		public const string EIR_PUERTAColumnName = "EIR_PUERTA";
		public const string EIR_REFRIGERADOColumnName = "EIR_REFRIGERADO";
		public const string OBSERVACIONES_EIRColumnName = "OBSERVACIONES_EIR";
		public const string DESCARTADOColumnName = "DESCARTADO";
		public const string ESTADO_CONTENEDORColumnName = "ESTADO_CONTENEDOR";
		public const string DESPACHO_FECHAColumnName = "DESPACHO_FECHA";
		public const string DESPACHO_NUMEROColumnName = "DESPACHO_NUMERO";
		public const string FACTURA_NUMEROColumnName = "FACTURA_NUMERO";
		public const string IMO_NOMBREColumnName = "IMO_NOMBRE";
		public const string DANADOColumnName = "DANADO";
		public const string DANO_INFORMADOColumnName = "DANO_INFORMADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PRE_EMB_CONTENEDOR_INFO_COMPCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PRE_EMB_CONTENEDOR_INFO_COMPCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PRE_EMB_CONTENEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects.</returns>
		public virtual PRE_EMB_CONTENEDOR_INFO_COMPRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PRE_EMB_CONTENEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PRE_EMB_CONTENEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PRE_EMB_CONTENEDOR_INFO_COMPRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PRE_EMB_CONTENEDOR_INFO_COMPRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects.</returns>
		public PRE_EMB_CONTENEDOR_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects that 
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
		/// <returns>An array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects.</returns>
		public virtual PRE_EMB_CONTENEDOR_INFO_COMPRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PRE_EMB_CONTENEDOR_INFO_COMP";
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
		/// <returns>An array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects.</returns>
		protected PRE_EMB_CONTENEDOR_INFO_COMPRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects.</returns>
		protected PRE_EMB_CONTENEDOR_INFO_COMPRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> objects.</returns>
		protected virtual PRE_EMB_CONTENEDOR_INFO_COMPRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pre_embarque_detalle_idColumnIndex = reader.GetOrdinal("PRE_EMBARQUE_DETALLE_ID");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int puerto_idColumnIndex = reader.GetOrdinal("PUERTO_ID");
			int puerto_nombreColumnIndex = reader.GetOrdinal("PUERTO_NOMBRE");
			int intercambio_equipo_idColumnIndex = reader.GetOrdinal("INTERCAMBIO_EQUIPO_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int contenedor_tipo_idColumnIndex = reader.GetOrdinal("CONTENEDOR_TIPO_ID");
			int contenedor_linea_idColumnIndex = reader.GetOrdinal("CONTENEDOR_LINEA_ID");
			int tamanoColumnIndex = reader.GetOrdinal("TAMANO");
			int capacidadColumnIndex = reader.GetOrdinal("CAPACIDAD");
			int peso_maximoColumnIndex = reader.GetOrdinal("PESO_MAXIMO");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int linea_nombreColumnIndex = reader.GetOrdinal("LINEA_NOMBRE");
			int agencia_idColumnIndex = reader.GetOrdinal("AGENCIA_ID");
			int agencia_nombreColumnIndex = reader.GetOrdinal("AGENCIA_NOMBRE");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int carta_de_frioColumnIndex = reader.GetOrdinal("CARTA_DE_FRIO");
			int set_pointColumnIndex = reader.GetOrdinal("SET_POINT");
			int imo_idColumnIndex = reader.GetOrdinal("IMO_ID");
			int payload_eirColumnIndex = reader.GetOrdinal("PAYLOAD_EIR");
			int tara_eirColumnIndex = reader.GetOrdinal("TARA_EIR");
			int temperatura_eirColumnIndex = reader.GetOrdinal("TEMPERATURA_EIR");
			int hora_eirColumnIndex = reader.GetOrdinal("HORA_EIR");
			int procesado_eirColumnIndex = reader.GetOrdinal("PROCESADO_EIR");
			int salidoColumnIndex = reader.GetOrdinal("SALIDO");
			int ediColumnIndex = reader.GetOrdinal("EDI");
			int edi_anuladoColumnIndex = reader.GetOrdinal("EDI_ANULADO");
			int edi_armadorColumnIndex = reader.GetOrdinal("EDI_ARMADOR");
			int precinto1ColumnIndex = reader.GetOrdinal("PRECINTO1");
			int precinto2ColumnIndex = reader.GetOrdinal("PRECINTO2");
			int precinto3ColumnIndex = reader.GetOrdinal("PRECINTO3");
			int precinto4ColumnIndex = reader.GetOrdinal("PRECINTO4");
			int precinto5ColumnIndex = reader.GetOrdinal("PRECINTO5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int precinto_1_eirColumnIndex = reader.GetOrdinal("PRECINTO_1_EIR");
			int precinto_2_eirColumnIndex = reader.GetOrdinal("PRECINTO_2_EIR");
			int precinto_3_eirColumnIndex = reader.GetOrdinal("PRECINTO_3_EIR");
			int precinto_4_eirColumnIndex = reader.GetOrdinal("PRECINTO_4_EIR");
			int precinto_5_eirColumnIndex = reader.GetOrdinal("PRECINTO_5_EIR");
			int precinto_ventilete_eirColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE_EIR");
			int eir_pisoColumnIndex = reader.GetOrdinal("EIR_PISO");
			int eir_fondoColumnIndex = reader.GetOrdinal("EIR_FONDO");
			int eir_techoColumnIndex = reader.GetOrdinal("EIR_TECHO");
			int eir_panel_derechoColumnIndex = reader.GetOrdinal("EIR_PANEL_DERECHO");
			int eir_panel_izquierdoColumnIndex = reader.GetOrdinal("EIR_PANEL_IZQUIERDO");
			int eir_puertaColumnIndex = reader.GetOrdinal("EIR_PUERTA");
			int eir_refrigeradoColumnIndex = reader.GetOrdinal("EIR_REFRIGERADO");
			int observaciones_eirColumnIndex = reader.GetOrdinal("OBSERVACIONES_EIR");
			int descartadoColumnIndex = reader.GetOrdinal("DESCARTADO");
			int estado_contenedorColumnIndex = reader.GetOrdinal("ESTADO_CONTENEDOR");
			int despacho_fechaColumnIndex = reader.GetOrdinal("DESPACHO_FECHA");
			int despacho_numeroColumnIndex = reader.GetOrdinal("DESPACHO_NUMERO");
			int factura_numeroColumnIndex = reader.GetOrdinal("FACTURA_NUMERO");
			int imo_nombreColumnIndex = reader.GetOrdinal("IMO_NOMBRE");
			int danadoColumnIndex = reader.GetOrdinal("DANADO");
			int dano_informadoColumnIndex = reader.GetOrdinal("DANO_INFORMADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PRE_EMB_CONTENEDOR_INFO_COMPRow record = new PRE_EMB_CONTENEDOR_INFO_COMPRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PRE_EMBARQUE_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pre_embarque_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_idColumnIndex))
						record.PUERTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_nombreColumnIndex))
						record.PUERTO_NOMBRE = Convert.ToString(reader.GetValue(puerto_nombreColumnIndex));
					if(!reader.IsDBNull(intercambio_equipo_idColumnIndex))
						record.INTERCAMBIO_EQUIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(intercambio_equipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_numeroColumnIndex))
						record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(contenedor_tipo_idColumnIndex))
						record.CONTENEDOR_TIPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_tipo_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_linea_idColumnIndex))
						record.CONTENEDOR_LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(tamanoColumnIndex))
						record.TAMANO = Math.Round(Convert.ToDecimal(reader.GetValue(tamanoColumnIndex)), 9);
					if(!reader.IsDBNull(capacidadColumnIndex))
						record.CAPACIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(capacidadColumnIndex)), 9);
					if(!reader.IsDBNull(peso_maximoColumnIndex))
						record.PESO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_maximoColumnIndex)), 9);
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Convert.ToString(reader.GetValue(tipoColumnIndex));
					if(!reader.IsDBNull(linea_idColumnIndex))
						record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(linea_nombreColumnIndex))
						record.LINEA_NOMBRE = Convert.ToString(reader.GetValue(linea_nombreColumnIndex));
					if(!reader.IsDBNull(agencia_idColumnIndex))
						record.AGENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(agencia_idColumnIndex)), 9);
					if(!reader.IsDBNull(agencia_nombreColumnIndex))
						record.AGENCIA_NOMBRE = Convert.ToString(reader.GetValue(agencia_nombreColumnIndex));
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(carta_de_frioColumnIndex))
						record.CARTA_DE_FRIO = Convert.ToString(reader.GetValue(carta_de_frioColumnIndex));
					if(!reader.IsDBNull(set_pointColumnIndex))
						record.SET_POINT = Convert.ToString(reader.GetValue(set_pointColumnIndex));
					if(!reader.IsDBNull(imo_idColumnIndex))
						record.IMO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(imo_idColumnIndex)), 9);
					if(!reader.IsDBNull(payload_eirColumnIndex))
						record.PAYLOAD_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(payload_eirColumnIndex)), 9);
					if(!reader.IsDBNull(tara_eirColumnIndex))
						record.TARA_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_eirColumnIndex)), 9);
					if(!reader.IsDBNull(temperatura_eirColumnIndex))
						record.TEMPERATURA_EIR = Math.Round(Convert.ToDecimal(reader.GetValue(temperatura_eirColumnIndex)), 9);
					if(!reader.IsDBNull(hora_eirColumnIndex))
						record.HORA_EIR = Convert.ToDateTime(reader.GetValue(hora_eirColumnIndex));
					if(!reader.IsDBNull(procesado_eirColumnIndex))
						record.PROCESADO_EIR = Convert.ToString(reader.GetValue(procesado_eirColumnIndex));
					if(!reader.IsDBNull(salidoColumnIndex))
						record.SALIDO = Convert.ToString(reader.GetValue(salidoColumnIndex));
					if(!reader.IsDBNull(ediColumnIndex))
						record.EDI = Convert.ToString(reader.GetValue(ediColumnIndex));
					if(!reader.IsDBNull(edi_anuladoColumnIndex))
						record.EDI_ANULADO = Convert.ToString(reader.GetValue(edi_anuladoColumnIndex));
					if(!reader.IsDBNull(edi_armadorColumnIndex))
						record.EDI_ARMADOR = Convert.ToString(reader.GetValue(edi_armadorColumnIndex));
					if(!reader.IsDBNull(precinto1ColumnIndex))
						record.PRECINTO1 = Convert.ToString(reader.GetValue(precinto1ColumnIndex));
					if(!reader.IsDBNull(precinto2ColumnIndex))
						record.PRECINTO2 = Convert.ToString(reader.GetValue(precinto2ColumnIndex));
					if(!reader.IsDBNull(precinto3ColumnIndex))
						record.PRECINTO3 = Convert.ToString(reader.GetValue(precinto3ColumnIndex));
					if(!reader.IsDBNull(precinto4ColumnIndex))
						record.PRECINTO4 = Convert.ToString(reader.GetValue(precinto4ColumnIndex));
					if(!reader.IsDBNull(precinto5ColumnIndex))
						record.PRECINTO5 = Convert.ToString(reader.GetValue(precinto5ColumnIndex));
					if(!reader.IsDBNull(precinto_ventileteColumnIndex))
						record.PRECINTO_VENTILETE = Convert.ToString(reader.GetValue(precinto_ventileteColumnIndex));
					if(!reader.IsDBNull(precinto_1_eirColumnIndex))
						record.PRECINTO_1_EIR = Convert.ToString(reader.GetValue(precinto_1_eirColumnIndex));
					if(!reader.IsDBNull(precinto_2_eirColumnIndex))
						record.PRECINTO_2_EIR = Convert.ToString(reader.GetValue(precinto_2_eirColumnIndex));
					if(!reader.IsDBNull(precinto_3_eirColumnIndex))
						record.PRECINTO_3_EIR = Convert.ToString(reader.GetValue(precinto_3_eirColumnIndex));
					if(!reader.IsDBNull(precinto_4_eirColumnIndex))
						record.PRECINTO_4_EIR = Convert.ToString(reader.GetValue(precinto_4_eirColumnIndex));
					if(!reader.IsDBNull(precinto_5_eirColumnIndex))
						record.PRECINTO_5_EIR = Convert.ToString(reader.GetValue(precinto_5_eirColumnIndex));
					if(!reader.IsDBNull(precinto_ventilete_eirColumnIndex))
						record.PRECINTO_VENTILETE_EIR = Convert.ToString(reader.GetValue(precinto_ventilete_eirColumnIndex));
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
					if(!reader.IsDBNull(observaciones_eirColumnIndex))
						record.OBSERVACIONES_EIR = Convert.ToString(reader.GetValue(observaciones_eirColumnIndex));
					if(!reader.IsDBNull(descartadoColumnIndex))
						record.DESCARTADO = Convert.ToString(reader.GetValue(descartadoColumnIndex));
					if(!reader.IsDBNull(estado_contenedorColumnIndex))
						record.ESTADO_CONTENEDOR = Convert.ToString(reader.GetValue(estado_contenedorColumnIndex));
					if(!reader.IsDBNull(despacho_fechaColumnIndex))
						record.DESPACHO_FECHA = Convert.ToDateTime(reader.GetValue(despacho_fechaColumnIndex));
					if(!reader.IsDBNull(despacho_numeroColumnIndex))
						record.DESPACHO_NUMERO = Convert.ToString(reader.GetValue(despacho_numeroColumnIndex));
					if(!reader.IsDBNull(factura_numeroColumnIndex))
						record.FACTURA_NUMERO = Convert.ToString(reader.GetValue(factura_numeroColumnIndex));
					if(!reader.IsDBNull(imo_nombreColumnIndex))
						record.IMO_NOMBRE = Convert.ToString(reader.GetValue(imo_nombreColumnIndex));
					if(!reader.IsDBNull(danadoColumnIndex))
						record.DANADO = Convert.ToString(reader.GetValue(danadoColumnIndex));
					if(!reader.IsDBNull(dano_informadoColumnIndex))
						record.DANO_INFORMADO = Convert.ToString(reader.GetValue(dano_informadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PRE_EMB_CONTENEDOR_INFO_COMPRow[])(recordList.ToArray(typeof(PRE_EMB_CONTENEDOR_INFO_COMPRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PRE_EMB_CONTENEDOR_INFO_COMPRow"/> object.</returns>
		protected virtual PRE_EMB_CONTENEDOR_INFO_COMPRow MapRow(DataRow row)
		{
			PRE_EMB_CONTENEDOR_INFO_COMPRow mappedObject = new PRE_EMB_CONTENEDOR_INFO_COMPRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PRE_EMBARQUE_DETALLE_ID"
			dataColumn = dataTable.Columns["PRE_EMBARQUE_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRE_EMBARQUE_DETALLE_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "PUERTO_ID"
			dataColumn = dataTable.Columns["PUERTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ID = (decimal)row[dataColumn];
			// Column "PUERTO_NOMBRE"
			dataColumn = dataTable.Columns["PUERTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_NOMBRE = (string)row[dataColumn];
			// Column "INTERCAMBIO_EQUIPO_ID"
			dataColumn = dataTable.Columns["INTERCAMBIO_EQUIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_EQUIPO_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "CONTENEDOR_TIPO_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_TIPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_TIPO_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_LINEA_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_LINEA_ID = (decimal)row[dataColumn];
			// Column "TAMANO"
			dataColumn = dataTable.Columns["TAMANO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TAMANO = (decimal)row[dataColumn];
			// Column "CAPACIDAD"
			dataColumn = dataTable.Columns["CAPACIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CAPACIDAD = (decimal)row[dataColumn];
			// Column "PESO_MAXIMO"
			dataColumn = dataTable.Columns["PESO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MAXIMO = (decimal)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (string)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "LINEA_NOMBRE"
			dataColumn = dataTable.Columns["LINEA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_NOMBRE = (string)row[dataColumn];
			// Column "AGENCIA_ID"
			dataColumn = dataTable.Columns["AGENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_ID = (decimal)row[dataColumn];
			// Column "AGENCIA_NOMBRE"
			dataColumn = dataTable.Columns["AGENCIA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENCIA_NOMBRE = (string)row[dataColumn];
			// Column "MERCADERIA"
			dataColumn = dataTable.Columns["MERCADERIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "CARTA_DE_FRIO"
			dataColumn = dataTable.Columns["CARTA_DE_FRIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CARTA_DE_FRIO = (string)row[dataColumn];
			// Column "SET_POINT"
			dataColumn = dataTable.Columns["SET_POINT"];
			if(!row.IsNull(dataColumn))
				mappedObject.SET_POINT = (string)row[dataColumn];
			// Column "IMO_ID"
			dataColumn = dataTable.Columns["IMO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMO_ID = (decimal)row[dataColumn];
			// Column "PAYLOAD_EIR"
			dataColumn = dataTable.Columns["PAYLOAD_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAYLOAD_EIR = (decimal)row[dataColumn];
			// Column "TARA_EIR"
			dataColumn = dataTable.Columns["TARA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_EIR = (decimal)row[dataColumn];
			// Column "TEMPERATURA_EIR"
			dataColumn = dataTable.Columns["TEMPERATURA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPERATURA_EIR = (decimal)row[dataColumn];
			// Column "HORA_EIR"
			dataColumn = dataTable.Columns["HORA_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_EIR = (System.DateTime)row[dataColumn];
			// Column "PROCESADO_EIR"
			dataColumn = dataTable.Columns["PROCESADO_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADO_EIR = (string)row[dataColumn];
			// Column "SALIDO"
			dataColumn = dataTable.Columns["SALIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALIDO = (string)row[dataColumn];
			// Column "EDI"
			dataColumn = dataTable.Columns["EDI"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI = (string)row[dataColumn];
			// Column "EDI_ANULADO"
			dataColumn = dataTable.Columns["EDI_ANULADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_ANULADO = (string)row[dataColumn];
			// Column "EDI_ARMADOR"
			dataColumn = dataTable.Columns["EDI_ARMADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI_ARMADOR = (string)row[dataColumn];
			// Column "PRECINTO1"
			dataColumn = dataTable.Columns["PRECINTO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO1 = (string)row[dataColumn];
			// Column "PRECINTO2"
			dataColumn = dataTable.Columns["PRECINTO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO2 = (string)row[dataColumn];
			// Column "PRECINTO3"
			dataColumn = dataTable.Columns["PRECINTO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO3 = (string)row[dataColumn];
			// Column "PRECINTO4"
			dataColumn = dataTable.Columns["PRECINTO4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO4 = (string)row[dataColumn];
			// Column "PRECINTO5"
			dataColumn = dataTable.Columns["PRECINTO5"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO5 = (string)row[dataColumn];
			// Column "PRECINTO_VENTILETE"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE = (string)row[dataColumn];
			// Column "PRECINTO_1_EIR"
			dataColumn = dataTable.Columns["PRECINTO_1_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_1_EIR = (string)row[dataColumn];
			// Column "PRECINTO_2_EIR"
			dataColumn = dataTable.Columns["PRECINTO_2_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_2_EIR = (string)row[dataColumn];
			// Column "PRECINTO_3_EIR"
			dataColumn = dataTable.Columns["PRECINTO_3_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_3_EIR = (string)row[dataColumn];
			// Column "PRECINTO_4_EIR"
			dataColumn = dataTable.Columns["PRECINTO_4_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_4_EIR = (string)row[dataColumn];
			// Column "PRECINTO_5_EIR"
			dataColumn = dataTable.Columns["PRECINTO_5_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_5_EIR = (string)row[dataColumn];
			// Column "PRECINTO_VENTILETE_EIR"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE_EIR = (string)row[dataColumn];
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
			// Column "OBSERVACIONES_EIR"
			dataColumn = dataTable.Columns["OBSERVACIONES_EIR"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES_EIR = (string)row[dataColumn];
			// Column "DESCARTADO"
			dataColumn = dataTable.Columns["DESCARTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCARTADO = (string)row[dataColumn];
			// Column "ESTADO_CONTENEDOR"
			dataColumn = dataTable.Columns["ESTADO_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CONTENEDOR = (string)row[dataColumn];
			// Column "DESPACHO_FECHA"
			dataColumn = dataTable.Columns["DESPACHO_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO_FECHA = (System.DateTime)row[dataColumn];
			// Column "DESPACHO_NUMERO"
			dataColumn = dataTable.Columns["DESPACHO_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO_NUMERO = (string)row[dataColumn];
			// Column "FACTURA_NUMERO"
			dataColumn = dataTable.Columns["FACTURA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_NUMERO = (string)row[dataColumn];
			// Column "IMO_NOMBRE"
			dataColumn = dataTable.Columns["IMO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMO_NOMBRE = (string)row[dataColumn];
			// Column "DANADO"
			dataColumn = dataTable.Columns["DANADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANADO = (string)row[dataColumn];
			// Column "DANO_INFORMADO"
			dataColumn = dataTable.Columns["DANO_INFORMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANO_INFORMADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PRE_EMB_CONTENEDOR_INFO_COMP</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PRE_EMB_CONTENEDOR_INFO_COMP";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRE_EMBARQUE_DETALLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_EQUIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_TIPO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_LINEA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TAMANO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CAPACIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_MAXIMO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LINEA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AGENCIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AGENCIA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CARTA_DE_FRIO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SET_POINT", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAYLOAD_EIR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_EIR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEMPERATURA_EIR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("HORA_EIR", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROCESADO_EIR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EDI", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EDI_ANULADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EDI_ARMADOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO1", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO2", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO3", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO4", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO5", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_1_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_2_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_3_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_4_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_5_EIR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE_EIR", typeof(string));
			dataColumn.MaxLength = 25;
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
			dataColumn.MaxLength = 800;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES_EIR", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCARTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHO_FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESPACHO_NUMERO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_NUMERO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DANADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DANO_INFORMADO", typeof(string));
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

				case "PRE_EMBARQUE_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INTERCAMBIO_EQUIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_TIPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TAMANO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CAPACIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LINEA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AGENCIA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CARTA_DE_FRIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SET_POINT":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAYLOAD_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEMPERATURA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "HORA_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PROCESADO_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SALIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDI":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDI_ANULADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EDI_ARMADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRECINTO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_1_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_2_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_3_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_4_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_5_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_VENTILETE_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "OBSERVACIONES_EIR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCARTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DESPACHO_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DANADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DANO_INFORMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PRE_EMB_CONTENEDOR_INFO_COMPCollection_Base class
}  // End of namespace
