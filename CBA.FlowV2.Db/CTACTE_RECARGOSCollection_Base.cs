// <fileinfo name="CTACTE_RECARGOSCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_RECARGOSCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_RECARGOSCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_RECARGOSCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TIPO_RECARGOColumnName = "TIPO_RECARGO";
		public const string CASO_ORIGEN_IDColumnName = "CASO_ORIGEN_ID";
		public const string CTACTE_PAGO_PERSONA_DOC_IDColumnName = "CTACTE_PAGO_PERSONA_DOC_ID";
		public const string CTACTE_PAGO_PERSONA_RECARGO_IDColumnName = "CTACTE_PAGO_PERSONA_RECARGO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string FUNCIONARIO_IDColumnName = "FUNCIONARIO_ID";
		public const string CTACTE_CAJA_SUCURSAL_IDColumnName = "CTACTE_CAJA_SUCURSAL_ID";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACIONColumnName = "COTIZACION";
		public const string MONTOColumnName = "MONTO";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string FECHAColumnName = "FECHA";
		public const string CASO_FACTURA_IDColumnName = "CASO_FACTURA_ID";
		public const string APLICACION_DOCUMENTO_DOC_IDColumnName = "APLICACION_DOCUMENTO_DOC_ID";
		public const string APLICACION_DOCUMENTO_DOC_RE_IDColumnName = "APLICACION_DOCUMENTO_DOC_RE_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_RECARGOSCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_RECARGOSCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_RECARGOS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_RECARGOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_RECARGOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_RECARGOSRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_RECARGOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_RECARGOSRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_RECARGOSRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public CTACTE_RECARGOSRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_RECARGOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_RECARGOSRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_RECARGOSRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_RECARGOSRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_RECARGOSRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public CTACTE_RECARGOSRow[] GetByAPLICACION_DOCUMENTO_DOC_RE_ID(decimal aplicacion_documento_doc_re_id)
		{
			return GetByAPLICACION_DOCUMENTO_DOC_RE_ID(aplicacion_documento_doc_re_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_re_idNull">true if the method ignores the aplicacion_documento_doc_re_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByAPLICACION_DOCUMENTO_DOC_RE_ID(decimal aplicacion_documento_doc_re_id, bool aplicacion_documento_doc_re_idNull)
		{
			return MapRecords(CreateGetByAPLICACION_DOCUMENTO_DOC_RE_IDCommand(aplicacion_documento_doc_re_id, aplicacion_documento_doc_re_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPLICACION_DOCUMENTO_DOC_RE_IDAsDataTable(decimal aplicacion_documento_doc_re_id)
		{
			return GetByAPLICACION_DOCUMENTO_DOC_RE_IDAsDataTable(aplicacion_documento_doc_re_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_re_idNull">true if the method ignores the aplicacion_documento_doc_re_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPLICACION_DOCUMENTO_DOC_RE_IDAsDataTable(decimal aplicacion_documento_doc_re_id, bool aplicacion_documento_doc_re_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPLICACION_DOCUMENTO_DOC_RE_IDCommand(aplicacion_documento_doc_re_id, aplicacion_documento_doc_re_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_re_idNull">true if the method ignores the aplicacion_documento_doc_re_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPLICACION_DOCUMENTO_DOC_RE_IDCommand(decimal aplicacion_documento_doc_re_id, bool aplicacion_documento_doc_re_idNull)
		{
			string whereSql = "";
			if(aplicacion_documento_doc_re_idNull)
				whereSql += "APLICACION_DOCUMENTO_DOC_RE_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTO_DOC_RE_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_RE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aplicacion_documento_doc_re_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_RE_ID", aplicacion_documento_doc_re_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public CTACTE_RECARGOSRow[] GetByAPLICACION_DOCUMENTO_DOC_ID(decimal aplicacion_documento_doc_id)
		{
			return GetByAPLICACION_DOCUMENTO_DOC_ID(aplicacion_documento_doc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_idNull">true if the method ignores the aplicacion_documento_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByAPLICACION_DOCUMENTO_DOC_ID(decimal aplicacion_documento_doc_id, bool aplicacion_documento_doc_idNull)
		{
			return MapRecords(CreateGetByAPLICACION_DOCUMENTO_DOC_IDCommand(aplicacion_documento_doc_id, aplicacion_documento_doc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAPLICACION_DOCUMENTO_DOC_IDAsDataTable(decimal aplicacion_documento_doc_id)
		{
			return GetByAPLICACION_DOCUMENTO_DOC_IDAsDataTable(aplicacion_documento_doc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_idNull">true if the method ignores the aplicacion_documento_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAPLICACION_DOCUMENTO_DOC_IDAsDataTable(decimal aplicacion_documento_doc_id, bool aplicacion_documento_doc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAPLICACION_DOCUMENTO_DOC_IDCommand(aplicacion_documento_doc_id, aplicacion_documento_doc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_idNull">true if the method ignores the aplicacion_documento_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAPLICACION_DOCUMENTO_DOC_IDCommand(decimal aplicacion_documento_doc_id, bool aplicacion_documento_doc_idNull)
		{
			string whereSql = "";
			if(aplicacion_documento_doc_idNull)
				whereSql += "APLICACION_DOCUMENTO_DOC_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTO_DOC_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!aplicacion_documento_doc_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_ID", aplicacion_documento_doc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public CTACTE_RECARGOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <param name="ctacte_caja_sucursal_idNull">true if the method ignores the ctacte_caja_sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id, bool ctacte_caja_sucursal_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_SUCURSAL_IDCommand(ctacte_caja_sucursal_id, ctacte_caja_sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(decimal ctacte_caja_sucursal_id)
		{
			return GetByCTACTE_CAJA_SUCURSAL_IDAsDataTable(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public CTACTE_RECARGOSRow[] GetByCASO_FACTURA_ID(decimal caso_factura_id)
		{
			return GetByCASO_FACTURA_ID(caso_factura_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <param name="caso_factura_idNull">true if the method ignores the caso_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByCASO_FACTURA_ID(decimal caso_factura_id, bool caso_factura_idNull)
		{
			return MapRecords(CreateGetByCASO_FACTURA_IDCommand(caso_factura_id, caso_factura_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_FACTURA_IDAsDataTable(decimal caso_factura_id)
		{
			return GetByCASO_FACTURA_IDAsDataTable(caso_factura_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <param name="caso_factura_idNull">true if the method ignores the caso_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_FACTURA_IDAsDataTable(decimal caso_factura_id, bool caso_factura_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_FACTURA_IDCommand(caso_factura_id, caso_factura_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <param name="caso_factura_idNull">true if the method ignores the caso_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_FACTURA_IDCommand(decimal caso_factura_id, bool caso_factura_idNull)
		{
			string whereSql = "";
			if(caso_factura_idNull)
				whereSql += "CASO_FACTURA_ID IS NULL";
			else
				whereSql += "CASO_FACTURA_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_factura_idNull)
				AddParameter(cmd, "CASO_FACTURA_ID", caso_factura_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_CASO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return MapRecords(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_CASO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ORIGEN_IDAsDataTable(decimal caso_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ORIGEN_IDCommand(caso_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_CASO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ORIGEN_IDCommand(decimal caso_origen_id)
		{
			string whereSql = "";
			whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return MapRecords(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFUNCIONARIO_IDAsDataTable(decimal funcionario_id)
		{
			return MapRecordsToDataTable(CreateGetByFUNCIONARIO_IDCommand(funcionario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_FUNC</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByIMPUESTO_IDCommand(decimal impuesto_id)
		{
			string whereSql = "";
			whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public CTACTE_RECARGOSRow[] GetByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_doc_idNull">true if the method ignores the ctacte_pago_persona_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id, bool ctacte_pago_persona_doc_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_DOC_IDCommand(ctacte_pago_persona_doc_id, ctacte_pago_persona_doc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(decimal ctacte_pago_persona_doc_id)
		{
			return GetByCTACTE_PAGO_PERSONA_DOC_IDAsDataTable(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public CTACTE_RECARGOSRow[] GetByCTACTE_PAGO_PERSONA_RECARGO_ID(decimal ctacte_pago_persona_recargo_id)
		{
			return GetByCTACTE_PAGO_PERSONA_RECARGO_ID(ctacte_pago_persona_recargo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_recargo_idNull">true if the method ignores the ctacte_pago_persona_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByCTACTE_PAGO_PERSONA_RECARGO_ID(decimal ctacte_pago_persona_recargo_id, bool ctacte_pago_persona_recargo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGO_PERSONA_RECARGO_IDCommand(ctacte_pago_persona_recargo_id, ctacte_pago_persona_recargo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGO_PERSONA_RECARGO_IDAsDataTable(decimal ctacte_pago_persona_recargo_id)
		{
			return GetByCTACTE_PAGO_PERSONA_RECARGO_IDAsDataTable(ctacte_pago_persona_recargo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_recargo_idNull">true if the method ignores the ctacte_pago_persona_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGO_PERSONA_RECARGO_IDAsDataTable(decimal ctacte_pago_persona_recargo_id, bool ctacte_pago_persona_recargo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGO_PERSONA_RECARGO_IDCommand(ctacte_pago_persona_recargo_id, ctacte_pago_persona_recargo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_recargo_idNull">true if the method ignores the ctacte_pago_persona_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGO_PERSONA_RECARGO_IDCommand(decimal ctacte_pago_persona_recargo_id, bool ctacte_pago_persona_recargo_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_recargo_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_RECARGO_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_RECARGO_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_RECARGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pago_persona_recargo_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_RECARGO_ID", ctacte_pago_persona_recargo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_PERSONA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_RECARGOSRow"/> objects 
		/// by the <c>FK_CTACTE_RECARGOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		public virtual CTACTE_RECARGOSRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_RECARGOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_RECARGOS_SUC</c> foreign key.
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
		/// Adds a new record into the <c>CTACTE_RECARGOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_RECARGOSRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_RECARGOSRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_RECARGOS (" +
				"ID, " +
				"TIPO_RECARGO, " +
				"CASO_ORIGEN_ID, " +
				"CTACTE_PAGO_PERSONA_DOC_ID, " +
				"CTACTE_PAGO_PERSONA_RECARGO_ID, " +
				"SUCURSAL_ID, " +
				"FUNCIONARIO_ID, " +
				"CTACTE_CAJA_SUCURSAL_ID, " +
				"PERSONA_ID, " +
				"MONEDA_ID, " +
				"COTIZACION, " +
				"MONTO, " +
				"IMPUESTO_ID, " +
				"FECHA, " +
				"CASO_FACTURA_ID, " +
				"APLICACION_DOCUMENTO_DOC_ID, " +
				"APLICACION_DOCUMENTO_DOC_RE_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TIPO_RECARGO") + ", " +
				_db.CreateSqlParameterName("CASO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_RECARGO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION") + ", " +
				_db.CreateSqlParameterName("MONTO") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("CASO_FACTURA_ID") + ", " +
				_db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_ID") + ", " +
				_db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_RE_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TIPO_RECARGO", value.TIPO_RECARGO);
			AddParameter(cmd, "CASO_ORIGEN_ID", value.CASO_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID",
				value.IsCTACTE_PAGO_PERSONA_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_RECARGO_ID",
				value.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_RECARGO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CASO_FACTURA_ID",
				value.IsCASO_FACTURA_IDNull ? DBNull.Value : (object)value.CASO_FACTURA_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_ID",
				value.IsAPLICACION_DOCUMENTO_DOC_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTO_DOC_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_RE_ID",
				value.IsAPLICACION_DOCUMENTO_DOC_RE_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTO_DOC_RE_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_RECARGOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_RECARGOSRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_RECARGOSRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_RECARGOS SET " +
				"TIPO_RECARGO=" + _db.CreateSqlParameterName("TIPO_RECARGO") + ", " +
				"CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID") + ", " +
				"CTACTE_PAGO_PERSONA_DOC_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_DOC_ID") + ", " +
				"CTACTE_PAGO_PERSONA_RECARGO_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_RECARGO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"FUNCIONARIO_ID=" + _db.CreateSqlParameterName("FUNCIONARIO_ID") + ", " +
				"CTACTE_CAJA_SUCURSAL_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_SUCURSAL_ID") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION=" + _db.CreateSqlParameterName("COTIZACION") + ", " +
				"MONTO=" + _db.CreateSqlParameterName("MONTO") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"CASO_FACTURA_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_ID") + ", " +
				"APLICACION_DOCUMENTO_DOC_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_ID") + ", " +
				"APLICACION_DOCUMENTO_DOC_RE_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_RE_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TIPO_RECARGO", value.TIPO_RECARGO);
			AddParameter(cmd, "CASO_ORIGEN_ID", value.CASO_ORIGEN_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_DOC_ID",
				value.IsCTACTE_PAGO_PERSONA_DOC_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_DOC_ID);
			AddParameter(cmd, "CTACTE_PAGO_PERSONA_RECARGO_ID",
				value.IsCTACTE_PAGO_PERSONA_RECARGO_IDNull ? DBNull.Value : (object)value.CTACTE_PAGO_PERSONA_RECARGO_ID);
			AddParameter(cmd, "SUCURSAL_ID", value.SUCURSAL_ID);
			AddParameter(cmd, "FUNCIONARIO_ID", value.FUNCIONARIO_ID);
			AddParameter(cmd, "CTACTE_CAJA_SUCURSAL_ID",
				value.IsCTACTE_CAJA_SUCURSAL_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_SUCURSAL_ID);
			AddParameter(cmd, "PERSONA_ID", value.PERSONA_ID);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION", value.COTIZACION);
			AddParameter(cmd, "MONTO", value.MONTO);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "FECHA", value.FECHA);
			AddParameter(cmd, "CASO_FACTURA_ID",
				value.IsCASO_FACTURA_IDNull ? DBNull.Value : (object)value.CASO_FACTURA_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_ID",
				value.IsAPLICACION_DOCUMENTO_DOC_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTO_DOC_ID);
			AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_RE_ID",
				value.IsAPLICACION_DOCUMENTO_DOC_RE_IDNull ? DBNull.Value : (object)value.APLICACION_DOCUMENTO_DOC_RE_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_RECARGOS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_RECARGOS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_RECARGOS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_RECARGOSRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_RECARGOSRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_RECARGOS</c> table using
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
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTO_DOC_RE_ID(decimal aplicacion_documento_doc_re_id)
		{
			return DeleteByAPLICACION_DOCUMENTO_DOC_RE_ID(aplicacion_documento_doc_re_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_re_idNull">true if the method ignores the aplicacion_documento_doc_re_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTO_DOC_RE_ID(decimal aplicacion_documento_doc_re_id, bool aplicacion_documento_doc_re_idNull)
		{
			return CreateDeleteByAPLICACION_DOCUMENTO_DOC_RE_IDCommand(aplicacion_documento_doc_re_id, aplicacion_documento_doc_re_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_APL_D_DOC_R</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_re_id">The <c>APLICACION_DOCUMENTO_DOC_RE_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_re_idNull">true if the method ignores the aplicacion_documento_doc_re_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPLICACION_DOCUMENTO_DOC_RE_IDCommand(decimal aplicacion_documento_doc_re_id, bool aplicacion_documento_doc_re_idNull)
		{
			string whereSql = "";
			if(aplicacion_documento_doc_re_idNull)
				whereSql += "APLICACION_DOCUMENTO_DOC_RE_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTO_DOC_RE_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_RE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aplicacion_documento_doc_re_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_RE_ID", aplicacion_documento_doc_re_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTO_DOC_ID(decimal aplicacion_documento_doc_id)
		{
			return DeleteByAPLICACION_DOCUMENTO_DOC_ID(aplicacion_documento_doc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_idNull">true if the method ignores the aplicacion_documento_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAPLICACION_DOCUMENTO_DOC_ID(decimal aplicacion_documento_doc_id, bool aplicacion_documento_doc_idNull)
		{
			return CreateDeleteByAPLICACION_DOCUMENTO_DOC_IDCommand(aplicacion_documento_doc_id, aplicacion_documento_doc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_APL_DO_DOC</c> foreign key.
		/// </summary>
		/// <param name="aplicacion_documento_doc_id">The <c>APLICACION_DOCUMENTO_DOC_ID</c> column value.</param>
		/// <param name="aplicacion_documento_doc_idNull">true if the method ignores the aplicacion_documento_doc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAPLICACION_DOCUMENTO_DOC_IDCommand(decimal aplicacion_documento_doc_id, bool aplicacion_documento_doc_idNull)
		{
			string whereSql = "";
			if(aplicacion_documento_doc_idNull)
				whereSql += "APLICACION_DOCUMENTO_DOC_ID IS NULL";
			else
				whereSql += "APLICACION_DOCUMENTO_DOC_ID=" + _db.CreateSqlParameterName("APLICACION_DOCUMENTO_DOC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!aplicacion_documento_doc_idNull)
				AddParameter(cmd, "APLICACION_DOCUMENTO_DOC_ID", aplicacion_documento_doc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_sucursal_id">The <c>CTACTE_CAJA_SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_SUCURSAL_ID(decimal ctacte_caja_sucursal_id)
		{
			return DeleteByCTACTE_CAJA_SUCURSAL_ID(ctacte_caja_sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_RECARGOS_CAJA_SUC</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FACTURA_ID(decimal caso_factura_id)
		{
			return DeleteByCASO_FACTURA_ID(caso_factura_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <param name="caso_factura_idNull">true if the method ignores the caso_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FACTURA_ID(decimal caso_factura_id, bool caso_factura_idNull)
		{
			return CreateDeleteByCASO_FACTURA_IDCommand(caso_factura_id, caso_factura_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_CASO_FC</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_id">The <c>CASO_FACTURA_ID</c> column value.</param>
		/// <param name="caso_factura_idNull">true if the method ignores the caso_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_FACTURA_IDCommand(decimal caso_factura_id, bool caso_factura_idNull)
		{
			string whereSql = "";
			if(caso_factura_idNull)
				whereSql += "CASO_FACTURA_ID IS NULL";
			else
				whereSql += "CASO_FACTURA_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_factura_idNull)
				AddParameter(cmd, "CASO_FACTURA_ID", caso_factura_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_CASO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ORIGEN_ID(decimal caso_origen_id)
		{
			return CreateDeleteByCASO_ORIGEN_IDCommand(caso_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_CASO_ORIGEN</c> foreign key.
		/// </summary>
		/// <param name="caso_origen_id">The <c>CASO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ORIGEN_IDCommand(decimal caso_origen_id)
		{
			string whereSql = "";
			whereSql += "CASO_ORIGEN_ID=" + _db.CreateSqlParameterName("CASO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CASO_ORIGEN_ID", caso_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_FUNC</c> foreign key.
		/// </summary>
		/// <param name="funcionario_id">The <c>FUNCIONARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFUNCIONARIO_ID(decimal funcionario_id)
		{
			return CreateDeleteByFUNCIONARIO_IDCommand(funcionario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_FUNC</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByIMPUESTO_IDCommand(decimal impuesto_id)
		{
			string whereSql = "";
			whereSql += "IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "IMPUESTO_ID", impuesto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_doc_id">The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_DOC_ID(decimal ctacte_pago_persona_doc_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_DOC_ID(ctacte_pago_persona_doc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_RECARGOS_PAGO_PE_DOC</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_RECARGO_ID(decimal ctacte_pago_persona_recargo_id)
		{
			return DeleteByCTACTE_PAGO_PERSONA_RECARGO_ID(ctacte_pago_persona_recargo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_recargo_idNull">true if the method ignores the ctacte_pago_persona_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGO_PERSONA_RECARGO_ID(decimal ctacte_pago_persona_recargo_id, bool ctacte_pago_persona_recargo_idNull)
		{
			return CreateDeleteByCTACTE_PAGO_PERSONA_RECARGO_IDCommand(ctacte_pago_persona_recargo_id, ctacte_pago_persona_recargo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_PAGO_PE_REC</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pago_persona_recargo_id">The <c>CTACTE_PAGO_PERSONA_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_pago_persona_recargo_idNull">true if the method ignores the ctacte_pago_persona_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGO_PERSONA_RECARGO_IDCommand(decimal ctacte_pago_persona_recargo_id, bool ctacte_pago_persona_recargo_idNull)
		{
			string whereSql = "";
			if(ctacte_pago_persona_recargo_idNull)
				whereSql += "CTACTE_PAGO_PERSONA_RECARGO_ID IS NULL";
			else
				whereSql += "CTACTE_PAGO_PERSONA_RECARGO_ID=" + _db.CreateSqlParameterName("CTACTE_PAGO_PERSONA_RECARGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pago_persona_recargo_idNull)
				AddParameter(cmd, "CTACTE_PAGO_PERSONA_RECARGO_ID", ctacte_pago_persona_recargo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_PERSONA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_RECARGOS</c> table using the 
		/// <c>FK_CTACTE_RECARGOS_SUC</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_RECARGOS_SUC</c> foreign key.
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
		/// Deletes <c>CTACTE_RECARGOS</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_RECARGOS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_RECARGOS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_RECARGOS</c> table.
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
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		protected CTACTE_RECARGOSRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		protected CTACTE_RECARGOSRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_RECARGOSRow"/> objects.</returns>
		protected virtual CTACTE_RECARGOSRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tipo_recargoColumnIndex = reader.GetOrdinal("TIPO_RECARGO");
			int caso_origen_idColumnIndex = reader.GetOrdinal("CASO_ORIGEN_ID");
			int ctacte_pago_persona_doc_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_DOC_ID");
			int ctacte_pago_persona_recargo_idColumnIndex = reader.GetOrdinal("CTACTE_PAGO_PERSONA_RECARGO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int funcionario_idColumnIndex = reader.GetOrdinal("FUNCIONARIO_ID");
			int ctacte_caja_sucursal_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_SUCURSAL_ID");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacionColumnIndex = reader.GetOrdinal("COTIZACION");
			int montoColumnIndex = reader.GetOrdinal("MONTO");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int caso_factura_idColumnIndex = reader.GetOrdinal("CASO_FACTURA_ID");
			int aplicacion_documento_doc_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTO_DOC_ID");
			int aplicacion_documento_doc_re_idColumnIndex = reader.GetOrdinal("APLICACION_DOCUMENTO_DOC_RE_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_RECARGOSRow record = new CTACTE_RECARGOSRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TIPO_RECARGO = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_recargoColumnIndex)), 9);
					record.CASO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_doc_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_doc_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pago_persona_recargo_idColumnIndex))
						record.CTACTE_PAGO_PERSONA_RECARGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pago_persona_recargo_idColumnIndex)), 9);
					record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					record.FUNCIONARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(funcionario_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_sucursal_idColumnIndex))
						record.CTACTE_CAJA_SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_sucursal_idColumnIndex)), 9);
					record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacionColumnIndex)), 9);
					record.MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(montoColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(caso_factura_idColumnIndex))
						record.CASO_FACTURA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_factura_idColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_documento_doc_idColumnIndex))
						record.APLICACION_DOCUMENTO_DOC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documento_doc_idColumnIndex)), 9);
					if(!reader.IsDBNull(aplicacion_documento_doc_re_idColumnIndex))
						record.APLICACION_DOCUMENTO_DOC_RE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(aplicacion_documento_doc_re_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_RECARGOSRow[])(recordList.ToArray(typeof(CTACTE_RECARGOSRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_RECARGOSRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_RECARGOSRow"/> object.</returns>
		protected virtual CTACTE_RECARGOSRow MapRow(DataRow row)
		{
			CTACTE_RECARGOSRow mappedObject = new CTACTE_RECARGOSRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TIPO_RECARGO"
			dataColumn = dataTable.Columns["TIPO_RECARGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_RECARGO = (decimal)row[dataColumn];
			// Column "CASO_ORIGEN_ID"
			dataColumn = dataTable.Columns["CASO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_DOC_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_DOC_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGO_PERSONA_RECARGO_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGO_PERSONA_RECARGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGO_PERSONA_RECARGO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_ID"
			dataColumn = dataTable.Columns["SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "FUNCIONARIO_ID"
			dataColumn = dataTable.Columns["FUNCIONARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FUNCIONARIO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_SUCURSAL_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_SUCURSAL_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_SUCURSAL_ID = (decimal)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
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
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "CASO_FACTURA_ID"
			dataColumn = dataTable.Columns["CASO_FACTURA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FACTURA_ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTO_DOC_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTO_DOC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTO_DOC_ID = (decimal)row[dataColumn];
			// Column "APLICACION_DOCUMENTO_DOC_RE_ID"
			dataColumn = dataTable.Columns["APLICACION_DOCUMENTO_DOC_RE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.APLICACION_DOCUMENTO_DOC_RE_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_RECARGOS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_RECARGOS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_RECARGO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ORIGEN_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_DOC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGO_PERSONA_RECARGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FUNCIONARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_FACTURA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTO_DOC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("APLICACION_DOCUMENTO_DOC_RE_ID", typeof(decimal));
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

				case "TIPO_RECARGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGO_PERSONA_RECARGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FUNCIONARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_SUCURSAL_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
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

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CASO_FACTURA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCUMENTO_DOC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "APLICACION_DOCUMENTO_DOC_RE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_RECARGOSCollection_Base class
}  // End of namespace
