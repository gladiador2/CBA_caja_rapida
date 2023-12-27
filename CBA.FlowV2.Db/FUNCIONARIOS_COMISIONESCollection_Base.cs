// <fileinfo name="FUNCIONARIOS_COMISIONESCollection_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_COMISIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FUNCIONARIOS_COMISIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_COMISIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_COMISIONColumnName = "TIPO_COMISION";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONTOColumnName = "MONTO";
		public const string COBRADOColumnName = "COBRADO";
		public const string FUNCIONARIO_BONIFICACION_IDColumnName = "FUNCIONARIO_BONIFICACION_ID";
		public const string FUNCIONARIO_DESCUENTO_IDColumnName = "FUNCIONARIO_DESCUENTO_ID";
		public const string ANHOColumnName = "ANHO";
		public const string TEMPORADA_IDColumnName = "TEMPORADA_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string TIPO_FUNCIONARIOColumnName = "TIPO_FUNCIONARIO";
		public const string CTACTE_PAGO_PERSONA_DOC_IDColumnName = "CTACTE_PAGO_PERSONA_DOC_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_COMISIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FUNCIONARIOS_COMISIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FUNCIONARIOS_COMISIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FUNCIONARIOS_COMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FUNCIONARIOS_COMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FUNCIONARIOS_COMISIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_COMISIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FUNCIONARIOS_COMISIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FUNCIONARIOS_COMISIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public FUNCIONARIOS_COMISIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FUNCIONARIOS_COMISIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FUNCIONARIOS_COMISIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FUNCIONARIOS_COMISIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FUNCIONARIOS_COMISIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public FUNCIONARIOS_COMISIONESRow[] GetByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_DOC_IDCommand(ctacte_pago_persona_doc_id, ctacte_pago_persona_doc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(decimal ctacte_pago_persona_doc_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_DOC_IDCommand(ctacte_pago_persona_doc_id, ctacte_pago_persona_doc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_DOC_IDCommand(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_doc_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pago_persona_doc_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID", ctacte_pago_persona_doc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public FUNCIONARIOS_COMISIONESRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id, bool caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public FUNCIONARIOS_COMISIONESRow[] GetByFUNCIONARIO_BONIFICACION_ID(decimal funcionario_bonificacion_id)
		{
			return GetByFUNCIONARIO_BONIFICACION_ID(funcionario_bonificacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <param name="funcionario_bonificacion_idNull">true if the method ignores the funcionario_bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByFUNCIONARIO_BONIFICACION_ID(decimal funcionario_bonificacion_id, bool funcionario_bonificacion_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_BONIFICACION_IDCommand(funcionario_bonificacion_id, funcionario_bonificacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_BONIFICACION_IDAsDataTable(decimal funcionario_bonificacion_id)
		{
			return GetByFUNCIONARIO_BONIFICACION_IDAsDataTable(funcionario_bonificacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <param name="funcionario_bonificacion_idNull">true if the method ignores the funcionario_bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_BONIFICACION_IDAsDataTable(decimal funcionario_bonificacion_id, bool funcionario_bonificacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_BONIFICACION_IDCommand(funcionario_bonificacion_id, funcionario_bonificacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <param name="funcionario_bonificacion_idNull">true if the method ignores the funcionario_bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_BONIFICACION_IDCommand(decimal funcionario_bonificacion_id, bool funcionario_bonificacion_idNull)
		{
			string whereSql = "";
			if(funcionario_bonificacion_idNull)
				whereSql += "FUNCIONARIO_BONIFICACION_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_BONIFICACION_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_BONIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_bonificacion_idNull)
				AddParameter(cmd, "FUNCIONARIO_BONIFICACION_ID", funcionario_bonificacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public FUNCIONARIOS_COMISIONESRow[] GetByFUNCIONARIO_DESCUENTO_ID(decimal funcionario_descuento_id)
		{
			return GetByFUNCIONARIO_DESCUENTO_ID(funcionario_descuento_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <param name="funcionario_descuento_idNull">true if the method ignores the funcionario_descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByFUNCIONARIO_DESCUENTO_ID(decimal funcionario_descuento_id, bool funcionario_descuento_idNull)
		{
			return MapRecords(CreateGetByFUNCIONARIO_DESCUENTO_IDCommand(funcionario_descuento_id, funcionario_descuento_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFUNCIONARIO_DESCUENTO_IDAsDataTable(decimal funcionario_descuento_id)
		{
			return GetByFUNCIONARIO_DESCUENTO_IDAsDataTable(funcionario_descuento_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <param name="funcionario_descuento_idNull">true if the method ignores the funcionario_descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_DESCUENTO_IDAsDataTable(decimal funcionario_descuento_id, bool funcionario_descuento_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_DESCUENTO_IDCommand(funcionario_descuento_id, funcionario_descuento_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <param name="funcionario_descuento_idNull">true if the method ignores the funcionario_descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFUNCIONARIO_DESCUENTO_IDCommand(decimal funcionario_descuento_id, bool funcionario_descuento_idNull)
		{
			string whereSql = "";
			if(funcionario_descuento_idNull)
				whereSql += "FUNCIONARIO_DESCUENTO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_DESCUENTO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_DESCUENTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!funcionario_descuento_idNull)
				AddParameter(cmd, "FUNCIONARIO_DESCUENTO_ID", funcionario_descuento_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_COMISIONES_FUNCIONARIO</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_COMISIONES_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public FUNCIONARIOS_COMISIONESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
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
		/// return records by the <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public FUNCIONARIOS_COMISIONESRow[] GetByTEMPORADA_ID(decimal temporada_id)
		{
			return GetByTEMPORADA_ID(temporada_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects 
		/// by the <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <param name="temporada_idNull">true if the method ignores the temporada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		public virtual FUNCIONARIOS_COMISIONESRow[] GetByTEMPORADA_ID(decimal temporada_id, bool temporada_idNull)
		{
			return MapRecords(CreateGetByTEMPORADA_IDCommand(temporada_id, temporada_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEMPORADA_IDAsDataTable(decimal temporada_id)
		{
			return GetByTEMPORADA_IDAsDataTable(temporada_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <param name="temporada_idNull">true if the method ignores the temporada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEMPORADA_IDAsDataTable(decimal temporada_id, bool temporada_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTEMPORADA_IDCommand(temporada_id, temporada_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <param name="temporada_idNull">true if the method ignores the temporada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEMPORADA_IDCommand(decimal temporada_id, bool temporada_idNull)
		{
			string whereSql = "";
			if(temporada_idNull)
				whereSql += "TEMPORADA_ID IS NULL";
			else
				whereSql += "TEMPORADA_ID=" + _db.CreateSqlParameterName("TEMPORADA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!temporada_idNull)
				AddParameter(cmd, "TEMPORADA_ID", temporada_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>FUNCIONARIOS_COMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_COMISIONESRow"/> object to be inserted.</param>
		public virtual void Insert(FUNCIONARIOS_COMISIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FUNCIONARIOS_COMISIONES (" +
				"ID, " +
				"TIPO_COMISION, " +
				"FUNCIONARIO_ID, " +
				"CASO_ID, " +
				"FECHA, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"MONTO, " +
				"COBRADO, " +
				"FUNCIONARIO_BONIFICACION_ID, " +
				"FUNCIONARIO_DESCUENTO_ID, " +
				"ANHO, " +
				"TEMPORADA_ID, " +
				"PERSONA_ID, " +
				"TIPO_FUNCIONARIO, " +
				"CTACTE_PAGO_PERSONA_DOC_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_COMISION") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("COBRADO") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_BONIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_DESCUENTO_ID") + ", " +
				_db.CreateSqlParameterName("ANHO") + ", " +
				_db.CreateSqlParameterName("TEMPORADA_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_FUNCIONARIO") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_COMISION", value.TIPO_COMISION);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			AddParameter(cmd, "FUNCIONARIO_BONIFICACION_ID",
				value.IsFUNCIONARIO_BONIFICACION_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_BONIFICACION_ID);
			AddParameter(cmd, "FUNCIONARIO_DESCUENTO_ID",
				value.IsFUNCIONARIO_DESCUENTO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_DESCUENTO_ID);
			AddParameter(cmd, "ANHO",
				value.IsANHONull ? DBNull.Value : (object)value.ANHO);
			AddParameter(cmd, "TEMPORADA_ID",
				value.IsTEMPORADA_IDNull ? DBNull.Value : (object)value.TEMPORADA_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "TIPO_FUNCIONARIO", value.TIPO_FUNCIONARIO);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID",
				value.IsCTACTE_PAGO_PERSONA_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DOC_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FUNCIONARIOS_COMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_COMISIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FUNCIONARIOS_COMISIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.FUNCIONARIOS_COMISIONES SET " +
				"TIPO_COMISION=" + _db.CreateSqlParameterName("TIPO_COMISION") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"COBRADO=" + _db.CreateSqlParameterName("COBRADO") + ", " +
				"FUNCIONARIO_BONIFICACION_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_BONIFICACION_ID") + ", " +
				"FUNCIONARIO_DESCUENTO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_DESCUENTO_ID") + ", " +
				"ANHO=" + _db.CreateSqlParameterName("ANHO") + ", " +
				"TEMPORADA_ID=" + _db.CreateSqlParameterName("TEMPORADA_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"TIPO_FUNCIONARIO=" + _db.CreateSqlParameterName("TIPO_FUNCIONARIO") + ", " +
				"CTACTE_PAGO_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_COMISION", value.TIPO_COMISION);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "COBRADO", value.COBRADO);
			AddParameter(cmd, "FUNCIONARIO_BONIFICACION_ID",
				value.IsFUNCIONARIO_BONIFICACION_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_BONIFICACION_ID);
			AddParameter(cmd, "FUNCIONARIO_DESCUENTO_ID",
				value.IsFUNCIONARIO_DESCUENTO_IDNull ? DBNull.Value : (object)value.FUNCIONARIO_DESCUENTO_ID);
			AddParameter(cmd, "ANHO",
				value.IsANHONull ? DBNull.Value : (object)value.ANHO);
			AddParameter(cmd, "TEMPORADA_ID",
				value.IsTEMPORADA_IDNull ? DBNull.Value : (object)value.TEMPORADA_ID);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "TIPO_FUNCIONARIO", value.TIPO_FUNCIONARIO);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID",
				value.IsCTACTE_PAGO_PERSONA_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DOC_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_COMISIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FUNCIONARIOS_COMISIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FUNCIONARIOS_COMISIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FUNCIONARIOS_COMISIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FUNCIONARIOS_COMISIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FUNCIONARIOS_COMISIONES</c> table using
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
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_DOC_IDCommand(ctacte_pago_persona_doc_id, ctacte_pago_persona_doc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_COMIS_CTACT_PAG_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_DOC_IDCommand(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_doc_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pago_persona_doc_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID", ctacte_pago_persona_doc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return CreateDeleteByCASO_IDCommand(caso_id, caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_COMISIONES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_IDCommand(decimal caso_id, bool caso_idNull)
		{
			string whereSql = "";
			if(caso_idNull)
				whereSql += "CASO_ID IS NULL";
			else
				whereSql += "CASO_ID=" + _db.CreateSqlParameterName("CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_idNull)
				AddParameter(cmd, "CASO_ID", caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_BONIFICACION_ID(decimal funcionario_bonificacion_id)
		{
			return DeleteByFUNCIONARIO_BONIFICACION_ID(funcionario_bonificacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <param name="funcionario_bonificacion_idNull">true if the method ignores the funcionario_bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_BONIFICACION_ID(decimal funcionario_bonificacion_id, bool funcionario_bonificacion_idNull)
		{
			return CreateDeleteByFUNCIONARIO_BONIFICACION_IDCommand(funcionario_bonificacion_id, funcionario_bonificacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_COMISIONES_FUNC_BONIF</c> foreign key.
		/// </summary>
		/// <param name="funcionario_bonificacion_id">The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</param>
		/// <param name="funcionario_bonificacion_idNull">true if the method ignores the funcionario_bonificacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_BONIFICACION_IDCommand(decimal funcionario_bonificacion_id, bool funcionario_bonificacion_idNull)
		{
			string whereSql = "";
			if(funcionario_bonificacion_idNull)
				whereSql += "FUNCIONARIO_BONIFICACION_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_BONIFICACION_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_BONIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_bonificacion_idNull)
				AddParameter(cmd, "FUNCIONARIO_BONIFICACION_ID", funcionario_bonificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_DESCUENTO_ID(decimal funcionario_descuento_id)
		{
			return DeleteByFUNCIONARIO_DESCUENTO_ID(funcionario_descuento_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <param name="funcionario_descuento_idNull">true if the method ignores the funcionario_descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_DESCUENTO_ID(decimal funcionario_descuento_id, bool funcionario_descuento_idNull)
		{
			return CreateDeleteByFUNCIONARIO_DESCUENTO_IDCommand(funcionario_descuento_id, funcionario_descuento_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_COMISIONES_FUNC_DESC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_descuento_id">The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</param>
		/// <param name="funcionario_descuento_idNull">true if the method ignores the funcionario_descuento_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFUNCIONARIO_DESCUENTO_IDCommand(decimal funcionario_descuento_id, bool funcionario_descuento_idNull)
		{
			string whereSql = "";
			if(funcionario_descuento_idNull)
				whereSql += "FUNCIONARIO_DESCUENTO_ID IS NULL";
			else
				whereSql += "FUNCIONARIO_DESCUENTO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_DESCUENTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!funcionario_descuento_idNull)
				AddParameter(cmd, "FUNCIONARIO_DESCUENTO_ID", funcionario_descuento_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_FUNCIONARIO</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_COMISIONES_FUNCIONARIO</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_COMISIONES_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
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
		/// delete records using the <c>FK_FUNC_COMISIONES_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEMPORADA_ID(decimal temporada_id)
		{
			return DeleteByTEMPORADA_ID(temporada_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FUNCIONARIOS_COMISIONES</c> table using the 
		/// <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <param name="temporada_idNull">true if the method ignores the temporada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEMPORADA_ID(decimal temporada_id, bool temporada_idNull)
		{
			return CreateDeleteByTEMPORADA_IDCommand(temporada_id, temporada_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FUNC_COMISIONES_TEMPORADA</c> foreign key.
		/// </summary>
		/// <param name="temporada_id">The <c>TEMPORADA_ID</c> column value.</param>
		/// <param name="temporada_idNull">true if the method ignores the temporada_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEMPORADA_IDCommand(decimal temporada_id, bool temporada_idNull)
		{
			string whereSql = "";
			if(temporada_idNull)
				whereSql += "TEMPORADA_ID IS NULL";
			else
				whereSql += "TEMPORADA_ID=" + _db.CreateSqlParameterName("TEMPORADA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!temporada_idNull)
				AddParameter(cmd, "TEMPORADA_ID", temporada_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>FUNCIONARIOS_COMISIONES</c> records that match the specified criteria.
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
		/// to delete <c>FUNCIONARIOS_COMISIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FUNCIONARIOS_COMISIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FUNCIONARIOS_COMISIONES</c> table.
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
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		protected FUNCIONARIOS_COMISIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		protected FUNCIONARIOS_COMISIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FUNCIONARIOS_COMISIONESRow"/> objects.</returns>
		protected virtual FUNCIONARIOS_COMISIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_comisionColumnIndex = reader.GetOrdinal("TIPO_COMISION");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int cobradoColumnIndex = reader.GetOrdinal("COBRADO");
			int funcionario_bonificacion_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_BONIFICACION_ID");
			int funcionario_descuento_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_DESCUENTO_ID");
			int anhoColumnIndex = reader.GetOrdinal("ANHO");
			int temporada_idColumnIndex = reader.GetOrdinal("TEMPORADA_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int tipo_funcionarioColumnIndex = reader.GetOrdinal("TIPO_FUNCIONARIO");
			int ctacte_pago_persona_doc_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DOC_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FUNCIONARIOS_COMISIONESRow record = new FUNCIONARIOS_COMISIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_COMISION = Convert.ToString(reader.GetValue(tipo_comisionColumnIndex));
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.COBRADO = Convert.ToString(reader.GetValue(cobradoColumnIndex));
					if(!reader.IsDBNull(funcionario_bonificacion_idColumnIndex))
						record.FUNCIONARIO_BONIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_bonificacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(funcionario_descuento_idColumnIndex))
						record.FUNCIONARIO_DESCUENTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_descuento_idColumnIndex)), 9);
					if(!reader.IsDBNull(anhoColumnIndex))
						record.ANHO = Math.Round(Convert.ToDecimal(reader.GetValue(anhoColumnIndex)), 9);
					if(!reader.IsDBNull(temporada_idColumnIndex))
						record.TEMPORADA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(temporada_idColumnIndex)), 9);
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.TIPO_FUNCIONARIO = Convert.ToString(reader.GetValue(tipo_funcionarioColumnIndex));
					if(!reader.IsDBNull(ctacte_pago_persona_doc_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_doc_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FUNCIONARIOS_COMISIONESRow[])(recordList.ToArray(typeof(FUNCIONARIOS_COMISIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FUNCIONARIOS_COMISIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FUNCIONARIOS_COMISIONESRow"/> object.</returns>
		protected virtual FUNCIONARIOS_COMISIONESRow MapRow(DataRow row)
		{
			FUNCIONARIOS_COMISIONESRow mappedObject = new FUNCIONARIOS_COMISIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_COMISION"
			dataColumn = dataTable.Columns["TIPO_COMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_COMISION = (string)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION"
			dataColumn = dataTable.Columns["COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION = (decimal)row[dataColumn];
			// Column "MONTO"
			dataColumn = dataTable.Columns["MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO = (decimal)row[dataColumn];
			// Column "COBRADO"
			dataColumn = dataTable.Columns["COBRADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COBRADO = (string)row[dataColumn];
			// Column "FUNCIONARIO_BONIFICACION_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_BONIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_BONIFICACION_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_DESCUENTO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_DESCUENTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_DESCUENTO_ID = (decimal)row[dataColumn];
			// Column "ANHO"
			dataColumn = dataTable.Columns["ANHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANHO = (decimal)row[dataColumn];
			// Column "TEMPORADA_ID"
			dataColumn = dataTable.Columns["TEMPORADA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEMPORADA_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "TIPO_FUNCIONARIO"
			dataColumn = dataTable.Columns["TIPO_FUNCIONARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_FUNCIONARIO = (string)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DOC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DOC_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FUNCIONARIOS_COMISIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FUNCIONARIOS_COMISIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_COMISION", typeof(string));
			dataColumn.MaxLength = 10;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COBRADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_BONIFICACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_DESCUENTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ANHO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TEMPORADA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_FUNCIONARIO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DOC_ID", typeof(decimal));
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

				case "TIPO_COMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COBRADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "FUNCIONARIO_BONIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_DESCUENTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TEMPORADA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_FUNCIONARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PAGO_PERSONA_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FUNCIONARIOS_COMISIONESCollection_Base class
}  // End of namespace
