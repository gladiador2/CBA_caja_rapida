// <fileinfo name="CTB_INDICADORES_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="CTB_INDICADORES_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTB_INDICADORES_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_INDICADORES_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CTB_INDICADOR_IDColumnName = "CTB_INDICADOR_ID";
		public const string CTB_INDICADORES_DETALLE_1ColumnName = "CTB_INDICADORES_DETALLE_1";
		public const string CTB_INDICADORES_DETALLE_2ColumnName = "CTB_INDICADORES_DETALLE_2";
		public const string OPERACIONColumnName = "OPERACION";
		public const string CTB_INDICADORES_DETALLE_PADREColumnName = "CTB_INDICADORES_DETALLE_PADRE";
		public const string CTB_CUENTAColumnName = "CTB_CUENTA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_INDICADORES_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTB_INDICADORES_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTB_INDICADORES_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTB_INDICADORES_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTB_INDICADORES_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTB_INDICADORES_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTB_INDICADORES_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTB_INDICADORES_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTB_INDICADORES_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public CTB_INDICADORES_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTB_INDICADORES_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTB_INDICADORES_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTB_INDICADORES_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTB_INDICADORES_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTB_INDICADORES_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public CTB_INDICADORES_DETALLERow[] GetByCTB_CUENTA(decimal ctb_cuenta)
		{
			return GetByCTB_CUENTA(ctb_cuenta, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <param name="ctb_cuentaNull">true if the method ignores the ctb_cuenta
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetByCTB_CUENTA(decimal ctb_cuenta, bool ctb_cuentaNull)
		{
			return MapRecords(CreateGetByCTB_CUENTACommand(ctb_cuenta, ctb_cuentaNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_CUENTAAsDataTable(decimal ctb_cuenta)
		{
			return GetByCTB_CUENTAAsDataTable(ctb_cuenta, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <param name="ctb_cuentaNull">true if the method ignores the ctb_cuenta
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_CUENTAAsDataTable(decimal ctb_cuenta, bool ctb_cuentaNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_CUENTACommand(ctb_cuenta, ctb_cuentaNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <param name="ctb_cuentaNull">true if the method ignores the ctb_cuenta
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_CUENTACommand(decimal ctb_cuenta, bool ctb_cuentaNull)
		{
			string whereSql = "";
			if(ctb_cuentaNull)
				whereSql += "CTB_CUENTA IS NULL";
			else
				whereSql += "CTB_CUENTA=" + _db.CreateSqlParameterName("CTB_CUENTA");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_cuentaNull)
				AddParameter(cmd, "CTB_CUENTA", ctb_cuenta);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public CTB_INDICADORES_DETALLERow[] GetByCTB_INDICADORES_DETALLE_PADRE(decimal ctb_indicadores_detalle_padre)
		{
			return GetByCTB_INDICADORES_DETALLE_PADRE(ctb_indicadores_detalle_padre, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_padreNull">true if the method ignores the ctb_indicadores_detalle_padre
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetByCTB_INDICADORES_DETALLE_PADRE(decimal ctb_indicadores_detalle_padre, bool ctb_indicadores_detalle_padreNull)
		{
			return MapRecords(CreateGetByCTB_INDICADORES_DETALLE_PADRECommand(ctb_indicadores_detalle_padre, ctb_indicadores_detalle_padreNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_INDICADORES_DETALLE_PADREAsDataTable(decimal ctb_indicadores_detalle_padre)
		{
			return GetByCTB_INDICADORES_DETALLE_PADREAsDataTable(ctb_indicadores_detalle_padre, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_padreNull">true if the method ignores the ctb_indicadores_detalle_padre
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_INDICADORES_DETALLE_PADREAsDataTable(decimal ctb_indicadores_detalle_padre, bool ctb_indicadores_detalle_padreNull)
		{
			return MapRecordsToDataTable(CreateGetByCTB_INDICADORES_DETALLE_PADRECommand(ctb_indicadores_detalle_padre, ctb_indicadores_detalle_padreNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_padreNull">true if the method ignores the ctb_indicadores_detalle_padre
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_INDICADORES_DETALLE_PADRECommand(decimal ctb_indicadores_detalle_padre, bool ctb_indicadores_detalle_padreNull)
		{
			string whereSql = "";
			if(ctb_indicadores_detalle_padreNull)
				whereSql += "CTB_INDICADORES_DETALLE_PADRE IS NULL";
			else
				whereSql += "CTB_INDICADORES_DETALLE_PADRE=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_PADRE");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_indicadores_detalle_padreNull)
				AddParameter(cmd, "CTB_INDICADORES_DETALLE_PADRE", ctb_indicadores_detalle_padre);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicador_id">The <c>CTB_INDICADOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetByCTB_INDICADOR_ID(decimal ctb_indicador_id)
		{
			return MapRecords(CreateGetByCTB_INDICADOR_IDCommand(ctb_indicador_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicador_id">The <c>CTB_INDICADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_INDICADOR_IDAsDataTable(decimal ctb_indicador_id)
		{
			return MapRecordsToDataTable(CreateGetByCTB_INDICADOR_IDCommand(ctb_indicador_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICAD_DET_INDICADOR</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicador_id">The <c>CTB_INDICADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_INDICADOR_IDCommand(decimal ctb_indicador_id)
		{
			string whereSql = "";
			whereSql += "CTB_INDICADOR_ID=" + _db.CreateSqlParameterName("CTB_INDICADOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTB_INDICADOR_ID", ctb_indicador_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public CTB_INDICADORES_DETALLERow[] GetByCTB_INDICADORES_DETALLE_1(decimal ctb_indicadores_detalle_1)
		{
			return GetByCTB_INDICADORES_DETALLE_1(ctb_indicadores_detalle_1, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_1Null">true if the method ignores the ctb_indicadores_detalle_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetByCTB_INDICADORES_DETALLE_1(decimal ctb_indicadores_detalle_1, bool ctb_indicadores_detalle_1Null)
		{
			return MapRecords(CreateGetByCTB_INDICADORES_DETALLE_1Command(ctb_indicadores_detalle_1, ctb_indicadores_detalle_1Null));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_INDICADORES_DETALLE_1AsDataTable(decimal ctb_indicadores_detalle_1)
		{
			return GetByCTB_INDICADORES_DETALLE_1AsDataTable(ctb_indicadores_detalle_1, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_1Null">true if the method ignores the ctb_indicadores_detalle_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_INDICADORES_DETALLE_1AsDataTable(decimal ctb_indicadores_detalle_1, bool ctb_indicadores_detalle_1Null)
		{
			return MapRecordsToDataTable(CreateGetByCTB_INDICADORES_DETALLE_1Command(ctb_indicadores_detalle_1, ctb_indicadores_detalle_1Null));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_1Null">true if the method ignores the ctb_indicadores_detalle_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_INDICADORES_DETALLE_1Command(decimal ctb_indicadores_detalle_1, bool ctb_indicadores_detalle_1Null)
		{
			string whereSql = "";
			if(ctb_indicadores_detalle_1Null)
				whereSql += "CTB_INDICADORES_DETALLE_1 IS NULL";
			else
				whereSql += "CTB_INDICADORES_DETALLE_1=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_1");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_indicadores_detalle_1Null)
				AddParameter(cmd, "CTB_INDICADORES_DETALLE_1", ctb_indicadores_detalle_1);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public CTB_INDICADORES_DETALLERow[] GetByCTB_INDICADORES_DETALLE_2(decimal ctb_indicadores_detalle_2)
		{
			return GetByCTB_INDICADORES_DETALLE_2(ctb_indicadores_detalle_2, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_2Null">true if the method ignores the ctb_indicadores_detalle_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetByCTB_INDICADORES_DETALLE_2(decimal ctb_indicadores_detalle_2, bool ctb_indicadores_detalle_2Null)
		{
			return MapRecords(CreateGetByCTB_INDICADORES_DETALLE_2Command(ctb_indicadores_detalle_2, ctb_indicadores_detalle_2Null));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTB_INDICADORES_DETALLE_2AsDataTable(decimal ctb_indicadores_detalle_2)
		{
			return GetByCTB_INDICADORES_DETALLE_2AsDataTable(ctb_indicadores_detalle_2, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_2Null">true if the method ignores the ctb_indicadores_detalle_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTB_INDICADORES_DETALLE_2AsDataTable(decimal ctb_indicadores_detalle_2, bool ctb_indicadores_detalle_2Null)
		{
			return MapRecordsToDataTable(CreateGetByCTB_INDICADORES_DETALLE_2Command(ctb_indicadores_detalle_2, ctb_indicadores_detalle_2Null));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_2Null">true if the method ignores the ctb_indicadores_detalle_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTB_INDICADORES_DETALLE_2Command(decimal ctb_indicadores_detalle_2, bool ctb_indicadores_detalle_2Null)
		{
			string whereSql = "";
			if(ctb_indicadores_detalle_2Null)
				whereSql += "CTB_INDICADORES_DETALLE_2 IS NULL";
			else
				whereSql += "CTB_INDICADORES_DETALLE_2=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_2");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctb_indicadores_detalle_2Null)
				AddParameter(cmd, "CTB_INDICADORES_DETALLE_2", ctb_indicadores_detalle_2);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public CTB_INDICADORES_DETALLERow[] GetByOPERACION(decimal operacion)
		{
			return GetByOPERACION(operacion, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTB_INDICADORES_DETALLERow"/> objects 
		/// by the <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <param name="operacionNull">true if the method ignores the operacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		public virtual CTB_INDICADORES_DETALLERow[] GetByOPERACION(decimal operacion, bool operacionNull)
		{
			return MapRecords(CreateGetByOPERACIONCommand(operacion, operacionNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByOPERACIONAsDataTable(decimal operacion)
		{
			return GetByOPERACIONAsDataTable(operacion, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <param name="operacionNull">true if the method ignores the operacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByOPERACIONAsDataTable(decimal operacion, bool operacionNull)
		{
			return MapRecordsToDataTable(CreateGetByOPERACIONCommand(operacion, operacionNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <param name="operacionNull">true if the method ignores the operacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByOPERACIONCommand(decimal operacion, bool operacionNull)
		{
			string whereSql = "";
			if(operacionNull)
				whereSql += "OPERACION IS NULL";
			else
				whereSql += "OPERACION=" + _db.CreateSqlParameterName("OPERACION");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!operacionNull)
				AddParameter(cmd, "OPERACION", operacion);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTB_INDICADORES_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_INDICADORES_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(CTB_INDICADORES_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTB_INDICADORES_DETALLE (" +
				"ID, " +
				"CTB_INDICADOR_ID, " +
				"CTB_INDICADORES_DETALLE_1, " +
				"CTB_INDICADORES_DETALLE_2, " +
				"OPERACION, " +
				"CTB_INDICADORES_DETALLE_PADRE, " +
				"CTB_CUENTA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CTB_INDICADOR_ID") + ", " +
				_db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_1") + ", " +
				_db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_2") + ", " +
				_db.CreateSqlParameterName("OPERACION") + ", " +
				_db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_PADRE") + ", " +
				_db.CreateSqlParameterName("CTB_CUENTA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CTB_INDICADOR_ID", value.CTB_INDICADOR_ID);
			AddParameter(cmd, "CTB_INDICADORES_DETALLE_1",
				value.IsCTB_INDICADORES_DETALLE_1Null ? DBNull.Value : (object)value.CTB_INDICADORES_DETALLE_1);
			AddParameter(cmd, "CTB_INDICADORES_DETALLE_2",
				value.IsCTB_INDICADORES_DETALLE_2Null ? DBNull.Value : (object)value.CTB_INDICADORES_DETALLE_2);
			AddParameter(cmd, "OPERACION",
				value.IsOPERACIONNull ? DBNull.Value : (object)value.OPERACION);
			AddParameter(cmd, "CTB_INDICADORES_DETALLE_PADRE",
				value.IsCTB_INDICADORES_DETALLE_PADRENull ? DBNull.Value : (object)value.CTB_INDICADORES_DETALLE_PADRE);
			AddParameter(cmd, "CTB_CUENTA",
				value.IsCTB_CUENTANull ? DBNull.Value : (object)value.CTB_CUENTA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTB_INDICADORES_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_INDICADORES_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTB_INDICADORES_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.CTB_INDICADORES_DETALLE SET " +
				"CTB_INDICADOR_ID=" + _db.CreateSqlParameterName("CTB_INDICADOR_ID") + ", " +
				"CTB_INDICADORES_DETALLE_1=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_1") + ", " +
				"CTB_INDICADORES_DETALLE_2=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_2") + ", " +
				"OPERACION=" + _db.CreateSqlParameterName("OPERACION") + ", " +
				"CTB_INDICADORES_DETALLE_PADRE=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_PADRE") + ", " +
				"CTB_CUENTA=" + _db.CreateSqlParameterName("CTB_CUENTA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CTB_INDICADOR_ID", value.CTB_INDICADOR_ID);
			AddParameter(cmd, "CTB_INDICADORES_DETALLE_1",
				value.IsCTB_INDICADORES_DETALLE_1Null ? DBNull.Value : (object)value.CTB_INDICADORES_DETALLE_1);
			AddParameter(cmd, "CTB_INDICADORES_DETALLE_2",
				value.IsCTB_INDICADORES_DETALLE_2Null ? DBNull.Value : (object)value.CTB_INDICADORES_DETALLE_2);
			AddParameter(cmd, "OPERACION",
				value.IsOPERACIONNull ? DBNull.Value : (object)value.OPERACION);
			AddParameter(cmd, "CTB_INDICADORES_DETALLE_PADRE",
				value.IsCTB_INDICADORES_DETALLE_PADRENull ? DBNull.Value : (object)value.CTB_INDICADORES_DETALLE_PADRE);
			AddParameter(cmd, "CTB_CUENTA",
				value.IsCTB_CUENTANull ? DBNull.Value : (object)value.CTB_CUENTA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTB_INDICADORES_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTB_INDICADORES_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTB_INDICADORES_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTB_INDICADORES_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTB_INDICADORES_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTB_INDICADORES_DETALLE</c> table using
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
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA(decimal ctb_cuenta)
		{
			return DeleteByCTB_CUENTA(ctb_cuenta, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <param name="ctb_cuentaNull">true if the method ignores the ctb_cuenta
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_CUENTA(decimal ctb_cuenta, bool ctb_cuentaNull)
		{
			return CreateDeleteByCTB_CUENTACommand(ctb_cuenta, ctb_cuentaNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICAD_DET_CTB_CUENTA</c> foreign key.
		/// </summary>
		/// <param name="ctb_cuenta">The <c>CTB_CUENTA</c> column value.</param>
		/// <param name="ctb_cuentaNull">true if the method ignores the ctb_cuenta
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_CUENTACommand(decimal ctb_cuenta, bool ctb_cuentaNull)
		{
			string whereSql = "";
			if(ctb_cuentaNull)
				whereSql += "CTB_CUENTA IS NULL";
			else
				whereSql += "CTB_CUENTA=" + _db.CreateSqlParameterName("CTB_CUENTA");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_cuentaNull)
				AddParameter(cmd, "CTB_CUENTA", ctb_cuenta);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_INDICADORES_DETALLE_PADRE(decimal ctb_indicadores_detalle_padre)
		{
			return DeleteByCTB_INDICADORES_DETALLE_PADRE(ctb_indicadores_detalle_padre, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_padreNull">true if the method ignores the ctb_indicadores_detalle_padre
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_INDICADORES_DETALLE_PADRE(decimal ctb_indicadores_detalle_padre, bool ctb_indicadores_detalle_padreNull)
		{
			return CreateDeleteByCTB_INDICADORES_DETALLE_PADRECommand(ctb_indicadores_detalle_padre, ctb_indicadores_detalle_padreNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICAD_DET_IND_PADRE</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_padre">The <c>CTB_INDICADORES_DETALLE_PADRE</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_padreNull">true if the method ignores the ctb_indicadores_detalle_padre
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_INDICADORES_DETALLE_PADRECommand(decimal ctb_indicadores_detalle_padre, bool ctb_indicadores_detalle_padreNull)
		{
			string whereSql = "";
			if(ctb_indicadores_detalle_padreNull)
				whereSql += "CTB_INDICADORES_DETALLE_PADRE IS NULL";
			else
				whereSql += "CTB_INDICADORES_DETALLE_PADRE=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_PADRE");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_indicadores_detalle_padreNull)
				AddParameter(cmd, "CTB_INDICADORES_DETALLE_PADRE", ctb_indicadores_detalle_padre);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_INDICADOR</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicador_id">The <c>CTB_INDICADOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_INDICADOR_ID(decimal ctb_indicador_id)
		{
			return CreateDeleteByCTB_INDICADOR_IDCommand(ctb_indicador_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICAD_DET_INDICADOR</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicador_id">The <c>CTB_INDICADOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_INDICADOR_IDCommand(decimal ctb_indicador_id)
		{
			string whereSql = "";
			whereSql += "CTB_INDICADOR_ID=" + _db.CreateSqlParameterName("CTB_INDICADOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTB_INDICADOR_ID", ctb_indicador_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_INDICADORES_DETALLE_1(decimal ctb_indicadores_detalle_1)
		{
			return DeleteByCTB_INDICADORES_DETALLE_1(ctb_indicadores_detalle_1, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_1Null">true if the method ignores the ctb_indicadores_detalle_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_INDICADORES_DETALLE_1(decimal ctb_indicadores_detalle_1, bool ctb_indicadores_detalle_1Null)
		{
			return CreateDeleteByCTB_INDICADORES_DETALLE_1Command(ctb_indicadores_detalle_1, ctb_indicadores_detalle_1Null).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICAD_DET_INDICADOR_1</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_1">The <c>CTB_INDICADORES_DETALLE_1</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_1Null">true if the method ignores the ctb_indicadores_detalle_1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_INDICADORES_DETALLE_1Command(decimal ctb_indicadores_detalle_1, bool ctb_indicadores_detalle_1Null)
		{
			string whereSql = "";
			if(ctb_indicadores_detalle_1Null)
				whereSql += "CTB_INDICADORES_DETALLE_1 IS NULL";
			else
				whereSql += "CTB_INDICADORES_DETALLE_1=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_1");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_indicadores_detalle_1Null)
				AddParameter(cmd, "CTB_INDICADORES_DETALLE_1", ctb_indicadores_detalle_1);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_INDICADORES_DETALLE_2(decimal ctb_indicadores_detalle_2)
		{
			return DeleteByCTB_INDICADORES_DETALLE_2(ctb_indicadores_detalle_2, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_2Null">true if the method ignores the ctb_indicadores_detalle_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTB_INDICADORES_DETALLE_2(decimal ctb_indicadores_detalle_2, bool ctb_indicadores_detalle_2Null)
		{
			return CreateDeleteByCTB_INDICADORES_DETALLE_2Command(ctb_indicadores_detalle_2, ctb_indicadores_detalle_2Null).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICAD_DET_INDICADOR_2</c> foreign key.
		/// </summary>
		/// <param name="ctb_indicadores_detalle_2">The <c>CTB_INDICADORES_DETALLE_2</c> column value.</param>
		/// <param name="ctb_indicadores_detalle_2Null">true if the method ignores the ctb_indicadores_detalle_2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTB_INDICADORES_DETALLE_2Command(decimal ctb_indicadores_detalle_2, bool ctb_indicadores_detalle_2Null)
		{
			string whereSql = "";
			if(ctb_indicadores_detalle_2Null)
				whereSql += "CTB_INDICADORES_DETALLE_2 IS NULL";
			else
				whereSql += "CTB_INDICADORES_DETALLE_2=" + _db.CreateSqlParameterName("CTB_INDICADORES_DETALLE_2");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctb_indicadores_detalle_2Null)
				AddParameter(cmd, "CTB_INDICADORES_DETALLE_2", ctb_indicadores_detalle_2);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOPERACION(decimal operacion)
		{
			return DeleteByOPERACION(operacion, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTB_INDICADORES_DETALLE</c> table using the 
		/// <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <param name="operacionNull">true if the method ignores the operacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByOPERACION(decimal operacion, bool operacionNull)
		{
			return CreateDeleteByOPERACIONCommand(operacion, operacionNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTB_INDICAD_DET_OPERACION</c> foreign key.
		/// </summary>
		/// <param name="operacion">The <c>OPERACION</c> column value.</param>
		/// <param name="operacionNull">true if the method ignores the operacion
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByOPERACIONCommand(decimal operacion, bool operacionNull)
		{
			string whereSql = "";
			if(operacionNull)
				whereSql += "OPERACION IS NULL";
			else
				whereSql += "OPERACION=" + _db.CreateSqlParameterName("OPERACION");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!operacionNull)
				AddParameter(cmd, "OPERACION", operacion);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTB_INDICADORES_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>CTB_INDICADORES_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTB_INDICADORES_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTB_INDICADORES_DETALLE</c> table.
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
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		protected CTB_INDICADORES_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		protected CTB_INDICADORES_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTB_INDICADORES_DETALLERow"/> objects.</returns>
		protected virtual CTB_INDICADORES_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int ctb_indicador_idColumnIndex = reader.GetOrdinal("CTB_INDICADOR_ID");
			int ctb_indicadores_detalle_1ColumnIndex = reader.GetOrdinal("CTB_INDICADORES_DETALLE_1");
			int ctb_indicadores_detalle_2ColumnIndex = reader.GetOrdinal("CTB_INDICADORES_DETALLE_2");
			int operacionColumnIndex = reader.GetOrdinal("OPERACION");
			int ctb_indicadores_detalle_padreColumnIndex = reader.GetOrdinal("CTB_INDICADORES_DETALLE_PADRE");
			int ctb_cuentaColumnIndex = reader.GetOrdinal("CTB_CUENTA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTB_INDICADORES_DETALLERow record = new CTB_INDICADORES_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CTB_INDICADOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_indicador_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_indicadores_detalle_1ColumnIndex))
						record.CTB_INDICADORES_DETALLE_1 = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_indicadores_detalle_1ColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_indicadores_detalle_2ColumnIndex))
						record.CTB_INDICADORES_DETALLE_2 = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_indicadores_detalle_2ColumnIndex)), 9);
					if(!reader.IsDBNull(operacionColumnIndex))
						record.OPERACION = Math.Round(Convert.ToDecimal(reader.GetValue(operacionColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_indicadores_detalle_padreColumnIndex))
						record.CTB_INDICADORES_DETALLE_PADRE = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_indicadores_detalle_padreColumnIndex)), 9);
					if(!reader.IsDBNull(ctb_cuentaColumnIndex))
						record.CTB_CUENTA = Math.Round(Convert.ToDecimal(reader.GetValue(ctb_cuentaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTB_INDICADORES_DETALLERow[])(recordList.ToArray(typeof(CTB_INDICADORES_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTB_INDICADORES_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTB_INDICADORES_DETALLERow"/> object.</returns>
		protected virtual CTB_INDICADORES_DETALLERow MapRow(DataRow row)
		{
			CTB_INDICADORES_DETALLERow mappedObject = new CTB_INDICADORES_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CTB_INDICADOR_ID"
			dataColumn = dataTable.Columns["CTB_INDICADOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_INDICADOR_ID = (decimal)row[dataColumn];
			// Column "CTB_INDICADORES_DETALLE_1"
			dataColumn = dataTable.Columns["CTB_INDICADORES_DETALLE_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_INDICADORES_DETALLE_1 = (decimal)row[dataColumn];
			// Column "CTB_INDICADORES_DETALLE_2"
			dataColumn = dataTable.Columns["CTB_INDICADORES_DETALLE_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_INDICADORES_DETALLE_2 = (decimal)row[dataColumn];
			// Column "OPERACION"
			dataColumn = dataTable.Columns["OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERACION = (decimal)row[dataColumn];
			// Column "CTB_INDICADORES_DETALLE_PADRE"
			dataColumn = dataTable.Columns["CTB_INDICADORES_DETALLE_PADRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_INDICADORES_DETALLE_PADRE = (decimal)row[dataColumn];
			// Column "CTB_CUENTA"
			dataColumn = dataTable.Columns["CTB_CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTB_CUENTA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTB_INDICADORES_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTB_INDICADORES_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_INDICADOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTB_INDICADORES_DETALLE_1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTB_INDICADORES_DETALLE_2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OPERACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTB_INDICADORES_DETALLE_PADRE", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTB_CUENTA", typeof(decimal));
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

				case "CTB_INDICADOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_INDICADORES_DETALLE_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_INDICADORES_DETALLE_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_INDICADORES_DETALLE_PADRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTB_CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTB_INDICADORES_DETALLECollection_Base class
}  // End of namespace
