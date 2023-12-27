// <fileinfo name="SUCURSALESCollection_Base.cs">
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
	/// The base class for <see cref="SUCURSALESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="SUCURSALESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class SUCURSALESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string ABREVIATURAColumnName = "ABREVIATURA";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string DIRECCIONColumnName = "DIRECCION";
		public const string TELEFONOColumnName = "TELEFONO";
		public const string MAYORISTAColumnName = "MAYORISTA";
		public const string ES_CASA_MATRIZColumnName = "ES_CASA_MATRIZ";
		public const string SUC_CASA_MATRIZ_IDColumnName = "SUC_CASA_MATRIZ_ID";
		public const string PLAN_DE_CUENTASColumnName = "PLAN_DE_CUENTAS";
		public const string RUCColumnName = "RUC";
		public const string ESTADOColumnName = "ESTADO";
		public const string REGION_IDColumnName = "REGION_ID";
		public const string DEPARTAMENTO_IDColumnName = "DEPARTAMENTO_ID";
		public const string BARRIO_IDColumnName = "BARRIO_ID";
		public const string CIUDAD_IDColumnName = "CIUDAD_ID";
		public const string CENTRO_COSTO_IDColumnName = "CENTRO_COSTO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string FC_PROVEEDORES_CC_OBLIGATORIOColumnName = "FC_PROVEEDORES_CC_OBLIGATORIO";
		public const string PARA_FACTURARColumnName = "PARA_FACTURAR";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="SUCURSALESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public SUCURSALESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>SUCURSALES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>SUCURSALES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>SUCURSALES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="SUCURSALESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="SUCURSALESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public SUCURSALESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			SUCURSALESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public SUCURSALESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects that 
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
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.SUCURSALES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="SUCURSALESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="SUCURSALESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual SUCURSALESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			SUCURSALESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public SUCURSALESRow[] GetByBARRIO_ID(decimal barrio_id)
		{
			return GetByBARRIO_ID(barrio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <param name="barrio_idNull">true if the method ignores the barrio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByBARRIO_ID(decimal barrio_id, bool barrio_idNull)
		{
			return MapRecords(CreateGetByBARRIO_IDCommand(barrio_id, barrio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO_IDAsDataTable(decimal barrio_id)
		{
			return GetByBARRIO_IDAsDataTable(barrio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_BARRIOS</c> foreign key.
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
		/// return records by the <c>FK_SUCURSALES_BARRIOS</c> foreign key.
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
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public SUCURSALESRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <param name="centro_costo_idNull">true if the method ignores the centro_costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByCENTRO_COSTO_ID(decimal centro_costo_id, bool centro_costo_idNull)
		{
			return MapRecords(CreateGetByCENTRO_COSTO_IDCommand(centro_costo_id, centro_costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCENTRO_COSTO_IDAsDataTable(decimal centro_costo_id)
		{
			return GetByCENTRO_COSTO_IDAsDataTable(centro_costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
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
		/// return records by the <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
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
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public SUCURSALESRow[] GetByCIUDAD_ID(decimal ciudad_id)
		{
			return GetByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByCIUDAD_ID(decimal ciudad_id, bool ciudad_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_IDCommand(ciudad_id, ciudad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_IDAsDataTable(decimal ciudad_id)
		{
			return GetByCIUDAD_IDAsDataTable(ciudad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_CIUDAD</c> foreign key.
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
		/// return records by the <c>FK_SUCURSALES_CIUDAD</c> foreign key.
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
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public SUCURSALESRow[] GetByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByDEPARTAMENTO_ID(decimal departamento_id, bool departamento_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_IDAsDataTable(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_IDAsDataTable(departamento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
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
		/// return records by the <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
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
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SUCURSALES_ENTIDAD</c> foreign key.
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
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SUCURSALES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByPAIS_ID(decimal pais_id)
		{
			return MapRecords(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAIS_IDAsDataTable(decimal pais_id)
		{
			return MapRecordsToDataTable(CreateGetByPAIS_IDCommand(pais_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SUCURSALES_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public SUCURSALESRow[] GetByREGION_ID(decimal region_id)
		{
			return GetByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetByREGION_ID(decimal region_id, bool region_idNull)
		{
			return MapRecords(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByREGION_IDAsDataTable(decimal region_id)
		{
			return GetByREGION_IDAsDataTable(region_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREGION_IDAsDataTable(decimal region_id, bool region_idNull)
		{
			return MapRecordsToDataTable(CreateGetByREGION_IDCommand(region_id, region_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public SUCURSALESRow[] GetBySUC_CASA_MATRIZ_ID(decimal suc_casa_matriz_id)
		{
			return GetBySUC_CASA_MATRIZ_ID(suc_casa_matriz_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="SUCURSALESRow"/> objects 
		/// by the <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <param name="suc_casa_matriz_idNull">true if the method ignores the suc_casa_matriz_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		public virtual SUCURSALESRow[] GetBySUC_CASA_MATRIZ_ID(decimal suc_casa_matriz_id, bool suc_casa_matriz_idNull)
		{
			return MapRecords(CreateGetBySUC_CASA_MATRIZ_IDCommand(suc_casa_matriz_id, suc_casa_matriz_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUC_CASA_MATRIZ_IDAsDataTable(decimal suc_casa_matriz_id)
		{
			return GetBySUC_CASA_MATRIZ_IDAsDataTable(suc_casa_matriz_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <param name="suc_casa_matriz_idNull">true if the method ignores the suc_casa_matriz_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUC_CASA_MATRIZ_IDAsDataTable(decimal suc_casa_matriz_id, bool suc_casa_matriz_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUC_CASA_MATRIZ_IDCommand(suc_casa_matriz_id, suc_casa_matriz_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <param name="suc_casa_matriz_idNull">true if the method ignores the suc_casa_matriz_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUC_CASA_MATRIZ_IDCommand(decimal suc_casa_matriz_id, bool suc_casa_matriz_idNull)
		{
			string whereSql = "";
			if(suc_casa_matriz_idNull)
				whereSql += "SUC_CASA_MATRIZ_ID IS NULL";
			else
				whereSql += "SUC_CASA_MATRIZ_ID=" + _db.CreateSqlParameterName("SUC_CASA_MATRIZ_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!suc_casa_matriz_idNull)
				AddParameter(cmd, "SUC_CASA_MATRIZ_ID", suc_casa_matriz_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>SUCURSALES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="SUCURSALESRow"/> object to be inserted.</param>
		public virtual void Insert(SUCURSALESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.SUCURSALES (" +
				"ID, " +
				"NOMBRE, " +
				"ABREVIATURA, " +
				"PAIS_ID, " +
				"ENTIDAD_ID, " +
				"MONEDA_ID, " +
				"DIRECCION, " +
				"TELEFONO, " +
				"MAYORISTA, " +
				"ES_CASA_MATRIZ, " +
				"SUC_CASA_MATRIZ_ID, " +
				"PLAN_DE_CUENTAS, " +
				"RUC, " +
				"ESTADO, " +
				"REGION_ID, " +
				"DEPARTAMENTO_ID, " +
				"BARRIO_ID, " +
				"CIUDAD_ID, " +
				"CENTRO_COSTO_ID, " +
				"PERSONA_ID, " +
				"FC_PROVEEDORES_CC_OBLIGATORIO, " +
				"PARA_FACTURAR" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("ABREVIATURA") + ", " +
				_db.CreateSqlParameterName("PAIS_ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("DIRECCION") + ", " +
				_db.CreateSqlParameterName("TELEFONO") + ", " +
				_db.CreateSqlParameterName("MAYORISTA") + ", " +
				_db.CreateSqlParameterName("ES_CASA_MATRIZ") + ", " +
				_db.CreateSqlParameterName("SUC_CASA_MATRIZ_ID") + ", " +
				_db.CreateSqlParameterName("PLAN_DE_CUENTAS") + ", " +
				_db.CreateSqlParameterName("RUC") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("REGION_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				_db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("FC_PROVEEDORES_CC_OBLIGATORIO") + ", " +
				_db.CreateSqlParameterName("PARA_FACTURAR") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "DIRECCION", value.DIRECCION);
			AddParameter(cmd, "TELEFONO", value.TELEFONO);
			AddParameter(cmd, "MAYORISTA", value.MAYORISTA);
			AddParameter(cmd, "ES_CASA_MATRIZ", value.ES_CASA_MATRIZ);
			AddParameter(cmd, "SUC_CASA_MATRIZ_ID",
				value.IsSUC_CASA_MATRIZ_IDNull ? DBNull.Value : (object)value.SUC_CASA_MATRIZ_ID);
			AddParameter(cmd, "PLAN_DE_CUENTAS",
				value.IsPLAN_DE_CUENTASNull ? DBNull.Value : (object)value.PLAN_DE_CUENTAS);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "BARRIO_ID",
				value.IsBARRIO_IDNull ? DBNull.Value : (object)value.BARRIO_ID);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FC_PROVEEDORES_CC_OBLIGATORIO", value.FC_PROVEEDORES_CC_OBLIGATORIO);
			AddParameter(cmd, "PARA_FACTURAR", value.PARA_FACTURAR);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>SUCURSALES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="SUCURSALESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(SUCURSALESRow value)
		{
			
			string sqlStr = "UPDATE TRC.SUCURSALES SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"ABREVIATURA=" + _db.CreateSqlParameterName("ABREVIATURA") + ", " +
				"PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID") + ", " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"DIRECCION=" + _db.CreateSqlParameterName("DIRECCION") + ", " +
				"TELEFONO=" + _db.CreateSqlParameterName("TELEFONO") + ", " +
				"MAYORISTA=" + _db.CreateSqlParameterName("MAYORISTA") + ", " +
				"ES_CASA_MATRIZ=" + _db.CreateSqlParameterName("ES_CASA_MATRIZ") + ", " +
				"SUC_CASA_MATRIZ_ID=" + _db.CreateSqlParameterName("SUC_CASA_MATRIZ_ID") + ", " +
				"PLAN_DE_CUENTAS=" + _db.CreateSqlParameterName("PLAN_DE_CUENTAS") + ", " +
				"RUC=" + _db.CreateSqlParameterName("RUC") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"REGION_ID=" + _db.CreateSqlParameterName("REGION_ID") + ", " +
				"DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				"BARRIO_ID=" + _db.CreateSqlParameterName("BARRIO_ID") + ", " +
				"CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				"CENTRO_COSTO_ID=" + _db.CreateSqlParameterName("CENTRO_COSTO_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"FC_PROVEEDORES_CC_OBLIGATORIO=" + _db.CreateSqlParameterName("FC_PROVEEDORES_CC_OBLIGATORIO") + ", " +
				"PARA_FACTURAR=" + _db.CreateSqlParameterName("PARA_FACTURAR") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "ABREVIATURA", value.ABREVIATURA);
			AddParameter(cmd, "PAIS_ID", value.PAIS_ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "DIRECCION", value.DIRECCION);
			AddParameter(cmd, "TELEFONO", value.TELEFONO);
			AddParameter(cmd, "MAYORISTA", value.MAYORISTA);
			AddParameter(cmd, "ES_CASA_MATRIZ", value.ES_CASA_MATRIZ);
			AddParameter(cmd, "SUC_CASA_MATRIZ_ID",
				value.IsSUC_CASA_MATRIZ_IDNull ? DBNull.Value : (object)value.SUC_CASA_MATRIZ_ID);
			AddParameter(cmd, "PLAN_DE_CUENTAS",
				value.IsPLAN_DE_CUENTASNull ? DBNull.Value : (object)value.PLAN_DE_CUENTAS);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "REGION_ID",
				value.IsREGION_IDNull ? DBNull.Value : (object)value.REGION_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "BARRIO_ID",
				value.IsBARRIO_IDNull ? DBNull.Value : (object)value.BARRIO_ID);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "CENTRO_COSTO_ID",
				value.IsCENTRO_COSTO_IDNull ? DBNull.Value : (object)value.CENTRO_COSTO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "FC_PROVEEDORES_CC_OBLIGATORIO", value.FC_PROVEEDORES_CC_OBLIGATORIO);
			AddParameter(cmd, "PARA_FACTURAR", value.PARA_FACTURAR);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>SUCURSALES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>SUCURSALES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>SUCURSALES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="SUCURSALESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(SUCURSALESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>SUCURSALES</c> table using
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
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_BARRIOS</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_ID(decimal barrio_id)
		{
			return DeleteByBARRIO_ID(barrio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_BARRIOS</c> foreign key.
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
		/// delete records using the <c>FK_SUCURSALES_BARRIOS</c> foreign key.
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
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
		/// </summary>
		/// <param name="centro_costo_id">The <c>CENTRO_COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCENTRO_COSTO_ID(decimal centro_costo_id)
		{
			return DeleteByCENTRO_COSTO_ID(centro_costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
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
		/// delete records using the <c>FK_SUCURSALES_CENTRO_COSTO</c> foreign key.
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
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ID(decimal ciudad_id)
		{
			return DeleteByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_CIUDAD</c> foreign key.
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
		/// delete records using the <c>FK_SUCURSALES_CIUDAD</c> foreign key.
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
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return DeleteByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
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
		/// delete records using the <c>FK_SUCURSALES_DEPARTAMENTOS</c> foreign key.
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
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SUCURSALES_ENTIDAD</c> foreign key.
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
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SUCURSALES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id)
		{
			return CreateDeleteByPAIS_IDCommand(pais_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SUCURSALES_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAIS_IDCommand(decimal pais_id)
		{
			string whereSql = "";
			whereSql += "PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PAIS_ID", pais_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id)
		{
			return DeleteByREGION_ID(region_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREGION_ID(decimal region_id, bool region_idNull)
		{
			return CreateDeleteByREGION_IDCommand(region_id, region_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SUCURSALES_REGION</c> foreign key.
		/// </summary>
		/// <param name="region_id">The <c>REGION_ID</c> column value.</param>
		/// <param name="region_idNull">true if the method ignores the region_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREGION_IDCommand(decimal region_id, bool region_idNull)
		{
			string whereSql = "";
			if(region_idNull)
				whereSql += "REGION_ID IS NULL";
			else
				whereSql += "REGION_ID=" + _db.CreateSqlParameterName("REGION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!region_idNull)
				AddParameter(cmd, "REGION_ID", region_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUC_CASA_MATRIZ_ID(decimal suc_casa_matriz_id)
		{
			return DeleteBySUC_CASA_MATRIZ_ID(suc_casa_matriz_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>SUCURSALES</c> table using the 
		/// <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <param name="suc_casa_matriz_idNull">true if the method ignores the suc_casa_matriz_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUC_CASA_MATRIZ_ID(decimal suc_casa_matriz_id, bool suc_casa_matriz_idNull)
		{
			return CreateDeleteBySUC_CASA_MATRIZ_IDCommand(suc_casa_matriz_id, suc_casa_matriz_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_SUCURSALES_SUC_CASA_MATRIZ</c> foreign key.
		/// </summary>
		/// <param name="suc_casa_matriz_id">The <c>SUC_CASA_MATRIZ_ID</c> column value.</param>
		/// <param name="suc_casa_matriz_idNull">true if the method ignores the suc_casa_matriz_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUC_CASA_MATRIZ_IDCommand(decimal suc_casa_matriz_id, bool suc_casa_matriz_idNull)
		{
			string whereSql = "";
			if(suc_casa_matriz_idNull)
				whereSql += "SUC_CASA_MATRIZ_ID IS NULL";
			else
				whereSql += "SUC_CASA_MATRIZ_ID=" + _db.CreateSqlParameterName("SUC_CASA_MATRIZ_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!suc_casa_matriz_idNull)
				AddParameter(cmd, "SUC_CASA_MATRIZ_ID", suc_casa_matriz_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>SUCURSALES</c> records that match the specified criteria.
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
		/// to delete <c>SUCURSALES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.SUCURSALES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>SUCURSALES</c> table.
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
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		protected SUCURSALESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		protected SUCURSALESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="SUCURSALESRow"/> objects.</returns>
		protected virtual SUCURSALESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int abreviaturaColumnIndex = reader.GetOrdinal("ABREVIATURA");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int direccionColumnIndex = reader.GetOrdinal("DIRECCION");
			int telefonoColumnIndex = reader.GetOrdinal("TELEFONO");
			int mayoristaColumnIndex = reader.GetOrdinal("MAYORISTA");
			int es_casa_matrizColumnIndex = reader.GetOrdinal("ES_CASA_MATRIZ");
			int suc_casa_matriz_idColumnIndex = reader.GetOrdinal("SUC_CASA_MATRIZ_ID");
			int plan_de_cuentasColumnIndex = reader.GetOrdinal("PLAN_DE_CUENTAS");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int region_idColumnIndex = reader.GetOrdinal("REGION_ID");
			int departamento_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_ID");
			int barrio_idColumnIndex = reader.GetOrdinal("BARRIO_ID");
			int ciudad_idColumnIndex = reader.GetOrdinal("CIUDAD_ID");
			int centro_costo_idColumnIndex = reader.GetOrdinal("CENTRO_COSTO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int fc_proveedores_cc_obligatorioColumnIndex = reader.GetOrdinal("FC_PROVEEDORES_CC_OBLIGATORIO");
			int para_facturarColumnIndex = reader.GetOrdinal("PARA_FACTURAR");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					SUCURSALESRow record = new SUCURSALESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.ABREVIATURA = Convert.ToString(reader.GetValue(abreviaturaColumnIndex));
					record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(direccionColumnIndex))
						record.DIRECCION = Convert.ToString(reader.GetValue(direccionColumnIndex));
					if(!reader.IsDBNull(telefonoColumnIndex))
						record.TELEFONO = Convert.ToString(reader.GetValue(telefonoColumnIndex));
					record.MAYORISTA = Convert.ToString(reader.GetValue(mayoristaColumnIndex));
					record.ES_CASA_MATRIZ = Convert.ToString(reader.GetValue(es_casa_matrizColumnIndex));
					if(!reader.IsDBNull(suc_casa_matriz_idColumnIndex))
						record.SUC_CASA_MATRIZ_ID = Math.Round(Convert.ToDecimal(reader.GetValue(suc_casa_matriz_idColumnIndex)), 9);
					if(!reader.IsDBNull(plan_de_cuentasColumnIndex))
						record.PLAN_DE_CUENTAS = Math.Round(Convert.ToDecimal(reader.GetValue(plan_de_cuentasColumnIndex)), 9);
					if(!reader.IsDBNull(rucColumnIndex))
						record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(region_idColumnIndex))
						record.REGION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(region_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_idColumnIndex))
						record.DEPARTAMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_idColumnIndex))
						record.BARRIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_idColumnIndex))
						record.CIUDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_idColumnIndex)), 9);
					if(!reader.IsDBNull(centro_costo_idColumnIndex))
						record.CENTRO_COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(centro_costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.FC_PROVEEDORES_CC_OBLIGATORIO = Convert.ToString(reader.GetValue(fc_proveedores_cc_obligatorioColumnIndex));
					record.PARA_FACTURAR = Convert.ToString(reader.GetValue(para_facturarColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (SUCURSALESRow[])(recordList.ToArray(typeof(SUCURSALESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="SUCURSALESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="SUCURSALESRow"/> object.</returns>
		protected virtual SUCURSALESRow MapRow(DataRow row)
		{
			SUCURSALESRow mappedObject = new SUCURSALESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "ABREVIATURA"
			dataColumn = dataTable.Columns["ABREVIATURA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ABREVIATURA = (string)row[dataColumn];
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "ENTIDAD_ID"
			dataColumn = dataTable.Columns["ENTIDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "DIRECCION"
			dataColumn = dataTable.Columns["DIRECCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIRECCION = (string)row[dataColumn];
			// Column "TELEFONO"
			dataColumn = dataTable.Columns["TELEFONO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO = (string)row[dataColumn];
			// Column "MAYORISTA"
			dataColumn = dataTable.Columns["MAYORISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAYORISTA = (string)row[dataColumn];
			// Column "ES_CASA_MATRIZ"
			dataColumn = dataTable.Columns["ES_CASA_MATRIZ"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_CASA_MATRIZ = (string)row[dataColumn];
			// Column "SUC_CASA_MATRIZ_ID"
			dataColumn = dataTable.Columns["SUC_CASA_MATRIZ_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUC_CASA_MATRIZ_ID = (decimal)row[dataColumn];
			// Column "PLAN_DE_CUENTAS"
			dataColumn = dataTable.Columns["PLAN_DE_CUENTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLAN_DE_CUENTAS = (decimal)row[dataColumn];
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "REGION_ID"
			dataColumn = dataTable.Columns["REGION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGION_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_ID = (decimal)row[dataColumn];
			// Column "BARRIO_ID"
			dataColumn = dataTable.Columns["BARRIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_ID"
			dataColumn = dataTable.Columns["CIUDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_ID = (decimal)row[dataColumn];
			// Column "CENTRO_COSTO_ID"
			dataColumn = dataTable.Columns["CENTRO_COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CENTRO_COSTO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "FC_PROVEEDORES_CC_OBLIGATORIO"
			dataColumn = dataTable.Columns["FC_PROVEEDORES_CC_OBLIGATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FC_PROVEEDORES_CC_OBLIGATORIO = (string)row[dataColumn];
			// Column "PARA_FACTURAR"
			dataColumn = dataTable.Columns["PARA_FACTURAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PARA_FACTURAR = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>SUCURSALES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "SUCURSALES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ABREVIATURA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIRECCION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("TELEFONO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("MAYORISTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_CASA_MATRIZ", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUC_CASA_MATRIZ_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PLAN_DE_CUENTAS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CENTRO_COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FC_PROVEEDORES_CC_OBLIGATORIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PARA_FACTURAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
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

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ABREVIATURA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIRECCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MAYORISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_CASA_MATRIZ":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SUC_CASA_MATRIZ_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PLAN_DE_CUENTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "REGION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CENTRO_COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FC_PROVEEDORES_CC_OBLIGATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PARA_FACTURAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of SUCURSALESCollection_Base class
}  // End of namespace
