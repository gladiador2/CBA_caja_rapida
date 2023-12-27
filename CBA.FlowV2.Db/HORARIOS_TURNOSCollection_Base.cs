// <fileinfo name="HORARIOS_TURNOSCollection_Base.cs">
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
	/// The base class for <see cref="HORARIOS_TURNOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="HORARIOS_TURNOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOS_TURNOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string HORARIO_IDColumnName = "HORARIO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string HORA_INICIOColumnName = "HORA_INICIO";
		public const string HORA_FINColumnName = "HORA_FIN";
		public const string MINUTOS_ANTES_ENTRADAColumnName = "MINUTOS_ANTES_ENTRADA";
		public const string MINUTOS_ANTES_SALIDAColumnName = "MINUTOS_ANTES_SALIDA";
		public const string MINUTOS_DESPUES_ENTRADAColumnName = "MINUTOS_DESPUES_ENTRADA";
		public const string MINUTOS_DESPUES_SALIDAColumnName = "MINUTOS_DESPUES_SALIDA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_TURNOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public HORARIOS_TURNOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>HORARIOS_TURNOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="HORARIOS_TURNOSRow"/> objects.</returns>
		public virtual HORARIOS_TURNOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>HORARIOS_TURNOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>HORARIOS_TURNOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="HORARIOS_TURNOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="HORARIOS_TURNOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public HORARIOS_TURNOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			HORARIOS_TURNOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_TURNOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="HORARIOS_TURNOSRow"/> objects.</returns>
		public HORARIOS_TURNOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_TURNOSRow"/> objects that 
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
		/// <returns>An array of <see cref="HORARIOS_TURNOSRow"/> objects.</returns>
		public virtual HORARIOS_TURNOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.HORARIOS_TURNOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="HORARIOS_TURNOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="HORARIOS_TURNOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual HORARIOS_TURNOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			HORARIOS_TURNOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="HORARIOS_TURNOSRow"/> objects 
		/// by the <c>FK_HORARIOS_TURNOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="HORARIOS_TURNOSRow"/> objects.</returns>
		public virtual HORARIOS_TURNOSRow[] GetByHORARIO_ID(decimal horario_id)
		{
			return MapRecords(CreateGetByHORARIO_IDCommand(horario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_HORARIOS_TURNOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByHORARIO_IDAsDataTable(decimal horario_id)
		{
			return MapRecordsToDataTable(CreateGetByHORARIO_IDCommand(horario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_HORARIOS_TURNOS_HORARIOS</c> foreign key.
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
		/// Adds a new record into the <c>HORARIOS_TURNOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HORARIOS_TURNOSRow"/> object to be inserted.</param>
		public virtual void Insert(HORARIOS_TURNOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.HORARIOS_TURNOS (" +
				"ID, " +
				"HORARIO_ID, " +
				"NOMBRE, " +
				"HORA_INICIO, " +
				"HORA_FIN, " +
				"MINUTOS_ANTES_ENTRADA, " +
				"MINUTOS_ANTES_SALIDA, " +
				"MINUTOS_DESPUES_ENTRADA, " +
				"MINUTOS_DESPUES_SALIDA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("HORARIO_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("HORA_INICIO") + ", " +
				_db.CreateSqlParameterName("HORA_FIN") + ", " +
				_db.CreateSqlParameterName("MINUTOS_ANTES_ENTRADA") + ", " +
				_db.CreateSqlParameterName("MINUTOS_ANTES_SALIDA") + ", " +
				_db.CreateSqlParameterName("MINUTOS_DESPUES_ENTRADA") + ", " +
				_db.CreateSqlParameterName("MINUTOS_DESPUES_SALIDA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "HORARIO_ID", value.HORARIO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "HORA_INICIO", value.HORA_INICIO);
			AddParameter(cmd, "HORA_FIN", value.HORA_FIN);
			AddParameter(cmd, "MINUTOS_ANTES_ENTRADA",
				value.IsMINUTOS_ANTES_ENTRADANull ? DBNull.Value : (object)value.MINUTOS_ANTES_ENTRADA);
			AddParameter(cmd, "MINUTOS_ANTES_SALIDA",
				value.IsMINUTOS_ANTES_SALIDANull ? DBNull.Value : (object)value.MINUTOS_ANTES_SALIDA);
			AddParameter(cmd, "MINUTOS_DESPUES_ENTRADA",
				value.IsMINUTOS_DESPUES_ENTRADANull ? DBNull.Value : (object)value.MINUTOS_DESPUES_ENTRADA);
			AddParameter(cmd, "MINUTOS_DESPUES_SALIDA",
				value.IsMINUTOS_DESPUES_SALIDANull ? DBNull.Value : (object)value.MINUTOS_DESPUES_SALIDA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>HORARIOS_TURNOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HORARIOS_TURNOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(HORARIOS_TURNOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.HORARIOS_TURNOS SET " +
				"HORARIO_ID=" + _db.CreateSqlParameterName("HORARIO_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"HORA_INICIO=" + _db.CreateSqlParameterName("HORA_INICIO") + ", " +
				"HORA_FIN=" + _db.CreateSqlParameterName("HORA_FIN") + ", " +
				"MINUTOS_ANTES_ENTRADA=" + _db.CreateSqlParameterName("MINUTOS_ANTES_ENTRADA") + ", " +
				"MINUTOS_ANTES_SALIDA=" + _db.CreateSqlParameterName("MINUTOS_ANTES_SALIDA") + ", " +
				"MINUTOS_DESPUES_ENTRADA=" + _db.CreateSqlParameterName("MINUTOS_DESPUES_ENTRADA") + ", " +
				"MINUTOS_DESPUES_SALIDA=" + _db.CreateSqlParameterName("MINUTOS_DESPUES_SALIDA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "HORARIO_ID", value.HORARIO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "HORA_INICIO", value.HORA_INICIO);
			AddParameter(cmd, "HORA_FIN", value.HORA_FIN);
			AddParameter(cmd, "MINUTOS_ANTES_ENTRADA",
				value.IsMINUTOS_ANTES_ENTRADANull ? DBNull.Value : (object)value.MINUTOS_ANTES_ENTRADA);
			AddParameter(cmd, "MINUTOS_ANTES_SALIDA",
				value.IsMINUTOS_ANTES_SALIDANull ? DBNull.Value : (object)value.MINUTOS_ANTES_SALIDA);
			AddParameter(cmd, "MINUTOS_DESPUES_ENTRADA",
				value.IsMINUTOS_DESPUES_ENTRADANull ? DBNull.Value : (object)value.MINUTOS_DESPUES_ENTRADA);
			AddParameter(cmd, "MINUTOS_DESPUES_SALIDA",
				value.IsMINUTOS_DESPUES_SALIDANull ? DBNull.Value : (object)value.MINUTOS_DESPUES_SALIDA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>HORARIOS_TURNOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>HORARIOS_TURNOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>HORARIOS_TURNOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="HORARIOS_TURNOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(HORARIOS_TURNOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>HORARIOS_TURNOS</c> table using
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
		/// Deletes records from the <c>HORARIOS_TURNOS</c> table using the 
		/// <c>FK_HORARIOS_TURNOS_HORARIOS</c> foreign key.
		/// </summary>
		/// <param name="horario_id">The <c>HORARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByHORARIO_ID(decimal horario_id)
		{
			return CreateDeleteByHORARIO_IDCommand(horario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_HORARIOS_TURNOS_HORARIOS</c> foreign key.
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
		/// Deletes <c>HORARIOS_TURNOS</c> records that match the specified criteria.
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
		/// to delete <c>HORARIOS_TURNOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.HORARIOS_TURNOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>HORARIOS_TURNOS</c> table.
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
		/// <returns>An array of <see cref="HORARIOS_TURNOSRow"/> objects.</returns>
		protected HORARIOS_TURNOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="HORARIOS_TURNOSRow"/> objects.</returns>
		protected HORARIOS_TURNOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="HORARIOS_TURNOSRow"/> objects.</returns>
		protected virtual HORARIOS_TURNOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int horario_idColumnIndex = reader.GetOrdinal("HORARIO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int hora_inicioColumnIndex = reader.GetOrdinal("HORA_INICIO");
			int hora_finColumnIndex = reader.GetOrdinal("HORA_FIN");
			int minutos_antes_entradaColumnIndex = reader.GetOrdinal("MINUTOS_ANTES_ENTRADA");
			int minutos_antes_salidaColumnIndex = reader.GetOrdinal("MINUTOS_ANTES_SALIDA");
			int minutos_despues_entradaColumnIndex = reader.GetOrdinal("MINUTOS_DESPUES_ENTRADA");
			int minutos_despues_salidaColumnIndex = reader.GetOrdinal("MINUTOS_DESPUES_SALIDA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					HORARIOS_TURNOSRow record = new HORARIOS_TURNOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.HORARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(horario_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.HORA_INICIO = Convert.ToDateTime(reader.GetValue(hora_inicioColumnIndex));
					record.HORA_FIN = Convert.ToDateTime(reader.GetValue(hora_finColumnIndex));
					if(!reader.IsDBNull(minutos_antes_entradaColumnIndex))
						record.MINUTOS_ANTES_ENTRADA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_antes_entradaColumnIndex)), 9);
					if(!reader.IsDBNull(minutos_antes_salidaColumnIndex))
						record.MINUTOS_ANTES_SALIDA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_antes_salidaColumnIndex)), 9);
					if(!reader.IsDBNull(minutos_despues_entradaColumnIndex))
						record.MINUTOS_DESPUES_ENTRADA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_despues_entradaColumnIndex)), 9);
					if(!reader.IsDBNull(minutos_despues_salidaColumnIndex))
						record.MINUTOS_DESPUES_SALIDA = Math.Round(Convert.ToDecimal(reader.GetValue(minutos_despues_salidaColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (HORARIOS_TURNOSRow[])(recordList.ToArray(typeof(HORARIOS_TURNOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="HORARIOS_TURNOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="HORARIOS_TURNOSRow"/> object.</returns>
		protected virtual HORARIOS_TURNOSRow MapRow(DataRow row)
		{
			HORARIOS_TURNOSRow mappedObject = new HORARIOS_TURNOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "HORARIO_ID"
			dataColumn = dataTable.Columns["HORARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORARIO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "HORA_INICIO"
			dataColumn = dataTable.Columns["HORA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_INICIO = (System.DateTime)row[dataColumn];
			// Column "HORA_FIN"
			dataColumn = dataTable.Columns["HORA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_FIN = (System.DateTime)row[dataColumn];
			// Column "MINUTOS_ANTES_ENTRADA"
			dataColumn = dataTable.Columns["MINUTOS_ANTES_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_ANTES_ENTRADA = (decimal)row[dataColumn];
			// Column "MINUTOS_ANTES_SALIDA"
			dataColumn = dataTable.Columns["MINUTOS_ANTES_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_ANTES_SALIDA = (decimal)row[dataColumn];
			// Column "MINUTOS_DESPUES_ENTRADA"
			dataColumn = dataTable.Columns["MINUTOS_DESPUES_ENTRADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_DESPUES_ENTRADA = (decimal)row[dataColumn];
			// Column "MINUTOS_DESPUES_SALIDA"
			dataColumn = dataTable.Columns["MINUTOS_DESPUES_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINUTOS_DESPUES_SALIDA = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>HORARIOS_TURNOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "HORARIOS_TURNOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HORARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("HORA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("HORA_FIN", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MINUTOS_ANTES_ENTRADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MINUTOS_ANTES_SALIDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MINUTOS_DESPUES_ENTRADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MINUTOS_DESPUES_SALIDA", typeof(decimal));
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

				case "HORARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "HORA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "HORA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MINUTOS_ANTES_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MINUTOS_ANTES_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MINUTOS_DESPUES_ENTRADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MINUTOS_DESPUES_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of HORARIOS_TURNOSCollection_Base class
}  // End of namespace
