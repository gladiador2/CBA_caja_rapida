// <fileinfo name="TARIFARIOS_COLUMNASCollection_Base.cs">
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
	/// The base class for <see cref="TARIFARIOS_COLUMNASCollection"/>. Provides methods 
	/// for common database table operations. 
	/// </summary>
	/// <remarks>
	/// Do not change this source code. Update the <see cref="TARIFARIOS_COLUMNASCollection"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TARIFARIOS_COLUMNASCollection_Base
	{
		// Constants
		public const string IDColumnName = "ID";
		public const string TARIFARIO_IDColumnName = "TARIFARIO_ID";
		public const string NOMBREColumnName = "NOMBRE";
		public const string TIPO_DATO_IDColumnName = "TIPO_DATO_ID";
		public const string ESTADOColumnName = "ESTADO";
		public const string USUARIO_MODIFICACION_IDColumnName = "USUARIO_MODIFICACION_ID";
		public const string FECHA_MODIFICACIONColumnName = "FECHA_MODIFICACION";
		public const string OBLIGATORIOColumnName = "OBLIGATORIO";
		public const string ORDENColumnName = "ORDEN";
		public const string ARTICULO_RELACIONADO_IDColumnName = "ARTICULO_RELACIONADO_ID";
		public const string TARIFARIOS_GRUPO_IDColumnName = "TARIFARIOS_GRUPO_ID";
		public const string MINIMOColumnName = "MINIMO";
		public const string MAXIMOColumnName = "MAXIMO";
		public const string VALOR_POR_DEFECTOColumnName = "VALOR_POR_DEFECTO";
		public const string INCLUIR_SIEMPREColumnName = "INCLUIR_SIEMPRE";
		public const string TOMAR_DATO_INGRESADOColumnName = "TOMAR_DATO_INGRESADO";
		public const string PRIMER_PERIODOColumnName = "PRIMER_PERIODO";
		public const string PERIODOS_POSTERIORESColumnName = "PERIODOS_POSTERIORES";
		public const string PRORRATEO_PERIODOSColumnName = "PRORRATEO_PERIODOS";

		// Instance fields
		private CBAV2 _db;

		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_COLUMNASCollection_Base"/> 
		/// class with the specified <see cref="CBAV2"/>.
		/// </summary>
		/// <param name="db">The <see cref="CBAV2"/> object.</param>
		public TARIFARIOS_COLUMNASCollection_Base(CBAV2 db)
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
		/// Gets an array of all records from the <c>TARIFARIOS_COLUMNAS</c> table.
		/// </summary>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNASRow[] GetAll()
		{
			return MapRecords(CreateGetAllCommand());
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object that 
		/// includes all records from the <c>TARIFARIOS_COLUMNAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetAllAsDataTable()
		{
			return MapRecordsToDataTable(CreateGetAllCommand());
		}

		/// <summary>
		/// Creates and returns an <see cref="System.Data.IDbCommand"/> object that is used
		/// to retrieve all records from the <c>TARIFARIOS_COLUMNAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetAllCommand()
		{
			return CreateGetCommand(null, null);
		}

		/// <summary>
		/// Gets the first <see cref="TARIFARIOS_COLUMNASRow"/> objects that 
		/// match the search condition.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>An instance of <see cref="TARIFARIOS_COLUMNASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public TARIFARIOS_COLUMNASRow GetRow(string whereSql)
		{
			int totalRecordCount = -1;
			TARIFARIOS_COLUMNASRow[] rows = GetAsArray(whereSql, null, 0, 1, ref totalRecordCount);
			return 0 == rows.Length ? null : rows[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects that 
		/// match the search condition, in the the specified sort order.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. For example: 
		/// <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <param name="orderBySql">The column name(s) followed by "ASC" (ascending) or "DESC" (descending).
		/// Columns are sorted in ascending order by default. For example: <c>"LastName ASC, FirstName ASC"</c>.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public TARIFARIOS_COLUMNASRow[] GetAsArray(string whereSql, string orderBySql)
		{
			int totalRecordCount = -1;
			return GetAsArray(whereSql, orderBySql, 0, int.MaxValue, ref totalRecordCount);
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects that 
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNASRow[] GetAsArray(string whereSql, string orderBySql,
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
			            
			string sql = "SELECT * FROM TRC.TARIFARIOS_COLUMNAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			if(null != orderBySql && 0 < orderBySql.Length)
				sql += " ORDER BY " + orderBySql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Gets <see cref="TARIFARIOS_COLUMNASRow"/> by the primary key.
		/// </summary>
		/// <param name="id">The <c>ID</c> column value.</param>
		/// <returns>An instance of <see cref="TARIFARIOS_COLUMNASRow"/> or null reference 
		/// (Nothing in Visual Basic) if the object was not found.</returns>
		public virtual TARIFARIOS_COLUMNASRow GetByPrimaryKey(decimal id)
		{
			string whereSql = "ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "ID", id);
			TARIFARIOS_COLUMNASRow[] tempArray = MapRecords(cmd);
			return 0 == tempArray.Length ? null : tempArray[0];
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects 
		/// by the <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public TARIFARIOS_COLUMNASRow[] GetByARTICULO_RELACIONADO_ID(decimal articulo_relacionado_id)
		{
			return GetByARTICULO_RELACIONADO_ID(articulo_relacionado_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects 
		/// by the <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <param name="articulo_relacionado_idNull">true if the method ignores the articulo_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNASRow[] GetByARTICULO_RELACIONADO_ID(decimal articulo_relacionado_id, bool articulo_relacionado_idNull)
		{
			return MapRecords(CreateGetByARTICULO_RELACIONADO_IDCommand(articulo_relacionado_id, articulo_relacionado_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByARTICULO_RELACIONADO_IDAsDataTable(decimal articulo_relacionado_id)
		{
			return GetByARTICULO_RELACIONADO_IDAsDataTable(articulo_relacionado_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <param name="articulo_relacionado_idNull">true if the method ignores the articulo_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByARTICULO_RELACIONADO_IDAsDataTable(decimal articulo_relacionado_id, bool articulo_relacionado_idNull)
		{
			return MapRecordsToDataTable(CreateGetByARTICULO_RELACIONADO_IDCommand(articulo_relacionado_id, articulo_relacionado_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <param name="articulo_relacionado_idNull">true if the method ignores the articulo_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByARTICULO_RELACIONADO_IDCommand(decimal articulo_relacionado_id, bool articulo_relacionado_idNull)
		{
			string whereSql = "";
			if(articulo_relacionado_idNull)
				whereSql += "ARTICULO_RELACIONADO_ID IS NULL";
			else
				whereSql += "ARTICULO_RELACIONADO_ID=" + _db.CreateSqlParameterName("ARTICULO_RELACIONADO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!articulo_relacionado_idNull)
				AddParameter(cmd, "ARTICULO_RELACIONADO_ID", articulo_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects 
		/// by the <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public TARIFARIOS_COLUMNASRow[] GetByTARIFARIOS_GRUPO_ID(decimal tarifarios_grupo_id)
		{
			return GetByTARIFARIOS_GRUPO_ID(tarifarios_grupo_id, false);
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects 
		/// by the <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <param name="tarifarios_grupo_idNull">true if the method ignores the tarifarios_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNASRow[] GetByTARIFARIOS_GRUPO_ID(decimal tarifarios_grupo_id, bool tarifarios_grupo_idNull)
		{
			return MapRecords(CreateGetByTARIFARIOS_GRUPO_IDCommand(tarifarios_grupo_id, tarifarios_grupo_idNull));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public DataTable GetByTARIFARIOS_GRUPO_IDAsDataTable(decimal tarifarios_grupo_id)
		{
			return GetByTARIFARIOS_GRUPO_IDAsDataTable(tarifarios_grupo_id, false);
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <param name="tarifarios_grupo_idNull">true if the method ignores the tarifarios_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTARIFARIOS_GRUPO_IDAsDataTable(decimal tarifarios_grupo_id, bool tarifarios_grupo_idNull)
		{
			return MapRecordsToDataTable(CreateGetByTARIFARIOS_GRUPO_IDCommand(tarifarios_grupo_id, tarifarios_grupo_idNull));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <param name="tarifarios_grupo_idNull">true if the method ignores the tarifarios_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTARIFARIOS_GRUPO_IDCommand(decimal tarifarios_grupo_id, bool tarifarios_grupo_idNull)
		{
			string whereSql = "";
			if(tarifarios_grupo_idNull)
				whereSql += "TARIFARIOS_GRUPO_ID IS NULL";
			else
				whereSql += "TARIFARIOS_GRUPO_ID=" + _db.CreateSqlParameterName("TARIFARIOS_GRUPO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			if(!tarifarios_grupo_idNull)
				AddParameter(cmd, "TARIFARIOS_GRUPO_ID", tarifarios_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects 
		/// by the <c>FK_TARIFARIOS_COL_TARIFARIO</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNASRow[] GetByTARIFARIO_ID(decimal tarifario_id)
		{
			return MapRecords(CreateGetByTARIFARIO_IDCommand(tarifario_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_COL_TARIFARIO</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByTARIFARIO_IDAsDataTable(decimal tarifario_id)
		{
			return MapRecordsToDataTable(CreateGetByTARIFARIO_IDCommand(tarifario_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_COL_TARIFARIO</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByTARIFARIO_IDCommand(decimal tarifario_id)
		{
			string whereSql = "";
			whereSql += "TARIFARIO_ID=" + _db.CreateSqlParameterName("TARIFARIO_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "TARIFARIO_ID", tarifario_id);
			return cmd;
		}

		/// <summary>
		/// Gets an array of <see cref="TARIFARIOS_COLUMNASRow"/> objects 
		/// by the <c>FK_TARIFARIOS_COL_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		public virtual TARIFARIOS_COLUMNASRow[] GetByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return MapRecords(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id));
		}

		/// <summary>
		/// Gets a <see cref="System.Data.DataTable"/> object 
		/// by the <c>FK_TARIFARIOS_COL_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		public virtual DataTable GetByUSUARIO_MODIFICACION_IDAsDataTable(decimal usuario_modificacion_id)
		{
			return MapRecordsToDataTable(CreateGetByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id));
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to 
		/// return records by the <c>FK_TARIFARIOS_COL_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateGetByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateGetCommand(whereSql, null);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Adds a new record into the <c>TARIFARIOS_COLUMNAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TARIFARIOS_COLUMNASRow"/> object to be inserted.</param>
		public virtual void Insert(TARIFARIOS_COLUMNASRow value)
		{
						
			string sqlStr = "INSERT INTO TRC.TARIFARIOS_COLUMNAS (" +
				"ID, " +
				"TARIFARIO_ID, " +
				"NOMBRE, " +
				"TIPO_DATO_ID, " +
				"ESTADO, " +
				"USUARIO_MODIFICACION_ID, " +
				"FECHA_MODIFICACION, " +
				"OBLIGATORIO, " +
				"ORDEN, " +
				"ARTICULO_RELACIONADO_ID, " +
				"TARIFARIOS_GRUPO_ID, " +
				"MINIMO, " +
				"MAXIMO, " +
				"VALOR_POR_DEFECTO, " +
				"INCLUIR_SIEMPRE, " +
				"TOMAR_DATO_INGRESADO, " +
				"PRIMER_PERIODO, " +
				"PERIODOS_POSTERIORES, " +
				"PRORRATEO_PERIODOS" +
				") VALUES (" +
				_db.CreateSqlParameterName("ID") + ", " +
				_db.CreateSqlParameterName("TARIFARIO_ID") + ", " +
				_db.CreateSqlParameterName("NOMBRE") + ", " +
				_db.CreateSqlParameterName("TIPO_DATO_ID") + ", " +
				_db.CreateSqlParameterName("ESTADO") + ", " +
				_db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				_db.CreateSqlParameterName("FECHA_MODIFICACION") + ", " +
				_db.CreateSqlParameterName("OBLIGATORIO") + ", " +
				_db.CreateSqlParameterName("ORDEN") + ", " +
				_db.CreateSqlParameterName("ARTICULO_RELACIONADO_ID") + ", " +
				_db.CreateSqlParameterName("TARIFARIOS_GRUPO_ID") + ", " +
				_db.CreateSqlParameterName("MINIMO") + ", " +
				_db.CreateSqlParameterName("MAXIMO") + ", " +
				_db.CreateSqlParameterName("VALOR_POR_DEFECTO") + ", " +
				_db.CreateSqlParameterName("INCLUIR_SIEMPRE") + ", " +
				_db.CreateSqlParameterName("TOMAR_DATO_INGRESADO") + ", " +
				_db.CreateSqlParameterName("PRIMER_PERIODO") + ", " +
				_db.CreateSqlParameterName("PERIODOS_POSTERIORES") + ", " +
				_db.CreateSqlParameterName("PRORRATEO_PERIODOS") + ")";
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "ID", value.ID);
			AddParameter(cmd, "TARIFARIO_ID", value.TARIFARIO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "TIPO_DATO_ID", value.TIPO_DATO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "FECHA_MODIFICACION", value.FECHA_MODIFICACION);
			AddParameter(cmd, "OBLIGATORIO", value.OBLIGATORIO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "ARTICULO_RELACIONADO_ID",
				value.IsARTICULO_RELACIONADO_IDNull ? DBNull.Value : (object)value.ARTICULO_RELACIONADO_ID);
			AddParameter(cmd, "TARIFARIOS_GRUPO_ID",
				value.IsTARIFARIOS_GRUPO_IDNull ? DBNull.Value : (object)value.TARIFARIOS_GRUPO_ID);
			AddParameter(cmd, "MINIMO",
				value.IsMINIMONull ? DBNull.Value : (object)value.MINIMO);
			AddParameter(cmd, "MAXIMO",
				value.IsMAXIMONull ? DBNull.Value : (object)value.MAXIMO);
			AddParameter(cmd, "VALOR_POR_DEFECTO",
				value.IsVALOR_POR_DEFECTONull ? DBNull.Value : (object)value.VALOR_POR_DEFECTO);
			AddParameter(cmd, "INCLUIR_SIEMPRE", value.INCLUIR_SIEMPRE);
			AddParameter(cmd, "TOMAR_DATO_INGRESADO", value.TOMAR_DATO_INGRESADO);
			AddParameter(cmd, "PRIMER_PERIODO",
				value.IsPRIMER_PERIODONull ? DBNull.Value : (object)value.PRIMER_PERIODO);
			AddParameter(cmd, "PERIODOS_POSTERIORES",
				value.IsPERIODOS_POSTERIORESNull ? DBNull.Value : (object)value.PERIODOS_POSTERIORES);
			AddParameter(cmd, "PRORRATEO_PERIODOS",
				value.IsPRORRATEO_PERIODOSNull ? DBNull.Value : (object)value.PRORRATEO_PERIODOS);
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates a record in the <c>TARIFARIOS_COLUMNAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TARIFARIOS_COLUMNASRow"/>
		/// object used to update the table record.</param>
		/// <returns>true if the record was updated; otherwise, false.</returns>
		public virtual bool Update(TARIFARIOS_COLUMNASRow value)
		{
			
			string sqlStr = "UPDATE TRC.TARIFARIOS_COLUMNAS SET " +
				"TARIFARIO_ID=" + _db.CreateSqlParameterName("TARIFARIO_ID") + ", " +
				"NOMBRE=" + _db.CreateSqlParameterName("NOMBRE") + ", " +
				"TIPO_DATO_ID=" + _db.CreateSqlParameterName("TIPO_DATO_ID") + ", " +
				"ESTADO=" + _db.CreateSqlParameterName("ESTADO") + ", " +
				"USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID") + ", " +
				"FECHA_MODIFICACION=" + _db.CreateSqlParameterName("FECHA_MODIFICACION") + ", " +
				"OBLIGATORIO=" + _db.CreateSqlParameterName("OBLIGATORIO") + ", " +
				"ORDEN=" + _db.CreateSqlParameterName("ORDEN") + ", " +
				"ARTICULO_RELACIONADO_ID=" + _db.CreateSqlParameterName("ARTICULO_RELACIONADO_ID") + ", " +
				"TARIFARIOS_GRUPO_ID=" + _db.CreateSqlParameterName("TARIFARIOS_GRUPO_ID") + ", " +
				"MINIMO=" + _db.CreateSqlParameterName("MINIMO") + ", " +
				"MAXIMO=" + _db.CreateSqlParameterName("MAXIMO") + ", " +
				"VALOR_POR_DEFECTO=" + _db.CreateSqlParameterName("VALOR_POR_DEFECTO") + ", " +
				"INCLUIR_SIEMPRE=" + _db.CreateSqlParameterName("INCLUIR_SIEMPRE") + ", " +
				"TOMAR_DATO_INGRESADO=" + _db.CreateSqlParameterName("TOMAR_DATO_INGRESADO") + ", " +
				"PRIMER_PERIODO=" + _db.CreateSqlParameterName("PRIMER_PERIODO") + ", " +
				"PERIODOS_POSTERIORES=" + _db.CreateSqlParameterName("PERIODOS_POSTERIORES") + ", " +
				"PRORRATEO_PERIODOS=" + _db.CreateSqlParameterName("PRORRATEO_PERIODOS") +
				" WHERE " +
				"ID=" + _db.CreateSqlParameterName("ID");
			IDbCommand cmd = _db.CreateCommand(sqlStr);
			AddParameter(cmd, "TARIFARIO_ID", value.TARIFARIO_ID);
			AddParameter(cmd, "NOMBRE", value.NOMBRE);
			AddParameter(cmd, "TIPO_DATO_ID", value.TIPO_DATO_ID);
			AddParameter(cmd, "ESTADO", value.ESTADO);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", value.USUARIO_MODIFICACION_ID);
			AddParameter(cmd, "FECHA_MODIFICACION", value.FECHA_MODIFICACION);
			AddParameter(cmd, "OBLIGATORIO", value.OBLIGATORIO);
			AddParameter(cmd, "ORDEN", value.ORDEN);
			AddParameter(cmd, "ARTICULO_RELACIONADO_ID",
				value.IsARTICULO_RELACIONADO_IDNull ? DBNull.Value : (object)value.ARTICULO_RELACIONADO_ID);
			AddParameter(cmd, "TARIFARIOS_GRUPO_ID",
				value.IsTARIFARIOS_GRUPO_IDNull ? DBNull.Value : (object)value.TARIFARIOS_GRUPO_ID);
			AddParameter(cmd, "MINIMO",
				value.IsMINIMONull ? DBNull.Value : (object)value.MINIMO);
			AddParameter(cmd, "MAXIMO",
				value.IsMAXIMONull ? DBNull.Value : (object)value.MAXIMO);
			AddParameter(cmd, "VALOR_POR_DEFECTO",
				value.IsVALOR_POR_DEFECTONull ? DBNull.Value : (object)value.VALOR_POR_DEFECTO);
			AddParameter(cmd, "INCLUIR_SIEMPRE", value.INCLUIR_SIEMPRE);
			AddParameter(cmd, "TOMAR_DATO_INGRESADO", value.TOMAR_DATO_INGRESADO);
			AddParameter(cmd, "PRIMER_PERIODO",
				value.IsPRIMER_PERIODONull ? DBNull.Value : (object)value.PRIMER_PERIODO);
			AddParameter(cmd, "PERIODOS_POSTERIORES",
				value.IsPERIODOS_POSTERIORESNull ? DBNull.Value : (object)value.PERIODOS_POSTERIORES);
			AddParameter(cmd, "PRORRATEO_PERIODOS",
				value.IsPRORRATEO_PERIODOSNull ? DBNull.Value : (object)value.PRORRATEO_PERIODOS);
			AddParameter(cmd, "ID", value.ID);
			return 0 != cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updates the <c>TARIFARIOS_COLUMNAS</c> table and calls the <c>AcceptChanges</c> method
		/// on the changed DataRow objects.
		/// </summary>
		/// <param name="table">The <see cref="System.Data.DataTable"/> used to update the data source.</param>
		public void Update(DataTable table)
		{
			Update(table, true);
		}

		/// <summary>
		/// Updates the <c>TARIFARIOS_COLUMNAS</c> table. Pass <c>false</c> as the <c>acceptChanges</c> 
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
		/// Deletes the specified object from the <c>TARIFARIOS_COLUMNAS</c> table.
		/// </summary>
		/// <param name="value">The <see cref="TARIFARIOS_COLUMNASRow"/> object to delete.</param>
		/// <returns>true if the record was deleted; otherwise, false.</returns>
		public bool Delete(TARIFARIOS_COLUMNASRow value)
		{
			return DeleteByPrimaryKey(value.ID);
		}

		/// <summary>
		/// Deletes a record from the <c>TARIFARIOS_COLUMNAS</c> table using
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
		/// Deletes records from the <c>TARIFARIOS_COLUMNAS</c> table using the 
		/// <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_RELACIONADO_ID(decimal articulo_relacionado_id)
		{
			return DeleteByARTICULO_RELACIONADO_ID(articulo_relacionado_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_COLUMNAS</c> table using the 
		/// <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <param name="articulo_relacionado_idNull">true if the method ignores the articulo_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByARTICULO_RELACIONADO_ID(decimal articulo_relacionado_id, bool articulo_relacionado_idNull)
		{
			return CreateDeleteByARTICULO_RELACIONADO_IDCommand(articulo_relacionado_id, articulo_relacionado_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_COL_ART_ID</c> foreign key.
		/// </summary>
		/// <param name="articulo_relacionado_id">The <c>ARTICULO_RELACIONADO_ID</c> column value.</param>
		/// <param name="articulo_relacionado_idNull">true if the method ignores the articulo_relacionado_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByARTICULO_RELACIONADO_IDCommand(decimal articulo_relacionado_id, bool articulo_relacionado_idNull)
		{
			string whereSql = "";
			if(articulo_relacionado_idNull)
				whereSql += "ARTICULO_RELACIONADO_ID IS NULL";
			else
				whereSql += "ARTICULO_RELACIONADO_ID=" + _db.CreateSqlParameterName("ARTICULO_RELACIONADO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!articulo_relacionado_idNull)
				AddParameter(cmd, "ARTICULO_RELACIONADO_ID", articulo_relacionado_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_COLUMNAS</c> table using the 
		/// <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTARIFARIOS_GRUPO_ID(decimal tarifarios_grupo_id)
		{
			return DeleteByTARIFARIOS_GRUPO_ID(tarifarios_grupo_id, false);
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_COLUMNAS</c> table using the 
		/// <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <param name="tarifarios_grupo_idNull">true if the method ignores the tarifarios_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTARIFARIOS_GRUPO_ID(decimal tarifarios_grupo_id, bool tarifarios_grupo_idNull)
		{
			return CreateDeleteByTARIFARIOS_GRUPO_IDCommand(tarifarios_grupo_id, tarifarios_grupo_idNull).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_COL_TAR_GRUP_ID</c> foreign key.
		/// </summary>
		/// <param name="tarifarios_grupo_id">The <c>TARIFARIOS_GRUPO_ID</c> column value.</param>
		/// <param name="tarifarios_grupo_idNull">true if the method ignores the tarifarios_grupo_id
		/// parameter value and uses DbNull instead of it; otherwise, false.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTARIFARIOS_GRUPO_IDCommand(decimal tarifarios_grupo_id, bool tarifarios_grupo_idNull)
		{
			string whereSql = "";
			if(tarifarios_grupo_idNull)
				whereSql += "TARIFARIOS_GRUPO_ID IS NULL";
			else
				whereSql += "TARIFARIOS_GRUPO_ID=" + _db.CreateSqlParameterName("TARIFARIOS_GRUPO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			if(!tarifarios_grupo_idNull)
				AddParameter(cmd, "TARIFARIOS_GRUPO_ID", tarifarios_grupo_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_COLUMNAS</c> table using the 
		/// <c>FK_TARIFARIOS_COL_TARIFARIO</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByTARIFARIO_ID(decimal tarifario_id)
		{
			return CreateDeleteByTARIFARIO_IDCommand(tarifario_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_COL_TARIFARIO</c> foreign key.
		/// </summary>
		/// <param name="tarifario_id">The <c>TARIFARIO_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByTARIFARIO_IDCommand(decimal tarifario_id)
		{
			string whereSql = "";
			whereSql += "TARIFARIO_ID=" + _db.CreateSqlParameterName("TARIFARIO_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "TARIFARIO_ID", tarifario_id);
			return cmd;
		}

		/// <summary>
		/// Deletes records from the <c>TARIFARIOS_COLUMNAS</c> table using the 
		/// <c>FK_TARIFARIOS_COL_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>The number of records deleted from the table.</returns>
		public int DeleteByUSUARIO_MODIFICACION_ID(decimal usuario_modificacion_id)
		{
			return CreateDeleteByUSUARIO_MODIFICACION_IDCommand(usuario_modificacion_id).ExecuteNonQuery();
		}

		/// <summary>
		/// Creates an <see cref="System.Data.IDbCommand"/> object that can be used to
		/// delete records using the <c>FK_TARIFARIOS_COL_USU_ID</c> foreign key.
		/// </summary>
		/// <param name="usuario_modificacion_id">The <c>USUARIO_MODIFICACION_ID</c> column value.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteByUSUARIO_MODIFICACION_IDCommand(decimal usuario_modificacion_id)
		{
			string whereSql = "";
			whereSql += "USUARIO_MODIFICACION_ID=" + _db.CreateSqlParameterName("USUARIO_MODIFICACION_ID");

			IDbCommand cmd = CreateDeleteCommand(whereSql);
			AddParameter(cmd, "USUARIO_MODIFICACION_ID", usuario_modificacion_id);
			return cmd;
		}

		/// <summary>
		/// Deletes <c>TARIFARIOS_COLUMNAS</c> records that match the specified criteria.
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
		/// to delete <c>TARIFARIOS_COLUMNAS</c> records that match the specified criteria.
		/// </summary>
		/// <param name="whereSql">The SQL search condition. 
		/// For example: <c>"FirstName='Smith' AND Zip=75038"</c>.</param>
		/// <returns>A reference to the <see cref="System.Data.IDbCommand"/> object.</returns>
		protected virtual IDbCommand CreateDeleteCommand(string whereSql)
		{
			
			string sql = "DELETE FROM TRC.TARIFARIOS_COLUMNAS";
			if(null != whereSql && 0 < whereSql.Length)
				sql += " WHERE " + whereSql;
			return _db.CreateCommand(sql);
		}

		/// <summary>
		/// Deletes all records from the <c>TARIFARIOS_COLUMNAS</c> table.
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		protected TARIFARIOS_COLUMNASRow[] MapRecords(IDbCommand command)
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		protected TARIFARIOS_COLUMNASRow[] MapRecords(IDataReader reader)
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
		/// <returns>An array of <see cref="TARIFARIOS_COLUMNASRow"/> objects.</returns>
		protected virtual TARIFARIOS_COLUMNASRow[] MapRecords(IDataReader reader, 
										int startIndex, int length, ref int totalRecordCount)
		{
			if(0 > startIndex)
				throw new ArgumentOutOfRangeException("startIndex", startIndex, "StartIndex cannot be less than zero.");
			if(0 > length)
				throw new ArgumentOutOfRangeException("length", length, "Length cannot be less than zero.");

			int idColumnIndex = reader.GetOrdinal("ID");
			int tarifario_idColumnIndex = reader.GetOrdinal("TARIFARIO_ID");
			int nombreColumnIndex = reader.GetOrdinal("NOMBRE");
			int tipo_dato_idColumnIndex = reader.GetOrdinal("TIPO_DATO_ID");
			int estadoColumnIndex = reader.GetOrdinal("ESTADO");
			int usuario_modificacion_idColumnIndex = reader.GetOrdinal("USUARIO_MODIFICACION_ID");
			int fecha_modificacionColumnIndex = reader.GetOrdinal("FECHA_MODIFICACION");
			int obligatorioColumnIndex = reader.GetOrdinal("OBLIGATORIO");
			int ordenColumnIndex = reader.GetOrdinal("ORDEN");
			int articulo_relacionado_idColumnIndex = reader.GetOrdinal("ARTICULO_RELACIONADO_ID");
			int tarifarios_grupo_idColumnIndex = reader.GetOrdinal("TARIFARIOS_GRUPO_ID");
			int minimoColumnIndex = reader.GetOrdinal("MINIMO");
			int maximoColumnIndex = reader.GetOrdinal("MAXIMO");
			int valor_por_defectoColumnIndex = reader.GetOrdinal("VALOR_POR_DEFECTO");
			int incluir_siempreColumnIndex = reader.GetOrdinal("INCLUIR_SIEMPRE");
			int tomar_dato_ingresadoColumnIndex = reader.GetOrdinal("TOMAR_DATO_INGRESADO");
			int primer_periodoColumnIndex = reader.GetOrdinal("PRIMER_PERIODO");
			int periodos_posterioresColumnIndex = reader.GetOrdinal("PERIODOS_POSTERIORES");
			int prorrateo_periodosColumnIndex = reader.GetOrdinal("PRORRATEO_PERIODOS");

			System.Collections.ArrayList recordList = new System.Collections.ArrayList();
			int ri = -startIndex;
			while(reader.Read())
			{
				ri++;
				if(ri > 0 && ri <= length)
				{
					TARIFARIOS_COLUMNASRow record = new TARIFARIOS_COLUMNASRow();
					recordList.Add(record);

					record.ID = Math.Round(Convert.ToDecimal(reader.GetValue(idColumnIndex)), 9);
					record.TARIFARIO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tarifario_idColumnIndex)), 9);
					record.NOMBRE = Convert.ToString(reader.GetValue(nombreColumnIndex));
					record.TIPO_DATO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tipo_dato_idColumnIndex)), 9);
					record.ESTADO = Convert.ToString(reader.GetValue(estadoColumnIndex));
					record.USUARIO_MODIFICACION_ID = Math.Round(Convert.ToDecimal(reader.GetValue(usuario_modificacion_idColumnIndex)), 9);
					record.FECHA_MODIFICACION = Convert.ToDateTime(reader.GetValue(fecha_modificacionColumnIndex));
					record.OBLIGATORIO = Convert.ToString(reader.GetValue(obligatorioColumnIndex));
					record.ORDEN = Math.Round(Convert.ToDecimal(reader.GetValue(ordenColumnIndex)), 9);
					if(!reader.IsDBNull(articulo_relacionado_idColumnIndex))
						record.ARTICULO_RELACIONADO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(articulo_relacionado_idColumnIndex)), 9);
					if(!reader.IsDBNull(tarifarios_grupo_idColumnIndex))
						record.TARIFARIOS_GRUPO_ID = Math.Round(Convert.ToDecimal(reader.GetValue(tarifarios_grupo_idColumnIndex)), 9);
					if(!reader.IsDBNull(minimoColumnIndex))
						record.MINIMO = Math.Round(Convert.ToDecimal(reader.GetValue(minimoColumnIndex)), 9);
					if(!reader.IsDBNull(maximoColumnIndex))
						record.MAXIMO = Math.Round(Convert.ToDecimal(reader.GetValue(maximoColumnIndex)), 9);
					if(!reader.IsDBNull(valor_por_defectoColumnIndex))
						record.VALOR_POR_DEFECTO = Math.Round(Convert.ToDecimal(reader.GetValue(valor_por_defectoColumnIndex)), 9);
					record.INCLUIR_SIEMPRE = Convert.ToString(reader.GetValue(incluir_siempreColumnIndex));
					record.TOMAR_DATO_INGRESADO = Convert.ToString(reader.GetValue(tomar_dato_ingresadoColumnIndex));
					if(!reader.IsDBNull(primer_periodoColumnIndex))
						record.PRIMER_PERIODO = Math.Round(Convert.ToDecimal(reader.GetValue(primer_periodoColumnIndex)), 9);
					if(!reader.IsDBNull(periodos_posterioresColumnIndex))
						record.PERIODOS_POSTERIORES = Math.Round(Convert.ToDecimal(reader.GetValue(periodos_posterioresColumnIndex)), 9);
					if(!reader.IsDBNull(prorrateo_periodosColumnIndex))
						record.PRORRATEO_PERIODOS = Math.Round(Convert.ToDecimal(reader.GetValue(prorrateo_periodosColumnIndex)), 9);

					if(ri == length && 0 != totalRecordCount)
						break;
				}
			}

			totalRecordCount = 0 == totalRecordCount ? ri + startIndex : -1;
			return (TARIFARIOS_COLUMNASRow[])(recordList.ToArray(typeof(TARIFARIOS_COLUMNASRow)));
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
		/// Converts <see cref="System.Data.DataRow"/> to <see cref="TARIFARIOS_COLUMNASRow"/>.
		/// </summary>
		/// <param name="row">The <see cref="System.Data.DataRow"/> object to be mapped.</param>
		/// <returns>A reference to the <see cref="TARIFARIOS_COLUMNASRow"/> object.</returns>
		protected virtual TARIFARIOS_COLUMNASRow MapRow(DataRow row)
		{
			TARIFARIOS_COLUMNASRow mappedObject = new TARIFARIOS_COLUMNASRow();
			DataTable dataTable = row.Table;
			DataColumn dataColumn;
			// Column "ID"
			dataColumn = dataTable.Columns["ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ID = (decimal)row[dataColumn];
			// Column "TARIFARIO_ID"
			dataColumn = dataTable.Columns["TARIFARIO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIO_ID = (decimal)row[dataColumn];
			// Column "NOMBRE"
			dataColumn = dataTable.Columns["NOMBRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.NOMBRE = (string)row[dataColumn];
			// Column "TIPO_DATO_ID"
			dataColumn = dataTable.Columns["TIPO_DATO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TIPO_DATO_ID = (decimal)row[dataColumn];
			// Column "ESTADO"
			dataColumn = dataTable.Columns["ESTADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.ESTADO = (string)row[dataColumn];
			// Column "USUARIO_MODIFICACION_ID"
			dataColumn = dataTable.Columns["USUARIO_MODIFICACION_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.USUARIO_MODIFICACION_ID = (decimal)row[dataColumn];
			// Column "FECHA_MODIFICACION"
			dataColumn = dataTable.Columns["FECHA_MODIFICACION"];
			if(!row.IsNull(dataColumn))
				mappedObject.FECHA_MODIFICACION = (System.DateTime)row[dataColumn];
			// Column "OBLIGATORIO"
			dataColumn = dataTable.Columns["OBLIGATORIO"];
			if(!row.IsNull(dataColumn))
				mappedObject.OBLIGATORIO = (string)row[dataColumn];
			// Column "ORDEN"
			dataColumn = dataTable.Columns["ORDEN"];
			if(!row.IsNull(dataColumn))
				mappedObject.ORDEN = (decimal)row[dataColumn];
			// Column "ARTICULO_RELACIONADO_ID"
			dataColumn = dataTable.Columns["ARTICULO_RELACIONADO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.ARTICULO_RELACIONADO_ID = (decimal)row[dataColumn];
			// Column "TARIFARIOS_GRUPO_ID"
			dataColumn = dataTable.Columns["TARIFARIOS_GRUPO_ID"];
			if(!row.IsNull(dataColumn))
				mappedObject.TARIFARIOS_GRUPO_ID = (decimal)row[dataColumn];
			// Column "MINIMO"
			dataColumn = dataTable.Columns["MINIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MINIMO = (decimal)row[dataColumn];
			// Column "MAXIMO"
			dataColumn = dataTable.Columns["MAXIMO"];
			if(!row.IsNull(dataColumn))
				mappedObject.MAXIMO = (decimal)row[dataColumn];
			// Column "VALOR_POR_DEFECTO"
			dataColumn = dataTable.Columns["VALOR_POR_DEFECTO"];
			if(!row.IsNull(dataColumn))
				mappedObject.VALOR_POR_DEFECTO = (decimal)row[dataColumn];
			// Column "INCLUIR_SIEMPRE"
			dataColumn = dataTable.Columns["INCLUIR_SIEMPRE"];
			if(!row.IsNull(dataColumn))
				mappedObject.INCLUIR_SIEMPRE = (string)row[dataColumn];
			// Column "TOMAR_DATO_INGRESADO"
			dataColumn = dataTable.Columns["TOMAR_DATO_INGRESADO"];
			if(!row.IsNull(dataColumn))
				mappedObject.TOMAR_DATO_INGRESADO = (string)row[dataColumn];
			// Column "PRIMER_PERIODO"
			dataColumn = dataTable.Columns["PRIMER_PERIODO"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRIMER_PERIODO = (decimal)row[dataColumn];
			// Column "PERIODOS_POSTERIORES"
			dataColumn = dataTable.Columns["PERIODOS_POSTERIORES"];
			if(!row.IsNull(dataColumn))
				mappedObject.PERIODOS_POSTERIORES = (decimal)row[dataColumn];
			// Column "PRORRATEO_PERIODOS"
			dataColumn = dataTable.Columns["PRORRATEO_PERIODOS"];
			if(!row.IsNull(dataColumn))
				mappedObject.PRORRATEO_PERIODOS = (decimal)row[dataColumn];
			return mappedObject;
		}

		/// <summary>
		/// Creates a <see cref="System.Data.DataTable"/> object for 
		/// the <c>TARIFARIOS_COLUMNAS</c> table.
		/// </summary>
		/// <returns>A reference to the <see cref="System.Data.DataTable"/> object.</returns>
		protected virtual DataTable CreateDataTable()
		{
			DataTable dataTable = new DataTable();
			dataTable.TableName = "TARIFARIOS_COLUMNAS";
			DataColumn dataColumn;
			dataColumn = dataTable.Columns.Add("ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TARIFARIO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("NOMBRE", typeof(string));
			dataColumn.MaxLength = 100;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TIPO_DATO_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ESTADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("USUARIO_MODIFICACION_ID", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("FECHA_MODIFICACION", typeof(System.DateTime));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("OBLIGATORIO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ORDEN", typeof(decimal));
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("ARTICULO_RELACIONADO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("TARIFARIOS_GRUPO_ID", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MINIMO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("MAXIMO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("VALOR_POR_DEFECTO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("INCLUIR_SIEMPRE", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("TOMAR_DATO_INGRESADO", typeof(string));
			dataColumn.MaxLength = 1;
			dataColumn.AllowDBNull = false;
			dataColumn = dataTable.Columns.Add("PRIMER_PERIODO", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PERIODOS_POSTERIORES", typeof(decimal));
			dataColumn = dataTable.Columns.Add("PRORRATEO_PERIODOS", typeof(decimal));
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

				case "TARIFARIO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "NOMBRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiString, value);
					break;

				case "TIPO_DATO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ESTADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "USUARIO_MODIFICACION_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "FECHA_MODIFICACION":
					parameter = _db.AddParameter(cmd, paramName, DbType.DateTime, value);
					break;

				case "OBLIGATORIO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "ORDEN":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "ARTICULO_RELACIONADO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "TARIFARIOS_GRUPO_ID":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MINIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "MAXIMO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "VALOR_POR_DEFECTO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "INCLUIR_SIEMPRE":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "TOMAR_DATO_INGRESADO":
					parameter = _db.AddParameter(cmd, paramName, DbType.AnsiStringFixedLength, value);
					break;

				case "PRIMER_PERIODO":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PERIODOS_POSTERIORES":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				case "PRORRATEO_PERIODOS":
					parameter = _db.AddParameter(cmd, paramName, DbType.Decimal, value);
					break;

				default:
					throw new ArgumentException("Unknown parameter name (" + paramName + ").");
			}
			return parameter;
		}
	} // End of TARIFARIOS_COLUMNASCollection_Base class
}  // End of namespace
