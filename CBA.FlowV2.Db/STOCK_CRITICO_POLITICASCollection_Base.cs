// <fileinfo name="STOCK_CRITICO_POLITICASCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_CRITICO_POLITICASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_CRITICO_POLITICASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_CRITICO_POLITICASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string MARCA_IDColumnName = "MARCA_ID";
		public const string FAMILIA_IDColumnName = "FAMILIA_ID";
		public const string GRUPO_IDColumnName = "GRUPO_ID";
		public const string SUBGRUPO_IDColumnName = "SUBGRUPO_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string POLITICA_CALCULOColumnName = "POLITICA_CALCULO";
		public const string FRECUENCIA_CALCULOColumnName = "FRECUENCIA_CALCULO";
		public const string FECHA_ULTIMA_EJECUCIONColumnName = "FECHA_ULTIMA_EJECUCION";
		public const string FECHA_PROXIMA_EJECUCIONColumnName = "FECHA_PROXIMA_EJECUCION";
		public const string ESTADOColumnName = "ESTADO";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_CRITICO_POLITICASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_CRITICO_POLITICASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_CRITICO_POLITICAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_CRITICO_POLITICAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_CRITICO_POLITICAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_CRITICO_POLITICASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_CRITICO_POLITICASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_CRITICO_POLITICASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_CRITICO_POLITICASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_CRITICO_POLITICAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="STOCK_CRITICO_POLITICASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="STOCK_CRITICO_POLITICASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual STOCK_CRITICO_POLITICASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			STOCK_CRITICO_POLITICASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return GetByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return GetByDEPOSITO_IDAsDataTable(deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetByFAMILIA_ID(decimal familia_id)
		{
			return GetByFAMILIA_ID(familia_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetByFAMILIA_ID(decimal familia_id, bool familia_idNull)
		{
			return MapRecords(CreateGetByFAMILIA_IDCommand(familia_id, familia_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFAMILIA_IDAsDataTable(decimal familia_id)
		{
			return GetByFAMILIA_IDAsDataTable(familia_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFAMILIA_IDAsDataTable(decimal familia_id, bool familia_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFAMILIA_IDCommand(familia_id, familia_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFAMILIA_IDCommand(decimal familia_id, bool familia_idNull)
		{
			string whereSql = "";
			if(familia_idNull)
				whereSql += "FAMILIA_ID IS NULL";
			else
				whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!familia_idNull)
				AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetByGRUPO_ID(decimal grupo_id)
		{
			return GetByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecords(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id)
		{
			return GetByGRUPO_IDAsDataTable(grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByGRUPO_IDAsDataTable(decimal grupo_id, bool grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByGRUPO_IDCommand(grupo_id, grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetByMARCA_ID(decimal marca_id)
		{
			return GetByMARCA_ID(marca_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <param name="marca_idNull">true if the method ignores the marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetByMARCA_ID(decimal marca_id, bool marca_idNull)
		{
			return MapRecords(CreateGetByMARCA_IDCommand(marca_id, marca_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMARCA_IDAsDataTable(decimal marca_id)
		{
			return GetByMARCA_IDAsDataTable(marca_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <param name="marca_idNull">true if the method ignores the marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMARCA_IDAsDataTable(decimal marca_id, bool marca_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMARCA_IDCommand(marca_id, marca_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <param name="marca_idNull">true if the method ignores the marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMARCA_IDCommand(decimal marca_id, bool marca_idNull)
		{
			string whereSql = "";
			if(marca_idNull)
				whereSql += "MARCA_ID IS NULL";
			else
				whereSql += "MARCA_ID=" + _db.CreateSqlParameterName("MARCA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!marca_idNull)
				AddParameter(cmd, "MARCA_ID", marca_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecords(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id)
		{
			return GetBySUBGRUPO_IDAsDataTable(subgrupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUBGRUPO_IDAsDataTable(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public STOCK_CRITICO_POLITICASRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects 
		/// by the <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		public virtual STOCK_CRITICO_POLITICASRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>STOCK_CRITICO_POLITICAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_CRITICO_POLITICASRow"/> object to be inserted.</param>
		public virtual void Insert(STOCK_CRITICO_POLITICASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.STOCK_CRITICO_POLITICAS (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"MARCA_ID, " +
				"FAMILIA_ID, " +
				"GRUPO_ID, " +
				"SUBGRUPO_ID, " +
				"ARTICULO_ID, " +
				"POLITICA_CALCULO, " +
				"FRECUENCIA_CALCULO, " +
				"FECHA_ULTIMA_EJECUCION, " +
				"FECHA_PROXIMA_EJECUCION, " +
				"ESTADO, " +
				"USUARIO_CREACION_ID, " +
				"FECHA_CREACION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("MARCA_ID") + ", " +
				_db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				_db.CreateSqlParameterName("GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("POLITICA_CALCULO") + ", " +
				_db.CreateSqlParameterName("FRECUENCIA_CALCULO") + ", " +
				_db.CreateSqlParameterName("FECHA_ULTIMA_EJECUCION") + ", " +
				_db.CreateSqlParameterName("FECHA_PROXIMA_EJECUCION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "MARCA_ID",
				value.IsMARCA_IDNull ? DBNull.Value : (object)value.MARCA_ID);
			AddParameter(cmd, "FAMILIA_ID",
				value.IsFAMILIA_IDNull ? DBNull.Value : (object)value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "POLITICA_CALCULO", value.POLITICA_CALCULO);
			AddParameter(cmd, "FRECUENCIA_CALCULO", value.FRECUENCIA_CALCULO);
			AddParameter(cmd, "FECHA_ULTIMA_EJECUCION",
				value.IsFECHA_ULTIMA_EJECUCIONNull ? DBNull.Value : (object)value.FECHA_ULTIMA_EJECUCION);
			AddParameter(cmd, "FECHA_PROXIMA_EJECUCION",
				value.IsFECHA_PROXIMA_EJECUCIONNull ? DBNull.Value : (object)value.FECHA_PROXIMA_EJECUCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>STOCK_CRITICO_POLITICAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_CRITICO_POLITICASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(STOCK_CRITICO_POLITICASRow value)
		{
			
			string sqlStr = "UPDATE TRC.STOCK_CRITICO_POLITICAS SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"MARCA_ID=" + _db.CreateSqlParameterName("MARCA_ID") + ", " +
				"FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID") + ", " +
				"GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID") + ", " +
				"SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"POLITICA_CALCULO=" + _db.CreateSqlParameterName("POLITICA_CALCULO") + ", " +
				"FRECUENCIA_CALCULO=" + _db.CreateSqlParameterName("FRECUENCIA_CALCULO") + ", " +
				"FECHA_ULTIMA_EJECUCION=" + _db.CreateSqlParameterName("FECHA_ULTIMA_EJECUCION") + ", " +
				"FECHA_PROXIMA_EJECUCION=" + _db.CreateSqlParameterName("FECHA_PROXIMA_EJECUCION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "MARCA_ID",
				value.IsMARCA_IDNull ? DBNull.Value : (object)value.MARCA_ID);
			AddParameter(cmd, "FAMILIA_ID",
				value.IsFAMILIA_IDNull ? DBNull.Value : (object)value.FAMILIA_ID);
			AddParameter(cmd, "GRUPO_ID",
				value.IsGRUPO_IDNull ? DBNull.Value : (object)value.GRUPO_ID);
			AddParameter(cmd, "SUBGRUPO_ID",
				value.IsSUBGRUPO_IDNull ? DBNull.Value : (object)value.SUBGRUPO_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "POLITICA_CALCULO", value.POLITICA_CALCULO);
			AddParameter(cmd, "FRECUENCIA_CALCULO", value.FRECUENCIA_CALCULO);
			AddParameter(cmd, "FECHA_ULTIMA_EJECUCION",
				value.IsFECHA_ULTIMA_EJECUCIONNull ? DBNull.Value : (object)value.FECHA_ULTIMA_EJECUCION);
			AddParameter(cmd, "FECHA_PROXIMA_EJECUCION",
				value.IsFECHA_PROXIMA_EJECUCIONNull ? DBNull.Value : (object)value.FECHA_PROXIMA_EJECUCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>STOCK_CRITICO_POLITICAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>STOCK_CRITICO_POLITICAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>STOCK_CRITICO_POLITICAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_CRITICO_POLITICASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(STOCK_CRITICO_POLITICASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>STOCK_CRITICO_POLITICAS</c> table using
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
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id, articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_CRIT_POL_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return DeleteByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id, deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_CRIT_POL_DEPO_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFAMILIA_ID(decimal familia_id)
		{
			return DeleteByFAMILIA_ID(familia_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFAMILIA_ID(decimal familia_id, bool familia_idNull)
		{
			return CreateDeleteByFAMILIA_IDCommand(familia_id, familia_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_CRIT_POL_FLIA_ID</c> foreign key.
		/// </summary>
		/// <param name="familia_id">The <c>FAMILIA_ID</c> column value.</param>
		/// <param name="familia_idNull">true if the method ignores the familia_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFAMILIA_IDCommand(decimal familia_id, bool familia_idNull)
		{
			string whereSql = "";
			if(familia_idNull)
				whereSql += "FAMILIA_ID IS NULL";
			else
				whereSql += "FAMILIA_ID=" + _db.CreateSqlParameterName("FAMILIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!familia_idNull)
				AddParameter(cmd, "FAMILIA_ID", familia_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id)
		{
			return DeleteByGRUPO_ID(grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGRUPO_ID(decimal grupo_id, bool grupo_idNull)
		{
			return CreateDeleteByGRUPO_IDCommand(grupo_id, grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_CRIT_POL_GRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="grupo_id">The <c>GRUPO_ID</c> column value.</param>
		/// <param name="grupo_idNull">true if the method ignores the grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByGRUPO_IDCommand(decimal grupo_id, bool grupo_idNull)
		{
			string whereSql = "";
			if(grupo_idNull)
				whereSql += "GRUPO_ID IS NULL";
			else
				whereSql += "GRUPO_ID=" + _db.CreateSqlParameterName("GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!grupo_idNull)
				AddParameter(cmd, "GRUPO_ID", grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMARCA_ID(decimal marca_id)
		{
			return DeleteByMARCA_ID(marca_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <param name="marca_idNull">true if the method ignores the marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMARCA_ID(decimal marca_id, bool marca_idNull)
		{
			return CreateDeleteByMARCA_IDCommand(marca_id, marca_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_CRIT_POL_MARCA_ID</c> foreign key.
		/// </summary>
		/// <param name="marca_id">The <c>MARCA_ID</c> column value.</param>
		/// <param name="marca_idNull">true if the method ignores the marca_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMARCA_IDCommand(decimal marca_id, bool marca_idNull)
		{
			string whereSql = "";
			if(marca_idNull)
				whereSql += "MARCA_ID IS NULL";
			else
				whereSql += "MARCA_ID=" + _db.CreateSqlParameterName("MARCA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!marca_idNull)
				AddParameter(cmd, "MARCA_ID", marca_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id)
		{
			return DeleteBySUBGRUPO_ID(subgrupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUBGRUPO_ID(decimal subgrupo_id, bool subgrupo_idNull)
		{
			return CreateDeleteBySUBGRUPO_IDCommand(subgrupo_id, subgrupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_CRIT_POL_SUBGRUPO_ID</c> foreign key.
		/// </summary>
		/// <param name="subgrupo_id">The <c>SUBGRUPO_ID</c> column value.</param>
		/// <param name="subgrupo_idNull">true if the method ignores the subgrupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUBGRUPO_IDCommand(decimal subgrupo_id, bool subgrupo_idNull)
		{
			string whereSql = "";
			if(subgrupo_idNull)
				whereSql += "SUBGRUPO_ID IS NULL";
			else
				whereSql += "SUBGRUPO_ID=" + _db.CreateSqlParameterName("SUBGRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!subgrupo_idNull)
				AddParameter(cmd, "SUBGRUPO_ID", subgrupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_CRITICO_POLITICAS</c> table using the 
		/// <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STOCK_CRIT_POL_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>STOCK_CRITICO_POLITICAS</c> records that match the specified criteria.
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
		/// to delete <c>STOCK_CRITICO_POLITICAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.STOCK_CRITICO_POLITICAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>STOCK_CRITICO_POLITICAS</c> table.
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
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		protected STOCK_CRITICO_POLITICASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		protected STOCK_CRITICO_POLITICASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_CRITICO_POLITICASRow"/> objects.</returns>
		protected virtual STOCK_CRITICO_POLITICASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int marca_idColumnIndex = reader.GetOrdinal("MARCA_ID");
			int familia_idColumnIndex = reader.GetOrdinal("FAMILIA_ID");
			int grupo_idColumnIndex = reader.GetOrdinal("GRUPO_ID");
			int subgrupo_idColumnIndex = reader.GetOrdinal("SUBGRUPO_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int politica_calculoColumnIndex = reader.GetOrdinal("POLITICA_CALCULO");
			int frecuencia_calculoColumnIndex = reader.GetOrdinal("FRECUENCIA_CALCULO");
			int fecha_ultima_ejecucionColumnIndex = reader.GetOrdinal("FECHA_ULTIMA_EJECUCION");
			int fecha_proxima_ejecucionColumnIndex = reader.GetOrdinal("FECHA_PROXIMA_EJECUCION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_CRITICO_POLITICASRow record = new STOCK_CRITICO_POLITICASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(marca_idColumnIndex))
						record.MARCA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(marca_idColumnIndex)), 9);
					if(!reader.IsDBNull(familia_idColumnIndex))
						record.FAMILIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(familia_idColumnIndex)), 9);
					if(!reader.IsDBNull(grupo_idColumnIndex))
						record.GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(subgrupo_idColumnIndex))
						record.SUBGRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(subgrupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.POLITICA_CALCULO = Convert.ToString(reader.GetValue(politica_calculoColumnIndex));
					record.FRECUENCIA_CALCULO = Convert.ToString(reader.GetValue(frecuencia_calculoColumnIndex));
					if(!reader.IsDBNull(fecha_ultima_ejecucionColumnIndex))
						record.FECHA_ULTIMA_EJECUCION = Convert.ToDateTime(reader.GetValue(fecha_ultima_ejecucionColumnIndex));
					if(!reader.IsDBNull(fecha_proxima_ejecucionColumnIndex))
						record.FECHA_PROXIMA_EJECUCION = Convert.ToDateTime(reader.GetValue(fecha_proxima_ejecucionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_CRITICO_POLITICASRow[])(recordList.ToArray(typeof(STOCK_CRITICO_POLITICASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_CRITICO_POLITICASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_CRITICO_POLITICASRow"/> object.</returns>
		protected virtual STOCK_CRITICO_POLITICASRow MapRow(DataRow row)
		{
			STOCK_CRITICO_POLITICASRow mappedObject = new STOCK_CRITICO_POLITICASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "MARCA_ID"
			dataColumn = dataTable.Columns["MARCA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA_ID = (decimal)row[dataColumn];
			// Column "FAMILIA_ID"
			dataColumn = dataTable.Columns["FAMILIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FAMILIA_ID = (decimal)row[dataColumn];
			// Column "GRUPO_ID"
			dataColumn = dataTable.Columns["GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GRUPO_ID = (decimal)row[dataColumn];
			// Column "SUBGRUPO_ID"
			dataColumn = dataTable.Columns["SUBGRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUBGRUPO_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "POLITICA_CALCULO"
			dataColumn = dataTable.Columns["POLITICA_CALCULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.POLITICA_CALCULO = (string)row[dataColumn];
			// Column "FRECUENCIA_CALCULO"
			dataColumn = dataTable.Columns["FRECUENCIA_CALCULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FRECUENCIA_CALCULO = (string)row[dataColumn];
			// Column "FECHA_ULTIMA_EJECUCION"
			dataColumn = dataTable.Columns["FECHA_ULTIMA_EJECUCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ULTIMA_EJECUCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_PROXIMA_EJECUCION"
			dataColumn = dataTable.Columns["FECHA_PROXIMA_EJECUCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_PROXIMA_EJECUCION = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_CRITICO_POLITICAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_CRITICO_POLITICAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MARCA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FAMILIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUBGRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("POLITICA_CALCULO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FRECUENCIA_CALCULO", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ULTIMA_EJECUCION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_PROXIMA_EJECUCION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MARCA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FAMILIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUBGRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "POLITICA_CALCULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FRECUENCIA_CALCULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ULTIMA_EJECUCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_PROXIMA_EJECUCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_CRITICO_POLITICASCollection_Base class
}  // End of namespace
