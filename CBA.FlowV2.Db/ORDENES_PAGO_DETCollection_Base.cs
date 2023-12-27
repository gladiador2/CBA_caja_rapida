// <fileinfo name="ORDENES_PAGO_DETCollection_Base.cs">
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
	/// The base class for <see cref="ORDENES_PAGO_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ORDENES_PAGO_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ORDENES_PAGO_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string CTACTE_PROVEEDOR_IDColumnName = "CTACTE_PROVEEDOR_ID";
		public const string CTACTE_PERSONA_IDColumnName = "CTACTE_PERSONA_ID";
		public const string CTACTE_CAJA_TESO_DESTINO_IDColumnName = "CTACTE_CAJA_TESO_DESTINO_ID";
		public const string CTACTE_FONDO_FIJO_IDColumnName = "CTACTE_FONDO_FIJO_ID";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string MONTO_ORIGENColumnName = "MONTO_ORIGEN";
		public const string COTIZACION_MONEDA_ORIGENColumnName = "COTIZACION_MONEDA_ORIGEN";
		public const string MONTO_DESTINOColumnName = "MONTO_DESTINO";
		public const string FLUJO_REFERIDO_IDColumnName = "FLUJO_REFERIDO_ID";
		public const string CASO_REFERIDO_IDColumnName = "CASO_REFERIDO_ID";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string LIQUIDACION_IDColumnName = "LIQUIDACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ORDENES_PAGO_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ORDENES_PAGO_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ORDENES_PAGO_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ORDENES_PAGO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ORDENES_PAGO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ORDENES_PAGO_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ORDENES_PAGO_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ORDENES_PAGO_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ORDENES_PAGO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ORDENES_PAGO_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ORDENES_PAGO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ORDENES_PAGO_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ORDENES_PAGO_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByCTACTE_CAJA_TESO_DESTINO_ID(decimal ctacte_caja_teso_destino_id)
		{
			return GetByCTACTE_CAJA_TESO_DESTINO_ID(ctacte_caja_teso_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_destino_idNull">true if the method ignores the ctacte_caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByCTACTE_CAJA_TESO_DESTINO_ID(decimal ctacte_caja_teso_destino_id, bool ctacte_caja_teso_destino_idNull)
		{
			return MapRecords(CreateGetByCTACTE_CAJA_TESO_DESTINO_IDCommand(ctacte_caja_teso_destino_id, ctacte_caja_teso_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_CAJA_TESO_DESTINO_IDAsDataTable(decimal ctacte_caja_teso_destino_id)
		{
			return GetByCTACTE_CAJA_TESO_DESTINO_IDAsDataTable(ctacte_caja_teso_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_destino_idNull">true if the method ignores the ctacte_caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CAJA_TESO_DESTINO_IDAsDataTable(decimal ctacte_caja_teso_destino_id, bool ctacte_caja_teso_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CAJA_TESO_DESTINO_IDCommand(ctacte_caja_teso_destino_id, ctacte_caja_teso_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_destino_idNull">true if the method ignores the ctacte_caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CAJA_TESO_DESTINO_IDCommand(decimal ctacte_caja_teso_destino_id, bool ctacte_caja_teso_destino_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_teso_destino_idNull)
				whereSql += "CTACTE_CAJA_TESO_DESTINO_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESO_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_caja_teso_destino_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESO_DESTINO_ID", ctacte_caja_teso_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByCASO_REFERIDO_ID(decimal caso_referido_id)
		{
			return GetByCASO_REFERIDO_ID(caso_referido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <param name="caso_referido_idNull">true if the method ignores the caso_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByCASO_REFERIDO_ID(decimal caso_referido_id, bool caso_referido_idNull)
		{
			return MapRecords(CreateGetByCASO_REFERIDO_IDCommand(caso_referido_id, caso_referido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_REFERIDO_IDAsDataTable(decimal caso_referido_id)
		{
			return GetByCASO_REFERIDO_IDAsDataTable(caso_referido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <param name="caso_referido_idNull">true if the method ignores the caso_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_REFERIDO_IDAsDataTable(decimal caso_referido_id, bool caso_referido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_REFERIDO_IDCommand(caso_referido_id, caso_referido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <param name="caso_referido_idNull">true if the method ignores the caso_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_REFERIDO_IDCommand(decimal caso_referido_id, bool caso_referido_idNull)
		{
			string whereSql = "";
			if(caso_referido_idNull)
				whereSql += "CASO_REFERIDO_ID IS NULL";
			else
				whereSql += "CASO_REFERIDO_ID=" + _db.CreateSqlParameterName("CASO_REFERIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_referido_idNull)
				AddParameter(cmd, "CASO_REFERIDO_ID", caso_referido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id)
		{
			return GetByCTACTE_PERSONA_IDAsDataTable(ctacte_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PERSONA_IDAsDataTable(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id)
		{
			return GetByCTACTE_PROVEEDOR_ID(ctacte_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id, ctacte_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROVEEDOR_IDAsDataTable(decimal ctacte_proveedor_id)
		{
			return GetByCTACTE_PROVEEDOR_IDAsDataTable(ctacte_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROVEEDOR_IDAsDataTable(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id, ctacte_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROVEEDOR_IDCommand(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			string whereSql = "";
			if(ctacte_proveedor_idNull)
				whereSql += "CTACTE_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_proveedor_idNull)
				AddParameter(cmd, "CTACTE_PROVEEDOR_ID", ctacte_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByFLUJO_REFERIDO_ID(decimal flujo_referido_id)
		{
			return GetByFLUJO_REFERIDO_ID(flujo_referido_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <param name="flujo_referido_idNull">true if the method ignores the flujo_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByFLUJO_REFERIDO_ID(decimal flujo_referido_id, bool flujo_referido_idNull)
		{
			return MapRecords(CreateGetByFLUJO_REFERIDO_IDCommand(flujo_referido_id, flujo_referido_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByFLUJO_REFERIDO_IDAsDataTable(decimal flujo_referido_id)
		{
			return GetByFLUJO_REFERIDO_IDAsDataTable(flujo_referido_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <param name="flujo_referido_idNull">true if the method ignores the flujo_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFLUJO_REFERIDO_IDAsDataTable(decimal flujo_referido_id, bool flujo_referido_idNull)
		{
			return MapRecordsToDataTable(CreateGetByFLUJO_REFERIDO_IDCommand(flujo_referido_id, flujo_referido_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <param name="flujo_referido_idNull">true if the method ignores the flujo_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFLUJO_REFERIDO_IDCommand(decimal flujo_referido_id, bool flujo_referido_idNull)
		{
			string whereSql = "";
			if(flujo_referido_idNull)
				whereSql += "FLUJO_REFERIDO_ID IS NULL";
			else
				whereSql += "FLUJO_REFERIDO_ID=" + _db.CreateSqlParameterName("FLUJO_REFERIDO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!flujo_referido_idNull)
				AddParameter(cmd, "FLUJO_REFERIDO_ID", flujo_referido_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id)
		{
			return GetByCTACTE_FONDO_FIJO_IDAsDataTable(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_FONDO_FIJO_IDAsDataTable(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_IDAsDataTable(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			string whereSql = "";
			if(moneda_origen_idNull)
				whereSql += "MONEDA_ORIGEN_ID IS NULL";
			else
				whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!moneda_origen_idNull)
				AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return MapRecords(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_IDCommand(decimal orden_pago_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_IDAsDataTable(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			string whereSql = "";
			if(sucursal_destino_idNull)
				whereSql += "SUCURSAL_DESTINO_ID IS NULL";
			else
				whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_destino_idNull)
				AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public ORDENES_PAGO_DETRow[] GetByLIQUIDACION_ID(decimal liquidacion_id)
		{
			return GetByLIQUIDACION_ID(liquidacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ORDENES_PAGO_DETRow"/> objects 
		/// by the <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		public virtual ORDENES_PAGO_DETRow[] GetByLIQUIDACION_ID(decimal liquidacion_id, bool liquidacion_idNull)
		{
			return MapRecords(CreateGetByLIQUIDACION_IDCommand(liquidacion_id, liquidacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLIQUIDACION_IDAsDataTable(decimal liquidacion_id)
		{
			return GetByLIQUIDACION_IDAsDataTable(liquidacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLIQUIDACION_IDAsDataTable(decimal liquidacion_id, bool liquidacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLIQUIDACION_IDCommand(liquidacion_id, liquidacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLIQUIDACION_IDCommand(decimal liquidacion_id, bool liquidacion_idNull)
		{
			string whereSql = "";
			if(liquidacion_idNull)
				whereSql += "LIQUIDACION_ID IS NULL";
			else
				whereSql += "LIQUIDACION_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!liquidacion_idNull)
				AddParameter(cmd, "LIQUIDACION_ID", liquidacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ORDENES_PAGO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGO_DETRow"/> object to be inserted.</param>
		public virtual void Insert(ORDENES_PAGO_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ORDENES_PAGO_DET (" +
				"ID, " +
				"ORDEN_PAGO_ID, " +
				"SUCURSAL_DESTINO_ID, " +
				"CTACTE_PROVEEDOR_ID, " +
				"CTACTE_PERSONA_ID, " +
				"CTACTE_CAJA_TESO_DESTINO_ID, " +
				"CTACTE_FONDO_FIJO_ID, " +
				"MONEDA_ORIGEN_ID, " +
				"MONTO_ORIGEN, " +
				"COTIZACION_MONEDA_ORIGEN, " +
				"MONTO_DESTINO, " +
				"FLUJO_REFERIDO_ID, " +
				"CASO_REFERIDO_ID, " +
				"OBSERVACION, " +
				"LIQUIDACION_ID, " +
				"NRO_COMPROBANTE" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_CAJA_TESO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				_db.CreateSqlParameterName("FLUJO_REFERIDO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_REFERIDO_ID") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("LIQUIDACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ORDEN_PAGO_ID", value.ORDEN_PAGO_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID",
				value.IsCTACTE_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CTACTE_PROVEEDOR_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESO_DESTINO_ID",
				value.IsCTACTE_CAJA_TESO_DESTINO_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESO_DESTINO_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "MONTO_ORIGEN",
				value.IsMONTO_ORIGENNull ? DBNull.Value : (object)value.MONTO_ORIGEN);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN",
				value.IsCOTIZACION_MONEDA_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO",
				value.IsMONTO_DESTINONull ? DBNull.Value : (object)value.MONTO_DESTINO);
			AddParameter(cmd, "FLUJO_REFERIDO_ID",
				value.IsFLUJO_REFERIDO_IDNull ? DBNull.Value : (object)value.FLUJO_REFERIDO_ID);
			AddParameter(cmd, "CASO_REFERIDO_ID",
				value.IsCASO_REFERIDO_IDNull ? DBNull.Value : (object)value.CASO_REFERIDO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "LIQUIDACION_ID",
				value.IsLIQUIDACION_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ORDENES_PAGO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGO_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ORDENES_PAGO_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.ORDENES_PAGO_DET SET " +
				"ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				"SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				"CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID") + ", " +
				"CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID") + ", " +
				"CTACTE_CAJA_TESO_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_DESTINO_ID") + ", " +
				"CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"MONTO_ORIGEN=" + _db.CreateSqlParameterName("MONTO_ORIGEN") + ", " +
				"COTIZACION_MONEDA_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_ORIGEN") + ", " +
				"MONTO_DESTINO=" + _db.CreateSqlParameterName("MONTO_DESTINO") + ", " +
				"FLUJO_REFERIDO_ID=" + _db.CreateSqlParameterName("FLUJO_REFERIDO_ID") + ", " +
				"CASO_REFERIDO_ID=" + _db.CreateSqlParameterName("CASO_REFERIDO_ID") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"LIQUIDACION_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ORDEN_PAGO_ID", value.ORDEN_PAGO_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "CTACTE_PROVEEDOR_ID",
				value.IsCTACTE_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CTACTE_PROVEEDOR_ID);
			AddParameter(cmd, "CTACTE_PERSONA_ID",
				value.IsCTACTE_PERSONA_IDNull ? DBNull.Value : (object)value.CTACTE_PERSONA_ID);
			AddParameter(cmd, "CTACTE_CAJA_TESO_DESTINO_ID",
				value.IsCTACTE_CAJA_TESO_DESTINO_IDNull ? DBNull.Value : (object)value.CTACTE_CAJA_TESO_DESTINO_ID);
			AddParameter(cmd, "CTACTE_FONDO_FIJO_ID",
				value.IsCTACTE_FONDO_FIJO_IDNull ? DBNull.Value : (object)value.CTACTE_FONDO_FIJO_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "MONTO_ORIGEN",
				value.IsMONTO_ORIGENNull ? DBNull.Value : (object)value.MONTO_ORIGEN);
			AddParameter(cmd, "COTIZACION_MONEDA_ORIGEN",
				value.IsCOTIZACION_MONEDA_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_ORIGEN);
			AddParameter(cmd, "MONTO_DESTINO",
				value.IsMONTO_DESTINONull ? DBNull.Value : (object)value.MONTO_DESTINO);
			AddParameter(cmd, "FLUJO_REFERIDO_ID",
				value.IsFLUJO_REFERIDO_IDNull ? DBNull.Value : (object)value.FLUJO_REFERIDO_ID);
			AddParameter(cmd, "CASO_REFERIDO_ID",
				value.IsCASO_REFERIDO_IDNull ? DBNull.Value : (object)value.CASO_REFERIDO_ID);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "LIQUIDACION_ID",
				value.IsLIQUIDACION_IDNull ? DBNull.Value : (object)value.LIQUIDACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ORDENES_PAGO_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ORDENES_PAGO_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ORDENES_PAGO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ORDENES_PAGO_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ORDENES_PAGO_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ORDENES_PAGO_DET</c> table using
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
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESO_DESTINO_ID(decimal ctacte_caja_teso_destino_id)
		{
			return DeleteByCTACTE_CAJA_TESO_DESTINO_ID(ctacte_caja_teso_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_destino_idNull">true if the method ignores the ctacte_caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CAJA_TESO_DESTINO_ID(decimal ctacte_caja_teso_destino_id, bool ctacte_caja_teso_destino_idNull)
		{
			return CreateDeleteByCTACTE_CAJA_TESO_DESTINO_IDCommand(ctacte_caja_teso_destino_id, ctacte_caja_teso_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_CAJA_TE_DE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_caja_teso_destino_id">The <c>CTACTE_CAJA_TESO_DESTINO_ID</c> column value.</param>
		/// <param name="ctacte_caja_teso_destino_idNull">true if the method ignores the ctacte_caja_teso_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CAJA_TESO_DESTINO_IDCommand(decimal ctacte_caja_teso_destino_id, bool ctacte_caja_teso_destino_idNull)
		{
			string whereSql = "";
			if(ctacte_caja_teso_destino_idNull)
				whereSql += "CTACTE_CAJA_TESO_DESTINO_ID IS NULL";
			else
				whereSql += "CTACTE_CAJA_TESO_DESTINO_ID=" + _db.CreateSqlParameterName("CTACTE_CAJA_TESO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_caja_teso_destino_idNull)
				AddParameter(cmd, "CTACTE_CAJA_TESO_DESTINO_ID", ctacte_caja_teso_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_REFERIDO_ID(decimal caso_referido_id)
		{
			return DeleteByCASO_REFERIDO_ID(caso_referido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <param name="caso_referido_idNull">true if the method ignores the caso_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_REFERIDO_ID(decimal caso_referido_id, bool caso_referido_idNull)
		{
			return CreateDeleteByCASO_REFERIDO_IDCommand(caso_referido_id, caso_referido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_CASO_REF</c> foreign key.
		/// </summary>
		/// <param name="caso_referido_id">The <c>CASO_REFERIDO_ID</c> column value.</param>
		/// <param name="caso_referido_idNull">true if the method ignores the caso_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_REFERIDO_IDCommand(decimal caso_referido_id, bool caso_referido_idNull)
		{
			string whereSql = "";
			if(caso_referido_idNull)
				whereSql += "CASO_REFERIDO_ID IS NULL";
			else
				whereSql += "CASO_REFERIDO_ID=" + _db.CreateSqlParameterName("CASO_REFERIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_referido_idNull)
				AddParameter(cmd, "CASO_REFERIDO_ID", caso_referido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id)
		{
			return DeleteByCTACTE_PERSONA_ID(ctacte_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PERSONA_ID(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			return CreateDeleteByCTACTE_PERSONA_IDCommand(ctacte_persona_id, ctacte_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_CTACTE_PER</c> foreign key.
		/// </summary>
		/// <param name="ctacte_persona_id">The <c>CTACTE_PERSONA_ID</c> column value.</param>
		/// <param name="ctacte_persona_idNull">true if the method ignores the ctacte_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PERSONA_IDCommand(decimal ctacte_persona_id, bool ctacte_persona_idNull)
		{
			string whereSql = "";
			if(ctacte_persona_idNull)
				whereSql += "CTACTE_PERSONA_ID IS NULL";
			else
				whereSql += "CTACTE_PERSONA_ID=" + _db.CreateSqlParameterName("CTACTE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_persona_idNull)
				AddParameter(cmd, "CTACTE_PERSONA_ID", ctacte_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id)
		{
			return DeleteByCTACTE_PROVEEDOR_ID(ctacte_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROVEEDOR_ID(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			return CreateDeleteByCTACTE_PROVEEDOR_IDCommand(ctacte_proveedor_id, ctacte_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_CTACTE_PRO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_id">The <c>CTACTE_PROVEEDOR_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_idNull">true if the method ignores the ctacte_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROVEEDOR_IDCommand(decimal ctacte_proveedor_id, bool ctacte_proveedor_idNull)
		{
			string whereSql = "";
			if(ctacte_proveedor_idNull)
				whereSql += "CTACTE_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CTACTE_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_proveedor_idNull)
				AddParameter(cmd, "CTACTE_PROVEEDOR_ID", ctacte_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_REFERIDO_ID(decimal flujo_referido_id)
		{
			return DeleteByFLUJO_REFERIDO_ID(flujo_referido_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <param name="flujo_referido_idNull">true if the method ignores the flujo_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFLUJO_REFERIDO_ID(decimal flujo_referido_id, bool flujo_referido_idNull)
		{
			return CreateDeleteByFLUJO_REFERIDO_IDCommand(flujo_referido_id, flujo_referido_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_FLUJO_REF</c> foreign key.
		/// </summary>
		/// <param name="flujo_referido_id">The <c>FLUJO_REFERIDO_ID</c> column value.</param>
		/// <param name="flujo_referido_idNull">true if the method ignores the flujo_referido_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFLUJO_REFERIDO_IDCommand(decimal flujo_referido_id, bool flujo_referido_idNull)
		{
			string whereSql = "";
			if(flujo_referido_idNull)
				whereSql += "FLUJO_REFERIDO_ID IS NULL";
			else
				whereSql += "FLUJO_REFERIDO_ID=" + _db.CreateSqlParameterName("FLUJO_REFERIDO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!flujo_referido_idNull)
				AddParameter(cmd, "FLUJO_REFERIDO_ID", flujo_referido_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id)
		{
			return DeleteByCTACTE_FONDO_FIJO_ID(ctacte_fondo_fijo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_FONDO_FIJO_ID(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			return CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(ctacte_fondo_fijo_id, ctacte_fondo_fijo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_FONDO_FIJO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_fondo_fijo_id">The <c>CTACTE_FONDO_FIJO_ID</c> column value.</param>
		/// <param name="ctacte_fondo_fijo_idNull">true if the method ignores the ctacte_fondo_fijo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_FONDO_FIJO_IDCommand(decimal ctacte_fondo_fijo_id, bool ctacte_fondo_fijo_idNull)
		{
			string whereSql = "";
			if(ctacte_fondo_fijo_idNull)
				whereSql += "CTACTE_FONDO_FIJO_ID IS NULL";
			else
				whereSql += "CTACTE_FONDO_FIJO_ID=" + _db.CreateSqlParameterName("CTACTE_FONDO_FIJO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_fondo_fijo_idNull)
				AddParameter(cmd, "CTACTE_FONDO_FIJO_ID", ctacte_fondo_fijo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return DeleteByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return CreateDeleteByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_MONEDA_O</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMONEDA_ORIGEN_IDCommand(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			string whereSql = "";
			if(moneda_origen_idNull)
				whereSql += "MONEDA_ORIGEN_ID IS NULL";
			else
				whereSql += "MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!moneda_origen_idNull)
				AddParameter(cmd, "MONEDA_ORIGEN_ID", moneda_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return CreateDeleteByORDEN_PAGO_IDCommand(orden_pago_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_IDCommand(decimal orden_pago_id)
		{
			string whereSql = "";
			whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return DeleteBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return CreateDeleteBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_DET_SUC_D</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_DESTINO_IDCommand(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			string whereSql = "";
			if(sucursal_destino_idNull)
				whereSql += "SUCURSAL_DESTINO_ID IS NULL";
			else
				whereSql += "SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_destino_idNull)
				AddParameter(cmd, "SUCURSAL_DESTINO_ID", sucursal_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLIQUIDACION_ID(decimal liquidacion_id)
		{
			return DeleteByLIQUIDACION_ID(liquidacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ORDENES_PAGO_DET</c> table using the 
		/// <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLIQUIDACION_ID(decimal liquidacion_id, bool liquidacion_idNull)
		{
			return CreateDeleteByLIQUIDACION_IDCommand(liquidacion_id, liquidacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ORDENES_PAGO_LIQ_ID</c> foreign key.
		/// </summary>
		/// <param name="liquidacion_id">The <c>LIQUIDACION_ID</c> column value.</param>
		/// <param name="liquidacion_idNull">true if the method ignores the liquidacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLIQUIDACION_IDCommand(decimal liquidacion_id, bool liquidacion_idNull)
		{
			string whereSql = "";
			if(liquidacion_idNull)
				whereSql += "LIQUIDACION_ID IS NULL";
			else
				whereSql += "LIQUIDACION_ID=" + _db.CreateSqlParameterName("LIQUIDACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!liquidacion_idNull)
				AddParameter(cmd, "LIQUIDACION_ID", liquidacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ORDENES_PAGO_DET</c> records that match the specified criteria.
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
		/// to delete <c>ORDENES_PAGO_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ORDENES_PAGO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ORDENES_PAGO_DET</c> table.
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		protected ORDENES_PAGO_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		protected ORDENES_PAGO_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ORDENES_PAGO_DETRow"/> objects.</returns>
		protected virtual ORDENES_PAGO_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int ctacte_proveedor_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_ID");
			int ctacte_persona_idColumnIndex = reader.GetOrdinal("CTACTE_PERSONA_ID");
			int ctacte_caja_teso_destino_idColumnIndex = reader.GetOrdinal("CTACTE_CAJA_TESO_DESTINO_ID");
			int ctacte_fondo_fijo_idColumnIndex = reader.GetOrdinal("CTACTE_FONDO_FIJO_ID");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int monto_origenColumnIndex = reader.GetOrdinal("MONTO_ORIGEN");
			int cotizacion_moneda_origenColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_ORIGEN");
			int monto_destinoColumnIndex = reader.GetOrdinal("MONTO_DESTINO");
			int flujo_referido_idColumnIndex = reader.GetOrdinal("FLUJO_REFERIDO_ID");
			int caso_referido_idColumnIndex = reader.GetOrdinal("CASO_REFERIDO_ID");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int liquidacion_idColumnIndex = reader.GetOrdinal("LIQUIDACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ORDENES_PAGO_DETRow record = new ORDENES_PAGO_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_idColumnIndex))
						record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_proveedor_idColumnIndex))
						record.CTACTE_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_persona_idColumnIndex))
						record.CTACTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_caja_teso_destino_idColumnIndex))
						record.CTACTE_CAJA_TESO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_caja_teso_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_fondo_fijo_idColumnIndex))
						record.CTACTE_FONDO_FIJO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_fondo_fijo_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(monto_origenColumnIndex))
						record.MONTO_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_moneda_origenColumnIndex))
						record.COTIZACION_MONEDA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_origenColumnIndex)), 9);
					if(!reader.IsDBNull(monto_destinoColumnIndex))
						record.MONTO_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_destinoColumnIndex)), 9);
					if(!reader.IsDBNull(flujo_referido_idColumnIndex))
						record.FLUJO_REFERIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(flujo_referido_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_referido_idColumnIndex))
						record.CASO_REFERIDO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_referido_idColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(liquidacion_idColumnIndex))
						record.LIQUIDACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(liquidacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ORDENES_PAGO_DETRow[])(recordList.ToArray(typeof(ORDENES_PAGO_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ORDENES_PAGO_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ORDENES_PAGO_DETRow"/> object.</returns>
		protected virtual ORDENES_PAGO_DETRow MapRow(DataRow row)
		{
			ORDENES_PAGO_DETRow mappedObject = new ORDENES_PAGO_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PERSONA_ID"
			dataColumn = dataTable.Columns["CTACTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_CAJA_TESO_DESTINO_ID"
			dataColumn = dataTable.Columns["CTACTE_CAJA_TESO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CAJA_TESO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_FONDO_FIJO_ID"
			dataColumn = dataTable.Columns["CTACTE_FONDO_FIJO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_FONDO_FIJO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "MONTO_ORIGEN"
			dataColumn = dataTable.Columns["MONTO_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_ORIGEN = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_ORIGEN = (decimal)row[dataColumn];
			// Column "MONTO_DESTINO"
			dataColumn = dataTable.Columns["MONTO_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESTINO = (decimal)row[dataColumn];
			// Column "FLUJO_REFERIDO_ID"
			dataColumn = dataTable.Columns["FLUJO_REFERIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FLUJO_REFERIDO_ID = (decimal)row[dataColumn];
			// Column "CASO_REFERIDO_ID"
			dataColumn = dataTable.Columns["CASO_REFERIDO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_REFERIDO_ID = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "LIQUIDACION_ID"
			dataColumn = dataTable.Columns["LIQUIDACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LIQUIDACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ORDENES_PAGO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ORDENES_PAGO_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_CAJA_TESO_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_FONDO_FIJO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_DESTINO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FLUJO_REFERIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_REFERIDO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("LIQUIDACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
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

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CAJA_TESO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_FONDO_FIJO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FLUJO_REFERIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_REFERIDO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LIQUIDACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ORDENES_PAGO_DETCollection_Base class
}  // End of namespace
