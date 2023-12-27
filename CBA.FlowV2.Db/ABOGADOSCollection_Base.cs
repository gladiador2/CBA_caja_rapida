// <fileinfo name="ABOGADOSCollection_Base.cs">
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
	/// The base class for <see cref="ABOGADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ABOGADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ABOGADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ENTIDAD_IDColumnName = "ENTIDAD_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string APELLIDOColumnName = "APELLIDO";
		public const string NOMBRE_ESTUDIOColumnName = "NOMBRE_ESTUDIO";
		public const string RUCColumnName = "RUC";
		public const string TELEFONO1ColumnName = "TELEFONO1";
		public const string TELEFONO2ColumnName = "TELEFONO2";
		public const string TELEFONO3ColumnName = "TELEFONO3";
		public const string TELEFONO4ColumnName = "TELEFONO4";
		public const string EMAIL1ColumnName = "EMAIL1";
		public const string EMAIL2ColumnName = "EMAIL2";
		public const string EMAIL3ColumnName = "EMAIL3";
		public const string PAIS_IDColumnName = "PAIS_ID";
		public const string DEPARTAMENTO_IDColumnName = "DEPARTAMENTO_ID";
		public const string CIUDAD_IDColumnName = "CIUDAD_ID";
		public const string BARRIO_IDColumnName = "BARRIO_ID";
		public const string CALLEColumnName = "CALLE";
		public const string CODIGO_POSTALColumnName = "CODIGO_POSTAL";
		public const string NOMBRE_CONTACTOColumnName = "NOMBRE_CONTACTO";
		public const string TELEFONO_CONTACTOColumnName = "TELEFONO_CONTACTO";
		public const string EMAIL_CONTACTOColumnName = "EMAIL_CONTACTO";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ABOGADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ABOGADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ABOGADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public virtual ABOGADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ABOGADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ABOGADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ABOGADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ABOGADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ABOGADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ABOGADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ABOGADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public ABOGADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ABOGADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public virtual ABOGADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ABOGADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ABOGADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ABOGADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ABOGADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ABOGADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_BARRIO</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public ABOGADOSRow[] GetByBARRIO_ID(decimal barrio_id)
		{
			return GetByBARRIO_ID(barrio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_BARRIO</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <param name="barrio_idNull">true if the method ignores the barrio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public virtual ABOGADOSRow[] GetByBARRIO_ID(decimal barrio_id, bool barrio_idNull)
		{
			return MapRecords(CreateGetByBARRIO_IDCommand(barrio_id, barrio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_BARRIO</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByBARRIO_IDAsDataTable(decimal barrio_id)
		{
			return GetByBARRIO_IDAsDataTable(barrio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_BARRIO</c> foreign key.
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
		/// return records by the <c>FK_ABOGADOS_BARRIO</c> foreign key.
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
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public ABOGADOSRow[] GetByCIUDAD_ID(decimal ciudad_id)
		{
			return GetByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <param name="ciudad_idNull">true if the method ignores the ciudad_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public virtual ABOGADOSRow[] GetByCIUDAD_ID(decimal ciudad_id, bool ciudad_idNull)
		{
			return MapRecords(CreateGetByCIUDAD_IDCommand(ciudad_id, ciudad_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCIUDAD_IDAsDataTable(decimal ciudad_id)
		{
			return GetByCIUDAD_IDAsDataTable(ciudad_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_CIUDAD</c> foreign key.
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
		/// return records by the <c>FK_ABOGADOS_CIUDAD</c> foreign key.
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
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public ABOGADOSRow[] GetByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <param name="departamento_idNull">true if the method ignores the departamento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public virtual ABOGADOSRow[] GetByDEPARTAMENTO_ID(decimal departamento_id, bool departamento_idNull)
		{
			return MapRecords(CreateGetByDEPARTAMENTO_IDCommand(departamento_id, departamento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPARTAMENTO_IDAsDataTable(decimal departamento_id)
		{
			return GetByDEPARTAMENTO_IDAsDataTable(departamento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
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
		/// return records by the <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
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
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public virtual ABOGADOSRow[] GetByENTIDAD_ID(decimal entidad_id)
		{
			return MapRecords(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByENTIDAD_IDAsDataTable(decimal entidad_id)
		{
			return MapRecordsToDataTable(CreateGetByENTIDAD_IDCommand(entidad_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ABOGADOS_ENTIDAD</c> foreign key.
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
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public ABOGADOSRow[] GetByPAIS_ID(decimal pais_id)
		{
			return GetByPAIS_ID(pais_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ABOGADOSRow"/> objects 
		/// by the <c>FK_ABOGADOS_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <param name="pais_idNull">true if the method ignores the pais_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		public virtual ABOGADOSRow[] GetByPAIS_ID(decimal pais_id, bool pais_idNull)
		{
			return MapRecords(CreateGetByPAIS_IDCommand(pais_id, pais_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPAIS_IDAsDataTable(decimal pais_id)
		{
			return GetByPAIS_IDAsDataTable(pais_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ABOGADOS_PAIS</c> foreign key.
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
		/// return records by the <c>FK_ABOGADOS_PAIS</c> foreign key.
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
		/// Adds a new record into the <c>ABOGADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ABOGADOSRow"/> object to be inserted.</param>
		public virtual void Insert(ABOGADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ABOGADOS (" +
				"ID, " +
				"ENTIDAD_ID, " +
				"NOMBRE, " +
				"APELLIDO, " +
				"NOMBRE_ESTUDIO, " +
				"RUC, " +
				"TELEFONO1, " +
				"TELEFONO2, " +
				"TELEFONO3, " +
				"TELEFONO4, " +
				"EMAIL1, " +
				"EMAIL2, " +
				"EMAIL3, " +
				"PAIS_ID, " +
				"DEPARTAMENTO_ID, " +
				"CIUDAD_ID, " +
				"BARRIO_ID, " +
				"CALLE, " +
				"CODIGO_POSTAL, " +
				"NOMBRE_CONTACTO, " +
				"TELEFONO_CONTACTO, " +
				"EMAIL_CONTACTO, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("APELLIDO") + ", " +
				_db.CreateSqlParameterName("NOMBRE_ESTUDIO") + ", " +
				_db.CreateSqlParameterName("RUC") + ", " +
				_db.CreateSqlParameterName("TELEFONO1") + ", " +
				_db.CreateSqlParameterName("TELEFONO2") + ", " +
				_db.CreateSqlParameterName("TELEFONO3") + ", " +
				_db.CreateSqlParameterName("TELEFONO4") + ", " +
				_db.CreateSqlParameterName("EMAIL1") + ", " +
				_db.CreateSqlParameterName("EMAIL2") + ", " +
				_db.CreateSqlParameterName("EMAIL3") + ", " +
				_db.CreateSqlParameterName("PAIS_ID") + ", " +
				_db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				_db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				_db.CreateSqlParameterName("BARRIO_ID") + ", " +
				_db.CreateSqlParameterName("CALLE") + ", " +
				_db.CreateSqlParameterName("CODIGO_POSTAL") + ", " +
				_db.CreateSqlParameterName("NOMBRE_CONTACTO") + ", " +
				_db.CreateSqlParameterName("TELEFONO_CONTACTO") + ", " +
				_db.CreateSqlParameterName("EMAIL_CONTACTO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "NOMBRE_ESTUDIO", value.NOMBRE_ESTUDIO);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "PAIS_ID",
				value.IsPAIS_IDNull ? DBNull.Value : (object)value.PAIS_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "BARRIO_ID",
				value.IsBARRIO_IDNull ? DBNull.Value : (object)value.BARRIO_ID);
			AddParameter(cmd, "CALLE", value.CALLE);
			AddParameter(cmd, "CODIGO_POSTAL", value.CODIGO_POSTAL);
			AddParameter(cmd, "NOMBRE_CONTACTO", value.NOMBRE_CONTACTO);
			AddParameter(cmd, "TELEFONO_CONTACTO", value.TELEFONO_CONTACTO);
			AddParameter(cmd, "EMAIL_CONTACTO", value.EMAIL_CONTACTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ABOGADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ABOGADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ABOGADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.ABOGADOS SET " +
				"ENTIDAD_ID=" + _db.CreateSqlParameterName("ENTIDAD_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"APELLIDO=" + _db.CreateSqlParameterName("APELLIDO") + ", " +
				"NOMBRE_ESTUDIO=" + _db.CreateSqlParameterName("NOMBRE_ESTUDIO") + ", " +
				"RUC=" + _db.CreateSqlParameterName("RUC") + ", " +
				"TELEFONO1=" + _db.CreateSqlParameterName("TELEFONO1") + ", " +
				"TELEFONO2=" + _db.CreateSqlParameterName("TELEFONO2") + ", " +
				"TELEFONO3=" + _db.CreateSqlParameterName("TELEFONO3") + ", " +
				"TELEFONO4=" + _db.CreateSqlParameterName("TELEFONO4") + ", " +
				"EMAIL1=" + _db.CreateSqlParameterName("EMAIL1") + ", " +
				"EMAIL2=" + _db.CreateSqlParameterName("EMAIL2") + ", " +
				"EMAIL3=" + _db.CreateSqlParameterName("EMAIL3") + ", " +
				"PAIS_ID=" + _db.CreateSqlParameterName("PAIS_ID") + ", " +
				"DEPARTAMENTO_ID=" + _db.CreateSqlParameterName("DEPARTAMENTO_ID") + ", " +
				"CIUDAD_ID=" + _db.CreateSqlParameterName("CIUDAD_ID") + ", " +
				"BARRIO_ID=" + _db.CreateSqlParameterName("BARRIO_ID") + ", " +
				"CALLE=" + _db.CreateSqlParameterName("CALLE") + ", " +
				"CODIGO_POSTAL=" + _db.CreateSqlParameterName("CODIGO_POSTAL") + ", " +
				"NOMBRE_CONTACTO=" + _db.CreateSqlParameterName("NOMBRE_CONTACTO") + ", " +
				"TELEFONO_CONTACTO=" + _db.CreateSqlParameterName("TELEFONO_CONTACTO") + ", " +
				"EMAIL_CONTACTO=" + _db.CreateSqlParameterName("EMAIL_CONTACTO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ENTIDAD_ID", value.ENTIDAD_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "APELLIDO", value.APELLIDO);
			AddParameter(cmd, "NOMBRE_ESTUDIO", value.NOMBRE_ESTUDIO);
			AddParameter(cmd, "RUC", value.RUC);
			AddParameter(cmd, "TELEFONO1", value.TELEFONO1);
			AddParameter(cmd, "TELEFONO2", value.TELEFONO2);
			AddParameter(cmd, "TELEFONO3", value.TELEFONO3);
			AddParameter(cmd, "TELEFONO4", value.TELEFONO4);
			AddParameter(cmd, "EMAIL1", value.EMAIL1);
			AddParameter(cmd, "EMAIL2", value.EMAIL2);
			AddParameter(cmd, "EMAIL3", value.EMAIL3);
			AddParameter(cmd, "PAIS_ID",
				value.IsPAIS_IDNull ? DBNull.Value : (object)value.PAIS_ID);
			AddParameter(cmd, "DEPARTAMENTO_ID",
				value.IsDEPARTAMENTO_IDNull ? DBNull.Value : (object)value.DEPARTAMENTO_ID);
			AddParameter(cmd, "CIUDAD_ID",
				value.IsCIUDAD_IDNull ? DBNull.Value : (object)value.CIUDAD_ID);
			AddParameter(cmd, "BARRIO_ID",
				value.IsBARRIO_IDNull ? DBNull.Value : (object)value.BARRIO_ID);
			AddParameter(cmd, "CALLE", value.CALLE);
			AddParameter(cmd, "CODIGO_POSTAL", value.CODIGO_POSTAL);
			AddParameter(cmd, "NOMBRE_CONTACTO", value.NOMBRE_CONTACTO);
			AddParameter(cmd, "TELEFONO_CONTACTO", value.TELEFONO_CONTACTO);
			AddParameter(cmd, "EMAIL_CONTACTO", value.EMAIL_CONTACTO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ABOGADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ABOGADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ABOGADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ABOGADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ABOGADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ABOGADOS</c> table using
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
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_BARRIO</c> foreign key.
		/// </summary>
		/// <param name="barrio_id">The <c>BARRIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByBARRIO_ID(decimal barrio_id)
		{
			return DeleteByBARRIO_ID(barrio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_BARRIO</c> foreign key.
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
		/// delete records using the <c>FK_ABOGADOS_BARRIO</c> foreign key.
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
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_CIUDAD</c> foreign key.
		/// </summary>
		/// <param name="ciudad_id">The <c>CIUDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCIUDAD_ID(decimal ciudad_id)
		{
			return DeleteByCIUDAD_ID(ciudad_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_CIUDAD</c> foreign key.
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
		/// delete records using the <c>FK_ABOGADOS_CIUDAD</c> foreign key.
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
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
		/// </summary>
		/// <param name="departamento_id">The <c>DEPARTAMENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPARTAMENTO_ID(decimal departamento_id)
		{
			return DeleteByDEPARTAMENTO_ID(departamento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
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
		/// delete records using the <c>FK_ABOGADOS_DEPARTAMENTO</c> foreign key.
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
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_ENTIDAD</c> foreign key.
		/// </summary>
		/// <param name="entidad_id">The <c>ENTIDAD_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByENTIDAD_ID(decimal entidad_id)
		{
			return CreateDeleteByENTIDAD_IDCommand(entidad_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ABOGADOS_ENTIDAD</c> foreign key.
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
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_PAIS</c> foreign key.
		/// </summary>
		/// <param name="pais_id">The <c>PAIS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAIS_ID(decimal pais_id)
		{
			return DeleteByPAIS_ID(pais_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ABOGADOS</c> table using the 
		/// <c>FK_ABOGADOS_PAIS</c> foreign key.
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
		/// delete records using the <c>FK_ABOGADOS_PAIS</c> foreign key.
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
		/// Deletes <c>ABOGADOS</c> records that match the specified criteria.
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
		/// to delete <c>ABOGADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ABOGADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ABOGADOS</c> table.
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
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		protected ABOGADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		protected ABOGADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ABOGADOSRow"/> objects.</returns>
		protected virtual ABOGADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int entidad_idColumnIndex = reader.GetOrdinal("ENTIDAD_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int apellidoColumnIndex = reader.GetOrdinal("APELLIDO");
			int nombre_estudioColumnIndex = reader.GetOrdinal("NOMBRE_ESTUDIO");
			int rucColumnIndex = reader.GetOrdinal("RUC");
			int telefono1ColumnIndex = reader.GetOrdinal("TELEFONO1");
			int telefono2ColumnIndex = reader.GetOrdinal("TELEFONO2");
			int telefono3ColumnIndex = reader.GetOrdinal("TELEFONO3");
			int telefono4ColumnIndex = reader.GetOrdinal("TELEFONO4");
			int email1ColumnIndex = reader.GetOrdinal("EMAIL1");
			int email2ColumnIndex = reader.GetOrdinal("EMAIL2");
			int email3ColumnIndex = reader.GetOrdinal("EMAIL3");
			int pais_idColumnIndex = reader.GetOrdinal("PAIS_ID");
			int departamento_idColumnIndex = reader.GetOrdinal("DEPARTAMENTO_ID");
			int ciudad_idColumnIndex = reader.GetOrdinal("CIUDAD_ID");
			int barrio_idColumnIndex = reader.GetOrdinal("BARRIO_ID");
			int calleColumnIndex = reader.GetOrdinal("CALLE");
			int codigo_postalColumnIndex = reader.GetOrdinal("CODIGO_POSTAL");
			int nombre_contactoColumnIndex = reader.GetOrdinal("NOMBRE_CONTACTO");
			int telefono_contactoColumnIndex = reader.GetOrdinal("TELEFONO_CONTACTO");
			int email_contactoColumnIndex = reader.GetOrdinal("EMAIL_CONTACTO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ABOGADOSRow record = new ABOGADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ENTIDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(entidad_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(apellidoColumnIndex))
						record.APELLIDO = Convert.ToString(reader.GetValue(apellidoColumnIndex));
					record.NOMBRE_ESTUDIO = Convert.ToString(reader.GetValue(nombre_estudioColumnIndex));
					if(!reader.IsDBNull(rucColumnIndex))
						record.RUC = Convert.ToString(reader.GetValue(rucColumnIndex));
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
					if(!reader.IsDBNull(pais_idColumnIndex))
						record.PAIS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pais_idColumnIndex)), 9);
					if(!reader.IsDBNull(departamento_idColumnIndex))
						record.DEPARTAMENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(departamento_idColumnIndex)), 9);
					if(!reader.IsDBNull(ciudad_idColumnIndex))
						record.CIUDAD_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ciudad_idColumnIndex)), 9);
					if(!reader.IsDBNull(barrio_idColumnIndex))
						record.BARRIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(barrio_idColumnIndex)), 9);
					if(!reader.IsDBNull(calleColumnIndex))
						record.CALLE = Convert.ToString(reader.GetValue(calleColumnIndex));
					if(!reader.IsDBNull(codigo_postalColumnIndex))
						record.CODIGO_POSTAL = Convert.ToString(reader.GetValue(codigo_postalColumnIndex));
					if(!reader.IsDBNull(nombre_contactoColumnIndex))
						record.NOMBRE_CONTACTO = Convert.ToString(reader.GetValue(nombre_contactoColumnIndex));
					if(!reader.IsDBNull(telefono_contactoColumnIndex))
						record.TELEFONO_CONTACTO = Convert.ToString(reader.GetValue(telefono_contactoColumnIndex));
					if(!reader.IsDBNull(email_contactoColumnIndex))
						record.EMAIL_CONTACTO = Convert.ToString(reader.GetValue(email_contactoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ABOGADOSRow[])(recordList.ToArray(typeof(ABOGADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ABOGADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ABOGADOSRow"/> object.</returns>
		protected virtual ABOGADOSRow MapRow(DataRow row)
		{
			ABOGADOSRow mappedObject = new ABOGADOSRow();
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
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "APELLIDO"
			dataColumn = dataTable.Columns["APELLIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APELLIDO = (string)row[dataColumn];
			// Column "NOMBRE_ESTUDIO"
			dataColumn = dataTable.Columns["NOMBRE_ESTUDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_ESTUDIO = (string)row[dataColumn];
			// Column "RUC"
			dataColumn = dataTable.Columns["RUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.RUC = (string)row[dataColumn];
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
			// Column "PAIS_ID"
			dataColumn = dataTable.Columns["PAIS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAIS_ID = (decimal)row[dataColumn];
			// Column "DEPARTAMENTO_ID"
			dataColumn = dataTable.Columns["DEPARTAMENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPARTAMENTO_ID = (decimal)row[dataColumn];
			// Column "CIUDAD_ID"
			dataColumn = dataTable.Columns["CIUDAD_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CIUDAD_ID = (decimal)row[dataColumn];
			// Column "BARRIO_ID"
			dataColumn = dataTable.Columns["BARRIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.BARRIO_ID = (decimal)row[dataColumn];
			// Column "CALLE"
			dataColumn = dataTable.Columns["CALLE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALLE = (string)row[dataColumn];
			// Column "CODIGO_POSTAL"
			dataColumn = dataTable.Columns["CODIGO_POSTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_POSTAL = (string)row[dataColumn];
			// Column "NOMBRE_CONTACTO"
			dataColumn = dataTable.Columns["NOMBRE_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_CONTACTO = (string)row[dataColumn];
			// Column "TELEFONO_CONTACTO"
			dataColumn = dataTable.Columns["TELEFONO_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TELEFONO_CONTACTO = (string)row[dataColumn];
			// Column "EMAIL_CONTACTO"
			dataColumn = dataTable.Columns["EMAIL_CONTACTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMAIL_CONTACTO = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ABOGADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ABOGADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ENTIDAD_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APELLIDO", typeof(string));
			dataColumn.MaxLength = 70;
			dataColumn = dataTable.Columns.Add("NOMBRE_ESTUDIO", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RUC", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO1", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO2", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO3", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TELEFONO4", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("EMAIL1", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL2", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("EMAIL3", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("PAIS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPARTAMENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CIUDAD_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BARRIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALLE", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn = dataTable.Columns.Add("CODIGO_POSTAL", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("NOMBRE_CONTACTO", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("TELEFONO_CONTACTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("EMAIL_CONTACTO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "ENTIDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "APELLIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_ESTUDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "RUC":
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

				case "PAIS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPARTAMENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CIUDAD_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BARRIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALLE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO_POSTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TELEFONO_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "EMAIL_CONTACTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ABOGADOSCollection_Base class
}  // End of namespace
