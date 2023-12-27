// <fileinfo name="TRAMITES_MEDIDAS_CAUTELARESCollection_Base.cs">
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
	/// The base class for <see cref="TRAMITES_MEDIDAS_CAUTELARESCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TRAMITES_MEDIDAS_CAUTELARESCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_MEDIDAS_CAUTELARESCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TEXTO_PREDEFINIDO_ID_TIPOColumnName = "TEXTO_PREDEFINIDO_ID_TIPO";
		public const string OBSERVACIONColumnName = "OBSERVACION";
		public const string TRAMITE_IDColumnName = "TRAMITE_ID";
		public const string FECHA_OTORGAMIENTOColumnName = "FECHA_OTORGAMIENTO";
		public const string FECHA_INSCRIPCIONColumnName = "FECHA_INSCRIPCION";
		public const string MONTO_EMBARGADOColumnName = "MONTO_EMBARGADO";
		public const string NRO_CUENTA_BANCARIAColumnName = "NRO_CUENTA_BANCARIA";
		public const string ENTIDADColumnName = "ENTIDAD";
		public const string CUENTAColumnName = "CUENTA";
		public const string TEXTO_PREDEFINIDO_ID_BIENColumnName = "TEXTO_PREDEFINIDO_ID_BIEN";
		public const string DATOS_DEL_BIENColumnName = "DATOS_DEL_BIEN";
		public const string OTROS_EMBARGOS_BIENColumnName = "OTROS_EMBARGOS_BIEN";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_MEDIDAS_CAUTELARESCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TRAMITES_MEDIDAS_CAUTELARESCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		public virtual TRAMITES_MEDIDAS_CAUTELARESRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TRAMITES_MEDIDAS_CAUTELARESRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TRAMITES_MEDIDAS_CAUTELARESRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		public TRAMITES_MEDIDAS_CAUTELARESRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects that 
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
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		public virtual TRAMITES_MEDIDAS_CAUTELARESRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TRAMITES_MEDIDAS_CAUTELARES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TRAMITES_MEDIDAS_CAUTELARESRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TRAMITES_MEDIDAS_CAUTELARESRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects 
		/// by the <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		public TRAMITES_MEDIDAS_CAUTELARESRow[] GetByTEXTO_PREDEFINIDO_ID_BIEN(decimal texto_predefinido_id_bien)
		{
			return GetByTEXTO_PREDEFINIDO_ID_BIEN(texto_predefinido_id_bien, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects 
		/// by the <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <param name="texto_predefinido_id_bienNull">true if the method ignores the texto_predefinido_id_bien
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		public virtual TRAMITES_MEDIDAS_CAUTELARESRow[] GetByTEXTO_PREDEFINIDO_ID_BIEN(decimal texto_predefinido_id_bien, bool texto_predefinido_id_bienNull)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_ID_BIENCommand(texto_predefinido_id_bien, texto_predefinido_id_bienNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTEXTO_PREDEFINIDO_ID_BIENAsDataTable(decimal texto_predefinido_id_bien)
		{
			return GetByTEXTO_PREDEFINIDO_ID_BIENAsDataTable(texto_predefinido_id_bien, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <param name="texto_predefinido_id_bienNull">true if the method ignores the texto_predefinido_id_bien
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_ID_BIENAsDataTable(decimal texto_predefinido_id_bien, bool texto_predefinido_id_bienNull)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_ID_BIENCommand(texto_predefinido_id_bien, texto_predefinido_id_bienNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <param name="texto_predefinido_id_bienNull">true if the method ignores the texto_predefinido_id_bien
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_ID_BIENCommand(decimal texto_predefinido_id_bien, bool texto_predefinido_id_bienNull)
		{
			string whereSql = "";
			if(texto_predefinido_id_bienNull)
				whereSql += "TEXTO_PREDEFINIDO_ID_BIEN IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID_BIEN=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_BIEN");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!texto_predefinido_id_bienNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_BIEN", texto_predefinido_id_bien);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects 
		/// by the <c>FK_TRAMIT_MED_CAUT_TEXT_ID_TIP</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_tipo">The <c>TEXTO_PREDEFINIDO_ID_TIPO</c> column value.</param>
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		public virtual TRAMITES_MEDIDAS_CAUTELARESRow[] GetByTEXTO_PREDEFINIDO_ID_TIPO(decimal texto_predefinido_id_tipo)
		{
			return MapRecords(CreateGetByTEXTO_PREDEFINIDO_ID_TIPOCommand(texto_predefinido_id_tipo));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAMIT_MED_CAUT_TEXT_ID_TIP</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_tipo">The <c>TEXTO_PREDEFINIDO_ID_TIPO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTEXTO_PREDEFINIDO_ID_TIPOAsDataTable(decimal texto_predefinido_id_tipo)
		{
			return MapRecordsToDataTable(CreateGetByTEXTO_PREDEFINIDO_ID_TIPOCommand(texto_predefinido_id_tipo));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAMIT_MED_CAUT_TEXT_ID_TIP</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_tipo">The <c>TEXTO_PREDEFINIDO_ID_TIPO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTEXTO_PREDEFINIDO_ID_TIPOCommand(decimal texto_predefinido_id_tipo)
		{
			string whereSql = "";
			whereSql += "TEXTO_PREDEFINIDO_ID_TIPO=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_TIPO");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_TIPO", texto_predefinido_id_tipo);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects 
		/// by the <c>FK_TRAMIT_MED_CAUT_TRAMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_id">The <c>TRAMITE_ID</c> column value.</param>
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		public virtual TRAMITES_MEDIDAS_CAUTELARESRow[] GetByTRAMITE_ID(decimal tramite_id)
		{
			return MapRecords(CreateGetByTRAMITE_IDCommand(tramite_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TRAMIT_MED_CAUT_TRAMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_id">The <c>TRAMITE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTRAMITE_IDAsDataTable(decimal tramite_id)
		{
			return MapRecordsToDataTable(CreateGetByTRAMITE_IDCommand(tramite_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TRAMIT_MED_CAUT_TRAMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_id">The <c>TRAMITE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTRAMITE_IDCommand(decimal tramite_id)
		{
			string whereSql = "";
			whereSql += "TRAMITE_ID=" + _db.CreateSqlParameterName("TRAMITE_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TRAMITE_ID", tramite_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> object to be inserted.</param>
		public virtual void Insert(TRAMITES_MEDIDAS_CAUTELARESRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TRAMITES_MEDIDAS_CAUTELARES (" +
				"ID, " +
				"TEXTO_PREDEFINIDO_ID_TIPO, " +
				"OBSERVACION, " +
				"TRAMITE_ID, " +
				"FECHA_OTORGAMIENTO, " +
				"FECHA_INSCRIPCION, " +
				"MONTO_EMBARGADO, " +
				"NRO_CUENTA_BANCARIA, " +
				"ENTIDAD, " +
				"CUENTA, " +
				"TEXTO_PREDEFINIDO_ID_BIEN, " +
				"DATOS_DEL_BIEN, " +
				"OTROS_EMBARGOS_BIEN" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_TIPO") + ", " +
				_db.CreateSqlParameterName("OBSERVACION") + ", " +
				_db.CreateSqlParameterName("TRAMITE_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_OTORGAMIENTO") + ", " +
				_db.CreateSqlParameterName("FECHA_INSCRIPCION") + ", " +
				_db.CreateSqlParameterName("MONTO_EMBARGADO") + ", " +
				_db.CreateSqlParameterName("NRO_CUENTA_BANCARIA") + ", " +
				_db.CreateSqlParameterName("ENTIDAD") + ", " +
				_db.CreateSqlParameterName("CUENTA") + ", " +
				_db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_BIEN") + ", " +
				_db.CreateSqlParameterName("DATOS_DEL_BIEN") + ", " +
				_db.CreateSqlParameterName("OTROS_EMBARGOS_BIEN") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_TIPO", value.TEXTO_PREDEFINIDO_ID_TIPO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TRAMITE_ID", value.TRAMITE_ID);
			AddParameter(cmd, "FECHA_OTORGAMIENTO",
				value.IsFECHA_OTORGAMIENTONull ? DBNull.Value : (object)value.FECHA_OTORGAMIENTO);
			AddParameter(cmd, "FECHA_INSCRIPCION", value.FECHA_INSCRIPCION);
			AddParameter(cmd, "MONTO_EMBARGADO",
				value.IsMONTO_EMBARGADONull ? DBNull.Value : (object)value.MONTO_EMBARGADO);
			AddParameter(cmd, "NRO_CUENTA_BANCARIA", value.NRO_CUENTA_BANCARIA);
			AddParameter(cmd, "ENTIDAD", value.ENTIDAD);
			AddParameter(cmd, "CUENTA", value.CUENTA);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_BIEN",
				value.IsTEXTO_PREDEFINIDO_ID_BIENNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID_BIEN);
			AddParameter(cmd, "DATOS_DEL_BIEN", value.DATOS_DEL_BIEN);
			AddParameter(cmd, "OTROS_EMBARGOS_BIEN", value.OTROS_EMBARGOS_BIEN);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TRAMITES_MEDIDAS_CAUTELARESRow value)
		{
			
			string sqlStr = "UPDATE TRC.TRAMITES_MEDIDAS_CAUTELARES SET " +
				"TEXTO_PREDEFINIDO_ID_TIPO=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_TIPO") + ", " +
				"OBSERVACION=" + _db.CreateSqlParameterName("OBSERVACION") + ", " +
				"TRAMITE_ID=" + _db.CreateSqlParameterName("TRAMITE_ID") + ", " +
				"FECHA_OTORGAMIENTO=" + _db.CreateSqlParameterName("FECHA_OTORGAMIENTO") + ", " +
				"FECHA_INSCRIPCION=" + _db.CreateSqlParameterName("FECHA_INSCRIPCION") + ", " +
				"MONTO_EMBARGADO=" + _db.CreateSqlParameterName("MONTO_EMBARGADO") + ", " +
				"NRO_CUENTA_BANCARIA=" + _db.CreateSqlParameterName("NRO_CUENTA_BANCARIA") + ", " +
				"ENTIDAD=" + _db.CreateSqlParameterName("ENTIDAD") + ", " +
				"CUENTA=" + _db.CreateSqlParameterName("CUENTA") + ", " +
				"TEXTO_PREDEFINIDO_ID_BIEN=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_BIEN") + ", " +
				"DATOS_DEL_BIEN=" + _db.CreateSqlParameterName("DATOS_DEL_BIEN") + ", " +
				"OTROS_EMBARGOS_BIEN=" + _db.CreateSqlParameterName("OTROS_EMBARGOS_BIEN") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_TIPO", value.TEXTO_PREDEFINIDO_ID_TIPO);
			AddParameter(cmd, "OBSERVACION", value.OBSERVACION);
			AddParameter(cmd, "TRAMITE_ID", value.TRAMITE_ID);
			AddParameter(cmd, "FECHA_OTORGAMIENTO",
				value.IsFECHA_OTORGAMIENTONull ? DBNull.Value : (object)value.FECHA_OTORGAMIENTO);
			AddParameter(cmd, "FECHA_INSCRIPCION", value.FECHA_INSCRIPCION);
			AddParameter(cmd, "MONTO_EMBARGADO",
				value.IsMONTO_EMBARGADONull ? DBNull.Value : (object)value.MONTO_EMBARGADO);
			AddParameter(cmd, "NRO_CUENTA_BANCARIA", value.NRO_CUENTA_BANCARIA);
			AddParameter(cmd, "ENTIDAD", value.ENTIDAD);
			AddParameter(cmd, "CUENTA", value.CUENTA);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_BIEN",
				value.IsTEXTO_PREDEFINIDO_ID_BIENNull ? DBNull.Value : (object)value.TEXTO_PREDEFINIDO_ID_BIEN);
			AddParameter(cmd, "DATOS_DEL_BIEN", value.DATOS_DEL_BIEN);
			AddParameter(cmd, "OTROS_EMBARGOS_BIEN", value.OTROS_EMBARGOS_BIEN);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TRAMITES_MEDIDAS_CAUTELARESRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table using
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
		/// Deletes records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table using the 
		/// <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID_BIEN(decimal texto_predefinido_id_bien)
		{
			return DeleteByTEXTO_PREDEFINIDO_ID_BIEN(texto_predefinido_id_bien, false);
		}

		/// <summary>
		/// Deletes records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table using the 
		/// <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <param name="texto_predefinido_id_bienNull">true if the method ignores the texto_predefinido_id_bien
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID_BIEN(decimal texto_predefinido_id_bien, bool texto_predefinido_id_bienNull)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_ID_BIENCommand(texto_predefinido_id_bien, texto_predefinido_id_bienNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAM_MED_CAUT_TEXT_ID_BIEN</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_bien">The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</param>
		/// <param name="texto_predefinido_id_bienNull">true if the method ignores the texto_predefinido_id_bien
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_ID_BIENCommand(decimal texto_predefinido_id_bien, bool texto_predefinido_id_bienNull)
		{
			string whereSql = "";
			if(texto_predefinido_id_bienNull)
				whereSql += "TEXTO_PREDEFINIDO_ID_BIEN IS NULL";
			else
				whereSql += "TEXTO_PREDEFINIDO_ID_BIEN=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_BIEN");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!texto_predefinido_id_bienNull)
				AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_BIEN", texto_predefinido_id_bien);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table using the 
		/// <c>FK_TRAMIT_MED_CAUT_TEXT_ID_TIP</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_tipo">The <c>TEXTO_PREDEFINIDO_ID_TIPO</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTEXTO_PREDEFINIDO_ID_TIPO(decimal texto_predefinido_id_tipo)
		{
			return CreateDeleteByTEXTO_PREDEFINIDO_ID_TIPOCommand(texto_predefinido_id_tipo).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAMIT_MED_CAUT_TEXT_ID_TIP</c> foreign key.
		/// </summary>
		/// <param name="texto_predefinido_id_tipo">The <c>TEXTO_PREDEFINIDO_ID_TIPO</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTEXTO_PREDEFINIDO_ID_TIPOCommand(decimal texto_predefinido_id_tipo)
		{
			string whereSql = "";
			whereSql += "TEXTO_PREDEFINIDO_ID_TIPO=" + _db.CreateSqlParameterName("TEXTO_PREDEFINIDO_ID_TIPO");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TEXTO_PREDEFINIDO_ID_TIPO", texto_predefinido_id_tipo);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table using the 
		/// <c>FK_TRAMIT_MED_CAUT_TRAMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_id">The <c>TRAMITE_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRAMITE_ID(decimal tramite_id)
		{
			return CreateDeleteByTRAMITE_IDCommand(tramite_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TRAMIT_MED_CAUT_TRAMIT_ID</c> foreign key.
		/// </summary>
		/// <param name="tramite_id">The <c>TRAMITE_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTRAMITE_IDCommand(decimal tramite_id)
		{
			string whereSql = "";
			whereSql += "TRAMITE_ID=" + _db.CreateSqlParameterName("TRAMITE_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TRAMITE_ID", tramite_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TRAMITES_MEDIDAS_CAUTELARES</c> records that match the specified criteria.
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
		/// to delete <c>TRAMITES_MEDIDAS_CAUTELARES</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TRAMITES_MEDIDAS_CAUTELARES";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
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
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		protected TRAMITES_MEDIDAS_CAUTELARESRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		protected TRAMITES_MEDIDAS_CAUTELARESRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> objects.</returns>
		protected virtual TRAMITES_MEDIDAS_CAUTELARESRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int texto_predefinido_id_tipoColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID_TIPO");
			int observacionColumnIndex = reader.GetOrdinal("OBSERVACION");
			int tramite_idColumnIndex = reader.GetOrdinal("TRAMITE_ID");
			int fecha_otorgamientoColumnIndex = reader.GetOrdinal("FECHA_OTORGAMIENTO");
			int fecha_inscripcionColumnIndex = reader.GetOrdinal("FECHA_INSCRIPCION");
			int monto_embargadoColumnIndex = reader.GetOrdinal("MONTO_EMBARGADO");
			int nro_cuenta_bancariaColumnIndex = reader.GetOrdinal("NRO_CUENTA_BANCARIA");
			int entidadColumnIndex = reader.GetOrdinal("ENTIDAD");
			int cuentaColumnIndex = reader.GetOrdinal("CUENTA");
			int texto_predefinido_id_bienColumnIndex = reader.GetOrdinal("TEXTO_PREDEFINIDO_ID_BIEN");
			int datos_del_bienColumnIndex = reader.GetOrdinal("DATOS_DEL_BIEN");
			int otros_embargos_bienColumnIndex = reader.GetOrdinal("OTROS_EMBARGOS_BIEN");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TRAMITES_MEDIDAS_CAUTELARESRow record = new TRAMITES_MEDIDAS_CAUTELARESRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TEXTO_PREDEFINIDO_ID_TIPO = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_id_tipoColumnIndex)), 9);
					if(!reader.IsDBNull(observacionColumnIndex))
						record.OBSERVACION = Convert.ToString(reader.GetValue(observacionColumnIndex));
					record.TRAMITE_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tramite_idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_otorgamientoColumnIndex))
						record.FECHA_OTORGAMIENTO = Convert.ToDateTime(reader.GetValue(fecha_otorgamientoColumnIndex));
					record.FECHA_INSCRIPCION = Convert.ToDateTime(reader.GetValue(fecha_inscripcionColumnIndex));
					if(!reader.IsDBNull(monto_embargadoColumnIndex))
						record.MONTO_EMBARGADO = Math.Round(Convert.ToDecimal(reader.GetValue(monto_embargadoColumnIndex)), 9);
					if(!reader.IsDBNull(nro_cuenta_bancariaColumnIndex))
						record.NRO_CUENTA_BANCARIA = Convert.ToString(reader.GetValue(nro_cuenta_bancariaColumnIndex));
					if(!reader.IsDBNull(entidadColumnIndex))
						record.ENTIDAD = Convert.ToString(reader.GetValue(entidadColumnIndex));
					if(!reader.IsDBNull(cuentaColumnIndex))
						record.CUENTA = Convert.ToString(reader.GetValue(cuentaColumnIndex));
					if(!reader.IsDBNull(texto_predefinido_id_bienColumnIndex))
						record.TEXTO_PREDEFINIDO_ID_BIEN = Math.Round(Convert.ToDecimal(reader.GetValue(texto_predefinido_id_bienColumnIndex)), 9);
					if(!reader.IsDBNull(datos_del_bienColumnIndex))
						record.DATOS_DEL_BIEN = Convert.ToString(reader.GetValue(datos_del_bienColumnIndex));
					if(!reader.IsDBNull(otros_embargos_bienColumnIndex))
						record.OTROS_EMBARGOS_BIEN = Convert.ToString(reader.GetValue(otros_embargos_bienColumnIndex));

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TRAMITES_MEDIDAS_CAUTELARESRow[])(recordList.ToArray(typeof(TRAMITES_MEDIDAS_CAUTELARESRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TRAMITES_MEDIDAS_CAUTELARESRow"/> object.</returns>
		protected virtual TRAMITES_MEDIDAS_CAUTELARESRow MapRow(DataRow row)
		{
			TRAMITES_MEDIDAS_CAUTELARESRow mappedObject = new TRAMITES_MEDIDAS_CAUTELARESRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID_TIPO"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID_TIPO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID_TIPO = (decimal)row[dataColumn];
			// Column "OBSERVACION"
			dataColumn = dataTable.Columns["OBSERVACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBSERVACION = (string)row[dataColumn];
			// Column "TRAMITE_ID"
			dataColumn = dataTable.Columns["TRAMITE_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRAMITE_ID = (decimal)row[dataColumn];
			// Column "FECHA_OTORGAMIENTO"
			dataColumn = dataTable.Columns["FECHA_OTORGAMIENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_OTORGAMIENTO = (System.DateTime)row[dataColumn];
			// Column "FECHA_INSCRIPCION"
			dataColumn = dataTable.Columns["FECHA_INSCRIPCION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_INSCRIPCION = (System.DateTime)row[dataColumn];
			// Column "MONTO_EMBARGADO"
			dataColumn = dataTable.Columns["MONTO_EMBARGADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MONTO_EMBARGADO = (decimal)row[dataColumn];
			// Column "NRO_CUENTA_BANCARIA"
			dataColumn = dataTable.Columns["NRO_CUENTA_BANCARIA"];
			if(!row.IsNull(dataColumn))
				mappedObject.NRO_CUENTA_BANCARIA = (string)row[dataColumn];
			// Column "ENTIDAD"
			dataColumn = dataTable.Columns["ENTIDAD"];
			if(!row.IsNull(dataColumn))
				mappedObject.ENTIDAD = (string)row[dataColumn];
			// Column "CUENTA"
			dataColumn = dataTable.Columns["CUENTA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CUENTA = (string)row[dataColumn];
			// Column "TEXTO_PREDEFINIDO_ID_BIEN"
			dataColumn = dataTable.Columns["TEXTO_PREDEFINIDO_ID_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.TEXTO_PREDEFINIDO_ID_BIEN = (decimal)row[dataColumn];
			// Column "DATOS_DEL_BIEN"
			dataColumn = dataTable.Columns["DATOS_DEL_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.DATOS_DEL_BIEN = (string)row[dataColumn];
			// Column "OTROS_EMBARGOS_BIEN"
			dataColumn = dataTable.Columns["OTROS_EMBARGOS_BIEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.OTROS_EMBARGOS_BIEN = (string)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TRAMITES_MEDIDAS_CAUTELARES</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TRAMITES_MEDIDAS_CAUTELARES";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID_TIPO", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBSERVACION", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("TRAMITE_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_OTORGAMIENTO", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("FECHA_INSCRIPCION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("MONTO_EMBARGADO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("NRO_CUENTA_BANCARIA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("ENTIDAD", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("CUENTA", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("TEXTO_PREDEFINIDO_ID_BIEN", typeof(decimal));
			dataColumn = dataTable.Columns.Add("DATOS_DEL_BIEN", typeof(string));
			dataColumn.MaxLength = 500;
			dataColumn = dataTable.Columns.Add("OTROS_EMBARGOS_BIEN", typeof(string));
			dataColumn.MaxLength = 500;
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

				case "TEXTO_PREDEFINIDO_ID_TIPO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "OBSERVACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRAMITE_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_OTORGAMIENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "FECHA_INSCRIPCION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "MONTO_EMBARGADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NRO_CUENTA_BANCARIA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "ENTIDAD":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CUENTA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TEXTO_PREDEFINIDO_ID_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "DATOS_DEL_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "OTROS_EMBARGOS_BIEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TRAMITES_MEDIDAS_CAUTELARESCollection_Base class
}  // End of namespace
