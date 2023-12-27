// <fileinfo name="ITEMS_INGR_DEP_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGR_DEP_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEMS_INGRESO_DEPOSITO_IDColumnName = "ITEMS_INGRESO_DEPOSITO_ID";
		public const string ITEMS_INGRESO_DETALLE_IDColumnName = "ITEMS_INGRESO_DETALLE_ID";
		public const string UBICACIONColumnName = "UBICACION";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string TIPO_BULTOSColumnName = "TIPO_BULTOS";
		public const string MERCADERIASColumnName = "MERCADERIAS";
		public const string PESOColumnName = "PESO";
		public const string LARGOColumnName = "LARGO";
		public const string ANCHOColumnName = "ANCHO";
		public const string ALTOColumnName = "ALTO";
		public const string TOTAL_ESPACIOColumnName = "TOTAL_ESPACIO";
		public const string ESTIBADORESColumnName = "ESTIBADORES";
		public const string ESTIBADORES_FACTURADOSColumnName = "ESTIBADORES_FACTURADOS";
		public const string MONTACARGASColumnName = "MONTACARGAS";
		public const string MONTACARGAS_FACTURADOSColumnName = "MONTACARGAS_FACTURADOS";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string USO_BASCULAColumnName = "USO_BASCULA";
		public const string USO_BASCULA_FACTURADOColumnName = "USO_BASCULA_FACTURADO";
		public const string USO_GRUAColumnName = "USO_GRUA";
		public const string USO_GRUA_FACTURADOColumnName = "USO_GRUA_FACTURADO";
		public const string CONSIGNATARIO_PERSONA_IDColumnName = "CONSIGNATARIO_PERSONA_ID";
		public const string CONSIGNATARIO_CODIGOColumnName = "CONSIGNATARIO_CODIGO";
		public const string CONSIGNATARIO_NOMBREColumnName = "CONSIGNATARIO_NOMBRE";
		public const string CONOCIMIENTOColumnName = "CONOCIMIENTO";
		public const string CANTIDAD_MANIFESTADAColumnName = "CANTIDAD_MANIFESTADA";
		public const string TIPO_BULTO_MANIFESTADOColumnName = "TIPO_BULTO_MANIFESTADO";
		public const string MERCADERIA_MANIFESTADAColumnName = "MERCADERIA_MANIFESTADA";
		public const string VALOR_NETOColumnName = "VALOR_NETO";
		public const string VALOR_MONEDA_IDColumnName = "VALOR_MONEDA_ID";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string MONEDA_CADENA_DECIMALESColumnName = "MONEDA_CADENA_DECIMALES";
		public const string FACTURA_COMERCIALColumnName = "FACTURA_COMERCIAL";
		public const string FECHA_INGRESOColumnName = "FECHA_INGRESO";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string GENERACION_CONFIRMADAColumnName = "GENERACION_CONFIRMADA";
		public const string INGRESO_CONFIRMADOColumnName = "INGRESO_CONFIRMADO";
		public const string NUMERO_COMPROBANTEColumnName = "NUMERO_COMPROBANTE";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string FCL_LCLColumnName = "FCL_LCL";
		public const string MIC_DTAColumnName = "MIC_DTA";
		public const string SEMANAColumnName = "SEMANA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_INGR_DEP_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_INGR_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual ITEMS_INGR_DEP_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_INGR_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_INGR_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_INGR_DEP_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_INGR_DEP_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		public ITEMS_INGR_DEP_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual ITEMS_INGR_DEP_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_INGR_DEP_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		protected ITEMS_INGR_DEP_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		protected ITEMS_INGR_DEP_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual ITEMS_INGR_DEP_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int items_ingreso_deposito_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_DEPOSITO_ID");
			int items_ingreso_detalle_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_DETALLE_ID");
			int ubicacionColumnIndex = reader.GetOrdinal("UBICACION");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int tipo_bultosColumnIndex = reader.GetOrdinal("TIPO_BULTOS");
			int mercaderiasColumnIndex = reader.GetOrdinal("MERCADERIAS");
			int pesoColumnIndex = reader.GetOrdinal("PESO");
			int largoColumnIndex = reader.GetOrdinal("LARGO");
			int anchoColumnIndex = reader.GetOrdinal("ANCHO");
			int altoColumnIndex = reader.GetOrdinal("ALTO");
			int total_espacioColumnIndex = reader.GetOrdinal("TOTAL_ESPACIO");
			int estibadoresColumnIndex = reader.GetOrdinal("ESTIBADORES");
			int estibadores_facturadosColumnIndex = reader.GetOrdinal("ESTIBADORES_FACTURADOS");
			int montacargasColumnIndex = reader.GetOrdinal("MONTACARGAS");
			int montacargas_facturadosColumnIndex = reader.GetOrdinal("MONTACARGAS_FACTURADOS");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int uso_basculaColumnIndex = reader.GetOrdinal("USO_BASCULA");
			int uso_bascula_facturadoColumnIndex = reader.GetOrdinal("USO_BASCULA_FACTURADO");
			int uso_gruaColumnIndex = reader.GetOrdinal("USO_GRUA");
			int uso_grua_facturadoColumnIndex = reader.GetOrdinal("USO_GRUA_FACTURADO");
			int consignatario_persona_idColumnIndex = reader.GetOrdinal("CONSIGNATARIO_PERSONA_ID");
			int consignatario_codigoColumnIndex = reader.GetOrdinal("CONSIGNATARIO_CODIGO");
			int consignatario_nombreColumnIndex = reader.GetOrdinal("CONSIGNATARIO_NOMBRE");
			int conocimientoColumnIndex = reader.GetOrdinal("CONOCIMIENTO");
			int cantidad_manifestadaColumnIndex = reader.GetOrdinal("CANTIDAD_MANIFESTADA");
			int tipo_bulto_manifestadoColumnIndex = reader.GetOrdinal("TIPO_BULTO_MANIFESTADO");
			int mercaderia_manifestadaColumnIndex = reader.GetOrdinal("MERCADERIA_MANIFESTADA");
			int valor_netoColumnIndex = reader.GetOrdinal("VALOR_NETO");
			int valor_moneda_idColumnIndex = reader.GetOrdinal("VALOR_MONEDA_ID");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int moneda_cadena_decimalesColumnIndex = reader.GetOrdinal("MONEDA_CADENA_DECIMALES");
			int factura_comercialColumnIndex = reader.GetOrdinal("FACTURA_COMERCIAL");
			int fecha_ingresoColumnIndex = reader.GetOrdinal("FECHA_INGRESO");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int generacion_confirmadaColumnIndex = reader.GetOrdinal("GENERACION_CONFIRMADA");
			int ingreso_confirmadoColumnIndex = reader.GetOrdinal("INGRESO_CONFIRMADO");
			int numero_comprobanteColumnIndex = reader.GetOrdinal("NUMERO_COMPROBANTE");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int fcl_lclColumnIndex = reader.GetOrdinal("FCL_LCL");
			int mic_dtaColumnIndex = reader.GetOrdinal("MIC_DTA");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_INGR_DEP_DET_INFO_COMPLRow record = new ITEMS_INGR_DEP_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingreso_deposito_idColumnIndex))
						record.ITEMS_INGRESO_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_deposito_idColumnIndex)), 9);
					record.ITEMS_INGRESO_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(ubicacionColumnIndex))
						record.UBICACION = Convert.ToString(reader.GetValue(ubicacionColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_bultosColumnIndex))
						record.TIPO_BULTOS = Convert.ToString(reader.GetValue(tipo_bultosColumnIndex));
					if(!reader.IsDBNull(mercaderiasColumnIndex))
						record.MERCADERIAS = Convert.ToString(reader.GetValue(mercaderiasColumnIndex));
					if(!reader.IsDBNull(pesoColumnIndex))
						record.PESO = Math.Round(Convert.ToDecimal(reader.GetValue(pesoColumnIndex)), 9);
					record.LARGO = Math.Round(Convert.ToDecimal(reader.GetValue(largoColumnIndex)), 9);
					record.ANCHO = Math.Round(Convert.ToDecimal(reader.GetValue(anchoColumnIndex)), 9);
					if(!reader.IsDBNull(altoColumnIndex))
						record.ALTO = Math.Round(Convert.ToDecimal(reader.GetValue(altoColumnIndex)), 9);
					record.TOTAL_ESPACIO = Math.Round(Convert.ToDecimal(reader.GetValue(total_espacioColumnIndex)), 9);
					record.ESTIBADORES = Math.Round(Convert.ToDecimal(reader.GetValue(estibadoresColumnIndex)), 9);
					if(!reader.IsDBNull(estibadores_facturadosColumnIndex))
						record.ESTIBADORES_FACTURADOS = Math.Round(Convert.ToDecimal(reader.GetValue(estibadores_facturadosColumnIndex)), 9);
					record.MONTACARGAS = Math.Round(Convert.ToDecimal(reader.GetValue(montacargasColumnIndex)), 9);
					if(!reader.IsDBNull(montacargas_facturadosColumnIndex))
						record.MONTACARGAS_FACTURADOS = Math.Round(Convert.ToDecimal(reader.GetValue(montacargas_facturadosColumnIndex)), 9);
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(uso_basculaColumnIndex))
						record.USO_BASCULA = Math.Round(Convert.ToDecimal(reader.GetValue(uso_basculaColumnIndex)), 9);
					if(!reader.IsDBNull(uso_bascula_facturadoColumnIndex))
						record.USO_BASCULA_FACTURADO = Math.Round(Convert.ToDecimal(reader.GetValue(uso_bascula_facturadoColumnIndex)), 9);
					if(!reader.IsDBNull(uso_gruaColumnIndex))
						record.USO_GRUA = Math.Round(Convert.ToDecimal(reader.GetValue(uso_gruaColumnIndex)), 9);
					if(!reader.IsDBNull(uso_grua_facturadoColumnIndex))
						record.USO_GRUA_FACTURADO = Math.Round(Convert.ToDecimal(reader.GetValue(uso_grua_facturadoColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_persona_idColumnIndex))
						record.CONSIGNATARIO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(consignatario_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_codigoColumnIndex))
						record.CONSIGNATARIO_CODIGO = Convert.ToString(reader.GetValue(consignatario_codigoColumnIndex));
					if(!reader.IsDBNull(consignatario_nombreColumnIndex))
						record.CONSIGNATARIO_NOMBRE = Convert.ToString(reader.GetValue(consignatario_nombreColumnIndex));
					if(!reader.IsDBNull(conocimientoColumnIndex))
						record.CONOCIMIENTO = Convert.ToString(reader.GetValue(conocimientoColumnIndex));
					if(!reader.IsDBNull(cantidad_manifestadaColumnIndex))
						record.CANTIDAD_MANIFESTADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_manifestadaColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_bulto_manifestadoColumnIndex))
						record.TIPO_BULTO_MANIFESTADO = Convert.ToString(reader.GetValue(tipo_bulto_manifestadoColumnIndex));
					if(!reader.IsDBNull(mercaderia_manifestadaColumnIndex))
						record.MERCADERIA_MANIFESTADA = Convert.ToString(reader.GetValue(mercaderia_manifestadaColumnIndex));
					if(!reader.IsDBNull(valor_netoColumnIndex))
						record.VALOR_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(valor_netoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_moneda_idColumnIndex))
						record.VALOR_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(valor_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_simboloColumnIndex))
						record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(moneda_cadena_decimalesColumnIndex))
						record.MONEDA_CADENA_DECIMALES = Convert.ToString(reader.GetValue(moneda_cadena_decimalesColumnIndex));
					if(!reader.IsDBNull(factura_comercialColumnIndex))
						record.FACTURA_COMERCIAL = Convert.ToString(reader.GetValue(factura_comercialColumnIndex));
					if(!reader.IsDBNull(fecha_ingresoColumnIndex))
						record.FECHA_INGRESO = Convert.ToDateTime(reader.GetValue(fecha_ingresoColumnIndex));
					if(!reader.IsDBNull(fecha_emisionColumnIndex))
						record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(generacion_confirmadaColumnIndex))
						record.GENERACION_CONFIRMADA = Convert.ToString(reader.GetValue(generacion_confirmadaColumnIndex));
					if(!reader.IsDBNull(ingreso_confirmadoColumnIndex))
						record.INGRESO_CONFIRMADO = Convert.ToString(reader.GetValue(ingreso_confirmadoColumnIndex));
					if(!reader.IsDBNull(numero_comprobanteColumnIndex))
						record.NUMERO_COMPROBANTE = Convert.ToString(reader.GetValue(numero_comprobanteColumnIndex));
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(fcl_lclColumnIndex))
						record.FCL_LCL = Convert.ToString(reader.GetValue(fcl_lclColumnIndex));
					if(!reader.IsDBNull(mic_dtaColumnIndex))
						record.MIC_DTA = Convert.ToString(reader.GetValue(mic_dtaColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_INGR_DEP_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(ITEMS_INGR_DEP_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_INGR_DEP_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual ITEMS_INGR_DEP_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			ITEMS_INGR_DEP_DET_INFO_COMPLRow mappedObject = new ITEMS_INGR_DEP_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESO_DEPOSITO_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESO_DETALLE_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_DETALLE_ID = (decimal)row[dataColumn];
			// Column "UBICACION"
			dataColumn = dataTable.Columns["UBICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UBICACION = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "TIPO_BULTOS"
			dataColumn = dataTable.Columns["TIPO_BULTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_BULTOS = (string)row[dataColumn];
			// Column "MERCADERIAS"
			dataColumn = dataTable.Columns["MERCADERIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIAS = (string)row[dataColumn];
			// Column "PESO"
			dataColumn = dataTable.Columns["PESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO = (decimal)row[dataColumn];
			// Column "LARGO"
			dataColumn = dataTable.Columns["LARGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LARGO = (decimal)row[dataColumn];
			// Column "ANCHO"
			dataColumn = dataTable.Columns["ANCHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANCHO = (decimal)row[dataColumn];
			// Column "ALTO"
			dataColumn = dataTable.Columns["ALTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ALTO = (decimal)row[dataColumn];
			// Column "TOTAL_ESPACIO"
			dataColumn = dataTable.Columns["TOTAL_ESPACIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_ESPACIO = (decimal)row[dataColumn];
			// Column "ESTIBADORES"
			dataColumn = dataTable.Columns["ESTIBADORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTIBADORES = (decimal)row[dataColumn];
			// Column "ESTIBADORES_FACTURADOS"
			dataColumn = dataTable.Columns["ESTIBADORES_FACTURADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTIBADORES_FACTURADOS = (decimal)row[dataColumn];
			// Column "MONTACARGAS"
			dataColumn = dataTable.Columns["MONTACARGAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTACARGAS = (decimal)row[dataColumn];
			// Column "MONTACARGAS_FACTURADOS"
			dataColumn = dataTable.Columns["MONTACARGAS_FACTURADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTACARGAS_FACTURADOS = (decimal)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "USO_BASCULA"
			dataColumn = dataTable.Columns["USO_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_BASCULA = (decimal)row[dataColumn];
			// Column "USO_BASCULA_FACTURADO"
			dataColumn = dataTable.Columns["USO_BASCULA_FACTURADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_BASCULA_FACTURADO = (decimal)row[dataColumn];
			// Column "USO_GRUA"
			dataColumn = dataTable.Columns["USO_GRUA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_GRUA = (decimal)row[dataColumn];
			// Column "USO_GRUA_FACTURADO"
			dataColumn = dataTable.Columns["USO_GRUA_FACTURADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_GRUA_FACTURADO = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_PERSONA_ID"
			dataColumn = dataTable.Columns["CONSIGNATARIO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_CODIGO"
			dataColumn = dataTable.Columns["CONSIGNATARIO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_CODIGO = (string)row[dataColumn];
			// Column "CONSIGNATARIO_NOMBRE"
			dataColumn = dataTable.Columns["CONSIGNATARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_NOMBRE = (string)row[dataColumn];
			// Column "CONOCIMIENTO"
			dataColumn = dataTable.Columns["CONOCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO = (string)row[dataColumn];
			// Column "CANTIDAD_MANIFESTADA"
			dataColumn = dataTable.Columns["CANTIDAD_MANIFESTADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MANIFESTADA = (decimal)row[dataColumn];
			// Column "TIPO_BULTO_MANIFESTADO"
			dataColumn = dataTable.Columns["TIPO_BULTO_MANIFESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_BULTO_MANIFESTADO = (string)row[dataColumn];
			// Column "MERCADERIA_MANIFESTADA"
			dataColumn = dataTable.Columns["MERCADERIA_MANIFESTADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA_MANIFESTADA = (string)row[dataColumn];
			// Column "VALOR_NETO"
			dataColumn = dataTable.Columns["VALOR_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_NETO = (decimal)row[dataColumn];
			// Column "VALOR_MONEDA_ID"
			dataColumn = dataTable.Columns["VALOR_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "MONEDA_CADENA_DECIMALES"
			dataColumn = dataTable.Columns["MONEDA_CADENA_DECIMALES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_CADENA_DECIMALES = (string)row[dataColumn];
			// Column "FACTURA_COMERCIAL"
			dataColumn = dataTable.Columns["FACTURA_COMERCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_COMERCIAL = (string)row[dataColumn];
			// Column "FECHA_INGRESO"
			dataColumn = dataTable.Columns["FECHA_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO = (System.DateTime)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "GENERACION_CONFIRMADA"
			dataColumn = dataTable.Columns["GENERACION_CONFIRMADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERACION_CONFIRMADA = (string)row[dataColumn];
			// Column "INGRESO_CONFIRMADO"
			dataColumn = dataTable.Columns["INGRESO_CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_CONFIRMADO = (string)row[dataColumn];
			// Column "NUMERO_COMPROBANTE"
			dataColumn = dataTable.Columns["NUMERO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_COMPROBANTE = (string)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "FCL_LCL"
			dataColumn = dataTable.Columns["FCL_LCL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FCL_LCL = (string)row[dataColumn];
			// Column "MIC_DTA"
			dataColumn = dataTable.Columns["MIC_DTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MIC_DTA = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_INGR_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_INGR_DEP_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_DETALLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("UBICACION", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_BULTOS", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIAS", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LARGO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ANCHO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ALTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TOTAL_ESPACIO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTIBADORES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTIBADORES_FACTURADOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTACARGAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTACARGAS_FACTURADOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USO_BASCULA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USO_BASCULA_FACTURADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USO_GRUA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USO_GRUA_FACTURADO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MANIFESTADA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_BULTO_MANIFESTADO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIA_MANIFESTADA", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VALOR_MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_CADENA_DECIMALES", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FACTURA_COMERCIAL", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERACION_CONFIRMADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FCL_LCL", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MIC_DTA", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
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

				case "ITEMS_INGRESO_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ITEMS_INGRESO_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UBICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_BULTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LARGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANCHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ALTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_ESPACIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTIBADORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTIBADORES_FACTURADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTACARGAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTACARGAS_FACTURADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USO_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_BASCULA_FACTURADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_GRUA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_GRUA_FACTURADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSIGNATARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONOCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_MANIFESTADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_BULTO_MANIFESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIA_MANIFESTADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VALOR_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_CADENA_DECIMALES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_COMERCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "GENERACION_CONFIRMADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INGRESO_CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NUMERO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FCL_LCL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MIC_DTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_INGR_DEP_DET_INFO_COMPLCollection_Base class
}  // End of namespace
