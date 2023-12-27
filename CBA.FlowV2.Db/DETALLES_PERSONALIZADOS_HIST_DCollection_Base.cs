// <fileinfo name="DETALLES_PERSONALIZADOS_HIST_DCollection_Base.cs">
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
	/// The base class for <see cref="DETALLES_PERSONALIZADOS_HIST_DCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DETALLES_PERSONALIZADOS_HIST_DCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DETALLES_PERSONALIZADOS_HIST_DCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string DETALLE_PERSONALIZADO_HIST_IDColumnName = "DETALLE_PERSONALIZADO_HIST_ID";
		public const string VALOR_NUMEROColumnName = "VALOR_NUMERO";
		public const string VALOR_FECHAColumnName = "VALOR_FECHA";
		public const string VALOR_TEXTOColumnName = "VALOR_TEXTO";
		public const string ORDENColumnName = "ORDEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOS_HIST_DCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DETALLES_PERSONALIZADOS_HIST_DCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HIST_DRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DETALLES_PERSONALIZADOS_HIST_DRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DETALLES_PERSONALIZADOS_HIST_DRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects.</returns>
		public DETALLES_PERSONALIZADOS_HIST_DRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects that 
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HIST_DRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DETALLES_PERSONALIZADOS_HIST_D";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DETALLES_PERSONALIZADOS_HIST_DRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DETALLES_PERSONALIZADOS_HIST_DRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects 
		/// by the <c>FK_DETALLES_PERS_HIST_DET_D</c> foreign key.
		/// </summary>
		/// <param name="detalle_personalizado_hist_id">The <c>DETALLE_PERSONALIZADO_HIST_ID</c> column value.</param>
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects.</returns>
		public virtual DETALLES_PERSONALIZADOS_HIST_DRow[] GetByDETALLE_PERSONALIZADO_HIST_ID(decimal detalle_personalizado_hist_id)
		{
			return MapRecords(CreateGetByDETALLE_PERSONALIZADO_HIST_IDCommand(detalle_personalizado_hist_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DETALLES_PERS_HIST_DET_D</c> foreign key.
		/// </summary>
		/// <param name="detalle_personalizado_hist_id">The <c>DETALLE_PERSONALIZADO_HIST_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDETALLE_PERSONALIZADO_HIST_IDAsDataTable(decimal detalle_personalizado_hist_id)
		{
			return MapRecordsToDataTable(CreateGetByDETALLE_PERSONALIZADO_HIST_IDCommand(detalle_personalizado_hist_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DETALLES_PERS_HIST_DET_D</c> foreign key.
		/// </summary>
		/// <param name="detalle_personalizado_hist_id">The <c>DETALLE_PERSONALIZADO_HIST_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDETALLE_PERSONALIZADO_HIST_IDCommand(decimal detalle_personalizado_hist_id)
		{
			string whereSql = "";
			whereSql += "DETALLE_PERSONALIZADO_HIST_ID=" + _db.CreateSqlParameterName("DETALLE_PERSONALIZADO_HIST_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DETALLE_PERSONALIZADO_HIST_ID", detalle_personalizado_hist_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> object to be inserted.</param>
		public virtual void Insert(DETALLES_PERSONALIZADOS_HIST_DRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DETALLES_PERSONALIZADOS_HIST_D (" +
				"ID, " +
				"DETALLE_PERSONALIZADO_HIST_ID, " +
				"VALOR_NUMERO, " +
				"VALOR_FECHA, " +
				"VALOR_TEXTO, " +
				"ORDEN" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("DETALLE_PERSONALIZADO_HIST_ID") + ", " +
				_db.CreateSqlParameterName("VALOR_NUMERO") + ", " +
				_db.CreateSqlParameterName("VALOR_FECHA") + ", " +
				_db.CreateSqlParameterName("VALOR_TEXTO") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "DETALLE_PERSONALIZADO_HIST_ID", value.DETALLE_PERSONALIZADO_HIST_ID);
			AddParameter(cmd, "VALOR_NUMERO",
				value.IsVALOR_NUMERONull ? DBNull.Value : (object)value.VALOR_NUMERO);
			AddParameter(cmd, "VALOR_FECHA",
				value.IsVALOR_FECHANull ? DBNull.Value : (object)value.VALOR_FECHA);
			AddParameter(cmd, "VALOR_TEXTO", value.VALOR_TEXTO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DETALLES_PERSONALIZADOS_HIST_DRow value)
		{
			
			string sqlStr = "UPDATE TRC.DETALLES_PERSONALIZADOS_HIST_D SET " +
				"DETALLE_PERSONALIZADO_HIST_ID=" + _db.CreateSqlParameterName("DETALLE_PERSONALIZADO_HIST_ID") + ", " +
				"VALOR_NUMERO=" + _db.CreateSqlParameterName("VALOR_NUMERO") + ", " +
				"VALOR_FECHA=" + _db.CreateSqlParameterName("VALOR_FECHA") + ", " +
				"VALOR_TEXTO=" + _db.CreateSqlParameterName("VALOR_TEXTO") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "DETALLE_PERSONALIZADO_HIST_ID", value.DETALLE_PERSONALIZADO_HIST_ID);
			AddParameter(cmd, "VALOR_NUMERO",
				value.IsVALOR_NUMERONull ? DBNull.Value : (object)value.VALOR_NUMERO);
			AddParameter(cmd, "VALOR_FECHA",
				value.IsVALOR_FECHANull ? DBNull.Value : (object)value.VALOR_FECHA);
			AddParameter(cmd, "VALOR_TEXTO", value.VALOR_TEXTO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DETALLES_PERSONALIZADOS_HIST_DRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table using
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
		/// Deletes records from the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table using the 
		/// <c>FK_DETALLES_PERS_HIST_DET_D</c> foreign key.
		/// </summary>
		/// <param name="detalle_personalizado_hist_id">The <c>DETALLE_PERSONALIZADO_HIST_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDETALLE_PERSONALIZADO_HIST_ID(decimal detalle_personalizado_hist_id)
		{
			return CreateDeleteByDETALLE_PERSONALIZADO_HIST_IDCommand(detalle_personalizado_hist_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DETALLES_PERS_HIST_DET_D</c> foreign key.
		/// </summary>
		/// <param name="detalle_personalizado_hist_id">The <c>DETALLE_PERSONALIZADO_HIST_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDETALLE_PERSONALIZADO_HIST_IDCommand(decimal detalle_personalizado_hist_id)
		{
			string whereSql = "";
			whereSql += "DETALLE_PERSONALIZADO_HIST_ID=" + _db.CreateSqlParameterName("DETALLE_PERSONALIZADO_HIST_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DETALLE_PERSONALIZADO_HIST_ID", detalle_personalizado_hist_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DETALLES_PERSONALIZADOS_HIST_D</c> records that match the specified criteria.
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
		/// to delete <c>DETALLES_PERSONALIZADOS_HIST_D</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DETALLES_PERSONALIZADOS_HIST_D";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects.</returns>
		protected DETALLES_PERSONALIZADOS_HIST_DRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects.</returns>
		protected DETALLES_PERSONALIZADOS_HIST_DRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> objects.</returns>
		protected virtual DETALLES_PERSONALIZADOS_HIST_DRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int detalle_personalizado_hist_idColumnIndex = reader.GetOrdinal("DETALLE_PERSONALIZADO_HIST_ID");
			int valor_numeroColumnIndex = reader.GetOrdinal("VALOR_NUMERO");
			int valor_fechaColumnIndex = reader.GetOrdinal("VALOR_FECHA");
			int valor_textoColumnIndex = reader.GetOrdinal("VALOR_TEXTO");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DETALLES_PERSONALIZADOS_HIST_DRow record = new DETALLES_PERSONALIZADOS_HIST_DRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.DETALLE_PERSONALIZADO_HIST_ID = Math.Round(Convert.ToDecimal(reader.GetValue(detalle_personalizado_hist_idColumnIndex)), 9);
					if(!reader.IsDBNull(valor_numeroColumnIndex))
						record.VALOR_NUMERO = Math.Round(Convert.ToDecimal(reader.GetValue(valor_numeroColumnIndex)), 9);
					if(!reader.IsDBNull(valor_fechaColumnIndex))
						record.VALOR_FECHA = Convert.ToDateTime(reader.GetValue(valor_fechaColumnIndex));
					if(!reader.IsDBNull(valor_textoColumnIndex))
						record.VALOR_TEXTO = Convert.ToString(reader.GetValue(valor_textoColumnIndex));
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DETALLES_PERSONALIZADOS_HIST_DRow[])(recordList.ToArray(typeof(DETALLES_PERSONALIZADOS_HIST_DRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DETALLES_PERSONALIZADOS_HIST_DRow"/> object.</returns>
		protected virtual DETALLES_PERSONALIZADOS_HIST_DRow MapRow(DataRow row)
		{
			DETALLES_PERSONALIZADOS_HIST_DRow mappedObject = new DETALLES_PERSONALIZADOS_HIST_DRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "DETALLE_PERSONALIZADO_HIST_ID"
			dataColumn = dataTable.Columns["DETALLE_PERSONALIZADO_HIST_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DETALLE_PERSONALIZADO_HIST_ID = (decimal)row[dataColumn];
			// Column "VALOR_NUMERO"
			dataColumn = dataTable.Columns["VALOR_NUMERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_NUMERO = (decimal)row[dataColumn];
			// Column "VALOR_FECHA"
			dataColumn = dataTable.Columns["VALOR_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_FECHA = (System.DateTime)row[dataColumn];
			// Column "VALOR_TEXTO"
			dataColumn = dataTable.Columns["VALOR_TEXTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_TEXTO = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DETALLES_PERSONALIZADOS_HIST_D</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DETALLES_PERSONALIZADOS_HIST_D";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DETALLE_PERSONALIZADO_HIST_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VALOR_NUMERO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("VALOR_TEXTO", typeof(string));
			dataColumn.MaxLength = 1000;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
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

				case "DETALLE_PERSONALIZADO_HIST_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_NUMERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VALOR_TEXTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DETALLES_PERSONALIZADOS_HIST_DCollection_Base class
}  // End of namespace
