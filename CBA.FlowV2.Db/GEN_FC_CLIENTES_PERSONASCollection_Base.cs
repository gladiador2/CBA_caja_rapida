// <fileinfo name="GEN_FC_CLIENTES_PERSONASCollection_Base.cs">
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
	/// The base class for <see cref="GEN_FC_CLIENTES_PERSONASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="GEN_FC_CLIENTES_PERSONASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class GEN_FC_CLIENTES_PERSONASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string GENERACION_FC_CLIENTE_IDColumnName = "GENERACION_FC_CLIENTE_ID";
		public const string CONDICION_IDColumnName = "CONDICION_ID";
		public const string FUNCIONARIO_VENDEDOR_IDColumnName = "FUNCIONARIO_VENDEDOR_ID";
		public const string FECHAColumnName = "FECHA";
		public const string FACTURA_GENERADAColumnName = "FACTURA_GENERADA";
		public const string CASO_FACTURA_GENERADA_IDColumnName = "CASO_FACTURA_GENERADA_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string ANULADAColumnName = "ANULADA";
		public const string PAGADAColumnName = "PAGADA";
		public const string AFECTA_CTACTEColumnName = "AFECTA_CTACTE";
		public const string AFECTA_STOCKColumnName = "AFECTA_STOCK";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="GEN_FC_CLIENTES_PERSONASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public GEN_FC_CLIENTES_PERSONASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public GEN_FC_CLIENTES_PERSONASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			GEN_FC_CLIENTES_PERSONASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public GEN_FC_CLIENTES_PERSONASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects that 
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
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.GEN_FC_CLIENTES_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="GEN_FC_CLIENTES_PERSONASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			GEN_FC_CLIENTES_PERSONASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public GEN_FC_CLIENTES_PERSONASRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public GEN_FC_CLIENTES_PERSONASRow[] GetByCASO_FACTURA_GENERADA_ID(decimal caso_factura_generada_id)
		{
			return GetByCASO_FACTURA_GENERADA_ID(caso_factura_generada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <param name="caso_factura_generada_idNull">true if the method ignores the caso_factura_generada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetByCASO_FACTURA_GENERADA_ID(decimal caso_factura_generada_id, bool caso_factura_generada_idNull)
		{
			return MapRecords(CreateGetByCASO_FACTURA_GENERADA_IDCommand(caso_factura_generada_id, caso_factura_generada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_FACTURA_GENERADA_IDAsDataTable(decimal caso_factura_generada_id)
		{
			return GetByCASO_FACTURA_GENERADA_IDAsDataTable(caso_factura_generada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <param name="caso_factura_generada_idNull">true if the method ignores the caso_factura_generada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_FACTURA_GENERADA_IDAsDataTable(decimal caso_factura_generada_id, bool caso_factura_generada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_FACTURA_GENERADA_IDCommand(caso_factura_generada_id, caso_factura_generada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <param name="caso_factura_generada_idNull">true if the method ignores the caso_factura_generada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_FACTURA_GENERADA_IDCommand(decimal caso_factura_generada_id, bool caso_factura_generada_idNull)
		{
			string whereSql = "";
			if(caso_factura_generada_idNull)
				whereSql += "CASO_FACTURA_GENERADA_ID IS NULL";
			else
				whereSql += "CASO_FACTURA_GENERADA_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_GENERADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_factura_generada_idNull)
				AddParameter(cmd, "CASO_FACTURA_GENERADA_ID", caso_factura_generada_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_COND_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_id">The <c>CONDICION_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetByCONDICION_ID(decimal condicion_id)
		{
			return MapRecords(CreateGetByCONDICION_IDCommand(condicion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_COND_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_id">The <c>CONDICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_IDAsDataTable(decimal condicion_id)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_IDCommand(condicion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GEN_FC_CLIE_PER_COND_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_id">The <c>CONDICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_IDCommand(decimal condicion_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_ID=" + _db.CreateSqlParameterName("CONDICION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONDICION_ID", condicion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public GEN_FC_CLIENTES_PERSONASRow[] GetByFUNCIONARIO_VENDEDOR_ID(decimal funcionario_vendedor_id)
		{
			return GetByFUNCIONARIO_VENDEDOR_ID(funcionario_vendedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <param name="funcionario_vendedor_idNull">true if the method ignores the funcionario_vendedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetByFUNCIONARIO_VENDEDOR_ID(decimal funcionario_vendedor_id, bool funcionario_vendedor_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_VENDEDOR_IDCommand(funcionario_vendedor_id, funcionario_vendedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_VENDEDOR_IDAsDataTable(decimal funcionario_vendedor_id)
		{
			return GetByFUNCIONARIO_VENDEDOR_IDAsDataTable(funcionario_vendedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
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
		/// return records by the <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
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
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_GEN_ID</c> foreign key.
		/// </summary>
		/// <param name="generacion_fc_cliente_id">The <c>GENERACION_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetByGENERACION_FC_CLIENTE_ID(decimal generacion_fc_cliente_id)
		{
			return MapRecords(CreateGetByGENERACION_FC_CLIENTE_IDCommand(generacion_fc_cliente_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_GEN_ID</c> foreign key.
		/// </summary>
		/// <param name="generacion_fc_cliente_id">The <c>GENERACION_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByGENERACION_FC_CLIENTE_IDAsDataTable(decimal generacion_fc_cliente_id)
		{
			return MapRecordsToDataTable(CreateGetByGENERACION_FC_CLIENTE_IDCommand(generacion_fc_cliente_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GEN_FC_CLIE_PER_GEN_ID</c> foreign key.
		/// </summary>
		/// <param name="generacion_fc_cliente_id">The <c>GENERACION_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByGENERACION_FC_CLIENTE_IDCommand(decimal generacion_fc_cliente_id)
		{
			string whereSql = "";
			whereSql += "GENERACION_FC_CLIENTE_ID=" + _db.CreateSqlParameterName("GENERACION_FC_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "GENERACION_FC_CLIENTE_ID", generacion_fc_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public GEN_FC_CLIENTES_PERSONASRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects 
		/// by the <c>FK_GEN_FC_CLIE_PER_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		public virtual GEN_FC_CLIENTES_PERSONASRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_GEN_FC_CLIE_PER_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_GEN_FC_CLIE_PER_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GEN_FC_CLIENTES_PERSONASRow"/> object to be inserted.</param>
		public virtual void Insert(GEN_FC_CLIENTES_PERSONASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.GEN_FC_CLIENTES_PERSONAS (" +
				"ID, " +
				"PERSONA_ID, " +
				"GENERACION_FC_CLIENTE_ID, " +
				"CONDICION_ID, " +
				"FUNCIONARIO_VENDEDOR_ID, " +
				"FECHA, " +
				"FACTURA_GENERADA, " +
				"CASO_FACTURA_GENERADA_ID, " +
				"MONEDA_ID, " +
				"NRO_COMPROBANTE, " +
				"AUTONUMERACION_ID, " +
				"ANULADA, " +
				"PAGADA, " +
				"AFECTA_CTACTE, " +
				"AFECTA_STOCK" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("GENERACION_FC_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("CONDICION_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_VENDEDOR_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("FACTURA_GENERADA") + ", " +
				_db.CreateSqlParameterName("CASO_FACTURA_GENERADA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("ANULADA") + ", " +
				_db.CreateSqlParameterName("PAGADA") + ", " +
				_db.CreateSqlParameterName("AFECTA_CTACTE") + ", " +
				_db.CreateSqlParameterName("AFECTA_STOCK") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "GENERACION_FC_CLIENTE_ID", value.GENERACION_FC_CLIENTE_ID);
			AddParameter(cmd, "CONDICION_ID", value.CONDICION_ID);
			AddParameter(cmd, "FUNCIONARIO_VENDEDOR_ID",
				value.IsFUNCIONARIO_VENDEDOR_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_VENDEDOR_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FACTURA_GENERADA", value.FACTURA_GENERADA);
			AddParameter(cmd, "CASO_FACTURA_GENERADA_ID",
				value.IsCASO_FACTURA_GENERADA_IDNull ? DBNull.Value : (object)value.CASO_FACTURA_GENERADA_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "ANULADA", value.ANULADA);
			AddParameter(cmd, "PAGADA", value.PAGADA);
			AddParameter(cmd, "AFECTA_CTACTE", value.AFECTA_CTACTE);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GEN_FC_CLIENTES_PERSONASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(GEN_FC_CLIENTES_PERSONASRow value)
		{
			
			string sqlStr = "UPDATE TRC.GEN_FC_CLIENTES_PERSONAS SET " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"GENERACION_FC_CLIENTE_ID=" + _db.CreateSqlParameterName("GENERACION_FC_CLIENTE_ID") + ", " +
				"CONDICION_ID=" + _db.CreateSqlParameterName("CONDICION_ID") + ", " +
				"FUNCIONARIO_VENDEDOR_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_VENDEDOR_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"FACTURA_GENERADA=" + _db.CreateSqlParameterName("FACTURA_GENERADA") + ", " +
				"CASO_FACTURA_GENERADA_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_GENERADA_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"ANULADA=" + _db.CreateSqlParameterName("ANULADA") + ", " +
				"PAGADA=" + _db.CreateSqlParameterName("PAGADA") + ", " +
				"AFECTA_CTACTE=" + _db.CreateSqlParameterName("AFECTA_CTACTE") + ", " +
				"AFECTA_STOCK=" + _db.CreateSqlParameterName("AFECTA_STOCK") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "GENERACION_FC_CLIENTE_ID", value.GENERACION_FC_CLIENTE_ID);
			AddParameter(cmd, "CONDICION_ID", value.CONDICION_ID);
			AddParameter(cmd, "FUNCIONARIO_VENDEDOR_ID",
				value.IsFUNCIONARIO_VENDEDOR_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_VENDEDOR_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "FACTURA_GENERADA", value.FACTURA_GENERADA);
			AddParameter(cmd, "CASO_FACTURA_GENERADA_ID",
				value.IsCASO_FACTURA_GENERADA_IDNull ? DBNull.Value : (object)value.CASO_FACTURA_GENERADA_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "ANULADA", value.ANULADA);
			AddParameter(cmd, "PAGADA", value.PAGADA);
			AddParameter(cmd, "AFECTA_CTACTE", value.AFECTA_CTACTE);
			AddParameter(cmd, "AFECTA_STOCK", value.AFECTA_STOCK);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>GEN_FC_CLIENTES_PERSONAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>GEN_FC_CLIENTES_PERSONAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="GEN_FC_CLIENTES_PERSONASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(GEN_FC_CLIENTES_PERSONASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using
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
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return CreateDeleteByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GEN_FC_CLIE_PER_AUTONUM_ID</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_IDCommand(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			string whereSql = "";
			if(autonumeracion_idNull)
				whereSql += "AUTONUMERACION_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_idNull)
				AddParameter(cmd, "AUTONUMERACION_ID", autonumeracion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FACTURA_GENERADA_ID(decimal caso_factura_generada_id)
		{
			return DeleteByCASO_FACTURA_GENERADA_ID(caso_factura_generada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <param name="caso_factura_generada_idNull">true if the method ignores the caso_factura_generada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FACTURA_GENERADA_ID(decimal caso_factura_generada_id, bool caso_factura_generada_idNull)
		{
			return CreateDeleteByCASO_FACTURA_GENERADA_IDCommand(caso_factura_generada_id, caso_factura_generada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GEN_FC_CLIE_PER_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_generada_id">The <c>CASO_FACTURA_GENERADA_ID</c> column value.</param>
		/// <param name="caso_factura_generada_idNull">true if the method ignores the caso_factura_generada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_FACTURA_GENERADA_IDCommand(decimal caso_factura_generada_id, bool caso_factura_generada_idNull)
		{
			string whereSql = "";
			if(caso_factura_generada_idNull)
				whereSql += "CASO_FACTURA_GENERADA_ID IS NULL";
			else
				whereSql += "CASO_FACTURA_GENERADA_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_GENERADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_factura_generada_idNull)
				AddParameter(cmd, "CASO_FACTURA_GENERADA_ID", caso_factura_generada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_COND_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_id">The <c>CONDICION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_ID(decimal condicion_id)
		{
			return CreateDeleteByCONDICION_IDCommand(condicion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GEN_FC_CLIE_PER_COND_ID</c> foreign key.
		/// </summary>
		/// <param name="condicion_id">The <c>CONDICION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_IDCommand(decimal condicion_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_ID=" + _db.CreateSqlParameterName("CONDICION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONDICION_ID", condicion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
		/// </summary>
		/// <param name="funcionario_vendedor_id">The <c>FUNCIONARIO_VENDEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_VENDEDOR_ID(decimal funcionario_vendedor_id)
		{
			return DeleteByFUNCIONARIO_VENDEDOR_ID(funcionario_vendedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
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
		/// delete records using the <c>FK_GEN_FC_CLIE_PER_FUN_ID</c> foreign key.
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
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_GEN_ID</c> foreign key.
		/// </summary>
		/// <param name="generacion_fc_cliente_id">The <c>GENERACION_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByGENERACION_FC_CLIENTE_ID(decimal generacion_fc_cliente_id)
		{
			return CreateDeleteByGENERACION_FC_CLIENTE_IDCommand(generacion_fc_cliente_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GEN_FC_CLIE_PER_GEN_ID</c> foreign key.
		/// </summary>
		/// <param name="generacion_fc_cliente_id">The <c>GENERACION_FC_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByGENERACION_FC_CLIENTE_IDCommand(decimal generacion_fc_cliente_id)
		{
			string whereSql = "";
			whereSql += "GENERACION_FC_CLIENTE_ID=" + _db.CreateSqlParameterName("GENERACION_FC_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "GENERACION_FC_CLIENTE_ID", generacion_fc_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id, moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GEN_FC_CLIE_PER_MONEDA_ID</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_IDCommand(decimal moneda_id, bool moneda_idNull)
		{
			string whereSql = "";
			if(moneda_idNull)
				whereSql += "MONEDA_ID IS NULL";
			else
				whereSql += "MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_idNull)
				AddParameter(cmd, "MONEDA_ID", moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table using the 
		/// <c>FK_GEN_FC_CLIE_PER_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_GEN_FC_CLIE_PER_PERSONA_ID</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id)
		{
			string whereSql = "";
			whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>GEN_FC_CLIENTES_PERSONAS</c> records that match the specified criteria.
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
		/// to delete <c>GEN_FC_CLIENTES_PERSONAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.GEN_FC_CLIENTES_PERSONAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
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
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		protected GEN_FC_CLIENTES_PERSONASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		protected GEN_FC_CLIENTES_PERSONASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="GEN_FC_CLIENTES_PERSONASRow"/> objects.</returns>
		protected virtual GEN_FC_CLIENTES_PERSONASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int generacion_fc_cliente_idColumnIndex = reader.GetOrdinal("GENERACION_FC_CLIENTE_ID");
			int condicion_idColumnIndex = reader.GetOrdinal("CONDICION_ID");
			int funcionario_vendedor_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_VENDEDOR_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int factura_generadaColumnIndex = reader.GetOrdinal("FACTURA_GENERADA");
			int caso_factura_generada_idColumnIndex = reader.GetOrdinal("CASO_FACTURA_GENERADA_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int anuladaColumnIndex = reader.GetOrdinal("ANULADA");
			int pagadaColumnIndex = reader.GetOrdinal("PAGADA");
			int afecta_ctacteColumnIndex = reader.GetOrdinal("AFECTA_CTACTE");
			int afecta_stockColumnIndex = reader.GetOrdinal("AFECTA_STOCK");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					GEN_FC_CLIENTES_PERSONASRow record = new GEN_FC_CLIENTES_PERSONASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.GENERACION_FC_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(generacion_fc_cliente_idColumnIndex)), 9);
					record.CONDICION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_vendedor_idColumnIndex))
						record.FUNCIONARIO_VENDEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_vendedor_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.FACTURA_GENERADA = Convert.ToString(reader.GetValue(factura_generadaColumnIndex));
					if(!reader.IsDBNull(caso_factura_generada_idColumnIndex))
						record.CASO_FACTURA_GENERADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_factura_generada_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					record.ANULADA = Convert.ToString(reader.GetValue(anuladaColumnIndex));
					record.PAGADA = Convert.ToString(reader.GetValue(pagadaColumnIndex));
					record.AFECTA_CTACTE = Convert.ToString(reader.GetValue(afecta_ctacteColumnIndex));
					record.AFECTA_STOCK = Convert.ToString(reader.GetValue(afecta_stockColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (GEN_FC_CLIENTES_PERSONASRow[])(recordList.ToArray(typeof(GEN_FC_CLIENTES_PERSONASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="GEN_FC_CLIENTES_PERSONASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="GEN_FC_CLIENTES_PERSONASRow"/> object.</returns>
		protected virtual GEN_FC_CLIENTES_PERSONASRow MapRow(DataRow row)
		{
			GEN_FC_CLIENTES_PERSONASRow mappedObject = new GEN_FC_CLIENTES_PERSONASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "GENERACION_FC_CLIENTE_ID"
			dataColumn = dataTable.Columns["GENERACION_FC_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERACION_FC_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "CONDICION_ID"
			dataColumn = dataTable.Columns["CONDICION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_VENDEDOR_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_VENDEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_VENDEDOR_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "FACTURA_GENERADA"
			dataColumn = dataTable.Columns["FACTURA_GENERADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_GENERADA = (string)row[dataColumn];
			// Column "CASO_FACTURA_GENERADA_ID"
			dataColumn = dataTable.Columns["CASO_FACTURA_GENERADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FACTURA_GENERADA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "ANULADA"
			dataColumn = dataTable.Columns["ANULADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANULADA = (string)row[dataColumn];
			// Column "PAGADA"
			dataColumn = dataTable.Columns["PAGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGADA = (string)row[dataColumn];
			// Column "AFECTA_CTACTE"
			dataColumn = dataTable.Columns["AFECTA_CTACTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_CTACTE = (string)row[dataColumn];
			// Column "AFECTA_STOCK"
			dataColumn = dataTable.Columns["AFECTA_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_STOCK = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>GEN_FC_CLIENTES_PERSONAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "GEN_FC_CLIENTES_PERSONAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("GENERACION_FC_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONDICION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_VENDEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURA_GENERADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_FACTURA_GENERADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANULADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PAGADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_CTACTE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("AFECTA_STOCK", typeof(string));
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

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "GENERACION_FC_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_VENDEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FACTURA_GENERADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CASO_FACTURA_GENERADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANULADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PAGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_CTACTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "AFECTA_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of GEN_FC_CLIENTES_PERSONASCollection_Base class
}  // End of namespace
