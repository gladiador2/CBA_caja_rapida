// <fileinfo name="STOCK_TRANSFERENCIA_BALANC_DETCollection_Base.cs">
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
	/// The base class for <see cref="STOCK_TRANSFERENCIA_BALANC_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="STOCK_TRANSFERENCIA_BALANC_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class STOCK_TRANSFERENCIA_BALANC_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TRANSFERENCIA_BALANC_IDColumnName = "TRANSFERENCIA_BALANC_ID";
		public const string ARTICULO_IDColumnName = "ARTICULO_ID";
		public const string LOTE_IDColumnName = "LOTE_ID";
		public const string UNIDAD_MEDIDA_DESTINO_IDColumnName = "UNIDAD_MEDIDA_DESTINO_ID";
		public const string CANTIDAD_DEST_UNITARIAColumnName = "CANTIDAD_DEST_UNITARIA";
		public const string CANTIDAD_DEST_EMBALADAColumnName = "CANTIDAD_DEST_EMBALADA";
		public const string CANTIDAD_DEST_CAJAColumnName = "CANTIDAD_DEST_CAJA";
		public const string COSTO_MONEDA_IDColumnName = "COSTO_MONEDA_ID";
		public const string COTIZACION_MONEDAColumnName = "COTIZACION_MONEDA";
		public const string MONTO_COSTOColumnName = "MONTO_COSTO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string CANTIDAD_UNITARIA_DEST_TOTALColumnName = "CANTIDAD_UNITARIA_DEST_TOTAL";
		public const string UNIDAD_MEDIDA_ORIGEN_IDColumnName = "UNIDAD_MEDIDA_ORIGEN_ID";
		public const string CANTIDAD_ORIG_UNITARIAColumnName = "CANTIDAD_ORIG_UNITARIA";
		public const string CANTIDAD_ORIG_EMBALADAColumnName = "CANTIDAD_ORIG_EMBALADA";
		public const string CANTIDAD_ORIG_CAJAColumnName = "CANTIDAD_ORIG_CAJA";
		public const string CANTIDAD_UNITARIA_ORIG_TOTALColumnName = "CANTIDAD_UNITARIA_ORIG_TOTAL";
		public const string FACTOR_CONVERSIONColumnName = "FACTOR_CONVERSION";
		public const string COSTOS_IDColumnName = "COSTOS_ID";
		public const string PROVEEDOR_IDColumnName = "PROVEEDOR_ID";
		public const string SUCURSAL_DESTINO_IDColumnName = "SUCURSAL_DESTINO_ID";
		public const string DEPOSITO_DESTINO_IDColumnName = "DEPOSITO_DESTINO_ID";
		public const string CASO_IDColumnName = "CASO_ID";
		public const string RECIBIDOColumnName = "RECIBIDO";
		public const string TAR_BRUTOColumnName = "TAR_BRUTO";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string TAR_PESO_NETOColumnName = "TAR_PESO_NETO";
		public const string AUTONUMERACION_IDColumnName = "AUTONUMERACION_ID";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string GENERAR_STOCKColumnName = "GENERAR_STOCK";
		public const string NRO_CELDAColumnName = "NRO_CELDA";
		public const string DEPOSITO_ORIGEN_IDColumnName = "DEPOSITO_ORIGEN_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="STOCK_TRANSFERENCIA_BALANC_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public STOCK_TRANSFERENCIA_BALANC_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			STOCK_TRANSFERENCIA_BALANC_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.STOCK_TRANSFERENCIA_BALANC_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			STOCK_TRANSFERENCIA_BALANC_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByCASO_ID(decimal caso_id)
		{
			return GetByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <param name="caso_idNull">true if the method ignores the caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByCASO_ID(decimal caso_id, bool caso_idNull)
		{
			return MapRecords(CreateGetByCASO_IDCommand(caso_id, caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCASO_IDAsDataTable(decimal caso_id)
		{
			return GetByCASO_IDAsDataTable(caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
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
		/// return records by the <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByDEPOSITO_DESTINO_ID(decimal deposito_destino_id)
		{
			return GetByDEPOSITO_DESTINO_ID(deposito_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByDEPOSITO_DESTINO_ID(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			return MapRecords(CreateGetByDEPOSITO_DESTINO_IDCommand(deposito_destino_id, deposito_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDEPOSITO_DESTINO_IDAsDataTable(decimal deposito_destino_id)
		{
			return GetByDEPOSITO_DESTINO_IDAsDataTable(deposito_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDEPOSITO_DESTINO_IDAsDataTable(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDEPOSITO_DESTINO_IDCommand(deposito_destino_id, deposito_destino_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDEPOSITO_DESTINO_IDCommand(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			string whereSql = "";
			if(deposito_destino_idNull)
				whereSql += "DEPOSITO_DESTINO_ID IS NULL";
			else
				whereSql += "DEPOSITO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPOSITO_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!deposito_destino_idNull)
				AddParameter(cmd, "DEPOSITO_DESTINO_ID", deposito_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByARTICULO_ID(decimal articulo_id)
		{
			return GetByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecords(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id)
		{
			return GetByARTICULO_IDAsDataTable(articulo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_IDAsDataTable(decimal articulo_id, bool articulo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_IDCommand(articulo_id, articulo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByCOSTOS_ID(decimal costos_id)
		{
			return GetByCOSTOS_ID(costos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByCOSTOS_ID(decimal costos_id, bool costos_idNull)
		{
			return MapRecords(CreateGetByCOSTOS_IDCommand(costos_id, costos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCOSTOS_IDAsDataTable(decimal costos_id)
		{
			return GetByCOSTOS_IDAsDataTable(costos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCOSTOS_IDAsDataTable(decimal costos_id, bool costos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCOSTOS_IDCommand(costos_id, costos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCOSTOS_IDCommand(decimal costos_id, bool costos_idNull)
		{
			string whereSql = "";
			if(costos_idNull)
				whereSql += "COSTOS_ID IS NULL";
			else
				whereSql += "COSTOS_ID=" + _db.CreateSqlParameterName("COSTOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!costos_idNull)
				AddParameter(cmd, "COSTOS_ID", costos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByLOTE_ID(decimal lote_id)
		{
			return GetByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <param name="lote_idNull">true if the method ignores the lote_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByLOTE_ID(decimal lote_id, bool lote_idNull)
		{
			return MapRecords(CreateGetByLOTE_IDCommand(lote_id, lote_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLOTE_IDAsDataTable(decimal lote_id)
		{
			return GetByLOTE_IDAsDataTable(lote_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
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
		/// return records by the <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByPROVEEDOR_ID(decimal proveedor_id)
		{
			return GetByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <param name="proveedor_idNull">true if the method ignores the proveedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByPROVEEDOR_ID(decimal proveedor_id, bool proveedor_idNull)
		{
			return MapRecords(CreateGetByPROVEEDOR_IDCommand(proveedor_id, proveedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPROVEEDOR_IDAsDataTable(decimal proveedor_id)
		{
			return GetByPROVEEDOR_IDAsDataTable(proveedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
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
		/// return records by the <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
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
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByTRANSFERENCIA_BALANC_ID(decimal transferencia_balanc_id)
		{
			return GetByTRANSFERENCIA_BALANC_ID(transferencia_balanc_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <param name="transferencia_balanc_idNull">true if the method ignores the transferencia_balanc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByTRANSFERENCIA_BALANC_ID(decimal transferencia_balanc_id, bool transferencia_balanc_idNull)
		{
			return MapRecords(CreateGetByTRANSFERENCIA_BALANC_IDCommand(transferencia_balanc_id, transferencia_balanc_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSFERENCIA_BALANC_IDAsDataTable(decimal transferencia_balanc_id)
		{
			return GetByTRANSFERENCIA_BALANC_IDAsDataTable(transferencia_balanc_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <param name="transferencia_balanc_idNull">true if the method ignores the transferencia_balanc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSFERENCIA_BALANC_IDAsDataTable(decimal transferencia_balanc_id, bool transferencia_balanc_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSFERENCIA_BALANC_IDCommand(transferencia_balanc_id, transferencia_balanc_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <param name="transferencia_balanc_idNull">true if the method ignores the transferencia_balanc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSFERENCIA_BALANC_IDCommand(decimal transferencia_balanc_id, bool transferencia_balanc_idNull)
		{
			string whereSql = "";
			if(transferencia_balanc_idNull)
				whereSql += "TRANSFERENCIA_BALANC_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BALANC_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BALANC_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transferencia_balanc_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BALANC_ID", transferencia_balanc_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByUNIDAD_MEDIDA_DESTINO_ID(string unidad_medida_destino_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_DESTINO_IDAsDataTable(string unidad_medida_destino_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STK_TRANF_BALAN_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_DESTINO_IDCommand(string unidad_medida_destino_id)
		{
			string whereSql = "";
			if(null == unidad_medida_destino_id)
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_medida_destino_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", unidad_medida_destino_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetByUNIDAD_MEDIDA_ORIGEN_ID(string unidad_medida_origen_id)
		{
			return MapRecords(CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUNIDAD_MEDIDA_ORIGEN_IDAsDataTable(string unidad_medida_origen_id)
		{
			return MapRecordsToDataTable(CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_STK_TRANF_BALAN_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUNIDAD_MEDIDA_ORIGEN_IDCommand(string unidad_medida_origen_id)
		{
			string whereSql = "";
			if(null == unidad_medida_origen_id)
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != unidad_medida_origen_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", unidad_medida_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public STOCK_TRANSFERENCIA_BALANC_DETRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects 
		/// by the <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <param name="sucursal_destino_idNull">true if the method ignores the sucursal_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		public virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] GetBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id, bool sucursal_destino_idNull)
		{
			return MapRecords(CreateGetBySUCURSAL_DESTINO_IDCommand(sucursal_destino_id, sucursal_destino_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetBySUCURSAL_DESTINO_IDAsDataTable(decimal sucursal_destino_id)
		{
			return GetBySUCURSAL_DESTINO_IDAsDataTable(sucursal_destino_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
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
		/// return records by the <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
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
		/// Adds a new record into the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> object to be inserted.</param>
		public virtual void Insert(STOCK_TRANSFERENCIA_BALANC_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.STOCK_TRANSFERENCIA_BALANC_DET (" +
				"ID, " +
				"TRANSFERENCIA_BALANC_ID, " +
				"ARTICULO_ID, " +
				"LOTE_ID, " +
				"UNIDAD_MEDIDA_DESTINO_ID, " +
				"CANTIDAD_DEST_UNITARIA, " +
				"CANTIDAD_DEST_EMBALADA, " +
				"CANTIDAD_DEST_CAJA, " +
				"COSTO_MONEDA_ID, " +
				"COTIZACION_MONEDA, " +
				"MONTO_COSTO, " +
				"OBSERVACION, " +
				"CANTIDAD_UNITARIA_DEST_TOTAL, " +
				"UNIDAD_MEDIDA_ORIGEN_ID, " +
				"CANTIDAD_ORIG_UNITARIA, " +
				"CANTIDAD_ORIG_EMBALADA, " +
				"CANTIDAD_ORIG_CAJA, " +
				"CANTIDAD_UNITARIA_ORIG_TOTAL, " +
				"FACTOR_CONVERSION, " +
				"COSTOS_ID, " +
				"PROVEEDOR_ID, " +
				"SUCURSAL_DESTINO_ID, " +
				"DEPOSITO_DESTINO_ID, " +
				"CASO_ID, " +
				"RECIBIDO, " +
				"TAR_BRUTO, " +
				"PESO_BRUTO, " +
				"TAR_PESO_NETO, " +
				"AUTONUMERACION_ID, " +
				"NRO_COMPROBANTE, " +
				"GENERAR_STOCK, " +
				"NRO_CELDA, " +
				"DEPOSITO_ORIGEN_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TRANSFERENCIA_BALANC_ID") + ", " +
				_db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				_db.CreateSqlParameterName("LOTE_ID") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEST_UNITARIA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEST_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_DEST_CAJA") + ", " +
				_db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				_db.CreateSqlParameterName("MONTO_COSTO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_DEST_TOTAL") + ", " +
				_db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIG_UNITARIA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIG_EMBALADA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_ORIG_CAJA") + ", " +
				_db.CreateSqlParameterName("CANTIDAD_UNITARIA_ORIG_TOTAL") + ", " +
				_db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				_db.CreateSqlParameterName("COSTOS_ID") + ", " +
				_db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				_db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_DESTINO_ID") + ", " +
				_db.CreateSqlParameterName("CASO_ID") + ", " +
				_db.CreateSqlParameterName("RECIBIDO") + ", " +
				_db.CreateSqlParameterName("TAR_BRUTO") + ", " +
				_db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				_db.CreateSqlParameterName("TAR_PESO_NETO") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("GENERAR_STOCK") + ", " +
				_db.CreateSqlParameterName("NRO_CELDA") + ", " +
				_db.CreateSqlParameterName("DEPOSITO_ORIGEN_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TRANSFERENCIA_BALANC_ID",
				value.IsTRANSFERENCIA_BALANC_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BALANC_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", value.UNIDAD_MEDIDA_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_DEST_UNITARIA",
				value.IsCANTIDAD_DEST_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_DEST_UNITARIA);
			AddParameter(cmd, "CANTIDAD_DEST_EMBALADA",
				value.IsCANTIDAD_DEST_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_DEST_EMBALADA);
			AddParameter(cmd, "CANTIDAD_DEST_CAJA",
				value.IsCANTIDAD_DEST_CAJANull ? DBNull.Value : (object)value.CANTIDAD_DEST_CAJA);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_COSTO",
				value.IsMONTO_COSTONull ? DBNull.Value : (object)value.MONTO_COSTO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CANTIDAD_UNITARIA_DEST_TOTAL",
				value.IsCANTIDAD_UNITARIA_DEST_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_DEST_TOTAL);
			AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", value.UNIDAD_MEDIDA_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_ORIG_UNITARIA",
				value.IsCANTIDAD_ORIG_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_UNITARIA);
			AddParameter(cmd, "CANTIDAD_ORIG_EMBALADA",
				value.IsCANTIDAD_ORIG_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_EMBALADA);
			AddParameter(cmd, "CANTIDAD_ORIG_CAJA",
				value.IsCANTIDAD_ORIG_CAJANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_ORIG_TOTAL",
				value.IsCANTIDAD_UNITARIA_ORIG_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_ORIG_TOTAL);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTOS_ID",
				value.IsCOSTOS_IDNull ? DBNull.Value : (object)value.COSTOS_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "DEPOSITO_DESTINO_ID",
				value.IsDEPOSITO_DESTINO_IDNull ? DBNull.Value : (object)value.DEPOSITO_DESTINO_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "RECIBIDO", value.RECIBIDO);
			AddParameter(cmd, "TAR_BRUTO",
				value.IsTAR_BRUTONull ? DBNull.Value : (object)value.TAR_BRUTO);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "TAR_PESO_NETO",
				value.IsTAR_PESO_NETONull ? DBNull.Value : (object)value.TAR_PESO_NETO);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "GENERAR_STOCK", value.GENERAR_STOCK);
			AddParameter(cmd, "NRO_CELDA",
				value.IsNRO_CELDANull ? DBNull.Value : (object)value.NRO_CELDA);
			AddParameter(cmd, "DEPOSITO_ORIGEN_ID",
				value.IsDEPOSITO_ORIGEN_IDNull ? DBNull.Value : (object)value.DEPOSITO_ORIGEN_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(STOCK_TRANSFERENCIA_BALANC_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.STOCK_TRANSFERENCIA_BALANC_DET SET " +
				"TRANSFERENCIA_BALANC_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BALANC_ID") + ", " +
				"ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID") + ", " +
				"LOTE_ID=" + _db.CreateSqlParameterName("LOTE_ID") + ", " +
				"UNIDAD_MEDIDA_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID") + ", " +
				"CANTIDAD_DEST_UNITARIA=" + _db.CreateSqlParameterName("CANTIDAD_DEST_UNITARIA") + ", " +
				"CANTIDAD_DEST_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_DEST_EMBALADA") + ", " +
				"CANTIDAD_DEST_CAJA=" + _db.CreateSqlParameterName("CANTIDAD_DEST_CAJA") + ", " +
				"COSTO_MONEDA_ID=" + _db.CreateSqlParameterName("COSTO_MONEDA_ID") + ", " +
				"COTIZACION_MONEDA=" + _db.CreateSqlParameterName("COTIZACION_MONEDA") + ", " +
				"MONTO_COSTO=" + _db.CreateSqlParameterName("MONTO_COSTO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"CANTIDAD_UNITARIA_DEST_TOTAL=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_DEST_TOTAL") + ", " +
				"UNIDAD_MEDIDA_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID") + ", " +
				"CANTIDAD_ORIG_UNITARIA=" + _db.CreateSqlParameterName("CANTIDAD_ORIG_UNITARIA") + ", " +
				"CANTIDAD_ORIG_EMBALADA=" + _db.CreateSqlParameterName("CANTIDAD_ORIG_EMBALADA") + ", " +
				"CANTIDAD_ORIG_CAJA=" + _db.CreateSqlParameterName("CANTIDAD_ORIG_CAJA") + ", " +
				"CANTIDAD_UNITARIA_ORIG_TOTAL=" + _db.CreateSqlParameterName("CANTIDAD_UNITARIA_ORIG_TOTAL") + ", " +
				"FACTOR_CONVERSION=" + _db.CreateSqlParameterName("FACTOR_CONVERSION") + ", " +
				"COSTOS_ID=" + _db.CreateSqlParameterName("COSTOS_ID") + ", " +
				"PROVEEDOR_ID=" + _db.CreateSqlParameterName("PROVEEDOR_ID") + ", " +
				"SUCURSAL_DESTINO_ID=" + _db.CreateSqlParameterName("SUCURSAL_DESTINO_ID") + ", " +
				"DEPOSITO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPOSITO_DESTINO_ID") + ", " +
				"CASO_ID=" + _db.CreateSqlParameterName("CASO_ID") + ", " +
				"RECIBIDO=" + _db.CreateSqlParameterName("RECIBIDO") + ", " +
				"TAR_BRUTO=" + _db.CreateSqlParameterName("TAR_BRUTO") + ", " +
				"PESO_BRUTO=" + _db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				"TAR_PESO_NETO=" + _db.CreateSqlParameterName("TAR_PESO_NETO") + ", " +
				"AUTONUMERACION_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_ID") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"GENERAR_STOCK=" + _db.CreateSqlParameterName("GENERAR_STOCK") + ", " +
				"NRO_CELDA=" + _db.CreateSqlParameterName("NRO_CELDA") + ", " +
				"DEPOSITO_ORIGEN_ID=" + _db.CreateSqlParameterName("DEPOSITO_ORIGEN_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TRANSFERENCIA_BALANC_ID",
				value.IsTRANSFERENCIA_BALANC_IDNull ? DBNull.Value : (object)value.TRANSFERENCIA_BALANC_ID);
			AddParameter(cmd, "ARTICULO_ID",
				value.IsARTICULO_IDNull ? DBNull.Value : (object)value.ARTICULO_ID);
			AddParameter(cmd, "LOTE_ID",
				value.IsLOTE_IDNull ? DBNull.Value : (object)value.LOTE_ID);
			AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", value.UNIDAD_MEDIDA_DESTINO_ID);
			AddParameter(cmd, "CANTIDAD_DEST_UNITARIA",
				value.IsCANTIDAD_DEST_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_DEST_UNITARIA);
			AddParameter(cmd, "CANTIDAD_DEST_EMBALADA",
				value.IsCANTIDAD_DEST_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_DEST_EMBALADA);
			AddParameter(cmd, "CANTIDAD_DEST_CAJA",
				value.IsCANTIDAD_DEST_CAJANull ? DBNull.Value : (object)value.CANTIDAD_DEST_CAJA);
			AddParameter(cmd, "COSTO_MONEDA_ID",
				value.IsCOSTO_MONEDA_IDNull ? DBNull.Value : (object)value.COSTO_MONEDA_ID);
			AddParameter(cmd, "COTIZACION_MONEDA",
				value.IsCOTIZACION_MONEDANull ? DBNull.Value : (object)value.COTIZACION_MONEDA);
			AddParameter(cmd, "MONTO_COSTO",
				value.IsMONTO_COSTONull ? DBNull.Value : (object)value.MONTO_COSTO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "CANTIDAD_UNITARIA_DEST_TOTAL",
				value.IsCANTIDAD_UNITARIA_DEST_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_DEST_TOTAL);
			AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", value.UNIDAD_MEDIDA_ORIGEN_ID);
			AddParameter(cmd, "CANTIDAD_ORIG_UNITARIA",
				value.IsCANTIDAD_ORIG_UNITARIANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_UNITARIA);
			AddParameter(cmd, "CANTIDAD_ORIG_EMBALADA",
				value.IsCANTIDAD_ORIG_EMBALADANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_EMBALADA);
			AddParameter(cmd, "CANTIDAD_ORIG_CAJA",
				value.IsCANTIDAD_ORIG_CAJANull ? DBNull.Value : (object)value.CANTIDAD_ORIG_CAJA);
			AddParameter(cmd, "CANTIDAD_UNITARIA_ORIG_TOTAL",
				value.IsCANTIDAD_UNITARIA_ORIG_TOTALNull ? DBNull.Value : (object)value.CANTIDAD_UNITARIA_ORIG_TOTAL);
			AddParameter(cmd, "FACTOR_CONVERSION",
				value.IsFACTOR_CONVERSIONNull ? DBNull.Value : (object)value.FACTOR_CONVERSION);
			AddParameter(cmd, "COSTOS_ID",
				value.IsCOSTOS_IDNull ? DBNull.Value : (object)value.COSTOS_ID);
			AddParameter(cmd, "PROVEEDOR_ID",
				value.IsPROVEEDOR_IDNull ? DBNull.Value : (object)value.PROVEEDOR_ID);
			AddParameter(cmd, "SUCURSAL_DESTINO_ID",
				value.IsSUCURSAL_DESTINO_IDNull ? DBNull.Value : (object)value.SUCURSAL_DESTINO_ID);
			AddParameter(cmd, "DEPOSITO_DESTINO_ID",
				value.IsDEPOSITO_DESTINO_IDNull ? DBNull.Value : (object)value.DEPOSITO_DESTINO_ID);
			AddParameter(cmd, "CASO_ID",
				value.IsCASO_IDNull ? DBNull.Value : (object)value.CASO_ID);
			AddParameter(cmd, "RECIBIDO", value.RECIBIDO);
			AddParameter(cmd, "TAR_BRUTO",
				value.IsTAR_BRUTONull ? DBNull.Value : (object)value.TAR_BRUTO);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "TAR_PESO_NETO",
				value.IsTAR_PESO_NETONull ? DBNull.Value : (object)value.TAR_PESO_NETO);
			AddParameter(cmd, "AUTONUMERACION_ID",
				value.IsAUTONUMERACION_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_ID);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "GENERAR_STOCK", value.GENERAR_STOCK);
			AddParameter(cmd, "NRO_CELDA",
				value.IsNRO_CELDANull ? DBNull.Value : (object)value.NRO_CELDA);
			AddParameter(cmd, "DEPOSITO_ORIGEN_ID",
				value.IsDEPOSITO_ORIGEN_IDNull ? DBNull.Value : (object)value.DEPOSITO_ORIGEN_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(STOCK_TRANSFERENCIA_BALANC_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
		/// </summary>
		/// <param name="caso_id">The <c>CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCASO_ID(decimal caso_id)
		{
			return DeleteByCASO_ID(caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
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
		/// delete records using the <c>FK_STK_TRANF_BALAN_CASO_ID</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_DESTINO_ID(decimal deposito_destino_id)
		{
			return DeleteByDEPOSITO_DESTINO_ID(deposito_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDEPOSITO_DESTINO_ID(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			return CreateDeleteByDEPOSITO_DESTINO_IDCommand(deposito_destino_id, deposito_destino_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STK_TRANF_BALAN_DEPO_DEST</c> foreign key.
		/// </summary>
		/// <param name="deposito_destino_id">The <c>DEPOSITO_DESTINO_ID</c> column value.</param>
		/// <param name="deposito_destino_idNull">true if the method ignores the deposito_destino_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDEPOSITO_DESTINO_IDCommand(decimal deposito_destino_id, bool deposito_destino_idNull)
		{
			string whereSql = "";
			if(deposito_destino_idNull)
				whereSql += "DEPOSITO_DESTINO_ID IS NULL";
			else
				whereSql += "DEPOSITO_DESTINO_ID=" + _db.CreateSqlParameterName("DEPOSITO_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!deposito_destino_idNull)
				AddParameter(cmd, "DEPOSITO_DESTINO_ID", deposito_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id)
		{
			return DeleteByARTICULO_ID(articulo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_ID(decimal articulo_id, bool articulo_idNull)
		{
			return CreateDeleteByARTICULO_IDCommand(articulo_id, articulo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STK_TRANF_BALAN_DET_ARTICULO</c> foreign key.
		/// </summary>
		/// <param name="articulo_id">The <c>ARTICULO_ID</c> column value.</param>
		/// <param name="articulo_idNull">true if the method ignores the articulo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_IDCommand(decimal articulo_id, bool articulo_idNull)
		{
			string whereSql = "";
			if(articulo_idNull)
				whereSql += "ARTICULO_ID IS NULL";
			else
				whereSql += "ARTICULO_ID=" + _db.CreateSqlParameterName("ARTICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_idNull)
				AddParameter(cmd, "ARTICULO_ID", articulo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTOS_ID(decimal costos_id)
		{
			return DeleteByCOSTOS_ID(costos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCOSTOS_ID(decimal costos_id, bool costos_idNull)
		{
			return CreateDeleteByCOSTOS_IDCommand(costos_id, costos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STK_TRANF_BALAN_DET_COSTO_ID</c> foreign key.
		/// </summary>
		/// <param name="costos_id">The <c>COSTOS_ID</c> column value.</param>
		/// <param name="costos_idNull">true if the method ignores the costos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCOSTOS_IDCommand(decimal costos_id, bool costos_idNull)
		{
			string whereSql = "";
			if(costos_idNull)
				whereSql += "COSTOS_ID IS NULL";
			else
				whereSql += "COSTOS_ID=" + _db.CreateSqlParameterName("COSTOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!costos_idNull)
				AddParameter(cmd, "COSTOS_ID", costos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
		/// </summary>
		/// <param name="lote_id">The <c>LOTE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLOTE_ID(decimal lote_id)
		{
			return DeleteByLOTE_ID(lote_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
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
		/// delete records using the <c>FK_STK_TRANF_BALAN_DET_LOTE</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
		/// </summary>
		/// <param name="proveedor_id">The <c>PROVEEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPROVEEDOR_ID(decimal proveedor_id)
		{
			return DeleteByPROVEEDOR_ID(proveedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
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
		/// delete records using the <c>FK_STK_TRANF_BALAN_DET_PROVEEDOR</c> foreign key.
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
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BALANC_ID(decimal transferencia_balanc_id)
		{
			return DeleteByTRANSFERENCIA_BALANC_ID(transferencia_balanc_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <param name="transferencia_balanc_idNull">true if the method ignores the transferencia_balanc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSFERENCIA_BALANC_ID(decimal transferencia_balanc_id, bool transferencia_balanc_idNull)
		{
			return CreateDeleteByTRANSFERENCIA_BALANC_IDCommand(transferencia_balanc_id, transferencia_balanc_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STK_TRANF_BALAN_DET_TRANSF</c> foreign key.
		/// </summary>
		/// <param name="transferencia_balanc_id">The <c>TRANSFERENCIA_BALANC_ID</c> column value.</param>
		/// <param name="transferencia_balanc_idNull">true if the method ignores the transferencia_balanc_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSFERENCIA_BALANC_IDCommand(decimal transferencia_balanc_id, bool transferencia_balanc_idNull)
		{
			string whereSql = "";
			if(transferencia_balanc_idNull)
				whereSql += "TRANSFERENCIA_BALANC_ID IS NULL";
			else
				whereSql += "TRANSFERENCIA_BALANC_ID=" + _db.CreateSqlParameterName("TRANSFERENCIA_BALANC_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transferencia_balanc_idNull)
				AddParameter(cmd, "TRANSFERENCIA_BALANC_ID", transferencia_balanc_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_DESTINO_ID(string unidad_medida_destino_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_DESTINO_IDCommand(unidad_medida_destino_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STK_TRANF_BALAN_DET_UNID_DEST</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_destino_id">The <c>UNIDAD_MEDIDA_DESTINO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_DESTINO_IDCommand(string unidad_medida_destino_id)
		{
			string whereSql = "";
			if(null == unidad_medida_destino_id)
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_DESTINO_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_DESTINO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_medida_destino_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_DESTINO_ID", unidad_medida_destino_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUNIDAD_MEDIDA_ORIGEN_ID(string unidad_medida_origen_id)
		{
			return CreateDeleteByUNIDAD_MEDIDA_ORIGEN_IDCommand(unidad_medida_origen_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_STK_TRANF_BALAN_DET_UNID_ORIG</c> foreign key.
		/// </summary>
		/// <param name="unidad_medida_origen_id">The <c>UNIDAD_MEDIDA_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUNIDAD_MEDIDA_ORIGEN_IDCommand(string unidad_medida_origen_id)
		{
			string whereSql = "";
			if(null == unidad_medida_origen_id)
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID IS NULL";
			else
				whereSql += "UNIDAD_MEDIDA_ORIGEN_ID=" + _db.CreateSqlParameterName("UNIDAD_MEDIDA_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != unidad_medida_origen_id)
				AddParameter(cmd, "UNIDAD_MEDIDA_ORIGEN_ID", unidad_medida_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
		/// </summary>
		/// <param name="sucursal_destino_id">The <c>SUCURSAL_DESTINO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteBySUCURSAL_DESTINO_ID(decimal sucursal_destino_id)
		{
			return DeleteBySUCURSAL_DESTINO_ID(sucursal_destino_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table using the 
		/// <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
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
		/// delete records using the <c>FK_STK_TRANF_BALAN_SUC_DEST</c> foreign key.
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
		/// Deletes <c>STOCK_TRANSFERENCIA_BALANC_DET</c> records that match the specified criteria.
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
		/// to delete <c>STOCK_TRANSFERENCIA_BALANC_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.STOCK_TRANSFERENCIA_BALANC_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		protected STOCK_TRANSFERENCIA_BALANC_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		protected STOCK_TRANSFERENCIA_BALANC_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> objects.</returns>
		protected virtual STOCK_TRANSFERENCIA_BALANC_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int transferencia_balanc_idColumnIndex = reader.GetOrdinal("TRANSFERENCIA_BALANC_ID");
			int articulo_idColumnIndex = reader.GetOrdinal("ARTICULO_ID");
			int lote_idColumnIndex = reader.GetOrdinal("LOTE_ID");
			int unidad_medida_destino_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_DESTINO_ID");
			int cantidad_dest_unitariaColumnIndex = reader.GetOrdinal("CANTIDAD_DEST_UNITARIA");
			int cantidad_dest_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_DEST_EMBALADA");
			int cantidad_dest_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_DEST_CAJA");
			int costo_moneda_idColumnIndex = reader.GetOrdinal("COSTO_MONEDA_ID");
			int cotizacion_monedaColumnIndex = reader.GetOrdinal("COTIZACION_MONEDA");
			int monto_costoColumnIndex = reader.GetOrdinal("MONTO_COSTO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int cantidad_unitaria_dest_totalColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_DEST_TOTAL");
			int unidad_medida_origen_idColumnIndex = reader.GetOrdinal("UNIDAD_MEDIDA_ORIGEN_ID");
			int cantidad_orig_unitariaColumnIndex = reader.GetOrdinal("CANTIDAD_ORIG_UNITARIA");
			int cantidad_orig_embaladaColumnIndex = reader.GetOrdinal("CANTIDAD_ORIG_EMBALADA");
			int cantidad_orig_cajaColumnIndex = reader.GetOrdinal("CANTIDAD_ORIG_CAJA");
			int cantidad_unitaria_orig_totalColumnIndex = reader.GetOrdinal("CANTIDAD_UNITARIA_ORIG_TOTAL");
			int factor_conversionColumnIndex = reader.GetOrdinal("FACTOR_CONVERSION");
			int costos_idColumnIndex = reader.GetOrdinal("COSTOS_ID");
			int proveedor_idColumnIndex = reader.GetOrdinal("PROVEEDOR_ID");
			int sucursal_destino_idColumnIndex = reader.GetOrdinal("SUCURSAL_DESTINO_ID");
			int deposito_destino_idColumnIndex = reader.GetOrdinal("DEPOSITO_DESTINO_ID");
			int caso_idColumnIndex = reader.GetOrdinal("CASO_ID");
			int recibidoColumnIndex = reader.GetOrdinal("RECIBIDO");
			int tar_brutoColumnIndex = reader.GetOrdinal("TAR_BRUTO");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int tar_peso_netoColumnIndex = reader.GetOrdinal("TAR_PESO_NETO");
			int autonumeracion_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_ID");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int generar_stockColumnIndex = reader.GetOrdinal("GENERAR_STOCK");
			int nro_celdaColumnIndex = reader.GetOrdinal("NRO_CELDA");
			int deposito_origen_idColumnIndex = reader.GetOrdinal("DEPOSITO_ORIGEN_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					STOCK_TRANSFERENCIA_BALANC_DETRow record = new STOCK_TRANSFERENCIA_BALANC_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(transferencia_balanc_idColumnIndex))
						record.TRANSFERENCIA_BALANC_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transferencia_balanc_idColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_idColumnIndex))
						record.ARTICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_idColumnIndex)), 9);
					if(!reader.IsDBNull(lote_idColumnIndex))
						record.LOTE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lote_idColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_destino_idColumnIndex))
						record.UNIDAD_MEDIDA_DESTINO_ID = Convert.ToString(reader.GetValue(unidad_medida_destino_idColumnIndex));
					if(!reader.IsDBNull(cantidad_dest_unitariaColumnIndex))
						record.CANTIDAD_DEST_UNITARIA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dest_unitariaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_dest_embaladaColumnIndex))
						record.CANTIDAD_DEST_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dest_embaladaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_dest_cajaColumnIndex))
						record.CANTIDAD_DEST_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_dest_cajaColumnIndex)), 9);
					if(!reader.IsDBNull(costo_moneda_idColumnIndex))
						record.COSTO_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costo_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(cotizacion_monedaColumnIndex))
						record.COTIZACION_MONEDA = Math.Round(Convert.ToDecimal(reader.GetValue(cotizacion_monedaColumnIndex)), 9);
					if(!reader.IsDBNull(monto_costoColumnIndex))
						record.MONTO_COSTO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_costoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(cantidad_unitaria_dest_totalColumnIndex))
						record.CANTIDAD_UNITARIA_DEST_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_dest_totalColumnIndex)), 9);
					if(!reader.IsDBNull(unidad_medida_origen_idColumnIndex))
						record.UNIDAD_MEDIDA_ORIGEN_ID = Convert.ToString(reader.GetValue(unidad_medida_origen_idColumnIndex));
					if(!reader.IsDBNull(cantidad_orig_unitariaColumnIndex))
						record.CANTIDAD_ORIG_UNITARIA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_orig_unitariaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_orig_embaladaColumnIndex))
						record.CANTIDAD_ORIG_EMBALADA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_orig_embaladaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_orig_cajaColumnIndex))
						record.CANTIDAD_ORIG_CAJA = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_orig_cajaColumnIndex)), 9);
					if(!reader.IsDBNull(cantidad_unitaria_orig_totalColumnIndex))
						record.CANTIDAD_UNITARIA_ORIG_TOTAL = Math.Round(Convert.ToDecimal(reader.GetValue(cantidad_unitaria_orig_totalColumnIndex)), 9);
					if(!reader.IsDBNull(factor_conversionColumnIndex))
						record.FACTOR_CONVERSION = Math.Round(Convert.ToDecimal(reader.GetValue(factor_conversionColumnIndex)), 9);
					if(!reader.IsDBNull(costos_idColumnIndex))
						record.COSTOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(costos_idColumnIndex)), 9);
					if(!reader.IsDBNull(proveedor_idColumnIndex))
						record.PROVEEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(proveedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(sucursal_destino_idColumnIndex))
						record.SUCURSAL_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(sucursal_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_destino_idColumnIndex))
						record.DEPOSITO_DESTINO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_destino_idColumnIndex)), 9);
					if(!reader.IsDBNull(caso_idColumnIndex))
						record.CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(caso_idColumnIndex)), 9);
					if(!reader.IsDBNull(recibidoColumnIndex))
						record.RECIBIDO = Convert.ToString(reader.GetValue(recibidoColumnIndex));
					if(!reader.IsDBNull(tar_brutoColumnIndex))
						record.TAR_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(tar_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(tar_peso_netoColumnIndex))
						record.TAR_PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(tar_peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(autonumeracion_idColumnIndex))
						record.AUTONUMERACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_idColumnIndex)), 9);
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(generar_stockColumnIndex))
						record.GENERAR_STOCK = Convert.ToString(reader.GetValue(generar_stockColumnIndex));
					if(!reader.IsDBNull(nro_celdaColumnIndex))
						record.NRO_CELDA = Math.Round(Convert.ToDecimal(reader.GetValue(nro_celdaColumnIndex)), 9);
					if(!reader.IsDBNull(deposito_origen_idColumnIndex))
						record.DEPOSITO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(deposito_origen_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (STOCK_TRANSFERENCIA_BALANC_DETRow[])(recordList.ToArray(typeof(STOCK_TRANSFERENCIA_BALANC_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="STOCK_TRANSFERENCIA_BALANC_DETRow"/> object.</returns>
		protected virtual STOCK_TRANSFERENCIA_BALANC_DETRow MapRow(DataRow row)
		{
			STOCK_TRANSFERENCIA_BALANC_DETRow mappedObject = new STOCK_TRANSFERENCIA_BALANC_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TRANSFERENCIA_BALANC_ID"
			dataColumn = dataTable.Columns["TRANSFERENCIA_BALANC_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSFERENCIA_BALANC_ID = (decimal)row[dataColumn];
			// Column "ARTICULO_ID"
			dataColumn = dataTable.Columns["ARTICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_ID = (decimal)row[dataColumn];
			// Column "LOTE_ID"
			dataColumn = dataTable.Columns["LOTE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LOTE_ID = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_DESTINO_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_DESTINO_ID = (string)row[dataColumn];
			// Column "CANTIDAD_DEST_UNITARIA"
			dataColumn = dataTable.Columns["CANTIDAD_DEST_UNITARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEST_UNITARIA = (decimal)row[dataColumn];
			// Column "CANTIDAD_DEST_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_DEST_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEST_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_DEST_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_DEST_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_DEST_CAJA = (decimal)row[dataColumn];
			// Column "COSTO_MONEDA_ID"
			dataColumn = dataTable.Columns["COSTO_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTO_MONEDA_ID = (decimal)row[dataColumn];
			// Column "COTIZACION_MONEDA"
			dataColumn = dataTable.Columns["COTIZACION_MONEDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.COTIZACION_MONEDA = (decimal)row[dataColumn];
			// Column "MONTO_COSTO"
			dataColumn = dataTable.Columns["MONTO_COSTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_COSTO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_DEST_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_DEST_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_DEST_TOTAL = (decimal)row[dataColumn];
			// Column "UNIDAD_MEDIDA_ORIGEN_ID"
			dataColumn = dataTable.Columns["UNIDAD_MEDIDA_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.UNIDAD_MEDIDA_ORIGEN_ID = (string)row[dataColumn];
			// Column "CANTIDAD_ORIG_UNITARIA"
			dataColumn = dataTable.Columns["CANTIDAD_ORIG_UNITARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIG_UNITARIA = (decimal)row[dataColumn];
			// Column "CANTIDAD_ORIG_EMBALADA"
			dataColumn = dataTable.Columns["CANTIDAD_ORIG_EMBALADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIG_EMBALADA = (decimal)row[dataColumn];
			// Column "CANTIDAD_ORIG_CAJA"
			dataColumn = dataTable.Columns["CANTIDAD_ORIG_CAJA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_ORIG_CAJA = (decimal)row[dataColumn];
			// Column "CANTIDAD_UNITARIA_ORIG_TOTAL"
			dataColumn = dataTable.Columns["CANTIDAD_UNITARIA_ORIG_TOTAL"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD_UNITARIA_ORIG_TOTAL = (decimal)row[dataColumn];
			// Column "FACTOR_CONVERSION"
			dataColumn = dataTable.Columns["FACTOR_CONVERSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTOR_CONVERSION = (decimal)row[dataColumn];
			// Column "COSTOS_ID"
			dataColumn = dataTable.Columns["COSTOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.COSTOS_ID = (decimal)row[dataColumn];
			// Column "PROVEEDOR_ID"
			dataColumn = dataTable.Columns["PROVEEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROVEEDOR_ID = (decimal)row[dataColumn];
			// Column "SUCURSAL_DESTINO_ID"
			dataColumn = dataTable.Columns["SUCURSAL_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.SUCURSAL_DESTINO_ID = (decimal)row[dataColumn];
			// Column "DEPOSITO_DESTINO_ID"
			dataColumn = dataTable.Columns["DEPOSITO_DESTINO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_DESTINO_ID = (decimal)row[dataColumn];
			// Column "CASO_ID"
			dataColumn = dataTable.Columns["CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CASO_ID = (decimal)row[dataColumn];
			// Column "RECIBIDO"
			dataColumn = dataTable.Columns["RECIBIDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.RECIBIDO = (string)row[dataColumn];
			// Column "TAR_BRUTO"
			dataColumn = dataTable.Columns["TAR_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TAR_BRUTO = (decimal)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "TAR_PESO_NETO"
			dataColumn = dataTable.Columns["TAR_PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TAR_PESO_NETO = (decimal)row[dataColumn];
			// Column "AUTONUMERACION_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_ID = (decimal)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "GENERAR_STOCK"
			dataColumn = dataTable.Columns["GENERAR_STOCK"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERAR_STOCK = (string)row[dataColumn];
			// Column "NRO_CELDA"
			dataColumn = dataTable.Columns["NRO_CELDA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CELDA = (decimal)row[dataColumn];
			// Column "DEPOSITO_ORIGEN_ID"
			dataColumn = dataTable.Columns["DEPOSITO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DEPOSITO_ORIGEN_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>STOCK_TRANSFERENCIA_BALANC_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "STOCK_TRANSFERENCIA_BALANC_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TRANSFERENCIA_BALANC_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ARTICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LOTE_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_DESTINO_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEST_UNITARIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEST_EMBALADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_DEST_CAJA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTO_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COTIZACION_MONEDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTO_COSTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_DEST_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("UNIDAD_MEDIDA_ORIGEN_ID", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIG_UNITARIA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIG_EMBALADA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_ORIG_CAJA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD_UNITARIA_ORIG_TOTAL", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FACTOR_CONVERSION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("COSTOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PROVEEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SUCURSAL_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_DESTINO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RECIBIDO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("TAR_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TAR_PESO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("GENERAR_STOCK", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NRO_CELDA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DEPOSITO_ORIGEN_ID", typeof(decimal));
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

				case "TRANSFERENCIA_BALANC_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LOTE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_DEST_UNITARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DEST_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_DEST_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTO_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COTIZACION_MONEDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTO_COSTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_UNITARIA_DEST_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "UNIDAD_MEDIDA_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD_ORIG_UNITARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ORIG_EMBALADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_ORIG_CAJA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD_UNITARIA_ORIG_TOTAL":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FACTOR_CONVERSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "COSTOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROVEEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SUCURSAL_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_DESTINO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RECIBIDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TAR_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TAR_PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "AUTONUMERACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GENERAR_STOCK":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_CELDA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DEPOSITO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of STOCK_TRANSFERENCIA_BALANC_DETCollection_Base class
}  // End of namespace
