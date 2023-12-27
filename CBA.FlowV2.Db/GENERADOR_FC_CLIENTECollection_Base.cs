// <fileinfo name="GENERADOR_FC_CLIENTECollection_Base.cs">
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
	/// The base class for <see cref="GENERADOR_FC_CLIENTECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="GENERADOR_FC_CLIENTECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GENERADOR_FC_CLIENTECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string FUNCIONARIO_VENDEDOR_IDColumnName = "FUNCIONARIO_VENDEDOR_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string FECHAColumnName = "FECHA";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="GENERADOR_FC_CLIENTECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public GENERADOR_FC_CLIENTECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>GENERADOR_FC_CLIENTE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>GENERADOR_FC_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>GENERADOR_FC_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="GENERADOR_FC_CLIENTERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="GENERADOR_FC_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public GENERADOR_FC_CLIENTERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			GENERADOR_FC_CLIENTERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public GENERADOR_FC_CLIENTERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects that 
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
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.GENERADOR_FC_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="GENERADOR_FC_CLIENTERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="GENERADOR_FC_CLIENTERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual GENERADOR_FC_CLIENTERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			GENERADOR_FC_CLIENTERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENERADOR_FC_CLIENTE_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return MapRecords(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENERADOR_FC_CLIENTE_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_PAGO_IDCommand(decimal condicion_pago_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENERADOR_FC_CLIENTE_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public GENERADOR_FC_CLIENTERow[] GetByFUNCIONARIO_VENDEDOR_ID(decimal funcionario_vendedor_id)
		{
			return GetByFUNCIONARIO_VENDEDOR_ID(funcionario_vendedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <param name="funcionario_vendedor_idNull">true if the method ignores the funcionario_vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetByFUNCIONARIO_VENDEDOR_ID(decimal funcionario_vendedor_id, bool funcionario_vendedor_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_VENDEDOR_IDCommand(funcionario_vendedor_id, funcionario_vendedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_VENDEDOR_IDAsDataTable(decimal funcionario_vendedor_id)
		{
			return GetByFUNCIONARIO_VENDEDOR_IDAsDataTable(funcionario_vendedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <param name="funcionario_vendedor_idNull">true if the method ignores the funcionario_vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_VENDEDOR_IDAsDataTable(decimal funcionario_vendedor_id, bool funcionario_vendedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_VENDEDOR_IDCommand(funcionario_vendedor_id, funcionario_vendedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <param name="funcionario_vendedor_idNull">true if the method ignores the funcionario_vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_VENDEDOR_IDCommand(decimal funcionario_vendedor_id, bool funcionario_vendedor_idNull)
		{
			string whereSql = "";
			if(funcionario_vendedor_idNull)
				whereSql += "FUNCIONARIO_VENDEDOR_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_VENDEDOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_VENDEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_vendedor_idNull)
				AddParameter(cmd, "FUNCIONARIO_VENDEDOR_ID", funcionario_vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENERADOR_FC_CLIENTE_MON_ID</c> foreign key.
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
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public GENERADOR_FC_CLIENTERow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_IDAsDataTable(lista_precio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GENERADOR_FC_CLIENTERow"/> objects 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		public virtual GENERADOR_FC_CLIENTERow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GENERADOR_FC_CLIENTE_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GENERADOR_FC_CLIENTE_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>GENERADOR_FC_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GENERADOR_FC_CLIENTERow"/> object to be inserted.</param>
		public virtual void Insert(GENERADOR_FC_CLIENTERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.GENERADOR_FC_CLIENTE (" +
				"ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"AUTONUMERACION_ID, " +
				"LISTA_PRECIO_ID, " +
				"MONEDA_ID, " +
				"FUNCIONARIO_VENDEDOR_ID, " +
				"NOMBRE, " +
				"FECHA, " +
				"CONDICION_PAGO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_VENDEDOR_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "FUNCIONARIO_VENDEDOR_ID",
				value.IsFUNCIONARIO_VENDEDOR_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_VENDEDOR_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CONDICION_PAGO_ID", value.CONDICION_PAGO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>GENERADOR_FC_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GENERADOR_FC_CLIENTERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(GENERADOR_FC_CLIENTERow value)
		{
			
			string sqlStr = "UPDATE TRC.GENERADOR_FC_CLIENTE SET " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"FUNCIONARIO_VENDEDOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_VENDEDOR_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID", value.DEPOSITO_ID);
			AddParameter(cmd, "AUTONUMERACION_ID", value.AUTONUMERACION_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "FUNCIONARIO_VENDEDOR_ID",
				value.IsFUNCIONARIO_VENDEDOR_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_VENDEDOR_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CONDICION_PAGO_ID", value.CONDICION_PAGO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>GENERADOR_FC_CLIENTE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>GENERADOR_FC_CLIENTE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>GENERADOR_FC_CLIENTE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GENERADOR_FC_CLIENTERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(GENERADOR_FC_CLIENTERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>GENERADOR_FC_CLIENTE</c> table using
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
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENERADOR_FC_CLIENTE_AUT_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id)
		{
			string whereSql = "";
			whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return CreateDeleteByCONDICION_PAGO_IDCommand(condicion_pago_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENERADOR_FC_CLIENTE_CON_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_PAGO_IDCommand(decimal condicion_pago_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENERADOR_FC_CLIENTE_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id)
		{
			string whereSql = "";
			whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_VENDEDOR_ID(decimal funcionario_vendedor_id)
		{
			return DeleteByFUNCIONARIO_VENDEDOR_ID(funcionario_vendedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <param name="funcionario_vendedor_idNull">true if the method ignores the funcionario_vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_VENDEDOR_ID(decimal funcionario_vendedor_id, bool funcionario_vendedor_idNull)
		{
			return CreateDeleteByFUNCIONARIO_VENDEDOR_IDCommand(funcionario_vendedor_id, funcionario_vendedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENERADOR_FC_CLIENTE_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <param name="funcionario_vendedor_idNull">true if the method ignores the funcionario_vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_VENDEDOR_IDCommand(decimal funcionario_vendedor_id, bool funcionario_vendedor_idNull)
		{
			string whereSql = "";
			if(funcionario_vendedor_idNull)
				whereSql += "FUNCIONARIO_VENDEDOR_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_VENDEDOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_VENDEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_vendedor_idNull)
				AddParameter(cmd, "FUNCIONARIO_VENDEDOR_ID", funcionario_vendedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENERADOR_FC_CLIENTE_MON_ID</c> foreign key.
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
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return DeleteByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return CreateDeleteByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENERADOR_FC_CLIENTE_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLISTA_PRECIO_IDCommand(decimal lista_precio_id, bool lista_precio_idNull)
		{
			string whereSql = "";
			if(lista_precio_idNull)
				whereSql += "LISTA_PRECIO_ID IS NULL";
			else
				whereSql += "LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lista_precio_idNull)
				AddParameter(cmd, "LISTA_PRECIO_ID", lista_precio_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GENERADOR_FC_CLIENTE</c> table using the 
		/// <c>FK_GENERADOR_FC_CLIENTE_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GENERADOR_FC_CLIENTE_SUC_ID</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id)
		{
			string whereSql = "";
			whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>GENERADOR_FC_CLIENTE</c> records that match the specified criteria.
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
		/// to delete <c>GENERADOR_FC_CLIENTE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.GENERADOR_FC_CLIENTE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>GENERADOR_FC_CLIENTE</c> table.
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
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		protected GENERADOR_FC_CLIENTERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		protected GENERADOR_FC_CLIENTERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="GENERADOR_FC_CLIENTERow"/> objects.</returns>
		protected virtual GENERADOR_FC_CLIENTERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int funcionario_vendedor_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_VENDEDOR_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					GENERADOR_FC_CLIENTERow record = new GENERADOR_FC_CLIENTERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_vendedor_idColumnIndex))
						record.FUNCIONARIO_VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_vendedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(nombreColumnIndex))
						record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (GENERADOR_FC_CLIENTERow[])(recordList.ToArray(typeof(GENERADOR_FC_CLIENTERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="GENERADOR_FC_CLIENTERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="GENERADOR_FC_CLIENTERow"/> object.</returns>
		protected virtual GENERADOR_FC_CLIENTERow MapRow(DataRow row)
		{
			GENERADOR_FC_CLIENTERow mappedObject = new GENERADOR_FC_CLIENTERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_VENDEDOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>GENERADOR_FC_CLIENTE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "GENERADOR_FC_CLIENTE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_VENDEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
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

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of GENERADOR_FC_CLIENTECollection_Base class
}  // End of namespace
