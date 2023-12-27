// <fileinfo name="PEDIDOS_CLIENTE_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="PEDIDOS_CLIENTE_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PEDIDOS_CLIENTE_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PEDIDOS_CLIENTE_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PEDIDOS_CLIENTE_IDColumnName = "PEDIDOS_CLIENTE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string VENDEDOR_COMISIONISTA_IDColumnName = "VENDEDOR_COMISIONISTA_ID";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_ORIGENColumnName = "COTIZACION_ORIGEN";
		public const string COTIZACION_MONEDA_LINEA_CREDColumnName = "COTIZACION_MONEDA_LINEA_CRED";
		public const string UNIDAD_DESTINO_IDColumnName = "UNIDAD_DESTINO_ID";
		public const string CANTIDAD_CAJAS_ENTREGADAColumnName = "CANTIDAD_CAJAS_ENTREGADA";
		public const string CANTIDAD_UNITARIA_ENTREGADAColumnName = "CANTIDAD_UNITARIA_ENTREGADA";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string CANTIDAD_CAJAS_PEDIDAColumnName = "CANTIDAD_CAJAS_PEDIDA";
		public const string CANTIDAD_UNITARIA_PEDIDAColumnName = "CANTIDAD_UNITARIA_PEDIDA";
		public const string CANTIDAD_TOTAL_PEDIDAColumnName = "CANTIDAD_TOTAL_PEDIDA";
		public const string CANTIDAD_SUBITEMS_FINALColumnName = "CANTIDAD_SUBITEMS_FINAL";
		public const string PRECIO_LISTA_DESTINOColumnName = "PRECIO_LISTA_DESTINO";
		public const string MONTO_DESCUENTOColumnName = "MONTO_DESCUENTO";
		public const string PORCENTAJE_DTOColumnName = "PORCENTAJE_DTO";
		public const string IMPUESTO_IDColumnName = "IMPUESTO_ID";
		public const string PORCENTAJE_COMISION_VENColumnName = "PORCENTAJE_COMISION_VEN";
		public const string MONTO_COMISION_VENColumnName = "MONTO_COMISION_VEN";
		public const string TOTAL_MONTO_IMPUESTOColumnName = "TOTAL_MONTO_IMPUESTO";
		public const string TOTAL_MONTO_DTOColumnName = "TOTAL_MONTO_DTO";
		public const string TOTAL_MONTO_BRUTOColumnName = "TOTAL_MONTO_BRUTO";
		public const string TOTAL_NETOColumnName = "TOTAL_NETO";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string CANTIDAD_TOTAL_ENTREGADAColumnName = "CANTIDAD_TOTAL_ENTREGADA";
		public const string UNIDAD_ORIGEN_IDColumnName = "UNIDAD_ORIGEN_ID";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string PRECIO_LISTA_ORIGENColumnName = "PRECIO_LISTA_ORIGEN";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIG";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string COSTO_MONTOColumnName = "COSTO_MONTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string COSTO_IDColumnName = "COSTO_ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string ORDEN_DE_PRESENTACIONColumnName = "ORDEN_DE_PRESENTACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string PRECIO_UNITARIO_APROBADOColumnName = "PRECIO_UNITARIO_APROBADO";
		public const string CON_STOCKColumnName = "CON_STOCK";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PEDIDOS_CLIENTE_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PEDIDOS_CLIENTE_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PEDIDOS_CLIENTE_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PEDIDOS_CLIENTE_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public PEDIDOS_CLIENTE_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PEDIDOS_CLIENTE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PEDIDOS_CLIENTE_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PEDIDOS_CLIENTE_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public PEDIDOS_CLIENTE_DETALLERow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByACTIVO_IDAsDataTable(decimal activo_id, bool activo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_cliente_id">The <c>PEDIDOS_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByPEDIDOS_CLIENTE_ID(decimal pedidos_cliente_id)
		{
			return MapRecords(CreateGetByPEDIDOS_CLIENTE_IDCommand(pedidos_cliente_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_cliente_id">The <c>PEDIDOS_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPEDIDOS_CLIENTE_IDAsDataTable(decimal pedidos_cliente_id)
		{
			return MapRecordsToDataTable(CreateGetByPEDIDOS_CLIENTE_IDCommand(pedidos_cliente_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_cliente_id">The <c>PEDIDOS_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPEDIDOS_CLIENTE_IDCommand(decimal pedidos_cliente_id)
		{
			string whereSql = "";
			whereSql += "PEDIDOS_CLIENTE_ID=" + _db.CreateSqlParameterName("PEDIDOS_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PEDIDOS_CLIENTE_ID", pedidos_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_CLI_DET_IMPUESTO</c> foreign key.
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
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public PEDIDOS_CLIENTE_DETALLERow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_IDAsDataTable(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
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
		/// return records by the <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public PEDIDOS_CLIENTE_DETALLERow[] GetByVENDEDOR_COMISIONISTA_ID(decimal vendedor_comisionista_id)
		{
			return GetByVENDEDOR_COMISIONISTA_ID(vendedor_comisionista_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <param name="vendedor_comisionista_idNull">true if the method ignores the vendedor_comisionista_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByVENDEDOR_COMISIONISTA_ID(decimal vendedor_comisionista_id, bool vendedor_comisionista_idNull)
		{
			return MapRecords(CreateGetByVENDEDOR_COMISIONISTA_IDCommand(vendedor_comisionista_id, vendedor_comisionista_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVENDEDOR_COMISIONISTA_IDAsDataTable(decimal vendedor_comisionista_id)
		{
			return GetByVENDEDOR_COMISIONISTA_IDAsDataTable(vendedor_comisionista_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <param name="vendedor_comisionista_idNull">true if the method ignores the vendedor_comisionista_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVENDEDOR_COMISIONISTA_IDAsDataTable(decimal vendedor_comisionista_id, bool vendedor_comisionista_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVENDEDOR_COMISIONISTA_IDCommand(vendedor_comisionista_id, vendedor_comisionista_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <param name="vendedor_comisionista_idNull">true if the method ignores the vendedor_comisionista_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVENDEDOR_COMISIONISTA_IDCommand(decimal vendedor_comisionista_id, bool vendedor_comisionista_idNull)
		{
			string whereSql = "";
			if(vendedor_comisionista_idNull)
				whereSql += "VENDEDOR_COMISIONISTA_ID IS NULL";
			else
				whereSql += "VENDEDOR_COMISIONISTA_ID=" + _db.CreateSqlParameterName("VENDEDOR_COMISIONISTA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!vendedor_comisionista_idNull)
				AddParameter(cmd, "VENDEDOR_COMISIONISTA_ID", vendedor_comisionista_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public PEDIDOS_CLIENTE_DETALLERow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLOTE_IDAsDataTable(decimal lote_id, bool lote_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_PEDIDO_CLI_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual PEDIDOS_CLIENTE_DETALLERow[] GetByUNIDAD_DESTINO_ID(string unidad_destino_id)
		{
			return MapRecords(CreateGetByUNIDAD_DESTINO_IDCommand(unidad_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PEDIDO_CLI_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_DESTINO_IDAsDataTable(string unidad_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_DESTINO_IDCommand(unidad_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PEDIDO_CLI_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_DESTINO_IDCommand(string unidad_destino_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", unidad_destino_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_CLIENTE_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(PEDIDOS_CLIENTE_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PEDIDOS_CLIENTE_DETALLE (" +
				"ID, " +
				"PEDIDOS_CLIENTE_ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"VENDEDOR_COMISIONISTA_ID, " +
				"MONEDA_ORIGEN_ID, " +
				"COTIZACION_ORIGEN, " +
				"COTIZACION_MONEDA_LINEA_CRED, " +
				"UNIDAD_DESTINO_ID, " +
				"CANTIDAD_CAJAS_ENTREGADA, " +
				"CANTIDAD_UNITARIA_ENTREGADA, " +
				"CANTIDAD_POR_CAJA_DESTINO, " +
				"CANTIDAD_CAJAS_PEDIDA, " +
				"CANTIDAD_UNITARIA_PEDIDA, " +
				"CANTIDAD_TOTAL_PEDIDA, " +
				"CANTIDAD_SUBITEMS_FINAL, " +
				"PRECIO_LISTA_DESTINO, " +
				"MONTO_DESCUENTO, " +
				"PORCENTAJE_DTO, " +
				"IMPUESTO_ID, " +
				"PORCENTAJE_COMISION_VEN, " +
				"MONTO_COMISION_VEN, " +
				"TOTAL_MONTO_IMPUESTO, " +
				"TOTAL_MONTO_DTO, " +
				"TOTAL_MONTO_BRUTO, " +
				"TOTAL_NETO, " +
				"PORCENTAJE_IMPUESTO, " +
				"CANTIDAD_TOTAL_ENTREGADA, " +
				"UNIDAD_ORIGEN_ID, " +
				"CANTIDAD_UNIDAD_ORIGEN, " +
				"CANTIDAD_POR_CAJA_ORIGEN, " +
				"PRECIO_LISTA_ORIGEN, " +
				"CANTIDAD_UNITARIA_TOTAL_ORIG, " +
				"FACTOR_CONVERSION, " +
				"COSTO_MONTO, " +
				"COSTO_MONEDA_ID, " +
				"COSTO_MONEDA_COTIZACION, " +
				"COSTO_ID, " +
				"ACTIVO_ID, " +
				"ORDEN_DE_PRESENTACION, " +
				"OBSERVACION, " +
				"TOTAL_RECARGO_FINANCIERO, " +
				"PRECIO_UNITARIO_APROBADO, " +
				"CON_STOCK" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PEDIDOS_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("VENDEDOR_COMISIONISTA_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_ORIGEN") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_LINEA_CRED") + ", " +
				_db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CAJAS_ENTREGADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_ENTREGADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_CAJAS_PEDIDA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_PEDIDA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_TOTAL_PEDIDA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_SUBITEMS_FINAL") + ", " +
				_db.CreateSqlParameterName("PRECIO_LISTA_DESTINO") + ", " +
				_db.CreateSqlParameterName("MONTO_DESCUENTO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_DTO") + ", " +
				_db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_COMISION_VEN") + ", " +
				_db.CreateSqlParameterName("MONTO_COMISION_VEN") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_DTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_MONTO_BRUTO") + ", " +
				_db.CreateSqlParameterName("TOTAL_NETO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_TOTAL_ENTREGADA") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("PRECIO_LISTA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIG") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				_db.CreateSqlParameterName("COSTO_MONTO") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				_db.CreateSqlParameterName("COSTO_ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN_DE_PRESENTACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TOTAL_RECARGO_FINANCIERO") + ", " +
				_db.CreateSqlParameterName("PRECIO_UNITARIO_APROBADO") + ", " +
				_db.CreateSqlParameterName("CON_STOCK") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PEDIDOS_CLIENTE_ID", value.PEDIDOS_CLIENTE_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "VENDEDOR_COMISIONISTA_ID",
				value.IsVENDEDOR_COMISIONISTA_IDNull ? DBNull.Value : (object)value.VENDEDOR_COMISIONISTA_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_ORIGEN",
				value.IsCOTIZACION_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_ORIGEN);
			AddParameter(cmd, "COTIZACION_MONEDA_LINEA_CRED",
				value.IsCOTIZACION_MONEDA_LINEA_CREDNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_LINEA_CRED);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_CAJAS_ENTREGADA", value.CANTIDAD_CAJAS_ENTREGADA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_ENTREGADA", value.CANTIDAD_UNITARIA_ENTREGADA);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_CAJAS_PEDIDA", value.CANTIDAD_CAJAS_PEDIDA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_PEDIDA", value.CANTIDAD_UNITARIA_PEDIDA);
			AddParameter(cmd, "CANTIDAD_TOTAL_PEDIDA", value.CANTIDAD_TOTAL_PEDIDA);
			AddParameter(cmd, "CANTIDAD_SUBITEMS_FINAL",
				value.IsCANTIDAD_SUBITEMS_FINALNull ? DBNull.Value : (object)value.CANTIDAD_SUBITEMS_FINAL);
			AddParameter(cmd, "PRECIO_LISTA_DESTINO", value.PRECIO_LISTA_DESTINO);
			AddParameter(cmd, "MONTO_DESCUENTO", value.MONTO_DESCUENTO);
			AddParameter(cmd, "PORCENTAJE_DTO", value.PORCENTAJE_DTO);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "PORCENTAJE_COMISION_VEN",
				value.IsPORCENTAJE_COMISION_VENNull ? DBNull.Value : (object)value.PORCENTAJE_COMISION_VEN);
			AddParameter(cmd, "MONTO_COMISION_VEN",
				value.IsMONTO_COMISION_VENNull ? DBNull.Value : (object)value.MONTO_COMISION_VEN);
			AddParameter(cmd, "TOTAL_MONTO_IMPUESTO", value.TOTAL_MONTO_IMPUESTO);
			AddParameter(cmd, "TOTAL_MONTO_DTO", value.TOTAL_MONTO_DTO);
			AddParameter(cmd, "TOTAL_MONTO_BRUTO", value.TOTAL_MONTO_BRUTO);
			AddParameter(cmd, "TOTAL_NETO", value.TOTAL_NETO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO",
				value.IsPORCENTAJE_IMPUESTONull ? DBNull.Value : (object)value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "CANTIDAD_TOTAL_ENTREGADA",
				value.IsCANTIDAD_TOTAL_ENTREGADANull ? DBNull.Value : (object)value.CANTIDAD_TOTAL_ENTREGADA);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN",
				value.IsCANTIDAD_UNIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN",
				value.IsCANTIDAD_POR_CAJA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "PRECIO_LISTA_ORIGEN", value.PRECIO_LISTA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIG",
				value.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL_ORIG);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTO_MONTO", value.COSTO_MONTO);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION",
				value.IsCOSTO_MONEDA_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "ORDEN_DE_PRESENTACION", value.ORDEN_DE_PRESENTACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TOTAL_RECARGO_FINANCIERO", value.TOTAL_RECARGO_FINANCIERO);
			AddParameter(cmd, "PRECIO_UNITARIO_APROBADO",
				value.IsPRECIO_UNITARIO_APROBADONull ? DBNull.Value : (object)value.PRECIO_UNITARIO_APROBADO);
			AddParameter(cmd, "CON_STOCK", value.CON_STOCK);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_CLIENTE_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PEDIDOS_CLIENTE_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.PEDIDOS_CLIENTE_DETALLE SET " +
				"PEDIDOS_CLIENTE_ID=" + _db.CreateSqlParameterName("PEDIDOS_CLIENTE_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"VENDEDOR_COMISIONISTA_ID=" + _db.CreateSqlParameterName("VENDEDOR_COMISIONISTA_ID") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"COTIZACION_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_ORIGEN") + ", " +
				"COTIZACION_MONEDA_LINEA_CRED=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_LINEA_CRED") + ", " +
				"UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				"CANTIDAD_CAJAS_ENTREGADA=" + _db.CreateSqlParameterName("CANTIDAD_CAJAS_ENTREGADA") + ", " +
				"CANTIDAD_UNITARIA_ENTREGADA=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_ENTREGADA") + ", " +
				"CANTIDAD_POR_CAJA_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				"CANTIDAD_CAJAS_PEDIDA=" + _db.CreateSqlParameterName("CANTIDAD_CAJAS_PEDIDA") + ", " +
				"CANTIDAD_UNITARIA_PEDIDA=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_PEDIDA") + ", " +
				"CANTIDAD_TOTAL_PEDIDA=" + _db.CreateSqlParameterName("CANTIDAD_TOTAL_PEDIDA") + ", " +
				"CANTIDAD_SUBITEMS_FINAL=" + _db.CreateSqlParameterName("CANTIDAD_SUBITEMS_FINAL") + ", " +
				"PRECIO_LISTA_DESTINO=" + _db.CreateSqlParameterName("PRECIO_LISTA_DESTINO") + ", " +
				"MONTO_DESCUENTO=" + _db.CreateSqlParameterName("MONTO_DESCUENTO") + ", " +
				"PORCENTAJE_DTO=" + _db.CreateSqlParameterName("PORCENTAJE_DTO") + ", " +
				"IMPUESTO_ID=" + _db.CreateSqlParameterName("IMPUESTO_ID") + ", " +
				"PORCENTAJE_COMISION_VEN=" + _db.CreateSqlParameterName("PORCENTAJE_COMISION_VEN") + ", " +
				"MONTO_COMISION_VEN=" + _db.CreateSqlParameterName("MONTO_COMISION_VEN") + ", " +
				"TOTAL_MONTO_IMPUESTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_IMPUESTO") + ", " +
				"TOTAL_MONTO_DTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_DTO") + ", " +
				"TOTAL_MONTO_BRUTO=" + _db.CreateSqlParameterName("TOTAL_MONTO_BRUTO") + ", " +
				"TOTAL_NETO=" + _db.CreateSqlParameterName("TOTAL_NETO") + ", " +
				"PORCENTAJE_IMPUESTO=" + _db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				"CANTIDAD_TOTAL_ENTREGADA=" + _db.CreateSqlParameterName("CANTIDAD_TOTAL_ENTREGADA") + ", " +
				"UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				"CANTIDAD_UNIDAD_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				"CANTIDAD_POR_CAJA_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				"PRECIO_LISTA_ORIGEN=" + _db.CreateSqlParameterName("PRECIO_LISTA_ORIGEN") + ", " +
				"CANTIDAD_UNITARIA_TOTAL_ORIG=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIG") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				"COSTO_MONTO=" + _db.CreateSqlParameterName("COSTO_MONTO") + ", " +
				"COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				"COSTO_MONEDA_COTIZACION=" + _db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				"COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"ORDEN_DE_PRESENTACION=" + _db.CreateSqlParameterName("ORDEN_DE_PRESENTACION") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TOTAL_RECARGO_FINANCIERO=" + _db.CreateSqlParameterName("TOTAL_RECARGO_FINANCIERO") + ", " +
				"PRECIO_UNITARIO_APROBADO=" + _db.CreateSqlParameterName("PRECIO_UNITARIO_APROBADO") + ", " +
				"CON_STOCK=" + _db.CreateSqlParameterName("CON_STOCK") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PEDIDOS_CLIENTE_ID", value.PEDIDOS_CLIENTE_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "VENDEDOR_COMISIONISTA_ID",
				value.IsVENDEDOR_COMISIONISTA_IDNull ? DBNull.Value : (object)value.VENDEDOR_COMISIONISTA_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_ORIGEN",
				value.IsCOTIZACION_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_ORIGEN);
			AddParameter(cmd, "COTIZACION_MONEDA_LINEA_CRED",
				value.IsCOTIZACION_MONEDA_LINEA_CREDNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_LINEA_CRED);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_CAJAS_ENTREGADA", value.CANTIDAD_CAJAS_ENTREGADA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_ENTREGADA", value.CANTIDAD_UNITARIA_ENTREGADA);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_CAJAS_PEDIDA", value.CANTIDAD_CAJAS_PEDIDA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_PEDIDA", value.CANTIDAD_UNITARIA_PEDIDA);
			AddParameter(cmd, "CANTIDAD_TOTAL_PEDIDA", value.CANTIDAD_TOTAL_PEDIDA);
			AddParameter(cmd, "CANTIDAD_SUBITEMS_FINAL",
				value.IsCANTIDAD_SUBITEMS_FINALNull ? DBNull.Value : (object)value.CANTIDAD_SUBITEMS_FINAL);
			AddParameter(cmd, "PRECIO_LISTA_DESTINO", value.PRECIO_LISTA_DESTINO);
			AddParameter(cmd, "MONTO_DESCUENTO", value.MONTO_DESCUENTO);
			AddParameter(cmd, "PORCENTAJE_DTO", value.PORCENTAJE_DTO);
			AddParameter(cmd, "IMPUESTO_ID", value.IMPUESTO_ID);
			AddParameter(cmd, "PORCENTAJE_COMISION_VEN",
				value.IsPORCENTAJE_COMISION_VENNull ? DBNull.Value : (object)value.PORCENTAJE_COMISION_VEN);
			AddParameter(cmd, "MONTO_COMISION_VEN",
				value.IsMONTO_COMISION_VENNull ? DBNull.Value : (object)value.MONTO_COMISION_VEN);
			AddParameter(cmd, "TOTAL_MONTO_IMPUESTO", value.TOTAL_MONTO_IMPUESTO);
			AddParameter(cmd, "TOTAL_MONTO_DTO", value.TOTAL_MONTO_DTO);
			AddParameter(cmd, "TOTAL_MONTO_BRUTO", value.TOTAL_MONTO_BRUTO);
			AddParameter(cmd, "TOTAL_NETO", value.TOTAL_NETO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO",
				value.IsPORCENTAJE_IMPUESTONull ? DBNull.Value : (object)value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "CANTIDAD_TOTAL_ENTREGADA",
				value.IsCANTIDAD_TOTAL_ENTREGADANull ? DBNull.Value : (object)value.CANTIDAD_TOTAL_ENTREGADA);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN",
				value.IsCANTIDAD_UNIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN",
				value.IsCANTIDAD_POR_CAJA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "PRECIO_LISTA_ORIGEN", value.PRECIO_LISTA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIG",
				value.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL_ORIG);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTO_MONTO", value.COSTO_MONTO);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION",
				value.IsCOSTO_MONEDA_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "ORDEN_DE_PRESENTACION", value.ORDEN_DE_PRESENTACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TOTAL_RECARGO_FINANCIERO", value.TOTAL_RECARGO_FINANCIERO);
			AddParameter(cmd, "PRECIO_UNITARIO_APROBADO",
				value.IsPRECIO_UNITARIO_APROBADONull ? DBNull.Value : (object)value.PRECIO_UNITARIO_APROBADO);
			AddParameter(cmd, "CON_STOCK", value.CON_STOCK);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PEDIDOS_CLIENTE_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PEDIDOS_CLIENTE_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PEDIDOS_CLIENTE_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PEDIDOS_CLIENTE_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using
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
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return CreateDeleteByACTIVO_IDCommand(activo_id, activo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_CLI_ACTIVOS</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByACTIVO_IDCommand(decimal activo_id, bool activo_idNull)
		{
			string whereSql = "";
			if(activo_idNull)
				whereSql += "ACTIVO_ID IS NULL";
			else
				whereSql += "ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!activo_idNull)
				AddParameter(cmd, "ACTIVO_ID", activo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id)
		{
			string whereSql = "";
			whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_cliente_id">The <c>PEDIDOS_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPEDIDOS_CLIENTE_ID(decimal pedidos_cliente_id)
		{
			return CreateDeleteByPEDIDOS_CLIENTE_IDCommand(pedidos_cliente_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="pedidos_cliente_id">The <c>PEDIDOS_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPEDIDOS_CLIENTE_IDCommand(decimal pedidos_cliente_id)
		{
			string whereSql = "";
			whereSql += "PEDIDOS_CLIENTE_ID=" + _db.CreateSqlParameterName("PEDIDOS_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PEDIDOS_CLIENTE_ID", pedidos_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_CLI_DET_IMPUESTO</c> foreign key.
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
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return DeleteByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
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
		/// delete records using the <c>FK_PEDIDO_CLI_DET_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_COMISIONISTA_ID(decimal vendedor_comisionista_id)
		{
			return DeleteByVENDEDOR_COMISIONISTA_ID(vendedor_comisionista_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <param name="vendedor_comisionista_idNull">true if the method ignores the vendedor_comisionista_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_COMISIONISTA_ID(decimal vendedor_comisionista_id, bool vendedor_comisionista_idNull)
		{
			return CreateDeleteByVENDEDOR_COMISIONISTA_IDCommand(vendedor_comisionista_id, vendedor_comisionista_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_CLI_DET_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <param name="vendedor_comisionista_idNull">true if the method ignores the vendedor_comisionista_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVENDEDOR_COMISIONISTA_IDCommand(decimal vendedor_comisionista_id, bool vendedor_comisionista_idNull)
		{
			string whereSql = "";
			if(vendedor_comisionista_idNull)
				whereSql += "VENDEDOR_COMISIONISTA_ID IS NULL";
			else
				whereSql += "VENDEDOR_COMISIONISTA_ID=" + _db.CreateSqlParameterName("VENDEDOR_COMISIONISTA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!vendedor_comisionista_idNull)
				AddParameter(cmd, "VENDEDOR_COMISIONISTA_ID", vendedor_comisionista_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return CreateDeleteByLOTE_IDCommand(lote_id, lote_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLOTE_IDCommand(decimal lote_id, bool lote_idNull)
		{
			string whereSql = "";
			if(lote_idNull)
				whereSql += "LOTE_ID IS NULL";
			else
				whereSql += "LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!lote_idNull)
				AddParameter(cmd, "LOTE_ID", lote_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_PEDIDO_CLI_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_DESTINO_ID(string unidad_destino_id)
		{
			return CreateDeleteByUNIDAD_DESTINO_IDCommand(unidad_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PEDIDO_CLI_UNIDAD</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_DESTINO_IDCommand(string unidad_destino_id)
		{
			string whereSql = "";
			whereSql += "UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", unidad_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PEDIDOS_CLIENTE_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>PEDIDOS_CLIENTE_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PEDIDOS_CLIENTE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		protected PEDIDOS_CLIENTE_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		protected PEDIDOS_CLIENTE_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PEDIDOS_CLIENTE_DETALLERow"/> objects.</returns>
		protected virtual PEDIDOS_CLIENTE_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int pedidos_cliente_idColumnIndex = reader.GetOrdinal("PEDIDOS_CLIENTE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int vendedor_comisionista_idColumnIndex = reader.GetOrdinal("VENDEDOR_COMISIONISTA_ID");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_origenColumnIndex = reader.GetOrdinal("COTIZACION_ORIGEN");
			int cotizacion_moneda_linea_credColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_LINEA_CRED");
			int unidad_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_ID");
			int cantidad_cajas_entregadaColumnIndex = reader.GetOrdinal("CANTIDAD_CAJAS_ENTREGADA");
			int cantidad_unitaria_entregadaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_ENTREGADA");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int cantidad_cajas_pedidaColumnIndex = reader.GetOrdinal("CANTIDAD_CAJAS_PEDIDA");
			int cantidad_unitaria_pedidaColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_PEDIDA");
			int cantidad_total_pedidaColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_PEDIDA");
			int cantidad_subitems_finalColumnIndex = reader.GetOrdinal("CANTIDAD_SUBITEMS_FINAL");
			int precio_lista_destinoColumnIndex = reader.GetOrdinal("PRECIO_LISTA_DESTINO");
			int monto_descuentoColumnIndex = reader.GetOrdinal("MONTO_DESCUENTO");
			int porcentaje_dtoColumnIndex = reader.GetOrdinal("PORCENTAJE_DTO");
			int impuesto_idColumnIndex = reader.GetOrdinal("IMPUESTO_ID");
			int porcentaje_comision_venColumnIndex = reader.GetOrdinal("PORCENTAJE_COMISION_VEN");
			int monto_comision_venColumnIndex = reader.GetOrdinal("MONTO_COMISION_VEN");
			int total_monto_impuestoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_IMPUESTO");
			int total_monto_dtoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_DTO");
			int total_monto_brutoColumnIndex = reader.GetOrdinal("TOTAL_MONTO_BRUTO");
			int total_netoColumnIndex = reader.GetOrdinal("TOTAL_NETO");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int cantidad_total_entregadaColumnIndex = reader.GetOrdinal("CANTIDAD_TOTAL_ENTREGADA");
			int unidad_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_ID");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int precio_lista_origenColumnIndex = reader.GetOrdinal("PRECIO_LISTA_ORIGEN");
			int cantidad_unitaria_total_origColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIG");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int costo_montoColumnIndex = reader.GetOrdinal("COSTO_MONTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int costo_idColumnIndex = reader.GetOrdinal("COSTO_ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int orden_de_presentacionColumnIndex = reader.GetOrdinal("ORDEN_DE_PRESENTACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int precio_unitario_aprobadoColumnIndex = reader.GetOrdinal("PRECIO_UNITARIO_APROBADO");
			int con_stockColumnIndex = reader.GetOrdinal("CON_STOCK");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PEDIDOS_CLIENTE_DETALLERow record = new PEDIDOS_CLIENTE_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PEDIDOS_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(pedidos_cliente_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(vendedor_comisionista_idColumnIndex))
						record.VENDEDOR_COMISIONISTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_comisionista_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_origenColumnIndex))
						record.COTIZACION_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_moneda_linea_credColumnIndex))
						record.COTIZACION_MONEDA_LINEA_CRED = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_linea_credColumnIndex)), 9);
					record.UNIDAD_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_destino_idColumnIndex));
					record.CANTIDAD_CAJAS_ENTREGADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cajas_entregadaColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_ENTREGADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_entregadaColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.CANTIDAD_CAJAS_PEDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_cajas_pedidaColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_PEDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_pedidaColumnIndex)), 9);
					record.CANTIDAD_TOTAL_PEDIDA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_pedidaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_subitems_finalColumnIndex))
						record.CANTIDAD_SUBITEMS_FINAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_subitems_finalColumnIndex)), 9);
					record.PRECIO_LISTA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_lista_destinoColumnIndex)), 9);
					record.MONTO_DESCUENTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_descuentoColumnIndex)), 9);
					record.PORCENTAJE_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_dtoColumnIndex)), 9);
					record.IMPUESTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(impuesto_idColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_comision_venColumnIndex))
						record.PORCENTAJE_COMISION_VEN = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_comision_venColumnIndex)), 9);
					if(!reader.IsDBNull(monto_comision_venColumnIndex))
						record.MONTO_COMISION_VEN = Math.Round(Convert.ToDecimal(reader.GetValue(monto_comision_venColumnIndex)), 9);
					record.TOTAL_MONTO_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_impuestoColumnIndex)), 9);
					record.TOTAL_MONTO_DTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_dtoColumnIndex)), 9);
					record.TOTAL_MONTO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(total_monto_brutoColumnIndex)), 9);
					record.TOTAL_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(total_netoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_impuestoColumnIndex))
						record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_total_entregadaColumnIndex))
						record.CANTIDAD_TOTAL_ENTREGADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_total_entregadaColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_origen_idColumnIndex))
						record.UNIDAD_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_origen_idColumnIndex));
					if(!reader.IsDBNull(cantidad_unidad_origenColumnIndex))
						record.CANTIDAD_UNIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_por_caja_origenColumnIndex))
						record.CANTIDAD_POR_CAJA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_origenColumnIndex)), 9);
					record.PRECIO_LISTA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(precio_lista_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_total_origColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL_ORIG = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_origColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					record.COSTO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_idColumnIndex))
						record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_cotizacionColumnIndex))
						record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_idColumnIndex))
						record.COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.ORDEN_DE_PRESENTACION = Math.Round(Convert.ToDecimal(reader.GetValue(orden_de_presentacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					if(!reader.IsDBNull(precio_unitario_aprobadoColumnIndex))
						record.PRECIO_UNITARIO_APROBADO = Math.Round(Convert.ToDecimal(reader.GetValue(precio_unitario_aprobadoColumnIndex)), 9);
					if(!reader.IsDBNull(con_stockColumnIndex))
						record.CON_STOCK = Convert.ToString(reader.GetValue(con_stockColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PEDIDOS_CLIENTE_DETALLERow[])(recordList.ToArray(typeof(PEDIDOS_CLIENTE_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PEDIDOS_CLIENTE_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PEDIDOS_CLIENTE_DETALLERow"/> object.</returns>
		protected virtual PEDIDOS_CLIENTE_DETALLERow MapRow(DataRow row)
		{
			PEDIDOS_CLIENTE_DETALLERow mappedObject = new PEDIDOS_CLIENTE_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PEDIDOS_CLIENTE_ID"
			dataColumn = dataTable.Columns["PEDIDOS_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PEDIDOS_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "VENDEDOR_COMISIONISTA_ID"
			dataColumn = dataTable.Columns["VENDEDOR_COMISIONISTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_COMISIONISTA_ID = (decimal)row[dataColumn];
			// Column "MONEDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["MONEDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONEDA_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_ORIGEN"
			dataColumn = dataTable.Columns["COTIZACION_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_ORIGEN = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA_LINEA_CRED"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA_LINEA_CRED"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA_LINEA_CRED = (decimal)row[dataColumn];
			// Column "UNIDAD_DESTINO_ID"
			dataColumn = dataTable.Columns["UNIDAD_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_DESTINO_ID = (string)row[dataColumn];
			// Column "CANTIDAD_CAJAS_ENTREGADA"
			dataColumn = dataTable.Columns["CANTIDAD_CAJAS_ENTREGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CAJAS_ENTREGADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_ENTREGADA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_ENTREGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_ENTREGADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_CAJAS_PEDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_CAJAS_PEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_CAJAS_PEDIDA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_PEDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_PEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_PEDIDA = (decimal)row[dataColumn];
			// Column "CANTIDAD_TOTAL_PEDIDA"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_PEDIDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_PEDIDA = (decimal)row[dataColumn];
			// Column "CANTIDAD_SUBITEMS_FINAL"
			dataColumn = dataTable.Columns["CANTIDAD_SUBITEMS_FINAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_SUBITEMS_FINAL = (decimal)row[dataColumn];
			// Column "PRECIO_LISTA_DESTINO"
			dataColumn = dataTable.Columns["PRECIO_LISTA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_LISTA_DESTINO = (decimal)row[dataColumn];
			// Column "MONTO_DESCUENTO"
			dataColumn = dataTable.Columns["MONTO_DESCUENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_DESCUENTO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_DTO"
			dataColumn = dataTable.Columns["PORCENTAJE_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_DTO = (decimal)row[dataColumn];
			// Column "IMPUESTO_ID"
			dataColumn = dataTable.Columns["IMPUESTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPUESTO_ID = (decimal)row[dataColumn];
			// Column "PORCENTAJE_COMISION_VEN"
			dataColumn = dataTable.Columns["PORCENTAJE_COMISION_VEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_COMISION_VEN = (decimal)row[dataColumn];
			// Column "MONTO_COMISION_VEN"
			dataColumn = dataTable.Columns["MONTO_COMISION_VEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COMISION_VEN = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_IMPUESTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_IMPUESTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_DTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_DTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_DTO = (decimal)row[dataColumn];
			// Column "TOTAL_MONTO_BRUTO"
			dataColumn = dataTable.Columns["TOTAL_MONTO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_MONTO_BRUTO = (decimal)row[dataColumn];
			// Column "TOTAL_NETO"
			dataColumn = dataTable.Columns["TOTAL_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
			// Column "CANTIDAD_TOTAL_ENTREGADA"
			dataColumn = dataTable.Columns["CANTIDAD_TOTAL_ENTREGADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_TOTAL_ENTREGADA = (decimal)row[dataColumn];
			// Column "UNIDAD_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_ORIGEN_ID = (string)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_ORIGEN"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_ORIGEN = (decimal)row[dataColumn];
			// Column "PRECIO_LISTA_ORIGEN"
			dataColumn = dataTable.Columns["PRECIO_LISTA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_LISTA_ORIGEN = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_ORIG"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_ORIG"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_ORIG = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "COSTO_MONTO"
			dataColumn = dataTable.Columns["COSTO_MONTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONTO = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_COTIZACION"
			dataColumn = dataTable.Columns["COSTO_MONEDA_COTIZACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_COTIZACION = (decimal)row[dataColumn];
			// Column "COSTO_ID"
			dataColumn = dataTable.Columns["COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "ORDEN_DE_PRESENTACION"
			dataColumn = dataTable.Columns["ORDEN_DE_PRESENTACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN_DE_PRESENTACION = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "PRECIO_UNITARIO_APROBADO"
			dataColumn = dataTable.Columns["PRECIO_UNITARIO_APROBADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_UNITARIO_APROBADO = (decimal)row[dataColumn];
			// Column "CON_STOCK"
			dataColumn = dataTable.Columns["CON_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.CON_STOCK = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PEDIDOS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PEDIDOS_CLIENTE_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PEDIDOS_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VENDEDOR_COMISIONISTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_LINEA_CRED", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CAJAS_ENTREGADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_ENTREGADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_CAJAS_PEDIDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_PEDIDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_PEDIDA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_SUBITEMS_FINAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECIO_LISTA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_DESCUENTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("IMPUESTO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_COMISION_VEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_COMISION_VEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_IMPUESTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_DTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_MONTO_BRUTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_TOTAL_ENTREGADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECIO_LISTA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_ORIG", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN_DE_PRESENTACION", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRECIO_UNITARIO_APROBADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CON_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
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

				case "PEDIDOS_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VENDEDOR_COMISIONISTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONEDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA_LINEA_CRED":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_CAJAS_ENTREGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_ENTREGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_CAJAS_PEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_PEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_TOTAL_PEDIDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_SUBITEMS_FINAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_LISTA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_DESCUENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPUESTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_COMISION_VEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COMISION_VEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_DTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_MONTO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_TOTAL_ENTREGADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_UNIDAD_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_LISTA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_ORIG":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_COTIZACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN_DE_PRESENTACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_UNITARIO_APROBADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CON_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PEDIDOS_CLIENTE_DETALLECollection_Base class
}  // End of namespace
