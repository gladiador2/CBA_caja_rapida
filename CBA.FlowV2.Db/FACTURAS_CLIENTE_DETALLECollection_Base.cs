// <fileinfo name="FACTURAS_CLIENTE_DETALLECollection_Base.cs">
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
	/// The base class for <see cref="FACTURAS_CLIENTE_DETALLECollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="FACTURAS_CLIENTE_DETALLECollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FACTURAS_CLIENTE_DETALLECollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FACTURAS_CLIENTE_IDColumnName = "FACTURAS_CLIENTE_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string MONEDA_ORIGEN_IDColumnName = "MONEDA_ORIGEN_ID";
		public const string COTIZACION_ORIGENColumnName = "COTIZACION_ORIGEN";
		public const string COTIZACION_MONEDA_LINEA_CREDColumnName = "COTIZACION_MONEDA_LINEA_CRED";
		public const string UNIDAD_DESTINO_IDColumnName = "UNIDAD_DESTINO_ID";
		public const string CANTIDAD_EMBALADAColumnName = "CANTIDAD_EMBALADA";
		public const string CANTIDAD_UNIDAD_DESTINOColumnName = "CANTIDAD_UNIDAD_DESTINO";
		public const string CANTIDAD_POR_CAJA_DESTINOColumnName = "CANTIDAD_POR_CAJA_DESTINO";
		public const string CANTIDAD_UNITARIA_TOTAL_DESTColumnName = "CANTIDAD_UNITARIA_TOTAL_DEST";
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
		public const string ARTICULO_CODIGOColumnName = "ARTICULO_CODIGO";
		public const string ARTICULO_CODIGO_BARRASColumnName = "ARTICULO_CODIGO_BARRAS";
		public const string ARTICULO_DESCRIPCIONColumnName = "ARTICULO_DESCRIPCION";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string CANTIDAD_DEVUELTA_NOTA_CREDITOColumnName = "CANTIDAD_DEVUELTA_NOTA_CREDITO";
		public const string PORCENTAJE_IMPUESTOColumnName = "PORCENTAJE_IMPUESTO";
		public const string UNIDAD_ORIGEN_IDColumnName = "UNIDAD_ORIGEN_ID";
		public const string CANTIDAD_UNIDAD_ORIGENColumnName = "CANTIDAD_UNIDAD_ORIGEN";
		public const string CANTIDAD_POR_CAJA_ORIGENColumnName = "CANTIDAD_POR_CAJA_ORIGEN";
		public const string CANTIDAD_UNITARIA_TOTAL_ORIGColumnName = "CANTIDAD_UNITARIA_TOTAL_ORIG";
		public const string PRECIO_LISTA_ORIGENColumnName = "PRECIO_LISTA_ORIGEN";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string COSTO_IDColumnName = "COSTO_ID";
		public const string COSTO_MONTOColumnName = "COSTO_MONTO";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COSTO_MONEDA_COTIZACIONColumnName = "COSTO_MONEDA_COTIZACION";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string VENDEDOR_COMISIONISTA_IDColumnName = "VENDEDOR_COMISIONISTA_ID";
		public const string ACTIVO_IDColumnName = "ACTIVO_ID";
		public const string TOTAL_RECARGO_FINANCIEROColumnName = "TOTAL_RECARGO_FINANCIERO";
		public const string CTACTE_RECARGO_IDColumnName = "CTACTE_RECARGO_ID";
		public const string TOTAL_NETO_LUEGO_DE_NCColumnName = "TOTAL_NETO_LUEGO_DE_NC";
		public const string TOTAL_NETO_LUEGO_DE_NC_AUXColumnName = "TOTAL_NETO_LUEGO_DE_NC_AUX";
		public const string CANTIDAD_ANTERIOR_AUXColumnName = "CANTIDAD_ANTERIOR_AUX";
		public const string CASO_ASOCIADO_IDColumnName = "CASO_ASOCIADO_ID";
		public const string DEPOSITO_IDColumnName = "DEPOSITO_ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="FACTURAS_CLIENTE_DETALLECollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public FACTURAS_CLIENTE_DETALLECollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>FACTURAS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>FACTURAS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>FACTURAS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="FACTURAS_CLIENTE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public FACTURAS_CLIENTE_DETALLERow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			FACTURAS_CLIENTE_DETALLERow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects that 
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.FACTURAS_CLIENTE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="FACTURAS_CLIENTE_DETALLERow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="FACTURAS_CLIENTE_DETALLERow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			FACTURAS_CLIENTE_DETALLERow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_IDAsDataTable(lista_precio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
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
		/// return records by the <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByDEPOSITO_ID(decimal deposito_id)
		{
			return GetByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <param name="deposito_idNull">true if the method ignores the deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByDEPOSITO_ID(decimal deposito_id, bool deposito_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_IDCommand(deposito_id, deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_IDAsDataTable(decimal deposito_id)
		{
			return GetByDEPOSITO_IDAsDataTable(deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DEP</c> foreign key.
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
		/// return records by the <c>FK_FACTURAS_CLI_DEP</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DET_ARTICULO</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="facturas_cliente_id">The <c>FACTURAS_CLIENTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByFACTURAS_CLIENTE_ID(decimal facturas_cliente_id)
		{
			return MapRecords(CreateGetByFACTURAS_CLIENTE_IDCommand(facturas_cliente_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="facturas_cliente_id">The <c>FACTURAS_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByFACTURAS_CLIENTE_IDAsDataTable(decimal facturas_cliente_id)
		{
			return MapRecordsToDataTable(CreateGetByFACTURAS_CLIENTE_IDCommand(facturas_cliente_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="facturas_cliente_id">The <c>FACTURAS_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByFACTURAS_CLIENTE_IDCommand(decimal facturas_cliente_id)
		{
			string whereSql = "";
			whereSql += "FACTURAS_CLIENTE_ID=" + _db.CreateSqlParameterName("FACTURAS_CLIENTE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "FACTURAS_CLIENTE_ID", facturas_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecords(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id)
		{
			return GetByCASO_ASOCIADO_IDAsDataTable(caso_asociado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCASO_ASOCIADO_IDAsDataTable(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByCOSTO_ID(decimal costo_id)
		{
			return GetByCOSTO_ID(costo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByCOSTO_ID(decimal costo_id, bool costo_idNull)
		{
			return MapRecords(CreateGetByCOSTO_IDCommand(costo_id, costo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOSTO_IDAsDataTable(decimal costo_id)
		{
			return GetByCOSTO_IDAsDataTable(costo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTO_IDAsDataTable(decimal costo_id, bool costo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOSTO_IDCommand(costo_id, costo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTO_IDCommand(decimal costo_id, bool costo_idNull)
		{
			string whereSql = "";
			if(costo_idNull)
				whereSql += "COSTO_ID IS NULL";
			else
				whereSql += "COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!costo_idNull)
				AddParameter(cmd, "COSTO_ID", costo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByCOSTO_MONEDA_ID(decimal costo_moneda_id)
		{
			return GetByCOSTO_MONEDA_ID(costo_moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <param name="costo_moneda_idNull">true if the method ignores the costo_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByCOSTO_MONEDA_ID(decimal costo_moneda_id, bool costo_moneda_idNull)
		{
			return MapRecords(CreateGetByCOSTO_MONEDA_IDCommand(costo_moneda_id, costo_moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOSTO_MONEDA_IDAsDataTable(decimal costo_moneda_id)
		{
			return GetByCOSTO_MONEDA_IDAsDataTable(costo_moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <param name="costo_moneda_idNull">true if the method ignores the costo_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTO_MONEDA_IDAsDataTable(decimal costo_moneda_id, bool costo_moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOSTO_MONEDA_IDCommand(costo_moneda_id, costo_moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <param name="costo_moneda_idNull">true if the method ignores the costo_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTO_MONEDA_IDCommand(decimal costo_moneda_id, bool costo_moneda_idNull)
		{
			string whereSql = "";
			if(costo_moneda_idNull)
				whereSql += "COSTO_MONEDA_ID IS NULL";
			else
				whereSql += "COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!costo_moneda_idNull)
				AddParameter(cmd, "COSTO_MONEDA_ID", costo_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByIMPUESTO_ID(decimal impuesto_id)
		{
			return MapRecords(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByIMPUESTO_IDAsDataTable(decimal impuesto_id)
		{
			return MapRecordsToDataTable(CreateGetByIMPUESTO_IDCommand(impuesto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_DET_IMPUESTO</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <param name="moneda_origen_idNull">true if the method ignores the moneda_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByMONEDA_ORIGEN_ID(decimal moneda_origen_id, bool moneda_origen_idNull)
		{
			return MapRecords(CreateGetByMONEDA_ORIGEN_IDCommand(moneda_origen_id, moneda_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByMONEDA_ORIGEN_IDAsDataTable(decimal moneda_origen_id)
		{
			return GetByMONEDA_ORIGEN_IDAsDataTable(moneda_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
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
		/// return records by the <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
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
		/// return records by the <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByCTACTE_RECARGO_ID(decimal ctacte_recargo_id)
		{
			return GetByCTACTE_RECARGO_ID(ctacte_recargo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_recargo_idNull">true if the method ignores the ctacte_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByCTACTE_RECARGO_ID(decimal ctacte_recargo_id, bool ctacte_recargo_idNull)
		{
			return MapRecords(CreateGetByCTACTE_RECARGO_IDCommand(ctacte_recargo_id, ctacte_recargo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCTACTE_RECARGO_IDAsDataTable(decimal ctacte_recargo_id)
		{
			return GetByCTACTE_RECARGO_IDAsDataTable(ctacte_recargo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_recargo_idNull">true if the method ignores the ctacte_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCTACTE_RECARGO_IDAsDataTable(decimal ctacte_recargo_id, bool ctacte_recargo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCTACTE_RECARGO_IDCommand(ctacte_recargo_id, ctacte_recargo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_recargo_idNull">true if the method ignores the ctacte_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCTACTE_RECARGO_IDCommand(decimal ctacte_recargo_id, bool ctacte_recargo_idNull)
		{
			string whereSql = "";
			if(ctacte_recargo_idNull)
				whereSql += "CTACTE_RECARGO_ID IS NULL";
			else
				whereSql += "CTACTE_RECARGO_ID=" + _db.CreateSqlParameterName("CTACTE_RECARGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ctacte_recargo_idNull)
				AddParameter(cmd, "CTACTE_RECARGO_ID", ctacte_recargo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByUNIDAD_DESTINO_ID(string unidad_destino_id)
		{
			return MapRecords(CreateGetByUNIDAD_DESTINO_IDCommand(unidad_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_DESTINO_IDAsDataTable(string unidad_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_DESTINO_IDCommand(unidad_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_UNIDAD_DEST</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByUNIDAD_ORIGEN_ID(string unidad_origen_id)
		{
			return MapRecords(CreateGetByUNIDAD_ORIGEN_IDCommand(unidad_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_ORIGEN_IDAsDataTable(string unidad_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_ORIGEN_IDCommand(unidad_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_FACTURAS_CLI_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_ORIGEN_IDCommand(string unidad_origen_id)
		{
			string whereSql = "";
			if(null == unidad_origen_id)
				whereSql += "UNIDAD_ORIGEN_ID IS NULL";
			else
				whereSql += "UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_origen_id)
				AddParameter(cmd, "UNIDAD_ORIGEN_ID", unidad_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByVENDEDOR_COMISIONISTA_ID(decimal vendedor_comisionista_id)
		{
			return GetByVENDEDOR_COMISIONISTA_ID(vendedor_comisionista_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <param name="vendedor_comisionista_idNull">true if the method ignores the vendedor_comisionista_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByVENDEDOR_COMISIONISTA_ID(decimal vendedor_comisionista_id, bool vendedor_comisionista_idNull)
		{
			return MapRecords(CreateGetByVENDEDOR_COMISIONISTA_IDCommand(vendedor_comisionista_id, vendedor_comisionista_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVENDEDOR_COMISIONISTA_IDAsDataTable(decimal vendedor_comisionista_id)
		{
			return GetByVENDEDOR_COMISIONISTA_IDAsDataTable(vendedor_comisionista_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
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
		/// return records by the <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
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
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public FACTURAS_CLIENTE_DETALLERow[] GetByACTIVO_ID(decimal activo_id)
		{
			return GetByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects 
		/// by the <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <param name="activo_idNull">true if the method ignores the activo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		public virtual FACTURAS_CLIENTE_DETALLERow[] GetByACTIVO_ID(decimal activo_id, bool activo_idNull)
		{
			return MapRecords(CreateGetByACTIVO_IDCommand(activo_id, activo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByACTIVO_IDAsDataTable(decimal activo_id)
		{
			return GetByACTIVO_IDAsDataTable(activo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
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
		/// return records by the <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
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
		/// Adds a new record into the <c>FACTURAS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_CLIENTE_DETALLERow"/> object to be inserted.</param>
		public virtual void Insert(FACTURAS_CLIENTE_DETALLERow value)
		{
						
			string sqlStr = "INSERT INTO TRC.FACTURAS_CLIENTE_DETALLE (" +
				"ID, " +
				"FACTURAS_CLIENTE_ID, " +
				"ARTICULO_ID, " +
				"MONEDA_ORIGEN_ID, " +
				"COTIZACION_ORIGEN, " +
				"COTIZACION_MONEDA_LINEA_CRED, " +
				"UNIDAD_DESTINO_ID, " +
				"CANTIDAD_EMBALADA, " +
				"CANTIDAD_UNIDAD_DESTINO, " +
				"CANTIDAD_POR_CAJA_DESTINO, " +
				"CANTIDAD_UNITARIA_TOTAL_DEST, " +
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
				"ARTICULO_CODIGO, " +
				"ARTICULO_CODIGO_BARRAS, " +
				"ARTICULO_DESCRIPCION, " +
				"LOTE_ID, " +
				"CANTIDAD_DEVUELTA_NOTA_CREDITO, " +
				"PORCENTAJE_IMPUESTO, " +
				"UNIDAD_ORIGEN_ID, " +
				"CANTIDAD_UNIDAD_ORIGEN, " +
				"CANTIDAD_POR_CAJA_ORIGEN, " +
				"CANTIDAD_UNITARIA_TOTAL_ORIG, " +
				"PRECIO_LISTA_ORIGEN, " +
				"FACTOR_CONVERSION, " +
				"COSTO_ID, " +
				"COSTO_MONTO, " +
				"COSTO_MONEDA_ID, " +
				"COSTO_MONEDA_COTIZACION, " +
				"OBSERVACION, " +
				"VENDEDOR_COMISIONISTA_ID, " +
				"ACTIVO_ID, " +
				"TOTAL_RECARGO_FINANCIERO, " +
				"CTACTE_RECARGO_ID, " +
				"TOTAL_NETO_LUEGO_DE_NC, " +
				"TOTAL_NETO_LUEGO_DE_NC_AUX, " +
				"CANTIDAD_ANTERIOR_AUX, " +
				"CASO_ASOCIADO_ID, " +
				"DEPOSITO_ID, " +
				"LISTA_PRECIO_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FACTURAS_CLIENTE_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_ORIGEN") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA_LINEA_CRED") + ", " +
				_db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_DEST") + ", " +
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
				_db.CreateSqlParameterName("ARTICULO_CODIGO") + ", " +
				_db.CreateSqlParameterName("ARTICULO_CODIGO_BARRAS") + ", " +
				_db.CreateSqlParameterName("ARTICULO_DESCRIPCION") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEVUELTA_NOTA_CREDITO") + ", " +
				_db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				_db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIG") + ", " +
				_db.CreateSqlParameterName("PRECIO_LISTA_ORIGEN") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				_db.CreateSqlParameterName("COSTO_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_MONTO") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("VENDEDOR_COMISIONISTA_ID") + ", " +
				_db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				_db.CreateSqlParameterName("TOTAL_RECARGO_FINANCIERO") + ", " +
				_db.CreateSqlParameterName("CTACTE_RECARGO_ID") + ", " +
				_db.CreateSqlParameterName("TOTAL_NETO_LUEGO_DE_NC") + ", " +
				_db.CreateSqlParameterName("TOTAL_NETO_LUEGO_DE_NC_AUX") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ANTERIOR_AUX") + ", " +
				_db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIO_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FACTURAS_CLIENTE_ID", value.FACTURAS_CLIENTE_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_ORIGEN",
				value.IsCOTIZACION_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_ORIGEN);
			AddParameter(cmd, "COTIZACION_MONEDA_LINEA_CRED",
				value.IsCOTIZACION_MONEDA_LINEA_CREDNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_LINEA_CRED);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_UNIDAD_DESTINO", value.CANTIDAD_UNIDAD_DESTINO);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_DEST", value.CANTIDAD_UNITARIA_TOTAL_DEST);
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
			AddParameter(cmd, "ARTICULO_CODIGO", value.ARTICULO_CODIGO);
			AddParameter(cmd, "ARTICULO_CODIGO_BARRAS", value.ARTICULO_CODIGO_BARRAS);
			AddParameter(cmd, "ARTICULO_DESCRIPCION", value.ARTICULO_DESCRIPCION);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_DEVUELTA_NOTA_CREDITO", value.CANTIDAD_DEVUELTA_NOTA_CREDITO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO",
				value.IsPORCENTAJE_IMPUESTONull ? DBNull.Value : (object)value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN",
				value.IsCANTIDAD_UNIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN",
				value.IsCANTIDAD_POR_CAJA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIG",
				value.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL_ORIG);
			AddParameter(cmd, "PRECIO_LISTA_ORIGEN", value.PRECIO_LISTA_ORIGEN);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "COSTO_MONTO", value.COSTO_MONTO);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION",
				value.IsCOSTO_MONEDA_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "VENDEDOR_COMISIONISTA_ID",
				value.IsVENDEDOR_COMISIONISTA_IDNull ? DBNull.Value : (object)value.VENDEDOR_COMISIONISTA_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "TOTAL_RECARGO_FINANCIERO", value.TOTAL_RECARGO_FINANCIERO);
			AddParameter(cmd, "CTACTE_RECARGO_ID",
				value.IsCTACTE_RECARGO_IDNull ? DBNull.Value : (object)value.CTACTE_RECARGO_ID);
			AddParameter(cmd, "TOTAL_NETO_LUEGO_DE_NC", value.TOTAL_NETO_LUEGO_DE_NC);
			AddParameter(cmd, "TOTAL_NETO_LUEGO_DE_NC_AUX", value.TOTAL_NETO_LUEGO_DE_NC_AUX);
			AddParameter(cmd, "CANTIDAD_ANTERIOR_AUX", value.CANTIDAD_ANTERIOR_AUX);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>FACTURAS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_CLIENTE_DETALLERow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(FACTURAS_CLIENTE_DETALLERow value)
		{
			
			string sqlStr = "UPDATE TRC.FACTURAS_CLIENTE_DETALLE SET " +
				"FACTURAS_CLIENTE_ID=" + _db.CreateSqlParameterName("FACTURAS_CLIENTE_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"MONEDA_ORIGEN_ID=" + _db.CreateSqlParameterName("MONEDA_ORIGEN_ID") + ", " +
				"COTIZACION_ORIGEN=" + _db.CreateSqlParameterName("COTIZACION_ORIGEN") + ", " +
				"COTIZACION_MONEDA_LINEA_CRED=" + _db.CreateSqlParameterName("COTIZACION_MONEDA_LINEA_CRED") + ", " +
				"UNIDAD_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_DESTINO_ID") + ", " +
				"CANTIDAD_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_EMBALADA") + ", " +
				"CANTIDAD_UNIDAD_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_DESTINO") + ", " +
				"CANTIDAD_POR_CAJA_DESTINO=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_DESTINO") + ", " +
				"CANTIDAD_UNITARIA_TOTAL_DEST=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_DEST") + ", " +
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
				"ARTICULO_CODIGO=" + _db.CreateSqlParameterName("ARTICULO_CODIGO") + ", " +
				"ARTICULO_CODIGO_BARRAS=" + _db.CreateSqlParameterName("ARTICULO_CODIGO_BARRAS") + ", " +
				"ARTICULO_DESCRIPCION=" + _db.CreateSqlParameterName("ARTICULO_DESCRIPCION") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"CANTIDAD_DEVUELTA_NOTA_CREDITO=" + _db.CreateSqlParameterName("CANTIDAD_DEVUELTA_NOTA_CREDITO") + ", " +
				"PORCENTAJE_IMPUESTO=" + _db.CreateSqlParameterName("PORCENTAJE_IMPUESTO") + ", " +
				"UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID") + ", " +
				"CANTIDAD_UNIDAD_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_UNIDAD_ORIGEN") + ", " +
				"CANTIDAD_POR_CAJA_ORIGEN=" + _db.CreateSqlParameterName("CANTIDAD_POR_CAJA_ORIGEN") + ", " +
				"CANTIDAD_UNITARIA_TOTAL_ORIG=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_TOTAL_ORIG") + ", " +
				"PRECIO_LISTA_ORIGEN=" + _db.CreateSqlParameterName("PRECIO_LISTA_ORIGEN") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				"COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID") + ", " +
				"COSTO_MONTO=" + _db.CreateSqlParameterName("COSTO_MONTO") + ", " +
				"COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				"COSTO_MONEDA_COTIZACION=" + _db.CreateSqlParameterName("COSTO_MONEDA_COTIZACION") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"VENDEDOR_COMISIONISTA_ID=" + _db.CreateSqlParameterName("VENDEDOR_COMISIONISTA_ID") + ", " +
				"ACTIVO_ID=" + _db.CreateSqlParameterName("ACTIVO_ID") + ", " +
				"TOTAL_RECARGO_FINANCIERO=" + _db.CreateSqlParameterName("TOTAL_RECARGO_FINANCIERO") + ", " +
				"CTACTE_RECARGO_ID=" + _db.CreateSqlParameterName("CTACTE_RECARGO_ID") + ", " +
				"TOTAL_NETO_LUEGO_DE_NC=" + _db.CreateSqlParameterName("TOTAL_NETO_LUEGO_DE_NC") + ", " +
				"TOTAL_NETO_LUEGO_DE_NC_AUX=" + _db.CreateSqlParameterName("TOTAL_NETO_LUEGO_DE_NC_AUX") + ", " +
				"CANTIDAD_ANTERIOR_AUX=" + _db.CreateSqlParameterName("CANTIDAD_ANTERIOR_AUX") + ", " +
				"CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID") + ", " +
				"DEPOSITO_ID=" + _db.CreateSqlParameterName("DEPOSITO_ID") + ", " +
				"LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FACTURAS_CLIENTE_ID", value.FACTURAS_CLIENTE_ID);
			AddParameter(cmd, "ARTICULO_ID", value.ARTICULO_ID);
			AddParameter(cmd, "MONEDA_ORIGEN_ID",
				value.IsMONEDA_ORIGEN_IDNull ? DBNull.Value : (object)value.MONEDA_ORIGEN_ID);
			AddParameter(cmd, "COTIZACION_ORIGEN",
				value.IsCOTIZACION_ORIGENNull ? DBNull.Value : (object)value.COTIZACION_ORIGEN);
			AddParameter(cmd, "COTIZACION_MONEDA_LINEA_CRED",
				value.IsCOTIZACION_MONEDA_LINEA_CREDNull ? DBNull.Value : (object)value.COTIZACION_MONEDA_LINEA_CRED);
			AddParameter(cmd, "UNIDAD_DESTINO_ID", value.UNIDAD_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_EMBALADA", value.CANTIDAD_EMBALADA);
			AddParameter(cmd, "CANTIDAD_UNIDAD_DESTINO", value.CANTIDAD_UNIDAD_DESTINO);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_DESTINO", value.CANTIDAD_POR_CAJA_DESTINO);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_DEST", value.CANTIDAD_UNITARIA_TOTAL_DEST);
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
			AddParameter(cmd, "ARTICULO_CODIGO", value.ARTICULO_CODIGO);
			AddParameter(cmd, "ARTICULO_CODIGO_BARRAS", value.ARTICULO_CODIGO_BARRAS);
			AddParameter(cmd, "ARTICULO_DESCRIPCION", value.ARTICULO_DESCRIPCION);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "CANTIDAD_DEVUELTA_NOTA_CREDITO", value.CANTIDAD_DEVUELTA_NOTA_CREDITO);
			AddParameter(cmd, "PORCENTAJE_IMPUESTO",
				value.IsPORCENTAJE_IMPUESTONull ? DBNull.Value : (object)value.PORCENTAJE_IMPUESTO);
			AddParameter(cmd, "UNIDAD_ORIGEN_ID", value.UNIDAD_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_UNIDAD_ORIGEN",
				value.IsCANTIDAD_UNIDAD_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_UNIDAD_ORIGEN);
			AddParameter(cmd, "CANTIDAD_POR_CAJA_ORIGEN",
				value.IsCANTIDAD_POR_CAJA_ORIGENNull ? DBNull.Value : (object)value.CANTIDAD_POR_CAJA_ORIGEN);
			AddParameter(cmd, "CANTIDAD_UNITARIA_TOTAL_ORIG",
				value.IsCANTIDAD_UNITARIA_TOTAL_ORIGNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_TOTAL_ORIG);
			AddParameter(cmd, "PRECIO_LISTA_ORIGEN", value.PRECIO_LISTA_ORIGEN);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTO_ID",
				value.IsCOSTO_IDNull ? DBNull.Value : (object)value.COSTO_ID);
			AddParameter(cmd, "COSTO_MONTO", value.COSTO_MONTO);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COSTO_MONEDA_COTIZACION",
				value.IsCOSTO_MONEDA_COTIZACIONNull ? DBNull.Value : (object)value.COSTO_MONEDA_COTIZACION);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "VENDEDOR_COMISIONISTA_ID",
				value.IsVENDEDOR_COMISIONISTA_IDNull ? DBNull.Value : (object)value.VENDEDOR_COMISIONISTA_ID);
			AddParameter(cmd, "ACTIVO_ID",
				value.IsACTIVO_IDNull ? DBNull.Value : (object)value.ACTIVO_ID);
			AddParameter(cmd, "TOTAL_RECARGO_FINANCIERO", value.TOTAL_RECARGO_FINANCIERO);
			AddParameter(cmd, "CTACTE_RECARGO_ID",
				value.IsCTACTE_RECARGO_IDNull ? DBNull.Value : (object)value.CTACTE_RECARGO_ID);
			AddParameter(cmd, "TOTAL_NETO_LUEGO_DE_NC", value.TOTAL_NETO_LUEGO_DE_NC);
			AddParameter(cmd, "TOTAL_NETO_LUEGO_DE_NC_AUX", value.TOTAL_NETO_LUEGO_DE_NC_AUX);
			AddParameter(cmd, "CANTIDAD_ANTERIOR_AUX", value.CANTIDAD_ANTERIOR_AUX);
			AddParameter(cmd, "CASO_ASOCIADO_ID",
				value.IsCASO_ASOCIADO_IDNull ? DBNull.Value : (object)value.CASO_ASOCIADO_ID);
			AddParameter(cmd, "DEPOSITO_ID",
				value.IsDEPOSITO_IDNull ? DBNull.Value : (object)value.DEPOSITO_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>FACTURAS_CLIENTE_DETALLE</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>FACTURAS_CLIENTE_DETALLE</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>FACTURAS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <param name="value">The <see cref="FACTURAS_CLIENTE_DETALLERow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(FACTURAS_CLIENTE_DETALLERow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>FACTURAS_CLIENTE_DETALLE</c> table using
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return DeleteByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
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
		/// delete records using the <c>FK_FACTU_CLI_LIST_PRECIO_ID</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DEP</c> foreign key.
		/// </summary>
		/// <param name="deposito_id">The <c>DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_ID(decimal deposito_id)
		{
			return DeleteByDEPOSITO_ID(deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DEP</c> foreign key.
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
		/// delete records using the <c>FK_FACTURAS_CLI_DEP</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DET_ARTICULO</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="facturas_cliente_id">The <c>FACTURAS_CLIENTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByFACTURAS_CLIENTE_ID(decimal facturas_cliente_id)
		{
			return CreateDeleteByFACTURAS_CLIENTE_IDCommand(facturas_cliente_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DET_CAB</c> foreign key.
		/// </summary>
		/// <param name="facturas_cliente_id">The <c>FACTURAS_CLIENTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByFACTURAS_CLIENTE_IDCommand(decimal facturas_cliente_id)
		{
			string whereSql = "";
			whereSql += "FACTURAS_CLIENTE_ID=" + _db.CreateSqlParameterName("FACTURAS_CLIENTE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "FACTURAS_CLIENTE_ID", facturas_cliente_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id)
		{
			return DeleteByCASO_ASOCIADO_ID(caso_asociado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ASOCIADO_ID(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			return CreateDeleteByCASO_ASOCIADO_IDCommand(caso_asociado_id, caso_asociado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DET_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_asociado_id">The <c>CASO_ASOCIADO_ID</c> column value.</param>
		/// <param name="caso_asociado_idNull">true if the method ignores the caso_asociado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCASO_ASOCIADO_IDCommand(decimal caso_asociado_id, bool caso_asociado_idNull)
		{
			string whereSql = "";
			if(caso_asociado_idNull)
				whereSql += "CASO_ASOCIADO_ID IS NULL";
			else
				whereSql += "CASO_ASOCIADO_ID=" + _db.CreateSqlParameterName("CASO_ASOCIADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!caso_asociado_idNull)
				AddParameter(cmd, "CASO_ASOCIADO_ID", caso_asociado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_ID(decimal costo_id)
		{
			return DeleteByCOSTO_ID(costo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_ID(decimal costo_id, bool costo_idNull)
		{
			return CreateDeleteByCOSTO_IDCommand(costo_id, costo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DET_COSTO</c> foreign key.
		/// </summary>
		/// <param name="costo_id">The <c>COSTO_ID</c> column value.</param>
		/// <param name="costo_idNull">true if the method ignores the costo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTO_IDCommand(decimal costo_id, bool costo_idNull)
		{
			string whereSql = "";
			if(costo_idNull)
				whereSql += "COSTO_ID IS NULL";
			else
				whereSql += "COSTO_ID=" + _db.CreateSqlParameterName("COSTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!costo_idNull)
				AddParameter(cmd, "COSTO_ID", costo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_MONEDA_ID(decimal costo_moneda_id)
		{
			return DeleteByCOSTO_MONEDA_ID(costo_moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <param name="costo_moneda_idNull">true if the method ignores the costo_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTO_MONEDA_ID(decimal costo_moneda_id, bool costo_moneda_idNull)
		{
			return CreateDeleteByCOSTO_MONEDA_IDCommand(costo_moneda_id, costo_moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DET_COSTO_MON</c> foreign key.
		/// </summary>
		/// <param name="costo_moneda_id">The <c>COSTO_MONEDA_ID</c> column value.</param>
		/// <param name="costo_moneda_idNull">true if the method ignores the costo_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTO_MONEDA_IDCommand(decimal costo_moneda_id, bool costo_moneda_idNull)
		{
			string whereSql = "";
			if(costo_moneda_idNull)
				whereSql += "COSTO_MONEDA_ID IS NULL";
			else
				whereSql += "COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!costo_moneda_idNull)
				AddParameter(cmd, "COSTO_MONEDA_ID", costo_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_IMPUESTO</c> foreign key.
		/// </summary>
		/// <param name="impuesto_id">The <c>IMPUESTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByIMPUESTO_ID(decimal impuesto_id)
		{
			return CreateDeleteByIMPUESTO_IDCommand(impuesto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_DET_IMPUESTO</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
		/// </summary>
		/// <param name="moneda_origen_id">The <c>MONEDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByMONEDA_ORIGEN_ID(decimal moneda_origen_id)
		{
			return DeleteByMONEDA_ORIGEN_ID(moneda_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
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
		/// delete records using the <c>FK_FACTURAS_CLI_DET_MONEDA</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
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
		/// delete records using the <c>FK_FACTURAS_CLI_LOTE</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECARGO_ID(decimal ctacte_recargo_id)
		{
			return DeleteByCTACTE_RECARGO_ID(ctacte_recargo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_recargo_idNull">true if the method ignores the ctacte_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCTACTE_RECARGO_ID(decimal ctacte_recargo_id, bool ctacte_recargo_idNull)
		{
			return CreateDeleteByCTACTE_RECARGO_IDCommand(ctacte_recargo_id, ctacte_recargo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_RECARGO</c> foreign key.
		/// </summary>
		/// <param name="ctacte_recargo_id">The <c>CTACTE_RECARGO_ID</c> column value.</param>
		/// <param name="ctacte_recargo_idNull">true if the method ignores the ctacte_recargo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCTACTE_RECARGO_IDCommand(decimal ctacte_recargo_id, bool ctacte_recargo_idNull)
		{
			string whereSql = "";
			if(ctacte_recargo_idNull)
				whereSql += "CTACTE_RECARGO_ID IS NULL";
			else
				whereSql += "CTACTE_RECARGO_ID=" + _db.CreateSqlParameterName("CTACTE_RECARGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ctacte_recargo_idNull)
				AddParameter(cmd, "CTACTE_RECARGO_ID", ctacte_recargo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_UNIDAD_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_destino_id">The <c>UNIDAD_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_DESTINO_ID(string unidad_destino_id)
		{
			return CreateDeleteByUNIDAD_DESTINO_IDCommand(unidad_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_UNIDAD_DEST</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_ORIGEN_ID(string unidad_origen_id)
		{
			return CreateDeleteByUNIDAD_ORIGEN_IDCommand(unidad_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_FACTURAS_CLI_UNIDAD_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_origen_id">The <c>UNIDAD_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_ORIGEN_IDCommand(string unidad_origen_id)
		{
			string whereSql = "";
			if(null == unidad_origen_id)
				whereSql += "UNIDAD_ORIGEN_ID IS NULL";
			else
				whereSql += "UNIDAD_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_origen_id)
				AddParameter(cmd, "UNIDAD_ORIGEN_ID", unidad_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
		/// </summary>
		/// <param name="vendedor_comisionista_id">The <c>VENDEDOR_COMISIONISTA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVENDEDOR_COMISIONISTA_ID(decimal vendedor_comisionista_id)
		{
			return DeleteByVENDEDOR_COMISIONISTA_ID(vendedor_comisionista_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
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
		/// delete records using the <c>FK_FACTURAS_CLI_VEND_COMI</c> foreign key.
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
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
		/// </summary>
		/// <param name="activo_id">The <c>ACTIVO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByACTIVO_ID(decimal activo_id)
		{
			return DeleteByACTIVO_ID(activo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>FACTURAS_CLIENTE_DETALLE</c> table using the 
		/// <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
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
		/// delete records using the <c>FK_FACTURAS_CLIE_DET_ACTIVO</c> foreign key.
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
		/// Deletes <c>FACTURAS_CLIENTE_DETALLE</c> records that match the specified criteria.
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
		/// to delete <c>FACTURAS_CLIENTE_DETALLE</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.FACTURAS_CLIENTE_DETALLE";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>FACTURAS_CLIENTE_DETALLE</c> table.
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		protected FACTURAS_CLIENTE_DETALLERow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		protected FACTURAS_CLIENTE_DETALLERow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="FACTURAS_CLIENTE_DETALLERow"/> objects.</returns>
		protected virtual FACTURAS_CLIENTE_DETALLERow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int facturas_cliente_idColumnIndex = reader.GetOrdinal("FACTURAS_CLIENTE_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int moneda_origen_idColumnIndex = reader.GetOrdinal("MONEDA_ORIGEN_ID");
			int cotizacion_origenColumnIndex = reader.GetOrdinal("COTIZACION_ORIGEN");
			int cotizacion_moneda_linea_credColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA_LINEA_CRED");
			int unidad_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_DESTINO_ID");
			int cantidad_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_EMBALADA");
			int cantidad_unidad_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_DESTINO");
			int cantidad_por_caja_destinoColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_DESTINO");
			int cantidad_unitaria_total_destColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_DEST");
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
			int articulo_codigoColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO");
			int articulo_codigo_barrasColumnIndex = reader.GetOrdinal("ARTICULO_CODIGO_BARRAS");
			int articulo_descripcionColumnIndex = reader.GetOrdinal("ARTICULO_DESCRIPCION");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int cantidad_devuelta_nota_creditoColumnIndex = reader.GetOrdinal("CANTIDAD_DEVUELTA_NOTA_CREDITO");
			int porcentaje_impuestoColumnIndex = reader.GetOrdinal("PORCENTAJE_IMPUESTO");
			int unidad_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_ORIGEN_ID");
			int cantidad_unidad_origenColumnIndex = reader.GetOrdinal("CANTIDAD_UNIDAD_ORIGEN");
			int cantidad_por_caja_origenColumnIndex = reader.GetOrdinal("CANTIDAD_POR_CAJA_ORIGEN");
			int cantidad_unitaria_total_origColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_TOTAL_ORIG");
			int precio_lista_origenColumnIndex = reader.GetOrdinal("PRECIO_LISTA_ORIGEN");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int costo_idColumnIndex = reader.GetOrdinal("COSTO_ID");
			int costo_montoColumnIndex = reader.GetOrdinal("COSTO_MONTO");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int costo_moneda_cotizacionColumnIndex = reader.GetOrdinal("COSTO_MONEDA_COTIZACION");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int vendedor_comisionista_idColumnIndex = reader.GetOrdinal("VENDEDOR_COMISIONISTA_ID");
			int activo_idColumnIndex = reader.GetOrdinal("ACTIVO_ID");
			int total_recargo_financieroColumnIndex = reader.GetOrdinal("TOTAL_RECARGO_FINANCIERO");
			int ctacte_recargo_idColumnIndex = reader.GetOrdinal("CTACTE_RECARGO_ID");
			int total_neto_luego_de_ncColumnIndex = reader.GetOrdinal("TOTAL_NETO_LUEGO_DE_NC");
			int total_neto_luego_de_nc_auxColumnIndex = reader.GetOrdinal("TOTAL_NETO_LUEGO_DE_NC_AUX");
			int cantidad_anterior_auxColumnIndex = reader.GetOrdinal("CANTIDAD_ANTERIOR_AUX");
			int caso_asociado_idColumnIndex = reader.GetOrdinal("CASO_ASOCIADO_ID");
			int deposito_idColumnIndex = reader.GetOrdinal("DEPOSITO_ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					FACTURAS_CLIENTE_DETALLERow record = new FACTURAS_CLIENTE_DETALLERow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.FACTURAS_CLIENTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(facturas_cliente_idColumnIndex)), 9);
					record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(moneda_origen_idColumnIndex))
						record.MONEDA_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(moneda_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_origenColumnIndex))
						record.COTIZACION_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_moneda_linea_credColumnIndex))
						record.COTIZACION_MONEDA_LINEA_CRED = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_moneda_linea_credColumnIndex)), 9);
					record.UNIDAD_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_destino_idColumnIndex));
					record.CANTIDAD_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_embaladaColumnIndex)), 9);
					record.CANTIDAD_UNIDAD_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_destinoColumnIndex)), 9);
					record.CANTIDAD_POR_CAJA_DESTINO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_destinoColumnIndex)), 9);
					record.CANTIDAD_UNITARIA_TOTAL_DEST = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_destColumnIndex)), 9);
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
					if(!reader.IsDBNull(articulo_codigoColumnIndex))
						record.ARTICULO_CODIGO = Convert.ToString(reader.GetValue(articulo_codigoColumnIndex));
					if(!reader.IsDBNull(articulo_codigo_barrasColumnIndex))
						record.ARTICULO_CODIGO_BARRAS = Convert.ToString(reader.GetValue(articulo_codigo_barrasColumnIndex));
					if(!reader.IsDBNull(articulo_descripcionColumnIndex))
						record.ARTICULO_DESCRIPCION = Convert.ToString(reader.GetValue(articulo_descripcionColumnIndex));
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					record.CANTIDAD_DEVUELTA_NOTA_CREDITO = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_devuelta_nota_creditoColumnIndex)), 9);
					if(!reader.IsDBNull(porcentaje_impuestoColumnIndex))
						record.PORCENTAJE_IMPUESTO = Math.Round(Convert.ToDecimal(reader.GetValue(porcentaje_impuestoColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_origen_idColumnIndex))
						record.UNIDAD_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_origen_idColumnIndex));
					if(!reader.IsDBNull(cantidad_unidad_origenColumnIndex))
						record.CANTIDAD_UNIDAD_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unidad_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_por_caja_origenColumnIndex))
						record.CANTIDAD_POR_CAJA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_por_caja_origenColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_total_origColumnIndex))
						record.CANTIDAD_UNITARIA_TOTAL_ORIG = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_total_origColumnIndex)), 9);
					record.PRECIO_LISTA_ORIGEN = Math.Round(Convert.ToDecimal(reader.GetValue(precio_lista_origenColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(costo_idColumnIndex))
						record.COSTO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_idColumnIndex)), 9);
					record.COSTO_MONTO = Math.Round(Convert.ToDecimal(reader.GetValue(costo_montoColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_idColumnIndex))
						record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_cotizacionColumnIndex))
						record.COSTO_MONEDA_COTIZACION = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_cotizacionColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(vendedor_comisionista_idColumnIndex))
						record.VENDEDOR_COMISIONISTA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(vendedor_comisionista_idColumnIndex)), 9);
					if(!reader.IsDBNull(activo_idColumnIndex))
						record.ACTIVO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(activo_idColumnIndex)), 9);
					record.TOTAL_RECARGO_FINANCIERO = Math.Round(Convert.ToDecimal(reader.GetValue(total_recargo_financieroColumnIndex)), 9);
					if(!reader.IsDBNull(ctacte_recargo_idColumnIndex))
						record.CTACTE_RECARGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ctacte_recargo_idColumnIndex)), 9);
					record.TOTAL_NETO_LUEGO_DE_NC = Math.Round(Convert.ToDecimal(reader.GetValue(total_neto_luego_de_ncColumnIndex)), 9);
					record.TOTAL_NETO_LUEGO_DE_NC_AUX = Math.Round(Convert.ToDecimal(reader.GetValue(total_neto_luego_de_nc_auxColumnIndex)), 9);
					record.CANTIDAD_ANTERIOR_AUX = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_anterior_auxColumnIndex)), 9);
					if(!reader.IsDBNull(caso_asociado_idColumnIndex))
						record.CASO_ASOCIADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_asociado_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_idColumnIndex))
						record.DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (FACTURAS_CLIENTE_DETALLERow[])(recordList.ToArray(typeof(FACTURAS_CLIENTE_DETALLERow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="FACTURAS_CLIENTE_DETALLERow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="FACTURAS_CLIENTE_DETALLERow"/> object.</returns>
		protected virtual FACTURAS_CLIENTE_DETALLERow MapRow(DataRow row)
		{
			FACTURAS_CLIENTE_DETALLERow mappedObject = new FACTURAS_CLIENTE_DETALLERow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FACTURAS_CLIENTE_ID"
			dataColumn = dataTable.Columns["FACTURAS_CLIENTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURAS_CLIENTE_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
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
			// Column "CANTIDAD_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNIDAD_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_UNIDAD_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNIDAD_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_POR_CAJA_DESTINO"
			dataColumn = dataTable.Columns["CANTIDAD_POR_CAJA_DESTINO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_POR_CAJA_DESTINO = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_TOTAL_DEST"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_DEST"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_DEST = (decimal)row[dataColumn];
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
			// Column "ARTICULO_CODIGO"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO = (string)row[dataColumn];
			// Column "ARTICULO_CODIGO_BARRAS"
			dataColumn = dataTable.Columns["ARTICULO_CODIGO_BARRAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_CODIGO_BARRAS = (string)row[dataColumn];
			// Column "ARTICULO_DESCRIPCION"
			dataColumn = dataTable.Columns["ARTICULO_DESCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_DESCRIPCION = (string)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD_DEVUELTA_NOTA_CREDITO"
			dataColumn = dataTable.Columns["CANTIDAD_DEVUELTA_NOTA_CREDITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEVUELTA_NOTA_CREDITO = (decimal)row[dataColumn];
			// Column "PORCENTAJE_IMPUESTO"
			dataColumn = dataTable.Columns["PORCENTAJE_IMPUESTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PORCENTAJE_IMPUESTO = (decimal)row[dataColumn];
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
			// Column "CANTIDAD_UNITARIA_TOTAL_ORIG"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_TOTAL_ORIG"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_TOTAL_ORIG = (decimal)row[dataColumn];
			// Column "PRECIO_LISTA_ORIGEN"
			dataColumn = dataTable.Columns["PRECIO_LISTA_ORIGEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECIO_LISTA_ORIGEN = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "COSTO_ID"
			dataColumn = dataTable.Columns["COSTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_ID = (decimal)row[dataColumn];
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
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "VENDEDOR_COMISIONISTA_ID"
			dataColumn = dataTable.Columns["VENDEDOR_COMISIONISTA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENDEDOR_COMISIONISTA_ID = (decimal)row[dataColumn];
			// Column "ACTIVO_ID"
			dataColumn = dataTable.Columns["ACTIVO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ACTIVO_ID = (decimal)row[dataColumn];
			// Column "TOTAL_RECARGO_FINANCIERO"
			dataColumn = dataTable.Columns["TOTAL_RECARGO_FINANCIERO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_RECARGO_FINANCIERO = (decimal)row[dataColumn];
			// Column "CTACTE_RECARGO_ID"
			dataColumn = dataTable.Columns["CTACTE_RECARGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CTACTE_RECARGO_ID = (decimal)row[dataColumn];
			// Column "TOTAL_NETO_LUEGO_DE_NC"
			dataColumn = dataTable.Columns["TOTAL_NETO_LUEGO_DE_NC"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO_LUEGO_DE_NC = (decimal)row[dataColumn];
			// Column "TOTAL_NETO_LUEGO_DE_NC_AUX"
			dataColumn = dataTable.Columns["TOTAL_NETO_LUEGO_DE_NC_AUX"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_NETO_LUEGO_DE_NC_AUX = (decimal)row[dataColumn];
			// Column "CANTIDAD_ANTERIOR_AUX"
			dataColumn = dataTable.Columns["CANTIDAD_ANTERIOR_AUX"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ANTERIOR_AUX = (decimal)row[dataColumn];
			// Column "CASO_ASOCIADO_ID"
			dataColumn = dataTable.Columns["CASO_ASOCIADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ASOCIADO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>FACTURAS_CLIENTE_DETALLE</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "FACTURAS_CLIENTE_DETALLE";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTURAS_CLIENTE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONEDA_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA_LINEA_CRED", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_EMBALADA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_DESTINO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_DEST", typeof(decimal));
			dataColumn.AllowDBNull = false;
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
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("ARTICULO_CODIGO_BARRAS", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("ARTICULO_DESCRIPCION", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEVUELTA_NOTA_CREDITO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PORCENTAJE_IMPUESTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNIDAD_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_POR_CAJA_ORIGEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_TOTAL_ORIG", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECIO_LISTA_ORIGEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONTO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_COTIZACION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("VENDEDOR_COMISIONISTA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ACTIVO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_RECARGO_FINANCIERO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CTACTE_RECARGO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_NETO_LUEGO_DE_NC", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOTAL_NETO_LUEGO_DE_NC_AUX", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ANTERIOR_AUX", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CASO_ASOCIADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
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

				case "FACTURAS_CLIENTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
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

				case "CANTIDAD_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNIDAD_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_POR_CAJA_DESTINO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_TOTAL_DEST":
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

				case "ARTICULO_CODIGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_CODIGO_BARRAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ARTICULO_DESCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DEVUELTA_NOTA_CREDITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PORCENTAJE_IMPUESTO":
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

				case "CANTIDAD_UNITARIA_TOTAL_ORIG":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECIO_LISTA_ORIGEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_ID":
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

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENDEDOR_COMISIONISTA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ACTIVO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_RECARGO_FINANCIERO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CTACTE_RECARGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO_LUEGO_DE_NC":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_NETO_LUEGO_DE_NC_AUX":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ANTERIOR_AUX":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ASOCIADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of FACTURAS_CLIENTE_DETALLECollection_Base class
}  // End of namespace
