// <fileinfo name="USUARIOS_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="USUARIOS_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="USUARIOS_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOS_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string CODIGO_VERIFICACIONColumnName = "CODIGO_VERIFICACION";
		public const string FECHA_ENVIOColumnName = "FECHA_ENVIO";
		public const string FECHA_CADUCIDADColumnName = "FECHA_CADUCIDAD";
		public const string FECHA_USOColumnName = "FECHA_USO";
		public const string VALIDACION_CORRECTAColumnName = "VALIDACION_CORRECTA";
		public const string IP_SOLICITUD_CONTRASENAColumnName = "IP_SOLICITUD_CONTRASENA";
		public const string IP_VALIDACION_USUARIOColumnName = "IP_VALIDACION_USUARIO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public USUARIOS_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>USUARIOS_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="USUARIOS_DETALLERow"/> objects.</returns>
		public virtual USUARIOS_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>USUARIOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>USUARIOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="USUARIOS_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="USUARIOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public USUARIOS_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			USUARIOS_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOS_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="USUARIOS_DETALLERow"/> objects.</returns>
		public USUARIOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOS_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="USUARIOS_DETALLERow"/> objects.</returns>
		public virtual USUARIOS_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.USUARIOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="USUARIOS_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="USUARIOS_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual USUARIOS_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			USUARIOS_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="USUARIOS_DETALLERow"/> objects 
		/// by the <c>FK_USUARIOS</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="USUARIOS_DETALLERow"/> objects.</returns>
		public virtual USUARIOS_DETALLERow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_USUARIOS</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_USUARIOS</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>USUARIOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USUARIOS_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(USUARIOS_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.USUARIOS_DETALLE (" +
				"ID, " +
				"USUARIO_ID, " +
				"CODIGO_VERIFICACION, " +
				"FECHA_ENVIO, " +
				"FECHA_CADUCIDAD, " +
				"FECHA_USO, " +
				"VALIDACION_CORRECTA, " +
				"IP_SOLICITUD_CONTRASENA, " +
				"IP_VALIDACION_USUARIO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("CODIGO_VERIFICACION") + ", " +
				_db.CreateSqlParameterName("FECHA_ENVIO") + ", " +
				_db.CreateSqlParameterName("FECHA_CADUCIDAD") + ", " +
				_db.CreateSqlParameterName("FECHA_USO") + ", " +
				_db.CreateSqlParameterName("VALIDACION_CORRECTA") + ", " +
				_db.CreateSqlParameterName("IP_SOLICITUD_CONTRASENA") + ", " +
				_db.CreateSqlParameterName("IP_VALIDACION_USUARIO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "CODIGO_VERIFICACION", value.CODIGO_VERIFICACION);
			AddParameter(cmd, "FECHA_ENVIO", value.FECHA_ENVIO);
			AddParameter(cmd, "FECHA_CADUCIDAD", value.FECHA_CADUCIDAD);
			AddParameter(cmd, "FECHA_USO",
				value.IsFECHA_USONull ? DBNull.Value : (object)value.FECHA_USO);
			AddParameter(cmd, "VALIDACION_CORRECTA", value.VALIDACION_CORRECTA);
			AddParameter(cmd, "IP_SOLICITUD_CONTRASENA", value.IP_SOLICITUD_CONTRASENA);
			AddParameter(cmd, "IP_VALIDACION_USUARIO", value.IP_VALIDACION_USUARIO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>USUARIOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USUARIOS_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(USUARIOS_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.USUARIOS_DETALLE SET " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"CODIGO_VERIFICACION=" + _db.CreateSqlParameterName("CODIGO_VERIFICACION") + ", " +
				"FECHA_ENVIO=" + _db.CreateSqlParameterName("FECHA_ENVIO") + ", " +
				"FECHA_CADUCIDAD=" + _db.CreateSqlParameterName("FECHA_CADUCIDAD") + ", " +
				"FECHA_USO=" + _db.CreateSqlParameterName("FECHA_USO") + ", " +
				"VALIDACION_CORRECTA=" + _db.CreateSqlParameterName("VALIDACION_CORRECTA") + ", " +
				"IP_SOLICITUD_CONTRASENA=" + _db.CreateSqlParameterName("IP_SOLICITUD_CONTRASENA") + ", " +
				"IP_VALIDACION_USUARIO=" + _db.CreateSqlParameterName("IP_VALIDACION_USUARIO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "USUARIO_ID", value.USUARIO_ID);
			AddParameter(cmd, "CODIGO_VERIFICACION", value.CODIGO_VERIFICACION);
			AddParameter(cmd, "FECHA_ENVIO", value.FECHA_ENVIO);
			AddParameter(cmd, "FECHA_CADUCIDAD", value.FECHA_CADUCIDAD);
			AddParameter(cmd, "FECHA_USO",
				value.IsFECHA_USONull ? DBNull.Value : (object)value.FECHA_USO);
			AddParameter(cmd, "VALIDACION_CORRECTA", value.VALIDACION_CORRECTA);
			AddParameter(cmd, "IP_SOLICITUD_CONTRASENA", value.IP_SOLICITUD_CONTRASENA);
			AddParameter(cmd, "IP_VALIDACION_USUARIO", value.IP_VALIDACION_USUARIO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>USUARIOS_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>USUARIOS_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>USUARIOS_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="USUARIOS_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(USUARIOS_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>USUARIOS_DETALLE</c> table using
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
		/// Deletes records from the <c>USUARIOS_DETALLE</c> table using the 
		/// <c>FK_USUARIOS</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_USUARIOS</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>USUARIOS_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>USUARIOS_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.USUARIOS_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>USUARIOS_DETALLE</c> table.
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
		/// <returns>An array of <see cref="USUARIOS_DETALLERow"/> objects.</returns>
		protected USUARIOS_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="USUARIOS_DETALLERow"/> objects.</returns>
		protected USUARIOS_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="USUARIOS_DETALLERow"/> objects.</returns>
		protected virtual USUARIOS_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int codigo_verificacionColumnIndex = reader.GetOrdinal("CODIGO_VERIFICACION");
			int fecha_envioColumnIndex = reader.GetOrdinal("FECHA_ENVIO");
			int fecha_caducidadColumnIndex = reader.GetOrdinal("FECHA_CADUCIDAD");
			int fecha_usoColumnIndex = reader.GetOrdinal("FECHA_USO");
			int validacion_correctaColumnIndex = reader.GetOrdinal("VALIDACION_CORRECTA");
			int ip_solicitud_contrasenaColumnIndex = reader.GetOrdinal("IP_SOLICITUD_CONTRASENA");
			int ip_validacion_usuarioColumnIndex = reader.GetOrdinal("IP_VALIDACION_USUARIO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					USUARIOS_DETALLERow record = new USUARIOS_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					record.CODIGO_VERIFICACION = Convert.ToString(reader.GetValue(codigo_verificacionColumnIndex));
					record.FECHA_ENVIO = Convert.ToDateTime(reader.GetValue(fecha_envioColumnIndex));
					record.FECHA_CADUCIDAD = Convert.ToDateTime(reader.GetValue(fecha_caducidadColumnIndex));
					if(!reader.IsDBNull(fecha_usoColumnIndex))
						record.FECHA_USO = Convert.ToDateTime(reader.GetValue(fecha_usoColumnIndex));
					if(!reader.IsDBNull(validacion_correctaColumnIndex))
						record.VALIDACION_CORRECTA = Convert.ToString(reader.GetValue(validacion_correctaColumnIndex));
					record.IP_SOLICITUD_CONTRASENA = Convert.ToString(reader.GetValue(ip_solicitud_contrasenaColumnIndex));
					if(!reader.IsDBNull(ip_validacion_usuarioColumnIndex))
						record.IP_VALIDACION_USUARIO = Convert.ToString(reader.GetValue(ip_validacion_usuarioColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (USUARIOS_DETALLERow[])(recordList.ToArray(typeof(USUARIOS_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="USUARIOS_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="USUARIOS_DETALLERow"/> object.</returns>
		protected virtual USUARIOS_DETALLERow MapRow(DataRow row)
		{
			USUARIOS_DETALLERow mappedObject = new USUARIOS_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "CODIGO_VERIFICACION"
			dataColumn = dataTable.Columns["CODIGO_VERIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CODIGO_VERIFICACION = (string)row[dataColumn];
			// Column "FECHA_ENVIO"
			dataColumn = dataTable.Columns["FECHA_ENVIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENVIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_CADUCIDAD"
			dataColumn = dataTable.Columns["FECHA_CADUCIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CADUCIDAD = (System.DateTime)row[dataColumn];
			// Column "FECHA_USO"
			dataColumn = dataTable.Columns["FECHA_USO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_USO = (System.DateTime)row[dataColumn];
			// Column "VALIDACION_CORRECTA"
			dataColumn = dataTable.Columns["VALIDACION_CORRECTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALIDACION_CORRECTA = (string)row[dataColumn];
			// Column "IP_SOLICITUD_CONTRASENA"
			dataColumn = dataTable.Columns["IP_SOLICITUD_CONTRASENA"];
			if(!row.IsNull(dataColumn))
				mappedObject.IP_SOLICITUD_CONTRASENA = (string)row[dataColumn];
			// Column "IP_VALIDACION_USUARIO"
			dataColumn = dataTable.Columns["IP_VALIDACION_USUARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IP_VALIDACION_USUARIO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>USUARIOS_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "USUARIOS_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CODIGO_VERIFICACION", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ENVIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_CADUCIDAD", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_USO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("VALIDACION_CORRECTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("IP_SOLICITUD_CONTRASENA", typeof(string));
			dataColumn.MaxLength = 40;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IP_VALIDACION_USUARIO", typeof(string));
			dataColumn.MaxLength = 40;
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

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CODIGO_VERIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ENVIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_CADUCIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_USO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "VALIDACION_CORRECTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "IP_SOLICITUD_CONTRASENA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "IP_VALIDACION_USUARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of USUARIOS_DETALLECollection_Base class
}  // End of namespace
