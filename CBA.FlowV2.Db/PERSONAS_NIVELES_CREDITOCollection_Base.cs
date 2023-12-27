// <fileinfo name="PERSONAS_NIVELES_CREDITOCollection_Base.cs">
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
	/// The base class for <see cref="PERSONAS_NIVELES_CREDITOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PERSONAS_NIVELES_CREDITOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_NIVELES_CREDITOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string LIMITE_CREDITOColumnName = "LIMITE_CREDITO";
		public const string DIAS_GRACIAColumnName = "DIAS_GRACIA";
		public const string LIMITE_INFERIOR_CREDITOColumnName = "LIMITE_INFERIOR_CREDITO";
		public const string ROL_DESBLOQUEO1ColumnName = "ROL_DESBLOQUEO1";
		public const string ROL_DESBLOQUEO2ColumnName = "ROL_DESBLOQUEO2";
		public const string ROL_DESBLOQUEO3ColumnName = "ROL_DESBLOQUEO3";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_NIVELES_CREDITOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PERSONAS_NIVELES_CREDITOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PERSONAS_NIVELES_CREDITO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_NIVELES_CREDITORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PERSONAS_NIVELES_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PERSONAS_NIVELES_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PERSONAS_NIVELES_CREDITORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PERSONAS_NIVELES_CREDITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PERSONAS_NIVELES_CREDITORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PERSONAS_NIVELES_CREDITORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public PERSONAS_NIVELES_CREDITORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects that 
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
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_NIVELES_CREDITORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PERSONAS_NIVELES_CREDITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PERSONAS_NIVELES_CREDITORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PERSONAS_NIVELES_CREDITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PERSONAS_NIVELES_CREDITORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PERSONAS_NIVELES_CREDITORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public PERSONAS_NIVELES_CREDITORow[] GetByROL_DESBLOQUEO1(decimal rol_desbloqueo1)
		{
			return GetByROL_DESBLOQUEO1(rol_desbloqueo1, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <param name="rol_desbloqueo1Null">true if the method ignores the rol_desbloqueo1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_NIVELES_CREDITORow[] GetByROL_DESBLOQUEO1(decimal rol_desbloqueo1, bool rol_desbloqueo1Null)
		{
			return MapRecords(CreateGetByROL_DESBLOQUEO1Command(rol_desbloqueo1, rol_desbloqueo1Null));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_DESBLOQUEO1AsDataTable(decimal rol_desbloqueo1)
		{
			return GetByROL_DESBLOQUEO1AsDataTable(rol_desbloqueo1, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <param name="rol_desbloqueo1Null">true if the method ignores the rol_desbloqueo1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_DESBLOQUEO1AsDataTable(decimal rol_desbloqueo1, bool rol_desbloqueo1Null)
		{
			return MapRecordsToDataTable(CreateGetByROL_DESBLOQUEO1Command(rol_desbloqueo1, rol_desbloqueo1Null));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <param name="rol_desbloqueo1Null">true if the method ignores the rol_desbloqueo1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_DESBLOQUEO1Command(decimal rol_desbloqueo1, bool rol_desbloqueo1Null)
		{
			string whereSql = "";
			if(rol_desbloqueo1Null)
				whereSql += "ROL_DESBLOQUEO1 IS NULL";
			else
				whereSql += "ROL_DESBLOQUEO1=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO1");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_desbloqueo1Null)
				AddParameter(cmd, "ROL_DESBLOQUEO1", rol_desbloqueo1);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public PERSONAS_NIVELES_CREDITORow[] GetByROL_DESBLOQUEO2(decimal rol_desbloqueo2)
		{
			return GetByROL_DESBLOQUEO2(rol_desbloqueo2, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <param name="rol_desbloqueo2Null">true if the method ignores the rol_desbloqueo2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_NIVELES_CREDITORow[] GetByROL_DESBLOQUEO2(decimal rol_desbloqueo2, bool rol_desbloqueo2Null)
		{
			return MapRecords(CreateGetByROL_DESBLOQUEO2Command(rol_desbloqueo2, rol_desbloqueo2Null));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_DESBLOQUEO2AsDataTable(decimal rol_desbloqueo2)
		{
			return GetByROL_DESBLOQUEO2AsDataTable(rol_desbloqueo2, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <param name="rol_desbloqueo2Null">true if the method ignores the rol_desbloqueo2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_DESBLOQUEO2AsDataTable(decimal rol_desbloqueo2, bool rol_desbloqueo2Null)
		{
			return MapRecordsToDataTable(CreateGetByROL_DESBLOQUEO2Command(rol_desbloqueo2, rol_desbloqueo2Null));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <param name="rol_desbloqueo2Null">true if the method ignores the rol_desbloqueo2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_DESBLOQUEO2Command(decimal rol_desbloqueo2, bool rol_desbloqueo2Null)
		{
			string whereSql = "";
			if(rol_desbloqueo2Null)
				whereSql += "ROL_DESBLOQUEO2 IS NULL";
			else
				whereSql += "ROL_DESBLOQUEO2=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO2");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_desbloqueo2Null)
				AddParameter(cmd, "ROL_DESBLOQUEO2", rol_desbloqueo2);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public PERSONAS_NIVELES_CREDITORow[] GetByROL_DESBLOQUEO3(decimal rol_desbloqueo3)
		{
			return GetByROL_DESBLOQUEO3(rol_desbloqueo3, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <param name="rol_desbloqueo3Null">true if the method ignores the rol_desbloqueo3
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		public virtual PERSONAS_NIVELES_CREDITORow[] GetByROL_DESBLOQUEO3(decimal rol_desbloqueo3, bool rol_desbloqueo3Null)
		{
			return MapRecords(CreateGetByROL_DESBLOQUEO3Command(rol_desbloqueo3, rol_desbloqueo3Null));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByROL_DESBLOQUEO3AsDataTable(decimal rol_desbloqueo3)
		{
			return GetByROL_DESBLOQUEO3AsDataTable(rol_desbloqueo3, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <param name="rol_desbloqueo3Null">true if the method ignores the rol_desbloqueo3
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByROL_DESBLOQUEO3AsDataTable(decimal rol_desbloqueo3, bool rol_desbloqueo3Null)
		{
			return MapRecordsToDataTable(CreateGetByROL_DESBLOQUEO3Command(rol_desbloqueo3, rol_desbloqueo3Null));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <param name="rol_desbloqueo3Null">true if the method ignores the rol_desbloqueo3
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByROL_DESBLOQUEO3Command(decimal rol_desbloqueo3, bool rol_desbloqueo3Null)
		{
			string whereSql = "";
			if(rol_desbloqueo3Null)
				whereSql += "ROL_DESBLOQUEO3 IS NULL";
			else
				whereSql += "ROL_DESBLOQUEO3=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO3");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!rol_desbloqueo3Null)
				AddParameter(cmd, "ROL_DESBLOQUEO3", rol_desbloqueo3);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PERSONAS_NIVELES_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_NIVELES_CREDITORow"/> object to be inserted.</param>
		public virtual void Insert(PERSONAS_NIVELES_CREDITORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PERSONAS_NIVELES_CREDITO (" +
				"ID, " +
				"NOMBRE, " +
				"DESCRIPCION, " +
				"LIMITE_CREDITO, " +
				"DIAS_GRACIA, " +
				"LIMITE_INFERIOR_CREDITO, " +
				"ROL_DESBLOQUEO1, " +
				"ROL_DESBLOQUEO2, " +
				"ROL_DESBLOQUEO3" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("LIMITE_CREDITO") + ", " +
				_db.CreateSqlParameterName("DIAS_GRACIA") + ", " +
				_db.CreateSqlParameterName("LIMITE_INFERIOR_CREDITO") + ", " +
				_db.CreateSqlParameterName("ROL_DESBLOQUEO1") + ", " +
				_db.CreateSqlParameterName("ROL_DESBLOQUEO2") + ", " +
				_db.CreateSqlParameterName("ROL_DESBLOQUEO3") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "LIMITE_CREDITO", value.LIMITE_CREDITO);
			AddParameter(cmd, "DIAS_GRACIA", value.DIAS_GRACIA);
			AddParameter(cmd, "LIMITE_INFERIOR_CREDITO", value.LIMITE_INFERIOR_CREDITO);
			AddParameter(cmd, "ROL_DESBLOQUEO1",
				value.IsROL_DESBLOQUEO1Null ? DBNull.Value : (object)value.ROL_DESBLOQUEO1);
			AddParameter(cmd, "ROL_DESBLOQUEO2",
				value.IsROL_DESBLOQUEO2Null ? DBNull.Value : (object)value.ROL_DESBLOQUEO2);
			AddParameter(cmd, "ROL_DESBLOQUEO3",
				value.IsROL_DESBLOQUEO3Null ? DBNull.Value : (object)value.ROL_DESBLOQUEO3);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PERSONAS_NIVELES_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_NIVELES_CREDITORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PERSONAS_NIVELES_CREDITORow value)
		{
			
			string sqlStr = "UPDATE TRC.PERSONAS_NIVELES_CREDITO SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"LIMITE_CREDITO=" + _db.CreateSqlParameterName("LIMITE_CREDITO") + ", " +
				"DIAS_GRACIA=" + _db.CreateSqlParameterName("DIAS_GRACIA") + ", " +
				"LIMITE_INFERIOR_CREDITO=" + _db.CreateSqlParameterName("LIMITE_INFERIOR_CREDITO") + ", " +
				"ROL_DESBLOQUEO1=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO1") + ", " +
				"ROL_DESBLOQUEO2=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO2") + ", " +
				"ROL_DESBLOQUEO3=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO3") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "LIMITE_CREDITO", value.LIMITE_CREDITO);
			AddParameter(cmd, "DIAS_GRACIA", value.DIAS_GRACIA);
			AddParameter(cmd, "LIMITE_INFERIOR_CREDITO", value.LIMITE_INFERIOR_CREDITO);
			AddParameter(cmd, "ROL_DESBLOQUEO1",
				value.IsROL_DESBLOQUEO1Null ? DBNull.Value : (object)value.ROL_DESBLOQUEO1);
			AddParameter(cmd, "ROL_DESBLOQUEO2",
				value.IsROL_DESBLOQUEO2Null ? DBNull.Value : (object)value.ROL_DESBLOQUEO2);
			AddParameter(cmd, "ROL_DESBLOQUEO3",
				value.IsROL_DESBLOQUEO3Null ? DBNull.Value : (object)value.ROL_DESBLOQUEO3);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PERSONAS_NIVELES_CREDITO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PERSONAS_NIVELES_CREDITO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PERSONAS_NIVELES_CREDITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PERSONAS_NIVELES_CREDITORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PERSONAS_NIVELES_CREDITORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PERSONAS_NIVELES_CREDITO</c> table using
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
		/// Deletes records from the <c>PERSONAS_NIVELES_CREDITO</c> table using the 
		/// <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_DESBLOQUEO1(decimal rol_desbloqueo1)
		{
			return DeleteByROL_DESBLOQUEO1(rol_desbloqueo1, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_NIVELES_CREDITO</c> table using the 
		/// <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <param name="rol_desbloqueo1Null">true if the method ignores the rol_desbloqueo1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_DESBLOQUEO1(decimal rol_desbloqueo1, bool rol_desbloqueo1Null)
		{
			return CreateDeleteByROL_DESBLOQUEO1Command(rol_desbloqueo1, rol_desbloqueo1Null).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_NIV_CRED_ROL_DES1</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo1">The <c>ROL_DESBLOQUEO1</c> column value.</param>
		/// <param name="rol_desbloqueo1Null">true if the method ignores the rol_desbloqueo1
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_DESBLOQUEO1Command(decimal rol_desbloqueo1, bool rol_desbloqueo1Null)
		{
			string whereSql = "";
			if(rol_desbloqueo1Null)
				whereSql += "ROL_DESBLOQUEO1 IS NULL";
			else
				whereSql += "ROL_DESBLOQUEO1=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO1");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_desbloqueo1Null)
				AddParameter(cmd, "ROL_DESBLOQUEO1", rol_desbloqueo1);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_NIVELES_CREDITO</c> table using the 
		/// <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_DESBLOQUEO2(decimal rol_desbloqueo2)
		{
			return DeleteByROL_DESBLOQUEO2(rol_desbloqueo2, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_NIVELES_CREDITO</c> table using the 
		/// <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <param name="rol_desbloqueo2Null">true if the method ignores the rol_desbloqueo2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_DESBLOQUEO2(decimal rol_desbloqueo2, bool rol_desbloqueo2Null)
		{
			return CreateDeleteByROL_DESBLOQUEO2Command(rol_desbloqueo2, rol_desbloqueo2Null).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_NIV_CRED_ROL_DES2</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo2">The <c>ROL_DESBLOQUEO2</c> column value.</param>
		/// <param name="rol_desbloqueo2Null">true if the method ignores the rol_desbloqueo2
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_DESBLOQUEO2Command(decimal rol_desbloqueo2, bool rol_desbloqueo2Null)
		{
			string whereSql = "";
			if(rol_desbloqueo2Null)
				whereSql += "ROL_DESBLOQUEO2 IS NULL";
			else
				whereSql += "ROL_DESBLOQUEO2=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO2");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_desbloqueo2Null)
				AddParameter(cmd, "ROL_DESBLOQUEO2", rol_desbloqueo2);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_NIVELES_CREDITO</c> table using the 
		/// <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_DESBLOQUEO3(decimal rol_desbloqueo3)
		{
			return DeleteByROL_DESBLOQUEO3(rol_desbloqueo3, false);
		}

		/// <summary>
		/// Deletes records from the <c>PERSONAS_NIVELES_CREDITO</c> table using the 
		/// <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <param name="rol_desbloqueo3Null">true if the method ignores the rol_desbloqueo3
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByROL_DESBLOQUEO3(decimal rol_desbloqueo3, bool rol_desbloqueo3Null)
		{
			return CreateDeleteByROL_DESBLOQUEO3Command(rol_desbloqueo3, rol_desbloqueo3Null).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PERSONAS_NIV_CRED_ROL_DES3</c> foreign key.
		/// </summary>
		/// <param name="rol_desbloqueo3">The <c>ROL_DESBLOQUEO3</c> column value.</param>
		/// <param name="rol_desbloqueo3Null">true if the method ignores the rol_desbloqueo3
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByROL_DESBLOQUEO3Command(decimal rol_desbloqueo3, bool rol_desbloqueo3Null)
		{
			string whereSql = "";
			if(rol_desbloqueo3Null)
				whereSql += "ROL_DESBLOQUEO3 IS NULL";
			else
				whereSql += "ROL_DESBLOQUEO3=" + _db.CreateSqlParameterName("ROL_DESBLOQUEO3");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!rol_desbloqueo3Null)
				AddParameter(cmd, "ROL_DESBLOQUEO3", rol_desbloqueo3);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PERSONAS_NIVELES_CREDITO</c> records that match the specified criteria.
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
		/// to delete <c>PERSONAS_NIVELES_CREDITO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PERSONAS_NIVELES_CREDITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PERSONAS_NIVELES_CREDITO</c> table.
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
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		protected PERSONAS_NIVELES_CREDITORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		protected PERSONAS_NIVELES_CREDITORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PERSONAS_NIVELES_CREDITORow"/> objects.</returns>
		protected virtual PERSONAS_NIVELES_CREDITORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int limite_creditoColumnIndex = reader.GetOrdinal("LIMITE_CREDITO");
			int dias_graciaColumnIndex = reader.GetOrdinal("DIAS_GRACIA");
			int limite_inferior_creditoColumnIndex = reader.GetOrdinal("LIMITE_INFERIOR_CREDITO");
			int rol_desbloqueo1ColumnIndex = reader.GetOrdinal("ROL_DESBLOQUEO1");
			int rol_desbloqueo2ColumnIndex = reader.GetOrdinal("ROL_DESBLOQUEO2");
			int rol_desbloqueo3ColumnIndex = reader.GetOrdinal("ROL_DESBLOQUEO3");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PERSONAS_NIVELES_CREDITORow record = new PERSONAS_NIVELES_CREDITORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.LIMITE_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(limite_creditoColumnIndex)), 9);
					record.DIAS_GRACIA = Math.Round(Convert.ToDecimal(reader.GetValue(dias_graciaColumnIndex)), 9);
					record.LIMITE_INFERIOR_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(limite_inferior_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(rol_desbloqueo1ColumnIndex))
						record.ROL_DESBLOQUEO1 = Math.Round(Convert.ToDecimal(reader.GetValue(rol_desbloqueo1ColumnIndex)), 9);
					if(!reader.IsDBNull(rol_desbloqueo2ColumnIndex))
						record.ROL_DESBLOQUEO2 = Math.Round(Convert.ToDecimal(reader.GetValue(rol_desbloqueo2ColumnIndex)), 9);
					if(!reader.IsDBNull(rol_desbloqueo3ColumnIndex))
						record.ROL_DESBLOQUEO3 = Math.Round(Convert.ToDecimal(reader.GetValue(rol_desbloqueo3ColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PERSONAS_NIVELES_CREDITORow[])(recordList.ToArray(typeof(PERSONAS_NIVELES_CREDITORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PERSONAS_NIVELES_CREDITORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PERSONAS_NIVELES_CREDITORow"/> object.</returns>
		protected virtual PERSONAS_NIVELES_CREDITORow MapRow(DataRow row)
		{
			PERSONAS_NIVELES_CREDITORow mappedObject = new PERSONAS_NIVELES_CREDITORow();
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
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "LIMITE_CREDITO"
			dataColumn = dataTable.Columns["LIMITE_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_CREDITO = (decimal)row[dataColumn];
			// Column "DIAS_GRACIA"
			dataColumn = dataTable.Columns["DIAS_GRACIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DIAS_GRACIA = (decimal)row[dataColumn];
			// Column "LIMITE_INFERIOR_CREDITO"
			dataColumn = dataTable.Columns["LIMITE_INFERIOR_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_INFERIOR_CREDITO = (decimal)row[dataColumn];
			// Column "ROL_DESBLOQUEO1"
			dataColumn = dataTable.Columns["ROL_DESBLOQUEO1"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_DESBLOQUEO1 = (decimal)row[dataColumn];
			// Column "ROL_DESBLOQUEO2"
			dataColumn = dataTable.Columns["ROL_DESBLOQUEO2"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_DESBLOQUEO2 = (decimal)row[dataColumn];
			// Column "ROL_DESBLOQUEO3"
			dataColumn = dataTable.Columns["ROL_DESBLOQUEO3"];
			if(!row.IsNull(dataColumn))
				mappedObject.ROL_DESBLOQUEO3 = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PERSONAS_NIVELES_CREDITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PERSONAS_NIVELES_CREDITO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("LIMITE_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DIAS_GRACIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LIMITE_INFERIOR_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ROL_DESBLOQUEO1", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ROL_DESBLOQUEO2", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ROL_DESBLOQUEO3", typeof(decimal));
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

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIMITE_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DIAS_GRACIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_INFERIOR_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_DESBLOQUEO1":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_DESBLOQUEO2":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ROL_DESBLOQUEO3":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PERSONAS_NIVELES_CREDITOCollection_Base class
}  // End of namespace
