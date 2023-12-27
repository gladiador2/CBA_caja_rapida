// <fileinfo name="DETALLES_PERSONALIZADOSCollection_Base.cs">
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
	/// The base class for <see cref="DETALLES_PERSONALIZADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DETALLES_PERSONALIZADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DETALLES_PERSONALIZADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_DETALLE_PERSONALIZADO_IDColumnName = "TIPO_DETALLE_PERSONALIZADO_ID";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_BORRADO_IDColumnName = "USUARIO_BORRADO_ID";
		public const string FECHA_BORRADOColumnName = "FECHA_BORRADO";
		public const string ESTADOColumnName = "ESTADO";
		public const string TABLA_IDColumnName = "TABLA_ID";
		public const string COLUMNAColumnName = "COLUMNA";
		public const string REGISTRO_IDColumnName = "REGISTRO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DETALLES_PERSONALIZADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DETALLES_PERSONALIZADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DETALLES_PERSONALIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DETALLES_PERSONALIZADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DETALLES_PERSONALIZADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public DETALLES_PERSONALIZADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DETALLES_PERSONALIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DETALLES_PERSONALIZADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DETALLES_PERSONALIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DETALLES_PERSONALIZADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DETALLES_PERSONALIZADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOSRow[] GetByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id)
		{
			return MapRecords(CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_DETALLE_PERSONALIZADO_IDAsDataTable(decimal tipo_detalle_personalizado_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_DETALLE_PERSONALIZADO_IDCommand(decimal tipo_detalle_personalizado_id)
		{
			string whereSql = "";
			whereSql += "TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", tipo_detalle_personalizado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public DETALLES_PERSONALIZADOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOSRow[] GetByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id)
		{
			return GetByUSUARIO_BORRADO_IDAsDataTable(usuario_borrado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_BORRADO_IDAsDataTable(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_USER_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOSRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_USER_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_USER_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOSRow"/> object to be inserted.</param>
		public virtual void Insert(DETALLES_PERSONALIZADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DETALLES_PERSONALIZADOS (" +
				"ID, " +
				"TIPO_DETALLE_PERSONALIZADO_ID, " +
				"USUARIO_CREACION_ID, " +
				"FECHA_CREACION, " +
				"USUARIO_BORRADO_ID, " +
				"FECHA_BORRADO, " +
				"ESTADO, " +
				"TABLA_ID, " +
				"COLUMNA, " +
				"REGISTRO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("TABLA_ID") + ", " +
				_db.CreateSqlParameterName("COLUMNA") + ", " +
				_db.CreateSqlParameterName("REGISTRO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", value.TIPO_DETALLE_PERSONALIZADO_ID);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "COLUMNA", value.COLUMNA);
			AddParameter(cmd, "REGISTRO_ID", value.REGISTRO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DETALLES_PERSONALIZADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.DETALLES_PERSONALIZADOS SET " +
				"TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID") + ", " +
				"FECHA_BORRADO=" + _db.CreateSqlParameterName("FECHA_BORRADO") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"TABLA_ID=" + _db.CreateSqlParameterName("TABLA_ID") + ", " +
				"COLUMNA=" + _db.CreateSqlParameterName("COLUMNA") + ", " +
				"REGISTRO_ID=" + _db.CreateSqlParameterName("REGISTRO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", value.TIPO_DETALLE_PERSONALIZADO_ID);
			AddParameter(cmd, "USUARIO_CREACION_ID", value.USUARIO_CREACION_ID);
			AddParameter(cmd, "FECHA_CREACION", value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_BORRADO_ID",
				value.IsUSUARIO_BORRADO_IDNull ? DBNull.Value : (object)value.USUARIO_BORRADO_ID);
			AddParameter(cmd, "FECHA_BORRADO",
				value.IsFECHA_BORRADONull ? DBNull.Value : (object)value.FECHA_BORRADO);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "TABLA_ID", value.TABLA_ID);
			AddParameter(cmd, "COLUMNA", value.COLUMNA);
			AddParameter(cmd, "REGISTRO_ID", value.REGISTRO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DETALLES_PERSONALIZADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DETALLES_PERSONALIZADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DETALLES_PERSONALIZADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DETALLES_PERSONALIZADOS</c> table using
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
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS</c> table using the 
		/// <c>FK_DETALLES_PERS_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_DETALLE_PERSONALIZADO_ID(decimal tipo_detalle_personalizado_id)
		{
			return CreateDeleteByTIPO_DETALLE_PERSONALIZADO_IDCommand(tipo_detalle_personalizado_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_TIPO_DET</c> foreign key.
		/// </summary>
		/// <param name="tipo_detalle_personalizado_id">The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_DETALLE_PERSONALIZADO_IDCommand(decimal tipo_detalle_personalizado_id)
		{
			string whereSql = "";
			whereSql += "TIPO_DETALLE_PERSONALIZADO_ID=" + _db.CreateSqlParameterName("TIPO_DETALLE_PERSONALIZADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TIPO_DETALLE_PERSONALIZADO_ID", tipo_detalle_personalizado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS</c> table using the 
		/// <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id)
		{
			return DeleteByUSUARIO_BORRADO_ID(usuario_borrado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS</c> table using the 
		/// <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_BORRADO_ID(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			return CreateDeleteByUSUARIO_BORRADO_IDCommand(usuario_borrado_id, usuario_borrado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_USER_BORR_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_borrado_id">The <c>USUARIO_BORRADO_ID</c> column value.</param>
		/// <param name="usuario_borrado_idNull">true if the method ignores the usuario_borrado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_BORRADO_IDCommand(decimal usuario_borrado_id, bool usuario_borrado_idNull)
		{
			string whereSql = "";
			if(usuario_borrado_idNull)
				whereSql += "USUARIO_BORRADO_ID IS NULL";
			else
				whereSql += "USUARIO_BORRADO_ID=" + _db.CreateSqlParameterName("USUARIO_BORRADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_borrado_idNull)
				AddParameter(cmd, "USUARIO_BORRADO_ID", usuario_borrado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS</c> table using the 
		/// <c>FK_DETALLES_PERS_USER_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_USER_CREAC_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DETALLES_PERSONALIZADOS</c> records that match the specified criteria.
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
		/// to delete <c>DETALLES_PERSONALIZADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DETALLES_PERSONALIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DETALLES_PERSONALIZADOS</c> table.
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		protected DETALLES_PERSONALIZADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		protected DETALLES_PERSONALIZADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		protected virtual DETALLES_PERSONALIZADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_detalle_personalizado_idColumnIndex = reader.GetOrdinal("TIPO_DETALLE_PERSONALIZADO_ID");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_borrado_idColumnIndex = reader.GetOrdinal("USUARIO_BORRADO_ID");
			int fecha_borradoColumnIndex = reader.GetOrdinal("FECHA_BORRADO");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int tabla_idColumnIndex = reader.GetOrdinal("TABLA_ID");
			int columnaColumnIndex = reader.GetOrdinal("COLUMNA");
			int registro_idColumnIndex = reader.GetOrdinal("REGISTRO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DETALLES_PERSONALIZADOSRow record = new DETALLES_PERSONALIZADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_DETALLE_PERSONALIZADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_detalle_personalizado_idColumnIndex)), 9);
					record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(usuario_borrado_idColumnIndex))
						record.USUARIO_BORRADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_borrado_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_borradoColumnIndex))
						record.FECHA_BORRADO = Convert.ToDateTime(reader.GetValue(fecha_borradoColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.TABLA_ID = Convert.ToString(reader.GetValue(tabla_idColumnIndex));
					record.COLUMNA = Convert.ToString(reader.GetValue(columnaColumnIndex));
					record.REGISTRO_ID = Convert.ToString(reader.GetValue(registro_idColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DETALLES_PERSONALIZADOSRow[])(recordList.ToArray(typeof(DETALLES_PERSONALIZADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DETALLES_PERSONALIZADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DETALLES_PERSONALIZADOSRow"/> object.</returns>
		protected virtual DETALLES_PERSONALIZADOSRow MapRow(DataRow row)
		{
			DETALLES_PERSONALIZADOSRow mappedObject = new DETALLES_PERSONALIZADOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_DETALLE_PERSONALIZADO_ID"
			dataColumn = dataTable.Columns["TIPO_DETALLE_PERSONALIZADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DETALLE_PERSONALIZADO_ID = (decimal)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_BORRADO_ID"
			dataColumn = dataTable.Columns["USUARIO_BORRADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_BORRADO_ID = (decimal)row[dataColumn];
			// Column "FECHA_BORRADO"
			dataColumn = dataTable.Columns["FECHA_BORRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_BORRADO = (System.DateTime)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "TABLA_ID"
			dataColumn = dataTable.Columns["TABLA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TABLA_ID = (string)row[dataColumn];
			// Column "COLUMNA"
			dataColumn = dataTable.Columns["COLUMNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLUMNA = (string)row[dataColumn];
			// Column "REGISTRO_ID"
			dataColumn = dataTable.Columns["REGISTRO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REGISTRO_ID = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DETALLES_PERSONALIZADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_DETALLE_PERSONALIZADO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_BORRADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_BORRADO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TABLA_ID", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COLUMNA", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REGISTRO_ID", typeof(string));
			dataColumn.MaxLength = 300;
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

				case "TIPO_DETALLE_PERSONALIZADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_BORRADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_BORRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TABLA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COLUMNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REGISTRO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DETALLES_PERSONALIZADOSCollection_Base class
}  // End of namespace
