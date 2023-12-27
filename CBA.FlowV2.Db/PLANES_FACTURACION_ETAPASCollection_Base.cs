// <fileinfo name="PLANES_FACTURACION_ETAPASCollection_Base.cs">
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
	/// The base class for <see cref="PLANES_FACTURACION_ETAPASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="PLANES_FACTURACION_ETAPASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANES_FACTURACION_ETAPASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string PLAN_FACTURACION_IDColumnName = "PLAN_FACTURACION_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string FECHA_ESTIMADA_INICIOColumnName = "FECHA_ESTIMADA_INICIO";
		public const string FECHA_ESTIMADA_FINColumnName = "FECHA_ESTIMADA_FIN";
		public const string FECHA_FACTURACION_DESDEColumnName = "FECHA_FACTURACION_DESDE";
		public const string FECHA_FACTURACION_HASTAColumnName = "FECHA_FACTURACION_HASTA";
		public const string ULTIMA_FC_CREADA_FECHAColumnName = "ULTIMA_FC_CREADA_FECHA";
		public const string ULTIMA_FC_CREADA_CASO_IDColumnName = "ULTIMA_FC_CREADA_CASO_ID";
		public const string ORDENColumnName = "ORDEN";
		public const string TIPO_INTERVALOColumnName = "TIPO_INTERVALO";
		public const string INTERVALOColumnName = "INTERVALO";
		public const string CONDICION_PAGO_IDColumnName = "CONDICION_PAGO_ID";
		public const string LISTA_PRECIO_IDColumnName = "LISTA_PRECIO_ID";
		public const string MORA_PORCENTAJEColumnName = "MORA_PORCENTAJE";
		public const string MORA_DIAS_GRACIAColumnName = "MORA_DIAS_GRACIA";
		public const string PROXIMA_FECHAColumnName = "PROXIMA_FECHA";
		public const string AUTONUMERACION_FACTURA_IDColumnName = "AUTONUMERACION_FACTURA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANES_FACTURACION_ETAPASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public PLANES_FACTURACION_ETAPASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>PLANES_FACTURACION_ETAPAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>PLANES_FACTURACION_ETAPAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>PLANES_FACTURACION_ETAPAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="PLANES_FACTURACION_ETAPASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="PLANES_FACTURACION_ETAPASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public PLANES_FACTURACION_ETAPASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			PLANES_FACTURACION_ETAPASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public PLANES_FACTURACION_ETAPASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects that 
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.PLANES_FACTURACION_ETAPAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="PLANES_FACTURACION_ETAPASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="PLANES_FACTURACION_ETAPASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			PLANES_FACTURACION_ETAPASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public PLANES_FACTURACION_ETAPASRow[] GetByAUTONUMERACION_FACTURA_ID(decimal autonumeracion_factura_id)
		{
			return GetByAUTONUMERACION_FACTURA_ID(autonumeracion_factura_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <param name="autonumeracion_factura_idNull">true if the method ignores the autonumeracion_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow[] GetByAUTONUMERACION_FACTURA_ID(decimal autonumeracion_factura_id, bool autonumeracion_factura_idNull)
		{
			return MapRecords(CreateGetByAUTONUMERACION_FACTURA_IDCommand(autonumeracion_factura_id, autonumeracion_factura_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByAUTONUMERACION_FACTURA_IDAsDataTable(decimal autonumeracion_factura_id)
		{
			return GetByAUTONUMERACION_FACTURA_IDAsDataTable(autonumeracion_factura_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <param name="autonumeracion_factura_idNull">true if the method ignores the autonumeracion_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByAUTONUMERACION_FACTURA_IDAsDataTable(decimal autonumeracion_factura_id, bool autonumeracion_factura_idNull)
		{
			return MapRecordsToDataTable(CreateGetByAUTONUMERACION_FACTURA_IDCommand(autonumeracion_factura_id, autonumeracion_factura_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <param name="autonumeracion_factura_idNull">true if the method ignores the autonumeracion_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByAUTONUMERACION_FACTURA_IDCommand(decimal autonumeracion_factura_id, bool autonumeracion_factura_idNull)
		{
			string whereSql = "";
			if(autonumeracion_factura_idNull)
				whereSql += "AUTONUMERACION_FACTURA_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_FACTURA_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_FACTURA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!autonumeracion_factura_idNull)
				AddParameter(cmd, "AUTONUMERACION_FACTURA_ID", autonumeracion_factura_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_COND</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow[] GetByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return MapRecords(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_COND</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByCONDICION_PAGO_IDAsDataTable(decimal condicion_pago_id)
		{
			return MapRecordsToDataTable(CreateGetByCONDICION_PAGO_IDCommand(condicion_pago_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANES_FACTURACION_ET_COND</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByCONDICION_PAGO_IDCommand(decimal condicion_pago_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public PLANES_FACTURACION_ETAPASRow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <param name="lista_precio_idNull">true if the method ignores the lista_precio_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow[] GetByLISTA_PRECIO_ID(decimal lista_precio_id, bool lista_precio_idNull)
		{
			return MapRecords(CreateGetByLISTA_PRECIO_IDCommand(lista_precio_id, lista_precio_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLISTA_PRECIO_IDAsDataTable(decimal lista_precio_id)
		{
			return GetByLISTA_PRECIO_IDAsDataTable(lista_precio_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
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
		/// return records by the <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
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
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_id">The <c>PLAN_FACTURACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow[] GetByPLAN_FACTURACION_ID(decimal plan_facturacion_id)
		{
			return MapRecords(CreateGetByPLAN_FACTURACION_IDCommand(plan_facturacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_id">The <c>PLAN_FACTURACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPLAN_FACTURACION_IDAsDataTable(decimal plan_facturacion_id)
		{
			return MapRecordsToDataTable(CreateGetByPLAN_FACTURACION_IDCommand(plan_facturacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANES_FACTURACION_ET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_id">The <c>PLAN_FACTURACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPLAN_FACTURACION_IDCommand(decimal plan_facturacion_id)
		{
			string whereSql = "";
			whereSql += "PLAN_FACTURACION_ID=" + _db.CreateSqlParameterName("PLAN_FACTURACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "PLAN_FACTURACION_ID", plan_facturacion_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public PLANES_FACTURACION_ETAPASRow[] GetByULTIMA_FC_CREADA_CASO_ID(decimal ultima_fc_creada_caso_id)
		{
			return GetByULTIMA_FC_CREADA_CASO_ID(ultima_fc_creada_caso_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects 
		/// by the <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <param name="ultima_fc_creada_caso_idNull">true if the method ignores the ultima_fc_creada_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		public virtual PLANES_FACTURACION_ETAPASRow[] GetByULTIMA_FC_CREADA_CASO_ID(decimal ultima_fc_creada_caso_id, bool ultima_fc_creada_caso_idNull)
		{
			return MapRecords(CreateGetByULTIMA_FC_CREADA_CASO_IDCommand(ultima_fc_creada_caso_id, ultima_fc_creada_caso_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByULTIMA_FC_CREADA_CASO_IDAsDataTable(decimal ultima_fc_creada_caso_id)
		{
			return GetByULTIMA_FC_CREADA_CASO_IDAsDataTable(ultima_fc_creada_caso_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <param name="ultima_fc_creada_caso_idNull">true if the method ignores the ultima_fc_creada_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByULTIMA_FC_CREADA_CASO_IDAsDataTable(decimal ultima_fc_creada_caso_id, bool ultima_fc_creada_caso_idNull)
		{
			return MapRecordsToDataTable(CreateGetByULTIMA_FC_CREADA_CASO_IDCommand(ultima_fc_creada_caso_id, ultima_fc_creada_caso_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <param name="ultima_fc_creada_caso_idNull">true if the method ignores the ultima_fc_creada_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByULTIMA_FC_CREADA_CASO_IDCommand(decimal ultima_fc_creada_caso_id, bool ultima_fc_creada_caso_idNull)
		{
			string whereSql = "";
			if(ultima_fc_creada_caso_idNull)
				whereSql += "ULTIMA_FC_CREADA_CASO_ID IS NULL";
			else
				whereSql += "ULTIMA_FC_CREADA_CASO_ID=" + _db.CreateSqlParameterName("ULTIMA_FC_CREADA_CASO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!ultima_fc_creada_caso_idNull)
				AddParameter(cmd, "ULTIMA_FC_CREADA_CASO_ID", ultima_fc_creada_caso_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>PLANES_FACTURACION_ETAPAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANES_FACTURACION_ETAPASRow"/> object to be inserted.</param>
		public virtual void Insert(PLANES_FACTURACION_ETAPASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.PLANES_FACTURACION_ETAPAS (" +
				"ID, " +
				"PLAN_FACTURACION_ID, " +
				"NOMBRE, " +
				"FECHA_ESTIMADA_INICIO, " +
				"FECHA_ESTIMADA_FIN, " +
				"FECHA_FACTURACION_DESDE, " +
				"FECHA_FACTURACION_HASTA, " +
				"ULTIMA_FC_CREADA_FECHA, " +
				"ULTIMA_FC_CREADA_CASO_ID, " +
				"ORDEN, " +
				"TIPO_INTERVALO, " +
				"INTERVALO, " +
				"CONDICION_PAGO_ID, " +
				"LISTA_PRECIO_ID, " +
				"MORA_PORCENTAJE, " +
				"MORA_DIAS_GRACIA, " +
				"PROXIMA_FECHA, " +
				"AUTONUMERACION_FACTURA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("PLAN_FACTURACION_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("FECHA_ESTIMADA_INICIO") + ", " +
				_db.CreateSqlParameterName("FECHA_ESTIMADA_FIN") + ", " +
				_db.CreateSqlParameterName("FECHA_FACTURACION_DESDE") + ", " +
				_db.CreateSqlParameterName("FECHA_FACTURACION_HASTA") + ", " +
				_db.CreateSqlParameterName("ULTIMA_FC_CREADA_FECHA") + ", " +
				_db.CreateSqlParameterName("ULTIMA_FC_CREADA_CASO_ID") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("TIPO_INTERVALO") + ", " +
				_db.CreateSqlParameterName("INTERVALO") + ", " +
				_db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				_db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				_db.CreateSqlParameterName("MORA_PORCENTAJE") + ", " +
				_db.CreateSqlParameterName("MORA_DIAS_GRACIA") + ", " +
				_db.CreateSqlParameterName("PROXIMA_FECHA") + ", " +
				_db.CreateSqlParameterName("AUTONUMERACION_FACTURA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "PLAN_FACTURACION_ID", value.PLAN_FACTURACION_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "FECHA_ESTIMADA_INICIO",
				value.IsFECHA_ESTIMADA_INICIONull ? DBNull.Value : (object)value.FECHA_ESTIMADA_INICIO);
			AddParameter(cmd, "FECHA_ESTIMADA_FIN",
				value.IsFECHA_ESTIMADA_FINNull ? DBNull.Value : (object)value.FECHA_ESTIMADA_FIN);
			AddParameter(cmd, "FECHA_FACTURACION_DESDE",
				value.IsFECHA_FACTURACION_DESDENull ? DBNull.Value : (object)value.FECHA_FACTURACION_DESDE);
			AddParameter(cmd, "FECHA_FACTURACION_HASTA",
				value.IsFECHA_FACTURACION_HASTANull ? DBNull.Value : (object)value.FECHA_FACTURACION_HASTA);
			AddParameter(cmd, "ULTIMA_FC_CREADA_FECHA",
				value.IsULTIMA_FC_CREADA_FECHANull ? DBNull.Value : (object)value.ULTIMA_FC_CREADA_FECHA);
			AddParameter(cmd, "ULTIMA_FC_CREADA_CASO_ID",
				value.IsULTIMA_FC_CREADA_CASO_IDNull ? DBNull.Value : (object)value.ULTIMA_FC_CREADA_CASO_ID);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "TIPO_INTERVALO", value.TIPO_INTERVALO);
			AddParameter(cmd, "INTERVALO", value.INTERVALO);
			AddParameter(cmd, "CONDICION_PAGO_ID", value.CONDICION_PAGO_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "MORA_PORCENTAJE", value.MORA_PORCENTAJE);
			AddParameter(cmd, "MORA_DIAS_GRACIA", value.MORA_DIAS_GRACIA);
			AddParameter(cmd, "PROXIMA_FECHA",
				value.IsPROXIMA_FECHANull ? DBNull.Value : (object)value.PROXIMA_FECHA);
			AddParameter(cmd, "AUTONUMERACION_FACTURA_ID",
				value.IsAUTONUMERACION_FACTURA_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_FACTURA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>PLANES_FACTURACION_ETAPAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANES_FACTURACION_ETAPASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(PLANES_FACTURACION_ETAPASRow value)
		{
			
			string sqlStr = "UPDATE TRC.PLANES_FACTURACION_ETAPAS SET " +
				"PLAN_FACTURACION_ID=" + _db.CreateSqlParameterName("PLAN_FACTURACION_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"FECHA_ESTIMADA_INICIO=" + _db.CreateSqlParameterName("FECHA_ESTIMADA_INICIO") + ", " +
				"FECHA_ESTIMADA_FIN=" + _db.CreateSqlParameterName("FECHA_ESTIMADA_FIN") + ", " +
				"FECHA_FACTURACION_DESDE=" + _db.CreateSqlParameterName("FECHA_FACTURACION_DESDE") + ", " +
				"FECHA_FACTURACION_HASTA=" + _db.CreateSqlParameterName("FECHA_FACTURACION_HASTA") + ", " +
				"ULTIMA_FC_CREADA_FECHA=" + _db.CreateSqlParameterName("ULTIMA_FC_CREADA_FECHA") + ", " +
				"ULTIMA_FC_CREADA_CASO_ID=" + _db.CreateSqlParameterName("ULTIMA_FC_CREADA_CASO_ID") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"TIPO_INTERVALO=" + _db.CreateSqlParameterName("TIPO_INTERVALO") + ", " +
				"INTERVALO=" + _db.CreateSqlParameterName("INTERVALO") + ", " +
				"CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID") + ", " +
				"LISTA_PRECIO_ID=" + _db.CreateSqlParameterName("LISTA_PRECIO_ID") + ", " +
				"MORA_PORCENTAJE=" + _db.CreateSqlParameterName("MORA_PORCENTAJE") + ", " +
				"MORA_DIAS_GRACIA=" + _db.CreateSqlParameterName("MORA_DIAS_GRACIA") + ", " +
				"PROXIMA_FECHA=" + _db.CreateSqlParameterName("PROXIMA_FECHA") + ", " +
				"AUTONUMERACION_FACTURA_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_FACTURA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "PLAN_FACTURACION_ID", value.PLAN_FACTURACION_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "FECHA_ESTIMADA_INICIO",
				value.IsFECHA_ESTIMADA_INICIONull ? DBNull.Value : (object)value.FECHA_ESTIMADA_INICIO);
			AddParameter(cmd, "FECHA_ESTIMADA_FIN",
				value.IsFECHA_ESTIMADA_FINNull ? DBNull.Value : (object)value.FECHA_ESTIMADA_FIN);
			AddParameter(cmd, "FECHA_FACTURACION_DESDE",
				value.IsFECHA_FACTURACION_DESDENull ? DBNull.Value : (object)value.FECHA_FACTURACION_DESDE);
			AddParameter(cmd, "FECHA_FACTURACION_HASTA",
				value.IsFECHA_FACTURACION_HASTANull ? DBNull.Value : (object)value.FECHA_FACTURACION_HASTA);
			AddParameter(cmd, "ULTIMA_FC_CREADA_FECHA",
				value.IsULTIMA_FC_CREADA_FECHANull ? DBNull.Value : (object)value.ULTIMA_FC_CREADA_FECHA);
			AddParameter(cmd, "ULTIMA_FC_CREADA_CASO_ID",
				value.IsULTIMA_FC_CREADA_CASO_IDNull ? DBNull.Value : (object)value.ULTIMA_FC_CREADA_CASO_ID);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "TIPO_INTERVALO", value.TIPO_INTERVALO);
			AddParameter(cmd, "INTERVALO", value.INTERVALO);
			AddParameter(cmd, "CONDICION_PAGO_ID", value.CONDICION_PAGO_ID);
			AddParameter(cmd, "LISTA_PRECIO_ID",
				value.IsLISTA_PRECIO_IDNull ? DBNull.Value : (object)value.LISTA_PRECIO_ID);
			AddParameter(cmd, "MORA_PORCENTAJE", value.MORA_PORCENTAJE);
			AddParameter(cmd, "MORA_DIAS_GRACIA", value.MORA_DIAS_GRACIA);
			AddParameter(cmd, "PROXIMA_FECHA",
				value.IsPROXIMA_FECHANull ? DBNull.Value : (object)value.PROXIMA_FECHA);
			AddParameter(cmd, "AUTONUMERACION_FACTURA_ID",
				value.IsAUTONUMERACION_FACTURA_IDNull ? DBNull.Value : (object)value.AUTONUMERACION_FACTURA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>PLANES_FACTURACION_ETAPAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>PLANES_FACTURACION_ETAPAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>PLANES_FACTURACION_ETAPAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="PLANES_FACTURACION_ETAPASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(PLANES_FACTURACION_ETAPASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>PLANES_FACTURACION_ETAPAS</c> table using
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
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_FACTURA_ID(decimal autonumeracion_factura_id)
		{
			return DeleteByAUTONUMERACION_FACTURA_ID(autonumeracion_factura_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <param name="autonumeracion_factura_idNull">true if the method ignores the autonumeracion_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByAUTONUMERACION_FACTURA_ID(decimal autonumeracion_factura_id, bool autonumeracion_factura_idNull)
		{
			return CreateDeleteByAUTONUMERACION_FACTURA_IDCommand(autonumeracion_factura_id, autonumeracion_factura_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANES_FACTURACION_ET_AUTON</c> foreign key.
		/// </summary>
		/// <param name="autonumeracion_factura_id">The <c>AUTONUMERACION_FACTURA_ID</c> column value.</param>
		/// <param name="autonumeracion_factura_idNull">true if the method ignores the autonumeracion_factura_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByAUTONUMERACION_FACTURA_IDCommand(decimal autonumeracion_factura_id, bool autonumeracion_factura_idNull)
		{
			string whereSql = "";
			if(autonumeracion_factura_idNull)
				whereSql += "AUTONUMERACION_FACTURA_ID IS NULL";
			else
				whereSql += "AUTONUMERACION_FACTURA_ID=" + _db.CreateSqlParameterName("AUTONUMERACION_FACTURA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!autonumeracion_factura_idNull)
				AddParameter(cmd, "AUTONUMERACION_FACTURA_ID", autonumeracion_factura_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_COND</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONDICION_PAGO_ID(decimal condicion_pago_id)
		{
			return CreateDeleteByCONDICION_PAGO_IDCommand(condicion_pago_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANES_FACTURACION_ET_COND</c> foreign key.
		/// </summary>
		/// <param name="condicion_pago_id">The <c>CONDICION_PAGO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByCONDICION_PAGO_IDCommand(decimal condicion_pago_id)
		{
			string whereSql = "";
			whereSql += "CONDICION_PAGO_ID=" + _db.CreateSqlParameterName("CONDICION_PAGO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "CONDICION_PAGO_ID", condicion_pago_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
		/// </summary>
		/// <param name="lista_precio_id">The <c>LISTA_PRECIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLISTA_PRECIO_ID(decimal lista_precio_id)
		{
			return DeleteByLISTA_PRECIO_ID(lista_precio_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
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
		/// delete records using the <c>FK_PLANES_FACTURACION_ET_LISTA</c> foreign key.
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
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_id">The <c>PLAN_FACTURACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPLAN_FACTURACION_ID(decimal plan_facturacion_id)
		{
			return CreateDeleteByPLAN_FACTURACION_IDCommand(plan_facturacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANES_FACTURACION_ET_PLAN</c> foreign key.
		/// </summary>
		/// <param name="plan_facturacion_id">The <c>PLAN_FACTURACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPLAN_FACTURACION_IDCommand(decimal plan_facturacion_id)
		{
			string whereSql = "";
			whereSql += "PLAN_FACTURACION_ID=" + _db.CreateSqlParameterName("PLAN_FACTURACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "PLAN_FACTURACION_ID", plan_facturacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByULTIMA_FC_CREADA_CASO_ID(decimal ultima_fc_creada_caso_id)
		{
			return DeleteByULTIMA_FC_CREADA_CASO_ID(ultima_fc_creada_caso_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>PLANES_FACTURACION_ETAPAS</c> table using the 
		/// <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <param name="ultima_fc_creada_caso_idNull">true if the method ignores the ultima_fc_creada_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByULTIMA_FC_CREADA_CASO_ID(decimal ultima_fc_creada_caso_id, bool ultima_fc_creada_caso_idNull)
		{
			return CreateDeleteByULTIMA_FC_CREADA_CASO_IDCommand(ultima_fc_creada_caso_id, ultima_fc_creada_caso_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_PLANES_FACTURACION_ET_ULT_C</c> foreign key.
		/// </summary>
		/// <param name="ultima_fc_creada_caso_id">The <c>ULTIMA_FC_CREADA_CASO_ID</c> column value.</param>
		/// <param name="ultima_fc_creada_caso_idNull">true if the method ignores the ultima_fc_creada_caso_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByULTIMA_FC_CREADA_CASO_IDCommand(decimal ultima_fc_creada_caso_id, bool ultima_fc_creada_caso_idNull)
		{
			string whereSql = "";
			if(ultima_fc_creada_caso_idNull)
				whereSql += "ULTIMA_FC_CREADA_CASO_ID IS NULL";
			else
				whereSql += "ULTIMA_FC_CREADA_CASO_ID=" + _db.CreateSqlParameterName("ULTIMA_FC_CREADA_CASO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!ultima_fc_creada_caso_idNull)
				AddParameter(cmd, "ULTIMA_FC_CREADA_CASO_ID", ultima_fc_creada_caso_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>PLANES_FACTURACION_ETAPAS</c> records that match the specified criteria.
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
		/// to delete <c>PLANES_FACTURACION_ETAPAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.PLANES_FACTURACION_ETAPAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>PLANES_FACTURACION_ETAPAS</c> table.
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		protected PLANES_FACTURACION_ETAPASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		protected PLANES_FACTURACION_ETAPASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="PLANES_FACTURACION_ETAPASRow"/> objects.</returns>
		protected virtual PLANES_FACTURACION_ETAPASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int plan_facturacion_idColumnIndex = reader.GetOrdinal("PLAN_FACTURACION_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int fecha_estimada_inicioColumnIndex = reader.GetOrdinal("FECHA_ESTIMADA_INICIO");
			int fecha_estimada_finColumnIndex = reader.GetOrdinal("FECHA_ESTIMADA_FIN");
			int fecha_facturacion_desdeColumnIndex = reader.GetOrdinal("FECHA_FACTURACION_DESDE");
			int fecha_facturacion_hastaColumnIndex = reader.GetOrdinal("FECHA_FACTURACION_HASTA");
			int ultima_fc_creada_fechaColumnIndex = reader.GetOrdinal("ULTIMA_FC_CREADA_FECHA");
			int ultima_fc_creada_caso_idColumnIndex = reader.GetOrdinal("ULTIMA_FC_CREADA_CASO_ID");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int tipo_intervaloColumnIndex = reader.GetOrdinal("TIPO_INTERVALO");
			int intervaloColumnIndex = reader.GetOrdinal("INTERVALO");
			int condicion_pago_idColumnIndex = reader.GetOrdinal("CONDICION_PAGO_ID");
			int lista_precio_idColumnIndex = reader.GetOrdinal("LISTA_PRECIO_ID");
			int mora_porcentajeColumnIndex = reader.GetOrdinal("MORA_PORCENTAJE");
			int mora_dias_graciaColumnIndex = reader.GetOrdinal("MORA_DIAS_GRACIA");
			int proxima_fechaColumnIndex = reader.GetOrdinal("PROXIMA_FECHA");
			int autonumeracion_factura_idColumnIndex = reader.GetOrdinal("AUTONUMERACION_FACTURA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					PLANES_FACTURACION_ETAPASRow record = new PLANES_FACTURACION_ETAPASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.PLAN_FACTURACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(plan_facturacion_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					if(!reader.IsDBNull(fecha_estimada_inicioColumnIndex))
						record.FECHA_ESTIMADA_INICIO = Convert.ToDateTime(reader.GetValue(fecha_estimada_inicioColumnIndex));
					if(!reader.IsDBNull(fecha_estimada_finColumnIndex))
						record.FECHA_ESTIMADA_FIN = Convert.ToDateTime(reader.GetValue(fecha_estimada_finColumnIndex));
					if(!reader.IsDBNull(fecha_facturacion_desdeColumnIndex))
						record.FECHA_FACTURACION_DESDE = Convert.ToDateTime(reader.GetValue(fecha_facturacion_desdeColumnIndex));
					if(!reader.IsDBNull(fecha_facturacion_hastaColumnIndex))
						record.FECHA_FACTURACION_HASTA = Convert.ToDateTime(reader.GetValue(fecha_facturacion_hastaColumnIndex));
					if(!reader.IsDBNull(ultima_fc_creada_fechaColumnIndex))
						record.ULTIMA_FC_CREADA_FECHA = Convert.ToDateTime(reader.GetValue(ultima_fc_creada_fechaColumnIndex));
					if(!reader.IsDBNull(ultima_fc_creada_caso_idColumnIndex))
						record.ULTIMA_FC_CREADA_CASO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(ultima_fc_creada_caso_idColumnIndex)), 9);
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					record.TIPO_INTERVALO = Convert.ToString(reader.GetValue(tipo_intervaloColumnIndex));
					record.INTERVALO = Math.Round(Convert.ToDecimal(reader.GetValue(intervaloColumnIndex)), 9);
					record.CONDICION_PAGO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(condicion_pago_idColumnIndex)), 9);
					if(!reader.IsDBNull(lista_precio_idColumnIndex))
						record.LISTA_PRECIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(lista_precio_idColumnIndex)), 9);
					record.MORA_PORCENTAJE = Math.Round(Convert.ToDecimal(reader.GetValue(mora_porcentajeColumnIndex)), 9);
					record.MORA_DIAS_GRACIA = Math.Round(Convert.ToDecimal(reader.GetValue(mora_dias_graciaColumnIndex)), 9);
					if(!reader.IsDBNull(proxima_fechaColumnIndex))
						record.PROXIMA_FECHA = Convert.ToDateTime(reader.GetValue(proxima_fechaColumnIndex));
					if(!reader.IsDBNull(autonumeracion_factura_idColumnIndex))
						record.AUTONUMERACION_FACTURA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(autonumeracion_factura_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (PLANES_FACTURACION_ETAPASRow[])(recordList.ToArray(typeof(PLANES_FACTURACION_ETAPASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="PLANES_FACTURACION_ETAPASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="PLANES_FACTURACION_ETAPASRow"/> object.</returns>
		protected virtual PLANES_FACTURACION_ETAPASRow MapRow(DataRow row)
		{
			PLANES_FACTURACION_ETAPASRow mappedObject = new PLANES_FACTURACION_ETAPASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "PLAN_FACTURACION_ID"
			dataColumn = dataTable.Columns["PLAN_FACTURACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PLAN_FACTURACION_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "FECHA_ESTIMADA_INICIO"
			dataColumn = dataTable.Columns["FECHA_ESTIMADA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ESTIMADA_INICIO = (System.DateTime)row[dataColumn];
			// Column "FECHA_ESTIMADA_FIN"
			dataColumn = dataTable.Columns["FECHA_ESTIMADA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_ESTIMADA_FIN = (System.DateTime)row[dataColumn];
			// Column "FECHA_FACTURACION_DESDE"
			dataColumn = dataTable.Columns["FECHA_FACTURACION_DESDE"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FACTURACION_DESDE = (System.DateTime)row[dataColumn];
			// Column "FECHA_FACTURACION_HASTA"
			dataColumn = dataTable.Columns["FECHA_FACTURACION_HASTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_FACTURACION_HASTA = (System.DateTime)row[dataColumn];
			// Column "ULTIMA_FC_CREADA_FECHA"
			dataColumn = dataTable.Columns["ULTIMA_FC_CREADA_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.ULTIMA_FC_CREADA_FECHA = (System.DateTime)row[dataColumn];
			// Column "ULTIMA_FC_CREADA_CASO_ID"
			dataColumn = dataTable.Columns["ULTIMA_FC_CREADA_CASO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ULTIMA_FC_CREADA_CASO_ID = (decimal)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "TIPO_INTERVALO"
			dataColumn = dataTable.Columns["TIPO_INTERVALO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_INTERVALO = (string)row[dataColumn];
			// Column "INTERVALO"
			dataColumn = dataTable.Columns["INTERVALO"];
			if(!row.IsNull(dataColumn))
				mappedObject.INTERVALO = (decimal)row[dataColumn];
			// Column "CONDICION_PAGO_ID"
			dataColumn = dataTable.Columns["CONDICION_PAGO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONDICION_PAGO_ID = (decimal)row[dataColumn];
			// Column "LISTA_PRECIO_ID"
			dataColumn = dataTable.Columns["LISTA_PRECIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LISTA_PRECIO_ID = (decimal)row[dataColumn];
			// Column "MORA_PORCENTAJE"
			dataColumn = dataTable.Columns["MORA_PORCENTAJE"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_PORCENTAJE = (decimal)row[dataColumn];
			// Column "MORA_DIAS_GRACIA"
			dataColumn = dataTable.Columns["MORA_DIAS_GRACIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MORA_DIAS_GRACIA = (decimal)row[dataColumn];
			// Column "PROXIMA_FECHA"
			dataColumn = dataTable.Columns["PROXIMA_FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROXIMA_FECHA = (System.DateTime)row[dataColumn];
			// Column "AUTONUMERACION_FACTURA_ID"
			dataColumn = dataTable.Columns["AUTONUMERACION_FACTURA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.AUTONUMERACION_FACTURA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>PLANES_FACTURACION_ETAPAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "PLANES_FACTURACION_ETAPAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PLAN_FACTURACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_ESTIMADA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_ESTIMADA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FACTURACION_DESDE", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_FACTURACION_HASTA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ULTIMA_FC_CREADA_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ULTIMA_FC_CREADA_CASO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_INTERVALO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("INTERVALO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONDICION_PAGO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("LISTA_PRECIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MORA_PORCENTAJE", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MORA_DIAS_GRACIA", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PROXIMA_FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("AUTONUMERACION_FACTURA_ID", typeof(decimal));
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

				case "PLAN_FACTURACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA_ESTIMADA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_ESTIMADA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FACTURACION_DESDE":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_FACTURACION_HASTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ULTIMA_FC_CREADA_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ULTIMA_FC_CREADA_CASO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_INTERVALO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "INTERVALO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONDICION_PAGO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LISTA_PRECIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MORA_PORCENTAJE":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MORA_DIAS_GRACIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PROXIMA_FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "AUTONUMERACION_FACTURA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of PLANES_FACTURACION_ETAPASCollection_Base class
}  // End of namespace
