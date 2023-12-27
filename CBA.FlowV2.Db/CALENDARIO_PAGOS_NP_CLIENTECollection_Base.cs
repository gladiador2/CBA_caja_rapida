// <fileinfo name="CALENDARIO_PAGOS_NP_CLIENTECollection_Base.cs">
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
	/// The base class for <see cref="CALENDARIO_PAGOS_NP_CLIENTECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CALENDARIO_PAGOS_NP_CLIENTECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CALENDARIO_PAGOS_NP_CLIENTECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOTA_PEDIDO_CLIENTE_IDColumnName = "NOTA_PEDIDO_CLIENTE_ID";
		public const string MONTO_CAPITALColumnName = "MONTO_CAPITAL";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string MONTO_INTERESColumnName = "MONTO_INTERES";
		public const string NUMERO_CUOTAColumnName = "NUMERO_CUOTA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CALENDARIO_PAGOS_NP_CLIENTECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CALENDARIO_PAGOS_NP_CLIENTECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_NP_CLIENTERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CALENDARIO_PAGOS_NP_CLIENTERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CALENDARIO_PAGOS_NP_CLIENTERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects.</returns>
		public CALENDARIO_PAGOS_NP_CLIENTERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects that 
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_NP_CLIENTERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CALENDARIO_PAGOS_NP_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CALENDARIO_PAGOS_NP_CLIENTERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CALENDARIO_PAGOS_NP_CLIENTERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects 
		/// by the <c>FK_CALENDARIO_PAGOS_NP_NP</c> foreign key.
		/// </summary>
		/// <param name="nota_pedido_cliente_id">The <c>NOTA_PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects.</returns>
		public virtual CALENDARIO_PAGOS_NP_CLIENTERow[] GetByNOTA_PEDIDO_CLIENTE_ID(decimal nota_pedido_cliente_id)
		{
			return MapRecords(CreateGetByNOTA_PEDIDO_CLIENTE_IDCommand(nota_pedido_cliente_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CALENDARIO_PAGOS_NP_NP</c> foreign key.
		/// </summary>
		/// <param name="nota_pedido_cliente_id">The <c>NOTA_PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNOTA_PEDIDO_CLIENTE_IDAsDataTable(decimal nota_pedido_cliente_id)
		{
			return MapRecordsToDataTable(CreateGetByNOTA_PEDIDO_CLIENTE_IDCommand(nota_pedido_cliente_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CALENDARIO_PAGOS_NP_NP</c> foreign key.
		/// </summary>
		/// <param name="nota_pedido_cliente_id">The <c>NOTA_PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNOTA_PEDIDO_CLIENTE_IDCommand(decimal nota_pedido_cliente_id)
		{
			string whereSql = "";
			whereSql += "NOTA_PEDIDO_CLIENTE_ID=" + _db.CreateSqlParameterName("NOTA_PEDIDO_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "NOTA_PEDIDO_CLIENTE_ID", nota_pedido_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> object to be inserted.</param>
		public virtual void Insert(CALENDARIO_PAGOS_NP_CLIENTERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CALENDARIO_PAGOS_NP_CLIENTE (" +
				"ID, " +
				"NOTA_PEDIDO_CLIENTE_ID, " +
				"MONTO_CAPITAL, " +
				"FECHA_VENCIMIENTO, " +
				"MONTO_INTERES, " +
				"NUMERO_CUOTA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOTA_PEDIDO_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				_db.CreateSqlParameterName("NUMERO_CUOTA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOTA_PEDIDO_CLIENTE_ID", value.NOTA_PEDIDO_CLIENTE_ID);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "MONTO_INTERES", value.MONTO_INTERES);
			AddParameter(cmd, "NUMERO_CUOTA", value.NUMERO_CUOTA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CALENDARIO_PAGOS_NP_CLIENTERow value)
		{
			
			string sqlStr = "UPDATE TRC.CALENDARIO_PAGOS_NP_CLIENTE SET " +
				"NOTA_PEDIDO_CLIENTE_ID=" + _db.CreateSqlParameterName("NOTA_PEDIDO_CLIENTE_ID") + ", " +
				"MONTO_CAPITAL=" + _db.CreateSqlParameterName("MONTO_CAPITAL") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"MONTO_INTERES=" + _db.CreateSqlParameterName("MONTO_INTERES") + ", " +
				"NUMERO_CUOTA=" + _db.CreateSqlParameterName("NUMERO_CUOTA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOTA_PEDIDO_CLIENTE_ID", value.NOTA_PEDIDO_CLIENTE_ID);
			AddParameter(cmd, "MONTO_CAPITAL", value.MONTO_CAPITAL);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "MONTO_INTERES", value.MONTO_INTERES);
			AddParameter(cmd, "NUMERO_CUOTA", value.NUMERO_CUOTA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CALENDARIO_PAGOS_NP_CLIENTERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table using
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
		/// Deletes records from the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table using the 
		/// <c>FK_CALENDARIO_PAGOS_NP_NP</c> foreign key.
		/// </summary>
		/// <param name="nota_pedido_cliente_id">The <c>NOTA_PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNOTA_PEDIDO_CLIENTE_ID(decimal nota_pedido_cliente_id)
		{
			return CreateDeleteByNOTA_PEDIDO_CLIENTE_IDCommand(nota_pedido_cliente_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CALENDARIO_PAGOS_NP_NP</c> foreign key.
		/// </summary>
		/// <param name="nota_pedido_cliente_id">The <c>NOTA_PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNOTA_PEDIDO_CLIENTE_IDCommand(decimal nota_pedido_cliente_id)
		{
			string whereSql = "";
			whereSql += "NOTA_PEDIDO_CLIENTE_ID=" + _db.CreateSqlParameterName("NOTA_PEDIDO_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "NOTA_PEDIDO_CLIENTE_ID", nota_pedido_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CALENDARIO_PAGOS_NP_CLIENTE</c> records that match the specified criteria.
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
		/// to delete <c>CALENDARIO_PAGOS_NP_CLIENTE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CALENDARIO_PAGOS_NP_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects.</returns>
		protected CALENDARIO_PAGOS_NP_CLIENTERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects.</returns>
		protected CALENDARIO_PAGOS_NP_CLIENTERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> objects.</returns>
		protected virtual CALENDARIO_PAGOS_NP_CLIENTERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nota_pedido_cliente_idColumnIndex = reader.GetOrdinal("NOTA_PEDIDO_CLIENTE_ID");
			int monto_capitalColumnIndex = reader.GetOrdinal("MONTO_CAPITAL");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int monto_interesColumnIndex = reader.GetOrdinal("MONTO_INTERES");
			int numero_cuotaColumnIndex = reader.GetOrdinal("NUMERO_CUOTA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CALENDARIO_PAGOS_NP_CLIENTERow record = new CALENDARIO_PAGOS_NP_CLIENTERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOTA_PEDIDO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nota_pedido_cliente_idColumnIndex)), 9);
					record.MONTO_CAPITAL = Math.Round(Convert.ToDecimal(reader.GetValue(monto_capitalColumnIndex)), 9);
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					record.MONTO_INTERES = Math.Round(Convert.ToDecimal(reader.GetValue(monto_interesColumnIndex)), 9);
					record.NUMERO_CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(numero_cuotaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CALENDARIO_PAGOS_NP_CLIENTERow[])(recordList.ToArray(typeof(CALENDARIO_PAGOS_NP_CLIENTERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CALENDARIO_PAGOS_NP_CLIENTERow"/> object.</returns>
		protected virtual CALENDARIO_PAGOS_NP_CLIENTERow MapRow(DataRow row)
		{
			CALENDARIO_PAGOS_NP_CLIENTERow mappedObject = new CALENDARIO_PAGOS_NP_CLIENTERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "NOTA_PEDIDO_CLIENTE_ID"
			dataColumn = dataTable.Columns["NOTA_PEDIDO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOTA_PEDIDO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "MONTO_CAPITAL"
			dataColumn = dataTable.Columns["MONTO_CAPITAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_CAPITAL = (decimal)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "MONTO_INTERES"
			dataColumn = dataTable.Columns["MONTO_INTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_INTERES = (decimal)row[dataColumn];
			// Column "NUMERO_CUOTA"
			dataColumn = dataTable.Columns["NUMERO_CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CUOTA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CALENDARIO_PAGOS_NP_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CALENDARIO_PAGOS_NP_CLIENTE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOTA_PEDIDO_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_CAPITAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_INTERES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NUMERO_CUOTA", typeof(decimal));
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

				case "NOTA_PEDIDO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_CAPITAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONTO_INTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CALENDARIO_PAGOS_NP_CLIENTECollection_Base class
}  // End of namespace
