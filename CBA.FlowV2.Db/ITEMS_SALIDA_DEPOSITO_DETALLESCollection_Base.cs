// <fileinfo name="ITEMS_SALIDA_DEPOSITO_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_SALIDA_DEPOSITO_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEM_SALIDA_DEPOSITO_IDColumnName = "ITEM_SALIDA_DEPOSITO_ID";
		public const string FECHA_ENTRADA_PUERTOColumnName = "FECHA_ENTRADA_PUERTO";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string NOMBRE_ENCARGADOColumnName = "NOMBRE_ENCARGADO";
		public const string STATUSColumnName = "STATUS";
		public const string TRANSPORTADORA_PERSONA_IDColumnName = "TRANSPORTADORA_PERSONA_ID";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string TIPO_CAMION_IDColumnName = "TIPO_CAMION_ID";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string TIPO_BULTO_IDColumnName = "TIPO_BULTO_ID";
		public const string MERCADERIAColumnName = "MERCADERIA";
		public const string FECHA_SALIDA_PUERTOColumnName = "FECHA_SALIDA_PUERTO";
		public const string CONFIRMADOColumnName = "CONFIRMADO";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FECHA_CONFIRMACIONColumnName = "FECHA_CONFIRMACION";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string PRECINTO_VENTILETEColumnName = "PRECINTO_VENTILETE";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string TIPO_RETIROColumnName = "TIPO_RETIRO";
		public const string SEMANAColumnName = "SEMANA";
		public const string FECHA_SALIDA_DEPOSITOColumnName = "FECHA_SALIDA_DEPOSITO";
		public const string FECHA_ENTRADA_DEPOSITOColumnName = "FECHA_ENTRADA_DEPOSITO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_SALIDA_DEPOSITO_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_SALIDA_DEPOSITO_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_SALIDA_DEPOSITO_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_SALIDA_DEPOSITO_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ITEMS_SALIDA_DEPOSITO_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONTENEDOR_IDCommand(decimal contenedor_id, bool contenedor_idNull)
		{
			string whereSql = "";
			if(contenedor_idNull)
				whereSql += "CONTENEDOR_ID IS NULL";
			else
				whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!contenedor_idNull)
				AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByITEM_SALIDA_DEPOSITO_ID(decimal item_salida_deposito_id)
		{
			return GetByITEM_SALIDA_DEPOSITO_ID(item_salida_deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <param name="item_salida_deposito_idNull">true if the method ignores the item_salida_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByITEM_SALIDA_DEPOSITO_ID(decimal item_salida_deposito_id, bool item_salida_deposito_idNull)
		{
			return MapRecords(CreateGetByITEM_SALIDA_DEPOSITO_IDCommand(item_salida_deposito_id, item_salida_deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEM_SALIDA_DEPOSITO_IDAsDataTable(decimal item_salida_deposito_id)
		{
			return GetByITEM_SALIDA_DEPOSITO_IDAsDataTable(item_salida_deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <param name="item_salida_deposito_idNull">true if the method ignores the item_salida_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEM_SALIDA_DEPOSITO_IDAsDataTable(decimal item_salida_deposito_id, bool item_salida_deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEM_SALIDA_DEPOSITO_IDCommand(item_salida_deposito_id, item_salida_deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <param name="item_salida_deposito_idNull">true if the method ignores the item_salida_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEM_SALIDA_DEPOSITO_IDCommand(decimal item_salida_deposito_id, bool item_salida_deposito_idNull)
		{
			string whereSql = "";
			if(item_salida_deposito_idNull)
				whereSql += "ITEM_SALIDA_DEPOSITO_ID IS NULL";
			else
				whereSql += "ITEM_SALIDA_DEPOSITO_ID=" + _db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!item_salida_deposito_idNull)
				AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ID", item_salida_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByTIPO_CAMION_ID(decimal tipo_camion_id)
		{
			return GetByTIPO_CAMION_ID(tipo_camion_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <param name="tipo_camion_idNull">true if the method ignores the tipo_camion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByTIPO_CAMION_ID(decimal tipo_camion_id, bool tipo_camion_idNull)
		{
			return MapRecords(CreateGetByTIPO_CAMION_IDCommand(tipo_camion_id, tipo_camion_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_CAMION_IDAsDataTable(decimal tipo_camion_id)
		{
			return GetByTIPO_CAMION_IDAsDataTable(tipo_camion_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <param name="tipo_camion_idNull">true if the method ignores the tipo_camion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_CAMION_IDAsDataTable(decimal tipo_camion_id, bool tipo_camion_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_CAMION_IDCommand(tipo_camion_id, tipo_camion_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <param name="tipo_camion_idNull">true if the method ignores the tipo_camion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_CAMION_IDCommand(decimal tipo_camion_id, bool tipo_camion_idNull)
		{
			string whereSql = "";
			if(tipo_camion_idNull)
				whereSql += "TIPO_CAMION_ID IS NULL";
			else
				whereSql += "TIPO_CAMION_ID=" + _db.CreateSqlParameterName("TIPO_CAMION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_camion_idNull)
				AddParameter(cmd, "TIPO_CAMION_ID", tipo_camion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id)
		{
			return GetByTRANSPORTADORA_PERSONA_ID(transportadora_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			return MapRecords(CreateGetByTRANSPORTADORA_PERSONA_IDCommand(transportadora_persona_id, transportadora_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSPORTADORA_PERSONA_IDAsDataTable(decimal transportadora_persona_id)
		{
			return GetByTRANSPORTADORA_PERSONA_IDAsDataTable(transportadora_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRANSPORTADORA_PERSONA_IDAsDataTable(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTRANSPORTADORA_PERSONA_IDCommand(transportadora_persona_id, transportadora_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRANSPORTADORA_PERSONA_IDCommand(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			string whereSql = "";
			if(transportadora_persona_idNull)
				whereSql += "TRANSPORTADORA_PERSONA_ID IS NULL";
			else
				whereSql += "TRANSPORTADORA_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!transportadora_persona_idNull)
				AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID", transportadora_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects 
		/// by the <c>FK_IT_SAL_DEP_DET_UN_MED_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_bulto_id">The <c>TIPO_BULTO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] GetByTIPO_BULTO_ID(string tipo_bulto_id)
		{
			return MapRecords(CreateGetByTIPO_BULTO_IDCommand(tipo_bulto_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_IT_SAL_DEP_DET_UN_MED_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_bulto_id">The <c>TIPO_BULTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_BULTO_IDAsDataTable(string tipo_bulto_id)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_BULTO_IDCommand(tipo_bulto_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_IT_SAL_DEP_DET_UN_MED_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_bulto_id">The <c>TIPO_BULTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_BULTO_IDCommand(string tipo_bulto_id)
		{
			string whereSql = "";
			if(null == tipo_bulto_id)
				whereSql += "TIPO_BULTO_ID IS NULL";
			else
				whereSql += "TIPO_BULTO_ID=" + _db.CreateSqlParameterName("TIPO_BULTO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(null != tipo_bulto_id)
				AddParameter(cmd, "TIPO_BULTO_ID", tipo_bulto_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(ITEMS_SALIDA_DEPOSITO_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ITEMS_SALIDA_DEPOSITO_DETALLES (" +
				"ID, " +
				"ITEM_SALIDA_DEPOSITO_ID, " +
				"FECHA_ENTRADA_PUERTO, " +
				"CHAPA_CAMION, " +
				"CHAPA_CARRETA, " +
				"NOMBRE_ENCARGADO, " +
				"STATUS, " +
				"TRANSPORTADORA_PERSONA_ID, " +
				"TRANSPORTADORA_NOMBRE, " +
				"TIPO_CAMION_ID, " +
				"CHOFER_NOMBRE, " +
				"CHOFER_DOCUMENTO, " +
				"TARA_CAMION, " +
				"TARA_CONTENEDOR, " +
				"PESO_BRUTO, " +
				"PESO_NETO, " +
				"OBSERVACIONES, " +
				"CANTIDAD, " +
				"TIPO_BULTO_ID, " +
				"MERCADERIA, " +
				"FECHA_SALIDA_PUERTO, " +
				"CONFIRMADO, " +
				"NRO_COMPROBANTE, " +
				"FECHA_CONFIRMACION, " +
				"PRECINTO_1, " +
				"PRECINTO_2, " +
				"PRECINTO_3, " +
				"PRECINTO_4, " +
				"PRECINTO_5, " +
				"PRECINTO_VENTILETE, " +
				"CONTENEDOR_ID, " +
				"TIPO_RETIRO, " +
				"SEMANA, " +
				"FECHA_SALIDA_DEPOSITO, " +
				"FECHA_ENTRADA_DEPOSITO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_ENTRADA_PUERTO") + ", " +
				_db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				_db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				_db.CreateSqlParameterName("NOMBRE_ENCARGADO") + ", " +
				_db.CreateSqlParameterName("STATUS") + ", " +
				_db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("TRANSPORTADORA_NOMBRE") + ", " +
				_db.CreateSqlParameterName("TIPO_CAMION_ID") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("TARA_CAMION") + ", " +
				_db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				_db.CreateSqlParameterName("PESO_NETO") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("TIPO_BULTO_ID") + ", " +
				_db.CreateSqlParameterName("MERCADERIA") + ", " +
				_db.CreateSqlParameterName("FECHA_SALIDA_PUERTO") + ", " +
				_db.CreateSqlParameterName("CONFIRMADO") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FECHA_CONFIRMACION") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5") + ", " +
				_db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("TIPO_RETIRO") + ", " +
				_db.CreateSqlParameterName("SEMANA") + ", " +
				_db.CreateSqlParameterName("FECHA_SALIDA_DEPOSITO") + ", " +
				_db.CreateSqlParameterName("FECHA_ENTRADA_DEPOSITO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ID",
				value.IsITEM_SALIDA_DEPOSITO_IDNull ? DBNull.Value : (object)value.ITEM_SALIDA_DEPOSITO_ID);
			AddParameter(cmd, "FECHA_ENTRADA_PUERTO",
				value.IsFECHA_ENTRADA_PUERTONull ? DBNull.Value : (object)value.FECHA_ENTRADA_PUERTO);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "NOMBRE_ENCARGADO", value.NOMBRE_ENCARGADO);
			AddParameter(cmd, "STATUS", value.STATUS);
			AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID",
				value.IsTRANSPORTADORA_PERSONA_IDNull ? DBNull.Value : (object)value.TRANSPORTADORA_PERSONA_ID);
			AddParameter(cmd, "TRANSPORTADORA_NOMBRE", value.TRANSPORTADORA_NOMBRE);
			AddParameter(cmd, "TIPO_CAMION_ID",
				value.IsTIPO_CAMION_IDNull ? DBNull.Value : (object)value.TIPO_CAMION_ID);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTO_ID", value.TIPO_BULTO_ID);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "FECHA_SALIDA_PUERTO",
				value.IsFECHA_SALIDA_PUERTONull ? DBNull.Value : (object)value.FECHA_SALIDA_PUERTO);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_CONFIRMACION",
				value.IsFECHA_CONFIRMACIONNull ? DBNull.Value : (object)value.FECHA_CONFIRMACION);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "TIPO_RETIRO", value.TIPO_RETIRO);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			AddParameter(cmd, "FECHA_SALIDA_DEPOSITO",
				value.IsFECHA_SALIDA_DEPOSITONull ? DBNull.Value : (object)value.FECHA_SALIDA_DEPOSITO);
			AddParameter(cmd, "FECHA_ENTRADA_DEPOSITO",
				value.IsFECHA_ENTRADA_DEPOSITONull ? DBNull.Value : (object)value.FECHA_ENTRADA_DEPOSITO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ITEMS_SALIDA_DEPOSITO_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.ITEMS_SALIDA_DEPOSITO_DETALLES SET " +
				"ITEM_SALIDA_DEPOSITO_ID=" + _db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ID") + ", " +
				"FECHA_ENTRADA_PUERTO=" + _db.CreateSqlParameterName("FECHA_ENTRADA_PUERTO") + ", " +
				"CHAPA_CAMION=" + _db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				"CHAPA_CARRETA=" + _db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				"NOMBRE_ENCARGADO=" + _db.CreateSqlParameterName("NOMBRE_ENCARGADO") + ", " +
				"STATUS=" + _db.CreateSqlParameterName("STATUS") + ", " +
				"TRANSPORTADORA_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID") + ", " +
				"TRANSPORTADORA_NOMBRE=" + _db.CreateSqlParameterName("TRANSPORTADORA_NOMBRE") + ", " +
				"TIPO_CAMION_ID=" + _db.CreateSqlParameterName("TIPO_CAMION_ID") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"CHOFER_DOCUMENTO=" + _db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				"TARA_CAMION=" + _db.CreateSqlParameterName("TARA_CAMION") + ", " +
				"TARA_CONTENEDOR=" + _db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				"PESO_BRUTO=" + _db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				"PESO_NETO=" + _db.CreateSqlParameterName("PESO_NETO") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"TIPO_BULTO_ID=" + _db.CreateSqlParameterName("TIPO_BULTO_ID") + ", " +
				"MERCADERIA=" + _db.CreateSqlParameterName("MERCADERIA") + ", " +
				"FECHA_SALIDA_PUERTO=" + _db.CreateSqlParameterName("FECHA_SALIDA_PUERTO") + ", " +
				"CONFIRMADO=" + _db.CreateSqlParameterName("CONFIRMADO") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FECHA_CONFIRMACION=" + _db.CreateSqlParameterName("FECHA_CONFIRMACION") + ", " +
				"PRECINTO_1=" + _db.CreateSqlParameterName("PRECINTO_1") + ", " +
				"PRECINTO_2=" + _db.CreateSqlParameterName("PRECINTO_2") + ", " +
				"PRECINTO_3=" + _db.CreateSqlParameterName("PRECINTO_3") + ", " +
				"PRECINTO_4=" + _db.CreateSqlParameterName("PRECINTO_4") + ", " +
				"PRECINTO_5=" + _db.CreateSqlParameterName("PRECINTO_5") + ", " +
				"PRECINTO_VENTILETE=" + _db.CreateSqlParameterName("PRECINTO_VENTILETE") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"TIPO_RETIRO=" + _db.CreateSqlParameterName("TIPO_RETIRO") + ", " +
				"SEMANA=" + _db.CreateSqlParameterName("SEMANA") + ", " +
				"FECHA_SALIDA_DEPOSITO=" + _db.CreateSqlParameterName("FECHA_SALIDA_DEPOSITO") + ", " +
				"FECHA_ENTRADA_DEPOSITO=" + _db.CreateSqlParameterName("FECHA_ENTRADA_DEPOSITO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ID",
				value.IsITEM_SALIDA_DEPOSITO_IDNull ? DBNull.Value : (object)value.ITEM_SALIDA_DEPOSITO_ID);
			AddParameter(cmd, "FECHA_ENTRADA_PUERTO",
				value.IsFECHA_ENTRADA_PUERTONull ? DBNull.Value : (object)value.FECHA_ENTRADA_PUERTO);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "NOMBRE_ENCARGADO", value.NOMBRE_ENCARGADO);
			AddParameter(cmd, "STATUS", value.STATUS);
			AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID",
				value.IsTRANSPORTADORA_PERSONA_IDNull ? DBNull.Value : (object)value.TRANSPORTADORA_PERSONA_ID);
			AddParameter(cmd, "TRANSPORTADORA_NOMBRE", value.TRANSPORTADORA_NOMBRE);
			AddParameter(cmd, "TIPO_CAMION_ID",
				value.IsTIPO_CAMION_IDNull ? DBNull.Value : (object)value.TIPO_CAMION_ID);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTO_ID", value.TIPO_BULTO_ID);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "FECHA_SALIDA_PUERTO",
				value.IsFECHA_SALIDA_PUERTONull ? DBNull.Value : (object)value.FECHA_SALIDA_PUERTO);
			AddParameter(cmd, "CONFIRMADO", value.CONFIRMADO);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FECHA_CONFIRMACION",
				value.IsFECHA_CONFIRMACIONNull ? DBNull.Value : (object)value.FECHA_CONFIRMACION);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "PRECINTO_VENTILETE", value.PRECINTO_VENTILETE);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "TIPO_RETIRO", value.TIPO_RETIRO);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			AddParameter(cmd, "FECHA_SALIDA_DEPOSITO",
				value.IsFECHA_SALIDA_DEPOSITONull ? DBNull.Value : (object)value.FECHA_SALIDA_DEPOSITO);
			AddParameter(cmd, "FECHA_ENTRADA_DEPOSITO",
				value.IsFECHA_ENTRADA_DEPOSITONull ? DBNull.Value : (object)value.FECHA_ENTRADA_DEPOSITO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ITEMS_SALIDA_DEPOSITO_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using
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
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return CreateDeleteByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IT_SAL_DEP_DET_CONT_ID</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONTENEDOR_IDCommand(decimal contenedor_id, bool contenedor_idNull)
		{
			string whereSql = "";
			if(contenedor_idNull)
				whereSql += "CONTENEDOR_ID IS NULL";
			else
				whereSql += "CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!contenedor_idNull)
				AddParameter(cmd, "CONTENEDOR_ID", contenedor_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEM_SALIDA_DEPOSITO_ID(decimal item_salida_deposito_id)
		{
			return DeleteByITEM_SALIDA_DEPOSITO_ID(item_salida_deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <param name="item_salida_deposito_idNull">true if the method ignores the item_salida_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEM_SALIDA_DEPOSITO_ID(decimal item_salida_deposito_id, bool item_salida_deposito_idNull)
		{
			return CreateDeleteByITEM_SALIDA_DEPOSITO_IDCommand(item_salida_deposito_id, item_salida_deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IT_SAL_DEP_DET_ITEM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_id">The <c>ITEM_SALIDA_DEPOSITO_ID</c> column value.</param>
		/// <param name="item_salida_deposito_idNull">true if the method ignores the item_salida_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEM_SALIDA_DEPOSITO_IDCommand(decimal item_salida_deposito_id, bool item_salida_deposito_idNull)
		{
			string whereSql = "";
			if(item_salida_deposito_idNull)
				whereSql += "ITEM_SALIDA_DEPOSITO_ID IS NULL";
			else
				whereSql += "ITEM_SALIDA_DEPOSITO_ID=" + _db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!item_salida_deposito_idNull)
				AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ID", item_salida_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CAMION_ID(decimal tipo_camion_id)
		{
			return DeleteByTIPO_CAMION_ID(tipo_camion_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <param name="tipo_camion_idNull">true if the method ignores the tipo_camion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_CAMION_ID(decimal tipo_camion_id, bool tipo_camion_idNull)
		{
			return CreateDeleteByTIPO_CAMION_IDCommand(tipo_camion_id, tipo_camion_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IT_SAL_DEP_DET_TIPO_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_camion_id">The <c>TIPO_CAMION_ID</c> column value.</param>
		/// <param name="tipo_camion_idNull">true if the method ignores the tipo_camion_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_CAMION_IDCommand(decimal tipo_camion_id, bool tipo_camion_idNull)
		{
			string whereSql = "";
			if(tipo_camion_idNull)
				whereSql += "TIPO_CAMION_ID IS NULL";
			else
				whereSql += "TIPO_CAMION_ID=" + _db.CreateSqlParameterName("TIPO_CAMION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_camion_idNull)
				AddParameter(cmd, "TIPO_CAMION_ID", tipo_camion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id)
		{
			return DeleteByTRANSPORTADORA_PERSONA_ID(transportadora_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			return CreateDeleteByTRANSPORTADORA_PERSONA_IDCommand(transportadora_persona_id, transportadora_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IT_SAL_DEP_DET_TRA_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRANSPORTADORA_PERSONA_IDCommand(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			string whereSql = "";
			if(transportadora_persona_idNull)
				whereSql += "TRANSPORTADORA_PERSONA_ID IS NULL";
			else
				whereSql += "TRANSPORTADORA_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!transportadora_persona_idNull)
				AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID", transportadora_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table using the 
		/// <c>FK_IT_SAL_DEP_DET_UN_MED_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_bulto_id">The <c>TIPO_BULTO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_BULTO_ID(string tipo_bulto_id)
		{
			return CreateDeleteByTIPO_BULTO_IDCommand(tipo_bulto_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_IT_SAL_DEP_DET_UN_MED_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_bulto_id">The <c>TIPO_BULTO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_BULTO_IDCommand(string tipo_bulto_id)
		{
			string whereSql = "";
			if(null == tipo_bulto_id)
				whereSql += "TIPO_BULTO_ID IS NULL";
			else
				whereSql += "TIPO_BULTO_ID=" + _db.CreateSqlParameterName("TIPO_BULTO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(null != tipo_bulto_id)
				AddParameter(cmd, "TIPO_BULTO_ID", tipo_bulto_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ITEMS_SALIDA_DEPOSITO_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		protected ITEMS_SALIDA_DEPOSITO_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		protected ITEMS_SALIDA_DEPOSITO_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> objects.</returns>
		protected virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int item_salida_deposito_idColumnIndex = reader.GetOrdinal("ITEM_SALIDA_DEPOSITO_ID");
			int fecha_entrada_puertoColumnIndex = reader.GetOrdinal("FECHA_ENTRADA_PUERTO");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int nombre_encargadoColumnIndex = reader.GetOrdinal("NOMBRE_ENCARGADO");
			int statusColumnIndex = reader.GetOrdinal("STATUS");
			int transportadora_persona_idColumnIndex = reader.GetOrdinal("TRANSPORTADORA_PERSONA_ID");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int tipo_camion_idColumnIndex = reader.GetOrdinal("TIPO_CAMION_ID");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int tipo_bulto_idColumnIndex = reader.GetOrdinal("TIPO_BULTO_ID");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");
			int fecha_salida_puertoColumnIndex = reader.GetOrdinal("FECHA_SALIDA_PUERTO");
			int confirmadoColumnIndex = reader.GetOrdinal("CONFIRMADO");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int fecha_confirmacionColumnIndex = reader.GetOrdinal("FECHA_CONFIRMACION");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int precinto_ventileteColumnIndex = reader.GetOrdinal("PRECINTO_VENTILETE");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int tipo_retiroColumnIndex = reader.GetOrdinal("TIPO_RETIRO");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");
			int fecha_salida_depositoColumnIndex = reader.GetOrdinal("FECHA_SALIDA_DEPOSITO");
			int fecha_entrada_depositoColumnIndex = reader.GetOrdinal("FECHA_ENTRADA_DEPOSITO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_SALIDA_DEPOSITO_DETALLESRow record = new ITEMS_SALIDA_DEPOSITO_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(item_salida_deposito_idColumnIndex))
						record.ITEM_SALIDA_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(item_salida_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_entrada_puertoColumnIndex))
						record.FECHA_ENTRADA_PUERTO = Convert.ToDateTime(reader.GetValue(fecha_entrada_puertoColumnIndex));
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(nombre_encargadoColumnIndex))
						record.NOMBRE_ENCARGADO = Convert.ToString(reader.GetValue(nombre_encargadoColumnIndex));
					if(!reader.IsDBNull(statusColumnIndex))
						record.STATUS = Convert.ToString(reader.GetValue(statusColumnIndex));
					if(!reader.IsDBNull(transportadora_persona_idColumnIndex))
						record.TRANSPORTADORA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transportadora_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_camion_idColumnIndex))
						record.TIPO_CAMION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_camion_idColumnIndex)), 9);
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_bulto_idColumnIndex))
						record.TIPO_BULTO_ID = Convert.ToString(reader.GetValue(tipo_bulto_idColumnIndex));
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));
					if(!reader.IsDBNull(fecha_salida_puertoColumnIndex))
						record.FECHA_SALIDA_PUERTO = Convert.ToDateTime(reader.GetValue(fecha_salida_puertoColumnIndex));
					if(!reader.IsDBNull(confirmadoColumnIndex))
						record.CONFIRMADO = Convert.ToString(reader.GetValue(confirmadoColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(fecha_confirmacionColumnIndex))
						record.FECHA_CONFIRMACION = Convert.ToDateTime(reader.GetValue(fecha_confirmacionColumnIndex));
					if(!reader.IsDBNull(precinto_1ColumnIndex))
						record.PRECINTO_1 = Convert.ToString(reader.GetValue(precinto_1ColumnIndex));
					if(!reader.IsDBNull(precinto_2ColumnIndex))
						record.PRECINTO_2 = Convert.ToString(reader.GetValue(precinto_2ColumnIndex));
					if(!reader.IsDBNull(precinto_3ColumnIndex))
						record.PRECINTO_3 = Convert.ToString(reader.GetValue(precinto_3ColumnIndex));
					if(!reader.IsDBNull(precinto_4ColumnIndex))
						record.PRECINTO_4 = Convert.ToString(reader.GetValue(precinto_4ColumnIndex));
					if(!reader.IsDBNull(precinto_5ColumnIndex))
						record.PRECINTO_5 = Convert.ToString(reader.GetValue(precinto_5ColumnIndex));
					if(!reader.IsDBNull(precinto_ventileteColumnIndex))
						record.PRECINTO_VENTILETE = Convert.ToString(reader.GetValue(precinto_ventileteColumnIndex));
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_retiroColumnIndex))
						record.TIPO_RETIRO = Convert.ToString(reader.GetValue(tipo_retiroColumnIndex));
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_salida_depositoColumnIndex))
						record.FECHA_SALIDA_DEPOSITO = Convert.ToDateTime(reader.GetValue(fecha_salida_depositoColumnIndex));
					if(!reader.IsDBNull(fecha_entrada_depositoColumnIndex))
						record.FECHA_ENTRADA_DEPOSITO = Convert.ToDateTime(reader.GetValue(fecha_entrada_depositoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_SALIDA_DEPOSITO_DETALLESRow[])(recordList.ToArray(typeof(ITEMS_SALIDA_DEPOSITO_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_SALIDA_DEPOSITO_DETALLESRow"/> object.</returns>
		protected virtual ITEMS_SALIDA_DEPOSITO_DETALLESRow MapRow(DataRow row)
		{
			ITEMS_SALIDA_DEPOSITO_DETALLESRow mappedObject = new ITEMS_SALIDA_DEPOSITO_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEM_SALIDA_DEPOSITO_ID"
			dataColumn = dataTable.Columns["ITEM_SALIDA_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEM_SALIDA_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "FECHA_ENTRADA_PUERTO"
			dataColumn = dataTable.Columns["FECHA_ENTRADA_PUERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTRADA_PUERTO = (System.DateTime)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "NOMBRE_ENCARGADO"
			dataColumn = dataTable.Columns["NOMBRE_ENCARGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE_ENCARGADO = (string)row[dataColumn];
			// Column "STATUS"
			dataColumn = dataTable.Columns["STATUS"];
			if(!row.IsNull(dataColumn))
				mappedObject.STATUS = (string)row[dataColumn];
			// Column "TRANSPORTADORA_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSPORTADORA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_CAMION_ID"
			dataColumn = dataTable.Columns["TIPO_CAMION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_CAMION_ID = (decimal)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "TIPO_BULTO_ID"
			dataColumn = dataTable.Columns["TIPO_BULTO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_BULTO_ID = (string)row[dataColumn];
			// Column "MERCADERIA"
			dataColumn = dataTable.Columns["MERCADERIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA = (string)row[dataColumn];
			// Column "FECHA_SALIDA_PUERTO"
			dataColumn = dataTable.Columns["FECHA_SALIDA_PUERTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA_PUERTO = (System.DateTime)row[dataColumn];
			// Column "CONFIRMADO"
			dataColumn = dataTable.Columns["CONFIRMADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONFIRMADO = (string)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FECHA_CONFIRMACION"
			dataColumn = dataTable.Columns["FECHA_CONFIRMACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_CONFIRMACION = (System.DateTime)row[dataColumn];
			// Column "PRECINTO_1"
			dataColumn = dataTable.Columns["PRECINTO_1"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_1 = (string)row[dataColumn];
			// Column "PRECINTO_2"
			dataColumn = dataTable.Columns["PRECINTO_2"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_2 = (string)row[dataColumn];
			// Column "PRECINTO_3"
			dataColumn = dataTable.Columns["PRECINTO_3"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_3 = (string)row[dataColumn];
			// Column "PRECINTO_4"
			dataColumn = dataTable.Columns["PRECINTO_4"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_4 = (string)row[dataColumn];
			// Column "PRECINTO_5"
			dataColumn = dataTable.Columns["PRECINTO_5"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_5 = (string)row[dataColumn];
			// Column "PRECINTO_VENTILETE"
			dataColumn = dataTable.Columns["PRECINTO_VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTO_VENTILETE = (string)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "TIPO_RETIRO"
			dataColumn = dataTable.Columns["TIPO_RETIRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_RETIRO = (string)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			// Column "FECHA_SALIDA_DEPOSITO"
			dataColumn = dataTable.Columns["FECHA_SALIDA_DEPOSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_SALIDA_DEPOSITO = (System.DateTime)row[dataColumn];
			// Column "FECHA_ENTRADA_DEPOSITO"
			dataColumn = dataTable.Columns["FECHA_ENTRADA_DEPOSITO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ENTRADA_DEPOSITO = (System.DateTime)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_SALIDA_DEPOSITO_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_SALIDA_DEPOSITO_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ITEM_SALIDA_DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_ENTRADA_PUERTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("NOMBRE_ENCARGADO", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("STATUS", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("TIPO_CAMION_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_BULTO_ID", typeof(string));
			dataColumn.MaxLength = 30;
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA_PUERTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CONFIRMADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("FECHA_CONFIRMACION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("PRECINTO_1", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_2", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_3", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_4", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_5", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PRECINTO_VENTILETE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_RETIRO", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_SALIDA_DEPOSITO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ENTRADA_DEPOSITO", typeof(System.DateTime));
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

				case "ITEM_SALIDA_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_ENTRADA_PUERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "NOMBRE_ENCARGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "STATUS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_CAMION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_BULTO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_SALIDA_PUERTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CONFIRMADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_CONFIRMACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "PRECINTO_1":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_2":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_3":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_4":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_5":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PRECINTO_VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_RETIRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_SALIDA_DEPOSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ENTRADA_DEPOSITO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_SALIDA_DEPOSITO_DETALLESCollection_Base class
}  // End of namespace
