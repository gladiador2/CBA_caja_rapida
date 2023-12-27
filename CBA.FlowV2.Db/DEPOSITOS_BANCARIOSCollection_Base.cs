// <fileinfo name="DEPOSITOS_BANCARIOSCollection_Base.cs">
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
	/// The base class for <see cref="DEPOSITOS_BANCARIOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="DEPOSITOS_BANCARIOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DEPOSITOS_BANCARIOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string DEPOSITO_DESDE_SUCColumnName = "DEPOSITO_DESDE_SUC";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_BANCARIA_IDColumnName = "CTACTE_BANCARIA_ID";
		public const string CTACTE_CAJA_TESORERIA_IDColumnName = "CTACTE_CAJA_TESORERIA_ID";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string TOTAL_EFECTIVOColumnName = "TOTAL_EFECTIVO";
		public const string TOTAL_CHEQUE_MISMO_BANCOColumnName = "TOTAL_CHEQUE_MISMO_BANCO";
		public const string TOTAL_CHEQUE_OTRO_BANCOColumnName = "TOTAL_CHEQUE_OTRO_BANCO";
		public const string TOTAL_IMPORTEColumnName = "TOTAL_IMPORTE";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TEXTO_PREDEFINIDO_IDColumnName = "TEXTO_PREDEFINIDO_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string INCLUYE_PERSONAColumnName = "INCLUYE_PERSONA";
		public const string CREAR_ANTICIPO_PERSONAColumnName = "CREAR_ANTICIPO_PERSONA";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEPOSITOS_BANCARIOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public DEPOSITOS_BANCARIOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>DEPOSITOS_BANCARIOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>DEPOSITOS_BANCARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>DEPOSITOS_BANCARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="DEPOSITOS_BANCARIOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="DEPOSITOS_BANCARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public DEPOSITOS_BANCARIOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			DEPOSITOS_BANCARIOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public DEPOSITOS_BANCARIOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects that 
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.DEPOSITOS_BANCARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="DEPOSITOS_BANCARIOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="DEPOSITOS_BANCARIOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual DEPOSITOS_BANCARIOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			DEPOSITOS_BANCARIOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public DEPOSITOS_BANCARIOSRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id)
		{
			return GetByTEXTO_PREDEFINIDO_IDAsDataTable(texto_predefinido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_IDAsDataTable(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCARIOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return MapRecords(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_BANCARIA_IDAsDataTable(decimal ctacte_bancaria_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCARIOS_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public DEPOSITOS_BANCARIOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public DEPOSITOS_BANCARIOSRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id)
		{
			return GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESORERIA_IDAsDataTable(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_tesoreria_idNull)
				whereSql += "CTACTE_CAJA_TESORERIA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_tesoreria_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public DEPOSITOS_BANCARIOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		public virtual DEPOSITOS_BANCARIOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_DEPOSITOS_BANCARIOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_DEPOSITOS_BANCARIOS_SUC</c> foreign key.
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
		/// Adds a new record into the <c>DEPOSITOS_BANCARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DEPOSITOS_BANCARIOSRow"/> object to be inserted.</param>
		public virtual void Insert(DEPOSITOS_BANCARIOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.DEPOSITOS_BANCARIOS (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"FUNCIONARIO_ID, " +
				"FECHA, " +
				"DEPOSITO_DESDE_SUC, " +
				"COTIZACION_MONEDA, " +
				"CTACTE_BANCARIA_ID, " +
				"CTACTE_CAJA_TESORERIA_ID, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"NRO_COMPROBANTE, " +
				"TOTAL_EFECTIVO, " +
				"TOTAL_CHEQUE_MISMO_BANCO, " +
				"TOTAL_CHEQUE_OTRO_BANCO, " +
				"TOTAL_IMPORTE, " +
				"OBSERVACION, " +
				"TEXTO_PREDEFINIDO_ID, " +
				"PERSONA_ID, " +
				"INCLUYE_PERSONA, " +
				"CREAR_ANTICIPO_PERSONA" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_DESDE_SUC") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("TOTAL_EFECTIVO") + ", " +
				_db.CreateSqlParameterName("TOTAL_CHEQUE_MISMO_BANCO") + ", " +
				_db.CreateSqlParameterName("TOTAL_CHEQUE_OTRO_BANCO") + ", " +
				_db.CreateSqlParameterName("TOTAL_IMPORTE") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("INCLUYE_PERSONA") + ", " +
				_db.CreateSqlParameterName("CREAR_ANTICIPO_PERSONA") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "DEPOSITO_DESDE_SUC", value.DEPOSITO_DESDE_SUC);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "TOTAL_EFECTIVO", value.TOTAL_EFECTIVO);
			AddParameter(cmd, "TOTAL_CHEQUE_MISMO_BANCO", value.TOTAL_CHEQUE_MISMO_BANCO);
			AddParameter(cmd, "TOTAL_CHEQUE_OTRO_BANCO", value.TOTAL_CHEQUE_OTRO_BANCO);
			AddParameter(cmd, "TOTAL_IMPORTE", value.TOTAL_IMPORTE);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "INCLUYE_PERSONA", value.INCLUYE_PERSONA);
			AddParameter(cmd, "CREAR_ANTICIPO_PERSONA", value.CREAR_ANTICIPO_PERSONA);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>DEPOSITOS_BANCARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DEPOSITOS_BANCARIOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(DEPOSITOS_BANCARIOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.DEPOSITOS_BANCARIOS SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"DEPOSITO_DESDE_SUC=" + _db.CreateSqlParameterName("DEPOSITO_DESDE_SUC") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID") + ", " +
				"CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"TOTAL_EFECTIVO=" + _db.CreateSqlParameterName("TOTAL_EFECTIVO") + ", " +
				"TOTAL_CHEQUE_MISMO_BANCO=" + _db.CreateSqlParameterName("TOTAL_CHEQUE_MISMO_BANCO") + ", " +
				"TOTAL_CHEQUE_OTRO_BANCO=" + _db.CreateSqlParameterName("TOTAL_CHEQUE_OTRO_BANCO") + ", " +
				"TOTAL_IMPORTE=" + _db.CreateSqlParameterName("TOTAL_IMPORTE") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"INCLUYE_PERSONA=" + _db.CreateSqlParameterName("INCLUYE_PERSONA") + ", " +
				"CREAR_ANTICIPO_PERSONA=" + _db.CreateSqlParameterName("CREAR_ANTICIPO_PERSONA") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "DEPOSITO_DESDE_SUC", value.DEPOSITO_DESDE_SUC);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", value.CTACTE_BANCARIA_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID",
				value.IsCTACTE_CAJA_TESORERIA_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESORERIA_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "TOTAL_EFECTIVO", value.TOTAL_EFECTIVO);
			AddParameter(cmd, "TOTAL_CHEQUE_MISMO_BANCO", value.TOTAL_CHEQUE_MISMO_BANCO);
			AddParameter(cmd, "TOTAL_CHEQUE_OTRO_BANCO", value.TOTAL_CHEQUE_OTRO_BANCO);
			AddParameter(cmd, "TOTAL_IMPORTE", value.TOTAL_IMPORTE);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID",
				value.IsTEXTO_PREDEFINIDO_IDNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "INCLUYE_PERSONA", value.INCLUYE_PERSONA);
			AddParameter(cmd, "CREAR_ANTICIPO_PERSONA", value.CREAR_ANTICIPO_PERSONA);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>DEPOSITOS_BANCARIOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>DEPOSITOS_BANCARIOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>DEPOSITOS_BANCARIOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="DEPOSITOS_BANCARIOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(DEPOSITOS_BANCARIOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>DEPOSITOS_BANCARIOS</c> table using
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
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID(texto_predefinido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(texto_predefinido_id, texto_predefinido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCA_TEX_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id">The <c>TEXTO_PREDEFINIDO_ID</c> column value.</param>
		/// <param name="texto_predefinido_idNull">true if the method ignores the texto_predefinido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_IDCommand(decimal texto_predefinido_id, bool texto_predefinido_idNull)
		{
			string whereSql = "";
			if(texto_predefinido_idNull)
				whereSql += "TEXTO_PREDEFINIDO_ID IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_idNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID", texto_predefinido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCARIOS_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id)
		{
			string whereSql = "";
			whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_BANCARIA_ID(decimal ctacte_bancaria_id)
		{
			return CreateDeleteByCTACTE_BANCARIA_IDCommand(ctacte_bancaria_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCARIOS_CTA</c> foreign key.
		/// </summary>
		/// <param name="ctacte_bancaria_id">The <c>CTACTE_BANCARIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_BANCARIA_IDCommand(decimal ctacte_bancaria_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_BANCARIA_ID=" + _db.CreateSqlParameterName("CTACTE_BANCARIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_BANCARIA_ID", ctacte_bancaria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCARIOS_CTAS</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_SUCURSAL_IDCommand(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_sucursal_idNull)
				whereSql += "CTACTE_CAJA_SUCURSAL_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_sucursal_idNull)
				AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID", ctacte_caja_sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id)
		{
			return DeleteByCTACTE_CAJA_TESORERIA_ID(ctacte_caja_tesoreria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESORERIA_ID(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(ctacte_caja_tesoreria_id, ctacte_caja_tesoreria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCARIOS_CTAT</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_tesoreria_id">The <c>CTACTE_CAJA_TESORERIA_ID</c> column value.</param>
		/// <param name="ctacte_caja_tesoreria_idNull">true if the method ignores the ctacte_caja_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESORERIA_IDCommand(decimal ctacte_caja_tesoreria_id, bool ctacte_caja_tesoreria_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_tesoreria_idNull)
				whereSql += "CTACTE_CAJA_TESORERIA_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESORERIA_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESORERIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_tesoreria_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESORERIA_ID", ctacte_caja_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCARIOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_IDCommand(decimal funcionario_id)
		{
			string whereSql = "";
			whereSql += "FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FUNCIONARIO_ID", funcionario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCARIOS_PERS</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>DEPOSITOS_BANCARIOS</c> table using the 
		/// <c>FK_DEPOSITOS_BANCARIOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_DEPOSITOS_BANCARIOS_SUC</c> foreign key.
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
		/// Deletes <c>DEPOSITOS_BANCARIOS</c> records that match the specified criteria.
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
		/// to delete <c>DEPOSITOS_BANCARIOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.DEPOSITOS_BANCARIOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>DEPOSITOS_BANCARIOS</c> table.
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		protected DEPOSITOS_BANCARIOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		protected DEPOSITOS_BANCARIOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="DEPOSITOS_BANCARIOSRow"/> objects.</returns>
		protected virtual DEPOSITOS_BANCARIOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int deposito_desde_sucColumnIndex = reader.GetOrdinal("DEPOSITO_DESDE_SUC");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_bancaria_idColumnIndex = reader.GetOrdinal("CTACTE_BANCARIA_ID");
			int ctacte_caja_tesoreria_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESORERIA_ID");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int total_efectivoColumnIndex = reader.GetOrdinal("TOTAL_EFECTIVO");
			int total_cheque_mismo_bancoColumnIndex = reader.GetOrdinal("TOTAL_CHEQUE_MISMO_BANCO");
			int total_cheque_otro_bancoColumnIndex = reader.GetOrdinal("TOTAL_CHEQUE_OTRO_BANCO");
			int total_importeColumnIndex = reader.GetOrdinal("TOTAL_IMPORTE");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int texto_predefinido_idColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int incluye_personaColumnIndex = reader.GetOrdinal("INCLUYE_PERSONA");
			int crear_anticipo_personaColumnIndex = reader.GetOrdinal("CREAR_ANTICIPO_PERSONA");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					DEPOSITOS_BANCARIOSRow record = new DEPOSITOS_BANCARIOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.DEPOSITO_DESDE_SUC = Convert.ToString(reader.GetValue(deposito_desde_sucColumnIndex));
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_BANCARIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_bancaria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_tesoreria_idColumnIndex))
						record.CTACTE_CAJA_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					record.TOTAL_EFECTIVO = Math.Round(Convert.ToDecimal(reader.GetValue(total_efectivoColumnIndex)), 9);
					record.TOTAL_CHEQUE_MISMO_BANCO = Math.Round(Convert.ToDecimal(reader.GetValue(total_cheque_mismo_bancoColumnIndex)), 9);
					record.TOTAL_CHEQUE_OTRO_BANCO = Math.Round(Convert.ToDecimal(reader.GetValue(total_cheque_otro_bancoColumnIndex)), 9);
					record.TOTAL_IMPORTE = Math.Round(Convert.ToDecimal(reader.GetValue(total_importeColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_idColumnIndex))
						record.TEXTO_PREDEFINIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.INCLUYE_PERSONA = Convert.ToString(reader.GetValue(incluye_personaColumnIndex));
					record.CREAR_ANTICIPO_PERSONA = Convert.ToString(reader.GetValue(crear_anticipo_personaColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (DEPOSITOS_BANCARIOSRow[])(recordList.ToArray(typeof(DEPOSITOS_BANCARIOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="DEPOSITOS_BANCARIOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="DEPOSITOS_BANCARIOSRow"/> object.</returns>
		protected virtual DEPOSITOS_BANCARIOSRow MapRow(DataRow row)
		{
			DEPOSITOS_BANCARIOSRow mappedObject = new DEPOSITOS_BANCARIOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "DEPOSITO_DESDE_SUC"
			dataColumn = dataTable.Columns["DEPOSITO_DESDE_SUC"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_DESDE_SUC = (string)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "CTACTE_BANCARIA_ID"
			dataColumn = dataTable.Columns["CTACTE_BANCARIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_BANCARIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESORERIA_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "TOTAL_EFECTIVO"
			dataColumn = dataTable.Columns["TOTAL_EFECTIVO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_EFECTIVO = (decimal)row[dataColumn];
			// Column "TOTAL_CHEQUE_MISMO_BANCO"
			dataColumn = dataTable.Columns["TOTAL_CHEQUE_MISMO_BANCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CHEQUE_MISMO_BANCO = (decimal)row[dataColumn];
			// Column "TOTAL_CHEQUE_OTRO_BANCO"
			dataColumn = dataTable.Columns["TOTAL_CHEQUE_OTRO_BANCO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_CHEQUE_OTRO_BANCO = (decimal)row[dataColumn];
			// Column "TOTAL_IMPORTE"
			dataColumn = dataTable.Columns["TOTAL_IMPORTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMPORTE = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "INCLUYE_PERSONA"
			dataColumn = dataTable.Columns["INCLUYE_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUYE_PERSONA = (string)row[dataColumn];
			// Column "CREAR_ANTICIPO_PERSONA"
			dataColumn = dataTable.Columns["CREAR_ANTICIPO_PERSONA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREAR_ANTICIPO_PERSONA = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>DEPOSITOS_BANCARIOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "DEPOSITOS_BANCARIOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEPOSITO_DESDE_SUC", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_BANCARIA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESORERIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TOTAL_EFECTIVO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_CHEQUE_MISMO_BANCO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_CHEQUE_OTRO_BANCO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_IMPORTE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 300;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INCLUYE_PERSONA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CREAR_ANTICIPO_PERSONA", typeof(string));
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

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "DEPOSITO_DESDE_SUC":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_BANCARIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_EFECTIVO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CHEQUE_MISMO_BANCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_CHEQUE_OTRO_BANCO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMPORTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INCLUYE_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CREAR_ANTICIPO_PERSONA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of DEPOSITOS_BANCARIOSCollection_Base class
}  // End of namespace
