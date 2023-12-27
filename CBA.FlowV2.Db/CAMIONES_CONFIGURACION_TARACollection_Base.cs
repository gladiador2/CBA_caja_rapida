// <fileinfo name="CAMIONES_CONFIGURACION_TARACollection_Base.cs">
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
	/// The base class for <see cref="CAMIONES_CONFIGURACION_TARACollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="CAMIONES_CONFIGURACION_TARACollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CAMIONES_CONFIGURACION_TARACollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string FECHA_HORAColumnName = "FECHA_HORA";
		public const string USUARIO_IDColumnName = "USUARIO_ID";
		public const string TARAColumnName = "TARA";
		public const string CHAPA_CAMIONColumnName = "CHAPA_CAMION";
		public const string CHAPA_CARRETAColumnName = "CHAPA_CARRETA";
		public const string CHOFER_DOCUMENTOColumnName = "CHOFER_DOCUMENTO";
		public const string CHOFER_NOMBREColumnName = "CHOFER_NOMBRE";
		public const string TARA_CONTENEDORColumnName = "TARA_CONTENEDOR";
		public const string PESO_BRUTOColumnName = "PESO_BRUTO";
		public const string PESO_NETOColumnName = "PESO_NETO";
		public const string SIN_CARGAColumnName = "SIN_CARGA";
		public const string CONTENEDORColumnName = "CONTENEDOR";
		public const string TRANSPORTADORA_PERSONA_IDColumnName = "TRANSPORTADORA_PERSONA_ID";
		public const string TRANSPORTADORA_NOMBREColumnName = "TRANSPORTADORA_NOMBRE";
		public const string TIPO_VEHICULO_IDColumnName = "TIPO_VEHICULO_ID";
		public const string CONSIGNATARIO_PERSONA_IDColumnName = "CONSIGNATARIO_PERSONA_ID";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="CAMIONES_CONFIGURACION_TARACollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public CAMIONES_CONFIGURACION_TARACollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>CAMIONES_CONFIGURACION_TARA</c> table.
		/// </summary>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public virtual CAMIONES_CONFIGURACION_TARARow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>CAMIONES_CONFIGURACION_TARA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>CAMIONES_CONFIGURACION_TARA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="CAMIONES_CONFIGURACION_TARARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public CAMIONES_CONFIGURACION_TARARow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			CAMIONES_CONFIGURACION_TARARow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public CAMIONES_CONFIGURACION_TARARow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects that 
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
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public virtual CAMIONES_CONFIGURACION_TARARow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.CAMIONES_CONFIGURACION_TARA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="CAMIONES_CONFIGURACION_TARARow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="CAMIONES_CONFIGURACION_TARARow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual CAMIONES_CONFIGURACION_TARARow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			CAMIONES_CONFIGURACION_TARARow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public CAMIONES_CONFIGURACION_TARARow[] GetByTIPO_VEHICULO_ID(decimal tipo_vehiculo_id)
		{
			return GetByTIPO_VEHICULO_ID(tipo_vehiculo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <param name="tipo_vehiculo_idNull">true if the method ignores the tipo_vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public virtual CAMIONES_CONFIGURACION_TARARow[] GetByTIPO_VEHICULO_ID(decimal tipo_vehiculo_id, bool tipo_vehiculo_idNull)
		{
			return MapRecords(CreateGetByTIPO_VEHICULO_IDCommand(tipo_vehiculo_id, tipo_vehiculo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTIPO_VEHICULO_IDAsDataTable(decimal tipo_vehiculo_id)
		{
			return GetByTIPO_VEHICULO_IDAsDataTable(tipo_vehiculo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <param name="tipo_vehiculo_idNull">true if the method ignores the tipo_vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTIPO_VEHICULO_IDAsDataTable(decimal tipo_vehiculo_id, bool tipo_vehiculo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTIPO_VEHICULO_IDCommand(tipo_vehiculo_id, tipo_vehiculo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <param name="tipo_vehiculo_idNull">true if the method ignores the tipo_vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTIPO_VEHICULO_IDCommand(decimal tipo_vehiculo_id, bool tipo_vehiculo_idNull)
		{
			string whereSql = "";
			if(tipo_vehiculo_idNull)
				whereSql += "TIPO_VEHICULO_ID IS NULL";
			else
				whereSql += "TIPO_VEHICULO_ID=" + _db.CreateSqlParameterName("TIPO_VEHICULO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tipo_vehiculo_idNull)
				AddParameter(cmd, "TIPO_VEHICULO_ID", tipo_vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public CAMIONES_CONFIGURACION_TARARow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <param name="consignatario_persona_idNull">true if the method ignores the consignatario_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public virtual CAMIONES_CONFIGURACION_TARARow[] GetByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id, bool consignatario_persona_idNull)
		{
			return MapRecords(CreateGetByCONSIGNATARIO_PERSONA_IDCommand(consignatario_persona_id, consignatario_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByCONSIGNATARIO_PERSONA_IDAsDataTable(decimal consignatario_persona_id)
		{
			return GetByCONSIGNATARIO_PERSONA_IDAsDataTable(consignatario_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
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
		/// return records by the <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
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
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public CAMIONES_CONFIGURACION_TARARow[] GetByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id)
		{
			return GetByTRANSPORTADORA_PERSONA_ID(transportadora_persona_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <param name="transportadora_persona_idNull">true if the method ignores the transportadora_persona_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public virtual CAMIONES_CONFIGURACION_TARARow[] GetByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id, bool transportadora_persona_idNull)
		{
			return MapRecords(CreateGetByTRANSPORTADORA_PERSONA_IDCommand(transportadora_persona_id, transportadora_persona_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTRANSPORTADORA_PERSONA_IDAsDataTable(decimal transportadora_persona_id)
		{
			return GetByTRANSPORTADORA_PERSONA_IDAsDataTable(transportadora_persona_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
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
		/// return records by the <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
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
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public CAMIONES_CONFIGURACION_TARARow[] GetByUSUARIO_ID(decimal usuario_id)
		{
			return GetByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects 
		/// by the <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		public virtual CAMIONES_CONFIGURACION_TARARow[] GetByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecords(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id)
		{
			return GetByUSUARIO_IDAsDataTable(usuario_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_IDAsDataTable(decimal usuario_id, bool usuario_idNull)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_IDCommand(usuario_id, usuario_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>CAMIONES_CONFIGURACION_TARA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CAMIONES_CONFIGURACION_TARARow"/> object to be inserted.</param>
		public virtual void Insert(CAMIONES_CONFIGURACION_TARARow value)
		{
						
			string sqlStr = "INSERT INTO TRC.CAMIONES_CONFIGURACION_TARA (" +
				"ID, " +
				"FECHA_HORA, " +
				"USUARIO_ID, " +
				"TARA, " +
				"CHAPA_CAMION, " +
				"CHAPA_CARRETA, " +
				"CHOFER_DOCUMENTO, " +
				"CHOFER_NOMBRE, " +
				"TARA_CONTENEDOR, " +
				"PESO_BRUTO, " +
				"PESO_NETO, " +
				"SIN_CARGA, " +
				"CONTENEDOR, " +
				"TRANSPORTADORA_PERSONA_ID, " +
				"TRANSPORTADORA_NOMBRE, " +
				"TIPO_VEHICULO_ID, " +
				"CONSIGNATARIO_PERSONA_ID" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("FECHA_HORA") + ", " +
				_db.CreateSqlParameterName("USUARIO_ID") + ", " +
				_db.CreateSqlParameterName("TARA") + ", " +
				_db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				_db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				_db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				_db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				_db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				_db.CreateSqlParameterName("PESO_NETO") + ", " +
				_db.CreateSqlParameterName("SIN_CARGA") + ", " +
				_db.CreateSqlParameterName("CONTENEDOR") + ", " +
				_db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID") + ", " +
				_db.CreateSqlParameterName("TRANSPORTADORA_NOMBRE") + ", " +
				_db.CreateSqlParameterName("TIPO_VEHICULO_ID") + ", " +
				_db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "FECHA_HORA",
				value.IsFECHA_HORANull ? DBNull.Value : (object)value.FECHA_HORA);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "TARA",
				value.IsTARANull ? DBNull.Value : (object)value.TARA);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "SIN_CARGA", value.SIN_CARGA);
			AddParameter(cmd, "CONTENEDOR", value.CONTENEDOR);
			AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID",
				value.IsTRANSPORTADORA_PERSONA_IDNull ? DBNull.Value : (object)value.TRANSPORTADORA_PERSONA_ID);
			AddParameter(cmd, "TRANSPORTADORA_NOMBRE", value.TRANSPORTADORA_NOMBRE);
			AddParameter(cmd, "TIPO_VEHICULO_ID",
				value.IsTIPO_VEHICULO_IDNull ? DBNull.Value : (object)value.TIPO_VEHICULO_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>CAMIONES_CONFIGURACION_TARA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CAMIONES_CONFIGURACION_TARARow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(CAMIONES_CONFIGURACION_TARARow value)
		{
			
			string sqlStr = "UPDATE TRC.CAMIONES_CONFIGURACION_TARA SET " +
				"FECHA_HORA=" + _db.CreateSqlParameterName("FECHA_HORA") + ", " +
				"USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID") + ", " +
				"TARA=" + _db.CreateSqlParameterName("TARA") + ", " +
				"CHAPA_CAMION=" + _db.CreateSqlParameterName("CHAPA_CAMION") + ", " +
				"CHAPA_CARRETA=" + _db.CreateSqlParameterName("CHAPA_CARRETA") + ", " +
				"CHOFER_DOCUMENTO=" + _db.CreateSqlParameterName("CHOFER_DOCUMENTO") + ", " +
				"CHOFER_NOMBRE=" + _db.CreateSqlParameterName("CHOFER_NOMBRE") + ", " +
				"TARA_CONTENEDOR=" + _db.CreateSqlParameterName("TARA_CONTENEDOR") + ", " +
				"PESO_BRUTO=" + _db.CreateSqlParameterName("PESO_BRUTO") + ", " +
				"PESO_NETO=" + _db.CreateSqlParameterName("PESO_NETO") + ", " +
				"SIN_CARGA=" + _db.CreateSqlParameterName("SIN_CARGA") + ", " +
				"CONTENEDOR=" + _db.CreateSqlParameterName("CONTENEDOR") + ", " +
				"TRANSPORTADORA_PERSONA_ID=" + _db.CreateSqlParameterName("TRANSPORTADORA_PERSONA_ID") + ", " +
				"TRANSPORTADORA_NOMBRE=" + _db.CreateSqlParameterName("TRANSPORTADORA_NOMBRE") + ", " +
				"TIPO_VEHICULO_ID=" + _db.CreateSqlParameterName("TIPO_VEHICULO_ID") + ", " +
				"CONSIGNATARIO_PERSONA_ID=" + _db.CreateSqlParameterName("CONSIGNATARIO_PERSONA_ID") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "FECHA_HORA",
				value.IsFECHA_HORANull ? DBNull.Value : (object)value.FECHA_HORA);
			AddParameter(cmd, "USUARIO_ID",
				value.IsUSUARIO_IDNull ? DBNull.Value : (object)value.USUARIO_ID);
			AddParameter(cmd, "TARA",
				value.IsTARANull ? DBNull.Value : (object)value.TARA);
			AddParameter(cmd, "CHAPA_CAMION", value.CHAPA_CAMION);
			AddParameter(cmd, "CHAPA_CARRETA", value.CHAPA_CARRETA);
			AddParameter(cmd, "CHOFER_DOCUMENTO", value.CHOFER_DOCUMENTO);
			AddParameter(cmd, "CHOFER_NOMBRE", value.CHOFER_NOMBRE);
			AddParameter(cmd, "TARA_CONTENEDOR",
				value.IsTARA_CONTENEDORNull ? DBNull.Value : (object)value.TARA_CONTENEDOR);
			AddParameter(cmd, "PESO_BRUTO",
				value.IsPESO_BRUTONull ? DBNull.Value : (object)value.PESO_BRUTO);
			AddParameter(cmd, "PESO_NETO",
				value.IsPESO_NETONull ? DBNull.Value : (object)value.PESO_NETO);
			AddParameter(cmd, "SIN_CARGA", value.SIN_CARGA);
			AddParameter(cmd, "CONTENEDOR", value.CONTENEDOR);
			AddParameter(cmd, "TRANSPORTADORA_PERSONA_ID",
				value.IsTRANSPORTADORA_PERSONA_IDNull ? DBNull.Value : (object)value.TRANSPORTADORA_PERSONA_ID);
			AddParameter(cmd, "TRANSPORTADORA_NOMBRE", value.TRANSPORTADORA_NOMBRE);
			AddParameter(cmd, "TIPO_VEHICULO_ID",
				value.IsTIPO_VEHICULO_IDNull ? DBNull.Value : (object)value.TIPO_VEHICULO_ID);
			AddParameter(cmd, "CONSIGNATARIO_PERSONA_ID",
				value.IsCONSIGNATARIO_PERSONA_IDNull ? DBNull.Value : (object)value.CONSIGNATARIO_PERSONA_ID);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>CAMIONES_CONFIGURACION_TARA</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>CAMIONES_CONFIGURACION_TARA</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>CAMIONES_CONFIGURACION_TARA</c> table.
		/// </summary>
		/// <param name="value">The <see cref="CAMIONES_CONFIGURACION_TARARow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(CAMIONES_CONFIGURACION_TARARow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>CAMIONES_CONFIGURACION_TARA</c> table using
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
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_VEHICULO_ID(decimal tipo_vehiculo_id)
		{
			return DeleteByTIPO_VEHICULO_ID(tipo_vehiculo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <param name="tipo_vehiculo_idNull">true if the method ignores the tipo_vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTIPO_VEHICULO_ID(decimal tipo_vehiculo_id, bool tipo_vehiculo_idNull)
		{
			return CreateDeleteByTIPO_VEHICULO_IDCommand(tipo_vehiculo_id, tipo_vehiculo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CAMIONES_CONF_TARA_CAM_ID</c> foreign key.
		/// </summary>
		/// <param name="tipo_vehiculo_id">The <c>TIPO_VEHICULO_ID</c> column value.</param>
		/// <param name="tipo_vehiculo_idNull">true if the method ignores the tipo_vehiculo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTIPO_VEHICULO_IDCommand(decimal tipo_vehiculo_id, bool tipo_vehiculo_idNull)
		{
			string whereSql = "";
			if(tipo_vehiculo_idNull)
				whereSql += "TIPO_VEHICULO_ID IS NULL";
			else
				whereSql += "TIPO_VEHICULO_ID=" + _db.CreateSqlParameterName("TIPO_VEHICULO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tipo_vehiculo_idNull)
				AddParameter(cmd, "TIPO_VEHICULO_ID", tipo_vehiculo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
		/// </summary>
		/// <param name="consignatario_persona_id">The <c>CONSIGNATARIO_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByCONSIGNATARIO_PERSONA_ID(decimal consignatario_persona_id)
		{
			return DeleteByCONSIGNATARIO_PERSONA_ID(consignatario_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
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
		/// delete records using the <c>FK_CAMIONES_CONF_TARA_CONS_ID</c> foreign key.
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
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
		/// </summary>
		/// <param name="transportadora_persona_id">The <c>TRANSPORTADORA_PERSONA_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTRANSPORTADORA_PERSONA_ID(decimal transportadora_persona_id)
		{
			return DeleteByTRANSPORTADORA_PERSONA_ID(transportadora_persona_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
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
		/// delete records using the <c>FK_CAMIONES_CONF_TARA_TRAN_ID</c> foreign key.
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
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id)
		{
			return DeleteByUSUARIO_ID(usuario_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>CAMIONES_CONFIGURACION_TARA</c> table using the 
		/// <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_ID(decimal usuario_id, bool usuario_idNull)
		{
			return CreateDeleteByUSUARIO_IDCommand(usuario_id, usuario_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_CAMIONES_CONF_TARA_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_id">The <c>USUARIO_ID</c> column value.</param>
		/// <param name="usuario_idNull">true if the method ignores the usuario_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_IDCommand(decimal usuario_id, bool usuario_idNull)
		{
			string whereSql = "";
			if(usuario_idNull)
				whereSql += "USUARIO_ID IS NULL";
			else
				whereSql += "USUARIO_ID=" + _db.CreateSqlParameterName("USUARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!usuario_idNull)
				AddParameter(cmd, "USUARIO_ID", usuario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>CAMIONES_CONFIGURACION_TARA</c> records that match the specified criteria.
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
		/// to delete <c>CAMIONES_CONFIGURACION_TARA</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.CAMIONES_CONFIGURACION_TARA";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>CAMIONES_CONFIGURACION_TARA</c> table.
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
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		protected CAMIONES_CONFIGURACION_TARARow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		protected CAMIONES_CONFIGURACION_TARARow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="CAMIONES_CONFIGURACION_TARARow"/> objects.</returns>
		protected virtual CAMIONES_CONFIGURACION_TARARow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int fecha_horaColumnIndex = reader.GetOrdinal("FECHA_HORA");
			int usuario_idColumnIndex = reader.GetOrdinal("USUARIO_ID");
			int taraColumnIndex = reader.GetOrdinal("TARA");
			int chapa_camionColumnIndex = reader.GetOrdinal("CHAPA_CAMION");
			int chapa_carretaColumnIndex = reader.GetOrdinal("CHAPA_CARRETA");
			int chofer_documentoColumnIndex = reader.GetOrdinal("CHOFER_DOCUMENTO");
			int chofer_nombreColumnIndex = reader.GetOrdinal("CHOFER_NOMBRE");
			int tara_contenedorColumnIndex = reader.GetOrdinal("TARA_CONTENEDOR");
			int peso_brutoColumnIndex = reader.GetOrdinal("PESO_BRUTO");
			int peso_netoColumnIndex = reader.GetOrdinal("PESO_NETO");
			int sin_cargaColumnIndex = reader.GetOrdinal("SIN_CARGA");
			int contenedorColumnIndex = reader.GetOrdinal("CONTENEDOR");
			int transportadora_persona_idColumnIndex = reader.GetOrdinal("TRANSPORTADORA_PERSONA_ID");
			int transportadora_nombreColumnIndex = reader.GetOrdinal("TRANSPORTADORA_NOMBRE");
			int tipo_vehiculo_idColumnIndex = reader.GetOrdinal("TIPO_VEHICULO_ID");
			int consignatario_persona_idColumnIndex = reader.GetOrdinal("CONSIGNATARIO_PERSONA_ID");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					CAMIONES_CONFIGURACION_TARARow record = new CAMIONES_CONFIGURACION_TARARow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					if(!reader.IsDBNull(fecha_horaColumnIndex))
						record.FECHA_HORA = Convert.ToDateTime(reader.GetValue(fecha_horaColumnIndex));
					if(!reader.IsDBNull(usuario_idColumnIndex))
						record.USUARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_idColumnIndex)), 9);
					if(!reader.IsDBNull(taraColumnIndex))
						record.TARA = Math.Round(Convert.ToDecimal(reader.GetValue(taraColumnIndex)), 9);
					if(!reader.IsDBNull(chapa_camionColumnIndex))
						record.CHAPA_CAMION = Convert.ToString(reader.GetValue(chapa_camionColumnIndex));
					if(!reader.IsDBNull(chapa_carretaColumnIndex))
						record.CHAPA_CARRETA = Convert.ToString(reader.GetValue(chapa_carretaColumnIndex));
					if(!reader.IsDBNull(chofer_documentoColumnIndex))
						record.CHOFER_DOCUMENTO = Convert.ToString(reader.GetValue(chofer_documentoColumnIndex));
					if(!reader.IsDBNull(chofer_nombreColumnIndex))
						record.CHOFER_NOMBRE = Convert.ToString(reader.GetValue(chofer_nombreColumnIndex));
					if(!reader.IsDBNull(tara_contenedorColumnIndex))
						record.TARA_CONTENEDOR = Math.Round(Convert.ToDecimal(reader.GetValue(tara_contenedorColumnIndex)), 9);
					if(!reader.IsDBNull(peso_brutoColumnIndex))
						record.PESO_BRUTO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_brutoColumnIndex)), 9);
					if(!reader.IsDBNull(peso_netoColumnIndex))
						record.PESO_NETO = Math.Round(Convert.ToDecimal(reader.GetValue(peso_netoColumnIndex)), 9);
					record.SIN_CARGA = Convert.ToString(reader.GetValue(sin_cargaColumnIndex));
					if(!reader.IsDBNull(contenedorColumnIndex))
						record.CONTENEDOR = Convert.ToString(reader.GetValue(contenedorColumnIndex));
					if(!reader.IsDBNull(transportadora_persona_idColumnIndex))
						record.TRANSPORTADORA_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(transportadora_persona_idColumnIndex)), 9);
					if(!reader.IsDBNull(transportadora_nombreColumnIndex))
						record.TRANSPORTADORA_NOMBRE = Convert.ToString(reader.GetValue(transportadora_nombreColumnIndex));
					if(!reader.IsDBNull(tipo_vehiculo_idColumnIndex))
						record.TIPO_VEHICULO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_vehiculo_idColumnIndex)), 9);
					if(!reader.IsDBNull(consignatario_persona_idColumnIndex))
						record.CONSIGNATARIO_PERSONA_ID = Math.Round(Convert.ToDecimal(reader.GetValue(consignatario_persona_idColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (CAMIONES_CONFIGURACION_TARARow[])(recordList.ToArray(typeof(CAMIONES_CONFIGURACION_TARARow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="CAMIONES_CONFIGURACION_TARARow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="CAMIONES_CONFIGURACION_TARARow"/> object.</returns>
		protected virtual CAMIONES_CONFIGURACION_TARARow MapRow(DataRow row)
		{
			CAMIONES_CONFIGURACION_TARARow mappedObject = new CAMIONES_CONFIGURACION_TARARow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "FECHA_HORA"
			dataColumn = dataTable.Columns["FECHA_HORA"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_HORA = (System.DateTime)row[dataColumn];
			// Column "USUARIO_ID"
			dataColumn = dataTable.Columns["USUARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_ID = (decimal)row[dataColumn];
			// Column "TARA"
			dataColumn = dataTable.Columns["TARA"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARA = (decimal)row[dataColumn];
			// Column "CHAPA_CAMION"
			dataColumn = dataTable.Columns["CHAPA_CAMION"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CAMION = (string)row[dataColumn];
			// Column "CHAPA_CARRETA"
			dataColumn = dataTable.Columns["CHAPA_CARRETA"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHAPA_CARRETA = (string)row[dataColumn];
			// Column "CHOFER_DOCUMENTO"
			dataColumn = dataTable.Columns["CHOFER_DOCUMENTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_DOCUMENTO = (string)row[dataColumn];
			// Column "CHOFER_NOMBRE"
			dataColumn = dataTable.Columns["CHOFER_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.CHOFER_NOMBRE = (string)row[dataColumn];
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
			// Column "SIN_CARGA"
			dataColumn = dataTable.Columns["SIN_CARGA"];
			if(!row.IsNull(dataColumn))
				mappedObject.SIN_CARGA = (string)row[dataColumn];
			// Column "CONTENEDOR"
			dataColumn = dataTable.Columns["CONTENEDOR"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONTENEDOR = (string)row[dataColumn];
			// Column "TRANSPORTADORA_PERSONA_ID"
			dataColumn = dataTable.Columns["TRANSPORTADORA_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_PERSONA_ID = (decimal)row[dataColumn];
			// Column "TRANSPORTADORA_NOMBRE"
			dataColumn = dataTable.Columns["TRANSPORTADORA_NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.TRANSPORTADORA_NOMBRE = (string)row[dataColumn];
			// Column "TIPO_VEHICULO_ID"
			dataColumn = dataTable.Columns["TIPO_VEHICULO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_VEHICULO_ID = (decimal)row[dataColumn];
			// Column "CONSIGNATARIO_PERSONA_ID"
			dataColumn = dataTable.Columns["CONSIGNATARIO_PERSONA_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.CONSIGNATARIO_PERSONA_ID = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>CAMIONES_CONFIGURACION_TARA</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "CAMIONES_CONFIGURACION_TARA";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_HORA", typeof(System.DateTime));
			dataColumn = dataTable.Columns.Add("USUARIO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARA", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CHAPA_CAMION", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CHAPA_CARRETA", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CHOFER_DOCUMENTO", typeof(string));
			dataColumn.MaxLength = 25;
			dataColumn = dataTable.Columns.Add("CHOFER_NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn = dataTable.Columns.Add("TARA_CONTENEDOR", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_BRUTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PESO_NETO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("SIN_CARGA", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("CONTENEDOR", typeof(string));
			dataColumn.MaxLength = 50;
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_PERSONA_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TRANSPORTADORA_NOMBRE", typeof(string));
			dataColumn.MaxLength = 150;
			dataColumn = dataTable.Columns.Add("TIPO_VEHICULO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("CONSIGNATARIO_PERSONA_ID", typeof(decimal));
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

				case "FECHA_HORA":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "USUARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARA":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CHAPA_CAMION":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHAPA_CARRETA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_DOCUMENTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "CHOFER_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
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

				case "SIN_CARGA":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "CONTENEDOR":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TRANSPORTADORA_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TRANSPORTADORA_NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_VEHICULO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "CONSIGNATARIO_PERSONA_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of CAMIONES_CONFIGURACION_TARACollection_Base class
}  // End of namespace
