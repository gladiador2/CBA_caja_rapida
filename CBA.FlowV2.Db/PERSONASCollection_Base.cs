// <fileinfo name="PERSONASCollection_Base.cs">
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
	/// The base class for <see cref="PERSONASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PERSONASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string FISICOColumnName = "FISICO";
		public const string MAYORISTAColumnName = "MAYORISTA";
		public const string TRATAMIENTO_IDColumnName = "TRATAMIENTO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string APELLIDOColumnName = "APELLIDO";
		public const string NOMBRE_COMPLETOColumnName = "NOMBRE_COMPLETO";
		public const string NOMBRE_FANTASIAColumnName = "NOMBRE_FANTASIA";
		public const string GENEROColumnName = "GENERO";
		public const string RUCColumnName = "RUC";
		public const string NACIMIENTOColumnName = "NACIMIENTO";
		public const string TIPO_DOCUMENTO_IDENTIDAD_IDColumnName = "TIPO_DOCUMENTO_IDENTIDAD_ID";
		public const string NUMERO_DOCUMENTOColumnName = "NUMERO_DOCUMENTO";
		public const string PAIS_NACIONALIDAD_IDColumnName = "PAIS_NACIONALIDAD_ID";
		public const string PAIS_RESIDENCIA_IDColumnName = "PAIS_RESIDENCIA_ID";
		public const string EN_INFORMCONFColumnName = "EN_INFORMCONF";
		public const string FECHA_MODIFICACION_INFORMCONFColumnName = "FECHA_MODIFICACION_INFORMCONF";
		public const string EN_JUDICIALColumnName = "EN_JUDICIAL";
		public const string ES_CLIENTEColumnName = "ES_CLIENTE";
		public const string POSEE_UNIPERSONALColumnName = "POSEE_UNIPERSONAL";
		public const string EMPRESA_NOMBRE_FANTASIAColumnName = "EMPRESA_NOMBRE_FANTASIA";
		public const string FECHA_MODIFICACION_JUDICIALColumnName = "FECHA_MODIFICACION_JUDICIAL";
		public const string ABOGADO_IDColumnName = "ABOGADO_ID";
		public const string PROFESION_IDColumnName = "PROFESION_ID";
		public const string DEPARTAMENTO1_IDColumnName = "DEPARTAMENTO1_ID";
		public const string CIUDAD1_IDColumnName = "CIUDAD1_ID";
		public const string BARRIO1_IDColumnName = "BARRIO1_ID";
		public const string CALLE1ColumnName = "CALLE1";
		public const string CODIGO_POSTAL1ColumnName = "CODIGO_POSTAL1";
		public const string LATITUD1ColumnName = "LATITUD1";
		public const string LONGITUD1ColumnName = "LONGITUD1";
		public const string DEPARTAMENTO2_IDColumnName = "DEPARTAMENTO2_ID";
		public const string CIUDAD2_IDColumnName = "CIUDAD2_ID";
		public const string BARRIO2_IDColumnName = "BARRIO2_ID";
		public const string CALLE2ColumnName = "CALLE2";
		public const string CODIGO_POSTAL2ColumnName = "CODIGO_POSTAL2";
		public const string LATITUD2ColumnName = "LATITUD2";
		public const string LONGITUD2ColumnName = "LONGITUD2";
		public const string TELEFONO1ColumnName = "TELEFONO1";
		public const string TELEFONO2ColumnName = "TELEFONO2";
		public const string TELEFONO3ColumnName = "TELEFONO3";
		public const string TELEFONO4ColumnName = "TELEFONO4";
		public const string EMAIL1ColumnName = "EMAIL1";
		public const string EMAIL2ColumnName = "EMAIL2";
		public const string EMAIL3ColumnName = "EMAIL3";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string EMPRESA_FUNDACIONColumnName = "EMPRESA_FUNDACION";
		public const string EMPRESA_PERSONA_CONTACTOColumnName = "EMPRESA_PERSONA_CONTACTO";
		public const string EMPRESA_TELEFONO_CONTACTOColumnName = "EMPRESA_TELEFONO_CONTACTO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string OPERA_CREDITOColumnName = "OPERA_CREDITO";
		public const string CONDICION_HABITUAL_PAGO_IDColumnName = "CONDICION_HABITUAL_PAGO_ID";
		public const string MONEDA_LIMITE_CREDITO_IDColumnName = "MONEDA_LIMITE_CREDITO_ID";
		public const string CONTADOR_CREDITO_ACTUALColumnName = "CONTADOR_CREDITO_ACTUAL";
		public const string VENDEDOR_HABITUAL_IDColumnName = "VENDEDOR_HABITUAL_ID";
		public const string COBRADOR_HABITUAL_IDColumnName = "COBRADOR_HABITUAL_ID";
		public const string DEPARTAMENTO_COBRANZA_IDColumnName = "DEPARTAMENTO_COBRANZA_ID";
		public const string CIUDAD_COBRANZA_IDColumnName = "CIUDAD_COBRANZA_ID";
		public const string BARRIO_COBRANZA_IDColumnName = "BARRIO_COBRANZA_ID";
		public const string CALLE_COBRANZAColumnName = "CALLE_COBRANZA";
		public const string CODIGO_POSTAL_COBRANZAColumnName = "CODIGO_POSTAL_COBRANZA";
		public const string LATITUD_COBRANZAColumnName = "LATITUD_COBRANZA";
		public const string LONGITUD_COBRANZAColumnName = "LONGITUD_COBRANZA";
		public const string TELEFONO_COBRANZA1ColumnName = "TELEFONO_COBRANZA1";
		public const string TELEFONO_COBRANZA2ColumnName = "TELEFONO_COBRANZA2";
		public const string CONYUGE_NOMBREColumnName = "CONYUGE_NOMBRE";
		public const string CONYUGE_APELLIDOColumnName = "CONYUGE_APELLIDO";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string NIVEL_CREDITO_IDColumnName = "NIVEL_CREDITO_ID";
		public const string AGENTE_RETENCIONColumnName = "AGENTE_RETENCION";
		public const string BANDERA_RETENCIONColumnName = "BANDERA_RETENCION";
		public const string ESTADOColumnName = "ESTADO";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string GRUPO_SANGUINEOColumnName = "GRUPO_SANGUINEO";
		public const string ESTADO_CIVIL_IDColumnName = "ESTADO_CIVIL_ID";
		public const string PERSONA_ID_CONYUGEColumnName = "PERSONA_ID_CONYUGE";
		public const string NUMERO_HIJOSColumnName = "NUMERO_HIJOS";
		public const string TIPO_EMPLEOColumnName = "TIPO_EMPLEO";
		public const string SEPARACION_BIENESColumnName = "SEPARACION_BIENES";
		public const string PORC_DESCUENTO_AUTOMATICOColumnName = "PORC_DESCUENTO_AUTOMATICO";
		public const string PERSONA_CALIFICACION_IDColumnName = "PERSONA_CALIFICACION_ID";
		public const string ZONA_COBRANZA_IDColumnName = "ZONA_COBRANZA_ID";
		public const string TIPO_CLIENTE_IDColumnName = "TIPO_CLIENTE_ID";
		public const string ESTADO_MOROSIDAD_IDColumnName = "ESTADO_MOROSIDAD_ID";
		public const string MODIFICABLEColumnName = "MODIFICABLE";
		public const string ES_CONTRIBUYENTEColumnName = "ES_CONTRIBUYENTE";
		public const string NRO_TARJETA_RED_PAGOColumnName = "NRO_TARJETA_RED_PAGO";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string CODIGO_EXTERNOColumnName = "CODIGO_EXTERNO";
		public const string FECHA_ULTIMA_VISITAColumnName = "FECHA_ULTIMA_VISITA";
		public const string FECHA_ULTIMA_ACTUALIZAC_DATOSColumnName = "FECHA_ULTIMA_ACTUALIZAC_DATOS";
		public const string PERSONA_PADRE_IDColumnName = "PERSONA_PADRE_ID";
		public const string LISTA_PRECIOS_IDColumnName = "LISTA_PRECIOS_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PERSONASCollection_Base(CBAV2 db)
		{
			_db = db;
		}

		/// <summary>
		/// Gets the database object that this table belongs to.
		///	</summary>
		///	<value>The <see cref="CBAV2"/> object.</value>
		protected CBAV2 Database
		{
			get { return _db; }
		}

		/// <summary>
		/// Gets an array of all records from the <c>PERSONAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PERSONASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PERSONASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PERSONASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects that 
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
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PERSONASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PERSONASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PERSONASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByABOGADO_ID(decimal abogado_id)
		{
			return GetByABOGADO_ID(abogado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <param name="abogado_idNull">true if the method ignores the abogado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByABOGADO_ID(decimal abogado_id, bool abogado_idNull)
		{
			return MapRecords(CreateGetByABOGADO_IDCommand(abogado_id, abogado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByABOGADO_IDAsDataTable(decimal abogado_id)
		{
			return GetByABOGADO_IDAsDataTable(abogado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <param name="abogado_idNull">true if the method ignores the abogado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByABOGADO_IDAsDataTable(decimal abogado_id, bool abogado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByABOGADO_IDCommand(abogado_id, abogado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <param name="abogado_idNull">true if the method ignores the abogado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByABOGADO_IDCommand(decimal abogado_id, bool abogado_idNull)
		{
			string whereSql = "";
			if(abogado_idNull)
				whereSql += "ABOGADO_ID IS NULL";
			else
				whereSql += "ABOGADO_ID=" + _db.CreateSqlParameterName("ABOGADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!abogado_idNull)
				AddParameter(cmd, "ABOGADO_ID", abogado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByBARRIO_COBRANZA_ID(decimal barrio_cobranza_id)
		{
			return GetByBARRIO_COBRANZA_ID(barrio_cobranza_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <param name="barrio_cobranza_idNull">true if the method ignores the barrio_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByBARRIO_COBRANZA_ID(decimal barrio_cobranza_id, bool barrio_cobranza_idNull)
		{
			return MapRecords(CreateGetByBARRIO_COBRANZA_IDCommand(barrio_cobranza_id, barrio_cobranza_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO_COBRANZA_IDAsDataTable(decimal barrio_cobranza_id)
		{
			return GetByBARRIO_COBRANZA_IDAsDataTable(barrio_cobranza_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <param name="barrio_cobranza_idNull">true if the method ignores the barrio_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO_COBRANZA_IDAsDataTable(decimal barrio_cobranza_id, bool barrio_cobranza_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO_COBRANZA_IDCommand(barrio_cobranza_id, barrio_cobranza_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <param name="barrio_cobranza_idNull">true if the method ignores the barrio_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO_COBRANZA_IDCommand(decimal barrio_cobranza_id, bool barrio_cobranza_idNull)
		{
			string whereSql = "";
			if(barrio_cobranza_idNull)
				whereSql += "BARRIO_COBRANZA_ID IS NULL";
			else
				whereSql += "BARRIO_COBRANZA_ID=" + _db.CreateSqlParameterName("BARRIO_COBRANZA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio_cobranza_idNull)
				AddParameter(cmd, "BARRIO_COBRANZA_ID", barrio_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByBARRIO1_ID(decimal barrio1_id)
		{
			return GetByBARRIO1_ID(barrio1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByBARRIO1_ID(decimal barrio1_id, bool barrio1_idNull)
		{
			return MapRecords(CreateGetByBARRIO1_IDCommand(barrio1_id, barrio1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO1_IDAsDataTable(decimal barrio1_id)
		{
			return GetByBARRIO1_IDAsDataTable(barrio1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO1_IDAsDataTable(decimal barrio1_id, bool barrio1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO1_IDCommand(barrio1_id, barrio1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO1_IDCommand(decimal barrio1_id, bool barrio1_idNull)
		{
			string whereSql = "";
			if(barrio1_idNull)
				whereSql += "BARRIO1_ID IS NULL";
			else
				whereSql += "BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio1_idNull)
				AddParameter(cmd, "BARRIO1_ID", barrio1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByBARRIO2_ID(decimal barrio2_id)
		{
			return GetByBARRIO2_ID(barrio2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByBARRIO2_ID(decimal barrio2_id, bool barrio2_idNull)
		{
			return MapRecords(CreateGetByBARRIO2_IDCommand(barrio2_id, barrio2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO2_IDAsDataTable(decimal barrio2_id)
		{
			return GetByBARRIO2_IDAsDataTable(barrio2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO2_IDAsDataTable(decimal barrio2_id, bool barrio2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO2_IDCommand(barrio2_id, barrio2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO2_IDCommand(decimal barrio2_id, bool barrio2_idNull)
		{
			string whereSql = "";
			if(barrio2_idNull)
				whereSql += "BARRIO2_ID IS NULL";
			else
				whereSql += "BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio2_idNull)
				AddParameter(cmd, "BARRIO2_ID", barrio2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByCIUDAD_COBRANZA_ID(decimal ciudad_cobranza_id)
		{
			return GetByCIUDAD_COBRANZA_ID(ciudad_cobranza_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <param name="ciudad_cobranza_idNull">true if the method ignores the ciudad_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByCIUDAD_COBRANZA_ID(decimal ciudad_cobranza_id, bool ciudad_cobranza_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_COBRANZA_IDCommand(ciudad_cobranza_id, ciudad_cobranza_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_COBRANZA_IDAsDataTable(decimal ciudad_cobranza_id)
		{
			return GetByCIUDAD_COBRANZA_IDAsDataTable(ciudad_cobranza_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <param name="ciudad_cobranza_idNull">true if the method ignores the ciudad_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD_COBRANZA_IDAsDataTable(decimal ciudad_cobranza_id, bool ciudad_cobranza_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD_COBRANZA_IDCommand(ciudad_cobranza_id, ciudad_cobranza_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <param name="ciudad_cobranza_idNull">true if the method ignores the ciudad_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD_COBRANZA_IDCommand(decimal ciudad_cobranza_id, bool ciudad_cobranza_idNull)
		{
			string whereSql = "";
			if(ciudad_cobranza_idNull)
				whereSql += "CIUDAD_COBRANZA_ID IS NULL";
			else
				whereSql += "CIUDAD_COBRANZA_ID=" + _db.CreateSqlParameterName("CIUDAD_COBRANZA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad_cobranza_idNull)
				AddParameter(cmd, "CIUDAD_COBRANZA_ID", ciudad_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByPERSONA_CALIFICACION_ID(decimal persona_calificacion_id)
		{
			return GetByPERSONA_CALIFICACION_ID(persona_calificacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <param name="persona_calificacion_idNull">true if the method ignores the persona_calificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByPERSONA_CALIFICACION_ID(decimal persona_calificacion_id, bool persona_calificacion_idNull)
		{
			return MapRecords(CreateGetByPERSONA_CALIFICACION_IDCommand(persona_calificacion_id, persona_calificacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_CALIFICACION_IDAsDataTable(decimal persona_calificacion_id)
		{
			return GetByPERSONA_CALIFICACION_IDAsDataTable(persona_calificacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <param name="persona_calificacion_idNull">true if the method ignores the persona_calificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_CALIFICACION_IDAsDataTable(decimal persona_calificacion_id, bool persona_calificacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_CALIFICACION_IDCommand(persona_calificacion_id, persona_calificacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <param name="persona_calificacion_idNull">true if the method ignores the persona_calificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_CALIFICACION_IDCommand(decimal persona_calificacion_id, bool persona_calificacion_idNull)
		{
			string whereSql = "";
			if(persona_calificacion_idNull)
				whereSql += "PERSONA_CALIFICACION_ID IS NULL";
			else
				whereSql += "PERSONA_CALIFICACION_ID=" + _db.CreateSqlParameterName("PERSONA_CALIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_calificacion_idNull)
				AddParameter(cmd, "PERSONA_CALIFICACION_ID", persona_calificacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByCIUDAD1_ID(decimal ciudad1_id)
		{
			return GetByCIUDAD1_ID(ciudad1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByCIUDAD1_ID(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return MapRecords(CreateGetByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD1_IDAsDataTable(decimal ciudad1_id)
		{
			return GetByCIUDAD1_IDAsDataTable(ciudad1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD1_IDAsDataTable(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD1_IDCommand(decimal ciudad1_id, bool ciudad1_idNull)
		{
			string whereSql = "";
			if(ciudad1_idNull)
				whereSql += "CIUDAD1_ID IS NULL";
			else
				whereSql += "CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad1_idNull)
				AddParameter(cmd, "CIUDAD1_ID", ciudad1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByCIUDAD2_ID(decimal ciudad2_id)
		{
			return GetByCIUDAD2_ID(ciudad2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByCIUDAD2_ID(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return MapRecords(CreateGetByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD2_IDAsDataTable(decimal ciudad2_id)
		{
			return GetByCIUDAD2_IDAsDataTable(ciudad2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD2_IDAsDataTable(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD2_IDCommand(decimal ciudad2_id, bool ciudad2_idNull)
		{
			string whereSql = "";
			if(ciudad2_idNull)
				whereSql += "CIUDAD2_ID IS NULL";
			else
				whereSql += "CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad2_idNull)
				AddParameter(cmd, "CIUDAD2_ID", ciudad2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByCOBRADOR_HABITUAL_ID(decimal cobrador_habitual_id)
		{
			return GetByCOBRADOR_HABITUAL_ID(cobrador_habitual_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <param name="cobrador_habitual_idNull">true if the method ignores the cobrador_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByCOBRADOR_HABITUAL_ID(decimal cobrador_habitual_id, bool cobrador_habitual_idNull)
		{
			return MapRecords(CreateGetByCOBRADOR_HABITUAL_IDCommand(cobrador_habitual_id, cobrador_habitual_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOBRADOR_HABITUAL_IDAsDataTable(decimal cobrador_habitual_id)
		{
			return GetByCOBRADOR_HABITUAL_IDAsDataTable(cobrador_habitual_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <param name="cobrador_habitual_idNull">true if the method ignores the cobrador_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOBRADOR_HABITUAL_IDAsDataTable(decimal cobrador_habitual_id, bool cobrador_habitual_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOBRADOR_HABITUAL_IDCommand(cobrador_habitual_id, cobrador_habitual_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <param name="cobrador_habitual_idNull">true if the method ignores the cobrador_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOBRADOR_HABITUAL_IDCommand(decimal cobrador_habitual_id, bool cobrador_habitual_idNull)
		{
			string whereSql = "";
			if(cobrador_habitual_idNull)
				whereSql += "COBRADOR_HABITUAL_ID IS NULL";
			else
				whereSql += "COBRADOR_HABITUAL_ID=" + _db.CreateSqlParameterName("COBRADOR_HABITUAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!cobrador_habitual_idNull)
				AddParameter(cmd, "COBRADOR_HABITUAL_ID", cobrador_habitual_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CONDICION_HAB_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByCONDICION_HABITUAL_PAGO_ID(decimal condicion_habitual_pago_id)
		{
			return MapRecords(CreateGetByCONDICION_HABITUAL_PAGO_IDCommand(condicion_habitual_pago_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CONDICION_HAB_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_HABITUAL_PAGO_IDAsDataTable(decimal condicion_habitual_pago_id)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_HABITUAL_PAGO_IDCommand(condicion_habitual_pago_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_CONDICION_HAB_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_HABITUAL_PAGO_IDCommand(decimal condicion_habitual_pago_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_HABITUAL_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID", condicion_habitual_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByPERSONA_ID_CONYUGE(decimal persona_id_conyuge)
		{
			return GetByPERSONA_ID_CONYUGE(persona_id_conyuge, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <param name="persona_id_conyugeNull">true if the method ignores the persona_id_conyuge
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByPERSONA_ID_CONYUGE(decimal persona_id_conyuge, bool persona_id_conyugeNull)
		{
			return MapRecords(CreateGetByPERSONA_ID_CONYUGECommand(persona_id_conyuge, persona_id_conyugeNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_ID_CONYUGEAsDataTable(decimal persona_id_conyuge)
		{
			return GetByPERSONA_ID_CONYUGEAsDataTable(persona_id_conyuge, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <param name="persona_id_conyugeNull">true if the method ignores the persona_id_conyuge
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_ID_CONYUGEAsDataTable(decimal persona_id_conyuge, bool persona_id_conyugeNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_ID_CONYUGECommand(persona_id_conyuge, persona_id_conyugeNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <param name="persona_id_conyugeNull">true if the method ignores the persona_id_conyuge
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_ID_CONYUGECommand(decimal persona_id_conyuge, bool persona_id_conyugeNull)
		{
			string whereSql = "";
			if(persona_id_conyugeNull)
				whereSql += "PERSONA_ID_CONYUGE IS NULL";
			else
				whereSql += "PERSONA_ID_CONYUGE=" + _db.CreateSqlParameterName("PERSONA_ID_CONYUGE");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_id_conyugeNull)
				AddParameter(cmd, "PERSONA_ID_CONYUGE", persona_id_conyuge);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByDEPARTAMENTO_COBRANZA_ID(decimal departamento_cobranza_id)
		{
			return GetByDEPARTAMENTO_COBRANZA_ID(departamento_cobranza_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <param name="departamento_cobranza_idNull">true if the method ignores the departamento_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByDEPARTAMENTO_COBRANZA_ID(decimal departamento_cobranza_id, bool departamento_cobranza_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_COBRANZA_IDCommand(departamento_cobranza_id, departamento_cobranza_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_COBRANZA_IDAsDataTable(decimal departamento_cobranza_id)
		{
			return GetByDEPARTAMENTO_COBRANZA_IDAsDataTable(departamento_cobranza_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <param name="departamento_cobranza_idNull">true if the method ignores the departamento_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO_COBRANZA_IDAsDataTable(decimal departamento_cobranza_id, bool departamento_cobranza_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO_COBRANZA_IDCommand(departamento_cobranza_id, departamento_cobranza_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <param name="departamento_cobranza_idNull">true if the method ignores the departamento_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO_COBRANZA_IDCommand(decimal departamento_cobranza_id, bool departamento_cobranza_idNull)
		{
			string whereSql = "";
			if(departamento_cobranza_idNull)
				whereSql += "DEPARTAMENTO_COBRANZA_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_COBRANZA_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_COBRANZA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento_cobranza_idNull)
				AddParameter(cmd, "DEPARTAMENTO_COBRANZA_ID", departamento_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByDEPARTAMENTO1_ID(decimal departamento1_id)
		{
			return GetByDEPARTAMENTO1_ID(departamento1_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByDEPARTAMENTO1_ID(decimal departamento1_id, bool departamento1_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO1_IDAsDataTable(decimal departamento1_id)
		{
			return GetByDEPARTAMENTO1_IDAsDataTable(departamento1_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO1_IDAsDataTable(decimal departamento1_id, bool departamento1_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO1_IDCommand(decimal departamento1_id, bool departamento1_idNull)
		{
			string whereSql = "";
			if(departamento1_idNull)
				whereSql += "DEPARTAMENTO1_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento1_idNull)
				AddParameter(cmd, "DEPARTAMENTO1_ID", departamento1_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByDEPARTAMENTO2_ID(decimal departamento2_id)
		{
			return GetByDEPARTAMENTO2_ID(departamento2_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByDEPARTAMENTO2_ID(decimal departamento2_id, bool departamento2_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO2_IDAsDataTable(decimal departamento2_id)
		{
			return GetByDEPARTAMENTO2_IDAsDataTable(departamento2_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO2_IDAsDataTable(decimal departamento2_id, bool departamento2_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO2_IDCommand(decimal departamento2_id, bool departamento2_idNull)
		{
			string whereSql = "";
			if(departamento2_idNull)
				whereSql += "DEPARTAMENTO2_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento2_idNull)
				AddParameter(cmd, "DEPARTAMENTO2_ID", departamento2_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByESTADO_CIVIL_ID(string estado_civil_id)
		{
			return MapRecords(CreateGetByESTADO_CIVIL_IDCommand(estado_civil_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_CIVIL_IDAsDataTable(string estado_civil_id)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_CIVIL_IDCommand(estado_civil_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_CIVIL_IDCommand(string estado_civil_id)
		{
			string whereSql = "";
			if(null == estado_civil_id)
				whereSql += "ESTADO_CIVIL_ID IS NULL";
			else
				whereSql += "ESTADO_CIVIL_ID=" + _db.CreateSqlParameterName("ESTADO_CIVIL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != estado_civil_id)
				AddParameter(cmd, "ESTADO_CIVIL_ID", estado_civil_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecords(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_IDAsDataTable(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByESTADO_MOROSIDAD_ID(decimal estado_morosidad_id)
		{
			return GetByESTADO_MOROSIDAD_ID(estado_morosidad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="estado_morosidad_idNull">true if the method ignores the estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByESTADO_MOROSIDAD_ID(decimal estado_morosidad_id, bool estado_morosidad_idNull)
		{
			return MapRecords(CreateGetByESTADO_MOROSIDAD_IDCommand(estado_morosidad_id, estado_morosidad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByESTADO_MOROSIDAD_IDAsDataTable(decimal estado_morosidad_id)
		{
			return GetByESTADO_MOROSIDAD_IDAsDataTable(estado_morosidad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="estado_morosidad_idNull">true if the method ignores the estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_MOROSIDAD_IDAsDataTable(decimal estado_morosidad_id, bool estado_morosidad_idNull)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_MOROSIDAD_IDCommand(estado_morosidad_id, estado_morosidad_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="estado_morosidad_idNull">true if the method ignores the estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_MOROSIDAD_IDCommand(decimal estado_morosidad_id, bool estado_morosidad_idNull)
		{
			string whereSql = "";
			if(estado_morosidad_idNull)
				whereSql += "ESTADO_MOROSIDAD_ID IS NULL";
			else
				whereSql += "ESTADO_MOROSIDAD_ID=" + _db.CreateSqlParameterName("ESTADO_MOROSIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!estado_morosidad_idNull)
				AddParameter(cmd, "ESTADO_MOROSIDAD_ID", estado_morosidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByLISTA_PRECIOS_ID(decimal lista_precios_id)
		{
			return GetByLISTA_PRECIOS_ID(lista_precios_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByLISTA_PRECIOS_ID(decimal lista_precios_id, bool lista_precios_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIOS_IDCommand(lista_precios_id, lista_precios_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIOS_IDAsDataTable(decimal lista_precios_id)
		{
			return GetByLISTA_PRECIOS_IDAsDataTable(lista_precios_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIOS_IDAsDataTable(decimal lista_precios_id, bool lista_precios_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIOS_IDCommand(lista_precios_id, lista_precios_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIOS_IDCommand(decimal lista_precios_id, bool lista_precios_idNull)
		{
			string whereSql = "";
			if(lista_precios_idNull)
				whereSql += "LISTA_PRECIOS_ID IS NULL";
			else
				whereSql += "LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lista_precios_idNull)
				AddParameter(cmd, "LISTA_PRECIOS_ID", lista_precios_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_MONEDA_LIM_CRED</c> foreign key.
		/// </summary>
		/// <param name="moneda_limite_credito_id">The <c>MONEDA_LIMITE_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByMONEDA_LIMITE_CREDITO_ID(decimal moneda_limite_credito_id)
		{
			return MapRecords(CreateGetByMONEDA_LIMITE_CREDITO_IDCommand(moneda_limite_credito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_MONEDA_LIM_CRED</c> foreign key.
		/// </summary>
		/// <param name="moneda_limite_credito_id">The <c>MONEDA_LIMITE_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_LIMITE_CREDITO_IDAsDataTable(decimal moneda_limite_credito_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_LIMITE_CREDITO_IDCommand(moneda_limite_credito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_MONEDA_LIM_CRED</c> foreign key.
		/// </summary>
		/// <param name="moneda_limite_credito_id">The <c>MONEDA_LIMITE_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_LIMITE_CREDITO_IDCommand(decimal moneda_limite_credito_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_LIMITE_CREDITO_ID=" + _db.CreateSqlParameterName("MONEDA_LIMITE_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_LIMITE_CREDITO_ID", moneda_limite_credito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByNIVEL_CREDITO_ID(decimal nivel_credito_id)
		{
			return GetByNIVEL_CREDITO_ID(nivel_credito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <param name="nivel_credito_idNull">true if the method ignores the nivel_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByNIVEL_CREDITO_ID(decimal nivel_credito_id, bool nivel_credito_idNull)
		{
			return MapRecords(CreateGetByNIVEL_CREDITO_IDCommand(nivel_credito_id, nivel_credito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNIVEL_CREDITO_IDAsDataTable(decimal nivel_credito_id)
		{
			return GetByNIVEL_CREDITO_IDAsDataTable(nivel_credito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <param name="nivel_credito_idNull">true if the method ignores the nivel_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNIVEL_CREDITO_IDAsDataTable(decimal nivel_credito_id, bool nivel_credito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNIVEL_CREDITO_IDCommand(nivel_credito_id, nivel_credito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <param name="nivel_credito_idNull">true if the method ignores the nivel_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNIVEL_CREDITO_IDCommand(decimal nivel_credito_id, bool nivel_credito_idNull)
		{
			string whereSql = "";
			if(nivel_credito_idNull)
				whereSql += "NIVEL_CREDITO_ID IS NULL";
			else
				whereSql += "NIVEL_CREDITO_ID=" + _db.CreateSqlParameterName("NIVEL_CREDITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nivel_credito_idNull)
				AddParameter(cmd, "NIVEL_CREDITO_ID", nivel_credito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByPERSONA_PADRE_ID(decimal persona_padre_id)
		{
			return GetByPERSONA_PADRE_ID(persona_padre_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <param name="persona_padre_idNull">true if the method ignores the persona_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByPERSONA_PADRE_ID(decimal persona_padre_id, bool persona_padre_idNull)
		{
			return MapRecords(CreateGetByPERSONA_PADRE_IDCommand(persona_padre_id, persona_padre_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_PADRE_IDAsDataTable(decimal persona_padre_id)
		{
			return GetByPERSONA_PADRE_IDAsDataTable(persona_padre_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <param name="persona_padre_idNull">true if the method ignores the persona_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_PADRE_IDAsDataTable(decimal persona_padre_id, bool persona_padre_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_PADRE_IDCommand(persona_padre_id, persona_padre_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <param name="persona_padre_idNull">true if the method ignores the persona_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_PADRE_IDCommand(decimal persona_padre_id, bool persona_padre_idNull)
		{
			string whereSql = "";
			if(persona_padre_idNull)
				whereSql += "PERSONA_PADRE_ID IS NULL";
			else
				whereSql += "PERSONA_PADRE_ID=" + _db.CreateSqlParameterName("PERSONA_PADRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_padre_idNull)
				AddParameter(cmd, "PERSONA_PADRE_ID", persona_padre_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id)
		{
			return GetByPAIS_NACIONALIDAD_ID(pais_nacionalidad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			return MapRecords(CreateGetByPAIS_NACIONALIDAD_IDCommand(pais_nacionalidad_id, pais_nacionalidad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPAIS_NACIONALIDAD_IDAsDataTable(decimal pais_nacionalidad_id)
		{
			return GetByPAIS_NACIONALIDAD_IDAsDataTable(pais_nacionalidad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_NACIONALIDAD_IDAsDataTable(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_NACIONALIDAD_IDCommand(pais_nacionalidad_id, pais_nacionalidad_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_NACIONALIDAD_IDCommand(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			string whereSql = "";
			if(pais_nacionalidad_idNull)
				whereSql += "PAIS_NACIONALIDAD_ID IS NULL";
			else
				whereSql += "PAIS_NACIONALIDAD_ID=" + _db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pais_nacionalidad_idNull)
				AddParameter(cmd, "PAIS_NACIONALIDAD_ID", pais_nacionalidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByPAIS_RESIDENCIA_ID(decimal pais_residencia_id)
		{
			return GetByPAIS_RESIDENCIA_ID(pais_residencia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByPAIS_RESIDENCIA_ID(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			return MapRecords(CreateGetByPAIS_RESIDENCIA_IDCommand(pais_residencia_id, pais_residencia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPAIS_RESIDENCIA_IDAsDataTable(decimal pais_residencia_id)
		{
			return GetByPAIS_RESIDENCIA_IDAsDataTable(pais_residencia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_RESIDENCIA_IDAsDataTable(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_RESIDENCIA_IDCommand(pais_residencia_id, pais_residencia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_RESIDENCIA_IDCommand(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			string whereSql = "";
			if(pais_residencia_idNull)
				whereSql += "PAIS_RESIDENCIA_ID IS NULL";
			else
				whereSql += "PAIS_RESIDENCIA_ID=" + _db.CreateSqlParameterName("PAIS_RESIDENCIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pais_residencia_idNull)
				AddParameter(cmd, "PAIS_RESIDENCIA_ID", pais_residencia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByPROFESION_ID(string profesion_id)
		{
			return MapRecords(CreateGetByPROFESION_IDCommand(profesion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROFESION_IDAsDataTable(string profesion_id)
		{
			return MapRecordsToDataTable(CreateGetByPROFESION_IDCommand(profesion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROFESION_IDCommand(string profesion_id)
		{
			string whereSql = "";
			if(null == profesion_id)
				whereSql += "PROFESION_ID IS NULL";
			else
				whereSql += "PROFESION_ID=" + _db.CreateSqlParameterName("PROFESION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != profesion_id)
				AddParameter(cmd, "PROFESION_ID", profesion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByRUBRO_ID(decimal rubro_id)
		{
			return GetByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecords(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id)
		{
			return GetByRUBRO_IDAsDataTable(rubro_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRUBRO_IDAsDataTable(decimal rubro_id, bool rubro_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRUBRO_IDCommand(rubro_id, rubro_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRUBRO_IDCommand(decimal rubro_id, bool rubro_idNull)
		{
			string whereSql = "";
			if(rubro_idNull)
				whereSql += "RUBRO_ID IS NULL";
			else
				whereSql += "RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rubro_idNull)
				AddParameter(cmd, "RUBRO_ID", rubro_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByTIPO_CLIENTE_ID(decimal tipo_cliente_id)
		{
			return GetByTIPO_CLIENTE_ID(tipo_cliente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByTIPO_CLIENTE_ID(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			return MapRecords(CreateGetByTIPO_CLIENTE_IDCommand(tipo_cliente_id, tipo_cliente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_CLIENTE_IDAsDataTable(decimal tipo_cliente_id)
		{
			return GetByTIPO_CLIENTE_IDAsDataTable(tipo_cliente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CLIENTE_IDAsDataTable(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CLIENTE_IDCommand(tipo_cliente_id, tipo_cliente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CLIENTE_IDCommand(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			string whereSql = "";
			if(tipo_cliente_idNull)
				whereSql += "TIPO_CLIENTE_ID IS NULL";
			else
				whereSql += "TIPO_CLIENTE_ID=" + _db.CreateSqlParameterName("TIPO_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_cliente_idNull)
				AddParameter(cmd, "TIPO_CLIENTE_ID", tipo_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByTIPO_DOCUMENTO_IDENTIDAD_ID(string tipo_documento_identidad_id)
		{
			return MapRecords(CreateGetByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(tipo_documento_identidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_DOCUMENTO_IDENTIDAD_IDAsDataTable(string tipo_documento_identidad_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(tipo_documento_identidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(string tipo_documento_identidad_id)
		{
			string whereSql = "";
			if(null == tipo_documento_identidad_id)
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID IS NULL";
			else
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID=" + _db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tipo_documento_identidad_id)
				AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", tipo_documento_identidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByTRATAMIENTO_ID(string tratamiento_id)
		{
			return MapRecords(CreateGetByTRATAMIENTO_IDCommand(tratamiento_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRATAMIENTO_IDAsDataTable(string tratamiento_id)
		{
			return MapRecordsToDataTable(CreateGetByTRATAMIENTO_IDCommand(tratamiento_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRATAMIENTO_IDCommand(string tratamiento_id)
		{
			string whereSql = "";
			if(null == tratamiento_id)
				whereSql += "TRATAMIENTO_ID IS NULL";
			else
				whereSql += "TRATAMIENTO_ID=" + _db.CreateSqlParameterName("TRATAMIENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tratamiento_id)
				AddParameter(cmd, "TRATAMIENTO_ID", tratamiento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id)
		{
			return GetByUSUARIO_APROBACION_IDAsDataTable(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_APROBACION_IDAsDataTable(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByVENDEDOR_HABITUAL_ID(decimal vendedor_habitual_id)
		{
			return GetByVENDEDOR_HABITUAL_ID(vendedor_habitual_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <param name="vendedor_habitual_idNull">true if the method ignores the vendedor_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByVENDEDOR_HABITUAL_ID(decimal vendedor_habitual_id, bool vendedor_habitual_idNull)
		{
			return MapRecords(CreateGetByVENDEDOR_HABITUAL_IDCommand(vendedor_habitual_id, vendedor_habitual_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVENDEDOR_HABITUAL_IDAsDataTable(decimal vendedor_habitual_id)
		{
			return GetByVENDEDOR_HABITUAL_IDAsDataTable(vendedor_habitual_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <param name="vendedor_habitual_idNull">true if the method ignores the vendedor_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVENDEDOR_HABITUAL_IDAsDataTable(decimal vendedor_habitual_id, bool vendedor_habitual_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVENDEDOR_HABITUAL_IDCommand(vendedor_habitual_id, vendedor_habitual_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <param name="vendedor_habitual_idNull">true if the method ignores the vendedor_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVENDEDOR_HABITUAL_IDCommand(decimal vendedor_habitual_id, bool vendedor_habitual_idNull)
		{
			string whereSql = "";
			if(vendedor_habitual_idNull)
				whereSql += "VENDEDOR_HABITUAL_ID IS NULL";
			else
				whereSql += "VENDEDOR_HABITUAL_ID=" + _db.CreateSqlParameterName("VENDEDOR_HABITUAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vendedor_habitual_idNull)
				AddParameter(cmd, "VENDEDOR_HABITUAL_ID", vendedor_habitual_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public PERSONASRow[] GetByZONA_COBRANZA_ID(decimal zona_cobranza_id)
		{
			return GetByZONA_COBRANZA_ID(zona_cobranza_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONASRow"/> objects 
		/// by the <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <param name="zona_cobranza_idNull">true if the method ignores the zona_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		public virtual PERSONASRow[] GetByZONA_COBRANZA_ID(decimal zona_cobranza_id, bool zona_cobranza_idNull)
		{
			return MapRecords(CreateGetByZONA_COBRANZA_IDCommand(zona_cobranza_id, zona_cobranza_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByZONA_COBRANZA_IDAsDataTable(decimal zona_cobranza_id)
		{
			return GetByZONA_COBRANZA_IDAsDataTable(zona_cobranza_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <param name="zona_cobranza_idNull">true if the method ignores the zona_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByZONA_COBRANZA_IDAsDataTable(decimal zona_cobranza_id, bool zona_cobranza_idNull)
		{
			return MapRecordsToDataTable(CreateGetByZONA_COBRANZA_IDCommand(zona_cobranza_id, zona_cobranza_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <param name="zona_cobranza_idNull">true if the method ignores the zona_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByZONA_COBRANZA_IDCommand(decimal zona_cobranza_id, bool zona_cobranza_idNull)
		{
			string whereSql = "";
			if(zona_cobranza_idNull)
				whereSql += "ZONA_COBRANZA_ID IS NULL";
			else
				whereSql += "ZONA_COBRANZA_ID=" + _db.CreateSqlParameterName("ZONA_COBRANZA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!zona_cobranza_idNull)
				AddParameter(cmd, "ZONA_COBRANZA_ID", zona_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONASRow"/> object to be inserted.</param>
		public virtual void Insert(PERSONASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PERSONAS (" +
				"ID, " +
				"CODIGO, " +
				"ENTIDAD_ID, " +
				"FISICO, " +
				"MAYORISTA, " +
				"TRATAMIENTO_ID, " +
				"NOMBRE, " +
				"APELLIDO, " +
				"NOMBRE_COMPLETO, " +
				"NOMBRE_FANTASIA, " +
				"GENERO, " +
				"RUC, " +
				"NACIMIENTO, " +
				"TIPO_DOCUMENTO_IDENTIDAD_ID, " +
				"NUMERO_DOCUMENTO, " +
				"PAIS_NACIONALIDAD_ID, " +
				"PAIS_RESIDENCIA_ID, " +
				"EN_INFORMCONF, " +
				"FECHA_MODIFICACION_INFORMCONF, " +
				"EN_JUDICIAL, " +
				"ES_CLIENTE, " +
				"POSEE_UNIPERSONAL, " +
				"EMPRESA_NOMBRE_FANTASIA, " +
				"FECHA_MODIFICACION_JUDICIAL, " +
				"ABOGADO_ID, " +
				"PROFESION_ID, " +
				"DEPARTAMENTO1_ID, " +
				"CIUDAD1_ID, " +
				"BARRIO1_ID, " +
				"CALLE1, " +
				"CODIGO_POSTAL1, " +
				"LATITUD1, " +
				"LONGITUD1, " +
				"DEPARTAMENTO2_ID, " +
				"CIUDAD2_ID, " +
				"BARRIO2_ID, " +
				"CALLE2, " +
				"CODIGO_POSTAL2, " +
				"LATITUD2, " +
				"LONGITUD2, " +
				"TELEFONO1, " +
				"TELEFONO2, " +
				"TELEFONO3, " +
				"TELEFONO4, " +
				"EMAIL1, " +
				"EMAIL2, " +
				"EMAIL3, " +
				"RUBRO_ID, " +
				"EMPRESA_FUNDACION, " +
				"EMPRESA_PERSONA_CONTACTO, " +
				"EMPRESA_TELEFONO_CONTACTO, " +
				"MONEDA_ID, " +
				"OPERA_CREDITO, " +
				"CONDICION_HABITUAL_PAGO_ID, " +
				"MONEDA_LIMITE_CREDITO_ID, " +
				"CONTADOR_CREDITO_ACTUAL, " +
				"VENDEDOR_HABITUAL_ID, " +
				"COBRADOR_HABITUAL_ID, " +
				"DEPARTAMENTO_COBRANZA_ID, " +
				"CIUDAD_COBRANZA_ID, " +
				"BARRIO_COBRANZA_ID, " +
				"CALLE_COBRANZA, " +
				"CODIGO_POSTAL_COBRANZA, " +
				"LATITUD_COBRANZA, " +
				"LONGITUD_COBRANZA, " +
				"TELEFONO_COBRANZA1, " +
				"TELEFONO_COBRANZA2, " +
				"CONYUGE_NOMBRE, " +
				"CONYUGE_APELLIDO, " +
				"ESTADO_DOCUMENTACION_ID, " +
				"NIVEL_CREDITO_ID, " +
				"AGENTE_RETENCION, " +
				"BANDERA_RETENCION, " +
				"ESTADO, " +
				"INGRESO_APROBADO, " +
				"USUARIO_APROBACION_ID, " +
				"FECHA_APROBACION, " +
				"GRUPO_SANGUINEO, " +
				"ESTADO_CIVIL_ID, " +
				"PERSONA_ID_CONYUGE, " +
				"NUMERO_HIJOS, " +
				"TIPO_EMPLEO, " +
				"SEPARACION_BIENES, " +
				"PORC_DESCUENTO_AUTOMATICO, " +
				"PERSONA_CALIFICACION_ID, " +
				"ZONA_COBRANZA_ID, " +
				"TIPO_CLIENTE_ID, " +
				"ESTADO_MOROSIDAD_ID, " +
				"MODIFICABLE, " +
				"ES_CONTRIBUYENTE, " +
				"NRO_TARJETA_RED_PAGO, " +
				"CENTRO_COSTO_ID, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"CODIGO_EXTERNO, " +
				"FECHA_ULTIMA_VISITA, " +
				"FECHA_ULTIMA_ACTUALIZAC_DATOS, " +
				"PERSONA_PADRE_ID, " +
				"LISTA_PRECIOS_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("FISICO") + ", " +
				_db.CreateSqlParameterName("MAYORISTA") + ", " +
				_db.CreateSqlParameterName("TRATAMIENTO_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("APELLIDO") + ", " +
				_db.CreateSqlParameterName("NOMBRE_COMPLETO") + ", " +
				_db.CreateSqlParameterName("NOMBRE_FANTASIA") + ", " +
				_db.CreateSqlParameterName("GENERO") + ", " +
				_db.CreateSqlParameterName("RUC") + ", " +
				_db.CreateSqlParameterName("NACIMIENTO") + ", " +
				_db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID") + ", " +
				_db.CreateSqlParameterName("PAIS_RESIDENCIA_ID") + ", " +
				_db.CreateSqlParameterName("EN_INFORMCONF") + ", " +
				_db.CreateSqlParameterName("FECHA_MODIFICACION_INFORMCONF") + ", " +
				_db.CreateSqlParameterName("EN_JUDICIAL") + ", " +
				_db.CreateSqlParameterName("ES_CLIENTE") + ", " +
				_db.CreateSqlParameterName("POSEE_UNIPERSONAL") + ", " +
				_db.CreateSqlParameterName("EMPRESA_NOMBRE_FANTASIA") + ", " +
				_db.CreateSqlParameterName("FECHA_MODIFICACION_JUDICIAL") + ", " +
				_db.CreateSqlParameterName("ABOGADO_ID") + ", " +
				_db.CreateSqlParameterName("PROFESION_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO1_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD1_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO1_ID") + ", " +
				_db.CreateSqlParameterName("CALLE1") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL1") + ", " +
				_db.CreateSqlParameterName("LATITUD1") + ", " +
				_db.CreateSqlParameterName("LONGITUD1") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO2_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD2_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO2_ID") + ", " +
				_db.CreateSqlParameterName("CALLE2") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL2") + ", " +
				_db.CreateSqlParameterName("LATITUD2") + ", " +
				_db.CreateSqlParameterName("LONGITUD2") + ", " +
				_db.CreateSqlParameterName("TELEFONO1") + ", " +
				_db.CreateSqlParameterName("TELEFONO2") + ", " +
				_db.CreateSqlParameterName("TELEFONO3") + ", " +
				_db.CreateSqlParameterName("TELEFONO4") + ", " +
				_db.CreateSqlParameterName("EMAIL1") + ", " +
				_db.CreateSqlParameterName("EMAIL2") + ", " +
				_db.CreateSqlParameterName("EMAIL3") + ", " +
				_db.CreateSqlParameterName("RUBRO_ID") + ", " +
				_db.CreateSqlParameterName("EMPRESA_FUNDACION") + ", " +
				_db.CreateSqlParameterName("EMPRESA_PERSONA_CONTACTO") + ", " +
				_db.CreateSqlParameterName("EMPRESA_TELEFONO_CONTACTO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("OPERA_CREDITO") + ", " +
				_db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_LIMITE_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("CONTADOR_CREDITO_ACTUAL") + ", " +
				_db.CreateSqlParameterName("VENDEDOR_HABITUAL_ID") + ", " +
				_db.CreateSqlParameterName("COBRADOR_HABITUAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_COBRANZA_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD_COBRANZA_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO_COBRANZA_ID") + ", " +
				_db.CreateSqlParameterName("CALLE_COBRANZA") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL_COBRANZA") + ", " +
				_db.CreateSqlParameterName("LATITUD_COBRANZA") + ", " +
				_db.CreateSqlParameterName("LONGITUD_COBRANZA") + ", " +
				_db.CreateSqlParameterName("TELEFONO_COBRANZA1") + ", " +
				_db.CreateSqlParameterName("TELEFONO_COBRANZA2") + ", " +
				_db.CreateSqlParameterName("CONYUGE_NOMBRE") + ", " +
				_db.CreateSqlParameterName("CONYUGE_APELLIDO") + ", " +
				_db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				_db.CreateSqlParameterName("NIVEL_CREDITO_ID") + ", " +
				_db.CreateSqlParameterName("AGENTE_RETENCION") + ", " +
				_db.CreateSqlParameterName("BANDERA_RETENCION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				_db.CreateSqlParameterName("GRUPO_SANGUINEO") + ", " +
				_db.CreateSqlParameterName("ESTADO_CIVIL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID_CONYUGE") + ", " +
				_db.CreateSqlParameterName("NUMERO_HIJOS") + ", " +
				_db.CreateSqlParameterName("TIPO_EMPLEO") + ", " +
				_db.CreateSqlParameterName("SEPARACION_BIENES") + ", " +
				_db.CreateSqlParameterName("PORC_DESCUENTO_AUTOMATICO") + ", " +
				_db.CreateSqlParameterName("PERSONA_CALIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("ZONA_COBRANZA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO_MOROSIDAD_ID") + ", " +
				_db.CreateSqlParameterName("MODIFICABLE") + ", " +
				_db.CreateSqlParameterName("ES_CONTRIBUYENTE") + ", " +
				_db.CreateSqlParameterName("NRO_TARJETA_RED_PAGO") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_EXTERNO") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMA_VISITA") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMA_ACTUALIZAC_DATOS") + ", " +
				_db.CreateSqlParameterName("PERSONA_PADRE_ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIOS_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "FISICO", value.FISICO);
			AddParameter(cmd, "MAYORISTA", value.MAYORISTA);
			AddParameter(cmd, "TRATAMIENTO_ID", value.TRATAMIENTO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "NOMBRE_COMPLETO", value.NOMBRE_COMPLETO);
			AddParameter(cmd, "NOMBRE_FANTASIA", value.NOMBRE_FANTASIA);
			AddParameter(cmd, "GENERO", value.GENERO);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "NACIMIENTO",
				value.IsNACIMIENTONull ? DBNull.Value : (object)value.NACIMIENTO);
			AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", value.TIPO_DOCUMENTO_IDENTIDAD_ID);
			AddParameter(cmd, "NUMERO_DOCUMENTO", value.NUMERO_DOCUMENTO);
			AddParameter(cmd, "PAIS_NACIONALIDAD_ID",
				value.IsPAIS_NACIONALIDAD_IDNull ? DBNull.Value : (object)value.PAIS_NACIONALIDAD_ID);
			AddParameter(cmd, "PAIS_RESIDENCIA_ID",
				value.IsPAIS_RESIDENCIA_IDNull ? DBNull.Value : (object)value.PAIS_RESIDENCIA_ID);
			AddParameter(cmd, "EN_INFORMCONF", value.EN_INFORMCONF);
			AddParameter(cmd, "FECHA_MODIFICACION_INFORMCONF",
				value.IsFECHA_MODIFICACION_INFORMCONFNull ? DBNull.Value : (object)value.FECHA_MODIFICACION_INFORMCONF);
			AddParameter(cmd, "EN_JUDICIAL", value.EN_JUDICIAL);
			AddParameter(cmd, "ES_CLIENTE", value.ES_CLIENTE);
			AddParameter(cmd, "POSEE_UNIPERSONAL", value.POSEE_UNIPERSONAL);
			AddParameter(cmd, "EMPRESA_NOMBRE_FANTASIA", value.EMPRESA_NOMBRE_FANTASIA);
			AddParameter(cmd, "FECHA_MODIFICACION_JUDICIAL",
				value.IsFECHA_MODIFICACION_JUDICIALNull ? DBNull.Value : (object)value.FECHA_MODIFICACION_JUDICIAL);
			AddParameter(cmd, "ABOGADO_ID",
				value.IsABOGADO_IDNull ? DBNull.Value : (object)value.ABOGADO_ID);
			AddParameter(cmd, "PROFESION_ID", value.PROFESION_ID);
			AddParameter(cmd, "DEPARTAMENTO1_ID",
				value.IsDEPARTAMENTO1_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO1_ID);
			AddParameter(cmd, "CIUDAD1_ID",
				value.IsCIUDAD1_IDNull ? DBNull.Value : (object)value.CIUDAD1_ID);
			AddParameter(cmd, "BARRIO1_ID",
				value.IsBARRIO1_IDNull ? DBNull.Value : (object)value.BARRIO1_ID);
			AddParameter(cmd, "CALLE1", value.CALLE1);
			AddParameter(cmd, "CODIGO_POSTAL1", value.CODIGO_POSTAL1);
			AddParameter(cmd, "LATITUD1",
				value.IsLATITUD1Null ? DBNull.Value : (object)value.LATITUD1);
			AddParameter(cmd, "LONGITUD1",
				value.IsLONGITUD1Null ? DBNull.Value : (object)value.LONGITUD1);
			AddParameter(cmd, "DEPARTAMENTO2_ID",
				value.IsDEPARTAMENTO2_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO2_ID);
			AddParameter(cmd, "CIUDAD2_ID",
				value.IsCIUDAD2_IDNull ? DBNull.Value : (object)value.CIUDAD2_ID);
			AddParameter(cmd, "BARRIO2_ID",
				value.IsBARRIO2_IDNull ? DBNull.Value : (object)value.BARRIO2_ID);
			AddParameter(cmd, "CALLE2", value.CALLE2);
			AddParameter(cmd, "CODIGO_POSTAL2", value.CODIGO_POSTAL2);
			AddParameter(cmd, "LATITUD2",
				value.IsLATITUD2Null ? DBNull.Value : (object)value.LATITUD2);
			AddParameter(cmd, "LONGITUD2",
				value.IsLONGITUD2Null ? DBNull.Value : (object)value.LONGITUD2);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "EMPRESA_FUNDACION",
				value.IsEMPRESA_FUNDACIONNull ? DBNull.Value : (object)value.EMPRESA_FUNDACION);
			AddParameter(cmd, "EMPRESA_PERSONA_CONTACTO", value.EMPRESA_PERSONA_CONTACTO);
			AddParameter(cmd, "EMPRESA_TELEFONO_CONTACTO", value.EMPRESA_TELEFONO_CONTACTO);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "OPERA_CREDITO", value.OPERA_CREDITO);
			AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID", value.CONDICION_HABITUAL_PAGO_ID);
			AddParameter(cmd, "MONEDA_LIMITE_CREDITO_ID", value.MONEDA_LIMITE_CREDITO_ID);
			AddParameter(cmd, "CONTADOR_CREDITO_ACTUAL", value.CONTADOR_CREDITO_ACTUAL);
			AddParameter(cmd, "VENDEDOR_HABITUAL_ID",
				value.IsVENDEDOR_HABITUAL_IDNull ? DBNull.Value : (object)value.VENDEDOR_HABITUAL_ID);
			AddParameter(cmd, "COBRADOR_HABITUAL_ID",
				value.IsCOBRADOR_HABITUAL_IDNull ? DBNull.Value : (object)value.COBRADOR_HABITUAL_ID);
			AddParameter(cmd, "DEPARTAMENTO_COBRANZA_ID",
				value.IsDEPARTAMENTO_COBRANZA_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_COBRANZA_ID);
			AddParameter(cmd, "CIUDAD_COBRANZA_ID",
				value.IsCIUDAD_COBRANZA_IDNull ? DBNull.Value : (object)value.CIUDAD_COBRANZA_ID);
			AddParameter(cmd, "BARRIO_COBRANZA_ID",
				value.IsBARRIO_COBRANZA_IDNull ? DBNull.Value : (object)value.BARRIO_COBRANZA_ID);
			AddParameter(cmd, "CALLE_COBRANZA", value.CALLE_COBRANZA);
			AddParameter(cmd, "CODIGO_POSTAL_COBRANZA", value.CODIGO_POSTAL_COBRANZA);
			AddParameter(cmd, "LATITUD_COBRANZA",
				value.IsLATITUD_COBRANZANull ? DBNull.Value : (object)value.LATITUD_COBRANZA);
			AddParameter(cmd, "LONGITUD_COBRANZA",
				value.IsLONGITUD_COBRANZANull ? DBNull.Value : (object)value.LONGITUD_COBRANZA);
			AddParameter(cmd, "TELEFONO_COBRANZA1", value.TELEFONO_COBRANZA1);
			AddParameter(cmd, "TELEFONO_COBRANZA2", value.TELEFONO_COBRANZA2);
			AddParameter(cmd, "CONYUGE_NOMBRE", value.CONYUGE_NOMBRE);
			AddParameter(cmd, "CONYUGE_APELLIDO", value.CONYUGE_APELLIDO);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "NIVEL_CREDITO_ID",
				value.IsNIVEL_CREDITO_IDNull ? DBNull.Value : (object)value.NIVEL_CREDITO_ID);
			AddParameter(cmd, "AGENTE_RETENCION", value.AGENTE_RETENCION);
			AddParameter(cmd, "BANDERA_RETENCION", value.BANDERA_RETENCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "GRUPO_SANGUINEO", value.GRUPO_SANGUINEO);
			AddParameter(cmd, "ESTADO_CIVIL_ID", value.ESTADO_CIVIL_ID);
			AddParameter(cmd, "PERSONA_ID_CONYUGE",
				value.IsPERSONA_ID_CONYUGENull ? DBNull.Value : (object)value.PERSONA_ID_CONYUGE);
			AddParameter(cmd, "NUMERO_HIJOS",
				value.IsNUMERO_HIJOSNull ? DBNull.Value : (object)value.NUMERO_HIJOS);
			AddParameter(cmd, "TIPO_EMPLEO", value.TIPO_EMPLEO);
			AddParameter(cmd, "SEPARACION_BIENES", value.SEPARACION_BIENES);
			AddParameter(cmd, "PORC_DESCUENTO_AUTOMATICO", value.PORC_DESCUENTO_AUTOMATICO);
			AddParameter(cmd, "PERSONA_CALIFICACION_ID",
				value.IsPERSONA_CALIFICACION_IDNull ? DBNull.Value : (object)value.PERSONA_CALIFICACION_ID);
			AddParameter(cmd, "ZONA_COBRANZA_ID",
				value.IsZONA_COBRANZA_IDNull ? DBNull.Value : (object)value.ZONA_COBRANZA_ID);
			AddParameter(cmd, "TIPO_CLIENTE_ID",
				value.IsTIPO_CLIENTE_IDNull ? DBNull.Value : (object)value.TIPO_CLIENTE_ID);
			AddParameter(cmd, "ESTADO_MOROSIDAD_ID",
				value.IsESTADO_MOROSIDAD_IDNull ? DBNull.Value : (object)value.ESTADO_MOROSIDAD_ID);
			AddParameter(cmd, "MODIFICABLE", value.MODIFICABLE);
			AddParameter(cmd, "ES_CONTRIBUYENTE", value.ES_CONTRIBUYENTE);
			AddParameter(cmd, "NRO_TARJETA_RED_PAGO",
				value.IsNRO_TARJETA_RED_PAGONull ? DBNull.Value : (object)value.NRO_TARJETA_RED_PAGO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CODIGO_EXTERNO", value.CODIGO_EXTERNO);
			AddParameter(cmd, "FECHA_ULTIMA_VISITA",
				value.IsFECHA_ULTIMA_VISITANull ? DBNull.Value : (object)value.FECHA_ULTIMA_VISITA);
			AddParameter(cmd, "FECHA_ULTIMA_ACTUALIZAC_DATOS", value.FECHA_ULTIMA_ACTUALIZAC_DATOS);
			AddParameter(cmd, "PERSONA_PADRE_ID",
				value.IsPERSONA_PADRE_IDNull ? DBNull.Value : (object)value.PERSONA_PADRE_ID);
			AddParameter(cmd, "LISTA_PRECIOS_ID",
				value.IsLISTA_PRECIOS_IDNull ? DBNull.Value : (object)value.LISTA_PRECIOS_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PERSONASRow value)
		{
			
			string sqlStr = "UPDATE TRC.PERSONAS SET " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"FISICO=" + _db.CreateSqlParameterName("FISICO") + ", " +
				"MAYORISTA=" + _db.CreateSqlParameterName("MAYORISTA") + ", " +
				"TRATAMIENTO_ID=" + _db.CreateSqlParameterName("TRATAMIENTO_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"APELLIDO=" + _db.CreateSqlParameterName("APELLIDO") + ", " +
				"NOMBRE_COMPLETO=" + _db.CreateSqlParameterName("NOMBRE_COMPLETO") + ", " +
				"NOMBRE_FANTASIA=" + _db.CreateSqlParameterName("NOMBRE_FANTASIA") + ", " +
				"GENERO=" + _db.CreateSqlParameterName("GENERO") + ", " +
				"RUC=" + _db.CreateSqlParameterName("RUC") + ", " +
				"NACIMIENTO=" + _db.CreateSqlParameterName("NACIMIENTO") + ", " +
				"TIPO_DOCUMENTO_IDENTIDAD_ID=" + _db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID") + ", " +
				"NUMERO_DOCUMENTO=" + _db.CreateSqlParameterName("NUMERO_DOCUMENTO") + ", " +
				"PAIS_NACIONALIDAD_ID=" + _db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID") + ", " +
				"PAIS_RESIDENCIA_ID=" + _db.CreateSqlParameterName("PAIS_RESIDENCIA_ID") + ", " +
				"EN_INFORMCONF=" + _db.CreateSqlParameterName("EN_INFORMCONF") + ", " +
				"FECHA_MODIFICACION_INFORMCONF=" + _db.CreateSqlParameterName("FECHA_MODIFICACION_INFORMCONF") + ", " +
				"EN_JUDICIAL=" + _db.CreateSqlParameterName("EN_JUDICIAL") + ", " +
				"ES_CLIENTE=" + _db.CreateSqlParameterName("ES_CLIENTE") + ", " +
				"POSEE_UNIPERSONAL=" + _db.CreateSqlParameterName("POSEE_UNIPERSONAL") + ", " +
				"EMPRESA_NOMBRE_FANTASIA=" + _db.CreateSqlParameterName("EMPRESA_NOMBRE_FANTASIA") + ", " +
				"FECHA_MODIFICACION_JUDICIAL=" + _db.CreateSqlParameterName("FECHA_MODIFICACION_JUDICIAL") + ", " +
				"ABOGADO_ID=" + _db.CreateSqlParameterName("ABOGADO_ID") + ", " +
				"PROFESION_ID=" + _db.CreateSqlParameterName("PROFESION_ID") + ", " +
				"DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID") + ", " +
				"CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID") + ", " +
				"BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID") + ", " +
				"CALLE1=" + _db.CreateSqlParameterName("CALLE1") + ", " +
				"CODIGO_POSTAL1=" + _db.CreateSqlParameterName("CODIGO_POSTAL1") + ", " +
				"LATITUD1=" + _db.CreateSqlParameterName("LATITUD1") + ", " +
				"LONGITUD1=" + _db.CreateSqlParameterName("LONGITUD1") + ", " +
				"DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID") + ", " +
				"CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID") + ", " +
				"BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID") + ", " +
				"CALLE2=" + _db.CreateSqlParameterName("CALLE2") + ", " +
				"CODIGO_POSTAL2=" + _db.CreateSqlParameterName("CODIGO_POSTAL2") + ", " +
				"LATITUD2=" + _db.CreateSqlParameterName("LATITUD2") + ", " +
				"LONGITUD2=" + _db.CreateSqlParameterName("LONGITUD2") + ", " +
				"TELEFONO1=" + _db.CreateSqlParameterName("TELEFONO1") + ", " +
				"TELEFONO2=" + _db.CreateSqlParameterName("TELEFONO2") + ", " +
				"TELEFONO3=" + _db.CreateSqlParameterName("TELEFONO3") + ", " +
				"TELEFONO4=" + _db.CreateSqlParameterName("TELEFONO4") + ", " +
				"EMAIL1=" + _db.CreateSqlParameterName("EMAIL1") + ", " +
				"EMAIL2=" + _db.CreateSqlParameterName("EMAIL2") + ", " +
				"EMAIL3=" + _db.CreateSqlParameterName("EMAIL3") + ", " +
				"RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID") + ", " +
				"EMPRESA_FUNDACION=" + _db.CreateSqlParameterName("EMPRESA_FUNDACION") + ", " +
				"EMPRESA_PERSONA_CONTACTO=" + _db.CreateSqlParameterName("EMPRESA_PERSONA_CONTACTO") + ", " +
				"EMPRESA_TELEFONO_CONTACTO=" + _db.CreateSqlParameterName("EMPRESA_TELEFONO_CONTACTO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"OPERA_CREDITO=" + _db.CreateSqlParameterName("OPERA_CREDITO") + ", " +
				"CONDICION_HABITUAL_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID") + ", " +
				"MONEDA_LIMITE_CREDITO_ID=" + _db.CreateSqlParameterName("MONEDA_LIMITE_CREDITO_ID") + ", " +
				"CONTADOR_CREDITO_ACTUAL=" + _db.CreateSqlParameterName("CONTADOR_CREDITO_ACTUAL") + ", " +
				"VENDEDOR_HABITUAL_ID=" + _db.CreateSqlParameterName("VENDEDOR_HABITUAL_ID") + ", " +
				"COBRADOR_HABITUAL_ID=" + _db.CreateSqlParameterName("COBRADOR_HABITUAL_ID") + ", " +
				"DEPARTAMENTO_COBRANZA_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_COBRANZA_ID") + ", " +
				"CIUDAD_COBRANZA_ID=" + _db.CreateSqlParameterName("CIUDAD_COBRANZA_ID") + ", " +
				"BARRIO_COBRANZA_ID=" + _db.CreateSqlParameterName("BARRIO_COBRANZA_ID") + ", " +
				"CALLE_COBRANZA=" + _db.CreateSqlParameterName("CALLE_COBRANZA") + ", " +
				"CODIGO_POSTAL_COBRANZA=" + _db.CreateSqlParameterName("CODIGO_POSTAL_COBRANZA") + ", " +
				"LATITUD_COBRANZA=" + _db.CreateSqlParameterName("LATITUD_COBRANZA") + ", " +
				"LONGITUD_COBRANZA=" + _db.CreateSqlParameterName("LONGITUD_COBRANZA") + ", " +
				"TELEFONO_COBRANZA1=" + _db.CreateSqlParameterName("TELEFONO_COBRANZA1") + ", " +
				"TELEFONO_COBRANZA2=" + _db.CreateSqlParameterName("TELEFONO_COBRANZA2") + ", " +
				"CONYUGE_NOMBRE=" + _db.CreateSqlParameterName("CONYUGE_NOMBRE") + ", " +
				"CONYUGE_APELLIDO=" + _db.CreateSqlParameterName("CONYUGE_APELLIDO") + ", " +
				"ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				"NIVEL_CREDITO_ID=" + _db.CreateSqlParameterName("NIVEL_CREDITO_ID") + ", " +
				"AGENTE_RETENCION=" + _db.CreateSqlParameterName("AGENTE_RETENCION") + ", " +
				"BANDERA_RETENCION=" + _db.CreateSqlParameterName("BANDERA_RETENCION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"INGRESO_APROBADO=" + _db.CreateSqlParameterName("INGRESO_APROBADO") + ", " +
				"USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID") + ", " +
				"FECHA_APROBACION=" + _db.CreateSqlParameterName("FECHA_APROBACION") + ", " +
				"GRUPO_SANGUINEO=" + _db.CreateSqlParameterName("GRUPO_SANGUINEO") + ", " +
				"ESTADO_CIVIL_ID=" + _db.CreateSqlParameterName("ESTADO_CIVIL_ID") + ", " +
				"PERSONA_ID_CONYUGE=" + _db.CreateSqlParameterName("PERSONA_ID_CONYUGE") + ", " +
				"NUMERO_HIJOS=" + _db.CreateSqlParameterName("NUMERO_HIJOS") + ", " +
				"TIPO_EMPLEO=" + _db.CreateSqlParameterName("TIPO_EMPLEO") + ", " +
				"SEPARACION_BIENES=" + _db.CreateSqlParameterName("SEPARACION_BIENES") + ", " +
				"PORC_DESCUENTO_AUTOMATICO=" + _db.CreateSqlParameterName("PORC_DESCUENTO_AUTOMATICO") + ", " +
				"PERSONA_CALIFICACION_ID=" + _db.CreateSqlParameterName("PERSONA_CALIFICACION_ID") + ", " +
				"ZONA_COBRANZA_ID=" + _db.CreateSqlParameterName("ZONA_COBRANZA_ID") + ", " +
				"TIPO_CLIENTE_ID=" + _db.CreateSqlParameterName("TIPO_CLIENTE_ID") + ", " +
				"ESTADO_MOROSIDAD_ID=" + _db.CreateSqlParameterName("ESTADO_MOROSIDAD_ID") + ", " +
				"MODIFICABLE=" + _db.CreateSqlParameterName("MODIFICABLE") + ", " +
				"ES_CONTRIBUYENTE=" + _db.CreateSqlParameterName("ES_CONTRIBUYENTE") + ", " +
				"NRO_TARJETA_RED_PAGO=" + _db.CreateSqlParameterName("NRO_TARJETA_RED_PAGO") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"CODIGO_EXTERNO=" + _db.CreateSqlParameterName("CODIGO_EXTERNO") + ", " +
				"FECHA_ULTIMA_VISITA=" + _db.CreateSqlParameterName("FECHA_ULTIMA_VISITA") + ", " +
				"FECHA_ULTIMA_ACTUALIZAC_DATOS=" + _db.CreateSqlParameterName("FECHA_ULTIMA_ACTUALIZAC_DATOS") + ", " +
				"PERSONA_PADRE_ID=" + _db.CreateSqlParameterName("PERSONA_PADRE_ID") + ", " +
				"LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "FISICO", value.FISICO);
			AddParameter(cmd, "MAYORISTA", value.MAYORISTA);
			AddParameter(cmd, "TRATAMIENTO_ID", value.TRATAMIENTO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "NOMBRE_COMPLETO", value.NOMBRE_COMPLETO);
			AddParameter(cmd, "NOMBRE_FANTASIA", value.NOMBRE_FANTASIA);
			AddParameter(cmd, "GENERO", value.GENERO);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "NACIMIENTO",
				value.IsNACIMIENTONull ? DBNull.Value : (object)value.NACIMIENTO);
			AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", value.TIPO_DOCUMENTO_IDENTIDAD_ID);
			AddParameter(cmd, "NUMERO_DOCUMENTO", value.NUMERO_DOCUMENTO);
			AddParameter(cmd, "PAIS_NACIONALIDAD_ID",
				value.IsPAIS_NACIONALIDAD_IDNull ? DBNull.Value : (object)value.PAIS_NACIONALIDAD_ID);
			AddParameter(cmd, "PAIS_RESIDENCIA_ID",
				value.IsPAIS_RESIDENCIA_IDNull ? DBNull.Value : (object)value.PAIS_RESIDENCIA_ID);
			AddParameter(cmd, "EN_INFORMCONF", value.EN_INFORMCONF);
			AddParameter(cmd, "FECHA_MODIFICACION_INFORMCONF",
				value.IsFECHA_MODIFICACION_INFORMCONFNull ? DBNull.Value : (object)value.FECHA_MODIFICACION_INFORMCONF);
			AddParameter(cmd, "EN_JUDICIAL", value.EN_JUDICIAL);
			AddParameter(cmd, "ES_CLIENTE", value.ES_CLIENTE);
			AddParameter(cmd, "POSEE_UNIPERSONAL", value.POSEE_UNIPERSONAL);
			AddParameter(cmd, "EMPRESA_NOMBRE_FANTASIA", value.EMPRESA_NOMBRE_FANTASIA);
			AddParameter(cmd, "FECHA_MODIFICACION_JUDICIAL",
				value.IsFECHA_MODIFICACION_JUDICIALNull ? DBNull.Value : (object)value.FECHA_MODIFICACION_JUDICIAL);
			AddParameter(cmd, "ABOGADO_ID",
				value.IsABOGADO_IDNull ? DBNull.Value : (object)value.ABOGADO_ID);
			AddParameter(cmd, "PROFESION_ID", value.PROFESION_ID);
			AddParameter(cmd, "DEPARTAMENTO1_ID",
				value.IsDEPARTAMENTO1_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO1_ID);
			AddParameter(cmd, "CIUDAD1_ID",
				value.IsCIUDAD1_IDNull ? DBNull.Value : (object)value.CIUDAD1_ID);
			AddParameter(cmd, "BARRIO1_ID",
				value.IsBARRIO1_IDNull ? DBNull.Value : (object)value.BARRIO1_ID);
			AddParameter(cmd, "CALLE1", value.CALLE1);
			AddParameter(cmd, "CODIGO_POSTAL1", value.CODIGO_POSTAL1);
			AddParameter(cmd, "LATITUD1",
				value.IsLATITUD1Null ? DBNull.Value : (object)value.LATITUD1);
			AddParameter(cmd, "LONGITUD1",
				value.IsLONGITUD1Null ? DBNull.Value : (object)value.LONGITUD1);
			AddParameter(cmd, "DEPARTAMENTO2_ID",
				value.IsDEPARTAMENTO2_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO2_ID);
			AddParameter(cmd, "CIUDAD2_ID",
				value.IsCIUDAD2_IDNull ? DBNull.Value : (object)value.CIUDAD2_ID);
			AddParameter(cmd, "BARRIO2_ID",
				value.IsBARRIO2_IDNull ? DBNull.Value : (object)value.BARRIO2_ID);
			AddParameter(cmd, "CALLE2", value.CALLE2);
			AddParameter(cmd, "CODIGO_POSTAL2", value.CODIGO_POSTAL2);
			AddParameter(cmd, "LATITUD2",
				value.IsLATITUD2Null ? DBNull.Value : (object)value.LATITUD2);
			AddParameter(cmd, "LONGITUD2",
				value.IsLONGITUD2Null ? DBNull.Value : (object)value.LONGITUD2);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "RUBRO_ID",
				value.IsRUBRO_IDNull ? DBNull.Value : (object)value.RUBRO_ID);
			AddParameter(cmd, "EMPRESA_FUNDACION",
				value.IsEMPRESA_FUNDACIONNull ? DBNull.Value : (object)value.EMPRESA_FUNDACION);
			AddParameter(cmd, "EMPRESA_PERSONA_CONTACTO", value.EMPRESA_PERSONA_CONTACTO);
			AddParameter(cmd, "EMPRESA_TELEFONO_CONTACTO", value.EMPRESA_TELEFONO_CONTACTO);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "OPERA_CREDITO", value.OPERA_CREDITO);
			AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID", value.CONDICION_HABITUAL_PAGO_ID);
			AddParameter(cmd, "MONEDA_LIMITE_CREDITO_ID", value.MONEDA_LIMITE_CREDITO_ID);
			AddParameter(cmd, "CONTADOR_CREDITO_ACTUAL", value.CONTADOR_CREDITO_ACTUAL);
			AddParameter(cmd, "VENDEDOR_HABITUAL_ID",
				value.IsVENDEDOR_HABITUAL_IDNull ? DBNull.Value : (object)value.VENDEDOR_HABITUAL_ID);
			AddParameter(cmd, "COBRADOR_HABITUAL_ID",
				value.IsCOBRADOR_HABITUAL_IDNull ? DBNull.Value : (object)value.COBRADOR_HABITUAL_ID);
			AddParameter(cmd, "DEPARTAMENTO_COBRANZA_ID",
				value.IsDEPARTAMENTO_COBRANZA_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_COBRANZA_ID);
			AddParameter(cmd, "CIUDAD_COBRANZA_ID",
				value.IsCIUDAD_COBRANZA_IDNull ? DBNull.Value : (object)value.CIUDAD_COBRANZA_ID);
			AddParameter(cmd, "BARRIO_COBRANZA_ID",
				value.IsBARRIO_COBRANZA_IDNull ? DBNull.Value : (object)value.BARRIO_COBRANZA_ID);
			AddParameter(cmd, "CALLE_COBRANZA", value.CALLE_COBRANZA);
			AddParameter(cmd, "CODIGO_POSTAL_COBRANZA", value.CODIGO_POSTAL_COBRANZA);
			AddParameter(cmd, "LATITUD_COBRANZA",
				value.IsLATITUD_COBRANZANull ? DBNull.Value : (object)value.LATITUD_COBRANZA);
			AddParameter(cmd, "LONGITUD_COBRANZA",
				value.IsLONGITUD_COBRANZANull ? DBNull.Value : (object)value.LONGITUD_COBRANZA);
			AddParameter(cmd, "TELEFONO_COBRANZA1", value.TELEFONO_COBRANZA1);
			AddParameter(cmd, "TELEFONO_COBRANZA2", value.TELEFONO_COBRANZA2);
			AddParameter(cmd, "CONYUGE_NOMBRE", value.CONYUGE_NOMBRE);
			AddParameter(cmd, "CONYUGE_APELLIDO", value.CONYUGE_APELLIDO);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "NIVEL_CREDITO_ID",
				value.IsNIVEL_CREDITO_IDNull ? DBNull.Value : (object)value.NIVEL_CREDITO_ID);
			AddParameter(cmd, "AGENTE_RETENCION", value.AGENTE_RETENCION);
			AddParameter(cmd, "BANDERA_RETENCION", value.BANDERA_RETENCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "INGRESO_APROBADO", value.INGRESO_APROBADO);
			AddParameter(cmd, "USUARIO_APROBACION_ID",
				value.IsUSUARIO_APROBACION_IDNull ? DBNull.Value : (object)value.USUARIO_APROBACION_ID);
			AddParameter(cmd, "FECHA_APROBACION",
				value.IsFECHA_APROBACIONNull ? DBNull.Value : (object)value.FECHA_APROBACION);
			AddParameter(cmd, "GRUPO_SANGUINEO", value.GRUPO_SANGUINEO);
			AddParameter(cmd, "ESTADO_CIVIL_ID", value.ESTADO_CIVIL_ID);
			AddParameter(cmd, "PERSONA_ID_CONYUGE",
				value.IsPERSONA_ID_CONYUGENull ? DBNull.Value : (object)value.PERSONA_ID_CONYUGE);
			AddParameter(cmd, "NUMERO_HIJOS",
				value.IsNUMERO_HIJOSNull ? DBNull.Value : (object)value.NUMERO_HIJOS);
			AddParameter(cmd, "TIPO_EMPLEO", value.TIPO_EMPLEO);
			AddParameter(cmd, "SEPARACION_BIENES", value.SEPARACION_BIENES);
			AddParameter(cmd, "PORC_DESCUENTO_AUTOMATICO", value.PORC_DESCUENTO_AUTOMATICO);
			AddParameter(cmd, "PERSONA_CALIFICACION_ID",
				value.IsPERSONA_CALIFICACION_IDNull ? DBNull.Value : (object)value.PERSONA_CALIFICACION_ID);
			AddParameter(cmd, "ZONA_COBRANZA_ID",
				value.IsZONA_COBRANZA_IDNull ? DBNull.Value : (object)value.ZONA_COBRANZA_ID);
			AddParameter(cmd, "TIPO_CLIENTE_ID",
				value.IsTIPO_CLIENTE_IDNull ? DBNull.Value : (object)value.TIPO_CLIENTE_ID);
			AddParameter(cmd, "ESTADO_MOROSIDAD_ID",
				value.IsESTADO_MOROSIDAD_IDNull ? DBNull.Value : (object)value.ESTADO_MOROSIDAD_ID);
			AddParameter(cmd, "MODIFICABLE", value.MODIFICABLE);
			AddParameter(cmd, "ES_CONTRIBUYENTE", value.ES_CONTRIBUYENTE);
			AddParameter(cmd, "NRO_TARJETA_RED_PAGO",
				value.IsNRO_TARJETA_RED_PAGONull ? DBNull.Value : (object)value.NRO_TARJETA_RED_PAGO);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "CODIGO_EXTERNO", value.CODIGO_EXTERNO);
			AddParameter(cmd, "FECHA_ULTIMA_VISITA",
				value.IsFECHA_ULTIMA_VISITANull ? DBNull.Value : (object)value.FECHA_ULTIMA_VISITA);
			AddParameter(cmd, "FECHA_ULTIMA_ACTUALIZAC_DATOS", value.FECHA_ULTIMA_ACTUALIZAC_DATOS);
			AddParameter(cmd, "PERSONA_PADRE_ID",
				value.IsPERSONA_PADRE_IDNull ? DBNull.Value : (object)value.PERSONA_PADRE_ID);
			AddParameter(cmd, "LISTA_PRECIOS_ID",
				value.IsLISTA_PRECIOS_IDNull ? DBNull.Value : (object)value.LISTA_PRECIOS_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PERSONAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PERSONAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
		/// argument when your code calls this method in an ADO.NET transaction context. Note that in 
		/// this case, after you call the Update method you need call either <c>AcceptChanges</c> 
		/// or <c>RejectChanges</c> method on the DataTable object.
		/// <code>
		/// MyDb db = new MyDb();
		/// try
		/// {
		///		db.BeginTransaction();
		///		db.MyCollection.Update(myDataTable, false);
		///		db.CommitTransaction();
		///		myDataTable.AcceptChanges();
		/// }
		/// catch(Exception)
		/// {
		///		db.RollbackTransaction();
		///		myDataTable.RejectChanges();
		/// }
		/// </code>
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		/// <param name="acceptChanges">Specifies whether this method calls the <c>AcceptChanges</c>
		/// method on the changed DataRow objects.</param>
		public virtual void Update(DataTable table, bool acceptChanges)
		{
			DataRowCollection rows = table.Rows;
			for(int i = rows.Count - 1; i >= 0; i--)
			{
				DataRow row = rows[i];
				switch(row.RowState)
				{
					case DataRowState.Added:
						Insert(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;

					case DataRowState.Deleted:
						// Temporary reject changes to be able to access to the PK column(s)
						row.RejectChanges();
						try
						{
							DeleteByPrimaryKey((decimal)row["ID"]);
						}
						finally
						{
							row.Delete();
						}
						if(acceptChanges)
							row.AcceptChanges();
						break;
						
					case DataRowState.Modified:
						Update(MapRow(row));
						if(acceptChanges)
							row.AcceptChanges();
						break;
				}
			}
		}

		/// <summary>
		/// Deletes the specified object from the <c>PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PERSONASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PERSONAS</c> table using
		/// the specified primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public virtual bool DeleteByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ID", id);
			return 0 < cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByABOGADO_ID(decimal abogado_id)
		{
			return DeleteByABOGADO_ID(abogado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <param name="abogado_idNull">true if the method ignores the abogado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByABOGADO_ID(decimal abogado_id, bool abogado_idNull)
		{
			return CreateDeleteByABOGADO_IDCommand(abogado_id, abogado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_ABOGADO</c> foreign key.
		/// </summary>
		/// <param name="abogado_id">The <c>ABOGADO_ID</c> column value.</param>
		/// <param name="abogado_idNull">true if the method ignores the abogado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByABOGADO_IDCommand(decimal abogado_id, bool abogado_idNull)
		{
			string whereSql = "";
			if(abogado_idNull)
				whereSql += "ABOGADO_ID IS NULL";
			else
				whereSql += "ABOGADO_ID=" + _db.CreateSqlParameterName("ABOGADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!abogado_idNull)
				AddParameter(cmd, "ABOGADO_ID", abogado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_COBRANZA_ID(decimal barrio_cobranza_id)
		{
			return DeleteByBARRIO_COBRANZA_ID(barrio_cobranza_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <param name="barrio_cobranza_idNull">true if the method ignores the barrio_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_COBRANZA_ID(decimal barrio_cobranza_id, bool barrio_cobranza_idNull)
		{
			return CreateDeleteByBARRIO_COBRANZA_IDCommand(barrio_cobranza_id, barrio_cobranza_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_B_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="barrio_cobranza_id">The <c>BARRIO_COBRANZA_ID</c> column value.</param>
		/// <param name="barrio_cobranza_idNull">true if the method ignores the barrio_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO_COBRANZA_IDCommand(decimal barrio_cobranza_id, bool barrio_cobranza_idNull)
		{
			string whereSql = "";
			if(barrio_cobranza_idNull)
				whereSql += "BARRIO_COBRANZA_ID IS NULL";
			else
				whereSql += "BARRIO_COBRANZA_ID=" + _db.CreateSqlParameterName("BARRIO_COBRANZA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio_cobranza_idNull)
				AddParameter(cmd, "BARRIO_COBRANZA_ID", barrio_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO1_ID(decimal barrio1_id)
		{
			return DeleteByBARRIO1_ID(barrio1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO1_ID(decimal barrio1_id, bool barrio1_idNull)
		{
			return CreateDeleteByBARRIO1_IDCommand(barrio1_id, barrio1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_BARRIO1</c> foreign key.
		/// </summary>
		/// <param name="barrio1_id">The <c>BARRIO1_ID</c> column value.</param>
		/// <param name="barrio1_idNull">true if the method ignores the barrio1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO1_IDCommand(decimal barrio1_id, bool barrio1_idNull)
		{
			string whereSql = "";
			if(barrio1_idNull)
				whereSql += "BARRIO1_ID IS NULL";
			else
				whereSql += "BARRIO1_ID=" + _db.CreateSqlParameterName("BARRIO1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio1_idNull)
				AddParameter(cmd, "BARRIO1_ID", barrio1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO2_ID(decimal barrio2_id)
		{
			return DeleteByBARRIO2_ID(barrio2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO2_ID(decimal barrio2_id, bool barrio2_idNull)
		{
			return CreateDeleteByBARRIO2_IDCommand(barrio2_id, barrio2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_BARRIO2</c> foreign key.
		/// </summary>
		/// <param name="barrio2_id">The <c>BARRIO2_ID</c> column value.</param>
		/// <param name="barrio2_idNull">true if the method ignores the barrio2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO2_IDCommand(decimal barrio2_id, bool barrio2_idNull)
		{
			string whereSql = "";
			if(barrio2_idNull)
				whereSql += "BARRIO2_ID IS NULL";
			else
				whereSql += "BARRIO2_ID=" + _db.CreateSqlParameterName("BARRIO2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio2_idNull)
				AddParameter(cmd, "BARRIO2_ID", barrio2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_COBRANZA_ID(decimal ciudad_cobranza_id)
		{
			return DeleteByCIUDAD_COBRANZA_ID(ciudad_cobranza_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <param name="ciudad_cobranza_idNull">true if the method ignores the ciudad_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_COBRANZA_ID(decimal ciudad_cobranza_id, bool ciudad_cobranza_idNull)
		{
			return CreateDeleteByCIUDAD_COBRANZA_IDCommand(ciudad_cobranza_id, ciudad_cobranza_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_C_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="ciudad_cobranza_id">The <c>CIUDAD_COBRANZA_ID</c> column value.</param>
		/// <param name="ciudad_cobranza_idNull">true if the method ignores the ciudad_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD_COBRANZA_IDCommand(decimal ciudad_cobranza_id, bool ciudad_cobranza_idNull)
		{
			string whereSql = "";
			if(ciudad_cobranza_idNull)
				whereSql += "CIUDAD_COBRANZA_ID IS NULL";
			else
				whereSql += "CIUDAD_COBRANZA_ID=" + _db.CreateSqlParameterName("CIUDAD_COBRANZA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad_cobranza_idNull)
				AddParameter(cmd, "CIUDAD_COBRANZA_ID", ciudad_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_CALIFICACION_ID(decimal persona_calificacion_id)
		{
			return DeleteByPERSONA_CALIFICACION_ID(persona_calificacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <param name="persona_calificacion_idNull">true if the method ignores the persona_calificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_CALIFICACION_ID(decimal persona_calificacion_id, bool persona_calificacion_idNull)
		{
			return CreateDeleteByPERSONA_CALIFICACION_IDCommand(persona_calificacion_id, persona_calificacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_CALIFICACION</c> foreign key.
		/// </summary>
		/// <param name="persona_calificacion_id">The <c>PERSONA_CALIFICACION_ID</c> column value.</param>
		/// <param name="persona_calificacion_idNull">true if the method ignores the persona_calificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_CALIFICACION_IDCommand(decimal persona_calificacion_id, bool persona_calificacion_idNull)
		{
			string whereSql = "";
			if(persona_calificacion_idNull)
				whereSql += "PERSONA_CALIFICACION_ID IS NULL";
			else
				whereSql += "PERSONA_CALIFICACION_ID=" + _db.CreateSqlParameterName("PERSONA_CALIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_calificacion_idNull)
				AddParameter(cmd, "PERSONA_CALIFICACION_ID", persona_calificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return CreateDeleteByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCENTRO_COSTO_IDCommand(decimal centro_costo_id, bool centro_costo_idNull)
		{
			string whereSql = "";
			if(centro_costo_idNull)
				whereSql += "CENTRO_COSTO_ID IS NULL";
			else
				whereSql += "CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!centro_costo_idNull)
				AddParameter(cmd, "CENTRO_COSTO_ID", centro_costo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD1_ID(decimal ciudad1_id)
		{
			return DeleteByCIUDAD1_ID(ciudad1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD1_ID(decimal ciudad1_id, bool ciudad1_idNull)
		{
			return CreateDeleteByCIUDAD1_IDCommand(ciudad1_id, ciudad1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_CIUDAD1</c> foreign key.
		/// </summary>
		/// <param name="ciudad1_id">The <c>CIUDAD1_ID</c> column value.</param>
		/// <param name="ciudad1_idNull">true if the method ignores the ciudad1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD1_IDCommand(decimal ciudad1_id, bool ciudad1_idNull)
		{
			string whereSql = "";
			if(ciudad1_idNull)
				whereSql += "CIUDAD1_ID IS NULL";
			else
				whereSql += "CIUDAD1_ID=" + _db.CreateSqlParameterName("CIUDAD1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad1_idNull)
				AddParameter(cmd, "CIUDAD1_ID", ciudad1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD2_ID(decimal ciudad2_id)
		{
			return DeleteByCIUDAD2_ID(ciudad2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD2_ID(decimal ciudad2_id, bool ciudad2_idNull)
		{
			return CreateDeleteByCIUDAD2_IDCommand(ciudad2_id, ciudad2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_CIUDAD2</c> foreign key.
		/// </summary>
		/// <param name="ciudad2_id">The <c>CIUDAD2_ID</c> column value.</param>
		/// <param name="ciudad2_idNull">true if the method ignores the ciudad2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD2_IDCommand(decimal ciudad2_id, bool ciudad2_idNull)
		{
			string whereSql = "";
			if(ciudad2_idNull)
				whereSql += "CIUDAD2_ID IS NULL";
			else
				whereSql += "CIUDAD2_ID=" + _db.CreateSqlParameterName("CIUDAD2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad2_idNull)
				AddParameter(cmd, "CIUDAD2_ID", ciudad2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOBRADOR_HABITUAL_ID(decimal cobrador_habitual_id)
		{
			return DeleteByCOBRADOR_HABITUAL_ID(cobrador_habitual_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <param name="cobrador_habitual_idNull">true if the method ignores the cobrador_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOBRADOR_HABITUAL_ID(decimal cobrador_habitual_id, bool cobrador_habitual_idNull)
		{
			return CreateDeleteByCOBRADOR_HABITUAL_IDCommand(cobrador_habitual_id, cobrador_habitual_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_COBRADOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="cobrador_habitual_id">The <c>COBRADOR_HABITUAL_ID</c> column value.</param>
		/// <param name="cobrador_habitual_idNull">true if the method ignores the cobrador_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOBRADOR_HABITUAL_IDCommand(decimal cobrador_habitual_id, bool cobrador_habitual_idNull)
		{
			string whereSql = "";
			if(cobrador_habitual_idNull)
				whereSql += "COBRADOR_HABITUAL_ID IS NULL";
			else
				whereSql += "COBRADOR_HABITUAL_ID=" + _db.CreateSqlParameterName("COBRADOR_HABITUAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!cobrador_habitual_idNull)
				AddParameter(cmd, "COBRADOR_HABITUAL_ID", cobrador_habitual_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CONDICION_HAB_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_HABITUAL_PAGO_ID(decimal condicion_habitual_pago_id)
		{
			return CreateDeleteByCONDICION_HABITUAL_PAGO_IDCommand(condicion_habitual_pago_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_CONDICION_HAB_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_habitual_pago_id">The <c>CONDICION_HABITUAL_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_HABITUAL_PAGO_IDCommand(decimal condicion_habitual_pago_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_HABITUAL_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_HABITUAL_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONDICION_HABITUAL_PAGO_ID", condicion_habitual_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID_CONYUGE(decimal persona_id_conyuge)
		{
			return DeleteByPERSONA_ID_CONYUGE(persona_id_conyuge, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <param name="persona_id_conyugeNull">true if the method ignores the persona_id_conyuge
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID_CONYUGE(decimal persona_id_conyuge, bool persona_id_conyugeNull)
		{
			return CreateDeleteByPERSONA_ID_CONYUGECommand(persona_id_conyuge, persona_id_conyugeNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_CONYUGE</c> foreign key.
		/// </summary>
		/// <param name="persona_id_conyuge">The <c>PERSONA_ID_CONYUGE</c> column value.</param>
		/// <param name="persona_id_conyugeNull">true if the method ignores the persona_id_conyuge
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_ID_CONYUGECommand(decimal persona_id_conyuge, bool persona_id_conyugeNull)
		{
			string whereSql = "";
			if(persona_id_conyugeNull)
				whereSql += "PERSONA_ID_CONYUGE IS NULL";
			else
				whereSql += "PERSONA_ID_CONYUGE=" + _db.CreateSqlParameterName("PERSONA_ID_CONYUGE");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_id_conyugeNull)
				AddParameter(cmd, "PERSONA_ID_CONYUGE", persona_id_conyuge);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_COBRANZA_ID(decimal departamento_cobranza_id)
		{
			return DeleteByDEPARTAMENTO_COBRANZA_ID(departamento_cobranza_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <param name="departamento_cobranza_idNull">true if the method ignores the departamento_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_COBRANZA_ID(decimal departamento_cobranza_id, bool departamento_cobranza_idNull)
		{
			return CreateDeleteByDEPARTAMENTO_COBRANZA_IDCommand(departamento_cobranza_id, departamento_cobranza_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_DEP_COBRANZA</c> foreign key.
		/// </summary>
		/// <param name="departamento_cobranza_id">The <c>DEPARTAMENTO_COBRANZA_ID</c> column value.</param>
		/// <param name="departamento_cobranza_idNull">true if the method ignores the departamento_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO_COBRANZA_IDCommand(decimal departamento_cobranza_id, bool departamento_cobranza_idNull)
		{
			string whereSql = "";
			if(departamento_cobranza_idNull)
				whereSql += "DEPARTAMENTO_COBRANZA_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_COBRANZA_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_COBRANZA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento_cobranza_idNull)
				AddParameter(cmd, "DEPARTAMENTO_COBRANZA_ID", departamento_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO1_ID(decimal departamento1_id)
		{
			return DeleteByDEPARTAMENTO1_ID(departamento1_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO1_ID(decimal departamento1_id, bool departamento1_idNull)
		{
			return CreateDeleteByDEPARTAMENTO1_IDCommand(departamento1_id, departamento1_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_DEPARTAMENTO1</c> foreign key.
		/// </summary>
		/// <param name="departamento1_id">The <c>DEPARTAMENTO1_ID</c> column value.</param>
		/// <param name="departamento1_idNull">true if the method ignores the departamento1_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO1_IDCommand(decimal departamento1_id, bool departamento1_idNull)
		{
			string whereSql = "";
			if(departamento1_idNull)
				whereSql += "DEPARTAMENTO1_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO1_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO1_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento1_idNull)
				AddParameter(cmd, "DEPARTAMENTO1_ID", departamento1_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO2_ID(decimal departamento2_id)
		{
			return DeleteByDEPARTAMENTO2_ID(departamento2_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO2_ID(decimal departamento2_id, bool departamento2_idNull)
		{
			return CreateDeleteByDEPARTAMENTO2_IDCommand(departamento2_id, departamento2_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_DEPARTAMENTO2</c> foreign key.
		/// </summary>
		/// <param name="departamento2_id">The <c>DEPARTAMENTO2_ID</c> column value.</param>
		/// <param name="departamento2_idNull">true if the method ignores the departamento2_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO2_IDCommand(decimal departamento2_id, bool departamento2_idNull)
		{
			string whereSql = "";
			if(departamento2_idNull)
				whereSql += "DEPARTAMENTO2_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO2_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO2_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento2_idNull)
				AddParameter(cmd, "DEPARTAMENTO2_ID", departamento2_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByENTIDAD_IDCommand(decimal entidad_id)
		{
			string whereSql = "";
			whereSql += "ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ENTIDAD_ID", entidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_CIVIL_ID(string estado_civil_id)
		{
			return CreateDeleteByESTADO_CIVIL_IDCommand(estado_civil_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_ESTADO_CIVIL</c> foreign key.
		/// </summary>
		/// <param name="estado_civil_id">The <c>ESTADO_CIVIL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_CIVIL_IDCommand(string estado_civil_id)
		{
			string whereSql = "";
			if(null == estado_civil_id)
				whereSql += "ESTADO_CIVIL_ID IS NULL";
			else
				whereSql += "ESTADO_CIVIL_ID=" + _db.CreateSqlParameterName("ESTADO_CIVIL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != estado_civil_id)
				AddParameter(cmd, "ESTADO_CIVIL_ID", estado_civil_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return DeleteByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return CreateDeleteByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_MOROSIDAD_ID(decimal estado_morosidad_id)
		{
			return DeleteByESTADO_MOROSIDAD_ID(estado_morosidad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="estado_morosidad_idNull">true if the method ignores the estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_MOROSIDAD_ID(decimal estado_morosidad_id, bool estado_morosidad_idNull)
		{
			return CreateDeleteByESTADO_MOROSIDAD_IDCommand(estado_morosidad_id, estado_morosidad_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_ESTADO_MOROSIDAD</c> foreign key.
		/// </summary>
		/// <param name="estado_morosidad_id">The <c>ESTADO_MOROSIDAD_ID</c> column value.</param>
		/// <param name="estado_morosidad_idNull">true if the method ignores the estado_morosidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_MOROSIDAD_IDCommand(decimal estado_morosidad_id, bool estado_morosidad_idNull)
		{
			string whereSql = "";
			if(estado_morosidad_idNull)
				whereSql += "ESTADO_MOROSIDAD_ID IS NULL";
			else
				whereSql += "ESTADO_MOROSIDAD_ID=" + _db.CreateSqlParameterName("ESTADO_MOROSIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!estado_morosidad_idNull)
				AddParameter(cmd, "ESTADO_MOROSIDAD_ID", estado_morosidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIOS_ID(decimal lista_precios_id)
		{
			return DeleteByLISTA_PRECIOS_ID(lista_precios_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIOS_ID(decimal lista_precios_id, bool lista_precios_idNull)
		{
			return CreateDeleteByLISTA_PRECIOS_IDCommand(lista_precios_id, lista_precios_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_LISTA_PRECIO</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_id">The <c>LISTA_PRECIOS_ID</c> column value.</param>
		/// <param name="lista_precios_idNull">true if the method ignores the lista_precios_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIOS_IDCommand(decimal lista_precios_id, bool lista_precios_idNull)
		{
			string whereSql = "";
			if(lista_precios_idNull)
				whereSql += "LISTA_PRECIOS_ID IS NULL";
			else
				whereSql += "LISTA_PRECIOS_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lista_precios_idNull)
				AddParameter(cmd, "LISTA_PRECIOS_ID", lista_precios_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id, moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_MONEDA_LIM_CRED</c> foreign key.
		/// </summary>
		/// <param name="moneda_limite_credito_id">The <c>MONEDA_LIMITE_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_LIMITE_CREDITO_ID(decimal moneda_limite_credito_id)
		{
			return CreateDeleteByMONEDA_LIMITE_CREDITO_IDCommand(moneda_limite_credito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_MONEDA_LIM_CRED</c> foreign key.
		/// </summary>
		/// <param name="moneda_limite_credito_id">The <c>MONEDA_LIMITE_CREDITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_LIMITE_CREDITO_IDCommand(decimal moneda_limite_credito_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_LIMITE_CREDITO_ID=" + _db.CreateSqlParameterName("MONEDA_LIMITE_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_LIMITE_CREDITO_ID", moneda_limite_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNIVEL_CREDITO_ID(decimal nivel_credito_id)
		{
			return DeleteByNIVEL_CREDITO_ID(nivel_credito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <param name="nivel_credito_idNull">true if the method ignores the nivel_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNIVEL_CREDITO_ID(decimal nivel_credito_id, bool nivel_credito_idNull)
		{
			return CreateDeleteByNIVEL_CREDITO_IDCommand(nivel_credito_id, nivel_credito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_NIVEL_CREDITO</c> foreign key.
		/// </summary>
		/// <param name="nivel_credito_id">The <c>NIVEL_CREDITO_ID</c> column value.</param>
		/// <param name="nivel_credito_idNull">true if the method ignores the nivel_credito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNIVEL_CREDITO_IDCommand(decimal nivel_credito_id, bool nivel_credito_idNull)
		{
			string whereSql = "";
			if(nivel_credito_idNull)
				whereSql += "NIVEL_CREDITO_ID IS NULL";
			else
				whereSql += "NIVEL_CREDITO_ID=" + _db.CreateSqlParameterName("NIVEL_CREDITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nivel_credito_idNull)
				AddParameter(cmd, "NIVEL_CREDITO_ID", nivel_credito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_PADRE_ID(decimal persona_padre_id)
		{
			return DeleteByPERSONA_PADRE_ID(persona_padre_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <param name="persona_padre_idNull">true if the method ignores the persona_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_PADRE_ID(decimal persona_padre_id, bool persona_padre_idNull)
		{
			return CreateDeleteByPERSONA_PADRE_IDCommand(persona_padre_id, persona_padre_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_PADRE_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_padre_id">The <c>PERSONA_PADRE_ID</c> column value.</param>
		/// <param name="persona_padre_idNull">true if the method ignores the persona_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_PADRE_IDCommand(decimal persona_padre_id, bool persona_padre_idNull)
		{
			string whereSql = "";
			if(persona_padre_idNull)
				whereSql += "PERSONA_PADRE_ID IS NULL";
			else
				whereSql += "PERSONA_PADRE_ID=" + _db.CreateSqlParameterName("PERSONA_PADRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_padre_idNull)
				AddParameter(cmd, "PERSONA_PADRE_ID", persona_padre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id)
		{
			return DeleteByPAIS_NACIONALIDAD_ID(pais_nacionalidad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_NACIONALIDAD_ID(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			return CreateDeleteByPAIS_NACIONALIDAD_IDCommand(pais_nacionalidad_id, pais_nacionalidad_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_PAIS_NACIONALIDAD</c> foreign key.
		/// </summary>
		/// <param name="pais_nacionalidad_id">The <c>PAIS_NACIONALIDAD_ID</c> column value.</param>
		/// <param name="pais_nacionalidad_idNull">true if the method ignores the pais_nacionalidad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_NACIONALIDAD_IDCommand(decimal pais_nacionalidad_id, bool pais_nacionalidad_idNull)
		{
			string whereSql = "";
			if(pais_nacionalidad_idNull)
				whereSql += "PAIS_NACIONALIDAD_ID IS NULL";
			else
				whereSql += "PAIS_NACIONALIDAD_ID=" + _db.CreateSqlParameterName("PAIS_NACIONALIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pais_nacionalidad_idNull)
				AddParameter(cmd, "PAIS_NACIONALIDAD_ID", pais_nacionalidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_RESIDENCIA_ID(decimal pais_residencia_id)
		{
			return DeleteByPAIS_RESIDENCIA_ID(pais_residencia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_RESIDENCIA_ID(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			return CreateDeleteByPAIS_RESIDENCIA_IDCommand(pais_residencia_id, pais_residencia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_PAIS_RESIDENCIA</c> foreign key.
		/// </summary>
		/// <param name="pais_residencia_id">The <c>PAIS_RESIDENCIA_ID</c> column value.</param>
		/// <param name="pais_residencia_idNull">true if the method ignores the pais_residencia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_RESIDENCIA_IDCommand(decimal pais_residencia_id, bool pais_residencia_idNull)
		{
			string whereSql = "";
			if(pais_residencia_idNull)
				whereSql += "PAIS_RESIDENCIA_ID IS NULL";
			else
				whereSql += "PAIS_RESIDENCIA_ID=" + _db.CreateSqlParameterName("PAIS_RESIDENCIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pais_residencia_idNull)
				AddParameter(cmd, "PAIS_RESIDENCIA_ID", pais_residencia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROFESION_ID(string profesion_id)
		{
			return CreateDeleteByPROFESION_IDCommand(profesion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_PROFESION</c> foreign key.
		/// </summary>
		/// <param name="profesion_id">The <c>PROFESION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROFESION_IDCommand(string profesion_id)
		{
			string whereSql = "";
			if(null == profesion_id)
				whereSql += "PROFESION_ID IS NULL";
			else
				whereSql += "PROFESION_ID=" + _db.CreateSqlParameterName("PROFESION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != profesion_id)
				AddParameter(cmd, "PROFESION_ID", profesion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id)
		{
			return DeleteByRUBRO_ID(rubro_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRUBRO_ID(decimal rubro_id, bool rubro_idNull)
		{
			return CreateDeleteByRUBRO_IDCommand(rubro_id, rubro_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_RUBRO</c> foreign key.
		/// </summary>
		/// <param name="rubro_id">The <c>RUBRO_ID</c> column value.</param>
		/// <param name="rubro_idNull">true if the method ignores the rubro_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRUBRO_IDCommand(decimal rubro_id, bool rubro_idNull)
		{
			string whereSql = "";
			if(rubro_idNull)
				whereSql += "RUBRO_ID IS NULL";
			else
				whereSql += "RUBRO_ID=" + _db.CreateSqlParameterName("RUBRO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rubro_idNull)
				AddParameter(cmd, "RUBRO_ID", rubro_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_TEXTO_PREDEFINIDO</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CLIENTE_ID(decimal tipo_cliente_id)
		{
			return DeleteByTIPO_CLIENTE_ID(tipo_cliente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CLIENTE_ID(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			return CreateDeleteByTIPO_CLIENTE_IDCommand(tipo_cliente_id, tipo_cliente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_TIPO_CLIENTES</c> foreign key.
		/// </summary>
		/// <param name="tipo_cliente_id">The <c>TIPO_CLIENTE_ID</c> column value.</param>
		/// <param name="tipo_cliente_idNull">true if the method ignores the tipo_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CLIENTE_IDCommand(decimal tipo_cliente_id, bool tipo_cliente_idNull)
		{
			string whereSql = "";
			if(tipo_cliente_idNull)
				whereSql += "TIPO_CLIENTE_ID IS NULL";
			else
				whereSql += "TIPO_CLIENTE_ID=" + _db.CreateSqlParameterName("TIPO_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_cliente_idNull)
				AddParameter(cmd, "TIPO_CLIENTE_ID", tipo_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_DOCUMENTO_IDENTIDAD_ID(string tipo_documento_identidad_id)
		{
			return CreateDeleteByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(tipo_documento_identidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_TIPO_DOC_IDENT</c> foreign key.
		/// </summary>
		/// <param name="tipo_documento_identidad_id">The <c>TIPO_DOCUMENTO_IDENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_DOCUMENTO_IDENTIDAD_IDCommand(string tipo_documento_identidad_id)
		{
			string whereSql = "";
			if(null == tipo_documento_identidad_id)
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID IS NULL";
			else
				whereSql += "TIPO_DOCUMENTO_IDENTIDAD_ID=" + _db.CreateSqlParameterName("TIPO_DOCUMENTO_IDENTIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tipo_documento_identidad_id)
				AddParameter(cmd, "TIPO_DOCUMENTO_IDENTIDAD_ID", tipo_documento_identidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRATAMIENTO_ID(string tratamiento_id)
		{
			return CreateDeleteByTRATAMIENTO_IDCommand(tratamiento_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_TRATAMIENTO</c> foreign key.
		/// </summary>
		/// <param name="tratamiento_id">The <c>TRATAMIENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRATAMIENTO_IDCommand(string tratamiento_id)
		{
			string whereSql = "";
			if(null == tratamiento_id)
				whereSql += "TRATAMIENTO_ID IS NULL";
			else
				whereSql += "TRATAMIENTO_ID=" + _db.CreateSqlParameterName("TRATAMIENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tratamiento_id)
				AddParameter(cmd, "TRATAMIENTO_ID", tratamiento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id)
		{
			return DeleteByUSUARIO_APROBACION_ID(usuario_aprobacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_APROBACION_ID(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			return CreateDeleteByUSUARIO_APROBACION_IDCommand(usuario_aprobacion_id, usuario_aprobacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_USR_APROB</c> foreign key.
		/// </summary>
		/// <param name="usuario_aprobacion_id">The <c>USUARIO_APROBACION_ID</c> column value.</param>
		/// <param name="usuario_aprobacion_idNull">true if the method ignores the usuario_aprobacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_APROBACION_IDCommand(decimal usuario_aprobacion_id, bool usuario_aprobacion_idNull)
		{
			string whereSql = "";
			if(usuario_aprobacion_idNull)
				whereSql += "USUARIO_APROBACION_ID IS NULL";
			else
				whereSql += "USUARIO_APROBACION_ID=" + _db.CreateSqlParameterName("USUARIO_APROBACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_aprobacion_idNull)
				AddParameter(cmd, "USUARIO_APROBACION_ID", usuario_aprobacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_HABITUAL_ID(decimal vendedor_habitual_id)
		{
			return DeleteByVENDEDOR_HABITUAL_ID(vendedor_habitual_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <param name="vendedor_habitual_idNull">true if the method ignores the vendedor_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_HABITUAL_ID(decimal vendedor_habitual_id, bool vendedor_habitual_idNull)
		{
			return CreateDeleteByVENDEDOR_HABITUAL_IDCommand(vendedor_habitual_id, vendedor_habitual_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_VENDEDOR_HAB</c> foreign key.
		/// </summary>
		/// <param name="vendedor_habitual_id">The <c>VENDEDOR_HABITUAL_ID</c> column value.</param>
		/// <param name="vendedor_habitual_idNull">true if the method ignores the vendedor_habitual_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVENDEDOR_HABITUAL_IDCommand(decimal vendedor_habitual_id, bool vendedor_habitual_idNull)
		{
			string whereSql = "";
			if(vendedor_habitual_idNull)
				whereSql += "VENDEDOR_HABITUAL_ID IS NULL";
			else
				whereSql += "VENDEDOR_HABITUAL_ID=" + _db.CreateSqlParameterName("VENDEDOR_HABITUAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vendedor_habitual_idNull)
				AddParameter(cmd, "VENDEDOR_HABITUAL_ID", vendedor_habitual_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByZONA_COBRANZA_ID(decimal zona_cobranza_id)
		{
			return DeleteByZONA_COBRANZA_ID(zona_cobranza_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS</c> table using the 
		/// <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <param name="zona_cobranza_idNull">true if the method ignores the zona_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByZONA_COBRANZA_ID(decimal zona_cobranza_id, bool zona_cobranza_idNull)
		{
			return CreateDeleteByZONA_COBRANZA_IDCommand(zona_cobranza_id, zona_cobranza_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_ZONA_COB</c> foreign key.
		/// </summary>
		/// <param name="zona_cobranza_id">The <c>ZONA_COBRANZA_ID</c> column value.</param>
		/// <param name="zona_cobranza_idNull">true if the method ignores the zona_cobranza_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByZONA_COBRANZA_IDCommand(decimal zona_cobranza_id, bool zona_cobranza_idNull)
		{
			string whereSql = "";
			if(zona_cobranza_idNull)
				whereSql += "ZONA_COBRANZA_ID IS NULL";
			else
				whereSql += "ZONA_COBRANZA_ID=" + _db.CreateSqlParameterName("ZONA_COBRANZA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!zona_cobranza_idNull)
				AddParameter(cmd, "ZONA_COBRANZA_ID", zona_cobranza_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PERSONAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>The number of deleted records.</returns>
		public int Delete(string whereSql)
		{
			return CreateDeleteCommand(whereSql).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used 
		/// to delete <c>PERSONAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PERSONAS</c> table.
		/// </summary>
		/// <returns>The number of deleted records.</returns>
		public int DeleteAll()
		{
			return Delete("");
		}

		/// <summary>
		/// Reads data using the specified command and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="command">The <see cref="System.Data.IDbCommand"/> object.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		protected PERSONASRow[] MapRecords(IDbCommand command)
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		protected PERSONASRow[] MapRecords(IDataReader reader)
		{
			int totalRecordCount = -1;
			return MapRecords(reader, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Reads data from the provided data reader and returns 
		/// an array of mapped objects.
		/// </summary>
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
		/// <param name="startIndex">The index of the first record to map.</param>
		/// <param name="length">The number of records to map.</param>
		/// <param name="totalRecordCount">A reference parameter that returns the total number 
		/// of records in the reader object if 0 was passed into the method; otherwise it returns -1.</param>
		/// <returns>An array of <see cref="PERSONASRow"/> objects.</returns>
		protected virtual PERSONASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int fisicoColumnIndex = reader.GetOrdinal("FISICO");
			int mayoristaColumnIndex = reader.GetOrdinal("MAYORISTA");
			int tratamiento_idColumnIndex = reader.GetOrdinal("TRATAMIENTO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int apellidoColumnIndex = reader.GetOrdinal("APELLIDO");
			int nombre_completoColumnIndex = reader.GetOrdinal("NOMBRE_COMPLETO");
			int nombre_fantasiaColumnIndex = reader.GetOrdinal("NOMBRE_FANTASIA");
			int generoColumnIndex = reader.GetOrdinal("GENERO");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int nacimientoColumnIndex = reader.GetOrdinal("NACIMIENTO");
			int tipo_documento_identidad_idColumnIndex = reader.GetOrdinal("TIPO_DOCUMENTO_IDENTIDAD_ID");
			int numero_documentoColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO");
			int pais_nacionalidad_idColumnIndex = reader.GetOrdinal("PAIS_NACIONALIDAD_ID");
			int pais_residencia_idColumnIndex = reader.GetOrdinal("PAIS_RESIDENCIA_ID");
			int en_informconfColumnIndex = reader.GetOrdinal("EN_INFORMCONF");
			int fecha_modificacion_informconfColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION_INFORMCONF");
			int en_judicialColumnIndex = reader.GetOrdinal("EN_JUDICIAL");
			int es_clienteColumnIndex = reader.GetOrdinal("ES_CLIENTE");
			int posee_unipersonalColumnIndex = reader.GetOrdinal("POSEE_UNIPERSONAL");
			int empresa_nombre_fantasiaColumnIndex = reader.GetOrdinal("EMPRESA_NOMBRE_FANTASIA");
			int fecha_modificacion_judicialColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION_JUDICIAL");
			int abogado_idColumnIndex = reader.GetOrdinal("ABOGADO_ID");
			int profesion_idColumnIndex = reader.GetOrdinal("PROFESION_ID");
			int departamento1_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO1_ID");
			int ciudad1_idColumnIndex = reader.GetOrdinal("CIUDAD1_ID");
			int barrio1_idColumnIndex = reader.GetOrdinal("BARRIO1_ID");
			int calle1ColumnIndex = reader.GetOrdinal("CALLE1");
			int codigo_postal1ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL1");
			int latitud1ColumnIndex = reader.GetOrdinal("LATITUD1");
			int longitud1ColumnIndex = reader.GetOrdinal("LONGITUD1");
			int departamento2_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_ID");
			int ciudad2_idColumnIndex = reader.GetOrdinal("CIUDAD2_ID");
			int barrio2_idColumnIndex = reader.GetOrdinal("BARRIO2_ID");
			int calle2ColumnIndex = reader.GetOrdinal("CALLE2");
			int codigo_postal2ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL2");
			int latitud2ColumnIndex = reader.GetOrdinal("LATITUD2");
			int longitud2ColumnIndex = reader.GetOrdinal("LONGITUD2");
			int telefono1ColumnIndex = reader.GetOrdinal("TELEFONO1");
			int telefono2ColumnIndex = reader.GetOrdinal("TELEFONO2");
			int telefono3ColumnIndex = reader.GetOrdinal("TELEFONO3");
			int telefono4ColumnIndex = reader.GetOrdinal("TELEFONO4");
			int email1ColumnIndex = reader.GetOrdinal("EMAIL1");
			int email2ColumnIndex = reader.GetOrdinal("EMAIL2");
			int email3ColumnIndex = reader.GetOrdinal("EMAIL3");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int empresa_fundacionColumnIndex = reader.GetOrdinal("EMPRESA_FUNDACION");
			int empresa_persona_contactoColumnIndex = reader.GetOrdinal("EMPRESA_PERSONA_CONTACTO");
			int empresa_telefono_contactoColumnIndex = reader.GetOrdinal("EMPRESA_TELEFONO_CONTACTO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int opera_creditoColumnIndex = reader.GetOrdinal("OPERA_CREDITO");
			int condicion_habitual_pago_idColumnIndex = reader.GetOrdinal("CONDICION_HABITUAL_PAGO_ID");
			int moneda_limite_credito_idColumnIndex = reader.GetOrdinal("MONEDA_LIMITE_CREDITO_ID");
			int contador_credito_actualColumnIndex = reader.GetOrdinal("CONTADOR_CREDITO_ACTUAL");
			int vendedor_habitual_idColumnIndex = reader.GetOrdinal("VENDEDOR_HABITUAL_ID");
			int cobrador_habitual_idColumnIndex = reader.GetOrdinal("COBRADOR_HABITUAL_ID");
			int departamento_cobranza_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_COBRANZA_ID");
			int ciudad_cobranza_idColumnIndex = reader.GetOrdinal("CIUDAD_COBRANZA_ID");
			int barrio_cobranza_idColumnIndex = reader.GetOrdinal("BARRIO_COBRANZA_ID");
			int calle_cobranzaColumnIndex = reader.GetOrdinal("CALLE_COBRANZA");
			int codigo_postal_cobranzaColumnIndex = reader.GetOrdinal("CODIGO_POSTAL_COBRANZA");
			int latitud_cobranzaColumnIndex = reader.GetOrdinal("LATITUD_COBRANZA");
			int longitud_cobranzaColumnIndex = reader.GetOrdinal("LONGITUD_COBRANZA");
			int telefono_cobranza1ColumnIndex = reader.GetOrdinal("TELEFONO_COBRANZA1");
			int telefono_cobranza2ColumnIndex = reader.GetOrdinal("TELEFONO_COBRANZA2");
			int conyuge_nombreColumnIndex = reader.GetOrdinal("CONYUGE_NOMBRE");
			int conyuge_apellidoColumnIndex = reader.GetOrdinal("CONYUGE_APELLIDO");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int nivel_credito_idColumnIndex = reader.GetOrdinal("NIVEL_CREDITO_ID");
			int agente_retencionColumnIndex = reader.GetOrdinal("AGENTE_RETENCION");
			int bandera_retencionColumnIndex = reader.GetOrdinal("BANDERA_RETENCION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int grupo_sanguineoColumnIndex = reader.GetOrdinal("GRUPO_SANGUINEO");
			int estado_civil_idColumnIndex = reader.GetOrdinal("ESTADO_CIVIL_ID");
			int persona_id_conyugeColumnIndex = reader.GetOrdinal("PERSONA_ID_CONYUGE");
			int numero_hijosColumnIndex = reader.GetOrdinal("NUMERO_HIJOS");
			int tipo_empleoColumnIndex = reader.GetOrdinal("TIPO_EMPLEO");
			int separacion_bienesColumnIndex = reader.GetOrdinal("SEPARACION_BIENES");
			int porc_descuento_automaticoColumnIndex = reader.GetOrdinal("PORC_DESCUENTO_AUTOMATICO");
			int persona_calificacion_idColumnIndex = reader.GetOrdinal("PERSONA_CALIFICACION_ID");
			int zona_cobranza_idColumnIndex = reader.GetOrdinal("ZONA_COBRANZA_ID");
			int tipo_cliente_idColumnIndex = reader.GetOrdinal("TIPO_CLIENTE_ID");
			int estado_morosidad_idColumnIndex = reader.GetOrdinal("ESTADO_MOROSIDAD_ID");
			int modificableColumnIndex = reader.GetOrdinal("MODIFICABLE");
			int es_contribuyenteColumnIndex = reader.GetOrdinal("ES_CONTRIBUYENTE");
			int nro_tarjeta_red_pagoColumnIndex = reader.GetOrdinal("NRO_TARJETA_RED_PAGO");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int codigo_externoColumnIndex = reader.GetOrdinal("CODIGO_EXTERNO");
			int fecha_ultima_visitaColumnIndex = reader.GetOrdinal("FECHA_ULTIMA_VISITA");
			int fecha_ultima_actualizac_datosColumnIndex = reader.GetOrdinal("FECHA_ULTIMA_ACTUALIZAC_DATOS");
			int persona_padre_idColumnIndex = reader.GetOrdinal("PERSONA_PADRE_ID");
			int lista_precios_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PERSONASRow record = new PERSONASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.FISICO = Convert.ToString(reader.GetValue(fisicoColumnIndex));
					record.MAYORISTA = Convert.ToString(reader.GetValue(mayoristaColumnIndex));
					if(!reader.IsDBNull(tratamiento_idColumnIndex))
						record.TRATAMIENTO_ID = Convert.ToString(reader.GetValue(tratamiento_idColumnIndex));
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
					if(!reader.IsDBNull(pais_nacionalidad_idColumnIndex))
						record.PAIS_NACIONALIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_nacionalidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(pais_residencia_idColumnIndex))
						record.PAIS_RESIDENCIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_residencia_idColumnIndex)), 9);
					if(!reader.IsDBNull(en_informconfColumnIndex))
						record.EN_INFORMCONF = Convert.ToString(reader.GetValue(en_informconfColumnIndex));
					if(!reader.IsDBNull(fecha_modificacion_informconfColumnIndex))
						record.FECHA_MODIFICACION_INFORMCONF = Convert.ToDateTime(reader.GetValue(fecha_modificacion_informconfColumnIndex));
					if(!reader.IsDBNull(en_judicialColumnIndex))
						record.EN_JUDICIAL = Convert.ToString(reader.GetValue(en_judicialColumnIndex));
					record.ES_CLIENTE = Convert.ToString(reader.GetValue(es_clienteColumnIndex));
					record.POSEE_UNIPERSONAL = Convert.ToString(reader.GetValue(posee_unipersonalColumnIndex));
					if(!reader.IsDBNull(empresa_nombre_fantasiaColumnIndex))
						record.EMPRESA_NOMBRE_FANTASIA = Convert.ToString(reader.GetValue(empresa_nombre_fantasiaColumnIndex));
					if(!reader.IsDBNull(fecha_modificacion_judicialColumnIndex))
						record.FECHA_MODIFICACION_JUDICIAL = Convert.ToDateTime(reader.GetValue(fecha_modificacion_judicialColumnIndex));
					if(!reader.IsDBNull(abogado_idColumnIndex))
						record.ABOGADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(abogado_idColumnIndex)), 9);
					if(!reader.IsDBNull(profesion_idColumnIndex))
						record.PROFESION_ID = Convert.ToString(reader.GetValue(profesion_idColumnIndex));
					if(!reader.IsDBNull(departamento1_idColumnIndex))
						record.DEPARTAMENTO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento1_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad1_idColumnIndex))
						record.CIUDAD1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad1_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio1_idColumnIndex))
						record.BARRIO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio1_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle1ColumnIndex))
						record.CALLE1 = Convert.ToString(reader.GetValue(calle1ColumnIndex));
					if(!reader.IsDBNull(codigo_postal1ColumnIndex))
						record.CODIGO_POSTAL1 = Convert.ToString(reader.GetValue(codigo_postal1ColumnIndex));
					if(!reader.IsDBNull(latitud1ColumnIndex))
						record.LATITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud1ColumnIndex))
						record.LONGITUD1 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud1ColumnIndex)), 9);
					if(!reader.IsDBNull(departamento2_idColumnIndex))
						record.DEPARTAMENTO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento2_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad2_idColumnIndex))
						record.CIUDAD2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad2_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio2_idColumnIndex))
						record.BARRIO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio2_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle2ColumnIndex))
						record.CALLE2 = Convert.ToString(reader.GetValue(calle2ColumnIndex));
					if(!reader.IsDBNull(codigo_postal2ColumnIndex))
						record.CODIGO_POSTAL2 = Convert.ToString(reader.GetValue(codigo_postal2ColumnIndex));
					if(!reader.IsDBNull(latitud2ColumnIndex))
						record.LATITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(latitud2ColumnIndex)), 9);
					if(!reader.IsDBNull(longitud2ColumnIndex))
						record.LONGITUD2 = Math.Round(Convert.ToDecimal(reader.GetValue(longitud2ColumnIndex)), 9);
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
					if(!reader.IsDBNull(empresa_fundacionColumnIndex))
						record.EMPRESA_FUNDACION = Convert.ToDateTime(reader.GetValue(empresa_fundacionColumnIndex));
					if(!reader.IsDBNull(empresa_persona_contactoColumnIndex))
						record.EMPRESA_PERSONA_CONTACTO = Convert.ToString(reader.GetValue(empresa_persona_contactoColumnIndex));
					if(!reader.IsDBNull(empresa_telefono_contactoColumnIndex))
						record.EMPRESA_TELEFONO_CONTACTO = Convert.ToString(reader.GetValue(empresa_telefono_contactoColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(opera_creditoColumnIndex))
						record.OPERA_CREDITO = Convert.ToString(reader.GetValue(opera_creditoColumnIndex));
					record.CONDICION_HABITUAL_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_habitual_pago_idColumnIndex)), 9);
					record.MONEDA_LIMITE_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_limite_credito_idColumnIndex)), 9);
					record.CONTADOR_CREDITO_ACTUAL = Math.Round(Convert.ToDecimal(reader.GetValue(contador_credito_actualColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_habitual_idColumnIndex))
						record.VENDEDOR_HABITUAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_habitual_idColumnIndex)), 9);
					if(!reader.IsDBNull(cobrador_habitual_idColumnIndex))
						record.COBRADOR_HABITUAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(cobrador_habitual_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_cobranza_idColumnIndex))
						record.DEPARTAMENTO_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_cobranza_idColumnIndex))
						record.CIUDAD_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_cobranza_idColumnIndex))
						record.BARRIO_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle_cobranzaColumnIndex))
						record.CALLE_COBRANZA = Convert.ToString(reader.GetValue(calle_cobranzaColumnIndex));
					if(!reader.IsDBNull(codigo_postal_cobranzaColumnIndex))
						record.CODIGO_POSTAL_COBRANZA = Convert.ToString(reader.GetValue(codigo_postal_cobranzaColumnIndex));
					if(!reader.IsDBNull(latitud_cobranzaColumnIndex))
						record.LATITUD_COBRANZA = Math.Round(Convert.ToDecimal(reader.GetValue(latitud_cobranzaColumnIndex)), 9);
					if(!reader.IsDBNull(longitud_cobranzaColumnIndex))
						record.LONGITUD_COBRANZA = Math.Round(Convert.ToDecimal(reader.GetValue(longitud_cobranzaColumnIndex)), 9);
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
					if(!reader.IsDBNull(nivel_credito_idColumnIndex))
						record.NIVEL_CREDITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nivel_credito_idColumnIndex)), 9);
					record.AGENTE_RETENCION = Convert.ToString(reader.GetValue(agente_retencionColumnIndex));
					record.BANDERA_RETENCION = Convert.ToString(reader.GetValue(bandera_retencionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(grupo_sanguineoColumnIndex))
						record.GRUPO_SANGUINEO = Convert.ToString(reader.GetValue(grupo_sanguineoColumnIndex));
					if(!reader.IsDBNull(estado_civil_idColumnIndex))
						record.ESTADO_CIVIL_ID = Convert.ToString(reader.GetValue(estado_civil_idColumnIndex));
					if(!reader.IsDBNull(persona_id_conyugeColumnIndex))
						record.PERSONA_ID_CONYUGE = Math.Round(Convert.ToDecimal(reader.GetValue(persona_id_conyugeColumnIndex)), 9);
					if(!reader.IsDBNull(numero_hijosColumnIndex))
						record.NUMERO_HIJOS = Math.Round(Convert.ToDecimal(reader.GetValue(numero_hijosColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_empleoColumnIndex))
						record.TIPO_EMPLEO = Convert.ToString(reader.GetValue(tipo_empleoColumnIndex));
					record.SEPARACION_BIENES = Convert.ToString(reader.GetValue(separacion_bienesColumnIndex));
					record.PORC_DESCUENTO_AUTOMATICO = Math.Round(Convert.ToDecimal(reader.GetValue(porc_descuento_automaticoColumnIndex)), 9);
					if(!reader.IsDBNull(persona_calificacion_idColumnIndex))
						record.PERSONA_CALIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_calificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(zona_cobranza_idColumnIndex))
						record.ZONA_COBRANZA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(zona_cobranza_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_cliente_idColumnIndex))
						record.TIPO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(estado_morosidad_idColumnIndex))
						record.ESTADO_MOROSIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_morosidad_idColumnIndex)), 9);
					record.MODIFICABLE = Convert.ToString(reader.GetValue(modificableColumnIndex));
					record.ES_CONTRIBUYENTE = Convert.ToString(reader.GetValue(es_contribuyenteColumnIndex));
					if(!reader.IsDBNull(nro_tarjeta_red_pagoColumnIndex))
						record.NRO_TARJETA_RED_PAGO = Math.Round(Convert.ToDecimal(reader.GetValue(nro_tarjeta_red_pagoColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigo_externoColumnIndex))
						record.CODIGO_EXTERNO = Convert.ToString(reader.GetValue(codigo_externoColumnIndex));
					if(!reader.IsDBNull(fecha_ultima_visitaColumnIndex))
						record.FECHA_ULTIMA_VISITA = Convert.ToDateTime(reader.GetValue(fecha_ultima_visitaColumnIndex));
					record.FECHA_ULTIMA_ACTUALIZAC_DATOS = Convert.ToDateTime(reader.GetValue(fecha_ultima_actualizac_datosColumnIndex));
					if(!reader.IsDBNull(persona_padre_idColumnIndex))
						record.PERSONA_PADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_padre_idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precios_idColumnIndex))
						record.LISTA_PRECIOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PERSONASRow[])(recordList.ToArray(typeof(PERSONASRow)));
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// <param name="reader">The <see cref="System.Data.IDataReader"/> object to read data from the table.</param>
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PERSONASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PERSONASRow"/> object.</returns>
		protected virtual PERSONASRow MapRow(DataRow row)
		{
			PERSONASRow mappedObject = new PERSONASRow();
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
			// Column "PAIS_NACIONALIDAD_ID"
			dataColumn = dataTable.Columns["PAIS_NACIONALIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_NACIONALIDAD_ID = (decimal)row[dataColumn];
			// Column "PAIS_RESIDENCIA_ID"
			dataColumn = dataTable.Columns["PAIS_RESIDENCIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_RESIDENCIA_ID = (decimal)row[dataColumn];
			// Column "EN_INFORMCONF"
			dataColumn = dataTable.Columns["EN_INFORMCONF"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_INFORMCONF = (string)row[dataColumn];
			// Column "FECHA_MODIFICACION_INFORMCONF"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION_INFORMCONF"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION_INFORMCONF = (System.DateTime)row[dataColumn];
			// Column "EN_JUDICIAL"
			dataColumn = dataTable.Columns["EN_JUDICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.EN_JUDICIAL = (string)row[dataColumn];
			// Column "ES_CLIENTE"
			dataColumn = dataTable.Columns["ES_CLIENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CLIENTE = (string)row[dataColumn];
			// Column "POSEE_UNIPERSONAL"
			dataColumn = dataTable.Columns["POSEE_UNIPERSONAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.POSEE_UNIPERSONAL = (string)row[dataColumn];
			// Column "EMPRESA_NOMBRE_FANTASIA"
			dataColumn = dataTable.Columns["EMPRESA_NOMBRE_FANTASIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMPRESA_NOMBRE_FANTASIA = (string)row[dataColumn];
			// Column "FECHA_MODIFICACION_JUDICIAL"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION_JUDICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION_JUDICIAL = (System.DateTime)row[dataColumn];
			// Column "ABOGADO_ID"
			dataColumn = dataTable.Columns["ABOGADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABOGADO_ID = (decimal)row[dataColumn];
			// Column "PROFESION_ID"
			dataColumn = dataTable.Columns["PROFESION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROFESION_ID = (string)row[dataColumn];
			// Column "DEPARTAMENTO1_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO1_ID = (decimal)row[dataColumn];
			// Column "CIUDAD1_ID"
			dataColumn = dataTable.Columns["CIUDAD1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_ID = (decimal)row[dataColumn];
			// Column "BARRIO1_ID"
			dataColumn = dataTable.Columns["BARRIO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_ID = (decimal)row[dataColumn];
			// Column "CALLE1"
			dataColumn = dataTable.Columns["CALLE1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE1 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL1"
			dataColumn = dataTable.Columns["CODIGO_POSTAL1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL1 = (string)row[dataColumn];
			// Column "LATITUD1"
			dataColumn = dataTable.Columns["LATITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD1 = (decimal)row[dataColumn];
			// Column "LONGITUD1"
			dataColumn = dataTable.Columns["LONGITUD1"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD1 = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO2_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO2_ID = (decimal)row[dataColumn];
			// Column "CIUDAD2_ID"
			dataColumn = dataTable.Columns["CIUDAD2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_ID = (decimal)row[dataColumn];
			// Column "BARRIO2_ID"
			dataColumn = dataTable.Columns["BARRIO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_ID = (decimal)row[dataColumn];
			// Column "CALLE2"
			dataColumn = dataTable.Columns["CALLE2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE2 = (string)row[dataColumn];
			// Column "CODIGO_POSTAL2"
			dataColumn = dataTable.Columns["CODIGO_POSTAL2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL2 = (string)row[dataColumn];
			// Column "LATITUD2"
			dataColumn = dataTable.Columns["LATITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD2 = (decimal)row[dataColumn];
			// Column "LONGITUD2"
			dataColumn = dataTable.Columns["LONGITUD2"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD2 = (decimal)row[dataColumn];
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
			// Column "CIUDAD_COBRANZA_ID"
			dataColumn = dataTable.Columns["CIUDAD_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "BARRIO_COBRANZA_ID"
			dataColumn = dataTable.Columns["BARRIO_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "CALLE_COBRANZA"
			dataColumn = dataTable.Columns["CALLE_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE_COBRANZA = (string)row[dataColumn];
			// Column "CODIGO_POSTAL_COBRANZA"
			dataColumn = dataTable.Columns["CODIGO_POSTAL_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL_COBRANZA = (string)row[dataColumn];
			// Column "LATITUD_COBRANZA"
			dataColumn = dataTable.Columns["LATITUD_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD_COBRANZA = (decimal)row[dataColumn];
			// Column "LONGITUD_COBRANZA"
			dataColumn = dataTable.Columns["LONGITUD_COBRANZA"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD_COBRANZA = (decimal)row[dataColumn];
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
			// Column "NIVEL_CREDITO_ID"
			dataColumn = dataTable.Columns["NIVEL_CREDITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIVEL_CREDITO_ID = (decimal)row[dataColumn];
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
			// Column "PERSONA_CALIFICACION_ID"
			dataColumn = dataTable.Columns["PERSONA_CALIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CALIFICACION_ID = (decimal)row[dataColumn];
			// Column "ZONA_COBRANZA_ID"
			dataColumn = dataTable.Columns["ZONA_COBRANZA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ZONA_COBRANZA_ID = (decimal)row[dataColumn];
			// Column "TIPO_CLIENTE_ID"
			dataColumn = dataTable.Columns["TIPO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "ESTADO_MOROSIDAD_ID"
			dataColumn = dataTable.Columns["ESTADO_MOROSIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_MOROSIDAD_ID = (decimal)row[dataColumn];
			// Column "MODIFICABLE"
			dataColumn = dataTable.Columns["MODIFICABLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MODIFICABLE = (string)row[dataColumn];
			// Column "ES_CONTRIBUYENTE"
			dataColumn = dataTable.Columns["ES_CONTRIBUYENTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CONTRIBUYENTE = (string)row[dataColumn];
			// Column "NRO_TARJETA_RED_PAGO"
			dataColumn = dataTable.Columns["NRO_TARJETA_RED_PAGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_TARJETA_RED_PAGO = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "CODIGO_EXTERNO"
			dataColumn = dataTable.Columns["CODIGO_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_EXTERNO = (string)row[dataColumn];
			// Column "FECHA_ULTIMA_VISITA"
			dataColumn = dataTable.Columns["FECHA_ULTIMA_VISITA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMA_VISITA = (System.DateTime)row[dataColumn];
			// Column "FECHA_ULTIMA_ACTUALIZAC_DATOS"
			dataColumn = dataTable.Columns["FECHA_ULTIMA_ACTUALIZAC_DATOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMA_ACTUALIZAC_DATOS = (System.DateTime)row[dataColumn];
			// Column "PERSONA_PADRE_ID"
			dataColumn = dataTable.Columns["PERSONA_PADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_PADRE_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PERSONAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FISICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MAYORISTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRATAMIENTO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn = dataTable.Columns.Add("NOMBRE_FANTASIA", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("GENERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("NACIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("TIPO_DOCUMENTO_IDENTIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PAIS_NACIONALIDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PAIS_RESIDENCIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EN_INFORMCONF", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION_INFORMCONF", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("EN_JUDICIAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ES_CLIENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("POSEE_UNIPERSONAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("EMPRESA_NOMBRE_FANTASIA", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION_JUDICIAL", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ABOGADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROFESION_ID", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO1_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE1", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL1", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO2_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE2", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL2", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TELEFONO1", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("TELEFONO2", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("TELEFONO3", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("TELEFONO4", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("EMAIL1", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL3", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EMPRESA_FUNDACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("EMPRESA_PERSONA_CONTACTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("EMPRESA_TELEFONO_CONTACTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OPERA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("CONDICION_HABITUAL_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_LIMITE_CREDITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTADOR_CREDITO_ACTUAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VENDEDOR_HABITUAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COBRADOR_HABITUAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_COBRANZA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD_COBRANZA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO_COBRANZA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE_COBRANZA", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL_COBRANZA", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("LATITUD_COBRANZA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD_COBRANZA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TELEFONO_COBRANZA1", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("TELEFONO_COBRANZA2", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("CONYUGE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("CONYUGE_APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NIVEL_CREDITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AGENTE_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("BANDERA_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INGRESO_APROBADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_APROBACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_APROBACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("GRUPO_SANGUINEO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("ESTADO_CIVIL_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PERSONA_ID_CONYUGE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO_HIJOS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_EMPLEO", typeof(string));
			dataColumn.MaxLength = 3;
			dataColumn = dataTable.Columns.Add("SEPARACION_BIENES", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORC_DESCUENTO_AUTOMATICO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_CALIFICACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ZONA_COBRANZA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_CLIENTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO_MOROSIDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MODIFICABLE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_CONTRIBUYENTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NRO_TARJETA_RED_PAGO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CODIGO_EXTERNO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMA_VISITA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMA_ACTUALIZAC_DATOS", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_PADRE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_ID", typeof(decimal));
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

				case "FISICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MAYORISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TRATAMIENTO_ID":
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

				case "PAIS_NACIONALIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_RESIDENCIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EN_INFORMCONF":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_MODIFICACION_INFORMCONF":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EN_JUDICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_CLIENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "POSEE_UNIPERSONAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "EMPRESA_NOMBRE_FANTASIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_MODIFICACION_JUDICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ABOGADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROFESION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "OPERA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONDICION_HABITUAL_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_LIMITE_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "CIUDAD_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD_COBRANZA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "NIVEL_CREDITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "TIPO_EMPLEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEPARACION_BIENES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PORC_DESCUENTO_AUTOMATICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_CALIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ZONA_COBRANZA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO_MOROSIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MODIFICABLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_CONTRIBUYENTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_TARJETA_RED_PAGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ULTIMA_VISITA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ULTIMA_ACTUALIZAC_DATOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PERSONA_PADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PERSONASCollection_Base class
}  // End of namespace
