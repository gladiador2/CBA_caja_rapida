// <fileinfo name="PAGO_CONTRATISTAS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="PAGO_CONTRATISTAS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PAGO_CONTRATISTAS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PAGO_CONTRATISTAS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PAGO_CONTRATISTA_IDColumnName = "PAGO_CONTRATISTA_ID";
		public const string FECHA_DESDEColumnName = "FECHA_DESDE";
		public const string FECHA_HASTAColumnName = "FECHA_HASTA";
		public const string CERTIFICADO_NROColumnName = "CERTIFICADO_NRO";
		public const string CERTIFICADOColumnName = "CERTIFICADO";
		public const string CERTIFICADO_MONTOColumnName = "CERTIFICADO_MONTO";
		public const string FONDO_FIJOColumnName = "FONDO_FIJO";
		public const string FONDO_FIJO_PAGADOColumnName = "FONDO_FIJO_PAGADO";
		public const string FACTURAS_PROVEEDORColumnName = "FACTURAS_PROVEEDOR";
		public const string FACTURAS_PROVEEDOR_PAGADOColumnName = "FACTURAS_PROVEEDOR_PAGADO";
		public const string ADELANTOSColumnName = "ADELANTOS";
		public const string ADELANTOS_PAGADOSColumnName = "ADELANTOS_PAGADOS";
		public const string ADELANTO_INICIALColumnName = "ADELANTO_INICIAL";
		public const string FONDO_REPAROColumnName = "FONDO_REPARO";
		public const string TOTALColumnName = "TOTAL";
		public const string TOTAL_IVAColumnName = "TOTAL_IVA";
		public const string RETENCIONColumnName = "RETENCION";
		public const string TOTAL_PAGARColumnName = "TOTAL_PAGAR";
		public const string PORCENTAJE_FONDO_REPAROColumnName = "PORCENTAJE_FONDO_REPARO";
		public const string CASO_RELACIONADO_IDColumnName = "CASO_RELACIONADO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PAGO_CONTRATISTAS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PAGO_CONTRATISTAS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		public virtual PAGO_CONTRATISTAS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PAGO_CONTRATISTAS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PAGO_CONTRATISTAS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		public PAGO_CONTRATISTAS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		public virtual PAGO_CONTRATISTAS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PAGO_CONTRATISTAS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PAGO_CONTRATISTAS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PAGO_CONTRATISTAS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects 
		/// by the <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		public PAGO_CONTRATISTAS_DETALLESRow[] GetByCASO_RELACIONADO_ID(decimal caso_relacionado_id)
		{
			return GetByCASO_RELACIONADO_ID(caso_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects 
		/// by the <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		public virtual PAGO_CONTRATISTAS_DETALLESRow[] GetByCASO_RELACIONADO_ID(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return MapRecords(CreateGetByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_RELACIONADO_IDAsDataTable(decimal caso_relacionado_id)
		{
			return GetByCASO_RELACIONADO_IDAsDataTable(caso_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_RELACIONADO_IDAsDataTable(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_RELACIONADO_IDCommand(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			string whereSql = "";
			if(caso_relacionado_idNull)
				whereSql += "CASO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_relacionado_idNull)
				AddParameter(cmd, "CASO_RELACIONADO_ID", caso_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects 
		/// by the <c>FK_PAGO_CONT_DET_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_id">The <c>PAGO_CONTRATISTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		public virtual PAGO_CONTRATISTAS_DETALLESRow[] GetByPAGO_CONTRATISTA_ID(decimal pago_contratista_id)
		{
			return MapRecords(CreateGetByPAGO_CONTRATISTA_IDCommand(pago_contratista_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PAGO_CONT_DET_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_id">The <c>PAGO_CONTRATISTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPAGO_CONTRATISTA_IDAsDataTable(decimal pago_contratista_id)
		{
			return MapRecordsToDataTable(CreateGetByPAGO_CONTRATISTA_IDCommand(pago_contratista_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PAGO_CONT_DET_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_id">The <c>PAGO_CONTRATISTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPAGO_CONTRATISTA_IDCommand(decimal pago_contratista_id)
		{
			string whereSql = "";
			whereSql += "PAGO_CONTRATISTA_ID=" + _db.CreateSqlParameterName("PAGO_CONTRATISTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PAGO_CONTRATISTA_ID", pago_contratista_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(PAGO_CONTRATISTAS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PAGO_CONTRATISTAS_DETALLES (" +
				"ID, " +
				"PAGO_CONTRATISTA_ID, " +
				"FECHA_DESDE, " +
				"FECHA_HASTA, " +
				"CERTIFICADO_NRO, " +
				"CERTIFICADO, " +
				"CERTIFICADO_MONTO, " +
				"FONDO_FIJO, " +
				"FONDO_FIJO_PAGADO, " +
				"FACTURAS_PROVEEDOR, " +
				"FACTURAS_PROVEEDOR_PAGADO, " +
				"ADELANTOS, " +
				"ADELANTOS_PAGADOS, " +
				"ADELANTO_INICIAL, " +
				"FONDO_REPARO, " +
				"TOTAL, " +
				"TOTAL_IVA, " +
				"RETENCION, " +
				"TOTAL_PAGAR, " +
				"PORCENTAJE_FONDO_REPARO, " +
				"CASO_RELACIONADO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PAGO_CONTRATISTA_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_DESDE") + ", " +
				_db.CreateSqlParameterName("FECHA_HASTA") + ", " +
				_db.CreateSqlParameterName("CERTIFICADO_NRO") + ", " +
				_db.CreateSqlParameterName("CERTIFICADO") + ", " +
				_db.CreateSqlParameterName("CERTIFICADO_MONTO") + ", " +
				_db.CreateSqlParameterName("FONDO_FIJO") + ", " +
				_db.CreateSqlParameterName("FONDO_FIJO_PAGADO") + ", " +
				_db.CreateSqlParameterName("FACTURAS_PROVEEDOR") + ", " +
				_db.CreateSqlParameterName("FACTURAS_PROVEEDOR_PAGADO") + ", " +
				_db.CreateSqlParameterName("ADELANTOS") + ", " +
				_db.CreateSqlParameterName("ADELANTOS_PAGADOS") + ", " +
				_db.CreateSqlParameterName("ADELANTO_INICIAL") + ", " +
				_db.CreateSqlParameterName("FONDO_REPARO") + ", " +
				_db.CreateSqlParameterName("TOTAL") + ", " +
				_db.CreateSqlParameterName("TOTAL_IVA") + ", " +
				_db.CreateSqlParameterName("RETENCION") + ", " +
				_db.CreateSqlParameterName("TOTAL_PAGAR") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_FONDO_REPARO") + ", " +
				_db.CreateSqlParameterName("CASO_RELACIONADO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PAGO_CONTRATISTA_ID", value.PAGO_CONTRATISTA_ID);
			AddParameter(cmd, "FECHA_DESDE",
				value.IsFECHA_DESDENull ? DBNull.Value : (object)value.FECHA_DESDE);
			AddParameter(cmd, "FECHA_HASTA",
				value.IsFECHA_HASTANull ? DBNull.Value : (object)value.FECHA_HASTA);
			AddParameter(cmd, "CERTIFICADO_NRO",
				value.IsCERTIFICADO_NRONull ? DBNull.Value : (object)value.CERTIFICADO_NRO);
			AddParameter(cmd, "CERTIFICADO", value.CERTIFICADO);
			AddParameter(cmd, "CERTIFICADO_MONTO", value.CERTIFICADO_MONTO);
			AddParameter(cmd, "FONDO_FIJO", value.FONDO_FIJO);
			AddParameter(cmd, "FONDO_FIJO_PAGADO", value.FONDO_FIJO_PAGADO);
			AddParameter(cmd, "FACTURAS_PROVEEDOR", value.FACTURAS_PROVEEDOR);
			AddParameter(cmd, "FACTURAS_PROVEEDOR_PAGADO", value.FACTURAS_PROVEEDOR_PAGADO);
			AddParameter(cmd, "ADELANTOS", value.ADELANTOS);
			AddParameter(cmd, "ADELANTOS_PAGADOS", value.ADELANTOS_PAGADOS);
			AddParameter(cmd, "ADELANTO_INICIAL", value.ADELANTO_INICIAL);
			AddParameter(cmd, "FONDO_REPARO", value.FONDO_REPARO);
			AddParameter(cmd, "TOTAL", value.TOTAL);
			AddParameter(cmd, "TOTAL_IVA", value.TOTAL_IVA);
			AddParameter(cmd, "RETENCION", value.RETENCION);
			AddParameter(cmd, "TOTAL_PAGAR", value.TOTAL_PAGAR);
			AddParameter(cmd, "PORCENTAJE_FONDO_REPARO",
				value.IsPORCENTAJE_FONDO_REPARONull ? DBNull.Value : (object)value.PORCENTAJE_FONDO_REPARO);
			AddParameter(cmd, "CASO_RELACIONADO_ID",
				value.IsCASO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CASO_RELACIONADO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PAGO_CONTRATISTAS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PAGO_CONTRATISTAS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.PAGO_CONTRATISTAS_DETALLES SET " +
				"PAGO_CONTRATISTA_ID=" + _db.CreateSqlParameterName("PAGO_CONTRATISTA_ID") + ", " +
				"FECHA_DESDE=" + _db.CreateSqlParameterName("FECHA_DESDE") + ", " +
				"FECHA_HASTA=" + _db.CreateSqlParameterName("FECHA_HASTA") + ", " +
				"CERTIFICADO_NRO=" + _db.CreateSqlParameterName("CERTIFICADO_NRO") + ", " +
				"CERTIFICADO=" + _db.CreateSqlParameterName("CERTIFICADO") + ", " +
				"CERTIFICADO_MONTO=" + _db.CreateSqlParameterName("CERTIFICADO_MONTO") + ", " +
				"FONDO_FIJO=" + _db.CreateSqlParameterName("FONDO_FIJO") + ", " +
				"FONDO_FIJO_PAGADO=" + _db.CreateSqlParameterName("FONDO_FIJO_PAGADO") + ", " +
				"FACTURAS_PROVEEDOR=" + _db.CreateSqlParameterName("FACTURAS_PROVEEDOR") + ", " +
				"FACTURAS_PROVEEDOR_PAGADO=" + _db.CreateSqlParameterName("FACTURAS_PROVEEDOR_PAGADO") + ", " +
				"ADELANTOS=" + _db.CreateSqlParameterName("ADELANTOS") + ", " +
				"ADELANTOS_PAGADOS=" + _db.CreateSqlParameterName("ADELANTOS_PAGADOS") + ", " +
				"ADELANTO_INICIAL=" + _db.CreateSqlParameterName("ADELANTO_INICIAL") + ", " +
				"FONDO_REPARO=" + _db.CreateSqlParameterName("FONDO_REPARO") + ", " +
				"TOTAL=" + _db.CreateSqlParameterName("TOTAL") + ", " +
				"TOTAL_IVA=" + _db.CreateSqlParameterName("TOTAL_IVA") + ", " +
				"RETENCION=" + _db.CreateSqlParameterName("RETENCION") + ", " +
				"TOTAL_PAGAR=" + _db.CreateSqlParameterName("TOTAL_PAGAR") + ", " +
				"PORCENTAJE_FONDO_REPARO=" + _db.CreateSqlParameterName("PORCENTAJE_FONDO_REPARO") + ", " +
				"CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PAGO_CONTRATISTA_ID", value.PAGO_CONTRATISTA_ID);
			AddParameter(cmd, "FECHA_DESDE",
				value.IsFECHA_DESDENull ? DBNull.Value : (object)value.FECHA_DESDE);
			AddParameter(cmd, "FECHA_HASTA",
				value.IsFECHA_HASTANull ? DBNull.Value : (object)value.FECHA_HASTA);
			AddParameter(cmd, "CERTIFICADO_NRO",
				value.IsCERTIFICADO_NRONull ? DBNull.Value : (object)value.CERTIFICADO_NRO);
			AddParameter(cmd, "CERTIFICADO", value.CERTIFICADO);
			AddParameter(cmd, "CERTIFICADO_MONTO", value.CERTIFICADO_MONTO);
			AddParameter(cmd, "FONDO_FIJO", value.FONDO_FIJO);
			AddParameter(cmd, "FONDO_FIJO_PAGADO", value.FONDO_FIJO_PAGADO);
			AddParameter(cmd, "FACTURAS_PROVEEDOR", value.FACTURAS_PROVEEDOR);
			AddParameter(cmd, "FACTURAS_PROVEEDOR_PAGADO", value.FACTURAS_PROVEEDOR_PAGADO);
			AddParameter(cmd, "ADELANTOS", value.ADELANTOS);
			AddParameter(cmd, "ADELANTOS_PAGADOS", value.ADELANTOS_PAGADOS);
			AddParameter(cmd, "ADELANTO_INICIAL", value.ADELANTO_INICIAL);
			AddParameter(cmd, "FONDO_REPARO", value.FONDO_REPARO);
			AddParameter(cmd, "TOTAL", value.TOTAL);
			AddParameter(cmd, "TOTAL_IVA", value.TOTAL_IVA);
			AddParameter(cmd, "RETENCION", value.RETENCION);
			AddParameter(cmd, "TOTAL_PAGAR", value.TOTAL_PAGAR);
			AddParameter(cmd, "PORCENTAJE_FONDO_REPARO",
				value.IsPORCENTAJE_FONDO_REPARONull ? DBNull.Value : (object)value.PORCENTAJE_FONDO_REPARO);
			AddParameter(cmd, "CASO_RELACIONADO_ID",
				value.IsCASO_RELACIONADO_IDNull ? DBNull.Value : (object)value.CASO_RELACIONADO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PAGO_CONTRATISTAS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PAGO_CONTRATISTAS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PAGO_CONTRATISTAS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PAGO_CONTRATISTAS_DETALLES</c> table using
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
		/// Deletes records from the <c>PAGO_CONTRATISTAS_DETALLES</c> table using the 
		/// <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELACIONADO_ID(decimal caso_relacionado_id)
		{
			return DeleteByCASO_RELACIONADO_ID(caso_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PAGO_CONTRATISTAS_DETALLES</c> table using the 
		/// <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_RELACIONADO_ID(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			return CreateDeleteByCASO_RELACIONADO_IDCommand(caso_relacionado_id, caso_relacionado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PAGO_CONT_DET_CASO_RELAC</c> foreign key.
		/// </summary>
		/// <param name="caso_relacionado_id">The <c>CASO_RELACIONADO_ID</c> column value.</param>
		/// <param name="caso_relacionado_idNull">true if the method ignores the caso_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_RELACIONADO_IDCommand(decimal caso_relacionado_id, bool caso_relacionado_idNull)
		{
			string whereSql = "";
			if(caso_relacionado_idNull)
				whereSql += "CASO_RELACIONADO_ID IS NULL";
			else
				whereSql += "CASO_RELACIONADO_ID=" + _db.CreateSqlParameterName("CASO_RELACIONADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_relacionado_idNull)
				AddParameter(cmd, "CASO_RELACIONADO_ID", caso_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PAGO_CONTRATISTAS_DETALLES</c> table using the 
		/// <c>FK_PAGO_CONT_DET_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_id">The <c>PAGO_CONTRATISTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPAGO_CONTRATISTA_ID(decimal pago_contratista_id)
		{
			return CreateDeleteByPAGO_CONTRATISTA_IDCommand(pago_contratista_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PAGO_CONT_DET_PAGO_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="pago_contratista_id">The <c>PAGO_CONTRATISTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPAGO_CONTRATISTA_IDCommand(decimal pago_contratista_id)
		{
			string whereSql = "";
			whereSql += "PAGO_CONTRATISTA_ID=" + _db.CreateSqlParameterName("PAGO_CONTRATISTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PAGO_CONTRATISTA_ID", pago_contratista_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PAGO_CONTRATISTAS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>PAGO_CONTRATISTAS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PAGO_CONTRATISTAS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		protected PAGO_CONTRATISTAS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		protected PAGO_CONTRATISTAS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> objects.</returns>
		protected virtual PAGO_CONTRATISTAS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pago_contratista_idColumnIndex = reader.GetOrdinal("PAGO_CONTRATISTA_ID");
			int fecha_desdeColumnIndex = reader.GetOrdinal("FECHA_DESDE");
			int fecha_hastaColumnIndex = reader.GetOrdinal("FECHA_HASTA");
			int certificado_nroColumnIndex = reader.GetOrdinal("CERTIFICADO_NRO");
			int certificadoColumnIndex = reader.GetOrdinal("CERTIFICADO");
			int certificado_montoColumnIndex = reader.GetOrdinal("CERTIFICADO_MONTO");
			int fondo_fijoColumnIndex = reader.GetOrdinal("FONDO_FIJO");
			int fondo_fijo_pagadoColumnIndex = reader.GetOrdinal("FONDO_FIJO_PAGADO");
			int facturas_proveedorColumnIndex = reader.GetOrdinal("FACTURAS_PROVEEDOR");
			int facturas_proveedor_pagadoColumnIndex = reader.GetOrdinal("FACTURAS_PROVEEDOR_PAGADO");
			int adelantosColumnIndex = reader.GetOrdinal("ADELANTOS");
			int adelantos_pagadosColumnIndex = reader.GetOrdinal("ADELANTOS_PAGADOS");
			int adelanto_inicialColumnIndex = reader.GetOrdinal("ADELANTO_INICIAL");
			int fondo_reparoColumnIndex = reader.GetOrdinal("FONDO_REPARO");
			int totalColumnIndex = reader.GetOrdinal("TOTAL");
			int total_ivaColumnIndex = reader.GetOrdinal("TOTAL_IVA");
			int retencionColumnIndex = reader.GetOrdinal("RETENCION");
			int total_pagarColumnIndex = reader.GetOrdinal("TOTAL_PAGAR");
			int porcentaje_fondo_reparoColumnIndex = reader.GetOrdinal("PORCENTAJE_FONDO_REPARO");
			int caso_relacionado_idColumnIndex = reader.GetOrdinal("CASO_RELACIONADO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PAGO_CONTRATISTAS_DETALLESRow record = new PAGO_CONTRATISTAS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PAGO_CONTRATISTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pago_contratista_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_desdeColumnIndex))
						record.FECHA_DESDE = Convert.ToDateTime(reader.GetValue(fecha_desdeColumnIndex));
					if(!reader.IsDBNull(fecha_hastaColumnIndex))
						record.FECHA_HASTA = Convert.ToDateTime(reader.GetValue(fecha_hastaColumnIndex));
					if(!reader.IsDBNull(certificado_nroColumnIndex))
						record.CERTIFICADO_NRO = Math.Round(Convert.ToDecimal(reader.GetValue(certificado_nroColumnIndex)), 9);
					if(!reader.IsDBNull(certificadoColumnIndex))
						record.CERTIFICADO = Convert.ToString(reader.GetValue(certificadoColumnIndex));
					record.CERTIFICADO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(certificado_montoColumnIndex)), 9);
					record.FONDO_FIJO = Math.Round(Convert.ToDecimal(reader.GetValue(fondo_fijoColumnIndex)), 9);
					record.FONDO_FIJO_PAGADO = Math.Round(Convert.ToDecimal(reader.GetValue(fondo_fijo_pagadoColumnIndex)), 9);
					record.FACTURAS_PROVEEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(facturas_proveedorColumnIndex)), 9);
					record.FACTURAS_PROVEEDOR_PAGADO = Math.Round(Convert.ToDecimal(reader.GetValue(facturas_proveedor_pagadoColumnIndex)), 9);
					record.ADELANTOS = Math.Round(Convert.ToDecimal(reader.GetValue(adelantosColumnIndex)), 9);
					record.ADELANTOS_PAGADOS = Math.Round(Convert.ToDecimal(reader.GetValue(adelantos_pagadosColumnIndex)), 9);
					record.ADELANTO_INICIAL = Math.Round(Convert.ToDecimal(reader.GetValue(adelanto_inicialColumnIndex)), 9);
					record.FONDO_REPARO = Math.Round(Convert.ToDecimal(reader.GetValue(fondo_reparoColumnIndex)), 9);
					record.TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(totalColumnIndex)), 9);
					record.TOTAL_IVA = Math.Round(Convert.ToDecimal(reader.GetValue(total_ivaColumnIndex)), 9);
					record.RETENCION = Math.Round(Convert.ToDecimal(reader.GetValue(retencionColumnIndex)), 9);
					record.TOTAL_PAGAR = Math.Round(Convert.ToDecimal(reader.GetValue(total_pagarColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_fondo_reparoColumnIndex))
						record.PORCENTAJE_FONDO_REPARO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_fondo_reparoColumnIndex)), 9);
					if(!reader.IsDBNull(caso_relacionado_idColumnIndex))
						record.CASO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_relacionado_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PAGO_CONTRATISTAS_DETALLESRow[])(recordList.ToArray(typeof(PAGO_CONTRATISTAS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PAGO_CONTRATISTAS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PAGO_CONTRATISTAS_DETALLESRow"/> object.</returns>
		protected virtual PAGO_CONTRATISTAS_DETALLESRow MapRow(DataRow row)
		{
			PAGO_CONTRATISTAS_DETALLESRow mappedObject = new PAGO_CONTRATISTAS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PAGO_CONTRATISTA_ID"
			dataColumn = dataTable.Columns["PAGO_CONTRATISTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PAGO_CONTRATISTA_ID = (decimal)row[dataColumn];
			// Column "FECHA_DESDE"
			dataColumn = dataTable.Columns["FECHA_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_DESDE = (System.DateTime)row[dataColumn];
			// Column "FECHA_HASTA"
			dataColumn = dataTable.Columns["FECHA_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HASTA = (System.DateTime)row[dataColumn];
			// Column "CERTIFICADO_NRO"
			dataColumn = dataTable.Columns["CERTIFICADO_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CERTIFICADO_NRO = (decimal)row[dataColumn];
			// Column "CERTIFICADO"
			dataColumn = dataTable.Columns["CERTIFICADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CERTIFICADO = (string)row[dataColumn];
			// Column "CERTIFICADO_MONTO"
			dataColumn = dataTable.Columns["CERTIFICADO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CERTIFICADO_MONTO = (decimal)row[dataColumn];
			// Column "FONDO_FIJO"
			dataColumn = dataTable.Columns["FONDO_FIJO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO = (decimal)row[dataColumn];
			// Column "FONDO_FIJO_PAGADO"
			dataColumn = dataTable.Columns["FONDO_FIJO_PAGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_FIJO_PAGADO = (decimal)row[dataColumn];
			// Column "FACTURAS_PROVEEDOR"
			dataColumn = dataTable.Columns["FACTURAS_PROVEEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAS_PROVEEDOR = (decimal)row[dataColumn];
			// Column "FACTURAS_PROVEEDOR_PAGADO"
			dataColumn = dataTable.Columns["FACTURAS_PROVEEDOR_PAGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAS_PROVEEDOR_PAGADO = (decimal)row[dataColumn];
			// Column "ADELANTOS"
			dataColumn = dataTable.Columns["ADELANTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ADELANTOS = (decimal)row[dataColumn];
			// Column "ADELANTOS_PAGADOS"
			dataColumn = dataTable.Columns["ADELANTOS_PAGADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ADELANTOS_PAGADOS = (decimal)row[dataColumn];
			// Column "ADELANTO_INICIAL"
			dataColumn = dataTable.Columns["ADELANTO_INICIAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.ADELANTO_INICIAL = (decimal)row[dataColumn];
			// Column "FONDO_REPARO"
			dataColumn = dataTable.Columns["FONDO_REPARO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO_REPARO = (decimal)row[dataColumn];
			// Column "TOTAL"
			dataColumn = dataTable.Columns["TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL = (decimal)row[dataColumn];
			// Column "TOTAL_IVA"
			dataColumn = dataTable.Columns["TOTAL_IVA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IVA = (decimal)row[dataColumn];
			// Column "RETENCION"
			dataColumn = dataTable.Columns["RETENCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.RETENCION = (decimal)row[dataColumn];
			// Column "TOTAL_PAGAR"
			dataColumn = dataTable.Columns["TOTAL_PAGAR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_PAGAR = (decimal)row[dataColumn];
			// Column "PORCENTAJE_FONDO_REPARO"
			dataColumn = dataTable.Columns["PORCENTAJE_FONDO_REPARO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_FONDO_REPARO = (decimal)row[dataColumn];
			// Column "CASO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["CASO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_RELACIONADO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PAGO_CONTRATISTAS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PAGO_CONTRATISTAS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PAGO_CONTRATISTA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_DESDE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_HASTA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CERTIFICADO_NRO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CERTIFICADO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CERTIFICADO_MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FONDO_FIJO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FONDO_FIJO_PAGADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAS_PROVEEDOR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAS_PROVEEDOR_PAGADO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ADELANTOS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ADELANTOS_PAGADOS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ADELANTO_INICIAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FONDO_REPARO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_IVA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("RETENCION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_PAGAR", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_FONDO_REPARO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_RELACIONADO_ID", typeof(decimal));
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

				case "PAGO_CONTRATISTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CERTIFICADO_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CERTIFICADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CERTIFICADO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FONDO_FIJO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FONDO_FIJO_PAGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURAS_PROVEEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTURAS_PROVEEDOR_PAGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ADELANTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ADELANTOS_PAGADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ADELANTO_INICIAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FONDO_REPARO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IVA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RETENCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_PAGAR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_FONDO_REPARO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PAGO_CONTRATISTAS_DETALLESCollection_Base class
}  // End of namespace
