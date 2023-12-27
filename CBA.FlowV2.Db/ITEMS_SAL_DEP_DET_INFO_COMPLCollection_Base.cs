// <fileinfo name="ITEMS_SAL_DEP_DET_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_SAL_DEP_DET_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEM_SALIDA_DEPOSITO_IDColumnName = "ITEM_SALIDA_DEPOSITO_ID";
		public const string ITEMS_INGRESOS_DETALLES_IDColumnName = "ITEMS_INGRESOS_DETALLES_ID";
		public const string CONOCIMIENTOColumnName = "CONOCIMIENTO";
		public const string CONSIGANATARIO_NOMBREColumnName = "CONSIGANATARIO_NOMBRE";
		public const string NUMERO_SALIDAColumnName = "NUMERO_SALIDA";
		public const string FECHA_ENTRADA_PUERTOColumnName = "FECHA_ENTRADA_PUERTO";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string NOMBRE_ENCARGADOColumnName = "NOMBRE_ENCARGADO";
		public const string STATUSColumnName = "STATUS";
		public const string TRANSPORTADORA_PERSONA_IDColumnName = "TRANSPORTADORA_PERSONA_ID";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string TIPO_CAMION_IDColumnName = "TIPO_CAMION_ID";
		public const string TIPO_VEHICULO_NOMBREColumnName = "TIPO_VEHICULO_NOMBRE";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string CONTENDOR_TIPOColumnName = "CONTENDOR_TIPO";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string TIPO_BULTO_IDColumnName = "TIPO_BULTO_ID";
		public const string MERCADERIAColumnName = "MERCADERIA";
		public const string FECHA_SALIDA_PUERTOColumnName = "FECHA_SALIDA_PUERTO";
		public const string CONFIRMADOColumnName = "CONFIRMADO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_CONFIRMACIONColumnName = "FECHA_CONFIRMACION";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string TIPO_RETIROColumnName = "TIPO_RETIRO";
		public const string SEMANAColumnName = "SEMANA";
		public const string FECHA_ENTRADA_DEPOSITOColumnName = "FECHA_ENTRADA_DEPOSITO";
		public const string FECHA_SALIDA_DEPOSITOColumnName = "FECHA_SALIDA_DEPOSITO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_SAL_DEP_DET_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_SAL_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual ITEMS_SAL_DEP_DET_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_SAL_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_SAL_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_SAL_DEP_DET_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_SAL_DEP_DET_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		public ITEMS_SAL_DEP_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		public virtual ITEMS_SAL_DEP_DET_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_SAL_DEP_DET_INFO_COMPL";
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
		/// <returns>An array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		protected ITEMS_SAL_DEP_DET_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		protected ITEMS_SAL_DEP_DET_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> objects.</returns>
		protected virtual ITEMS_SAL_DEP_DET_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int item_salida_deposito_idColumnIndex = reader.GetOrdinal("ITEM_SALIDA_DEPOSITO_ID");
			int items_ingresos_detalles_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESOS_DETALLES_ID");
			int conocimientoColumnIndex = reader.GetOrdinal("CONOCIMIENTO");
			int consiganatario_nombreColumnIndex = reader.GetOrdinal("CONSIGANATARIO_NOMBRE");
			int numero_salidaColumnIndex = reader.GetOrdinal("NUMERO_SALIDA");
			int fecha_entrada_puertoColumnIndex = reader.GetOrdinal("FECHA_ENTRADA_PUERTO");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int nombre_encargadoColumnIndex = reader.GetOrdinal("NOMBRE_ENCARGADO");
			int statusColumnIndex = reader.GetOrdinal("STATUS");
			int transportadora_persona_idColumnIndex = reader.GetOrdinal("TRANSPORTADORA_PERSONA_ID");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int tipo_camion_idColumnIndex = reader.GetOrdinal("TIPO_CAMION_ID");
			int tipo_vehiculo_nombreColumnIndex = reader.GetOrdinal("TIPO_VEHICULO_NOMBRE");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int contendor_tipoColumnIndex = reader.GetOrdinal("CONTENDOR_TIPO");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int tipo_bulto_idColumnIndex = reader.GetOrdinal("TIPO_BULTO_ID");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");
			int fecha_salida_puertoColumnIndex = reader.GetOrdinal("FECHA_SALIDA_PUERTO");
			int confirmadoColumnIndex = reader.GetOrdinal("CONFIRMADO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_confirmacionColumnIndex = reader.GetOrdinal("FECHA_CONFIRMACION");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int tipo_retiroColumnIndex = reader.GetOrdinal("TIPO_RETIRO");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");
			int fecha_entrada_depositoColumnIndex = reader.GetOrdinal("FECHA_ENTRADA_DEPOSITO");
			int fecha_salida_depositoColumnIndex = reader.GetOrdinal("FECHA_SALIDA_DEPOSITO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_SAL_DEP_DET_INFO_COMPLRow record = new ITEMS_SAL_DEP_DET_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(item_salida_deposito_idColumnIndex))
						record.ITEM_SALIDA_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(item_salida_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingresos_detalles_idColumnIndex))
						record.ITEMS_INGRESOS_DETALLES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingresos_detalles_idColumnIndex)), 9);
					if(!reader.IsDBNull(conocimientoColumnIndex))
						record.CONOCIMIENTO = Convert.ToString(reader.GetValue(conocimientoColumnIndex));
					if(!reader.IsDBNull(consiganatario_nombreColumnIndex))
						record.CONSIGANATARIO_NOMBRE = Convert.ToString(reader.GetValue(consiganatario_nombreColumnIndex));
					if(!reader.IsDBNull(numero_salidaColumnIndex))
						record.NUMERO_SALIDA = Convert.ToString(reader.GetValue(numero_salidaColumnIndex));
					if(!reader.IsDBNull(fecha_entrada_puertoColumnIndex))
						record.FECHA_ENTRADA_PUERTO = Convert.ToDateTime(reader.GetValue(fecha_entrada_puertoColumnIndex));
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(nombre_encargadoColumnIndex))
						record.NOMBRE_ENCARGADO = Convert.ToString(reader.GetValue(nombre_encargadoColumnIndex));
					if(!reader.IsDBNull(statusColumnIndex))
						record.STATUS = Convert.ToString(reader.GetValue(statusColumnIndex));
					if(!reader.IsDBNull(transportadora_persona_idColumnIndex))
						record.TRANSPORTADORA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transportadora_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_camion_idColumnIndex))
						record.TIPO_CAMION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_camion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_vehiculo_nombreColumnIndex))
						record.TIPO_VEHICULO_NOMBRE = Convert.ToString(reader.GetValue(tipo_vehiculo_nombreColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(contenedor_numeroColumnIndex))
						record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					if(!reader.IsDBNull(contendor_tipoColumnIndex))
						record.CONTENDOR_TIPO = Convert.ToString(reader.GetValue(contendor_tipoColumnIndex));
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_bulto_idColumnIndex))
						record.TIPO_BULTO_ID = Convert.ToString(reader.GetValue(tipo_bulto_idColumnIndex));
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));
					if(!reader.IsDBNull(fecha_salida_puertoColumnIndex))
						record.FECHA_SALIDA_PUERTO = Convert.ToDateTime(reader.GetValue(fecha_salida_puertoColumnIndex));
					if(!reader.IsDBNull(confirmadoColumnIndex))
						record.CONFIRMADO = Convert.ToString(reader.GetValue(confirmadoColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fecha_confirmacionColumnIndex))
						record.FECHA_CONFIRMACION = Convert.ToDateTime(reader.GetValue(fecha_confirmacionColumnIndex));
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
					if(!reader.IsDBNull(tipo_retiroColumnIndex))
						record.TIPO_RETIRO = Convert.ToString(reader.GetValue(tipo_retiroColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_entrada_depositoColumnIndex))
						record.FECHA_ENTRADA_DEPOSITO = Convert.ToDateTime(reader.GetValue(fecha_entrada_depositoColumnIndex));
					if(!reader.IsDBNull(fecha_salida_depositoColumnIndex))
						record.FECHA_SALIDA_DEPOSITO = Convert.ToDateTime(reader.GetValue(fecha_salida_depositoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_SAL_DEP_DET_INFO_COMPLRow[])(recordList.ToArray(typeof(ITEMS_SAL_DEP_DET_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_SAL_DEP_DET_INFO_COMPLRow"/> object.</returns>
		protected virtual ITEMS_SAL_DEP_DET_INFO_COMPLRow MapRow(DataRow row)
		{
			ITEMS_SAL_DEP_DET_INFO_COMPLRow mappedObject = new ITEMS_SAL_DEP_DET_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEM_SALIDA_DEPOSITO_ID"
			dataColumn = dataTable.Columns["ITEM_SALIDA_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEM_SALIDA_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESOS_DETALLES_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESOS_DETALLES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESOS_DETALLES_ID = (decimal)row[dataColumn];
			// Column "CONOCIMIENTO"
			dataColumn = dataTable.Columns["CONOCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO = (string)row[dataColumn];
			// Column "CONSIGANATARIO_NOMBRE"
			dataColumn = dataTable.Columns["CONSIGANATARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGANATARIO_NOMBRE = (string)row[dataColumn];
			// Column "NUMERO_SALIDA"
			dataColumn = dataTable.Columns["NUMERO_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_SALIDA = (string)row[dataColumn];
			// Column "FECHA_ENTRADA_PUERTO"
			dataColumn = dataTable.Columns["FECHA_ENTRADA_PUERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTRADA_PUERTO = (System.DateTime)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "NOMBRE_ENCARGADO"
			dataColumn = dataTable.Columns["NOMBRE_ENCARGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_ENCARGADO = (string)row[dataColumn];
			// Column "STATUS"
			dataColumn = dataTable.Columns["STATUS"];
			if(!row.IsNull(dataColumn))
				mappedObject.STATUS = (string)row[dataColumn];
			// Column "TRANSPORTADORA_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSPORTADORA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_CAMION_ID"
			dataColumn = dataTable.Columns["TIPO_CAMION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CAMION_ID = (decimal)row[dataColumn];
			// Column "TIPO_VEHICULO_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_VEHICULO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_VEHICULO_NOMBRE = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "CONTENDOR_TIPO"
			dataColumn = dataTable.Columns["CONTENDOR_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENDOR_TIPO = (string)row[dataColumn];
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "TIPO_BULTO_ID"
			dataColumn = dataTable.Columns["TIPO_BULTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_BULTO_ID = (string)row[dataColumn];
			// Column "MERCADERIA"
			dataColumn = dataTable.Columns["MERCADERIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA = (string)row[dataColumn];
			// Column "FECHA_SALIDA_PUERTO"
			dataColumn = dataTable.Columns["FECHA_SALIDA_PUERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA_PUERTO = (System.DateTime)row[dataColumn];
			// Column "CONFIRMADO"
			dataColumn = dataTable.Columns["CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONFIRMADO = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_CONFIRMACION"
			dataColumn = dataTable.Columns["FECHA_CONFIRMACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONFIRMACION = (System.DateTime)row[dataColumn];
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
			// Column "TIPO_RETIRO"
			dataColumn = dataTable.Columns["TIPO_RETIRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_RETIRO = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			// Column "FECHA_ENTRADA_DEPOSITO"
			dataColumn = dataTable.Columns["FECHA_ENTRADA_DEPOSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTRADA_DEPOSITO = (System.DateTime)row[dataColumn];
			// Column "FECHA_SALIDA_DEPOSITO"
			dataColumn = dataTable.Columns["FECHA_SALIDA_DEPOSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA_DEPOSITO = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_SAL_DEP_DET_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_SAL_DEP_DET_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEM_SALIDA_DEPOSITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESOS_DETALLES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONSIGANATARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_SALIDA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ENTRADA_PUERTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_ENCARGADO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("STATUS", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CAMION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_VEHICULO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENDOR_TIPO", typeof(string));
			dataColumn.MaxLength = 56;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_BULTO_ID", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA_PUERTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CONFIRMACION", typeof(System.DateTime));
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
			dataColumn = dataTable.Columns.Add("TIPO_RETIRO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ENTRADA_DEPOSITO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA_DEPOSITO", typeof(System.DateTime));
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

				case "ITEM_SALIDA_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ITEMS_INGRESOS_DETALLES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONOCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONSIGANATARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ENTRADA_PUERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_ENCARGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "STATUS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CAMION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_VEHICULO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENDOR_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_BULTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_SALIDA_PUERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CONFIRMACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
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

				case "TIPO_RETIRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ENTRADA_DEPOSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_SALIDA_DEPOSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_SAL_DEP_DET_INFO_COMPLCollection_Base class
}  // End of namespace
