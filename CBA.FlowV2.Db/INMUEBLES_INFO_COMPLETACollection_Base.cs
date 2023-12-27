// <fileinfo name="INMUEBLES_INFO_COMPLETACollection_Base.cs">
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
	/// The base class for <see cref="INMUEBLES_INFO_COMPLETACollection"/>. Provides methods 
	/// for common database view operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INMUEBLES_INFO_COMPLETACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INMUEBLES_INFO_COMPLETACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TEXTO_PRED_TIPO_INMUEBLE_IDColumnName = "TEXTO_PRED_TIPO_INMUEBLE_ID";
		public const string TIPO_INMUEBLE_TEXTOColumnName = "TIPO_INMUEBLE_TEXTO";
		public const string PROPIETARIO_NOMBREColumnName = "PROPIETARIO_NOMBRE";
		public const string PROPIETARIO_APELLIDOColumnName = "PROPIETARIO_APELLIDO";
		public const string PERSONA_PROPIETARIO_IDColumnName = "PERSONA_PROPIETARIO_ID";
		public const string PROVEEDOR_PROPIETARIO_IDColumnName = "PROVEEDOR_PROPIETARIO_ID";
		public const string PERSONA_NOMBREColumnName = "PERSONA_NOMBRE";
		public const string PERSONA_APELLIDOColumnName = "PERSONA_APELLIDO";
		public const string INMUEBLE_PADRE_IDColumnName = "INMUEBLE_PADRE_ID";
		public const string INMUEBLE_PADRE_NOMBREColumnName = "INMUEBLE_PADRE_NOMBRE";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string PAIS_NOMBREColumnName = "PAIS_NOMBRE";
		public const string CIUDAD_IDColumnName = "CIUDAD_ID";
		public const string CIUDAD_NOMBREColumnName = "CIUDAD_NOMBRE";
		public const string BARRIO_IDColumnName = "BARRIO_ID";
		public const string BARRIO_NOMBREColumnName = "BARRIO_NOMBRE";
		public const string DEPARTAMENTO_IDColumnName = "DEPARTAMENTO_ID";
		public const string DEPARTAMENTO_NOMBREColumnName = "DEPARTAMENTO_NOMBRE";
		public const string LOTE_NUMEROColumnName = "LOTE_NUMERO";
		public const string SUPERFICIEColumnName = "SUPERFICIE";
		public const string CUENTA_CATASTRALColumnName = "CUENTA_CATASTRAL";
		public const string FINCA_NUMEROColumnName = "FINCA_NUMERO";
		public const string PADRON_NUMEROColumnName = "PADRON_NUMERO";
		public const string LATITUDColumnName = "LATITUD";
		public const string LONGITUDColumnName = "LONGITUD";
		public const string ESCRITURADOColumnName = "ESCRITURADO";
		public const string PISOColumnName = "PISO";
		public const string TELEFONOColumnName = "TELEFONO";
		public const string NUMEROColumnName = "NUMERO";
		public const string MEDIDOR_AGUA_NUMEROColumnName = "MEDIDOR_AGUA_NUMERO";
		public const string MEDIDOR_ELECTRICIDAD_NUMEROColumnName = "MEDIDOR_ELECTRICIDAD_NUMERO";
		public const string NIS_ELECTRICIDADColumnName = "NIS_ELECTRICIDAD";
		public const string CUENTA_CATASTRAL_AGUAColumnName = "CUENTA_CATASTRAL_AGUA";
		public const string ES_ESPACIO_COMUNColumnName = "ES_ESPACIO_COMUN";
		public const string MATRICULA_NROColumnName = "MATRICULA_NRO";
		public const string TEXTO_PRED_DISPONIBILIDAD_IDColumnName = "TEXTO_PRED_DISPONIBILIDAD_ID";
		public const string DISPONIBILIDAD_TEXTOColumnName = "DISPONIBILIDAD_TEXTO";
		public const string NOMBREColumnName = "NOMBRE";
		public const string CALLEColumnName = "CALLE";
		public const string RAZON_SOCIALColumnName = "RAZON_SOCIAL";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INMUEBLES_INFO_COMPLETACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INMUEBLES_INFO_COMPLETACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INMUEBLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>An array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects.</returns>
		public virtual INMUEBLES_INFO_COMPLETARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INMUEBLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INMUEBLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INMUEBLES_INFO_COMPLETARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INMUEBLES_INFO_COMPLETARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INMUEBLES_INFO_COMPLETARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INMUEBLES_INFO_COMPLETARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects.</returns>
		public INMUEBLES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects that 
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
		/// <returns>An array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects.</returns>
		public virtual INMUEBLES_INFO_COMPLETARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INMUEBLES_INFO_COMPLETA";
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
		/// <returns>An array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects.</returns>
		protected INMUEBLES_INFO_COMPLETARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects.</returns>
		protected INMUEBLES_INFO_COMPLETARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INMUEBLES_INFO_COMPLETARow"/> objects.</returns>
		protected virtual INMUEBLES_INFO_COMPLETARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int texto_pred_tipo_inmueble_idColumnIndex = reader.GetOrdinal("TEXTO_PRED_TIPO_INMUEBLE_ID");
			int tipo_inmueble_textoColumnIndex = reader.GetOrdinal("TIPO_INMUEBLE_TEXTO");
			int propietario_nombreColumnIndex = reader.GetOrdinal("PROPIETARIO_NOMBRE");
			int propietario_apellidoColumnIndex = reader.GetOrdinal("PROPIETARIO_APELLIDO");
			int persona_propietario_idColumnIndex = reader.GetOrdinal("PERSONA_PROPIETARIO_ID");
			int proveedor_propietario_idColumnIndex = reader.GetOrdinal("PROVEEDOR_PROPIETARIO_ID");
			int persona_nombreColumnIndex = reader.GetOrdinal("PERSONA_NOMBRE");
			int persona_apellidoColumnIndex = reader.GetOrdinal("PERSONA_APELLIDO");
			int inmueble_padre_idColumnIndex = reader.GetOrdinal("INMUEBLE_PADRE_ID");
			int inmueble_padre_nombreColumnIndex = reader.GetOrdinal("INMUEBLE_PADRE_NOMBRE");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int pais_nombreColumnIndex = reader.GetOrdinal("PAIS_NOMBRE");
			int ciudad_idColumnIndex = reader.GetOrdinal("CIUDAD_ID");
			int ciudad_nombreColumnIndex = reader.GetOrdinal("CIUDAD_NOMBRE");
			int barrio_idColumnIndex = reader.GetOrdinal("BARRIO_ID");
			int barrio_nombreColumnIndex = reader.GetOrdinal("BARRIO_NOMBRE");
			int departamento_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_ID");
			int departamento_nombreColumnIndex = reader.GetOrdinal("DEPARTAMENTO_NOMBRE");
			int lote_numeroColumnIndex = reader.GetOrdinal("LOTE_NUMERO");
			int superficieColumnIndex = reader.GetOrdinal("SUPERFICIE");
			int cuenta_catastralColumnIndex = reader.GetOrdinal("CUENTA_CATASTRAL");
			int finca_numeroColumnIndex = reader.GetOrdinal("FINCA_NUMERO");
			int padron_numeroColumnIndex = reader.GetOrdinal("PADRON_NUMERO");
			int latitudColumnIndex = reader.GetOrdinal("LATITUD");
			int longitudColumnIndex = reader.GetOrdinal("LONGITUD");
			int escrituradoColumnIndex = reader.GetOrdinal("ESCRITURADO");
			int pisoColumnIndex = reader.GetOrdinal("PISO");
			int telefonoColumnIndex = reader.GetOrdinal("TELEFONO");
			int numeroColumnIndex = reader.GetOrdinal("NUMERO");
			int medidor_agua_numeroColumnIndex = reader.GetOrdinal("MEDIDOR_AGUA_NUMERO");
			int medidor_electricidad_numeroColumnIndex = reader.GetOrdinal("MEDIDOR_ELECTRICIDAD_NUMERO");
			int nis_electricidadColumnIndex = reader.GetOrdinal("NIS_ELECTRICIDAD");
			int cuenta_catastral_aguaColumnIndex = reader.GetOrdinal("CUENTA_CATASTRAL_AGUA");
			int es_espacio_comunColumnIndex = reader.GetOrdinal("ES_ESPACIO_COMUN");
			int matricula_nroColumnIndex = reader.GetOrdinal("MATRICULA_NRO");
			int texto_pred_disponibilidad_idColumnIndex = reader.GetOrdinal("TEXTO_PRED_DISPONIBILIDAD_ID");
			int disponibilidad_textoColumnIndex = reader.GetOrdinal("DISPONIBILIDAD_TEXTO");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int calleColumnIndex = reader.GetOrdinal("CALLE");
			int razon_socialColumnIndex = reader.GetOrdinal("RAZON_SOCIAL");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INMUEBLES_INFO_COMPLETARow record = new INMUEBLES_INFO_COMPLETARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TEXTO_PRED_TIPO_INMUEBLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_pred_tipo_inmueble_idColumnIndex)), 9);
					record.TIPO_INMUEBLE_TEXTO = Convert.ToString(reader.GetValue(tipo_inmueble_textoColumnIndex));
					if(!reader.IsDBNull(propietario_nombreColumnIndex))
						record.PROPIETARIO_NOMBRE = Convert.ToString(reader.GetValue(propietario_nombreColumnIndex));
					if(!reader.IsDBNull(propietario_apellidoColumnIndex))
						record.PROPIETARIO_APELLIDO = Convert.ToString(reader.GetValue(propietario_apellidoColumnIndex));
					if(!reader.IsDBNull(persona_propietario_idColumnIndex))
						record.PERSONA_PROPIETARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_propietario_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_propietario_idColumnIndex))
						record.PROVEEDOR_PROPIETARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_propietario_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_nombreColumnIndex))
						record.PERSONA_NOMBRE = Convert.ToString(reader.GetValue(persona_nombreColumnIndex));
					if(!reader.IsDBNull(persona_apellidoColumnIndex))
						record.PERSONA_APELLIDO = Convert.ToString(reader.GetValue(persona_apellidoColumnIndex));
					if(!reader.IsDBNull(inmueble_padre_idColumnIndex))
						record.INMUEBLE_PADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(inmueble_padre_idColumnIndex)), 9);
					if(!reader.IsDBNull(inmueble_padre_nombreColumnIndex))
						record.INMUEBLE_PADRE_NOMBRE = Convert.ToString(reader.GetValue(inmueble_padre_nombreColumnIndex));
					if(!reader.IsDBNull(pais_idColumnIndex))
						record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(pais_nombreColumnIndex))
						record.PAIS_NOMBRE = Convert.ToString(reader.GetValue(pais_nombreColumnIndex));
					if(!reader.IsDBNull(ciudad_idColumnIndex))
						record.CIUDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_nombreColumnIndex))
						record.CIUDAD_NOMBRE = Convert.ToString(reader.GetValue(ciudad_nombreColumnIndex));
					if(!reader.IsDBNull(barrio_idColumnIndex))
						record.BARRIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_nombreColumnIndex))
						record.BARRIO_NOMBRE = Convert.ToString(reader.GetValue(barrio_nombreColumnIndex));
					if(!reader.IsDBNull(departamento_idColumnIndex))
						record.DEPARTAMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_nombreColumnIndex))
						record.DEPARTAMENTO_NOMBRE = Convert.ToString(reader.GetValue(departamento_nombreColumnIndex));
					if(!reader.IsDBNull(lote_numeroColumnIndex))
						record.LOTE_NUMERO = Convert.ToString(reader.GetValue(lote_numeroColumnIndex));
					if(!reader.IsDBNull(superficieColumnIndex))
						record.SUPERFICIE = Math.Round(Convert.ToDecimal(reader.GetValue(superficieColumnIndex)), 9);
					if(!reader.IsDBNull(cuenta_catastralColumnIndex))
						record.CUENTA_CATASTRAL = Convert.ToString(reader.GetValue(cuenta_catastralColumnIndex));
					if(!reader.IsDBNull(finca_numeroColumnIndex))
						record.FINCA_NUMERO = Convert.ToString(reader.GetValue(finca_numeroColumnIndex));
					if(!reader.IsDBNull(padron_numeroColumnIndex))
						record.PADRON_NUMERO = Convert.ToString(reader.GetValue(padron_numeroColumnIndex));
					if(!reader.IsDBNull(latitudColumnIndex))
						record.LATITUD = Math.Round(Convert.ToDecimal(reader.GetValue(latitudColumnIndex)), 9);
					if(!reader.IsDBNull(longitudColumnIndex))
						record.LONGITUD = Math.Round(Convert.ToDecimal(reader.GetValue(longitudColumnIndex)), 9);
					if(!reader.IsDBNull(escrituradoColumnIndex))
						record.ESCRITURADO = Convert.ToString(reader.GetValue(escrituradoColumnIndex));
					if(!reader.IsDBNull(pisoColumnIndex))
						record.PISO = Convert.ToString(reader.GetValue(pisoColumnIndex));
					if(!reader.IsDBNull(telefonoColumnIndex))
						record.TELEFONO = Convert.ToString(reader.GetValue(telefonoColumnIndex));
					if(!reader.IsDBNull(numeroColumnIndex))
						record.NUMERO = Convert.ToString(reader.GetValue(numeroColumnIndex));
					if(!reader.IsDBNull(medidor_agua_numeroColumnIndex))
						record.MEDIDOR_AGUA_NUMERO = Convert.ToString(reader.GetValue(medidor_agua_numeroColumnIndex));
					if(!reader.IsDBNull(medidor_electricidad_numeroColumnIndex))
						record.MEDIDOR_ELECTRICIDAD_NUMERO = Convert.ToString(reader.GetValue(medidor_electricidad_numeroColumnIndex));
					if(!reader.IsDBNull(nis_electricidadColumnIndex))
						record.NIS_ELECTRICIDAD = Convert.ToString(reader.GetValue(nis_electricidadColumnIndex));
					if(!reader.IsDBNull(cuenta_catastral_aguaColumnIndex))
						record.CUENTA_CATASTRAL_AGUA = Convert.ToString(reader.GetValue(cuenta_catastral_aguaColumnIndex));
					if(!reader.IsDBNull(es_espacio_comunColumnIndex))
						record.ES_ESPACIO_COMUN = Convert.ToString(reader.GetValue(es_espacio_comunColumnIndex));
					if(!reader.IsDBNull(matricula_nroColumnIndex))
						record.MATRICULA_NRO = Convert.ToString(reader.GetValue(matricula_nroColumnIndex));
					record.TEXTO_PRED_DISPONIBILIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_pred_disponibilidad_idColumnIndex)), 9);
					if(!reader.IsDBNull(disponibilidad_textoColumnIndex))
						record.DISPONIBILIDAD_TEXTO = Convert.ToString(reader.GetValue(disponibilidad_textoColumnIndex));
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(calleColumnIndex))
						record.CALLE = Convert.ToString(reader.GetValue(calleColumnIndex));
					if(!reader.IsDBNull(razon_socialColumnIndex))
						record.RAZON_SOCIAL = Convert.ToString(reader.GetValue(razon_socialColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INMUEBLES_INFO_COMPLETARow[])(recordList.ToArray(typeof(INMUEBLES_INFO_COMPLETARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INMUEBLES_INFO_COMPLETARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INMUEBLES_INFO_COMPLETARow"/> object.</returns>
		protected virtual INMUEBLES_INFO_COMPLETARow MapRow(DataRow row)
		{
			INMUEBLES_INFO_COMPLETARow mappedObject = new INMUEBLES_INFO_COMPLETARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TEXTO_PRED_TIPO_INMUEBLE_ID"
			dataColumn = dataTable.Columns["TEXTO_PRED_TIPO_INMUEBLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PRED_TIPO_INMUEBLE_ID = (decimal)row[dataColumn];
			// Column "TIPO_INMUEBLE_TEXTO"
			dataColumn = dataTable.Columns["TIPO_INMUEBLE_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_INMUEBLE_TEXTO = (string)row[dataColumn];
			// Column "PROPIETARIO_NOMBRE"
			dataColumn = dataTable.Columns["PROPIETARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROPIETARIO_NOMBRE = (string)row[dataColumn];
			// Column "PROPIETARIO_APELLIDO"
			dataColumn = dataTable.Columns["PROPIETARIO_APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROPIETARIO_APELLIDO = (string)row[dataColumn];
			// Column "PERSONA_PROPIETARIO_ID"
			dataColumn = dataTable.Columns["PERSONA_PROPIETARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_PROPIETARIO_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_PROPIETARIO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_PROPIETARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_PROPIETARIO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_NOMBRE"
			dataColumn = dataTable.Columns["PERSONA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_NOMBRE = (string)row[dataColumn];
			// Column "PERSONA_APELLIDO"
			dataColumn = dataTable.Columns["PERSONA_APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_APELLIDO = (string)row[dataColumn];
			// Column "INMUEBLE_PADRE_ID"
			dataColumn = dataTable.Columns["INMUEBLE_PADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INMUEBLE_PADRE_ID = (decimal)row[dataColumn];
			// Column "INMUEBLE_PADRE_NOMBRE"
			dataColumn = dataTable.Columns["INMUEBLE_PADRE_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INMUEBLE_PADRE_NOMBRE = (string)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "PAIS_NOMBRE"
			dataColumn = dataTable.Columns["PAIS_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_NOMBRE = (string)row[dataColumn];
			// Column "CIUDAD_ID"
			dataColumn = dataTable.Columns["CIUDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_NOMBRE"
			dataColumn = dataTable.Columns["CIUDAD_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_NOMBRE = (string)row[dataColumn];
			// Column "BARRIO_ID"
			dataColumn = dataTable.Columns["BARRIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_ID = (decimal)row[dataColumn];
			// Column "BARRIO_NOMBRE"
			dataColumn = dataTable.Columns["BARRIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_NOMBRE = (string)row[dataColumn];
			// Column "DEPARTAMENTO_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO_NOMBRE"
			dataColumn = dataTable.Columns["DEPARTAMENTO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_NOMBRE = (string)row[dataColumn];
			// Column "LOTE_NUMERO"
			dataColumn = dataTable.Columns["LOTE_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_NUMERO = (string)row[dataColumn];
			// Column "SUPERFICIE"
			dataColumn = dataTable.Columns["SUPERFICIE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUPERFICIE = (decimal)row[dataColumn];
			// Column "CUENTA_CATASTRAL"
			dataColumn = dataTable.Columns["CUENTA_CATASTRAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_CATASTRAL = (string)row[dataColumn];
			// Column "FINCA_NUMERO"
			dataColumn = dataTable.Columns["FINCA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FINCA_NUMERO = (string)row[dataColumn];
			// Column "PADRON_NUMERO"
			dataColumn = dataTable.Columns["PADRON_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PADRON_NUMERO = (string)row[dataColumn];
			// Column "LATITUD"
			dataColumn = dataTable.Columns["LATITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.LATITUD = (decimal)row[dataColumn];
			// Column "LONGITUD"
			dataColumn = dataTable.Columns["LONGITUD"];
			if(!row.IsNull(dataColumn))
				mappedObject.LONGITUD = (decimal)row[dataColumn];
			// Column "ESCRITURADO"
			dataColumn = dataTable.Columns["ESCRITURADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESCRITURADO = (string)row[dataColumn];
			// Column "PISO"
			dataColumn = dataTable.Columns["PISO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PISO = (string)row[dataColumn];
			// Column "TELEFONO"
			dataColumn = dataTable.Columns["TELEFONO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO = (string)row[dataColumn];
			// Column "NUMERO"
			dataColumn = dataTable.Columns["NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO = (string)row[dataColumn];
			// Column "MEDIDOR_AGUA_NUMERO"
			dataColumn = dataTable.Columns["MEDIDOR_AGUA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MEDIDOR_AGUA_NUMERO = (string)row[dataColumn];
			// Column "MEDIDOR_ELECTRICIDAD_NUMERO"
			dataColumn = dataTable.Columns["MEDIDOR_ELECTRICIDAD_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MEDIDOR_ELECTRICIDAD_NUMERO = (string)row[dataColumn];
			// Column "NIS_ELECTRICIDAD"
			dataColumn = dataTable.Columns["NIS_ELECTRICIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.NIS_ELECTRICIDAD = (string)row[dataColumn];
			// Column "CUENTA_CATASTRAL_AGUA"
			dataColumn = dataTable.Columns["CUENTA_CATASTRAL_AGUA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_CATASTRAL_AGUA = (string)row[dataColumn];
			// Column "ES_ESPACIO_COMUN"
			dataColumn = dataTable.Columns["ES_ESPACIO_COMUN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_ESPACIO_COMUN = (string)row[dataColumn];
			// Column "MATRICULA_NRO"
			dataColumn = dataTable.Columns["MATRICULA_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MATRICULA_NRO = (string)row[dataColumn];
			// Column "TEXTO_PRED_DISPONIBILIDAD_ID"
			dataColumn = dataTable.Columns["TEXTO_PRED_DISPONIBILIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PRED_DISPONIBILIDAD_ID = (decimal)row[dataColumn];
			// Column "DISPONIBILIDAD_TEXTO"
			dataColumn = dataTable.Columns["DISPONIBILIDAD_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DISPONIBILIDAD_TEXTO = (string)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "CALLE"
			dataColumn = dataTable.Columns["CALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE = (string)row[dataColumn];
			// Column "RAZON_SOCIAL"
			dataColumn = dataTable.Columns["RAZON_SOCIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_SOCIAL = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INMUEBLES_INFO_COMPLETA</c> view.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INMUEBLES_INFO_COMPLETA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PRED_TIPO_INMUEBLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TIPO_INMUEBLE_TEXTO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROPIETARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROPIETARIO_APELLIDO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_PROPIETARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_PROPIETARIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PERSONA_APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INMUEBLE_PADRE_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("INMUEBLE_PADRE_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PAIS_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CIUDAD_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("BARRIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_ID", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LOTE_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("SUPERFICIE", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_CATASTRAL", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("FINCA_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PADRON_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LATITUD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("LONGITUD", typeof(decimal));
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ESCRITURADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("PISO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TELEFONO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MEDIDOR_AGUA_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MEDIDOR_ELECTRICIDAD_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NIS_ELECTRICIDAD", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CUENTA_CATASTRAL_AGUA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("ES_ESPACIO_COMUN", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("MATRICULA_NRO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("TEXTO_PRED_DISPONIBILIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("DISPONIBILIDAD_TEXTO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("CALLE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn.ReadOnly = true;
			dataColumn = dataTable.Columns.Add("RAZON_SOCIAL", typeof(string));
			dataColumn.MaxLength = 150;
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

				case "TEXTO_PRED_TIPO_INMUEBLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_INMUEBLE_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROPIETARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROPIETARIO_APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_PROPIETARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_PROPIETARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "INMUEBLE_PADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INMUEBLE_PADRE_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CIUDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BARRIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DEPARTAMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOTE_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUPERFICIE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUENTA_CATASTRAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FINCA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PADRON_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LATITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LONGITUD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESCRITURADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PISO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MEDIDOR_AGUA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MEDIDOR_ELECTRICIDAD_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NIS_ELECTRICIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CUENTA_CATASTRAL_AGUA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ES_ESPACIO_COMUN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "MATRICULA_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PRED_DISPONIBILIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DISPONIBILIDAD_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RAZON_SOCIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INMUEBLES_INFO_COMPLETACollection_Base class
}  // End of namespace
