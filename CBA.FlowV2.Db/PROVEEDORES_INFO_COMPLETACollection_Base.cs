// <fileinfo name="PROVEEDORES_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="PROVEEDORES_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PROVEEDORES_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PROVEEDORES_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string CODIGOColumnName = "CODIGO";
		public const string RAZON_SOCIALColumnName = "RAZON_SOCIAL";
		public const string NOMBRE_FANTASIAColumnName = "NOMBRE_FANTASIA";
		public const string RUBRO_IDColumnName = "RUBRO_ID";
		public const string RUBRO_NOMBREColumnName = "RUBRO_NOMBRE";
		public const string RUCColumnName = "RUC";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string MONEDA_NOMBREColumnName = "MONEDA_NOMBRE";
		public const string MONEDA_SIMBOLOColumnName = "MONEDA_SIMBOLO";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string PERSONA_NOMBRE_COMPLETOColumnName = "PERSONA_NOMBRE_COMPLETO";
		public const string PERSONA_CODIGOColumnName = "PERSONA_CODIGO";
		public const string OPERA_CREDITOColumnName = "OPERA_CREDITO";
		public const string CONDICION_HABITUAL_PAGO_IDColumnName = "CONDICION_HABITUAL_PAGO_ID";
		public const string CONDICION_HABITUAL_PAGO_NOMBREColumnName = "CONDICION_HABITUAL_PAGO_NOMBRE";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string PAIS_NOMBREColumnName = "PAIS_NOMBRE";
		public const string PAIS_ABREVIATURAColumnName = "PAIS_ABREVIATURA";
		public const string DEPARTAMENTO1_IDColumnName = "DEPARTAMENTO1_ID";
		public const string DEPARTAMENTO1_NOMBREColumnName = "DEPARTAMENTO1_NOMBRE";
		public const string DEPARTAMENTO1_ABREVIATURAColumnName = "DEPARTAMENTO1_ABREVIATURA";
		public const string CIUDAD1_IDColumnName = "CIUDAD1_ID";
		public const string CIUDAD1_NOMBREColumnName = "CIUDAD1_NOMBRE";
		public const string CIUDAD1_ABREVIATURAColumnName = "CIUDAD1_ABREVIATURA";
		public const string BARRIO1_IDColumnName = "BARRIO1_ID";
		public const string BARRIO1_NOMBREColumnName = "BARRIO1_NOMBRE";
		public const string BARRIO1_ABREVIATURAColumnName = "BARRIO1_ABREVIATURA";
		public const string CALLE1ColumnName = "CALLE1";
		public const string CODIGO_POSTAL1ColumnName = "CODIGO_POSTAL1";
		public const string LATITUD1ColumnName = "LATITUD1";
		public const string LONGITUD1ColumnName = "LONGITUD1";
		public const string DEPARTAMENTO2_IDColumnName = "DEPARTAMENTO2_ID";
		public const string DEPARTAMENTO2_NOMBREColumnName = "DEPARTAMENTO2_NOMBRE";
		public const string DEPARTAMENTO2_ABREVIATURAColumnName = "DEPARTAMENTO2_ABREVIATURA";
		public const string CIUDAD2_IDColumnName = "CIUDAD2_ID";
		public const string CIUDAD2_NOMBREColumnName = "CIUDAD2_NOMBRE";
		public const string CIUDAD2_ABREVIATURAColumnName = "CIUDAD2_ABREVIATURA";
		public const string BARRIO2_IDColumnName = "BARRIO2_ID";
		public const string BARRIO2_NOMBREColumnName = "BARRIO2_NOMBRE";
		public const string BARRIO2_ABREVIATURAColumnName = "BARRIO2_ABREVIATURA";
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
		public const string PASIBLE_RETENCIONColumnName = "PASIBLE_RETENCION";
		public const string BANDERA_RETENCIONColumnName = "BANDERA_RETENCION";
		public const string FECHA_FUNDACIONColumnName = "FECHA_FUNDACION";
		public const string CONTACTO_PERSONAColumnName = "CONTACTO_PERSONA";
		public const string CONTACTO_TELEFONOColumnName = "CONTACTO_TELEFONO";
		public const string CONTACTO_EMAILColumnName = "CONTACTO_EMAIL";
		public const string ESTADOColumnName = "ESTADO";
		public const string INGRESO_APROBADOColumnName = "INGRESO_APROBADO";
		public const string USUARIO_APROBACION_IDColumnName = "USUARIO_APROBACION_ID";
		public const string FECHA_APROBACIONColumnName = "FECHA_APROBACION";
		public const string CTACTE_BANCO_IDColumnName = "CTACTE_BANCO_ID";
		public const string SOLICITA_REFERENCIAColumnName = "SOLICITA_REFERENCIA";
		public const string ES_NACIONALColumnName = "ES_NACIONAL";
		public const string FC_OBSERVACION_DETALLEColumnName = "FC_OBSERVACION_DETALLE";
		public const string FECHA_DESDE_NO_RETENERColumnName = "FECHA_DESDE_NO_RETENER";
		public const string FECHA_HASTA_NO_RETENERColumnName = "FECHA_HASTA_NO_RETENER";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PROVEEDORES_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PROVEEDORES_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PROVEEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects.</returns>
		public virtual PROVEEDORES_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PROVEEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PROVEEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PROVEEDORES_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PROVEEDORES_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PROVEEDORES_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects.</returns>
		public PROVEEDORES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects.</returns>
		public virtual PROVEEDORES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PROVEEDORES_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects.</returns>
		protected PROVEEDORES_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects.</returns>
		protected PROVEEDORES_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PROVEEDORES_INFO_COMPLETARow"/> objects.</returns>
		protected virtual PROVEEDORES_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int razon_socialColumnIndex = reader.GetOrdinal("RAZON_SOCIAL");
			int nombre_fantasiaColumnIndex = reader.GetOrdinal("NOMBRE_FANTASIA");
			int rubro_idColumnIndex = reader.GetOrdinal("RUBRO_ID");
			int rubro_nombreColumnIndex = reader.GetOrdinal("RUBRO_NOMBRE");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int moneda_nombreColumnIndex = reader.GetOrdinal("MONEDA_NOMBRE");
			int moneda_simboloColumnIndex = reader.GetOrdinal("MONEDA_SIMBOLO");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int persona_nombre_completoColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE_COMPLETO");
			int persona_codigoColumnIndex = reader.GetOrdinal("PERSONA_CODIGO");
			int opera_creditoColumnIndex = reader.GetOrdinal("OPERA_CREDITO");
			int condicion_habitual_pago_idColumnIndex = reader.GetOrdinal("CONDICION_HABITUAL_PAGO_ID");
			int condicion_habitual_pago_nombreColumnIndex = reader.GetOrdinal("CONDICION_HABITUAL_PAGO_NOMBRE");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int pais_nombreColumnIndex = reader.GetOrdinal("PAIS_NOMBRE");
			int pais_abreviaturaColumnIndex = reader.GetOrdinal("PAIS_ABREVIATURA");
			int departamento1_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO1_ID");
			int departamento1_nombreColumnIndex = reader.GetOrdinal("DEPARTAMENTO1_NOMBRE");
			int departamento1_abreviaturaColumnIndex = reader.GetOrdinal("DEPARTAMENTO1_ABREVIATURA");
			int ciudad1_idColumnIndex = reader.GetOrdinal("CIUDAD1_ID");
			int ciudad1_nombreColumnIndex = reader.GetOrdinal("CIUDAD1_NOMBRE");
			int ciudad1_abreviaturaColumnIndex = reader.GetOrdinal("CIUDAD1_ABREVIATURA");
			int barrio1_idColumnIndex = reader.GetOrdinal("BARRIO1_ID");
			int barrio1_nombreColumnIndex = reader.GetOrdinal("BARRIO1_NOMBRE");
			int barrio1_abreviaturaColumnIndex = reader.GetOrdinal("BARRIO1_ABREVIATURA");
			int calle1ColumnIndex = reader.GetOrdinal("CALLE1");
			int codigo_postal1ColumnIndex = reader.GetOrdinal("CODIGO_POSTAL1");
			int latitud1ColumnIndex = reader.GetOrdinal("LATITUD1");
			int longitud1ColumnIndex = reader.GetOrdinal("LONGITUD1");
			int departamento2_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_ID");
			int departamento2_nombreColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_NOMBRE");
			int departamento2_abreviaturaColumnIndex = reader.GetOrdinal("DEPARTAMENTO2_ABREVIATURA");
			int ciudad2_idColumnIndex = reader.GetOrdinal("CIUDAD2_ID");
			int ciudad2_nombreColumnIndex = reader.GetOrdinal("CIUDAD2_NOMBRE");
			int ciudad2_abreviaturaColumnIndex = reader.GetOrdinal("CIUDAD2_ABREVIATURA");
			int barrio2_idColumnIndex = reader.GetOrdinal("BARRIO2_ID");
			int barrio2_nombreColumnIndex = reader.GetOrdinal("BARRIO2_NOMBRE");
			int barrio2_abreviaturaColumnIndex = reader.GetOrdinal("BARRIO2_ABREVIATURA");
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
			int pasible_retencionColumnIndex = reader.GetOrdinal("PASIBLE_RETENCION");
			int bandera_retencionColumnIndex = reader.GetOrdinal("BANDERA_RETENCION");
			int fecha_fundacionColumnIndex = reader.GetOrdinal("FECHA_FUNDACION");
			int contacto_personaColumnIndex = reader.GetOrdinal("CONTACTO_PERSONA");
			int contacto_telefonoColumnIndex = reader.GetOrdinal("CONTACTO_TELEFONO");
			int contacto_emailColumnIndex = reader.GetOrdinal("CONTACTO_EMAIL");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int ingreso_aprobadoColumnIndex = reader.GetOrdinal("INGRESO_APROBADO");
			int usuario_aprobacion_idColumnIndex = reader.GetOrdinal("USUARIO_APROBACION_ID");
			int fecha_aprobacionColumnIndex = reader.GetOrdinal("FECHA_APROBACION");
			int ctacte_banco_idColumnIndex = reader.GetOrdinal("CTACTE_BANCO_ID");
			int solicita_referenciaColumnIndex = reader.GetOrdinal("SOLICITA_REFERENCIA");
			int es_nacionalColumnIndex = reader.GetOrdinal("ES_NACIONAL");
			int fc_observacion_detalleColumnIndex = reader.GetOrdinal("FC_OBSERVACION_DETALLE");
			int fecha_desde_no_retenerColumnIndex = reader.GetOrdinal("FECHA_DESDE_NO_RETENER");
			int fecha_hasta_no_retenerColumnIndex = reader.GetOrdinal("FECHA_HASTA_NO_RETENER");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PROVEEDORES_INFO_COMPLETARow record = new PROVEEDORES_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					record.RAZON_SOCIAL = Convert.ToString(reader.GetValue(razon_socialColumnIndex));
					if(!reader.IsDBNull(nombre_fantasiaColumnIndex))
						record.NOMBRE_FANTASIA = Convert.ToString(reader.GetValue(nombre_fantasiaColumnIndex));
					if(!reader.IsDBNull(rubro_idColumnIndex))
						record.RUBRO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(rubro_idColumnIndex)), 9);
					if(!reader.IsDBNull(rubro_nombreColumnIndex))
						record.RUBRO_NOMBRE = Convert.ToString(reader.GetValue(rubro_nombreColumnIndex));
					record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_nombreColumnIndex))
						record.MONEDA_NOMBRE = Convert.ToString(reader.GetValue(moneda_nombreColumnIndex));
					if(!reader.IsDBNull(moneda_simboloColumnIndex))
						record.MONEDA_SIMBOLO = Convert.ToString(reader.GetValue(moneda_simboloColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombre_completoColumnIndex))
						record.PERSONA_NOMBRE_COMPLETO = Convert.ToString(reader.GetValue(persona_nombre_completoColumnIndex));
					if(!reader.IsDBNull(persona_codigoColumnIndex))
						record.PERSONA_CODIGO = Convert.ToString(reader.GetValue(persona_codigoColumnIndex));
					if(!reader.IsDBNull(opera_creditoColumnIndex))
						record.OPERA_CREDITO = Convert.ToString(reader.GetValue(opera_creditoColumnIndex));
					if(!reader.IsDBNull(condicion_habitual_pago_idColumnIndex))
						record.CONDICION_HABITUAL_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_habitual_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(condicion_habitual_pago_nombreColumnIndex))
						record.CONDICION_HABITUAL_PAGO_NOMBRE = Convert.ToString(reader.GetValue(condicion_habitual_pago_nombreColumnIndex));
					record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(pais_nombreColumnIndex))
						record.PAIS_NOMBRE = Convert.ToString(reader.GetValue(pais_nombreColumnIndex));
					if(!reader.IsDBNull(pais_abreviaturaColumnIndex))
						record.PAIS_ABREVIATURA = Convert.ToString(reader.GetValue(pais_abreviaturaColumnIndex));
					if(!reader.IsDBNull(departamento1_idColumnIndex))
						record.DEPARTAMENTO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento1_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento1_nombreColumnIndex))
						record.DEPARTAMENTO1_NOMBRE = Convert.ToString(reader.GetValue(departamento1_nombreColumnIndex));
					if(!reader.IsDBNull(departamento1_abreviaturaColumnIndex))
						record.DEPARTAMENTO1_ABREVIATURA = Convert.ToString(reader.GetValue(departamento1_abreviaturaColumnIndex));
					if(!reader.IsDBNull(ciudad1_idColumnIndex))
						record.CIUDAD1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad1_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad1_nombreColumnIndex))
						record.CIUDAD1_NOMBRE = Convert.ToString(reader.GetValue(ciudad1_nombreColumnIndex));
					if(!reader.IsDBNull(ciudad1_abreviaturaColumnIndex))
						record.CIUDAD1_ABREVIATURA = Convert.ToString(reader.GetValue(ciudad1_abreviaturaColumnIndex));
					if(!reader.IsDBNull(barrio1_idColumnIndex))
						record.BARRIO1_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio1_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio1_nombreColumnIndex))
						record.BARRIO1_NOMBRE = Convert.ToString(reader.GetValue(barrio1_nombreColumnIndex));
					if(!reader.IsDBNull(barrio1_abreviaturaColumnIndex))
						record.BARRIO1_ABREVIATURA = Convert.ToString(reader.GetValue(barrio1_abreviaturaColumnIndex));
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
					if(!reader.IsDBNull(departamento2_nombreColumnIndex))
						record.DEPARTAMENTO2_NOMBRE = Convert.ToString(reader.GetValue(departamento2_nombreColumnIndex));
					if(!reader.IsDBNull(departamento2_abreviaturaColumnIndex))
						record.DEPARTAMENTO2_ABREVIATURA = Convert.ToString(reader.GetValue(departamento2_abreviaturaColumnIndex));
					if(!reader.IsDBNull(ciudad2_idColumnIndex))
						record.CIUDAD2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad2_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad2_nombreColumnIndex))
						record.CIUDAD2_NOMBRE = Convert.ToString(reader.GetValue(ciudad2_nombreColumnIndex));
					if(!reader.IsDBNull(ciudad2_abreviaturaColumnIndex))
						record.CIUDAD2_ABREVIATURA = Convert.ToString(reader.GetValue(ciudad2_abreviaturaColumnIndex));
					if(!reader.IsDBNull(barrio2_idColumnIndex))
						record.BARRIO2_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio2_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio2_nombreColumnIndex))
						record.BARRIO2_NOMBRE = Convert.ToString(reader.GetValue(barrio2_nombreColumnIndex));
					if(!reader.IsDBNull(barrio2_abreviaturaColumnIndex))
						record.BARRIO2_ABREVIATURA = Convert.ToString(reader.GetValue(barrio2_abreviaturaColumnIndex));
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
					record.PASIBLE_RETENCION = Convert.ToString(reader.GetValue(pasible_retencionColumnIndex));
					record.BANDERA_RETENCION = Convert.ToString(reader.GetValue(bandera_retencionColumnIndex));
					if(!reader.IsDBNull(fecha_fundacionColumnIndex))
						record.FECHA_FUNDACION = Convert.ToDateTime(reader.GetValue(fecha_fundacionColumnIndex));
					if(!reader.IsDBNull(contacto_personaColumnIndex))
						record.CONTACTO_PERSONA = Convert.ToString(reader.GetValue(contacto_personaColumnIndex));
					if(!reader.IsDBNull(contacto_telefonoColumnIndex))
						record.CONTACTO_TELEFONO = Convert.ToString(reader.GetValue(contacto_telefonoColumnIndex));
					if(!reader.IsDBNull(contacto_emailColumnIndex))
						record.CONTACTO_EMAIL = Convert.ToString(reader.GetValue(contacto_emailColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.INGRESO_APROBADO = Convert.ToString(reader.GetValue(ingreso_aprobadoColumnIndex));
					if(!reader.IsDBNull(usuario_aprobacion_idColumnIndex))
						record.USUARIO_APROBACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_aprobacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_aprobacionColumnIndex))
						record.FECHA_APROBACION = Convert.ToDateTime(reader.GetValue(fecha_aprobacionColumnIndex));
					if(!reader.IsDBNull(ctacte_banco_idColumnIndex))
						record.CTACTE_BANCO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_banco_idColumnIndex)), 9);
					record.SOLICITA_REFERENCIA = Convert.ToString(reader.GetValue(solicita_referenciaColumnIndex));
					record.ES_NACIONAL = Convert.ToString(reader.GetValue(es_nacionalColumnIndex));
					if(!reader.IsDBNull(fc_observacion_detalleColumnIndex))
						record.FC_OBSERVACION_DETALLE = Convert.ToString(reader.GetValue(fc_observacion_detalleColumnIndex));
					if(!reader.IsDBNull(fecha_desde_no_retenerColumnIndex))
						record.FECHA_DESDE_NO_RETENER = Convert.ToDateTime(reader.GetValue(fecha_desde_no_retenerColumnIndex));
					if(!reader.IsDBNull(fecha_hasta_no_retenerColumnIndex))
						record.FECHA_HASTA_NO_RETENER = Convert.ToDateTime(reader.GetValue(fecha_hasta_no_retenerColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PROVEEDORES_INFO_COMPLETARow[])(recordList.ToArray(typeof(PROVEEDORES_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PROVEEDORES_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PROVEEDORES_INFO_COMPLETARow"/> object.</returns>
		protected virtual PROVEEDORES_INFO_COMPLETARow MapRow(DataRow row)
		{
			PROVEEDORES_INFO_COMPLETARow mappedObject = new PROVEEDORES_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "RAZON_SOCIAL"
			dataColumn = dataTable.Columns["RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_SOCIAL = (string)row[dataColumn];
			// Column "NOMBRE_FANTASIA"
			dataColumn = dataTable.Columns["NOMBRE_FANTASIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_FANTASIA = (string)row[dataColumn];
			// Column "RUBRO_ID"
			dataColumn = dataTable.Columns["RUBRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_ID = (decimal)row[dataColumn];
			// Column "RUBRO_NOMBRE"
			dataColumn = dataTable.Columns["RUBRO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUBRO_NOMBRE = (string)row[dataColumn];
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
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
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE_COMPLETO"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE_COMPLETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE_COMPLETO = (string)row[dataColumn];
			// Column "PERSONA_CODIGO"
			dataColumn = dataTable.Columns["PERSONA_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_CODIGO = (string)row[dataColumn];
			// Column "OPERA_CREDITO"
			dataColumn = dataTable.Columns["OPERA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERA_CREDITO = (string)row[dataColumn];
			// Column "CONDICION_HABITUAL_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_HABITUAL_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_HABITUAL_PAGO_ID = (decimal)row[dataColumn];
			// Column "CONDICION_HABITUAL_PAGO_NOMBRE"
			dataColumn = dataTable.Columns["CONDICION_HABITUAL_PAGO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_HABITUAL_PAGO_NOMBRE = (string)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "PAIS_NOMBRE"
			dataColumn = dataTable.Columns["PAIS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_NOMBRE = (string)row[dataColumn];
			// Column "PAIS_ABREVIATURA"
			dataColumn = dataTable.Columns["PAIS_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ABREVIATURA = (string)row[dataColumn];
			// Column "DEPARTAMENTO1_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO1_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO1_NOMBRE"
			dataColumn = dataTable.Columns["DEPARTAMENTO1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO1_NOMBRE = (string)row[dataColumn];
			// Column "DEPARTAMENTO1_ABREVIATURA"
			dataColumn = dataTable.Columns["DEPARTAMENTO1_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO1_ABREVIATURA = (string)row[dataColumn];
			// Column "CIUDAD1_ID"
			dataColumn = dataTable.Columns["CIUDAD1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_ID = (decimal)row[dataColumn];
			// Column "CIUDAD1_NOMBRE"
			dataColumn = dataTable.Columns["CIUDAD1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_NOMBRE = (string)row[dataColumn];
			// Column "CIUDAD1_ABREVIATURA"
			dataColumn = dataTable.Columns["CIUDAD1_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD1_ABREVIATURA = (string)row[dataColumn];
			// Column "BARRIO1_ID"
			dataColumn = dataTable.Columns["BARRIO1_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_ID = (decimal)row[dataColumn];
			// Column "BARRIO1_NOMBRE"
			dataColumn = dataTable.Columns["BARRIO1_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_NOMBRE = (string)row[dataColumn];
			// Column "BARRIO1_ABREVIATURA"
			dataColumn = dataTable.Columns["BARRIO1_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO1_ABREVIATURA = (string)row[dataColumn];
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
			// Column "DEPARTAMENTO2_NOMBRE"
			dataColumn = dataTable.Columns["DEPARTAMENTO2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO2_NOMBRE = (string)row[dataColumn];
			// Column "DEPARTAMENTO2_ABREVIATURA"
			dataColumn = dataTable.Columns["DEPARTAMENTO2_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO2_ABREVIATURA = (string)row[dataColumn];
			// Column "CIUDAD2_ID"
			dataColumn = dataTable.Columns["CIUDAD2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_ID = (decimal)row[dataColumn];
			// Column "CIUDAD2_NOMBRE"
			dataColumn = dataTable.Columns["CIUDAD2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_NOMBRE = (string)row[dataColumn];
			// Column "CIUDAD2_ABREVIATURA"
			dataColumn = dataTable.Columns["CIUDAD2_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD2_ABREVIATURA = (string)row[dataColumn];
			// Column "BARRIO2_ID"
			dataColumn = dataTable.Columns["BARRIO2_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_ID = (decimal)row[dataColumn];
			// Column "BARRIO2_NOMBRE"
			dataColumn = dataTable.Columns["BARRIO2_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_NOMBRE = (string)row[dataColumn];
			// Column "BARRIO2_ABREVIATURA"
			dataColumn = dataTable.Columns["BARRIO2_ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO2_ABREVIATURA = (string)row[dataColumn];
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
			// Column "PASIBLE_RETENCION"
			dataColumn = dataTable.Columns["PASIBLE_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.PASIBLE_RETENCION = (string)row[dataColumn];
			// Column "BANDERA_RETENCION"
			dataColumn = dataTable.Columns["BANDERA_RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.BANDERA_RETENCION = (string)row[dataColumn];
			// Column "FECHA_FUNDACION"
			dataColumn = dataTable.Columns["FECHA_FUNDACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FUNDACION = (System.DateTime)row[dataColumn];
			// Column "CONTACTO_PERSONA"
			dataColumn = dataTable.Columns["CONTACTO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTACTO_PERSONA = (string)row[dataColumn];
			// Column "CONTACTO_TELEFONO"
			dataColumn = dataTable.Columns["CONTACTO_TELEFONO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTACTO_TELEFONO = (string)row[dataColumn];
			// Column "CONTACTO_EMAIL"
			dataColumn = dataTable.Columns["CONTACTO_EMAIL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTACTO_EMAIL = (string)row[dataColumn];
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
			// Column "CTACTE_BANCO_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCO_ID = (decimal)row[dataColumn];
			// Column "SOLICITA_REFERENCIA"
			dataColumn = dataTable.Columns["SOLICITA_REFERENCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SOLICITA_REFERENCIA = (string)row[dataColumn];
			// Column "ES_NACIONAL"
			dataColumn = dataTable.Columns["ES_NACIONAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_NACIONAL = (string)row[dataColumn];
			// Column "FC_OBSERVACION_DETALLE"
			dataColumn = dataTable.Columns["FC_OBSERVACION_DETALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_OBSERVACION_DETALLE = (string)row[dataColumn];
			// Column "FECHA_DESDE_NO_RETENER"
			dataColumn = dataTable.Columns["FECHA_DESDE_NO_RETENER"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESDE_NO_RETENER = (System.DateTime)row[dataColumn];
			// Column "FECHA_HASTA_NO_RETENER"
			dataColumn = dataTable.Columns["FECHA_HASTA_NO_RETENER"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HASTA_NO_RETENER = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PROVEEDORES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PROVEEDORES_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE_FANTASIA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUBRO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MONEDA_SIMBOLO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE_COMPLETO", typeof(string));
			dataColumn.MaxLength = 180;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_CODIGO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("OPERA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_HABITUAL_PAGO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONDICION_HABITUAL_PAGO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO1_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD1_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO1_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO1_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO1_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE1", typeof(string));
			dataColumn.MaxLength = 80;
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
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO2_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD2_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO2_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO2_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO2_ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE2", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL2", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD2", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO1", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO2", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO3", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO4", typeof(string));
			dataColumn.MaxLength = 15;
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
			dataColumn = dataTable.Columns.Add("PASIBLE_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BANDERA_RETENCION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_FUNDACION", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTACTO_PERSONA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTACTO_TELEFONO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CONTACTO_EMAIL", typeof(string));
			dataColumn.MaxLength = 100;
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
			dataColumn = dataTable.Columns.Add("CTACTE_BANCO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SOLICITA_REFERENCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_NACIONAL", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FC_OBSERVACION_DETALLE", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_DESDE_NO_RETENER", typeof(System.DateTime));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FECHA_HASTA_NO_RETENER", typeof(System.DateTime));
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_FANTASIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RUBRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUBRO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE_COMPLETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OPERA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONDICION_HABITUAL_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_HABITUAL_PAGO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO1_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD1_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO1_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO1_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO1_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "DEPARTAMENTO2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO2_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD2_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO2_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO2_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO2_ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "PASIBLE_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "BANDERA_RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FECHA_FUNDACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONTACTO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTACTO_TELEFONO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTACTO_EMAIL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "CTACTE_BANCO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SOLICITA_REFERENCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_NACIONAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FC_OBSERVACION_DETALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_DESDE_NO_RETENER":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_HASTA_NO_RETENER":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PROVEEDORES_INFO_COMPLETACollection_Base class
}  // End of namespace
