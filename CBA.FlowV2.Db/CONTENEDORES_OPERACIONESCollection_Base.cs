// <fileinfo name="CONTENEDORES_OPERACIONESCollection_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_OPERACIONESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CONTENEDORES_OPERACIONESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_OPERACIONESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string OPERACIONColumnName = "OPERACION";
		public const string FECHAColumnName = "FECHA";
		public const string HORA_INICIOColumnName = "HORA_INICIO";
		public const string HORA_FINColumnName = "HORA_FIN";
		public const string NRO_FORMULARIOColumnName = "NRO_FORMULARIO";
		public const string CONTENEDOR_IDColumnName = "CONTENEDOR_ID";
		public const string LINEA_IDColumnName = "LINEA_ID";
		public const string CANTIDADColumnName = "CANTIDAD";
		public const string BL_NROColumnName = "BL_NRO";
		public const string BOOKINGColumnName = "BOOKING";
		public const string PERSONA_IDColumnName = "PERSONA_ID";
		public const string CLASIFICACION_IDColumnName = "CLASIFICACION_ID";
		public const string ITEMColumnName = "ITEM";
		public const string MERCADERIA_INTERNAColumnName = "MERCADERIA_INTERNA";
		public const string PRECINTO_1ColumnName = "PRECINTO_1";
		public const string PRECINTO_2ColumnName = "PRECINTO_2";
		public const string PRECINTO_3ColumnName = "PRECINTO_3";
		public const string PRECINTO_4ColumnName = "PRECINTO_4";
		public const string PRECINTO_5ColumnName = "PRECINTO_5";
		public const string EDIColumnName = "EDI";
		public const string ESTADOColumnName = "ESTADO";
		public const string PROCESADOColumnName = "PROCESADO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string VENTILETEColumnName = "VENTILETE";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string TARA_CAMIONColumnName = "TARA_CAMION";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PISOColumnName = "PISO";
		public const string FONDOColumnName = "FONDO";
		public const string TECHOColumnName = "TECHO";
		public const string PANEL_DERECHOColumnName = "PANEL_DERECHO";
		public const string PANEL_IZQUIERDOColumnName = "PANEL_IZQUIERDO";
		public const string PUERTAColumnName = "PUERTA";
		public const string REFRIGERADOColumnName = "REFRIGERADO";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_OPERACIONESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CONTENEDORES_OPERACIONESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CONTENEDORES_OPERACIONES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public virtual CONTENEDORES_OPERACIONESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CONTENEDORES_OPERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CONTENEDORES_OPERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CONTENEDORES_OPERACIONESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_OPERACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CONTENEDORES_OPERACIONESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CONTENEDORES_OPERACIONESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public CONTENEDORES_OPERACIONESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects that 
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public virtual CONTENEDORES_OPERACIONESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CONTENEDORES_OPERACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CONTENEDORES_OPERACIONESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CONTENEDORES_OPERACIONESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CONTENEDORES_OPERACIONESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CONTENEDORES_OPERACIONESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public CONTENEDORES_OPERACIONESRow[] GetByCONTENEDOR_ID(decimal contenedor_id)
		{
			return GetByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <param name="contenedor_idNull">true if the method ignores the contenedor_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public virtual CONTENEDORES_OPERACIONESRow[] GetByCONTENEDOR_ID(decimal contenedor_id, bool contenedor_idNull)
		{
			return MapRecords(CreateGetByCONTENEDOR_IDCommand(contenedor_id, contenedor_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONTENEDOR_IDAsDataTable(decimal contenedor_id)
		{
			return GetByCONTENEDOR_IDAsDataTable(contenedor_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
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
		/// return records by the <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
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
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public CONTENEDORES_OPERACIONESRow[] GetByLINEA_ID(decimal linea_id)
		{
			return GetByLINEA_ID(linea_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public virtual CONTENEDORES_OPERACIONESRow[] GetByLINEA_ID(decimal linea_id, bool linea_idNull)
		{
			return MapRecords(CreateGetByLINEA_IDCommand(linea_id, linea_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByLINEA_IDAsDataTable(decimal linea_id)
		{
			return GetByLINEA_IDAsDataTable(linea_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByLINEA_IDAsDataTable(decimal linea_id, bool linea_idNull)
		{
			return MapRecordsToDataTable(CreateGetByLINEA_IDCommand(linea_id, linea_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByLINEA_IDCommand(decimal linea_id, bool linea_idNull)
		{
			string whereSql = "";
			if(linea_idNull)
				whereSql += "LINEA_ID IS NULL";
			else
				whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!linea_idNull)
				AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public CONTENEDORES_OPERACIONESRow[] GetByPERSONA_ID(decimal persona_id)
		{
			return GetByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects 
		/// by the <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		public virtual CONTENEDORES_OPERACIONESRow[] GetByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return MapRecords(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByPERSONA_IDAsDataTable(decimal persona_id)
		{
			return GetByPERSONA_IDAsDataTable(persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByPERSONA_IDAsDataTable(decimal persona_id, bool persona_idNull)
		{
			return MapRecordsToDataTable(CreateGetByPERSONA_IDCommand(persona_id, persona_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CONTENEDORES_OPERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_OPERACIONESRow"/> object to be inserted.</param>
		public virtual void Insert(CONTENEDORES_OPERACIONESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CONTENEDORES_OPERACIONES (" +
				"ID, " +
				"OPERACION, " +
				"FECHA, " +
				"HORA_INICIO, " +
				"HORA_FIN, " +
				"NRO_FORMULARIO, " +
				"CONTENEDOR_ID, " +
				"LINEA_ID, " +
				"CANTIDAD, " +
				"BL_NRO, " +
				"BOOKING, " +
				"PERSONA_ID, " +
				"CLASIFICACION_ID, " +
				"ITEM, " +
				"MERCADERIA_INTERNA, " +
				"PRECINTO_1, " +
				"PRECINTO_2, " +
				"PRECINTO_3, " +
				"PRECINTO_4, " +
				"PRECINTO_5, " +
				"EDI, " +
				"ESTADO, " +
				"PROCESADO, " +
				"OBSERVACION, " +
				"VENTILETE, " +
				"PESO_BRUTO, " +
				"TARA_CAMION, " +
				"PESO_NETO, " +
				"TARA_CONTENEDOR, " +
				"PISO, " +
				"FONDO, " +
				"TECHO, " +
				"PANEL_DERECHO, " +
				"PANEL_IZQUIERDO, " +
				"PUERTA, " +
				"REFRIGERADO" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("OPERACION") + ", " +
				_db.CreateSqlParameterName("FECHA") + ", " +
				_db.CreateSqlParameterName("HORA_INICIO") + ", " +
				_db.CreateSqlParameterName("HORA_FIN") + ", " +
				_db.CreateSqlParameterName("NRO_FORMULARIO") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				_db.CreateSqlParameterName("LINEA_ID") + ", " +
				_db.CreateSqlParameterName("CANTIDAD") + ", " +
				_db.CreateSqlParameterName("BL_NRO") + ", " +
				_db.CreateSqlParameterName("BOOKING") + ", " +
				_db.CreateSqlParameterName("PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("CLASIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("ITEM") + ", " +
				_db.CreateSqlParameterName("MERCADERIA_INTERNA") + ", " +
				_db.CreateSqlParameterName("PRECINTO_1") + ", " +
				_db.CreateSqlParameterName("PRECINTO_2") + ", " +
				_db.CreateSqlParameterName("PRECINTO_3") + ", " +
				_db.CreateSqlParameterName("PRECINTO_4") + ", " +
				_db.CreateSqlParameterName("PRECINTO_5") + ", " +
				_db.CreateSqlParameterName("EDI") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("PROCESADO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("VENTILETE") + ", " +
				_db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				_db.CreateSqlParameterName("TARA_CAMION") + ", " +
				_db.CreateSqlParameterName("PESO_NETO") + ", " +
				_db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("PISO") + ", " +
				_db.CreateSqlParameterName("FONDO") + ", " +
				_db.CreateSqlParameterName("TECHO") + ", " +
				_db.CreateSqlParameterName("PANEL_DERECHO") + ", " +
				_db.CreateSqlParameterName("PANEL_IZQUIERDO") + ", " +
				_db.CreateSqlParameterName("PUERTA") + ", " +
				_db.CreateSqlParameterName("REFRIGERADO") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "OPERACION", value.OPERACION);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "HORA_INICIO",
				value.IsHORA_INICIONull ? DBNull.Value : (object)value.HORA_INICIO);
			AddParameter(cmd, "HORA_FIN",
				value.IsHORA_FINNull ? DBNull.Value : (object)value.HORA_FIN);
			AddParameter(cmd, "NRO_FORMULARIO", value.NRO_FORMULARIO);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "LINEA_ID",
				value.IsLINEA_IDNull ? DBNull.Value : (object)value.LINEA_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "BL_NRO", value.BL_NRO);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "CLASIFICACION_ID", value.CLASIFICACION_ID);
			AddParameter(cmd, "ITEM",
				value.IsITEMNull ? DBNull.Value : (object)value.ITEM);
			AddParameter(cmd, "MERCADERIA_INTERNA", value.MERCADERIA_INTERNA);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "EDI", value.EDI);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PROCESADO", value.PROCESADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "VENTILETE", value.VENTILETE);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PISO", value.PISO);
			AddParameter(cmd, "FONDO", value.FONDO);
			AddParameter(cmd, "TECHO", value.TECHO);
			AddParameter(cmd, "PANEL_DERECHO", value.PANEL_DERECHO);
			AddParameter(cmd, "PANEL_IZQUIERDO", value.PANEL_IZQUIERDO);
			AddParameter(cmd, "PUERTA", value.PUERTA);
			AddParameter(cmd, "REFRIGERADO", value.REFRIGERADO);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CONTENEDORES_OPERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_OPERACIONESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CONTENEDORES_OPERACIONESRow value)
		{
			
			string sqlStr = "UPDATE TRC.CONTENEDORES_OPERACIONES SET " +
				"OPERACION=" + _db.CreateSqlParameterName("OPERACION") + ", " +
				"FECHA=" + _db.CreateSqlParameterName("FECHA") + ", " +
				"HORA_INICIO=" + _db.CreateSqlParameterName("HORA_INICIO") + ", " +
				"HORA_FIN=" + _db.CreateSqlParameterName("HORA_FIN") + ", " +
				"NRO_FORMULARIO=" + _db.CreateSqlParameterName("NRO_FORMULARIO") + ", " +
				"CONTENEDOR_ID=" + _db.CreateSqlParameterName("CONTENEDOR_ID") + ", " +
				"LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID") + ", " +
				"CANTIDAD=" + _db.CreateSqlParameterName("CANTIDAD") + ", " +
				"BL_NRO=" + _db.CreateSqlParameterName("BL_NRO") + ", " +
				"BOOKING=" + _db.CreateSqlParameterName("BOOKING") + ", " +
				"PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID") + ", " +
				"CLASIFICACION_ID=" + _db.CreateSqlParameterName("CLASIFICACION_ID") + ", " +
				"ITEM=" + _db.CreateSqlParameterName("ITEM") + ", " +
				"MERCADERIA_INTERNA=" + _db.CreateSqlParameterName("MERCADERIA_INTERNA") + ", " +
				"PRECINTO_1=" + _db.CreateSqlParameterName("PRECINTO_1") + ", " +
				"PRECINTO_2=" + _db.CreateSqlParameterName("PRECINTO_2") + ", " +
				"PRECINTO_3=" + _db.CreateSqlParameterName("PRECINTO_3") + ", " +
				"PRECINTO_4=" + _db.CreateSqlParameterName("PRECINTO_4") + ", " +
				"PRECINTO_5=" + _db.CreateSqlParameterName("PRECINTO_5") + ", " +
				"EDI=" + _db.CreateSqlParameterName("EDI") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"PROCESADO=" + _db.CreateSqlParameterName("PROCESADO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"VENTILETE=" + _db.CreateSqlParameterName("VENTILETE") + ", " +
				"PESO_BRUTO=" + _db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				"TARA_CAMION=" + _db.CreateSqlParameterName("TARA_CAMION") + ", " +
				"PESO_NETO=" + _db.CreateSqlParameterName("PESO_NETO") + ", " +
				"TARA_CONTENEDOR=" + _db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				"PISO=" + _db.CreateSqlParameterName("PISO") + ", " +
				"FONDO=" + _db.CreateSqlParameterName("FONDO") + ", " +
				"TECHO=" + _db.CreateSqlParameterName("TECHO") + ", " +
				"PANEL_DERECHO=" + _db.CreateSqlParameterName("PANEL_DERECHO") + ", " +
				"PANEL_IZQUIERDO=" + _db.CreateSqlParameterName("PANEL_IZQUIERDO") + ", " +
				"PUERTA=" + _db.CreateSqlParameterName("PUERTA") + ", " +
				"REFRIGERADO=" + _db.CreateSqlParameterName("REFRIGERADO") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "OPERACION", value.OPERACION);
			AddParameter(cmd, "FECHA",
				value.IsFECHANull ? DBNull.Value : (object)value.FECHA);
			AddParameter(cmd, "HORA_INICIO",
				value.IsHORA_INICIONull ? DBNull.Value : (object)value.HORA_INICIO);
			AddParameter(cmd, "HORA_FIN",
				value.IsHORA_FINNull ? DBNull.Value : (object)value.HORA_FIN);
			AddParameter(cmd, "NRO_FORMULARIO", value.NRO_FORMULARIO);
			AddParameter(cmd, "CONTENEDOR_ID",
				value.IsCONTENEDOR_IDNull ? DBNull.Value : (object)value.CONTENEDOR_ID);
			AddParameter(cmd, "LINEA_ID",
				value.IsLINEA_IDNull ? DBNull.Value : (object)value.LINEA_ID);
			AddParameter(cmd, "CANTIDAD",
				value.IsCANTIDADNull ? DBNull.Value : (object)value.CANTIDAD);
			AddParameter(cmd, "BL_NRO", value.BL_NRO);
			AddParameter(cmd, "BOOKING", value.BOOKING);
			AddParameter(cmd, "PERSONA_ID",
				value.IsPERSONA_IDNull ? DBNull.Value : (object)value.PERSONA_ID);
			AddParameter(cmd, "CLASIFICACION_ID", value.CLASIFICACION_ID);
			AddParameter(cmd, "ITEM",
				value.IsITEMNull ? DBNull.Value : (object)value.ITEM);
			AddParameter(cmd, "MERCADERIA_INTERNA", value.MERCADERIA_INTERNA);
			AddParameter(cmd, "PRECINTO_1", value.PRECINTO_1);
			AddParameter(cmd, "PRECINTO_2", value.PRECINTO_2);
			AddParameter(cmd, "PRECINTO_3", value.PRECINTO_3);
			AddParameter(cmd, "PRECINTO_4", value.PRECINTO_4);
			AddParameter(cmd, "PRECINTO_5", value.PRECINTO_5);
			AddParameter(cmd, "EDI", value.EDI);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "PROCESADO", value.PROCESADO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "VENTILETE", value.VENTILETE);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "TARA_CAMION",
				value.IsTARA_CAMIONNull ? DBNull.Value : (object)value.TARA_CAMION);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PISO", value.PISO);
			AddParameter(cmd, "FONDO", value.FONDO);
			AddParameter(cmd, "TECHO", value.TECHO);
			AddParameter(cmd, "PANEL_DERECHO", value.PANEL_DERECHO);
			AddParameter(cmd, "PANEL_IZQUIERDO", value.PANEL_IZQUIERDO);
			AddParameter(cmd, "PUERTA", value.PUERTA);
			AddParameter(cmd, "REFRIGERADO", value.REFRIGERADO);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES_OPERACIONES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CONTENEDORES_OPERACIONES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CONTENEDORES_OPERACIONES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CONTENEDORES_OPERACIONESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CONTENEDORES_OPERACIONESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CONTENEDORES_OPERACIONES</c> table using
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
		/// Deletes records from the <c>CONTENEDORES_OPERACIONES</c> table using the 
		/// <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
		/// </summary>
		/// <param name="contenedor_id">The <c>CONTENEDOR_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONTENEDOR_ID(decimal contenedor_id)
		{
			return DeleteByCONTENEDOR_ID(contenedor_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_OPERACIONES</c> table using the 
		/// <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
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
		/// delete records using the <c>FK_CONTENEDORES_OPER_CONTEN</c> foreign key.
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
		/// Deletes records from the <c>CONTENEDORES_OPERACIONES</c> table using the 
		/// <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id)
		{
			return DeleteByLINEA_ID(linea_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_OPERACIONES</c> table using the 
		/// <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByLINEA_ID(decimal linea_id, bool linea_idNull)
		{
			return CreateDeleteByLINEA_IDCommand(linea_id, linea_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTENEDORES_OPER_LINEA</c> foreign key.
		/// </summary>
		/// <param name="linea_id">The <c>LINEA_ID</c> column value.</param>
		/// <param name="linea_idNull">true if the method ignores the linea_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByLINEA_IDCommand(decimal linea_id, bool linea_idNull)
		{
			string whereSql = "";
			if(linea_idNull)
				whereSql += "LINEA_ID IS NULL";
			else
				whereSql += "LINEA_ID=" + _db.CreateSqlParameterName("LINEA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!linea_idNull)
				AddParameter(cmd, "LINEA_ID", linea_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_OPERACIONES</c> table using the 
		/// <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id)
		{
			return DeleteByPERSONA_ID(persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CONTENEDORES_OPERACIONES</c> table using the 
		/// <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByPERSONA_ID(decimal persona_id, bool persona_idNull)
		{
			return CreateDeleteByPERSONA_IDCommand(persona_id, persona_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CONTENEDORES_OPER_PERSONA</c> foreign key.
		/// </summary>
		/// <param name="persona_id">The <c>PERSONA_ID</c> column value.</param>
		/// <param name="persona_idNull">true if the method ignores the persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByPERSONA_IDCommand(decimal persona_id, bool persona_idNull)
		{
			string whereSql = "";
			if(persona_idNull)
				whereSql += "PERSONA_ID IS NULL";
			else
				whereSql += "PERSONA_ID=" + _db.CreateSqlParameterName("PERSONA_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!persona_idNull)
				AddParameter(cmd, "PERSONA_ID", persona_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CONTENEDORES_OPERACIONES</c> records that match the specified criteria.
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
		/// to delete <c>CONTENEDORES_OPERACIONES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CONTENEDORES_OPERACIONES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CONTENEDORES_OPERACIONES</c> table.
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		protected CONTENEDORES_OPERACIONESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		protected CONTENEDORES_OPERACIONESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CONTENEDORES_OPERACIONESRow"/> objects.</returns>
		protected virtual CONTENEDORES_OPERACIONESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int operacionColumnIndex = reader.GetOrdinal("OPERACION");
			int fechaColumnIndex = reader.GetOrdinal("FECHA");
			int hora_inicioColumnIndex = reader.GetOrdinal("HORA_INICIO");
			int hora_finColumnIndex = reader.GetOrdinal("HORA_FIN");
			int nro_formularioColumnIndex = reader.GetOrdinal("NRO_FORMULARIO");
			int contenedor_idColumnIndex = reader.GetOrdinal("CONTENEDOR_ID");
			int linea_idColumnIndex = reader.GetOrdinal("LINEA_ID");
			int cantidadColumnIndex = reader.GetOrdinal("CANTIDAD");
			int bl_nroColumnIndex = reader.GetOrdinal("BL_NRO");
			int bookingColumnIndex = reader.GetOrdinal("BOOKING");
			int persona_idColumnIndex = reader.GetOrdinal("PERSONA_ID");
			int clasificacion_idColumnIndex = reader.GetOrdinal("CLASIFICACION_ID");
			int itemColumnIndex = reader.GetOrdinal("ITEM");
			int mercaderia_internaColumnIndex = reader.GetOrdinal("MERCADERIA_INTERNA");
			int precinto_1ColumnIndex = reader.GetOrdinal("PRECINTO_1");
			int precinto_2ColumnIndex = reader.GetOrdinal("PRECINTO_2");
			int precinto_3ColumnIndex = reader.GetOrdinal("PRECINTO_3");
			int precinto_4ColumnIndex = reader.GetOrdinal("PRECINTO_4");
			int precinto_5ColumnIndex = reader.GetOrdinal("PRECINTO_5");
			int ediColumnIndex = reader.GetOrdinal("EDI");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int procesadoColumnIndex = reader.GetOrdinal("PROCESADO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int ventileteColumnIndex = reader.GetOrdinal("VENTILETE");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int tara_camionColumnIndex = reader.GetOrdinal("TARA_CAMION");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int pisoColumnIndex = reader.GetOrdinal("PISO");
			int fondoColumnIndex = reader.GetOrdinal("FONDO");
			int techoColumnIndex = reader.GetOrdinal("TECHO");
			int panel_derechoColumnIndex = reader.GetOrdinal("PANEL_DERECHO");
			int panel_izquierdoColumnIndex = reader.GetOrdinal("PANEL_IZQUIERDO");
			int puertaColumnIndex = reader.GetOrdinal("PUERTA");
			int refrigeradoColumnIndex = reader.GetOrdinal("REFRIGERADO");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CONTENEDORES_OPERACIONESRow record = new CONTENEDORES_OPERACIONESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(operacionColumnIndex))
						record.OPERACION = Convert.ToString(reader.GetValue(operacionColumnIndex));
					if(!reader.IsDBNull(fechaColumnIndex))
						record.FECHA = Convert.ToDateTime(reader.GetValue(fechaColumnIndex));
					if(!reader.IsDBNull(hora_inicioColumnIndex))
						record.HORA_INICIO = Convert.ToDateTime(reader.GetValue(hora_inicioColumnIndex));
					if(!reader.IsDBNull(hora_finColumnIndex))
						record.HORA_FIN = Convert.ToDateTime(reader.GetValue(hora_finColumnIndex));
					if(!reader.IsDBNull(nro_formularioColumnIndex))
						record.NRO_FORMULARIO = Convert.ToString(reader.GetValue(nro_formularioColumnIndex));
					if(!reader.IsDBNull(contenedor_idColumnIndex))
						record.CONTENEDOR_ID = Math.Round(Convert.ToDecimal(reader.GetValue(contenedor_idColumnIndex)), 9);
					if(!reader.IsDBNull(linea_idColumnIndex))
						record.LINEA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(linea_idColumnIndex)), 9);
					if(!reader.IsDBNull(cantidadColumnIndex))
						record.CANTIDAD = Math.Round(Convert.ToDecimal(reader.GetValue(cantidadColumnIndex)), 9);
					if(!reader.IsDBNull(bl_nroColumnIndex))
						record.BL_NRO = Convert.ToString(reader.GetValue(bl_nroColumnIndex));
					if(!reader.IsDBNull(bookingColumnIndex))
						record.BOOKING = Convert.ToString(reader.GetValue(bookingColumnIndex));
					if(!reader.IsDBNull(persona_idColumnIndex))
						record.PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(clasificacion_idColumnIndex))
						record.CLASIFICACION_ID = Convert.ToString(reader.GetValue(clasificacion_idColumnIndex));
					if(!reader.IsDBNull(itemColumnIndex))
						record.ITEM = Math.Round(Convert.ToDecimal(reader.GetValue(itemColumnIndex)), 9);
					if(!reader.IsDBNull(mercaderia_internaColumnIndex))
						record.MERCADERIA_INTERNA = Convert.ToString(reader.GetValue(mercaderia_internaColumnIndex));
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
					if(!reader.IsDBNull(ediColumnIndex))
						record.EDI = Convert.ToString(reader.GetValue(ediColumnIndex));
					if(!reader.IsDBNull(estadoColumnIndex))
						record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					if(!reader.IsDBNull(procesadoColumnIndex))
						record.PROCESADO = Convert.ToString(reader.GetValue(procesadoColumnIndex));
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					if(!reader.IsDBNull(ventileteColumnIndex))
						record.VENTILETE = Convert.ToString(reader.GetValue(ventileteColumnIndex));
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(tara_camionColumnIndex))
						record.TARA_CAMION = Math.Round(Convert.ToDecimal(reader.GetValue(tara_camionColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(pisoColumnIndex))
						record.PISO = Convert.ToString(reader.GetValue(pisoColumnIndex));
					if(!reader.IsDBNull(fondoColumnIndex))
						record.FONDO = Convert.ToString(reader.GetValue(fondoColumnIndex));
					if(!reader.IsDBNull(techoColumnIndex))
						record.TECHO = Convert.ToString(reader.GetValue(techoColumnIndex));
					if(!reader.IsDBNull(panel_derechoColumnIndex))
						record.PANEL_DERECHO = Convert.ToString(reader.GetValue(panel_derechoColumnIndex));
					if(!reader.IsDBNull(panel_izquierdoColumnIndex))
						record.PANEL_IZQUIERDO = Convert.ToString(reader.GetValue(panel_izquierdoColumnIndex));
					if(!reader.IsDBNull(puertaColumnIndex))
						record.PUERTA = Convert.ToString(reader.GetValue(puertaColumnIndex));
					if(!reader.IsDBNull(refrigeradoColumnIndex))
						record.REFRIGERADO = Convert.ToString(reader.GetValue(refrigeradoColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CONTENEDORES_OPERACIONESRow[])(recordList.ToArray(typeof(CONTENEDORES_OPERACIONESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CONTENEDORES_OPERACIONESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CONTENEDORES_OPERACIONESRow"/> object.</returns>
		protected virtual CONTENEDORES_OPERACIONESRow MapRow(DataRow row)
		{
			CONTENEDORES_OPERACIONESRow mappedObject = new CONTENEDORES_OPERACIONESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "OPERACION"
			dataColumn = dataTable.Columns["OPERACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OPERACION = (string)row[dataColumn];
			// Column "FECHA"
			dataColumn = dataTable.Columns["FECHA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA = (System.DateTime)row[dataColumn];
			// Column "HORA_INICIO"
			dataColumn = dataTable.Columns["HORA_INICIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_INICIO = (System.DateTime)row[dataColumn];
			// Column "HORA_FIN"
			dataColumn = dataTable.Columns["HORA_FIN"];
			if(!row.IsNull(dataColumn))
				mappedObject.HORA_FIN = (System.DateTime)row[dataColumn];
			// Column "NRO_FORMULARIO"
			dataColumn = dataTable.Columns["NRO_FORMULARIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_FORMULARIO = (string)row[dataColumn];
			// Column "CONTENEDOR_ID"
			dataColumn = dataTable.Columns["CONTENEDOR_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR_ID = (decimal)row[dataColumn];
			// Column "LINEA_ID"
			dataColumn = dataTable.Columns["LINEA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.LINEA_ID = (decimal)row[dataColumn];
			// Column "CANTIDAD"
			dataColumn = dataTable.Columns["CANTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.CANTIDAD = (decimal)row[dataColumn];
			// Column "BL_NRO"
			dataColumn = dataTable.Columns["BL_NRO"];
			if(!row.IsNull(dataColumn))
				mappedObject.BL_NRO = (string)row[dataColumn];
			// Column "BOOKING"
			dataColumn = dataTable.Columns["BOOKING"];
			if(!row.IsNull(dataColumn))
				mappedObject.BOOKING = (string)row[dataColumn];
			// Column "PERSONA_ID"
			dataColumn = dataTable.Columns["PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERSONA_ID = (decimal)row[dataColumn];
			// Column "CLASIFICACION_ID"
			dataColumn = dataTable.Columns["CLASIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CLASIFICACION_ID = (string)row[dataColumn];
			// Column "ITEM"
			dataColumn = dataTable.Columns["ITEM"];
			if(!row.IsNull(dataColumn))
				mappedObject.ITEM = (decimal)row[dataColumn];
			// Column "MERCADERIA_INTERNA"
			dataColumn = dataTable.Columns["MERCADERIA_INTERNA"];
			if(!row.IsNull(dataColumn))
				mappedObject.MERCADERIA_INTERNA = (string)row[dataColumn];
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
			// Column "EDI"
			dataColumn = dataTable.Columns["EDI"];
			if(!row.IsNull(dataColumn))
				mappedObject.EDI = (string)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "PROCESADO"
			dataColumn = dataTable.Columns["PROCESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PROCESADO = (string)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "VENTILETE"
			dataColumn = dataTable.Columns["VENTILETE"];
			if(!row.IsNull(dataColumn))
				mappedObject.VENTILETE = (string)row[dataColumn];
			// Column "PESO_BRUTO"
			dataColumn = dataTable.Columns["PESO_BRUTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_BRUTO = (decimal)row[dataColumn];
			// Column "TARA_CAMION"
			dataColumn = dataTable.Columns["TARA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CAMION = (decimal)row[dataColumn];
			// Column "PESO_NETO"
			dataColumn = dataTable.Columns["PESO_NETO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PESO_NETO = (decimal)row[dataColumn];
			// Column "TARA_CONTENEDOR"
			dataColumn = dataTable.Columns["TARA_CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA_CONTENEDOR = (decimal)row[dataColumn];
			// Column "PISO"
			dataColumn = dataTable.Columns["PISO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PISO = (string)row[dataColumn];
			// Column "FONDO"
			dataColumn = dataTable.Columns["FONDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FONDO = (string)row[dataColumn];
			// Column "TECHO"
			dataColumn = dataTable.Columns["TECHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TECHO = (string)row[dataColumn];
			// Column "PANEL_DERECHO"
			dataColumn = dataTable.Columns["PANEL_DERECHO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PANEL_DERECHO = (string)row[dataColumn];
			// Column "PANEL_IZQUIERDO"
			dataColumn = dataTable.Columns["PANEL_IZQUIERDO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PANEL_IZQUIERDO = (string)row[dataColumn];
			// Column "PUERTA"
			dataColumn = dataTable.Columns["PUERTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.PUERTA = (string)row[dataColumn];
			// Column "REFRIGERADO"
			dataColumn = dataTable.Columns["REFRIGERADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.REFRIGERADO = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CONTENEDORES_OPERACIONES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CONTENEDORES_OPERACIONES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OPERACION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("FECHA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("HORA_INICIO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("HORA_FIN", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("NRO_FORMULARIO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CONTENEDOR_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("LINEA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CANTIDAD", typeof(decimal));
			dataColumn = dataTable.Columns.Add("BL_NRO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("BOOKING", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CLASIFICACION_ID", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ITEM", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MERCADERIA_INTERNA", typeof(string));
			dataColumn.MaxLength = 500;
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
			dataColumn = dataTable.Columns.Add("EDI", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("PROCESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("VENTILETE", typeof(string));
			dataColumn.MaxLength = 20;
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_CAMION", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PISO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("FONDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("TECHO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("PANEL_DERECHO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("PANEL_IZQUIERDO", typeof(string));
			dataColumn.MaxLength = 400;
			dataColumn = dataTable.Columns.Add("PUERTA", typeof(string));
			dataColumn.MaxLength = 1500;
			dataColumn = dataTable.Columns.Add("REFRIGERADO", typeof(string));
			dataColumn.MaxLength = 400;
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

				case "OPERACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FECHA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "HORA_INICIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "HORA_FIN":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "NRO_FORMULARIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CONTENEDOR_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "LINEA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CANTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "BL_NRO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "BOOKING":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CLASIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ITEM":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MERCADERIA_INTERNA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "EDI":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PROCESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "VENTILETE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PESO_BRUTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PESO_NETO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA_CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PISO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "FONDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TECHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PANEL_DERECHO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PANEL_IZQUIERDO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "PUERTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "REFRIGERADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CONTENEDORES_OPERACIONESCollection_Base class
}  // End of namespace
