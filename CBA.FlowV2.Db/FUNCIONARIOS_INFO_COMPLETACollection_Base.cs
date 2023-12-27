// <fileinfo name="FUNCIONARIOS_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FUNCIONARIOS_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string ENTIDAD_NOMBREColumnName = "ENTIDAD_NOMBRE";
		public const string TRATAMIENTO_IDColumnName = "TRATAMIENTO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string NOMBRE_COMPLETOColumnName = "NOMBRE_COMPLETO";
		public const string APELLIDOColumnName = "APELLIDO";
		public const string APODOColumnName = "APODO";
		public const string GENEROColumnName = "GENERO";
		public const string RUCColumnName = "RUC";
		public const string NACIMIENTOColumnName = "NACIMIENTO";
		public const string TIPO_DOCUMENTO_IDENTIDAD_IDColumnName = "TIPO_DOCUMENTO_IDENTIDAD_ID";
		public const string NUMERO_DOCUMENTOColumnName = "NUMERO_DOCUMENTO";
		public const string PAIS_NACIONALIDAD_IDColumnName = "PAIS_NACIONALIDAD_ID";
		public const string PAIS_RESIDENCIA_IDColumnName = "PAIS_RESIDENCIA_ID";
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
		public const string FECHA_CONTRATACIONColumnName = "FECHA_CONTRATACION";
		public const string FECHA_SALIDAColumnName = "FECHA_SALIDA";
		public const string MOTIVO_SALIDAColumnName = "MOTIVO_SALIDA";
		public const string ESTADO_CIVIL_IDColumnName = "ESTADO_CIVIL_ID";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string NOMBRE_FAMILIAR_CONTACTOColumnName = "NOMBRE_FAMILIAR_CONTACTO";
		public const string RELACION_FAMILIAR_CONTACTOColumnName = "RELACION_FAMILIAR_CONTACTO";
		public const string TELEFONO_FAMILIAR_CONTACTOColumnName = "TELEFONO_FAMILIAR_CONTACTO";
		public const string DEPARTAMENTO_FAMILIAR_CONT_IDColumnName = "DEPARTAMENTO_FAMILIAR_CONT_ID";
		public const string CIUDAD_FAMILIAR_CONTACTO_IDColumnName = "CIUDAD_FAMILIAR_CONTACTO_ID";
		public const string BARRIO_FAMILIAR_CONTACTO_IDColumnName = "BARRIO_FAMILIAR_CONTACTO_ID";
		public const string CALLE_FAMILIAR_CONTACTOColumnName = "CALLE_FAMILIAR_CONTACTO";
		public const string COD_POST_FAMILIAR_CONTACTOColumnName = "COD_POST_FAMILIAR_CONTACTO";
		public const string LATITUD_FAMILIAR_CONTACTOColumnName = "LATITUD_FAMILIAR_CONTACTO";
		public const string LONGITUD_FAMILIAR_CONTACTOColumnName = "LONGITUD_FAMILIAR_CONTACTO";
		public const string ESTADOColumnName = "ESTADO";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string ES_VENDEDORColumnName = "ES_VENDEDOR";
		public const string ES_COBRADORColumnName = "ES_COBRADOR";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string SUCURSAL_NOMBREColumnName = "SUCURSAL_NOMBRE";
		public const string INGRESO_SEGUROColumnName = "INGRESO_SEGURO";
		public const string SALARIO_TIPOColumnName = "SALARIO_TIPO";
		public const string COBRA_SALARIO_MINIMOColumnName = "COBRA_SALARIO_MINIMO";
		public const string SALARIOColumnName = "SALARIO";
		public const string SALARIO_COMPLEMENTARIOColumnName = "SALARIO_COMPLEMENTARIO";
		public const string SALARIO_EXTRAColumnName = "SALARIO_EXTRA";
		public const string COBRA_ANTICIPOColumnName = "COBRA_ANTICIPO";
		public const string MONTO_ANTICIPOColumnName = "MONTO_ANTICIPO";
		public const string COBRA_BONIFICACIONColumnName = "COBRA_BONIFICACION";
		public const string MONTO_BONIFICACIONColumnName = "MONTO_BONIFICACION";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string CTACTEColumnName = "CTACTE";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string GRUPO_SANGUINEOColumnName = "GRUPO_SANGUINEO";
		public const string ES_PROMOTORColumnName = "ES_PROMOTOR";
		public const string MARCACIONES_IDColumnName = "MARCACIONES_ID";
		public const string ES_CHOFERColumnName = "ES_CHOFER";
		public const string DEPOSITEROColumnName = "DEPOSITERO";
		public const string ES_COBRADOR_EXTERNOColumnName = "ES_COBRADOR_EXTERNO";
		public const string CODIGO_TALONARIOColumnName = "CODIGO_TALONARIO";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string DESCUENTOS_BASICOColumnName = "DESCUENTOS_BASICO";
		public const string DESCUENTOS_COMPLEMENTARIOColumnName = "DESCUENTOS_COMPLEMENTARIO";
		public const string DESCUENTOS_EXTRAColumnName = "DESCUENTOS_EXTRA";
		public const string CANAL_VENTA_IDColumnName = "CANAL_VENTA_ID";
		public const string CANAL_VENTA_NOMBREColumnName = "CANAL_VENTA_NOMBRE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FUNCIONARIOS_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FUNCIONARIOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual FUNCIONARIOS_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FUNCIONARIOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FUNCIONARIOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FUNCIONARIOS_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FUNCIONARIOS_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects.</returns>
		public FUNCIONARIOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects.</returns>
		public virtual FUNCIONARIOS_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FUNCIONARIOS_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects.</returns>
		protected FUNCIONARIOS_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects.</returns>
		protected FUNCIONARIOS_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> objects.</returns>
		protected virtual FUNCIONARIOS_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
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
			int tratamiento_idColumnIndex = reader.GetOrdinal("TRATAMIENTO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int nombre_completoColumnIndex = reader.GetOrdinal("NOMBRE_COMPLETO");
			int apellidoColumnIndex = reader.GetOrdinal("APELLIDO");
			int apodoColumnIndex = reader.GetOrdinal("APODO");
			int generoColumnIndex = reader.GetOrdinal("GENERO");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int nacimientoColumnIndex = reader.GetOrdinal("NACIMIENTO");
			int tipo_documento_identidad_idColumnIndex = reader.GetOrdinal("TIPO_DOCUMENTO_IDENTIDAD_ID");
			int numero_documentoColumnIndex = reader.GetOrdinal("NUMERO_DOCUMENTO");
			int pais_nacionalidad_idColumnIndex = reader.GetOrdinal("PAIS_NACIONALIDAD_ID");
			int pais_residencia_idColumnIndex = reader.GetOrdinal("PAIS_RESIDENCIA_ID");
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
			int fecha_contratacionColumnIndex = reader.GetOrdinal("FECHA_CONTRATACION");
			int fecha_salidaColumnIndex = reader.GetOrdinal("FECHA_SALIDA");
			int motivo_salidaColumnIndex = reader.GetOrdinal("MOTIVO_SALIDA");
			int estado_civil_idColumnIndex = reader.GetOrdinal("ESTADO_CIVIL_ID");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int nombre_familiar_contactoColumnIndex = reader.GetOrdinal("NOMBRE_FAMILIAR_CONTACTO");
			int relacion_familiar_contactoColumnIndex = reader.GetOrdinal("RELACION_FAMILIAR_CONTACTO");
			int telefono_familiar_contactoColumnIndex = reader.GetOrdinal("TELEFONO_FAMILIAR_CONTACTO");
			int departamento_familiar_cont_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_FAMILIAR_CONT_ID");
			int ciudad_familiar_contacto_idColumnIndex = reader.GetOrdinal("CIUDAD_FAMILIAR_CONTACTO_ID");
			int barrio_familiar_contacto_idColumnIndex = reader.GetOrdinal("BARRIO_FAMILIAR_CONTACTO_ID");
			int calle_familiar_contactoColumnIndex = reader.GetOrdinal("CALLE_FAMILIAR_CONTACTO");
			int cod_post_familiar_contactoColumnIndex = reader.GetOrdinal("COD_POST_FAMILIAR_CONTACTO");
			int latitud_familiar_contactoColumnIndex = reader.GetOrdinal("LATITUD_FAMILIAR_CONTACTO");
			int longitud_familiar_contactoColumnIndex = reader.GetOrdinal("LONGITUD_FAMILIAR_CONTACTO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int es_vendedorColumnIndex = reader.GetOrdinal("ES_VENDEDOR");
			int es_cobradorColumnIndex = reader.GetOrdinal("ES_COBRADOR");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int sucursal_nombreColumnIndex = reader.GetOrdinal("SUCURSAL_NOMBRE");
			int ingreso_seguroColumnIndex = reader.GetOrdinal("INGRESO_SEGURO");
			int salario_tipoColumnIndex = reader.GetOrdinal("SALARIO_TIPO");
			int cobra_salario_minimoColumnIndex = reader.GetOrdinal("COBRA_SALARIO_MINIMO");
			int salarioColumnIndex = reader.GetOrdinal("SALARIO");
			int salario_complementarioColumnIndex = reader.GetOrdinal("SALARIO_COMPLEMENTARIO");
			int salario_extraColumnIndex = reader.GetOrdinal("SALARIO_EXTRA");
			int cobra_anticipoColumnIndex = reader.GetOrdinal("COBRA_ANTICIPO");
			int monto_anticipoColumnIndex = reader.GetOrdinal("MONTO_ANTICIPO");
			int cobra_bonificacionColumnIndex = reader.GetOrdinal("COBRA_BONIFICACION");
			int monto_bonificacionColumnIndex = reader.GetOrdinal("MONTO_BONIFICACION");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int ctacteColumnIndex = reader.GetOrdinal("CTACTE");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int grupo_sanguineoColumnIndex = reader.GetOrdinal("GRUPO_SANGUINEO");
			int es_promotorColumnIndex = reader.GetOrdinal("ES_PROMOTOR");
			int marcaciones_idColumnIndex = reader.GetOrdinal("MARCACIONES_ID");
			int es_choferColumnIndex = reader.GetOrdinal("ES_CHOFER");
			int depositeroColumnIndex = reader.GetOrdinal("DEPOSITERO");
			int es_cobrador_externoColumnIndex = reader.GetOrdinal("ES_COBRADOR_EXTERNO");
			int codigo_talonarioColumnIndex = reader.GetOrdinal("CODIGO_TALONARIO");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int descuentos_basicoColumnIndex = reader.GetOrdinal("DESCUENTOS_BASICO");
			int descuentos_complementarioColumnIndex = reader.GetOrdinal("DESCUENTOS_COMPLEMENTARIO");
			int descuentos_extraColumnIndex = reader.GetOrdinal("DESCUENTOS_EXTRA");
			int canal_venta_idColumnIndex = reader.GetOrdinal("CANAL_VENTA_ID");
			int canal_venta_nombreColumnIndex = reader.GetOrdinal("CANAL_VENTA_NOMBRE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FUNCIONARIOS_INFO_COMPLETARow record = new FUNCIONARIOS_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.ENTIDAD_NOMBRE = Convert.ToString(reader.GetValue(entidad_nombreColumnIndex));
					if(!reader.IsDBNull(tratamiento_idColumnIndex))
						record.TRATAMIENTO_ID = Convert.ToString(reader.GetValue(tratamiento_idColumnIndex));
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(nombre_completoColumnIndex))
						record.NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(nombre_completoColumnIndex));
					if(!reader.IsDBNull(apellidoColumnIndex))
						record.APELLIDO = Convert.ToString(reader.GetValue(apellidoColumnIndex));
					if(!reader.IsDBNull(apodoColumnIndex))
						record.APODO = Convert.ToString(reader.GetValue(apodoColumnIndex));
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
					if(!reader.IsDBNull(fecha_contratacionColumnIndex))
						record.FECHA_CONTRATACION = Convert.ToDateTime(reader.GetValue(fecha_contratacionColumnIndex));
					if(!reader.IsDBNull(fecha_salidaColumnIndex))
						record.FECHA_SALIDA = Convert.ToDateTime(reader.GetValue(fecha_salidaColumnIndex));
					if(!reader.IsDBNull(motivo_salidaColumnIndex))
						record.MOTIVO_SALIDA = Convert.ToString(reader.GetValue(motivo_salidaColumnIndex));
					if(!reader.IsDBNull(estado_civil_idColumnIndex))
						record.ESTADO_CIVIL_ID = Convert.ToString(reader.GetValue(estado_civil_idColumnIndex));
					if(!reader.IsDBNull(estado_documentacion_idColumnIndex))
						record.ESTADO_DOCUMENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_documentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombre_familiar_contactoColumnIndex))
						record.NOMBRE_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(nombre_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(relacion_familiar_contactoColumnIndex))
						record.RELACION_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(relacion_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(telefono_familiar_contactoColumnIndex))
						record.TELEFONO_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(telefono_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(departamento_familiar_cont_idColumnIndex))
						record.DEPARTAMENTO_FAMILIAR_CONT_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_familiar_cont_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_familiar_contacto_idColumnIndex))
						record.CIUDAD_FAMILIAR_CONTACTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_familiar_contacto_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_familiar_contacto_idColumnIndex))
						record.BARRIO_FAMILIAR_CONTACTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_familiar_contacto_idColumnIndex)), 9);
					if(!reader.IsDBNull(calle_familiar_contactoColumnIndex))
						record.CALLE_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(calle_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(cod_post_familiar_contactoColumnIndex))
						record.COD_POST_FAMILIAR_CONTACTO = Convert.ToString(reader.GetValue(cod_post_familiar_contactoColumnIndex));
					if(!reader.IsDBNull(latitud_familiar_contactoColumnIndex))
						record.LATITUD_FAMILIAR_CONTACTO = Math.Round(Convert.ToDecimal(reader.GetValue(latitud_familiar_contactoColumnIndex)), 9);
					if(!reader.IsDBNull(longitud_familiar_contactoColumnIndex))
						record.LONGITUD_FAMILIAR_CONTACTO = Math.Round(Convert.ToDecimal(reader.GetValue(longitud_familiar_contactoColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					record.ES_VENDEDOR = Convert.ToString(reader.GetValue(es_vendedorColumnIndex));
					record.ES_COBRADOR = Convert.ToString(reader.GetValue(es_cobradorColumnIndex));
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_nombreColumnIndex))
						record.SUCURSAL_NOMBRE = Convert.ToString(reader.GetValue(sucursal_nombreColumnIndex));
					if(!reader.IsDBNull(ingreso_seguroColumnIndex))
						record.INGRESO_SEGURO = Convert.ToDateTime(reader.GetValue(ingreso_seguroColumnIndex));
					if(!reader.IsDBNull(salario_tipoColumnIndex))
						record.SALARIO_TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(salario_tipoColumnIndex)), 9);
					if(!reader.IsDBNull(cobra_salario_minimoColumnIndex))
						record.COBRA_SALARIO_MINIMO = Convert.ToString(reader.GetValue(cobra_salario_minimoColumnIndex));
					if(!reader.IsDBNull(salarioColumnIndex))
						record.SALARIO = Math.Round(Convert.ToDecimal(reader.GetValue(salarioColumnIndex)), 9);
					if(!reader.IsDBNull(salario_complementarioColumnIndex))
						record.SALARIO_COMPLEMENTARIO = Math.Round(Convert.ToDecimal(reader.GetValue(salario_complementarioColumnIndex)), 9);
					if(!reader.IsDBNull(salario_extraColumnIndex))
						record.SALARIO_EXTRA = Math.Round(Convert.ToDecimal(reader.GetValue(salario_extraColumnIndex)), 9);
					if(!reader.IsDBNull(cobra_anticipoColumnIndex))
						record.COBRA_ANTICIPO = Convert.ToString(reader.GetValue(cobra_anticipoColumnIndex));
					if(!reader.IsDBNull(monto_anticipoColumnIndex))
						record.MONTO_ANTICIPO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_anticipoColumnIndex)), 9);
					if(!reader.IsDBNull(cobra_bonificacionColumnIndex))
						record.COBRA_BONIFICACION = Convert.ToString(reader.GetValue(cobra_bonificacionColumnIndex));
					if(!reader.IsDBNull(monto_bonificacionColumnIndex))
						record.MONTO_BONIFICACION = Math.Round(Convert.ToDecimal(reader.GetValue(monto_bonificacionColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_nombreColumnIndex))
						record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_simboloColumnIndex))
						record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(ctacteColumnIndex))
						record.CTACTE = Convert.ToString(reader.GetValue(ctacteColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_sanguineoColumnIndex))
						record.GRUPO_SANGUINEO = Convert.ToString(reader.GetValue(grupo_sanguineoColumnIndex));
					record.ES_PROMOTOR = Convert.ToString(reader.GetValue(es_promotorColumnIndex));
					if(!reader.IsDBNull(marcaciones_idColumnIndex))
						record.MARCACIONES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(marcaciones_idColumnIndex)), 9);
					record.ES_CHOFER = Convert.ToString(reader.GetValue(es_choferColumnIndex));
					record.DEPOSITERO = Convert.ToString(reader.GetValue(depositeroColumnIndex));
					record.ES_COBRADOR_EXTERNO = Convert.ToString(reader.GetValue(es_cobrador_externoColumnIndex));
					if(!reader.IsDBNull(codigo_talonarioColumnIndex))
						record.CODIGO_TALONARIO = Convert.ToString(reader.GetValue(codigo_talonarioColumnIndex));
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(descuentos_basicoColumnIndex))
						record.DESCUENTOS_BASICO = Convert.ToString(reader.GetValue(descuentos_basicoColumnIndex));
					if(!reader.IsDBNull(descuentos_complementarioColumnIndex))
						record.DESCUENTOS_COMPLEMENTARIO = Convert.ToString(reader.GetValue(descuentos_complementarioColumnIndex));
					if(!reader.IsDBNull(descuentos_extraColumnIndex))
						record.DESCUENTOS_EXTRA = Convert.ToString(reader.GetValue(descuentos_extraColumnIndex));
					if(!reader.IsDBNull(canal_venta_idColumnIndex))
						record.CANAL_VENTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(canal_venta_idColumnIndex)), 9);
					if(!reader.IsDBNull(canal_venta_nombreColumnIndex))
						record.CANAL_VENTA_NOMBRE = Convert.ToString(reader.GetValue(canal_venta_nombreColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FUNCIONARIOS_INFO_COMPLETARow[])(recordList.ToArray(typeof(FUNCIONARIOS_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FUNCIONARIOS_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FUNCIONARIOS_INFO_COMPLETARow"/> object.</returns>
		protected virtual FUNCIONARIOS_INFO_COMPLETARow MapRow(DataRow row)
		{
			FUNCIONARIOS_INFO_COMPLETARow mappedObject = new FUNCIONARIOS_INFO_COMPLETARow();
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
			// Column "TRATAMIENTO_ID"
			dataColumn = dataTable.Columns["TRATAMIENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRATAMIENTO_ID = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "APELLIDO"
			dataColumn = dataTable.Columns["APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APELLIDO = (string)row[dataColumn];
			// Column "APODO"
			dataColumn = dataTable.Columns["APODO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APODO = (string)row[dataColumn];
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
			// Column "FECHA_CONTRATACION"
			dataColumn = dataTable.Columns["FECHA_CONTRATACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONTRATACION = (System.DateTime)row[dataColumn];
			// Column "FECHA_SALIDA"
			dataColumn = dataTable.Columns["FECHA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA = (System.DateTime)row[dataColumn];
			// Column "MOTIVO_SALIDA"
			dataColumn = dataTable.Columns["MOTIVO_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOTIVO_SALIDA = (string)row[dataColumn];
			// Column "ESTADO_CIVIL_ID"
			dataColumn = dataTable.Columns["ESTADO_CIVIL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_CIVIL_ID = (string)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_ID"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_ID = (decimal)row[dataColumn];
			// Column "NOMBRE_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["NOMBRE_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "RELACION_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["RELACION_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RELACION_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "TELEFONO_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["TELEFONO_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "DEPARTAMENTO_FAMILIAR_CONT_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_FAMILIAR_CONT_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_FAMILIAR_CONT_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_FAMILIAR_CONTACTO_ID"
			dataColumn = dataTable.Columns["CIUDAD_FAMILIAR_CONTACTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_FAMILIAR_CONTACTO_ID = (decimal)row[dataColumn];
			// Column "BARRIO_FAMILIAR_CONTACTO_ID"
			dataColumn = dataTable.Columns["BARRIO_FAMILIAR_CONTACTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_FAMILIAR_CONTACTO_ID = (decimal)row[dataColumn];
			// Column "CALLE_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["CALLE_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "COD_POST_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["COD_POST_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COD_POST_FAMILIAR_CONTACTO = (string)row[dataColumn];
			// Column "LATITUD_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["LATITUD_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD_FAMILIAR_CONTACTO = (decimal)row[dataColumn];
			// Column "LONGITUD_FAMILIAR_CONTACTO"
			dataColumn = dataTable.Columns["LONGITUD_FAMILIAR_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD_FAMILIAR_CONTACTO = (decimal)row[dataColumn];
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
			// Column "ES_VENDEDOR"
			dataColumn = dataTable.Columns["ES_VENDEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_VENDEDOR = (string)row[dataColumn];
			// Column "ES_COBRADOR"
			dataColumn = dataTable.Columns["ES_COBRADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COBRADOR = (string)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_NOMBRE"
			dataColumn = dataTable.Columns["SUCURSAL_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_NOMBRE = (string)row[dataColumn];
			// Column "INGRESO_SEGURO"
			dataColumn = dataTable.Columns["INGRESO_SEGURO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INGRESO_SEGURO = (System.DateTime)row[dataColumn];
			// Column "SALARIO_TIPO"
			dataColumn = dataTable.Columns["SALARIO_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO_TIPO = (decimal)row[dataColumn];
			// Column "COBRA_SALARIO_MINIMO"
			dataColumn = dataTable.Columns["COBRA_SALARIO_MINIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRA_SALARIO_MINIMO = (string)row[dataColumn];
			// Column "SALARIO"
			dataColumn = dataTable.Columns["SALARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO = (decimal)row[dataColumn];
			// Column "SALARIO_COMPLEMENTARIO"
			dataColumn = dataTable.Columns["SALARIO_COMPLEMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO_COMPLEMENTARIO = (decimal)row[dataColumn];
			// Column "SALARIO_EXTRA"
			dataColumn = dataTable.Columns["SALARIO_EXTRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALARIO_EXTRA = (decimal)row[dataColumn];
			// Column "COBRA_ANTICIPO"
			dataColumn = dataTable.Columns["COBRA_ANTICIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRA_ANTICIPO = (string)row[dataColumn];
			// Column "MONTO_ANTICIPO"
			dataColumn = dataTable.Columns["MONTO_ANTICIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ANTICIPO = (decimal)row[dataColumn];
			// Column "COBRA_BONIFICACION"
			dataColumn = dataTable.Columns["COBRA_BONIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRA_BONIFICACION = (string)row[dataColumn];
			// Column "MONTO_BONIFICACION"
			dataColumn = dataTable.Columns["MONTO_BONIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_BONIFICACION = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_NOMBRE"
			dataColumn = dataTable.Columns["MONEDA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_NOMBRE = (string)row[dataColumn];
			// Column "MONEDA_SIMBOLO"
			dataColumn = dataTable.Columns["MONEDA_SIMBOLO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_SIMBOLO = (string)row[dataColumn];
			// Column "CTACTE"
			dataColumn = dataTable.Columns["CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "GRUPO_SANGUINEO"
			dataColumn = dataTable.Columns["GRUPO_SANGUINEO"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_SANGUINEO = (string)row[dataColumn];
			// Column "ES_PROMOTOR"
			dataColumn = dataTable.Columns["ES_PROMOTOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_PROMOTOR = (string)row[dataColumn];
			// Column "MARCACIONES_ID"
			dataColumn = dataTable.Columns["MARCACIONES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCACIONES_ID = (decimal)row[dataColumn];
			// Column "ES_CHOFER"
			dataColumn = dataTable.Columns["ES_CHOFER"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CHOFER = (string)row[dataColumn];
			// Column "DEPOSITERO"
			dataColumn = dataTable.Columns["DEPOSITERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITERO = (string)row[dataColumn];
			// Column "ES_COBRADOR_EXTERNO"
			dataColumn = dataTable.Columns["ES_COBRADOR_EXTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_COBRADOR_EXTERNO = (string)row[dataColumn];
			// Column "CODIGO_TALONARIO"
			dataColumn = dataTable.Columns["CODIGO_TALONARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_TALONARIO = (string)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "DESCUENTOS_BASICO"
			dataColumn = dataTable.Columns["DESCUENTOS_BASICO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTOS_BASICO = (string)row[dataColumn];
			// Column "DESCUENTOS_COMPLEMENTARIO"
			dataColumn = dataTable.Columns["DESCUENTOS_COMPLEMENTARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTOS_COMPLEMENTARIO = (string)row[dataColumn];
			// Column "DESCUENTOS_EXTRA"
			dataColumn = dataTable.Columns["DESCUENTOS_EXTRA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTOS_EXTRA = (string)row[dataColumn];
			// Column "CANAL_VENTA_ID"
			dataColumn = dataTable.Columns["CANAL_VENTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_ID = (decimal)row[dataColumn];
			// Column "CANAL_VENTA_NOMBRE"
			dataColumn = dataTable.Columns["CANAL_VENTA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANAL_VENTA_NOMBRE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FUNCIONARIOS_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FUNCIONARIOS_INFO_COMPLETA";
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
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TRATAMIENTO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 141;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("APODO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GENERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NACIMIENTO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_DOCUMENTO_IDENTIDAD_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_NACIONALIDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_RESIDENCIA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROFESION_ID", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE1", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL1", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD1", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD1", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE2", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL2", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD2", typeof(decimal));
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
			dataColumn = dataTable.Columns.Add("FECHA_CONTRATACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MOTIVO_SALIDA", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_CIVIL_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RELACION_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_FAMILIAR_CONT_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD_FAMILIAR_CONTACTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO_FAMILIAR_CONTACTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 2000;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COD_POST_FAMILIAR_CONTACTO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD_FAMILIAR_CONTACTO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD_FAMILIAR_CONTACTO", typeof(decimal));
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
			dataColumn = dataTable.Columns.Add("ES_VENDEDOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_COBRADOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUCURSAL_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INGRESO_SEGURO", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALARIO_TIPO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COBRA_SALARIO_MINIMO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALARIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALARIO_COMPLEMENTARIO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SALARIO_EXTRA", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COBRA_ANTICIPO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_ANTICIPO", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("COBRA_BONIFICACION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONTO_BONIFICACION", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CTACTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("GRUPO_SANGUINEO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_PROMOTOR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MARCACIONES_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_CHOFER", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPOSITERO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_COBRADOR_EXTERNO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_TALONARIO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTOS_BASICO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTOS_COMPLEMENTARIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DESCUENTOS_EXTRA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CANAL_VENTA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "TRATAMIENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APODO":
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

				case "FECHA_CONTRATACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MOTIVO_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_CIVIL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO_DOCUMENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RELACION_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO_FAMILIAR_CONT_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_FAMILIAR_CONTACTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_FAMILIAR_CONTACTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COD_POST_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD_FAMILIAR_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "ES_VENDEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COBRADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INGRESO_SEGURO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "SALARIO_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRA_SALARIO_MINIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SALARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALARIO_COMPLEMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SALARIO_EXTRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRA_ANTICIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_ANTICIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRA_BONIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MONTO_BONIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MONEDA_SIMBOLO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_SANGUINEO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_PROMOTOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MARCACIONES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_CHOFER":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DEPOSITERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_COBRADOR_EXTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CODIGO_TALONARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTOS_BASICO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCUENTOS_COMPLEMENTARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESCUENTOS_EXTRA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CANAL_VENTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANAL_VENTA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FUNCIONARIOS_INFO_COMPLETACollection_Base class
}  // End of namespace
