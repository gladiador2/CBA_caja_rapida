// <fileinfo name="ITEMS_INGRESOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_INGRESOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_HORAColumnName = "FECHA_HORA";
		public const string MIC_DTAColumnName = "MIC_DTA";
		public const string COMPROBANTEColumnName = "COMPROBANTE";
		public const string ORIGENColumnName = "ORIGEN";
		public const string FCL_LCLColumnName = "FCL_LCL";
		public const string TRANSPORTADORA_PERSONA_IDColumnName = "TRANSPORTADORA_PERSONA_ID";
		public const string TRASPORTADORA_PERSONA_CODIGOColumnName = "TRASPORTADORA_PERSONA_CODIGO";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string TIPO_CAMION_IDColumnName = "TIPO_CAMION_ID";
		public const string TIPO_CAMION_NOMBREColumnName = "TIPO_CAMION_NOMBRE";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string TARA_CARRETAColumnName = "TARA_CARRETA";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string PESO_MANIFESTADOColumnName = "PESO_MANIFESTADO";
		public const string TOLERANCIAColumnName = "TOLERANCIA";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string CONTENEDOR_TIPOColumnName = "CONTENEDOR_TIPO";
		public const string CONTENEDOR_LINEA_IDColumnName = "CONTENEDOR_LINEA_ID";
		public const string CONTENEDOR_LINEAColumnName = "CONTENEDOR_LINEA";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string DIFERENCIAColumnName = "DIFERENCIA";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string VALOR_NETOColumnName = "VALOR_NETO";
		public const string VALOR_MONEDA_IDColumnName = "VALOR_MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CANTIDAD_DECIMALESColumnName = "MONEDA_CANTIDAD_DECIMALES";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string CONFIRMADOColumnName = "CONFIRMADO";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string SEMANAColumnName = "SEMANA";
		public const string NOTIFICADOColumnName = "NOTIFICADO";
		public const string OBSERVACION_NOTIFICACIONColumnName = "OBSERVACION_NOTIFICACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_INGRESOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_INGRESOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_INGRESOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_INGRESOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_INGRESOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_INGRESOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects.</returns>
		public ITEMS_INGRESOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_INGRESOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects.</returns>
		protected ITEMS_INGRESOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects.</returns>
		protected ITEMS_INGRESOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual ITEMS_INGRESOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_horaColumnIndex = reader.GetOrdinal("FECHA_HORA");
			int mic_dtaColumnIndex = reader.GetOrdinal("MIC_DTA");
			int comprobanteColumnIndex = reader.GetOrdinal("COMPROBANTE");
			int origenColumnIndex = reader.GetOrdinal("ORIGEN");
			int fcl_lclColumnIndex = reader.GetOrdinal("FCL_LCL");
			int transportadora_persona_idColumnIndex = reader.GetOrdinal("TRANSPORTADORA_PERSONA_ID");
			int trasportadora_persona_codigoColumnIndex = reader.GetOrdinal("TRASPORTADORA_PERSONA_CODIGO");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int tipo_camion_idColumnIndex = reader.GetOrdinal("TIPO_CAMION_ID");
			int tipo_camion_nombreColumnIndex = reader.GetOrdinal("TIPO_CAMION_NOMBRE");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int tara_carretaColumnIndex = reader.GetOrdinal("TARA_CARRETA");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int peso_manifestadoColumnIndex = reader.GetOrdinal("PESO_MANIFESTADO");
			int toleranciaColumnIndex = reader.GetOrdinal("TOLERANCIA");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int contenedor_tipoColumnIndex = reader.GetOrdinal("CONTENEDOR_TIPO");
			int contenedor_linea_idColumnIndex = reader.GetOrdinal("CONTENEDOR_LINEA_ID");
			int contenedor_lineaColumnIndex = reader.GetOrdinal("CONTENEDOR_LINEA");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int diferenciaColumnIndex = reader.GetOrdinal("DIFERENCIA");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int valor_netoColumnIndex = reader.GetOrdinal("VALOR_NETO");
			int valor_moneda_idColumnIndex = reader.GetOrdinal("VALOR_MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cantidad_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CANTIDAD_DECIMALES");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int confirmadoColumnIndex = reader.GetOrdinal("CONFIRMADO");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");
			int notificadoColumnIndex = reader.GetOrdinal("NOTIFICADO");
			int observacion_notificacionColumnIndex = reader.GetOrdinal("OBSERVACION_NOTIFICACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_INGRESOS_INFO_COMPLETARow record = new ITEMS_INGRESOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_horaColumnIndex))
						record.FECHA_HORA = Convert.ToDateTime(reader.GetValue(fecha_horaColumnIndex));
					if(!reader.IsDBNull(mic_dtaColumnIndex))
						record.MIC_DTA = Convert.ToString(reader.GetValue(mic_dtaColumnIndex));
					if(!reader.IsDBNull(comprobanteColumnIndex))
						record.COMPROBANTE = Convert.ToString(reader.GetValue(comprobanteColumnIndex));
					if(!reader.IsDBNull(origenColumnIndex))
						record.ORIGEN = Convert.ToString(reader.GetValue(origenColumnIndex));
					if(!reader.IsDBNull(fcl_lclColumnIndex))
						record.FCL_LCL = Convert.ToString(reader.GetValue(fcl_lclColumnIndex));
					if(!reader.IsDBNull(transportadora_persona_idColumnIndex))
						record.TRANSPORTADORA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transportadora_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(trasportadora_persona_codigoColumnIndex))
						record.TRASPORTADORA_PERSONA_CODIGO = Convert.ToString(reader.GetValue(trasportadora_persona_codigoColumnIndex));
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(tipo_camion_idColumnIndex))
						record.TIPO_CAMION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_camion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_camion_nombreColumnIndex))
						record.TIPO_CAMION_NOMBRE = Convert.ToString(reader.GetValue(tipo_camion_nombreColumnIndex));
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(tara_carretaColumnIndex))
						record.TARA_CARRETA = Math.Round(Convert.ToDecimal(reader.GetValue(tara_carretaColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(peso_manifestadoColumnIndex))
						record.PESO_MANIFESTADO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_manifestadoColumnIndex)), 9);
					if(!reader.IsDBNull(toleranciaColumnIndex))
						record.TOLERANCIA = Math.Round(Convert.ToDecimal(reader.GetValue(toleranciaColumnIndex)), 9);
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_numeroColumnIndex))
						record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(contenedor_tipoColumnIndex))
						record.CONTENEDOR_TIPO = Convert.ToString(reader.GetValue(contenedor_tipoColumnIndex));
					if(!reader.IsDBNull(contenedor_linea_idColumnIndex))
						record.CONTENEDOR_LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_lineaColumnIndex))
						record.CONTENEDOR_LINEA = Convert.ToString(reader.GetValue(contenedor_lineaColumnIndex));
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(diferenciaColumnIndex))
						record.DIFERENCIA = Math.Round(Convert.ToDecimal(reader.GetValue(diferenciaColumnIndex)), 9);
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
					if(!reader.IsDBNull(valor_netoColumnIndex))
						record.VALOR_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(valor_netoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_moneda_idColumnIndex))
						record.VALOR_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(valor_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_nombreColumnIndex))
						record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_simboloColumnIndex))
						record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(moneda_cantidad_decimalesColumnIndex))
						record.MONEDA_CANTIDAD_DECIMALES = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_cantidad_decimalesColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(confirmadoColumnIndex))
						record.CONFIRMADO = Convert.ToString(reader.GetValue(confirmadoColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);
					if(!reader.IsDBNull(notificadoColumnIndex))
						record.NOTIFICADO = Convert.ToString(reader.GetValue(notificadoColumnIndex));
					if(!reader.IsDBNull(observacion_notificacionColumnIndex))
						record.OBSERVACION_NOTIFICACION = Convert.ToString(reader.GetValue(observacion_notificacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_INGRESOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(ITEMS_INGRESOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_INGRESOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual ITEMS_INGRESOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			ITEMS_INGRESOS_INFO_COMPLETARow mappedObject = new ITEMS_INGRESOS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_HORA"
			dataColumn = dataTable.Columns["FECHA_HORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HORA = (System.DateTime)row[dataColumn];
			// Column "MIC_DTA"
			dataColumn = dataTable.Columns["MIC_DTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MIC_DTA = (string)row[dataColumn];
			// Column "COMPROBANTE"
			dataColumn = dataTable.Columns["COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.COMPROBANTE = (string)row[dataColumn];
			// Column "ORIGEN"
			dataColumn = dataTable.Columns["ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORIGEN = (string)row[dataColumn];
			// Column "FCL_LCL"
			dataColumn = dataTable.Columns["FCL_LCL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FCL_LCL = (string)row[dataColumn];
			// Column "TRANSPORTADORA_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSPORTADORA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "TRASPORTADORA_PERSONA_CODIGO"
			dataColumn = dataTable.Columns["TRASPORTADORA_PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRASPORTADORA_PERSONA_CODIGO = (string)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "TIPO_CAMION_ID"
			dataColumn = dataTable.Columns["TIPO_CAMION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CAMION_ID = (decimal)row[dataColumn];
			// Column "TIPO_CAMION_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_CAMION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CAMION_NOMBRE = (string)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "TARA_CARRETA"
			dataColumn = dataTable.Columns["TARA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CARRETA = (decimal)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "PESO_MANIFESTADO"
			dataColumn = dataTable.Columns["PESO_MANIFESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_MANIFESTADO = (decimal)row[dataColumn];
			// Column "TOLERANCIA"
			dataColumn = dataTable.Columns["TOLERANCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOLERANCIA = (decimal)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "CONTENEDOR_TIPO"
			dataColumn = dataTable.Columns["CONTENEDOR_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_TIPO = (string)row[dataColumn];
			// Column "CONTENEDOR_LINEA_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_LINEA_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_LINEA"
			dataColumn = dataTable.Columns["CONTENEDOR_LINEA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_LINEA = (string)row[dataColumn];
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "DIFERENCIA"
			dataColumn = dataTable.Columns["DIFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIFERENCIA = (decimal)row[dataColumn];
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
			// Column "VALOR_NETO"
			dataColumn = dataTable.Columns["VALOR_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_NETO = (decimal)row[dataColumn];
			// Column "VALOR_MONEDA_ID"
			dataColumn = dataTable.Columns["VALOR_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "MONEDA_CANTIDAD_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CANTIDAD_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CANTIDAD_DECIMALES = (decimal)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "CONFIRMADO"
			dataColumn = dataTable.Columns["CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONFIRMADO = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			// Column "NOTIFICADO"
			dataColumn = dataTable.Columns["NOTIFICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTIFICADO = (string)row[dataColumn];
			// Column "OBSERVACION_NOTIFICACION"
			dataColumn = dataTable.Columns["OBSERVACION_NOTIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION_NOTIFICACION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_INGRESOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_INGRESOS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_HORA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MIC_DTA", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ORIGEN", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FCL_LCL", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRASPORTADORA_PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CAMION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CAMION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CARRETA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_MANIFESTADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOLERANCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_TIPO", typeof(string));
			dataColumn.MaxLength = 56;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_LINEA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_LINEA", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DIFERENCIA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_2", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_3", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_4", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_5", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CANTIDAD_DECIMALES", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTIFICADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACION_NOTIFICACION", typeof(string));
			dataColumn.MaxLength = 2000;
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

				case "FECHA_HORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MIC_DTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FCL_LCL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRASPORTADORA_PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CAMION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CAMION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO_MANIFESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOLERANCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_LINEA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "VALOR_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CANTIDAD_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTIFICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION_NOTIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_INGRESOS_INFO_COMPLETACollection_Base class
}  // End of namespace
