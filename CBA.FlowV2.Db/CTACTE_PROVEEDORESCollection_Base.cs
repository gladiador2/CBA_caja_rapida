// <fileinfo name="CTACTE_PROVEEDORESCollection_Base.cs">
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
	/// The base class for <see cref="CTACTE_PROVEEDORESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CTACTE_PROVEEDORESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PROVEEDORESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string FECHA_INSERCIONColumnName = "FECHA_INSERCION";
		public const string FECHA_VENCIMIENTOColumnName = "FECHA_VENCIMIENTO";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string CTACTE_CONCEPTO_IDColumnName = "CTACTE_CONCEPTO_ID";
		public const string CTACTE_VALOR_IDColumnName = "CTACTE_VALOR_ID";
		public const string ORDEN_PAGO_IDColumnName = "ORDEN_PAGO_ID";
		public const string MOVIMIENTO_VARIO_TESORERIA_IDColumnName = "MOVIMIENTO_VARIO_TESORERIA_ID";
		public const string EGRESO_VARIO_CAJA_IDColumnName = "EGRESO_VARIO_CAJA_ID";
		public const string CTACTE_PAGARE_DET_IDColumnName = "CTACTE_PAGARE_DET_ID";
		public const string CALENDARIO_PAGOS_FC_PROV_IDColumnName = "CALENDARIO_PAGOS_FC_PROV_ID";
		public const string CREDITO_PROVEEDOR_DET_IDColumnName = "CREDITO_PROVEEDOR_DET_ID";
		public const string CREDITOColumnName = "CREDITO";
		public const string DEBITOColumnName = "DEBITO";
		public const string CONCEPTOColumnName = "CONCEPTO";
		public const string CTACTE_PROVEEDOR_RELAC_IDColumnName = "CTACTE_PROVEEDOR_RELAC_ID";
		public const string NC_APLICACION_IDColumnName = "NC_APLICACION_ID";
		public const string NC_APLICACION_DET_IDColumnName = "NC_APLICACION_DET_ID";
		public const string ORDEN_PAGO_VALOR_IDColumnName = "ORDEN_PAGO_VALOR_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PROVEEDORESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CTACTE_PROVEEDORESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CTACTE_PROVEEDORES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CTACTE_PROVEEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CTACTE_PROVEEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CTACTE_PROVEEDORESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CTACTE_PROVEEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CTACTE_PROVEEDORESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CTACTE_PROVEEDORESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects that 
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CTACTE_PROVEEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CTACTE_PROVEEDORESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CTACTE_PROVEEDORESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CTACTE_PROVEEDORESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CTACTE_PROVEEDORESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByCALENDARIO_PAGOS_FC_PROV_ID(decimal calendario_pagos_fc_prov_id)
		{
			return GetByCALENDARIO_PAGOS_FC_PROV_ID(calendario_pagos_fc_prov_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_prov_idNull">true if the method ignores the calendario_pagos_fc_prov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByCALENDARIO_PAGOS_FC_PROV_ID(decimal calendario_pagos_fc_prov_id, bool calendario_pagos_fc_prov_idNull)
		{
			return MapRecords(CreateGetByCALENDARIO_PAGOS_FC_PROV_IDCommand(calendario_pagos_fc_prov_id, calendario_pagos_fc_prov_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCALENDARIO_PAGOS_FC_PROV_IDAsDataTable(decimal calendario_pagos_fc_prov_id)
		{
			return GetByCALENDARIO_PAGOS_FC_PROV_IDAsDataTable(calendario_pagos_fc_prov_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_prov_idNull">true if the method ignores the calendario_pagos_fc_prov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCALENDARIO_PAGOS_FC_PROV_IDAsDataTable(decimal calendario_pagos_fc_prov_id, bool calendario_pagos_fc_prov_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCALENDARIO_PAGOS_FC_PROV_IDCommand(calendario_pagos_fc_prov_id, calendario_pagos_fc_prov_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_prov_idNull">true if the method ignores the calendario_pagos_fc_prov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCALENDARIO_PAGOS_FC_PROV_IDCommand(decimal calendario_pagos_fc_prov_id, bool calendario_pagos_fc_prov_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_fc_prov_idNull)
				whereSql += "CALENDARIO_PAGOS_FC_PROV_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_FC_PROV_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_PROV_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!calendario_pagos_fc_prov_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_FC_PROV_ID", calendario_pagos_fc_prov_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
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
		/// return records by the <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CONCEP</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByCTACTE_CONCEPTO_ID(decimal ctacte_concepto_id)
		{
			return MapRecords(CreateGetByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CONCEP</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_CONCEPTO_IDAsDataTable(decimal ctacte_concepto_id)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_CONCEP</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_CONCEPTO_IDCommand(decimal ctacte_concepto_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", ctacte_concepto_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByCREDITO_PROVEEDOR_DET_ID(decimal credito_proveedor_det_id)
		{
			return GetByCREDITO_PROVEEDOR_DET_ID(credito_proveedor_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <param name="credito_proveedor_det_idNull">true if the method ignores the credito_proveedor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByCREDITO_PROVEEDOR_DET_ID(decimal credito_proveedor_det_id, bool credito_proveedor_det_idNull)
		{
			return MapRecords(CreateGetByCREDITO_PROVEEDOR_DET_IDCommand(credito_proveedor_det_id, credito_proveedor_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCREDITO_PROVEEDOR_DET_IDAsDataTable(decimal credito_proveedor_det_id)
		{
			return GetByCREDITO_PROVEEDOR_DET_IDAsDataTable(credito_proveedor_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <param name="credito_proveedor_det_idNull">true if the method ignores the credito_proveedor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCREDITO_PROVEEDOR_DET_IDAsDataTable(decimal credito_proveedor_det_id, bool credito_proveedor_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCREDITO_PROVEEDOR_DET_IDCommand(credito_proveedor_det_id, credito_proveedor_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <param name="credito_proveedor_det_idNull">true if the method ignores the credito_proveedor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCREDITO_PROVEEDOR_DET_IDCommand(decimal credito_proveedor_det_id, bool credito_proveedor_det_idNull)
		{
			string whereSql = "";
			if(credito_proveedor_det_idNull)
				whereSql += "CREDITO_PROVEEDOR_DET_ID IS NULL";
			else
				whereSql += "CREDITO_PROVEEDOR_DET_ID=" + _db.CreateSqlParameterName("CREDITO_PROVEEDOR_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!credito_proveedor_det_idNull)
				AddParameter(cmd, "CREDITO_PROVEEDOR_DET_ID", credito_proveedor_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByCTACTE_PROVEEDOR_RELAC_ID(decimal ctacte_proveedor_relac_id)
		{
			return GetByCTACTE_PROVEEDOR_RELAC_ID(ctacte_proveedor_relac_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_relac_idNull">true if the method ignores the ctacte_proveedor_relac_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByCTACTE_PROVEEDOR_RELAC_ID(decimal ctacte_proveedor_relac_id, bool ctacte_proveedor_relac_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PROVEEDOR_RELAC_IDCommand(ctacte_proveedor_relac_id, ctacte_proveedor_relac_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PROVEEDOR_RELAC_IDAsDataTable(decimal ctacte_proveedor_relac_id)
		{
			return GetByCTACTE_PROVEEDOR_RELAC_IDAsDataTable(ctacte_proveedor_relac_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_relac_idNull">true if the method ignores the ctacte_proveedor_relac_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PROVEEDOR_RELAC_IDAsDataTable(decimal ctacte_proveedor_relac_id, bool ctacte_proveedor_relac_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PROVEEDOR_RELAC_IDCommand(ctacte_proveedor_relac_id, ctacte_proveedor_relac_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_relac_idNull">true if the method ignores the ctacte_proveedor_relac_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PROVEEDOR_RELAC_IDCommand(decimal ctacte_proveedor_relac_id, bool ctacte_proveedor_relac_idNull)
		{
			string whereSql = "";
			if(ctacte_proveedor_relac_idNull)
				whereSql += "CTACTE_PROVEEDOR_RELAC_ID IS NULL";
			else
				whereSql += "CTACTE_PROVEEDOR_RELAC_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_RELAC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_proveedor_relac_idNull)
				AddParameter(cmd, "CTACTE_PROVEEDOR_RELAC_ID", ctacte_proveedor_relac_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecords(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id)
		{
			return GetByEGRESO_VARIO_CAJA_IDAsDataTable(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByEGRESO_VARIO_CAJA_IDAsDataTable(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return MapRecordsToDataTable(CreateGetByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return MapRecordsToDataTable(CreateGetByMONEDA_IDCommand(moneda_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id)
		{
			return GetByMOVIMIENTO_VARIO_TESORERIA_ID(movimiento_vario_tesoreria_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			return MapRecords(CreateGetByMOVIMIENTO_VARIO_TESORERIA_IDCommand(movimiento_vario_tesoreria_id, movimiento_vario_tesoreria_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMOVIMIENTO_VARIO_TESORERIA_IDAsDataTable(decimal movimiento_vario_tesoreria_id)
		{
			return GetByMOVIMIENTO_VARIO_TESORERIA_IDAsDataTable(movimiento_vario_tesoreria_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByMOVIMIENTO_VARIO_TESORERIA_IDAsDataTable(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			return MapRecordsToDataTable(CreateGetByMOVIMIENTO_VARIO_TESORERIA_IDCommand(movimiento_vario_tesoreria_id, movimiento_vario_tesoreria_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByMOVIMIENTO_VARIO_TESORERIA_IDCommand(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			string whereSql = "";
			if(movimiento_vario_tesoreria_idNull)
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!movimiento_vario_tesoreria_idNull)
				AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID", movimiento_vario_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecords(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id)
		{
			return GetByORDEN_PAGO_IDAsDataTable(orden_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_IDAsDataTable(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id)
		{
			return GetByORDEN_PAGO_VALOR_ID(orden_pago_valor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			return MapRecords(CreateGetByORDEN_PAGO_VALOR_IDCommand(orden_pago_valor_id, orden_pago_valor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByORDEN_PAGO_VALOR_IDAsDataTable(decimal orden_pago_valor_id)
		{
			return GetByORDEN_PAGO_VALOR_IDAsDataTable(orden_pago_valor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByORDEN_PAGO_VALOR_IDAsDataTable(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByORDEN_PAGO_VALOR_IDCommand(orden_pago_valor_id, orden_pago_valor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByORDEN_PAGO_VALOR_IDCommand(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			string whereSql = "";
			if(orden_pago_valor_idNull)
				whereSql += "ORDEN_PAGO_VALOR_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_VALOR_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!orden_pago_valor_idNull)
				AddParameter(cmd, "ORDEN_PAGO_VALOR_ID", orden_pago_valor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id)
		{
			return GetByCTACTE_PAGARE_DET_ID(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return MapRecords(CreateGetByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_PAGARE_DET_IDAsDataTable(decimal ctacte_pagare_det_id)
		{
			return GetByCTACTE_PAGARE_DET_IDAsDataTable(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_PAGARE_DET_IDAsDataTable(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_PAGARE_DET_IDCommand(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_det_idNull)
				whereSql += "CTACTE_PAGARE_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_pagare_det_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DET_ID", ctacte_pagare_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id)
		{
			string whereSql = "";
			whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByCTACTE_VALOR_ID(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return MapRecords(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id)
		{
			return GetByCTACTE_VALOR_IDAsDataTable(ctacte_valor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_VALOR_IDAsDataTable(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			string whereSql = "";
			if(ctacte_valor_idNull)
				whereSql += "CTACTE_VALOR_ID IS NULL";
			else
				whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_valor_idNull)
				AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByNC_APLICACION_DET_ID(decimal nc_aplicacion_det_id)
		{
			return GetByNC_APLICACION_DET_ID(nc_aplicacion_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <param name="nc_aplicacion_det_idNull">true if the method ignores the nc_aplicacion_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByNC_APLICACION_DET_ID(decimal nc_aplicacion_det_id, bool nc_aplicacion_det_idNull)
		{
			return MapRecords(CreateGetByNC_APLICACION_DET_IDCommand(nc_aplicacion_det_id, nc_aplicacion_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNC_APLICACION_DET_IDAsDataTable(decimal nc_aplicacion_det_id)
		{
			return GetByNC_APLICACION_DET_IDAsDataTable(nc_aplicacion_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <param name="nc_aplicacion_det_idNull">true if the method ignores the nc_aplicacion_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNC_APLICACION_DET_IDAsDataTable(decimal nc_aplicacion_det_id, bool nc_aplicacion_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNC_APLICACION_DET_IDCommand(nc_aplicacion_det_id, nc_aplicacion_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <param name="nc_aplicacion_det_idNull">true if the method ignores the nc_aplicacion_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNC_APLICACION_DET_IDCommand(decimal nc_aplicacion_det_id, bool nc_aplicacion_det_idNull)
		{
			string whereSql = "";
			if(nc_aplicacion_det_idNull)
				whereSql += "NC_APLICACION_DET_ID IS NULL";
			else
				whereSql += "NC_APLICACION_DET_ID=" + _db.CreateSqlParameterName("NC_APLICACION_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nc_aplicacion_det_idNull)
				AddParameter(cmd, "NC_APLICACION_DET_ID", nc_aplicacion_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public CTACTE_PROVEEDORESRow[] GetByNC_APLICACION_ID(decimal nc_aplicacion_id)
		{
			return GetByNC_APLICACION_ID(nc_aplicacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CTACTE_PROVEEDORESRow"/> objects 
		/// by the <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <param name="nc_aplicacion_idNull">true if the method ignores the nc_aplicacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		public virtual CTACTE_PROVEEDORESRow[] GetByNC_APLICACION_ID(decimal nc_aplicacion_id, bool nc_aplicacion_idNull)
		{
			return MapRecords(CreateGetByNC_APLICACION_IDCommand(nc_aplicacion_id, nc_aplicacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByNC_APLICACION_IDAsDataTable(decimal nc_aplicacion_id)
		{
			return GetByNC_APLICACION_IDAsDataTable(nc_aplicacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <param name="nc_aplicacion_idNull">true if the method ignores the nc_aplicacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByNC_APLICACION_IDAsDataTable(decimal nc_aplicacion_id, bool nc_aplicacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByNC_APLICACION_IDCommand(nc_aplicacion_id, nc_aplicacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <param name="nc_aplicacion_idNull">true if the method ignores the nc_aplicacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByNC_APLICACION_IDCommand(decimal nc_aplicacion_id, bool nc_aplicacion_idNull)
		{
			string whereSql = "";
			if(nc_aplicacion_idNull)
				whereSql += "NC_APLICACION_ID IS NULL";
			else
				whereSql += "NC_APLICACION_ID=" + _db.CreateSqlParameterName("NC_APLICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!nc_aplicacion_idNull)
				AddParameter(cmd, "NC_APLICACION_ID", nc_aplicacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CTACTE_PROVEEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROVEEDORESRow"/> object to be inserted.</param>
		public virtual void Insert(CTACTE_PROVEEDORESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CTACTE_PROVEEDORES (" +
				"ID, " +
				"PROVEEDOR_ID, " +
				"CASO_ID, " +
				"FECHA_INSERCION, " +
				"FECHA_VENCIMIENTO, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"CTACTE_CONCEPTO_ID, " +
				"CTACTE_VALOR_ID, " +
				"ORDEN_PAGO_ID, " +
				"MOVIMIENTO_VARIO_TESORERIA_ID, " +
				"EGRESO_VARIO_CAJA_ID, " +
				"CTACTE_PAGARE_DET_ID, " +
				"CALENDARIO_PAGOS_FC_PROV_ID, " +
				"CREDITO_PROVEEDOR_DET_ID, " +
				"CREDITO, " +
				"DEBITO, " +
				"CONCEPTO, " +
				"CTACTE_PROVEEDOR_RELAC_ID, " +
				"NC_APLICACION_ID, " +
				"NC_APLICACION_DET_ID, " +
				"ORDEN_PAGO_VALOR_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				_db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("CTACTE_CONCEPTO_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID") + ", " +
				_db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				_db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID") + ", " +
				_db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_PROV_ID") + ", " +
				_db.CreateSqlParameterName("CREDITO_PROVEEDOR_DET_ID") + ", " +
				_db.CreateSqlParameterName("CREDITO") + ", " +
				_db.CreateSqlParameterName("DEBITO") + ", " +
				_db.CreateSqlParameterName("CONCEPTO") + ", " +
				_db.CreateSqlParameterName("CTACTE_PROVEEDOR_RELAC_ID") + ", " +
				_db.CreateSqlParameterName("NC_APLICACION_ID") + ", " +
				_db.CreateSqlParameterName("NC_APLICACION_DET_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PROVEEDOR_ID", value.PROVEEDOR_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", value.CTACTE_CONCEPTO_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID",
				value.IsMOVIMIENTO_VARIO_TESORERIA_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_VARIO_TESORERIA_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DET_ID",
				value.IsCTACTE_PAGARE_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DET_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_FC_PROV_ID",
				value.IsCALENDARIO_PAGOS_FC_PROV_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_FC_PROV_ID);
			AddParameter(cmd, "CREDITO_PROVEEDOR_DET_ID",
				value.IsCREDITO_PROVEEDOR_DET_IDNull ? DBNull.Value : (object)value.CREDITO_PROVEEDOR_DET_ID);
			AddParameter(cmd, "CREDITO", value.CREDITO);
			AddParameter(cmd, "DEBITO", value.DEBITO);
			AddParameter(cmd, "CONCEPTO", value.CONCEPTO);
			AddParameter(cmd, "CTACTE_PROVEEDOR_RELAC_ID",
				value.IsCTACTE_PROVEEDOR_RELAC_IDNull ? DBNull.Value : (object)value.CTACTE_PROVEEDOR_RELAC_ID);
			AddParameter(cmd, "NC_APLICACION_ID",
				value.IsNC_APLICACION_IDNull ? DBNull.Value : (object)value.NC_APLICACION_ID);
			AddParameter(cmd, "NC_APLICACION_DET_ID",
				value.IsNC_APLICACION_DET_IDNull ? DBNull.Value : (object)value.NC_APLICACION_DET_ID);
			AddParameter(cmd, "ORDEN_PAGO_VALOR_ID",
				value.IsORDEN_PAGO_VALOR_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_VALOR_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CTACTE_PROVEEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROVEEDORESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CTACTE_PROVEEDORESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CTACTE_PROVEEDORES SET " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"FECHA_INSERCION=" + _db.CreateSqlParameterName("FECHA_INSERCION") + ", " +
				"FECHA_VENCIMIENTO=" + _db.CreateSqlParameterName("FECHA_VENCIMIENTO") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID") + ", " +
				"CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID") + ", " +
				"ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID") + ", " +
				"MOVIMIENTO_VARIO_TESORERIA_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID") + ", " +
				"EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID") + ", " +
				"CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID") + ", " +
				"CALENDARIO_PAGOS_FC_PROV_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_PROV_ID") + ", " +
				"CREDITO_PROVEEDOR_DET_ID=" + _db.CreateSqlParameterName("CREDITO_PROVEEDOR_DET_ID") + ", " +
				"CREDITO=" + _db.CreateSqlParameterName("CREDITO") + ", " +
				"DEBITO=" + _db.CreateSqlParameterName("DEBITO") + ", " +
				"CONCEPTO=" + _db.CreateSqlParameterName("CONCEPTO") + ", " +
				"CTACTE_PROVEEDOR_RELAC_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_RELAC_ID") + ", " +
				"NC_APLICACION_ID=" + _db.CreateSqlParameterName("NC_APLICACION_ID") + ", " +
				"NC_APLICACION_DET_ID=" + _db.CreateSqlParameterName("NC_APLICACION_DET_ID") + ", " +
				"ORDEN_PAGO_VALOR_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PROVEEDOR_ID", value.PROVEEDOR_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "FECHA_INSERCION", value.FECHA_INSERCION);
			AddParameter(cmd, "FECHA_VENCIMIENTO", value.FECHA_VENCIMIENTO);
			AddParameter(cmd, "MONEDA_ID", value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA", value.COTIZACION_MONEDA);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", value.CTACTE_CONCEPTO_ID);
			AddParameter(cmd, "CTACTE_VALOR_ID",
				value.IsCTACTE_VALOR_IDNull ? DBNull.Value : (object)value.CTACTE_VALOR_ID);
			AddParameter(cmd, "ORDEN_PAGO_ID",
				value.IsORDEN_PAGO_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_ID);
			AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID",
				value.IsMOVIMIENTO_VARIO_TESORERIA_IDNull ? DBNull.Value : (object)value.MOVIMIENTO_VARIO_TESORERIA_ID);
			AddParameter(cmd, "EGRESO_VARIO_CAJA_ID",
				value.IsEGRESO_VARIO_CAJA_IDNull ? DBNull.Value : (object)value.EGRESO_VARIO_CAJA_ID);
			AddParameter(cmd, "CTACTE_PAGARE_DET_ID",
				value.IsCTACTE_PAGARE_DET_IDNull ? DBNull.Value : (object)value.CTACTE_PAGARE_DET_ID);
			AddParameter(cmd, "CALENDARIO_PAGOS_FC_PROV_ID",
				value.IsCALENDARIO_PAGOS_FC_PROV_IDNull ? DBNull.Value : (object)value.CALENDARIO_PAGOS_FC_PROV_ID);
			AddParameter(cmd, "CREDITO_PROVEEDOR_DET_ID",
				value.IsCREDITO_PROVEEDOR_DET_IDNull ? DBNull.Value : (object)value.CREDITO_PROVEEDOR_DET_ID);
			AddParameter(cmd, "CREDITO", value.CREDITO);
			AddParameter(cmd, "DEBITO", value.DEBITO);
			AddParameter(cmd, "CONCEPTO", value.CONCEPTO);
			AddParameter(cmd, "CTACTE_PROVEEDOR_RELAC_ID",
				value.IsCTACTE_PROVEEDOR_RELAC_IDNull ? DBNull.Value : (object)value.CTACTE_PROVEEDOR_RELAC_ID);
			AddParameter(cmd, "NC_APLICACION_ID",
				value.IsNC_APLICACION_IDNull ? DBNull.Value : (object)value.NC_APLICACION_ID);
			AddParameter(cmd, "NC_APLICACION_DET_ID",
				value.IsNC_APLICACION_DET_IDNull ? DBNull.Value : (object)value.NC_APLICACION_DET_ID);
			AddParameter(cmd, "ORDEN_PAGO_VALOR_ID",
				value.IsORDEN_PAGO_VALOR_IDNull ? DBNull.Value : (object)value.ORDEN_PAGO_VALOR_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CTACTE_PROVEEDORES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CTACTE_PROVEEDORES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CTACTE_PROVEEDORES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CTACTE_PROVEEDORESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CTACTE_PROVEEDORESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CTACTE_PROVEEDORES</c> table using
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
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_FC_PROV_ID(decimal calendario_pagos_fc_prov_id)
		{
			return DeleteByCALENDARIO_PAGOS_FC_PROV_ID(calendario_pagos_fc_prov_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_prov_idNull">true if the method ignores the calendario_pagos_fc_prov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCALENDARIO_PAGOS_FC_PROV_ID(decimal calendario_pagos_fc_prov_id, bool calendario_pagos_fc_prov_idNull)
		{
			return CreateDeleteByCALENDARIO_PAGOS_FC_PROV_IDCommand(calendario_pagos_fc_prov_id, calendario_pagos_fc_prov_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_CAL_PAG</c> foreign key.
		/// </summary>
		/// <param name="calendario_pagos_fc_prov_id">The <c>CALENDARIO_PAGOS_FC_PROV_ID</c> column value.</param>
		/// <param name="calendario_pagos_fc_prov_idNull">true if the method ignores the calendario_pagos_fc_prov_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCALENDARIO_PAGOS_FC_PROV_IDCommand(decimal calendario_pagos_fc_prov_id, bool calendario_pagos_fc_prov_idNull)
		{
			string whereSql = "";
			if(calendario_pagos_fc_prov_idNull)
				whereSql += "CALENDARIO_PAGOS_FC_PROV_ID IS NULL";
			else
				whereSql += "CALENDARIO_PAGOS_FC_PROV_ID=" + _db.CreateSqlParameterName("CALENDARIO_PAGOS_FC_PROV_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!calendario_pagos_fc_prov_idNull)
				AddParameter(cmd, "CALENDARIO_PAGOS_FC_PROV_ID", calendario_pagos_fc_prov_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
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
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_CASO</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CONCEP</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_CONCEPTO_ID(decimal ctacte_concepto_id)
		{
			return CreateDeleteByCTACTE_CONCEPTO_IDCommand(ctacte_concepto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_CONCEP</c> foreign key.
		/// </summary>
		/// <param name="ctacte_concepto_id">The <c>CTACTE_CONCEPTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_CONCEPTO_IDCommand(decimal ctacte_concepto_id)
		{
			string whereSql = "";
			whereSql += "CTACTE_CONCEPTO_ID=" + _db.CreateSqlParameterName("CTACTE_CONCEPTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CTACTE_CONCEPTO_ID", ctacte_concepto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCREDITO_PROVEEDOR_DET_ID(decimal credito_proveedor_det_id)
		{
			return DeleteByCREDITO_PROVEEDOR_DET_ID(credito_proveedor_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <param name="credito_proveedor_det_idNull">true if the method ignores the credito_proveedor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCREDITO_PROVEEDOR_DET_ID(decimal credito_proveedor_det_id, bool credito_proveedor_det_idNull)
		{
			return CreateDeleteByCREDITO_PROVEEDOR_DET_IDCommand(credito_proveedor_det_id, credito_proveedor_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_CRED_D</c> foreign key.
		/// </summary>
		/// <param name="credito_proveedor_det_id">The <c>CREDITO_PROVEEDOR_DET_ID</c> column value.</param>
		/// <param name="credito_proveedor_det_idNull">true if the method ignores the credito_proveedor_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCREDITO_PROVEEDOR_DET_IDCommand(decimal credito_proveedor_det_id, bool credito_proveedor_det_idNull)
		{
			string whereSql = "";
			if(credito_proveedor_det_idNull)
				whereSql += "CREDITO_PROVEEDOR_DET_ID IS NULL";
			else
				whereSql += "CREDITO_PROVEEDOR_DET_ID=" + _db.CreateSqlParameterName("CREDITO_PROVEEDOR_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!credito_proveedor_det_idNull)
				AddParameter(cmd, "CREDITO_PROVEEDOR_DET_ID", credito_proveedor_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROVEEDOR_RELAC_ID(decimal ctacte_proveedor_relac_id)
		{
			return DeleteByCTACTE_PROVEEDOR_RELAC_ID(ctacte_proveedor_relac_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_relac_idNull">true if the method ignores the ctacte_proveedor_relac_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PROVEEDOR_RELAC_ID(decimal ctacte_proveedor_relac_id, bool ctacte_proveedor_relac_idNull)
		{
			return CreateDeleteByCTACTE_PROVEEDOR_RELAC_IDCommand(ctacte_proveedor_relac_id, ctacte_proveedor_relac_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_CTA_P</c> foreign key.
		/// </summary>
		/// <param name="ctacte_proveedor_relac_id">The <c>CTACTE_PROVEEDOR_RELAC_ID</c> column value.</param>
		/// <param name="ctacte_proveedor_relac_idNull">true if the method ignores the ctacte_proveedor_relac_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PROVEEDOR_RELAC_IDCommand(decimal ctacte_proveedor_relac_id, bool ctacte_proveedor_relac_idNull)
		{
			string whereSql = "";
			if(ctacte_proveedor_relac_idNull)
				whereSql += "CTACTE_PROVEEDOR_RELAC_ID IS NULL";
			else
				whereSql += "CTACTE_PROVEEDOR_RELAC_ID=" + _db.CreateSqlParameterName("CTACTE_PROVEEDOR_RELAC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_proveedor_relac_idNull)
				AddParameter(cmd, "CTACTE_PROVEEDOR_RELAC_ID", ctacte_proveedor_relac_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id)
		{
			return DeleteByEGRESO_VARIO_CAJA_ID(egreso_vario_caja_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByEGRESO_VARIO_CAJA_ID(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			return CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(egreso_vario_caja_id, egreso_vario_caja_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_EGRESO_V</c> foreign key.
		/// </summary>
		/// <param name="egreso_vario_caja_id">The <c>EGRESO_VARIO_CAJA_ID</c> column value.</param>
		/// <param name="egreso_vario_caja_idNull">true if the method ignores the egreso_vario_caja_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByEGRESO_VARIO_CAJA_IDCommand(decimal egreso_vario_caja_id, bool egreso_vario_caja_idNull)
		{
			string whereSql = "";
			if(egreso_vario_caja_idNull)
				whereSql += "EGRESO_VARIO_CAJA_ID IS NULL";
			else
				whereSql += "EGRESO_VARIO_CAJA_ID=" + _db.CreateSqlParameterName("EGRESO_VARIO_CAJA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!egreso_vario_caja_idNull)
				AddParameter(cmd, "EGRESO_VARIO_CAJA_ID", egreso_vario_caja_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return CreateDeleteByMONEDA_IDCommand(moneda_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id)
		{
			return DeleteByMOVIMIENTO_VARIO_TESORERIA_ID(movimiento_vario_tesoreria_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMOVIMIENTO_VARIO_TESORERIA_ID(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			return CreateDeleteByMOVIMIENTO_VARIO_TESORERIA_IDCommand(movimiento_vario_tesoreria_id, movimiento_vario_tesoreria_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_MOV_V_T</c> foreign key.
		/// </summary>
		/// <param name="movimiento_vario_tesoreria_id">The <c>MOVIMIENTO_VARIO_TESORERIA_ID</c> column value.</param>
		/// <param name="movimiento_vario_tesoreria_idNull">true if the method ignores the movimiento_vario_tesoreria_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByMOVIMIENTO_VARIO_TESORERIA_IDCommand(decimal movimiento_vario_tesoreria_id, bool movimiento_vario_tesoreria_idNull)
		{
			string whereSql = "";
			if(movimiento_vario_tesoreria_idNull)
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID IS NULL";
			else
				whereSql += "MOVIMIENTO_VARIO_TESORERIA_ID=" + _db.CreateSqlParameterName("MOVIMIENTO_VARIO_TESORERIA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!movimiento_vario_tesoreria_idNull)
				AddParameter(cmd, "MOVIMIENTO_VARIO_TESORERIA_ID", movimiento_vario_tesoreria_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id)
		{
			return DeleteByORDEN_PAGO_ID(orden_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_ID(decimal orden_pago_id, bool orden_pago_idNull)
		{
			return CreateDeleteByORDEN_PAGO_IDCommand(orden_pago_id, orden_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_OP</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_id">The <c>ORDEN_PAGO_ID</c> column value.</param>
		/// <param name="orden_pago_idNull">true if the method ignores the orden_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_IDCommand(decimal orden_pago_id, bool orden_pago_idNull)
		{
			string whereSql = "";
			if(orden_pago_idNull)
				whereSql += "ORDEN_PAGO_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!orden_pago_idNull)
				AddParameter(cmd, "ORDEN_PAGO_ID", orden_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id)
		{
			return DeleteByORDEN_PAGO_VALOR_ID(orden_pago_valor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByORDEN_PAGO_VALOR_ID(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			return CreateDeleteByORDEN_PAGO_VALOR_IDCommand(orden_pago_valor_id, orden_pago_valor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_OP_VAL</c> foreign key.
		/// </summary>
		/// <param name="orden_pago_valor_id">The <c>ORDEN_PAGO_VALOR_ID</c> column value.</param>
		/// <param name="orden_pago_valor_idNull">true if the method ignores the orden_pago_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByORDEN_PAGO_VALOR_IDCommand(decimal orden_pago_valor_id, bool orden_pago_valor_idNull)
		{
			string whereSql = "";
			if(orden_pago_valor_idNull)
				whereSql += "ORDEN_PAGO_VALOR_ID IS NULL";
			else
				whereSql += "ORDEN_PAGO_VALOR_ID=" + _db.CreateSqlParameterName("ORDEN_PAGO_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!orden_pago_valor_idNull)
				AddParameter(cmd, "ORDEN_PAGO_VALOR_ID", orden_pago_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id)
		{
			return DeleteByCTACTE_PAGARE_DET_ID(ctacte_pagare_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_PAGARE_DET_ID(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			return CreateDeleteByCTACTE_PAGARE_DET_IDCommand(ctacte_pagare_det_id, ctacte_pagare_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_PAGARE</c> foreign key.
		/// </summary>
		/// <param name="ctacte_pagare_det_id">The <c>CTACTE_PAGARE_DET_ID</c> column value.</param>
		/// <param name="ctacte_pagare_det_idNull">true if the method ignores the ctacte_pagare_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_PAGARE_DET_IDCommand(decimal ctacte_pagare_det_id, bool ctacte_pagare_det_idNull)
		{
			string whereSql = "";
			if(ctacte_pagare_det_idNull)
				whereSql += "CTACTE_PAGARE_DET_ID IS NULL";
			else
				whereSql += "CTACTE_PAGARE_DET_ID=" + _db.CreateSqlParameterName("CTACTE_PAGARE_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_pagare_det_idNull)
				AddParameter(cmd, "CTACTE_PAGARE_DET_ID", ctacte_pagare_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_PROV</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id)
		{
			string whereSql = "";
			whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id)
		{
			return DeleteByCTACTE_VALOR_ID(ctacte_valor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_VALOR_ID(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			return CreateDeleteByCTACTE_VALOR_IDCommand(ctacte_valor_id, ctacte_valor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTACTE_PROVEEDORES_VALOR</c> foreign key.
		/// </summary>
		/// <param name="ctacte_valor_id">The <c>CTACTE_VALOR_ID</c> column value.</param>
		/// <param name="ctacte_valor_idNull">true if the method ignores the ctacte_valor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_VALOR_IDCommand(decimal ctacte_valor_id, bool ctacte_valor_idNull)
		{
			string whereSql = "";
			if(ctacte_valor_idNull)
				whereSql += "CTACTE_VALOR_ID IS NULL";
			else
				whereSql += "CTACTE_VALOR_ID=" + _db.CreateSqlParameterName("CTACTE_VALOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_valor_idNull)
				AddParameter(cmd, "CTACTE_VALOR_ID", ctacte_valor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_APLICACION_DET_ID(decimal nc_aplicacion_det_id)
		{
			return DeleteByNC_APLICACION_DET_ID(nc_aplicacion_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <param name="nc_aplicacion_det_idNull">true if the method ignores the nc_aplicacion_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_APLICACION_DET_ID(decimal nc_aplicacion_det_id, bool nc_aplicacion_det_idNull)
		{
			return CreateDeleteByNC_APLICACION_DET_IDCommand(nc_aplicacion_det_id, nc_aplicacion_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTATE_PROV_NC_APLIC_DET</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_det_id">The <c>NC_APLICACION_DET_ID</c> column value.</param>
		/// <param name="nc_aplicacion_det_idNull">true if the method ignores the nc_aplicacion_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNC_APLICACION_DET_IDCommand(decimal nc_aplicacion_det_id, bool nc_aplicacion_det_idNull)
		{
			string whereSql = "";
			if(nc_aplicacion_det_idNull)
				whereSql += "NC_APLICACION_DET_ID IS NULL";
			else
				whereSql += "NC_APLICACION_DET_ID=" + _db.CreateSqlParameterName("NC_APLICACION_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nc_aplicacion_det_idNull)
				AddParameter(cmd, "NC_APLICACION_DET_ID", nc_aplicacion_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_APLICACION_ID(decimal nc_aplicacion_id)
		{
			return DeleteByNC_APLICACION_ID(nc_aplicacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CTACTE_PROVEEDORES</c> table using the 
		/// <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <param name="nc_aplicacion_idNull">true if the method ignores the nc_aplicacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByNC_APLICACION_ID(decimal nc_aplicacion_id, bool nc_aplicacion_idNull)
		{
			return CreateDeleteByNC_APLICACION_IDCommand(nc_aplicacion_id, nc_aplicacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CTATE_PROV_NC_APLICACION</c> foreign key.
		/// </summary>
		/// <param name="nc_aplicacion_id">The <c>NC_APLICACION_ID</c> column value.</param>
		/// <param name="nc_aplicacion_idNull">true if the method ignores the nc_aplicacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByNC_APLICACION_IDCommand(decimal nc_aplicacion_id, bool nc_aplicacion_idNull)
		{
			string whereSql = "";
			if(nc_aplicacion_idNull)
				whereSql += "NC_APLICACION_ID IS NULL";
			else
				whereSql += "NC_APLICACION_ID=" + _db.CreateSqlParameterName("NC_APLICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!nc_aplicacion_idNull)
				AddParameter(cmd, "NC_APLICACION_ID", nc_aplicacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CTACTE_PROVEEDORES</c> records that match the specified criteria.
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
		/// to delete <c>CTACTE_PROVEEDORES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CTACTE_PROVEEDORES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CTACTE_PROVEEDORES</c> table.
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		protected CTACTE_PROVEEDORESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		protected CTACTE_PROVEEDORESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CTACTE_PROVEEDORESRow"/> objects.</returns>
		protected virtual CTACTE_PROVEEDORESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int fecha_insercionColumnIndex = reader.GetOrdinal("FECHA_INSERCION");
			int fecha_vencimientoColumnIndex = reader.GetOrdinal("FECHA_VENCIMIENTO");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int ctacte_concepto_idColumnIndex = reader.GetOrdinal("CTACTE_CONCEPTO_ID");
			int ctacte_valor_idColumnIndex = reader.GetOrdinal("CTACTE_VALOR_ID");
			int orden_pago_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_ID");
			int movimiento_vario_tesoreria_idColumnIndex = reader.GetOrdinal("MOVIMIENTO_VARIO_TESORERIA_ID");
			int egreso_vario_caja_idColumnIndex = reader.GetOrdinal("EGRESO_VARIO_CAJA_ID");
			int ctacte_pagare_det_idColumnIndex = reader.GetOrdinal("CTACTE_PAGARE_DET_ID");
			int calendario_pagos_fc_prov_idColumnIndex = reader.GetOrdinal("CALENDARIO_PAGOS_FC_PROV_ID");
			int credito_proveedor_det_idColumnIndex = reader.GetOrdinal("CREDITO_PROVEEDOR_DET_ID");
			int creditoColumnIndex = reader.GetOrdinal("CREDITO");
			int debitoColumnIndex = reader.GetOrdinal("DEBITO");
			int conceptoColumnIndex = reader.GetOrdinal("CONCEPTO");
			int ctacte_proveedor_relac_idColumnIndex = reader.GetOrdinal("CTACTE_PROVEEDOR_RELAC_ID");
			int nc_aplicacion_idColumnIndex = reader.GetOrdinal("NC_APLICACION_ID");
			int nc_aplicacion_det_idColumnIndex = reader.GetOrdinal("NC_APLICACION_DET_ID");
			int orden_pago_valor_idColumnIndex = reader.GetOrdinal("ORDEN_PAGO_VALOR_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CTACTE_PROVEEDORESRow record = new CTACTE_PROVEEDORESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					record.FECHA_INSERCION = Convert.ToDateTime(reader.GetValue(fecha_insercionColumnIndex));
					record.FECHA_VENCIMIENTO = Convert.ToDateTime(reader.GetValue(fecha_vencimientoColumnIndex));
					record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.CTACTE_CONCEPTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_concepto_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_valor_idColumnIndex))
						record.CTACTE_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_valor_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_idColumnIndex))
						record.ORDEN_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(movimiento_vario_tesoreria_idColumnIndex))
						record.MOVIMIENTO_VARIO_TESORERIA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(movimiento_vario_tesoreria_idColumnIndex)), 9);
					if(!reader.IsDBNull(egreso_vario_caja_idColumnIndex))
						record.EGRESO_VARIO_CAJA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(egreso_vario_caja_idColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_pagare_det_idColumnIndex))
						record.CTACTE_PAGARE_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_pagare_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(calendario_pagos_fc_prov_idColumnIndex))
						record.CALENDARIO_PAGOS_FC_PROV_ID = Math.Round(Convert.ToDecimal(reader.GetValue(calendario_pagos_fc_prov_idColumnIndex)), 9);
					if(!reader.IsDBNull(credito_proveedor_det_idColumnIndex))
						record.CREDITO_PROVEEDOR_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(credito_proveedor_det_idColumnIndex)), 9);
					record.CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(creditoColumnIndex)), 9);
					record.DEBITO = Math.Round(Convert.ToDecimal(reader.GetValue(debitoColumnIndex)), 9);
					if(!reader.IsDBNull(conceptoColumnIndex))
						record.CONCEPTO = Convert.ToString(reader.GetValue(conceptoColumnIndex));
					if(!reader.IsDBNull(ctacte_proveedor_relac_idColumnIndex))
						record.CTACTE_PROVEEDOR_RELAC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_proveedor_relac_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_aplicacion_idColumnIndex))
						record.NC_APLICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_aplicacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nc_aplicacion_det_idColumnIndex))
						record.NC_APLICACION_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(nc_aplicacion_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(orden_pago_valor_idColumnIndex))
						record.ORDEN_PAGO_VALOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(orden_pago_valor_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CTACTE_PROVEEDORESRow[])(recordList.ToArray(typeof(CTACTE_PROVEEDORESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CTACTE_PROVEEDORESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CTACTE_PROVEEDORESRow"/> object.</returns>
		protected virtual CTACTE_PROVEEDORESRow MapRow(DataRow row)
		{
			CTACTE_PROVEEDORESRow mappedObject = new CTACTE_PROVEEDORESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "FECHA_INSERCION"
			dataColumn = dataTable.Columns["FECHA_INSERCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSERCION = (System.DateTime)row[dataColumn];
			// Column "FECHA_VENCIMIENTO"
			dataColumn = dataTable.Columns["FECHA_VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "CTACTE_CONCEPTO_ID"
			dataColumn = dataTable.Columns["CTACTE_CONCEPTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_CONCEPTO_ID = (decimal)row[dataColumn];
			// Column "CTACTE_VALOR_ID"
			dataColumn = dataTable.Columns["CTACTE_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_VALOR_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_ID = (decimal)row[dataColumn];
			// Column "MOVIMIENTO_VARIO_TESORERIA_ID"
			dataColumn = dataTable.Columns["MOVIMIENTO_VARIO_TESORERIA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MOVIMIENTO_VARIO_TESORERIA_ID = (decimal)row[dataColumn];
			// Column "EGRESO_VARIO_CAJA_ID"
			dataColumn = dataTable.Columns["EGRESO_VARIO_CAJA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.EGRESO_VARIO_CAJA_ID = (decimal)row[dataColumn];
			// Column "CTACTE_PAGARE_DET_ID"
			dataColumn = dataTable.Columns["CTACTE_PAGARE_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PAGARE_DET_ID = (decimal)row[dataColumn];
			// Column "CALENDARIO_PAGOS_FC_PROV_ID"
			dataColumn = dataTable.Columns["CALENDARIO_PAGOS_FC_PROV_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CALENDARIO_PAGOS_FC_PROV_ID = (decimal)row[dataColumn];
			// Column "CREDITO_PROVEEDOR_DET_ID"
			dataColumn = dataTable.Columns["CREDITO_PROVEEDOR_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO_PROVEEDOR_DET_ID = (decimal)row[dataColumn];
			// Column "CREDITO"
			dataColumn = dataTable.Columns["CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CREDITO = (decimal)row[dataColumn];
			// Column "DEBITO"
			dataColumn = dataTable.Columns["DEBITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEBITO = (decimal)row[dataColumn];
			// Column "CONCEPTO"
			dataColumn = dataTable.Columns["CONCEPTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONCEPTO = (string)row[dataColumn];
			// Column "CTACTE_PROVEEDOR_RELAC_ID"
			dataColumn = dataTable.Columns["CTACTE_PROVEEDOR_RELAC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_PROVEEDOR_RELAC_ID = (decimal)row[dataColumn];
			// Column "NC_APLICACION_ID"
			dataColumn = dataTable.Columns["NC_APLICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_APLICACION_ID = (decimal)row[dataColumn];
			// Column "NC_APLICACION_DET_ID"
			dataColumn = dataTable.Columns["NC_APLICACION_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.NC_APLICACION_DET_ID = (decimal)row[dataColumn];
			// Column "ORDEN_PAGO_VALOR_ID"
			dataColumn = dataTable.Columns["ORDEN_PAGO_VALOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_PAGO_VALOR_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CTACTE_PROVEEDORES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CTACTE_PROVEEDORES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_INSERCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_VENCIMIENTO", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_CONCEPTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_VALOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MOVIMIENTO_VARIO_TESORERIA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("EGRESO_VARIO_CAJA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CTACTE_PAGARE_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CALENDARIO_PAGOS_FC_PROV_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CREDITO_PROVEEDOR_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("DEBITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONCEPTO", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CTACTE_PROVEEDOR_RELAC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NC_APLICACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NC_APLICACION_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN_PAGO_VALOR_ID", typeof(decimal));
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

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INSERCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_CONCEPTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MOVIMIENTO_VARIO_TESORERIA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "EGRESO_VARIO_CAJA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_PAGARE_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CALENDARIO_PAGOS_FC_PROV_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO_PROVEEDOR_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEBITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONCEPTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CTACTE_PROVEEDOR_RELAC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_APLICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NC_APLICACION_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_PAGO_VALOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CTACTE_PROVEEDORESCollection_Base class
}  // End of namespace
