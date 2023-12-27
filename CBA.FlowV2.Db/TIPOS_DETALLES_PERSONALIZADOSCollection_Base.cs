// <fileinfo name="TIPOS_DETALLES_PERSONALIZADOSCollection_Base.cs">
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
	/// The base class for <see cref="TIPOS_DETALLES_PERSONALIZADOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TIPOS_DETALLES_PERSONALIZADOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPOS_DETALLES_PERSONALIZADOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string ESTADOColumnName = "ESTADO";
		public const string PRIVADOColumnName = "PRIVADO";
		public const string TITULOSColumnName = "TITULOS";
		public const string OBLIGATORIOSColumnName = "OBLIGATORIOS";
		public const string DISPARAN_ALARMAColumnName = "DISPARAN_ALARMA";
		public const string TIPOS_DATOColumnName = "TIPOS_DATO";
		public const string ORDENColumnName = "ORDEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPOS_DETALLES_PERSONALIZADOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TIPOS_DETALLES_PERSONALIZADOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public virtual TIPOS_DETALLES_PERSONALIZADOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TIPOS_DETALLES_PERSONALIZADOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TIPOS_DETALLES_PERSONALIZADOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public TIPOS_DETALLES_PERSONALIZADOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects that 
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
		/// <returns>An array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		public virtual TIPOS_DETALLES_PERSONALIZADOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TIPOS_DETALLES_PERSONALIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TIPOS_DETALLES_PERSONALIZADOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TIPOS_DETALLES_PERSONALIZADOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> object to be inserted.</param>
		public virtual void Insert(TIPOS_DETALLES_PERSONALIZADOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TIPOS_DETALLES_PERSONALIZADOS (" +
				"ID, " +
				"NOMBRE, " +
				"OBSERVACION, " +
				"ESTADO, " +
				"PRIVADO, " +
				"TITULOS, " +
				"OBLIGATORIOS, " +
				"DISPARAN_ALARMA, " +
				"TIPOS_DATO, " +
				"ORDEN" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("PRIVADO") + ", " +
				_db.CreateSqlParameterName("TITULOS") + ", " +
				_db.CreateSqlParameterName("OBLIGATORIOS") + ", " +
				_db.CreateSqlParameterName("DISPARAN_ALARMA") + ", " +
				_db.CreateSqlParameterName("TIPOS_DATO") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PRIVADO", value.PRIVADO);
			AddParameter(cmd, "TITULOS", value.TITULOS);
			AddParameter(cmd, "OBLIGATORIOS", value.OBLIGATORIOS);
			AddParameter(cmd, "DISPARAN_ALARMA", value.DISPARAN_ALARMA);
			AddParameter(cmd, "TIPOS_DATO", value.TIPOS_DATO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TIPOS_DETALLES_PERSONALIZADOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.TIPOS_DETALLES_PERSONALIZADOS SET " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"PRIVADO=" + _db.CreateSqlParameterName("PRIVADO") + ", " +
				"TITULOS=" + _db.CreateSqlParameterName("TITULOS") + ", " +
				"OBLIGATORIOS=" + _db.CreateSqlParameterName("OBLIGATORIOS") + ", " +
				"DISPARAN_ALARMA=" + _db.CreateSqlParameterName("DISPARAN_ALARMA") + ", " +
				"TIPOS_DATO=" + _db.CreateSqlParameterName("TIPOS_DATO") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PRIVADO", value.PRIVADO);
			AddParameter(cmd, "TITULOS", value.TITULOS);
			AddParameter(cmd, "OBLIGATORIOS", value.OBLIGATORIOS);
			AddParameter(cmd, "DISPARAN_ALARMA", value.DISPARAN_ALARMA);
			AddParameter(cmd, "TIPOS_DATO", value.TIPOS_DATO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TIPOS_DETALLES_PERSONALIZADOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table using
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
		/// Deletes <c>TIPOS_DETALLES_PERSONALIZADOS</c> records that match the specified criteria.
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
		/// to delete <c>TIPOS_DETALLES_PERSONALIZADOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TIPOS_DETALLES_PERSONALIZADOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
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
		/// <returns>An array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		protected TIPOS_DETALLES_PERSONALIZADOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		protected TIPOS_DETALLES_PERSONALIZADOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> objects.</returns>
		protected virtual TIPOS_DETALLES_PERSONALIZADOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int privadoColumnIndex = reader.GetOrdinal("PRIVADO");
			int titulosColumnIndex = reader.GetOrdinal("TITULOS");
			int obligatoriosColumnIndex = reader.GetOrdinal("OBLIGATORIOS");
			int disparan_alarmaColumnIndex = reader.GetOrdinal("DISPARAN_ALARMA");
			int tipos_datoColumnIndex = reader.GetOrdinal("TIPOS_DATO");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TIPOS_DETALLES_PERSONALIZADOSRow record = new TIPOS_DETALLES_PERSONALIZADOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.PRIVADO = Convert.ToString(reader.GetValue(privadoColumnIndex));
					if(!reader.IsDBNull(titulosColumnIndex))
						record.TITULOS = Convert.ToString(reader.GetValue(titulosColumnIndex));
					if(!reader.IsDBNull(obligatoriosColumnIndex))
						record.OBLIGATORIOS = Convert.ToString(reader.GetValue(obligatoriosColumnIndex));
					if(!reader.IsDBNull(disparan_alarmaColumnIndex))
						record.DISPARAN_ALARMA = Convert.ToString(reader.GetValue(disparan_alarmaColumnIndex));
					if(!reader.IsDBNull(tipos_datoColumnIndex))
						record.TIPOS_DATO = Convert.ToString(reader.GetValue(tipos_datoColumnIndex));
					if(!reader.IsDBNull(ordenColumnIndex))
						record.ORDEN = Convert.ToString(reader.GetValue(ordenColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TIPOS_DETALLES_PERSONALIZADOSRow[])(recordList.ToArray(typeof(TIPOS_DETALLES_PERSONALIZADOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TIPOS_DETALLES_PERSONALIZADOSRow"/> object.</returns>
		protected virtual TIPOS_DETALLES_PERSONALIZADOSRow MapRow(DataRow row)
		{
			TIPOS_DETALLES_PERSONALIZADOSRow mappedObject = new TIPOS_DETALLES_PERSONALIZADOSRow();
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
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PRIVADO"
			dataColumn = dataTable.Columns["PRIVADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRIVADO = (string)row[dataColumn];
			// Column "TITULOS"
			dataColumn = dataTable.Columns["TITULOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TITULOS = (string)row[dataColumn];
			// Column "OBLIGATORIOS"
			dataColumn = dataTable.Columns["OBLIGATORIOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBLIGATORIOS = (string)row[dataColumn];
			// Column "DISPARAN_ALARMA"
			dataColumn = dataTable.Columns["DISPARAN_ALARMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.DISPARAN_ALARMA = (string)row[dataColumn];
			// Column "TIPOS_DATO"
			dataColumn = dataTable.Columns["TIPOS_DATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPOS_DATO = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TIPOS_DETALLES_PERSONALIZADOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TIPOS_DETALLES_PERSONALIZADOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRIVADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TITULOS", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn = dataTable.Columns.Add("OBLIGATORIOS", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("DISPARAN_ALARMA", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("TIPOS_DATO", typeof(string));
			dataColumn.MaxLength = 200;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(string));
			dataColumn.MaxLength = 200;
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

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRIVADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TITULOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBLIGATORIOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DISPARAN_ALARMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPOS_DATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TIPOS_DETALLES_PERSONALIZADOSCollection_Base class
}  // End of namespace
