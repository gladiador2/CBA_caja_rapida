// <fileinfo name="PEDIDOS_PROVEEDORCollection_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_PROVEEDORCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PEDIDOS_PROVEEDORCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_PROVEEDORCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string SUCURSAL_IDColumnName = "SUCURSAL_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string FECHA_PEDIDOColumnName = "FECHA_PEDIDO";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string MONEDA_IDColumnName = "MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string AFECTA_LINEA_CREDITOColumnName = "AFECTA_LINEA_CREDITO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string NUMERO_CONTRATOColumnName = "NUMERO_CONTRATO";
		public const string CASO_FACTURA_PROVEEDOR_IDColumnName = "CASO_FACTURA_PROVEEDOR_ID";
		public const string INVOICEColumnName = "INVOICE";
		public const string FECHA_INVOICEColumnName = "FECHA_INVOICE";
		public const string ESTADO_DOCUMENTACION_IDColumnName = "ESTADO_DOCUMENTACION_ID";
		public const string TIPO_EMBARQUE_IDColumnName = "TIPO_EMBARQUE_ID";
		public const string TIPO_CONTENEDOR_IDColumnName = "TIPO_CONTENEDOR_ID";
		public const string CANTIDAD_CONTENEDORESColumnName = "CANTIDAD_CONTENEDORES";
		public const string TOTAL_BRUTO_PEDIDOColumnName = "TOTAL_BRUTO_PEDIDO";
		public const string TOTAL_DTO_PEDIDOColumnName = "TOTAL_DTO_PEDIDO";
		public const string TOTAL_NETO_PEDIDOColumnName = "TOTAL_NETO_PEDIDO";
		public const string TOTAL_IMP_PEDIDOColumnName = "TOTAL_IMP_PEDIDO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_PROVEEDORCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PEDIDOS_PROVEEDORCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PEDIDOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PEDIDOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PEDIDOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PEDIDOS_PROVEEDORRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PEDIDOS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PEDIDOS_PROVEEDORRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PEDIDOS_PROVEEDORRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects that 
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PEDIDOS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PEDIDOS_PROVEEDORRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PEDIDOS_PROVEEDORRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PEDIDOS_PROVEEDORRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PEDIDOS_PROVEEDORRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <param name="autonumeracion_idNull">true if the method ignores the autonumeracion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByAUTONUMERACION_ID(decimal autonumeracion_id, bool autonumeracion_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_IDCommand(autonumeracion_id, autonumeracion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_IDAsDataTable(decimal autonumeracion_id)
		{
			return GetByAUTONUMERACION_IDAsDataTable(autonumeracion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
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
		/// return records by the <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
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
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByCASO_ID(decimal caso_id)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return MapRecordsToDataTable(CreateGetByCASO_IDCommand(caso_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_CASO</c> foreign key.
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
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByCASO_FACTURA_PROVEEDOR_ID(decimal caso_factura_proveedor_id)
		{
			return GetByCASO_FACTURA_PROVEEDOR_ID(caso_factura_proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_factura_proveedor_idNull">true if the method ignores the caso_factura_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByCASO_FACTURA_PROVEEDOR_ID(decimal caso_factura_proveedor_id, bool caso_factura_proveedor_idNull)
		{
			return MapRecords(CreateGetByCASO_FACTURA_PROVEEDOR_IDCommand(caso_factura_proveedor_id, caso_factura_proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_FACTURA_PROVEEDOR_IDAsDataTable(decimal caso_factura_proveedor_id)
		{
			return GetByCASO_FACTURA_PROVEEDOR_IDAsDataTable(caso_factura_proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_factura_proveedor_idNull">true if the method ignores the caso_factura_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_FACTURA_PROVEEDOR_IDAsDataTable(decimal caso_factura_proveedor_id, bool caso_factura_proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_FACTURA_PROVEEDOR_IDCommand(caso_factura_proveedor_id, caso_factura_proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_factura_proveedor_idNull">true if the method ignores the caso_factura_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_FACTURA_PROVEEDOR_IDCommand(decimal caso_factura_proveedor_id, bool caso_factura_proveedor_idNull)
		{
			string whereSql = "";
			if(caso_factura_proveedor_idNull)
				whereSql += "CASO_FACTURA_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CASO_FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_factura_proveedor_idNull)
				AddParameter(cmd, "CASO_FACTURA_PROVEEDOR_ID", caso_factura_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecords(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id)
		{
			return GetByCONDICION_PAGO_IDAsDataTable(condicion_pago_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return GetByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return GetByDEPOSITO_IDAsDataTable(deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecords(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id)
		{
			return GetByESTADO_DOCUMENTACION_IDAsDataTable(estado_documentacion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByESTADO_DOCUMENTACION_IDAsDataTable(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByMONEDA_ID(decimal moneda_id)
		{
			return GetByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <param name="moneda_idNull">true if the method ignores the moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByMONEDA_ID(decimal moneda_id, bool moneda_idNull)
		{
			return MapRecords(CreateGetByMONEDA_IDCommand(moneda_id, moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_IDAsDataTable(decimal moneda_id)
		{
			return GetByMONEDA_IDAsDataTable(moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
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
		/// return records by the <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetBySUCURSAL_ID(decimal sucursal_id)
		{
			return GetBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id)
		{
			return GetBySUCURSAL_IDAsDataTable(sucursal_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetBySUCURSAL_IDAsDataTable(decimal sucursal_id, bool sucursal_idNull)
		{
			return MapRecordsToDataTable(CreateGetBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return GetByTIPO_CONTENEDOR_ID(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return MapRecords(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id)
		{
			return GetByTIPO_CONTENEDOR_IDAsDataTable(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CONTENEDOR_IDAsDataTable(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			string whereSql = "";
			if(tipo_contenedor_idNull)
				whereSql += "TIPO_CONTENEDOR_ID IS NULL";
			else
				whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_contenedor_idNull)
				AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public PEDIDOS_PROVEEDORRow[] GetByTIPO_EMBARQUE_ID(decimal tipo_embarque_id)
		{
			return GetByTIPO_EMBARQUE_ID(tipo_embarque_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_PROVEEDORRow"/> objects 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		public virtual PEDIDOS_PROVEEDORRow[] GetByTIPO_EMBARQUE_ID(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			return MapRecords(CreateGetByTIPO_EMBARQUE_IDCommand(tipo_embarque_id, tipo_embarque_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_EMBARQUE_IDAsDataTable(decimal tipo_embarque_id)
		{
			return GetByTIPO_EMBARQUE_IDAsDataTable(tipo_embarque_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_EMBARQUE_IDAsDataTable(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_EMBARQUE_IDCommand(tipo_embarque_id, tipo_embarque_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_EMBARQUE_IDCommand(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			string whereSql = "";
			if(tipo_embarque_idNull)
				whereSql += "TIPO_EMBARQUE_ID IS NULL";
			else
				whereSql += "TIPO_EMBARQUE_ID=" + _db.CreateSqlParameterName("TIPO_EMBARQUE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_embarque_idNull)
				AddParameter(cmd, "TIPO_EMBARQUE_ID", tipo_embarque_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PEDIDOS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_PROVEEDORRow"/> object to be inserted.</param>
		public virtual void Insert(PEDIDOS_PROVEEDORRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PEDIDOS_PROVEEDOR (" +
				"ID, " +
				"CASO_ID, " +
				"SUCURSAL_ID, " +
				"DEPOSITO_ID, " +
				"FECHA_PEDIDO, " +
				"PROVEEDOR_ID, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"CONDICION_PAGO_ID, " +
				"MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"AFECTA_LINEA_CREDITO, " +
				"OBSERVACION, " +
				"NUMERO_CONTRATO, " +
				"CASO_FACTURA_PROVEEDOR_ID, " +
				"INVOICE, " +
				"FECHA_INVOICE, " +
				"ESTADO_DOCUMENTACION_ID, " +
				"TIPO_EMBARQUE_ID, " +
				"TIPO_CONTENEDOR_ID, " +
				"CANTIDAD_CONTENEDORES, " +
				"TOTAL_BRUTO_PEDIDO, " +
				"TOTAL_DTO_PEDIDO, " +
				"TOTAL_NETO_PEDIDO, " +
				"TOTAL_IMP_PEDIDO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_PEDIDO") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("AFECTA_LINEA_CREDITO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("NUMERO_CONTRATO") + ", " +
				_db.CreateSqlParameterName("CASO_FACTURA_PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("INVOICE") + ", " +
				_db.CreateSqlParameterName("FECHA_INVOICE") + ", " +
				_db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_EMBARQUE_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CONTENEDORES") + ", " +
				_db.CreateSqlParameterName("TOTAL_BRUTO_PEDIDO") + ", " +
				_db.CreateSqlParameterName("TOTAL_DTO_PEDIDO") + ", " +
				_db.CreateSqlParameterName("TOTAL_NETO_PEDIDO") + ", " +
				_db.CreateSqlParameterName("TOTAL_IMP_PEDIDO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA_PEDIDO",
				value.IsFECHA_PEDIDONull ? DBNull.Value : (object)value.FECHA_PEDIDO);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "AFECTA_LINEA_CREDITO", value.AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "NUMERO_CONTRATO", value.NUMERO_CONTRATO);
			AddParameter(cmd, "CASO_FACTURA_PROVEEDOR_ID",
				value.IsCASO_FACTURA_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CASO_FACTURA_PROVEEDOR_ID);
			AddParameter(cmd, "INVOICE", value.INVOICE);
			AddParameter(cmd, "FECHA_INVOICE",
				value.IsFECHA_INVOICENull ? DBNull.Value : (object)value.FECHA_INVOICE);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "TIPO_EMBARQUE_ID",
				value.IsTIPO_EMBARQUE_IDNull ? DBNull.Value : (object)value.TIPO_EMBARQUE_ID);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID",
				value.IsTIPO_CONTENEDOR_IDNull ? DBNull.Value : (object)value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "CANTIDAD_CONTENEDORES",
				value.IsCANTIDAD_CONTENEDORESNull ? DBNull.Value : (object)value.CANTIDAD_CONTENEDORES);
			AddParameter(cmd, "TOTAL_BRUTO_PEDIDO",
				value.IsTOTAL_BRUTO_PEDIDONull ? DBNull.Value : (object)value.TOTAL_BRUTO_PEDIDO);
			AddParameter(cmd, "TOTAL_DTO_PEDIDO",
				value.IsTOTAL_DTO_PEDIDONull ? DBNull.Value : (object)value.TOTAL_DTO_PEDIDO);
			AddParameter(cmd, "TOTAL_NETO_PEDIDO",
				value.IsTOTAL_NETO_PEDIDONull ? DBNull.Value : (object)value.TOTAL_NETO_PEDIDO);
			AddParameter(cmd, "TOTAL_IMP_PEDIDO",
				value.IsTOTAL_IMP_PEDIDONull ? DBNull.Value : (object)value.TOTAL_IMP_PEDIDO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PEDIDOS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_PROVEEDORRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PEDIDOS_PROVEEDORRow value)
		{
			
			string sqlStr = "UPDATE TRC.PEDIDOS_PROVEEDOR SET " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"FECHA_PEDIDO=" + _db.CreateSqlParameterName("FECHA_PEDIDO") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				"MONEDA_ID=" + _db.CreateSqlParameterName("MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"AFECTA_LINEA_CREDITO=" + _db.CreateSqlParameterName("AFECTA_LINEA_CREDITO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"NUMERO_CONTRATO=" + _db.CreateSqlParameterName("NUMERO_CONTRATO") + ", " +
				"CASO_FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_PROVEEDOR_ID") + ", " +
				"INVOICE=" + _db.CreateSqlParameterName("INVOICE") + ", " +
				"FECHA_INVOICE=" + _db.CreateSqlParameterName("FECHA_INVOICE") + ", " +
				"ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID") + ", " +
				"TIPO_EMBARQUE_ID=" + _db.CreateSqlParameterName("TIPO_EMBARQUE_ID") + ", " +
				"TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID") + ", " +
				"CANTIDAD_CONTENEDORES=" + _db.CreateSqlParameterName("CANTIDAD_CONTENEDORES") + ", " +
				"TOTAL_BRUTO_PEDIDO=" + _db.CreateSqlParameterName("TOTAL_BRUTO_PEDIDO") + ", " +
				"TOTAL_DTO_PEDIDO=" + _db.CreateSqlParameterName("TOTAL_DTO_PEDIDO") + ", " +
				"TOTAL_NETO_PEDIDO=" + _db.CreateSqlParameterName("TOTAL_NETO_PEDIDO") + ", " +
				"TOTAL_IMP_PEDIDO=" + _db.CreateSqlParameterName("TOTAL_IMP_PEDIDO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "CASO_ID", value.CASO_ID);
			AddParameter(cmd, "SUCURSAL_ID",
				value.IsSUCURSAL_IDNull ? DBNull.Value : (object)value.SUCURSAL_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "FECHA_PEDIDO",
				value.IsFECHA_PEDIDONull ? DBNull.Value : (object)value.FECHA_PEDIDO);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "CONDICION_PAGO_ID",
				value.IsCONDICION_PAGO_IDNull ? DBNull.Value : (object)value.CONDICION_PAGO_ID);
			AddParameter(cmd, "MONEDA_ID",
				value.IsMONEDA_IDNull ? DBNull.Value : (object)value.MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "AFECTA_LINEA_CREDITO", value.AFECTA_LINEA_CREDITO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "NUMERO_CONTRATO", value.NUMERO_CONTRATO);
			AddParameter(cmd, "CASO_FACTURA_PROVEEDOR_ID",
				value.IsCASO_FACTURA_PROVEEDOR_IDNull ? DBNull.Value : (object)value.CASO_FACTURA_PROVEEDOR_ID);
			AddParameter(cmd, "INVOICE", value.INVOICE);
			AddParameter(cmd, "FECHA_INVOICE",
				value.IsFECHA_INVOICENull ? DBNull.Value : (object)value.FECHA_INVOICE);
			AddParameter(cmd, "ESTADO_DOCUMENTACION_ID",
				value.IsESTADO_DOCUMENTACION_IDNull ? DBNull.Value : (object)value.ESTADO_DOCUMENTACION_ID);
			AddParameter(cmd, "TIPO_EMBARQUE_ID",
				value.IsTIPO_EMBARQUE_IDNull ? DBNull.Value : (object)value.TIPO_EMBARQUE_ID);
			AddParameter(cmd, "TIPO_CONTENEDOR_ID",
				value.IsTIPO_CONTENEDOR_IDNull ? DBNull.Value : (object)value.TIPO_CONTENEDOR_ID);
			AddParameter(cmd, "CANTIDAD_CONTENEDORES",
				value.IsCANTIDAD_CONTENEDORESNull ? DBNull.Value : (object)value.CANTIDAD_CONTENEDORES);
			AddParameter(cmd, "TOTAL_BRUTO_PEDIDO",
				value.IsTOTAL_BRUTO_PEDIDONull ? DBNull.Value : (object)value.TOTAL_BRUTO_PEDIDO);
			AddParameter(cmd, "TOTAL_DTO_PEDIDO",
				value.IsTOTAL_DTO_PEDIDONull ? DBNull.Value : (object)value.TOTAL_DTO_PEDIDO);
			AddParameter(cmd, "TOTAL_NETO_PEDIDO",
				value.IsTOTAL_NETO_PEDIDONull ? DBNull.Value : (object)value.TOTAL_NETO_PEDIDO);
			AddParameter(cmd, "TOTAL_IMP_PEDIDO",
				value.IsTOTAL_IMP_PEDIDONull ? DBNull.Value : (object)value.TOTAL_IMP_PEDIDO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PEDIDOS_PROVEEDOR</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PEDIDOS_PROVEEDOR</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PEDIDOS_PROVEEDOR</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_PROVEEDORRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PEDIDOS_PROVEEDORRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PEDIDOS_PROVEEDOR</c> table using
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
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_id">The <c>AUTONUMERACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_ID(decimal autonumeracion_id)
		{
			return DeleteByAUTONUMERACION_ID(autonumeracion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
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
		/// delete records using the <c>FK_PEDIDOS_PROV_AUTONUM</c> foreign key.
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
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_CASO</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return CreateDeleteByCASO_IDCommand(caso_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_CASO</c> foreign key.
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
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FACTURA_PROVEEDOR_ID(decimal caso_factura_proveedor_id)
		{
			return DeleteByCASO_FACTURA_PROVEEDOR_ID(caso_factura_proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_factura_proveedor_idNull">true if the method ignores the caso_factura_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_FACTURA_PROVEEDOR_ID(decimal caso_factura_proveedor_id, bool caso_factura_proveedor_idNull)
		{
			return CreateDeleteByCASO_FACTURA_PROVEEDOR_IDCommand(caso_factura_proveedor_id, caso_factura_proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_CASO_FACT</c> foreign key.
		/// </summary>
		/// <param name="caso_factura_proveedor_id">The <c>CASO_FACTURA_PROVEEDOR_ID</c> column value.</param>
		/// <param name="caso_factura_proveedor_idNull">true if the method ignores the caso_factura_proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_FACTURA_PROVEEDOR_IDCommand(decimal caso_factura_proveedor_id, bool caso_factura_proveedor_idNull)
		{
			string whereSql = "";
			if(caso_factura_proveedor_idNull)
				whereSql += "CASO_FACTURA_PROVEEDOR_ID IS NULL";
			else
				whereSql += "CASO_FACTURA_PROVEEDOR_ID=" + _db.CreateSqlParameterName("CASO_FACTURA_PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_factura_proveedor_idNull)
				AddParameter(cmd, "CASO_FACTURA_PROVEEDOR_ID", caso_factura_proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return DeleteByCONDICION_PAGO_ID(condicion_pago_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			return CreateDeleteByCONDICION_PAGO_IDCommand(condicion_pago_id, condicion_pago_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_COND_PAGO</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <param name="condicion_pago_idNull">true if the method ignores the condicion_pago_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_PAGO_IDCommand(decimal condicion_pago_id, bool condicion_pago_idNull)
		{
			string whereSql = "";
			if(condicion_pago_idNull)
				whereSql += "CONDICION_PAGO_ID IS NULL";
			else
				whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!condicion_pago_idNull)
				AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return DeleteByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return CreateDeleteByDEPOSITO_IDCommand(deposito_id, deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_DEPOSITO</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_IDCommand(decimal deposito_id, bool deposito_idNull)
		{
			string whereSql = "";
			if(deposito_idNull)
				whereSql += "DEPOSITO_ID IS NULL";
			else
				whereSql += "DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_idNull)
				AddParameter(cmd, "DEPOSITO_ID", deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id)
		{
			return DeleteByESTADO_DOCUMENTACION_ID(estado_documentacion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByESTADO_DOCUMENTACION_ID(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			return CreateDeleteByESTADO_DOCUMENTACION_IDCommand(estado_documentacion_id, estado_documentacion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_ESTADO_DOC</c> foreign key.
		/// </summary>
		/// <param name="estado_documentacion_id">The <c>ESTADO_DOCUMENTACION_ID</c> column value.</param>
		/// <param name="estado_documentacion_idNull">true if the method ignores the estado_documentacion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByESTADO_DOCUMENTACION_IDCommand(decimal estado_documentacion_id, bool estado_documentacion_idNull)
		{
			string whereSql = "";
			if(estado_documentacion_idNull)
				whereSql += "ESTADO_DOCUMENTACION_ID IS NULL";
			else
				whereSql += "ESTADO_DOCUMENTACION_ID=" + _db.CreateSqlParameterName("ESTADO_DOCUMENTACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!estado_documentacion_idNull)
				AddParameter(cmd, "ESTADO_DOCUMENTACION_ID", estado_documentacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_id">The <c>MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ID(decimal moneda_id)
		{
			return DeleteByMONEDA_ID(moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
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
		/// delete records using the <c>FK_PEDIDOS_PROV_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return CreateDeleteByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPROVEEDOR_IDCommand(decimal proveedor_id, bool proveedor_idNull)
		{
			string whereSql = "";
			if(proveedor_idNull)
				whereSql += "PROVEEDOR_ID IS NULL";
			else
				whereSql += "PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!proveedor_idNull)
				AddParameter(cmd, "PROVEEDOR_ID", proveedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id)
		{
			return DeleteBySUCURSAL_ID(sucursal_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_ID(decimal sucursal_id, bool sucursal_idNull)
		{
			return CreateDeleteBySUCURSAL_IDCommand(sucursal_id, sucursal_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_SUCURSAL</c> foreign key.
		/// </summary>
		/// <param name="sucursal_id">The <c>SUCURSAL_ID</c> column value.</param>
		/// <param name="sucursal_idNull">true if the method ignores the sucursal_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteBySUCURSAL_IDCommand(decimal sucursal_id, bool sucursal_idNull)
		{
			string whereSql = "";
			if(sucursal_idNull)
				whereSql += "SUCURSAL_ID IS NULL";
			else
				whereSql += "SUCURSAL_ID=" + _db.CreateSqlParameterName("SUCURSAL_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!sucursal_idNull)
				AddParameter(cmd, "SUCURSAL_ID", sucursal_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id)
		{
			return DeleteByTIPO_CONTENEDOR_ID(tipo_contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CONTENEDOR_ID(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			return CreateDeleteByTIPO_CONTENEDOR_IDCommand(tipo_contenedor_id, tipo_contenedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_TIPO_CONT</c> foreign key.
		/// </summary>
		/// <param name="tipo_contenedor_id">The <c>TIPO_CONTENEDOR_ID</c> column value.</param>
		/// <param name="tipo_contenedor_idNull">true if the method ignores the tipo_contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CONTENEDOR_IDCommand(decimal tipo_contenedor_id, bool tipo_contenedor_idNull)
		{
			string whereSql = "";
			if(tipo_contenedor_idNull)
				whereSql += "TIPO_CONTENEDOR_ID IS NULL";
			else
				whereSql += "TIPO_CONTENEDOR_ID=" + _db.CreateSqlParameterName("TIPO_CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_contenedor_idNull)
				AddParameter(cmd, "TIPO_CONTENEDOR_ID", tipo_contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_EMBARQUE_ID(decimal tipo_embarque_id)
		{
			return DeleteByTIPO_EMBARQUE_ID(tipo_embarque_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_PROVEEDOR</c> table using the 
		/// <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_EMBARQUE_ID(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			return CreateDeleteByTIPO_EMBARQUE_IDCommand(tipo_embarque_id, tipo_embarque_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDOS_PROV_TIPO_EMB</c> foreign key.
		/// </summary>
		/// <param name="tipo_embarque_id">The <c>TIPO_EMBARQUE_ID</c> column value.</param>
		/// <param name="tipo_embarque_idNull">true if the method ignores the tipo_embarque_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_EMBARQUE_IDCommand(decimal tipo_embarque_id, bool tipo_embarque_idNull)
		{
			string whereSql = "";
			if(tipo_embarque_idNull)
				whereSql += "TIPO_EMBARQUE_ID IS NULL";
			else
				whereSql += "TIPO_EMBARQUE_ID=" + _db.CreateSqlParameterName("TIPO_EMBARQUE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_embarque_idNull)
				AddParameter(cmd, "TIPO_EMBARQUE_ID", tipo_embarque_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PEDIDOS_PROVEEDOR</c> records that match the specified criteria.
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
		/// to delete <c>PEDIDOS_PROVEEDOR</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PEDIDOS_PROVEEDOR";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PEDIDOS_PROVEEDOR</c> table.
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		protected PEDIDOS_PROVEEDORRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		protected PEDIDOS_PROVEEDORRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PEDIDOS_PROVEEDORRow"/> objects.</returns>
		protected virtual PEDIDOS_PROVEEDORRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int sucursal_idColumnIndex = reader.GetOrdinal("SUCURSAL_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int fecha_pedidoColumnIndex = reader.GetOrdinal("FECHA_PEDIDO");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int moneda_idColumnIndex = reader.GetOrdinal("MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int afecta_linea_creditoColumnIndex = reader.GetOrdinal("AFECTA_LINEA_CREDITO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int numero_contratoColumnIndex = reader.GetOrdinal("NUMERO_CONTRATO");
			int caso_factura_proveedor_idColumnIndex = reader.GetOrdinal("CASO_FACTURA_PROVEEDOR_ID");
			int invoiceColumnIndex = reader.GetOrdinal("INVOICE");
			int fecha_invoiceColumnIndex = reader.GetOrdinal("FECHA_INVOICE");
			int estado_documentacion_idColumnIndex = reader.GetOrdinal("ESTADO_DOCUMENTACION_ID");
			int tipo_embarque_idColumnIndex = reader.GetOrdinal("TIPO_EMBARQUE_ID");
			int tipo_contenedor_idColumnIndex = reader.GetOrdinal("TIPO_CONTENEDOR_ID");
			int cantidad_contenedoresColumnIndex = reader.GetOrdinal("CANTIDAD_CONTENEDORES");
			int total_bruto_pedidoColumnIndex = reader.GetOrdinal("TOTAL_BRUTO_PEDIDO");
			int total_dto_pedidoColumnIndex = reader.GetOrdinal("TOTAL_DTO_PEDIDO");
			int total_neto_pedidoColumnIndex = reader.GetOrdinal("TOTAL_NETO_PEDIDO");
			int total_imp_pedidoColumnIndex = reader.GetOrdinal("TOTAL_IMP_PEDIDO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PEDIDOS_PROVEEDORRow record = new PEDIDOS_PROVEEDORRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_idColumnIndex))
						record.SUCURSAL_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_pedidoColumnIndex))
						record.FECHA_PEDIDO = Convert.ToDateTime(reader.GetValue(fecha_pedidoColumnIndex));
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(condicion_pago_idColumnIndex))
						record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_idColumnIndex))
						record.MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_monedaColumnIndex))
						record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					record.AFECTA_LINEA_CREDITO = Convert.ToString(reader.GetValue(afecta_linea_creditoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(numero_contratoColumnIndex))
						record.NUMERO_CONTRATO = Convert.ToString(reader.GetValue(numero_contratoColumnIndex));
					if(!reader.IsDBNull(caso_factura_proveedor_idColumnIndex))
						record.CASO_FACTURA_PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_factura_proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(invoiceColumnIndex))
						record.INVOICE = Convert.ToString(reader.GetValue(invoiceColumnIndex));
					if(!reader.IsDBNull(fecha_invoiceColumnIndex))
						record.FECHA_INVOICE = Convert.ToDateTime(reader.GetValue(fecha_invoiceColumnIndex));
					if(!reader.IsDBNull(estado_documentacion_idColumnIndex))
						record.ESTADO_DOCUMENTACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(estado_documentacion_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_embarque_idColumnIndex))
						record.TIPO_EMBARQUE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_embarque_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_contenedor_idColumnIndex))
						record.TIPO_CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_contenedoresColumnIndex))
						record.CANTIDAD_CONTENEDORES = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_contenedoresColumnIndex)), 9);
					if(!reader.IsDBNull(total_bruto_pedidoColumnIndex))
						record.TOTAL_BRUTO_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_bruto_pedidoColumnIndex)), 9);
					if(!reader.IsDBNull(total_dto_pedidoColumnIndex))
						record.TOTAL_DTO_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_dto_pedidoColumnIndex)), 9);
					if(!reader.IsDBNull(total_neto_pedidoColumnIndex))
						record.TOTAL_NETO_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_neto_pedidoColumnIndex)), 9);
					if(!reader.IsDBNull(total_imp_pedidoColumnIndex))
						record.TOTAL_IMP_PEDIDO = Math.Round(Convert.ToDecimal(reader.GetValue(total_imp_pedidoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PEDIDOS_PROVEEDORRow[])(recordList.ToArray(typeof(PEDIDOS_PROVEEDORRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PEDIDOS_PROVEEDORRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PEDIDOS_PROVEEDORRow"/> object.</returns>
		protected virtual PEDIDOS_PROVEEDORRow MapRow(DataRow row)
		{
			PEDIDOS_PROVEEDORRow mappedObject = new PEDIDOS_PROVEEDORRow();
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
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FECHA_PEDIDO"
			dataColumn = dataTable.Columns["FECHA_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_PEDIDO = (System.DateTime)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ID"
			dataColumn = dataTable.Columns["MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "AFECTA_LINEA_CREDITO"
			dataColumn = dataTable.Columns["AFECTA_LINEA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.AFECTA_LINEA_CREDITO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "NUMERO_CONTRATO"
			dataColumn = dataTable.Columns["NUMERO_CONTRATO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NUMERO_CONTRATO = (string)row[dataColumn];
			// Column "CASO_FACTURA_PROVEEDOR_ID"
			dataColumn = dataTable.Columns["CASO_FACTURA_PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_FACTURA_PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "INVOICE"
			dataColumn = dataTable.Columns["INVOICE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INVOICE = (string)row[dataColumn];
			// Column "FECHA_INVOICE"
			dataColumn = dataTable.Columns["FECHA_INVOICE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INVOICE = (System.DateTime)row[dataColumn];
			// Column "ESTADO_DOCUMENTACION_ID"
			dataColumn = dataTable.Columns["ESTADO_DOCUMENTACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_DOCUMENTACION_ID = (decimal)row[dataColumn];
			// Column "TIPO_EMBARQUE_ID"
			dataColumn = dataTable.Columns["TIPO_EMBARQUE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_EMBARQUE_ID = (decimal)row[dataColumn];
			// Column "TIPO_CONTENEDOR_ID"
			dataColumn = dataTable.Columns["TIPO_CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_CONTENEDORES"
			dataColumn = dataTable.Columns["CANTIDAD_CONTENEDORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CONTENEDORES = (decimal)row[dataColumn];
			// Column "TOTAL_BRUTO_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_BRUTO_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_BRUTO_PEDIDO = (decimal)row[dataColumn];
			// Column "TOTAL_DTO_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_DTO_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_DTO_PEDIDO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_NETO_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO_PEDIDO = (decimal)row[dataColumn];
			// Column "TOTAL_IMP_PEDIDO"
			dataColumn = dataTable.Columns["TOTAL_IMP_PEDIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_IMP_PEDIDO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PEDIDOS_PROVEEDOR</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PEDIDOS_PROVEEDOR";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("SUCURSAL_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_PEDIDO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AFECTA_LINEA_CREDITO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("NUMERO_CONTRATO", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CASO_FACTURA_PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INVOICE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("FECHA_INVOICE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ESTADO_DOCUMENTACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_EMBARQUE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_CONTENEDORES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_BRUTO_PEDIDO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_DTO_PEDIDO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_NETO_PEDIDO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_IMP_PEDIDO", typeof(decimal));
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

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AFECTA_LINEA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NUMERO_CONTRATO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CASO_FACTURA_PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INVOICE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_INVOICE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ESTADO_DOCUMENTACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_EMBARQUE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_CONTENEDORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_BRUTO_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_DTO_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_IMP_PEDIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PEDIDOS_PROVEEDORCollection_Base class
}  // End of namespace
