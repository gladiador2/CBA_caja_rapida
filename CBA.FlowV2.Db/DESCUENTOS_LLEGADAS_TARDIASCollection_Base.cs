// <fileinfo name="DESCUENTOS_LLEGADAS_TARDIASCollection_Base.cs">
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
	/// The base class for <see cref="DESCUENTOS_LLEGADAS_TARDIASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DESCUENTOS_LLEGADAS_TARDIASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DESCUENTOS_LLEGADAS_TARDIASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_REGLAColumnName = "TIPO_REGLA";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string ESTADOColumnName = "ESTADO";
		public const string HORARIO_IDColumnName = "HORARIO_ID";
		public const string APLICAR_TOLERANCIAColumnName = "APLICAR_TOLERANCIA";
		public const string APLICAR_DESC_MONTO_FIJOColumnName = "APLICAR_DESC_MONTO_FIJO";
		public const string ORDENColumnName = "ORDEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DESCUENTOS_LLEGADAS_TARDIASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DESCUENTOS_LLEGADAS_TARDIASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects.</returns>
		public virtual DESCUENTOS_LLEGADAS_TARDIASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DESCUENTOS_LLEGADAS_TARDIASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DESCUENTOS_LLEGADAS_TARDIASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects.</returns>
		public DESCUENTOS_LLEGADAS_TARDIASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects that 
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
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects.</returns>
		public virtual DESCUENTOS_LLEGADAS_TARDIASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DESCUENTOS_LLEGADAS_TARDIAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DESCUENTOS_LLEGADAS_TARDIASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DESCUENTOS_LLEGADAS_TARDIASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects 
		/// by the <c>FK_DESCUENTOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects.</returns>
		public virtual DESCUENTOS_LLEGADAS_TARDIASRow[] GetByHORARIO_ID(decimal horario_id)
		{
			return MapRecords(CreateGetByHORARIO_IDCommand(horario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DESCUENTOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByHORARIO_IDAsDataTable(decimal horario_id)
		{
			return MapRecordsToDataTable(CreateGetByHORARIO_IDCommand(horario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DESCUENTOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByHORARIO_IDCommand(decimal horario_id)
		{
			string whereSql = "";
			whereSql += "HORARIO_ID=" + _db.CreateSqlParameterName("HORARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "HORARIO_ID", horario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> object to be inserted.</param>
		public virtual void Insert(DESCUENTOS_LLEGADAS_TARDIASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DESCUENTOS_LLEGADAS_TARDIAS (" +
				"ID, " +
				"TIPO_REGLA, " +
				"DESCRIPCION, " +
				"ESTADO, " +
				"HORARIO_ID, " +
				"APLICAR_TOLERANCIA, " +
				"APLICAR_DESC_MONTO_FIJO, " +
				"ORDEN" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_REGLA") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("HORARIO_ID") + ", " +
				_db.CreateSqlParameterName("APLICAR_TOLERANCIA") + ", " +
				_db.CreateSqlParameterName("APLICAR_DESC_MONTO_FIJO") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_REGLA", value.TIPO_REGLA);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "HORARIO_ID", value.HORARIO_ID);
			AddParameter(cmd, "APLICAR_TOLERANCIA", value.APLICAR_TOLERANCIA);
			AddParameter(cmd, "APLICAR_DESC_MONTO_FIJO", value.APLICAR_DESC_MONTO_FIJO);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DESCUENTOS_LLEGADAS_TARDIASRow value)
		{
			
			string sqlStr = "UPDATE TRC.DESCUENTOS_LLEGADAS_TARDIAS SET " +
				"TIPO_REGLA=" + _db.CreateSqlParameterName("TIPO_REGLA") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"HORARIO_ID=" + _db.CreateSqlParameterName("HORARIO_ID") + ", " +
				"APLICAR_TOLERANCIA=" + _db.CreateSqlParameterName("APLICAR_TOLERANCIA") + ", " +
				"APLICAR_DESC_MONTO_FIJO=" + _db.CreateSqlParameterName("APLICAR_DESC_MONTO_FIJO") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_REGLA", value.TIPO_REGLA);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "HORARIO_ID", value.HORARIO_ID);
			AddParameter(cmd, "APLICAR_TOLERANCIA", value.APLICAR_TOLERANCIA);
			AddParameter(cmd, "APLICAR_DESC_MONTO_FIJO", value.APLICAR_DESC_MONTO_FIJO);
			AddParameter(cmd, "ORDEN",
				value.IsORDENNull ? DBNull.Value : (object)value.ORDEN);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DESCUENTOS_LLEGADAS_TARDIASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table using
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
		/// Deletes records from the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table using the 
		/// <c>FK_DESCUENTOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByHORARIO_ID(decimal horario_id)
		{
			return CreateDeleteByHORARIO_IDCommand(horario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DESCUENTOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByHORARIO_IDCommand(decimal horario_id)
		{
			string whereSql = "";
			whereSql += "HORARIO_ID=" + _db.CreateSqlParameterName("HORARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "HORARIO_ID", horario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DESCUENTOS_LLEGADAS_TARDIAS</c> records that match the specified criteria.
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
		/// to delete <c>DESCUENTOS_LLEGADAS_TARDIAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DESCUENTOS_LLEGADAS_TARDIAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
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
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects.</returns>
		protected DESCUENTOS_LLEGADAS_TARDIASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects.</returns>
		protected DESCUENTOS_LLEGADAS_TARDIASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> objects.</returns>
		protected virtual DESCUENTOS_LLEGADAS_TARDIASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_reglaColumnIndex = reader.GetOrdinal("TIPO_REGLA");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int horario_idColumnIndex = reader.GetOrdinal("HORARIO_ID");
			int aplicar_toleranciaColumnIndex = reader.GetOrdinal("APLICAR_TOLERANCIA");
			int aplicar_desc_monto_fijoColumnIndex = reader.GetOrdinal("APLICAR_DESC_MONTO_FIJO");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DESCUENTOS_LLEGADAS_TARDIASRow record = new DESCUENTOS_LLEGADAS_TARDIASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_REGLA = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_reglaColumnIndex)), 9);
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.HORARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(horario_idColumnIndex)), 9);
					record.APLICAR_TOLERANCIA = Convert.ToString(reader.GetValue(aplicar_toleranciaColumnIndex));
					record.APLICAR_DESC_MONTO_FIJO = Convert.ToString(reader.GetValue(aplicar_desc_monto_fijoColumnIndex));
					if(!reader.IsDBNull(ordenColumnIndex))
						record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DESCUENTOS_LLEGADAS_TARDIASRow[])(recordList.ToArray(typeof(DESCUENTOS_LLEGADAS_TARDIASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DESCUENTOS_LLEGADAS_TARDIASRow"/> object.</returns>
		protected virtual DESCUENTOS_LLEGADAS_TARDIASRow MapRow(DataRow row)
		{
			DESCUENTOS_LLEGADAS_TARDIASRow mappedObject = new DESCUENTOS_LLEGADAS_TARDIASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_REGLA"
			dataColumn = dataTable.Columns["TIPO_REGLA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_REGLA = (decimal)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "HORARIO_ID"
			dataColumn = dataTable.Columns["HORARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORARIO_ID = (decimal)row[dataColumn];
			// Column "APLICAR_TOLERANCIA"
			dataColumn = dataTable.Columns["APLICAR_TOLERANCIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICAR_TOLERANCIA = (string)row[dataColumn];
			// Column "APLICAR_DESC_MONTO_FIJO"
			dataColumn = dataTable.Columns["APLICAR_DESC_MONTO_FIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICAR_DESC_MONTO_FIJO = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DESCUENTOS_LLEGADAS_TARDIAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DESCUENTOS_LLEGADAS_TARDIAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_REGLA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 80;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HORARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APLICAR_TOLERANCIA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("APLICAR_DESC_MONTO_FIJO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
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

				case "TIPO_REGLA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "HORARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICAR_TOLERANCIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "APLICAR_DESC_MONTO_FIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DESCUENTOS_LLEGADAS_TARDIASCollection_Base class
}  // End of namespace
