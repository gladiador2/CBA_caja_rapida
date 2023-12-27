// <fileinfo name="DEPOSITO_PREPARACION_ESTADOCollection_Base.cs">
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
	/// The base class for <see cref="DEPOSITO_PREPARACION_ESTADOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DEPOSITO_PREPARACION_ESTADOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DEPOSITO_PREPARACION_ESTADOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PEDIDO_CLIENTE_IDColumnName = "PEDIDO_CLIENTE_ID";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string FUNCIONARIO_PREPARACION_IDColumnName = "FUNCIONARIO_PREPARACION_ID";
		public const string DEPOSITO_ESTADOColumnName = "DEPOSITO_ESTADO";
		public const string FECHAColumnName = "FECHA";
		public const string PUEDE_PROCESARColumnName = "PUEDE_PROCESAR";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string ESTADOColumnName = "ESTADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITO_PREPARACION_ESTADOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DEPOSITO_PREPARACION_ESTADOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public virtual DEPOSITO_PREPARACION_ESTADORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DEPOSITO_PREPARACION_ESTADORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DEPOSITO_PREPARACION_ESTADORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public DEPOSITO_PREPARACION_ESTADORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects that 
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
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public virtual DEPOSITO_PREPARACION_ESTADORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DEPOSITO_PREPARACION_ESTADO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DEPOSITO_PREPARACION_ESTADORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DEPOSITO_PREPARACION_ESTADORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DEPOSITO_PREPARACION_ESTADORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects 
		/// by the <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public DEPOSITO_PREPARACION_ESTADORow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects 
		/// by the <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public virtual DEPOSITO_PREPARACION_ESTADORow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects 
		/// by the <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public DEPOSITO_PREPARACION_ESTADORow[] GetByFUNCIONARIO_PREPARACION_ID(decimal funcionario_preparacion_id)
		{
			return GetByFUNCIONARIO_PREPARACION_ID(funcionario_preparacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects 
		/// by the <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <param name="funcionario_preparacion_idNull">true if the method ignores the funcionario_preparacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public virtual DEPOSITO_PREPARACION_ESTADORow[] GetByFUNCIONARIO_PREPARACION_ID(decimal funcionario_preparacion_id, bool funcionario_preparacion_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_PREPARACION_IDCommand(funcionario_preparacion_id, funcionario_preparacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_PREPARACION_IDAsDataTable(decimal funcionario_preparacion_id)
		{
			return GetByFUNCIONARIO_PREPARACION_IDAsDataTable(funcionario_preparacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <param name="funcionario_preparacion_idNull">true if the method ignores the funcionario_preparacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_PREPARACION_IDAsDataTable(decimal funcionario_preparacion_id, bool funcionario_preparacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_PREPARACION_IDCommand(funcionario_preparacion_id, funcionario_preparacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <param name="funcionario_preparacion_idNull">true if the method ignores the funcionario_preparacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_PREPARACION_IDCommand(decimal funcionario_preparacion_id, bool funcionario_preparacion_idNull)
		{
			string whereSql = "";
			if(funcionario_preparacion_idNull)
				whereSql += "FUNCIONARIO_PREPARACION_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_PREPARACION_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_PREPARACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_preparacion_idNull)
				AddParameter(cmd, "FUNCIONARIO_PREPARACION_ID", funcionario_preparacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects 
		/// by the <c>FK_DEP_PREP_ESTADO_PEDIDO_CLI</c> foreign key.
		/// </summary>
		/// <param name="pedido_cliente_id">The <c>PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public virtual DEPOSITO_PREPARACION_ESTADORow[] GetByPEDIDO_CLIENTE_ID(decimal pedido_cliente_id)
		{
			return MapRecords(CreateGetByPEDIDO_CLIENTE_IDCommand(pedido_cliente_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEP_PREP_ESTADO_PEDIDO_CLI</c> foreign key.
		/// </summary>
		/// <param name="pedido_cliente_id">The <c>PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPEDIDO_CLIENTE_IDAsDataTable(decimal pedido_cliente_id)
		{
			return MapRecordsToDataTable(CreateGetByPEDIDO_CLIENTE_IDCommand(pedido_cliente_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEP_PREP_ESTADO_PEDIDO_CLI</c> foreign key.
		/// </summary>
		/// <param name="pedido_cliente_id">The <c>PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPEDIDO_CLIENTE_IDCommand(decimal pedido_cliente_id)
		{
			string whereSql = "";
			whereSql += "PEDIDO_CLIENTE_ID=" + _db.CreateSqlParameterName("PEDIDO_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PEDIDO_CLIENTE_ID", pedido_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects 
		/// by the <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public DEPOSITO_PREPARACION_ESTADORow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects 
		/// by the <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		public virtual DEPOSITO_PREPARACION_ESTADORow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DEPOSITO_PREPARACION_ESTADORow"/> object to be inserted.</param>
		public virtual void Insert(DEPOSITO_PREPARACION_ESTADORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DEPOSITO_PREPARACION_ESTADO (" +
				"ID, " +
				"PEDIDO_CLIENTE_ID, " +
				"USUARIO_ID, " +
				"FUNCIONARIO_PREPARACION_ID, " +
				"DEPOSITO_ESTADO, " +
				"FECHA, " +
				"PUEDE_PROCESAR, " +
				"CANTIDAD, " +
				"ARTICULO_ID, " +
				"ESTADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PEDIDO_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_PREPARACION_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ESTADO") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("PUEDE_PROCESAR") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PEDIDO_CLIENTE_ID", value.PEDIDO_CLIENTE_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "FUNCIONARIO_PREPARACION_ID",
				value.IsFUNCIONARIO_PREPARACION_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_PREPARACION_ID);
			AddParameter(cmd, "DEPOSITO_ESTADO", value.DEPOSITO_ESTADO);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "PUEDE_PROCESAR", value.PUEDE_PROCESAR);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DEPOSITO_PREPARACION_ESTADORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DEPOSITO_PREPARACION_ESTADORow value)
		{
			
			string sqlStr = "UPDATE TRC.DEPOSITO_PREPARACION_ESTADO SET " +
				"PEDIDO_CLIENTE_ID=" + _db.CreateSqlParameterName("PEDIDO_CLIENTE_ID") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"FUNCIONARIO_PREPARACION_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_PREPARACION_ID") + ", " +
				"DEPOSITO_ESTADO=" + _db.CreateSqlParameterName("DEPOSITO_ESTADO") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"PUEDE_PROCESAR=" + _db.CreateSqlParameterName("PUEDE_PROCESAR") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PEDIDO_CLIENTE_ID", value.PEDIDO_CLIENTE_ID);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "FUNCIONARIO_PREPARACION_ID",
				value.IsFUNCIONARIO_PREPARACION_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_PREPARACION_ID);
			AddParameter(cmd, "DEPOSITO_ESTADO", value.DEPOSITO_ESTADO);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "PUEDE_PROCESAR", value.PUEDE_PROCESAR);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DEPOSITO_PREPARACION_ESTADO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DEPOSITO_PREPARACION_ESTADO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DEPOSITO_PREPARACION_ESTADORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DEPOSITO_PREPARACION_ESTADORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using
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
		/// Deletes records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using the 
		/// <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using the 
		/// <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id, articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEP_PREP_ARTICULO_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using the 
		/// <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_PREPARACION_ID(decimal funcionario_preparacion_id)
		{
			return DeleteByFUNCIONARIO_PREPARACION_ID(funcionario_preparacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using the 
		/// <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <param name="funcionario_preparacion_idNull">true if the method ignores the funcionario_preparacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_PREPARACION_ID(decimal funcionario_preparacion_id, bool funcionario_preparacion_idNull)
		{
			return CreateDeleteByFUNCIONARIO_PREPARACION_IDCommand(funcionario_preparacion_id, funcionario_preparacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEP_PREP_ESTADO_FUNCIO_PREP</c> foreign key.
		/// </summary>
		/// <param name="funcionario_preparacion_id">The <c>FUNCIONARIO_PREPARACION_ID</c> column value.</param>
		/// <param name="funcionario_preparacion_idNull">true if the method ignores the funcionario_preparacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_PREPARACION_IDCommand(decimal funcionario_preparacion_id, bool funcionario_preparacion_idNull)
		{
			string whereSql = "";
			if(funcionario_preparacion_idNull)
				whereSql += "FUNCIONARIO_PREPARACION_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_PREPARACION_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_PREPARACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_preparacion_idNull)
				AddParameter(cmd, "FUNCIONARIO_PREPARACION_ID", funcionario_preparacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using the 
		/// <c>FK_DEP_PREP_ESTADO_PEDIDO_CLI</c> foreign key.
		/// </summary>
		/// <param name="pedido_cliente_id">The <c>PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPEDIDO_CLIENTE_ID(decimal pedido_cliente_id)
		{
			return CreateDeleteByPEDIDO_CLIENTE_IDCommand(pedido_cliente_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEP_PREP_ESTADO_PEDIDO_CLI</c> foreign key.
		/// </summary>
		/// <param name="pedido_cliente_id">The <c>PEDIDO_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPEDIDO_CLIENTE_IDCommand(decimal pedido_cliente_id)
		{
			string whereSql = "";
			whereSql += "PEDIDO_CLIENTE_ID=" + _db.CreateSqlParameterName("PEDIDO_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PEDIDO_CLIENTE_ID", pedido_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using the 
		/// <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table using the 
		/// <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id, usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEP_PREP_ESTADO_PEDIDO_USU</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>DEPOSITO_PREPARACION_ESTADO</c> records that match the specified criteria.
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
		/// to delete <c>DEPOSITO_PREPARACION_ESTADO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DEPOSITO_PREPARACION_ESTADO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
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
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		protected DEPOSITO_PREPARACION_ESTADORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		protected DEPOSITO_PREPARACION_ESTADORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DEPOSITO_PREPARACION_ESTADORow"/> objects.</returns>
		protected virtual DEPOSITO_PREPARACION_ESTADORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pedido_cliente_idColumnIndex = reader.GetOrdinal("PEDIDO_CLIENTE_ID");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int funcionario_preparacion_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_PREPARACION_ID");
			int deposito_estadoColumnIndex = reader.GetOrdinal("DEPOSITO_ESTADO");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int puede_procesarColumnIndex = reader.GetOrdinal("PUEDE_PROCESAR");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DEPOSITO_PREPARACION_ESTADORow record = new DEPOSITO_PREPARACION_ESTADORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PEDIDO_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pedido_cliente_idColumnIndex)), 9);
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_preparacion_idColumnIndex))
						record.FUNCIONARIO_PREPARACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_preparacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_estadoColumnIndex))
						record.DEPOSITO_ESTADO = Convert.ToString(reader.GetValue(deposito_estadoColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.PUEDE_PROCESAR = Convert.ToString(reader.GetValue(puede_procesarColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DEPOSITO_PREPARACION_ESTADORow[])(recordList.ToArray(typeof(DEPOSITO_PREPARACION_ESTADORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DEPOSITO_PREPARACION_ESTADORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DEPOSITO_PREPARACION_ESTADORow"/> object.</returns>
		protected virtual DEPOSITO_PREPARACION_ESTADORow MapRow(DataRow row)
		{
			DEPOSITO_PREPARACION_ESTADORow mappedObject = new DEPOSITO_PREPARACION_ESTADORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PEDIDO_CLIENTE_ID"
			dataColumn = dataTable.Columns["PEDIDO_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PEDIDO_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_PREPARACION_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_PREPARACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_PREPARACION_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ESTADO"
			dataColumn = dataTable.Columns["DEPOSITO_ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ESTADO = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "PUEDE_PROCESAR"
			dataColumn = dataTable.Columns["PUEDE_PROCESAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUEDE_PROCESAR = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DEPOSITO_PREPARACION_ESTADO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DEPOSITO_PREPARACION_ESTADO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PEDIDO_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_PREPARACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ESTADO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PUEDE_PROCESAR", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
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

				case "PEDIDO_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_PREPARACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PUEDE_PROCESAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DEPOSITO_PREPARACION_ESTADOCollection_Base class
}  // End of namespace
