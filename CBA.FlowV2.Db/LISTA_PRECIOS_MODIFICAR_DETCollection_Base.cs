// <fileinfo name="LISTA_PRECIOS_MODIFICAR_DETCollection_Base.cs">
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
	/// The base class for <see cref="LISTA_PRECIOS_MODIFICAR_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="LISTA_PRECIOS_MODIFICAR_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LISTA_PRECIOS_MODIFICAR_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string LISTA_PRECIOS_MODIFICAR_IDColumnName = "LISTA_PRECIOS_MODIFICAR_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string PRECIO_NUEVOColumnName = "PRECIO_NUEVO";
		public const string COSTOColumnName = "COSTO";
		public const string MARGEN_RENTABILIDADColumnName = "MARGEN_RENTABILIDAD";
		public const string CANTIDAD_MINIMAColumnName = "CANTIDAD_MINIMA";
		public const string DESCUENTO_MAXIMOColumnName = "DESCUENTO_MAXIMO";
		public const string QUITAR_ARTICULO_DE_LISTAColumnName = "QUITAR_ARTICULO_DE_LISTA";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_COTIZACIONColumnName = "COSTO_COTIZACION";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string FECHA_FINColumnName = "FECHA_FIN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="LISTA_PRECIOS_MODIFICAR_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public LISTA_PRECIOS_MODIFICAR_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_MODIFICAR_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public LISTA_PRECIOS_MODIFICAR_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			LISTA_PRECIOS_MODIFICAR_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		public LISTA_PRECIOS_MODIFICAR_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_MODIFICAR_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.LISTA_PRECIOS_MODIFICAR_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual LISTA_PRECIOS_MODIFICAR_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			LISTA_PRECIOS_MODIFICAR_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects 
		/// by the <c>FK_LISTA_PRECIOS_MODIF_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_MODIFICAR_DETRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LISTA_PRECIOS_MODIF_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LISTA_PRECIOS_MODIF_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects 
		/// by the <c>FK_LISTA_PRECIOS_MODIF_DET_LIS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_modificar_id">The <c>LISTA_PRECIOS_MODIFICAR_ID</c> column value.</param>
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_MODIFICAR_DETRow[] GetByLISTA_PRECIOS_MODIFICAR_ID(decimal lista_precios_modificar_id)
		{
			return MapRecords(CreateGetByLISTA_PRECIOS_MODIFICAR_IDCommand(lista_precios_modificar_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LISTA_PRECIOS_MODIF_DET_LIS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_modificar_id">The <c>LISTA_PRECIOS_MODIFICAR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIOS_MODIFICAR_IDAsDataTable(decimal lista_precios_modificar_id)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIOS_MODIFICAR_IDCommand(lista_precios_modificar_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LISTA_PRECIOS_MODIF_DET_LIS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_modificar_id">The <c>LISTA_PRECIOS_MODIFICAR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIOS_MODIFICAR_IDCommand(decimal lista_precios_modificar_id)
		{
			string whereSql = "";
			whereSql += "LISTA_PRECIOS_MODIFICAR_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_MODIFICAR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "LISTA_PRECIOS_MODIFICAR_ID", lista_precios_modificar_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects 
		/// by the <c>FK_LISTA_PRECIOS_MODIF_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		public virtual LISTA_PRECIOS_MODIFICAR_DETRow[] GetByCOSTO_MONEDA_ID(decimal costo_moneda_id)
		{
			return MapRecords(CreateGetByCOSTO_MONEDA_IDCommand(costo_moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_LISTA_PRECIOS_MODIF_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTO_MONEDA_IDAsDataTable(decimal costo_moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByCOSTO_MONEDA_IDCommand(costo_moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_LISTA_PRECIOS_MODIF_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTO_MONEDA_IDCommand(decimal costo_moneda_id)
		{
			string whereSql = "";
			whereSql += "COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "COSTO_MONEDA_ID", costo_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> object to be inserted.</param>
		public virtual void Insert(LISTA_PRECIOS_MODIFICAR_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.LISTA_PRECIOS_MODIFICAR_DET (" +
				"ID, " +
				"LISTA_PRECIOS_MODIFICAR_ID, " +
				"ARTICULO_ID, " +
				"PRECIO_NUEVO, " +
				"COSTO, " +
				"MARGEN_RENTABILIDAD, " +
				"CANTIDAD_MINIMA, " +
				"DESCUENTO_MAXIMO, " +
				"QUITAR_ARTICULO_DE_LISTA, " +
				"COSTO_MONEDA_ID, " +
				"COSTO_COTIZACION, " +
				"FECHA_INICIO, " +
				"FECHA_FIN" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIOS_MODIFICAR_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("PRECIO_NUEVO") + ", " +
				_db.CreateSqlParameterName("COSTO") + ", " +
				_db.CreateSqlParameterName("MARGEN_RENTABILIDAD") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_MINIMA") + ", " +
				_db.CreateSqlParameterName("DESCUENTO_MAXIMO") + ", " +
				_db.CreateSqlParameterName("QUITAR_ARTICULO_DE_LISTA") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_COTIZACION") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_FIN") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "LISTA_PRECIOS_MODIFICAR_ID", value.LISTA_PRECIOS_MODIFICAR_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "PRECIO_NUEVO", value.PRECIO_NUEVO);
			AddParameter(cmd, "COSTO", value.COSTO);
			AddParameter(cmd, "MARGEN_RENTABILIDAD", value.MARGEN_RENTABILIDAD);
			AddParameter(cmd, "CANTIDAD_MINIMA", value.CANTIDAD_MINIMA);
			AddParameter(cmd, "DESCUENTO_MAXIMO", value.DESCUENTO_MAXIMO);
			AddParameter(cmd, "QUITAR_ARTICULO_DE_LISTA", value.QUITAR_ARTICULO_DE_LISTA);
			AddParameter(cmd, "COSTO_MONEDA_ID", value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_COTIZACION", value.COSTO_COTIZACION);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(LISTA_PRECIOS_MODIFICAR_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.LISTA_PRECIOS_MODIFICAR_DET SET " +
				"LISTA_PRECIOS_MODIFICAR_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_MODIFICAR_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"PRECIO_NUEVO=" + _db.CreateSqlParameterName("PRECIO_NUEVO") + ", " +
				"COSTO=" + _db.CreateSqlParameterName("COSTO") + ", " +
				"MARGEN_RENTABILIDAD=" + _db.CreateSqlParameterName("MARGEN_RENTABILIDAD") + ", " +
				"CANTIDAD_MINIMA=" + _db.CreateSqlParameterName("CANTIDAD_MINIMA") + ", " +
				"DESCUENTO_MAXIMO=" + _db.CreateSqlParameterName("DESCUENTO_MAXIMO") + ", " +
				"QUITAR_ARTICULO_DE_LISTA=" + _db.CreateSqlParameterName("QUITAR_ARTICULO_DE_LISTA") + ", " +
				"COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				"COSTO_COTIZACION=" + _db.CreateSqlParameterName("COSTO_COTIZACION") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"FECHA_FIN=" + _db.CreateSqlParameterName("FECHA_FIN") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "LISTA_PRECIOS_MODIFICAR_ID", value.LISTA_PRECIOS_MODIFICAR_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "PRECIO_NUEVO", value.PRECIO_NUEVO);
			AddParameter(cmd, "COSTO", value.COSTO);
			AddParameter(cmd, "MARGEN_RENTABILIDAD", value.MARGEN_RENTABILIDAD);
			AddParameter(cmd, "CANTIDAD_MINIMA", value.CANTIDAD_MINIMA);
			AddParameter(cmd, "DESCUENTO_MAXIMO", value.DESCUENTO_MAXIMO);
			AddParameter(cmd, "QUITAR_ARTICULO_DE_LISTA", value.QUITAR_ARTICULO_DE_LISTA);
			AddParameter(cmd, "COSTO_MONEDA_ID", value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_COTIZACION", value.COSTO_COTIZACION);
			AddParameter(cmd, "FECHA_INICIO", value.FECHA_INICIO);
			AddParameter(cmd, "FECHA_FIN",
				value.IsFECHA_FINNull ? DBNull.Value : (object)value.FECHA_FIN);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(LISTA_PRECIOS_MODIFICAR_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table using
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
		/// Deletes records from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table using the 
		/// <c>FK_LISTA_PRECIOS_MODIF_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LISTA_PRECIOS_MODIF_DET_ART</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table using the 
		/// <c>FK_LISTA_PRECIOS_MODIF_DET_LIS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_modificar_id">The <c>LISTA_PRECIOS_MODIFICAR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIOS_MODIFICAR_ID(decimal lista_precios_modificar_id)
		{
			return CreateDeleteByLISTA_PRECIOS_MODIFICAR_IDCommand(lista_precios_modificar_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LISTA_PRECIOS_MODIF_DET_LIS</c> foreign key.
		/// </summary>
		/// <param name="lista_precios_modificar_id">The <c>LISTA_PRECIOS_MODIFICAR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIOS_MODIFICAR_IDCommand(decimal lista_precios_modificar_id)
		{
			string whereSql = "";
			whereSql += "LISTA_PRECIOS_MODIFICAR_ID=" + _db.CreateSqlParameterName("LISTA_PRECIOS_MODIFICAR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "LISTA_PRECIOS_MODIFICAR_ID", lista_precios_modificar_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table using the 
		/// <c>FK_LISTA_PRECIOS_MODIF_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_MONEDA_ID(decimal costo_moneda_id)
		{
			return CreateDeleteByCOSTO_MONEDA_IDCommand(costo_moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_LISTA_PRECIOS_MODIF_DET_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTO_MONEDA_IDCommand(decimal costo_moneda_id)
		{
			string whereSql = "";
			whereSql += "COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "COSTO_MONEDA_ID", costo_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>LISTA_PRECIOS_MODIFICAR_DET</c> records that match the specified criteria.
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
		/// to delete <c>LISTA_PRECIOS_MODIFICAR_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.LISTA_PRECIOS_MODIFICAR_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		protected LISTA_PRECIOS_MODIFICAR_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		protected LISTA_PRECIOS_MODIFICAR_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> objects.</returns>
		protected virtual LISTA_PRECIOS_MODIFICAR_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int lista_precios_modificar_idColumnIndex = reader.GetOrdinal("LISTA_PRECIOS_MODIFICAR_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int precio_nuevoColumnIndex = reader.GetOrdinal("PRECIO_NUEVO");
			int costoColumnIndex = reader.GetOrdinal("COSTO");
			int margen_rentabilidadColumnIndex = reader.GetOrdinal("MARGEN_RENTABILIDAD");
			int cantidad_minimaColumnIndex = reader.GetOrdinal("CANTIDAD_MINIMA");
			int descuento_maximoColumnIndex = reader.GetOrdinal("DESCUENTO_MAXIMO");
			int quitar_articulo_de_listaColumnIndex = reader.GetOrdinal("QUITAR_ARTICULO_DE_LISTA");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_cotizacionColumnIndex = reader.GetOrdinal("COSTO_COTIZACION");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int fecha_finColumnIndex = reader.GetOrdinal("FECHA_FIN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					LISTA_PRECIOS_MODIFICAR_DETRow record = new LISTA_PRECIOS_MODIFICAR_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.LISTA_PRECIOS_MODIFICAR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precios_modificar_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.PRECIO_NUEVO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_nuevoColumnIndex)), 9);
					record.COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(costoColumnIndex)), 9);
					record.MARGEN_RENTABILIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(margen_rentabilidadColumnIndex)), 9);
					record.CANTIDAD_MINIMA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_minimaColumnIndex)), 9);
					record.DESCUENTO_MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(descuento_maximoColumnIndex)), 9);
					record.QUITAR_ARTICULO_DE_LISTA = Convert.ToString(reader.GetValue(quitar_articulo_de_listaColumnIndex));
					record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					record.COSTO_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_cotizacionColumnIndex)), 9);
					record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_finColumnIndex))
						record.FECHA_FIN = Convert.ToDateTime(reader.GetValue(fecha_finColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (LISTA_PRECIOS_MODIFICAR_DETRow[])(recordList.ToArray(typeof(LISTA_PRECIOS_MODIFICAR_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="LISTA_PRECIOS_MODIFICAR_DETRow"/> object.</returns>
		protected virtual LISTA_PRECIOS_MODIFICAR_DETRow MapRow(DataRow row)
		{
			LISTA_PRECIOS_MODIFICAR_DETRow mappedObject = new LISTA_PRECIOS_MODIFICAR_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIOS_MODIFICAR_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIOS_MODIFICAR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIOS_MODIFICAR_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "PRECIO_NUEVO"
			dataColumn = dataTable.Columns["PRECIO_NUEVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_NUEVO = (decimal)row[dataColumn];
			// Column "COSTO"
			dataColumn = dataTable.Columns["COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO = (decimal)row[dataColumn];
			// Column "MARGEN_RENTABILIDAD"
			dataColumn = dataTable.Columns["MARGEN_RENTABILIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.MARGEN_RENTABILIDAD = (decimal)row[dataColumn];
			// Column "CANTIDAD_MINIMA"
			dataColumn = dataTable.Columns["CANTIDAD_MINIMA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_MINIMA = (decimal)row[dataColumn];
			// Column "DESCUENTO_MAXIMO"
			dataColumn = dataTable.Columns["DESCUENTO_MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCUENTO_MAXIMO = (decimal)row[dataColumn];
			// Column "QUITAR_ARTICULO_DE_LISTA"
			dataColumn = dataTable.Columns["QUITAR_ARTICULO_DE_LISTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.QUITAR_ARTICULO_DE_LISTA = (string)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_COTIZACION = (decimal)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_FIN"
			dataColumn = dataTable.Columns["FECHA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FIN = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>LISTA_PRECIOS_MODIFICAR_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "LISTA_PRECIOS_MODIFICAR_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIOS_MODIFICAR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRECIO_NUEVO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MARGEN_RENTABILIDAD", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_MINIMA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DESCUENTO_MAXIMO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("QUITAR_ARTICULO_DE_LISTA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_FIN", typeof(System.DateTime));
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

				case "LISTA_PRECIOS_MODIFICAR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_NUEVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MARGEN_RENTABILIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_MINIMA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCUENTO_MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "QUITAR_ARTICULO_DE_LISTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of LISTA_PRECIOS_MODIFICAR_DETCollection_Base class
}  // End of namespace
