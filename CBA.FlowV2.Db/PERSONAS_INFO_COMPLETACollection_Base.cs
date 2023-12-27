// <fileinfo name="PERSONAS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="PERSONAS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PERSONAS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string ENTIDAD_NOMBREColumnName = "ENTIDAD_NOMBRE";
		public const string FISICOColumnName = "FISICO";
		public const string MAYORISTAColumnName = "MAYORISTA";
		public const string TRATAMIENTO_IDColumnName = "TRATAMIENTO_ID";
		public const string TRATAMIENTOColumnName = "TRATAMIENTO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string APELLIDOColumnName = "APELLIDO";
		public const string NOMBRE_COMPLETOColumnName = "NOMBRE_COMPLETO";
		public const string NOMBRE_FANTASIAColumnName = "NOMBRE_FANTASIA";
		public const string GENEROColumnName = "GENERO";
		public const string RUCColumnName = "RUC";
		public const string NACIMIENTOColumnName = "NACIMIENTO";
		public const string TIPO_DOCUMENTO_IDENTIDAD_IDColumnName = "TIPO_DOCUMENTO_IDENTIDAD_ID";
		public const string NUMERO_DOCUMENTOColumnName = "NUMERO_DOCUMENTO";
		public const string CODIGO_EXTERNOColumnName = "CODIGO_EXTERNO";
		public const string PAIS_NACIONALIDAD_IDColumnName = "PAIS_NACIONALIDAD_ID";
		public const string PAIS_NACIONALIDADColumnName = "PAIS_NACIONALIDAD";
		public const string PAIS_RESIDENCIA_IDColumnName = "PAIS_RESIDENCIA_ID";
		public const string PAIS_RESIDENCIAColumnName = "PAIS_RESIDENCIA";
		public const string EN_INFORMCONFColumnName = "EN_INFORMCONF";
		public const string FECHA_MODIFICACION_INFORMCONFColumnName = "FECHA_MODIFICACION_INFORMCONF";
		public const string FECHA_ULTIMA_VISITAColumnName = "FECHA_ULTIMA_VISITA";
		public const string EN_JUDICIALColumnName = "EN_JUDICIAL";
		public const string FECHA_MODIFICACION_JUDICIALColumnName = "FECHA_MODIFICACION_JUDICIAL";
		public const string FECHA_ULTIMA_ACTUALIZAC_DATOSColumnName = "FECHA_ULTIMA_ACTUALIZAC_DATOS";
		public const string ES_CLIENTEColumnName = "ES_CLIENTE";
		public const string ES_CONTRIBUYENTEColumnName = "ES_CONTRIBUYENTE";
		public const string ABOGADO_IDColumnName = "ABOGADO_ID";
		public const string ABOGADO_NOMBREColumnName = "ABOGADO_NOMBRE";
		public const string PROFESION_IDColumnName = "PROFESION_ID";
		public const string PROFESION_NOMBREColumnName = "PROFESION_NOMBRE";
		public const string DEPARTAMENTO1_IDColumnName = "DEPARTAMENTO1_ID";
		public const string DEPARTAMENT01_NOMBREColumnName = "DEPARTAMENT01_NOMBRE";
		public const string CIUDAD1_IDColumnName = "CIUDAD1_ID";
		public const string CIUDAD1_NOMBREColumnName = "CIUDAD1_NOMBRE";
		public const string BARRIO1_IDColumnName = "BARRIO1_ID";
		public const string BARRIO1_NOMBREColumnName = "BARRIO1_NOMBRE";
		public const string CALLE1ColumnName = "CALLE1";
		public const string CODIGO_POSTAL1ColumnName = "CODIGO_POSTAL1";
		public const string DEPARTAMENTO2_IDColumnName = "DEPARTAMENTO2_ID";
		public const string DEPARTAMENTO2_NOMBREColumnName = "DEPARTAMENTO2_NOMBRE";
		public const string CIUDAD2_IDColumnName = "CIUDAD2_ID";
		public const string CIUDAD2_NOMBREColumnName = "CIUDAD2_NOMBRE";
		public const string BARRIO2_IDColumnName = "BARRIO2_ID";
		public const string BARRIO2_NOMBREColumnName = "BARRIO2_NOMBRE";
		public const string CALLE2ColumnName = "CALLE2";
		public const string CODIGO_POSTAL2ColumnName = "CODIGO_POSTAL2";
		public const string TELEFONO1ColumnName = "TELEFONO1";
		public const string TELEFONO2ColumnName = "TELEFONO2";
		public const string TELEFONO3ColumnName = "TELEFONO3";
		public const string TELEFONO4ColumnName = "TELEFONO4";
		public const string EMAIL1ColumnName = "EMAIL1";
		public const string EMAIL2ColumnName = "EMAIL2";
		public const string EMAIL3ColumnName = "EMAIL3";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string RUBRO_NOMBREColumnName = "RUBRO_NOMBRE";
		public const string POSEE_UNIPERSONALColumnName = "POSEE_UNIPERSONAL";
		public const string EMPRESA_NOMBRE_FANTASIAColumnName = "EMPRESA_NOMBRE_FANTASIA";
		public const string EMPRESA_FUNDACIONColumnName = "EMPRESA_FUNDACION";
		public const string EMPRESA_PERSONA_CONTACTOColumnName = "EMPRESA_PERSONA_CONTACTO";
		public const string EMPRESA_TELEFONO_CONTACTOColumnName = "EMPRESA_TELEFONO_CONTACTO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string OPERA_CREDITOColumnName = "OPERA_CREDITO";
		public const string CONDICION_HABITUAL_PAGO_IDColumnName = "CONDICION_HABITUAL_PAGO_ID";
		public const string MONEDA_LIMITE_CREDITO_IDColumnName = "MONEDA_LIMITE_CREDITO_ID";
		public const string MONEDA_LIMITE_CREDITOColumnName = "MONEDA_LIMITE_CREDITO";
		public const string CONTADOR_CREDITO_ACTUALColumnName = "CONTADOR_CREDITO_ACTUAL";
		public const string VENDEDOR_HABITUAL_IDColumnName = "VENDEDOR_HABITUAL_ID";
		public const string COBRADOR_HABITUAL_IDColumnName = "COBRADOR_HABITUAL_ID";
		public const string DEPARTAMENTO_COBRANZA_IDColumnName = "DEPARTAMENTO_COBRANZA_ID";
		public const string DEPARTAMENTO_COBRANZAColumnName = "DEPARTAMENTO_COBRANZA";
		public const string CIUDAD_COBRANZA_IDColumnName = "CIUDAD_COBRANZA_ID";
		public const string CIUDAD_COBRANZAColumnName = "CIUDAD_COBRANZA";
		public const string BARRIO_COBRANZA_IDColumnName = "BARRIO_COBRANZA_ID";
		public const string BARRIO_COBRANZAColumnName = "BARRIO_COBRANZA";
		public const string CALLE_COBRANZAColumnName = "CALLE_COBRANZA";
		public const string CODIGO_POSTAL_COBRANZAColumnName = "CODIGO_POSTAL_COBRANZA";
		public const string TELEFONO_COBRANZA1ColumnName = "TELEFONO_COBRANZA1";
		public const string TELEFONO_COBRANZA2ColumnName = "TELEFONO_COBRANZA2";
		public const string CONYUGE_NOMBREColumnName = "CONYUGE_NOMBRE";
		public const string CONYUGE_APELLIDOColumnName = "CONYUGE_APELLIDO";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string DOCUMENTACION_ESTADOColumnName = "DOCUMENTACION_ESTADO";
		public const string AGENTE_RETENCIONColumnName = "AGENTE_RETENCION";
		public const string BANDERA_RETENCIONColumnName = "BANDERA_RETENCION";
		public const string ESTADOColumnName = "ESTADO";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string LATITUD1ColumnName = "LATITUD1";
		public const string LONGITUD1ColumnName = "LONGITUD1";
		public const string LATITUD2ColumnName = "LATITUD2";
		public const string LONGITUD2ColumnName = "LONGITUD2";
		public const string LATITUD_COBRANZAColumnName = "LATITUD_COBRANZA";
		public const string LONGITUD_COBRANZAColumnName = "LONGITUD_COBRANZA";
		public const string NIVEL_CREDITO_IDColumnName = "NIVEL_CREDITO_ID";
		public const string NIVEL_CREDITOColumnName = "NIVEL_CREDITO";
		public const string GRUPO_SANGUINEOColumnName = "GRUPO_SANGUINEO";
		public const string ESTADO_CIVIL_IDColumnName = "ESTADO_CIVIL_ID";
		public const string PERSONA_ID_CONYUGEColumnName = "PERSONA_ID_CONYUGE";
		public const string NUMERO_HIJOSColumnName = "NUMERO_HIJOS";
		public const string ZONA_COBRANZA_IDColumnName = "ZONA_COBRANZA_ID";
		public const string ZONA_NOMBREColumnName = "ZONA_NOMBRE";
		public const string ZONA_ABREVIATURAColumnName = "ZONA_ABREVIATURA";
		public const string ESTADO_CIVIL_DESCRIPCIONColumnName = "ESTADO_CIVIL_DESCRIPCION";
		public const string TIPO_EMPLEOColumnName = "TIPO_EMPLEO";
		public const string SEPARACION_BIENESColumnName = "SEPARACION_BIENES";
		public const string PORC_DESCUENTO_AUTOMATICOColumnName = "PORC_DESCUENTO_AUTOMATICO";
		public const string PERSONA_CALIFICAION_IDColumnName = "PERSONA_CALIFICAION_ID";
		public const string TIPO_CLIENTE_IDColumnName = "TIPO_CLIENTE_ID";
		public const string TIPO_CLIENTES_NOMBREColumnName = "TIPO_CLIENTES_NOMBRE";
		public const string ESTADO_MOROSIDAD_IDColumnName = "ESTADO_MOROSIDAD_ID";
		public const string ESTADO_MOROSIDAD_NOMBREColumnName = "ESTADO_MOROSIDAD_NOMBRE";
		public const string DESCRIPCION_CALIFICACIONColumnName = "DESCRIPCION_CALIFICACION";
		public const string MODIFICABLEColumnName = "MODIFICABLE";
		public const string NRO_TARJETA_RED_PAGOColumnName = "NRO_TARJETA_RED_PAGO";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string VENDEDOR_HABITUAL_NOMBREColumnName = "VENDEDOR_HABITUAL_NOMBRE";
		public const string VENDEDOR_HABITUAL_CODIGOColumnName = "VENDEDOR_HABITUAL_CODIGO";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string PERSONA_PADRE_IDColumnName = "PERSONA_PADRE_ID";
		public const string PERSONA_PADRE_CODIGOColumnName = "PERSONA_PADRE_CODIGO";
		public const string LISTA_PRECIOS_IDColumnName = "LISTA_PRECIOS_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PERSONAS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual PERSONAS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PERSONAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PERSONAS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PERSONAS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PERSONAS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		public PERSONAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		public virtual PERSONAS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PERSONAS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		protected PERSONAS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		protected PERSONAS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PERSONAS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual PERSONAS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int entidad_nombreColumnIndex = reader.GetOrdinal("ENTIDAD_NOMBRE");
			int fisicoColumnIndex = reader.GetOrdinal("FISICO");
			int mayoristaColumnIndex = reader.GetOrdinal("MAYORISTA");
			int tratamiento_idColumnIndex = reader.GetOrdinal("TRATAMIENTO_ID");
			int tratamientoColumnIndex = reader.GetOrdinal("TRATAMIENTO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int apellidoColumnIndex = reader.GetOrdinal("APELLIDO");
			int nombre_completoColumnIndex = reader.GetOrdinal("NOMBRE_COMPLETO");
			int nombre_fantasiaColumnIndex = reader.GetOrdinal("NOMBRE_FANTASIA");
			int generoColumnIndex = reader.GetOrdinal("GENERO");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int nacimientoColumnIndex = reader.GetOrdinal("NACIMIENTO");
			int tipo_documento_identidad_idColumnIndex = reader.GetOrdinal("TIPO_DOCUMENTO_IDENTIDAD_ID");
			int numero_documentoColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO");
			int codigo_externoColumnIndex = reader.GetOrdinal("CODIGO_EXTERNO");
			int pais_nacionalidad_idColumnIndex = reader.GetOrdinal("PAIS_NACIONALIDAD_ID");
			int pais_nacionalidadColumnIndex = reader.GetOrdinal("PAIS_NACIONALIDAD");
			int pais_residencia_idColumnIndex = reader.GetOrdinal("PAIS_RESIDENCIA_ID");
			int pais_residenciaColumnIndex = reader.GetOrdinal("PAIS_RESIDENCIA");
			int en_informconfColumnIndex = reader.GetOrdinal("EN_INFORMCONF");
			int fecha_modificacion_informconfColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION_INFORMCONF");
			int fecha_ultima_visitaColumnIndex = reader.GetOrdinal("FECHA_ULTIMA_VISITA");
			int en_judicialColumnIndex = reader.GetOrdinal("EN_JUDICIAL");
			int fecha_modificacion_judicialColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION_JUDICIAL");
			int fecha_ultima_actualizac_datosColumnIndex = reader.GetOrdinal("FECHA_ULTIMA_ACTUALIZAC_DATOS");
			int es_clienteColumnIndex = reader.GetOrdinal("ES_CLIENTE");
			int es_contribuyenteColumnIndex = reader.GetOrdinal("ES_CONTRIBUYENTE");
			int abogado_idColumnIndex = reader.GetOrdinal("ABOGADO_ID");
			int abogado_nombreColumnIndex = reader.GetOrdinal("ABOGADO_NOMBRE");
			int profesion_idColumnIndex = reader.GetOrdinal("PROFESION_ID");
			int profesion_nombreColumnIndex = reader.GetOrdinal("PROFESION_NOMBRE");
			int departamento1_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO1_ID");
			int departament01_nombreColumnIndex = reader.GetOrdinal("DEPARTAMENT01_NOMBRE");
			int ciudad1_idColumnIndex = reader.GetOrdinal("CIUDAD1_ID");
			int ciudad1_nombreColumnIndex = reader.GetOrdinal("CIUDAD1_NOMBRE");
			int barrio1_idColumnIndex = reader.GetOrdinal("BARRIO1_ID");
			int barrio1_nombreColumnIndex = reader.GetOrdinal("BARRIO1_NOMBRE");
			int calle1ColumnIndex = reader.GetOrdinal("CALLE1");
			int codigo_postal1ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL1");
			int departamento2_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_ID");
			int departamento2_nombreColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_NOMBRE");
			int ciudad2_idColumnIndex = reader.GetOrdinal("CIUDAD2_ID");
			int ciudad2_nombreColumnIndex = reader.GetOrdinal("CIUDAD2_NOMBRE");
			int barrio2_idColumnIndex = reader.GetOrdinal("BARRIO2_ID");
			int barrio2_nombreColumnIndex = reader.GetOrdinal("BARRIO2_NOMBRE");
			int calle2ColumnIndex = reader.GetOrdinal("CALLE2");
			int codigo_postal2ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL2");
			int telefono1ColumnIndex = reader.GetOrdinal("TELEFONO1");
			int telefono2ColumnIndex = reader.GetOrdinal("TELEFONO2");
			int telefono3ColumnIndex = reader.GetOrdinal("TELEFONO3");
			int telefono4ColumnIndex = reader.GetOrdinal("TELEFONO4");
			int email1ColumnIndex = reader.GetOrdinal("EMAIL1");
			int email2ColumnIndex = reader.GetOrdinal("EMAIL2");
			int email3ColumnIndex = reader.GetOrdinal("EMAIL3");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int rubro_nombreColumnIndex = reader.GetOrdinal("RUBRO_NOMBRE");
			int posee_unipersonalColumnIndex = reader.GetOrdinal("POSEE_UNIPERSONAL");
			int empresa_nombre_fantasiaColumnIndex = reader.GetOrdinal("EMPRESA_NOMBRE_FANTASIA");
			int empresa_fundacionColumnIndex = reader.GetOrdinal("EMPRESA_FUNDACION");
			int empresa_persona_contactoColumnIndex = reader.GetOrdinal("EMPRESA_PERSONA_CONTACTO");
			int empresa_telefono_contactoColumnIndex = reader.GetOrdinal("EMPRESA_TELEFONO_CONTACTO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int opera_creditoColumnIndex = reader.GetOrdinal("OPERA_CREDITO");
			int condicion_habitual_pago_idColumnIndex = reader.GetOrdinal("CONDICION_HABITUAL_PAGO_ID");
			int moneda_limite_credito_idColumnIndex = reader.GetOrdinal("MONEDA_LIMITE_CREDITO_ID");
			int moneda_limite_creditoColumnIndex = reader.GetOrdinal("MONEDA_LIMITE_CREDITO");
			int contador_credito_actualColumnIndex = reader.GetOrdinal("CONTADOR_CREDITO_ACTUAL");
			int vendedor_habitual_idColumnIndex = reader.GetOrdinal("VENDEDOR_HABITUAL_ID");
			int cobrador_habitual_idColumnIndex = reader.GetOrdinal("COBRADOR_HABITUAL_ID");
			int departamento_cobranza_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_COBRANZA_ID");
			int departamento_cobranzaColumnIndex = reader.GetOrdinal("DEPARTAMENTO_COBRANZA");
			int ciudad_cobranza_idColumnIndex = reader.GetOrdinal("CIUDAD_COBRANZA_ID");
			int ciudad_cobranzaColumnIndex = reader.GetOrdinal("CIUDAD_COBRANZA");
			int barrio_cobranza_idColumnIndex = reader.GetOrdinal("BARRIO_COBRANZA_ID");
			int barrio_cobranzaColumnIndex = reader.GetOrdinal("BARRIO_COBRANZA");
			int calle_cobranzaColumnIndex = reader.GetOrdinal("CALLE_COBRANZA");
			int codigo_postal_cobranzaColumnIndex = reader.GetOrdinal("CODIGO_POSTAL_COBRANZA");
			int telefono_cobranza1ColumnIndex = reader.GetOrdinal("TELEFONO_COBRANZA1");
			int telefono_cobranza2ColumnIndex = reader.GetOrdinal("TELEFONO_COBRANZA2");
			int conyuge_nombreColumnIndex = reader.GetOrdinal("CONYUGE_NOMBRE");
			int conyuge_apellidoColumnIndex = reader.GetOrdinal("CONYUGE_APELLIDO");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int documentacion_estadoColumnIndex = reader.GetOrdinal("DOCUMENTACION_ESTADO");
			int agente_retencionColumnIndex = reader.GetOrdinal("AGENTE_RETENCION");
			int bandera_retencionColumnIndex = reader.GetOrdinal("BANDERA_RETENCION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int latitud1ColumnIndex = reader.GetOrdinal("LATITUD1");
			int longitud1ColumnIndex = reader.GetOrdinal("LONGITUD1");
			int latitud2ColumnIndex = reader.GetOrdinal("LATITUD2");
			int longitud2ColumnIndex = reader.GetOrdinal("LONGITUD2");
			int latitud_cobranzaColumnIndex = reader.GetOrdinal("LATITUD_COBRANZA");
			int longitud_cobranzaColumnIndex = reader.GetOrdinal("LONGITUD_COBRANZA");
			int nivel_credito_idColumnIndex = reader.GetOrdinal("NIVEL_CREDITO_ID");
			int nivel_creditoColumnIndex = reader.GetOrdinal("NIVEL_CREDITO");
			int grupo_sanguineoColumnIndex = reader.GetOrdinal("GRUPO_SANGUINEO");
			int estado_civil_idColumnIndex = reader.GetOrdinal("ESTADO_CIVIL_ID");
			int persona_id_conyugeColumnIndex = reader.GetOrdinal("PERSONA_ID_CONYUGE");
			int numero_hijosColumnIndex = reader.GetOrdinal("NUMERO_HIJOS");
			int zona_cobranza_idColumnIndex = reader.GetOrdinal("ZONA_COBRANZA_ID");
			int zona_nombreColumnIndex = reader.GetOrdinal("ZONA_NOMBRE");
			int zona_abreviaturaColumnIndex = reader.GetOrdinal("ZONA_ABREVIATURA");
			int estado_civil_descripcionColumnIndex = reader.GetOrdinal("ESTADO_CIVIL_DESCRIPCION");
			int tipo_empleoColumnIndex = reader.GetOrdinal("TIPO_EMPLEO");
			int separacion_bienesColumnIndex = reader.GetOrdinal("SEPARACION_BIENES");
			int porc_descuento_automaticoColumnIndex = reader.GetOrdinal("PORC_DESCUENTO_AUTOMATICO");
			int persona_calificaion_idColumnIndex = reader.GetOrdinal("PERSONA_CALIFICAION_ID");
			int tipo_cliente_idColumnIndex = reader.GetOrdinal("TIPO_CLIENTE_ID");
			int tipo_clientes_nombreColumnIndex = reader.GetOrdinal("TIPO_CLIENTES_NOMBRE");
			int estado_morosidad_idColumnIndex = reader.GetOrdinal("ESTADO_MOROSIDAD_ID");
			int estado_morosidad_nombreColumnIndex = reader.GetOrdinal("ESTADO_MOROSIDAD_NOMBRE");
			int descripcion_calificacionColumnIndex = reader.GetOrdinal("DESCRIPCION_CALIFICACION");
			int modificableColumnIndex = reader.GetOrdinal("MODIFICABLE");
			int nro_tarjeta_red_pagoColumnIndex = reader.GetOrdinal("NRO_TARJETA_RED_PAGO");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int vendedor_habitual_nombreColumnIndex = reader.GetOrdinal("VENDEDOR_HABITUAL_NOMBRE");
			int vendedor_habitual_codigoColumnIndex = reader.GetOrdinal("VENDEDOR_HABITUAL_CODIGO");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int persona_padre_idColumnIndex = reader.GetOrdinal("PERSONA_PADRE_ID");
			int persona_padre_codigoColumnIndex = reader.GetOrdinal("PERSONA_PADRE_CODIGO");
			int lista_precios_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PERSONAS_INFO_COMPLETARow record = new PERSONAS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(entidad_nombreColumnIndex))
						record.ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(entidad_nombreColumnIndex));
					record.FISICO = Convert.ToString(reader.GetValue(fisicoColumnIndex));
					record.MAYORISTA = Convert.ToString(reader.GetValue(mayoristaColumnIndex));
					if(!reader.IsDBNull(tratamiento_idColumnIndex))
						record.TRATAMIENTO_ID = Convert.ToString(reader.GetValue(tratamiento_idColumnIndex));
					if(!reader.IsDBNull(tratamientoColumnIndex))
						record.TRATAMIENTO = Convert.ToString(reader.GetValue(tratamientoColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(apellidoColumnIndex))
						record.APELLIDO = Convert.ToString(reader.GetValue(apellidoColumnIndex));
					if(!reader.IsDBNull(nombre_completoColumnIndex))
						record.NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(nombre_completoColumnIndex));
					if(!reader.IsDBNull(nombre_fantasiaColumnIndex))
						record.NOMBRE_FANTASIA = Convert.ToString(reader.GetValue(nombre_fantasiaColumnIndex));
					if(!reader.IsDBNull(generoColumnIndex))
						record.GENERO = Convert.ToString(reader.GetValue(generoColumnIndex));
					if(!reader.IsDBNull(rucColumnIndex))
						record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
					if(!reader.IsDBNull(nacimientoColumnIndex))
						record.NACIMIENTO = Convert.ToDateTime(reader.GetValue(nacimientoColumnIndex));
					if(!reader.IsDBNull(tipo_documento_identidad_idColumnIndex))
						record.TIPO_DOCUMENTO_IDENTIDAD_ID = Convert.ToString(reader.GetValue(tipo_documento_identidad_idColumnIndex));
					if(!reader.IsDBNull(numero_documentoColumnIndex))
						record.NUMERO_DOCUMENTO = Convert.ToString(reader.GetValue(numero_documentoColumnIndex));
					if(!reader.IsDBNull(codigo_externoColumnIndex))
						record.CODIGO_EXTERNO = Convert.ToString(reader.GetValue(codigo_externoColumnIndex));
					if(!reader.IsDBNull(pais_nacionalidad_idColumnIndex))
						record.PAIS_NACIONALIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_nacionalidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(pais_nacionalidadColumnIndex))
						record.PAIS_NACIONALIDAD = Convert.ToString(reader.GetValue(pais_nacionalidadColumnIndex));
					if(!reader.IsDBNull(pais_residencia_idColumnIndex))
						record.PAIS_RESIDENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_residencia_idColumnIndex)), 9);
					if(!reader.IsDBNull(pais_residenciaColumnIndex))
						record.PAIS_RESIDENCIA = Convert.ToString(reader.GetValue(pais_residenciaColumnIndex));
					if(!reader.IsDBNull(en_informconfColumnIndex))
						record.EN_INFORMCONF = Convert.ToString(reader.GetValue(en_informconfColumnIndex));
					if(!reader.IsDBNull(fecha_modificacion_informconfColumnIndex))
						record.FECHA_MODIFICACION_INFORMCONF = Convert.ToDateTime(reader.GetValue(fecha_modificacion_informconfColumnIndex));
					if(!reader.IsDBNull(fecha_ultima_visitaColumnIndex))
						record.FECHA_ULTIMA_VISITA = Convert.ToDateTime(reader.GetValue(fecha_ultima_visitaColumnIndex));
					if(!reader.IsDBNull(en_judicialColumnIndex))
						record.EN_JUDICIAL = Convert.ToString(reader.GetValue(en_judicialColumnIndex));
					if(!reader.IsDBNull(fecha_modificacion_judicialColumnIndex))
						record.FECHA_MODIFICACION_JUDICIAL = Convert.ToDateTime(reader.GetValue(fecha_modificacion_judicialColumnIndex));
					record.FECHA_ULTIMA_ACTUALIZAC_DATOS = Convert.ToDateTime(reader.GetValue(fecha_ultima_actualizac_datosColumnIndex));
					record.ES_CLIENTE = Convert.ToString(reader.GetValue(es_clienteColumnIndex));
					record.ES_CONTRIBUYENTE = Convert.ToString(reader.GetValue(es_contribuyenteColumnIndex));
					if(!reader.IsDBNull(abogado_idColumnIndex))
						record.ABOGADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(abogado_idColumnIndex)), 9);
					if(!reader.IsDBNull(abogado_nombreColumnIndex))
						record.ABOGADO_NOMBRE = Convert.ToString(reader.GetValue(abogado_nombreColumnIndex));
					if(!reader.IsDBNull(profesion_idColumnIndex))
						record.PROFESION_ID = Convert.ToString(reader.GetValue(profesion_idColumnIndex));
					if(!reader.IsDBNull(profesion_nombreColumnIndex))
						record.PROFESION_NOMBRE = Convert.ToString(reader.GetValue(profesion_nombreColumnIndex));
					if(!reader.IsDBNull(departamento1_idColumnIndex))
						record.DEPARTAMENTO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento1_idColumnIndex)), 9);
					if(!reader.IsDBNull(departament01_nombreColumnIndex))
						record.DEPARTAMENT01_NOMBRE = Convert.ToString(reader.GetValue(departament01_nombreColumnIndex));
					if(!reader.IsDBNull(ciudad1_idColumnIndex))
						record.CIUDAD1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad1_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad1_nombreColumnIndex))
						record.CIUDAD1_NOMBRE = Convert.ToString(reader.GetValue(ciudad1_nombreColumnIndex));
					if(!reader.IsDBNull(barrio1_idColumnIndex))
						record.BARRIO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio1_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio1_nombreColumnIndex))
						record.BARRIO1_NOMBRE = Convert.ToString(reader.GetValue(barrio1_nombreColumnIndex));
					if(!reader.IsDBNull(calle1ColumnIndex))
						record.CALLE1 = Convert.ToString(reader.GetValue(calle1ColumnIndex));
					if(!reader.IsDBNull(codigo_postal1ColumnIndex))
						record.CODIGO_POSTAL1 = Convert.ToString(reader.GetValue(codigo_postal1ColumnIndex));
					if(!reader.IsDBNull(departamento2_idColumnIndex))
						record.DEPARTAMENTO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento2_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento2_nombreColumnIndex))
						record.DEPARTAMENTO2_NOMBRE = Convert.ToString(reader.GetValue(departamento2_nombreColumnIndex));
					if(!reader.IsDBNull(ciudad2_idColumnIndex))
						record.CIUDAD2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad2_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad2_nombreColumnIndex))
						record.CIUDAD2_NOMBRE = Convert.ToString(reader.GetValue(ciudad2_nombreColumnIndex));
					if(!reader.IsDBNull(barrio2_idColumnIndex))
						record.BARRIO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio2_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio2_nombreColumnIndex))
						record.BARRIO2_NOMBRE = Convert.ToString(reader.GetValue(barrio2_nombreColumnIndex));
					if(!reader.IsDBNull(calle2ColumnIndex))
						record.CALLE2 = Convert.ToString(reader.GetValue(calle2ColumnIndex));
					if(!reader.IsDBNull(codigo_postal2ColumnIndex))
						record.CODIGO_POSTAL2 = Convert.ToString(reader.GetValue(codigo_postal2ColumnIndex));
					if(!reader.IsDBNull(telefono1ColumnIndex))
						record.TELEFONO1 = Convert.ToString(reader.GetValue(telefono1ColumnIndex));
					if(!reader.IsDBNull(telefono2ColumnIndex))
						record.TELEFONO2 = Convert.ToString(reader.GetValue(telefono2ColumnIndex));
					if(!reader.IsDBNull(telefono3ColumnIndex))
						record.TELEFONO3 = Convert.ToString(reader.GetValue(telefono3ColumnIndex));
					if(!reader.IsDBNull(telefono4ColumnIndex))
						record.TELEFONO4 = Convert.ToString(reader.GetValue(telefono4ColumnIndex));
					if(!reader.IsDBNull(email1ColumnIndex))
						record.EMAIL1 = Convert.ToString(reader.GetValue(email1ColumnIndex));
					if(!reader.IsDBNull(email2ColumnIndex))
						record.EMAIL2 = Convert.ToString(reader.GetValue(email2ColumnIndex));
					if(!reader.IsDBNull(email3ColumnIndex))
						record.EMAIL3 = Convert.ToString(reader.GetValue(email3ColumnIndex));
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_nombreColumnIndex))
						record.RUBRO_NOMBRE = Convert.ToString(reader.GetValue(rubro_nombreColumnIndex));
					record.POSEE_UNIPERSONAL = Convert.ToString(reader.GetValue(posee_unipersonalColumnIndex));
					if(!reader.IsDBNull(empresa_nombre_fantasiaColumnIndex))
						record.EMPRESA_NOMBRE_FANTASIA = Convert.ToString(reader.GetValue(empresa_nombre_fantasiaColumnIndex));
					if(!reader.IsDBNull(empresa_fundacionColumnIndex))
						record.EMPRESA_FUNDACION = Convert.ToDateTime(reader.GetValue(empresa_fundacionColumnIndex));
					if(!reader.IsDBNull(empresa_persona_contactoColumnIndex))
						record.EMPRESA_PERSONA_CONTACTO = Convert.ToString(reader.GetValue(empresa_persona_contactoColumnIndex));
					if(!reader.IsDBNull(empresa_telefono_contactoColumnIndex))
						record.EMPRESA_TELEFONO_CONTACTO = Convert.ToString(reader.GetValue(empresa_telefono_contactoColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_nombreColumnIndex))
						record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					if(!reader.IsDBNull(opera_creditoColumnIndex))
						record.OPERA_CREDITO = Convert.ToString(reader.GetValue(opera_creditoColumnIndex));
					record.CONDICION_HABITUAL_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_habitual_pago_idColumnIndex)), 9);
					record.MONEDA_LIMITE_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_limite_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_limite_creditoColumnIndex))
						record.MONEDA_LIMITE_CREDITO = Convert.ToString(reader.GetValue(moneda_limite_creditoColumnIndex));
					record.CONTADOR_CREDITO_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(contador_credito_actualColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_habitual_idColumnIndex))
						record.VENDEDOR_HABITUAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_habitual_idColumnIndex)), 9);
					if(!reader.IsDBNull(cobrador_habitual_idColumnIndex))
						record.COBRADOR_HABITUAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cobrador_habitual_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_cobranza_idColumnIndex))
						record.DEPARTAMENTO_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_cobranzaColumnIndex))
						record.DEPARTAMENTO_COBRANZA = Convert.ToString(reader.GetValue(departamento_cobranzaColumnIndex));
					if(!reader.IsDBNull(ciudad_cobranza_idColumnIndex))
						record.CIUDAD_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_cobranzaColumnIndex))
						record.CIUDAD_COBRANZA = Convert.ToString(reader.GetValue(ciudad_cobranzaColumnIndex));
					if(!reader.IsDBNull(barrio_cobranza_idColumnIndex))
						record.BARRIO_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_cobranzaColumnIndex))
						record.BARRIO_COBRANZA = Convert.ToString(reader.GetValue(barrio_cobranzaColumnIndex));
					if(!reader.IsDBNull(calle_cobranzaColumnIndex))
						record.CALLE_COBRANZA = Convert.ToString(reader.GetValue(calle_cobranzaColumnIndex));
					if(!reader.IsDBNull(codigo_postal_cobranzaColumnIndex))
						record.CODIGO_POSTAL_COBRANZA = Convert.ToString(reader.GetValue(codigo_postal_cobranzaColumnIndex));
					if(!reader.IsDBNull(telefono_cobranza1ColumnIndex))
						record.TELEFONO_COBRANZA1 = Convert.ToString(reader.GetValue(telefono_cobranza1ColumnIndex));
					if(!reader.IsDBNull(telefono_cobranza2ColumnIndex))
						record.TELEFONO_COBRANZA2 = Convert.ToString(reader.GetValue(telefono_cobranza2ColumnIndex));
					if(!reader.IsDBNull(conyuge_nombreColumnIndex))
						record.CONYUGE_NOMBRE = Convert.ToString(reader.GetValue(conyuge_nombreColumnIndex));
					if(!reader.IsDBNull(conyuge_apellidoColumnIndex))
						record.CONYUGE_APELLIDO = Convert.ToString(reader.GetValue(conyuge_apellidoColumnIndex));
					if(!reader.IsDBNull(estado_documentacion_idColumnIndex))
						record.ESTADO_DOCUMENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_documentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(documentacion_estadoColumnIndex))
						record.DOCUMENTACION_ESTADO = Convert.ToString(reader.GetValue(documentacion_estadoColumnIndex));
					record.AGENTE_RETENCION = Convert.ToString(reader.GetValue(agente_retencionColumnIndex));
					record.BANDERA_RETENCION = Convert.ToString(reader.GetValue(bandera_retencionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(latitud1ColumnIndex))
						record.LATITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud1ColumnIndex))
						record.LONGITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(latitud2ColumnIndex))
						record.LATITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud2ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud2ColumnIndex))
						record.LONGITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud2ColumnIndex)), 9);
					if(!reader.IsDBNull(latitud_cobranzaColumnIndex))
						record.LATITUD_COBRANZA = Math.Round(Convert.ToDecimal(reader.GetValue(latitud_cobranzaColumnIndex)), 9);
					if(!reader.IsDBNull(longitud_cobranzaColumnIndex))
						record.LONGITUD_COBRANZA = Math.Round(Convert.ToDecimal(reader.GetValue(longitud_cobranzaColumnIndex)), 9);
					if(!reader.IsDBNull(nivel_credito_idColumnIndex))
						record.NIVEL_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nivel_credito_idColumnIndex)), 9);
					if(!reader.IsDBNull(nivel_creditoColumnIndex))
						record.NIVEL_CREDITO = Convert.ToString(reader.GetValue(nivel_creditoColumnIndex));
					if(!reader.IsDBNull(grupo_sanguineoColumnIndex))
						record.GRUPO_SANGUINEO = Convert.ToString(reader.GetValue(grupo_sanguineoColumnIndex));
					if(!reader.IsDBNull(estado_civil_idColumnIndex))
						record.ESTADO_CIVIL_ID = Convert.ToString(reader.GetValue(estado_civil_idColumnIndex));
					if(!reader.IsDBNull(persona_id_conyugeColumnIndex))
						record.PERSONA_ID_CONYUGE = Math.Round(Convert.ToDecimal(reader.GetValue(persona_id_conyugeColumnIndex)), 9);
					if(!reader.IsDBNull(numero_hijosColumnIndex))
						record.NUMERO_HIJOS = Math.Round(Convert.ToDecimal(reader.GetValue(numero_hijosColumnIndex)), 9);
					if(!reader.IsDBNull(zona_cobranza_idColumnIndex))
						record.ZONA_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(zona_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(zona_nombreColumnIndex))
						record.ZONA_NOMBRE = Convert.ToString(reader.GetValue(zona_nombreColumnIndex));
					if(!reader.IsDBNull(zona_abreviaturaColumnIndex))
						record.ZONA_ABREVIATURA = Convert.ToString(reader.GetValue(zona_abreviaturaColumnIndex));
					if(!reader.IsDBNull(estado_civil_descripcionColumnIndex))
						record.ESTADO_CIVIL_DESCRIPCION = Convert.ToString(reader.GetValue(estado_civil_descripcionColumnIndex));
					if(!reader.IsDBNull(tipo_empleoColumnIndex))
						record.TIPO_EMPLEO = Convert.ToString(reader.GetValue(tipo_empleoColumnIndex));
					record.SEPARACION_BIENES = Convert.ToString(reader.GetValue(separacion_bienesColumnIndex));
					record.PORC_DESCUENTO_AUTOMATICO = Math.Round(Convert.ToDecimal(reader.GetValue(porc_descuento_automaticoColumnIndex)), 9);
					if(!reader.IsDBNull(persona_calificaion_idColumnIndex))
						record.PERSONA_CALIFICAION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_calificaion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_cliente_idColumnIndex))
						record.TIPO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_clientes_nombreColumnIndex))
						record.TIPO_CLIENTES_NOMBRE = Convert.ToString(reader.GetValue(tipo_clientes_nombreColumnIndex));
					if(!reader.IsDBNull(estado_morosidad_idColumnIndex))
						record.ESTADO_MOROSIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_morosidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_morosidad_nombreColumnIndex))
						record.ESTADO_MOROSIDAD_NOMBRE = Convert.ToString(reader.GetValue(estado_morosidad_nombreColumnIndex));
					if(!reader.IsDBNull(descripcion_calificacionColumnIndex))
						record.DESCRIPCION_CALIFICACION = Convert.ToString(reader.GetValue(descripcion_calificacionColumnIndex));
					record.MODIFICABLE = Convert.ToString(reader.GetValue(modificableColumnIndex));
					if(!reader.IsDBNull(nro_tarjeta_red_pagoColumnIndex))
						record.NRO_TARJETA_RED_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(nro_tarjeta_red_pagoColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_habitual_nombreColumnIndex))
						record.VENDEDOR_HABITUAL_NOMBRE = Convert.ToString(reader.GetValue(vendedor_habitual_nombreColumnIndex));
					if(!reader.IsDBNull(vendedor_habitual_codigoColumnIndex))
						record.VENDEDOR_HABITUAL_CODIGO = Convert.ToString(reader.GetValue(vendedor_habitual_codigoColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_padre_idColumnIndex))
						record.PERSONA_PADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_padre_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_padre_codigoColumnIndex))
						record.PERSONA_PADRE_CODIGO = Convert.ToString(reader.GetValue(persona_padre_codigoColumnIndex));
					if(!reader.IsDBNull(lista_precios_idColumnIndex))
						record.LISTA_PRECIOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PERSONAS_INFO_COMPLETARow[])(recordList.ToArray(typeof(PERSONAS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PERSONAS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PERSONAS_INFO_COMPLETARow"/> object.</returns>
		protected virtual PERSONAS_INFO_COMPLETARow MapRow(DataRow row)
		{
			PERSONAS_INFO_COMPLETARow mappedObject = new PERSONAS_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_NOMBRE"
			dataColumn = dataTable.Columns["ENTIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_NOMBRE = (string)row[dataColumn];
			// Column "FISICO"
			dataColumn = dataTable.Columns["FISICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FISICO = (string)row[dataColumn];
			// Column "MAYORISTA"
			dataColumn = dataTable.Columns["MAYORISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAYORISTA = (string)row[dataColumn];
			// Column "TRATAMIENTO_ID"
			dataColumn = dataTable.Columns["TRATAMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRATAMIENTO_ID = (string)row[dataColumn];
			// Column "TRATAMIENTO"
			dataColumn = dataTable.Columns["TRATAMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRATAMIENTO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "APELLIDO"
			dataColumn = dataTable.Columns["APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APELLIDO = (string)row[dataColumn];
			// Column "NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "NOMBRE_FANTASIA"
			dataColumn = dataTable.Columns["NOMBRE_FANTASIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_FANTASIA = (string)row[dataColumn];
			// Column "GENERO"
			dataColumn = dataTable.Columns["GENERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERO = (string)row[dataColumn];
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
			// Column "NACIMIENTO"
			dataColumn = dataTable.Columns["NACIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NACIMIENTO = (System.DateTime)row[dataColumn];
			// Column "TIPO_DOCUMENTO_IDENTIDAD_ID"
			dataColumn = dataTable.Columns["TIPO_DOCUMENTO_IDENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DOCUMENTO_IDENTIDAD_ID = (string)row[dataColumn];
			// Column "NUMERO_DOCUMENTO"
			dataColumn = dataTable.Columns["NUMERO_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_DOCUMENTO = (string)row[dataColumn];
			// Column "CODIGO_EXTERNO"
			dataColumn = dataTable.Columns["CODIGO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EXTERNO = (string)row[dataColumn];
			// Column "PAIS_NACIONALIDAD_ID"
			dataColumn = dataTable.Columns["PAIS_NACIONALIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_NACIONALIDAD_ID = (decimal)row[dataColumn];
			// Column "PAIS_NACIONALIDAD"
			dataColumn = dataTable.Columns["PAIS_NACIONALIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_NACIONALIDAD = (string)row[dataColumn];
			// Column "PAIS_RESIDENCIA_ID"
			dataColumn = dataTable.Columns["PAIS_RESIDENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_RESIDENCIA_ID = (decimal)row[dataColumn];
			// Column "PAIS_RESIDENCIA"
			dataColumn = dataTable.Columns["PAIS_RESIDENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_RESIDENCIA = (string)row[dataColumn];
			// Column "EN_INFORMCONF"
			dataColumn = dataTable.Columns["EN_INFORMCONF"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_INFORMCONF = (string)row[dataColumn];
			// Column "FECHA_MODIFICACION_INFORMCONF"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION_INFORMCONF"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION_INFORMCONF = (System.DateTime)row[dataColumn];
			// Column "FECHA_ULTIMA_VISITA"
			dataColumn = dataTable.Columns["FECHA_ULTIMA_VISITA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMA_VISITA = (System.DateTime)row[dataColumn];
			// Column "EN_JUDICIAL"
			dataColumn = dataTable.Columns["EN_JUDICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_JUDICIAL = (string)row[dataColumn];
			// Column "FECHA_MODIFICACION_JUDICIAL"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION_JUDICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION_JUDICIAL = (System.DateTime)row[dataColumn];
			// Column "FECHA_ULTIMA_ACTUALIZAC_DATOS"
			dataColumn = dataTable.Columns["FECHA_ULTIMA_ACTUALIZAC_DATOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMA_ACTUALIZAC_DATOS = (System.DateTime)row[dataColumn];
			// Column "ES_CLIENTE"
			dataColumn = dataTable.Columns["ES_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CLIENTE = (string)row[dataColumn];
			// Column "ES_CONTRIBUYENTE"
			dataColumn = dataTable.Columns["ES_CONTRIBUYENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CONTRIBUYENTE = (string)row[dataColumn];
			// Column "ABOGADO_ID"
			dataColumn = dataTable.Columns["ABOGADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABOGADO_ID = (decimal)row[dataColumn];
			// Column "ABOGADO_NOMBRE"
			dataColumn = dataTable.Columns["ABOGADO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABOGADO_NOMBRE = (string)row[dataColumn];
			// Column "PROFESION_ID"
			dataColumn = dataTable.Columns["PROFESION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROFESION_ID = (string)row[dataColumn];
			// Column "PROFESION_NOMBRE"
			dataColumn = dataTable.Columns["PROFESION_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROFESION_NOMBRE = (string)row[dataColumn];
			// Column "DEPARTAMENTO1_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO1_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENT01_NOMBRE"
			dataColumn = dataTable.Columns["DEPARTAMENT01_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENT01_NOMBRE = (string)row[dataColumn];
			// Column "CIUDAD1_ID"
			dataColumn = dataTable.Columns["CIUDAD1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_ID = (decimal)row[dataColumn];
			// Column "CIUDAD1_NOMBRE"
			dataColumn = dataTable.Columns["CIUDAD1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_NOMBRE = (string)row[dataColumn];
			// Column "BARRIO1_ID"
			dataColumn = dataTable.Columns["BARRIO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_ID = (decimal)row[dataColumn];
			// Column "BARRIO1_NOMBRE"
			dataColumn = dataTable.Columns["BARRIO1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_NOMBRE = (string)row[dataColumn];
			// Column "CALLE1"
			dataColumn = dataTable.Columns["CALLE1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE1 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL1"
			dataColumn = dataTable.Columns["CODIGO_POSTAL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL1 = (string)row[dataColumn];
			// Column "DEPARTAMENTO2_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO2_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO2_NOMBRE"
			dataColumn = dataTable.Columns["DEPARTAMENTO2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO2_NOMBRE = (string)row[dataColumn];
			// Column "CIUDAD2_ID"
			dataColumn = dataTable.Columns["CIUDAD2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_ID = (decimal)row[dataColumn];
			// Column "CIUDAD2_NOMBRE"
			dataColumn = dataTable.Columns["CIUDAD2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_NOMBRE = (string)row[dataColumn];
			// Column "BARRIO2_ID"
			dataColumn = dataTable.Columns["BARRIO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_ID = (decimal)row[dataColumn];
			// Column "BARRIO2_NOMBRE"
			dataColumn = dataTable.Columns["BARRIO2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_NOMBRE = (string)row[dataColumn];
			// Column "CALLE2"
			dataColumn = dataTable.Columns["CALLE2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE2 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL2"
			dataColumn = dataTable.Columns["CODIGO_POSTAL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL2 = (string)row[dataColumn];
			// Column "TELEFONO1"
			dataColumn = dataTable.Columns["TELEFONO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO1 = (string)row[dataColumn];
			// Column "TELEFONO2"
			dataColumn = dataTable.Columns["TELEFONO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO2 = (string)row[dataColumn];
			// Column "TELEFONO3"
			dataColumn = dataTable.Columns["TELEFONO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO3 = (string)row[dataColumn];
			// Column "TELEFONO4"
			dataColumn = dataTable.Columns["TELEFONO4"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO4 = (string)row[dataColumn];
			// Column "EMAIL1"
			dataColumn = dataTable.Columns["EMAIL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL1 = (string)row[dataColumn];
			// Column "EMAIL2"
			dataColumn = dataTable.Columns["EMAIL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL2 = (string)row[dataColumn];
			// Column "EMAIL3"
			dataColumn = dataTable.Columns["EMAIL3"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL3 = (string)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_NOMBRE"
			dataColumn = dataTable.Columns["RUBRO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_NOMBRE = (string)row[dataColumn];
			// Column "POSEE_UNIPERSONAL"
			dataColumn = dataTable.Columns["POSEE_UNIPERSONAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.POSEE_UNIPERSONAL = (string)row[dataColumn];
			// Column "EMPRESA_NOMBRE_FANTASIA"
			dataColumn = dataTable.Columns["EMPRESA_NOMBRE_FANTASIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_NOMBRE_FANTASIA = (string)row[dataColumn];
			// Column "EMPRESA_FUNDACION"
			dataColumn = dataTable.Columns["EMPRESA_FUNDACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_FUNDACION = (System.DateTime)row[dataColumn];
			// Column "EMPRESA_PERSONA_CONTACTO"
			dataColumn = dataTable.Columns["EMPRESA_PERSONA_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_PERSONA_CONTACTO = (string)row[dataColumn];
			// Column "EMPRESA_TELEFONO_CONTACTO"
			dataColumn = dataTable.Columns["EMPRESA_TELEFONO_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_TELEFONO_CONTACTO = (string)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "OPERA_CREDITO"
			dataColumn = dataTable.Columns["OPERA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERA_CREDITO = (string)row[dataColumn];
			// Column "CONDICION_HABITUAL_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_HABITUAL_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_HABITUAL_PAGO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_LIMITE_CREDITO_ID"
			dataColumn = dataTable.Columns["MONEDA_LIMITE_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_LIMITE_CREDITO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_LIMITE_CREDITO"
			dataColumn = dataTable.Columns["MONEDA_LIMITE_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_LIMITE_CREDITO = (string)row[dataColumn];
			// Column "CONTADOR_CREDITO_ACTUAL"
			dataColumn = dataTable.Columns["CONTADOR_CREDITO_ACTUAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTADOR_CREDITO_ACTUAL = (decimal)row[dataColumn];
			// Column "VENDEDOR_HABITUAL_ID"
			dataColumn = dataTable.Columns["VENDEDOR_HABITUAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_HABITUAL_ID = (decimal)row[dataColumn];
			// Column "COBRADOR_HABITUAL_ID"
			dataColumn = dataTable.Columns["COBRADOR_HABITUAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRADOR_HABITUAL_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO_COBRANZA_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO_COBRANZA"
			dataColumn = dataTable.Columns["DEPARTAMENTO_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_COBRANZA = (string)row[dataColumn];
			// Column "CIUDAD_COBRANZA_ID"
			dataColumn = dataTable.Columns["CIUDAD_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_COBRANZA"
			dataColumn = dataTable.Columns["CIUDAD_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_COBRANZA = (string)row[dataColumn];
			// Column "BARRIO_COBRANZA_ID"
			dataColumn = dataTable.Columns["BARRIO_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "BARRIO_COBRANZA"
			dataColumn = dataTable.Columns["BARRIO_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_COBRANZA = (string)row[dataColumn];
			// Column "CALLE_COBRANZA"
			dataColumn = dataTable.Columns["CALLE_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE_COBRANZA = (string)row[dataColumn];
			// Column "CODIGO_POSTAL_COBRANZA"
			dataColumn = dataTable.Columns["CODIGO_POSTAL_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL_COBRANZA = (string)row[dataColumn];
			// Column "TELEFONO_COBRANZA1"
			dataColumn = dataTable.Columns["TELEFONO_COBRANZA1"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_COBRANZA1 = (string)row[dataColumn];
			// Column "TELEFONO_COBRANZA2"
			dataColumn = dataTable.Columns["TELEFONO_COBRANZA2"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_COBRANZA2 = (string)row[dataColumn];
			// Column "CONYUGE_NOMBRE"
			dataColumn = dataTable.Columns["CONYUGE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONYUGE_NOMBRE = (string)row[dataColumn];
			// Column "CONYUGE_APELLIDO"
			dataColumn = dataTable.Columns["CONYUGE_APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONYUGE_APELLIDO = (string)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_ID"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_ID = (decimal)row[dataColumn];
			// Column "DOCUMENTACION_ESTADO"
			dataColumn = dataTable.Columns["DOCUMENTACION_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTACION_ESTADO = (string)row[dataColumn];
			// Column "AGENTE_RETENCION"
			dataColumn = dataTable.Columns["AGENTE_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.AGENTE_RETENCION = (string)row[dataColumn];
			// Column "BANDERA_RETENCION"
			dataColumn = dataTable.Columns["BANDERA_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANDERA_RETENCION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "INGRESO_APROBADO"
			dataColumn = dataTable.Columns["INGRESO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_APROBADO = (string)row[dataColumn];
			// Column "USUARIO_APROBACION_ID"
			dataColumn = dataTable.Columns["USUARIO_APROBACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_APROBACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_APROBACION"
			dataColumn = dataTable.Columns["FECHA_APROBACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_APROBACION = (System.DateTime)row[dataColumn];
			// Column "LATITUD1"
			dataColumn = dataTable.Columns["LATITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD1 = (decimal)row[dataColumn];
			// Column "LONGITUD1"
			dataColumn = dataTable.Columns["LONGITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD1 = (decimal)row[dataColumn];
			// Column "LATITUD2"
			dataColumn = dataTable.Columns["LATITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD2 = (decimal)row[dataColumn];
			// Column "LONGITUD2"
			dataColumn = dataTable.Columns["LONGITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD2 = (decimal)row[dataColumn];
			// Column "LATITUD_COBRANZA"
			dataColumn = dataTable.Columns["LATITUD_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD_COBRANZA = (decimal)row[dataColumn];
			// Column "LONGITUD_COBRANZA"
			dataColumn = dataTable.Columns["LONGITUD_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD_COBRANZA = (decimal)row[dataColumn];
			// Column "NIVEL_CREDITO_ID"
			dataColumn = dataTable.Columns["NIVEL_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL_CREDITO_ID = (decimal)row[dataColumn];
			// Column "NIVEL_CREDITO"
			dataColumn = dataTable.Columns["NIVEL_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL_CREDITO = (string)row[dataColumn];
			// Column "GRUPO_SANGUINEO"
			dataColumn = dataTable.Columns["GRUPO_SANGUINEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_SANGUINEO = (string)row[dataColumn];
			// Column "ESTADO_CIVIL_ID"
			dataColumn = dataTable.Columns["ESTADO_CIVIL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CIVIL_ID = (string)row[dataColumn];
			// Column "PERSONA_ID_CONYUGE"
			dataColumn = dataTable.Columns["PERSONA_ID_CONYUGE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID_CONYUGE = (decimal)row[dataColumn];
			// Column "NUMERO_HIJOS"
			dataColumn = dataTable.Columns["NUMERO_HIJOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_HIJOS = (decimal)row[dataColumn];
			// Column "ZONA_COBRANZA_ID"
			dataColumn = dataTable.Columns["ZONA_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ZONA_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "ZONA_NOMBRE"
			dataColumn = dataTable.Columns["ZONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ZONA_NOMBRE = (string)row[dataColumn];
			// Column "ZONA_ABREVIATURA"
			dataColumn = dataTable.Columns["ZONA_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ZONA_ABREVIATURA = (string)row[dataColumn];
			// Column "ESTADO_CIVIL_DESCRIPCION"
			dataColumn = dataTable.Columns["ESTADO_CIVIL_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CIVIL_DESCRIPCION = (string)row[dataColumn];
			// Column "TIPO_EMPLEO"
			dataColumn = dataTable.Columns["TIPO_EMPLEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMPLEO = (string)row[dataColumn];
			// Column "SEPARACION_BIENES"
			dataColumn = dataTable.Columns["SEPARACION_BIENES"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEPARACION_BIENES = (string)row[dataColumn];
			// Column "PORC_DESCUENTO_AUTOMATICO"
			dataColumn = dataTable.Columns["PORC_DESCUENTO_AUTOMATICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORC_DESCUENTO_AUTOMATICO = (decimal)row[dataColumn];
			// Column "PERSONA_CALIFICAION_ID"
			dataColumn = dataTable.Columns["PERSONA_CALIFICAION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CALIFICAION_ID = (decimal)row[dataColumn];
			// Column "TIPO_CLIENTE_ID"
			dataColumn = dataTable.Columns["TIPO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "TIPO_CLIENTES_NOMBRE"
			dataColumn = dataTable.Columns["TIPO_CLIENTES_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTES_NOMBRE = (string)row[dataColumn];
			// Column "ESTADO_MOROSIDAD_ID"
			dataColumn = dataTable.Columns["ESTADO_MOROSIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_MOROSIDAD_ID = (decimal)row[dataColumn];
			// Column "ESTADO_MOROSIDAD_NOMBRE"
			dataColumn = dataTable.Columns["ESTADO_MOROSIDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_MOROSIDAD_NOMBRE = (string)row[dataColumn];
			// Column "DESCRIPCION_CALIFICACION"
			dataColumn = dataTable.Columns["DESCRIPCION_CALIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION_CALIFICACION = (string)row[dataColumn];
			// Column "MODIFICABLE"
			dataColumn = dataTable.Columns["MODIFICABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MODIFICABLE = (string)row[dataColumn];
			// Column "NRO_TARJETA_RED_PAGO"
			dataColumn = dataTable.Columns["NRO_TARJETA_RED_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TARJETA_RED_PAGO = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR_HABITUAL_NOMBRE"
			dataColumn = dataTable.Columns["VENDEDOR_HABITUAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_HABITUAL_NOMBRE = (string)row[dataColumn];
			// Column "VENDEDOR_HABITUAL_CODIGO"
			dataColumn = dataTable.Columns["VENDEDOR_HABITUAL_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_HABITUAL_CODIGO = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_PADRE_ID"
			dataColumn = dataTable.Columns["PERSONA_PADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_PADRE_ID = (decimal)row[dataColumn];
			// Column "PERSONA_PADRE_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_PADRE_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_PADRE_CODIGO = (string)row[dataColumn];
			// Column "LISTA_PRECIOS_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PERSONAS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PERSONAS_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FISICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MAYORISTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRATAMIENTO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRATAMIENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_FANTASIA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NACIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DOCUMENTO_IDENTIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_EXTERNO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_NACIONALIDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_NACIONALIDAD", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_RESIDENCIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_RESIDENCIA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EN_INFORMCONF", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION_INFORMCONF", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMA_VISITA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EN_JUDICIAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION_JUDICIAL", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMA_ACTUALIZAC_DATOS", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_CLIENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_CONTRIBUYENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ABOGADO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ABOGADO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROFESION_ID", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROFESION_NOMBRE", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENT01_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE1", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL1", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE2", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL2", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO1", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO2", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO3", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO4", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMAIL1", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMAIL2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMAIL3", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("POSEE_UNIPERSONAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_NOMBRE_FANTASIA", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_FUNDACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_PERSONA_CONTACTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("EMPRESA_TELEFONO_CONTACTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OPERA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_HABITUAL_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_LIMITE_CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_LIMITE_CREDITO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTADOR_CREDITO_ACTUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_HABITUAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COBRADOR_HABITUAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_COBRANZA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_COBRANZA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD_COBRANZA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD_COBRANZA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO_COBRANZA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO_COBRANZA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE_COBRANZA", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL_COBRANZA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO_COBRANZA1", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO_COBRANZA2", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONYUGE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONYUGE_APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DOCUMENTACION_ESTADO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("AGENTE_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANDERA_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD1", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD1", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD_COBRANZA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD_COBRANZA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NIVEL_CREDITO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NIVEL_CREDITO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_SANGUINEO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_CIVIL_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID_CONYUGE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_HIJOS", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ZONA_COBRANZA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ZONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ZONA_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_CIVIL_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_EMPLEO", typeof(string));
			dataColumn.MaxLength = 3;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SEPARACION_BIENES", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PORC_DESCUENTO_AUTOMATICO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CALIFICAION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTES_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_MOROSIDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_MOROSIDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCRIPCION_CALIFICACION", typeof(string));
			dataColumn.MaxLength = 60;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MODIFICABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NRO_TARJETA_RED_PAGO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_HABITUAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("VENDEDOR_HABITUAL_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_PADRE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_PADRE_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_ID", typeof(decimal));
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

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FISICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MAYORISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TRATAMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRATAMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_FANTASIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GENERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NACIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "TIPO_DOCUMENTO_IDENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_NACIONALIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_NACIONALIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_RESIDENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_RESIDENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EN_INFORMCONF":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_MODIFICACION_INFORMCONF":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ULTIMA_VISITA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EN_JUDICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_MODIFICACION_JUDICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ULTIMA_ACTUALIZAC_DATOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ES_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_CONTRIBUYENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ABOGADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ABOGADO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROFESION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROFESION_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENT01_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CALLE1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CALLE2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "POSEE_UNIPERSONAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EMPRESA_NOMBRE_FANTASIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMPRESA_FUNDACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EMPRESA_PERSONA_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMPRESA_TELEFONO_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OPERA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONDICION_HABITUAL_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_LIMITE_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_LIMITE_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTADOR_CREDITO_ACTUAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_HABITUAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRADOR_HABITUAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CALLE_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_COBRANZA1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_COBRANZA2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONYUGE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONYUGE_APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_DOCUMENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DOCUMENTACION_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AGENTE_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BANDERA_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INGRESO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_APROBACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_APROBACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "LATITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LATITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LATITUD_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NIVEL_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NIVEL_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GRUPO_SANGUINEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_CIVIL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID_CONYUGE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_HIJOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ZONA_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ZONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ZONA_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_CIVIL_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_EMPLEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEPARACION_BIENES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PORC_DESCUENTO_AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_CALIFICAION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CLIENTES_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_MOROSIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_MOROSIDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION_CALIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MODIFICABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_TARJETA_RED_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_HABITUAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENDEDOR_HABITUAL_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_PADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_PADRE_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LISTA_PRECIOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PERSONAS_INFO_COMPLETACollection_Base class
}  // End of namespace
