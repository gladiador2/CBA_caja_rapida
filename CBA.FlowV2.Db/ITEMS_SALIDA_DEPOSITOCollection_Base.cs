// <fileinfo name="ITEMS_SALIDA_DEPOSITOCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_SALIDA_DEPOSITOCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_SALIDA_DEPOSITOCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_SALIDA_DEPOSITOCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEMS_INGRESOS_DETALLES_IDColumnName = "ITEMS_INGRESOS_DETALLES_ID";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string NRO_COMPROBANTEColumnName = "NRO_COMPROBANTE";
		public const string FACTURA_PERSONA_IDColumnName = "FACTURA_PERSONA_ID";
		public const string CONSIGNATARIO_PERSONA_IDColumnName = "CONSIGNATARIO_PERSONA_ID";
		public const string DESPACHANTEColumnName = "DESPACHANTE";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string VENCIMIENTOColumnName = "VENCIMIENTO";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string TIPO_BULTOColumnName = "TIPO_BULTO";
		public const string MERCADERIAColumnName = "MERCADERIA";
		public const string DESPACHOColumnName = "DESPACHO";
		public const string GENERACION_CONFIRMADAColumnName = "GENERACION_CONFIRMADA";
		public const string SALIDA_CONFIRMADAColumnName = "SALIDA_CONFIRMADA";
		public const string ES_EXTENSIONColumnName = "ES_EXTENSION";
		public const string ITEM_SALIDA_DEPOSITO_ORIGEN_IDColumnName = "ITEM_SALIDA_DEPOSITO_ORIGEN_ID";
		public const string SEMANAColumnName = "SEMANA";
		public const string RAZON_TEXTOS_PREDEFINIDOS_IDColumnName = "RAZON_TEXTOS_PREDEFINIDOS_ID";
		public const string IMPRESOColumnName = "IMPRESO";
		public const string DESPACHANTE_PERSONA_IDColumnName = "DESPACHANTE_PERSONA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_SALIDA_DEPOSITOCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_SALIDA_DEPOSITOCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_SALIDA_DEPOSITO</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_SALIDA_DEPOSITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_SALIDA_DEPOSITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_SALIDA_DEPOSITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_SALIDA_DEPOSITORow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_SALIDA_DEPOSITORow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITORow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_SALIDA_DEPOSITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ITEMS_SALIDA_DEPOSITORow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ITEMS_SALIDA_DEPOSITORow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ITEMS_SALIDA_DEPOSITORow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITORow[] GetByDESPACHANTE_PERSONA_ID(decimal despachante_persona_id)
		{
			return GetByDESPACHANTE_PERSONA_ID(despachante_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <param name="despachante_persona_idNull">true if the method ignores the despachante_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow[] GetByDESPACHANTE_PERSONA_ID(decimal despachante_persona_id, bool despachante_persona_idNull)
		{
			return MapRecords(CreateGetByDESPACHANTE_PERSONA_IDCommand(despachante_persona_id, despachante_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByDESPACHANTE_PERSONA_IDAsDataTable(decimal despachante_persona_id)
		{
			return GetByDESPACHANTE_PERSONA_IDAsDataTable(despachante_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <param name="despachante_persona_idNull">true if the method ignores the despachante_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByDESPACHANTE_PERSONA_IDAsDataTable(decimal despachante_persona_id, bool despachante_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByDESPACHANTE_PERSONA_IDCommand(despachante_persona_id, despachante_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <param name="despachante_persona_idNull">true if the method ignores the despachante_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByDESPACHANTE_PERSONA_IDCommand(decimal despachante_persona_id, bool despachante_persona_idNull)
		{
			string whereSql = "";
			if(despachante_persona_idNull)
				whereSql += "DESPACHANTE_PERSONA_ID IS NULL";
			else
				whereSql += "DESPACHANTE_PERSONA_ID=" + _db.CreateSqlParameterName("DESPACHANTE_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!despachante_persona_idNull)
				AddParameter(cmd, "DESPACHANTE_PERSONA_ID", despachante_persona_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITORow[] GetByITEMS_INGRESOS_DETALLES_ID(decimal items_ingresos_detalles_id)
		{
			return GetByITEMS_INGRESOS_DETALLES_ID(items_ingresos_detalles_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <param name="items_ingresos_detalles_idNull">true if the method ignores the items_ingresos_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow[] GetByITEMS_INGRESOS_DETALLES_ID(decimal items_ingresos_detalles_id, bool items_ingresos_detalles_idNull)
		{
			return MapRecords(CreateGetByITEMS_INGRESOS_DETALLES_IDCommand(items_ingresos_detalles_id, items_ingresos_detalles_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEMS_INGRESOS_DETALLES_IDAsDataTable(decimal items_ingresos_detalles_id)
		{
			return GetByITEMS_INGRESOS_DETALLES_IDAsDataTable(items_ingresos_detalles_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <param name="items_ingresos_detalles_idNull">true if the method ignores the items_ingresos_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEMS_INGRESOS_DETALLES_IDAsDataTable(decimal items_ingresos_detalles_id, bool items_ingresos_detalles_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEMS_INGRESOS_DETALLES_IDCommand(items_ingresos_detalles_id, items_ingresos_detalles_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <param name="items_ingresos_detalles_idNull">true if the method ignores the items_ingresos_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEMS_INGRESOS_DETALLES_IDCommand(decimal items_ingresos_detalles_id, bool items_ingresos_detalles_idNull)
		{
			string whereSql = "";
			if(items_ingresos_detalles_idNull)
				whereSql += "ITEMS_INGRESOS_DETALLES_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESOS_DETALLES_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESOS_DETALLES_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!items_ingresos_detalles_idNull)
				AddParameter(cmd, "ITEMS_INGRESOS_DETALLES_ID", items_ingresos_detalles_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITORow[] GetByITEM_SALIDA_DEPOSITO_ORIGEN_ID(decimal item_salida_deposito_origen_id)
		{
			return GetByITEM_SALIDA_DEPOSITO_ORIGEN_ID(item_salida_deposito_origen_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <param name="item_salida_deposito_origen_idNull">true if the method ignores the item_salida_deposito_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow[] GetByITEM_SALIDA_DEPOSITO_ORIGEN_ID(decimal item_salida_deposito_origen_id, bool item_salida_deposito_origen_idNull)
		{
			return MapRecords(CreateGetByITEM_SALIDA_DEPOSITO_ORIGEN_IDCommand(item_salida_deposito_origen_id, item_salida_deposito_origen_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEM_SALIDA_DEPOSITO_ORIGEN_IDAsDataTable(decimal item_salida_deposito_origen_id)
		{
			return GetByITEM_SALIDA_DEPOSITO_ORIGEN_IDAsDataTable(item_salida_deposito_origen_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <param name="item_salida_deposito_origen_idNull">true if the method ignores the item_salida_deposito_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEM_SALIDA_DEPOSITO_ORIGEN_IDAsDataTable(decimal item_salida_deposito_origen_id, bool item_salida_deposito_origen_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEM_SALIDA_DEPOSITO_ORIGEN_IDCommand(item_salida_deposito_origen_id, item_salida_deposito_origen_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <param name="item_salida_deposito_origen_idNull">true if the method ignores the item_salida_deposito_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEM_SALIDA_DEPOSITO_ORIGEN_IDCommand(decimal item_salida_deposito_origen_id, bool item_salida_deposito_origen_idNull)
		{
			string whereSql = "";
			if(item_salida_deposito_origen_idNull)
				whereSql += "ITEM_SALIDA_DEPOSITO_ORIGEN_ID IS NULL";
			else
				whereSql += "ITEM_SALIDA_DEPOSITO_ORIGEN_ID=" + _db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ORIGEN_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!item_salida_deposito_origen_idNull)
				AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ORIGEN_ID", item_salida_deposito_origen_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITORow[] GetByRAZON_TEXTOS_PREDEFINIDOS_ID(decimal razon_textos_predefinidos_id)
		{
			return GetByRAZON_TEXTOS_PREDEFINIDOS_ID(razon_textos_predefinidos_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <param name="razon_textos_predefinidos_idNull">true if the method ignores the razon_textos_predefinidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow[] GetByRAZON_TEXTOS_PREDEFINIDOS_ID(decimal razon_textos_predefinidos_id, bool razon_textos_predefinidos_idNull)
		{
			return MapRecords(CreateGetByRAZON_TEXTOS_PREDEFINIDOS_IDCommand(razon_textos_predefinidos_id, razon_textos_predefinidos_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByRAZON_TEXTOS_PREDEFINIDOS_IDAsDataTable(decimal razon_textos_predefinidos_id)
		{
			return GetByRAZON_TEXTOS_PREDEFINIDOS_IDAsDataTable(razon_textos_predefinidos_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <param name="razon_textos_predefinidos_idNull">true if the method ignores the razon_textos_predefinidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByRAZON_TEXTOS_PREDEFINIDOS_IDAsDataTable(decimal razon_textos_predefinidos_id, bool razon_textos_predefinidos_idNull)
		{
			return MapRecordsToDataTable(CreateGetByRAZON_TEXTOS_PREDEFINIDOS_IDCommand(razon_textos_predefinidos_id, razon_textos_predefinidos_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <param name="razon_textos_predefinidos_idNull">true if the method ignores the razon_textos_predefinidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByRAZON_TEXTOS_PREDEFINIDOS_IDCommand(decimal razon_textos_predefinidos_id, bool razon_textos_predefinidos_idNull)
		{
			string whereSql = "";
			if(razon_textos_predefinidos_idNull)
				whereSql += "RAZON_TEXTOS_PREDEFINIDOS_ID IS NULL";
			else
				whereSql += "RAZON_TEXTOS_PREDEFINIDOS_ID=" + _db.CreateSqlParameterName("RAZON_TEXTOS_PREDEFINIDOS_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!razon_textos_predefinidos_idNull)
				AddParameter(cmd, "RAZON_TEXTOS_PREDEFINIDOS_ID", razon_textos_predefinidos_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public ITEMS_SALIDA_DEPOSITORow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects 
		/// by the <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		public virtual ITEMS_SALIDA_DEPOSITORow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			return MapRecords(CreateGetByCONSIGNATARIO_PERSONA_IDCommand(consignatario_persona_id, consignatario_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONSIGNATARIO_PERSONA_IDAsDataTable(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_IDAsDataTable(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONSIGNATARIO_PERSONA_IDAsDataTable(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByCONSIGNATARIO_PERSONA_IDCommand(consignatario_persona_id, consignatario_persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONSIGNATARIO_PERSONA_IDCommand(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			string whereSql = "";
			if(consignatario_persona_idNull)
				whereSql += "CONSIGNATARIO_PERSONA_ID IS NULL";
			else
				whereSql += "CONSIGNATARIO_PERSONA_ID=" + _db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!consignatario_persona_idNull)
				AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID", consignatario_persona_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ITEMS_SALIDA_DEPOSITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_SALIDA_DEPOSITORow"/> object to be inserted.</param>
		public virtual void Insert(ITEMS_SALIDA_DEPOSITORow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ITEMS_SALIDA_DEPOSITO (" +
				"ID, " +
				"ITEMS_INGRESOS_DETALLES_ID, " +
				"FECHA_EMISION, " +
				"NRO_COMPROBANTE, " +
				"FACTURA_PERSONA_ID, " +
				"CONSIGNATARIO_PERSONA_ID, " +
				"DESPACHANTE, " +
				"OBSERVACIONES, " +
				"VENCIMIENTO, " +
				"CANTIDAD, " +
				"TIPO_BULTO, " +
				"MERCADERIA, " +
				"DESPACHO, " +
				"GENERACION_CONFIRMADA, " +
				"SALIDA_CONFIRMADA, " +
				"ES_EXTENSION, " +
				"ITEM_SALIDA_DEPOSITO_ORIGEN_ID, " +
				"SEMANA, " +
				"RAZON_TEXTOS_PREDEFINIDOS_ID, " +
				"IMPRESO, " +
				"DESPACHANTE_PERSONA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ITEMS_INGRESOS_DETALLES_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				_db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				_db.CreateSqlParameterName("FACTURA_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("DESPACHANTE") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("VENCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("TIPO_BULTO") + ", " +
				_db.CreateSqlParameterName("MERCADERIA") + ", " +
				_db.CreateSqlParameterName("DESPACHO") + ", " +
				_db.CreateSqlParameterName("GENERACION_CONFIRMADA") + ", " +
				_db.CreateSqlParameterName("SALIDA_CONFIRMADA") + ", " +
				_db.CreateSqlParameterName("ES_EXTENSION") + ", " +
				_db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ORIGEN_ID") + ", " +
				_db.CreateSqlParameterName("SEMANA") + ", " +
				_db.CreateSqlParameterName("RAZON_TEXTOS_PREDEFINIDOS_ID") + ", " +
				_db.CreateSqlParameterName("IMPRESO") + ", " +
				_db.CreateSqlParameterName("DESPACHANTE_PERSONA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ITEMS_INGRESOS_DETALLES_ID",
				value.IsITEMS_INGRESOS_DETALLES_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESOS_DETALLES_ID);
			AddParameter(cmd, "FECHA_EMISION",
				value.IsFECHA_EMISIONNull ? DBNull.Value : (object)value.FECHA_EMISION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FACTURA_PERSONA_ID",
				value.IsFACTURA_PERSONA_IDNull ? DBNull.Value : (object)value.FACTURA_PERSONA_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			AddParameter(cmd, "DESPACHANTE", value.DESPACHANTE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "VENCIMIENTO",
				value.IsVENCIMIENTONull ? DBNull.Value : (object)value.VENCIMIENTO);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTO", value.TIPO_BULTO);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "GENERACION_CONFIRMADA", value.GENERACION_CONFIRMADA);
			AddParameter(cmd, "SALIDA_CONFIRMADA", value.SALIDA_CONFIRMADA);
			AddParameter(cmd, "ES_EXTENSION", value.ES_EXTENSION);
			AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ORIGEN_ID",
				value.IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull ? DBNull.Value : (object)value.ITEM_SALIDA_DEPOSITO_ORIGEN_ID);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			AddParameter(cmd, "RAZON_TEXTOS_PREDEFINIDOS_ID",
				value.IsRAZON_TEXTOS_PREDEFINIDOS_IDNull ? DBNull.Value : (object)value.RAZON_TEXTOS_PREDEFINIDOS_ID);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "DESPACHANTE_PERSONA_ID",
				value.IsDESPACHANTE_PERSONA_IDNull ? DBNull.Value : (object)value.DESPACHANTE_PERSONA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ITEMS_SALIDA_DEPOSITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_SALIDA_DEPOSITORow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ITEMS_SALIDA_DEPOSITORow value)
		{
			
			string sqlStr = "UPDATE TRC.ITEMS_SALIDA_DEPOSITO SET " +
				"ITEMS_INGRESOS_DETALLES_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESOS_DETALLES_ID") + ", " +
				"FECHA_EMISION=" + _db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				"NRO_COMPROBANTE=" + _db.CreateSqlParameterName("NRO_COMPROBANTE") + ", " +
				"FACTURA_PERSONA_ID=" + _db.CreateSqlParameterName("FACTURA_PERSONA_ID") + ", " +
				"CONSIGNATARIO_PERSONA_ID=" + _db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") + ", " +
				"DESPACHANTE=" + _db.CreateSqlParameterName("DESPACHANTE") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"VENCIMIENTO=" + _db.CreateSqlParameterName("VENCIMIENTO") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"TIPO_BULTO=" + _db.CreateSqlParameterName("TIPO_BULTO") + ", " +
				"MERCADERIA=" + _db.CreateSqlParameterName("MERCADERIA") + ", " +
				"DESPACHO=" + _db.CreateSqlParameterName("DESPACHO") + ", " +
				"GENERACION_CONFIRMADA=" + _db.CreateSqlParameterName("GENERACION_CONFIRMADA") + ", " +
				"SALIDA_CONFIRMADA=" + _db.CreateSqlParameterName("SALIDA_CONFIRMADA") + ", " +
				"ES_EXTENSION=" + _db.CreateSqlParameterName("ES_EXTENSION") + ", " +
				"ITEM_SALIDA_DEPOSITO_ORIGEN_ID=" + _db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ORIGEN_ID") + ", " +
				"SEMANA=" + _db.CreateSqlParameterName("SEMANA") + ", " +
				"RAZON_TEXTOS_PREDEFINIDOS_ID=" + _db.CreateSqlParameterName("RAZON_TEXTOS_PREDEFINIDOS_ID") + ", " +
				"IMPRESO=" + _db.CreateSqlParameterName("IMPRESO") + ", " +
				"DESPACHANTE_PERSONA_ID=" + _db.CreateSqlParameterName("DESPACHANTE_PERSONA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ITEMS_INGRESOS_DETALLES_ID",
				value.IsITEMS_INGRESOS_DETALLES_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESOS_DETALLES_ID);
			AddParameter(cmd, "FECHA_EMISION",
				value.IsFECHA_EMISIONNull ? DBNull.Value : (object)value.FECHA_EMISION);
			AddParameter(cmd, "NRO_COMPROBANTE", value.NRO_COMPROBANTE);
			AddParameter(cmd, "FACTURA_PERSONA_ID",
				value.IsFACTURA_PERSONA_IDNull ? DBNull.Value : (object)value.FACTURA_PERSONA_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			AddParameter(cmd, "DESPACHANTE", value.DESPACHANTE);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "VENCIMIENTO",
				value.IsVENCIMIENTONull ? DBNull.Value : (object)value.VENCIMIENTO);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTO", value.TIPO_BULTO);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "DESPACHO", value.DESPACHO);
			AddParameter(cmd, "GENERACION_CONFIRMADA", value.GENERACION_CONFIRMADA);
			AddParameter(cmd, "SALIDA_CONFIRMADA", value.SALIDA_CONFIRMADA);
			AddParameter(cmd, "ES_EXTENSION", value.ES_EXTENSION);
			AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ORIGEN_ID",
				value.IsITEM_SALIDA_DEPOSITO_ORIGEN_IDNull ? DBNull.Value : (object)value.ITEM_SALIDA_DEPOSITO_ORIGEN_ID);
			AddParameter(cmd, "SEMANA",
				value.IsSEMANANull ? DBNull.Value : (object)value.SEMANA);
			AddParameter(cmd, "RAZON_TEXTOS_PREDEFINIDOS_ID",
				value.IsRAZON_TEXTOS_PREDEFINIDOS_IDNull ? DBNull.Value : (object)value.RAZON_TEXTOS_PREDEFINIDOS_ID);
			AddParameter(cmd, "IMPRESO", value.IMPRESO);
			AddParameter(cmd, "DESPACHANTE_PERSONA_ID",
				value.IsDESPACHANTE_PERSONA_IDNull ? DBNull.Value : (object)value.DESPACHANTE_PERSONA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ITEMS_SALIDA_DEPOSITO</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ITEMS_SALIDA_DEPOSITO</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ITEMS_SALIDA_DEPOSITO</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_SALIDA_DEPOSITORow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ITEMS_SALIDA_DEPOSITORow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ITEMS_SALIDA_DEPOSITO</c> table using
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
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESPACHANTE_PERSONA_ID(decimal despachante_persona_id)
		{
			return DeleteByDESPACHANTE_PERSONA_ID(despachante_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <param name="despachante_persona_idNull">true if the method ignores the despachante_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByDESPACHANTE_PERSONA_ID(decimal despachante_persona_id, bool despachante_persona_idNull)
		{
			return CreateDeleteByDESPACHANTE_PERSONA_IDCommand(despachante_persona_id, despachante_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_SAL_DESP_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="despachante_persona_id">The <c>DESPACHANTE_PERSONA_ID</c> column value.</param>
		/// <param name="despachante_persona_idNull">true if the method ignores the despachante_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByDESPACHANTE_PERSONA_IDCommand(decimal despachante_persona_id, bool despachante_persona_idNull)
		{
			string whereSql = "";
			if(despachante_persona_idNull)
				whereSql += "DESPACHANTE_PERSONA_ID IS NULL";
			else
				whereSql += "DESPACHANTE_PERSONA_ID=" + _db.CreateSqlParameterName("DESPACHANTE_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!despachante_persona_idNull)
				AddParameter(cmd, "DESPACHANTE_PERSONA_ID", despachante_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESOS_DETALLES_ID(decimal items_ingresos_detalles_id)
		{
			return DeleteByITEMS_INGRESOS_DETALLES_ID(items_ingresos_detalles_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <param name="items_ingresos_detalles_idNull">true if the method ignores the items_ingresos_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESOS_DETALLES_ID(decimal items_ingresos_detalles_id, bool items_ingresos_detalles_idNull)
		{
			return CreateDeleteByITEMS_INGRESOS_DETALLES_IDCommand(items_ingresos_detalles_id, items_ingresos_detalles_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_SAL_ITM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingresos_detalles_id">The <c>ITEMS_INGRESOS_DETALLES_ID</c> column value.</param>
		/// <param name="items_ingresos_detalles_idNull">true if the method ignores the items_ingresos_detalles_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEMS_INGRESOS_DETALLES_IDCommand(decimal items_ingresos_detalles_id, bool items_ingresos_detalles_idNull)
		{
			string whereSql = "";
			if(items_ingresos_detalles_idNull)
				whereSql += "ITEMS_INGRESOS_DETALLES_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESOS_DETALLES_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESOS_DETALLES_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!items_ingresos_detalles_idNull)
				AddParameter(cmd, "ITEMS_INGRESOS_DETALLES_ID", items_ingresos_detalles_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEM_SALIDA_DEPOSITO_ORIGEN_ID(decimal item_salida_deposito_origen_id)
		{
			return DeleteByITEM_SALIDA_DEPOSITO_ORIGEN_ID(item_salida_deposito_origen_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <param name="item_salida_deposito_origen_idNull">true if the method ignores the item_salida_deposito_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEM_SALIDA_DEPOSITO_ORIGEN_ID(decimal item_salida_deposito_origen_id, bool item_salida_deposito_origen_idNull)
		{
			return CreateDeleteByITEM_SALIDA_DEPOSITO_ORIGEN_IDCommand(item_salida_deposito_origen_id, item_salida_deposito_origen_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_SAL_ITM_SAL_ID</c> foreign key.
		/// </summary>
		/// <param name="item_salida_deposito_origen_id">The <c>ITEM_SALIDA_DEPOSITO_ORIGEN_ID</c> column value.</param>
		/// <param name="item_salida_deposito_origen_idNull">true if the method ignores the item_salida_deposito_origen_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEM_SALIDA_DEPOSITO_ORIGEN_IDCommand(decimal item_salida_deposito_origen_id, bool item_salida_deposito_origen_idNull)
		{
			string whereSql = "";
			if(item_salida_deposito_origen_idNull)
				whereSql += "ITEM_SALIDA_DEPOSITO_ORIGEN_ID IS NULL";
			else
				whereSql += "ITEM_SALIDA_DEPOSITO_ORIGEN_ID=" + _db.CreateSqlParameterName("ITEM_SALIDA_DEPOSITO_ORIGEN_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!item_salida_deposito_origen_idNull)
				AddParameter(cmd, "ITEM_SALIDA_DEPOSITO_ORIGEN_ID", item_salida_deposito_origen_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRAZON_TEXTOS_PREDEFINIDOS_ID(decimal razon_textos_predefinidos_id)
		{
			return DeleteByRAZON_TEXTOS_PREDEFINIDOS_ID(razon_textos_predefinidos_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <param name="razon_textos_predefinidos_idNull">true if the method ignores the razon_textos_predefinidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByRAZON_TEXTOS_PREDEFINIDOS_ID(decimal razon_textos_predefinidos_id, bool razon_textos_predefinidos_idNull)
		{
			return CreateDeleteByRAZON_TEXTOS_PREDEFINIDOS_IDCommand(razon_textos_predefinidos_id, razon_textos_predefinidos_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_SAL_TXT_PRE_ID</c> foreign key.
		/// </summary>
		/// <param name="razon_textos_predefinidos_id">The <c>RAZON_TEXTOS_PREDEFINIDOS_ID</c> column value.</param>
		/// <param name="razon_textos_predefinidos_idNull">true if the method ignores the razon_textos_predefinidos_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByRAZON_TEXTOS_PREDEFINIDOS_IDCommand(decimal razon_textos_predefinidos_id, bool razon_textos_predefinidos_idNull)
		{
			string whereSql = "";
			if(razon_textos_predefinidos_idNull)
				whereSql += "RAZON_TEXTOS_PREDEFINIDOS_ID IS NULL";
			else
				whereSql += "RAZON_TEXTOS_PREDEFINIDOS_ID=" + _db.CreateSqlParameterName("RAZON_TEXTOS_PREDEFINIDOS_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!razon_textos_predefinidos_idNull)
				AddParameter(cmd, "RAZON_TEXTOS_PREDEFINIDOS_ID", razon_textos_predefinidos_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return DeleteByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_SALIDA_DEPOSITO</c> table using the 
		/// <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			return CreateDeleteByCONSIGNATARIO_PERSONA_IDCommand(consignatario_persona_id, consignatario_persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_SALIDAS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONSIGNATARIO_PERSONA_IDCommand(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			string whereSql = "";
			if(consignatario_persona_idNull)
				whereSql += "CONSIGNATARIO_PERSONA_ID IS NULL";
			else
				whereSql += "CONSIGNATARIO_PERSONA_ID=" + _db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!consignatario_persona_idNull)
				AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID", consignatario_persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ITEMS_SALIDA_DEPOSITO</c> records that match the specified criteria.
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
		/// to delete <c>ITEMS_SALIDA_DEPOSITO</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ITEMS_SALIDA_DEPOSITO";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ITEMS_SALIDA_DEPOSITO</c> table.
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		protected ITEMS_SALIDA_DEPOSITORow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		protected ITEMS_SALIDA_DEPOSITORow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_SALIDA_DEPOSITORow"/> objects.</returns>
		protected virtual ITEMS_SALIDA_DEPOSITORow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int items_ingresos_detalles_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESOS_DETALLES_ID");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int nro_comprobanteColumnIndex = reader.GetOrdinal("NRO_COMPROBANTE");
			int factura_persona_idColumnIndex = reader.GetOrdinal("FACTURA_PERSONA_ID");
			int consignatario_persona_idColumnIndex = reader.GetOrdinal("CONSIGNATARIO_PERSONA_ID");
			int despachanteColumnIndex = reader.GetOrdinal("DESPACHANTE");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int vencimientoColumnIndex = reader.GetOrdinal("VENCIMIENTO");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int tipo_bultoColumnIndex = reader.GetOrdinal("TIPO_BULTO");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");
			int despachoColumnIndex = reader.GetOrdinal("DESPACHO");
			int generacion_confirmadaColumnIndex = reader.GetOrdinal("GENERACION_CONFIRMADA");
			int salida_confirmadaColumnIndex = reader.GetOrdinal("SALIDA_CONFIRMADA");
			int es_extensionColumnIndex = reader.GetOrdinal("ES_EXTENSION");
			int item_salida_deposito_origen_idColumnIndex = reader.GetOrdinal("ITEM_SALIDA_DEPOSITO_ORIGEN_ID");
			int semanaColumnIndex = reader.GetOrdinal("SEMANA");
			int razon_textos_predefinidos_idColumnIndex = reader.GetOrdinal("RAZON_TEXTOS_PREDEFINIDOS_ID");
			int impresoColumnIndex = reader.GetOrdinal("IMPRESO");
			int despachante_persona_idColumnIndex = reader.GetOrdinal("DESPACHANTE_PERSONA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_SALIDA_DEPOSITORow record = new ITEMS_SALIDA_DEPOSITORow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingresos_detalles_idColumnIndex))
						record.ITEMS_INGRESOS_DETALLES_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingresos_detalles_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_emisionColumnIndex))
						record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(nro_comprobanteColumnIndex))
						record.NRO_COMPROBANTE = Convert.ToString(reader.GetValue(nro_comprobanteColumnIndex));
					if(!reader.IsDBNull(factura_persona_idColumnIndex))
						record.FACTURA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(factura_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_persona_idColumnIndex))
						record.CONSIGNATARIO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(consignatario_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(despachanteColumnIndex))
						record.DESPACHANTE = Convert.ToString(reader.GetValue(despachanteColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(vencimientoColumnIndex))
						record.VENCIMIENTO = Convert.ToDateTime(reader.GetValue(vencimientoColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_bultoColumnIndex))
						record.TIPO_BULTO = Convert.ToString(reader.GetValue(tipo_bultoColumnIndex));
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));
					if(!reader.IsDBNull(despachoColumnIndex))
						record.DESPACHO = Convert.ToString(reader.GetValue(despachoColumnIndex));
					if(!reader.IsDBNull(generacion_confirmadaColumnIndex))
						record.GENERACION_CONFIRMADA = Convert.ToString(reader.GetValue(generacion_confirmadaColumnIndex));
					if(!reader.IsDBNull(salida_confirmadaColumnIndex))
						record.SALIDA_CONFIRMADA = Convert.ToString(reader.GetValue(salida_confirmadaColumnIndex));
					if(!reader.IsDBNull(es_extensionColumnIndex))
						record.ES_EXTENSION = Convert.ToString(reader.GetValue(es_extensionColumnIndex));
					if(!reader.IsDBNull(item_salida_deposito_origen_idColumnIndex))
						record.ITEM_SALIDA_DEPOSITO_ORIGEN_ID = Math.Round(Convert.ToDecimal(reader.GetValue(item_salida_deposito_origen_idColumnIndex)), 9);
					if(!reader.IsDBNull(semanaColumnIndex))
						record.SEMANA = Math.Round(Convert.ToDecimal(reader.GetValue(semanaColumnIndex)), 9);
					if(!reader.IsDBNull(razon_textos_predefinidos_idColumnIndex))
						record.RAZON_TEXTOS_PREDEFINIDOS_ID = Math.Round(Convert.ToDecimal(reader.GetValue(razon_textos_predefinidos_idColumnIndex)), 9);
					if(!reader.IsDBNull(impresoColumnIndex))
						record.IMPRESO = Convert.ToString(reader.GetValue(impresoColumnIndex));
					if(!reader.IsDBNull(despachante_persona_idColumnIndex))
						record.DESPACHANTE_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(despachante_persona_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_SALIDA_DEPOSITORow[])(recordList.ToArray(typeof(ITEMS_SALIDA_DEPOSITORow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_SALIDA_DEPOSITORow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_SALIDA_DEPOSITORow"/> object.</returns>
		protected virtual ITEMS_SALIDA_DEPOSITORow MapRow(DataRow row)
		{
			ITEMS_SALIDA_DEPOSITORow mappedObject = new ITEMS_SALIDA_DEPOSITORow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESOS_DETALLES_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESOS_DETALLES_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESOS_DETALLES_ID = (decimal)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "NRO_COMPROBANTE"
			dataColumn = dataTable.Columns["NRO_COMPROBANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_COMPROBANTE = (string)row[dataColumn];
			// Column "FACTURA_PERSONA_ID"
			dataColumn = dataTable.Columns["FACTURA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.FACTURA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_PERSONA_ID"
			dataColumn = dataTable.Columns["CONSIGNATARIO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "DESPACHANTE"
			dataColumn = dataTable.Columns["DESPACHANTE"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHANTE = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "VENCIMIENTO"
			dataColumn = dataTable.Columns["VENCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENCIMIENTO = (System.DateTime)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "TIPO_BULTO"
			dataColumn = dataTable.Columns["TIPO_BULTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_BULTO = (string)row[dataColumn];
			// Column "MERCADERIA"
			dataColumn = dataTable.Columns["MERCADERIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA = (string)row[dataColumn];
			// Column "DESPACHO"
			dataColumn = dataTable.Columns["DESPACHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHO = (string)row[dataColumn];
			// Column "GENERACION_CONFIRMADA"
			dataColumn = dataTable.Columns["GENERACION_CONFIRMADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.GENERACION_CONFIRMADA = (string)row[dataColumn];
			// Column "SALIDA_CONFIRMADA"
			dataColumn = dataTable.Columns["SALIDA_CONFIRMADA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SALIDA_CONFIRMADA = (string)row[dataColumn];
			// Column "ES_EXTENSION"
			dataColumn = dataTable.Columns["ES_EXTENSION"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_EXTENSION = (string)row[dataColumn];
			// Column "ITEM_SALIDA_DEPOSITO_ORIGEN_ID"
			dataColumn = dataTable.Columns["ITEM_SALIDA_DEPOSITO_ORIGEN_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEM_SALIDA_DEPOSITO_ORIGEN_ID = (decimal)row[dataColumn];
			// Column "SEMANA"
			dataColumn = dataTable.Columns["SEMANA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SEMANA = (decimal)row[dataColumn];
			// Column "RAZON_TEXTOS_PREDEFINIDOS_ID"
			dataColumn = dataTable.Columns["RAZON_TEXTOS_PREDEFINIDOS_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.RAZON_TEXTOS_PREDEFINIDOS_ID = (decimal)row[dataColumn];
			// Column "IMPRESO"
			dataColumn = dataTable.Columns["IMPRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.IMPRESO = (string)row[dataColumn];
			// Column "DESPACHANTE_PERSONA_ID"
			dataColumn = dataTable.Columns["DESPACHANTE_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESPACHANTE_PERSONA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_SALIDA_DEPOSITO</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_SALIDA_DEPOSITO";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESOS_DETALLES_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_COMPROBANTE", typeof(string));
			dataColumn.MaxLength = 15;
			dataColumn = dataTable.Columns.Add("FACTURA_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESPACHANTE", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("VENCIMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_BULTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
			dataColumn.MaxLength = 250;
			dataColumn = dataTable.Columns.Add("DESPACHO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn = dataTable.Columns.Add("GENERACION_CONFIRMADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("SALIDA_CONFIRMADA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ES_EXTENSION", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ITEM_SALIDA_DEPOSITO_ORIGEN_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SEMANA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("RAZON_TEXTOS_PREDEFINIDOS_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("IMPRESO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("DESPACHANTE_PERSONA_ID", typeof(decimal));
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

				case "ITEMS_INGRESOS_DETALLES_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_COMPROBANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FACTURA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESPACHANTE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_BULTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "DESPACHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "GENERACION_CONFIRMADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "SALIDA_CONFIRMADA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ES_EXTENSION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ITEM_SALIDA_DEPOSITO_ORIGEN_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "SEMANA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "RAZON_TEXTOS_PREDEFINIDOS_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "IMPRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "DESPACHANTE_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_SALIDA_DEPOSITOCollection_Base class
}  // End of namespace
