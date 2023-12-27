// <fileinfo name="AUTONUMERACIONES_PROVEEDORCollection_Base.cs">
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
	/// The base class for <see cref="AUTONUMERACIONES_PROVEEDORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="AUTONUMERACIONES_PROVEEDORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AUTONUMERACIONES_PROVEEDORCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PROVEEDORES_IDColumnName = "PROVEEDORES_ID";
		public const string NUMERO_TIMBRADOColumnName = "NUMERO_TIMBRADO";
		public const string LIMITE_INFERIORColumnName = "LIMITE_INFERIOR";
		public const string LIMITE_SUPERIORColumnName = "LIMITE_SUPERIOR";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string FECHA_INICIOColumnName = "FECHA_INICIO";
		public const string PREFIJOColumnName = "PREFIJO";
		public const string FECHA_CREACIONColumnName = "FECHA_CREACION";
		public const string USUARIO_CREACION_IDColumnName = "USUARIO_CREACION_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string FLUJO_IDColumnName = "FLUJO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="AUTONUMERACIONES_PROVEEDORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public AUTONUMERACIONES_PROVEEDORCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public virtual AUTONUMERACIONES_PROVEEDORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public AUTONUMERACIONES_PROVEEDORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			AUTONUMERACIONES_PROVEEDORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public AUTONUMERACIONES_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects that 
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public virtual AUTONUMERACIONES_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.AUTONUMERACIONES_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="AUTONUMERACIONES_PROVEEDORRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual AUTONUMERACIONES_PROVEEDORRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			AUTONUMERACIONES_PROVEEDORRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects 
		/// by the <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public AUTONUMERACIONES_PROVEEDORRow[] GetByFLUJO_ID(decimal flujo_id)
		{
			return GetByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects 
		/// by the <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public virtual AUTONUMERACIONES_PROVEEDORRow[] GetByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecords(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id)
		{
			return GetByFLUJO_IDAsDataTable(flujo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_IDAsDataTable(decimal flujo_id, bool flujo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_IDCommand(flujo_id, flujo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects 
		/// by the <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public AUTONUMERACIONES_PROVEEDORRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return GetByUSUARIO_CREACION_ID(usuario_creacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects 
		/// by the <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public virtual AUTONUMERACIONES_PROVEEDORRow[] GetByUSUARIO_CREACION_ID(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id, usuario_creacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id)
		{
			return GetByUSUARIO_CREACION_IDAsDataTable(usuario_creacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_CREACION_IDAsDataTable(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_CREACION_IDCommand(usuario_creacion_id, usuario_creacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			string whereSql = "";
			if(usuario_creacion_idNull)
				whereSql += "USUARIO_CREACION_ID IS NULL";
			else
				whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_creacion_idNull)
				AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects 
		/// by the <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public AUTONUMERACIONES_PROVEEDORRow[] GetByPROVEEDORES_ID(decimal proveedores_id)
		{
			return GetByPROVEEDORES_ID(proveedores_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects 
		/// by the <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <param name="proveedores_idNull">true if the method ignores the proveedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		public virtual AUTONUMERACIONES_PROVEEDORRow[] GetByPROVEEDORES_ID(decimal proveedores_id, bool proveedores_idNull)
		{
			return MapRecords(CreateGetByPROVEEDORES_IDCommand(proveedores_id, proveedores_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDORES_IDAsDataTable(decimal proveedores_id)
		{
			return GetByPROVEEDORES_IDAsDataTable(proveedores_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <param name="proveedores_idNull">true if the method ignores the proveedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDORES_IDAsDataTable(decimal proveedores_id, bool proveedores_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDORES_IDCommand(proveedores_id, proveedores_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <param name="proveedores_idNull">true if the method ignores the proveedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDORES_IDCommand(decimal proveedores_id, bool proveedores_idNull)
		{
			string whereSql = "";
			if(proveedores_idNull)
				whereSql += "PROVEEDORES_ID IS NULL";
			else
				whereSql += "PROVEEDORES_ID=" + _db.CreateSqlParameterName("PROVEEDORES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedores_idNull)
				AddParameter(cmd, "PROVEEDORES_ID", proveedores_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="AUTONUMERACIONES_PROVEEDORRow"/> object to be inserted.</param>
		public virtual void Insert(AUTONUMERACIONES_PROVEEDORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.AUTONUMERACIONES_PROVEEDOR (" +
				"ID, " +
				"PROVEEDORES_ID, " +
				"NUMERO_TIMBRADO, " +
				"LIMITE_INFERIOR, " +
				"LIMITE_SUPERIOR, " +
				"FECHA_VENCIMIENTO, " +
				"FECHA_INICIO, " +
				"PREFIJO, " +
				"FECHA_CREACION, " +
				"USUARIO_CREACION_ID, " +
				"ESTADO, " +
				"FLUJO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDORES_ID") + ", " +
				_db.CreateSqlParameterName("NUMERO_TIMBRADO") + ", " +
				_db.CreateSqlParameterName("LIMITE_INFERIOR") + ", " +
				_db.CreateSqlParameterName("LIMITE_SUPERIOR") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				_db.CreateSqlParameterName("PREFIJO") + ", " +
				_db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				_db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("FLUJO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PROVEEDORES_ID",
				value.IsPROVEEDORES_IDNull ? DBNull.Value : (object)value.PROVEEDORES_ID);
			AddParameter(cmd, "NUMERO_TIMBRADO", value.NUMERO_TIMBRADO);
			AddParameter(cmd, "LIMITE_INFERIOR",
				value.IsLIMITE_INFERIORNull ? DBNull.Value : (object)value.LIMITE_INFERIOR);
			AddParameter(cmd, "LIMITE_SUPERIOR",
				value.IsLIMITE_SUPERIORNull ? DBNull.Value : (object)value.LIMITE_SUPERIOR);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "PREFIJO", value.PREFIJO);
			AddParameter(cmd, "FECHA_CREACION",
				value.IsFECHA_CREACIONNull ? DBNull.Value : (object)value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID",
				value.IsUSUARIO_CREACION_IDNull ? DBNull.Value : (object)value.USUARIO_CREACION_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="AUTONUMERACIONES_PROVEEDORRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(AUTONUMERACIONES_PROVEEDORRow value)
		{
			
			string sqlStr = "UPDATE TRC.AUTONUMERACIONES_PROVEEDOR SET " +
				"PROVEEDORES_ID=" + _db.CreateSqlParameterName("PROVEEDORES_ID") + ", " +
				"NUMERO_TIMBRADO=" + _db.CreateSqlParameterName("NUMERO_TIMBRADO") + ", " +
				"LIMITE_INFERIOR=" + _db.CreateSqlParameterName("LIMITE_INFERIOR") + ", " +
				"LIMITE_SUPERIOR=" + _db.CreateSqlParameterName("LIMITE_SUPERIOR") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"FECHA_INICIO=" + _db.CreateSqlParameterName("FECHA_INICIO") + ", " +
				"PREFIJO=" + _db.CreateSqlParameterName("PREFIJO") + ", " +
				"FECHA_CREACION=" + _db.CreateSqlParameterName("FECHA_CREACION") + ", " +
				"USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PROVEEDORES_ID",
				value.IsPROVEEDORES_IDNull ? DBNull.Value : (object)value.PROVEEDORES_ID);
			AddParameter(cmd, "NUMERO_TIMBRADO", value.NUMERO_TIMBRADO);
			AddParameter(cmd, "LIMITE_INFERIOR",
				value.IsLIMITE_INFERIORNull ? DBNull.Value : (object)value.LIMITE_INFERIOR);
			AddParameter(cmd, "LIMITE_SUPERIOR",
				value.IsLIMITE_SUPERIORNull ? DBNull.Value : (object)value.LIMITE_SUPERIOR);
			AddParameter(cmd, "FECHA_VENCIMIENTO",
				value.IsFECHA_VENCIMIENTONull ? DBNull.Value : (object)value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "FECHA_INICIO",
				value.IsFECHA_INICIONull ? DBNull.Value : (object)value.FECHA_INICIO);
			AddParameter(cmd, "PREFIJO", value.PREFIJO);
			AddParameter(cmd, "FECHA_CREACION",
				value.IsFECHA_CREACIONNull ? DBNull.Value : (object)value.FECHA_CREACION);
			AddParameter(cmd, "USUARIO_CREACION_ID",
				value.IsUSUARIO_CREACION_IDNull ? DBNull.Value : (object)value.USUARIO_CREACION_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "FLUJO_ID",
				value.IsFLUJO_IDNull ? DBNull.Value : (object)value.FLUJO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>AUTONUMERACIONES_PROVEEDOR</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>AUTONUMERACIONES_PROVEEDOR</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="AUTONUMERACIONES_PROVEEDORRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(AUTONUMERACIONES_PROVEEDORRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>AUTONUMERACIONES_PROVEEDOR</c> table using
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
		/// Deletes records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table using the 
		/// <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id)
		{
			return DeleteByFLUJO_ID(flujo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table using the 
		/// <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_ID(decimal flujo_id, bool flujo_idNull)
		{
			return CreateDeleteByFLUJO_IDCommand(flujo_id, flujo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUM_PROV_FLUJO_ID</c> foreign key.
		/// </summary>
		/// <param name="flujo_id">The <c>FLUJO_ID</c> column value.</param>
		/// <param name="flujo_idNull">true if the method ignores the flujo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_IDCommand(decimal flujo_id, bool flujo_idNull)
		{
			string whereSql = "";
			if(flujo_idNull)
				whereSql += "FLUJO_ID IS NULL";
			else
				whereSql += "FLUJO_ID=" + _db.CreateSqlParameterName("FLUJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!flujo_idNull)
				AddParameter(cmd, "FLUJO_ID", flujo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table using the 
		/// <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id)
		{
			return DeleteByUSUARIO_CREACION_ID(usuario_creacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table using the 
		/// <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_CREACION_ID(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			return CreateDeleteByUSUARIO_CREACION_IDCommand(usuario_creacion_id, usuario_creacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUM_PROV_USUARIO_CREA</c> foreign key.
		/// </summary>
		/// <param name="usuario_creacion_id">The <c>USUARIO_CREACION_ID</c> column value.</param>
		/// <param name="usuario_creacion_idNull">true if the method ignores the usuario_creacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_CREACION_IDCommand(decimal usuario_creacion_id, bool usuario_creacion_idNull)
		{
			string whereSql = "";
			if(usuario_creacion_idNull)
				whereSql += "USUARIO_CREACION_ID IS NULL";
			else
				whereSql += "USUARIO_CREACION_ID=" + _db.CreateSqlParameterName("USUARIO_CREACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_creacion_idNull)
				AddParameter(cmd, "USUARIO_CREACION_ID", usuario_creacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table using the 
		/// <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDORES_ID(decimal proveedores_id)
		{
			return DeleteByPROVEEDORES_ID(proveedores_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table using the 
		/// <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <param name="proveedores_idNull">true if the method ignores the proveedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDORES_ID(decimal proveedores_id, bool proveedores_idNull)
		{
			return CreateDeleteByPROVEEDORES_IDCommand(proveedores_id, proveedores_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_AUTONUM_PROVEE_</c> foreign key.
		/// </summary>
		/// <param name="proveedores_id">The <c>PROVEEDORES_ID</c> column value.</param>
		/// <param name="proveedores_idNull">true if the method ignores the proveedores_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDORES_IDCommand(decimal proveedores_id, bool proveedores_idNull)
		{
			string whereSql = "";
			if(proveedores_idNull)
				whereSql += "PROVEEDORES_ID IS NULL";
			else
				whereSql += "PROVEEDORES_ID=" + _db.CreateSqlParameterName("PROVEEDORES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedores_idNull)
				AddParameter(cmd, "PROVEEDORES_ID", proveedores_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>AUTONUMERACIONES_PROVEEDOR</c> records that match the specified criteria.
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
		/// to delete <c>AUTONUMERACIONES_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.AUTONUMERACIONES_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		protected AUTONUMERACIONES_PROVEEDORRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		protected AUTONUMERACIONES_PROVEEDORRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="AUTONUMERACIONES_PROVEEDORRow"/> objects.</returns>
		protected virtual AUTONUMERACIONES_PROVEEDORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int proveedores_idColumnIndex = reader.GetOrdinal("PROVEEDORES_ID");
			int numero_timbradoColumnIndex = reader.GetOrdinal("NUMERO_TIMBRADO");
			int limite_inferiorColumnIndex = reader.GetOrdinal("LIMITE_INFERIOR");
			int limite_superiorColumnIndex = reader.GetOrdinal("LIMITE_SUPERIOR");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int fecha_inicioColumnIndex = reader.GetOrdinal("FECHA_INICIO");
			int prefijoColumnIndex = reader.GetOrdinal("PREFIJO");
			int fecha_creacionColumnIndex = reader.GetOrdinal("FECHA_CREACION");
			int usuario_creacion_idColumnIndex = reader.GetOrdinal("USUARIO_CREACION_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int flujo_idColumnIndex = reader.GetOrdinal("FLUJO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					AUTONUMERACIONES_PROVEEDORRow record = new AUTONUMERACIONES_PROVEEDORRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedores_idColumnIndex))
						record.PROVEEDORES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedores_idColumnIndex)), 9);
					if(!reader.IsDBNull(numero_timbradoColumnIndex))
						record.NUMERO_TIMBRADO = Convert.ToString(reader.GetValue(numero_timbradoColumnIndex));
					if(!reader.IsDBNull(limite_inferiorColumnIndex))
						record.LIMITE_INFERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(limite_inferiorColumnIndex)), 9);
					if(!reader.IsDBNull(limite_superiorColumnIndex))
						record.LIMITE_SUPERIOR = Math.Round(Convert.ToDecimal(reader.GetValue(limite_superiorColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_vencimientoColumnIndex))
						record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					if(!reader.IsDBNull(fecha_inicioColumnIndex))
						record.FECHA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_inicioColumnIndex));
					if(!reader.IsDBNull(prefijoColumnIndex))
						record.PREFIJO = Convert.ToString(reader.GetValue(prefijoColumnIndex));
					if(!reader.IsDBNull(fecha_creacionColumnIndex))
						record.FECHA_CREACION = Convert.ToDateTime(reader.GetValue(fecha_creacionColumnIndex));
					if(!reader.IsDBNull(usuario_creacion_idColumnIndex))
						record.USUARIO_CREACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_creacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(flujo_idColumnIndex))
						record.FLUJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (AUTONUMERACIONES_PROVEEDORRow[])(recordList.ToArray(typeof(AUTONUMERACIONES_PROVEEDORRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="AUTONUMERACIONES_PROVEEDORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="AUTONUMERACIONES_PROVEEDORRow"/> object.</returns>
		protected virtual AUTONUMERACIONES_PROVEEDORRow MapRow(DataRow row)
		{
			AUTONUMERACIONES_PROVEEDORRow mappedObject = new AUTONUMERACIONES_PROVEEDORRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PROVEEDORES_ID"
			dataColumn = dataTable.Columns["PROVEEDORES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDORES_ID = (decimal)row[dataColumn];
			// Column "NUMERO_TIMBRADO"
			dataColumn = dataTable.Columns["NUMERO_TIMBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_TIMBRADO = (string)row[dataColumn];
			// Column "LIMITE_INFERIOR"
			dataColumn = dataTable.Columns["LIMITE_INFERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_INFERIOR = (decimal)row[dataColumn];
			// Column "LIMITE_SUPERIOR"
			dataColumn = dataTable.Columns["LIMITE_SUPERIOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIMITE_SUPERIOR = (decimal)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_INICIO"
			dataColumn = dataTable.Columns["FECHA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INICIO = (System.DateTime)row[dataColumn];
			// Column "PREFIJO"
			dataColumn = dataTable.Columns["PREFIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PREFIJO = (string)row[dataColumn];
			// Column "FECHA_CREACION"
			dataColumn = dataTable.Columns["FECHA_CREACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CREACION = (System.DateTime)row[dataColumn];
			// Column "USUARIO_CREACION_ID"
			dataColumn = dataTable.Columns["USUARIO_CREACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_CREACION_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "FLUJO_ID"
			dataColumn = dataTable.Columns["FLUJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>AUTONUMERACIONES_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "AUTONUMERACIONES_PROVEEDOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROVEEDORES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NUMERO_TIMBRADO", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("LIMITE_INFERIOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LIMITE_SUPERIOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PREFIJO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("FECHA_CREACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_CREACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("FLUJO_ID", typeof(decimal));
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

				case "PROVEEDORES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NUMERO_TIMBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIMITE_INFERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LIMITE_SUPERIOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PREFIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CREACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_CREACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FLUJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of AUTONUMERACIONES_PROVEEDORCollection_Base class
}  // End of namespace
