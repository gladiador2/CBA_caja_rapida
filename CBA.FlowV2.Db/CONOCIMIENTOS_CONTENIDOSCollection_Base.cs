// <fileinfo name="CONOCIMIENTOS_CONTENIDOSCollection_Base.cs">
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
	/// The base class for <see cref="CONOCIMIENTOS_CONTENIDOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONOCIMIENTOS_CONTENIDOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONOCIMIENTOS_CONTENIDOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPOColumnName = "TIPO";
		public const string DESCRIPCIONColumnName = "DESCRIPCION";
		public const string CODIGOColumnName = "CODIGO";
		public const string MARCAColumnName = "MARCA";
		public const string MODELOColumnName = "MODELO";
		public const string ANHOColumnName = "ANHO";
		public const string COLORColumnName = "COLOR";
		public const string CHASISColumnName = "CHASIS";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string NUEVOColumnName = "NUEVO";
		public const string TIPO_EMBARQUEColumnName = "TIPO_EMBARQUE";
		public const string NRO_INSPECCIONColumnName = "NRO_INSPECCION";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONOCIMIENTOS_CONTENIDOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONOCIMIENTOS_CONTENIDOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_CONTENIDOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONOCIMIENTOS_CONTENIDOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONOCIMIENTOS_CONTENIDOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects.</returns>
		public CONOCIMIENTOS_CONTENIDOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects.</returns>
		public virtual CONOCIMIENTOS_CONTENIDOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONOCIMIENTOS_CONTENIDOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONOCIMIENTOS_CONTENIDOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONOCIMIENTOS_CONTENIDOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Adds a new record into the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> object to be inserted.</param>
		public virtual void Insert(CONOCIMIENTOS_CONTENIDOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONOCIMIENTOS_CONTENIDOS (" +
				"ID, " +
				"TIPO, " +
				"DESCRIPCION, " +
				"CODIGO, " +
				"MARCA, " +
				"MODELO, " +
				"ANHO, " +
				"COLOR, " +
				"CHASIS, " +
				"OBSERVACION, " +
				"NUEVO, " +
				"TIPO_EMBARQUE, " +
				"NRO_INSPECCION" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO") + ", " +
				_db.CreateSqlParameterName("DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("CODIGO") + ", " +
				_db.CreateSqlParameterName("MARCA") + ", " +
				_db.CreateSqlParameterName("MODELO") + ", " +
				_db.CreateSqlParameterName("ANHO") + ", " +
				_db.CreateSqlParameterName("COLOR") + ", " +
				_db.CreateSqlParameterName("CHASIS") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("NUEVO") + ", " +
				_db.CreateSqlParameterName("TIPO_EMBARQUE") + ", " +
				_db.CreateSqlParameterName("NRO_INSPECCION") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "MARCA", value.MARCA);
			AddParameter(cmd, "MODELO", value.MODELO);
			AddParameter(cmd, "ANHO", value.ANHO);
			AddParameter(cmd, "COLOR", value.COLOR);
			AddParameter(cmd, "CHASIS", value.CHASIS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "NUEVO", value.NUEVO);
			AddParameter(cmd, "TIPO_EMBARQUE", value.TIPO_EMBARQUE);
			AddParameter(cmd, "NRO_INSPECCION", value.NRO_INSPECCION);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONOCIMIENTOS_CONTENIDOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONOCIMIENTOS_CONTENIDOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONOCIMIENTOS_CONTENIDOS SET " +
				"TIPO=" + _db.CreateSqlParameterName("TIPO") + ", " +
				"DESCRIPCION=" + _db.CreateSqlParameterName("DESCRIPCION") + ", " +
				"CODIGO=" + _db.CreateSqlParameterName("CODIGO") + ", " +
				"MARCA=" + _db.CreateSqlParameterName("MARCA") + ", " +
				"MODELO=" + _db.CreateSqlParameterName("MODELO") + ", " +
				"ANHO=" + _db.CreateSqlParameterName("ANHO") + ", " +
				"COLOR=" + _db.CreateSqlParameterName("COLOR") + ", " +
				"CHASIS=" + _db.CreateSqlParameterName("CHASIS") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"NUEVO=" + _db.CreateSqlParameterName("NUEVO") + ", " +
				"TIPO_EMBARQUE=" + _db.CreateSqlParameterName("TIPO_EMBARQUE") + ", " +
				"NRO_INSPECCION=" + _db.CreateSqlParameterName("NRO_INSPECCION") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO", value.TIPO);
			AddParameter(cmd, "DESCRIPCION", value.DESCRIPCION);
			AddParameter(cmd, "CODIGO", value.CODIGO);
			AddParameter(cmd, "MARCA", value.MARCA);
			AddParameter(cmd, "MODELO", value.MODELO);
			AddParameter(cmd, "ANHO", value.ANHO);
			AddParameter(cmd, "COLOR", value.COLOR);
			AddParameter(cmd, "CHASIS", value.CHASIS);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "NUEVO", value.NUEVO);
			AddParameter(cmd, "TIPO_EMBARQUE", value.TIPO_EMBARQUE);
			AddParameter(cmd, "NRO_INSPECCION", value.NRO_INSPECCION);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONOCIMIENTOS_CONTENIDOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONOCIMIENTOS_CONTENIDOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONOCIMIENTOS_CONTENIDOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONOCIMIENTOS_CONTENIDOS</c> table using
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
		/// Deletes <c>CONOCIMIENTOS_CONTENIDOS</c> records that match the specified criteria.
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
		/// to delete <c>CONOCIMIENTOS_CONTENIDOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONOCIMIENTOS_CONTENIDOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects.</returns>
		protected CONOCIMIENTOS_CONTENIDOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects.</returns>
		protected CONOCIMIENTOS_CONTENIDOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> objects.</returns>
		protected virtual CONOCIMIENTOS_CONTENIDOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipoColumnIndex = reader.GetOrdinal("TIPO");
			int descripcionColumnIndex = reader.GetOrdinal("DESCRIPCION");
			int codigoColumnIndex = reader.GetOrdinal("CODIGO");
			int marcaColumnIndex = reader.GetOrdinal("MARCA");
			int modeloColumnIndex = reader.GetOrdinal("MODELO");
			int anhoColumnIndex = reader.GetOrdinal("ANHO");
			int colorColumnIndex = reader.GetOrdinal("COLOR");
			int chasisColumnIndex = reader.GetOrdinal("CHASIS");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int nuevoColumnIndex = reader.GetOrdinal("NUEVO");
			int tipo_embarqueColumnIndex = reader.GetOrdinal("TIPO_EMBARQUE");
			int nro_inspeccionColumnIndex = reader.GetOrdinal("NRO_INSPECCION");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONOCIMIENTOS_CONTENIDOSRow record = new CONOCIMIENTOS_CONTENIDOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(tipoColumnIndex))
						record.TIPO = Convert.ToString(reader.GetValue(tipoColumnIndex));
					if(!reader.IsDBNull(descripcionColumnIndex))
						record.DESCRIPCION = Convert.ToString(reader.GetValue(descripcionColumnIndex));
					if(!reader.IsDBNull(codigoColumnIndex))
						record.CODIGO = Convert.ToString(reader.GetValue(codigoColumnIndex));
					if(!reader.IsDBNull(marcaColumnIndex))
						record.MARCA = Convert.ToString(reader.GetValue(marcaColumnIndex));
					if(!reader.IsDBNull(modeloColumnIndex))
						record.MODELO = Convert.ToString(reader.GetValue(modeloColumnIndex));
					if(!reader.IsDBNull(anhoColumnIndex))
						record.ANHO = Convert.ToString(reader.GetValue(anhoColumnIndex));
					if(!reader.IsDBNull(colorColumnIndex))
						record.COLOR = Convert.ToString(reader.GetValue(colorColumnIndex));
					if(!reader.IsDBNull(chasisColumnIndex))
						record.CHASIS = Convert.ToString(reader.GetValue(chasisColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(nuevoColumnIndex))
						record.NUEVO = Convert.ToString(reader.GetValue(nuevoColumnIndex));
					if(!reader.IsDBNull(tipo_embarqueColumnIndex))
						record.TIPO_EMBARQUE = Convert.ToString(reader.GetValue(tipo_embarqueColumnIndex));
					if(!reader.IsDBNull(nro_inspeccionColumnIndex))
						record.NRO_INSPECCION = Convert.ToString(reader.GetValue(nro_inspeccionColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONOCIMIENTOS_CONTENIDOSRow[])(recordList.ToArray(typeof(CONOCIMIENTOS_CONTENIDOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONOCIMIENTOS_CONTENIDOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONOCIMIENTOS_CONTENIDOSRow"/> object.</returns>
		protected virtual CONOCIMIENTOS_CONTENIDOSRow MapRow(DataRow row)
		{
			CONOCIMIENTOS_CONTENIDOSRow mappedObject = new CONOCIMIENTOS_CONTENIDOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO"
			dataColumn = dataTable.Columns["TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO = (string)row[dataColumn];
			// Column "DESCRIPCION"
			dataColumn = dataTable.Columns["DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCRIPCION = (string)row[dataColumn];
			// Column "CODIGO"
			dataColumn = dataTable.Columns["CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO = (string)row[dataColumn];
			// Column "MARCA"
			dataColumn = dataTable.Columns["MARCA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARCA = (string)row[dataColumn];
			// Column "MODELO"
			dataColumn = dataTable.Columns["MODELO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MODELO = (string)row[dataColumn];
			// Column "ANHO"
			dataColumn = dataTable.Columns["ANHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANHO = (string)row[dataColumn];
			// Column "COLOR"
			dataColumn = dataTable.Columns["COLOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.COLOR = (string)row[dataColumn];
			// Column "CHASIS"
			dataColumn = dataTable.Columns["CHASIS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHASIS = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "NUEVO"
			dataColumn = dataTable.Columns["NUEVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUEVO = (string)row[dataColumn];
			// Column "TIPO_EMBARQUE"
			dataColumn = dataTable.Columns["TIPO_EMBARQUE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMBARQUE = (string)row[dataColumn];
			// Column "NRO_INSPECCION"
			dataColumn = dataTable.Columns["NRO_INSPECCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_INSPECCION = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONOCIMIENTOS_CONTENIDOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONOCIMIENTOS_CONTENIDOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CODIGO", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn = dataTable.Columns.Add("MARCA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("MODELO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("ANHO", typeof(string));
			dataColumn.MaxLength = 5;
			dataColumn = dataTable.Columns.Add("COLOR", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CHASIS", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("NUEVO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TIPO_EMBARQUE", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("NRO_INSPECCION", typeof(string));
			dataColumn.MaxLength = 25;
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

				case "TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MARCA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MODELO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ANHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "COLOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHASIS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUEVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TIPO_EMBARQUE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NRO_INSPECCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONOCIMIENTOS_CONTENIDOSCollection_Base class
}  // End of namespace
