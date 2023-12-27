// <fileinfo name="ITEMS_INGRESOS_DETALLESCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESOS_DETALLESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_INGRESOS_DETALLESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESOS_DETALLESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEMS_INGRESO_IDColumnName = "ITEMS_INGRESO_ID";
		public const string CONSIGNATARIO_PERSONA_IDColumnName = "CONSIGNATARIO_PERSONA_ID";
		public const string CONSIGNATARIO_NOMBREColumnName = "CONSIGNATARIO_NOMBRE";
		public const string CONOCIMIENTOColumnName = "CONOCIMIENTO";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string TIPO_BULTOColumnName = "TIPO_BULTO";
		public const string MERCADERIAColumnName = "MERCADERIA";
		public const string VALOR_NETOColumnName = "VALOR_NETO";
		public const string VALOR_MONEDA_IDColumnName = "VALOR_MONEDA_ID";
		public const string ES_VEHICULOColumnName = "ES_VEHICULO";
		public const string ESTADO_VEHICULOColumnName = "ESTADO_VEHICULO";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string ITEMS_INGRESO_DEPOSITO_DET_IDColumnName = "ITEMS_INGRESO_DEPOSITO_DET_ID";
		public const string ITEMS_INGRESO_DETALLE_ORI_IDColumnName = "ITEMS_INGRESO_DETALLE_ORI_ID";
		public const string DESCONSOLIDADOColumnName = "DESCONSOLIDADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESOS_DETALLESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_INGRESOS_DETALLESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_INGRESOS_DETALLES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_INGRESOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_INGRESOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_INGRESOS_DETALLESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_INGRESOS_DETALLESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public ITEMS_INGRESOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_INGRESOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ITEMS_INGRESOS_DETALLESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESOS_DETALLESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ITEMS_INGRESOS_DETALLESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public ITEMS_INGRESOS_DETALLESRow[] GetByITEMS_INGRESO_DETALLE_ORI_ID(decimal items_ingreso_detalle_ori_id)
		{
			return GetByITEMS_INGRESO_DETALLE_ORI_ID(items_ingreso_detalle_ori_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <param name="items_ingreso_detalle_ori_idNull">true if the method ignores the items_ingreso_detalle_ori_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow[] GetByITEMS_INGRESO_DETALLE_ORI_ID(decimal items_ingreso_detalle_ori_id, bool items_ingreso_detalle_ori_idNull)
		{
			return MapRecords(CreateGetByITEMS_INGRESO_DETALLE_ORI_IDCommand(items_ingreso_detalle_ori_id, items_ingreso_detalle_ori_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEMS_INGRESO_DETALLE_ORI_IDAsDataTable(decimal items_ingreso_detalle_ori_id)
		{
			return GetByITEMS_INGRESO_DETALLE_ORI_IDAsDataTable(items_ingreso_detalle_ori_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <param name="items_ingreso_detalle_ori_idNull">true if the method ignores the items_ingreso_detalle_ori_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEMS_INGRESO_DETALLE_ORI_IDAsDataTable(decimal items_ingreso_detalle_ori_id, bool items_ingreso_detalle_ori_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEMS_INGRESO_DETALLE_ORI_IDCommand(items_ingreso_detalle_ori_id, items_ingreso_detalle_ori_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <param name="items_ingreso_detalle_ori_idNull">true if the method ignores the items_ingreso_detalle_ori_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEMS_INGRESO_DETALLE_ORI_IDCommand(decimal items_ingreso_detalle_ori_id, bool items_ingreso_detalle_ori_idNull)
		{
			string whereSql = "";
			if(items_ingreso_detalle_ori_idNull)
				whereSql += "ITEMS_INGRESO_DETALLE_ORI_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_DETALLE_ORI_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ORI_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!items_ingreso_detalle_ori_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ORI_ID", items_ingreso_detalle_ori_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public ITEMS_INGRESOS_DETALLESRow[] GetByITEMS_INGRESO_DEPOSITO_DET_ID(decimal items_ingreso_deposito_det_id)
		{
			return GetByITEMS_INGRESO_DEPOSITO_DET_ID(items_ingreso_deposito_det_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_det_idNull">true if the method ignores the items_ingreso_deposito_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow[] GetByITEMS_INGRESO_DEPOSITO_DET_ID(decimal items_ingreso_deposito_det_id, bool items_ingreso_deposito_det_idNull)
		{
			return MapRecords(CreateGetByITEMS_INGRESO_DEPOSITO_DET_IDCommand(items_ingreso_deposito_det_id, items_ingreso_deposito_det_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEMS_INGRESO_DEPOSITO_DET_IDAsDataTable(decimal items_ingreso_deposito_det_id)
		{
			return GetByITEMS_INGRESO_DEPOSITO_DET_IDAsDataTable(items_ingreso_deposito_det_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_det_idNull">true if the method ignores the items_ingreso_deposito_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEMS_INGRESO_DEPOSITO_DET_IDAsDataTable(decimal items_ingreso_deposito_det_id, bool items_ingreso_deposito_det_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEMS_INGRESO_DEPOSITO_DET_IDCommand(items_ingreso_deposito_det_id, items_ingreso_deposito_det_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_det_idNull">true if the method ignores the items_ingreso_deposito_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEMS_INGRESO_DEPOSITO_DET_IDCommand(decimal items_ingreso_deposito_det_id, bool items_ingreso_deposito_det_idNull)
		{
			string whereSql = "";
			if(items_ingreso_deposito_det_idNull)
				whereSql += "ITEMS_INGRESO_DEPOSITO_DET_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_DEPOSITO_DET_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_DET_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!items_ingreso_deposito_det_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_DET_ID", items_ingreso_deposito_det_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public ITEMS_INGRESOS_DETALLESRow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			return MapRecords(CreateGetByCONSIGNATARIO_PERSONA_IDCommand(consignatario_persona_id, consignatario_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONSIGNATARIO_PERSONA_IDAsDataTable(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_IDAsDataTable(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
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
		/// return records by the <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
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
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public ITEMS_INGRESOS_DETALLESRow[] GetByITEMS_INGRESO_ID(decimal items_ingreso_id)
		{
			return GetByITEMS_INGRESO_ID(items_ingreso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow[] GetByITEMS_INGRESO_ID(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			return MapRecords(CreateGetByITEMS_INGRESO_IDCommand(items_ingreso_id, items_ingreso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEMS_INGRESO_IDAsDataTable(decimal items_ingreso_id)
		{
			return GetByITEMS_INGRESO_IDAsDataTable(items_ingreso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEMS_INGRESO_IDAsDataTable(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEMS_INGRESO_IDCommand(items_ingreso_id, items_ingreso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEMS_INGRESO_IDCommand(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			string whereSql = "";
			if(items_ingreso_idNull)
				whereSql += "ITEMS_INGRESO_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!items_ingreso_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_ID", items_ingreso_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public ITEMS_INGRESOS_DETALLESRow[] GetByVALOR_MONEDA_ID(decimal valor_moneda_id)
		{
			return GetByVALOR_MONEDA_ID(valor_moneda_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects 
		/// by the <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		public virtual ITEMS_INGRESOS_DETALLESRow[] GetByVALOR_MONEDA_ID(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			return MapRecords(CreateGetByVALOR_MONEDA_IDCommand(valor_moneda_id, valor_moneda_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByVALOR_MONEDA_IDAsDataTable(decimal valor_moneda_id)
		{
			return GetByVALOR_MONEDA_IDAsDataTable(valor_moneda_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByVALOR_MONEDA_IDAsDataTable(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			return MapRecordsToDataTable(CreateGetByVALOR_MONEDA_IDCommand(valor_moneda_id, valor_moneda_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByVALOR_MONEDA_IDCommand(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			string whereSql = "";
			if(valor_moneda_idNull)
				whereSql += "VALOR_MONEDA_ID IS NULL";
			else
				whereSql += "VALOR_MONEDA_ID=" + _db.CreateSqlParameterName("VALOR_MONEDA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!valor_moneda_idNull)
				AddParameter(cmd, "VALOR_MONEDA_ID", valor_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ITEMS_INGRESOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESOS_DETALLESRow"/> object to be inserted.</param>
		public virtual void Insert(ITEMS_INGRESOS_DETALLESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ITEMS_INGRESOS_DETALLES (" +
				"ID, " +
				"ITEMS_INGRESO_ID, " +
				"CONSIGNATARIO_PERSONA_ID, " +
				"CONSIGNATARIO_NOMBRE, " +
				"CONOCIMIENTO, " +
				"CANTIDAD, " +
				"TIPO_BULTO, " +
				"MERCADERIA, " +
				"VALOR_NETO, " +
				"VALOR_MONEDA_ID, " +
				"ES_VEHICULO, " +
				"ESTADO_VEHICULO, " +
				"OBSERVACIONES, " +
				"ITEMS_INGRESO_DEPOSITO_DET_ID, " +
				"ITEMS_INGRESO_DETALLE_ORI_ID, " +
				"DESCONSOLIDADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ITEMS_INGRESO_ID") + ", " +
				_db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CONSIGNATARIO_NOMBRE") + ", " +
				_db.CreateSqlParameterName("CONOCIMIENTO") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("TIPO_BULTO") + ", " +
				_db.CreateSqlParameterName("MERCADERIA") + ", " +
				_db.CreateSqlParameterName("VALOR_NETO") + ", " +
				_db.CreateSqlParameterName("VALOR_MONEDA_ID") + ", " +
				_db.CreateSqlParameterName("ES_VEHICULO") + ", " +
				_db.CreateSqlParameterName("ESTADO_VEHICULO") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_DET_ID") + ", " +
				_db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ORI_ID") + ", " +
				_db.CreateSqlParameterName("DESCONSOLIDADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ITEMS_INGRESO_ID",
				value.IsITEMS_INGRESO_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			AddParameter(cmd, "CONSIGNATARIO_NOMBRE", value.CONSIGNATARIO_NOMBRE);
			AddParameter(cmd, "CONOCIMIENTO", value.CONOCIMIENTO);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTO", value.TIPO_BULTO);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "VALOR_NETO",
				value.IsVALOR_NETONull ? DBNull.Value : (object)value.VALOR_NETO);
			AddParameter(cmd, "VALOR_MONEDA_ID",
				value.IsVALOR_MONEDA_IDNull ? DBNull.Value : (object)value.VALOR_MONEDA_ID);
			AddParameter(cmd, "ES_VEHICULO", value.ES_VEHICULO);
			AddParameter(cmd, "ESTADO_VEHICULO", value.ESTADO_VEHICULO);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_DET_ID",
				value.IsITEMS_INGRESO_DEPOSITO_DET_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_DEPOSITO_DET_ID);
			AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ORI_ID",
				value.IsITEMS_INGRESO_DETALLE_ORI_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_DETALLE_ORI_ID);
			AddParameter(cmd, "DESCONSOLIDADO", value.DESCONSOLIDADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ITEMS_INGRESOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESOS_DETALLESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ITEMS_INGRESOS_DETALLESRow value)
		{
			
			string sqlStr = "UPDATE TRC.ITEMS_INGRESOS_DETALLES SET " +
				"ITEMS_INGRESO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_ID") + ", " +
				"CONSIGNATARIO_PERSONA_ID=" + _db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") + ", " +
				"CONSIGNATARIO_NOMBRE=" + _db.CreateSqlParameterName("CONSIGNATARIO_NOMBRE") + ", " +
				"CONOCIMIENTO=" + _db.CreateSqlParameterName("CONOCIMIENTO") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"TIPO_BULTO=" + _db.CreateSqlParameterName("TIPO_BULTO") + ", " +
				"MERCADERIA=" + _db.CreateSqlParameterName("MERCADERIA") + ", " +
				"VALOR_NETO=" + _db.CreateSqlParameterName("VALOR_NETO") + ", " +
				"VALOR_MONEDA_ID=" + _db.CreateSqlParameterName("VALOR_MONEDA_ID") + ", " +
				"ES_VEHICULO=" + _db.CreateSqlParameterName("ES_VEHICULO") + ", " +
				"ESTADO_VEHICULO=" + _db.CreateSqlParameterName("ESTADO_VEHICULO") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"ITEMS_INGRESO_DEPOSITO_DET_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_DET_ID") + ", " +
				"ITEMS_INGRESO_DETALLE_ORI_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ORI_ID") + ", " +
				"DESCONSOLIDADO=" + _db.CreateSqlParameterName("DESCONSOLIDADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ITEMS_INGRESO_ID",
				value.IsITEMS_INGRESO_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			AddParameter(cmd, "CONSIGNATARIO_NOMBRE", value.CONSIGNATARIO_NOMBRE);
			AddParameter(cmd, "CONOCIMIENTO", value.CONOCIMIENTO);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTO", value.TIPO_BULTO);
			AddParameter(cmd, "MERCADERIA", value.MERCADERIA);
			AddParameter(cmd, "VALOR_NETO",
				value.IsVALOR_NETONull ? DBNull.Value : (object)value.VALOR_NETO);
			AddParameter(cmd, "VALOR_MONEDA_ID",
				value.IsVALOR_MONEDA_IDNull ? DBNull.Value : (object)value.VALOR_MONEDA_ID);
			AddParameter(cmd, "ES_VEHICULO", value.ES_VEHICULO);
			AddParameter(cmd, "ESTADO_VEHICULO", value.ESTADO_VEHICULO);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_DET_ID",
				value.IsITEMS_INGRESO_DEPOSITO_DET_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_DEPOSITO_DET_ID);
			AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ORI_ID",
				value.IsITEMS_INGRESO_DETALLE_ORI_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_DETALLE_ORI_ID);
			AddParameter(cmd, "DESCONSOLIDADO", value.DESCONSOLIDADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESOS_DETALLES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESOS_DETALLES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ITEMS_INGRESOS_DETALLES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESOS_DETALLESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ITEMS_INGRESOS_DETALLESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ITEMS_INGRESOS_DETALLES</c> table using
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
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_DETALLE_ORI_ID(decimal items_ingreso_detalle_ori_id)
		{
			return DeleteByITEMS_INGRESO_DETALLE_ORI_ID(items_ingreso_detalle_ori_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <param name="items_ingreso_detalle_ori_idNull">true if the method ignores the items_ingreso_detalle_ori_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_DETALLE_ORI_ID(decimal items_ingreso_detalle_ori_id, bool items_ingreso_detalle_ori_idNull)
		{
			return CreateDeleteByITEMS_INGRESO_DETALLE_ORI_IDCommand(items_ingreso_detalle_ori_id, items_ingreso_detalle_ori_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEM_INGR_ITEM_ING_D_OR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_ori_id">The <c>ITEMS_INGRESO_DETALLE_ORI_ID</c> column value.</param>
		/// <param name="items_ingreso_detalle_ori_idNull">true if the method ignores the items_ingreso_detalle_ori_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEMS_INGRESO_DETALLE_ORI_IDCommand(decimal items_ingreso_detalle_ori_id, bool items_ingreso_detalle_ori_idNull)
		{
			string whereSql = "";
			if(items_ingreso_detalle_ori_idNull)
				whereSql += "ITEMS_INGRESO_DETALLE_ORI_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_DETALLE_ORI_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ORI_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!items_ingreso_detalle_ori_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ORI_ID", items_ingreso_detalle_ori_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_DEPOSITO_DET_ID(decimal items_ingreso_deposito_det_id)
		{
			return DeleteByITEMS_INGRESO_DEPOSITO_DET_ID(items_ingreso_deposito_det_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_det_idNull">true if the method ignores the items_ingreso_deposito_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_DEPOSITO_DET_ID(decimal items_ingreso_deposito_det_id, bool items_ingreso_deposito_det_idNull)
		{
			return CreateDeleteByITEMS_INGRESO_DEPOSITO_DET_IDCommand(items_ingreso_deposito_det_id, items_ingreso_deposito_det_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_INGRE_ITEM_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_det_id">The <c>ITEMS_INGRESO_DEPOSITO_DET_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_det_idNull">true if the method ignores the items_ingreso_deposito_det_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEMS_INGRESO_DEPOSITO_DET_IDCommand(decimal items_ingreso_deposito_det_id, bool items_ingreso_deposito_det_idNull)
		{
			string whereSql = "";
			if(items_ingreso_deposito_det_idNull)
				whereSql += "ITEMS_INGRESO_DEPOSITO_DET_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_DEPOSITO_DET_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_DET_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!items_ingreso_deposito_det_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_DET_ID", items_ingreso_deposito_det_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return DeleteByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
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
		/// delete records using the <c>FK_ITEMS_INGRESOS_CON_PER_ID</c> foreign key.
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
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_ID(decimal items_ingreso_id)
		{
			return DeleteByITEMS_INGRESO_ID(items_ingreso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_ID(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			return CreateDeleteByITEMS_INGRESO_IDCommand(items_ingreso_id, items_ingreso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_INGRESOS_ITEM_INGR_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_id">The <c>ITEMS_INGRESO_ID</c> column value.</param>
		/// <param name="items_ingreso_idNull">true if the method ignores the items_ingreso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEMS_INGRESO_IDCommand(decimal items_ingreso_id, bool items_ingreso_idNull)
		{
			string whereSql = "";
			if(items_ingreso_idNull)
				whereSql += "ITEMS_INGRESO_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!items_ingreso_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_ID", items_ingreso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVALOR_MONEDA_ID(decimal valor_moneda_id)
		{
			return DeleteByVALOR_MONEDA_ID(valor_moneda_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESOS_DETALLES</c> table using the 
		/// <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByVALOR_MONEDA_ID(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			return CreateDeleteByVALOR_MONEDA_IDCommand(valor_moneda_id, valor_moneda_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEMS_INGRESOS_VAL_MON_ID</c> foreign key.
		/// </summary>
		/// <param name="valor_moneda_id">The <c>VALOR_MONEDA_ID</c> column value.</param>
		/// <param name="valor_moneda_idNull">true if the method ignores the valor_moneda_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByVALOR_MONEDA_IDCommand(decimal valor_moneda_id, bool valor_moneda_idNull)
		{
			string whereSql = "";
			if(valor_moneda_idNull)
				whereSql += "VALOR_MONEDA_ID IS NULL";
			else
				whereSql += "VALOR_MONEDA_ID=" + _db.CreateSqlParameterName("VALOR_MONEDA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!valor_moneda_idNull)
				AddParameter(cmd, "VALOR_MONEDA_ID", valor_moneda_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ITEMS_INGRESOS_DETALLES</c> records that match the specified criteria.
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
		/// to delete <c>ITEMS_INGRESOS_DETALLES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ITEMS_INGRESOS_DETALLES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ITEMS_INGRESOS_DETALLES</c> table.
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		protected ITEMS_INGRESOS_DETALLESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		protected ITEMS_INGRESOS_DETALLESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_INGRESOS_DETALLESRow"/> objects.</returns>
		protected virtual ITEMS_INGRESOS_DETALLESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int items_ingreso_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_ID");
			int consignatario_persona_idColumnIndex = reader.GetOrdinal("CONSIGNATARIO_PERSONA_ID");
			int consignatario_nombreColumnIndex = reader.GetOrdinal("CONSIGNATARIO_NOMBRE");
			int conocimientoColumnIndex = reader.GetOrdinal("CONOCIMIENTO");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int tipo_bultoColumnIndex = reader.GetOrdinal("TIPO_BULTO");
			int mercaderiaColumnIndex = reader.GetOrdinal("MERCADERIA");
			int valor_netoColumnIndex = reader.GetOrdinal("VALOR_NETO");
			int valor_moneda_idColumnIndex = reader.GetOrdinal("VALOR_MONEDA_ID");
			int es_vehiculoColumnIndex = reader.GetOrdinal("ES_VEHICULO");
			int estado_vehiculoColumnIndex = reader.GetOrdinal("ESTADO_VEHICULO");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int items_ingreso_deposito_det_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_DEPOSITO_DET_ID");
			int items_ingreso_detalle_ori_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_DETALLE_ORI_ID");
			int desconsolidadoColumnIndex = reader.GetOrdinal("DESCONSOLIDADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_INGRESOS_DETALLESRow record = new ITEMS_INGRESOS_DETALLESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingreso_idColumnIndex))
						record.ITEMS_INGRESO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_persona_idColumnIndex))
						record.CONSIGNATARIO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(consignatario_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_nombreColumnIndex))
						record.CONSIGNATARIO_NOMBRE = Convert.ToString(reader.GetValue(consignatario_nombreColumnIndex));
					if(!reader.IsDBNull(conocimientoColumnIndex))
						record.CONOCIMIENTO = Convert.ToString(reader.GetValue(conocimientoColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_bultoColumnIndex))
						record.TIPO_BULTO = Convert.ToString(reader.GetValue(tipo_bultoColumnIndex));
					if(!reader.IsDBNull(mercaderiaColumnIndex))
						record.MERCADERIA = Convert.ToString(reader.GetValue(mercaderiaColumnIndex));
					if(!reader.IsDBNull(valor_netoColumnIndex))
						record.VALOR_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(valor_netoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_moneda_idColumnIndex))
						record.VALOR_MONEDA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(valor_moneda_idColumnIndex)), 9);
					if(!reader.IsDBNull(es_vehiculoColumnIndex))
						record.ES_VEHICULO = Convert.ToString(reader.GetValue(es_vehiculoColumnIndex));
					if(!reader.IsDBNull(estado_vehiculoColumnIndex))
						record.ESTADO_VEHICULO = Convert.ToString(reader.GetValue(estado_vehiculoColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(items_ingreso_deposito_det_idColumnIndex))
						record.ITEMS_INGRESO_DEPOSITO_DET_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_deposito_det_idColumnIndex)), 9);
					if(!reader.IsDBNull(items_ingreso_detalle_ori_idColumnIndex))
						record.ITEMS_INGRESO_DETALLE_ORI_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_detalle_ori_idColumnIndex)), 9);
					if(!reader.IsDBNull(desconsolidadoColumnIndex))
						record.DESCONSOLIDADO = Convert.ToString(reader.GetValue(desconsolidadoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_INGRESOS_DETALLESRow[])(recordList.ToArray(typeof(ITEMS_INGRESOS_DETALLESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_INGRESOS_DETALLESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_INGRESOS_DETALLESRow"/> object.</returns>
		protected virtual ITEMS_INGRESOS_DETALLESRow MapRow(DataRow row)
		{
			ITEMS_INGRESOS_DETALLESRow mappedObject = new ITEMS_INGRESOS_DETALLESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESO_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_PERSONA_ID"
			dataColumn = dataTable.Columns["CONSIGNATARIO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_NOMBRE"
			dataColumn = dataTable.Columns["CONSIGNATARIO_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_NOMBRE = (string)row[dataColumn];
			// Column "CONOCIMIENTO"
			dataColumn = dataTable.Columns["CONOCIMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONOCIMIENTO = (string)row[dataColumn];
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
			// Column "VALOR_NETO"
			dataColumn = dataTable.Columns["VALOR_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_NETO = (decimal)row[dataColumn];
			// Column "VALOR_MONEDA_ID"
			dataColumn = dataTable.Columns["VALOR_MONEDA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_MONEDA_ID = (decimal)row[dataColumn];
			// Column "ES_VEHICULO"
			dataColumn = dataTable.Columns["ES_VEHICULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ES_VEHICULO = (string)row[dataColumn];
			// Column "ESTADO_VEHICULO"
			dataColumn = dataTable.Columns["ESTADO_VEHICULO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO_VEHICULO = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "ITEMS_INGRESO_DEPOSITO_DET_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_DEPOSITO_DET_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_DEPOSITO_DET_ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESO_DETALLE_ORI_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_DETALLE_ORI_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_DETALLE_ORI_ID = (decimal)row[dataColumn];
			// Column "DESCONSOLIDADO"
			dataColumn = dataTable.Columns["DESCONSOLIDADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.DESCONSOLIDADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_INGRESOS_DETALLES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_INGRESOS_DETALLES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_NOMBRE", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("CONOCIMIENTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_BULTO", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn = dataTable.Columns.Add("MERCADERIA", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn = dataTable.Columns.Add("VALOR_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_MONEDA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ES_VEHICULO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO_VEHICULO", typeof(string));
			dataColumn.MaxLength = 12;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_DEPOSITO_DET_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_DETALLE_ORI_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DESCONSOLIDADO", typeof(string));
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

				case "ITEMS_INGRESO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONOCIMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "VALOR_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_MONEDA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ES_VEHICULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO_VEHICULO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ITEMS_INGRESO_DEPOSITO_DET_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ITEMS_INGRESO_DETALLE_ORI_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DESCONSOLIDADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_INGRESOS_DETALLESCollection_Base class
}  // End of namespace
