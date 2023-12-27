// <fileinfo name="REFINANCIACION_DEUDAS_DOCCollection_Base.cs">
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
	/// The base class for <see cref="REFINANCIACION_DEUDAS_DOCCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="REFINANCIACION_DEUDAS_DOCCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class REFINANCIACION_DEUDAS_DOCCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string REFINANCIACION_DEUDAS_IDColumnName = "REFINANCIACION_DEUDAS_ID";
		public const string CALENDARIO_PAGOS_FC_CLIENTE_IDColumnName = "CALENDARIO_PAGOS_FC_CLIENTE_ID";
		public const string MONTO_ANTERIORColumnName = "MONTO_ANTERIOR";
		public const string IMPORTEColumnName = "IMPORTE";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string VENCIMIENTOColumnName = "VENCIMIENTO";
		public const string CANTIDAD_CUOTASColumnName = "CANTIDAD_CUOTAS";
		public const string CUOTAColumnName = "CUOTA";
		public const string ES_INTERESColumnName = "ES_INTERES";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="REFINANCIACION_DEUDAS_DOCCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public REFINANCIACION_DEUDAS_DOCCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>REFINANCIACION_DEUDAS_DOC</c> table.
		/// </summary>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDAS_DOCRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>REFINANCIACION_DEUDAS_DOC</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>REFINANCIACION_DEUDAS_DOC</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public REFINANCIACION_DEUDAS_DOCRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			REFINANCIACION_DEUDAS_DOCRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		public REFINANCIACION_DEUDAS_DOCRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects that 
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDAS_DOCRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.REFINANCIACION_DEUDAS_DOC";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="REFINANCIACION_DEUDAS_DOCRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual REFINANCIACION_DEUDAS_DOCRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			REFINANCIACION_DEUDAS_DOCRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		public REFINANCIACION_DEUDAS_DOCRow[] GetByCALENDARIO_PAGOS_FC_CLIENTE_ID(decimal calendario_pagos_fc_cliente_id)
		{
			return GetByCALENDARIO_PAGOS_FC_CLIENTE_ID(calendario_pagos_fc_cliente_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cliente_idNull">true if the method ignores the calendario_pagos_fc_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDAS_DOCRow[] GetByCALENDARIO_PAGOS_FC_CLIENTE_ID(decimal calendario_pagos_fc_cliente_id, bool calendario_pagos_fc_cliente_idNull)
		{
			return MapRecords(CreateGetByCALENDARIO_PAGOS_FC_CLIENTE_IDCommand(calendario_pagos_fc_cliente_id, calendario_pagos_fc_cliente_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCALENDARIO_PAGOS_FC_CLIENTE_IDAsDataTable(decimal calendario_pagos_fc_cliente_id)
		{
			return GetByCALENDARIO_PAGOS_FC_CLIENTE_IDAsDataTable(calendario_pagos_fc_cliente_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cliente_idNull">true if the method ignores the calendario_pagos_fc_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCALENDARIO_PAGOS_FC_CLIENTE_IDAsDataTable(decimal calendario_pagos_fc_cliente_id, bool calendario_pagos_fc_cliente_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCALENDARIO_PAGOS_FC_CLIENTE_IDCommand(calendario_pagos_fc_cliente_id, calendario_pagos_fc_cliente_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cliente_idNull">true if the method ignores the calendario_pagos_fc_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCALENDARIO_PAGOS_FC_CLIENTE_IDCommand(decimal calendario_pagos_fc_cliente_id, bool calendario_pagos_fc_cliente_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_fc_cliente_idNull)
				whereSql += "CALENDARIO_PAGOS_FC_CLIENTE_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_FC_CLIENTE_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!calendario_pagos_fc_cliente_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLIENTE_ID", calendario_pagos_fc_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_DOC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDAS_DOCRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_DOC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_DOC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects 
		/// by the <c>FK_REFI_DEUDAS_DOC_REFI_ID_</c> foreign key.
		/// </summary>
		/// <param name="refinanciacion_deudas_id">The <c>REFINANCIACION_DEUDAS_ID</c> column value.</param>
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		public virtual REFINANCIACION_DEUDAS_DOCRow[] GetByREFINANCIACION_DEUDAS_ID(decimal refinanciacion_deudas_id)
		{
			return MapRecords(CreateGetByREFINANCIACION_DEUDAS_IDCommand(refinanciacion_deudas_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_REFI_DEUDAS_DOC_REFI_ID_</c> foreign key.
		/// </summary>
		/// <param name="refinanciacion_deudas_id">The <c>REFINANCIACION_DEUDAS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByREFINANCIACION_DEUDAS_IDAsDataTable(decimal refinanciacion_deudas_id)
		{
			return MapRecordsToDataTable(CreateGetByREFINANCIACION_DEUDAS_IDCommand(refinanciacion_deudas_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_REFI_DEUDAS_DOC_REFI_ID_</c> foreign key.
		/// </summary>
		/// <param name="refinanciacion_deudas_id">The <c>REFINANCIACION_DEUDAS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByREFINANCIACION_DEUDAS_IDCommand(decimal refinanciacion_deudas_id)
		{
			string whereSql = "";
			whereSql += "REFINANCIACION_DEUDAS_ID=" + _db.CreateSqlParameterName("REFINANCIACION_DEUDAS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "REFINANCIACION_DEUDAS_ID", refinanciacion_deudas_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>REFINANCIACION_DEUDAS_DOC</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REFINANCIACION_DEUDAS_DOCRow"/> object to be inserted.</param>
		public virtual void Insert(REFINANCIACION_DEUDAS_DOCRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.REFINANCIACION_DEUDAS_DOC (" +
				"ID, " +
				"REFINANCIACION_DEUDAS_ID, " +
				"CALENDARIO_PAGOS_FC_CLIENTE_ID, " +
				"MONTO_ANTERIOR, " +
				"IMPORTE, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"VENCIMIENTO, " +
				"CANTIDAD_CUOTAS, " +
				"CUOTA, " +
				"ES_INTERES" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("REFINANCIACION_DEUDAS_ID") + ", " +
				_db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_ANTERIOR") + ", " +
				_db.CreateSqlParameterName("IMPORTE") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				_db.CreateSqlParameterName("CUOTA") + ", " +
				_db.CreateSqlParameterName("ES_INTERES") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "REFINANCIACION_DEUDAS_ID", value.REFINANCIACION_DEUDAS_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLIENTE_ID",
				value.IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_FC_CLIENTE_ID);
			AddParameter(cmd, "MONTO_ANTERIOR", value.MONTO_ANTERIOR);
			AddParameter(cmd, "IMPORTE", value.IMPORTE);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "VENCIMIENTO", value.VENCIMIENTO);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "CUOTA", value.CUOTA);
			AddParameter(cmd, "ES_INTERES", value.ES_INTERES);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>REFINANCIACION_DEUDAS_DOC</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REFINANCIACION_DEUDAS_DOCRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(REFINANCIACION_DEUDAS_DOCRow value)
		{
			
			string sqlStr = "UPDATE TRC.REFINANCIACION_DEUDAS_DOC SET " +
				"REFINANCIACION_DEUDAS_ID=" + _db.CreateSqlParameterName("REFINANCIACION_DEUDAS_ID") + ", " +
				"CALENDARIO_PAGOS_FC_CLIENTE_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLIENTE_ID") + ", " +
				"MONTO_ANTERIOR=" + _db.CreateSqlParameterName("MONTO_ANTERIOR") + ", " +
				"IMPORTE=" + _db.CreateSqlParameterName("IMPORTE") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"VENCIMIENTO=" + _db.CreateSqlParameterName("VENCIMIENTO") + ", " +
				"CANTIDAD_CUOTAS=" + _db.CreateSqlParameterName("CANTIDAD_CUOTAS") + ", " +
				"CUOTA=" + _db.CreateSqlParameterName("CUOTA") + ", " +
				"ES_INTERES=" + _db.CreateSqlParameterName("ES_INTERES") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "REFINANCIACION_DEUDAS_ID", value.REFINANCIACION_DEUDAS_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLIENTE_ID",
				value.IsCALENDARIO_PAGOS_FC_CLIENTE_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_FC_CLIENTE_ID);
			AddParameter(cmd, "MONTO_ANTERIOR", value.MONTO_ANTERIOR);
			AddParameter(cmd, "IMPORTE", value.IMPORTE);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "VENCIMIENTO", value.VENCIMIENTO);
			AddParameter(cmd, "CANTIDAD_CUOTAS", value.CANTIDAD_CUOTAS);
			AddParameter(cmd, "CUOTA", value.CUOTA);
			AddParameter(cmd, "ES_INTERES", value.ES_INTERES);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>REFINANCIACION_DEUDAS_DOC</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>REFINANCIACION_DEUDAS_DOC</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>REFINANCIACION_DEUDAS_DOC</c> table.
		/// </summary>
		/// <param name="value">The <see cref="REFINANCIACION_DEUDAS_DOCRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(REFINANCIACION_DEUDAS_DOCRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>REFINANCIACION_DEUDAS_DOC</c> table using
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
		/// Deletes records from the <c>REFINANCIACION_DEUDAS_DOC</c> table using the 
		/// <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_FC_CLIENTE_ID(decimal calendario_pagos_fc_cliente_id)
		{
			return DeleteByCALENDARIO_PAGOS_FC_CLIENTE_ID(calendario_pagos_fc_cliente_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>REFINANCIACION_DEUDAS_DOC</c> table using the 
		/// <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cliente_idNull">true if the method ignores the calendario_pagos_fc_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_FC_CLIENTE_ID(decimal calendario_pagos_fc_cliente_id, bool calendario_pagos_fc_cliente_idNull)
		{
			return CreateDeleteByCALENDARIO_PAGOS_FC_CLIENTE_IDCommand(calendario_pagos_fc_cliente_id, calendario_pagos_fc_cliente_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_DOC_CALENDAR_ID</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_cliente_id">The <c>CALENDARIO_PAGOS_FC_CLIENTE_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_cliente_idNull">true if the method ignores the calendario_pagos_fc_cliente_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCALENDARIO_PAGOS_FC_CLIENTE_IDCommand(decimal calendario_pagos_fc_cliente_id, bool calendario_pagos_fc_cliente_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_fc_cliente_idNull)
				whereSql += "CALENDARIO_PAGOS_FC_CLIENTE_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_FC_CLIENTE_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!calendario_pagos_fc_cliente_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_FC_CLIENTE_ID", calendario_pagos_fc_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REFINANCIACION_DEUDAS_DOC</c> table using the 
		/// <c>FK_REFI_DEUDAS_DOC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_DOC_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id)
		{
			string whereSql = "";
			whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>REFINANCIACION_DEUDAS_DOC</c> table using the 
		/// <c>FK_REFI_DEUDAS_DOC_REFI_ID_</c> foreign key.
		/// </summary>
		/// <param name="refinanciacion_deudas_id">The <c>REFINANCIACION_DEUDAS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByREFINANCIACION_DEUDAS_ID(decimal refinanciacion_deudas_id)
		{
			return CreateDeleteByREFINANCIACION_DEUDAS_IDCommand(refinanciacion_deudas_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_REFI_DEUDAS_DOC_REFI_ID_</c> foreign key.
		/// </summary>
		/// <param name="refinanciacion_deudas_id">The <c>REFINANCIACION_DEUDAS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByREFINANCIACION_DEUDAS_IDCommand(decimal refinanciacion_deudas_id)
		{
			string whereSql = "";
			whereSql += "REFINANCIACION_DEUDAS_ID=" + _db.CreateSqlParameterName("REFINANCIACION_DEUDAS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "REFINANCIACION_DEUDAS_ID", refinanciacion_deudas_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>REFINANCIACION_DEUDAS_DOC</c> records that match the specified criteria.
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
		/// to delete <c>REFINANCIACION_DEUDAS_DOC</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.REFINANCIACION_DEUDAS_DOC";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>REFINANCIACION_DEUDAS_DOC</c> table.
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		protected REFINANCIACION_DEUDAS_DOCRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		protected REFINANCIACION_DEUDAS_DOCRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="REFINANCIACION_DEUDAS_DOCRow"/> objects.</returns>
		protected virtual REFINANCIACION_DEUDAS_DOCRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int refinanciacion_deudas_idColumnIndex = reader.GetOrdinal("REFINANCIACION_DEUDAS_ID");
			int calendario_pagos_fc_cliente_idColumnIndex = reader.GetOrdinal("CALENDARIO_PAGOS_FC_CLIENTE_ID");
			int monto_anteriorColumnIndex = reader.GetOrdinal("MONTO_ANTERIOR");
			int importeColumnIndex = reader.GetOrdinal("IMPORTE");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int vencimientoColumnIndex = reader.GetOrdinal("VENCIMIENTO");
			int cantidad_cuotasColumnIndex = reader.GetOrdinal("CANTIDAD_CUOTAS");
			int cuotaColumnIndex = reader.GetOrdinal("CUOTA");
			int es_interesColumnIndex = reader.GetOrdinal("ES_INTERES");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					REFINANCIACION_DEUDAS_DOCRow record = new REFINANCIACION_DEUDAS_DOCRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.REFINANCIACION_DEUDAS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(refinanciacion_deudas_idColumnIndex)), 9);
					if(!reader.IsDBNull(calendario_pagos_fc_cliente_idColumnIndex))
						record.CALENDARIO_PAGOS_FC_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(calendario_pagos_fc_cliente_idColumnIndex)), 9);
					record.MONTO_ANTERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(monto_anteriorColumnIndex)), 9);
					record.IMPORTE = Math.Round(Convert.ToDecimal(reader.GetValue(importeColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.VENCIMIENTO = Convert.ToDateTime(reader.GetValue(vencimientoColumnIndex));
					record.CANTIDAD_CUOTAS = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cuotasColumnIndex)), 9);
					record.CUOTA = Math.Round(Convert.ToDecimal(reader.GetValue(cuotaColumnIndex)), 9);
					record.ES_INTERES = Convert.ToString(reader.GetValue(es_interesColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (REFINANCIACION_DEUDAS_DOCRow[])(recordList.ToArray(typeof(REFINANCIACION_DEUDAS_DOCRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="REFINANCIACION_DEUDAS_DOCRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="REFINANCIACION_DEUDAS_DOCRow"/> object.</returns>
		protected virtual REFINANCIACION_DEUDAS_DOCRow MapRow(DataRow row)
		{
			REFINANCIACION_DEUDAS_DOCRow mappedObject = new REFINANCIACION_DEUDAS_DOCRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "REFINANCIACION_DEUDAS_ID"
			dataColumn = dataTable.Columns["REFINANCIACION_DEUDAS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.REFINANCIACION_DEUDAS_ID = (decimal)row[dataColumn];
			// Column "CALENDARIO_PAGOS_FC_CLIENTE_ID"
			dataColumn = dataTable.Columns["CALENDARIO_PAGOS_FC_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALENDARIO_PAGOS_FC_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "MONTO_ANTERIOR"
			dataColumn = dataTable.Columns["MONTO_ANTERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ANTERIOR = (decimal)row[dataColumn];
			// Column "IMPORTE"
			dataColumn = dataTable.Columns["IMPORTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPORTE = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "VENCIMIENTO"
			dataColumn = dataTable.Columns["VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CANTIDAD_CUOTAS"
			dataColumn = dataTable.Columns["CANTIDAD_CUOTAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CUOTAS = (decimal)row[dataColumn];
			// Column "CUOTA"
			dataColumn = dataTable.Columns["CUOTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUOTA = (decimal)row[dataColumn];
			// Column "ES_INTERES"
			dataColumn = dataTable.Columns["ES_INTERES"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_INTERES = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>REFINANCIACION_DEUDAS_DOC</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "REFINANCIACION_DEUDAS_DOC";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("REFINANCIACION_DEUDAS_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CALENDARIO_PAGOS_FC_CLIENTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_ANTERIOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPORTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CUOTAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CUOTA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ES_INTERES", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "REFINANCIACION_DEUDAS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALENDARIO_PAGOS_FC_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ANTERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPORTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CANTIDAD_CUOTAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CUOTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_INTERES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of REFINANCIACION_DEUDAS_DOCCollection_Base class
}  // End of namespace
