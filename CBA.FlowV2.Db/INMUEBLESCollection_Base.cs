// <fileinfo name="INMUEBLESCollection_Base.cs">
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
	/// The base class for <see cref="INMUEBLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="INMUEBLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class INMUEBLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TEXTO_PRED_TIPO_INMUEBLE_IDColumnName = "TEXTO_PRED_TIPO_INMUEBLE_ID";
		public const string PROPIETARIO_NOMBREColumnName = "PROPIETARIO_NOMBRE";
		public const string PROPIETARIO_APELLIDOColumnName = "PROPIETARIO_APELLIDO";
		public const string PERSONA_PROPIETARIO_IDColumnName = "PERSONA_PROPIETARIO_ID";
		public const string INMUEBLE_PADRE_IDColumnName = "INMUEBLE_PADRE_ID";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string CIUDAD_IDColumnName = "CIUDAD_ID";
		public const string BARRIO_IDColumnName = "BARRIO_ID";
		public const string DEPARTAMENTO_IDColumnName = "DEPARTAMENTO_ID";
		public const string LOTE_NUMEROColumnName = "LOTE_NUMERO";
		public const string SUPERFICIEColumnName = "SUPERFICIE";
		public const string FINCA_NUMEROColumnName = "FINCA_NUMERO";
		public const string CUENTA_CATASTRALColumnName = "CUENTA_CATASTRAL";
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
		public const string NOMBREColumnName = "NOMBRE";
		public const string CALLEColumnName = "CALLE";
		public const string PROVEEDOR_PROPIETARIO_IDColumnName = "PROVEEDOR_PROPIETARIO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="INMUEBLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public INMUEBLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>INMUEBLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>INMUEBLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>INMUEBLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="INMUEBLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="INMUEBLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public INMUEBLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			INMUEBLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects that 
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
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.INMUEBLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="INMUEBLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="INMUEBLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual INMUEBLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			INMUEBLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetByBARRIO_ID(decimal barrio_id)
		{
			return GetByBARRIO_ID(barrio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <param name="barrio_idNull">true if the method ignores the barrio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByBARRIO_ID(decimal barrio_id, bool barrio_idNull)
		{
			return MapRecords(CreateGetByBARRIO_IDCommand(barrio_id, barrio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO_IDAsDataTable(decimal barrio_id)
		{
			return GetByBARRIO_IDAsDataTable(barrio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <param name="barrio_idNull">true if the method ignores the barrio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByBARRIO_IDAsDataTable(decimal barrio_id, bool barrio_idNull)
		{
			return MapRecordsToDataTable(CreateGetByBARRIO_IDCommand(barrio_id, barrio_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <param name="barrio_idNull">true if the method ignores the barrio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByBARRIO_IDCommand(decimal barrio_id, bool barrio_idNull)
		{
			string whereSql = "";
			if(barrio_idNull)
				whereSql += "BARRIO_ID IS NULL";
			else
				whereSql += "BARRIO_ID=" + _db.CreateSqlParameterName("BARRIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!barrio_idNull)
				AddParameter(cmd, "BARRIO_ID", barrio_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetByCIUDAD_ID(decimal ciudad_id)
		{
			return GetByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByCIUDAD_ID(decimal ciudad_id, bool ciudad_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_IDCommand(ciudad_id, ciudad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_IDAsDataTable(decimal ciudad_id)
		{
			return GetByCIUDAD_IDAsDataTable(ciudad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCIUDAD_IDAsDataTable(decimal ciudad_id, bool ciudad_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCIUDAD_IDCommand(ciudad_id, ciudad_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCIUDAD_IDCommand(decimal ciudad_id, bool ciudad_idNull)
		{
			string whereSql = "";
			if(ciudad_idNull)
				whereSql += "CIUDAD_ID IS NULL";
			else
				whereSql += "CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ciudad_idNull)
				AddParameter(cmd, "CIUDAD_ID", ciudad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByDEPARTAMENTO_ID(decimal departamento_id, bool departamento_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_IDAsDataTable(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_IDAsDataTable(departamento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPARTAMENTO_IDAsDataTable(decimal departamento_id, bool departamento_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPARTAMENTO_IDCommand(decimal departamento_id, bool departamento_idNull)
		{
			string whereSql = "";
			if(departamento_idNull)
				whereSql += "DEPARTAMENTO_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!departamento_idNull)
				AddParameter(cmd, "DEPARTAMENTO_ID", departamento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_DISP_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_disponibilidad_id">The <c>TEXTO_PRED_DISPONIBILIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByTEXTO_PRED_DISPONIBILIDAD_ID(decimal texto_pred_disponibilidad_id)
		{
			return MapRecords(CreateGetByTEXTO_PRED_DISPONIBILIDAD_IDCommand(texto_pred_disponibilidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_DISP_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_disponibilidad_id">The <c>TEXTO_PRED_DISPONIBILIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PRED_DISPONIBILIDAD_IDAsDataTable(decimal texto_pred_disponibilidad_id)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PRED_DISPONIBILIDAD_IDCommand(texto_pred_disponibilidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_DISP_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_disponibilidad_id">The <c>TEXTO_PRED_DISPONIBILIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PRED_DISPONIBILIDAD_IDCommand(decimal texto_pred_disponibilidad_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PRED_DISPONIBILIDAD_ID=" + _db.CreateSqlParameterName("TEXTO_PRED_DISPONIBILIDAD_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TEXTO_PRED_DISPONIBILIDAD_ID", texto_pred_disponibilidad_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetByINMUEBLE_PADRE_ID(decimal inmueble_padre_id)
		{
			return GetByINMUEBLE_PADRE_ID(inmueble_padre_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <param name="inmueble_padre_idNull">true if the method ignores the inmueble_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByINMUEBLE_PADRE_ID(decimal inmueble_padre_id, bool inmueble_padre_idNull)
		{
			return MapRecords(CreateGetByINMUEBLE_PADRE_IDCommand(inmueble_padre_id, inmueble_padre_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByINMUEBLE_PADRE_IDAsDataTable(decimal inmueble_padre_id)
		{
			return GetByINMUEBLE_PADRE_IDAsDataTable(inmueble_padre_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <param name="inmueble_padre_idNull">true if the method ignores the inmueble_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByINMUEBLE_PADRE_IDAsDataTable(decimal inmueble_padre_id, bool inmueble_padre_idNull)
		{
			return MapRecordsToDataTable(CreateGetByINMUEBLE_PADRE_IDCommand(inmueble_padre_id, inmueble_padre_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <param name="inmueble_padre_idNull">true if the method ignores the inmueble_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByINMUEBLE_PADRE_IDCommand(decimal inmueble_padre_id, bool inmueble_padre_idNull)
		{
			string whereSql = "";
			if(inmueble_padre_idNull)
				whereSql += "INMUEBLE_PADRE_ID IS NULL";
			else
				whereSql += "INMUEBLE_PADRE_ID=" + _db.CreateSqlParameterName("INMUEBLE_PADRE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!inmueble_padre_idNull)
				AddParameter(cmd, "INMUEBLE_PADRE_ID", inmueble_padre_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetByPAIS_ID(decimal pais_id)
		{
			return GetByPAIS_ID(pais_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <param name="pais_idNull">true if the method ignores the pais_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByPAIS_ID(decimal pais_id, bool pais_idNull)
		{
			return MapRecords(CreateGetByPAIS_IDCommand(pais_id, pais_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPAIS_IDAsDataTable(decimal pais_id)
		{
			return GetByPAIS_IDAsDataTable(pais_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <param name="pais_idNull">true if the method ignores the pais_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_IDAsDataTable(decimal pais_id, bool pais_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_IDCommand(pais_id, pais_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <param name="pais_idNull">true if the method ignores the pais_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_IDCommand(decimal pais_id, bool pais_idNull)
		{
			string whereSql = "";
			if(pais_idNull)
				whereSql += "PAIS_ID IS NULL";
			else
				whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!pais_idNull)
				AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetByPERSONA_PROPIETARIO_ID(decimal persona_propietario_id)
		{
			return GetByPERSONA_PROPIETARIO_ID(persona_propietario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <param name="persona_propietario_idNull">true if the method ignores the persona_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByPERSONA_PROPIETARIO_ID(decimal persona_propietario_id, bool persona_propietario_idNull)
		{
			return MapRecords(CreateGetByPERSONA_PROPIETARIO_IDCommand(persona_propietario_id, persona_propietario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_PROPIETARIO_IDAsDataTable(decimal persona_propietario_id)
		{
			return GetByPERSONA_PROPIETARIO_IDAsDataTable(persona_propietario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <param name="persona_propietario_idNull">true if the method ignores the persona_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_PROPIETARIO_IDAsDataTable(decimal persona_propietario_id, bool persona_propietario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_PROPIETARIO_IDCommand(persona_propietario_id, persona_propietario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <param name="persona_propietario_idNull">true if the method ignores the persona_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_PROPIETARIO_IDCommand(decimal persona_propietario_id, bool persona_propietario_idNull)
		{
			string whereSql = "";
			if(persona_propietario_idNull)
				whereSql += "PERSONA_PROPIETARIO_ID IS NULL";
			else
				whereSql += "PERSONA_PROPIETARIO_ID=" + _db.CreateSqlParameterName("PERSONA_PROPIETARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_propietario_idNull)
				AddParameter(cmd, "PERSONA_PROPIETARIO_ID", persona_propietario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public INMUEBLESRow[] GetByPROVEEDOR_PROPIETARIO_ID(decimal proveedor_propietario_id)
		{
			return GetByPROVEEDOR_PROPIETARIO_ID(proveedor_propietario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <param name="proveedor_propietario_idNull">true if the method ignores the proveedor_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByPROVEEDOR_PROPIETARIO_ID(decimal proveedor_propietario_id, bool proveedor_propietario_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_PROPIETARIO_IDCommand(proveedor_propietario_id, proveedor_propietario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_PROPIETARIO_IDAsDataTable(decimal proveedor_propietario_id)
		{
			return GetByPROVEEDOR_PROPIETARIO_IDAsDataTable(proveedor_propietario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <param name="proveedor_propietario_idNull">true if the method ignores the proveedor_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_PROPIETARIO_IDAsDataTable(decimal proveedor_propietario_id, bool proveedor_propietario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_PROPIETARIO_IDCommand(proveedor_propietario_id, proveedor_propietario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <param name="proveedor_propietario_idNull">true if the method ignores the proveedor_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_PROPIETARIO_IDCommand(decimal proveedor_propietario_id, bool proveedor_propietario_idNull)
		{
			string whereSql = "";
			if(proveedor_propietario_idNull)
				whereSql += "PROVEEDOR_PROPIETARIO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_PROPIETARIO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_PROPIETARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_propietario_idNull)
				AddParameter(cmd, "PROVEEDOR_PROPIETARIO_ID", proveedor_propietario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="INMUEBLESRow"/> objects 
		/// by the <c>FK_INMUEBLES_TIPO_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_tipo_inmueble_id">The <c>TEXTO_PRED_TIPO_INMUEBLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		public virtual INMUEBLESRow[] GetByTEXTO_PRED_TIPO_INMUEBLE_ID(decimal texto_pred_tipo_inmueble_id)
		{
			return MapRecords(CreateGetByTEXTO_PRED_TIPO_INMUEBLE_IDCommand(texto_pred_tipo_inmueble_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_INMUEBLES_TIPO_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_tipo_inmueble_id">The <c>TEXTO_PRED_TIPO_INMUEBLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PRED_TIPO_INMUEBLE_IDAsDataTable(decimal texto_pred_tipo_inmueble_id)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PRED_TIPO_INMUEBLE_IDCommand(texto_pred_tipo_inmueble_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_INMUEBLES_TIPO_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_tipo_inmueble_id">The <c>TEXTO_PRED_TIPO_INMUEBLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PRED_TIPO_INMUEBLE_IDCommand(decimal texto_pred_tipo_inmueble_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PRED_TIPO_INMUEBLE_ID=" + _db.CreateSqlParameterName("TEXTO_PRED_TIPO_INMUEBLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TEXTO_PRED_TIPO_INMUEBLE_ID", texto_pred_tipo_inmueble_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>INMUEBLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INMUEBLESRow"/> object to be inserted.</param>
		public virtual void Insert(INMUEBLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.INMUEBLES (" +
				"ID, " +
				"TEXTO_PRED_TIPO_INMUEBLE_ID, " +
				"PROPIETARIO_NOMBRE, " +
				"PROPIETARIO_APELLIDO, " +
				"PERSONA_PROPIETARIO_ID, " +
				"INMUEBLE_PADRE_ID, " +
				"PAIS_ID, " +
				"CIUDAD_ID, " +
				"BARRIO_ID, " +
				"DEPARTAMENTO_ID, " +
				"LOTE_NUMERO, " +
				"SUPERFICIE, " +
				"FINCA_NUMERO, " +
				"CUENTA_CATASTRAL, " +
				"PADRON_NUMERO, " +
				"LATITUD, " +
				"LONGITUD, " +
				"ESCRITURADO, " +
				"PISO, " +
				"TELEFONO, " +
				"NUMERO, " +
				"MEDIDOR_AGUA_NUMERO, " +
				"MEDIDOR_ELECTRICIDAD_NUMERO, " +
				"NIS_ELECTRICIDAD, " +
				"CUENTA_CATASTRAL_AGUA, " +
				"ES_ESPACIO_COMUN, " +
				"MATRICULA_NRO, " +
				"TEXTO_PRED_DISPONIBILIDAD_ID, " +
				"NOMBRE, " +
				"CALLE, " +
				"PROVEEDOR_PROPIETARIO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PRED_TIPO_INMUEBLE_ID") + ", " +
				_db.CreateSqlParameterName("PROPIETARIO_NOMBRE") + ", " +
				_db.CreateSqlParameterName("PROPIETARIO_APELLIDO") + ", " +
				_db.CreateSqlParameterName("PERSONA_PROPIETARIO_ID") + ", " +
				_db.CreateSqlParameterName("INMUEBLE_PADRE_ID") + ", " +
				_db.CreateSqlParameterName("PAIS_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_NUMERO") + ", " +
				_db.CreateSqlParameterName("SUPERFICIE") + ", " +
				_db.CreateSqlParameterName("FINCA_NUMERO") + ", " +
				_db.CreateSqlParameterName("CUENTA_CATASTRAL") + ", " +
				_db.CreateSqlParameterName("PADRON_NUMERO") + ", " +
				_db.CreateSqlParameterName("LATITUD") + ", " +
				_db.CreateSqlParameterName("LONGITUD") + ", " +
				_db.CreateSqlParameterName("ESCRITURADO") + ", " +
				_db.CreateSqlParameterName("PISO") + ", " +
				_db.CreateSqlParameterName("TELEFONO") + ", " +
				_db.CreateSqlParameterName("NUMERO") + ", " +
				_db.CreateSqlParameterName("MEDIDOR_AGUA_NUMERO") + ", " +
				_db.CreateSqlParameterName("MEDIDOR_ELECTRICIDAD_NUMERO") + ", " +
				_db.CreateSqlParameterName("NIS_ELECTRICIDAD") + ", " +
				_db.CreateSqlParameterName("CUENTA_CATASTRAL_AGUA") + ", " +
				_db.CreateSqlParameterName("ES_ESPACIO_COMUN") + ", " +
				_db.CreateSqlParameterName("MATRICULA_NRO") + ", " +
				_db.CreateSqlParameterName("TEXTO_PRED_DISPONIBILIDAD_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("CALLE") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_PROPIETARIO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TEXTO_PRED_TIPO_INMUEBLE_ID", value.TEXTO_PRED_TIPO_INMUEBLE_ID);
			AddParameter(cmd, "PROPIETARIO_NOMBRE", value.PROPIETARIO_NOMBRE);
			AddParameter(cmd, "PROPIETARIO_APELLIDO", value.PROPIETARIO_APELLIDO);
			AddParameter(cmd, "PERSONA_PROPIETARIO_ID",
				value.IsPERSONA_PROPIETARIO_IDNull ? DBNull.Value : (object)value.PERSONA_PROPIETARIO_ID);
			AddParameter(cmd, "INMUEBLE_PADRE_ID",
				value.IsINMUEBLE_PADRE_IDNull ? DBNull.Value : (object)value.INMUEBLE_PADRE_ID);
			AddParameter(cmd, "PAIS_ID",
				value.IsPAIS_IDNull ? DBNull.Value : (object)value.PAIS_ID);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "BARRIO_ID",
				value.IsBARRIO_IDNull ? DBNull.Value : (object)value.BARRIO_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "LOTE_NUMERO", value.LOTE_NUMERO);
			AddParameter(cmd, "SUPERFICIE",
				value.IsSUPERFICIENull ? DBNull.Value : (object)value.SUPERFICIE);
			AddParameter(cmd, "FINCA_NUMERO", value.FINCA_NUMERO);
			AddParameter(cmd, "CUENTA_CATASTRAL", value.CUENTA_CATASTRAL);
			AddParameter(cmd, "PADRON_NUMERO", value.PADRON_NUMERO);
			AddParameter(cmd, "LATITUD",
				value.IsLATITUDNull ? DBNull.Value : (object)value.LATITUD);
			AddParameter(cmd, "LONGITUD",
				value.IsLONGITUDNull ? DBNull.Value : (object)value.LONGITUD);
			AddParameter(cmd, "ESCRITURADO", value.ESCRITURADO);
			AddParameter(cmd, "PISO", value.PISO);
			AddParameter(cmd, "TELEFONO", value.TELEFONO);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "MEDIDOR_AGUA_NUMERO", value.MEDIDOR_AGUA_NUMERO);
			AddParameter(cmd, "MEDIDOR_ELECTRICIDAD_NUMERO", value.MEDIDOR_ELECTRICIDAD_NUMERO);
			AddParameter(cmd, "NIS_ELECTRICIDAD", value.NIS_ELECTRICIDAD);
			AddParameter(cmd, "CUENTA_CATASTRAL_AGUA", value.CUENTA_CATASTRAL_AGUA);
			AddParameter(cmd, "ES_ESPACIO_COMUN", value.ES_ESPACIO_COMUN);
			AddParameter(cmd, "MATRICULA_NRO", value.MATRICULA_NRO);
			AddParameter(cmd, "TEXTO_PRED_DISPONIBILIDAD_ID", value.TEXTO_PRED_DISPONIBILIDAD_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "CALLE", value.CALLE);
			AddParameter(cmd, "PROVEEDOR_PROPIETARIO_ID",
				value.IsPROVEEDOR_PROPIETARIO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_PROPIETARIO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>INMUEBLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INMUEBLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(INMUEBLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.INMUEBLES SET " +
				"TEXTO_PRED_TIPO_INMUEBLE_ID=" + _db.CreateSqlParameterName("TEXTO_PRED_TIPO_INMUEBLE_ID") + ", " +
				"PROPIETARIO_NOMBRE=" + _db.CreateSqlParameterName("PROPIETARIO_NOMBRE") + ", " +
				"PROPIETARIO_APELLIDO=" + _db.CreateSqlParameterName("PROPIETARIO_APELLIDO") + ", " +
				"PERSONA_PROPIETARIO_ID=" + _db.CreateSqlParameterName("PERSONA_PROPIETARIO_ID") + ", " +
				"INMUEBLE_PADRE_ID=" + _db.CreateSqlParameterName("INMUEBLE_PADRE_ID") + ", " +
				"PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID") + ", " +
				"CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				"BARRIO_ID=" + _db.CreateSqlParameterName("BARRIO_ID") + ", " +
				"DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				"LOTE_NUMERO=" + _db.CreateSqlParameterName("LOTE_NUMERO") + ", " +
				"SUPERFICIE=" + _db.CreateSqlParameterName("SUPERFICIE") + ", " +
				"FINCA_NUMERO=" + _db.CreateSqlParameterName("FINCA_NUMERO") + ", " +
				"CUENTA_CATASTRAL=" + _db.CreateSqlParameterName("CUENTA_CATASTRAL") + ", " +
				"PADRON_NUMERO=" + _db.CreateSqlParameterName("PADRON_NUMERO") + ", " +
				"LATITUD=" + _db.CreateSqlParameterName("LATITUD") + ", " +
				"LONGITUD=" + _db.CreateSqlParameterName("LONGITUD") + ", " +
				"ESCRITURADO=" + _db.CreateSqlParameterName("ESCRITURADO") + ", " +
				"PISO=" + _db.CreateSqlParameterName("PISO") + ", " +
				"TELEFONO=" + _db.CreateSqlParameterName("TELEFONO") + ", " +
				"NUMERO=" + _db.CreateSqlParameterName("NUMERO") + ", " +
				"MEDIDOR_AGUA_NUMERO=" + _db.CreateSqlParameterName("MEDIDOR_AGUA_NUMERO") + ", " +
				"MEDIDOR_ELECTRICIDAD_NUMERO=" + _db.CreateSqlParameterName("MEDIDOR_ELECTRICIDAD_NUMERO") + ", " +
				"NIS_ELECTRICIDAD=" + _db.CreateSqlParameterName("NIS_ELECTRICIDAD") + ", " +
				"CUENTA_CATASTRAL_AGUA=" + _db.CreateSqlParameterName("CUENTA_CATASTRAL_AGUA") + ", " +
				"ES_ESPACIO_COMUN=" + _db.CreateSqlParameterName("ES_ESPACIO_COMUN") + ", " +
				"MATRICULA_NRO=" + _db.CreateSqlParameterName("MATRICULA_NRO") + ", " +
				"TEXTO_PRED_DISPONIBILIDAD_ID=" + _db.CreateSqlParameterName("TEXTO_PRED_DISPONIBILIDAD_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"CALLE=" + _db.CreateSqlParameterName("CALLE") + ", " +
				"PROVEEDOR_PROPIETARIO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_PROPIETARIO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TEXTO_PRED_TIPO_INMUEBLE_ID", value.TEXTO_PRED_TIPO_INMUEBLE_ID);
			AddParameter(cmd, "PROPIETARIO_NOMBRE", value.PROPIETARIO_NOMBRE);
			AddParameter(cmd, "PROPIETARIO_APELLIDO", value.PROPIETARIO_APELLIDO);
			AddParameter(cmd, "PERSONA_PROPIETARIO_ID",
				value.IsPERSONA_PROPIETARIO_IDNull ? DBNull.Value : (object)value.PERSONA_PROPIETARIO_ID);
			AddParameter(cmd, "INMUEBLE_PADRE_ID",
				value.IsINMUEBLE_PADRE_IDNull ? DBNull.Value : (object)value.INMUEBLE_PADRE_ID);
			AddParameter(cmd, "PAIS_ID",
				value.IsPAIS_IDNull ? DBNull.Value : (object)value.PAIS_ID);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "BARRIO_ID",
				value.IsBARRIO_IDNull ? DBNull.Value : (object)value.BARRIO_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "LOTE_NUMERO", value.LOTE_NUMERO);
			AddParameter(cmd, "SUPERFICIE",
				value.IsSUPERFICIENull ? DBNull.Value : (object)value.SUPERFICIE);
			AddParameter(cmd, "FINCA_NUMERO", value.FINCA_NUMERO);
			AddParameter(cmd, "CUENTA_CATASTRAL", value.CUENTA_CATASTRAL);
			AddParameter(cmd, "PADRON_NUMERO", value.PADRON_NUMERO);
			AddParameter(cmd, "LATITUD",
				value.IsLATITUDNull ? DBNull.Value : (object)value.LATITUD);
			AddParameter(cmd, "LONGITUD",
				value.IsLONGITUDNull ? DBNull.Value : (object)value.LONGITUD);
			AddParameter(cmd, "ESCRITURADO", value.ESCRITURADO);
			AddParameter(cmd, "PISO", value.PISO);
			AddParameter(cmd, "TELEFONO", value.TELEFONO);
			AddParameter(cmd, "NUMERO", value.NUMERO);
			AddParameter(cmd, "MEDIDOR_AGUA_NUMERO", value.MEDIDOR_AGUA_NUMERO);
			AddParameter(cmd, "MEDIDOR_ELECTRICIDAD_NUMERO", value.MEDIDOR_ELECTRICIDAD_NUMERO);
			AddParameter(cmd, "NIS_ELECTRICIDAD", value.NIS_ELECTRICIDAD);
			AddParameter(cmd, "CUENTA_CATASTRAL_AGUA", value.CUENTA_CATASTRAL_AGUA);
			AddParameter(cmd, "ES_ESPACIO_COMUN", value.ES_ESPACIO_COMUN);
			AddParameter(cmd, "MATRICULA_NRO", value.MATRICULA_NRO);
			AddParameter(cmd, "TEXTO_PRED_DISPONIBILIDAD_ID", value.TEXTO_PRED_DISPONIBILIDAD_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "CALLE", value.CALLE);
			AddParameter(cmd, "PROVEEDOR_PROPIETARIO_ID",
				value.IsPROVEEDOR_PROPIETARIO_IDNull ? DBNull.Value : (object)value.PROVEEDOR_PROPIETARIO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>INMUEBLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>INMUEBLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>INMUEBLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="INMUEBLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(INMUEBLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>INMUEBLES</c> table using
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
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_ID(decimal barrio_id)
		{
			return DeleteByBARRIO_ID(barrio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <param name="barrio_idNull">true if the method ignores the barrio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_ID(decimal barrio_id, bool barrio_idNull)
		{
			return CreateDeleteByBARRIO_IDCommand(barrio_id, barrio_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <param name="barrio_idNull">true if the method ignores the barrio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByBARRIO_IDCommand(decimal barrio_id, bool barrio_idNull)
		{
			string whereSql = "";
			if(barrio_idNull)
				whereSql += "BARRIO_ID IS NULL";
			else
				whereSql += "BARRIO_ID=" + _db.CreateSqlParameterName("BARRIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!barrio_idNull)
				AddParameter(cmd, "BARRIO_ID", barrio_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ID(decimal ciudad_id)
		{
			return DeleteByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ID(decimal ciudad_id, bool ciudad_idNull)
		{
			return CreateDeleteByCIUDAD_IDCommand(ciudad_id, ciudad_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_CIUDADES</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCIUDAD_IDCommand(decimal ciudad_id, bool ciudad_idNull)
		{
			string whereSql = "";
			if(ciudad_idNull)
				whereSql += "CIUDAD_ID IS NULL";
			else
				whereSql += "CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ciudad_idNull)
				AddParameter(cmd, "CIUDAD_ID", ciudad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return DeleteByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ID(decimal departamento_id, bool departamento_idNull)
		{
			return CreateDeleteByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPARTAMENTO_IDCommand(decimal departamento_id, bool departamento_idNull)
		{
			string whereSql = "";
			if(departamento_idNull)
				whereSql += "DEPARTAMENTO_ID IS NULL";
			else
				whereSql += "DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!departamento_idNull)
				AddParameter(cmd, "DEPARTAMENTO_ID", departamento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_DISP_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_disponibilidad_id">The <c>TEXTO_PRED_DISPONIBILIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PRED_DISPONIBILIDAD_ID(decimal texto_pred_disponibilidad_id)
		{
			return CreateDeleteByTEXTO_PRED_DISPONIBILIDAD_IDCommand(texto_pred_disponibilidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_DISP_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_disponibilidad_id">The <c>TEXTO_PRED_DISPONIBILIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PRED_DISPONIBILIDAD_IDCommand(decimal texto_pred_disponibilidad_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PRED_DISPONIBILIDAD_ID=" + _db.CreateSqlParameterName("TEXTO_PRED_DISPONIBILIDAD_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TEXTO_PRED_DISPONIBILIDAD_ID", texto_pred_disponibilidad_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINMUEBLE_PADRE_ID(decimal inmueble_padre_id)
		{
			return DeleteByINMUEBLE_PADRE_ID(inmueble_padre_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <param name="inmueble_padre_idNull">true if the method ignores the inmueble_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByINMUEBLE_PADRE_ID(decimal inmueble_padre_id, bool inmueble_padre_idNull)
		{
			return CreateDeleteByINMUEBLE_PADRE_IDCommand(inmueble_padre_id, inmueble_padre_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_INMUEBLES</c> foreign key.
		/// </summary>
		/// <param name="inmueble_padre_id">The <c>INMUEBLE_PADRE_ID</c> column value.</param>
		/// <param name="inmueble_padre_idNull">true if the method ignores the inmueble_padre_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByINMUEBLE_PADRE_IDCommand(decimal inmueble_padre_id, bool inmueble_padre_idNull)
		{
			string whereSql = "";
			if(inmueble_padre_idNull)
				whereSql += "INMUEBLE_PADRE_ID IS NULL";
			else
				whereSql += "INMUEBLE_PADRE_ID=" + _db.CreateSqlParameterName("INMUEBLE_PADRE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!inmueble_padre_idNull)
				AddParameter(cmd, "INMUEBLE_PADRE_ID", inmueble_padre_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id)
		{
			return DeleteByPAIS_ID(pais_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <param name="pais_idNull">true if the method ignores the pais_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id, bool pais_idNull)
		{
			return CreateDeleteByPAIS_IDCommand(pais_id, pais_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_PAISES</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <param name="pais_idNull">true if the method ignores the pais_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_IDCommand(decimal pais_id, bool pais_idNull)
		{
			string whereSql = "";
			if(pais_idNull)
				whereSql += "PAIS_ID IS NULL";
			else
				whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!pais_idNull)
				AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_PROPIETARIO_ID(decimal persona_propietario_id)
		{
			return DeleteByPERSONA_PROPIETARIO_ID(persona_propietario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <param name="persona_propietario_idNull">true if the method ignores the persona_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_PROPIETARIO_ID(decimal persona_propietario_id, bool persona_propietario_idNull)
		{
			return CreateDeleteByPERSONA_PROPIETARIO_IDCommand(persona_propietario_id, persona_propietario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_PERSONAS</c> foreign key.
		/// </summary>
		/// <param name="persona_propietario_id">The <c>PERSONA_PROPIETARIO_ID</c> column value.</param>
		/// <param name="persona_propietario_idNull">true if the method ignores the persona_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_PROPIETARIO_IDCommand(decimal persona_propietario_id, bool persona_propietario_idNull)
		{
			string whereSql = "";
			if(persona_propietario_idNull)
				whereSql += "PERSONA_PROPIETARIO_ID IS NULL";
			else
				whereSql += "PERSONA_PROPIETARIO_ID=" + _db.CreateSqlParameterName("PERSONA_PROPIETARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_propietario_idNull)
				AddParameter(cmd, "PERSONA_PROPIETARIO_ID", persona_propietario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_PROPIETARIO_ID(decimal proveedor_propietario_id)
		{
			return DeleteByPROVEEDOR_PROPIETARIO_ID(proveedor_propietario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <param name="proveedor_propietario_idNull">true if the method ignores the proveedor_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_PROPIETARIO_ID(decimal proveedor_propietario_id, bool proveedor_propietario_idNull)
		{
			return CreateDeleteByPROVEEDOR_PROPIETARIO_IDCommand(proveedor_propietario_id, proveedor_propietario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_propietario_id">The <c>PROVEEDOR_PROPIETARIO_ID</c> column value.</param>
		/// <param name="proveedor_propietario_idNull">true if the method ignores the proveedor_propietario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_PROPIETARIO_IDCommand(decimal proveedor_propietario_id, bool proveedor_propietario_idNull)
		{
			string whereSql = "";
			if(proveedor_propietario_idNull)
				whereSql += "PROVEEDOR_PROPIETARIO_ID IS NULL";
			else
				whereSql += "PROVEEDOR_PROPIETARIO_ID=" + _db.CreateSqlParameterName("PROVEEDOR_PROPIETARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_propietario_idNull)
				AddParameter(cmd, "PROVEEDOR_PROPIETARIO_ID", proveedor_propietario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>INMUEBLES</c> table using the 
		/// <c>FK_INMUEBLES_TIPO_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_tipo_inmueble_id">The <c>TEXTO_PRED_TIPO_INMUEBLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PRED_TIPO_INMUEBLE_ID(decimal texto_pred_tipo_inmueble_id)
		{
			return CreateDeleteByTEXTO_PRED_TIPO_INMUEBLE_IDCommand(texto_pred_tipo_inmueble_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_INMUEBLES_TIPO_TEXT_PREDEF</c> foreign key.
		/// </summary>
		/// <param name="texto_pred_tipo_inmueble_id">The <c>TEXTO_PRED_TIPO_INMUEBLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PRED_TIPO_INMUEBLE_IDCommand(decimal texto_pred_tipo_inmueble_id)
		{
			string whereSql = "";
			whereSql += "TEXTO_PRED_TIPO_INMUEBLE_ID=" + _db.CreateSqlParameterName("TEXTO_PRED_TIPO_INMUEBLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TEXTO_PRED_TIPO_INMUEBLE_ID", texto_pred_tipo_inmueble_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>INMUEBLES</c> records that match the specified criteria.
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
		/// to delete <c>INMUEBLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.INMUEBLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>INMUEBLES</c> table.
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
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		protected INMUEBLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		protected INMUEBLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="INMUEBLESRow"/> objects.</returns>
		protected virtual INMUEBLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int texto_pred_tipo_inmueble_idColumnIndex = reader.GetOrdinal("TEXTO_PRED_TIPO_INMUEBLE_ID");
			int propietario_nombreColumnIndex = reader.GetOrdinal("PROPIETARIO_NOMBRE");
			int propietario_apellidoColumnIndex = reader.GetOrdinal("PROPIETARIO_APELLIDO");
			int persona_propietario_idColumnIndex = reader.GetOrdinal("PERSONA_PROPIETARIO_ID");
			int inmueble_padre_idColumnIndex = reader.GetOrdinal("INMUEBLE_PADRE_ID");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int ciudad_idColumnIndex = reader.GetOrdinal("CIUDAD_ID");
			int barrio_idColumnIndex = reader.GetOrdinal("BARRIO_ID");
			int departamento_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_ID");
			int lote_numeroColumnIndex = reader.GetOrdinal("LOTE_NUMERO");
			int superficieColumnIndex = reader.GetOrdinal("SUPERFICIE");
			int finca_numeroColumnIndex = reader.GetOrdinal("FINCA_NUMERO");
			int cuenta_catastralColumnIndex = reader.GetOrdinal("CUENTA_CATASTRAL");
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
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int calleColumnIndex = reader.GetOrdinal("CALLE");
			int proveedor_propietario_idColumnIndex = reader.GetOrdinal("PROVEEDOR_PROPIETARIO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					INMUEBLESRow record = new INMUEBLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TEXTO_PRED_TIPO_INMUEBLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_pred_tipo_inmueble_idColumnIndex)), 9);
					if(!reader.IsDBNull(propietario_nombreColumnIndex))
						record.PROPIETARIO_NOMBRE = Convert.ToString(reader.GetValue(propietario_nombreColumnIndex));
					if(!reader.IsDBNull(propietario_apellidoColumnIndex))
						record.PROPIETARIO_APELLIDO = Convert.ToString(reader.GetValue(propietario_apellidoColumnIndex));
					if(!reader.IsDBNull(persona_propietario_idColumnIndex))
						record.PERSONA_PROPIETARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_propietario_idColumnIndex)), 9);
					if(!reader.IsDBNull(inmueble_padre_idColumnIndex))
						record.INMUEBLE_PADRE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(inmueble_padre_idColumnIndex)), 9);
					if(!reader.IsDBNull(pais_idColumnIndex))
						record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_idColumnIndex))
						record.CIUDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_idColumnIndex))
						record.BARRIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_idColumnIndex))
						record.DEPARTAMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_numeroColumnIndex))
						record.LOTE_NUMERO = Convert.ToString(reader.GetValue(lote_numeroColumnIndex));
					if(!reader.IsDBNull(superficieColumnIndex))
						record.SUPERFICIE = Math.Round(Convert.ToDecimal(reader.GetValue(superficieColumnIndex)), 9);
					if(!reader.IsDBNull(finca_numeroColumnIndex))
						record.FINCA_NUMERO = Convert.ToString(reader.GetValue(finca_numeroColumnIndex));
					if(!reader.IsDBNull(cuenta_catastralColumnIndex))
						record.CUENTA_CATASTRAL = Convert.ToString(reader.GetValue(cuenta_catastralColumnIndex));
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
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(calleColumnIndex))
						record.CALLE = Convert.ToString(reader.GetValue(calleColumnIndex));
					if(!reader.IsDBNull(proveedor_propietario_idColumnIndex))
						record.PROVEEDOR_PROPIETARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_propietario_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (INMUEBLESRow[])(recordList.ToArray(typeof(INMUEBLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="INMUEBLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="INMUEBLESRow"/> object.</returns>
		protected virtual INMUEBLESRow MapRow(DataRow row)
		{
			INMUEBLESRow mappedObject = new INMUEBLESRow();
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
			// Column "INMUEBLE_PADRE_ID"
			dataColumn = dataTable.Columns["INMUEBLE_PADRE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.INMUEBLE_PADRE_ID = (decimal)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_ID"
			dataColumn = dataTable.Columns["CIUDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_ID = (decimal)row[dataColumn];
			// Column "BARRIO_ID"
			dataColumn = dataTable.Columns["BARRIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_ID = (decimal)row[dataColumn];
			// Column "LOTE_NUMERO"
			dataColumn = dataTable.Columns["LOTE_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_NUMERO = (string)row[dataColumn];
			// Column "SUPERFICIE"
			dataColumn = dataTable.Columns["SUPERFICIE"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUPERFICIE = (decimal)row[dataColumn];
			// Column "FINCA_NUMERO"
			dataColumn = dataTable.Columns["FINCA_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FINCA_NUMERO = (string)row[dataColumn];
			// Column "CUENTA_CATASTRAL"
			dataColumn = dataTable.Columns["CUENTA_CATASTRAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA_CATASTRAL = (string)row[dataColumn];
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
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "CALLE"
			dataColumn = dataTable.Columns["CALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE = (string)row[dataColumn];
			// Column "PROVEEDOR_PROPIETARIO_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_PROPIETARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_PROPIETARIO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>INMUEBLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "INMUEBLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO_PRED_TIPO_INMUEBLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROPIETARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("PROPIETARIO_APELLIDO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("PERSONA_PROPIETARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INMUEBLE_PADRE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("SUPERFICIE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FINCA_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CUENTA_CATASTRAL", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PADRON_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("LATITUD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LONGITUD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESCRITURADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PISO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TELEFONO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MEDIDOR_AGUA_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MEDIDOR_ELECTRICIDAD_NUMERO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("NIS_ELECTRICIDAD", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CUENTA_CATASTRAL_AGUA", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ES_ESPACIO_COMUN", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("MATRICULA_NRO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TEXTO_PRED_DISPONIBILIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CALLE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_PROPIETARIO_ID", typeof(decimal));
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

				case "PROPIETARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROPIETARIO_APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_PROPIETARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INMUEBLE_PADRE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SUPERFICIE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FINCA_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CUENTA_CATASTRAL":
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

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PROVEEDOR_PROPIETARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of INMUEBLESCollection_Base class
}  // End of namespace
