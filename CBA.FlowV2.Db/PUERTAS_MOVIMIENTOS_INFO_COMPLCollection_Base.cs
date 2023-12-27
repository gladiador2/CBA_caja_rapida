// <fileinfo name="PUERTAS_MOVIMIENTOS_INFO_COMPLCollection_Base.cs">
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
	/// The base class for <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLCollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PUERTAS_MOVIMIENTOS_INFO_COMPLCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string BASCULA_IDColumnName = "BASCULA_ID";
		public const string BASCULA_NOMBREColumnName = "BASCULA_NOMBRE";
		public const string TIPO_MOVIMIENTOColumnName = "TIPO_MOVIMIENTO";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_TRACTOColumnName = "CHAPA_TRACTO";
		public const string MOVIMIENTOColumnName = "MOVIMIENTO";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string CONTENEDOR_NUMEROColumnName = "CONTENEDOR_NUMERO";
		public const string CONTENEDOR_TARAColumnName = "CONTENEDOR_TARA";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_DOCUMENTOColumnName = "PERSONA_DOCUMENTO";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string PUERTO_IDColumnName = "PUERTO_ID";
		public const string PUERTO_NOMBREColumnName = "PUERTO_NOMBRE";
		public const string PUERTO_ABREVIATURAColumnName = "PUERTO_ABREVIATURA";
		public const string NUMERO_COMPROBANTEColumnName = "NUMERO_COMPROBANTE";
		public const string IMPORTACION_TERRESTREColumnName = "IMPORTACION_TERRESTRE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string ESTADO_CONTENEDORColumnName = "ESTADO_CONTENEDOR";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string FECHAColumnName = "FECHA";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string NOTA_REMISIONColumnName = "NOTA_REMISION";
		public const string CONFIRMADOColumnName = "CONFIRMADO";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string INTERCAMBIO_EQUIPOS_IDColumnName = "INTERCAMBIO_EQUIPOS_ID";
		public const string USUARIO_CREADOR_IDColumnName = "USUARIO_CREADOR_ID";
		public const string USUARIO_CREADOR_NOMBREColumnName = "USUARIO_CREADOR_NOMBRE";
		public const string USUARIO_CONFIRMACION_IDColumnName = "USUARIO_CONFIRMACION_ID";
		public const string USUARIO_CONFIRMACION_NOMBREColumnName = "USUARIO_CONFIRMACION_NOMBRE";
		public const string FECHA_CONFIRMACIONColumnName = "FECHA_CONFIRMACION";
		public const string BOOKING_BLColumnName = "BOOKING_BL";
		public const string EIR_PISOColumnName = "EIR_PISO";
		public const string EIR_FONDOColumnName = "EIR_FONDO";
		public const string EIR_TECHOColumnName = "EIR_TECHO";
		public const string EIR_PANEL_DERECHOColumnName = "EIR_PANEL_DERECHO";
		public const string EIR_PANEL_IZQUIERDOColumnName = "EIR_PANEL_IZQUIERDO";
		public const string EIR_PUERTAColumnName = "EIR_PUERTA";
		public const string EIR_REFRIGERADOColumnName = "EIR_REFRIGERADO";
		public const string EQUIPO_AUTORIZADO_DET_IDColumnName = "EQUIPO_AUTORIZADO_DET_ID";
		public const string NRO_AUTORIZACIONColumnName = "NRO_AUTORIZACION";
		public const string CODIGO_AUTORIZACIONColumnName = "CODIGO_AUTORIZACION";
		public const string SET_POINTColumnName = "SET_POINT";
		public const string CONTENDOR_CLASEColumnName = "CONTENDOR_CLASE";
		public const string MERCADERIASColumnName = "MERCADERIAS";
		public const string DANADOColumnName = "DANADO";
		public const string DANO_INFORMADOColumnName = "DANO_INFORMADO";
		public const string RECHAZADOColumnName = "RECHAZADO";
		public const string CONOCIMIENTOColumnName = "CONOCIMIENTO";
		public const string TEMPERATURAColumnName = "TEMPERATURA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PUERTAS_MOVIMIENTOS_INFO_COMPLCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PUERTAS_MOVIMIENTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOS_INFO_COMPLRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PUERTAS_MOVIMIENTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PUERTAS_MOVIMIENTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PUERTAS_MOVIMIENTOS_INFO_COMPLRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PUERTAS_MOVIMIENTOS_INFO_COMPLRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects.</returns>
		public PUERTAS_MOVIMIENTOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects that 
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects.</returns>
		public virtual PUERTAS_MOVIMIENTOS_INFO_COMPLRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PUERTAS_MOVIMIENTOS_INFO_COMPL";
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects.</returns>
		protected PUERTAS_MOVIMIENTOS_INFO_COMPLRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects.</returns>
		protected PUERTAS_MOVIMIENTOS_INFO_COMPLRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> objects.</returns>
		protected virtual PUERTAS_MOVIMIENTOS_INFO_COMPLRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int bascula_idColumnIndex = reader.GetOrdinal("BASCULA_ID");
			int bascula_nombreColumnIndex = reader.GetOrdinal("BASCULA_NOMBRE");
			int tipo_movimientoColumnIndex = reader.GetOrdinal("TIPO_MOVIMIENTO");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_tractoColumnIndex = reader.GetOrdinal("CHAPA_TRACTO");
			int movimientoColumnIndex = reader.GetOrdinal("MOVIMIENTO");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int contenedor_numeroColumnIndex = reader.GetOrdinal("CONTENEDOR_NUMERO");
			int contenedor_taraColumnIndex = reader.GetOrdinal("CONTENEDOR_TARA");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_documentoColumnIndex = reader.GetOrdinal("PERSONA_DOCUMENTO");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int puerto_idColumnIndex = reader.GetOrdinal("PUERTO_ID");
			int puerto_nombreColumnIndex = reader.GetOrdinal("PUERTO_NOMBRE");
			int puerto_abreviaturaColumnIndex = reader.GetOrdinal("PUERTO_ABREVIATURA");
			int numero_comprobanteColumnIndex = reader.GetOrdinal("NUMERO_COMPROBANTE");
			int importacion_terrestreColumnIndex = reader.GetOrdinal("IMPORTACION_TERRESTRE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int estado_contenedorColumnIndex = reader.GetOrdinal("ESTADO_CONTENEDOR");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int nota_remisionColumnIndex = reader.GetOrdinal("NOTA_REMISION");
			int confirmadoColumnIndex = reader.GetOrdinal("CONFIRMADO");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int intercambio_equipos_idColumnIndex = reader.GetOrdinal("INTERCAMBIO_EQUIPOS_ID");
			int usuario_creador_idColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_ID");
			int usuario_creador_nombreColumnIndex = reader.GetOrdinal("USUARIO_CREADOR_NOMBRE");
			int usuario_confirmacion_idColumnIndex = reader.GetOrdinal("USUARIO_CONFIRMACION_ID");
			int usuario_confirmacion_nombreColumnIndex = reader.GetOrdinal("USUARIO_CONFIRMACION_NOMBRE");
			int fecha_confirmacionColumnIndex = reader.GetOrdinal("FECHA_CONFIRMACION");
			int booking_blColumnIndex = reader.GetOrdinal("BOOKING_BL");
			int eir_pisoColumnIndex = reader.GetOrdinal("EIR_PISO");
			int eir_fondoColumnIndex = reader.GetOrdinal("EIR_FONDO");
			int eir_techoColumnIndex = reader.GetOrdinal("EIR_TECHO");
			int eir_panel_derechoColumnIndex = reader.GetOrdinal("EIR_PANEL_DERECHO");
			int eir_panel_izquierdoColumnIndex = reader.GetOrdinal("EIR_PANEL_IZQUIERDO");
			int eir_puertaColumnIndex = reader.GetOrdinal("EIR_PUERTA");
			int eir_refrigeradoColumnIndex = reader.GetOrdinal("EIR_REFRIGERADO");
			int equipo_autorizado_det_idColumnIndex = reader.GetOrdinal("EQUIPO_AUTORIZADO_DET_ID");
			int nro_autorizacionColumnIndex = reader.GetOrdinal("NRO_AUTORIZACION");
			int codigo_autorizacionColumnIndex = reader.GetOrdinal("CODIGO_AUTORIZACION");
			int set_pointColumnIndex = reader.GetOrdinal("SET_POINT");
			int contendor_claseColumnIndex = reader.GetOrdinal("CONTENDOR_CLASE");
			int mercaderiasColumnIndex = reader.GetOrdinal("MERCADERIAS");
			int danadoColumnIndex = reader.GetOrdinal("DANADO");
			int dano_informadoColumnIndex = reader.GetOrdinal("DANO_INFORMADO");
			int rechazadoColumnIndex = reader.GetOrdinal("RECHAZADO");
			int conocimientoColumnIndex = reader.GetOrdinal("CONOCIMIENTO");
			int temperaturaColumnIndex = reader.GetOrdinal("TEMPERATURA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PUERTAS_MOVIMIENTOS_INFO_COMPLRow record = new PUERTAS_MOVIMIENTOS_INFO_COMPLRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(bascula_idColumnIndex))
						record.BASCULA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(bascula_idColumnIndex)), 9);
					if(!reader.IsDBNull(bascula_nombreColumnIndex))
						record.BASCULA_NOMBRE = Convert.ToString(reader.GetValue(bascula_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_movimientoColumnIndex))
						record.TIPO_MOVIMIENTO = Convert.ToString(reader.GetValue(tipo_movimientoColumnIndex));
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_tractoColumnIndex))
						record.CHAPA_TRACTO = Convert.ToString(reader.GetValue(chapa_tractoColumnIndex));
					if(!reader.IsDBNull(movimientoColumnIndex))
						record.MOVIMIENTO = Convert.ToString(reader.GetValue(movimientoColumnIndex));
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					record.CONTENEDOR_NUMERO = Convert.ToString(reader.GetValue(contenedor_numeroColumnIndex));
					record.CONTENEDOR_TARA = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_taraColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_documentoColumnIndex))
						record.PERSONA_DOCUMENTO = Convert.ToString(reader.GetValue(persona_documentoColumnIndex));
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(puerto_idColumnIndex))
						record.PUERTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(puerto_idColumnIndex)), 9);
					if(!reader.IsDBNull(puerto_nombreColumnIndex))
						record.PUERTO_NOMBRE = Convert.ToString(reader.GetValue(puerto_nombreColumnIndex));
					if(!reader.IsDBNull(puerto_abreviaturaColumnIndex))
						record.PUERTO_ABREVIATURA = Convert.ToString(reader.GetValue(puerto_abreviaturaColumnIndex));
					if(!reader.IsDBNull(numero_comprobanteColumnIndex))
						record.NUMERO_COMPROBANTE = Convert.ToString(reader.GetValue(numero_comprobanteColumnIndex));
					if(!reader.IsDBNull(importacion_terrestreColumnIndex))
						record.IMPORTACION_TERRESTRE = Convert.ToString(reader.GetValue(importacion_terrestreColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(estado_contenedorColumnIndex))
						record.ESTADO_CONTENEDOR = Convert.ToString(reader.GetValue(estado_contenedorColumnIndex));
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(nota_remisionColumnIndex))
						record.NOTA_REMISION = Convert.ToString(reader.GetValue(nota_remisionColumnIndex));
					record.CONFIRMADO = Convert.ToString(reader.GetValue(confirmadoColumnIndex));
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
					if(!reader.IsDBNull(intercambio_equipos_idColumnIndex))
						record.INTERCAMBIO_EQUIPOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(intercambio_equipos_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_creador_idColumnIndex))
						record.USUARIO_CREADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creador_idColumnIndex)), 9);
					record.USUARIO_CREADOR_NOMBRE = Convert.ToString(reader.GetValue(usuario_creador_nombreColumnIndex));
					if(!reader.IsDBNull(usuario_confirmacion_idColumnIndex))
						record.USUARIO_CONFIRMACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_confirmacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_confirmacion_nombreColumnIndex))
						record.USUARIO_CONFIRMACION_NOMBRE = Convert.ToString(reader.GetValue(usuario_confirmacion_nombreColumnIndex));
					if(!reader.IsDBNull(fecha_confirmacionColumnIndex))
						record.FECHA_CONFIRMACION = Convert.ToDateTime(reader.GetValue(fecha_confirmacionColumnIndex));
					if(!reader.IsDBNull(booking_blColumnIndex))
						record.BOOKING_BL = Convert.ToString(reader.GetValue(booking_blColumnIndex));
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
					if(!reader.IsDBNull(equipo_autorizado_det_idColumnIndex))
						record.EQUIPO_AUTORIZADO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(equipo_autorizado_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_autorizacionColumnIndex))
						record.NRO_AUTORIZACION = Convert.ToString(reader.GetValue(nro_autorizacionColumnIndex));
					if(!reader.IsDBNull(codigo_autorizacionColumnIndex))
						record.CODIGO_AUTORIZACION = Convert.ToString(reader.GetValue(codigo_autorizacionColumnIndex));
					if(!reader.IsDBNull(set_pointColumnIndex))
						record.SET_POINT = Math.Round(Convert.ToDecimal(reader.GetValue(set_pointColumnIndex)), 9);
					if(!reader.IsDBNull(contendor_claseColumnIndex))
						record.CONTENDOR_CLASE = Convert.ToString(reader.GetValue(contendor_claseColumnIndex));
					if(!reader.IsDBNull(mercaderiasColumnIndex))
						record.MERCADERIAS = Convert.ToString(reader.GetValue(mercaderiasColumnIndex));
					if(!reader.IsDBNull(danadoColumnIndex))
						record.DANADO = Convert.ToString(reader.GetValue(danadoColumnIndex));
					if(!reader.IsDBNull(dano_informadoColumnIndex))
						record.DANO_INFORMADO = Convert.ToString(reader.GetValue(dano_informadoColumnIndex));
					if(!reader.IsDBNull(rechazadoColumnIndex))
						record.RECHAZADO = Convert.ToString(reader.GetValue(rechazadoColumnIndex));
					if(!reader.IsDBNull(conocimientoColumnIndex))
						record.CONOCIMIENTO = Convert.ToString(reader.GetValue(conocimientoColumnIndex));
					if(!reader.IsDBNull(temperaturaColumnIndex))
						record.TEMPERATURA = Math.Round(Convert.ToDecimal(reader.GetValue(temperaturaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PUERTAS_MOVIMIENTOS_INFO_COMPLRow[])(recordList.ToArray(typeof(PUERTAS_MOVIMIENTOS_INFO_COMPLRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PUERTAS_MOVIMIENTOS_INFO_COMPLRow"/> object.</returns>
		protected virtual PUERTAS_MOVIMIENTOS_INFO_COMPLRow MapRow(DataRow row)
		{
			PUERTAS_MOVIMIENTOS_INFO_COMPLRow mappedObject = new PUERTAS_MOVIMIENTOS_INFO_COMPLRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "BASCULA_ID"
			dataColumn = dataTable.Columns["BASCULA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BASCULA_ID = (decimal)row[dataColumn];
			// Column "BASCULA_NOMBRE"
			dataColumn = dataTable.Columns["BASCULA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BASCULA_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_MOVIMIENTO"
			dataColumn = dataTable.Columns["TIPO_MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_MOVIMIENTO = (string)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_TRACTO"
			dataColumn = dataTable.Columns["CHAPA_TRACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_TRACTO = (string)row[dataColumn];
			// Column "MOVIMIENTO"
			dataColumn = dataTable.Columns["MOVIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO = (string)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CONTENEDOR_NUMERO"
			dataColumn = dataTable.Columns["CONTENEDOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_NUMERO = (string)row[dataColumn];
			// Column "CONTENEDOR_TARA"
			dataColumn = dataTable.Columns["CONTENEDOR_TARA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_TARA = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_DOCUMENTO"
			dataColumn = dataTable.Columns["PERSONA_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_DOCUMENTO = (string)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PUERTO_ID"
			dataColumn = dataTable.Columns["PUERTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ID = (decimal)row[dataColumn];
			// Column "PUERTO_NOMBRE"
			dataColumn = dataTable.Columns["PUERTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_NOMBRE = (string)row[dataColumn];
			// Column "PUERTO_ABREVIATURA"
			dataColumn = dataTable.Columns["PUERTO_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTO_ABREVIATURA = (string)row[dataColumn];
			// Column "NUMERO_COMPROBANTE"
			dataColumn = dataTable.Columns["NUMERO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_COMPROBANTE = (string)row[dataColumn];
			// Column "IMPORTACION_TERRESTRE"
			dataColumn = dataTable.Columns["IMPORTACION_TERRESTRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTACION_TERRESTRE = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "ESTADO_CONTENEDOR"
			dataColumn = dataTable.Columns["ESTADO_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CONTENEDOR = (string)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "NOTA_REMISION"
			dataColumn = dataTable.Columns["NOTA_REMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_REMISION = (string)row[dataColumn];
			// Column "CONFIRMADO"
			dataColumn = dataTable.Columns["CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONFIRMADO = (string)row[dataColumn];
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
			// Column "INTERCAMBIO_EQUIPOS_ID"
			dataColumn = dataTable.Columns["INTERCAMBIO_EQUIPOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERCAMBIO_EQUIPOS_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_ID"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREADOR_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_CREADOR_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREADOR_NOMBRE = (string)row[dataColumn];
			// Column "USUARIO_CONFIRMACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CONFIRMACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CONFIRMACION_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CONFIRMACION_NOMBRE"
			dataColumn = dataTable.Columns["USUARIO_CONFIRMACION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CONFIRMACION_NOMBRE = (string)row[dataColumn];
			// Column "FECHA_CONFIRMACION"
			dataColumn = dataTable.Columns["FECHA_CONFIRMACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONFIRMACION = (System.DateTime)row[dataColumn];
			// Column "BOOKING_BL"
			dataColumn = dataTable.Columns["BOOKING_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING_BL = (string)row[dataColumn];
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
			// Column "EQUIPO_AUTORIZADO_DET_ID"
			dataColumn = dataTable.Columns["EQUIPO_AUTORIZADO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EQUIPO_AUTORIZADO_DET_ID = (decimal)row[dataColumn];
			// Column "NRO_AUTORIZACION"
			dataColumn = dataTable.Columns["NRO_AUTORIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_AUTORIZACION = (string)row[dataColumn];
			// Column "CODIGO_AUTORIZACION"
			dataColumn = dataTable.Columns["CODIGO_AUTORIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_AUTORIZACION = (string)row[dataColumn];
			// Column "SET_POINT"
			dataColumn = dataTable.Columns["SET_POINT"];
			if(!row.IsNull(dataColumn))
				mappedObject.SET_POINT = (decimal)row[dataColumn];
			// Column "CONTENDOR_CLASE"
			dataColumn = dataTable.Columns["CONTENDOR_CLASE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENDOR_CLASE = (string)row[dataColumn];
			// Column "MERCADERIAS"
			dataColumn = dataTable.Columns["MERCADERIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIAS = (string)row[dataColumn];
			// Column "DANADO"
			dataColumn = dataTable.Columns["DANADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANADO = (string)row[dataColumn];
			// Column "DANO_INFORMADO"
			dataColumn = dataTable.Columns["DANO_INFORMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DANO_INFORMADO = (string)row[dataColumn];
			// Column "RECHAZADO"
			dataColumn = dataTable.Columns["RECHAZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECHAZADO = (string)row[dataColumn];
			// Column "CONOCIMIENTO"
			dataColumn = dataTable.Columns["CONOCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO = (string)row[dataColumn];
			// Column "TEMPERATURA"
			dataColumn = dataTable.Columns["TEMPERATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPERATURA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PUERTAS_MOVIMIENTOS_INFO_COMPL</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PUERTAS_MOVIMIENTOS_INFO_COMPL";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BASCULA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BASCULA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHAPA_TRACTO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOVIMIENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_NUMERO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_TARA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PUERTO_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("IMPORTACION_TERRESTRE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOTA_REMISION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 25;
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
			dataColumn = dataTable.Columns.Add("INTERCAMBIO_EQUIPOS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CREADOR_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CONFIRMACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_CONFIRMACION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_CONFIRMACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BOOKING_BL", typeof(string));
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
			dataColumn.MaxLength = 1500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EIR_REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EQUIPO_AUTORIZADO_DET_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_AUTORIZACION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_AUTORIZACION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SET_POINT", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTENDOR_CLASE", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MERCADERIAS", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DANADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DANO_INFORMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RECHAZADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEMPERATURA", typeof(decimal));
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

				case "BASCULA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BASCULA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_TRACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MOVIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENEDOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_TARA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PUERTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTO_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IMPORTACION_TERRESTRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOTA_REMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
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

				case "INTERCAMBIO_EQUIPOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREADOR_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USUARIO_CONFIRMACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CONFIRMACION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CONFIRMACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "BOOKING_BL":
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

				case "EQUIPO_AUTORIZADO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_AUTORIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_AUTORIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SET_POINT":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONTENDOR_CLASE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DANADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DANO_INFORMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RECHAZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONOCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEMPERATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PUERTAS_MOVIMIENTOS_INFO_COMPLCollection_Base class
}  // End of namespace
