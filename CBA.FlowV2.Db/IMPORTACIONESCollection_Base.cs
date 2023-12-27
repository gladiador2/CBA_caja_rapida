// <fileinfo name="IMPORTACIONESCollection_Base.cs">
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
	/// The base class for <see cref="IMPORTACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="IMPORTACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_SALIDAColumnName = "FECHA_SALIDA";
		public const string NOMBRE_INTERNOColumnName = "NOMBRE_INTERNO";
		public const string DOCUMENTOSColumnName = "DOCUMENTOS";
		public const string NUMERO_BLColumnName = "NUMERO_BL";
		public const string FECHA_LLEGADA_SITIO_INTERMEDIOColumnName = "FECHA_LLEGADA_SITIO_INTERMEDIO";
		public const string FECHA_LLEGADA_DESTINO_FINALColumnName = "FECHA_LLEGADA_DESTINO_FINAL";
		public const string EMBARCADORColumnName = "EMBARCADOR";
		public const string SE_PUEDE_MODIFICARColumnName = "SE_PUEDE_MODIFICAR";
		public const string FINALIZADOColumnName = "FINALIZADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public IMPORTACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>IMPORTACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="IMPORTACIONESRow"/> objects.</returns>
		public virtual IMPORTACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>IMPORTACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>IMPORTACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="IMPORTACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="IMPORTACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public IMPORTACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			IMPORTACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="IMPORTACIONESRow"/> objects.</returns>
		public IMPORTACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="IMPORTACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="IMPORTACIONESRow"/> objects.</returns>
		public virtual IMPORTACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.IMPORTACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="IMPORTACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="IMPORTACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual IMPORTACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			IMPORTACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>IMPORTACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(IMPORTACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.IMPORTACIONES (" +
				"ID, " +
				"FECHA_SALIDA, " +
				"NOMBRE_INTERNO, " +
				"DOCUMENTOS, " +
				"NUMERO_BL, " +
				"FECHA_LLEGADA_SITIO_INTERMEDIO, " +
				"FECHA_LLEGADA_DESTINO_FINAL, " +
				"EMBARCADOR, " +
				"SE_PUEDE_MODIFICAR, " +
				"FINALIZADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				_db.CreateSqlParameterName("NOMBRE_INTERNO") + ", " +
				_db.CreateSqlParameterName("DOCUMENTOS") + ", " +
				_db.CreateSqlParameterName("NUMERO_BL") + ", " +
				_db.CreateSqlParameterName("FECHA_LLEGADA_SITIO_INTERMEDIO") + ", " +
				_db.CreateSqlParameterName("FECHA_LLEGADA_DESTINO_FINAL") + ", " +
				_db.CreateSqlParameterName("EMBARCADOR") + ", " +
				_db.CreateSqlParameterName("SE_PUEDE_MODIFICAR") + ", " +
				_db.CreateSqlParameterName("FINALIZADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "NOMBRE_INTERNO", value.NOMBRE_INTERNO);
			AddParameter(cmd, "DOCUMENTOS", value.DOCUMENTOS);
			AddParameter(cmd, "NUMERO_BL", value.NUMERO_BL);
			AddParameter(cmd, "FECHA_LLEGADA_SITIO_INTERMEDIO",
				value.IsFECHA_LLEGADA_SITIO_INTERMEDIONull ? DBNull.Value : (object)value.FECHA_LLEGADA_SITIO_INTERMEDIO);
			AddParameter(cmd, "FECHA_LLEGADA_DESTINO_FINAL",
				value.IsFECHA_LLEGADA_DESTINO_FINALNull ? DBNull.Value : (object)value.FECHA_LLEGADA_DESTINO_FINAL);
			AddParameter(cmd, "EMBARCADOR", value.EMBARCADOR);
			AddParameter(cmd, "SE_PUEDE_MODIFICAR", value.SE_PUEDE_MODIFICAR);
			AddParameter(cmd, "FINALIZADO", value.FINALIZADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>IMPORTACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(IMPORTACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.IMPORTACIONES SET " +
				"FECHA_SALIDA=" + _db.CreateSqlParameterName("FECHA_SALIDA") + ", " +
				"NOMBRE_INTERNO=" + _db.CreateSqlParameterName("NOMBRE_INTERNO") + ", " +
				"DOCUMENTOS=" + _db.CreateSqlParameterName("DOCUMENTOS") + ", " +
				"NUMERO_BL=" + _db.CreateSqlParameterName("NUMERO_BL") + ", " +
				"FECHA_LLEGADA_SITIO_INTERMEDIO=" + _db.CreateSqlParameterName("FECHA_LLEGADA_SITIO_INTERMEDIO") + ", " +
				"FECHA_LLEGADA_DESTINO_FINAL=" + _db.CreateSqlParameterName("FECHA_LLEGADA_DESTINO_FINAL") + ", " +
				"EMBARCADOR=" + _db.CreateSqlParameterName("EMBARCADOR") + ", " +
				"SE_PUEDE_MODIFICAR=" + _db.CreateSqlParameterName("SE_PUEDE_MODIFICAR") + ", " +
				"FINALIZADO=" + _db.CreateSqlParameterName("FINALIZADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA_SALIDA",
				value.IsFECHA_SALIDANull ? DBNull.Value : (object)value.FECHA_SALIDA);
			AddParameter(cmd, "NOMBRE_INTERNO", value.NOMBRE_INTERNO);
			AddParameter(cmd, "DOCUMENTOS", value.DOCUMENTOS);
			AddParameter(cmd, "NUMERO_BL", value.NUMERO_BL);
			AddParameter(cmd, "FECHA_LLEGADA_SITIO_INTERMEDIO",
				value.IsFECHA_LLEGADA_SITIO_INTERMEDIONull ? DBNull.Value : (object)value.FECHA_LLEGADA_SITIO_INTERMEDIO);
			AddParameter(cmd, "FECHA_LLEGADA_DESTINO_FINAL",
				value.IsFECHA_LLEGADA_DESTINO_FINALNull ? DBNull.Value : (object)value.FECHA_LLEGADA_DESTINO_FINAL);
			AddParameter(cmd, "EMBARCADOR", value.EMBARCADOR);
			AddParameter(cmd, "SE_PUEDE_MODIFICAR", value.SE_PUEDE_MODIFICAR);
			AddParameter(cmd, "FINALIZADO", value.FINALIZADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>IMPORTACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>IMPORTACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>IMPORTACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="IMPORTACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(IMPORTACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>IMPORTACIONES</c> table using
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
		/// Deletes <c>IMPORTACIONES</c> records that match the specified criteria.
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
		/// to delete <c>IMPORTACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.IMPORTACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>IMPORTACIONES</c> table.
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
		/// <returns>An array of <see cref="IMPORTACIONESRow"/> objects.</returns>
		protected IMPORTACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="IMPORTACIONESRow"/> objects.</returns>
		protected IMPORTACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="IMPORTACIONESRow"/> objects.</returns>
		protected virtual IMPORTACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_salidaColumnIndex = reader.GetOrdinal("FECHA_SALIDA");
			int nombre_internoColumnIndex = reader.GetOrdinal("NOMBRE_INTERNO");
			int documentosColumnIndex = reader.GetOrdinal("DOCUMENTOS");
			int numero_blColumnIndex = reader.GetOrdinal("NUMERO_BL");
			int fecha_llegada_sitio_intermedioColumnIndex = reader.GetOrdinal("FECHA_LLEGADA_SITIO_INTERMEDIO");
			int fecha_llegada_destino_finalColumnIndex = reader.GetOrdinal("FECHA_LLEGADA_DESTINO_FINAL");
			int embarcadorColumnIndex = reader.GetOrdinal("EMBARCADOR");
			int se_puede_modificarColumnIndex = reader.GetOrdinal("SE_PUEDE_MODIFICAR");
			int finalizadoColumnIndex = reader.GetOrdinal("FINALIZADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					IMPORTACIONESRow record = new IMPORTACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_salidaColumnIndex))
						record.FECHA_SALIDA = Convert.ToDateTime(reader.GetValue(fecha_salidaColumnIndex));
					if(!reader.IsDBNull(nombre_internoColumnIndex))
						record.NOMBRE_INTERNO = Convert.ToString(reader.GetValue(nombre_internoColumnIndex));
					if(!reader.IsDBNull(documentosColumnIndex))
						record.DOCUMENTOS = Convert.ToString(reader.GetValue(documentosColumnIndex));
					if(!reader.IsDBNull(numero_blColumnIndex))
						record.NUMERO_BL = Convert.ToString(reader.GetValue(numero_blColumnIndex));
					if(!reader.IsDBNull(fecha_llegada_sitio_intermedioColumnIndex))
						record.FECHA_LLEGADA_SITIO_INTERMEDIO = Convert.ToDateTime(reader.GetValue(fecha_llegada_sitio_intermedioColumnIndex));
					if(!reader.IsDBNull(fecha_llegada_destino_finalColumnIndex))
						record.FECHA_LLEGADA_DESTINO_FINAL = Convert.ToDateTime(reader.GetValue(fecha_llegada_destino_finalColumnIndex));
					if(!reader.IsDBNull(embarcadorColumnIndex))
						record.EMBARCADOR = Convert.ToString(reader.GetValue(embarcadorColumnIndex));
					if(!reader.IsDBNull(se_puede_modificarColumnIndex))
						record.SE_PUEDE_MODIFICAR = Convert.ToString(reader.GetValue(se_puede_modificarColumnIndex));
					if(!reader.IsDBNull(finalizadoColumnIndex))
						record.FINALIZADO = Convert.ToString(reader.GetValue(finalizadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (IMPORTACIONESRow[])(recordList.ToArray(typeof(IMPORTACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="IMPORTACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="IMPORTACIONESRow"/> object.</returns>
		protected virtual IMPORTACIONESRow MapRow(DataRow row)
		{
			IMPORTACIONESRow mappedObject = new IMPORTACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_SALIDA"
			dataColumn = dataTable.Columns["FECHA_SALIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA = (System.DateTime)row[dataColumn];
			// Column "NOMBRE_INTERNO"
			dataColumn = dataTable.Columns["NOMBRE_INTERNO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_INTERNO = (string)row[dataColumn];
			// Column "DOCUMENTOS"
			dataColumn = dataTable.Columns["DOCUMENTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.DOCUMENTOS = (string)row[dataColumn];
			// Column "NUMERO_BL"
			dataColumn = dataTable.Columns["NUMERO_BL"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_BL = (string)row[dataColumn];
			// Column "FECHA_LLEGADA_SITIO_INTERMEDIO"
			dataColumn = dataTable.Columns["FECHA_LLEGADA_SITIO_INTERMEDIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_LLEGADA_SITIO_INTERMEDIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_LLEGADA_DESTINO_FINAL"
			dataColumn = dataTable.Columns["FECHA_LLEGADA_DESTINO_FINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_LLEGADA_DESTINO_FINAL = (System.DateTime)row[dataColumn];
			// Column "EMBARCADOR"
			dataColumn = dataTable.Columns["EMBARCADOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.EMBARCADOR = (string)row[dataColumn];
			// Column "SE_PUEDE_MODIFICAR"
			dataColumn = dataTable.Columns["SE_PUEDE_MODIFICAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.SE_PUEDE_MODIFICAR = (string)row[dataColumn];
			// Column "FINALIZADO"
			dataColumn = dataTable.Columns["FINALIZADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FINALIZADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>IMPORTACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "IMPORTACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NOMBRE_INTERNO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("DOCUMENTOS", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NUMERO_BL", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("FECHA_LLEGADA_SITIO_INTERMEDIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_LLEGADA_DESTINO_FINAL", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("EMBARCADOR", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("SE_PUEDE_MODIFICAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("FINALIZADO", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "FECHA_SALIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NOMBRE_INTERNO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DOCUMENTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NUMERO_BL":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_LLEGADA_SITIO_INTERMEDIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_LLEGADA_DESTINO_FINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "EMBARCADOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SE_PUEDE_MODIFICAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FINALIZADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of IMPORTACIONESCollection_Base class
}  // End of namespace
