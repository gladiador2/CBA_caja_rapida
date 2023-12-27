// <fileinfo name="ITEMS_INGRESO_DEPOSITO_DETCollection_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESO_DEPOSITO_DETCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="ITEMS_INGRESO_DEPOSITO_DETCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESO_DEPOSITO_DETCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string ITEMS_INGRESO_DETALLE_IDColumnName = "ITEMS_INGRESO_DETALLE_ID";
		public const string FECHA_INGRESOColumnName = "FECHA_INGRESO";
		public const string UBICACIONColumnName = "UBICACION";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string TIPO_BULTOSColumnName = "TIPO_BULTOS";
		public const string MERCADERIASColumnName = "MERCADERIAS";
		public const string LARGOColumnName = "LARGO";
		public const string ANCHOColumnName = "ANCHO";
		public const string ALTOColumnName = "ALTO";
		public const string ESTIBADORESColumnName = "ESTIBADORES";
		public const string ESTIBADORES_FACTURADOSColumnName = "ESTIBADORES_FACTURADOS";
		public const string MONTACARGASColumnName = "MONTACARGAS";
		public const string MONTACARGAS_FACTURADOSColumnName = "MONTACARGAS_FACTURADOS";
		public const string PRECINTOSColumnName = "PRECINTOS";
		public const string OBSERVACIONESColumnName = "OBSERVACIONES";
		public const string USO_BASCULAColumnName = "USO_BASCULA";
		public const string USO_BASCULA_FACTURADOColumnName = "USO_BASCULA_FACTURADO";
		public const string USO_GRUAColumnName = "USO_GRUA";
		public const string USO_GRUA_FACTURADOColumnName = "USO_GRUA_FACTURADO";
		public const string TOTAL_ESPACIOColumnName = "TOTAL_ESPACIO";
		public const string FECHA_EMISIONColumnName = "FECHA_EMISION";
		public const string ITEMS_INGRESO_DEPOSITO_IDColumnName = "ITEMS_INGRESO_DEPOSITO_ID";
		public const string CONSIGNATARIO_PERSONA_IDColumnName = "CONSIGNATARIO_PERSONA_ID";
		public const string PESOColumnName = "PESO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESO_DEPOSITO_DETCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public ITEMS_INGRESO_DEPOSITO_DETCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
		/// </summary>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITO_DETRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public ITEMS_INGRESO_DEPOSITO_DETRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			ITEMS_INGRESO_DEPOSITO_DETRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public ITEMS_INGRESO_DEPOSITO_DETRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects that 
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITO_DETRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.ITEMS_INGRESO_DEPOSITO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual ITEMS_INGRESO_DEPOSITO_DETRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			ITEMS_INGRESO_DEPOSITO_DETRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects 
		/// by the <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public ITEMS_INGRESO_DEPOSITO_DETRow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects 
		/// by the <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITO_DETRow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			return MapRecords(CreateGetByCONSIGNATARIO_PERSONA_IDCommand(consignatario_persona_id, consignatario_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONSIGNATARIO_PERSONA_IDAsDataTable(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_IDAsDataTable(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
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
		/// return records by the <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
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
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects 
		/// by the <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public ITEMS_INGRESO_DEPOSITO_DETRow[] GetByITEMS_INGRESO_DEPOSITO_ID(decimal items_ingreso_deposito_id)
		{
			return GetByITEMS_INGRESO_DEPOSITO_ID(items_ingreso_deposito_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects 
		/// by the <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_idNull">true if the method ignores the items_ingreso_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITO_DETRow[] GetByITEMS_INGRESO_DEPOSITO_ID(decimal items_ingreso_deposito_id, bool items_ingreso_deposito_idNull)
		{
			return MapRecords(CreateGetByITEMS_INGRESO_DEPOSITO_IDCommand(items_ingreso_deposito_id, items_ingreso_deposito_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByITEMS_INGRESO_DEPOSITO_IDAsDataTable(decimal items_ingreso_deposito_id)
		{
			return GetByITEMS_INGRESO_DEPOSITO_IDAsDataTable(items_ingreso_deposito_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_idNull">true if the method ignores the items_ingreso_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEMS_INGRESO_DEPOSITO_IDAsDataTable(decimal items_ingreso_deposito_id, bool items_ingreso_deposito_idNull)
		{
			return MapRecordsToDataTable(CreateGetByITEMS_INGRESO_DEPOSITO_IDCommand(items_ingreso_deposito_id, items_ingreso_deposito_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_idNull">true if the method ignores the items_ingreso_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEMS_INGRESO_DEPOSITO_IDCommand(decimal items_ingreso_deposito_id, bool items_ingreso_deposito_idNull)
		{
			string whereSql = "";
			if(items_ingreso_deposito_idNull)
				whereSql += "ITEMS_INGRESO_DEPOSITO_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_DEPOSITO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!items_ingreso_deposito_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_ID", items_ingreso_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects 
		/// by the <c>FK_ITEM_ING_DEP_IT_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_id">The <c>ITEMS_INGRESO_DETALLE_ID</c> column value.</param>
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		public virtual ITEMS_INGRESO_DEPOSITO_DETRow[] GetByITEMS_INGRESO_DETALLE_ID(decimal items_ingreso_detalle_id)
		{
			return MapRecords(CreateGetByITEMS_INGRESO_DETALLE_IDCommand(items_ingreso_detalle_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_ITEM_ING_DEP_IT_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_id">The <c>ITEMS_INGRESO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByITEMS_INGRESO_DETALLE_IDAsDataTable(decimal items_ingreso_detalle_id)
		{
			return MapRecordsToDataTable(CreateGetByITEMS_INGRESO_DETALLE_IDCommand(items_ingreso_detalle_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_ITEM_ING_DEP_IT_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_id">The <c>ITEMS_INGRESO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByITEMS_INGRESO_DETALLE_IDCommand(decimal items_ingreso_detalle_id)
		{
			string whereSql = "";
			whereSql += "ITEMS_INGRESO_DETALLE_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ID", items_ingreso_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> object to be inserted.</param>
		public virtual void Insert(ITEMS_INGRESO_DEPOSITO_DETRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.ITEMS_INGRESO_DEPOSITO_DET (" +
				"ID, " +
				"ITEMS_INGRESO_DETALLE_ID, " +
				"FECHA_INGRESO, " +
				"UBICACION, " +
				"CANTIDAD, " +
				"TIPO_BULTOS, " +
				"MERCADERIAS, " +
				"LARGO, " +
				"ANCHO, " +
				"ALTO, " +
				"ESTIBADORES, " +
				"ESTIBADORES_FACTURADOS, " +
				"MONTACARGAS, " +
				"MONTACARGAS_FACTURADOS, " +
				"PRECINTOS, " +
				"OBSERVACIONES, " +
				"USO_BASCULA, " +
				"USO_BASCULA_FACTURADO, " +
				"USO_GRUA, " +
				"USO_GRUA_FACTURADO, " +
				"TOTAL_ESPACIO, " +
				"FECHA_EMISION, " +
				"ITEMS_INGRESO_DEPOSITO_ID, " +
				"CONSIGNATARIO_PERSONA_ID, " +
				"PESO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				_db.CreateSqlParameterName("UBICACION") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("TIPO_BULTOS") + ", " +
				_db.CreateSqlParameterName("MERCADERIAS") + ", " +
				_db.CreateSqlParameterName("LARGO") + ", " +
				_db.CreateSqlParameterName("ANCHO") + ", " +
				_db.CreateSqlParameterName("ALTO") + ", " +
				_db.CreateSqlParameterName("ESTIBADORES") + ", " +
				_db.CreateSqlParameterName("ESTIBADORES_FACTURADOS") + ", " +
				_db.CreateSqlParameterName("MONTACARGAS") + ", " +
				_db.CreateSqlParameterName("MONTACARGAS_FACTURADOS") + ", " +
				_db.CreateSqlParameterName("PRECINTOS") + ", " +
				_db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				_db.CreateSqlParameterName("USO_BASCULA") + ", " +
				_db.CreateSqlParameterName("USO_BASCULA_FACTURADO") + ", " +
				_db.CreateSqlParameterName("USO_GRUA") + ", " +
				_db.CreateSqlParameterName("USO_GRUA_FACTURADO") + ", " +
				_db.CreateSqlParameterName("TOTAL_ESPACIO") + ", " +
				_db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				_db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_ID") + ", " +
				_db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("PESO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ID", value.ITEMS_INGRESO_DETALLE_ID);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "UBICACION", value.UBICACION);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTOS", value.TIPO_BULTOS);
			AddParameter(cmd, "MERCADERIAS", value.MERCADERIAS);
			AddParameter(cmd, "LARGO", value.LARGO);
			AddParameter(cmd, "ANCHO", value.ANCHO);
			AddParameter(cmd, "ALTO",
				value.IsALTONull ? DBNull.Value : (object)value.ALTO);
			AddParameter(cmd, "ESTIBADORES", value.ESTIBADORES);
			AddParameter(cmd, "ESTIBADORES_FACTURADOS",
				value.IsESTIBADORES_FACTURADOSNull ? DBNull.Value : (object)value.ESTIBADORES_FACTURADOS);
			AddParameter(cmd, "MONTACARGAS", value.MONTACARGAS);
			AddParameter(cmd, "MONTACARGAS_FACTURADOS",
				value.IsMONTACARGAS_FACTURADOSNull ? DBNull.Value : (object)value.MONTACARGAS_FACTURADOS);
			AddParameter(cmd, "PRECINTOS", value.PRECINTOS);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "USO_BASCULA",
				value.IsUSO_BASCULANull ? DBNull.Value : (object)value.USO_BASCULA);
			AddParameter(cmd, "USO_BASCULA_FACTURADO",
				value.IsUSO_BASCULA_FACTURADONull ? DBNull.Value : (object)value.USO_BASCULA_FACTURADO);
			AddParameter(cmd, "USO_GRUA",
				value.IsUSO_GRUANull ? DBNull.Value : (object)value.USO_GRUA);
			AddParameter(cmd, "USO_GRUA_FACTURADO",
				value.IsUSO_GRUA_FACTURADONull ? DBNull.Value : (object)value.USO_GRUA_FACTURADO);
			AddParameter(cmd, "TOTAL_ESPACIO", value.TOTAL_ESPACIO);
			AddParameter(cmd, "FECHA_EMISION",
				value.IsFECHA_EMISIONNull ? DBNull.Value : (object)value.FECHA_EMISION);
			AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_ID",
				value.IsITEMS_INGRESO_DEPOSITO_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_DEPOSITO_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			AddParameter(cmd, "PESO",
				value.IsPESONull ? DBNull.Value : (object)value.PESO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(ITEMS_INGRESO_DEPOSITO_DETRow value)
		{
			
			string sqlStr = "UPDATE TRC.ITEMS_INGRESO_DEPOSITO_DET SET " +
				"ITEMS_INGRESO_DETALLE_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ID") + ", " +
				"FECHA_INGRESO=" + _db.CreateSqlParameterName("FECHA_INGRESO") + ", " +
				"UBICACION=" + _db.CreateSqlParameterName("UBICACION") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"TIPO_BULTOS=" + _db.CreateSqlParameterName("TIPO_BULTOS") + ", " +
				"MERCADERIAS=" + _db.CreateSqlParameterName("MERCADERIAS") + ", " +
				"LARGO=" + _db.CreateSqlParameterName("LARGO") + ", " +
				"ANCHO=" + _db.CreateSqlParameterName("ANCHO") + ", " +
				"ALTO=" + _db.CreateSqlParameterName("ALTO") + ", " +
				"ESTIBADORES=" + _db.CreateSqlParameterName("ESTIBADORES") + ", " +
				"ESTIBADORES_FACTURADOS=" + _db.CreateSqlParameterName("ESTIBADORES_FACTURADOS") + ", " +
				"MONTACARGAS=" + _db.CreateSqlParameterName("MONTACARGAS") + ", " +
				"MONTACARGAS_FACTURADOS=" + _db.CreateSqlParameterName("MONTACARGAS_FACTURADOS") + ", " +
				"PRECINTOS=" + _db.CreateSqlParameterName("PRECINTOS") + ", " +
				"OBSERVACIONES=" + _db.CreateSqlParameterName("OBSERVACIONES") + ", " +
				"USO_BASCULA=" + _db.CreateSqlParameterName("USO_BASCULA") + ", " +
				"USO_BASCULA_FACTURADO=" + _db.CreateSqlParameterName("USO_BASCULA_FACTURADO") + ", " +
				"USO_GRUA=" + _db.CreateSqlParameterName("USO_GRUA") + ", " +
				"USO_GRUA_FACTURADO=" + _db.CreateSqlParameterName("USO_GRUA_FACTURADO") + ", " +
				"TOTAL_ESPACIO=" + _db.CreateSqlParameterName("TOTAL_ESPACIO") + ", " +
				"FECHA_EMISION=" + _db.CreateSqlParameterName("FECHA_EMISION") + ", " +
				"ITEMS_INGRESO_DEPOSITO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_ID") + ", " +
				"CONSIGNATARIO_PERSONA_ID=" + _db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") + ", " +
				"PESO=" + _db.CreateSqlParameterName("PESO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ID", value.ITEMS_INGRESO_DETALLE_ID);
			AddParameter(cmd, "FECHA_INGRESO",
				value.IsFECHA_INGRESONull ? DBNull.Value : (object)value.FECHA_INGRESO);
			AddParameter(cmd, "UBICACION", value.UBICACION);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "TIPO_BULTOS", value.TIPO_BULTOS);
			AddParameter(cmd, "MERCADERIAS", value.MERCADERIAS);
			AddParameter(cmd, "LARGO", value.LARGO);
			AddParameter(cmd, "ANCHO", value.ANCHO);
			AddParameter(cmd, "ALTO",
				value.IsALTONull ? DBNull.Value : (object)value.ALTO);
			AddParameter(cmd, "ESTIBADORES", value.ESTIBADORES);
			AddParameter(cmd, "ESTIBADORES_FACTURADOS",
				value.IsESTIBADORES_FACTURADOSNull ? DBNull.Value : (object)value.ESTIBADORES_FACTURADOS);
			AddParameter(cmd, "MONTACARGAS", value.MONTACARGAS);
			AddParameter(cmd, "MONTACARGAS_FACTURADOS",
				value.IsMONTACARGAS_FACTURADOSNull ? DBNull.Value : (object)value.MONTACARGAS_FACTURADOS);
			AddParameter(cmd, "PRECINTOS", value.PRECINTOS);
			AddParameter(cmd, "OBSERVACIONES", value.OBSERVACIONES);
			AddParameter(cmd, "USO_BASCULA",
				value.IsUSO_BASCULANull ? DBNull.Value : (object)value.USO_BASCULA);
			AddParameter(cmd, "USO_BASCULA_FACTURADO",
				value.IsUSO_BASCULA_FACTURADONull ? DBNull.Value : (object)value.USO_BASCULA_FACTURADO);
			AddParameter(cmd, "USO_GRUA",
				value.IsUSO_GRUANull ? DBNull.Value : (object)value.USO_GRUA);
			AddParameter(cmd, "USO_GRUA_FACTURADO",
				value.IsUSO_GRUA_FACTURADONull ? DBNull.Value : (object)value.USO_GRUA_FACTURADO);
			AddParameter(cmd, "TOTAL_ESPACIO", value.TOTAL_ESPACIO);
			AddParameter(cmd, "FECHA_EMISION",
				value.IsFECHA_EMISIONNull ? DBNull.Value : (object)value.FECHA_EMISION);
			AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_ID",
				value.IsITEMS_INGRESO_DEPOSITO_IDNull ? DBNull.Value : (object)value.ITEMS_INGRESO_DEPOSITO_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			AddParameter(cmd, "PESO",
				value.IsPESONull ? DBNull.Value : (object)value.PESO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
		/// </summary>
		/// <param name="value">The <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(ITEMS_INGRESO_DEPOSITO_DETRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table using
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
		/// Deletes records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table using the 
		/// <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return DeleteByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table using the 
		/// <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
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
		/// delete records using the <c>FK_ITEM_ING_DEP_CONSG_PER_ID</c> foreign key.
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
		/// Deletes records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table using the 
		/// <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_DEPOSITO_ID(decimal items_ingreso_deposito_id)
		{
			return DeleteByITEMS_INGRESO_DEPOSITO_ID(items_ingreso_deposito_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table using the 
		/// <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_idNull">true if the method ignores the items_ingreso_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_DEPOSITO_ID(decimal items_ingreso_deposito_id, bool items_ingreso_deposito_idNull)
		{
			return CreateDeleteByITEMS_INGRESO_DEPOSITO_IDCommand(items_ingreso_deposito_id, items_ingreso_deposito_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEM_ING_DEP_IT_IND_DEP_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_deposito_id">The <c>ITEMS_INGRESO_DEPOSITO_ID</c> column value.</param>
		/// <param name="items_ingreso_deposito_idNull">true if the method ignores the items_ingreso_deposito_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEMS_INGRESO_DEPOSITO_IDCommand(decimal items_ingreso_deposito_id, bool items_ingreso_deposito_idNull)
		{
			string whereSql = "";
			if(items_ingreso_deposito_idNull)
				whereSql += "ITEMS_INGRESO_DEPOSITO_ID IS NULL";
			else
				whereSql += "ITEMS_INGRESO_DEPOSITO_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DEPOSITO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!items_ingreso_deposito_idNull)
				AddParameter(cmd, "ITEMS_INGRESO_DEPOSITO_ID", items_ingreso_deposito_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table using the 
		/// <c>FK_ITEM_ING_DEP_IT_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_id">The <c>ITEMS_INGRESO_DETALLE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByITEMS_INGRESO_DETALLE_ID(decimal items_ingreso_detalle_id)
		{
			return CreateDeleteByITEMS_INGRESO_DETALLE_IDCommand(items_ingreso_detalle_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_ITEM_ING_DEP_IT_ING_DET_ID</c> foreign key.
		/// </summary>
		/// <param name="items_ingreso_detalle_id">The <c>ITEMS_INGRESO_DETALLE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByITEMS_INGRESO_DETALLE_IDCommand(decimal items_ingreso_detalle_id)
		{
			string whereSql = "";
			whereSql += "ITEMS_INGRESO_DETALLE_ID=" + _db.CreateSqlParameterName("ITEMS_INGRESO_DETALLE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "ITEMS_INGRESO_DETALLE_ID", items_ingreso_detalle_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>ITEMS_INGRESO_DEPOSITO_DET</c> records that match the specified criteria.
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
		/// to delete <c>ITEMS_INGRESO_DEPOSITO_DET</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.ITEMS_INGRESO_DEPOSITO_DET";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		protected ITEMS_INGRESO_DEPOSITO_DETRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		protected ITEMS_INGRESO_DEPOSITO_DETRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> objects.</returns>
		protected virtual ITEMS_INGRESO_DEPOSITO_DETRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int items_ingreso_detalle_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_DETALLE_ID");
			int fecha_ingresoColumnIndex = reader.GetOrdinal("FECHA_INGRESO");
			int ubicacionColumnIndex = reader.GetOrdinal("UBICACION");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int tipo_bultosColumnIndex = reader.GetOrdinal("TIPO_BULTOS");
			int mercaderiasColumnIndex = reader.GetOrdinal("MERCADERIAS");
			int largoColumnIndex = reader.GetOrdinal("LARGO");
			int anchoColumnIndex = reader.GetOrdinal("ANCHO");
			int altoColumnIndex = reader.GetOrdinal("ALTO");
			int estibadoresColumnIndex = reader.GetOrdinal("ESTIBADORES");
			int estibadores_facturadosColumnIndex = reader.GetOrdinal("ESTIBADORES_FACTURADOS");
			int montacargasColumnIndex = reader.GetOrdinal("MONTACARGAS");
			int montacargas_facturadosColumnIndex = reader.GetOrdinal("MONTACARGAS_FACTURADOS");
			int precintosColumnIndex = reader.GetOrdinal("PRECINTOS");
			int observacionesColumnIndex = reader.GetOrdinal("OBSERVACIONES");
			int uso_basculaColumnIndex = reader.GetOrdinal("USO_BASCULA");
			int uso_bascula_facturadoColumnIndex = reader.GetOrdinal("USO_BASCULA_FACTURADO");
			int uso_gruaColumnIndex = reader.GetOrdinal("USO_GRUA");
			int uso_grua_facturadoColumnIndex = reader.GetOrdinal("USO_GRUA_FACTURADO");
			int total_espacioColumnIndex = reader.GetOrdinal("TOTAL_ESPACIO");
			int fecha_emisionColumnIndex = reader.GetOrdinal("FECHA_EMISION");
			int items_ingreso_deposito_idColumnIndex = reader.GetOrdinal("ITEMS_INGRESO_DEPOSITO_ID");
			int consignatario_persona_idColumnIndex = reader.GetOrdinal("CONSIGNATARIO_PERSONA_ID");
			int pesoColumnIndex = reader.GetOrdinal("PESO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					ITEMS_INGRESO_DEPOSITO_DETRow record = new ITEMS_INGRESO_DEPOSITO_DETRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.ITEMS_INGRESO_DETALLE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_detalle_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_ingresoColumnIndex))
						record.FECHA_INGRESO = Convert.ToDateTime(reader.GetValue(fecha_ingresoColumnIndex));
					if(!reader.IsDBNull(ubicacionColumnIndex))
						record.UBICACION = Convert.ToString(reader.GetValue(ubicacionColumnIndex));
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(tipo_bultosColumnIndex))
						record.TIPO_BULTOS = Convert.ToString(reader.GetValue(tipo_bultosColumnIndex));
					if(!reader.IsDBNull(mercaderiasColumnIndex))
						record.MERCADERIAS = Convert.ToString(reader.GetValue(mercaderiasColumnIndex));
					record.LARGO = Math.Round(Convert.ToDecimal(reader.GetValue(largoColumnIndex)), 9);
					record.ANCHO = Math.Round(Convert.ToDecimal(reader.GetValue(anchoColumnIndex)), 9);
					if(!reader.IsDBNull(altoColumnIndex))
						record.ALTO = Math.Round(Convert.ToDecimal(reader.GetValue(altoColumnIndex)), 9);
					record.ESTIBADORES = Math.Round(Convert.ToDecimal(reader.GetValue(estibadoresColumnIndex)), 9);
					if(!reader.IsDBNull(estibadores_facturadosColumnIndex))
						record.ESTIBADORES_FACTURADOS = Math.Round(Convert.ToDecimal(reader.GetValue(estibadores_facturadosColumnIndex)), 9);
					record.MONTACARGAS = Math.Round(Convert.ToDecimal(reader.GetValue(montacargasColumnIndex)), 9);
					if(!reader.IsDBNull(montacargas_facturadosColumnIndex))
						record.MONTACARGAS_FACTURADOS = Math.Round(Convert.ToDecimal(reader.GetValue(montacargas_facturadosColumnIndex)), 9);
					if(!reader.IsDBNull(precintosColumnIndex))
						record.PRECINTOS = Convert.ToString(reader.GetValue(precintosColumnIndex));
					if(!reader.IsDBNull(observacionesColumnIndex))
						record.OBSERVACIONES = Convert.ToString(reader.GetValue(observacionesColumnIndex));
					if(!reader.IsDBNull(uso_basculaColumnIndex))
						record.USO_BASCULA = Math.Round(Convert.ToDecimal(reader.GetValue(uso_basculaColumnIndex)), 9);
					if(!reader.IsDBNull(uso_bascula_facturadoColumnIndex))
						record.USO_BASCULA_FACTURADO = Math.Round(Convert.ToDecimal(reader.GetValue(uso_bascula_facturadoColumnIndex)), 9);
					if(!reader.IsDBNull(uso_gruaColumnIndex))
						record.USO_GRUA = Math.Round(Convert.ToDecimal(reader.GetValue(uso_gruaColumnIndex)), 9);
					if(!reader.IsDBNull(uso_grua_facturadoColumnIndex))
						record.USO_GRUA_FACTURADO = Math.Round(Convert.ToDecimal(reader.GetValue(uso_grua_facturadoColumnIndex)), 9);
					record.TOTAL_ESPACIO = Math.Round(Convert.ToDecimal(reader.GetValue(total_espacioColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_emisionColumnIndex))
						record.FECHA_EMISION = Convert.ToDateTime(reader.GetValue(fecha_emisionColumnIndex));
					if(!reader.IsDBNull(items_ingreso_deposito_idColumnIndex))
						record.ITEMS_INGRESO_DEPOSITO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(items_ingreso_deposito_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_persona_idColumnIndex))
						record.CONSIGNATARIO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(consignatario_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(pesoColumnIndex))
						record.PESO = Math.Round(Convert.ToDecimal(reader.GetValue(pesoColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (ITEMS_INGRESO_DEPOSITO_DETRow[])(recordList.ToArray(typeof(ITEMS_INGRESO_DEPOSITO_DETRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="ITEMS_INGRESO_DEPOSITO_DETRow"/> object.</returns>
		protected virtual ITEMS_INGRESO_DEPOSITO_DETRow MapRow(DataRow row)
		{
			ITEMS_INGRESO_DEPOSITO_DETRow mappedObject = new ITEMS_INGRESO_DEPOSITO_DETRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "ITEMS_INGRESO_DETALLE_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_DETALLE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_DETALLE_ID = (decimal)row[dataColumn];
			// Column "FECHA_INGRESO"
			dataColumn = dataTable.Columns["FECHA_INGRESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INGRESO = (System.DateTime)row[dataColumn];
			// Column "UBICACION"
			dataColumn = dataTable.Columns["UBICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.UBICACION = (string)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "TIPO_BULTOS"
			dataColumn = dataTable.Columns["TIPO_BULTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_BULTOS = (string)row[dataColumn];
			// Column "MERCADERIAS"
			dataColumn = dataTable.Columns["MERCADERIAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIAS = (string)row[dataColumn];
			// Column "LARGO"
			dataColumn = dataTable.Columns["LARGO"];
			if(!row.IsNull(dataColumn))
				mappedObject.LARGO = (decimal)row[dataColumn];
			// Column "ANCHO"
			dataColumn = dataTable.Columns["ANCHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ANCHO = (decimal)row[dataColumn];
			// Column "ALTO"
			dataColumn = dataTable.Columns["ALTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ALTO = (decimal)row[dataColumn];
			// Column "ESTIBADORES"
			dataColumn = dataTable.Columns["ESTIBADORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTIBADORES = (decimal)row[dataColumn];
			// Column "ESTIBADORES_FACTURADOS"
			dataColumn = dataTable.Columns["ESTIBADORES_FACTURADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTIBADORES_FACTURADOS = (decimal)row[dataColumn];
			// Column "MONTACARGAS"
			dataColumn = dataTable.Columns["MONTACARGAS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTACARGAS = (decimal)row[dataColumn];
			// Column "MONTACARGAS_FACTURADOS"
			dataColumn = dataTable.Columns["MONTACARGAS_FACTURADOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTACARGAS_FACTURADOS = (decimal)row[dataColumn];
			// Column "PRECINTOS"
			dataColumn = dataTable.Columns["PRECINTOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRECINTOS = (string)row[dataColumn];
			// Column "OBSERVACIONES"
			dataColumn = dataTable.Columns["OBSERVACIONES"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACIONES = (string)row[dataColumn];
			// Column "USO_BASCULA"
			dataColumn = dataTable.Columns["USO_BASCULA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_BASCULA = (decimal)row[dataColumn];
			// Column "USO_BASCULA_FACTURADO"
			dataColumn = dataTable.Columns["USO_BASCULA_FACTURADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_BASCULA_FACTURADO = (decimal)row[dataColumn];
			// Column "USO_GRUA"
			dataColumn = dataTable.Columns["USO_GRUA"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_GRUA = (decimal)row[dataColumn];
			// Column "USO_GRUA_FACTURADO"
			dataColumn = dataTable.Columns["USO_GRUA_FACTURADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.USO_GRUA_FACTURADO = (decimal)row[dataColumn];
			// Column "TOTAL_ESPACIO"
			dataColumn = dataTable.Columns["TOTAL_ESPACIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOTAL_ESPACIO = (decimal)row[dataColumn];
			// Column "FECHA_EMISION"
			dataColumn = dataTable.Columns["FECHA_EMISION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_EMISION = (System.DateTime)row[dataColumn];
			// Column "ITEMS_INGRESO_DEPOSITO_ID"
			dataColumn = dataTable.Columns["ITEMS_INGRESO_DEPOSITO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEMS_INGRESO_DEPOSITO_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_PERSONA_ID"
			dataColumn = dataTable.Columns["CONSIGNATARIO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_PERSONA_ID = (decimal)row[dataColumn];
			// Column "PESO"
			dataColumn = dataTable.Columns["PESO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>ITEMS_INGRESO_DEPOSITO_DET</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "ITEMS_INGRESO_DEPOSITO_DET";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_DETALLE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_INGRESO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("UBICACION", typeof(string));
			dataColumn.MaxLength = 120;
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TIPO_BULTOS", typeof(string));
			dataColumn.MaxLength = 35;
			dataColumn = dataTable.Columns.Add("MERCADERIAS", typeof(string));
			dataColumn.MaxLength = 800;
			dataColumn = dataTable.Columns.Add("LARGO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ANCHO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ALTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("ESTIBADORES", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTIBADORES_FACTURADOS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MONTACARGAS", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTACARGAS_FACTURADOS", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRECINTOS", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("OBSERVACIONES", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("USO_BASCULA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USO_BASCULA_FACTURADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USO_GRUA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("USO_GRUA_FACTURADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TOTAL_ESPACIO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_EMISION", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("ITEMS_INGRESO_DEPOSITO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO", typeof(decimal));
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

				case "ITEMS_INGRESO_DETALLE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_INGRESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "UBICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TIPO_BULTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "MERCADERIAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "LARGO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ANCHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ALTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTIBADORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTIBADORES_FACTURADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTACARGAS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MONTACARGAS_FACTURADOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRECINTOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OBSERVACIONES":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "USO_BASCULA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_BASCULA_FACTURADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_GRUA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "USO_GRUA_FACTURADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TOTAL_ESPACIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_EMISION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "ITEMS_INGRESO_DEPOSITO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of ITEMS_INGRESO_DEPOSITO_DETCollection_Base class
}  // End of namespace
